using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SalaryCalculator
    {
        //move const HoursInYear out of the getAnnualSalary to make it global
        const int hoursInYear = 2080;
        public decimal GetAnnualSalary(decimal hourlyWage)
        {
            
            decimal annualSalary = hourlyWage * hoursInYear;

            return annualSalary;
        }

        public decimal GetHourlyWage(int annualSalary)
        {

            return annualSalary/hoursInYear;
        }
    }
}
