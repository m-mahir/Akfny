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

    public partial class RegistrationCourseProffer : Entity<int>
    {
       
        public Nullable<int> CourseProfferId { get; set; }
        public Nullable<int> TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public string RegistrationDate { get; set; }
        public string PaymentTime { get; set; }
        public Nullable<bool> IsPayment { get; set; }
        public string PaymentType { get; set; }
        public Nullable<int> PaymentId { get; set; }
        public string PaymentIdType { get; set; }
        public string PaymentDate { get; set; }
        public string RegistrationTime { get; set; }
        public string Note { get; set; }
        public decimal? PaymentPrice { get; set; }
        public decimal? PaymentDiscount { get; set; }
        public decimal? PaymentTotal { get; set; }
        public string PriceType { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TotalPriceTax { get; set; }
        public decimal? PriceAfertDiscount { get; set; }
        public byte[] PaymentImg { get; set; }
    
        public virtual CourseProffer CourseProffer { get; set; }
    }
}