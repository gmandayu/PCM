namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewExperienceForAdminViewModeList/{ID?}", Name = "CrewExperienceForAdminViewModeList-CrewExperienceForAdminViewMode-list")]
    [Route("Home/CrewExperienceForAdminViewModeList/{ID?}", Name = "CrewExperienceForAdminViewModeList-CrewExperienceForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewExperienceForAdminViewModeList()
    {
        // Create page object
        crewExperienceForAdminViewModeList = new GLOBALS.CrewExperienceForAdminViewModeList(this);
        crewExperienceForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewExperienceForAdminViewModeList.Run();
    }

    // add
    [Route("CrewExperienceForAdminViewModeAdd/{ID?}", Name = "CrewExperienceForAdminViewModeAdd-CrewExperienceForAdminViewMode-add")]
    [Route("Home/CrewExperienceForAdminViewModeAdd/{ID?}", Name = "CrewExperienceForAdminViewModeAdd-CrewExperienceForAdminViewMode-add-2")]
    public async Task<IActionResult> CrewExperienceForAdminViewModeAdd()
    {
        // Create page object
        crewExperienceForAdminViewModeAdd = new GLOBALS.CrewExperienceForAdminViewModeAdd(this);

        // Run the page
        return await crewExperienceForAdminViewModeAdd.Run();
    }

    // view
    [Route("CrewExperienceForAdminViewModeView/{ID?}", Name = "CrewExperienceForAdminViewModeView-CrewExperienceForAdminViewMode-view")]
    [Route("Home/CrewExperienceForAdminViewModeView/{ID?}", Name = "CrewExperienceForAdminViewModeView-CrewExperienceForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewExperienceForAdminViewModeView()
    {
        // Create page object
        crewExperienceForAdminViewModeView = new GLOBALS.CrewExperienceForAdminViewModeView(this);

        // Run the page
        return await crewExperienceForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewExperienceForAdminViewModeEdit/{ID?}", Name = "CrewExperienceForAdminViewModeEdit-CrewExperienceForAdminViewMode-edit")]
    [Route("Home/CrewExperienceForAdminViewModeEdit/{ID?}", Name = "CrewExperienceForAdminViewModeEdit-CrewExperienceForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewExperienceForAdminViewModeEdit()
    {
        // Create page object
        crewExperienceForAdminViewModeEdit = new GLOBALS.CrewExperienceForAdminViewModeEdit(this);

        // Run the page
        return await crewExperienceForAdminViewModeEdit.Run();
    }

    // delete
    [Route("CrewExperienceForAdminViewModeDelete/{ID?}", Name = "CrewExperienceForAdminViewModeDelete-CrewExperienceForAdminViewMode-delete")]
    [Route("Home/CrewExperienceForAdminViewModeDelete/{ID?}", Name = "CrewExperienceForAdminViewModeDelete-CrewExperienceForAdminViewMode-delete-2")]
    public async Task<IActionResult> CrewExperienceForAdminViewModeDelete()
    {
        // Create page object
        crewExperienceForAdminViewModeDelete = new GLOBALS.CrewExperienceForAdminViewModeDelete(this);

        // Run the page
        return await crewExperienceForAdminViewModeDelete.Run();
    }
}
