using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using WepApiRepository.Model;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace WepApiRepository.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        // SchoolContext được kế thừa từ DbContext
        internal AdventureContext context;

        // Generic repository này sẽ hoạt động dựa trên entity được truyền vào khi đăng ký trong Startup.cs
        internal DbSet<TEntity> dbSet;

        public GenericRepository(AdventureContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        // Expression<Func<TEntity, bool>> filter: cho phép bạn truyền vào một filter expression dạng LINQ
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            // Query là 1 dạng IQueryable, chỉ được thực thi khi cần giá trị list
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Tiếp theo, nó sẽ kèm theo các property cần thiết khi người dùng chỉ định
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            // Sau cùng, nó thực thi bằng cách translate thành câu lệnh SQL và gọi xuống database
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        // trong asp.net, Id cho 1 object có thể là GUID hoặc int
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        // trong asp.net, Id cho 1 object có thể là GUID hoặc int
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}