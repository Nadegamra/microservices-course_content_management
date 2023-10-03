using System.ComponentModel.DataAnnotations;

namespace CourseContentManagement.Data.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDeleted { get; set; }
    }
}