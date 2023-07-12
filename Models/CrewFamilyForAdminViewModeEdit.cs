namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewFamilyForAdminViewModeEdit
    /// </summary>
    public static CrewFamilyForAdminViewModeEdit crewFamilyForAdminViewModeEdit
    {
        get => HttpData.Get<CrewFamilyForAdminViewModeEdit>("crewFamilyForAdminViewModeEdit")!;
        set => HttpData["crewFamilyForAdminViewModeEdit"] = value;
    }

    /// <summary>
    /// Page class for CrewFamilyForAdminViewMode
    /// </summary>
    public class CrewFamilyForAdminViewModeEdit : CrewFamilyForAdminViewModeEditBase
    {
        // Constructor
        public CrewFamilyForAdminViewModeEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewFamilyForAdminViewModeEdit() : base()
        {
        }

        // Page Redirecting event
        public override void PageRedirecting(ref string url) {
            //url = newurl;
            int lastUpdatedFamilyCrewID = Session.GetInt("lastUpdatedFamilyCrewID");
            Session.Remove("lastUpdatedFamilyCrewID");
            url = "CrewFamilyForAdminViewModeList?crewID=" + ConvertToString(lastUpdatedFamilyCrewID);
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewFamilyForAdminViewModeEditBase : CrewFamilyForAdminViewMode
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewFamilyForAdminViewMode";

        // Page object name
        public string PageObjName = "crewFamilyForAdminViewModeEdit";

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
        public CrewFamilyForAdminViewModeEditBase()
        {
            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (crewFamilyForAdminViewMode)
            if (crewFamilyForAdminViewMode == null || crewFamilyForAdminViewMode is CrewFamilyForAdminViewMode)
                crewFamilyForAdminViewMode = this;

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
        public string PageName => "CrewFamilyForAdminViewModeEdit";

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
            Relationship.SetVisibility();
            FullName.SetVisibility();
            Gender.SetVisibility();
            DateOfBirth.SetVisibility();
            MobileNumberCode_CountryID.SetVisibility();
            MobileNumber.SetVisibility();
            _Email.SetVisibility();
            SocialSecurityNumber.SetVisibility();
            FamilyRegisterNumber.SetVisibility();
            Address.SetVisibility();
            ActiveDescription.Visible = false;
            CreatedByUserID.Visible = false;
            CreatedDateTime.Visible = false;
            LastUpdatedByUserID.Visible = false;
            LastUpdatedDateTime.Visible = false;
            MTUserID.Visible = false;
        }

        // Constructor
        public CrewFamilyForAdminViewModeEditBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "CrewFamilyForAdminViewModeView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(Relationship);
            await SetupLookupOptions(Gender);
            await SetupLookupOptions(MobileNumberCode_CountryID);

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
                            return Terminate("CrewFamilyForAdminViewModeList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "CrewFamilyForAdminViewModeList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) {
                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "CrewFamilyForAdminViewModeList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "CrewFamilyForAdminViewModeList"; // Return list page content
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
                crewFamilyForAdminViewModeEdit?.PageRender();
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

            // Check field name 'MTCrewID' before field var 'x_MTCrewID'
            val = CurrentForm.HasValue("MTCrewID") ? CurrentForm.GetValue("MTCrewID") : CurrentForm.GetValue("x_MTCrewID");
            if (!MTCrewID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTCrewID") && !CurrentForm.HasValue("x_MTCrewID")) // DN
                    MTCrewID.Visible = false; // Disable update for API request
                else
                    MTCrewID.SetFormValue(val);
            }

            // Check field name 'Relationship' before field var 'x_Relationship'
            val = CurrentForm.HasValue("Relationship") ? CurrentForm.GetValue("Relationship") : CurrentForm.GetValue("x_Relationship");
            if (!Relationship.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Relationship") && !CurrentForm.HasValue("x_Relationship")) // DN
                    Relationship.Visible = false; // Disable update for API request
                else
                    Relationship.SetFormValue(val);
            }

            // Check field name 'FullName' before field var 'x_FullName'
            val = CurrentForm.HasValue("FullName") ? CurrentForm.GetValue("FullName") : CurrentForm.GetValue("x_FullName");
            if (!FullName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FullName") && !CurrentForm.HasValue("x_FullName")) // DN
                    FullName.Visible = false; // Disable update for API request
                else
                    FullName.SetFormValue(val);
            }

            // Check field name 'Gender' before field var 'x_Gender'
            val = CurrentForm.HasValue("Gender") ? CurrentForm.GetValue("Gender") : CurrentForm.GetValue("x_Gender");
            if (!Gender.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Gender") && !CurrentForm.HasValue("x_Gender")) // DN
                    Gender.Visible = false; // Disable update for API request
                else
                    Gender.SetFormValue(val);
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

            // Check field name 'MobileNumberCode_CountryID' before field var 'x_MobileNumberCode_CountryID'
            val = CurrentForm.HasValue("MobileNumberCode_CountryID") ? CurrentForm.GetValue("MobileNumberCode_CountryID") : CurrentForm.GetValue("x_MobileNumberCode_CountryID");
            if (!MobileNumberCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MobileNumberCode_CountryID") && !CurrentForm.HasValue("x_MobileNumberCode_CountryID")) // DN
                    MobileNumberCode_CountryID.Visible = false; // Disable update for API request
                else
                    MobileNumberCode_CountryID.SetFormValue(val);
            }

            // Check field name 'MobileNumber' before field var 'x_MobileNumber'
            val = CurrentForm.HasValue("MobileNumber") ? CurrentForm.GetValue("MobileNumber") : CurrentForm.GetValue("x_MobileNumber");
            if (!MobileNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MobileNumber") && !CurrentForm.HasValue("x_MobileNumber")) // DN
                    MobileNumber.Visible = false; // Disable update for API request
                else
                    MobileNumber.SetFormValue(val);
            }

            // Check field name 'Email' before field var 'x__Email'
            val = CurrentForm.HasValue("Email") ? CurrentForm.GetValue("Email") : CurrentForm.GetValue("x__Email");
            if (!_Email.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Email") && !CurrentForm.HasValue("x__Email")) // DN
                    _Email.Visible = false; // Disable update for API request
                else
                    _Email.SetFormValue(val);
            }

            // Check field name 'SocialSecurityNumber' before field var 'x_SocialSecurityNumber'
            val = CurrentForm.HasValue("SocialSecurityNumber") ? CurrentForm.GetValue("SocialSecurityNumber") : CurrentForm.GetValue("x_SocialSecurityNumber");
            if (!SocialSecurityNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SocialSecurityNumber") && !CurrentForm.HasValue("x_SocialSecurityNumber")) // DN
                    SocialSecurityNumber.Visible = false; // Disable update for API request
                else
                    SocialSecurityNumber.SetFormValue(val);
            }

            // Check field name 'FamilyRegisterNumber' before field var 'x_FamilyRegisterNumber'
            val = CurrentForm.HasValue("FamilyRegisterNumber") ? CurrentForm.GetValue("FamilyRegisterNumber") : CurrentForm.GetValue("x_FamilyRegisterNumber");
            if (!FamilyRegisterNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FamilyRegisterNumber") && !CurrentForm.HasValue("x_FamilyRegisterNumber")) // DN
                    FamilyRegisterNumber.Visible = false; // Disable update for API request
                else
                    FamilyRegisterNumber.SetFormValue(val);
            }

            // Check field name 'Address' before field var 'x_Address'
            val = CurrentForm.HasValue("Address") ? CurrentForm.GetValue("Address") : CurrentForm.GetValue("x_Address");
            if (!Address.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Address") && !CurrentForm.HasValue("x_Address")) // DN
                    Address.Visible = false; // Disable update for API request
                else
                    Address.SetFormValue(val);
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
            MTCrewID.CurrentValue = MTCrewID.FormValue;
            Relationship.CurrentValue = Relationship.FormValue;
            FullName.CurrentValue = FullName.FormValue;
            Gender.CurrentValue = Gender.FormValue;
            DateOfBirth.CurrentValue = DateOfBirth.FormValue;
            DateOfBirth.CurrentValue = UnformatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern);
            MobileNumberCode_CountryID.CurrentValue = MobileNumberCode_CountryID.FormValue;
            MobileNumber.CurrentValue = MobileNumber.FormValue;
            _Email.CurrentValue = _Email.FormValue;
            SocialSecurityNumber.CurrentValue = SocialSecurityNumber.FormValue;
            FamilyRegisterNumber.CurrentValue = FamilyRegisterNumber.FormValue;
            Address.CurrentValue = Address.FormValue;
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
            MTCrewID.SetDbValue(row["MTCrewID"]);
            Relationship.SetDbValue(row["Relationship"]);
            FullName.SetDbValue(row["FullName"]);
            Gender.SetDbValue(row["Gender"]);
            DateOfBirth.SetDbValue(row["DateOfBirth"]);
            MobileNumberCode_CountryID.SetDbValue(row["MobileNumberCode_CountryID"]);
            MobileNumber.SetDbValue(row["MobileNumber"]);
            _Email.SetDbValue(row["Email"]);
            SocialSecurityNumber.SetDbValue(row["SocialSecurityNumber"]);
            FamilyRegisterNumber.SetDbValue(row["FamilyRegisterNumber"]);
            Address.SetDbValue(row["Address"]);
            ActiveDescription.SetDbValue(row["ActiveDescription"]);
            CreatedByUserID.SetDbValue(row["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(row["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(row["MTUserID"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTCrewID", MTCrewID.DefaultValue ?? DbNullValue); // DN
            row.Add("Relationship", Relationship.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("Gender", Gender.DefaultValue ?? DbNullValue); // DN
            row.Add("DateOfBirth", DateOfBirth.DefaultValue ?? DbNullValue); // DN
            row.Add("MobileNumberCode_CountryID", MobileNumberCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("MobileNumber", MobileNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("SocialSecurityNumber", SocialSecurityNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("FamilyRegisterNumber", FamilyRegisterNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("Address", Address.DefaultValue ?? DbNullValue); // DN
            row.Add("ActiveDescription", ActiveDescription.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedByUserID", CreatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("MTUserID", MTUserID.DefaultValue ?? DbNullValue); // DN
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

            // Relationship
            Relationship.RowCssClass = "row";

            // FullName
            FullName.RowCssClass = "row";

            // Gender
            Gender.RowCssClass = "row";

            // DateOfBirth
            DateOfBirth.RowCssClass = "row";

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.RowCssClass = "row";

            // MobileNumber
            MobileNumber.RowCssClass = "row";

            // Email
            _Email.RowCssClass = "row";

            // SocialSecurityNumber
            SocialSecurityNumber.RowCssClass = "row";

            // FamilyRegisterNumber
            FamilyRegisterNumber.RowCssClass = "row";

            // Address
            Address.RowCssClass = "row";

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

            // View row
            if (RowType == RowType.View) {
                // MTCrewID
                MTCrewID.ViewValue = MTCrewID.CurrentValue;
                MTCrewID.ViewValue = FormatNumber(MTCrewID.ViewValue, MTCrewID.FormatPattern);
                MTCrewID.ViewCustomAttributes = "";

                // Relationship
                if (!Empty(Relationship.CurrentValue)) {
                    Relationship.ViewValue = Relationship.HighlightLookup(ConvertToString(Relationship.CurrentValue), Relationship.OptionCaption(ConvertToString(Relationship.CurrentValue)));
                } else {
                    Relationship.ViewValue = DbNullValue;
                }
                Relationship.ViewCustomAttributes = "";

                // FullName
                FullName.ViewValue = ConvertToString(FullName.CurrentValue); // DN
                FullName.ViewCustomAttributes = "";

                // Gender
                if (!Empty(Gender.CurrentValue)) {
                    Gender.ViewValue = Gender.HighlightLookup(ConvertToString(Gender.CurrentValue), Gender.OptionCaption(ConvertToString(Gender.CurrentValue)));
                } else {
                    Gender.ViewValue = DbNullValue;
                }
                Gender.ViewCustomAttributes = "";

                // DateOfBirth
                DateOfBirth.ViewValue = DateOfBirth.CurrentValue;
                DateOfBirth.ViewValue = FormatDateTime(DateOfBirth.ViewValue, DateOfBirth.FormatPattern);
                DateOfBirth.ViewCustomAttributes = "";

                // MobileNumberCode_CountryID
                curVal = ConvertToString(MobileNumberCode_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MobileNumberCode_CountryID.Lookup != null && IsDictionary(MobileNumberCode_CountryID.Lookup?.Options) && MobileNumberCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MobileNumberCode_CountryID.ViewValue = MobileNumberCode_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MobileNumberCode_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = MobileNumberCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MobileNumberCode_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = MobileNumberCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            MobileNumberCode_CountryID.ViewValue = MobileNumberCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), MobileNumberCode_CountryID.DisplayValue(listwrk));
                        } else {
                            MobileNumberCode_CountryID.ViewValue = FormatNumber(MobileNumberCode_CountryID.CurrentValue, MobileNumberCode_CountryID.FormatPattern);
                        }
                    }
                } else {
                    MobileNumberCode_CountryID.ViewValue = DbNullValue;
                }
                MobileNumberCode_CountryID.ViewCustomAttributes = "";

                // MobileNumber
                MobileNumber.ViewValue = ConvertToString(MobileNumber.CurrentValue); // DN
                MobileNumber.ViewCustomAttributes = "";

                // Email
                _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
                _Email.ViewCustomAttributes = "";

                // SocialSecurityNumber
                SocialSecurityNumber.ViewValue = ConvertToString(SocialSecurityNumber.CurrentValue); // DN
                SocialSecurityNumber.ViewCustomAttributes = "";

                // FamilyRegisterNumber
                FamilyRegisterNumber.ViewValue = ConvertToString(FamilyRegisterNumber.CurrentValue); // DN
                FamilyRegisterNumber.ViewCustomAttributes = "";

                // Address
                Address.ViewValue = Address.CurrentValue;
                Address.ViewCustomAttributes = "";

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

                // MTCrewID
                MTCrewID.HrefValue = "";

                // Relationship
                Relationship.HrefValue = "";

                // FullName
                FullName.HrefValue = "";

                // Gender
                Gender.HrefValue = "";

                // DateOfBirth
                DateOfBirth.HrefValue = "";

                // MobileNumberCode_CountryID
                MobileNumberCode_CountryID.HrefValue = "";

                // MobileNumber
                MobileNumber.HrefValue = "";

                // Email
                _Email.HrefValue = "";

                // SocialSecurityNumber
                SocialSecurityNumber.HrefValue = "";

                // FamilyRegisterNumber
                FamilyRegisterNumber.HrefValue = "";

                // Address
                Address.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // MTCrewID
                MTCrewID.SetupEditAttributes();
                MTCrewID.EditValue = MTCrewID.CurrentValue; // DN
                MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);
                if (!Empty(MTCrewID.EditValue) && IsNumeric(MTCrewID.EditValue))
                    MTCrewID.EditValue = FormatNumber(MTCrewID.EditValue, null);

                // Relationship
                Relationship.SetupEditAttributes();
                Relationship.EditValue = Relationship.Options(true);
                Relationship.PlaceHolder = RemoveHtml(Relationship.Caption);

                // FullName
                FullName.SetupEditAttributes();
                if (!FullName.Raw)
                    FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
                FullName.EditValue = HtmlEncode(FullName.CurrentValue);
                FullName.PlaceHolder = RemoveHtml(FullName.Caption);

                // Gender
                Gender.SetupEditAttributes();
                Gender.EditValue = Gender.Options(true);
                Gender.PlaceHolder = RemoveHtml(Gender.Caption);

                // DateOfBirth
                DateOfBirth.SetupEditAttributes();
                DateOfBirth.EditValue = FormatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern); // DN
                DateOfBirth.PlaceHolder = RemoveHtml(DateOfBirth.Caption);

                // MobileNumberCode_CountryID
                MobileNumberCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(MobileNumberCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (MobileNumberCode_CountryID.Lookup != null && IsDictionary(MobileNumberCode_CountryID.Lookup?.Options) && MobileNumberCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MobileNumberCode_CountryID.EditValue = MobileNumberCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MobileNumberCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = MobileNumberCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MobileNumberCode_CountryID.EditValue = rswrk;
                }
                MobileNumberCode_CountryID.PlaceHolder = RemoveHtml(MobileNumberCode_CountryID.Caption);
                if (!Empty(MobileNumberCode_CountryID.EditValue) && IsNumeric(MobileNumberCode_CountryID.EditValue))
                    MobileNumberCode_CountryID.EditValue = FormatNumber(MobileNumberCode_CountryID.EditValue, null);

                // MobileNumber
                MobileNumber.SetupEditAttributes();
                if (!MobileNumber.Raw)
                    MobileNumber.CurrentValue = HtmlDecode(MobileNumber.CurrentValue);
                MobileNumber.EditValue = HtmlEncode(MobileNumber.CurrentValue);
                MobileNumber.PlaceHolder = RemoveHtml(MobileNumber.Caption);

                // Email
                _Email.SetupEditAttributes();
                if (!_Email.Raw)
                    _Email.CurrentValue = HtmlDecode(_Email.CurrentValue);
                _Email.EditValue = HtmlEncode(_Email.CurrentValue);
                _Email.PlaceHolder = RemoveHtml(_Email.Caption);

                // SocialSecurityNumber
                SocialSecurityNumber.SetupEditAttributes();
                if (!SocialSecurityNumber.Raw)
                    SocialSecurityNumber.CurrentValue = HtmlDecode(SocialSecurityNumber.CurrentValue);
                SocialSecurityNumber.EditValue = HtmlEncode(SocialSecurityNumber.CurrentValue);
                SocialSecurityNumber.PlaceHolder = RemoveHtml(SocialSecurityNumber.Caption);

                // FamilyRegisterNumber
                FamilyRegisterNumber.SetupEditAttributes();
                if (!FamilyRegisterNumber.Raw)
                    FamilyRegisterNumber.CurrentValue = HtmlDecode(FamilyRegisterNumber.CurrentValue);
                FamilyRegisterNumber.EditValue = HtmlEncode(FamilyRegisterNumber.CurrentValue);
                FamilyRegisterNumber.PlaceHolder = RemoveHtml(FamilyRegisterNumber.Caption);

                // Address
                Address.SetupEditAttributes();
                Address.EditValue = Address.CurrentValue; // DN
                Address.PlaceHolder = RemoveHtml(Address.Caption);

                // Edit refer script

                // MTCrewID
                MTCrewID.HrefValue = "";

                // Relationship
                Relationship.HrefValue = "";

                // FullName
                FullName.HrefValue = "";

                // Gender
                Gender.HrefValue = "";

                // DateOfBirth
                DateOfBirth.HrefValue = "";

                // MobileNumberCode_CountryID
                MobileNumberCode_CountryID.HrefValue = "";

                // MobileNumber
                MobileNumber.HrefValue = "";

                // Email
                _Email.HrefValue = "";

                // SocialSecurityNumber
                SocialSecurityNumber.HrefValue = "";

                // FamilyRegisterNumber
                FamilyRegisterNumber.HrefValue = "";

                // Address
                Address.HrefValue = "";
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
            if (Relationship.Required) {
                if (!Relationship.IsDetailKey && Empty(Relationship.FormValue)) {
                    Relationship.AddErrorMessage(ConvertToString(Relationship.RequiredErrorMessage).Replace("%s", Relationship.Caption));
                }
            }
            if (FullName.Required) {
                if (!FullName.IsDetailKey && Empty(FullName.FormValue)) {
                    FullName.AddErrorMessage(ConvertToString(FullName.RequiredErrorMessage).Replace("%s", FullName.Caption));
                }
            }
            if (Gender.Required) {
                if (!Gender.IsDetailKey && Empty(Gender.FormValue)) {
                    Gender.AddErrorMessage(ConvertToString(Gender.RequiredErrorMessage).Replace("%s", Gender.Caption));
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
            if (MobileNumberCode_CountryID.Required) {
                if (!MobileNumberCode_CountryID.IsDetailKey && Empty(MobileNumberCode_CountryID.FormValue)) {
                    MobileNumberCode_CountryID.AddErrorMessage(ConvertToString(MobileNumberCode_CountryID.RequiredErrorMessage).Replace("%s", MobileNumberCode_CountryID.Caption));
                }
            }
            if (MobileNumber.Required) {
                if (!MobileNumber.IsDetailKey && Empty(MobileNumber.FormValue)) {
                    MobileNumber.AddErrorMessage(ConvertToString(MobileNumber.RequiredErrorMessage).Replace("%s", MobileNumber.Caption));
                }
            }
            if (_Email.Required) {
                if (!_Email.IsDetailKey && Empty(_Email.FormValue)) {
                    _Email.AddErrorMessage(ConvertToString(_Email.RequiredErrorMessage).Replace("%s", _Email.Caption));
                }
            }
            if (SocialSecurityNumber.Required) {
                if (!SocialSecurityNumber.IsDetailKey && Empty(SocialSecurityNumber.FormValue)) {
                    SocialSecurityNumber.AddErrorMessage(ConvertToString(SocialSecurityNumber.RequiredErrorMessage).Replace("%s", SocialSecurityNumber.Caption));
                }
            }
            if (FamilyRegisterNumber.Required) {
                if (!FamilyRegisterNumber.IsDetailKey && Empty(FamilyRegisterNumber.FormValue)) {
                    FamilyRegisterNumber.AddErrorMessage(ConvertToString(FamilyRegisterNumber.RequiredErrorMessage).Replace("%s", FamilyRegisterNumber.Caption));
                }
            }
            if (Address.Required) {
                if (!Address.IsDetailKey && Empty(Address.FormValue)) {
                    Address.AddErrorMessage(ConvertToString(Address.RequiredErrorMessage).Replace("%s", Address.Caption));
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

            // MTCrewID
            MTCrewID.SetDbValue(rsnew, MTCrewID.CurrentValue, MTCrewID.ReadOnly);

            // Relationship
            Relationship.SetDbValue(rsnew, Relationship.CurrentValue, Relationship.ReadOnly);

            // FullName
            FullName.SetDbValue(rsnew, FullName.CurrentValue, FullName.ReadOnly);

            // Gender
            Gender.SetDbValue(rsnew, Gender.CurrentValue, Gender.ReadOnly);

            // DateOfBirth
            DateOfBirth.SetDbValue(rsnew, ConvertToDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern), DateOfBirth.ReadOnly);

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.SetDbValue(rsnew, MobileNumberCode_CountryID.CurrentValue, MobileNumberCode_CountryID.ReadOnly);

            // MobileNumber
            MobileNumber.SetDbValue(rsnew, MobileNumber.CurrentValue, MobileNumber.ReadOnly);

            // Email
            _Email.SetDbValue(rsnew, _Email.CurrentValue, _Email.ReadOnly);

            // SocialSecurityNumber
            SocialSecurityNumber.SetDbValue(rsnew, SocialSecurityNumber.CurrentValue, SocialSecurityNumber.ReadOnly);

            // FamilyRegisterNumber
            FamilyRegisterNumber.SetDbValue(rsnew, FamilyRegisterNumber.CurrentValue, FamilyRegisterNumber.ReadOnly);

            // Address
            Address.SetDbValue(rsnew, Address.CurrentValue, Address.ReadOnly);

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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("CrewFamilyForAdminViewModeList")), "", TableVar, true);
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
