using Agenda.Contatos.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<List<Contato>> ObterContatosOrdenados(string userId);
    }

    
}
