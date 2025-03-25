using Microsoft.AspNetCore.Identity;

namespace TodoApi.Domain.Entities;

public class User : IdentityUser
{
    public string Name { get; set; } = String.Empty;
}
