using System.Threading.Tasks;
using EscolaAlf_API.Data.Interfaces;

namespace EscolaAlf_API.Data.Services
{
    public class RepositoryService : IRepository
    {
        private readonly DataContext _context;
        public RepositoryService(DataContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this._context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this._context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this._context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}