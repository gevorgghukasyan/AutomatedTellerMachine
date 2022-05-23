using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class NotificationService : INotificationService
	{
		public void SendMessage(User user, string message)
		{
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
			{
				EnableSsl = true,
				Timeout = 10000,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential("bankarmenia21@gmail.com", "Gevorg21")
			};

			MailMessage mailMessage = new MailMessage();
			mailMessage.To.Add(user.Email);
			mailMessage.From = new MailAddress("bankarmenia21@gmail.com");
			mailMessage.Subject = "Bank Armenia";
			mailMessage.Body = message;
			client.Send(mailMessage);
		}
	}
}
