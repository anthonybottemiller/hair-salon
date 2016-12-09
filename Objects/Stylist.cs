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

  public static Stylist Find(int id)
  {
    SqlConnection connection = DB.Connection();
    connection.Open();

    SqlCommand command = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", connection);
    SqlParameter stylistIdParameter = new SqlParameter();
    stylistIdParameter.ParameterName = "@StylistId";
    stylistIdParameter.Value = id.ToString();
    command.Parameters.Add(stylistIdParameter);
    SqlDataReader reader = command.ExecuteReader();

    int foundStylistId = 0;
    string foundStylistName = null;

    while(reader.Read())
    {
      foundStylistId = reader.GetInt32(0);
      foundStylistName = reader.GetString(1);
    }

    Stylist foundStylist = new Stylist(foundStylistName, foundStylistId);

    if (reader != null)
    {
      reader.Close();
    }

    if (connection != null)
    {
      connection.Close();
    }
    return foundStylist;
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

  public void UpdateName(string newName)
  {
    SqlConnection connection = DB.Connection();
    connection.Open();

    SqlCommand command = new SqlCommand("UPDATE stylists SET name = @NewName OUTPUT INSERTED.name WHERE id = @StylistId;", connection);
    
    SqlParameter newNameParameter = new SqlParameter();
    newNameParameter.ParameterName = "@NewName";
    newNameParameter.Value = newName;
    command.Parameters.Add(newNameParameter);

    SqlParameter stylistIdParameter = new SqlParameter();
    stylistIdParameter.ParameterName = "@StylistId";
    stylistIdParameter.Value = this.GetId();
    command.Parameters.Add(stylistIdParameter);
    SqlDataReader reader = command.ExecuteReader();
    
    while(reader.Read())
    {
      this._name = reader.GetString(0);
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

  public static void Delete(int id)
  {
    SqlConnection connection = DB.Connection();
    connection.Open();
    SqlCommand command = new SqlCommand("DELETE FROM stylists WHERE id = @StylistId;", connection);
    SqlParameter stylistIdParameter = new SqlParameter();
    stylistIdParameter.ParameterName = "@StylistId";
    stylistIdParameter.Value = id.ToString();
    command.Parameters.Add(stylistIdParameter);
    command.ExecuteNonQuery();
    connection.Close();
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