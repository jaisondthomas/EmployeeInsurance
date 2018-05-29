using System;
using System.Linq;
using EmployeeInsurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeInsuranceTest
{
    [TestClass]
    public class InsurancePermiumTest
    {
        
        [TestMethod]
        public void OnlyFirstPermium()
        {
            var employee = EmployeesPermiumStub.EmployeeWithFirstPermium();

            var result = Insurance.PermiumPicker(employee);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void OnlySecondPermium()
        {
            var employee = EmployeesPermiumStub.EmployeeWithSecondPermium();

            var result = Insurance.PermiumPicker(employee);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void OnlyThirdPermium()
        {
            var employee = EmployeesPermiumStub.EmployeeWithThirdPermium();

            var result = Insurance.PermiumPicker(employee);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void FirstPermiumLessThanSecondPermium()
        {
            var employee = EmployeesPermiumStub.EmployeeWithLessFirstPermium();

            var result = Insurance.PermiumPicker(employee);

            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void FirstPermiumGreaterThanSecondPermium()
        {
            var employee = EmployeesPermiumStub.EmployeeWithGreaterFirstPermium();

            var result = Insurance.PermiumPicker(employee);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void FirstPermiumEqualsSecondPermiumThenThirdPermium()
        {
            var employee = EmployeesPermiumStub.EmployeeWithEqualFirstAndSecondPermium();

            var result = Insurance.PermiumPicker(employee);

            Assert.AreEqual(300, result);
        }

        [TestMethod]
        public void NoPermiumForEmployeeFound()
        {
            var employee = EmployeesPermiumStub.NoPermiumEmployee();

            var result = Insurance.PermiumPicker(employee);

            Assert.AreEqual(0, result);
        }

      
        [TestMethod]
        public void EmployeesPermium()
        {
            var employees = EmployeesPermiumStub.Employees();

            var result = Insurance.EmployeesPermium(employees);

            Assert.IsTrue(result.Count == 2 );
            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NoInsuredEmployeesFound()
        {
            var employees = EmployeesPermiumStub.NoInsuredEmployees();

            var result = Insurance.EmployeesPermium(employees);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullEmployees()
        {
            var result = Insurance.EmployeesPermium(null);
        }
       
        [TestMethod] 
        public void InvalidEmployees()
        {
            var employees = EmployeesPermiumStub.InvalidEmployees();
           var result =  Insurance.InvalidEmployees(employees);

            Assert.AreEqual( 0, result.ElementAt(0).EmployeeId );
        }

        [TestMethod]
        public void ValidEmployees()
        {
            var employees = EmployeesPermiumStub.Employees();
            var result = Insurance.InvalidEmployees(employees);

            Assert.IsTrue( result.Count == 0);
        }


        [TestMethod]
        public void InvalidInsurances()
        {
            var employees = EmployeesPermiumStub.InvalidInsurance();
            var result = Insurance.InvalidInsurances(employees);

            Assert.AreEqual(0, result.ElementAt(0).InsuranceCompanyId);
        }

        [TestMethod]
        public void ValidInsurances()
        {
            var employees = EmployeesPermiumStub.Employees();
            var result = Insurance.InvalidInsurances(employees);

           Assert.IsTrue(result.Count==0);
        }

        [TestMethod]
        public void CommitTest()
        {
            
        }


    }
}
