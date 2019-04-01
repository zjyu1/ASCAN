#include "stdafx.h"
#include "DaqDefine.h"
#include "ItemPacket.h"
#include "Simulate_cplusplus.h"

/*************************************************
Function: SimulateAscan()

Description:  construct function, init all datas

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:
		none
Output:
		none
Return: 
		none
Others: 
    // none.
*************************************************/
unsigned int SimulateAscan::ascanPointNum = 0;
double*  SimulateAscan::pRamFile = 0;

SimulateAscan::SimulateAscan()
{
//RAM FILE
	//Ascan Ram file
	this->pRamFile = 0;	

	//frame position for draw one ascan frame
	this->framePos = 0;  

	//flag for is load txt file
	this->isLoad = false;

	//txt file name for ascan source data 
	this->fileName = "";

	//txt file one frame has how much linenum
	this->linePointNum = 0;

	//total frame number
	this->totalFrameNum = 0;

	//current measurement position 
	this->measurePos = 0;

	this->doubleGatesPos = 0;

	this->isMax = true;
	
//TOTAL PKT SIZE
	this->totalPktSize = 0;
	this->pPktFile = 0;

//SUB ITEM NUMBER
	//ascan item number
	this->ascanItemNum = 0;

	//status item number
	this->statusItemNum = 0;
	//alarm item number

	this->alarmItemNum = 0;

	//gate item number
	this->gateItemNum = 0;

	//double gate item number
	this->gate2ItemNum = 0;

	this->totalItemNum = 0;

//SUB ITEM CELL NUMBER
	//ascan item cell number
	this->ascanCellNum = 0;

	//status item cell number
	this->statusCellNum = 0;
	//alarm item cell number

	this->alarmCellNum = 0;

	//gate item cell number
	this->gateCellNum = 0 ;

	//double gate item cell number
	this->gate2CellNum = 0;

//SUB PKT SIZE
	CalItemSize();

	pktWrPos = 0;


//LOG
	//log file name
	this->logFileName = "ErrLogSimulateAscan.txt";

	//open log file, has bug?
	this->errLog.open(logFileName.c_str(), ios::trunc | ios::out); //if exsist, delete and new one file	
	
} //end of SimulateAscan()

/*************************************************
Function: ~SimulateAscan()

Description:  desconstruct function, free all resources

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:
		none
Output:
		none
Return: 
		none
Others: 
    // none.
*************************************************/
 SimulateAscan::~SimulateAscan()
{
	if(this->pRamFile != 0)
	{
		delete [] this->pRamFile;
		this->pRamFile = 0;
	}	

	if(this->pPktFile != 0)
	{
		delete [] this->pPktFile;
		this->pPktFile = 0;
	}
	
	//close logfile
	this->errLog.close();	
		
} //end of ~SimulateAscan()



/*************************************************
Function: LogPrintf(char* func, char* strErrInfo)

Description:  log print to ErrLogSimulateAscan.txt file, the format is
              function name(...) + err info +, pls chk!

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:
		func: which function
		strErrInfo: str err info want to output
Output:
		none
Return: 
		none.
Others: 
    // none.
*************************************************/
void SimulateAscan::LogPrintf(long line, char* strfunc,char* strErr)
{
	char s[256];

	sprintf_s(s, "%d", line);
	
	this->errLog << "Date: " << __DATE__ << ".\n";

	this->errLog << "Time: " << __TIME__ << ".\n";

	this->errLog << "Line: " << s << ".\n";

	this->errLog << strfunc <<"(...),  "<< strErr <<",  pls chk!.\n";	

	this->errLog << "\n";

	this->errLog<< flush;

} //end of (...


/*************************************************
Function: int SimulateAscan::LoadFile()

Description:  read out ascan frames from txt file to  memory

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
    if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int SimulateAscan::LoadFile()
{
	//DEFINATION
	int err;
	
	
	//INIT
	err = 0;	
	

	//CHECK INPUTS
	if(this->fileName.empty())
	{
		err = -1;
		ErrPrintf("txt file name is null!" );
		return err;
	}
	if(this->linePointNum == 0 || this->linePointNum > SIM_ASCAN_LENGTH)
	{
		err = -1;
		ErrPrintf("txt file line number is 0 or >= SIM_ASCAN_LENGTH!" );
		return err;
	}
	if(this->pRamFile != 0)
	{
		delete [] this->pRamFile;
		this->pRamFile = 0;
	}
	
	if(this->totalFrameNum != 0)
	{
		this->totalFrameNum = 0;
		this->framePos = 0;
	}

	//INIT
	this->isLoad = false;

	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	err = ReadFromFile();
	if(err != 0)
	{
		err = -3;
		ErrPrintf("read txt file failor");
		return err;
	}
	

	this->totalFrameNum = this->ascanPointNum/this->linePointNum;
	this->framePos = 0;

	this->isLoad = true;
	//close or free resources	  

	return err;

} //end of NewRamFile(...

/*************************************************
Function: int SimulateAscan::ReadFromFile()

Description:  read out ascan frames from txt file to  memory

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
    if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int SimulateAscan::ReadFromFile()
{
	//DEFINATION
	int err;
	int count;
	FILE* infile;
	
	int* pIntPtr;
	double* pDoublePtr;

	double dbVal;
	int i;
	int j;


	//INIT
	err = 0;
	count = 0;
	infile = 0;
	

	pIntPtr = 0;
	pDoublePtr = 0;
	
	dbVal = 0;
	i = 0;
	j = 0;
	

	//CHECK INPUTS	
	if(this->pRamFile != NULL)
		return 0;
	
	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	pIntPtr = new int[DEFAULT_DAQ_BUF_SIZE];
	if(pIntPtr == NULL)
	{
		err = -2;
		ErrPrintf("alloc memory failor");
		return err;
	}

	
	err =  fopen_s(&infile, this->fileName.c_str(),"r");
	if(err != 0)
	{
		err = -3;
		ErrPrintf("open txt file failor");
		delete [] pIntPtr;
		pIntPtr = 0;
		return err;
	}

	count = 0;
	while(1 && count < DEFAULT_DAQ_BUF_SIZE)
	{
		err = fscanf_s(infile, "%d", &(pIntPtr[count]));
		if(feof(infile))
		{
			break;
		}
		else if(err != 1)
		{
			err = -3;
			ErrPrintf("fscanf txt file err");
			delete [] pIntPtr;
			pIntPtr = 0;
			return err;
		}
		count++;
	} //end while
	
	//align to last on
	//count = count;

	this->pRamFile = new double [32*DEFAULT_DAQ_BUF_SIZE];

	if(this->pRamFile == 0)
	{
		err = -2;
		ErrPrintf("alloc ram file failor" );
		return err;
	}		

	
	pDoublePtr = this->pRamFile;
	for(i=0; i<count; i++)
	{
		if(i%this->linePointNum == 0 && i > 0) //after line number
		{
			for(j = this->linePointNum; j< SIM_ASCAN_LENGTH; j++) //such as 150~ 1023
			{
				dbVal = 0;
				(*pDoublePtr) = dbVal;
				pDoublePtr++;
			}

			//push in #150 point
			dbVal = ((double) pIntPtr[i])/4194304; //1024
			(*pDoublePtr) = dbVal;
			pDoublePtr++;
		}
		else //before linenum, such as #0~#149
		{
			dbVal = ((double) pIntPtr[i])/4194304;
			(*pDoublePtr) = dbVal;
			pDoublePtr++;
		}
				
	}
	
	//update total ascan point
	this->ascanPointNum = count;	
    
    err = fclose(infile);
	if(err != 0)
	{
		err = -3;
		ErrPrintf("close txt file failor");
		delete [] pIntPtr;
		pIntPtr = 0;
		return err;
	}

	//free resources
	delete [] pIntPtr;
	pIntPtr = 0;
	
	return err;	

} //end of ReadFromFile(...


/*************************************************
Function: int SimulateAscan::DrawOneFrame(double* pFrame)

Description:  draw one frame from ram file

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:		
		pFrame: readed out buffer for frame(1024 double point), should be alloc already
		  
Output:
		pFrame: if success, pFrame will be filled
Return: 
     if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int SimulateAscan::DrawOneFrame(double* pFrame)
{
	//DEFINATION
	int err;
	double* pDoublePtr;
	

	//INIT
	err = 0;	
	pDoublePtr = 0;
	

	//CHECK INPUTS
	if(this->isLoad == false)
	{
		err = -1;
		ErrPrintf("txt file has not loaded, pls call Load function");
		return err;
	}

	if(pFrame == 0)
	{
		err = -1;
		ErrPrintf("input frame ptr is null");
		return err;
	}	

	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	if(this->framePos == (this->totalFrameNum - 1) )
	{
		this->framePos = 0;
	}

	pDoublePtr = this->pRamFile + SIM_ASCAN_LENGTH * this->framePos;

	memcpy(pFrame, pDoublePtr, SIM_ASCAN_LENGTH * sizeof(double));

	this->framePos++;

	return err;	
} //end of SimDrawOneAscanFrame(...

/*************************************************
Function: int SimulateAscan::DrawOneFrame(double* pFrame)

Description:  draw measurement data from ram file

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:		
		pFrame: readed out buffer for measurement data, should be alloc already
		  
Output:
		pFrame: if success, pFrame will be filled
Return: 
     if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int SimulateAscan::DrawMeasureData(double* pFrame)
{
	//DEFINATION
	int err;
	double* pDoublePtr;
	int i;
	int j;
	double* pStartPtr;
	

	//INIT
	err = 0;	
	pDoublePtr = 0;
	i = 0;

	//CHECK INPUTS
	if(this->isLoad == false)
	{
		err = -1;
		ErrPrintf("txt file has not loaded, pls call Load function");
		return err;
	}

	if(pFrame == 0)
	{
		err = -1;
		ErrPrintf("input frame ptr is null");
		return err;
	}	

	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	if(this->framePos >= this->ascanItemNum)
	{
		pStartPtr = this->pRamFile + SIM_ASCAN_LENGTH * (this->framePos - this->ascanItemNum);
		for(i = 0; i < this->ascanItemNum; i++)
		{
			pDoublePtr = pStartPtr + SIM_ASCAN_LENGTH * i + SIM_MEASURE_POS;
			*pFrame = *pDoublePtr;
			pFrame++;
		}
	}
	else
	{
		pStartPtr = this->pRamFile + SIM_ASCAN_LENGTH * (this->totalFrameNum - (this->ascanItemNum - this->framePos));
		for(i = 0; i < (this->ascanItemNum - this->framePos); i++)
		{
			pDoublePtr = pStartPtr + SIM_ASCAN_LENGTH * i + SIM_MEASURE_POS;
			*pFrame = *pDoublePtr;
			pFrame++;
		}
		for(j = 0; j < this->framePos; j++)
		{
			pDoublePtr = this->pRamFile + SIM_ASCAN_LENGTH * j + SIM_MEASURE_POS;
			*pFrame = *pDoublePtr;
			pFrame++;
		}
	}

	return err;	
}

/*************************************************
Function: int SimulateAscan::DrawDoubleGatesData(double* pFrame)

Description:  draw measurement data from ram file

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Input:		
		pFrame: readed out buffer for measurement data, should be alloc already
		  
Output:
		pFrame: if success, pFrame will be filled
Return: 
     if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int SimulateAscan::DrawDoubleGatesData(double* pFrame)
{
	//DEFINATION
	int err;
	double random;
	int i;
	

	//INIT
	err = 0;	
	i = 0;
	random = 0;

	//CHECK INPUTS
	if(this->isLoad == false)
	{
		err = -1;
		ErrPrintf("txt file has not loaded, pls call Load function");
		return err;
	}

	if(pFrame == 0)
	{
		err = -1;
		ErrPrintf("input frame ptr is null");
		return err;
	}	

	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	if(this->isMax)
	{
		for(i = 0; i < this->gate2CellNum; i++)
		{
			random = 2.0 * rand() / RAND_MAX - 1.0; 
			*pFrame = MAX_THICKNESS + random;
			pFrame++;
		}
	}
	else
	{
		for(i = 0; i < this->gate2CellNum; i++)
		{
			random = 2.0 * rand() / RAND_MAX - 1.0; 
			*pFrame = MIN_THICKNESS + random;
			pFrame++;
		}
	}

	return err;	
}

int SimulateAscan::Init(string fname, unsigned int linePtNum)
{
	int err = 0;


	//flag for is load txt file
	this->isLoad = false;

	//txt file name for ascan source data 
	if(fname.empty())
	{
		this->fileName = "";
		err = -1;
		ErrPrintf("input file name is empty");
		return err;
	}
	else
	{
		this->fileName = fname;
	}
	

	//txt file one frame has how much linenum
	this->linePointNum = linePtNum;


	//cal sub packet size
	CalItemSize();
	
	//cal total pkt size
	CalTotalPktSize() ;

	if(this->pPktFile != 0)
	{
		delete [] this->pPktFile;
		this->pPktFile = 0;
	}
	
	this->pPktFile = new char[this->totalPktSize];	
	if(this->pPktFile  == 0)
	{
		err = -2;
		ErrPrintf("alloc pPktFile err");
		return err;
	}

	this->pktWrPos = (char*)this->pPktFile;


//LOAD FILE
	err = LoadFile();
	if(err != 0)
	{
		err = -3;
		ErrPrintf("call LoadFile() function err");
		return err;
	}


	return err;
	
} //end of Init(...

/*************************************************
Function: void SimulateAscan::CalTotalPktSize()

Description: cal total pkt size based on item number, and item sub pkt size

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Implicit Input:		
		this->ascanItemNum    ,this->ascanItemSize
		this->statusItemNum   ,this->statusItemSize
		this->alarmItemNum    ,this->alarmItemSize
		this->gateItemNum     , this->gateItemSize
		this->gate2ItemNum    ,this->gate2ItemSize

Implicit Output:
		this->totalPktSize
Return: 
     none.
Others: 
    // none.
*************************************************/
void SimulateAscan::CalTotalPktSize()
{
	int size;

	size = 0;
	size += this->ascanItemNum * this->ascanItemSize;   //ascan
	size += this->statusItemNum * this->statusItemSize; //status
	size += this->alarmItemNum * this->alarmItemSize;   //alarm
	size += this->gateItemNum * this->gateItemSize;     //gate
	size += this->gate2ItemNum * this->gate2ItemSize;   //double gate
		
	size += sizeof(unsigned int); //total item is one uint

	this->totalPktSize = size;

	return;
} //end of CalTotalPktSize(...

/*************************************************
Function: int SimulateAscan::CalItemSize()

Description:  cal each type item size, one status item, one alarm item, one gate item, one 2gate item, 
                                       and one ascan item

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

ImplicitInput:		
		this->ascanCellNum
		this->statusCellNum
		this->alarmCellNum
		this->gateCellNum
		this->gate2CellNum
		SIM_ASCAN_LENGTH
Implicit Output:
		this->ascanItemSize
		this->statusItemSize
		this->alarmItemSize
		this->gateItemSize
		this->gate2ItemSize
Return: 
     error_code: error code defined in daqerr.h
Others: 
    // none.
*************************************************/
void SimulateAscan::CalItemSize()
{
	//DEFINATION
	unsigned int size;
	unsigned int cellNum;
	unsigned int headSize;


	//INIT
	size = 0;
	cellNum = 0;
	headSize = 0;

	//CHECK INPUTS
	//none

	//header size
	size = 4*sizeof(unsigned int);     //bin header size
	size +=  8*sizeof(char);   //start[2] 
	size +=  8*sizeof(unsigned int);   //stamp mode, stamp pos[3], stamp inc[3], cellNum
	size +=  8*sizeof(char);   //stop[2] 
	headSize = size;


	//MAIN
	//ascan size
	size = 15 * sizeof(unsigned int);//len, ifStartm, tofUnit, ampUnit, echoMax, waveDetectMode, envelopStart, led[8]	
	size += 13 * sizeof(double);//delay, width, gain, bea, decayFactor, ascanGateAmp[4], ascanGateTof[4]
	size += this->ascanCellNum * SIM_ASCAN_LENGTH * 3 * sizeof(double); //wave[SIM_ASCAN_LENGTH],maxEnvelop[SIM_ASCAN_LENGTH], minEnvelop[SIM_ASCAN_LENGTH]
	this->ascanItemSize = headSize + size;

	//status item	
	size =  this->statusCellNum * 3 * sizeof(unsigned int); //status[cellNum] = {status, errCode, beatHeart}*cellNum
	this->statusItemSize = headSize + size;

	//alarm item	
	size =  this->alarmCellNum * sizeof(unsigned int); //Alarm[cellNum]
	this->alarmItemSize = headSize + size;

	//gate item
	size = this->gateCellNum * sizeof(double); //amp[cellNum]
	this->gateItemSize = headSize + size;

	//double gate item
	size = this->gate2CellNum * sizeof(double);//thickness_max[cellNum]
	this->gate2ItemSize = headSize + size;

	return ;
} //end of CalItemSize(...


/*************************************************
Function: int SimulateAscan::SetItemNum(unsigned int ascan, unsigned int status,unsigned int alarm, unsigned int gate, unsigned int gate2)

Description: set item number

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Explicit Input:		
		//what item number want to be packed int packet
		ascan:
		status:
		alarm:
		gate:
		gate2:

Implicit Output:
		this->ascanItemNum
		this->statusItemNum
		this->alarmItemNum 
		this->gateItemNum
		this->gate2ItemNum

		this->tolalItemNum
Return: 
     none.
Others: 
    // none.
*************************************************/
void SimulateAscan::SetItemNum(unsigned int ascan, unsigned int status,unsigned int alarm, unsigned int gate, unsigned int gate2)
{

	//set
	this->ascanItemNum = ascan;
	this->statusItemNum = status;
	this->alarmItemNum = alarm;
	this->gateItemNum  = gate;
	this->gate2ItemNum = gate2;

	this->totalItemNum = this->ascanItemNum + this->statusItemNum +  this->alarmItemNum + this->gateItemNum  + this->gate2ItemNum;

	return ;
} //end of SetItemNum(...



/*************************************************
Function: void SimulateAscan::SetCellNum(unsigned int ascan, unsigned int status,unsigned int alarm, unsigned int gate, unsigned int gate2)

Description: set cell number

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Explicit Input:		
		//what item number want to be packed int packet
		ascan:
		status:
		alarm:
		gate:
		gate2:

Implicit Output:
		this->ascanCellNum
		this->statusCellNum
		this->alarmCellNum 
		this->gateCellNum
		this->gate2CellNum
Return: 
     none.
Others: 
    // none.
*************************************************/
void SimulateAscan::SetCellNum(unsigned int ascan, unsigned int status,unsigned int alarm, unsigned int gate, unsigned int gate2)
{
	//set
	this->ascanCellNum = ascan;
	this->statusCellNum = status;
	this->alarmCellNum = alarm;
	this->gateCellNum = gate;
	this->gate2CellNum = gate2;

} //end of SetCellNum(...


/*************************************************
Function: SimulateAscan::GenBoardPkt()

Description: generate one upload packet, base on CellNums, ItemNums, and pRamFile

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Implicit Input:		
		this->totalPktSize
		this->pPktFile
Implicit Output:
		this->pPktFile

Explict Input:
		pBuf: where to copy out, should be alloced previously
		bufSize: pBuf's size

Explict Output:
		pBuf: if success, which will be filled
		bufSize: if success, which will be updated to indicate what size data pushed in pBuf

Return: 
      if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int  SimulateAscan::GenBoardPkt(void* pBuf, unsigned int* bufSize)
{
	//DEFINATION
	int err;
	unsigned int* pUintBufPtr;
	void*         pTmpBuf;
	int i;
	unsigned int size;
	
	//INIT
	err = 0;
	pUintBufPtr = 0;
	pTmpBuf = 0;
	i = 0;
	size = 0;

	//CHECK INPUTS
	if(this->isLoad == false)
	{
		err = -1;
		ErrPrintf("txt file is not load, pls call Init() firstly");
		return err;
	}

	if(pBuf == 0)
	{
		err = -1;
		ErrPrintf("pBuf is null");
		return err;
	}

	if(*bufSize < this->totalPktSize)
	{
		err = -1;
		ErrPrintf("pBuf is not enough");
		return err;
	}
	
	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	

	//total item
	pUintBufPtr = (unsigned int*) this->pPktFile;
	(*pUintBufPtr) = this->totalItemNum;

	this->pktWrPos += sizeof(unsigned int);
	
	//ascan item
	for(i=0;i<(int)this->ascanItemNum;i++)
	{
		err |= PushAscanItem();
	}
	

	//status item
	for(i=0;i<(int)this->statusItemNum;i++)
	{
		err |= PushStatusItem(); 
	}

	//alarm item
	for(i=0;i<(int)this->alarmItemNum;i++)
	{
		err |= PushAlarmItem(); 
	}

	//gate item
	for(i=0;i<(int)this->gateItemNum;i++)
	{
		err |= PushGateItem();
	}

	//double gate item
	for(i=0;i<(int)this->gate2ItemNum;i++)
	{
		err |= Push2GateItem (); 
	}

	if(err != 0)
	{
		err = -3;
		ErrPrintf("push pkts err");
		return err;
	}

	//cpy in
	memcpy((void*)pBuf, (void*)this->pPktFile, this->totalPktSize);

	*bufSize = this->totalPktSize;

	this->pktWrPos = this->pPktFile;
	
	return err;

} //end of GenBoardPkt(...


/*************************************************
Function: SimulateAscan::PushAscanItem()

Description: push ascan to pPktFile

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Implicit Input:		
		this->ascanItemSize
		this->pktWrPos
		this->ascanCellNum
Implicit Output:
		this->pktWrPos

Return: 
      if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int  SimulateAscan::PushAscanItem()
{
	//DEFINATION
	int err;
	struct AscanSetPacket pkt;

	unsigned int * pUintPtr;
	double*    pDoublePtr;

	int i;

	unsigned int uVal;

	//INIT
	err = 0;
	memset(&pkt, 0, sizeof(struct AscanSetPacket));

	pUintPtr = 0;
	pDoublePtr = 0;

	i = 0;
	uVal = 0;

	
	//CHECK INPUTS
	//none.
	
	//INIT
	pUintPtr = (unsigned int*) this->pktWrPos;		

	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	//head
	pkt.head.port = 0;
	pkt.head.id = DAQ_ITEM_ID_ASCAN_VIDEO; 
    pkt.head.bin = 0; 
	pkt.head.size = this->ascanItemSize; 

	memcpy(pkt.start, "__start_", 8);
	//pkt.start[0] = (unsigned int)0x6774;
	//pkt.start[1] = (unsigned int )0x0041;

	//tag
	pkt.tag.stampMode = 1;
	pkt.tag.stampPos[0] = 1; 
    pkt.tag.stampPos[1] = 0; 
	pkt.tag.stampPos[2] = 0; 

	pkt.tag.stampInc[0] = 1; 
    pkt.tag.stampInc[1] = 0; 
	pkt.tag.stampInc[2] = 0; 

	pkt.tag.cellNum = this->ascanCellNum; 

	//ascan video
	pkt.len = SIM_ASCAN_LENGTH; 
	            
	
	pkt.ifStart = 0;
	
	pkt.tofUnit = 0;
	
	pkt.ampUnit = 0;

	pkt.echoMax = 0;
            
    pkt.waveDetectMode = 0;
	         
	
	pkt.envelopStart = 0;  
    pkt.led[0] = 0;
	pkt.led[1] = 0;
	pkt.led[2] = 0;
	pkt.led[3] = 0;
	pkt.led[4] = 0;
	pkt.led[5] = 0;
	pkt.led[6] = 0;
	pkt.led[7] = 0;
         

    pkt.delay = 0;

	pkt.width = 0;

    pkt.gain = 0; //  
	           
	
	pkt.bea = 0; //
		
	pkt.decayFactor = 0;  //decay factor

	//gate amp data
    pkt.ascanGateAmp[0] = 0;
	pkt.ascanGateAmp[1] = 0;
	pkt.ascanGateAmp[2] = 0;
	pkt.ascanGateAmp[3] = 0;
        
	//gate tof data
    pkt.ascanGateTof[0] = 0;
	pkt.ascanGateTof[1] = 0;
	pkt.ascanGateTof[2] = 0;
	pkt.ascanGateTof[3] = 0;

	pkt.wave = 0;
	pkt.maxEnvelop = 0;
	pkt.minEnvelop = 0;

	memcpy(pkt.stop, "__stop__", 8);
	//pkt.stop[0] = (unsigned int)0x6768;
	//pkt.stop[1] = (unsigned int )0x0041;

	//copy
	memcpy((void*)pUintPtr, &pkt, sizeof(struct AscanSetPacket));

	//align to wave 
	pUintPtr += sizeof(struct ItemHeader)/sizeof(unsigned int);
	pUintPtr += ITEM_START_SIZE/sizeof(unsigned int);
	pUintPtr += sizeof(struct UploadTagHeader)/sizeof(unsigned int);
	pUintPtr += ASCAN_INNER_UINT_SIZE/sizeof(unsigned int);
	pUintPtr += ASCAN_INNER_DOUBLE_SIZE/sizeof(unsigned int);

	pDoublePtr = (double*)(pUintPtr ); 

	//pkt.wave
    err = DrawOneFrame(pDoublePtr); //wave
	if(err != 0)
	{
		err = -3;
		ErrPrintf("draw one frame err");
		return err;
	}	

	pDoublePtr += SIM_ASCAN_LENGTH;

	for(i=0; i<SIM_ASCAN_LENGTH; i++)//max envelop
	{
		(*pDoublePtr) = (double)0;
		pDoublePtr++;
	}
	
	for(i=0; i<SIM_ASCAN_LENGTH; i++)//min envelop
	{
		(*pDoublePtr) = (double)0;
		pDoublePtr++;
	}	

	//stop
	pUintPtr = (unsigned int*) pDoublePtr;
	memcpy((void*)pUintPtr, pkt.stop, 8); 
	pUintPtr += 2;

	//check
	uVal = (unsigned int)((char*)pUintPtr - this->pktWrPos);
	if(uVal != this->ascanItemSize)
	{
		ErrPrintf("ascan push in size not correct");
	}

	//update write pos
	this->pktWrPos += this->ascanItemSize;

	return err;

} //end of PushAscanItem(... 

/*************************************************
Function: SimulateAscan::PushStatusItem()

Description: push status to pPktFile

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Implicit Input:		
		this->statusItemSize
		this->pktWrPos
		this->statusCellNum		
Implicit Output:
		this->pktWrPos

Return: 
      if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int  SimulateAscan::PushStatusItem()
{
	//DEFINATION
	int err;
	struct StatusSetPacket pkt;
	unsigned int * pUintPtr;

	int i;
	unsigned int uVal;

	//INIT
	err = 0;
	memset(&pkt, 0, sizeof(struct StatusSetPacket));
	pUintPtr = 0;
	i = 0;
	uVal = 0;

	//CHECK INPUTS
	//none.
	
	//INIT
	pUintPtr = (unsigned int*) this->pktWrPos;
	 

	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	//head
	pkt.head.port = 0;
	pkt.head.id = DAQ_ITEM_ID_STATUS; 
    pkt.head.bin = 0; 
	pkt.head.size = this->statusItemSize; 

	memcpy(pkt.start, "__start_", 8);
	//pkt.start[0] = (unsigned int)0x6774;
	//pkt.start[1] = (unsigned int )0x0041;

	//tag
	pkt.tag.stampMode = 1;
	pkt.tag.stampPos[0] = 1; 
    pkt.tag.stampPos[1] = 0; 
	pkt.tag.stampPos[2] = 0; 

	pkt.tag.stampInc[0] = 1; 
    pkt.tag.stampInc[1] = 0; 
	pkt.tag.stampInc[2] = 0; 

	pkt.tag.cellNum = this->statusCellNum;
    if(pkt.tag.cellNum  != 1)
	{
		ErrPrintf("status push in cellNum not 1");
	}

	//status data
    pkt.status = 2;
      
    pkt.errCode = 0;
        
    pkt.beatHeart = 10000;
      
	memcpy(pkt.stop, "__stop__", 8);
	//pkt.stop[0] = (unsigned int)0x6768;
	//pkt.stop[1] = (unsigned int )0x0041;

	//copy
	memcpy((void*)pUintPtr, &pkt, sizeof(struct StatusSetPacket));

	//
	uVal = sizeof(struct StatusSetPacket);
	if(uVal != this->statusItemSize)
	{
		ErrPrintf("status push in size not correct");
	}

	//update write pos
	this->pktWrPos += this->statusItemSize;

	return err;

} //end of PushStatusItem(... 

/*************************************************
Function: SimulateAscan::PushAlarmItem()

Description: push alarm to pPktFile

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Implicit Input:		
		this->alarmItemSize
		this->pktWrPos
		this->alarmCellNum
Implicit Output:
		this->pktWrPos

Return: 
      if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int  SimulateAscan::PushAlarmItem()
{
	//DEFINATION
	int err;
	struct AlarmSetPacket pkt;
	unsigned int * pUintPtr;

	int i;
	unsigned int uVal;

	//INIT
	err = 0;
	memset(&pkt, 0, sizeof(struct AlarmSetPacket));
	pUintPtr = 0;
	i = 0;
	uVal = 0;

	//CHECK INPUTS
	//none.
	
	//INIT
	pUintPtr = (unsigned int*) this->pktWrPos; 

	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	//head
	pkt.head.port = 0;
	pkt.head.id = DAQ_ITEM_ID_ALRAM_DISP; 
    pkt.head.bin = 0; 
	pkt.head.size = this->alarmItemSize; 

	memcpy(pkt.start, "__start_", 8);
	//pkt.start[0] = (unsigned int)0x6774;
	//pkt.start[1] = (unsigned int )0x0041;

	//tag
	pkt.tag.stampMode = 1;
	pkt.tag.stampPos[0] = 1; 
    pkt.tag.stampPos[1] = 0; 
	pkt.tag.stampPos[2] = 0; 

	pkt.tag.stampInc[0] = 1; 
    pkt.tag.stampInc[1] = 0; 
	pkt.tag.stampInc[2] = 0; 

	pkt.tag.cellNum = this->alarmCellNum; 

	//copy
	memcpy((void*)pUintPtr, &pkt, sizeof(struct AlarmSetPacket));

	//align to pkt.alarm
	pUintPtr += sizeof(struct AlarmSetPacket)/sizeof(unsigned int) - 3;

	//alarm data
	pkt.alarm = 0; 
	memset((void*)pUintPtr, 0, pkt.tag.cellNum * sizeof(unsigned int));
    
	//align to stop
	pUintPtr += pkt.tag.cellNum;

	memcpy(pkt.stop, "__stop__", 8);
	//pkt.stop[0] = (unsigned int)0x6768;
	//pkt.stop[1] = (unsigned int )0x0041;

	memcpy((void*)pUintPtr, (void*)pkt.stop, 8*sizeof(char));	
	pUintPtr += 2;

	//check 
	uVal = (unsigned int)((char*)pUintPtr - this->pktWrPos);
	if(uVal != this->alarmItemSize)
	{
		ErrPrintf("alarm push in size not correct");
	}
	//update write pos
	this->pktWrPos += this->alarmItemSize;

	return err;

} //end of PushAlarmItem(... 

/*************************************************
Function: SimulateAscan::PushGateItem()

Description: push gate to pPktFile

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Implicit Input:		
		this->gateItemSize
		this->pktWrPos
		this->gateCellNum
Implicit Output:
		this->pktWrPos

Return: 
      if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int  SimulateAscan::PushGateItem()
{
	//DEFINATION
	int err;
	struct GateSetPacket pkt;
	unsigned int * pUintPtr;
	double* pDoublePtr;

	int i;
	unsigned int uVal;

	//INIT
	err = 0;
	memset(&pkt, 0, sizeof(struct GateSetPacket));
	pUintPtr = 0;
	pDoublePtr = 0;
	i = 0;
	uVal = 0;

	//CHECK INPUTS
	//none.
	
	//INIT
	pUintPtr = (unsigned int*) this->pktWrPos;

	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	//head
	pkt.head.port = 0;
	pkt.head.id = DAQ_ITEM_ID_I_GATE; 
    pkt.head.bin = 0; 
	pkt.head.size = this->gateItemSize; 

	memcpy(pkt.start, "__start_", 8);
	//pkt.start[0] = (unsigned int)0x6774;
	//pkt.start[1] = (unsigned int )0x0041;

	//tag
	pkt.tag.stampMode = 1;
	pkt.tag.stampPos[0] = this->measurePos; 
    pkt.tag.stampPos[1] = 0; 
	pkt.tag.stampPos[2] = 0; 

	pkt.tag.stampInc[0] = 1; 
    pkt.tag.stampInc[1] = 0; 
	pkt.tag.stampInc[2] = 0; 

	pkt.tag.cellNum = this->ascanItemNum; 

	//copy
	memcpy((void*)pUintPtr, &pkt, sizeof(struct GateSetPacket));

	//align to pkt.d
	pUintPtr += sizeof(struct GateSetPacket)/sizeof(unsigned int) - 3;

	//gate data
	pkt.d = 0; 
	pDoublePtr = (double*)pUintPtr;

	//pkt.wave
    err = DrawMeasureData(pDoublePtr); //wave
	if(err != 0)
	{
		err = -3;
		ErrPrintf("draw measurement data err");
		return err;
	}
	//memset((void*)pDoublePtr, 0, pkt.tag.cellNum * sizeof(double));
    
	//align to stop
	pUintPtr += pkt.tag.cellNum * sizeof(double)/sizeof(unsigned int);

	memcpy(pkt.stop, "__stop__", 8);
	//pkt.stop[0] = (unsigned int)0x6768;
	//pkt.stop[1] = (unsigned int )0x0041;

	memcpy((void*)pUintPtr, (void*)pkt.stop, 8*sizeof(char));	
	pUintPtr += 2;

	//check size
	uVal = (unsigned int)((char*)pUintPtr - this->pktWrPos);
	if(uVal != this->gateItemSize)
	{
		ErrPrintf("gate push in size not correct");
	}

	//update write pos
	this->pktWrPos += this->gateItemSize;

	//update measurement pos
	this->measurePos += this->ascanItemNum;

	if(this->measurePos > 1024)
	{
		this->measurePos = 0;
	}

	return err;

} //end of PushGateItem(... 

/*************************************************
Function: SimulateAscan::Push2GateItem()

Description: push double gate to pPktFile

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )

Implicit Input:		
		this->gate2ItemSize
		this->pktWrPos
		this->gate2CellNum
Implicit Output:
		this->pktWrPos

Return: 
      if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int  SimulateAscan::Push2GateItem()
{
	//DEFINATION
	int err;
	struct Gate2SetPacket pkt;
	unsigned int * pUintPtr;
	double* pDoublePtr;

	int i;
	unsigned int uVal;

	//INIT
	err = 0;
	memset(&pkt, 0, sizeof(struct Gate2SetPacket));
	pUintPtr = 0;
	pDoublePtr = 0;
	i = 0;
	uVal = 0;

	//CHECK INPUTS
	//none.
	
	//INIT
	pUintPtr = (unsigned int*) this->pktWrPos; 

	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	//head
	pkt.head.port = 0;
	pkt.head.id = DAQ_ITEM_ID_BA_2GATE; 
	if(this->isMax)
		pkt.head.bin = 1; 
	else
		pkt.head.bin = 2; 

	pkt.head.size = this->gate2ItemSize; 

	memcpy(pkt.start, "__start_", 8);
	//pkt.start[0] = (unsigned int)0x6774;
	//pkt.start[1] = (unsigned int )0x0041;

	//tag
	pkt.tag.stampMode = 1;
	pkt.tag.stampPos[0] = this->doubleGatesPos; 
    pkt.tag.stampPos[1] = 0; 
	pkt.tag.stampPos[2] = 0; 

	pkt.tag.stampInc[0] = 1; 
    pkt.tag.stampInc[1] = 0; 
	pkt.tag.stampInc[2] = 0; 

	pkt.tag.cellNum = this->gate2CellNum; 

	//copy
	memcpy((void*)pUintPtr, &pkt, sizeof(struct Gate2SetPacket));

	//align to pkt.d
	pUintPtr += sizeof(struct Gate2SetPacket)/sizeof(unsigned int) - 3;

	//gate data
	pkt.d = 0; 
	pDoublePtr = (double*)pUintPtr;
	err = DrawDoubleGatesData(pDoublePtr); //wave
	if(err != 0)
	{
		err = -3;
		ErrPrintf("draw measurement data err");
		return err;
	}
	//memset((void*)pDoublePtr, 0, pkt.tag.cellNum * sizeof(double));
    
	//align to stop
	pUintPtr += pkt.tag.cellNum * sizeof(double)/sizeof(unsigned int);

	memcpy(pkt.stop, "__stop__", 8);
	//pkt.stop[0] = (unsigned int)0x6768;
	//pkt.stop[1] = (unsigned int )0x0041;

	memcpy((void*)pUintPtr, (void*)pkt.stop, 8*sizeof(char));	
	
	pUintPtr += 2;

	//check size
	uVal = (unsigned int)((char*)pUintPtr - this->pktWrPos);
	if(uVal != this->gate2ItemSize)
	{
		ErrPrintf("double gate push in size not correct");
	}
	//update write pos
	this->pktWrPos += this->gate2ItemSize;

	this->doubleGatesPos += this->gate2CellNum;

	if(this->doubleGatesPos > 1024)
	{
		this->doubleGatesPos = 0;
	}

	this->isMax = !this->isMax;

	return err;

} //end of Push2GateItem(... 

/*************************************************
Function: int SimulateAscan::Init(PktInfo info)

Description: push double gate to pPktFile

Calls: 
       // calls Function list                      source
	  
Called By: 
       // Called by fucntion list                 source
	   
Table Accessed: none (no database table)

Table Updated:  none (no database table )
Expict Input:
          info: PktInfo struct instance

Implicit Input:	
Implicit Output:
		none

Return: 
      if sucsses,     0
		            -1: input para err
					-2: alloc err
					-3: inner function err
					pls chk see ErrLog... file
Others: 
    // none.
*************************************************/
int SimulateAscan::Init(PktInfo info)
{
	//DEFINATION
	int err;
	
	//INIT
	err = 0;
	
	//CHECK INPUTS
	//none.
	
	//INIT
	
	//========================================================== 	
	//MAIN PROCESSING
    //==========================================================
	SetCellNum(info.ascanCellNum, info.statusCellNum,info.alarmCellNum,info.gateCellNum, info.gate2CellNum);

	SetItemNum(info.ascanItemNum, info.statusItemNum,info.alarmItemNum,info.gateItemNum, info.gate2ItemNum);
	
	err = Init(info.fName, info.lineNum);
	if(err != 0)
	{
		ErrPrintf("call Init() func err");
	}
	return err;

}//end of Init(...