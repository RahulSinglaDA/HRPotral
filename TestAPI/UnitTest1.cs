using DepartmentService;
using DepartmentService.Controllers;
using EmployeeService;
using EmployeeService.Controllers;
using Helper.Models;
using MediatR;
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
        public async Task Task_GetEmployeeById_Return_EmployeeAsync(int id)
        {
            //Arrange  
            var controller = new EmployeeController();

            //Act  
            var data = await controller.GetAsync(id);

            //Assert  
            Assert.IsType<Employee>(data);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public async Task Task_PostEmployee_Return_OkResultAsync(int expected,params Employee[] values)
        {
            //Arrange  
            var controller = new EmployeeController();

            foreach(Employee val in values)
            {
                var data =await controller.PostAsync(val);
                Assert.Equal(expected, data.StatusCode);
            }
            
        }

        public static System.Collections.Generic.IEnumerable<object[]> TestData()
        {
            yield return new Object[] {new OkResult().StatusCode, new Employee { EmployeeID = 5, EmployeeName = "Rahul1", EmployeeEmail = "abcd@gmail.com", EmployeePhone = 123, DepartmentID = 1 } };
            yield return new object[] {new OkResult().StatusCode, new Employee { EmployeeID = 7, EmployeeName = "Rahul3", EmployeeEmail = "abcd3@gmail.com", EmployeePhone = 3123, DepartmentID = 1 } };
        }



        [Theory]
        [InlineData(1)]
        public void Task_GetDepartmentById_Return_Department(int id)
        {  
            var controller = new DepartmentController();
 
            var data = controller.GetAsync(id);
 
            Assert.IsType<Department>(data);
        }
    }
}
