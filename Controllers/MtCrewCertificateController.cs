namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewCertificateList/{ID?}", Name = "MtCrewCertificateList-MTCrewCertificate-list")]
    [Route("Home/MtCrewCertificateList/{ID?}", Name = "MtCrewCertificateList-MTCrewCertificate-list-2")]
    public async Task<IActionResult> MtCrewCertificateList()
    {
        // Create page object
        mtCrewCertificateList = new GLOBALS.MtCrewCertificateList(this);
        mtCrewCertificateList.Cache = _cache;

        // Run the page
        return await mtCrewCertificateList.Run();
    }

    // search
    [Route("MtCrewCertificateSearch", Name = "MtCrewCertificateSearch-MTCrewCertificate-search")]
    [Route("Home/MtCrewCertificateSearch", Name = "MtCrewCertificateSearch-MTCrewCertificate-search-2")]
    public async Task<IActionResult> MtCrewCertificateSearch()
    {
        // Create page object
        mtCrewCertificateSearch = new GLOBALS.MtCrewCertificateSearch(this);

        // Run the page
        return await mtCrewCertificateSearch.Run();
    }

    // preview
    [Route("MtCrewCertificatePreview", Name = "MtCrewCertificatePreview-MTCrewCertificate-preview")]
    [Route("Home/MtCrewCertificatePreview", Name = "MtCrewCertificatePreview-MTCrewCertificate-preview-2")]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
    public async Task<IActionResult> MtCrewCertificatePreview()
    {
        // Create page object
        mtCrewCertificatePreview = new GLOBALS.MtCrewCertificatePreview(this);

        // Run the page
        return await mtCrewCertificatePreview.Run();
    }
}
