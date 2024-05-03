using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    public abstract class Shapes
    {
        private string _Name;

        public Shapes(string isId)
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

    }
    public abstract class Shape2D : Shapes
    {
       public Shape2D (string isId) : base(isId)
        {

        }
        public abstract double Area
        {
            get;
        }
        public abstract double Perimeter
        {
            get;
        }

        public override string ToString()
        {
            return $"{Id} Area = {Area:F2} and Perimeter = {Perimeter:F2}";
        }
    }
    public abstract class Shape3D : Shapes
    {
        public Shape3D(string isId) : base(isId)
        {

        }
        public abstract double Volume
        {
            get;
        }
        public abstract double SurfaceArea
        {
            get;
        }
        public abstract double Density
        {
            get;
        }

        public override string ToString()
        {
            return $"{Id} Volume = {Volume:F2} and Surface Area = {SurfaceArea:F2} And Density is = {Density:F2}";
        }
    }
    public class Rectangle2D : Shape2D
    {
        private int _Width;
        private int _Height;
        public Rectangle2D(int inWidth, int inHeight, string isId) :base(isId)
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
        public override double Perimeter
        {
            get
            {
                return 2 * (_Width + _Height);
            }
        }
    }
    public class Square2D : Shape2D
    {
        private int _Side;

        public Square2D(int inSide, string isId) : base(isId)
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
        public override double Perimeter
        {
            get
            {
                return 4 * _Side;
            }
        }
    }
    public class Circle2D : Shape2D
    {
        private int _Radius;

        public Circle2D(int inRadius, string isId) : base(isId)
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
        public override double Perimeter
        {
            get
            {
                return 2 * System.Math.PI * _Radius;
            }
        }
    }
    public class Cuboid : Shape3D
    {
        private int _Length;
        private int _Height;
        private int _breadth;
        private int _mass;
        public Cuboid(int inLength,int inBreadth, int inHeight,int inMass, string isId) : base(isId)
        {
            this._Length = inLength;
            this._breadth = inBreadth;
            this._Height = inHeight;
            this._mass = inMass;
        }
        public override double Volume
        {
            get
            {
                return _Length* _breadth * _Height;
            }
        }
        public override double SurfaceArea
        {
            get
            {
                return 2 * (_Length*_breadth + _breadth*_Height + _Length*_Height );
            }
        }
        public override double Density
        {
            get
            {
                return _mass / Volume;
            }
        }
    }
    public class Cube : Shape3D
    {
        private int _Side;
        private int _mass;

        public Cube(int inSide,int inMass, string isId) : base(isId)
        {
            this._Side = inSide;
            this._mass = inMass;

        }
        public override double Volume
        {
            get
            {
                return _Side * _Side* _Side;
            }
        }
        public override double SurfaceArea
        {
            get
            {
                return 6 * _Side * _Side;
            }
        }
        public override double Density
        {
            get
            {
                return _mass / Volume;
            }
        }
    }
    public class Sphere : Shape3D
    {
        private int _Radius;
        private int _mass;

        public Sphere(int inRadius, int inMass,string isId) : base(isId)
        {
            this._Radius = inRadius;
            this._mass = inMass;

        }
        public override double Volume
        {
            get
            {
                return (4*Math.Pow(3, _Radius)*System.Math.PI)/3;
            }
        }
        public override double SurfaceArea
        {
            get
            {
                return 4 * System.Math.PI * _Radius * _Radius;
            }
        }
        public override double Density
        {
            get
            {
                return _mass / Volume;
            }
        }
    }

}
