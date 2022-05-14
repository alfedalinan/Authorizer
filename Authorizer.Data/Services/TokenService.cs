using Authorizer.Business.Entities;
using Authorizer.Data.Constants;
using Authorizer.Data.Interfaces;
using Authorizer.Data.Repositories.Interfaces;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Authorizer.Data.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserRepository _userRepository;
        public TokenService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> VerifyAccess(string accessToken)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                var json = decoder.Decode(accessToken, TokenConstants.AccessSecret, verify: true);

                var payload = JsonConvert.DeserializeObject<Payload>(json);

                return await _userRepository.GetByCredentials(payload.Username, payload.Password);
            }
            catch (TokenExpiredException ex)
            {
                throw new Exception("Expired");
            }
            catch (SignatureVerificationException ex)
            {
                throw new Exception("Invalid Signature");
            }
        }

        public async Task<User> VerifyRefresh(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
