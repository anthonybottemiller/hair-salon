using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
  public class Client
  {
    private int _id;
    private int _stylistId;
    private string _name;
  public Client(String Name, int StylistId, int Id = 0)
  {
    _id = Id;
    _stylistId = StylistId;
    _name = Name;
  }

  public int GetId()
  {
    return _id;
  }

  public string GetName()
  {
    return _name;
  }

  public int GetStylistId()
  {
    return _stylistId;
  }

  public static List<Client> GetAll()
  {
    List<Client> allClients = new List<Client>{};

    SqlConnection connection = DB.Connection();
    connection.Open();
    
    SqlCommand command = new SqlCommand("SELECT * FROM clients;", connection);      
    SqlDataReader reader = command.ExecuteReader();

    while(reader.Read())
    {
      int clientId = reader.GetInt32(0);
      int stylistId = reader.GetInt32(1);
      string clientName = reader.GetString(2);
      Client newClient = new Client(clientName, stylistId, clientId);
      allClients.Add(newClient);
    }

    if (reader != null)
    {
      reader.Close();
    }

    if (connection != null)
    {
      connection.Close();
    }

    return allClients;
  }

  public void Save()
  {
    SqlConnection connection = DB.Connection();
    connection.Open();

    SqlCommand command = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @StylistId);", connection);

    SqlParameter nameParameter = new SqlParameter();
    nameParameter.ParameterName = "@ClientName";
    nameParameter.Value = this.GetName();
    command.Parameters.Add(nameParameter);

    SqlParameter idParameter = new SqlParameter();
    idParameter.ParameterName = "@StylistId";
    idParameter.Value = this.GetStylistId();
    command.Parameters.Add(idParameter);

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
    SqlCommand cmd = new SqlCommand("DELETE FROM clients;", connection);
    cmd.ExecuteNonQuery();
    connection.Close();
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
      bool idEquality = this.GetId() == newClient.GetId();
      bool nameEquality = this.GetName() == newClient.GetName();
      bool stylistIdEquality = this.GetStylistId() == newClient.GetStylistId();
      return (nameEquality && idEquality && stylistIdEquality);
    }
  }
  
  public override int GetHashCode()
  {
    return this.GetName().GetHashCode();
  }

  }
}