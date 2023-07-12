namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // PrintCV2 (custom)
    [Route("PrintCv2/{**key}", Name = "PrintCv2-PrintCV2-custom")]
    [Route("Home/PrintCv2/{**key}", Name = "PrintCv2-PrintCV2-custom-2")]
    public async Task<IActionResult> PrintCv2()
    {
        // Create page object
        printCv2 = new GLOBALS.PrintCv2(this);

        // Run the page
        return await printCv2.Run();
    }
}
