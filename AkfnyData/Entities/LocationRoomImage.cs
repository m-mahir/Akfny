//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Entities
{
    using Data.ViewModels;
    using System;
    using System.Collections.Generic;
    
    public partial class LocationRoomImage : Entity<int>
    {
       
        public int? LocationRoomId { get; set; }
        public virtual LocationRoom LocationRoom { get; set; }
        public byte[] RoomImage { get; set; }
        public int? ProviderId { get; set; }
    
    }
}
