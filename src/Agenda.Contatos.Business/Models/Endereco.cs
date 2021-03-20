using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Contatos.Business.Models
{
    public class Endereco : EntidadeBase
    {
        public Guid ContatoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Contato Contato { get; set; }
    }
}
