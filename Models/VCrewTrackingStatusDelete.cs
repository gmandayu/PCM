namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// vCrewTrackingStatusDelete
    /// </summary>
    public static VCrewTrackingStatusDelete vCrewTrackingStatusDelete
    {
        get => HttpData.Get<VCrewTrackingStatusDelete>("vCrewTrackingStatusDelete")!;
        set => HttpData["vCrewTrackingStatusDelete"] = value;
    }

    /// <summary>
    /// Page class for v_CrewTrackingStatus
    /// </summary>
    public class VCrewTrackingStatusDelete : VCrewTrackingStatusDeleteBase
    {
        // Constructor
        public VCrewTrackingStatusDelete(Controller controller) : base(controller)
        {
        }

        // Constructor
        public VCrewTrackingStatusDelete() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class VCrewTrackingStatusDeleteBase : VCrewTrackingStatus
    {
        // Page ID
        public string PageID = "delete";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "v_CrewTrackingStatus";

        // Page object name
        public string PageObjName = "vCrewTrackingStatusDelete";

        // Title
        public string? Title = null; // Title for <title> tag

        // Page headings
        public string Heading = "";

        public string Subheading = "";

        public string PageHeader = "";

        public string PageFooter = "";

        // Token
        public string? Token = null; // DN

        public bool CheckToken = Config.CheckToken;

        // Action result // DN
        public IActionResult? ActionResult;

        // Cache // DN
        public IMemoryCache? Cache;

        // Page layout
        public bool UseLayout = true;

        // Page terminated // DN
        private bool _terminated = false;

        // Is terminated
        public bool IsTerminated => _terminated;

        // Is lookup
        public bool IsLookup => IsApi() && RouteValues.TryGetValue("controller", out object? name) && SameText(name, Config.ApiLookupAction);

        // Is AutoFill
        public bool IsAutoFill => IsLookup && SameText(Post("ajax"), "autofill");

        // Is AutoSuggest
        public bool IsAutoSuggest => IsLookup && SameText(Post("ajax"), "autosuggest");

        // Is modal lookup
        public bool IsModalLookup => IsLookup && SameText(Post("ajax"), "modal");

        // Page URL
        private string _pageUrl = "";

        // Constructor
        public VCrewTrackingStatusDeleteBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (vCrewTrackingStatus)
            if (vCrewTrackingStatus == null || vCrewTrackingStatus is VCrewTrackingStatus)
                vCrewTrackingStatus = this;

            // Start time
            StartTime = Environment.TickCount;

            // Debug message
            LoadDebugMessage();

            // Open connection
            Conn = Connection; // DN

            // User table object (MTUser)
            UserTable = Resolve("usertable")!;
            UserTableConn = GetConnection(UserTable.DbId);
        }

        // Page action result
        public IActionResult PageResult()
        {
            if (ActionResult != null)
                return ActionResult;
            SetupMenus();
            return Controller.View();
        }

        // Page heading
        public string PageHeading
        {
            get {
                if (!Empty(Heading))
                    return Heading;
                else if (!Empty(Caption))
                    return Caption;
                else
                    return "";
            }
        }

        // Page subheading
        public string PageSubheading
        {
            get {
                if (!Empty(Subheading))
                    return Subheading;
                if (!Empty(TableName))
                    return Language.Phrase(PageID);
                return "";
            }
        }

        // Page name
        public string PageName => "VCrewTrackingStatusDelete";

        // Page URL
        public string PageUrl
        {
            get {
                if (_pageUrl == "") {
                    _pageUrl = PageName + "?";
                }
                return _pageUrl;
            }
        }

        // Show Page Header
        public IHtmlContent ShowPageHeader()
        {
            string header = PageHeader;
            PageDataRendering(ref header);
            if (!Empty(header)) // Header exists, display
                return new HtmlString("<p id=\"ew-page-header\">" + header + "</p>");
            return HtmlString.Empty;
        }

        // Show Page Footer
        public IHtmlContent ShowPageFooter()
        {
            string footer = PageFooter;
            PageDataRendered(ref footer);
            if (!Empty(footer)) // Footer exists, display
                return new HtmlString("<p id=\"ew-page-footer\">" + footer + "</p>");
            return HtmlString.Empty;
        }

        // Valid post
        protected async Task<bool> ValidPost() => !CheckToken || !IsPost() || IsApi() || Antiforgery != null && HttpContext != null && await Antiforgery.IsRequestValidAsync(HttpContext);

        // Create token
        public void CreateToken()
        {
            Token ??= HttpContext != null ? Antiforgery?.GetAndStoreTokens(HttpContext).RequestToken : null;
            CurrentToken = Token ?? ""; // Save to global variable
        }

        // Set field visibility
        public void SetVisibility()
        {
            ID.Visible = false;
            IndividualCodeNumber.SetVisibility();
            FullName.SetVisibility();
            RequiredPhoto.SetVisibility();
            VisaPhoto.SetVisibility();
            Gender.SetVisibility();
            RankAppliedFor.SetVisibility();
            WillAcceptLowRank.SetVisibility();
            EmployeeStatus.SetVisibility();
            Draft.SetVisibility();
            Submitted.SetVisibility();
            AgencyReviewed.SetVisibility();
            PDEReviewed.SetVisibility();
            RegistrationForm.SetVisibility();
            PreScreeningInterview.SetVisibility();
            MinimumRecruitmentCheck.SetVisibility();
            EngagementChecklist.SetVisibility();
            COCAuthenticity.SetVisibility();
            CESTest.SetVisibility();
            PyschometricTest.SetVisibility();
            CrewWatchlist.SetVisibility();
            PreviousAppraisalReport.SetVisibility();
            ContractBackgroundCheck.SetVisibility();
            EnglishProficiencyTestOrMarline.SetVisibility();
            Interviewed.SetVisibility();
            Approved.SetVisibility();
            MedicalCheckup.SetVisibility();
            CreatedBy.Visible = false;
            LastUpdatedBy.Visible = false;
        }

        // Constructor
        public VCrewTrackingStatusDeleteBase(Controller? controller = null): this() { // DN
            if (controller != null)
                Controller = controller;
        }

        /// <summary>
        /// Terminate page
        /// </summary>
        /// <param name="url">URL to rediect to</param>
        /// <returns>Page result</returns>
        public override IActionResult Terminate(string url = "") { // DN
            if (_terminated) // DN
                return new EmptyResult();

            // Page Unload event
            PageUnload();

            // Global Page Unloaded event
            PageUnloaded();
            if (!IsApi())
                PageRedirecting(ref url);

            // Gargage collection
            Collect(); // DN

            // Terminate
            _terminated = true; // DN

            // Return for API
            if (IsApi()) {
                var result = new Dictionary<string, string> { { "version", Config.ProductVersion } };
                if (!Empty(url)) // Add url
                    result.Add("url", GetUrl(url));
                foreach (var (key, value) in GetMessages()) // Add messages
                    result.Add(key, value);
                return Controller.Json(result);
            } else if (ActionResult != null) { // Check action result
                return ActionResult;
            }

            // Go to URL if specified
            if (!Empty(url)) {
                if (!Config.Debug)
                    ResponseClear();
                if (Response != null && !Response.HasStarted) {
                    SaveDebugMessage();
                    return Controller.LocalRedirect(AppPath(url));
                }
            }
            return new EmptyResult();
        }

        // Get all records from datareader
        [return: NotNullIfNotNull("dr")]
        protected async Task<List<Dictionary<string, object>>> GetRecordsFromRecordset(DbDataReader? dr)
        {
            var rows = new List<Dictionary<string, object>>();
            while (dr != null && await dr.ReadAsync()) {
                await LoadRowValues(dr); // Set up DbValue/CurrentValue
                if (GetRecordFromDictionary(GetDictionary(dr)) is Dictionary<string, object> row)
                    rows.Add(row);
            }
            return rows;
        }

        // Get all records from the list of records
        #pragma warning disable 1998

        protected async Task<List<Dictionary<string, object>>> GetRecordsFromRecordset(List<Dictionary<string, object>>? list)
        {
            var rows = new List<Dictionary<string, object>>();
            if (list != null) {
                foreach (var row in list) {
                    if (GetRecordFromDictionary(row) is Dictionary<string, object> d)
                       rows.Add(row);
                }
            }
            return rows;
        }
        #pragma warning restore 1998

        // Get the first record from datareader
        [return: NotNullIfNotNull("dr")]
        protected async Task<Dictionary<string, object>?> GetRecordFromRecordset(DbDataReader? dr)
        {
            if (dr != null) {
                await LoadRowValues(dr); // Set up DbValue/CurrentValue
                return GetRecordFromDictionary(GetDictionary(dr));
            }
            return null;
        }

        // Get the first record from the list of records
        protected Dictionary<string, object>? GetRecordFromRecordset(List<Dictionary<string, object>>? list) =>
            list != null && list.Count > 0 ? GetRecordFromDictionary(list[0]) : null;

        // Get record from Dictionary
        protected Dictionary<string, object>? GetRecordFromDictionary(Dictionary<string, object>? dict) {
            if (dict == null)
                return null;
            var row = new Dictionary<string, object>();
            foreach (var (key, value) in dict) {
                if (Fields.TryGetValue(key, out DbField? fld)) {
                    if (fld.Visible || fld.IsPrimaryKey) { // Primary key or Visible
                        if (fld.HtmlTag == "FILE") { // Upload field
                            if (Empty(value)) {
                                // row[key] = null;
                            } else {
                                if (fld.DataType == DataType.Blob) {
                                    string url = FullUrl(GetPageName(Config.ApiUrl) + "/" + Config.ApiFileAction + "/" + fld.TableVar + "/" + fld.Param + "/" + GetRecordKeyValue(dict)); // Query string format
                                    row[key] = new Dictionary<string, object> { { "type", ContentType((byte[])value) }, { "url", url }, { "name", fld.Param + ContentExtension((byte[])value) } };
                                } else if (!fld.UploadMultiple || !ConvertToString(value).Contains(Config.MultipleUploadSeparator)) { // Single file
                                    string url = FullUrl(GetPageName(Config.ApiUrl) + "/" + Config.ApiFileAction + "/" + fld.TableVar + "/" + Encrypt(fld.PhysicalUploadPath + ConvertToString(value))); // Query string format
                                    row[key] = new Dictionary<string, object> { { "type", ContentType(ConvertToString(value)) }, { "url", url }, { "name", ConvertToString(value) } };
                                } else { // Multiple files
                                    var files = ConvertToString(value).Split(Config.MultipleUploadSeparator);
                                    row[key] = files.Where(file => !Empty(file)).Select(file => new Dictionary<string, object> { { "type", ContentType(file) }, { "url", FullUrl(GetPageName(Config.ApiUrl) + "/" + Config.ApiFileAction + "/" + fld.TableVar + "/" + Encrypt(fld.PhysicalUploadPath + file)) }, { "name", file } });
                                }
                            }
                        } else {
                            string val = ConvertToString(value);
                            if (fld.DataType == DataType.Date && value is DateTime dt)
                                val = dt.ToString("s");
                            row[key] = ConvertToString(val);
                        }
                    }
                }
            }
            return row;
        }

        // Get record key value from array
        protected string GetRecordKeyValue(Dictionary<string, object> dict) {
            string key = "";
            key += UrlEncode(ConvertToString(dict.ContainsKey("ID") ? dict["ID"] : ID.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAddOrEdit)
                RankAppliedFor.Visible = false;
            if (IsAddOrEdit)
                Draft.Visible = false;
            if (IsAddOrEdit)
                Submitted.Visible = false;
            if (IsAddOrEdit)
                AgencyReviewed.Visible = false;
            if (IsAddOrEdit)
                PDEReviewed.Visible = false;
            if (IsAddOrEdit)
                RegistrationForm.Visible = false;
            if (IsAddOrEdit)
                PreScreeningInterview.Visible = false;
            if (IsAddOrEdit)
                MinimumRecruitmentCheck.Visible = false;
            if (IsAddOrEdit)
                EngagementChecklist.Visible = false;
            if (IsAddOrEdit)
                COCAuthenticity.Visible = false;
            if (IsAddOrEdit)
                CESTest.Visible = false;
            if (IsAddOrEdit)
                PyschometricTest.Visible = false;
            if (IsAddOrEdit)
                CrewWatchlist.Visible = false;
            if (IsAddOrEdit)
                PreviousAppraisalReport.Visible = false;
            if (IsAddOrEdit)
                ContractBackgroundCheck.Visible = false;
            if (IsAddOrEdit)
                EnglishProficiencyTestOrMarline.Visible = false;
            if (IsAddOrEdit)
                Interviewed.Visible = false;
            if (IsAddOrEdit)
                Approved.Visible = false;
            if (IsAddOrEdit)
                MedicalCheckup.Visible = false;
            if (IsAddOrEdit)
                CreatedBy.Visible = false;
            if (IsAddOrEdit)
                LastUpdatedBy.Visible = false;
        }

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public int StartRecord;

        public int TotalRecords;

        public int RecordCount;

        public List<string> RecordKeys = new ();

        public DbDataReader? Recordset;

        public int StartRowCount = 1;

        public bool IsModal = false;

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            // Use layout
            if (!Empty(Param("layout")) && !Param<bool>("layout"))
                UseLayout = false;

            // User profile
            Profile = ResolveProfile();

            // Security
            Security = ResolveSecurity();
            if (TableVar != "")
                Security.LoadTablePermissions(TableVar);
            CurrentAction = Param("action"); // Set up current action
            SetVisibility();

            // Do not use lookup cache
            if (!Config.LookupCachePageIds.Contains(PageID))
                SetUseLookupCache(false);

            // Global Page Loading event
            PageLoading();

            // Page Load event
            PageLoad();

            // Check token
            if (!await ValidPost())
                End(Language.Phrase("InvalidPostRequest"));

            // Check action result
            if (ActionResult != null) // Action result set by server event // DN
                return ActionResult;

            // Create token
            CreateToken();

            // Hide fields for add/edit
            if (!UseAjaxActions)
                HideFieldsForAddEdit();
            // Use inline delete
            if (UseAjaxActions)
                InlineDelete = true;

            // Set up lookup cache
            await SetupLookupOptions(Gender);
            await SetupLookupOptions(WillAcceptLowRank);

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Load key parameters
            RecordKeys = GetRecordKeys(); // Load record keys
            string filter = GetFilterFromRecordKeys();
            if (Empty(filter))
                return Terminate("VCrewTrackingStatusList"); // Prevent SQL injection, return to List page

            // Set up filter (WHERE Clause)
            CurrentFilter = filter;

            // Get action
            if (IsApi()) {
                CurrentAction = "delete"; // Delete record directly
            } else if (!Empty(Param("action"))) {
                CurrentAction = Param("action") == "delete" ? "delete" : "show";
            } else {
                CurrentAction = InlineDelete ?
                    "delete" : // Delete record directly
                    "show"; // Display record
            }
            if (IsDelete) { // DN
                SendEmail = true; // Send email on delete success
                var res = await DeleteRows();
                if (res) { // Delete rows
                    if (Empty(SuccessMessage))
                        SuccessMessage = Language.Phrase("DeleteSuccess"); // Set up success message
                    if (IsJsonResponse()) {
                        ClearMessages(); // Clear messages for Json response
                        return res;
                    } else {
                        return Terminate(ReturnUrl); // Return to caller
                    }
                } else { // Delete failed
                    if (IsJsonResponse()) {
                        return Terminate();
                    }
                    // Return JSON error message if UseAjaxActions
                    if (UseAjaxActions)
                        return Controller.Json(new { success = false, error = GetFailureMessage() });
                    if (InlineDelete)
                        return Terminate(ReturnUrl); // Return to caller
                    else
                        CurrentAction = "show"; // Display record
                }
            }
            if (IsShow) { // Load records for display // DN
                Recordset = await LoadRecordset();
                TotalRecords = await ListRecordCountAsync(); // Get record count
                if (TotalRecords <= 0) { // No record found, exit
                    CloseRecordset(); // DN
                    return Terminate("VCrewTrackingStatusList"); // Return to list
                }
            }

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();

                // Page Render event
                vCrewTrackingStatusDelete?.PageRender();
            }
            return PageResult();
        }

        // Load recordset // DN
        public async Task<DbDataReader?> LoadRecordset(int offset = -1, int rowcnt = -1)
        {
            // Load list page SQL
            string sql = ListSql;

            // Load recordset // DN
            var dr = await Connection.SelectLimit(sql, rowcnt, offset, !Empty(OrderBy) || !Empty(SessionOrderBy));

            // Call Recordset Selected event
            RecordsetSelected(dr);
            return dr;
        }

        // Load rows // DN
        public async Task<List<Dictionary<string, object>>> LoadRows(int offset = -1, int rowcnt = -1)
        {
            // Load list page SQL
            string sql = ListSql;

            // Load rows // DN
            using var dr = await Connection.SelectLimit(sql, rowcnt, offset, !Empty(OrderBy) || !Empty(SessionOrderBy));
            var rows = await Connection.GetRowsAsync(dr);
            dr.Close(); // Close datareader before return
            return rows;
        }

        // Load row based on key values
        public async Task<bool> LoadRow()
        {
            string filter = GetRecordFilter();

            // Call Row Selecting event
            RowSelecting(ref filter);

            // Load SQL based on filter
            CurrentFilter = filter;
            string sql = CurrentSql;
            bool res = false;
            try {
                var row = await Connection.GetRowAsync(sql);
                if (row != null) {
                    await LoadRowValues(row);
                    res = true;
                } else {
                    return false;
                }
            } catch {
                if (Config.Debug)
                    throw;
            }
            return res;
        }

        #pragma warning disable 162, 168, 1998, 4014
        // Load row values from data reader
        public async Task LoadRowValues(DbDataReader? dr = null) => LoadRowValues(GetDictionary(dr));

        // Load row values from recordset
        public async Task LoadRowValues(Dictionary<string, object>? row)
        {
            row ??= NewRow();

            // Call Row Selected event
            RowSelected(row);
            ID.SetDbValue(row["ID"]);
            IndividualCodeNumber.SetDbValue(row["IndividualCodeNumber"]);
            FullName.SetDbValue(row["FullName"]);
            RequiredPhoto.SetDbValue(row["RequiredPhoto"]);
            VisaPhoto.SetDbValue(row["VisaPhoto"]);
            Gender.SetDbValue(row["Gender"]);
            RankAppliedFor.SetDbValue(row["RankAppliedFor"]);
            WillAcceptLowRank.SetDbValue((ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"));
            EmployeeStatus.SetDbValue(row["EmployeeStatus"]);
            Draft.SetDbValue(row["Draft"]);
            Submitted.SetDbValue(row["Submitted"]);
            AgencyReviewed.SetDbValue(row["AgencyReviewed"]);
            PDEReviewed.SetDbValue(row["PDEReviewed"]);
            RegistrationForm.SetDbValue(row["RegistrationForm"]);
            PreScreeningInterview.SetDbValue(row["PreScreeningInterview"]);
            MinimumRecruitmentCheck.SetDbValue(row["MinimumRecruitmentCheck"]);
            EngagementChecklist.SetDbValue(row["EngagementChecklist"]);
            COCAuthenticity.SetDbValue(row["COCAuthenticity"]);
            CESTest.SetDbValue(row["CESTest"]);
            PyschometricTest.SetDbValue(row["PyschometricTest"]);
            CrewWatchlist.SetDbValue(row["CrewWatchlist"]);
            PreviousAppraisalReport.SetDbValue(row["PreviousAppraisalReport"]);
            ContractBackgroundCheck.SetDbValue(row["ContractBackgroundCheck"]);
            EnglishProficiencyTestOrMarline.SetDbValue(row["EnglishProficiencyTestOrMarline"]);
            Interviewed.SetDbValue(row["Interviewed"]);
            Approved.SetDbValue(row["Approved"]);
            MedicalCheckup.SetDbValue(row["MedicalCheckup"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("IndividualCodeNumber", IndividualCodeNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("RequiredPhoto", RequiredPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("VisaPhoto", VisaPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("Gender", Gender.DefaultValue ?? DbNullValue); // DN
            row.Add("RankAppliedFor", RankAppliedFor.DefaultValue ?? DbNullValue); // DN
            row.Add("WillAcceptLowRank", WillAcceptLowRank.DefaultValue ?? DbNullValue); // DN
            row.Add("EmployeeStatus", EmployeeStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("Draft", Draft.DefaultValue ?? DbNullValue); // DN
            row.Add("Submitted", Submitted.DefaultValue ?? DbNullValue); // DN
            row.Add("AgencyReviewed", AgencyReviewed.DefaultValue ?? DbNullValue); // DN
            row.Add("PDEReviewed", PDEReviewed.DefaultValue ?? DbNullValue); // DN
            row.Add("RegistrationForm", RegistrationForm.DefaultValue ?? DbNullValue); // DN
            row.Add("PreScreeningInterview", PreScreeningInterview.DefaultValue ?? DbNullValue); // DN
            row.Add("MinimumRecruitmentCheck", MinimumRecruitmentCheck.DefaultValue ?? DbNullValue); // DN
            row.Add("EngagementChecklist", EngagementChecklist.DefaultValue ?? DbNullValue); // DN
            row.Add("COCAuthenticity", COCAuthenticity.DefaultValue ?? DbNullValue); // DN
            row.Add("CESTest", CESTest.DefaultValue ?? DbNullValue); // DN
            row.Add("PyschometricTest", PyschometricTest.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewWatchlist", CrewWatchlist.DefaultValue ?? DbNullValue); // DN
            row.Add("PreviousAppraisalReport", PreviousAppraisalReport.DefaultValue ?? DbNullValue); // DN
            row.Add("ContractBackgroundCheck", ContractBackgroundCheck.DefaultValue ?? DbNullValue); // DN
            row.Add("EnglishProficiencyTestOrMarline", EnglishProficiencyTestOrMarline.DefaultValue ?? DbNullValue); // DN
            row.Add("Interviewed", Interviewed.DefaultValue ?? DbNullValue); // DN
            row.Add("Approved", Approved.DefaultValue ?? DbNullValue); // DN
            row.Add("MedicalCheckup", MedicalCheckup.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // ID
            ID.CellCssStyle = "white-space: nowrap;";

            // IndividualCodeNumber
            IndividualCodeNumber.CellCssStyle = "white-space: nowrap;";

            // FullName
            FullName.CellCssStyle = "white-space: nowrap;";

            // RequiredPhoto
            RequiredPhoto.CellCssStyle = "white-space: nowrap;";

            // VisaPhoto
            VisaPhoto.CellCssStyle = "white-space: nowrap;";

            // Gender
            Gender.CellCssStyle = "white-space: nowrap;";

            // RankAppliedFor
            RankAppliedFor.CellCssStyle = "white-space: nowrap;";

            // WillAcceptLowRank
            WillAcceptLowRank.CellCssStyle = "white-space: nowrap;";

            // EmployeeStatus
            EmployeeStatus.CellCssStyle = "white-space: nowrap;";

            // Draft
            Draft.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Submitted
            Submitted.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // AgencyReviewed
            AgencyReviewed.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PDEReviewed
            PDEReviewed.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // RegistrationForm
            RegistrationForm.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PreScreeningInterview
            PreScreeningInterview.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // MinimumRecruitmentCheck
            MinimumRecruitmentCheck.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // EngagementChecklist
            EngagementChecklist.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // COCAuthenticity
            COCAuthenticity.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // CESTest
            CESTest.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PyschometricTest
            PyschometricTest.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // CrewWatchlist
            CrewWatchlist.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PreviousAppraisalReport
            PreviousAppraisalReport.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // ContractBackgroundCheck
            ContractBackgroundCheck.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // EnglishProficiencyTestOrMarline
            EnglishProficiencyTestOrMarline.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Interviewed
            Interviewed.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Approved
            Approved.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // MedicalCheckup
            MedicalCheckup.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // CreatedBy
            CreatedBy.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // LastUpdatedBy
            LastUpdatedBy.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // View row
            if (RowType == RowType.View) {
                // IndividualCodeNumber
                IndividualCodeNumber.ViewValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
                IndividualCodeNumber.ViewCustomAttributes = "";

                // FullName
                FullName.ViewValue = ConvertToString(FullName.CurrentValue); // DN
                FullName.ViewCustomAttributes = "";

                // RequiredPhoto
                RequiredPhoto.ViewValue = ConvertToString(RequiredPhoto.CurrentValue); // DN
                RequiredPhoto.CellCssStyle += "text-align: center;";
                RequiredPhoto.ViewCustomAttributes = "";

                // VisaPhoto
                VisaPhoto.ViewValue = ConvertToString(VisaPhoto.CurrentValue); // DN
                VisaPhoto.CellCssStyle += "text-align: center;";
                VisaPhoto.ViewCustomAttributes = "";

                // Gender
                Gender.ViewValue = ConvertToString(Gender.CurrentValue); // DN
                Gender.ViewCustomAttributes = "";

                // RankAppliedFor
                RankAppliedFor.ViewValue = ConvertToString(RankAppliedFor.CurrentValue); // DN
                RankAppliedFor.ViewCustomAttributes = "";

                // WillAcceptLowRank
                if (ConvertToBool(WillAcceptLowRank.CurrentValue)) {
                    WillAcceptLowRank.ViewValue = WillAcceptLowRank.TagCaption(1) != "" ? WillAcceptLowRank.TagCaption(1) : "Yes";
                } else {
                    WillAcceptLowRank.ViewValue = WillAcceptLowRank.TagCaption(2) != "" ? WillAcceptLowRank.TagCaption(2) : "No";
                }
                WillAcceptLowRank.CellCssStyle += "text-align: center;";
                WillAcceptLowRank.ViewCustomAttributes = "";

                // EmployeeStatus
                EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
                EmployeeStatus.ViewCustomAttributes = "";

                // Draft
                Draft.ViewValue = Draft.CurrentValue;
                Draft.ViewValue = FormatNumber(Draft.ViewValue, Draft.FormatPattern);
                Draft.CellCssStyle += "text-align: center;";
                Draft.ViewCustomAttributes = "";

                // Submitted
                Submitted.ViewValue = Submitted.CurrentValue;
                Submitted.ViewValue = FormatNumber(Submitted.ViewValue, Submitted.FormatPattern);
                Submitted.CellCssStyle += "text-align: center;";
                Submitted.ViewCustomAttributes = "";

                // AgencyReviewed
                AgencyReviewed.ViewValue = AgencyReviewed.CurrentValue;
                AgencyReviewed.ViewValue = FormatNumber(AgencyReviewed.ViewValue, AgencyReviewed.FormatPattern);
                AgencyReviewed.CellCssStyle += "text-align: center;";
                AgencyReviewed.ViewCustomAttributes = "";

                // PDEReviewed
                PDEReviewed.ViewValue = PDEReviewed.CurrentValue;
                PDEReviewed.ViewValue = FormatNumber(PDEReviewed.ViewValue, PDEReviewed.FormatPattern);
                PDEReviewed.CellCssStyle += "text-align: center;";
                PDEReviewed.ViewCustomAttributes = "";

                // RegistrationForm
                RegistrationForm.ViewValue = RegistrationForm.CurrentValue;
                RegistrationForm.ViewValue = FormatNumber(RegistrationForm.ViewValue, RegistrationForm.FormatPattern);
                RegistrationForm.CellCssStyle += "text-align: center;";
                RegistrationForm.ViewCustomAttributes = "";

                // PreScreeningInterview
                PreScreeningInterview.ViewValue = PreScreeningInterview.CurrentValue;
                PreScreeningInterview.ViewValue = FormatNumber(PreScreeningInterview.ViewValue, PreScreeningInterview.FormatPattern);
                PreScreeningInterview.CellCssStyle += "text-align: center;";
                PreScreeningInterview.ViewCustomAttributes = "";

                // MinimumRecruitmentCheck
                MinimumRecruitmentCheck.ViewValue = MinimumRecruitmentCheck.CurrentValue;
                MinimumRecruitmentCheck.ViewValue = FormatNumber(MinimumRecruitmentCheck.ViewValue, MinimumRecruitmentCheck.FormatPattern);
                MinimumRecruitmentCheck.CellCssStyle += "text-align: center;";
                MinimumRecruitmentCheck.ViewCustomAttributes = "";

                // EngagementChecklist
                EngagementChecklist.ViewValue = EngagementChecklist.CurrentValue;
                EngagementChecklist.ViewValue = FormatNumber(EngagementChecklist.ViewValue, EngagementChecklist.FormatPattern);
                EngagementChecklist.CellCssStyle += "text-align: center;";
                EngagementChecklist.ViewCustomAttributes = "";

                // COCAuthenticity
                COCAuthenticity.ViewValue = COCAuthenticity.CurrentValue;
                COCAuthenticity.ViewValue = FormatNumber(COCAuthenticity.ViewValue, COCAuthenticity.FormatPattern);
                COCAuthenticity.CellCssStyle += "text-align: center;";
                COCAuthenticity.ViewCustomAttributes = "";

                // CESTest
                CESTest.ViewValue = CESTest.CurrentValue;
                CESTest.ViewValue = FormatNumber(CESTest.ViewValue, CESTest.FormatPattern);
                CESTest.CellCssStyle += "text-align: center;";
                CESTest.ViewCustomAttributes = "";

                // PyschometricTest
                PyschometricTest.ViewValue = PyschometricTest.CurrentValue;
                PyschometricTest.ViewValue = FormatNumber(PyschometricTest.ViewValue, PyschometricTest.FormatPattern);
                PyschometricTest.CellCssStyle += "text-align: center;";
                PyschometricTest.ViewCustomAttributes = "";

                // CrewWatchlist
                CrewWatchlist.ViewValue = CrewWatchlist.CurrentValue;
                CrewWatchlist.ViewValue = FormatNumber(CrewWatchlist.ViewValue, CrewWatchlist.FormatPattern);
                CrewWatchlist.CellCssStyle += "text-align: center;";
                CrewWatchlist.ViewCustomAttributes = "";

                // PreviousAppraisalReport
                PreviousAppraisalReport.ViewValue = PreviousAppraisalReport.CurrentValue;
                PreviousAppraisalReport.ViewValue = FormatNumber(PreviousAppraisalReport.ViewValue, PreviousAppraisalReport.FormatPattern);
                PreviousAppraisalReport.CellCssStyle += "text-align: center;";
                PreviousAppraisalReport.ViewCustomAttributes = "";

                // ContractBackgroundCheck
                ContractBackgroundCheck.ViewValue = ContractBackgroundCheck.CurrentValue;
                ContractBackgroundCheck.ViewValue = FormatNumber(ContractBackgroundCheck.ViewValue, ContractBackgroundCheck.FormatPattern);
                ContractBackgroundCheck.CellCssStyle += "text-align: center;";
                ContractBackgroundCheck.ViewCustomAttributes = "";

                // EnglishProficiencyTestOrMarline
                EnglishProficiencyTestOrMarline.ViewValue = EnglishProficiencyTestOrMarline.CurrentValue;
                EnglishProficiencyTestOrMarline.ViewValue = FormatNumber(EnglishProficiencyTestOrMarline.ViewValue, EnglishProficiencyTestOrMarline.FormatPattern);
                EnglishProficiencyTestOrMarline.CellCssStyle += "text-align: center;";
                EnglishProficiencyTestOrMarline.ViewCustomAttributes = "";

                // Interviewed
                Interviewed.ViewValue = Interviewed.CurrentValue;
                Interviewed.ViewValue = FormatNumber(Interviewed.ViewValue, Interviewed.FormatPattern);
                Interviewed.CellCssStyle += "text-align: center;";
                Interviewed.ViewCustomAttributes = "";

                // Approved
                Approved.ViewValue = Approved.CurrentValue;
                Approved.ViewValue = FormatNumber(Approved.ViewValue, Approved.FormatPattern);
                Approved.CellCssStyle += "text-align: center;";
                Approved.ViewCustomAttributes = "";

                // MedicalCheckup
                MedicalCheckup.ViewValue = MedicalCheckup.CurrentValue;
                MedicalCheckup.ViewValue = FormatNumber(MedicalCheckup.ViewValue, MedicalCheckup.FormatPattern);
                MedicalCheckup.CellCssStyle += "text-align: center;";
                MedicalCheckup.ViewCustomAttributes = "";

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";
                IndividualCodeNumber.TooltipValue = "";

                // FullName
                FullName.HrefValue = "";
                FullName.TooltipValue = "";

                // RequiredPhoto
                RequiredPhoto.HrefValue = "";
                RequiredPhoto.TooltipValue = "";

                // VisaPhoto
                VisaPhoto.HrefValue = "";
                VisaPhoto.TooltipValue = "";

                // Gender
                Gender.HrefValue = "";
                Gender.TooltipValue = "";

                // RankAppliedFor
                RankAppliedFor.HrefValue = "";
                RankAppliedFor.TooltipValue = "";

                // WillAcceptLowRank
                WillAcceptLowRank.HrefValue = "";
                WillAcceptLowRank.TooltipValue = "";

                // EmployeeStatus
                EmployeeStatus.HrefValue = "";
                EmployeeStatus.TooltipValue = "";

                // Draft
                Draft.HrefValue = "";
                Draft.TooltipValue = "";

                // Submitted
                Submitted.HrefValue = "";
                Submitted.TooltipValue = "";

                // AgencyReviewed
                AgencyReviewed.HrefValue = "";
                AgencyReviewed.TooltipValue = "";

                // PDEReviewed
                PDEReviewed.HrefValue = "";
                PDEReviewed.TooltipValue = "";

                // RegistrationForm
                RegistrationForm.HrefValue = "";
                RegistrationForm.TooltipValue = "";

                // PreScreeningInterview
                PreScreeningInterview.HrefValue = "";
                PreScreeningInterview.TooltipValue = "";

                // MinimumRecruitmentCheck
                MinimumRecruitmentCheck.HrefValue = "";
                MinimumRecruitmentCheck.TooltipValue = "";

                // EngagementChecklist
                EngagementChecklist.HrefValue = "";
                EngagementChecklist.TooltipValue = "";

                // COCAuthenticity
                COCAuthenticity.HrefValue = "";
                COCAuthenticity.TooltipValue = "";

                // CESTest
                CESTest.HrefValue = "";
                CESTest.TooltipValue = "";

                // PyschometricTest
                PyschometricTest.HrefValue = "";
                PyschometricTest.TooltipValue = "";

                // CrewWatchlist
                CrewWatchlist.HrefValue = "";
                CrewWatchlist.TooltipValue = "";

                // PreviousAppraisalReport
                PreviousAppraisalReport.HrefValue = "";
                PreviousAppraisalReport.TooltipValue = "";

                // ContractBackgroundCheck
                ContractBackgroundCheck.HrefValue = "";
                ContractBackgroundCheck.TooltipValue = "";

                // EnglishProficiencyTestOrMarline
                EnglishProficiencyTestOrMarline.HrefValue = "";
                EnglishProficiencyTestOrMarline.TooltipValue = "";

                // Interviewed
                Interviewed.HrefValue = "";
                Interviewed.TooltipValue = "";

                // Approved
                Approved.HrefValue = "";
                Approved.TooltipValue = "";

                // MedicalCheckup
                MedicalCheckup.HrefValue = "";
                MedicalCheckup.TooltipValue = "";
            }

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        // Delete records (based on current filter)
        protected async Task<JsonBoolResult> DeleteRows() { // DN
            if (!Security.CanDelete) {
                FailureMessage = Language.Phrase("NoDeletePermission"); // No delete permission
                return JsonBoolResult.FalseResult; // No delete permission
            }
            List<Dictionary<string, object>>? rsold = null;
            bool result = true;
            try {
                string sql = CurrentSql;
                using var rs = await Connection.GetDataReaderAsync(sql);
                if (rs == null) {
                    return JsonBoolResult.FalseResult;
                } else if (!rs.HasRows) {
                    FailureMessage = Language.Phrase("NoRecord"); // No record found
                    return JsonBoolResult.FalseResult;
                } else { // Clone old rows
                    rsold = await Connection.GetRowsAsync(rs);
                }
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }
            if (UseTransaction)
                Connection.BeginTrans();
            List<string> successKeys = new (), failKeys = new ();
            try {
                // Call Row Deleting event
                if (result)
                    result = rsold.All(row => RowDeleting(row));
                if (result) {
                    foreach (var row in rsold) {
                        try {
                            result = await DeleteAsync(row) > 0;
                        } catch (Exception e) {
                            if (Config.Debug)
                                throw;
                            FailureMessage = e.Message; // Set up error message
                            result = false;
                        }
                        if (!result) {
                            if (UseTransaction) {
                                successKeys.Clear();
                                break;
                            }
                            failKeys.Add(GetKey(row)); // DN
                        } else {
                            if (Config.DeleteUploadFiles)
                                DeleteUploadedFiles(row);
                            RowDeleted(row);
                            successKeys.Add(GetKey(row)); // DN
                        }
                    }
                }
                result = successKeys.Count > 0;
                if (!result) {
                    // Set up error message
                    if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {
                        // Use the message, do nothing
                    } else if (!Empty(CancelMessage)) {
                        FailureMessage = CancelMessage;
                        CancelMessage = "";
                    } else {
                        FailureMessage = Language.Phrase("DeleteCancelled");
                    }
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                result = false;
            }
            if (result) {
                if (UseTransaction)
                    Connection.CommitTrans(); // Commit the changes

                // Set warning message if delete some records failed
                if (failKeys.Count > 0)
                    WarningMessage = Language.Phrase("DeleteRecordsFailed").Replace("%k", String.Join(", ", failKeys));
            } else {
                if (UseTransaction)
                    Connection.RollbackTrans(); // Rollback changes
            }

            // Write JSON for API request
            Dictionary<string, object> d = new ();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                var rows = await GetRecordsFromRecordset(rsold);
                string table = TableVar;
                d.Add(table, RouteValues.Count > 2 && rows.Count == 1 ? rows[0] : rows); // If single-delete, route values are controller/action/id (count > 2)
                d.Add("action", Config.ApiDeleteAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, true);
            }
            return new JsonBoolResult(d, result);
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("VCrewTrackingStatusList")), "", TableVar, true);
            string pageId = "delete";
            breadcrumb.Add("delete", pageId, url);
            CurrentBreadcrumb = breadcrumb;
        }

        // Setup lookup options
        public async Task SetupLookupOptions(DbField fld)
        {
            if (fld.Lookup == null)
                return;
            Func<string>? lookupFilter = null;
            dynamic conn = Connection;
            if (fld.Lookup.Options.Count is int c && c == 0) {
                // Always call to Lookup.GetSql so that user can setup Lookup.Options in Lookup Selecting server event
                var sql = fld.Lookup.GetSql(false, "", lookupFilter, this);

                // Set up lookup cache
                if (!fld.HasLookupOptions && fld.UseLookupCache && !Empty(sql) && fld.Lookup.ParentFields.Count == 0 && fld.Lookup.Options.Count == 0) {
                    int totalCnt = await TryGetRecordCountAsync(sql, conn);
                    if (totalCnt > fld.LookupCacheCount) // Total count > cache count, do not cache
                        return;
                    var dict = new Dictionary<string, Dictionary<string, object>>();
                    var values = new List<object>();
                    List<Dictionary<string, object>> rs = await conn.GetRowsAsync(sql);
                    if (rs != null) {
                        for (int i = 0; i < rs.Count; i++) {
                            var row = rs[i];
                            row = fld.Lookup?.RenderViewRow(row, Resolve(fld.Lookup.LinkTable));
                            string key = row?.Values.First()?.ToString() ?? String.Empty;
                            if (!dict.ContainsKey(key) && row != null)
                                dict.Add(key, row);
                        }
                    }
                    fld.Lookup?.SetOptions(dict);
                }
            }
        }

        // Close recordset
        public void CloseRecordset()
        {
            using (Recordset) {} // Dispose
        }

        // Page Load event
        public virtual void PageLoad() {
            //Log("Page Load");
        }

        // Page Unload event
        public virtual void PageUnload() {
            //Log("Page Unload");
        }

        // Page Redirecting event
        public virtual void PageRedirecting(ref string url) {
            //url = newurl;
        }

        // Message Showing event
        // type = ""|"success"|"failure"|"warning"
        public virtual void MessageShowing(ref string msg, string type) {
            // Note: Do not change msg outside the following 4 cases.
            if (type == "success") {
                //msg = "your success message";
            } else if (type == "failure") {
                //msg = "your failure message";
            } else if (type == "warning") {
                //msg = "your warning message";
            } else {
                //msg = "your message";
            }
        }

        // Page Load event
        public virtual void PageRender() {
            //Log("Page Render");
        }

        // Page Data Rendering event
        public virtual void PageDataRendering(ref string header) {
            // Example:
            //header = "your header";
        }

        // Page Data Rendered event
        public virtual void PageDataRendered(ref string footer) {
            // Example:
            //footer = "your footer";
        }

        // Page Breaking event
        public void PageBreaking(ref bool brk, ref string content) {
            // Example:
            //	brk = false; // Skip page break, or
            //	content = "<div style=\"page-break-after:always;\">&nbsp;</div>"; // Modify page break content
        }
    } // End page class
} // End Partial class
