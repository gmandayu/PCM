namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewCertificateForAdminList/{ID?}", Name = "CrewCertificateForAdminList-CrewCertificateForAdmin-list")]
    [Route("Home/CrewCertificateForAdminList/{ID?}", Name = "CrewCertificateForAdminList-CrewCertificateForAdmin-list-2")]
    public async Task<IActionResult> CrewCertificateForAdminList()
    {
        // Create page object
        crewCertificateForAdminList = new GLOBALS.CrewCertificateForAdminList(this);
        crewCertificateForAdminList.Cache = _cache;

        // Run the page
        return await crewCertificateForAdminList.Run();
    }

    // add
    [Route("CrewCertificateForAdminAdd/{ID?}", Name = "CrewCertificateForAdminAdd-CrewCertificateForAdmin-add")]
    [Route("Home/CrewCertificateForAdminAdd/{ID?}", Name = "CrewCertificateForAdminAdd-CrewCertificateForAdmin-add-2")]
    public async Task<IActionResult> CrewCertificateForAdminAdd()
    {
        // Create page object
        crewCertificateForAdminAdd = new GLOBALS.CrewCertificateForAdminAdd(this);

        // Run the page
        return await crewCertificateForAdminAdd.Run();
    }

    // edit
    [Route("CrewCertificateForAdminEdit/{ID?}", Name = "CrewCertificateForAdminEdit-CrewCertificateForAdmin-edit")]
    [Route("Home/CrewCertificateForAdminEdit/{ID?}", Name = "CrewCertificateForAdminEdit-CrewCertificateForAdmin-edit-2")]
    public async Task<IActionResult> CrewCertificateForAdminEdit()
    {
        // Create page object
        crewCertificateForAdminEdit = new GLOBALS.CrewCertificateForAdminEdit(this);

        // Run the page
        return await crewCertificateForAdminEdit.Run();
    }

    // delete
    [Route("CrewCertificateForAdminDelete/{ID?}", Name = "CrewCertificateForAdminDelete-CrewCertificateForAdmin-delete")]
    [Route("Home/CrewCertificateForAdminDelete/{ID?}", Name = "CrewCertificateForAdminDelete-CrewCertificateForAdmin-delete-2")]
    public async Task<IActionResult> CrewCertificateForAdminDelete()
    {
        // Create page object
        crewCertificateForAdminDelete = new GLOBALS.CrewCertificateForAdminDelete(this);

        // Run the page
        return await crewCertificateForAdminDelete.Run();
    }
}
