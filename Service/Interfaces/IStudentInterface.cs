using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetStudents();
        StudentDTO GetStudentById(int id);
        StudentDTO AddStudent(StudentDTO student);
        StudentDTO UpdateStudent(StudentDTO student);
        bool DeleteStudent(int id);
    }
}
