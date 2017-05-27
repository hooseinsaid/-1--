using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace дерево
{
    public class Circles
    {
        public int circlenumber;
        public int radius;
        public Point position;
        public Circles(int circlenumber,int radius, Point position)
        {
            this.circlenumber = circlenumber;
            this.radius = radius;
            this.position = position;
        }
    }
    public class Lines
    {
        //public int linenumber;
       // public int circle_from;
        public int circle_to;
        public Point position_from;
        public Point position_to;
        public Lines(Point position_from, Point position_to)
        {
            this.position_from = position_from;
            this.position_to = position_to;
        }

    }
    public class Text
    {
        public string textstring;
        public Point textposition;
        public int fontsize;
        int radius;
        public Text(string textstring, Point textposition, int fontsize, int radius)
        {
            this.textstring = textstring;
            this.textposition = textposition;
            this.fontsize = fontsize;
            this.radius = radius;
            ModifyText();
        }
        void ModifyText()
        {
            int offsetx = 0;
            int offsety = (int)2 * radius / 3;
            if (textstring.Length == 1) { }
            else if (textstring.Length == 2)
            {
                 offsetx = (int)2.5 * radius / 5;                     
            }
            else if (textstring.Length == 3)
            {
                offsetx = (int)3 * radius / 5;
            }
            else 
            {
                offsetx = radius;
            }
            textposition = new Point(textposition.X - offsetx, textposition.Y - offsety);
        }
    }
}
