using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Entities;
using AutoMapper;
using API.Extensions;
using API.RequestHelpers;
using API.DTOs;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;

        public ProductsController(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedList<Product>>> GetProducts([FromQuery] ProductParams productParams, CancellationToken cancellationToken)
        {
            var query = _context.Products
            .Include(p => p.Categories)
            .Sort(productParams.OrderBy)
            .Search(productParams.SearchTerm)
            .FilterByCategory(productParams.Category)
            .AsQueryable();

            var products = await PagedList<Product>.ToPagedList(query, productParams.PageNumber, productParams.PageSize, cancellationToken);

            Response.AddPaginationHeader(products.MetaData);

            if (products == null) return NotFound();
            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(string slug, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(p => p.Slug == slug, cancellationToken);
            if (product == null) return NotFound();
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories(CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync(cancellationToken);
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        //create a product
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto,  CancellationToken cancellationToken)
        {
            // Validate input
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Get categories in a single query
            var categories = createProductDto.CategoryIds?.Any() == true
                ? await _context.Categories
                    .Where(c => createProductDto.CategoryIds.Contains(c.Id))
                    .ToListAsync(cancellationToken)
                : new List<Category>();

            // Create product using AutoMapper
            var product = new Product
            {
                Name = createProductDto.Name.Trim(),
                Description = createProductDto.Description?.Trim(),
                ShortDescription = createProductDto.ShortDescription?.Trim(),
                Price = createProductDto.Price,
                PictureUrl = createProductDto.PictureUrl?.Trim(),
                Stock = createProductDto.Stock,
                Slug = createProductDto.Name.ToLower().Replace(" ", "-").Trim(),
                Categories = categories
            };

            // Use ExecuteAsync for better performance on write operations
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return CreatedAtAction(
                nameof(GetProduct), 
                new { slug = product.Slug }, 
                _mapper.Map<ProductDto>(product));
        }

        //delete a product
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            
            _context.Products.Remove(product);
            var result = await _context.SaveChangesAsync(cancellationToken);
            
            if (result > 0)
                return Ok("Product removed successfully");
            else
                return BadRequest("Failed to remove product");
        }
    }
}