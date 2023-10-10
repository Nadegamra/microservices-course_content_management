using CourseContentManagement.Data;
using CourseContentManagement.Data.DTOs.Section;
using CourseContentManagement.Data.Models;

namespace CourseContentManagement.Handlers
{
    public class SectionsHandler
    {
        private readonly CourseContentDbContext dbContext;

        public SectionsHandler(CourseContentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Section>> GetSectionListAsync(int courseId)
        {
            Course? course = dbContext.Courses.Where(x => x.Id == courseId).FirstOrDefault();

            if (course == null || course.IsDeleted)
            {
                throw new Exception("Course, associated with this section does not exist");
            }
            return dbContext.Sections.Where(x => x.CourseId == courseId && !x.IsHidden).ToList();
        }
        public async Task<List<Section>> GetUserSectionListAsync(int courseId, int userId)
        {
            Course? course = dbContext.Courses.Where(x => x.Id == courseId).FirstOrDefault();

            bool isOwner = userId == course?.UserId;

            if (course == null || course.IsDeleted || !isOwner)
            {
                throw new Exception("Course, associated with this section does not exist");
            }
            return dbContext.Sections.Where(x => x.CourseId == courseId).ToList();
        }

        public async Task<Section?> GetSectionAsync(int courseId, int id)
        {
            Course? course = dbContext.Courses.Where(x => x.Id == courseId).FirstOrDefault();

            if (course == null || course.IsDeleted)
            {
                throw new Exception("Course, associated with this section does not exist");
            }
            return dbContext.Sections.Where(x => x.CourseId == courseId && x.Id == id && !x.IsHidden).FirstOrDefault();
        }
        public async Task<Section?> GetUserSectionAsync(int courseId, int userId, int id)
        {
            Course? course = dbContext.Courses.Where(x => x.Id == courseId).FirstOrDefault();

            bool isOwner = userId == course?.UserId;

            if (course == null || course.IsDeleted || !isOwner)
            {
                throw new Exception("Course, associated with this section does not exist");
            }
            return dbContext.Sections.Where(x => x.CourseId == courseId && x.Id == id).FirstOrDefault();
        }

        public async Task<Section> AddSectionAsync(int courseId, SectionAddRequest req, int userId)
        {
            IsUserCourseOwnerCheck(userId, courseId);

            Section section = new Section { CourseId = courseId, Name = req.Name, Description = req.Description, IsHidden = true };
            var res = await dbContext.Sections.AddAsync(section);
            await dbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Section> UpdateSectionAsync(int courseId, int sectionId, SectionUpdateRequest req, int userId)
        {
            IsUserCourseOwnerCheck(userId, courseId);

            Section? original = dbContext.Sections.Where(x => x.Id == sectionId).FirstOrDefault();
            if (original == null)
            {
                throw new Exception("Section does not exist");
            }

            Section section = new Section { Name = req.Name, Description = req.Description, IsHidden = req.IsHidden ?? original.IsHidden };
            foreach (var pair in typeof(Section).GetProperties())
            {
                var value = pair.GetValue(section);
                if (pair.Name == "Id" || value == null || pair.Name == "CourseId")
                {
                    continue;
                }
                pair.SetValue(original, value);
            }

            dbContext.Sections.Update(original);
            await dbContext.SaveChangesAsync();
            return original;
        }

        public async Task<bool> DeleteSectionAsync(int Id, int userId)
        {
            Section? section = dbContext.Sections.Where(x => x.Id == Id).FirstOrDefault();
            if (section == null)
            {
                return false;
            }

            IsUserCourseOwnerCheck(userId, section.CourseId);

            dbContext.Sections.Remove(section);
            await dbContext.SaveChangesAsync();
            return true;
        }

        private void IsUserCourseOwnerCheck(int userId, int courseId)
        {
            Course? course = dbContext.Courses.Where(x => x.Id == courseId).FirstOrDefault();
            if (course == null)
            {
                throw new Exception("Course with specified id does not exist");
            }
            if (course.UserId != userId)
            {
                throw new Exception("Unauthorized");
            }
        }
    }
}