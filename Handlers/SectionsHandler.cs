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

        public async Task<List<Section>> GetSectionListAsync(int courseId, int userId)
        {
            Course? course = dbContext.Courses.Where(x => x.Id == courseId).FirstOrDefault();

            bool isOwner = userId == course?.UserId;

            if (course == null || course.IsDeleted || (!isOwner && course.IsHidden))
            {
                throw new Exception("Course, associated with this section does not exist");
            }
            return dbContext.Sections.Where(x => x.CourseId == courseId || x.IsHidden || (x.IsHidden && isOwner)).ToList();
        }

        public async Task<Section> AddSectionAsync(SectionAddRequest req, int userId)
        {
            IsUserCourseOwnerCheck(userId, req.CourseId);

            Section section = new Section { CourseId = req.CourseId, Name = req.Name, Description = req.Description, IsHidden = true };
            var res = await dbContext.Sections.AddAsync(section);
            await dbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Section> UpdateSectionAsync(SectionUpdateRequest req, int userId)
        {
            IsUserCourseOwnerCheck(userId, req.CourseId);

            Section? original = dbContext.Sections.Where(x => x.Id == req.Id).FirstOrDefault();
            if (original == null)
            {
                throw new Exception("Section does not exist");
            }

            Section section = new Section { Name = req.Name, Description = req.Description, IsHidden = req.IsHidden };
            foreach (var pair in typeof(Section).GetProperties())
            {
                var value = pair.GetValue(section);
                if (pair.Name == "Id" || value == null)
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