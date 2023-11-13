using MyLib;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("");

        Circle circle = new Circle("Окружность", 4); // Создаём сущность круг с радиусом 4
        Console.WriteLine(circle + "\n"); // Выводим все параметры круга


        Triangle tris = new Triangle("tris", 4, 3); // Создаём треугольник по двум сторонам, третья сторона вычисляется сама
        Console.WriteLine(tris + "\n"); // Выводим все параметры труегольника

        Triangle trisTest = new Triangle("trisTest", 10, 7, 8); // Создаём треугольник по трём сторонам
        Console.WriteLine(trisTest + "\n"); // Выводим все параметры труегольника и проверяем, является ли он прямоугольным

        Triangle trisExist = new Triangle("trisExist", 10, 1, 1); // Создаём несуществующий треугольник
        Console.WriteLine(trisExist + "\n"); // Проверяем правильно ли программа определила существует ли он

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine($"Дан круг с радиусом 6, соответственно площадь круга будет равна {Circle.GetArea(6)}");
        Console.WriteLine($"Дан треугольник со сторонами {tris.lenght_a} {tris.lenght_b} {tris.lenght_c}, радиус описанной окружности = {tris.Radius_Big} и радиус вписанной окружности = {tris.Radius_Small}");
        Console.WriteLine($"Дан треугольник со сторонами {tris.lenght_a} {tris.lenght_b} {tris.lenght_c}, является ли данный треугольник прямоугольным? => {tris.rightAngle}");

        Console.ReadLine();

        
    }
}