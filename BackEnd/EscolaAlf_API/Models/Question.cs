namespace EscolaAlf_API.Models
{
    public class Question
    {
        public Question(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}