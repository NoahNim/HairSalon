using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest
  {
    [TestMethod]
    public void TestStylistCreation()
    {
      Stylist myStylist = new Stylist(1, "Kayla");
      myStylist.AddStylist();
      List<Stylist> StylistsList = Stylist.GetAllStylists();
      Assert.AreEqual("Kayle", StylistsList[0].GetName());
    }

    [TestMethod]
    public void TestFindStylist()
    {
      Stylist myStylist = new Stylist(1, "Kayla");
      myStylist.AddStylist();
      Stylist searchedId = Stylist.FindStylist(myStylist.GetId());
      Assert.AreEqual("Kayle", searchedId.GetName());
    }
    [TestMethod]
    public void TestAddClient()
    {
      Client myClient = new Client("Jack", 1);
      myClient.AddClient();
      List<Client> ClientList = Client.GetAllClients();
      Assert.AreEqual("Jack", ClientList[0].GetClientName());
    }
  }
}
