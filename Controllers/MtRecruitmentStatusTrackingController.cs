namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtRecruitmentStatusTrackingList/{ID?}", Name = "MtRecruitmentStatusTrackingList-MTRecruitmentStatusTracking-list")]
    [Route("Home/MtRecruitmentStatusTrackingList/{ID?}", Name = "MtRecruitmentStatusTrackingList-MTRecruitmentStatusTracking-list-2")]
    public async Task<IActionResult> MtRecruitmentStatusTrackingList()
    {
        // Create page object
        mtRecruitmentStatusTrackingList = new GLOBALS.MtRecruitmentStatusTrackingList(this);
        mtRecruitmentStatusTrackingList.Cache = _cache;

        // Run the page
        return await mtRecruitmentStatusTrackingList.Run();
    }

    // add
    [Route("MtRecruitmentStatusTrackingAdd/{ID?}", Name = "MtRecruitmentStatusTrackingAdd-MTRecruitmentStatusTracking-add")]
    [Route("Home/MtRecruitmentStatusTrackingAdd/{ID?}", Name = "MtRecruitmentStatusTrackingAdd-MTRecruitmentStatusTracking-add-2")]
    public async Task<IActionResult> MtRecruitmentStatusTrackingAdd()
    {
        // Create page object
        mtRecruitmentStatusTrackingAdd = new GLOBALS.MtRecruitmentStatusTrackingAdd(this);

        // Run the page
        return await mtRecruitmentStatusTrackingAdd.Run();
    }

    // view
    [Route("MtRecruitmentStatusTrackingView/{ID?}", Name = "MtRecruitmentStatusTrackingView-MTRecruitmentStatusTracking-view")]
    [Route("Home/MtRecruitmentStatusTrackingView/{ID?}", Name = "MtRecruitmentStatusTrackingView-MTRecruitmentStatusTracking-view-2")]
    public async Task<IActionResult> MtRecruitmentStatusTrackingView()
    {
        // Create page object
        mtRecruitmentStatusTrackingView = new GLOBALS.MtRecruitmentStatusTrackingView(this);

        // Run the page
        return await mtRecruitmentStatusTrackingView.Run();
    }

    // edit
    [Route("MtRecruitmentStatusTrackingEdit/{ID?}", Name = "MtRecruitmentStatusTrackingEdit-MTRecruitmentStatusTracking-edit")]
    [Route("Home/MtRecruitmentStatusTrackingEdit/{ID?}", Name = "MtRecruitmentStatusTrackingEdit-MTRecruitmentStatusTracking-edit-2")]
    public async Task<IActionResult> MtRecruitmentStatusTrackingEdit()
    {
        // Create page object
        mtRecruitmentStatusTrackingEdit = new GLOBALS.MtRecruitmentStatusTrackingEdit(this);

        // Run the page
        return await mtRecruitmentStatusTrackingEdit.Run();
    }

    // delete
    [Route("MtRecruitmentStatusTrackingDelete/{ID?}", Name = "MtRecruitmentStatusTrackingDelete-MTRecruitmentStatusTracking-delete")]
    [Route("Home/MtRecruitmentStatusTrackingDelete/{ID?}", Name = "MtRecruitmentStatusTrackingDelete-MTRecruitmentStatusTracking-delete-2")]
    public async Task<IActionResult> MtRecruitmentStatusTrackingDelete()
    {
        // Create page object
        mtRecruitmentStatusTrackingDelete = new GLOBALS.MtRecruitmentStatusTrackingDelete(this);

        // Run the page
        return await mtRecruitmentStatusTrackingDelete.Run();
    }
}
