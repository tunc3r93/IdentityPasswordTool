using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using IdentityPasswordTool.Models;

namespace IdentityPasswordTool.Services;
public class PasswordHashService
{
    public string HashPassword(string password, HashOptionsModel options)
    {
        var hasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = options.UseIdentityV3
                ? PasswordHasherCompatibilityMode.IdentityV3
                : PasswordHasherCompatibilityMode.IdentityV2,
            IterationCount = options.IterationCount
        };

        var hasher = new PasswordHasher<IdentityUserModel>(
            Options.Create(hasherOptions));

        var user = new IdentityUserModel
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "temp"
        };

        return hasher.HashPassword(user, password);
    }
}