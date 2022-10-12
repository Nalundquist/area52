using Area52.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Area52.Controllers
{
  public class SpeciesController : Controller
  {
    private readonly Area52Context _db;

    public SpeciesController(Area52Context db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Species.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "PlanetName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Specii specii)
    {
      _db.Species.Add(specii);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Specii thisSpecii = _db.Species
        .Include(specii => specii.JoinEntSpec)
        .ThenInclude(join => join.Specii)
        .Include(specii => specii.JoinPlanSpec)
        .ThenInclude(join => join.Specii)
        .FirstOrDefault(specii => specii.SpeciiId == id);
      return View(thisSpecii);
    }

    public ActionResult Edit(int id)
    {
      Specii thisSpecii = _db.Species.FirstOrDefault(specii => specii.SpeciiId == id);
      return View(thisSpecii);
    }

    [HttpPost]
    public ActionResult Edit(Specii specii)
    {
      _db.Entry(specii).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Specii thisSpecii = _db.Species.FirstOrDefault(specii => specii.SpeciiId == id);
      return View(thisSpecii);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Specii thisSpecii = _db.Species.FirstOrDefault(specii => specii.SpeciiId == id);
      _db.Species.Remove(thisSpecii);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddPlanet(int id)
		{
			Specii thisSpecii = _db.Species.FirstOrDefault(specii => specii.SpeciiId == id);
			ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "PlanetName");
			return View(thisSpecii);
		}

    [HttpPost]
		public ActionResult AddPlanet(Specii specii, int PlanetId)
		{
			_db.PlanetSpecii.Add(new PlanetSpecii() { PlanetId = PlanetId, SpeciiId = specii.SpeciiId});
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

    public ActionResult DeletePlanet(int id)
		{
			PlanetSpecii thisJoin = _db.PlanetSpecii.FirstOrDefault(join => join.PlanetSpeciiId == id);
			_db.PlanetSpecii.Remove(thisJoin);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
  }
}
