using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    abstract class DragableFigure : Figure
    {
        public abstract void Drag(int dX, int dY);
    }
}
