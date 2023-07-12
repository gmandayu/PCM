namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtUserList/{ID?}", Name = "MtUserList-MTUser-list")]
    [Route("Home/MtUserList/{ID?}", Name = "MtUserList-MTUser-list-2")]
    public async Task<IActionResult> MtUserList()
    {
        // Create page object
        mtUserList = new GLOBALS.MtUserList(this);
        mtUserList.Cache = _cache;

        // Run the page
        return await mtUserList.Run();
    }

    // add
    [Route("MtUserAdd/{ID?}", Name = "MtUserAdd-MTUser-add")]
    [Route("Home/MtUserAdd/{ID?}", Name = "MtUserAdd-MTUser-add-2")]
    public async Task<IActionResult> MtUserAdd()
    {
        // Create page object
        mtUserAdd = new GLOBALS.MtUserAdd(this);

        // Run the page
        return await mtUserAdd.Run();
    }

    // view
    [Route("MtUserView/{ID?}", Name = "MtUserView-MTUser-view")]
    [Route("Home/MtUserView/{ID?}", Name = "MtUserView-MTUser-view-2")]
    public async Task<IActionResult> MtUserView()
    {
        // Create page object
        mtUserView = new GLOBALS.MtUserView(this);

        // Run the page
        return await mtUserView.Run();
    }

    // edit
    [Route("MtUserEdit/{ID?}", Name = "MtUserEdit-MTUser-edit")]
    [Route("Home/MtUserEdit/{ID?}", Name = "MtUserEdit-MTUser-edit-2")]
    public async Task<IActionResult> MtUserEdit()
    {
        // Create page object
        mtUserEdit = new GLOBALS.MtUserEdit(this);

        // Run the page
        return await mtUserEdit.Run();
    }

    // delete
    [Route("MtUserDelete/{ID?}", Name = "MtUserDelete-MTUser-delete")]
    [Route("Home/MtUserDelete/{ID?}", Name = "MtUserDelete-MTUser-delete-2")]
    public async Task<IActionResult> MtUserDelete()
    {
        // Create page object
        mtUserDelete = new GLOBALS.MtUserDelete(this);

        // Run the page
        return await mtUserDelete.Run();
    }

    // search
    [Route("MtUserSearch", Name = "MtUserSearch-MTUser-search")]
    [Route("Home/MtUserSearch", Name = "MtUserSearch-MTUser-search-2")]
    public async Task<IActionResult> MtUserSearch()
    {
        // Create page object
        mtUserSearch = new GLOBALS.MtUserSearch(this);

        // Run the page
        return await mtUserSearch.Run();
    }
}
