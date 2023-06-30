using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WepApiRepository.Model;

namespace WepApiRepository.Repositories
{
    public class ClassRepository : IClassRepository, IDisposable
    {
        private bool disposedValue = false;

        private AdventureContext context;

        public ClassRepository(AdventureContext context)
        {
            this.context = context;
        }

        public void DeleteClass(int id)
        {   
            
            Class _class = context.Classes.Include(p=>p.Students).FirstOrDefault(p=>p.Id ==id);
            
            bool isEmpty = !_class.Students.Any();
            if (isEmpty)
            {
                context.Classes.Remove(_class);
            }            
            
        }

        public Class GetClass(int id)
        {
            return context.Classes.Include(p=>p.Students).FirstOrDefault(p=>p.Id == id );
        }

        public List<Class> GetClasses()
        {
            return context.Classes.Include(p=>p.Students).ToList();
        }

        public void InsertClass(int id, string name)
        {
            Class _class = new Class();
            _class.Id = id;
            _class.Name = name;
            context.Classes.Add(_class);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateClass(int id, string name)
        {
            Class _class = context.Classes.Find(id);
            if (_class != null)
            {
                _class.Name = name;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
