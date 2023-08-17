
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data.Interfaces;
using Infrastructure.Data.Specifications;
using AutoMapper;
using API.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly INakisaGenericRepository<Product> _nakisaGenericProductRepository;
        private readonly INakisaGenericRepository<ProductBrand> _nakisaGenericProductBrandRepository;
        private readonly INakisaGenericRepository<ProductType> _nakisaGenericProductTypeRepository;
        private readonly IMapper _mapper;

        public ProductsController(INakisaGenericRepository<Product> nakisaGenericProductRepository,
            INakisaGenericRepository<ProductBrand> nakisaGenericProductBrandRepository,
            INakisaGenericRepository<ProductType> nakisaGenericProductTypeRepository,
            IMapper mapper)
        {
            _nakisaGenericProductRepository = nakisaGenericProductRepository;
            _nakisaGenericProductBrandRepository = nakisaGenericProductBrandRepository;
            _nakisaGenericProductTypeRepository = nakisaGenericProductTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var productsSpec = new ProductsWithBrandsAndTypesSpecification();
            return Ok(await _nakisaGenericProductRepository.GetListFromSpec(productsSpec)) ;
        }

        [HttpGet("producttypes")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _nakisaGenericProductTypeRepository.GetAllAsync());
        }

        [HttpGet("productbrands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _nakisaGenericProductBrandRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProducts(int Id)
        {
            var spec = new ProductsWithBrandsAndTypesSpecification(Id);
            var product = await _nakisaGenericProductRepository.GetEntityWithSpec(spec);
            return Ok(_mapper.Map<Product, ProductDTO>(product));
        }
    }
}

