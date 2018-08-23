using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomizedTrips.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        //Added
        private string _apiKey;

        public EmailSender(string apiKey)
        {
            this._apiKey = apiKey;
        } 
        //

        public Task SendEmailAsync(string email, string subject, string message)
        {
            //Added
            //SendGrid.SendGridClient client = new SendGrid.SendGridClient(_apiKey);
            //
            return Task.CompletedTask;
        }
    }
}
