namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("UpdateTrackingList/{ID?}", Name = "UpdateTrackingList-UpdateTracking-list")]
    [Route("Home/UpdateTrackingList/{ID?}", Name = "UpdateTrackingList-UpdateTracking-list-2")]
    public async Task<IActionResult> UpdateTrackingList()
    {
        // Create page object
        updateTrackingList = new GLOBALS.UpdateTrackingList(this);
        updateTrackingList.Cache = _cache;

        // Run the page
        return await updateTrackingList.Run();
    }

    // view
    [Route("UpdateTrackingView/{ID?}", Name = "UpdateTrackingView-UpdateTracking-view")]
    [Route("Home/UpdateTrackingView/{ID?}", Name = "UpdateTrackingView-UpdateTracking-view-2")]
    public async Task<IActionResult> UpdateTrackingView()
    {
        // Create page object
        updateTrackingView = new GLOBALS.UpdateTrackingView(this);

        // Run the page
        return await updateTrackingView.Run();
    }

    // search
    [Route("UpdateTrackingSearch", Name = "UpdateTrackingSearch-UpdateTracking-search")]
    [Route("Home/UpdateTrackingSearch", Name = "UpdateTrackingSearch-UpdateTracking-search-2")]
    public async Task<IActionResult> UpdateTrackingSearch()
    {
        // Create page object
        updateTrackingSearch = new GLOBALS.UpdateTrackingSearch(this);

        // Run the page
        return await updateTrackingSearch.Run();
    }
}
