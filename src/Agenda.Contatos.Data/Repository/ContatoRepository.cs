using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using Agenda.Contatos.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Contatos.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(AgendaDbContext context) : base(context)
        {
           
        }

        public async Task<List<Contato>> ObterContatosOrdenados()
        {
            return await Db.Contatos.OrderBy(x => x.Favorito == false).ThenBy(y => y.Nome).AsNoTracking().ToListAsync();
        }
    }
}
