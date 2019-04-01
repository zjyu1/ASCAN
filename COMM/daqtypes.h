/*
* Copyright (c) 2015,  ZJU, ME, 128, Ultrsonic Group
* All rights reserved.
* Project£º  DAQ_USAQ 
* FileName£ºdaqtypes.h
* File Desc£º
* Abstract£ºdefine all data types used in project.
*
* Current Version£º2.0.0
* Author£º         Wueryong
* Date£º           2015Äê6ÔÂ16ÈÕ
* Remarks£º 
*/


#ifndef		_DAQ_TYPES_H
#define		_DAQ_TYPES_H

#ifdef __cplusplus
    extern "C" {
#endif

//==============================================================================
// Include files
//==============================================================================  
//none.

//==============================================================================
// Constants
//============================================================================== 
#ifndef mvimaq_types
#define mvimaq_types

#ifndef _DAQ_uInt8_DEFINED_
    #define _DAQ_uInt8_DEFINED_
    typedef unsigned char       uInt8;
#endif



#ifndef _DAQ_uInt32_DEFINED_
    #define _DAQ_uInt32_DEFINED_
    typedef unsigned int       uInt32;
#endif


#ifndef _DAQ_Int8_DEFINED_
    #define _DAQ_Int8_DEFINED_
    typedef char                Int8;
#endif



#ifndef _DAQ_Int32_DEFINED_
    #define _DAQ_Int32_DEFINED_
    typedef  int                Int32;
#endif


#ifndef _DAQ_DOUBLE		
typedef    double   Double;      
#endif		

#ifndef _DAQ_FLOAT	
#define _DAQ_FLOAT
typedef    float   Float;      
#endif	


//POINTER
typedef char*           Ptr;  

//INTERFACE ID
#ifndef  INTERFACE_ID
#define    INTERFACE_ID  uInt32    
#endif


//SESSION ID
#ifndef  SESSION_ID
#define    SESSION_ID   uInt32    
#endif


//EVENT ID
#ifndef  EVENT_ID
#define        EVENT_ID		uInt32
#endif


//PLUSE ID
#ifndef  PULSE_ID
#define        PULSE_ID		uInt32
#endif


//BUFFER LIST ID(pointer)
#ifndef  BUFLIST_ID
#define        BUFLIST_ID   uInt32
#endif

#ifndef  BITSQ_ID          
#define   BITSQ_ID   uInt32
#endif


//DAQ ERROR
#ifndef  DAQ_ERR
#define        DAQ_ERR		 uInt32
#endif


//DAQ sync flag
#ifndef  DAQ_SYNC
#define        DAQ_SYNC		 uInt32
#endif


//GUI handle
#ifndef  GUIHNDL
#define        GUIHNDL		uInt32
#endif

#ifndef BIT
#define BIT0    0x1
#define BIT1    0x1<<1
#define BIT2    0x1<<2
#define BIT3    0x1<<3
#define BIT4    0x1<<4
#define BIT5    0x1<<5
#define BIT6    0x1<<6
#define BIT7    0x1<<7
#define BIT8    0x1<<8
#define BIT9    0x1<<9
#define BIT10   0x1<<10
#define BIT11   0x1<<11
#define BIT12   0x1<<12
#define BIT13   0x1<<13
#define BIT14   0x1<<14
#define BIT15   0x1<<15
#define BIT16   0x1<<16
#define BIT17   0x1<<17
#define BIT18   0x1<<18
#define BIT19   0x1<<19
#define BIT20   0x1<<20
#define BIT21   0x1<<21
#define BIT22   0x1<<22
#define BIT23   0x1<<23
#define BIT24   0x1<<24
#define BIT25   0x1<<25
#define BIT26   0x1<<26
#define BIT27   0x1<<27
#define BIT28   0x1<<28
#define BIT29   0x1<<29
#define BIT30   0x1<<30
#define BIT31   0x1<<31
#endif

//==============================================================================
// Types
//==============================================================================  
//none
		
//==============================================================================
// External variables
//============================================================================== 
//none
		
//==============================================================================
// Global functions  
//==============================================================================
//none	

#endif 

#ifdef __cplusplus
    }
#endif

#endif //end of _DAQ_TYPE_H
