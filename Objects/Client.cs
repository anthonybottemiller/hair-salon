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