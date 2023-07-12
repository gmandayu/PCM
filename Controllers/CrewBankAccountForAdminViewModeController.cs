namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewBankAccountForAdminViewModeList/{ID?}", Name = "CrewBankAccountForAdminViewModeList-CrewBankAccountForAdminViewMode-list")]
    [Route("Home/CrewBankAccountForAdminViewModeList/{ID?}", Name = "CrewBankAccountForAdminViewModeList-CrewBankAccountForAdminViewMode-list-2")]
    public async Task<IActionResult> CrewBankAccountForAdminViewModeList()
    {
        // Create page object
        crewBankAccountForAdminViewModeList = new GLOBALS.CrewBankAccountForAdminViewModeList(this);
        crewBankAccountForAdminViewModeList.Cache = _cache;

        // Run the page
        return await crewBankAccountForAdminViewModeList.Run();
    }

    // add
    [Route("CrewBankAccountForAdminViewModeAdd/{ID?}", Name = "CrewBankAccountForAdminViewModeAdd-CrewBankAccountForAdminViewMode-add")]
    [Route("Home/CrewBankAccountForAdminViewModeAdd/{ID?}", Name = "CrewBankAccountForAdminViewModeAdd-CrewBankAccountForAdminViewMode-add-2")]
    public async Task<IActionResult> CrewBankAccountForAdminViewModeAdd()
    {
        // Create page object
        crewBankAccountForAdminViewModeAdd = new GLOBALS.CrewBankAccountForAdminViewModeAdd(this);

        // Run the page
        return await crewBankAccountForAdminViewModeAdd.Run();
    }

    // view
    [Route("CrewBankAccountForAdminViewModeView/{ID?}", Name = "CrewBankAccountForAdminViewModeView-CrewBankAccountForAdminViewMode-view")]
    [Route("Home/CrewBankAccountForAdminViewModeView/{ID?}", Name = "CrewBankAccountForAdminViewModeView-CrewBankAccountForAdminViewMode-view-2")]
    public async Task<IActionResult> CrewBankAccountForAdminViewModeView()
    {
        // Create page object
        crewBankAccountForAdminViewModeView = new GLOBALS.CrewBankAccountForAdminViewModeView(this);

        // Run the page
        return await crewBankAccountForAdminViewModeView.Run();
    }

    // edit
    [Route("CrewBankAccountForAdminViewModeEdit/{ID?}", Name = "CrewBankAccountForAdminViewModeEdit-CrewBankAccountForAdminViewMode-edit")]
    [Route("Home/CrewBankAccountForAdminViewModeEdit/{ID?}", Name = "CrewBankAccountForAdminViewModeEdit-CrewBankAccountForAdminViewMode-edit-2")]
    public async Task<IActionResult> CrewBankAccountForAdminViewModeEdit()
    {
        // Create page object
        crewBankAccountForAdminViewModeEdit = new GLOBALS.CrewBankAccountForAdminViewModeEdit(this);

        // Run the page
        return await crewBankAccountForAdminViewModeEdit.Run();
    }

    // delete
    [Route("CrewBankAccountForAdminViewModeDelete/{ID?}", Name = "CrewBankAccountForAdminViewModeDelete-CrewBankAccountForAdminViewMode-delete")]
    [Route("Home/CrewBankAccountForAdminViewModeDelete/{ID?}", Name = "CrewBankAccountForAdminViewModeDelete-CrewBankAccountForAdminViewMode-delete-2")]
    public async Task<IActionResult> CrewBankAccountForAdminViewModeDelete()
    {
        // Create page object
        crewBankAccountForAdminViewModeDelete = new GLOBALS.CrewBankAccountForAdminViewModeDelete(this);

        // Run the page
        return await crewBankAccountForAdminViewModeDelete.Run();
    }

    // search
    [Route("CrewBankAccountForAdminViewModeSearch", Name = "CrewBankAccountForAdminViewModeSearch-CrewBankAccountForAdminViewMode-search")]
    [Route("Home/CrewBankAccountForAdminViewModeSearch", Name = "CrewBankAccountForAdminViewModeSearch-CrewBankAccountForAdminViewMode-search-2")]
    public async Task<IActionResult> CrewBankAccountForAdminViewModeSearch()
    {
        // Create page object
        crewBankAccountForAdminViewModeSearch = new GLOBALS.CrewBankAccountForAdminViewModeSearch(this);

        // Run the page
        return await crewBankAccountForAdminViewModeSearch.Run();
    }
}
