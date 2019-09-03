using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Rodolfo.Schmidt.Data.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> EagerLoad<T>(this IQueryable<T> query, params
            Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));

            return query;
        }
    }
}
