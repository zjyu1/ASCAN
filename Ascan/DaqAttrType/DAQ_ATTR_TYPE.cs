using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class DaqAttrType
    {
        //start attr base 
        public static uint baseAddr;

        ////For all Gate
        public static UnitAttrType unit;

        //the AttrType of I、A、B、C
        public static GateAttrType[] gate;

        //the AttrType of BA、AI、BI、CI
        public static DGateAttrType[] dGate;

        //DAC POINT  
        public static DACAttrType dac;

        //Material Velocity
        public static MatVelocityAttrType matVelocity;

        //PA parameters
        public static PAAttrType pA;

        //Pluser Transmit Parameters  dsp only ack these attrbute setting for ut mode, 
        //PA mode will read by  DAQ_PA_BEAMFILE setattr   
        public static PulserTranmitAttrType pulserTranmit;

        //Reciever parameters
        public static RecieverAttrType receiver;

        //Back Echo Attenuation 
        public static BackEchoAttrType backEcho;

        //Ascan Video
        public static AscanVideoAttrType ascanVideo;

        //Global Control
        public static GlobalCtrlAttrType globalCtrl;

        //Board real-time status reg
        //Status indicator
        public static StatusIndicatorAttrType statusIndicator;

        //BOARD REAL-TIME UPLOAD DATA   
        //Measurement
        public static MeasurementAttrType measurement;

        //Ascan video data
        public static AscanDataAttrType ascanData;

        //Envelop video data
        public static EnvelopDataAttrType envelopData;

        //Real time upload data
        public static RealTimeDataAttrType realTimeData;

        //Interface Type
        public static InterfaceAttrType interfaceType;

        //LED STATUS 
        public static LEDStatusAttrType ledStatus;

        public static PCIAttrType pci;

        //Out line 路由配置
        public static OutLineAttrType outLine;

        //In line 
        public static InLineAttrType inLine;

        //POS TRIGGER SOURCE 配置   
        public static PosTriggerAttrType posTrigger;

        //PLUSER MODULE 配置 (for soft trig)      
        public static PluserModuleAttrType pluserModule;

        //TESOUT 配置 
        public static TesoutAttrType tesout;

        //POWER MANAGMENT FOR PA BOARD		
        public static PowerAttrType power;

        public static CaptureMethodAttrType captureMethod;

        public static void init()
        {
            InitStartAddrAttrType.read();

            InitUnitAttrType.read();

            InitGateAtrrType.read();

            InitDGateAttrType.read();

            InitDACAttrType.read();

            InitMatVelocityAttrType.read();

            InitPAAttrType.read();

            InitPulserTransmitAttrType.read();

            InitReceiverAttrType.read();

            InitBackEchoAttrType.read();

            InitAscanVideoAttrType.read();

            InitGlobalCtrlAttrType.read();

            InitStatusIndicatorAttrType.read();

            InitMeasurementAttrType.read();

            InitAscanDataAttrType.read();

            InitEnvelopDataAttrType.read();

            InitRealTimeDataAttrType.read();

            InitInterfaceAttrType.read();

            InitLEDStatusAttrType.read();

            InitPCIAttrType.read();

            InitOutLineAttrType.read();

            InitInLineAttrType.read();

            InitPosTriggerAttrType.read();

            InitPluserModuleAttrType.read();

            InitTesoutAttrType.read();

            InitPowerAttrType.read();

            InitCaptureMethodAttrType.read();
        }
    }
}
