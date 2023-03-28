using AutoMapper;
using DATA.Entities;
using DATA.Interfaces;
using Models.DTOs;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            //1. Entities
            //return await _dataContext.Students.ToListAsync();

            //2. DTOs
            //return _dataContext.Students.Select(x => new StudentDTO
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    DOB = x.DOB,
            //    EnrollmentDate = x.EnrollmentDate,
            //    StudentIndex = x.StudentIndex,
            //    GPA = x.GPA,
            //    Mail = x.Mail,
            //    AddressId = x.AddressId,
            //    Address = new AddressDTO
            //    {
            //        Id = x.Address.Id,
            //        Street = x.Address.Street,
            //        City = x.Address.City,
            //        Country = x.Address.Country
            //    }
            //}).ToList();

            //3. AutoMapper DTOs
            var students = _studentRepository.GetStudents();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public StudentDTO GetStudentById(int id)
        {
            //Would cause circular dependency error, so we need DTOs
            //return await _dataContext.Students.Include(s => s.Address).FirstOrDefaultAsync(x => x.Id == id);

            var student = _studentRepository.GetStudentById(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public StudentDTO AddStudent(StudentDTO student)
        {
            Student newStudent = _mapper.Map<Student>(student);

            if (_studentRepository.GetStudentById(student.Id) == null)
            {
                _studentRepository.AddStudent(newStudent);
            }
            return _mapper.Map<StudentDTO>(newStudent);
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            Student newStudent = _mapper.Map<Student>(student);
            Student oldStudent = _studentRepository.GetStudentById(newStudent.Id);

            if (oldStudent != null)
            {
                _studentRepository.UpdateStudent(oldStudent, newStudent);
            }
            return _mapper.Map<StudentDTO>(newStudent);
        }

        public bool DeleteStudent(int id)
        {
            var studentEntity = _studentRepository.GetStudentById(id);

            /* If we want to delete the address associated with the current student (in 1-to-1 relations) we should:
            //1. First retrieve the address associated with the current student addressId
            var addressEntity = await _dataContext.Addresses.FindAsync(studentEntity.AddressId);
            
            //2. Then delete all students associated with the current addressId
            var studentsWithAddress = await _dataContext.Students.Where(s => s.Id == studentEntity.Address.Id).ToListAsync();
            foreach(var student in studentsWithAddress)
            {
                _dataContext.Students.Remove(student);
            }

            //2. Then delete the address associated with those students
            _dataContext.Addresses.Remove(addressEntity);
            */

            //If we want to remove only the student without the associated address (for 1-to-m relations) as in our case 1 address - many students, we should remove the student only

            return _studentRepository.DeleteStudent(studentEntity);
        }
    }
}
