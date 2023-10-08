namespace CourseContentManagement.Data.DTOs.Section
{
    public class SectionUpdateRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsHidden { get; set; }
    }
}