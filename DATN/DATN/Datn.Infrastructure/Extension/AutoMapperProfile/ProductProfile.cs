using AutoMapper;
using Datn.Application.DataTransferObj;
using Datn.Domain.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datn.Infrastructure.Extension.AutoMapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<ProductCreateRequest, Product>();
        }
    }
}
