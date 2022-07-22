
namespace Data.Entities
{
    using Data.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Admin :Entity<int>
    {
        
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public byte[] AdminImg { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }
    }
}
