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
        Dictionary<string, object> model = new Dictionary<string, object>();
        List<Stylist> allStylists = Stylist.GetAll();
        List<Client> allClients = Client.GetAll();
        model.Add("stylists", allStylists);
        model.Add("clients", allClients);
        return View["index.cshtml", model];
      };

      Get["/stylists/new"] = _ => {
        return View["stylist-form.cshtml"];
      };

      Post["/stylists"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["new-stylist-success.cshtml", newStylist];
      };

      Get["/stylists/edit/{id}"] = parameters => {
        var foundStylist = Stylist.Find(parameters.id);
        return View["edit-stylist.cshtml", foundStylist];
      };

      Patch["/stylists/edit/{id}"] = parameters => {
        var foundStylist = Stylist.Find(parameters.id);
        string newName = Request.Form["stylist-name"];
        foundStylist.UpdateName(newName);
        var updatedStylist = Stylist.Find(parameters.id);
        return View["stylist-updated.cshtml", updatedStylist];
      };

      Get["/stylists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedStylist = Stylist.Find(parameters.id);
        var stylistsClients = selectedStylist.GetClients();
        model.Add("stylist", selectedStylist);
        model.Add("clients", stylistsClients);
        return View["stylist.cshtml", model];
      };

      Get["/stylists/delete/{id}"] = parameters => {
        Stylist foundStylist = Stylist.Find(parameters.id);
        return View["delete-stylist.cshtml", foundStylist];
      };

      Delete["/stylists/delete/{id}"] = parameters => {
        Stylist.Delete(parameters.id);
        return View["stylist-deleted.cshtml"];
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

      Get["/clients/edit/{id}"] = parameters => {
        var foundClient = Client.Find(parameters.id);
        return View["edit-client.cshtml", foundClient];
      };

      Patch["/clients/edit/{id}"] = parameters => {
        var foundClient = Client.Find(parameters.id);
        foundClient.UpdateName(Request.Form["client-name"]);
        return View["client-updated.cshtml", foundClient];
      };

      Get["/clients/delete/{id}"] = parameters => {
        var foundClient = Client.Find(parameters.id);
        return View["delete-client", foundClient];
      };

      Delete["/clients/delete/{id}"] = parameters => {
        Client.Delete(parameters.id);
        return View["client-deleted.cshtml"];
      };
    }
  }
}