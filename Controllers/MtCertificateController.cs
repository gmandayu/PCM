namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCertificateList/{ID?}", Name = "MtCertificateList-MTCertificate-list")]
    [Route("Home/MtCertificateList/{ID?}", Name = "MtCertificateList-MTCertificate-list-2")]
    public async Task<IActionResult> MtCertificateList()
    {
        // Create page object
        mtCertificateList = new GLOBALS.MtCertificateList(this);
        mtCertificateList.Cache = _cache;

        // Run the page
        return await mtCertificateList.Run();
    }

    // add
    [Route("MtCertificateAdd/{ID?}", Name = "MtCertificateAdd-MTCertificate-add")]
    [Route("Home/MtCertificateAdd/{ID?}", Name = "MtCertificateAdd-MTCertificate-add-2")]
    public async Task<IActionResult> MtCertificateAdd()
    {
        // Create page object
        mtCertificateAdd = new GLOBALS.MtCertificateAdd(this);

        // Run the page
        return await mtCertificateAdd.Run();
    }

    // view
    [Route("MtCertificateView/{ID?}", Name = "MtCertificateView-MTCertificate-view")]
    [Route("Home/MtCertificateView/{ID?}", Name = "MtCertificateView-MTCertificate-view-2")]
    public async Task<IActionResult> MtCertificateView()
    {
        // Create page object
        mtCertificateView = new GLOBALS.MtCertificateView(this);

        // Run the page
        return await mtCertificateView.Run();
    }

    // edit
    [Route("MtCertificateEdit/{ID?}", Name = "MtCertificateEdit-MTCertificate-edit")]
    [Route("Home/MtCertificateEdit/{ID?}", Name = "MtCertificateEdit-MTCertificate-edit-2")]
    public async Task<IActionResult> MtCertificateEdit()
    {
        // Create page object
        mtCertificateEdit = new GLOBALS.MtCertificateEdit(this);

        // Run the page
        return await mtCertificateEdit.Run();
    }

    // delete
    [Route("MtCertificateDelete/{ID?}", Name = "MtCertificateDelete-MTCertificate-delete")]
    [Route("Home/MtCertificateDelete/{ID?}", Name = "MtCertificateDelete-MTCertificate-delete-2")]
    public async Task<IActionResult> MtCertificateDelete()
    {
        // Create page object
        mtCertificateDelete = new GLOBALS.MtCertificateDelete(this);

        // Run the page
        return await mtCertificateDelete.Run();
    }

    // search
    [Route("MtCertificateSearch", Name = "MtCertificateSearch-MTCertificate-search")]
    [Route("Home/MtCertificateSearch", Name = "MtCertificateSearch-MTCertificate-search-2")]
    public async Task<IActionResult> MtCertificateSearch()
    {
        // Create page object
        mtCertificateSearch = new GLOBALS.MtCertificateSearch(this);

        // Run the page
        return await mtCertificateSearch.Run();
    }
}
