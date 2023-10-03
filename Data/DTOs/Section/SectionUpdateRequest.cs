using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseContentManagement.Data.DTOs.Section
{
    public class SectionUpdateRequest
    {
        [FromQuery]
        public int CourseId { get; set; }
        [FromQuery]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? IsHidden { get; set; }
    }
}