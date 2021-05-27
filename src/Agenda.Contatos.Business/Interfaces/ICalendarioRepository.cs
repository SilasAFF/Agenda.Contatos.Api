using Agenda.Contatos.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Interfaces
{
    public interface ICalendarioRepository : IRepository<Calendario>
    {
        Task<List<Calendario>> ObterCalendarioPorUser(string userId);
    }

}
