/*
* Copyright (c) 2015,  ZJU, ME, 128, Ultrsonic Group
* All rights reserved.
* Project£º  USCOMM
* FileName£º daqInterface.h
* File Desc£º re defined the data stuctured has been defined in DAQ_US Project, pls pay attension
*             if DAQ_US change these defination listed below, pls change this file simutanously. 
* Abstract£º
*
* Current Version£º1.0.0
* Author£º         Wueryong
* Date£º           2015-12-03
* Remarks£º 
* 				  
*/

#ifndef		_DAQ_INTTERFACE_H
#define		_DAQ_INTTERFACE_H

//==============================================================================
// Include files
#include "daqtypes.h"

//==============================================================================
// Constants
#define DAQ_MAX_PA_SEQ         1024
#define DAQ_MAX_DAC_POINTS     32

#define 	DAQ_UINT_TYPE          0
#define     DAQ_INT_TYPE           1
#define     DAQ_FLOAT_TYPE         2		
#define     DAQ_DOUBLE_TYPE        3
#define     DAQ_DAC_FILE_TYPE      4
#define     DAQ_BM_FILE_TYPE       5
#define     DAQ_PROBE_FILE_TYPE    7
#define     DAQ_OTHERS_TYPE        6

#define     DAQ_MAX_LENGTH_STR     64

#define     MAX_FILE_PATH_LEN      256

/**Max session num of the Interface.*/
#define MAX_SESSION_NUM			256

//===========================================================================
// Data Defination
//===========================================================================

//typedef struct zdDevList        //defined in daqAPI.h
//{
//	unsigned int       devHandle;
//	unsigned int*      next;  //next device pointer
//}DevHandleList,*pDevHandleList;

//DAC POINT Paras
typedef struct zdDAC_Paras
{
	unsigned int                                dac_on;
	unsigned int                                dac_point_num;
	double                                dac_tofs[DAQ_MAX_DAC_POINTS];
	double                                dac_amps[DAQ_MAX_DAC_POINTS];
}DAC_Paras,*pDAC_Paras;

typedef struct zdBeamFile
{
    unsigned int beamIndex;
	
	//transmit
    unsigned int txSize;
    unsigned int txElementBin[8];

    double txDelay[256];
	//Double txIntensify[DAQ_MAX_PA_ELEMENT];

	//reciever
    unsigned int rxSize;
    unsigned int rxElementBin[8];
    double rxDelay[256];
    double rxIntensify[256];

    double gain;
    unsigned int txEn;
    unsigned int rxOn;
    unsigned int digitalHpf;
    unsigned int dampOn;
    unsigned int dampValue;
    unsigned int path;
    unsigned int digitalLpf;
    unsigned int beaOn;
	
    DAC_Paras dac;
}BeamFile;

typedef struct zdStreamEnable
{
	unsigned int   index;
}StreamEnable, *pStreamEnable;

typedef struct zdAttrRangeuInt
{   unsigned int type;   //attr typ like DAQ_ATTR.type
	unsigned int min;
	unsigned int max;
	unsigned int dft;   //default
	unsigned int curr;
}AttrRangeuInt,*pAttrRangeuInt;

typedef struct zdAttrRangeDouble
{
	unsigned int type;   //attr typ like DAQ_ATTR.type
	double min;
	double max;
	double dft;   //default
	double curr;
}AttrRangeDouble,*pAttrRangeDouble;

typedef struct zdIdTarget
{
	char   name[16];	//Lab inner used
	char   version[16]; //like 2.1.0 bete2
	unsigned int id;			//see below
	char  sn[16];		//XXXX-YYYY-ZZZZ-DDDD, future will encrypted.
	char mac;         //Mac address blinding
}IdTarget,*pIdTarget;  

#endif //end of daqInterface.h