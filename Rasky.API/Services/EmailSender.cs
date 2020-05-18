using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;

using SendGrid.Helpers.Mail;
using Rasky.API.Configs;
using Microsoft.AspNetCore.Identity.UI.Services;
namespace Rasky.API.Services {

    public class EmailSender : IEmailSender {
        private readonly EmailSettings _emailSettings;

        public EmailSender (IOptions<EmailSettings> config) {
            _emailSettings = config.Value;
        }

        public async Task SendConfirmationEmailAsync (string email, string subject, string htmlMessage) {
            var client = new SendGridClient (_emailSettings.ApiKey);
            var from = new EmailAddress ("mohamed@test.com", "Support");
            var to = new EmailAddress (email);
            var plainTextContent = htmlMessage;
            var msg = MailHelper.CreateSingleEmail (from, to, subject, plainTextContent, $"<div>{htmlMessage}</div>");
            var response = await client.SendEmailAsync (msg);
        }
        public async Task SendForgotPasswordEmailAsync (string email, string subject, string htmlMessage) {
            var client = new SendGridClient (_emailSettings.ApiKey);
            var from = new EmailAddress ("mohamed@test.com", "Support");
            var to = new EmailAddress (email);
            var plainTextContent = htmlMessage;
            var msg = MailHelper.CreateSingleEmail (from, to, subject, plainTextContent, $"<div>{htmlMessage}</div>");
            var response = await client.SendEmailAsync (msg);
        }
    }
}