using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MongoDbContext context;

        public UserRepository(MongoDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await context.Users
                .Find(x => x.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(User user)
        {
            await context.Users.InsertOneAsync(user);
        }
    }
}
