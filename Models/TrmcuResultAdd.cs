namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// trmcuResultAdd
    /// </summary>
    public static TrmcuResultAdd trmcuResultAdd
    {
        get => HttpData.Get<TrmcuResultAdd>("trmcuResultAdd")!;
        set => HttpData["trmcuResultAdd"] = value;
    }

    /// <summary>
    /// Page class for TRMCUResult
    /// </summary>
    public class TrmcuResultAdd : TrmcuResultAddBase
    {
        // Constructor
        public TrmcuResultAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public TrmcuResultAdd() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class TrmcuResultAddBase : TrmcuResult
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "TRMCUResult";

        // Page object name
        public string PageObjName = "trmcuResultAdd";

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
        public TrmcuResultAddBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (trmcuResult)
            if (trmcuResult == null || trmcuResult is TrmcuResult)
                trmcuResult = this;

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
        public string PageName => "TrmcuResultAdd";

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
            McuResult_ID.Visible = false;
            MTCrew_ID.SetVisibility();
            McuDate.SetVisibility();
            McuExpirationDate.SetVisibility();
            HealthStatus.SetVisibility();
            McuLocation.SetVisibility();
            McuAttachment.SetVisibility();
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            MTUserID.Visible = false;
            McuScheduleDate.SetVisibility();
            McuRemark.SetVisibility();
        }

        // Constructor
        public TrmcuResultAddBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "TrmcuResultView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("McuResult_ID") ? dict["McuResult_ID"] : McuResult_ID.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAdd || IsCopy || IsGridAdd)
                McuResult_ID.Visible = false;
        }

        #pragma warning disable 219
        /// <summary>
        /// Lookup data from table
        /// </summary>
        public async Task<Dictionary<string, object>> Lookup(Dictionary<string, string>? dict = null)
        {
            Language = ResolveLanguage();
            Security = ResolveSecurity();
            string? v;

            // Get lookup object
            string fieldName = IsDictionary(dict) && dict.TryGetValue("field", out v) && v != null ? v : Post("field");
            var lookupField = FieldByName(fieldName);
            var lookup = lookupField?.Lookup;
            if (lookup == null) // DN
                return new Dictionary<string, object>();
            string lookupType = IsDictionary(dict) && dict.TryGetValue("ajax", out v) && v != null ? v : (Post("ajax") ?? "unknown");
            int pageSize = -1;
            int offset = -1;
            string searchValue = "";
            if (SameText(lookupType, "modal") || SameText(lookupType, "filter")) {
                searchValue = IsDictionary(dict) && (dict.TryGetValue("q", out v) && v != null || dict.TryGetValue("sv", out v) && v != null)
                    ? v
                    : (Param("q") ?? Post("sv"));
                pageSize = IsDictionary(dict) && (dict.TryGetValue("n", out v) || dict.TryGetValue("recperpage", out v))
                    ? ConvertToInt(v)
                    : (IsNumeric(Param("n")) ? Param<int>("n") : (Post("recperpage", out StringValues rpp) ? ConvertToInt(rpp.ToString()) : 10));
            } else if (SameText(lookupType, "autosuggest")) {
                searchValue = IsDictionary(dict) && dict.TryGetValue("q", out v) && v != null ? v : Param("q");
                pageSize = IsDictionary(dict) && dict.TryGetValue("n", out v) ? ConvertToInt(v) : (IsNumeric(Param("n")) ? Param<int>("n") : -1);
                if (pageSize <= 0)
                    pageSize = Config.AutoSuggestMaxEntries;
            }
            int start = IsDictionary(dict) && dict.TryGetValue("start", out v) ? ConvertToInt(v) : (IsNumeric(Param("start")) ? Param<int>("start") : -1);
            int page = IsDictionary(dict) && dict.TryGetValue("page", out v) ? ConvertToInt(v) : (IsNumeric(Param("page")) ? Param<int>("page") : -1);
            offset = start >= 0 ? start : (page > 0 && pageSize > 0 ? (page - 1) * pageSize : 0);
            string userSelect = Decrypt(IsDictionary(dict) && dict.TryGetValue("s", out v) && v != null ? v : Post("s"));
            string userFilter = Decrypt(IsDictionary(dict) && dict.TryGetValue("f", out v) && v != null ? v : Post("f"));
            string userOrderBy = Decrypt(IsDictionary(dict) && dict.TryGetValue("o", out v) && v != null ? v : Post("o"));

            // Selected records from modal, skip parent/filter fields and show all records
            lookup.LookupType = lookupType; // Lookup type
            lookup.FilterValues.Clear(); // Clear filter values first
            StringValues keys = IsDictionary(dict) && dict.TryGetValue("keys", out v) && !Empty(v)
                ? (StringValues)v
                : (Post("keys[]", out StringValues k) ? (StringValues)k : StringValues.Empty);
            if (!Empty(keys)) { // Selected records from modal
                lookup.FilterFields = new (); // Skip parent fields if any
                pageSize = -1; // Show all records
                lookup.FilterValues.Add(String.Join(",", keys.ToArray()));
            } else { // Lookup values
                string lookupValue = IsDictionary(dict) && (dict.TryGetValue("v0", out v) && v != null || dict.TryGetValue("lookupValue", out v) && v != null)
                    ? v
                    : (Post<string>("v0") ?? Post("lookupValue"));
                lookup.FilterValues.Add(lookupValue);
            }
            int cnt = IsDictionary(lookup.FilterFields) ? lookup.FilterFields.Count : 0;
            for (int i = 1; i <= cnt; i++) {
                var val = UrlDecode(IsDictionary(dict) && dict.TryGetValue("v" + i, out v) ? v : Post("v" + i));
                if (val != null) // DN
                    lookup.FilterValues.Add(val);
            }
            lookup.SearchValue = searchValue;
            lookup.PageSize = pageSize;
            lookup.Offset = offset;
            if (userSelect != "")
                lookup.UserSelect = userSelect;
            if (userFilter != "")
                lookup.UserFilter = userFilter;
            if (userOrderBy != "")
                lookup.UserOrderBy = userOrderBy;
            return await lookup.ToJson(this);
        }
        #pragma warning restore 219

        // Properties
        public string FormClassName = "ew-form ew-add-form";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public int StartRecord;

        public DbDataReader? Recordset = null; // Reserved // DN

        public bool CopyRecord;

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

            // Create form object
            CurrentForm ??= new ();
            await CurrentForm.Init();
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

            // Load default values for add
            LoadDefaultValues();

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;
            bool postBack = false;
            StringValues sv;

            // Set up current action
            if (IsApi()) {
                CurrentAction = "insert"; // Add record directly
                postBack = true;
            } else if (!Empty(Post("action"))) {
                CurrentAction = Post("action"); // Get form action
                if (Post(OldKeyName, out sv))
                    SetKey(sv.ToString());
                postBack = true;
            } else {
                // Load key from QueryString
                string[] keyValues = {};
                object? rv;
                if (RouteValues.TryGetValue("key", out object? k))
                    keyValues = ConvertToString(k).Split('/'); // For Copy page
                if (RouteValues.TryGetValue("McuResult_ID", out rv)) { // DN
                    McuResult_ID.QueryValue = UrlDecode(rv); // DN
                } else if (Get("McuResult_ID", out sv)) {
                    McuResult_ID.QueryValue = sv.ToString();
                }
                OldKey = GetKey(true); // Get from CurrentValue
                CopyRecord = !Empty(OldKey);
                if (CopyRecord) {
                    CurrentAction = "copy"; // Copy record
                    SetKey(OldKey); // Set up record key
                } else {
                    CurrentAction = "show"; // Display blank record
                }
            }

            // Load old record / default values
            var rsold = await LoadOldRecord();

            // Load form values
            if (postBack) {
                await LoadFormValues(); // Load form values
            }

            // Validate form if post back
            if (postBack) {
                if (!await ValidateForm()) {
                    EventCancelled = true; // Event cancelled
                    RestoreFormValues(); // Restore form values
                    if (IsApi())
                        return Terminate();
                    else
                        CurrentAction = "show"; // Form error, reset action
                }
            }

            // Perform current action
            switch (CurrentAction) {
                case "copy": // Copy an existing record
                    if (rsold == null) { // Record not loaded
                        if (Empty(FailureMessage))
                            FailureMessage = Language.Phrase("NoRecord"); // No record found
                        return Terminate("TrmcuResultList"); // No matching record, return to List page // DN
                    }
                    break;
                case "insert": // Add new record // DN
                    SendEmail = true; // Send email on add success
                    var res = await AddRow(rsold);
                    if (res) { // Add successful
                        if (Empty(SuccessMessage) && Post("addopt") != "1") // Skip success message for addopt (done in JavaScript)
                            SuccessMessage = Language.Phrase("AddSuccess"); // Set up success message
                        string returnUrl = "";
                        returnUrl = ReturnUrl;
                        if (GetPageName(returnUrl) == "TrmcuResultList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "TrmcuResultView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "TrmcuResultList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "TrmcuResultList"; // Return list page content
                            }
                        }
                        if (IsJsonResponse()) { // Return to caller
                            ClearMessages(); // Clear messages for Json response
                            return res;
                        } else {
                            return Terminate(returnUrl);
                        }
                    } else if (IsApi()) { // API request, return
                        return Terminate();
                    } else {
                        EventCancelled = true; // Event cancelled
                        RestoreFormValues(); // Add failed, restore form values
                    }
                    break;
            }

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Render row based on row type
            RowType = RowType.Add; // Render add type

            // Render row
            ResetAttributes();
            await RenderRow();

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();

                // Page Render event
                trmcuResultAdd?.PageRender();
            }
            return PageResult();
        }

        // Confirm page
        public bool ConfirmPage = false; // DN

        #pragma warning disable 1998
        // Get upload files
        public async Task GetUploadFiles()
        {
            // Get upload data
            McuAttachment.Upload.Index = CurrentForm.Index;
            if (!await McuAttachment.Upload.UploadFile()) // DN
                End(McuAttachment.Upload.Message);
            McuAttachment.CurrentValue = McuAttachment.Upload.FileName;
        }
        #pragma warning restore 1998

        // Load default values
        protected void LoadDefaultValues() {
        }

        #pragma warning disable 1998
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;
            string val;

            // Check field name 'MTCrew_ID' before field var 'x_MTCrew_ID'
            val = CurrentForm.HasValue("MTCrew_ID") ? CurrentForm.GetValue("MTCrew_ID") : CurrentForm.GetValue("x_MTCrew_ID");
            if (!MTCrew_ID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTCrew_ID") && !CurrentForm.HasValue("x_MTCrew_ID")) // DN
                    MTCrew_ID.Visible = false; // Disable update for API request
                else
                    MTCrew_ID.SetFormValue(val);
            }

            // Check field name 'McuDate' before field var 'x_McuDate'
            val = CurrentForm.HasValue("McuDate") ? CurrentForm.GetValue("McuDate") : CurrentForm.GetValue("x_McuDate");
            if (!McuDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("McuDate") && !CurrentForm.HasValue("x_McuDate")) // DN
                    McuDate.Visible = false; // Disable update for API request
                else
                    McuDate.SetFormValue(val, true, validate);
                McuDate.CurrentValue = UnformatDateTime(McuDate.CurrentValue, McuDate.FormatPattern);
            }

            // Check field name 'McuExpirationDate' before field var 'x_McuExpirationDate'
            val = CurrentForm.HasValue("McuExpirationDate") ? CurrentForm.GetValue("McuExpirationDate") : CurrentForm.GetValue("x_McuExpirationDate");
            if (!McuExpirationDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("McuExpirationDate") && !CurrentForm.HasValue("x_McuExpirationDate")) // DN
                    McuExpirationDate.Visible = false; // Disable update for API request
                else
                    McuExpirationDate.SetFormValue(val, true, validate);
                McuExpirationDate.CurrentValue = UnformatDateTime(McuExpirationDate.CurrentValue, McuExpirationDate.FormatPattern);
            }

            // Check field name 'HealthStatus' before field var 'x_HealthStatus'
            val = CurrentForm.HasValue("HealthStatus") ? CurrentForm.GetValue("HealthStatus") : CurrentForm.GetValue("x_HealthStatus");
            if (!HealthStatus.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("HealthStatus") && !CurrentForm.HasValue("x_HealthStatus")) // DN
                    HealthStatus.Visible = false; // Disable update for API request
                else
                    HealthStatus.SetFormValue(val);
            }

            // Check field name 'McuLocation' before field var 'x_McuLocation'
            val = CurrentForm.HasValue("McuLocation") ? CurrentForm.GetValue("McuLocation") : CurrentForm.GetValue("x_McuLocation");
            if (!McuLocation.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("McuLocation") && !CurrentForm.HasValue("x_McuLocation")) // DN
                    McuLocation.Visible = false; // Disable update for API request
                else
                    McuLocation.SetFormValue(val);
            }

            // Check field name 'CreatedByUserID' before field var 'x_CreatedByUserID'
            val = CurrentForm.HasValue("CreatedByUserID") ? CurrentForm.GetValue("CreatedByUserID") : CurrentForm.GetValue("x_CreatedByUserID");
            if (!CreatedByUserID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CreatedByUserID") && !CurrentForm.HasValue("x_CreatedByUserID")) // DN
                    CreatedByUserID.Visible = false; // Disable update for API request
                else
                    CreatedByUserID.SetFormValue(val, true, validate);
            }

            // Check field name 'CreatedDateTime' before field var 'x_CreatedDateTime'
            val = CurrentForm.HasValue("CreatedDateTime") ? CurrentForm.GetValue("CreatedDateTime") : CurrentForm.GetValue("x_CreatedDateTime");
            if (!CreatedDateTime.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CreatedDateTime") && !CurrentForm.HasValue("x_CreatedDateTime")) // DN
                    CreatedDateTime.Visible = false; // Disable update for API request
                else
                    CreatedDateTime.SetFormValue(val, true, validate);
                CreatedDateTime.CurrentValue = UnformatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern);
            }

            // Check field name 'LastUpdatedByUserID' before field var 'x_LastUpdatedByUserID'
            val = CurrentForm.HasValue("LastUpdatedByUserID") ? CurrentForm.GetValue("LastUpdatedByUserID") : CurrentForm.GetValue("x_LastUpdatedByUserID");
            if (!LastUpdatedByUserID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LastUpdatedByUserID") && !CurrentForm.HasValue("x_LastUpdatedByUserID")) // DN
                    LastUpdatedByUserID.Visible = false; // Disable update for API request
                else
                    LastUpdatedByUserID.SetFormValue(val, true, validate);
            }

            // Check field name 'LastUpdatedDateTime' before field var 'x_LastUpdatedDateTime'
            val = CurrentForm.HasValue("LastUpdatedDateTime") ? CurrentForm.GetValue("LastUpdatedDateTime") : CurrentForm.GetValue("x_LastUpdatedDateTime");
            if (!LastUpdatedDateTime.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LastUpdatedDateTime") && !CurrentForm.HasValue("x_LastUpdatedDateTime")) // DN
                    LastUpdatedDateTime.Visible = false; // Disable update for API request
                else
                    LastUpdatedDateTime.SetFormValue(val, true, validate);
                LastUpdatedDateTime.CurrentValue = UnformatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern);
            }

            // Check field name 'McuScheduleDate' before field var 'x_McuScheduleDate'
            val = CurrentForm.HasValue("McuScheduleDate") ? CurrentForm.GetValue("McuScheduleDate") : CurrentForm.GetValue("x_McuScheduleDate");
            if (!McuScheduleDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("McuScheduleDate") && !CurrentForm.HasValue("x_McuScheduleDate")) // DN
                    McuScheduleDate.Visible = false; // Disable update for API request
                else
                    McuScheduleDate.SetFormValue(val, true, validate);
                McuScheduleDate.CurrentValue = UnformatDateTime(McuScheduleDate.CurrentValue, McuScheduleDate.FormatPattern);
            }

            // Check field name 'McuRemark' before field var 'x_McuRemark'
            val = CurrentForm.HasValue("McuRemark") ? CurrentForm.GetValue("McuRemark") : CurrentForm.GetValue("x_McuRemark");
            if (!McuRemark.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("McuRemark") && !CurrentForm.HasValue("x_McuRemark")) // DN
                    McuRemark.Visible = false; // Disable update for API request
                else
                    McuRemark.SetFormValue(val);
            }

            // Check field name 'McuResult_ID' before field var 'x_McuResult_ID'
            val = CurrentForm.HasValue("McuResult_ID") ? CurrentForm.GetValue("McuResult_ID") : CurrentForm.GetValue("x_McuResult_ID");
            await GetUploadFiles(); // Get upload files
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            MTCrew_ID.CurrentValue = MTCrew_ID.FormValue;
            McuDate.CurrentValue = McuDate.FormValue;
            McuDate.CurrentValue = UnformatDateTime(McuDate.CurrentValue, McuDate.FormatPattern);
            McuExpirationDate.CurrentValue = McuExpirationDate.FormValue;
            McuExpirationDate.CurrentValue = UnformatDateTime(McuExpirationDate.CurrentValue, McuExpirationDate.FormatPattern);
            HealthStatus.CurrentValue = HealthStatus.FormValue;
            McuLocation.CurrentValue = McuLocation.FormValue;
            CreatedByUserID.CurrentValue = CreatedByUserID.FormValue;
            CreatedDateTime.CurrentValue = CreatedDateTime.FormValue;
            CreatedDateTime.CurrentValue = UnformatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern);
            LastUpdatedByUserID.CurrentValue = LastUpdatedByUserID.FormValue;
            LastUpdatedDateTime.CurrentValue = LastUpdatedDateTime.FormValue;
            LastUpdatedDateTime.CurrentValue = UnformatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern);
            McuScheduleDate.CurrentValue = McuScheduleDate.FormValue;
            McuScheduleDate.CurrentValue = UnformatDateTime(McuScheduleDate.CurrentValue, McuScheduleDate.FormatPattern);
            McuRemark.CurrentValue = McuRemark.FormValue;
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
            McuResult_ID.SetDbValue(row["McuResult_ID"]);
            MTCrew_ID.SetDbValue(row["MTCrew_ID"]);
            McuDate.SetDbValue(row["McuDate"]);
            McuExpirationDate.SetDbValue(row["McuExpirationDate"]);
            HealthStatus.SetDbValue(row["HealthStatus"]);
            McuLocation.SetDbValue(row["McuLocation"]);
            McuAttachment.Upload.DbValue = row["McuAttachment"];
            McuAttachment.SetDbValue(McuAttachment.Upload.DbValue);
            CreatedByUserID.SetDbValue(row["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(row["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(row["MTUserID"]);
            McuScheduleDate.SetDbValue(row["McuScheduleDate"]);
            McuRemark.SetDbValue(row["McuRemark"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("McuResult_ID", McuResult_ID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTCrew_ID", MTCrew_ID.DefaultValue ?? DbNullValue); // DN
            row.Add("McuDate", McuDate.DefaultValue ?? DbNullValue); // DN
            row.Add("McuExpirationDate", McuExpirationDate.DefaultValue ?? DbNullValue); // DN
            row.Add("HealthStatus", HealthStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("McuLocation", McuLocation.DefaultValue ?? DbNullValue); // DN
            row.Add("McuAttachment", McuAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedByUserID", CreatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("MTUserID", MTUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("McuScheduleDate", McuScheduleDate.DefaultValue ?? DbNullValue); // DN
            row.Add("McuRemark", McuRemark.DefaultValue ?? DbNullValue); // DN
            return row;
        }

        #pragma warning disable 618, 1998
        // Load old record
        protected async Task<Dictionary<string, object>?> LoadOldRecord(DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType>? cnn = null) {
            // Load old record
            Dictionary<string, object>? row = null;
            bool validKey = !Empty(OldKey);
            if (validKey) {
                SetKey(OldKey);
                CurrentFilter = GetRecordFilter();
                string sql = CurrentSql;
                try {
                    row = await (cnn ?? Connection).GetRowAsync(sql);
                } catch {
                    row = null;
                }
            }
            await LoadRowValues(row); // Load row values
            return row;
        }
        #pragma warning restore 618, 1998

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // McuResult_ID
            McuResult_ID.RowCssClass = "row";

            // MTCrew_ID
            MTCrew_ID.RowCssClass = "row";

            // McuDate
            McuDate.RowCssClass = "row";

            // McuExpirationDate
            McuExpirationDate.RowCssClass = "row";

            // HealthStatus
            HealthStatus.RowCssClass = "row";

            // McuLocation
            McuLocation.RowCssClass = "row";

            // McuAttachment
            McuAttachment.RowCssClass = "row";

            // CreatedByUserID
            CreatedByUserID.RowCssClass = "row";

            // CreatedDateTime
            CreatedDateTime.RowCssClass = "row";

            // LastUpdatedByUserID
            LastUpdatedByUserID.RowCssClass = "row";

            // LastUpdatedDateTime
            LastUpdatedDateTime.RowCssClass = "row";

            // MTUserID
            MTUserID.RowCssClass = "row";

            // McuScheduleDate
            McuScheduleDate.RowCssClass = "row";

            // McuRemark
            McuRemark.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // MTCrew_ID
                MTCrew_ID.ViewValue = MTCrew_ID.CurrentValue;
                MTCrew_ID.ViewValue = FormatNumber(MTCrew_ID.ViewValue, MTCrew_ID.FormatPattern);
                MTCrew_ID.ViewCustomAttributes = "";

                // McuDate
                McuDate.ViewValue = McuDate.CurrentValue;
                McuDate.ViewValue = FormatDateTime(McuDate.ViewValue, McuDate.FormatPattern);
                McuDate.ViewCustomAttributes = "";

                // McuExpirationDate
                McuExpirationDate.ViewValue = McuExpirationDate.CurrentValue;
                McuExpirationDate.ViewValue = FormatDateTime(McuExpirationDate.ViewValue, McuExpirationDate.FormatPattern);
                McuExpirationDate.ViewCustomAttributes = "";

                // HealthStatus
                HealthStatus.ViewValue = ConvertToString(HealthStatus.CurrentValue); // DN
                HealthStatus.ViewCustomAttributes = "";

                // McuLocation
                McuLocation.ViewValue = ConvertToString(McuLocation.CurrentValue); // DN
                McuLocation.ViewCustomAttributes = "";

                // McuAttachment
                if (!IsNull(McuAttachment.Upload.DbValue)) {
                    McuAttachment.ViewValue = McuAttachment.Upload.DbValue;
                } else {
                    McuAttachment.ViewValue = "";
                }
                McuAttachment.ViewCustomAttributes = "";

                // CreatedByUserID
                CreatedByUserID.ViewValue = CreatedByUserID.CurrentValue;
                CreatedByUserID.ViewValue = FormatNumber(CreatedByUserID.ViewValue, CreatedByUserID.FormatPattern);
                CreatedByUserID.ViewCustomAttributes = "";

                // CreatedDateTime
                CreatedDateTime.ViewValue = CreatedDateTime.CurrentValue;
                CreatedDateTime.ViewValue = FormatDateTime(CreatedDateTime.ViewValue, CreatedDateTime.FormatPattern);
                CreatedDateTime.ViewCustomAttributes = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.ViewValue = LastUpdatedByUserID.CurrentValue;
                LastUpdatedByUserID.ViewValue = FormatNumber(LastUpdatedByUserID.ViewValue, LastUpdatedByUserID.FormatPattern);
                LastUpdatedByUserID.ViewCustomAttributes = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.ViewValue = LastUpdatedDateTime.CurrentValue;
                LastUpdatedDateTime.ViewValue = FormatDateTime(LastUpdatedDateTime.ViewValue, LastUpdatedDateTime.FormatPattern);
                LastUpdatedDateTime.ViewCustomAttributes = "";

                // McuScheduleDate
                McuScheduleDate.ViewValue = McuScheduleDate.CurrentValue;
                McuScheduleDate.ViewValue = FormatDateTime(McuScheduleDate.ViewValue, McuScheduleDate.FormatPattern);
                McuScheduleDate.ViewCustomAttributes = "";

                // McuRemark
                McuRemark.ViewValue = ConvertToString(McuRemark.CurrentValue); // DN
                McuRemark.ViewCustomAttributes = "";

                // MTCrew_ID
                MTCrew_ID.HrefValue = "";

                // McuDate
                McuDate.HrefValue = "";

                // McuExpirationDate
                McuExpirationDate.HrefValue = "";

                // HealthStatus
                HealthStatus.HrefValue = "";

                // McuLocation
                McuLocation.HrefValue = "";

                // McuAttachment
                if (!IsNull(McuAttachment.Upload.DbValue)) {
                    McuAttachment.HrefValue = ConvertToString(GetFileUploadUrl(McuAttachment, McuAttachment.HtmlDecode(ConvertToString(McuAttachment.Upload.DbValue)))); // Add prefix/suffix
                    McuAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        McuAttachment.HrefValue = FullUrl(ConvertToString(McuAttachment.HrefValue), "href");
                } else {
                    McuAttachment.HrefValue = "";
                }
                McuAttachment.ExportHrefValue = McuAttachment.UploadPath + McuAttachment.Upload.DbValue;

                // CreatedByUserID
                CreatedByUserID.HrefValue = "";

                // CreatedDateTime
                CreatedDateTime.HrefValue = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.HrefValue = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.HrefValue = "";

                // McuScheduleDate
                McuScheduleDate.HrefValue = "";

                // McuRemark
                McuRemark.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // MTCrew_ID
                MTCrew_ID.SetupEditAttributes();
                MTCrew_ID.EditValue = MTCrew_ID.CurrentValue; // DN
                MTCrew_ID.PlaceHolder = RemoveHtml(MTCrew_ID.Caption);
                if (!Empty(MTCrew_ID.EditValue) && IsNumeric(MTCrew_ID.EditValue))
                    MTCrew_ID.EditValue = FormatNumber(MTCrew_ID.EditValue, null);

                // McuDate
                McuDate.SetupEditAttributes();
                McuDate.EditValue = FormatDateTime(McuDate.CurrentValue, McuDate.FormatPattern); // DN
                McuDate.PlaceHolder = RemoveHtml(McuDate.Caption);

                // McuExpirationDate
                McuExpirationDate.SetupEditAttributes();
                McuExpirationDate.EditValue = FormatDateTime(McuExpirationDate.CurrentValue, McuExpirationDate.FormatPattern); // DN
                McuExpirationDate.PlaceHolder = RemoveHtml(McuExpirationDate.Caption);

                // HealthStatus
                HealthStatus.SetupEditAttributes();
                if (!HealthStatus.Raw)
                    HealthStatus.CurrentValue = HtmlDecode(HealthStatus.CurrentValue);
                HealthStatus.EditValue = HtmlEncode(HealthStatus.CurrentValue);
                HealthStatus.PlaceHolder = RemoveHtml(HealthStatus.Caption);

                // McuLocation
                McuLocation.SetupEditAttributes();
                if (!McuLocation.Raw)
                    McuLocation.CurrentValue = HtmlDecode(McuLocation.CurrentValue);
                McuLocation.EditValue = HtmlEncode(McuLocation.CurrentValue);
                McuLocation.PlaceHolder = RemoveHtml(McuLocation.Caption);

                // McuAttachment
                McuAttachment.SetupEditAttributes();
                McuAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(McuAttachment.Upload.DbValue)) {
                    McuAttachment.EditValue = McuAttachment.Upload.DbValue;
                } else {
                    McuAttachment.EditValue = "";
                }
                if (!Empty(McuAttachment.CurrentValue))
                        McuAttachment.Upload.FileName = ConvertToString(McuAttachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(McuAttachment);

                // CreatedByUserID
                CreatedByUserID.SetupEditAttributes();
                CreatedByUserID.EditValue = CreatedByUserID.CurrentValue; // DN
                CreatedByUserID.PlaceHolder = RemoveHtml(CreatedByUserID.Caption);
                if (!Empty(CreatedByUserID.EditValue) && IsNumeric(CreatedByUserID.EditValue))
                    CreatedByUserID.EditValue = FormatNumber(CreatedByUserID.EditValue, null);

                // CreatedDateTime
                CreatedDateTime.SetupEditAttributes();
                CreatedDateTime.EditValue = FormatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern); // DN
                CreatedDateTime.PlaceHolder = RemoveHtml(CreatedDateTime.Caption);

                // LastUpdatedByUserID
                LastUpdatedByUserID.SetupEditAttributes();
                LastUpdatedByUserID.EditValue = LastUpdatedByUserID.CurrentValue; // DN
                LastUpdatedByUserID.PlaceHolder = RemoveHtml(LastUpdatedByUserID.Caption);
                if (!Empty(LastUpdatedByUserID.EditValue) && IsNumeric(LastUpdatedByUserID.EditValue))
                    LastUpdatedByUserID.EditValue = FormatNumber(LastUpdatedByUserID.EditValue, null);

                // LastUpdatedDateTime
                LastUpdatedDateTime.SetupEditAttributes();
                LastUpdatedDateTime.EditValue = FormatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern); // DN
                LastUpdatedDateTime.PlaceHolder = RemoveHtml(LastUpdatedDateTime.Caption);

                // McuScheduleDate
                McuScheduleDate.SetupEditAttributes();
                McuScheduleDate.EditValue = FormatDateTime(McuScheduleDate.CurrentValue, McuScheduleDate.FormatPattern); // DN
                McuScheduleDate.PlaceHolder = RemoveHtml(McuScheduleDate.Caption);

                // McuRemark
                McuRemark.SetupEditAttributes();
                if (!McuRemark.Raw)
                    McuRemark.CurrentValue = HtmlDecode(McuRemark.CurrentValue);
                McuRemark.EditValue = HtmlEncode(McuRemark.CurrentValue);
                McuRemark.PlaceHolder = RemoveHtml(McuRemark.Caption);

                // Add refer script

                // MTCrew_ID
                MTCrew_ID.HrefValue = "";

                // McuDate
                McuDate.HrefValue = "";

                // McuExpirationDate
                McuExpirationDate.HrefValue = "";

                // HealthStatus
                HealthStatus.HrefValue = "";

                // McuLocation
                McuLocation.HrefValue = "";

                // McuAttachment
                if (!IsNull(McuAttachment.Upload.DbValue)) {
                    McuAttachment.HrefValue = ConvertToString(GetFileUploadUrl(McuAttachment, McuAttachment.HtmlDecode(ConvertToString(McuAttachment.Upload.DbValue)))); // Add prefix/suffix
                    McuAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        McuAttachment.HrefValue = FullUrl(ConvertToString(McuAttachment.HrefValue), "href");
                } else {
                    McuAttachment.HrefValue = "";
                }
                McuAttachment.ExportHrefValue = McuAttachment.UploadPath + McuAttachment.Upload.DbValue;

                // CreatedByUserID
                CreatedByUserID.HrefValue = "";

                // CreatedDateTime
                CreatedDateTime.HrefValue = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.HrefValue = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.HrefValue = "";

                // McuScheduleDate
                McuScheduleDate.HrefValue = "";

                // McuRemark
                McuRemark.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
            if (MTCrew_ID.Required) {
                if (!MTCrew_ID.IsDetailKey && Empty(MTCrew_ID.FormValue)) {
                    MTCrew_ID.AddErrorMessage(ConvertToString(MTCrew_ID.RequiredErrorMessage).Replace("%s", MTCrew_ID.Caption));
                }
            }
            if (McuDate.Required) {
                if (!McuDate.IsDetailKey && Empty(McuDate.FormValue)) {
                    McuDate.AddErrorMessage(ConvertToString(McuDate.RequiredErrorMessage).Replace("%s", McuDate.Caption));
                }
            }
            if (!CheckDate(McuDate.FormValue, McuDate.FormatPattern)) {
                McuDate.AddErrorMessage(McuDate.GetErrorMessage(false));
            }
            if (McuExpirationDate.Required) {
                if (!McuExpirationDate.IsDetailKey && Empty(McuExpirationDate.FormValue)) {
                    McuExpirationDate.AddErrorMessage(ConvertToString(McuExpirationDate.RequiredErrorMessage).Replace("%s", McuExpirationDate.Caption));
                }
            }
            if (!CheckDate(McuExpirationDate.FormValue, McuExpirationDate.FormatPattern)) {
                McuExpirationDate.AddErrorMessage(McuExpirationDate.GetErrorMessage(false));
            }
            if (HealthStatus.Required) {
                if (!HealthStatus.IsDetailKey && Empty(HealthStatus.FormValue)) {
                    HealthStatus.AddErrorMessage(ConvertToString(HealthStatus.RequiredErrorMessage).Replace("%s", HealthStatus.Caption));
                }
            }
            if (McuLocation.Required) {
                if (!McuLocation.IsDetailKey && Empty(McuLocation.FormValue)) {
                    McuLocation.AddErrorMessage(ConvertToString(McuLocation.RequiredErrorMessage).Replace("%s", McuLocation.Caption));
                }
            }
            if (McuAttachment.Required) {
                if (McuAttachment.Upload.FileName == "" && !McuAttachment.Upload.KeepFile) {
                    McuAttachment.AddErrorMessage(ConvertToString(McuAttachment.RequiredErrorMessage).Replace("%s", McuAttachment.Caption));
                }
            }
            if (CreatedByUserID.Required) {
                if (!CreatedByUserID.IsDetailKey && Empty(CreatedByUserID.FormValue)) {
                    CreatedByUserID.AddErrorMessage(ConvertToString(CreatedByUserID.RequiredErrorMessage).Replace("%s", CreatedByUserID.Caption));
                }
            }
            if (!CheckInteger(CreatedByUserID.FormValue)) {
                CreatedByUserID.AddErrorMessage(CreatedByUserID.GetErrorMessage(false));
            }
            if (CreatedDateTime.Required) {
                if (!CreatedDateTime.IsDetailKey && Empty(CreatedDateTime.FormValue)) {
                    CreatedDateTime.AddErrorMessage(ConvertToString(CreatedDateTime.RequiredErrorMessage).Replace("%s", CreatedDateTime.Caption));
                }
            }
            if (!CheckDate(CreatedDateTime.FormValue, CreatedDateTime.FormatPattern)) {
                CreatedDateTime.AddErrorMessage(CreatedDateTime.GetErrorMessage(false));
            }
            if (LastUpdatedByUserID.Required) {
                if (!LastUpdatedByUserID.IsDetailKey && Empty(LastUpdatedByUserID.FormValue)) {
                    LastUpdatedByUserID.AddErrorMessage(ConvertToString(LastUpdatedByUserID.RequiredErrorMessage).Replace("%s", LastUpdatedByUserID.Caption));
                }
            }
            if (!CheckInteger(LastUpdatedByUserID.FormValue)) {
                LastUpdatedByUserID.AddErrorMessage(LastUpdatedByUserID.GetErrorMessage(false));
            }
            if (LastUpdatedDateTime.Required) {
                if (!LastUpdatedDateTime.IsDetailKey && Empty(LastUpdatedDateTime.FormValue)) {
                    LastUpdatedDateTime.AddErrorMessage(ConvertToString(LastUpdatedDateTime.RequiredErrorMessage).Replace("%s", LastUpdatedDateTime.Caption));
                }
            }
            if (!CheckDate(LastUpdatedDateTime.FormValue, LastUpdatedDateTime.FormatPattern)) {
                LastUpdatedDateTime.AddErrorMessage(LastUpdatedDateTime.GetErrorMessage(false));
            }
            if (McuScheduleDate.Required) {
                if (!McuScheduleDate.IsDetailKey && Empty(McuScheduleDate.FormValue)) {
                    McuScheduleDate.AddErrorMessage(ConvertToString(McuScheduleDate.RequiredErrorMessage).Replace("%s", McuScheduleDate.Caption));
                }
            }
            if (!CheckDate(McuScheduleDate.FormValue, McuScheduleDate.FormatPattern)) {
                McuScheduleDate.AddErrorMessage(McuScheduleDate.GetErrorMessage(false));
            }
            if (McuRemark.Required) {
                if (!McuRemark.IsDetailKey && Empty(McuRemark.FormValue)) {
                    McuRemark.AddErrorMessage(ConvertToString(McuRemark.RequiredErrorMessage).Replace("%s", McuRemark.Caption));
                }
            }

            // Return validate result
            validateForm = validateForm && !HasInvalidFields();

            // Call Form CustomValidate event
            string formCustomError = "";
            validateForm = validateForm && FormCustomValidate(ref formCustomError);
            if (!Empty(formCustomError))
                FailureMessage = formCustomError;
            return validateForm;
        }
        #pragma warning restore 1998

        // Add record
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> AddRow(Dictionary<string, object>? rsold = null) { // DN
            bool result = false;

            // Set new row
            Dictionary<string, object> rsnew = new ();
            try {
                // MTCrew_ID
                MTCrew_ID.SetDbValue(rsnew, MTCrew_ID.CurrentValue);

                // McuDate
                McuDate.SetDbValue(rsnew, ConvertToDateTimeOffset(McuDate.CurrentValue, DateTimeStyles.AssumeUniversal));

                // McuExpirationDate
                McuExpirationDate.SetDbValue(rsnew, ConvertToDateTimeOffset(McuExpirationDate.CurrentValue, DateTimeStyles.AssumeUniversal));

                // HealthStatus
                HealthStatus.SetDbValue(rsnew, HealthStatus.CurrentValue);

                // McuLocation
                McuLocation.SetDbValue(rsnew, McuLocation.CurrentValue);

                // McuAttachment
                if (McuAttachment.Visible && !McuAttachment.Upload.KeepFile) {
                    McuAttachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(McuAttachment.Upload.FileName)) {
                        rsnew["McuAttachment"] = DbNullValue;
                    } else {
                        rsnew["McuAttachment"] = McuAttachment.Upload.FileName;
                    }
                }

                // CreatedByUserID
                CreatedByUserID.SetDbValue(rsnew, CreatedByUserID.CurrentValue);

                // CreatedDateTime
                CreatedDateTime.SetDbValue(rsnew, ConvertToDateTimeOffset(CreatedDateTime.CurrentValue, DateTimeStyles.AssumeUniversal));

                // LastUpdatedByUserID
                LastUpdatedByUserID.SetDbValue(rsnew, LastUpdatedByUserID.CurrentValue);

                // LastUpdatedDateTime
                LastUpdatedDateTime.SetDbValue(rsnew, ConvertToDateTimeOffset(LastUpdatedDateTime.CurrentValue, DateTimeStyles.AssumeUniversal));

                // McuScheduleDate
                McuScheduleDate.SetDbValue(rsnew, ConvertToDateTimeOffset(McuScheduleDate.CurrentValue, DateTimeStyles.AssumeUniversal));

                // McuRemark
                McuRemark.SetDbValue(rsnew, McuRemark.CurrentValue);
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }
            if (McuAttachment.Visible && !McuAttachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(McuAttachment.Upload.DbValue) ? new () : new () { McuAttachment.HtmlDecode(McuAttachment.Upload.DbValue) };
                if (!Empty(McuAttachment.Upload.FileName)) {
                    var newFiles = new string[] { McuAttachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(McuAttachment, McuAttachment.Upload.Index);
                            if (FileExists(tempPath + newFiles[i])) {
                                var file = newFiles[i];
                                if (Config.DeleteUploadFiles) {
                                    bool oldFileFound = oldFiles.Any(oldFile => {
                                        if (oldFile == file) { // Old file found, no need to delete anymore
                                            oldFiles.Remove(oldFile);
                                            return true;
                                        }
                                        return false;
                                    });
                                    if (oldFileFound) // No need to check if file exists further
                                        continue;
                                }
                                var folders = new[] { McuAttachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(McuAttachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(McuAttachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    McuAttachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    McuAttachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    McuAttachment.SetDbValue(rsnew, McuAttachment.Upload.FileName);
                }
            }

            // Update current values
            SetCurrentValues(rsnew);

            // Load db values from rsold
            LoadDbValues(rsold);
            if (rsold != null) {
            }

            // Call Row Inserting event
            bool insertRow = RowInserting(rsold, rsnew);
            if (insertRow) {
                try {
                    result = ConvertToBool(await InsertAsync(rsnew));
                    rsnew["McuResult_ID"] = McuResult_ID.CurrentValue!;
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    result = false;
                }
                if (result) {
                    if (McuAttachment.Visible && !McuAttachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(McuAttachment.Upload.DbValue) ? new string[] {} : new string[] { McuAttachment.HtmlDecode(McuAttachment.Upload.DbValue) };
                        if (!Empty(McuAttachment.Upload.FileName)) {
                            newFiles = new string[] { McuAttachment.Upload.FileName };
                            var newFiles2 = new string[] { McuAttachment.HtmlDecode(ConvertToString(rsnew["McuAttachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(McuAttachment, McuAttachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await McuAttachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
                                            FailureMessage = Language.Phrase("UploadError7");
                                            return JsonBoolResult.FalseResult;
                                        }
                                    }
                                }
                            }
                        }
                        if (Config.DeleteUploadFiles) {
                            for (var i = 0; i < oldFiles.Length; i++) {
                                if (!Empty(oldFiles[i]) && !newFiles.ToList().Contains(oldFiles[i]))
                                    DeleteFile(McuAttachment.OldPhysicalUploadPath + oldFiles[i]);
                            }
                        }
                    }
                }
            } else {
                if (SuccessMessage != "" || FailureMessage != "") {
                    // Use the message, do nothing
                } else if (CancelMessage != "") {
                    FailureMessage = CancelMessage;
                    CancelMessage = "";
                } else {
                    FailureMessage = Language.Phrase("InsertCancelled");
                }
                result = false;
            }

            // Call Row Inserted event
            if (result)
                RowInserted(rsold, rsnew);

            // Write JSON for API request
            Dictionary<string, object> d = new ();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                if (GetRecordFromDictionary(rsnew) is var row && row != null) {
                    string table = TableVar;
                    d.Add(table, row);
                }
                d.Add("action", Config.ApiAddAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, result);
            }
            return new JsonBoolResult(d, result);
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("TrmcuResultList")), "", TableVar, true);
            string pageId = IsCopy ? "Copy" : "Add";
            breadcrumb.Add("add", pageId, url);
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

        // Form Custom Validate event
        public virtual bool FormCustomValidate(ref string customError) {
            //Return error message in customError
            return true;
        }
    } // End page class
} // End Partial class
