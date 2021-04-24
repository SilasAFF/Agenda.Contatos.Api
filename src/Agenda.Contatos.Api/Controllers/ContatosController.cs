using Agenda.Contatos.Api.Extensions;
using Agenda.Contatos.Api.ViewModels;
using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Api.Controllers
{
    [Authorize]
    [Route("api/contatos")]
    public class ContatosController : MainController
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        private readonly UserManager<IdentityUser> _userManager;
     
        public ContatosController(IContatoRepository contatoRepository, 
                                  IMapper mapper, 
                                  IContatoService contatoService, 
                                  INotificador notificador,
                                  IUser user,
                                  UserManager<IdentityUser> userManager) : base(notificador, user)
        {
            _contatoRepository = contatoRepository;
            _contatoService = contatoService;
            _mapper = mapper;

            _userManager = userManager;

        

        }

        /*
        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodos()
        {
            var contato = _mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoRepository.ObterTodos()); 
            return contato;
        }*/

        [HttpGet("{usuarioId}")]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodos(string usuarioId)
        {
            var contato = _mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoRepository.ObterContatosOrdenados(usuarioId));
            return contato;
        }

        [HttpGet("{usuarioid}/{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> ObterPorId(Guid id)
        {

            var contato = _mapper.Map<ContatoViewModel>(await _contatoRepository.ObterPorId(id));

            if (contato == null) return NotFound();

            return contato;
        }

        [HttpPost("{usuarioid}")]
        public async Task<ActionResult<ContatoViewModel>> Adicionar(string usuarioId , ContatoViewModel contatoViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            contatoViewModel.UserId = usuarioId;

            await _contatoService.Adicionar(_mapper.Map<Contato>(contatoViewModel));

            return CustomResponse(contatoViewModel);
        }

        [HttpPut("{usuarioid}/{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> Atualizar(string usuarioId, Guid id, ContatoViewModel contatoViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != contatoViewModel.Id) return BadRequest();

            contatoViewModel.UserId = usuarioId;

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
