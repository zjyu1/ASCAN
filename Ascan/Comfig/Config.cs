using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    class Config
    {
        public static void save(string path,uint ascanNum, uint ascanPort)
        {
            int error_code;

            error_code = GateCfg.save(ascanNum, ascanPort, path);
            if (error_code != 0)
                return;
        }

        public static void load(string path, uint ascanNum, uint ascanPort)
        {
            int error_code;

            error_code = GateCfg.load(ascanNum, ascanPort, path);
            if (error_code != 0)
                return;
        }
  
    }
}
