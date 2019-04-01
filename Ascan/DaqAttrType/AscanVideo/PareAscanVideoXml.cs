using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ascan
{

    [XmlType(TypeName = "Config")]
    public class AscanVideoXml
    {
        [XmlElement("AscanVideo")]
        public AscanVideos ascanVideo;
    }

    [XmlType(TypeName = "AscanVideo")]
    public class AscanVideos
    {
        public StrAscanVideo Param;
    }

    [XmlType(TypeName = "Param")]
    public struct StrAscanVideo
    {
        [XmlAttribute]
        public string Active;

        [XmlAttribute]
        public string IFActive;

        [XmlAttribute]
        public string Delay;

        [XmlAttribute]
        public string Range;

        [XmlAttribute]
        public string DetectionWaveMode;

        [XmlAttribute]
        public string EnvlopActive;

        [XmlAttribute]
        public string Length;

        [XmlAttribute]
        public string CompressedData;

        [XmlAttribute]
        public string EnvlopDecayFactor;
    }

}
