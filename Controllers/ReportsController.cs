using EvolveDataBank.Data;
using EvolveDataBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvolveDataBank.Controllers;

public class ReportsController : Controller
{
    private readonly ReportStore _store;

    public ReportsController(ReportStore store) => _store = store;

    [Route("reports")]
    public IActionResult Index() => View();

    // Only the cold chain report has a full page in this design.
    // Other reports send the visitor to the live site until their pages are built.
    [Route("reports/{slug}")]
    public IActionResult Details(string slug)
    {
        if (slug == ReportStore.ColdChainSlug)
            return View(_store.ColdChain);

        if (_store.Reports.Any(r => r.Slug == slug))
            return Redirect($"{Site.LiveBase}/ProductMaster/ProductDataDisplay/{slug}");

        return NotFound();
    }
}
