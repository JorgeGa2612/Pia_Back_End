using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;

namespace PiaTienda.Services
{
    public class servicioCorreo : Iconfigcorreo
    {
        private readonly correosettings _correosettings;
        public servicioCorreo(IOptions<correosettings> correosettings)
        {
            _correosettings = correosettings.Value;
        }

        public async Task SendEmailAsync(correorequest correorequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_correosettings.Mail);
            email.To.Add(MailboxAddress.Parse(correorequest.ToEmail));
            email.Subject = correorequest.Subject;
            var builder = new BodyBuilder();
            if (correorequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in correorequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = correorequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_correosettings.Host, _correosettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_correosettings.Mail, _correosettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
    }
}
