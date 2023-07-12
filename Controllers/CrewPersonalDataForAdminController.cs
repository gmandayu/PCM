namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewPersonalDataForAdminList/{ID?}", Name = "CrewPersonalDataForAdminList-CrewPersonalDataForAdmin-list")]
    [Route("Home/CrewPersonalDataForAdminList/{ID?}", Name = "CrewPersonalDataForAdminList-CrewPersonalDataForAdmin-list-2")]
    public async Task<IActionResult> CrewPersonalDataForAdminList()
    {
        // Create page object
        crewPersonalDataForAdminList = new GLOBALS.CrewPersonalDataForAdminList(this);
        crewPersonalDataForAdminList.Cache = _cache;

        // Run the page
        return await crewPersonalDataForAdminList.Run();
    }

    // edit
    [Route("CrewPersonalDataForAdminEdit/{ID?}", Name = "CrewPersonalDataForAdminEdit-CrewPersonalDataForAdmin-edit")]
    [Route("Home/CrewPersonalDataForAdminEdit/{ID?}", Name = "CrewPersonalDataForAdminEdit-CrewPersonalDataForAdmin-edit-2")]
    public async Task<IActionResult> CrewPersonalDataForAdminEdit()
    {
        // Create page object
        crewPersonalDataForAdminEdit = new GLOBALS.CrewPersonalDataForAdminEdit(this);

        // Run the page
        return await crewPersonalDataForAdminEdit.Run();
    }

    // delete
    [Route("CrewPersonalDataForAdminDelete/{ID?}", Name = "CrewPersonalDataForAdminDelete-CrewPersonalDataForAdmin-delete")]
    [Route("Home/CrewPersonalDataForAdminDelete/{ID?}", Name = "CrewPersonalDataForAdminDelete-CrewPersonalDataForAdmin-delete-2")]
    public async Task<IActionResult> CrewPersonalDataForAdminDelete()
    {
        // Create page object
        crewPersonalDataForAdminDelete = new GLOBALS.CrewPersonalDataForAdminDelete(this);

        // Run the page
        return await crewPersonalDataForAdminDelete.Run();
    }

    // search
    [Route("CrewPersonalDataForAdminSearch", Name = "CrewPersonalDataForAdminSearch-CrewPersonalDataForAdmin-search")]
    [Route("Home/CrewPersonalDataForAdminSearch", Name = "CrewPersonalDataForAdminSearch-CrewPersonalDataForAdmin-search-2")]
    public async Task<IActionResult> CrewPersonalDataForAdminSearch()
    {
        // Create page object
        crewPersonalDataForAdminSearch = new GLOBALS.CrewPersonalDataForAdminSearch(this);

        // Run the page
        return await crewPersonalDataForAdminSearch.Run();
    }
}
