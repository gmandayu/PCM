namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtReligionList/{ID?}", Name = "MtReligionList-MTReligion-list")]
    [Route("Home/MtReligionList/{ID?}", Name = "MtReligionList-MTReligion-list-2")]
    public async Task<IActionResult> MtReligionList()
    {
        // Create page object
        mtReligionList = new GLOBALS.MtReligionList(this);
        mtReligionList.Cache = _cache;

        // Run the page
        return await mtReligionList.Run();
    }

    // add
    [Route("MtReligionAdd/{ID?}", Name = "MtReligionAdd-MTReligion-add")]
    [Route("Home/MtReligionAdd/{ID?}", Name = "MtReligionAdd-MTReligion-add-2")]
    public async Task<IActionResult> MtReligionAdd()
    {
        // Create page object
        mtReligionAdd = new GLOBALS.MtReligionAdd(this);

        // Run the page
        return await mtReligionAdd.Run();
    }

    // view
    [Route("MtReligionView/{ID?}", Name = "MtReligionView-MTReligion-view")]
    [Route("Home/MtReligionView/{ID?}", Name = "MtReligionView-MTReligion-view-2")]
    public async Task<IActionResult> MtReligionView()
    {
        // Create page object
        mtReligionView = new GLOBALS.MtReligionView(this);

        // Run the page
        return await mtReligionView.Run();
    }

    // edit
    [Route("MtReligionEdit/{ID?}", Name = "MtReligionEdit-MTReligion-edit")]
    [Route("Home/MtReligionEdit/{ID?}", Name = "MtReligionEdit-MTReligion-edit-2")]
    public async Task<IActionResult> MtReligionEdit()
    {
        // Create page object
        mtReligionEdit = new GLOBALS.MtReligionEdit(this);

        // Run the page
        return await mtReligionEdit.Run();
    }

    // delete
    [Route("MtReligionDelete/{ID?}", Name = "MtReligionDelete-MTReligion-delete")]
    [Route("Home/MtReligionDelete/{ID?}", Name = "MtReligionDelete-MTReligion-delete-2")]
    public async Task<IActionResult> MtReligionDelete()
    {
        // Create page object
        mtReligionDelete = new GLOBALS.MtReligionDelete(this);

        // Run the page
        return await mtReligionDelete.Run();
    }

    // search
    [Route("MtReligionSearch", Name = "MtReligionSearch-MTReligion-search")]
    [Route("Home/MtReligionSearch", Name = "MtReligionSearch-MTReligion-search-2")]
    public async Task<IActionResult> MtReligionSearch()
    {
        // Create page object
        mtReligionSearch = new GLOBALS.MtReligionSearch(this);

        // Run the page
        return await mtReligionSearch.Run();
    }
}
