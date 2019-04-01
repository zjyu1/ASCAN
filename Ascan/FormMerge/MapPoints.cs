using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TChartFastLine = Steema.TeeChart.Styles.FastLine;
using TChartPoints = Steema.TeeChart.Styles.Points;


namespace Ascan
{
    /**All the points in a row map.*/
    [Serializable]
    public class MapPoints
    {
        private List<ResultPoint> resultPoints;
        /**Weather the MapPoints is used.*/
        private bool isUsed;
        public bool IsUsed
        {
            get { return isUsed; }
        }

        public MapPoints()
        {
            resultPoints = new List<ResultPoint>();

            isUsed = false;
        }

        /**Reset all the points.*/
        public void clear()
        {
            if (resultPoints != null)
            {
                foreach (ResultPoint point in resultPoints)
                {
                    if (point.IsUsed)
                        point.clear();
                }
            }
            this.isUsed = false;
        }

        /**Add a point.*/
        public void addPoint(int x, double y, int boardId, bool isGood)
        {
            while (x >= resultPoints.Count)
            {
                ResultPoint resultPoint = new ResultPoint();
                resultPoints.Add(resultPoint);
            }

            resultPoints[x].updatePoint(y, boardId, isGood);

            isUsed = true;
        }

        /**Add the points to the TChartLine and TChartpoints.
         *We use this function when we get the points from file.
         */
        public void addPointsToLine(TChartFastLine ft, TChartPoints goodPoints, TChartPoints badPoints)
        {
            for (int i = 0; i < resultPoints.Count; i++)
            {
                if (resultPoints[i].IsUsed)
                {
                    ft.Add(i, resultPoints[i].YValue);

                    if (resultPoints[i].IsGood)
                        goodPoints.Add(i, resultPoints[i].YValue);
                    else
                        badPoints.Add(i, resultPoints[i].YValue);
                }
            }
        }
        /**Get the information of a point according to the index.*/
        public string getInfo(int index)
        {
            string name;
            ResultPoint resultPoint;

            if (index >= resultPoints.Count)
                return "";

            resultPoint = resultPoints[index];
            name = resultPoint.BoardName;
            if(name == null)
                return "";
            return "X: " + index + "\nY: " + Math.Round(resultPoint.YValue, 2) + "\nCycel: " + name;
        }
    }

    [Serializable]
    public class ResultPoint
    {
        private double yValue;
        public double YValue
        {
            get { return yValue; }
        }
        private bool isUsed;
        public bool IsUsed
        {
            get { return isUsed; }
        }
        private bool isGood;
        public bool IsGood
        {
            get { return isGood; }
        }
        private int boardId;

        private string boardName;
        public string BoardName
        {
            get { return boardName; }
        }

        public ResultPoint()
        {
            yValue = 0;
            isUsed = false;
            isGood = false;
            boardId = 0;
        }

        /**Add a point.
         *If the point is already exist, we update it.
         *If the point is not exist, just set it.
         */
        public void updatePoint(double y, int boardId, bool isGood)
        {
            string name;
            name = SessionHardWare.getSessionName(boardId);
            if (name == null)
            {
                StackTrace st = new StackTrace(new StackFrame(true));
                LogHelper.WriteLog("Can not find the name of board! Board id is " + boardId, st);
                return;
            }

            yValue = y;
            isUsed = true;
            this.boardId = boardId;
            this.boardName = name;

            this.isGood = isGood;
        }

        public void clear()
        {
            yValue = 0;
            isUsed = false;
            isGood = false;
            boardId = 0;
        }
    }
}
