using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalonApp
{
    public class HairSalonTest
    {
        [Fact]
        public void Test_DatabaseEmpty()
        {
            int result = Stylist.GetAll().Count;

            Assert.Equal(2, result);
        }
    }
}
