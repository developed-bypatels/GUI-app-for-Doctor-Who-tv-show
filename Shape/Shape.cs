using System;
namespace Shape
{
    public abstract class Shape
    {
        public string Type { get; protected set; }         //The type of shape
        private static int count = 0;                      //Number of instantiated shapes
        protected const double PI = 3.141592653589793;     //Constant value for pi

        //All this constructor does is increment the number of Shape instances
        public Shape()
        {
            count++;
        }

        public abstract double CalculateArea();            //Calculate the Shape's area (surface area if 3-d)
        public abstract double CalculateVolume();          //Calculate the Shape's volume (if 3-d)5465
        public abstract void SetData();                    //Prompts the user for dimensions
        public override string ToString() => "";           //Used for printing Shape data

        //Retrieves the current number of Shape instances
        public static int GetCount()
        {
            return count;
        }
    }

    class Rectangle : Shape
    {
        private float rectangleLength;
        private float rectangleWidth;
        private float rectangleArea;
        bool inputData = false;

        public Rectangle(string typeofShape)                // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }
        public override void SetData()                      // prompts user for input
        {

            while (!inputData)                              // loops until the data entred is not true
            {
                Console.Write("\nEnter the length : ");

                if (!float.TryParse(Console.ReadLine(), out rectangleLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }
                Console.Write("\nEnter the width : ");
                if (!float.TryParse(Console.ReadLine(), out rectangleWidth))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;
                }
                else
                {
                    inputData = true;
                }
            }
        }
        public override double CalculateArea()                              // Calculates the area of the shape
        {
            rectangleArea = rectangleLength * rectangleWidth;
            return rectangleArea;
        }

        public override double CalculateVolume()                            // returns "0" for volume
        {
            return Convert.ToDouble(0);
        }

        public override string ToString()
        {
            return rectangleLength + " l x " + rectangleWidth + "w";
        }
    }

    class Square : Shape
    {
        private float squareLength;
        private float squareArea;
        bool inputData = false;

        public Square(string typeofShape)                   // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }

        public override void SetData()                      // prompts user for input
        {

            while (!inputData)                              // loops until the data entred is not true
            {
                Console.Write("\nEnter the length : ");

                if (!float.TryParse(Console.ReadLine(), out squareLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }
            }
        }
        public override double CalculateArea()                  // Calculates area for the shape
        {
            squareArea = squareLength * squareLength;
            return squareArea;
        }

        public override double CalculateVolume()                // returns 0 
        {
            return Convert.ToDouble(0);
        }

        public override string ToString()
        {
            return squareLength + " l";
        }
    }

    class Box : Shape
    {
        private float boxLength;
        private float boxWidth;
        private float boxHeight;
        private float boxArea;
        private float boxVolume;
        bool inputData = false;

        public Box(string typeofShape)                      // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }

        public override void SetData()                      // prompts user for input
        {

            while (!inputData)                              // loops until the data entred is not true
            {
                Console.Write("\nEnter the length : ");

                if (!float.TryParse(Console.ReadLine(), out boxLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }

                Console.Write("\nEnter the width : ");
                if (!float.TryParse(Console.ReadLine(), out boxWidth))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;
                }
                else
                {
                    inputData = true;
                }

                Console.Write("\nEnter the height : ");
                if (!float.TryParse(Console.ReadLine(), out boxHeight))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;
                }
                else
                {
                    inputData = true;
                }

            }
        }

        public override double CalculateArea()
        {
            boxArea = 2 * (boxLength * boxWidth + boxLength * boxHeight + boxWidth * boxHeight);
            return boxArea;

        }

        public override double CalculateVolume()
        {
            boxVolume = boxLength * boxWidth * boxHeight;
            return boxVolume;
        }

        public override string ToString()
        {
            return boxLength + " l x " + boxWidth + " w x " + boxHeight + " h ";
        }


    }

    class Cube : Shape
    {
        private float cubeLength;
        private float cubeArea;
        private float cubeVolume;
        bool inputData = false;

        public Cube(string typeofShape)                   // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }

        public override void SetData()                  // prompts user for input
        {
            while (!inputData)                          // loops unitl data is not true
            {
                Console.Write("\nEnter the length : ");

                if (!float.TryParse(Console.ReadLine(), out cubeLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }

            }
        }
        public override double CalculateArea()
        {
            cubeArea = 6 * (cubeLength * cubeLength);
            return cubeArea;
        }

        public override double CalculateVolume()
        {
            cubeVolume = cubeLength * cubeLength * cubeLength;
            return cubeVolume;
        }

        public override string ToString()
        {
            return cubeLength + " l";
        }
    }

    class Ellipse : Shape
    {
        private float majorLength;
        private float minorLength;
        private float ellipseArea;
        bool inputData = false;

        public Ellipse(string typeofShape)                   // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }

        public override void SetData()                      // prompts user for input
        {

            while (!inputData)                              // loops until the data entred is not true
            {
                Console.Write("\nEnter the semi-major : ");

                if (!float.TryParse(Console.ReadLine(), out majorLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }

                Console.Write("\nEnter the semi-minor : ");
                if (!float.TryParse(Console.ReadLine(), out minorLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }

            }
        }
        public override double CalculateArea()
        {
            ellipseArea = (float)PI * majorLength * minorLength;
            return ellipseArea;
        }

        public override double CalculateVolume()
        {
            return Convert.ToDouble(0);
        }

        public override string ToString()
        {
            return majorLength + " s.major x " + minorLength + " s.minor";
        }
    }

    class Circle : Shape
    {
        private float radiusLength;
        private float circleArea;
        bool inputData = false;

        public Circle(string typeofShape)                   // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }

        public override void SetData()                      // prompts user for input
        {

            while (!inputData)                              // loops until the data entred is not true
            {
                Console.Write("\nEnter the radius : ");

                if (!float.TryParse(Console.ReadLine(), out radiusLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }


            }
        }
        public override double CalculateArea()
        {
            circleArea = (float)PI * radiusLength * radiusLength;
            return circleArea;
        }

        public override double CalculateVolume()
        {
            return Convert.ToDouble(0);
        }

        public override string ToString()
        {
            return radiusLength + " r";
        }
    }

    class Cylinder : Shape
    {
        private float radiusLength;
        private float heightLength;
        private float cylinderArea;
        private float cylinderVolume;
        bool inputData = false;

        public Cylinder(string typeofShape)                   // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }

        public override void SetData()                      // prompts user for input
        {

            while (!inputData)                              // loops until the data entred is not true
            {
                Console.Write("\nEnter the radius : ");

                if (!float.TryParse(Console.ReadLine(), out radiusLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }

                Console.Write("\nEnter the height : ");

                if (!float.TryParse(Console.ReadLine(), out heightLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }
            }
        }
        public override double CalculateArea()
        {
            cylinderArea = (2 * (float)PI * radiusLength * heightLength) + (2 * (float)PI * radiusLength * radiusLength);
            return cylinderArea;
        }

        public override double CalculateVolume()
        {
            cylinderVolume = (float)PI * radiusLength * radiusLength * heightLength;
            return cylinderVolume;
        }

        public override string ToString()
        {
            return radiusLength + " r x " + heightLength + " h";
        }
    }

    class Sphere : Shape
    {
        private float radiusLength;
        private float sphereArea;
        private float sphereVolume;
        bool inputData = false;

        public Sphere(string typeofShape)                   // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }

        public override void SetData()                      // prompts user for input
        {

            while (!inputData)                              // loops until the data entred is not true
            {
                Console.Write("\nEnter the radius : ");

                if (!float.TryParse(Console.ReadLine(), out radiusLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }
            }
        }
        public override double CalculateArea()
        {
            sphereArea = (4 * (float)PI * radiusLength * radiusLength);
            return sphereArea;
        }

        public override double CalculateVolume()
        {
            sphereVolume = ((float)4 / 3) * ((float)PI * radiusLength * radiusLength * radiusLength);
            return sphereVolume;
        }

        public override string ToString()
        {
            return radiusLength + " r ";
        }
    }

    class Triangle : Shape
    {
        private float baseLength;
        private float heightLength;
        private float triangleArea;
        bool inputData = false;

        public Triangle(string typeofShape)                   // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }

        public override void SetData()                      // prompts user for input
        {

            while (!inputData)                              // loops until the data entred is not true
            {
                Console.Write("\nEnter the base : ");

                if (!float.TryParse(Console.ReadLine(), out baseLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }

                Console.Write("\nEnter the height : ");

                if (!float.TryParse(Console.ReadLine(), out heightLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }
            }
        }
        public override double CalculateArea()
        {
            triangleArea = (baseLength * heightLength) / 2;
            return triangleArea;
        }

        public override double CalculateVolume()
        {
            return Convert.ToDouble(0);
        }
        public override string ToString()
        {
            return baseLength + " b x " + heightLength + " h";
        }
    }

    class Tetrahedron : Shape
    {
        private float edgeLength;
        private float tetrahedronArea;
        private float tetrahedronVolume;
        bool inputData = false;

        public Tetrahedron(string typeofShape)                   // Constructor for shape
        {
            Type = typeofShape;                             // assigning the appropriate shape
        }
        public override void SetData()                      // prompts user for input
        {

            while (!inputData)                              // loops until the data entred is not true
            {
                Console.Write("\nEnter the edge : ");

                if (!float.TryParse(Console.ReadLine(), out edgeLength))
                {
                    Console.WriteLine("**Please enter only numbers\nPress any key to enter once again");
                    inputData = false;

                }
                else
                {
                    inputData = true;
                }

            }
        }
        public override double CalculateArea()
        {
            tetrahedronArea = ((float)Math.Pow(3, 0.5)) * edgeLength * edgeLength;
            return tetrahedronArea;
        }

        public override double CalculateVolume()
        {
            tetrahedronVolume = (edgeLength * edgeLength * edgeLength) / (6 * (float)Math.Pow(2, 0.5));
            return tetrahedronVolume;
        }
        public override string ToString()
        {
            return edgeLength + " l";
        }
    }
}
