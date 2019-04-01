// stdafx.cpp : source file that includes just the standard includes
// test.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "NmcHardware.h"
#include "BlockingMotionQueue.h"

// TODO: reference any additional headers you need in STDAFX.H
// and not in this file
// BoardTestCplusplus.cpp : 定义控制台应用程序的入口点。
//

void main()
{
	bool err;
	double xpos;
	double ypos;

	NmcHardareRes hardware;

	err = hardware.Open();

	if (err != true)
	{
		printf("Can not open, pls chk!");

	}

	err = hardware.GoZero();
	if (err != true)
	{
		printf("Can not go zero, pls chk!");

	}
	/*for (int i = 0; i < 30; i++)
	{
		err = hardware.BGo(1,2,5);
		if (err != true)
		{
			printf("can not go, pls chk!");
		}
	}*/
	hardware.BGoPlanar(1,20,2,10,20,1);
	while (1)
	{
		hardware.GetCurPos(1, &xpos);
		hardware.GetCurPos(2, &ypos);

		printf("Position %f", xpos);

		printf("Position %f \n", ypos);

		Sleep(1000);

	}
}


