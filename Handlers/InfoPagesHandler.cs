using CourseContentManagement.Data.DTOs.InfoPage;
using CourseContentManagement.Data.Models;
using CourseContentManagement.Data.Repositories;
using CourseContentManagement.Exceptions;

namespace CourseContentManagement.Handlers
{
    public class InfoPagesHandler
    {
        private readonly IRepository<InfoPage> infopagesRespository;
        private readonly SectionsHandler sectionsHandler;

        public InfoPagesHandler(IRepository<InfoPage> infopagesRespository, SectionsHandler sectionsHandler)
        {
            this.infopagesRespository = infopagesRespository;
            this.sectionsHandler = sectionsHandler;
        }

        public InfoPage GetInfoPage(int courseId, int sectionId, int infoPageId, int? userId = null)
        {
            CheckInfoPageValidity(courseId, sectionId, infoPageId, userId);
            InfoPage? infoPage = infopagesRespository.Get(infoPageId);

            return infoPage;
        }

        public List<InfoPage> GetInfoPageList(int courseId, int sectionId, int? userId = null)
        {
            sectionsHandler.CheckSectionValidity(courseId, sectionId, userId);

            if (userId == null)
            {
                return infopagesRespository.GetAll()
                        .Where(x => x.SectionId == sectionId && !x.IsHidden)
                        .ToList();
            }
            else
            {
                return infopagesRespository.GetAll()
                        .Where(x => x.SectionId == sectionId)
                        .ToList();
            }
        }

        public async Task<InfoPage> AddInfoPageAsync(int courseId, int sectionId, InfoPageAddRequest req, int userId)
        {
            sectionsHandler.CheckSectionValidity(courseId, sectionId, userId);

            InfoPage infoPage = req.ToEntity(sectionId);

            var res = infopagesRespository.Add(infoPage);
            return res;
        }

        public async Task<InfoPage> UpdateInfoPageAsync(int courseId, int sectionId, int id, InfoPageUpdateRequest req, int userId)
        {
            InfoPage original = GetInfoPage(courseId, sectionId, id, userId);

            InfoPage updated = req.UpdateEntity(original);

            var res = infopagesRespository.Update(updated);
            return res;
        }

        public async Task<bool> DeleteInfoPageAsync(int courseId, int sectionId, int id, int userId)
        {
            InfoPage infoPage = GetInfoPage(courseId, sectionId, id, userId);

            infopagesRespository.Delete(infoPage);
            return true;
        }

        public void CheckInfoPageValidity(int courseId, int sectionId, int infoPageId, int? userId = null)
        {
            sectionsHandler.CheckSectionValidity(courseId, sectionId, userId);

            InfoPage? infoPage = infopagesRespository.Get(infoPageId);
            if (infoPage == null || (userId == null && infoPage.IsHidden))
            {
                throw new NotFoundEntityException("infoPage", infoPageId);
            }
        }
    }
}