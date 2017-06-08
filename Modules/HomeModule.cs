using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace RestaurantProject
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var allCuisines = Cuisine.GetAll();
        var allRestaurants = Restaurant.GetAll();
        model.Add("cuisines", allCuisines);
        model.Add("restaurants", allRestaurants);
        return View["index.cshtml", model];
      };
      Get["/restaurant/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedRestaurant = Restaurant.Find(parameters.id);
        var SelectedCuisine = Cuisine.Find(SelectedRestaurant.GetCuisineId());
        List<Review> allReviews = SelectedRestaurant.GetReviews();
        model.Add("restaurantReviews", allReviews);
        model.Add("currentCuisine", SelectedCuisine);
        model.Add("currentRestaurant", SelectedRestaurant);
        return View["restaurant.cshtml", model];
      };
      Post["/restaurant/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedRestaurant = Restaurant.Find(parameters.id);
        var SelectedCuisine = Cuisine.Find(SelectedRestaurant.GetCuisineId());
        List<Review> allReviews = SelectedRestaurant.GetReviews();
        Review newReview = new Review(Request.Form["opinion"], SelectedRestaurant.GetId());
        allReviews.Add(newReview);
        newReview.Save();
        model.Add("restaurantReviews", allReviews);
        model.Add("currentCuisine", SelectedCuisine);
        model.Add("currentRestaurant", SelectedRestaurant);
        return View["restaurant.cshtml", model];
      };
      Post["/"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var allCuisines = Cuisine.GetAll();
        var allRestaurants = Restaurant.GetAll();
        Restaurant newRestaurant = new Restaurant(Request.Form["name"], 0, Request.Form["availability"], Request.Form["cuisine_id"], Request.Form["address"], Request.Form["takeOut"], Request.Form["phone"]);
        allRestaurants.Add(newRestaurant);
        newRestaurant.Save();
        model.Add("cuisines", allCuisines);
        model.Add("restaurants", allRestaurants);
        return View["index.cshtml", model];
      };
    }
  }
}
