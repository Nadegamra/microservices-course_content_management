using System.ComponentModel.DataAnnotations;

namespace CourseContentManagement.Data.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsHidden { get; set; }
    }
}