#include "NMC.h"
#include "stdafx.h"
#include "NmcHardware.h"


static NmcHardareRes hardware;

int HardwareOpen()
{
	int err = 0;
	err = hardware.Open();
	return err;
}

int HardwareClose()
{
	int err = 0;
	err = hardware.Close();
	return err;
}

bool HardwareIsOpen()
{
	bool flag = false;
	flag = hardware.IsOpen();
	return flag;
}

bool HardwareGoZero()
{
	bool flag = false;
	flag = hardware.GoZero();
	return flag;
}

bool HardwareGo(int axis, double range, double speed)
{
	bool flag = false;
	flag = hardware.Go(axis, range, speed);
	return flag;
}

bool HardwareBGo(int axis, double range, double speed)
{
	bool flag = false;
	flag = hardware.BGo(axis, range, speed);
	return flag;
}

bool HardwareBGoPlanar(int axis1, double range1, int axis2, double range2, double speed, double mmStep)
{
	bool flag = false;
	flag = hardware.BGoPlanar(axis1, range1, axis2, range2, speed, mmStep);
	return flag;
}

bool HardwareGoThree(int axis1, double range1, double speed1, int axis2, double range2, double speed2, int axis3, double range3, double speed3)
{
	bool flag = false;
	//flag = hardware.Go(axis1, range1, speed1, axis2, range2, speed2, axis3, range3, speed3);
	return flag;
}

bool HardwareGoPlanar(int axis1, double range1, int axis2, double range2, double speed, double mmStep)
{
	bool flag = false;
	flag = hardware.GoPlanar(axis1, range1, axis2, range2, speed, mmStep);
	return flag;
}

int HardwareGetCurPos(int axis, double* pos)
{
	int err = 0;
	double val = 0;
	err = hardware.GetCurPos(axis, &val);
	*pos = val;
	return err;
}

int HardwareCurVeloc(int axis, double* v)
{
	int err = 0;
	double val = 0;
	err = hardware.GetCurVeloc(axis, &val);
	*v = val;
	return err;
}

bool HardwareIsComplete()
{
	bool flag = false;
	flag = hardware.IsComplete();
	return flag;
}

bool HardwareWaitComplete(int ms)
{
	bool flag = false;
	flag = hardware.WaitComplete(ms);
	return flag;
}

void HardwareEHalt()
{
	hardware.EHalt();
}

void HardwareEKill()
{
	hardware.EKill();
}

void HardwareEStop()
{
	hardware.EStop();
}

void HardwareSigStart2Hardware()
{
	hardware.SigStart2Hardware();
}

void HardwareSigStop2Hardware()
{
	hardware.SigStop2Hardware();
}