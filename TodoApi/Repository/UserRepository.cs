using Microsoft.AspNetCore.Identity;
using TodoApi.Domain.Entities;

namespace TodoApi.Repository;
/*
    TODO: Implement Change Password method - Needed authentication 
    TODO: Implement SignOut method - Needed authentication
    TODO: Implement Change Email method - Needed authentication
 */
public class UserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> CreateUser(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<User?> FindByEmail(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> CheckPassword(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<SignInResult> SignIn(string email, string password)
    {
        return await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
    }
}
