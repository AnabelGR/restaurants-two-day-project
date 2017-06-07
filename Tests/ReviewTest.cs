using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantProject
{
  public class ReviewTest : IDisposable
  {
    public ReviewTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=portland_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Review.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //Arrange, Act
      Review firstReview = new Review("Fuck this restaurant", 1);
      Review secondReview = new Review("Fuck this restaurant", 1);

      //Assert
      Assert.Equal(firstReview, secondReview);
    }
    [Fact]
    public void Test_SaveAssignsIdToObject()
    {
      //Arrange
      Review testReview = new Review("Mow the damn lawn and we'll come back", 3);
      testReview.Save();

      //Act
      Review savedReview = Review.GetAll()[0];

      int result = savedReview.GetId();
      int testId = testReview.GetId();

      //Assert
      Assert.Equal(testId, result);
    }
    public void Dispose()
    {
      Review.DeleteAll();
    }
  }
}
