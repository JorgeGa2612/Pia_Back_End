using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace PiaTienda.Services
{
    public class servicioCorreo : Iconfigcorreo
    {
        private readonly Iconfigcorreo _configcorreo;
        public servicioCorreo(IOptions<Iconfigcorreo> configcorreo)
        {
            _configcorreo = configcorreo.Value;
        }

        public async Task SendEmailAsync(Iconfigcorreo mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_configcorreo.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
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
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_configcorreo.Host, _configcorreo.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configcorreo.Mail, _configcorreo.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
}
