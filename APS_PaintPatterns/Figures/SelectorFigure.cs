using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    class SelectorFigure : DragableFigure
    {
        private Figure source;
        private int corner = -1;

        int borderSizeModifier = 26;
        int cornersSize = 15;

        public void SetSource(Figure figure)
        {
            source = figure;
        }

        public override void Drag(int dX, int dY)
        {
            if(source != null) switch (corner)
            {
                case -1:
                    source.X = source.X + dX;
                    source.Y = source.Y + dY;
                    return;
                case 1:
                    source.X = source.Width > 1 ? source.X + dX : source.X;
                    source.Y = source.Height > 1? source.Y + dY : source.Y;
                    source.Width = source.Width - dX;
                    source.Height = source.Height - dY;
                    return;
                case 2:
                    source.Y = source.Height > 1 ? source.Y + dY : source.Y;
                    source.Height = source.Height - dY;
                    source.Width = source.Width + dX;
                    return;
                case 3:
                    source.Height = source.Height + dY;
                    source.X = source.Width > 1 ? source.X + dX : source.X;
                    source.Width = source.Width - dX;
                    return;
                case 4:
                    source.Width = source.Width + dX;
                    source.Height = source.Height + dY;
                    return;
                default:
                    return;
            }
        }

        public override void Draw(Graphics gr)
        {
            if (source != null)
            {
                Pen pen = new Pen(Color.Black);
                Pen penDash = new Pen(Color.Black, 1);
                penDash.DashStyle = DashStyle.Dash;
                gr.DrawRectangle(penDash, source.X - borderSizeModifier / 2, source.Y - borderSizeModifier / 2, source.Width + borderSizeModifier, source.Height + borderSizeModifier);
                gr.DrawRectangle(pen, source.X - borderSizeModifier / 2, source.Y - borderSizeModifier / 2, cornersSize, cornersSize); //Первый угол
                gr.DrawRectangle(pen, source.X + borderSizeModifier / 2 - cornersSize + source.Width, source.Y - borderSizeModifier / 2, cornersSize, cornersSize); //Второй угол
                gr.DrawRectangle(pen, source.X - borderSizeModifier / 2, source.Y + borderSizeModifier / 2 - cornersSize + source.Height, cornersSize, cornersSize); //Третий угол
                gr.DrawRectangle(pen, source.X + borderSizeModifier / 2 - cornersSize + source.Width, source.Y + borderSizeModifier / 2 - cornersSize + source.Height, cornersSize, cornersSize); //Четвертый угол
            }
        }

        public override bool Touch(int x, int y)
        {
            if (source != null)
            {
                if (source.Touch(x, y)) { corner = -1; return true; }

                GraphicsPath gp = new GraphicsPath();

                gp.AddRectangle(new RectangleF(source.X - borderSizeModifier / 2, source.Y - borderSizeModifier / 2, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { corner = 1; return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(source.X + borderSizeModifier / 2 - cornersSize + source.Width, source.Y - borderSizeModifier / 2, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { corner = 2; return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(source.X - borderSizeModifier / 2, source.Y + borderSizeModifier / 2 - cornersSize + source.Height, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { corner = 3; return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(source.X + borderSizeModifier / 2 - cornersSize + source.Width, source.Y + borderSizeModifier / 2 - cornersSize + source.Height, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { corner = 4; return true; }
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
