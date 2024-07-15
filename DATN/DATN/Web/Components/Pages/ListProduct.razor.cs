using Datn.Application.DataTransferObj;
using Microsoft.AspNetCore.Components;
using Web.Services;

namespace Web.Components.Pages
{
    public partial class ListProduct : ComponentBase
    {
        [Inject] private IProductService ProductService { get; set; }
        private IEnumerable<ProductDto> ProductDto { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ProductDto = await ProductService.GetAll();
        }
        private void CreateProduct()
        {
            // Code to create a new product
        }

        private void EditProduct(Guid id)
        {
            // Code to edit a product
        }

        private void ShowDetails(Guid id)
        {
            // Code to show product details
        }

        private async Task DeleteProduct(Guid id)
        {
            var delete = await ProductService.DeleteById(id);
            ProductDto = await ProductService.GetAll();
        }
    }
}
