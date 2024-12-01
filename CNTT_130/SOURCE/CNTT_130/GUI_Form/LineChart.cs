using LiveCharts;
using LiveCharts.Wpf;
using System;

namespace GUI_Form
{
    public class LineChart : BaseChart
    {
        public ChartValues<double> Values { get; set; }

        public override void DrawChart(LiveCharts.WinForms.CartesianChart chart)
        {
            chart.Series.Clear();
            chart.AxisX.Clear();
            chart.AxisY.Clear();

            var lineSeries = new LineSeries
            {
                Title = Title,
                Values = Values
            };
            chart.Series.Add(lineSeries);

            chart.AxisX.Add(new Axis
            {
                Title = "Thời gian",
                Labels = Labels
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Giá trị"
            });

            chart.Location = new System.Drawing.Point(PositionX, PositionY);
            chart.Size = new System.Drawing.Size(Width, Height);
        }
    }

}
