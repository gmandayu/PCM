namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VCrewBlacklistForAdminList/{ID?}", Name = "VCrewBlacklistForAdminList-v_CrewBlacklistForAdmin-list")]
    [Route("Home/VCrewBlacklistForAdminList/{ID?}", Name = "VCrewBlacklistForAdminList-v_CrewBlacklistForAdmin-list-2")]
    public async Task<IActionResult> VCrewBlacklistForAdminList()
    {
        // Create page object
        vCrewBlacklistForAdminList = new GLOBALS.VCrewBlacklistForAdminList(this);
        vCrewBlacklistForAdminList.Cache = _cache;

        // Run the page
        return await vCrewBlacklistForAdminList.Run();
    }

    // view
    [Route("VCrewBlacklistForAdminView/{ID?}", Name = "VCrewBlacklistForAdminView-v_CrewBlacklistForAdmin-view")]
    [Route("Home/VCrewBlacklistForAdminView/{ID?}", Name = "VCrewBlacklistForAdminView-v_CrewBlacklistForAdmin-view-2")]
    public async Task<IActionResult> VCrewBlacklistForAdminView()
    {
        // Create page object
        vCrewBlacklistForAdminView = new GLOBALS.VCrewBlacklistForAdminView(this);

        // Run the page
        return await vCrewBlacklistForAdminView.Run();
    }

    // edit
    [Route("VCrewBlacklistForAdminEdit/{ID?}", Name = "VCrewBlacklistForAdminEdit-v_CrewBlacklistForAdmin-edit")]
    [Route("Home/VCrewBlacklistForAdminEdit/{ID?}", Name = "VCrewBlacklistForAdminEdit-v_CrewBlacklistForAdmin-edit-2")]
    public async Task<IActionResult> VCrewBlacklistForAdminEdit()
    {
        // Create page object
        vCrewBlacklistForAdminEdit = new GLOBALS.VCrewBlacklistForAdminEdit(this);

        // Run the page
        return await vCrewBlacklistForAdminEdit.Run();
    }

    // delete
    [Route("VCrewBlacklistForAdminDelete/{ID?}", Name = "VCrewBlacklistForAdminDelete-v_CrewBlacklistForAdmin-delete")]
    [Route("Home/VCrewBlacklistForAdminDelete/{ID?}", Name = "VCrewBlacklistForAdminDelete-v_CrewBlacklistForAdmin-delete-2")]
    public async Task<IActionResult> VCrewBlacklistForAdminDelete()
    {
        // Create page object
        vCrewBlacklistForAdminDelete = new GLOBALS.VCrewBlacklistForAdminDelete(this);

        // Run the page
        return await vCrewBlacklistForAdminDelete.Run();
    }

    // search
    [Route("VCrewBlacklistForAdminSearch", Name = "VCrewBlacklistForAdminSearch-v_CrewBlacklistForAdmin-search")]
    [Route("Home/VCrewBlacklistForAdminSearch", Name = "VCrewBlacklistForAdminSearch-v_CrewBlacklistForAdmin-search-2")]
    public async Task<IActionResult> VCrewBlacklistForAdminSearch()
    {
        // Create page object
        vCrewBlacklistForAdminSearch = new GLOBALS.VCrewBlacklistForAdminSearch(this);

        // Run the page
        return await vCrewBlacklistForAdminSearch.Run();
    }
}
