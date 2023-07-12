namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("TrmcuResultList/{McuResult_ID?}", Name = "TrmcuResultList-TRMCUResult-list")]
    [Route("Home/TrmcuResultList/{McuResult_ID?}", Name = "TrmcuResultList-TRMCUResult-list-2")]
    public async Task<IActionResult> TrmcuResultList()
    {
        // Create page object
        trmcuResultList = new GLOBALS.TrmcuResultList(this);
        trmcuResultList.Cache = _cache;

        // Run the page
        return await trmcuResultList.Run();
    }

    // add
    [Route("TrmcuResultAdd/{McuResult_ID?}", Name = "TrmcuResultAdd-TRMCUResult-add")]
    [Route("Home/TrmcuResultAdd/{McuResult_ID?}", Name = "TrmcuResultAdd-TRMCUResult-add-2")]
    public async Task<IActionResult> TrmcuResultAdd()
    {
        // Create page object
        trmcuResultAdd = new GLOBALS.TrmcuResultAdd(this);

        // Run the page
        return await trmcuResultAdd.Run();
    }

    // view
    [Route("TrmcuResultView/{McuResult_ID?}", Name = "TrmcuResultView-TRMCUResult-view")]
    [Route("Home/TrmcuResultView/{McuResult_ID?}", Name = "TrmcuResultView-TRMCUResult-view-2")]
    public async Task<IActionResult> TrmcuResultView()
    {
        // Create page object
        trmcuResultView = new GLOBALS.TrmcuResultView(this);

        // Run the page
        return await trmcuResultView.Run();
    }

    // edit
    [Route("TrmcuResultEdit/{McuResult_ID?}", Name = "TrmcuResultEdit-TRMCUResult-edit")]
    [Route("Home/TrmcuResultEdit/{McuResult_ID?}", Name = "TrmcuResultEdit-TRMCUResult-edit-2")]
    public async Task<IActionResult> TrmcuResultEdit()
    {
        // Create page object
        trmcuResultEdit = new GLOBALS.TrmcuResultEdit(this);

        // Run the page
        return await trmcuResultEdit.Run();
    }

    // delete
    [Route("TrmcuResultDelete/{McuResult_ID?}", Name = "TrmcuResultDelete-TRMCUResult-delete")]
    [Route("Home/TrmcuResultDelete/{McuResult_ID?}", Name = "TrmcuResultDelete-TRMCUResult-delete-2")]
    public async Task<IActionResult> TrmcuResultDelete()
    {
        // Create page object
        trmcuResultDelete = new GLOBALS.TrmcuResultDelete(this);

        // Run the page
        return await trmcuResultDelete.Run();
    }
}
