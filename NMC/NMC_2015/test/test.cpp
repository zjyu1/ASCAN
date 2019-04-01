// test.cpp : Defines the entry point for the console application.
//

// BoardTestCplusplus.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "NmcHardware.h"
#include <Windows.h>




int _tmain(int argc, _TCHAR* argv[])
{
	bool err;
	int axis;
	int status;

	double pos = 0;
	double posTemp = 0;
	double v = 0;
	double vTemp = 0;
	status = 0;
	axis = 0;

	NmcHardareRes hardware;

	err = hardware.Open();
	if (err != true)
	{
		printf("Can not open, pls chk!");
		return -1;
	}
	/*
	for(int i=1;i<4;i++)
	{
	axis = i;
	err = hardware.GetCurPos(axis,&pos);
	if(err != true)
	{
	printf("get pos error, pls chk!");
	printf("axis= %d\n",axis);
	return -1;
	}

	printf("axis %d :: pos = %f mm\n", axis, pos);


	}
	*/
	//95,47,210

	//err = hardware.GoZero();

	//err |= hardware.Go(SPL_X_AXIS, 95,10);

	//err |= hardware.Go(SPL_Y_AXIS,47,10);

	//err |= hardware.Go(SPL_Z_AXIS,210,10);	



	err = hardware.GoZero();
	if (err != true)
	{
		printf("Can not go zero, pls chk!");
		return -1;
	}

	/*
	hardware.DGo(1, 30, 10);
	hardware.DGo(2, 20, 10);
	err = hardware.DGo(3, 100, 10);
	hardware.DGo(1, -30, 10);
	hardware.DGo(2, -20, 10);
	*/


	//hardware.DGo(3, 10,10);
	/*
	err = hardware.SigStart2Hardware();   //signal start sigs to testing board through RTSI line
	if(err != true)
	{
	printf("start err, pls chk");
	return -1;
	}
	/*
	for(int i=0;i<6;i++)
	{
	//bool Go(int axis, double range, double speed);  //one axis go
	//	//1 ->X axis;2->Y axis ;3->Z axis
	for(int j=1;j<2;j++)
	{
	axis = j;



	//go

	err = hardware.DGo(axis, 32, 10);
	if(err != true)
	{
	printf("go axis error, pls chk!");
	printf("axis= %d\n",axis);
	return -1;
	}


	//wait
	err = hardware.WaitComplete(0);
	if(err != true)
	{
	printf("wait cmpt error, pls chk!");
	printf("axis= %d\n",axis);
	return -1;
	}

	//check pos
	err = hardware.GetCurPos(axis,&pos);
	if(err != true)
	{
	printf("get pos error, pls chk!");
	printf("axis= %d\n",axis);
	return -1;
	}

	printf("axis %d :: pos = %f mm\n", axis, pos);


	//go
	//err = hardware.DGo(axis, -32, 10);
	if(err != true)
	{
	printf("go axis error, pls chk!");
	printf("axis= %d\n",axis);
	return -1;
	}

	//wait
	err = hardware.WaitComplete(0);
	if(err != true)
	{
	printf("wait cmpt error, pls chk!");
	printf("axis= %d\n",axis);
	return -1;
	}

	//check pos
	err = hardware.GetCurPos(axis,&pos);
	if(err != true)
	{
	printf("go back get pos error, pls chk!");
	printf("axis= %d\n",axis);
	return -1;
	}

	printf("goback, axis %d :: pos = %f mm\n", axis, pos);




	Sleep(1000);

	}
	}

	err = hardware.SigStop2Hardware();
	if(err != true)
	{
	printf("stop err, pls chk");
	printf("axis= %d\n",axis);
	return -1;
	}
	*/


	//hardware.Go(3, 210, 10);
	//err = hardware.GetCurPos(axis,&pos);			
	//if(err != true)
	//{
	//	printf("get pos error, pls chk!");
	//	printf("axis= %d\n",axis);
	//	return -1;
	//}

	//printf("axis %d :: pos = %f mm\n", axis, pos);
	hardware.Go(SPL_Z_AXIS, 185, 10);

	hardware.SigStart2Hardware();

	//hardware.Go(1, 100, 10);

	//testing planar motion
	err = hardware.GoPlanar(SPL_X_AXIS, 105, SPL_Y_AXIS, 105, 50, 1);
	//for(int i=0;i<6;i++)
	//{

	//	err = hardware.Go(SPL_X_AXIS, 32, 10); 
	//		if(err != true)
	//		{
	//			printf("go axis error, pls chk!");
	//			printf("axis= %d\n",axis);
	//			return -1;
	//		}
	//}

	//for(int i=0;i<6;i++)
	//{
	//	err = hardware.Go(SPL_X_AXIS, -32, 10); 
	//		if(err != true)
	//		{
	//			printf("go axis error, pls chk!");
	//			printf("axis= %d\n",axis);
	//			return -1;
	//		}
	//}




	if (err != true)
	{
		printf("go planar error, pls chk!");
		return -1;
	}
	hardware.SigStop2Hardware();
	return 0;
}






