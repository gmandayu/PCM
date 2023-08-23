namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TrEmailHistoryList/{Id?}", Name = "TrEmailHistoryList-TREmailHistory-list")]
    [Route("Home/TrEmailHistoryList/{Id?}", Name = "TrEmailHistoryList-TREmailHistory-list-2")]
    public async Task<IActionResult> TrEmailHistoryList()
    {
        // Create page object
        trEmailHistoryList = new GLOBALS.TrEmailHistoryList(this);
        trEmailHistoryList.Cache = _cache;

        // Run the page
        return await trEmailHistoryList.Run();
    }
}
