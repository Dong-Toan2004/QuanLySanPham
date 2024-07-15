using Datn.Application.DataTransferObj;

namespace Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(Guid id);
        Task<bool> Create(ProductCreateRequest productCreateRequest);
        Task<bool> Update(Guid id, ProductUpdateRequest productUpdateRequest);
        Task<bool> DeleteById(Guid id);
    }
}
