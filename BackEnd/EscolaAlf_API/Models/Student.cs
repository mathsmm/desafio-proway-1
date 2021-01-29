using System;

namespace EscolaAlf_API.Models
{
    public class Student
    {
        
        public Student(int id, string name, DateTime birthdate)
        {
            this.Id = id;
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}