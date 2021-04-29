using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Infra.Interfaces;

namespace ProEventos.Infra.Repositories
{
    public class PalestrantesRepository : IPalestrantesRepository
    {
        private readonly ProEventosContext _context;
        public PalestrantesRepository(ProEventosContext context)
        {
            _context = context;
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes.
                                                Include(ev => ev.RedesSociais);

            if(includeEventos) {
              query = query.Include(ev => ev.PalestrantesEventos).
                           ThenInclude(ev => ev.Evento);
            }                                    

            query = query.AsNoTracking().OrderBy(or => or.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestrantesByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes.
                                                Include(ev => ev.RedesSociais);

            if(includeEventos) {
              query = query.Include(ev => ev.PalestrantesEventos).
                            ThenInclude(ev => ev.Evento);
            }                                    

            query = query.AsNoTracking().OrderBy(or => or.Id).Where(x => x.Id == palestranteId)    ;

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes.
                                                Include(ev => ev.RedesSociais);

            if(includeEventos) {
              query = query.Include(ev => ev.PalestrantesEventos).
                            ThenInclude(ev => ev.Evento);
            }                                    

            query = query.AsNoTracking().OrderBy(or => or.Id).Where(x => x.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}