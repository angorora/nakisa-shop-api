
using System.Linq.Expressions;
using Core.Entities;
using Core.Specificatons;

namespace Infrastructure.Data.Specifications
{
	public class ProductsWithBrandsAndTypesSpecification: BaseSpecification<Product> 
	{
		public ProductsWithBrandsAndTypesSpecification()
		{
			AddIncludes(x => x.ProductTypes);
			AddIncludes(x => x.ProductBrands);
		}
		public ProductsWithBrandsAndTypesSpecification(int id):
			base(x=>x.Id == id)
        {
            AddIncludes(x => x.ProductTypes);
            AddIncludes(x => x.ProductBrands);
        }
    }
}

