namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCountryList/{ID?}", Name = "MtCountryList-MTCountry-list")]
    [Route("Home/MtCountryList/{ID?}", Name = "MtCountryList-MTCountry-list-2")]
    public async Task<IActionResult> MtCountryList()
    {
        // Create page object
        mtCountryList = new GLOBALS.MtCountryList(this);
        mtCountryList.Cache = _cache;

        // Run the page
        return await mtCountryList.Run();
    }

    // add
    [Route("MtCountryAdd/{ID?}", Name = "MtCountryAdd-MTCountry-add")]
    [Route("Home/MtCountryAdd/{ID?}", Name = "MtCountryAdd-MTCountry-add-2")]
    public async Task<IActionResult> MtCountryAdd()
    {
        // Create page object
        mtCountryAdd = new GLOBALS.MtCountryAdd(this);

        // Run the page
        return await mtCountryAdd.Run();
    }

    // view
    [Route("MtCountryView/{ID?}", Name = "MtCountryView-MTCountry-view")]
    [Route("Home/MtCountryView/{ID?}", Name = "MtCountryView-MTCountry-view-2")]
    public async Task<IActionResult> MtCountryView()
    {
        // Create page object
        mtCountryView = new GLOBALS.MtCountryView(this);

        // Run the page
        return await mtCountryView.Run();
    }

    // edit
    [Route("MtCountryEdit/{ID?}", Name = "MtCountryEdit-MTCountry-edit")]
    [Route("Home/MtCountryEdit/{ID?}", Name = "MtCountryEdit-MTCountry-edit-2")]
    public async Task<IActionResult> MtCountryEdit()
    {
        // Create page object
        mtCountryEdit = new GLOBALS.MtCountryEdit(this);

        // Run the page
        return await mtCountryEdit.Run();
    }

    // delete
    [Route("MtCountryDelete/{ID?}", Name = "MtCountryDelete-MTCountry-delete")]
    [Route("Home/MtCountryDelete/{ID?}", Name = "MtCountryDelete-MTCountry-delete-2")]
    public async Task<IActionResult> MtCountryDelete()
    {
        // Create page object
        mtCountryDelete = new GLOBALS.MtCountryDelete(this);

        // Run the page
        return await mtCountryDelete.Run();
    }

    // search
    [Route("MtCountrySearch", Name = "MtCountrySearch-MTCountry-search")]
    [Route("Home/MtCountrySearch", Name = "MtCountrySearch-MTCountry-search-2")]
    public async Task<IActionResult> MtCountrySearch()
    {
        // Create page object
        mtCountrySearch = new GLOBALS.MtCountrySearch(this);

        // Run the page
        return await mtCountrySearch.Run();
    }
}
