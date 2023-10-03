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

        [HttpGet("getList")]
        [AllowAnonymous]
        public async Task<ActionResult<List<InfoPage>>> GetInfoPageList([FromQuery] int sectionId)
        {
            try
            {
                return new OkObjectResult(await handler.GetInfoPageListAsync(sectionId, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<InfoPage>> AddInfoPage(InfoPageAddRequest req)
        {
            try
            {
                return new OkObjectResult(await handler.AddInfoPageAsync(req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<InfoPage>> UpdateInfoPage(InfoPageUpdateRequest req)
        {
            try
            {
                return new OkObjectResult(await handler.UpdateInfoPageAsync(req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<bool>> DeleteInfoPage([FromQuery] int Id)
        {
            try
            {
                return new OkObjectResult(await handler.DeleteInfoPageAsync(Id, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}