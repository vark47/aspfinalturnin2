using System;
using Xunit;
using RealEstateFinal.Models;
namespace RealEstateFinal.Tests
{
    public class MaintenanceRequestTests
    {
        [Fact]
        public void TestModel()
        {
            //Arrange

            MaintenanceRequest req = new MaintenanceRequest();
            req.Requestor = "Nicholas Cage";
            req.UnitNumber = 38;
            req.Description = "Test Data";
            req.PropertyAddress = "33 Arial Way";
            req.DateRequested = DateTime.Parse("12/11/1993");

            //Assert

            Assert.Equal("Nicholas Cage", req.Requestor);
            Assert.Equal(38, req.UnitNumber);
            Assert.Equal("Test Data", req.Description);
            Assert.Equal("33 Arial Way", req.PropertyAddress);
            Assert.Equal(DateTime.Parse("12/11/1993"), req.DateRequested);
        }
    }
}
