using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Ascan
{
    public class ConstParameter
    {
        public const int MaxFloatArrayCount = 8192;
        public const int MaxUintArrayCount = 64;
        public const uint MaxAscanWaveLen = 1024;
        public const int MaxQueueItemCount = 50;
        public const int TimeOutMilliSecondValue = 10 * 1000;
        public const int TimerInterval = 1000;
        public const int MaxMeasureDataLength = 8192;
        public const double MaxAllowedMeasureValue = 1.2;
        public const double MinAllowedMeasureValue = -1.2;
        public const double MaxAllowedDoubleGatesValue = 5;
        public const double MinAllowedDoubleGatesValue = 3;
        public const int ADSampleRate = 100;
        public const int MaxPixelHight = 3000;
        public const int PipeDiameter = 720;    
        public const int ScalePrePage = 200;
        public const double DefaultPosInc = 0.5;
        public const int BufferCapacity = 500;
        public const int AnglePreUnit = 1;
        public const double CoupleThreshold = 0.45;
        public const int BscanPointNumPrePacket = 256;
        public const int TOFDPointNumPrePacket = 256;
        public const uint StartLowFlag = 0x6774;
        public const uint StartHighFlag = 0x0041;
        public const uint StopLowFlag = 0x6768;
        public const uint StopHighFlag = 0x0041;
        public const double DistTOFD2PA = 50;  //distance between tofd and PA probe
        public static Color[] LineColor
           = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Green,
                Color.LightBlue, Color.DarkBlue,Color.Purple,Color.Black };

        public const int AscanTimerInterval = 50;

      
    }

    #region
    public enum AttrbuteType
    {
        /**Base address.*/
        DAQ_ATTR_UT_TESTING_MODE = 0x3FF60000,


        /**Unit type of TOF and AMP.*/
        DAQ_ATTR_GATE_TOF_UNIT,
        DAQ_ATTR_GATE_AMP_UNIT,


        /**Gate I.*/
        DAQ_ATTR_GATE_I_DELAY,                        
        DAQ_ATTR_GATE_I_WIDTH,
        DAQ_ATTR_GATE_I_THRELD,
        DAQ_ATTR_GATE_I_IF,                           
        DAQ_ATTR_GATE_I_TOF_MODE,

        DAQ_ATTR_GATE_I_DNS_ACTIVE,
        DAQ_ATTR_GATE_I_DNS_BW,
        DAQ_ATTR_GATE_I_DNS_START,
        DAQ_ATTR_GATE_I_DNS_SETP,

        DAQ_ATTR_GATE_I_ALARM_LOGIC,

        DAQ_ATTR_GATE_I_SC_ACTIVE,
        DAQ_ATTR_GATE_I_SC_COUNTER,

        DAQ_ATTR_GATE_I_DTS_ACTIVE,
        DAQ_ATTR_GATE_I_DTS_BAND,
        DAQ_ATTR_GATE_I_DTS_START,
        DAQ_ATTR_GATE_I_DTS_STEP,

        DAQ_ATTR_GATE_I_TOL_MONITOR_ACTIVE,
        DAQ_ATTR_GATE_I_TOL_MONITOR_MAX,
        DAQ_ATTR_GATE_I_TOL_MONITOR_MIN,
        DAQ_ATTR_GATE_I_TOL_MONITOR_SC,
 
        DAQ_ATTR_GATE_I_ALARM_ACTIVE,
        DAQ_ATTR_GATE_I_ALARM_MODE,
        DAQ_ATTR_GATE_I_ALARM_SIGNAL_LENGTH,
        DAQ_ATTR_GATE_I_ALARM_TIME_LENGTH,
        DAQ_ATTR_GATE_I_ALARM_ACTIVE_LEVEL,
 
        DAQ_ATTR_GATE_I_MEAS_ACTIVE,
        DAQ_ATTR_GATE_I_MEAS_MODE,
 

        /**Gate A.*/
        DAQ_ATTR_GATE_A_DELAY = 0x3FF60020,
        DAQ_ATTR_GATE_A_WIDTH,
        DAQ_ATTR_GATE_A_THRELD,
        DAQ_ATTR_GATE_A_IF,
        DAQ_ATTR_GATE_A_TOF_MODE,

        DAQ_ATTR_GATE_A_DNS_ACTIVE,
        DAQ_ATTR_GATE_A_DNS_BW,
        DAQ_ATTR_GATE_A_DNS_START,
        DAQ_ATTR_GATE_A_DNS_SETP,

        DAQ_ATTR_GATE_A_ALARM_LOGIC,

        DAQ_ATTR_GATE_A_SC_ACTIVE,
        DAQ_ATTR_GATE_A_SC_COUNTER,                    

        DAQ_ATTR_GATE_A_DTS_ACTIVE,
        DAQ_ATTR_GATE_A_DTS_BAND,
        DAQ_ATTR_GATE_A_DTS_START,
        DAQ_ATTR_GATE_A_DTS_STEP,           

        DAQ_ATTR_GATE_A_TOL_MONITOR_ACTIVE,
        DAQ_ATTR_GATE_A_TOL_MONITOR_MAX,
        DAQ_ATTR_GATE_A_TOL_MONITOR_MIN, 
        DAQ_ATTR_GATE_A_TOL_MONITOR_SC,

        DAQ_ATTR_GATE_A_ALARM_ACTIVE,
        DAQ_ATTR_GATE_A_ALARM_MODE,
        DAQ_ATTR_GATE_A_ALARM_SIGNAL_LENGTH,
        DAQ_ATTR_GATE_A_ALARM_TIME_LENGTH,
        DAQ_ATTR_GATE_A_ALARM_ACTIVE_LEVEL,

        DAQ_ATTR_GATE_A_MEAS_ACTIVE,
        DAQ_ATTR_GATE_A_MEAS_MODE,


        /**Gate B.*/
        DAQ_ATTR_GATE_B_DELAY = 0x3FF60040,
        DAQ_ATTR_GATE_B_WIDTH,
        DAQ_ATTR_GATE_B_THRELD,
        DAQ_ATTR_GATE_B_IF,
        DAQ_ATTR_GATE_B_TOF_MODE,

        DAQ_ATTR_GATE_B_DNS_ACTIVE,
        DAQ_ATTR_GATE_B_DNS_BW,
        DAQ_ATTR_GATE_B_DNS_START,
        DAQ_ATTR_GATE_B_DNS_SETP,

        DAQ_ATTR_GATE_B_ALARM_LOGIC,

        DAQ_ATTR_GATE_B_SC_ACTIVE,
        DAQ_ATTR_GATE_B_SC_COUNTER,

        DAQ_ATTR_GATE_B_DTS_ACTIVE,
        DAQ_ATTR_GATE_B_DTS_BAND,
        DAQ_ATTR_GATE_B_DTS_START,
        DAQ_ATTR_GATE_B_DTS_STEP,

        DAQ_ATTR_GATE_B_TOL_MONITOR_ACTIVE,
        DAQ_ATTR_GATE_B_TOL_MONITOR_MAX,
        DAQ_ATTR_GATE_B_TOL_MONITOR_MIN,
        DAQ_ATTR_GATE_B_TOL_MONITOR_SC,

        DAQ_ATTR_GATE_B_ALARM_ACTIVE,
        DAQ_ATTR_GATE_B_ALARM_MODE,
        DAQ_ATTR_GATE_B_ALARM_SIGNAL_LENGTH,
        DAQ_ATTR_GATE_B_ALARM_TIME_LENGTH,
        DAQ_ATTR_GATE_B_ALARM_ACTIVE_LEVEL,

        DAQ_ATTR_GATE_B_MEAS_ACTIVE,
        DAQ_ATTR_GATE_B_MEAS_MODE,


        /**Gate C.*/
        DAQ_ATTR_GATE_C_DELAY = 0x3FF60060,
        DAQ_ATTR_GATE_C_WIDTH,
        DAQ_ATTR_GATE_C_THRELD,
        DAQ_ATTR_GATE_C_IF,
        DAQ_ATTR_GATE_C_TOF_MODE,

        DAQ_ATTR_GATE_C_DNS_ACTIVE,
        DAQ_ATTR_GATE_C_DNS_BW,
        DAQ_ATTR_GATE_C_DNS_START,
        DAQ_ATTR_GATE_C_DNS_SETP,

        DAQ_ATTR_GATE_C_ALARM_LOGIC,

        DAQ_ATTR_GATE_C_SC_ACTIVE,
        DAQ_ATTR_GATE_C_SC_COUNTER,

        DAQ_ATTR_GATE_C_DTS_ACTIVE,
        DAQ_ATTR_GATE_C_DTS_BAND,
        DAQ_ATTR_GATE_C_DTS_START,
        DAQ_ATTR_GATE_C_DTS_STEP,

        DAQ_ATTR_GATE_C_TOL_MONITOR_ACTIVE,
        DAQ_ATTR_GATE_C_TOL_MONITOR_MAX,
        DAQ_ATTR_GATE_CTOL_MONITOR_MIN,
        DAQ_ATTR_GATE_C_TOL_MONITOR_SC,

        DAQ_ATTR_GATE_C_ALARM_ACTIVE,
        DAQ_ATTR_GATE_C_ALARM_MODE,
        DAQ_ATTR_GATE_C_ALARM_SIGNAL_LENGTH,
        DAQ_ATTR_GATE_C_ALARM_TIME_LENGTH,
        DAQ_ATTR_GATE_C_ALARM_ACTIVE_LEVEL,

        DAQ_ATTR_GATE_C_MEAS_ACTIVE,
        DAQ_ATTR_GATE_C_MEAS_MODE,


        /**Gate B-A.*/
        DAQ_ATTR_GATE_BA_TOL_MONITOR_ACTIVE = 0x3FF60080,
        DAQ_ATTR_GATE_BA_TOL_MONITOR_MAX,
        DAQ_ATTR_GATE_BA_TOL_MONITOR_MIN,
        DAQ_ATTR_GATE_BA_TOL_MONITOR_SC,

        DAQ_ATTR_GATE_BA_ALARM_ACTIVE,
        DAQ_ATTR_GATE_BA_ALARM_MODE,
        DAQ_ATTR_GATE_BA_ALARM_SIGNAL_LENGTH,
        DAQ_ATTR_GATE_BA_ALARM_TIME_LENGTH,
        DAQ_ATTR_GATE_BA_ALARM_ACTIVE_LEVEL,

        DAQ_ATTR_GATE_BA_MEAS_ACTIVE,
        DAQ_ATTR_GATE_BA_MEAS_MODE,


        /**Gate A-I.*/
        DAQ_ATTR_GATE_AI_TOL_MONITOR_ACTIVE = 0x3FF60090,
        DAQ_ATTR_GATE_AI_TOL_MONITOR_MAX,
        DAQ_ATTR_GATE_AI_TOL_MONITOR_MIN,
        DAQ_ATTR_GATE_AI_TOL_MONITOR_SC,

        DAQ_ATTR_GATE_AI_ALARM_ACTIVE,
        DAQ_ATTR_GATE_AI_ALARM_MODE,
        DAQ_ATTR_GATE_AI_ALARM_SIGNAL_LENGTH,
        DAQ_ATTR_GATE_AI_ALARM_TIME_LENGTH,
        DAQ_ATTR_GATE_AI_ALARM_ACTIVE_LEVEL,

        DAQ_ATTR_GATE_AI_MEAS_ACTIVE,
        DAQ_ATTR_GATE_AI_MEAS_MODE,


        /**Gate B-I.*/
        DAQ_ATTR_GATE_BI_TOL_MONITOR_ACTIVE = 0x3FF600a0,
        DAQ_ATTR_GATE_BI_TOL_MONITOR_MAX,
        DAQ_ATTR_GATE_BI_TOL_MONITOR_MIN,
        DAQ_ATTR_GATE_BI_TOL_MONITOR_SC,

        DAQ_ATTR_GATE_BI_ALARM_ACTIVE,
        DAQ_ATTR_GATE_BI_ALARM_MODE,
        DAQ_ATTR_GATE_BI_ALARM_SIGNAL_LENGTH,
        DAQ_ATTR_GATE_BI_ALARM_TIME_LENGTH,
        DAQ_ATTR_GATE_BI_ALARM_ACTIVE_LEVEL,

        DAQ_ATTR_GATE_BI_MEAS_ACTIVE,
        DAQ_ATTR_GATE_BI_MEAS_MODE,


        /**Gate C-I.*/
        DAQ_ATTR_GATE_CI_TOL_MONITOR_ACTIVE = 0x3FF600b0,
        DAQ_ATTR_GATE_CI_TOL_MONITOR_MAX,
        DAQ_ATTR_GATE_CI_TOL_MONITOR_MIN,
        DAQ_ATTR_GATE_CI_TOL_MONITOR_SC,

        DAQ_ATTR_GATE_CI_ALARM_ACTIVE,
        DAQ_ATTR_GATE_CI_ALARM_MODE,
        DAQ_ATTR_GATE_CI_ALARM_SIGNAL_LENGTH,
        DAQ_ATTR_GATE_CI_ALARM_TIME_LENGTH,
        DAQ_ATTR_GATE_CI_ALARM_ACTIVE_LEVEL,

        DAQ_ATTR_GATE_CI_MEAS_ACTIVE,
        DAQ_ATTR_GATE_CI_MEAS_MODE,


        /**DAC POINT.*/
        DAQ_ATTR_DAC_ACTIVE = 0x3FF600c0,
        DAQ_ATTR_DAC_POINT,
        DAQ_ATTR_DAC_FILE, 


        /**Material Velocity.*/
        DAQ_ATTR_MATERIAL_LONGITUDINAL_VELOCITY = 0x3FF600d0,
        DAQ_ATTR_MATERIAL_TRANSVERSE_VELOCITY,
 

        /**PA parameters.*/
        DAQ_ATTR_PA_SEQ_SCAN_REPEAT_MODE = 0x3FF600f0,
        DAQ_ATTR_PA_SCAN_MODE,
        DAQ_ATTR_PA_BEAMFORMER_FILE,
        DAQ_ATTR_PA_REAL_ELEMENT_SIZE,
        DAQ_ATTR_PA_VIRTUAL_ELEMENT_SIZE,
        DAQ_ATTR_PA_SEQ_PERIOD_TIMES,


        /**Pluser Transmit Parameters.*/
        DAQ_ATTR_PLUSER_ACTIVE = 0x3FF60100,
        DAQ_ATTR_PLUSER_DELAY,
        DAQ_ATTR_PLUSER_WIDTH,
        DAQ_ATTR_PLUSER_INTENSITY,
        DAQ_ATTR_PLUSER_DAMPING_ACTIVE,
        DAQ_ATTR_PLUSER_DAMPING_VALUE,
        DAQ_ATTR_TRANSMIT_RECIEVER_MODE,
        DAQ_ATTR_TRANSMIT_PRF,
 

        /**Reciever  parameters.*/
        DAQ_ATTR_RECIEVER_ACTIVE = 0x3FF60110,
        DAQ_ATTR_ANALOG_HPF,
        DAQ_ATTR_ANALOG_LPF,
        DAQ_ATTR_DIGITAL_HPF,
        DAQ_ATTR_DIGITAL_LPF,
        DAQ_ATTR_RECIEVER_PATH,
        DAQ_ATTR_RECIEVER_DAMPING_ACTIVE,
        DAQ_ATTR_RECIEVER_DAMPING_VALUE,
        DAQ_ATTR_ANALOG_GAIN,
 

        /**Back Echo Attenuation.*/
        DAQ_ATTR_BEA_ACTIVE = 0x3FF60120,
  
        /**Reciever parameters.*/
        DAQ_ATTR_RECIEVER_DELAY = 0x3FF60130,
        DAQ_ATTR_RECIEVER_INTENSITY,


        /**ASCAN VIDEO.*/
        DAQ_ATTR_ASCAN_VIDEO_ACTIVE = 0x3FF60140,
        DAQ_ATTR_ASCAN_VIDEO_IF_ACTIVE,
        DAQ_ATTR_ASCAN_VIDEO_DELAY,
        DAQ_ATTR_ASCAN_VIDEO_RANGE,
        DAQ_ATTR_ASCAN_VIDEO_DETECTION_WAVE_MODE,
        DAQ_ATTR_ASCAN_VIDEO_ENVLOPE_ACTIVE,
        DAQ_ATTR_ASCAN_VIDEO_LEN,
        DAQ_ATTR_ASCAN_COMPRESSD_DATA,
 

        /**GLOBAL CONTROL.*/
        DAQ_ATTR_TRIG_MODE = 0x3FF60150,
        DAQ_ATTR_RUN_MODE,
        DAQ_ATTR_PXISTAR_TRIG_START_DELAY,
        DAQ_ATTR_PXISTAR_TRIG_STOP_DELAY,
        DAQ_ATTR_SOFT_START,
        DAQ_ATTR_SOFT_STOP,
        DAQ_ATTR_SOFT_RESET,
 

        /**BOARD REAL-TIME STATUS REG.*/
        DAQ_ATTR_BOARD_STATUS_MACHINE = 0x3FF60160,
        DAQ_ATTR_BOARD_STATUS_ERRCODE,
        DAQ_ATTR_BOARD_BEAT_HEART,
        DAQ_ATTR_ACQ_IN_PROGRESS,
 

        /**BOARD REAL-TIME UPLOAD DATA.*/
        DAQ_ATTR_MEAS_ALARM_ACTIVE = 0x3FF60170,
        DAQ_ATTR_MEAS_ALARM_DISP,


        /**ASCAN VIDEO DATA.*/
        DAQ_ATTR_ASCAN_DATA_UPLOAD_MODE = 0x3FF60180,
        DAQ_ATTR_ASCAN_DATA_UPLOAD_STAMPS,
        DAQ_ATTR_ASCAN_DATA_UPLOAD_TYPE,								  
        DAQ_ATTR_ENVELOP_DATA_UPLOAD_MODE,
        DAQ_ATTR_ENVELOP_DATA_UPLOAD_STAMPS, 
        DAQ_ATTR_ENVELOP_DATA_UPLOAD_TYPE,
        DAQ_ATTR_REALTIME_DATA_UPLOAD_MODE,
        DAQ_ATTR_REALTIME_DATA_UPLOAD_STAMPS,
        DAQ_ATTR_REALTIME_DATA_UPLOAD_TYPE,


        /**Interface type.*/
        DAQ_ATTR_INTERFACE_TYPE = 0x3FF60190,
        DAQ_ATTR_HASRAM,
        DAQ_ATTR_RAMSIZE,
        DAQ_ATTR_CHANNEL,
        DAQ_ATTR_NUM_RTSI_LINES,
        DAQ_ATTR_NUM_RTSI_IN_USE,
        DAQ_ATTR_CLOCK_FREQ,
        DAQ_ATTR_NUM_ISO_IN_LINES,
        DAQ_ATTR_NUM_ISO_OUT_LINES,
        DAQ_ATTR_NUM_POST_TRIGGER_BUFFERS,
        DAQ_ATTR_EXT_TRIG_LINE_FILTER,
        DAQ_ATTR_RTSI_LINE_FILTER = 0x3FF601A1,
        DAQ_ATTR_NUM_PORTS,
        DAQ_ATTR_CURRENT_PORT_NUM,
        DAQ_ATTR_ENCODER_PHASE_A_POLARITY,
        DAQ_ATTR_ENCODER_PHASE_B_POLARITY,
        DAQ_ATTR_ENCODER_PHASE_Z_POLARITY,
        DAQ_ATTR_ENCODER_FILTER,
        DAQ_ATTR_ENCODER_DIVIDE_FACTOR,
        DAQ_ATTR_ENCODER_POSITION,
        DAQ_ATTR_TEMPERATURE = 0x3FF601B0,
 

        /**LED STATUS.*/ 
        DAQ_ATTR_LED_RUN,
        DAQ_ATTR_LED_SYSFAIL,
        DAQ_ATTR_LED_ACESS,
        DAQ_ATTR_LED_FAIL,

        DAQ_ATTR_SYNC_ACQ_DONE,
        DAQ_ATTR_PCI_SLOT_NUMBER,
        DAQ_ATTR_PCI_CLASSIC_NUMBER,


        /**OUT LINE.*/
        DAQ_ATTR_OUT_LINE0_ROUTE = 0x3FF601C0,
        DAQ_ATTR_OUT_LINE1_ROUTE,
        DAQ_ATTR_OUT_LINE2_ROUTE,
        DAQ_ATTR_OUT_LINE3_ROUTE,
        DAQ_ATTR_OUT_LINE4_ROUTE,
        DAQ_ATTR_OUT_LINE5_ROUTE,
        DAQ_ATTR_OUT_LINE6_ROUTE,
        DAQ_ATTR_OUT_LINE7_ROUTE,
        DAQ_ATTR_OUT_LINE8_ROUTE,
        DAQ_ATTR_OUT_LINE9_ROUTE,
        DAQ_ATTR_OUT_LINE10_ROUTE,
        DAQ_ATTR_OUT_LINE11_ROUTE,
        DAQ_ATTR_OUT_LINE12_ROUTE,
        DAQ_ATTR_OUT_LINE13_ROUTE,
        DAQ_ATTR_OUT_LINE14_ROUTE,
        DAQ_ATTR_OUT_LINE15_ROUTE,


        /**IN LINE.*/
        DAQ_ATTR_IN_LINE0_ROUTE = 0x3FF60200,
        DAQ_ATTR_IN_LINE1_ROUTE,
        DAQ_ATTR_IN_LINE2_ROUTE,
        DAQ_ATTR_IN_LINE3_ROUTE,
        DAQ_ATTR_IN_LINE4_ROUTE,
        DAQ_ATTR_IN_LINE5_ROUTE,
        DAQ_ATTR_IN_LINE6_ROUTE,
        DAQ_ATTR_IN_LINE7_ROUTE,
        DAQ_ATTR_IN_LINE8_ROUTE,
        DAQ_ATTR_IN_LINE9_ROUTE,
        DAQ_ATTR_IN_LINE10_ROUTE,
        DAQ_ATTR_IN_LINE11_ROUTE,
        DAQ_ATTR_IN_LINE12_ROUTE,
        DAQ_ATTR_IN_LINE13_ROUTE,
        DAQ_ATTR_IN_LINE14_ROUTE,
        DAQ_ATTR_IN_LINE15_ROUTE,


        /**POS TRIGGER SOURCE.*/
        DAQ_ATTR_POS_TRIG_SOURCE,
        DAQ_ATTR_ENCODER_TRIG_SOURCE,


        /**PLUSER MODULE.*/
        DAQ_PLUSER_MODE,
        DAQ_PLUSER_TIMEBASE,
        DAQ_PLUSER_REARM_SOURCE,

        /**TESOUT.*/
        DAQ_TESOUT_ACTIVE,
        DAQ_TESOUT_FREQ,
        DAQ_TESOUT_MODE,

        /**POWER MANAGMENT FOR PA BOARD.*/						   
        DAQ_HV_POWER_EN,
        DAQ_OPTOCOUPLER_POWER_EN,
        DAQ_OPA_POWER_EN,
        DAQ_TESTOUT_POWER_EN,
        DAQ_12VP_POWER_EN,
        DAQ_ETHERNET_POWER_EN,
        DAQ_SERIAL_POWER_EN,
 

        /**Acquire Function.*/
        DAQ_ATTR_ACQUIRE_MODE,
        DAQ_ATTR_FRAME_COUNT,
        DAQ_ATTR_LAST_VALID_BUFFER,

        DAQ_ATTR_FRAMEWAIT_MSEC,

        DAQ_ATTR_NUM_BUFFERS,
        DAQ_ATTR_LOST_FRAMES,
        DAQ_ATTR_LAST_ACTIVE_FRAME,
        
        DAQ_ATTR_LAST_ACQUIRED_BUFFER_NUM,
        DAQ_ATTR_LAST_ACQUIRED_BUFFER_INDEX,
        DAQ_ATTR_LAST_TRANSFERRED_BUFFER_NUM,
        DAQ_ATTR_LAST_TRANSFERRED_BUFFER_INDEX,
        DAQ_ATTR_LAST_ACTIVE_BUFFER,

        DAQ_DSP_LOADFILE_DOWN_ADDR,
        DAQ_DSP_LOADFILE_RUN_ADDR
    }
    #endregion

    /**ENUMS:Testing mode.*/
    public enum DAQ_UT_TESTING_MODE
    {
        DAQ_UT_TESTING_MODE_UT,
        DAQ_UT_TESTING_MODE_PA
    }

    /**ENUMS: TOF Unit for  Gate I,A,B,C etc.*/
    public enum DAQ_TOF_UNIT_TYPE
    {
        DAQ_TOF_UNIT_mm,
        DAQ_TOF_UNIT_us
    }

    /**ENUMS:Amplitude Unit for  Gate I,A,B,C etc.*/
    public enum DAQ_AMP_UNIT_TYPE
    {
        DAQ_AMP_UNIT_PERCENT,
        DAQ_AMP_UNIT_dB
    }

    /**ENUM:Interface Echo Tracking on/off.*/
    public enum DAQ_IF_ACTIVE
    {
        DAQ_IF_ACTIVE_OFF,
        DAQ_IF_ACTIVE_ON
    }

    /**ENUM:Gate TOF detection mode.*/
    public enum DAQ_GATE_MODE
    {
        DAQ_GATE_MODE_PEAK,
        DAQ_GATE_MODE_FIRST_PEAK,
        DAQ_GATE_MODE_FLANK,
        DAQ_GATE_MODE_ZERO_BEFORE,
        DAQ_GATE_MODE_ZERO_AFTER
    }

    /**ENUM:Dynamic noise suppressing on/off.*/
    public enum DAQ_GATE_DNS_ACTIVE
    {
        DAQ_GATE_DNS_OFF,
        DAQ_GATE_DNS_ON
    }

    /**ENUMS:Gate Alarm logic.*/
    public enum DAQ_GATE_ALARM_LOGIC_TYPE
    {
        DAQ_GATE_ALARM_NEGATIVE,
        DAQ_GATE_ALARM_POSITIVE
    }

    /**ENUMS:Gate Supress counter on/off.*/
    public enum DAQ_GATE_SC_ACTIVE
    {
        DAQ_GATE_SC_OFF,
        DAQ_GATE_SC_ON
    }

    /**ENUMS:Gate Dynamic threld on/off.*/
    public enum DAQ_GATE_DYNAMIC_THRELD_ACTIVE
    {
        DAQ_GATE_DYNAMIC_THRELD_OFF,
        DAQ_GATE_DYNAMIC_THRELD_ON
    }

    /**ENUMS:ASCAN video detection wave mode.*/
    public enum ASCAN_VIDEO_WAVE_MODE
    {
        DAQ_GATE_TOL_MONITOR_OFF,
        DAQ_GATE_TOL_MONITOR_ON
    }

    /**ENUMS:Gate I,A,B,C alarm on/off  enums.*/
    public enum DAQ_GATE_ALARM_ACTIVE
    {
        DAQ_GATE_ALARM_ON,
        DAQ_GATE_ALARM_OFF,
        DAQ_GATE_ALARM_TEST
    }

    /**ENUMS:Gate I,A,B,C alarm mode.*/
    public enum DAQ_GATE_ALARM_MODE
    {
        DAQ_GATE_ALARM_TOF_MIN,
        DAQ_GATE_ALARM_TOF_MAX,
        DAQ_GATE_ALARM_AMP_THRELD,
        DAQ_GATEALARM_OUT_AGC_RANGE
    }

    /**ENUMS:Gate BA,AI,BI,CI alarm mode  enums.*/
    public enum DAQ_GATE2_ALARM_MODE
    {
        DAQ_2GATE_ALARM_THICKNESS_MIN,
        DAQ_2GATE_ALARM_THICKNESS_MAX,
        DAQ_2GATE_ALARM_INVALID_VALUE
    }

    /**ENUMS:Gate alarm signal length enums.*/
    public enum DAQ_GATE_SIGNAL_LENGTH
    {
        DAQ_GATE_ALARM_SIGNAL_LENGTH_TIMED,
        DAQ_GATE_ALARM_SIGNAL_LENGTH_HOLD,
        DAQ_GATE_ALARM_SIGNAL_LENGTH_ONE_PRF,
        DAQ_GATE_ALARM_SIGNAL_LENGTH_AUTO_CLR
    }

    /**ENUMS:Gate alarm output level high or low is active.*/
    public enum DAQ_GATE_ALARM_LEVEL
    {
        DAQ_GATE_ALARM_LEVEL_LOW,
        DAQ_GATE_ALARM_LEVEL_HIGH
    }

    /**ENUMS:Gate I,A,B,C, B-A,A-I,B-I,C-I measment on/off.*/
    public enum DAQ_GATE_MEAS_ACTIVE
    {
        DAQ_GATE_MEAS_OFF,
        DAQ_GATE_MEAS_ON
    }

    /**ENUMS:Gate I,A,B,C measment mode.*/
    public enum DAQ_GATE_MEAS_MODE
    {
        DAQ_GATE_MEAS_NONE,
        DAQ_GATE_MEAS_TOF_PEAK,
        DAQ_GATE_MEAS_TOF_MAX,
        DAQ_GATE_MEAS_TOF_MIN,
        DAQ_GATE_MEAS_AMP_PERCENT,
        DAQ_GATE_MEAS_AMP_dB,
        DAQ_GATE_MEAS_SURFACE_DISTANCE,
        DAQ_GATE_MEAS_REDUCTED_SURFACE_DISTANCE,
        DAQ_GATE_MEAS_DEPTH,
        DAQ_GATE_MEAS_LEG,
        DAQ_GATE_MEAS_AMP_TO_DAC_PERCENT,
        DAQ_GATE_MEAS_AMP_TO_DAC_dB,
        DAQ_GATE_MEAS_GATEIN_DATA
    }

    /**ENUMS:DAC on/off.*/
    public enum DAQ_DAC_ACTIVE
    {
        DAQ_DAC_OFF,
        DAQ_DAC_ON
    }

    /**ENUMS:PA repeat mode.*/
    public enum DAQ_PA_SEQ_SCAN_REPEAT_MODE
    {
        DAQ_PA_SEQ_SCAN_REPEAT_ONE_SLOT,
        DAQ_PA_SEQ_SCAN_REPEAT_CYCLE,
        DAQ_PA_SEQ_SCAN_REPEAT_RETURN_START
    }

    /**ENUMS:PA scan mode.*/
    public enum DAQ_PA_SEQ_SCAN_MODE
    {
        DAQ_PA_SEQ_SCAN_LINEAR,
        DAQ_PA_SEQ_SCAN_SECTOR,
        DAQ_PA_SEQ_SCAN_VRETICAL,
        DAQ_PA_SEQ_SCAN_UNUSUAL,
        DAQ_PA_SEQ_SCAN_FMC
    }

    /**ENUMS: Pluser enable on/off.*/
    public enum DAQ_PLUSER_ACTIVE
    {
        DAQ_PLUSER_ACTIVE_OFF,
        DAQ_PLUSER_ACTIVE_ON
    }

    /**ENUMS: Pluser damping on/off.*/
    public enum DAQ_PLUSER_DAMPING_ACTIVE
    {
        DAQ_PLUSER_DAMPING_OFF,
        DAQ_PLUSER_DAMPING_ON
    }

    /**ENUMS:Pluser transimit and recieve mode.*/
    public enum DAQ_TRANSMIT_RECIEVER_TYPE
    {
        DAQ_TRANSMIT_RECIEVER_PE,
        DAQ_TRANSMIT_RECIEVER_PC
    }

    /**ENUMS:Reciever  on/off.*/
    public enum DAQ_RECIEVER_ACTIVE
    {
        DAQ_RECIEVER_ACTIVE_OFF,
        DAQ_RECIEVER_ACTIVE_ON
    }

    /**ENUMS: Reciever path channel select.*/
    public enum DAQ_RECIEVER_PATH
    {
        DAQ_RECIEVER_NORMAL,
        DAQ_RECIEVER_TESTIN,
        DAQ_RECIEVER_HVSENSE
    }

    /**ENUMS: Pluser damping on/off.*/
    public enum DAQ_RECIEVER_DAMPING_ACTIVE
    {
        DAQ_RECIEVER_DAMPING_OFF,
        DAQ_RECIEVER_DAMPING_ON
    }

    /**ENUMS: Back Echo Attenuation on/off.*/
    public enum DAQ_BEA_ACTIVE
    {
        DAQ_BEA_ACTIVE_OFF,
        DAQ_BEA_ACTIVE_ON
    }

    /**ENUMS:ASCAN video active.*/
    public enum DAQ_ASCAN_VIDEO_ACTIVE
    {
        DAQ_ASCAN_VIDEO_ACTIVE_OFF,
        DAQ_ASCAN_VIDEO_ACTIVE_ON
    }

    /**ENUMS: wave detection mode.*/
    public enum DAQ_ASCAN_VIDEO_DETECTION_WAVE_MODE
    {
        DAQ_RF,
        DAQ_FULL,
        DAQ_SEMI_POSITIVE,
        DAQ_SEMI_NEGTIVE
    }

    /**ENUMS: envlope is active.*/
    public enum DAQ_ASCAN_VIDEO_ENVLOPE_ACTIVE
    {
        DAQ_ENVLOPE_OFF,
        DAQ_ENVLOPE_ON
    }

    /**ENUMS: ASCAN video length mode.*/
    public enum DAQ_ASCAN_VIDEO_LEN
    {
        DAQ_ASCAN_VIDEO_LEN_512 = 512,
        DAQ_ASCAN_VIDEO_LEN_1024 = 1024
    }

    /**ENUMS:Ascan data e compressed on/off.*/
    public enum ASCAN_COMPRESSD_ACTIVE
    {
        ASCAN_COMPRESSD_DATA_OFF,
        ASCAN_COMPRESSD_DATA_ON
    }

    /**ENUMS: PRF trig mode.*/
    public enum DAQ_TRIG_MODE
    {
        DAQ_TRIG_SOFT = 1,
        DAQ_TRIG_POS,
        DAQ_TRIG_ENCODER,
        DAQ_TRIG_EXTERNAL,
        DAQ_TRIG_PXI_STAR,
        DAQ_TRIG_THRELD
    }

    /**ENUMS: Run mode.*/
    public enum DAQ_RUN_MODE
    {
        DAQ_AUTO,
        DAQ_CHECK_MODE,
        DAQ_MANUL_MODE
    }

    /**ENUMS: Soft start.*/
    public enum DAQ_SOFT_START
    {
        DAQ_SOFT_START_OFF,
        DAQ_SOFT_START_ON
    }

    /**ENUMS: Soft stop.*/
    public enum DAQ_SOFT_STOP
    {
        DAQ_SOFT_STOP_OFF,
        DAQ_SOFT_STOP_ON
    }

    /**ENUMS: Soft Reset on/off.*/
    public enum DAQ_SOFT_RESET
    {
        DAQ_SOFT_RESET_OFF,
        DAQ_SOFT_RESET_ON
    }

    /**ENUMS: Board status machine.*/
    public enum DAQ_BOARD_STATUS_MACHINE
    {
        DAQ_BOARD_STATUS_MACHINE_RESETTING,
        DAQ_BOARD_STATUS_MACHINE_IDLE,
        DAQ_BOARD_STATUS_MACHINE_RUNNING,
        DAQ_BOARD_STATUS_MACHINE_ERROR
    }

    /**ENUMS: acq is inprogress.*/
    public enum DAQ_ACQ_IN_PROGRESS_ACTIVE
    {
        DAQ_ACQ_IN_PROGRESS_OFF,
        DAQ_ACQ_IN_PROGRESS_ON
    }

    /**ENUM:  Alarm disp meas on/off.*/
    public enum DAQ_MEAS_ALARM_ACTIVE
    {
        DAQ_MEAS_ALARM_OFF,
        DAQ_MEAS_ALARM_ON
    }

    /**ENUM: Data upload mode.*/
    public enum DAQ_DATA_UPLOAD_MODE
    {
        DAQ_ASCAN_DATA_UPLOAD_STAMPS_PRF,
        DAQ_ASCAN_DATA_UPLOAD_STAMPS_POS,
        DAQ_ASCAN_DATA_UPLOAD_STAMPS_ENC,
        DAQ_PA_SEQ_SCAN_REPEAT_RETURN_TIMED
    }

    /**ENUMS:Ascan and envlop data upload data type.*/
    public enum VIDEO_DATA_UPLOAD_TYPE
    {
        VIDEO_DATA_UPLOAD_TYPE_SCHAR,
        VIDEO_DATA_UPLOAD_TYPE_INT32,
        VIDEO_DATA_UPLOAD_TYPE_FLOAT
    }

    /**ENUM: Daq interface type.*/
    public enum DAQ_INTERFACE_TYPE
    {
        DAQ_INTERFACE_TYPE_PXI,
        DAQ_INTERFACE_TYPE_ETHERNET,
        DAQ_INTERFACE_TYPE_SERIAL
    }

    /**ENUMS: line filter on/off .*/
    public enum DAQ_LINE_FILTER
    {
        DAQ_LINE_FILTER_OFF,
        DAQ_LINE_FILTER_ON
    }

    /**ENUMS: Pulse polarities.*/
    public enum DAQ_PULSE_POLAR
    {
        DAQ_PULSE_POLAR_ACTIVEL,
        DAQ_PULSE_POLAR_ACTIVEH
    }

    /**ENUMS: LED States.*/
    public enum DAQ_LED_STATE
    {
        DAQ_LED_OFF,
        DAQ_LED_ON
    }

    /**ENUMS:acquire indicator.*/
    public enum SYNC_ACQ_DONE
    {
        SYNC_ACQ_DONE_DONE,
        SYNC_ACQ_DONE_INPROGRESS
    }

    #region
    /**ENUMS: OPTOCOUPLER OUTPUT ROUTE TO WCHICH ALARM GATE SOURCE DEFINATION.*/
    public enum DAQ_OUT_LINE_ROUTE
    {
        DAQ_OUT_LINE_ROUTE_NONE,
        DAQ_OUT_LINE_ROUTE_I_GATE_ALARM,
        DAQ_OUT_LINE_ROUTE_A_GATE_ALARM,
        DAQ_OUT_LINE_ROUTE_B_GATE_ALARM,
        DAQ_OUT_LINE_ROUTE_C_GATE_ALARM,
        DAQ_OUT_LINE_ROUTE_BA_GATE_ALARM,
        DAQ_OUT_LINE_ROUTE_AI_GATE_ALARM,
        DAQ_OUT_LINE_ROUTE_BI_GATE_ALARM,
        DAQ_OUT_LINE_ROUTE_CI_GATE_ALARM,
        DAQ_OUT_LINE_ROUTE_READY_HANDSHAKE,

        DAQ_OUT_LINE_ROUTE_EN_X_DIRECTION,
        DAQ_OUT_LINE_ROUTE_DIR_X_DIRECTION,
        DAQ_OUT_LINE_ROUTE_STEP_X_DIRECTION,
	
        DAQ_OUT_LINE_ROUTE_EN_Y_DIRECTION,
        DAQ_OUT_LINE_ROUTE_DIR_Y_DIRECTION,
        DAQ_OUT_LINE_ROUTE_STEP_Y_DIRECTION,
	
        DAQ_OUT_LINE_ROUTE_EN_Z_DIRECTION,
        DAQ_OUT_LINE_ROUTE_DIR_Z_DIRECTION,
        DAQ_OUT_LINE_ROUTE_STEP_Z_DIRECTION,
        DAQ_OUT_LINE_ROUTE_GOTO_ZERO,
	
        DAQ_OUT_LINE_ROUTE_PXI_STAR_TRIG_LINE,
        DAQ_OUT_LINE_ROUTE_PXI_TRIG_LINE0,
        DAQ_OUT_LINE_ROUTE_PXI_TRIG_LINE1,
        DAQ_OUT_LINE_ROUTE_PXI_TRIG_LINE2,
        DAQ_OUT_LINE_ROUTE_PXI_TRIG_LINE3,
        DAQ_OUT_LINE_ROUTE_PXI_TRIG_LINE4,
        DAQ_OUT_LINE_ROUTE_PXI_TRIG_LINE5,
        DAQ_OUT_LINE_ROUTE_PXI_TRIG_LINE6,
        DAQ_OUT_LINE_ROUTE_PXI_TRIG_LINE7,

        DAQ_OUT_LINE_ROUTE_PXI_LBL0, 
        DAQ_OUT_LINE_ROUTE_PXI_LBL1,
        DAQ_OUT_LINE_ROUTE_PXI_LBL2,
        DAQ_OUT_LINE_ROUTE_PXI_LBL3,
        DAQ_OUT_LINE_ROUTE_PXI_LBL4, 
        DAQ_OUT_LINE_ROUTE_PXI_LBL5,
        DAQ_OUT_LINE_ROUTE_PXI_LBL6,
        DAQ_OUT_LINE_ROUTE_PXI_LBL7,
        DAQ_OUT_LINE_ROUTE_PXI_LBL8,
        DAQ_OUT_LINE_ROUTE_PXI_LBL9,
        DAQ_OUT_LINE_ROUTE_PXI_LBL10,
        DAQ_OUT_LINE_ROUTE_PXI_LBL11,
        DAQ_OUT_LINE_ROUTE_PXI_LBL12,
	
        DAQ_OUT_LINE_ROUTE_PXI_LBR0, 
        DAQ_OUT_LINE_ROUTE_PXI_LBR1,
        DAQ_OUT_LINE_ROUTE_PXI_LBR2,
        DAQ_OUT_LINE_ROUTE_PXI_LBR3,
        DAQ_OUT_LINE_ROUTE_PXI_LBR4,
        DAQ_OUT_LINE_ROUTE_PXI_LBR5, 
        DAQ_OUT_LINE_ROUTE_PXI_LBR6, 
        DAQ_OUT_LINE_ROUTE_PXI_LBR7,
        DAQ_OUT_LINE_ROUTE_PXI_LBR8,
        DAQ_OUT_LINE_ROUTE_PXI_LBR9,
        DAQ_OUT_LINE_ROUTE_PXI_LBR10,
        DAQ_OUT_LINE_ROUTE_PXI_LBR11,
        DAQ_OUT_LINE_ROUTE_PXI_LBR12,
	
        DAQ_OUT_LINE_ROUTE_PXI_AD32,
        DAQ_OUT_LINE_ROUTE_PXI_AD33, 
        DAQ_OUT_LINE_ROUTE_PXI_AD34,
        DAQ_OUT_LINE_ROUTE_PXI_AD35,
        DAQ_OUT_LINE_ROUTE_PXI_AD36,
        DAQ_OUT_LINE_ROUTE_PXI_AD37,
        DAQ_OUT_LINE_ROUTE_PXI_AD38,
        DAQ_OUT_LINE_ROUTE_PXI_AD39,
        DAQ_OUT_LINE_ROUTE_PXI_AD40,
        DAQ_OUT_LINE_ROUTE_PXI_AD41,
        DAQ_OUT_LINE_ROUTE_PXI_AD42,
        DAQ_OUT_LINE_ROUTE_PXI_AD43,
        DAQ_OUT_LINE_ROUTE_PXI_AD44,
        DAQ_OUT_LINE_ROUTE_PXI_AD45,
        DAQ_OUT_LINE_ROUTE_PXI_AD46,
        DAQ_OUT_LINE_ROUTE_PXI_AD47,
        DAQ_OUT_LINE_ROUTE_PXI_AD48,
        DAQ_OUT_LINE_ROUTE_PXI_AD49,
        DAQ_OUT_LINE_ROUTE_PXI_AD50,
        DAQ_OUT_LINE_ROUTE_PXI_AD51,
        DAQ_OUT_LINE_ROUTE_PXI_AD52,
        DAQ_OUT_LINE_ROUTE_PXI_AD53,
        DAQ_OUT_LINE_ROUTE_PXI_AD54,
        DAQ_OUT_LINE_ROUTE_PXI_AD55,
        DAQ_OUT_LINE_ROUTE_PXI_AD56,
        DAQ_OUT_LINE_ROUTE_PXI_AD57,
        DAQ_OUT_LINE_ROUTE_PXI_AD58,
        DAQ_OUT_LINE_ROUTE_PXI_AD59,
        DAQ_OUT_LINE_ROUTE_PXI_AD60,
        DAQ_OUT_LINE_ROUTE_PXI_AD61,
        DAQ_OUT_LINE_ROUTE_PXI_AD62,
        DAQ_OUT_LINE_ROUTE_PXI_AD63,

        DAQ_OUT_LINE_ROUTE_INLINE0,
        DAQ_OUT_LINE_ROUTE_INLINE1,
        DAQ_OUT_LINE_ROUTE_INLINE2,
        DAQ_OUT_LINE_ROUTE_INLINE3,
        DAQ_OUT_LINE_ROUTE_INLINE4,
        DAQ_OUT_LINE_ROUTE_INLINE5,
        DAQ_OUT_LINE_ROUTE_INLINE6,
        DAQ_OUT_LINE_ROUTE_INLINE7,
        DAQ_OUT_LINE_ROUTE_INLINE8,
        DAQ_OUT_LINE_ROUTE_INLINE9,
        DAQ_OUT_LINE_ROUTE_INLINE10,
        DAQ_OUT_LINE_ROUTE_INLINE11, 
        DAQ_OUT_LINE_ROUTE_INLINE12,
        DAQ_OUT_LINE_ROUTE_INLINE13,
        DAQ_OUT_LINE_ROUTE_INLINE14,
        DAQ_OUT_LINE_ROUTE_INLINE15  
    }
    #endregion

    #region
    /**OPTOCOUPLER INPUT ROUTE TO WCHICH ALARM GATE SOURCE DEFINATION.*/
    public enum DAQ_IN_LINE_ROUTE
    {
        DAQ_IN_LINE_ROUTE_NONE,
        DAQ_IN_LINE_ROUTE_ROTOR_ENCODER_A,
        DAQ_IN_LINE_ROUTE_ROTOR_ENCODER_B,
        DAQ_IN_LINE_ROUTE_ROTOR_ENCODER_Z,
	
        DAQ_IN_LINE_ROUTE_mm_ENCODER_A, 
        DAQ_IN_LINE_ROUTE_mm_ENCODER_B,
        DAQ_IN_LINE_ROUTE_mm_ENCODER_Z,
        DAQ_IN_LINE_ROUTE_START,
        DAQ_IN_LINE_ROUTE_STOP,
        DAQ_IN_LINE_ROUTE_ALARM_CLK,
        DAQ_IN_LINE_ROUTE_EXT_TRIG, 
	
        DAQ_IN_LINE_ROUTE_X_ENCODER_A,
        DAQ_IN_LINE_ROUTE_X_ENCODER_B,
        DAQ_IN_LINE_ROUTE_X_ENCODER_Z,
	
        DAQ_IN_LINE_ROUTE_Y_ENCODER_A,
        DAQ_IN_LINE_ROUTE_Y_ENCODER_B,
        DAQ_IN_LINE_ROUTE_Y_ENCODER_Z, 
	
        DAQ_IN_LINE_ROUTE_Z_ENCODER_A,
        DAQ_IN_LINE_ROUTE_Z_ENCODER_B,
        DAQ_IN_LINE_ROUTE_Z_ENCODER_Z,
	
        DAQ_IN_LINE_ROUTE_PXI_STAR_TRIG_LINE,
        DAQ_IN_LINE_ROUTE_PXI_TRIG_LINE0, 
        DAQ_IN_LINE_ROUTE_PXI_TRIG_LINE1,
        DAQ_IN_LINE_ROUTE_PXI_TRIG_LINE2,
        DAQ_IN_LINE_ROUTE_PXI_TRIG_LINE3,
        DAQ_IN_LINE_ROUTE_PXI_TRIG_LINE4,
        DAQ_IN_LINE_ROUTE_PXI_TRIG_LINE5,
        DAQ_IN_LINE_ROUTE_PXI_TRIG_LINE6,
        DAQ_IN_LINE_ROUTE_PXI_TRIG_LINE7,
	
        DAQ_IN_LINE_ROUTE_PXI_LBL0,
        DAQ_IN_LINE_ROUTE_PXI_LBL1, 
        DAQ_IN_LINE_ROUTE_PXI_LBL2,
        DAQ_IN_LINE_ROUTE_PXI_LBL3,
        DAQ_IN_LINE_ROUTE_PXI_LBL4,
        DAQ_IN_LINE_ROUTE_PXI_LBL5,
        DAQ_IN_LINE_ROUTE_PXI_LBL6,
        DAQ_IN_LINE_ROUTE_PXI_LBL7, 
        DAQ_IN_LINE_ROUTE_PXI_LBL8,
        DAQ_IN_LINE_ROUTE_PXI_LBL9,
        DAQ_IN_LINE_ROUTE_PXI_LBL10,
        DAQ_IN_LINE_ROUTE_PXI_LBL11,
        DAQ_IN_LINE_ROUTE_PXI_LBL12,
	
        DAQ_IN_LINE_ROUTE_PXI_LBR0,
        DAQ_IN_LINE_ROUTE_PXI_LBR1,
        DAQ_IN_LINE_ROUTE_PXI_LBR2,
        DAQ_IN_LINE_ROUTE_PXI_LBR3,
        DAQ_IN_LINE_ROUTE_PXI_LBR4,
        DAQ_IN_LINE_ROUTE_PXI_LBR5,
        DAQ_IN_LINE_ROUTE_PXI_LBR6,
        DAQ_IN_LINE_ROUTE_PXI_LBR7,
        DAQ_IN_LINE_ROUTE_PXI_LBR8, 
        DAQ_IN_LINE_ROUTE_PXI_LBR9,
        DAQ_IN_LINE_ROUTE_PXI_LBR10,
        DAQ_IN_LINE_ROUTE_PXI_LBR11,
        DAQ_IN_LINE_ROUTE_PXI_LBR12,
	
        DAQ_IN_LINE_ROUTE_PXI_AD32,
        DAQ_IN_LINE_ROUTE_PXI_AD33,
        DAQ_IN_LINE_ROUTE_PXI_AD34,
        DAQ_IN_LINE_ROUTE_PXI_AD35,
        DAQ_IN_LINE_ROUTE_PXI_AD36,
        DAQ_IN_LINE_ROUTE_PXI_AD37,
        DAQ_IN_LINE_ROUTE_PXI_AD38, 
        DAQ_IN_LINE_ROUTE_PXI_AD39,
        DAQ_IN_LINE_ROUTE_PXI_AD40,
        DAQ_IN_LINE_ROUTE_PXI_AD41, 
        DAQ_IN_LINE_ROUTE_PXI_AD42,
        DAQ_IN_LINE_ROUTE_PXI_AD43,
        DAQ_IN_LINE_ROUTE_PXI_AD44,
        DAQ_IN_LINE_ROUTE_PXI_AD45,
        DAQ_IN_LINE_ROUTE_PXI_AD46, 
        DAQ_IN_LINE_ROUTE_PXI_AD47,
        DAQ_IN_LINE_ROUTE_PXI_AD48,
        DAQ_IN_LINE_ROUTE_PXI_AD49,
        DAQ_IN_LINE_ROUTE_PXI_AD50,
        DAQ_IN_LINE_ROUTE_PXI_AD51, 
        DAQ_IN_LINE_ROUTE_PXI_AD52, 
        DAQ_IN_LINE_ROUTE_PXI_AD53,
        DAQ_IN_LINE_ROUTE_PXI_AD54,
        DAQ_IN_LINE_ROUTE_PXI_AD55,
        DAQ_IN_LINE_ROUTE_PXI_AD56,
        DAQ_IN_LINE_ROUTE_PXI_AD57,
        DAQ_IN_LINE_ROUTE_PXI_AD58, 
        DAQ_IN_LINE_ROUTE_PXI_AD59,
        DAQ_IN_LINE_ROUTE_PXI_AD60,
        DAQ_IN_LINE_ROUTE_PXI_AD61, 
        DAQ_IN_LINE_ROUTE_PXI_AD62,
        DAQ_IN_LINE_ROUTE_PXI_AD63
    }
    #endregion

    /**ENUMS:Pos encoder trig source select.*/
    public enum POS_ENC_TRIG_SOURCE
    {
        TRIG_SOURCE_NONE,
        TRIG_SOURCE_ROTOR_ENCODER_A,
        TRIG_SOURCE_ROTOR_ENCODER_B,
        TRIG_SOURCE_ROTOR_ENCODER_Z,

        TRIG_SOURCE_mm_ENCODER_A,
        TRIG_SOURCE_mm_ENCODER_B,
        TRIG_SOURCE_mm_ENCODER_Z,
        TRIG_SOURCE_START,
        TRIG_SOURCE_STOP,
        TRIG_SOURCE_ALARM_CLK,
        TRIG_SOURCE_EXT_TRIG,
	
        TRIG_SOURCE_X_ENCODER_A,
        TRIG_SOURCE_X_ENCODER_B,
        TRIG_SOURCE_X_ENCODER_Z,
	
        TRIG_SOURCE_Y_ENCODER_A,
        TRIG_SOURCE_Y_ENCODER_B,
        TRIG_SOURCE_Y_ENCODER_Z,
	
        TRIG_SOURCE_Z_ENCODER_A,
        TRIG_SOURCE_Z_ENCODER_B,
        TRIG_SOURCE_Z_ENCODER_Z,
	
        TRIG_SOURCE_PXI_STAR_TRIG_LINE,
        TRIG_SOURCE_PXI_TRIG_LINE0, 
        TRIG_SOURCE_PXI_TRIG_LINE1, 
        TRIG_SOURCE_PXI_TRIG_LINE2,
        TRIG_SOURCE_PXI_TRIG_LINE3,
        TRIG_SOURCE_PXI_TRIG_LINE4,
        TRIG_SOURCE_PXI_TRIG_LINE5,
        TRIG_SOURCE_PXI_TRIG_LINE6,
        TRIG_SOURCE_PXI_TRIG_LINE7 
    }

    /**ENUMS: Pulse mode.*/
    public enum DAQ_PLUSER_MODE
    {
        DAQ_PULSE_MODE_TRAIN = 1,
        DAQ_PULSE_MODE_SINGLE,
        DAQ_PULSE_MODE_SINGLE_REARM
    }

    /**ENUMS: Pulse timebases.*/
    public enum DAQ_PLUSER_TIMEBASE
    {
        DAQ_PULSE_TIMEBASE_10MHZ = 1,
        DAQ_PULSE_TIMEBASE_50MHZ,
        DAQ_PULSE_TIMEBASE_MM,
        DAQ_PULSE_TIMEBASE_ENCODER
    }

    /**ENUMS: Pulse Rearm source.*/
    public enum DAQ_PLUSER_REARM_SOURCE
    {
        DAQ_ACQ_DONE = 1,
        DAQ_BUF_COMPLETE,
        DAQ_FIXED_FREQUENCY
    }

    /**ENUMS: testout on/off.*/
    public enum DAQ_TESOUT_ACTIVE
    {
        DAQ_TESOUT_OFF,
        DAQ_TESOUT_ON
    }

    /**ENUMS: testout mode.*/
    public enum DAQ_TESOUT_MODE
    {
        DAQ_TESOUT_ASCAN,
        DAQ_TESOUT_SINE
    }

    /**ENUMS: Power on/off for PA .*/
    public enum DAQ_POWER_ACTIVE
    {
        DAQ_POWER_OFF,
        DAQ_POWER_ON
    }

    public enum DAQ_TYPE
    {
        DAQ_UINT_TYPE,
        DAQ_INT_TYPE,
        DAQ_FLOAT_TYPE,
        DAQ_DOUBLE_TYPE,
        DAQ_DAC_FILE_TYPE,
        DAQ_BM_FILE_TYPE,
        DAQ_OTHERS_TYPE
    }

    //Packet ID
    public enum PacketId
    {
        none = 0,
        IGate = 1,
        AGate = 2,
        BGate = 4,
        CGate = 8,
        BA2Gate = 16,
        AI2Gate = 32,
        BI2Gate = 64,
        CI2Gate = 128,
        alarmDisp = 256,
        ascanVedio = 512,
        status = 1024,
        eventId = 2048,
        couple = 4096
    }

    //Packet Bin
    public enum DAQ_MEAS_MODE 
    {
        NONE = 0,
        TOF_PEAK = 1, //Cscan TOF
        TOF_MAX = 2,
        TOF_MIN = 4,
        AMP_PERCENT = 8, //Cscan amp
        AMP_dB = 16,
        SURFACE_DISTANCE = 32,
        REDUCTED_SURFACE_DISTANCE = 64,
        DEPTH = 128,
        LEG = 256,
        AMP_TO_DAC_PERCENT = 512,
        AMP_TO_DAC_dB = 1024,
        GATEIN_DATA = 2048
    }

    public enum DAQ_EVENT
    {
        START_EVENT = 1,
        STOP_EVENT = 2
    }
}
