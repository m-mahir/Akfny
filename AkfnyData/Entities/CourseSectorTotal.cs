using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Entities
{
    public class CourseSectorTotal : Entity<int>
    {
        public int num { get; set; }
        public string SectorTxt { get; set; }
        public int CourseTotal { get; set; }
    }
}