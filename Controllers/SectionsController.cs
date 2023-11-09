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
            try
            {
                int userId = -1;
                try
                {
                    userId = this.GetUserId();
                    return Ok(await handler.GetUserSectionListAsync(courseId, userId));
                }
                catch
                {
                    return Ok(await handler.GetSectionListAsync(courseId));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Section?>> GetSection(int courseId, int id)
        {
            try
            {
                int userId = -1;
                try
                {
                    userId = this.GetUserId();
                    var res = await handler.GetUserSectionAsync(courseId, userId, id);
                    return res != null ? Ok(res) : NotFound();
                }
                catch
                {
                    return Ok(await handler.GetSectionAsync(courseId, id));
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<Section>> AddSection(int courseId, SectionAddRequest req)
        {
            try
            {
                var result = await handler.AddSectionAsync(courseId, req, this.GetUserId());
                return Created($"/courses/{courseId}/sections/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<Section>> UpdateSection(int courseId, int id, SectionUpdateRequest req)
        {
            try
            {
                return Ok(await handler.UpdateSectionAsync(courseId, id, req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<bool>> DeleteSection(int id)
        {
            try
            {
                bool result = await handler.DeleteSectionAsync(id, this.GetUserId());
                return result ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}