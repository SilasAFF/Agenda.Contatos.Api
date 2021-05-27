using Agenda.Contatos.Business.Models;
using System;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Interfaces
{
    public interface ICalendarioService : IDisposable
    {
        Task<bool> Adicionar(Calendario Calendario);
        Task<bool> Atualizar(Calendario Calendario);
        Task<bool> Remover(Guid id);
    }
}
