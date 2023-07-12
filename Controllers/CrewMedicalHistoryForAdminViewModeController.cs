namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewMedicalHistoryForAdminViewModeList/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeList-CrewMedicalHistoryForAdminViewMode-list")]
    [Route("Home/CrewMedicalHistoryForAdminViewModeList/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeList-CrewMedicalHistoryForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewMedicalHistoryForAdminViewModeList()
    {
        // Create page object
        crewMedicalHistoryForAdminViewModeList = new GLOBALS.CrewMedicalHistoryForAdminViewModeList(this);
        crewMedicalHistoryForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewMedicalHistoryForAdminViewModeList.Run();
    }

    // add
    [Route("CrewMedicalHistoryForAdminViewModeAdd/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeAdd-CrewMedicalHistoryForAdminViewMode-add")]
    [Route("Home/CrewMedicalHistoryForAdminViewModeAdd/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeAdd-CrewMedicalHistoryForAdminViewMode-add-2")]
    public async Task<IActionResult> CrewMedicalHistoryForAdminViewModeAdd()
    {
        // Create page object
        crewMedicalHistoryForAdminViewModeAdd = new GLOBALS.CrewMedicalHistoryForAdminViewModeAdd(this);

        // Run the page
        return await crewMedicalHistoryForAdminViewModeAdd.Run();
    }

    // view
    [Route("CrewMedicalHistoryForAdminViewModeView/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeView-CrewMedicalHistoryForAdminViewMode-view")]
    [Route("Home/CrewMedicalHistoryForAdminViewModeView/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeView-CrewMedicalHistoryForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewMedicalHistoryForAdminViewModeView()
    {
        // Create page object
        crewMedicalHistoryForAdminViewModeView = new GLOBALS.CrewMedicalHistoryForAdminViewModeView(this);

        // Run the page
        return await crewMedicalHistoryForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewMedicalHistoryForAdminViewModeEdit/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeEdit-CrewMedicalHistoryForAdminViewMode-edit")]
    [Route("Home/CrewMedicalHistoryForAdminViewModeEdit/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeEdit-CrewMedicalHistoryForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewMedicalHistoryForAdminViewModeEdit()
    {
        // Create page object
        crewMedicalHistoryForAdminViewModeEdit = new GLOBALS.CrewMedicalHistoryForAdminViewModeEdit(this);

        // Run the page
        return await crewMedicalHistoryForAdminViewModeEdit.Run();
    }

    // delete
    [Route("CrewMedicalHistoryForAdminViewModeDelete/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeDelete-CrewMedicalHistoryForAdminViewMode-delete")]
    [Route("Home/CrewMedicalHistoryForAdminViewModeDelete/{ID?}", Name = "CrewMedicalHistoryForAdminViewModeDelete-CrewMedicalHistoryForAdminViewMode-delete-2")]
    public async Task<IActionResult> CrewMedicalHistoryForAdminViewModeDelete()
    {
        // Create page object
        crewMedicalHistoryForAdminViewModeDelete = new GLOBALS.CrewMedicalHistoryForAdminViewModeDelete(this);

        // Run the page
        return await crewMedicalHistoryForAdminViewModeDelete.Run();
    }
}
