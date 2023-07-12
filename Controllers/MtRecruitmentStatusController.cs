namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtRecruitmentStatusList/{ID?}", Name = "MtRecruitmentStatusList-MTRecruitmentStatus-list")]
    [Route("Home/MtRecruitmentStatusList/{ID?}", Name = "MtRecruitmentStatusList-MTRecruitmentStatus-list-2")]
    public async Task<IActionResult> MtRecruitmentStatusList()
    {
        // Create page object
        mtRecruitmentStatusList = new GLOBALS.MtRecruitmentStatusList(this);
        mtRecruitmentStatusList.Cache = _cache;

        // Run the page
        return await mtRecruitmentStatusList.Run();
    }

    // add
    [Route("MtRecruitmentStatusAdd/{ID?}", Name = "MtRecruitmentStatusAdd-MTRecruitmentStatus-add")]
    [Route("Home/MtRecruitmentStatusAdd/{ID?}", Name = "MtRecruitmentStatusAdd-MTRecruitmentStatus-add-2")]
    public async Task<IActionResult> MtRecruitmentStatusAdd()
    {
        // Create page object
        mtRecruitmentStatusAdd = new GLOBALS.MtRecruitmentStatusAdd(this);

        // Run the page
        return await mtRecruitmentStatusAdd.Run();
    }

    // view
    [Route("MtRecruitmentStatusView/{ID?}", Name = "MtRecruitmentStatusView-MTRecruitmentStatus-view")]
    [Route("Home/MtRecruitmentStatusView/{ID?}", Name = "MtRecruitmentStatusView-MTRecruitmentStatus-view-2")]
    public async Task<IActionResult> MtRecruitmentStatusView()
    {
        // Create page object
        mtRecruitmentStatusView = new GLOBALS.MtRecruitmentStatusView(this);

        // Run the page
        return await mtRecruitmentStatusView.Run();
    }

    // edit
    [Route("MtRecruitmentStatusEdit/{ID?}", Name = "MtRecruitmentStatusEdit-MTRecruitmentStatus-edit")]
    [Route("Home/MtRecruitmentStatusEdit/{ID?}", Name = "MtRecruitmentStatusEdit-MTRecruitmentStatus-edit-2")]
    public async Task<IActionResult> MtRecruitmentStatusEdit()
    {
        // Create page object
        mtRecruitmentStatusEdit = new GLOBALS.MtRecruitmentStatusEdit(this);

        // Run the page
        return await mtRecruitmentStatusEdit.Run();
    }

    // delete
    [Route("MtRecruitmentStatusDelete/{ID?}", Name = "MtRecruitmentStatusDelete-MTRecruitmentStatus-delete")]
    [Route("Home/MtRecruitmentStatusDelete/{ID?}", Name = "MtRecruitmentStatusDelete-MTRecruitmentStatus-delete-2")]
    public async Task<IActionResult> MtRecruitmentStatusDelete()
    {
        // Create page object
        mtRecruitmentStatusDelete = new GLOBALS.MtRecruitmentStatusDelete(this);

        // Run the page
        return await mtRecruitmentStatusDelete.Run();
    }
}
