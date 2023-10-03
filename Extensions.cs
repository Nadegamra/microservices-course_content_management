using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseContentManagement
{
    public static class Utils
    {
        public static int GetUserId(this ControllerBase controllerBase)
        {
            return Convert.ToInt32(controllerBase.HttpContext.User.Claims.Where(x => x.Type == "UserId").First().Value);
        }
    }
}