using RealEstateFinal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RealEstateFinal.Tests
{
    public class ListingTests
    {
        [Fact]
        public void TestModel()
        {
            //Arrange

            Listing list = new Listing();
            list.Title = "Test title";
            list.AvailableNow = false;
            list.Beds = 1;
            list.Baths = 1;
            list.Body = "Test";
            list.Rent = 3900;
            list.ImgURL = "imgurl";


            //Assert

            Assert.Equal("Test title", list.Title);
            Assert.False(list.AvailableNow);
            Assert.Equal(1, list.Beds);
            Assert.Equal(1, list.Baths);
            Assert.Equal("Test", list.Body);
            Assert.Equal(3900, list.Rent);
            Assert.Equal("imgurl", list.ImgURL);

        }
    }
}
