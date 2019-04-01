
#ifndef USCOMM_BOARD_MANAGER_CPLUSPLUS
#define USCOMM_BOARD_MANAGER_CPLUSPLUS

#include <string>
#include <fstream>
#include "BoardResDesc_cplusplus.h"
#include "daqAPI.h"
#include "daqInterface.h"
#include "Simulate_cplusplus.h"

using namespace std;

#ifndef USCOMM_ERR_PRINTF
#define USCOMM_ERR_PRINTF
#define ErrPrintf(str_err_info) LogPrintf(__LINE__, __FUNCTION__, #str_err_info)
#endif 


class BoardManager
{
private:
	unsigned int brdsNum;

	BoardRes*    brds;

	bool         isOpen;

	char*        daqBuf;

	DevHandleList* pDevList;

#ifdef USCOMM_SIM
	SimulateAscan*	sim;
#endif

	
private: //LOG
	//log file name
	string logFileName;

	//log out file output stream
	ofstream  errLog;

//CONSTRUCT
public:
	BoardManager();

	//DESCONSTRUCT
	~BoardManager();


//EXTERNAL FUNCTION INTERFACE
public: 		
	
	/** open interface.*/
	int Open(string fname);

	/**get version.*/
	int GetVersion(unsigned int bid, IdTarget* pVal);

	/** close interface.*/
	int Close();

	unsigned int GetBoardsNum();

	int Get(unsigned int bid, unsigned int chn, unsigned int attrType, unsigned int* pVal);

	int Get(unsigned int bid, unsigned int chn, unsigned int attrType, float* pVal);

	int Get(unsigned int bid, unsigned int chn, unsigned int attrType, double* pVal);

	int Get(unsigned int bid, unsigned int chn, unsigned int attrType, DAC_Paras*  pDac);

	int Set(unsigned int bid, unsigned int chn, unsigned int attrType, unsigned int val);

	int Set(unsigned int bid, unsigned int chn, unsigned int attrType, float val);

	int Set(unsigned int bid, unsigned int chn, unsigned int attrType, double val);

	int Set(unsigned int bid, unsigned int chn, unsigned int attrType, DAC_Paras dac);

	int Set(unsigned int bid, unsigned int chn, unsigned int attrType, BeamFile beam);

	int LoadBMFile(unsigned int bid, char* ramFile, unsigned int* fileSize);

	int SaveBMFile(unsigned int bid, string fName); 

	int Get(unsigned int bid, unsigned int attrType, AttrRangeuInt* pRange);

	int Get(unsigned int bid, unsigned int attrType, AttrRangeDouble* pRange);

	int APILoadApp(unsigned int bid, string fName);

	int Run(unsigned int bid);

	int Stop(unsigned int bid);

	int Read(unsigned int bid, UniSetPacket* pPacket, unsigned int boolBlock);

	int StreamStart(unsigned int index, pStreamEnable pEnable);

	int StreamStop(unsigned int index, pStreamEnable pEnable);

private:
	BoardRes* GetRes(unsigned int bid);
	SimulateAscan* GetSim(unsigned int bid);
	unsigned int GetBoardID(unsigned int bid);
	char* GetDaqBuf(unsigned int bid);

private:
//ERR PRINTF
	//log printf to logFileName according stationary format
    void LogPrintf(long line, char* strfunc,char* strErr);
	
}; //end of class BoardManager

#endif