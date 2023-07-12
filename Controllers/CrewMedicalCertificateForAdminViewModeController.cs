namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewMedicalCertificateForAdminViewModeList/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeList-CrewMedicalCertificateForAdminViewMode-list")]
    [Route("Home/CrewMedicalCertificateForAdminViewModeList/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeList-CrewMedicalCertificateForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminViewModeList()
    {
        // Create page object
        crewMedicalCertificateForAdminViewModeList = new GLOBALS.CrewMedicalCertificateForAdminViewModeList(this);
        crewMedicalCertificateForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewMedicalCertificateForAdminViewModeList.Run();
    }

    // add
    [Route("CrewMedicalCertificateForAdminViewModeAdd/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeAdd-CrewMedicalCertificateForAdminViewMode-add")]
    [Route("Home/CrewMedicalCertificateForAdminViewModeAdd/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeAdd-CrewMedicalCertificateForAdminViewMode-add-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminViewModeAdd()
    {
        // Create page object
        crewMedicalCertificateForAdminViewModeAdd = new GLOBALS.CrewMedicalCertificateForAdminViewModeAdd(this);

        // Run the page
        return await crewMedicalCertificateForAdminViewModeAdd.Run();
    }

    // view
    [Route("CrewMedicalCertificateForAdminViewModeView/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeView-CrewMedicalCertificateForAdminViewMode-view")]
    [Route("Home/CrewMedicalCertificateForAdminViewModeView/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeView-CrewMedicalCertificateForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminViewModeView()
    {
        // Create page object
        crewMedicalCertificateForAdminViewModeView = new GLOBALS.CrewMedicalCertificateForAdminViewModeView(this);

        // Run the page
        return await crewMedicalCertificateForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewMedicalCertificateForAdminViewModeEdit/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeEdit-CrewMedicalCertificateForAdminViewMode-edit")]
    [Route("Home/CrewMedicalCertificateForAdminViewModeEdit/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeEdit-CrewMedicalCertificateForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminViewModeEdit()
    {
        // Create page object
        crewMedicalCertificateForAdminViewModeEdit = new GLOBALS.CrewMedicalCertificateForAdminViewModeEdit(this);

        // Run the page
        return await crewMedicalCertificateForAdminViewModeEdit.Run();
    }

    // delete
    [Route("CrewMedicalCertificateForAdminViewModeDelete/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeDelete-CrewMedicalCertificateForAdminViewMode-delete")]
    [Route("Home/CrewMedicalCertificateForAdminViewModeDelete/{ID?}", Name = "CrewMedicalCertificateForAdminViewModeDelete-CrewMedicalCertificateForAdminViewMode-delete-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminViewModeDelete()
    {
        // Create page object
        crewMedicalCertificateForAdminViewModeDelete = new GLOBALS.CrewMedicalCertificateForAdminViewModeDelete(this);

        // Run the page
        return await crewMedicalCertificateForAdminViewModeDelete.Run();
    }

    // search
    [Route("CrewMedicalCertificateForAdminViewModeSearch", Name = "CrewMedicalCertificateForAdminViewModeSearch-CrewMedicalCertificateForAdminViewMode-search")]
    [Route("Home/CrewMedicalCertificateForAdminViewModeSearch", Name = "CrewMedicalCertificateForAdminViewModeSearch-CrewMedicalCertificateForAdminViewMode-search-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminViewModeSearch()
    {
        // Create page object
        crewMedicalCertificateForAdminViewModeSearch = new GLOBALS.CrewMedicalCertificateForAdminViewModeSearch(this);

        // Run the page
        return await crewMedicalCertificateForAdminViewModeSearch.Run();
    }
}
