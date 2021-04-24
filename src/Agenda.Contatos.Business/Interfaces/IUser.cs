using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Agenda.Contatos.Business.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAutheticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClainsIdentity();
    }
}
