namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewGeneralDataForAdminViewModeEdit
    /// </summary>
    public static CrewGeneralDataForAdminViewModeEdit crewGeneralDataForAdminViewModeEdit
    {
        get => HttpData.Get<CrewGeneralDataForAdminViewModeEdit>("crewGeneralDataForAdminViewModeEdit")!;
        set => HttpData["crewGeneralDataForAdminViewModeEdit"] = value;
    }

    /// <summary>
    /// Page class for CrewGeneralDataForAdminViewMode
    /// </summary>
    public class CrewGeneralDataForAdminViewModeEdit : CrewGeneralDataForAdminViewModeEditBase
    {
        // Constructor
        public CrewGeneralDataForAdminViewModeEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewGeneralDataForAdminViewModeEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewGeneralDataForAdminViewModeEditBase : CrewGeneralDataForAdminViewMode
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewGeneralDataForAdminViewMode";

        // Page object name
        public string PageObjName = "crewGeneralDataForAdminViewModeEdit";

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
        public CrewGeneralDataForAdminViewModeEditBase()
        {
            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (crewGeneralDataForAdminViewMode)
            if (crewGeneralDataForAdminViewMode == null || crewGeneralDataForAdminViewMode is CrewGeneralDataForAdminViewMode)
                crewGeneralDataForAdminViewMode = this;

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
        public string PageName => "CrewGeneralDataForAdminViewModeEdit";

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
            EmployeeStatus.Visible = false;
            FormSubmittedDateTime.Visible = false;
            LastUpdatedByUserID.Visible = false;
            LastUpdatedDateTime.Visible = false;
            MTUserID.Visible = false;
            Reference1CompanyTelephoneCode_CountryID.SetVisibility();
            Reference2CompanyTelephoneCode_CountryID.SetVisibility();
        }

        // Constructor
        public CrewGeneralDataForAdminViewModeEditBase(Controller? controller = null): this() { // DN
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
                            return Terminate("CrewGeneralDataForAdminViewModeList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ViewUrl;
                    if (GetPageName(returnUrl) == "CrewGeneralDataForAdminViewModeList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) {
                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "CrewGeneralDataForAdminViewModeList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "CrewGeneralDataForAdminViewModeList"; // Return list page content
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
                crewGeneralDataForAdminViewModeEdit?.PageRender();
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
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;
            string val;

            // Check field name 'ForeignVisaHasBeenDenied' before field var 'x_ForeignVisaHasBeenDenied'
            val = CurrentForm.HasValue("ForeignVisaHasBeenDenied") ? CurrentForm.GetValue("ForeignVisaHasBeenDenied") : CurrentForm.GetValue("x_ForeignVisaHasBeenDenied");
            if (!ForeignVisaHasBeenDenied.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ForeignVisaHasBeenDenied") && !CurrentForm.HasValue("x_ForeignVisaHasBeenDenied")) // DN
                    ForeignVisaHasBeenDenied.Visible = false; // Disable update for API request
                else
                    ForeignVisaHasBeenDenied.SetFormValue(val);
            }

            // Check field name 'ForeignVisaDenied_CountryID' before field var 'x_ForeignVisaDenied_CountryID'
            val = CurrentForm.HasValue("ForeignVisaDenied_CountryID") ? CurrentForm.GetValue("ForeignVisaDenied_CountryID") : CurrentForm.GetValue("x_ForeignVisaDenied_CountryID");
            if (!ForeignVisaDenied_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ForeignVisaDenied_CountryID") && !CurrentForm.HasValue("x_ForeignVisaDenied_CountryID")) // DN
                    ForeignVisaDenied_CountryID.Visible = false; // Disable update for API request
                else
                    ForeignVisaDenied_CountryID.SetFormValue(val);
            }

            // Check field name 'ForeignVisaDeniedReason' before field var 'x_ForeignVisaDeniedReason'
            val = CurrentForm.HasValue("ForeignVisaDeniedReason") ? CurrentForm.GetValue("ForeignVisaDeniedReason") : CurrentForm.GetValue("x_ForeignVisaDeniedReason");
            if (!ForeignVisaDeniedReason.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ForeignVisaDeniedReason") && !CurrentForm.HasValue("x_ForeignVisaDeniedReason")) // DN
                    ForeignVisaDeniedReason.Visible = false; // Disable update for API request
                else
                    ForeignVisaDeniedReason.SetFormValue(val);
            }

            // Check field name 'HasMaritimeAccidentOrCourtOfEnquiry' before field var 'x_HasMaritimeAccidentOrCourtOfEnquiry'
            val = CurrentForm.HasValue("HasMaritimeAccidentOrCourtOfEnquiry") ? CurrentForm.GetValue("HasMaritimeAccidentOrCourtOfEnquiry") : CurrentForm.GetValue("x_HasMaritimeAccidentOrCourtOfEnquiry");
            if (!HasMaritimeAccidentOrCourtOfEnquiry.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("HasMaritimeAccidentOrCourtOfEnquiry") && !CurrentForm.HasValue("x_HasMaritimeAccidentOrCourtOfEnquiry")) // DN
                    HasMaritimeAccidentOrCourtOfEnquiry.Visible = false; // Disable update for API request
                else
                    HasMaritimeAccidentOrCourtOfEnquiry.SetFormValue(val);
            }

            // Check field name 'HasMaritimeAccidentOrCourtOfEnquiryDetails' before field var 'x_HasMaritimeAccidentOrCourtOfEnquiryDetails'
            val = CurrentForm.HasValue("HasMaritimeAccidentOrCourtOfEnquiryDetails") ? CurrentForm.GetValue("HasMaritimeAccidentOrCourtOfEnquiryDetails") : CurrentForm.GetValue("x_HasMaritimeAccidentOrCourtOfEnquiryDetails");
            if (!HasMaritimeAccidentOrCourtOfEnquiryDetails.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("HasMaritimeAccidentOrCourtOfEnquiryDetails") && !CurrentForm.HasValue("x_HasMaritimeAccidentOrCourtOfEnquiryDetails")) // DN
                    HasMaritimeAccidentOrCourtOfEnquiryDetails.Visible = false; // Disable update for API request
                else
                    HasMaritimeAccidentOrCourtOfEnquiryDetails.SetFormValue(val);
            }

            // Check field name 'Reference1CompanyName' before field var 'x_Reference1CompanyName'
            val = CurrentForm.HasValue("Reference1CompanyName") ? CurrentForm.GetValue("Reference1CompanyName") : CurrentForm.GetValue("x_Reference1CompanyName");
            if (!Reference1CompanyName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyName") && !CurrentForm.HasValue("x_Reference1CompanyName")) // DN
                    Reference1CompanyName.Visible = false; // Disable update for API request
                else
                    Reference1CompanyName.SetFormValue(val);
            }

            // Check field name 'Reference1ContactPersonName' before field var 'x_Reference1ContactPersonName'
            val = CurrentForm.HasValue("Reference1ContactPersonName") ? CurrentForm.GetValue("Reference1ContactPersonName") : CurrentForm.GetValue("x_Reference1ContactPersonName");
            if (!Reference1ContactPersonName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1ContactPersonName") && !CurrentForm.HasValue("x_Reference1ContactPersonName")) // DN
                    Reference1ContactPersonName.Visible = false; // Disable update for API request
                else
                    Reference1ContactPersonName.SetFormValue(val);
            }

            // Check field name 'Reference1CompanyAddress' before field var 'x_Reference1CompanyAddress'
            val = CurrentForm.HasValue("Reference1CompanyAddress") ? CurrentForm.GetValue("Reference1CompanyAddress") : CurrentForm.GetValue("x_Reference1CompanyAddress");
            if (!Reference1CompanyAddress.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyAddress") && !CurrentForm.HasValue("x_Reference1CompanyAddress")) // DN
                    Reference1CompanyAddress.Visible = false; // Disable update for API request
                else
                    Reference1CompanyAddress.SetFormValue(val);
            }

            // Check field name 'Reference1CompanyCountryID' before field var 'x_Reference1CompanyCountryID'
            val = CurrentForm.HasValue("Reference1CompanyCountryID") ? CurrentForm.GetValue("Reference1CompanyCountryID") : CurrentForm.GetValue("x_Reference1CompanyCountryID");
            if (!Reference1CompanyCountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyCountryID") && !CurrentForm.HasValue("x_Reference1CompanyCountryID")) // DN
                    Reference1CompanyCountryID.Visible = false; // Disable update for API request
                else
                    Reference1CompanyCountryID.SetFormValue(val);
            }

            // Check field name 'Reference1CompanyTelephone' before field var 'x_Reference1CompanyTelephone'
            val = CurrentForm.HasValue("Reference1CompanyTelephone") ? CurrentForm.GetValue("Reference1CompanyTelephone") : CurrentForm.GetValue("x_Reference1CompanyTelephone");
            if (!Reference1CompanyTelephone.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyTelephone") && !CurrentForm.HasValue("x_Reference1CompanyTelephone")) // DN
                    Reference1CompanyTelephone.Visible = false; // Disable update for API request
                else
                    Reference1CompanyTelephone.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyName' before field var 'x_Reference2CompanyName'
            val = CurrentForm.HasValue("Reference2CompanyName") ? CurrentForm.GetValue("Reference2CompanyName") : CurrentForm.GetValue("x_Reference2CompanyName");
            if (!Reference2CompanyName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyName") && !CurrentForm.HasValue("x_Reference2CompanyName")) // DN
                    Reference2CompanyName.Visible = false; // Disable update for API request
                else
                    Reference2CompanyName.SetFormValue(val);
            }

            // Check field name 'Reference2ContactPersonName' before field var 'x_Reference2ContactPersonName'
            val = CurrentForm.HasValue("Reference2ContactPersonName") ? CurrentForm.GetValue("Reference2ContactPersonName") : CurrentForm.GetValue("x_Reference2ContactPersonName");
            if (!Reference2ContactPersonName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2ContactPersonName") && !CurrentForm.HasValue("x_Reference2ContactPersonName")) // DN
                    Reference2ContactPersonName.Visible = false; // Disable update for API request
                else
                    Reference2ContactPersonName.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyAddress' before field var 'x_Reference2CompanyAddress'
            val = CurrentForm.HasValue("Reference2CompanyAddress") ? CurrentForm.GetValue("Reference2CompanyAddress") : CurrentForm.GetValue("x_Reference2CompanyAddress");
            if (!Reference2CompanyAddress.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyAddress") && !CurrentForm.HasValue("x_Reference2CompanyAddress")) // DN
                    Reference2CompanyAddress.Visible = false; // Disable update for API request
                else
                    Reference2CompanyAddress.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyCountryID' before field var 'x_Reference2CompanyCountryID'
            val = CurrentForm.HasValue("Reference2CompanyCountryID") ? CurrentForm.GetValue("Reference2CompanyCountryID") : CurrentForm.GetValue("x_Reference2CompanyCountryID");
            if (!Reference2CompanyCountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyCountryID") && !CurrentForm.HasValue("x_Reference2CompanyCountryID")) // DN
                    Reference2CompanyCountryID.Visible = false; // Disable update for API request
                else
                    Reference2CompanyCountryID.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyTelephone' before field var 'x_Reference2CompanyTelephone'
            val = CurrentForm.HasValue("Reference2CompanyTelephone") ? CurrentForm.GetValue("Reference2CompanyTelephone") : CurrentForm.GetValue("x_Reference2CompanyTelephone");
            if (!Reference2CompanyTelephone.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyTelephone") && !CurrentForm.HasValue("x_Reference2CompanyTelephone")) // DN
                    Reference2CompanyTelephone.Visible = false; // Disable update for API request
                else
                    Reference2CompanyTelephone.SetFormValue(val);
            }

            // Check field name 'Reference1CompanyTelephoneCode_CountryID' before field var 'x_Reference1CompanyTelephoneCode_CountryID'
            val = CurrentForm.HasValue("Reference1CompanyTelephoneCode_CountryID") ? CurrentForm.GetValue("Reference1CompanyTelephoneCode_CountryID") : CurrentForm.GetValue("x_Reference1CompanyTelephoneCode_CountryID");
            if (!Reference1CompanyTelephoneCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyTelephoneCode_CountryID") && !CurrentForm.HasValue("x_Reference1CompanyTelephoneCode_CountryID")) // DN
                    Reference1CompanyTelephoneCode_CountryID.Visible = false; // Disable update for API request
                else
                    Reference1CompanyTelephoneCode_CountryID.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyTelephoneCode_CountryID' before field var 'x_Reference2CompanyTelephoneCode_CountryID'
            val = CurrentForm.HasValue("Reference2CompanyTelephoneCode_CountryID") ? CurrentForm.GetValue("Reference2CompanyTelephoneCode_CountryID") : CurrentForm.GetValue("x_Reference2CompanyTelephoneCode_CountryID");
            if (!Reference2CompanyTelephoneCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyTelephoneCode_CountryID") && !CurrentForm.HasValue("x_Reference2CompanyTelephoneCode_CountryID")) // DN
                    Reference2CompanyTelephoneCode_CountryID.Visible = false; // Disable update for API request
                else
                    Reference2CompanyTelephoneCode_CountryID.SetFormValue(val);
            }

            // Check field name 'ID' before field var 'x_ID'
            val = CurrentForm.HasValue("ID") ? CurrentForm.GetValue("ID") : CurrentForm.GetValue("x_ID");
            if (!ID.IsDetailKey)
                ID.SetFormValue(val);
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            ID.CurrentValue = ID.FormValue;
            ForeignVisaHasBeenDenied.CurrentValue = ForeignVisaHasBeenDenied.FormValue;
            ForeignVisaDenied_CountryID.CurrentValue = ForeignVisaDenied_CountryID.FormValue;
            ForeignVisaDeniedReason.CurrentValue = ForeignVisaDeniedReason.FormValue;
            HasMaritimeAccidentOrCourtOfEnquiry.CurrentValue = HasMaritimeAccidentOrCourtOfEnquiry.FormValue;
            HasMaritimeAccidentOrCourtOfEnquiryDetails.CurrentValue = HasMaritimeAccidentOrCourtOfEnquiryDetails.FormValue;
            Reference1CompanyName.CurrentValue = Reference1CompanyName.FormValue;
            Reference1ContactPersonName.CurrentValue = Reference1ContactPersonName.FormValue;
            Reference1CompanyAddress.CurrentValue = Reference1CompanyAddress.FormValue;
            Reference1CompanyCountryID.CurrentValue = Reference1CompanyCountryID.FormValue;
            Reference1CompanyTelephone.CurrentValue = Reference1CompanyTelephone.FormValue;
            Reference2CompanyName.CurrentValue = Reference2CompanyName.FormValue;
            Reference2ContactPersonName.CurrentValue = Reference2ContactPersonName.FormValue;
            Reference2CompanyAddress.CurrentValue = Reference2CompanyAddress.FormValue;
            Reference2CompanyCountryID.CurrentValue = Reference2CompanyCountryID.FormValue;
            Reference2CompanyTelephone.CurrentValue = Reference2CompanyTelephone.FormValue;
            Reference1CompanyTelephoneCode_CountryID.CurrentValue = Reference1CompanyTelephoneCode_CountryID.FormValue;
            Reference2CompanyTelephoneCode_CountryID.CurrentValue = Reference2CompanyTelephoneCode_CountryID.FormValue;
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

            // ForeignVisaHasBeenDenied
            ForeignVisaHasBeenDenied.RowCssClass = "row";

            // ForeignVisaDenied_CountryID
            ForeignVisaDenied_CountryID.RowCssClass = "row";

            // ForeignVisaDeniedReason
            ForeignVisaDeniedReason.RowCssClass = "row";

            // HasMaritimeAccidentOrCourtOfEnquiry
            HasMaritimeAccidentOrCourtOfEnquiry.RowCssClass = "row";

            // HasMaritimeAccidentOrCourtOfEnquiryDetails
            HasMaritimeAccidentOrCourtOfEnquiryDetails.RowCssClass = "row";

            // Reference1CompanyName
            Reference1CompanyName.RowCssClass = "row";

            // Reference1ContactPersonName
            Reference1ContactPersonName.RowCssClass = "row";

            // Reference1CompanyAddress
            Reference1CompanyAddress.RowCssClass = "row";

            // Reference1CompanyCountryID
            Reference1CompanyCountryID.RowCssClass = "row";

            // Reference1CompanyTelephone
            Reference1CompanyTelephone.RowCssClass = "row";

            // Reference2CompanyName
            Reference2CompanyName.RowCssClass = "row";

            // Reference2ContactPersonName
            Reference2ContactPersonName.RowCssClass = "row";

            // Reference2CompanyAddress
            Reference2CompanyAddress.RowCssClass = "row";

            // Reference2CompanyCountryID
            Reference2CompanyCountryID.RowCssClass = "row";

            // Reference2CompanyTelephone
            Reference2CompanyTelephone.RowCssClass = "row";

            // EmployeeStatus
            EmployeeStatus.RowCssClass = "row";

            // FormSubmittedDateTime
            FormSubmittedDateTime.RowCssClass = "row";

            // LastUpdatedByUserID
            LastUpdatedByUserID.RowCssClass = "row";

            // LastUpdatedDateTime
            LastUpdatedDateTime.RowCssClass = "row";

            // MTUserID
            MTUserID.RowCssClass = "row";

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.RowCssClass = "row";

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.RowCssClass = "row";

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

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.HrefValue = "";

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.HrefValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.HrefValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.HrefValue = "";

                // Reference1CompanyName
                Reference1CompanyName.HrefValue = "";

                // Reference1ContactPersonName
                Reference1ContactPersonName.HrefValue = "";

                // Reference1CompanyAddress
                Reference1CompanyAddress.HrefValue = "";

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.HrefValue = "";

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.HrefValue = "";

                // Reference2CompanyName
                Reference2CompanyName.HrefValue = "";

                // Reference2ContactPersonName
                Reference2ContactPersonName.HrefValue = "";

                // Reference2CompanyAddress
                Reference2CompanyAddress.HrefValue = "";

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.HrefValue = "";

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.HrefValue = "";

                // Reference1CompanyTelephoneCode_CountryID
                Reference1CompanyTelephoneCode_CountryID.HrefValue = "";

                // Reference2CompanyTelephoneCode_CountryID
                Reference2CompanyTelephoneCode_CountryID.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // ForeignVisaHasBeenDenied
                ForeignVisaHasBeenDenied.EditValue = ForeignVisaHasBeenDenied.Options(false);
                ForeignVisaHasBeenDenied.PlaceHolder = RemoveHtml(ForeignVisaHasBeenDenied.Caption);

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.SetupEditAttributes();
                curVal = ConvertToString(ForeignVisaDenied_CountryID.CurrentValue)?.Trim() ?? "";
                if (ForeignVisaDenied_CountryID.Lookup != null && IsDictionary(ForeignVisaDenied_CountryID.Lookup?.Options) && ForeignVisaDenied_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ForeignVisaDenied_CountryID.EditValue = ForeignVisaDenied_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", ForeignVisaDenied_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = ForeignVisaDenied_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    ForeignVisaDenied_CountryID.EditValue = rswrk;
                }
                ForeignVisaDenied_CountryID.PlaceHolder = RemoveHtml(ForeignVisaDenied_CountryID.Caption);
                if (!Empty(ForeignVisaDenied_CountryID.EditValue) && IsNumeric(ForeignVisaDenied_CountryID.EditValue))
                    ForeignVisaDenied_CountryID.EditValue = FormatNumber(ForeignVisaDenied_CountryID.EditValue, null);

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.SetupEditAttributes();
                ForeignVisaDeniedReason.EditValue = ForeignVisaDeniedReason.CurrentValue; // DN
                ForeignVisaDeniedReason.PlaceHolder = RemoveHtml(ForeignVisaDeniedReason.Caption);

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.EditValue = HasMaritimeAccidentOrCourtOfEnquiry.Options(false);
                HasMaritimeAccidentOrCourtOfEnquiry.PlaceHolder = RemoveHtml(HasMaritimeAccidentOrCourtOfEnquiry.Caption);

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.SetupEditAttributes();
                HasMaritimeAccidentOrCourtOfEnquiryDetails.EditValue = HasMaritimeAccidentOrCourtOfEnquiryDetails.CurrentValue; // DN
                HasMaritimeAccidentOrCourtOfEnquiryDetails.PlaceHolder = RemoveHtml(HasMaritimeAccidentOrCourtOfEnquiryDetails.Caption);

                // Reference1CompanyName
                Reference1CompanyName.SetupEditAttributes();
                if (!Reference1CompanyName.Raw)
                    Reference1CompanyName.CurrentValue = HtmlDecode(Reference1CompanyName.CurrentValue);
                Reference1CompanyName.EditValue = HtmlEncode(Reference1CompanyName.CurrentValue);
                Reference1CompanyName.PlaceHolder = RemoveHtml(Reference1CompanyName.Caption);

                // Reference1ContactPersonName
                Reference1ContactPersonName.SetupEditAttributes();
                if (!Reference1ContactPersonName.Raw)
                    Reference1ContactPersonName.CurrentValue = HtmlDecode(Reference1ContactPersonName.CurrentValue);
                Reference1ContactPersonName.EditValue = HtmlEncode(Reference1ContactPersonName.CurrentValue);
                Reference1ContactPersonName.PlaceHolder = RemoveHtml(Reference1ContactPersonName.Caption);

                // Reference1CompanyAddress
                Reference1CompanyAddress.SetupEditAttributes();
                Reference1CompanyAddress.EditValue = Reference1CompanyAddress.CurrentValue; // DN
                Reference1CompanyAddress.PlaceHolder = RemoveHtml(Reference1CompanyAddress.Caption);

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference1CompanyCountryID.CurrentValue)?.Trim() ?? "";
                if (Reference1CompanyCountryID.Lookup != null && IsDictionary(Reference1CompanyCountryID.Lookup?.Options) && Reference1CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference1CompanyCountryID.EditValue = Reference1CompanyCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference1CompanyCountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = Reference1CompanyCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference1CompanyCountryID.EditValue = rswrk;
                }
                Reference1CompanyCountryID.PlaceHolder = RemoveHtml(Reference1CompanyCountryID.Caption);
                if (!Empty(Reference1CompanyCountryID.EditValue) && IsNumeric(Reference1CompanyCountryID.EditValue))
                    Reference1CompanyCountryID.EditValue = FormatNumber(Reference1CompanyCountryID.EditValue, null);

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.SetupEditAttributes();
                if (!Reference1CompanyTelephone.Raw)
                    Reference1CompanyTelephone.CurrentValue = HtmlDecode(Reference1CompanyTelephone.CurrentValue);
                Reference1CompanyTelephone.EditValue = HtmlEncode(Reference1CompanyTelephone.CurrentValue);
                Reference1CompanyTelephone.PlaceHolder = RemoveHtml(Reference1CompanyTelephone.Caption);

                // Reference2CompanyName
                Reference2CompanyName.SetupEditAttributes();
                if (!Reference2CompanyName.Raw)
                    Reference2CompanyName.CurrentValue = HtmlDecode(Reference2CompanyName.CurrentValue);
                Reference2CompanyName.EditValue = HtmlEncode(Reference2CompanyName.CurrentValue);
                Reference2CompanyName.PlaceHolder = RemoveHtml(Reference2CompanyName.Caption);

                // Reference2ContactPersonName
                Reference2ContactPersonName.SetupEditAttributes();
                if (!Reference2ContactPersonName.Raw)
                    Reference2ContactPersonName.CurrentValue = HtmlDecode(Reference2ContactPersonName.CurrentValue);
                Reference2ContactPersonName.EditValue = HtmlEncode(Reference2ContactPersonName.CurrentValue);
                Reference2ContactPersonName.PlaceHolder = RemoveHtml(Reference2ContactPersonName.Caption);

                // Reference2CompanyAddress
                Reference2CompanyAddress.SetupEditAttributes();
                Reference2CompanyAddress.EditValue = Reference2CompanyAddress.CurrentValue; // DN
                Reference2CompanyAddress.PlaceHolder = RemoveHtml(Reference2CompanyAddress.Caption);

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference2CompanyCountryID.CurrentValue)?.Trim() ?? "";
                if (Reference2CompanyCountryID.Lookup != null && IsDictionary(Reference2CompanyCountryID.Lookup?.Options) && Reference2CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference2CompanyCountryID.EditValue = Reference2CompanyCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference2CompanyCountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = Reference2CompanyCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference2CompanyCountryID.EditValue = rswrk;
                }
                Reference2CompanyCountryID.PlaceHolder = RemoveHtml(Reference2CompanyCountryID.Caption);
                if (!Empty(Reference2CompanyCountryID.EditValue) && IsNumeric(Reference2CompanyCountryID.EditValue))
                    Reference2CompanyCountryID.EditValue = FormatNumber(Reference2CompanyCountryID.EditValue, null);

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.SetupEditAttributes();
                if (!Reference2CompanyTelephone.Raw)
                    Reference2CompanyTelephone.CurrentValue = HtmlDecode(Reference2CompanyTelephone.CurrentValue);
                Reference2CompanyTelephone.EditValue = HtmlEncode(Reference2CompanyTelephone.CurrentValue);
                Reference2CompanyTelephone.PlaceHolder = RemoveHtml(Reference2CompanyTelephone.Caption);

                // Reference1CompanyTelephoneCode_CountryID
                Reference1CompanyTelephoneCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference1CompanyTelephoneCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (Reference1CompanyTelephoneCode_CountryID.Lookup != null && IsDictionary(Reference1CompanyTelephoneCode_CountryID.Lookup?.Options) && Reference1CompanyTelephoneCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference1CompanyTelephoneCode_CountryID.EditValue = Reference1CompanyTelephoneCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference1CompanyTelephoneCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = Reference1CompanyTelephoneCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference1CompanyTelephoneCode_CountryID.EditValue = rswrk;
                }
                Reference1CompanyTelephoneCode_CountryID.PlaceHolder = RemoveHtml(Reference1CompanyTelephoneCode_CountryID.Caption);

                // Reference2CompanyTelephoneCode_CountryID
                Reference2CompanyTelephoneCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference2CompanyTelephoneCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (Reference2CompanyTelephoneCode_CountryID.Lookup != null && IsDictionary(Reference2CompanyTelephoneCode_CountryID.Lookup?.Options) && Reference2CompanyTelephoneCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference2CompanyTelephoneCode_CountryID.EditValue = Reference2CompanyTelephoneCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference2CompanyTelephoneCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = Reference2CompanyTelephoneCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference2CompanyTelephoneCode_CountryID.EditValue = rswrk;
                }
                Reference2CompanyTelephoneCode_CountryID.PlaceHolder = RemoveHtml(Reference2CompanyTelephoneCode_CountryID.Caption);

                // Edit refer script

                // ForeignVisaHasBeenDenied
                ForeignVisaHasBeenDenied.HrefValue = "";

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.HrefValue = "";

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.HrefValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.HrefValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.HrefValue = "";

                // Reference1CompanyName
                Reference1CompanyName.HrefValue = "";

                // Reference1ContactPersonName
                Reference1ContactPersonName.HrefValue = "";

                // Reference1CompanyAddress
                Reference1CompanyAddress.HrefValue = "";

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.HrefValue = "";

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.HrefValue = "";

                // Reference2CompanyName
                Reference2CompanyName.HrefValue = "";

                // Reference2ContactPersonName
                Reference2ContactPersonName.HrefValue = "";

                // Reference2CompanyAddress
                Reference2CompanyAddress.HrefValue = "";

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.HrefValue = "";

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.HrefValue = "";

                // Reference1CompanyTelephoneCode_CountryID
                Reference1CompanyTelephoneCode_CountryID.HrefValue = "";

                // Reference2CompanyTelephoneCode_CountryID
                Reference2CompanyTelephoneCode_CountryID.HrefValue = "";
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
            if (ForeignVisaHasBeenDenied.Required) {
                if (Empty(ForeignVisaHasBeenDenied.FormValue)) {
                    ForeignVisaHasBeenDenied.AddErrorMessage(ConvertToString(ForeignVisaHasBeenDenied.RequiredErrorMessage).Replace("%s", ForeignVisaHasBeenDenied.Caption));
                }
            }
            if (ForeignVisaDenied_CountryID.Required) {
                if (!ForeignVisaDenied_CountryID.IsDetailKey && Empty(ForeignVisaDenied_CountryID.FormValue)) {
                    ForeignVisaDenied_CountryID.AddErrorMessage(ConvertToString(ForeignVisaDenied_CountryID.RequiredErrorMessage).Replace("%s", ForeignVisaDenied_CountryID.Caption));
                }
            }
            if (ForeignVisaDeniedReason.Required) {
                if (!ForeignVisaDeniedReason.IsDetailKey && Empty(ForeignVisaDeniedReason.FormValue)) {
                    ForeignVisaDeniedReason.AddErrorMessage(ConvertToString(ForeignVisaDeniedReason.RequiredErrorMessage).Replace("%s", ForeignVisaDeniedReason.Caption));
                }
            }
            if (HasMaritimeAccidentOrCourtOfEnquiry.Required) {
                if (Empty(HasMaritimeAccidentOrCourtOfEnquiry.FormValue)) {
                    HasMaritimeAccidentOrCourtOfEnquiry.AddErrorMessage(ConvertToString(HasMaritimeAccidentOrCourtOfEnquiry.RequiredErrorMessage).Replace("%s", HasMaritimeAccidentOrCourtOfEnquiry.Caption));
                }
            }
            if (HasMaritimeAccidentOrCourtOfEnquiryDetails.Required) {
                if (!HasMaritimeAccidentOrCourtOfEnquiryDetails.IsDetailKey && Empty(HasMaritimeAccidentOrCourtOfEnquiryDetails.FormValue)) {
                    HasMaritimeAccidentOrCourtOfEnquiryDetails.AddErrorMessage(ConvertToString(HasMaritimeAccidentOrCourtOfEnquiryDetails.RequiredErrorMessage).Replace("%s", HasMaritimeAccidentOrCourtOfEnquiryDetails.Caption));
                }
            }
            if (Reference1CompanyName.Required) {
                if (!Reference1CompanyName.IsDetailKey && Empty(Reference1CompanyName.FormValue)) {
                    Reference1CompanyName.AddErrorMessage(ConvertToString(Reference1CompanyName.RequiredErrorMessage).Replace("%s", Reference1CompanyName.Caption));
                }
            }
            if (Reference1ContactPersonName.Required) {
                if (!Reference1ContactPersonName.IsDetailKey && Empty(Reference1ContactPersonName.FormValue)) {
                    Reference1ContactPersonName.AddErrorMessage(ConvertToString(Reference1ContactPersonName.RequiredErrorMessage).Replace("%s", Reference1ContactPersonName.Caption));
                }
            }
            if (Reference1CompanyAddress.Required) {
                if (!Reference1CompanyAddress.IsDetailKey && Empty(Reference1CompanyAddress.FormValue)) {
                    Reference1CompanyAddress.AddErrorMessage(ConvertToString(Reference1CompanyAddress.RequiredErrorMessage).Replace("%s", Reference1CompanyAddress.Caption));
                }
            }
            if (Reference1CompanyCountryID.Required) {
                if (!Reference1CompanyCountryID.IsDetailKey && Empty(Reference1CompanyCountryID.FormValue)) {
                    Reference1CompanyCountryID.AddErrorMessage(ConvertToString(Reference1CompanyCountryID.RequiredErrorMessage).Replace("%s", Reference1CompanyCountryID.Caption));
                }
            }
            if (Reference1CompanyTelephone.Required) {
                if (!Reference1CompanyTelephone.IsDetailKey && Empty(Reference1CompanyTelephone.FormValue)) {
                    Reference1CompanyTelephone.AddErrorMessage(ConvertToString(Reference1CompanyTelephone.RequiredErrorMessage).Replace("%s", Reference1CompanyTelephone.Caption));
                }
            }
            if (Reference2CompanyName.Required) {
                if (!Reference2CompanyName.IsDetailKey && Empty(Reference2CompanyName.FormValue)) {
                    Reference2CompanyName.AddErrorMessage(ConvertToString(Reference2CompanyName.RequiredErrorMessage).Replace("%s", Reference2CompanyName.Caption));
                }
            }
            if (Reference2ContactPersonName.Required) {
                if (!Reference2ContactPersonName.IsDetailKey && Empty(Reference2ContactPersonName.FormValue)) {
                    Reference2ContactPersonName.AddErrorMessage(ConvertToString(Reference2ContactPersonName.RequiredErrorMessage).Replace("%s", Reference2ContactPersonName.Caption));
                }
            }
            if (Reference2CompanyAddress.Required) {
                if (!Reference2CompanyAddress.IsDetailKey && Empty(Reference2CompanyAddress.FormValue)) {
                    Reference2CompanyAddress.AddErrorMessage(ConvertToString(Reference2CompanyAddress.RequiredErrorMessage).Replace("%s", Reference2CompanyAddress.Caption));
                }
            }
            if (Reference2CompanyCountryID.Required) {
                if (!Reference2CompanyCountryID.IsDetailKey && Empty(Reference2CompanyCountryID.FormValue)) {
                    Reference2CompanyCountryID.AddErrorMessage(ConvertToString(Reference2CompanyCountryID.RequiredErrorMessage).Replace("%s", Reference2CompanyCountryID.Caption));
                }
            }
            if (Reference2CompanyTelephone.Required) {
                if (!Reference2CompanyTelephone.IsDetailKey && Empty(Reference2CompanyTelephone.FormValue)) {
                    Reference2CompanyTelephone.AddErrorMessage(ConvertToString(Reference2CompanyTelephone.RequiredErrorMessage).Replace("%s", Reference2CompanyTelephone.Caption));
                }
            }
            if (Reference1CompanyTelephoneCode_CountryID.Required) {
                if (!Reference1CompanyTelephoneCode_CountryID.IsDetailKey && Empty(Reference1CompanyTelephoneCode_CountryID.FormValue)) {
                    Reference1CompanyTelephoneCode_CountryID.AddErrorMessage(ConvertToString(Reference1CompanyTelephoneCode_CountryID.RequiredErrorMessage).Replace("%s", Reference1CompanyTelephoneCode_CountryID.Caption));
                }
            }
            if (Reference2CompanyTelephoneCode_CountryID.Required) {
                if (!Reference2CompanyTelephoneCode_CountryID.IsDetailKey && Empty(Reference2CompanyTelephoneCode_CountryID.FormValue)) {
                    Reference2CompanyTelephoneCode_CountryID.AddErrorMessage(ConvertToString(Reference2CompanyTelephoneCode_CountryID.RequiredErrorMessage).Replace("%s", Reference2CompanyTelephoneCode_CountryID.Caption));
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

            // ForeignVisaHasBeenDenied
            ForeignVisaHasBeenDenied.SetDbValue(rsnew, ConvertToBool(ForeignVisaHasBeenDenied.CurrentValue), ForeignVisaHasBeenDenied.ReadOnly);

            // ForeignVisaDenied_CountryID
            ForeignVisaDenied_CountryID.SetDbValue(rsnew, ForeignVisaDenied_CountryID.CurrentValue, ForeignVisaDenied_CountryID.ReadOnly);

            // ForeignVisaDeniedReason
            ForeignVisaDeniedReason.SetDbValue(rsnew, ForeignVisaDeniedReason.CurrentValue, ForeignVisaDeniedReason.ReadOnly);

            // HasMaritimeAccidentOrCourtOfEnquiry
            HasMaritimeAccidentOrCourtOfEnquiry.SetDbValue(rsnew, ConvertToBool(HasMaritimeAccidentOrCourtOfEnquiry.CurrentValue), HasMaritimeAccidentOrCourtOfEnquiry.ReadOnly);

            // HasMaritimeAccidentOrCourtOfEnquiryDetails
            HasMaritimeAccidentOrCourtOfEnquiryDetails.SetDbValue(rsnew, HasMaritimeAccidentOrCourtOfEnquiryDetails.CurrentValue, HasMaritimeAccidentOrCourtOfEnquiryDetails.ReadOnly);

            // Reference1CompanyName
            Reference1CompanyName.SetDbValue(rsnew, Reference1CompanyName.CurrentValue, Reference1CompanyName.ReadOnly);

            // Reference1ContactPersonName
            Reference1ContactPersonName.SetDbValue(rsnew, Reference1ContactPersonName.CurrentValue, Reference1ContactPersonName.ReadOnly);

            // Reference1CompanyAddress
            Reference1CompanyAddress.SetDbValue(rsnew, Reference1CompanyAddress.CurrentValue, Reference1CompanyAddress.ReadOnly);

            // Reference1CompanyCountryID
            Reference1CompanyCountryID.SetDbValue(rsnew, Reference1CompanyCountryID.CurrentValue, Reference1CompanyCountryID.ReadOnly);

            // Reference1CompanyTelephone
            Reference1CompanyTelephone.SetDbValue(rsnew, Reference1CompanyTelephone.CurrentValue, Reference1CompanyTelephone.ReadOnly);

            // Reference2CompanyName
            Reference2CompanyName.SetDbValue(rsnew, Reference2CompanyName.CurrentValue, Reference2CompanyName.ReadOnly);

            // Reference2ContactPersonName
            Reference2ContactPersonName.SetDbValue(rsnew, Reference2ContactPersonName.CurrentValue, Reference2ContactPersonName.ReadOnly);

            // Reference2CompanyAddress
            Reference2CompanyAddress.SetDbValue(rsnew, Reference2CompanyAddress.CurrentValue, Reference2CompanyAddress.ReadOnly);

            // Reference2CompanyCountryID
            Reference2CompanyCountryID.SetDbValue(rsnew, Reference2CompanyCountryID.CurrentValue, Reference2CompanyCountryID.ReadOnly);

            // Reference2CompanyTelephone
            Reference2CompanyTelephone.SetDbValue(rsnew, Reference2CompanyTelephone.CurrentValue, Reference2CompanyTelephone.ReadOnly);

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.SetDbValue(rsnew, Reference1CompanyTelephoneCode_CountryID.CurrentValue, Reference1CompanyTelephoneCode_CountryID.ReadOnly);

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.SetDbValue(rsnew, Reference2CompanyTelephoneCode_CountryID.CurrentValue, Reference2CompanyTelephoneCode_CountryID.ReadOnly);

            // Update current values
            SetCurrentValues(rsnew);

            // Call Row Updating event
            bool updateRow = RowUpdating(rsold, rsnew);
            if (updateRow) {
                try {
                    if (rsnew.Count > 0)
                        result = await UpdateAsync(rsnew, null, rsold) > 0;
                    else
                        result = true;
                    if (result) {
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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("CrewGeneralDataForAdminViewModeList")), "", TableVar, true);
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
