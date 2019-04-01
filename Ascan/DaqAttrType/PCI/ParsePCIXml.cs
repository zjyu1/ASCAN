using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class PCIXml
    {
        [XmlElement("PCI")]
        public PCI pci;
    }

    [XmlType(TypeName = "PCI")]
    public class PCI
    {
        public StrPCI Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrPCI
    {
        [XmlAttribute]
        public string SyncAcqDone;

        [XmlAttribute]
        public string PCISlotNumber;

        [XmlAttribute]
        public string PCIClassicNumber;  
    }
}
