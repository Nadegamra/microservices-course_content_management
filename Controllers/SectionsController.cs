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
        public async Task<ActionResult<List<Section>>> GetSectionList([FromQuery] int courseId)
        {
            try
            {
                return new OkObjectResult(await handler.GetSectionListAsync(courseId, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<Section>> AddSection(SectionAddRequest req)
        {
            try
            {
                return new OkObjectResult(await handler.AddSectionAsync(req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<Section>> UpdateSection(SectionUpdateRequest req)
        {
            try
            {
                return new OkObjectResult(await handler.UpdateSectionAsync(req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<bool>> DeleteSection([FromQuery] int Id)
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