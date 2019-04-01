using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{
    [XmlType(TypeName = "Config")]
    public class MeasurementXml
    {
        [XmlElement("Measurement")]
        public Measurement measurement;
    }

    [XmlType(TypeName = "Measurement")]
    public class Measurement
    {
        public StrMeasurement Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrMeasurement
    {
        [XmlAttribute]
        public string AlarmActive;

        [XmlAttribute]
        public string AlarmDisp;
    }
}
