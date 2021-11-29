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
        private FigureRenderer figureSource;
        private Dictionary<string, Factory> Tools = new Dictionary<string, Factory>();

        private OldGroup.GroupCreator paste = new OldGroup.GroupCreator();
        private SelectorFigure select = new SelectorFigure();
        private OldGroup multiSelector = new OldGroup();
        private bool isDragging = false;
        private bool isSelecting = false;
        private int startX, startY;

        public ToolsManager()
        {
            Tools.Add("rect", new Figures.Rectangle.RectangleFactory());
            Tools.Add("ellipse", new Ellipse.EllipseFactory());
            Tools.Add("select", null);
            Tools.Add("paste", paste);

            selectedTool = Tools["rect"];
        }

        public void InitRenderer(FigureRenderer renderer)
        {
            figureSource = renderer;
            renderer.InitSelector(select);
        }

        public void ToolSelect(string toolName)
        {
            selectedTool = Tools[toolName];
            if (toolName != "select")
            {
                multiSelector.Hide();
            }
        }

        public void ToolMouseDownAction(int x, int y)
        {
           
            if (selectedTool == null) // выбран select  
            {
                if (!select.Touch(x, y))
                {
                    isDragging = false;
                    isSelecting = true;
                    select.isVisible = true;
                    select.X = x;
                    select.Y = y;
                    startX = x;
                    startY = y;

                }
                else
                {
                    isSelecting = false;
                    isDragging = true;
                    startX = x;
                    startY = y;
                    return;
                }

            }
            else
            {
                Figure figure = selectedTool.Create(x - 25, y - 25, 50, 50, Color.Black, Color.Transparent);
                figureSource.Add(figure);
            }
                
        }

        public void ToolMouseMoveAction(int x, int y)
        {
            if (isDragging)
            {
                select.Drag(x - startX, y - startY);
                startX = x;
                startY = y;
            }
            else if (isSelecting)
            {
                select.Width = x - startX;
                select.Height = y - startY;
            }
            
            
        }

        public void ToolMouseUpAction(int x, int y)
        {
            select.SetSource(figureSource.Select(startX, startY, x - startX, y - startY));
            if (figureSource.Select(startX, startY, x - startX, y - startY) != null)
            {
                figureSource.InitSelector(select);
            }
            else
            {
                select.SetSource(null);
                select.isVisible = false;
            }
            startX = x;
            startY = y;
        }

        public void CopySelected()
        {
            
            Tools["paste"] = new OldGroup.GroupCreator(multiSelector);
            //throw new Exception();
        }


    }
}
