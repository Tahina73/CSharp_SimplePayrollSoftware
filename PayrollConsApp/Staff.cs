using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollConsApp
{
    public class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
        public int HoursWorked {
            get { return hWorked; }
            set {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }
        }
        public Staff(string pName, float pRate)
        {
            if (string.IsNullOrWhiteSpace(pName))
                throw new ArgumentNullException(nameof(pName));
            if (pRate<0)
                throw new ArgumentNullException(nameof(pRate)+" is smaller than 0");
            NameOfStaff = pName;
            hourlyRate = pRate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return @$" Staff : {NameOfStaff}
                        Hourly rate : {hourlyRate.ToString()}
                        Hours worked : {HoursWorked.ToString()}
                        Total pay : {TotalPay.ToString()}
                        Basic pay : {BasicPay.ToString()}";
        }
    }
}
