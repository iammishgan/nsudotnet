using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceModel.Syndication;
using System.Threading;
using System.Xml;

namespace RSS2Email
{
	class Program
	{
	    private static DateTime _lastDate;

		private static void Main(string[] args)
		{
			_lastDate = DateTime.Now;
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();
		}

        public static void ThreadProc()
        {
            while (true)
            {
               CheckNewFeeds();
               Thread.Sleep(1000);
            }
        }
		
		private static void CheckNewFeeds()
		{
		    var xmlReader = XmlReader.Create("http://bash.im/rss");
			var syndicationFeed = SyndicationFeed.Load(xmlReader);
			foreach (var item in syndicationFeed.Items.Where(item => item.PublishDate.Date.CompareTo(_lastDate) > 0))
			{
				SendEmail(item);
            }
			_lastDate = syndicationFeed.Items.ToArray()[0].PublishDate.Date;
		}

		private static void SendEmail(SyndicationItem item)
		{
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = item.Title.Text;
            mail.Body = item.Summary.Text;
            client.Send(mail);
         }
	}
}
