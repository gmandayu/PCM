namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TrChecklistList/{ID?}", Name = "TrChecklistList-TRChecklist-list")]
    [Route("Home/TrChecklistList/{ID?}", Name = "TrChecklistList-TRChecklist-list-2")]
    public async Task<IActionResult> TrChecklistList()
    {
        // Create page object
        trChecklistList = new GLOBALS.TrChecklistList(this);
        trChecklistList.Cache = _cache;

        // Run the page
        return await trChecklistList.Run();
    }

    // add
    [Route("TrChecklistAdd/{ID?}", Name = "TrChecklistAdd-TRChecklist-add")]
    [Route("Home/TrChecklistAdd/{ID?}", Name = "TrChecklistAdd-TRChecklist-add-2")]
    public async Task<IActionResult> TrChecklistAdd()
    {
        // Create page object
        trChecklistAdd = new GLOBALS.TrChecklistAdd(this);

        // Run the page
        return await trChecklistAdd.Run();
    }

    // search
    [Route("TrChecklistSearch", Name = "TrChecklistSearch-TRChecklist-search")]
    [Route("Home/TrChecklistSearch", Name = "TrChecklistSearch-TRChecklist-search-2")]
    public async Task<IActionResult> TrChecklistSearch()
    {
        // Create page object
        trChecklistSearch = new GLOBALS.TrChecklistSearch(this);

        // Run the page
        return await trChecklistSearch.Run();
    }
}
