using Microsoft.AspNetCore.Mvc;

namespace Area52.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}