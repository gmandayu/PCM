namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewFormalEducationForAdminList/{ID?}", Name = "CrewFormalEducationForAdminList-CrewFormalEducationForAdmin-list")]
    [Route("Home/CrewFormalEducationForAdminList/{ID?}", Name = "CrewFormalEducationForAdminList-CrewFormalEducationForAdmin-list-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminList()
    {
        // Create page object
        crewFormalEducationForAdminList = new GLOBALS.CrewFormalEducationForAdminList(this);
        crewFormalEducationForAdminList.Cache = _cache;

        // Run the page
        return await crewFormalEducationForAdminList.Run();
    }

    // add
    [Route("CrewFormalEducationForAdminAdd/{ID?}", Name = "CrewFormalEducationForAdminAdd-CrewFormalEducationForAdmin-add")]
    [Route("Home/CrewFormalEducationForAdminAdd/{ID?}", Name = "CrewFormalEducationForAdminAdd-CrewFormalEducationForAdmin-add-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminAdd()
    {
        // Create page object
        crewFormalEducationForAdminAdd = new GLOBALS.CrewFormalEducationForAdminAdd(this);

        // Run the page
        return await crewFormalEducationForAdminAdd.Run();
    }

    // view
    [Route("CrewFormalEducationForAdminView/{ID?}", Name = "CrewFormalEducationForAdminView-CrewFormalEducationForAdmin-view")]
    [Route("Home/CrewFormalEducationForAdminView/{ID?}", Name = "CrewFormalEducationForAdminView-CrewFormalEducationForAdmin-view-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminView()
    {
        // Create page object
        crewFormalEducationForAdminView = new GLOBALS.CrewFormalEducationForAdminView(this);

        // Run the page
        return await crewFormalEducationForAdminView.Run();
    }

    // edit
    [Route("CrewFormalEducationForAdminEdit/{ID?}", Name = "CrewFormalEducationForAdminEdit-CrewFormalEducationForAdmin-edit")]
    [Route("Home/CrewFormalEducationForAdminEdit/{ID?}", Name = "CrewFormalEducationForAdminEdit-CrewFormalEducationForAdmin-edit-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminEdit()
    {
        // Create page object
        crewFormalEducationForAdminEdit = new GLOBALS.CrewFormalEducationForAdminEdit(this);

        // Run the page
        return await crewFormalEducationForAdminEdit.Run();
    }

    // delete
    [Route("CrewFormalEducationForAdminDelete/{ID?}", Name = "CrewFormalEducationForAdminDelete-CrewFormalEducationForAdmin-delete")]
    [Route("Home/CrewFormalEducationForAdminDelete/{ID?}", Name = "CrewFormalEducationForAdminDelete-CrewFormalEducationForAdmin-delete-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminDelete()
    {
        // Create page object
        crewFormalEducationForAdminDelete = new GLOBALS.CrewFormalEducationForAdminDelete(this);

        // Run the page
        return await crewFormalEducationForAdminDelete.Run();
    }

    // search
    [Route("CrewFormalEducationForAdminSearch", Name = "CrewFormalEducationForAdminSearch-CrewFormalEducationForAdmin-search")]
    [Route("Home/CrewFormalEducationForAdminSearch", Name = "CrewFormalEducationForAdminSearch-CrewFormalEducationForAdmin-search-2")]
    public async Task<IActionResult> CrewFormalEducationForAdminSearch()
    {
        // Create page object
        crewFormalEducationForAdminSearch = new GLOBALS.CrewFormalEducationForAdminSearch(this);

        // Run the page
        return await crewFormalEducationForAdminSearch.Run();
    }
}
