using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Ascan
{
    public class GetPDAQ
    {
        public static int daqRead(uint index, ref UniSetPacket setPacket)
        {
            int error_code;
            const uint DOBLOCK = 1;

            error_code = DAQ.USCOMM_Read(index, ref setPacket, DOBLOCK);

            return error_code;
        }
    }
}
