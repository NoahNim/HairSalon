// using System;
// using System.Collections.Generic;
// using MySql.Data.MySqlClient;
// using HairSalon;
//
// namespace HairSalon.Models
// {
//   public class Client
//   {
//     private string _name;
//     private int _stylistId;
//
//     public Client(string name, string stylistId)
//     {
//       _name = name;
//       _stylistId = stylistId;
//     }
//
//     public string GetName()
//     {
//       return _name;
//     }
//     public string GetStylistId()
//     {
//       return _stylistId;
//     }
//
//     public void AddClient()
//     {
//       MySqlConnection conn = DB.Connection();
//       conn.Open();
//       var cmd = conn.CreateCommand() as MySqlCommand;
//       cmd.CommandText = @"INSERT INTO `clients` ('name`, 'stylistId') VALUES (@ItemName, @ItemStylistId)";
//
//       MySqlParameter name = new MySqlParameter();
//       name.ParameterName = "@ItemName";
//       name.Value = this._name;
//       cmd.Parameters.Add(name);
//
//       MySqlParameter stylistId = new MySqlParameter();
//       stylistId.ParameterName = "@ItemStylistId";
//       stylistId.Value = this._id;
//       cmd.Parameters.Add(stylistId);
//
//       cmd.ExecuteNonQuery();
//       conn.Close();
//       if(conn != null)
//       {
//         conn.Dispose();
//       }
//     }
//   }
// }
