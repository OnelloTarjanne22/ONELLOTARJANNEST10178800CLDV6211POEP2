using Microsoft.AspNetCore.Mvc;

namespace ONELLOTARJANNEST10178800CLDV6211POEPART1
{
public class SearchController : Controller
{
    private readonly SearchService _searchService;

    public SearchController(SearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return View();
        }

        var results = await _searchService.SearchAsync(query);
        return View(results);
    }
}

}
