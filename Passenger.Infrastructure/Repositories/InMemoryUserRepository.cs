using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository

    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("user1@gmail.com","user1","secret", "salt", "User"),
            new User("user2@gmail.com","user2","secret", "salt", "User"),
            new User("user3@gmail.com","user3","secret", "salt", "User"),
            new User("user4@gmail.com","user4","secret", "salt", "User"),

        };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));
        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Guid id)
        {
            await Task.CompletedTask;
        }

    }
}