using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseContentManagement.Data.DTOs.InfoPage
{
    public class InfoPageUpdateRequest
    {
        [FromQuery]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public bool? IsHidden { get; set; }
    }
}