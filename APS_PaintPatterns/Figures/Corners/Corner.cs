using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures.Corners
{

    class NotSelectedCorner : ICorner
    {
        Figure source;
        public void Drag(int dX, int dY)
        {
            source.X = source.X + dX;
            source.Y = source.Y + dY;
        }

        public NotSelectedCorner(Figure source)
        {
            this.source = source;
        }
    }

    class LeftTopCorner : ICorner
    {
        Figure source;
        public void Drag(int dX, int dY)
        {
            source.X = source.Width > 1 ? source.X + dX : source.X;
            source.Y = source.Height > 1 ? source.Y + dY : source.Y;
            source.Width = source.Width - dX;
            source.Height = source.Height - dY;
        }

        public LeftTopCorner(Figure source)
        {
            this.source = source;
        }
    }

    class RightTopCorner : ICorner
    {
        Figure source;
        public void Drag(int dX, int dY)
        {
            source.Y = source.Height > 1 ? source.Y + dY : source.Y;
            source.Height = source.Height - dY;
            source.Width = source.Width + dX;
        }

        public RightTopCorner(Figure source)
        {
            this.source = source;
        }
    }

    class LeftBottomCorner : ICorner
    {
        Figure source;
        public void Drag(int dX, int dY)
        {
            source.Height = source.Height + dY;
            source.X = source.Width > 1 ? source.X + dX : source.X;
            source.Width = source.Width - dX;
        }

        public LeftBottomCorner(Figure source)
        {
            this.source = source;
        }
    }
    class RightBottomCorner : ICorner
    {
        Figure source;
        public void Drag(int dX, int dY)
        {
            source.Width = source.Width + dX;
            source.Height = source.Height + dY;
        }

        public RightBottomCorner(Figure source)
        {
            this.source = source;
        }
    }


}
