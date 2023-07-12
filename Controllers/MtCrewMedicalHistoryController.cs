namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewMedicalHistoryList/{ID?}", Name = "MtCrewMedicalHistoryList-MTCrewMedicalHistory-list")]
    [Route("Home/MtCrewMedicalHistoryList/{ID?}", Name = "MtCrewMedicalHistoryList-MTCrewMedicalHistory-list-2")]
    public async Task<IActionResult> MtCrewMedicalHistoryList()
    {
        // Create page object
        mtCrewMedicalHistoryList = new GLOBALS.MtCrewMedicalHistoryList(this);
        mtCrewMedicalHistoryList.Cache = _cache;

        // Run the page
        return await mtCrewMedicalHistoryList.Run();
    }

    // search
    [Route("MtCrewMedicalHistorySearch", Name = "MtCrewMedicalHistorySearch-MTCrewMedicalHistory-search")]
    [Route("Home/MtCrewMedicalHistorySearch", Name = "MtCrewMedicalHistorySearch-MTCrewMedicalHistory-search-2")]
    public async Task<IActionResult> MtCrewMedicalHistorySearch()
    {
        // Create page object
        mtCrewMedicalHistorySearch = new GLOBALS.MtCrewMedicalHistorySearch(this);

        // Run the page
        return await mtCrewMedicalHistorySearch.Run();
    }

    // preview
    [Route("MtCrewMedicalHistoryPreview", Name = "MtCrewMedicalHistoryPreview-MTCrewMedicalHistory-preview")]
    [Route("Home/MtCrewMedicalHistoryPreview", Name = "MtCrewMedicalHistoryPreview-MTCrewMedicalHistory-preview-2")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
    public async Task<IActionResult> MtCrewMedicalHistoryPreview()
    {
        // Create page object
        mtCrewMedicalHistoryPreview = new GLOBALS.MtCrewMedicalHistoryPreview(this);

        // Run the page
        return await mtCrewMedicalHistoryPreview.Run();
    }
}
