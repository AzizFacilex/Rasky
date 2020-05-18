using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using SendGrid;
using Twilio.Rest.Verify.V2.Service;
using SendGrid.Helpers.Mail;
using Rasky.API.Configs;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;
namespace Rasky.API.Services {

    public class SmsSender : ISmsSender {
        private readonly SmsSettings smsSettings;

        public SmsSender (IOptions<SmsSettings> smsSettings) {
            this.smsSettings = smsSettings.Value;
        }

        public async Task SendConfirmationSmsCodeAsync(string number) 
        {
            var verification=await VerificationResource.CreateAsync(
                to:number,
                channel:"sms",
                pathServiceSid:smsSettings.Service
            );

        }
        public async Task VerifyConfirmationSmsCodeAsync(string number, string code)
        {
            
            var verification= await VerificationCheckResource.CreateAsync(
                to:number,
                code:code,
                pathServiceSid:smsSettings.Service
            );
            
        }
    }
}