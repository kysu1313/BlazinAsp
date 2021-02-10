﻿using BugBlaze.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugBlaze.Auth
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserModel>
    {
        public MyUserClaimsPrincipalFactory(
            UserManager<UserModel> userManager,
            IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserModel user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("urn:github:url", user.GitHubUrl ?? ""));

            return identity;
        }
    }
}
