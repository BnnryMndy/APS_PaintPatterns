using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using APS_PaintPatterns.Figures;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS_PaintPatterns
{
    class FigureRenderer
    {
        private List<Figure> figures = new List<Figure>();
        private Figure selector;

        public FigureRenderer()
        {

        }

        public void InitSelector(Figure selector)
        {
            this.selector = selector;
        }

        public void Add(Figure figure)
        {
            if (figure != null) figures.Add(figure);
        }

        public void Draw(Graphics gr)
        {
            if(selector != null) selector.Draw(gr);
            foreach (Figure item in figures)
            {
                item.Draw(gr);
            }
        }

        public Figure Select(int x, int y)
        {
            foreach (Figure item in figures)
            {
                if (item.Touch(x, y)) return item;
            }
            return null;
        }
        public Figure Select(int x, int y, int width, int height)
        {
            Group group = new Group();
            group.X = x;
            group.Y = y;
            group.Width = width;
            group.Height = height;
            List<Figure> selectedFigures = new List<Figure>();

            foreach (Figure item in figures)
            {
                if (item.X > x && item.X + item.Width < x + width &&
                    item.Y > y && item.Y + item.Height < y + height) // Проверяем, что выделяется хотя бы часть фигуры
                {
                    selectedFigures.Add(item);
                    group.addFigure(item);
                }
            }
            if (selectedFigures.Count < 1) return null;
            if (selectedFigures.Count == 1) return selectedFigures.First();

            return group;
        }

        public List<Figure> SelectMany(int x, int y, int width, int height)
        {
            List<Figure> selectedFigures = new List<Figures.Figure>();

            foreach (Figure item in figures)
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
