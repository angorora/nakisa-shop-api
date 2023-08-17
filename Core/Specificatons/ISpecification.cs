using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specificatons
{
	public interface ISpecification<T> 
	{
		Expression<Func<T, bool>> Criteria { get; }

		List<Expression<Func<T, object>>> Includes { get; }
	}
}

