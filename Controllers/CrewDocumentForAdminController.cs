namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewDocumentForAdminList/{ID?}", Name = "CrewDocumentForAdminList-CrewDocumentForAdmin-list")]
    [Route("Home/CrewDocumentForAdminList/{ID?}", Name = "CrewDocumentForAdminList-CrewDocumentForAdmin-list-2")]
    public async Task<IActionResult> CrewDocumentForAdminList()
    {
        // Create page object
        crewDocumentForAdminList = new GLOBALS.CrewDocumentForAdminList(this);
        crewDocumentForAdminList.Cache = _cache;

        // Run the page
        return await crewDocumentForAdminList.Run();
    }

    // add
    [Route("CrewDocumentForAdminAdd/{ID?}", Name = "CrewDocumentForAdminAdd-CrewDocumentForAdmin-add")]
    [Route("Home/CrewDocumentForAdminAdd/{ID?}", Name = "CrewDocumentForAdminAdd-CrewDocumentForAdmin-add-2")]
    public async Task<IActionResult> CrewDocumentForAdminAdd()
    {
        // Create page object
        crewDocumentForAdminAdd = new GLOBALS.CrewDocumentForAdminAdd(this);

        // Run the page
        return await crewDocumentForAdminAdd.Run();
    }

    // edit
    [Route("CrewDocumentForAdminEdit/{ID?}", Name = "CrewDocumentForAdminEdit-CrewDocumentForAdmin-edit")]
    [Route("Home/CrewDocumentForAdminEdit/{ID?}", Name = "CrewDocumentForAdminEdit-CrewDocumentForAdmin-edit-2")]
    public async Task<IActionResult> CrewDocumentForAdminEdit()
    {
        // Create page object
        crewDocumentForAdminEdit = new GLOBALS.CrewDocumentForAdminEdit(this);

        // Run the page
        return await crewDocumentForAdminEdit.Run();
    }

    // delete
    [Route("CrewDocumentForAdminDelete/{ID?}", Name = "CrewDocumentForAdminDelete-CrewDocumentForAdmin-delete")]
    [Route("Home/CrewDocumentForAdminDelete/{ID?}", Name = "CrewDocumentForAdminDelete-CrewDocumentForAdmin-delete-2")]
    public async Task<IActionResult> CrewDocumentForAdminDelete()
    {
        // Create page object
        crewDocumentForAdminDelete = new GLOBALS.CrewDocumentForAdminDelete(this);

        // Run the page
        return await crewDocumentForAdminDelete.Run();
    }
}
