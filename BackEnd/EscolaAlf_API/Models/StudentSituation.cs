using System.ComponentModel.DataAnnotations;

namespace EscolaAlf_API.Models
{
    public class StudentSituation
    {
        public StudentSituation(int id, int studentId, double average, bool approval)
        {
            this.Id = id;
            this.StudentId = studentId;
            this.Average = average;
            this.Approval = approval;
        }
        public int Id { get; set; }
        public int StudentId { get; set; }
        [Range(0, 10, ErrorMessage = "Value for average must be between 0 and 10.")]
        public double Average { get; set; }
        public bool Approval { get; set; }
    }
}