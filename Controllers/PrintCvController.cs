namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // PrintCV (custom)
    [Route("PrintCv/{**key}", Name = "PrintCv-PrintCV-custom")]
    [Route("Home/PrintCv/{**key}", Name = "PrintCv-PrintCV-custom-2")]
    public async Task<IActionResult> PrintCv()
    {
        // Create page object
        printCv = new GLOBALS.PrintCv(this);

        // Run the page
        return await printCv.Run();
    }
}
