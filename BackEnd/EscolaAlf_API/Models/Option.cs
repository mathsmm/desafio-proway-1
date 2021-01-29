namespace EscolaAlf_API.Models
{
    public class Option
    {
        public Option(int id, int optionNumber, int questionId, string description)
        {
            this.Id = id;
            this.OptionNumber = optionNumber;
            this.QuestionId = questionId;
            this.Description = description;
        }
        public int Id { get; set; }
        public int OptionNumber { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; }
    }
}