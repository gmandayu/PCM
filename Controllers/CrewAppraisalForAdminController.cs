namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("CrewAppraisalForAdminList/{ID?}", Name = "CrewAppraisalForAdminList-CrewAppraisalForAdmin-list")]
    [Route("Home/CrewAppraisalForAdminList/{ID?}", Name = "CrewAppraisalForAdminList-CrewAppraisalForAdmin-list-2")]
    public async Task<IActionResult> CrewAppraisalForAdminList()
    {
        // Create page object
        crewAppraisalForAdminList = new GLOBALS.CrewAppraisalForAdminList(this);
        crewAppraisalForAdminList.Cache = _cache;

        // Run the page
        return await crewAppraisalForAdminList.Run();
    }

    // add
    [Route("CrewAppraisalForAdminAdd/{ID?}", Name = "CrewAppraisalForAdminAdd-CrewAppraisalForAdmin-add")]
    [Route("Home/CrewAppraisalForAdminAdd/{ID?}", Name = "CrewAppraisalForAdminAdd-CrewAppraisalForAdmin-add-2")]
    public async Task<IActionResult> CrewAppraisalForAdminAdd()
    {
        // Create page object
        crewAppraisalForAdminAdd = new GLOBALS.CrewAppraisalForAdminAdd(this);

        // Run the page
        return await crewAppraisalForAdminAdd.Run();
    }

    // view
    [Route("CrewAppraisalForAdminView/{ID?}", Name = "CrewAppraisalForAdminView-CrewAppraisalForAdmin-view")]
    [Route("Home/CrewAppraisalForAdminView/{ID?}", Name = "CrewAppraisalForAdminView-CrewAppraisalForAdmin-view-2")]
    public async Task<IActionResult> CrewAppraisalForAdminView()
    {
        // Create page object
        crewAppraisalForAdminView = new GLOBALS.CrewAppraisalForAdminView(this);

        // Run the page
        return await crewAppraisalForAdminView.Run();
    }

    // edit
    [Route("CrewAppraisalForAdminEdit/{ID?}", Name = "CrewAppraisalForAdminEdit-CrewAppraisalForAdmin-edit")]
    [Route("Home/CrewAppraisalForAdminEdit/{ID?}", Name = "CrewAppraisalForAdminEdit-CrewAppraisalForAdmin-edit-2")]
    public async Task<IActionResult> CrewAppraisalForAdminEdit()
    {
        // Create page object
        crewAppraisalForAdminEdit = new GLOBALS.CrewAppraisalForAdminEdit(this);

        // Run the page
        return await crewAppraisalForAdminEdit.Run();
    }

    // delete
    [Route("CrewAppraisalForAdminDelete/{ID?}", Name = "CrewAppraisalForAdminDelete-CrewAppraisalForAdmin-delete")]
    [Route("Home/CrewAppraisalForAdminDelete/{ID?}", Name = "CrewAppraisalForAdminDelete-CrewAppraisalForAdmin-delete-2")]
    public async Task<IActionResult> CrewAppraisalForAdminDelete()
    {
        // Create page object
        crewAppraisalForAdminDelete = new GLOBALS.CrewAppraisalForAdminDelete(this);

        // Run the page
        return await crewAppraisalForAdminDelete.Run();
    }

    // search
    [Route("CrewAppraisalForAdminSearch", Name = "CrewAppraisalForAdminSearch-CrewAppraisalForAdmin-search")]
    [Route("Home/CrewAppraisalForAdminSearch", Name = "CrewAppraisalForAdminSearch-CrewAppraisalForAdmin-search-2")]
    public async Task<IActionResult> CrewAppraisalForAdminSearch()
    {
        // Create page object
        crewAppraisalForAdminSearch = new GLOBALS.CrewAppraisalForAdminSearch(this);

        // Run the page
        return await crewAppraisalForAdminSearch.Run();
    }
}
