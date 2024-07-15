using Datn.Application.DataTransferObj;
using Datn.Domain.Database.Entities;
using Datn.Infrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Datn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContexts _context;

        public CartController(IConfiguration configuration, AppDbContexts context)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("{cartId}/details")]
        public async Task<ActionResult<IEnumerable<CartDetail>>> GetCartDetails(Guid cartId)
        {
            var data = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            cartId = Guid.Parse(data);
            var cartDetails = await _context.CartsDetails
                .Where(cd => cd.CartId == cartId)
                .Include(cd => cd.Product) // Include Product navigation property if needed
                .ToListAsync();

            if (cartDetails == null || cartDetails.Count == 0)
            {
                return NotFound();
            }

            return cartDetails;
        }

        [HttpPost("add-to-cart")]
        [Authorize]
        public async Task<IActionResult> AddToCart(Guid Id, [FromBody] CartdetailCreateRequest model)
        {
            try
            {
                // Lấy UserId từ Claims
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Tìm giỏ hàng của người dùng (nếu có) hoặc tạo mới nếu chưa có
                var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == Guid.Parse(userId));


                // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
                var cartDetail = await _context.CartsDetails.FirstOrDefaultAsync(
                    cd => cd.CartId == cart.Id && cd.ProductId == Id
                );

                if (cartDetail == null)
                {
                    // Nếu chưa có, thêm mới CartDetail
                    cartDetail = new CartDetail
                    {
                        Id = Guid.NewGuid(),
                        CartId = cart.Id,
                        ProductId = model.ProductId,
                        Quantity = model.Quantity
                    };
                    await _context.CartsDetails.AddAsync(cartDetail);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Nếu đã có, cập nhật số lượng
                    cartDetail.Quantity += model.Quantity;
                    _context.CartsDetails.Update(cartDetail);
                    await _context.SaveChangesAsync();
                }

                await _context.SaveChangesAsync();

                return Ok(new { Success = true, Message = "Product added to cart successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Success = false, Error = ex.Message });
            }
        }
    }

}
