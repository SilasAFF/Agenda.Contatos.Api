using Agenda.Contatos.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Contatos.Business.Interfaces
{
    public interface IRepository<TEntidadeBase> : IDisposable where TEntidadeBase : EntidadeBase
    {
        Task<List<TEntidadeBase>> ObterTodos();
        Task Adicionar(TEntidadeBase entidadeBase);
        Task Atualizar(TEntidadeBase entidadeBase);
        Task Remover(Guid id);
        Task<TEntidadeBase> ObterPorId(Guid id);
        Task<IEnumerable<TEntidadeBase>> Buscar(Expression<Func<TEntidadeBase, bool>> predicate);
        Task<int> SaveChanges();
    }
}
