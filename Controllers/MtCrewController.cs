namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewList/{ID?}", Name = "MtCrewList-MTCrew-list")]
    [Route("Home/MtCrewList/{ID?}", Name = "MtCrewList-MTCrew-list-2")]
    public async Task<IActionResult> MtCrewList()
    {
        // Create page object
        mtCrewList = new GLOBALS.MtCrewList(this);
        mtCrewList.Cache = _cache;

        // Run the page
        return await mtCrewList.Run();
    }

    // add
    [Route("MtCrewAdd/{ID?}", Name = "MtCrewAdd-MTCrew-add")]
    [Route("Home/MtCrewAdd/{ID?}", Name = "MtCrewAdd-MTCrew-add-2")]
    public async Task<IActionResult> MtCrewAdd()
    {
        // Create page object
        mtCrewAdd = new GLOBALS.MtCrewAdd(this);

        // Run the page
        return await mtCrewAdd.Run();
    }

    // view
    [Route("MtCrewView/{ID?}", Name = "MtCrewView-MTCrew-view")]
    [Route("Home/MtCrewView/{ID?}", Name = "MtCrewView-MTCrew-view-2")]
    public async Task<IActionResult> MtCrewView()
    {
        // Create page object
        mtCrewView = new GLOBALS.MtCrewView(this);

        // Run the page
        return await mtCrewView.Run();
    }

    // edit
    [Route("MtCrewEdit/{ID?}", Name = "MtCrewEdit-MTCrew-edit")]
    [Route("Home/MtCrewEdit/{ID?}", Name = "MtCrewEdit-MTCrew-edit-2")]
    public async Task<IActionResult> MtCrewEdit()
    {
        // Create page object
        mtCrewEdit = new GLOBALS.MtCrewEdit(this);

        // Run the page
        return await mtCrewEdit.Run();
    }

    // delete
    [Route("MtCrewDelete/{ID?}", Name = "MtCrewDelete-MTCrew-delete")]
    [Route("Home/MtCrewDelete/{ID?}", Name = "MtCrewDelete-MTCrew-delete-2")]
    public async Task<IActionResult> MtCrewDelete()
    {
        // Create page object
        mtCrewDelete = new GLOBALS.MtCrewDelete(this);

        // Run the page
        return await mtCrewDelete.Run();
    }

    // search
    [Route("MtCrewSearch", Name = "MtCrewSearch-MTCrew-search")]
    [Route("Home/MtCrewSearch", Name = "MtCrewSearch-MTCrew-search-2")]
    public async Task<IActionResult> MtCrewSearch()
    {
        // Create page object
        mtCrewSearch = new GLOBALS.MtCrewSearch(this);

        // Run the page
        return await mtCrewSearch.Run();
    }
}
