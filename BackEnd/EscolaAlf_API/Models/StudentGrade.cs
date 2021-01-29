using System.ComponentModel.DataAnnotations;

namespace EscolaAlf_API.Models
{
    public class StudentGrade
    {
        public StudentGrade(int id, int testId, int studentId, double grade)
        {
            this.Id = id;
            this.TestId = testId;
            this.StudentId = studentId;
            this.Grade = grade;
        }

        public int Id { get; set; }
        public int TestId { get; set; }
        public int StudentId { get; set; }
        [Range(0, 10, ErrorMessage = "Value for grade must be between 0 and 10.")]
        public double Grade { get; set; }
    }
}