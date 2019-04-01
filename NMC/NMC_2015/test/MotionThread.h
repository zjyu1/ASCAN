#pragma once
#include <thread>
#include <windows.h>
#include "BlockingMotionQueue.h"
#include "NmcHardware.h"


class MotionThread
{
public:
	bool isQuit;
	NmcHardareRes hardware;
	MotionQueue<Motion*> Queue;

public:
	MotionThread() 
	{
	};
	~MotionThread();

public:
	void start(bool x);
};
