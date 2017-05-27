using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic;
using System.Threading;

namespace дерево
{
    public class Draw
    {
        public Graphics graphics_obj;
        Controller controller;
        public Draw(Graphics graphics_obj)
        {
            this.graphics_obj = graphics_obj;
        }
        public void SetController(Controller controller)
        {
            this.controller = controller;
        }
        public void  DrawCircle(Point position, int radius)
        {
            //точка где будет вершина
           // string cst = Interaction.InputBox("введите стоймость пути");
       
            int x = position.X;
            int y = position.Y;
            int diameter = radius * 2;
            int diameter2 = (int)(diameter*1.5);
            Rectangle rectangle = new Rectangle(x - radius, y - radius, diameter2, diameter);//прямоугольник определяющий размер и раположение окружности 
            Pen pen = new Pen(Color.Green);
            //SolidBrush brush = new SolidBrush(Color.Green);
            graphics_obj.DrawEllipse(pen, rectangle);
            graphics_obj.FillEllipse(new SolidBrush(Color.Green),rectangle);
        }
        public void DrawLine(Point Position_from, Point position_to)
        {
            Pen pen = new Pen(Color.Green);
            AdjustableArrowCap bigarrow = new AdjustableArrowCap(4, 4);
            pen.CustomEndCap = bigarrow;
            graphics_obj.DrawLine(pen, Position_from,position_to);
        }
        public void DrawText(string text, int fontsize, Point position)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            Font font = new Font("Arial", fontsize);
            graphics_obj.DrawString(text, font, brush,position);
        }
    }
}
