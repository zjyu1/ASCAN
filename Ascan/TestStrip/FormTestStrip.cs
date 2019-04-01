using Steema.TeeChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TChartHorizLine = Steema.TeeChart.Styles.HorizLine;
using TChartPoints = Steema.TeeChart.Styles.Points;
using Map = Steema.TeeChart.Styles.Map;
using TChartImage = Steema.TeeChart.Tools.ChartImage;

namespace Ascan
{

    public partial class FormTestStrip : Form
    {
        private const int OnePageDistance = 200;//mm

        private int curchan;
        private int curgate;
        private int curport;
        private int index;
        private int lastScrollBarValue;

        private double maxpos;
        private double inc;
        private float[] amplist;
        private float[] toflist;

        private List<SessionInfo> sessionsAttrs;

        private delegate void updateDelegate(double maxpos, TChart chart, float[] data);
        private updateDelegate updateCallBack;

        public FormTestStrip(List<SessionInfo> sessionsAttrs)
        {
            InitializeComponent();
            this.sessionsAttrs = sessionsAttrs;
            AddItem();
            InitSeries();
            updateCallBack = new updateDelegate(UpdateTchart);
            maxpos = 0;
        }

        private void InitSeries()
        {
            InitTchart(tChartAmp);
            InitTchart(tChartTof);
            InitScroll();
        }
        private void InitTchart(TChart chart)
        {
            chart.Axes.Bottom.Minimum = OnePageDistance;
            chart.Axes.Bottom.Maximum = OnePageDistance;
        }
        private void InitScroll()
        {
            lastScrollBarValue = 0;

            hScrollBar.Minimum = 0;
            hScrollBar.Maximum = ConstParameter.ScalePrePage;
            hScrollBar.Value = 0;
            hScrollBar.SmallChange = 10;
            hScrollBar.LargeChange = hScrollBar.Maximum;
        }
        private void chanBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curchan = chanBox.SelectedIndex;
            curport = sessionsAttrs[curport].myHardInfo.upPort;
        }

        private void gateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curgate = gateBox.SelectedIndex;
        }

        public void Add(StripData stripdata)
        {
            float[] tof = stripdata.tof;
            float[] amp = stripdata.amp;
            double startpos = stripdata.startpos;
            inc = stripdata.inc;
            int cellnum = stripdata.cellnum;
            int id = stripdata.id;
            int port = stripdata.port;

            if (id == 1<<curgate && curport == port)
            {
                Array.Copy(tof, 0, toflist, index, cellnum);
                Array.Copy(amp, 0, amplist, index, cellnum);
                index += cellnum; 
                maxpos += inc * cellnum;
            }
            UpdatePic(maxpos);
        }

        private void UpdatePic(double maxpos)
        {
            //UpdateTchart(maxpos,tChartTof,toflist);
            //UpdateTchart(maxpos,tChartAmp,amplist);

            if (null != updateCallBack)
            {
                updateCallBack(maxpos, tChartTof, toflist);
                updateCallBack(maxpos, tChartAmp, amplist);
            }
        }

        private void UpdateTchart(double maxpos, TChart chart,float[] data)
        {
            int maxindex = (int)(maxpos / inc);

            float[] xValue, yValue;

            xValue = new float[OnePageDistance];
            yValue = new float[OnePageDistance];
            for (int i = 0; i < OnePageDistance; i++)
                xValue[i] = (float)((maxindex - OnePageDistance + i)*inc);

            int startindex = maxindex - OnePageDistance;
            Array.Copy(data, maxindex- OnePageDistance, yValue, 0, OnePageDistance);

            chart.Series[0].Add(xValue, yValue);
        }

        private void AddItem()
        {
            string assignedName;
            string itemName;
            for (int i = 0; i < sessionsAttrs.Count; i++)
            {
                if (sessionsAttrs[i].myHardInfo.enable == true)
                {
                    assignedName = sessionsAttrs[i].myHardInfo.AssignedName;
                    itemName = i + "-" + assignedName;
                    chanBox.Items.Add(itemName);
                }
            }

            gateBox.Items.Add("GateI");
            gateBox.Items.Add("GateA");
            gateBox.Items.Add("GateB");
            gateBox.Items.Add("GateC");
        }

        private void cofirm_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(databox.Text);
            amplist = new float[count];
            tChartAmp.Visible = true;
            toflist = new float[count];
            tChartTof.Visible = true;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            int scaleperpage = OnePageDistance;
            if (Math.Abs(e.NewValue - lastScrollBarValue) > 10) 
            {
                lastScrollBarValue = e.NewValue;
                double reshowPosValue = e.NewValue * (maxpos - scaleperpage) / (hScrollBar.Maximum - hScrollBar.LargeChange) + scaleperpage;
                UpdatePic(reshowPosValue);
            }
        }
    }
}
