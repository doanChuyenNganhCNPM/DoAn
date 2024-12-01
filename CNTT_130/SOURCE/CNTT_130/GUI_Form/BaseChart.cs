using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Form
{
    public abstract class BaseChart
    {
        public string Title { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; } = 600;
        public int Height { get; set; } = 400;
        public string[] Labels { get; set; }

        public abstract void DrawChart(LiveCharts.WinForms.CartesianChart chart);
    }
}
