namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewDocumentList/{ID?}", Name = "MtCrewDocumentList-MTCrewDocument-list")]
    [Route("Home/MtCrewDocumentList/{ID?}", Name = "MtCrewDocumentList-MTCrewDocument-list-2")]
    public async Task<IActionResult> MtCrewDocumentList()
    {
        // Create page object
        mtCrewDocumentList = new GLOBALS.MtCrewDocumentList(this);
        mtCrewDocumentList.Cache = _cache;

        // Run the page
        return await mtCrewDocumentList.Run();
    }

    // search
    [Route("MtCrewDocumentSearch", Name = "MtCrewDocumentSearch-MTCrewDocument-search")]
    [Route("Home/MtCrewDocumentSearch", Name = "MtCrewDocumentSearch-MTCrewDocument-search-2")]
    public async Task<IActionResult> MtCrewDocumentSearch()
    {
        // Create page object
        mtCrewDocumentSearch = new GLOBALS.MtCrewDocumentSearch(this);

        // Run the page
        return await mtCrewDocumentSearch.Run();
    }

    // preview
    [Route("MtCrewDocumentPreview", Name = "MtCrewDocumentPreview-MTCrewDocument-preview")]
    [Route("Home/MtCrewDocumentPreview", Name = "MtCrewDocumentPreview-MTCrewDocument-preview-2")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
    public async Task<IActionResult> MtCrewDocumentPreview()
    {
        // Create page object
        mtCrewDocumentPreview = new GLOBALS.MtCrewDocumentPreview(this);

        // Run the page
        return await mtCrewDocumentPreview.Run();
    }
}
