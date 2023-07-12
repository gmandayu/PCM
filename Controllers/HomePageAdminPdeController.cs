namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // HomePageAdminPDE (custom)
    [Route("HomePageAdminPde/{**key}", Name = "HomePageAdminPde-HomePageAdminPDE-custom")]
    [Route("Home/HomePageAdminPde/{**key}", Name = "HomePageAdminPde-HomePageAdminPDE-custom-2")]
    public async Task<IActionResult> HomePageAdminPde()
    {
        // Create page object
        homePageAdminPde = new GLOBALS.HomePageAdminPde(this);

        // Run the page
        return await homePageAdminPde.Run();
    }
}
