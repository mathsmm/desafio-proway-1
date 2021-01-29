using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaAlf_API.Data.Services
{
    public class StudentReplyService : IStudentReply
    {
        private readonly DataContext _context;
        public StudentReplyService(DataContext context)
        {
            this._context = context;
        }

        public async Task<StudentReply[]> GetAllAsync()
        {
            IQueryable<StudentReply> query = _context.StudentReply.AsNoTracking().OrderBy(sr => sr.Id);
            return await query.ToArrayAsync();
        }

        public async Task<StudentReply> GetByIdAsync(int studentReplyId, bool includeTestQuestion)
        {
            IQueryable<StudentReply> query = _context.StudentReply.AsNoTracking().Where(sr => sr.Id == studentReplyId);
            if (includeTestQuestion)
            {
                query = query.Include(sr => sr.TestQuestion);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<StudentReply[]> GetByStudentIdAsync(int studentId)
        {
            IQueryable<StudentReply> query = _context.StudentReply.AsNoTracking().OrderBy(sr => sr.Id).Where(sr => sr.StudentId == studentId);
            return await query.ToArrayAsync();
        }

        public async Task<StudentReply[]> GetByTestId(int testId)
        {
            IQueryable<StudentReply> query = _context.StudentReply.AsNoTracking().OrderBy(sr => sr.StudentId).Where(sr => sr.TestQuestion.TestId == testId);
            return await query.ToArrayAsync();
        }

        public List<int> ReturnStudentReplyOptionsId(int testId, int studentId)
        {
            IQueryable<StudentReply> query = _context.StudentReply.AsNoTracking().OrderBy(sr => sr.TestQuestionId).Where(sr => sr.StudentId == studentId && sr.TestQuestion.TestId == testId);
            List<int> optionsList = new List<int>();
            optionsList = query.Select(sr => sr.OptionId).ToList();
            return optionsList;
        }

        public List<int> ReturnStudentIdList(int testId)
        {
            IQueryable<StudentReply> query = _context.StudentReply.AsNoTracking().OrderBy(sr => sr.StudentId).Where(sr => sr.TestQuestion.TestId == testId);
            List<int> studentIdList = new List<int>();
            studentIdList = query.Select(sr => sr.StudentId).ToList();
            return studentIdList;
        }
    }
}