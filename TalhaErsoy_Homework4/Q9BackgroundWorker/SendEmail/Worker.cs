using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using MimeKit;
using MimeKit.Text;

namespace MyWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
      
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress("talha", "m.talhaersoy@hotmail.com"));
            message.From.Add(new MailboxAddress("talha", "m.talhaersoy@hotmail.com"));
            message.Subject = "Hi";
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = "Email for testing"
            };


            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {

                await client.ConnectAsync("smtp-mail.outlook.com", 587, SecureSocketOptions.Auto);

                client.AuthenticationMechanisms.Remove("XOAUTH2");

                await client.AuthenticateAsync("m.talhaersoy@hotmail.com", "Password");

                await client.SendAsync(message);
       

               await client.DisconnectAsync(true);
            }

            
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
   
            await base.StopAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(200000, stoppingToken);
            }
        }
    }
}