using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Wars.Logger
{
    public class Log : ILog
    {
        public void Logger(string message)
        {
            Console.WriteLine("LOG: {0}", message);
        }
    }
}
