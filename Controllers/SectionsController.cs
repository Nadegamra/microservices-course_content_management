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

        [HttpGet("getList")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Section>>> GetSectionList(int courseId)
        {
            try
            {
                return new OkObjectResult(await handler.GetSectionListAsync(courseId));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        [HttpGet("getList/owned")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<List<Section>>> GetUserSectionList(int courseId)
        {
            try
            {
                return new OkObjectResult(await handler.GetUserSectionListAsync(courseId, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<Section>> AddSection(int courseId, SectionAddRequest req)
        {
            try
            {
                return new OkObjectResult(await handler.AddSectionAsync(courseId, req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<Section>> UpdateSection(int courseId, int id, SectionUpdateRequest req)
        {
            try
            {
                return new OkObjectResult(await handler.UpdateSectionAsync(courseId, id, req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<bool>> DeleteSection(int Id)
        {
            try
            {
                return new OkObjectResult(await handler.DeleteSectionAsync(Id, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}