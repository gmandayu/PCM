namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // PrintChecklist (custom)
    [Route("PrintChecklist/{**key}", Name = "PrintChecklist-PrintChecklist-custom")]
    [Route("Home/PrintChecklist/{**key}", Name = "PrintChecklist-PrintChecklist-custom-2")]
    public async Task<IActionResult> PrintChecklist()
    {
        // Create page object
        printChecklist = new GLOBALS.PrintChecklist(this);

        // Run the page
        return await printChecklist.Run();
    }
}
