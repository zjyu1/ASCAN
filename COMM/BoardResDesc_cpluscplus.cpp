//
#include "stdafx.h"
#include "DaqDefine.h"
#include "BoardResDesc_cplusplus.h"

BoardRes::BoardRes()
{
	this->boardId = 0;

	this->boardName = "";


	//pBuf prepared for daqReadTSQ()
	this->pBuf = 0;
	this->bufSize = 0;

	//filled data UniSetPacket num array
	this->fillNum = 0;

	//remain data UniSetPacket num in array
	this->freeNum = USCOMM_DEFAULT_SET_NUMBER;

	//const = 32
	this->totalNum = USCOMM_DEFAULT_SET_NUMBER; 

	//rd ptr
	this->rdPos = 0;

	//wr ptr
	this->wrPos = 0; 

	//
	this->pPkts = 0;
	this->pktNums = 0;

	this->isOpen = false;

	this->dftPktCapcity = USCOMM_DEFAULT_SET_NUMBER; //number
	this->dftBufCapcity = DEFAULT_DAQ_BUF_SIZE; //unit bytes

	//log file name
	this->logFileName = "ErrLogBoardRes.txt";

	//open log file, has bug?
	this->errLog.open(logFileName.c_str(), ios::trunc | ios::out); //if exsist, delete and new one file	
} //end of BoardRes()

BoardRes::~BoardRes()
{
	//delete pBuf
	if(this->pBuf != NULL)
	{
		delete [] (this->pBuf);
		this->pBuf = NULL;
	}
			
	//delete pPkts
	if(this->pPkts != NULL)
	{
		delete [] (this->pPkts);
		this->pPkts = NULL;
	}

	//close logfile
	this->errLog.close();

} //end of ~BoardRes(...)

int BoardRes::Init(unsigned int brdId, string brdName)
{
	int err = 0;

	this->boardId = brdId;
	this->boardName = brdName;

	//alloc pBuf
	this->pBuf = new char[this->dftBufCapcity];
	if(this->pBuf == NULL)
	{
		err = -2;	
		ErrPrintf("alloc pBuf failor");
		return err;
	}

	//alloc Pkts
	this->pPkts = new struct UniSetPacket[this->dftPktCapcity];
	if(this->pPkts == NULL)
	{
		err = -2;	
		ErrPrintf("alloc pPkts failor");
		delete [] this->pBuf;
		this->pBuf = NULL;
		return err;
	}	

	//
	initUniPkt();

	this->isOpen = true;

	return err;
}

/*************************************************
Function: int PopOneUniPktOut(UniSetPacket* pPkt)

Description:  pop out one frame from BoardRes uni packet array, and fetch out to pPkt

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:
		pPkt:  uni packet  ptr, must be alloced prevoisly
		  
Output:
		pPkt: if success, will be filled.
Return: 
     error_code: error code defined in daqerr.h
Others: 
    // none.
*************************************************/
int BoardRes::PopOneUniPktOut(struct UniSetPacket* pPkt)
{
		//DEFINATION
	int err;
	struct UniSetPacket* pUni;
	unsigned int uniPktNum;
	int i;
	unsigned int*  pPos;
	unsigned int num;

	unsigned int id;
	unsigned int cellNum;
	

	//INIT
	err = 0;
	pUni = NULL;
	uniPktNum = 0;
	i = 0;

	pPos = NULL;
	num = 0;

	//CHECK INPUTS
	if(pPkt == 0)
	{
		err = -1;
		ErrPrintf("input para is null");
		return err;
	}

	//INIT
	memset((void*)pPkt, 0, sizeof(struct UniSetPacket));
	pUni = this->pPkts;
	
	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	if(this->Empty() == true) //all readed out
	{
		err = -3;
		ErrPrintf("all uni packet has been readed out");
		return err;
	}

	//popout data
	pUni += this->rdPos;

	//memcpy((void*)pPkt, (void*)pUni, sizeof(struct UniSetPacket));
	//pPos = (unsigned int *)pPkt;

	//copy header and ud
	num = (4+2+8+ITEM_UD_MAX_SIZE); //port, id, bin, size, start[2], stampmode, stampPos[3], stampInc[3], cellNum, ud[ITEM_UD_MAX_SIZE]
	memcpy((void*)pPkt, (void*)pUni, num*sizeof(unsigned int));
	

	//copy fd
	id =pUni->id;
	cellNum = pUni->cellNum;
	if(id == DAQ_ITEM_ID_ASCAN_VIDEO)
	{
		num = ASCAN_INNER_DOUBLE_SIZE/sizeof(float) + ASCAN_LENGTH * 3; //wave, minEnv, MaxEnv
	}
	else if(id > 0 && (id < DAQ_ITEM_ID_ALRAM_DISP || id == DAQ_ITEM_ID_COUPLE_SUPERVISORY))
	{
		num = cellNum;
	}
	else //alarm disp, none
	{
		num = 0;
	}
	
	if(num > 0)
	{
		memcpy(pPkt->fd, pUni->fd, num*sizeof(float));
	}
	
	//copy stop
	memcpy(pPkt->stop, pUni->stop, 2*sizeof(unsigned int));

	
	//update pRes
	this->fillNum -= 1;

	this->freeNum += 1;

	this->rdPos += 1;

	if(this->wrPos == this->rdPos)
	{
		this->wrPos = 0;
		this->rdPos = 0;
	}
	else if(this->rdPos > this->wrPos)
	{
		err = -3;
		ErrPrintf("rdPos > wrPos");
		return err;
	}

	return err;

} //end of PopOneUniPktOut(...


/*************************************************
Function: int BoardRes::PushUnUniPktIn(void* pBuffer, unsigned int size)

Description:  read daq and parse the packet to UniSetPacket

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:
		none.		  
Output:
		none.
Return: 
     error_code: error code defined in daqerr.h
Others: 
    // none.
*************************************************/
int BoardRes::PushUnUniPktIn(void* pBuffer, unsigned int size)
{
	//DEFINATION
	int err;
	int i;

	//INIT
	err = 0;
	i = 0;

	//CHECK INPUTS
	if(pBuffer == NULL)
	{
		err = -1;
		ErrPrintf("pBuffer is null");
		return err;
	}
	if(size == 0 || size%sizeof(unsigned int) != 0 || size > this->dftBufCapcity)
	{
		err = -1;
		ErrPrintf("size  is 0 or %4 != 0 or size > dftBufCapcity");
		return err;
	}

	//INIT

	
	
	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	if(Empty() == false) //not all readed out
	{
		err = -2;
		ErrPrintf("pUniPkt is should freed before push in");
		return err;
	}
	
	//copy data
	memcpy((void*)this->pBuf, pBuffer, size);

	this->bufSize = size;


	//parse data
	err = parsePacket();
	if(err != 0)
	{
		ErrPrintf("parse packet err");
		return err;
	}

	//update pRes
	this->fillNum = this->pktNums;

	this->freeNum = this->totalNum - this->fillNum;

	this->rdPos = 0;

	this->wrPos = this->fillNum;


	return err;
} //end of ReadDaqPushIn(...


/*************************************************
Function: int BoardRes::initUniPkt()

Description:  init pPkt's content to zero

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:
		//none.
		  
Output:
		none
Return: 
     error_code: error code defined in daqerr.h
Others: 
    // none.
*************************************************/
int BoardRes::initUniPkt()
{
	//DEFINATION
	int err;
	struct UniSetPacket* pUni;

	int i;

	//INIT
	err = 0;
	pUni = NULL;

	i = 0;

	//CHECK INPUTS
	//none.
	pUni = this->pPkts;
	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	for(i=0; i<(int) this->dftPktCapcity; i++)
	{
		pUni += i;

		pUni->port = 0;
		pUni->id = 0;
		pUni->bin = 0;
		pUni->size = 0;

		memset(pUni->start, 0, 8);

		//UploadTagHeader
		pUni->stampMode = 0;

		pUni->stampPos[0] = 0;
		pUni->stampPos[1] = 0;
		pUni->stampPos[2] = 0;

		pUni->stampInc[0] = 0;
		pUni->stampInc[1] = 0;
		pUni->stampInc[2] = 0;

		pUni->cellNum = 0;

		//uint data
		for(i=0; i<(int)PACKET_UINT_SIZE; i++)
		{
			pUni->ud[i] = 0;
		}

		for(i=0; i<(int)PACKET_FLOAT_SIZE; i++)
		{
			pUni->fd[i] = 0.0;
		}
	
		memset(pUni->stop, 0, 8);
	}

	return err;

} //end of initUniPkt(...

/*************************************************
Function: int BoardRes::ChkHeaderId(unsigned int id)

Description:  check head id is valid?

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:
		id: header id to be checked		
		  
Output:
		none.
Return: 
     error_code: error code defined in daqerr.h
Others: 
    // none.
*************************************************/
int BoardRes::ChkHeaderId(unsigned int id)
{
	//DEFINATION
	int err;	
	int i;

	//INIT
	err = 0;	
	i = 0;

	//CHECK INPUTS
	
	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	switch(id)
	{
		case DAQ_ITEM_ID_I_GATE:   //I
			{
				err = 0;
			}
			break;
		case DAQ_ITEM_ID_A_GATE:   //A
			{
				err = 0;
			}
			break;
		case DAQ_ITEM_ID_B_GATE:  //B
			{
				err = 0;
			}
			break;
		case DAQ_ITEM_ID_C_GATE:  //C
			{
				err = 0;
			}
			break;
		case DAQ_ITEM_ID_BA_2GATE: //BA
			{
				err = 0;
			}
			break;
		case DAQ_ITEM_ID_AI_2GATE: //AI
			{
				err = 0;
			}
			break;
		case DAQ_ITEM_ID_BI_2GATE: //BI
			{
				err = 0;
			}
			break;
		case DAQ_ITEM_ID_CI_2GATE:  //CI
			{
				err = 0;
			}
			break;
		case DAQ_ITEM_ID_ALRAM_DISP:  
			{
				err = 0;
			}
			break;
		case DAQ_ITEM_ID_ASCAN_VIDEO:  
			{
				err = 0;
			}
			break;		
		case DAQ_ITEM_ID_STATUS:  
			{
				err = 0;
			}
			break;	
		case DAQ_ITEM_ID_EVENT:  
			{
				err = 0;
			}
			break;	
		case DAQ_ITEM_ID_COUPLE_SUPERVISORY:  
			{
				err = 0;
			}
			break;	
		case DAQ_ITEM_ID_NONE:
			{
				err = -1;
				////logPrintf("")
			}
			break;			
		default:
			{
				err = -1;
				////logPrintf("")
			}
			break;
	} 

	return err;

} //end of ChkHeaderId(...


/*************************************************
Function: int parsePacket(void* pBuf, unsigned int bufSize, UniSetPacket* pUni, unsigned int * num)

Description:  parse and copy pBuf data to normal UniSetPacket buf

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:
		pBuf: packet data ptr
		bufSize: pBuf content size (byte unit)
        pUni: UniSetPacket ptr, data where to parsed to
		num:  return parsed out UniSetPacket number		
		  
Output:
		num:  if success, return parsed out UniSetPacket number.
Return: 
     error_code: error code defined in daqerr.h
Others: 
    // none.
*************************************************/
int BoardRes::parsePacket()
{
	//DEFINATION
	int err;
	unsigned int   tolNum;
	unsigned int*  pUintPtr;
	unsigned int*  pUintTmpPtr;
	float*         pFloatPtr;
	struct UniSetPacket* pUni;

	//header
	unsigned int id;
	unsigned int bin;
	unsigned int size;

	unsigned int cellNum;
	
		
	int i;
	int remain;

	unsigned int setNum;
	unsigned int copyedSize;

	unsigned int uVal;

	//INIT
	err = 0;
	tolNum = 0;	
	pUintPtr = 0;
	pUintTmpPtr = 0;
	pFloatPtr = 0;
	pUni = 0;

	id = 0;
	bin = 0;
	size = 0;

	cellNum = 0;

	i = 0;
	remain = 0;

	setNum = 0;
	copyedSize = 0;

	uVal = 0;


	//CHECK INPUTS
	if(this->pBuf == NULL)
	{
		err = -1;
		ErrPrintf("this->pBuf is null");
		return err;
	}

	if(this->bufSize == 0)
	{
		err = -1;
		ErrPrintf("this->bufSize is 0");
		return err;
	}

	if(this->pPkts == NULL)
	{
		err = -1;
		ErrPrintf("this->this->pUni is NULL");
		return err;
	}

	if(this->dftPktCapcity == 0)
	{
		err = -1;
		ErrPrintf("this->pktNums is 0");
		return err;
	}

	//INIT
	pUni = this->pPkts;
	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	//fetch total item number
	pUintPtr = (unsigned int *) this->pBuf;
	tolNum = (*pUintPtr);
	if(tolNum > USCOMM_DEFAULT_SET_NUMBER)
	{
		err = -2;
		ErrPrintf("tolNum > default max uni pkt capcity");
		return err;
	}
	if(tolNum <= 0)
	{
		err = -1;
		ErrPrintf("tolNum <= 0");
		return err;
	}

	//
	copyedSize = copyedSize + sizeof(unsigned int);

	//iter for item
	pUintPtr++;
	for(i = 0; i < (int)tolNum; i++)
	{
		if(copyedSize > this->bufSize)
		{						
			err = -3;
			ErrPrintf("copyedSize > buf size");	
			return err;
		}

		pUintTmpPtr = pUintPtr;

		//Go to id
		pUintTmpPtr ++;

		//fetch item header
		id = (*pUintTmpPtr);

		//construt UniSetPacket
		err = ChkHeaderId(id);
		if(err != 0)
		{
			ErrPrintf("id err");
			return err;
		}

		//copy item header
		memcpy( (void*)pUni, (void*)pUintPtr, sizeof(struct ItemHeader));
		pUintPtr += 4;

		id  = pUni->id;
		bin = pUni->bin;
		size = pUni->size;
		

		//copy start
		memcpy( (void*)pUni->start, (void*)pUintPtr, 2* sizeof(unsigned int));
		//check start
		if(pUni->start[0] != DAQ_START_FLAG_LOW)
		{
			err = -3;
			ErrPrintf("parse start flag error!");
			return err;
		}
		if(pUni->start[1] != DAQ_START_FLAG_HIGH)
		{
			err = -3;
			ErrPrintf("parse start flag error");
			return err;
		}

		/*uVal = *pUintPtr;
		if(uVal != DAQ_START_FLAG_LOW) 
		{
			err = -3;
			ErrPrintf("");
			return err;
		}
		uVal = *(pUintPtr + 1);
		if(uVal != DAQ_START_FLAG_HIGH) 
		{
			err = -3;
			ErrPrintf("");
			return err;
		}*/

		pUintPtr += 2;

		//copy tag header
		memcpy( (void*)&(pUni->stampMode), (void*)pUintPtr, sizeof(struct UploadTagHeader));
		pUintPtr += 8;

		cellNum = pUni->cellNum;

		//copy ud and fd
		if(id == DAQ_ITEM_ID_ASCAN_VIDEO)
		{
			if(cellNum != 1)
			{
				err = -3;
				ErrPrintf("ascan cell num is not 1");
				return err;
			}

			//copy ascanVideo uint type data
			memcpy((void*) pUni->ud, (void*)pUintPtr, 15 * sizeof(unsigned int)); 
			pUintPtr += 15;

			pFloatPtr = (float*)(pUintPtr);
			remain =  size - 31 * sizeof(unsigned int); //port, bin, id, size, start[2], tag[8], unit[15], stop[2]
			if(remain != (1024*3 + 13)*sizeof(float) && remain != (512*3 + 13)*sizeof(float))
			{
				err = -3;
				ErrPrintf("parse ascan remain is not equal to its size!");
				return err;
			}

			//copy double paras before delay
			memcpy((void*) pUni->fd, (void*) pFloatPtr, remain);	

			pUintPtr = (unsigned int*)pFloatPtr;
			pUintPtr += remain/sizeof(unsigned int);

		}
		else if(id == DAQ_ITEM_ID_ALRAM_DISP)
		{
			//check item size
			remain =  size - 16 * sizeof(unsigned int); //id,bin,size,start[2], tag[8], stop[2]
			if(remain != cellNum * sizeof(unsigned int))
			{
				err = -3;
				ErrPrintf("DAQ_ITEM_ID_ALRAM_DISP id remain not equal to cellNum's size");
				return err;
			}
			//copy item data
			memcpy((void*) pUni->ud, (void*)pUintPtr, remain);

			pUintPtr += remain/sizeof(unsigned int);

		}
		else if(id == DAQ_ITEM_ID_STATUS)
		{	
			//check item size
			remain =  size - 16 * sizeof(unsigned int); // port,id,bin,size,start[2], tag[8], stop[2]
			if(remain != cellNum * sizeof(unsigned int)*3)
			{
				err = -3;
				ErrPrintf("DAQ_ITEM_ID_STATUS id remain not equal to cellNum's size");
				return err;
			}

			//copy item data
			memcpy((void*) pUni->ud, (void*)pUintPtr, remain);

			pUintPtr += remain/sizeof(unsigned int);
		}
		else if(id==DAQ_ITEM_ID_EVENT)
		{
			//check item size
			remain =  size - 16 * sizeof(unsigned int); // port,id,bin,size,start[2], tag[8], stop[2]
			if(remain != 0)
			{
				err = -3;
				ErrPrintf("DAQ_ITEM_ID_EVENT id remain not equal to its size!");
				return err;
			}
		}
		else //construct gate, 
		{
			
			//check item size
			remain =  size - 16 * sizeof(unsigned int); //id,bin,size,start[2], tag[8], stop[2]
			if(remain != cellNum * sizeof(float)) // pls attension with gate in data
			{
				err = -3;
				ErrPrintf("DAQ_ITEM_GATE or GATE2 id remain not equal to cellNum's size");
				return err;
			}
			//copy item data
			memcpy((void*) pUni->fd, (void*)pUintPtr, remain); //pls attension with data type, we see it as double

			//align
			pUintPtr += remain/sizeof(unsigned int);

		}

		//copy "__stop__"
		memcpy((void*) pUni->stop, (void*)pUintPtr , 2*sizeof(unsigned int));

		if(pUni->stop[0] != DAQ_STOP_FLAG_LOW)
		{
			err = -3;
			ErrPrintf("stop flag error");
			return err;
		}
		if(pUni->stop[1] != DAQ_STOP_FLAG_HIGH)
		{
			err = -3;
			ErrPrintf("stop flag error");
			return err;
		}

		/*uVal = *pUintPtr;
		if(uVal != DAQ_STOP_FLAG_LOW) 
		{
			err = -3;
			ErrPrintf("");
			return err;
		}
		uVal = *(pUintPtr + 1);
		if(uVal != DAQ_STOP_FLAG_HIGH) 
		{
			err = -3;
			ErrPrintf("");
			return err;
		}*/

		//align to next item header
		pUintPtr += 2; //
	
		//update num
		setNum = setNum + 1;

		//update pUni
		pUni += 1;

		copyedSize += size;                          

	} //end for(...

	if(copyedSize != this->bufSize)
	{
		err = -3;
		ErrPrintf("");
		return err;
	}

	this->pktNums = setNum;

	return err;

} //end of parsePacket(...

bool BoardRes::Empty()
{
	if(this->wrPos == this->rdPos)
	{
		return true;
	}
	else
	{
		return false;

	}
} //end of Empty()

void BoardRes::LogPrintf(long line, char* strfunc,char* strErr)
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


unsigned int BoardRes::GetBrdID()
{
	return this->boardId;
}

string BoardRes::GetBrdName()
{
	return this->boardName;
}








