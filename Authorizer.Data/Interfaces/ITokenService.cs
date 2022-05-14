using Authorizer.Business.DataTransferObjects;
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
        Task<UserDTO> VerifyAccess(string accessToken);
        Task<UserDTO> VerifyRefresh(string refreshToken);
    }
}
