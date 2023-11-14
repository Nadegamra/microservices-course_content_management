namespace CourseContentManagement.Data.DTOs.InfoPage
{
    public class InfoPageUpdateRequest
    {
        public string? Name { get; set; }
        public string? Text { get; set; }
        public bool? IsHidden { get; set; }

        public Models.InfoPage UpdateEntity(Models.InfoPage original)
        {
            original.Name = Name ?? original.Name;
            original.Text = Text ?? original.Text;
            original.IsHidden = IsHidden ?? original.IsHidden;
            return original;
        }
    }
}