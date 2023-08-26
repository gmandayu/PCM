namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TrUpdateTrackingList/{ID?}", Name = "TrUpdateTrackingList-TRUpdateTracking-list")]
    [Route("Home/TrUpdateTrackingList/{ID?}", Name = "TrUpdateTrackingList-TRUpdateTracking-list-2")]
    public async Task<IActionResult> TrUpdateTrackingList()
    {
        // Create page object
        trUpdateTrackingList = new GLOBALS.TrUpdateTrackingList(this);
        trUpdateTrackingList.Cache = _cache;

        // Run the page
        return await trUpdateTrackingList.Run();
    }

    // add
    [Route("TrUpdateTrackingAdd/{ID?}", Name = "TrUpdateTrackingAdd-TRUpdateTracking-add")]
    [Route("Home/TrUpdateTrackingAdd/{ID?}", Name = "TrUpdateTrackingAdd-TRUpdateTracking-add-2")]
    public async Task<IActionResult> TrUpdateTrackingAdd()
    {
        // Create page object
        trUpdateTrackingAdd = new GLOBALS.TrUpdateTrackingAdd(this);

        // Run the page
        return await trUpdateTrackingAdd.Run();
    }

    // view
    [Route("TrUpdateTrackingView/{ID?}", Name = "TrUpdateTrackingView-TRUpdateTracking-view")]
    [Route("Home/TrUpdateTrackingView/{ID?}", Name = "TrUpdateTrackingView-TRUpdateTracking-view-2")]
    public async Task<IActionResult> TrUpdateTrackingView()
    {
        // Create page object
        trUpdateTrackingView = new GLOBALS.TrUpdateTrackingView(this);

        // Run the page
        return await trUpdateTrackingView.Run();
    }

    // edit
    [Route("TrUpdateTrackingEdit/{ID?}", Name = "TrUpdateTrackingEdit-TRUpdateTracking-edit")]
    [Route("Home/TrUpdateTrackingEdit/{ID?}", Name = "TrUpdateTrackingEdit-TRUpdateTracking-edit-2")]
    public async Task<IActionResult> TrUpdateTrackingEdit()
    {
        // Create page object
        trUpdateTrackingEdit = new GLOBALS.TrUpdateTrackingEdit(this);

        // Run the page
        return await trUpdateTrackingEdit.Run();
    }

    // delete
    [Route("TrUpdateTrackingDelete/{ID?}", Name = "TrUpdateTrackingDelete-TRUpdateTracking-delete")]
    [Route("Home/TrUpdateTrackingDelete/{ID?}", Name = "TrUpdateTrackingDelete-TRUpdateTracking-delete-2")]
    public async Task<IActionResult> TrUpdateTrackingDelete()
    {
        // Create page object
        trUpdateTrackingDelete = new GLOBALS.TrUpdateTrackingDelete(this);

        // Run the page
        return await trUpdateTrackingDelete.Run();
    }
}
