using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KitchenEquipment.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendAsync(string destinationEmail, string subject, string message)
        {
            await SendEmailAsync(destinationEmail, subject, message);

            return Ok();
        }

        private static async Task SendEmailAsync(string destinationEmail, string name, string message)
        {
            var fromAddress = new MailAddress("zylon@mail.ru", "Alex");
            var toAddress = new MailAddress(destinationEmail, name);
            const string fromPassword = "41535";
            const string subject = "From site";

            var smtp = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Port = 465,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var letter = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = message
            })
            {
                smtp.Send(letter);
            }
        }
    }
}