using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using WebApi.Helpers;
using WebApi.Models.DTO;
using WebApi.Models.Entities;
using WebApi.Models.Identity;
using WebApi.Repositories;

namespace WebApi.Services;

public class AuthService
{
    private readonly UserProfileRepo _userProfileRepo;
    private readonly UserManager<CustomIdentityUser> _userManager;
    private readonly SignInManager<CustomIdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JwtToken _jwt;

    public AuthService(UserProfileRepo userProfileRepo, UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, JwtToken jwt, RoleManager<IdentityRole> roleManager)
    {
        _userProfileRepo = userProfileRepo;
        _userManager = userManager;
        _signInManager = signInManager;
        _jwt = jwt;
        _roleManager = roleManager;
    }

    public async Task<bool> RegisterAsync(AuthenticationSignupModel model)
    {
        try
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("productChief"));
            }

            if (!await _userManager.Users.AnyAsync())
                model.RoleName = "admin";


            var identityResult = await _userManager.CreateAsync(model, model.Password);

            if (identityResult.Succeeded)
            {
                var identityUser = await _userManager.FindByEmailAsync(model.Email);
                var roleResult = await _userManager.AddToRoleAsync(identityUser!, model.RoleName);

                if (roleResult.Succeeded)
                {
                    UserProfileEntity userProfileEntity = model;
                    userProfileEntity.UserId = identityUser!.Id;
                    await _userProfileRepo.AddAsync(userProfileEntity);
                    return true;
                }
            }

        } catch { }

        return false;
    }

    public async Task<string> LoginAsync(AuthenticationLoginModel model)
    {
        var identityUser = await _userManager.FindByEmailAsync(model.Email);
        if (identityUser != null)
        {
            var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, model.Password, false);
            if (signInResult.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(identityUser);
                var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", identityUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, identityUser.Email!),
                    new Claim(ClaimTypes.Role, role[0])
                });

                return _jwt.GenerateToken(claimsIdentity, DateTime.Now.AddHours(1));
            }

        }

        return string.Empty;
    }
}
