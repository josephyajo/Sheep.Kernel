using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Dependency
{
    public class RegisterExtensions
    {
        public static void Register()
        {
            string path = "/log4net.dll";
            Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + path);
            Type[] list = assembly.ManifestModule.FindTypes((t, obj) => t.Name.EndsWith("Factory"), null);
        }
    }
}
