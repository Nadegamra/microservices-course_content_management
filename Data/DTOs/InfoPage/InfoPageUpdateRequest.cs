namespace CourseContentManagement.Data.DTOs.InfoPage
{
    public class InfoPageUpdateRequest
    {
        public string? Name { get; set; }
        public string? Text { get; set; }
        public bool? IsHidden { get; set; }
    }
}