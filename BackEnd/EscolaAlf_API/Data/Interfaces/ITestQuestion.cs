using System.Collections.Generic;

namespace EscolaAlf_API.Data.Interfaces
{
    public interface ITestQuestion
    {
        List<int> ReturnWeights(int testId);
    }
}