namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewMedicalCertificateForAdminViewModeEdit
    /// </summary>
    public static CrewMedicalCertificateForAdminViewModeEdit crewMedicalCertificateForAdminViewModeEdit
    {
        get => HttpData.Get<CrewMedicalCertificateForAdminViewModeEdit>("crewMedicalCertificateForAdminViewModeEdit")!;
        set => HttpData["crewMedicalCertificateForAdminViewModeEdit"] = value;
    }

    /// <summary>
    /// Page class for CrewMedicalCertificateForAdminViewMode
    /// </summary>
    public class CrewMedicalCertificateForAdminViewModeEdit : CrewMedicalCertificateForAdminViewModeEditBase
    {
        // Constructor
        public CrewMedicalCertificateForAdminViewModeEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewMedicalCertificateForAdminViewModeEdit() : base()
        {
        }

        // Page Redirecting event
        public override void PageRedirecting(ref string url) {
            //url = newurl;
            int lastUpdatedMedicalCertificateCrewID = Session.GetInt("lastUpdatedMedicalCertificateCrewID");
            Session.Remove("lastUpdatedMedicalCertificateCrewID");
            url = "CrewMedicalCertificateForAdminViewModeList?crewID=" + ConvertToString(lastUpdatedMedicalCertificateCrewID);
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewMedicalCertificateForAdminViewModeEditBase : CrewMedicalCertificateForAdminViewMode
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewMedicalCertificateForAdminViewMode";

        // Page object name
        public string PageObjName = "crewMedicalCertificateForAdminViewModeEdit";

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
        public CrewMedicalCertificateForAdminViewModeEditBase()
        {
            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (crewMedicalCertificateForAdminViewMode)
            if (crewMedicalCertificateForAdminViewMode == null || crewMedicalCertificateForAdminViewMode is CrewMedicalCertificateForAdminViewMode)
                crewMedicalCertificateForAdminViewMode = this;

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
        public string PageName => "CrewMedicalCertificateForAdminViewModeEdit";

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
            MTMedicalCertificateID.SetVisibility();
            Number.SetVisibility();
            PlaceOfIssue.SetVisibility();
            DateOfIssue.SetVisibility();
            ExpirationDate.SetVisibility();
            Attachment.SetVisibility();
            MTCrewID.SetVisibility();
            MTUserID.Visible = false;
            ActiveDescription.Visible = false;
            CreatedByUserID.Visible = false;
            CreatedDateTime.Visible = false;
            LastUpdatedByUserID.Visible = false;
            LastUpdatedDateTime.Visible = false;
        }

        // Constructor
        public CrewMedicalCertificateForAdminViewModeEditBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "CrewMedicalCertificateForAdminViewModeView" ? "1" : "0"); // If View page, no primary button
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

        public int DisplayRecords = 1; // Number of display records

        public int StartRecord;

        public int StopRecord;

        public int TotalRecords = -1;

        public int RecordRange = 10;

        public int RecordCount;

        public Dictionary<string, string> RecordKeys = new ();

        public string FormClassName = "ew-form ew-edit-form overlay-wrapper";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public DbDataReader? Recordset; // DN

        #pragma warning disable 219
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

            // Set up lookup cache
            await SetupLookupOptions(MTMedicalCertificateID);

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;
            bool loaded = false;
            bool postBack = false;
            StringValues sv;
            object? rv;

            // Set up current action and primary key
            if (IsApi()) {
                loaded = true;

                // Load key from form
                string[] keyValues = {};
                if (RouteValues.TryGetValue("key", out object? k))
                    keyValues = ConvertToString(k).Split('/');
                if (RouteValues.TryGetValue("ID", out rv)) { // DN
                    ID.FormValue = UrlDecode(rv); // DN
                    ID.OldValue = ID.FormValue;
                } else if (CurrentForm.HasValue("x_ID")) {
                    ID.FormValue = CurrentForm.GetValue("x_ID");
                    ID.OldValue = ID.FormValue;
                } else if (!Empty(keyValues)) {
                    ID.OldValue = ConvertToString(keyValues[0]);
                } else {
                    loaded = false; // Unable to load key
                }

                // Load record
                if (loaded)
                    loaded = await LoadRow();
                if (!loaded) {
                    FailureMessage = Language.Phrase("NoRecord"); // Set no record message
                    return Terminate();
                }
                CurrentAction = "update"; // Update record directly
                OldKey = GetKey(true); // Get from CurrentValue
                postBack = true;
            } else {
                if (!Empty(Post("action"))) {
                    CurrentAction = Post("action"); // Get action code
                    if (!IsShow) // Not reload record, handle as postback
                        postBack = true;

                    // Get key from Form
                    if (Post(OldKeyName, out sv))
                        SetKey(sv.ToString(), IsShow);
                } else {
                    CurrentAction = "show"; // Default action is display

                    // Load key from QueryString
                    bool loadByQuery = false;
                    if (RouteValues.TryGetValue("ID", out rv)) { // DN
                        ID.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("ID", out sv)) {
                        ID.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        ID.CurrentValue = DbNullValue;
                    }
                }

                // Load recordset
                if (IsShow) {
                    // Load current record
                    loaded = await LoadRow();
                OldKey = loaded ? GetKey(true) : ""; // Get from CurrentValue
            }
        }

        // Process form if post back
        if (postBack) {
            await LoadFormValues(); // Get form values
            if (IsApi() && RouteValues.TryGetValue("key", out object? k)) {
                var keyValues = ConvertToString(k).Split('/');
                ID.FormValue = ConvertToString(keyValues[0]);
            }
        }

        // Validate form if post back
        if (postBack) {
            if (!await ValidateForm()) {
                EventCancelled = true; // Event cancelled
                RestoreFormValues();
                if (IsApi())
                    return Terminate();
                else
                    CurrentAction = ""; // Form error, reset action
            }
        }

        // Perform current action
        switch (CurrentAction) {
                case "show": // Get a record to display
                        if (!loaded) { // Load record based on key
                            if (Empty(FailureMessage))
                                FailureMessage = Language.Phrase("NoRecord"); // No record found
                            return Terminate("CrewMedicalCertificateForAdminViewModeList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "CrewMedicalCertificateForAdminViewModeList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) {
                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "CrewMedicalCertificateForAdminViewModeList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "CrewMedicalCertificateForAdminViewModeList"; // Return list page content
                            }
                        }
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success
                        if (IsJsonResponse()) {
                            ClearMessages(); // Clear messages for Json response
                            return res;
                        } else {
                            return Terminate(returnUrl); // Return to caller
                        }
                    } else if (IsApi()) { // API request, return
                        return Terminate();
                    } else if (IsModal && UseAjaxActions) { // Return JSON error message
                        return Controller.Json(new { success = false, error = GetFailureMessage() });
                    } else if (FailureMessage == Language.Phrase("NoRecord")) {
                        return Terminate(returnUrl); // Return to caller
                    } else {
                        EventCancelled = true; // Event cancelled
                        RestoreFormValues(); // Restore form values if update failed
                    }
                    break;
            }

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Render the record
            RowType = RowType.Edit; // Render as Edit
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
                crewMedicalCertificateForAdminViewModeEdit?.PageRender();
            }
            return PageResult();
        }
        #pragma warning restore 219

        // Confirm page
        public bool ConfirmPage = false; // DN

        #pragma warning disable 1998
        // Get upload files
        public async Task GetUploadFiles()
        {
            // Get upload data
            Attachment.Upload.Index = CurrentForm.Index;
            if (!await Attachment.Upload.UploadFile()) // DN
                End(Attachment.Upload.Message);
            Attachment.CurrentValue = Attachment.Upload.FileName;
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;
            string val;

            // Check field name 'MTMedicalCertificateID' before field var 'x_MTMedicalCertificateID'
            val = CurrentForm.HasValue("MTMedicalCertificateID") ? CurrentForm.GetValue("MTMedicalCertificateID") : CurrentForm.GetValue("x_MTMedicalCertificateID");
            if (!MTMedicalCertificateID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTMedicalCertificateID") && !CurrentForm.HasValue("x_MTMedicalCertificateID")) // DN
                    MTMedicalCertificateID.Visible = false; // Disable update for API request
                else
                    MTMedicalCertificateID.SetFormValue(val);
            }

            // Check field name 'Number' before field var 'x_Number'
            val = CurrentForm.HasValue("Number") ? CurrentForm.GetValue("Number") : CurrentForm.GetValue("x_Number");
            if (!Number.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Number") && !CurrentForm.HasValue("x_Number")) // DN
                    Number.Visible = false; // Disable update for API request
                else
                    Number.SetFormValue(val);
            }

            // Check field name 'PlaceOfIssue' before field var 'x_PlaceOfIssue'
            val = CurrentForm.HasValue("PlaceOfIssue") ? CurrentForm.GetValue("PlaceOfIssue") : CurrentForm.GetValue("x_PlaceOfIssue");
            if (!PlaceOfIssue.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PlaceOfIssue") && !CurrentForm.HasValue("x_PlaceOfIssue")) // DN
                    PlaceOfIssue.Visible = false; // Disable update for API request
                else
                    PlaceOfIssue.SetFormValue(val);
            }

            // Check field name 'DateOfIssue' before field var 'x_DateOfIssue'
            val = CurrentForm.HasValue("DateOfIssue") ? CurrentForm.GetValue("DateOfIssue") : CurrentForm.GetValue("x_DateOfIssue");
            if (!DateOfIssue.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DateOfIssue") && !CurrentForm.HasValue("x_DateOfIssue")) // DN
                    DateOfIssue.Visible = false; // Disable update for API request
                else
                    DateOfIssue.SetFormValue(val, true, validate);
                DateOfIssue.CurrentValue = UnformatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern);
            }

            // Check field name 'ExpirationDate' before field var 'x_ExpirationDate'
            val = CurrentForm.HasValue("ExpirationDate") ? CurrentForm.GetValue("ExpirationDate") : CurrentForm.GetValue("x_ExpirationDate");
            if (!ExpirationDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ExpirationDate") && !CurrentForm.HasValue("x_ExpirationDate")) // DN
                    ExpirationDate.Visible = false; // Disable update for API request
                else
                    ExpirationDate.SetFormValue(val, true, validate);
                ExpirationDate.CurrentValue = UnformatDateTime(ExpirationDate.CurrentValue, ExpirationDate.FormatPattern);
            }

            // Check field name 'MTCrewID' before field var 'x_MTCrewID'
            val = CurrentForm.HasValue("MTCrewID") ? CurrentForm.GetValue("MTCrewID") : CurrentForm.GetValue("x_MTCrewID");
            if (!MTCrewID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTCrewID") && !CurrentForm.HasValue("x_MTCrewID")) // DN
                    MTCrewID.Visible = false; // Disable update for API request
                else
                    MTCrewID.SetFormValue(val);
            }

            // Check field name 'ID' before field var 'x_ID'
            val = CurrentForm.HasValue("ID") ? CurrentForm.GetValue("ID") : CurrentForm.GetValue("x_ID");
            if (!ID.IsDetailKey)
                ID.SetFormValue(val);
            await GetUploadFiles(); // Get upload files
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            ID.CurrentValue = ID.FormValue;
            MTMedicalCertificateID.CurrentValue = MTMedicalCertificateID.FormValue;
            Number.CurrentValue = Number.FormValue;
            PlaceOfIssue.CurrentValue = PlaceOfIssue.FormValue;
            DateOfIssue.CurrentValue = DateOfIssue.FormValue;
            DateOfIssue.CurrentValue = UnformatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern);
            ExpirationDate.CurrentValue = ExpirationDate.FormValue;
            ExpirationDate.CurrentValue = UnformatDateTime(ExpirationDate.CurrentValue, ExpirationDate.FormatPattern);
            MTCrewID.CurrentValue = MTCrewID.FormValue;
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

            // Check if valid User ID
            if (res) {
                res = ShowOptionLink("edit");
                if (!res)
                    FailureMessage = DeniedMessage();
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
            MTMedicalCertificateID.SetDbValue(row["MTMedicalCertificateID"]);
            Number.SetDbValue(row["Number"]);
            PlaceOfIssue.SetDbValue(row["PlaceOfIssue"]);
            DateOfIssue.SetDbValue(row["DateOfIssue"]);
            ExpirationDate.SetDbValue(row["ExpirationDate"]);
            Attachment.Upload.DbValue = row["Attachment"];
            Attachment.SetDbValue(Attachment.Upload.DbValue);
            MTCrewID.SetDbValue(row["MTCrewID"]);
            MTUserID.SetDbValue(row["MTUserID"]);
            ActiveDescription.SetDbValue(row["ActiveDescription"]);
            CreatedByUserID.SetDbValue(row["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(row["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTMedicalCertificateID", MTMedicalCertificateID.DefaultValue ?? DbNullValue); // DN
            row.Add("Number", Number.DefaultValue ?? DbNullValue); // DN
            row.Add("PlaceOfIssue", PlaceOfIssue.DefaultValue ?? DbNullValue); // DN
            row.Add("DateOfIssue", DateOfIssue.DefaultValue ?? DbNullValue); // DN
            row.Add("ExpirationDate", ExpirationDate.DefaultValue ?? DbNullValue); // DN
            row.Add("Attachment", Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("MTCrewID", MTCrewID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTUserID", MTUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("ActiveDescription", ActiveDescription.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedByUserID", CreatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
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

            // ID
            ID.RowCssClass = "row";

            // MTMedicalCertificateID
            MTMedicalCertificateID.RowCssClass = "row";

            // Number
            Number.RowCssClass = "row";

            // PlaceOfIssue
            PlaceOfIssue.RowCssClass = "row";

            // DateOfIssue
            DateOfIssue.RowCssClass = "row";

            // ExpirationDate
            ExpirationDate.RowCssClass = "row";

            // Attachment
            Attachment.RowCssClass = "row";

            // MTCrewID
            MTCrewID.RowCssClass = "row";

            // MTUserID
            MTUserID.RowCssClass = "row";

            // ActiveDescription
            ActiveDescription.RowCssClass = "row";

            // CreatedByUserID
            CreatedByUserID.RowCssClass = "row";

            // CreatedDateTime
            CreatedDateTime.RowCssClass = "row";

            // LastUpdatedByUserID
            LastUpdatedByUserID.RowCssClass = "row";

            // LastUpdatedDateTime
            LastUpdatedDateTime.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // MTMedicalCertificateID
                curVal = ConvertToString(MTMedicalCertificateID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MTMedicalCertificateID.Lookup != null && IsDictionary(MTMedicalCertificateID.Lookup?.Options) && MTMedicalCertificateID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTMedicalCertificateID.ViewValue = MTMedicalCertificateID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MTMedicalCertificateID.CurrentValue, DataType.Number, "");
                        lookupFilter = () => MTMedicalCertificateID.GetSelectFilter();
                        sqlWrk = MTMedicalCertificateID.Lookup?.GetSql(false, filterWrk, lookupFilter, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MTMedicalCertificateID.Lookup != null) { // Lookup values found
                            var listwrk = MTMedicalCertificateID.Lookup?.RenderViewRow(rswrk[0]);
                            MTMedicalCertificateID.ViewValue = MTMedicalCertificateID.HighlightLookup(ConvertToString(rswrk[0]), MTMedicalCertificateID.DisplayValue(listwrk));
                        } else {
                            MTMedicalCertificateID.ViewValue = FormatNumber(MTMedicalCertificateID.CurrentValue, MTMedicalCertificateID.FormatPattern);
                        }
                    }
                } else {
                    MTMedicalCertificateID.ViewValue = DbNullValue;
                }
                MTMedicalCertificateID.ViewCustomAttributes = "";

                // Number
                Number.ViewValue = ConvertToString(Number.CurrentValue); // DN
                Number.ViewCustomAttributes = "";

                // PlaceOfIssue
                PlaceOfIssue.ViewValue = ConvertToString(PlaceOfIssue.CurrentValue); // DN
                PlaceOfIssue.ViewCustomAttributes = "";

                // DateOfIssue
                DateOfIssue.ViewValue = DateOfIssue.CurrentValue;
                DateOfIssue.ViewValue = FormatDateTime(DateOfIssue.ViewValue, DateOfIssue.FormatPattern);
                DateOfIssue.ViewCustomAttributes = "";

                // ExpirationDate
                ExpirationDate.ViewValue = ExpirationDate.CurrentValue;
                ExpirationDate.ViewValue = FormatDateTime(ExpirationDate.ViewValue, ExpirationDate.FormatPattern);
                ExpirationDate.ViewCustomAttributes = "";

                // Attachment
                if (!IsNull(Attachment.Upload.DbValue)) {
                    Attachment.ImageWidth = 200;
                    Attachment.ImageHeight = 0;
                    Attachment.ImageAlt = Attachment.Alt;
                    Attachment.ImageCssClass = "ew-image";
                    Attachment.ViewValue = Attachment.Upload.DbValue;
                } else {
                    Attachment.ViewValue = "";
                }
                Attachment.ViewCustomAttributes = "";

                // MTCrewID
                MTCrewID.ViewValue = MTCrewID.CurrentValue;
                MTCrewID.ViewValue = FormatNumber(MTCrewID.ViewValue, MTCrewID.FormatPattern);
                MTCrewID.ViewCustomAttributes = "";

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

                // MTMedicalCertificateID
                MTMedicalCertificateID.HrefValue = "";

                // Number
                Number.HrefValue = "";

                // PlaceOfIssue
                PlaceOfIssue.HrefValue = "";

                // DateOfIssue
                DateOfIssue.HrefValue = "";

                // ExpirationDate
                ExpirationDate.HrefValue = "";

                // Attachment
                if (!IsNull(Attachment.Upload.DbValue)) {
                    Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Attachment, Attachment.HtmlDecode(ConvertToString(Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Attachment.HrefValue = FullUrl(ConvertToString(Attachment.HrefValue), "href");
                } else {
                    Attachment.HrefValue = "";
                }
                Attachment.ExportHrefValue = Attachment.UploadPath + Attachment.Upload.DbValue;

                // MTCrewID
                MTCrewID.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // MTMedicalCertificateID
                MTMedicalCertificateID.SetupEditAttributes();
                curVal = ConvertToString(MTMedicalCertificateID.CurrentValue)?.Trim() ?? "";
                if (MTMedicalCertificateID.Lookup != null && IsDictionary(MTMedicalCertificateID.Lookup?.Options) && MTMedicalCertificateID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTMedicalCertificateID.EditValue = MTMedicalCertificateID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTMedicalCertificateID.CurrentValue, DataType.Number, "");
                    }
                    lookupFilter = () => MTMedicalCertificateID.GetSelectFilter();
                    sqlWrk = MTMedicalCertificateID.Lookup?.GetSql(true, filterWrk, lookupFilter, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTMedicalCertificateID.EditValue = rswrk;
                }
                MTMedicalCertificateID.PlaceHolder = RemoveHtml(MTMedicalCertificateID.Caption);
                if (!Empty(MTMedicalCertificateID.EditValue) && IsNumeric(MTMedicalCertificateID.EditValue))
                    MTMedicalCertificateID.EditValue = FormatNumber(MTMedicalCertificateID.EditValue, null);

                // Number
                Number.SetupEditAttributes();
                if (!Number.Raw)
                    Number.CurrentValue = HtmlDecode(Number.CurrentValue);
                Number.EditValue = HtmlEncode(Number.CurrentValue);
                Number.PlaceHolder = RemoveHtml(Number.Caption);

                // PlaceOfIssue
                PlaceOfIssue.SetupEditAttributes();
                if (!PlaceOfIssue.Raw)
                    PlaceOfIssue.CurrentValue = HtmlDecode(PlaceOfIssue.CurrentValue);
                PlaceOfIssue.EditValue = HtmlEncode(PlaceOfIssue.CurrentValue);
                PlaceOfIssue.PlaceHolder = RemoveHtml(PlaceOfIssue.Caption);

                // DateOfIssue
                DateOfIssue.SetupEditAttributes();
                DateOfIssue.EditValue = FormatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern); // DN
                DateOfIssue.PlaceHolder = RemoveHtml(DateOfIssue.Caption);

                // ExpirationDate
                ExpirationDate.SetupEditAttributes();
                ExpirationDate.EditValue = FormatDateTime(ExpirationDate.CurrentValue, ExpirationDate.FormatPattern); // DN
                ExpirationDate.PlaceHolder = RemoveHtml(ExpirationDate.Caption);

                // Attachment
                Attachment.SetupEditAttributes();
                Attachment.EditAttrs["accept"] = "jpg,jpeg,png,pdf";
                if (!IsNull(Attachment.Upload.DbValue)) {
                    Attachment.ImageWidth = 200;
                    Attachment.ImageHeight = 0;
                    Attachment.ImageAlt = Attachment.Alt;
                    Attachment.ImageCssClass = "ew-image";
                    Attachment.EditValue = Attachment.Upload.DbValue;
                } else {
                    Attachment.EditValue = "";
                }
                if (!Empty(Attachment.CurrentValue))
                        Attachment.Upload.FileName = ConvertToString(Attachment.CurrentValue);
                if (IsShow && !EventCancelled)
                    await RenderUploadField(Attachment);

                // MTCrewID
                MTCrewID.SetupEditAttributes();
                MTCrewID.EditValue = MTCrewID.CurrentValue; // DN
                MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);
                if (!Empty(MTCrewID.EditValue) && IsNumeric(MTCrewID.EditValue))
                    MTCrewID.EditValue = FormatNumber(MTCrewID.EditValue, null);

                // Edit refer script

                // MTMedicalCertificateID
                MTMedicalCertificateID.HrefValue = "";

                // Number
                Number.HrefValue = "";

                // PlaceOfIssue
                PlaceOfIssue.HrefValue = "";

                // DateOfIssue
                DateOfIssue.HrefValue = "";

                // ExpirationDate
                ExpirationDate.HrefValue = "";

                // Attachment
                if (!IsNull(Attachment.Upload.DbValue)) {
                    Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Attachment, Attachment.HtmlDecode(ConvertToString(Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Attachment.HrefValue = FullUrl(ConvertToString(Attachment.HrefValue), "href");
                } else {
                    Attachment.HrefValue = "";
                }
                Attachment.ExportHrefValue = Attachment.UploadPath + Attachment.Upload.DbValue;

                // MTCrewID
                MTCrewID.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();

            // Save data for Custom Template
            if (RowType == RowType.View || RowType == RowType.Edit || RowType == RowType.Add)
                Rows.Add(CustomTemplateFieldValues());
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
            if (MTMedicalCertificateID.Required) {
                if (!MTMedicalCertificateID.IsDetailKey && Empty(MTMedicalCertificateID.FormValue)) {
                    MTMedicalCertificateID.AddErrorMessage(ConvertToString(MTMedicalCertificateID.RequiredErrorMessage).Replace("%s", MTMedicalCertificateID.Caption));
                }
            }
            if (Number.Required) {
                if (!Number.IsDetailKey && Empty(Number.FormValue)) {
                    Number.AddErrorMessage(ConvertToString(Number.RequiredErrorMessage).Replace("%s", Number.Caption));
                }
            }
            if (PlaceOfIssue.Required) {
                if (!PlaceOfIssue.IsDetailKey && Empty(PlaceOfIssue.FormValue)) {
                    PlaceOfIssue.AddErrorMessage(ConvertToString(PlaceOfIssue.RequiredErrorMessage).Replace("%s", PlaceOfIssue.Caption));
                }
            }
            if (DateOfIssue.Required) {
                if (!DateOfIssue.IsDetailKey && Empty(DateOfIssue.FormValue)) {
                    DateOfIssue.AddErrorMessage(ConvertToString(DateOfIssue.RequiredErrorMessage).Replace("%s", DateOfIssue.Caption));
                }
            }
            if (!CheckDate(DateOfIssue.FormValue, DateOfIssue.FormatPattern)) {
                DateOfIssue.AddErrorMessage(DateOfIssue.GetErrorMessage(false));
            }
            if (ExpirationDate.Required) {
                if (!ExpirationDate.IsDetailKey && Empty(ExpirationDate.FormValue)) {
                    ExpirationDate.AddErrorMessage(ConvertToString(ExpirationDate.RequiredErrorMessage).Replace("%s", ExpirationDate.Caption));
                }
            }
            if (!CheckDate(ExpirationDate.FormValue, ExpirationDate.FormatPattern)) {
                ExpirationDate.AddErrorMessage(ExpirationDate.GetErrorMessage(false));
            }
            if (Attachment.Required) {
                if (Attachment.Upload.FileName == "" && !Attachment.Upload.KeepFile) {
                    Attachment.AddErrorMessage(ConvertToString(Attachment.RequiredErrorMessage).Replace("%s", Attachment.Caption));
                }
            }
            if (MTCrewID.Required) {
                if (!MTCrewID.IsDetailKey && Empty(MTCrewID.FormValue)) {
                    MTCrewID.AddErrorMessage(ConvertToString(MTCrewID.RequiredErrorMessage).Replace("%s", MTCrewID.Caption));
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

        // Update record based on key values
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> EditRow() { // DN
            bool result = false;
            Dictionary<string, object> rsold;
            string oldKeyFilter = GetRecordFilter();
            string filter = ApplyUserIDFilters(oldKeyFilter);

            // Load old row
            CurrentFilter = filter;
            string sql = CurrentSql;
            try {
                using var rsedit = await Connection.GetDataReaderAsync(sql);
                if (rsedit == null || !await rsedit.ReadAsync()) {
                    FailureMessage = Language.Phrase("NoRecord"); // Set no record message
                    return JsonBoolResult.FalseResult;
                }
                rsold = Connection.GetRow(rsedit);
                LoadDbValues(rsold);
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }

            // Set new row
            Dictionary<string, object> rsnew = new ();

            // MTMedicalCertificateID
            MTMedicalCertificateID.SetDbValue(rsnew, MTMedicalCertificateID.CurrentValue, MTMedicalCertificateID.ReadOnly);

            // Number
            Number.SetDbValue(rsnew, Number.CurrentValue, Number.ReadOnly);

            // PlaceOfIssue
            PlaceOfIssue.SetDbValue(rsnew, PlaceOfIssue.CurrentValue, PlaceOfIssue.ReadOnly);

            // DateOfIssue
            DateOfIssue.SetDbValue(rsnew, ConvertToDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern), DateOfIssue.ReadOnly);

            // ExpirationDate
            ExpirationDate.SetDbValue(rsnew, ConvertToDateTime(ExpirationDate.CurrentValue, ExpirationDate.FormatPattern), ExpirationDate.ReadOnly);

            // Attachment
            if (Attachment.Visible && !Attachment.ReadOnly && !Attachment.Upload.KeepFile) {
                Attachment.Upload.DbValue = rsold["Attachment"]; // Get original value
                if (Empty(Attachment.Upload.FileName)) {
                    rsnew["Attachment"] = DbNullValue;
                } else {
                    rsnew["Attachment"] = Attachment.Upload.FileName;
                }
            }

            // MTCrewID
            MTCrewID.SetDbValue(rsnew, MTCrewID.CurrentValue, MTCrewID.ReadOnly);

            // Update current values
            SetCurrentValues(rsnew);
            if (Attachment.Visible && !Attachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(Attachment.Upload.DbValue) ? new () : new () { Attachment.HtmlDecode(Attachment.Upload.DbValue) };
                if (!Empty(Attachment.Upload.FileName)) {
                    var newFiles = new string[] { Attachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(Attachment, Attachment.Upload.Index);
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
                                var folders = new[] { Attachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(Attachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(Attachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    Attachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    Attachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    Attachment.SetDbValue(rsnew, Attachment.Upload.FileName, Attachment.ReadOnly);
                }
            }

            // Call Row Updating event
            bool updateRow = RowUpdating(rsold, rsnew);
            if (updateRow) {
                try {
                    if (rsnew.Count > 0)
                        result = await UpdateAsync(rsnew, null, rsold) > 0;
                    else
                        result = true;
                    if (result) {
                        if (Attachment.Visible && !Attachment.Upload.KeepFile) {
                            var newFiles = new string[] {};
                            var oldFiles = Empty(Attachment.Upload.DbValue) ? new string[] {} : new string[] { Attachment.HtmlDecode(Attachment.Upload.DbValue) };
                            if (!Empty(Attachment.Upload.FileName)) {
                                newFiles = new string[] { Attachment.Upload.FileName };
                                var newFiles2 = new string[] { Attachment.HtmlDecode(ConvertToString(rsnew["Attachment"])) };
                                for (var i = 0; i < newFiles.Length; i++) {
                                    if (!Empty(newFiles[i])) {
                                        var file = UploadTempPath(Attachment, Attachment.Upload.Index) + newFiles[i];
                                        if (FileExists(file)) {
                                            if (!Empty(newFiles2[i])) // Use correct file name
                                                newFiles[i] = newFiles2[i];
                                            if (!await Attachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                        DeleteFile(Attachment.OldPhysicalUploadPath + oldFiles[i]);
                                }
                            }
                        }
                    }
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    return JsonBoolResult.FalseResult;
                }
            } else {
                if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {
                    // Use the message, do nothing
                } else if (!Empty(CancelMessage)) {
                    FailureMessage = CancelMessage;
                    CancelMessage = "";
                } else {
                    FailureMessage = Language.Phrase("UpdateCancelled");
                }
                result = false;
            }

            // Call Row Updated event
            if (result)
                RowUpdated(rsold, rsnew);

            // Write JSON for API request
            Dictionary<string, object> d = new ();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                if (GetRecordFromDictionary(rsnew) is var row && row != null) {
                    string table = TableVar;
                    d.Add(table, row);
                }
                d.Add("action", Config.ApiEditAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, true);
            }
            return new JsonBoolResult(d, result);
        }

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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("CrewMedicalCertificateForAdminViewModeList")), "", TableVar, true);
            string pageId = "edit";
            breadcrumb.Add("edit", pageId, url);
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
                // Set up lookup SQL
                switch (fld.FieldVar) {
                    case "x_MTMedicalCertificateID":
                        lookupFilter = () => fld.GetSelectFilter();
                        break;
                }

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

        // Form Custom Validate event
        public virtual bool FormCustomValidate(ref string customError) {
            //Return error message in customError
            return true;
        }
    } // End page class
} // End Partial class
