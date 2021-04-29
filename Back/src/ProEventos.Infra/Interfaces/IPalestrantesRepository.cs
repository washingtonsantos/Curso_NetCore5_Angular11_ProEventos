using System.Threading.Tasks;
using ProEventos.Domain.Entities;

namespace ProEventos.Infra.Interfaces
{
    public interface IPalestrantesRepository
    {
        //Palestrantess
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);   
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);   
        Task<Palestrante> GetAllPalestrantesByIdAsync(int palestranteId, bool includeEventos);   
    }
}