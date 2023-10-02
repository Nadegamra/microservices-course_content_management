using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CourseContentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseSectionsController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<string>> GetSectionsList()
        {
            return "Result";
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<string>> AddSection()
        {
            return "Result";
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN, CREATOR")]
        public async Task<ActionResult<string>> UpdateSection()
        {
            return "Result";
        }
    }
}