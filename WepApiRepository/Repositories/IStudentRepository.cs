
using System;
using System.Collections.Generic;
using WepApiRepository.Model;

namespace WepApiRepository.Repositories
{
    public interface IStudentRepository : IDisposable
    {
        List<Student> GetStudents();
        Student GetStudentByID(int studentId);
        void InsertStudent(int id, string name, int classId, string Address);
        void DeleteStudent(int studentID);
        void UpdateStudent(int id, string name, int classId, string Address);
        void Save();

        Student GetStudentHasMaxId();
    }
}
