using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Food
    {
        private int _x;
        private int _y;
        private char _ch;
        Random rand = new Random();
        public Point position;
        public Food(int x, int y, char ch) { _x=x; _y=y; _ch = ch; }
        public void CreateFood()
        {
            position = new Point(rand.Next(1, _x - 1), rand.Next(1, _y - 1), _ch);
            position.Draw();
        }
        
    }
}
