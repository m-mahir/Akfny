using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyData.Entities
{
    public class ApplicationUser :IdentityUser
    {
        public Lecturer Lecturer { get; set; }
        public int? LecturerId { get; set; }
        public Trainer Trainer { get; set; }
        public int? TrainerId { get; set; }
        public PMP PMP { get; set; }
        public int? PMPId { get; set; }
    }
}
