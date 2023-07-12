namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("ChecklistList/{ID?}", Name = "ChecklistList-Checklist-list")]
    [Route("Home/ChecklistList/{ID?}", Name = "ChecklistList-Checklist-list-2")]
    public async Task<IActionResult> ChecklistList()
    {
        // Create page object
        checklistList = new GLOBALS.ChecklistList(this);
        checklistList.Cache = _cache;

        // Run the page
        return await checklistList.Run();
    }

    // view
    [Route("ChecklistView/{ID?}", Name = "ChecklistView-Checklist-view")]
    [Route("Home/ChecklistView/{ID?}", Name = "ChecklistView-Checklist-view-2")]
    public async Task<IActionResult> ChecklistView()
    {
        // Create page object
        checklistView = new GLOBALS.ChecklistView(this);

        // Run the page
        return await checklistView.Run();
    }

    // edit
    [Route("ChecklistEdit/{ID?}", Name = "ChecklistEdit-Checklist-edit")]
    [Route("Home/ChecklistEdit/{ID?}", Name = "ChecklistEdit-Checklist-edit-2")]
    public async Task<IActionResult> ChecklistEdit()
    {
        // Create page object
        checklistEdit = new GLOBALS.ChecklistEdit(this);

        // Run the page
        return await checklistEdit.Run();
    }

    // search
    [Route("ChecklistSearch", Name = "ChecklistSearch-Checklist-search")]
    [Route("Home/ChecklistSearch", Name = "ChecklistSearch-Checklist-search-2")]
    public async Task<IActionResult> ChecklistSearch()
    {
        // Create page object
        checklistSearch = new GLOBALS.ChecklistSearch(this);

        // Run the page
        return await checklistSearch.Run();
    }
}
