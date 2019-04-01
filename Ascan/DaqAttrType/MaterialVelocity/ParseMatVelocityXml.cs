using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class MatVelocityXml
    {
        [XmlElement("MaterialVelocity")]
        public MaterialVelocity matVelocity;
    }

    [XmlType(TypeName = "MaterialVelocity")]
    public class MaterialVelocity
    {
        public StrMaterialVelocity Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrMaterialVelocity
    {
        [XmlAttribute]
        public string Longitudinal;

        [XmlAttribute]
        public string Transverse;

        [XmlAttribute]
        public string Velocity;
    }
}
