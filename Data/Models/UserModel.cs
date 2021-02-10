using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BugBlaze.Data.Models
{
    public class UserModel : IdentityUser
    {
        public UserModel() { }

        //[Key]

        [PersonalData]
        public int Id { get; set; }
        [PersonalData]
        public string GitHubUrl { get; set; }
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public string EmailAddress { get; set; }

    }

    //public class ApplicationIdentityUserRole : IdentityUserRole<string>
    //{
    //    public virtual UserModel User { get; set; }
    //    public virtual UserModel Role { get; set; }
    //}

}
