#pragma once

//pls attension, this must be sync to DAQ
#ifndef DEFAULT_DAQ_BUF_SIZE
#define DEFAULT_DAQ_BUF_SIZE (1024*1024/4 + 1024*8)
#endif

#ifndef DAQ_BLOCK
#define DAQ_BLOCK      ((unsigned int) 1)
#define DAQ_UNBLOCK    ((unsigned int) 0)
#endif

#ifndef DAQ_START_FLAG_UINT
#define DAQ_START_FLAG_LOW  ((unsigned int) 0x6774)
#define DAQ_START_FLAG_HIGH ((unsigned int) 0x0041) 
#define DAQ_START_FLAG      "__start_"
#define DAQ_STOP_FLAG_LOW  ((unsigned int) 0x6768)
#define DAQ_STOP_FLAG_HIGH ((unsigned int) 0x0041)
#define DAQ_STOP_FLAG       "__stop__"
#endif

#ifndef SIM_ASCAN_LENGTH
#define SIM_ASCAN_LENGTH ((unsigned int)1024)
#endif

#ifndef SIM_MEASURE_POS
#define SIM_MEASURE_POS ((unsigned int)25)
#endif

#ifndef SIM_DOUBLE_GATES_NUM
#define SIM_DOUBLE_GATES_NUM ((unsigned int)12)
#endif

#ifndef MAX_THICKNESS
#define MAX_THICKNESS ((unsigned int)5)
#endif

#ifndef MIN_THICKNESS
#define MIN_THICKNESS ((unsigned int)3)
#endif



#ifndef DAQ_ITEM_ID_NONE

//id and bin  list 
#define DAQ_ITEM_ID_NONE            ((unsigned int) 0x0)
//item bin fixed 0x0

#define DAQ_ITEM_ID_I_GATE          ((unsigned int) 0x1)
	//its item bin: Ref to ENUM_DAQ_GATE_MEAS_MODE as defined in <daqattr.h> 

#define DAQ_ITEM_ID_A_GATE          ((unsigned int)0x1<<1)
	//item_bin like above

#define DAQ_ITEM_ID_B_GATE			((unsigned int)0x1<<2)
	//item_bin like above

#define DAQ_ITEM_ID_C_GATE  		((unsigned int)0x1<<3)
	//item_bin like above

#define DAQ_ITEM_ID_BA_2GATE 		((unsigned int)0x1<<4)
	//its item bin:  Ref to ENUM_DAQ_2GATE_MEAS_MODE as defined in <daqattr.h>

#define DAQ_ITEM_ID_AI_2GATE  		((unsigned int)0x1<<5)
	//item_bin like above  

#define DAQ_ITEM_ID_BI_2GATE  		((unsigned int)0x1<<6)
	//item_bin like above  

#define DAQ_ITEM_ID_CI_2GATE  		((unsigned int)0x1<<7)
	//item_bin like above  

#define DAQ_ITEM_ID_ALRAM_DISP      ((unsigned int)0x1<<8)
	//item bin: Ref to DAQ_ATTR_MEAS_ALARM_DISP as defined in <daqattr.h>

#define DAQ_ITEM_ID_ASCAN_VIDEO     ((unsigned int)0x1<<9)
	//item bin: fixed as 0x0

#define DAQ_ITEM_ID_STATUS          ((unsigned int)0x1<<10)
	//item bin: fixed as 0x0

#define DAQ_ITEM_ID_EVENT			 ((unsigned int)0x1<<11)
//item bin: 0x0, none; 0x1 StartEvent; 0x2 stopEvent, etc	

#define DAQ_ITEM_ID_COUPLE_SUPERVISORY ((unsigned int)0x1<<12)

#endif