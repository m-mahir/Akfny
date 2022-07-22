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
    using System.ComponentModel.DataAnnotations;

    public partial class LocationRoom : Entity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LocationRoom()
        {
            this.LocationRoomImages = new HashSet<LocationRoomImage>();
            this.CSLocations = new HashSet<CSLocation>();
            this.CSLocation_Temp = new HashSet<CSLocation_Temp>();
            this.CourseProffers = new HashSet<CourseProffer>();
        }
       
        public string RoomName { get; set; }
        public int? CapacityFrom { get; set; }
        public int? CapacityTo { get; set; }
        public string Ranking { get; set; }
        public int? locId { get; set; }
        public string Cafe { get; set; }
        public string RoomOrder { get; set; }
        public string Shape { get; set; }
        public string RoomView { get; set; }
        public Nullable<decimal> RoomPrice { get; set; }
        public int? ProviderId { get; set; }
    
        public virtual CoordinatorLocation CoordinatorLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LocationRoomImage> LocationRoomImages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CSLocation> CSLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CSLocation_Temp> CSLocation_Temp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseProffer> CourseProffers { get; set; }
    }
}
