namespace CourseContentManagement.Data.DTOs.Section
{
    public class SectionUpdateRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsHidden { get; set; }

        public Models.Section UpdateEntity(Models.Section original)
        {
            original.Name = Name ?? original.Name;
            original.Description = Description ?? original.Description;
            original.IsHidden = IsHidden ?? original.IsHidden;
            return original;
        }
    }
}