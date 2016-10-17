using System;
using System.IO;
using System.Reflection;

namespace Sheep.Kernel.Reflaction
{
    public class GenerationFactory
    {
        public static object CreateInstance(string assemblyName, string className)
        {
            return Assembly.LoadFrom(assemblyName).CreateInstance(className);
        }
    }
}
