using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ascan
{
    public class SetBatchDAQ
    {
        public static bool isOn = false;
        private static List<SessionInfo> batchSessionsInfo;

        private const uint ascanNumMin = 0;
        private const uint ascanNumMax = 255;

        public static void Init(List<SessionInfo> sessionsInfo)
        {
            SetBatchDAQ.batchSessionsInfo = sessionsInfo;
        }

        //使得筛选的通道和当前显示通道所有参数变得一样
        public static int Param(uint sessionIndex, uint selPort)
        {
            int error_code = 0;
            bool isSetPre = false;
            double delay = 0;
            double range = 0;
            double gain = 0;
            uint envlopDecay = 0;
            AscanWaveDectionMode waveMode = AscanWaveDectionMode.SemiPositve;
            RecieverType type = RecieverType.Pc;
            AscanEnvelopActive envelopActive = AscanEnvelopActive.OFF;

            int gateTol = 4;
            TofMode tofMode = TofMode.Flank;
            TofMode[] tofModeArr = new TofMode[gateTol];
            GateAlarmLogic[] gateAlarmLogic = new GateAlarmLogic[gateTol];
            GateAlarmActive[] gateAlarmActive = new GateAlarmActive[gateTol];
            double[] gateDelay = new double[gateTol];
            double[] gateWidth = new double[gateTol];
            double[] threshold = new double[gateTol];
            SuppressCounterActive[] scActive = new SuppressCounterActive[gateTol];
            uint[] scCount = new uint[gateTol];

            IFActive ifActive = IFActive.OFF;
            AscanIFActive ascanIfActive = AscanIFActive.OFF;

            //取得当前通道的所有参数
            error_code = GetAsacnVideoDAQ.Delay(sessionIndex, selPort, ref delay);
            error_code |= GetAsacnVideoDAQ.Range(sessionIndex, selPort, ref range);
            error_code |= GetAsacnVideoDAQ.Range(sessionIndex, selPort, ref range);
            error_code |= GetRecieverDAQ.AnalogGain(sessionIndex, selPort, ref gain);
            error_code |= GetAsacnVideoDAQ.EnvlopDecayFactor(sessionIndex, selPort, ref envlopDecay);
            error_code |= GetAsacnVideoDAQ.DetectionWaveMode(sessionIndex, selPort, ref waveMode);
            error_code |= GetPulserTransmitDAQ.RecieverMode(sessionIndex, selPort, ref type);
            error_code |= GetAsacnVideoDAQ.EnvlopActive(sessionIndex, selPort, ref envelopActive);
            error_code |= GetGateDAQ.IFActive(sessionIndex, selPort, GateType.I, ref ifActive);
            error_code |= GetAsacnVideoDAQ.IFActive(sessionIndex, selPort, ref ascanIfActive);

            for (int i = 0; i < gateTol; i++)
            {
                GateType gateIndex = (GateType)i;
                error_code |= GetGateDAQ.TofMode(sessionIndex, selPort, gateIndex, ref tofModeArr[i]);
                error_code |= GetGateDAQ.AlarmLogic(sessionIndex, selPort, gateIndex, ref gateAlarmLogic[i]);
                error_code |= GetGateDAQ.AlarmActive(sessionIndex, selPort, gateIndex, ref gateAlarmActive[i]);
                error_code |= GetGateDAQ.Delay(sessionIndex, selPort, gateIndex, ref gateDelay[i]);
                error_code |= GetGateDAQ.Width(sessionIndex, selPort, gateIndex, ref gateWidth[i]);
                error_code |= GetGateDAQ.Threshold(sessionIndex, selPort, gateIndex, ref threshold[i]);
                error_code |= GetGateDAQ.ScActive(sessionIndex, selPort, gateIndex, ref scActive[i]);
                error_code |= GetGateDAQ.ScCounter(sessionIndex, selPort, gateIndex, ref scCount[i]);
            }

            if (error_code != 0)
                return error_code;

            //赋值
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                uint port = (uint)batchSessionsInfo[i].port;
                uint seIndex = (uint)batchSessionsInfo[i].sessionIndex;
                //第二种情况||batchSessionsInfo[i].sessionIndex ！= sessionIndex
                //if (batchSessionsInfo[i].sessionIndex == sessionIndex && port != selPort )//以selPort号为依据配置同一块板卡的其他虚拟通道的参数
                {
                    error_code = SetAscanVideoDAQ.Delay(seIndex, port, delay);
                    error_code |= SetAscanVideoDAQ.Range(seIndex, port, range);
                    error_code |= SetReceiverDAQ.AnalogGain(seIndex, port, gain);
                    error_code |= SetAscanVideoDAQ.EnvlopDecayFactor(seIndex, port, envlopDecay);
                    isSetPre = SetAscanVideoDAQ.WaveMode(seIndex, port, waveMode);
                    error_code |= SetPulserTransmitDAQ.RecieverMode(seIndex, port, type);
                    error_code |= SetAscanVideoDAQ.EnvlopActive(seIndex, port, envelopActive);

                    for (int j = 0; j < gateTol; j++)
                    {
                        GateType gateIndex = (GateType)j;
                        isSetPre |= SetGateDAQ.setTofMode(seIndex, port, gateIndex, tofModeArr[j]);
                        error_code |= SetGateDAQ.AlarmLogic(seIndex, port, gateIndex, gateAlarmLogic[j]);
                        error_code |= SetGateDAQ.AlarmActive(seIndex, port, gateIndex, gateAlarmActive[j]);
                        error_code |= SetGateDAQ.Delay(seIndex, port, gateIndex, gateDelay[j]);
                        error_code |= SetGateDAQ.Width(seIndex, port, gateIndex, gateWidth[j]);
                        error_code |= SetGateDAQ.Threshold(seIndex, port, gateIndex, threshold[j]);
                        error_code |= SetGateDAQ.ScActive(seIndex, port, gateIndex, scActive[j]);
                        error_code |= SetGateDAQ.ScCounter(seIndex, port, gateIndex, scCount[j]);

                        if (error_code != 0)
                            return error_code;
                    }

                    error_code |= GetGateDAQ.TofMode(seIndex, port, GateType.I, ref tofMode);
                    if (ifActive == IFActive.ON && ascanIfActive == AscanIFActive.ON)
                    {
                        if (tofMode != TofMode.Flank)
                        {
                            MessageShow.show("Warning:" + seIndex + port + "The TOF Mode GateI must select Flank mode!",
                                "警告：" + sessionIndex + port + "门模式门I未选择Flank模式!");
                            return error_code = -1;
                        }
                        else
                        {
                            error_code |= SetGateDAQ.iFActive(seIndex, port, GateType.I, IFActive.ON);
                            error_code |= SetAscanVideoDAQ.IFActive(seIndex, port, AscanIFActive.ON);
                        }
                    }
                    else
                    {
                        error_code |= SetGateDAQ.iFActive(seIndex, port, GateType.I, IFActive.OFF);
                        error_code |= SetAscanVideoDAQ.IFActive(seIndex, port, AscanIFActive.OFF);
                    }
                    if (error_code != 0)
                        return error_code;
                }
            }
            return error_code;
        }

        public static int Delay(uint sessionIndex, double delay)
        {
            int error_code =0 ;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                uint seIndex=(uint)batchSessionsInfo[i].sessionIndex;
                //if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetAscanVideoDAQ.Delay(seIndex, (uint)batchSessionsInfo[i].port, delay);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }


        public static int Range(uint sessionIndex, double range)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetAscanVideoDAQ.Range(sessionIndex, (uint)batchSessionsInfo[i].port, range);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int AnalogGain(uint sessionIndex, double gain)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetReceiverDAQ.AnalogGain(sessionIndex, (uint)batchSessionsInfo[i].port, gain);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }


        public static int EnvlopDecayFactor(uint sessionIndex, uint value)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetAscanVideoDAQ.EnvlopDecayFactor(sessionIndex, (uint)batchSessionsInfo[i].port, value);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static bool WaveMode(uint sessionIndex, AscanWaveDectionMode waveMode)
        {
            bool isSetPre = false ;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    isSetPre = SetAscanVideoDAQ.WaveMode(sessionIndex, (uint)batchSessionsInfo[i].port, waveMode);
                    if (isSetPre)
                        break;
                }
            }
            return isSetPre;
           
        }

        public static int RecieverMode(uint sessionIndex, RecieverType type)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetPulserTransmitDAQ.RecieverMode(sessionIndex, (uint)batchSessionsInfo[i].port, type);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int EnvlopActive(uint sessionIndex, AscanEnvelopActive active)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetAscanVideoDAQ.EnvlopActive(sessionIndex, (uint)batchSessionsInfo[i].port, active);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static bool setTofMode(uint sessionIndex, GateType gateNum, TofMode tofMode)
        {
            bool isSetPre = false;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    isSetPre = SetGateDAQ.setTofMode(sessionIndex, (uint)batchSessionsInfo[i].port, gateNum, tofMode);
                    if (isSetPre)
                        break;
                }
            }
            return isSetPre;
        }

        public static int AlarmLogic(uint sessionIndex, GateType gateNum, GateAlarmLogic logic)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetGateDAQ.AlarmLogic(sessionIndex, (uint)batchSessionsInfo[i].port, gateNum, logic);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int AlarmActive(uint sessionIndex, GateType gateNum, GateAlarmActive active)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetGateDAQ.AlarmActive(sessionIndex, (uint)batchSessionsInfo[i].port, gateNum, active);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int GateDlay(uint sessionIndex, GateType gateNum, double delay)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetGateDAQ.Delay(sessionIndex, (uint)batchSessionsInfo[i].port, gateNum, delay);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int GateWidth(uint sessionIndex, GateType gateNum, double width)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetGateDAQ.Width(sessionIndex, (uint)batchSessionsInfo[i].port, gateNum, width);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int GateThreshold(uint sessionIndex, GateType gateNum, double threshold)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetGateDAQ.Threshold(sessionIndex, (uint)batchSessionsInfo[i].port, gateNum, threshold);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int ScActive(uint sessionIndex, GateType gateNum, SuppressCounterActive active)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetGateDAQ.ScActive(sessionIndex, (uint)batchSessionsInfo[i].port, gateNum, active);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int ScCounter(uint sessionIndex, GateType gateNum, uint supressCount)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetGateDAQ.ScCounter(sessionIndex, (uint)batchSessionsInfo[i].port, gateNum, supressCount);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int getTOfMode(uint sessionIndex, GateType gateNum, List<TofMode> list)
        {
            int error_code = 0;
            TofMode tofMode = TofMode.Flank;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = GetGateDAQ.TofMode(SelectAscan.sessionIndex, SelectAscan.port, gateNum, ref tofMode);
                    if (error_code != 0)
                        break;
                    list.Add(tofMode);
                }
            }
            return error_code;
        }

        public static int GateIFActive(uint sessionIndex, GateType gateNum, IFActive active)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetGateDAQ.iFActive(sessionIndex, (uint)batchSessionsInfo[i].port, gateNum, active);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

        public static int AscanVideoIFActive(uint sessionIndex, GateType gateNum, AscanIFActive active)
        {
            int error_code = 0;
            for (int i = 0; i < batchSessionsInfo.Count; i++)
            {
                if (batchSessionsInfo[i].sessionIndex == sessionIndex)
                {
                    error_code = SetAscanVideoDAQ.IFActive(sessionIndex, (uint)batchSessionsInfo[i].port, active);
                    if (error_code != 0)
                        break;
                }
            }
            return error_code;
        }

    }
}
