namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// vCrewAcceptedForAdminEdit
    /// </summary>
    public static VCrewAcceptedForAdminEdit vCrewAcceptedForAdminEdit
    {
        get => HttpData.Get<VCrewAcceptedForAdminEdit>("vCrewAcceptedForAdminEdit")!;
        set => HttpData["vCrewAcceptedForAdminEdit"] = value;
    }

    /// <summary>
    /// Page class for v_CrewAcceptedForAdmin
    /// </summary>
    public class VCrewAcceptedForAdminEdit : VCrewAcceptedForAdminEditBase
    {
        // Constructor
        public VCrewAcceptedForAdminEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public VCrewAcceptedForAdminEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class VCrewAcceptedForAdminEditBase : VCrewAcceptedForAdmin
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "v_CrewAcceptedForAdmin";

        // Page object name
        public string PageObjName = "vCrewAcceptedForAdminEdit";

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
        public VCrewAcceptedForAdminEditBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (vCrewAcceptedForAdmin)
            if (vCrewAcceptedForAdmin == null || vCrewAcceptedForAdmin is VCrewAcceptedForAdmin)
                vCrewAcceptedForAdmin = this;

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
        public string PageName => "VCrewAcceptedForAdminEdit";

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
            EmployeeStatus.SetVisibility();
            FullName.SetVisibility();
            RequiredPhoto.SetVisibility();
            VisaPhoto.SetVisibility();
            CityOfBirth.SetVisibility();
            DateOfBirth.SetVisibility();
            Gender.SetVisibility();
            RankAppliedFor_RankID.SetVisibility();
            WillAcceptLowRank.SetVisibility();
            AvailableFrom.SetVisibility();
            AvailableUntil.SetVisibility();
        }

        // Constructor
        public VCrewAcceptedForAdminEditBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "VCrewAcceptedForAdminView" ? "1" : "0"); // If View page, no primary button
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
            if (IsAdd || IsCopy || IsGridAdd)
                ID.Visible = false;
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
            await SetupLookupOptions(RankAppliedFor_RankID);
            await SetupLookupOptions(WillAcceptLowRank);

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
                            return Terminate("VCrewAcceptedForAdminList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "VCrewAcceptedForAdminList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) {
                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "VCrewAcceptedForAdminList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "VCrewAcceptedForAdminList"; // Return list page content
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
                vCrewAcceptedForAdminEdit?.PageRender();
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

            // Check field name 'IndividualCodeNumber' before field var 'x_IndividualCodeNumber'
            val = CurrentForm.HasValue("IndividualCodeNumber") ? CurrentForm.GetValue("IndividualCodeNumber") : CurrentForm.GetValue("x_IndividualCodeNumber");
            if (!IndividualCodeNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IndividualCodeNumber") && !CurrentForm.HasValue("x_IndividualCodeNumber")) // DN
                    IndividualCodeNumber.Visible = false; // Disable update for API request
                else
                    IndividualCodeNumber.SetFormValue(val);
            }

            // Check field name 'EmployeeStatus' before field var 'x_EmployeeStatus'
            val = CurrentForm.HasValue("EmployeeStatus") ? CurrentForm.GetValue("EmployeeStatus") : CurrentForm.GetValue("x_EmployeeStatus");
            if (!EmployeeStatus.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("EmployeeStatus") && !CurrentForm.HasValue("x_EmployeeStatus")) // DN
                    EmployeeStatus.Visible = false; // Disable update for API request
                else
                    EmployeeStatus.SetFormValue(val);
            }

            // Check field name 'FullName' before field var 'x_FullName'
            val = CurrentForm.HasValue("FullName") ? CurrentForm.GetValue("FullName") : CurrentForm.GetValue("x_FullName");
            if (!FullName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FullName") && !CurrentForm.HasValue("x_FullName")) // DN
                    FullName.Visible = false; // Disable update for API request
                else
                    FullName.SetFormValue(val);
            }

            // Check field name 'RequiredPhoto' before field var 'x_RequiredPhoto'
            val = CurrentForm.HasValue("RequiredPhoto") ? CurrentForm.GetValue("RequiredPhoto") : CurrentForm.GetValue("x_RequiredPhoto");
            if (!RequiredPhoto.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RequiredPhoto") && !CurrentForm.HasValue("x_RequiredPhoto")) // DN
                    RequiredPhoto.Visible = false; // Disable update for API request
                else
                    RequiredPhoto.SetFormValue(val);
            }

            // Check field name 'VisaPhoto' before field var 'x_VisaPhoto'
            val = CurrentForm.HasValue("VisaPhoto") ? CurrentForm.GetValue("VisaPhoto") : CurrentForm.GetValue("x_VisaPhoto");
            if (!VisaPhoto.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("VisaPhoto") && !CurrentForm.HasValue("x_VisaPhoto")) // DN
                    VisaPhoto.Visible = false; // Disable update for API request
                else
                    VisaPhoto.SetFormValue(val);
            }

            // Check field name 'CityOfBirth' before field var 'x_CityOfBirth'
            val = CurrentForm.HasValue("CityOfBirth") ? CurrentForm.GetValue("CityOfBirth") : CurrentForm.GetValue("x_CityOfBirth");
            if (!CityOfBirth.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CityOfBirth") && !CurrentForm.HasValue("x_CityOfBirth")) // DN
                    CityOfBirth.Visible = false; // Disable update for API request
                else
                    CityOfBirth.SetFormValue(val);
            }

            // Check field name 'DateOfBirth' before field var 'x_DateOfBirth'
            val = CurrentForm.HasValue("DateOfBirth") ? CurrentForm.GetValue("DateOfBirth") : CurrentForm.GetValue("x_DateOfBirth");
            if (!DateOfBirth.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DateOfBirth") && !CurrentForm.HasValue("x_DateOfBirth")) // DN
                    DateOfBirth.Visible = false; // Disable update for API request
                else
                    DateOfBirth.SetFormValue(val, true, validate);
                DateOfBirth.CurrentValue = UnformatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern);
            }

            // Check field name 'Gender' before field var 'x_Gender'
            val = CurrentForm.HasValue("Gender") ? CurrentForm.GetValue("Gender") : CurrentForm.GetValue("x_Gender");
            if (!Gender.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Gender") && !CurrentForm.HasValue("x_Gender")) // DN
                    Gender.Visible = false; // Disable update for API request
                else
                    Gender.SetFormValue(val);
            }

            // Check field name 'RankAppliedFor_RankID' before field var 'x_RankAppliedFor_RankID'
            val = CurrentForm.HasValue("RankAppliedFor_RankID") ? CurrentForm.GetValue("RankAppliedFor_RankID") : CurrentForm.GetValue("x_RankAppliedFor_RankID");
            if (!RankAppliedFor_RankID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RankAppliedFor_RankID") && !CurrentForm.HasValue("x_RankAppliedFor_RankID")) // DN
                    RankAppliedFor_RankID.Visible = false; // Disable update for API request
                else
                    RankAppliedFor_RankID.SetFormValue(val, true, validate);
            }

            // Check field name 'WillAcceptLowRank' before field var 'x_WillAcceptLowRank'
            val = CurrentForm.HasValue("WillAcceptLowRank") ? CurrentForm.GetValue("WillAcceptLowRank") : CurrentForm.GetValue("x_WillAcceptLowRank");
            if (!WillAcceptLowRank.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("WillAcceptLowRank") && !CurrentForm.HasValue("x_WillAcceptLowRank")) // DN
                    WillAcceptLowRank.Visible = false; // Disable update for API request
                else
                    WillAcceptLowRank.SetFormValue(val);
            }

            // Check field name 'AvailableFrom' before field var 'x_AvailableFrom'
            val = CurrentForm.HasValue("AvailableFrom") ? CurrentForm.GetValue("AvailableFrom") : CurrentForm.GetValue("x_AvailableFrom");
            if (!AvailableFrom.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AvailableFrom") && !CurrentForm.HasValue("x_AvailableFrom")) // DN
                    AvailableFrom.Visible = false; // Disable update for API request
                else
                    AvailableFrom.SetFormValue(val, true, validate);
                AvailableFrom.CurrentValue = UnformatDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern);
            }

            // Check field name 'AvailableUntil' before field var 'x_AvailableUntil'
            val = CurrentForm.HasValue("AvailableUntil") ? CurrentForm.GetValue("AvailableUntil") : CurrentForm.GetValue("x_AvailableUntil");
            if (!AvailableUntil.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AvailableUntil") && !CurrentForm.HasValue("x_AvailableUntil")) // DN
                    AvailableUntil.Visible = false; // Disable update for API request
                else
                    AvailableUntil.SetFormValue(val, true, validate);
                AvailableUntil.CurrentValue = UnformatDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern);
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
            IndividualCodeNumber.CurrentValue = IndividualCodeNumber.FormValue;
            EmployeeStatus.CurrentValue = EmployeeStatus.FormValue;
            FullName.CurrentValue = FullName.FormValue;
            RequiredPhoto.CurrentValue = RequiredPhoto.FormValue;
            VisaPhoto.CurrentValue = VisaPhoto.FormValue;
            CityOfBirth.CurrentValue = CityOfBirth.FormValue;
            DateOfBirth.CurrentValue = DateOfBirth.FormValue;
            DateOfBirth.CurrentValue = UnformatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern);
            Gender.CurrentValue = Gender.FormValue;
            RankAppliedFor_RankID.CurrentValue = RankAppliedFor_RankID.FormValue;
            WillAcceptLowRank.CurrentValue = WillAcceptLowRank.FormValue;
            AvailableFrom.CurrentValue = AvailableFrom.FormValue;
            AvailableFrom.CurrentValue = UnformatDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern);
            AvailableUntil.CurrentValue = AvailableUntil.FormValue;
            AvailableUntil.CurrentValue = UnformatDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern);
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
            EmployeeStatus.SetDbValue(row["EmployeeStatus"]);
            FullName.SetDbValue(row["FullName"]);
            RequiredPhoto.SetDbValue(row["RequiredPhoto"]);
            VisaPhoto.SetDbValue(row["VisaPhoto"]);
            CityOfBirth.SetDbValue(row["CityOfBirth"]);
            DateOfBirth.SetDbValue(row["DateOfBirth"]);
            Gender.SetDbValue(row["Gender"]);
            RankAppliedFor_RankID.SetDbValue(row["RankAppliedFor_RankID"]);
            WillAcceptLowRank.SetDbValue((ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"));
            AvailableFrom.SetDbValue(row["AvailableFrom"]);
            AvailableUntil.SetDbValue(row["AvailableUntil"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("IndividualCodeNumber", IndividualCodeNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("EmployeeStatus", EmployeeStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("RequiredPhoto", RequiredPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("VisaPhoto", VisaPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("CityOfBirth", CityOfBirth.DefaultValue ?? DbNullValue); // DN
            row.Add("DateOfBirth", DateOfBirth.DefaultValue ?? DbNullValue); // DN
            row.Add("Gender", Gender.DefaultValue ?? DbNullValue); // DN
            row.Add("RankAppliedFor_RankID", RankAppliedFor_RankID.DefaultValue ?? DbNullValue); // DN
            row.Add("WillAcceptLowRank", WillAcceptLowRank.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableFrom", AvailableFrom.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableUntil", AvailableUntil.DefaultValue ?? DbNullValue); // DN
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

            // IndividualCodeNumber
            IndividualCodeNumber.RowCssClass = "row";

            // EmployeeStatus
            EmployeeStatus.RowCssClass = "row";

            // FullName
            FullName.RowCssClass = "row";

            // RequiredPhoto
            RequiredPhoto.RowCssClass = "row";

            // VisaPhoto
            VisaPhoto.RowCssClass = "row";

            // CityOfBirth
            CityOfBirth.RowCssClass = "row";

            // DateOfBirth
            DateOfBirth.RowCssClass = "row";

            // Gender
            Gender.RowCssClass = "row";

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.RowCssClass = "row";

            // WillAcceptLowRank
            WillAcceptLowRank.RowCssClass = "row";

            // AvailableFrom
            AvailableFrom.RowCssClass = "row";

            // AvailableUntil
            AvailableUntil.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // IndividualCodeNumber
                IndividualCodeNumber.ViewValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
                IndividualCodeNumber.ViewCustomAttributes = "";

                // EmployeeStatus
                EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
                EmployeeStatus.ViewCustomAttributes = "";

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

                // CityOfBirth
                CityOfBirth.ViewValue = ConvertToString(CityOfBirth.CurrentValue); // DN
                CityOfBirth.ViewCustomAttributes = "";

                // DateOfBirth
                DateOfBirth.ViewValue = DateOfBirth.CurrentValue;
                DateOfBirth.ViewValue = FormatDateTime(DateOfBirth.ViewValue, DateOfBirth.FormatPattern);
                DateOfBirth.ViewCustomAttributes = "";

                // Gender
                Gender.ViewValue = ConvertToString(Gender.CurrentValue); // DN
                Gender.ViewCustomAttributes = "";

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.ViewValue = RankAppliedFor_RankID.CurrentValue;
                curVal = ConvertToString(RankAppliedFor_RankID.CurrentValue);
                if (!Empty(curVal)) {
                    if (RankAppliedFor_RankID.Lookup != null && IsDictionary(RankAppliedFor_RankID.Lookup?.Options) && RankAppliedFor_RankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        RankAppliedFor_RankID.ViewValue = RankAppliedFor_RankID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", RankAppliedFor_RankID.CurrentValue, DataType.Number, "");
                        sqlWrk = RankAppliedFor_RankID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && RankAppliedFor_RankID.Lookup != null) { // Lookup values found
                            var listwrk = RankAppliedFor_RankID.Lookup?.RenderViewRow(rswrk[0]);
                            RankAppliedFor_RankID.ViewValue = RankAppliedFor_RankID.HighlightLookup(ConvertToString(rswrk[0]), RankAppliedFor_RankID.DisplayValue(listwrk));
                        } else {
                            RankAppliedFor_RankID.ViewValue = FormatNumber(RankAppliedFor_RankID.CurrentValue, RankAppliedFor_RankID.FormatPattern);
                        }
                    }
                } else {
                    RankAppliedFor_RankID.ViewValue = DbNullValue;
                }
                RankAppliedFor_RankID.ViewCustomAttributes = "";

                // WillAcceptLowRank
                if (ConvertToBool(WillAcceptLowRank.CurrentValue)) {
                    WillAcceptLowRank.ViewValue = WillAcceptLowRank.TagCaption(1) != "" ? WillAcceptLowRank.TagCaption(1) : "Yes";
                } else {
                    WillAcceptLowRank.ViewValue = WillAcceptLowRank.TagCaption(2) != "" ? WillAcceptLowRank.TagCaption(2) : "No";
                }
                WillAcceptLowRank.ViewCustomAttributes = "";

                // AvailableFrom
                AvailableFrom.ViewValue = AvailableFrom.CurrentValue;
                AvailableFrom.ViewValue = FormatDateTime(AvailableFrom.ViewValue, AvailableFrom.FormatPattern);
                AvailableFrom.ViewCustomAttributes = "";

                // AvailableUntil
                AvailableUntil.ViewValue = AvailableUntil.CurrentValue;
                AvailableUntil.ViewValue = FormatDateTime(AvailableUntil.ViewValue, AvailableUntil.FormatPattern);
                AvailableUntil.ViewCustomAttributes = "";

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";

                // EmployeeStatus
                EmployeeStatus.HrefValue = "";

                // FullName
                FullName.HrefValue = "";

                // RequiredPhoto
                RequiredPhoto.HrefValue = "";

                // VisaPhoto
                VisaPhoto.HrefValue = "";

                // CityOfBirth
                CityOfBirth.HrefValue = "";

                // DateOfBirth
                DateOfBirth.HrefValue = "";

                // Gender
                Gender.HrefValue = "";

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.HrefValue = "";

                // WillAcceptLowRank
                WillAcceptLowRank.HrefValue = "";

                // AvailableFrom
                AvailableFrom.HrefValue = "";

                // AvailableUntil
                AvailableUntil.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // IndividualCodeNumber
                IndividualCodeNumber.SetupEditAttributes();
                if (!IndividualCodeNumber.Raw)
                    IndividualCodeNumber.CurrentValue = HtmlDecode(IndividualCodeNumber.CurrentValue);
                IndividualCodeNumber.EditValue = HtmlEncode(IndividualCodeNumber.CurrentValue);
                IndividualCodeNumber.PlaceHolder = RemoveHtml(IndividualCodeNumber.Caption);

                // EmployeeStatus
                EmployeeStatus.SetupEditAttributes();
                if (!EmployeeStatus.Raw)
                    EmployeeStatus.CurrentValue = HtmlDecode(EmployeeStatus.CurrentValue);
                EmployeeStatus.EditValue = HtmlEncode(EmployeeStatus.CurrentValue);
                EmployeeStatus.PlaceHolder = RemoveHtml(EmployeeStatus.Caption);

                // FullName
                FullName.SetupEditAttributes();
                if (!FullName.Raw)
                    FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
                FullName.EditValue = HtmlEncode(FullName.CurrentValue);
                FullName.PlaceHolder = RemoveHtml(FullName.Caption);

                // RequiredPhoto
                RequiredPhoto.SetupEditAttributes();
                if (!RequiredPhoto.Raw)
                    RequiredPhoto.CurrentValue = HtmlDecode(RequiredPhoto.CurrentValue);
                RequiredPhoto.EditValue = HtmlEncode(RequiredPhoto.CurrentValue);
                RequiredPhoto.PlaceHolder = RemoveHtml(RequiredPhoto.Caption);

                // VisaPhoto
                VisaPhoto.SetupEditAttributes();
                if (!VisaPhoto.Raw)
                    VisaPhoto.CurrentValue = HtmlDecode(VisaPhoto.CurrentValue);
                VisaPhoto.EditValue = HtmlEncode(VisaPhoto.CurrentValue);
                VisaPhoto.PlaceHolder = RemoveHtml(VisaPhoto.Caption);

                // CityOfBirth
                CityOfBirth.SetupEditAttributes();
                if (!CityOfBirth.Raw)
                    CityOfBirth.CurrentValue = HtmlDecode(CityOfBirth.CurrentValue);
                CityOfBirth.EditValue = HtmlEncode(CityOfBirth.CurrentValue);
                CityOfBirth.PlaceHolder = RemoveHtml(CityOfBirth.Caption);

                // DateOfBirth
                DateOfBirth.SetupEditAttributes();
                DateOfBirth.EditValue = FormatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern); // DN
                DateOfBirth.PlaceHolder = RemoveHtml(DateOfBirth.Caption);

                // Gender
                Gender.SetupEditAttributes();
                if (!Gender.Raw)
                    Gender.CurrentValue = HtmlDecode(Gender.CurrentValue);
                Gender.EditValue = HtmlEncode(Gender.CurrentValue);
                Gender.PlaceHolder = RemoveHtml(Gender.Caption);

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.SetupEditAttributes();
                RankAppliedFor_RankID.EditValue = RankAppliedFor_RankID.CurrentValue; // DN
                curVal = ConvertToString(RankAppliedFor_RankID.CurrentValue);
                if (!Empty(curVal)) {
                    if (RankAppliedFor_RankID.Lookup != null && IsDictionary(RankAppliedFor_RankID.Lookup?.Options) && RankAppliedFor_RankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        RankAppliedFor_RankID.EditValue = RankAppliedFor_RankID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", RankAppliedFor_RankID.CurrentValue, DataType.Number, "");
                        sqlWrk = RankAppliedFor_RankID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && RankAppliedFor_RankID.Lookup != null) { // Lookup values found
                            var listwrk = RankAppliedFor_RankID.Lookup?.RenderViewRow(rswrk[0]);
                            RankAppliedFor_RankID.EditValue = RankAppliedFor_RankID.HighlightLookup(ConvertToString(rswrk[0]), RankAppliedFor_RankID.DisplayValue(listwrk));
                        } else {
                            RankAppliedFor_RankID.EditValue = HtmlEncode(FormatNumber(RankAppliedFor_RankID.CurrentValue, RankAppliedFor_RankID.FormatPattern));
                        }
                    }
                } else {
                    RankAppliedFor_RankID.EditValue = DbNullValue;
                }
                RankAppliedFor_RankID.PlaceHolder = RemoveHtml(RankAppliedFor_RankID.Caption);
                if (!Empty(RankAppliedFor_RankID.EditValue) && IsNumeric(RankAppliedFor_RankID.EditValue))
                    RankAppliedFor_RankID.EditValue = FormatNumber(RankAppliedFor_RankID.EditValue, null);

                // WillAcceptLowRank
                WillAcceptLowRank.EditValue = WillAcceptLowRank.Options(false);
                WillAcceptLowRank.PlaceHolder = RemoveHtml(WillAcceptLowRank.Caption);

                // AvailableFrom
                AvailableFrom.SetupEditAttributes();
                AvailableFrom.EditValue = FormatDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern); // DN
                AvailableFrom.PlaceHolder = RemoveHtml(AvailableFrom.Caption);

                // AvailableUntil
                AvailableUntil.SetupEditAttributes();
                AvailableUntil.EditValue = FormatDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern); // DN
                AvailableUntil.PlaceHolder = RemoveHtml(AvailableUntil.Caption);

                // Edit refer script

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";

                // EmployeeStatus
                EmployeeStatus.HrefValue = "";

                // FullName
                FullName.HrefValue = "";

                // RequiredPhoto
                RequiredPhoto.HrefValue = "";

                // VisaPhoto
                VisaPhoto.HrefValue = "";

                // CityOfBirth
                CityOfBirth.HrefValue = "";

                // DateOfBirth
                DateOfBirth.HrefValue = "";

                // Gender
                Gender.HrefValue = "";

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.HrefValue = "";

                // WillAcceptLowRank
                WillAcceptLowRank.HrefValue = "";

                // AvailableFrom
                AvailableFrom.HrefValue = "";

                // AvailableUntil
                AvailableUntil.HrefValue = "";
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
            if (IndividualCodeNumber.Required) {
                if (!IndividualCodeNumber.IsDetailKey && Empty(IndividualCodeNumber.FormValue)) {
                    IndividualCodeNumber.AddErrorMessage(ConvertToString(IndividualCodeNumber.RequiredErrorMessage).Replace("%s", IndividualCodeNumber.Caption));
                }
            }
            if (EmployeeStatus.Required) {
                if (!EmployeeStatus.IsDetailKey && Empty(EmployeeStatus.FormValue)) {
                    EmployeeStatus.AddErrorMessage(ConvertToString(EmployeeStatus.RequiredErrorMessage).Replace("%s", EmployeeStatus.Caption));
                }
            }
            if (FullName.Required) {
                if (!FullName.IsDetailKey && Empty(FullName.FormValue)) {
                    FullName.AddErrorMessage(ConvertToString(FullName.RequiredErrorMessage).Replace("%s", FullName.Caption));
                }
            }
            if (RequiredPhoto.Required) {
                if (!RequiredPhoto.IsDetailKey && Empty(RequiredPhoto.FormValue)) {
                    RequiredPhoto.AddErrorMessage(ConvertToString(RequiredPhoto.RequiredErrorMessage).Replace("%s", RequiredPhoto.Caption));
                }
            }
            if (VisaPhoto.Required) {
                if (!VisaPhoto.IsDetailKey && Empty(VisaPhoto.FormValue)) {
                    VisaPhoto.AddErrorMessage(ConvertToString(VisaPhoto.RequiredErrorMessage).Replace("%s", VisaPhoto.Caption));
                }
            }
            if (CityOfBirth.Required) {
                if (!CityOfBirth.IsDetailKey && Empty(CityOfBirth.FormValue)) {
                    CityOfBirth.AddErrorMessage(ConvertToString(CityOfBirth.RequiredErrorMessage).Replace("%s", CityOfBirth.Caption));
                }
            }
            if (DateOfBirth.Required) {
                if (!DateOfBirth.IsDetailKey && Empty(DateOfBirth.FormValue)) {
                    DateOfBirth.AddErrorMessage(ConvertToString(DateOfBirth.RequiredErrorMessage).Replace("%s", DateOfBirth.Caption));
                }
            }
            if (!CheckDate(DateOfBirth.FormValue, DateOfBirth.FormatPattern)) {
                DateOfBirth.AddErrorMessage(DateOfBirth.GetErrorMessage(false));
            }
            if (Gender.Required) {
                if (!Gender.IsDetailKey && Empty(Gender.FormValue)) {
                    Gender.AddErrorMessage(ConvertToString(Gender.RequiredErrorMessage).Replace("%s", Gender.Caption));
                }
            }
            if (RankAppliedFor_RankID.Required) {
                if (!RankAppliedFor_RankID.IsDetailKey && Empty(RankAppliedFor_RankID.FormValue)) {
                    RankAppliedFor_RankID.AddErrorMessage(ConvertToString(RankAppliedFor_RankID.RequiredErrorMessage).Replace("%s", RankAppliedFor_RankID.Caption));
                }
            }
            if (!CheckInteger(RankAppliedFor_RankID.FormValue)) {
                RankAppliedFor_RankID.AddErrorMessage(RankAppliedFor_RankID.GetErrorMessage(false));
            }
            if (WillAcceptLowRank.Required) {
                if (Empty(WillAcceptLowRank.FormValue)) {
                    WillAcceptLowRank.AddErrorMessage(ConvertToString(WillAcceptLowRank.RequiredErrorMessage).Replace("%s", WillAcceptLowRank.Caption));
                }
            }
            if (AvailableFrom.Required) {
                if (!AvailableFrom.IsDetailKey && Empty(AvailableFrom.FormValue)) {
                    AvailableFrom.AddErrorMessage(ConvertToString(AvailableFrom.RequiredErrorMessage).Replace("%s", AvailableFrom.Caption));
                }
            }
            if (!CheckDate(AvailableFrom.FormValue, AvailableFrom.FormatPattern)) {
                AvailableFrom.AddErrorMessage(AvailableFrom.GetErrorMessage(false));
            }
            if (AvailableUntil.Required) {
                if (!AvailableUntil.IsDetailKey && Empty(AvailableUntil.FormValue)) {
                    AvailableUntil.AddErrorMessage(ConvertToString(AvailableUntil.RequiredErrorMessage).Replace("%s", AvailableUntil.Caption));
                }
            }
            if (!CheckDate(AvailableUntil.FormValue, AvailableUntil.FormatPattern)) {
                AvailableUntil.AddErrorMessage(AvailableUntil.GetErrorMessage(false));
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

            // IndividualCodeNumber
            IndividualCodeNumber.SetDbValue(rsnew, IndividualCodeNumber.CurrentValue, IndividualCodeNumber.ReadOnly);

            // EmployeeStatus
            EmployeeStatus.SetDbValue(rsnew, EmployeeStatus.CurrentValue, EmployeeStatus.ReadOnly);

            // FullName
            FullName.SetDbValue(rsnew, FullName.CurrentValue, FullName.ReadOnly);

            // RequiredPhoto
            RequiredPhoto.SetDbValue(rsnew, RequiredPhoto.CurrentValue, RequiredPhoto.ReadOnly);

            // VisaPhoto
            VisaPhoto.SetDbValue(rsnew, VisaPhoto.CurrentValue, VisaPhoto.ReadOnly);

            // CityOfBirth
            CityOfBirth.SetDbValue(rsnew, CityOfBirth.CurrentValue, CityOfBirth.ReadOnly);

            // DateOfBirth
            DateOfBirth.SetDbValue(rsnew, ConvertToDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern), DateOfBirth.ReadOnly);

            // Gender
            Gender.SetDbValue(rsnew, Gender.CurrentValue, Gender.ReadOnly);

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.SetDbValue(rsnew, RankAppliedFor_RankID.CurrentValue, RankAppliedFor_RankID.ReadOnly);

            // WillAcceptLowRank
            WillAcceptLowRank.SetDbValue(rsnew, ConvertToBool(WillAcceptLowRank.CurrentValue), WillAcceptLowRank.ReadOnly);

            // AvailableFrom
            AvailableFrom.SetDbValue(rsnew, ConvertToDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern), AvailableFrom.ReadOnly);

            // AvailableUntil
            AvailableUntil.SetDbValue(rsnew, ConvertToDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern), AvailableUntil.ReadOnly);

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

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("VCrewAcceptedForAdminList")), "", TableVar, true);
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
