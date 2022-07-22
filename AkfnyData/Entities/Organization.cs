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

    public partial class Organization : Entity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organization()
        {
            this.OrganizationOfficers = new HashSet<OrganizationOfficer>();
            this.OrganizationCourseRequests = new HashSet<OrganizationCourseRequest>();
        }
      
        public string OrgName { get; set; }
        public string OrgType { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public string ResponsibleManagement { get; set; }
        public string ManagerName { get; set; }
        public string Jawal { get; set; }
        public string Email { get; set; }
        public byte[] CR { get; set; }
        public string Password { get; set; }
        public string Headquarters { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsSuspend { get; set; }
        public bool? IsDeleted { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public string RegistrationTime { get; set; }
        public string InvitationCode { get; set; }
        public byte[] Photograph { get; set; }
        public bool? Auth { get; set; }
        public bool? InfoUpdate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationOfficer> OrganizationOfficers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationCourseRequest> OrganizationCourseRequests { get; set; }
    }
}