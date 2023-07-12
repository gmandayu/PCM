namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// trChecklistAdd
    /// </summary>
    public static TrChecklistAdd trChecklistAdd
    {
        get => HttpData.Get<TrChecklistAdd>("trChecklistAdd")!;
        set => HttpData["trChecklistAdd"] = value;
    }

    /// <summary>
    /// Page class for TRChecklist
    /// </summary>
    public class TrChecklistAdd : TrChecklistAddBase
    {
        // Constructor
        public TrChecklistAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public TrChecklistAdd() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            //Log("Page Load");
            MTCrewID.DisplayValueSeparator = " ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class TrChecklistAddBase : TrChecklist
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "TRChecklist";

        // Page object name
        public string PageObjName = "trChecklistAdd";

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
        public TrChecklistAddBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (trChecklist)
            if (trChecklist == null || trChecklist is TrChecklist)
                trChecklist = this;

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
        public string PageName => "TrChecklistAdd";

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
            MTCrewID.Visible = false;
            DocumentDate.SetVisibility();
            Activity10.SetVisibility();
            Activity11.SetVisibility();
            Activity12.SetVisibility();
            Activity13.SetVisibility();
            Activity14.SetVisibility();
            Activity20.SetVisibility();
            Activity30.SetVisibility();
            Activity40.SetVisibility();
            Activity50.SetVisibility();
            Activity60.SetVisibility();
            Activity70.SetVisibility();
            InterviewerComment.SetVisibility();
            FinalInterviewComment.SetVisibility();
            JobKnowledge.SetVisibility();
            SafetyAwareness.SetVisibility();
            Personality.SetVisibility();
            EnglishProficiency.SetVisibility();
            PrincipalComment.SetVisibility();
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            RemarkActivity10.SetVisibility();
            RemarkActivity11.SetVisibility();
            RemarkActivity12.SetVisibility();
            RemarkActivity13.SetVisibility();
            RemarkActivity14.SetVisibility();
            RemarkActivity20.SetVisibility();
            RemarkActivity30.SetVisibility();
            RemarkActivity40.SetVisibility();
            RemarkActivity50.SetVisibility();
            RemarkActivity60.SetVisibility();
            RemarkActivity70.SetVisibility();
            InterviewedByPersonOneName.SetVisibility();
            InterviewedByPersonOneRank.SetVisibility();
            InterviewedByPersonOneDate.SetVisibility();
            AssistantManagerPdeReviewedDate.SetVisibility();
            InterviewedByPersonTwoName.SetVisibility();
            InterviewedByPersonTwoRank.SetVisibility();
            InterviewedByPersonTwoDate.SetVisibility();
            InterviewedByPersonThreeName.SetVisibility();
            InterviewedByPersonThreeRank.SetVisibility();
            InterviewedByPersonThreeDate.SetVisibility();
            CrewingManagerApprovalDate.SetVisibility();
            Activity14Attachment.SetVisibility();
            Activity20Attachment.SetVisibility();
            Activity30Attachment.SetVisibility();
            Activity50Attachment.SetVisibility();
            Activity70Attachment.SetVisibility();
            InterviewedByPersonOneAttachment.SetVisibility();
            InterviewedByPersonTwoAttachment.SetVisibility();
            InterviewedByPersonThreeAttachment.SetVisibility();
            FinalInterviewAttachment.SetVisibility();
            PrincipalCommentAttachment.SetVisibility();
            FormPrintoutAttachment.SetVisibility();
            AssistantManagerPdeReviewed.SetVisibility();
            CrewingManagerApproval.SetVisibility();
            InterviewDate.SetVisibility();
            InterviewAttachment.SetVisibility();
            ApprovedByUserID1.SetVisibility();
            ApprovedByUserID2.SetVisibility();
        }

        // Constructor
        public TrChecklistAddBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "TrChecklistView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(JobKnowledge);
            await SetupLookupOptions(SafetyAwareness);
            await SetupLookupOptions(Personality);
            await SetupLookupOptions(EnglishProficiency);
            await SetupLookupOptions(AssistantManagerPdeReviewed);
            await SetupLookupOptions(CrewingManagerApproval);

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

            // Set up detail parameters
            SetupDetailParms();

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
                        return Terminate("TrChecklistList"); // No matching record, return to List page // DN
                    }

                    // Set up detail parameters
                    SetupDetailParms();
                    break;
                case "insert": // Add new record // DN
                    SendEmail = true; // Send email on add success
                    var res = await AddRow(rsold);
                    if (res) { // Add successful
                        if (Empty(SuccessMessage) && Post("addopt") != "1") // Skip success message for addopt (done in JavaScript)
                            SuccessMessage = Language.Phrase("AddSuccess"); // Set up success message
                        string returnUrl = "";
                        if (!Empty(CurrentDetailTable)) // Master/detail add
                            returnUrl = DetailUrl;
                        else
                            returnUrl = ReturnUrl;
                        if (GetPageName(returnUrl) == "TrChecklistList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "TrChecklistView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "TrChecklistList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "TrChecklistList"; // Return list page content
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

                        // Set up detail parameters
                        SetupDetailParms();
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
                trChecklistAdd?.PageRender();
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
            Activity14Attachment.Upload.Index = CurrentForm.Index;
            if (!await Activity14Attachment.Upload.UploadFile()) // DN
                End(Activity14Attachment.Upload.Message);
            Activity14Attachment.CurrentValue = Activity14Attachment.Upload.FileName;
            Activity20Attachment.Upload.Index = CurrentForm.Index;
            if (!await Activity20Attachment.Upload.UploadFile()) // DN
                End(Activity20Attachment.Upload.Message);
            Activity20Attachment.CurrentValue = Activity20Attachment.Upload.FileName;
            Activity30Attachment.Upload.Index = CurrentForm.Index;
            if (!await Activity30Attachment.Upload.UploadFile()) // DN
                End(Activity30Attachment.Upload.Message);
            Activity30Attachment.CurrentValue = Activity30Attachment.Upload.FileName;
            Activity50Attachment.Upload.Index = CurrentForm.Index;
            if (!await Activity50Attachment.Upload.UploadFile()) // DN
                End(Activity50Attachment.Upload.Message);
            Activity50Attachment.CurrentValue = Activity50Attachment.Upload.FileName;
            Activity70Attachment.Upload.Index = CurrentForm.Index;
            if (!await Activity70Attachment.Upload.UploadFile()) // DN
                End(Activity70Attachment.Upload.Message);
            Activity70Attachment.CurrentValue = Activity70Attachment.Upload.FileName;
            FinalInterviewAttachment.Upload.Index = CurrentForm.Index;
            if (!await FinalInterviewAttachment.Upload.UploadFile()) // DN
                End(FinalInterviewAttachment.Upload.Message);
            FinalInterviewAttachment.CurrentValue = FinalInterviewAttachment.Upload.FileName;
            PrincipalCommentAttachment.Upload.Index = CurrentForm.Index;
            if (!await PrincipalCommentAttachment.Upload.UploadFile()) // DN
                End(PrincipalCommentAttachment.Upload.Message);
            PrincipalCommentAttachment.CurrentValue = PrincipalCommentAttachment.Upload.FileName;
            FormPrintoutAttachment.Upload.Index = CurrentForm.Index;
            if (!await FormPrintoutAttachment.Upload.UploadFile()) // DN
                End(FormPrintoutAttachment.Upload.Message);
            FormPrintoutAttachment.CurrentValue = FormPrintoutAttachment.Upload.FileName;
            InterviewAttachment.Upload.Index = CurrentForm.Index;
            if (!await InterviewAttachment.Upload.UploadFile()) // DN
                End(InterviewAttachment.Upload.Message);
            InterviewAttachment.CurrentValue = InterviewAttachment.Upload.FileName;
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

            // Check field name 'DocumentDate' before field var 'x_DocumentDate'
            val = CurrentForm.HasValue("DocumentDate") ? CurrentForm.GetValue("DocumentDate") : CurrentForm.GetValue("x_DocumentDate");
            if (!DocumentDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DocumentDate") && !CurrentForm.HasValue("x_DocumentDate")) // DN
                    DocumentDate.Visible = false; // Disable update for API request
                else
                    DocumentDate.SetFormValue(val, true, validate);
                DocumentDate.CurrentValue = UnformatDateTime(DocumentDate.CurrentValue, DocumentDate.FormatPattern);
            }

            // Check field name 'Activity10' before field var 'x_Activity10'
            val = CurrentForm.HasValue("Activity10") ? CurrentForm.GetValue("Activity10") : CurrentForm.GetValue("x_Activity10");
            if (!Activity10.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity10") && !CurrentForm.HasValue("x_Activity10")) // DN
                    Activity10.Visible = false; // Disable update for API request
                else
                    Activity10.SetFormValue(val);
            }

            // Check field name 'Activity11' before field var 'x_Activity11'
            val = CurrentForm.HasValue("Activity11") ? CurrentForm.GetValue("Activity11") : CurrentForm.GetValue("x_Activity11");
            if (!Activity11.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity11") && !CurrentForm.HasValue("x_Activity11")) // DN
                    Activity11.Visible = false; // Disable update for API request
                else
                    Activity11.SetFormValue(val);
            }

            // Check field name 'Activity12' before field var 'x_Activity12'
            val = CurrentForm.HasValue("Activity12") ? CurrentForm.GetValue("Activity12") : CurrentForm.GetValue("x_Activity12");
            if (!Activity12.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity12") && !CurrentForm.HasValue("x_Activity12")) // DN
                    Activity12.Visible = false; // Disable update for API request
                else
                    Activity12.SetFormValue(val);
            }

            // Check field name 'Activity13' before field var 'x_Activity13'
            val = CurrentForm.HasValue("Activity13") ? CurrentForm.GetValue("Activity13") : CurrentForm.GetValue("x_Activity13");
            if (!Activity13.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity13") && !CurrentForm.HasValue("x_Activity13")) // DN
                    Activity13.Visible = false; // Disable update for API request
                else
                    Activity13.SetFormValue(val);
            }

            // Check field name 'Activity14' before field var 'x_Activity14'
            val = CurrentForm.HasValue("Activity14") ? CurrentForm.GetValue("Activity14") : CurrentForm.GetValue("x_Activity14");
            if (!Activity14.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity14") && !CurrentForm.HasValue("x_Activity14")) // DN
                    Activity14.Visible = false; // Disable update for API request
                else
                    Activity14.SetFormValue(val);
            }

            // Check field name 'Activity20' before field var 'x_Activity20'
            val = CurrentForm.HasValue("Activity20") ? CurrentForm.GetValue("Activity20") : CurrentForm.GetValue("x_Activity20");
            if (!Activity20.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity20") && !CurrentForm.HasValue("x_Activity20")) // DN
                    Activity20.Visible = false; // Disable update for API request
                else
                    Activity20.SetFormValue(val);
            }

            // Check field name 'Activity30' before field var 'x_Activity30'
            val = CurrentForm.HasValue("Activity30") ? CurrentForm.GetValue("Activity30") : CurrentForm.GetValue("x_Activity30");
            if (!Activity30.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity30") && !CurrentForm.HasValue("x_Activity30")) // DN
                    Activity30.Visible = false; // Disable update for API request
                else
                    Activity30.SetFormValue(val);
            }

            // Check field name 'Activity40' before field var 'x_Activity40'
            val = CurrentForm.HasValue("Activity40") ? CurrentForm.GetValue("Activity40") : CurrentForm.GetValue("x_Activity40");
            if (!Activity40.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity40") && !CurrentForm.HasValue("x_Activity40")) // DN
                    Activity40.Visible = false; // Disable update for API request
                else
                    Activity40.SetFormValue(val);
            }

            // Check field name 'Activity50' before field var 'x_Activity50'
            val = CurrentForm.HasValue("Activity50") ? CurrentForm.GetValue("Activity50") : CurrentForm.GetValue("x_Activity50");
            if (!Activity50.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity50") && !CurrentForm.HasValue("x_Activity50")) // DN
                    Activity50.Visible = false; // Disable update for API request
                else
                    Activity50.SetFormValue(val);
            }

            // Check field name 'Activity60' before field var 'x_Activity60'
            val = CurrentForm.HasValue("Activity60") ? CurrentForm.GetValue("Activity60") : CurrentForm.GetValue("x_Activity60");
            if (!Activity60.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity60") && !CurrentForm.HasValue("x_Activity60")) // DN
                    Activity60.Visible = false; // Disable update for API request
                else
                    Activity60.SetFormValue(val);
            }

            // Check field name 'Activity70' before field var 'x_Activity70'
            val = CurrentForm.HasValue("Activity70") ? CurrentForm.GetValue("Activity70") : CurrentForm.GetValue("x_Activity70");
            if (!Activity70.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Activity70") && !CurrentForm.HasValue("x_Activity70")) // DN
                    Activity70.Visible = false; // Disable update for API request
                else
                    Activity70.SetFormValue(val);
            }

            // Check field name 'InterviewerComment' before field var 'x_InterviewerComment'
            val = CurrentForm.HasValue("InterviewerComment") ? CurrentForm.GetValue("InterviewerComment") : CurrentForm.GetValue("x_InterviewerComment");
            if (!InterviewerComment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewerComment") && !CurrentForm.HasValue("x_InterviewerComment")) // DN
                    InterviewerComment.Visible = false; // Disable update for API request
                else
                    InterviewerComment.SetFormValue(val);
            }

            // Check field name 'FinalInterviewComment' before field var 'x_FinalInterviewComment'
            val = CurrentForm.HasValue("FinalInterviewComment") ? CurrentForm.GetValue("FinalInterviewComment") : CurrentForm.GetValue("x_FinalInterviewComment");
            if (!FinalInterviewComment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FinalInterviewComment") && !CurrentForm.HasValue("x_FinalInterviewComment")) // DN
                    FinalInterviewComment.Visible = false; // Disable update for API request
                else
                    FinalInterviewComment.SetFormValue(val);
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

            // Check field name 'RemarkActivity10' before field var 'x_RemarkActivity10'
            val = CurrentForm.HasValue("RemarkActivity10") ? CurrentForm.GetValue("RemarkActivity10") : CurrentForm.GetValue("x_RemarkActivity10");
            if (!RemarkActivity10.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity10") && !CurrentForm.HasValue("x_RemarkActivity10")) // DN
                    RemarkActivity10.Visible = false; // Disable update for API request
                else
                    RemarkActivity10.SetFormValue(val);
            }

            // Check field name 'RemarkActivity11' before field var 'x_RemarkActivity11'
            val = CurrentForm.HasValue("RemarkActivity11") ? CurrentForm.GetValue("RemarkActivity11") : CurrentForm.GetValue("x_RemarkActivity11");
            if (!RemarkActivity11.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity11") && !CurrentForm.HasValue("x_RemarkActivity11")) // DN
                    RemarkActivity11.Visible = false; // Disable update for API request
                else
                    RemarkActivity11.SetFormValue(val);
            }

            // Check field name 'RemarkActivity12' before field var 'x_RemarkActivity12'
            val = CurrentForm.HasValue("RemarkActivity12") ? CurrentForm.GetValue("RemarkActivity12") : CurrentForm.GetValue("x_RemarkActivity12");
            if (!RemarkActivity12.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity12") && !CurrentForm.HasValue("x_RemarkActivity12")) // DN
                    RemarkActivity12.Visible = false; // Disable update for API request
                else
                    RemarkActivity12.SetFormValue(val);
            }

            // Check field name 'RemarkActivity13' before field var 'x_RemarkActivity13'
            val = CurrentForm.HasValue("RemarkActivity13") ? CurrentForm.GetValue("RemarkActivity13") : CurrentForm.GetValue("x_RemarkActivity13");
            if (!RemarkActivity13.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity13") && !CurrentForm.HasValue("x_RemarkActivity13")) // DN
                    RemarkActivity13.Visible = false; // Disable update for API request
                else
                    RemarkActivity13.SetFormValue(val);
            }

            // Check field name 'RemarkActivity14' before field var 'x_RemarkActivity14'
            val = CurrentForm.HasValue("RemarkActivity14") ? CurrentForm.GetValue("RemarkActivity14") : CurrentForm.GetValue("x_RemarkActivity14");
            if (!RemarkActivity14.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity14") && !CurrentForm.HasValue("x_RemarkActivity14")) // DN
                    RemarkActivity14.Visible = false; // Disable update for API request
                else
                    RemarkActivity14.SetFormValue(val);
            }

            // Check field name 'RemarkActivity20' before field var 'x_RemarkActivity20'
            val = CurrentForm.HasValue("RemarkActivity20") ? CurrentForm.GetValue("RemarkActivity20") : CurrentForm.GetValue("x_RemarkActivity20");
            if (!RemarkActivity20.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity20") && !CurrentForm.HasValue("x_RemarkActivity20")) // DN
                    RemarkActivity20.Visible = false; // Disable update for API request
                else
                    RemarkActivity20.SetFormValue(val);
            }

            // Check field name 'RemarkActivity30' before field var 'x_RemarkActivity30'
            val = CurrentForm.HasValue("RemarkActivity30") ? CurrentForm.GetValue("RemarkActivity30") : CurrentForm.GetValue("x_RemarkActivity30");
            if (!RemarkActivity30.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity30") && !CurrentForm.HasValue("x_RemarkActivity30")) // DN
                    RemarkActivity30.Visible = false; // Disable update for API request
                else
                    RemarkActivity30.SetFormValue(val);
            }

            // Check field name 'RemarkActivity40' before field var 'x_RemarkActivity40'
            val = CurrentForm.HasValue("RemarkActivity40") ? CurrentForm.GetValue("RemarkActivity40") : CurrentForm.GetValue("x_RemarkActivity40");
            if (!RemarkActivity40.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity40") && !CurrentForm.HasValue("x_RemarkActivity40")) // DN
                    RemarkActivity40.Visible = false; // Disable update for API request
                else
                    RemarkActivity40.SetFormValue(val);
            }

            // Check field name 'RemarkActivity50' before field var 'x_RemarkActivity50'
            val = CurrentForm.HasValue("RemarkActivity50") ? CurrentForm.GetValue("RemarkActivity50") : CurrentForm.GetValue("x_RemarkActivity50");
            if (!RemarkActivity50.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity50") && !CurrentForm.HasValue("x_RemarkActivity50")) // DN
                    RemarkActivity50.Visible = false; // Disable update for API request
                else
                    RemarkActivity50.SetFormValue(val);
            }

            // Check field name 'RemarkActivity60' before field var 'x_RemarkActivity60'
            val = CurrentForm.HasValue("RemarkActivity60") ? CurrentForm.GetValue("RemarkActivity60") : CurrentForm.GetValue("x_RemarkActivity60");
            if (!RemarkActivity60.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity60") && !CurrentForm.HasValue("x_RemarkActivity60")) // DN
                    RemarkActivity60.Visible = false; // Disable update for API request
                else
                    RemarkActivity60.SetFormValue(val);
            }

            // Check field name 'RemarkActivity70' before field var 'x_RemarkActivity70'
            val = CurrentForm.HasValue("RemarkActivity70") ? CurrentForm.GetValue("RemarkActivity70") : CurrentForm.GetValue("x_RemarkActivity70");
            if (!RemarkActivity70.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RemarkActivity70") && !CurrentForm.HasValue("x_RemarkActivity70")) // DN
                    RemarkActivity70.Visible = false; // Disable update for API request
                else
                    RemarkActivity70.SetFormValue(val);
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

            // Check field name 'InterviewedByPersonOneDate' before field var 'x_InterviewedByPersonOneDate'
            val = CurrentForm.HasValue("InterviewedByPersonOneDate") ? CurrentForm.GetValue("InterviewedByPersonOneDate") : CurrentForm.GetValue("x_InterviewedByPersonOneDate");
            if (!InterviewedByPersonOneDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonOneDate") && !CurrentForm.HasValue("x_InterviewedByPersonOneDate")) // DN
                    InterviewedByPersonOneDate.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonOneDate.SetFormValue(val, true, validate);
                InterviewedByPersonOneDate.CurrentValue = UnformatDateTime(InterviewedByPersonOneDate.CurrentValue, InterviewedByPersonOneDate.FormatPattern);
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

            // Check field name 'InterviewedByPersonTwoDate' before field var 'x_InterviewedByPersonTwoDate'
            val = CurrentForm.HasValue("InterviewedByPersonTwoDate") ? CurrentForm.GetValue("InterviewedByPersonTwoDate") : CurrentForm.GetValue("x_InterviewedByPersonTwoDate");
            if (!InterviewedByPersonTwoDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonTwoDate") && !CurrentForm.HasValue("x_InterviewedByPersonTwoDate")) // DN
                    InterviewedByPersonTwoDate.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonTwoDate.SetFormValue(val, true, validate);
                InterviewedByPersonTwoDate.CurrentValue = UnformatDateTime(InterviewedByPersonTwoDate.CurrentValue, InterviewedByPersonTwoDate.FormatPattern);
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

            // Check field name 'InterviewedByPersonThreeDate' before field var 'x_InterviewedByPersonThreeDate'
            val = CurrentForm.HasValue("InterviewedByPersonThreeDate") ? CurrentForm.GetValue("InterviewedByPersonThreeDate") : CurrentForm.GetValue("x_InterviewedByPersonThreeDate");
            if (!InterviewedByPersonThreeDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonThreeDate") && !CurrentForm.HasValue("x_InterviewedByPersonThreeDate")) // DN
                    InterviewedByPersonThreeDate.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonThreeDate.SetFormValue(val, true, validate);
                InterviewedByPersonThreeDate.CurrentValue = UnformatDateTime(InterviewedByPersonThreeDate.CurrentValue, InterviewedByPersonThreeDate.FormatPattern);
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

            // Check field name 'InterviewedByPersonOneAttachment' before field var 'x_InterviewedByPersonOneAttachment'
            val = CurrentForm.HasValue("InterviewedByPersonOneAttachment") ? CurrentForm.GetValue("InterviewedByPersonOneAttachment") : CurrentForm.GetValue("x_InterviewedByPersonOneAttachment");
            if (!InterviewedByPersonOneAttachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonOneAttachment") && !CurrentForm.HasValue("x_InterviewedByPersonOneAttachment")) // DN
                    InterviewedByPersonOneAttachment.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonOneAttachment.SetFormValue(val);
            }

            // Check field name 'InterviewedByPersonTwoAttachment' before field var 'x_InterviewedByPersonTwoAttachment'
            val = CurrentForm.HasValue("InterviewedByPersonTwoAttachment") ? CurrentForm.GetValue("InterviewedByPersonTwoAttachment") : CurrentForm.GetValue("x_InterviewedByPersonTwoAttachment");
            if (!InterviewedByPersonTwoAttachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonTwoAttachment") && !CurrentForm.HasValue("x_InterviewedByPersonTwoAttachment")) // DN
                    InterviewedByPersonTwoAttachment.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonTwoAttachment.SetFormValue(val);
            }

            // Check field name 'InterviewedByPersonThreeAttachment' before field var 'x_InterviewedByPersonThreeAttachment'
            val = CurrentForm.HasValue("InterviewedByPersonThreeAttachment") ? CurrentForm.GetValue("InterviewedByPersonThreeAttachment") : CurrentForm.GetValue("x_InterviewedByPersonThreeAttachment");
            if (!InterviewedByPersonThreeAttachment.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InterviewedByPersonThreeAttachment") && !CurrentForm.HasValue("x_InterviewedByPersonThreeAttachment")) // DN
                    InterviewedByPersonThreeAttachment.Visible = false; // Disable update for API request
                else
                    InterviewedByPersonThreeAttachment.SetFormValue(val);
            }

            // Check field name 'AssistantManagerPdeReviewed' before field var 'x_AssistantManagerPdeReviewed'
            val = CurrentForm.HasValue("AssistantManagerPdeReviewed") ? CurrentForm.GetValue("AssistantManagerPdeReviewed") : CurrentForm.GetValue("x_AssistantManagerPdeReviewed");
            if (!AssistantManagerPdeReviewed.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AssistantManagerPdeReviewed") && !CurrentForm.HasValue("x_AssistantManagerPdeReviewed")) // DN
                    AssistantManagerPdeReviewed.Visible = false; // Disable update for API request
                else
                    AssistantManagerPdeReviewed.SetFormValue(val);
            }

            // Check field name 'CrewingManagerApproval' before field var 'x_CrewingManagerApproval'
            val = CurrentForm.HasValue("CrewingManagerApproval") ? CurrentForm.GetValue("CrewingManagerApproval") : CurrentForm.GetValue("x_CrewingManagerApproval");
            if (!CrewingManagerApproval.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CrewingManagerApproval") && !CurrentForm.HasValue("x_CrewingManagerApproval")) // DN
                    CrewingManagerApproval.Visible = false; // Disable update for API request
                else
                    CrewingManagerApproval.SetFormValue(val);
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

            // Check field name 'ApprovedByUserID1' before field var 'x_ApprovedByUserID1'
            val = CurrentForm.HasValue("ApprovedByUserID1") ? CurrentForm.GetValue("ApprovedByUserID1") : CurrentForm.GetValue("x_ApprovedByUserID1");
            if (!ApprovedByUserID1.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ApprovedByUserID1") && !CurrentForm.HasValue("x_ApprovedByUserID1")) // DN
                    ApprovedByUserID1.Visible = false; // Disable update for API request
                else
                    ApprovedByUserID1.SetFormValue(val, true, validate);
            }

            // Check field name 'ApprovedByUserID2' before field var 'x_ApprovedByUserID2'
            val = CurrentForm.HasValue("ApprovedByUserID2") ? CurrentForm.GetValue("ApprovedByUserID2") : CurrentForm.GetValue("x_ApprovedByUserID2");
            if (!ApprovedByUserID2.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ApprovedByUserID2") && !CurrentForm.HasValue("x_ApprovedByUserID2")) // DN
                    ApprovedByUserID2.Visible = false; // Disable update for API request
                else
                    ApprovedByUserID2.SetFormValue(val, true, validate);
            }

            // Check field name 'ID' before field var 'x_ID'
            val = CurrentForm.HasValue("ID") ? CurrentForm.GetValue("ID") : CurrentForm.GetValue("x_ID");
            await GetUploadFiles(); // Get upload files
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            DocumentDate.CurrentValue = DocumentDate.FormValue;
            DocumentDate.CurrentValue = UnformatDateTime(DocumentDate.CurrentValue, DocumentDate.FormatPattern);
            Activity10.CurrentValue = Activity10.FormValue;
            Activity11.CurrentValue = Activity11.FormValue;
            Activity12.CurrentValue = Activity12.FormValue;
            Activity13.CurrentValue = Activity13.FormValue;
            Activity14.CurrentValue = Activity14.FormValue;
            Activity20.CurrentValue = Activity20.FormValue;
            Activity30.CurrentValue = Activity30.FormValue;
            Activity40.CurrentValue = Activity40.FormValue;
            Activity50.CurrentValue = Activity50.FormValue;
            Activity60.CurrentValue = Activity60.FormValue;
            Activity70.CurrentValue = Activity70.FormValue;
            InterviewerComment.CurrentValue = InterviewerComment.FormValue;
            FinalInterviewComment.CurrentValue = FinalInterviewComment.FormValue;
            JobKnowledge.CurrentValue = JobKnowledge.FormValue;
            SafetyAwareness.CurrentValue = SafetyAwareness.FormValue;
            Personality.CurrentValue = Personality.FormValue;
            EnglishProficiency.CurrentValue = EnglishProficiency.FormValue;
            PrincipalComment.CurrentValue = PrincipalComment.FormValue;
            CreatedByUserID.CurrentValue = CreatedByUserID.FormValue;
            CreatedDateTime.CurrentValue = CreatedDateTime.FormValue;
            CreatedDateTime.CurrentValue = UnformatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern);
            LastUpdatedByUserID.CurrentValue = LastUpdatedByUserID.FormValue;
            LastUpdatedDateTime.CurrentValue = LastUpdatedDateTime.FormValue;
            LastUpdatedDateTime.CurrentValue = UnformatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern);
            RemarkActivity10.CurrentValue = RemarkActivity10.FormValue;
            RemarkActivity11.CurrentValue = RemarkActivity11.FormValue;
            RemarkActivity12.CurrentValue = RemarkActivity12.FormValue;
            RemarkActivity13.CurrentValue = RemarkActivity13.FormValue;
            RemarkActivity14.CurrentValue = RemarkActivity14.FormValue;
            RemarkActivity20.CurrentValue = RemarkActivity20.FormValue;
            RemarkActivity30.CurrentValue = RemarkActivity30.FormValue;
            RemarkActivity40.CurrentValue = RemarkActivity40.FormValue;
            RemarkActivity50.CurrentValue = RemarkActivity50.FormValue;
            RemarkActivity60.CurrentValue = RemarkActivity60.FormValue;
            RemarkActivity70.CurrentValue = RemarkActivity70.FormValue;
            InterviewedByPersonOneName.CurrentValue = InterviewedByPersonOneName.FormValue;
            InterviewedByPersonOneRank.CurrentValue = InterviewedByPersonOneRank.FormValue;
            InterviewedByPersonOneDate.CurrentValue = InterviewedByPersonOneDate.FormValue;
            InterviewedByPersonOneDate.CurrentValue = UnformatDateTime(InterviewedByPersonOneDate.CurrentValue, InterviewedByPersonOneDate.FormatPattern);
            AssistantManagerPdeReviewedDate.CurrentValue = AssistantManagerPdeReviewedDate.FormValue;
            AssistantManagerPdeReviewedDate.CurrentValue = UnformatDateTime(AssistantManagerPdeReviewedDate.CurrentValue, AssistantManagerPdeReviewedDate.FormatPattern);
            InterviewedByPersonTwoName.CurrentValue = InterviewedByPersonTwoName.FormValue;
            InterviewedByPersonTwoRank.CurrentValue = InterviewedByPersonTwoRank.FormValue;
            InterviewedByPersonTwoDate.CurrentValue = InterviewedByPersonTwoDate.FormValue;
            InterviewedByPersonTwoDate.CurrentValue = UnformatDateTime(InterviewedByPersonTwoDate.CurrentValue, InterviewedByPersonTwoDate.FormatPattern);
            InterviewedByPersonThreeName.CurrentValue = InterviewedByPersonThreeName.FormValue;
            InterviewedByPersonThreeRank.CurrentValue = InterviewedByPersonThreeRank.FormValue;
            InterviewedByPersonThreeDate.CurrentValue = InterviewedByPersonThreeDate.FormValue;
            InterviewedByPersonThreeDate.CurrentValue = UnformatDateTime(InterviewedByPersonThreeDate.CurrentValue, InterviewedByPersonThreeDate.FormatPattern);
            CrewingManagerApprovalDate.CurrentValue = CrewingManagerApprovalDate.FormValue;
            CrewingManagerApprovalDate.CurrentValue = UnformatDateTime(CrewingManagerApprovalDate.CurrentValue, CrewingManagerApprovalDate.FormatPattern);
            InterviewedByPersonOneAttachment.CurrentValue = InterviewedByPersonOneAttachment.FormValue;
            InterviewedByPersonTwoAttachment.CurrentValue = InterviewedByPersonTwoAttachment.FormValue;
            InterviewedByPersonThreeAttachment.CurrentValue = InterviewedByPersonThreeAttachment.FormValue;
            AssistantManagerPdeReviewed.CurrentValue = AssistantManagerPdeReviewed.FormValue;
            CrewingManagerApproval.CurrentValue = CrewingManagerApproval.FormValue;
            InterviewDate.CurrentValue = InterviewDate.FormValue;
            InterviewDate.CurrentValue = UnformatDateTime(InterviewDate.CurrentValue, InterviewDate.FormatPattern);
            ApprovedByUserID1.CurrentValue = ApprovedByUserID1.FormValue;
            ApprovedByUserID2.CurrentValue = ApprovedByUserID2.FormValue;
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
            DocumentDate.SetDbValue(row["DocumentDate"]);
            Activity10.SetDbValue((ConvertToBool(row["Activity10"]) ? "1" : "0"));
            Activity11.SetDbValue((ConvertToBool(row["Activity11"]) ? "1" : "0"));
            Activity12.SetDbValue((ConvertToBool(row["Activity12"]) ? "1" : "0"));
            Activity13.SetDbValue((ConvertToBool(row["Activity13"]) ? "1" : "0"));
            Activity14.SetDbValue((ConvertToBool(row["Activity14"]) ? "1" : "0"));
            Activity20.SetDbValue((ConvertToBool(row["Activity20"]) ? "1" : "0"));
            Activity30.SetDbValue((ConvertToBool(row["Activity30"]) ? "1" : "0"));
            Activity40.SetDbValue((ConvertToBool(row["Activity40"]) ? "1" : "0"));
            Activity50.SetDbValue((ConvertToBool(row["Activity50"]) ? "1" : "0"));
            Activity60.SetDbValue((ConvertToBool(row["Activity60"]) ? "1" : "0"));
            Activity70.SetDbValue((ConvertToBool(row["Activity70"]) ? "1" : "0"));
            InterviewerComment.SetDbValue(row["InterviewerComment"]);
            FinalInterviewComment.SetDbValue(row["FinalInterviewComment"]);
            JobKnowledge.SetDbValue(row["JobKnowledge"]);
            SafetyAwareness.SetDbValue(row["SafetyAwareness"]);
            Personality.SetDbValue(row["Personality"]);
            EnglishProficiency.SetDbValue(row["EnglishProficiency"]);
            PrincipalComment.SetDbValue(row["PrincipalComment"]);
            CreatedByUserID.SetDbValue(row["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(row["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
            RemarkActivity10.SetDbValue(row["RemarkActivity10"]);
            RemarkActivity11.SetDbValue(row["RemarkActivity11"]);
            RemarkActivity12.SetDbValue(row["RemarkActivity12"]);
            RemarkActivity13.SetDbValue(row["RemarkActivity13"]);
            RemarkActivity14.SetDbValue(row["RemarkActivity14"]);
            RemarkActivity20.SetDbValue(row["RemarkActivity20"]);
            RemarkActivity30.SetDbValue(row["RemarkActivity30"]);
            RemarkActivity40.SetDbValue(row["RemarkActivity40"]);
            RemarkActivity50.SetDbValue(row["RemarkActivity50"]);
            RemarkActivity60.SetDbValue(row["RemarkActivity60"]);
            RemarkActivity70.SetDbValue(row["RemarkActivity70"]);
            InterviewedByPersonOneName.SetDbValue(row["InterviewedByPersonOneName"]);
            InterviewedByPersonOneRank.SetDbValue(row["InterviewedByPersonOneRank"]);
            InterviewedByPersonOneDate.SetDbValue(row["InterviewedByPersonOneDate"]);
            AssistantManagerPdeReviewedDate.SetDbValue(row["AssistantManagerPdeReviewedDate"]);
            InterviewedByPersonTwoName.SetDbValue(row["InterviewedByPersonTwoName"]);
            InterviewedByPersonTwoRank.SetDbValue(row["InterviewedByPersonTwoRank"]);
            InterviewedByPersonTwoDate.SetDbValue(row["InterviewedByPersonTwoDate"]);
            InterviewedByPersonThreeName.SetDbValue(row["InterviewedByPersonThreeName"]);
            InterviewedByPersonThreeRank.SetDbValue(row["InterviewedByPersonThreeRank"]);
            InterviewedByPersonThreeDate.SetDbValue(row["InterviewedByPersonThreeDate"]);
            CrewingManagerApprovalDate.SetDbValue(row["CrewingManagerApprovalDate"]);
            Activity14Attachment.Upload.DbValue = row["Activity14Attachment"];
            Activity14Attachment.SetDbValue(Activity14Attachment.Upload.DbValue);
            Activity20Attachment.Upload.DbValue = row["Activity20Attachment"];
            Activity20Attachment.SetDbValue(Activity20Attachment.Upload.DbValue);
            Activity30Attachment.Upload.DbValue = row["Activity30Attachment"];
            Activity30Attachment.SetDbValue(Activity30Attachment.Upload.DbValue);
            Activity50Attachment.Upload.DbValue = row["Activity50Attachment"];
            Activity50Attachment.SetDbValue(Activity50Attachment.Upload.DbValue);
            Activity70Attachment.Upload.DbValue = row["Activity70Attachment"];
            Activity70Attachment.SetDbValue(Activity70Attachment.Upload.DbValue);
            InterviewedByPersonOneAttachment.SetDbValue(row["InterviewedByPersonOneAttachment"]);
            InterviewedByPersonTwoAttachment.SetDbValue(row["InterviewedByPersonTwoAttachment"]);
            InterviewedByPersonThreeAttachment.SetDbValue(row["InterviewedByPersonThreeAttachment"]);
            FinalInterviewAttachment.Upload.DbValue = row["FinalInterviewAttachment"];
            FinalInterviewAttachment.SetDbValue(FinalInterviewAttachment.Upload.DbValue);
            PrincipalCommentAttachment.Upload.DbValue = row["PrincipalCommentAttachment"];
            PrincipalCommentAttachment.SetDbValue(PrincipalCommentAttachment.Upload.DbValue);
            FormPrintoutAttachment.Upload.DbValue = row["FormPrintoutAttachment"];
            FormPrintoutAttachment.SetDbValue(FormPrintoutAttachment.Upload.DbValue);
            AssistantManagerPdeReviewed.SetDbValue((ConvertToBool(row["AssistantManagerPdeReviewed"]) ? "1" : "0"));
            CrewingManagerApproval.SetDbValue((ConvertToBool(row["CrewingManagerApproval"]) ? "1" : "0"));
            InterviewDate.SetDbValue(row["InterviewDate"]);
            InterviewAttachment.Upload.DbValue = row["InterviewAttachment"];
            InterviewAttachment.SetDbValue(InterviewAttachment.Upload.DbValue);
            ApprovedByUserID1.SetDbValue(row["ApprovedByUserID1"]);
            ApprovedByUserID2.SetDbValue(row["ApprovedByUserID2"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTCrewID", MTCrewID.DefaultValue ?? DbNullValue); // DN
            row.Add("DocumentDate", DocumentDate.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity10", Activity10.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity11", Activity11.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity12", Activity12.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity13", Activity13.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity14", Activity14.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity20", Activity20.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity30", Activity30.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity40", Activity40.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity50", Activity50.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity60", Activity60.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity70", Activity70.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewerComment", InterviewerComment.DefaultValue ?? DbNullValue); // DN
            row.Add("FinalInterviewComment", FinalInterviewComment.DefaultValue ?? DbNullValue); // DN
            row.Add("JobKnowledge", JobKnowledge.DefaultValue ?? DbNullValue); // DN
            row.Add("SafetyAwareness", SafetyAwareness.DefaultValue ?? DbNullValue); // DN
            row.Add("Personality", Personality.DefaultValue ?? DbNullValue); // DN
            row.Add("EnglishProficiency", EnglishProficiency.DefaultValue ?? DbNullValue); // DN
            row.Add("PrincipalComment", PrincipalComment.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedByUserID", CreatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity10", RemarkActivity10.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity11", RemarkActivity11.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity12", RemarkActivity12.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity13", RemarkActivity13.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity14", RemarkActivity14.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity20", RemarkActivity20.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity30", RemarkActivity30.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity40", RemarkActivity40.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity50", RemarkActivity50.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity60", RemarkActivity60.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity70", RemarkActivity70.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneName", InterviewedByPersonOneName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneRank", InterviewedByPersonOneRank.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneDate", InterviewedByPersonOneDate.DefaultValue ?? DbNullValue); // DN
            row.Add("AssistantManagerPdeReviewedDate", AssistantManagerPdeReviewedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoName", InterviewedByPersonTwoName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoRank", InterviewedByPersonTwoRank.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoDate", InterviewedByPersonTwoDate.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeName", InterviewedByPersonThreeName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeRank", InterviewedByPersonThreeRank.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeDate", InterviewedByPersonThreeDate.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewingManagerApprovalDate", CrewingManagerApprovalDate.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity14Attachment", Activity14Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity20Attachment", Activity20Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity30Attachment", Activity30Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity50Attachment", Activity50Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity70Attachment", Activity70Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneAttachment", InterviewedByPersonOneAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoAttachment", InterviewedByPersonTwoAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeAttachment", InterviewedByPersonThreeAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("FinalInterviewAttachment", FinalInterviewAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("PrincipalCommentAttachment", PrincipalCommentAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("FormPrintoutAttachment", FormPrintoutAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("AssistantManagerPdeReviewed", AssistantManagerPdeReviewed.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewingManagerApproval", CrewingManagerApproval.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewDate", InterviewDate.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewAttachment", InterviewAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("ApprovedByUserID1", ApprovedByUserID1.DefaultValue ?? DbNullValue); // DN
            row.Add("ApprovedByUserID2", ApprovedByUserID2.DefaultValue ?? DbNullValue); // DN
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

            // DocumentDate
            DocumentDate.RowCssClass = "row";

            // Activity10
            Activity10.RowCssClass = "row";

            // Activity11
            Activity11.RowCssClass = "row";

            // Activity12
            Activity12.RowCssClass = "row";

            // Activity13
            Activity13.RowCssClass = "row";

            // Activity14
            Activity14.RowCssClass = "row";

            // Activity20
            Activity20.RowCssClass = "row";

            // Activity30
            Activity30.RowCssClass = "row";

            // Activity40
            Activity40.RowCssClass = "row";

            // Activity50
            Activity50.RowCssClass = "row";

            // Activity60
            Activity60.RowCssClass = "row";

            // Activity70
            Activity70.RowCssClass = "row";

            // InterviewerComment
            InterviewerComment.RowCssClass = "row";

            // FinalInterviewComment
            FinalInterviewComment.RowCssClass = "row";

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

            // CreatedByUserID
            CreatedByUserID.RowCssClass = "row";

            // CreatedDateTime
            CreatedDateTime.RowCssClass = "row";

            // LastUpdatedByUserID
            LastUpdatedByUserID.RowCssClass = "row";

            // LastUpdatedDateTime
            LastUpdatedDateTime.RowCssClass = "row";

            // RemarkActivity10
            RemarkActivity10.RowCssClass = "row";

            // RemarkActivity11
            RemarkActivity11.RowCssClass = "row";

            // RemarkActivity12
            RemarkActivity12.RowCssClass = "row";

            // RemarkActivity13
            RemarkActivity13.RowCssClass = "row";

            // RemarkActivity14
            RemarkActivity14.RowCssClass = "row";

            // RemarkActivity20
            RemarkActivity20.RowCssClass = "row";

            // RemarkActivity30
            RemarkActivity30.RowCssClass = "row";

            // RemarkActivity40
            RemarkActivity40.RowCssClass = "row";

            // RemarkActivity50
            RemarkActivity50.RowCssClass = "row";

            // RemarkActivity60
            RemarkActivity60.RowCssClass = "row";

            // RemarkActivity70
            RemarkActivity70.RowCssClass = "row";

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.RowCssClass = "row";

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.RowCssClass = "row";

            // InterviewedByPersonOneDate
            InterviewedByPersonOneDate.RowCssClass = "row";

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.RowCssClass = "row";

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.RowCssClass = "row";

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.RowCssClass = "row";

            // InterviewedByPersonTwoDate
            InterviewedByPersonTwoDate.RowCssClass = "row";

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.RowCssClass = "row";

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.RowCssClass = "row";

            // InterviewedByPersonThreeDate
            InterviewedByPersonThreeDate.RowCssClass = "row";

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.RowCssClass = "row";

            // Activity14Attachment
            Activity14Attachment.RowCssClass = "row";

            // Activity20Attachment
            Activity20Attachment.RowCssClass = "row";

            // Activity30Attachment
            Activity30Attachment.RowCssClass = "row";

            // Activity50Attachment
            Activity50Attachment.RowCssClass = "row";

            // Activity70Attachment
            Activity70Attachment.RowCssClass = "row";

            // InterviewedByPersonOneAttachment
            InterviewedByPersonOneAttachment.RowCssClass = "row";

            // InterviewedByPersonTwoAttachment
            InterviewedByPersonTwoAttachment.RowCssClass = "row";

            // InterviewedByPersonThreeAttachment
            InterviewedByPersonThreeAttachment.RowCssClass = "row";

            // FinalInterviewAttachment
            FinalInterviewAttachment.RowCssClass = "row";

            // PrincipalCommentAttachment
            PrincipalCommentAttachment.RowCssClass = "row";

            // FormPrintoutAttachment
            FormPrintoutAttachment.RowCssClass = "row";

            // AssistantManagerPdeReviewed
            AssistantManagerPdeReviewed.RowCssClass = "row";

            // CrewingManagerApproval
            CrewingManagerApproval.RowCssClass = "row";

            // InterviewDate
            InterviewDate.RowCssClass = "row";

            // InterviewAttachment
            InterviewAttachment.RowCssClass = "row";

            // ApprovedByUserID1
            ApprovedByUserID1.RowCssClass = "row";

            // ApprovedByUserID2
            ApprovedByUserID2.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // MTCrewID
                MTCrewID.ViewValue = MTCrewID.CurrentValue;
                MTCrewID.ViewValue = FormatNumber(MTCrewID.ViewValue, MTCrewID.FormatPattern);
                MTCrewID.ViewCustomAttributes = "";

                // DocumentDate
                DocumentDate.ViewValue = DocumentDate.CurrentValue;
                DocumentDate.ViewValue = FormatDateTime(DocumentDate.ViewValue, DocumentDate.FormatPattern);
                DocumentDate.ViewCustomAttributes = "";

                // Activity10
                if (ConvertToBool(Activity10.CurrentValue)) {
                    Activity10.ViewValue = Activity10.TagCaption(1) != "" ? Activity10.TagCaption(1) : "Yes";
                } else {
                    Activity10.ViewValue = Activity10.TagCaption(2) != "" ? Activity10.TagCaption(2) : "No";
                }
                Activity10.ViewCustomAttributes = "";

                // Activity11
                if (ConvertToBool(Activity11.CurrentValue)) {
                    Activity11.ViewValue = Activity11.TagCaption(1) != "" ? Activity11.TagCaption(1) : "Yes";
                } else {
                    Activity11.ViewValue = Activity11.TagCaption(2) != "" ? Activity11.TagCaption(2) : "No";
                }
                Activity11.ViewCustomAttributes = "";

                // Activity12
                if (ConvertToBool(Activity12.CurrentValue)) {
                    Activity12.ViewValue = Activity12.TagCaption(1) != "" ? Activity12.TagCaption(1) : "Yes";
                } else {
                    Activity12.ViewValue = Activity12.TagCaption(2) != "" ? Activity12.TagCaption(2) : "No";
                }
                Activity12.ViewCustomAttributes = "";

                // Activity13
                if (ConvertToBool(Activity13.CurrentValue)) {
                    Activity13.ViewValue = Activity13.TagCaption(1) != "" ? Activity13.TagCaption(1) : "Yes";
                } else {
                    Activity13.ViewValue = Activity13.TagCaption(2) != "" ? Activity13.TagCaption(2) : "No";
                }
                Activity13.ViewCustomAttributes = "";

                // Activity14
                if (ConvertToBool(Activity14.CurrentValue)) {
                    Activity14.ViewValue = Activity14.TagCaption(1) != "" ? Activity14.TagCaption(1) : "Yes";
                } else {
                    Activity14.ViewValue = Activity14.TagCaption(2) != "" ? Activity14.TagCaption(2) : "No";
                }
                Activity14.ViewCustomAttributes = "";

                // Activity20
                if (ConvertToBool(Activity20.CurrentValue)) {
                    Activity20.ViewValue = Activity20.TagCaption(1) != "" ? Activity20.TagCaption(1) : "Yes";
                } else {
                    Activity20.ViewValue = Activity20.TagCaption(2) != "" ? Activity20.TagCaption(2) : "No";
                }
                Activity20.ViewCustomAttributes = "";

                // Activity30
                if (ConvertToBool(Activity30.CurrentValue)) {
                    Activity30.ViewValue = Activity30.TagCaption(1) != "" ? Activity30.TagCaption(1) : "Yes";
                } else {
                    Activity30.ViewValue = Activity30.TagCaption(2) != "" ? Activity30.TagCaption(2) : "No";
                }
                Activity30.ViewCustomAttributes = "";

                // Activity40
                if (ConvertToBool(Activity40.CurrentValue)) {
                    Activity40.ViewValue = Activity40.TagCaption(1) != "" ? Activity40.TagCaption(1) : "Yes";
                } else {
                    Activity40.ViewValue = Activity40.TagCaption(2) != "" ? Activity40.TagCaption(2) : "No";
                }
                Activity40.ViewCustomAttributes = "";

                // Activity50
                if (ConvertToBool(Activity50.CurrentValue)) {
                    Activity50.ViewValue = Activity50.TagCaption(1) != "" ? Activity50.TagCaption(1) : "Yes";
                } else {
                    Activity50.ViewValue = Activity50.TagCaption(2) != "" ? Activity50.TagCaption(2) : "No";
                }
                Activity50.ViewCustomAttributes = "";

                // Activity60
                if (ConvertToBool(Activity60.CurrentValue)) {
                    Activity60.ViewValue = Activity60.TagCaption(1) != "" ? Activity60.TagCaption(1) : "Yes";
                } else {
                    Activity60.ViewValue = Activity60.TagCaption(2) != "" ? Activity60.TagCaption(2) : "No";
                }
                Activity60.ViewCustomAttributes = "";

                // Activity70
                if (ConvertToBool(Activity70.CurrentValue)) {
                    Activity70.ViewValue = Activity70.TagCaption(1) != "" ? Activity70.TagCaption(1) : "Yes";
                } else {
                    Activity70.ViewValue = Activity70.TagCaption(2) != "" ? Activity70.TagCaption(2) : "No";
                }
                Activity70.ViewCustomAttributes = "";

                // InterviewerComment
                InterviewerComment.ViewValue = InterviewerComment.CurrentValue;
                InterviewerComment.ViewCustomAttributes = "";

                // FinalInterviewComment
                FinalInterviewComment.ViewValue = FinalInterviewComment.CurrentValue;
                FinalInterviewComment.ViewCustomAttributes = "";

                // JobKnowledge
                if (!Empty(JobKnowledge.CurrentValue)) {
                    JobKnowledge.ViewValue = JobKnowledge.HighlightLookup(ConvertToString(JobKnowledge.CurrentValue), JobKnowledge.OptionCaption(ConvertToString(JobKnowledge.CurrentValue)));
                } else {
                    JobKnowledge.ViewValue = DbNullValue;
                }
                JobKnowledge.ViewCustomAttributes = "";

                // SafetyAwareness
                if (!Empty(SafetyAwareness.CurrentValue)) {
                    SafetyAwareness.ViewValue = SafetyAwareness.HighlightLookup(ConvertToString(SafetyAwareness.CurrentValue), SafetyAwareness.OptionCaption(ConvertToString(SafetyAwareness.CurrentValue)));
                } else {
                    SafetyAwareness.ViewValue = DbNullValue;
                }
                SafetyAwareness.ViewCustomAttributes = "";

                // Personality
                if (!Empty(Personality.CurrentValue)) {
                    Personality.ViewValue = Personality.HighlightLookup(ConvertToString(Personality.CurrentValue), Personality.OptionCaption(ConvertToString(Personality.CurrentValue)));
                } else {
                    Personality.ViewValue = DbNullValue;
                }
                Personality.ViewCustomAttributes = "";

                // EnglishProficiency
                if (!Empty(EnglishProficiency.CurrentValue)) {
                    EnglishProficiency.ViewValue = EnglishProficiency.HighlightLookup(ConvertToString(EnglishProficiency.CurrentValue), EnglishProficiency.OptionCaption(ConvertToString(EnglishProficiency.CurrentValue)));
                } else {
                    EnglishProficiency.ViewValue = DbNullValue;
                }
                EnglishProficiency.ViewCustomAttributes = "";

                // PrincipalComment
                PrincipalComment.ViewValue = PrincipalComment.CurrentValue;
                PrincipalComment.ViewCustomAttributes = "";

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

                // RemarkActivity10
                RemarkActivity10.ViewValue = RemarkActivity10.CurrentValue;
                RemarkActivity10.ViewCustomAttributes = "";

                // RemarkActivity11
                RemarkActivity11.ViewValue = RemarkActivity11.CurrentValue;
                RemarkActivity11.ViewCustomAttributes = "";

                // RemarkActivity12
                RemarkActivity12.ViewValue = RemarkActivity12.CurrentValue;
                RemarkActivity12.ViewCustomAttributes = "";

                // RemarkActivity13
                RemarkActivity13.ViewValue = RemarkActivity13.CurrentValue;
                RemarkActivity13.ViewCustomAttributes = "";

                // RemarkActivity14
                RemarkActivity14.ViewValue = RemarkActivity14.CurrentValue;
                RemarkActivity14.ViewCustomAttributes = "";

                // RemarkActivity20
                RemarkActivity20.ViewValue = RemarkActivity20.CurrentValue;
                RemarkActivity20.ViewCustomAttributes = "";

                // RemarkActivity30
                RemarkActivity30.ViewValue = RemarkActivity30.CurrentValue;
                RemarkActivity30.ViewCustomAttributes = "";

                // RemarkActivity40
                RemarkActivity40.ViewValue = RemarkActivity40.CurrentValue;
                RemarkActivity40.ViewCustomAttributes = "";

                // RemarkActivity50
                RemarkActivity50.ViewValue = RemarkActivity50.CurrentValue;
                RemarkActivity50.ViewCustomAttributes = "";

                // RemarkActivity60
                RemarkActivity60.ViewValue = RemarkActivity60.CurrentValue;
                RemarkActivity60.ViewCustomAttributes = "";

                // RemarkActivity70
                RemarkActivity70.ViewValue = RemarkActivity70.CurrentValue;
                RemarkActivity70.ViewCustomAttributes = "";

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.ViewValue = ConvertToString(InterviewedByPersonOneName.CurrentValue); // DN
                InterviewedByPersonOneName.ViewCustomAttributes = "";

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.ViewValue = ConvertToString(InterviewedByPersonOneRank.CurrentValue); // DN
                InterviewedByPersonOneRank.ViewCustomAttributes = "";

                // InterviewedByPersonOneDate
                InterviewedByPersonOneDate.ViewValue = InterviewedByPersonOneDate.CurrentValue;
                InterviewedByPersonOneDate.ViewValue = FormatDateTime(InterviewedByPersonOneDate.ViewValue, InterviewedByPersonOneDate.FormatPattern);
                InterviewedByPersonOneDate.ViewCustomAttributes = "";

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.ViewValue = AssistantManagerPdeReviewedDate.CurrentValue;
                AssistantManagerPdeReviewedDate.ViewValue = FormatDateTime(AssistantManagerPdeReviewedDate.ViewValue, AssistantManagerPdeReviewedDate.FormatPattern);
                AssistantManagerPdeReviewedDate.ViewCustomAttributes = "";

                // InterviewedByPersonTwoName
                InterviewedByPersonTwoName.ViewValue = ConvertToString(InterviewedByPersonTwoName.CurrentValue); // DN
                InterviewedByPersonTwoName.ViewCustomAttributes = "";

                // InterviewedByPersonTwoRank
                InterviewedByPersonTwoRank.ViewValue = ConvertToString(InterviewedByPersonTwoRank.CurrentValue); // DN
                InterviewedByPersonTwoRank.ViewCustomAttributes = "";

                // InterviewedByPersonTwoDate
                InterviewedByPersonTwoDate.ViewValue = InterviewedByPersonTwoDate.CurrentValue;
                InterviewedByPersonTwoDate.ViewValue = FormatDateTime(InterviewedByPersonTwoDate.ViewValue, InterviewedByPersonTwoDate.FormatPattern);
                InterviewedByPersonTwoDate.ViewCustomAttributes = "";

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.ViewValue = ConvertToString(InterviewedByPersonThreeName.CurrentValue); // DN
                InterviewedByPersonThreeName.ViewCustomAttributes = "";

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.ViewValue = ConvertToString(InterviewedByPersonThreeRank.CurrentValue); // DN
                InterviewedByPersonThreeRank.ViewCustomAttributes = "";

                // InterviewedByPersonThreeDate
                InterviewedByPersonThreeDate.ViewValue = InterviewedByPersonThreeDate.CurrentValue;
                InterviewedByPersonThreeDate.ViewValue = FormatDateTime(InterviewedByPersonThreeDate.ViewValue, InterviewedByPersonThreeDate.FormatPattern);
                InterviewedByPersonThreeDate.ViewCustomAttributes = "";

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.ViewValue = CrewingManagerApprovalDate.CurrentValue;
                CrewingManagerApprovalDate.ViewValue = FormatDateTime(CrewingManagerApprovalDate.ViewValue, CrewingManagerApprovalDate.FormatPattern);
                CrewingManagerApprovalDate.ViewCustomAttributes = "";

                // Activity14Attachment
                if (!IsNull(Activity14Attachment.Upload.DbValue)) {
                    Activity14Attachment.ViewValue = Activity14Attachment.Upload.DbValue;
                } else {
                    Activity14Attachment.ViewValue = "";
                }
                Activity14Attachment.ViewCustomAttributes = "";

                // Activity20Attachment
                if (!IsNull(Activity20Attachment.Upload.DbValue)) {
                    Activity20Attachment.ViewValue = Activity20Attachment.Upload.DbValue;
                } else {
                    Activity20Attachment.ViewValue = "";
                }
                Activity20Attachment.ViewCustomAttributes = "";

                // Activity30Attachment
                if (!IsNull(Activity30Attachment.Upload.DbValue)) {
                    Activity30Attachment.ViewValue = Activity30Attachment.Upload.DbValue;
                } else {
                    Activity30Attachment.ViewValue = "";
                }
                Activity30Attachment.ViewCustomAttributes = "";

                // Activity50Attachment
                if (!IsNull(Activity50Attachment.Upload.DbValue)) {
                    Activity50Attachment.ViewValue = Activity50Attachment.Upload.DbValue;
                } else {
                    Activity50Attachment.ViewValue = "";
                }
                Activity50Attachment.ViewCustomAttributes = "";

                // Activity70Attachment
                if (!IsNull(Activity70Attachment.Upload.DbValue)) {
                    Activity70Attachment.ViewValue = Activity70Attachment.Upload.DbValue;
                } else {
                    Activity70Attachment.ViewValue = "";
                }
                Activity70Attachment.ViewCustomAttributes = "";

                // InterviewedByPersonOneAttachment
                InterviewedByPersonOneAttachment.ViewValue = ConvertToString(InterviewedByPersonOneAttachment.CurrentValue); // DN
                InterviewedByPersonOneAttachment.ViewCustomAttributes = "";

                // InterviewedByPersonTwoAttachment
                InterviewedByPersonTwoAttachment.ViewValue = ConvertToString(InterviewedByPersonTwoAttachment.CurrentValue); // DN
                InterviewedByPersonTwoAttachment.ViewCustomAttributes = "";

                // InterviewedByPersonThreeAttachment
                InterviewedByPersonThreeAttachment.ViewValue = ConvertToString(InterviewedByPersonThreeAttachment.CurrentValue); // DN
                InterviewedByPersonThreeAttachment.ViewCustomAttributes = "";

                // FinalInterviewAttachment
                if (!IsNull(FinalInterviewAttachment.Upload.DbValue)) {
                    FinalInterviewAttachment.ViewValue = FinalInterviewAttachment.Upload.DbValue;
                } else {
                    FinalInterviewAttachment.ViewValue = "";
                }
                FinalInterviewAttachment.ViewCustomAttributes = "";

                // PrincipalCommentAttachment
                if (!IsNull(PrincipalCommentAttachment.Upload.DbValue)) {
                    PrincipalCommentAttachment.ViewValue = PrincipalCommentAttachment.Upload.DbValue;
                } else {
                    PrincipalCommentAttachment.ViewValue = "";
                }
                PrincipalCommentAttachment.ViewCustomAttributes = "";

                // FormPrintoutAttachment
                if (!IsNull(FormPrintoutAttachment.Upload.DbValue)) {
                    FormPrintoutAttachment.ViewValue = FormPrintoutAttachment.Upload.DbValue;
                } else {
                    FormPrintoutAttachment.ViewValue = "";
                }
                FormPrintoutAttachment.ViewCustomAttributes = "";

                // AssistantManagerPdeReviewed
                if (ConvertToBool(AssistantManagerPdeReviewed.CurrentValue)) {
                    AssistantManagerPdeReviewed.ViewValue = AssistantManagerPdeReviewed.TagCaption(1) != "" ? AssistantManagerPdeReviewed.TagCaption(1) : "Yes";
                } else {
                    AssistantManagerPdeReviewed.ViewValue = AssistantManagerPdeReviewed.TagCaption(2) != "" ? AssistantManagerPdeReviewed.TagCaption(2) : "No";
                }
                AssistantManagerPdeReviewed.ViewCustomAttributes = "";

                // CrewingManagerApproval
                if (ConvertToBool(CrewingManagerApproval.CurrentValue)) {
                    CrewingManagerApproval.ViewValue = CrewingManagerApproval.TagCaption(1) != "" ? CrewingManagerApproval.TagCaption(1) : "Yes";
                } else {
                    CrewingManagerApproval.ViewValue = CrewingManagerApproval.TagCaption(2) != "" ? CrewingManagerApproval.TagCaption(2) : "No";
                }
                CrewingManagerApproval.ViewCustomAttributes = "";

                // InterviewDate
                InterviewDate.ViewValue = InterviewDate.CurrentValue;
                InterviewDate.ViewValue = FormatDateTime(InterviewDate.ViewValue, InterviewDate.FormatPattern);
                InterviewDate.ViewCustomAttributes = "";

                // InterviewAttachment
                if (!IsNull(InterviewAttachment.Upload.DbValue)) {
                    InterviewAttachment.ViewValue = InterviewAttachment.Upload.DbValue;
                } else {
                    InterviewAttachment.ViewValue = "";
                }
                InterviewAttachment.ViewCustomAttributes = "";

                // ApprovedByUserID1
                ApprovedByUserID1.ViewValue = ApprovedByUserID1.CurrentValue;
                ApprovedByUserID1.ViewValue = FormatNumber(ApprovedByUserID1.ViewValue, ApprovedByUserID1.FormatPattern);
                ApprovedByUserID1.ViewCustomAttributes = "";

                // ApprovedByUserID2
                ApprovedByUserID2.ViewValue = ApprovedByUserID2.CurrentValue;
                ApprovedByUserID2.ViewValue = FormatNumber(ApprovedByUserID2.ViewValue, ApprovedByUserID2.FormatPattern);
                ApprovedByUserID2.ViewCustomAttributes = "";

                // DocumentDate
                DocumentDate.HrefValue = "";

                // Activity10
                Activity10.HrefValue = "";

                // Activity11
                Activity11.HrefValue = "";

                // Activity12
                Activity12.HrefValue = "";

                // Activity13
                Activity13.HrefValue = "";

                // Activity14
                Activity14.HrefValue = "";

                // Activity20
                Activity20.HrefValue = "";

                // Activity30
                Activity30.HrefValue = "";

                // Activity40
                Activity40.HrefValue = "";

                // Activity50
                Activity50.HrefValue = "";

                // Activity60
                Activity60.HrefValue = "";

                // Activity70
                Activity70.HrefValue = "";

                // InterviewerComment
                InterviewerComment.HrefValue = "";

                // FinalInterviewComment
                FinalInterviewComment.HrefValue = "";

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

                // CreatedByUserID
                CreatedByUserID.HrefValue = "";

                // CreatedDateTime
                CreatedDateTime.HrefValue = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.HrefValue = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.HrefValue = "";

                // RemarkActivity10
                RemarkActivity10.HrefValue = "";

                // RemarkActivity11
                RemarkActivity11.HrefValue = "";

                // RemarkActivity12
                RemarkActivity12.HrefValue = "";

                // RemarkActivity13
                RemarkActivity13.HrefValue = "";

                // RemarkActivity14
                RemarkActivity14.HrefValue = "";

                // RemarkActivity20
                RemarkActivity20.HrefValue = "";

                // RemarkActivity30
                RemarkActivity30.HrefValue = "";

                // RemarkActivity40
                RemarkActivity40.HrefValue = "";

                // RemarkActivity50
                RemarkActivity50.HrefValue = "";

                // RemarkActivity60
                RemarkActivity60.HrefValue = "";

                // RemarkActivity70
                RemarkActivity70.HrefValue = "";

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.HrefValue = "";

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.HrefValue = "";

                // InterviewedByPersonOneDate
                InterviewedByPersonOneDate.HrefValue = "";

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.HrefValue = "";

                // InterviewedByPersonTwoName
                InterviewedByPersonTwoName.HrefValue = "";

                // InterviewedByPersonTwoRank
                InterviewedByPersonTwoRank.HrefValue = "";

                // InterviewedByPersonTwoDate
                InterviewedByPersonTwoDate.HrefValue = "";

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.HrefValue = "";

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.HrefValue = "";

                // InterviewedByPersonThreeDate
                InterviewedByPersonThreeDate.HrefValue = "";

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.HrefValue = "";

                // Activity14Attachment
                if (!IsNull(Activity14Attachment.Upload.DbValue)) {
                    Activity14Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity14Attachment, Activity14Attachment.HtmlDecode(ConvertToString(Activity14Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity14Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity14Attachment.HrefValue = FullUrl(ConvertToString(Activity14Attachment.HrefValue), "href");
                } else {
                    Activity14Attachment.HrefValue = "";
                }
                Activity14Attachment.ExportHrefValue = Activity14Attachment.UploadPath + Activity14Attachment.Upload.DbValue;

                // Activity20Attachment
                if (!IsNull(Activity20Attachment.Upload.DbValue)) {
                    Activity20Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity20Attachment, Activity20Attachment.HtmlDecode(ConvertToString(Activity20Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity20Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity20Attachment.HrefValue = FullUrl(ConvertToString(Activity20Attachment.HrefValue), "href");
                } else {
                    Activity20Attachment.HrefValue = "";
                }
                Activity20Attachment.ExportHrefValue = Activity20Attachment.UploadPath + Activity20Attachment.Upload.DbValue;

                // Activity30Attachment
                if (!IsNull(Activity30Attachment.Upload.DbValue)) {
                    Activity30Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity30Attachment, Activity30Attachment.HtmlDecode(ConvertToString(Activity30Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity30Attachment.LinkAttrs["target"] = ""; // Add target
                    if (IsExport())
                        Activity30Attachment.HrefValue = FullUrl(ConvertToString(Activity30Attachment.HrefValue), "href");
                } else {
                    Activity30Attachment.HrefValue = "";
                }
                Activity30Attachment.ExportHrefValue = Activity30Attachment.UploadPath + Activity30Attachment.Upload.DbValue;

                // Activity50Attachment
                if (!IsNull(Activity50Attachment.Upload.DbValue)) {
                    Activity50Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity50Attachment, Activity50Attachment.HtmlDecode(ConvertToString(Activity50Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity50Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity50Attachment.HrefValue = FullUrl(ConvertToString(Activity50Attachment.HrefValue), "href");
                } else {
                    Activity50Attachment.HrefValue = "";
                }
                Activity50Attachment.ExportHrefValue = Activity50Attachment.UploadPath + Activity50Attachment.Upload.DbValue;

                // Activity70Attachment
                if (!IsNull(Activity70Attachment.Upload.DbValue)) {
                    Activity70Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity70Attachment, Activity70Attachment.HtmlDecode(ConvertToString(Activity70Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity70Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity70Attachment.HrefValue = FullUrl(ConvertToString(Activity70Attachment.HrefValue), "href");
                } else {
                    Activity70Attachment.HrefValue = "";
                }
                Activity70Attachment.ExportHrefValue = Activity70Attachment.UploadPath + Activity70Attachment.Upload.DbValue;

                // InterviewedByPersonOneAttachment
                InterviewedByPersonOneAttachment.HrefValue = "";

                // InterviewedByPersonTwoAttachment
                InterviewedByPersonTwoAttachment.HrefValue = "";

                // InterviewedByPersonThreeAttachment
                InterviewedByPersonThreeAttachment.HrefValue = "";

                // FinalInterviewAttachment
                if (!IsNull(FinalInterviewAttachment.Upload.DbValue)) {
                    FinalInterviewAttachment.HrefValue = ConvertToString(GetFileUploadUrl(FinalInterviewAttachment, FinalInterviewAttachment.HtmlDecode(ConvertToString(FinalInterviewAttachment.Upload.DbValue)))); // Add prefix/suffix
                    FinalInterviewAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        FinalInterviewAttachment.HrefValue = FullUrl(ConvertToString(FinalInterviewAttachment.HrefValue), "href");
                } else {
                    FinalInterviewAttachment.HrefValue = "";
                }
                FinalInterviewAttachment.ExportHrefValue = FinalInterviewAttachment.UploadPath + FinalInterviewAttachment.Upload.DbValue;

                // PrincipalCommentAttachment
                if (!IsNull(PrincipalCommentAttachment.Upload.DbValue)) {
                    PrincipalCommentAttachment.HrefValue = ConvertToString(GetFileUploadUrl(PrincipalCommentAttachment, PrincipalCommentAttachment.HtmlDecode(ConvertToString(PrincipalCommentAttachment.Upload.DbValue)))); // Add prefix/suffix
                    PrincipalCommentAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        PrincipalCommentAttachment.HrefValue = FullUrl(ConvertToString(PrincipalCommentAttachment.HrefValue), "href");
                } else {
                    PrincipalCommentAttachment.HrefValue = "";
                }
                PrincipalCommentAttachment.ExportHrefValue = PrincipalCommentAttachment.UploadPath + PrincipalCommentAttachment.Upload.DbValue;

                // FormPrintoutAttachment
                if (!IsNull(FormPrintoutAttachment.Upload.DbValue)) {
                    FormPrintoutAttachment.HrefValue = ConvertToString(GetFileUploadUrl(FormPrintoutAttachment, FormPrintoutAttachment.HtmlDecode(ConvertToString(FormPrintoutAttachment.Upload.DbValue)))); // Add prefix/suffix
                    FormPrintoutAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        FormPrintoutAttachment.HrefValue = FullUrl(ConvertToString(FormPrintoutAttachment.HrefValue), "href");
                } else {
                    FormPrintoutAttachment.HrefValue = "";
                }
                FormPrintoutAttachment.ExportHrefValue = FormPrintoutAttachment.UploadPath + FormPrintoutAttachment.Upload.DbValue;

                // AssistantManagerPdeReviewed
                AssistantManagerPdeReviewed.HrefValue = "";

                // CrewingManagerApproval
                CrewingManagerApproval.HrefValue = "";

                // InterviewDate
                InterviewDate.HrefValue = "";

                // InterviewAttachment
                if (!IsNull(InterviewAttachment.Upload.DbValue)) {
                    InterviewAttachment.HrefValue = ConvertToString(GetFileUploadUrl(InterviewAttachment, InterviewAttachment.HtmlDecode(ConvertToString(InterviewAttachment.Upload.DbValue)))); // Add prefix/suffix
                    InterviewAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        InterviewAttachment.HrefValue = FullUrl(ConvertToString(InterviewAttachment.HrefValue), "href");
                } else {
                    InterviewAttachment.HrefValue = "";
                }
                InterviewAttachment.ExportHrefValue = InterviewAttachment.UploadPath + InterviewAttachment.Upload.DbValue;

                // ApprovedByUserID1
                ApprovedByUserID1.HrefValue = "";

                // ApprovedByUserID2
                ApprovedByUserID2.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // DocumentDate
                DocumentDate.SetupEditAttributes();
                DocumentDate.EditValue = FormatDateTime(DocumentDate.CurrentValue, DocumentDate.FormatPattern); // DN
                DocumentDate.PlaceHolder = RemoveHtml(DocumentDate.Caption);

                // Activity10
                Activity10.EditValue = Activity10.Options(false);
                Activity10.PlaceHolder = RemoveHtml(Activity10.Caption);

                // Activity11
                Activity11.EditValue = Activity11.Options(false);
                Activity11.PlaceHolder = RemoveHtml(Activity11.Caption);

                // Activity12
                Activity12.EditValue = Activity12.Options(false);
                Activity12.PlaceHolder = RemoveHtml(Activity12.Caption);

                // Activity13
                Activity13.EditValue = Activity13.Options(false);
                Activity13.PlaceHolder = RemoveHtml(Activity13.Caption);

                // Activity14
                Activity14.EditValue = Activity14.Options(false);
                Activity14.PlaceHolder = RemoveHtml(Activity14.Caption);

                // Activity20
                Activity20.EditValue = Activity20.Options(false);
                Activity20.PlaceHolder = RemoveHtml(Activity20.Caption);

                // Activity30
                Activity30.EditValue = Activity30.Options(false);
                Activity30.PlaceHolder = RemoveHtml(Activity30.Caption);

                // Activity40
                Activity40.EditValue = Activity40.Options(false);
                Activity40.PlaceHolder = RemoveHtml(Activity40.Caption);

                // Activity50
                Activity50.EditValue = Activity50.Options(false);
                Activity50.PlaceHolder = RemoveHtml(Activity50.Caption);

                // Activity60
                Activity60.EditValue = Activity60.Options(false);
                Activity60.PlaceHolder = RemoveHtml(Activity60.Caption);

                // Activity70
                Activity70.EditValue = Activity70.Options(false);
                Activity70.PlaceHolder = RemoveHtml(Activity70.Caption);

                // InterviewerComment
                InterviewerComment.SetupEditAttributes();
                InterviewerComment.EditValue = InterviewerComment.CurrentValue; // DN
                InterviewerComment.PlaceHolder = RemoveHtml(InterviewerComment.Caption);

                // FinalInterviewComment
                FinalInterviewComment.SetupEditAttributes();
                FinalInterviewComment.EditValue = FinalInterviewComment.CurrentValue; // DN
                FinalInterviewComment.PlaceHolder = RemoveHtml(FinalInterviewComment.Caption);

                // JobKnowledge
                JobKnowledge.SetupEditAttributes();
                JobKnowledge.EditValue = JobKnowledge.Options(true);
                JobKnowledge.PlaceHolder = RemoveHtml(JobKnowledge.Caption);

                // SafetyAwareness
                SafetyAwareness.SetupEditAttributes();
                SafetyAwareness.EditValue = SafetyAwareness.Options(true);
                SafetyAwareness.PlaceHolder = RemoveHtml(SafetyAwareness.Caption);

                // Personality
                Personality.SetupEditAttributes();
                Personality.EditValue = Personality.Options(true);
                Personality.PlaceHolder = RemoveHtml(Personality.Caption);

                // EnglishProficiency
                EnglishProficiency.SetupEditAttributes();
                EnglishProficiency.EditValue = EnglishProficiency.Options(true);
                EnglishProficiency.PlaceHolder = RemoveHtml(EnglishProficiency.Caption);

                // PrincipalComment
                PrincipalComment.SetupEditAttributes();
                PrincipalComment.EditValue = PrincipalComment.CurrentValue; // DN
                PrincipalComment.PlaceHolder = RemoveHtml(PrincipalComment.Caption);

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

                // RemarkActivity10
                RemarkActivity10.SetupEditAttributes();
                RemarkActivity10.EditValue = RemarkActivity10.CurrentValue; // DN
                RemarkActivity10.PlaceHolder = RemoveHtml(RemarkActivity10.Caption);

                // RemarkActivity11
                RemarkActivity11.SetupEditAttributes();
                RemarkActivity11.EditValue = RemarkActivity11.CurrentValue; // DN
                RemarkActivity11.PlaceHolder = RemoveHtml(RemarkActivity11.Caption);

                // RemarkActivity12
                RemarkActivity12.SetupEditAttributes();
                RemarkActivity12.EditValue = RemarkActivity12.CurrentValue; // DN
                RemarkActivity12.PlaceHolder = RemoveHtml(RemarkActivity12.Caption);

                // RemarkActivity13
                RemarkActivity13.SetupEditAttributes();
                RemarkActivity13.EditValue = RemarkActivity13.CurrentValue; // DN
                RemarkActivity13.PlaceHolder = RemoveHtml(RemarkActivity13.Caption);

                // RemarkActivity14
                RemarkActivity14.SetupEditAttributes();
                RemarkActivity14.EditValue = RemarkActivity14.CurrentValue; // DN
                RemarkActivity14.PlaceHolder = RemoveHtml(RemarkActivity14.Caption);

                // RemarkActivity20
                RemarkActivity20.SetupEditAttributes();
                RemarkActivity20.EditValue = RemarkActivity20.CurrentValue; // DN
                RemarkActivity20.PlaceHolder = RemoveHtml(RemarkActivity20.Caption);

                // RemarkActivity30
                RemarkActivity30.SetupEditAttributes();
                RemarkActivity30.EditValue = RemarkActivity30.CurrentValue; // DN
                RemarkActivity30.PlaceHolder = RemoveHtml(RemarkActivity30.Caption);

                // RemarkActivity40
                RemarkActivity40.SetupEditAttributes();
                RemarkActivity40.EditValue = RemarkActivity40.CurrentValue; // DN
                RemarkActivity40.PlaceHolder = RemoveHtml(RemarkActivity40.Caption);

                // RemarkActivity50
                RemarkActivity50.SetupEditAttributes();
                RemarkActivity50.EditValue = RemarkActivity50.CurrentValue; // DN
                RemarkActivity50.PlaceHolder = RemoveHtml(RemarkActivity50.Caption);

                // RemarkActivity60
                RemarkActivity60.SetupEditAttributes();
                RemarkActivity60.EditValue = RemarkActivity60.CurrentValue; // DN
                RemarkActivity60.PlaceHolder = RemoveHtml(RemarkActivity60.Caption);

                // RemarkActivity70
                RemarkActivity70.SetupEditAttributes();
                RemarkActivity70.EditValue = RemarkActivity70.CurrentValue; // DN
                RemarkActivity70.PlaceHolder = RemoveHtml(RemarkActivity70.Caption);

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

                // InterviewedByPersonOneDate
                InterviewedByPersonOneDate.SetupEditAttributes();
                InterviewedByPersonOneDate.EditValue = FormatDateTime(InterviewedByPersonOneDate.CurrentValue, InterviewedByPersonOneDate.FormatPattern); // DN
                InterviewedByPersonOneDate.PlaceHolder = RemoveHtml(InterviewedByPersonOneDate.Caption);

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.SetupEditAttributes();
                AssistantManagerPdeReviewedDate.EditValue = FormatDateTime(AssistantManagerPdeReviewedDate.CurrentValue, AssistantManagerPdeReviewedDate.FormatPattern); // DN
                AssistantManagerPdeReviewedDate.PlaceHolder = RemoveHtml(AssistantManagerPdeReviewedDate.Caption);

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

                // InterviewedByPersonTwoDate
                InterviewedByPersonTwoDate.SetupEditAttributes();
                InterviewedByPersonTwoDate.EditValue = FormatDateTime(InterviewedByPersonTwoDate.CurrentValue, InterviewedByPersonTwoDate.FormatPattern); // DN
                InterviewedByPersonTwoDate.PlaceHolder = RemoveHtml(InterviewedByPersonTwoDate.Caption);

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

                // InterviewedByPersonThreeDate
                InterviewedByPersonThreeDate.SetupEditAttributes();
                InterviewedByPersonThreeDate.EditValue = FormatDateTime(InterviewedByPersonThreeDate.CurrentValue, InterviewedByPersonThreeDate.FormatPattern); // DN
                InterviewedByPersonThreeDate.PlaceHolder = RemoveHtml(InterviewedByPersonThreeDate.Caption);

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.SetupEditAttributes();
                CrewingManagerApprovalDate.EditValue = FormatDateTime(CrewingManagerApprovalDate.CurrentValue, CrewingManagerApprovalDate.FormatPattern); // DN
                CrewingManagerApprovalDate.PlaceHolder = RemoveHtml(CrewingManagerApprovalDate.Caption);

                // Activity14Attachment
                Activity14Attachment.SetupEditAttributes();
                Activity14Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(Activity14Attachment.Upload.DbValue)) {
                    Activity14Attachment.EditValue = Activity14Attachment.Upload.DbValue;
                } else {
                    Activity14Attachment.EditValue = "";
                }
                if (!Empty(Activity14Attachment.CurrentValue))
                        Activity14Attachment.Upload.FileName = ConvertToString(Activity14Attachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(Activity14Attachment);

                // Activity20Attachment
                Activity20Attachment.SetupEditAttributes();
                Activity20Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(Activity20Attachment.Upload.DbValue)) {
                    Activity20Attachment.EditValue = Activity20Attachment.Upload.DbValue;
                } else {
                    Activity20Attachment.EditValue = "";
                }
                if (!Empty(Activity20Attachment.CurrentValue))
                        Activity20Attachment.Upload.FileName = ConvertToString(Activity20Attachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(Activity20Attachment);

                // Activity30Attachment
                Activity30Attachment.SetupEditAttributes();
                Activity30Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(Activity30Attachment.Upload.DbValue)) {
                    Activity30Attachment.EditValue = Activity30Attachment.Upload.DbValue;
                } else {
                    Activity30Attachment.EditValue = "";
                }
                if (!Empty(Activity30Attachment.CurrentValue))
                        Activity30Attachment.Upload.FileName = ConvertToString(Activity30Attachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(Activity30Attachment);

                // Activity50Attachment
                Activity50Attachment.SetupEditAttributes();
                Activity50Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(Activity50Attachment.Upload.DbValue)) {
                    Activity50Attachment.EditValue = Activity50Attachment.Upload.DbValue;
                } else {
                    Activity50Attachment.EditValue = "";
                }
                if (!Empty(Activity50Attachment.CurrentValue))
                        Activity50Attachment.Upload.FileName = ConvertToString(Activity50Attachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(Activity50Attachment);

                // Activity70Attachment
                Activity70Attachment.SetupEditAttributes();
                Activity70Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(Activity70Attachment.Upload.DbValue)) {
                    Activity70Attachment.EditValue = Activity70Attachment.Upload.DbValue;
                } else {
                    Activity70Attachment.EditValue = "";
                }
                if (!Empty(Activity70Attachment.CurrentValue))
                        Activity70Attachment.Upload.FileName = ConvertToString(Activity70Attachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(Activity70Attachment);

                // InterviewedByPersonOneAttachment
                InterviewedByPersonOneAttachment.SetupEditAttributes();
                if (!InterviewedByPersonOneAttachment.Raw)
                    InterviewedByPersonOneAttachment.CurrentValue = HtmlDecode(InterviewedByPersonOneAttachment.CurrentValue);
                InterviewedByPersonOneAttachment.EditValue = HtmlEncode(InterviewedByPersonOneAttachment.CurrentValue);
                InterviewedByPersonOneAttachment.PlaceHolder = RemoveHtml(InterviewedByPersonOneAttachment.Caption);

                // InterviewedByPersonTwoAttachment
                InterviewedByPersonTwoAttachment.SetupEditAttributes();
                if (!InterviewedByPersonTwoAttachment.Raw)
                    InterviewedByPersonTwoAttachment.CurrentValue = HtmlDecode(InterviewedByPersonTwoAttachment.CurrentValue);
                InterviewedByPersonTwoAttachment.EditValue = HtmlEncode(InterviewedByPersonTwoAttachment.CurrentValue);
                InterviewedByPersonTwoAttachment.PlaceHolder = RemoveHtml(InterviewedByPersonTwoAttachment.Caption);

                // InterviewedByPersonThreeAttachment
                InterviewedByPersonThreeAttachment.SetupEditAttributes();
                if (!InterviewedByPersonThreeAttachment.Raw)
                    InterviewedByPersonThreeAttachment.CurrentValue = HtmlDecode(InterviewedByPersonThreeAttachment.CurrentValue);
                InterviewedByPersonThreeAttachment.EditValue = HtmlEncode(InterviewedByPersonThreeAttachment.CurrentValue);
                InterviewedByPersonThreeAttachment.PlaceHolder = RemoveHtml(InterviewedByPersonThreeAttachment.Caption);

                // FinalInterviewAttachment
                FinalInterviewAttachment.SetupEditAttributes();
                FinalInterviewAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(FinalInterviewAttachment.Upload.DbValue)) {
                    FinalInterviewAttachment.EditValue = FinalInterviewAttachment.Upload.DbValue;
                } else {
                    FinalInterviewAttachment.EditValue = "";
                }
                if (!Empty(FinalInterviewAttachment.CurrentValue))
                        FinalInterviewAttachment.Upload.FileName = ConvertToString(FinalInterviewAttachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(FinalInterviewAttachment);

                // PrincipalCommentAttachment
                PrincipalCommentAttachment.SetupEditAttributes();
                PrincipalCommentAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(PrincipalCommentAttachment.Upload.DbValue)) {
                    PrincipalCommentAttachment.EditValue = PrincipalCommentAttachment.Upload.DbValue;
                } else {
                    PrincipalCommentAttachment.EditValue = "";
                }
                if (!Empty(PrincipalCommentAttachment.CurrentValue))
                        PrincipalCommentAttachment.Upload.FileName = ConvertToString(PrincipalCommentAttachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(PrincipalCommentAttachment);

                // FormPrintoutAttachment
                FormPrintoutAttachment.SetupEditAttributes();
                FormPrintoutAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(FormPrintoutAttachment.Upload.DbValue)) {
                    FormPrintoutAttachment.EditValue = FormPrintoutAttachment.Upload.DbValue;
                } else {
                    FormPrintoutAttachment.EditValue = "";
                }
                if (!Empty(FormPrintoutAttachment.CurrentValue))
                        FormPrintoutAttachment.Upload.FileName = ConvertToString(FormPrintoutAttachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(FormPrintoutAttachment);

                // AssistantManagerPdeReviewed
                AssistantManagerPdeReviewed.EditValue = AssistantManagerPdeReviewed.Options(false);
                AssistantManagerPdeReviewed.PlaceHolder = RemoveHtml(AssistantManagerPdeReviewed.Caption);

                // CrewingManagerApproval
                CrewingManagerApproval.EditValue = CrewingManagerApproval.Options(false);
                CrewingManagerApproval.PlaceHolder = RemoveHtml(CrewingManagerApproval.Caption);

                // InterviewDate
                InterviewDate.SetupEditAttributes();
                InterviewDate.EditValue = FormatDateTime(InterviewDate.CurrentValue, InterviewDate.FormatPattern); // DN
                InterviewDate.PlaceHolder = RemoveHtml(InterviewDate.Caption);

                // InterviewAttachment
                InterviewAttachment.SetupEditAttributes();
                InterviewAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
                if (!IsNull(InterviewAttachment.Upload.DbValue)) {
                    InterviewAttachment.EditValue = InterviewAttachment.Upload.DbValue;
                } else {
                    InterviewAttachment.EditValue = "";
                }
                if (!Empty(InterviewAttachment.CurrentValue))
                        InterviewAttachment.Upload.FileName = ConvertToString(InterviewAttachment.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(InterviewAttachment);

                // ApprovedByUserID1
                ApprovedByUserID1.SetupEditAttributes();
                ApprovedByUserID1.EditValue = ApprovedByUserID1.CurrentValue; // DN
                ApprovedByUserID1.PlaceHolder = RemoveHtml(ApprovedByUserID1.Caption);
                if (!Empty(ApprovedByUserID1.EditValue) && IsNumeric(ApprovedByUserID1.EditValue))
                    ApprovedByUserID1.EditValue = FormatNumber(ApprovedByUserID1.EditValue, null);

                // ApprovedByUserID2
                ApprovedByUserID2.SetupEditAttributes();
                ApprovedByUserID2.EditValue = ApprovedByUserID2.CurrentValue; // DN
                ApprovedByUserID2.PlaceHolder = RemoveHtml(ApprovedByUserID2.Caption);
                if (!Empty(ApprovedByUserID2.EditValue) && IsNumeric(ApprovedByUserID2.EditValue))
                    ApprovedByUserID2.EditValue = FormatNumber(ApprovedByUserID2.EditValue, null);

                // Add refer script

                // DocumentDate
                DocumentDate.HrefValue = "";

                // Activity10
                Activity10.HrefValue = "";

                // Activity11
                Activity11.HrefValue = "";

                // Activity12
                Activity12.HrefValue = "";

                // Activity13
                Activity13.HrefValue = "";

                // Activity14
                Activity14.HrefValue = "";

                // Activity20
                Activity20.HrefValue = "";

                // Activity30
                Activity30.HrefValue = "";

                // Activity40
                Activity40.HrefValue = "";

                // Activity50
                Activity50.HrefValue = "";

                // Activity60
                Activity60.HrefValue = "";

                // Activity70
                Activity70.HrefValue = "";

                // InterviewerComment
                InterviewerComment.HrefValue = "";

                // FinalInterviewComment
                FinalInterviewComment.HrefValue = "";

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

                // CreatedByUserID
                CreatedByUserID.HrefValue = "";

                // CreatedDateTime
                CreatedDateTime.HrefValue = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.HrefValue = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.HrefValue = "";

                // RemarkActivity10
                RemarkActivity10.HrefValue = "";

                // RemarkActivity11
                RemarkActivity11.HrefValue = "";

                // RemarkActivity12
                RemarkActivity12.HrefValue = "";

                // RemarkActivity13
                RemarkActivity13.HrefValue = "";

                // RemarkActivity14
                RemarkActivity14.HrefValue = "";

                // RemarkActivity20
                RemarkActivity20.HrefValue = "";

                // RemarkActivity30
                RemarkActivity30.HrefValue = "";

                // RemarkActivity40
                RemarkActivity40.HrefValue = "";

                // RemarkActivity50
                RemarkActivity50.HrefValue = "";

                // RemarkActivity60
                RemarkActivity60.HrefValue = "";

                // RemarkActivity70
                RemarkActivity70.HrefValue = "";

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.HrefValue = "";

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.HrefValue = "";

                // InterviewedByPersonOneDate
                InterviewedByPersonOneDate.HrefValue = "";

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.HrefValue = "";

                // InterviewedByPersonTwoName
                InterviewedByPersonTwoName.HrefValue = "";

                // InterviewedByPersonTwoRank
                InterviewedByPersonTwoRank.HrefValue = "";

                // InterviewedByPersonTwoDate
                InterviewedByPersonTwoDate.HrefValue = "";

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.HrefValue = "";

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.HrefValue = "";

                // InterviewedByPersonThreeDate
                InterviewedByPersonThreeDate.HrefValue = "";

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.HrefValue = "";

                // Activity14Attachment
                if (!IsNull(Activity14Attachment.Upload.DbValue)) {
                    Activity14Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity14Attachment, Activity14Attachment.HtmlDecode(ConvertToString(Activity14Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity14Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity14Attachment.HrefValue = FullUrl(ConvertToString(Activity14Attachment.HrefValue), "href");
                } else {
                    Activity14Attachment.HrefValue = "";
                }
                Activity14Attachment.ExportHrefValue = Activity14Attachment.UploadPath + Activity14Attachment.Upload.DbValue;

                // Activity20Attachment
                if (!IsNull(Activity20Attachment.Upload.DbValue)) {
                    Activity20Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity20Attachment, Activity20Attachment.HtmlDecode(ConvertToString(Activity20Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity20Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity20Attachment.HrefValue = FullUrl(ConvertToString(Activity20Attachment.HrefValue), "href");
                } else {
                    Activity20Attachment.HrefValue = "";
                }
                Activity20Attachment.ExportHrefValue = Activity20Attachment.UploadPath + Activity20Attachment.Upload.DbValue;

                // Activity30Attachment
                if (!IsNull(Activity30Attachment.Upload.DbValue)) {
                    Activity30Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity30Attachment, Activity30Attachment.HtmlDecode(ConvertToString(Activity30Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity30Attachment.LinkAttrs["target"] = ""; // Add target
                    if (IsExport())
                        Activity30Attachment.HrefValue = FullUrl(ConvertToString(Activity30Attachment.HrefValue), "href");
                } else {
                    Activity30Attachment.HrefValue = "";
                }
                Activity30Attachment.ExportHrefValue = Activity30Attachment.UploadPath + Activity30Attachment.Upload.DbValue;

                // Activity50Attachment
                if (!IsNull(Activity50Attachment.Upload.DbValue)) {
                    Activity50Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity50Attachment, Activity50Attachment.HtmlDecode(ConvertToString(Activity50Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity50Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity50Attachment.HrefValue = FullUrl(ConvertToString(Activity50Attachment.HrefValue), "href");
                } else {
                    Activity50Attachment.HrefValue = "";
                }
                Activity50Attachment.ExportHrefValue = Activity50Attachment.UploadPath + Activity50Attachment.Upload.DbValue;

                // Activity70Attachment
                if (!IsNull(Activity70Attachment.Upload.DbValue)) {
                    Activity70Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity70Attachment, Activity70Attachment.HtmlDecode(ConvertToString(Activity70Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity70Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity70Attachment.HrefValue = FullUrl(ConvertToString(Activity70Attachment.HrefValue), "href");
                } else {
                    Activity70Attachment.HrefValue = "";
                }
                Activity70Attachment.ExportHrefValue = Activity70Attachment.UploadPath + Activity70Attachment.Upload.DbValue;

                // InterviewedByPersonOneAttachment
                InterviewedByPersonOneAttachment.HrefValue = "";

                // InterviewedByPersonTwoAttachment
                InterviewedByPersonTwoAttachment.HrefValue = "";

                // InterviewedByPersonThreeAttachment
                InterviewedByPersonThreeAttachment.HrefValue = "";

                // FinalInterviewAttachment
                if (!IsNull(FinalInterviewAttachment.Upload.DbValue)) {
                    FinalInterviewAttachment.HrefValue = ConvertToString(GetFileUploadUrl(FinalInterviewAttachment, FinalInterviewAttachment.HtmlDecode(ConvertToString(FinalInterviewAttachment.Upload.DbValue)))); // Add prefix/suffix
                    FinalInterviewAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        FinalInterviewAttachment.HrefValue = FullUrl(ConvertToString(FinalInterviewAttachment.HrefValue), "href");
                } else {
                    FinalInterviewAttachment.HrefValue = "";
                }
                FinalInterviewAttachment.ExportHrefValue = FinalInterviewAttachment.UploadPath + FinalInterviewAttachment.Upload.DbValue;

                // PrincipalCommentAttachment
                if (!IsNull(PrincipalCommentAttachment.Upload.DbValue)) {
                    PrincipalCommentAttachment.HrefValue = ConvertToString(GetFileUploadUrl(PrincipalCommentAttachment, PrincipalCommentAttachment.HtmlDecode(ConvertToString(PrincipalCommentAttachment.Upload.DbValue)))); // Add prefix/suffix
                    PrincipalCommentAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        PrincipalCommentAttachment.HrefValue = FullUrl(ConvertToString(PrincipalCommentAttachment.HrefValue), "href");
                } else {
                    PrincipalCommentAttachment.HrefValue = "";
                }
                PrincipalCommentAttachment.ExportHrefValue = PrincipalCommentAttachment.UploadPath + PrincipalCommentAttachment.Upload.DbValue;

                // FormPrintoutAttachment
                if (!IsNull(FormPrintoutAttachment.Upload.DbValue)) {
                    FormPrintoutAttachment.HrefValue = ConvertToString(GetFileUploadUrl(FormPrintoutAttachment, FormPrintoutAttachment.HtmlDecode(ConvertToString(FormPrintoutAttachment.Upload.DbValue)))); // Add prefix/suffix
                    FormPrintoutAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        FormPrintoutAttachment.HrefValue = FullUrl(ConvertToString(FormPrintoutAttachment.HrefValue), "href");
                } else {
                    FormPrintoutAttachment.HrefValue = "";
                }
                FormPrintoutAttachment.ExportHrefValue = FormPrintoutAttachment.UploadPath + FormPrintoutAttachment.Upload.DbValue;

                // AssistantManagerPdeReviewed
                AssistantManagerPdeReviewed.HrefValue = "";

                // CrewingManagerApproval
                CrewingManagerApproval.HrefValue = "";

                // InterviewDate
                InterviewDate.HrefValue = "";

                // InterviewAttachment
                if (!IsNull(InterviewAttachment.Upload.DbValue)) {
                    InterviewAttachment.HrefValue = ConvertToString(GetFileUploadUrl(InterviewAttachment, InterviewAttachment.HtmlDecode(ConvertToString(InterviewAttachment.Upload.DbValue)))); // Add prefix/suffix
                    InterviewAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        InterviewAttachment.HrefValue = FullUrl(ConvertToString(InterviewAttachment.HrefValue), "href");
                } else {
                    InterviewAttachment.HrefValue = "";
                }
                InterviewAttachment.ExportHrefValue = InterviewAttachment.UploadPath + InterviewAttachment.Upload.DbValue;

                // ApprovedByUserID1
                ApprovedByUserID1.HrefValue = "";

                // ApprovedByUserID2
                ApprovedByUserID2.HrefValue = "";
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
            if (DocumentDate.Required) {
                if (!DocumentDate.IsDetailKey && Empty(DocumentDate.FormValue)) {
                    DocumentDate.AddErrorMessage(ConvertToString(DocumentDate.RequiredErrorMessage).Replace("%s", DocumentDate.Caption));
                }
            }
            if (!CheckDate(DocumentDate.FormValue, DocumentDate.FormatPattern)) {
                DocumentDate.AddErrorMessage(DocumentDate.GetErrorMessage(false));
            }
            if (Activity10.Required) {
                if (Empty(Activity10.FormValue)) {
                    Activity10.AddErrorMessage(ConvertToString(Activity10.RequiredErrorMessage).Replace("%s", Activity10.Caption));
                }
            }
            if (Activity11.Required) {
                if (Empty(Activity11.FormValue)) {
                    Activity11.AddErrorMessage(ConvertToString(Activity11.RequiredErrorMessage).Replace("%s", Activity11.Caption));
                }
            }
            if (Activity12.Required) {
                if (Empty(Activity12.FormValue)) {
                    Activity12.AddErrorMessage(ConvertToString(Activity12.RequiredErrorMessage).Replace("%s", Activity12.Caption));
                }
            }
            if (Activity13.Required) {
                if (Empty(Activity13.FormValue)) {
                    Activity13.AddErrorMessage(ConvertToString(Activity13.RequiredErrorMessage).Replace("%s", Activity13.Caption));
                }
            }
            if (Activity14.Required) {
                if (Empty(Activity14.FormValue)) {
                    Activity14.AddErrorMessage(ConvertToString(Activity14.RequiredErrorMessage).Replace("%s", Activity14.Caption));
                }
            }
            if (Activity20.Required) {
                if (Empty(Activity20.FormValue)) {
                    Activity20.AddErrorMessage(ConvertToString(Activity20.RequiredErrorMessage).Replace("%s", Activity20.Caption));
                }
            }
            if (Activity30.Required) {
                if (Empty(Activity30.FormValue)) {
                    Activity30.AddErrorMessage(ConvertToString(Activity30.RequiredErrorMessage).Replace("%s", Activity30.Caption));
                }
            }
            if (Activity40.Required) {
                if (Empty(Activity40.FormValue)) {
                    Activity40.AddErrorMessage(ConvertToString(Activity40.RequiredErrorMessage).Replace("%s", Activity40.Caption));
                }
            }
            if (Activity50.Required) {
                if (Empty(Activity50.FormValue)) {
                    Activity50.AddErrorMessage(ConvertToString(Activity50.RequiredErrorMessage).Replace("%s", Activity50.Caption));
                }
            }
            if (Activity60.Required) {
                if (Empty(Activity60.FormValue)) {
                    Activity60.AddErrorMessage(ConvertToString(Activity60.RequiredErrorMessage).Replace("%s", Activity60.Caption));
                }
            }
            if (Activity70.Required) {
                if (Empty(Activity70.FormValue)) {
                    Activity70.AddErrorMessage(ConvertToString(Activity70.RequiredErrorMessage).Replace("%s", Activity70.Caption));
                }
            }
            if (InterviewerComment.Required) {
                if (!InterviewerComment.IsDetailKey && Empty(InterviewerComment.FormValue)) {
                    InterviewerComment.AddErrorMessage(ConvertToString(InterviewerComment.RequiredErrorMessage).Replace("%s", InterviewerComment.Caption));
                }
            }
            if (FinalInterviewComment.Required) {
                if (!FinalInterviewComment.IsDetailKey && Empty(FinalInterviewComment.FormValue)) {
                    FinalInterviewComment.AddErrorMessage(ConvertToString(FinalInterviewComment.RequiredErrorMessage).Replace("%s", FinalInterviewComment.Caption));
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
            if (RemarkActivity10.Required) {
                if (!RemarkActivity10.IsDetailKey && Empty(RemarkActivity10.FormValue)) {
                    RemarkActivity10.AddErrorMessage(ConvertToString(RemarkActivity10.RequiredErrorMessage).Replace("%s", RemarkActivity10.Caption));
                }
            }
            if (RemarkActivity11.Required) {
                if (!RemarkActivity11.IsDetailKey && Empty(RemarkActivity11.FormValue)) {
                    RemarkActivity11.AddErrorMessage(ConvertToString(RemarkActivity11.RequiredErrorMessage).Replace("%s", RemarkActivity11.Caption));
                }
            }
            if (RemarkActivity12.Required) {
                if (!RemarkActivity12.IsDetailKey && Empty(RemarkActivity12.FormValue)) {
                    RemarkActivity12.AddErrorMessage(ConvertToString(RemarkActivity12.RequiredErrorMessage).Replace("%s", RemarkActivity12.Caption));
                }
            }
            if (RemarkActivity13.Required) {
                if (!RemarkActivity13.IsDetailKey && Empty(RemarkActivity13.FormValue)) {
                    RemarkActivity13.AddErrorMessage(ConvertToString(RemarkActivity13.RequiredErrorMessage).Replace("%s", RemarkActivity13.Caption));
                }
            }
            if (RemarkActivity14.Required) {
                if (!RemarkActivity14.IsDetailKey && Empty(RemarkActivity14.FormValue)) {
                    RemarkActivity14.AddErrorMessage(ConvertToString(RemarkActivity14.RequiredErrorMessage).Replace("%s", RemarkActivity14.Caption));
                }
            }
            if (RemarkActivity20.Required) {
                if (!RemarkActivity20.IsDetailKey && Empty(RemarkActivity20.FormValue)) {
                    RemarkActivity20.AddErrorMessage(ConvertToString(RemarkActivity20.RequiredErrorMessage).Replace("%s", RemarkActivity20.Caption));
                }
            }
            if (RemarkActivity30.Required) {
                if (!RemarkActivity30.IsDetailKey && Empty(RemarkActivity30.FormValue)) {
                    RemarkActivity30.AddErrorMessage(ConvertToString(RemarkActivity30.RequiredErrorMessage).Replace("%s", RemarkActivity30.Caption));
                }
            }
            if (RemarkActivity40.Required) {
                if (!RemarkActivity40.IsDetailKey && Empty(RemarkActivity40.FormValue)) {
                    RemarkActivity40.AddErrorMessage(ConvertToString(RemarkActivity40.RequiredErrorMessage).Replace("%s", RemarkActivity40.Caption));
                }
            }
            if (RemarkActivity50.Required) {
                if (!RemarkActivity50.IsDetailKey && Empty(RemarkActivity50.FormValue)) {
                    RemarkActivity50.AddErrorMessage(ConvertToString(RemarkActivity50.RequiredErrorMessage).Replace("%s", RemarkActivity50.Caption));
                }
            }
            if (RemarkActivity60.Required) {
                if (!RemarkActivity60.IsDetailKey && Empty(RemarkActivity60.FormValue)) {
                    RemarkActivity60.AddErrorMessage(ConvertToString(RemarkActivity60.RequiredErrorMessage).Replace("%s", RemarkActivity60.Caption));
                }
            }
            if (RemarkActivity70.Required) {
                if (!RemarkActivity70.IsDetailKey && Empty(RemarkActivity70.FormValue)) {
                    RemarkActivity70.AddErrorMessage(ConvertToString(RemarkActivity70.RequiredErrorMessage).Replace("%s", RemarkActivity70.Caption));
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
            if (InterviewedByPersonOneDate.Required) {
                if (!InterviewedByPersonOneDate.IsDetailKey && Empty(InterviewedByPersonOneDate.FormValue)) {
                    InterviewedByPersonOneDate.AddErrorMessage(ConvertToString(InterviewedByPersonOneDate.RequiredErrorMessage).Replace("%s", InterviewedByPersonOneDate.Caption));
                }
            }
            if (!CheckDate(InterviewedByPersonOneDate.FormValue, InterviewedByPersonOneDate.FormatPattern)) {
                InterviewedByPersonOneDate.AddErrorMessage(InterviewedByPersonOneDate.GetErrorMessage(false));
            }
            if (AssistantManagerPdeReviewedDate.Required) {
                if (!AssistantManagerPdeReviewedDate.IsDetailKey && Empty(AssistantManagerPdeReviewedDate.FormValue)) {
                    AssistantManagerPdeReviewedDate.AddErrorMessage(ConvertToString(AssistantManagerPdeReviewedDate.RequiredErrorMessage).Replace("%s", AssistantManagerPdeReviewedDate.Caption));
                }
            }
            if (!CheckDate(AssistantManagerPdeReviewedDate.FormValue, AssistantManagerPdeReviewedDate.FormatPattern)) {
                AssistantManagerPdeReviewedDate.AddErrorMessage(AssistantManagerPdeReviewedDate.GetErrorMessage(false));
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
            if (InterviewedByPersonTwoDate.Required) {
                if (!InterviewedByPersonTwoDate.IsDetailKey && Empty(InterviewedByPersonTwoDate.FormValue)) {
                    InterviewedByPersonTwoDate.AddErrorMessage(ConvertToString(InterviewedByPersonTwoDate.RequiredErrorMessage).Replace("%s", InterviewedByPersonTwoDate.Caption));
                }
            }
            if (!CheckDate(InterviewedByPersonTwoDate.FormValue, InterviewedByPersonTwoDate.FormatPattern)) {
                InterviewedByPersonTwoDate.AddErrorMessage(InterviewedByPersonTwoDate.GetErrorMessage(false));
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
            if (InterviewedByPersonThreeDate.Required) {
                if (!InterviewedByPersonThreeDate.IsDetailKey && Empty(InterviewedByPersonThreeDate.FormValue)) {
                    InterviewedByPersonThreeDate.AddErrorMessage(ConvertToString(InterviewedByPersonThreeDate.RequiredErrorMessage).Replace("%s", InterviewedByPersonThreeDate.Caption));
                }
            }
            if (!CheckDate(InterviewedByPersonThreeDate.FormValue, InterviewedByPersonThreeDate.FormatPattern)) {
                InterviewedByPersonThreeDate.AddErrorMessage(InterviewedByPersonThreeDate.GetErrorMessage(false));
            }
            if (CrewingManagerApprovalDate.Required) {
                if (!CrewingManagerApprovalDate.IsDetailKey && Empty(CrewingManagerApprovalDate.FormValue)) {
                    CrewingManagerApprovalDate.AddErrorMessage(ConvertToString(CrewingManagerApprovalDate.RequiredErrorMessage).Replace("%s", CrewingManagerApprovalDate.Caption));
                }
            }
            if (!CheckDate(CrewingManagerApprovalDate.FormValue, CrewingManagerApprovalDate.FormatPattern)) {
                CrewingManagerApprovalDate.AddErrorMessage(CrewingManagerApprovalDate.GetErrorMessage(false));
            }
            if (Activity14Attachment.Required) {
                if (Activity14Attachment.Upload.FileName == "" && !Activity14Attachment.Upload.KeepFile) {
                    Activity14Attachment.AddErrorMessage(ConvertToString(Activity14Attachment.RequiredErrorMessage).Replace("%s", Activity14Attachment.Caption));
                }
            }
            if (Activity20Attachment.Required) {
                if (Activity20Attachment.Upload.FileName == "" && !Activity20Attachment.Upload.KeepFile) {
                    Activity20Attachment.AddErrorMessage(ConvertToString(Activity20Attachment.RequiredErrorMessage).Replace("%s", Activity20Attachment.Caption));
                }
            }
            if (Activity30Attachment.Required) {
                if (Activity30Attachment.Upload.FileName == "" && !Activity30Attachment.Upload.KeepFile) {
                    Activity30Attachment.AddErrorMessage(ConvertToString(Activity30Attachment.RequiredErrorMessage).Replace("%s", Activity30Attachment.Caption));
                }
            }
            if (Activity50Attachment.Required) {
                if (Activity50Attachment.Upload.FileName == "" && !Activity50Attachment.Upload.KeepFile) {
                    Activity50Attachment.AddErrorMessage(ConvertToString(Activity50Attachment.RequiredErrorMessage).Replace("%s", Activity50Attachment.Caption));
                }
            }
            if (Activity70Attachment.Required) {
                if (Activity70Attachment.Upload.FileName == "" && !Activity70Attachment.Upload.KeepFile) {
                    Activity70Attachment.AddErrorMessage(ConvertToString(Activity70Attachment.RequiredErrorMessage).Replace("%s", Activity70Attachment.Caption));
                }
            }
            if (InterviewedByPersonOneAttachment.Required) {
                if (!InterviewedByPersonOneAttachment.IsDetailKey && Empty(InterviewedByPersonOneAttachment.FormValue)) {
                    InterviewedByPersonOneAttachment.AddErrorMessage(ConvertToString(InterviewedByPersonOneAttachment.RequiredErrorMessage).Replace("%s", InterviewedByPersonOneAttachment.Caption));
                }
            }
            if (InterviewedByPersonTwoAttachment.Required) {
                if (!InterviewedByPersonTwoAttachment.IsDetailKey && Empty(InterviewedByPersonTwoAttachment.FormValue)) {
                    InterviewedByPersonTwoAttachment.AddErrorMessage(ConvertToString(InterviewedByPersonTwoAttachment.RequiredErrorMessage).Replace("%s", InterviewedByPersonTwoAttachment.Caption));
                }
            }
            if (InterviewedByPersonThreeAttachment.Required) {
                if (!InterviewedByPersonThreeAttachment.IsDetailKey && Empty(InterviewedByPersonThreeAttachment.FormValue)) {
                    InterviewedByPersonThreeAttachment.AddErrorMessage(ConvertToString(InterviewedByPersonThreeAttachment.RequiredErrorMessage).Replace("%s", InterviewedByPersonThreeAttachment.Caption));
                }
            }
            if (FinalInterviewAttachment.Required) {
                if (FinalInterviewAttachment.Upload.FileName == "" && !FinalInterviewAttachment.Upload.KeepFile) {
                    FinalInterviewAttachment.AddErrorMessage(ConvertToString(FinalInterviewAttachment.RequiredErrorMessage).Replace("%s", FinalInterviewAttachment.Caption));
                }
            }
            if (PrincipalCommentAttachment.Required) {
                if (PrincipalCommentAttachment.Upload.FileName == "" && !PrincipalCommentAttachment.Upload.KeepFile) {
                    PrincipalCommentAttachment.AddErrorMessage(ConvertToString(PrincipalCommentAttachment.RequiredErrorMessage).Replace("%s", PrincipalCommentAttachment.Caption));
                }
            }
            if (FormPrintoutAttachment.Required) {
                if (FormPrintoutAttachment.Upload.FileName == "" && !FormPrintoutAttachment.Upload.KeepFile) {
                    FormPrintoutAttachment.AddErrorMessage(ConvertToString(FormPrintoutAttachment.RequiredErrorMessage).Replace("%s", FormPrintoutAttachment.Caption));
                }
            }
            if (AssistantManagerPdeReviewed.Required) {
                if (Empty(AssistantManagerPdeReviewed.FormValue)) {
                    AssistantManagerPdeReviewed.AddErrorMessage(ConvertToString(AssistantManagerPdeReviewed.RequiredErrorMessage).Replace("%s", AssistantManagerPdeReviewed.Caption));
                }
            }
            if (CrewingManagerApproval.Required) {
                if (Empty(CrewingManagerApproval.FormValue)) {
                    CrewingManagerApproval.AddErrorMessage(ConvertToString(CrewingManagerApproval.RequiredErrorMessage).Replace("%s", CrewingManagerApproval.Caption));
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
                if (InterviewAttachment.Upload.FileName == "" && !InterviewAttachment.Upload.KeepFile) {
                    InterviewAttachment.AddErrorMessage(ConvertToString(InterviewAttachment.RequiredErrorMessage).Replace("%s", InterviewAttachment.Caption));
                }
            }
            if (ApprovedByUserID1.Required) {
                if (!ApprovedByUserID1.IsDetailKey && Empty(ApprovedByUserID1.FormValue)) {
                    ApprovedByUserID1.AddErrorMessage(ConvertToString(ApprovedByUserID1.RequiredErrorMessage).Replace("%s", ApprovedByUserID1.Caption));
                }
            }
            if (!CheckInteger(ApprovedByUserID1.FormValue)) {
                ApprovedByUserID1.AddErrorMessage(ApprovedByUserID1.GetErrorMessage(false));
            }
            if (ApprovedByUserID2.Required) {
                if (!ApprovedByUserID2.IsDetailKey && Empty(ApprovedByUserID2.FormValue)) {
                    ApprovedByUserID2.AddErrorMessage(ConvertToString(ApprovedByUserID2.RequiredErrorMessage).Replace("%s", ApprovedByUserID2.Caption));
                }
            }
            if (!CheckInteger(ApprovedByUserID2.FormValue)) {
                ApprovedByUserID2.AddErrorMessage(ApprovedByUserID2.GetErrorMessage(false));
            }

            // Validate detail grid
            var detailTblVar = CurrentDetailTables;
            if (detailTblVar.Contains("TRChecklistPerformance") && trChecklistPerformance?.DetailAdd == true) {
                trChecklistPerformanceGrid = Resolve("TrChecklistPerformanceGrid")!; // Get detail page object
                if (trChecklistPerformanceGrid != null)
                    validateForm = validateForm && await trChecklistPerformanceGrid.ValidateGridForm();
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
                // DocumentDate
                DocumentDate.SetDbValue(rsnew, ConvertToDateTime(DocumentDate.CurrentValue, DocumentDate.FormatPattern));

                // Activity10
                Activity10.SetDbValue(rsnew, ConvertToBool(Activity10.CurrentValue));

                // Activity11
                Activity11.SetDbValue(rsnew, ConvertToBool(Activity11.CurrentValue));

                // Activity12
                Activity12.SetDbValue(rsnew, ConvertToBool(Activity12.CurrentValue));

                // Activity13
                Activity13.SetDbValue(rsnew, ConvertToBool(Activity13.CurrentValue));

                // Activity14
                Activity14.SetDbValue(rsnew, ConvertToBool(Activity14.CurrentValue));

                // Activity20
                Activity20.SetDbValue(rsnew, ConvertToBool(Activity20.CurrentValue));

                // Activity30
                Activity30.SetDbValue(rsnew, ConvertToBool(Activity30.CurrentValue));

                // Activity40
                Activity40.SetDbValue(rsnew, ConvertToBool(Activity40.CurrentValue));

                // Activity50
                Activity50.SetDbValue(rsnew, ConvertToBool(Activity50.CurrentValue));

                // Activity60
                Activity60.SetDbValue(rsnew, ConvertToBool(Activity60.CurrentValue));

                // Activity70
                Activity70.SetDbValue(rsnew, ConvertToBool(Activity70.CurrentValue));

                // InterviewerComment
                InterviewerComment.SetDbValue(rsnew, InterviewerComment.CurrentValue);

                // FinalInterviewComment
                FinalInterviewComment.SetDbValue(rsnew, FinalInterviewComment.CurrentValue);

                // JobKnowledge
                JobKnowledge.SetDbValue(rsnew, JobKnowledge.CurrentValue);

                // SafetyAwareness
                SafetyAwareness.SetDbValue(rsnew, SafetyAwareness.CurrentValue);

                // Personality
                Personality.SetDbValue(rsnew, Personality.CurrentValue);

                // EnglishProficiency
                EnglishProficiency.SetDbValue(rsnew, EnglishProficiency.CurrentValue);

                // PrincipalComment
                PrincipalComment.SetDbValue(rsnew, PrincipalComment.CurrentValue);

                // CreatedByUserID
                CreatedByUserID.SetDbValue(rsnew, CreatedByUserID.CurrentValue);

                // CreatedDateTime
                CreatedDateTime.SetDbValue(rsnew, ConvertToDateTimeOffset(CreatedDateTime.CurrentValue, DateTimeStyles.AssumeUniversal));

                // LastUpdatedByUserID
                LastUpdatedByUserID.SetDbValue(rsnew, LastUpdatedByUserID.CurrentValue);

                // LastUpdatedDateTime
                LastUpdatedDateTime.SetDbValue(rsnew, ConvertToDateTimeOffset(LastUpdatedDateTime.CurrentValue, DateTimeStyles.AssumeUniversal));

                // RemarkActivity10
                RemarkActivity10.SetDbValue(rsnew, RemarkActivity10.CurrentValue);

                // RemarkActivity11
                RemarkActivity11.SetDbValue(rsnew, RemarkActivity11.CurrentValue);

                // RemarkActivity12
                RemarkActivity12.SetDbValue(rsnew, RemarkActivity12.CurrentValue);

                // RemarkActivity13
                RemarkActivity13.SetDbValue(rsnew, RemarkActivity13.CurrentValue);

                // RemarkActivity14
                RemarkActivity14.SetDbValue(rsnew, RemarkActivity14.CurrentValue);

                // RemarkActivity20
                RemarkActivity20.SetDbValue(rsnew, RemarkActivity20.CurrentValue);

                // RemarkActivity30
                RemarkActivity30.SetDbValue(rsnew, RemarkActivity30.CurrentValue);

                // RemarkActivity40
                RemarkActivity40.SetDbValue(rsnew, RemarkActivity40.CurrentValue);

                // RemarkActivity50
                RemarkActivity50.SetDbValue(rsnew, RemarkActivity50.CurrentValue);

                // RemarkActivity60
                RemarkActivity60.SetDbValue(rsnew, RemarkActivity60.CurrentValue);

                // RemarkActivity70
                RemarkActivity70.SetDbValue(rsnew, RemarkActivity70.CurrentValue);

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.SetDbValue(rsnew, InterviewedByPersonOneName.CurrentValue);

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.SetDbValue(rsnew, InterviewedByPersonOneRank.CurrentValue);

                // InterviewedByPersonOneDate
                InterviewedByPersonOneDate.SetDbValue(rsnew, ConvertToDateTime(InterviewedByPersonOneDate.CurrentValue, InterviewedByPersonOneDate.FormatPattern));

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.SetDbValue(rsnew, ConvertToDateTime(AssistantManagerPdeReviewedDate.CurrentValue, AssistantManagerPdeReviewedDate.FormatPattern));

                // InterviewedByPersonTwoName
                InterviewedByPersonTwoName.SetDbValue(rsnew, InterviewedByPersonTwoName.CurrentValue);

                // InterviewedByPersonTwoRank
                InterviewedByPersonTwoRank.SetDbValue(rsnew, InterviewedByPersonTwoRank.CurrentValue);

                // InterviewedByPersonTwoDate
                InterviewedByPersonTwoDate.SetDbValue(rsnew, ConvertToDateTime(InterviewedByPersonTwoDate.CurrentValue, InterviewedByPersonTwoDate.FormatPattern));

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.SetDbValue(rsnew, InterviewedByPersonThreeName.CurrentValue);

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.SetDbValue(rsnew, InterviewedByPersonThreeRank.CurrentValue);

                // InterviewedByPersonThreeDate
                InterviewedByPersonThreeDate.SetDbValue(rsnew, ConvertToDateTime(InterviewedByPersonThreeDate.CurrentValue, InterviewedByPersonThreeDate.FormatPattern));

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.SetDbValue(rsnew, ConvertToDateTime(CrewingManagerApprovalDate.CurrentValue, CrewingManagerApprovalDate.FormatPattern));

                // Activity14Attachment
                if (Activity14Attachment.Visible && !Activity14Attachment.Upload.KeepFile) {
                    Activity14Attachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(Activity14Attachment.Upload.FileName)) {
                        rsnew["Activity14Attachment"] = DbNullValue;
                    } else {
                        rsnew["Activity14Attachment"] = Activity14Attachment.Upload.FileName;
                    }
                }

                // Activity20Attachment
                if (Activity20Attachment.Visible && !Activity20Attachment.Upload.KeepFile) {
                    Activity20Attachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(Activity20Attachment.Upload.FileName)) {
                        rsnew["Activity20Attachment"] = DbNullValue;
                    } else {
                        rsnew["Activity20Attachment"] = Activity20Attachment.Upload.FileName;
                    }
                }

                // Activity30Attachment
                if (Activity30Attachment.Visible && !Activity30Attachment.Upload.KeepFile) {
                    Activity30Attachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(Activity30Attachment.Upload.FileName)) {
                        rsnew["Activity30Attachment"] = DbNullValue;
                    } else {
                        rsnew["Activity30Attachment"] = Activity30Attachment.Upload.FileName;
                    }
                }

                // Activity50Attachment
                if (Activity50Attachment.Visible && !Activity50Attachment.Upload.KeepFile) {
                    Activity50Attachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(Activity50Attachment.Upload.FileName)) {
                        rsnew["Activity50Attachment"] = DbNullValue;
                    } else {
                        rsnew["Activity50Attachment"] = Activity50Attachment.Upload.FileName;
                    }
                }

                // Activity70Attachment
                if (Activity70Attachment.Visible && !Activity70Attachment.Upload.KeepFile) {
                    Activity70Attachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(Activity70Attachment.Upload.FileName)) {
                        rsnew["Activity70Attachment"] = DbNullValue;
                    } else {
                        rsnew["Activity70Attachment"] = Activity70Attachment.Upload.FileName;
                    }
                }

                // InterviewedByPersonOneAttachment
                InterviewedByPersonOneAttachment.SetDbValue(rsnew, InterviewedByPersonOneAttachment.CurrentValue);

                // InterviewedByPersonTwoAttachment
                InterviewedByPersonTwoAttachment.SetDbValue(rsnew, InterviewedByPersonTwoAttachment.CurrentValue);

                // InterviewedByPersonThreeAttachment
                InterviewedByPersonThreeAttachment.SetDbValue(rsnew, InterviewedByPersonThreeAttachment.CurrentValue);

                // FinalInterviewAttachment
                if (FinalInterviewAttachment.Visible && !FinalInterviewAttachment.Upload.KeepFile) {
                    FinalInterviewAttachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(FinalInterviewAttachment.Upload.FileName)) {
                        rsnew["FinalInterviewAttachment"] = DbNullValue;
                    } else {
                        rsnew["FinalInterviewAttachment"] = FinalInterviewAttachment.Upload.FileName;
                    }
                }

                // PrincipalCommentAttachment
                if (PrincipalCommentAttachment.Visible && !PrincipalCommentAttachment.Upload.KeepFile) {
                    PrincipalCommentAttachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(PrincipalCommentAttachment.Upload.FileName)) {
                        rsnew["PrincipalCommentAttachment"] = DbNullValue;
                    } else {
                        rsnew["PrincipalCommentAttachment"] = PrincipalCommentAttachment.Upload.FileName;
                    }
                }

                // FormPrintoutAttachment
                if (FormPrintoutAttachment.Visible && !FormPrintoutAttachment.Upload.KeepFile) {
                    FormPrintoutAttachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(FormPrintoutAttachment.Upload.FileName)) {
                        rsnew["FormPrintoutAttachment"] = DbNullValue;
                    } else {
                        rsnew["FormPrintoutAttachment"] = FormPrintoutAttachment.Upload.FileName;
                    }
                }

                // AssistantManagerPdeReviewed
                AssistantManagerPdeReviewed.SetDbValue(rsnew, ConvertToBool(AssistantManagerPdeReviewed.CurrentValue), Empty(AssistantManagerPdeReviewed.CurrentValue));

                // CrewingManagerApproval
                CrewingManagerApproval.SetDbValue(rsnew, ConvertToBool(CrewingManagerApproval.CurrentValue), Empty(CrewingManagerApproval.CurrentValue));

                // InterviewDate
                InterviewDate.SetDbValue(rsnew, ConvertToDateTime(InterviewDate.CurrentValue, InterviewDate.FormatPattern));

                // InterviewAttachment
                if (InterviewAttachment.Visible && !InterviewAttachment.Upload.KeepFile) {
                    InterviewAttachment.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(InterviewAttachment.Upload.FileName)) {
                        rsnew["InterviewAttachment"] = DbNullValue;
                    } else {
                        rsnew["InterviewAttachment"] = InterviewAttachment.Upload.FileName;
                    }
                }

                // ApprovedByUserID1
                ApprovedByUserID1.SetDbValue(rsnew, ApprovedByUserID1.CurrentValue);

                // ApprovedByUserID2
                ApprovedByUserID2.SetDbValue(rsnew, ApprovedByUserID2.CurrentValue);
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }
            if (Activity14Attachment.Visible && !Activity14Attachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(Activity14Attachment.Upload.DbValue) ? new () : new () { Activity14Attachment.HtmlDecode(Activity14Attachment.Upload.DbValue) };
                if (!Empty(Activity14Attachment.Upload.FileName)) {
                    var newFiles = new string[] { Activity14Attachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(Activity14Attachment, Activity14Attachment.Upload.Index);
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
                                var folders = new[] { Activity14Attachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(Activity14Attachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(Activity14Attachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    Activity14Attachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    Activity14Attachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    Activity14Attachment.SetDbValue(rsnew, Activity14Attachment.Upload.FileName);
                }
            }
            if (Activity20Attachment.Visible && !Activity20Attachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(Activity20Attachment.Upload.DbValue) ? new () : new () { Activity20Attachment.HtmlDecode(Activity20Attachment.Upload.DbValue) };
                if (!Empty(Activity20Attachment.Upload.FileName)) {
                    var newFiles = new string[] { Activity20Attachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(Activity20Attachment, Activity20Attachment.Upload.Index);
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
                                var folders = new[] { Activity20Attachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(Activity20Attachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(Activity20Attachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    Activity20Attachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    Activity20Attachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    Activity20Attachment.SetDbValue(rsnew, Activity20Attachment.Upload.FileName);
                }
            }
            if (Activity30Attachment.Visible && !Activity30Attachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(Activity30Attachment.Upload.DbValue) ? new () : new () { Activity30Attachment.HtmlDecode(Activity30Attachment.Upload.DbValue) };
                if (!Empty(Activity30Attachment.Upload.FileName)) {
                    var newFiles = new string[] { Activity30Attachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(Activity30Attachment, Activity30Attachment.Upload.Index);
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
                                var folders = new[] { Activity30Attachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(Activity30Attachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(Activity30Attachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    Activity30Attachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    Activity30Attachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    Activity30Attachment.SetDbValue(rsnew, Activity30Attachment.Upload.FileName);
                }
            }
            if (Activity50Attachment.Visible && !Activity50Attachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(Activity50Attachment.Upload.DbValue) ? new () : new () { Activity50Attachment.HtmlDecode(Activity50Attachment.Upload.DbValue) };
                if (!Empty(Activity50Attachment.Upload.FileName)) {
                    var newFiles = new string[] { Activity50Attachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(Activity50Attachment, Activity50Attachment.Upload.Index);
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
                                var folders = new[] { Activity50Attachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(Activity50Attachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(Activity50Attachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    Activity50Attachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    Activity50Attachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    Activity50Attachment.SetDbValue(rsnew, Activity50Attachment.Upload.FileName);
                }
            }
            if (Activity70Attachment.Visible && !Activity70Attachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(Activity70Attachment.Upload.DbValue) ? new () : new () { Activity70Attachment.HtmlDecode(Activity70Attachment.Upload.DbValue) };
                if (!Empty(Activity70Attachment.Upload.FileName)) {
                    var newFiles = new string[] { Activity70Attachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(Activity70Attachment, Activity70Attachment.Upload.Index);
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
                                var folders = new[] { Activity70Attachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(Activity70Attachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(Activity70Attachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    Activity70Attachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    Activity70Attachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    Activity70Attachment.SetDbValue(rsnew, Activity70Attachment.Upload.FileName);
                }
            }
            if (FinalInterviewAttachment.Visible && !FinalInterviewAttachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(FinalInterviewAttachment.Upload.DbValue) ? new () : new () { FinalInterviewAttachment.HtmlDecode(FinalInterviewAttachment.Upload.DbValue) };
                if (!Empty(FinalInterviewAttachment.Upload.FileName)) {
                    var newFiles = new string[] { FinalInterviewAttachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(FinalInterviewAttachment, FinalInterviewAttachment.Upload.Index);
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
                                var folders = new[] { FinalInterviewAttachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(FinalInterviewAttachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(FinalInterviewAttachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    FinalInterviewAttachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    FinalInterviewAttachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    FinalInterviewAttachment.SetDbValue(rsnew, FinalInterviewAttachment.Upload.FileName);
                }
            }
            if (PrincipalCommentAttachment.Visible && !PrincipalCommentAttachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(PrincipalCommentAttachment.Upload.DbValue) ? new () : new () { PrincipalCommentAttachment.HtmlDecode(PrincipalCommentAttachment.Upload.DbValue) };
                if (!Empty(PrincipalCommentAttachment.Upload.FileName)) {
                    var newFiles = new string[] { PrincipalCommentAttachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(PrincipalCommentAttachment, PrincipalCommentAttachment.Upload.Index);
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
                                var folders = new[] { PrincipalCommentAttachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(PrincipalCommentAttachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(PrincipalCommentAttachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    PrincipalCommentAttachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    PrincipalCommentAttachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    PrincipalCommentAttachment.SetDbValue(rsnew, PrincipalCommentAttachment.Upload.FileName);
                }
            }
            if (FormPrintoutAttachment.Visible && !FormPrintoutAttachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(FormPrintoutAttachment.Upload.DbValue) ? new () : new () { FormPrintoutAttachment.HtmlDecode(FormPrintoutAttachment.Upload.DbValue) };
                if (!Empty(FormPrintoutAttachment.Upload.FileName)) {
                    var newFiles = new string[] { FormPrintoutAttachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(FormPrintoutAttachment, FormPrintoutAttachment.Upload.Index);
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
                                var folders = new[] { FormPrintoutAttachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(FormPrintoutAttachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(FormPrintoutAttachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    FormPrintoutAttachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    FormPrintoutAttachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    FormPrintoutAttachment.SetDbValue(rsnew, FormPrintoutAttachment.Upload.FileName);
                }
            }
            if (InterviewAttachment.Visible && !InterviewAttachment.Upload.KeepFile) {
                List<string> oldFiles = Empty(InterviewAttachment.Upload.DbValue) ? new () : new () { InterviewAttachment.HtmlDecode(InterviewAttachment.Upload.DbValue) };
                if (!Empty(InterviewAttachment.Upload.FileName)) {
                    var newFiles = new string[] { InterviewAttachment.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(InterviewAttachment, InterviewAttachment.Upload.Index);
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
                                var folders = new[] { InterviewAttachment.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(InterviewAttachment.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(InterviewAttachment.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    InterviewAttachment.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    InterviewAttachment.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    InterviewAttachment.SetDbValue(rsnew, InterviewAttachment.Upload.FileName);
                }
            }

            // Update current values
            SetCurrentValues(rsnew);

            // Begin transaction
            if (!Empty(CurrentDetailTable) && UseTransaction)
                Connection.BeginTrans();

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
                if (result) {
                    if (Activity14Attachment.Visible && !Activity14Attachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(Activity14Attachment.Upload.DbValue) ? new string[] {} : new string[] { Activity14Attachment.HtmlDecode(Activity14Attachment.Upload.DbValue) };
                        if (!Empty(Activity14Attachment.Upload.FileName)) {
                            newFiles = new string[] { Activity14Attachment.Upload.FileName };
                            var newFiles2 = new string[] { Activity14Attachment.HtmlDecode(ConvertToString(rsnew["Activity14Attachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(Activity14Attachment, Activity14Attachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await Activity14Attachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(Activity14Attachment.OldPhysicalUploadPath + oldFiles[i]);
                            }
                        }
                    }
                    if (Activity20Attachment.Visible && !Activity20Attachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(Activity20Attachment.Upload.DbValue) ? new string[] {} : new string[] { Activity20Attachment.HtmlDecode(Activity20Attachment.Upload.DbValue) };
                        if (!Empty(Activity20Attachment.Upload.FileName)) {
                            newFiles = new string[] { Activity20Attachment.Upload.FileName };
                            var newFiles2 = new string[] { Activity20Attachment.HtmlDecode(ConvertToString(rsnew["Activity20Attachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(Activity20Attachment, Activity20Attachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await Activity20Attachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(Activity20Attachment.OldPhysicalUploadPath + oldFiles[i]);
                            }
                        }
                    }
                    if (Activity30Attachment.Visible && !Activity30Attachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(Activity30Attachment.Upload.DbValue) ? new string[] {} : new string[] { Activity30Attachment.HtmlDecode(Activity30Attachment.Upload.DbValue) };
                        if (!Empty(Activity30Attachment.Upload.FileName)) {
                            newFiles = new string[] { Activity30Attachment.Upload.FileName };
                            var newFiles2 = new string[] { Activity30Attachment.HtmlDecode(ConvertToString(rsnew["Activity30Attachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(Activity30Attachment, Activity30Attachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await Activity30Attachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(Activity30Attachment.OldPhysicalUploadPath + oldFiles[i]);
                            }
                        }
                    }
                    if (Activity50Attachment.Visible && !Activity50Attachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(Activity50Attachment.Upload.DbValue) ? new string[] {} : new string[] { Activity50Attachment.HtmlDecode(Activity50Attachment.Upload.DbValue) };
                        if (!Empty(Activity50Attachment.Upload.FileName)) {
                            newFiles = new string[] { Activity50Attachment.Upload.FileName };
                            var newFiles2 = new string[] { Activity50Attachment.HtmlDecode(ConvertToString(rsnew["Activity50Attachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(Activity50Attachment, Activity50Attachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await Activity50Attachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(Activity50Attachment.OldPhysicalUploadPath + oldFiles[i]);
                            }
                        }
                    }
                    if (Activity70Attachment.Visible && !Activity70Attachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(Activity70Attachment.Upload.DbValue) ? new string[] {} : new string[] { Activity70Attachment.HtmlDecode(Activity70Attachment.Upload.DbValue) };
                        if (!Empty(Activity70Attachment.Upload.FileName)) {
                            newFiles = new string[] { Activity70Attachment.Upload.FileName };
                            var newFiles2 = new string[] { Activity70Attachment.HtmlDecode(ConvertToString(rsnew["Activity70Attachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(Activity70Attachment, Activity70Attachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await Activity70Attachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(Activity70Attachment.OldPhysicalUploadPath + oldFiles[i]);
                            }
                        }
                    }
                    if (FinalInterviewAttachment.Visible && !FinalInterviewAttachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(FinalInterviewAttachment.Upload.DbValue) ? new string[] {} : new string[] { FinalInterviewAttachment.HtmlDecode(FinalInterviewAttachment.Upload.DbValue) };
                        if (!Empty(FinalInterviewAttachment.Upload.FileName)) {
                            newFiles = new string[] { FinalInterviewAttachment.Upload.FileName };
                            var newFiles2 = new string[] { FinalInterviewAttachment.HtmlDecode(ConvertToString(rsnew["FinalInterviewAttachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(FinalInterviewAttachment, FinalInterviewAttachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await FinalInterviewAttachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(FinalInterviewAttachment.OldPhysicalUploadPath + oldFiles[i]);
                            }
                        }
                    }
                    if (PrincipalCommentAttachment.Visible && !PrincipalCommentAttachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(PrincipalCommentAttachment.Upload.DbValue) ? new string[] {} : new string[] { PrincipalCommentAttachment.HtmlDecode(PrincipalCommentAttachment.Upload.DbValue) };
                        if (!Empty(PrincipalCommentAttachment.Upload.FileName)) {
                            newFiles = new string[] { PrincipalCommentAttachment.Upload.FileName };
                            var newFiles2 = new string[] { PrincipalCommentAttachment.HtmlDecode(ConvertToString(rsnew["PrincipalCommentAttachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(PrincipalCommentAttachment, PrincipalCommentAttachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await PrincipalCommentAttachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(PrincipalCommentAttachment.OldPhysicalUploadPath + oldFiles[i]);
                            }
                        }
                    }
                    if (FormPrintoutAttachment.Visible && !FormPrintoutAttachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(FormPrintoutAttachment.Upload.DbValue) ? new string[] {} : new string[] { FormPrintoutAttachment.HtmlDecode(FormPrintoutAttachment.Upload.DbValue) };
                        if (!Empty(FormPrintoutAttachment.Upload.FileName)) {
                            newFiles = new string[] { FormPrintoutAttachment.Upload.FileName };
                            var newFiles2 = new string[] { FormPrintoutAttachment.HtmlDecode(ConvertToString(rsnew["FormPrintoutAttachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(FormPrintoutAttachment, FormPrintoutAttachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await FormPrintoutAttachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(FormPrintoutAttachment.OldPhysicalUploadPath + oldFiles[i]);
                            }
                        }
                    }
                    if (InterviewAttachment.Visible && !InterviewAttachment.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(InterviewAttachment.Upload.DbValue) ? new string[] {} : new string[] { InterviewAttachment.HtmlDecode(InterviewAttachment.Upload.DbValue) };
                        if (!Empty(InterviewAttachment.Upload.FileName)) {
                            newFiles = new string[] { InterviewAttachment.Upload.FileName };
                            var newFiles2 = new string[] { InterviewAttachment.HtmlDecode(ConvertToString(rsnew["InterviewAttachment"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(InterviewAttachment, InterviewAttachment.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await InterviewAttachment.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(InterviewAttachment.OldPhysicalUploadPath + oldFiles[i]);
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

            // Add detail records
            var detailTblVar = CurrentDetailTables;
            if (result) {
                if (detailTblVar.Contains("TRChecklistPerformance") && trChecklistPerformance?.DetailAdd == true) {
                    trChecklistPerformance.TRChecklistID.SessionValue = ConvertToString(ID.CurrentValue); // Set master key
                    trChecklistPerformanceGrid = Resolve("TrChecklistPerformanceGrid")!; // Get detail page object
                    if (trChecklistPerformanceGrid != null) {
                        Security.LoadCurrentUserLevel(ProjectID + "TRChecklistPerformance"); // Load user level of detail table
                        result = await trChecklistPerformanceGrid.GridInsert();
                        Security.LoadCurrentUserLevel(ProjectID + TableName); // Restore user level of master table
                    }
                }
            }

            // Commit/Rollback transaction
            if (!Empty(CurrentDetailTable) && UseTransaction) {
                if (result) {
                    Connection.CommitTrans(); // Commit transaction
                } else {
                    Connection.RollbackTrans(); // Rollback transaction
                }
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

        // Set up detail parms based on QueryString
        protected void SetupDetailParms() {
            StringValues detailTblVar = "";
            // Get the keys for master table
            if (Query.TryGetValue(Config.TableShowDetail, out detailTblVar)) { // Do not use Get()
                CurrentDetailTable = detailTblVar.ToString();
            } else {
                detailTblVar = CurrentDetailTable;
            }
            if (!Empty(detailTblVar)) {
                var detailTblVars = detailTblVar.ToString().Split(',');
                if (detailTblVars.Contains("TRChecklistPerformance")) {
                    trChecklistPerformanceGrid = Resolve("TrChecklistPerformanceGrid")!;
                    if (trChecklistPerformanceGrid?.DetailAdd ?? false) {
                        if (CopyRecord)
                            trChecklistPerformanceGrid.CurrentMode = "copy";
                        else
                            trChecklistPerformanceGrid.CurrentMode = "add";
                        trChecklistPerformanceGrid.CurrentAction = "gridadd";

                        // Save current master table to detail table
                        trChecklistPerformanceGrid.CurrentMasterTable = TableVar;
                        trChecklistPerformanceGrid.StartRecordNumber = 1;
                        trChecklistPerformanceGrid.TRChecklistID.IsDetailKey = true;
                        trChecklistPerformanceGrid.TRChecklistID.CurrentValue = ID.CurrentValue;
                        trChecklistPerformanceGrid.TRChecklistID.SessionValue = trChecklistPerformanceGrid.TRChecklistID.CurrentValue;
                    }
                }
            }
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("TrChecklistList")), "", TableVar, true);
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
