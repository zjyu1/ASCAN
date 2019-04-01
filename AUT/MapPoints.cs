using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
using TChartHorizLine = Steema.TeeChart.Styles.HorizLine;
using Map = Steema.TeeChart.Styles.Map;

namespace AUT
{
    [Serializable]
    public class MapPoints
    {
        private List<MapDots> map;
        private List<LineDots> line;

        public MapPoints(bool isStrip)
        {
            map = new List<MapDots>();

            if (isStrip)
                line = new List<LineDots>();
            else
                line = null;
        }

        public void clear()
        {
            if (map != null && map.Count != 0)
                map.Clear();

            if (line != null && line.Count != 0)
                line.Clear();
        }

        public void addAMap(double posStart, double posEnd, double valueStart, double valueEnd, Color mapColor)
        {
            if (map == null)
                return;

            MapDots mapDots = new MapDots(posStart, posEnd, valueStart, valueEnd, mapColor);
            map.Add(mapDots);
        }

        public void addAPoint(double pos, double value)
        {
            if (line == null)
                return;

            LineDots lineDots = new LineDots(pos, value);
            line.Add(lineDots);
        }

        public void ShowInChart(TChart tchart, TChartHorizLine destLine, Map destMap, Map collapseMap)
        {
            if (line != null && destLine != null)
                foreach (LineDots lineDots in line)
                    destLine.Add(lineDots.Value, lineDots.Pos);

            if (map != null && destMap != null)
            {
                foreach (MapDots mapDots in map)
                {
                    int i;
                    using (Polygon polygonToAdd = new Polygon(destMap.Shapes, tchart.Chart))
                    {
                        polygonToAdd.Add(mapDots.ValueStart, mapDots.PosStart);
                        polygonToAdd.Add(mapDots.ValueEnd, mapDots.PosStart);
                        polygonToAdd.Add(mapDots.ValueEnd, mapDots.PosEnd);
                        polygonToAdd.Add(mapDots.ValueStart, mapDots.PosEnd);
                        i = destMap.Shapes.Add(polygonToAdd);
                    }
                    destMap.Repaint();

                    destMap.Shapes[i].ParentBrush = false;
                    destMap.Shapes[i].Color = mapDots.MapColor;
                    //tgtMap.Shapes[i].Text = info;

                    destMap.Shapes[i].ParentPen = false;
                    destMap.Shapes[i].Pen.Visible = false;

                    if (collapseMap != null)
                    {
                        using (Polygon polygonToAdd = new Polygon(collapseMap.Shapes, tchart.Chart))
                        {
                            polygonToAdd.Add(0, mapDots.PosStart);
                            polygonToAdd.Add(100, mapDots.PosStart);
                            polygonToAdd.Add(100, mapDots.PosEnd);
                            polygonToAdd.Add(0, mapDots.PosEnd);
                            i = collapseMap.Shapes.Add(polygonToAdd);
                        }
                        collapseMap.Repaint();

                        collapseMap.Shapes[i].ParentBrush = false;
                        collapseMap.Shapes[i].Color = mapDots.MapColor;

                        collapseMap.Shapes[i].ParentPen = false;
                        collapseMap.Shapes[i].Pen.Visible = false;
                    }
                }
            }
        }
    }

    [Serializable]
    public class MapDots
    {
        private double posStart;
        private double posEnd;
        private double valueStart;
        private double valueEnd;
        private Color mapColor;

        public double PosStart { get { return posStart; } }
        public double PosEnd { get { return posEnd; } }
        public double ValueStart { get { return valueStart; } }
        public double ValueEnd { get { return valueEnd; } }
        public Color MapColor { get { return mapColor; } }

        public MapDots(double posStart, double posEnd, double valueStart, double valueEnd, Color mapColor)
        {
            this.posStart = posStart;
            this.posEnd = posEnd;
            this.valueStart = valueStart;
            this.valueEnd = valueEnd;

            this.mapColor = mapColor;
        }
    }

    [Serializable]
    public class LineDots
    {
        private double pos;
        private double value;

        public double Pos { get { return pos; } }
        public double Value { get { return value; } }

        public LineDots(double pos, double value)
        {
            this.pos = pos;
            this.value = value;
        }
    }

    //Bscan Picture
    [Serializable]
    public class PicturePoints
    {
        public List<LineDates> dates;

        public PicturePoints()
        {
            dates = new List<LineDates>();
        }

        /**Reset all the points.*/
        public void clear()
        {
            if (dates != null)
            {
                foreach (LineDates point in dates)
                    point.clear();
            }
        }

        /**Add a point.*/
        public void addPoint(int rowIndex, int columnIndex, double value)
        {
            while (rowIndex >= dates.Count)
            {
                LineDates lineDates = new LineDates(dates.Count);
                dates.Add(lineDates);
            }

            dates[rowIndex].setValue(columnIndex, value);
        }
    }

    //Bscan one line data 
    [Serializable]
    public class LineDates
    {
        public double[] lines;

        public int columnIndex;

        public bool isUsed;

        public LineDates(int index)
        {
            lines = new double[256];  //ConstParameter.BscanOneLineDataNum

            columnIndex = index;

            isUsed = false;
        }

        public void setValue(int index, double value)
        {
            if (lines != null && index < lines.Length)
            {
                lines[index] = value;
                isUsed = true;
            }
        }

        public void clear()
        {
            if (lines != null)
            {
                for (int i = 0; i < lines.Length; i++)
                    lines[i] = 0;
                isUsed = false;
            }
        }
    }
}
