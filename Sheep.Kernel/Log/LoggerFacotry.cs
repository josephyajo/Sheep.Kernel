using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheep.Kernel.Serialization;

namespace Sheep.Kernel.Log
{
    public class LoggerFacotry
    {
        public static ILogger CreateLogger(string className)
        {
            Type type = Type.GetType("Sheep.Kernel.Log." + className);
            return Activator.CreateInstance(type) as ILogger;
        }
    }
}
