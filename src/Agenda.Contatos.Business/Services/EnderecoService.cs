using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {
        private readonly IEnderecoRepository _EnderecoRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository EnderecoRepository, IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _EnderecoRepository = EnderecoRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(Endereco Endereco)
        {

            await _EnderecoRepository.Adicionar(Endereco);
            return true;
        }

        public async Task<bool> Atualizar(Endereco Endereco)
        {
            //if (!ExecutarValidacao(new EnderecoValidation(), Endereco)) return false;

            //if (_EnderecoRepository.Buscar(f => f.Numero == Endereco.Numero && f.Id != Endereco.Id).Result.Any())
            //{
            //    Notificar("Já existe um Endereco com este Número informado.");
            //    return false;
            //}

            await _EnderecoRepository.Atualizar(Endereco);
            return true;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            //if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> Remover(Guid id)
        {


            var endereco = await _enderecoRepository.ObterEnderecoPorContato(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _EnderecoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _EnderecoRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }

        
    }
}
