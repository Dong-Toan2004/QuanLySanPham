using Datn.Application.Interface;
using Datn.Domain.Database.Entities;
using Datn.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datn.Infrastructure.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContexts contexts;

        public UserRepository(AppDbContexts contexts)
        {
            this.contexts = contexts;
        }
        public async Task<User> Create(User user)
        {
            Cart cart = new Cart()
            {
                Id = user.Id,
                UserId = user.Id,
            };
            await contexts.Users.AddAsync(user);
            await contexts.Carts.AddAsync(cart);
            await contexts.SaveChangesAsync();
            return user;
        }

        public async Task<User> Delete(Guid id)
        {
            var userDelete = await contexts.Users.FindAsync(id);
            contexts.Users.Remove(userDelete);
            await contexts.SaveChangesAsync();
            return userDelete;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var userData = await contexts.Users.ToListAsync();
            return userData;
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await contexts.Users.FindAsync(id);
            return user;
        }


        public async Task<User> Update(User user)
        {
            contexts.Entry(user).State = EntityState.Modified;
            await contexts.SaveChangesAsync();
            return user;
        }
    }
}
