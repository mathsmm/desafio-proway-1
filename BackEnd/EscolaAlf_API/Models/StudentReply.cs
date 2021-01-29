namespace EscolaAlf_API.Models
{
    public class StudentReply
    {
        public StudentReply(int id, int studentId, int testQuestionId, int optionId)
        {
            this.Id = id;
            this.StudentId = studentId;
            this.TestQuestionId = testQuestionId;
            this.OptionId = optionId;
        }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TestQuestionId { get; set; }
        public TestQuestion TestQuestion { get; set; }
        public int OptionId { get; set; }
    }
}