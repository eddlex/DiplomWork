using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Text;
using BackEnd.Services.SMTPConfig;

namespace BackEnd.Services.Notification
{
    public class NotificationsService : INotificationsService
    {
        private readonly SmtpService smtpService;
        public NotificationsService(ISmtpService smtpService)
        {
            this.smtpService = (SmtpService)smtpService;
        }


        public async Task SendPhoneVerificationCode(int ClientId)
        {
            TwilioClient.Init(Environment.GetEnvironmentVariable("ACf32f5326cbde6aac5d1420be3b4d0f58"), Environment.GetEnvironmentVariable("764dc2208aa5de75cde16db2f70673e0"));

            var message = await MessageResource.CreateAsync
            (
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber("+15598534880"),
                to: new Twilio.Types.PhoneNumber("+15558675310")
            );
        }


        public async Task SendMessage(int groupId, int universityId)
        {
            //this.smtpService.GetSmtpConfig();
            // Set the SMTP server details
            string smtpServer = "smtp.office365.com";
            int smtpPort = 587;

            // Set the sender email address and credentials
            string senderEmail = "eduardordukhanyan.tt055-1@polytechnic.am";
            string senderPassword = "Cox28234";

            // Set the recipient email address
            string recipientEmail = "e.ordukhanyan@gmail.com";

            // Create a new MailMessage
            MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail)
            {
                Subject = "Test Email",
                Body = "This is a test email sent from C#.",
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8,
        };

            // Create a new SmtpClient
            SmtpClient smtpClient = new SmtpClient(smtpServer)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false

        };

            // Send the email
            await smtpClient.SendMailAsync(mailMessage);



        }

        public Task SendMessage()
        {

            throw new NotImplementedException();
        }
    }
}
