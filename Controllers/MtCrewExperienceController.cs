namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewExperienceList/{ID?}", Name = "MtCrewExperienceList-MTCrewExperience-list")]
    [Route("Home/MtCrewExperienceList/{ID?}", Name = "MtCrewExperienceList-MTCrewExperience-list-2")]
    public async Task<IActionResult> MtCrewExperienceList()
    {
        // Create page object
        mtCrewExperienceList = new GLOBALS.MtCrewExperienceList(this);
        mtCrewExperienceList.Cache = _cache;

        // Run the page
        return await mtCrewExperienceList.Run();
    }

    // search
    [Route("MtCrewExperienceSearch", Name = "MtCrewExperienceSearch-MTCrewExperience-search")]
    [Route("Home/MtCrewExperienceSearch", Name = "MtCrewExperienceSearch-MTCrewExperience-search-2")]
    public async Task<IActionResult> MtCrewExperienceSearch()
    {
        // Create page object
        mtCrewExperienceSearch = new GLOBALS.MtCrewExperienceSearch(this);

        // Run the page
        return await mtCrewExperienceSearch.Run();
    }

    // preview
    [Route("MtCrewExperiencePreview", Name = "MtCrewExperiencePreview-MTCrewExperience-preview")]
    [Route("Home/MtCrewExperiencePreview", Name = "MtCrewExperiencePreview-MTCrewExperience-preview-2")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
    public async Task<IActionResult> MtCrewExperiencePreview()
    {
        // Create page object
        mtCrewExperiencePreview = new GLOBALS.MtCrewExperiencePreview(this);

        // Run the page
        return await mtCrewExperiencePreview.Run();
    }
}
