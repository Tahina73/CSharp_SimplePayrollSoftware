using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace PayrollConsApp
{
    public class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1,
            FEB = 2,
            MAR = 3,
            APR = 4,
            MAY = 5,
            JUN = 6,
            JUL = 7,
            AUG = 8,
            SEP = 9,
            OCT = 10,
            NOV = 11,
            DEC = 12
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            if (myStaff == null || myStaff.Count == 0)
                throw new ArgumentNullException(nameof(myStaff));
            string path = string.Empty;
            foreach (Staff member in myStaff)
            {
                path = member.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.WriteLine($"PAYSLIP FOR {(MonthsOfYear)month} {year.ToString()} ");
                    sw.WriteLine("=================================");
                    sw.WriteLine(member.ToString());
                    sw.Close();
                }
            }
        }

        public void GenerateSumary(List<Staff> myStaff)
        {
            if (myStaff == null || myStaff.Count == 0)
                throw new ArgumentNullException(nameof(myStaff));
            string path = "summary.txt";
            var result = from member in myStaff
                         where member.HoursWorked < 10
                         orderby member.NameOfStaff ascending
                         select new { member.NameOfStaff, member.HoursWorked };
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                if (result != null && result.Count() > 0)
                {
                    sw.WriteLine("==========================================");
                    sw.WriteLine("STAFF worked less than 10 hours that month");
                    sw.WriteLine("==========================================");
                    foreach (var elt in result)
                    {
                        sw.WriteLine($@"Name         = {elt.NameOfStaff.ToUpper()}
                                     Hours worked = {elt.HoursWorked}
                                     **********************");
                    }
                }
                else
                {
                    sw.WriteLine("==============================================");
                    sw.WriteLine("Everybody worked more than 10 hours that month");
                    sw.WriteLine("==============================================");
                }
                sw.Close();
            }
            if (result != null && result.Count() > 0)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("STAFF worked less than 10 hours that month");
                Console.WriteLine("==========================================");
                foreach (var elt in result)
                {
                    Console.WriteLine($@"Name         = {elt.NameOfStaff.ToUpper()}
                                     Hours worked = {elt.HoursWorked}
                                     **********************");
                }
            }
            else
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("Everybody worked more than 10 hours that month");
                Console.WriteLine("==============================================");
            }

        }

        public override string ToString()
        {
            return $"PAYSLIP FOR {(MonthsOfYear)month} {year.ToString()} ";
        }
    }
}
