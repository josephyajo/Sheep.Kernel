using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Reflaction
{
    public class DynamicLoad
    {
        public static Assembly LoadDll(string path)
        {
            return Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + path);
        }

        public static Assembly LoadCurrentDll()
        {
            return Assembly.GetExecutingAssembly();
        }

        public static Module GetModule(Assembly assembly, string name)
        {
            return assembly.GetModule(name);
        }

        public static Module GetCurrentModule(Assembly assembly)
        {
            return assembly.ManifestModule;
        }

        public static Module[] GetAllModule(Assembly assembly, string name)
        {
            return assembly.GetModules();
        }


    }
}
