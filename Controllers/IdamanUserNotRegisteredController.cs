namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // IdamanUserNotRegistered (custom)
    [Route("IdamanUserNotRegistered/{**key}", Name = "IdamanUserNotRegistered-IdamanUserNotRegistered-custom")]
    [Route("Home/IdamanUserNotRegistered/{**key}", Name = "IdamanUserNotRegistered-IdamanUserNotRegistered-custom-2")]
    public async Task<IActionResult> IdamanUserNotRegistered()
    {
        // Create page object
        idamanUserNotRegistered = new GLOBALS.IdamanUserNotRegistered(this);

        // Run the page
        return await idamanUserNotRegistered.Run();
    }
}
