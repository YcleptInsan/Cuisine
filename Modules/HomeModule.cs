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
      Get["/restaurant"] = _ => {
        List<Task> AllTasks = Task.GetAll();
        return View["restaurants.cshtml", AllTasks];
      };

      Get["/cuisine"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["cuisine.cshtml", AllCuisine];
      };

      Get["/cuisine/new"] = _ => {
        return View["cuisine_form.cshtml"];
      };
      Post["/cuisine/new"] = _ => {
       Cuisine newCuisine = new Cuisine(Request.Form["cuisine-type"]);
       newCuisine.Save();
       return View["success.cshtml"];
      };
      Get["/restaurant/new"] = _ => {
        List<Cuisine> AllCuisine = Cuisine.GetAll();
        return View["restaurant_form.cshtml", AllCuisine];
      };
      Post["/restaurant/new"] = _ => {
        Task newTask = new Task(Request.Form["restaurant-name"], Request.Form["cuisine-id"]);
        newTask.Save();
        return View["success.cshtml"];
       };

       Post["/restaurant/delete"] = _ => {
         Task.DeleteAll();
         return View["cleared.cshtml"];
       };

       Get["/cuisine/{id}"] = parameters => {
         Dictionary<string, object> model = new Dictionary<string, object>();
         var SelectedCuisine = Cuisine.Find(parameters.id);
         var CuisineTasks = SelectedCuisine.GetTasks();
         model.Add("cuisine", SelectedCuisine);
         model.Add("restaurant", CuisineTasks);

         return View["cuisine.cshtml", model];
      };

      Get["cuisine/edit/{id}"] = parameters => {
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);

      return View["cuisine_edit.cshtml", SelectedCuisine];
      };

      Patch["cuisine/edit/{id}"] = parameters => {
        Cuisine SelectedCuisine = Cuisine.Find(parameters.id);
        SelectedCuisine.Update(Request.Form["cuisine-name"]);

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
