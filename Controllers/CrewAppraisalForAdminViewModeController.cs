namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewAppraisalForAdminViewModeList/{ID?}", Name = "CrewAppraisalForAdminViewModeList-CrewAppraisalForAdminViewMode-list")]
    [Route("Home/CrewAppraisalForAdminViewModeList/{ID?}", Name = "CrewAppraisalForAdminViewModeList-CrewAppraisalForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewAppraisalForAdminViewModeList()
    {
        // Create page object
        crewAppraisalForAdminViewModeList = new GLOBALS.CrewAppraisalForAdminViewModeList(this);
        crewAppraisalForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewAppraisalForAdminViewModeList.Run();
    }

    // add
    [Route("CrewAppraisalForAdminViewModeAdd/{ID?}", Name = "CrewAppraisalForAdminViewModeAdd-CrewAppraisalForAdminViewMode-add")]
    [Route("Home/CrewAppraisalForAdminViewModeAdd/{ID?}", Name = "CrewAppraisalForAdminViewModeAdd-CrewAppraisalForAdminViewMode-add-2")]
    public async Task<IActionResult> CrewAppraisalForAdminViewModeAdd()
    {
        // Create page object
        crewAppraisalForAdminViewModeAdd = new GLOBALS.CrewAppraisalForAdminViewModeAdd(this);

        // Run the page
        return await crewAppraisalForAdminViewModeAdd.Run();
    }

    // view
    [Route("CrewAppraisalForAdminViewModeView/{ID?}", Name = "CrewAppraisalForAdminViewModeView-CrewAppraisalForAdminViewMode-view")]
    [Route("Home/CrewAppraisalForAdminViewModeView/{ID?}", Name = "CrewAppraisalForAdminViewModeView-CrewAppraisalForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewAppraisalForAdminViewModeView()
    {
        // Create page object
        crewAppraisalForAdminViewModeView = new GLOBALS.CrewAppraisalForAdminViewModeView(this);

        // Run the page
        return await crewAppraisalForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewAppraisalForAdminViewModeEdit/{ID?}", Name = "CrewAppraisalForAdminViewModeEdit-CrewAppraisalForAdminViewMode-edit")]
    [Route("Home/CrewAppraisalForAdminViewModeEdit/{ID?}", Name = "CrewAppraisalForAdminViewModeEdit-CrewAppraisalForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewAppraisalForAdminViewModeEdit()
    {
        // Create page object
        crewAppraisalForAdminViewModeEdit = new GLOBALS.CrewAppraisalForAdminViewModeEdit(this);

        // Run the page
        return await crewAppraisalForAdminViewModeEdit.Run();
    }

    // delete
    [Route("CrewAppraisalForAdminViewModeDelete/{ID?}", Name = "CrewAppraisalForAdminViewModeDelete-CrewAppraisalForAdminViewMode-delete")]
    [Route("Home/CrewAppraisalForAdminViewModeDelete/{ID?}", Name = "CrewAppraisalForAdminViewModeDelete-CrewAppraisalForAdminViewMode-delete-2")]
    public async Task<IActionResult> CrewAppraisalForAdminViewModeDelete()
    {
        // Create page object
        crewAppraisalForAdminViewModeDelete = new GLOBALS.CrewAppraisalForAdminViewModeDelete(this);

        // Run the page
        return await crewAppraisalForAdminViewModeDelete.Run();
    }

    // search
    [Route("CrewAppraisalForAdminViewModeSearch", Name = "CrewAppraisalForAdminViewModeSearch-CrewAppraisalForAdminViewMode-search")]
    [Route("Home/CrewAppraisalForAdminViewModeSearch", Name = "CrewAppraisalForAdminViewModeSearch-CrewAppraisalForAdminViewMode-search-2")]
    public async Task<IActionResult> CrewAppraisalForAdminViewModeSearch()
    {
        // Create page object
        crewAppraisalForAdminViewModeSearch = new GLOBALS.CrewAppraisalForAdminViewModeSearch(this);

        // Run the page
        return await crewAppraisalForAdminViewModeSearch.Run();
    }
}
