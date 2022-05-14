using Authorizer.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizer.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByCredentials(string username, string password);
    }
}
