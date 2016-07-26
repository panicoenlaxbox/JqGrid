using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using JqGrid.Models.Entities;

namespace JqGrid.Models.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly IDbSet<T> _set;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
            _set = _context.Set<T>();
        }

        public void SaveGraph(T entity)
        {
            _set.Add(entity);
            _context.ApplyStateChanges();
        }

        public void Save(T entity)
        {
            if (entity.Id == default(int))
            {
                _set.Add(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Remove(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll()
        {
            return _set;
        }

        public IQueryable<T> GetAll<TKey>(IEnumerable<Expression<Func<T, bool>>> predicates,
            IEnumerable<Expression<Func<T, object>>> includes, Expression<Func<T, TKey>> sortExpression)
        {
            IQueryable<T> query = _set;
            ApplyPredicates(ref query, predicates);
            ApplyIncludes(ref query, includes);
            if (sortExpression != null)
            {
                query = query.OrderBy(sortExpression);
            }
            return query;
        }

        public IQueryable<T> GetAll(IEnumerable<Expression<Func<T, bool>>> predicates,
            IEnumerable<Expression<Func<T, object>>> includes, string sortExpression)
        {
            IQueryable<T> query = _set;
            ApplyPredicates(ref query, predicates);
            ApplyIncludes(ref query, includes);
            if (!string.IsNullOrWhiteSpace(sortExpression))
            {
                query = query.OrderBy(sortExpression);
            }
            return query;
        }

        public IQueryable<TResult> GetAll<TResult, TKey>(Expression<Func<T, TResult>> @select,
            IEnumerable<Expression<Func<T, bool>>> predicates,
            IEnumerable<Expression<Func<T, object>>> includes, Expression<Func<T, TKey>> sortExpression)
        {
            IQueryable<T> query = _set;
            ApplyPredicates(ref query, predicates);
            ApplyIncludes(ref query, includes);
            if (sortExpression != null)
            {
                query = query.OrderBy(sortExpression);
            }
            return query.Select(select);
        }

        public IQueryable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> @select,
            IEnumerable<Expression<Func<T, bool>>> predicates,
            IEnumerable<Expression<Func<T, object>>> includes, string sortExpression)
        {
            IQueryable<T> query = _set;
            ApplyPredicates(ref query, predicates);
            ApplyIncludes(ref query, includes);
            if (!string.IsNullOrWhiteSpace(sortExpression))
            {
                query = query.OrderBy(sortExpression);
            }
            return query.Select(select);
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }

        private void ApplyIncludes(ref IQueryable<T> query, IEnumerable<Expression<Func<T, object>>> includes)
        {
            if (includes == null)
            {
                return;
            }
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        private void ApplyPredicates(ref IQueryable<T> query,
            IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            if (predicates == null)
            {
                return;
            }
            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }
        }
    }
}