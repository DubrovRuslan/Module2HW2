namespace Module2HW2.Notifications
{
    public class EmailNotifier
    {
        public void SendEmail(string email, string message)
        {
            Logger.Instance.WriteToLog($"Send Email to: {email}, message: {message}, server: {Configurations.Instance.SmsServerNumber}");
        }
    }
}
