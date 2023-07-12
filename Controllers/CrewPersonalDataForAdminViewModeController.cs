namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewPersonalDataForAdminViewModeList/{ID?}", Name = "CrewPersonalDataForAdminViewModeList-CrewPersonalDataForAdminViewMode-list")]
    [Route("Home/CrewPersonalDataForAdminViewModeList/{ID?}", Name = "CrewPersonalDataForAdminViewModeList-CrewPersonalDataForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewPersonalDataForAdminViewModeList()
    {
        // Create page object
        crewPersonalDataForAdminViewModeList = new GLOBALS.CrewPersonalDataForAdminViewModeList(this);
        crewPersonalDataForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewPersonalDataForAdminViewModeList.Run();
    }

    // view
    [Route("CrewPersonalDataForAdminViewModeView/{ID?}", Name = "CrewPersonalDataForAdminViewModeView-CrewPersonalDataForAdminViewMode-view")]
    [Route("Home/CrewPersonalDataForAdminViewModeView/{ID?}", Name = "CrewPersonalDataForAdminViewModeView-CrewPersonalDataForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewPersonalDataForAdminViewModeView()
    {
        // Create page object
        crewPersonalDataForAdminViewModeView = new GLOBALS.CrewPersonalDataForAdminViewModeView(this);

        // Run the page
        return await crewPersonalDataForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewPersonalDataForAdminViewModeEdit/{ID?}", Name = "CrewPersonalDataForAdminViewModeEdit-CrewPersonalDataForAdminViewMode-edit")]
    [Route("Home/CrewPersonalDataForAdminViewModeEdit/{ID?}", Name = "CrewPersonalDataForAdminViewModeEdit-CrewPersonalDataForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewPersonalDataForAdminViewModeEdit()
    {
        // Create page object
        crewPersonalDataForAdminViewModeEdit = new GLOBALS.CrewPersonalDataForAdminViewModeEdit(this);

        // Run the page
        return await crewPersonalDataForAdminViewModeEdit.Run();
    }

    // search
    [Route("CrewPersonalDataForAdminViewModeSearch", Name = "CrewPersonalDataForAdminViewModeSearch-CrewPersonalDataForAdminViewMode-search")]
    [Route("Home/CrewPersonalDataForAdminViewModeSearch", Name = "CrewPersonalDataForAdminViewModeSearch-CrewPersonalDataForAdminViewMode-search-2")]
    public async Task<IActionResult> CrewPersonalDataForAdminViewModeSearch()
    {
        // Create page object
        crewPersonalDataForAdminViewModeSearch = new GLOBALS.CrewPersonalDataForAdminViewModeSearch(this);

        // Run the page
        return await crewPersonalDataForAdminViewModeSearch.Run();
    }
}
