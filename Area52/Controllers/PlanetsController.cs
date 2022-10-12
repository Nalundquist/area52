using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Area52.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Area52.Controllers
{
  public class PlanetsController : Controller
  {
    private readonly Area52Context _db;

    public PlanetsController(Area52Context db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Planets.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Planet planet)
    {
      _db.Planets.Add(planet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Planet thisPlanet = _db.Planets
        .Include(planet => planet.JoinEntPlan)
        .ThenInclude(join => join.Planet)
        .Include(planet => planet.JoinPlanSpec)
        .ThenInclude(join => join.Planet)
        .FirstOrDefault(planet => planet.PlanetId == id);
      return View(thisPlanet);
    }

    public ActionResult Edit(int id)
    {
      Planet thisPlanet = _db.Planets.FirstOrDefault(planet => planet.PlanetId == id);
      return View(thisPlanet);
    }

    [HttpPost]
    public ActionResult Edit(Planet planet)
    {
      _db.Entry(planet).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Planet thisPlanet = _db.Planets.FirstOrDefault(planet => planet.PlanetId ==id);
      return View(thisPlanet);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Planet thisPlanet = _db.Planets.FirstOrDefault(planet => planet.PlanetId == id);
      _db.Planets.Remove(thisPlanet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}