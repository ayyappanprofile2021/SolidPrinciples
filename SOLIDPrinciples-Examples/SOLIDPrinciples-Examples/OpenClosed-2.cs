using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples_Examples
{
    public interface INotification
    {
        void Send(string message);
    }

    public class Email:INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email - {message}" );
        }
    }

    public class SMS : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS - {message}");
        }
    }

    public class Push : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Push - {message}");
        }
    }

    public class WhatsApp:INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"WhatsApp - {message}");
        }
    }

    public class Facebook : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Facebook - {message}");
        }
    }

    public static class NotificationManager
    {
        public static void SendNotification(List<INotification> notifications, string message)
        {
            foreach(INotification notification in notifications)
            {
                notification.Send(message);
            }
        }
    }

    public class MainTask
    {
        public Status PerformOperation()
        {
            Random rd=new Random();
            int randomNum = rd.Next(1, 100);
            if (randomNum % 2 == 0)
                return Status.Success;
            else
                return Status.Fail;
        }
    }

    public enum Status
    {
        Success,Fail
    }    
}
