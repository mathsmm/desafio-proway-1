using System.Collections.Generic;
using System.Linq;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaAlf_API.Data.Services
{
    public class TestQuestionService : ITestQuestion
    {
        private readonly DataContext _context;
        public TestQuestionService(DataContext context)
        {
            this._context = context;
        }

        public List<int> ReturnWeights(int testId)
        {
            IQueryable<TestQuestion> query = _context.TestQuestion.AsNoTracking().OrderBy(tq => tq.QuestionNumber).Where(tq => tq.TestId == testId);
            List<int> weightList = new List<int>();
            weightList = query.Select(tq => tq.Weight).ToList();
            return weightList;
        }
    }
}