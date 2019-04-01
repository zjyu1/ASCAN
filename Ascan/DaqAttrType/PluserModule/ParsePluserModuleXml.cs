using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class PluserModuleXml
    {
        [XmlElement("PluserModule")]
        public PluserModule pluserModule;
    }

    [XmlType(TypeName = "PluserModule")]
    public class PluserModule
    {
        public StrPluserModule Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrPluserModule
    {
        [XmlAttribute]
        public string Mode;

        [XmlAttribute]
        public string TimeBase;

        [XmlAttribute]
        public string RearmSource;
    }
}
