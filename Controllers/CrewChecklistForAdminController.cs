namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewChecklistForAdminList/{ID?}", Name = "CrewChecklistForAdminList-CrewChecklistForAdmin-list")]
    [Route("Home/CrewChecklistForAdminList/{ID?}", Name = "CrewChecklistForAdminList-CrewChecklistForAdmin-list-2")]
    public async Task<IActionResult> CrewChecklistForAdminList()
    {
        // Create page object
        crewChecklistForAdminList = new GLOBALS.CrewChecklistForAdminList(this);
        crewChecklistForAdminList.Cache = _cache;

        // Run the page
        return await crewChecklistForAdminList.Run();
    }

    // view
    [Route("CrewChecklistForAdminView/{ID?}", Name = "CrewChecklistForAdminView-CrewChecklistForAdmin-view")]
    [Route("Home/CrewChecklistForAdminView/{ID?}", Name = "CrewChecklistForAdminView-CrewChecklistForAdmin-view-2")]
    public async Task<IActionResult> CrewChecklistForAdminView()
    {
        // Create page object
        crewChecklistForAdminView = new GLOBALS.CrewChecklistForAdminView(this);

        // Run the page
        return await crewChecklistForAdminView.Run();
    }

    // edit
    [Route("CrewChecklistForAdminEdit/{ID?}", Name = "CrewChecklistForAdminEdit-CrewChecklistForAdmin-edit")]
    [Route("Home/CrewChecklistForAdminEdit/{ID?}", Name = "CrewChecklistForAdminEdit-CrewChecklistForAdmin-edit-2")]
    public async Task<IActionResult> CrewChecklistForAdminEdit()
    {
        // Create page object
        crewChecklistForAdminEdit = new GLOBALS.CrewChecklistForAdminEdit(this);

        // Run the page
        return await crewChecklistForAdminEdit.Run();
    }

    // search
    [Route("CrewChecklistForAdminSearch", Name = "CrewChecklistForAdminSearch-CrewChecklistForAdmin-search")]
    [Route("Home/CrewChecklistForAdminSearch", Name = "CrewChecklistForAdminSearch-CrewChecklistForAdmin-search-2")]
    public async Task<IActionResult> CrewChecklistForAdminSearch()
    {
        // Create page object
        crewChecklistForAdminSearch = new GLOBALS.CrewChecklistForAdminSearch(this);

        // Run the page
        return await crewChecklistForAdminSearch.Run();
    }
}
