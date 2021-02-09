using BugBlaze.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugBlaze.Auth
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>

    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        //protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        //{
        //    var identity = await base.GenerateClaimsAsync(user);
        //    identity.AddClaim(new Claim("urn:github:url", user.GitHubUrl ?? ""));
        //    return identity;
        //}

    }
}
