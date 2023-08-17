using System.Linq;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specificatons
{
	public class BaseSpecification<T> : ISpecification<T> 
	{
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
		}

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public void AddIncludes(Expression<Func<T, object>> include) {
            this.Includes.Add(include);
        }
    }
}

