namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("NotificationForCrewList/{ID?}", Name = "NotificationForCrewList-NotificationForCrew-list")]
    [Route("Home/NotificationForCrewList/{ID?}", Name = "NotificationForCrewList-NotificationForCrew-list-2")]
    public async Task<IActionResult> NotificationForCrewList()
    {
        // Create page object
        notificationForCrewList = new GLOBALS.NotificationForCrewList(this);
        notificationForCrewList.Cache = _cache;

        // Run the page
        return await notificationForCrewList.Run();
    }
}
