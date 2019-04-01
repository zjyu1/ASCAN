
#ifndef _DAQERR_H
#define _DAQERR_H


//============================================================================
//  Error Codes
//============================================================================
#define _DAQ_ERR                                0xBFF60000
#define  DAQ_ERR_GOOD                            0                    // no error

//----------------------------------------------------------------------------
//  ¾¯¸æ
//----------------------------------------------------------------------------
#define  DAQ_WRN_BCAM                           (_DAQ_BASE + 0x0001)  // corrupt camera file detected
#define  DAQ_WRN_CONF                           (_DAQ_BASE + 0x0002)  // change requires reconfigure to take effect
#define  DAQ_WRN_ILCK                           (_DAQ_BASE + 0x0003)  // interface still locked
#define  DAQ_WRN_BLKG                           (_DAQ_BASE + 0x0004)  // STC: unstable blanking reference
#define  DAQ_WRN_BRST                           (_DAQ_BASE + 0x0005)  // STC: bad quality colorburst
#define  DAQ_WRN_OATTR                          (_DAQ_BASE + 0x0006)  // old attribute used
#define  DAQ_WRN_WLOR                           (_DAQ_BASE + 0x0007)  // white level out of range
#define  DAQ_WRN_IATTR                          (_DAQ_BASE + 0x0008)  // invalid attribute in current state
#define  DAQ_WRN_LATEST                         (_DAQ_BASE + 0x000A)

//----------------------------------------------------------------------------
//  ´íÎóÂë
//----------------------------------------------------------------------------
#define  DAQ_ERR_NOT_SUPPORTED                  	(_DAQ_ERR + 0x0001)  // function not implemented
#define  DAQ_ERR_OVRN                               (_DAQ_ERR + 0x0002)  // too many interfaces open
#define  DAQ_ERR_SYSTEM_MEMORY_FULL                 (_DAQ_ERR + 0x0003)  // could not allocate memory in user mode (calloc failed)
#define  DAQ_ERR_OSER                               (_DAQ_ERR + 0x0004)  // operating system error occurred
#define  DAQ_ERR_PAR1                               (_DAQ_ERR + 0x0005)  // Error with parameter 1
#define  DAQ_ERR_PAR2                               (_DAQ_ERR + 0x0006)  // Error with parameter 2
#define  DAQ_ERR_PAR3                               (_DAQ_ERR + 0x0007)  // Error with parameter 3
#define  DAQ_ERR_PAR4                               (_DAQ_ERR + 0x0008)  // Error with parameter 4
#define  DAQ_ERR_PAR5                               (_DAQ_ERR + 0x0009)  // Error with parameter 5
#define  DAQ_ERR_PAR6                               (_DAQ_ERR + 0x000A)  // Error with parameter 6
#define  DAQ_ERR_PAR7                               (_DAQ_ERR + 0x000B)  // Error with parameter 7
#define  DAQ_ERR_MXBF                               (_DAQ_ERR + 0x000C)  // too many buffers already allocated
#define  DAQ_ERR_DLLE                               (_DAQ_ERR + 0x000D)  // DLL internal error - bad logic state
#define  DAQ_ERR_BUFFER_SIZE_TOO_SMALL              (_DAQ_ERR + 0x000E)  // buffer size used is too small for minimum acquisition frame
#define  DAQ_ERR_MXBI                               (_DAQ_ERR + 0x000F)  // exhausted buffer id's
#define  DAQ_ERR_ELCK                               (_DAQ_ERR + 0x0010)  // not enough physical memory - the system could not allocate page locked memory
#define  DAQ_ERR_DISE                               (_DAQ_ERR + 0x0011)  // error releasing the image buffer
#define  DAQ_ERR_BBUF                               (_DAQ_ERR + 0x0012)  // bad buffer pointer in list
#define  DAQ_ERR_BUFFER_LIST_NOT_LOCKED             (_DAQ_ERR + 0x0013)  // buffer list is not locked
#define  DAQ_ERR_NSESSION                           (_DAQ_ERR + 0x0014)  // no session defined for this channel
#define  DAQ_ERR_BAD_INTERFACE_FILE                 (_DAQ_ERR + 0x0015)  // bad interface
#define  DAQ_ERR_BROW                               (_DAQ_ERR + 0x0016)  // rowbytes is less than region of interest
#define  DAQ_ERR_BAD_USER_RECT                      (_DAQ_ERR + 0x0017)  // bad region of interest; check width, heigh, rowpixels, and scaling
#define  DAQ_ERR_BAD_CAMERA_FILE                    (_DAQ_ERR + 0x0018)  // bad camera file (check syntax)
#define  DAQ_ERR_NVBL                               (_DAQ_ERR + 0x0019)  // not successful because of hardware limitations
#define  DAQ_ERR_NO_BUFFERS_CONFIGURED              (_DAQ_ERR + 0x001A)  // invalid action - no buffers configured for session
#define  DAQ_ERR_BAD_BUFFER_LIST_FINAL_COMMAND      (_DAQ_ERR + 0x001B)  // buffer list does not contain a valid final command
#define  DAQ_ERR_BAD_BUFFER_LIST_COMMAND            (_DAQ_ERR + 0x001C)  // buffer list does contains an invalid command
#define  DAQ_ERR_BAD_BUFFER_POINTER                 (_DAQ_ERR + 0x001D)  // a buffer list buffer is null
#define  DAQ_ERR_BOARD_NOT_RUNNING                  (_DAQ_ERR + 0x001E)  // no acquisition in progress
#define  DAQ_ERR_VIDEO_LOCK                         (_DAQ_ERR + 0x001F)  // can't get video lock
#define  DAQ_ERR_BDMA                               (_DAQ_ERR + 0x0020)  // bad DMA transfer
#define  DAQ_ERR_BOARD_RUNNING                      (_DAQ_ERR + 0x0021)  // can't perform request - acquisition in progress
#define  DAQ_ERR_TIMEOUT                            (_DAQ_ERR + 0x0022)  // wait timed out - acquisition not complete
#define  DAQ_ERR_NBUF                               (_DAQ_ERR + 0x0023)  // no buffers available - too early in acquisition
#define  DAQ_ERR_ZERO_BUFFER_SIZE                   (_DAQ_ERR + 0x0024)  // zero buffer size - no bytes filled
#define  DAQ_ERR_HLPR                               (_DAQ_ERR + 0x0025)  // bad parameter to low level - check attributes and high level arguments
#define  DAQ_ERR_BTRG                               (_DAQ_ERR + 0x0026)  // trigger loopback problem - can't drive trigger with action enabled
#define  DAQ_ERR_NO_INTERFACE_FOUND                 (_DAQ_ERR + 0x0027)  // no interface found
#define  DAQ_ERR_NDLL                               (_DAQ_ERR + 0x0028)  // unable to load DLL
#define  DAQ_ERR_NFNC                               (_DAQ_ERR + 0x0029)  // unable to find API function in DLL
#define  DAQ_ERR_NOSR                               (_DAQ_ERR + 0x002A)  // unable to allocate system resources (CVI only)
#define  DAQ_ERR_BTAC                               (_DAQ_ERR + 0x002B)  // no trigger action - acquisition will time out
#define  DAQ_ERR_FIFO_OVERFLOW                      (_DAQ_ERR + 0x002C)  // fifo overflow caused acquisition to halt
#define  DAQ_ERR_MEMORY_PAGE_LOCK_FAULT             (_DAQ_ERR + 0x002D)  // memory lock error - the system could not page lock the buffer(s)
#define  DAQ_ERR_ILCK                               (_DAQ_ERR + 0x002E)  // interface locked
#define  DAQ_ERR_NEPK                               (_DAQ_ERR + 0x002F)  // no external pixel clock
#define  DAQ_ERR_SCLM                               (_DAQ_ERR + 0x0030)  // field scaling mode not supported
#define  DAQ_ERR_SCC1                               (_DAQ_ERR + 0x0031)  // still color rgb, channel not set to 1
#define  DAQ_ERR_SMALLALLOC                         (_DAQ_ERR + 0x0032)  // Error during small buffer allocation
#define  DAQ_ERR_ALLOC                              (_DAQ_ERR + 0x0033)  // Error during large buffer allocation
#define  DAQ_ERR_BAD_CAMERA_TYPE                    (_DAQ_ERR + 0x0034)  // Bad camera type - (Not a NTSC or PAL)
#define  DAQ_ERR_BADPIXTYPE                         (_DAQ_ERR + 0x0035)  // Camera not supported (not 8 bits)
#define  DAQ_ERR_BADCAMPARAM                        (_DAQ_ERR + 0x0036)  // Bad camera parameter from the configuration file
#define  DAQ_ERR_PALKEYDTCT                         (_DAQ_ERR + 0x0037)  // PAL key detection error
#define  DAQ_ERR_BAD_CLOCK_FREQUENCY                (_DAQ_ERR + 0x0038)  // Bad frequency values
#define  DAQ_ERR_BITP                               (_DAQ_ERR + 0x0039)  // Bad interface type
#define  DAQ_ERR_HARDWARE_NOT_CAPABLE               (_DAQ_ERR + 0x003A)  // Hardware not capable of supporting this
#define  DAQ_ERR_SERIAL                             (_DAQ_ERR + 0x003B)  // serial port error
#define  DAQ_ERR_MXPI                               (_DAQ_ERR + 0x003C)  // exhausted pulse id's
#define  DAQ_ERR_BPID                               (_DAQ_ERR + 0x003D)  // bad pulse id
#define  DAQ_ERR_NEVR                               (_DAQ_ERR + 0x003E)  // should never get this error - bad code!
#define  DAQ_ERR_SERIAL_TIMO                        (_DAQ_ERR + 0x003F)  // serial transmit/receive timeout
#define  DAQ_ERR_PG_TOO_MANY                        (_DAQ_ERR + 0x0040)  // too many PG transitions defined
#define  DAQ_ERR_PG_BAD_TRANS                       (_DAQ_ERR + 0x0041)  // bad PG transition time
#define  DAQ_ERR_PLNS                               (_DAQ_ERR + 0x0042)  // pulse not started error
#define  DAQ_ERR_BPMD                               (_DAQ_ERR + 0x0043)  // bad pulse mode
#define  DAQ_ERR_ATTRIBUTE_NOT_SETTABLE             (_DAQ_ERR + 0x0044)  // non settable attribute
#define  DAQ_ERR_HYBRID                             (_DAQ_ERR + 0x0045)  // can't mix onboard and system memory buffers
#define  DAQ_ERR_BADFILFMT                          (_DAQ_ERR + 0x0046)  // the pixel depth is not supported by this file format
#define  DAQ_ERR_BADFILEXT                          (_DAQ_ERR + 0x0047)  // This file extension is not supported
#define  DAQ_ERR_NRTSI                              (_DAQ_ERR + 0x0048)  // exhausted RTSI map registers
#define  DAQ_ERR_MXTRG                              (_DAQ_ERR + 0x0049)  // exhausted trigger resources
#define  DAQ_ERR_MXRC                               (_DAQ_ERR + 0x004A)  // exhausted resources (general)
#define  DAQ_ERR_OOR                                (_DAQ_ERR + 0x004B)  // parameter out of range
#define  DAQ_ERR_NPROG                              (_DAQ_ERR + 0x004C)  // FPGA not programmed
#define  DAQ_ERR_ONBOARD_MEMORY_FULL                (_DAQ_ERR + 0x004D)  // not enough onboard memory to perform operation
#define  DAQ_ERR_BDTYPE                             (_DAQ_ERR + 0x004E)  // bad display type -- buffer cannot be displayed with MVPlot
#define  DAQ_ERR_THRDACCDEN                         (_DAQ_ERR + 0x004F)  // thread denied access to function
#define  DAQ_ERR_BADFILWRT                          (_DAQ_ERR + 0x0050)  // Could not write the file
#define  DAQ_ERR_BUFFER_NOT_RELEASED                (_DAQ_ERR + 0x0051)  // Already called ExamineBuffer once.  Call ReleaseBuffer.
#define  DAQ_ERR_BAD_LUT_TYPE                       (_DAQ_ERR + 0x0052)  // Invalid LUT type
#define  DAQ_ERR_ATTRIBUTE_NOT_READABLE             (_DAQ_ERR + 0x0053)  // non readable attribute
#define  DAQ_ERR_BOARD_NOT_SUPPORTED                (_DAQ_ERR + 0x0054)  // This version of the driver doesn't support the board.
#define  DAQ_ERR_BAD_FRAME_FIELD                    (_DAQ_ERR + 0x0055)  // The value for frame/field was invalid.
#define  DAQ_ERR_INVALID_ATTRIBUTE                  (_DAQ_ERR + 0x0056)  // The requested attribute is invalid.
#define  DAQ_ERR_BAD_LINE_MAP                       (_DAQ_ERR + 0x0057)  // The line map is invalid
#define  DAQ_ERR_BAD_CHANNEL                        (_DAQ_ERR + 0x0059)  // The requested channel is invalid.
#define  DAQ_ERR_BAD_CHROMA_FILTER                  (_DAQ_ERR + 0x005A)  // The value for the anti-chrominance filter is invalid.
#define  DAQ_ERR_BAD_SCALE                          (_DAQ_ERR + 0x005B)  // The value for scaling is invalid.
#define  DAQ_ERR_BAD_TRIGGER_MODE                   (_DAQ_ERR + 0x005D)  // The value for trigger mode is invalid.
#define  DAQ_ERR_BAD_CLAMP_START                    (_DAQ_ERR + 0x005E)  // The value for clamp start is invalid.
#define  DAQ_ERR_BAD_CLAMP_STOP                     (_DAQ_ERR + 0x005F)  // The value for clamp stop is invalid.
#define  DAQ_ERR_BAD_BRIGHTNESS                     (_DAQ_ERR + 0x0060)  // The brightness level is out of range
#define  DAQ_ERR_BAD_CONTRAST                       (_DAQ_ERR + 0x0061)  // The constrast  level is out of range
#define  DAQ_ERR_BAD_SATURATION                     (_DAQ_ERR + 0x0062)  // The saturation level is out of range
#define  DAQ_ERR_BAD_TINT                           (_DAQ_ERR + 0x0063)  // The tint level is out of range
#define  DAQ_ERR_BAD_HUE_OFF_ANGLE                  (_DAQ_ERR + 0x0064)  // The hue offset angle is out of range.
#define  DAQ_ERR_BAD_ACQUIRE_FIELD                  (_DAQ_ERR + 0x0065)  // The value for acquire field is invalid.
#define  DAQ_ERR_BAD_LUMA_BANDWIDTH                 (_DAQ_ERR + 0x0066)  // The value for luma bandwidth is invalid.
#define  DAQ_ERR_BAD_LUMA_COMB                      (_DAQ_ERR + 0x0067)  // The value for luma comb is invalid.
#define  DAQ_ERR_BAD_CHROMA_PROCESS                 (_DAQ_ERR + 0x0068)  // The value for chroma processing is invalid.
#define  DAQ_ERR_BAD_CHROMA_BANDWIDTH               (_DAQ_ERR + 0x0069)  // The value for chroma bandwidth is invalid.
#define  DAQ_ERR_BAD_CHROMA_COMB                    (_DAQ_ERR + 0x006A)  // The value for chroma comb is invalid.
#define  DAQ_ERR_BAD_RGB_CORING                     (_DAQ_ERR + 0x006B)  // The value for RGB coring is invalid.
#define  DAQ_ERR_BAD_HUE_REPLACE_VALUE              (_DAQ_ERR + 0x006C)  // The value for HSL hue replacement is out of range.
#define  DAQ_ERR_BAD_RED_GAIN                       (_DAQ_ERR + 0x006D)  // The value for red gain is out of range.
#define  DAQ_ERR_BAD_GREEN_GAIN                     (_DAQ_ERR + 0x006E)  // The value for green gain is out of range.
#define  DAQ_ERR_BAD_BLUE_GAIN                      (_DAQ_ERR + 0x006F)  // The value for blue gain is out of range.
#define  DAQ_ERR_BAD_START_FIELD                    (_DAQ_ERR + 0x0070)  // Invalid start field
#define  DAQ_ERR_BAD_TAP_DIRECTION                  (_DAQ_ERR + 0x0071)  // Invalid tap scan direction
#define  DAQ_ERR_BAD_MAX_IMAGE_RECT                 (_DAQ_ERR + 0x0072)  // Invalid maximum image rect
#define  DAQ_ERR_BAD_TAP_TYPE                       (_DAQ_ERR + 0x0073)  // Invalid tap configuration type
#define  DAQ_ERR_BAD_SYNC_RECT                      (_DAQ_ERR + 0x0074)  // Invalid sync rect
#define  DAQ_ERR_BAD_ACQWINDOW_RECT                 (_DAQ_ERR + 0x0075)  // Invalid acquisition window
#define  DAQ_ERR_BAD_HSL_CORING                     (_DAQ_ERR + 0x0076)  // The value for HSL coring is out of range.
#define  DAQ_ERR_BAD_TAP_0_ACTIVE_RECT               (_DAQ_ERR + 0x0077)  // Invalid tap 0 valid rect
#define  DAQ_ERR_BAD_TAP_1_ACTIVE_RECT               (_DAQ_ERR + 0x0078)  // Invalid tap 1 valid rect
#define  DAQ_ERR_BAD_TAP_2_ACTIVE_RECT               (_DAQ_ERR + 0x0079)  // Invalid tap 2 valid rect
#define  DAQ_ERR_BAD_TAP_3_ACTIVE_RECT               (_DAQ_ERR + 0x007A)  // Invalid tap 3 valid rect
#define  DAQ_ERR_BAD_TAP_RECT                       (_DAQ_ERR + 0x007B)  // Invalid tap rect
#define  DAQ_ERR_BAD_NUM_TAPS                       (_DAQ_ERR + 0x007C)  // Invalid number of taps
#define  DAQ_ERR_BAD_TAP_NUM                        (_DAQ_ERR + 0x007D)  // Invalid tap number
#define  DAQ_ERR_BAD_QUAD_NUM                       (_DAQ_ERR + 0x007E)  // Invalid Scarab quadrant number
#define  DAQ_ERR_BAD_NUM_DATA_LINES                 (_DAQ_ERR + 0x007F)  // Invalid number of requested data lines
#define  DAQ_ERR_BAD_BITS_PER_COMPONENT             (_DAQ_ERR + 0x0080)  // The value for bits per component is invalid.
#define  DAQ_ERR_BAD_NUM_COMPONENTS                 (_DAQ_ERR + 0x0081)  // The value for number of components is invalid.
#define  DAQ_ERR_BAD_BIN_THRESHOLD_LOW              (_DAQ_ERR + 0x0082)  // The value for the lower binary threshold is out of range.
#define  DAQ_ERR_BAD_BIN_THRESHOLD_HIGH             (_DAQ_ERR + 0x0083)  // The value for the upper binary threshold is out of range.
#define  DAQ_ERR_BAD_BLACK_REF_VOLT                 (_DAQ_ERR + 0x0084)  // The value for the black reference voltage is out of range.
#define  DAQ_ERR_BAD_WHITE_REF_VOLT                 (_DAQ_ERR + 0x0085)  // The value for the white reference voltage is out of range.
#define  DAQ_ERR_BAD_FREQ_STD                       (_DAQ_ERR + 0x0086)  // The value for the 6431 frequency standard is out of range.
#define  DAQ_ERR_BAD_HDELAY                         (_DAQ_ERR + 0x0087)  // The value for HDELAY is out of range.
#define  DAQ_ERR_BAD_LOCK_SPEED                     (_DAQ_ERR + 0x0088)  // Invalid lock speed.
#define  DAQ_ERR_BAD_BUFFER_LIST                    (_DAQ_ERR + 0x0089)  // Invalid buffer list
#define  DAQ_ERR_BOARD_NOT_INITIALIZED              (_DAQ_ERR + 0x008A)  // An attempt was made to access the board before it was initialized.
#define  DAQ_ERR_BAD_PCLK_SOURCE                    (_DAQ_ERR + 0x008B)  // Invalid pixel clock source
#define  DAQ_ERR_BAD_VIDEO_LOCK_CHANNEL             (_DAQ_ERR + 0x008C)  // Invalid video lock source
#define  DAQ_ERR_BAD_LOCK_SEL                       (_DAQ_ERR + 0x008D)  // Invalid locking mode
#define  DAQ_ERR_BAD_BAUD_RATE                      (_DAQ_ERR + 0x008E)  // Invalid baud rate for the UART
#define  DAQ_ERR_BAD_STOP_BITS                      (_DAQ_ERR + 0x008F)  // The number of stop bits for the UART is out of range.
#define  DAQ_ERR_BAD_DATA_BITS                      (_DAQ_ERR + 0x0090)  // The number of data bits for the UART is out of range.
#define  DAQ_ERR_BAD_PARITY                         (_DAQ_ERR + 0x0091)  // Invalid parity setting for the UART
#define  DAQ_ERR_TERM_STRING_NOT_FOUND              (_DAQ_ERR + 0x0092)  // Couldn't find the termination string in a serial read
#define  DAQ_ERR_SERIAL_READ_TIMEOUT                (_DAQ_ERR + 0x0093)  // Exceeded the user specified timeout for a serial read
#define  DAQ_ERR_SERIAL_WRITE_TIMEOUT               (_DAQ_ERR + 0x0094)  // Exceeded the user specified timeout for a serial write
#define  DAQ_ERR_BAD_SYNCHRONICITY                  (_DAQ_ERR + 0x0095)  // Invalid setting for whether the acquisition is synchronous.
#define  DAQ_ERR_BAD_INTERLACING_CONFIG             (_DAQ_ERR + 0x0096)  // Bad interlacing configuration
#define  DAQ_ERR_BAD_CHIP_CODE                      (_DAQ_ERR + 0x0098)  // Bad chip code.  Couldn't find a matching chip.
#define  DAQ_ERR_LUT_NOT_PRESENT                    (_DAQ_ERR + 0x0099)  // The LUT chip doesn't exist
#define  DAQ_ERR_DSPFILTER_NOT_PRESENT              (_DAQ_ERR + 0x009A)  // The DSP filter doesn't exist
#define  DAQ_ERR_DEVICE_NOT_FOUND                   (_DAQ_ERR + 0x009B)  // The IMAQ device was not found
#define  DAQ_ERR_ONBOARD_MEM_CONFIG                 (_DAQ_ERR + 0x009C)  // There was a problem while configuring onboard memory
#define  DAQ_ERR_BAD_POINTER                        (_DAQ_ERR + 0x009D)  // The pointer is bad.  It might be NULL when it shouldn't be NULL or non-NULL when it should be NULL.
#define  DAQ_ERR_BAD_BUFFER_LIST_INDEX              (_DAQ_ERR + 0x009E)  // The given buffer list index is invalid
#define  DAQ_ERR_INVALID_BUFFER_ATTRIBUTE           (_DAQ_ERR + 0x009F)  // The given buffer attribute is invalid
#define  DAQ_ERR_INVALID_BUFFER_PTR                 (_DAQ_ERR + 0x00A0)  // The given buffer wan't created by the NI-IMAQ driver
#define  DAQ_ERR_BUFFER_LIST_ALREADY_LOCKED         (_DAQ_ERR + 0x00A1)  // A buffer list is already locked down in memory for this device
#define  DAQ_ERR_BAD_DEVICE_TYPE                    (_DAQ_ERR + 0x00A2)  // The type of IMAQ device is invalid
#define  DAQ_ERR_BAD_BAR_SIZE                       (_DAQ_ERR + 0x00A3)  // The size of one or more BAR windows is incorrect
#define  DAQ_ERR_NO_ACTIVE_COUNTER_RECT              (_DAQ_ERR + 0x00A5)  // Couldn't settle on a valid counter rect
#define  DAQ_ERR_ACQ_STOPPED                        (_DAQ_ERR + 0x00A6)  // The wait terminated because the acquisition stopped.
#define  DAQ_ERR_BAD_TRIGGER_ACTION                 (_DAQ_ERR + 0x00A7)  // The trigger action is invalid.
#define  DAQ_ERR_BAD_TRIGGER_POLARITY               (_DAQ_ERR + 0x00A8)  // The trigger polarity is invalid.
#define  DAQ_ERR_BAD_TRIGGER_NUMBER                 (_DAQ_ERR + 0x00A9)  // The requested trigger line is invalid.
#define  DAQ_ERR_BUFFER_NOT_AVAILABLE               (_DAQ_ERR + 0x00AA)  // The requested buffer has been overwritten and is no longer available.
#define  DAQ_ERR_BAD_PULSE_ID                       (_DAQ_ERR + 0x00AC)  // The given pulse id is invalid
#define  DAQ_ERR_BAD_PULSE_TIMEBASE                 (_DAQ_ERR + 0x00AD)  // The given timebase is invalid.
#define  DAQ_ERR_BAD_PULSE_GATE                     (_DAQ_ERR + 0x00AE)  // The given gate signal for the pulse is invalid.
#define  DAQ_ERR_BAD_PULSE_GATE_POLARITY            (_DAQ_ERR + 0x00AF)  // The polarity of the gate signal is invalid.
#define  DAQ_ERR_BAD_PULSE_OUTPUT                   (_DAQ_ERR + 0x00B0)  // The given output signal for the pulse is invalid.
#define  DAQ_ERR_BAD_PULSE_OUTPUT_POLARITY          (_DAQ_ERR + 0x00B1)  // The polarity of the output signal is invalid.
#define  DAQ_ERR_BAD_PULSE_MODE                     (_DAQ_ERR + 0x00B2)  // The given pulse mode is invalid.
#define  DAQ_ERR_NOT_ENOUGH_RESOURCES               (_DAQ_ERR + 0x00B3)  // There are not enough resources to complete the requested operation.
#define  DAQ_ERR_INVALID_RESOURCE                   (_DAQ_ERR + 0x00B4)  // The requested resource is invalid
#define  DAQ_ERR_BAD_FVAL_ENABLE                    (_DAQ_ERR + 0x00B5)  // Invalid enable mode for FVAL
#define  DAQ_ERR_BAD_WRITE_ENABLE_MODE              (_DAQ_ERR + 0x00B6)  // Invalid combination of enables to write to DRAM
#define  DAQ_ERR_COMPONENT_MISMATCH                 (_DAQ_ERR + 0x00B7)  // Internal Error: The installed components of the driver are incompatible.  Reinstall the driver.
#define  DAQ_ERR_FPGA_PROGRAMMING_FAILED            (_DAQ_ERR + 0x00B8)  // Internal Error: Downloading the program to an FPGA didn't work.
#define  DAQ_ERR_CONTROL_FPGA_FAILED                (_DAQ_ERR + 0x00B9)  // Internal Error: The Control FPGA didn't initialize properly
#define  DAQ_ERR_CHIP_NOT_READABLE                  (_DAQ_ERR + 0x00BA)  // Internal Error: Attempt to read a write-only chip.
#define  DAQ_ERR_CHIP_NOT_WRITABLE                  (_DAQ_ERR + 0x00BB)  // Internal Error: Attempt to write a read-only chip.
#define  DAQ_ERR_I2C_BUS_FAILED                     (_DAQ_ERR + 0x00BC)  // Internal Error: The I2C bus didn't respond correctly.
#define  DAQ_ERR_DEVICE_IN_USE                      (_DAQ_ERR + 0x00BD)  // The requested IMAQ device is already open
#define  DAQ_ERR_BAD_TAP_DATALANES                  (_DAQ_ERR + 0x00BE)  // The requested data lanes on a particular tap are invalid
#define  DAQ_ERR_BAD_VIDEO_GAIN                     (_DAQ_ERR + 0x00BF)  // Bad video gain value
#define  DAQ_ERR_VHA_MODE_NOT_ALLOWED               (_DAQ_ERR + 0x00C0)  // VHA mode not allowed, based upon the current configuration
#define  DAQ_ERR_BAD_TRACKING_SPEED                 (_DAQ_ERR + 0x00C1)  // Bad color video tracking speed
#define  DAQ_ERR_BAD_COLOR_INPUT_SELECT             (_DAQ_ERR + 0x00C2)  // Invalid input select for the 1411
#define  DAQ_ERR_BAD_HAV_OFFSET                     (_DAQ_ERR + 0x00C3)  // Invalid HAV offset
#define  DAQ_ERR_BAD_HS1_OFFSET                     (_DAQ_ERR + 0x00C4)  // Invalid HS1 offset
#define  DAQ_ERR_BAD_HS2_OFFSET                     (_DAQ_ERR + 0x00C5)  // Invalid HS2 offset
#define  DAQ_ERR_BAD_IF_CHROMA                      (_DAQ_ERR + 0x00C6)  // Invalid chroma IF compensation
#define  DAQ_ERR_BAD_COLOR_OUTPUT_FORMAT            (_DAQ_ERR + 0x00C7)  // Invalid format for color output
#define  DAQ_ERR_BAD_SAMSUNG_SCHCMP                 (_DAQ_ERR + 0x00C8)  // Invalid phase constant
#define  DAQ_ERR_BAD_SAMSUNG_CDLY                   (_DAQ_ERR + 0x00C9)  // Invalid chroma path group delay
#define  DAQ_ERR_BAD_SECAM_DETECT                   (_DAQ_ERR + 0x00CA)  // Invalid method for secam detection
#define  DAQ_ERR_BAD_FSC_DETECT                     (_DAQ_ERR + 0x00CB)  // Invalid method for fsc detection
#define  DAQ_ERR_BAD_SAMSUNG_CFTC                   (_DAQ_ERR + 0x00CC)  // Invalid chroma frequency tracking time constant
#define  DAQ_ERR_BAD_SAMSUNG_CGTC                   (_DAQ_ERR + 0x00CD)  // Invalid chroma gain tracking time constant
#define  DAQ_ERR_BAD_SAMSUNG_SAMPLE_RATE            (_DAQ_ERR + 0x00CE)  // Invalid pixel sampling rate
#define  DAQ_ERR_BAD_SAMSUNG_VSYNC_EDGE             (_DAQ_ERR + 0x00CF)  // Invalid edge for vsync to follow
#define  DAQ_ERR_SAMSUNG_LUMA_GAIN_CTRL             (_DAQ_ERR + 0x00D0)  // Invalid method to control the luma gain
#define  DAQ_ERR_BAD_SET_COMB_COEF                  (_DAQ_ERR + 0x00D1)  // Invalid way to set the chroma comb coefficients
#define  DAQ_ERR_SAMSUNG_CHROMA_TRACK               (_DAQ_ERR + 0x00D2)  // Invalid method to track chroma
#define  DAQ_ERR_SAMSUNG_DROP_LINES                 (_DAQ_ERR + 0x00D3)  // Invalid algorithm to drop video lines
#define  DAQ_ERR_VHA_OPTIMIZATION_NOT_ALLOWED       (_DAQ_ERR + 0x00D4)  // VHA optimization not allowed, based upon the current configuration
#define  DAQ_ERR_BAD_PG_TRANSITION                  (_DAQ_ERR + 0x00D5)  // A pattern generation transition is invalid
#define  DAQ_ERR_TOO_MANY_PG_TRANSITIONS            (_DAQ_ERR + 0x00D6)  // User is attempting to generate more pattern generation transitions than we support
#define  DAQ_ERR_BAD_CL_DATA_CONFIG                 (_DAQ_ERR + 0x00D7)  // Invalid data configuration for the Camera Link chips
#define  DAQ_ERR_BAD_OCCURRENCE                     (_DAQ_ERR + 0x00D8)  // The given occurrence is not valid.
#define  DAQ_ERR_BAD_PG_MODE                        (_DAQ_ERR + 0x00D9)  // Invalid pattern generation mode
#define  DAQ_ERR_BAD_PG_SOURCE                      (_DAQ_ERR + 0x00DA)  // Invalid pattern generation source signal
#define  DAQ_ERR_BAD_PG_GATE                        (_DAQ_ERR + 0x00DB)  // Invalid pattern generation gate signal
#define  DAQ_ERR_BAD_PG_GATE_POLARITY               (_DAQ_ERR + 0x00DC)  // Invalid pattern generation gate polarity
#define  DAQ_ERR_BAD_PG_WAVEFORM_INITIAL_STATE      (_DAQ_ERR + 0x00DD)  // Invalid pattern generation waveform initial state
#define  DAQ_ERR_INVALID_CAMERA_ATTRIBUTE           (_DAQ_ERR + 0x00DE)  // The requested camera attribute is invalid
#define  DAQ_ERR_BOARD_CLOSED                       (_DAQ_ERR + 0x00DF)  // The request failed because the board was closed
#define  DAQ_ERR_FILE_NOT_FOUND                     (_DAQ_ERR + 0x00E0)  // The requested file could not be found
#define  DAQ_ERR_BAD_1409_DSP_FILE                  (_DAQ_ERR + 0x00E1)  // The dspfilter1409.bin file was corrupt or missing
#define  DAQ_ERR_BAD_SCARABXCV200_32_FILE           (_DAQ_ERR + 0x00E2)  // The scarabXCV200.bin file was corrupt or missing
#define  DAQ_ERR_BAD_SCARABXCV200_16_FILE           (_DAQ_ERR + 0x00E3)  // The scarab16bit.bin file was corrupt or missing
#define  DAQ_ERR_BAD_CAMERA_LINK_FILE               (_DAQ_ERR + 0x00E4)  // The data1428.bin file was corrupt or missing
#define  DAQ_ERR_BAD_1411_CSC_FILE                  (_DAQ_ERR + 0x00E5)  // The colorspace.bin file was corrupt or missing
#define  DAQ_ERR_BAD_ERROR_CODE                     (_DAQ_ERR + 0x00E6)  // The error code passed into MVShowError was unknown.
#define  DAQ_ERR_DRIVER_TOO_OLD                     (_DAQ_ERR + 0x00E7)  // The board requires a newer version of the driver.
#define  DAQ_ERR_INSTALLATION_CORRUPT               (_DAQ_ERR + 0x00E8)  // A driver piece is not present (.dll, registry entry, etc).
#define  DAQ_ERR_NO_ONBOARD_MEMORY                  (_DAQ_ERR + 0x00E9)  // There is no onboard memory, thus an onboard acquisition cannot be performed.
#define  DAQ_ERR_BAD_BAYER_PATTERN                  (_DAQ_ERR + 0x00EA)  // The Bayer pattern specified is invalid.
#define  DAQ_ERR_CANNOT_INITIALIZE_BOARD            (_DAQ_ERR + 0x00EB)  // The board is not operating correctly and cannot be initialized.
#define  DAQ_ERR_CALIBRATION_DATA_CORRUPT           (_DAQ_ERR + 0x00EC)  // The stored calibration data has been corrupted.
#define  DAQ_ERR_DRIVER_FAULT                       (_DAQ_ERR + 0x00ED)  // The driver attempted to perform an illegal operation.
#define  DAQ_ERR_ADDRESS_OUT_OF_RANGE               (_DAQ_ERR + 0x00EE)  // An attempt was made to access a chip beyond it's addressable range.
#define  DAQ_ERR_ONBOARD_ACQUISITION                (_DAQ_ERR + 0x00EF)  // The requested operation is not valid for onboard acquisitions.
#define  DAQ_ERR_NOT_AN_ONBOARD_ACQUISITION         (_DAQ_ERR + 0x00F0)  // The requested operation is only valid for onboard acquisitions.
#define  DAQ_ERR_BOARD_ALREADY_INITIALIZED          (_DAQ_ERR + 0x00F1)  // An attempt was made to call an initialization function on a board that was already initialized.
#define  DAQ_ERR_NO_SERIAL_PORT                     (_DAQ_ERR + 0x00F2)  // Tried to use the serial port on a board that doesn't have one
#define  DAQ_ERR_BAD_VENABLE_GATING_MODE            (_DAQ_ERR + 0x00F3)  // The VENABLE gating mode selection is invalid
#define  DAQ_ERR_BAD_1407_LUT_FILE                  (_DAQ_ERR + 0x00F4)  // The lutfpga1407.bin was corrupt or missing
#define  DAQ_ERR_BAD_SYNC_DETECT_LEVEL              (_DAQ_ERR + 0x00F5)  // The detect sync level is out of range for the 1407 rev A-D
#define  DAQ_ERR_BAD_1405_GAIN_FILE                 (_DAQ_ERR + 0x00F6)  // The gain1405.bin file was corrupt or missing
#define  DAQ_ERR_CLAMP_DAC_NOT_PRESENT              (_DAQ_ERR + 0x00F7)  // The device doesn't have a clamp DAC
#define  DAQ_ERR_GAIN_DAC_NOT_PRESENT               (_DAQ_ERR + 0x00F8)  // The device doesn't have a gain DAC
#define  DAQ_ERR_REF_DAC_NOT_PRESENT                (_DAQ_ERR + 0x00F9)  // The device doesn't have a reference DAC
#define  DAQ_ERR_BAD_SCARABXC2S200_FILE             (_DAQ_ERR + 0x00FA)  // The scarab16bit.bin file was corrupt or missing
#define  DAQ_ERR_BAD_LUT_GAIN                       (_DAQ_ERR + 0x00FB)  // The desired LUT gain is invalid
#define  DAQ_ERR_BAD_MAX_BUF_LIST_ITER              (_DAQ_ERR + 0x00FC)  // The desired maximum number of buffer list iterations to store on onboard memory is invalid
#define  DAQ_ERR_BAD_PG_LINE_NUM                    (_DAQ_ERR + 0x00FD)  // The desired pattern generation line number is invalid
#define  DAQ_ERR_BAD_BITS_PER_PIXEL                 (_DAQ_ERR + 0x00FE)  // The desired number of bits per pixel is invalid
#define  DAQ_ERR_TRIGGER_ALARM                      (_DAQ_ERR + 0x00FF)  // Triggers are coming in too fast to handle them and maintain system responsiveness.  Check for glitches on your trigger line.
#define  DAQ_ERR_BAD_SCARABXC2S200_03052009_FILE    (_DAQ_ERR + 0x0100)  // The scarabXC2S200_03052009.bin file was corrupt or missing
#define  DAQ_ERR_LUT_CONFIG                         (_DAQ_ERR + 0x0101)  // There was an error configuring the LUT
#define  DAQ_ERR_CONTROL_FPGA_REQUIRES_NEWER_DRIVER (_DAQ_ERR + 0x0102)  // The Control FPGA requires a newer version of the driver than is currently installed.  This can happen when field upgrading the Control FPGA.
#define  DAQ_ERR_CONTROL_FPGA_PROGRAMMING_FAILED    (_DAQ_ERR + 0x0103) // The FlashCPLD reported that the Control FPGA did not program successfully.
#define  DAQ_ERR_BAD_TRIGGER_SIGNAL_LEVEL           (_DAQ_ERR + 0x0104) // A trigger signalling level is invalid.
#define  DAQ_ERR_CAMERA_FILE_REQUIRES_NEWER_DRIVER  (_DAQ_ERR + 0x0105) // The camera file requires a newer version of the driver
#define  DAQ_ERR_DUPLICATED_BUFFER                  (_DAQ_ERR + 0x0106) // The same image was put in the buffer list twice.  LabVIEW only.
#define  DAQ_ERR_NO_ERROR                           (_DAQ_ERR + 0x0107) // No error.  Never returned by the driver.
#define  DAQ_ERR_INTERFACE_NOT_SUPPORTED            (_DAQ_ERR + 0x0108) // The camera file does not support the board that is trying to open it.
#define  DAQ_ERR_BAD_PCLK_POLARITY                  (_DAQ_ERR + 0x0109) // The requested polarity for the pixel clock is invalid.
#define  DAQ_ERR_BAD_ENABLE_POLARITY                (_DAQ_ERR + 0x010A) // The requested polarity for the enable line is invalid.
#define  DAQ_ERR_BAD_PCLK_SIGNAL_LEVEL              (_DAQ_ERR + 0x010B) // The requested signaling level for the pixel clock is invalid.
#define  DAQ_ERR_BAD_ENABLE_SIGNAL_LEVEL            (_DAQ_ERR + 0x010C) // The requested signaling level for the enable line is invalid.
#define  DAQ_ERR_BAD_DATA_SIGNAL_LEVEL              (_DAQ_ERR + 0x010D) // The requested signaling level for the data lines is invalid.
#define  DAQ_ERR_BAD_CTRL_SIGNAL_LEVEL              (_DAQ_ERR + 0x010E) // The requested signaling level for the control lines is invalid.
#define  DAQ_ERR_BAD_WINDOW_HANDLE                  (_DAQ_ERR + 0x010F) // The given window handle is invalid
#define  DAQ_ERR_CANNOT_WRITE_FILE                  (_DAQ_ERR + 0x0110) // Cannot open the requested file for writing.
#define  DAQ_ERR_CANNOT_READ_FILE                   (_DAQ_ERR + 0x0111) // Cannot open the requested file for reading.
#define  DAQ_ERR_BAD_SIGNAL_TYPE                    (_DAQ_ERR + 0x0112) // The signal passed into MVSessionWaitSignal(Async) was invalid.
#define  DAQ_ERR_BAD_SAMPLES_PER_LINE               (_DAQ_ERR + 0x0113) // Invalid samples per line
#define  DAQ_ERR_BAD_SAMPLES_PER_LINE_REF           (_DAQ_ERR + 0x0114) // Invalid samples per line reference
#define  DAQ_ERR_USE_EXTERNAL_HSYNC                 (_DAQ_ERR + 0x0115) // The current video signal requires an external HSYNC to be used to lock the signal.
#define  DAQ_ERR_BUFFER_NOT_ALIGNED                 (_DAQ_ERR + 0x0116) // An image buffer is not properly aligned.  It must be aligned to a DWORD boundary.
#define  DAQ_ERR_ROWPIXELS_TOO_SMALL                (_DAQ_ERR + 0x0117) // The number of pixels per row is less than the region of interest width.
#define  DAQ_ERR_ROWPIXELS_NOT_ALIGNED              (_DAQ_ERR + 0x0118) // The number of pixels per row is not properly aligned.  The total number of bytes per row must be aligned to a DWORD boundary.
#define  DAQ_ERR_ROI_WIDTH_NOT_ALIGNED              (_DAQ_ERR + 0x0119) // The ROI width is not properly aligned.  The total number of bytes bounded by ROI width must be aligned to a DWORD boundary.
#define  DAQ_ERR_LINESCAN_NOT_ALLOWED               (_DAQ_ERR + 0x011A) // Linescan mode is not allowed for this tap configuration.
#define  DAQ_ERR_INTERFACE_FILE_REQUIRES_NEWER_DRIVER (_DAQ_ERR + 0x011B) // The camera file requires a newer version of the driver
#define  DAQ_ERR_BAD_SKIP_COUNT                     (_DAQ_ERR + 0x011C) // The requested skip count value is out of range.
#define  DAQ_ERR_BAD_NUM_X_ZONES                    (_DAQ_ERR + 0x011D) // The number of X-zones is invalid
#define  DAQ_ERR_BAD_NUM_Y_ZONES                    (_DAQ_ERR + 0x011E) // The number of Y-zones is invalid
#define  DAQ_ERR_BAD_NUM_TAPS_PER_X_ZONE            (_DAQ_ERR + 0x011F) // The number of taps per X-zone is invalid
#define  DAQ_ERR_BAD_NUM_TAPS_PER_Y_ZONE            (_DAQ_ERR + 0x0120) // The number of taps per Y-zone is invalid
#define  DAQ_ERR_BAD_TEST_IMAGE_TYPE                (_DAQ_ERR + 0x0121) // The requested test image type is invalid
#define  DAQ_ERR_CANNOT_ACQUIRE_FROM_CAMERA         (_DAQ_ERR + 0x0122) // This firmware is not capable of acquiring from a camera
#define  DAQ_ERR_BAD_CTRL_LINE_SOURCE               (_DAQ_ERR + 0x0123) // The selected source for one of the camera control lines is bad
#define  DAQ_ERR_BAD_PIXEL_EXTRACTOR                (_DAQ_ERR + 0x0124) // The desired pixel extractor is invalid
#define  DAQ_ERR_BAD_NUM_TIME_SLOTS                 (_DAQ_ERR + 0x0125) // The desired number of time slots is invalid
#define  DAQ_ERR_BAD_PLL_VCO_DIVIDER                (_DAQ_ERR + 0x0126) // The VCO divide by number was invalide for the ICS1523
#define  DAQ_ERR_CRITICAL_TEMP                      (_DAQ_ERR + 0x0127) // The device temperature exceeded the critical temperature threshold
#define  DAQ_ERR_BAD_DPA_OFFSET                     (_DAQ_ERR + 0x0128) // The requested dynamic phase aligner offset is invalid
#define  DAQ_ERR_BAD_NUM_POST_TRIGGER_BUFFERS       (_DAQ_ERR + 0x0129) // The requested number of post trigger buffers is invalid
#define  DAQ_ERR_BAD_DVAL_MODE                      (_DAQ_ERR + 0x012A) // The requested DVAL mode is invalid
#define  DAQ_ERR_BAD_TRIG_GEN_REARM_SOURCE          (_DAQ_ERR + 0x012B) // The requested trig gen rearm source signal is invalid
#define  DAQ_ERR_BAD_ASM_GATE_SOURCE                (_DAQ_ERR + 0x012C) // The requested ASM gate signal is invalid
#define  DAQ_ERR_TOO_MANY_BUFFERS                   (_DAQ_ERR + 0x012D) // The requested number of buffer list buffers is not supported by this IMAQ device
#define  DAQ_ERR_BAD_TAP_4_ACTIVE_RECT               (_DAQ_ERR + 0x012E) // Invalid tap 4 valid rect
#define  DAQ_ERR_BAD_TAP_5_ACTIVE_RECT               (_DAQ_ERR + 0x012F) // Invalid tap 5 valid rect
#define  DAQ_ERR_BAD_TAP_6_ACTIVE_RECT               (_DAQ_ERR + 0x0130) // Invalid tap 6 valid rect
#define  DAQ_ERR_BAD_TAP_7_ACTIVE_RECT               (_DAQ_ERR + 0x0131) // Invalid tap 7 valid rect
#define  DAQ_ERR_FRONT_END_BANDWIDTH_EXCEEDED       (_DAQ_ERR + 0x0132) // The camera is providing image data faster than the IMAQ device can receive it.
#define  DAQ_ERR_BAD_PORT_NUMBER                    (_DAQ_ERR + 0x0133) // The requested port number does not exist.
#define  DAQ_ERR_PORT_CONFIG_CONFLICT               (_DAQ_ERR + 0x0134) // The requested port cannot be cannot be configured due to a conflict with another port that is currently opened.
#define  DAQ_ERR_BITSTREAM_INCOMPATIBLE             (_DAQ_ERR + 0x0135) // The requested bitstream is not compatible with the IMAQ device.
#define  DAQ_ERR_SERIAL_PORT_IN_USE                 (_DAQ_ERR + 0x0136) // The requested serial port is currently in use and is not accessible.
#define  DAQ_ERR_BAD_ENCODER_DIVIDE_FACTOR          (_DAQ_ERR + 0x0137) // The requested encoder divide factor is invalid.
#define  DAQ_ERR_ENCODER_NOT_SUPPORTED              (_DAQ_ERR + 0x0138) // Encoder support is not present for this IMAQ device.  Please verify that this device is capable of handling encoder signals and that phase A and B are connected.
#define  DAQ_ERR_BAD_ENCODER_POLARITY               (_DAQ_ERR + 0x0139) // The requested encoder phase signal polarity is invalid.
#define  DAQ_ERR_BAD_ENCODER_FILTER                 (_DAQ_ERR + 0x013A) // The requested encoder filter setting is invalid.
#define  DAQ_ERR_ENCODER_POSITION_NOT_SUPPORTED     (_DAQ_ERR + 0x013B) // This IMAQ device does not support reading the absolute encoder position.
#define  DAQ_ERR_IMAGE_IN_USE                       (_DAQ_ERR + 0x013C) // The IMAQ image appears to be in use.  Please name the images differently to avoid this situation.
#define  DAQ_ERR_BAD_SCARABXL4000_FILE              (_DAQ_ERR + 0x013D) // The scarab.bin file is corrupt or missing
#define  DAQ_ERR_BAD_ATTRIBUTE_VALUE               (_DAQ_ERR + 0x013E) // The requested camera attribute value is invalid.  For numeric camera attributes, please ensure that the value is properly aligned and within the allowable range.
#define  DAQ_ERR_BAD_PULSE_WIDTH                    (_DAQ_ERR + 0x013F) // The requested pulse width is invalid.
#define  DAQ_ERR_FPGA_FILE_NOT_FOUND                (_DAQ_ERR + 0x0140) // The requested FPGA bitstream file could not be found.
#define  DAQ_ERR_FPGA_FILE_CORRUPT                  (_DAQ_ERR + 0x0141) // The requested FPGA bitstream file is corrupt.
#define  DAQ_ERR_BAD_PULSE_DELAY                    (_DAQ_ERR + 0x0142) // The requested pulse delay is invalid.
#define  DAQ_ERR_BAD_PG_IDLE_SIGNAL_LEVEL           (_DAQ_ERR + 0x0143) // On SecondGen boards tristating the idle state is all or nothing.
#define  DAQ_ERR_BAD_PG_WAVEFORM_IDLE_STATE         (_DAQ_ERR + 0x0144) // Invalid pattern generation waveform idle state
#define  DAQ_ERR_64_BIT_MEMORY_NOT_SUPPORTED        (_DAQ_ERR + 0x0145) // This device only supports acquiring into the 32-bit address space; however, portions of the image buffer list reside outside of 32-bit physical memory.
#define  DAQ_ERR_64_BIT_MEMORY_UPDATE_AVAILABLE     (_DAQ_ERR + 0x0146) // This 32-bit device is operating on a 64-bit OS with more than 3GB of physical memory.  An update is available to allow acquisitions into 64-bit physical memory.  Launch the updater from the menu in MAX:  Tools >> NI Vision >> NI-IMAQ Firmware Updater.
#define  DAQ_ERR_32_BIT_MEMORY_LIMITATION           (_DAQ_ERR + 0x0147) // This 32-bit device is operating on a 64-bit OS with more than 3GB of physical memory.  This configuration could allocate 64-bit memory which is unsupported by the device.  To solve this problem, reduce the amount of physical memory in the system.
#define  DAQ_ERR_KERNEL_NOT_LOADED                  (_DAQ_ERR + 0x0148) // The kernel component of the driver, niimaqk.sys, is not loaded.  Verify that an IMAQ device is in your system or reinstall the driver.
#define  DAQ_ERR_BAD_SENSOR_SHUTTER_PERIOD          (_DAQ_ERR + 0x0149) // The sensor shutter period is invalid.  Check the horizontal and vertical shutter period values.
#define  DAQ_ERR_BAD_SENSOR_CCD_TYPE                (_DAQ_ERR + 0x014A) // The sensor CCD type is invalid.
#define  DAQ_ERR_BAD_SENSOR_PARTIAL_SCAN            (_DAQ_ERR + 0x014B) // The sensor partial scan mode is invalid.
#define  DAQ_ERR_BAD_SENSOR_BINNING                 (_DAQ_ERR + 0x014C) // The sensor binning mode is invalid.
#define  DAQ_ERR_BAD_SENSOR_GAIN                    (_DAQ_ERR + 0x014D) // The sensor gain value is invalid.
#define  DAQ_ERR_BAD_SENSOR_BRIGHTNESS              (_DAQ_ERR + 0x014E) // The sensor brightness value is invalid.
#define  DAQ_ERR_BAD_LED_STATE                      (_DAQ_ERR + 0x014F) // The LED state is invalid.
#define  DAQ_ERR_64_BIT_NOT_SUPPORTED				(_DAQ_ERR + 0x0150) // The operation is not supported for 64-bit applications. 
#define  DAQ_ERR_BAD_TRIGGER_DELAY                  (_DAQ_ERR + 0x0151) // The requested trigger delay value is not supported
#define  DAQ_ERR_LIGHTING_CURRENT_EXCEEDS_LIMITS    (_DAQ_ERR + 0x0152) // The configured lighting current exceeds the hardware or user's configured limits
#define  DAQ_ERR_LIGHTING_INVALID_MODE              (_DAQ_ERR + 0x0153) // The configured lighting mode is invalid
#define  DAQ_ERR_LIGHTING_EXTERNAL_INVALID_MODE     (_DAQ_ERR + 0x0154) // The configured external lighting mode is invalid
#define  DAQ_ERR_BAD_SENSOR_EXPOSURE                (_DAQ_ERR + 0x0155) // The sensor exposure time is invalid.
#define  DAQ_ERR_BAD_FRAME_RATE                     (_DAQ_ERR + 0x0156) // The frame rate is invalid for the current configuration.
#define  DAQ_ERR_BAD_SENSOR_PARTIAL_SCAN_BINNING_COMBINATION (_DAQ_ERR + 0x0157) // The partial scan mode / binning mode combination is invalid.
#define  DAQ_ERR_SOFTWARE_TRIGGER_NOT_CONFIGURED    (_DAQ_ERR + 0x0158) // The requested software trigger is not configured.
#define  DAQ_ERR_FREE_RUN_MODE_NOT_ALLOWED          (_DAQ_ERR + 0x0159) // Free-run mode is not allowed in the current configuration.  This is typically caused by simultaneously enabling free-run mode and a triggered acquisition.
#define  DAQ_ERR_BAD_LIGHTING_RAMPUP                (_DAQ_ERR + 0x015A) // The lighting ramp-up delay is either less than the minimum value allowed or larger than the maximum time that the light is allowed to be on.
#define  DAQ_ERR_AFE_CONFIG_TIMEOUT                 (_DAQ_ERR + 0x015B) // Internal Error: A write to the AFEConfig register did not complete properly.
#define  DAQ_ERR_LIGHTING_ARM_TIMEOUT               (_DAQ_ERR + 0x015C) // Internal Error: The arming of the lighting controller did not complete properly.
#define  DAQ_ERR_LIGHTING_SHORT_CIRCUIT             (_DAQ_ERR + 0x015D) // A short circuit has been detected in the internal lighting current controller.  Remove the short circuit before restarting the acquisition.
#define  DAQ_ERR_BAD_BOARD_HEALTH                   (_DAQ_ERR + 0x015E) // The board health register has indicated an internal problem.
#define  DAQ_ERR_LIGHTING_BAD_CONTINUOUS_CURRENT_LIMIT (_DAQ_ERR + 0x015F) // The requested continuous current limit for the lighting controller is less than the minimum allowed current.
#define  DAQ_ERR_LIGHTING_BAD_STROBE_DUTY_CYCLE_LIMIT (_DAQ_ERR + 0x0160) // The requested duty cycle limit for the lighting controller strobe mode is invalid.
#define  DAQ_ERR_LIGHTING_BAD_STROBE_DURATION_LIMIT (_DAQ_ERR + 0x0161) // The requested duration limit for the lighting controller strobe mode is invalid.
#define  DAQ_ERR_BAD_LIGHTING_CURRENT_EXPOSURE_COMBINATION (_DAQ_ERR + 0x0162) // The lighting current is invalid because the exposure time plus the lighting ramp-up time exceeds either the strobe duration limit or the strobe duty cycle limit.
#define  DAQ_ERR_LIGHTING_HEAD_CONFIG_NOT_FOUND     (_DAQ_ERR + 0x0163) // The configuration for the desired light head was not found
#define  DAQ_ERR_LIGHTING_HEAD_DATA_CORRUPT         (_DAQ_ERR + 0x0164) // The data for the desired light head is invalid or corrupt.
#define  DAQ_ERR_LIGHTING_ABORT_TIMEOUT             (_DAQ_ERR + 0x0165) // Internal Error: The abort of the lighting controller did not complete properly.
#define  DAQ_ERR_LIGHTING_BAD_STROBE_CURRENT_LIMIT  (_DAQ_ERR + 0x0166) // The requested strobe current limit for the lighting controller is less than the minimum allowed current.
#define  DAQ_ERR_DMA_ENGINE_UNRESPONSIVE            (_DAQ_ERR + 0x0167) // Internal Error: The DMA engine is unresponsive.  Reboot the target.  If the problem persists contact National Instruments.
#define  DAQ_ERR_LAST_ERROR                         (_DAQ_ERR + 0x167)

//============================================================================
//  Ìí¼ÓµÄ´íÎó

#define  _DAQ_ERRX                                   (_DAQ_ERR + 0x168) 

#define  DAQ_ERR_DATA_DOWNLOAD_TODSP_FAILED	    	 (_DAQ_ERRX + 0x1)

#define  DAQ_ERR_DATA_FROM_DSP_FAILED				 (_DAQ_ERRX + 0x2)                                                     

#define  DAQ_ERR_READ_FILE	                         (_DAQ_ERRX + 0x3)

#define  DAQ_ERR_OPEN_FILE  	                     (_DAQ_ERRX + 0x4)

#define  DAQ_ERR_WRITE_FILE  	                     (_DAQ_ERRX + 0x5)

#define  DAQ_ERR_BAD_GET_ATTR 	                     (_DAQ_ERRX + 0x6)

#define  DAQ_ERR_BAD_SET_ATTR						 (_DAQ_ERRX + 0x7)

#define  DAQ_ERR_BAD_GET_ID_TARET 	                 (_DAQ_ERRX + 0x8)

#define  DAQ_ERR_BAD_FIRMWARE_UPDATE 	             (_DAQ_ERRX + 0x9)

#define  DAQ_ERR_BAD_SESSION_FILE	 	             (_DAQ_ERRX + 0x0a)

#define  DAQ_ERR_NFSEESION			  	             (_DAQ_ERRX + 0x0b)

#define  DAQ_ERR_BAD_SESSION_CONFIG_FILE 	         (_DAQ_ERRX + 0x0c)

#define  DAQ_ERR_CANNOT_READ_INI_ITEM  	             (_DAQ_ERRX + 0x0d)

#define  DAQ_ERR_INVALID_INI_ITEM	  	             (_DAQ_ERRX + 0x0e)  

#define  DAQ_ERR_BAD_PCI_COMMUNICATION 	             (_DAQ_ERRX + 0x0f)

#define  DAQ_ERR_BAD_LOADFILE_TO_DSP   	             (_DAQ_ERRX + 0x10)

#define  DAQ_ERR_BAD_TEST_MODE		   	             (_DAQ_ERRX + 0x11)

#define  DAQ_ERR_CMD_NOT_WRITEABLE	  	             (_DAQ_ERRX + 0x12)

#define  DAQ_ERR_CMD_NOT_READABLE	 	             (_DAQ_ERRX + 0x13)

#define  DAQ_ERR_BAD_CMD_TYPE		  	             (_DAQ_ERRX + 0x14)

#define  DAQ_ERR_FUNC_CALL							 (_DAQ_ERRX + 0x15)

#define  DAQ_ERR_PXI0_MEMACC						 (_DAQ_ERRX + 0x16)

#define  DAQ_ERR_INI_READ                            (_DAQ_ERRX + 0x17) 

#define  DAQ_ERR_INI_WRITE                           (_DAQ_ERRX + 0x18) 

//add 2015- 09 -25
#define  DAQ_ERR_TSQ_WRITE                           (_DAQ_ERRX + 0x1c)

#define  DAQ_ERR_TSQ_NEW                             (_DAQ_ERRX + 0x1d)

#define  DAQ_ERR_TSQ_DISCARD						 (_DAQ_ERRX + 0x1e) 

#define  DAQ_ERR_GET_TSQ_ATTR                        (_DAQ_ERRX + 0x1f)

#define  DAQ_ERR_TSQ_EMPTY             				 (_DAQ_ERRX + 0x20)

#define  DAQ_ERR_TSQ_READ                            (_DAQ_ERRX + 0x21)

#define  DAQ_ERR_TSQ_ITEMS_NUMBER                    (_DAQ_ERRX + 0x22)

#define  DAQ_ERR_TSQ_FULL                            (_DAQ_ERRX + 0x23)

#define  DAQ_ERR_TSQ_READED_BUF_SIZE				 (_DAQ_ERRX + 0x24)

#define  DAQ_ERR_LOST_FRAME                          (_DAQ_ERRX + 0x25)

#define  DAQ_ERR_BUF_EMPTY                           (_DAQ_ERRX + 0x26)   //buffer is empty

#define  DAQ_ERR_BUF_FULL                            (_DAQ_ERRX + 0x27)   //buffer is full
#endif								  	                       
