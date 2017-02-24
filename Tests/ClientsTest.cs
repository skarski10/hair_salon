using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class ClinetTest
    {
        public void ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
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
    }
}
