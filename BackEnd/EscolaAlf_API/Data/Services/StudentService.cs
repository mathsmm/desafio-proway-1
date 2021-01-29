using System.Linq;
using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;
using EscolaAlf_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaAlf_API.Data.Services
{
    public class StudentService : IStudent
    {
        private readonly DataContext _context;
        public StudentService(DataContext context)
        {
            this._context = context;
        }

        public async Task<Student[]> GetAllAsync()
        {
            IQueryable<Student> query = _context.Student.AsNoTracking().OrderBy(s => s.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Student> GetByIdAsync(int studentId)
        {
            IQueryable<Student> query = _context.Student.AsNoTracking().Where(s => s.Id == studentId);
            return await query.FirstOrDefaultAsync();
        }

        public int ReturnNumberOfStudents()
        {
            IQueryable<Student> query = _context.Student.AsNoTracking();
            return query.Count();
        }
    }
}