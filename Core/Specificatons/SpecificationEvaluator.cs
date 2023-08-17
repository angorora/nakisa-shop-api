using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Specificatons
{
	public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
	{
        public SpecificationEvaluator()
		{
		}

		public static IQueryable<TEntity> BuildSpecificationQuery(IQueryable<TEntity> query,ISpecification<TEntity> specification)
		{
			var resultantQuery = query;
			if(specification.Criteria != null)
			{
				resultantQuery = resultantQuery.Where(specification.Criteria);
			}

			resultantQuery = specification.Includes.Aggregate(resultantQuery, (current, include) => current.Include(include));

			return resultantQuery;
		}
	}
}

