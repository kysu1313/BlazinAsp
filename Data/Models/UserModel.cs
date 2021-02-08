using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BugBlaze.Data.Models
{
    public class UserModel : IdentityUser
    {
        public UserModel() { }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Team OnTeam { get; set; }
    }
}
