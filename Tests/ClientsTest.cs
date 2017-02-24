using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_DatabaseEmpty()
        {
            int result = Client.GetAll().Count;

            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_ReturnTrueIfEqual()
        {
            //Arrange, Act
            Client firstClient = new Client("Birdperson", 1);
            Client secondClient = new Client("Birdperson", 1);

            //Assert
            Assert.Equal(firstClient, secondClient);
        }

        [Fact]
        public void Test_Save_SavesClient()
        {
            // Arrange
            Client testClient = new Client("Squanchy", 1);

            // Act
            testClient.Save();
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client>{testClient};

            // Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_SaveAssignsIdToObject()
        {
            // Arrange
            Client testClient = new Client("Tammy", 1);
            testClient.Save();

            // Act
            Client savedClient = Client.GetAll()[0];

            int result = savedClient.GetClientId();
            int testId = testClient.GetClientId();

            // Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void Test_FindStylistId()
        {
            //Arrange
            Client testClient = new Client("Jerry Smith", 1);
            testClient.Save();

            //Act
            Client foundClientId = Client.Find(testClient.GetClientId());

            //Assert
            Assert.Equal(testClient, foundClientId);
        }

        [Fact]
        public void Test_EditClientName()
        {
            //Arrange
            Client testClient = new Client("Bird Person", 1);
            testClient.Save();
            string newName = "Birdperson";

            //Act
            testClient.Update(newName);

            string result = testClient.GetClientName();

            //Assert
            Assert.Equal(newName, result);
        }

        [Fact]
        public void Test_Delete_DeletesClientFromDatabase()
        {
            //Arrange
            string name1 = "Beth Smith";
            Client testClient1 = new Client(name1, 1);
            testClient1.Save();

            string name2 = "Jerry Smith";
            Client testClient2 = new Client(name2, 1);
            testClient2.Save();

            Stylist testStylist1 = new Stylist("Rick", testClient1.GetClientId());
            testStylist1.Save();
            Stylist testStylist2 = new Stylist("Mr. MeeSeeks", testClient2.GetClientId());
            testStylist2.Save();

            //Act
            testClient1.Delete();
            List<Client> resultCategories = Client.GetAll();
            List<Client> testClientList = new List<Client> {testClient2};

            List<Stylist> resultStylists = Stylist.GetAll();
            List<Stylist> testStylistList = new List<Stylist> {testStylist2};

            //Assert
            Assert.Equal(testClientList, resultCategories);
            Assert.Equal(testStylistList, resultStylists);
        }











        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
        }
    }
}
