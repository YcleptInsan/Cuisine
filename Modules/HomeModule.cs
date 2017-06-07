using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BestRestaurants
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["index.cshtml", AllCuisine];
      };
      Get["/restaurants"] = _ => {
        List<Restaurant> AllResturants = Restaurant.GetAll();
        return View["restaurants.cshtml", AllResturants];
      };

      Get["/cuisines"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["cuisines.cshtml", AllCuisine];
      };

      Get["/cuisines/new"] = _ => {
        return View["cuisines_form.cshtml"];
      };
      Post["/cuisines/new"] = _ => {
       Cuisine newCuisine = new Cuisine(Request.Form["cuisine-type"]);
       newCuisine.Save();
       return View["success.cshtml"];
      };
      Get["/restaurants/new"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["restaurants_form.cshtml", AllCuisine];
      };
      Post["/restaurants/new"] = _ => {
        Restaurant newRestaurant = new Restaurant(Request.Form["restaurant-name"], Request.Form["cuisine-id"]);
        newRestaurant.Save();
        return View["success.cshtml"];
       };

       Post["/restaurants/delete"] = _ => {
         Restaurant.DeleteAll();
         return View["cleared.cshtml"];
       };

       Get["/cuisines/{id}"] = parameters => {
         Dictionary<string, object> model = new Dictionary<string, object>();
         var SelectedCuisine = Cuisine.Find(parameters.id);
         var CuisineRestaurants = SelectedCuisine.GetRestaurants();
         model.Add("cuisine", SelectedCuisine);
         model.Add("restaurants", CuisineRestaurants);

         return View["cuisine.cshtml", model];
      };

      Get["cuisine/edit/{id}"] = parameters => {
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);

      return View["cuisine_edit.cshtml", SelectedCuisine];
      };

      Patch["cuisine/edit/{id}"] = parameters => {
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
        SelectedCuisine.Update(Request.Form["cuisine-type"]);

      return View["success.cshtml"];
      };

      Get["cuisine/delete/{id}"] = parameters => {
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
        return View["cuisine_delete.cshtml", SelectedCuisine];
      };

      Delete["cuisine/delete/{id}"] = parameters => {
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
        SelectedCuisine.Delete();
        return View["success.cshtml"];
      };
    }
  }
}
