using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BugTracker.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly BugTrackerDBContext _context;

        protected BaseRepository(BugTrackerDBContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }


        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }


        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }


        public void Add(TEntity entity)
        {
            SetCreateVars(entity);
            _context.Set<TEntity>().Add(entity);
        }


        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }


        public void Update(TEntity entity)
        {
            SetUpdateVars(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }


        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }


        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }


        public T SetCreateVars<T>(T model)
        {
            model = SetUpdateVars(model);

            ((dynamic)model).CreateDate = DateTime.Now;
            ((dynamic)model).CreatedBy = 1;

            return model;
        }


        public T SetUpdateVars<T>(T model)
        {
            ((dynamic)model).EditDate = DateTime.Now;
            ((dynamic)model).EditedBy = 1;

            return model;
        }
    }

    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);

        T SetCreateVars<T>(T model);
        T SetUpdateVars<T>(T model);
    }
}
