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

    public partial class SubInterest : Entity<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubInterest()
        {
            this.CourseTargeteds = new HashSet<CourseTargeted>();
            this.CourseTargetedFinals = new HashSet<CourseTargetedFinal>();
            this.TrainerInteresteds = new HashSet<TrainerInterested>();
            this.TrainerInterestedTemps = new HashSet<TrainerInterestedTemp>();
        }
        
        public string SubInterestTxt { get; set; }
        public string E_SubInterest { get; set; }
        public Nullable<int> MajorInterestId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseTargeted> CourseTargeteds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseTargetedFinal> CourseTargetedFinals { get; set; }
        public virtual MajorInterest MajorInterest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainerInterested> TrainerInteresteds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainerInterestedTemp> TrainerInterestedTemps { get; set; }
    }
}
