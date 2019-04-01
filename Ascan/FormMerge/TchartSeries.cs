using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steema.TeeChart;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using TChartFastLine = Steema.TeeChart.Styles.FastLine;
using TChartPoints = Steema.TeeChart.Styles.Points;

namespace Ascan
{
    [Serializable]
    public class BaseSeries
    {
        [NonSerialized] protected TChart tchart;

        /**The max value that allowed.*/
        [NonSerialized] protected TChartFastLine maxAllowFt;
        /**The min value that allowed.*/
        [NonSerialized] protected TChartFastLine minAllowFt;

        /**Show the bad points' count.*/
        [NonSerialized] protected Steema.TeeChart.Tools.PageNumber countShow;

        /**All the config this row map need.
         *We check it when measureUIThread gave the datas.
         */
        [NonSerialized] public List<MeasureFastMatch> matchList;

        /**.Delegate for the function of updateFastLine*/
        protected delegate void updatePointsCallback(GatePacket gatePacket, int boardIndex);
        /**.Delegate for the function of clear*/
        protected delegate void clearCallback();

        [NonSerialized] protected updatePointsCallback updatePointsFunc;
        [NonSerialized] protected clearCallback clearCallbackFunc;

        public BaseSeries(TChart tchart)
        {
            this.tchart = tchart;

            this.matchList = new List<MeasureFastMatch>();
        }

        /**Initial all the series.*/
        public virtual void initSeries()
        {
            maxAllowFt = new TChartFastLine();
            //ft.LinePen.Style = DashStyle.Solid;
            //ft.Title = String.Concat("[" + index + ",Ft]");
            maxAllowFt.Visible = true;
            maxAllowFt.ShowInLegend = false;
            maxAllowFt.Color = Color.Red;
            //maxAllowFt.Add(0, ConstParameter.MaxAllowedMeasureValue);
            tchart.Series.Add(maxAllowFt);

            minAllowFt = new TChartFastLine();
            //ft.LinePen.Style = DashStyle.Solid;
            //ft.Title = String.Concat("[" + index + ",Ft]");
            minAllowFt.Visible = true;
            minAllowFt.ShowInLegend = false;
            minAllowFt.Color = Color.Red;
            //minAllowFt.Add(0, ConstParameter.MinAllowedMeasureValue);
            tchart.Series.Add(minAllowFt);

            countShow = new Steema.TeeChart.Tools.PageNumber();
            countShow.Position = Steema.TeeChart.Tools.AnnotationPositions.LeftTop;
            countShow.Shape.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            tchart.Tools.Add(countShow);
        }

        /**Weather the boardIndex, port and sourceID are matched.*/
        protected bool matchConfig(int id, int port, int source)
        {
            int sourceID;
            if (matchList == null)
                return false;

            foreach (MeasureFastMatch fastMatch in matchList)
            {
                sourceID = 1 << (int)fastMatch.source;
                if ((id == fastMatch.boardID) && (port == fastMatch.port) && (source == sourceID))
                    return true;
            }

            return false;
        }

        public virtual void removeSeries()
        {
            tchart.Series.Remove(maxAllowFt);
            tchart.Series.Remove(minAllowFt);
            tchart.Tools.Remove(countShow);
        }

        /**Set the sourceList and bind to the cycleList.*/
        public virtual void bindToList(List<RowData> rowDataList, List<List<SingleGateSeries>> singleList, List<List<DoubleGatesSeries>> doubleList)
        {
        }

        /**Rebuild the nonseriealized datas when read from file.*/
        public virtual bool rebuildNonSeriealizedDatas(TChart chart)
        {
            return true;
        }

        /**Add points which are get from measureUIThread.*/
        public virtual void updataFastLine(GatePacket gatePacket, int boardIndex)
        {
        }

        public virtual void clear()
        {
        }

        public virtual string getInfo(int x, int y)
        {
            return "";
        }
    }

    [Serializable]
    public class SingleGateSeries : BaseSeries
    {
        /**The line.*/
        [NonSerialized] private TChartFastLine ft;

        /**All the good points.*/
        [NonSerialized] private TChartPoints goodPoints;
        /**All the bad points.*/
        [NonSerialized] private TChartPoints badPoints;

        private MapPoints points;

        public SingleGateSeries(TChart tchart) : base(tchart)
        {
            initSeries();
            points = new MapPoints();
        }

        /**Initial all the series.*/
        public override void initSeries()
        {
            base.initSeries();

            ft = new TChartFastLine();
            //ft.LinePen.Style = DashStyle.Solid;
            //ft.Title = String.Concat("[" + index + ",Ft]");
            ft.Visible = true;
            ft.ShowInLegend = false;
            ft.Color = Color.Black;
            tchart.Series.Add(ft);

            goodPoints = new TChartPoints();
            goodPoints.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            goodPoints.Color = Color.Green;
            goodPoints.Title = String.Concat("Good Points");
            goodPoints.Visible = false;
            goodPoints.ShowInLegend = true;
            tchart.Series.Add(goodPoints);

            badPoints = new TChartPoints();
            badPoints.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            badPoints.Color = Color.Red;
            badPoints.Title = String.Concat("Bad Points");
            badPoints.Visible = true;
            badPoints.ShowInLegend = true;
            tchart.Series.Add(badPoints);

            updataCountShow();
            tchart.Axes.Left.SetMinMax(AscanMeasureMap.MinSingleGateValue * 1.5, AscanMeasureMap.MaxSingleGateValue * 1.5);
            maxAllowFt.Add(0, AscanMeasureMap.MaxSingleGateValue);
            minAllowFt.Add(0, AscanMeasureMap.MinSingleGateValue);
        }

        /**Rebuild the nonseriealized datas when read from file.*/
        public override bool rebuildNonSeriealizedDatas(TChart chart)
        {
            if (points == null)
                return false;

            this.tchart = chart;
            this.matchList = new List<MeasureFastMatch>();

            initSeries();
            showSeries();

            return true;
        }

        /**Show the series according to the points get from file.*/
        private void showSeries()
        {
            if (points == null)
            {
                MessageShow.show("The points to show is null", "用于显示的点为null");
                return;
            }

            points.addPointsToLine(ft, goodPoints, badPoints);

            maxAllowFt.Add(tchart.Axes.Bottom.MaxXValue, AscanMeasureMap.MaxSingleGateValue);
            minAllowFt.Add(tchart.Axes.Bottom.MaxXValue, AscanMeasureMap.MinSingleGateValue);

            updataCountShow();
        }

        /**Set the sourceList and bind to the cycleList.*/
        public override void bindToList(List<RowData> rowDataList, List<List<SingleGateSeries>> singleList, List<List<DoubleGatesSeries>> doubleList)
        {
            int cycelIndex;

            if (singleList.Count == 0)
                return;

            if (matchList.Count != 0)
                matchList.Clear();

            foreach (RowData rowData in rowDataList)
            {
                if (rowData.activity)
                {
                    int port;
                    SessionHardWare.getInfo(rowData.Cycle, out cycelIndex, out port);
                    if ((cycelIndex < 0) || (port < 0)|| (cycelIndex >= singleList.Count))
                        continue;

                    MeasureFastMatch fastMatch = new MeasureFastMatch(cycelIndex, port, rowData.Source);

                    if (!matchList.Contains(fastMatch))
                        matchList.Add(fastMatch);

                    if (!singleList[cycelIndex].Contains(this))
                        singleList[cycelIndex].Add(this);
                }
            }
        }

        /**Add points which are get from measureUIThread.*/
        public override void updataFastLine(GatePacket gatePacket, int boardIndex)
        {
            if (!tchart.InvokeRequired)
                updatePoints(gatePacket, boardIndex);
            else
            {
                if (updatePointsFunc == null)
                    updatePointsFunc = new updatePointsCallback(updataFastLine);

                tchart.Invoke(updatePointsFunc, gatePacket, boardIndex);
            }
                
        }

        private void updatePoints(GatePacket gatePacket, int boardIndex)
        {
            int sourceID = (int)gatePacket.head.id;
            int curPosX = (int)gatePacket.tag.stampPos[0] + boardIndex * 20;
            int port = (int)gatePacket.head.port;
            int num = (int)gatePacket.tag.cellNum;
            double tmpYValue, preYValue;
            int index;
            bool isFinded;
            bool isGood;

            if (points == null)
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("The class for stroging the points is null!", st);
                return;
            }

            //Weather the boardIndex and sourceID are matched.
            isFinded = matchConfig(boardIndex, port, sourceID);
            if (!isFinded)
                return;

            if (gatePacket.tag.stampPos[0] == 0)
                clear();

            for (int i = 0; i < num; i++)
            {
                index = ft.XValues.IndexOf(curPosX);
                tmpYValue = gatePacket.measureDate[i];

                //A new point.
                if (index < 0)
                {
                    isGood = addPoint(curPosX, tmpYValue);
                    ft.Add(curPosX, tmpYValue);
                    points.addPoint(curPosX, tmpYValue, boardIndex, isGood);
                }
                //An old point, need to check.
                else
                {
                    preYValue = ft.YValues[index];
                    if (Math.Abs(tmpYValue) > Math.Abs(preYValue))
                    {
                        deletePoint(curPosX, preYValue);
                        ft.Delete(index);
                        isGood = addPoint(curPosX, tmpYValue);
                        ft.Add(curPosX, tmpYValue);
                        points.addPoint(curPosX, tmpYValue, boardIndex, isGood);
                    }
                }

                curPosX += (int)gatePacket.tag.stampInc[0];


                maxAllowFt.Add(tchart.Axes.Bottom.MaxXValue, AscanMeasureMap.MaxSingleGateValue);
                minAllowFt.Add(tchart.Axes.Bottom.MaxXValue, AscanMeasureMap.MinSingleGateValue);
            }
        }

        /**Add a point to TChartPoints.*/
        private bool addPoint(int x, double y)
        {
            if ((y > AscanMeasureMap.MaxSingleGateValue) || (y < AscanMeasureMap.MinSingleGateValue))
            {
                badPoints.Add(x, y);
                updataCountShow();
                return false;
            }
            else
            {
                goodPoints.Add(x, y);
                return true;
            }
        }

        /**Delete a point From TChartPoints.*/
        private void deletePoint(int x, double y)
        {
            int index;
            if ((y > AscanMeasureMap.MaxSingleGateValue) || (y < AscanMeasureMap.MinSingleGateValue))
            {
                index = badPoints.XValues.IndexOf(x);
                if (index != -1)
                {
                    badPoints.Delete(index);
                    updataCountShow();
                }
            }
            else
            {
                index = goodPoints.XValues.IndexOf(x);
                if (index != -1)
                    goodPoints.Delete(index);
            }
        }

        /**Show bad points' count.*/
        private void updataCountShow()
        {
            if (MultiLanguage.lang == "EN")
                countShow.Text = "Count:" + this.badPoints.Count;
            else
                countShow.Text = "计数：" + this.badPoints.Count;
        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                ft.Clear();
                maxAllowFt.Clear();
                minAllowFt.Clear();
                goodPoints.Clear();
                badPoints.Clear();
                updataCountShow();
                if (points.IsUsed)
                    points.clear();

                maxAllowFt.Add(0, AscanMeasureMap.MaxSingleGateValue);
                minAllowFt.Add(0, AscanMeasureMap.MinSingleGateValue);
            }
            else
            {
                if (clearCallbackFunc == null)
                    clearCallbackFunc = new clearCallback(clear);
                tchart.Invoke(clearCallbackFunc);
            } 
        }

        public override string getInfo(int x, int y)
        {
            string info;
            int valueIndex = -1;

            valueIndex = badPoints.Clicked(x, y);
            if (valueIndex == -1 /*&& valueIndexBot == -1*/)
            {
                info = "";
            }
            else
            {
                info = points.getInfo((int)badPoints[valueIndex].X);
            }
            return info;
        }

        public override void removeSeries()
        {
            clear();

            base.removeSeries();

            tchart.Series.Remove(ft);
            tchart.Series.Remove(goodPoints);
            tchart.Series.Remove(badPoints);
        }
    }

    [Serializable]
    public class DoubleGatesSeries : BaseSeries
    {
        /**The line for max thickness.*/
        [NonSerialized] private TChartFastLine maxFt;
        /**The line for min thickness.*/
        [NonSerialized] private TChartFastLine minFt;

        /**All the good points for max thickness.*/
        [NonSerialized] private TChartPoints maxGoodPoints;
        /**All the good points for min thickness.*/
        [NonSerialized] private TChartPoints minGoodPoints;
        /**All the bad points for max thickness.*/
        [NonSerialized] private TChartPoints maxBadPoints;
        /**All the bad points for min thickness.*/
        [NonSerialized] private TChartPoints minBadPoints;

        private MapPoints maxPoints;
        private MapPoints minPoints;

        public DoubleGatesSeries(TChart tchart)
            : base(tchart)
        {
            initSeries();
            maxPoints = new MapPoints();
            minPoints = new MapPoints();
        }

        /**Initial all the series.*/
        public override void initSeries()
        {
            base.initSeries();

            maxFt = new TChartFastLine();
            //ft.LinePen.Style = DashStyle.Solid;
            //ft.Title = String.Concat("[" + index + ",Ft]");
            maxFt.Visible = true;
            maxFt.ShowInLegend = false;
            maxFt.Color = Color.Black;
            tchart.Series.Add(maxFt);

            minFt = new TChartFastLine();
            //ft.LinePen.Style = DashStyle.Solid;
            //ft.Title = String.Concat("[" + index + ",Ft]");
            minFt.Visible = true;
            minFt.ShowInLegend = false;
            minFt.Color = Color.Black;
            tchart.Series.Add(minFt);

            maxGoodPoints = new TChartPoints();
            maxGoodPoints.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            maxGoodPoints.Color = Color.Green;
            maxGoodPoints.Title = String.Concat("Good Points");
            maxGoodPoints.Visible = false;
            maxGoodPoints.ShowInLegend = true;
            tchart.Series.Add(maxGoodPoints);

            minGoodPoints = new TChartPoints();
            minGoodPoints.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            minGoodPoints.Color = Color.Green;
            minGoodPoints.Title = String.Concat("Good Points");
            minGoodPoints.Visible = false;
            minGoodPoints.ShowInLegend = true;
            tchart.Series.Add(minGoodPoints);

            maxBadPoints = new TChartPoints();
            maxBadPoints.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            maxBadPoints.Color = Color.Red;
            maxBadPoints.Title = String.Concat("Bad Points");
            maxBadPoints.Visible = true;
            maxBadPoints.ShowInLegend = true;
            tchart.Series.Add(maxBadPoints);

            minBadPoints = new TChartPoints();
            minBadPoints.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            minBadPoints.Color = Color.Red;
            minBadPoints.Title = String.Concat("Bad Points");
            minBadPoints.Visible = true;
            minBadPoints.ShowInLegend = true;
            tchart.Series.Add(minBadPoints);

            updataCountShow();
            tchart.Axes.Left.SetMinMax(AscanMeasureMap.MinDoubleGatesValue * 0.5, AscanMeasureMap.MaxDoubleGatesValue * 1.2);
            maxAllowFt.Add(0, AscanMeasureMap.MaxDoubleGatesValue);
            minAllowFt.Add(0, AscanMeasureMap.MinDoubleGatesValue);
        }

        /**Rebuild the nonseriealized datas when read from file.*/
        public override bool rebuildNonSeriealizedDatas(TChart chart)
        {
            if ((maxPoints == null) || (minPoints == null))
                return false;

            this.tchart = chart;
            this.matchList = new List<MeasureFastMatch>();

            initSeries();
            showSeries();

            return true;
        }

        /**Show the series according to the points get from file.*/
        private void showSeries()
        {
            if ((maxPoints == null) || (minPoints == null))
            {
                MessageShow.show("The points to show is null", "用于显示的点为null");
                return;
            }

            maxPoints.addPointsToLine(maxFt, maxGoodPoints, maxBadPoints);
            minPoints.addPointsToLine(minFt, minGoodPoints, minBadPoints);

            maxAllowFt.Add(tchart.Axes.Bottom.MaxXValue, AscanMeasureMap.MaxDoubleGatesValue);
            minAllowFt.Add(tchart.Axes.Bottom.MaxXValue, AscanMeasureMap.MinDoubleGatesValue);

            updataCountShow();
        }

        /**Set the sourceList and bind to the cycleList.*/
        public override void bindToList(List<RowData> rowDataList, List<List<SingleGateSeries>> singleList, List<List<DoubleGatesSeries>> doubleList)
        {
            int cycelIndex;

            if (doubleList.Count == 0)
                return;

            if (matchList.Count != 0)
                matchList.Clear();

            foreach (RowData rowData in rowDataList)
            {
                if (rowData.activity)
                {
                    int port;
                    SessionHardWare.getInfo(rowData.Cycle, out cycelIndex, out port);
                    if ((cycelIndex < 0) || (port < 0) || (cycelIndex >= singleList.Count))
                        continue;

                    MeasureFastMatch fastMatch = new MeasureFastMatch(cycelIndex, port, rowData.Source);

                    if (!matchList.Contains(fastMatch))
                        matchList.Add(fastMatch);

                    if (!doubleList[cycelIndex].Contains(this))
                        doubleList[cycelIndex].Add(this);
                }
            }
        }

        /**Add points which are get from measureUIThread.*/
        public override void updataFastLine(GatePacket gatePacket, int boardIndex)
        {
            if (!tchart.InvokeRequired)
                updatePoints(gatePacket, boardIndex);
            else
            {
                if (updatePointsFunc == null)
                    updatePointsFunc = new updatePointsCallback(updataFastLine);

                tchart.Invoke(updatePointsFunc, gatePacket, boardIndex);
            }
        }

        private void updatePoints(GatePacket gatePacket, int boardIndex)
        {
            int sourceID = (int)gatePacket.head.id;
            int bin = (int)gatePacket.head.bin;
            int port = (int)gatePacket.head.port;
            int curPosX = (int)gatePacket.tag.stampPos[0] + boardIndex * 20;
            int num = (int)gatePacket.tag.cellNum;
            double tmpYValue, preYValue;
            int index;
            bool isFinded;
            bool isGood;
            bool isMax;
            TChartFastLine ft;
            MapPoints points;

            if (bin == (int)DGateMeasMode.ThicknessMax)
            {
                ft = this.maxFt;
                points = this.maxPoints;
                isMax = true;
            }
            else if (bin == (int)DGateMeasMode.ThicknessMin)
            {
                ft = this.minFt;
                points = this.minPoints;
                isMax = false;
            }
            else
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("The bin for double gates is unrecognized!", st);
                return;
            }

            if (points == null)
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("The class for storaging the points is null!", st);
                return;
            }
            if (num >= ConstParameter.MaxMeasureDataLength)
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("The cell num in measurement package is large than " + ConstParameter.MaxMeasureDataLength, st);
                return;
            }

            //Weather the boardIndex, port and sourceID are matched.
            isFinded = matchConfig(boardIndex, port, sourceID);
            if (!isFinded)
                return;

            if (gatePacket.tag.stampPos[0] == 0)
                clear();


            for (int i = 0; i < num; i++)
            {
                index = ft.XValues.IndexOf(curPosX);
                tmpYValue = gatePacket.measureDate[i];
                if (tmpYValue <= 0)
                    continue;

                //A new point.
                if (index < 0)
                {
                    isGood = addPoint(curPosX, tmpYValue, bin);
                    ft.Add(curPosX, tmpYValue);
                    points.addPoint(curPosX, tmpYValue, boardIndex, isGood);
                }
                //An old point, need to check.
                else
                {
                    preYValue = ft.YValues[index];

                    if (isMax)
                    {
                        if (tmpYValue > preYValue)
                        {
                            deletePoint(curPosX, preYValue, bin);
                            ft.Delete(index);
                            isGood = addPoint(curPosX, tmpYValue, bin);
                            ft.Add(curPosX, tmpYValue);
                            points.addPoint(curPosX, tmpYValue, boardIndex, isGood);
                        }
                    }
                    else
                    {
                        if (tmpYValue < preYValue)
                        {
                            deletePoint(curPosX, preYValue, bin);
                            ft.Delete(index);
                            isGood = addPoint(curPosX, tmpYValue, bin);
                            ft.Add(curPosX, tmpYValue);
                            points.addPoint(curPosX, tmpYValue, boardIndex, isGood);
                        }
                    }
                }

                curPosX += (int)gatePacket.tag.stampInc[0];


                maxAllowFt.Add(tchart.Axes.Bottom.MaxXValue, AscanMeasureMap.MaxDoubleGatesValue);
                minAllowFt.Add(tchart.Axes.Bottom.MaxXValue, AscanMeasureMap.MinDoubleGatesValue);
            }
        }

        /**Add a point to TChartPoints.*/
        private bool addPoint(int x, double y, int bin)
        {
            if (bin == (int)DGateMeasMode.ThicknessMax)
            {
                if (y > AscanMeasureMap.MaxDoubleGatesValue)
                {
                    maxBadPoints.Add(x, y);
                    updataCountShow();
                    return false;
                }
                else
                {
                    maxGoodPoints.Add(x, y);
                    return true;
                }
            }
            else if (bin == (int)DGateMeasMode.ThicknessMin)
            {
                if (y < AscanMeasureMap.MinDoubleGatesValue)
                {
                    minBadPoints.Add(x, y);
                    updataCountShow();
                    return false;
                }
                else
                {
                    minGoodPoints.Add(x, y);
                    return true;
                }
            }
            else
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("The bin for double gates is unrecognized!", st);
                return false;
            }
        }

        /**Delete a point From TChartPoints.*/
        private void deletePoint(int x, double y, int bin)
        {
            int index;
            if (bin == (int)DGateMeasMode.ThicknessMax)
            {
                if (y > AscanMeasureMap.MaxDoubleGatesValue)
                {
                    index = maxBadPoints.XValues.IndexOf(x);
                    if (index != -1)
                    {
                        maxBadPoints.Delete(index);
                        updataCountShow();
                    }
                }
                else
                {
                    index = maxGoodPoints.XValues.IndexOf(x);
                    if (index != -1)
                        maxGoodPoints.Delete(index);
                }
            }
            else if (bin == (int)DGateMeasMode.ThicknessMin)
            {
                if (y < AscanMeasureMap.MinDoubleGatesValue)
                {
                    index = minBadPoints.XValues.IndexOf(x);
                    if (index != -1)
                    {
                        minBadPoints.Delete(index);
                        updataCountShow();
                    }
                }
                else
                {
                    index = minGoodPoints.XValues.IndexOf(x);
                    if (index != -1)
                        minGoodPoints.Delete(index);
                }
            }
            else
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("The bin for double gates is unrecognized!", st);
                return;
            }
        }

        /**Show bad points' count.*/
        private void updataCountShow()
        {
            if (MultiLanguage.lang == "EN")
                countShow.Text = "Count:" + (maxBadPoints.Count + minBadPoints.Count).ToString();
            else
                countShow.Text = "计数：" + (maxBadPoints.Count + minBadPoints.Count).ToString();
        }

        public override void clear()
        {
            if (!tchart.InvokeRequired)
            {
                maxFt.Clear();
                minFt.Clear();
                maxAllowFt.Clear();
                minAllowFt.Clear();
                maxGoodPoints.Clear();
                minGoodPoints.Clear();
                maxBadPoints.Clear();
                minBadPoints.Clear();
                updataCountShow();
                if (maxPoints.IsUsed)
                    maxPoints.clear();
                if (minPoints.IsUsed)
                    minPoints.clear();

                maxAllowFt.Add(0, AscanMeasureMap.MaxDoubleGatesValue);
                minAllowFt.Add(0, AscanMeasureMap.MinDoubleGatesValue);
            }
            else
            {
                if (clearCallbackFunc == null)
                    clearCallbackFunc = new clearCallback(clear);
                tchart.Invoke(clearCallbackFunc);
            } 
        }

        public override string getInfo(int x, int y)
        {
            string info;
            int valueIndex = -1;

            valueIndex = maxBadPoints.Clicked(x, y);
            if (valueIndex != -1)
            {
                info = maxPoints.getInfo((int)maxBadPoints[valueIndex].X);
                return info;
            }
            else
            {
                valueIndex = minBadPoints.Clicked(x, y);
                if (valueIndex == -1 /*&& valueIndexBot == -1*/)
                {
                    info = "";
                }
                else
                {
                    info = minPoints.getInfo((int)minBadPoints[valueIndex].X);
                }
            }

            return info;
        }

        public override void removeSeries()
        {
            clear();

            base.removeSeries();

            tchart.Series.Remove(maxFt);
            tchart.Series.Remove(minFt);
            tchart.Series.Remove(maxGoodPoints);
            tchart.Series.Remove(minGoodPoints);
            tchart.Series.Remove(maxBadPoints);
            tchart.Series.Remove(minBadPoints);
        }
    }
}
