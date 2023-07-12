namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtUserLevelPermissionList/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionList-MTUserLevelPermission-list")]
    [Route("Home/MtUserLevelPermissionList/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionList-MTUserLevelPermission-list-2")]
    public async Task<IActionResult> MtUserLevelPermissionList()
    {
        // Create page object
        mtUserLevelPermissionList = new GLOBALS.MtUserLevelPermissionList(this);
        mtUserLevelPermissionList.Cache = _cache;

        // Run the page
        return await mtUserLevelPermissionList.Run();
    }

    // add
    [Route("MtUserLevelPermissionAdd/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionAdd-MTUserLevelPermission-add")]
    [Route("Home/MtUserLevelPermissionAdd/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionAdd-MTUserLevelPermission-add-2")]
    public async Task<IActionResult> MtUserLevelPermissionAdd()
    {
        // Create page object
        mtUserLevelPermissionAdd = new GLOBALS.MtUserLevelPermissionAdd(this);

        // Run the page
        return await mtUserLevelPermissionAdd.Run();
    }

    // view
    [Route("MtUserLevelPermissionView/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionView-MTUserLevelPermission-view")]
    [Route("Home/MtUserLevelPermissionView/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionView-MTUserLevelPermission-view-2")]
    public async Task<IActionResult> MtUserLevelPermissionView()
    {
        // Create page object
        mtUserLevelPermissionView = new GLOBALS.MtUserLevelPermissionView(this);

        // Run the page
        return await mtUserLevelPermissionView.Run();
    }

    // edit
    [Route("MtUserLevelPermissionEdit/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionEdit-MTUserLevelPermission-edit")]
    [Route("Home/MtUserLevelPermissionEdit/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionEdit-MTUserLevelPermission-edit-2")]
    public async Task<IActionResult> MtUserLevelPermissionEdit()
    {
        // Create page object
        mtUserLevelPermissionEdit = new GLOBALS.MtUserLevelPermissionEdit(this);

        // Run the page
        return await mtUserLevelPermissionEdit.Run();
    }

    // delete
    [Route("MtUserLevelPermissionDelete/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionDelete-MTUserLevelPermission-delete")]
    [Route("Home/MtUserLevelPermissionDelete/{UserLevelID?}/{_TableName?}", Name = "MtUserLevelPermissionDelete-MTUserLevelPermission-delete-2")]
    public async Task<IActionResult> MtUserLevelPermissionDelete()
    {
        // Create page object
        mtUserLevelPermissionDelete = new GLOBALS.MtUserLevelPermissionDelete(this);

        // Run the page
        return await mtUserLevelPermissionDelete.Run();
    }
}
