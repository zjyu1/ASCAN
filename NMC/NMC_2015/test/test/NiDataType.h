
#ifndef NMC_NI_DATA_TYPE_CPLUSPLUS
#define NMC_NI_DATA_TYPE_CPLUSPLUS

using namespace std;

//SPL  means scan platform 

//Motor
#define   SPL_MOTOR_TYPE	"RKS569BC-3"
#define   SPL_MOTOR_MANU   "OreintorMortor, Jpan"
#define   SPL_MOTOR_MAX_HZ 200000 //200KHz
//driver
#define  SPL_MOTOR_DRIVER_STEP	4
#define SPL_MOTOR_STEP_ANGLE		(double)0.144 //degree

//encoder
#define SPL_ENCODER_RESLUTION		2500   //2500 line encoder

//axis
#define SPL_X_AXIS_ROTOR_PITCH      5 //mm
#define SPL_Y_AXIS_ROTOR_PITCH      5
#define SPL_Z_AXIS_ROTOR_PITCH      3
#define SPL_R_AXIS_ROTOR_PITCH      5


#define  SPL_X_AXIS   1
#define  SPL_Y_AXIS   2
#define  SPL_Z_AXIS   3
#define  SPL_R_AXIS   4

#define  SPL_FAULT_VELOCITY    -1.0
#define  SPL_FAULT_POS         -1.0


//motor control type
#define  SPL_OPEN_LOOP     0
#define  SPL_CLOSED_LOOP   1
#define  SPL_PCOMMAND_LOOP 2

//Input vectors
#define SPL_DIRECT    0xFF
#define SPL_VARIABLE  0x01 //0x01 to 0x78
#define SPL_INDIRECT  0x81 //0x81 to 0xF8


//Error defination
#define  SPL_ERR	-1
#define  SPL_OK		0
#define  SPL_NOK	-1

//
#define  SPL_FALSE  0
#define  SPL_TRUE   1

//time
#define SPL_1_SECOND  1000

//CSR bitmap
#define SPL_CSR_ERR(x) (x&0xB0) 

//AXis space for three dimensional
#define SPL_3AXIS_VECTOR_SPACE  (1 << SPL_X_AXIS) | (1 << SPL_Y_AXIS) | (1 << SPL_Z_AXIS)  

//Default speed
#define SPL_DFT_VELOC  10.0

//Default ACC 
#define SPL_DFT_ACC     10000    //10000 steps/s
#define SPL_RUNNING_ACC 100000   

//platform motion range
#define SPL_X_MOTION_RANGE	400 //mm
#define SPL_Y_MOTION_RANGE	400 //mm
#define SPL_Z_MOTION_RANGE  270 //mm
#define SPL_R_MOTION_RANGE  0

#define SPL_DFT_OUTPUT_MODLUS 1.0 //mm

#define SPL_DFT_WAIT_TIME  1000   //ms

#define SPL_DIR_POS			1
#define SPL_DIR_NEG         0

#define SPL_RELATIVE_X_OFFSET 30  //mm
#define SPL_RELATIVE_Y_OFFSET 30  //mm
#define SPL_RELATIVE_Z_OFFSET 50  //mm
#define SPL_RELATIVE_R_OFFSET 25  //rsv,mm
#define SPL_RANGE_RSV 5


#define SPL_LOC_TOLERANCE     0.01  // 10um

#endif














