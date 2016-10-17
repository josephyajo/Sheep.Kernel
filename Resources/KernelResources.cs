using Sheep.Kernel.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Kernel.Context
{
    internal class KernelResources
    {
        private static CultureInfo resourceCulture;
        private static ResourceManager resourceMan;

        internal static string RequiredAttribute_ErrorMessage
        {
            get
            {
                return ResourceManager.GetString("RequiredAttribute_ErrorMessage", resourceCulture);
            }
        }

        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    resourceMan = new ResourceManager("Sheep.Kernel.Resources", typeof(KernelResources).Assembly);
                }
                return resourceMan;
            }
        }

        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }
    }
}
