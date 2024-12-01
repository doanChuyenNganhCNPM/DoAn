using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Media;

namespace GUI_Form
{
    public class ColumnChart : BaseChart
    {
        public ChartValues<double> Values { get; set; }

        public override void DrawChart(LiveCharts.WinForms.CartesianChart chart)
        {
            chart.Series.Clear();
            chart.AxisX.Clear();
            chart.AxisY.Clear();

            var columnSeries = new ColumnSeries
            {
                Title = Title,
                Values = Values
            };
            chart.Series.Add(columnSeries);

            chart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Danh mục",
                Labels = Labels
            });

            chart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Giá trị"
            });
            chart.Background = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
            chart.Location = new System.Drawing.Point(PositionX, PositionY);
            chart.Size = new System.Drawing.Size(Width, Height);
        }
    }
}
