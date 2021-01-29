namespace EscolaAlf_API.Models
{
    public class Template
    {
        public Template(int id, int testQuestionId, int optionId)
        {
            this.Id = id;
            this.TestQuestionId = testQuestionId;
            this.OptionId = optionId;
        }
        public int Id { get; set; }
        public int TestQuestionId { get; set; }
        public TestQuestion TestQuestion { get; set; }
        public int OptionId { get; set; }
    }
}