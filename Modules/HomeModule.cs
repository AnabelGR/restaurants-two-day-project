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
    }
  }
}
