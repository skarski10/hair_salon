using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalonApp
{
    public class Stylist
    {
        private int _id;
        private string _name;

        public Stylist(string name, int id = 0)
        {
            _id = id;
            _name = name;
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> stylistList = new List<Stylist> {};

            return stylistList;
        }
    }
}
