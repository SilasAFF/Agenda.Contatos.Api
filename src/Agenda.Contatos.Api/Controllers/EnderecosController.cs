using Agenda.Contatos.Api.Controllers;
using Agenda.Contatos.Api.ViewModels;
using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda.Contatos.Api.Controllers
{
    [Route("api/enderecos")]
    public class EnderecosController : MainController
    {
        private readonly IEnderecoRepository _EnderecoRepository;
        private readonly IEnderecoService _Enderecoservice;
        private readonly IMapper _mapper;

        public EnderecosController(IEnderecoRepository EnderecoRepository, IMapper mapper, IEnderecoService Enderecoservice, INotificador notificador) : base(notificador)
        {
            _EnderecoRepository = EnderecoRepository;
            _Enderecoservice = Enderecoservice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EnderecoViewModel>> ObterTodos()
        {
            //var Endereco = _mapper.Map<IEnumerable<EnderecoViewModel>>(await _EnderecoRepository.ObterTodos());
            var Endereco = _mapper.Map<IEnumerable<EnderecoViewModel>>(await _EnderecoRepository.ObterTodos());  
            return Endereco;
        }

        [HttpGet("{contatoId:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> ObterPorId(Guid contatoId)
        {
            var enderecoViewModel = _mapper.Map<EnderecoViewModel>(await _EnderecoRepository.ObterEnderecoPorContato(contatoId));

            //if (enderecoViewModel == null) return NotFound();

            return CustomResponse(enderecoViewModel);
        }

        [HttpPost("{contatoId:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> Adicionar(EnderecoViewModel EnderecoViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _Enderecoservice.Adicionar(_mapper.Map<Endereco>(EnderecoViewModel));

            return CustomResponse(EnderecoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> Atualizar(Guid id, EnderecoViewModel EnderecoViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != EnderecoViewModel.Id) return BadRequest();

            await _Enderecoservice.Atualizar(_mapper.Map<Endereco>(EnderecoViewModel));

            return CustomResponse(EnderecoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> Excluir(Guid id)
        {
            var Endereco = _mapper.Map<EnderecoViewModel>(await _EnderecoRepository.ObterPorId(id));

            if (Endereco == null) return NotFound();

            var result = await _Enderecoservice.Remover(id);

            if (!result) return BadRequest();

            return CustomResponse(id);
        }
    }
}
