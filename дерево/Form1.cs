using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace дерево
{
    public partial class Form1 : Form
    {
        Controller controller;
        DynamicBST<int> bst;
        Draw draw;
        Graphics graphicsobj;
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            graphicsobj = tabPage1.CreateGraphics();
            draw = new Draw(graphicsobj);
            bool bst = radioButtonBST.Checked;
            controller = new Controller(this, draw,bst);
        }
        protected override void OnPaint(PaintEventArgs paintEvnt)
        {
            graphicsobj.Clear(Color.White);
            controller.UpdateView();
        }
        public void SetController(Controller controller)
        {
            this.controller = controller;
        }
        private void buttAddNode_Click(object sender, EventArgs e)
        {
            int node_item = int.Parse(textBoxItem.Text);
            controller.Tree_Insert(node_item);
            Invalidate();
            
        }

        private void buttDeleteNode_Click(object sender, EventArgs e)
        {
            int node_item = int.Parse(textBoxItem.Text);
            controller.DeleteNode(node_item);
            //buffer.Dispose();
            Invalidate();
            
        }

        private void buttSearchNode_Click(object sender, EventArgs e)
        {

        }
    }
}
