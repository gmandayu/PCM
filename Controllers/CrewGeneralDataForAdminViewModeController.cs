namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewGeneralDataForAdminViewModeList/{ID?}", Name = "CrewGeneralDataForAdminViewModeList-CrewGeneralDataForAdminViewMode-list")]
    [Route("Home/CrewGeneralDataForAdminViewModeList/{ID?}", Name = "CrewGeneralDataForAdminViewModeList-CrewGeneralDataForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewGeneralDataForAdminViewModeList()
    {
        // Create page object
        crewGeneralDataForAdminViewModeList = new GLOBALS.CrewGeneralDataForAdminViewModeList(this);
        crewGeneralDataForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewGeneralDataForAdminViewModeList.Run();
    }

    // view
    [Route("CrewGeneralDataForAdminViewModeView/{ID?}", Name = "CrewGeneralDataForAdminViewModeView-CrewGeneralDataForAdminViewMode-view")]
    [Route("Home/CrewGeneralDataForAdminViewModeView/{ID?}", Name = "CrewGeneralDataForAdminViewModeView-CrewGeneralDataForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewGeneralDataForAdminViewModeView()
    {
        // Create page object
        crewGeneralDataForAdminViewModeView = new GLOBALS.CrewGeneralDataForAdminViewModeView(this);

        // Run the page
        return await crewGeneralDataForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewGeneralDataForAdminViewModeEdit/{ID?}", Name = "CrewGeneralDataForAdminViewModeEdit-CrewGeneralDataForAdminViewMode-edit")]
    [Route("Home/CrewGeneralDataForAdminViewModeEdit/{ID?}", Name = "CrewGeneralDataForAdminViewModeEdit-CrewGeneralDataForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewGeneralDataForAdminViewModeEdit()
    {
        // Create page object
        crewGeneralDataForAdminViewModeEdit = new GLOBALS.CrewGeneralDataForAdminViewModeEdit(this);

        // Run the page
        return await crewGeneralDataForAdminViewModeEdit.Run();
    }
}
