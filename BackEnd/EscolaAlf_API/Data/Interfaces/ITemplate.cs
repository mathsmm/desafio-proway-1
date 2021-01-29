using System.Collections.Generic;
using System.Threading.Tasks;
using EscolaAlf_API.Models;

namespace EscolaAlf_API.Data.Interfaces
{
    public interface ITemplate
    {
        Task<Template[]> GetAllAsync(bool includeTestQuestion);
        Task<Template> GetByIdAsync(int templateId, bool includeTestQuestion);
        List<int> ReturnTemplateOptionsId(int testId);
    }
}