namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtMedicalCertificateList/{ID?}", Name = "MtMedicalCertificateList-MTMedicalCertificate-list")]
    [Route("Home/MtMedicalCertificateList/{ID?}", Name = "MtMedicalCertificateList-MTMedicalCertificate-list-2")]
    public async Task<IActionResult> MtMedicalCertificateList()
    {
        // Create page object
        mtMedicalCertificateList = new GLOBALS.MtMedicalCertificateList(this);
        mtMedicalCertificateList.Cache = _cache;

        // Run the page
        return await mtMedicalCertificateList.Run();
    }

    // add
    [Route("MtMedicalCertificateAdd/{ID?}", Name = "MtMedicalCertificateAdd-MTMedicalCertificate-add")]
    [Route("Home/MtMedicalCertificateAdd/{ID?}", Name = "MtMedicalCertificateAdd-MTMedicalCertificate-add-2")]
    public async Task<IActionResult> MtMedicalCertificateAdd()
    {
        // Create page object
        mtMedicalCertificateAdd = new GLOBALS.MtMedicalCertificateAdd(this);

        // Run the page
        return await mtMedicalCertificateAdd.Run();
    }

    // view
    [Route("MtMedicalCertificateView/{ID?}", Name = "MtMedicalCertificateView-MTMedicalCertificate-view")]
    [Route("Home/MtMedicalCertificateView/{ID?}", Name = "MtMedicalCertificateView-MTMedicalCertificate-view-2")]
    public async Task<IActionResult> MtMedicalCertificateView()
    {
        // Create page object
        mtMedicalCertificateView = new GLOBALS.MtMedicalCertificateView(this);

        // Run the page
        return await mtMedicalCertificateView.Run();
    }

    // edit
    [Route("MtMedicalCertificateEdit/{ID?}", Name = "MtMedicalCertificateEdit-MTMedicalCertificate-edit")]
    [Route("Home/MtMedicalCertificateEdit/{ID?}", Name = "MtMedicalCertificateEdit-MTMedicalCertificate-edit-2")]
    public async Task<IActionResult> MtMedicalCertificateEdit()
    {
        // Create page object
        mtMedicalCertificateEdit = new GLOBALS.MtMedicalCertificateEdit(this);

        // Run the page
        return await mtMedicalCertificateEdit.Run();
    }

    // delete
    [Route("MtMedicalCertificateDelete/{ID?}", Name = "MtMedicalCertificateDelete-MTMedicalCertificate-delete")]
    [Route("Home/MtMedicalCertificateDelete/{ID?}", Name = "MtMedicalCertificateDelete-MTMedicalCertificate-delete-2")]
    public async Task<IActionResult> MtMedicalCertificateDelete()
    {
        // Create page object
        mtMedicalCertificateDelete = new GLOBALS.MtMedicalCertificateDelete(this);

        // Run the page
        return await mtMedicalCertificateDelete.Run();
    }

    // search
    [Route("MtMedicalCertificateSearch", Name = "MtMedicalCertificateSearch-MTMedicalCertificate-search")]
    [Route("Home/MtMedicalCertificateSearch", Name = "MtMedicalCertificateSearch-MTMedicalCertificate-search-2")]
    public async Task<IActionResult> MtMedicalCertificateSearch()
    {
        // Create page object
        mtMedicalCertificateSearch = new GLOBALS.MtMedicalCertificateSearch(this);

        // Run the page
        return await mtMedicalCertificateSearch.Run();
    }
}
