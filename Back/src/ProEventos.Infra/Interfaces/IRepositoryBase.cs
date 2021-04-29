using System.Threading.Tasks;

namespace ProEventos.Infra.Interfaces
{
    public interface IRepositoryBase
    {
        void Add<T>(T entitty) where T : class;
        void Update<T>(T entitty) where T : class;
        void Delete<T>(T entitty) where T : class;
        void DeleteRange<T>(T[] entitty) where T : class;

        Task<bool> SaveChangesAsync();

    }
}