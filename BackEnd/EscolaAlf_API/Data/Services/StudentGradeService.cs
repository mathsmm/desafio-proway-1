using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaAlf_API.Data.Services
{
    public class StudentGradeService : IStudentGrade
    {
        private readonly DataContext _context;
        public StudentGradeService(DataContext context)
        {
            this._context = context;
        }

        public async Task<StudentGrade[]> GetAllAsync()
        {
            IQueryable<StudentGrade> query = _context.StudentGrade.AsNoTracking().OrderBy(sg => sg.Id);
            return await query.ToArrayAsync();
        }

        public async Task<StudentGrade> GetByIdAsync(int studentGradeId)
        {
            IQueryable<StudentGrade> query = _context.StudentGrade.AsNoTracking().OrderBy(sg => sg.Id).Where(sg => sg.Id == studentGradeId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<StudentGrade[]> GetByStudentIdAsync(int studentId)
        {
            IQueryable<StudentGrade> query = _context.StudentGrade.AsNoTracking().OrderBy(sg => sg.Id).Where(sg => sg.StudentId == studentId);
            return await query.ToArrayAsync();
        }

        public List<double> ReturnGradesOfAStudent(int studentId)
        {
            IQueryable<StudentGrade> query = _context.StudentGrade.AsNoTracking().OrderBy(sg => sg.Id).Where(sg => sg.StudentId == studentId);
            return query.Select(st => st.Grade).ToList();
        }
    }
}