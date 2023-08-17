
using Core.Entities;

namespace Infrastructure.Data.Interfaces
{
    public interface INakisaGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
	}
}

