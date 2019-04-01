using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class testBlock
    {
        private double blockHeight;
        private double bottomLength;
        private double testBlockVelocity;
        private double verticalHeight;
        private double vAngle;
        public int Type;

        public double BlockHeight
        {
            get
            {
                return blockHeight;
            }
            set
            {
                blockHeight = value;
            }
        }

        public double BottomLength
        {
            get
            {
                return bottomLength;
            }
            set
            {
                bottomLength = value;
            }
        }

        public double TestBlockVelocity
        {
            get
            {
                return testBlockVelocity;
            }
            set
            {
                testBlockVelocity = value;
            }
        }

        public double VerticalHeight
        {
            get
            {
                return verticalHeight;
            }
            set
            {
                verticalHeight = value;
            }
        }

        public double VAngle
        {
            get
            {
                return vAngle;
            }
            set
            {
                vAngle = value;
            }
        }
    }

        public class wedge
        {
            private double wedgeBottomLength;
            private double wedgeTopLength;
            private double wedgeLeftHeight;
            private double wedgeAngle;
            private double wedgeVelocity;

            public double WedgeBottomLength
            {
                get
                {
                    return wedgeBottomLength;
                }
                set
                {
                    wedgeBottomLength = value;
                }
            }

            public double WedgeTopLength
            {
                get
                {
                    return wedgeTopLength;
                }
                set
                {
                    wedgeTopLength = value;
                }
            }

            public double WedgeLeftHeight
            {
                get
                {
                    return wedgeLeftHeight;
                }
                set
                {
                    wedgeLeftHeight = value;
                }
            }



            public double WedgeAngle
            {
                get
                {
                    return wedgeAngle;
                }
                set
                {
                    wedgeAngle = value;
                }
            }
            public double WedgeVelocity
            {
                get
                {
                    return wedgeVelocity;
                }
                set
                {
                    wedgeVelocity = value;
                }
            }

        }
        public class probe
        {
            private double casingLength;
            private double firstDistance;
            private double elementaryPitch;
            private double elementaryInterSpace;
            private double centralFrequency;
            private int numOfExcitation;

            public double CentralFrequency
            {
                get
                {
                    return centralFrequency;
                }
                set
                {
                    centralFrequency = value;
                }
            }
            public double CasingLength
            {
                get
                {
                    return casingLength;
                }
                set
                {
                    casingLength = value;
                }
            }

            public double FirstDistance
            {
                get
                {
                    return firstDistance;
                }
                set
                {
                    firstDistance = value;
                }
            }

            public double ElementaryPitch
            {
                get
                {
                    return elementaryPitch;
                }
                set
                {
                    elementaryPitch = value;
                }
            }

            public double ElementaryInterSpace
            {
                get
                {
                    return elementaryInterSpace;
                }
                set
                {
                    elementaryInterSpace = value;
                }
            }

            public int NumOfExcitation
            {
                get
                {
                    return numOfExcitation;
                }
                set
                {
                    numOfExcitation = value;
                }
            }

        }

        public class UTPosition
        {
            private double wedgePosition;
            private double probePosition;

            public double WedgePosition
            {
                get
                {
                    return wedgePosition;
                }
                set
                {
                    wedgePosition = value;
                }
            }
            public double ProbePosition
            {
                get
                {
                    return probePosition;
                }
                set
                {
                    probePosition = value;
                }
            }
        }
      public  class pipeParaAndEleConfig
        {
          private double pipeBottomLength;
          private double pipeDiameter;
          private double thickness;
          private double wedgePosition;
            private int startEle;
            private int endEle;
            private int eleNum;

            public double PipeBottomLength
            {
                get
                {
                    return pipeBottomLength;
                }
                set
                {
                    pipeBottomLength = value;
                }
            }
            public double PipeDiameter
            {
                get
                {
                    return pipeDiameter;
                }
                set
                {
                    pipeDiameter = value;
                }
            }

            public double Thickness
            {
                get
                {
                    return thickness;
                }
                set
                {
                    thickness = value;
                }
            }

            public double WedgePosition
            {
                get
                {
                    return wedgePosition;
                }
                set
                {
                    wedgePosition = value;
                }
            }

            public int StartEle
            {
                get
                {
                    return startEle;
                }
                set
                {
                    startEle = value;
                }
            }

            public int EndEle
            {
                get
                {
                    return endEle;
                }
                set
                {
                    endEle = value;
                }
            }

            public int EleNum
            {
                get
                {
                    return eleNum;
                }
                set
                {
                    eleNum = value;
                }
            }
        }
    
}