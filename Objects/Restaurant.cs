using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace RestaurantProject
{
  public class Restaurant
  {

    //SIMILAR TO TASKS CLASS
    //WILL INCLUDE AUTOMATICALLY GENERATED INDIVIDUAL ID
    //WILL MATCH "CUISINE" ID AND ONLY INCLUDE ONE CUISINE
    //WILL INCLUDE
      // _restaurantName (STRING),
      // _rating (INT) to store rating 0-100,
      // _availability(STRING) to check for open or close at this moment,
      // _reviews(List<Review> of multiple reviews)empty at first but options to add in the future.
    private int _id;
    private string _name;
    private int _rating;
    private string _availability;
    private int _cuisineId;

    public Restaurant(string Name, int Rating, string Availability, int CuisineId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _rating = Rating;
      _availability = Availability;
      _cuisineId = CuisineId;
    }
    public override bool Equals(System.Object otherRestaurant)
    {
      if(!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool nameEquality = (this.GetName() == newRestaurant.GetName());
        bool ratingEquality = (this.GetRating() == newRestaurant.GetRating());
        bool availabilityEquality = (this.GetAvailability() == newRestaurant.GetAvailability());
        bool cuisineIdEquality = (this.GetCuisineId() == newRestaurant.GetCuisineId());
        return (nameEquality && ratingEquality && availabilityEquality && cuisineIdEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public int GetCuisineId()
    {
      return _cuisineId;
    }
    public void SetCuisineId(int newCuisineId)
    {
      _cuisineId = newCuisineId;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetRating()
    {
      return _rating;
    }
    public void SetRating(int newRating)
    {
      _rating = newRating;
    }
    public string GetAvailability()
    {
      return _availability;
    }
    public void SetAvailability(string newAvailability)
    {
      _availability = newAvailability;
    }
    public List<Review> GetReviews()
      {
        SqlConnection conn = DB.Connection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM review WHERE restaurant_id = @RestaurantId;", conn);
        SqlParameter restaurantIdParameter = new SqlParameter();
        restaurantIdParameter.ParameterName = "@RestaurantId";
        restaurantIdParameter.Value = this.GetId();

        cmd.Parameters.Add(restaurantIdParameter);
        SqlDataReader rdr = cmd.ExecuteReader();

        List<Review> reviews = new List<Review> {};
        while(rdr.Read())
        {
          int reviewId = rdr.GetInt32(0);
          string reviewOpinion = rdr.GetString(1);
          int reviewRestaurantId = rdr.GetInt32(3);
          Review newReview = new Review(reviewOpinion, reviewRestaurantId, reviewId);
          reviews.Add(newReview);
        }
        if (rdr != null)
        {
          rdr.Close();
        }
        if (conn != null)
        {
          conn.Close();
        }
        return reviews;
      }

    public static List<Restaurant> GetAll()
      {
        List<Restaurant> allRestaurants = new List<Restaurant>{};

        SqlConnection conn = DB.Connection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant;", conn);
        SqlDataReader rdr = cmd.ExecuteReader();

        while(rdr.Read())
        {
          int restaurantId = rdr.GetInt32(0);
          string restaurantName = rdr.GetString(1);
          string restaurantAvailability = rdr.GetString(3);
          int restaurantRating = rdr.GetInt32(2);
          int restaurantCuisineId = rdr.GetInt32(4);
          Restaurant newRestaurant = new Restaurant(restaurantName, restaurantRating, restaurantAvailability, restaurantCuisineId, restaurantId);
          allRestaurants.Add(newRestaurant);
        }

        if (rdr != null)
        {
          rdr.Close();
        }
        if (conn != null)
        {
          conn.Close();
        }

        return allRestaurants;
      }
      public void Save()
      {
        SqlConnection conn = DB.Connection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("INSERT INTO restaurant (name, rating, availability, cuisineId) OUTPUT INSERTED.id VALUES (@RestaurantName, @RestaurantRating, @RestaurantAvailability, @RestaurantCuisineId);", conn);

        SqlParameter nameParameter = new SqlParameter();
        nameParameter.ParameterName = "@RestaurantName";
        nameParameter.Value = this.GetName();

        SqlParameter ratingParameter = new SqlParameter();
        ratingParameter.ParameterName = "@RestaurantRating";
        ratingParameter.Value = this.GetRating();

        SqlParameter availabilityParameter = new SqlParameter();
        availabilityParameter.ParameterName = "@RestaurantAvailability";
        availabilityParameter.Value = this.GetAvailability();

        SqlParameter cuisineIdParameter = new SqlParameter();
        cuisineIdParameter.ParameterName = "@RestaurantCuisineId";
        cuisineIdParameter.Value = this.GetCuisineId();

        cmd.Parameters.Add(nameParameter);
        cmd.Parameters.Add(ratingParameter);
        cmd.Parameters.Add(availabilityParameter);
        cmd.Parameters.Add(cuisineIdParameter);
        SqlDataReader rdr = cmd.ExecuteReader();

        while(rdr.Read())
        {
          this._id = rdr.GetInt32(0);
        }
        if (rdr != null)
        {
          rdr.Close();
        }
        if (conn != null)
        {
          conn.Close();
        }
      }
      public static Restaurant Find(int id)
      {
        SqlConnection conn = DB.Connection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant WHERE id = @RestaurantId;", conn);
        SqlParameter restaurantIdParameter = new SqlParameter();
        restaurantIdParameter.ParameterName = "@RestaurantId";
        restaurantIdParameter.Value = id.ToString();
        cmd.Parameters.Add(restaurantIdParameter);
        SqlDataReader rdr = cmd.ExecuteReader();

        int foundRestaurantId = 0;
        string foundRestaurantName = null;
        int foundRestaurantRating = 0;
        string foundRestaurantAvailability = null;
        int foundRestaurantCuisineId = 0;
        while(rdr.Read())
        {
          foundRestaurantId = rdr.GetInt32(0);
          foundRestaurantName = rdr.GetString(1);
          foundRestaurantRating = rdr.GetInt(2);
          foundRestaurantAvailability = rdr.GetString(3);
          foundRestaurantCuisineId = rdr.GetInt32(4);
        }
        Restaurant foundRestaurant = new Restaurant(foundRestaurantName, foundRestaurantRating, foundRestaurantAvailability, foundRestaurantCuisineId, foundRestaurantId);

        if (rdr != null)
        {
          rdr.Close();
        }
        if (conn != null)
        {
          conn.Close();
        }
        return foundRestaurant;
      }
      public static void DeleteAll()
      {
        SqlConnection conn = DB.Connection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM restaurant;", conn);
        cmd.ExecuteNonQuery();
        conn.Close();
      }
  }
}
