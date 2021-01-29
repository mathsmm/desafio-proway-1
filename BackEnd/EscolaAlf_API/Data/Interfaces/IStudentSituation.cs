using System.Collections.Generic;
using System.Threading.Tasks;
using EscolaAlf_API.Models;

namespace EscolaAlf_API.Data.Interfaces
{
    public interface IStudentSituation
    {
        Task<StudentSituation[]> GetAllAsync();
        Task<StudentSituation> GetByIdAsync(int studentSituationId);
        Task<StudentSituation[]> GetByStudentIdAsync(int studentId);
        Task<StudentSituation[]> GetByApprovalAsync(bool approval);
        List<int> ReturnStudentIdListOfStudentsWithoutAverage();
        List<int> ReturnSituationIdListOfStudentsWithoutAverage();
    }
}