namespace CourseContentManagement.Data.DTOs.InfoPage
{
    public class InfoPageAddRequest
    {
        public required string Name { get; set; }
        public required string Text { get; set; }

        public Models.InfoPage ToEntity(int sectionId)
        {
            return new Models.InfoPage
            {
                SectionId = sectionId,
                Name = Name,
                Text = Text,
                IsHidden = true
            };
        }
    }
}