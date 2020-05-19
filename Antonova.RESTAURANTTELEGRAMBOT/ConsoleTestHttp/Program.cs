using Antonova.Core.Services;
using System;

namespace ConsoleTestHttp
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpHandler = new HttpHandler();
            var host = "https://api.kanye.rest?format=text";
            string result = httpHandler.GetStringQuoteAsync(host).GetAwaiter().GetResult();
            Console.ReadLine();
            Console.WriteLine(result);
        }
    }
}
