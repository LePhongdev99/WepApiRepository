using Microsoft.EntityFrameworkCore;
using WepApiRepository.Model;

namespace WepApiRepository.Repositories
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private readonly AdventureContext context;
        private readonly IClassRepository classRepository;

        public StudentRepository(AdventureContext context, IClassRepository classRepository)
        {
            this.context = context;
            this.classRepository = classRepository;
        }

        public Student GetStudentHasMaxId()
        {
            Student student = context.Students.OrderByDescending(p=>p.Id).FirstOrDefault();
            return student;
        }

        public void DeleteStudent(int studentID)
        {
            Student student = context.Students.Find(studentID);
            context.Students.Remove(student);
        }

        public Student GetStudentByID(int studentId)
        {
            return context.Students.Include(p => p.Class).ThenInclude(p=>p.Students).FirstOrDefault(p=>p.Id == studentId);
        }

        public List<Student> GetStudents()
        {
            //return context.Students.Include(p=>p.Class).ThenInclude(p=>p.Students).ToList();
            return context.Students.ToList();
        }

        public void InsertStudent(int id, string name, int classId, string Address)
        {
            var student = new Student();
            student.Id = id;                
            student.Name = name;
            student.ClassId = classId;
            student.Address = Address;
            
            context.Students.Add(student);
            
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateStudent(int id, string name, int classId, string Address)
        {
            Student student = context.Students.Find(id);
            if (student != null) { 
                student.Name=name;
                student.ClassId=classId;
                student.Address=Address;
            }
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
