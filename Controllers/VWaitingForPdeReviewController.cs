namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("VWaitingForPdeReviewList/{ID?}", Name = "VWaitingForPdeReviewList-v_WaitingForPDEReview-list")]
    [Route("Home/VWaitingForPdeReviewList/{ID?}", Name = "VWaitingForPdeReviewList-v_WaitingForPDEReview-list-2")]
    public async Task<IActionResult> VWaitingForPdeReviewList()
    {
        // Create page object
        vWaitingForPdeReviewList = new GLOBALS.VWaitingForPdeReviewList(this);
        vWaitingForPdeReviewList.Cache = _cache;

        // Run the page
        return await vWaitingForPdeReviewList.Run();
    }

    // view
    [Route("VWaitingForPdeReviewView/{ID?}", Name = "VWaitingForPdeReviewView-v_WaitingForPDEReview-view")]
    [Route("Home/VWaitingForPdeReviewView/{ID?}", Name = "VWaitingForPdeReviewView-v_WaitingForPDEReview-view-2")]
    public async Task<IActionResult> VWaitingForPdeReviewView()
    {
        // Create page object
        vWaitingForPdeReviewView = new GLOBALS.VWaitingForPdeReviewView(this);

        // Run the page
        return await vWaitingForPdeReviewView.Run();
    }

    // search
    [Route("VWaitingForPdeReviewSearch", Name = "VWaitingForPdeReviewSearch-v_WaitingForPDEReview-search")]
    [Route("Home/VWaitingForPdeReviewSearch", Name = "VWaitingForPdeReviewSearch-v_WaitingForPDEReview-search-2")]
    public async Task<IActionResult> VWaitingForPdeReviewSearch()
    {
        // Create page object
        vWaitingForPdeReviewSearch = new GLOBALS.VWaitingForPdeReviewSearch(this);

        // Run the page
        return await vWaitingForPdeReviewSearch.Run();
    }
}
