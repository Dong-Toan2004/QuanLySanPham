using Datn.Application.DataTransferObj;
using Datn.Domain.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datn.Application.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> Update(Product product);
        Task<Product> Create(Product product);
        Task<Product> Detete(Guid id);
    }
}
