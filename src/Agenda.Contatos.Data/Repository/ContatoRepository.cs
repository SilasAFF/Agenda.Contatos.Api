using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using Agenda.Contatos.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Contatos.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(AgendaDbContext context) : base(context)
        {

        }
    }
}
