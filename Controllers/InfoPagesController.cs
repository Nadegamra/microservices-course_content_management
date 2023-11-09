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
            try
            {
                int userId = -1;
                try
                {
                    userId = this.GetUserId();
                    return Ok(await handler.GetUserInfoPageListAsync(courseId, sectionId, this.GetUserId()));
                }
                catch
                {
                    return Ok(await handler.GetInfoPageListAsync(courseId, sectionId));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<InfoPage>>> GetInfoPage(int courseId, int sectionId, int id)
        {
            try
            {
                int userId = -1;
                try
                {
                    userId = this.GetUserId();
                    return Ok(await handler.GetUserInfoPageAsync(courseId, sectionId, id, userId));
                }
                catch
                {
                    return Ok(await handler.GetInfoPageAsync(courseId, sectionId, id));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<InfoPage>> AddInfoPage(int courseId, int sectionId, InfoPageAddRequest req)
        {
            try
            {
                var result = await handler.AddInfoPageAsync(sectionId, req, this.GetUserId());
                return Created($"/courses/{courseId}/sections/{sectionId}/infoPages/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<InfoPage>> UpdateInfoPage(int id, InfoPageUpdateRequest req)
        {
            try
            {
                return Ok(await handler.UpdateInfoPageAsync(id, req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<bool>> DeleteInfoPage(int id)
        {
            try
            {
                bool result = await handler.DeleteInfoPageAsync(id, this.GetUserId());
                return result ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}