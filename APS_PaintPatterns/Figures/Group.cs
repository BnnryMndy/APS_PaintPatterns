using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    class Group : Figure
    {
        List<Figure> groupedFigures = new List<Figure>();
        //public override int X
        //{
        //    get
        //    {
                
        //        return x;
        //    }
        //    set
        //    {
        //        Drag(value - x, y);
        //        x = value;
                
        //    }
        //}

        //public override int Y
        //{
        //    get
        //    { 
        //       return y;
        //    }
        //    set
        //    {
        //        Drag(x, value - y);
        //        y = value;
        //    }
        //}

        //public override int Width
        //{
        //    get
        //    {
        //        return width;
        //    }
        //    set
        //    {
        //        width = value > minSize ? value : minSize;
        //    }
        //}

        //public override int Height
        //{
        //    get
        //    {
        //        return height;
        //    }
        //    set
        //    {
        //        height = value > minSize ? value : minSize;
        //    }
        //}

        //public void 
        public void addFigure(Figure figure)
        {
            if (groupedFigures.Contains(figure)) return;
            
            groupedFigures.Add(figure);
            //if (figure.X < this.X)
            //    this.x = figure.X;

            //if (figure.Y < this.y)
            //    this.y = figure.Y;

            //if (this.x + this.width < figure.X + figure.Width)
            //    this.width = this.Width + (figure.X + figure.Width - (this.x + this.width));

            //if (this.y + this.height < figure.Y + figure.Height)
            //    this.height = this.height + (figure.Y + figure.Height - (this.y + this.height));
        }


        //don't work now ()
        private void ungroupFigure(Figure figure)
        {
            groupedFigures.Remove(figure);

            if (figure.X == this.X)
                this.x = figure.X;

            if (figure.Y == this.y)
                this.y = figure.Y;

            if (this.x + this.width == figure.X + figure.Width)
                this.width = this.Width + (figure.X + figure.Width - (this.x + this.width));

            if (this.y + this.height == figure.Y + figure.Height)
                this.height = this.height + (figure.Y + figure.Height - (this.y + this.height));
        }

        public override Figure Copy()
        {
            Group copy = new Group(); //x, y, width, height, borderColor, bgColor
            foreach (Figure item in groupedFigures)
            {
                copy.addFigure(item.Copy());
            }
            return copy;
        }

        public override bool Touch(int xx, int yy)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(new RectangleF(x, y, width, height));
            return gp.IsVisible(xx, yy);
        }

        public override void Draw(Graphics gr)
        {
            foreach (Figure item in groupedFigures)
            {
                item.Draw(gr);
            }
        }

        public void Drag(int dx, int dy)
        {
            if (groupedFigures.Count < 1) return;
            foreach (Figure item in groupedFigures)
            {
                item.X += dx;
                item.Y += dy;
            }
        }


    }
}
