using CourseContentManagement.Data.DTOs.Section;
using CourseContentManagement.Data.Models;
using CourseContentManagement.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseContentManagement.Controllers
{
    [ApiController]
    [Route("/courses/{courseId}/sections/")]
    public class SectionsController : ControllerBase
    {
        private readonly SectionsHandler handler;

        public SectionsController(SectionsHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Section>>> GetSectionList(int courseId)
        {

            int? userId = this.IsAuthed() ? this.GetUserId() : null;
            List<Section> sections = handler.GetSectionList(courseId, userId);

            return Ok(sections);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Section?>> GetSection(int courseId, int id)
        {
            int? userId = this.IsAuthed() ? this.GetUserId() : null;
            Section section = handler.GetSection(courseId, id, userId);

            return Ok(section);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<Section>> AddSection(int courseId, SectionAddRequest req)
        {
            var result = await handler.AddSectionAsync(courseId, req, this.GetUserId());
            return Created($"/courses/{courseId}/sections/{result.Id}", result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<Section>> UpdateSection(int courseId, int id, SectionUpdateRequest req)
        {
            return Ok(await handler.UpdateSectionAsync(courseId, id, req, this.GetUserId()));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<bool>> DeleteSection(int courseId, int id)
        {
            bool result = await handler.DeleteSectionAsync(courseId, id, this.GetUserId());
            return result ? NoContent() : NotFound();
        }
    }
}