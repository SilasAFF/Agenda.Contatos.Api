using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Contatos.Api.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "Insira um {0} válido", MinimumLength = 10)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Insira um {0} válido")]
        public string Email { get; set; }

        public bool Favorito { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public string UserId { get; set; }

    }
}
