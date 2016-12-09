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

    [Fact]
    public void Client_Save_SavesAssignsIdToObject()
    {
      Client testClient = new Client("Miranda Gaffeney",2);
      testClient.Save();

      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Client_Save_SavesAssignsStylistIdToObject()
    {
      Client testClient = new Client("Miranda Gaffeney",2);
      testClient.Save();

      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetStylistId();
      int testId = testClient.GetStylistId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Client_Find_FindsClientInDatabase()
    {
      Client testClient = new Client("Miranda Gaffeney",2);
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());

      Assert.Equal(testClient, foundClient);
    }

    [Fact]
    public void Client_Delete_DeleteClientInDatabase()
    {
      Client testClientZero = new Client("Miranda Gaffeney",2);
      testClientZero.Save();
      Client testClientOne = new Client("Gary Jules",2);
      testClientOne.Save();

      Client.Delete(testClientZero.GetId());
      List<Client> testList = new List<Client>{testClientOne};
      var foundClients = Client.GetAll();

      Assert.Equal(testList, foundClients);
    }

        [Fact]
    public void Client_UpdateName_UpdateClientInDatabase()
    {
      Client testClient = new Client("Miranda Gaffeney", 2);
      testClient.Save();
      string newName = "Miranda H Gaffeney";

      testClient.Update(newName);

      string result = testClient.GetName();

      Assert.Equal(newName, result);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}