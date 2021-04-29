using System.Threading.Tasks;
using ProEventos.Domain.Entities;

namespace ProEventos.Infra.Interfaces
{
    public interface IEventosRepository
    {        
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrante);
        Task<Evento> GetAllEventosByIdAsync(int eventoId, bool includePalestrante);
    }
}