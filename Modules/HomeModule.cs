using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

      Get["/stylists/new"] = _ => {
        return View["stylist-form.cshtml"];
      };

      Post["/stylists"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["new-stylist-success.cshtml", newStylist];
      };

      Get["/stylists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedStylist = Stylist.Find(parameters.id);
        var stylistsClients = selectedStylist.GetClients();
        model.Add("stylist", selectedStylist);
        model.Add("clients", stylistsClients);
        return View["stylist.cshtml", model];
      };

      Get["/clients/new"] = _ => {
        var stylists = Stylist.GetAll();
        return View["new-client.cshtml", stylists];
      };

      Post["/clients"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["new-client-success.cshtml", newClient];
      };
    }
  }
}