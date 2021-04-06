using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using Agenda.Contatos.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Agenda.Contatos.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AgendaDbContext context) : base(context)
        {

        }

        public async Task<Endereco> ObterEnderecoPorContato(Guid contatoId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.ContatoId == contatoId);
        }
    }
}
