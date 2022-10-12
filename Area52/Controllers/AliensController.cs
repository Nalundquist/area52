using Area52.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Area52.Controllers
{
  public class AliensController : Controller
  {
    private readonly Area52Context _db;

    public AliensController(Area52Context db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Aliens.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.SpeciiId = new SelectList(_db.Species, "SpeciiId", "SpeciiName");
      ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "PlanetName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Alien alien, int SpeciiId, int PlanetId)
    {
      _db.Aliens.Add(alien);
      _db.SaveChanges();
      if (SpeciiId != 0)
      {
        _db.AlienSpecii.Add(new AlienSpecii() {AlienId = alien.AlienId, SpeciiId = SpeciiId });
        _db.SaveChanges();
      }
      
      if (PlanetId != 0)
      {
        _db.AlienPlanet.Add(new AlienPlanet() {AlienId = alien.AlienId, PlanetId = PlanetId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Alien thisAlien = _db.Aliens
        .Include(alien => alien.JoinEntSpec)
        .ThenInclude(join => join.Alien)
        .Include(alien => alien.JoinEntPlan)
        .ThenInclude(join => join.Alien)
        .FirstOrDefault(alien => alien.AlienId == id);
      return View(thisAlien);
    }

		public ActionResult Edit(int id)
		{
			Alien thisAlien = _db.Aliens.FirstOrDefault(alien => alien.AlienId == id);
			return View(thisAlien);
		}

		[HttpPost]
		public ActionResult Edit(Alien alien)
		{
			_db.Entry(alien).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			Alien thisAlien = _db.Aliens.FirstOrDefault(alien => alien.AlienId == id);
			return View(thisAlien);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Alien thisAlien = _db.Aliens.FirstOrDefault(alien => alien.AlienId == id);
			_db.Aliens.Remove(thisAlien);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AddPlanet(int id)
		{
			Alien thisAlien = _db.Aliens.FirstOrDefault(alien => alien.AlienId == id);
			ViewBag.PlanetId = new SelectList(_db.Planets, "PlanetId", "PlanetName");
			return View(thisAlien);
		}

		[HttpPost]
		public ActionResult AddPlanet(Alien alien, int PlanetId)
		{
			_db.AlienPlanet.Add(new AlienPlanet() { PlanetId = PlanetId, AlienId = alien.AlienId});
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeletePlanet(int id)
		{
			AlienPlanet thisJoin = _db.AlienPlanet.FirstOrDefault(join => join.AlienPlanetId == id);
			_db.AlienPlanet.Remove(thisJoin);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

				public ActionResult AddSpecii(int id)
		{
			Alien thisAlien = _db.Aliens.FirstOrDefault(alien => alien.AlienId == id);
			ViewBag.SpeciiId = new SelectList(_db.Species, "SpeciiId", "SpeciiName");
			return View(thisAlien);
		}

		[HttpPost]
		public ActionResult AddSpecii(Alien alien, int SpeciiId)
		{
			_db.AlienSpecii.Add(new AlienSpecii() { SpeciiId = SpeciiId, AlienId = alien.AlienId});
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteSpecii(int joinId)
		{
			AlienSpecii thisJoin = _db.AlienSpecii.FirstOrDefault(join => join.AlienSpeciiId == joinId);
			_db.AlienSpecii.Remove(thisJoin);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
  }
}