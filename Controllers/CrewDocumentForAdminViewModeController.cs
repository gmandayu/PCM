namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewDocumentForAdminViewModeList/{ID?}", Name = "CrewDocumentForAdminViewModeList-CrewDocumentForAdminViewMode-list")]
    [Route("Home/CrewDocumentForAdminViewModeList/{ID?}", Name = "CrewDocumentForAdminViewModeList-CrewDocumentForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewDocumentForAdminViewModeList()
    {
        // Create page object
        crewDocumentForAdminViewModeList = new GLOBALS.CrewDocumentForAdminViewModeList(this);
        crewDocumentForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewDocumentForAdminViewModeList.Run();
    }

    // add
    [Route("CrewDocumentForAdminViewModeAdd/{ID?}", Name = "CrewDocumentForAdminViewModeAdd-CrewDocumentForAdminViewMode-add")]
    [Route("Home/CrewDocumentForAdminViewModeAdd/{ID?}", Name = "CrewDocumentForAdminViewModeAdd-CrewDocumentForAdminViewMode-add-2")]
    public async Task<IActionResult> CrewDocumentForAdminViewModeAdd()
    {
        // Create page object
        crewDocumentForAdminViewModeAdd = new GLOBALS.CrewDocumentForAdminViewModeAdd(this);

        // Run the page
        return await crewDocumentForAdminViewModeAdd.Run();
    }

    // view
    [Route("CrewDocumentForAdminViewModeView/{ID?}", Name = "CrewDocumentForAdminViewModeView-CrewDocumentForAdminViewMode-view")]
    [Route("Home/CrewDocumentForAdminViewModeView/{ID?}", Name = "CrewDocumentForAdminViewModeView-CrewDocumentForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewDocumentForAdminViewModeView()
    {
        // Create page object
        crewDocumentForAdminViewModeView = new GLOBALS.CrewDocumentForAdminViewModeView(this);

        // Run the page
        return await crewDocumentForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewDocumentForAdminViewModeEdit/{ID?}", Name = "CrewDocumentForAdminViewModeEdit-CrewDocumentForAdminViewMode-edit")]
    [Route("Home/CrewDocumentForAdminViewModeEdit/{ID?}", Name = "CrewDocumentForAdminViewModeEdit-CrewDocumentForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewDocumentForAdminViewModeEdit()
    {
        // Create page object
        crewDocumentForAdminViewModeEdit = new GLOBALS.CrewDocumentForAdminViewModeEdit(this);

        // Run the page
        return await crewDocumentForAdminViewModeEdit.Run();
    }

    // delete
    [Route("CrewDocumentForAdminViewModeDelete/{ID?}", Name = "CrewDocumentForAdminViewModeDelete-CrewDocumentForAdminViewMode-delete")]
    [Route("Home/CrewDocumentForAdminViewModeDelete/{ID?}", Name = "CrewDocumentForAdminViewModeDelete-CrewDocumentForAdminViewMode-delete-2")]
    public async Task<IActionResult> CrewDocumentForAdminViewModeDelete()
    {
        // Create page object
        crewDocumentForAdminViewModeDelete = new GLOBALS.CrewDocumentForAdminViewModeDelete(this);

        // Run the page
        return await crewDocumentForAdminViewModeDelete.Run();
    }

    // search
    [Route("CrewDocumentForAdminViewModeSearch", Name = "CrewDocumentForAdminViewModeSearch-CrewDocumentForAdminViewMode-search")]
    [Route("Home/CrewDocumentForAdminViewModeSearch", Name = "CrewDocumentForAdminViewModeSearch-CrewDocumentForAdminViewMode-search-2")]
    public async Task<IActionResult> CrewDocumentForAdminViewModeSearch()
    {
        // Create page object
        crewDocumentForAdminViewModeSearch = new GLOBALS.CrewDocumentForAdminViewModeSearch(this);

        // Run the page
        return await crewDocumentForAdminViewModeSearch.Run();
    }
}
