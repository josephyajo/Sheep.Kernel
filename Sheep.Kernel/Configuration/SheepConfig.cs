using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sheep.Kernel.Configuration
{
    [XmlRoot("sheep")]
    public class SheepConfig
    {
        [XmlElement("path")]
        public string Path { get; set; }
    }
}
