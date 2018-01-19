using System;
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
    public class UnitTest1
    {
        [TestMethod]
        public void AnnualSalaryTest()
        {
            //Arrange
            SalaryCalculator sc = new SalaryCalculator();
            //Act
            decimal annualSalary = sc.GetAnnualSalary(50);
            //Assert
            Assert.AreEqual(10400, annualSalary);
        }
    }
}
