using LiveCharts;
using LiveCharts.Wpf;
using System;

namespace GUI_Form
{
    public class PieChart
    {
        public string Title { get; set; }
        public ChartValues<double> Values { get; set; }
        public string[] Labels { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; } = 400;
        public int Height { get; set; } = 400;

        public void DrawChart(LiveCharts.WinForms.PieChart chart)
        {
            chart.Series.Clear();

            for (int i = 0; i < Values.Count; i++)
            {
                chart.Series.Add(new LiveCharts.Wpf.PieSeries
                {
                    Title = Labels[i],
                    Values = new ChartValues<double> { Values[i] },
                    DataLabels = true
                });
            }

            chart.Location = new System.Drawing.Point(PositionX, PositionY);
            chart.Size = new System.Drawing.Size(Width, Height);
        }
    }

}
