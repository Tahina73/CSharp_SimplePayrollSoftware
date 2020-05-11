using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollConsApp
{
    public class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 70f;

        public float Overtime { get; private set; }

        public Admin(string pName) : base(pName, adminHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }

        }

        public override string ToString()
        {
            return @$"  Admin : {NameOfStaff}
==========================================
Hourly rate : {adminHourlyRate.ToString()}
Hours worked : {HoursWorked.ToString()}
Overtime rate : {overtimeRate.ToString()}
Overtime pay : ${Overtime.ToString()}
Basic pay : ${BasicPay.ToString()}
===================================
Total pay : ${TotalPay.ToString()}
===================================";
        }
    }
}
