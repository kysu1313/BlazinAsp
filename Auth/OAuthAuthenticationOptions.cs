using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugBlaze.Auth
{
    public class OAuthAuthenticationOptions : AuthenticationOptions
    {
        /// <summary>
        /// A list of permissions to request.
        /// 
        /// </summary>
        public IList<string> Scope { get; private set; }
    }
}
