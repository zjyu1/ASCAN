using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAUT
{
    class testBlock
    {
        private float blockHeight;
        private float bottomLength;
        private float testBlockVelocity;
        private float verticalHeight;
        private float vAngle;

        public float BlockHeight
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

        public float BottomLength
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

        public float TestBlockVelocity
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

        public float VerticalHeight
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

        public float VAngle
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

        class wedge
        {
            private float wedgeBottomLength;
            private float wedgeTopLength;
            private float wedgeLeftHeight;
            private float wedgeAngle;
            private float wedgeVelocity;

            public float WedgeBottomLength
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

            public float WedgeTopLength
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

            public float WedgeLeftHeight
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

            

            public float WedgeAngle
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
            public float WedgeVelocity
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
        class probe
        {
            private float casingLength;
            private float firstDistance;
            private float elementaryPitch;
            private float elementaryInterSpace;
            private float centralFrequency;
            private int numOfExcitation;

            public float CentralFrequency
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
            public float CasingLength
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

            public float FirstDistance
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

            public float ElementaryPitch
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

            public float ElementaryInterSpace
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

        class position
        {
            private float wedgePosition;
            private float probePosition;

            public float WedgePosition
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
            public float ProbePosition
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
            private float pipeBottomLength;
            private float pipeDiameter;
            private float thickness;
            private float wedgePosition;
            private int startEle;
            private int endEle;
            private int eleNum;
           
            public float PipeBottomLength
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
            public float PipeDiameter
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

            public float Thickness
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

            public float WedgePosition
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