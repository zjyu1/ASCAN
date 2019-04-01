using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class UnitXml
    {
        [XmlElement("Unit")]
        public Unit unit;
    }

    [XmlType(TypeName = "Unit")]
    public class Unit
    {
        public StrUnit Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrUnit
    {
        [XmlAttribute]
        public string Tof;

        [XmlAttribute]
        public string Amp;
    }
}
