using System;
using System.IO;

namespace ConsoleApp
{
    public class AppSettings
    {
        public const string Settings = "Settings";

        public static readonly string BasePath = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string LogFile = Path.Combine(BasePath, "ConsoleApp-{Date}.log");

        public string Greeting { get; set; }
    }
}
