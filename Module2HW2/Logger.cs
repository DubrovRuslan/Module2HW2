using System;
using System.Text;

namespace Module2HW2
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        private readonly StringBuilder _log;

        static Logger()
        {
        }

        private Logger()
        {
            _log = new StringBuilder();
        }

        public static Logger Instance
        {
            get
            {
                return _instance;
            }
        }

        public void WriteToLog(string message)
        {
            _log.AppendLine($"{DateTime.UtcNow.ToString()} : {message}");
            Console.WriteLine(message);
        }

        public string GetAllLog()
        {
            return _log.ToString();
        }
    }
}
