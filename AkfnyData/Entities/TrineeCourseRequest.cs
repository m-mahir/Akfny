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
    
    public partial class TrineeCourseRequest : Entity<int>
    {
     
        public Nullable<int> TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public Nullable<int> CountryId { get; set; }
        public virtual Country Country { get; set; }
        public Nullable<int> CityId { get; set; }
        public virtual City City { get; set; }
        public string BookingDate { get; set; }
        public string BookingTime { get; set; }
        public Nullable<int> CourseId { get; set; }
        public virtual Course Course { get; set; }
        public string Note { get; set; }
        public string SuggestedDate { get; set; }
        public string SuggestedTime { get; set; }
        public Nullable<bool> ReqStatus { get; set; }
        public string ReqNote { get; set; }
        public string ReqDate { get; set; }
        public string ReqTime { get; set; }
    
    }
}