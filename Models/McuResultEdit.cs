namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mcuResultEdit
    /// </summary>
    public static McuResultEdit mcuResultEdit
    {
        get => HttpData.Get<McuResultEdit>("mcuResultEdit")!;
        set => HttpData["mcuResultEdit"] = value;
    }

    /// <summary>
    /// Page class for McuResult
    /// </summary>
    public class McuResultEdit : McuResultEditBase
    {
        // Constructor
        public McuResultEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public McuResultEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class McuResultEditBase : McuResult
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "McuResult";

        // Page object name
        public string PageObjName = "mcuResultEdit";

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
        public McuResultEditBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (mcuResult)
            if (mcuResult == null || mcuResult is McuResult)
                mcuResult = this;

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
        public string PageName => "McuResultEdit";

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
            IndividualCodeNumber.SetVisibility();
            FullName.SetVisibility();
            RequiredPhoto.SetVisibility();
            VisaPhoto.SetVisibility();
            Gender.Visible = false;
            RankAppliedFor.SetVisibility();
            WillAcceptLowRank.SetVisibility();
            AvailableFrom.SetVisibility();
            AvailableUntil.SetVisibility();
            EmployeeStatus.Visible = false;
            McuScheduleDate.SetVisibility();
            McuDate.SetVisibility();
            McuExpirationDate.SetVisibility();
            HealthStatus.SetVisibility();
            McuLocation.SetVisibility();
            McuAttachment.SetVisibility();
            McuRemark.SetVisibility();
            CreatedBy.Visible = false;
            CreatedDateTime.Visible = false;
            LastUpdatedBy.Visible = false;
            LastUpdatedDateTime.Visible = false;
            MTUserID.Visible = false;
        }

        // Constructor
        public McuResultEditBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "McuResultView" ? "1" : "0"); // If View page, no primary button
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
                RequiredPhoto.OldUploadPath = RequiredPhoto.GetUploadPath();
                RequiredPhoto.UploadPath = RequiredPhoto.OldUploadPath;
                VisaPhoto.OldUploadPath = VisaPhoto.GetUploadPath();
                VisaPhoto.UploadPath = VisaPhoto.OldUploadPath;
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
            if (IsAddOrEdit)
                IndividualCodeNumber.Visible = false;
            if (IsAddOrEdit)
                FullName.Visible = false;
            if (IsAddOrEdit)
                RequiredPhoto.Visible = false;
            if (IsAddOrEdit)
                VisaPhoto.Visible = false;
            if (IsAddOrEdit)
                Gender.Visible = false;
            if (IsAddOrEdit)
                RankAppliedFor.Visible = false;
            if (IsAddOrEdit)
                WillAcceptLowRank.Visible = false;
            if (IsAddOrEdit)
                AvailableFrom.Visible = false;
            if (IsAddOrEdit)
                AvailableUntil.Visible = false;
            if (IsAddOrEdit)
                EmployeeStatus.Visible = false;
            if (IsAddOrEdit)
                CreatedBy.Visible = false;
            if (IsAddOrEdit)
                LastUpdatedBy.Visible = false;
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
            await SetupLookupOptions(Gender);
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
                if (RouteValues.TryGetValue("McuResult_ID", out rv)) { // DN
                    McuResult_ID.FormValue = UrlDecode(rv); // DN
                    McuResult_ID.OldValue = McuResult_ID.FormValue;
                } else if (CurrentForm.HasValue("x_McuResult_ID")) {
                    McuResult_ID.FormValue = CurrentForm.GetValue("x_McuResult_ID");
                    McuResult_ID.OldValue = McuResult_ID.FormValue;
                } else if (!Empty(keyValues)) {
                    McuResult_ID.OldValue = ConvertToString(keyValues[0]);
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
                    if (RouteValues.TryGetValue("McuResult_ID", out rv)) { // DN
                        McuResult_ID.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("McuResult_ID", out sv)) {
                        McuResult_ID.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        McuResult_ID.CurrentValue = DbNullValue;
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
                McuResult_ID.FormValue = ConvertToString(keyValues[0]);
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
                            return Terminate("McuResultList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "McuResultList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) {
                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "McuResultList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "McuResultList"; // Return list page content
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
                mcuResultEdit?.PageRender();
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
            RequiredPhoto.Upload.Index = CurrentForm.Index;
            if (!await RequiredPhoto.Upload.UploadFile()) // DN
                End(RequiredPhoto.Upload.Message);
            RequiredPhoto.CurrentValue = RequiredPhoto.Upload.FileName;
            VisaPhoto.Upload.Index = CurrentForm.Index;
            if (!await VisaPhoto.Upload.UploadFile()) // DN
                End(VisaPhoto.Upload.Message);
            VisaPhoto.CurrentValue = VisaPhoto.Upload.FileName;
            McuAttachment.Upload.Index = CurrentForm.Index;
            if (!await McuAttachment.Upload.UploadFile()) // DN
                End(McuAttachment.Upload.Message);
            McuAttachment.CurrentValue = McuAttachment.Upload.FileName;
        }
        #pragma warning restore 1998

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

            // Check field name 'IndividualCodeNumber' before field var 'x_IndividualCodeNumber'
            val = CurrentForm.HasValue("IndividualCodeNumber") ? CurrentForm.GetValue("IndividualCodeNumber") : CurrentForm.GetValue("x_IndividualCodeNumber");
            if (!IndividualCodeNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IndividualCodeNumber") && !CurrentForm.HasValue("x_IndividualCodeNumber")) // DN
                    IndividualCodeNumber.Visible = false; // Disable update for API request
                else
                    IndividualCodeNumber.SetFormValue(val);
            }

            // Check field name 'FullName' before field var 'x_FullName'
            val = CurrentForm.HasValue("FullName") ? CurrentForm.GetValue("FullName") : CurrentForm.GetValue("x_FullName");
            if (!FullName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FullName") && !CurrentForm.HasValue("x_FullName")) // DN
                    FullName.Visible = false; // Disable update for API request
                else
                    FullName.SetFormValue(val);
            }

            // Check field name 'RankAppliedFor' before field var 'x_RankAppliedFor'
            val = CurrentForm.HasValue("RankAppliedFor") ? CurrentForm.GetValue("RankAppliedFor") : CurrentForm.GetValue("x_RankAppliedFor");
            if (!RankAppliedFor.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RankAppliedFor") && !CurrentForm.HasValue("x_RankAppliedFor")) // DN
                    RankAppliedFor.Visible = false; // Disable update for API request
                else
                    RankAppliedFor.SetFormValue(val);
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

            // Check field name 'McuScheduleDate' before field var 'x_McuScheduleDate'
            val = CurrentForm.HasValue("McuScheduleDate") ? CurrentForm.GetValue("McuScheduleDate") : CurrentForm.GetValue("x_McuScheduleDate");
            if (!McuScheduleDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("McuScheduleDate") && !CurrentForm.HasValue("x_McuScheduleDate")) // DN
                    McuScheduleDate.Visible = false; // Disable update for API request
                else
                    McuScheduleDate.SetFormValue(val, true, validate);
                McuScheduleDate.CurrentValue = UnformatDateTime(McuScheduleDate.CurrentValue, McuScheduleDate.FormatPattern);
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
            if (!McuResult_ID.IsDetailKey)
                McuResult_ID.SetFormValue(CurrentForm.GetValue("x_McuResult_ID"));
            RequiredPhoto.OldUploadPath = RequiredPhoto.GetUploadPath();
            RequiredPhoto.UploadPath = RequiredPhoto.OldUploadPath;
            VisaPhoto.OldUploadPath = VisaPhoto.GetUploadPath();
            VisaPhoto.UploadPath = VisaPhoto.OldUploadPath;
            await GetUploadFiles(); // Get upload files
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            McuResult_ID.CurrentValue = McuResult_ID.FormValue;
            MTCrew_ID.CurrentValue = MTCrew_ID.FormValue;
            IndividualCodeNumber.CurrentValue = IndividualCodeNumber.FormValue;
            FullName.CurrentValue = FullName.FormValue;
            RankAppliedFor.CurrentValue = RankAppliedFor.FormValue;
            WillAcceptLowRank.CurrentValue = WillAcceptLowRank.FormValue;
            AvailableFrom.CurrentValue = AvailableFrom.FormValue;
            AvailableFrom.CurrentValue = UnformatDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern);
            AvailableUntil.CurrentValue = AvailableUntil.FormValue;
            AvailableUntil.CurrentValue = UnformatDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern);
            McuScheduleDate.CurrentValue = McuScheduleDate.FormValue;
            McuScheduleDate.CurrentValue = UnformatDateTime(McuScheduleDate.CurrentValue, McuScheduleDate.FormatPattern);
            McuDate.CurrentValue = McuDate.FormValue;
            McuDate.CurrentValue = UnformatDateTime(McuDate.CurrentValue, McuDate.FormatPattern);
            McuExpirationDate.CurrentValue = McuExpirationDate.FormValue;
            McuExpirationDate.CurrentValue = UnformatDateTime(McuExpirationDate.CurrentValue, McuExpirationDate.FormatPattern);
            HealthStatus.CurrentValue = HealthStatus.FormValue;
            McuLocation.CurrentValue = McuLocation.FormValue;
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
            IndividualCodeNumber.SetDbValue(row["IndividualCodeNumber"]);
            FullName.SetDbValue(row["FullName"]);
            RequiredPhoto.Upload.DbValue = row["RequiredPhoto"];
            RequiredPhoto.SetDbValue(RequiredPhoto.Upload.DbValue);
            VisaPhoto.Upload.DbValue = row["VisaPhoto"];
            VisaPhoto.SetDbValue(VisaPhoto.Upload.DbValue);
            Gender.SetDbValue(row["Gender"]);
            RankAppliedFor.SetDbValue(row["RankAppliedFor"]);
            WillAcceptLowRank.SetDbValue((ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"));
            AvailableFrom.SetDbValue(row["AvailableFrom"]);
            AvailableUntil.SetDbValue(row["AvailableUntil"]);
            EmployeeStatus.SetDbValue(row["EmployeeStatus"]);
            McuScheduleDate.SetDbValue(row["McuScheduleDate"]);
            McuDate.SetDbValue(row["McuDate"]);
            McuExpirationDate.SetDbValue(row["McuExpirationDate"]);
            HealthStatus.SetDbValue(row["HealthStatus"]);
            McuLocation.SetDbValue(row["McuLocation"]);
            McuAttachment.Upload.DbValue = row["McuAttachment"];
            McuAttachment.SetDbValue(McuAttachment.Upload.DbValue);
            McuRemark.SetDbValue(row["McuRemark"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(row["MTUserID"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("McuResult_ID", McuResult_ID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTCrew_ID", MTCrew_ID.DefaultValue ?? DbNullValue); // DN
            row.Add("IndividualCodeNumber", IndividualCodeNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("RequiredPhoto", RequiredPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("VisaPhoto", VisaPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("Gender", Gender.DefaultValue ?? DbNullValue); // DN
            row.Add("RankAppliedFor", RankAppliedFor.DefaultValue ?? DbNullValue); // DN
            row.Add("WillAcceptLowRank", WillAcceptLowRank.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableFrom", AvailableFrom.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableUntil", AvailableUntil.DefaultValue ?? DbNullValue); // DN
            row.Add("EmployeeStatus", EmployeeStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("McuScheduleDate", McuScheduleDate.DefaultValue ?? DbNullValue); // DN
            row.Add("McuDate", McuDate.DefaultValue ?? DbNullValue); // DN
            row.Add("McuExpirationDate", McuExpirationDate.DefaultValue ?? DbNullValue); // DN
            row.Add("HealthStatus", HealthStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("McuLocation", McuLocation.DefaultValue ?? DbNullValue); // DN
            row.Add("McuAttachment", McuAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("McuRemark", McuRemark.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
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

            // McuResult_ID
            McuResult_ID.RowCssClass = "row";

            // MTCrew_ID
            MTCrew_ID.RowCssClass = "row";

            // IndividualCodeNumber
            IndividualCodeNumber.RowCssClass = "row";

            // FullName
            FullName.RowCssClass = "row";

            // RequiredPhoto
            RequiredPhoto.RowCssClass = "row";

            // VisaPhoto
            VisaPhoto.RowCssClass = "row";

            // Gender
            Gender.RowCssClass = "row";

            // RankAppliedFor
            RankAppliedFor.RowCssClass = "row";

            // WillAcceptLowRank
            WillAcceptLowRank.RowCssClass = "row";

            // AvailableFrom
            AvailableFrom.RowCssClass = "row";

            // AvailableUntil
            AvailableUntil.RowCssClass = "row";

            // EmployeeStatus
            EmployeeStatus.RowCssClass = "row";

            // McuScheduleDate
            McuScheduleDate.RowCssClass = "row";

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

            // McuRemark
            McuRemark.RowCssClass = "row";

            // CreatedBy
            CreatedBy.RowCssClass = "row";

            // CreatedDateTime
            CreatedDateTime.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // LastUpdatedDateTime
            LastUpdatedDateTime.RowCssClass = "row";

            // MTUserID
            MTUserID.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // MTCrew_ID
                MTCrew_ID.ViewValue = MTCrew_ID.CurrentValue;
                MTCrew_ID.ViewValue = FormatNumber(MTCrew_ID.ViewValue, MTCrew_ID.FormatPattern);
                MTCrew_ID.ViewCustomAttributes = "";

                // IndividualCodeNumber
                IndividualCodeNumber.ViewValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
                IndividualCodeNumber.ViewCustomAttributes = "";

                // FullName
                FullName.ViewValue = ConvertToString(FullName.CurrentValue); // DN
                FullName.ViewCustomAttributes = "";

                // RequiredPhoto
                RequiredPhoto.UploadPath = RequiredPhoto.GetUploadPath();
                if (!IsNull(RequiredPhoto.Upload.DbValue)) {
                    RequiredPhoto.ImageWidth = 120;
                    RequiredPhoto.ImageHeight = 0;
                    RequiredPhoto.ImageAlt = RequiredPhoto.Alt;
                    RequiredPhoto.ImageCssClass = "ew-image";
                    RequiredPhoto.ViewValue = RequiredPhoto.Upload.DbValue;
                } else {
                    RequiredPhoto.ViewValue = "";
                }
                RequiredPhoto.CellCssStyle += "text-align: center;";
                RequiredPhoto.ViewCustomAttributes = "";

                // VisaPhoto
                VisaPhoto.UploadPath = VisaPhoto.GetUploadPath();
                if (!IsNull(VisaPhoto.Upload.DbValue)) {
                    VisaPhoto.ImageWidth = 120;
                    VisaPhoto.ImageHeight = 0;
                    VisaPhoto.ImageAlt = VisaPhoto.Alt;
                    VisaPhoto.ImageCssClass = "ew-image";
                    VisaPhoto.ViewValue = VisaPhoto.Upload.DbValue;
                } else {
                    VisaPhoto.ViewValue = "";
                }
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
                WillAcceptLowRank.ViewCustomAttributes = "";

                // AvailableFrom
                AvailableFrom.ViewValue = AvailableFrom.CurrentValue;
                AvailableFrom.ViewValue = FormatDateTime(AvailableFrom.ViewValue, AvailableFrom.FormatPattern);
                AvailableFrom.ViewCustomAttributes = "";

                // AvailableUntil
                AvailableUntil.ViewValue = AvailableUntil.CurrentValue;
                AvailableUntil.ViewValue = FormatDateTime(AvailableUntil.ViewValue, AvailableUntil.FormatPattern);
                AvailableUntil.ViewCustomAttributes = "";

                // EmployeeStatus
                EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
                EmployeeStatus.ViewCustomAttributes = "";

                // McuScheduleDate
                McuScheduleDate.ViewValue = McuScheduleDate.CurrentValue;
                McuScheduleDate.ViewValue = FormatDateTime(McuScheduleDate.ViewValue, McuScheduleDate.FormatPattern);
                McuScheduleDate.ViewCustomAttributes = "";

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
                McuAttachment.CellCssStyle += "text-align: center;";
                McuAttachment.ViewCustomAttributes = "";

                // McuRemark
                McuRemark.ViewValue = ConvertToString(McuRemark.CurrentValue); // DN
                McuRemark.ViewCustomAttributes = "";

                // CreatedBy
                CreatedBy.ViewValue = ConvertToString(CreatedBy.CurrentValue); // DN
                CreatedBy.ViewCustomAttributes = "";

                // CreatedDateTime
                CreatedDateTime.ViewValue = CreatedDateTime.CurrentValue;
                CreatedDateTime.ViewValue = FormatDateTime(CreatedDateTime.ViewValue, CreatedDateTime.FormatPattern);
                CreatedDateTime.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.ViewValue = LastUpdatedDateTime.CurrentValue;
                LastUpdatedDateTime.ViewValue = FormatDateTime(LastUpdatedDateTime.ViewValue, LastUpdatedDateTime.FormatPattern);
                LastUpdatedDateTime.ViewCustomAttributes = "";

                // MTCrew_ID
                MTCrew_ID.HrefValue = "";

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";

                // FullName
                FullName.HrefValue = "";

                // RequiredPhoto
                RequiredPhoto.UploadPath = RequiredPhoto.GetUploadPath();
                if (!IsNull(RequiredPhoto.Upload.DbValue)) {
                    RequiredPhoto.HrefValue = ConvertToString(GetFileUploadUrl(RequiredPhoto, RequiredPhoto.HtmlDecode(ConvertToString(RequiredPhoto.Upload.DbValue)))); // Add prefix/suffix
                    RequiredPhoto.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        RequiredPhoto.HrefValue = FullUrl(ConvertToString(RequiredPhoto.HrefValue), "href");
                } else {
                    RequiredPhoto.HrefValue = "";
                }
                RequiredPhoto.ExportHrefValue = RequiredPhoto.UploadPath + RequiredPhoto.Upload.DbValue;

                // VisaPhoto
                VisaPhoto.UploadPath = VisaPhoto.GetUploadPath();
                if (!IsNull(VisaPhoto.Upload.DbValue)) {
                    VisaPhoto.HrefValue = ConvertToString(GetFileUploadUrl(VisaPhoto, VisaPhoto.HtmlDecode(ConvertToString(VisaPhoto.Upload.DbValue)))); // Add prefix/suffix
                    VisaPhoto.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        VisaPhoto.HrefValue = FullUrl(ConvertToString(VisaPhoto.HrefValue), "href");
                } else {
                    VisaPhoto.HrefValue = "";
                }
                VisaPhoto.ExportHrefValue = VisaPhoto.UploadPath + VisaPhoto.Upload.DbValue;

                // RankAppliedFor
                RankAppliedFor.HrefValue = "";

                // WillAcceptLowRank
                WillAcceptLowRank.HrefValue = "";

                // AvailableFrom
                AvailableFrom.HrefValue = "";

                // AvailableUntil
                AvailableUntil.HrefValue = "";

                // McuScheduleDate
                McuScheduleDate.HrefValue = "";

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

                // McuRemark
                McuRemark.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // MTCrew_ID
                MTCrew_ID.SetupEditAttributes();
                MTCrew_ID.EditValue = MTCrew_ID.CurrentValue; // DN
                MTCrew_ID.PlaceHolder = RemoveHtml(MTCrew_ID.Caption);
                if (!Empty(MTCrew_ID.EditValue) && IsNumeric(MTCrew_ID.EditValue))
                    MTCrew_ID.EditValue = FormatNumber(MTCrew_ID.EditValue, null);

                // IndividualCodeNumber
                IndividualCodeNumber.SetupEditAttributes();
                if (!IndividualCodeNumber.Raw)
                    IndividualCodeNumber.CurrentValue = HtmlDecode(IndividualCodeNumber.CurrentValue);
                IndividualCodeNumber.EditValue = HtmlEncode(IndividualCodeNumber.CurrentValue);
                IndividualCodeNumber.PlaceHolder = RemoveHtml(IndividualCodeNumber.Caption);

                // FullName
                FullName.SetupEditAttributes();
                if (!FullName.Raw)
                    FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
                FullName.EditValue = HtmlEncode(FullName.CurrentValue);
                FullName.PlaceHolder = RemoveHtml(FullName.Caption);

                // RequiredPhoto
                RequiredPhoto.SetupEditAttributes();
                RequiredPhoto.EditAttrs["accept"] = "jpeg,png,jpg";
                RequiredPhoto.UploadPath = RequiredPhoto.GetUploadPath();
                if (!IsNull(RequiredPhoto.Upload.DbValue)) {
                    RequiredPhoto.ImageWidth = 120;
                    RequiredPhoto.ImageHeight = 0;
                    RequiredPhoto.ImageAlt = RequiredPhoto.Alt;
                    RequiredPhoto.ImageCssClass = "ew-image";
                    RequiredPhoto.EditValue = RequiredPhoto.Upload.DbValue;
                } else {
                    RequiredPhoto.EditValue = "";
                }
                if (!Empty(RequiredPhoto.CurrentValue))
                        RequiredPhoto.Upload.FileName = ConvertToString(RequiredPhoto.CurrentValue);
                if (IsShow && !EventCancelled)
                    await RenderUploadField(RequiredPhoto);

                // VisaPhoto
                VisaPhoto.SetupEditAttributes();
                VisaPhoto.EditAttrs["accept"] = "jpeg,png,jpg";
                VisaPhoto.UploadPath = VisaPhoto.GetUploadPath();
                if (!IsNull(VisaPhoto.Upload.DbValue)) {
                    VisaPhoto.ImageWidth = 120;
                    VisaPhoto.ImageHeight = 0;
                    VisaPhoto.ImageAlt = VisaPhoto.Alt;
                    VisaPhoto.ImageCssClass = "ew-image";
                    VisaPhoto.EditValue = VisaPhoto.Upload.DbValue;
                } else {
                    VisaPhoto.EditValue = "";
                }
                if (!Empty(VisaPhoto.CurrentValue))
                        VisaPhoto.Upload.FileName = ConvertToString(VisaPhoto.CurrentValue);
                if (IsShow && !EventCancelled)
                    await RenderUploadField(VisaPhoto);

                // RankAppliedFor
                RankAppliedFor.SetupEditAttributes();
                if (!RankAppliedFor.Raw)
                    RankAppliedFor.CurrentValue = HtmlDecode(RankAppliedFor.CurrentValue);
                RankAppliedFor.EditValue = HtmlEncode(RankAppliedFor.CurrentValue);
                RankAppliedFor.PlaceHolder = RemoveHtml(RankAppliedFor.Caption);

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

                // McuScheduleDate
                McuScheduleDate.SetupEditAttributes();
                McuScheduleDate.EditValue = FormatDateTime(McuScheduleDate.CurrentValue, McuScheduleDate.FormatPattern); // DN
                McuScheduleDate.PlaceHolder = RemoveHtml(McuScheduleDate.Caption);

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
                if (IsShow && !EventCancelled)
                    await RenderUploadField(McuAttachment);

                // McuRemark
                McuRemark.SetupEditAttributes();
                if (!McuRemark.Raw)
                    McuRemark.CurrentValue = HtmlDecode(McuRemark.CurrentValue);
                McuRemark.EditValue = HtmlEncode(McuRemark.CurrentValue);
                McuRemark.PlaceHolder = RemoveHtml(McuRemark.Caption);

                // Edit refer script

                // MTCrew_ID
                MTCrew_ID.HrefValue = "";

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";

                // FullName
                FullName.HrefValue = "";

                // RequiredPhoto
                RequiredPhoto.UploadPath = RequiredPhoto.GetUploadPath();
                if (!IsNull(RequiredPhoto.Upload.DbValue)) {
                    RequiredPhoto.HrefValue = ConvertToString(GetFileUploadUrl(RequiredPhoto, RequiredPhoto.HtmlDecode(ConvertToString(RequiredPhoto.Upload.DbValue)))); // Add prefix/suffix
                    RequiredPhoto.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        RequiredPhoto.HrefValue = FullUrl(ConvertToString(RequiredPhoto.HrefValue), "href");
                } else {
                    RequiredPhoto.HrefValue = "";
                }
                RequiredPhoto.ExportHrefValue = RequiredPhoto.UploadPath + RequiredPhoto.Upload.DbValue;

                // VisaPhoto
                VisaPhoto.UploadPath = VisaPhoto.GetUploadPath();
                if (!IsNull(VisaPhoto.Upload.DbValue)) {
                    VisaPhoto.HrefValue = ConvertToString(GetFileUploadUrl(VisaPhoto, VisaPhoto.HtmlDecode(ConvertToString(VisaPhoto.Upload.DbValue)))); // Add prefix/suffix
                    VisaPhoto.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        VisaPhoto.HrefValue = FullUrl(ConvertToString(VisaPhoto.HrefValue), "href");
                } else {
                    VisaPhoto.HrefValue = "";
                }
                VisaPhoto.ExportHrefValue = VisaPhoto.UploadPath + VisaPhoto.Upload.DbValue;

                // RankAppliedFor
                RankAppliedFor.HrefValue = "";

                // WillAcceptLowRank
                WillAcceptLowRank.HrefValue = "";

                // AvailableFrom
                AvailableFrom.HrefValue = "";

                // AvailableUntil
                AvailableUntil.HrefValue = "";

                // McuScheduleDate
                McuScheduleDate.HrefValue = "";

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
            if (IndividualCodeNumber.Required) {
                if (!IndividualCodeNumber.IsDetailKey && Empty(IndividualCodeNumber.FormValue)) {
                    IndividualCodeNumber.AddErrorMessage(ConvertToString(IndividualCodeNumber.RequiredErrorMessage).Replace("%s", IndividualCodeNumber.Caption));
                }
            }
            if (FullName.Required) {
                if (!FullName.IsDetailKey && Empty(FullName.FormValue)) {
                    FullName.AddErrorMessage(ConvertToString(FullName.RequiredErrorMessage).Replace("%s", FullName.Caption));
                }
            }
            if (RequiredPhoto.Required) {
                if (RequiredPhoto.Upload.FileName == "" && !RequiredPhoto.Upload.KeepFile) {
                    RequiredPhoto.AddErrorMessage(ConvertToString(RequiredPhoto.RequiredErrorMessage).Replace("%s", RequiredPhoto.Caption));
                }
            }
            if (VisaPhoto.Required) {
                if (VisaPhoto.Upload.FileName == "" && !VisaPhoto.Upload.KeepFile) {
                    VisaPhoto.AddErrorMessage(ConvertToString(VisaPhoto.RequiredErrorMessage).Replace("%s", VisaPhoto.Caption));
                }
            }
            if (RankAppliedFor.Required) {
                if (!RankAppliedFor.IsDetailKey && Empty(RankAppliedFor.FormValue)) {
                    RankAppliedFor.AddErrorMessage(ConvertToString(RankAppliedFor.RequiredErrorMessage).Replace("%s", RankAppliedFor.Caption));
                }
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
            if (McuScheduleDate.Required) {
                if (!McuScheduleDate.IsDetailKey && Empty(McuScheduleDate.FormValue)) {
                    McuScheduleDate.AddErrorMessage(ConvertToString(McuScheduleDate.RequiredErrorMessage).Replace("%s", McuScheduleDate.Caption));
                }
            }
            if (!CheckDate(McuScheduleDate.FormValue, McuScheduleDate.FormatPattern)) {
                McuScheduleDate.AddErrorMessage(McuScheduleDate.GetErrorMessage(false));
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
                RequiredPhoto.OldUploadPath = RequiredPhoto.GetUploadPath();
                RequiredPhoto.UploadPath = RequiredPhoto.OldUploadPath;
                VisaPhoto.OldUploadPath = VisaPhoto.GetUploadPath();
                VisaPhoto.UploadPath = VisaPhoto.OldUploadPath;
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }

            // Set new row
            Dictionary<string, object> rsnew = new ();

            // MTCrew_ID
            MTCrew_ID.SetDbValue(rsnew, MTCrew_ID.CurrentValue, MTCrew_ID.ReadOnly);

            // McuScheduleDate
            McuScheduleDate.SetDbValue(rsnew, ConvertToDateTimeOffset(McuScheduleDate.CurrentValue, DateTimeStyles.AssumeUniversal), McuScheduleDate.ReadOnly);

            // McuDate
            McuDate.SetDbValue(rsnew, ConvertToDateTimeOffset(McuDate.CurrentValue, DateTimeStyles.AssumeUniversal), McuDate.ReadOnly);

            // McuExpirationDate
            McuExpirationDate.SetDbValue(rsnew, ConvertToDateTimeOffset(McuExpirationDate.CurrentValue, DateTimeStyles.AssumeUniversal), McuExpirationDate.ReadOnly);

            // HealthStatus
            HealthStatus.SetDbValue(rsnew, HealthStatus.CurrentValue, HealthStatus.ReadOnly);

            // McuLocation
            McuLocation.SetDbValue(rsnew, McuLocation.CurrentValue, McuLocation.ReadOnly);

            // McuAttachment
            if (McuAttachment.Visible && !McuAttachment.ReadOnly && !McuAttachment.Upload.KeepFile) {
                McuAttachment.Upload.DbValue = rsold["McuAttachment"]; // Get original value
                if (Empty(McuAttachment.Upload.FileName)) {
                    rsnew["McuAttachment"] = DbNullValue;
                } else {
                    rsnew["McuAttachment"] = McuAttachment.Upload.FileName;
                }
            }

            // McuRemark
            McuRemark.SetDbValue(rsnew, McuRemark.CurrentValue, McuRemark.ReadOnly);

            // Update current values
            SetCurrentValues(rsnew);

            // Check field with unique index (IndividualCodeNumber)
            if (!Empty(IndividualCodeNumber.CurrentValue)) {
                string filterChk = "([IndividualCodeNumber] = '" + AdjustSql(IndividualCodeNumber.CurrentValue, DbId) + "')";
                filterChk = filterChk + " AND NOT (" + filter + ")";
                try {
                    using var rschk = await LoadReader(filterChk);
                    if (rschk?.HasRows ?? false) {
                        var idxErrMsg = Language.Phrase("DupIndex").Replace("%f", IndividualCodeNumber.Caption);
                        idxErrMsg = idxErrMsg.Replace("%v", ConvertToString(IndividualCodeNumber.CurrentValue));
                        FailureMessage = idxErrMsg;
                        return JsonBoolResult.FalseResult;
                    }
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    return JsonBoolResult.FalseResult;
                }
            }
            if (RequiredPhoto.Visible && !RequiredPhoto.Upload.KeepFile) {
                RequiredPhoto.UploadPath = RequiredPhoto.GetUploadPath();
                List<string> oldFiles = Empty(RequiredPhoto.Upload.DbValue) ? new () : new () { RequiredPhoto.HtmlDecode(RequiredPhoto.Upload.DbValue) };
                if (!Empty(RequiredPhoto.Upload.FileName)) {
                    var newFiles = new string[] { RequiredPhoto.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(RequiredPhoto, RequiredPhoto.Upload.Index);
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
                                var folders = new[] { RequiredPhoto.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(RequiredPhoto.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(RequiredPhoto.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    RequiredPhoto.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    RequiredPhoto.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    RequiredPhoto.SetDbValue(rsnew, RequiredPhoto.Upload.FileName, RequiredPhoto.ReadOnly);
                }
            }
            if (VisaPhoto.Visible && !VisaPhoto.Upload.KeepFile) {
                VisaPhoto.UploadPath = VisaPhoto.GetUploadPath();
                List<string> oldFiles = Empty(VisaPhoto.Upload.DbValue) ? new () : new () { VisaPhoto.HtmlDecode(VisaPhoto.Upload.DbValue) };
                if (!Empty(VisaPhoto.Upload.FileName)) {
                    var newFiles = new string[] { VisaPhoto.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(VisaPhoto, VisaPhoto.Upload.Index);
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
                                var folders = new[] { VisaPhoto.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(VisaPhoto.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(VisaPhoto.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    VisaPhoto.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    VisaPhoto.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    VisaPhoto.SetDbValue(rsnew, VisaPhoto.Upload.FileName, VisaPhoto.ReadOnly);
                }
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
                    McuAttachment.SetDbValue(rsnew, McuAttachment.Upload.FileName, McuAttachment.ReadOnly);
                }
            }

            // Call Row Updating event
            bool updateRow = RowUpdating(rsold, rsnew);

            // Check for duplicate key when key changed
            if (updateRow) {
                string newKeyFilter = GetRecordFilter(rsnew);
                if (newKeyFilter != oldKeyFilter) {
                    using var rsChk = await LoadReader(newKeyFilter);
                    if (rsChk?.HasRows ?? false) { // DN
                        FailureMessage = Language.Phrase("DupKey").Replace("%f", newKeyFilter);
                        updateRow = false;
                    }
                }
            }
            if (updateRow) {
                try {
                    if (rsnew.Count > 0)
                        result = await UpdateAsync(rsnew, null, rsold) > 0;
                    else
                        result = true;
                    if (result) {
                        if (RequiredPhoto.Visible && !RequiredPhoto.Upload.KeepFile) {
                            var newFiles = new string[] {};
                            var oldFiles = Empty(RequiredPhoto.Upload.DbValue) ? new string[] {} : new string[] { RequiredPhoto.HtmlDecode(RequiredPhoto.Upload.DbValue) };
                            if (!Empty(RequiredPhoto.Upload.FileName)) {
                                newFiles = new string[] { RequiredPhoto.Upload.FileName };
                                var newFiles2 = new string[] { RequiredPhoto.HtmlDecode(ConvertToString(rsnew["RequiredPhoto"])) };
                                for (var i = 0; i < newFiles.Length; i++) {
                                    if (!Empty(newFiles[i])) {
                                        var file = UploadTempPath(RequiredPhoto, RequiredPhoto.Upload.Index) + newFiles[i];
                                        if (FileExists(file)) {
                                            if (!Empty(newFiles2[i])) // Use correct file name
                                                newFiles[i] = newFiles2[i];
                                            if (!await RequiredPhoto.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                        DeleteFile(RequiredPhoto.OldPhysicalUploadPath + oldFiles[i]);
                                }
                            }
                        }
                        if (VisaPhoto.Visible && !VisaPhoto.Upload.KeepFile) {
                            var newFiles = new string[] {};
                            var oldFiles = Empty(VisaPhoto.Upload.DbValue) ? new string[] {} : new string[] { VisaPhoto.HtmlDecode(VisaPhoto.Upload.DbValue) };
                            if (!Empty(VisaPhoto.Upload.FileName)) {
                                newFiles = new string[] { VisaPhoto.Upload.FileName };
                                var newFiles2 = new string[] { VisaPhoto.HtmlDecode(ConvertToString(rsnew["VisaPhoto"])) };
                                for (var i = 0; i < newFiles.Length; i++) {
                                    if (!Empty(newFiles[i])) {
                                        var file = UploadTempPath(VisaPhoto, VisaPhoto.Upload.Index) + newFiles[i];
                                        if (FileExists(file)) {
                                            if (!Empty(newFiles2[i])) // Use correct file name
                                                newFiles[i] = newFiles2[i];
                                            if (!await VisaPhoto.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                        DeleteFile(VisaPhoto.OldPhysicalUploadPath + oldFiles[i]);
                                }
                            }
                        }
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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("McuResultList")), "", TableVar, true);
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
