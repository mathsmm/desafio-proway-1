using System.Collections.Generic;
using System.Threading.Tasks;
using EscolaAlf_API.Models;

namespace EscolaAlf_API.Data.Interfaces
{
    public interface IStudentGrade
    {
        Task<StudentGrade[]> GetAllAsync();
        Task<StudentGrade> GetByIdAsync(int studentGradeId);
        Task<StudentGrade[]> GetByStudentIdAsync(int studentId);
        List<double> ReturnGradesOfAStudent (int studentId);
    }
}