namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewMedicalHistoryForAdminList/{ID?}", Name = "CrewMedicalHistoryForAdminList-CrewMedicalHistoryForAdmin-list")]
    [Route("Home/CrewMedicalHistoryForAdminList/{ID?}", Name = "CrewMedicalHistoryForAdminList-CrewMedicalHistoryForAdmin-list-2")]
    public async Task<IActionResult> CrewMedicalHistoryForAdminList()
    {
        // Create page object
        crewMedicalHistoryForAdminList = new GLOBALS.CrewMedicalHistoryForAdminList(this);
        crewMedicalHistoryForAdminList.Cache = _cache;

        // Run the page
        return await crewMedicalHistoryForAdminList.Run();
    }

    // add
    [Route("CrewMedicalHistoryForAdminAdd/{ID?}", Name = "CrewMedicalHistoryForAdminAdd-CrewMedicalHistoryForAdmin-add")]
    [Route("Home/CrewMedicalHistoryForAdminAdd/{ID?}", Name = "CrewMedicalHistoryForAdminAdd-CrewMedicalHistoryForAdmin-add-2")]
    public async Task<IActionResult> CrewMedicalHistoryForAdminAdd()
    {
        // Create page object
        crewMedicalHistoryForAdminAdd = new GLOBALS.CrewMedicalHistoryForAdminAdd(this);

        // Run the page
        return await crewMedicalHistoryForAdminAdd.Run();
    }

    // edit
    [Route("CrewMedicalHistoryForAdminEdit/{ID?}", Name = "CrewMedicalHistoryForAdminEdit-CrewMedicalHistoryForAdmin-edit")]
    [Route("Home/CrewMedicalHistoryForAdminEdit/{ID?}", Name = "CrewMedicalHistoryForAdminEdit-CrewMedicalHistoryForAdmin-edit-2")]
    public async Task<IActionResult> CrewMedicalHistoryForAdminEdit()
    {
        // Create page object
        crewMedicalHistoryForAdminEdit = new GLOBALS.CrewMedicalHistoryForAdminEdit(this);

        // Run the page
        return await crewMedicalHistoryForAdminEdit.Run();
    }

    // delete
    [Route("CrewMedicalHistoryForAdminDelete/{ID?}", Name = "CrewMedicalHistoryForAdminDelete-CrewMedicalHistoryForAdmin-delete")]
    [Route("Home/CrewMedicalHistoryForAdminDelete/{ID?}", Name = "CrewMedicalHistoryForAdminDelete-CrewMedicalHistoryForAdmin-delete-2")]
    public async Task<IActionResult> CrewMedicalHistoryForAdminDelete()
    {
        // Create page object
        crewMedicalHistoryForAdminDelete = new GLOBALS.CrewMedicalHistoryForAdminDelete(this);

        // Run the page
        return await crewMedicalHistoryForAdminDelete.Run();
    }
}
