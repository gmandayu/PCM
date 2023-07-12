namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewFamilyList/{ID?}", Name = "MtCrewFamilyList-MTCrewFamily-list")]
    [Route("Home/MtCrewFamilyList/{ID?}", Name = "MtCrewFamilyList-MTCrewFamily-list-2")]
    public async Task<IActionResult> MtCrewFamilyList()
    {
        // Create page object
        mtCrewFamilyList = new GLOBALS.MtCrewFamilyList(this);
        mtCrewFamilyList.Cache = _cache;

        // Run the page
        return await mtCrewFamilyList.Run();
    }

    // search
    [Route("MtCrewFamilySearch", Name = "MtCrewFamilySearch-MTCrewFamily-search")]
    [Route("Home/MtCrewFamilySearch", Name = "MtCrewFamilySearch-MTCrewFamily-search-2")]
    public async Task<IActionResult> MtCrewFamilySearch()
    {
        // Create page object
        mtCrewFamilySearch = new GLOBALS.MtCrewFamilySearch(this);

        // Run the page
        return await mtCrewFamilySearch.Run();
    }

    // preview
    [Route("MtCrewFamilyPreview", Name = "MtCrewFamilyPreview-MTCrewFamily-preview")]
    [Route("Home/MtCrewFamilyPreview", Name = "MtCrewFamilyPreview-MTCrewFamily-preview-2")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
    public async Task<IActionResult> MtCrewFamilyPreview()
    {
        // Create page object
        mtCrewFamilyPreview = new GLOBALS.MtCrewFamilyPreview(this);

        // Run the page
        return await mtCrewFamilyPreview.Run();
    }
}
