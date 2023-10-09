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
        public async Task<ActionResult<List<InfoPage>>> GetInfoPageList(int courseId, int sectionId)
        {
            try
            {
                return new OkObjectResult(await handler.GetInfoPageListAsync(courseId, sectionId));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


        [HttpGet("getList/owned")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<List<InfoPage>>> GetUserInfoPageList(int courseId, int sectionId)
        {
            try
            {
                return new OkObjectResult(await handler.GetUserInfoPageListAsync(courseId, sectionId, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<InfoPage>> AddInfoPage(int sectionId, InfoPageAddRequest req)
        {
            try
            {
                return new OkObjectResult(await handler.AddInfoPageAsync(sectionId, req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<InfoPage>> UpdateInfoPage(int id, InfoPageUpdateRequest req)
        {
            try
            {
                return new OkObjectResult(await handler.UpdateInfoPageAsync(id, req, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<bool>> DeleteInfoPage(int id)
        {
            try
            {
                return new OkObjectResult(await handler.DeleteInfoPageAsync(id, this.GetUserId()));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}