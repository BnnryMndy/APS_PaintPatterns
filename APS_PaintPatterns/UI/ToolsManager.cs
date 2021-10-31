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

        private Group.GroupCreator paste = new Group.GroupCreator();
        private SelectorFigure select = new SelectorFigure();
        private Group multiSelector = new Group();
        private DragableFigure currentSelector; // TODO: сделать элегантно 
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
            renderer.InitSelector(currentSelector);
        }

        public void ToolSelect(string toolName)
        {
            selectedTool = Tools[toolName];
            if (toolName != "select")
            {
                //select.SetSource(null);
                multiSelector.Hide();
            }
        }

        public void ToolMouseDownAction(int x, int y)
        {
            //if (selectedTool) throw new Exception();
            if (selectedTool == null) // выбран select  
            {
                bool isAlreadySelected = select.Touch(x, y);
                if (!isAlreadySelected)
                {
                    select.SetSource(figureSource.Select(x, y));
                    if (figureSource.Select(x, y) != null)
                    {
                        currentSelector = select;
                        figureSource.InitSelector(select);
                    }
                }
                else
                {

                    isDragging = true;
                    startX = x;
                    startY = y;
                    return;
                }

                if (!multiSelector.Touch(x, y))
                {
                    multiSelector.setStartPosition(x, y);
                    currentSelector = multiSelector;
                    figureSource.InitSelector(multiSelector);
                    isSelecting = true;
                    return;
                }
                else
                {
                    isDragging = true;
                    startX = x;
                    startY = y;
                    return;
                }

            }
            else
            {
                Figure figure = selectedTool.Create(x - 25, y - 25, 50, 50, Color.Black, Color.Transparent);
                
                if (selectedTool == Tools["paste"])
                {
                    Group figures = (Group)figure;
                    foreach (Figure figure1 in figures.SelectedFiguries)
                    {
                        figureSource.Add(figure1);
                    }
                }
                else
                {
                    figureSource.Add(figure);
                }
                
                
            }
                
        }

        public void ToolMouseMoveAction(int x, int y)
        {
            if (isDragging)
            {
                currentSelector.Drag(x - startX, y - startY);
                startX = x;
                startY = y;
            }
            if (currentSelector == multiSelector && isSelecting)
            {
                multiSelector.setEndPosition(x, y);
            }
            
        }

        public void ToolMouseUpAction(int x, int y)
        {
            isDragging = false;
            if(multiSelector == currentSelector && isSelecting)
            {
                isSelecting = false;
                multiSelector.SelectedFiguries = figureSource.SelectMany(multiSelector.X, multiSelector.Y, multiSelector.Width, multiSelector.Height);
            }
        }

        public void CopySelected()
        {
            
            Tools["paste"] = new Group.GroupCreator(multiSelector);
            //throw new Exception();
        }

        //public void Paste(int x, int y)

    }
}
