using CourseContentManagement.Data.Models;

namespace CourseContentManagement.Data
{
    public static class DefaultData
    {
        public static List<Course> Courses = new List<Course> {
            new Course { Id = 1, UserId = 2, IsHidden = true, IsDeleted = false },
            new Course { Id = 2, UserId = 2, IsHidden = false, IsDeleted = false}
        };

        public static List<Section> Sections = new List<Section>
        {
            new Section { Id = 1, CourseId = 1, IsHidden = true, Name = "Intro", Description = "What will be learned in this course"},
            new Section { Id = 2, CourseId = 1, IsHidden = true, Name = "Variables and arithmetic", Description = "Introduction to python variables and arithmetic operations"},
            new Section { Id = 3, CourseId = 1, IsHidden = true, Name = "Functions", Description = "Python functions"},
            new Section { Id = 4, CourseId = 2, IsHidden = false, Name = "Installation", Description = "Installation process on different OS'es"},
            new Section { Id = 5, CourseId = 2, IsHidden = false, Name = "Dockerfiles", Description = "Dockerfile writing basics"},
            new Section { Id = 6, CourseId = 2, IsHidden = false, Name = "Docker compose", Description = "How to write docker compose files"},
            new Section { Id = 7, CourseId = 2, IsHidden = true, Name = "Docker CLI", Description = "Most commonly used docker CLI commands"},
        };

        public static List<InfoPage> InfoPages = new List<InfoPage>
        {
            new InfoPage { Id = 1, SectionId = 1, IsHidden = true, Name="Introduction", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 2, SectionId = 2, IsHidden = true, Name="Arithmetic operations", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 3, SectionId = 2, IsHidden = true, Name="Variables", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 4, SectionId = 3, IsHidden = true, Name="Function introduction", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 5, SectionId = 3, IsHidden = true, Name="Function parameters", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 6, SectionId = 4, IsHidden = false, Name="Windows", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 7, SectionId = 4, IsHidden = false, Name="Linux", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 8, SectionId = 4, IsHidden = true, Name="MacOS", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 9, SectionId = 5, IsHidden = false, Name="Undelying principles", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 10, SectionId = 5, IsHidden = false, Name="Dockerfile syntax", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 11, SectionId = 6, IsHidden = false, Name="Docker compose file syntax", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 12, SectionId = 6, IsHidden = true, Name="Environment files (.env)", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
            new InfoPage { Id = 13, SectionId = 7, IsHidden = true, Name="Container management", Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
        };
    }
}