using System;
using System.Threading.Tasks;
using Hotels.API.Models;

namespace Hotels.API.Services
{
    public interface IUserService
    {
        Task<UserInfo> Authenticate(TokenRequest req);
        string CreateRefreshToken();
        Task<UserInfo> RefreshToken(string refreshToken);
    }
}
