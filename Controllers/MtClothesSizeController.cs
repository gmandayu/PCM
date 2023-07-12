namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtClothesSizeList/{ID?}", Name = "MtClothesSizeList-MTClothesSize-list")]
    [Route("Home/MtClothesSizeList/{ID?}", Name = "MtClothesSizeList-MTClothesSize-list-2")]
    public async Task<IActionResult> MtClothesSizeList()
    {
        // Create page object
        mtClothesSizeList = new GLOBALS.MtClothesSizeList(this);
        mtClothesSizeList.Cache = _cache;

        // Run the page
        return await mtClothesSizeList.Run();
    }

    // add
    [Route("MtClothesSizeAdd/{ID?}", Name = "MtClothesSizeAdd-MTClothesSize-add")]
    [Route("Home/MtClothesSizeAdd/{ID?}", Name = "MtClothesSizeAdd-MTClothesSize-add-2")]
    public async Task<IActionResult> MtClothesSizeAdd()
    {
        // Create page object
        mtClothesSizeAdd = new GLOBALS.MtClothesSizeAdd(this);

        // Run the page
        return await mtClothesSizeAdd.Run();
    }

    // view
    [Route("MtClothesSizeView/{ID?}", Name = "MtClothesSizeView-MTClothesSize-view")]
    [Route("Home/MtClothesSizeView/{ID?}", Name = "MtClothesSizeView-MTClothesSize-view-2")]
    public async Task<IActionResult> MtClothesSizeView()
    {
        // Create page object
        mtClothesSizeView = new GLOBALS.MtClothesSizeView(this);

        // Run the page
        return await mtClothesSizeView.Run();
    }

    // edit
    [Route("MtClothesSizeEdit/{ID?}", Name = "MtClothesSizeEdit-MTClothesSize-edit")]
    [Route("Home/MtClothesSizeEdit/{ID?}", Name = "MtClothesSizeEdit-MTClothesSize-edit-2")]
    public async Task<IActionResult> MtClothesSizeEdit()
    {
        // Create page object
        mtClothesSizeEdit = new GLOBALS.MtClothesSizeEdit(this);

        // Run the page
        return await mtClothesSizeEdit.Run();
    }

    // delete
    [Route("MtClothesSizeDelete/{ID?}", Name = "MtClothesSizeDelete-MTClothesSize-delete")]
    [Route("Home/MtClothesSizeDelete/{ID?}", Name = "MtClothesSizeDelete-MTClothesSize-delete-2")]
    public async Task<IActionResult> MtClothesSizeDelete()
    {
        // Create page object
        mtClothesSizeDelete = new GLOBALS.MtClothesSizeDelete(this);

        // Run the page
        return await mtClothesSizeDelete.Run();
    }

    // search
    [Route("MtClothesSizeSearch", Name = "MtClothesSizeSearch-MTClothesSize-search")]
    [Route("Home/MtClothesSizeSearch", Name = "MtClothesSizeSearch-MTClothesSize-search-2")]
    public async Task<IActionResult> MtClothesSizeSearch()
    {
        // Create page object
        mtClothesSizeSearch = new GLOBALS.MtClothesSizeSearch(this);

        // Run the page
        return await mtClothesSizeSearch.Run();
    }
}
