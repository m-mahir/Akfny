using AkfnyServices.Model;
using Data.Entities;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AkfnyServices.Helper
{
    public class SendEmails
    {
        readonly private IRepository<EmailsLog, int> _emailsLogRepository;
        private readonly MailSettings _mailSettings;
        public SendEmails(MailSettings mailSettings, IRepository<EmailsLog, int> emailsLogRepository)
        {
            _emailsLogRepository = emailsLogRepository;
            _mailSettings = mailSettings;
        }

        private bool RemoteServerCertificateValidationCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public void Send_RegistrationMarket(Trainer trainer)
        {
            try
            {
                string html = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "/Emails/RegistrationMarket.html");

                string subject = "تسجيل متدرب جديد - منصة أكفني";
                string name = "إسم المتدرب : " + trainer.TrainerFname + " " + trainer.TrainerSname + " " + trainer.TrainerTname + " " + trainer.TrainerLname;

                html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
                html = html.Replace("{Name}", name);

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info@akfeny.com");
                msg.To.Add(new MailAddress("marketing@akfeny.com"));
                //msg.CC.Add(new MailAddress("ghena@suqur.org"));
                msg.Bcc.Add(new MailAddress("emaznm@hotmail.com"));
                msg.Subject = subject;
                msg.IsBodyHtml = true;

                msg.Body = html;
                //{ForwardNote}
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                SmtpClient client = new SmtpClient(_mailSettings.Host, _mailSettings.Port);
                client.Credentials = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;

                EmailsLog log = new EmailsLog();
                log.Date = DateTime.Now.AddHours(10);
                log.Send = "إشعار تسجيل متدرب جديد";
                log.SendBy = "SYS";
                log.SendById = 0;
                log.time = DateTime.Now.AddHours(10).ToShortTimeString();
                log.SendTo = "marketing@akfeny.com";
                log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
                log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
                log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
                _emailsLogRepository.Add(log);

                client.Send(msg);
            }
            catch (Exception ex)
            {

            }
        }

        public void Send_RegistrationTrainer(Trainer trainer, string Pass)
        {
            try
            {
                string html = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "/Emails/RegistrationTraineeSys.html");

                string subject = "شكرا للتسجيل - منصة أكفني";
                string name = "عزيزي المتدرب : " + trainer.TrainerFname + " " + trainer.TrainerSname + " " + trainer.TrainerTname + " " + trainer.TrainerLname;

                html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
                html = html.Replace("{Name}", name);
                html = html.Replace("{Usenamer}", trainer.Email1);
                html = html.Replace("{Password}", Pass);

                //{ForwardNote}
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                SmtpClient client = new SmtpClient(_mailSettings.Host, _mailSettings.Port);
                client.Credentials = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info@akfeny.com");
                msg.To.Add(new MailAddress(trainer.Email1));

                msg.Subject = subject;
                msg.IsBodyHtml = true;

                msg.Body = html;

                EmailsLog log = new EmailsLog();
                log.Date = DateTime.Now.AddHours(10);
                log.Send = "شكرا للتسجيل - متدرب";
                log.SendBy = "SYS";
                log.SendById = 0;
                log.time = DateTime.Now.AddHours(10).ToShortTimeString();
                log.SendTo = trainer.Email1;
                log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
                log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
                log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
                _emailsLogRepository.Add(log);

                client.Send(msg);
            }
            catch (Exception ex)
            {

            }
        }

        public void Send_RegistrationLecturer(Lecturer lecturer)
        {
            try
            {
                string html = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "/Emails/Registration.html");

                string subject = "شكرا للتسجيل - منصة أكفني";
                string name = "نشكرك عزيزي المدرب : " + lecturer.LecturerFname + " " + lecturer.LecturerSname + " " + lecturer.LecturerTname + " " + lecturer.LecturerLname;

                html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
                html = html.Replace("{Name}", name);

                //{ForwardNote}
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                SmtpClient client = new SmtpClient(_mailSettings.Host, _mailSettings.Port);
                client.Credentials = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info@akfeny.com");
                msg.To.Add(new MailAddress(lecturer.Email1));

                msg.Subject = subject;
                msg.IsBodyHtml = true;

                msg.Body = html;

                EmailsLog log = new EmailsLog();
                log.Date = DateTime.Now.AddHours(10);
                log.Send = "شكرا للتسجيل - مدرب";
                log.SendBy = "SYS";
                log.SendById = 0;
                log.time = DateTime.Now.AddHours(10).ToShortTimeString();
                log.SendTo = lecturer.Email1;
                log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
                log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
                log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
                _emailsLogRepository.Add(log);
                client.Send(msg);
            }
            catch (Exception)
            {

            }
        }

        public void Send_RegistrationPMP(Lecturer lecturer)
        {
            try
            {
                string html = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "/Emails/RegistrationPMP.html");

                string subject = "تسجيل مدرب جديد - منصة أكفني";
                string text = "اشعار بتسجيل مدرب";
                string name = "إسم المدرب : " + lecturer.LecturerFname + " " + lecturer.LecturerSname + " " + lecturer.LecturerTname + " " + lecturer.LecturerLname;

                html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
                html = html.Replace("{Name}", name);
                html = html.Replace("{text}", text);

                //{ForwardNote}
                System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
                SmtpClient client = new SmtpClient(_mailSettings.Host, _mailSettings.Port);
                client.Credentials = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info@akfeny.com");
                msg.To.Add(new MailAddress("ahmed@akfeny.com"));
                msg.CC.Add(new MailAddress("ejs@akfeny.com"));
                msg.Bcc.Add(new MailAddress("emaznm@hotmail.com"));
                msg.Subject = subject;
                msg.IsBodyHtml = true;

                msg.Body = html;

                EmailsLog log = new EmailsLog();
                log.Date = DateTime.Now.AddHours(10);
                log.Send = "إشعار تسجيل مدرب جديد";
                log.SendBy = "SYS";
                log.SendById = 0;
                log.time = DateTime.Now.AddHours(10).ToShortTimeString();
                log.SendTo = "ahmed@akfeny.com";
                log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
                log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
                log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
                _emailsLogRepository.Add(log);
                
                client.Send(msg);
            }
            catch (Exception)
            {

            }
        }

        //public void Send_Forward(int CourseProfferId, string FordwardType, string type, int typeId, string email, string subject, string note)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/Forward.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        CourseProffer cp = db.CourseProffers.SingleOrDefault(x => x.CourseProfferId == CourseProfferId);
        //        string ForwardName = "";
        //        if (type == "F")
        //        {
        //            Finance f = db.Finances.SingleOrDefault(x => x.FinanceId == typeId);
        //            ForwardName = f.FinanceName;
        //        }

        //        else if (type == "P")
        //        {
        //            PMP p = db.PMPs.SingleOrDefault(x => x.PMPId == typeId);
        //            ForwardName = p.PMPName;
        //        }
        //        else if (type == "G")
        //        {
        //            GM g = db.GMs.SingleOrDefault(x => x.GMId == typeId);
        //            ForwardName = g.GMName;
        //        }
        //        else
        //        {
        //            ForwardName = "غير محدد";
        //        }
        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{CourseName}", cp.Course.CourseTxt);
        //        html = html.Replace("{CourseNum}", CourseProfferId.ToString("D4"));
        //        html = html.Replace("{CourseType}", FordwardType);
        //        html = html.Replace("{CourseDateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{LecturerName}", cp.Lecturer.LecturerFname + " " + cp.Lecturer.LecturerSname + " " + cp.Lecturer.LecturerTname + " " + cp.Lecturer.LecturerLname);
        //        html = html.Replace("{ForwardDateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{ForwardName}", ForwardName);
        //        html = html.Replace("{ForwardNote}", note);
        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "طلب إعادة توجيه";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_Remember(int CourseProfferId, string FordwardType, string type, int typeId, string email, string subject)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/Remember.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        CourseProffer cp = db.CourseProffers.SingleOrDefault(x => x.CourseProfferId == CourseProfferId);
        //        string ForwardName = "";
        //        if (type == "F")
        //        {
        //            Finance f = db.Finances.SingleOrDefault(x => x.FinanceId == typeId);
        //            ForwardName = f.FinanceName;
        //        }
        //        else if (type == "P")
        //        {
        //            PMP p = db.PMPs.SingleOrDefault(x => x.PMPId == typeId);
        //            ForwardName = p.PMPName;
        //        }
        //        else if (type == "G")
        //        {
        //            GM g = db.GMs.SingleOrDefault(x => x.GMId == typeId);
        //            ForwardName = g.GMName;
        //        }
        //        else
        //        {
        //            ForwardName = "غير محدد";
        //        }
        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{CourseName}", cp.Course.CourseTxt);
        //        html = html.Replace("{CourseNum}", CourseProfferId.ToString("D4"));
        //        html = html.Replace("{CourseType}", FordwardType);
        //        html = html.Replace("{CourseDateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{LecturerName}", cp.Lecturer.LecturerFname + " " + cp.Lecturer.LecturerSname + " " + cp.Lecturer.LecturerTname + " " + cp.Lecturer.LecturerLname);

        //        html = html.Replace("{ForwardName}", ForwardName);

        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "رسالة تذكير";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)

        //    {


        //    }

        //}

        //public void Send_Active(string Name, string Usenamer, string Password, string subject)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/ActiveAccount.html"));
        //        SoqurEntities1 db = new SoqurEntities1();

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{Name}", Name);
        //        html = html.Replace("{Usenamer}", Usenamer);
        //        html = html.Replace("{Password}", Password);
        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Usenamer));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "تفعيل حساب مدرب";
        //        log.SendBy = "PMP";
        //        log.SendById = 1;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Usenamer;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)

        //    {


        //    }

        //}
        //public void Send_Active_Org(string Name, string Usenamer, string Password, string subject)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/ActiveAccountOrg.html"));
        //        SoqurEntities1 db = new SoqurEntities1();

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{Name}", Name);
        //        html = html.Replace("{Usenamer}", Usenamer);
        //        html = html.Replace("{Password}", Password);
        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Usenamer));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "تفعيل حساب مدير تدريب";
        //        log.SendBy = "PMP";
        //        log.SendById = 1;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Usenamer;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)

        //    {


        //    }

        //}
        //public void Send_Active_SectorSupervisor(string Name, string Usenamer, string Password, string subject)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/ActiveSectorSupervisor.html"));
        //        SoqurEntities1 db = new SoqurEntities1();

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{Name}", Name);
        //        html = html.Replace("{Usenamer}", Usenamer);
        //        html = html.Replace("{Password}", Password);
        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Usenamer));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "تفعيل حساب مشرف قطاع";
        //        log.SendBy = "PMP";
        //        log.SendById = 1;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Usenamer;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)

        //    {


        //    }

        //}
        //public void Send_InquiryReplay(string Name, string InquirySubject, string InquiryMsg, string InquiryReplay, string Email)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/InquiryReplay.html"));
        //        SoqurEntities1 db = new SoqurEntities1();

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{Name}", Name);
        //        html = html.Replace("{InquirySubject}", InquirySubject);
        //        html = html.Replace("{InquiryMsg}", InquiryMsg);
        //        html = html.Replace("{InquiryReplay}", InquiryReplay);
        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Email));

        //        msg.Subject = "رد على استفساراتكم";
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "رد على استفساراتكم";
        //        log.SendBy = "PMP";
        //        log.SendById = 1;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)

        //    {


        //    }

        //}

        //public void Send_CourseInquiryReplay(string Name, string InquirySubject, string InquiryMsg, string InquiryReplay, string Email, string CourseTxt)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/CourseInquiryReplay.html"));
        //        SoqurEntities1 db = new SoqurEntities1();

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{CourseTxt}", CourseTxt);
        //        html = html.Replace("{Name}", Name);
        //        html = html.Replace("{InquirySubject}", InquirySubject);
        //        html = html.Replace("{InquiryMsg}", InquiryMsg);
        //        html = html.Replace("{InquiryReplay}", InquiryReplay);
        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Email));

        //        msg.Subject = "رد على استفساراتكم بخصوص الدورات التدريبية";
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "رد على استفساراتكم بخصوص الدورات التدريبية";
        //        log.SendBy = "PMP";
        //        log.SendById = 1;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_SpecialTrainingReplay(string Name, string Subject, string Note, string NoteReplay, string Email)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/SpecialTrainingReplay.html"));
        //        SoqurEntities1 db = new SoqurEntities1();

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{Subject}", Subject);
        //        html = html.Replace("{Name}", Name);
        //        html = html.Replace("{Note}", Note);
        //        html = html.Replace("{NoteReplay}", NoteReplay);

        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Email));

        //        msg.Subject = "رد على طلب تدريب موجه - منصة أكفني";
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "رد على طلب تدريب موجه";
        //        log.SendBy = "PMP";
        //        log.SendById = 1;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)
        //    {


        //    }

        //}
        //public void Send_ProfferRequest(int CourseProfferId)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/ProfferRequest.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        CourseProffer cp = db.CourseProffers.SingleOrDefault(x => x.CourseProfferId == CourseProfferId);

        //        string subject = "اشعار بوجود طلب تقديم دورة جديد";
        //        GM g = db.GMs.Where(x => x.CityId == cp.CityId).First();
        //        PMP p = db.PMPs.Where(x => x.CityId == cp.CityId).First();
        //        Finance f = db.Finances.Where(x => x.CityId == cp.CityId).First();
        //        Coordinator c = db.Coordinators.SingleOrDefault(x => x.CityId == cp.CityId && x.IsActive == true && x.IsSuspend == false && x.IsDeleted == false);

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{CourseName}", cp.Course.CourseTxt);
        //        html = html.Replace("{CourseNum}", CourseProfferId.ToString("D4"));
        //        html = html.Replace("{CourseType}", "طلب تقديم دورة");
        //        html = html.Replace("{CourseDateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{LecturerName}", cp.Lecturer.LecturerFname + " " + cp.Lecturer.LecturerSname + " " + cp.Lecturer.LecturerTname + " " + cp.Lecturer.LecturerLname);



        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(c.Email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "طلب تقديم دورة";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = c.Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);

        //        MailMessage msg2 = new MailMessage();
        //        msg2.From = new MailAddress("info@akfeny.com");
        //        msg2.To.Add(new MailAddress(f.FinanceUserName));

        //        msg2.Subject = subject;
        //        msg2.IsBodyHtml = true;

        //        msg2.Body = html;


        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "طلب تقديم دورة";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = f.FinanceUserName;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);

        //        db.SaveChanges();

        //        client.Send(msg2);

        //        MailMessage msg3 = new MailMessage();
        //        msg3.From = new MailAddress("info@akfeny.com");
        //        msg3.To.Add(new MailAddress(p.PMPUserName));

        //        msg3.Subject = subject;
        //        msg3.IsBodyHtml = true;

        //        msg3.Body = html;

        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "طلب تقديم دورة";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = p.PMPUserName;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);

        //        db.SaveChanges();
        //        client.Send(msg3);

        //        MailMessage msg4 = new MailMessage();
        //        msg4.From = new MailAddress("info@akfeny.com");
        //        msg4.To.Add(new MailAddress(g.GMUserName));

        //        msg4.Subject = subject;
        //        msg4.IsBodyHtml = true;

        //        msg4.Body = html;

        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "طلب تقديم دورة";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = g.GMUserName;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();
        //        client.Send(msg4);
        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_OrganizationRegistrationPMP(int OrgId)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/RegistrationPMP.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Organization cp = db.Organizations.SingleOrDefault(x => x.OrgId == OrgId);

        //        string subject = "تسجيل حساب مدير تدريب جديد - منصة أكفني";
        //        string name = "السادة : " + cp.OrgName;
        //        string text = "اشعار بتسجيل مدير تدريب";

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Name}", name);
        //        html = html.Replace("{text}", text);



        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress("ahmed@akfeny.com"));
        //        msg.CC.Add(new MailAddress("ejs@akfeny.com"));
        //        msg.Bcc.Add(new MailAddress("emaznm@hotmail.com"));
        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "إشعار تسجيل مدير تدريب جديد";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = "ahmed@akfeny.com";
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_Invite(int TrainerId, string Email)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/InviteEmail.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Trainer cp = db.Trainers.SingleOrDefault(x => x.TrainerId == TrainerId);
        //        string EId = EncryptionHelper.Encrypt(Convert.ToString(cp.TrainerId));
        //        string ECode = EncryptionHelper.Encrypt(cp.InvitationCode);
        //        //string EId2 = System.Web.HttpUtility.UrlEncode(EId);
        //        //string ECode2 = System.Web.HttpUtility.UrlEncode(EId);
        //        string link = "https://www.suqur.org/Trainee/InviteRegistration?Cid=" + ECode + "&Tid=" + EId;
        //        string ELink = System.Web.HttpUtility.UrlEncode(link);
        //        string Name = cp.TrainerFname + " " + cp.TrainerSname + " " + cp.TrainerTname + " " + cp.TrainerLname;
        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{InviteName}", Name);
        //        html = html.Replace("{Link}", link);

        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Email));

        //        msg.Subject = "دعوة من صديق - منصة أكفني";
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "دعوة صديق";
        //        log.SendBy = "TRE";
        //        log.SendById = TrainerId;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)

        //    {


        //    }

        //}

        //public void Send_Invite_Organization(int OrgId, int OfficerId, string Email, string EmailFrom)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/OrganizationInviteEmail.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Organization cp = db.Organizations.SingleOrDefault(x => x.OrgId == OrgId);
        //        string EId = EncryptionHelper.Encrypt(Convert.ToString(cp.OrgId));
        //        string ECode = EncryptionHelper.Encrypt(cp.InvitationCode);
        //        string OFid = EncryptionHelper.Encrypt(Convert.ToString(OfficerId));

        //        //string EId2 = System.Web.HttpUtility.UrlEncode(EId);
        //        //string ECode2 = System.Web.HttpUtility.UrlEncode(EId);
        //        string link = "https://www.suqur.org/Trainee/OrgInviteRegistration?Cid=" + ECode + "&Oid=" + EId + "&OFid=" + OFid;
        //        string ELink = System.Web.HttpUtility.UrlEncode(link);
        //        string Name = cp.OrgName;
        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{InviteName}", Name);
        //        html = html.Replace("{Link}", link);
        //        html = html.Replace("{Email}", EmailFrom);
        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Email));

        //        msg.Subject = "دعوة من : " + cp.OrgName + " - منصة أكفني";
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "دعوة متدرب";
        //        log.SendBy = "ORG";
        //        log.SendById = OrgId;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)

        //    {


        //    }

        //}
        //public void Send_Invite_Lecturer(int LecturerId, string Email)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/LecturerInviteEmail.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Lecturer cp = db.Lecturers.SingleOrDefault(x => x.LecturerId == LecturerId);
        //        string EId = EncryptionHelper.Encrypt(Convert.ToString(cp.LecturerId));
        //        string ECode = EncryptionHelper.Encrypt(cp.InvitationCode);
        //        //string EId2 = System.Web.HttpUtility.UrlEncode(EId);
        //        //string ECode2 = System.Web.HttpUtility.UrlEncode(EId);
        //        string link = "https://www.suqur.org/Trainer/InviteRegistration?Cid=" + ECode + "&Tid=" + EId;
        //        string ELink = System.Web.HttpUtility.UrlEncode(link);
        //        string Name = cp.LecturerFname + " " + cp.LecturerSname + " " + cp.LecturerTname + " " + cp.LecturerLname;
        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{InviteName}", Name);
        //        html = html.Replace("{Link}", link);

        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Email));

        //        msg.Subject = "دعوة من صديق - منصة أكفني";
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "دعوة صديق";
        //        log.SendBy = "LEC";
        //        log.SendById = LecturerId;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)

        //    {


        //    }

        //}
        //public void Send_CourseSend(int CourseProfferId)
        //{
        //    //string data="1";
        //    try
        //    {
        //        //string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/CourseSend.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        List<SelectedLecturer> cp = db.SelectedLecturers.Where(x => x.CourseProfferId == CourseProfferId).ToList();

        //        string subject = "طلب تقديم دورة - منصة أكفني";

        //        string EmailTo = "", LectureName = "", CourseTxt = "", html = "";
        //        foreach (var item in cp)
        //        {
        //            html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/CourseSend.html"));

        //            LectureName = item.Lecturer.LecturerFname + " " + item.Lecturer.LecturerSname + " " + item.Lecturer.LecturerTname + " " + item.Lecturer.LecturerLname;

        //            CourseTxt = item.Course.CourseTxt;
        //            html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //            html = html.Replace("{LectureName}", LectureName);
        //            html = html.Replace("{CourseTxt}", CourseTxt);
        //            EmailTo = item.Lecturer.Email1;

        //            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //            SmtpClient client = new SmtpClient();
        //            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            client.EnableSsl = false;

        //            MailMessage msg = new MailMessage();
        //            msg.From = new MailAddress("info@akfeny.com");
        //            msg.To.Add(new MailAddress(EmailTo));
        //            msg.Bcc.Add(new MailAddress("emaznm@hotmail.com"));
        //            msg.Subject = subject;
        //            msg.IsBodyHtml = true;

        //            msg.Body = html;

        //            EmailsLog log = new EmailsLog();
        //            log.Date = DateTime.Now.AddHours(10);
        //            log.Send = "طلب تقديم دورة";
        //            log.SendBy = "SYS";
        //            log.SendById = 0;
        //            log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //            log.SendTo = EmailTo;
        //            log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //            log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //            log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //            db.EmailsLogs.Add(log);

        //            db.SaveChanges();

        //            client.Send(msg);
        //        }






        //        //{ForwardNote}



        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_TaskNotification(int TaskId)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/TaskNotification.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        MyTask cp = db.MyTasks.SingleOrDefault(x => x.TaskId == TaskId);

        //        string subject = "مهمة جديده - منصة أكفني";
        //        string Task = "رقم المهمة : " + cp.TaskId + " - عنوان المهمة : " + cp.TaskSubject;

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Task}", Task);

        //        string EmailTo = "";
        //        if (cp.ToType == "P")
        //        {

        //            PMP u = db.PMPs.SingleOrDefault(x => x.PMPId == cp.TaskTo);
        //            EmailTo = u.PMPUserName;
        //        }
        //        else if (cp.ToType == "F")
        //        {

        //            Finance u = db.Finances.SingleOrDefault(x => x.FinanceId == cp.TaskTo);
        //            EmailTo = u.FinanceUserName;
        //        }
        //        else if (cp.ToType == "G")
        //        {

        //            GM u = db.GMs.SingleOrDefault(x => x.GMId == cp.TaskTo);
        //            EmailTo = u.GMUserName;
        //        }
        //        else if (cp.ToType == "M")
        //        {

        //            ContentManagement u = db.ContentManagements.SingleOrDefault(x => x.ContentManagementId == cp.TaskTo);
        //            EmailTo = u.ContentManagementEmail;
        //        }
        //        else if (cp.ToType == "A")
        //        {

        //            Admin u = db.Admins.SingleOrDefault(x => x.AdminId == cp.TaskTo);
        //            EmailTo = u.AdminEmail;
        //        }

        //        else
        //        {

        //            EmailTo = "it@akfeny.com";
        //        }


        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(EmailTo));
        //        msg.Bcc.Add(new MailAddress("emaznm@hotmail.com"));
        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "مهمة جديده";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = EmailTo;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_TaskDoneNotification(int TaskId)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/TaskDoneNotification.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        MyTask cp = db.MyTasks.SingleOrDefault(x => x.TaskId == TaskId);

        //        string subject = "مهمة تم إنجازها - منصة أكفني";
        //        string Task = "إشعار بإنجاز " + "مهمة رقم : " + cp.TaskId + " - تحت عنوان : " + cp.TaskSubject;

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Task}", Task);

        //        string EmailTo = "";
        //        if (cp.FromType == "P")
        //        {

        //            PMP u = db.PMPs.SingleOrDefault(x => x.PMPId == cp.TaskFrom);
        //            EmailTo = u.PMPUserName;
        //        }
        //        else if (cp.FromType == "F")
        //        {

        //            Finance u = db.Finances.SingleOrDefault(x => x.FinanceId == cp.TaskFrom);
        //            EmailTo = u.FinanceUserName;
        //        }
        //        else if (cp.FromType == "G")
        //        {

        //            GM u = db.GMs.SingleOrDefault(x => x.GMId == cp.TaskFrom);
        //            EmailTo = u.GMUserName;
        //        }
        //        else if (cp.FromType == "M")
        //        {

        //            ContentManagement u = db.ContentManagements.SingleOrDefault(x => x.ContentManagementId == cp.TaskFrom);
        //            EmailTo = u.ContentManagementEmail;
        //        }
        //        else if (cp.FromType == "A")
        //        {

        //            Admin u = db.Admins.SingleOrDefault(x => x.AdminId == cp.TaskFrom);
        //            EmailTo = u.AdminEmail;
        //        }

        //        else
        //        {

        //            EmailTo = "it@akfeny.com";
        //        }


        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(EmailTo));
        //        msg.Bcc.Add(new MailAddress("emaznm@hotmail.com"));
        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "مهمة تم إنجازها";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = EmailTo;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_RegistrationOrgTrainer(int TrainerId, string Pass)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/RegistrationOrgTraineeSys.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Trainer cp = db.Trainers.SingleOrDefault(x => x.TrainerId == TrainerId);

        //        string subject = "شكرا للتسجيل - منصة أكفني";
        //        string name = "عزيزي المتدرب : " + cp.TrainerFname + " " + cp.TrainerSname + " " + cp.TrainerTname + " " + cp.TrainerLname;

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Name}", name);
        //        html = html.Replace("{Usenamer}", cp.Email1);
        //        html = html.Replace("{Password}", Pass);


        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(cp.Email1));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "شكرا للتسجيل - متدرب";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = cp.Email1;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        //public void Send_RegistrationOrganization(int OrgId, string Pass)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/RegistrationOrganizationSys.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Organization cp = db.Organizations.SingleOrDefault(x => x.OrgId == OrgId);

        //        string subject = "شكرا للتسجيل - منصة أكفني";
        //        string name = "السادة : " + cp.OrgName;

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Name}", name);
        //        html = html.Replace("{Usenamer}", cp.Email);
        //        html = html.Replace("{Password}", Pass);


        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(cp.Email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "شكرا للتسجيل - حساب مؤسسي";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = cp.Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        //public void Send_PassRest(string Email, string Pass, string name)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/PassRest.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        //Trainer cp = db.Trainers.SingleOrDefault(x => x.TrainerId == TrainerId);

        //        string subject = "نسيت كلمة المرور - منصة أكفني";
        //        //string name = "عزيزي المتدرب : " + cp.TrainerFname + " " + cp.TrainerSname + " " + cp.TrainerTname + " " + cp.TrainerLname;

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Name}", name);
        //        html = html.Replace("{Usenamer}", Email);
        //        html = html.Replace("{Password}", Pass);


        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(Email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "نسيت كلمة المرور";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        //public void Send_RegistrationReminder(int TrainerId, int SendId)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/RegistrationReminder.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Trainer cp = db.Trainers.SingleOrDefault(x => x.TrainerId == TrainerId);
        //        TrainerUser tu = db.TrainerUsers.SingleOrDefault(x => x.TrainerId == TrainerId);
        //        string Pass = EncryptionHelper.Decrypt(tu.TrainerUserPassword);
        //        string subject = "إغتنم الفرصة - منصة أكفني";
        //        string name = "عزيزي المتدرب : " + cp.TrainerFname + " " + cp.TrainerSname + " " + cp.TrainerTname + " " + cp.TrainerLname;

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Name}", name);
        //        html = html.Replace("{Usenamer}", cp.Email1);
        //        html = html.Replace("{Password}", Pass);


        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(cp.Email1));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "إغتنم الفرصة";
        //        log.SendBy = "MAK";
        //        log.SendById = SendId;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = cp.Email1;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        //public void Send_RegistrationOfficerReminder(int TrainerId, int SendId)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/RegistrationReminder.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Trainer cp = db.Trainers.SingleOrDefault(x => x.TrainerId == TrainerId);
        //        TrainerUser tu = db.TrainerUsers.SingleOrDefault(x => x.TrainerId == TrainerId);
        //        string Pass = EncryptionHelper.Decrypt(tu.TrainerUserPassword);

        //        string subject = "إغتنم الفرصة - منصة أكفني";
        //        string name = "عزيزي المتدرب : " + cp.TrainerFname + " " + cp.TrainerSname + " " + cp.TrainerTname + " " + cp.TrainerLname;

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Name}", name);
        //        html = html.Replace("{Usenamer}", cp.Email1);
        //        html = html.Replace("{Password}", Pass);


        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(cp.Email1));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "إغتنم الفرصة";
        //        log.SendBy = "Officer";
        //        log.SendById = SendId;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = cp.Email1;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        //public void Send_RegistrationTrainee(int TrainerId, int SendId, string password)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/RegistrationTrainee.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Trainer cp = db.Trainers.SingleOrDefault(x => x.TrainerId == TrainerId);

        //        string subject = "تم إختيارك - منصة أكفني";
        //        string name = "عزيزي المتدرب : " + cp.TrainerFname + " " + cp.TrainerSname + " " + cp.TrainerTname + " " + cp.TrainerLname;
        //        string Msg = "يتيح لك تسجيلك معنا إدارة سجلك التدريبي وتطوير مهاراتك المهنية باختيارك الوقت والمكان والمدرب حدد اهتمامك المهني للتسجيل في أحدث الدورات التدريبية والتطويرية في قطاعك الوظيفي او مجالك المهني";
        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Name}", name);
        //        html = html.Replace("{msg}", Msg);
        //        html = html.Replace("{Usenamer}", cp.Email1);
        //        html = html.Replace("{Password}", password);


        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(cp.Email1));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "تم إختيارك";
        //        log.SendBy = "MAK";
        //        log.SendById = SendId;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = cp.Email1;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        //public void Send_RegistrationTraineeOrgOfficer(int TrainerId, int SendId, string password)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/RegistrationTrainee.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Trainer cp = db.Trainers.SingleOrDefault(x => x.TrainerId == TrainerId);

        //        string subject = "تم إختيارك - منصة أكفني";
        //        string name = "عزيزي المتدرب : " + cp.TrainerFname + " " + cp.TrainerSname + " " + cp.TrainerTname + " " + cp.TrainerLname;
        //        string Msg = "حدد إهتمامك المهني لتصلك بيانات أحدث الدورات التدريبية والتطويرية في قطاعك الوظيفي أو مجالك المهني";
        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Name}", name);
        //        html = html.Replace("{msg}", Msg);
        //        html = html.Replace("{Usenamer}", cp.Email1);
        //        html = html.Replace("{Password}", password);


        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(cp.Email1));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "تم إختيارك";
        //        log.SendBy = "Officer";
        //        log.SendById = SendId;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = cp.Email1;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        //public void Send_RegistrationCoordinator(int CoordinatorId)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/Registration.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        Coordinator cp = db.Coordinators.SingleOrDefault(x => x.CoordinatorId == CoordinatorId);

        //        string subject = "شكرا للتسجيل - منصة أكفني";
        //        string name = "نشكرك عزيزي المنسق : " + cp.CoordinatorName;

        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString() + " - " + DateTime.Now.AddHours(10).ToShortTimeString());
        //        html = html.Replace("{Name}", name);




        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(cp.Email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "شكرا للتسجيل - منسق";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = cp.Email;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);


        //    }
        //    catch (Exception)
        //    {


        //    }

        //}
        //public void Send_Authorization(string CompanyName, string TenderName, string ActivePassword, string email, string subject)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/invite.html"));



        //        html = html.Replace("{CompanyName}", CompanyName);
        //        html = html.Replace("{msg_Header}", "اشعار بطلب دخول الى شاشة العروض");
        //        html = html.Replace("{msg1}", "تحتوي هذه الرسالة على معلومات في غاية السرية");
        //        html = html.Replace("{msg2}", "موقع غير مسؤول عن اي تسريب يتم عن محتوى هذا الايميل ");
        //        html = html.Replace("{TenderName}", TenderName);
        //        html = html.Replace("{ActivePassword}", ActivePassword);

        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();

        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("emaznm@gmail.com");
        //        msg.To.Add(new MailAddress(email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;
        //        client.Send(msg);
        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_PasswordReset(string CompanyName, string UserName, string ActivePassword, string email, string subject)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/confirm.html"));



        //        html = html.Replace("{CompanyName}", CompanyName);
        //        html = html.Replace("{ActiveUserName}", UserName);
        //        html = html.Replace("{ActivePassword}", ActivePassword);

        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("emaznm@gmail.com");
        //        msg.To.Add(new MailAddress(email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;
        //        client.Send(msg);
        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_ExtendMsg(string CompanyName, string TenderName, string msg1, string msg2, string ExtendNote, string ExtendDate, string email, string subject)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/Extend.html"));



        //        html = html.Replace("{CompanyName}", CompanyName);
        //        html = html.Replace("{msg_Header}", "تمديد فترة تقديم للمناقصة");
        //        html = html.Replace("{msg1}", msg1);
        //        html = html.Replace("{msg2}", msg2);
        //        html = html.Replace("{TenderName}", TenderName);
        //        html = html.Replace("{ExtendNote}", ExtendNote);
        //        html = html.Replace("{ExtendDate}", ExtendDate);
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("emaznm@gmail.com");
        //        msg.To.Add(new MailAddress(email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;
        //        client.Send(msg);
        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_ActiveMsg(string CompanyName, string ActiveMsg, string email, string subject)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/ActiveMsg.html"));



        //        html = html.Replace("{CompanyName}", CompanyName);
        //        html = html.Replace("{ActiveMsg}", ActiveMsg);

        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("emaznm@gmail.com");
        //        msg.To.Add(new MailAddress(email));

        //        msg.Subject = subject;
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;
        //        client.Send(msg);
        //    }
        //    catch (Exception)
        //    {


        //    }

        //}

        //public void Send_ActiveOrganizationOfficer(int OfficerId, string Password)
        //{
        //    //string data="1";
        //    try
        //    {
        //        string html = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Emails/ActiveOrganizationOfficer.html"));
        //        SoqurEntities1 db = new SoqurEntities1();
        //        OrganizationOfficer o = db.OrganizationOfficers.SingleOrDefault(x => x.OfficerId == OfficerId);
        //        html = html.Replace("{DateTime}", DateTime.Now.AddHours(10).ToShortDateString());
        //        html = html.Replace("{Name}", o.OfficerName);
        //        html = html.Replace("{Usenamer}", o.OfficerEmail);
        //        html = html.Replace("{Password}", Password);
        //        html = html.Replace("{Year}", DateTime.Now.Year.ToString());
        //        //{ForwardNote}
        //        System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(RemoteServerCertificateValidationCallback);
        //        SmtpClient client = new SmtpClient();
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.EnableSsl = false;

        //        MailMessage msg = new MailMessage();
        //        msg.From = new MailAddress("info@akfeny.com");
        //        msg.To.Add(new MailAddress(o.OfficerEmail));
        //        msg.Bcc.Add(new MailAddress("emaznm@hotmail.com"));
        //        msg.Subject = "إشعار بتفعيل حساب منسق إرتباط";
        //        msg.IsBodyHtml = true;

        //        msg.Body = html;

        //        EmailsLog log = new EmailsLog();
        //        log.Date = DateTime.Now.AddHours(10);
        //        log.Send = "تفعيل حساب منسق إرتباط";
        //        log.SendBy = "SYS";
        //        log.SendById = 0;
        //        log.time = DateTime.Now.AddHours(10).ToShortTimeString();
        //        log.SendTo = o.OfficerEmail;
        //        log.SDay = Convert.ToInt32(DateTime.Now.AddHours(10).Day);
        //        log.SMonth = Convert.ToInt32(DateTime.Now.AddHours(10).Month);
        //        log.SYear = Convert.ToInt32(DateTime.Now.AddHours(10).Year);
        //        db.EmailsLogs.Add(log);
        //        db.SaveChanges();

        //        client.Send(msg);
        //    }

        //    catch (Exception)

        //    {


        //    }

        //}
    }
}
