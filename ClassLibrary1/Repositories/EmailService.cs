



using SendGrid;
using SendGrid.Helpers.Mail;

namespace BLL
{
    public class EmailService : IEmailService
    {
        public async Task<Response> SendDynamicTemplateConfirmationEmail(string toEmail, string confirmationlink)
        {
            try
            {
                var sendGridClient = new SendGridClient("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");
                var sendGridMessage = new SendGridMessage();
                sendGridMessage.SetFrom("no-reply@mohandisy.com", "Mohandisy");
                sendGridMessage.AddTo(toEmail);
                //The Template Id will be something like this - d-9416e4bc396e4e7fbb658900102abaa2
                sendGridMessage.SetTemplateId("d-df9c8b11410f4e4c8822346389c251ca");
                //Here is the Place holder values you need to replace.
                sendGridMessage.SetTemplateData(new
                {
                    confirmationLink = confirmationlink
                });
                var response = await sendGridClient.SendEmailAsync(sendGridMessage);
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response> SendNotifyToEmail(string subject, string toEmail, string toName)
        {
            try
            {
                var sendGridClient = new SendGridClient("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");
                var sendGridMessage = new SendGridMessage();
                sendGridMessage.SetFrom("no-reply@mohandisy.com", "Mohandisy");
                sendGridMessage.AddTo(toEmail);
                //The Template Id will be something like this - d-9416e4bc396e4e7fbb658900102abaa2
                sendGridMessage.SetTemplateId("d-d95ed9956a2b44afac9b20c67c92e8d1");
                //Here is the Place holder values you need to replace.
                sendGridMessage.SetTemplateData(new
                {
                    subject = subject,
                    name = toName
                });
                var response = await sendGridClient.SendEmailAsync(sendGridMessage);
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Response> SendPassResetTokenEmail(string subject, string toEmail, string toName, string code)
        {
            try
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("no-reply@mohandisy.com", "Mohandisy");
                // subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress(toEmail, toName);

                var plainTextContent = $"Welcome {toName}";
                var htmlContent = $"use this code to reset your password <br><strong>'{code}'</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
