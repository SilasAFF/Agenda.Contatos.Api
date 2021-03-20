using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using Agenda.Contatos.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Services
{
    public class ContatoService : BaseService, IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IEnderecoRepository _enderecoRepository;


        public ContatoService(IContatoRepository contatoRepository, IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _contatoRepository = contatoRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(Contato contato)
        {
            if (!ExecutarValidacao(new ContatoValidation(), contato)
                /*|| !ExecutarValidacao(new EnderecoValidation(), contato.Endereco)*/) return false;

            if (_contatoRepository.Buscar(f => f.Numero == contato.Numero).Result.Any())
            {
                Notificar("Já existe um contato com este numero informado.");
                return false;
            }

            await _contatoRepository.Adicionar(contato);
            return true;
        }

        public async Task<bool> Atualizar(Contato contato)
        {
            if (!ExecutarValidacao(new ContatoValidation(), contato)) return false;

            if (_contatoRepository.Buscar(f => f.Numero == contato.Numero && f.Id != contato.Id).Result.Any())
            {
                Notificar("Já existe um contato com este numero informado.");
                return false;
            }

            await _contatoRepository.Atualizar(contato);
            return true;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool> Remover(Guid id)
        {


            var endereco = await _enderecoRepository.ObterEnderecoPorContato(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _contatoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _contatoRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }

        
    }
}
