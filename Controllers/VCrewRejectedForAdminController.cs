namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VCrewRejectedForAdminList/{ID?}", Name = "VCrewRejectedForAdminList-v_CrewRejectedForAdmin-list")]
    [Route("Home/VCrewRejectedForAdminList/{ID?}", Name = "VCrewRejectedForAdminList-v_CrewRejectedForAdmin-list-2")]
    public async Task<IActionResult> VCrewRejectedForAdminList()
    {
        // Create page object
        vCrewRejectedForAdminList = new GLOBALS.VCrewRejectedForAdminList(this);
        vCrewRejectedForAdminList.Cache = _cache;

        // Run the page
        return await vCrewRejectedForAdminList.Run();
    }

    // view
    [Route("VCrewRejectedForAdminView/{ID?}", Name = "VCrewRejectedForAdminView-v_CrewRejectedForAdmin-view")]
    [Route("Home/VCrewRejectedForAdminView/{ID?}", Name = "VCrewRejectedForAdminView-v_CrewRejectedForAdmin-view-2")]
    public async Task<IActionResult> VCrewRejectedForAdminView()
    {
        // Create page object
        vCrewRejectedForAdminView = new GLOBALS.VCrewRejectedForAdminView(this);

        // Run the page
        return await vCrewRejectedForAdminView.Run();
    }

    // edit
    [Route("VCrewRejectedForAdminEdit/{ID?}", Name = "VCrewRejectedForAdminEdit-v_CrewRejectedForAdmin-edit")]
    [Route("Home/VCrewRejectedForAdminEdit/{ID?}", Name = "VCrewRejectedForAdminEdit-v_CrewRejectedForAdmin-edit-2")]
    public async Task<IActionResult> VCrewRejectedForAdminEdit()
    {
        // Create page object
        vCrewRejectedForAdminEdit = new GLOBALS.VCrewRejectedForAdminEdit(this);

        // Run the page
        return await vCrewRejectedForAdminEdit.Run();
    }

    // delete
    [Route("VCrewRejectedForAdminDelete/{ID?}", Name = "VCrewRejectedForAdminDelete-v_CrewRejectedForAdmin-delete")]
    [Route("Home/VCrewRejectedForAdminDelete/{ID?}", Name = "VCrewRejectedForAdminDelete-v_CrewRejectedForAdmin-delete-2")]
    public async Task<IActionResult> VCrewRejectedForAdminDelete()
    {
        // Create page object
        vCrewRejectedForAdminDelete = new GLOBALS.VCrewRejectedForAdminDelete(this);

        // Run the page
        return await vCrewRejectedForAdminDelete.Run();
    }

    // search
    [Route("VCrewRejectedForAdminSearch", Name = "VCrewRejectedForAdminSearch-v_CrewRejectedForAdmin-search")]
    [Route("Home/VCrewRejectedForAdminSearch", Name = "VCrewRejectedForAdminSearch-v_CrewRejectedForAdmin-search-2")]
    public async Task<IActionResult> VCrewRejectedForAdminSearch()
    {
        // Create page object
        vCrewRejectedForAdminSearch = new GLOBALS.VCrewRejectedForAdminSearch(this);

        // Run the page
        return await vCrewRejectedForAdminSearch.Run();
    }
}
