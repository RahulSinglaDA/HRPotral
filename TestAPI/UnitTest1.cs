using DepartmentService;
using DepartmentService.Controllers;
using EmployeeService;
using EmployeeService.Controllers;
using Helper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestAPI
{
    public class UnitTest1
    {

        //[Fact]
        //public void Task_GetEmployeeById_Return_OkResult()
        //{
        //    //Arrange  
        //    var controller = new EmployeeController(new EmployeeRepository(new Helper.DBManager()));
        //    var empId = 1;

        //    //Act  
        //    var data = controller.Get(empId);

        //    //Assert  
        //    Assert.IsType<Employee>(data);
        //}

        [Theory]
        [InlineData(1)]
        public void Task_GetEmployeeById_Return_Employee(int id)
        {
            //Arrange  
            var controller = new EmployeeController();

            //Act  
            var data = controller.GetAsync(id);

            //Assert  
            Assert.IsType<Employee>(data);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Task_PostEmployee_Return_OkResult(int expected,params Employee[] values)
        {
            //Arrange  
            var controller = new EmployeeController();

            foreach(Employee val in values)
            {
                var data = controller.PostAsync(val);
                Assert.Equal(expected, data.Result.StatusCode);
            }
            
        }

        public static System.Collections.Generic.IEnumerable<object[]> TestData()
        {
            yield return new Object[] {new OkResult().StatusCode, new Employee { EmployeeID = 4, EmployeeName = "Rahul1", EmployeeEmail = "abcd@gmail.com", EmployeePhone = 123, DepartmentID = 1 } };
            yield return new object[] {new OkResult().StatusCode, new Employee { EmployeeID = 5, EmployeeName = "Rahul3", EmployeeEmail = "abcd3@gmail.com", EmployeePhone = 3123, DepartmentID = 1 } };
        }



        [Theory]
        [InlineData(1)]
        public void Task_GetDepartmentById_Return_Department(int id)
        {  
            var controller = new DepartmentController(new DepartmentRepository(new Helper.DBManager()));
 
            var data = controller.Get(id);
 
            Assert.IsType<Department>(data);
        }
    }
}
