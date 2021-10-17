using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    /// <summary>
    /// Квадрат
    /// </summary>
    class Rectangle : Figure
    {
        private Rectangle(int x, int y, int width, int height, Color mainColor, Color bgColor) : base(x, y, width, height, mainColor, bgColor){ }

        /// <summary>
        /// Фабрика квадратов, наследуемая от абстрактного класса фабрики
        /// </summary>
        public class RectangleFactory : Factory
        {
            public override Figure Create(int x, int y, int width, int height, Color mainColor, Color bgColor)
            {
                return new Rectangle(x, y, width, height, mainColor, bgColor);
            }
        }

        public override void Draw(Graphics gr)
        {
            gr.DrawRectangle(new Pen(borderColor),x,y, width, height);
        }

        public override bool Touch(int xx, int yy)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(new RectangleF(x, y, width, height));
            return gp.IsVisible(xx, yy);
        }
    }
}
