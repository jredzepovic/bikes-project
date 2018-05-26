using System.Collections.Generic;
using System.Linq;
using bikes_project.Models;
using bikes_project.Data;
using System;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace bikes_project.Services
{
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public EmailService(IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            this._configuration = configuration;
        }

        public void SendAdvertAddEmail(string emailAddress, Bike model)
        {
            using (SmtpClient client = new SmtpClient()
            {
                Port = 587,
                Host = "smtp.live.com",
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(_configuration["Mail:Address"], _configuration["Mail:Password"])
            })
            {
                string messageSubject = "Dodavanje oglasa";
                string messageBody = $"Oglas \"{model.Name}\" je uspješno predan.";

                MailMessage mm = new MailMessage(_configuration["Mail:Address"], emailAddress, messageSubject, messageBody);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
            }
        }
    }
}
