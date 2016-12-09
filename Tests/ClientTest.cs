using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class ClientTest : IDisposable
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

    [Fact]
    public void Client_Save_SavesClientToDatabase()
    {
      Client testClient = new Client("Miranda Gaffeney",2);
      testClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> testClientList = new List<Client>{testClient};

      Assert.Equal(testClientList, result);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}