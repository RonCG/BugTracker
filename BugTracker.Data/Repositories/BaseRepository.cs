using BugTracker.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BugTracker.Data.Repositories
{
    /// <summary>
    /// Base repository class. Handles general db operations.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly BugTrackerDBContext _db;
        protected readonly IRequestUser _requestUser;

        protected BaseRepository(BugTrackerDBContext context, IRequestUser requestUser)
        {
            _db = context;
            _requestUser = requestUser;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }


        public TEntity Get(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }


        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate);
        }


        public void Add(TEntity entity)
        {
            SetCreateVars(entity);
            _db.Set<TEntity>().Add(entity);
        }


        public void AddRange(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().AddRange(entities);
        }


        public void Update(TEntity entity)
        {
            SetUpdateVars(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }


        public void Remove(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }


        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().RemoveRange(entities);
        }


        public T SetCreateVars<T>(T model)
        {
            model = SetUpdateVars(model);
         
            ((dynamic)model).CreateDate = DateTime.Now;
            ((dynamic)model).CreatedBy = SetUserID();

            return model;
        }


        public T SetUpdateVars<T>(T model)
        {
            ((dynamic)model).EditDate = DateTime.Now;
            ((dynamic)model).EditedBy = SetUserID();

            return model;
        }


        private int SetUserID()
        {
            int? userID = _requestUser?.UserID > 0 ? _requestUser.UserID : -1;
            return userID.GetValueOrDefault(-1);
        }
    }



    /// <summary>
    /// IBaseRepository DI interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
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

        T SetUpdateVars<T>(T model);
        T SetCreateVars<T>(T model);

    }
}
