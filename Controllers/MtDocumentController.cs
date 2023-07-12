namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtDocumentList/{ID?}", Name = "MtDocumentList-MTDocument-list")]
    [Route("Home/MtDocumentList/{ID?}", Name = "MtDocumentList-MTDocument-list-2")]
    public async Task<IActionResult> MtDocumentList()
    {
        // Create page object
        mtDocumentList = new GLOBALS.MtDocumentList(this);
        mtDocumentList.Cache = _cache;

        // Run the page
        return await mtDocumentList.Run();
    }

    // add
    [Route("MtDocumentAdd/{ID?}", Name = "MtDocumentAdd-MTDocument-add")]
    [Route("Home/MtDocumentAdd/{ID?}", Name = "MtDocumentAdd-MTDocument-add-2")]
    public async Task<IActionResult> MtDocumentAdd()
    {
        // Create page object
        mtDocumentAdd = new GLOBALS.MtDocumentAdd(this);

        // Run the page
        return await mtDocumentAdd.Run();
    }

    // view
    [Route("MtDocumentView/{ID?}", Name = "MtDocumentView-MTDocument-view")]
    [Route("Home/MtDocumentView/{ID?}", Name = "MtDocumentView-MTDocument-view-2")]
    public async Task<IActionResult> MtDocumentView()
    {
        // Create page object
        mtDocumentView = new GLOBALS.MtDocumentView(this);

        // Run the page
        return await mtDocumentView.Run();
    }

    // edit
    [Route("MtDocumentEdit/{ID?}", Name = "MtDocumentEdit-MTDocument-edit")]
    [Route("Home/MtDocumentEdit/{ID?}", Name = "MtDocumentEdit-MTDocument-edit-2")]
    public async Task<IActionResult> MtDocumentEdit()
    {
        // Create page object
        mtDocumentEdit = new GLOBALS.MtDocumentEdit(this);

        // Run the page
        return await mtDocumentEdit.Run();
    }

    // delete
    [Route("MtDocumentDelete/{ID?}", Name = "MtDocumentDelete-MTDocument-delete")]
    [Route("Home/MtDocumentDelete/{ID?}", Name = "MtDocumentDelete-MTDocument-delete-2")]
    public async Task<IActionResult> MtDocumentDelete()
    {
        // Create page object
        mtDocumentDelete = new GLOBALS.MtDocumentDelete(this);

        // Run the page
        return await mtDocumentDelete.Run();
    }

    // search
    [Route("MtDocumentSearch", Name = "MtDocumentSearch-MTDocument-search")]
    [Route("Home/MtDocumentSearch", Name = "MtDocumentSearch-MTDocument-search-2")]
    public async Task<IActionResult> MtDocumentSearch()
    {
        // Create page object
        mtDocumentSearch = new GLOBALS.MtDocumentSearch(this);

        // Run the page
        return await mtDocumentSearch.Run();
    }
}
