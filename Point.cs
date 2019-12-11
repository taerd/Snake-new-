using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Point : IEquatable<Point>
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char CH { get; private set; }

        public Point(int x, int y, char ch) 
        {
            X = x;
            Y = y;
            CH = ch;
        }
        public void Draw()
        {
            DrawSymbol(CH);
        }
        public void Clear()
        {
            DrawSymbol(' ');
        }
        public void DrawSymbol(char ch)
        {
            
            Console.SetCursorPosition(X, Y);
            Console.Write(ch);
        }

        public bool Equals(Point other)
        {
            return X==other.X && Y==other.Y;
        }
    }
}
