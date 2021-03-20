using Agenda.Contatos.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Interfaces
{
    public interface IContatoService : IDisposable
    {
        Task<bool> Adicionar(Contato contato);
        Task<bool> Atualizar(Contato contato);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}
