namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("EmailHistoryList/{Id?}", Name = "EmailHistoryList-EmailHistory-list")]
    [Route("Home/EmailHistoryList/{Id?}", Name = "EmailHistoryList-EmailHistory-list-2")]
    public async Task<IActionResult> EmailHistoryList()
    {
        // Create page object
        emailHistoryList = new GLOBALS.EmailHistoryList(this);
        emailHistoryList.Cache = _cache;

        // Run the page
        return await emailHistoryList.Run();
    }

    // view
    [Route("EmailHistoryView/{Id?}", Name = "EmailHistoryView-EmailHistory-view")]
    [Route("Home/EmailHistoryView/{Id?}", Name = "EmailHistoryView-EmailHistory-view-2")]
    public async Task<IActionResult> EmailHistoryView()
    {
        // Create page object
        emailHistoryView = new GLOBALS.EmailHistoryView(this);

        // Run the page
        return await emailHistoryView.Run();
    }

    // search
    [Route("EmailHistorySearch", Name = "EmailHistorySearch-EmailHistory-search")]
    [Route("Home/EmailHistorySearch", Name = "EmailHistorySearch-EmailHistory-search-2")]
    public async Task<IActionResult> EmailHistorySearch()
    {
        // Create page object
        emailHistorySearch = new GLOBALS.EmailHistorySearch(this);

        // Run the page
        return await emailHistorySearch.Run();
    }
}
