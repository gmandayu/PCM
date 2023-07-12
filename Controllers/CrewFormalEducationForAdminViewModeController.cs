namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewFormalEducationForAdminViewModeList/{ID?}", Name = "CrewFormalEducationForAdminViewModeList-CrewFormalEducationForAdminViewMode-list")]
    [Route("Home/CrewFormalEducationForAdminViewModeList/{ID?}", Name = "CrewFormalEducationForAdminViewModeList-CrewFormalEducationForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminViewModeList()
    {
        // Create page object
        crewFormalEducationForAdminViewModeList = new GLOBALS.CrewFormalEducationForAdminViewModeList(this);
        crewFormalEducationForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewFormalEducationForAdminViewModeList.Run();
    }

    // add
    [Route("CrewFormalEducationForAdminViewModeAdd/{ID?}", Name = "CrewFormalEducationForAdminViewModeAdd-CrewFormalEducationForAdminViewMode-add")]
    [Route("Home/CrewFormalEducationForAdminViewModeAdd/{ID?}", Name = "CrewFormalEducationForAdminViewModeAdd-CrewFormalEducationForAdminViewMode-add-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminViewModeAdd()
    {
        // Create page object
        crewFormalEducationForAdminViewModeAdd = new GLOBALS.CrewFormalEducationForAdminViewModeAdd(this);

        // Run the page
        return await crewFormalEducationForAdminViewModeAdd.Run();
    }

    // view
    [Route("CrewFormalEducationForAdminViewModeView/{ID?}", Name = "CrewFormalEducationForAdminViewModeView-CrewFormalEducationForAdminViewMode-view")]
    [Route("Home/CrewFormalEducationForAdminViewModeView/{ID?}", Name = "CrewFormalEducationForAdminViewModeView-CrewFormalEducationForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminViewModeView()
    {
        // Create page object
        crewFormalEducationForAdminViewModeView = new GLOBALS.CrewFormalEducationForAdminViewModeView(this);

        // Run the page
        return await crewFormalEducationForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewFormalEducationForAdminViewModeEdit/{ID?}", Name = "CrewFormalEducationForAdminViewModeEdit-CrewFormalEducationForAdminViewMode-edit")]
    [Route("Home/CrewFormalEducationForAdminViewModeEdit/{ID?}", Name = "CrewFormalEducationForAdminViewModeEdit-CrewFormalEducationForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminViewModeEdit()
    {
        // Create page object
        crewFormalEducationForAdminViewModeEdit = new GLOBALS.CrewFormalEducationForAdminViewModeEdit(this);

        // Run the page
        return await crewFormalEducationForAdminViewModeEdit.Run();
    }

    // delete
    [Route("CrewFormalEducationForAdminViewModeDelete/{ID?}", Name = "CrewFormalEducationForAdminViewModeDelete-CrewFormalEducationForAdminViewMode-delete")]
    [Route("Home/CrewFormalEducationForAdminViewModeDelete/{ID?}", Name = "CrewFormalEducationForAdminViewModeDelete-CrewFormalEducationForAdminViewMode-delete-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminViewModeDelete()
    {
        // Create page object
        crewFormalEducationForAdminViewModeDelete = new GLOBALS.CrewFormalEducationForAdminViewModeDelete(this);

        // Run the page
        return await crewFormalEducationForAdminViewModeDelete.Run();
    }

    // search
    [Route("CrewFormalEducationForAdminViewModeSearch", Name = "CrewFormalEducationForAdminViewModeSearch-CrewFormalEducationForAdminViewMode-search")]
    [Route("Home/CrewFormalEducationForAdminViewModeSearch", Name = "CrewFormalEducationForAdminViewModeSearch-CrewFormalEducationForAdminViewMode-search-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminViewModeSearch()
    {
        // Create page object
        crewFormalEducationForAdminViewModeSearch = new GLOBALS.CrewFormalEducationForAdminViewModeSearch(this);

        // Run the page
        return await crewFormalEducationForAdminViewModeSearch.Run();
    }
}
