using System;
using Amazon;

namespace heaven
{
    internal class AppLogger
    {
        private static readonly AppLogger _instance = new AppLogger();

        internal static AppLogger GetLogger()
        {
            return _instance;
        }

        internal void Print(object message)
        {
            Console.WriteLine(message);
        }

        internal void Printf(string format, object arg)
        {
            Print(string.Format(format, arg));
        }

        internal void Printf(string format, object arg, object arg1)
        {
            Print(string.Format(format, arg, arg1));
        }
    }
}