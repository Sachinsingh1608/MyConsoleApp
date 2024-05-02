
namespace MyConsoleApp
{
    public abstract class Shape
    {
        private string _Name;

        public Shape(string isId)
        {
            Id = isId;
        }
        
        public string Id
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public abstract double Area
        {
            get;
        }
        public override string ToString()
        {
            return  $"{Id} Area = {Area:F2}";
        }
    }
    public class Rectangle : Shape
    {
        private int _Width;
        private int _Height;
        public Rectangle(int inWidth,int inHeight, string isId):base(isId)
        {
            this._Width = inWidth;
            this._Height = inHeight;
        }
        public override double Area
        {
            get
            {
                return _Width * _Height;
            }
        }
    }
    public class Square : Shape
    {
        private int _Side;
       
        public Square(int inSide, string isId) : base(isId)
        {
            this._Side = inSide;
         
        }
        public override double Area
        {
            get
            {
                return _Side * _Side;
            }
        }
    }
    public class Circle : Shape
    {
        private int _Radius;

        public Circle(int inRadius, string isId) : base(isId)
        {
            this._Radius = inRadius;

        }
        public override double Area
        {
            get
            {
                return System.Math.PI * _Radius * _Radius;
            }
        }
    }
}