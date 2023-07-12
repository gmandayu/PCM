namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("RegistrationList/{ID?}", Name = "RegistrationList-Registration-list")]
    [Route("Home/RegistrationList/{ID?}", Name = "RegistrationList-Registration-list-2")]
    public async Task<IActionResult> RegistrationList()
    {
        // Create page object
        registrationList = new GLOBALS.RegistrationList(this);
        registrationList.Cache = _cache;

        // Run the page
        return await registrationList.Run();
    }

    // view
    [Route("RegistrationView/{ID?}", Name = "RegistrationView-Registration-view")]
    [Route("Home/RegistrationView/{ID?}", Name = "RegistrationView-Registration-view-2")]
    public async Task<IActionResult> RegistrationView()
    {
        // Create page object
        registrationView = new GLOBALS.RegistrationView(this);

        // Run the page
        return await registrationView.Run();
    }

    // edit
    [Route("RegistrationEdit/{ID?}", Name = "RegistrationEdit-Registration-edit")]
    [Route("Home/RegistrationEdit/{ID?}", Name = "RegistrationEdit-Registration-edit-2")]
    public async Task<IActionResult> RegistrationEdit()
    {
        // Create page object
        registrationEdit = new GLOBALS.RegistrationEdit(this);

        // Run the page
        return await registrationEdit.Run();
    }

    // delete
    [Route("RegistrationDelete/{ID?}", Name = "RegistrationDelete-Registration-delete")]
    [Route("Home/RegistrationDelete/{ID?}", Name = "RegistrationDelete-Registration-delete-2")]
    public async Task<IActionResult> RegistrationDelete()
    {
        // Create page object
        registrationDelete = new GLOBALS.RegistrationDelete(this);

        // Run the page
        return await registrationDelete.Run();
    }

    // search
    [Route("RegistrationSearch", Name = "RegistrationSearch-Registration-search")]
    [Route("Home/RegistrationSearch", Name = "RegistrationSearch-Registration-search-2")]
    public async Task<IActionResult> RegistrationSearch()
    {
        // Create page object
        registrationSearch = new GLOBALS.RegistrationSearch(this);

        // Run the page
        return await registrationSearch.Run();
    }
}
