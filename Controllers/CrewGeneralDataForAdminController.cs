namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewGeneralDataForAdminList/{ID?}", Name = "CrewGeneralDataForAdminList-CrewGeneralDataForAdmin-list")]
    [Route("Home/CrewGeneralDataForAdminList/{ID?}", Name = "CrewGeneralDataForAdminList-CrewGeneralDataForAdmin-list-2")]
    public async Task<IActionResult> CrewGeneralDataForAdminList()
    {
        // Create page object
        crewGeneralDataForAdminList = new GLOBALS.CrewGeneralDataForAdminList(this);
        crewGeneralDataForAdminList.Cache = _cache;

        // Run the page
        return await crewGeneralDataForAdminList.Run();
    }

    // edit
    [Route("CrewGeneralDataForAdminEdit/{ID?}", Name = "CrewGeneralDataForAdminEdit-CrewGeneralDataForAdmin-edit")]
    [Route("Home/CrewGeneralDataForAdminEdit/{ID?}", Name = "CrewGeneralDataForAdminEdit-CrewGeneralDataForAdmin-edit-2")]
    public async Task<IActionResult> CrewGeneralDataForAdminEdit()
    {
        // Create page object
        crewGeneralDataForAdminEdit = new GLOBALS.CrewGeneralDataForAdminEdit(this);

        // Run the page
        return await crewGeneralDataForAdminEdit.Run();
    }
}
