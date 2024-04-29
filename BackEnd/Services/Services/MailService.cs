using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Text;
using BackEnd.Services.Interfaces;
using System.Security.Claims;
using System.Text.Json;
using BackEnd.Helpers;
using BackEnd.Models.Input;
using BackEnd.Models.Output;
using FrontEnd.Helpers;


namespace BackEnd.Services.Services
{
    public class MailService : IMailService
    {
        private readonly SmtpService smtpService;
        private readonly RecipientService recipientService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IFormService? formService;
        public (int UserId, int DepartmentId, int RoleId) Token { get; set; } = (-1, -1, -1);
        private readonly string href;
        public MailService(ISmtpService smtpService,
                                    IRecipientService recipientService,
                                    IHttpContextAccessor httpContextAccessor, IFormService formService)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.formService = formService;
            this.smtpService = (SmtpService)smtpService;
            this.recipientService = (RecipientService)recipientService;
            if (this.httpContextAccessor.HttpContext != null)
            {
                this.Token = this.httpContextAccessor.HttpContext.User.ParseToken();
                this.href = this.httpContextAccessor.HttpContext.Request.Headers["Origin"]+ "/Rating/";
            }
        }

   
        // public async Task SendPhoneVerificationCode(int ClientId)
        // {
        //     TwilioClient.Init(Environment.GetEnvironmentVariable("ACf32f5326cbde6aac5d1420be3b4d0f58"), Environment.GetEnvironmentVariable("764dc2208aa5de75cde16db2f70673e0"));
        //
        //     var message = await MessageResource.CreateAsync
        //     (
        //         body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
        //         from: new Twilio.Types.PhoneNumber("+15598534880"),
        //         to: new Twilio.Types.PhoneNumber("+15558675310")
        //     );
        // }
       
        public async Task<bool> SendMail(Form model)
        {
            var department = (int?)model?.GetType()?.GetProperty("DepartmentId")?.GetValue(model);
             if (Token.RoleId == 0 ||
                Token.RoleId == 1 && Token.DepartmentId != department)
                throw Alert.Create(Constants.Error.WrongPermissions);
            
            var smtpConfig = (await this.smtpService.GetSmtpConfig()).FirstOrDefault();

            if (smtpConfig != null)
            {
                var to = (await this.recipientService.GetRecipients()).Where(r => r.GroupId == model?.GroupId).ToList();
                if (to is { Count: > 0 })
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
                    
                    foreach (var recipient in to)
                    {
                        var guid = await this.formService?.AddFormIdentification(new()
                        {
                            GroupId = recipient.GroupId,
                            ExpirationTime = DateTime.Today,
                            FormId = model.Id,
                            RecipientId = recipient.Id
                        });

                        var mailMessage = new MailMessage(smtpConfig.UserName, recipient.Mail)
                        {
                            Subject = "ՈՒսումնական պլանի արդիականացման հարցում",
                            Body = $"Հարգելի {recipient.Name} " + Environment.NewLine +
                                    "Խնդրում ենք անցնել հղումով և մասնակցել հարցմանը:" + Environment.NewLine +
                                    $"Հղում` {href + guid}" + Environment.NewLine + Environment.NewLine +
                                    "Նամակը գեներացվել է ավտոմատ:" + Environment.NewLine + Environment.NewLine +
                                    "Հարգանքով՝" + Environment.NewLine +
                                    "Հայաստանի Ազգային Պոլիտեխնիկական Համալսարան" + Environment.NewLine,
                            BodyEncoding = Encoding.UTF8,
                            SubjectEncoding = Encoding.UTF8,

                        };

                        // Send the email
                        try
                        {
                            await smtpClient.SendMailAsync(mailMessage);
                        }
                        catch (Exception ex)
                        {
                            // ignored
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
