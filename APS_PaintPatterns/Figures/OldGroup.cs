using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    class OldGroup : DragableFigure //TODO: make figure 
    {
        private List<Figure> selectedFigures = new List<Figure>();


        //
        private List<double> selectedProportionalsW = new List<double>();
        private List<double> selectedProportionalsH = new List<double>();
        private List<double> selectedProportionalsX = new List<double>();
        private List<double> selectedProportionalsY = new List<double>();

        private double[] proportionalsW;
        private double[] proportionalsH;
        private double[] proportionalsX;
        private double[] proportionalsY;

        private bool isVisible = false;
        int corner = -1;//TODO: make it strategy
        int cornersSize = 10;
        int startX;
        int startY; 
        int startWidth;
        int startHeight;

        public class GroupCreator : Factory
        {

            OldGroup prototype;
            public GroupCreator(OldGroup template)
            {
                prototype = (OldGroup)template.Copy();
            }
            public GroupCreator()
            {
                prototype = new OldGroup();
            }

            public override Figure Create(int x, int y, int width, int height, Color borderColor, Color bgColor)
            {
                OldGroup template = (OldGroup)prototype.Copy();
                template.X = x;
                template.Y = y;
                template.Drag(prototype.X*(-1) - (prototype.width/2) +(width/2), prototype.Y * (-1) - (prototype.height/2) + (width / 2));
                template.Drag(0, 0);
                template.isVisible = false;
                
                //if (true) throw new Exception();
                return template;
                
            }
        }

        public List<Figure> SelectedFiguries {
            set
            {
                selectedFigures.Clear();
                selectedProportionalsH.Clear();
                selectedProportionalsW.Clear();
                selectedProportionalsX.Clear();
                selectedProportionalsY.Clear();
                               
                foreach (Figure newItem in value)
                {
                    selectedFigures.Add(newItem);
                    
                    selectedProportionalsX.Add((double)(newItem.X - startX) / (double)Width);
                    selectedProportionalsY.Add((double)(newItem.Y - startY) / (double)Height);
                    selectedProportionalsH.Add((double)newItem.Height / (double)Height);
                    selectedProportionalsW.Add((double)newItem.Width / (double)Width);
                }

                proportionalsW = selectedProportionalsW.ToArray();
                proportionalsH = selectedProportionalsH.ToArray();
                proportionalsX = selectedProportionalsX.ToArray();
                proportionalsY = selectedProportionalsY.ToArray();
            }

            get { return selectedFigures; }
        }

        public bool IsVisible { get { return isVisible; } }

        public override void Drag(int dX, int dY)
        {
            int i = 0; //Кто же знал, что я докачусь до такого
            
            //изменение размеров объекта селектора
            x = corner < 0 ? x + dX : x + dX * (corner % 2 == 0 ? 0 : 1);
            y = corner < 0 ? y + dY : y + dY * (corner % 3 == 0 || corner % 4 == 0 ? 0 : 1);
            width = width < 1? 1 : corner < 0 ? width : width - dX * (corner % 2 == 0 ? - 1 : 1);
            height = height < 1 ? 1 : corner < 0 ? height : height - dY * (corner % 3 == 0 || corner % 4 == 0 ? -1 : 1);

            //пропорциональное уменьшение 
            foreach (Figure figure in selectedFigures)
            {
                figure.X = (int)(proportionalsX[i] * startWidth + (x));
                figure.Y = (int)(proportionalsY[i] * startHeight + (y));
                figure.Width = (int)(startWidth * proportionalsW[i]);
                figure.Height = (int)(startHeight * proportionalsH[i]);
                
                i++;
            }

            startX = x;
            startY = y;
            startWidth = width;
            startHeight = height;

           
        }

        public void setStartPosition(int x, int y)
        {
            isVisible = true;
            this.x = x;
            this.y = y;
            startX = x;
            startY = y;

            //сбрасываем размер
            this.width = 0;
            this.height = 0;

            //сбрасываем выбранные фигуры
            selectedFigures.Clear();
        }

        public void setEndPosition(int x, int y)
        {
            //магия, чтобы область выделялась во все стороны (ВРЕМЕННО НЕ РАБОТАЕТ)
            
            //this.x = x - this.x > 0 ? this.x : x;
            //this.y = y - this.y > 0 ? this.y : y;
            //int secondX = 0;
            //int secondY = 0;
            //secondX = x - this.x > 0 ? this.x : secondX;
            //secondY = y - this.y > 0 ? this.y : secondY;
            width = x - this.x > 0 ? x - this.x : 1;
            height = y - this.y > 0 ? y - this.y: 1;
            startWidth = width;
            startHeight = height;
        }

        public override bool Touch(int x, int y)
        {
            if (isVisible)
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddRectangle(new RectangleF(X, Y, Width, Height));
                if (gp.IsVisible(x, y)) { corner = -1; return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(X - cornersSize, Y - cornersSize, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { corner = 1; return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(X + Width, Y - cornersSize, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { corner = 2; return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(X - cornersSize, Y + Height, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { corner = 3; return true; }

                gp.ClearMarkers();
                gp.AddRectangle(new RectangleF(X + Width, Y + Height, cornersSize, cornersSize));
                if (gp.IsVisible(x, y)) { corner = 4; return true; }

            }
            return false;
        }

        public override void Draw(Graphics gr)
        {
            if (isVisible)
            {
                Pen pen = new Pen(Color.Black);
                Pen penDash = new Pen(Color.Black, 1);
                penDash.DashStyle = DashStyle.Dash;
                gr.DrawRectangle(penDash, X, Y, Width, Height);
                gr.DrawRectangle(pen, X - cornersSize, Y - cornersSize, cornersSize, cornersSize); //Первый угол
                gr.DrawRectangle(pen, X + Width, Y - cornersSize, cornersSize, cornersSize); //Второй угол
                gr.DrawRectangle(pen, X - cornersSize, Y + Height, cornersSize, cornersSize); //Третий угол
                gr.DrawRectangle(pen, X + Width, Y + Height, cornersSize, cornersSize); //Четвертый угол
                
                
            }

            foreach (Figure selected in selectedFigures)
            {
                selected.Draw(gr);
            }
        }

        public void Hide()
        {
            isVisible = false;
        }

        public override Figure Copy()
        {
            OldGroup copy = new OldGroup();
            copy.X = x;
            copy.Y = y;
            copy.Width = width;
            copy.Height = height;

            List<Figure> figures = new List<Figure>();
            foreach(Figure figure in selectedFigures)
            {
                figures.Add(figure.Copy());
                if (figure == figures.Last()) throw new Exception();
            }
            copy.SelectedFiguries = figures;
            return copy;
        }
    }
}
