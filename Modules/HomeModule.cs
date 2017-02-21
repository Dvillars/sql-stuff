using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Inventory
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                List<Bills_PC> AllPokemon = Bills_PC.GetAll();
                return View["index.cshtml", AllPokemon];
            };

            Post["/pc"] = _ =>
            {
                Bills_PC newEntry = new Bills_PC(Request.Form["dex-no"], Request.Form["name"], Request.Form["nick-name"], Request.Form["lv"]);
                newEntry.Save();
                List<Bills_PC> AllPokemon = Bills_PC.GetAll();
                return View["index.cshtml", AllPokemon];
            };

            Post["/DeleteAll"] = _ =>
            {
                Bills_PC.DeleteAll();
                List<Bills_PC> AllPokemon = Bills_PC.GetAll();
                return View["index.cshtml", AllPokemon];
            };

            Post["/release"] = _ =>
            {
                foreach (string pokemon in Request.Form["pokemon"])
                {
                    Bills_PC.DeleteOne(pokemon);
                }
                List<Bills_PC> AllPokemon = Bills_PC.GetAll();
                return View["index.cshtml", AllPokemon];
            };
        }
    }
}
