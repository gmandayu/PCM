namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtUserLevelList/{UserLevelID?}", Name = "MtUserLevelList-MTUserLevel-list")]
    [Route("Home/MtUserLevelList/{UserLevelID?}", Name = "MtUserLevelList-MTUserLevel-list-2")]
    public async Task<IActionResult> MtUserLevelList()
    {
        // Create page object
        mtUserLevelList = new GLOBALS.MtUserLevelList(this);
        mtUserLevelList.Cache = _cache;

        // Run the page
        return await mtUserLevelList.Run();
    }

    // add
    [Route("MtUserLevelAdd/{UserLevelID?}", Name = "MtUserLevelAdd-MTUserLevel-add")]
    [Route("Home/MtUserLevelAdd/{UserLevelID?}", Name = "MtUserLevelAdd-MTUserLevel-add-2")]
    public async Task<IActionResult> MtUserLevelAdd()
    {
        // Create page object
        mtUserLevelAdd = new GLOBALS.MtUserLevelAdd(this);

        // Run the page
        return await mtUserLevelAdd.Run();
    }

    // view
    [Route("MtUserLevelView/{UserLevelID?}", Name = "MtUserLevelView-MTUserLevel-view")]
    [Route("Home/MtUserLevelView/{UserLevelID?}", Name = "MtUserLevelView-MTUserLevel-view-2")]
    public async Task<IActionResult> MtUserLevelView()
    {
        // Create page object
        mtUserLevelView = new GLOBALS.MtUserLevelView(this);

        // Run the page
        return await mtUserLevelView.Run();
    }

    // edit
    [Route("MtUserLevelEdit/{UserLevelID?}", Name = "MtUserLevelEdit-MTUserLevel-edit")]
    [Route("Home/MtUserLevelEdit/{UserLevelID?}", Name = "MtUserLevelEdit-MTUserLevel-edit-2")]
    public async Task<IActionResult> MtUserLevelEdit()
    {
        // Create page object
        mtUserLevelEdit = new GLOBALS.MtUserLevelEdit(this);

        // Run the page
        return await mtUserLevelEdit.Run();
    }

    // delete
    [Route("MtUserLevelDelete/{UserLevelID?}", Name = "MtUserLevelDelete-MTUserLevel-delete")]
    [Route("Home/MtUserLevelDelete/{UserLevelID?}", Name = "MtUserLevelDelete-MTUserLevel-delete-2")]
    public async Task<IActionResult> MtUserLevelDelete()
    {
        // Create page object
        mtUserLevelDelete = new GLOBALS.MtUserLevelDelete(this);

        // Run the page
        return await mtUserLevelDelete.Run();
    }
}
