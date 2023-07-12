namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VCrewAcceptedForAdminList/{ID?}", Name = "VCrewAcceptedForAdminList-v_CrewAcceptedForAdmin-list")]
    [Route("Home/VCrewAcceptedForAdminList/{ID?}", Name = "VCrewAcceptedForAdminList-v_CrewAcceptedForAdmin-list-2")]
    public async Task<IActionResult> VCrewAcceptedForAdminList()
    {
        // Create page object
        vCrewAcceptedForAdminList = new GLOBALS.VCrewAcceptedForAdminList(this);
        vCrewAcceptedForAdminList.Cache = _cache;

        // Run the page
        return await vCrewAcceptedForAdminList.Run();
    }

    // view
    [Route("VCrewAcceptedForAdminView/{ID?}", Name = "VCrewAcceptedForAdminView-v_CrewAcceptedForAdmin-view")]
    [Route("Home/VCrewAcceptedForAdminView/{ID?}", Name = "VCrewAcceptedForAdminView-v_CrewAcceptedForAdmin-view-2")]
    public async Task<IActionResult> VCrewAcceptedForAdminView()
    {
        // Create page object
        vCrewAcceptedForAdminView = new GLOBALS.VCrewAcceptedForAdminView(this);

        // Run the page
        return await vCrewAcceptedForAdminView.Run();
    }

    // edit
    [Route("VCrewAcceptedForAdminEdit/{ID?}", Name = "VCrewAcceptedForAdminEdit-v_CrewAcceptedForAdmin-edit")]
    [Route("Home/VCrewAcceptedForAdminEdit/{ID?}", Name = "VCrewAcceptedForAdminEdit-v_CrewAcceptedForAdmin-edit-2")]
    public async Task<IActionResult> VCrewAcceptedForAdminEdit()
    {
        // Create page object
        vCrewAcceptedForAdminEdit = new GLOBALS.VCrewAcceptedForAdminEdit(this);

        // Run the page
        return await vCrewAcceptedForAdminEdit.Run();
    }

    // delete
    [Route("VCrewAcceptedForAdminDelete/{ID?}", Name = "VCrewAcceptedForAdminDelete-v_CrewAcceptedForAdmin-delete")]
    [Route("Home/VCrewAcceptedForAdminDelete/{ID?}", Name = "VCrewAcceptedForAdminDelete-v_CrewAcceptedForAdmin-delete-2")]
    public async Task<IActionResult> VCrewAcceptedForAdminDelete()
    {
        // Create page object
        vCrewAcceptedForAdminDelete = new GLOBALS.VCrewAcceptedForAdminDelete(this);

        // Run the page
        return await vCrewAcceptedForAdminDelete.Run();
    }

    // search
    [Route("VCrewAcceptedForAdminSearch", Name = "VCrewAcceptedForAdminSearch-v_CrewAcceptedForAdmin-search")]
    [Route("Home/VCrewAcceptedForAdminSearch", Name = "VCrewAcceptedForAdminSearch-v_CrewAcceptedForAdmin-search-2")]
    public async Task<IActionResult> VCrewAcceptedForAdminSearch()
    {
        // Create page object
        vCrewAcceptedForAdminSearch = new GLOBALS.VCrewAcceptedForAdminSearch(this);

        // Run the page
        return await vCrewAcceptedForAdminSearch.Run();
    }
}
