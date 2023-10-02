using System.ComponentModel.DataAnnotations;

namespace CourseContentManagement.Data.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string ShortDescription { get; set; }
    }
}