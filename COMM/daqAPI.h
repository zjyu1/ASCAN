/*
* Copyright (c) 2015,  ZJU, ME, 128, Ultrsonic Group
* All rights reserved.
* Project£º  DAQ_USAQ 
* FileName£ºdaqAPI.h
* File Desc£º
* Abstract£ºdefine the function to operate the pxi interface, include all board
*
* Current Version£º2.0.0
* Author£º         Wueryong, LiKeDi
* Date£º           2015Äê9ÔÂ10ÈÕ
* Remarks£º 
* 		
*/

#ifndef		_DAQ_API_H
#define		_DAQ_API_H


#ifdef __cplusplus
	extern "C"{
#endif

//============================================================================
//INCLUDES
//===========================================================================
//#include "daq.h"
//#include "daqcmd.h"


//===========================================================================
// Micro Defination
//===========================================================================
#define    DevHandle   unsigned int 
#define    pDevHandle  unsigned int*

#ifndef  DAQ_SESSION_NUM_BUFFERS
#define 	DAQ_SESSION_NUM_BUFFERS 		32			//number of buffers
#endif

#define  DAQ_READ_API_FLUSH_ITEM_FLAG    1

#ifndef LX_DLL_CLASS_EXPORTS
	#define LX_DLL_CLASS __declspec(dllexport)
#else
	#define LX_DLL_CLASS __declspec(dllimport)
#endif

//===========================================================================
// Data Defination
//===========================================================================
typedef struct zdDevList
{
	unsigned int       devHandle;
	unsigned int*      next;  //next device pointer
}DevHandleList,*pDevHandleList;

//===========================================================================
// Function Defination
//===========================================================================
//open

LX_DLL_CLASS int daqOpen(const char* devName, unsigned int* pDevHdlList);			           //open one interface, and open all devices (board)
LX_DLL_CLASS int daqClose(unsigned int* pDevHdlList);							   // close  device   

//attr

LX_DLL_CLASS int  daqGet(const unsigned int pDevHdl, unsigned int chn, unsigned int attrType, void* pVal, unsigned int dflag);	       //get attr
LX_DLL_CLASS int  daqSet(const unsigned int pDevHdl, unsigned int chn, unsigned int attrType, void* pVal, unsigned int dflag);	       //set attr
LX_DLL_CLASS int daqGetDesc(const unsigned int pDevHdl, unsigned int attrType, void* pValSet, unsigned int dflag); //get attr's range info 

//get version info

LX_DLL_CLASS int daqGetVersion(const unsigned int pDevHdl, void* pid);

//load firmware file, and download to board 

LX_DLL_CLASS int daqLoadApp(const unsigned int pDevHdl, char* pBinFile);	               // load dsp App 

//run & stop 
LX_DLL_CLASS int daqRun(const unsigned int pDevHdl);                                 //start acquire 
LX_DLL_CLASS int daqStop(const unsigned int pDevHdl);                                //stop acquire 

//uploaded data
LX_DLL_CLASS int daqRead(const unsigned int pDevHdl, void* pBuf, unsigned int* psize, unsigned int boolBlock);  //read buf data

//measment item upload seletion and review  
LX_DLL_CLASS int daqDataItemListGet(const unsigned int pDevHdl, unsigned int chn, void*  pid); 

LX_DLL_CLASS int daqDataItemEnable(const unsigned int pDevHdl, unsigned int chn, void*  pid); 

LX_DLL_CLASS int daqDataItemDisable(const unsigned int pDevHdl, unsigned int chn, void*  pid);

//measment upload start or stop
LX_DLL_CLASS int daqDataStreamStart(const unsigned int pDevHdl, void*  pid);

LX_DLL_CLASS int daqDataStreamStop(const unsigned int pDevHdl, void* pid);

/**********************************************************
//CALL THESE FUNCTION BELOW DIRECTLY, HERE NOT REWRITE IT, HAVE BEEN IMPLEMETED IN daqcmd.h!!!
***********************************************************/
//notify board to load paras or save paras
    //Int32 daqLoadParam(SESSION_ID sid, pDAQ_Params_Set pid); //implement load parameter cmd

    //Int32 daqSaveParam(SESSION_ID sid, pDAQ_Params_Set pid);  //implement save parameter cmd

//measment item upload seletion and review 
    //Int32 daqGetDataItemList(SESSION_ID sid, unsigned int chn, pDAQ_Data_Items pid) ;  //implement get data item list


    //Int32 daqEnableDataItem(SESSION_ID sid, unsigned int chn,  pDAQ_Data_Item pid) ;   //implement enable data item cmd


    //Int32 daqDisableDataItem(SESSION_ID sid, unsigned int chn, pDAQ_Data_Item pid);   //implement disable data item cmd

//measment upload start or stop
    //Int32 daqStartDataStream(SESSION_ID sid, pDAQ_Stream_Switch pid);   //implement start upload datastream cmd

    //Int32 daqStopDataStream(SESSION_ID sid, pDAQ_Stream_Switch pid);	//implement stop upload datastream cmd

#ifdef __cplusplus
	}
#endif

#endif //end of _DAQ_API_H















