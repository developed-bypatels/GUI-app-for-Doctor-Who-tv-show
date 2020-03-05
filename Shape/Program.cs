using System;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            string aplhaArray = "ABCDEFGHIJabcdegfhij";                     // array to check the input must lies in between in this
            string choice = "";                                             // intializing choice so that we can enter "while" loop for the first time
            int i = 0;                                                      // declaring and intializing variable to keep track number of objects

            Shape[] shapeObjects = new Shape[100];                          // class array of shape class

            while (choice != "0")                                           // condition to end the while loop when user enters "0"
            {
                Console.Clear();                                            // clears the console screen
                Console.ForegroundColor = ConsoleColor.Green;               // to change the font color
                Console.WriteLine("Frank's Geometry Class");
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine("A - Rectangle\tE - Ellipse\tI - Triangle");
                Console.WriteLine("B - Square\tF - Circle\tJ - Tetrahedron");               // UI for the program
                Console.WriteLine("C - Box\t\tG - Cylinder");
                Console.WriteLine("D - Cube\tH - Sphere\n");
                Console.WriteLine("0 - List all shapes and Exit...\n");
                Console.WriteLine("( {0} shapes entered so far )\n", Shape.GetCount());
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();                                                    // input from the user


                if (choice == "")                                                               // validates if the input is empty
                {
                    Console.WriteLine("\n**Please enter something.\nPress any key to continue ...");
                    Console.ReadKey();
                }
                else if (aplhaArray.Contains(choice))                                           // validates if the input lies in the array
                {
                    if (choice == "A" || choice == "a")                                         // validates if input is in array then Rectangle object is created
                    {
                        shapeObjects[i] = new Rectangle("Rectangle");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }

                    else if (choice == "B" || choice == "b")                                    // validates if input is in array then Square object is created
                    {
                        shapeObjects[i] = new Square("Square");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }

                    else if (choice == "C" || choice == "c")                                    // validates if input is in array then Box object is created
                    {
                        shapeObjects[i] = new Box("Box");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }

                    else if (choice == "D" || choice == "d")                                    // validates if input is in array then Cube object is created
                    {
                        shapeObjects[i] = new Cube("Cube");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }

                    else if (choice == "e" || choice == "E")                                    // validates if input is in array then Ellipse object is created
                    {
                        shapeObjects[i] = new Ellipse("Ellipse");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }

                    else if (choice == "f" || choice == "F")                                    // validates if input is in array then Circle object is created
                    {
                        shapeObjects[i] = new Circle("Circle");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }

                    else if (choice == "g" || choice == "G")                                    // validates if input is in array then Cylinder object is created
                    {
                        shapeObjects[i] = new Cylinder("Cylinder");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }

                    else if (choice == "h" || choice == "H")                                    // validates if input is in array then Sphere object is created
                    {
                        shapeObjects[i] = new Sphere("Sphere");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }

                    else if (choice == "i" || choice == "I")                                    // validates if input is in array then Triangle object is created
                    {
                        shapeObjects[i] = new Triangle("Triangle");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }

                    else if (choice == "j" || choice == "J")                                    // validates if input is in array then Tetrahedron object is created
                    {
                        shapeObjects[i] = new Tetrahedron("Tetrahedron");
                        shapeObjects[i].SetData();                                              // prompts user for input
                    }
                    i++;
                }
                else if (choice == "0")                                                         // validates the input and prints the shape and exits the program
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Frank's Geometry Class");
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("\nThere is {0} object:", Shape.GetCount());               // prints the number of shapes

                    Console.WriteLine("\n{0,12} {1,25} {2,25} {3,25}", "Shape", "Area", "Volume", "Details");
                    Console.WriteLine("=================== ============================= ============================= ==============================");

                    for (int obj = 0; obj < Shape.GetCount(); obj++)
                    {

                        Console.Write($"{shapeObjects[obj].Type,12}{shapeObjects[obj].CalculateArea(),25}{shapeObjects[obj].CalculateVolume(),25}");
                        Console.WriteLine($"{shapeObjects[obj].ToString(),25}");

                    }
                    Console.WriteLine("\n\nPress enter to end the program");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine("\n**Input is Wrong.\nPress enter key to continue");
                    Console.ReadKey();
                }

            }
        }
    }
}
