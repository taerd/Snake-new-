using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Snake
    {
        private List<Point> _snake;
        public enum Direction { UP,RIGHT,DOWN,LEFT}
        public Direction direction;
        private Point _newhead;
        private Point _tail;
        public bool Add { get; set; }
        public int score { get; set; }
        public Snake(int x,int y)
        {
            Point p = new Point(x, y, '*');
            _snake = new List<Point>();
            _snake.Add(p);
            p.Draw();
            direction = Direction.RIGHT;
            Add = false;
            score = 1;
        }
        public Point GetHead()
        {
            return _snake.FindLast(
                delegate(Point p) 
                {
                    return (p != null);
                }
                );
            //return _snake.Last();//какая то ошибка с индексами
        }
        public bool IsHit(Point head)
        {
            for(int i = _snake.Count - 2; i > 0; i--)
            {
                if (_snake[i].Equals(head)) return true;
            }
            return false;
        }
        public void ChangeDirection(ConsoleKey pressed)//добавить управление мышью
        {
            switch (pressed)
            {
                case ConsoleKey.UpArrow:
                    if (direction == Direction.DOWN) break;
                    else
                    {
                        direction = Direction.UP;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    if (direction == Direction.LEFT) break;
                    else
                    {
                        direction = Direction.RIGHT;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    if (direction == Direction.UP) break;
                    else
                    {
                        direction = Direction.DOWN;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    if (direction == Direction.RIGHT) break;
                    else
                    {
                        direction = Direction.LEFT;
                        break;
                    }
                default:
                    break;
            }
        }
        public void Move()
        {
            switch (direction)
            {
                case Direction.UP:
                    ReDraw(0, -1);
                    break;
                case Direction.RIGHT:
                    ReDraw(1, 0);
                    break;
                case Direction.DOWN:
                    ReDraw(0, 1);
                    break;
                case Direction.LEFT:
                    ReDraw(-1, 0);
                    break;
                default:
                    break;
            }
        }
        public void ReDraw(int x,int y)
        {
            GetNextPoint(x, y);
            _snake.Add(_newhead);
            if (!Add)
            {
                _tail = _snake.First();
                _tail.Clear();
                _snake.Remove(_tail);
            }
            _newhead.Draw();
            Add = false;
        }
        public Point GetNextPoint(int x,int y)
        {
            return _newhead = new Point(_snake.Last().X+x, _snake.Last().Y+y, '*');
        }
    }
}
