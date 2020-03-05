using System;
namespace Employee
{
    public class Employee
    {
        private String name;
        private int number;
        private decimal rate;
        private double hours;
        private decimal gross;


        public Employee()
        {
        }
        public Employee(String name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;
        }

        public decimal GetGross()
        {
            return gross;
        }

        public double GetHours()
        {
            return hours;
        }

        public String GetName()
        {
            return name;
        }

        public int GetNumber()
        {
            return number;
        }

        public decimal GetRate()
        {
            return rate;
        }

        public void PrintEmployee()
        {
            Console.WriteLine(GetName() + "\t\t" + GetNumber() + "\t" + GetRate() + "\t" + GetHours() + "\t" + GetGross());
        }

        public void SetHours(double hours)
        {
            this.hours = hours;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public void SetNumber(int number)
        {
            this.number = number;
        }

        public void SetRate(decimal rate)
        {
            this.rate = rate;
        }
        public void SetGross(decimal gross)
        {
            this.gross = gross;
        }
    }
}
