using FPTCertification.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FPTCertification.Business.Services
{
    public interface IBaseService<TEntity, TKey> where TEntity : class
    {
        TEntity GetById(TKey id);
        TEntity GetById(TKey id, Expression<Func<TEntity, object>> include);
        IQueryable<TEntity> Entity();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TKey id);
        TEntity Delete(TEntity entity);
        void Dispose();
        void Commit();
        void CommitAsync();
    }
    public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey>, IDisposable where TEntity : class
    {
        DataContext _context;
        DbSet<TEntity> dbSet;
        private bool _disposed;
        public BaseService(DataContext context)
        {
            this._context = _context ?? context;
            this.dbSet = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void CommitAsync()
        {
            _context.SaveChangesAsync();
        }

        public TEntity Delete(TKey id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                return dbSet.Remove(entity).Entity;
            }
            return null;
        }

        public TEntity Delete(TEntity entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> Entity()
        {
            return dbSet;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
            {
                return dbSet;
            }
            return dbSet.Where(expression);
        }

        public TEntity GetById(TKey id)
        {
            return dbSet.Find(id);
        }

        public TEntity GetById(TKey id, Expression<Func<TEntity, object>> include)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            var result = _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
