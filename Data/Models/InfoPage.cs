using System.ComponentModel.DataAnnotations;

namespace CourseContentManagement.Data.Models
{
    public class InfoPage
    {
        [Key]
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public bool? IsHidden { get; set; }
    }
}