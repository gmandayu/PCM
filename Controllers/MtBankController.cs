namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtBankList/{ID?}", Name = "MtBankList-MTBank-list")]
    [Route("Home/MtBankList/{ID?}", Name = "MtBankList-MTBank-list-2")]
    public async Task<IActionResult> MtBankList()
    {
        // Create page object
        mtBankList = new GLOBALS.MtBankList(this);
        mtBankList.Cache = _cache;

        // Run the page
        return await mtBankList.Run();
    }

    // add
    [Route("MtBankAdd/{ID?}", Name = "MtBankAdd-MTBank-add")]
    [Route("Home/MtBankAdd/{ID?}", Name = "MtBankAdd-MTBank-add-2")]
    public async Task<IActionResult> MtBankAdd()
    {
        // Create page object
        mtBankAdd = new GLOBALS.MtBankAdd(this);

        // Run the page
        return await mtBankAdd.Run();
    }

    // view
    [Route("MtBankView/{ID?}", Name = "MtBankView-MTBank-view")]
    [Route("Home/MtBankView/{ID?}", Name = "MtBankView-MTBank-view-2")]
    public async Task<IActionResult> MtBankView()
    {
        // Create page object
        mtBankView = new GLOBALS.MtBankView(this);

        // Run the page
        return await mtBankView.Run();
    }

    // edit
    [Route("MtBankEdit/{ID?}", Name = "MtBankEdit-MTBank-edit")]
    [Route("Home/MtBankEdit/{ID?}", Name = "MtBankEdit-MTBank-edit-2")]
    public async Task<IActionResult> MtBankEdit()
    {
        // Create page object
        mtBankEdit = new GLOBALS.MtBankEdit(this);

        // Run the page
        return await mtBankEdit.Run();
    }

    // delete
    [Route("MtBankDelete/{ID?}", Name = "MtBankDelete-MTBank-delete")]
    [Route("Home/MtBankDelete/{ID?}", Name = "MtBankDelete-MTBank-delete-2")]
    public async Task<IActionResult> MtBankDelete()
    {
        // Create page object
        mtBankDelete = new GLOBALS.MtBankDelete(this);

        // Run the page
        return await mtBankDelete.Run();
    }

    // search
    [Route("MtBankSearch", Name = "MtBankSearch-MTBank-search")]
    [Route("Home/MtBankSearch", Name = "MtBankSearch-MTBank-search-2")]
    public async Task<IActionResult> MtBankSearch()
    {
        // Create page object
        mtBankSearch = new GLOBALS.MtBankSearch(this);

        // Run the page
        return await mtBankSearch.Run();
    }
}
