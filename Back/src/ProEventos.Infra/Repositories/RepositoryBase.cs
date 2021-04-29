using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Infra.Interfaces;

namespace ProEventos.Infra.Repositories
{
    public class RepositoryBase : IRepositoryBase
    {
        private readonly ProEventosContext _context;
        public RepositoryBase(ProEventosContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entities) where T : class
        {
           _context.RemoveRange(entities);
        }
        public async Task<bool> SaveChangesAsync()
        {   
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}