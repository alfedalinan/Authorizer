using Authorizer.Business.Entities;
using Authorizer.Data.Repositories.Interfaces;
using Authorizer.Data.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Authorizer.Data.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthorizerContext _context;
        public UserRepository(AuthorizerContext context)
        {
            _context = context;
        }

        public async Task<User> GetByCredentials(string username, string password)
        {
            return await _context.Users.Where(a => a.Username == username && a.Password == password).FirstOrDefaultAsync();   
        }
    }
}
