namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewExperienceForAdminAdd
    /// </summary>
    public static CrewExperienceForAdminAdd crewExperienceForAdminAdd
    {
        get => HttpData.Get<CrewExperienceForAdminAdd>("crewExperienceForAdminAdd")!;
        set => HttpData["crewExperienceForAdminAdd"] = value;
    }

    /// <summary>
    /// Page class for CrewExperienceForAdmin
    /// </summary>
    public class CrewExperienceForAdminAdd : CrewExperienceForAdminAddBase
    {
        // Constructor
        public CrewExperienceForAdminAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewExperienceForAdminAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            //Log("Page Load");
            MTVesselTypeID.DisplayValueSeparator = " ";
        }

        // Page Redirecting event
        public override void PageRedirecting(ref string url) {
            //url = newurl;
            int lastAddedExperienceCrewID = Session.GetInt("lastAddedExperienceCrewID");
            Session.Remove("lastAddedExperienceCrewID");
            url = "CrewExperienceForAdminAdd?crewID=" + ConvertToString(lastAddedExperienceCrewID);
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewExperienceForAdminAddBase : CrewExperienceForAdmin
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewExperienceForAdmin";

        // Page object name
        public string PageObjName = "crewExperienceForAdminAdd";

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
        public CrewExperienceForAdminAddBase()
        {
            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (crewExperienceForAdmin)
            if (crewExperienceForAdmin == null || crewExperienceForAdmin is CrewExperienceForAdmin)
                crewExperienceForAdmin = this;

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
        public string PageName => "CrewExperienceForAdminAdd";

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
            MTCrewID.SetVisibility();
            CompanyName.SetVisibility();
            FlagName_CountryID.SetVisibility();
            VesselName.SetVisibility();
            MTVesselTypeID.SetVisibility();
            GRT.SetVisibility();
            DWT.SetVisibility();
            MainEngine.SetVisibility();
            BHP.SetVisibility();
            MTRankID.SetVisibility();
            DateFrom.SetVisibility();
            DateUntil.SetVisibility();
            ActiveDescription.Visible = false;
            CreatedByUserID.Visible = false;
            CreatedDateTime.Visible = false;
            LastUpdatedByUserID.Visible = false;
            LastUpdatedDateTime.Visible = false;
            MTUserID.Visible = false;
            SignOnPortName.SetVisibility();
            SignOffPortName.SetVisibility();
            SignOffReason.SetVisibility();
        }

        // Constructor
        public CrewExperienceForAdminAddBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "CrewExperienceForAdminView" ? "1" : "0"); // If View page, no primary button
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

            // Set up lookup cache
            await SetupLookupOptions(FlagName_CountryID);
            await SetupLookupOptions(MTVesselTypeID);
            await SetupLookupOptions(MTRankID);

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
                if (RouteValues.TryGetValue("ID", out rv)) { // DN
                    ID.QueryValue = UrlDecode(rv); // DN
                } else if (Get("ID", out sv)) {
                    ID.QueryValue = sv.ToString();
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
                        return Terminate("CrewExperienceForAdminList"); // No matching record, return to List page // DN
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
                        if (GetPageName(returnUrl) == "CrewExperienceForAdminList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "CrewExperienceForAdminView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "CrewExperienceForAdminList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "CrewExperienceForAdminList"; // Return list page content
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
                crewExperienceForAdminAdd?.PageRender();
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

            // Check field name 'MTCrewID' before field var 'x_MTCrewID'
            val = CurrentForm.HasValue("MTCrewID") ? CurrentForm.GetValue("MTCrewID") : CurrentForm.GetValue("x_MTCrewID");
            if (!MTCrewID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTCrewID") && !CurrentForm.HasValue("x_MTCrewID")) // DN
                    MTCrewID.Visible = false; // Disable update for API request
                else
                    MTCrewID.SetFormValue(val);
            }

            // Check field name 'CompanyName' before field var 'x_CompanyName'
            val = CurrentForm.HasValue("CompanyName") ? CurrentForm.GetValue("CompanyName") : CurrentForm.GetValue("x_CompanyName");
            if (!CompanyName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CompanyName") && !CurrentForm.HasValue("x_CompanyName")) // DN
                    CompanyName.Visible = false; // Disable update for API request
                else
                    CompanyName.SetFormValue(val);
            }

            // Check field name 'FlagName_CountryID' before field var 'x_FlagName_CountryID'
            val = CurrentForm.HasValue("FlagName_CountryID") ? CurrentForm.GetValue("FlagName_CountryID") : CurrentForm.GetValue("x_FlagName_CountryID");
            if (!FlagName_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FlagName_CountryID") && !CurrentForm.HasValue("x_FlagName_CountryID")) // DN
                    FlagName_CountryID.Visible = false; // Disable update for API request
                else
                    FlagName_CountryID.SetFormValue(val);
            }

            // Check field name 'VesselName' before field var 'x_VesselName'
            val = CurrentForm.HasValue("VesselName") ? CurrentForm.GetValue("VesselName") : CurrentForm.GetValue("x_VesselName");
            if (!VesselName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("VesselName") && !CurrentForm.HasValue("x_VesselName")) // DN
                    VesselName.Visible = false; // Disable update for API request
                else
                    VesselName.SetFormValue(val);
            }

            // Check field name 'MTVesselTypeID' before field var 'x_MTVesselTypeID'
            val = CurrentForm.HasValue("MTVesselTypeID") ? CurrentForm.GetValue("MTVesselTypeID") : CurrentForm.GetValue("x_MTVesselTypeID");
            if (!MTVesselTypeID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTVesselTypeID") && !CurrentForm.HasValue("x_MTVesselTypeID")) // DN
                    MTVesselTypeID.Visible = false; // Disable update for API request
                else
                    MTVesselTypeID.SetFormValue(val);
            }

            // Check field name 'GRT' before field var 'x_GRT'
            val = CurrentForm.HasValue("GRT") ? CurrentForm.GetValue("GRT") : CurrentForm.GetValue("x_GRT");
            if (!GRT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("GRT") && !CurrentForm.HasValue("x_GRT")) // DN
                    GRT.Visible = false; // Disable update for API request
                else
                    GRT.SetFormValue(val);
            }

            // Check field name 'DWT' before field var 'x_DWT'
            val = CurrentForm.HasValue("DWT") ? CurrentForm.GetValue("DWT") : CurrentForm.GetValue("x_DWT");
            if (!DWT.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DWT") && !CurrentForm.HasValue("x_DWT")) // DN
                    DWT.Visible = false; // Disable update for API request
                else
                    DWT.SetFormValue(val);
            }

            // Check field name 'MainEngine' before field var 'x_MainEngine'
            val = CurrentForm.HasValue("MainEngine") ? CurrentForm.GetValue("MainEngine") : CurrentForm.GetValue("x_MainEngine");
            if (!MainEngine.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MainEngine") && !CurrentForm.HasValue("x_MainEngine")) // DN
                    MainEngine.Visible = false; // Disable update for API request
                else
                    MainEngine.SetFormValue(val);
            }

            // Check field name 'BHP' before field var 'x_BHP'
            val = CurrentForm.HasValue("BHP") ? CurrentForm.GetValue("BHP") : CurrentForm.GetValue("x_BHP");
            if (!BHP.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BHP") && !CurrentForm.HasValue("x_BHP")) // DN
                    BHP.Visible = false; // Disable update for API request
                else
                    BHP.SetFormValue(val);
            }

            // Check field name 'MTRankID' before field var 'x_MTRankID'
            val = CurrentForm.HasValue("MTRankID") ? CurrentForm.GetValue("MTRankID") : CurrentForm.GetValue("x_MTRankID");
            if (!MTRankID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTRankID") && !CurrentForm.HasValue("x_MTRankID")) // DN
                    MTRankID.Visible = false; // Disable update for API request
                else
                    MTRankID.SetFormValue(val);
            }

            // Check field name 'DateFrom' before field var 'x_DateFrom'
            val = CurrentForm.HasValue("DateFrom") ? CurrentForm.GetValue("DateFrom") : CurrentForm.GetValue("x_DateFrom");
            if (!DateFrom.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DateFrom") && !CurrentForm.HasValue("x_DateFrom")) // DN
                    DateFrom.Visible = false; // Disable update for API request
                else
                    DateFrom.SetFormValue(val, true, validate);
                DateFrom.CurrentValue = UnformatDateTime(DateFrom.CurrentValue, DateFrom.FormatPattern);
            }

            // Check field name 'DateUntil' before field var 'x_DateUntil'
            val = CurrentForm.HasValue("DateUntil") ? CurrentForm.GetValue("DateUntil") : CurrentForm.GetValue("x_DateUntil");
            if (!DateUntil.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DateUntil") && !CurrentForm.HasValue("x_DateUntil")) // DN
                    DateUntil.Visible = false; // Disable update for API request
                else
                    DateUntil.SetFormValue(val, true, validate);
                DateUntil.CurrentValue = UnformatDateTime(DateUntil.CurrentValue, DateUntil.FormatPattern);
            }

            // Check field name 'SignOnPortName' before field var 'x_SignOnPortName'
            val = CurrentForm.HasValue("SignOnPortName") ? CurrentForm.GetValue("SignOnPortName") : CurrentForm.GetValue("x_SignOnPortName");
            if (!SignOnPortName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SignOnPortName") && !CurrentForm.HasValue("x_SignOnPortName")) // DN
                    SignOnPortName.Visible = false; // Disable update for API request
                else
                    SignOnPortName.SetFormValue(val);
            }

            // Check field name 'SignOffPortName' before field var 'x_SignOffPortName'
            val = CurrentForm.HasValue("SignOffPortName") ? CurrentForm.GetValue("SignOffPortName") : CurrentForm.GetValue("x_SignOffPortName");
            if (!SignOffPortName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SignOffPortName") && !CurrentForm.HasValue("x_SignOffPortName")) // DN
                    SignOffPortName.Visible = false; // Disable update for API request
                else
                    SignOffPortName.SetFormValue(val);
            }

            // Check field name 'SignOffReason' before field var 'x_SignOffReason'
            val = CurrentForm.HasValue("SignOffReason") ? CurrentForm.GetValue("SignOffReason") : CurrentForm.GetValue("x_SignOffReason");
            if (!SignOffReason.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SignOffReason") && !CurrentForm.HasValue("x_SignOffReason")) // DN
                    SignOffReason.Visible = false; // Disable update for API request
                else
                    SignOffReason.SetFormValue(val);
            }

            // Check field name 'ID' before field var 'x_ID'
            val = CurrentForm.HasValue("ID") ? CurrentForm.GetValue("ID") : CurrentForm.GetValue("x_ID");
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            MTCrewID.CurrentValue = MTCrewID.FormValue;
            CompanyName.CurrentValue = CompanyName.FormValue;
            FlagName_CountryID.CurrentValue = FlagName_CountryID.FormValue;
            VesselName.CurrentValue = VesselName.FormValue;
            MTVesselTypeID.CurrentValue = MTVesselTypeID.FormValue;
            GRT.CurrentValue = GRT.FormValue;
            DWT.CurrentValue = DWT.FormValue;
            MainEngine.CurrentValue = MainEngine.FormValue;
            BHP.CurrentValue = BHP.FormValue;
            MTRankID.CurrentValue = MTRankID.FormValue;
            DateFrom.CurrentValue = DateFrom.FormValue;
            DateFrom.CurrentValue = UnformatDateTime(DateFrom.CurrentValue, DateFrom.FormatPattern);
            DateUntil.CurrentValue = DateUntil.FormValue;
            DateUntil.CurrentValue = UnformatDateTime(DateUntil.CurrentValue, DateUntil.FormatPattern);
            SignOnPortName.CurrentValue = SignOnPortName.FormValue;
            SignOffPortName.CurrentValue = SignOffPortName.FormValue;
            SignOffReason.CurrentValue = SignOffReason.FormValue;
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
                res = ShowOptionLink("add");
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
            MTCrewID.SetDbValue(row["MTCrewID"]);
            CompanyName.SetDbValue(row["CompanyName"]);
            FlagName_CountryID.SetDbValue(row["FlagName_CountryID"]);
            VesselName.SetDbValue(row["VesselName"]);
            MTVesselTypeID.SetDbValue(row["MTVesselTypeID"]);
            GRT.SetDbValue(row["GRT"]);
            DWT.SetDbValue(row["DWT"]);
            MainEngine.SetDbValue(row["MainEngine"]);
            BHP.SetDbValue(row["BHP"]);
            MTRankID.SetDbValue(row["MTRankID"]);
            DateFrom.SetDbValue(row["DateFrom"]);
            DateUntil.SetDbValue(row["DateUntil"]);
            ActiveDescription.SetDbValue(row["ActiveDescription"]);
            CreatedByUserID.SetDbValue(row["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(row["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(row["MTUserID"]);
            SignOnPortName.SetDbValue(row["SignOnPortName"]);
            SignOffPortName.SetDbValue(row["SignOffPortName"]);
            SignOffReason.SetDbValue(row["SignOffReason"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTCrewID", MTCrewID.DefaultValue ?? DbNullValue); // DN
            row.Add("CompanyName", CompanyName.DefaultValue ?? DbNullValue); // DN
            row.Add("FlagName_CountryID", FlagName_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("VesselName", VesselName.DefaultValue ?? DbNullValue); // DN
            row.Add("MTVesselTypeID", MTVesselTypeID.DefaultValue ?? DbNullValue); // DN
            row.Add("GRT", GRT.DefaultValue ?? DbNullValue); // DN
            row.Add("DWT", DWT.DefaultValue ?? DbNullValue); // DN
            row.Add("MainEngine", MainEngine.DefaultValue ?? DbNullValue); // DN
            row.Add("BHP", BHP.DefaultValue ?? DbNullValue); // DN
            row.Add("MTRankID", MTRankID.DefaultValue ?? DbNullValue); // DN
            row.Add("DateFrom", DateFrom.DefaultValue ?? DbNullValue); // DN
            row.Add("DateUntil", DateUntil.DefaultValue ?? DbNullValue); // DN
            row.Add("ActiveDescription", ActiveDescription.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedByUserID", CreatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("MTUserID", MTUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("SignOnPortName", SignOnPortName.DefaultValue ?? DbNullValue); // DN
            row.Add("SignOffPortName", SignOffPortName.DefaultValue ?? DbNullValue); // DN
            row.Add("SignOffReason", SignOffReason.DefaultValue ?? DbNullValue); // DN
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

            // MTCrewID
            MTCrewID.RowCssClass = "row";

            // CompanyName
            CompanyName.RowCssClass = "row";

            // FlagName_CountryID
            FlagName_CountryID.RowCssClass = "row";

            // VesselName
            VesselName.RowCssClass = "row";

            // MTVesselTypeID
            MTVesselTypeID.RowCssClass = "row";

            // GRT
            GRT.RowCssClass = "row";

            // DWT
            DWT.RowCssClass = "row";

            // MainEngine
            MainEngine.RowCssClass = "row";

            // BHP
            BHP.RowCssClass = "row";

            // MTRankID
            MTRankID.RowCssClass = "row";

            // DateFrom
            DateFrom.RowCssClass = "row";

            // DateUntil
            DateUntil.RowCssClass = "row";

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

            // MTUserID
            MTUserID.RowCssClass = "row";

            // SignOnPortName
            SignOnPortName.RowCssClass = "row";

            // SignOffPortName
            SignOffPortName.RowCssClass = "row";

            // SignOffReason
            SignOffReason.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // MTCrewID
                MTCrewID.ViewValue = MTCrewID.CurrentValue;
                MTCrewID.ViewValue = FormatNumber(MTCrewID.ViewValue, MTCrewID.FormatPattern);
                MTCrewID.ViewCustomAttributes = "";

                // CompanyName
                CompanyName.ViewValue = ConvertToString(CompanyName.CurrentValue); // DN
                CompanyName.ViewCustomAttributes = "";

                // FlagName_CountryID
                curVal = ConvertToString(FlagName_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (FlagName_CountryID.Lookup != null && IsDictionary(FlagName_CountryID.Lookup?.Options) && FlagName_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        FlagName_CountryID.ViewValue = FlagName_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", FlagName_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = FlagName_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && FlagName_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = FlagName_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            FlagName_CountryID.ViewValue = FlagName_CountryID.HighlightLookup(ConvertToString(rswrk[0]), FlagName_CountryID.DisplayValue(listwrk));
                        } else {
                            FlagName_CountryID.ViewValue = FormatNumber(FlagName_CountryID.CurrentValue, FlagName_CountryID.FormatPattern);
                        }
                    }
                } else {
                    FlagName_CountryID.ViewValue = DbNullValue;
                }
                FlagName_CountryID.ViewCustomAttributes = "";

                // VesselName
                VesselName.ViewValue = ConvertToString(VesselName.CurrentValue); // DN
                VesselName.ViewCustomAttributes = "";

                // MTVesselTypeID
                curVal = ConvertToString(MTVesselTypeID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MTVesselTypeID.Lookup != null && IsDictionary(MTVesselTypeID.Lookup?.Options) && MTVesselTypeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTVesselTypeID.ViewValue = MTVesselTypeID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MTVesselTypeID.CurrentValue, DataType.Number, "");
                        sqlWrk = MTVesselTypeID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MTVesselTypeID.Lookup != null) { // Lookup values found
                            var listwrk = MTVesselTypeID.Lookup?.RenderViewRow(rswrk[0]);
                            MTVesselTypeID.ViewValue = MTVesselTypeID.HighlightLookup(ConvertToString(rswrk[0]), MTVesselTypeID.DisplayValue(listwrk));
                        } else {
                            MTVesselTypeID.ViewValue = FormatNumber(MTVesselTypeID.CurrentValue, MTVesselTypeID.FormatPattern);
                        }
                    }
                } else {
                    MTVesselTypeID.ViewValue = DbNullValue;
                }
                MTVesselTypeID.ViewCustomAttributes = "";

                // GRT
                GRT.ViewValue = GRT.CurrentValue;
                GRT.ViewCustomAttributes = "";

                // DWT
                DWT.ViewValue = DWT.CurrentValue;
                DWT.ViewCustomAttributes = "";

                // MainEngine
                MainEngine.ViewValue = ConvertToString(MainEngine.CurrentValue); // DN
                MainEngine.ViewCustomAttributes = "";

                // BHP
                BHP.ViewValue = BHP.CurrentValue;
                BHP.ViewCustomAttributes = "";

                // MTRankID
                curVal = ConvertToString(MTRankID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MTRankID.Lookup != null && IsDictionary(MTRankID.Lookup?.Options) && MTRankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTRankID.ViewValue = MTRankID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MTRankID.CurrentValue, DataType.Number, "");
                        sqlWrk = MTRankID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MTRankID.Lookup != null) { // Lookup values found
                            var listwrk = MTRankID.Lookup?.RenderViewRow(rswrk[0]);
                            MTRankID.ViewValue = MTRankID.HighlightLookup(ConvertToString(rswrk[0]), MTRankID.DisplayValue(listwrk));
                        } else {
                            MTRankID.ViewValue = FormatNumber(MTRankID.CurrentValue, MTRankID.FormatPattern);
                        }
                    }
                } else {
                    MTRankID.ViewValue = DbNullValue;
                }
                MTRankID.ViewCustomAttributes = "";

                // DateFrom
                DateFrom.ViewValue = DateFrom.CurrentValue;
                DateFrom.ViewValue = FormatDateTime(DateFrom.ViewValue, DateFrom.FormatPattern);
                DateFrom.ViewCustomAttributes = "";

                // DateUntil
                DateUntil.ViewValue = DateUntil.CurrentValue;
                DateUntil.ViewValue = FormatDateTime(DateUntil.ViewValue, DateUntil.FormatPattern);
                DateUntil.ViewCustomAttributes = "";

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

                // SignOnPortName
                SignOnPortName.ViewValue = ConvertToString(SignOnPortName.CurrentValue); // DN
                SignOnPortName.ViewCustomAttributes = "";

                // SignOffPortName
                SignOffPortName.ViewValue = ConvertToString(SignOffPortName.CurrentValue); // DN
                SignOffPortName.ViewCustomAttributes = "";

                // SignOffReason
                SignOffReason.ViewValue = SignOffReason.CurrentValue;
                SignOffReason.ViewCustomAttributes = "";

                // MTCrewID
                MTCrewID.HrefValue = "";

                // CompanyName
                CompanyName.HrefValue = "";

                // FlagName_CountryID
                FlagName_CountryID.HrefValue = "";

                // VesselName
                VesselName.HrefValue = "";

                // MTVesselTypeID
                MTVesselTypeID.HrefValue = "";

                // GRT
                GRT.HrefValue = "";

                // DWT
                DWT.HrefValue = "";

                // MainEngine
                MainEngine.HrefValue = "";

                // BHP
                BHP.HrefValue = "";

                // MTRankID
                MTRankID.HrefValue = "";

                // DateFrom
                DateFrom.HrefValue = "";

                // DateUntil
                DateUntil.HrefValue = "";

                // SignOnPortName
                SignOnPortName.HrefValue = "";

                // SignOffPortName
                SignOffPortName.HrefValue = "";

                // SignOffReason
                SignOffReason.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // MTCrewID
                MTCrewID.SetupEditAttributes();
                MTCrewID.EditValue = MTCrewID.CurrentValue; // DN
                MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);
                if (!Empty(MTCrewID.EditValue) && IsNumeric(MTCrewID.EditValue))
                    MTCrewID.EditValue = FormatNumber(MTCrewID.EditValue, null);

                // CompanyName
                CompanyName.SetupEditAttributes();
                if (!CompanyName.Raw)
                    CompanyName.CurrentValue = HtmlDecode(CompanyName.CurrentValue);
                CompanyName.EditValue = HtmlEncode(CompanyName.CurrentValue);
                CompanyName.PlaceHolder = RemoveHtml(CompanyName.Caption);

                // FlagName_CountryID
                FlagName_CountryID.SetupEditAttributes();
                curVal = ConvertToString(FlagName_CountryID.CurrentValue)?.Trim() ?? "";
                if (FlagName_CountryID.Lookup != null && IsDictionary(FlagName_CountryID.Lookup?.Options) && FlagName_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    FlagName_CountryID.EditValue = FlagName_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", FlagName_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = FlagName_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    FlagName_CountryID.EditValue = rswrk;
                }
                FlagName_CountryID.PlaceHolder = RemoveHtml(FlagName_CountryID.Caption);
                if (!Empty(FlagName_CountryID.EditValue) && IsNumeric(FlagName_CountryID.EditValue))
                    FlagName_CountryID.EditValue = FormatNumber(FlagName_CountryID.EditValue, null);

                // VesselName
                VesselName.SetupEditAttributes();
                if (!VesselName.Raw)
                    VesselName.CurrentValue = HtmlDecode(VesselName.CurrentValue);
                VesselName.EditValue = HtmlEncode(VesselName.CurrentValue);
                VesselName.PlaceHolder = RemoveHtml(VesselName.Caption);

                // MTVesselTypeID
                MTVesselTypeID.SetupEditAttributes();
                curVal = ConvertToString(MTVesselTypeID.CurrentValue)?.Trim() ?? "";
                if (MTVesselTypeID.Lookup != null && IsDictionary(MTVesselTypeID.Lookup?.Options) && MTVesselTypeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTVesselTypeID.EditValue = MTVesselTypeID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTVesselTypeID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = MTVesselTypeID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTVesselTypeID.EditValue = rswrk;
                }
                MTVesselTypeID.PlaceHolder = RemoveHtml(MTVesselTypeID.Caption);
                if (!Empty(MTVesselTypeID.EditValue) && IsNumeric(MTVesselTypeID.EditValue))
                    MTVesselTypeID.EditValue = FormatNumber(MTVesselTypeID.EditValue, null);

                // GRT
                GRT.SetupEditAttributes();
                GRT.EditValue = GRT.CurrentValue; // DN
                GRT.PlaceHolder = RemoveHtml(GRT.Caption);

                // DWT
                DWT.SetupEditAttributes();
                DWT.EditValue = DWT.CurrentValue; // DN
                DWT.PlaceHolder = RemoveHtml(DWT.Caption);

                // MainEngine
                MainEngine.SetupEditAttributes();
                if (!MainEngine.Raw)
                    MainEngine.CurrentValue = HtmlDecode(MainEngine.CurrentValue);
                MainEngine.EditValue = HtmlEncode(MainEngine.CurrentValue);
                MainEngine.PlaceHolder = RemoveHtml(MainEngine.Caption);

                // BHP
                BHP.SetupEditAttributes();
                BHP.EditValue = BHP.CurrentValue; // DN
                BHP.PlaceHolder = RemoveHtml(BHP.Caption);

                // MTRankID
                MTRankID.SetupEditAttributes();
                curVal = ConvertToString(MTRankID.CurrentValue)?.Trim() ?? "";
                if (MTRankID.Lookup != null && IsDictionary(MTRankID.Lookup?.Options) && MTRankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTRankID.EditValue = MTRankID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTRankID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = MTRankID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTRankID.EditValue = rswrk;
                }
                MTRankID.PlaceHolder = RemoveHtml(MTRankID.Caption);
                if (!Empty(MTRankID.EditValue) && IsNumeric(MTRankID.EditValue))
                    MTRankID.EditValue = FormatNumber(MTRankID.EditValue, null);

                // DateFrom
                DateFrom.SetupEditAttributes();
                DateFrom.EditValue = FormatDateTime(DateFrom.CurrentValue, DateFrom.FormatPattern); // DN
                DateFrom.PlaceHolder = RemoveHtml(DateFrom.Caption);

                // DateUntil
                DateUntil.SetupEditAttributes();
                DateUntil.EditValue = FormatDateTime(DateUntil.CurrentValue, DateUntil.FormatPattern); // DN
                DateUntil.PlaceHolder = RemoveHtml(DateUntil.Caption);

                // SignOnPortName
                SignOnPortName.SetupEditAttributes();
                if (!SignOnPortName.Raw)
                    SignOnPortName.CurrentValue = HtmlDecode(SignOnPortName.CurrentValue);
                SignOnPortName.EditValue = HtmlEncode(SignOnPortName.CurrentValue);
                SignOnPortName.PlaceHolder = RemoveHtml(SignOnPortName.Caption);

                // SignOffPortName
                SignOffPortName.SetupEditAttributes();
                if (!SignOffPortName.Raw)
                    SignOffPortName.CurrentValue = HtmlDecode(SignOffPortName.CurrentValue);
                SignOffPortName.EditValue = HtmlEncode(SignOffPortName.CurrentValue);
                SignOffPortName.PlaceHolder = RemoveHtml(SignOffPortName.Caption);

                // SignOffReason
                SignOffReason.SetupEditAttributes();
                SignOffReason.EditValue = SignOffReason.CurrentValue; // DN
                SignOffReason.PlaceHolder = RemoveHtml(SignOffReason.Caption);

                // Add refer script

                // MTCrewID
                MTCrewID.HrefValue = "";

                // CompanyName
                CompanyName.HrefValue = "";

                // FlagName_CountryID
                FlagName_CountryID.HrefValue = "";

                // VesselName
                VesselName.HrefValue = "";

                // MTVesselTypeID
                MTVesselTypeID.HrefValue = "";

                // GRT
                GRT.HrefValue = "";

                // DWT
                DWT.HrefValue = "";

                // MainEngine
                MainEngine.HrefValue = "";

                // BHP
                BHP.HrefValue = "";

                // MTRankID
                MTRankID.HrefValue = "";

                // DateFrom
                DateFrom.HrefValue = "";

                // DateUntil
                DateUntil.HrefValue = "";

                // SignOnPortName
                SignOnPortName.HrefValue = "";

                // SignOffPortName
                SignOffPortName.HrefValue = "";

                // SignOffReason
                SignOffReason.HrefValue = "";
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
            if (MTCrewID.Required) {
                if (!MTCrewID.IsDetailKey && Empty(MTCrewID.FormValue)) {
                    MTCrewID.AddErrorMessage(ConvertToString(MTCrewID.RequiredErrorMessage).Replace("%s", MTCrewID.Caption));
                }
            }
            if (CompanyName.Required) {
                if (!CompanyName.IsDetailKey && Empty(CompanyName.FormValue)) {
                    CompanyName.AddErrorMessage(ConvertToString(CompanyName.RequiredErrorMessage).Replace("%s", CompanyName.Caption));
                }
            }
            if (FlagName_CountryID.Required) {
                if (!FlagName_CountryID.IsDetailKey && Empty(FlagName_CountryID.FormValue)) {
                    FlagName_CountryID.AddErrorMessage(ConvertToString(FlagName_CountryID.RequiredErrorMessage).Replace("%s", FlagName_CountryID.Caption));
                }
            }
            if (VesselName.Required) {
                if (!VesselName.IsDetailKey && Empty(VesselName.FormValue)) {
                    VesselName.AddErrorMessage(ConvertToString(VesselName.RequiredErrorMessage).Replace("%s", VesselName.Caption));
                }
            }
            if (MTVesselTypeID.Required) {
                if (!MTVesselTypeID.IsDetailKey && Empty(MTVesselTypeID.FormValue)) {
                    MTVesselTypeID.AddErrorMessage(ConvertToString(MTVesselTypeID.RequiredErrorMessage).Replace("%s", MTVesselTypeID.Caption));
                }
            }
            if (GRT.Required) {
                if (!GRT.IsDetailKey && Empty(GRT.FormValue)) {
                    GRT.AddErrorMessage(ConvertToString(GRT.RequiredErrorMessage).Replace("%s", GRT.Caption));
                }
            }
            if (DWT.Required) {
                if (!DWT.IsDetailKey && Empty(DWT.FormValue)) {
                    DWT.AddErrorMessage(ConvertToString(DWT.RequiredErrorMessage).Replace("%s", DWT.Caption));
                }
            }
            if (MainEngine.Required) {
                if (!MainEngine.IsDetailKey && Empty(MainEngine.FormValue)) {
                    MainEngine.AddErrorMessage(ConvertToString(MainEngine.RequiredErrorMessage).Replace("%s", MainEngine.Caption));
                }
            }
            if (BHP.Required) {
                if (!BHP.IsDetailKey && Empty(BHP.FormValue)) {
                    BHP.AddErrorMessage(ConvertToString(BHP.RequiredErrorMessage).Replace("%s", BHP.Caption));
                }
            }
            if (MTRankID.Required) {
                if (!MTRankID.IsDetailKey && Empty(MTRankID.FormValue)) {
                    MTRankID.AddErrorMessage(ConvertToString(MTRankID.RequiredErrorMessage).Replace("%s", MTRankID.Caption));
                }
            }
            if (DateFrom.Required) {
                if (!DateFrom.IsDetailKey && Empty(DateFrom.FormValue)) {
                    DateFrom.AddErrorMessage(ConvertToString(DateFrom.RequiredErrorMessage).Replace("%s", DateFrom.Caption));
                }
            }
            if (!CheckDate(DateFrom.FormValue, DateFrom.FormatPattern)) {
                DateFrom.AddErrorMessage(DateFrom.GetErrorMessage(false));
            }
            if (DateUntil.Required) {
                if (!DateUntil.IsDetailKey && Empty(DateUntil.FormValue)) {
                    DateUntil.AddErrorMessage(ConvertToString(DateUntil.RequiredErrorMessage).Replace("%s", DateUntil.Caption));
                }
            }
            if (!CheckDate(DateUntil.FormValue, DateUntil.FormatPattern)) {
                DateUntil.AddErrorMessage(DateUntil.GetErrorMessage(false));
            }
            if (SignOnPortName.Required) {
                if (!SignOnPortName.IsDetailKey && Empty(SignOnPortName.FormValue)) {
                    SignOnPortName.AddErrorMessage(ConvertToString(SignOnPortName.RequiredErrorMessage).Replace("%s", SignOnPortName.Caption));
                }
            }
            if (SignOffPortName.Required) {
                if (!SignOffPortName.IsDetailKey && Empty(SignOffPortName.FormValue)) {
                    SignOffPortName.AddErrorMessage(ConvertToString(SignOffPortName.RequiredErrorMessage).Replace("%s", SignOffPortName.Caption));
                }
            }
            if (SignOffReason.Required) {
                if (!SignOffReason.IsDetailKey && Empty(SignOffReason.FormValue)) {
                    SignOffReason.AddErrorMessage(ConvertToString(SignOffReason.RequiredErrorMessage).Replace("%s", SignOffReason.Caption));
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
                // MTCrewID
                MTCrewID.SetDbValue(rsnew, MTCrewID.CurrentValue);

                // CompanyName
                CompanyName.SetDbValue(rsnew, CompanyName.CurrentValue);

                // FlagName_CountryID
                FlagName_CountryID.SetDbValue(rsnew, FlagName_CountryID.CurrentValue);

                // VesselName
                VesselName.SetDbValue(rsnew, VesselName.CurrentValue);

                // MTVesselTypeID
                MTVesselTypeID.SetDbValue(rsnew, MTVesselTypeID.CurrentValue);

                // GRT
                GRT.SetDbValue(rsnew, GRT.CurrentValue);

                // DWT
                DWT.SetDbValue(rsnew, DWT.CurrentValue);

                // MainEngine
                MainEngine.SetDbValue(rsnew, MainEngine.CurrentValue);

                // BHP
                BHP.SetDbValue(rsnew, BHP.CurrentValue);

                // MTRankID
                MTRankID.SetDbValue(rsnew, MTRankID.CurrentValue);

                // DateFrom
                DateFrom.SetDbValue(rsnew, ConvertToDateTime(DateFrom.CurrentValue, DateFrom.FormatPattern));

                // DateUntil
                DateUntil.SetDbValue(rsnew, ConvertToDateTime(DateUntil.CurrentValue, DateUntil.FormatPattern));

                // SignOnPortName
                SignOnPortName.SetDbValue(rsnew, SignOnPortName.CurrentValue);

                // SignOffPortName
                SignOffPortName.SetDbValue(rsnew, SignOffPortName.CurrentValue);

                // SignOffReason
                SignOffReason.SetDbValue(rsnew, SignOffReason.CurrentValue);

                // MTUserID
                if (!Security.IsAdmin && Security.IsLoggedIn) { // Non system admin
                    rsnew["MTUserID"] = CurrentUserID();
                }
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }

            // Update current values
            SetCurrentValues(rsnew);

            // Check if valid User ID
            bool validUser = false;
            string userIdMsg;
            if (!Empty(Security.CurrentUserID) && !Security.IsAdmin) { // Non system admin
                validUser = Security.IsValidUserID(MTUserID.CurrentValue);
                if (!validUser) {
                    userIdMsg = Language.Phrase("UnAuthorizedUserID").Replace("%c", ConvertToString(Security.CurrentUserID));
                    userIdMsg = userIdMsg.Replace("%u", ConvertToString(MTUserID.CurrentValue));
                    FailureMessage = userIdMsg;
                    return JsonBoolResult.FalseResult;
                }
            }

            // Load db values from rsold
            LoadDbValues(rsold);
            if (rsold != null) {
            }

            // Call Row Inserting event
            bool insertRow = RowInserting(rsold, rsnew);
            if (insertRow) {
                try {
                    result = ConvertToBool(await InsertAsync(rsnew));
                    rsnew["ID"] = ID.CurrentValue!;
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    result = false;
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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("CrewExperienceForAdminList")), "", TableVar, true);
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
