using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _name;

    public Stylist(int id, string name)
    {
      _id = id;
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }

    public void AddStylist()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `stylists` (`id`,`name`) VALUES (@ItemId, @ItemName)";

      MySqlParameter id = new MySqlParameter();
      id.ParameterName = "@ItemId";
      id.Value = this._id;
      cmd.Parameters.Add(id);

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@ItemName";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<Stylist> GetAllStylists()
    {
      List<Stylist> lists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int Id = rdr.GetInt32(0);
        string  Name = rdr.GetString(1);
        Stylist MyStylist = new Stylist(Id, Name);
        lists.Add(MyStylist);
      }
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return lists;
    }

    public static Stylist FindStylist(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT FROM stylists WHERE id = (@searchId)";

      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);


      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int stylistID = 0;
      string stylistName = "";

      while(rdr.Read())
      {
        stylistID = rdr.GetInt32(0);
        stylistName = rdr.GetString(1);
      }

      Stylist myStylist = new Stylist(stylistID, stylistName);

      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
      return myStylist;
    }
  }
}
