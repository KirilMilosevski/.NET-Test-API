using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student oldStuden, Student students);
        bool DeleteStudent(Student student);

    }
}
