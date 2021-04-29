using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Infra.Interfaces;

namespace ProEventos.Infra.Repositories
{
    public class EventosRepository : IEventosRepository
    {
        private readonly ProEventosContext _context;
        public EventosRepository(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.
                                                Include(ev => ev.Lotes).
                                                Include(ev => ev.RedesSociais);

            if(includePalestrante) {
              query = query.Include(ev => ev.PalestrantesEventos).
                            ThenInclude(ev => ev.Palestrante);
            }                                    

            query = query.AsNoTracking().OrderBy(or => or.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventosByIdAsync(int eventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.
                                                Include(ev => ev.Lotes).
                                                Include(ev => ev.RedesSociais);

            if(includePalestrante) {
              query = query.Include(ev => ev.PalestrantesEventos).
                            ThenInclude(ev => ev.Palestrante);
            }                                    

            query = query.AsNoTracking().OrderBy(or => or.Id).Where(x => x.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
             IQueryable<Evento> query = _context.Eventos.
                                                Include(ev => ev.Lotes).
                                                Include(ev => ev.RedesSociais);

            if(includePalestrante) {
              query = query.Include(ev => ev.PalestrantesEventos).
                            ThenInclude(ev => ev.Palestrante);
            }                                    

            query = query.AsNoTracking().OrderBy(or => or.Id).Where(x => x.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

    }
}