namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewBankAccountForAdminList/{ID?}", Name = "CrewBankAccountForAdminList-CrewBankAccountForAdmin-list")]
    [Route("Home/CrewBankAccountForAdminList/{ID?}", Name = "CrewBankAccountForAdminList-CrewBankAccountForAdmin-list-2")]
    public async Task<IActionResult> CrewBankAccountForAdminList()
    {
        // Create page object
        crewBankAccountForAdminList = new GLOBALS.CrewBankAccountForAdminList(this);
        crewBankAccountForAdminList.Cache = _cache;

        // Run the page
        return await crewBankAccountForAdminList.Run();
    }

    // add
    [Route("CrewBankAccountForAdminAdd/{ID?}", Name = "CrewBankAccountForAdminAdd-CrewBankAccountForAdmin-add")]
    [Route("Home/CrewBankAccountForAdminAdd/{ID?}", Name = "CrewBankAccountForAdminAdd-CrewBankAccountForAdmin-add-2")]
    public async Task<IActionResult> CrewBankAccountForAdminAdd()
    {
        // Create page object
        crewBankAccountForAdminAdd = new GLOBALS.CrewBankAccountForAdminAdd(this);

        // Run the page
        return await crewBankAccountForAdminAdd.Run();
    }

    // edit
    [Route("CrewBankAccountForAdminEdit/{ID?}", Name = "CrewBankAccountForAdminEdit-CrewBankAccountForAdmin-edit")]
    [Route("Home/CrewBankAccountForAdminEdit/{ID?}", Name = "CrewBankAccountForAdminEdit-CrewBankAccountForAdmin-edit-2")]
    public async Task<IActionResult> CrewBankAccountForAdminEdit()
    {
        // Create page object
        crewBankAccountForAdminEdit = new GLOBALS.CrewBankAccountForAdminEdit(this);

        // Run the page
        return await crewBankAccountForAdminEdit.Run();
    }

    // delete
    [Route("CrewBankAccountForAdminDelete/{ID?}", Name = "CrewBankAccountForAdminDelete-CrewBankAccountForAdmin-delete")]
    [Route("Home/CrewBankAccountForAdminDelete/{ID?}", Name = "CrewBankAccountForAdminDelete-CrewBankAccountForAdmin-delete-2")]
    public async Task<IActionResult> CrewBankAccountForAdminDelete()
    {
        // Create page object
        crewBankAccountForAdminDelete = new GLOBALS.CrewBankAccountForAdminDelete(this);

        // Run the page
        return await crewBankAccountForAdminDelete.Run();
    }

    // search
    [Route("CrewBankAccountForAdminSearch", Name = "CrewBankAccountForAdminSearch-CrewBankAccountForAdmin-search")]
    [Route("Home/CrewBankAccountForAdminSearch", Name = "CrewBankAccountForAdminSearch-CrewBankAccountForAdmin-search-2")]
    public async Task<IActionResult> CrewBankAccountForAdminSearch()
    {
        // Create page object
        crewBankAccountForAdminSearch = new GLOBALS.CrewBankAccountForAdminSearch(this);

        // Run the page
        return await crewBankAccountForAdminSearch.Run();
    }
}
