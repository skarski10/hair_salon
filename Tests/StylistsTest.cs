using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class HairSalonTest : IDisposable
    {
        [Fact]
        public void Test_DatabaseEmpty()
        {
            int result = Stylist.GetAll().Count;

            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_ReturnTrueIfEqual()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("Rick");
            Stylist secondStylist = new Stylist("Rick");

            //Assert
            Assert.Equal(firstStylist, secondStylist);
        }

        [Fact]
        public void Test_Save_SavesStylist()
        {
            // Arrange
            Stylist testStylist = new Stylist("Morty");

            // Act
            testStylist.Save();
            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist>{testStylist};

            // Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_SaveAssignsIdToObject()
        {
            // Arrange
            Stylist testStylist = new Stylist("Summer");
            testStylist.Save();

            // Act
            Stylist savedStylist = Stylist.GetAll()[0];

            int result = savedStylist.GetStylistId();
            int testId = testStylist.GetStylistId();

            // Assert
            Assert.Equal(testId, result);
        }








        public void Dispose()
        {
            Stylist.DeleteAll();
        }
    }
}
