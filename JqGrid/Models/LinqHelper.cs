using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JqGrid.Models
{
    public static class LinqHelper
    {
        public static IEnumerable<Expression<Func<T, bool>>> Predicates<T>(
            params Expression<Func<T, bool>>[] predicates)
        {
            return new List<Expression<Func<T, bool>>>(predicates);
        }

        public static IEnumerable<Expression<Func<T, object>>> Includes<T>(
            params Expression<Func<T, object>>[] includes)
        {
            return new List<Expression<Func<T, object>>>(includes);
        }
    }
}