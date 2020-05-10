using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollConsApp
{
    public class Manager : Staff
    {
        private const float managerHourlyRate = 50f;

        public int Allowance { get; set; }

        public Manager(string pName):base(pName,managerHourlyRate)
        { 
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160)
                TotalPay += 1000;
        }

        public override string ToString()
        {
            return @$" Manager : {NameOfStaff}
                        Hourly rate : {managerHourlyRate.ToString()}
                        Hours worked : {HoursWorked.ToString()}
                        Allowance : {Allowance.ToString()}
                        Total pay : {TotalPay.ToString()}
                        Basic pay : {BasicPay.ToString()}";
        }
    }
}
