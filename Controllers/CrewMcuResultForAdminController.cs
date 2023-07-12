namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewMcuResultForAdminList/{McuResult_ID?}", Name = "CrewMcuResultForAdminList-CrewMcuResultForAdmin-list")]
    [Route("Home/CrewMcuResultForAdminList/{McuResult_ID?}", Name = "CrewMcuResultForAdminList-CrewMcuResultForAdmin-list-2")]
    public async Task<IActionResult> CrewMcuResultForAdminList()
    {
        // Create page object
        crewMcuResultForAdminList = new GLOBALS.CrewMcuResultForAdminList(this);
        crewMcuResultForAdminList.Cache = _cache;

        // Run the page
        return await crewMcuResultForAdminList.Run();
    }

    // view
    [Route("CrewMcuResultForAdminView/{McuResult_ID?}", Name = "CrewMcuResultForAdminView-CrewMcuResultForAdmin-view")]
    [Route("Home/CrewMcuResultForAdminView/{McuResult_ID?}", Name = "CrewMcuResultForAdminView-CrewMcuResultForAdmin-view-2")]
    public async Task<IActionResult> CrewMcuResultForAdminView()
    {
        // Create page object
        crewMcuResultForAdminView = new GLOBALS.CrewMcuResultForAdminView(this);

        // Run the page
        return await crewMcuResultForAdminView.Run();
    }

    // edit
    [Route("CrewMcuResultForAdminEdit/{McuResult_ID?}", Name = "CrewMcuResultForAdminEdit-CrewMcuResultForAdmin-edit")]
    [Route("Home/CrewMcuResultForAdminEdit/{McuResult_ID?}", Name = "CrewMcuResultForAdminEdit-CrewMcuResultForAdmin-edit-2")]
    public async Task<IActionResult> CrewMcuResultForAdminEdit()
    {
        // Create page object
        crewMcuResultForAdminEdit = new GLOBALS.CrewMcuResultForAdminEdit(this);

        // Run the page
        return await crewMcuResultForAdminEdit.Run();
    }

    // search
    [Route("CrewMcuResultForAdminSearch", Name = "CrewMcuResultForAdminSearch-CrewMcuResultForAdmin-search")]
    [Route("Home/CrewMcuResultForAdminSearch", Name = "CrewMcuResultForAdminSearch-CrewMcuResultForAdmin-search-2")]
    public async Task<IActionResult> CrewMcuResultForAdminSearch()
    {
        // Create page object
        crewMcuResultForAdminSearch = new GLOBALS.CrewMcuResultForAdminSearch(this);

        // Run the page
        return await crewMcuResultForAdminSearch.Run();
    }
}
