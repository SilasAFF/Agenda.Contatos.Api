using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Contatos.Api.ViewModels
{
    public class CalendarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string NomeEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string DescricaoEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime inicioEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime FimEvento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ContatoId { get; set; }

        public string UserId { get; set; }

        public ContatoViewModel Contato { get; set; }
    }
}
