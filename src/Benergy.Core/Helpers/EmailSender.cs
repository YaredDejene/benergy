using System;
using System.Threading.Tasks;
using Benergy.Core.Common;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Benergy.Core.Helpers
{
    /// <summary>
    /// Email sending service using SendGrid
    /// </summary>
    public static class EmailSender
    {
        public static async Task Send(Tuple<string, string> sender, string subject,string body, Tuple<string, string> receiver)
        {
            var apiKey = SiteSettings.SendGridApiKey;
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(sender.Item1, sender.Item2),
                Subject = subject,
                PlainTextContent = body,
                HtmlContent = $"<strong>{body}</strong>"
            };
            msg.AddTo(new EmailAddress(receiver.Item1, receiver.Item2));
            var response = await client.SendEmailAsync(msg);
        }
    }
}