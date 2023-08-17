using System;
using Core.Entities;
using Core.Specificatons;

namespace Infrastructure.Data.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<IReadOnlyList<T>> GetAllAsync();
		Task<T> GetById(int id);
		Task<IReadOnlyList<T>>GetListFromSpec(ISpecification<T> spec);
		Task<T> GetEntityWithSpec(ISpecification<T> specification);
	}
}

