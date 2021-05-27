using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Services
{
    public class CalendarioService : BaseService, ICalendarioService
    {
        private readonly ICalendarioRepository _calendarioRepository;

        public CalendarioService(ICalendarioRepository calendarioRepository, INotificador notificador) : base(notificador)
        {
            _calendarioRepository = calendarioRepository;
        }


        public async Task<bool> Adicionar(Calendario Calendario)
        {
            await _calendarioRepository.Adicionar(Calendario);
            return true;
        }

        public async Task<bool> Atualizar(Calendario Calendario)
        {

            await _calendarioRepository.Atualizar(Calendario);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {

            await _calendarioRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _calendarioRepository?.Dispose();
        }
    }
}