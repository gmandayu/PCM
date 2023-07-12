namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCrewMedicalCertificateList/{ID?}", Name = "MtCrewMedicalCertificateList-MTCrewMedicalCertificate-list")]
    [Route("Home/MtCrewMedicalCertificateList/{ID?}", Name = "MtCrewMedicalCertificateList-MTCrewMedicalCertificate-list-2")]
    public async Task<IActionResult> MtCrewMedicalCertificateList()
    {
        // Create page object
        mtCrewMedicalCertificateList = new GLOBALS.MtCrewMedicalCertificateList(this);
        mtCrewMedicalCertificateList.Cache = _cache;

        // Run the page
        return await mtCrewMedicalCertificateList.Run();
    }

    // search
    [Route("MtCrewMedicalCertificateSearch", Name = "MtCrewMedicalCertificateSearch-MTCrewMedicalCertificate-search")]
    [Route("Home/MtCrewMedicalCertificateSearch", Name = "MtCrewMedicalCertificateSearch-MTCrewMedicalCertificate-search-2")]
    public async Task<IActionResult> MtCrewMedicalCertificateSearch()
    {
        // Create page object
        mtCrewMedicalCertificateSearch = new GLOBALS.MtCrewMedicalCertificateSearch(this);

        // Run the page
        return await mtCrewMedicalCertificateSearch.Run();
    }
}
