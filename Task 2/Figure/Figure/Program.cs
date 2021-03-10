using System;
using System.Collections.Generic;
using System.Linq;
using LibraryStringCharTask;

namespace Figure
{
    class Program
    {
        static void Main(string[] args)
        {

            Cons c = new Cons();

            CustomChar customChar = new CustomChar(10);

        }
    }
    class Cons
    {
        public Cons()
        {
            double x, y, radius, wight, height, x1, y1, radiusOutSide;
            var figure = new List<Figure>();
            string newLine = Environment.NewLine;
            bool exit = false;
            
            Console.Write("Как мне к вам обращаться?  ");
            string Name = TestName.Name();//свой метод проверки имени на пустоту
            while (!exit)
            {
                Console.WriteLine($"{Name} выберите действие ");
                Console.WriteLine("1.Добавить фигуру" + newLine + "2.Вывести фигуры"
                                                      + newLine + "3.Очистить холст"
                                                      + newLine + "4.Выход"
                                                      + newLine + "5.Сменить пользователя");

                string TypeFigure = Console.ReadLine();
                switch (TypeFigure)
                {
                    case "1":
                        Console.WriteLine("Доступные фигуры к созданию:" + newLine + "1: Круг  ||  2: Окружность   ||  3: Квадрат ||  4: Прямоугольник   ||  5: Линия   ||  6: Кольцо");
                        Console.Write("Выберите тип фигуры: ");
                        string inputShape = Console.ReadLine();
                        switch (inputShape)
                        {



                            case "Круг":
                            case "круг":
                            case "1":
                                Console.WriteLine($"{Name} введите параметры фигуры Круг :");

                                Console.Write("Введите координаты по оси X :");

                                while (!double.TryParse(Console.ReadLine(), out x));

                                Console.Write("Введите координаты по оси Y :");

                                while (!double.TryParse(Console.ReadLine(), out y));

                                Console.Write("Введите радиус:");

                                while (!double.TryParse(Console.ReadLine(), out radius));

                                figure.Add(new Circle(x, y, radius));

                                Console.WriteLine("Удачно!");
                                break;


                            case "Окружность":
                            case "окружность":
                            case "2":
                                Console.WriteLine($"{Name} введите параметры фигуры окружность :");

                                Console.Write("Введите координаты по оси X :");

                                while (!double.TryParse(Console.ReadLine(), out x));

                                Console.Write("Введите координаты по оси Y :");

                                while (!double.TryParse(Console.ReadLine(), out y));

                                Console.Write("Введите радиус:");

                                while (!double.TryParse(Console.ReadLine(), out radius));

                                figure.Add(new Сircumference(x, y, radius));

                                Console.WriteLine("Удачно!");
                                break;



                            case "квадрат":
                            case "Квадрат":
                            case "3":
                                Console.WriteLine($"{Name} введите параметры фигуры Квадрат :");

                                Console.Write("Введите координаты по оси X :");

                                while (!double.TryParse(Console.ReadLine(), out x));

                                Console.Write("Введите координаты по оси Y :");

                                while (!double.TryParse(Console.ReadLine(), out y));

                                Console.Write("Введите длину стороны:");

                                while (!double.TryParse(Console.ReadLine(), out wight));

                                figure.Add(new Square(x, y, wight));

                                Console.WriteLine("Удачно!");
                                break;



                            case "прямоугольник":
                            case "Прямоугольник":
                            case "4":
                                Console.WriteLine($"{Name} введите параметры фигуры прямоугольникa :");

                                Console.Write("Введите координаты по оси X :");

                                while (!double.TryParse(Console.ReadLine(), out x)) ;

                                Console.Write("Введите координаты по оси Y :");

                                while (!double.TryParse(Console.ReadLine(), out y)) ;

                                Console.Write("Введите ширину:");

                                while (!double.TryParse(Console.ReadLine(), out wight)) ;

                                Console.Write("Введите высоту:");

                                while (!double.TryParse(Console.ReadLine(), out height)) ;

                                figure.Add(new Rectangle(x, y, wight, height));

                                Console.WriteLine("Удачно!");
                                break;



                            case "Линия":
                            case "линия":
                            case "5":
                                Console.WriteLine($"{Name} введите параметры Линии :");

                                Console.Write("Введите координаты по оси X первой точки:");

                                while (!double.TryParse(Console.ReadLine(), out x)) ;

                                Console.Write("Введите координаты по оси Y первой точки:");

                                while (!double.TryParse(Console.ReadLine(), out y)) ;

                                Console.Write("Введите координаты по оси X второй точки:");

                                while (!double.TryParse(Console.ReadLine(), out x1)) ;

                                Console.Write("Введите координаты по оси Y второй точки:");

                                while (!double.TryParse(Console.ReadLine(), out y1)) ;

                                figure.Add(new Line(x, y, x1, y1));

                                Console.WriteLine("Удачно!");
                                break;



                            case "Кольцо":
                            case "кольцо":
                            case "6":
                                Console.WriteLine($"{Name} введите параметры Кольца :");

                                Console.Write("Введите координаты по оси X первой точки:");

                                while (!double.TryParse(Console.ReadLine(), out x)) ;

                                Console.Write("Введите координаты по оси Y первой точки:");

                                while (!double.TryParse(Console.ReadLine(), out y)) ;

                                Console.Write("Введите введите внешний радиус");

                                while (!double.TryParse(Console.ReadLine(), out radius)) ;

                                Console.Write("Введите введите внутренний радиус:");

                                while (!double.TryParse(Console.ReadLine(), out radiusOutSide)) ;

                                figure.Add(new Ring(x, y, radius, radiusOutSide));

                                Console.WriteLine("Удачно!");
                                break;


                            default:
                                Console.WriteLine("Ввод невалиден.");
                                break;
                        }

                        break;
                    case "2":
                        if (figure.Count > 0)
                        {

                            foreach (var item in figure)
                            {

                                Console.WriteLine(item.ToString());
                            };
                        }
                        break;


                    case "3":
                        figure.Clear();
                        Console.WriteLine($"{Name}, вы удалили все фигуры.");
                        break;


                    case "4":
                        exit = true;
                        break;


                    case "5":
                        Name = TestName.Name();
                        break;
                }
            }

        }
    }
    public static class TestName
    {
        public static string Name()
        {
            bool nullName = true;
            string Name = "";
            while (nullName)
            {
                Name = Console.ReadLine();
                if (!String.IsNullOrEmpty(Name))
                {
                    nullName = false;
                }
            }
            return Name;

        }
    }



    public abstract class Figure
    {
        protected double x, y;

        public Figure(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract double SidesLength();

    }


    public class Line : Figure
    {
        public double x1;
        public double y1;
        public double sidesLength { get; set; }

        public Line(double x, double y, double x1, double y1)
            : base(x, y)
        {
            this.x1 = x1;
            this.y1 = y1;
            sidesLength = SidesLength();
        }

        public override double SidesLength()
        {
            return Math.Sqrt(Math.Pow((x1 - x), 2) + Math.Pow((y1 - y), 2));
        }
        public override string ToString()
        {
            return $"Линия: Длина линии: {sidesLength}.";
        }

    }



    public class Square : Figure
    {
        public double height;
        public double width;
        public double area;
        public double sidesLength;

        public Square(double x, double y, double widht)
            : base(x, y)
        {
            this.height = width;
            this.width = widht;
            area = Area();
            sidesLength = SidesLength();

        }


        public override double SidesLength()
        {
            return width * 4;
        }
        public virtual double Area()
        {
            return width * width;
        }
        public override string ToString()
        {
            return ($"Квадрат: Длина сторон: {sidesLength}  Площадь: {area}");
        }

    }



    public class Rectangle : Square
    {
        public Rectangle(double x, double y, double widht, double height)
            : base(x, y, widht)
        {
            this.height = height;
            this.width = widht;
            area = Area();
            sidesLength = SidesLength();
        }

        public override double SidesLength()
        {
            return (width + height) * 2;
        }
        public override string ToString()
        {
            return ($"Прямоугольник: Длина линии: {sidesLength} Площадь:  {area}.");
        }
    }



    public class Сircumference : Figure
    {
        public const double pi = Math.PI;
        public double radius;
        public double siderLenght;
        public Сircumference(double x, double y, double radius)
        : base(x, y)
        {
            this.radius = radius;
            siderLenght = SidesLength();
        }

        public override double SidesLength()
        {
            return pi * radius * 2;
        }
        public override string ToString()
        {
            return ($"Окружность: Радиус: {radius}   Cумма сторон {siderLenght}");
        }


    }



    public class Circle : Сircumference
    {
        public double sidelenght;
        public double area;
        public Circle(double x, double y, double radius)
        : base(x, y, radius)
        {
            this.radius = radius;
            sidelenght = SidesLength();
            area = Area();
        }

        public virtual double Area()
        {
            return pi * radius * radius;
        }
        public override double SidesLength()
        {
            return pi * radius * 2;
        }
        public override string ToString()
        {
            return ($"Круг: Радиус: {radius}  Площадь: {area} Cумма сторон {sidelenght}");
        }
    }



    public class Ring : Сircumference
    {
        public double area;
        public double outSideRadius;

        public Ring(double x, double y, double radius, double outSideRadius)
        : base(x, y, radius)
        {
            this.outSideRadius = outSideRadius;
            if (outSideRadius < radius)
            {
                object a = outSideRadius;
                outSideRadius = radius;
                radius = (double)a;
            }
            area = Area();
        }

        public virtual double Area()
        {
            return pi * (outSideRadius * outSideRadius - radius * radius);
        }
        public override double SidesLength()
        {
            return pi * outSideRadius * 2;
        }
        public double InsideSidesLength()
        {
            return pi * radius * 2;
        }
        public override string ToString()
        {
            return $"Кольцо: Длина внешней окружности: {outSideRadius}  Длина внутренней окружности: {radius} Площадь: {area}.";
        }
    }

}
