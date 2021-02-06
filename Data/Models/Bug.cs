using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugBlaze.Data.Models
{
    public class Bug
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Component { get; set; }
        public int ProjectId { get; set; }
        public BugSeverity Severity { get; set; }

        public enum BugSeverity
        {
            low = 1,
            medium = 2,
            high = 3,
            critical = 4
        }
    }

}
