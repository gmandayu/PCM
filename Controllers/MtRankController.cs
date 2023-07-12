namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtRankList/{ID?}", Name = "MtRankList-MTRank-list")]
    [Route("Home/MtRankList/{ID?}", Name = "MtRankList-MTRank-list-2")]
    public async Task<IActionResult> MtRankList()
    {
        // Create page object
        mtRankList = new GLOBALS.MtRankList(this);
        mtRankList.Cache = _cache;

        // Run the page
        return await mtRankList.Run();
    }

    // add
    [Route("MtRankAdd/{ID?}", Name = "MtRankAdd-MTRank-add")]
    [Route("Home/MtRankAdd/{ID?}", Name = "MtRankAdd-MTRank-add-2")]
    public async Task<IActionResult> MtRankAdd()
    {
        // Create page object
        mtRankAdd = new GLOBALS.MtRankAdd(this);

        // Run the page
        return await mtRankAdd.Run();
    }

    // view
    [Route("MtRankView/{ID?}", Name = "MtRankView-MTRank-view")]
    [Route("Home/MtRankView/{ID?}", Name = "MtRankView-MTRank-view-2")]
    public async Task<IActionResult> MtRankView()
    {
        // Create page object
        mtRankView = new GLOBALS.MtRankView(this);

        // Run the page
        return await mtRankView.Run();
    }

    // edit
    [Route("MtRankEdit/{ID?}", Name = "MtRankEdit-MTRank-edit")]
    [Route("Home/MtRankEdit/{ID?}", Name = "MtRankEdit-MTRank-edit-2")]
    public async Task<IActionResult> MtRankEdit()
    {
        // Create page object
        mtRankEdit = new GLOBALS.MtRankEdit(this);

        // Run the page
        return await mtRankEdit.Run();
    }

    // delete
    [Route("MtRankDelete/{ID?}", Name = "MtRankDelete-MTRank-delete")]
    [Route("Home/MtRankDelete/{ID?}", Name = "MtRankDelete-MTRank-delete-2")]
    public async Task<IActionResult> MtRankDelete()
    {
        // Create page object
        mtRankDelete = new GLOBALS.MtRankDelete(this);

        // Run the page
        return await mtRankDelete.Run();
    }

    // search
    [Route("MtRankSearch", Name = "MtRankSearch-MTRank-search")]
    [Route("Home/MtRankSearch", Name = "MtRankSearch-MTRank-search-2")]
    public async Task<IActionResult> MtRankSearch()
    {
        // Create page object
        mtRankSearch = new GLOBALS.MtRankSearch(this);

        // Run the page
        return await mtRankSearch.Run();
    }
}
