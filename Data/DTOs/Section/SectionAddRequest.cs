using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseContentManagement.Data.DTOs.Section
{
    public class SectionAddRequest
    {
        [FromQuery]
        public int CourseId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}