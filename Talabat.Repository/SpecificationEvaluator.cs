using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    internal static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var Query = inputQuery;
            if (spec.Criteria != null) 
            {
                Query = Query.Where(spec.Criteria);
            }
            Query = spec.Includes.Aggregate(Query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            return Query;
        } 
    }
}
