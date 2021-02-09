using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BugBlaze.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        //[PersonalData]
        //public int UserModelId { get; set; }
        [PersonalData]
        public string GitHubUrl { get; set; }
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string EmailAddress { get; set; }
        //public Team OnTeam { get; set; }
    }
}
