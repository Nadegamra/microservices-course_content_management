namespace CourseContentManagement.Data.DTOs.Section
{
    public class SectionAddRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }

        public Models.Section ToEntity(int courseId)
        {
            return new Models.Section
            {
                CourseId = courseId,
                Name = Name,
                Description = Description,
                IsHidden = true
            };
        }
    }
}