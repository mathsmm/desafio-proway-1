using System;

namespace EscolaAlf_API.Models
{
    public class Test
    {
        public Test(int id, DateTime date)
        {
            this.Id = id;
            this.Date = date;
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}