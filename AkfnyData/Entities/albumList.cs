
namespace Data.Entities
{
    using Data.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class albumList : Entity<int>
    {
        public int? albumId { get; set; }
        public virtual album album { get; set; }
        public byte[] albumImg { get; set; }
        public string albumImgDescription { get; set; }
        public Nullable<int> InsertCode { get; set; }
    
    }
}
