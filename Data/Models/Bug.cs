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
        [Required]
        public string Component { get; set; }
        public string ProjectId { get; set; }
        public int Severity { get; set; }
        public bool Resolved { get; set; }

        
    }

}
