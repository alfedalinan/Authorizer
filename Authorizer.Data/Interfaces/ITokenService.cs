using Authorizer.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizer.Data.Interfaces
{
    public interface ITokenService
    {
        Task<User> VerifyAccess(string accessToken);
        Task<User> VerifyRefresh(string refreshToken);
    }
}
