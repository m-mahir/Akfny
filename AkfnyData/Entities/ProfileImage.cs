using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Entities
{
    public class ProfileImage : Entity<int>
    {
    
        public string Photograph { get; set; }

        public string Photograph2 { get; set; }

    }
}