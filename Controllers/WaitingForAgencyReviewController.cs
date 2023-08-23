namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("WaitingForAgencyReviewList/{ID?}", Name = "WaitingForAgencyReviewList-WaitingForAgencyReview-list")]
    [Route("Home/WaitingForAgencyReviewList/{ID?}", Name = "WaitingForAgencyReviewList-WaitingForAgencyReview-list-2")]
    public async Task<IActionResult> WaitingForAgencyReviewList()
    {
        // Create page object
        waitingForAgencyReviewList = new GLOBALS.WaitingForAgencyReviewList(this);
        waitingForAgencyReviewList.Cache = _cache;

        // Run the page
        return await waitingForAgencyReviewList.Run();
    }

    // view
    [Route("WaitingForAgencyReviewView/{ID?}", Name = "WaitingForAgencyReviewView-WaitingForAgencyReview-view")]
    [Route("Home/WaitingForAgencyReviewView/{ID?}", Name = "WaitingForAgencyReviewView-WaitingForAgencyReview-view-2")]
    public async Task<IActionResult> WaitingForAgencyReviewView()
    {
        // Create page object
        waitingForAgencyReviewView = new GLOBALS.WaitingForAgencyReviewView(this);

        // Run the page
        return await waitingForAgencyReviewView.Run();
    }

    // search
    [Route("WaitingForAgencyReviewSearch", Name = "WaitingForAgencyReviewSearch-WaitingForAgencyReview-search")]
    [Route("Home/WaitingForAgencyReviewSearch", Name = "WaitingForAgencyReviewSearch-WaitingForAgencyReview-search-2")]
    public async Task<IActionResult> WaitingForAgencyReviewSearch()
    {
        // Create page object
        waitingForAgencyReviewSearch = new GLOBALS.WaitingForAgencyReviewSearch(this);

        // Run the page
        return await waitingForAgencyReviewSearch.Run();
    }
}
