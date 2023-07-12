namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TrNotificationList/{ID?}", Name = "TrNotificationList-TRNotification-list")]
    [Route("Home/TrNotificationList/{ID?}", Name = "TrNotificationList-TRNotification-list-2")]
    public async Task<IActionResult> TrNotificationList()
    {
        // Create page object
        trNotificationList = new GLOBALS.TrNotificationList(this);
        trNotificationList.Cache = _cache;

        // Run the page
        return await trNotificationList.Run();
    }
}
