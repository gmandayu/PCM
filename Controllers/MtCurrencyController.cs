namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCurrencyList/{ID?}", Name = "MtCurrencyList-MTCurrency-list")]
    [Route("Home/MtCurrencyList/{ID?}", Name = "MtCurrencyList-MTCurrency-list-2")]
    public async Task<IActionResult> MtCurrencyList()
    {
        // Create page object
        mtCurrencyList = new GLOBALS.MtCurrencyList(this);
        mtCurrencyList.Cache = _cache;

        // Run the page
        return await mtCurrencyList.Run();
    }

    // add
    [Route("MtCurrencyAdd/{ID?}", Name = "MtCurrencyAdd-MTCurrency-add")]
    [Route("Home/MtCurrencyAdd/{ID?}", Name = "MtCurrencyAdd-MTCurrency-add-2")]
    public async Task<IActionResult> MtCurrencyAdd()
    {
        // Create page object
        mtCurrencyAdd = new GLOBALS.MtCurrencyAdd(this);

        // Run the page
        return await mtCurrencyAdd.Run();
    }

    // view
    [Route("MtCurrencyView/{ID?}", Name = "MtCurrencyView-MTCurrency-view")]
    [Route("Home/MtCurrencyView/{ID?}", Name = "MtCurrencyView-MTCurrency-view-2")]
    public async Task<IActionResult> MtCurrencyView()
    {
        // Create page object
        mtCurrencyView = new GLOBALS.MtCurrencyView(this);

        // Run the page
        return await mtCurrencyView.Run();
    }

    // edit
    [Route("MtCurrencyEdit/{ID?}", Name = "MtCurrencyEdit-MTCurrency-edit")]
    [Route("Home/MtCurrencyEdit/{ID?}", Name = "MtCurrencyEdit-MTCurrency-edit-2")]
    public async Task<IActionResult> MtCurrencyEdit()
    {
        // Create page object
        mtCurrencyEdit = new GLOBALS.MtCurrencyEdit(this);

        // Run the page
        return await mtCurrencyEdit.Run();
    }

    // delete
    [Route("MtCurrencyDelete/{ID?}", Name = "MtCurrencyDelete-MTCurrency-delete")]
    [Route("Home/MtCurrencyDelete/{ID?}", Name = "MtCurrencyDelete-MTCurrency-delete-2")]
    public async Task<IActionResult> MtCurrencyDelete()
    {
        // Create page object
        mtCurrencyDelete = new GLOBALS.MtCurrencyDelete(this);

        // Run the page
        return await mtCurrencyDelete.Run();
    }

    // search
    [Route("MtCurrencySearch", Name = "MtCurrencySearch-MTCurrency-search")]
    [Route("Home/MtCurrencySearch", Name = "MtCurrencySearch-MTCurrency-search-2")]
    public async Task<IActionResult> MtCurrencySearch()
    {
        // Create page object
        mtCurrencySearch = new GLOBALS.MtCurrencySearch(this);

        // Run the page
        return await mtCurrencySearch.Run();
    }
}
