using System.Net.Mail;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Text;
using BackEnd.Services.Interfaces;
using System.Security.Claims;
using BackEnd.Helpers;

namespace BackEnd.Services.Services
{
    public class NotificationsService : INotificationsService
    {
        private readonly SmtpService smtpService;
        private readonly RecipientService recipientService;
        public (int UserId, int DepartmentId, int RoleId) Token { get; set; } = (-1, -1, -1);

        public NotificationsService(ISmtpService smtpService, IRecipientService recipientService)
        {
            this.smtpService = (SmtpService)smtpService;
            this.recipientService = (RecipientService)recipientService;
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


        public async Task<bool> SendForms(int groupId)
        {
            var smtpConfig = (await this.smtpService.GetSmtpConfig(Token.DepartmentId)).FirstOrDefault();

            if (smtpConfig != null)
            {
                var to = await this.recipientService.GetRecipients();
                if (to != null && to.Count > 0)
                {
                    // Create a new SmtpClient
                    var smtpClient = new SmtpClient(smtpConfig.SmtpServer)
                    {
                        Port = smtpConfig.Port,
                        Credentials = new NetworkCredential(smtpConfig.UserName, smtpConfig.Password),
                        EnableSsl = smtpConfig.EnableSSL,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false
                    };

                    foreach (var item in to)
                    {
                        var mailMessage = new MailMessage(smtpConfig.UserName, item.Mail)
                        {
                            Subject = "Test Email",
                            Body = "This is a test email sent from C#.",
                            BodyEncoding = Encoding.UTF8,
                            SubjectEncoding = Encoding.UTF8,
                        };


                        // Send the email
                        await smtpClient.SendMailAsync(mailMessage);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
