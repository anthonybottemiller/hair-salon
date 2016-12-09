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
      Get["/stylist/{id}"] = parameters => {
        var selectedStylist = Stylist.Find(parameters.id);
        var stylistsClients = selectedStylist.GetClients();
        return View["stylist.cshtml", stylistsClients];
      };
    }
  }
}