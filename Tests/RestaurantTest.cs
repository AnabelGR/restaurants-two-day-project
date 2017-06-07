using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantProject
{
  public class RestaurantTest : IDisposable
  {
    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=portland_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Restaurant.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      Restaurant firstRestaurant = new Restaurant("Mow the lawn", 1, "Open", 1);
      Restaurant secondRestaurant = new Restaurant("Mow the lawn", 1, "Open", 1);

      //Assert
      Assert.Equal(firstRestaurant, secondRestaurant);
    }
    [Fact]
    public void Test_SaveAssignsIdToObject()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Mow the lawn", 3, "Closed Tuesdays", 1);
      testRestaurant.Save();

      //Act
      Restaurant savedRestaurant = Restaurant.GetAll()[0];

      int result = savedRestaurant.GetId();
      int testId = testRestaurant.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsRestaurantInDatabase()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Mow the lawn", 4, "Monday", 1);
      testRestaurant.Save();

      //Act
      Restaurant foundRestaurant = Restaurant.Find(testRestaurant.GetId());

      //Assert
      Assert.Equal(testRestaurant, foundRestaurant);
    }
    public void Dispose()
    {
      Restaurant.DeleteAll();
    }
  }
}
