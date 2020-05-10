using System;
using System.Collections.Generic;
using System.Text;

namespace PayrollConsApp
{
    public class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30f;

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
            return @$" Manager : {NameOfStaff}
                        Hourly rate : {adminHourlyRate.ToString()}
                        Hours worked : {HoursWorked.ToString()}
                        Overtime rate : {overtimeRate.ToString()}
                        Overtime : {Overtime.ToString()}
                        Total pay : {TotalPay.ToString()}
                        Basic pay : {BasicPay.ToString()}";
        }
    }
}
