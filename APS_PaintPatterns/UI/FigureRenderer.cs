using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS_PaintPatterns
{
    class FigureRenderer
    {
        private List<Figures.Figure> figures = new List<Figures.Figure>();
        private Figures.DragableFigure selector;

        public FigureRenderer()
        {

        }

        public void InitSelector(Figures.DragableFigure selector)
        {
            this.selector = selector;
        }

        public void Add(Figures.Figure figure)
        {
            if (figure != null) figures.Add(figure);
        }

        public void Draw(Graphics gr)
        {
            if(selector != null) selector.Draw(gr);
            foreach (Figures.Figure item in figures)
            {
                item.Draw(gr);
            }
        }

        public Figures.Figure Select(int x, int y)
        {
            foreach (Figures.Figure item in figures)
            {
                if (item.Touch(x, y)) return item;
            }
            return null;
        }

        public List<Figures.Figure> SelectMany(int x, int y, int width, int height)
        {
            List<Figures.Figure> selectedFigures = new List<Figures.Figure>();

            foreach (Figures.Figure item in figures)
            {
                if(item.X > x && item.X + item.Width < x + width &&
                    item.Y > y && item.Y + item.Height < y + height) // Проверяем, что выделяется вся фигура
                {
                    selectedFigures.Add(item);
                }
            }

            return selectedFigures;
        }
    }
}
