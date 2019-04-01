using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Ascan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DACParas
    {
        public uint dac_on;
        public uint dac_point_num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public float[] dac_tofs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public float[] dac_amps;
        public uint dac_mode;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct IdTarget
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] version;
        public uint id;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] sn;
        public char mac;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct StructBeamFile
    {
        public uint beamIndex;
	
	    //transmit
        public uint txSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] txElementBin;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public float[] txDelay;
	    //Double txIntensify[DAQ_MAX_PA_ELEMENT];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public float[] txIntensify;

	    //reciever
        public uint rxSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] rxElementBin;
	
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public float[] rxDelay;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public float[] rxIntensify;

        public float gain;

        public uint txEn;

        public uint rxOn;

        public uint digitalHpf;

        public uint dampOn;

        public uint dampValue;

        public uint path;

        public uint digitalLpf;

        public uint beaOn;
	
	    //Uint32 ctrl;
	    //BIT0      BIT1      [7:2]                BIT8           BIT[15:9]           BIT16   [17:23]         [24]
	    //TXEN     RXON     digital_hpf        DAMP_ON    DAMP_VALUE     PATH    digital_lpf       BEAON


        public DACParas dac;
    }
//added by xll at 2017/3/2
    [Serializable]
    public class ClassBasicSetting
    {
        public int savemode;

        public int boradcount;
        public double[] startdelay;
        public double[] stopdelay;
        public double[] prf;
        public string[] assignname;
        public string[] trigmode;
        public string[] function;

        public int[] virtualcount;
        public string[,] assignedname;
        public string[,] beamformerpath;
        public string[,] beamformername;

        public List<ClassBeamFile> beamlist;
        public List<ClassChanpara> chanPara;

        public ClassBasicSetting()
        {
            savemode = 0;
            boradcount = 0;
            assignname = new string[4];
            startdelay = new double[4];
            stopdelay = new double[4];
            prf = new double[4];
            trigmode = new string[4];
            function = new string[4];

            virtualcount = new int[16];
            assignedname = new string[4, 16];
            beamformerpath = new string[4,16];
            beamformername = new string[4,16];
            beamlist = new List<ClassBeamFile>();
            chanPara = new List<ClassChanpara>();
        }

    }
//added by xll at 2017/3/2
    [Serializable]
    public class ClassBeamFile
    {
        public uint beamIndex;

        public uint txSize;
        public uint[] txElementBin;
        public float[] txDelay;
        public float[] txIntensify;

        public uint rxSize;
        public uint[] rxElementBin;
        public float[] rxDelay;
        public float[] rxIntensify;

        public float gain;
        public uint txEn;
        public uint rxOn;
        public uint digitalHpf;
        public uint dampOn;
        public uint dampValue;
        public uint path;
        public uint digitalLpf;
        public uint beaOn;

        public uint dac_on;
        public uint dac_point_num;
        public float[] dac_tofs;
        public float[] dac_amps;
        public uint dac_mode;

        public ClassBeamFile()
        {
            beamIndex = 0;
            txSize = 0;
            txElementBin = new uint[8];
            txDelay = new float[256];
            txIntensify = new float[256];

            rxSize = 0;
            rxElementBin = new uint[8];
            rxDelay = new float[256];
            rxIntensify = new float[256];

            gain = 0;
            txEn = 0;
            rxOn = 0;
            digitalHpf = 0;
            dampOn = 0;
            dampValue = 0;
            path = 0;
            digitalLpf = 0;
            beaOn = 0;

            dac_on = 0;
            dac_point_num = 0;
            dac_tofs = new float[32];
            dac_amps = new float[32];
            dac_mode = 0;
        }

        public StructBeamFile getStruct()
        {
            StructBeamFile structBeam = new StructBeamFile();
            structBeam.txElementBin = new uint[8];
            structBeam.txDelay = new float[256];
            structBeam.txIntensify = new float[256];
            structBeam.rxElementBin = new uint[8];
            structBeam.rxDelay = new float[256];
            structBeam.rxIntensify = new float[256];
            structBeam.dac.dac_tofs = new float[32];
            structBeam.dac.dac_amps = new float[32];

            structBeam.beamIndex = this.beamIndex;
            structBeam.txSize = this.txSize;
            Array.Copy(this.txElementBin, structBeam.txElementBin, this.txElementBin.Length);
            Array.Copy(this.txDelay, structBeam.txDelay, this.txDelay.Length);
            Array.Copy(this.txIntensify, structBeam.txIntensify, this.txIntensify.Length);
            structBeam.rxSize = this.rxSize;
            Array.Copy(this.rxElementBin, structBeam.rxElementBin, this.rxElementBin.Length);
            Array.Copy(this.rxDelay, structBeam.rxDelay, this.rxDelay.Length);
            Array.Copy(this.rxIntensify, structBeam.rxIntensify, this.rxIntensify.Length);
            structBeam.gain = this.gain;
            structBeam.txEn = this.txEn;
            structBeam.rxOn = this.rxOn;
            structBeam.digitalHpf = this.digitalHpf;
            structBeam.dampOn = this.dampOn;
            structBeam.dampValue = this.dampValue;
            structBeam.path = this.path;
            structBeam.digitalLpf = this.digitalLpf;
            structBeam.beaOn = this.beaOn;
            structBeam.dac.dac_on = this.dac_on;
            structBeam.dac.dac_point_num = this.dac_point_num;
            Array.Copy(this.dac_tofs, structBeam.dac.dac_tofs, this.dac_tofs.Length);
            Array.Copy(this.dac_amps, structBeam.dac.dac_amps, this.dac_amps.Length);
            structBeam.dac.dac_mode = this.dac_mode;

            return structBeam;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AttrRangeUInt
    {
        uint type;   //attr typ like DAQ_ATTR.type
        uint min;
        uint max;
        uint dft;   //default
        uint curr;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct AttrRangeDouble
    {
        uint type;   //attr typ like DAQ_ATTR.type
        double min;
        double max;
        double dft;   //default
        double curr;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct StreamEnable
    {
        uint index;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct UniSetPacket
    {
        //Item header
        public uint port;
        public uint id;
        public uint bin;
        public uint size;

        //"__start__"
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] start;

        //UploadTagHeader
        public uint stampMode;
        //see daqattr.h    
        //ENUM_DAQ_DATA_UPLOAD_MODE

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] stampPos;
        //correspoing start position, maybe three dimensional

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] stampInc;  //increament interval, maybe three dimensional

        public uint cellNum;   //how many  sub-packet data cell, such as alarm disp, measment, ascan, envelop etc

        //uint type data
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ConstParameter.MaxUintArrayCount)]   //defaulat
        public uint[] ud;

        //floating data type
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ConstParameter.MaxFloatArrayCount)]
        public float[] fd;

        //"___stop___"
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] stop;
    }

    [Serializable]
    public class ItemHeader : IClone<ItemHeader>
    {
        //Item header
        public uint port;
        public uint id;
        public uint bin;
        public uint size;

        public ItemHeader()
        {
            port = 0;
            id = 0;
            bin = 0;
            size = 0;
        }

        public void clone(ItemHeader dest)
        {
            dest.port = this.port;
            dest.id = this.id;
            dest.bin = this.bin;
            dest.size = this.size;
        }
    } //end of class ItemHeader

    [Serializable]
    public class UploadTagHeader : IClone<UploadTagHeader>
    {
        public uint stampMode;
        public int[] stampPos;
        public int[] stampInc;
        public uint cellNum;

        public UploadTagHeader()
        {   
            stampMode = 0; //enum
            stampPos = new int[3];
            stampInc = new int[3];
            cellNum = 0;
        }

        public void clone(UploadTagHeader dest)
        {
            dest.stampMode = this.stampMode;
            Array.Copy(stampPos, dest.stampPos, 3);
            Array.Copy(stampInc, dest.stampInc, 3);
            dest.cellNum = this.cellNum;
        }

    } //end of class UploadTagHeader

    public class AscanSetPacket : IClone<AscanSetPacket>
    {
        //Item header
        public ItemHeader head;

        //UploadTagHeader
        public UploadTagHeader tag;

        //ascan length
        private uint ascanLen;

        public AscanVideo ascan;

        //defcosntruct
        public AscanSetPacket()
        {
            head = new ItemHeader();
            tag = new UploadTagHeader();
            tag.cellNum = 1; //should be use xml   

            ascanLen = ConstParameter.MaxAscanWaveLen; 
            ascan = new AscanVideo(ascanLen);
        }

        public void clone(AscanSetPacket dest)
        {
            head.clone(dest.head);
            tag.clone(dest.tag);
            dest.ascanLen = this.ascanLen;
            ascan.clone(dest.ascan);
        }
    } //end of class AlarmSetPacket

    public class AscanVideo : IClone<AscanVideo>
    {
        public uint len; //512 or 1024

        public uint ifStart; //interface tracking on/off

        public uint tofUnit;

        public uint ampUnit;

        public uint echoMax;
        //EchoMax        flag
        //	off			0
        //	on			1

        public uint waveDetectMode;
        //see ENUM_DAQ_ASCAN_VIDEO_DETECTION_WAVE_MODE

        public uint envelopStart;  //
        //envelopStart     flag
        //	off			   0
        //	on			   1

        public uint[] led;
        // I, A, B, C, BA, AI, BI, CI
        //	gray					0x00            Disabled 
        //  green					0x01            OK
        //  red					0x02	        NOT OK        

        public float delay;

        public float width;

        public float gain; //  


        public float bea; //

        public float decayFactor;  //decay factor


        public float[] ascanGateAmp;
        //gate amp data

        public float[] ascanGateTof;
        //gate tof data

        public float[] wave; //
        //ascan wave    length maybe 512 or 1024 from attr defination
        //void is defined in attr, ENUM_VIDEO_DATA_UPLOAD_TYPE, maybe schar or float or int32

        public float[] maxEnvelop; //
        //envelop data upper wave , length is same to ascan maxEnvelop[ascan length]

        public float[] minEnvelop;//
        //
        //envelop data lower wave

        public AscanVideo(uint ascanLen)
        {

            len = ascanLen;

            led = new uint[8]; //xml

            ascanGateAmp = new float[4];

            ascanGateTof = new float[4];

            wave = new float[len];

            maxEnvelop = new float[len];

            minEnvelop = new float[len];

        }

        public void clone(AscanVideo dest)
        {
            dest.len = this.len;
            dest.ifStart = this.ifStart;
            dest.tofUnit = this.tofUnit;
            dest.ampUnit = this.ampUnit;
            dest.echoMax = this.echoMax;
            dest.waveDetectMode = this.waveDetectMode;
            dest.envelopStart = this.envelopStart;
            Array.Copy(led, dest.led, 8);
            dest.delay = this.delay;
            dest.width = this.width;
            dest.gain = this.gain;
            dest.bea = this.bea;
            dest.decayFactor = this.decayFactor;
            Array.Copy(ascanGateAmp, dest.ascanGateAmp, 4);
            Array.Copy(ascanGateTof, dest.ascanGateTof, 4);
            Array.Copy(wave, dest.wave, len);
            Array.Copy(maxEnvelop, dest.maxEnvelop, len);
            Array.Copy(minEnvelop, dest.minEnvelop, len);
        }
    } //end of class AscanVideo 

    public class BoardStatusSetPacket : IClone<BoardStatusSetPacket>
    {
        //Item header
        public ItemHeader head;

        //UploadTagHeader
        public UploadTagHeader tag;

        //alarm data

        public BoardStatus status;

        //defcosntruct
        public BoardStatusSetPacket()
        {
            head = new ItemHeader();
            tag = new UploadTagHeader();
            status = new BoardStatus();

            tag.cellNum = 1; //should use xml            
        }

        public void clone(BoardStatusSetPacket dest)
        {
            head.clone(dest.head);
            tag.clone(dest.tag);
            status.clone(dest.status);
        }
    }

    public class BoardStatus : IClone<BoardStatus>
    {
        public uint status;
        //status			flag
        //reseting		0x0;
        //idle			0x1;
        //running		0x2;
        //err			0x3;
        public int errCode;
        //see daqerr.h

        public uint beatHeart;
        //non-zero, and increment

        public BoardStatus()
        {
            status = 0;
            errCode = 0;
            beatHeart = 0;
        }

        public void clone(BoardStatus dest)
        {
            dest.status = this.status;
            dest.errCode = this.errCode;
            dest.beatHeart = this.beatHeart;
        }
    } //end of class BoardStatus

    [Serializable]
    public class GatePacket : IClone<GatePacket>
    {
        //Item header
        public ItemHeader head;

        //UploadTagHeader
        public UploadTagHeader tag;

        public float[] measureDate;

        public GatePacket()
        {
            head = new ItemHeader();
            tag = new UploadTagHeader();
            measureDate = new float[ConstParameter.MaxMeasureDataLength];
        }

        public void clone(GatePacket dest)
        {
            head.clone(dest.head);
            tag.clone(dest.tag);
            Array.Copy(this.measureDate, dest.measureDate, measureDate.Length);
        }
    }
}
