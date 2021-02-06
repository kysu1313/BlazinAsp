using System.ComponentModel.DataAnnotations;

namespace BugBlaze.Data.Models
{
    public class Project
    {
        public Project() {}

        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
    }
}
