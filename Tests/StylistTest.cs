using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Stylist_Equal_ReturnsTrueIfNamesAreTheSame_True()
    {
      Stylist firstStylist = new Stylist("Justin Bryden");
      Stylist secondStylist = new Stylist("Justin Bryden");

      Assert.Equal(firstStylist, secondStylist);
    }

    [Fact]
    public void Stylist_Save_SavesStylistToDatabase()
    {
      Stylist testStylist = new Stylist("Justin Bryden");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist>{testStylist};

      Assert.Equal(testStylistList, result);
    }

    [Fact]
    public void Stylist_Save_SavesAssignsIdToObject()
    {
      Stylist testStylist = new Stylist("Justin Bryden");
      testStylist.Save();

      Stylist savedStylist = Stylist.GetAll()[0];

      int result = savedStylist.GetId();
      int testId = testStylist.GetId();

      Assert.Equal(testId, result);
    }

    [Fact]
    public void Stylist_Find_FindsStylistInDatabase()
    {
      Stylist testStylist = new Stylist("Justin Bryden");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }

    [Fact]
    public void Stylist_Delete_DeleteStylistInDatabase()
    {
      Stylist testStylistZero = new Stylist("Justin Bryden");
      testStylistZero.Save();
      Stylist testStylistOne = new Stylist("Jennifer Krause");
      testStylistOne.Save();

      Stylist.Delete(testStylistZero.GetId());
      List<Stylist> testList = new List<Stylist>{testStylistOne};
      var foundStylists = Stylist.GetAll();

      Assert.Equal(testList, foundStylists);
    }

    [Fact]
    public void Stylist_UpdateName_UpdateStylistInDatabase()
    {
      Stylist testStylist = new Stylist("Justin Bryden");
      testStylist.Save();
      string newName = "Justin A Bryden";

      testStylist.UpdateName(newName);

      string result = testStylist.GetName();

      Assert.Equal(newName, result);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}