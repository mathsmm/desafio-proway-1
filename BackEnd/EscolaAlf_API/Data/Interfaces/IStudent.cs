using System.Threading.Tasks;
using EscolaAlf_API.Models;

namespace EscolaAlf_API.Data.Interfaces
{
    public interface IStudent
    {
        Task<Student[]> GetAllAsync();
        Task<Student> GetByIdAsync(int studentId);
        int ReturnNumberOfStudents();
    }
}