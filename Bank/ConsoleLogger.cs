using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public interface ILogger
    { 
        void Info(string message);
        void Error(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
        public void Error(string message)
        {
            Console.WriteLine(message);
        }
    }
}
