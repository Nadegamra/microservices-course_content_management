using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseContentManagement.Data.DTOs.InfoPage
{
    public class InfoPageAddRequest
    {
        public required int SectionId { get; set; }
        public required string Name { get; set; }
        public required string Text { get; set; }
    }
}