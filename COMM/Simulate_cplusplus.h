
#ifndef SIMULATE_CPLUSPLUS
#define SIMULATE_CPLUSPLUS

#include <string>
#include <fstream>

using namespace std;

#ifndef USCOMM_ERR_PRINTF
#define USCOMM_ERR_PRINTF
#define ErrPrintf(str_err_info) LogPrintf(__LINE__, __FUNCTION__, #str_err_info)
#endif 

struct PktInfo
{
	string fName;
	unsigned int lineNum;

	unsigned int ascanCellNum;
	unsigned int statusCellNum;
	unsigned int alarmCellNum;
	unsigned int gateCellNum;
	unsigned int gate2CellNum;

	unsigned int ascanItemNum;
	unsigned int statusItemNum;
	unsigned int alarmItemNum;
	unsigned int gateItemNum;
	unsigned int gate2ItemNum;	
};

class SimulateAscan
{
private: //RAM FILE
	//Ascan Ram file
	static double*  pRamFile;	

	//frame position for draw one ascan frame
	unsigned int framePos;  

	//flag for is load txt file
	bool isLoad;

	//txt file name for ascan source data 
	string    fileName;   

	//in txt file, how much point in one frame
	unsigned int linePointNum;

	//in txt file, totally how much points include
	static unsigned int ascanPointNum; 

	//total frame number
	unsigned int totalFrameNum;

	//current measurement position 
	unsigned int measurePos;

	//current doubleGatesPos
	unsigned int doubleGatesPos;

	bool isMax;
	
private: //PACKET GENERATE		
//TOTAL PKT SIZE
	unsigned int totalPktSize;
	char*        pPktFile;

//SUB ITEM CELL NUMBER
	//ascan item cell number
	unsigned int ascanCellNum;

	//status item cell number
	unsigned int statusCellNum;
	//alarm item cell number

	unsigned int alarmCellNum;

	//gate item cell number
	unsigned int gateCellNum;

	//double gate item cell number
	unsigned int gate2CellNum;

//SUB ITEM NUMBER
	//ascan item number
	unsigned int ascanItemNum;

	//status item number
	unsigned int statusItemNum;
	//alarm item number

	unsigned int alarmItemNum;

	//gate item number
	unsigned int gateItemNum;

	//double gate item number
	unsigned int gate2ItemNum;

//TATAL ITEM NUMBER
	unsigned int totalItemNum;


//SUB PKT SIZE
	//ascan item sub pkt size(bytes)
	unsigned int ascanItemSize;	

	//status item sub pkt size(bytes)
	unsigned int statusItemSize;	

	//alram item sub pkt size(bytes)
	unsigned int alarmItemSize;	

	//gate item sub pkt size(bytes)
	unsigned int gateItemSize;	

	//doubel gate item pkt size(bytes)
	unsigned int gate2ItemSize;

// PKT WRITE POS TRACKING 
	char*    pktWrPos;

	
private: //LOG
	//log file name
	string logFileName;

	//log out file output stream
	ofstream  errLog;

//CONSTRUCT
public:
	SimulateAscan();

	//DESCONSTRUCT
	~SimulateAscan();


//EXTERNAL FUNCTION INTERFACE
public: 		
	
	int Init(PktInfo info);

	//genrate one pkt for USSYSTEM read
	int GenBoardPkt(void* pBuf, unsigned int* bufSize);

//INNER FUNCTION INTERFACE
private:
	//load txt to ram file
	int LoadFile();

//INIT
	void SetCellNum(unsigned int ascan, unsigned int status,unsigned int alarm, unsigned int gate, unsigned int gate2);
	
	void SetItemNum(unsigned int ascan, unsigned int status,unsigned int alarm, unsigned int gate, unsigned int gate2);
	
	int Init(string fname, unsigned int linePtNum);

//PKT GENERATE FUNCTIONS
	//cal sub pkt size and pos according item cell number
	void CalItemSize();

	//cal total pkt size based on item number, and item sub pkt size
	void CalTotalPktSize();

	//fetch one ascan item
	int PushAscanItem(); 

	//fetch one status item
	int PushStatusItem(); 

	//fetch one alaram item
	int PushAlarmItem(); 

	//fetch one gate item
	int PushGateItem();

	//fetch one 2gate item
	int Push2GateItem(); 
	
	
	//scan 1024 or 512 data for start to delay gate in datas peak amp and tof
	//int SimScanFrame(double* pBuf, double delay, double range, double* amp, double* tof);

//RAM FILE FUNCTIONS
	// inner read from txt and get num's frame asacan
	int ReadFromFile();	

	//read out ascan frames from txt file to  memory
	int NewRamFile();
	
	// draw one frame from ram file
	int DrawOneFrame(double* pFrame);

	//draw measurement data from ram file
	int DrawMeasureData(double* pFrame);

	//draw double gates data from ram file
	int DrawDoubleGatesData(double* pFrame);

//ASCAN BEHEVOIR FUNCTION
	//scan 1024 or 512 data for start to delay gate in datas peak amp and tof
	//int SimScanFrame(double* pBuf, double delay, double range, double* amp, double* tof);

//ERR PRINTF
	//log printf to logFileName according stationary format
    void LogPrintf(long line, char* strfunc,char* strErr);
	
}; //end of SimulateAscan




#endif




