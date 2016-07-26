using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JqGrid.Models.Entities;

namespace JqGrid.Models.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        T Get(int id);
        IQueryable<T> GetAll();

        IQueryable<T> GetAll<TKey>(IEnumerable<Expression<Func<T, bool>>> predicates,
            IEnumerable<Expression<Func<T, object>>> includes, Expression<Func<T, TKey>> sortExpression);

        IQueryable<T> GetAll(IEnumerable<Expression<Func<T, bool>>> predicates,
            IEnumerable<Expression<Func<T, object>>> includes, string sortExpression);

        IQueryable<TResult> GetAll<TResult, TKey>(Expression<Func<T, TResult>> @select,
            IEnumerable<Expression<Func<T, bool>>> predicates,
            IEnumerable<Expression<Func<T, object>>> includes, Expression<Func<T, TKey>> sortExpression);

        IQueryable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> @select,
            IEnumerable<Expression<Func<T, bool>>> predicates,
            IEnumerable<Expression<Func<T, object>>> includes, string sortExpression);

        void Remove(T entity);
        void Save(T entity);
        void SaveGraph(T entity);
    }
}