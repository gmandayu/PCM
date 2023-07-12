namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewFamilyForAdminViewModeList/{ID?}", Name = "CrewFamilyForAdminViewModeList-CrewFamilyForAdminViewMode-list")]
    [Route("Home/CrewFamilyForAdminViewModeList/{ID?}", Name = "CrewFamilyForAdminViewModeList-CrewFamilyForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewFamilyForAdminViewModeList()
    {
        // Create page object
        crewFamilyForAdminViewModeList = new GLOBALS.CrewFamilyForAdminViewModeList(this);
        crewFamilyForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewFamilyForAdminViewModeList.Run();
    }

    // add
    [Route("CrewFamilyForAdminViewModeAdd/{ID?}", Name = "CrewFamilyForAdminViewModeAdd-CrewFamilyForAdminViewMode-add")]
    [Route("Home/CrewFamilyForAdminViewModeAdd/{ID?}", Name = "CrewFamilyForAdminViewModeAdd-CrewFamilyForAdminViewMode-add-2")]
    public async Task<IActionResult> CrewFamilyForAdminViewModeAdd()
    {
        // Create page object
        crewFamilyForAdminViewModeAdd = new GLOBALS.CrewFamilyForAdminViewModeAdd(this);

        // Run the page
        return await crewFamilyForAdminViewModeAdd.Run();
    }

    // view
    [Route("CrewFamilyForAdminViewModeView/{ID?}", Name = "CrewFamilyForAdminViewModeView-CrewFamilyForAdminViewMode-view")]
    [Route("Home/CrewFamilyForAdminViewModeView/{ID?}", Name = "CrewFamilyForAdminViewModeView-CrewFamilyForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewFamilyForAdminViewModeView()
    {
        // Create page object
        crewFamilyForAdminViewModeView = new GLOBALS.CrewFamilyForAdminViewModeView(this);

        // Run the page
        return await crewFamilyForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewFamilyForAdminViewModeEdit/{ID?}", Name = "CrewFamilyForAdminViewModeEdit-CrewFamilyForAdminViewMode-edit")]
    [Route("Home/CrewFamilyForAdminViewModeEdit/{ID?}", Name = "CrewFamilyForAdminViewModeEdit-CrewFamilyForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewFamilyForAdminViewModeEdit()
    {
        // Create page object
        crewFamilyForAdminViewModeEdit = new GLOBALS.CrewFamilyForAdminViewModeEdit(this);

        // Run the page
        return await crewFamilyForAdminViewModeEdit.Run();
    }

    // delete
    [Route("CrewFamilyForAdminViewModeDelete/{ID?}", Name = "CrewFamilyForAdminViewModeDelete-CrewFamilyForAdminViewMode-delete")]
    [Route("Home/CrewFamilyForAdminViewModeDelete/{ID?}", Name = "CrewFamilyForAdminViewModeDelete-CrewFamilyForAdminViewMode-delete-2")]
    public async Task<IActionResult> CrewFamilyForAdminViewModeDelete()
    {
        // Create page object
        crewFamilyForAdminViewModeDelete = new GLOBALS.CrewFamilyForAdminViewModeDelete(this);

        // Run the page
        return await crewFamilyForAdminViewModeDelete.Run();
    }
}
