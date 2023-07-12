namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewFamilyForAdminList/{ID?}", Name = "CrewFamilyForAdminList-CrewFamilyForAdmin-list")]
    [Route("Home/CrewFamilyForAdminList/{ID?}", Name = "CrewFamilyForAdminList-CrewFamilyForAdmin-list-2")]
    public async Task<IActionResult> CrewFamilyForAdminList()
    {
        // Create page object
        crewFamilyForAdminList = new GLOBALS.CrewFamilyForAdminList(this);
        crewFamilyForAdminList.Cache = _cache;

        // Run the page
        return await crewFamilyForAdminList.Run();
    }

    // add
    [Route("CrewFamilyForAdminAdd/{ID?}", Name = "CrewFamilyForAdminAdd-CrewFamilyForAdmin-add")]
    [Route("Home/CrewFamilyForAdminAdd/{ID?}", Name = "CrewFamilyForAdminAdd-CrewFamilyForAdmin-add-2")]
    public async Task<IActionResult> CrewFamilyForAdminAdd()
    {
        // Create page object
        crewFamilyForAdminAdd = new GLOBALS.CrewFamilyForAdminAdd(this);

        // Run the page
        return await crewFamilyForAdminAdd.Run();
    }

    // edit
    [Route("CrewFamilyForAdminEdit/{ID?}", Name = "CrewFamilyForAdminEdit-CrewFamilyForAdmin-edit")]
    [Route("Home/CrewFamilyForAdminEdit/{ID?}", Name = "CrewFamilyForAdminEdit-CrewFamilyForAdmin-edit-2")]
    public async Task<IActionResult> CrewFamilyForAdminEdit()
    {
        // Create page object
        crewFamilyForAdminEdit = new GLOBALS.CrewFamilyForAdminEdit(this);

        // Run the page
        return await crewFamilyForAdminEdit.Run();
    }

    // delete
    [Route("CrewFamilyForAdminDelete/{ID?}", Name = "CrewFamilyForAdminDelete-CrewFamilyForAdmin-delete")]
    [Route("Home/CrewFamilyForAdminDelete/{ID?}", Name = "CrewFamilyForAdminDelete-CrewFamilyForAdmin-delete-2")]
    public async Task<IActionResult> CrewFamilyForAdminDelete()
    {
        // Create page object
        crewFamilyForAdminDelete = new GLOBALS.CrewFamilyForAdminDelete(this);

        // Run the page
        return await crewFamilyForAdminDelete.Run();
    }
}
