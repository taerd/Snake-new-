﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static Wall wall;
        static Food food;
        static Snake snake;
        static Timer time;
        static readonly int x = 40;
        static readonly int y = 14;
        static bool game;
        static int difficulty;
        static string [] lvl =  { "Slug  ","Worm  ","Cobra ","Python" };
        static ConsoleKeyInfo pressed;
        static void Main(string[] args)
        {
            Console.SetWindowSize(x + 40, y+2 );
            Console.SetBufferSize(x + 40, y +2);
            Console.CursorVisible = false;
            wall = new Wall(x, y, '#');

            snake = new Snake(x / 2, y / 2);

            food = new Food(x, y, '@',snake);
            food.CreateFood();

            Console.SetCursorPosition(x + 2, 1);
            Console.Write("To start - press something");
            Console.SetCursorPosition(x + 2, 3);
            Console.Write("Moving- Arrows, End- Escape");

            pressed = Console.ReadKey();
            game = true;

            difficulty = 0;

            Console.SetCursorPosition(x + 2, 5);
            Console.Write($"Lvl:{lvl[0]}");

            time = new Timer(Loop, null, 0, 200);

            while (game)
            {
                if (wall.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()) || pressed.Key==ConsoleKey.Escape) 
                {
                    game = false;
                    time.Change(0, Timeout.Infinite);
                }
                if (Console.KeyAvailable)
                {
                    pressed = Console.ReadKey();
                    snake.ChangeDirection(pressed.Key);
                }
            }
            time.Change(0,Timeout.Infinite);
            Console.SetCursorPosition(x+2, 7);
            Console.Write("Game over");
            Console.SetCursorPosition(x+2, 9);
            Console.Write($"Your score is : {snake.score}");
            Console.ReadKey();
        }
        static void Loop(object obj)
        {
            if(game)
            {
                if (wall.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()) || pressed.Key == ConsoleKey.Escape) 
                {
                    game = false;
                    time.Change(0, Timeout.Infinite);
                }
                if (food.position.Equals(snake.GetHead()))
                {
                    food.CreateFood();
                    snake.Add = true;
                    snake.score += 1;
                }
                if(difficulty < 3 && snake.score >= 5+5*difficulty)
                {
                    difficulty++;
                    time.Change(200 - difficulty * 40,200 - difficulty * 40);
                    Console.SetCursorPosition(x + 2, 5);
                    Console.Write($"Lvl:{lvl[difficulty]}");
                }
                snake.Move();
            }
            else time.Change(0, Timeout.Infinite);
        }
    }
}
