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
    [Route("api/agenda")]
    public class CalendarioController : MainController
    {

        private readonly ICalendarioRepository _calendarioRepository;
        private readonly ICalendarioService _calendarioService;
        private readonly IMapper _mapper;

        public CalendarioController(ICalendarioRepository calendarioRepository,
                                    IMapper mapper,
                                    ICalendarioService calendarioService,
                                    INotificador notificador,
                                    IUser user) : base(notificador, user)
        {
            _calendarioRepository = calendarioRepository;
            _calendarioService = calendarioService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<CalendarioViewModel>> ObterTodos()
        {
            var calendario = _mapper.Map<IEnumerable<CalendarioViewModel>>(await _calendarioRepository.ObterTodos());
            return calendario;
        }

        [HttpGet("{usuarioId}")]
        public async Task<IEnumerable<CalendarioViewModel>> ObterTodosPorUser(string usuarioId)
        {
            var calendario = _mapper.Map<IEnumerable<CalendarioViewModel>>(await _calendarioRepository.ObterCalendarioPorUser(usuarioId));
            return calendario;
        }

        [HttpPost]
        public async Task<ActionResult<CalendarioViewModel>> Adicionar(CalendarioViewModel CalendarioViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _calendarioService.Adicionar(_mapper.Map<Calendario>(CalendarioViewModel));

            return CustomResponse(CalendarioViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CalendarioViewModel>> Atualizar(Guid id, CalendarioViewModel CalendarioViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != CalendarioViewModel.Id) return BadRequest();

            await _calendarioService.Atualizar(_mapper.Map<Calendario>(CalendarioViewModel));

            return CustomResponse(CalendarioViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CalendarioViewModel>> Excluir(Guid id)
        {
            var Calendario = _mapper.Map<CalendarioViewModel>(await _calendarioRepository.ObterPorId(id));

            if (Calendario == null) return NotFound();

            var result = await _calendarioService.Remover(id);

            if (!result) return BadRequest();

            return CustomResponse(id);
        }

    }
}