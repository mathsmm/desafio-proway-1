using System.ComponentModel.DataAnnotations;

namespace EscolaAlf_API.Models
{
    public class TestQuestion
    {
        public TestQuestion(int id, int testId, int questionId, int questionNumber, int weight)
        {
            this.Id = id;
            this.TestId = testId;
            this.QuestionId = questionId;
            this.QuestionNumber = questionNumber;
            this.Weight = weight;
        }
        public int Id { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionNumber { get; set; }

        [Range(1, 1000, ErrorMessage = "Value for weight must be between 1 and 1000.")]
        public int Weight { get; set; }
    }
}