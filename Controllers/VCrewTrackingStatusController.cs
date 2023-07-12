namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VCrewTrackingStatusList/{ID?}", Name = "VCrewTrackingStatusList-v_CrewTrackingStatus-list")]
    [Route("Home/VCrewTrackingStatusList/{ID?}", Name = "VCrewTrackingStatusList-v_CrewTrackingStatus-list-2")]
    public async Task<IActionResult> VCrewTrackingStatusList()
    {
        // Create page object
        vCrewTrackingStatusList = new GLOBALS.VCrewTrackingStatusList(this);
        vCrewTrackingStatusList.Cache = _cache;

        // Run the page
        return await vCrewTrackingStatusList.Run();
    }

    // view
    [Route("VCrewTrackingStatusView/{ID?}", Name = "VCrewTrackingStatusView-v_CrewTrackingStatus-view")]
    [Route("Home/VCrewTrackingStatusView/{ID?}", Name = "VCrewTrackingStatusView-v_CrewTrackingStatus-view-2")]
    public async Task<IActionResult> VCrewTrackingStatusView()
    {
        // Create page object
        vCrewTrackingStatusView = new GLOBALS.VCrewTrackingStatusView(this);

        // Run the page
        return await vCrewTrackingStatusView.Run();
    }

    // edit
    [Route("VCrewTrackingStatusEdit/{ID?}", Name = "VCrewTrackingStatusEdit-v_CrewTrackingStatus-edit")]
    [Route("Home/VCrewTrackingStatusEdit/{ID?}", Name = "VCrewTrackingStatusEdit-v_CrewTrackingStatus-edit-2")]
    public async Task<IActionResult> VCrewTrackingStatusEdit()
    {
        // Create page object
        vCrewTrackingStatusEdit = new GLOBALS.VCrewTrackingStatusEdit(this);

        // Run the page
        return await vCrewTrackingStatusEdit.Run();
    }

    // delete
    [Route("VCrewTrackingStatusDelete/{ID?}", Name = "VCrewTrackingStatusDelete-v_CrewTrackingStatus-delete")]
    [Route("Home/VCrewTrackingStatusDelete/{ID?}", Name = "VCrewTrackingStatusDelete-v_CrewTrackingStatus-delete-2")]
    public async Task<IActionResult> VCrewTrackingStatusDelete()
    {
        // Create page object
        vCrewTrackingStatusDelete = new GLOBALS.VCrewTrackingStatusDelete(this);

        // Run the page
        return await vCrewTrackingStatusDelete.Run();
    }

    // search
    [Route("VCrewTrackingStatusSearch", Name = "VCrewTrackingStatusSearch-v_CrewTrackingStatus-search")]
    [Route("Home/VCrewTrackingStatusSearch", Name = "VCrewTrackingStatusSearch-v_CrewTrackingStatus-search-2")]
    public async Task<IActionResult> VCrewTrackingStatusSearch()
    {
        // Create page object
        vCrewTrackingStatusSearch = new GLOBALS.VCrewTrackingStatusSearch(this);

        // Run the page
        return await vCrewTrackingStatusSearch.Run();
    }
}
