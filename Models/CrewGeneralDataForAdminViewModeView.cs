namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewGeneralDataForAdminViewModeView
    /// </summary>
    public static CrewGeneralDataForAdminViewModeView crewGeneralDataForAdminViewModeView
    {
        get => HttpData.Get<CrewGeneralDataForAdminViewModeView>("crewGeneralDataForAdminViewModeView")!;
        set => HttpData["crewGeneralDataForAdminViewModeView"] = value;
    }

    /// <summary>
    /// Page class for CrewGeneralDataForAdminViewMode
    /// </summary>
    public class CrewGeneralDataForAdminViewModeView : CrewGeneralDataForAdminViewModeViewBase
    {
        // Constructor
        public CrewGeneralDataForAdminViewModeView(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewGeneralDataForAdminViewModeView() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewGeneralDataForAdminViewModeViewBase : CrewGeneralDataForAdminViewMode
    {
        // Page ID
        public string PageID = "view";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewGeneralDataForAdminViewMode";

        // Page object name
        public string PageObjName = "crewGeneralDataForAdminViewModeView";

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
        public CrewGeneralDataForAdminViewModeViewBase()
        {
            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-view-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (crewGeneralDataForAdminViewMode)
            if (crewGeneralDataForAdminViewMode == null || crewGeneralDataForAdminViewMode is CrewGeneralDataForAdminViewMode)
                crewGeneralDataForAdminViewMode = this;

            // DN
            string[] keys = new string[0];
            StringValues str = "";
            object? obj = null;
            string currentPageName = CurrentPageName();
            string currentUrl = AppPath(currentPageName); // DN
            if (IsApi()) {
                if (RouteValues.TryGetValue("key", out object? k) && !Empty(k))
                    keys = ConvertToString(k).Split('/');
                if (keys.Length > 0)
                    RecordKeys["ID"] = keys[0];
            } else {
                RecordKeys["ID"] = RouteValues.TryGetValue("ID", out obj) && obj != null ? UrlDecode(obj) : Get("ID"); // DN
            }

            // Start time
            StartTime = Environment.TickCount;

            // Debug message
            LoadDebugMessage();

            // Open connection
            Conn = Connection; // DN

            // User table object (MTUser)
            UserTable = Resolve("usertable")!;
            UserTableConn = GetConnection(UserTable.DbId);

            // Other options
            OtherOptions["detail"] = new () { TagClassName = "ew-detail-option" };
            OtherOptions["action"] = new () { TagClassName = "ew-action-option" };
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
        public string PageName => "CrewGeneralDataForAdminViewModeView";

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

        // Update URLs
        public string InlineAddUrl = "";

        public string GridAddUrl = "";

        public string GridEditUrl = "";

        public string MultiEditUrl = "";

        public string MultiDeleteUrl = "";

        public string MultiUpdateUrl = "";

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
            ID.SetVisibility();
            ForeignVisaHasBeenDenied.SetVisibility();
            ForeignVisaDenied_CountryID.SetVisibility();
            ForeignVisaDeniedReason.SetVisibility();
            HasMaritimeAccidentOrCourtOfEnquiry.SetVisibility();
            HasMaritimeAccidentOrCourtOfEnquiryDetails.SetVisibility();
            Reference1CompanyName.SetVisibility();
            Reference1ContactPersonName.SetVisibility();
            Reference1CompanyAddress.SetVisibility();
            Reference1CompanyCountryID.SetVisibility();
            Reference1CompanyTelephone.SetVisibility();
            Reference2CompanyName.SetVisibility();
            Reference2ContactPersonName.SetVisibility();
            Reference2CompanyAddress.SetVisibility();
            Reference2CompanyCountryID.SetVisibility();
            Reference2CompanyTelephone.SetVisibility();
            EmployeeStatus.SetVisibility();
            FormSubmittedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            MTUserID.SetVisibility();
            Reference1CompanyTelephoneCode_CountryID.SetVisibility();
            Reference2CompanyTelephoneCode_CountryID.SetVisibility();
        }

        // Constructor
        public CrewGeneralDataForAdminViewModeViewBase(Controller? controller = null): this() { // DN
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
                    // Handle modal response (Assume return to modal for simplicity)
                    if (IsModal) { // Show as modal
                        var result = new Dictionary<string, string> { {"url", GetUrl(url)}, {"modal", "1"} };
                        string pageName = GetPageName(url);
                        if (pageName != ListUrl) { // Not List page
                            result.Add("caption", GetModalCaption(pageName));
                            result.Add("view", pageName == "CrewGeneralDataForAdminViewModeView" ? "1" : "0"); // If View page, no primary button
                        } else { // List page
                            // result.Add("list", PageID == "search" ? "1" : "0"); // Refresh List page if current page is Search page
                            result.Add("error", FailureMessage); // List page should not be shown as modal => error
                            ClearFailureMessage();
                        }
                        return Controller.Json(result);
                    } else {
                        SaveDebugMessage();
                        return Controller.LocalRedirect(AppPath(url));
                    }
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
        }

        public int DisplayRecords = 1; // Number of display records

        public int StartRecord;

        public int StopRecord;

        public int TotalRecords = -1;

        public int RecordRange = 10;

        public int RecordCount;

        public Dictionary<string, string> RecordKeys = new ();

        public bool IsModal = false;

        public string SearchWhere = "";

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public bool MasterRecordExists;

        public DbDataReader? Recordset = null;

        #pragma warning disable 168, 219
        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            // Is modal
            IsModal = Param<bool>("modal");
            UseLayout = UseLayout && !IsModal;

            // Use layout
            if (!Empty(Param("layout")) && !Param<bool>("layout"))
                UseLayout = false;

            // User profile
            Profile = ResolveProfile();

            // Security
            Security = ResolveSecurity();
            if (TableVar != "")
                Security.LoadTablePermissions(TableVar);

            // Get export parameters
            string custom = "";
            if (!Empty(Param("export"))) {
                Export = Param("export");
                custom = Param("custom");
            } else {
                ExportReturnUrl = CurrentUrl();
            }
            ExportType = Export; // Get export parameter, used in header
            if (!Empty(ExportType))
                SkipHeaderFooter = true;
            if (!Empty(Export) && !SameText(Export, "print") && Empty(custom)) // No layout for export // DN
                UseLayout = false;
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
            await SetupLookupOptions(ForeignVisaHasBeenDenied);
            await SetupLookupOptions(ForeignVisaDenied_CountryID);
            await SetupLookupOptions(HasMaritimeAccidentOrCourtOfEnquiry);
            await SetupLookupOptions(Reference1CompanyCountryID);
            await SetupLookupOptions(Reference2CompanyCountryID);
            await SetupLookupOptions(Reference1CompanyTelephoneCode_CountryID);
            await SetupLookupOptions(Reference2CompanyTelephoneCode_CountryID);

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;

            // Load current record
            bool loadCurrentRecord = false;
            string returnUrl = "";
            bool matchRecord = false;
            string[] keyValues = {};
            object? v;
            StringValues sv;
            if (IsApi()) {
                if (RouteValues.TryGetValue(Config.ApiKeyName, out object? k)) {
                    if (!Empty(k))
                        keyValues = ConvertToString(k).Split('/');
                } else { // Get key from query string
                    string key = Get(Config.ApiKeyName);
                    if (!Empty(key))
                        keyValues = key.Split(',');
                }
                if (keyValues.Length == 0)
                    return new JsonBoolResult(new { success = false, error = Language.Phrase("NoRecord"), version = Config.ProductVersion }, false);
            }
            if (RouteValues.TryGetValue("ID", out v) && !Empty(v)) { // DN
                ID.QueryValue = UrlDecode(v); // DN
                RecordKeys["ID"] = ID.QueryValue;
            } else if (Get("ID", out sv)) {
                ID.QueryValue = sv.ToString();
                RecordKeys["ID"] = ID.QueryValue;
            } else if (IsApi() && !Empty(keyValues)) {
                ID.QueryValue = ConvertToString(keyValues[0]);
                RecordKeys["ID"] = ID.QueryValue;
            } else if (!loadCurrentRecord) {
                returnUrl = "CrewGeneralDataForAdminViewModeList"; // Return to list
            }

            // Get action
            CurrentAction = "show"; // Display form
            switch (CurrentAction) {
                case "show": // Get a record to display
                        bool res;
                        if (IsApi()) {
                            string filter = GetRecordFilter();
                            CurrentFilter = filter;
                            string sql = CurrentSql;
                            var conn = await GetConnectionAsync();
                            Recordset = await conn.GetDataReaderAsync(sql);
                            res = !Empty(Recordset) && await Recordset.ReadAsync();
                        } else {
                            res = await LoadRow();
                        }
                        if (!res) { // Load record based on key
                            if (Empty(SuccessMessage) && Empty(FailureMessage))
                                FailureMessage = Language.Phrase("NoRecord"); // Set no record message
                            if (IsApi()) {
                                if (!Empty(SuccessMessage))
                                    return new JsonBoolResult(new { success = true, message = SuccessMessage, version = Config.ProductVersion }, true);
                                else
                                    return new JsonBoolResult(new { success = false, error = FailureMessage, version = Config.ProductVersion }, false);
                            } else {
                                return Terminate("CrewGeneralDataForAdminViewModeList"); // Return to list page
                            }
                        }
                    break;
            }
            if (!Empty(returnUrl))
                return Terminate(returnUrl);

            // Render row
            RowType = RowType.View;
            ResetAttributes();
            await RenderRow();

            // Setup export options
            SetupExportOptions();

            // Set up Breadcrumb
            if (!IsExport())
                SetupBreadcrumb();

            // Normal return
            if (IsApi()) // Get current record only
                if (!IsExport())
                    return Controller.Json(new { success = true, TableVar = await GetRecordFromRecordset(Recordset), version = Config.ProductVersion });

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();

                // Page Render event
                crewGeneralDataForAdminViewModeView?.PageRender();
            }
            return PageResult();
        }
        #pragma warning restore 168, 219

        // Set up other options
        #pragma warning disable 168, 219

        public void SetupOtherOptions()
        {
            var options = OtherOptions;
            var option = options["action"];
            ListOption item;
            string links = "";

            // Edit
            item = option.Add("edit");
            var editTitle = Language.Phrase("ViewPageEditLink", true);
            if (IsModal) // Modal
                item.Body = "<a class=\"ew-action ew-edit\" title=\"" + editTitle + "\" data-caption=\"" + editTitle + "\" data-ew-action=\"modal\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("ViewPageEditLink") + "</a>";
            else
                item.Body = "<a class=\"ew-action ew-edit\" title=\"" + editTitle + "\" data-caption=\"" + editTitle + "\" href=\"" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("ViewPageEditLink") + "</a>";
                item.Visible = EditUrl != "" && Security.CanEdit && ShowOptionLink("edit");

            // Set up action default
            option = options["action"];
            option.DropDownButtonPhrase = "ButtonActions";
            option.UseDropDownButton = !IsJsonResponse() && true;
            option.UseButtonGroup = true;
            item = option.AddGroupOption();
            item.Body = "";
            item.Visible = false;
        }
        #pragma warning restore 168, 219

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
            ForeignVisaHasBeenDenied.SetDbValue((ConvertToBool(row["ForeignVisaHasBeenDenied"]) ? "1" : "0"));
            ForeignVisaDenied_CountryID.SetDbValue(row["ForeignVisaDenied_CountryID"]);
            ForeignVisaDeniedReason.SetDbValue(row["ForeignVisaDeniedReason"]);
            HasMaritimeAccidentOrCourtOfEnquiry.SetDbValue((ConvertToBool(row["HasMaritimeAccidentOrCourtOfEnquiry"]) ? "1" : "0"));
            HasMaritimeAccidentOrCourtOfEnquiryDetails.SetDbValue(row["HasMaritimeAccidentOrCourtOfEnquiryDetails"]);
            Reference1CompanyName.SetDbValue(row["Reference1CompanyName"]);
            Reference1ContactPersonName.SetDbValue(row["Reference1ContactPersonName"]);
            Reference1CompanyAddress.SetDbValue(row["Reference1CompanyAddress"]);
            Reference1CompanyCountryID.SetDbValue(row["Reference1CompanyCountryID"]);
            Reference1CompanyTelephone.SetDbValue(row["Reference1CompanyTelephone"]);
            Reference2CompanyName.SetDbValue(row["Reference2CompanyName"]);
            Reference2ContactPersonName.SetDbValue(row["Reference2ContactPersonName"]);
            Reference2CompanyAddress.SetDbValue(row["Reference2CompanyAddress"]);
            Reference2CompanyCountryID.SetDbValue(row["Reference2CompanyCountryID"]);
            Reference2CompanyTelephone.SetDbValue(row["Reference2CompanyTelephone"]);
            EmployeeStatus.SetDbValue(row["EmployeeStatus"]);
            FormSubmittedDateTime.SetDbValue(row["FormSubmittedDateTime"]);
            LastUpdatedByUserID.SetDbValue(row["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(row["MTUserID"]);
            Reference1CompanyTelephoneCode_CountryID.SetDbValue(row["Reference1CompanyTelephoneCode_CountryID"]);
            Reference2CompanyTelephoneCode_CountryID.SetDbValue(row["Reference2CompanyTelephoneCode_CountryID"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("ForeignVisaHasBeenDenied", ForeignVisaHasBeenDenied.DefaultValue ?? DbNullValue); // DN
            row.Add("ForeignVisaDenied_CountryID", ForeignVisaDenied_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("ForeignVisaDeniedReason", ForeignVisaDeniedReason.DefaultValue ?? DbNullValue); // DN
            row.Add("HasMaritimeAccidentOrCourtOfEnquiry", HasMaritimeAccidentOrCourtOfEnquiry.DefaultValue ?? DbNullValue); // DN
            row.Add("HasMaritimeAccidentOrCourtOfEnquiryDetails", HasMaritimeAccidentOrCourtOfEnquiryDetails.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyName", Reference1CompanyName.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1ContactPersonName", Reference1ContactPersonName.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyAddress", Reference1CompanyAddress.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyCountryID", Reference1CompanyCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyTelephone", Reference1CompanyTelephone.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyName", Reference2CompanyName.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2ContactPersonName", Reference2ContactPersonName.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyAddress", Reference2CompanyAddress.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyCountryID", Reference2CompanyCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyTelephone", Reference2CompanyTelephone.DefaultValue ?? DbNullValue); // DN
            row.Add("EmployeeStatus", EmployeeStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("FormSubmittedDateTime", FormSubmittedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("MTUserID", MTUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyTelephoneCode_CountryID", Reference1CompanyTelephoneCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyTelephoneCode_CountryID", Reference2CompanyTelephoneCode_CountryID.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            SetupOtherOptions();

            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // ID

            // ForeignVisaHasBeenDenied

            // ForeignVisaDenied_CountryID

            // ForeignVisaDeniedReason

            // HasMaritimeAccidentOrCourtOfEnquiry

            // HasMaritimeAccidentOrCourtOfEnquiryDetails

            // Reference1CompanyName

            // Reference1ContactPersonName

            // Reference1CompanyAddress

            // Reference1CompanyCountryID

            // Reference1CompanyTelephone

            // Reference2CompanyName

            // Reference2ContactPersonName

            // Reference2CompanyAddress

            // Reference2CompanyCountryID

            // Reference2CompanyTelephone

            // EmployeeStatus

            // FormSubmittedDateTime

            // LastUpdatedByUserID

            // LastUpdatedDateTime

            // MTUserID

            // Reference1CompanyTelephoneCode_CountryID

            // Reference2CompanyTelephoneCode_CountryID

            // View row
            if (RowType == RowType.View) {
                // ForeignVisaHasBeenDenied
                if (ConvertToBool(ForeignVisaHasBeenDenied.CurrentValue)) {
                    ForeignVisaHasBeenDenied.ViewValue = ForeignVisaHasBeenDenied.TagCaption(2) != "" ? ForeignVisaHasBeenDenied.TagCaption(2) : "Yes";
                } else {
                    ForeignVisaHasBeenDenied.ViewValue = ForeignVisaHasBeenDenied.TagCaption(1) != "" ? ForeignVisaHasBeenDenied.TagCaption(1) : "No";
                }
                ForeignVisaHasBeenDenied.ViewCustomAttributes = "";

                // ForeignVisaDenied_CountryID
                curVal = ConvertToString(ForeignVisaDenied_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (ForeignVisaDenied_CountryID.Lookup != null && IsDictionary(ForeignVisaDenied_CountryID.Lookup?.Options) && ForeignVisaDenied_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        ForeignVisaDenied_CountryID.ViewValue = ForeignVisaDenied_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", ForeignVisaDenied_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = ForeignVisaDenied_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && ForeignVisaDenied_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = ForeignVisaDenied_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            ForeignVisaDenied_CountryID.ViewValue = ForeignVisaDenied_CountryID.HighlightLookup(ConvertToString(rswrk[0]), ForeignVisaDenied_CountryID.DisplayValue(listwrk));
                        } else {
                            ForeignVisaDenied_CountryID.ViewValue = FormatNumber(ForeignVisaDenied_CountryID.CurrentValue, ForeignVisaDenied_CountryID.FormatPattern);
                        }
                    }
                } else {
                    ForeignVisaDenied_CountryID.ViewValue = DbNullValue;
                }
                ForeignVisaDenied_CountryID.ViewCustomAttributes = "";

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.ViewValue = ForeignVisaDeniedReason.CurrentValue;
                ForeignVisaDeniedReason.ViewCustomAttributes = "";

                // HasMaritimeAccidentOrCourtOfEnquiry
                if (ConvertToBool(HasMaritimeAccidentOrCourtOfEnquiry.CurrentValue)) {
                    HasMaritimeAccidentOrCourtOfEnquiry.ViewValue = HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(2) != "" ? HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(2) : "Yes";
                } else {
                    HasMaritimeAccidentOrCourtOfEnquiry.ViewValue = HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(1) != "" ? HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(1) : "No";
                }
                HasMaritimeAccidentOrCourtOfEnquiry.ViewCustomAttributes = "";

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.ViewValue = HasMaritimeAccidentOrCourtOfEnquiryDetails.CurrentValue;
                HasMaritimeAccidentOrCourtOfEnquiryDetails.ViewCustomAttributes = "";

                // Reference1CompanyName
                Reference1CompanyName.ViewValue = ConvertToString(Reference1CompanyName.CurrentValue); // DN
                Reference1CompanyName.ViewCustomAttributes = "";

                // Reference1ContactPersonName
                Reference1ContactPersonName.ViewValue = ConvertToString(Reference1ContactPersonName.CurrentValue); // DN
                Reference1ContactPersonName.ViewCustomAttributes = "";

                // Reference1CompanyAddress
                Reference1CompanyAddress.ViewValue = Reference1CompanyAddress.CurrentValue;
                Reference1CompanyAddress.ViewCustomAttributes = "";

                // Reference1CompanyCountryID
                curVal = ConvertToString(Reference1CompanyCountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (Reference1CompanyCountryID.Lookup != null && IsDictionary(Reference1CompanyCountryID.Lookup?.Options) && Reference1CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Reference1CompanyCountryID.ViewValue = Reference1CompanyCountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", Reference1CompanyCountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = Reference1CompanyCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Reference1CompanyCountryID.Lookup != null) { // Lookup values found
                            var listwrk = Reference1CompanyCountryID.Lookup?.RenderViewRow(rswrk[0]);
                            Reference1CompanyCountryID.ViewValue = Reference1CompanyCountryID.HighlightLookup(ConvertToString(rswrk[0]), Reference1CompanyCountryID.DisplayValue(listwrk));
                        } else {
                            Reference1CompanyCountryID.ViewValue = FormatNumber(Reference1CompanyCountryID.CurrentValue, Reference1CompanyCountryID.FormatPattern);
                        }
                    }
                } else {
                    Reference1CompanyCountryID.ViewValue = DbNullValue;
                }
                Reference1CompanyCountryID.ViewCustomAttributes = "";

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.ViewValue = ConvertToString(Reference1CompanyTelephone.CurrentValue); // DN
                Reference1CompanyTelephone.ViewCustomAttributes = "";

                // Reference2CompanyName
                Reference2CompanyName.ViewValue = ConvertToString(Reference2CompanyName.CurrentValue); // DN
                Reference2CompanyName.ViewCustomAttributes = "";

                // Reference2ContactPersonName
                Reference2ContactPersonName.ViewValue = ConvertToString(Reference2ContactPersonName.CurrentValue); // DN
                Reference2ContactPersonName.ViewCustomAttributes = "";

                // Reference2CompanyAddress
                Reference2CompanyAddress.ViewValue = Reference2CompanyAddress.CurrentValue;
                Reference2CompanyAddress.ViewCustomAttributes = "";

                // Reference2CompanyCountryID
                curVal = ConvertToString(Reference2CompanyCountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (Reference2CompanyCountryID.Lookup != null && IsDictionary(Reference2CompanyCountryID.Lookup?.Options) && Reference2CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Reference2CompanyCountryID.ViewValue = Reference2CompanyCountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", Reference2CompanyCountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = Reference2CompanyCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Reference2CompanyCountryID.Lookup != null) { // Lookup values found
                            var listwrk = Reference2CompanyCountryID.Lookup?.RenderViewRow(rswrk[0]);
                            Reference2CompanyCountryID.ViewValue = Reference2CompanyCountryID.HighlightLookup(ConvertToString(rswrk[0]), Reference2CompanyCountryID.DisplayValue(listwrk));
                        } else {
                            Reference2CompanyCountryID.ViewValue = FormatNumber(Reference2CompanyCountryID.CurrentValue, Reference2CompanyCountryID.FormatPattern);
                        }
                    }
                } else {
                    Reference2CompanyCountryID.ViewValue = DbNullValue;
                }
                Reference2CompanyCountryID.ViewCustomAttributes = "";

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.ViewValue = ConvertToString(Reference2CompanyTelephone.CurrentValue); // DN
                Reference2CompanyTelephone.ViewCustomAttributes = "";

                // EmployeeStatus
                EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
                EmployeeStatus.ViewCustomAttributes = "";

                // FormSubmittedDateTime
                FormSubmittedDateTime.ViewValue = FormSubmittedDateTime.CurrentValue;
                FormSubmittedDateTime.ViewValue = FormatDateTime(FormSubmittedDateTime.ViewValue, FormSubmittedDateTime.FormatPattern);
                FormSubmittedDateTime.ViewCustomAttributes = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.ViewValue = LastUpdatedByUserID.CurrentValue;
                LastUpdatedByUserID.ViewValue = FormatNumber(LastUpdatedByUserID.ViewValue, LastUpdatedByUserID.FormatPattern);
                LastUpdatedByUserID.ViewCustomAttributes = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.ViewValue = LastUpdatedDateTime.CurrentValue;
                LastUpdatedDateTime.ViewValue = FormatDateTime(LastUpdatedDateTime.ViewValue, LastUpdatedDateTime.FormatPattern);
                LastUpdatedDateTime.ViewCustomAttributes = "";

                // Reference1CompanyTelephoneCode_CountryID
                curVal = ConvertToString(Reference1CompanyTelephoneCode_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (Reference1CompanyTelephoneCode_CountryID.Lookup != null && IsDictionary(Reference1CompanyTelephoneCode_CountryID.Lookup?.Options) && Reference1CompanyTelephoneCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Reference1CompanyTelephoneCode_CountryID.ViewValue = Reference1CompanyTelephoneCode_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", Reference1CompanyTelephoneCode_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = Reference1CompanyTelephoneCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Reference1CompanyTelephoneCode_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = Reference1CompanyTelephoneCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            Reference1CompanyTelephoneCode_CountryID.ViewValue = Reference1CompanyTelephoneCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), Reference1CompanyTelephoneCode_CountryID.DisplayValue(listwrk));
                        } else {
                            Reference1CompanyTelephoneCode_CountryID.ViewValue = Reference1CompanyTelephoneCode_CountryID.CurrentValue;
                        }
                    }
                } else {
                    Reference1CompanyTelephoneCode_CountryID.ViewValue = DbNullValue;
                }
                Reference1CompanyTelephoneCode_CountryID.ViewCustomAttributes = "";

                // Reference2CompanyTelephoneCode_CountryID
                curVal = ConvertToString(Reference2CompanyTelephoneCode_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (Reference2CompanyTelephoneCode_CountryID.Lookup != null && IsDictionary(Reference2CompanyTelephoneCode_CountryID.Lookup?.Options) && Reference2CompanyTelephoneCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Reference2CompanyTelephoneCode_CountryID.ViewValue = Reference2CompanyTelephoneCode_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", Reference2CompanyTelephoneCode_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = Reference2CompanyTelephoneCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Reference2CompanyTelephoneCode_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = Reference2CompanyTelephoneCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            Reference2CompanyTelephoneCode_CountryID.ViewValue = Reference2CompanyTelephoneCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), Reference2CompanyTelephoneCode_CountryID.DisplayValue(listwrk));
                        } else {
                            Reference2CompanyTelephoneCode_CountryID.ViewValue = Reference2CompanyTelephoneCode_CountryID.CurrentValue;
                        }
                    }
                } else {
                    Reference2CompanyTelephoneCode_CountryID.ViewValue = DbNullValue;
                }
                Reference2CompanyTelephoneCode_CountryID.ViewCustomAttributes = "";

                // ForeignVisaHasBeenDenied
                ForeignVisaHasBeenDenied.HrefValue = "";
                ForeignVisaHasBeenDenied.TooltipValue = "";

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.HrefValue = "";
                ForeignVisaDenied_CountryID.TooltipValue = "";

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.HrefValue = "";
                ForeignVisaDeniedReason.TooltipValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.HrefValue = "";
                HasMaritimeAccidentOrCourtOfEnquiry.TooltipValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.HrefValue = "";
                HasMaritimeAccidentOrCourtOfEnquiryDetails.TooltipValue = "";

                // Reference1CompanyName
                Reference1CompanyName.HrefValue = "";
                Reference1CompanyName.TooltipValue = "";

                // Reference1ContactPersonName
                Reference1ContactPersonName.HrefValue = "";
                Reference1ContactPersonName.TooltipValue = "";

                // Reference1CompanyAddress
                Reference1CompanyAddress.HrefValue = "";
                Reference1CompanyAddress.TooltipValue = "";

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.HrefValue = "";
                Reference1CompanyCountryID.TooltipValue = "";

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.HrefValue = "";
                Reference1CompanyTelephone.TooltipValue = "";

                // Reference2CompanyName
                Reference2CompanyName.HrefValue = "";
                Reference2CompanyName.TooltipValue = "";

                // Reference2ContactPersonName
                Reference2ContactPersonName.HrefValue = "";
                Reference2ContactPersonName.TooltipValue = "";

                // Reference2CompanyAddress
                Reference2CompanyAddress.HrefValue = "";
                Reference2CompanyAddress.TooltipValue = "";

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.HrefValue = "";
                Reference2CompanyCountryID.TooltipValue = "";

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.HrefValue = "";
                Reference2CompanyTelephone.TooltipValue = "";

                // EmployeeStatus
                EmployeeStatus.HrefValue = "";
                EmployeeStatus.TooltipValue = "";

                // FormSubmittedDateTime
                FormSubmittedDateTime.HrefValue = "";
                FormSubmittedDateTime.TooltipValue = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.HrefValue = "";
                LastUpdatedByUserID.TooltipValue = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.HrefValue = "";
                LastUpdatedDateTime.TooltipValue = "";

                // Reference1CompanyTelephoneCode_CountryID
                Reference1CompanyTelephoneCode_CountryID.HrefValue = "";
                Reference1CompanyTelephoneCode_CountryID.TooltipValue = "";

                // Reference2CompanyTelephoneCode_CountryID
                Reference2CompanyTelephoneCode_CountryID.HrefValue = "";
                Reference2CompanyTelephoneCode_CountryID.TooltipValue = "";
            }

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();

            // Save data for Custom Template
            if (RowType == RowType.View || RowType == RowType.Edit || RowType == RowType.Add)
                Rows.Add(CustomTemplateFieldValues());
        }
        #pragma warning restore 1998

        // Get export HTML tag
        protected string GetExportTag(string type, bool custom = false) {
            string exportUrl = AppPath(CurrentPageName()); // DN
            if (type == "print" || custom) { // Printer friendly / custom export
                List<string> keys = GetKey(true).Split(Config.CompositeKeySeparator).ToList();
                foreach (string key in keys)
                    exportUrl += "/" + UrlEncode(key);
                exportUrl += "?export=" + type + (custom ? "&amp;custom=1" : "");
            } else {
                exportUrl = AppPath(Config.ApiUrl + Config.ApiExportAction + "/" + type + "/" + TableVar);
                exportUrl += "?" + Config.ApiKeyName + "=" + GetKey(true);
            }
            if (SameText(type, "excel")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fCrewGeneralDataForAdminViewModeview\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
            } else if (SameText(type, "word")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fCrewGeneralDataForAdminViewModeview\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>";
            } else if (SameText(type, "pdf")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fCrewGeneralDataForAdminViewModeview\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\">" + Language.Phrase("ExportToPDF") + "</a>";
            } else if (SameText(type, "html")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-html\" title=\"" + HtmlEncode(Language.Phrase("ExportToHtml", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToHtml", true)) + "\">" + Language.Phrase("ExportToHtml") + "</a>";
            } else if (SameText(type, "xml")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-xml\" title=\"" + HtmlEncode(Language.Phrase("ExportToXml", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToXml", true)) + "\">" + Language.Phrase("ExportToXml") + "</a>";
            } else if (SameText(type, "csv")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-csv\" title=\"" + HtmlEncode(Language.Phrase("ExportToCsv", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToCsv", true)) + "\">" + Language.Phrase("ExportToCsv") + "</a>";
            } else if (SameText(type, "email")) {
                string url = custom ? " data-url=\"" + exportUrl + "\"" : "";
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fCrewGeneralDataForAdminViewModeview\" data-ew-action=\"email\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-key='" + HtmlEncode(ConvertToJsonAttribute(RecordKeys)) + "' data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
            } else if (SameText(type, "print")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-print\" title=\"" + HtmlEncode(Language.Phrase("PrinterFriendly", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("PrinterFriendly", true)) + "\">" + Language.Phrase("PrinterFriendly") + "</a>";
            }
            return "";
        }

        // Set up export options
        protected void SetupExportOptions() {
            ListOption item;

            // Printer friendly
            item = ExportOptions.Add("print");
            item.Body = GetExportTag("print");
            item.Visible = false;

            // Export to Excel
            item = ExportOptions.Add("excel");
            item.Body = GetExportTag("excel", !Config.UseExcelExtension);
            item.Visible = true;

            // Export to Word
            item = ExportOptions.Add("word");
            item.Body = GetExportTag("word", !Config.UseWordExtension);
            item.Visible = false;

            // Export to HTML
            item = ExportOptions.Add("html");
            item.Body = GetExportTag("html");
            item.Visible = false;

            // Export to XML
            item = ExportOptions.Add("xml");
            item.Body = GetExportTag("xml");
            item.Visible = false;

            // Export to CSV
            item = ExportOptions.Add("csv");
            item.Body = GetExportTag("csv");
            item.Visible = true;

            // Export to PDF
            item = ExportOptions.Add("pdf");
            item.Body = GetExportTag("pdf", true);
            item.Visible = false;

            // Export to Email
            item = ExportOptions.Add("email");
            item.Body = GetExportTag("email", true);
            item.Visible = false;

            // Drop down button for export
            ExportOptions.UseButtonGroup = true;
            ExportOptions.UseDropDownButton = true;
            if (ExportOptions.UseButtonGroup && IsMobile())
                ExportOptions.UseDropDownButton = true;
            ExportOptions.DropDownButtonPhrase = "ButtonExport";

            // Add group option item
            item = ExportOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;

            // Hide options for export
            if (IsExport())
                ExportOptions.HideAllOptions();

            // Hide options if json response
            if (IsJsonResponse())
                ExportOptions.HideAllOptions();
            if (!Security.CanExport) // Export not allowed
                ExportOptions.HideAllOptions();
        }

        #pragma warning disable 168

        /// <summary>
        /// Export data
        /// </summary>
        public async Task ExportData(dynamic? doc, string[] keys)
        {
            // Load recordset // DN
            DbDataReader? dr = null;
            if (TotalRecords < 0)
                TotalRecords = await ListRecordCountAsync();
            StartRecord = 1;
            if (keys.Length >= 1) {
                ID.OldValue = keys[0];
                var c = await GetConnection2Async(DbId); // Note: Use new connection for view page export // DN
                dr = await LoadReader(GetRecordFilter(), "", c);
            }
            if (doc == null) { // DN
                RemoveHeader("Content-Type"); // Remove header
                RemoveHeader("Content-Disposition");
                FailureMessage = Language.Phrase("ExportClassNotFound"); // Export class not found
                return;
            }

            // Call Page Exporting server event
            doc.ExportCustom = !PageExporting(ref doc);

            // Page header
            string header = PageHeader;
            PageDataRendering(ref header);
            doc.Text.Append(header);

            // Export
            if (dr != null)
                await ExportDocument(doc, dr, StartRecord, StopRecord, "view");

            // Page footer
            string footer = PageFooter;
            PageDataRendered(ref footer);
            doc.Text.Append(footer);

            // Close recordset
            using (dr) {} // Dispose

            // Export header and footer
            await doc.ExportHeaderAndFooter();

            // Call Page Exported server event
            PageExported(doc);
        }
        #pragma warning restore 168

        // Show link optionally based on User ID
        protected bool ShowOptionLink(string pageId = "") { // DN
            if (Security.IsLoggedIn && !Security.IsAdmin && !UserIDAllow(pageId))
                return Security.IsValidUserID(MTUserID.CurrentValue);
            return true;
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("CrewGeneralDataForAdminViewModeList")), "", TableVar, true);
            string pageId = "view";
            breadcrumb.Add("view", pageId, url);
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

        // Set up starting record parameters
        public void SetupStartRecord()
        {
            // Exit if DisplayRecords = 0
            if (DisplayRecords == 0)
                return;
            string pageNo = Get(Config.TablePageNumber);
            string startRec = Get(Config.TableStartRec);
            bool infiniteScroll = false;
            string recordNo = !Empty(pageNo) ? pageNo : startRec; // Record number = page number or start record
            if (!Empty(recordNo) && IsNumeric(recordNo))
                StartRecord = ConvertToInt(recordNo);
            else
                StartRecord = StartRecordNumber;

            // Check if correct start record counter
            if (StartRecord <= 0) // Avoid invalid start record counter
                StartRecord = 1; // Reset start record counter
            else if (StartRecord > TotalRecords) // Avoid starting record > total records
                StartRecord = ((TotalRecords - 1) / DisplayRecords) * DisplayRecords + 1; // Point to last page first record
            else if ((StartRecord - 1) % DisplayRecords != 0)
                StartRecord = ((StartRecord - 1) / DisplayRecords) * DisplayRecords + 1; // Point to page boundary
            if (!infiniteScroll)
                StartRecordNumber = StartRecord;
        }

        // Get page count
        public int PageCount
        {
            get {
                return ConvertToInt(Math.Ceiling((double)TotalRecords / DisplayRecords));
            }
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

        // Page Exporting event
        // doc = export document object
        public virtual bool PageExporting(ref dynamic doc) {
            //doc.Text.Append("<p>" + "my header" + "</p>"); // Export header
            //return false; // Return false to skip default export and use Row_Export event
            return true; // Return true to use default export and skip Row_Export event
        }

        // Page Exported event
        // doc = export document object
        public virtual void PageExported(dynamic doc) {
            //doc.Text.Append("my footer"); // Export footer
            //Log("Text: {Text}", doc.Text.ToString());
        }
    } // End page class
} // End Partial class
