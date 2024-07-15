using Datn.Application.DataTransferObj;

namespace Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> Create(ProductCreateRequest productCreateRequest)
        {
            var productDto = await httpClient.PostAsJsonAsync("api/Product/create", productCreateRequest);
            return productDto.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var productDto = await httpClient.DeleteAsync($"api/Product/delete?id={id}");
            return productDto.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var productDto = await httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
            return productDto;
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            var productDto = await httpClient.GetFromJsonAsync<ProductDto>($"api/Product/{id}");
            return productDto;
        }

        public async Task<bool> Update(Guid id, ProductUpdateRequest productUpdateRequest)
        {
            var productDto = await httpClient.PutAsJsonAsync($"api/Product/update?id={id}",productUpdateRequest);
            return productDto.IsSuccessStatusCode;
        }
    }
}
