﻿using SecondHomework.ConcreteShape;

namespace SecondHomework.GeometricShapes
{
    public class Square : Shape
    {
        private double _side;
        public double Side
        {
            get { return _side; }
            set 
            {
                ValidateData(value); 
                _side = value; 
            }
        }
        public Square(double side)
        {
            Side = side;
            shape = new SquareShape(side);
        }
    }
}