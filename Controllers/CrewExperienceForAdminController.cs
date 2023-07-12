namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewExperienceForAdminList/{ID?}", Name = "CrewExperienceForAdminList-CrewExperienceForAdmin-list")]
    [Route("Home/CrewExperienceForAdminList/{ID?}", Name = "CrewExperienceForAdminList-CrewExperienceForAdmin-list-2")]
    public async Task<IActionResult> CrewExperienceForAdminList()
    {
        // Create page object
        crewExperienceForAdminList = new GLOBALS.CrewExperienceForAdminList(this);
        crewExperienceForAdminList.Cache = _cache;

        // Run the page
        return await crewExperienceForAdminList.Run();
    }

    // add
    [Route("CrewExperienceForAdminAdd/{ID?}", Name = "CrewExperienceForAdminAdd-CrewExperienceForAdmin-add")]
    [Route("Home/CrewExperienceForAdminAdd/{ID?}", Name = "CrewExperienceForAdminAdd-CrewExperienceForAdmin-add-2")]
    public async Task<IActionResult> CrewExperienceForAdminAdd()
    {
        // Create page object
        crewExperienceForAdminAdd = new GLOBALS.CrewExperienceForAdminAdd(this);

        // Run the page
        return await crewExperienceForAdminAdd.Run();
    }

    // edit
    [Route("CrewExperienceForAdminEdit/{ID?}", Name = "CrewExperienceForAdminEdit-CrewExperienceForAdmin-edit")]
    [Route("Home/CrewExperienceForAdminEdit/{ID?}", Name = "CrewExperienceForAdminEdit-CrewExperienceForAdmin-edit-2")]
    public async Task<IActionResult> CrewExperienceForAdminEdit()
    {
        // Create page object
        crewExperienceForAdminEdit = new GLOBALS.CrewExperienceForAdminEdit(this);

        // Run the page
        return await crewExperienceForAdminEdit.Run();
    }

    // delete
    [Route("CrewExperienceForAdminDelete/{ID?}", Name = "CrewExperienceForAdminDelete-CrewExperienceForAdmin-delete")]
    [Route("Home/CrewExperienceForAdminDelete/{ID?}", Name = "CrewExperienceForAdminDelete-CrewExperienceForAdmin-delete-2")]
    public async Task<IActionResult> CrewExperienceForAdminDelete()
    {
        // Create page object
        crewExperienceForAdminDelete = new GLOBALS.CrewExperienceForAdminDelete(this);

        // Run the page
        return await crewExperienceForAdminDelete.Run();
    }
}
