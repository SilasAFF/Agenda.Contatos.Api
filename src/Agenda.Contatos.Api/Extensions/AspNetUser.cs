using Agenda.Contatos.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Agenda.Contatos.Api.Extensions
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            
        }
        public string Name => _accessor.HttpContext.User.Identity.Name;
        public Guid Id;

        public Guid GetUserId()
        {

            return IsAutheticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.NewGuid();
        }

        public string GetUserEmail()
        {
            return IsAutheticated() ? _accessor.HttpContext.User.GetUserEmail() : "";
        }

        public bool IsAutheticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetClainsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
        
    }



    public static class ClaimsPrincipalExtensions
    { 
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if(principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);

            return claim != null ? claim.Value : null;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }
            var claim = principal.FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }
    }
    
}
