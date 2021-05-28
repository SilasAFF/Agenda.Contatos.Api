using Agenda.Contatos.Api.ViewModels;
using Agenda.Contatos.Business.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Api.Controllers
{
    [Route("api/pendencia-financeira")]
    public class PendenciaFinanceiraController : MainController
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        private readonly UserManager<IdentityUser> _userManager;

        public PendenciaFinanceiraController(IContatoRepository contatoRepository,
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


        [HttpGet("{usuarioId}")]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodos(string usuarioId)
        {
            var contato = _mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoRepository.ObterContatosOrdenadosPendenciaFinanceira(usuarioId));
            return contato;
        }
    }
}
