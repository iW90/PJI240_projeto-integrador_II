using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Pessoa()
    {
        return View("Pessoa");
    }

    public IActionResult Orcamento()
    {
        return View("Orcamento");
    }
}
