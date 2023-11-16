using CourseContentManagement.Data.DTOs.Section;
using CourseContentManagement.Data.Models;
using CourseContentManagement.Data.Repositories;
using CourseContentManagement.Exceptions;

namespace CourseContentManagement.Handlers
{
    public class SectionsHandler
    {
        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<Section> repository;
        private readonly CoursesHandler coursesHandler;

        public SectionsHandler(IRepository<Section> repository, CoursesHandler coursesHandler, IRepository<Course> courseRepository)
        {
            this.repository = repository;
            this.coursesHandler = coursesHandler;
            this.courseRepository = courseRepository;
        }

        public Section GetSection(int courseId, int sectionId, int? userId = null)
        {
            CheckSectionValidity(courseId, sectionId, userId);
            return repository.Get(sectionId);

        }

        public List<Section> GetSectionList(int courseId, int? userId = null)
        {
            coursesHandler.CheckCourseValidity(courseId, userId);
            var course = courseRepository.Get(courseId);

            if (userId == null || course.UserId != userId)
            {
                return repository.GetAll()
                        .Where(x => x.CourseId == courseId && !x.IsHidden)
                        .ToList();
            }
            else
            {
                return repository.GetAll()
                        .Where(x => x.CourseId == courseId)
                        .ToList();
            }
        }


        public async Task<Section> AddSectionAsync(int courseId, SectionAddRequest req, int userId)
        {
            coursesHandler.CheckCourseValidity(courseId, userId);

            Section section = req.ToEntity(courseId);
            var res = repository.Add(section);
            return res;
        }

        public async Task<Section> UpdateSectionAsync(int courseId, int sectionId, SectionUpdateRequest req, int userId)
        {
            CheckSectionValidity(courseId, sectionId, userId);
            Section original = repository.Get(sectionId);

            Section updated = req.UpdateEntity(original);

            var res = repository.Update(updated);
            return res;
        }

        public async Task<bool> DeleteSectionAsync(int courseId, int id, int userId)
        {
            CheckSectionValidity(courseId, id, userId);
            Section section = repository.Get(id);

            repository.Delete(section);
            return true;
        }

        public void CheckSectionValidity(int courseId, int sectionId, int? userId = null)
        {
            coursesHandler.CheckCourseValidity(courseId, userId);
            var course = courseRepository.Get(courseId);

            Section? section = repository.Get(sectionId);
            if (section == null || (section.IsHidden && (userId == null && userId != course.UserId)))
            {
                throw new NotFoundEntityException("section", sectionId);
            }
            if (section.CourseId != courseId)
            {
                throw new InvalidIdChainException("course", courseId, "section", sectionId);
            }
        }
    }
}