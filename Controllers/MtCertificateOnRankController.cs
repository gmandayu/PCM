namespace PCM.Controllers;

// Partial class
public partial class HomeController : Controller
{
    // list
    [Route("MtCertificateOnRankList/{ID?}", Name = "MtCertificateOnRankList-MTCertificateOnRank-list")]
    [Route("Home/MtCertificateOnRankList/{ID?}", Name = "MtCertificateOnRankList-MTCertificateOnRank-list-2")]
    public async Task<IActionResult> MtCertificateOnRankList()
    {
        // Create page object
        mtCertificateOnRankList = new GLOBALS.MtCertificateOnRankList(this);
        mtCertificateOnRankList.Cache = _cache;

        // Run the page
        return await mtCertificateOnRankList.Run();
    }

    // add
    [Route("MtCertificateOnRankAdd/{ID?}", Name = "MtCertificateOnRankAdd-MTCertificateOnRank-add")]
    [Route("Home/MtCertificateOnRankAdd/{ID?}", Name = "MtCertificateOnRankAdd-MTCertificateOnRank-add-2")]
    public async Task<IActionResult> MtCertificateOnRankAdd()
    {
        // Create page object
        mtCertificateOnRankAdd = new GLOBALS.MtCertificateOnRankAdd(this);

        // Run the page
        return await mtCertificateOnRankAdd.Run();
    }

    // view
    [Route("MtCertificateOnRankView/{ID?}", Name = "MtCertificateOnRankView-MTCertificateOnRank-view")]
    [Route("Home/MtCertificateOnRankView/{ID?}", Name = "MtCertificateOnRankView-MTCertificateOnRank-view-2")]
    public async Task<IActionResult> MtCertificateOnRankView()
    {
        // Create page object
        mtCertificateOnRankView = new GLOBALS.MtCertificateOnRankView(this);

        // Run the page
        return await mtCertificateOnRankView.Run();
    }

    // edit
    [Route("MtCertificateOnRankEdit/{ID?}", Name = "MtCertificateOnRankEdit-MTCertificateOnRank-edit")]
    [Route("Home/MtCertificateOnRankEdit/{ID?}", Name = "MtCertificateOnRankEdit-MTCertificateOnRank-edit-2")]
    public async Task<IActionResult> MtCertificateOnRankEdit()
    {
        // Create page object
        mtCertificateOnRankEdit = new GLOBALS.MtCertificateOnRankEdit(this);

        // Run the page
        return await mtCertificateOnRankEdit.Run();
    }

    // delete
    [Route("MtCertificateOnRankDelete/{ID?}", Name = "MtCertificateOnRankDelete-MTCertificateOnRank-delete")]
    [Route("Home/MtCertificateOnRankDelete/{ID?}", Name = "MtCertificateOnRankDelete-MTCertificateOnRank-delete-2")]
    public async Task<IActionResult> MtCertificateOnRankDelete()
    {
        // Create page object
        mtCertificateOnRankDelete = new GLOBALS.MtCertificateOnRankDelete(this);

        // Run the page
        return await mtCertificateOnRankDelete.Run();
    }

    // search
    [Route("MtCertificateOnRankSearch", Name = "MtCertificateOnRankSearch-MTCertificateOnRank-search")]
    [Route("Home/MtCertificateOnRankSearch", Name = "MtCertificateOnRankSearch-MTCertificateOnRank-search-2")]
    public async Task<IActionResult> MtCertificateOnRankSearch()
    {
        // Create page object
        mtCertificateOnRankSearch = new GLOBALS.MtCertificateOnRankSearch(this);

        // Run the page
        return await mtCertificateOnRankSearch.Run();
    }
}
