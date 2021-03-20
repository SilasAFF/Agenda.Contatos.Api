using Agenda.Contatos.Business.Interfaces;
using Agenda.Contatos.Business.Models;
using Agenda.Contatos.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Contatos.Data.Repository
{
    public abstract class Repository<TEntidadeBase> : IRepository<TEntidadeBase> where TEntidadeBase : EntidadeBase, new()
    {
        protected readonly AgendaDbContext Db;

        protected readonly DbSet<TEntidadeBase> DbSet;

        protected Repository(AgendaDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntidadeBase>();
        }

        public async Task<IEnumerable<TEntidadeBase>> Buscar(Expression<Func<TEntidadeBase, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntidadeBase> ObterPorId(Guid id)
        {
            //return await DbSet.FindAsync(id); //Tive que comentar pq nao tinha AsNoTracking e tava dando erro na hora de deletar os dados pq tava abrindo transação na chamada desse metodo e não tava fechando antes de fazer o Remove
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public virtual async Task<List<TEntidadeBase>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntidadeBase entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntidadeBase entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntidadeBase { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
