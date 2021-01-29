using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaAlf_API.Data.Services
{
    public class TemplateService : ITemplate
    {
        private readonly DataContext _context;
        public TemplateService(DataContext context)
        {
            this._context = context;
        }

        public async Task<Template[]> GetAllAsync(bool includeTestQuestion)
        {
            IQueryable<Template> query = _context.Template.AsNoTracking().OrderBy(t => t.Id);
            if (includeTestQuestion)
            {
                query = query.Include(t => t.TestQuestion);
            }
            return await query.ToArrayAsync();
        }

        public async Task<Template> GetByIdAsync(int templateId, bool includeTestQuestion)
        {
            IQueryable<Template> query = _context.Template.AsNoTracking().OrderBy(t => t.Id).Where(t => t.Id == templateId);
            if (includeTestQuestion)
            {
                query = query.Include(t => t.TestQuestion);
            }
            return await query.FirstOrDefaultAsync();
        }

        public List<int> ReturnTemplateOptionsId(int testId)
        {
            IQueryable<Template> query = _context.Template.AsNoTracking().OrderBy(t => t.TestQuestionId).Where(t => t.TestQuestion.TestId == testId);
            List<int> optionsList = new List<int>();
            optionsList = query.Select(t => t.OptionId).ToList();
            return optionsList;
        }
    }
}