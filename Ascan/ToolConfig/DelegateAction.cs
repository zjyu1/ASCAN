using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steema.TeeChart.Styles;

namespace Ascan
{
    public class DelegateAsacnNum
    {
        public delegate void SendFormNum(List<SessionInfo> sessionsAttrs);
        public static event SendFormNum SendFormNumEvent;

        //Execute the event of SendFormNumEvent
        public static void Execute(List<SessionInfo> sessionsAttrs)
        {
            if (SendFormNumEvent != null)
            {
                SendFormNumEvent(sessionsAttrs);
            }
        }
    }

    public class DelegateGateLine
    {
        private int gateNum;
        private MDIChild mDIChild;
        private double delay;
        private double width;
        private double threshold;
        public delegate void GateLineTrigger(int gateNum, MDIChild mDIChild, double delay, double width, double threshold);
        public event GateLineTrigger GateLineTriggerEvent;

        public void Execute()
        {
            if (GateLineTriggerEvent != null)
            {
                GateLineTriggerEvent(gateNum, mDIChild, delay, width, threshold);
            }
        }

        public DelegateGateLine(int gateNum, MDIChild mDIChild, double delay, double width, double threshold)
        {
            this.gateNum = gateNum;
            this.mDIChild = mDIChild;
            this.delay = delay;
            this.width = width;
            this.threshold = threshold;
        }

        public void drawGateLine(int gateNum, MDIChild mDIChild, double delay, double width, double threshold)
        {
            mDIChild.tChart.Series[gateNum].Clear();
            mDIChild.tChart.Series[gateNum].Add(delay, threshold);
            mDIChild.tChart.Series[gateNum].Add(delay + width, threshold);
        }
    }

    public class DelegateGatePosition
    {
        private FormGatePosition formGatePosition;
        private int gateNum;//the gateNum is the index of selected gate in the FormGatePosition
        private int gateLineNum;//the gateLineNum is the index of selected gateLine in the MDIChild
        private bool formEnable;
        private double delay;
        private double width;
        private double threshold;

        public delegate void GatePositionTrigger(double delay, double width, double threshold);
        public event GatePositionTrigger GatePositionTriggerEvent;

        public void Execute()
        {
            if (GatePositionTriggerEvent != null && formEnable == true && gateNum == gateLineNum)
            {
                GatePositionTriggerEvent(delay, width, threshold);
            }
        }

        public DelegateGatePosition(FormGatePosition formGatePosition, int gateLineNum, double delay, double width, double threshold)
        {
            this.formGatePosition = formGatePosition;
            this.gateNum = (int)formGatePosition.GateNum;
            this.delay = delay;
            this.width = width;
            this.threshold = threshold;
            this.formEnable = formGatePosition.Enabled;
            this.gateLineNum = gateLineNum;
        }
        
        public void updatenumUpDownOfGatePosition(double delay, double width, double threshold)
        {
            //formGatePosition.numUpDownDelay.Value = Convert.ToDecimal(delay);
            //formGatePosition.numUpDownWidth.Value = Convert.ToDecimal(width);
            //formGatePosition.numUpDownThreshold.Value = Convert.ToDecimal(threshold);
        }

    }
}
