using Datn.Application.DataTransferObj;
using Microsoft.AspNetCore.Components;
using Web.Services;

namespace Web.Components.Pages
{
    public partial class Product : ComponentBase
    {
        [Inject] private IProductService ProductService { get; set; }
        private IEnumerable<ProductDto> ProductDto {  get; set; }
        protected override async Task OnInitializedAsync()
        {
            ProductDto = await ProductService.GetAll();
        }
    }
}
