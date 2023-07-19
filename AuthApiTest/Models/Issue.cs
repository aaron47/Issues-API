using System.ComponentModel.DataAnnotations;

namespace AuthApiTest.Models
{
    public class Issue
    {
        public int Id { get; set; }
        [Required] public String Title { get; set; }

        [Required] public String Description { get; set; }

        public Priority Priority { get; set; }
        public IssueType IssueType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum IssueType
    {
        Feature,
        Bug,
        Documentation,
        Other
    }
}