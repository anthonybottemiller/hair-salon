using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    
    [Fact]
    public void Client_Equal_ReturnsTrueIfNamesAreTheSame_True()
    {
      Client firstClient = new Client("Miranda Gaffeney",0);
      Client secondClient = new Client("Miranda Gaffeney",0);

      Assert.Equal(firstClient, secondClient);
    }    
  }
}