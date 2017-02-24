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









            // Get an id for each stylist and take you to the clicked on stylists client page
            Get["/stylists/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>();
                Stylist selectedStylist = Stylist.Find(parameters.id);
                List<Client> addedClients = selectedStylist.GetClients();
                model.Add("client", addedClients);
                model.Add("stylist", selectedStylist);
                return View["clients.cshtml", model];
            };

            // Take the client entered and post in on the clients page
            Post["/stylist/{id}/clients"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>();
                Stylist selectedStylist = Stylist.Find(Request.Form["stylist"]);
                List<Client> stylistClient = selectedStylist.GetClients();
                string clientEntered = Request.Form["client"];
                Client newClient = new Client(clientEntered, selectedStylist.GetStylistId());
                newClient.Save();
                stylistClient.Add(newClient);
                model.Add("client", stylistClient);
                model.Add("stylist", selectedStylist);
                return View["clients.cshtml", model];
            };









        }
    }
}
