#ifndef USCOMM_PDAQ
#define USCOMM_PDAQ

#include<iostream>
#include "daqInterface.h"
#include "ItemPacket.h"

//#include "DllTest.h"

#define LX_DLL_CLASS_EXPORTS //export

#ifndef LX_DLL_CLASS_EXPORTS
    #define LX_DLL_CLASS __declspec(dllexport)
#else
    #define LX_DLL_CLASS __declspec(dllimport)
#endif

#ifndef DEFAULT_PACKET_IN_SIZE
	#define DEFAULT_PACKET_IN_SIZE 4096
#endif

#ifndef DAQ_MAX_BUFF_SIZE 
#define     DAQ_MAX_BUFF_SIZE    (1024*1024)
#endif

using namespace std;

void LogPrintf(long line, char* strfunc,char* strErr);

/** Alloc mem for Interface, Session and board, and initial datas.*/
extern "C" LX_DLL_CLASS int USCOMM_InitDevice(char* devName, unsigned int* sessionNum);

/**Get the information of the session hardware.*/
extern "C" LX_DLL_CLASS int USCOMM_GetVersion(unsigned int index, IdTarget* pVal);

/** Free mem of Interface, Session and board.*/
extern "C" LX_DLL_CLASS int USCOMM_CloseDevice();
/** Get attrbute value whoes type is uInt.*/
extern "C" LX_DLL_CLASS int USCOMM_GetuInt(unsigned int index, unsigned int chn, unsigned int attrType, unsigned int* pVal);

/** Get attrbute value whoes type is Float.*/
extern "C" LX_DLL_CLASS int USCOMM_GetFloat(unsigned int index, unsigned int chn,  unsigned int attrType, float* pVal);

/** Get attrbute value whoes type is struct.*/
extern "C" LX_DLL_CLASS int USCOMM_GetDac(unsigned int index, unsigned int chn, unsigned int attrType, DAC_Paras* pVal);

/**Load Beamformer file*/
extern "C" LX_DLL_CLASS int USCOMM_LoadBMFile(unsigned int index, char* ramFile, unsigned int* fileSize);

/**Save Beamformer file*/
extern "C" LX_DLL_CLASS int USCOMM_SaveBMFile(unsigned int index, char* fileName);

/** Set attrbute value whoes type is uInt.*/
extern "C" LX_DLL_CLASS int USCOMM_SetuInt(unsigned int index, unsigned int chn, unsigned int attrType, unsigned int val);

/** Set attrbute value whoes type is Float.*/
extern "C" LX_DLL_CLASS int USCOMM_SetFloat(unsigned int index, unsigned int chn, unsigned int attrType, float val);

/** Set attrbute value whoes type is dac.*/
extern "C" LX_DLL_CLASS int USCOMM_SetDac(unsigned int index, unsigned int chn, unsigned int attrType, DAC_Paras val);

/** Set attrbute value whoes type is beamFile.*/
extern "C" LX_DLL_CLASS int USCOMM_SetBeam(unsigned int index, unsigned int chn, unsigned int attrType, BeamFile val);

/** Get attr's range info.*/
extern "C" LX_DLL_CLASS int USCOMM_GetRangeuInt(unsigned int index, unsigned int attrType, AttrRangeuInt* pValSet);


extern "C" LX_DLL_CLASS int USCOMM_GetRangeuDouble(unsigned int index, unsigned int attrType, AttrRangeDouble* pValSet);

/** Load dsp App. */
extern "C" LX_DLL_CLASS int USCOMM_APILoadApp(unsigned int index, char* pBinFile);

/** Start acquire. */
extern "C" LX_DLL_CLASS int USCOMM_SessionRun(unsigned int index);

/** Stop acquire. */
extern "C" LX_DLL_CLASS int USCOMM_SessionStop(unsigned int index);

/** Read buf datas in TSQ.*/
extern "C" LX_DLL_CLASS int USCOMM_Read(unsigned int index, UniSetPacket* pPacket, unsigned int boolBlock);

/** Stream start.*/
extern "C" LX_DLL_CLASS int USCOMM_StreamStart(unsigned int index, pStreamEnable pEnable);

/** Stream stop.*/
extern "C" LX_DLL_CLASS int USCOMM_StreamStop(unsigned int index, pStreamEnable pEnable);

#endif