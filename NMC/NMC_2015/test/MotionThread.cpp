#include "stdafx.h"
#include "MotionThread.h"
#include "BlockingMotionQueue.h"


void MotionThread_Func(bool x, NmcHardareRes hardware, MotionQueue<Motion> Queue)
{
	Motion* item;
	int axis;
	double range;
	double speed;
	bool err;
	double pos;
	bool isQuit;

	isQuit = x;
	//item = new Motion(0, 0, 0);
	while (!isQuit)
	{
		while (Queue.Dequeue(*item))
		{
			axis = item->getAxis();
			range = item->getRange();
			speed = item->getSpeed();

			while ((err = hardware.Go(axis, range, speed)))
			{
				hardware.GetCurPos(1, &pos);
				printf("Position %f",pos);
			}
		}
	}
}

MotionThread::MotionThread()
{
	this->isQuit = false;
}

MotionThread::~MotionThread()
{
	this->isQuit = true;;
}

void MotionThread::start(bool x)
{
	std::thread thread(MotionThread_Func,x,hardware,Queue);
	thread.join();
}

int main()
{
	bool err;
	MotionThread thread;
	NmcHardareRes hardware;
	//MotionQueue<Motion*> Queue;

	bool isQuit = thread.isQuit;
	err = hardware.Open();

	
	if (err != true)
	{
		printf("Can not open, pls chk!");
	}

	//err = hardware.GoZero();
	if (err != true)
	{
		printf("Can not go zero, pls chk!");
	}
	int n = 10;
	while (n--)
	{
		hardware.BGo(thread.Queue,1, 5, 5);
	}

	thread.start(isQuit);



}