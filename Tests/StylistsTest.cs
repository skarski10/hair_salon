using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class StylistTest : IDisposable
    {
        public StylistTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

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

        [Fact]
        public void Test_FindStylistId()
        {
            //Arrange
            Stylist testStylist = new Stylist("Mr. MeeSeeks");
            testStylist.Save();

            //Act
            Stylist foundStylistId = Stylist.Find(testStylist.GetStylistId());

            //Assert
            Assert.Equal(testStylist, foundStylistId);
        }

        [Fact]
        public void Test_EditStylistName()
        {
            //Arrange
            Stylist testStylist = new Stylist("Ricky", 1);
            testStylist.Save();
            string newName = "Rick";

            //Act
            testStylist.Update(newName);

            string result = testStylist.GetStylistName();

            //Assert
            Assert.Equal(newName, result);
        }

        // [Fact]
        // public void Test_Delete_DeletesStylistFromDatabase()
        // {
        //     //Arrange
        //     string name1 = "Morty";
        //     Stylist testStylist1 = new Stylist(name1, 1);
        //     testStylist1.Save();
        //
        //     string name2 = "Summer";
        //     Stylist testStylist2 = new Stylist(name2, 1);
        //     testStylist2.Save();
        //
        //     //Act
        //     testStylist1.Delete();
        //     List<Stylist> resultStylist = Stylist.GetAll();
        //     List<Stylist> testStylistList = new List<Stylist> {testStylist2};
        //
        //
        //     //Assert
        //     Assert.Equal(testStylistList, resultStylist);
        // }








        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
        }
    }
}
