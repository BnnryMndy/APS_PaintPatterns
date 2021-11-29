using APS_PaintPatterns.Figures.Corners;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    class SelectorFigure : Figure
    {
        private Figure source;
 
        private ICorner selectedCorner;
        private NotSelectedCorner notSelected;
        private LeftTopCorner leftTop;
        private RightTopCorner rightTop;
        private LeftBottomCorner leftBottom;
        private RightBottomCorner rightBottom;

        public bool isVisible = false;
        int borderSizeModifier = 26;
        int cornersSize = 15;

        public void SetSource(Figure figure)
        {
            source = figure;
            notSelected = new NotSelectedCorner(source);
            leftTop = new LeftTopCorner(source);
            rightTop = new RightTopCorner(source);
            leftBottom = new LeftBottomCorner(source);
            rightBottom = new RightBottomCorner(source);

        }

        //TODO: переписать через стратегию
        public void Drag(int dX, int dY)
        {
            if (source != null) selectedCorner.Drag(dX, dY);
        }

        public override void Draw(Graphics gr)
        {
            Pen pen = new Pen(Color.Black);
            Pen penDash = new Pen(Color.Black, 1);
            penDash.DashStyle = DashStyle.Dash;
            
            if(isVisible) if (source != null)
            {
                gr.DrawRectangle(penDash, source.X - borderSizeModifier / 2, source.Y - borderSizeModifier / 2, source.Width + borderSizeModifier, source.Height + borderSizeModifier);
                gr.DrawRectangle(pen, source.X - borderSizeModifier / 2, source.Y - borderSizeModifier / 2, cornersSize, cornersSize); //Первый угол
                gr.DrawRectangle(pen, source.X + borderSizeModifier / 2 - cornersSize + source.Width, source.Y - borderSizeModifier / 2, cornersSize, cornersSize); //Второй угол
                gr.DrawRectangle(pen, source.X - borderSizeModifier / 2, source.Y + borderSizeModifier / 2 - cornersSize + source.Height, cornersSize, cornersSize); //Третий угол
                gr.DrawRectangle(pen, source.X + borderSizeModifier / 2 - cornersSize + source.Width, source.Y + borderSizeModifier / 2 - cornersSize + source.Height, cornersSize, cornersSize); //Четвертый угол
            }
            else
            {
                gr.DrawRectangle(penDash, this.X - borderSizeModifier / 2, this.Y - borderSizeModifier / 2, this.Width + borderSizeModifier, this.Height + borderSizeModifier);
                gr.DrawRectangle(pen, this.X - borderSizeModifier / 2, this.Y - borderSizeModifier / 2, cornersSize, cornersSize); //Первый угол
                gr.DrawRectangle(pen, this.X + borderSizeModifier / 2 - cornersSize + this.Width, this.Y - borderSizeModifier / 2, cornersSize, cornersSize); //Второй угол
                gr.DrawRectangle(pen, this.X - borderSizeModifier / 2, this.Y + borderSizeModifier / 2 - cornersSize + this.Height, cornersSize, cornersSize); //Третий угол
                gr.DrawRectangle(pen, this.X + borderSizeModifier / 2 - cornersSize + this.Width, this.Y + borderSizeModifier / 2 - cornersSize + this.Height, cornersSize, cornersSize); //Четвертый угол
            }
        }

        public override bool Touch(int x, int y)
        {
            if (source != null)
            {
                if (source.Touch(x, y)) { selectedCorner = notSelected; return true; }
                GraphicsPath gp = new GraphicsPath();
                gp.AddRectangle(new RectangleF(source.X - borderSizeModifier / 2, source.Y - borderSizeModifier / 2, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { selectedCorner = leftTop; return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(source.X + borderSizeModifier / 2 - cornersSize + source.Width, source.Y - borderSizeModifier / 2, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { selectedCorner = rightTop;  return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(source.X - borderSizeModifier / 2, source.Y + borderSizeModifier / 2 - cornersSize + source.Height, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { selectedCorner = leftBottom; return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(source.X + borderSizeModifier / 2 - cornersSize + source.Width, source.Y + borderSizeModifier / 2 - cornersSize + source.Height, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { selectedCorner = rightBottom; return true; }
            }


            return false;
        }

        public override Figure Copy()
        {
            SelectorFigure copy = new SelectorFigure();
            copy.SetSource(source.Copy());
            return copy;
        }
    }
}
