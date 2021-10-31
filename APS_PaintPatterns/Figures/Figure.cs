using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    abstract class Figure
    {
        protected const int minSize = 1;

        protected int x, y;
        protected int width, height;
        protected Color borderColor, bgColor;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Width { get { return width; } set { width = value > minSize ? value : minSize; } }
        public int Height { get { return height; } set { height = value > minSize? value : minSize; } }
        public Color BorderColor { get { return borderColor; } set { borderColor = value; } }
        public Color BgColor { get { return bgColor; } set { bgColor = value; } }

        public abstract void Draw(Graphics gr);

        public Figure()
        {
            x = 0;
            y = 0;
            width = 30;
            height = 30;
            borderColor = Color.Violet;
            bgColor = Color.Purple; 
        }

        public Figure(int x, int y, int width, int height, Color borderColor, Color bgColor)
        {
            this.x = x;
            this.y = y;
            this.width = width > minSize ? width : minSize;
            this.height = height > minSize ? height : minSize;
            this.borderColor = borderColor;
            this.bgColor = bgColor;
        }

        public virtual bool Touch(int xx, int yy)
        {
            return false;
        }

        public abstract Figure Copy();
    }
}
