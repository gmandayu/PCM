namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewAppraisalList/{ID?}", Name = "MtCrewAppraisalList-MTCrewAppraisal-list")]
    [Route("Home/MtCrewAppraisalList/{ID?}", Name = "MtCrewAppraisalList-MTCrewAppraisal-list-2")]
    public async Task<IActionResult> MtCrewAppraisalList()
    {
        // Create page object
        mtCrewAppraisalList = new GLOBALS.MtCrewAppraisalList(this);
        mtCrewAppraisalList.Cache = _cache;

        // Run the page
        return await mtCrewAppraisalList.Run();
    }

    // search
    [Route("MtCrewAppraisalSearch", Name = "MtCrewAppraisalSearch-MTCrewAppraisal-search")]
    [Route("Home/MtCrewAppraisalSearch", Name = "MtCrewAppraisalSearch-MTCrewAppraisal-search-2")]
    public async Task<IActionResult> MtCrewAppraisalSearch()
    {
        // Create page object
        mtCrewAppraisalSearch = new GLOBALS.MtCrewAppraisalSearch(this);

        // Run the page
        return await mtCrewAppraisalSearch.Run();
    }
}
