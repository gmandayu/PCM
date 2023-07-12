namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("McuResultList/{McuResult_ID?}", Name = "McuResultList-McuResult-list")]
    [Route("Home/McuResultList/{McuResult_ID?}", Name = "McuResultList-McuResult-list-2")]
    public async Task<IActionResult> McuResultList()
    {
        // Create page object
        mcuResultList = new GLOBALS.McuResultList(this);
        mcuResultList.Cache = _cache;

        // Run the page
        return await mcuResultList.Run();
    }

    // view
    [Route("McuResultView/{McuResult_ID?}", Name = "McuResultView-McuResult-view")]
    [Route("Home/McuResultView/{McuResult_ID?}", Name = "McuResultView-McuResult-view-2")]
    public async Task<IActionResult> McuResultView()
    {
        // Create page object
        mcuResultView = new GLOBALS.McuResultView(this);

        // Run the page
        return await mcuResultView.Run();
    }

    // edit
    [Route("McuResultEdit/{McuResult_ID?}", Name = "McuResultEdit-McuResult-edit")]
    [Route("Home/McuResultEdit/{McuResult_ID?}", Name = "McuResultEdit-McuResult-edit-2")]
    public async Task<IActionResult> McuResultEdit()
    {
        // Create page object
        mcuResultEdit = new GLOBALS.McuResultEdit(this);

        // Run the page
        return await mcuResultEdit.Run();
    }

    // search
    [Route("McuResultSearch", Name = "McuResultSearch-McuResult-search")]
    [Route("Home/McuResultSearch", Name = "McuResultSearch-McuResult-search-2")]
    public async Task<IActionResult> McuResultSearch()
    {
        // Create page object
        mcuResultSearch = new GLOBALS.McuResultSearch(this);

        // Run the page
        return await mcuResultSearch.Run();
    }
}
