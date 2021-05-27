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

    public class CalendarioRepository : Repository<Calendario>, ICalendarioRepository
    {
        public CalendarioRepository(AgendaDbContext context) : base(context)
        {

        }

        public async Task<List<Calendario>> ObterCalendarioPorUser(string userId)
        {
            //return await Db.Calendario.Where(b => b.UserId == userId).AsNoTracking().ToListAsync();

            /*
            var result = from calendario in Db.Calendario
                         join contatos in Db.Contatos on calendario.ContatoId equals contatos.Id into Contatos

                         from m in Contatos.DefaultIfEmpty().Where(b => b.UserId == userId)
                         select new
                         {
                             id = calendario.Id,
                             nomeEvento = calendario.NomeEvento,
                             descricaoEvento = calendario.DescricaoEvento,
                             inicioEvento = calendario.InicioEvento,
                             fimEvento = calendario.FimEvento,
                             contatoId = calendario.ContatoId,
                             userId = calendario.UserId,
                             nomeContato = m.Nome
                         };
            */

            return await Db.Calendario.AsNoTracking()
                                      .Where(b => b.UserId == userId)
                                      .Include(c => c.Contato)
                                      .ToListAsync();

        }
    }
}
