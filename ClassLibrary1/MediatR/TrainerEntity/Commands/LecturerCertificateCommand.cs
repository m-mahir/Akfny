using System;
using System.Collections.Generic;
using System.Text;

namespace AkfnyServices.MediatR.TrainerEntity.Commands
{
    public class LecturerCertificateCommand
    {
        public int Id { get; set; }
        public string LecturerCertificateImg_Base64 { get; set; }
        public string LecturerCertificateDate { get; set; }
        public int? RegistrationCode { get; set; }
        public int? LecturerId { get; set; }
        public string LecturerCertificateTital { get; set; }
    }
}
