namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewFormalEducationList/{ID?}", Name = "MtCrewFormalEducationList-MTCrewFormalEducation-list")]
    [Route("Home/MtCrewFormalEducationList/{ID?}", Name = "MtCrewFormalEducationList-MTCrewFormalEducation-list-2")]
    public async Task<IActionResult> MtCrewFormalEducationList()
    {
        // Create page object
        mtCrewFormalEducationList = new GLOBALS.MtCrewFormalEducationList(this);
        mtCrewFormalEducationList.Cache = _cache;

        // Run the page
        return await mtCrewFormalEducationList.Run();
    }

    // search
    [Route("MtCrewFormalEducationSearch", Name = "MtCrewFormalEducationSearch-MTCrewFormalEducation-search")]
    [Route("Home/MtCrewFormalEducationSearch", Name = "MtCrewFormalEducationSearch-MTCrewFormalEducation-search-2")]
    public async Task<IActionResult> MtCrewFormalEducationSearch()
    {
        // Create page object
        mtCrewFormalEducationSearch = new GLOBALS.MtCrewFormalEducationSearch(this);

        // Run the page
        return await mtCrewFormalEducationSearch.Run();
    }
}
