using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantProject
{
  [Collection("RestaurantProject")]
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=portland_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_CuisineRetrieval_Returns0_Listings()
    {
      int result = Cuisine.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      //Arrange, Act
      Cuisine firstCuisine = new Cuisine("Chinese");
      Cuisine secondCuisine = new Cuisine("Chinese");

      //Assert
      Assert.Equal(firstCuisine, secondCuisine);
    }
    [Fact]
    public void Test_Save_SavesCuisineToDatabase()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Chinese");
      testCuisine.Save();

      //Act
      List<Cuisine> result = Cuisine.GetAll();
      List<Cuisine> testList = new List<Cuisine>{testCuisine};

      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_Find_FindsCuisineInDatabase()
    {
      //Arrange
      Cuisine testCuisine = new Cuisine("Chinese");
      testCuisine.Save();

      //Act
      Cuisine foundCuisine = Cuisine.Find(testCuisine.GetId());

      //Assert
      Assert.Equal(testCuisine, foundCuisine);
    }
    [Fact]
    public void Test_GetRestaurants_RetrievesAllRestaurantsWithCuisine()
    {
      Cuisine testCuisine = new Cuisine("Chinese");
      testCuisine.Save();

      Restaurant firstRestaurant = new Restaurant("Wong's", 4, "Closed", testCuisine.GetId(), "123 Address Road", "true", "503-405-3054");
      firstRestaurant.Save();
      Restaurant secondRestaurant = new Restaurant("Jimmy Johns", 1, "Closed", testCuisine.GetId(), "321 Road AddressRd", "true", "504-345-0090");
      secondRestaurant.Save();


      List<Restaurant> testRestaurantList = new List<Restaurant> {firstRestaurant, secondRestaurant};
      List<Restaurant> resultRestaurantList = testCuisine.GetRestaurants();

      Assert.Equal(testRestaurantList, resultRestaurantList);
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
