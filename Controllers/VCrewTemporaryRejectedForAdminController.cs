namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VCrewTemporaryRejectedForAdminList/{ID?}", Name = "VCrewTemporaryRejectedForAdminList-v_CrewTemporaryRejectedForAdmin-list")]
    [Route("Home/VCrewTemporaryRejectedForAdminList/{ID?}", Name = "VCrewTemporaryRejectedForAdminList-v_CrewTemporaryRejectedForAdmin-list-2")]
    public async Task<IActionResult> VCrewTemporaryRejectedForAdminList()
    {
        // Create page object
        vCrewTemporaryRejectedForAdminList = new GLOBALS.VCrewTemporaryRejectedForAdminList(this);
        vCrewTemporaryRejectedForAdminList.Cache = _cache;

        // Run the page
        return await vCrewTemporaryRejectedForAdminList.Run();
    }

    // view
    [Route("VCrewTemporaryRejectedForAdminView/{ID?}", Name = "VCrewTemporaryRejectedForAdminView-v_CrewTemporaryRejectedForAdmin-view")]
    [Route("Home/VCrewTemporaryRejectedForAdminView/{ID?}", Name = "VCrewTemporaryRejectedForAdminView-v_CrewTemporaryRejectedForAdmin-view-2")]
    public async Task<IActionResult> VCrewTemporaryRejectedForAdminView()
    {
        // Create page object
        vCrewTemporaryRejectedForAdminView = new GLOBALS.VCrewTemporaryRejectedForAdminView(this);

        // Run the page
        return await vCrewTemporaryRejectedForAdminView.Run();
    }

    // edit
    [Route("VCrewTemporaryRejectedForAdminEdit/{ID?}", Name = "VCrewTemporaryRejectedForAdminEdit-v_CrewTemporaryRejectedForAdmin-edit")]
    [Route("Home/VCrewTemporaryRejectedForAdminEdit/{ID?}", Name = "VCrewTemporaryRejectedForAdminEdit-v_CrewTemporaryRejectedForAdmin-edit-2")]
    public async Task<IActionResult> VCrewTemporaryRejectedForAdminEdit()
    {
        // Create page object
        vCrewTemporaryRejectedForAdminEdit = new GLOBALS.VCrewTemporaryRejectedForAdminEdit(this);

        // Run the page
        return await vCrewTemporaryRejectedForAdminEdit.Run();
    }

    // delete
    [Route("VCrewTemporaryRejectedForAdminDelete/{ID?}", Name = "VCrewTemporaryRejectedForAdminDelete-v_CrewTemporaryRejectedForAdmin-delete")]
    [Route("Home/VCrewTemporaryRejectedForAdminDelete/{ID?}", Name = "VCrewTemporaryRejectedForAdminDelete-v_CrewTemporaryRejectedForAdmin-delete-2")]
    public async Task<IActionResult> VCrewTemporaryRejectedForAdminDelete()
    {
        // Create page object
        vCrewTemporaryRejectedForAdminDelete = new GLOBALS.VCrewTemporaryRejectedForAdminDelete(this);

        // Run the page
        return await vCrewTemporaryRejectedForAdminDelete.Run();
    }

    // search
    [Route("VCrewTemporaryRejectedForAdminSearch", Name = "VCrewTemporaryRejectedForAdminSearch-v_CrewTemporaryRejectedForAdmin-search")]
    [Route("Home/VCrewTemporaryRejectedForAdminSearch", Name = "VCrewTemporaryRejectedForAdminSearch-v_CrewTemporaryRejectedForAdmin-search-2")]
    public async Task<IActionResult> VCrewTemporaryRejectedForAdminSearch()
    {
        // Create page object
        vCrewTemporaryRejectedForAdminSearch = new GLOBALS.VCrewTemporaryRejectedForAdminSearch(this);

        // Run the page
        return await vCrewTemporaryRejectedForAdminSearch.Run();
    }
}
