using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Services
{
    public class MailService : IMailService
    {
        #region Backing Fields
        private const string _apiKey = "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";
        private const string _fromMail = "support@colconsult.dk";
        private const string _senderName = "Email Delivery Service";
        #endregion

        public async Task SendOrderConfirmMail(OrderDTO order)
        {
            SendGridClient client = new(_apiKey);
            EmailAddress from = new(_fromMail, _senderName);
            EmailAddress to = new(order.Customer.Email);

            string subject = $"Order Confirmation #{order.Id}";
            string body = $"Dear {order.Customer.FirstName} {order.Customer.LastName},\n\n" +
                $"Thank you for your order. Your order has been confirmed and will be shipped shortly.\n\n" +
                $"Order details:\n" +
                $"Order ID: {order.Id}\n" +
                $"Order Date: {order.OrderDate}\n" +
                $"Order Status: {order.Status}\n\n" +
                $"Regards GreenPrint Store\n";

            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            await client.SendEmailAsync(msg);
        }

        public async Task SendTestMail()
        {
            SendGridClient client = new(_apiKey);
            EmailAddress from = new(_fromMail, _senderName);
            EmailAddress to = new("alex802c@gmail.com");

            string subject = $"Just a test mail :)";
            string body = $"This is just a test mail :) Hooray";

            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            await client.SendEmailAsync(msg);
        }
    }
}
