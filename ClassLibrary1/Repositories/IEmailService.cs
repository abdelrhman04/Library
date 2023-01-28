using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IEmailService
    {
        Task<Response> SendNotifyToEmail(string subject, string toEmail, string toName);
        Task<Response> SendDynamicTemplateConfirmationEmail(string toEmail, string confirmationlink);
        Task<Response> SendPassResetTokenEmail(string subject, string toEmail, string toName, string code);
    }
}
