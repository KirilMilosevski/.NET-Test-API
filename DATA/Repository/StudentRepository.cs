using DATA.Entities;
using DATA.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _dataContext;

        public StudentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddStudent(Student newstudent)
        {
            _dataContext.Students.Add(newstudent);
            Save();
        }

        public bool DeleteStudent(Student student)
        {
            try
            {
                _dataContext.Students.Remove(student);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Student GetStudentById(int id)
        {
            return _dataContext.Students.Include(s => s.Address).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _dataContext.Students.Include(s => s.Address);
        }

        public void UpdateStudent(Student oldStuden, Student newStudents)
        {
            _dataContext.Entry(oldStuden).CurrentValues.SetValues(newStudents);
            Save();
        }

        public void Save()
        {
            _dataContext.SaveChangesAsync();
        }
    }
}
