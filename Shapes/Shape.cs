using System.Xml.Linq;

namespace MyLib
{

    interface IShape
    {
        string Name { get; }
        float Area { get; }
        float Radius_Big { get; }

        float GetRadiusFromArea();
        float GetAreaFromRadius();
    }


    public class Shape : IShape
    {
        public string Name { get; set; }

        private float radius_Big;
        public virtual float Radius_Big { get { return radius_Big; } private protected set { radius_Big = value; area = GetAreaFromRadius(); } }



        private float area;
        public float Area { get { return area; } private protected set { area = value; radius_Big = GetRadiusFromArea(); } }


        public Shape()
        {
            Name = "";
        }

        public Shape(string name)
        {
            Name = name;
        }


        public Shape(float radius) : this() { Radius_Big = radius; Area = GetAreaFromRadius(); }
        public Shape(string Name, float radius) : this(Name) { Radius_Big = radius; Area = GetAreaFromRadius(); }


        public virtual float GetRadiusFromArea() => (float)(Math.Sqrt(Area / Math.PI));

        public virtual float GetAreaFromRadius() => (float)(Math.PI * Math.Pow(Radius_Big, 2));


        public override string ToString() => $"Радиус = {Radius_Big}\nПлощадь = {Area}\nName = {Name}\n";
    }

    public class Circle : Shape, IShape
    {

        public Circle() { Radius_Big = 0; Area = 0; }
        public Circle(string Name) : base(Name) { Radius_Big = 0; Area = 0; }
        public Circle(float radius) : base(radius) { }
        public Circle(string Name, float radius) : base(Name, radius) { }

        //public override float GetAreaFromRadius() => (float)(Math.PI * Math.Pow(Radius_Big, 2));

        //public override float GetRadiusFromArea() => (float)(Math.Sqrt(Area / Math.PI));
        public static float GetRadius(float area) => (float)(Math.Sqrt(area / Math.PI));

        public static float GetArea(float radius) => (float)(Math.PI * Math.Pow(radius, 2));

        public override string ToString() => $"---(ОКРУЖНОСТЬ)---\nРадиус = {Radius_Big}\nПлощадь = {Area}\nName = {Name}";

    }

    public class Triangle : Shape, IShape
    {
        public float lenght_a { get; private set; } // Первая сторона
        public float lenght_b { get; private set; } // Вторая сторона
        public float lenght_c { get; private set; } // Третья сторона

        private float TriangleP; // Периметр треугольника
        public float _TriangleP { get { return TriangleP; } private set { TriangleP = value; triangle_p = TriangleP / 2; } }

        private float triangle_p; // Полупериметр треугольника
        public float _triangle_p { get { return triangle_p; } private set { triangle_p = value; TriangleP = triangle_p * 2; } }
        private float TriangleArea;
        public float triangleArea { get { return TriangleArea; } private set { TriangleArea = value; } }
        private float radius_Small;
        public float Radius_Small { get { return radius_Small; } private protected set { radius_Small = value; } }

        public bool triangleExists { get; private set; }
        public bool rightAngle { get; private set; }

        public Triangle() { }

        public Triangle(string name, float lenght_a, float lenght_b)
        {
            Name = name;
            this.lenght_a = Math.Abs(lenght_a);
            this.lenght_b = Math.Abs(lenght_b);
            lenght_c = (float)Math.Sqrt(Math.Pow(lenght_a, 2) + Math.Pow(lenght_b, 2));

            CalculateTriangle();

            triangleExists = true;
        }

        public Triangle(string name, float lenght_a, float lenght_b, float lenght_c)
        {
            Name = name;
            this.lenght_a = lenght_a;
            this.lenght_b = lenght_b;
            this.lenght_c = lenght_c;

            triangleExists = TriangleExists();

            if (triangleExists) CalculateTriangle();
        }

        private void CalculateTriangle()
        {
            _TriangleP = FindTriangleP();
            triangleArea = FirnTriangleArea();
            Radius_Big = FirnTriangleRadiusBig();
            Radius_Small = FirnTriangleRadiusSmall();
            rightAngle = RightAngle();
        }


        private bool TriangleExists()
        {
            if (lenght_a + lenght_b > lenght_c && lenght_a + lenght_c > lenght_b && lenght_b + lenght_c > lenght_a) 
                return true;
            else return false;
        }

        private bool RightAngle()
        {
            float biggest = lenght_a;
            if (biggest < lenght_b) biggest = lenght_b;
            if (biggest < lenght_c) biggest = lenght_c;

            if (biggest == lenght_a)
            {
                if (lenght_a == (float)Math.Sqrt(Math.Pow(lenght_b, 2) + Math.Pow(lenght_c, 2)))
                    return true;
                else return false;
            }
            else if (biggest == lenght_b)
            {
                if (lenght_b == (float)Math.Sqrt(Math.Pow(lenght_a, 2) + Math.Pow(lenght_c, 2)))
                    return true;
                else return false;
            }
            else if (biggest == lenght_c)
            {
                if (lenght_c == (float)Math.Sqrt(Math.Pow(lenght_a, 2) + Math.Pow(lenght_b, 2)))
                    return true;
                else return false;
            }
            return false;
        }

        public override string ToString()
        {
            if (triangleExists) return $"---(ТРЕУГОЛЬНИК)---\nСтороны a = {lenght_a} b = {lenght_b} c = {lenght_c}\np (Полупериметр) = {triangle_p}\nP (Периметр) = {TriangleP}\nS (Площадь треугольника) = {TriangleArea}\nРадиус вписанной окружности = {Radius_Small}\n" +
            $"Радиус описанной окружности = {Radius_Big}\nПлощадь = {Area}\nПрямоугольный треугольник = {(_ = rightAngle == true ? "Истина" : "Ложь")}\nName = {Name}";
            else return $"Треуголтника не существует, так как длины его сторон не образуют замкнутую фигуру\nСтороны: {lenght_a} {lenght_b} {lenght_c}";
        } 

        // Нахождение периметра треугольника
        private float FindTriangleP() => lenght_a + lenght_b + lenght_c; 
        // Нахождение площади треугольника
        private float FirnTriangleArea() => (float)Math.Sqrt(triangle_p * (triangle_p - lenght_a) * (triangle_p - lenght_b) * (triangle_p - lenght_c)); 
        // Нахождение описанной окружности треугольника
        private float FirnTriangleRadiusBig() => (lenght_a * lenght_b * lenght_c) / (4 * TriangleArea);
        // Нахождение вписанной окружности треугольника
        private float FirnTriangleRadiusSmall() => (TriangleArea / _triangle_p);

    }

}