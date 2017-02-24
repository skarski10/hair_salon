using Nancy;
using HairSalonApp;
using System.Collections.Generic;

namespace HairSalonApp
{
    public class HomeModule: NancyModule
    {
        public HomeModule()
        {
            // Take you to the homepage
            Get["/"] = _ => {
                return View["index.cshtml"];
            };

            // take you to the stylist page
            Get["/stylists"] = _ => {
                var stylistList = Stylist.GetAll();
                return View["stylists.cshtml", stylistList];
            };

            // Post the enter stylist name onto the stylists page
            Post["/stylists"] = _ => {
                var newStylist = new Stylist(Request.Form["stylist"]);
                newStylist.Save();
                var stylistList = Stylist.GetAll();
                return View["stylists.cshtml", stylistList];
            };









            // Get an id for each stylist and take you to the clicked on stylists restaurant page
            Get["/stylists/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>();
                Cuisine selectedCuisine = Cuisine.Find(parameters.id);
                List<Restaurant> addedRestaurants = selectedCuisine.GetRestaurants();
                model.Add("restaurant", addedRestaurants);
                model.Add("stylist", selectedCuisine);
                return View["restaurants.cshtml", model];
            };









        }
    }
}
