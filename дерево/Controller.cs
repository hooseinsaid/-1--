using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
namespace дерево
{
    public class Controller
    {
        Draw draw;
        DynamicBST<int> MyTree;
        public List<Circles> MyCircles;
        public List<Lines> MyEdges;
        public List<Text> MyTexts;
        public List<Circles> Smallcircles;
        public List<Text> Smalltexts;
        public List<Lines> Smalllines;
        AVL<int> MyTree1;
        int treelevel;
        List<int> Tree;
        Form1 view;
        bool bst;
        public Controller(Form1 view, Draw draw,bool bst)
        {
            this.view = view;
            this.draw = draw;
            MyTree = new DynamicBST<int>();
            MyTree1 = new AVL<int>();
            MyCircles = new List<Circles>();
            MyEdges = new List<Lines>();
            MyTexts = new List<Text>();
            Smallcircles = new List<Circles>();
            Smalltexts = new List<Text>();
            Tree = new List<int>();
            treelevel = 0;
            Smalllines = new List<Lines>();
            this.bst = bst;
        }
        public void AddNode(int node_item, int direction)
        {
            
            //if (bst) direction = MyTree.AddNode(node_item);
            //else direction = MyTree1.AddNode(node_item);
            int radius = 16;
            Point position;
            Point position2;
            Circles circle;
            if (MyCircles.Count == 0)
            {
                Tree.Add(node_item);
                position = new Point(350, 30);
                position2 = new Point(350, 15);
                circle = new Circles(node_item, radius, position);
                MyCircles.Add(circle);
                circle = new Circles(node_item, radius/2, position2);
                Smallcircles.Add(circle);
                AddText(node_item, position, radius, 3);
                AddText(node_item, position2, radius / 2, 2);
            }
            else if(direction != 0)
            {
                 Tree.Add(node_item);
                 Point parentposition;
                 Point parentposition2;
                 parentposition = GetParentPosition(node_item, 3);
                 parentposition2 = GetParentPosition(node_item, 2);
                 int nodelevel = NodeLevel(node_item);
                 int offsetx = 120/(nodelevel-1);
                 int offsety = 100 - nodelevel * 4;
                 if (direction == 1)
                 {
                     position = new Point(parentposition.X + offsetx, parentposition.Y + offsety);
                     position2 = new Point(parentposition2.X + offsetx / 2, parentposition2.Y + offsety / 2);
                     circle = new Circles(node_item, radius, position);
                     MyCircles.Add(circle);
                     circle = new Circles(node_item, radius / 2, position2);
                     Smallcircles.Add(circle);
                     AddEdge(parentposition, position, radius, 3);
                     AddEdge(parentposition2, position2, radius/2, 2);
                     AddText(node_item, position, radius, 3);
                     AddText(node_item, position2, radius / 2, 2);
                 }
                 else if(direction == -1)
                 {
                     position = new Point(parentposition.X - offsetx, parentposition.Y + offsety);
                     position2 = new Point(parentposition2.X - offsetx / 2, parentposition2.Y + offsety / 2); 
                     circle = new Circles(node_item, radius, position);
                     MyCircles.Add(circle);
                     circle = new Circles(node_item, radius / 2, position2);
                     Smallcircles.Add(circle);
                     AddEdge(parentposition,position, radius,3);
                     AddEdge(parentposition2, position2, radius/2, 2);
                     AddText(node_item, position, radius, 3);
                     AddText(node_item, position2, radius / 2, 2);
                 }
            }

        }
        void ProccessRotations(int data)
        {
 
        }
        public void Tree_Insert(int Number)
        {
            if (bst) AddNode(Number, MyTree.AddNode(Number));
            else
            {
                BinTreeNodes<int> node = MyTree1.root;
                bool find = MyTree1.NodeExists(ref node, Number);
                if (find == false)
                {
                    int d = 0;
                    MyTree1.AddNode(Number);
                    int a = 0;
                    Insert_old();
                }
            }
        }
        private void Insert_old()
        {
            BinTreeNodes<int> copy_r = MyTree1.root;
            AVL<int> Temp = new AVL<int>();
            MyCircles = new List<Circles>();
            Smallcircles = new List<Circles>();
            MyTexts = new List<Text>();
            Smalltexts = new List<Text>();
            MyEdges = new List<Lines>();
            Smalllines = new List<Lines>();
            treelevel = 0;
            rec_add(Temp, copy_r);
        }

        private void rec_add(AVL<int>Temp, BinTreeNodes<int> copy_root)
        {
            int dir;
            if (copy_root != null)
            {
                dir = Temp.Tree_Copy(copy_root);
                AddNode(copy_root.data, dir);
                if (copy_root.left != null) rec_add(Temp, copy_root.left);
                if (copy_root.right != null) rec_add(Temp, copy_root.right);
            }
        }

        public void DeleteNode(int node)
        {
            MyCircles.Clear();
            MyEdges.Clear();
            MyTexts.Clear();
            Smallcircles.Clear();
            Smalllines.Clear();
            Smalltexts.Clear();
            treelevel = 0;
            MyTree1 = new AVL<int>();
            MyTree = new DynamicBST<int>();
            int[] tree = Tree.ToArray();
            Tree.Clear();
            for (int i = 0; i < tree.Length; i++)
            {
                if(tree.ElementAt(i) != node)Tree_Insert(tree.ElementAt(i));
            }
        }
        public int NodeLevel(int childnode)
        {
            BinTreeNodes<int> testnode = new BinTreeNodes<int>();
            bool check = false;
            if (bst) check = MyTree.NodeExists(ref testnode, childnode);
            else check = MyTree1.NodeExists(ref testnode, childnode);
            int k = 0;
            while (testnode != null)
            {
                testnode = testnode.parent;
                k++;
            }
            if (k > treelevel) treelevel = k;
            return k;
        }
        public void TreeLevel()
        {
            BinTreeNodes<int> testnode = null;
            if (bst) testnode = MyTree.root;
            else testnode = MyTree1.root;
            int k = 0;
            while (testnode != null)
            {
                testnode = testnode.parent;
                k++;
            }
            //treelevel = k;

        }
        public void UpdateView()
        {
            draw.graphics_obj.Clear(Color.White);
            for (int i = 0; i < MyCircles.Count; i++)
            {
                //draw.Updateobj();
                if (treelevel > 4)draw.DrawCircle(Smallcircles.ElementAt(i).position, Smallcircles.ElementAt(i).radius);
                else draw.DrawCircle(MyCircles.ElementAt(i).position, MyCircles.ElementAt(i).radius);
            }
            for (int i = 0; i < MyEdges.Count; i++)
            {
                if (treelevel > 4) draw.DrawLine(Smalllines.ElementAt(i).position_from, Smalllines.ElementAt(i).position_to);
                else draw.DrawLine(MyEdges.ElementAt(i).position_from, MyEdges.ElementAt(i).position_to);
            }
            for (int i = 0; i < MyTexts.Count; i++)
            {
                if(treelevel > 4 )draw.DrawText(Smalltexts.ElementAt(i).textstring, Smalltexts.ElementAt(i).fontsize, Smalltexts.ElementAt(i).textposition);
                else draw.DrawText(MyTexts.ElementAt(i).textstring, MyTexts.ElementAt(i).fontsize, MyTexts.ElementAt(i).textposition);
            }
        }
        Point GetParentPosition(int childnode, int circlesize)
        {
            BinTreeNodes<int> testnode = new BinTreeNodes<int>();
            int parentdata = 0;
            BinTree<int> tree = null;
            if (bst) tree = MyTree;
            else tree = MyTree1;
            Point parentposition = new Point(0,0);
            bool check = false;
            if (bst) check = MyTree.NodeExists(ref testnode, childnode);
            else check = MyTree1.NodeExists(ref testnode, childnode);
            if (check && testnode != tree.root)
            {
                parentdata = testnode.parent.data;
                for (int i = 0; i < MyCircles.Count; i++)
                {
                    if (MyCircles.ElementAt(i).circlenumber == parentdata)
                    {
                        if (circlesize == 3) parentposition = MyCircles.ElementAt(i).position;
                        else if (circlesize == 2) parentposition = Smallcircles.ElementAt(i).position;
                    }
                }
            }
            return parentposition;
        }
        public void AddEdge(Point parentposition, Point childposition, int radius, int size)
        {
            Point point_from = parentposition;
            Point point_to = childposition;
            GetPoints(ref point_from, ref point_to, radius);
            Lines edge = new Lines(point_from, point_to);
            if (size == 3) MyEdges.Add(edge);
            else if (size == 2) Smalllines.Add(edge);
        }
        public void AddText(int node_item, Point position, int radius, int size)
        {
            int textfont = 13;
            string textstring = node_item.ToString();
            Text text = new Text(textstring,position, textfont, radius);
            if (size == 3) MyTexts.Add(text);
            else if (size == 2)
            {
                text = new Text(textstring, position, textfont / 2, radius);
                Smalltexts.Add(text);
            }
        }
        /// <summary>
        /// проверка на попадание точка в нужное место
        /// </summary>
        /// <param name="position">точка вершины</param>
        /// <param name="gap">радиус для проверки попадания</param>
        /// <returns>истинна если попала и ложь если не попала</returns>
        public bool PointCoincidence(ref Point position, int gap)
        {
            bool Res = false;
            for (int i = 0; i < MyCircles.Count; i++)
            {
                if ((MyCircles.ElementAt(i).position.X >= position.X - gap && MyCircles.ElementAt(i).position.X <= position.X + gap) &&
                    (MyCircles.ElementAt(i).position.Y >= position.Y - gap && MyCircles.ElementAt(i).position.Y <= position.Y + gap))//проверка на попадание
                {
                    position = MyCircles.ElementAt(i).position;
                    Res = true;
                    break;
                }
            }
            return Res;
        }
        /// <summary>
        /// проверка на существование ребра
        /// </summary>
        /// <param name="point1">первая вершина</param>
        /// <param name="point2">вторая вершина</param>
        /// <param name="MyEdges">список храняющий ребер</param>
        /// <returns>истинна или ложь</returns>
        /*public bool EdgeExist(Point point1, Point point2)
        {
            bool Found = false;
            for (int i = 0; i < MyEdges.Count; i++)
            {
                Circles Circle1 = MyCircles.ElementAt(MyEdges.ElementAt(i).circle_from + 1);
                Circles Cirle2 = MyCircles.ElementAt(MyEdges.ElementAt(i).circle_to + 1);

                if (point1 == Circle1.position && point2 == Cirle2.position)//проверка на существование ребра
                {
                    Found = true;
                    return Found;
                }
            }
            return Found;
        }*/
        /// <summary>
        /// определение точек расположение концов ребра на вершине
        /// с помощью уравнения прямой и градиент прямой
        /// </summary>
        /// <param name="point1">первая точка</param>
        /// <param name="point2">вторая точка</param>
        /// <param name="rad">радиус вершины</param>
        public void GetPoints(ref Point point1, ref Point point2, int rad)
        {
            int x1 = point1.X;//точки вершин
            int y1 = point1.Y;
            int x2 = point2.X;
            int y2 = point2.Y;
            double G = 0;
            if (x1 == x2) G = rad;
            else G = (double)(y2 - y1) / (double)(x2 - x1);// G-градиент ребра
            if ((x1 > x2 || y1 > y2) && G > 0) G = -G;// отрицательное G
            double newx1 = 0, newx2 = 0, newy1 = 0, newy2 = 0;// новые точки
            double function = 0;
            if (x1 != x2)
            {
                function = Math.Sqrt((rad * rad) / (Math.Pow(G, 2) + 1));
                if (G <= 0) function = -function;
            }
            if (x2 > x1 && y1 > y2) function = -function;
            newx1 = function + x1;
            if (y2 == y1 && x2 > x1) newx1 = x1 - function;
            newx2 = x2 - function;
            if (y2 == y1 && x2 > x1) newx2 = x2 + function;
            if (x1 != x2)
            {
                if (x2 > x1 && y1 > y2 || y2 > y1) newy1 = G * (newx1 - x1) + y1;
                else newy1 = -G * (newx1 - x1) + y1;
                if (x2 > x1 && y1 > y2 || y2 > y1) newy2 = G * (newx2 - x2) + y2;
                else newy2 = -G * (newx2 - x2) + y2;
            }
            else
            {
                newy1 = G + y1;
                newy2 = y2 - G;
            }
            point1 = new Point(Convert.ToInt32(newx1), Convert.ToInt32(newy1));//новые точки
            point2 = new Point(Convert.ToInt32(newx2), Convert.ToInt32(newy2));
        }
    }
}
