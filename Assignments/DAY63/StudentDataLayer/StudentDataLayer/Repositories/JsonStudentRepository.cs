using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentDataLayer.Repositories
{
    public class JsonStudentRepository : IStudentRepository {
        private readonly string _filePath = @"../../../students.json";
        private readonly List<Student> _students = new List<Student>();
        

        public JsonStudentRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var loaded = JsonSerializer.Deserialize<List<Student>>(json);
                if (loaded != null)
                {
                    _students.AddRange(loaded);
                   
                }
            }
        }

        private void SaveData()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_students, options);
            File.WriteAllText(_filePath, json);
        }

        public IEnumerable<Student> GetAll() => _students;
        public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public void Add(Student student)
        {
           

            _students.Add(student);
            SaveData();
        }

        public void Update(Student student)
        {
            var existing = GetById(student.Id);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
                SaveData();
            }
        }

        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _students.Remove(student);
                SaveData();
            }
        }


    }

    
    
}
