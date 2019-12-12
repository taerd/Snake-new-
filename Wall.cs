using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Wall
    {
        private char _ch;
        private int _x;
        private int _y;
        private List<Point> _wall = new List<Point>();
        public Wall(int x,int y,char ch)
        {
            _ch = ch;
            _x = x;
            _y = y;
            DrawHorizontal(_x, 0);
            DrawVertical(0, _y);
            DrawHorizontal(_x, _y);
            DrawVertical(_x, _y);
        }

        private void DrawHorizontal(int x,int y)
        {
            for(int i = 0; i < x; i++)
            {
                Point p = new Point(i, y, _ch);
                p.Draw();
                _wall.Add(p);
            }
        }
        private void DrawVertical(int x,int y)
        {
            for (int i = 0; i < y; i++)
            {
                Point p = new Point(x, i, _ch);
                p.Draw();
                _wall.Add(p);
            }
        }
        public bool IsHit(Point p)
        {
            return (p.X == 0 || p.X == _x || p.Y == 0 || p.Y == _y);//проверим лишь контурные границы игрового поля. Для внутренних стен не годится
            
            /*//проверка по каждому элементу списка стен
            foreach (Point w in _wall)
            {
                if (w.Equals(p)) return true;
            }
            return false;
            */
        }
    }
}
