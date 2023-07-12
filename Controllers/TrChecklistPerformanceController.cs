namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TrChecklistPerformanceList/{ID?}", Name = "TrChecklistPerformanceList-TRChecklistPerformance-list")]
    [Route("Home/TrChecklistPerformanceList/{ID?}", Name = "TrChecklistPerformanceList-TRChecklistPerformance-list-2")]
    public async Task<IActionResult> TrChecklistPerformanceList()
    {
        // Create page object
        trChecklistPerformanceList = new GLOBALS.TrChecklistPerformanceList(this);
        trChecklistPerformanceList.Cache = _cache;

        // Run the page
        return await trChecklistPerformanceList.Run();
    }

    // add
    [Route("TrChecklistPerformanceAdd/{ID?}", Name = "TrChecklistPerformanceAdd-TRChecklistPerformance-add")]
    [Route("Home/TrChecklistPerformanceAdd/{ID?}", Name = "TrChecklistPerformanceAdd-TRChecklistPerformance-add-2")]
    public async Task<IActionResult> TrChecklistPerformanceAdd()
    {
        // Create page object
        trChecklistPerformanceAdd = new GLOBALS.TrChecklistPerformanceAdd(this);

        // Run the page
        return await trChecklistPerformanceAdd.Run();
    }

    // delete
    [Route("TrChecklistPerformanceDelete/{ID?}", Name = "TrChecklistPerformanceDelete-TRChecklistPerformance-delete")]
    [Route("Home/TrChecklistPerformanceDelete/{ID?}", Name = "TrChecklistPerformanceDelete-TRChecklistPerformance-delete-2")]
    public async Task<IActionResult> TrChecklistPerformanceDelete()
    {
        // Create page object
        trChecklistPerformanceDelete = new GLOBALS.TrChecklistPerformanceDelete(this);

        // Run the page
        return await trChecklistPerformanceDelete.Run();
    }

    // search
    [Route("TrChecklistPerformanceSearch", Name = "TrChecklistPerformanceSearch-TRChecklistPerformance-search")]
    [Route("Home/TrChecklistPerformanceSearch", Name = "TrChecklistPerformanceSearch-TRChecklistPerformance-search-2")]
    public async Task<IActionResult> TrChecklistPerformanceSearch()
    {
        // Create page object
        trChecklistPerformanceSearch = new GLOBALS.TrChecklistPerformanceSearch(this);

        // Run the page
        return await trChecklistPerformanceSearch.Run();
    }

    // preview
    [Route("TrChecklistPerformancePreview", Name = "TrChecklistPerformancePreview-TRChecklistPerformance-preview")]
    [Route("Home/TrChecklistPerformancePreview", Name = "TrChecklistPerformancePreview-TRChecklistPerformance-preview-2")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
    public async Task<IActionResult> TrChecklistPerformancePreview()
    {
        // Create page object
        trChecklistPerformancePreview = new GLOBALS.TrChecklistPerformancePreview(this);

        // Run the page
        return await trChecklistPerformancePreview.Run();
    }
}
