using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Contatos.Business.Models
{
    public class Calendario: EntidadeBase
    {
        public string NomeEvento { get; set; }
        public string DescricaoEvento { get; set; }
        public DateTime InicioEvento { get; set; }
        public DateTime FimEvento { get; set; }
        public Guid ContatoId { get; set; }
        public string UserId { get; set; }
        public Contato Contato { get; set; }
    }
}
