using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS_PaintPatterns.Figures;

namespace APS_PaintPatterns.UI
{
    class ToolsManager
    {
        private Factory selectedTool; //для селекта null

        private Dictionary<string, Factory> Tools = new Dictionary<string, Factory>();

        public ToolsManager()
        {
            Tools.Add("rect", new Figures.Rectangle.RectangleFactory());
            Tools.Add("ellipse", new Ellipse.EllipseFactory());

            selectedTool = Tools["rect"];
        }

        public void ToolSelect(string toolName)
        {
            selectedTool = Tools[toolName];
        }

        public Figure ToolAction(int x, int y)
        {
            return selectedTool.Create(x - 25, y - 25, 50, 50, Color.Black, Color.Transparent);
        }

    }
}
