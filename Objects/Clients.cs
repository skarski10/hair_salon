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
                return (clientEquality && stylistIdEquality);
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> AllClients = new List<Client>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int clientStylistId = rdr.GetInt32(2);

                Client newClient = new Client(clientName, clientStylistId, clientId);
                AllClients.Add(newClient);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return AllClients;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @StylistId);", conn);

            SqlParameter nameParameter = new SqlParameter();
            nameParameter.ParameterName = "@ClientName";
            nameParameter.Value = this.GetClientName();

            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = this.GetStylistId();

            cmd.Parameters.Add(nameParameter);
            cmd.Parameters.Add(stylistIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static Client Find(int id)
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
          SqlParameter clientIdParameter = new SqlParameter();
          clientIdParameter.ParameterName = "@ClientId";
          clientIdParameter.Value = id.ToString();
          cmd.Parameters.Add(clientIdParameter);
          SqlDataReader rdr = cmd.ExecuteReader();

          int foundClientId = 0;
          string foundClientName = null;
          int foundStylistId = 0;

          while(rdr.Read())
          {
            foundClientId = rdr.GetInt32(0);
            foundClientName = rdr.GetString(1);
            foundStylistId = rdr.GetInt32(2);
          }

          Client foundClient = new Client(foundClientName, foundStylistId, foundClientId);

          if (rdr != null)
          {
            rdr.Close();
          }
          if (conn != null)
          {
            conn.Close();
          }
          return foundClient;

        }

        public void Update(string newName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @NewName OUTPUT INSERTED.name WHERE id = @ClientId;", conn);

            SqlParameter newNameParameter = new SqlParameter();
            newNameParameter.ParameterName = "@NewName";
            newNameParameter.Value = newName;
            cmd.Parameters.Add(newNameParameter);

            SqlParameter clientIdParameter = new SqlParameter();
            clientIdParameter.ParameterName = "@ClientId";
            clientIdParameter.Value = this.GetClientId();
            cmd.Parameters.Add(clientIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._name = rdr.GetString(0);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void Delete()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id=@ClientId", conn);
            SqlParameter idParameter = new SqlParameter();
            idParameter.ParameterName = "@ClientId";
            idParameter.Value = this.GetClientId();
            cmd.Parameters.Add(idParameter);
            cmd.ExecuteNonQuery();

            if(conn != null)
            {
                conn.Close();
            }
        }






        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
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
