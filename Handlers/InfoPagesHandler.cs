using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CourseContentManagement.Data;
using CourseContentManagement.Data.DTOs.InfoPage;
using CourseContentManagement.Data.Models;

namespace CourseContentManagement.Handlers
{
    public class InfoPagesHandler
    {
        private readonly CourseContentDbContext dbContext;

        public InfoPagesHandler(CourseContentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<InfoPage>> GetInfoPageListAsync(int sectionId, int userId)
        {
            Course? course = dbContext.Courses.Where(x => x.Id == sectionId).FirstOrDefault();

            bool isOwner = userId == course?.UserId;

            if (course == null || course.IsDeleted || (!isOwner && course.IsHidden))
            {
                throw new Exception("Course, associated with this section does not exist");
            }
            return dbContext.InfoPages.Where(x => x.SectionId == sectionId || !x.IsHidden || (x.IsHidden && isOwner)).ToList();
        }

        public async Task<InfoPage> AddInfoPageAsync(InfoPageAddRequest req, int userId)
        {
            IsUserSectionOwnerCheck(userId, req.SectionId);

            InfoPage infoPage = new InfoPage { SectionId = req.SectionId, Name = req.Name, Text = req.Text, IsHidden = true };
            var res = await dbContext.InfoPages.AddAsync(infoPage);
            await dbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<InfoPage> UpdateInfoPageAsync(InfoPageUpdateRequest req, int userId)
        {
            InfoPage? original = dbContext.InfoPages.Where(x => x.Id == req.Id).FirstOrDefault();
            if (original == null)
            {
                throw new Exception("Info page does not exist");
            }

            IsUserSectionOwnerCheck(userId, original.SectionId);

            InfoPage updated = new InfoPage { Name = req.Name, Text = req.Text, IsHidden = req.IsHidden };
            foreach (var pair in typeof(InfoPage).GetProperties())
            {
                var value = pair.GetValue(updated);
                if (pair.Name == "Id" || value == null)
                {
                    continue;
                }
                pair.SetValue(original, value);
            }

            dbContext.InfoPages.Update(original);
            await dbContext.SaveChangesAsync();
            return original;
        }

        public async Task<bool> DeleteInfoPageAsync(int id, int userId)
        {
            InfoPage? infoPage = dbContext.InfoPages.Where(x => x.Id == id).FirstOrDefault();
            if (infoPage == null)
            {
                return false;
            }

            IsUserSectionOwnerCheck(userId, infoPage.SectionId);

            dbContext.InfoPages.Remove(infoPage);
            await dbContext.SaveChangesAsync();
            return true;
        }

        private void IsUserSectionOwnerCheck(int userId, int sectionId)
        {
            Section section = dbContext.Sections.Where(x => x.Id == sectionId).FirstOrDefault();
            if (section == null)
            {
                throw new Exception("Section with specified id does not exist");
            }
            Course? course = dbContext.Courses.Where(x => x.Id == section.CourseId).FirstOrDefault();
            if (course == null)
            {
                throw new Exception("Course with specified id does not exist");
            }
            if (course.UserId != userId)
            {
                throw new Exception("Unauthorized");
            }
        }

        private bool IsHidden(int infoPageId, int userId)
        {
            InfoPage? infoPage = dbContext.InfoPages.Where(x => x.Id == infoPageId).FirstOrDefault();
            if (infoPage == null)
            {
                throw new Exception("This info page does not exist");
            }
            Section? section = dbContext.Sections.Where(x => x.Id == infoPage.SectionId).FirstOrDefault();
            if (section == null)
            {
                throw new Exception("The associated section does not exist");
            }
            Course? course = dbContext.Courses.Where(x => x.Id == section.CourseId).FirstOrDefault();
            if (course == null)
            {
                throw new Exception("The associated course does not exist");
            }
            if (course.IsDeleted)
            {
                return true;
            }
            return (infoPage.IsHidden || section.IsHidden || course.IsHidden) && userId != course.UserId;
        }
    }
}