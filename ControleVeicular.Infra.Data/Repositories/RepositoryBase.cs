using ControleVeicular.Domain.Interfaces.Repositories;
using ControleVeicular.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleVeicular.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ControleVeicularContext Db = new ControleVeicularContext();
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void DetachLocal(Func<TEntity, bool> predicate)
        {
            var local = Db.Set<TEntity>().Local.Where(predicate).FirstOrDefault();
            if (local != null)
            {
                Db.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            }
        }
    }
}
