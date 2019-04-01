// BoardTestCplusplus.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"

#include "Simulate_cplusplus.h"

#include "BoardResDesc_cplusplus.h"

#include "ItemPacket.h"

#include "PDAQ.h"



int _tmain(int argc, _TCHAR* argv[])
{
	void*			pBuf = 0;
	unsigned int	size = 1024*1024;
	BoardRes        brd;

	struct UniSetPacket     pkt;
	SimulateAscan	sim;
	PktInfo			info;
	int err			= 0;


	//INIT info
	info.fName = "../../HIC_20150814.txt";
	info.lineNum = 150;

	info.ascanCellNum = 1;
	info.statusCellNum = 1;
	info.alarmCellNum = 100;
	info.gateCellNum = 234;
	info.gate2CellNum = 567;

	info.ascanItemNum = 12;
	info.statusItemNum = 1;
	info.alarmItemNum = 1;
	info.gateItemNum = 1;
	info.gate2ItemNum = 1;
	
	
	err = sim.Init(info);
	if(err != 0)
	{
		printf("Init err");
		return -2;
	}		
	

	pBuf = new char[size];
	if(pBuf == 0)
	{
		err = -2;
		printf("Alloc pBuf err");
		return err;
	}

	err = sim.GenBoardPkt((void*)pBuf, &size);
	if(err != 0)
	{
		printf("Gen err");
		return -2;
	}	


	err = brd.Init(1, "test board");
	if(err != 0)
	{
		printf("BoardRes Init err");
		return -2;
	}

	err = brd.PushUnUniPktIn(pBuf, size);
	if(err != 0)
	{
		printf("BoardRes Init err");
		return -2;
	}

	while(1)
	{
		if(brd.Empty() != true)
		{
			err = brd.PopOneUniPktOut(&pkt);
			if(err != 0)
			{
				err = -3;
				printf("pop out err");
				return err;
			}

		}
	}
	

	if(pBuf != NULL)
	{
		delete [] pBuf;
		pBuf = NULL;
	}
	
	return 0;
}

