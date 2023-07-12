namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewMedicalCertificateForAdminList/{ID?}", Name = "CrewMedicalCertificateForAdminList-CrewMedicalCertificateForAdmin-list")]
    [Route("Home/CrewMedicalCertificateForAdminList/{ID?}", Name = "CrewMedicalCertificateForAdminList-CrewMedicalCertificateForAdmin-list-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminList()
    {
        // Create page object
        crewMedicalCertificateForAdminList = new GLOBALS.CrewMedicalCertificateForAdminList(this);
        crewMedicalCertificateForAdminList.Cache = _cache;

        // Run the page
        return await crewMedicalCertificateForAdminList.Run();
    }

    // add
    [Route("CrewMedicalCertificateForAdminAdd/{ID?}", Name = "CrewMedicalCertificateForAdminAdd-CrewMedicalCertificateForAdmin-add")]
    [Route("Home/CrewMedicalCertificateForAdminAdd/{ID?}", Name = "CrewMedicalCertificateForAdminAdd-CrewMedicalCertificateForAdmin-add-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminAdd()
    {
        // Create page object
        crewMedicalCertificateForAdminAdd = new GLOBALS.CrewMedicalCertificateForAdminAdd(this);

        // Run the page
        return await crewMedicalCertificateForAdminAdd.Run();
    }

    // view
    [Route("CrewMedicalCertificateForAdminView/{ID?}", Name = "CrewMedicalCertificateForAdminView-CrewMedicalCertificateForAdmin-view")]
    [Route("Home/CrewMedicalCertificateForAdminView/{ID?}", Name = "CrewMedicalCertificateForAdminView-CrewMedicalCertificateForAdmin-view-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminView()
    {
        // Create page object
        crewMedicalCertificateForAdminView = new GLOBALS.CrewMedicalCertificateForAdminView(this);

        // Run the page
        return await crewMedicalCertificateForAdminView.Run();
    }

    // edit
    [Route("CrewMedicalCertificateForAdminEdit/{ID?}", Name = "CrewMedicalCertificateForAdminEdit-CrewMedicalCertificateForAdmin-edit")]
    [Route("Home/CrewMedicalCertificateForAdminEdit/{ID?}", Name = "CrewMedicalCertificateForAdminEdit-CrewMedicalCertificateForAdmin-edit-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminEdit()
    {
        // Create page object
        crewMedicalCertificateForAdminEdit = new GLOBALS.CrewMedicalCertificateForAdminEdit(this);

        // Run the page
        return await crewMedicalCertificateForAdminEdit.Run();
    }

    // delete
    [Route("CrewMedicalCertificateForAdminDelete/{ID?}", Name = "CrewMedicalCertificateForAdminDelete-CrewMedicalCertificateForAdmin-delete")]
    [Route("Home/CrewMedicalCertificateForAdminDelete/{ID?}", Name = "CrewMedicalCertificateForAdminDelete-CrewMedicalCertificateForAdmin-delete-2")]
    public async Task<IActionResult> CrewMedicalCertificateForAdminDelete()
    {
        // Create page object
        crewMedicalCertificateForAdminDelete = new GLOBALS.CrewMedicalCertificateForAdminDelete(this);

        // Run the page
        return await crewMedicalCertificateForAdminDelete.Run();
    }
}
