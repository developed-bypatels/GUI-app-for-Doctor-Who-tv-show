using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Employee
{
    // I, have used Insertion sort as a sorting algorihm https://en.wikipedia.org/wiki/Insertion_sort
    class Program
    {

        public static string[,] employeedata = new string[100, 5];
        public static Employee[] employee = new Employee[100];

        public static string[] nameArray;
        public static int[] numberArray;
        public static decimal[] rateArray;
        public static double[] hoursArray;                                      // Declaring the arry for sorting
        public static decimal[] grossArray;

        public static int[] tempNumberArray;
        public static string[] tempNameArray;
        public static decimal[] tempRateArray;
        public static double[] tempHoursArray;
        public static decimal[] tempGrossArray;
        public static Boolean fileExistance;
        static void Main(string[] args)
        {

            Read();                                                                             // Call read method
            if (fileExistance)
            {
                string tempChoice;                                                                  // declaring variable for input of choice
                while (true)                                                                        // while loop never ends unless it is break
                {
                    Console.Write("1. Sort by Employee Name (ascending) \n"
                            + "2. Sort by Employee Number(ascending) \n"
                            + "3. Sort by Employee Pay Rate(descending) \n"
                            + "4. Sort by Employee Hours(descending) \n"
                            + "5. Sort by Employee Gross Pay(descending) \n\n"
                            + "6. Exit \n\n"
                            + "Enter Choice: ");


                    tempChoice = Console.ReadLine();                                                // input of choice as a string
                    int choice = 0;                                                                  // declaring the integer variable to store actual choice
                    if (Int32.TryParse(tempChoice, out choice) || choice > 6)                       // Exception handling
                    {
                        Console.WriteLine("Wrong Input, Try Again\n");

                    }
                    if (choice < 6 && choice > 0)                                                   // menu handling
                    {
                        Console.Clear();
                        Console.WriteLine("Employee\t\tNumber\tRate\tHours\tGross Pay\t\tNick's Company");
                        Console.WriteLine("====================================================================");

                        switch (choice)                                                             // check switch case
                        {

                            case 1:

                                nameArray = Sort(nameArray);                                        // call sort method nameArray sorted

                                for (int i = 0; i < nameArray.Length; i++)                          // looping throgh sorted array
                                {
                                    // tempNameArray is unsorted array of name
                                    for (int j = 0; j < tempNameArray.Length; j++)                  // looping throgh unsortde array
                                    {
                                        if (nameArray[i] == tempNameArray[j])                       // value of sorted array matches unsorted array index is noted of unsorted array
                                        {
                                            employee[j].PrintEmployee();                            // that index is used to print whole Employee class
                                        }
                                    }
                                }
                                Console.WriteLine();
                                break;

                            case 2:
                                Sort(numberArray);

                                for (int i = 0; i < numberArray.Length; i++)
                                {

                                    for (int j = 0; j < tempNumberArray.Length; j++)
                                    {
                                        if (numberArray[i] == tempNumberArray[j])                       // same as nameArray where here numberArray is sorted array
                                        {                                                               // and tempNumberArray is unsorted array
                                            employee[j].PrintEmployee();
                                            break;
                                        }
                                    }
                                }
                                Console.WriteLine(); break;

                            case 3:
                                Sort(rateArray);
                                int[] noRepeat = new int[rateArray.Length];

                                int k = 0;
                                int count = 1;
                                for (int i = 0; i < rateArray.Length; i++)                              // same as numberArray where here is rateArray is sorted array
                                {                                                                       // and tempRateArray is unsorted array

                                    for (int j = 0; j < tempRateArray.Length; j++)
                                    {
                                        if (rateArray[i] == tempRateArray[j])
                                        {
                                            if (!(noRepeat.Contains(j)))                                // index is stored in noRepeat array so that the
                                            {                                                           // employee class printed once is not printed second time
                                                employee[j].PrintEmployee();
                                                noRepeat[k] = j;
                                                k++;
                                            }
                                            else if (j == 0 && count == 1)                              // int array has remaining value as 0 so that employee
                                            {                                                           // class with 0 index was not printed 
                                                employee[j].PrintEmployee();
                                                noRepeat[k] = j;
                                                k++;
                                                count++;
                                            }
                                        }

                                    }
                                }
                                Console.WriteLine();
                                break;

                            case 4:
                                Sort(hoursArray);

                                for (int i = 0; i < hoursArray.Length; i++)
                                {

                                    for (int j = 0; j < tempHoursArray.Length; j++)                     // same as numberArray where here hoursArray is sorted array
                                    {                                                                   // and tempHoursArray is unsorted array
                                        if (hoursArray[i] == tempHoursArray[j])
                                        {
                                            employee[j].PrintEmployee();
                                        }
                                    }
                                }
                                Console.WriteLine(); break;

                            case 5:
                                Sort(grossArray);

                                for (int i = 0; i < grossArray.Length; i++)
                                {

                                    for (int j = 0; j < tempGrossArray.Length; j++)
                                    {                                                                   // same as numberArray where here grossArray is sorted array
                                        if (grossArray[i] == tempGrossArray[j])                         // and tempGrossArray is unsorted Array
                                        {
                                            employee[j].PrintEmployee();
                                        }
                                    }
                                }
                                Console.WriteLine(); break;

                            default: break;
                        }
                    }
                    else if (choice == 6) { break; }                                                    // Program ends if uer enters 6
                }


            }
            else
            {
                Console.WriteLine("File Not Found");
                Console.ReadLine();
            }
        }

        private static void Read()                                                                 // Read method will read whole file
        {                                                                                          // and populates the data in employee class

            employeedata = new string[100, 5];                                                     // intializing 2d array to first populate data into
            employee = new Employee[100];                                                          // intializing the Employee class to populate data into



            string[] data = new string[5];                                                          // to store comma seperated value into
            int rowNumber = 0;

            string row;                                                                            // to read whole line
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader("employees.txt");             // code to open the file
                while ((row = file.ReadLine()) != null)                                                // to read file line by line and storing it into row
                {
                    data = row.Split(',');                                                              // row is stored into string array data 


                    for (int i = 0; i < data.Length; i++)                                               // looping through data
                    {
                        employeedata[rowNumber, i] = data[i].Trim();                                    // trim the line
                    }
                    rowNumber++;

                }
                fileExistance = true;
                file.Close();                                                                           // file closed
            }
            catch
            {
                fileExistance = false;
            }




            nameArray = new string[rowNumber];
            numberArray = new int[rowNumber];
            rateArray = new decimal[rowNumber];
            hoursArray = new double[rowNumber];
            grossArray = new decimal[rowNumber];

            tempNumberArray = new int[rowNumber];
            tempNameArray = new string[rowNumber];
            tempRateArray = new decimal[rowNumber];
            tempHoursArray = new double[rowNumber];
            tempGrossArray = new decimal[rowNumber];


            for (int i = 0; employeedata[i, 0] != null; i++)                                         // looping through row of 2d array of employeedata
            {                                                                                       // populating all the arrays nameArray, tempNameArray, numberArray, tempNmberArray and all the same 

                employee[i] = new Employee();                                                       // creating the new employee class

                for (int j = 0; employeedata[i, j] != null; j++)                                      // looping through column of 2d aray of employeedata
                {

                    if (j == 0)                                                                     // for index 1 storing the data into name method of employee class
                    {
                        employee[i].SetName(employeedata[i, j]);
                        nameArray[i] = employee[i].GetName();
                        tempNameArray[i] = employee[i].GetName();

                    }
                    else if (j == 1)                                                                // for index 2 storing the data into number method of employee class
                    {
                        employee[i].SetNumber(int.Parse(employeedata[i, j]));
                        numberArray[i] = employee[i].GetNumber();
                        tempNumberArray[i] = employee[i].GetNumber();
                    }
                    else if (j == 2)                                                                // for index 3 storing the data into rate method of employee class
                    {
                        employee[i].SetRate(decimal.Parse(employeedata[i, j]));
                        rateArray[i] = employee[i].GetRate();
                        tempRateArray[i] = employee[i].GetRate();

                    }
                    else if (j == 3)                                                                // for index 4 storing the hours into name method of employee class
                    {
                        employee[i].SetHours(double.Parse(employeedata[i, j]));
                        employee[i].SetGross(employee[i].GetRate() * Convert.ToDecimal(employee[i].GetHours()));    // storing the data into gross method of employee class
                        hoursArray[i] = employee[i].GetHours();
                        tempHoursArray[i] = employee[i].GetHours();
                        grossArray[i] = employee[i].GetGross();
                        tempGrossArray[i] = employee[i].GetGross();
                    }

                }

            }

        }

        public static void Sort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                for (int j = i; j > 0 && numbers[j - 1] > numbers[j]; j--)
                {
                    int temp = numbers[j - 1];
                    numbers[j - 1] = numbers[j];
                    numbers[j] = temp;
                }

            }

        }

        public static string[] Sort(string[] names)                                             // Sorting method for name
        {                                                                                       // Insertion Sort
            for (int i = 0; i < names.Length; i++)
            {
                for (int j = i + 1; j < names.Length; j++)
                {
                    if (names[i][0] > names[j][0])
                    {
                        string temp = names[i].ToString();
                        names[i] = names[j];
                        names[j] = temp;
                    }
                }
            }
            return names;
        }


        public static void Sort(decimal[] numbers)                                          // Sorting method for decimal
        {                                                                                   // Insertion Sort               
            for (int i = 1; i < numbers.Length; i++)
            {
                for (int j = i; j > 0 && numbers[j - 1] > numbers[j]; j--)
                {
                    decimal temp = numbers[j - 1];
                    numbers[j - 1] = numbers[j];
                    numbers[j] = temp;
                }

            }

        }

        public static void Sort(double[] numbers)                                           // sorting method for double
        {                                                                                   // Insertion Sort
            for (int i = 1; i < numbers.Length; i++)
            {
                for (int j = i; j > 0 && numbers[j - 1] > numbers[j]; j--)
                {
                    double temp = numbers[j - 1];
                    numbers[j - 1] = numbers[j];
                    numbers[j] = temp;
                }

            }

        }
    }
}
