using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugBlaze.Data.Models
{
    public class Repository : Project
    {
        public string RepoName { get; set; }
        public ApplicationUser Owner { get; set; }
        public int Id { get; set; }
        public string url { get; set; }
        public string starredUrl { get; set; }
        public string followersUrl { get; set; }
    }
}
