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
    private string _address;
    private string _takeOut;
    private string _phone;


    public Restaurant(string Name, int Rating, string Availability, int CuisineId, string Address, string TakeOut, string Phone, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _rating = Rating;
      _availability = Availability;
      _cuisineId = CuisineId;
      _address = Address;
      _takeOut = TakeOut;
      _phone = Phone;
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
        bool addressEquality = (this.GetAddress() == newRestaurant.GetAddress());
        bool takeOutEquality = (this.GetTakeOut() == newRestaurant.GetTakeOut());
        bool phoneEquality = (this.GetPhone() == newRestaurant.GetPhone());
        return (nameEquality && ratingEquality && availabilityEquality && cuisineIdEquality && addressEquality && takeOutEquality && phoneEquality);
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
    public string GetAddress()
    {
      return _address;
    }
    public void SetAddress(string newAddress)
    {
      _address = newAddress;
    }
    public string GetTakeOut()
    {
      return _takeOut;
    }
    public void SetTakeOut(string newTakeOut)
    {
      _takeOut = newTakeOut;
    }
    public string GetPhone()
    {
      return _phone;
    }
    public void SetPhone(string newPhone)
    {
      _phone = newPhone;
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
          int reviewRestaurantId = rdr.GetInt32(2);
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
          string restaurantAddress = rdr.GetString(5);
          string restaurantTakeOut = rdr.GetString(6);
          string restaurantPhone = rdr.GetString(7);
          Restaurant newRestaurant = new Restaurant(restaurantName, restaurantRating, restaurantAvailability, restaurantCuisineId, restaurantAddress, restaurantTakeOut, restaurantPhone, restaurantId);
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

        SqlCommand cmd = new SqlCommand("INSERT INTO restaurant (name, rating, availability, cuisine_Id, address, takeout, phone) OUTPUT INSERTED.id VALUES (@RestaurantName, @RestaurantRating, @RestaurantAvailability, @RestaurantCuisineId, @RestaurantAddress, @RestaurantTakeOut, @RestaurantPhone);", conn);

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

        SqlParameter addressParameter = new SqlParameter();
        addressParameter.ParameterName = "@RestaurantAddress";
        addressParameter.Value = this.GetAddress();

        SqlParameter takeOutParameter = new SqlParameter();
        takeOutParameter.ParameterName = "@RestaurantTakeOut";
        takeOutParameter.Value = this.GetTakeOut();

        SqlParameter phoneParameter = new SqlParameter();
        phoneParameter.ParameterName = "@RestaurantPhone";
        phoneParameter.Value = this.GetPhone();

        cmd.Parameters.Add(nameParameter);
        cmd.Parameters.Add(ratingParameter);
        cmd.Parameters.Add(availabilityParameter);
        cmd.Parameters.Add(cuisineIdParameter);
        cmd.Parameters.Add(addressParameter);
        cmd.Parameters.Add(takeOutParameter);
        cmd.Parameters.Add(phoneParameter);
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
        string foundRestaurantAddress = null;
        string foundRestaurantTakeOut = null;
        string foundRestaurantPhone = null;
        while(rdr.Read())
        {
          foundRestaurantId = rdr.GetInt32(0);
          foundRestaurantName = rdr.GetString(1);
          foundRestaurantRating = rdr.GetInt32(2);
          foundRestaurantAvailability = rdr.GetString(3);
          foundRestaurantCuisineId = rdr.GetInt32(4);
          foundRestaurantAddress = rdr.GetString(5);
          foundRestaurantTakeOut = rdr.GetString(6);
          foundRestaurantPhone = rdr.GetString(7);
        }
        Restaurant foundRestaurant = new Restaurant(foundRestaurantName, foundRestaurantRating, foundRestaurantAvailability, foundRestaurantCuisineId, foundRestaurantAddress, foundRestaurantTakeOut, foundRestaurantPhone, foundRestaurantId);

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
