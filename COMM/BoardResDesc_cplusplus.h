
#ifndef USCOMM_BOARD_RES_DESC_CPLUSPLUS
#define USCOMM_BOARD_RES_DESC_CPLUSPLUS

using namespace std;

#include "ItemPacket.h"
#include <string>
#include <fstream>

//#ifndef USCOMM_SIM
//#define USCOMM_SIM
//#endif

#ifndef USCOMM_DEFAULT_SET_NUMBER
#define USCOMM_DEFAULT_SET_NUMBER 32
#endif

#ifndef USCOMM_DEFAULT_ASCAN_UINT_OFFSET  //AscanVideo in ustmdi delay's uint offset
#define USCOMM_DEFAULT_ASCAN_UINT_OFFSET 15
#endif

#ifndef USCOMM_DEFAULT_HEADER_OFFSET      //UniSetPacket before pUni->ud 's uint number size
#define USCOMM_DEFAULT_HEADER_OFFSET 13
#endif

#ifndef USCOMM_ERR_PRINTF
#define USCOMM_ERR_PRINTF
#define ErrPrintf(str_err_info) LogPrintf(__LINE__, __FUNCTION__, #str_err_info)
#endif 



class BoardRes
{
private:
	//index
	unsigned int boardId;

	string boardName;

private:
	//pBuf prepared for daqReadTSQ()
	void* pBuf;
	unsigned int bufSize;

	//filled data UniSetPacket num array
	unsigned int fillNum;

	//remain data UniSetPacket num in array
	unsigned int freeNum;

	//const = 32
	unsigned int totalNum; 

	//rd ptr
	unsigned int rdPos;

	//wr ptr
	unsigned int wrPos; 

	//
	struct UniSetPacket* pPkts;
	unsigned int pktNums;

	bool   isOpen;

public:
	unsigned int dftPktCapcity; //number
	unsigned int dftBufCapcity; //unit bytes

private: //LOG
	//log file name
	string logFileName;

	//log out file output stream
	ofstream  errLog;

public:
	BoardRes();
	~BoardRes();
public:
	int Init(unsigned int brdId, string brdName);
	int PopOneUniPktOut(struct UniSetPacket* pPkt);	
	int PushUnUniPktIn(void* pBuffer, unsigned int size);
	bool Empty();
	unsigned int GetBrdID();
	string GetBrdName();

private:
	//for init to zero 
	int initUniPkt();

	//chk header is valid?
	int ChkHeaderId(unsigned int id);

	//parse pBuf data which readed from daq to pUni, num is returned how much parsed out
	int parsePacket();
//ERR PRINTF
	//log printf to logFileName according stationary format
    void LogPrintf(long line, char* strfunc,char* strErr);
};

/*class BrdsResDesc
{
private:
	unsigned int boardNum;
	BoardRes* pBrds;
public:
	AllBrdResDescs();
	~AllBrdResDescs();

private: //LOG
	//log file name
	string logFileName;

	//log out file output stream
	ofstream  errLog;

public:
	int Init(unsigned int boardNum);
};*/

#endif














