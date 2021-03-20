using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Contatos.Business.Models
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = new Guid();
        }
    }
}
