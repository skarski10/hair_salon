using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalonApp
{
    public class Client
    {
        private int _id;
        private string _name;
        private int _stylistId;
        public Client(string name, int stylistId, int id = 0)
        {
            _id = id;
            _name = name;
            _stylistId = stylistId;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool clientEquality = this.GetClientName() == newClient.GetClientName();
                bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
                return false;
            }
        }







        public int GetClientId()
        {
            return _id;
        }

        public string GetClientName()
        {
            return _name;
        }
        public void SetClientName(string newName)
        {
            _name = newName;
        }
        public int GetStylistId()
        {
            return _stylistId;
        }
        public void SetStylistId(int newStylistId)
        {
            _stylistId = newStylistId;
        }
    }
}
