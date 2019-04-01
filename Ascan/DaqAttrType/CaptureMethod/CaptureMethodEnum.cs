using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public enum AcqiureMode
    {
        Continue = 0x00,//连续采集模式 
        Single = 0x01,//单幅采集模式
        List = 0x02,//采集一组图像
        Latest = 0x03//下位机每次上传最新采集的数据，上位机缓存队列只有一个缓存元素
    }
}
