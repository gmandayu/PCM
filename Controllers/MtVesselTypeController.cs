namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtVesselTypeList/{ID?}", Name = "MtVesselTypeList-MTVesselType-list")]
    [Route("Home/MtVesselTypeList/{ID?}", Name = "MtVesselTypeList-MTVesselType-list-2")]
    public async Task<IActionResult> MtVesselTypeList()
    {
        // Create page object
        mtVesselTypeList = new GLOBALS.MtVesselTypeList(this);
        mtVesselTypeList.Cache = _cache;

        // Run the page
        return await mtVesselTypeList.Run();
    }

    // add
    [Route("MtVesselTypeAdd/{ID?}", Name = "MtVesselTypeAdd-MTVesselType-add")]
    [Route("Home/MtVesselTypeAdd/{ID?}", Name = "MtVesselTypeAdd-MTVesselType-add-2")]
    public async Task<IActionResult> MtVesselTypeAdd()
    {
        // Create page object
        mtVesselTypeAdd = new GLOBALS.MtVesselTypeAdd(this);

        // Run the page
        return await mtVesselTypeAdd.Run();
    }

    // view
    [Route("MtVesselTypeView/{ID?}", Name = "MtVesselTypeView-MTVesselType-view")]
    [Route("Home/MtVesselTypeView/{ID?}", Name = "MtVesselTypeView-MTVesselType-view-2")]
    public async Task<IActionResult> MtVesselTypeView()
    {
        // Create page object
        mtVesselTypeView = new GLOBALS.MtVesselTypeView(this);

        // Run the page
        return await mtVesselTypeView.Run();
    }

    // edit
    [Route("MtVesselTypeEdit/{ID?}", Name = "MtVesselTypeEdit-MTVesselType-edit")]
    [Route("Home/MtVesselTypeEdit/{ID?}", Name = "MtVesselTypeEdit-MTVesselType-edit-2")]
    public async Task<IActionResult> MtVesselTypeEdit()
    {
        // Create page object
        mtVesselTypeEdit = new GLOBALS.MtVesselTypeEdit(this);

        // Run the page
        return await mtVesselTypeEdit.Run();
    }

    // delete
    [Route("MtVesselTypeDelete/{ID?}", Name = "MtVesselTypeDelete-MTVesselType-delete")]
    [Route("Home/MtVesselTypeDelete/{ID?}", Name = "MtVesselTypeDelete-MTVesselType-delete-2")]
    public async Task<IActionResult> MtVesselTypeDelete()
    {
        // Create page object
        mtVesselTypeDelete = new GLOBALS.MtVesselTypeDelete(this);

        // Run the page
        return await mtVesselTypeDelete.Run();
    }

    // search
    [Route("MtVesselTypeSearch", Name = "MtVesselTypeSearch-MTVesselType-search")]
    [Route("Home/MtVesselTypeSearch", Name = "MtVesselTypeSearch-MTVesselType-search-2")]
    public async Task<IActionResult> MtVesselTypeSearch()
    {
        // Create page object
        mtVesselTypeSearch = new GLOBALS.MtVesselTypeSearch(this);

        // Run the page
        return await mtVesselTypeSearch.Run();
    }
}
