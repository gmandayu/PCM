namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewAppraisalForAdminAdd
    /// </summary>
    public static CrewAppraisalForAdminAdd crewAppraisalForAdminAdd
    {
        get => HttpData.Get<CrewAppraisalForAdminAdd>("crewAppraisalForAdminAdd")!;
        set => HttpData["crewAppraisalForAdminAdd"] = value;
    }

    /// <summary>
    /// Page class for CrewAppraisalForAdmin
    /// </summary>
    public class CrewAppraisalForAdminAdd : CrewAppraisalForAdminAddBase
    {
        // Constructor
        public CrewAppraisalForAdminAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewAppraisalForAdminAdd() : base()
        {
        }

        // Page Redirecting event
        public override void PageRedirecting(ref string url) {
            //url = newurl;
            int lastAddedAppraisalCrewID = Session.GetInt("lastAddedAppraisalCrewID");
            Session.Remove("lastAddedAppraisalCrewID");
            url = "CrewAppraisalForAdminAdd?crewID=" + ConvertToString(lastAddedAppraisalCrewID);
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewAppraisalForAdminAddBase : CrewAppraisalForAdmin
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewAppraisalForAdmin";

        // Page object name
        public string PageObjName = "crewAppraisalForAdminAdd";

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
        public CrewAppraisalForAdminAddBase()
        {
            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (crewAppraisalForAdmin)
            if (crewAppraisalForAdmin == null || crewAppraisalForAdmin is CrewAppraisalForAdmin)
                crewAppraisalForAdmin = this;

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
        public string PageName => "CrewAppraisalForAdminAdd";

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
            VesselName.SetVisibility();
            MTRankID.SetVisibility();
            Questionnaire.SetVisibility();
            Approved.SetVisibility();
            AverageRating.SetVisibility();
            Rehire.SetVisibility();
            Promote.SetVisibility();
            Appraiser.SetVisibility();
            DateInput.SetVisibility();
            MTCrewID.SetVisibility();
            MTUserID.Visible = false;
            ActiveDescription.Visible = false;
            CreatedByUserID.Visible = false;
            CreatedDateTime.Visible = false;
            LastUpdatedByUserID.Visible = false;
            LastUpdatedDateTime.Visible = false;
        }

        // Constructor
        public CrewAppraisalForAdminAddBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "CrewAppraisalForAdminView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(MTRankID);
            await SetupLookupOptions(Approved);
            await SetupLookupOptions(Rehire);
            await SetupLookupOptions(Promote);

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
                        return Terminate("CrewAppraisalForAdminList"); // No matching record, return to List page // DN
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
                        if (GetPageName(returnUrl) == "CrewAppraisalForAdminList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "CrewAppraisalForAdminView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "CrewAppraisalForAdminList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "CrewAppraisalForAdminList"; // Return list page content
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
                crewAppraisalForAdminAdd?.PageRender();
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

            // Check field name 'VesselName' before field var 'x_VesselName'
            val = CurrentForm.HasValue("VesselName") ? CurrentForm.GetValue("VesselName") : CurrentForm.GetValue("x_VesselName");
            if (!VesselName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("VesselName") && !CurrentForm.HasValue("x_VesselName")) // DN
                    VesselName.Visible = false; // Disable update for API request
                else
                    VesselName.SetFormValue(val);
            }

            // Check field name 'MTRankID' before field var 'x_MTRankID'
            val = CurrentForm.HasValue("MTRankID") ? CurrentForm.GetValue("MTRankID") : CurrentForm.GetValue("x_MTRankID");
            if (!MTRankID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTRankID") && !CurrentForm.HasValue("x_MTRankID")) // DN
                    MTRankID.Visible = false; // Disable update for API request
                else
                    MTRankID.SetFormValue(val);
            }

            // Check field name 'Questionnaire' before field var 'x_Questionnaire'
            val = CurrentForm.HasValue("Questionnaire") ? CurrentForm.GetValue("Questionnaire") : CurrentForm.GetValue("x_Questionnaire");
            if (!Questionnaire.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Questionnaire") && !CurrentForm.HasValue("x_Questionnaire")) // DN
                    Questionnaire.Visible = false; // Disable update for API request
                else
                    Questionnaire.SetFormValue(val);
            }

            // Check field name 'Approved' before field var 'x_Approved'
            val = CurrentForm.HasValue("Approved") ? CurrentForm.GetValue("Approved") : CurrentForm.GetValue("x_Approved");
            if (!Approved.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Approved") && !CurrentForm.HasValue("x_Approved")) // DN
                    Approved.Visible = false; // Disable update for API request
                else
                    Approved.SetFormValue(val);
            }

            // Check field name 'AverageRating' before field var 'x_AverageRating'
            val = CurrentForm.HasValue("AverageRating") ? CurrentForm.GetValue("AverageRating") : CurrentForm.GetValue("x_AverageRating");
            if (!AverageRating.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AverageRating") && !CurrentForm.HasValue("x_AverageRating")) // DN
                    AverageRating.Visible = false; // Disable update for API request
                else
                    AverageRating.SetFormValue(val);
            }

            // Check field name 'Rehire' before field var 'x_Rehire'
            val = CurrentForm.HasValue("Rehire") ? CurrentForm.GetValue("Rehire") : CurrentForm.GetValue("x_Rehire");
            if (!Rehire.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Rehire") && !CurrentForm.HasValue("x_Rehire")) // DN
                    Rehire.Visible = false; // Disable update for API request
                else
                    Rehire.SetFormValue(val);
            }

            // Check field name 'Promote' before field var 'x_Promote'
            val = CurrentForm.HasValue("Promote") ? CurrentForm.GetValue("Promote") : CurrentForm.GetValue("x_Promote");
            if (!Promote.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Promote") && !CurrentForm.HasValue("x_Promote")) // DN
                    Promote.Visible = false; // Disable update for API request
                else
                    Promote.SetFormValue(val);
            }

            // Check field name 'Appraiser' before field var 'x_Appraiser'
            val = CurrentForm.HasValue("Appraiser") ? CurrentForm.GetValue("Appraiser") : CurrentForm.GetValue("x_Appraiser");
            if (!Appraiser.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Appraiser") && !CurrentForm.HasValue("x_Appraiser")) // DN
                    Appraiser.Visible = false; // Disable update for API request
                else
                    Appraiser.SetFormValue(val);
            }

            // Check field name 'DateInput' before field var 'x_DateInput'
            val = CurrentForm.HasValue("DateInput") ? CurrentForm.GetValue("DateInput") : CurrentForm.GetValue("x_DateInput");
            if (!DateInput.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DateInput") && !CurrentForm.HasValue("x_DateInput")) // DN
                    DateInput.Visible = false; // Disable update for API request
                else
                    DateInput.SetFormValue(val, true, validate);
                DateInput.CurrentValue = UnformatDateTime(DateInput.CurrentValue, DateInput.FormatPattern);
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
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            VesselName.CurrentValue = VesselName.FormValue;
            MTRankID.CurrentValue = MTRankID.FormValue;
            Questionnaire.CurrentValue = Questionnaire.FormValue;
            Approved.CurrentValue = Approved.FormValue;
            AverageRating.CurrentValue = AverageRating.FormValue;
            Rehire.CurrentValue = Rehire.FormValue;
            Promote.CurrentValue = Promote.FormValue;
            Appraiser.CurrentValue = Appraiser.FormValue;
            DateInput.CurrentValue = DateInput.FormValue;
            DateInput.CurrentValue = UnformatDateTime(DateInput.CurrentValue, DateInput.FormatPattern);
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
            VesselName.SetDbValue(row["VesselName"]);
            MTRankID.SetDbValue(row["MTRankID"]);
            Questionnaire.SetDbValue(row["Questionnaire"]);
            Approved.SetDbValue((ConvertToBool(row["Approved"]) ? "1" : "0"));
            AverageRating.SetDbValue(IsNull(row["AverageRating"]) ? DbNullValue : ConvertToDouble(row["AverageRating"]));
            Rehire.SetDbValue((ConvertToBool(row["Rehire"]) ? "1" : "0"));
            Promote.SetDbValue((ConvertToBool(row["Promote"]) ? "1" : "0"));
            Appraiser.SetDbValue(row["Appraiser"]);
            DateInput.SetDbValue(row["DateInput"]);
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
            row.Add("VesselName", VesselName.DefaultValue ?? DbNullValue); // DN
            row.Add("MTRankID", MTRankID.DefaultValue ?? DbNullValue); // DN
            row.Add("Questionnaire", Questionnaire.DefaultValue ?? DbNullValue); // DN
            row.Add("Approved", Approved.DefaultValue ?? DbNullValue); // DN
            row.Add("AverageRating", AverageRating.DefaultValue ?? DbNullValue); // DN
            row.Add("Rehire", Rehire.DefaultValue ?? DbNullValue); // DN
            row.Add("Promote", Promote.DefaultValue ?? DbNullValue); // DN
            row.Add("Appraiser", Appraiser.DefaultValue ?? DbNullValue); // DN
            row.Add("DateInput", DateInput.DefaultValue ?? DbNullValue); // DN
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

            // VesselName
            VesselName.RowCssClass = "row";

            // MTRankID
            MTRankID.RowCssClass = "row";

            // Questionnaire
            Questionnaire.RowCssClass = "row";

            // Approved
            Approved.RowCssClass = "row";

            // AverageRating
            AverageRating.RowCssClass = "row";

            // Rehire
            Rehire.RowCssClass = "row";

            // Promote
            Promote.RowCssClass = "row";

            // Appraiser
            Appraiser.RowCssClass = "row";

            // DateInput
            DateInput.RowCssClass = "row";

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
                // VesselName
                VesselName.ViewValue = ConvertToString(VesselName.CurrentValue); // DN
                VesselName.ViewCustomAttributes = "";

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

                // Questionnaire
                Questionnaire.ViewValue = ConvertToString(Questionnaire.CurrentValue); // DN
                Questionnaire.ViewCustomAttributes = "";

                // Approved
                if (ConvertToBool(Approved.CurrentValue)) {
                    Approved.ViewValue = Approved.TagCaption(1) != "" ? Approved.TagCaption(1) : "Yes";
                } else {
                    Approved.ViewValue = Approved.TagCaption(2) != "" ? Approved.TagCaption(2) : "No";
                }
                Approved.ViewCustomAttributes = "";

                // AverageRating
                AverageRating.ViewValue = AverageRating.CurrentValue;
                AverageRating.ViewValue = FormatNumber(AverageRating.ViewValue, AverageRating.FormatPattern);
                AverageRating.ViewCustomAttributes = "";

                // Rehire
                if (ConvertToBool(Rehire.CurrentValue)) {
                    Rehire.ViewValue = Rehire.TagCaption(1) != "" ? Rehire.TagCaption(1) : "";
                } else {
                    Rehire.ViewValue = Rehire.TagCaption(2) != "" ? Rehire.TagCaption(2) : "";
                }
                Rehire.ViewCustomAttributes = "";

                // Promote
                if (ConvertToBool(Promote.CurrentValue)) {
                    Promote.ViewValue = Promote.TagCaption(1) != "" ? Promote.TagCaption(1) : "";
                } else {
                    Promote.ViewValue = Promote.TagCaption(2) != "" ? Promote.TagCaption(2) : "";
                }
                Promote.ViewCustomAttributes = "";

                // Appraiser
                Appraiser.ViewValue = ConvertToString(Appraiser.CurrentValue); // DN
                Appraiser.ViewCustomAttributes = "";

                // DateInput
                DateInput.ViewValue = DateInput.CurrentValue;
                DateInput.ViewValue = FormatDateTime(DateInput.ViewValue, DateInput.FormatPattern);
                DateInput.ViewCustomAttributes = "";

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

                // VesselName
                VesselName.HrefValue = "";

                // MTRankID
                MTRankID.HrefValue = "";

                // Questionnaire
                Questionnaire.HrefValue = "";

                // Approved
                Approved.HrefValue = "";

                // AverageRating
                AverageRating.HrefValue = "";

                // Rehire
                Rehire.HrefValue = "";

                // Promote
                Promote.HrefValue = "";

                // Appraiser
                Appraiser.HrefValue = "";

                // DateInput
                DateInput.HrefValue = "";

                // MTCrewID
                MTCrewID.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // VesselName
                VesselName.SetupEditAttributes();
                if (!VesselName.Raw)
                    VesselName.CurrentValue = HtmlDecode(VesselName.CurrentValue);
                VesselName.EditValue = HtmlEncode(VesselName.CurrentValue);
                VesselName.PlaceHolder = RemoveHtml(VesselName.Caption);

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

                // Questionnaire
                Questionnaire.SetupEditAttributes();
                if (!Questionnaire.Raw)
                    Questionnaire.CurrentValue = HtmlDecode(Questionnaire.CurrentValue);
                Questionnaire.EditValue = HtmlEncode(Questionnaire.CurrentValue);
                Questionnaire.PlaceHolder = RemoveHtml(Questionnaire.Caption);

                // Approved
                Approved.EditValue = Approved.Options(false);
                Approved.PlaceHolder = RemoveHtml(Approved.Caption);

                // AverageRating
                AverageRating.SetupEditAttributes();
                AverageRating.EditValue = AverageRating.CurrentValue; // DN
                AverageRating.PlaceHolder = RemoveHtml(AverageRating.Caption);
                if (!Empty(AverageRating.EditValue) && IsNumeric(AverageRating.EditValue))
                    AverageRating.EditValue = FormatNumber(AverageRating.EditValue, null);

                // Rehire
                Rehire.EditValue = Rehire.Options(false);
                Rehire.PlaceHolder = RemoveHtml(Rehire.Caption);

                // Promote
                Promote.EditValue = Promote.Options(false);
                Promote.PlaceHolder = RemoveHtml(Promote.Caption);

                // Appraiser
                Appraiser.SetupEditAttributes();
                if (!Appraiser.Raw)
                    Appraiser.CurrentValue = HtmlDecode(Appraiser.CurrentValue);
                Appraiser.EditValue = HtmlEncode(Appraiser.CurrentValue);
                Appraiser.PlaceHolder = RemoveHtml(Appraiser.Caption);

                // DateInput
                DateInput.SetupEditAttributes();
                DateInput.EditValue = FormatDateTime(DateInput.CurrentValue, DateInput.FormatPattern); // DN
                DateInput.PlaceHolder = RemoveHtml(DateInput.Caption);

                // MTCrewID
                MTCrewID.SetupEditAttributes();
                MTCrewID.EditValue = MTCrewID.CurrentValue; // DN
                MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);
                if (!Empty(MTCrewID.EditValue) && IsNumeric(MTCrewID.EditValue))
                    MTCrewID.EditValue = FormatNumber(MTCrewID.EditValue, null);

                // Add refer script

                // VesselName
                VesselName.HrefValue = "";

                // MTRankID
                MTRankID.HrefValue = "";

                // Questionnaire
                Questionnaire.HrefValue = "";

                // Approved
                Approved.HrefValue = "";

                // AverageRating
                AverageRating.HrefValue = "";

                // Rehire
                Rehire.HrefValue = "";

                // Promote
                Promote.HrefValue = "";

                // Appraiser
                Appraiser.HrefValue = "";

                // DateInput
                DateInput.HrefValue = "";

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
            if (VesselName.Required) {
                if (!VesselName.IsDetailKey && Empty(VesselName.FormValue)) {
                    VesselName.AddErrorMessage(ConvertToString(VesselName.RequiredErrorMessage).Replace("%s", VesselName.Caption));
                }
            }
            if (MTRankID.Required) {
                if (!MTRankID.IsDetailKey && Empty(MTRankID.FormValue)) {
                    MTRankID.AddErrorMessage(ConvertToString(MTRankID.RequiredErrorMessage).Replace("%s", MTRankID.Caption));
                }
            }
            if (Questionnaire.Required) {
                if (!Questionnaire.IsDetailKey && Empty(Questionnaire.FormValue)) {
                    Questionnaire.AddErrorMessage(ConvertToString(Questionnaire.RequiredErrorMessage).Replace("%s", Questionnaire.Caption));
                }
            }
            if (Approved.Required) {
                if (Empty(Approved.FormValue)) {
                    Approved.AddErrorMessage(ConvertToString(Approved.RequiredErrorMessage).Replace("%s", Approved.Caption));
                }
            }
            if (AverageRating.Required) {
                if (!AverageRating.IsDetailKey && Empty(AverageRating.FormValue)) {
                    AverageRating.AddErrorMessage(ConvertToString(AverageRating.RequiredErrorMessage).Replace("%s", AverageRating.Caption));
                }
            }
            if (Rehire.Required) {
                if (Empty(Rehire.FormValue)) {
                    Rehire.AddErrorMessage(ConvertToString(Rehire.RequiredErrorMessage).Replace("%s", Rehire.Caption));
                }
            }
            if (Promote.Required) {
                if (Empty(Promote.FormValue)) {
                    Promote.AddErrorMessage(ConvertToString(Promote.RequiredErrorMessage).Replace("%s", Promote.Caption));
                }
            }
            if (Appraiser.Required) {
                if (!Appraiser.IsDetailKey && Empty(Appraiser.FormValue)) {
                    Appraiser.AddErrorMessage(ConvertToString(Appraiser.RequiredErrorMessage).Replace("%s", Appraiser.Caption));
                }
            }
            if (DateInput.Required) {
                if (!DateInput.IsDetailKey && Empty(DateInput.FormValue)) {
                    DateInput.AddErrorMessage(ConvertToString(DateInput.RequiredErrorMessage).Replace("%s", DateInput.Caption));
                }
            }
            if (!CheckDate(DateInput.FormValue, DateInput.FormatPattern)) {
                DateInput.AddErrorMessage(DateInput.GetErrorMessage(false));
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

        // Add record
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> AddRow(Dictionary<string, object>? rsold = null) { // DN
            bool result = false;

            // Set new row
            Dictionary<string, object> rsnew = new ();
            try {
                // VesselName
                VesselName.SetDbValue(rsnew, VesselName.CurrentValue);

                // MTRankID
                MTRankID.SetDbValue(rsnew, MTRankID.CurrentValue);

                // Questionnaire
                Questionnaire.SetDbValue(rsnew, Questionnaire.CurrentValue);

                // Approved
                Approved.SetDbValue(rsnew, ConvertToBool(Approved.CurrentValue));

                // AverageRating
                AverageRating.SetDbValue(rsnew, AverageRating.CurrentValue);

                // Rehire
                Rehire.SetDbValue(rsnew, ConvertToBool(Rehire.CurrentValue));

                // Promote
                Promote.SetDbValue(rsnew, ConvertToBool(Promote.CurrentValue));

                // Appraiser
                Appraiser.SetDbValue(rsnew, Appraiser.CurrentValue);

                // DateInput
                DateInput.SetDbValue(rsnew, ConvertToDateTime(DateInput.CurrentValue, DateInput.FormatPattern));

                // MTCrewID
                MTCrewID.SetDbValue(rsnew, MTCrewID.CurrentValue);

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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("CrewAppraisalForAdminList")), "", TableVar, true);
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
