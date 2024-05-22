using System.Net.Mail;

namespace Tomnaia.Services.Mail
{
    public interface IMailingService
    {
        void SendMail(MailMessage message);
    }
}
