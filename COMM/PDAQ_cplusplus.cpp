#include "stdafx.h"
#include "PDAQ.h"
#include <string.h>
#include "BoardManager_cpluscplus.h"
//#pragma comment(lib,"DllTest.lib")

/*************************************************
Global data defination
*************************************************/
 

static BoardManager brdsManager;

void LogPrintf(long line, char* strfunc,char* strErr)
{
	char s[256];

	sprintf_s(s, "%d", line);
	
	cout << "Date: " << __DATE__ << ".\n";

	cout << "Time: " << __TIME__ << ".\n";

	cout << "Line: " << s << ".\n";

	cout << strfunc <<"(...),  "<< strErr <<",  pls chk!.\n";	

	cout << "\n";

	cout<< flush;

} //end of LogPrintf(...


int USCOMM_InitDevice(char* fname, unsigned int* sessionNum)
{
	//DEFINATION
	int err = 0;
	string name;
	

	//INIT
	name = fname;

	err = brdsManager.Open(name);
	if(err != 0)
	{
		err = -2;
		ErrPrintf("");
		return err;
	}

	*sessionNum = brdsManager.GetBoardsNum();
	return err;
} //end of USCOMM_InitDevice(...


int USCOMM_GetVersion(unsigned int index, IdTarget* pVal)
{
	//DEFINATION
	int err = 0;

	err = brdsManager.GetVersion(index, pVal);

	if(err != 0)
	{
		err = -2;
		ErrPrintf("Get version error!");
		return err;
	}

	return err;
}


int USCOMM_CloseDevice()
{
	int err = 0;
	err = brdsManager.Close();
	if(err != 0)
	{
		err = -2;
		ErrPrintf("");
		return err;
	}
	return err;
} //end of USCOMM_CloseDevice(...


int USCOMM_GetuInt(unsigned int index, unsigned int chn, unsigned int attrType, uInt32* pVal)
{
	int err = 0;
	unsigned int uVal = 0;
	err = brdsManager.Get(index, chn, attrType, &uVal);
	if(err != 0)
	{
		err = -2;
		ErrPrintf("get uint val err");
		return err;
	}
	*pVal = uVal;
	return err;

} //end of USCOMM_GetuInt(...

int USCOMM_GetFloat(unsigned int index, unsigned int chn, unsigned int attrType, float* pVal)
{
	int err = 0;
	float ftVal = 0;

	err = brdsManager.Get(index, chn, attrType, &ftVal);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("get double val err");
		return err;
	}

	*pVal = ftVal;
	return err;

}

int USCOMM_GetDouble(unsigned int index, unsigned int chn, unsigned int attrType, double* pVal)
{
	int err = 0;
	double dbVal = 0;

	err = brdsManager.Get(index, chn, attrType, &dbVal);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("get double val err");
		return err;
	}

	*pVal = dbVal;
	return err;

}


int USCOMM_GetDac(unsigned int index, unsigned int chn, unsigned int attrType, DAC_Paras* pVal)
{
	int err = 0;
	DAC_Paras dac;
	memset(&dac, 0, sizeof(DAC_Paras));

	err = brdsManager.Get(index, chn, attrType, &dac);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("get dac para err");
		return err;
	}

	*pVal = dac;
	return err;
}

int USCOMM_LoadBMFile(unsigned int index, char* ramFile, unsigned int* fileSize)
{
	int err = 0;
	unsigned int uVal = 0;

	if(ramFile == NULL)
	{
		err = -1;
		ErrPrintf("ramFile is null");
		return err;
	}

	uVal = (*fileSize);
	err = brdsManager.LoadBMFile(index, ramFile, &uVal);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("load bm file err");
		return err;
	}

	(*fileSize) = uVal;

	return err;
}

int USCOMM_SaveBMFile(unsigned int index, char* fileName)
{
	int err = 0;
	string name = "";

	if(fileName == NULL)
	{
		err = -1;
		ErrPrintf("fname is null");
		return err;
	}

	name = fileName;	

	err = brdsManager.SaveBMFile(index, name);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("save bm file err");
		return err;
	}

	return err;
}

int USCOMM_SetuInt(unsigned int index, unsigned int chn, unsigned int attrType, unsigned int val)
{
	int err = 0;
	
	err = brdsManager.Set(index, chn, attrType, val);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("set uint err");
		return err;
	}

	return err;
}


int USCOMM_SetFloat(unsigned int index, unsigned int chn, unsigned int attrType, float val)
{
	int err = 0;
	
	err = brdsManager.Set(index, chn, attrType, val);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("set double err");
		return err;
	}
	return err;
}

int USCOMM_SetDouble(unsigned int index, unsigned int chn, unsigned int attrType, double val)
{
	int err = 0;
	
	err = brdsManager.Set(index, chn, attrType, val);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("set double err");
		return err;
	}
	return err;
}


int USCOMM_SetDac(unsigned int index, unsigned int chn, unsigned int attrType, DAC_Paras val)
{
	int err = 0;
	
	err = brdsManager.Set(index, chn, attrType, val);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("set dac err");
		return err;
	}
	return err;
}

int USCOMM_SetBeam(unsigned int index, unsigned int chn, unsigned int attrType, BeamFile val)
{
	int err = 0;
	
	err = brdsManager.Set(index, chn, attrType, val);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("set beam err");
		return err;
	}
	return err;
}

int USCOMM_GetRangeuInt(unsigned int index, unsigned int attrType, AttrRangeuInt* pVal)
{
	int err = 0;
	AttrRangeuInt range;

	memset(&range,0,sizeof(AttrRangeuInt));

	err = brdsManager.Get(index, attrType, &range);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("get uint range err");
		return err;
	}

	*pVal = range;
	return err;
}


int USCOMM_GetRangeDouble(unsigned int index, unsigned int attrType, AttrRangeDouble* pVal)
{
	int err = 0;
	AttrRangeDouble range;

	memset(&range,0,sizeof(AttrRangeDouble));

	err = brdsManager.Get(index, attrType, &range);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("get double range err");
		return err;
	}

	*pVal = range;
	return err;
} //end of 


int USCOMM_APILoadApp(unsigned int index, char* pBinFile)
{
	int err = 0;
	string fname = pBinFile;

	err = brdsManager.APILoadApp(index, fname);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("load app err");
		return err;
	}

	
	return err;
} //end of  USCOMM_APILoadApp(...


int USCOMM_SessionRun(unsigned int index)
{
	int err = 0;
	
	err = brdsManager.Run(index);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("session run err");
		return err;
	}	
	return err;
} //end of USCOMM_SessionRun(...



int USCOMM_SessionStop(unsigned int index)
{
	int err = 0;
	
	err = brdsManager.Stop(index);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("session run err");
		return err;
	}	
	return err;
}

int USCOMM_Read(unsigned int index, UniSetPacket* pPacket, unsigned int boolBlock)
{
	int err = 0;
	//unsigned int bufSize;

	//bufSize = (*size);

	/*pPacket->id = 7;
	pPacket->bin = 7;
	pPacket->size = 7;
	memcpy((void*)pPacket->start, "__start_", 2*sizeof(unsigned int));
	pPacket->stampMode = 7;
	pPacket->stampPos[0] = 7;
	pPacket->stampPos[1] = 7;
	pPacket->stampPos[2] = 7;
	pPacket->stampInc[0] = 7;
	pPacket->stampInc[1] = 7;
	pPacket->stampInc[2] = 7;
	pPacket->cellNum = 7;
	memset((void*)pPacket->ud, 0, 4096*sizeof(unsigned int));
	memset((void*)pPacket->fd, 0, 4096*sizeof(double));
	memcpy((void*)pPacket->stop, "__stop__", 2*sizeof(unsigned int));
	return err;*/

	err = brdsManager.Read(index, pPacket, boolBlock);

	if(err == 1)
		return 1;

	if(err != 0)
	{
		err = -3;
		ErrPrintf("read err");
		return err;
	}	
	//(*size) = bufSize;

	return err;

} //end of USCOMM_Read(...

int USCOMM_StreamStart(unsigned int index, pStreamEnable pEnable)
{
	int err = 0;
	StreamEnable streamEnable;

	memset(&streamEnable,0,sizeof(StreamEnable));

	err = brdsManager.StreamStart(index, &streamEnable);

	if(err != 0)
	{
		err = -4;
		ErrPrintf("stream start err");
		return err;
	}	
	//(*size) = bufSize;

	*pEnable = streamEnable;
	return err;
}

int USCOMM_StreamStop(unsigned int index, pStreamEnable pEnable)
{
	int err = 0;
	StreamEnable streamEnable;
	memset(&streamEnable,0,sizeof(StreamEnable));
	err = brdsManager.StreamStop(index, &streamEnable);
	if(err != 0)
	{
		err = -4;
		ErrPrintf("stream stop err");
		return err;
	}	
	//(*size) = bufSize;
	*pEnable = streamEnable;
	return err;
}

