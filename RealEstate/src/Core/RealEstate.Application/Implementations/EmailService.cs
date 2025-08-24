using Microsoft.Extensions.Options;
using RealEstate.Application.Contracts;
using RealEstate.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.Implementations
{
    public class EmailService : SmtpClient, IEmailService
    {
        EmailServiceOptions options;
        public EmailService(IOptions<EmailServiceOptions> options)
        {
            this.options = options.Value;
            this.Host = this.options.Host;
            this.Port = this.options.Port;
            this.EnableSsl = this.options.EnableSsl;
            this.Credentials = new NetworkCredential(this.options.Username, this.options.Password);
        }
        public async Task<bool> SendEmailAsync(string to, string subject, string message, CancellationToken cancellationToken = default)
        {

            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.From = new MailAddress(this.options.Username, this.options.DisplayName);
                    mailMessage.To.Add(to);
                    await this.SendMailAsync(mailMessage, cancellationToken);

                };

            }
            catch (Exception ex)
            {

                return false;
            }



            return true;
        }
    }
}
