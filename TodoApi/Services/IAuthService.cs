using TodoApi.Domain.Entities;

namespace TodoApi.Services;

public interface IAuthService
{
    string GenerateJwtToken(User user);
}
