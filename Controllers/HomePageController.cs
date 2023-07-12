namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // HomePage (custom)
    [Route("HomePage/{**key}", Name = "HomePage-HomePage-custom")]
    [Route("Home/HomePage/{**key}", Name = "HomePage-HomePage-custom-2")]
    public async Task<IActionResult> HomePage()
    {
        // Create page object
        homePage = new GLOBALS.HomePage(this);

        // Run the page
        return await homePage.Run();
    }
}
