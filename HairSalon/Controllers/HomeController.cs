using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Stylist> myStylists = Stylist.GetAllStylists();
      return View(myStylists);
    }
    [HttpGet("/stylists/new")]
    public ActionResult StylistForm()
    {
      return View("CreateStylist");
    }
    [HttpPost("/stylists/add")]
    public ActionResult AddNewStylist()
    {
      string stylistName = Request.Form["name"];
      Stylist newStylist = new Stylist(0, stylistName);
      newStylist.AddStylist();
      return RedirectToAction("Index");
    }
    [HttpGet("/stylists/{id}")]
     public ActionResult StylistInfo(int id)
     {
         Stylist thisStylist = Stylist.FindStylist(id);
         return View("StylistInfo", thisStylist);
     }
  }
}
