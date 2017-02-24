using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class ClinetTest : IDisposable
    {
        public void ClientTest()
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
            Client testClient = new Client("Summer", 1);
            testClient.Save();

            // Act
            Client savedClient = Client.GetAll()[0];

            int result = savedClient.GetClientId();
            int testId = testClient.GetClientId();

            // Assert
            Assert.Equal(testId, result);
        }










        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
        }
    }
}
