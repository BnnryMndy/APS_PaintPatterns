using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APS_PaintPatterns.UI;

namespace APS_PaintPatterns
{
    public partial class Form1 : Form
    {
        ToolsManager toolsManager = new ToolsManager();
        FigureRenderer renderer = new FigureRenderer();

        public Form1()
        {
            InitializeComponent();
            toolsManager.InitRenderer(renderer);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); //removing flickering
            SetStyle(ControlStyles.DoubleBuffer, true);
        }
        //TODO: вызывать здесь отрисовку
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            renderer.Draw(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            toolsManager.ToolMouseDownAction(e.X, e.Y);
            Refresh();
        }

        private void RectangleToolButton_Click(object sender, EventArgs e)
        {
            toolsManager.ToolSelect("rect");
        }

        private void EllipseToolButton_Click(object sender, EventArgs e)
        {
            toolsManager.ToolSelect("ellipse");
        }

        private void SelectToolButton_Click(object sender, EventArgs e)
        {
            toolsManager.ToolSelect("select");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            toolsManager.ToolMouseMoveAction(e.X, e.Y);
            Refresh();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            toolsManager.ToolMouseUpAction(e.X, e.Y);
            Refresh();
        }
    }
}
