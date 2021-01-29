using System.Collections.Generic;
using System.Threading.Tasks;
using EscolaAlf_API.Models;

namespace EscolaAlf_API.Data.Interfaces
{
    public interface IStudentReply
    {
        Task<StudentReply[]> GetAllAsync();
        Task<StudentReply> GetByIdAsync(int studentReplyId, bool includeTestQuestion);
        Task<StudentReply[]> GetByStudentIdAsync(int studentId);
        Task<StudentReply[]> GetByTestId(int testId);
        List<int> ReturnStudentReplyOptionsId(int testId, int studentId);
        List<int> ReturnStudentIdList(int testId);
    }
}