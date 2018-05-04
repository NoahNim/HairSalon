using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private int _stylistId;

    public Client(string name, int stylistId)
    {
      _name = name;
      _stylistId = stylistId;
    }

    public string GetClientName()
    {
      return _name;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }

    public void AddClient()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `clients` ('name`, 'stylistId') VALUES (@ItemName, @ItemStylistId)";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@ItemName";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@ItemStylistId";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);

      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAllClients()
    {
      List<Client> lists = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string  Name = rdr.GetString(0);
        int StylistId = rdr.GetInt32(1);
        Client MyClient = new Client(Name, StylistId);
        lists.Add(MyClient);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return lists;
    }
  }
}
