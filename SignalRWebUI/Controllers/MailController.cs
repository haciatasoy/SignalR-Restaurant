using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.IdentityDtos;
using MailKit.Net.Smtp;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailSettingService mm;

        public MailController(IMailSettingService mm)
        {
            this.mm = mm;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailSettingDto mailSettingDto)
        {
            
            var mailsetting = mm.TGetListAll().FirstOrDefault();
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", mailsetting.Usermail);
            MailboxAddress mailboxAddresTo = new MailboxAddress("Rezervasyon Sahibi",mailSettingDto.Email);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddresTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailSettingDto.Body; ;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailSettingDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect(mailsetting.SmtpMail, mailsetting.Port, mailsetting.EnableSsl);
            client.Authenticate(mailsetting.Usermail, mailsetting.Password);

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Category");
        }
    }
}
