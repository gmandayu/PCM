namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TrEmployeeStatusList", Name = "TrEmployeeStatusList-TREmployeeStatus-list")]
    [Route("Home/TrEmployeeStatusList", Name = "TrEmployeeStatusList-TREmployeeStatus-list-2")]
    public async Task<IActionResult> TrEmployeeStatusList()
    {
        // Create page object
        trEmployeeStatusList = new GLOBALS.TrEmployeeStatusList(this);
        trEmployeeStatusList.Cache = _cache;

        // Run the page
        return await trEmployeeStatusList.Run();
    }

    // search
    [Route("TrEmployeeStatusSearch", Name = "TrEmployeeStatusSearch-TREmployeeStatus-search")]
    [Route("Home/TrEmployeeStatusSearch", Name = "TrEmployeeStatusSearch-TREmployeeStatus-search-2")]
    public async Task<IActionResult> TrEmployeeStatusSearch()
    {
        // Create page object
        trEmployeeStatusSearch = new GLOBALS.TrEmployeeStatusSearch(this);

        // Run the page
        return await trEmployeeStatusSearch.Run();
    }
}
