using System;
using System.Threading.Tasks;
using ProEventos.Application.Interfaces;
using ProEventos.Domain.Entities;
using ProEventos.Infra.Interfaces;

namespace ProEventos.Application.Services
{
    public class EventoService : IEventoService
    {
        private readonly IRepositoryBase _repositoryBase;
        private readonly IEventosRepository _eventosRepository;
        public EventoService(IRepositoryBase repositoryBase, IEventosRepository eventosRepository)
        {
            _eventosRepository = eventosRepository;
            _repositoryBase = repositoryBase;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _repositoryBase.Add(model);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return await _eventosRepository.GetAllEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventosRepository.GetAllEventosByIdAsync(eventoId, false);

                if (evento == null) return null;

                model.Id = evento.Id;

                _repositoryBase.Update(model);

                if (await _repositoryBase.SaveChangesAsync())
                {
                    return await _eventosRepository.GetAllEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventosRepository.GetAllEventosByIdAsync(eventoId, false);

                if (evento == null) throw new Exception("Evento não encontrado!");

                _repositoryBase.Delete<Evento>(evento);

                return await _repositoryBase.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante)
        {
            try
            {
                return await _eventosRepository.GetAllEventosAsync(includePalestrante);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventosByIdAsync(int eventoId, bool includePalestrante)
        {
            try
            {
                return await _eventosRepository.GetAllEventosByIdAsync(eventoId, includePalestrante);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante)
        {
            try
            {
                return await _eventosRepository.GetAllEventosByTemaAsync(tema, includePalestrante);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}