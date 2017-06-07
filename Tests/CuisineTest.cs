using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantProject
{
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=portland_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_CuisineEmptyAtFirst()
    {
      int result = Cuisine.GetAll().Count;
      Assert.Equal(4, result);
    }
    public void Dispose()
    {
      Restaurant.DeleteAll();
      Cuisine.DeleteAll();
    }
  }
}

// Tests/Specs
//
// Empty Cuisine List at first
// Returns True if Restaurant Names are the same
// Assigns Cuisine_Id to Restaurant when it's saved
// Search and Find Restaurant
//
// (WISHLIST)
// Owners admin to alter individual restaurant information
// Change availability to DATETIME instead of STRING
//Review affect rating.
