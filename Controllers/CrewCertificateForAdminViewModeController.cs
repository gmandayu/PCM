namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewCertificateForAdminViewModeList/{ID?}", Name = "CrewCertificateForAdminViewModeList-CrewCertificateForAdminViewMode-list")]
    [Route("Home/CrewCertificateForAdminViewModeList/{ID?}", Name = "CrewCertificateForAdminViewModeList-CrewCertificateForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewCertificateForAdminViewModeList()
    {
        // Create page object
        crewCertificateForAdminViewModeList = new GLOBALS.CrewCertificateForAdminViewModeList(this);
        crewCertificateForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewCertificateForAdminViewModeList.Run();
    }

    // add
    [Route("CrewCertificateForAdminViewModeAdd/{ID?}", Name = "CrewCertificateForAdminViewModeAdd-CrewCertificateForAdminViewMode-add")]
    [Route("Home/CrewCertificateForAdminViewModeAdd/{ID?}", Name = "CrewCertificateForAdminViewModeAdd-CrewCertificateForAdminViewMode-add-2")]
    public async Task<IActionResult> CrewCertificateForAdminViewModeAdd()
    {
        // Create page object
        crewCertificateForAdminViewModeAdd = new GLOBALS.CrewCertificateForAdminViewModeAdd(this);

        // Run the page
        return await crewCertificateForAdminViewModeAdd.Run();
    }

    // view
    [Route("CrewCertificateForAdminViewModeView/{ID?}", Name = "CrewCertificateForAdminViewModeView-CrewCertificateForAdminViewMode-view")]
    [Route("Home/CrewCertificateForAdminViewModeView/{ID?}", Name = "CrewCertificateForAdminViewModeView-CrewCertificateForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewCertificateForAdminViewModeView()
    {
        // Create page object
        crewCertificateForAdminViewModeView = new GLOBALS.CrewCertificateForAdminViewModeView(this);

        // Run the page
        return await crewCertificateForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewCertificateForAdminViewModeEdit/{ID?}", Name = "CrewCertificateForAdminViewModeEdit-CrewCertificateForAdminViewMode-edit")]
    [Route("Home/CrewCertificateForAdminViewModeEdit/{ID?}", Name = "CrewCertificateForAdminViewModeEdit-CrewCertificateForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewCertificateForAdminViewModeEdit()
    {
        // Create page object
        crewCertificateForAdminViewModeEdit = new GLOBALS.CrewCertificateForAdminViewModeEdit(this);

        // Run the page
        return await crewCertificateForAdminViewModeEdit.Run();
    }

    // delete
    [Route("CrewCertificateForAdminViewModeDelete/{ID?}", Name = "CrewCertificateForAdminViewModeDelete-CrewCertificateForAdminViewMode-delete")]
    [Route("Home/CrewCertificateForAdminViewModeDelete/{ID?}", Name = "CrewCertificateForAdminViewModeDelete-CrewCertificateForAdminViewMode-delete-2")]
    public async Task<IActionResult> CrewCertificateForAdminViewModeDelete()
    {
        // Create page object
        crewCertificateForAdminViewModeDelete = new GLOBALS.CrewCertificateForAdminViewModeDelete(this);

        // Run the page
        return await crewCertificateForAdminViewModeDelete.Run();
    }
}
