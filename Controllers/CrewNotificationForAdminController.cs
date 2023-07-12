namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewNotificationForAdminList/{ID?}", Name = "CrewNotificationForAdminList-CrewNotificationForAdmin-list")]
    [Route("Home/CrewNotificationForAdminList/{ID?}", Name = "CrewNotificationForAdminList-CrewNotificationForAdmin-list-2")]
    public async Task<IActionResult> CrewNotificationForAdminList()
    {
        // Create page object
        crewNotificationForAdminList = new GLOBALS.CrewNotificationForAdminList(this);
        crewNotificationForAdminList.Cache = _cache;

        // Run the page
        return await crewNotificationForAdminList.Run();
    }

    // add
    [Route("CrewNotificationForAdminAdd/{ID?}", Name = "CrewNotificationForAdminAdd-CrewNotificationForAdmin-add")]
    [Route("Home/CrewNotificationForAdminAdd/{ID?}", Name = "CrewNotificationForAdminAdd-CrewNotificationForAdmin-add-2")]
    public async Task<IActionResult> CrewNotificationForAdminAdd()
    {
        // Create page object
        crewNotificationForAdminAdd = new GLOBALS.CrewNotificationForAdminAdd(this);

        // Run the page
        return await crewNotificationForAdminAdd.Run();
    }
}
