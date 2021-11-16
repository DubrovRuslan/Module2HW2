using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW2.Notifications
{
    public class SmsNotifier
    {
        public void SendSMS(string number, string message)
        {
            Logger.Instance.WriteToLog($"Send SMS to: {number}, message: {message}, sever: {Configurations.Instance.SmtpServerAdress}");
        }
    }
}
