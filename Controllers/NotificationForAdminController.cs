namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("NotificationForAdminList/{ID?}", Name = "NotificationForAdminList-NotificationForAdmin-list")]
    [Route("Home/NotificationForAdminList/{ID?}", Name = "NotificationForAdminList-NotificationForAdmin-list-2")]
    public async Task<IActionResult> NotificationForAdminList()
    {
        // Create page object
        notificationForAdminList = new GLOBALS.NotificationForAdminList(this);
        notificationForAdminList.Cache = _cache;

        // Run the page
        return await notificationForAdminList.Run();
    }

    // add
    [Route("NotificationForAdminAdd/{ID?}", Name = "NotificationForAdminAdd-NotificationForAdmin-add")]
    [Route("Home/NotificationForAdminAdd/{ID?}", Name = "NotificationForAdminAdd-NotificationForAdmin-add-2")]
    public async Task<IActionResult> NotificationForAdminAdd()
    {
        // Create page object
        notificationForAdminAdd = new GLOBALS.NotificationForAdminAdd(this);

        // Run the page
        return await notificationForAdminAdd.Run();
    }

    // view
    [Route("NotificationForAdminView/{ID?}", Name = "NotificationForAdminView-NotificationForAdmin-view")]
    [Route("Home/NotificationForAdminView/{ID?}", Name = "NotificationForAdminView-NotificationForAdmin-view-2")]
    public async Task<IActionResult> NotificationForAdminView()
    {
        // Create page object
        notificationForAdminView = new GLOBALS.NotificationForAdminView(this);

        // Run the page
        return await notificationForAdminView.Run();
    }

    // search
    [Route("NotificationForAdminSearch", Name = "NotificationForAdminSearch-NotificationForAdmin-search")]
    [Route("Home/NotificationForAdminSearch", Name = "NotificationForAdminSearch-NotificationForAdmin-search-2")]
    public async Task<IActionResult> NotificationForAdminSearch()
    {
        // Create page object
        notificationForAdminSearch = new GLOBALS.NotificationForAdminSearch(this);

        // Run the page
        return await notificationForAdminSearch.Run();
    }
}
