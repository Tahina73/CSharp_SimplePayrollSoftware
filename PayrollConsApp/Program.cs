using System;
using System.Collections.Generic;

namespace PayrollConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0, year = 0, i = 0;
            PaySlip ps = null;

            while (year <= 0)
            {
                Console.WriteLine("\nPlease enter the year : ");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException )
                {
                    Console.WriteLine("Please enter a valid year");
                }
            }
            while (month <= 0 || month >12)
            {
                Console.WriteLine("\nPlease enter the month [1 - 12] : ");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12)
                        Console.WriteLine("Month must be between 1 and 12");
                }
                catch (FormatException )
                {
                    Console.WriteLine("Please enter a month year [1 - 12]");
                }
            }
            myStaff = fr.ReadFile();
            while(i<myStaff.Count)
            {
                try
                {
                    Console.WriteLine("Enter hours worked for " + myStaff[i].NameOfStaff.ToUpper());
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                    i++;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Enter a valid number.");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    i++;
                }
            }
            ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSumary(myStaff);
            Console.ReadLine();
        }
    }
}
