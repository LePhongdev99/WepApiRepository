using Microsoft.AspNetCore.Mvc;
using WepApiRepository.Model;
using WepApiRepository.Repositories;

namespace WepApiRepository.Controllers
{
    [ApiController]
    [Route("/")]
    public class ClassController : Controller
    {
        
        private readonly IClassRepository classRepository;
        private readonly IStudentRepository studentRepository;

        public ClassController(IClassRepository classRepository, IStudentRepository studentRepository)
        {
            this.classRepository = classRepository;
            this.studentRepository = studentRepository;
        }

        [HttpPost]
        [Route("InsertClass")]
        public void InsertClass(int id, string name)
        {
            classRepository.InsertClass(id, name);
            classRepository.Save();
        }

        [HttpGet]
        [Route("GetClassByID")]
        public Class GetClassById(int id)
        {
            return classRepository.GetClass(id);
        }

        [HttpDelete]
        [Route("DeleteClassById")]
        public void DeleteClassById(int id)
        {
            classRepository.DeleteClass(id);
            classRepository.Save();
        }

        [HttpGet]
        [Route("GetClasses")]
        public List<Class> GetClasses()
        {
            return classRepository.GetClasses();
            classRepository.Save();
        }

        [HttpPut]
        [Route("UpdateClass")]

        public void UpdateClass(int id, string name)
        {
            classRepository.UpdateClass(id, name);
            classRepository.Save();
        }
    }
}
