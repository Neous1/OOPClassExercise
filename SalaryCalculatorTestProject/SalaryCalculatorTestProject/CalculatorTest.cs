﻿using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculatorTestProject
{
    /***
    To get hourly, divide annnual salary by 2080
    $100,006.40/2080 = $48.08 hr

    Toget annual, multiply hourly by 2080
    $48.08 * 2080
    
    */
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void AnnualSalaryTest()
        {
            //Arrange
            SalaryCalculator sc = new SalaryCalculator();
            //Act
            decimal annualSalary = sc.GetAnnualSalary(50);
            //Assert
            Assert.AreEqual(104000, annualSalary);
        }
        [TestMethod]
        public void HourlyWageTest()
        {
            //Arrange
            SalaryCalculator sc = new SalaryCalculator();
            //Act
            decimal hourlyWage = sc.GetHourlyWage(52000);
            //Assert
            Assert.AreEqual(25, hourlyWage);
        }
    }
}
