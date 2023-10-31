using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BackEnd.Services.Notification
{
    public class NotificationsService 
    {
        public NotificationsService()
        {
            
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
    }
}
