namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // PageNotFound (custom)
    [Route("PageNotFound/{**key}", Name = "PageNotFound-PageNotFound-custom")]
    [Route("Home/PageNotFound/{**key}", Name = "PageNotFound-PageNotFound-custom-2")]
    public async Task<IActionResult> PageNotFound()
    {
        // Create page object
        pageNotFound = new GLOBALS.PageNotFound(this);

        // Run the page
        return await pageNotFound.Run();
    }
}
