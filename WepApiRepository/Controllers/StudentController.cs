
using Microsoft.AspNetCore.Mvc;
using WepApiRepository.Model;
using WepApiRepository.Repositories;



namespace WepApiRepository.Controllers
{
    [ApiController]
    
    public class StudentController : ControllerBase
    {   
        
        private readonly IStudentRepository studentRepository;
        private readonly IClassRepository classRepository;
        public StudentController(IStudentRepository studentRepository, IClassRepository classRepository) 
        { 
            this.studentRepository = studentRepository;
            this.classRepository = classRepository;
            
        }
        [HttpGet]
        [Route("GetAllStudent")]

        public List<Student> GetStudents()
        {
            return this.studentRepository.GetStudents();

        }
        [HttpGet]
        [Route("GetStudentById")]
        
        public Student GetStudentById(int id)
        {
            var student = studentRepository.GetStudentByID(id);
            return student;
            
        }

        [HttpPost]
        [Route("InsertStudent")]

        public void InsertStudent(int id, string name, int classId, string address)
        {
            studentRepository.InsertStudent(id, name, classId, address);
            studentRepository.Save();
        }

        [HttpPut]
        [Route("UpdateStudent")]

        public void UpdateStudent(int id, string name, int classId, string Address)
        {
            studentRepository.UpdateStudent( id, name, classId, Address);
            studentRepository.Save();
        }

        [HttpDelete]
        [Route("deleteStudentById")]
        public void DeleteStudent(int id)
        {
            studentRepository.DeleteStudent(id);
            studentRepository.Save();
        }
    }
}
