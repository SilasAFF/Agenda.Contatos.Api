using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Contatos.Business.Models
{
    public class Contato : EntidadeBase
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }
        public bool Favorito { get; set; }
        public Endereco Endereco { get; set; }
        public string UserId { get; set; }
        public bool PendenciaFinanceira { get; set; }


    }
}
