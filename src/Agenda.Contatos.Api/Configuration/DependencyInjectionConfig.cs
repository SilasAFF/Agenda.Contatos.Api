using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Notificacoes;
using Agenda.Contatos.Business.Services;
using Agenda.Contatos.Data.Context;
using Agenda.Contatos.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<AgendaDbContext>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            return services;
        }
    }
}
