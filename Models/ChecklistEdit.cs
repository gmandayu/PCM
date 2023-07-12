namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// checklistEdit
    /// </summary>
    public static ChecklistEdit checklistEdit
    {
        get => HttpData.Get<ChecklistEdit>("checklistEdit")!;
        set => HttpData["checklistEdit"] = value;
    }

    /// <summary>
    /// Page class for Checklist
    /// </summary>
    public class ChecklistEdit : ChecklistEditBase
    {
        // Constructor
        public ChecklistEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public ChecklistEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class ChecklistEditBase : Checklist
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "Checklist";

        // Page object name
        public string PageObjName = "checklistEdit";

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
        public ChecklistEditBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (checklist)
            if (checklist == null || checklist is Checklist)
                checklist = this;

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
        public string PageName => "ChecklistEdit";

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
            EmployeeStatus.Visible = false;
            IndividualCodeNumber.SetVisibility();
            FullName.SetVisibility();
            RequiredPhoto.SetVisibility();
            VisaPhoto.SetVisibility();
            RankAppliedFor.SetVisibility();
            WillAcceptLowRank.SetVisibility();
            AvailableFrom.SetVisibility();
            AvailableUntil.SetVisibility();
            Activity10.SetVisibility();
            RemarkActivity10.SetVisibility();
            Activity11.SetVisibility();
            RemarkActivity11.SetVisibility();
            Activity12.SetVisibility();
            RemarkActivity12.SetVisibility();
            Activity13.SetVisibility();
            RemarkActivity13.SetVisibility();
            Activity14.SetVisibility();
            RemarkActivity14.SetVisibility();
            Activity14Attachment.SetVisibility();
            Activity20.SetVisibility();
            RemarkActivity20.SetVisibility();
            Activity20Attachment.SetVisibility();
            Activity30.SetVisibility();
            RemarkActivity30.SetVisibility();
            Activity30Attachment.SetVisibility();
            Activity40.SetVisibility();
            RemarkActivity40.SetVisibility();
            Activity50.SetVisibility();
            RemarkActivity50.SetVisibility();
            Activity50Attachment.SetVisibility();
            Activity60.SetVisibility();
            RemarkActivity60.SetVisibility();
            Activity70.SetVisibility();
            RemarkActivity70.SetVisibility();
            Activity70Attachment.SetVisibility();
            InterviewerComment.SetVisibility();
            InterviewDate.SetVisibility();
            InterviewAttachment.SetVisibility();
            InterviewedByPersonOneName.SetVisibility();
            InterviewedByPersonOneRank.SetVisibility();
            InterviewedByPersonTwoName.SetVisibility();
            InterviewedByPersonTwoRank.SetVisibility();
            InterviewedByPersonThreeName.SetVisibility();
            InterviewedByPersonThreeRank.SetVisibility();
            FinalInterviewComment.SetVisibility();
            FinalInterviewAttachment.SetVisibility();
            JobKnowledge.SetVisibility();
            SafetyAwareness.SetVisibility();
            Personality.SetVisibility();
            EnglishProficiency.SetVisibility();
            PrincipalComment.SetVisibility();
            PrincipalCommentAttachment.SetVisibility();
            AssistantManagerPdeReviewed.SetVisibility();
            AssistantManagerPdeReviewedDate.SetVisibility();
            CrewingManagerApproval.SetVisibility();
            CrewingManagerApprovalDate.SetVisibility();
            FormPrintoutAttachment.SetVisibility();
            CreatedBy.Visible = false;
            CreatedDateTime.Visible = false;
            LastUpdatedBy.Visible = false;
            LastUpdatedDateTime.Visible = false;
        }

        // Constructor
        public ChecklistEditBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "ChecklistView" ? "1" : "0"); // If View page, no primary button
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
            key += UrlEncode(ConvertToString(dict.ContainsKey("ID") ? dict["ID"] : ID.CurrentValue));
            return key;
        }

        // Hide fields for Add/Edit
        protected void HideFieldsForAddEdit() {
            if (IsAddOrEdit)
                EmployeeStatus.Visible = false;
            if (IsAddOrEdit)
                IndividualCodeNumber.Visible = false;
            if (IsAddOrEdit)
                FullName.Visible = false;
            if (IsAddOrEdit)
                RequiredPhoto.Visible = false;
            if (IsAddOrEdit)
                VisaPhoto.Visible = false;
            if (IsAddOrEdit)
                RankAppliedFor.Visible = false;
            if (IsAddOrEdit)
                WillAcceptLowRank.Visible = false;
            if (IsAddOrEdit)
                AvailableFrom.Visible = false;
            if (IsAddOrEdit)
                AvailableUntil.Visible = false;
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
            await SetupLookupOptions(WillAcceptLowRank);
            await SetupLookupOptions(Activity10);
            await SetupLookupOptions(Activity11);
            await SetupLookupOptions(Activity12);
            await SetupLookupOptions(Activity13);
            await SetupLookupOptions(Activity14);
            await SetupLookupOptions(Activity20);
            await SetupLookupOptions(Activity30);
            await SetupLookupOptions(Activity40);
            await SetupLookupOptions(Activity50);
            await SetupLookupOptions(Activity60);
            await SetupLookupOptions(Activity70);
            await SetupLookupOptions(AssistantManagerPdeReviewed);
            await SetupLookupOptions(CrewingManagerApproval);

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
                            return Terminate("ChecklistList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = ReturnUrl;
                    if (GetPageName(returnUrl) == "ChecklistList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) {
                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "ChecklistList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "ChecklistList"; // Return list page content
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
                checklistEdit?.PageRender();
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

            // Check field name 'Activity10' before field var 'x_Activity10'
            val = CurrentForm.HasValue("Activity10") ? CurrentForm.GetValue("Activity10") : CurrentForm.GetValue("x_Activity10");
            if (!Activity10.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity10") && !CurrentForm.HasValue("x_Activity10")) // DN
                    Activity10.Visible = false; // Disable update for API request
                else
                    Activity10.SetFormValue(val);
            }

            // Check field name 'RemarkActivity10' before field var 'x_RemarkActivity10'
            val = CurrentForm.HasValue("RemarkActivity10") ? CurrentForm.GetValue("RemarkActivity10") : CurrentForm.GetValue("x_RemarkActivity10");
            if (!RemarkActivity10.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity10") && !CurrentForm.HasValue("x_RemarkActivity10")) // DN
                    RemarkActivity10.Visible = false; // Disable update for API request
                else
                    RemarkActivity10.SetFormValue(val);
            }

            // Check field name 'Activity11' before field var 'x_Activity11'
            val = CurrentForm.HasValue("Activity11") ? CurrentForm.GetValue("Activity11") : CurrentForm.GetValue("x_Activity11");
            if (!Activity11.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity11") && !CurrentForm.HasValue("x_Activity11")) // DN
                    Activity11.Visible = false; // Disable update for API request
                else
                    Activity11.SetFormValue(val);
            }

            // Check field name 'RemarkActivity11' before field var 'x_RemarkActivity11'
            val = CurrentForm.HasValue("RemarkActivity11") ? CurrentForm.GetValue("RemarkActivity11") : CurrentForm.GetValue("x_RemarkActivity11");
            if (!RemarkActivity11.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity11") && !CurrentForm.HasValue("x_RemarkActivity11")) // DN
                    RemarkActivity11.Visible = false; // Disable update for API request
                else
                    RemarkActivity11.SetFormValue(val);
            }

            // Check field name 'Activity12' before field var 'x_Activity12'
            val = CurrentForm.HasValue("Activity12") ? CurrentForm.GetValue("Activity12") : CurrentForm.GetValue("x_Activity12");
            if (!Activity12.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity12") && !CurrentForm.HasValue("x_Activity12")) // DN
                    Activity12.Visible = false; // Disable update for API request
                else
                    Activity12.SetFormValue(val);
            }

            // Check field name 'RemarkActivity12' before field var 'x_RemarkActivity12'
            val = CurrentForm.HasValue("RemarkActivity12") ? CurrentForm.GetValue("RemarkActivity12") : CurrentForm.GetValue("x_RemarkActivity12");
            if (!RemarkActivity12.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity12") && !CurrentForm.HasValue("x_RemarkActivity12")) // DN
                    RemarkActivity12.Visible = false; // Disable update for API request
                else
                    RemarkActivity12.SetFormValue(val);
            }

            // Check field name 'Activity13' before field var 'x_Activity13'
            val = CurrentForm.HasValue("Activity13") ? CurrentForm.GetValue("Activity13") : CurrentForm.GetValue("x_Activity13");
            if (!Activity13.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity13") && !CurrentForm.HasValue("x_Activity13")) // DN
                    Activity13.Visible = false; // Disable update for API request
                else
                    Activity13.SetFormValue(val);
            }

            // Check field name 'RemarkActivity13' before field var 'x_RemarkActivity13'
            val = CurrentForm.HasValue("RemarkActivity13") ? CurrentForm.GetValue("RemarkActivity13") : CurrentForm.GetValue("x_RemarkActivity13");
            if (!RemarkActivity13.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity13") && !CurrentForm.HasValue("x_RemarkActivity13")) // DN
                    RemarkActivity13.Visible = false; // Disable update for API request
                else
                    RemarkActivity13.SetFormValue(val);
            }

            // Check field name 'Activity14' before field var 'x_Activity14'
            val = CurrentForm.HasValue("Activity14") ? CurrentForm.GetValue("Activity14") : CurrentForm.GetValue("x_Activity14");
            if (!Activity14.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity14") && !CurrentForm.HasValue("x_Activity14")) // DN
                    Activity14.Visible = false; // Disable update for API request
                else
                    Activity14.SetFormValue(val);
            }

            // Check field name 'RemarkActivity14' before field var 'x_RemarkActivity14'
            val = CurrentForm.HasValue("RemarkActivity14") ? CurrentForm.GetValue("RemarkActivity14") : CurrentForm.GetValue("x_RemarkActivity14");
            if (!RemarkActivity14.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity14") && !CurrentForm.HasValue("x_RemarkActivity14")) // DN
                    RemarkActivity14.Visible = false; // Disable update for API request
                else
                    RemarkActivity14.SetFormValue(val);
            }

            // Check field name 'Activity14Attachment' before field var 'x_Activity14Attachment'
            val = CurrentForm.HasValue("Activity14Attachment") ? CurrentForm.GetValue("Activity14Attachment") : CurrentForm.GetValue("x_Activity14Attachment");
            if (!Activity14Attachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity14Attachment") && !CurrentForm.HasValue("x_Activity14Attachment")) // DN
                    Activity14Attachment.Visible = false; // Disable update for API request
                else
                    Activity14Attachment.SetFormValue(val);
            }

            // Check field name 'Activity20' before field var 'x_Activity20'
            val = CurrentForm.HasValue("Activity20") ? CurrentForm.GetValue("Activity20") : CurrentForm.GetValue("x_Activity20");
            if (!Activity20.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity20") && !CurrentForm.HasValue("x_Activity20")) // DN
                    Activity20.Visible = false; // Disable update for API request
                else
                    Activity20.SetFormValue(val);
            }

            // Check field name 'RemarkActivity20' before field var 'x_RemarkActivity20'
            val = CurrentForm.HasValue("RemarkActivity20") ? CurrentForm.GetValue("RemarkActivity20") : CurrentForm.GetValue("x_RemarkActivity20");
            if (!RemarkActivity20.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity20") && !CurrentForm.HasValue("x_RemarkActivity20")) // DN
                    RemarkActivity20.Visible = false; // Disable update for API request
                else
                    RemarkActivity20.SetFormValue(val);
            }

            // Check field name 'Activity20Attachment' before field var 'x_Activity20Attachment'
            val = CurrentForm.HasValue("Activity20Attachment") ? CurrentForm.GetValue("Activity20Attachment") : CurrentForm.GetValue("x_Activity20Attachment");
            if (!Activity20Attachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity20Attachment") && !CurrentForm.HasValue("x_Activity20Attachment")) // DN
                    Activity20Attachment.Visible = false; // Disable update for API request
                else
                    Activity20Attachment.SetFormValue(val);
            }

            // Check field name 'Activity30' before field var 'x_Activity30'
            val = CurrentForm.HasValue("Activity30") ? CurrentForm.GetValue("Activity30") : CurrentForm.GetValue("x_Activity30");
            if (!Activity30.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity30") && !CurrentForm.HasValue("x_Activity30")) // DN
                    Activity30.Visible = false; // Disable update for API request
                else
                    Activity30.SetFormValue(val);
            }

            // Check field name 'RemarkActivity30' before field var 'x_RemarkActivity30'
            val = CurrentForm.HasValue("RemarkActivity30") ? CurrentForm.GetValue("RemarkActivity30") : CurrentForm.GetValue("x_RemarkActivity30");
            if (!RemarkActivity30.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity30") && !CurrentForm.HasValue("x_RemarkActivity30")) // DN
                    RemarkActivity30.Visible = false; // Disable update for API request
                else
                    RemarkActivity30.SetFormValue(val);
            }

            // Check field name 'Activity30Attachment' before field var 'x_Activity30Attachment'
            val = CurrentForm.HasValue("Activity30Attachment") ? CurrentForm.GetValue("Activity30Attachment") : CurrentForm.GetValue("x_Activity30Attachment");
            if (!Activity30Attachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity30Attachment") && !CurrentForm.HasValue("x_Activity30Attachment")) // DN
                    Activity30Attachment.Visible = false; // Disable update for API request
                else
                    Activity30Attachment.SetFormValue(val);
            }

            // Check field name 'Activity40' before field var 'x_Activity40'
            val = CurrentForm.HasValue("Activity40") ? CurrentForm.GetValue("Activity40") : CurrentForm.GetValue("x_Activity40");
            if (!Activity40.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity40") && !CurrentForm.HasValue("x_Activity40")) // DN
                    Activity40.Visible = false; // Disable update for API request
                else
                    Activity40.SetFormValue(val);
            }

            // Check field name 'RemarkActivity40' before field var 'x_RemarkActivity40'
            val = CurrentForm.HasValue("RemarkActivity40") ? CurrentForm.GetValue("RemarkActivity40") : CurrentForm.GetValue("x_RemarkActivity40");
            if (!RemarkActivity40.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity40") && !CurrentForm.HasValue("x_RemarkActivity40")) // DN
                    RemarkActivity40.Visible = false; // Disable update for API request
                else
                    RemarkActivity40.SetFormValue(val);
            }

            // Check field name 'Activity50' before field var 'x_Activity50'
            val = CurrentForm.HasValue("Activity50") ? CurrentForm.GetValue("Activity50") : CurrentForm.GetValue("x_Activity50");
            if (!Activity50.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity50") && !CurrentForm.HasValue("x_Activity50")) // DN
                    Activity50.Visible = false; // Disable update for API request
                else
                    Activity50.SetFormValue(val);
            }

            // Check field name 'RemarkActivity50' before field var 'x_RemarkActivity50'
            val = CurrentForm.HasValue("RemarkActivity50") ? CurrentForm.GetValue("RemarkActivity50") : CurrentForm.GetValue("x_RemarkActivity50");
            if (!RemarkActivity50.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity50") && !CurrentForm.HasValue("x_RemarkActivity50")) // DN
                    RemarkActivity50.Visible = false; // Disable update for API request
                else
                    RemarkActivity50.SetFormValue(val);
            }

            // Check field name 'Activity50Attachment' before field var 'x_Activity50Attachment'
            val = CurrentForm.HasValue("Activity50Attachment") ? CurrentForm.GetValue("Activity50Attachment") : CurrentForm.GetValue("x_Activity50Attachment");
            if (!Activity50Attachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity50Attachment") && !CurrentForm.HasValue("x_Activity50Attachment")) // DN
                    Activity50Attachment.Visible = false; // Disable update for API request
                else
                    Activity50Attachment.SetFormValue(val);
            }

            // Check field name 'Activity60' before field var 'x_Activity60'
            val = CurrentForm.HasValue("Activity60") ? CurrentForm.GetValue("Activity60") : CurrentForm.GetValue("x_Activity60");
            if (!Activity60.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity60") && !CurrentForm.HasValue("x_Activity60")) // DN
                    Activity60.Visible = false; // Disable update for API request
                else
                    Activity60.SetFormValue(val);
            }

            // Check field name 'RemarkActivity60' before field var 'x_RemarkActivity60'
            val = CurrentForm.HasValue("RemarkActivity60") ? CurrentForm.GetValue("RemarkActivity60") : CurrentForm.GetValue("x_RemarkActivity60");
            if (!RemarkActivity60.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity60") && !CurrentForm.HasValue("x_RemarkActivity60")) // DN
                    RemarkActivity60.Visible = false; // Disable update for API request
                else
                    RemarkActivity60.SetFormValue(val);
            }

            // Check field name 'Activity70' before field var 'x_Activity70'
            val = CurrentForm.HasValue("Activity70") ? CurrentForm.GetValue("Activity70") : CurrentForm.GetValue("x_Activity70");
            if (!Activity70.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity70") && !CurrentForm.HasValue("x_Activity70")) // DN
                    Activity70.Visible = false; // Disable update for API request
                else
                    Activity70.SetFormValue(val);
            }

            // Check field name 'RemarkActivity70' before field var 'x_RemarkActivity70'
            val = CurrentForm.HasValue("RemarkActivity70") ? CurrentForm.GetValue("RemarkActivity70") : CurrentForm.GetValue("x_RemarkActivity70");
            if (!RemarkActivity70.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity70") && !CurrentForm.HasValue("x_RemarkActivity70")) // DN
                    RemarkActivity70.Visible = false; // Disable update for API request
                else
                    RemarkActivity70.SetFormValue(val);
            }

            // Check field name 'Activity70Attachment' before field var 'x_Activity70Attachment'
            val = CurrentForm.HasValue("Activity70Attachment") ? CurrentForm.GetValue("Activity70Attachment") : CurrentForm.GetValue("x_Activity70Attachment");
            if (!Activity70Attachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity70Attachment") && !CurrentForm.HasValue("x_Activity70Attachment")) // DN
                    Activity70Attachment.Visible = false; // Disable update for API request
                else
                    Activity70Attachment.SetFormValue(val);
            }

            // Check field name 'InterviewerComment' before field var 'x_InterviewerComment'
            val = CurrentForm.HasValue("InterviewerComment") ? CurrentForm.GetValue("InterviewerComment") : CurrentForm.GetValue("x_InterviewerComment");
            if (!InterviewerComment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewerComment") && !CurrentForm.HasValue("x_InterviewerComment")) // DN
                    InterviewerComment.Visible = false; // Disable update for API request
                else
                    InterviewerComment.SetFormValue(val);
            }

            // Check field name 'InterviewDate' before field var 'x_InterviewDate'
            val = CurrentForm.HasValue("InterviewDate") ? CurrentForm.GetValue("InterviewDate") : CurrentForm.GetValue("x_InterviewDate");
            if (!InterviewDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewDate") && !CurrentForm.HasValue("x_InterviewDate")) // DN
                    InterviewDate.Visible = false; // Disable update for API request
                else
                    InterviewDate.SetFormValue(val, true, validate);
                InterviewDate.CurrentValue = UnformatDateTime(InterviewDate.CurrentValue, InterviewDate.FormatPattern);
            }

            // Check field name 'InterviewAttachment' before field var 'x_InterviewAttachment'
            val = CurrentForm.HasValue("InterviewAttachment") ? CurrentForm.GetValue("InterviewAttachment") : CurrentForm.GetValue("x_InterviewAttachment");
            if (!InterviewAttachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewAttachment") && !CurrentForm.HasValue("x_InterviewAttachment")) // DN
                    InterviewAttachment.Visible = false; // Disable update for API request
                else
                    InterviewAttachment.SetFormValue(val);
            }

            // Check field name 'InterviewedByPersonOneName' before field var 'x_InterviewedByPersonOneName'
            val = CurrentForm.HasValue("InterviewedByPersonOneName") ? CurrentForm.GetValue("InterviewedByPersonOneName") : CurrentForm.GetValue("x_InterviewedByPersonOneName");
            if (!InterviewedByPersonOneName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonOneName") && !CurrentForm.HasValue("x_InterviewedByPersonOneName")) // DN
                    InterviewedByPersonOneName.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonOneName.SetFormValue(val);
            }

            // Check field name 'InterviewedByPersonOneRank' before field var 'x_InterviewedByPersonOneRank'
            val = CurrentForm.HasValue("InterviewedByPersonOneRank") ? CurrentForm.GetValue("InterviewedByPersonOneRank") : CurrentForm.GetValue("x_InterviewedByPersonOneRank");
            if (!InterviewedByPersonOneRank.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonOneRank") && !CurrentForm.HasValue("x_InterviewedByPersonOneRank")) // DN
                    InterviewedByPersonOneRank.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonOneRank.SetFormValue(val);
            }

            // Check field name 'InterviewedByPersonTwoName' before field var 'x_InterviewedByPersonTwoName'
            val = CurrentForm.HasValue("InterviewedByPersonTwoName") ? CurrentForm.GetValue("InterviewedByPersonTwoName") : CurrentForm.GetValue("x_InterviewedByPersonTwoName");
            if (!InterviewedByPersonTwoName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonTwoName") && !CurrentForm.HasValue("x_InterviewedByPersonTwoName")) // DN
                    InterviewedByPersonTwoName.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonTwoName.SetFormValue(val);
            }

            // Check field name 'InterviewedByPersonTwoRank' before field var 'x_InterviewedByPersonTwoRank'
            val = CurrentForm.HasValue("InterviewedByPersonTwoRank") ? CurrentForm.GetValue("InterviewedByPersonTwoRank") : CurrentForm.GetValue("x_InterviewedByPersonTwoRank");
            if (!InterviewedByPersonTwoRank.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonTwoRank") && !CurrentForm.HasValue("x_InterviewedByPersonTwoRank")) // DN
                    InterviewedByPersonTwoRank.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonTwoRank.SetFormValue(val);
            }

            // Check field name 'InterviewedByPersonThreeName' before field var 'x_InterviewedByPersonThreeName'
            val = CurrentForm.HasValue("InterviewedByPersonThreeName") ? CurrentForm.GetValue("InterviewedByPersonThreeName") : CurrentForm.GetValue("x_InterviewedByPersonThreeName");
            if (!InterviewedByPersonThreeName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonThreeName") && !CurrentForm.HasValue("x_InterviewedByPersonThreeName")) // DN
                    InterviewedByPersonThreeName.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonThreeName.SetFormValue(val);
            }

            // Check field name 'InterviewedByPersonThreeRank' before field var 'x_InterviewedByPersonThreeRank'
            val = CurrentForm.HasValue("InterviewedByPersonThreeRank") ? CurrentForm.GetValue("InterviewedByPersonThreeRank") : CurrentForm.GetValue("x_InterviewedByPersonThreeRank");
            if (!InterviewedByPersonThreeRank.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonThreeRank") && !CurrentForm.HasValue("x_InterviewedByPersonThreeRank")) // DN
                    InterviewedByPersonThreeRank.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonThreeRank.SetFormValue(val);
            }

            // Check field name 'FinalInterviewComment' before field var 'x_FinalInterviewComment'
            val = CurrentForm.HasValue("FinalInterviewComment") ? CurrentForm.GetValue("FinalInterviewComment") : CurrentForm.GetValue("x_FinalInterviewComment");
            if (!FinalInterviewComment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FinalInterviewComment") && !CurrentForm.HasValue("x_FinalInterviewComment")) // DN
                    FinalInterviewComment.Visible = false; // Disable update for API request
                else
                    FinalInterviewComment.SetFormValue(val);
            }

            // Check field name 'FinalInterviewAttachment' before field var 'x_FinalInterviewAttachment'
            val = CurrentForm.HasValue("FinalInterviewAttachment") ? CurrentForm.GetValue("FinalInterviewAttachment") : CurrentForm.GetValue("x_FinalInterviewAttachment");
            if (!FinalInterviewAttachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FinalInterviewAttachment") && !CurrentForm.HasValue("x_FinalInterviewAttachment")) // DN
                    FinalInterviewAttachment.Visible = false; // Disable update for API request
                else
                    FinalInterviewAttachment.SetFormValue(val);
            }

            // Check field name 'JobKnowledge' before field var 'x_JobKnowledge'
            val = CurrentForm.HasValue("JobKnowledge") ? CurrentForm.GetValue("JobKnowledge") : CurrentForm.GetValue("x_JobKnowledge");
            if (!JobKnowledge.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("JobKnowledge") && !CurrentForm.HasValue("x_JobKnowledge")) // DN
                    JobKnowledge.Visible = false; // Disable update for API request
                else
                    JobKnowledge.SetFormValue(val);
            }

            // Check field name 'SafetyAwareness' before field var 'x_SafetyAwareness'
            val = CurrentForm.HasValue("SafetyAwareness") ? CurrentForm.GetValue("SafetyAwareness") : CurrentForm.GetValue("x_SafetyAwareness");
            if (!SafetyAwareness.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SafetyAwareness") && !CurrentForm.HasValue("x_SafetyAwareness")) // DN
                    SafetyAwareness.Visible = false; // Disable update for API request
                else
                    SafetyAwareness.SetFormValue(val);
            }

            // Check field name 'Personality' before field var 'x_Personality'
            val = CurrentForm.HasValue("Personality") ? CurrentForm.GetValue("Personality") : CurrentForm.GetValue("x_Personality");
            if (!Personality.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Personality") && !CurrentForm.HasValue("x_Personality")) // DN
                    Personality.Visible = false; // Disable update for API request
                else
                    Personality.SetFormValue(val);
            }

            // Check field name 'EnglishProficiency' before field var 'x_EnglishProficiency'
            val = CurrentForm.HasValue("EnglishProficiency") ? CurrentForm.GetValue("EnglishProficiency") : CurrentForm.GetValue("x_EnglishProficiency");
            if (!EnglishProficiency.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("EnglishProficiency") && !CurrentForm.HasValue("x_EnglishProficiency")) // DN
                    EnglishProficiency.Visible = false; // Disable update for API request
                else
                    EnglishProficiency.SetFormValue(val);
            }

            // Check field name 'PrincipalComment' before field var 'x_PrincipalComment'
            val = CurrentForm.HasValue("PrincipalComment") ? CurrentForm.GetValue("PrincipalComment") : CurrentForm.GetValue("x_PrincipalComment");
            if (!PrincipalComment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrincipalComment") && !CurrentForm.HasValue("x_PrincipalComment")) // DN
                    PrincipalComment.Visible = false; // Disable update for API request
                else
                    PrincipalComment.SetFormValue(val);
            }

            // Check field name 'PrincipalCommentAttachment' before field var 'x_PrincipalCommentAttachment'
            val = CurrentForm.HasValue("PrincipalCommentAttachment") ? CurrentForm.GetValue("PrincipalCommentAttachment") : CurrentForm.GetValue("x_PrincipalCommentAttachment");
            if (!PrincipalCommentAttachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrincipalCommentAttachment") && !CurrentForm.HasValue("x_PrincipalCommentAttachment")) // DN
                    PrincipalCommentAttachment.Visible = false; // Disable update for API request
                else
                    PrincipalCommentAttachment.SetFormValue(val);
            }

            // Check field name 'AssistantManagerPdeReviewed' before field var 'x_AssistantManagerPdeReviewed'
            val = CurrentForm.HasValue("AssistantManagerPdeReviewed") ? CurrentForm.GetValue("AssistantManagerPdeReviewed") : CurrentForm.GetValue("x_AssistantManagerPdeReviewed");
            if (!AssistantManagerPdeReviewed.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AssistantManagerPdeReviewed") && !CurrentForm.HasValue("x_AssistantManagerPdeReviewed")) // DN
                    AssistantManagerPdeReviewed.Visible = false; // Disable update for API request
                else
                    AssistantManagerPdeReviewed.SetFormValue(val);
            }

            // Check field name 'AssistantManagerPdeReviewedDate' before field var 'x_AssistantManagerPdeReviewedDate'
            val = CurrentForm.HasValue("AssistantManagerPdeReviewedDate") ? CurrentForm.GetValue("AssistantManagerPdeReviewedDate") : CurrentForm.GetValue("x_AssistantManagerPdeReviewedDate");
            if (!AssistantManagerPdeReviewedDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AssistantManagerPdeReviewedDate") && !CurrentForm.HasValue("x_AssistantManagerPdeReviewedDate")) // DN
                    AssistantManagerPdeReviewedDate.Visible = false; // Disable update for API request
                else
                    AssistantManagerPdeReviewedDate.SetFormValue(val, true, validate);
                AssistantManagerPdeReviewedDate.CurrentValue = UnformatDateTime(AssistantManagerPdeReviewedDate.CurrentValue, AssistantManagerPdeReviewedDate.FormatPattern);
            }

            // Check field name 'CrewingManagerApproval' before field var 'x_CrewingManagerApproval'
            val = CurrentForm.HasValue("CrewingManagerApproval") ? CurrentForm.GetValue("CrewingManagerApproval") : CurrentForm.GetValue("x_CrewingManagerApproval");
            if (!CrewingManagerApproval.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CrewingManagerApproval") && !CurrentForm.HasValue("x_CrewingManagerApproval")) // DN
                    CrewingManagerApproval.Visible = false; // Disable update for API request
                else
                    CrewingManagerApproval.SetFormValue(val);
            }

            // Check field name 'CrewingManagerApprovalDate' before field var 'x_CrewingManagerApprovalDate'
            val = CurrentForm.HasValue("CrewingManagerApprovalDate") ? CurrentForm.GetValue("CrewingManagerApprovalDate") : CurrentForm.GetValue("x_CrewingManagerApprovalDate");
            if (!CrewingManagerApprovalDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CrewingManagerApprovalDate") && !CurrentForm.HasValue("x_CrewingManagerApprovalDate")) // DN
                    CrewingManagerApprovalDate.Visible = false; // Disable update for API request
                else
                    CrewingManagerApprovalDate.SetFormValue(val, true, validate);
                CrewingManagerApprovalDate.CurrentValue = UnformatDateTime(CrewingManagerApprovalDate.CurrentValue, CrewingManagerApprovalDate.FormatPattern);
            }

            // Check field name 'FormPrintoutAttachment' before field var 'x_FormPrintoutAttachment'
            val = CurrentForm.HasValue("FormPrintoutAttachment") ? CurrentForm.GetValue("FormPrintoutAttachment") : CurrentForm.GetValue("x_FormPrintoutAttachment");
            if (!FormPrintoutAttachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FormPrintoutAttachment") && !CurrentForm.HasValue("x_FormPrintoutAttachment")) // DN
                    FormPrintoutAttachment.Visible = false; // Disable update for API request
                else
                    FormPrintoutAttachment.SetFormValue(val);
            }

            // Check field name 'ID' before field var 'x_ID'
            val = CurrentForm.HasValue("ID") ? CurrentForm.GetValue("ID") : CurrentForm.GetValue("x_ID");
            if (!ID.IsDetailKey)
                ID.SetFormValue(CurrentForm.GetValue("x_ID"));
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
            ID.CurrentValue = ID.FormValue;
            MTCrewID.CurrentValue = MTCrewID.FormValue;
            IndividualCodeNumber.CurrentValue = IndividualCodeNumber.FormValue;
            FullName.CurrentValue = FullName.FormValue;
            RankAppliedFor.CurrentValue = RankAppliedFor.FormValue;
            WillAcceptLowRank.CurrentValue = WillAcceptLowRank.FormValue;
            AvailableFrom.CurrentValue = AvailableFrom.FormValue;
            AvailableFrom.CurrentValue = UnformatDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern);
            AvailableUntil.CurrentValue = AvailableUntil.FormValue;
            AvailableUntil.CurrentValue = UnformatDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern);
            Activity10.CurrentValue = Activity10.FormValue;
            RemarkActivity10.CurrentValue = RemarkActivity10.FormValue;
            Activity11.CurrentValue = Activity11.FormValue;
            RemarkActivity11.CurrentValue = RemarkActivity11.FormValue;
            Activity12.CurrentValue = Activity12.FormValue;
            RemarkActivity12.CurrentValue = RemarkActivity12.FormValue;
            Activity13.CurrentValue = Activity13.FormValue;
            RemarkActivity13.CurrentValue = RemarkActivity13.FormValue;
            Activity14.CurrentValue = Activity14.FormValue;
            RemarkActivity14.CurrentValue = RemarkActivity14.FormValue;
            Activity14Attachment.CurrentValue = Activity14Attachment.FormValue;
            Activity20.CurrentValue = Activity20.FormValue;
            RemarkActivity20.CurrentValue = RemarkActivity20.FormValue;
            Activity20Attachment.CurrentValue = Activity20Attachment.FormValue;
            Activity30.CurrentValue = Activity30.FormValue;
            RemarkActivity30.CurrentValue = RemarkActivity30.FormValue;
            Activity30Attachment.CurrentValue = Activity30Attachment.FormValue;
            Activity40.CurrentValue = Activity40.FormValue;
            RemarkActivity40.CurrentValue = RemarkActivity40.FormValue;
            Activity50.CurrentValue = Activity50.FormValue;
            RemarkActivity50.CurrentValue = RemarkActivity50.FormValue;
            Activity50Attachment.CurrentValue = Activity50Attachment.FormValue;
            Activity60.CurrentValue = Activity60.FormValue;
            RemarkActivity60.CurrentValue = RemarkActivity60.FormValue;
            Activity70.CurrentValue = Activity70.FormValue;
            RemarkActivity70.CurrentValue = RemarkActivity70.FormValue;
            Activity70Attachment.CurrentValue = Activity70Attachment.FormValue;
            InterviewerComment.CurrentValue = InterviewerComment.FormValue;
            InterviewDate.CurrentValue = InterviewDate.FormValue;
            InterviewDate.CurrentValue = UnformatDateTime(InterviewDate.CurrentValue, InterviewDate.FormatPattern);
            InterviewAttachment.CurrentValue = InterviewAttachment.FormValue;
            InterviewedByPersonOneName.CurrentValue = InterviewedByPersonOneName.FormValue;
            InterviewedByPersonOneRank.CurrentValue = InterviewedByPersonOneRank.FormValue;
            InterviewedByPersonTwoName.CurrentValue = InterviewedByPersonTwoName.FormValue;
            InterviewedByPersonTwoRank.CurrentValue = InterviewedByPersonTwoRank.FormValue;
            InterviewedByPersonThreeName.CurrentValue = InterviewedByPersonThreeName.FormValue;
            InterviewedByPersonThreeRank.CurrentValue = InterviewedByPersonThreeRank.FormValue;
            FinalInterviewComment.CurrentValue = FinalInterviewComment.FormValue;
            FinalInterviewAttachment.CurrentValue = FinalInterviewAttachment.FormValue;
            JobKnowledge.CurrentValue = JobKnowledge.FormValue;
            SafetyAwareness.CurrentValue = SafetyAwareness.FormValue;
            Personality.CurrentValue = Personality.FormValue;
            EnglishProficiency.CurrentValue = EnglishProficiency.FormValue;
            PrincipalComment.CurrentValue = PrincipalComment.FormValue;
            PrincipalCommentAttachment.CurrentValue = PrincipalCommentAttachment.FormValue;
            AssistantManagerPdeReviewed.CurrentValue = AssistantManagerPdeReviewed.FormValue;
            AssistantManagerPdeReviewedDate.CurrentValue = AssistantManagerPdeReviewedDate.FormValue;
            AssistantManagerPdeReviewedDate.CurrentValue = UnformatDateTime(AssistantManagerPdeReviewedDate.CurrentValue, AssistantManagerPdeReviewedDate.FormatPattern);
            CrewingManagerApproval.CurrentValue = CrewingManagerApproval.FormValue;
            CrewingManagerApprovalDate.CurrentValue = CrewingManagerApprovalDate.FormValue;
            CrewingManagerApprovalDate.CurrentValue = UnformatDateTime(CrewingManagerApprovalDate.CurrentValue, CrewingManagerApprovalDate.FormatPattern);
            FormPrintoutAttachment.CurrentValue = FormPrintoutAttachment.FormValue;
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
            MTCrewID.SetDbValue(row["MTCrewID"]);
            EmployeeStatus.SetDbValue(row["EmployeeStatus"]);
            IndividualCodeNumber.SetDbValue(row["IndividualCodeNumber"]);
            FullName.SetDbValue(row["FullName"]);
            RequiredPhoto.Upload.DbValue = row["RequiredPhoto"];
            RequiredPhoto.SetDbValue(RequiredPhoto.Upload.DbValue);
            VisaPhoto.Upload.DbValue = row["VisaPhoto"];
            VisaPhoto.SetDbValue(VisaPhoto.Upload.DbValue);
            RankAppliedFor.SetDbValue(row["RankAppliedFor"]);
            WillAcceptLowRank.SetDbValue((ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"));
            AvailableFrom.SetDbValue(row["AvailableFrom"]);
            AvailableUntil.SetDbValue(row["AvailableUntil"]);
            Activity10.SetDbValue((ConvertToBool(row["Activity10"]) ? "1" : "0"));
            RemarkActivity10.SetDbValue(row["RemarkActivity10"]);
            Activity11.SetDbValue((ConvertToBool(row["Activity11"]) ? "1" : "0"));
            RemarkActivity11.SetDbValue(row["RemarkActivity11"]);
            Activity12.SetDbValue((ConvertToBool(row["Activity12"]) ? "1" : "0"));
            RemarkActivity12.SetDbValue(row["RemarkActivity12"]);
            Activity13.SetDbValue((ConvertToBool(row["Activity13"]) ? "1" : "0"));
            RemarkActivity13.SetDbValue(row["RemarkActivity13"]);
            Activity14.SetDbValue((ConvertToBool(row["Activity14"]) ? "1" : "0"));
            RemarkActivity14.SetDbValue(row["RemarkActivity14"]);
            Activity14Attachment.SetDbValue(row["Activity14Attachment"]);
            Activity20.SetDbValue((ConvertToBool(row["Activity20"]) ? "1" : "0"));
            RemarkActivity20.SetDbValue(row["RemarkActivity20"]);
            Activity20Attachment.SetDbValue(row["Activity20Attachment"]);
            Activity30.SetDbValue((ConvertToBool(row["Activity30"]) ? "1" : "0"));
            RemarkActivity30.SetDbValue(row["RemarkActivity30"]);
            Activity30Attachment.SetDbValue(row["Activity30Attachment"]);
            Activity40.SetDbValue((ConvertToBool(row["Activity40"]) ? "1" : "0"));
            RemarkActivity40.SetDbValue(row["RemarkActivity40"]);
            Activity50.SetDbValue((ConvertToBool(row["Activity50"]) ? "1" : "0"));
            RemarkActivity50.SetDbValue(row["RemarkActivity50"]);
            Activity50Attachment.SetDbValue(row["Activity50Attachment"]);
            Activity60.SetDbValue((ConvertToBool(row["Activity60"]) ? "1" : "0"));
            RemarkActivity60.SetDbValue(row["RemarkActivity60"]);
            Activity70.SetDbValue((ConvertToBool(row["Activity70"]) ? "1" : "0"));
            RemarkActivity70.SetDbValue(row["RemarkActivity70"]);
            Activity70Attachment.SetDbValue(row["Activity70Attachment"]);
            InterviewerComment.SetDbValue(row["InterviewerComment"]);
            InterviewDate.SetDbValue(row["InterviewDate"]);
            InterviewAttachment.SetDbValue(row["InterviewAttachment"]);
            InterviewedByPersonOneName.SetDbValue(row["InterviewedByPersonOneName"]);
            InterviewedByPersonOneRank.SetDbValue(row["InterviewedByPersonOneRank"]);
            InterviewedByPersonTwoName.SetDbValue(row["InterviewedByPersonTwoName"]);
            InterviewedByPersonTwoRank.SetDbValue(row["InterviewedByPersonTwoRank"]);
            InterviewedByPersonThreeName.SetDbValue(row["InterviewedByPersonThreeName"]);
            InterviewedByPersonThreeRank.SetDbValue(row["InterviewedByPersonThreeRank"]);
            FinalInterviewComment.SetDbValue(row["FinalInterviewComment"]);
            FinalInterviewAttachment.SetDbValue(row["FinalInterviewAttachment"]);
            JobKnowledge.SetDbValue(row["JobKnowledge"]);
            SafetyAwareness.SetDbValue(row["SafetyAwareness"]);
            Personality.SetDbValue(row["Personality"]);
            EnglishProficiency.SetDbValue(row["EnglishProficiency"]);
            PrincipalComment.SetDbValue(row["PrincipalComment"]);
            PrincipalCommentAttachment.SetDbValue(row["PrincipalCommentAttachment"]);
            AssistantManagerPdeReviewed.SetDbValue((ConvertToBool(row["AssistantManagerPdeReviewed"]) ? "1" : "0"));
            AssistantManagerPdeReviewedDate.SetDbValue(row["AssistantManagerPdeReviewedDate"]);
            CrewingManagerApproval.SetDbValue((ConvertToBool(row["CrewingManagerApproval"]) ? "1" : "0"));
            CrewingManagerApprovalDate.SetDbValue(row["CrewingManagerApprovalDate"]);
            FormPrintoutAttachment.SetDbValue(row["FormPrintoutAttachment"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTCrewID", MTCrewID.DefaultValue ?? DbNullValue); // DN
            row.Add("EmployeeStatus", EmployeeStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("IndividualCodeNumber", IndividualCodeNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("RequiredPhoto", RequiredPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("VisaPhoto", VisaPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("RankAppliedFor", RankAppliedFor.DefaultValue ?? DbNullValue); // DN
            row.Add("WillAcceptLowRank", WillAcceptLowRank.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableFrom", AvailableFrom.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableUntil", AvailableUntil.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity10", Activity10.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity10", RemarkActivity10.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity11", Activity11.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity11", RemarkActivity11.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity12", Activity12.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity12", RemarkActivity12.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity13", Activity13.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity13", RemarkActivity13.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity14", Activity14.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity14", RemarkActivity14.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity14Attachment", Activity14Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity20", Activity20.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity20", RemarkActivity20.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity20Attachment", Activity20Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity30", Activity30.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity30", RemarkActivity30.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity30Attachment", Activity30Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity40", Activity40.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity40", RemarkActivity40.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity50", Activity50.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity50", RemarkActivity50.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity50Attachment", Activity50Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity60", Activity60.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity60", RemarkActivity60.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity70", Activity70.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity70", RemarkActivity70.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity70Attachment", Activity70Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewerComment", InterviewerComment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewDate", InterviewDate.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewAttachment", InterviewAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneName", InterviewedByPersonOneName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneRank", InterviewedByPersonOneRank.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoName", InterviewedByPersonTwoName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoRank", InterviewedByPersonTwoRank.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeName", InterviewedByPersonThreeName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeRank", InterviewedByPersonThreeRank.DefaultValue ?? DbNullValue); // DN
            row.Add("FinalInterviewComment", FinalInterviewComment.DefaultValue ?? DbNullValue); // DN
            row.Add("FinalInterviewAttachment", FinalInterviewAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("JobKnowledge", JobKnowledge.DefaultValue ?? DbNullValue); // DN
            row.Add("SafetyAwareness", SafetyAwareness.DefaultValue ?? DbNullValue); // DN
            row.Add("Personality", Personality.DefaultValue ?? DbNullValue); // DN
            row.Add("EnglishProficiency", EnglishProficiency.DefaultValue ?? DbNullValue); // DN
            row.Add("PrincipalComment", PrincipalComment.DefaultValue ?? DbNullValue); // DN
            row.Add("PrincipalCommentAttachment", PrincipalCommentAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("AssistantManagerPdeReviewed", AssistantManagerPdeReviewed.DefaultValue ?? DbNullValue); // DN
            row.Add("AssistantManagerPdeReviewedDate", AssistantManagerPdeReviewedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewingManagerApproval", CrewingManagerApproval.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewingManagerApprovalDate", CrewingManagerApprovalDate.DefaultValue ?? DbNullValue); // DN
            row.Add("FormPrintoutAttachment", FormPrintoutAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
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

            // MTCrewID
            MTCrewID.RowCssClass = "row";

            // EmployeeStatus
            EmployeeStatus.RowCssClass = "row";

            // IndividualCodeNumber
            IndividualCodeNumber.RowCssClass = "row";

            // FullName
            FullName.RowCssClass = "row";

            // RequiredPhoto
            RequiredPhoto.RowCssClass = "row";

            // VisaPhoto
            VisaPhoto.RowCssClass = "row";

            // RankAppliedFor
            RankAppliedFor.RowCssClass = "row";

            // WillAcceptLowRank
            WillAcceptLowRank.RowCssClass = "row";

            // AvailableFrom
            AvailableFrom.RowCssClass = "row";

            // AvailableUntil
            AvailableUntil.RowCssClass = "row";

            // Activity10
            Activity10.RowCssClass = "row";

            // RemarkActivity10
            RemarkActivity10.RowCssClass = "row";

            // Activity11
            Activity11.RowCssClass = "row";

            // RemarkActivity11
            RemarkActivity11.RowCssClass = "row";

            // Activity12
            Activity12.RowCssClass = "row";

            // RemarkActivity12
            RemarkActivity12.RowCssClass = "row";

            // Activity13
            Activity13.RowCssClass = "row";

            // RemarkActivity13
            RemarkActivity13.RowCssClass = "row";

            // Activity14
            Activity14.RowCssClass = "row";

            // RemarkActivity14
            RemarkActivity14.RowCssClass = "row";

            // Activity14Attachment
            Activity14Attachment.RowCssClass = "row";

            // Activity20
            Activity20.RowCssClass = "row";

            // RemarkActivity20
            RemarkActivity20.RowCssClass = "row";

            // Activity20Attachment
            Activity20Attachment.RowCssClass = "row";

            // Activity30
            Activity30.RowCssClass = "row";

            // RemarkActivity30
            RemarkActivity30.RowCssClass = "row";

            // Activity30Attachment
            Activity30Attachment.RowCssClass = "row";

            // Activity40
            Activity40.RowCssClass = "row";

            // RemarkActivity40
            RemarkActivity40.RowCssClass = "row";

            // Activity50
            Activity50.RowCssClass = "row";

            // RemarkActivity50
            RemarkActivity50.RowCssClass = "row";

            // Activity50Attachment
            Activity50Attachment.RowCssClass = "row";

            // Activity60
            Activity60.RowCssClass = "row";

            // RemarkActivity60
            RemarkActivity60.RowCssClass = "row";

            // Activity70
            Activity70.RowCssClass = "row";

            // RemarkActivity70
            RemarkActivity70.RowCssClass = "row";

            // Activity70Attachment
            Activity70Attachment.RowCssClass = "row";

            // InterviewerComment
            InterviewerComment.RowCssClass = "row";

            // InterviewDate
            InterviewDate.RowCssClass = "row";

            // InterviewAttachment
            InterviewAttachment.RowCssClass = "row";

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.RowCssClass = "row";

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.RowCssClass = "row";

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.RowCssClass = "row";

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.RowCssClass = "row";

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.RowCssClass = "row";

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.RowCssClass = "row";

            // FinalInterviewComment
            FinalInterviewComment.RowCssClass = "row";

            // FinalInterviewAttachment
            FinalInterviewAttachment.RowCssClass = "row";

            // JobKnowledge
            JobKnowledge.RowCssClass = "row";

            // SafetyAwareness
            SafetyAwareness.RowCssClass = "row";

            // Personality
            Personality.RowCssClass = "row";

            // EnglishProficiency
            EnglishProficiency.RowCssClass = "row";

            // PrincipalComment
            PrincipalComment.RowCssClass = "row";

            // PrincipalCommentAttachment
            PrincipalCommentAttachment.RowCssClass = "row";

            // AssistantManagerPdeReviewed
            AssistantManagerPdeReviewed.RowCssClass = "row";

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.RowCssClass = "row";

            // CrewingManagerApproval
            CrewingManagerApproval.RowCssClass = "row";

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.RowCssClass = "row";

            // FormPrintoutAttachment
            FormPrintoutAttachment.RowCssClass = "row";

            // CreatedBy
            CreatedBy.RowCssClass = "row";

            // CreatedDateTime
            CreatedDateTime.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // LastUpdatedDateTime
            LastUpdatedDateTime.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // MTCrewID
                MTCrewID.ViewValue = MTCrewID.CurrentValue;
                MTCrewID.ViewValue = FormatNumber(MTCrewID.ViewValue, MTCrewID.FormatPattern);
                MTCrewID.ViewCustomAttributes = "";

                // EmployeeStatus
                EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
                EmployeeStatus.ViewCustomAttributes = "";

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

                // Activity10
                if (ConvertToBool(Activity10.CurrentValue)) {
                    Activity10.ViewValue = Activity10.TagCaption(1) != "" ? Activity10.TagCaption(1) : "Yes";
                } else {
                    Activity10.ViewValue = Activity10.TagCaption(2) != "" ? Activity10.TagCaption(2) : "No";
                }
                Activity10.ViewCustomAttributes = "";

                // RemarkActivity10
                RemarkActivity10.ViewValue = RemarkActivity10.CurrentValue;
                RemarkActivity10.ViewCustomAttributes = "";

                // Activity11
                if (ConvertToBool(Activity11.CurrentValue)) {
                    Activity11.ViewValue = Activity11.TagCaption(1) != "" ? Activity11.TagCaption(1) : "Yes";
                } else {
                    Activity11.ViewValue = Activity11.TagCaption(2) != "" ? Activity11.TagCaption(2) : "No";
                }
                Activity11.ViewCustomAttributes = "";

                // RemarkActivity11
                RemarkActivity11.ViewValue = RemarkActivity11.CurrentValue;
                RemarkActivity11.ViewCustomAttributes = "";

                // Activity12
                if (ConvertToBool(Activity12.CurrentValue)) {
                    Activity12.ViewValue = Activity12.TagCaption(1) != "" ? Activity12.TagCaption(1) : "Yes";
                } else {
                    Activity12.ViewValue = Activity12.TagCaption(2) != "" ? Activity12.TagCaption(2) : "No";
                }
                Activity12.ViewCustomAttributes = "";

                // RemarkActivity12
                RemarkActivity12.ViewValue = RemarkActivity12.CurrentValue;
                RemarkActivity12.ViewCustomAttributes = "";

                // Activity13
                if (ConvertToBool(Activity13.CurrentValue)) {
                    Activity13.ViewValue = Activity13.TagCaption(1) != "" ? Activity13.TagCaption(1) : "Yes";
                } else {
                    Activity13.ViewValue = Activity13.TagCaption(2) != "" ? Activity13.TagCaption(2) : "No";
                }
                Activity13.ViewCustomAttributes = "";

                // RemarkActivity13
                RemarkActivity13.ViewValue = RemarkActivity13.CurrentValue;
                RemarkActivity13.ViewCustomAttributes = "";

                // Activity14
                if (ConvertToBool(Activity14.CurrentValue)) {
                    Activity14.ViewValue = Activity14.TagCaption(1) != "" ? Activity14.TagCaption(1) : "Yes";
                } else {
                    Activity14.ViewValue = Activity14.TagCaption(2) != "" ? Activity14.TagCaption(2) : "No";
                }
                Activity14.ViewCustomAttributes = "";

                // RemarkActivity14
                RemarkActivity14.ViewValue = RemarkActivity14.CurrentValue;
                RemarkActivity14.ViewCustomAttributes = "";

                // Activity14Attachment
                Activity14Attachment.ViewValue = ConvertToString(Activity14Attachment.CurrentValue); // DN
                Activity14Attachment.ViewCustomAttributes = "";

                // Activity20
                if (ConvertToBool(Activity20.CurrentValue)) {
                    Activity20.ViewValue = Activity20.TagCaption(1) != "" ? Activity20.TagCaption(1) : "Yes";
                } else {
                    Activity20.ViewValue = Activity20.TagCaption(2) != "" ? Activity20.TagCaption(2) : "No";
                }
                Activity20.ViewCustomAttributes = "";

                // RemarkActivity20
                RemarkActivity20.ViewValue = RemarkActivity20.CurrentValue;
                RemarkActivity20.ViewCustomAttributes = "";

                // Activity20Attachment
                Activity20Attachment.ViewValue = ConvertToString(Activity20Attachment.CurrentValue); // DN
                Activity20Attachment.ViewCustomAttributes = "";

                // Activity30
                if (ConvertToBool(Activity30.CurrentValue)) {
                    Activity30.ViewValue = Activity30.TagCaption(1) != "" ? Activity30.TagCaption(1) : "Yes";
                } else {
                    Activity30.ViewValue = Activity30.TagCaption(2) != "" ? Activity30.TagCaption(2) : "No";
                }
                Activity30.ViewCustomAttributes = "";

                // RemarkActivity30
                RemarkActivity30.ViewValue = RemarkActivity30.CurrentValue;
                RemarkActivity30.ViewCustomAttributes = "";

                // Activity30Attachment
                Activity30Attachment.ViewValue = ConvertToString(Activity30Attachment.CurrentValue); // DN
                Activity30Attachment.ViewCustomAttributes = "";

                // Activity40
                if (ConvertToBool(Activity40.CurrentValue)) {
                    Activity40.ViewValue = Activity40.TagCaption(1) != "" ? Activity40.TagCaption(1) : "Yes";
                } else {
                    Activity40.ViewValue = Activity40.TagCaption(2) != "" ? Activity40.TagCaption(2) : "No";
                }
                Activity40.ViewCustomAttributes = "";

                // RemarkActivity40
                RemarkActivity40.ViewValue = RemarkActivity40.CurrentValue;
                RemarkActivity40.ViewCustomAttributes = "";

                // Activity50
                if (ConvertToBool(Activity50.CurrentValue)) {
                    Activity50.ViewValue = Activity50.TagCaption(1) != "" ? Activity50.TagCaption(1) : "Yes";
                } else {
                    Activity50.ViewValue = Activity50.TagCaption(2) != "" ? Activity50.TagCaption(2) : "No";
                }
                Activity50.ViewCustomAttributes = "";

                // RemarkActivity50
                RemarkActivity50.ViewValue = RemarkActivity50.CurrentValue;
                RemarkActivity50.ViewCustomAttributes = "";

                // Activity50Attachment
                Activity50Attachment.ViewValue = ConvertToString(Activity50Attachment.CurrentValue); // DN
                Activity50Attachment.ViewCustomAttributes = "";

                // Activity60
                if (ConvertToBool(Activity60.CurrentValue)) {
                    Activity60.ViewValue = Activity60.TagCaption(1) != "" ? Activity60.TagCaption(1) : "Yes";
                } else {
                    Activity60.ViewValue = Activity60.TagCaption(2) != "" ? Activity60.TagCaption(2) : "No";
                }
                Activity60.ViewCustomAttributes = "";

                // RemarkActivity60
                RemarkActivity60.ViewValue = RemarkActivity60.CurrentValue;
                RemarkActivity60.ViewCustomAttributes = "";

                // Activity70
                if (ConvertToBool(Activity70.CurrentValue)) {
                    Activity70.ViewValue = Activity70.TagCaption(1) != "" ? Activity70.TagCaption(1) : "Yes";
                } else {
                    Activity70.ViewValue = Activity70.TagCaption(2) != "" ? Activity70.TagCaption(2) : "No";
                }
                Activity70.ViewCustomAttributes = "";

                // RemarkActivity70
                RemarkActivity70.ViewValue = RemarkActivity70.CurrentValue;
                RemarkActivity70.ViewCustomAttributes = "";

                // Activity70Attachment
                Activity70Attachment.ViewValue = ConvertToString(Activity70Attachment.CurrentValue); // DN
                Activity70Attachment.ViewCustomAttributes = "";

                // InterviewerComment
                InterviewerComment.ViewValue = ConvertToString(InterviewerComment.CurrentValue); // DN
                InterviewerComment.ViewCustomAttributes = "";

                // InterviewDate
                InterviewDate.ViewValue = InterviewDate.CurrentValue;
                InterviewDate.ViewValue = FormatDateTime(InterviewDate.ViewValue, InterviewDate.FormatPattern);
                InterviewDate.ViewCustomAttributes = "";

                // InterviewAttachment
                InterviewAttachment.ViewValue = ConvertToString(InterviewAttachment.CurrentValue); // DN
                InterviewAttachment.ViewCustomAttributes = "";

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.ViewValue = ConvertToString(InterviewedByPersonOneName.CurrentValue); // DN
                InterviewedByPersonOneName.ViewCustomAttributes = "";

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.ViewValue = ConvertToString(InterviewedByPersonOneRank.CurrentValue); // DN
                InterviewedByPersonOneRank.ViewCustomAttributes = "";

                // InterviewedByPersonTwoName
                InterviewedByPersonTwoName.ViewValue = ConvertToString(InterviewedByPersonTwoName.CurrentValue); // DN
                InterviewedByPersonTwoName.ViewCustomAttributes = "";

                // InterviewedByPersonTwoRank
                InterviewedByPersonTwoRank.ViewValue = ConvertToString(InterviewedByPersonTwoRank.CurrentValue); // DN
                InterviewedByPersonTwoRank.ViewCustomAttributes = "";

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.ViewValue = ConvertToString(InterviewedByPersonThreeName.CurrentValue); // DN
                InterviewedByPersonThreeName.ViewCustomAttributes = "";

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.ViewValue = ConvertToString(InterviewedByPersonThreeRank.CurrentValue); // DN
                InterviewedByPersonThreeRank.ViewCustomAttributes = "";

                // FinalInterviewComment
                FinalInterviewComment.ViewValue = ConvertToString(FinalInterviewComment.CurrentValue); // DN
                FinalInterviewComment.ViewCustomAttributes = "";

                // FinalInterviewAttachment
                FinalInterviewAttachment.ViewValue = ConvertToString(FinalInterviewAttachment.CurrentValue); // DN
                FinalInterviewAttachment.ViewCustomAttributes = "";

                // JobKnowledge
                JobKnowledge.ViewValue = ConvertToString(JobKnowledge.CurrentValue); // DN
                JobKnowledge.ViewCustomAttributes = "";

                // SafetyAwareness
                SafetyAwareness.ViewValue = ConvertToString(SafetyAwareness.CurrentValue); // DN
                SafetyAwareness.ViewCustomAttributes = "";

                // Personality
                Personality.ViewValue = ConvertToString(Personality.CurrentValue); // DN
                Personality.ViewCustomAttributes = "";

                // EnglishProficiency
                EnglishProficiency.ViewValue = ConvertToString(EnglishProficiency.CurrentValue); // DN
                EnglishProficiency.ViewCustomAttributes = "";

                // PrincipalComment
                PrincipalComment.ViewValue = ConvertToString(PrincipalComment.CurrentValue); // DN
                PrincipalComment.ViewCustomAttributes = "";

                // PrincipalCommentAttachment
                PrincipalCommentAttachment.ViewValue = ConvertToString(PrincipalCommentAttachment.CurrentValue); // DN
                PrincipalCommentAttachment.ViewCustomAttributes = "";

                // AssistantManagerPdeReviewed
                if (ConvertToBool(AssistantManagerPdeReviewed.CurrentValue)) {
                    AssistantManagerPdeReviewed.ViewValue = AssistantManagerPdeReviewed.TagCaption(1) != "" ? AssistantManagerPdeReviewed.TagCaption(1) : "Yes";
                } else {
                    AssistantManagerPdeReviewed.ViewValue = AssistantManagerPdeReviewed.TagCaption(2) != "" ? AssistantManagerPdeReviewed.TagCaption(2) : "No";
                }
                AssistantManagerPdeReviewed.ViewCustomAttributes = "";

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.ViewValue = AssistantManagerPdeReviewedDate.CurrentValue;
                AssistantManagerPdeReviewedDate.ViewValue = FormatDateTime(AssistantManagerPdeReviewedDate.ViewValue, AssistantManagerPdeReviewedDate.FormatPattern);
                AssistantManagerPdeReviewedDate.ViewCustomAttributes = "";

                // CrewingManagerApproval
                if (ConvertToBool(CrewingManagerApproval.CurrentValue)) {
                    CrewingManagerApproval.ViewValue = CrewingManagerApproval.TagCaption(1) != "" ? CrewingManagerApproval.TagCaption(1) : "Yes";
                } else {
                    CrewingManagerApproval.ViewValue = CrewingManagerApproval.TagCaption(2) != "" ? CrewingManagerApproval.TagCaption(2) : "No";
                }
                CrewingManagerApproval.ViewCustomAttributes = "";

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.ViewValue = CrewingManagerApprovalDate.CurrentValue;
                CrewingManagerApprovalDate.ViewValue = FormatDateTime(CrewingManagerApprovalDate.ViewValue, CrewingManagerApprovalDate.FormatPattern);
                CrewingManagerApprovalDate.ViewCustomAttributes = "";

                // FormPrintoutAttachment
                FormPrintoutAttachment.ViewValue = ConvertToString(FormPrintoutAttachment.CurrentValue); // DN
                FormPrintoutAttachment.ViewCustomAttributes = "";

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

                // MTCrewID
                MTCrewID.HrefValue = "";

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

                // Activity10
                Activity10.HrefValue = "";

                // RemarkActivity10
                RemarkActivity10.HrefValue = "";

                // Activity11
                Activity11.HrefValue = "";

                // RemarkActivity11
                RemarkActivity11.HrefValue = "";

                // Activity12
                Activity12.HrefValue = "";

                // RemarkActivity12
                RemarkActivity12.HrefValue = "";

                // Activity13
                Activity13.HrefValue = "";

                // RemarkActivity13
                RemarkActivity13.HrefValue = "";

                // Activity14
                Activity14.HrefValue = "";

                // RemarkActivity14
                RemarkActivity14.HrefValue = "";

                // Activity14Attachment
                Activity14Attachment.HrefValue = "";

                // Activity20
                Activity20.HrefValue = "";

                // RemarkActivity20
                RemarkActivity20.HrefValue = "";

                // Activity20Attachment
                Activity20Attachment.HrefValue = "";

                // Activity30
                Activity30.HrefValue = "";

                // RemarkActivity30
                RemarkActivity30.HrefValue = "";

                // Activity30Attachment
                Activity30Attachment.HrefValue = "";

                // Activity40
                Activity40.HrefValue = "";

                // RemarkActivity40
                RemarkActivity40.HrefValue = "";

                // Activity50
                Activity50.HrefValue = "";

                // RemarkActivity50
                RemarkActivity50.HrefValue = "";

                // Activity50Attachment
                Activity50Attachment.HrefValue = "";

                // Activity60
                Activity60.HrefValue = "";

                // RemarkActivity60
                RemarkActivity60.HrefValue = "";

                // Activity70
                Activity70.HrefValue = "";

                // RemarkActivity70
                RemarkActivity70.HrefValue = "";

                // Activity70Attachment
                Activity70Attachment.HrefValue = "";

                // InterviewerComment
                InterviewerComment.HrefValue = "";

                // InterviewDate
                InterviewDate.HrefValue = "";

                // InterviewAttachment
                InterviewAttachment.HrefValue = "";

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.HrefValue = "";

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.HrefValue = "";

                // InterviewedByPersonTwoName
                InterviewedByPersonTwoName.HrefValue = "";

                // InterviewedByPersonTwoRank
                InterviewedByPersonTwoRank.HrefValue = "";

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.HrefValue = "";

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.HrefValue = "";

                // FinalInterviewComment
                FinalInterviewComment.HrefValue = "";

                // FinalInterviewAttachment
                FinalInterviewAttachment.HrefValue = "";

                // JobKnowledge
                JobKnowledge.HrefValue = "";

                // SafetyAwareness
                SafetyAwareness.HrefValue = "";

                // Personality
                Personality.HrefValue = "";

                // EnglishProficiency
                EnglishProficiency.HrefValue = "";

                // PrincipalComment
                PrincipalComment.HrefValue = "";

                // PrincipalCommentAttachment
                PrincipalCommentAttachment.HrefValue = "";

                // AssistantManagerPdeReviewed
                AssistantManagerPdeReviewed.HrefValue = "";

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.HrefValue = "";

                // CrewingManagerApproval
                CrewingManagerApproval.HrefValue = "";

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.HrefValue = "";

                // FormPrintoutAttachment
                FormPrintoutAttachment.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // MTCrewID
                MTCrewID.SetupEditAttributes();
                MTCrewID.EditValue = MTCrewID.CurrentValue; // DN
                MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);
                if (!Empty(MTCrewID.EditValue) && IsNumeric(MTCrewID.EditValue))
                    MTCrewID.EditValue = FormatNumber(MTCrewID.EditValue, null);

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

                // Activity10
                Activity10.EditValue = Activity10.Options(false);
                Activity10.PlaceHolder = RemoveHtml(Activity10.Caption);

                // RemarkActivity10
                RemarkActivity10.SetupEditAttributes();
                RemarkActivity10.EditValue = RemarkActivity10.CurrentValue; // DN
                RemarkActivity10.PlaceHolder = RemoveHtml(RemarkActivity10.Caption);

                // Activity11
                Activity11.EditValue = Activity11.Options(false);
                Activity11.PlaceHolder = RemoveHtml(Activity11.Caption);

                // RemarkActivity11
                RemarkActivity11.SetupEditAttributes();
                RemarkActivity11.EditValue = RemarkActivity11.CurrentValue; // DN
                RemarkActivity11.PlaceHolder = RemoveHtml(RemarkActivity11.Caption);

                // Activity12
                Activity12.EditValue = Activity12.Options(false);
                Activity12.PlaceHolder = RemoveHtml(Activity12.Caption);

                // RemarkActivity12
                RemarkActivity12.SetupEditAttributes();
                RemarkActivity12.EditValue = RemarkActivity12.CurrentValue; // DN
                RemarkActivity12.PlaceHolder = RemoveHtml(RemarkActivity12.Caption);

                // Activity13
                Activity13.EditValue = Activity13.Options(false);
                Activity13.PlaceHolder = RemoveHtml(Activity13.Caption);

                // RemarkActivity13
                RemarkActivity13.SetupEditAttributes();
                RemarkActivity13.EditValue = RemarkActivity13.CurrentValue; // DN
                RemarkActivity13.PlaceHolder = RemoveHtml(RemarkActivity13.Caption);

                // Activity14
                Activity14.EditValue = Activity14.Options(false);
                Activity14.PlaceHolder = RemoveHtml(Activity14.Caption);

                // RemarkActivity14
                RemarkActivity14.SetupEditAttributes();
                RemarkActivity14.EditValue = RemarkActivity14.CurrentValue; // DN
                RemarkActivity14.PlaceHolder = RemoveHtml(RemarkActivity14.Caption);

                // Activity14Attachment
                Activity14Attachment.SetupEditAttributes();
                if (!Activity14Attachment.Raw)
                    Activity14Attachment.CurrentValue = HtmlDecode(Activity14Attachment.CurrentValue);
                Activity14Attachment.EditValue = HtmlEncode(Activity14Attachment.CurrentValue);
                Activity14Attachment.PlaceHolder = RemoveHtml(Activity14Attachment.Caption);

                // Activity20
                Activity20.EditValue = Activity20.Options(false);
                Activity20.PlaceHolder = RemoveHtml(Activity20.Caption);

                // RemarkActivity20
                RemarkActivity20.SetupEditAttributes();
                RemarkActivity20.EditValue = RemarkActivity20.CurrentValue; // DN
                RemarkActivity20.PlaceHolder = RemoveHtml(RemarkActivity20.Caption);

                // Activity20Attachment
                Activity20Attachment.SetupEditAttributes();
                if (!Activity20Attachment.Raw)
                    Activity20Attachment.CurrentValue = HtmlDecode(Activity20Attachment.CurrentValue);
                Activity20Attachment.EditValue = HtmlEncode(Activity20Attachment.CurrentValue);
                Activity20Attachment.PlaceHolder = RemoveHtml(Activity20Attachment.Caption);

                // Activity30
                Activity30.EditValue = Activity30.Options(false);
                Activity30.PlaceHolder = RemoveHtml(Activity30.Caption);

                // RemarkActivity30
                RemarkActivity30.SetupEditAttributes();
                RemarkActivity30.EditValue = RemarkActivity30.CurrentValue; // DN
                RemarkActivity30.PlaceHolder = RemoveHtml(RemarkActivity30.Caption);

                // Activity30Attachment
                Activity30Attachment.SetupEditAttributes();
                if (!Activity30Attachment.Raw)
                    Activity30Attachment.CurrentValue = HtmlDecode(Activity30Attachment.CurrentValue);
                Activity30Attachment.EditValue = HtmlEncode(Activity30Attachment.CurrentValue);
                Activity30Attachment.PlaceHolder = RemoveHtml(Activity30Attachment.Caption);

                // Activity40
                Activity40.EditValue = Activity40.Options(false);
                Activity40.PlaceHolder = RemoveHtml(Activity40.Caption);

                // RemarkActivity40
                RemarkActivity40.SetupEditAttributes();
                RemarkActivity40.EditValue = RemarkActivity40.CurrentValue; // DN
                RemarkActivity40.PlaceHolder = RemoveHtml(RemarkActivity40.Caption);

                // Activity50
                Activity50.EditValue = Activity50.Options(false);
                Activity50.PlaceHolder = RemoveHtml(Activity50.Caption);

                // RemarkActivity50
                RemarkActivity50.SetupEditAttributes();
                RemarkActivity50.EditValue = RemarkActivity50.CurrentValue; // DN
                RemarkActivity50.PlaceHolder = RemoveHtml(RemarkActivity50.Caption);

                // Activity50Attachment
                Activity50Attachment.SetupEditAttributes();
                if (!Activity50Attachment.Raw)
                    Activity50Attachment.CurrentValue = HtmlDecode(Activity50Attachment.CurrentValue);
                Activity50Attachment.EditValue = HtmlEncode(Activity50Attachment.CurrentValue);
                Activity50Attachment.PlaceHolder = RemoveHtml(Activity50Attachment.Caption);

                // Activity60
                Activity60.EditValue = Activity60.Options(false);
                Activity60.PlaceHolder = RemoveHtml(Activity60.Caption);

                // RemarkActivity60
                RemarkActivity60.SetupEditAttributes();
                RemarkActivity60.EditValue = RemarkActivity60.CurrentValue; // DN
                RemarkActivity60.PlaceHolder = RemoveHtml(RemarkActivity60.Caption);

                // Activity70
                Activity70.EditValue = Activity70.Options(false);
                Activity70.PlaceHolder = RemoveHtml(Activity70.Caption);

                // RemarkActivity70
                RemarkActivity70.SetupEditAttributes();
                RemarkActivity70.EditValue = RemarkActivity70.CurrentValue; // DN
                RemarkActivity70.PlaceHolder = RemoveHtml(RemarkActivity70.Caption);

                // Activity70Attachment
                Activity70Attachment.SetupEditAttributes();
                if (!Activity70Attachment.Raw)
                    Activity70Attachment.CurrentValue = HtmlDecode(Activity70Attachment.CurrentValue);
                Activity70Attachment.EditValue = HtmlEncode(Activity70Attachment.CurrentValue);
                Activity70Attachment.PlaceHolder = RemoveHtml(Activity70Attachment.Caption);

                // InterviewerComment
                InterviewerComment.SetupEditAttributes();
                if (!InterviewerComment.Raw)
                    InterviewerComment.CurrentValue = HtmlDecode(InterviewerComment.CurrentValue);
                InterviewerComment.EditValue = HtmlEncode(InterviewerComment.CurrentValue);
                InterviewerComment.PlaceHolder = RemoveHtml(InterviewerComment.Caption);

                // InterviewDate
                InterviewDate.SetupEditAttributes();
                InterviewDate.EditValue = FormatDateTime(InterviewDate.CurrentValue, InterviewDate.FormatPattern); // DN
                InterviewDate.PlaceHolder = RemoveHtml(InterviewDate.Caption);

                // InterviewAttachment
                InterviewAttachment.SetupEditAttributes();
                if (!InterviewAttachment.Raw)
                    InterviewAttachment.CurrentValue = HtmlDecode(InterviewAttachment.CurrentValue);
                InterviewAttachment.EditValue = HtmlEncode(InterviewAttachment.CurrentValue);
                InterviewAttachment.PlaceHolder = RemoveHtml(InterviewAttachment.Caption);

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.SetupEditAttributes();
                if (!InterviewedByPersonOneName.Raw)
                    InterviewedByPersonOneName.CurrentValue = HtmlDecode(InterviewedByPersonOneName.CurrentValue);
                InterviewedByPersonOneName.EditValue = HtmlEncode(InterviewedByPersonOneName.CurrentValue);
                InterviewedByPersonOneName.PlaceHolder = RemoveHtml(InterviewedByPersonOneName.Caption);

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.SetupEditAttributes();
                if (!InterviewedByPersonOneRank.Raw)
                    InterviewedByPersonOneRank.CurrentValue = HtmlDecode(InterviewedByPersonOneRank.CurrentValue);
                InterviewedByPersonOneRank.EditValue = HtmlEncode(InterviewedByPersonOneRank.CurrentValue);
                InterviewedByPersonOneRank.PlaceHolder = RemoveHtml(InterviewedByPersonOneRank.Caption);

                // InterviewedByPersonTwoName
                InterviewedByPersonTwoName.SetupEditAttributes();
                if (!InterviewedByPersonTwoName.Raw)
                    InterviewedByPersonTwoName.CurrentValue = HtmlDecode(InterviewedByPersonTwoName.CurrentValue);
                InterviewedByPersonTwoName.EditValue = HtmlEncode(InterviewedByPersonTwoName.CurrentValue);
                InterviewedByPersonTwoName.PlaceHolder = RemoveHtml(InterviewedByPersonTwoName.Caption);

                // InterviewedByPersonTwoRank
                InterviewedByPersonTwoRank.SetupEditAttributes();
                if (!InterviewedByPersonTwoRank.Raw)
                    InterviewedByPersonTwoRank.CurrentValue = HtmlDecode(InterviewedByPersonTwoRank.CurrentValue);
                InterviewedByPersonTwoRank.EditValue = HtmlEncode(InterviewedByPersonTwoRank.CurrentValue);
                InterviewedByPersonTwoRank.PlaceHolder = RemoveHtml(InterviewedByPersonTwoRank.Caption);

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.SetupEditAttributes();
                if (!InterviewedByPersonThreeName.Raw)
                    InterviewedByPersonThreeName.CurrentValue = HtmlDecode(InterviewedByPersonThreeName.CurrentValue);
                InterviewedByPersonThreeName.EditValue = HtmlEncode(InterviewedByPersonThreeName.CurrentValue);
                InterviewedByPersonThreeName.PlaceHolder = RemoveHtml(InterviewedByPersonThreeName.Caption);

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.SetupEditAttributes();
                if (!InterviewedByPersonThreeRank.Raw)
                    InterviewedByPersonThreeRank.CurrentValue = HtmlDecode(InterviewedByPersonThreeRank.CurrentValue);
                InterviewedByPersonThreeRank.EditValue = HtmlEncode(InterviewedByPersonThreeRank.CurrentValue);
                InterviewedByPersonThreeRank.PlaceHolder = RemoveHtml(InterviewedByPersonThreeRank.Caption);

                // FinalInterviewComment
                FinalInterviewComment.SetupEditAttributes();
                if (!FinalInterviewComment.Raw)
                    FinalInterviewComment.CurrentValue = HtmlDecode(FinalInterviewComment.CurrentValue);
                FinalInterviewComment.EditValue = HtmlEncode(FinalInterviewComment.CurrentValue);
                FinalInterviewComment.PlaceHolder = RemoveHtml(FinalInterviewComment.Caption);

                // FinalInterviewAttachment
                FinalInterviewAttachment.SetupEditAttributes();
                if (!FinalInterviewAttachment.Raw)
                    FinalInterviewAttachment.CurrentValue = HtmlDecode(FinalInterviewAttachment.CurrentValue);
                FinalInterviewAttachment.EditValue = HtmlEncode(FinalInterviewAttachment.CurrentValue);
                FinalInterviewAttachment.PlaceHolder = RemoveHtml(FinalInterviewAttachment.Caption);

                // JobKnowledge
                JobKnowledge.SetupEditAttributes();
                if (!JobKnowledge.Raw)
                    JobKnowledge.CurrentValue = HtmlDecode(JobKnowledge.CurrentValue);
                JobKnowledge.EditValue = HtmlEncode(JobKnowledge.CurrentValue);
                JobKnowledge.PlaceHolder = RemoveHtml(JobKnowledge.Caption);

                // SafetyAwareness
                SafetyAwareness.SetupEditAttributes();
                if (!SafetyAwareness.Raw)
                    SafetyAwareness.CurrentValue = HtmlDecode(SafetyAwareness.CurrentValue);
                SafetyAwareness.EditValue = HtmlEncode(SafetyAwareness.CurrentValue);
                SafetyAwareness.PlaceHolder = RemoveHtml(SafetyAwareness.Caption);

                // Personality
                Personality.SetupEditAttributes();
                if (!Personality.Raw)
                    Personality.CurrentValue = HtmlDecode(Personality.CurrentValue);
                Personality.EditValue = HtmlEncode(Personality.CurrentValue);
                Personality.PlaceHolder = RemoveHtml(Personality.Caption);

                // EnglishProficiency
                EnglishProficiency.SetupEditAttributes();
                if (!EnglishProficiency.Raw)
                    EnglishProficiency.CurrentValue = HtmlDecode(EnglishProficiency.CurrentValue);
                EnglishProficiency.EditValue = HtmlEncode(EnglishProficiency.CurrentValue);
                EnglishProficiency.PlaceHolder = RemoveHtml(EnglishProficiency.Caption);

                // PrincipalComment
                PrincipalComment.SetupEditAttributes();
                if (!PrincipalComment.Raw)
                    PrincipalComment.CurrentValue = HtmlDecode(PrincipalComment.CurrentValue);
                PrincipalComment.EditValue = HtmlEncode(PrincipalComment.CurrentValue);
                PrincipalComment.PlaceHolder = RemoveHtml(PrincipalComment.Caption);

                // PrincipalCommentAttachment
                PrincipalCommentAttachment.SetupEditAttributes();
                if (!PrincipalCommentAttachment.Raw)
                    PrincipalCommentAttachment.CurrentValue = HtmlDecode(PrincipalCommentAttachment.CurrentValue);
                PrincipalCommentAttachment.EditValue = HtmlEncode(PrincipalCommentAttachment.CurrentValue);
                PrincipalCommentAttachment.PlaceHolder = RemoveHtml(PrincipalCommentAttachment.Caption);

                // AssistantManagerPdeReviewed
                AssistantManagerPdeReviewed.EditValue = AssistantManagerPdeReviewed.Options(false);
                AssistantManagerPdeReviewed.PlaceHolder = RemoveHtml(AssistantManagerPdeReviewed.Caption);

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.SetupEditAttributes();
                AssistantManagerPdeReviewedDate.EditValue = FormatDateTime(AssistantManagerPdeReviewedDate.CurrentValue, AssistantManagerPdeReviewedDate.FormatPattern); // DN
                AssistantManagerPdeReviewedDate.PlaceHolder = RemoveHtml(AssistantManagerPdeReviewedDate.Caption);

                // CrewingManagerApproval
                CrewingManagerApproval.EditValue = CrewingManagerApproval.Options(false);
                CrewingManagerApproval.PlaceHolder = RemoveHtml(CrewingManagerApproval.Caption);

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.SetupEditAttributes();
                CrewingManagerApprovalDate.EditValue = FormatDateTime(CrewingManagerApprovalDate.CurrentValue, CrewingManagerApprovalDate.FormatPattern); // DN
                CrewingManagerApprovalDate.PlaceHolder = RemoveHtml(CrewingManagerApprovalDate.Caption);

                // FormPrintoutAttachment
                FormPrintoutAttachment.SetupEditAttributes();
                if (!FormPrintoutAttachment.Raw)
                    FormPrintoutAttachment.CurrentValue = HtmlDecode(FormPrintoutAttachment.CurrentValue);
                FormPrintoutAttachment.EditValue = HtmlEncode(FormPrintoutAttachment.CurrentValue);
                FormPrintoutAttachment.PlaceHolder = RemoveHtml(FormPrintoutAttachment.Caption);

                // Edit refer script

                // MTCrewID
                MTCrewID.HrefValue = "";

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

                // Activity10
                Activity10.HrefValue = "";

                // RemarkActivity10
                RemarkActivity10.HrefValue = "";

                // Activity11
                Activity11.HrefValue = "";

                // RemarkActivity11
                RemarkActivity11.HrefValue = "";

                // Activity12
                Activity12.HrefValue = "";

                // RemarkActivity12
                RemarkActivity12.HrefValue = "";

                // Activity13
                Activity13.HrefValue = "";

                // RemarkActivity13
                RemarkActivity13.HrefValue = "";

                // Activity14
                Activity14.HrefValue = "";

                // RemarkActivity14
                RemarkActivity14.HrefValue = "";

                // Activity14Attachment
                Activity14Attachment.HrefValue = "";

                // Activity20
                Activity20.HrefValue = "";

                // RemarkActivity20
                RemarkActivity20.HrefValue = "";

                // Activity20Attachment
                Activity20Attachment.HrefValue = "";

                // Activity30
                Activity30.HrefValue = "";

                // RemarkActivity30
                RemarkActivity30.HrefValue = "";

                // Activity30Attachment
                Activity30Attachment.HrefValue = "";

                // Activity40
                Activity40.HrefValue = "";

                // RemarkActivity40
                RemarkActivity40.HrefValue = "";

                // Activity50
                Activity50.HrefValue = "";

                // RemarkActivity50
                RemarkActivity50.HrefValue = "";

                // Activity50Attachment
                Activity50Attachment.HrefValue = "";

                // Activity60
                Activity60.HrefValue = "";

                // RemarkActivity60
                RemarkActivity60.HrefValue = "";

                // Activity70
                Activity70.HrefValue = "";

                // RemarkActivity70
                RemarkActivity70.HrefValue = "";

                // Activity70Attachment
                Activity70Attachment.HrefValue = "";

                // InterviewerComment
                InterviewerComment.HrefValue = "";

                // InterviewDate
                InterviewDate.HrefValue = "";

                // InterviewAttachment
                InterviewAttachment.HrefValue = "";

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.HrefValue = "";

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.HrefValue = "";

                // InterviewedByPersonTwoName
                InterviewedByPersonTwoName.HrefValue = "";

                // InterviewedByPersonTwoRank
                InterviewedByPersonTwoRank.HrefValue = "";

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.HrefValue = "";

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.HrefValue = "";

                // FinalInterviewComment
                FinalInterviewComment.HrefValue = "";

                // FinalInterviewAttachment
                FinalInterviewAttachment.HrefValue = "";

                // JobKnowledge
                JobKnowledge.HrefValue = "";

                // SafetyAwareness
                SafetyAwareness.HrefValue = "";

                // Personality
                Personality.HrefValue = "";

                // EnglishProficiency
                EnglishProficiency.HrefValue = "";

                // PrincipalComment
                PrincipalComment.HrefValue = "";

                // PrincipalCommentAttachment
                PrincipalCommentAttachment.HrefValue = "";

                // AssistantManagerPdeReviewed
                AssistantManagerPdeReviewed.HrefValue = "";

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.HrefValue = "";

                // CrewingManagerApproval
                CrewingManagerApproval.HrefValue = "";

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.HrefValue = "";

                // FormPrintoutAttachment
                FormPrintoutAttachment.HrefValue = "";
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
            if (MTCrewID.Required) {
                if (!MTCrewID.IsDetailKey && Empty(MTCrewID.FormValue)) {
                    MTCrewID.AddErrorMessage(ConvertToString(MTCrewID.RequiredErrorMessage).Replace("%s", MTCrewID.Caption));
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
            if (Activity10.Required) {
                if (Empty(Activity10.FormValue)) {
                    Activity10.AddErrorMessage(ConvertToString(Activity10.RequiredErrorMessage).Replace("%s", Activity10.Caption));
                }
            }
            if (RemarkActivity10.Required) {
                if (!RemarkActivity10.IsDetailKey && Empty(RemarkActivity10.FormValue)) {
                    RemarkActivity10.AddErrorMessage(ConvertToString(RemarkActivity10.RequiredErrorMessage).Replace("%s", RemarkActivity10.Caption));
                }
            }
            if (Activity11.Required) {
                if (Empty(Activity11.FormValue)) {
                    Activity11.AddErrorMessage(ConvertToString(Activity11.RequiredErrorMessage).Replace("%s", Activity11.Caption));
                }
            }
            if (RemarkActivity11.Required) {
                if (!RemarkActivity11.IsDetailKey && Empty(RemarkActivity11.FormValue)) {
                    RemarkActivity11.AddErrorMessage(ConvertToString(RemarkActivity11.RequiredErrorMessage).Replace("%s", RemarkActivity11.Caption));
                }
            }
            if (Activity12.Required) {
                if (Empty(Activity12.FormValue)) {
                    Activity12.AddErrorMessage(ConvertToString(Activity12.RequiredErrorMessage).Replace("%s", Activity12.Caption));
                }
            }
            if (RemarkActivity12.Required) {
                if (!RemarkActivity12.IsDetailKey && Empty(RemarkActivity12.FormValue)) {
                    RemarkActivity12.AddErrorMessage(ConvertToString(RemarkActivity12.RequiredErrorMessage).Replace("%s", RemarkActivity12.Caption));
                }
            }
            if (Activity13.Required) {
                if (Empty(Activity13.FormValue)) {
                    Activity13.AddErrorMessage(ConvertToString(Activity13.RequiredErrorMessage).Replace("%s", Activity13.Caption));
                }
            }
            if (RemarkActivity13.Required) {
                if (!RemarkActivity13.IsDetailKey && Empty(RemarkActivity13.FormValue)) {
                    RemarkActivity13.AddErrorMessage(ConvertToString(RemarkActivity13.RequiredErrorMessage).Replace("%s", RemarkActivity13.Caption));
                }
            }
            if (Activity14.Required) {
                if (Empty(Activity14.FormValue)) {
                    Activity14.AddErrorMessage(ConvertToString(Activity14.RequiredErrorMessage).Replace("%s", Activity14.Caption));
                }
            }
            if (RemarkActivity14.Required) {
                if (!RemarkActivity14.IsDetailKey && Empty(RemarkActivity14.FormValue)) {
                    RemarkActivity14.AddErrorMessage(ConvertToString(RemarkActivity14.RequiredErrorMessage).Replace("%s", RemarkActivity14.Caption));
                }
            }
            if (Activity14Attachment.Required) {
                if (!Activity14Attachment.IsDetailKey && Empty(Activity14Attachment.FormValue)) {
                    Activity14Attachment.AddErrorMessage(ConvertToString(Activity14Attachment.RequiredErrorMessage).Replace("%s", Activity14Attachment.Caption));
                }
            }
            if (Activity20.Required) {
                if (Empty(Activity20.FormValue)) {
                    Activity20.AddErrorMessage(ConvertToString(Activity20.RequiredErrorMessage).Replace("%s", Activity20.Caption));
                }
            }
            if (RemarkActivity20.Required) {
                if (!RemarkActivity20.IsDetailKey && Empty(RemarkActivity20.FormValue)) {
                    RemarkActivity20.AddErrorMessage(ConvertToString(RemarkActivity20.RequiredErrorMessage).Replace("%s", RemarkActivity20.Caption));
                }
            }
            if (Activity20Attachment.Required) {
                if (!Activity20Attachment.IsDetailKey && Empty(Activity20Attachment.FormValue)) {
                    Activity20Attachment.AddErrorMessage(ConvertToString(Activity20Attachment.RequiredErrorMessage).Replace("%s", Activity20Attachment.Caption));
                }
            }
            if (Activity30.Required) {
                if (Empty(Activity30.FormValue)) {
                    Activity30.AddErrorMessage(ConvertToString(Activity30.RequiredErrorMessage).Replace("%s", Activity30.Caption));
                }
            }
            if (RemarkActivity30.Required) {
                if (!RemarkActivity30.IsDetailKey && Empty(RemarkActivity30.FormValue)) {
                    RemarkActivity30.AddErrorMessage(ConvertToString(RemarkActivity30.RequiredErrorMessage).Replace("%s", RemarkActivity30.Caption));
                }
            }
            if (Activity30Attachment.Required) {
                if (!Activity30Attachment.IsDetailKey && Empty(Activity30Attachment.FormValue)) {
                    Activity30Attachment.AddErrorMessage(ConvertToString(Activity30Attachment.RequiredErrorMessage).Replace("%s", Activity30Attachment.Caption));
                }
            }
            if (Activity40.Required) {
                if (Empty(Activity40.FormValue)) {
                    Activity40.AddErrorMessage(ConvertToString(Activity40.RequiredErrorMessage).Replace("%s", Activity40.Caption));
                }
            }
            if (RemarkActivity40.Required) {
                if (!RemarkActivity40.IsDetailKey && Empty(RemarkActivity40.FormValue)) {
                    RemarkActivity40.AddErrorMessage(ConvertToString(RemarkActivity40.RequiredErrorMessage).Replace("%s", RemarkActivity40.Caption));
                }
            }
            if (Activity50.Required) {
                if (Empty(Activity50.FormValue)) {
                    Activity50.AddErrorMessage(ConvertToString(Activity50.RequiredErrorMessage).Replace("%s", Activity50.Caption));
                }
            }
            if (RemarkActivity50.Required) {
                if (!RemarkActivity50.IsDetailKey && Empty(RemarkActivity50.FormValue)) {
                    RemarkActivity50.AddErrorMessage(ConvertToString(RemarkActivity50.RequiredErrorMessage).Replace("%s", RemarkActivity50.Caption));
                }
            }
            if (Activity50Attachment.Required) {
                if (!Activity50Attachment.IsDetailKey && Empty(Activity50Attachment.FormValue)) {
                    Activity50Attachment.AddErrorMessage(ConvertToString(Activity50Attachment.RequiredErrorMessage).Replace("%s", Activity50Attachment.Caption));
                }
            }
            if (Activity60.Required) {
                if (Empty(Activity60.FormValue)) {
                    Activity60.AddErrorMessage(ConvertToString(Activity60.RequiredErrorMessage).Replace("%s", Activity60.Caption));
                }
            }
            if (RemarkActivity60.Required) {
                if (!RemarkActivity60.IsDetailKey && Empty(RemarkActivity60.FormValue)) {
                    RemarkActivity60.AddErrorMessage(ConvertToString(RemarkActivity60.RequiredErrorMessage).Replace("%s", RemarkActivity60.Caption));
                }
            }
            if (Activity70.Required) {
                if (Empty(Activity70.FormValue)) {
                    Activity70.AddErrorMessage(ConvertToString(Activity70.RequiredErrorMessage).Replace("%s", Activity70.Caption));
                }
            }
            if (RemarkActivity70.Required) {
                if (!RemarkActivity70.IsDetailKey && Empty(RemarkActivity70.FormValue)) {
                    RemarkActivity70.AddErrorMessage(ConvertToString(RemarkActivity70.RequiredErrorMessage).Replace("%s", RemarkActivity70.Caption));
                }
            }
            if (Activity70Attachment.Required) {
                if (!Activity70Attachment.IsDetailKey && Empty(Activity70Attachment.FormValue)) {
                    Activity70Attachment.AddErrorMessage(ConvertToString(Activity70Attachment.RequiredErrorMessage).Replace("%s", Activity70Attachment.Caption));
                }
            }
            if (InterviewerComment.Required) {
                if (!InterviewerComment.IsDetailKey && Empty(InterviewerComment.FormValue)) {
                    InterviewerComment.AddErrorMessage(ConvertToString(InterviewerComment.RequiredErrorMessage).Replace("%s", InterviewerComment.Caption));
                }
            }
            if (InterviewDate.Required) {
                if (!InterviewDate.IsDetailKey && Empty(InterviewDate.FormValue)) {
                    InterviewDate.AddErrorMessage(ConvertToString(InterviewDate.RequiredErrorMessage).Replace("%s", InterviewDate.Caption));
                }
            }
            if (!CheckDate(InterviewDate.FormValue, InterviewDate.FormatPattern)) {
                InterviewDate.AddErrorMessage(InterviewDate.GetErrorMessage(false));
            }
            if (InterviewAttachment.Required) {
                if (!InterviewAttachment.IsDetailKey && Empty(InterviewAttachment.FormValue)) {
                    InterviewAttachment.AddErrorMessage(ConvertToString(InterviewAttachment.RequiredErrorMessage).Replace("%s", InterviewAttachment.Caption));
                }
            }
            if (InterviewedByPersonOneName.Required) {
                if (!InterviewedByPersonOneName.IsDetailKey && Empty(InterviewedByPersonOneName.FormValue)) {
                    InterviewedByPersonOneName.AddErrorMessage(ConvertToString(InterviewedByPersonOneName.RequiredErrorMessage).Replace("%s", InterviewedByPersonOneName.Caption));
                }
            }
            if (InterviewedByPersonOneRank.Required) {
                if (!InterviewedByPersonOneRank.IsDetailKey && Empty(InterviewedByPersonOneRank.FormValue)) {
                    InterviewedByPersonOneRank.AddErrorMessage(ConvertToString(InterviewedByPersonOneRank.RequiredErrorMessage).Replace("%s", InterviewedByPersonOneRank.Caption));
                }
            }
            if (InterviewedByPersonTwoName.Required) {
                if (!InterviewedByPersonTwoName.IsDetailKey && Empty(InterviewedByPersonTwoName.FormValue)) {
                    InterviewedByPersonTwoName.AddErrorMessage(ConvertToString(InterviewedByPersonTwoName.RequiredErrorMessage).Replace("%s", InterviewedByPersonTwoName.Caption));
                }
            }
            if (InterviewedByPersonTwoRank.Required) {
                if (!InterviewedByPersonTwoRank.IsDetailKey && Empty(InterviewedByPersonTwoRank.FormValue)) {
                    InterviewedByPersonTwoRank.AddErrorMessage(ConvertToString(InterviewedByPersonTwoRank.RequiredErrorMessage).Replace("%s", InterviewedByPersonTwoRank.Caption));
                }
            }
            if (InterviewedByPersonThreeName.Required) {
                if (!InterviewedByPersonThreeName.IsDetailKey && Empty(InterviewedByPersonThreeName.FormValue)) {
                    InterviewedByPersonThreeName.AddErrorMessage(ConvertToString(InterviewedByPersonThreeName.RequiredErrorMessage).Replace("%s", InterviewedByPersonThreeName.Caption));
                }
            }
            if (InterviewedByPersonThreeRank.Required) {
                if (!InterviewedByPersonThreeRank.IsDetailKey && Empty(InterviewedByPersonThreeRank.FormValue)) {
                    InterviewedByPersonThreeRank.AddErrorMessage(ConvertToString(InterviewedByPersonThreeRank.RequiredErrorMessage).Replace("%s", InterviewedByPersonThreeRank.Caption));
                }
            }
            if (FinalInterviewComment.Required) {
                if (!FinalInterviewComment.IsDetailKey && Empty(FinalInterviewComment.FormValue)) {
                    FinalInterviewComment.AddErrorMessage(ConvertToString(FinalInterviewComment.RequiredErrorMessage).Replace("%s", FinalInterviewComment.Caption));
                }
            }
            if (FinalInterviewAttachment.Required) {
                if (!FinalInterviewAttachment.IsDetailKey && Empty(FinalInterviewAttachment.FormValue)) {
                    FinalInterviewAttachment.AddErrorMessage(ConvertToString(FinalInterviewAttachment.RequiredErrorMessage).Replace("%s", FinalInterviewAttachment.Caption));
                }
            }
            if (JobKnowledge.Required) {
                if (!JobKnowledge.IsDetailKey && Empty(JobKnowledge.FormValue)) {
                    JobKnowledge.AddErrorMessage(ConvertToString(JobKnowledge.RequiredErrorMessage).Replace("%s", JobKnowledge.Caption));
                }
            }
            if (SafetyAwareness.Required) {
                if (!SafetyAwareness.IsDetailKey && Empty(SafetyAwareness.FormValue)) {
                    SafetyAwareness.AddErrorMessage(ConvertToString(SafetyAwareness.RequiredErrorMessage).Replace("%s", SafetyAwareness.Caption));
                }
            }
            if (Personality.Required) {
                if (!Personality.IsDetailKey && Empty(Personality.FormValue)) {
                    Personality.AddErrorMessage(ConvertToString(Personality.RequiredErrorMessage).Replace("%s", Personality.Caption));
                }
            }
            if (EnglishProficiency.Required) {
                if (!EnglishProficiency.IsDetailKey && Empty(EnglishProficiency.FormValue)) {
                    EnglishProficiency.AddErrorMessage(ConvertToString(EnglishProficiency.RequiredErrorMessage).Replace("%s", EnglishProficiency.Caption));
                }
            }
            if (PrincipalComment.Required) {
                if (!PrincipalComment.IsDetailKey && Empty(PrincipalComment.FormValue)) {
                    PrincipalComment.AddErrorMessage(ConvertToString(PrincipalComment.RequiredErrorMessage).Replace("%s", PrincipalComment.Caption));
                }
            }
            if (PrincipalCommentAttachment.Required) {
                if (!PrincipalCommentAttachment.IsDetailKey && Empty(PrincipalCommentAttachment.FormValue)) {
                    PrincipalCommentAttachment.AddErrorMessage(ConvertToString(PrincipalCommentAttachment.RequiredErrorMessage).Replace("%s", PrincipalCommentAttachment.Caption));
                }
            }
            if (AssistantManagerPdeReviewed.Required) {
                if (Empty(AssistantManagerPdeReviewed.FormValue)) {
                    AssistantManagerPdeReviewed.AddErrorMessage(ConvertToString(AssistantManagerPdeReviewed.RequiredErrorMessage).Replace("%s", AssistantManagerPdeReviewed.Caption));
                }
            }
            if (AssistantManagerPdeReviewedDate.Required) {
                if (!AssistantManagerPdeReviewedDate.IsDetailKey && Empty(AssistantManagerPdeReviewedDate.FormValue)) {
                    AssistantManagerPdeReviewedDate.AddErrorMessage(ConvertToString(AssistantManagerPdeReviewedDate.RequiredErrorMessage).Replace("%s", AssistantManagerPdeReviewedDate.Caption));
                }
            }
            if (!CheckDate(AssistantManagerPdeReviewedDate.FormValue, AssistantManagerPdeReviewedDate.FormatPattern)) {
                AssistantManagerPdeReviewedDate.AddErrorMessage(AssistantManagerPdeReviewedDate.GetErrorMessage(false));
            }
            if (CrewingManagerApproval.Required) {
                if (Empty(CrewingManagerApproval.FormValue)) {
                    CrewingManagerApproval.AddErrorMessage(ConvertToString(CrewingManagerApproval.RequiredErrorMessage).Replace("%s", CrewingManagerApproval.Caption));
                }
            }
            if (CrewingManagerApprovalDate.Required) {
                if (!CrewingManagerApprovalDate.IsDetailKey && Empty(CrewingManagerApprovalDate.FormValue)) {
                    CrewingManagerApprovalDate.AddErrorMessage(ConvertToString(CrewingManagerApprovalDate.RequiredErrorMessage).Replace("%s", CrewingManagerApprovalDate.Caption));
                }
            }
            if (!CheckDate(CrewingManagerApprovalDate.FormValue, CrewingManagerApprovalDate.FormatPattern)) {
                CrewingManagerApprovalDate.AddErrorMessage(CrewingManagerApprovalDate.GetErrorMessage(false));
            }
            if (FormPrintoutAttachment.Required) {
                if (!FormPrintoutAttachment.IsDetailKey && Empty(FormPrintoutAttachment.FormValue)) {
                    FormPrintoutAttachment.AddErrorMessage(ConvertToString(FormPrintoutAttachment.RequiredErrorMessage).Replace("%s", FormPrintoutAttachment.Caption));
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

            // MTCrewID
            MTCrewID.SetDbValue(rsnew, MTCrewID.CurrentValue, MTCrewID.ReadOnly);

            // Activity10
            Activity10.SetDbValue(rsnew, ConvertToBool(Activity10.CurrentValue), Activity10.ReadOnly);

            // RemarkActivity10
            RemarkActivity10.SetDbValue(rsnew, RemarkActivity10.CurrentValue, RemarkActivity10.ReadOnly);

            // Activity11
            Activity11.SetDbValue(rsnew, ConvertToBool(Activity11.CurrentValue), Activity11.ReadOnly);

            // RemarkActivity11
            RemarkActivity11.SetDbValue(rsnew, RemarkActivity11.CurrentValue, RemarkActivity11.ReadOnly);

            // Activity12
            Activity12.SetDbValue(rsnew, ConvertToBool(Activity12.CurrentValue), Activity12.ReadOnly);

            // RemarkActivity12
            RemarkActivity12.SetDbValue(rsnew, RemarkActivity12.CurrentValue, RemarkActivity12.ReadOnly);

            // Activity13
            Activity13.SetDbValue(rsnew, ConvertToBool(Activity13.CurrentValue), Activity13.ReadOnly);

            // RemarkActivity13
            RemarkActivity13.SetDbValue(rsnew, RemarkActivity13.CurrentValue, RemarkActivity13.ReadOnly);

            // Activity14
            Activity14.SetDbValue(rsnew, ConvertToBool(Activity14.CurrentValue), Activity14.ReadOnly);

            // RemarkActivity14
            RemarkActivity14.SetDbValue(rsnew, RemarkActivity14.CurrentValue, RemarkActivity14.ReadOnly);

            // Activity14Attachment
            Activity14Attachment.SetDbValue(rsnew, Activity14Attachment.CurrentValue, Activity14Attachment.ReadOnly);

            // Activity20
            Activity20.SetDbValue(rsnew, ConvertToBool(Activity20.CurrentValue), Activity20.ReadOnly);

            // RemarkActivity20
            RemarkActivity20.SetDbValue(rsnew, RemarkActivity20.CurrentValue, RemarkActivity20.ReadOnly);

            // Activity20Attachment
            Activity20Attachment.SetDbValue(rsnew, Activity20Attachment.CurrentValue, Activity20Attachment.ReadOnly);

            // Activity30
            Activity30.SetDbValue(rsnew, ConvertToBool(Activity30.CurrentValue), Activity30.ReadOnly);

            // RemarkActivity30
            RemarkActivity30.SetDbValue(rsnew, RemarkActivity30.CurrentValue, RemarkActivity30.ReadOnly);

            // Activity30Attachment
            Activity30Attachment.SetDbValue(rsnew, Activity30Attachment.CurrentValue, Activity30Attachment.ReadOnly);

            // Activity40
            Activity40.SetDbValue(rsnew, ConvertToBool(Activity40.CurrentValue), Activity40.ReadOnly);

            // RemarkActivity40
            RemarkActivity40.SetDbValue(rsnew, RemarkActivity40.CurrentValue, RemarkActivity40.ReadOnly);

            // Activity50
            Activity50.SetDbValue(rsnew, ConvertToBool(Activity50.CurrentValue), Activity50.ReadOnly);

            // RemarkActivity50
            RemarkActivity50.SetDbValue(rsnew, RemarkActivity50.CurrentValue, RemarkActivity50.ReadOnly);

            // Activity50Attachment
            Activity50Attachment.SetDbValue(rsnew, Activity50Attachment.CurrentValue, Activity50Attachment.ReadOnly);

            // Activity60
            Activity60.SetDbValue(rsnew, ConvertToBool(Activity60.CurrentValue), Activity60.ReadOnly);

            // RemarkActivity60
            RemarkActivity60.SetDbValue(rsnew, RemarkActivity60.CurrentValue, RemarkActivity60.ReadOnly);

            // Activity70
            Activity70.SetDbValue(rsnew, ConvertToBool(Activity70.CurrentValue), Activity70.ReadOnly);

            // RemarkActivity70
            RemarkActivity70.SetDbValue(rsnew, RemarkActivity70.CurrentValue, RemarkActivity70.ReadOnly);

            // Activity70Attachment
            Activity70Attachment.SetDbValue(rsnew, Activity70Attachment.CurrentValue, Activity70Attachment.ReadOnly);

            // InterviewerComment
            InterviewerComment.SetDbValue(rsnew, InterviewerComment.CurrentValue, InterviewerComment.ReadOnly);

            // InterviewDate
            InterviewDate.SetDbValue(rsnew, ConvertToDateTime(InterviewDate.CurrentValue, InterviewDate.FormatPattern), InterviewDate.ReadOnly);

            // InterviewAttachment
            InterviewAttachment.SetDbValue(rsnew, InterviewAttachment.CurrentValue, InterviewAttachment.ReadOnly);

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.SetDbValue(rsnew, InterviewedByPersonOneName.CurrentValue, InterviewedByPersonOneName.ReadOnly);

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.SetDbValue(rsnew, InterviewedByPersonOneRank.CurrentValue, InterviewedByPersonOneRank.ReadOnly);

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.SetDbValue(rsnew, InterviewedByPersonTwoName.CurrentValue, InterviewedByPersonTwoName.ReadOnly);

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.SetDbValue(rsnew, InterviewedByPersonTwoRank.CurrentValue, InterviewedByPersonTwoRank.ReadOnly);

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.SetDbValue(rsnew, InterviewedByPersonThreeName.CurrentValue, InterviewedByPersonThreeName.ReadOnly);

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.SetDbValue(rsnew, InterviewedByPersonThreeRank.CurrentValue, InterviewedByPersonThreeRank.ReadOnly);

            // FinalInterviewComment
            FinalInterviewComment.SetDbValue(rsnew, FinalInterviewComment.CurrentValue, FinalInterviewComment.ReadOnly);

            // FinalInterviewAttachment
            FinalInterviewAttachment.SetDbValue(rsnew, FinalInterviewAttachment.CurrentValue, FinalInterviewAttachment.ReadOnly);

            // JobKnowledge
            JobKnowledge.SetDbValue(rsnew, JobKnowledge.CurrentValue, JobKnowledge.ReadOnly);

            // SafetyAwareness
            SafetyAwareness.SetDbValue(rsnew, SafetyAwareness.CurrentValue, SafetyAwareness.ReadOnly);

            // Personality
            Personality.SetDbValue(rsnew, Personality.CurrentValue, Personality.ReadOnly);

            // EnglishProficiency
            EnglishProficiency.SetDbValue(rsnew, EnglishProficiency.CurrentValue, EnglishProficiency.ReadOnly);

            // PrincipalComment
            PrincipalComment.SetDbValue(rsnew, PrincipalComment.CurrentValue, PrincipalComment.ReadOnly);

            // PrincipalCommentAttachment
            PrincipalCommentAttachment.SetDbValue(rsnew, PrincipalCommentAttachment.CurrentValue, PrincipalCommentAttachment.ReadOnly);

            // AssistantManagerPdeReviewed
            AssistantManagerPdeReviewed.SetDbValue(rsnew, ConvertToBool(AssistantManagerPdeReviewed.CurrentValue), AssistantManagerPdeReviewed.ReadOnly);

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.SetDbValue(rsnew, ConvertToDateTime(AssistantManagerPdeReviewedDate.CurrentValue, AssistantManagerPdeReviewedDate.FormatPattern), AssistantManagerPdeReviewedDate.ReadOnly);

            // CrewingManagerApproval
            CrewingManagerApproval.SetDbValue(rsnew, ConvertToBool(CrewingManagerApproval.CurrentValue), CrewingManagerApproval.ReadOnly);

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.SetDbValue(rsnew, ConvertToDateTime(CrewingManagerApprovalDate.CurrentValue, CrewingManagerApprovalDate.FormatPattern), CrewingManagerApprovalDate.ReadOnly);

            // FormPrintoutAttachment
            FormPrintoutAttachment.SetDbValue(rsnew, FormPrintoutAttachment.CurrentValue, FormPrintoutAttachment.ReadOnly);

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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("ChecklistList")), "", TableVar, true);
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
