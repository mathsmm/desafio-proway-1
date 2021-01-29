using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaAlf_API.Data.Services
{
    public class StudentSituationService : IStudentSituation
    {
        private readonly DataContext _context;
        public StudentSituationService(DataContext context)
        {
            this._context = context;
        }

        public async Task<StudentSituation[]> GetAllAsync()
        {
            IQueryable<StudentSituation> query = _context.StudentSituation.AsNoTracking().OrderBy(ss => ss.Id);
            return await query.ToArrayAsync();
        }

        public async Task<StudentSituation> GetByIdAsync(int studentSituationId)
        {
            IQueryable<StudentSituation> query = _context.StudentSituation.AsNoTracking().OrderBy(ss => ss.Id).Where(ss => ss.Id == studentSituationId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<StudentSituation[]> GetByStudentIdAsync(int studentId)
        {
            IQueryable<StudentSituation> query = _context.StudentSituation.AsNoTracking().OrderBy(ss => ss.Id).Where(ss => ss.StudentId == studentId);
            return await query.ToArrayAsync();
        }

        public async Task<StudentSituation[]> GetByApprovalAsync(bool approval)
        {
            IQueryable<StudentSituation> query = _context.StudentSituation.AsNoTracking().OrderBy(ss => ss.Id).Where(ss => ss.Approval == approval);
            return await query.ToArrayAsync();
        }

        public List<int> ReturnStudentIdListOfStudentsWithoutAverage()
        {
            IQueryable<StudentSituation> query = _context.StudentSituation.AsNoTracking().OrderBy(ss => ss.Id).Where(ss => ss.Average == 0);
            return query.Select(ss => ss.StudentId).ToList();
        }

        public List<int> ReturnSituationIdListOfStudentsWithoutAverage()
        {
            IQueryable<StudentSituation> query = _context.StudentSituation.AsNoTracking().OrderBy(ss => ss.Id).Where(ss => ss.Average == 0);
            return query.Select(ss => ss.Id).ToList();
        }
    }
}