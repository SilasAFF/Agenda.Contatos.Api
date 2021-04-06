using Agenda.Contatos.Business.Models;
using System;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorContato(Guid contatoId);
    }
}
