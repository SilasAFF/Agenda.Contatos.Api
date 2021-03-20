using Agenda.Contatos.Api.ViewModels;
using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Api.Controllers
{
    [Route("api/contatos")]
    public class ContatosController : MainController
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        public ContatosController(IContatoRepository contatoRepository, IMapper mapper, IContatoService contatoService, INotificador notificador) : base(notificador)
        {
            _contatoRepository = contatoRepository;
            _contatoService = contatoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodos()
        {
            var contato = _mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoRepository.ObterTodos());
            return contato;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> ObterPorId(Guid id)
        {
            var contato = _mapper.Map<ContatoViewModel>(await _contatoRepository.ObterPorId(id));

            if (contato == null) return NotFound();

            return contato;
        }

        //[Route("api/clientes/adicionar")]
        [HttpPost]
        public async Task<ActionResult<ContatoViewModel>> Adicionar(ContatoViewModel contatoViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            //var cliente = _mapper.Map<Cliente>(ClienteViewModel);
            //var result = await _clienteService.Adicionar(cliente);
            //
            //if (!result) return BadRequest();
            //
            //return Ok(cliente);
            await _contatoService.Adicionar(_mapper.Map<Contato>(contatoViewModel));

            return CustomResponse(contatoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> Atualizar(Guid id, ContatoViewModel contatoViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (id != contatoViewModel.Id) return BadRequest();
            /*
            if (id != ClienteViewModel.Id) return BadRequest();
            var cliente = _mapper.Map<Cliente>(ClienteViewModel);
            var result = await _clienteService.Atualizar(cliente);
            if (!result) return BadRequest();
            return Ok(cliente);
            */
            await _contatoService.Atualizar(_mapper.Map<Contato>(contatoViewModel));
            return CustomResponse(contatoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> Excluir(Guid id)
        {
            var contato = _mapper.Map<ContatoViewModel>(await _contatoRepository.ObterPorId(id));

            if (contato == null) return NotFound();

            var result = await _contatoService.Remover(id);

            if (!result) return BadRequest();

            return Ok();
        }
    }
}
