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

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool nameEquality = this.GetStylistName() == newStylist.GetStylistName();
                return (nameEquality);
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> stylistList = new List<Stylist> {};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistType = rdr.GetString(1);

                Stylist newStylist = new Stylist(stylistType, stylistId);
                stylistList.Add(newStylist);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return stylistList;
        }

        public int GetStylistId()
        {
            return _id;
        }

        public string GetStylistName()
        {
            return _name;
        }
    }
}
