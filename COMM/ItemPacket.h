#ifndef ITEM_PACKET_H
#define ITEM_PACKET_H 

#define ASCAN_INNER_UINT_SIZE		(sizeof(unsigned int) * 15)
#define ASCAN_INNER_DOUBLE_SIZE		(sizeof(float) * 13)
#define ITEM_START_SIZE				(sizeof(unsigned int)*2)
#define ITEM_STOP_SIZE				(sizeof(unsigned int)*2)
#define PACKET_UINT_SIZE            64
#define PACKET_FLOAT_SIZE           8192

#define ITEM_UD_MAX_SIZE			64
#define ITEM_FD_MAX_SIZE			8192
#define ASCAN_LENGTH				512


    struct UniSetPacket
    {
        //Item header
		unsigned int port;
        unsigned int id;
        unsigned int bin;
        unsigned int size;

        //"__start__"        
        unsigned int start[2];

        //UploadTagHeader
        unsigned int stampMode;
	                   //see daqattr.h    
					   //ENUM_DAQ_DATA_UPLOAD_MODE

        
	     int stampPos[3];
 					  //correspoing start position, maybe three dimensional

     
         int stampInc[3];  //increament interval, maybe three dimensional
	
	    unsigned int cellNum;   //how many  sub-packet data cell, such as alarm disp, measment, ascan, envelop etc

        //unsigned int type data        
        unsigned int ud[ITEM_UD_MAX_SIZE];

        //floating data type        
        float fd[ITEM_FD_MAX_SIZE]; 

        //"___stop___"
        unsigned int stop[2]; 

    }; //end of struct UniSetPacket

	struct ItemHeader
    {
        //Item header
		unsigned int port;
        unsigned int id;
        unsigned int bin;
        unsigned int size;       
    }; //end of class ItemHeader

    struct UploadTagHeader
    {
        unsigned int stampMode;
        int stampPos[3];
        int stampInc[3];
        unsigned int cellNum;      

    }; //end of class UploadTagHeader

    struct AlarmSetPacket
    {
        //Item header
        struct ItemHeader head;

		unsigned int start[2];

        //UploadTagHeader
        struct UploadTagHeader tag;

        //alarm data
        unsigned int * alarm;

		unsigned int stop[2];

       
    }; //end of class AlarmSetPacket



	
    struct AscanSetPacket
    {
        //Item header
        struct ItemHeader head;

		unsigned int start[2];

        //UploadTagHeader
        struct UploadTagHeader tag;        

		//Ascan Video
        unsigned int len; //512 or 1024 
	            
	
	    unsigned int ifStart; //interface tracking on/off
	
	    unsigned int tofUnit;
	
	    unsigned int ampUnit;

	    unsigned int echoMax;
               //EchoMax        flag
               //	off			0
               //	on			1

        unsigned int waveDetectMode;
	           //see ENUM_DAQ_ASCAN_VIDEO_DETECTION_WAVE_MODE
	
	    unsigned int  envelopStart;  //
	            		    //envelopStart     flag
                            //	off			   0
                            //	on			   1

        unsigned int  led[8];
        // I, A, B, C, BA, AI, BI, CI
        //	gray					0x00            Disabled 
        //  green					0x01            OK
        //  red					0x02	        NOT OK        

        float  delay;

	    float  width;

        float gain; //  
	           
	    float bea; //
		
	    float decayFactor;  //decay factor


        float ascanGateAmp[4];
        //gate amp data

        float ascanGateTof[4];
        //gate tof data

        float *wave; //
	            //ascan wave    length maybe 512 or 1024 from attr defination
                //void is defined in attr, ENUM_VIDEO_DATA_UPLOAD_TYPE, maybe schar or float or int32
		
	    float* maxEnvelop; //
	               //envelop data upper wave , length is same to ascan maxEnvelop[ascan length]
	
	    float * minEnvelop;//

		unsigned int stop[2];
	 			     //
					 //envelop data lower wave       
    }; //end of class AlarmSetPacket

    struct GateSetPacket
    {
        //Item header
        struct ItemHeader head;

		unsigned int start[2];

        //UploadTagHeader
        struct UploadTagHeader tag;

        //alarm data
        float * d; 

		unsigned int stop[2];
    };


    struct Gate2SetPacket
    {
        //Item header
        struct ItemHeader head;

		unsigned int start[2];

        //UploadTagHeader
        struct UploadTagHeader tag;

        float* d;  

		unsigned int stop[2];
 
    }; //end of class Meas2GateSetPacket
	

    struct StatusSetPacket
    {
        //Item header
        struct ItemHeader head;

		unsigned int start[2];

        //UploadTagHeader
        struct UploadTagHeader tag;

        //status data
        unsigned int status;
        //status			flag
        //reseting		0x0;
        //idle			0x1;
        //running		0x2;
        //err			0x3;
        int errCode;
        //see daqerr.h

        unsigned int beatHeart;
        //non-zero, and increment   

		unsigned int stop[2];
    }; 

   struct EventSetPacket
  {
	 //Item header
         struct ItemHeader head;

	unsigned int start[2];

        //UploadTagHeader
        struct UploadTagHeader tag;

      	unsigned int stop[2];
};

#endif

