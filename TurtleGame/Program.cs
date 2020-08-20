using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace TurtleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            Turtle.PenUp(); //убираем след черепашки
            //начальные координаты
            int x = 200; 
            int y = 200;
            //создаем еду
            GraphicsWindow.BrushColor = "Blue"; //цвет
            var eat = Shapes.AddRectangle(10, 10); //инициализация "еды" и определение ее размеров
            Shapes.Move(eat, x, y); //двигаем по определенным координатам

            Random rand = new Random();

            while (true)
            {
                Turtle.Move(10);
                //если черепашка столкнется с едой, то 
                if (Turtle.X >= x && Turtle.X <= x + 10 && Turtle.Y >= y && Turtle.Y <= y + 10)
                {
                    //меняем координаты рандомно
                    x = rand.Next(0, GraphicsWindow.Width);
                    y = rand.Next(0, GraphicsWindow.Height);
                    Shapes.Move(eat, x, y); //переставляем "еду"
                    Turtle.Speed += 1; //увиличиваем скорость черепашки
                }
            }

        }
        //функция для изменения направления движения черепашки при нажатии клавиш
        static void GraphicsWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up")
            {
                Turtle.Angle = 0;
            }
            else if (GraphicsWindow.LastKey == "Right")
            {
                Turtle.Angle = 90;
            }
            else if (GraphicsWindow.LastKey == "Down")
            {
                Turtle.Angle = 180;
            }
            else if (GraphicsWindow.LastKey == "Left")
            {
                Turtle.Angle = 270;
            }
        }
    }
}
