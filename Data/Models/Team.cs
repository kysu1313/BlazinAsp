using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugBlaze.Data.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int NumMembers { get; set; }
        public IEnumerable<UserModel> Members { get; set; }

    }
}