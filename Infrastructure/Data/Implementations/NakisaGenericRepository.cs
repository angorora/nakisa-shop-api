using System;
using Core.Entities;
using Core.Specificatons;
using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Implementations
{
	public class NakisaGenericRepository<T> : INakisaGenericRepository<T> where T : BaseEntity
	{
        private readonly StoreContext _storeContext;

        public NakisaGenericRepository(StoreContext storeContext)
		{
            _storeContext = storeContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await  _storeContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _storeContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> specification)
        {
            return await GetSpecData(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetListAsync()
        {
            return await _storeContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetListFromSpec(ISpecification<T> spec)
        {
            return await GetSpecData(spec).ToListAsync();
        }

        private  IQueryable<T> GetSpecData(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.BuildSpecificationQuery(_storeContext.Set<T>().AsQueryable<T>(), spec);
        }
    }
}

