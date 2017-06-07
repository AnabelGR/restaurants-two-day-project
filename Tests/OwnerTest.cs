using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantProject
{
  public class OwnerTest
  {
    [Fact]
    public void TestCheckPasswordFunction_ReturnFalse()
    {
      Owner newOwner = new Owner("Jun Fritz", "password");
      Assert.Equal(false, newOwner.CheckPassword());
    }
    [Fact]
    public void TestCheckPasswordFunction_ReturnTrue()
    {
      Owner newOwner = new Owner("admin", "pa55w0rd");
      Assert.Equal(true, newOwner.CheckPassword());
    }
  }
}
