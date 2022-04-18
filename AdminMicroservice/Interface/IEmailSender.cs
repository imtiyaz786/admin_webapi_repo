using AdminMicroservice.Model;
using System.Threading.Tasks;

namespace EmailSender.Interface
{
    public interface IEmailSender
    {
        Task<string> SendEmailAsync(string recipientEmail);
    }
}
