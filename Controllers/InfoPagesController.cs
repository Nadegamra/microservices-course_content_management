using CourseContentManagement.Data.DTOs.InfoPage;
using CourseContentManagement.Data.Models;
using CourseContentManagement.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseContentManagement.Controllers
{
    [ApiController]
    [Route("/courses/{courseId}/sections/{sectionId}/infoPages")]
    public class InfoPagesController : ControllerBase
    {
        private readonly InfoPagesHandler handler;

        public InfoPagesController(InfoPagesHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<InfoPage>>> GetInfoPageList(int courseId, int sectionId)
        {
            int? userId = this.IsAuthed() ? this.GetUserId() : null;
            List<InfoPage> infoPages = handler.GetInfoPageList(courseId, sectionId, userId);

            return Ok(infoPages);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<InfoPage>>> GetInfoPage(int courseId, int sectionId, int id)
        {
            int? userId = this.IsAuthed() ? this.GetUserId() : null;
            InfoPage infoPage = handler.GetInfoPage(courseId, sectionId, id, userId);

            return Ok(infoPage);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<InfoPage>> AddInfoPage(int courseId, int sectionId, InfoPageAddRequest req)
        {
            var result = await handler.AddInfoPageAsync(courseId, sectionId, req, this.GetUserId());
            return Created($"/courses/{courseId}/sections/{sectionId}/infoPages/{result.Id}", result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<InfoPage>> UpdateInfoPage(int courseId, int sectionId, int id, InfoPageUpdateRequest req)
        {
            return Ok(await handler.UpdateInfoPageAsync(courseId, sectionId, id, req, this.GetUserId()));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<bool>> DeleteInfoPage(int courseId, int sectionId, int id)
        {
            bool result = await handler.DeleteInfoPageAsync(courseId, sectionId, id, this.GetUserId());
            return result ? NoContent() : NotFound();
        }
    }
}