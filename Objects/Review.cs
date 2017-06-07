// Will include a automatically generated Id
// Will include a string for the reviews
// Will include restaurant id to match single restaurant
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace RestaurantProject
{
  public class Review
  {

    // SIMILAR TO "CATEGORY" CLASS
    // WILL INCLUDE AUTOMATICALLY GENERATED ID
    // WILL INCLUDE NAME/TYPE OF CUISINE FOR THE "RESTAURANT" CLASS TO REFERENCE
    private int _id;
    private string _opinion;
    private int _restaurantId;

    public Review(string Opinion, int RestaurantId, int Id = 0)
    {
      _id = Id;
      _restaurantId = RestaurantId;
      _opinion = Opinion;
    }

    public override bool Equals(System.Object otherReview)
    {
      if (!(otherReview is Review))
      {
        return false;
      }
      else
      {
        Review newReview = (Review) otherReview;
        bool idEquality = this.GetId() == newReview.GetId();
        bool restaurantIdEquality = this.GetRestaurantId() == newReview.GetRestaurantId();
        bool opinionEquality = this.GetOpinion() == newReview.GetOpinion();
        return (idEquality && opinionEquality && restaurantIdEquality);
      }
    }

    public int GetId()
    {
      return _id;
    }
    public int GetRestaurantId()
    {
      return _restaurantId;
    }
    public void SetRestaurantId(int newRestaurantId)
    {
      _restaurantId = newRestaurantId;
    }
    public string GetOpinion()
    {
      return _opinion;
    }
    public void SetOpinion(string newOpinion)
    {
      _opinion = newOpinion;
    }

    public static List<Review> GetAll()
    {
      List<Review> allReviews = new List<Review>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM review;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int reviewId = rdr.GetInt32(0);
        string reviewOpinion = rdr.GetString(1);
        int reviewRestaurantId = rdr.GetInt32(2);
        Review newReview = new Review(reviewOpinion, reviewRestaurantId, reviewId);
        allReviews.Add(newReview);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allReviews;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO review (opinion, restaurant_id) OUTPUT INSERTED.id VALUES (@ReviewOpinion, @ReviewRestaurantId);", conn);

      SqlParameter opinionParameter = new SqlParameter();
      opinionParameter.ParameterName = "@ReviewOpinion";
      opinionParameter.Value = this.GetOpinion();
      cmd.Parameters.Add(opinionParameter);

      SqlParameter restaurantIdParameter = new SqlParameter();
      restaurantIdParameter.ParameterName = "@ReviewRestaurantId";
      restaurantIdParameter.Value = this.GetRestaurantId();
      cmd.Parameters.Add(restaurantIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM review WHERE id = @ReviewId;", conn);

      SqlParameter reviewIdParameter = new SqlParameter();
      reviewIdParameter.ParameterName = "@ReviewId";
      reviewIdParameter.Value = this.GetId();

      cmd.Parameters.Add(reviewIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM review;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
