using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication1.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }

    public class EmailService : IEmailService
    {
        EmailSettings _emailSettings = null;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public bool SendEmail(EmailData emailData)
        {
            try
            {
                

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(_emailSettings.EmailId, _emailSettings.Password),
                    EnableSsl = true,
                };

                smtpClient.Send("karim951369@gmail.com", emailData.EmailToId, emailData.EmailSubject, emailData.EmailBody);

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }
    }
}
