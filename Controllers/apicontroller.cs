namespace PCM.Controllers;

[ApiController]
[Route("api/[controller]/")]
[EnableCors("ApiCorsPolicy")]
[HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
public abstract class ApiController : Controller
{
    public static Lang Language = ResolveLanguage();

    // Dispose
    // protected override void Dispose(bool disposing)
    // {
    //     try
    //     {
    //         base.Dispose(disposing);
    //     }
    //     finally
    //     {
    //     }
    // }
}

/// <summary>
/// List records from a table
/// </summary>
/// <example>
/// api/list/cars
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class ListController : ApiController
{
    [HttpGet("{table}")]
    public async Task<IActionResult> List([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "List", new object[] { this });
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion }, false);
    }
}

/// <summary>
/// Get a record from a table
/// </summary>
/// <example>
/// api/view/cars/1/...
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class ViewController : ApiController
{
    [HttpGet("{table}/{**key}")]
    public async Task<IActionResult> Get([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "View", new object[] { this });
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion }, false);
    }
}

/// <summary>
/// Insert a record to a table by POST
/// </summary>
/// <example>
/// api/add
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class AddController : ApiController
{
    [HttpPost("{table}")]
    public async Task<IActionResult> Add([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "Add", new object[] { this });
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion }, false);
    }
}

/// <summary>
/// Edit a record by POST
/// </summary>
/// <example>
/// api/edit/cars/1/...
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class EditController : ApiController
{
    [HttpPost("{table}/{**key}")]
    public async Task<IActionResult> Edit([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "Edit", new object[] { this });
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion }, false);
    }
}

/// <summary>
/// Delete a record from a table
/// </summary>
/// <example>
/// api/delete/cars/1/...
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class DeleteController : ApiController
{
    [HttpGet("{table}/{**key}")]
    [HttpPost("{table}")]
    public async Task<IActionResult> Delete([FromRoute] string table)
    {
        if (Config.NamedTypes.TryGetValue(table, out Type? classType) && classType != null) {
            var obj = CreateInstance(classType.Name + "Delete", new object[] { this });
            if (obj != null)
                return await obj.Run();
        }
        return new JsonBoolResult(new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion }, false);
    }
}

/// <summary>
/// Export file
/// </summary>
/// <example>
/// api/export/cars
/// </example>
[Authorize(Policy = "ApiUserLevel2")]
public class ExportController : ApiController
{
    /// <summary>
    /// Export file by export type and table name
    /// </summary>
    /// <param name="type">Export type</param>
    /// <param name="table">Table name</param>
    /// <returns>Export content</returns>
    [HttpPost("{type}/{table}")]
    [HttpGet("{type}/{table}")]
    public async Task<IActionResult> ExportData([FromRoute] string type, [FromRoute] string table)
    {
        ExportHandler obj = new (this);
        return await obj.ExportData(type, table);
    }

    /// <summary>
    /// Export file by export type, table name and primary key
    /// </summary>
    /// <param name="type">Export type</param>
    /// <param name="table">Table name</param>
    /// <param name="key">Primary key</param>
    /// <returns>Export content</returns>
    [HttpPost("{type}/{table}/{**key}")]
    [HttpGet("{type}/{table}/{**key}")]
    public async Task<IActionResult> ExportData([FromRoute] string type, [FromRoute] string table, [FromRoute] string key)
    {
        ExportHandler obj = new (this);
        return await obj.ExportData(type, table, key.Split('/'));
    }

    /// <summary>
    /// Search export file
    /// </summary>
    /// <param name="search">File guid / search</param>
    /// <returns>Export content</returns>
    [HttpGet("{search}")]
    public async Task<IActionResult> Search([FromRoute] string search)
    {
        ExportHandler obj = new (this);
        return await obj.Search(search);
    }
}

/// <summary>
/// Register a record to a table by POST
/// </summary>
/// <example>
/// api/register
/// </example>
[AllowAnonymous]
public class RegisterController : ApiController
{
    // Post
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var obj = CreateInstance("Register", new object[] { this });
        if (obj != null)
            return await obj.Run();
        return new JsonBoolResult(new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion }, false);
    }
}

/// <summary>
/// Login by POST
/// </summary>
/// <example>
/// api/login
/// </example>
[AllowAnonymous]
public class LoginController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] LoginModel model)
    {
        // User profile
        Profile = ResolveProfile();

        // Security
        Security = ResolveSecurity();

        // As an example, AuthService.CreateToken can return Jose.JWT.Encode(claims, YourTokenSecretKey, Jose.JwsAlgorithm.HS256);
        if (await Security.ValidateUser(model, false))
            return Ok(new { JWT = Security.CreateJwtToken(model.Expire * 60 * 60, model.Permission) });
        return BadRequest(Language.Phrase("InvalidUidPwd"));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] LoginModel model)
    {
        // User profile
        Profile = ResolveProfile();

        // Security
        Security = ResolveSecurity();

        // As an example, AuthService.CreateToken can return Jose.JWT.Encode(claims, YourTokenSecretKey, Jose.JwsAlgorithm.HS256);
        if (await Security.ValidateUser(model, false))
            return Ok(new { JWT = Security.CreateJwtToken(model.Expire * 60 * 60, model.Permission) });
        return BadRequest(Language.Phrase("InvalidUidPwd"));
    }
}

/// <summary>
/// Get a file
/// </summary>
/// <example>
/// api/file/cars/Picture/1/...
/// </example>
public class FileController : ApiController
{
    /// <summary>
    /// Get file by table name, field name and primary key
    /// </summary>
    /// <param name="table">Table name</param>
    /// <param name="field">Field name</param>
    /// <param name="key">Primary key</param>
    /// <returns>File result</returns>
    [Authorize(Policy = "UserLevel")]
    [HttpGet("{table}/{field}/{**key}")]
    public async Task<IActionResult> GetFile([FromRoute] string table, [FromRoute] string field, [FromRoute] string key)
    {
        Language = ResolveLanguage(); // Set up CurrentNumberFormat
        FileViewer obj = new (this);
        return await obj.GetFile(table, field, key.Split('/'));
    }

    /// <summary>
    /// Get file by table name and file path
    /// </summary>
    /// <param name="table">Table name</param>
    /// <param name="fn">File path</param>
    /// <returns>File result</returns>
    [Authorize(Policy = "UserLevel")]
    [HttpGet("{table}/{fn}")]
    public async Task<IActionResult> GetFile([FromRoute] string table, [FromRoute] string fn)
    {
        Language = ResolveLanguage(); // Set up CurrentNumberFormat
        FileViewer obj = new (this);
        return await obj.GetFile(table, fn);
    }

    /// <summary>
    /// Get file by file path
    /// </summary>
    /// <param name="fn">File path</param>
    /// <returns>File result</returns>
    [AllowAnonymous]
    [HttpGet("{fn}")]
    public async Task<IActionResult> GetFile([FromRoute] string fn)
    {
        Language = ResolveLanguage(); // Set up CurrentNumberFormat
        FileViewer obj = new (this);
        return await obj.GetFile(fn);
    }
}

/// <summary>
/// File upload
/// </summary>
/// <example>
/// api/upload
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class UploadController : ApiController
{
    [HttpPost]
    [HttpPut]
    public async Task<IActionResult> Post() => await HttpUpload.GetUploadedFiles();
}

/// <summary>
/// File upload with jQuery File Upload
/// </summary>
/// <example>
/// api/jupload
/// </example>
[AutoValidateAntiforgeryToken]
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi = true)]
public class JUploadController : ApiController
{
    [HttpGet]
    [HttpPost]
    [HttpPut]
    public async Task<IActionResult> Index()
    {
        var obj = new UploadHandler(this);
        return await obj.Run();
    }
}

/// <summary>
/// Session handler
/// </summary>
/// <example>
/// api/session
/// </example>
[AutoValidateAntiforgeryToken]
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi = true)]
public class SessionController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        var obj = new SessionHandler(this);
        return obj.GetSession();
    }
}

/// <summary>
/// Lookup (UpdateOption/ModalLookup/AutoSuggest/AutoFill)
/// </summary>
/// <example>
/// api/lookup
/// </example>
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi = true)]
public class LookupController : ApiController
{
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<IActionResult> Post([FromForm] string page) // Single request
    {
        dynamic? obj = Resolve(page); // Get object created in API permission handler
        var res = await obj?.Lookup() ?? new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion };
        return new JsonBoolResult((object)res, res.TryGetValue("result", out object? v) ? ConvertToString(v) == "OK" : false);
    }

    [HttpPost]
    [Consumes("application/json")]
    public async Task<IActionResult> Batch([FromBody] List<Dictionary<string, string>> pages) // Batch request (json)
    {
        List<object> responses = new ();
        foreach (Dictionary<string, string> req in pages) {
            if (req.TryGetValue(Config.ApiLookupPage, out string? page) && req.TryGetValue(Config.ApiFieldName, out string? fieldName)) {
                dynamic? obj = Resolve(page); // Get object
                dynamic? tbl = obj?.FieldByName(fieldName)?.Lookup?.GetTable(); // Get table
                if (tbl != null) {
                    Security.LoadTablePermissions(tbl.TableVar);
                    object res = Security.CanLookup
                        ? await obj?.Lookup(req) ?? new { success = false, error = Language.Phrase("FailedToCreate"), version = Config.ProductVersion }
                        : new { success = false, error = "401 " + Language.Phrase("401"), version = Config.ProductVersion };
                    responses.Add(res);
                }
            }
        }
        return Json(responses);
    }
}

/// <summary>
/// Chart exporter
/// </summary>
/// <example>
/// api/chart
/// </example>
[AutoValidateAntiforgeryToken]
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ChartController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        var exporter = new ChartExporter(this);
        return await exporter.Export();
    }
}

/// <summary>
/// Permissions
/// </summary>
/// <example>
/// api/permissions/{userlevel}
/// </example>
[Authorize(Policy = "ApiUserLevel")]
public class PermissionsController : ApiController
{
    [AllowAnonymous]
    [HttpGet("{userlevel?}")]
    public IActionResult Get([FromRoute] string userlevel)
    {
        if (!ValidApiRequest())
            return new EmptyResult();
        Security.SetupUserLevel();

        // Check user level
        int userLevel = -2; // Default anonymous
        List<int> userLevels = new ();
        userLevels.Add(userLevel);
        if (Security.IsLoggedIn) {
            if (Security.IsSysAdmin && IsNumeric(userlevel) && userlevel != "-1") { // Get permissions for user level
                if (Security.UserLevelIDExists(Convert.ToInt32(userlevel))) { // Make sure user level exists
                    userLevel = Convert.ToInt32(userlevel);
                    userLevels.Clear();
                    userLevels.Add(userLevel);
                }
            } else { // Get current user permissions
                userLevel = Convert.ToInt32(Security.CurrentUserLevelID);
                userLevels = Security.UserLevelID;
            }
        }
        Dictionary<string, int> privs = new ();
        var wrkTable = Config.UserLevelTablePermissions;
        foreach (var table in wrkTable) {
            if (table.Allowed) {
                int priv = 0;
                foreach (int lvl in userLevels)
                    priv |= Security.GetUserLevelPriv(table.ProjectId + table.TableName, lvl);
                privs.Add(table.TableVar, priv);
            }
        }
        return Json(new { userlevel = userLevel, permissions = privs });
    }

    // Post with route
    [HttpPost("{userlevel}")]
    public async Task<IActionResult> PostWithRoute([FromRoute] string userlevel)
    {
        if (!ValidApiRequest())
            return new EmptyResult();
        await Security.SetupUserLevels();

        // Check if admin
        if (!Security.IsSysAdmin)
            return new EmptyResult();

        // Check user level
        int userLevel;
        if (IsNumeric(userlevel) && userlevel != "-1") { // Set permissions for user level
            userLevel = Convert.ToInt32(userlevel);
        } else {
            return new EmptyResult();
        }
        Dictionary<string, int> privs = new ();
        Dictionary<string, int> privsOut = new ();
        StringValues sv;
        var wrkTable = Config.UserLevelTablePermissions;
        foreach (var table in wrkTable) {
            if (table.Allowed && Post(table.TableVar, out sv)) {
                int priv = Convert.ToInt32(sv);
                privs.Add(table.ProjectId + table.TableName, priv);
                privsOut.Add(table.TableName, priv);
            }
        }
        var mi = Security.GetType().GetMethod("UpdatePermissions", BindingFlags.Public | BindingFlags.Instance);
        if (mi?.Invoke(Security, new object[] { userLevel, privs }) is Task<bool> res)
            await res; // Update Permissions
        return Json(new { success = true, userlevel = userLevel, permissions = privsOut });
    }
}

// Custom API actions
// GMANDAYU: Start
public class ChecklistItemsRequest
{
    public string EmployeeStatus { get; set; }

    public int CrewID { get; set; }
}

public class RequestData
{
    public MCUDateTimeRequest mcuDateTimeRequest { get; set; }

    public ExpiredDateRequest expiredDateRequest { get; set; }

    public HealthStatusRequest healthStatusRequest { get; set; }

    public MCULocationRequest mcuLocationRequest { get; set; }

    public UploadFileRequest uploadFileRequest { get; set; }
}

public class MCUDateTimeRequest
{
    public string mcuDate { get; set; }

    public string crewIDArray { get; set; }
}

public class ExpiredDateRequest
{
    public string expiredDate { get; set; }

    public string crewIDArray { get; set; }
}

public class HealthStatusRequest
{
    public string healthStatus { get; set; }

    public string crewIDArray { get; set; }
}

public class MCULocationRequest
{
    public string mcuLocation { get; set; }

    public string crewIDArray { get; set; }
}

public class UploadFileRequest
{
    public string uploadFile { get; set; }

    public string crewIDArray { get; set; }
}

public class CustomFormat
{
    public const string DATE_FORMAT = "'dd MMM yyyy'"; // the single quote is to be used for SelectRaw

    public const string DATE_TIME_FORMAT = "'dd MMM yyyy HH:mm:sszzz'"; // the single quote is to be used for SelectRaw

    public const string YEAR_ONLY_FORMAT = "'yyyy'"; // the single quote is to be used for SelectRaw
}
// GMANDAYU: End
// gmandayu: required for revised actions.
public class RevisedMultipleCrewRequest
{
    public string revisedReason { get; set; }

    public string crewIDArray { get; set; }
}

// gmandayu: required for accept MCU result page.
public class AcceptSingleFinalRequest { 

    public string finalAcceptDateTime { get; set; }

    public string crewIDArray { get; set; }
}

public class JsonResponse
{
    public bool success { get; set; }

    public object data { get; set; }

    public string errorMessage { get; set; }
}

public class DocumentCheckDateTimeRequest
{
    public string scheduleDateTime { get; set; }

    public string notes { get; set; }

    public string crewIDArray { get; set; }
}

public class RejectMultipleRequest
{
    public string rejectReason { get; set; }

    public string crewIDArray { get; set; }
}

public class InterviewDateTimeRequest
{
    public string managerInterviewDateTime { get; set; }

    public string gmInterviewDateTime { get; set; }

    public int crewID { get; set; }       

    public int checklistID { get; set; }
}

public class MCUScheduleRequest
{
    public string mcuScheduleDateTime { get; set; }

    public string mcuLocation { get; set; }

    public int crewID { get; set; }
}

public class RejectSingleRequest
{
    public string rejectReason { get; set; }

    public int crewID { get; set; }
}

/* Gmandayu: reject from MCU page.
 * Code Updated: 13 July 2023
 */
public class RejectFinalRequest
{
    public string rejectReason { get; set; }

    public int crewID { get; set; }
}

public class PersonalDataDerivedColumnResponse
{
    public string Age { get; set; }

    public string BMI { get; set; }

    public int TotalSeaExperience { get; set; }

    public dynamic[] SeaExperiences { get; set; }
}

public class InviteCrewRequest
{
    public string inviteDateTime { get; set; }

    public string notes { get; set; }

    public int crewID { get; set; }
}

public class AddNotificationForAdminRequest
{
    public string subject { get; set; }

    public string body { get; set; }

    public string crewID { get; set; }
}

public class ApproveChecklistRequest
{
    public string password { get; set; }

    public string userLevel { get; set; }

    public int checklistID { get; set; }
}

public class SeafarerInputRequest
{
    public string seafarerID { get; set; }

    public int manningAgentID { get; set; }

    public int crewID { get; set; }
}

public class AcceptByAgencyRequest
{
    public string crewIDArray { get; set; }
}

// Partial class
public partial class RegistrationController : ApiController
{
    // load MTCrewDocument given crewID
    [HttpGet("crew-document-for-admin")]
    public IActionResult GetCrewDocumentForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            IEnumerable<dynamic> results = QueryBuilder("MTCrewDocument")
                .Where("MTCrewID", crewID)
                .Join("MTDocument", "MTDocument.ID", "MTCrewDocument.MTDocumentID")
                .Join("MTCountry", "MTCountry.ID", "MTCrewDocument.CountryOfIssue_CountryID")
                .Join("MTUser AS CreatedByUser", "CreatedByUser.ID", "MTCrewDocument.CreatedByUserID")
                .Join("MTUser AS LastUpdatedByUser", "LastUpdatedByUser.ID", "MTCrewDocument.LastUpdatedByUserID")
                .Select(
                    "MTCrewDocument.ID",
                    "MTDocument.Type as DocumentType",  
                    "MTCrewDocument.Number",
                    "MTCountry.Name as CountryOfIssue"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewDocument.DateOfIssue, {CustomFormat.DATE_FORMAT}) as DateOfIssue"
                )
                .Select(
                    "MTCrewDocument.PlaceOfIssue"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewDocument.DateValidUntil, {CustomFormat.DATE_FORMAT}) as DateValidUntil"
                )
                .Select(
                    "MTCrewDocument.Image",
                    "CreatedByUser.Email as CreatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewDocument.CreatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as CreatedDateTime"
                )
                .Select(
                    "LastUpdatedByUser.Email as LastUpdatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewDocument.LastUpdatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as LastUpdatedDateTime"
                )
                .Get();
            jsonResponse.success = true;
            jsonResponse.data = results.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load MTCrewDocument given crewID
    [HttpGet("crew-document-for-admin-with-draft-status")]
    public IActionResult GetCrewDocumentForAdminWithDraftStatus([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            IEnumerable<dynamic> results = QueryBuilder("MTCrewDocument")
                .Where("MTCrewID", crewID)
                .Join("MTDocument", "MTDocument.ID", "MTCrewDocument.MTDocumentID")
                .Join("MTCountry", "MTCountry.ID", "MTCrewDocument.CountryOfIssue_CountryID")
                .Join("MTUser AS CreatedByUser", "CreatedByUser.ID", "MTCrewDocument.CreatedByUserID")
                .Join("MTUser AS LastUpdatedByUser", "LastUpdatedByUser.ID", "MTCrewDocument.LastUpdatedByUserID")
                .Select(
                    "MTCrewDocument.ID"
                )
                .SelectRaw(
                    "CASE WHEN MTCrewDocument.IsDraft = 1 THEN 'Draft' ELSE 'Final' END AS IsDraft"
                )
                .Select(
                    "MTDocument.Type as DocumentType",  
                    "MTCrewDocument.Number",
                    "MTCountry.Name as CountryOfIssue"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewDocument.DateOfIssue, {CustomFormat.DATE_FORMAT}) as DateOfIssue"
                )
                .Select(
                    "MTCrewDocument.PlaceOfIssue"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewDocument.DateValidUntil, {CustomFormat.DATE_FORMAT}) as DateValidUntil"
                )
                .Select(
                    "MTCrewDocument.Image",
                    "CreatedByUser.Email as CreatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewDocument.CreatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as CreatedDateTime"
                )
                .Select(
                    "LastUpdatedByUser.Email as LastUpdatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewDocument.LastUpdatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as LastUpdatedDateTime"
                )
                .Get();
            jsonResponse.success = true;
            jsonResponse.data = results.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load documents not yet added for select options in add page
    [HttpGet("crew-document-options-add")]
    public IActionResult CrewDocumentOptionsAdd([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            try
            {
                var notYetAddedDocumentQuery = ExecuteRows(
                    "SELECT " + 
                    "MTDocument.ID, " + 
                    "MTDocument.Type " +  
                    "FROM MTDocument " +
                    "WHERE MTDocument.ID NOT IN (SELECT MTDocumentID FROM MTCrewDocument WHERE MTCrewID = '" + crewID.ToString() + "');"
                );
                jsonResponse.success = true;
                jsonResponse.data = notYetAddedDocumentQuery.ToArray();
                return Json(jsonResponse);
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // load documents not yet added(including currently edited crew document) for select options in edit page
    [HttpGet("crew-document-options-edit")]
    public IActionResult CrewDocumentOptionsEdit([FromQuery] int crewID, [FromQuery] int crewDocumentID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            try
            {
                var notYetAddedDocumentQuery = ExecuteRows(
                    "SELECT " + 
                    "MTDocument.ID, " + 
                    "MTDocument.Type " +  
                    "FROM MTDocument " +
                    "WHERE MTDocument.ID NOT IN (SELECT MTDocumentID FROM MTCrewDocument WHERE MTCrewID = '" + crewID.ToString() + "' AND ID != '" + crewDocumentID.ToString() + "');"
                );
                jsonResponse.success = true;
                jsonResponse.data = notYetAddedDocumentQuery.ToArray();
                return Json(jsonResponse);
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // get bpjs number from MTCrew
    [HttpGet("get-bpjs-number")]
    public IActionResult GetBPJSNumber([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = "";
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                .Where("ID", crewID)
                .Select("MTUserID")
                .Select("NSSF_Health_Number")
                .Select("NSSF_Occupation_Number")
                .FirstOrDefault();
            if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
            {
                if (CurrentUserLevel() == "0" && crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                    return Json(jsonResponse);
                }
                string bpjsKesehatanNumber = (crewUserIDQuery.NSSF_Health_Number != null) ? crewUserIDQuery.NSSF_Health_Number : "";
                string bpjsKetenagakerjaanNumber = (crewUserIDQuery.NSSF_Occupation_Number != null) ? crewUserIDQuery.NSSF_Occupation_Number : "";
                jsonResponse.success = true;
                jsonResponse.data = new { bpjsKesehatanNumber = bpjsKesehatanNumber, bpjsKetenagakerjaanNumber = bpjsKetenagakerjaanNumber };
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load MTCrewFamily given crewID
    [HttpGet("crew-family-for-admin")]
    public IActionResult GetCrewFamilyForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            IEnumerable<dynamic> results = QueryBuilder("MTCrewFamily")
                .Where("MTCrewID", crewID)
                .Join("MTCountry", "MTCountry.ID", "MTCrewFamily.MobileNumberCode_CountryID")
                .Join("MTUser AS CreatedByUser", "CreatedByUser.ID", "MTCrewFamily.CreatedByUserID")
                .Join("MTUser AS LastUpdatedByUser", "LastUpdatedByUser.ID", "MTCrewFamily.LastUpdatedByUserID")
                .Select(
                    "MTCrewFamily.ID",
                    "MTCrewFamily.Relationship",
                    "MTCrewFamily.FullName"
                )
                .SelectRaw( 
                    "CASE WHEN MTCrewFamily.Gender = 'F' THEN 'Female' WHEN MTCrewFamily.Gender = 'M' THEN 'Male' ELSE MTCrewFamily.Gender END AS Gender"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewFamily.DateOfBirth, {CustomFormat.DATE_FORMAT}) as DateOfBirth"
                )
                .SelectRaw(
                    "CONCAT('(', MTCountry.CallingCode, ')', MTCrewFamily.MobileNumber) AS MobileNumber"
                )
                .Select(
                    "MTCrewFamily.Email",
                    "MTCrewFamily.SocialSecurityNumber",
                    "MTCrewFamily.FamilyRegisterNumber",
                    "MTCrewFamily.Address"
                )
                .Select(
                    "CreatedByUser.Email as CreatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewFamily.CreatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as CreatedDateTime"
                )
                .Select(
                    "LastUpdatedByUser.Email as LastUpdatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewFamily.LastUpdatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as LastUpdatedDateTime"
                )
                .Get();
            if (CurrentLanguage == "id-ID")
            {
                var engToIndCaption = new Dictionary<string, string>
                {
                    { "Male", "Pria" },
                    { "Female", "Wanita" }
                };
                foreach (dynamic result in results)
                {
                    result.Gender = engToIndCaption[result.Gender];
                }
            }
            jsonResponse.success = true;
            jsonResponse.data = results.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load MTCrewCertificate given crewID
    [HttpGet("crew-certificate-for-admin")]
    public IActionResult GetCrewCertificateForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            var crewCertificateQuery = ExecuteRows(
                "SELECT " + 
                "MTCrewCertificate.ID, " + 
                "MTCertificate.Name as CertificateName, " + 
                "MTCrewCertificate.PaxVesselType, " + 
                "CASE WHEN MTCrewCertificate.Level = '1' THEN '1 : Incharge' WHEN MTCrewCertificate.Level = '2' THEN '2 : Asst.' ELSE MTCrewCertificate.Level END AS Level, " + 
                "MTCountry.Name as CountryOfIssue, " + 
                "MTCrewCertificate.Number, " + 
                "FORMAT(MTCrewCertificate.DateOfIssue, 'dd MMM yyyy') as DateOfIssue, " + 
                "FORMAT(MTCrewCertificate.DateOfExpiry, 'dd MMM yyyy') as DateOfExpiry, " + 
                "MTCrewCertificate.PlaceOfIssue, " + 
                "MTCrewCertificate.IssuingAuthority, " + 
                "MTCrewCertificate.Image, " + 
                "CreatedByUser.Email as CreatedBy, " + 
                "FORMAT(MTCrewCertificate.CreatedDateTime, 'dd MMM yyyy HH:mm:sszzz') as CreatedDateTime, " + 
                "LastUpdatedByUser.Email as LastUpdatedBy, " + 
                "FORMAT(MTCrewCertificate.LastUpdatedDateTime, 'dd MMM yyyy HH:mm:sszzz') as LastUpdatedDateTime " + 
                "FROM MTCrewCertificate " +
                "LEFT JOIN MTCertificate ON MTCertificate.ID = MTCrewCertificate.MTCertificateID " +
                "LEFT JOIN MTCountry ON MTCountry.ID = MTCrewCertificate.CountryOfIssue_CountryID " +
                "LEFT JOIN MTUser AS CreatedByUser ON CreatedByUser.ID = MTCrewCertificate.CreatedByUserID " +
                "LEFT JOIN MTUser AS LastUpdatedByUser ON LastUpdatedByUser.ID = MTCrewCertificate.LastUpdatedByUserID " +
                "WHERE MTCrewCertificate.MTCrewID = '" + crewID.ToString() + "';"
            );
            jsonResponse.success = true;
            jsonResponse.data = crewCertificateQuery.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load certificates not yet added for select options in add page
    [HttpGet("crew-certificate-options-add")]
    public IActionResult CrewCertificateOptionsAdd([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            try
            {
                var notYetAddedCertificateQuery = ExecuteRows(
                    "SELECT " + 
                    "MTCertificate.ID, " + 
                    "MTCertificate.Name " +  
                    "FROM MTCertificate " +
                    "WHERE MTCertificate.ID NOT IN (SELECT MTCertificateID FROM MTCrewCertificate WHERE MTCrewID = '" + crewID.ToString() + "');"
                );
                jsonResponse.success = true;
                jsonResponse.data = notYetAddedCertificateQuery.ToArray();
                return Json(jsonResponse);
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // load certificates not yet added(including currently edited crew certificate) for select options in edit page
    [HttpGet("crew-certificate-options-edit")]
    public IActionResult CrewCertificateOptionsEdit([FromQuery] int crewID, [FromQuery] int crewCertificateID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            try
            {
                var notYetAddedCertificateQuery = ExecuteRows(
                    "SELECT " + 
                    "MTCertificate.ID, " + 
                    "MTCertificate.Name " +  
                    "FROM MTCertificate " +
                    "WHERE MTCertificate.ID NOT IN (SELECT MTCertificateID FROM MTCrewCertificate WHERE MTCrewID = '" + crewID.ToString() + "' AND ID != '" + crewCertificateID.ToString() + "');"
                );
                jsonResponse.success = true;
                jsonResponse.data = notYetAddedCertificateQuery.ToArray();
                return Json(jsonResponse);
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // load MTCrewExperience given crewID
    [HttpGet("crew-experience-for-admin")]
    public IActionResult GetCrewExperienceForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            IEnumerable<dynamic> results = QueryBuilder("MTCrewExperience")
                .Where("MTCrewID", crewID)
                .WhereRaw("DateFrom >= DATEADD(YEAR, - 10, GETDATE())")
                .Join("MTCountry", "MTCountry.ID", "MTCrewExperience.FlagName_CountryID")
                .Join("MTVesselType", "MTVesselType.ID", "MTCrewExperience.MTVesselTypeID")
                .Join("MTRank", "MTRank.ID", "MTCrewExperience.MTRankID")
                .Join("MTUser AS CreatedByUser", "CreatedByUser.ID", "MTCrewExperience.CreatedByUserID")
                .Join("MTUser AS LastUpdatedByUser", "LastUpdatedByUser.ID", "MTCrewExperience.LastUpdatedByUserID")
                .Select(
                    "MTCrewExperience.ID",
                    "MTCrewExperience.CompanyName",
                    "MTCountry.Name as FlagName",
                    "MTCrewExperience.VesselName"
                )
                .SelectRaw( 
                    "MTVesselType.Abbreviation + ' ' + MTVesselType.Name as VesselType"
                )
                .SelectRaw( 
                    "FORMAT(MTCrewExperience.GRT, 'N0', 'id-ID') AS GRT"
                )
                .SelectRaw( 
                    "FORMAT(MTCrewExperience.DWT, 'N0', 'id-ID') AS DWT"
                )
                .Select(
                    "MTCrewExperience.MainEngine"
                )
                .SelectRaw( 
                    "FORMAT(MTCrewExperience.BHP, 'N0', 'id-ID') AS BHP"
                )
                .Select(
                    "MTRank.Name as Rank"
                )
                .SelectRaw( 
                    $"FORMAT(MTCrewExperience.DateFrom, {CustomFormat.DATE_FORMAT}) as DateFrom"
                )
                .Select(
                    "MTCrewExperience.SignOnPortName"
                )
                .SelectRaw( 
                    $"FORMAT(MTCrewExperience.DateUntil, {CustomFormat.DATE_FORMAT}) as DateUntil"
                )
                .Select(
                    "MTCrewExperience.SignOffPortName",
                    "MTCrewExperience.SignOffReason"
                )
                .SelectRaw(
                    "DATEDIFF(DAY, MTCrewExperience.DateFrom, MTCrewExperience.DateUntil) as Duration"
                )
                .Select(
                    "CreatedByUser.Email as CreatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewExperience.CreatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as CreatedDateTime"
                )
                .Select(
                    "LastUpdatedByUser.Email as LastUpdatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewExperience.LastUpdatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as LastUpdatedDateTime"
                )
                .OrderByDesc("MTCrewExperience.DateFrom")
                .Get();
            jsonResponse.success = true;
            jsonResponse.data = results.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load MTCrewMedicalHistory given crewID
    [HttpGet("crew-medical-history-for-admin")]
    public IActionResult GetCrewMedicalHistoryForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            IEnumerable<dynamic> results = QueryBuilder("MTCrewMedicalHistory")
                .Where("MTCrewID", crewID)
                .Join("MTUser AS CreatedByUser", "CreatedByUser.ID", "MTCrewMedicalHistory.CreatedByUserID")
                .Join("MTUser AS LastUpdatedByUser", "LastUpdatedByUser.ID", "MTCrewMedicalHistory.LastUpdatedByUserID")
                .Select(
                    "MTCrewMedicalHistory.ID",
                    "MTCrewMedicalHistory.Type",
                    "MTCrewMedicalHistory.VesselName"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewMedicalHistory.DateOccurence, {CustomFormat.DATE_FORMAT}) as DateOccurence"
                )
                .Select(
                    "MTCrewMedicalHistory.PlaceOccurence",
                    "MTCrewMedicalHistory.PeriodOfDisability",
                    "MTCrewMedicalHistory.PresentCondition",
                    "MTCrewMedicalHistory.Treatment",
                    "MTCrewMedicalHistory.Details"
                )
                .Select(
                    "CreatedByUser.Email as CreatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewMedicalHistory.CreatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as CreatedDateTime"
                )
                .Select(
                    "LastUpdatedByUser.Email as LastUpdatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewMedicalHistory.LastUpdatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as LastUpdatedDateTime"
                )
                .Get();
            if (CurrentLanguage == "id-ID")
            {
                var engToIndCaption = new Dictionary<string, string>
                {
                    { "None", "Tidak Ada" },
                    { "Has Illness Or Accident Consulted To Doctor", "Memiliki Penyakit / Kecelakaan Yang Dikonsultasikan Ke Dokter" },
                    { "Health Or Disability Problem", "Masalah Kesehatan / Disabilitas" },
                    { "Medical Operation", "Operasi Medis" },
                    { "Signed Off Due To Medical Reasons", "Sign Off Karena Alasan Kesehatan" }
                };
                foreach (dynamic result in results)
                {
                    result.Type = engToIndCaption[result.Type];
                }
            }
            jsonResponse.success = true;
            jsonResponse.data = results.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load opposing gender for use in CrewFamilyForAdmin Page
    [HttpGet("get-opposing-gender-for-admin")]
    public IActionResult GetOpposingGenderForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = "";
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            dynamic crewQuery = QueryBuilder("MTCrew")
                .Where("ID", crewID)
                .Select("Gender")
                .FirstOrDefault();
            if ((object) crewQuery != null)
            {
                jsonResponse.success = true;
                if (crewQuery.Gender == "M") {
                    jsonResponse.data = "F";
                } else if (crewQuery.Gender == "F") {
                    jsonResponse.data = "M";
                }
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // check if a certificate category is D4, G or H to be used in CrewCertificateForAdmin page
    [HttpGet("get-certificate-category-for-admin")]
    public IActionResult GetCertificateCategoryForAdmin([FromQuery] int certificateID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = "";
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            dynamic certificateQuery = QueryBuilder("MTCertificate")
                .Where("ID", certificateID)
                .Select("CategoryName", "Name")
                .FirstOrDefault();
            if ((object) certificateQuery != null)
            {
                jsonResponse.success = true;
                if (certificateQuery.CategoryName != null && certificateQuery.Name != null)
                {
                    if (certificateQuery.CategoryName.Contains("(D)"))
                    {
                        jsonResponse.data = "D";
                    }
                    else if (certificateQuery.CategoryName.Contains("(H)"))
                    {
                        jsonResponse.data = "H";
                    }
                    else if (certificateQuery.CategoryName.Contains("(G)"))
                    {
                        if (certificateQuery.Name.Contains("Endorsement"))
                        {
                            jsonResponse.data = "G Non Page";
                        }
                        else
                        {
                            jsonResponse.data = "G Page";
                        }
                    }
                }
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                    ? "Certificate Not Found"
                    : "Sertifikat Tidak Ditemukan";
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // submit crew registration form
    [HttpPost("submit-form-for-admin")]
    public IActionResult SubmitFormForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new
        {
            IsAlreadySubmitted = false
        };
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }

            // gmandayu: pengecekan apakah calon crew masuk daftar blacklist.
            var tempCrewSeafarerId = QueryBuilder("MTCrew")
                .Where("ID", crewID)
                .Select("IndividualCodeNumber")
                .FirstOrDefault<dynamic>();
            if (tempCrewSeafarerId != null && tempCrewSeafarerId.IndividualCodeNumber != null)
            {
                string seafarerId = tempCrewSeafarerId.IndividualCodeNumber.ToString();
                var rowBlacklistCrew = ExecuteRow($"SELECT KodePelaut, SisaHariHukuman FROM v_LinkedServerBlacklistCrew WHERE KodePelaut = '{seafarerId}'");

                // Jika masuk daftar blacklist.
                if (rowBlacklistCrew != null && rowBlacklistCrew.ContainsKey("KodePelaut") && rowBlacklistCrew["KodePelaut"] != null)
                {
                    string sisaHariHukuman = rowBlacklistCrew["SisaHariHukuman"].ToString();
                    if (!string.IsNullOrEmpty(sisaHariHukuman))
                    {
                        if (sisaHariHukuman == "SELAMANYA" || sisaHariHukuman == ">365" || sisaHariHukuman == "UNDETERMINED")
                        {
                            try
                            {
                                int affectedRows = QueryBuilder("MTCrew")
                                    .Where("ID", crewID)
                                    .Update(new
                                    {
                                        EmployeeStatus = "Candidate - Blacklist",
                                        LastUpdatedByUserID = CurrentUserID(),
                                        LastUpdatedDateTime = DateTimeOffset.Now
                                    });
                                if (affectedRows == 0)
                                {
                                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Data" : "Gagal Mengubah Data Kru";
                                    return Json(jsonResponse);
                                }
                                jsonResponse.data = new
                                {
                                    IsAlreadySubmitted = true
                                };

                                // Update ke tabel MTRecruitmentStatusTracking untuk mencatat tracking status.
                                // 28 Juli 2023
                                affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                                    .Where("MTCrewID", crewID)
                                    .Where("MTRecruitmentStatusID", 118)
                                    .Update(new
                                    {
                                        Flag = 1,
                                        FlagDescription = "Selesai",
                                        LastUpdatedByUserID = CurrentUserID(),
                                        LastUpdatedDateTime = DateTimeOffset.Now,
                                    });
                                affectedRows += QueryBuilder("MTRecruitmentStatusTracking")
                                    .Where("MTCrewID", crewID)
                                    .WhereNotIn("MTRecruitmentStatusID", new[] { 118 })
                                    .Update(new
                                    {
                                        Flag = 3,
                                        FlagDescription = "Dibatalkan",
                                        LastUpdatedByUserID = CurrentUserID(),
                                        LastUpdatedDateTime = DateTimeOffset.Now,
                                    });
                                if (affectedRows == 0)
                                {
                                    throw new Exception((CurrentLanguage == "en-US")
                                        ? "Failed to Update Crew Tracking Status"
                                        : "Gagal Mengubah Data Pelacakan Status Kru");
                                }
                                // gmandayu: code ends here.

                                // Insert ke tabel TREmployeeStatus untuk mencatat perubahan status
                                affectedRows = QueryBuilder("TREmployeeStatus").Insert(new
                                {
                                    MTCrewID = crewID,
                                    MTUserID = CurrentUserID(),
                                    PreviousStatus = "Candidate - Draft",
                                    CurrentStatus = "Candidate - Blacklist",
                                    ChangedDateTime = DateTimeOffset.Now
                                });
                                if (affectedRows == 0)
                                {
                                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                                    return Json(jsonResponse);
                                }

                                // Disini akan menampilkan toast warning "Anda terblacklist"
                                return Json(
                                    new 
                                    {
                                        success = true,
                                        crewStatus = "Candidate - Blacklist",
                                        isBlacklisted = true
                                    });

                                // jsonResponse.success = true;
                                // return Json(jsonResponse);
                            }
                            catch (Exception ex)
                            {
                                jsonResponse.errorMessage = ex.Message;
                                return Json(jsonResponse);
                            }
                        }
                        else 
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew can be submitted" : "Kru bisa submit";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Sisa Hari Hukuman not found!" : "Sisa Hari Hukuman tidak ditemukan!";
                        return Json(jsonResponse);
                    }
                }
                // Jika tidak masuk daftar blacklist, crew submitted.
                else
                {
                    string[] crewMandatoryColumns = {
                    "RequiredPhoto",
                    "VisaPhoto",
                    "IndividualCodeNumber",
                    "Email",
                    "MobileNumber",
                    "FullName",
                    "DateOfBirth",
                    "CountryOfOrigin_CountryID",
                    "CityOfBirth",
                    "Nationality_CountryID",
                    "Gender",
                    "MaritalStatus",
                    "ReligionID",
                    "BloodType",
                    "PrimaryAddressDetail",
                    "PrimaryAddressCity",
                    "PrimaryAddressPostCode",
                    "PrimaryAddressCountryID",
                    "PrimaryAddressState",
                    "PrimaryAddressHomeTel",
                    "PrimaryAddressNearestAirport",
                    "RankAppliedFor_RankID",
                    "AvailableFrom",
                    "AvailableUntil",
                    "Weight",
                    "Height",
                    "CoverallSize",
                    "SafetyShoesSize",
                    "ShirtSize",
                    "TrousersSize",
                    "NomineeFullName",
                    "NomineeRelationship",
                    "NomineeGender",
                    "NomineeNationality_CountryID",
                    "NomineeAddressCity",
                    "NomineeAddressPostCode",
                    "NomineeAddressCountryID",
                    "NomineeEmail",
                    "NomineeAddressHomeTel",
                    "NomineeMobileNumber",
                    "NomineeAddressDetail",
                    "SocialSecurityNumber",
                    "SocialSecurityIssuingCountryID",
                    "SocialSecurityImage"
                    };
                    string crewSelectClause = string.Join(", ", crewMandatoryColumns);
                    var crewQueryResult = QueryBuilder("MTCrew")
                        .Where("ID", crewID)
                        .SelectRaw(crewSelectClause).FirstOrDefault();
                    if ((object)crewQueryResult != null)
                    {
                        crewPersonalDataForAdminEdit = new GLOBALS.CrewPersonalDataForAdminEdit(this);

                        // PERSONAL DATA
                        if (crewQueryResult.RequiredPhoto == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.RequiredPhoto.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.RequiredPhoto.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.VisaPhoto == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.VisaPhoto.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.VisaPhoto.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.IndividualCodeNumber == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.IndividualCodeNumber.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.IndividualCodeNumber.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.Email == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit._Email.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit._Email.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.MobileNumber == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.MobileNumber.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.MobileNumber.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.FullName == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.FullName.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.FullName.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.DateOfBirth == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.DateOfBirth.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.DateOfBirth.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.CountryOfOrigin_CountryID == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.CountryOfOrigin_CountryID.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.CountryOfOrigin_CountryID.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.CityOfBirth == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.CityOfBirth.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.CityOfBirth.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.Nationality_CountryID == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.Nationality_CountryID.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.Nationality_CountryID.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.Gender == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.Gender.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.Gender.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.MaritalStatus == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.MaritalStatus.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.MaritalStatus.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.ReligionID == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.ReligionID.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.ReligionID.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.BloodType == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.BloodType.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.BloodType.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.PrimaryAddressDetail == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - 1. Permanent/Primary Address - {crewPersonalDataForAdminEdit.PrimaryAddressDetail.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - 1. Alamat Permanen/Utama: {crewPersonalDataForAdminEdit.PrimaryAddressDetail.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.PrimaryAddressCity == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - 1. Permanent/Primary Address: {crewPersonalDataForAdminEdit.PrimaryAddressCity.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - 1. Alamat Permanen/Utama: {crewPersonalDataForAdminEdit.PrimaryAddressCity.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.PrimaryAddressPostCode == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - 1. Permanent/Primary Address: {crewPersonalDataForAdminEdit.PrimaryAddressPostCode.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - 1. Alamat Permanen/Utama: {crewPersonalDataForAdminEdit.PrimaryAddressPostCode.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.PrimaryAddressCountryID == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - 1. Permanent/Primary Address: {crewPersonalDataForAdminEdit.PrimaryAddressCountryID.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - 1. Alamat Permanen/Utama: {crewPersonalDataForAdminEdit.PrimaryAddressCountryID.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.PrimaryAddressState == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - 1. Permanent/Primary Address: {crewPersonalDataForAdminEdit.PrimaryAddressState.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - 1. Alamat Permanen/Utama: {crewPersonalDataForAdminEdit.PrimaryAddressState.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.PrimaryAddressHomeTel == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - 1. Permanent/Primary Address: {crewPersonalDataForAdminEdit.PrimaryAddressHomeTel.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - 1. Alamat Permanen/Utama: {crewPersonalDataForAdminEdit.PrimaryAddressHomeTel.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.PrimaryAddressNearestAirport == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - 1. Permanent/Primary Address: {crewPersonalDataForAdminEdit.PrimaryAddressNearestAirport.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - 1. Alamat Permanen/Utama: {crewPersonalDataForAdminEdit.PrimaryAddressNearestAirport.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.RankAppliedFor_RankID == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.RankAppliedFor_RankID.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.RankAppliedFor_RankID.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.AvailableFrom == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.AvailableFrom.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.AvailableFrom.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.AvailableUntil == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.AvailableUntil.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.AvailableUntil.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.Weight == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.Weight.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.Weight.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.Height == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.Height.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.Height.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.CoverallSize == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.CoverallSize.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.CoverallSize.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.SafetyShoesSize == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.SafetyShoesSize.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.SafetyShoesSize.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.ShirtSize == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.ShirtSize.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.ShirtSize.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.TrousersSize == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.TrousersSize.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.TrousersSize.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeFullName == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeFullName.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeFullName.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeRelationship == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeRelationship.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeRelationship.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeGender == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeGender.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeGender.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeNationality_CountryID == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeNationality_CountryID.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeNationality_CountryID.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeAddressCity == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeAddressCity.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeAddressCity.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeAddressPostCode == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeAddressPostCode.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeAddressPostCode.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeAddressCountryID == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeAddressCountryID.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeAddressCountryID.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeEmail == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeEmail.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeEmail.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeAddressHomeTel == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeAddressHomeTel.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeAddressHomeTel.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeMobileNumber == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeMobileNumber.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeMobileNumber.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.NomineeAddressDetail == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - {crewPersonalDataForAdminEdit.NomineeAddressDetail.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - {crewPersonalDataForAdminEdit.NomineeAddressDetail.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.SocialSecurityNumber == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - Social Security: {crewPersonalDataForAdminEdit.SocialSecurityNumber.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - KTP: {crewPersonalDataForAdminEdit.SocialSecurityNumber.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.SocialSecurityIssuingCountryID == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - Social Security: {crewPersonalDataForAdminEdit.SocialSecurityIssuingCountryID.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - KTP: {crewPersonalDataForAdminEdit.SocialSecurityIssuingCountryID.Caption}";
                            return Json(jsonResponse);
                        }
                        if (crewQueryResult.SocialSecurityImage == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? $"Error PERSONAL DATA: Please enter required field - Social Security: {crewPersonalDataForAdminEdit.SocialSecurityImage.Caption}"
                                : $"Error DATA PERSONAL: Masukkan input yang dibutuhkan - KTP: {crewPersonalDataForAdminEdit.SocialSecurityImage.Caption}";
                            return Json(jsonResponse);
                        }

                        // DOCUMENTS
                        IEnumerable<dynamic> crewDocuments = QueryBuilder("MTCrewDocument")
                            .Where("MTCrewID", crewID)
                            .Join("MTDocument", "MTDocument.ID", "MTCrewDocument.MTDocumentID")
                            .Select(
                                "MTDocument.Type as DocumentType"
                            )
                            .Get();
                        if (crewDocuments.Count() == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? "Error DOCUMENTS: Documents cannot be empty"
                                : "Error DOKUMEN: Dokumen tidak boleh kosong";
                            return Json(jsonResponse);
                        }
                        Dictionary<string, bool> documentTypesDict = new Dictionary<string, bool> {
                            {"Seaman's Book", false},
                            {"Passport", false},
                            {"Family Register (KK)", false}
                        };
                        foreach (dynamic crewDocument in crewDocuments)
                        {
                            string documentType = (string)crewDocument.DocumentType;
                            if (documentTypesDict.ContainsKey(documentType))
                            {
                                documentTypesDict[documentType] = true;
                            }
                        }
                        foreach (KeyValuePair<string, bool> documentTypeKeyValue in documentTypesDict)
                        {
                            if (!documentTypeKeyValue.Value)
                            {
                                var documentType = documentTypeKeyValue.Key;
                                jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                    ? $"Error DOCUMENTS: Document with type {documentType} must be submitted"
                                    : $"Error DOKUMEN: Dokumen dengan tipe {documentType} harus disubmit";
                                return Json(jsonResponse);
                            }
                        }

                        // CERTIFICATES AND QUALIFICATIONS
                        int rankIDAppliedFor = crewQueryResult.RankAppliedFor_RankID;
                        IEnumerable<dynamic> certificateOnRankQuery = QueryBuilder("MTCertificateOnRank")
                            .Where("MTRankID", rankIDAppliedFor)
                            .Select("MTCertificateID")
                            .Get();
                        if (certificateOnRankQuery.Any())
                        {
                            IEnumerable<dynamic> crewCertificateQuery = QueryBuilder("MTCrewCertificate")
                                .Where("MTCrewID", crewID)
                                .WhereRaw("Number IS NOT NULL")
                                .Select("MTCertificateID")
                                .Get();
                            dynamic firstMissingMandatoryCertificateID = certificateOnRankQuery
                                .Select(c => c.MTCertificateID)
                                .Except(crewCertificateQuery.Select(cc => cc.MTCertificateID))
                                .FirstOrDefault();
                            if (firstMissingMandatoryCertificateID != null)
                            {
                                int firstMissingMandatoryCertificateIDInt = firstMissingMandatoryCertificateID;
                                object certificateNameObject = ExecuteScalar("SELECT Name FROM MTCertificate WHERE ID = @FirstMissingMandatoryCertificateID;", new { FirstMissingMandatoryCertificateID = firstMissingMandatoryCertificateIDInt });
                                if (certificateNameObject != null)
                                {
                                    string firstMissingMandatoryCertificateName = certificateNameObject.ToString();
                                    jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                        ? $"Error CERTIFICATES AND QUALIFICATIONS: Certificate with name {firstMissingMandatoryCertificateName} must be filled and submitted"
                                        : $"Error SERTIFIKAT DAN KUALIFIKASI: Sertifikat dengan nama {firstMissingMandatoryCertificateName} harus diisi dan disubmit";
                                    return Json(jsonResponse);
                                }
                            }
                        }

                        // MEDICAL HISTORY
                        IEnumerable<dynamic> crewMedicalHistory = QueryBuilder("MTCrewMedicalHistory")
                            .Where("MTCrewID", crewID)
                            .Select(
                                "MTCrewMedicalHistory.ID"
                            )
                            .Get();
                        if (crewMedicalHistory.Count() == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                ? "Error MEDICAL HISTORY: Medical history cannot be empty"
                                : "Error RIWAYAT MEDIS: Riwayat medis tidak boleh kosong";
                            return Json(jsonResponse);
                        }

                        // form is valid
                        try
                        {
                            // !TODO: Code untuk tetap mempertahankan status Candidate - Accepted
                            dynamic currentEmployeeStatus = QueryBuilder("MTCrew")
                                .Where("ID", crewID)
                                .Select("EmployeeStatus")
                                .FirstOrDefault();
                            if ((object)currentEmployeeStatus != null && (object)currentEmployeeStatus.EmployeeStatus != null) 
                            {
                                string empStatus = currentEmployeeStatus.EmployeeStatus.ToString();
                                // Jika sekarang candidate merupakan "Candidate Draft"
                                if (empStatus == "Candidate - Draft")
                                {
                                    int affectedRows = QueryBuilder("MTCrew").Where("ID", crewID).Update(new
                                    {
                                        EmployeeStatus = "Candidate - Submitted",
                                        FormSubmittedDateTime = DateTimeOffset.Now,
                                        LastUpdatedByUserID = CurrentUserID(),
                                        LastUpdatedDateTime = DateTimeOffset.Now,
                                    });
                                    if (affectedRows == 0)
                                    {
                                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Data" : "Gagal Mengubah Data Kru";
                                        return Json(jsonResponse);
                                    }
                                    jsonResponse.data = new
                                    {
                                        IsAlreadySubmitted = true
                                    };

                                    // gmandayu: Update ke tabel MTRecruitmentStatusTracking
                                    var mtRecruitmentStatusId = QueryBuilder("MTRecruitmentStatus")
                                        .Where("Description", "Candidate - Submitted")
                                        .Select("ID")
                                        .FirstOrDefault();
                                    affectedRows += QueryBuilder("MTRecruitmentStatusTracking")
                                        .Where("MTCrewID", crewID)
                                        .Where("MTRecruitmentStatusID", 101) // Submitted
                                        .Update(new
                                        {
                                            Flag = 1,
                                            FlagDescription = "Selesai",
                                            LastUpdatedByUserID = CurrentUserID(),
                                            LastUpdatedDateTime = DateTimeOffset.Now,
                                        });
                                    affectedRows += QueryBuilder("MTRecruitmentStatusTracking")
                                        .Where("MTCrewID", crewID)
                                        .Where("MTRecruitmentStatusID", 118) // Blacklist
                                        .Update(new
                                        {
                                            Flag = 3,
                                            FlagDescription = "Dibatalkan",
                                            LastUpdatedByUserID = CurrentUserID(),
                                            LastUpdatedDateTime = DateTimeOffset.Now,
                                        });
                                    if (affectedRows == 0)
                                    {
                                        jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                            ? "Failed to Update Crew Tracking Status"
                                            : "Gagal Mengubah Data Pelacakan Status Kru";
                                        return Json(jsonResponse);
                                    }

                                    // gmandayu: code ends here
                                    affectedRows = QueryBuilder("TREmployeeStatus").Insert(new
                                    {
                                        MTCrewID = crewID,
                                        MTUserID = CurrentUserID(),
                                        PreviousStatus = "Candidate - Draft",
                                        CurrentStatus = "Candidate - Submitted",
                                        ChangedDateTime = DateTimeOffset.Now,
                                    });
                                    if (affectedRows == 0)
                                    {
                                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                                        return Json(jsonResponse);
                                    }
                                    string subject = "Submit Form Successful";
                                    string body = "Your form is successfully submitted. Please wait for further announcement.";
                                    var row = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewID.ToString() + "'");
                                    if (row.ContainsKey("MTUserID") && row["MTUserID"] != null)
                                    {
                                        var userID = Convert.ToInt32(row["MTUserID"]);
                                        affectedRows = QueryBuilder("TRNotification").Insert(new
                                        {
                                            MTUserID = userID,
                                            Subject = subject,
                                            Body = body,
                                            CreatedByUserID = CurrentUserID(),
                                            CreatedDateTime = DateTimeOffset.Now,
                                            LastUpdatedByUserID = CurrentUserID(),
                                            LastUpdatedDateTime = DateTimeOffset.Now,
                                        });
                                        if (affectedRows == 0)
                                        {
                                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Create Submit Notification" : "Gagal Membuat Notifikasi Submit";
                                            return Json(jsonResponse);
                                        }
                                    }
                                    else
                                    {
                                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                                        return Json(jsonResponse);
                                    }

                                    // send email start
                                    var emailTemplateCategory = "Crew Form 560 Submitted Succesfully";
                                    var crewInfo = ExecuteRow("SELECT MTCrew.Email, MTCrew.FullName, MTRank.Name AS RankAppliedFor FROM MTCrew INNER JOIN MTRank ON MTCrew.RankAppliedFor_RankID = MTRank.ID WHERE MTCrew.ID = '" + crewID.ToString() + "'");
                                    if (crewInfo["Email"] == null || crewInfo["FullName"] == null || crewInfo["RankAppliedFor"] == null)
                                    {
                                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew email, full name, and rank applied for cannot be empty" : "Email, nama lengkap, dan rank yang akan dipilih crew tidak boleh kosong";
                                        return Json(jsonResponse);
                                    }
                                    var email = new Email();
                                    email.Sender = Config.SenderEmail;
                                    email.Recipient = crewInfo["Email"].ToString();
                                    var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
                                    if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
                                    {
                                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email template not found or the subject and message column is empty" : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
                                        return Json(jsonResponse);
                                    }
                                    email.Subject = emailTemplate["Subject"].ToString();
                                    email.Content = emailTemplate["Message"].ToString();
                                    email.ReplaceContent("{{crewCandidateFullName}}", crewInfo["FullName"].ToString());
                                    email.ReplaceContent("{{rankAppliedFor}}", crewInfo["RankAppliedFor"].ToString());
                                    if (Email.Mailer == null)
                                    {
                                        var smtpClient = new SmtpClient();
                                        smtpClient.CheckCertificateRevocation = false;
                                        Email.Mailer = smtpClient;
                                    }
                                    else if (Email.Mailer.CheckCertificateRevocation)
                                    {
                                        Email.Mailer.CheckCertificateRevocation = false;
                                    }
                                    bool isEmailSent = false;
                                    Task.Run(async () =>
                                    {
                                        isEmailSent = await email.SendAsync();
                                    }).GetAwaiter().GetResult();
                                    if (isEmailSent)
                                    {
                                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                                        {
                                            MTCrew_ID = crewID,
                                            Subject = email.Subject,
                                            Message = email.Content,
                                            To = email.Recipient,
                                            IsSent = 1,
                                            SentDateTime = DateTimeOffset.Now
                                        });
                                        if (affectedRows == 0)
                                        {
                                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                                            return Json(jsonResponse);
                                        }
                                    }
                                    else
                                    {
                                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                                        {
                                            MTCrew_ID = crewID,
                                            Subject = email.Subject,
                                            Message = email.Content,
                                            To = email.Recipient,
                                            IsSent = 0,
                                            SentDateTime = DateTimeOffset.Now
                                        });
                                        if (affectedRows == 0)
                                        {
                                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                                            return Json(jsonResponse);
                                        }
                                        jsonResponse.errorMessage = email.SendError;
                                        return Json(jsonResponse);
                                    }
                                    // send email end
                                    jsonResponse.success = true;
                                    return Json(jsonResponse);
                                }
                                // Jika sekarang candidate merupakan selain "Candidate Draft"
                                else
                                {
                                    int affectedRows = QueryBuilder("MTCrew")
                                        .Where("ID", crewID)
                                        .Update(new
                                        {
                                            EmployeeStatus = empStatus + " - Waiting for PDE Review", // currentEmployeeStatus or "Candidate - Accepted - Waiting For PDE Review "
                                            FormSubmittedDateTime = DateTimeOffset.Now,
                                            LastUpdatedByUserID = CurrentUserID(),
                                            LastUpdatedDateTime = DateTimeOffset.Now,
                                        });
                                    if (affectedRows == 0)
                                    {
                                        jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                                            ? "Failed to Update Crew Data"
                                            : "Gagal Mengubah Data Kru";
                                        return Json(jsonResponse);
                                    }

                                    // Proses lain disini
                                    // INSERT TREmployeeStatus
                                    affectedRows += QueryBuilder("TREmployeeStatus").Insert(new
                                    {
                                        MTCrewID = crewID, 
                                        MTUserID = CurrentUserID(),
                                        PreviousStatus = empStatus,
                                        CurrentStatus = empStatus + " - Waiting for PDE Review", 
                                        ChangedDateTime = DateTimeOffset.Now,
                                    });
                                    if (affectedRows == 0) 
                                    {
                                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") 
                                            ? "Failed to Update Crew Employee Status History" 
                                            : "Gagal Mengubah Data Histori Status Karyawan Kru";
                                        return Json(jsonResponse);
                                    }

                                    // INSERT TRNotification
                                    string subject = "Update personal data successful";

                                    // Jangan diubah
                                    jsonResponse.data = new
                                    {
                                        IsAlreadySubmitted = true
                                    };
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            jsonResponse.errorMessage = ex.Message;
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                        return Json(jsonResponse);
                    }
                    // jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "tempCrewBlacklist is null" : "tempCrewBlacklist kosong";
                    return Json(jsonResponse);
                }
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew not found!" : "Crew tidak ditemukan!";
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    [HttpPost("add-mcu-result")]
    public IActionResult AddMCUResult([FromBody] RequestData requestData)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            string mcuDate = requestData.mcuDateTimeRequest.mcuDate;
            string expiredDate = requestData.expiredDateRequest.expiredDate;
            string healthStatus = requestData.healthStatusRequest.healthStatus;
            string mcuLocation = requestData.mcuLocationRequest.mcuLocation;
            string mcuFileUpload = requestData.uploadFileRequest.uploadFile;
            IEnumerable<dynamic> deserializedCrewIDArray = (IEnumerable<dynamic>)JsonConvert.DeserializeObject(requestData.mcuDateTimeRequest.crewIDArray);
            try
            {
                foreach (dynamic crewIDDynamic in deserializedCrewIDArray)
                {
                    string crewID = crewIDDynamic.ToString();
                    int affectedRows = Execute(
                        "UPDATE MTCrew " +
                        "SET EmployeeStatus = 'Candidate - MCU', " +
                        "LastUpdatedByUserID = @LastUpdatedByUserID, " +
                        "LastUpdatedDateTime = @LastUpdatedDateTime " +
                        "WHERE ID = @CrewID;",
                        new
                        {
                            // MCUDate = mcuDate,
                            // ExpiredDate = expiredDate,
                            // HealthStatus = healthStatus,
                            // McuLocation = mcuLocation,
                            // McuFileUpload = mcuFileUpload,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                            CrewID = crewID
                        }
                    );
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengupdate Sejarah Status Karyawan Kru";
                        return Json(jsonResponse);
                    }
                    affectedRows = QueryBuilder("TRMCUResult").Insert(new
                    {
                        MTCrewID = crewID,
                        // MTUserID = CurrentUserID(),
                        // McuResult_ID = // Assign the value for McuResult_ID
                        McuDate = mcuDate,
                        McuExpirationDate = expiredDate, // Assign the value for McuExpirationDate
                        HealthStatus = healthStatus, // Assign the value for HealthStatus
                        McuLocation = mcuLocation, // Assign the value for McuLocation (// pre-record)
                        McuAttachment = mcuFileUpload, // Assign the value for McuAttachment
                        CreatedByUserID = CurrentUserID(),
                        CreatedDateTime = DateTimeOffset.Now,
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now
                    });

                    // gmandayu: Update ke tabel MTRecruitmentStatusTracking
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                            .Where("MTCrewID", crewID)
                            .Where("MTRecruitmentStatusID", 114)
                            .Update(new
                            {
                                Flag = 1,
                                FlagDescription = "Selesai",
                                LastUpdatedByUserID = CurrentUserID(),
                                LastUpdatedDateTime = DateTimeOffset.Now,
                            });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Tracking Status" : "Gagal Mengubah Data Pelacakan Status Kru";
                        return Json(jsonResponse);
                    }
                    // gmandayu: code ends here
                    affectedRows = QueryBuilder("TREmployeeStatus").Insert(new
                    {
                        MTCrewID = crewID,
                        MTUserID = CurrentUserID(),
                        PreviousStatus = "Candidate - Interviewed",
                        CurrentStatus = "Candidate - MCU",
                        ChangedDateTime = DateTimeOffset.Now,
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                        return Json(jsonResponse);
                    }
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Create Crew Medical Checkup!" : "Gagal Membuat Dokumen Pemeriksaan Medis Kru!";
                        return Json(jsonResponse);
                    }
                }
                jsonResponse.success = true;
                return Json(jsonResponse);

                // Send Email
                // SendNotificationEmail();
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // save document check date time to database
    [HttpPost("add-document-check-date-time")]
    public IActionResult AddDocumentCheckDateTime([FromBody] DocumentCheckDateTimeRequest documentCheckDateTimeRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn())
        {
            string scheduleDateTime = documentCheckDateTimeRequest.scheduleDateTime;
            string notes = documentCheckDateTimeRequest.notes;
            IEnumerable<dynamic> deserializedCrewIDArray = (IEnumerable<dynamic>) JsonConvert.DeserializeObject(documentCheckDateTimeRequest.crewIDArray);
            CultureInfo enCI = new CultureInfo("en-US", false);
            CultureInfo idCI = new CultureInfo("id-ID", false);
            DateTimeOffset dateTimeOffset;
            var currentCI = (CurrentLanguage == "en-US") ? enCI : idCI;
            if (!DateTimeOffset.TryParseExact(scheduleDateTime, "dd MMM yyyy HH:mm:sszzz", currentCI, DateTimeStyles.None, out dateTimeOffset))
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Date time must be in format dd MMM yyyy HH:mm:sszzz" : "Tanggal dan jam harus dalam format dd MMM yyyy HH:mm:sszzz";
                return Json(jsonResponse);
            }
            string date = dateTimeOffset.ToString("dddd, dd MMMM yyyy", idCI);
            string time = dateTimeOffset.ToString("HH.mm", idCI);
            try
            {
                foreach (dynamic crewIDDynamic in deserializedCrewIDArray)
                {
                    string crewID = crewIDDynamic.ToString();
                    string subject = "Checklist Invitation";
                    string body = "Please come on " + date + ", " + time + " at: "+
                        "<br>Patra Jasa Office Tower Lantai 22 Wing 3, Jl. Jend Gatot Subroto Kav. 32-34 Jaksel "+
                        "<br>for the checklist process.";
                    if (notes != "")
                    {
                        body += "<br>Notes: " + notes;
                    }
                    int affectedRows = 0;
                    var row = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewID + "'");
                    if (row.ContainsKey("MTUserID") && row["MTUserID"] != null)
                    {
                        var userID = Convert.ToInt32(row["MTUserID"]);
                        affectedRows = QueryBuilder("TRNotification").Insert(new {
                            MTUserID = userID,
                            Subject = subject,
                            Body = body,
                            CreatedByUserID = CurrentUserID(),
                            CreatedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add Document Check Date Time" : "Gagal Menambahkan Tanggal Dan Jam Pengecekan Dokumen";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                        return Json(jsonResponse);
                    }
                    affectedRows = Execute(
                        "UPDATE MTCrew " +
                        "SET EmployeeStatus = 'Candidate - PDE Reviewed', " +
                        "    LastUpdatedByUserID = @LastUpdatedByUserID, " +
                        "    LastUpdatedDateTime = @LastUpdatedDateTime "+
                        "WHERE ID = @CrewID;",
                        new
                        {
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                            CrewID = crewID
                        }
                    );
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add Document Check Date Time" : "Gagal Menambahkan Tanggal Dan Jam Pengecekan Dokumen";
                        return Json(jsonResponse);
                    }
                    // gmandayu: Update ke tabel MTRecruitmentStatusTracking
                    // 28 Juli 2023
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewID)
                        .WhereIn("MTRecruitmentStatusID", new[] { 102, 103 })
                        .Update(new
                        {
                            Flag = 1,
                            FlagDescription = "Selesai",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") 
                            ? "Failed to Update Crew Tracking Status"
                            : "Gagal Mengubah Data Pelacakan Status Kru";
                        return Json(jsonResponse);
                    }

                    // gmandayu: code ends here
                    affectedRows = QueryBuilder("TREmployeeStatus").Insert(new {
                        MTCrewID = crewID,
                        MTUserID = CurrentUserID(),
                        PreviousStatus = "Candidate - Submitted",
                        CurrentStatus = "Candidate - PDE Reviewed",
                        ChangedDateTime = DateTimeOffset.Now,
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                        return Json(jsonResponse);
                    }
                    affectedRows = QueryBuilder("TRChecklist").Insert(new {
                        MTCrewID = crewID,
                        Activity10 = true,
                        CreatedByUserID = CurrentUserID(),
                        CreatedDateTime = DateTimeOffset.Now,
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Create Crew Checklist" : "Gagal Membuat Daftar Seleksi Kru";
                        return Json(jsonResponse);
                    }

                    // send email start
                    var emailTemplateCategory = "Crew Checklist";
                    var crewInfo = ExecuteRow("SELECT MTCrew.Email, MTCrew.FullName FROM MTCrew WHERE MTCrew.ID = '" + crewID + "'");
                    if (crewInfo["Email"] == null || crewInfo["FullName"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew email, full name cannot be empty" : "Email, nama lengkap crew tidak boleh kosong";
                        return Json(jsonResponse);
                    }
                    var email = new Email();
                    email.Sender = Config.SenderEmail;
                    email.Recipient = crewInfo["Email"].ToString();
                    var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
                    if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email template not found or the subject and message column is empty" : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
                        return Json(jsonResponse);
                    }
                    email.Subject = emailTemplate["Subject"].ToString();
                    email.Content = emailTemplate["Message"].ToString();
                    email.ReplaceContent("{{crew_fullname}}", crewInfo["FullName"].ToString());
                    email.ReplaceContent("{{date}}", date);
                    email.ReplaceContent("{{time}}", "Pukul " + time + " s/d Selesai");
                    if (Email.Mailer == null)
                    {
                        var smtpClient = new SmtpClient();
                        smtpClient.CheckCertificateRevocation = false;
                        Email.Mailer = smtpClient;
                    }
                    else if (Email.Mailer.CheckCertificateRevocation)
                    {
                        Email.Mailer.CheckCertificateRevocation = false;
                    }
                    bool isEmailSent = false;
                    Task.Run(async () =>
                    {
                        isEmailSent = await email.SendAsync();
                    }).GetAwaiter().GetResult();
                    if (isEmailSent)
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient, 
                            IsSent = 1,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient,
                            IsSent = 0,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                        jsonResponse.errorMessage = email.SendError;
                        return Json(jsonResponse);
                    }
                    // send email end
                }
                jsonResponse.success = true;
                return Json(jsonResponse);
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // accept crew by admin manning agency
    [HttpPost("accept-by-agency")]
    public IActionResult AcceptByAgency([FromBody] AcceptByAgencyRequest acceptByAgencyRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn())
        {
            IEnumerable<dynamic> deserializedCrewIDArray = (IEnumerable<dynamic>) JsonConvert.DeserializeObject(acceptByAgencyRequest.crewIDArray);
            try
            {
                if (CurrentUserLevel() == "")
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "User Level Not Found" : "Level Pengguna Tidak Ditemukan";
                    return Json(jsonResponse);
                }
                int currentUserLevelInt = Convert.ToInt32(CurrentUserLevel());
                dynamic userLevelQuery = QueryBuilder("MTUserLevel")
                    .Where("UserLevelID", currentUserLevelInt)
                    .Select("UserLevelName")
                    .FirstOrDefault();
                if ((object) userLevelQuery == null || (object) userLevelQuery.UserLevelName == null)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "User Level Not Found" : "Level Pengguna Tidak Ditemukan";
                    return Json(jsonResponse);
                }
                var userLevelName = userLevelQuery.UserLevelName;
                if (userLevelName != "Manning Agent")
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
                    return Json(jsonResponse);
                }
                var userQuery = ExecuteRow("SELECT MTManningAgentID FROM MTUser WHERE ID = '" + CurrentUserID() + "'");
                if (!userQuery.ContainsKey("MTManningAgentID") || userQuery["MTManningAgentID"] == null)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Manning agent admin must be associated with any manning agent" : "Admin agensi kru harus memiliki asosiasi dengan agensi kru";
                    return Json(jsonResponse);
                }
                var manningAgentIDString = userQuery["MTManningAgentID"].ToString();
                var manningAgentQuery = ExecuteRow("SELECT Name FROM MTManningAgent WHERE ID = '" + manningAgentIDString + "'");
                if (!manningAgentQuery.ContainsKey("Name") || manningAgentQuery["Name"] == null)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Manning agent not found" : "Agensi kru tidak ditemukan";
                    return Json(jsonResponse);
                }
                var manningAgentName = manningAgentQuery["Name"].ToString();
                foreach (dynamic crewIDDynamic in deserializedCrewIDArray)
                {
                    string crewID = crewIDDynamic.ToString();
                    var oldEmployeeStatusQuery = ExecuteRow("SELECT EmployeeStatus FROM MTCrew WHERE ID = '" + crewID + "'");
                    if (!oldEmployeeStatusQuery.ContainsKey("EmployeeStatus") || oldEmployeeStatusQuery["EmployeeStatus"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                        return Json(jsonResponse);
                    }
                    var oldEmployeeStatus = oldEmployeeStatusQuery["EmployeeStatus"].ToString();
                    string subject = "Agency Reviewed";
                    string body = "Your application has been reviewed by " + manningAgentName + ". You have been redirected to Personnel Decision Evaluation (PDE) review step. The PDE review process will involve further evaluation of your qualifications and experience, and we will be in touch soon with further details on scheduling and preparation requirements.";
                    int affectedRows = 0;
                    var row = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewID + "'");
                    if (row.ContainsKey("MTUserID") && row["MTUserID"] != null)
                    {
                        var userID = Convert.ToInt32(row["MTUserID"]);
                        affectedRows = QueryBuilder("TRNotification").Insert(new {
                            MTUserID = userID,
                            Subject = subject,
                            Body = body,
                            CreatedByUserID = CurrentUserID(),
                            CreatedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add Document Check Date Time" : "Gagal Menambahkan Tanggal Dan Jam Pengecekan Dokumen";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                        return Json(jsonResponse);
                    }
                    affectedRows = Execute(
                        "UPDATE MTCrew " +
                        "SET EmployeeStatus = 'Candidate - Agency Reviewed', " +
                        "    LastUpdatedByUserID = @LastUpdatedByUserID, " +
                        "    LastUpdatedDateTime = @LastUpdatedDateTime "+
                        "WHERE ID = @CrewID;",
                        new
                        {
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                            CrewID = crewID
                        }
                    );
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add Document Check Date Time" : "Gagal Menambahkan Tanggal Dan Jam Pengecekan Dokumen";
                        return Json(jsonResponse);
                    }
                    // gmandayu: Update ke tabel MTRecruitmentStatusTracking for Agency Reviewed
                    // 28 Juli 2023
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewID)
                        .WhereIn("MTRecruitmentStatusID", new[] { 121 }) // 121 = "Candidate - Agency Reviewed"
                        .Update(new
                        {
                            Flag = 1,
                            FlagDescription = "Selesai",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") 
                            ? "Failed to Update Crew Tracking Status"
                            : "Gagal Mengubah Data Pelacakan Status Kru";
                        return Json(jsonResponse);
                    }

                    // gmandayu: code ends here
                    affectedRows = QueryBuilder("TREmployeeStatus").Insert(new {
                        MTCrewID = crewID,
                        MTUserID = CurrentUserID(),
                        PreviousStatus = oldEmployeeStatus,
                        CurrentStatus = "Candidate - Agency Reviewed",
                        ChangedDateTime = DateTimeOffset.Now,
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                        return Json(jsonResponse);
                    }
                    var crewDocumentsQuery = ExecuteRows(
                        "SELECT ID FROM MTCrewDocument " + 
                        "WHERE MTCrewID = '" + crewID + "';"
                    );
                    affectedRows = QueryBuilder("MTCrewDocument")
                        .Where("MTCrewID", crewID)
                        .Update(new
                        {
                            IsDraft = 1,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now
                        });
                    if (affectedRows < crewDocumentsQuery.Count)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Status Of Crew Documents" : "Gagal Mengubah Status Dokumen Kru";
                        return Json(jsonResponse);
                    }

                    // send email start
                    var emailTemplateCategory = "Crew Agency Reviewed";
                    var crewInfo = ExecuteRow("SELECT MTCrew.Email, MTCrew.FullName FROM MTCrew WHERE MTCrew.ID = '" + crewID + "'");
                    if (crewInfo["Email"] == null || crewInfo["FullName"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew email, full name cannot be empty" : "Email, nama lengkap crew tidak boleh kosong";
                        return Json(jsonResponse);
                    }
                    var email = new Email();
                    email.Sender = Config.SenderEmail;
                    email.Recipient = crewInfo["Email"].ToString();
                    var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
                    if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email template not found or the subject and message column is empty" : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
                        return Json(jsonResponse);
                    }
                    email.Subject = emailTemplate["Subject"].ToString();
                    email.Content = emailTemplate["Message"].ToString();
                    email.ReplaceContent("{{crewCandidateFullName}}", crewInfo["FullName"].ToString());
                    email.ReplaceContent("{{AgencyName}}", manningAgentName);
                    if (Email.Mailer == null)
                    {
                        var smtpClient = new SmtpClient();
                        smtpClient.CheckCertificateRevocation = false;
                        Email.Mailer = smtpClient;
                    }
                    else if (Email.Mailer.CheckCertificateRevocation)
                    {
                        Email.Mailer.CheckCertificateRevocation = false;
                    }
                    bool isEmailSent = false;
                    Task.Run(async () =>
                    {
                        isEmailSent = await email.SendAsync();
                    }).GetAwaiter().GetResult();
                    if (isEmailSent)
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient, 
                            IsSent = 1,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient,
                            IsSent = 0,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                        jsonResponse.errorMessage = email.SendError;
                        return Json(jsonResponse);
                    }
                    // send email end
                }
                jsonResponse.success = true;
                return Json(jsonResponse);
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // reject multiple crew candidate
    [HttpPost("reject-multiple-crew")]
    public IActionResult RejectMultiple([FromBody] RejectMultipleRequest rejectMultipleRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            string rejectReason = rejectMultipleRequest.rejectReason;
            IEnumerable<dynamic> deserializedCrewIDArray = (IEnumerable<dynamic>) JsonConvert.DeserializeObject(rejectMultipleRequest.crewIDArray);
            try
            {
                foreach (dynamic crewIDDynamic in deserializedCrewIDArray)
                {
                    string crewID = crewIDDynamic.ToString();
                    var oldEmployeeStatusQuery = ExecuteRow("SELECT EmployeeStatus FROM MTCrew WHERE ID = '" + crewID + "'");
                    if (oldEmployeeStatusQuery.ContainsKey("EmployeeStatus") && oldEmployeeStatusQuery["EmployeeStatus"] != null)
                    {
                        var oldEmployeeStatus = oldEmployeeStatusQuery["EmployeeStatus"].ToString();
                        int affectedRows = Execute(
                            "UPDATE MTCrew " +
                            "SET RejectedReason = @RejectedReason, " +
                            "    RejectedDateTime = @RejectedDateTime, " +
                            "    EmployeeStatus = 'Candidate - Rejected', " +
                            "    LastUpdatedByUserID = @LastUpdatedByUserID, " +
                            "    LastUpdatedDateTime = @LastUpdatedDateTime "+
                            "WHERE ID = @CrewID;",
                            new
                            {
                                RejectedReason = rejectReason,
                                RejectedDateTime = DateTimeOffset.Now,
                                LastUpdatedByUserID = CurrentUserID(),
                                LastUpdatedDateTime = DateTimeOffset.Now,
                                CrewID = crewID
                            }
                        );
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Reject Crew" : "Gagal Menolak Kru";
                            return Json(jsonResponse);
                        }
                        affectedRows = QueryBuilder("TREmployeeStatus").Insert(new {
                            MTCrewID = crewID,
                            MTUserID = CurrentUserID(),
                            PreviousStatus = oldEmployeeStatus,
                            CurrentStatus = "Candidate - Rejected",
                            ChangedDateTime = DateTimeOffset.Now,
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                            return Json(jsonResponse);
                        }
                        string subject = "Rejection Notification";
                        string body = "Thank you for taking the time to apply at our company. After careful consideration, we regret to inform you that your application has not been successful. We genuinely appreciate the effort and time you invested in applying for our company. Thank you once again for your interest in joining our company.";
                        var row = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewID + "'");
                        if (row.ContainsKey("MTUserID") && row["MTUserID"] != null)
                        {
                            var userID = Convert.ToInt32(row["MTUserID"]);
                            affectedRows = QueryBuilder("TRNotification").Insert(new {
                                MTUserID = userID,
                                Subject = subject,
                                Body = body,
                                CreatedByUserID = CurrentUserID(),
                                CreatedDateTime = DateTimeOffset.Now,
                                LastUpdatedByUserID = CurrentUserID(),
                                LastUpdatedDateTime = DateTimeOffset.Now,
                            });
                            if (affectedRows == 0)
                            {
                                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Create Rejection Notification" : "Gagal Membuat Notifikasi Penolakan";
                                return Json(jsonResponse);
                            }
                        }
                        else
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                            return Json(jsonResponse);
                        }
                        // send email start
                        var emailTemplateCategory = "Crew Permanently Rejected";
                        var crewInfo = ExecuteRow("SELECT MTCrew.Email, MTCrew.FullName, MTRank.Name AS RankAppliedFor FROM MTCrew INNER JOIN MTRank ON MTCrew.RankAppliedFor_RankID = MTRank.ID WHERE MTCrew.ID = '" + crewID + "'");
                        if (crewInfo["Email"] == null || crewInfo["FullName"] == null || crewInfo["RankAppliedFor"] == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew email, full name, and rank applied for cannot be empty" : "Email, nama lengkap, dan rank yang akan dipilih crew tidak boleh kosong";
                            return Json(jsonResponse);
                        }
                        var email = new Email();
                        email.Sender = Config.SenderEmail;
                        email.Recipient = crewInfo["Email"].ToString();
                        var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
                        if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email template not found or the subject and message column is empty" : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
                            return Json(jsonResponse);
                        }
                        email.Subject = emailTemplate["Subject"].ToString();
                        email.Content = emailTemplate["Message"].ToString();
                        email.ReplaceContent("{{crewCandidateFullName}}", crewInfo["FullName"].ToString());
                        email.ReplaceContent("{{rankAppliedFor}}", crewInfo["RankAppliedFor"].ToString());
                        if (Email.Mailer == null)
                        {
                            var smtpClient = new SmtpClient();
                            smtpClient.CheckCertificateRevocation = false;
                            Email.Mailer = smtpClient;
                        }
                        else if (Email.Mailer.CheckCertificateRevocation)
                        {
                            Email.Mailer.CheckCertificateRevocation = false;
                        }
                        bool isEmailSent = false;
                        Task.Run(async () =>
                        {
                            isEmailSent = await email.SendAsync();
                        }).GetAwaiter().GetResult();
                        if (isEmailSent)
                        {
                            affectedRows = QueryBuilder("TREmailHistory").Insert(new
                            {
                                MTCrew_ID = crewID,
                                Subject = email.Subject,
                                Message = email.Content,
                                To = email.Recipient, 
                                IsSent = 1,
                                SentDateTime = DateTimeOffset.Now
                            });
                            if (affectedRows == 0)
                            {
                                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                                return Json(jsonResponse);
                            }
                        }
                        else
                        {
                            affectedRows = QueryBuilder("TREmailHistory").Insert(new
                            {
                                MTCrew_ID = crewID,
                                Subject = email.Subject,
                                Message = email.Content,
                                To = email.Recipient,
                                IsSent = 0,
                                SentDateTime = DateTimeOffset.Now
                            });
                            if (affectedRows == 0)
                            {
                                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                                return Json(jsonResponse);
                            }
                            jsonResponse.errorMessage = email.SendError;
                            return Json(jsonResponse);
                        }
                        // send email end

                        /* Gmandayu: Update recruitment status tracking for rejected crew.
                        * Code updated: 28 Juli 2023
                        */
                        affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                            .Where("MTCrewID", int.Parse(crewID))
                            .Where("MTRecruitmentStatusID", 116)
                            .Update(new
                            {
                                Flag = 1,
                                FlagDescription = "Selesai",
                                LastUpdatedByUserID = CurrentUserID(),
                                LastUpdatedDateTime = DateTimeOffset.Now,
                            });
                        affectedRows += QueryBuilder("MTRecruitmentStatusTracking")
                            .Where("MTCrewID", int.Parse(crewID))
                            .Where("FlagDescription", "Menunggu")
                            .Update(new
                            {
                                Flag = 3,
                                FlagDescription = "Dibatalkan",
                                LastUpdatedByUserID = CurrentUserID(),
                                LastUpdatedDateTime = DateTimeOffset.Now,
                            });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = ((CurrentLanguage == "en-US")
                                ? "Failed to Update Crew Tracking Status"
                                : "Gagal Mengubah Data Pelacakan Status Kru");
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                        return Json(jsonResponse);
                    }
                }              
                jsonResponse.success = true;
                return Json(jsonResponse);
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // save mcu schedule(date time and location) to database
    [HttpPost("add-mcu-schedule")]
    public IActionResult AddMCUSchedule([FromBody] MCUScheduleRequest mcuScheduleRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            string mcuScheduleDateTime = mcuScheduleRequest.mcuScheduleDateTime;
            string mcuLocation = mcuScheduleRequest.mcuLocation;
            int crewID = mcuScheduleRequest.crewID;
            try
            {
                int affectedRows = 0;
                CultureInfo enCI = new CultureInfo("en-US", false);
                CultureInfo idCI = new CultureInfo("id-ID", false);
                DateTimeOffset dateTimeOffset;
                var currentCI = (CurrentLanguage == "en-US") ? enCI : idCI;
                if (!DateTimeOffset.TryParseExact(mcuScheduleDateTime, "dd MMM yyyy HH:mm:sszzz", currentCI, DateTimeStyles.None, out dateTimeOffset))
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Date time must be in format dd MMM yyyy HH:mm:sszzz" : "Tanggal dan jam harus dalam format dd MMM yyyy HH:mm:sszzz";
                    return Json(jsonResponse);
                }
                string date = dateTimeOffset.ToString("dddd, dd MMMM yyyy", idCI);
                string time = dateTimeOffset.ToString("HH.mm", idCI);
                affectedRows = Execute(
                    "UPDATE MTCrew " +
                    "SET EmployeeStatus = 'Candidate - MCU', " +
                    "    LastUpdatedByUserID = @LastUpdatedByUserID, " +
                    "    LastUpdatedDateTime = @LastUpdatedDateTime "+
                    "WHERE ID = @CrewID;",
                    new
                    {
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                        CrewID = crewID
                    }
                );
                if (affectedRows == 0)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add MCU Schedule" : "Gagal Menambahkan Jadwal MCU";
                    return Json(jsonResponse);
                }
                // gmandayu: Update ke tabel MTRecruitmentStatusTracking
                // 28 Juli 2023
                affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                    .Where("MTCrewID", crewID)
                    .Where("MTRecruitmentStatusID", 114)
                    .Update(new
                    {
                        Flag = 1,
                        FlagDescription = "Selesai",
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                    });
                if (affectedRows == 0)
                {
                    jsonResponse.errorMessage = ((CurrentLanguage == "en-US")
                        ? "Failed to Update Crew Tracking Status"
                        : "Gagal Mengubah Data Pelacakan Status Kru");
                    return Json(jsonResponse);
                }
                // gmandayu: code ends here
                affectedRows = QueryBuilder("TREmployeeStatus").Insert(new {
                    MTCrewID = crewID,
                    MTUserID = CurrentUserID(),
                    PreviousStatus = "Candidate - PDE Reviewed",
                    CurrentStatus = "Candidate - MCU",
                    ChangedDateTime = DateTimeOffset.Now,
                });
                if (affectedRows == 0)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                    return Json(jsonResponse);
                }
                affectedRows = Execute(
                    "INSERT INTO TRMCUResult " +
                    "(MTCrew_ID, MTUserID, McuScheduleDate, McuLocation, CreatedByUserID, CreatedDateTime, LastUpdatedByUserID, LastUpdatedDateTime) " +
                    "VALUES (" +
                    "@CrewID, @MTUserID, @McuScheduleDate, @McuLocation, @CreatedByUserID, @CreatedDateTime, @LastUpdatedByUserID, @LastUpdatedDateTime" +
                    ");",
                    new
                    {
                        CrewID = crewID,
                        MTUserID = CurrentUserID(),
                        McuScheduleDate = dateTimeOffset,
                        McuLocation = mcuLocation,
                        CreatedByUserID = CurrentUserID(),
                        CreatedDateTime = DateTimeOffset.Now,
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                    }
                );
                if (affectedRows == 0)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add MCU Schedule" : "Gagal Menambahkan Jadwal MCU";
                    return Json(jsonResponse);
                }
                string subject = "MCU Invitation";
                string body = "Please come on " + date + ", " + time + " at " + mcuLocation + " for MCU(Medical Check Up) process.";
                var row = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewID + "'");
                if (row.ContainsKey("MTUserID") && row["MTUserID"] != null)
                {
                    var userID = Convert.ToInt32(row["MTUserID"]);
                    affectedRows = QueryBuilder("TRNotification").Insert(new {
                        MTUserID = userID,
                        Subject = subject,
                        Body = body,
                        CreatedByUserID = CurrentUserID(),
                        CreatedDateTime = DateTimeOffset.Now,
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add MCU Schedule" : "Gagal Menambahkan Jadwal MCU";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }

                // send email start
                var emailTemplateCategory = "Crew Medical Checkup Scheduling";
                var crewInfo = ExecuteRow("SELECT MTCrew.Email, MTCrew.FullName FROM MTCrew WHERE MTCrew.ID = '" + crewID.ToString() + "'");
                if (crewInfo["Email"] == null || crewInfo["FullName"] == null)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew email, full name cannot be empty" : "Email, nama lengkap crew tidak boleh kosong";
                    return Json(jsonResponse);
                }
                var email = new Email();
                email.Sender = Config.SenderEmail;
                email.Recipient = crewInfo["Email"].ToString();
                var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
                if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email template not found or the subject and message column is empty" : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
                    return Json(jsonResponse);
                }
                email.Subject = emailTemplate["Subject"].ToString();
                email.Content = emailTemplate["Message"].ToString();
                email.ReplaceContent("{{crewCandidateFullName}}", crewInfo["FullName"].ToString());
                //email.ReplaceContent("{{mcuDate}}", date + ", " + time + ", at " + mcuLocation);
                email.ReplaceContent("{{mcuDate}}", date + ", " + time);
                email.ReplaceContent("{{mcu location}}", mcuLocation);
                if (Email.Mailer == null)
                {
                    var smtpClient = new SmtpClient();
                    smtpClient.CheckCertificateRevocation = false;
                    Email.Mailer = smtpClient;
                }
                else if (Email.Mailer.CheckCertificateRevocation)
                {
                    Email.Mailer.CheckCertificateRevocation = false;
                }
                bool isEmailSent = false;
                Task.Run(async () =>
                {
                    isEmailSent = await email.SendAsync();
                }).GetAwaiter().GetResult();
                if (isEmailSent)
                {
                    affectedRows = QueryBuilder("TREmailHistory").Insert(new
                    {
                        MTCrew_ID = crewID,
                        Subject = email.Subject,
                        Message = email.Content,
                        To = email.Recipient, 
                        IsSent = 1,
                        SentDateTime = DateTimeOffset.Now
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    affectedRows = QueryBuilder("TREmailHistory").Insert(new
                    {
                        MTCrew_ID = crewID,
                        Subject = email.Subject,
                        Message = email.Content,
                        To = email.Recipient,
                        IsSent = 0,
                        SentDateTime = DateTimeOffset.Now
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                        return Json(jsonResponse);
                    }
                    jsonResponse.errorMessage = email.SendError;
                    return Json(jsonResponse);
                }
                // send email end
                jsonResponse.success = true;
                return Json(jsonResponse);
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // reject single crew candidate
    [HttpPost("reject-single-crew")]
    public IActionResult RejectSingle([FromBody] RejectSingleRequest rejectSingleRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            string rejectReason = rejectSingleRequest.rejectReason;
            int crewID = rejectSingleRequest.crewID;
            try
            {
                var row = ExecuteRow("SELECT EmployeeStatus FROM MTCrew WHERE ID = '" + crewID.ToString() + "'");
                if (row.ContainsKey("EmployeeStatus") && row["EmployeeStatus"] != null)
                {
                    var oldEmployeeStatus = row["EmployeeStatus"].ToString();
                    int affectedRows = Execute(
                        "UPDATE MTCrew " +
                        "SET RejectedReason = @RejectedReason, " +
                        "    RejectedDateTime = @RejectedDateTime, " +
                        "    EmployeeStatus = 'Candidate - Rejected', " +
                        "    LastUpdatedByUserID = @LastUpdatedByUserID, " +
                        "    LastUpdatedDateTime = @LastUpdatedDateTime "+
                        "WHERE ID = @CrewID;",
                        new
                        {
                            RejectedReason = rejectReason,
                            RejectedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                            CrewID = crewID
                        }
                    );
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Reject Crew" : "Gagal Menolak Kru";
                        return Json(jsonResponse);
                    }
                    affectedRows = QueryBuilder("TREmployeeStatus").Insert(new {
                        MTCrewID = crewID,
                        MTUserID = CurrentUserID(),
                        PreviousStatus = oldEmployeeStatus,
                        CurrentStatus = "Candidate - Rejected",
                        ChangedDateTime = DateTimeOffset.Now,
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                        return Json(jsonResponse);
                    }
                    string notificationSubject = "Rejection Notification";
                    string notificationBody = "Thank you for taking the time to apply at our company. After careful consideration, we regret to inform you that your application has not been successful. We genuinely appreciate the effort and time you invested in applying for our company. Thank you once again for your interest in joining our company.";
                    var userIDRow = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewID.ToString() + "'");
                    if (userIDRow.ContainsKey("MTUserID") && userIDRow["MTUserID"] != null)
                    {
                        var userID = Convert.ToInt32(userIDRow["MTUserID"]);
                        affectedRows = QueryBuilder("TRNotification").Insert(new {
                            MTUserID = userID,
                            Subject = notificationSubject,
                            Body = notificationBody,
                            CreatedByUserID = CurrentUserID(),
                            CreatedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Create Rejection Notification" : "Gagal Membuat Notifikasi Penolakan";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                        return Json(jsonResponse);
                    }

                    // send email start
                    var emailTemplateCategory = "Crew Permanently Rejected";
                    var crewInfo = ExecuteRow("SELECT MTCrew.Email, MTCrew.FullName, MTRank.Name AS RankAppliedFor FROM MTCrew INNER JOIN MTRank ON MTCrew.RankAppliedFor_RankID = MTRank.ID WHERE MTCrew.ID = '" + crewID.ToString() + "'");
                    if (crewInfo["Email"] == null || crewInfo["FullName"] == null || crewInfo["RankAppliedFor"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew email, full name, and rank applied for cannot be empty" : "Email, nama lengkap, dan rank yang akan dipilih crew tidak boleh kosong";
                        return Json(jsonResponse);
                    }
                    var email = new Email();
                    email.Sender = Config.SenderEmail;
                    email.Recipient = crewInfo["Email"].ToString();
                    var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
                    if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email template not found or the subject and message column is empty" : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
                        return Json(jsonResponse);
                    }
                    email.Subject = emailTemplate["Subject"].ToString();
                    email.Content = emailTemplate["Message"].ToString();
                    email.ReplaceContent("{{crewCandidateFullName}}", crewInfo["FullName"].ToString());
                    email.ReplaceContent("{{rankAppliedFor}}", crewInfo["RankAppliedFor"].ToString());
                    if (Email.Mailer == null)
                    {
                        var smtpClient = new SmtpClient();
                        smtpClient.CheckCertificateRevocation = false;
                        Email.Mailer = smtpClient;
                    }
                    else if (Email.Mailer.CheckCertificateRevocation)
                    {
                        Email.Mailer.CheckCertificateRevocation = false;
                    }
                    bool isEmailSent = false;
                    Task.Run(async () =>
                    {
                        isEmailSent = await email.SendAsync();
                    }).GetAwaiter().GetResult();
                    if (isEmailSent)
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient, 
                            IsSent = 1,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient,
                            IsSent = 0,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                        jsonResponse.errorMessage = email.SendError;
                        return Json(jsonResponse);
                    }
                    // send email end

                    // gmandayu: code updated 28 Juli 2023.
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewID)
                        .Where("MTRecruitmentStatusID", 116)
                        .Update(new
                        {
                            Flag = 1,
                            FlagDescription = "Selesai",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    affectedRows += QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewID)
                        .Where("FlagDescription", "Menunggu")
                        .Update(new
                        {
                            Flag = 3,
                            FlagDescription = "Dibatalkan",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = ((CurrentLanguage == "en-US")
                            ? "Failed to Update Crew Tracking Status"
                            : "Gagal Mengubah Data Pelacakan Status Kru");
                        return Json(jsonResponse);
                    }
                    jsonResponse.success = true;
                    return Json(jsonResponse);
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    /* 
     * Gmandayu: reject crew from MCU page
     * Code updated: 13 July 2023
     */
    [HttpPost("reject-final-crew")]
    public IActionResult RejectFinal([FromBody] RejectFinalRequest rejectFinalRequest)
    {
        JsonResponse jsonResponse = new()
        {
            success = false,
            data = new object(),
            errorMessage = ""
        };
        if (!IsLoggedIn())
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
        string rejectReason = rejectFinalRequest.rejectReason;
        int crewID = rejectFinalRequest.crewID;
        try
        {
            int affectedRows = 0;
            string notificationSubject = "", notificationBody = "", currentStatus = "";
            var row = ExecuteRow("SELECT EmployeeStatus FROM MTCrew WHERE ID = '" + crewID.ToString() + "'");
            var getHealthStatus = ExecuteRow("SELECT HealthStatus FROM TRMCUResult WHERE MTCrew_ID = '" + crewID.ToString() + "'");
            if (!row.ContainsKey("EmployeeStatus") && row["EmployeeStatus"] != null)
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                return Json(jsonResponse);
            }
            if (!getHealthStatus.ContainsKey("HealthStatus") || getHealthStatus["HealthStatus"] == null)
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Health Status must not be empty" : "Status kesehatan tidak boleh kosong";
                return Json(jsonResponse);
            }
            var oldEmployeeStatus = row["EmployeeStatus"].ToString();
            var healthStatus = getHealthStatus["HealthStatus"].ToString();
            switch (healthStatus)
            {
                case "UnfitTemporary":
                    affectedRows += Execute("UPDATE MTCrew " +
                        "SET RejectedReason = @RejectedReason, " +
                        "    RejectedDateTime = @RejectedDateTime, " +
                        "    EmployeeStatus = 'Candidate - Temporary Rejected', " +
                        "    LastUpdatedByUserID = @LastUpdatedByUserID, " +
                        "    LastUpdatedDateTime = @LastUpdatedDateTime " +
                        "WHERE ID = @CrewID;",
                        new
                        {
                            RejectedReason = rejectReason,
                            RejectedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                            CrewID = crewID
                        }
                    );
                    notificationSubject = "Temporary Rejection Notification";
                    notificationBody = "Thank you for taking the time to apply at our company. " +
                        "<br>After careful consideration, we regret to inform you that your application has not been successful at the moment. " +
                        "<br>Rejected Reason: <b>" + rejectReason + "</b> " +
                        "<br>Please wait for further information. " +
                        "<br>Thank you once again for your interest in joining our company.";
                    currentStatus = "Candidate - Temporary Rejected";

                    // gmandayu: code updated 28 Juli 2023
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewID)
                        .Where("MTRecruitmentStatusID", 115)
                        .Update(new
                        {
                            Flag = 1,
                            FlagDescription = "Selesai",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    affectedRows += QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewID)
                        .Where("FlagDescription", "Menunggu")
                        .Update(new
                        {
                            Flag = 3,
                            FlagDescription = "Dibatalkan",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = ((CurrentLanguage == "en-US")
                            ? "Failed to Update Crew Tracking Status"
                            : "Gagal Mengubah Data Pelacakan Status Kru");
                        return Json(jsonResponse);
                    }
                    break;
                case "UnfitPermanent":
                    affectedRows += Execute("UPDATE MTCrew " +
                        "SET RejectedReason = @RejectedReason, " +
                        "    RejectedDateTime = @RejectedDateTime, " +
                        "    EmployeeStatus = 'Candidate - Rejected', " +
                        "    LastUpdatedByUserID = @LastUpdatedByUserID, " +
                        "    LastUpdatedDateTime = @LastUpdatedDateTime " +
                        "WHERE ID = @CrewID;",
                        new
                        {
                            RejectedReason = rejectReason,
                            RejectedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                            CrewID = crewID
                        }
                    );
                    notificationSubject = "Rejection Notification";
                    notificationBody = "Thank you for taking the time to apply at our company. " +
                        "<br>After careful consideration, we regret to inform you that your application has not been successful. " +
                        "<br>We genuinely appreciate the effort and time you invested in applying for our company. " +
                        "<br>Rejected Reason: <b>" + rejectReason + "</b> " +
                        "<br>Thank you once again for your interest in joining our company.";
                    currentStatus = "Candidate - Rejected";

                    // gmandayu: code updated 28 Juli 2023.
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewID)
                        .Where("MTRecruitmentStatusID", 116)
                        .Update(new
                        {
                            Flag = 1,
                            FlagDescription = "Selesai",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    affectedRows += QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewID)
                        .Where("FlagDescription", "Menunggu")
                        .Update(new
                        {
                            Flag = 3,
                            FlagDescription = "Dibatalkan",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = ((CurrentLanguage == "en-US")
                            ? "Failed to Update Crew Tracking Status"
                            : "Gagal Mengubah Data Pelacakan Status Kru");
                        return Json(jsonResponse);
                    }
                    break;
                default:
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Reject Crew" : "Gagal Menolak Kru";
                    return Json(jsonResponse);
            }
            affectedRows += QueryBuilder("TREmployeeStatus").Insert(new
            {
                MTCrewID = crewID,
                MTUserID = CurrentUserID(),
                PreviousStatus = oldEmployeeStatus,
                CurrentStatus = currentStatus,
                ChangedDateTime = DateTimeOffset.Now,
            });
            if (affectedRows == 0)
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                return Json(jsonResponse);
            }
            SendFinalRejectionNotification(crewID, notificationSubject, notificationBody, jsonResponse);
            jsonResponse = SendEmailNotification(crewID, currentStatus, jsonResponse);
            return Json(jsonResponse);
        }
        catch (Exception ex)
        {
            jsonResponse.errorMessage = ex.Message;
            return Json(jsonResponse);
        }
    }

    private static JsonResponse SendFinalRejectionNotification(int crewID, string notificationSubject, string notificationBody, JsonResponse jsonResponse)
    {
        var userIDRow = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID ='" + crewID + "'");
        if (userIDRow.ContainsKey("MTUserID") && userIDRow["MTUserID"] != null)
        {
            int affectedRows = 0;
            var userID = Convert.ToInt32(userIDRow["MTUserID"]);
            affectedRows += QueryBuilder("TRNotification").Insert(new
            {
                MTUserID = userID,
                Subject = notificationSubject,
                Body = notificationBody,
                CreatedByUserID = CurrentUserID(),
                CreatedDateTime = DateTimeOffset.Now,
                LastUpdatedByUserID = CurrentUserID(),
                LastUpdatedDateTime = DateTimeOffset.Now,
            });
            if (affectedRows == 0)
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Create Rejection Notification" : "Gagal Membuat Notifikasi Penolakan";
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
        }
        return jsonResponse;
    }

    private static JsonResponse SendEmailNotification(int crewID, string employeeStatus, JsonResponse jsonResponse)
    {
        var emailTemplateCategory = "";
        if (employeeStatus == "Candidate - Temporary Rejected")
        {
            emailTemplateCategory = "Crew Temporary Rejected";
        }
        else if (employeeStatus == "Candidate - Rejected")
        {
            emailTemplateCategory = "Crew Permanently Rejected";
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                ? "Invalid employee status for sending email notification"
                : "Status karyawan yang tidak valid untuk mengirim notifikasi email";
            return jsonResponse;
        }
        var crewInfo = ExecuteRow("SELECT " +
            "MTCrew.Email, " +
            "MTCrew.FullName, " +
            "MTRank.Name AS RankAppliedFor " +
            "FROM MTCrew INNER JOIN MTRank " +
            "ON MTCrew.RankAppliedFor_RankID = MTRank.ID " +
            "WHERE MTCrew.ID = '" + crewID.ToString() + "'");
        if (crewInfo["Email"] == null || crewInfo["FullName"] == null || crewInfo["RankAppliedFor"] == null)
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") 
                ? "Crew email, full name, and rank applied for cannot be empty" 
                : "Email, nama lengkap, dan rank yang akan dipilih crew tidak boleh kosong";
            return jsonResponse;
        }
        var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
        if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") 
                ? "Email template not found or the subject and message column is empty" 
                : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
            return jsonResponse;
        }
        var email = new Email();
        email.Sender = Config.SenderEmail;
        email.Recipient = crewInfo["Email"].ToString();
        email.Subject = emailTemplate["Subject"].ToString();
        email.Content = emailTemplate["Message"].ToString();
        email.ReplaceContent("{{crewCandidateFullName}}", crewInfo["FullName"].ToString());
        email.ReplaceContent("{{rankAppliedFor}}", crewInfo["RankAppliedFor"].ToString());
        if (Email.Mailer == null)
        {
            var smtpClient = new SmtpClient();
            smtpClient.CheckCertificateRevocation = false;
            Email.Mailer = smtpClient;
        }
        else if (Email.Mailer.CheckCertificateRevocation)
        {
            Email.Mailer.CheckCertificateRevocation = false;
        }
        bool isEmailSent = false;
        Task.Run(async () => {
            isEmailSent = await email.SendAsync();
        }).GetAwaiter().GetResult();
        int affectedRows = 0;
        if (isEmailSent)
        {
            affectedRows = QueryBuilder("TREmailHistory").Insert(new
            {
                MTCrew_ID = crewID,
                Subject = email.Subject,
                Message = email.Content,
                To = email.Recipient, 
                IsSent = 1,
                SentDateTime = DateTimeOffset.Now
            });
            if (affectedRows == 0)
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                return jsonResponse;
            }
        }
        else
        {
            affectedRows = QueryBuilder("TREmailHistory").Insert(new
            {
                MTCrew_ID = crewID,
                Subject = email.Subject,
                Message = email.Content,
                To = email.Recipient,
                IsSent = 0,
                SentDateTime = DateTimeOffset.Now
            });
            if (affectedRows == 0)
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                return jsonResponse;
            }
            jsonResponse.errorMessage = email.SendError;
            return jsonResponse;
        }
        jsonResponse.success = true;
        return jsonResponse;
    }

    // get isAdmin() and crew's employee status
    [HttpGet("get-admin-and-employee-status")]
    public IActionResult GetCrewEmployeeStatus([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = "";
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            dynamic crewQuery = QueryBuilder("MTCrew")
                .Where("ID", crewID)
                .Select("EmployeeStatus")
                .FirstOrDefault();
            if ((object) crewQuery != null)
            {
                if (crewQuery.EmployeeStatus != null)
                {
                    jsonResponse.success = true;
                    var adminAndEmployeeStatus = new
                    {
                        IsAdmin = IsAdmin(),
                        EmployeeStatus = crewQuery.EmployeeStatus
                    };
                    jsonResponse.data = adminAndEmployeeStatus;
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Employee Status Is Empty" : "Status Karyawan Kru Bernilai Kosong";
                }
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load MTCrewBankAccount given crewID
    [HttpGet("crew-bank-account-for-admin")]
    public IActionResult GetCrewBankAccountForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            IEnumerable<dynamic> results = QueryBuilder("MTCrewBankAccount")
                .Where("MTCrewID", crewID)
                .Join("MTCurrency", "MTCurrency.ID", "MTCrewBankAccount.MTCurrencyID")
                .Join("MTBank", "MTBank.ID", "MTCrewBankAccount.MTBankID")
                .Join("MTUser AS CreatedByUser", "CreatedByUser.ID", "MTCrewBankAccount.CreatedByUserID")
                .Join("MTUser AS LastUpdatedByUser", "LastUpdatedByUser.ID", "MTCrewBankAccount.LastUpdatedByUserID")
                .Select(
                    "MTCrewBankAccount.ID"
                )
                .SelectRaw( 
                    "CASE WHEN MTCrewBankAccount.OtherBankName IS NULL THEN CONCAT(MTBank.Name, '/', MTBank.Code) ELSE MTCrewBankAccount.OtherBankName END AS BankName"
                )
                .Select(
                    "MTCrewBankAccount.AccountNumber",
                    "MTCrewBankAccount.Beneficiary"
                )
                .SelectRaw( 
                    "CONCAT(MTCurrency.Code, ' - ', MTCurrency.Name) AS Currency"
                )
                .SelectRaw( 
                    "CASE WHEN MTCrewBankAccount.MainAcc = 1 THEN 'Yes' ELSE 'No' END AS MainAcc"
                )
                .Select(
                    "MTCrewBankAccount.Attachment"
                )
                .Select(
                    "CreatedByUser.Email as CreatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewBankAccount.CreatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as CreatedDateTime"
                )
                .Select(
                    "LastUpdatedByUser.Email as LastUpdatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewBankAccount.LastUpdatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as LastUpdatedDateTime"
                )
                .Get();
            if (CurrentLanguage == "id-ID")
            {
                var engToIndCaption = new Dictionary<string, string>
                {
                    { "Yes", "Iya" },
                    { "No", "Tidak" }
                };
                foreach (dynamic result in results)
                {
                    result.MainAcc = engToIndCaption[result.MainAcc];
                }
            }
            jsonResponse.success = true;
            jsonResponse.data = results.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load MTCrewFormalEducation given crewID
    [HttpGet("crew-formal-education-for-admin")]
    public IActionResult GetCrewFormalEducationForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            IEnumerable<dynamic> results = QueryBuilder("MTCrewFormalEducation")
                .Where("MTCrewID", crewID)
                .Join("MTUser AS CreatedByUser", "CreatedByUser.ID", "MTCrewFormalEducation.CreatedByUserID")
                .Join("MTUser AS LastUpdatedByUser", "LastUpdatedByUser.ID", "MTCrewFormalEducation.LastUpdatedByUserID")
                .Select(
                    "MTCrewFormalEducation.ID",
                    "MTCrewFormalEducation.EducationLevel",
                    "MTCrewFormalEducation.SchoolName",
                    "MTCrewFormalEducation.City",
                    "MTCrewFormalEducation.Attachment"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewFormalEducation.StartDate, {CustomFormat.YEAR_ONLY_FORMAT}) as StartDate"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewFormalEducation.EndDate, {CustomFormat.YEAR_ONLY_FORMAT}) as EndDate"
                )
                .Select(
                    "CreatedByUser.Email as CreatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewFormalEducation.CreatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as CreatedDateTime"
                )
                .Select(
                    "LastUpdatedByUser.Email as LastUpdatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewFormalEducation.LastUpdatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as LastUpdatedDateTime"
                )
                .Get();
            if (CurrentLanguage == "id-ID")
            {
                var engToIndCaption = new Dictionary<string, string>
                {
                    { "Primary", "SD" },
                    { "Secondary", "SMP" },
                    { "High / Vocational", "SMA / SMK" },
                    { "Associate", "D1 / D2 / D3" },
                    { "Bachelor", "S1" },
                    { "Master", "S2" },
                    { "Doctoral", "S3" }
                };
                foreach (dynamic result in results)
                {
                    result.EducationLevel = engToIndCaption[result.EducationLevel];
                }
            }
            jsonResponse.success = true;
            jsonResponse.data = results.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load MTCrewMedicalCertificate given crewID
    [HttpGet("crew-medical-certificate-for-admin")]
    public IActionResult GetCrewMedicalCertificateForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            IEnumerable<dynamic> results = QueryBuilder("MTCrewMedicalCertificate")
                .Where("MTCrewID", crewID)
                .Join("MTMedicalCertificate", "MTMedicalCertificate.ID", "MTCrewMedicalCertificate.MTMedicalCertificateID")
                .Join("MTUser AS CreatedByUser", "CreatedByUser.ID", "MTCrewMedicalCertificate.CreatedByUserID")
                .Join("MTUser AS LastUpdatedByUser", "LastUpdatedByUser.ID", "MTCrewMedicalCertificate.LastUpdatedByUserID")
                .Select(
                    "MTCrewMedicalCertificate.ID",
                    "MTMedicalCertificate.Name",
                    "MTCrewMedicalCertificate.Number",
                    "MTCrewMedicalCertificate.PlaceOfIssue"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewMedicalCertificate.DateOfIssue, {CustomFormat.DATE_FORMAT}) as DateOfIssue"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewMedicalCertificate.ExpirationDate, {CustomFormat.DATE_FORMAT}) as ExpirationDate"
                )
                .Select(
                    "MTCrewMedicalCertificate.Attachment"
                )
                .Select(
                    "CreatedByUser.Email as CreatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewMedicalCertificate.CreatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as CreatedDateTime"
                )
                .Select(
                    "LastUpdatedByUser.Email as LastUpdatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewMedicalCertificate.LastUpdatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as LastUpdatedDateTime"
                )
                .Get();
            jsonResponse.success = true;
            jsonResponse.data = results.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // load MTCrewAppraisal given crewID
    [HttpGet("crew-appraisal-for-admin")]
    public IActionResult GetCrewAppraisalForAdmin([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            IEnumerable<dynamic> results = QueryBuilder("MTCrewAppraisal")
                .Where("MTCrewID", crewID)
                .Join("MTRank", "MTRank.ID", "MTCrewAppraisal.MTRankID")
                .Join("MTUser AS CreatedByUser", "CreatedByUser.ID", "MTCrewAppraisal.CreatedByUserID")
                .Join("MTUser AS LastUpdatedByUser", "LastUpdatedByUser.ID", "MTCrewAppraisal.LastUpdatedByUserID")
                .Select(
                    "MTCrewAppraisal.ID",
                    "MTCrewAppraisal.VesselName",
                    "MTRank.Name",
                    "MTCrewAppraisal.Questionnaire"
                )
                .SelectRaw(
                    "CASE WHEN MTCrewAppraisal.Approved = 1 THEN 'Yes' ELSE 'No' END AS Approved"
                )
                .SelectRaw(
                    "FORMAT(MTCrewAppraisal.AverageRating, 'N2', 'id-ID') AS AverageRating"
                )
                .SelectRaw(
                    "CASE WHEN MTCrewAppraisal.Rehire = 1 THEN 'Yes' ELSE 'No' END AS Rehire"
                )
                .SelectRaw(
                    "CASE WHEN MTCrewAppraisal.Promote = 1 THEN 'Yes' ELSE 'No' END AS Promote"
                )
                .Select(
                    "MTCrewAppraisal.Appraiser"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewAppraisal.DateInput, {CustomFormat.DATE_FORMAT}) as DateInput"
                )
                .Select(
                    "CreatedByUser.Email as CreatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewAppraisal.CreatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as CreatedDateTime"
                )
                .Select(
                    "LastUpdatedByUser.Email as LastUpdatedBy"
                )
                .SelectRaw(
                    $"FORMAT(MTCrewAppraisal.LastUpdatedDateTime, {CustomFormat.DATE_TIME_FORMAT}) as LastUpdatedDateTime"
                )
                .Get();
            if (CurrentLanguage == "id-ID")
            {
                var engToIndCaption = new Dictionary<string, string>
                {
                    { "Yes", "Iya" },
                    { "No", "Tidak" }
                };
                foreach (dynamic result in results)
                {
                    result.Approved = engToIndCaption[result.Approved];
                    result.Rehire = engToIndCaption[result.Rehire];
                    result.Promote = engToIndCaption[result.Promote];
                }
            }
            jsonResponse.success = true;
            jsonResponse.data = results.ToArray();
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // get crew experience duration
    [HttpGet("get-experience-duration-for-admin")]
    public IActionResult GetExperienceDurationForAdmin([FromQuery] int crewExperienceID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = "";
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            dynamic crewExperienceQuery = QueryBuilder("MTCrewExperience")
                .Where("ID", crewExperienceID)
                .SelectRaw(
                    "DATEDIFF(DAY, DateFrom, DateUntil) as Duration"
                )
                .FirstOrDefault();
            if ((object) crewExperienceQuery != null)
            {
                if (crewExperienceQuery.Duration != null)
                {
                    jsonResponse.success = true;
                    jsonResponse.data = crewExperienceQuery.Duration;
                }
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                    ? "Crew Experience Not Found"
                    : "Pengalaman Kru Tidak Ditemukan";
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // get crew personal data derived columns(age, sea experiences, and bmi index)
    [HttpGet("get-personal-data-derived-columns")]
    public IActionResult GetPersonalDataDerivedColumns([FromQuery] int crewID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = "";
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            if (CurrentUserLevel() == "0")
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            dynamic crewQuery = QueryBuilder("MTCrew")
                .Where("ID", crewID)
                .SelectRaw(
                    "CASE WHEN DateOfBirth IS NOT NULL THEN CAST(DATEDIFF(YEAR, DateOfBirth, GETDATE()) AS NVARCHAR(4)) ELSE '' END as Age"
                )
                .SelectRaw(
                    "FORMAT(CASE WHEN Weight IS NOT NULL AND Weight > 0 AND Height IS NOT NULL AND Height > 0 THEN CAST(Weight / ((Height / 100.0) * (Height / 100.0)) as DECIMAL(10, 2)) ELSE 0.00 END, 'N2', 'id-ID') as BMI"
                )
                .FirstOrDefault();
            if ((object) crewQuery != null && crewQuery.Age != null && crewQuery.BMI != null)
            {
                dynamic totalExperienceQuery = QueryBuilder("MTCrewExperience")
                    .Where("MTCrewID", crewID)
                    .SelectRaw(
                        "SUM(DATEDIFF(DAY, DateFrom, DateUntil)) AS TotalSeaExperience"
                    )
                    .FirstOrDefault();
                if ((object)totalExperienceQuery != null)
                {
                    jsonResponse.success = true;
                    PersonalDataDerivedColumnResponse personalDataDerivedColumnResponse = new PersonalDataDerivedColumnResponse();
                    personalDataDerivedColumnResponse.Age = crewQuery.Age;
                    personalDataDerivedColumnResponse.BMI = crewQuery.BMI != "0,00" ? crewQuery.BMI : "";
                    if (totalExperienceQuery.TotalSeaExperience != null)
                    {
                        IEnumerable<dynamic> seaExperiences = QueryBuilder("MTCrewExperience")
                            .Join("MTVesselType", "MTVesselType.ID", "MTCrewExperience.MTVesselTypeID")
                            .Join("MTRank", "MTRank.ID", "MTCrewExperience.MTRankID")
                            .Where("MTCrewExperience.MTCrewID", crewID)
                            .WhereRaw("MTCrewExperience.DateFrom >= DATEADD(YEAR, - 10, GETDATE())")
                            .GroupBy("MTVesselType.Abbreviation", "MTRank.Name")
                            .Select(
                                "MTVesselType.Abbreviation AS VesselTypeAbbreviation",
                                "MTRank.Name AS RankName"
                            )
                            .SelectRaw( 
                                "SUM(DATEDIFF(DAY, MTCrewExperience.DateFrom, MTCrewExperience.DateUntil)) AS ExperienceDuration"
                            )
                            .Get();
                        personalDataDerivedColumnResponse.TotalSeaExperience = totalExperienceQuery.TotalSeaExperience;
                        personalDataDerivedColumnResponse.SeaExperiences = seaExperiences.ToArray();
                    }
                    else
                    {
                        personalDataDerivedColumnResponse.TotalSeaExperience = 0;
                        personalDataDerivedColumnResponse.SeaExperiences = new dynamic[0];
                    }
                    jsonResponse.data = personalDataDerivedColumnResponse;
                }
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                    ? "Crew Not Found"
                    : "Kru Tidak Ditemukan";
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // gmandayu start: load crew info to be used in mcuresult page
    [HttpGet("get-crew-info-for-mcu-result")]
    public IActionResult GetCrewInfoForMcuResult([FromQuery] int mcuResultID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = null;
        jsonResponse.errorMessage = "";
        if(IsLoggedIn()) 
        {
            var row = ExecuteRow("SELECT MTCrew_ID FROM TRMCUResult WHERE McuResult_ID = '" + mcuResultID.ToString() + "'");
            if (row.ContainsKey("MTCrew_ID") && row["MTCrew_ID"] != null)
            {
                int mtCrewID = Convert.ToInt32(row["MTCrew_ID"]);
                IEnumerable<dynamic> crewQuery = QueryBuilder("MTCrew")
                    .Join("MTRank", "MTRank.ID", "MTCrew.RankAppliedFor_RankID")
                    .Where("MTCrew.ID", mtCrewID)
                    .Select("MTCrew.ID", "MTCrew.FullName", "MTCrew.RequiredPhoto", "MTCrew.VisaPhoto", "MTCrew.EmployeeStatus", "MTCrew.IndividualCodeNumber", "MTRank.Name as RankAppliedFor")
                    .SelectRaw("CASE WHEN MTCrew.WillAcceptLowRank = 1 THEN 'Yes' ELSE 'No' END AS WillAcceptLowRank")
                    .SelectRaw($"FORMAT(MTCrew.AvailableFrom, {CustomFormat.DATE_FORMAT}) as AvailableFrom")
                    .SelectRaw($"FORMAT(MTCrew.AvailableUntil, {CustomFormat.DATE_FORMAT}) as AvailableUntil")
                    .Get();
                if (crewQuery.Any())
                {
                    jsonResponse.success = true;
                    jsonResponse.data = crewQuery.First();
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew's data not found!" : "Data kru tidak ditemukan!";
                }
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Medical checkup data not found!" : "Data pemeriksaan medis tidak ditemukan!";
            }
            return Json(jsonResponse);
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "You do not have authorization!" : "Anda tidak memiliki otorisasi!";
            return Json(jsonResponse);
        }
        return Json(jsonResponse);
    }

        // load crew info to be used in checklist page
    [HttpGet("get-crew-info-for-checklist")]
    public IActionResult GetCrewInfoForChecklist([FromQuery] int checklistID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            var row = ExecuteRow("SELECT MTCrewID FROM TRChecklist WHERE ID = '" + checklistID.ToString() + "'");
            if (row.ContainsKey("MTCrewID") )
            {
                if (row["MTCrewID"] != null)
                {
                    IEnumerable<dynamic> crewQuery = QueryBuilder("MTCrew")
                        .Join("MTRank", "MTRank.ID", "MTCrew.RankAppliedFor_RankID")
                        .Where("MTCrew.ID", Convert.ToInt32(row["MTCrewID"]))
                        .Select(
                            "MTCrew.ID",
                            "MTCrew.FullName",
                            "MTCrew.RequiredPhoto",
                            "MTCrew.VisaPhoto",
                            "MTCrew.EmployeeStatus",
                            "MTCrew.IndividualCodeNumber",
                            "MTRank.Name as RankAppliedFor"
                        )
                        .SelectRaw(
                            "CASE WHEN MTCrew.WillAcceptLowRank = 1 THEN 'Yes' ELSE 'No' END AS WillAcceptLowRank"
                        )
                        .SelectRaw(
                            $"FORMAT(MTCrew.AvailableFrom, {CustomFormat.DATE_FORMAT}) as AvailableFrom"
                        )
                        .SelectRaw(
                            $"FORMAT(MTCrew.AvailableUntil, {CustomFormat.DATE_FORMAT}) as AvailableUntil"
                        )
                        .Get();
                    if (crewQuery.Count() > 0)
                    {
                        jsonResponse.success = true;
                        jsonResponse.data = crewQuery.First();
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew not found" : "Kru tidak ditemukan";        
                    }
                }
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Checklist not found" : "Ceklis tidak ditemukan";
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // approve crew document
    [HttpPost("approve-crew-document")]
    public IActionResult ApproveCrewDocument([FromQuery] int crewDocumentID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            try
            {
                int affectedRows = Execute(
                    "UPDATE MTCrewDocument " +
                    "SET IsDraft = 0, " +
                    "    LastUpdatedByUserID = @LastUpdatedByUserID, " +
                    "    LastUpdatedDateTime = @LastUpdatedDateTime "+
                    "WHERE ID = @CrewDocumentID;",
                    new
                    {
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                        CrewDocumentID = crewDocumentID
                    }
                );
                if (affectedRows == 0)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Approve Document" : "Gagal Menyetujui Dokumen";
                    return Json(jsonResponse);
                }
                jsonResponse.success = true;
                return Json(jsonResponse);
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // create new notification
    [HttpPost("invite-crew")]
    public IActionResult InviteCrew([FromBody] InviteCrewRequest inviteCrewRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn())
        {
            string inviteDateTime = inviteCrewRequest.inviteDateTime;
            string notes = inviteCrewRequest.notes;
            int crewID = inviteCrewRequest.crewID;
            try
            {
                int affectedRows = 0;
                CultureInfo enCI = new CultureInfo("en-US", false);
                CultureInfo idCI = new CultureInfo("id-ID", false);
                DateTimeOffset dateTimeOffset;
                var currentCI = (CurrentLanguage == "en-US") ? enCI : idCI;
                if (!DateTimeOffset.TryParseExact(inviteDateTime, "dd MMM yyyy HH:mm:sszzz", currentCI, DateTimeStyles.None, out dateTimeOffset))
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Date time must be in format dd MMM yyyy HH:mm:sszzz" : "Tanggal dan jam harus dalam format dd MMM yyyy HH:mm:sszzz";
                    return Json(jsonResponse);
                }
                string date = dateTimeOffset.ToString("dddd, dd MMMM yyyy", idCI);
                string time = dateTimeOffset.ToString("HH.mm", idCI);
                string body = "Please come on " + date + ", " + time + " at: "+
                    "<br>Patra Jasa Office Tower Lantai 22 Wing 3, Jl. Jend Gatot Subroto Kav. 32-34 Jaksel "+
                    "<br>to continue the checklist process.";
                body += (notes != "") ? "<br>Notes: " + notes : "";
                var row = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewID.ToString() + "'");
                if (row.ContainsKey("MTUserID") && row["MTUserID"] != null)
                {
                    var userID = Convert.ToInt32(row["MTUserID"]);
                    affectedRows = QueryBuilder("TRNotification").Insert(new {
                        MTUserID = userID,
                        Subject = "Checklist Invitation",
                        Body = body,
                        CreatedByUserID = CurrentUserID(),
                        CreatedDateTime = DateTimeOffset.Now,
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Create Notification" : "Gagal Membuat Notifikasi";
                        return Json(jsonResponse);
                    }

                    // send email start
                    var emailTemplateCategory = "Crew Checklist Invite";
                    var crewInfo = ExecuteRow("SELECT MTCrew.Email, MTCrew.FullName FROM MTCrew WHERE MTCrew.ID = '" + crewID.ToString() + "'");
                    if (crewInfo["Email"] == null || crewInfo["FullName"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew email, full name cannot be empty" : "Email, nama lengkap crew tidak boleh kosong";
                        return Json(jsonResponse);
                    }
                    var email = new Email();
                    email.Sender = Config.SenderEmail;
                    email.Recipient = crewInfo["Email"].ToString();
                    var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
                    if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email template not found or the subject and message column is empty" : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
                        return Json(jsonResponse);
                    }
                    email.Subject = emailTemplate["Subject"].ToString();
                    email.Content = emailTemplate["Message"].ToString();
                    email.ReplaceContent("{{crewCandidateFullName}}", crewInfo["FullName"].ToString());
                    email.ReplaceContent("{{Checklist Invitation Date Time}}", date + ", " + time);
                    email.ReplaceContent("{{invite notes}}", notes);
                    if (Email.Mailer == null)
                    {
                        var smtpClient = new SmtpClient();
                        smtpClient.CheckCertificateRevocation = false;
                        Email.Mailer = smtpClient;
                    }
                    else if (Email.Mailer.CheckCertificateRevocation)
                    {
                        Email.Mailer.CheckCertificateRevocation = false;
                    }
                    bool isEmailSent = false;
                    Task.Run(async () =>
                    {
                        isEmailSent = await email.SendAsync();
                    }).GetAwaiter().GetResult();
                    if (isEmailSent)
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient, 
                            IsSent = 1,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient,
                            IsSent = 0,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                        jsonResponse.errorMessage = email.SendError;
                        return Json(jsonResponse);
                    }
                    // send email end
                    jsonResponse.success = true;
                    return Json(jsonResponse);
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // create notification for admin
    [HttpPost("add-notification-for-admin")]
    public IActionResult AddNotificationForAdmin([FromBody] AddNotificationForAdminRequest addNotificationForAdminRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() && IsAdmin())
        {
            string subject = addNotificationForAdminRequest.subject;
            string body = addNotificationForAdminRequest.body;
            string crewID = addNotificationForAdminRequest.crewID;
            try
            {
                int affectedRows = 0;
                if (crewID == "")
                {
                    affectedRows = QueryBuilder("TRNotification").Insert(new {
                        Subject = subject,
                        Body = body,
                        CreatedByUserID = CurrentUserID(),
                        CreatedDateTime = DateTimeOffset.Now,
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add Notification" : "Gagal Menambahkan Notifikasi";
                        return Json(jsonResponse);
                    }
                    jsonResponse.success = true;
                    return Json(jsonResponse);
                }
                else
                {
                    var row = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewID + "'");
                    if (row.ContainsKey("MTUserID") && row["MTUserID"] != null)
                    {
                        var userID = Convert.ToInt32(row["MTUserID"]);
                        affectedRows = QueryBuilder("TRNotification").Insert(new {
                            MTUserID = userID,
                            Subject = subject,
                            Body = body,
                            CreatedByUserID = CurrentUserID(),
                            CreatedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add Notification" : "Gagal Menambahkan Notifikasi";
                            return Json(jsonResponse);
                        }
                        jsonResponse.success = true;
                        return Json(jsonResponse);
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                        return Json(jsonResponse);
                    }
                }
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // approve crew checklist
    [HttpPost("approve-checklist")]
    public IActionResult ApproveChecklist([FromBody] ApproveChecklistRequest approveChecklistRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn())
        {
            string password = approveChecklistRequest.password;
            string userLevel = approveChecklistRequest.userLevel;
            int checklistID = approveChecklistRequest.checklistID;
            try
            {
                int affectedRows = 0;
                if (userLevel != "Assistant Manager PDE" && userLevel != "Crewing Manager")
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
                    return Json(jsonResponse);
                }
                var row = ExecuteRow("SELECT Password FROM MTUser WHERE ID = '" + CurrentUserID() + "'");
                if (row.ContainsKey("Password") && row["Password"] != null)
                {
                    string dbPassword = row["Password"].ToString();
                    if (!ComparePassword(dbPassword, password))
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Wrong Password" : "Kata Sandi Salah";
                        return Json(jsonResponse);
                    }
                    if (userLevel == "Assistant Manager PDE")
                    {
                        affectedRows = Execute(
                            "UPDATE TRChecklist " +
                            "SET AssistantManagerPdeReviewed = 1, " +
                            "    AssistantManagerPdeReviewedDate = @CurrentDate, " +
                            "    ApprovedByUserID1 = @CurrentUserID "+
                            "WHERE ID = @ChecklistID;",
                            new
                            {
                                CurrentDate = DateTime.Now,
                                CurrentUserID = CurrentUserID(),
                                ChecklistID = checklistID
                            }
                        );
                    }
                    else if (userLevel == "Crewing Manager")
                    {
                        affectedRows = Execute(
                            "UPDATE TRChecklist " +
                            "SET CrewingManagerApproval = 1, " +
                            "    CrewingManagerApprovalDate = @CurrentDate, " +
                            "    ApprovedByUserID2 = @CurrentUserID "+
                            "WHERE ID = @ChecklistID;",
                            new
                            {
                                CurrentDate = DateTime.Now,
                                CurrentUserID = CurrentUserID(),
                                ChecklistID = checklistID
                            }
                        );
                    }
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Approve Crew Candidate" : "Gagal Menyetujui Kandidat Kru";
                        return Json(jsonResponse);
                    }
                    jsonResponse.success = true;
                    return Json(jsonResponse);
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "User not found" : "User tidak ditemukan";
                    return Json(jsonResponse);
                }
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // get user level
    [HttpGet("get-user-level")]
    public IActionResult GetUserLevel()
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn())
        {
            try
            {
                if (CurrentUserLevel() == "")
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "User Level Not Found" : "Level Pengguna Tidak Ditemukan";
                    return Json(jsonResponse);
                }
                int currentUserLevelInt = Convert.ToInt32(CurrentUserLevel());
                dynamic userLevelQuery = QueryBuilder("MTUserLevel")
                    .Where("UserLevelID", currentUserLevelInt)
                    .Select("UserLevelName")
                    .FirstOrDefault();
                if ((object) userLevelQuery != null)
                {
                    if (userLevelQuery.UserLevelName == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "User Level Not Found" : "Level Pengguna Tidak Ditemukan";
                        return Json(jsonResponse);
                    }
                    else
                    {
                        jsonResponse.success = true;
                        jsonResponse.data = userLevelQuery.UserLevelName;
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "User Level Not Found" : "Level Pengguna Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // save seafarer id and crew agency to database
    [HttpPost("add-seafarer-id-and-crew-agency")]
    public IActionResult AddSeafarerIDAndCrewAgency([FromBody] SeafarerInputRequest seafarerInputRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            string seafarerID = seafarerInputRequest.seafarerID;
            int manningAgentID = seafarerInputRequest.manningAgentID;
            int crewID = seafarerInputRequest.crewID;
            int userID = -1;
            try
            {
                dynamic crewUserIDQuery = QueryBuilder("MTCrew")
                    .Where("ID", crewID)
                    .Select("MTUserID")
                    .FirstOrDefault();
                if ((object) crewUserIDQuery != null && (object) crewUserIDQuery.MTUserID != null)
                {
                    userID = Convert.ToInt32((object)crewUserIDQuery.MTUserID);
                    if (CurrentUserLevel() == "0")
                    {
                        if (crewUserIDQuery.MTUserID.ToString() != CurrentUserID())
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not Authorized" : "Tidak Diizinkan";
                            return Json(jsonResponse);
                        }
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                    return Json(jsonResponse);
                }
                dynamic sameIndividualCodeNumberQuery = QueryBuilder("MTCrew").Where("IndividualCodeNumber", seafarerID).Select("IndividualCodeNumber").FirstOrDefault();
                if ((object)sameIndividualCodeNumberQuery != null && (object)sameIndividualCodeNumberQuery.IndividualCodeNumber != null)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Seafarer ID must be unique" : "Seafarer ID harus unik";
                    return Json(jsonResponse);
                }
                int affectedRows = 0;
                affectedRows = Execute(
                    "UPDATE MTCrew " +
                    "SET IndividualCodeNumber = @IndividualCodeNumber, " +
                    "MTManningAgentID = @MTManningAgentID, " +
                    "LastUpdatedByUserID = @LastUpdatedByUserID, " +
                    "LastUpdatedDateTime = @LastUpdatedDateTime " +
                    "WHERE ID = @CrewID;",
                    new
                    {
                        IndividualCodeNumber = seafarerID,
                        MTManningAgentID = manningAgentID,
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                        CrewID = crewID
                    }
                );
                if (affectedRows == 0)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add Seafarer ID And Crew Agency" : "Gagal Menambahkan Seafarer ID Dan Agensi Kru";
                    return Json(jsonResponse);
                }
                affectedRows = Execute(
                    "UPDATE MTUser " +
                    "SET SeafarerID = @SeafarerID, " +
                    "MTManningAgentID = @MTManningAgentID " +
                    "WHERE ID = @UserID;",
                    new
                    {
                        SeafarerID = seafarerID,
                        MTManningAgentID = manningAgentID,
                        UserID = userID
                    }
                );
                if (affectedRows == 0)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add Seafarer ID And Crew Agency" : "Gagal Menambahkan Seafarer ID Dan Agensi Kru";
                    return Json(jsonResponse);
                }
                jsonResponse.success = true;
                return Json(jsonResponse);
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // load manning agent options(only the active ones)
    [HttpGet("manning-agent-options")]
    public IActionResult ManningAgentOptions()
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() )
        {
            try
            {
                var manningAgentQuery = ExecuteRows(
                    "SELECT " + 
                    "MTManningAgent.ID, " + 
                    "MTManningAgent.Name " +  
                    "FROM MTManningAgent " +
                    "WHERE MTManningAgent.Active = 1;"
                );
                jsonResponse.success = true;
                jsonResponse.data = manningAgentQuery.ToArray();
                return Json(jsonResponse);
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // gmandayu: disini mcu result page - accept
    [HttpPost("accept-single-crew-final")]
    public IActionResult AcceptSingleCrewFinal([FromBody] AcceptSingleFinalRequest acceptSingleFinalRequest)
    { 
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn())
        {
            string finalAcceptDateTime = acceptSingleFinalRequest.finalAcceptDateTime;
            string crewID = acceptSingleFinalRequest.crewIDArray;
            // int mcuResultID = acceptSingleFinalRequest.mcuResultID;
            try 
            {
                int affectedRows = 0;
                if (finalAcceptDateTime != "")
                {
                    affectedRows = Execute(
                        "UPDATE MTCrew "+
                        "SET FinalAcceptedDate = @FinalAcceptedDate, "+ 
                        "   EmployeeStatus = 'Candidate - Accepted', "+
                        "   LastUpdatedByUserID = @LastUpdatedByUserID, " +
                        "   LastUpdatedDateTime = @LastUpdatedDateTime " +
                        "WHERE ID = @CrewID;",
                        new 
                        {
                            FinalAcceptedDate = DateTimeOffset.Now,
                            // FinalAcceptedDate = finalAcceptDateTime,
                            LastUpdatedByUserID = CurrentUserID(),
                            // LastUpdatedDateTime = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:sszzz"),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                            CrewID = crewID
                        }
                    );
                    if (affectedRows == 0) {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to accept final crew" : "Gagal penerimaan akhir kru";
                        return Json(jsonResponse);
                    }
                    affectedRows = QueryBuilder("TREmployeeStatus").Insert(new
                    {
                        MTCrewID = crewID,
                        MTUserID = CurrentUserID(),
                        PreviousStatus = "Candidate - MCU",
                        CurrentStatus = "Candidate - Accepted",
                        ChangedDateTime = DateTimeOffset.Now,
                    });

                    // gmandayu: Update ke tabel MTRecruitmentStatusTracking
                    // 28 Juli 2023
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewID)
                        .WhereIn("MTRecruitmentStatusID", new[] { 115, 116 })
                        .Update(new
                        {
                            Flag = 3,
                            FlagDescription = "Dibatalkan",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                            .Where("MTCrewID", crewID)
                            .Where("MTRecruitmentStatusID", 117)
                            .Update(new
                            {
                                Flag = 1,
                                FlagDescription = "Selesai",
                                LastUpdatedByUserID = CurrentUserID(),
                                LastUpdatedDateTime = DateTimeOffset.Now,
                            });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") 
                            ? "Failed to Update Crew Tracking Status" 
                            : "Gagal Mengubah Data Pelacakan Status Kru";
                        return Json(jsonResponse);
                    }
                    // gmandayu: code ends here

                    // FIXME:
                    string subject = "Final Acceptance Ceremonial Invitation";
                    string body = "Please come on Final Acceptance Ceremonial Invitation process.";
                    var row = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewID + "'");
                    if (row.ContainsKey("MTUserID") && row["MTUserID"] != null)
                    {
                        var userID = Convert.ToInt32(row["MTUserID"]);
                        affectedRows = QueryBuilder("TRNotification").Insert(new
                        {
                            MTUserID = userID,
                            Subject = subject,
                            Body = body,
                            CreatedByUserID = CurrentUserID(),
                            CreatedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Add Acceptence Ceremonial Invitation Schedule" : "Gagal Menambahkan Jadwal Acceptence Ceremonial Invitation";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                        return Json(jsonResponse);
                    }

                    // send email start
                    var emailTemplateCategory = "Crew Accepted";
                    var crewInfo = ExecuteRow("SELECT MTCrew.Email, MTCrew.FullName, MTRank.Name AS RankAppliedFor FROM MTCrew INNER JOIN MTRank ON MTCrew.RankAppliedFor_RankID = MTRank.ID WHERE MTCrew.ID = '" + crewID + "'");
                    if (crewInfo["Email"] == null || crewInfo["FullName"] == null || crewInfo["RankAppliedFor"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew email, full name, and rank applied for cannot be empty" : "Email, nama lengkap, dan rank yang akan dipilih crew tidak boleh kosong";
                        return Json(jsonResponse);
                    }
                    var email = new Email();
                    email.Sender = Config.SenderEmail;
                    email.Recipient = crewInfo["Email"].ToString();
                    var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
                    if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email template not found or the subject and message column is empty" : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
                        return Json(jsonResponse);
                    }
                    email.Subject = emailTemplate["Subject"].ToString();
                    email.Subject = email.Subject.Replace("{{rankAppliedFor}}", crewInfo["RankAppliedFor"].ToString());
                    email.Content = emailTemplate["Message"].ToString();
                    email.ReplaceContent("{{crewCandidateFullName}}", crewInfo["FullName"].ToString());
                    email.ReplaceContent("{{rankAppliedFor}}", crewInfo["RankAppliedFor"].ToString());
                    if (Email.Mailer == null)
                    {
                        var smtpClient = new SmtpClient();
                        smtpClient.CheckCertificateRevocation = false;
                        Email.Mailer = smtpClient;
                    }
                    else if (Email.Mailer.CheckCertificateRevocation)
                    {
                        Email.Mailer.CheckCertificateRevocation = false;
                    }
                    bool isEmailSent = false;
                    Task.Run(async () =>
                    {
                        isEmailSent = await email.SendAsync();
                    }).GetAwaiter().GetResult();
                    if (isEmailSent)
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient, 
                            IsSent = 1,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewID,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient,
                            IsSent = 0,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                        jsonResponse.errorMessage = email.SendError;
                        return Json(jsonResponse);
                    }
                    // send email end

                    // endpoint return
                    jsonResponse.success = true;
                    return Json(jsonResponse);
                }
            }
            catch (Exception ex) 
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
        return Json(jsonResponse);
    }

    // gmandayu: do something about revised actions.
    [HttpPost("revise-multiple-crew")]
    public IActionResult RevisedMultipleCrew([FromBody] RevisedMultipleCrewRequest revisedMultipleCrewRequest)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn())
        {
            string revisedReason = revisedMultipleCrewRequest.revisedReason;
            IEnumerable<dynamic> deserializedCrewIDArray = (IEnumerable<dynamic>)JsonConvert.DeserializeObject(revisedMultipleCrewRequest.crewIDArray);
            try
            {
                foreach (dynamic crewIdDynamic in deserializedCrewIDArray)
                {
                    string crewId = crewIdDynamic.ToString();
                    int affectedRows = Execute(
                        "UPDATE MTCrew " +
                            "SET RevisedReason = @RevisedReason, " +
                            "RevisedDateTime = @RevisedDateTime, " +
                            "EmployeeStatus = 'Candidate - Draft', " +
                            "LastUpdatedByUserID = @LastUpdatedByUserID, " +
                            "LastUpdatedDateTime = @LastUpdatedDateTime " +
                            "WHERE ID = @CrewID;",
                        new
                        {
                            RevisedReason = revisedReason,
                            RevisedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                            CrewID = crewId
                        }
                    );
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Submit Revised Request" : "Gagal Mengajukan Peninjauan Ulang";
                        return Json(jsonResponse);
                    }

                    // gmandayu: Update ke tabel MTRecruitmentStatusTracking
                    // 28 Juli 2023
                    affectedRows += QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", crewId)
                        .Where("MTRecruitmentStatusID", 101) // Submitted
                        .Update(new
                        {
                            Flag = 2,
                            FlagDescription = "Menunggu",
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                            ? "Failed to Update Crew Tracking Status"
                            : "Gagal Mengubah Data Pelacakan Status Kru";
                        return Json(jsonResponse);
                    }

                    // notifikasi untuk revised
                    string notificationSubject = "Revised Notification";
                    string notificationBody = "Revised Reason: <b>" + revisedReason + "</b><br><br>" +
                        "<br>Thank you for taking the time to apply at our company. " +
                        "<br>After careful consideration, we regret to inform you that your application has not been successful. " +
                        "<br>We genuinely appreciate the effort and time you invested in applying for a position with our company. " +
                        "<br>While we are unable to offer you a position at this time, we encourage you to <b>review and revise your registration data as needed.</b> " +
                        "<br>Please make the necessary changes and resubmit your application. " +
                        "<br>Thank you once again for your interest in joining our company.";
                    var userIDRow = ExecuteRow("SELECT MTUserID FROM MTCrew WHERE ID = '" + crewId.ToString() + "'");
                    if (userIDRow.ContainsKey("MTUserID") && userIDRow["MTUserID"] != null)
                    {
                        var userID = Convert.ToInt32(userIDRow["MTUserID"]);
                        affectedRows = QueryBuilder("TRNotification").Insert(new {
                            MTUserID = userID,
                            Subject = notificationSubject,
                            Body = notificationBody,
                            CreatedByUserID = CurrentUserID(),
                            CreatedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Create Data Revised Notification" : "Gagal Membuat Notifikasi Revisi Data";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew Not Found" : "Kru Tidak Ditemukan";
                        return Json(jsonResponse);
                    }
                    affectedRows = QueryBuilder("TREmployeeStatus").Insert(new
                    {
                        MTCrewID = crewId,
                        MTUserID = CurrentUserID(),
                        PreviousStatus = "Candidate - Submitted",
                        CurrentStatus = "Candidate - Draft",
                        ChangedDateTime = DateTimeOffset.Now,
                    });
                    if (affectedRows == 0)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Update Crew Employee Status History" : "Gagal Mengubah Data Histori Status Karyawan Kru";
                        return Json(jsonResponse);
                    }

                    // send email start
                    var emailTemplateCategory = "Crew Form 560 Need to Revised";
                    var crewInfo = ExecuteRow("SELECT MTCrew.Email, MTCrew.FullName FROM MTCrew WHERE MTCrew.ID = '" + crewId.ToString() + "'");
                    if (crewInfo["Email"] == null || crewInfo["FullName"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Crew email, full name cannot be empty" : "Email, nama lengkap crew tidak boleh kosong";
                        return Json(jsonResponse);
                    }
                    var email = new Email();
                    email.Sender = Config.SenderEmail;
                    email.Recipient = crewInfo["Email"].ToString();
                    var emailTemplate = ExecuteRow("SELECT Subject, Message FROM MTEmailTemplate WHERE Category = '" + emailTemplateCategory + "';");
                    if (emailTemplate["Subject"] == null || emailTemplate["Message"] == null)
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email template not found or the subject and message column is empty" : "Template email tidak ditemukan atau kolom subject dan message bernilai kosong";
                        return Json(jsonResponse);
                    }
                    email.Subject = emailTemplate["Subject"].ToString();
                    email.Content = emailTemplate["Message"].ToString();
                    email.ReplaceContent("{{crewCandidateFullName}}", crewInfo["FullName"].ToString());
                    email.ReplaceContent("{{revised note}}", revisedReason);
                    if (Email.Mailer == null)
                    {
                        var smtpClient = new SmtpClient();
                        smtpClient.CheckCertificateRevocation = false;
                        Email.Mailer = smtpClient;
                    }
                    else if (Email.Mailer.CheckCertificateRevocation)
                    {
                        Email.Mailer.CheckCertificateRevocation = false;
                    }
                    bool isEmailSent = false;
                    Task.Run(async () =>
                    {
                        isEmailSent = await email.SendAsync();
                    }).GetAwaiter().GetResult();
                    if (isEmailSent)
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewId,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient, 
                            IsSent = 1,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = crewId,
                            Subject = email.Subject,
                            Message = email.Content,
                            To = email.Recipient,
                            IsSent = 0,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                        jsonResponse.errorMessage = email.SendError;
                        return Json(jsonResponse);
                    }
                    // send email end
                }
                jsonResponse.success = true;
                return Json(jsonResponse);
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }

    // gmandayu: get TRChecklistId.
    [HttpGet("get-trchecklist-id")]
    public IActionResult GetTrChecklistId([FromQuery] int crewId) 
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = null;
        jsonResponse.errorMessage = "";
        if(IsLoggedIn())
        {
            var crewQuery = QueryBuilder("TRChecklist")
                .Where("MTCrewID", crewId)
                .Select("ID")
                .FirstOrDefault();
            if(crewQuery != null && crewQuery.ID != null)
            {
                jsonResponse.success = true;
                jsonResponse.data = crewQuery.ID;
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Data MCU Result Not Found" : "Data Pemeriksaan Medis Tidak Ditemukan";
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    // gmandayu: get TRMcuResultId.
    [HttpGet("get-trmcuresult-id")]
    public IActionResult GetTrMcuResultId([FromQuery] int crewId)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = null;
        jsonResponse.errorMessage = "";
        if (IsLoggedIn())
        {
            var crewQuery = QueryBuilder("TRMCUResult")
                .Where("MTCrew_ID", crewId)
                .Select("McuResult_ID")
                .FirstOrDefault();
            if (crewQuery != null && crewQuery.McuResult_ID != null)
            {
                jsonResponse.success = true;
                jsonResponse.data = crewQuery.McuResult_ID;
            }
            else
            {
                jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Data MCU Result Not Found" : "Data Pemeriksaan Medis Tidak Ditemukan";
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }

    [HttpPost("save-draft-checklist-tracking-include")]
    public IActionResult SaveDraftChecklistTrackingInclude([FromQuery] ChecklistItemsRequest checklistItemsRequest)
    {
        string employeeStatus = checklistItemsRequest.EmployeeStatus;
        int crewID = checklistItemsRequest.CrewID;
        if (employeeStatus == "Candidate - PDE Reviewed")
        {
            var checklistItems = QueryBuilder("TRChecklist")
            .Where("MTCrewID", crewID)
            .Get();
            int affectedRows = 0;
            foreach (var item in checklistItems)
            {
                int activity10 = item.Activity10, activity11 = item.Activity11, activity12 = item.Activity12, activity13 = item.Activity13, activity14 = item.Activity14,
                    activity20 = item.Activity20, activity30 = item.Activity30, activity40 = item.Activity40, activity50 = item.Activity50, activity60 = item.Activity60,
                    activity70 = item.Activity70;
                int flag;
                string flagDescription;
                if (activity10 == 1 && activity11 == 1 && activity12 == 1 && activity13 == 1 && activity14 == 1 && activity20 == 1 && activity30 == 1 && activity40 == 1 && activity50 == 1 && activity60 == 1 && activity70 == 1)
                {
                    flag = 1;
                    flagDescription = "Selesai";
                }
                else
                {
                    flag = 2;
                    flagDescription = "Menunggu";
                }
                affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                    .Where("MTCrewID", crewID)
                    .WhereIn("MTCrewRecruitmentStatusID", new int[] { 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113 })
                    .Update(new
                    {
                        Flag = flag,
                        FlagDescription = flagDescription,
                        LastUpdatedByUserID = CurrentUserID(),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                    });
                if (affectedRows == 0)
                {
                    throw new Exception((CurrentLanguage == "en-US") ? "Failed to Update Crew Tracking Status" : "Gagal Mengubah Data Pelacakan Status Kru");
                }
            }
            affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                .Where("MTCrewID", crewID)
                .Where("MTRecruitmentStatusID", 114)
                .Update(new
                {
                    Flag = 1,
                    FlagDescription = "Selesai",
                    LastUpdatedByUserID = CurrentUserID(),
                    LastUpdatedDateTime = DateTimeOffset.Now,
                });
            if (affectedRows == 0)
            {
                throw new Exception((CurrentLanguage == "en-US") ? "Failed to Update Crew Tracking Status" : "Gagal Mengubah Data Pelacakan Status Kru");
            }
        }
        return Ok("Data berhasil disimpan");
    }

    [HttpGet("get-employee-status")]
    public IActionResult GetEmployeeStatus()
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = null;
        jsonResponse.errorMessage = "";
        if (IsLoggedIn())
        {
            dynamic getUserLevelID = QueryBuilder("MTUser")
                .Where("ID", CurrentUserID())
                .Select("MTUserLevelID")
                .FirstOrDefault();
            if (getUserLevelID.MTUserLevelID != null && getUserLevelID != null)
            {
                var userLevelID = getUserLevelID.MTUserLevelID;
                if (userLevelID == 0) {
                    dynamic query = QueryBuilder("MTCrew")
                        .Where("MTUserID", CurrentUserID())
                        .Select("EmployeeStatus")
                        .FirstOrDefault();
                    if (query.EmployeeStatus != null && query != null)
                    {
                        var employeeStatus = query.EmployeeStatus;
                        jsonResponse.success = true;
                        jsonResponse.data = employeeStatus;
                    }
                    else
                    {
                        jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                            ? "Crew Employee Status is not found"
                            : "Status Karyawan kru tidak ditemukan";
                    }
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                        ? "Not authorized"
                        : "Tidak diizinkan";
                }
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US")
                ? "Not authorized"
                : "Tidak diizinkan";
        }
        return Json(jsonResponse);
    }
}

public partial class DashboardController : ApiController 
{
    // gmandayu: disini dashboard
    [HttpGet("get-admin-name")]
    public IActionResult GetAdminName()
    {
        try
        {
            string currentUserId = CurrentUserID(); // Mengambil ID pengguna saat ini
            QueryBuilder? queryBuilder = QueryBuilder("MTUser")
                .Select("FullName")
                .Where("ID", currentUserId);
            if (queryBuilder != null)
            {
                string adminName = QueryExtensions.FirstOrDefault<string>(queryBuilder);
                if (adminName != null)
                {
                    // Buat respons JSON dengan nama admin yang diperoleh
                    JsonResponse jsonResponse = new JsonResponse();
                    jsonResponse.success = true;
                    jsonResponse.data = adminName;
                    return Json(jsonResponse);
                }
                else
                {
                    // Jika nama admin null, berikan respons kosong dengan success false
                    JsonResponse emptyResponse = new JsonResponse();
                    emptyResponse.success = false;
                    emptyResponse.data = null;
                    return Json(emptyResponse);
                }
            }
            else
            {
                throw new Exception("QueryBuilder is null");
            }
        }
        catch (Exception ex)
        {
            // Jika terjadi exception, berikan respons error dengan pesan kesalahan
            JsonResponse errorResponse = new JsonResponse();
            errorResponse.success = false;
            errorResponse.errorMessage = ex.Message;
            return StatusCode(500, errorResponse);
        }
    }

    [HttpGet("get-count-total-crew")]
    public IActionResult GetCountTotalCrew()
    {
        try
        { 
            QueryBuilder? queryBuilder = QueryBuilder("MTCrew");
            if (queryBuilder != null) 
            {
                int? crewCount = QueryExtensions.Count<int>(queryBuilder!);

                // Set "0" kalau crewCount adalah null lur..
                int count = crewCount ?? 0;
                JsonResponse jsonResponse = new JsonResponse();
                jsonResponse.success = true;
                jsonResponse.data = count;
                return Json(jsonResponse);
            }
            else
            {
                throw new Exception("QueryBuilder is null");
            }
        }
        catch (Exception ex)
        {
            JsonResponse errorResponse = new JsonResponse();
            errorResponse.success = false;
            errorResponse.errorMessage = ex.Message;
            return StatusCode(500, errorResponse);
        }
    }

    [HttpGet("get-count-candidate-draft-crew")]
    public IActionResult GetCountCandidateDraftCrew([FromQuery] string employeeStatus)
    {
        try
        {
            QueryBuilder? queryBuilder = QueryBuilder("MTCrew")
                .Where("EmployeeStatus", employeeStatus);
            if (queryBuilder != null)
            {
                int? crewCount = QueryExtensions.Count<int?>(queryBuilder!);

                // Set "0" kalau crewCount adalah null lur..
                int count = crewCount ?? 0;
                JsonResponse jsonResponse = new JsonResponse();
                jsonResponse.success = true;
                jsonResponse.data = count;
                return Json(jsonResponse);
            }
            else
            {
                throw new Exception("QueryBuilder is null");
            }
        }
        catch (Exception ex)
        {
            JsonResponse errorResponse = new JsonResponse();
            errorResponse.success = false;
            errorResponse.errorMessage = ex.Message;
            return StatusCode(500, errorResponse);
        }
    }

    [HttpGet("get-count-candidate-submitted-crew")]
    public IActionResult GetCountCandidateSubmittedCrew([FromQuery] string employeeStatus)
    {
        try
        {
            QueryBuilder? queryBuilder = QueryBuilder("MTCrew")
                .Where("MTCrew.EmployeeStatus", employeeStatus);
            if (queryBuilder != null)
            {
                int? crewCount = QueryExtensions.Count<int?>(queryBuilder!);

                // Set "0" kalau crewCount adalah null lur..
                int count = crewCount ?? 0;
                JsonResponse jsonResponse = new JsonResponse();
                jsonResponse.success = true;
                jsonResponse.data = count;
                return Json(jsonResponse);
            }
            else
            {
                throw new Exception("QueryBuilder is null");
            }
        }
        catch (Exception ex)
        {
            JsonResponse errorResponse = new JsonResponse();
            errorResponse.success = false;
            errorResponse.errorMessage = ex.Message;
            return StatusCode(500, errorResponse);
        }
    }

    [HttpGet("get-count-agency-reviewed-crew")]
    public IActionResult GetCountAgencyReviewedCrew([FromQuery] string employeeStatus) 
    {
        try 
        {
            QueryBuilder? queryBuilder = QueryBuilder("MTCrew")
                .Where("MTCrew.EmployeeStatus", employeeStatus);
            if (queryBuilder != null)
            {
                int? crewCount = QueryExtensions.Count<int?>(queryBuilder!);
                int count = crewCount ?? 0;
                JsonResponse jsonResponse = new JsonResponse();
                jsonResponse.success = true;
                jsonResponse.data = count;
                return Json(jsonResponse);
            }
            else
            { throw new Exception("QueryBuilder is null"); }
        }
        catch (Exception ex) 
        { 
            JsonResponse errorResponse = new JsonResponse();
            errorResponse.success = false;
            errorResponse.errorMessage = ex.Message;
            return StatusCode(500, errorResponse);
        }
    }

    [HttpGet("get-records-change-count")]
    public IActionResult GetRecordsChangeCount()
    {
        JsonResponse jsonResponse = new JsonResponse
        {
            data = null,
            success = false,
            errorMessage = ""
        };
        try
        {
            QueryBuilder? updateTracking = QueryBuilder("UpdateTracking");
            if (updateTracking != null)
            {
                int? recordsChangeCount = QueryExtensions.Count<int>(updateTracking!);
                int count = recordsChangeCount ?? 0;
                jsonResponse.success = true;
                jsonResponse.data = count;
            }
        }
        catch (Exception ex)
        {
            jsonResponse.errorMessage = ex.Message;
        }
        return Json(jsonResponse);
    }

    [HttpGet("get-count-checklist-crew")]
    public IActionResult GetCountChecklistCrew([FromQuery] string employeeStatus)
    {
        try
        {
            QueryBuilder? queryBuilder = QueryBuilder("TRChecklist")
                .Join("MTCrew", "TRChecklist.MTCrewID", "MTCrew.ID")
                .Where("MTCrew.EmployeeStatus", employeeStatus);
            if (queryBuilder != null)
            {
                int? crewCount = QueryExtensions.Count<int?>(queryBuilder!);

                // Set "0" kalau crewCount adalah null lur..
                int count = crewCount ?? 0;
                JsonResponse jsonResponse = new JsonResponse();
                jsonResponse.success = true;
                jsonResponse.data = count;
                return Json(jsonResponse);
            }
            else
            {
                throw new Exception("QueryBuilder is null"); 
            }
        }
        catch (Exception ex)
        {
            JsonResponse errorResponse = new JsonResponse();
            errorResponse.success = false;
            errorResponse.errorMessage = ex.Message;
            return StatusCode(500, errorResponse);
        }
    }

    [HttpGet("get-count-candidate-mcu-crew")]
    public IActionResult GetCountCandidateMcuCrew([FromQuery] string employeeStatus)
    {
        try
        {
            QueryBuilder? queryBuilder = QueryBuilder("MTCrew")
                .Where("MTCrew.EmployeeStatus", employeeStatus);
            if (queryBuilder != null)
            {
                int? crewCount = QueryExtensions.Count<int?>(queryBuilder!);

                // Set "0" kalau crewCount adalah null lur..
                int count = crewCount ?? 0;
                JsonResponse jsonResponse = new JsonResponse();
                jsonResponse.success = true;
                jsonResponse.data = count;
                return Json(jsonResponse);
            }
            else
            {
                throw new Exception("QueryBuilder is null");
            }
        }
        catch (Exception ex)
        {
            JsonResponse errorResponse = new JsonResponse();
            errorResponse.success = false;
            errorResponse.errorMessage = ex.Message;
            return StatusCode(500, errorResponse);
        }
    }

    /* ini sementara untuk general (accept, reject, reject temporary, blacklist). 
     * mungkin nanti dibuat lebih spesifik.
     */
    [HttpGet("get-crew-count")]
    public IActionResult GetCrewCount([FromQuery] string employeeStatus)
    {
        try
        {
            /*
            if (!IsLoggedIn())
            {
                throw new UnauthorizedAccessException((CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan");
            }
            */
            QueryBuilder? queryBuilder = QueryBuilder("MTCrew")
                .Where("MTCrew.EmployeeStatus", employeeStatus);
            if (queryBuilder != null)
            {
                int? crewCount = QueryExtensions.Count<int?>(queryBuilder!);

                // Set "0" kalau crewCount adalah null lur..
                int count = crewCount ?? 0;
                JsonResponse jsonResponse = new JsonResponse();
                jsonResponse.success = true;
                jsonResponse.data = count;
                return Json(jsonResponse);
            }
            else
            {
                throw new Exception("QueryBuilder is null");
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            JsonResponse errorResponse = new JsonResponse();
            errorResponse.success = false;
            errorResponse.errorMessage = ex.Message;
            return StatusCode(401, errorResponse);
        }
        catch (Exception ex)
        {
            JsonResponse errorResponse = new JsonResponse();
            errorResponse.success = false;
            errorResponse.errorMessage = ex.Message;
            return StatusCode(500, errorResponse);
        }
    }
}

// gmandayu: notification need to read.
public partial class NotificationController : ApiController 
{
    [HttpGet("get-user-level-notification")]
    public IActionResult GetUserLevelNotification() 
    { 
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (!IsLoggedIn())
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
        else
        {
            try
            {
                string currentUser = CurrentUserID();
                dynamic getUserLevel = QueryBuilder("MTUser")
                    .Where("ID", currentUser)
                    .Select("MTUserLevelID")
                    .FirstOrDefault();
                if (getUserLevel != null) 
                {
                    if(getUserLevel == "0")
                    {
                        jsonResponse.success = true;
                        return Json(jsonResponse);
                    }
                    else 
                    {
                        jsonResponse.success = false;
                        jsonResponse.errorMessage = "Hanya crew.";
                        return Json(jsonResponse);
                    }
                }
                else
                {
                    jsonResponse.success = false;
                    jsonResponse.errorMessage = "User level tidak ditemukan.";
                    return Json(jsonResponse);
                }
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
    }

    [HttpGet("unread-notification")]
    public IActionResult GetUnreadNotification()
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (!IsLoggedIn())
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
        else 
        {
            try
            {
                string currentUser = CurrentUserID();
                dynamic getNotificationQuery = QueryBuilder("TRNotification")
                    .Where("MarkAsRead", null)
                    .OrWhere("MarkAsRead", "<>", 1)
                    .Where("MTUserID", CurrentUserID())
                    .Select("*")
                    .FirstOrDefault();
                if (getNotificationQuery != null)
                {
                    jsonResponse.success = true;
                    return Json(jsonResponse);
                }
                else
                {
                    jsonResponse.success = false;
                    jsonResponse.errorMessage = "Tidak ada notifikasi yang belum dibaca.";
                    return Json(jsonResponse);
                }
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
    }

    [HttpPost("notification-mark-as-read")]
    public IActionResult NotificationMarkAsRead([FromQuery] int notificationId)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (!IsLoggedIn())
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
        else 
        {
            try
            {
                int affectedRows = 0;
                affectedRows += Execute("UPDATE TRNotification "+
                    "SET MarkAsRead = '1' "+
                    "WHERE ID = @NotificationId;", 
                    new {
                        NotificationId = notificationId 
                    }
                );
                if (affectedRows == 0)
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to mark notification as read." : "Gagal menandai notifikasi sebagai telah dibaca.";
                    return Json(jsonResponse);
                }
                jsonResponse.success = true;
                return Json(jsonResponse);
            }
            catch (Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
    }
}

public partial class EmailController : ApiController 
{
    // resend email
    [HttpPost("resend-email")]
    public IActionResult ResendEmail([FromQuery] int emailID)
    {
        JsonResponse jsonResponse = new JsonResponse();
        jsonResponse.success = false;
        jsonResponse.data = new object();
        jsonResponse.errorMessage = "";
        if (IsLoggedIn() && IsAdmin())
        {
            try
            {
                dynamic emailHistoryQuery = QueryBuilder("TREmailHistory")
                    .Where("ID", emailID)
                    .Select("MTCrew_ID", "To", "Subject", "Message")
                    .FirstOrDefault();
                if ((object) emailHistoryQuery != null)
                {
                    var email = new Email();
                    email.Sender = Config.SenderEmail;
                    email.Recipient = ConvertToString(emailHistoryQuery.To);
                    email.Subject = ConvertToString(emailHistoryQuery.Subject);
                    email.Content = ConvertToString(emailHistoryQuery.Message);
                    if (Email.Mailer == null)
                    {
                        var smtpClient = new SmtpClient();
                        smtpClient.CheckCertificateRevocation = false;
                        Email.Mailer = smtpClient;
                    }
                    else if (Email.Mailer.CheckCertificateRevocation)
                    {
                        Email.Mailer.CheckCertificateRevocation = false;
                    }
                    bool isEmailSent = false;
                    Task.Run(async () =>
                    {
                        isEmailSent = await email.SendAsync();
                    }).GetAwaiter().GetResult();
                    int affectedRows = 0;
                    if (isEmailSent)
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = ConvertToString(emailHistoryQuery.MTCrew_ID),
                            Subject = ConvertToString(emailHistoryQuery.Subject),
                            Message = ConvertToString(emailHistoryQuery.Message),
                            To = ConvertToString(emailHistoryQuery.To), 
                            IsSent = 1,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                    }
                    else
                    {
                        affectedRows = QueryBuilder("TREmailHistory").Insert(new
                        {
                            MTCrew_ID = ConvertToString(emailHistoryQuery.MTCrew_ID),
                            Subject = ConvertToString(emailHistoryQuery.Subject),
                            Message = ConvertToString(emailHistoryQuery.Message),
                            To = ConvertToString(emailHistoryQuery.To), 
                            IsSent = 0,
                            SentDateTime = DateTimeOffset.Now
                        });
                        if (affectedRows == 0)
                        {
                            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Failed to Insert Email To Database" : "Gagal Menyimpan Email Ke Database";
                            return Json(jsonResponse);
                        }
                        jsonResponse.errorMessage = email.SendError;
                        return Json(jsonResponse);
                    }
                    jsonResponse.success = true;
                    return Json(jsonResponse);
                }
                else
                {
                    jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Email Not Found" : "Email Tidak Ditemukan";
                    return Json(jsonResponse);
                }
            }
            catch(Exception ex)
            {
                jsonResponse.errorMessage = ex.Message;
                return Json(jsonResponse);
            }
        }
        else
        {
            jsonResponse.errorMessage = (CurrentLanguage == "en-US") ? "Not authorized" : "Tidak diizinkan";
            return Json(jsonResponse);
        }
    }
}
