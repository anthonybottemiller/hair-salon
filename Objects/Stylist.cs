using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _name;

  public Stylist(string Name, int Id = 0)
  {
    _id = Id;
    _name = Name;
  }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection connection = DB.Connection();
      connection.Open();
      
      SqlCommand command = new SqlCommand("SELECT * FROM stylists;", connection);      
      SqlDataReader reader = command.ExecuteReader();

      while(reader.Read())
      {
        int stylistId = reader.GetInt32(0);
        string stylistName = reader.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        allStylists.Add(newStylist);
      }

      if (reader != null)
      {
        reader.Close();
      }

      if (connection != null)
      {
        connection.Close();
      }

      return allStylists;
    }

    public void Save()
    {
      SqlConnection connection = DB.Connection();
      connection.Open();

      SqlCommand command = new SqlCommand("INSERT INTO stylists (name) OUTPUT INSERTED.id VALUES (@StylistName);", connection);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StylistName";
      nameParameter.Value = this.GetName();
      command.Parameters.Add(nameParameter);
      SqlDataReader reader = command.ExecuteReader();

      while(reader.Read())
      {
        this._id = reader.GetInt32(0);
      }
      if (reader != null)
      {
        reader.Close();
      }
      if (connection != null)
      {
        connection.Close();
      }
    }

public static void DeleteAll()
    {
      SqlConnection connection = DB.Connection();
      connection.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", connection);
      cmd.ExecuteNonQuery();
      connection.Close();
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
        bool idEquality = this.GetId() == newStylist.GetId();
        bool nameEquality = this.GetName() == newStylist.GetName();
        return (nameEquality && idEquality);
      }
    }
    public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }
  }
}