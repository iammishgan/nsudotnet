using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
using System.Timers;
using System.Xml;

namespace RSS2Email
{
	class Program
	{
	    private static DateTime _lastDate;
        private static System.Timers.Timer _aTimer;

		private static void Main(string[] args)
		{
            _lastDate = DateTime.Now;
            _aTimer = new System.Timers.Timer(100);
            _aTimer.Elapsed += new ElapsedEventHandler(CheckNewFeeds);
            _aTimer.Enabled = true;
            Console.ReadLine();
		}



        private static void CheckNewFeeds(object source, ElapsedEventArgs e)
		{
            var xmlReader = XmlReader.Create("http://www.overclockers.ru/rss/all.rss");
			var syndicationFeed = SyndicationFeed.Load(xmlReader);
			foreach (var item in syndicationFeed.Items.Where(item => item.PublishDate.Date.CompareTo(_lastDate) > 0))
			{
				SendEmail(item);
            }
			_lastDate = syndicationFeed.Items.ToArray()[0].PublishDate.Date;
		}

		private static void SendEmail(SyndicationItem item)
		{

            _lastDate = DateTime.Now;

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("iammishgan@gmail.com", "pass");

            MailMessage mm = new MailMessage("donotreply@domain.com", "iammishgan@rambler.ru", "test", "test");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mm.Subject = item.Title.Text;
            mm.Body = item.Summary.Text;
            client.Send(mm);
          }
	}
}
