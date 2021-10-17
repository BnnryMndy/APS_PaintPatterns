using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    class Ellipse : Figure
    {
        public override void Draw(Graphics gr)
        {
            Pen pen = new Pen(BorderColor);
            gr.DrawEllipse(pen, x, y, width, height);
        }

        private Ellipse(int x, int y, int width, int height, Color mainColor, Color bgColor) : base(x, y, width, height, mainColor, bgColor) { }

        public class EllipseFactory : Factory
        {
            public override Figure Create(int x, int y, int width, int height, Color borderColor, Color bgColor)
            {
                return new Ellipse(x, y, width, height, borderColor, bgColor);
            }
        }
    }
}
