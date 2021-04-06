using Agenda.Contatos.Business.Models;
using System;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Interfaces
{
    public interface IEnderecoService : IDisposable
    {
        Task<bool> Adicionar(Endereco Endereco);
        Task<bool> Atualizar(Endereco Endereco);
        Task<bool> Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}
