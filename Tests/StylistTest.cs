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
    public void Stylist_Equal_ReturnsTrueIfNamesAreTheSame_True()
    {
      Stylist firstStylist = new Stylist("Justin Bryden");
      Stylist secondStylist = new Stylist("Justin Bryden");

      Assert.Equal(firstStylist, secondStylist);
    }
    [Fact]
    public void Test_Save()
    {
      Stylist testStylist = new Stylist("Justin Bryden");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist>{testStylist};

      Assert.Equal(testStylistList, result);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}