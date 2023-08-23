namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtManningAgentList/{ID?}", Name = "MtManningAgentList-MTManningAgent-list")]
    [Route("Home/MtManningAgentList/{ID?}", Name = "MtManningAgentList-MTManningAgent-list-2")]
    public async Task<IActionResult> MtManningAgentList()
    {
        // Create page object
        mtManningAgentList = new GLOBALS.MtManningAgentList(this);
        mtManningAgentList.Cache = _cache;

        // Run the page
        return await mtManningAgentList.Run();
    }

    // add
    [Route("MtManningAgentAdd/{ID?}", Name = "MtManningAgentAdd-MTManningAgent-add")]
    [Route("Home/MtManningAgentAdd/{ID?}", Name = "MtManningAgentAdd-MTManningAgent-add-2")]
    public async Task<IActionResult> MtManningAgentAdd()
    {
        // Create page object
        mtManningAgentAdd = new GLOBALS.MtManningAgentAdd(this);

        // Run the page
        return await mtManningAgentAdd.Run();
    }

    // view
    [Route("MtManningAgentView/{ID?}", Name = "MtManningAgentView-MTManningAgent-view")]
    [Route("Home/MtManningAgentView/{ID?}", Name = "MtManningAgentView-MTManningAgent-view-2")]
    public async Task<IActionResult> MtManningAgentView()
    {
        // Create page object
        mtManningAgentView = new GLOBALS.MtManningAgentView(this);

        // Run the page
        return await mtManningAgentView.Run();
    }

    // edit
    [Route("MtManningAgentEdit/{ID?}", Name = "MtManningAgentEdit-MTManningAgent-edit")]
    [Route("Home/MtManningAgentEdit/{ID?}", Name = "MtManningAgentEdit-MTManningAgent-edit-2")]
    public async Task<IActionResult> MtManningAgentEdit()
    {
        // Create page object
        mtManningAgentEdit = new GLOBALS.MtManningAgentEdit(this);

        // Run the page
        return await mtManningAgentEdit.Run();
    }

    // delete
    [Route("MtManningAgentDelete/{ID?}", Name = "MtManningAgentDelete-MTManningAgent-delete")]
    [Route("Home/MtManningAgentDelete/{ID?}", Name = "MtManningAgentDelete-MTManningAgent-delete-2")]
    public async Task<IActionResult> MtManningAgentDelete()
    {
        // Create page object
        mtManningAgentDelete = new GLOBALS.MtManningAgentDelete(this);

        // Run the page
        return await mtManningAgentDelete.Run();
    }

    // search
    [Route("MtManningAgentSearch", Name = "MtManningAgentSearch-MTManningAgent-search")]
    [Route("Home/MtManningAgentSearch", Name = "MtManningAgentSearch-MTManningAgent-search-2")]
    public async Task<IActionResult> MtManningAgentSearch()
    {
        // Create page object
        mtManningAgentSearch = new GLOBALS.MtManningAgentSearch(this);

        // Run the page
        return await mtManningAgentSearch.Run();
    }
}
