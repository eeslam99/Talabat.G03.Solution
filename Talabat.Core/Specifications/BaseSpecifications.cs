﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; } = null;
        public Expression<Func<T, object>> OrderByDesc { get; set; } = null;

        public BaseSpecifications()
        {

        }
        public BaseSpecifications(Expression<Func<T,bool>> CriteriaExpression)
        {
            Criteria = CriteriaExpression;

        }

        public void AddOrderBy(Expression<Func<T,Object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        public void AddOrderByDesc(Expression<Func<T, Object>> OrderByDescExpression)
        {
            OrderByDesc = OrderByDescExpression;
        }
    }
}
