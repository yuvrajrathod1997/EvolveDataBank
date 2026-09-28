using Microsoft.AspNetCore.Mvc;

namespace EvolveDataBank.Controllers;

public class HomeController : Controller
{
    [Route("")]
    public IActionResult Index() => View();

    [Route("about")]
    public IActionResult About() => View();

    [Route("services")]
    public IActionResult Services() => View();

    [Route("contact")]
    public IActionResult Contact() => View();

    [Route("error")]
    public IActionResult Error() => Content("Something went wrong. Please try again.");
}
