using System;
using System.Collections.Generic;

namespace UpdatedEmployee
{
    public class Employee : IComparable<Employee>
    {
        public decimal gross;                                       // Local variable for Gross Pay

        /// <summary>
        /// Name property
        /// </summary>
        /// <remarks>
        /// Get and Set methods for Name
        /// </remarks>
        public string Name { get; set; }                          // The employee name

        /// <summary>
        /// Number property
        /// </summary>
        /// <remarks>
        /// Get and Set methods for Number
        /// </remarks>
        public int Number { get; set; }                           // The employee ID

        /// <summary>
        /// Rate property
        /// </summary>
        /// <remarks>
        /// Get and Set methods for Rate
        /// </remarks>
        public decimal Rate { get; set; }                        // The hourly rate

        /// <summary>
        /// Gross property
        /// </summary>
        /// <remarks>
        /// Get and Set proerties for Gross
        /// </remarks>
        public decimal Gross                                    // The gross pay
        {
            get
            {
                if (Hours < 40)
                    gross = (decimal)Hours * Rate;
                else
                    gross = (40.0m * Rate) + (((decimal)Hours - 40.0m) * Rate * 1.5m);
                return gross;
            }
            set
            {
                gross = value;
            }
        }

        /// <summary>
        /// Hours property
        /// </summary>
        /// <remarks>
        /// Get and Set methods for Hours
        /// </remarks>
        public double Hours { get; set; }                        // The weekly hours

        /// <summary>
        /// Default constructor for Employee - used for creating Employee array
        /// </summary>
        public Employee()
        {
        }

        /// <summary>
        /// Four-argument constructor for Employee
        /// </summary>
        /// <param name="name">Employee name</param>
        /// <param name="number">Employee number</param>
        /// <param name="rate">Hourly rate of pay</param>
        /// <param name="hours">Hours worked in a week</param>
        public Employee(string name, int number, decimal rate, double hours)
        {
            /* This is the better way to set data in a class - use the accessor methods.
             * That way, if their implementation changes, the constructor doesn't need to
             * be edited as well.
             */
            Name = name;
            Number = number;
            Rate = rate;
            Hours = hours;
            Gross = gross;
        }

        /// <summary>
        /// Employee display method - in the future, we'll override the ToString method of Object
        /// </summary>
        public void PrintEmployee()
        {
            Console.WriteLine("{0, -20}  {1:D5}  {2,6:C}  {3:#0.00}  {4,9:C}", Name, Number, Rate, Hours, Gross);
        }

        /// <summary>
        /// Implemented CompareTo method of Comparable inrerface
        ///  </summary>
        /// <param name="obj">Employee object name</param>
        public int CompareTo(Employee obj)
        {

            if (obj == null) return 1;
            return Name.CompareTo(obj.Name);
        }


        /// <summary>
        /// Four-argument constructor for Employee
        /// </summary>
        /// <param name="emp">Employee onject intance</param>
        /// <param name="choice">Choice entered by the user in console</param>
        public int CompareTo(Employee emp, int choice)      // Special implementation to be called by custom comparer
        {
            switch (choice)
            {
                case 1:
                    return Name.CompareTo(emp.Name);        // Name sorted in ascending order

                case 2:
                    return Number.CompareTo(emp.Number);    // Number sorted in ascending order

                case 3:
                    return emp.Rate.CompareTo(Rate);        // Rate sorted in descending order

                case 4:
                    return emp.Hours.CompareTo(Hours);      // Hours sorted in descending order

                case 5:
                    return emp.Gross.CompareTo(Gross);      // Gross sorted in Descending order
            }
            return 0;                                       // Error Handling
        }

        // nested class which implements IComparer
        /// <summary>
        /// Nested class to implement IComparer interface in order to sort all fields
        /// </summary>
        /// <param name="emp1">First Employee onject intance</param>
        /// <param name="emp2">Second Employee onject intance</param>
        /// <param name="Choice">Choice properties for user entred choice</param>
        public class FieldsSorting : IComparer<Employee>
        {
            // private variable choice to make the access 
            public int Choice { get; set; }

            // Called by Sort method on Employee objects to compare
            public int Compare(Employee emp1, Employee emp2)
            {
                return emp1.CompareTo(emp2, Choice);
            }
        }
    }
}
