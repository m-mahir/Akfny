using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Entities
{
    public class Payment_Invoice : Entity<int>
    {
      
        public int RegistrationId { get; set; }
        public string Name { get; set; }
        public string TraineeAddress { get; set; }
        public string TraineeJawwal { get; set; }

        public string CourseTitle { get; set; }

        public string CourseAdress { get; set; }

        public string CourseDateTime { get; set; }

        public decimal? CoursePrice { get; set; }
        public decimal? TotalTax { get; set; }
               
        public decimal? TotalWithTax { get; set; }

        public string InvoiceNum { get; set; }

        public string InvoiceDate { get; set; }

        public string PaymentInvoiceDate { get; set; }
        public string note { get; set; }
        public string PaymentType { get; set; }
        public decimal? Tax { get; set; }
        public decimal? disValue { get; set; }
        public decimal? PaymentDiscount { get; set; }
        public decimal? TotalPriceTax { get; set; }
        public decimal? PriceAfertDiscount { get; set; }

        public string PaymentImg { get; set; }

        public bool IsImage { get; set; }
    }
}