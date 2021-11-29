using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS_PaintPatterns.Figures
{
    interface ICorner
    {
        //void SetSource(int x, int y, int witdh, int height);

        void Drag(int dX, int dY);
    }
}
