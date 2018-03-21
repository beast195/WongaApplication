using System;
using Wonga.Common.Services.ConsoleWrapper.Interface;

namespace Wonga.Common.Services.ConsoleWrapper
{
    /// <summary>
    /// Mock Console
    /// </summary>
    public class ConsoleWrapper : IConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}