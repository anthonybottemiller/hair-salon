using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class HairSalon : IDisposable
  {
    public void HairSalonTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
    
    [Fact]
    public void Client_Equal_ReturnsTrueIfNamesAreTheSame_True()
    {
      Client firstClient = new Client("Miranda Gaffeney");
      Client secondClient = new Client("Miranda Gaffeney");

      Assert.Equal(firstClient, secondClient);
    }    
  }
}