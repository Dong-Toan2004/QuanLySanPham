using Datn.Domain.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datn.Application.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(Guid id);
    }
}
