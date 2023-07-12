namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewBankAccountList/{ID?}", Name = "MtCrewBankAccountList-MTCrewBankAccount-list")]
    [Route("Home/MtCrewBankAccountList/{ID?}", Name = "MtCrewBankAccountList-MTCrewBankAccount-list-2")]
    public async Task<IActionResult> MtCrewBankAccountList()
    {
        // Create page object
        mtCrewBankAccountList = new GLOBALS.MtCrewBankAccountList(this);
        mtCrewBankAccountList.Cache = _cache;

        // Run the page
        return await mtCrewBankAccountList.Run();
    }

    // search
    [Route("MtCrewBankAccountSearch", Name = "MtCrewBankAccountSearch-MTCrewBankAccount-search")]
    [Route("Home/MtCrewBankAccountSearch", Name = "MtCrewBankAccountSearch-MTCrewBankAccount-search-2")]
    public async Task<IActionResult> MtCrewBankAccountSearch()
    {
        // Create page object
        mtCrewBankAccountSearch = new GLOBALS.MtCrewBankAccountSearch(this);

        // Run the page
        return await mtCrewBankAccountSearch.Run();
    }
}
