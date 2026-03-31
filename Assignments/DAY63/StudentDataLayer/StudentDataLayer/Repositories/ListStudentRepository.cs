using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentDataLayer.Repositories
{
    public class ListStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();
       

        public IEnumerable<Student> GetAll() => _students;
        public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public void Add(Student student)
        {
            if (student.Id == 0)
                

            _students.Add(student);
        }

        public void Update(Student student)
        {
            var existing = GetById(student.Id);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
            }
        }

        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
                _students.Remove(student);
        }


    }
    
}
