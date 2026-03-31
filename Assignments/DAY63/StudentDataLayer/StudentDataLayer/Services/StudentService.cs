using StudentDataLayer.Models;
using StudentDataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataLayer.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void AddStudent(Student student)
        {
            Validate(student);
            _repository.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            Validate(student);
            _repository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Student> GetAllStudents() => _repository.GetAll();
        public Student? GetStudentById(int id) => _repository.GetById(id);

        private static void Validate(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
                throw new ArgumentException("Name cannot be empty.");

            if (student.Grade < 0 || student.Grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");
        }
    }
}
