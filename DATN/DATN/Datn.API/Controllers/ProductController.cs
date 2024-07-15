using AutoMapper;
using Datn.Application.DataTransferObj;
using Datn.Application.Interface;
using Datn.Domain.Database.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Datn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository products;
        private readonly IMapper mapper;

        // GET: api/<ProductController>
        public ProductController(IProductRepository product, IMapper mapper)
        {
            this.products = product;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var product = await products.GetAll();
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                var productDto = mapper.Map<IEnumerable<ProductDto>>(product);
                return Ok(productDto);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var productId = await products.GetById(id);
            if (productId == null)
            {
                return BadRequest("Không có dữ liệu");
            }
            else
            {
                return Ok(productId);
            }
        }

        // POST api/<ProductController>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] ProductCreateRequest product)
        {           
            var data = await products.Create(mapper.Map<Product>(product));
            return Ok(data);
        }

        // PUT api/<ProductController>/5
        [HttpPut("update")]
        public async Task<ActionResult> Update(Guid id, [FromBody] ProductUpdateRequest product)
        {
            try
            {
                var productUpdate = await products.GetById(id);
                if (productUpdate == null)
                {
                    return BadRequest("Không tìm thấy");
                }
                else
                {
                    productUpdate.Name = product.Name;
                    productUpdate.Description = product.Description;
                    productUpdate.Price = product.Price;
                    productUpdate.Image = product.Image;
                    productUpdate.Quantity = product.Quantity;
                    productUpdate.CategoryId = product.CategoryId;

                    await products.Update(productUpdate);
                    return Ok(productUpdate);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await products.Detete(id);
            return Ok("Xóa thành công");
        }
    }
}
