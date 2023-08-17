using System;
using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
	public class AutoMapperProfiles: Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Product, ProductDTO>()
			.ForMember(dest=>dest.ProductBrand,source =>source.MapFrom(s=>s.ProductBrands.Name))
             .ForMember(dest => dest.ProductType, source => source.MapFrom(s => s.ProductTypes.Name));
            ;
        }
	}
}

