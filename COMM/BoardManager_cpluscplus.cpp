//
#include "stdafx.h"
#include "DaqDefine.h"
#include "BoardManager_cpluscplus.h"

#define UINT_TYPE       0
#define INT_TYPE        1
#define FLOAT_TYPE      2
#define DOUBLE_TYPE     3
#define DAC_FILE_TYPE   4
#define BM_FILE_TYPE    5
#define OTHERS_TYPE     6

#pragma comment(lib, "daqAPI.lib")

BoardManager::BoardManager()
{
	this->brdsNum = 0;

	this->brds = 0;
	

	this->isOpen = false;

	
	this->pDevList = 0;

	//log file name
	this->logFileName = "ErrLogBoardManager.txt";

	//open log file, has bug?
	this->errLog.open(logFileName.c_str(), ios::trunc | ios::out); //if exsist, delete and new one file	

} //end of BoardRes()

BoardManager::~BoardManager()
{
	//delete pBuf
	if(this->brds != NULL)
	{
		delete [] (this->brds);
		this->brds = NULL;
	}	
#ifdef USCOMM_SIM
	if(this->sim != NULL)
	{
		delete [] (this->sim);
		this->sim = NULL;
	}
#endif
	if(daqBuf != NULL)
	{
		delete [] daqBuf;
		daqBuf = NULL;
	}
	//close logfile
	this->errLog.close();

} //end of ~BoardRes(...)

int BoardManager::Open(string fName)
{
	int err = 0;
	int i=0;
	int j = 0;

	//device list
	DevHandleList* pList = 0;
	unsigned int   devHandleArray[256];
	BoardRes* pRes = NULL;

#ifdef USCOMM_SIM
	struct PktInfo			info;
	//INIT info
	info.fName = "HIC_20150814.txt";
	info.lineNum = 150;

	info.ascanCellNum = 1;
	info.statusCellNum = 1;
	info.alarmCellNum = 100;
	info.gateCellNum = 12;
	info.gate2CellNum = SIM_DOUBLE_GATES_NUM;

	info.ascanItemNum = 12;
	info.statusItemNum = 1;
	info.alarmItemNum = 1;
	info.gateItemNum = 1;
	info.gate2ItemNum = 1;
#endif
	
	for(i=0;i<256;i++)
	{
		devHandleArray[i] = 0;
	}

#ifdef USCOMM_SIM
	this->brdsNum = 4;
	for(i = 0; i < this->brdsNum; i++)
	{
		devHandleArray[i] = i + 1;
	}


	//sim
	this->sim = new SimulateAscan[this->brdsNum];
	for(j = 0; j < this->brdsNum; j++)
	{
		err = sim[j].Init(info);
		if(err != 0)
		{
			err = -3;
			printf("sim init err");
			return err;
		}
	}
#else
	if(this->isOpen == true)
	{
		Close();
	}
	err = daqOpen(fName.c_str(), (unsigned int*)&pDevList);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("open interface error");
		return err;
	}

	pList = pDevList;
	for(i = 0; i < 256; i++)
	{
		if(pList->devHandle != 0)
		{
			this->brdsNum++;
			devHandleArray[i] = pList->devHandle;
		}
		if(pList->next == 0)
		{
			break;
		}
		else
		{
			pList = (DevHandleList*)pList->next;
		}
	}

	if(this->brdsNum == 0)
	{
		err = -3;
		ErrPrintf("no board find in devList");
		return err;
	}
#endif

	this->daqBuf = new char[DEFAULT_DAQ_BUF_SIZE * this->brdsNum]; //1M
	if(this->daqBuf == NULL)
	{
		err = -2;
		ErrPrintf("alloc daqBuf err");
		return err;
	}

	this->brds = new BoardRes[this->brdsNum];
	if(this->brds == 0)
	{
		err = -2;
		ErrPrintf("alloc BoardRes err");
		return err;
	}

	//Init board
	for(i=0; i < (int)this->brdsNum; i++)
	{
		brds[i].Init(devHandleArray[i], "");	
		if(err != 0)
		{
			err = -3;
			printf("brd init err");
			return err;
		}
	}	

	this->isOpen = true;

	return err;
}

int BoardManager::Close()
{
	int err = 0;

	if(this->isOpen == false)
	{
		return err;
	}

#ifndef USCOMM_SIM
	err = daqClose((unsigned int*)this->pDevList);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("Close Interface failor");
	}
#endif
	this->isOpen = false;

	this->brdsNum = 0;

	if(this->brds != NULL)
	{
		delete [] this->brds ;
		this->brds = NULL;
	}

	if(this->daqBuf != NULL)
	{
		delete [] this->daqBuf;
		this->daqBuf = NULL;
	}

	return err;
}

unsigned int BoardManager::GetBoardsNum()
{
	return this->brdsNum;
}



void BoardManager::LogPrintf(long line, char* strfunc,char* strErr)
{
	char s[256];

	sprintf_s(s, "%d", line);
	
	this->errLog << "Date: " << __DATE__ << ".\n";

	this->errLog << "Time: " << __TIME__ << ".\n";

	this->errLog << "Line: " << s << ".\n";

	this->errLog << strfunc <<"(...),  "<< strErr <<",  pls chk!.\n";	

	this->errLog << "\n";

	this->errLog<< flush;

} //end of LogPrintf(...

int BoardManager::Get(unsigned int bid, unsigned int chn, unsigned int attrType, unsigned int* pVal)
{
	int err = 0;
	int i=0;
	unsigned int uVal=0;
	unsigned int devHandle = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("get error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	*pVal = 0;
	return err;
#else
	devHandle = GetBoardID(bid);
	err = daqGet(devHandle, chn, attrType, (void*)&uVal, UINT_TYPE);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq get uInt err");
		return err;
	}

	*pVal = uVal;	
#endif
	return err;
}

int BoardManager::Get(unsigned int bid, unsigned int chn, unsigned int attrType, float* pVal)
{
	int err = 0;
	int i=0;
	float ftVal=0;
	unsigned int devHandle = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("get error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	*pVal = 0.0;
	return err;
#else
	devHandle = GetBoardID(bid);

	err = daqGet(devHandle, chn, attrType, &ftVal, FLOAT_TYPE);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq get float err");
		return err;
	}

	*pVal = ftVal;	
#endif
	return err;
}

int BoardManager::Get(unsigned int bid, unsigned int chn, unsigned int attrType, double* pVal)
{
	int err = 0;
	int i=0;
	double uVal=0;
	unsigned int devHandle = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("get error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	*pVal = 0.0;
	return err;
#else
	devHandle = GetBoardID(bid);

	err = daqGet(devHandle, chn, attrType, &uVal, DOUBLE_TYPE);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq get double err");
		return err;
	}

	*pVal = uVal;	
#endif
	return err;
}

int BoardManager::Get(unsigned int bid, unsigned int chn, unsigned int attrType, DAC_Paras* pVal)
{
	int err = 0;
	int i=0;
	DAC_Paras dac;
	unsigned int devHandle = 0;

	memset(&dac, 0, sizeof(DAC_Paras));

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("get error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	*pVal = dac;
	return err;
#else
	devHandle = GetBoardID(bid);

	err = daqGet(devHandle, chn, attrType, &dac, DAC_FILE_TYPE);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq get dac err");
		return err;
	}

	*pVal = dac;	
#endif
	return err;
}

int BoardManager::Set(unsigned int bid, unsigned int chn, unsigned int attrType, unsigned int val)
{
	int err = 0;
	int i=0;
	unsigned int uVal=0;
	unsigned int devHandle = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("set error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	return err;
#else
	devHandle = GetBoardID(bid);
	err = daqSet(devHandle, chn, attrType, (void*)&val, UINT_TYPE);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq set uInt err");
		return err;
	}
#endif
	return err;
}

int BoardManager::Set(unsigned int bid, unsigned int chn, unsigned int attrType, float val)
{
	int err = 0;
	int i=0;
	unsigned int devHandle = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("set error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	return err;
#else
	devHandle = GetBoardID(bid);
	err = daqSet(devHandle, chn, attrType, (void*)&val, FLOAT_TYPE);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq set float err");
		return err;
	}
#endif
	return err;
}

int BoardManager::Set(unsigned int bid, unsigned int chn, unsigned int attrType, double val)
{
	int err = 0;
	int i=0;
	unsigned int devHandle = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("set error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	return err;
#else
	devHandle = GetBoardID(bid);
	err = daqSet(devHandle, chn, attrType, (void*)&val, DOUBLE_TYPE);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq set double err");
		return err;
	}
#endif
	return err;
}

int BoardManager::Set(unsigned int bid, unsigned int chn, unsigned int attrType, DAC_Paras  dac)
{
	int err = 0;
	int i=0;
	unsigned int devHandle = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("set error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	return err;
#else
	devHandle = GetBoardID(bid);
	err = daqSet(devHandle, chn, attrType, (void*)&dac, DAC_FILE_TYPE);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq set dac err");
		return err;
	}


#endif
	return err;
}

int BoardManager::Set(unsigned int bid, unsigned int chn, unsigned int attrType, BeamFile beam)
{
	int err = 0;
	int i=0;
	unsigned int devHandle = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("set error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	return err;
#else
	devHandle = GetBoardID(bid);
	err = daqSet(devHandle, chn, attrType, (void*)&beam, BM_FILE_TYPE);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq set beam err");
		return err;
	}


#endif
	return err;
}

int BoardManager::LoadBMFile(unsigned int bid, char* ramFile, unsigned int* fileSize)
{
	int err = 0;
	int i=0;
	
	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("load bmfile error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	*fileSize = 0;
	return err;
#else
	
	//err = daqLoadBF(bid, ramFile, fileSize);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq load bmfile err");
		return err;
	}
#endif
	return err;
}


int BoardManager::SaveBMFile(unsigned int bid, string fName)
{
	int err = 0;
	int i=0;
	
	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("save bmfile error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	return err;
#else
	
//	err = daqSaveBF(bid, fName.c_str());
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq save bm file err");
		return err;
	}


#endif
	return err;
}

int BoardManager::Get(unsigned int bid, unsigned int attrType, AttrRangeuInt* pRange)
{
	int err = 0;
	int i=0;
	AttrRangeuInt range;

	memset(&range,0, sizeof(AttrRangeuInt));

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("get error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	*pRange = range;
	return err;
#else
	
	//err = daqGetuIntRange(bid, &range);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq get uInt range err");
		return err;
	}

	*pRange = range;
#endif
	return err;
}


int BoardManager::Get(unsigned int bid, unsigned int attrType, AttrRangeDouble* pRange)
{
	int err = 0;
	AttrRangeDouble range;

	memset(&range,0, sizeof(AttrRangeDouble));

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("get error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	*pRange = range;
	return err;
#else
	
	//err = daqGetDoubleRange(bid, &range);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq get double range err");
		return err;
	}

	*pRange = range;
#endif
	return err;
}

int BoardManager:: GetVersion(unsigned int bid, IdTarget* pVal)
{
	int err = 0;
	IdTarget version;
	unsigned int devHandle = 0;

	memset(&version, 0, sizeof(IdTarget));

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("get error, interface is not opened");
		return err;
	}

#ifdef USCOMM_SIM
	return err;
#else

	devHandle = GetBoardID(bid);
	err = daqGetVersion(devHandle, &version);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq get version err");
		return err;
	}
	memcpy(pVal, &version, sizeof(IdTarget));
#endif
	return err;
}

int BoardManager:: APILoadApp(unsigned int bid, string fName)
{
	int err = 0;
	
	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("load app error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	return err;
#else
	
	//err = daqLoadApp(bid, fName.c_str());
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq load app err");
		return err;
	}


#endif
	return err;
}


int BoardManager::Run(unsigned int bid)
{
	int err = 0;
	unsigned int boardId = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("load app error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	return err;
#else
	boardId = GetBoardID(bid);
	err = daqRun(boardId);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq run err");
		return err;
	}


#endif
	return err;
}


int BoardManager::Stop(unsigned int bid)
{
	int err = 0;
	unsigned int boardId = 0;

	if(this->isOpen == false)
	{
		err = -2;
		ErrPrintf("Stop error, interface is not opened");
		return err;
	}
#ifdef USCOMM_SIM
	return err;
#else
	boardId = GetBoardID(bid);
	err = daqStop(boardId);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("daq stop err");
		return err;
	}


#endif
	return err;
}

int BoardManager::Read(unsigned int bid, UniSetPacket* pPacket, unsigned int boolBlock)
{
	int err = 0;
	BoardRes* pRes = 0;
	SimulateAscan* pSim = 0;
	unsigned int boardId = 0;
	char* daqBuf = 0;
	unsigned int size = 0;
	struct UniSetPacket pkt;

	/*if(*bufSize < sizeof(struct UniSetPacket))
	{
		err = -1;
		ErrPrintf("input buffer size is too small");
		return err;
	}*/

	pRes = GetRes(bid);
	boardId = GetBoardID(bid);
	pSim = GetSim(bid);


	if(pRes->Empty() == true)
	{
		daqBuf = this->GetDaqBuf(bid);
		size = DEFAULT_DAQ_BUF_SIZE;

		//read
#ifndef USCOMM_SIM
		err = daqRead(boardId, daqBuf, &size, 1); //block

		if(err == 1)
			return 1;

		if(err != 0)
		{
			err = -3;
			ErrPrintf("daq read err");
			return err;
		}
#endif
#ifdef USCOMM_SIM
		err = pSim->GenBoardPkt((void*)daqBuf, &size);
		if(err != 0)
		{
			err = -3;
			ErrPrintf("sim gen pkt err");
			return err;
		}	
#endif

		//push to board res
		err = pRes->PushUnUniPktIn((void*) daqBuf, size);
		if(err != 0)
		{
			err = -3;
			ErrPrintf("push un uni pkt in err");
			return err;
		}		
	}

	err = pRes->PopOneUniPktOut(&pkt);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("pop one uni pkt out err");
		return err;
	}

	memcpy((void*)pPacket, &pkt, sizeof(UniSetPacket));
	/*pPacket->id = pkt.id;
	pPacket->bin = pkt.bin;
	pPacket->size = pkt.size;
	memcpy((void*)pPacket->start, (void*)pkt.start, 2*sizeof(unsigned int));
	pPacket->stampMode = pkt.stampMode;
	memcpy((void*)pPacket->stampPos, (void*)pkt.stampPos, 3*sizeof(unsigned int));
	memcpy((void*)pPacket->stampInc, (void*)pkt.stampInc, 3*sizeof(unsigned int));
	pPacket->cellNum = pkt.cellNum;
	memcpy((void*)pPacket->ud, (void*)pkt.ud, 4096*sizeof(unsigned int));
	memcpy((void*)pPacket->fd, (void*)pkt.fd, 4096*sizeof(double));
	memcpy((void*)pPacket->stop, (void*)pkt.stop, 2*sizeof(unsigned int));*/

	return err;
}

int BoardManager::StreamStart(unsigned int bid, pStreamEnable pEnable)
{
	int err = 0;
	unsigned int boardId = 0;

	boardId = GetBoardID(bid);

	err = daqDataStreamStart(boardId, (void*)pEnable);
	if(err != 0)
	{
		err = -1;
		ErrPrintf("stream start err");
		return err;
	}
	return err;
}

int BoardManager::StreamStop(unsigned int bid, pStreamEnable pEnable)
{
	int err = 0;
	unsigned int boardId = 0;

	boardId = GetBoardID(bid);

	err = daqDataStreamStop(boardId, (void*)pEnable);
	if(err != 0)
	{
		err = -1;
		ErrPrintf("stream stop err");
		return err;
	}
	return err;
}


BoardRes* BoardManager::GetRes(unsigned int bid)
{
	int err = 0;
	BoardRes* pRes = 0;

	if(bid >= this->brdsNum)
	{
		err = -1;
		ErrPrintf("bid is too large");
		return 0;
	}
	else
	{
		pRes = this->brds + bid;
	}
	return pRes;
}

SimulateAscan* BoardManager::GetSim(unsigned int bid)
{
	int err = 0;
	SimulateAscan* pSim = 0;

	if(bid >= this->brdsNum)
	{
		err = -1;
		ErrPrintf("bid is too large");
		return 0;
	}
	else
	{
#ifdef USCOMM_SIM
		pSim = this->sim + bid;
#endif
	}
	return pSim;
}

unsigned int BoardManager::GetBoardID(unsigned int bid)
{
	int err = 0;
	BoardRes* pRes = 0;
	unsigned int uval = 0;

	if(bid >= this->brdsNum)
	{
		err = -1;
		ErrPrintf("bid is too large");
		return 0;
	}
	else
	{
		pRes = this->brds + bid;
	}
	uval = pRes->GetBrdID();
	return uval;
}

char* BoardManager::GetDaqBuf(unsigned int bid)
{
	int err = 0;
	BoardRes* pRes = 0;
	char* pBuf = 0;

	if(bid >= this->brdsNum)
	{
		err = -1;
		ErrPrintf("bid is too large or equal to 0");
		return 0;
	}
	
	pBuf = this->daqBuf;
	if(pBuf == NULL)
	{
		err = -1;
		ErrPrintf("daqBuf is null");
		return 0;
	}

	pBuf += bid * DEFAULT_DAQ_BUF_SIZE;
	return pBuf;	
}