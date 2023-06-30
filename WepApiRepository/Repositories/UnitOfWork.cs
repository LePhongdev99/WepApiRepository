using System;
using WepApiRepository.Model;

namespace WepApiRepository.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private AdventureContext context = new AdventureContext();
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Class> classRepository;

        // Kiểm tra xem repository đã được khởi tạo chưa
        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        // Kiểm tra xem repository đã được khởi tạo chưa
        public GenericRepository<Class> ClassRepository
        {
            get
            {
                if (this.classRepository == null)
                {
                    this.classRepository = new GenericRepository<Class>(context);
                }
                return classRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
