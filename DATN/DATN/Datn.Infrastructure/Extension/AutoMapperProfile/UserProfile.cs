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
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserCreateRequest, User>();
        }
    }
}
