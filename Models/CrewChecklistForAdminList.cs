namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewChecklistForAdminList
    /// </summary>
    public static CrewChecklistForAdminList crewChecklistForAdminList
    {
        get => HttpData.Get<CrewChecklistForAdminList>("crewChecklistForAdminList")!;
        set => HttpData["crewChecklistForAdminList"] = value;
    }

    /// <summary>
    /// Page class for CrewChecklistForAdmin
    /// </summary>
    public class CrewChecklistForAdminList : CrewChecklistForAdminListBase
    {
        // Constructor
        public CrewChecklistForAdminList(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewChecklistForAdminList() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewChecklistForAdminListBase : CrewChecklistForAdmin
    {
        // Page ID
        public string PageID = "list";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewChecklistForAdmin";

        // Page object name
        public string PageObjName = "crewChecklistForAdminList";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fCrewChecklistForAdminlist";

        public string FormActionName = "";

        public string FormBlankRowName = "";

        public string FormKeyCountName = "";

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
        public CrewChecklistForAdminListBase()
        {
            // CSS class name as context
            TableVar = "CrewChecklistForAdmin";
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);
            FormActionName = Config.FormRowActionName;
            FormBlankRowName = Config.FormBlankRowName;
            FormKeyCountName = Config.FormKeyCountName;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

            // CSS class name as context
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);

            // Language object
            Language = ResolveLanguage();

            // Table object (crewChecklistForAdmin)
            if (crewChecklistForAdmin == null || crewChecklistForAdmin is CrewChecklistForAdmin)
                crewChecklistForAdmin = this;

            // Initialize URLs
            AddUrl = "CrewChecklistForAdminAdd?" + Config.TableShowDetail + "=";
            InlineAddUrl = PageUrl + "action=add";
            GridAddUrl = PageUrl + "action=gridadd";
            GridEditUrl = PageUrl + "action=gridedit";
            MultiEditUrl = PageUrl + "action=multiedit";
            MultiDeleteUrl = "CrewChecklistForAdminDelete";
            MultiUpdateUrl = "CrewChecklistForAdminUpdate";

            // Start time
            StartTime = Environment.TickCount;

            // Debug message
            LoadDebugMessage();

            // Open connection
            Conn = Connection; // DN

            // User table object (MTUser)
            UserTable = Resolve("usertable")!;
            UserTableConn = GetConnection(UserTable.DbId);

            // Other options
            OtherOptions["addedit"] = new () {
                TagClassName = "ew-add-edit-option",
                UseDropDownButton = false,
                DropDownButtonPhrase = "ButtonAddEdit",
                UseButtonGroup = true
            };

            // Other options
            OtherOptions["detail"] = new () { TagClassName = "ew-detail-option" };
            OtherOptions["action"] = new () { TagClassName = "ew-action-option" };

            // Column visibility
            OtherOptions["column"] = new () {
                TableVar = TableVar,
                TagClassName = "ew-columns-option",
                ButtonGroupClass = "ew-column-dropdown",
                UseDropDownButton = true,
                DropDownButtonPhrase = "Columns",
                DropDownAutoClose = "outside",
                UseButtonGroup = false
            };
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
        public string PageName => "CrewChecklistForAdminList";

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

        // Update URLs
        public string InlineAddUrl = "";

        public string GridAddUrl = "";

        public string GridEditUrl = "";

        public string MultiEditUrl = "";

        public string MultiDeleteUrl = "";

        public string MultiUpdateUrl = "";

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
            Activity10.Visible = false;
            RemarkActivity10.Visible = false;
            Activity11.Visible = false;
            RemarkActivity11.Visible = false;
            Activity12.Visible = false;
            RemarkActivity12.Visible = false;
            Activity13.Visible = false;
            RemarkActivity13.Visible = false;
            Activity14.Visible = false;
            RemarkActivity14.Visible = false;
            Activity20.Visible = false;
            RemarkActivity20.Visible = false;
            Activity30.Visible = false;
            RemarkActivity30.Visible = false;
            Activity40.Visible = false;
            RemarkActivity40.Visible = false;
            Activity50.Visible = false;
            RemarkActivity50.Visible = false;
            Activity60.Visible = false;
            RemarkActivity60.Visible = false;
            Activity70.Visible = false;
            RemarkActivity70.Visible = false;
            InterviewerComment.Visible = false;
            JobKnowledge.Visible = false;
            SafetyAwareness.Visible = false;
            Personality.Visible = false;
            EnglishProficiency.Visible = false;
            PrincipalComment.Visible = false;
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            FinalInterviewComment.Visible = false;
            InterviewedByPersonOneName.Visible = false;
            InterviewedByPersonOneRank.Visible = false;
            AssistantManagerPdeReviewedDate.Visible = false;
            InterviewedByPersonTwoName.Visible = false;
            InterviewedByPersonTwoRank.Visible = false;
            InterviewedByPersonThreeName.Visible = false;
            InterviewedByPersonThreeRank.Visible = false;
            CrewingManagerApprovalDate.Visible = false;
            Activity14Attachment.Visible = false;
            Activity20Attachment.Visible = false;
            Activity30Attachment.Visible = false;
            Activity50Attachment.Visible = false;
            Activity70Attachment.Visible = false;
            FinalInterviewAttachment.Visible = false;
            PrincipalCommentAttachment.Visible = false;
            FormPrintoutAttachment.Visible = false;
            AssistantManagerPdeReviewed.Visible = false;
            CrewingManagerApproval.Visible = false;
            InterviewDate.Visible = false;
            InterviewAttachment.Visible = false;
            ApprovedByUserID1.SetVisibility();
            ApprovedByUserID2.SetVisibility();
        }

        // Constructor
        public CrewChecklistForAdminListBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "CrewChecklistForAdminView" ? "1" : "0"); // If View page, no primary button
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

        /// <summary>
        /// Run chart
        /// </summary>
        /// <param name="chartVar">Chart variable name</param>
        /// <returns>Page result</returns>
        public async Task<IActionResult> RunChart(string chartVar = "") { // DN
            IActionResult res = await Run();
            DbChart? chart = ChartByParam(chartVar);
            if (!IsTerminated && chart != null) {
                string chartClass = (chart.PageBreakType == "before") ? "ew-chart-bottom" : "ew-chart-top";
                int chartWidth = Query.TryGetValue("width", out StringValues sv) ? ConvertToInt(sv) : -1;
                int chartHeight = Query.TryGetValue("height", out StringValues sv2) ? ConvertToInt(sv2) : -1;
                return Controller.Content(ConvertToString(await chart.Render(chartClass, chartWidth, chartHeight)), "text/html", Encoding.UTF8);
            }
            return res;
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
                            if (fld.DataType == DataType.Memo && fld.MemoMaxLength > 0 && !Empty(val))
                                val = TruncateMemo(val, fld.MemoMaxLength, fld.TruncateMemoRemoveHtml);
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
        private Pager? _pager; // DN

        public int SelectedCount = 0;

        public int SelectedIndex = 0;

        public int DisplayRecords = 20; // Number of display records

        public int StartRecord;

        public int StopRecord;

        public int TotalRecords = -1;

        public int RecordRange = 10;

        public string PageSizes = "10,20,50,100,-1"; // Page sizes (comma separated)

        public string DefaultSearchWhere = ""; // Default search WHERE clause

        public string SearchWhere = ""; // Search WHERE clause

        public string SearchPanelClass = "ew-search-panel collapse show"; // Search panel class

        public int SearchColumnCount = 0; // For extended search

        public int SearchFieldsPerRow = 1; // For extended search

        public int RecordCount = 0; // Record count

        public int InlineRowCount = 0;

        public int StartRowCount = 1;

        public List<Tuple<string, Dictionary<string, string>>> Attributes = new (); // Row attributes and cell attributes

        public object RowIndex = 0; // Row index

        public int KeyCount = 0; // Key count

        public string MultiColumnGridClass = "row-cols-md";

        public string MultiColumnEditClass = "col-12 w-100";

        public string MultiColumnCardClass = "card h-100 ew-card";

        public string MultiColumnListOptionsPosition = "bottom-start";

        public string DbMasterFilter = ""; // Master filter

        public string DbDetailFilter = ""; // Detail filter

        public bool MasterRecordExists;

        public string MultiSelectKey = "";

        public string UserAction = ""; // User action

        public bool RestoreSearch = false;

        public SubPages? DetailPages; // Detail pages object

        public DbDataReader? Recordset;

        public string TopContentClass = "ew-top";

        public string MiddleContentClass = "ew-middle";

        public string BottomContentClass = "ew-bottom";

        public List<string> RecordKeys = new ();

        public bool IsModal = false;

        private string FilterForModalActions = "";

        private bool UseInfiniteScroll = false;

        // Pager
        public Pager Pager
        {
            get {
                _pager ??= new PrevNextPager(this, StartRecord, RecordsPerPage, TotalRecords, PageSizes, RecordRange, AutoHidePager, AutoHidePageSizeSelector);
                return _pager;
            }
        }

        /// <summary>
        /// Load recordset from filter
        /// <param name="filter">Record filter</param>
        /// </summary>
        public async Task LoadRecordsetFromFilter(string filter)
        {
            // Set up list options
            await SetupListOptions();

            // Search options
            SetupSearchOptions();

            // Other options
            SetupOtherOptions();

            // Set visibility
            SetVisibility();

            // Load recordset
            TotalRecords = LoadRecordCount(filter);
            StartRecord = 1;
            StopRecord = DisplayRecords;
            CurrentFilter = filter;
            Recordset = await LoadRecordset();
        }

        #pragma warning disable 219
        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            // Multi column button position
            MultiColumnListOptionsPosition = Config.MultiColumnListOptionsPosition;
            DashboardReport = DashboardReport || Param<bool>(Config.PageDashboard);

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

            // Get export parameters
            string custom = "";
            if (!Empty(Param("export"))) {
                Export = Param("export");
                custom = Param("custom");
            } else {
                ExportReturnUrl = CurrentUrl();
            }
            ExportType = Export; // Get export parameter, used in header
            if (!Empty(ExportType))
                SkipHeaderFooter = true;
            if (!Empty(Export) && !SameText(Export, "print") && Empty(custom)) // No layout for export // DN
                UseLayout = false;
            CurrentAction = Param("action"); // Set up current action

            // Get grid add count
            int gridaddcnt = Get<int>(Config.TableGridAddRowCount);
            if (gridaddcnt > 0)
                GridAddRowCount = gridaddcnt;

            // Set up list options
            await SetupListOptions();

            // Setup export options
            SetupExportOptions();

            // Setup import options
            SetupImportOptions();
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

            // Setup other options
            SetupOtherOptions();

            // Set up custom action (compatible with old version)
            ListActions.Add(CustomActions);

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
            await SetupLookupOptions(ApprovedByUserID1);
            await SetupLookupOptions(ApprovedByUserID2);

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fCrewChecklistForAdmingrid";

            // Set up infinite scroll
            UseInfiniteScroll = Param<bool>("infinitescroll");

            // Search filters
            string srchAdvanced = ""; // Advanced search filter
            string srchBasic = ""; // Basic search filter
            string filter = ""; // Filter
            string query = ""; // Query builder

            // Get command
            Command = Get("cmd").ToLower();

            // Process list action first
            var result = await ProcessListAction();
            if (result is not EmptyResult) // Ajax request
                return result;

            // Set up records per page
            SetupDisplayRecords();

            // Handle reset command
            ResetCommand();

            // Set up Breadcrumb
            if (!IsExport())
                SetupBreadcrumb();

            // Process import
            if (IsImport) {
                if (!Config.Debug)
                    Response?.Clear();
                return await Import(Param(Config.ApiFileTokenName), Param<bool>("rollback"));
            }

            // Hide list options
            if (IsExport()) {
                ListOptions.HideAllOptions(new () {"sequence"});
                ListOptions.UseDropDownButton = false; // Disable drop down button
                ListOptions.UseButtonGroup = false; // Disable button group
            } else if (IsGridAdd || IsGridEdit || IsMultiEdit || IsConfirm) {
                ListOptions.HideAllOptions();
                ListOptions.UseDropDownButton = false; // Disable drop down button
                ListOptions.UseButtonGroup = false; // Disable button group
            }

            // Hide options
            if (IsExport() || !Empty(CurrentAction) || IsSearch) {
                ExportOptions.HideAllOptions();
                FilterOptions.HideAllOptions();
                ImportOptions.HideAllOptions();
            }

            // Hide other options
            if (IsExport()) {
                foreach (var (key, value) in OtherOptions)
                    value.HideAllOptions();
            }

            // Get default search criteria
            AddFilter(ref DefaultSearchWhere, BasicSearchWhere(true));
            AddFilter(ref DefaultSearchWhere, AdvancedSearchWhere(true));

            // Get basic search values
            LoadBasicSearchValues();

            // Get and validate search values for advanced search
            if (Empty(UserAction)) // Skip if user action
                LoadSearchValues(); // Get search values

            // Process filter list
            var filterResult = await ProcessFilterList();
            if (filterResult != null) {
                // Clean output buffer
                if (!Config.Debug)
                    Response?.Clear();
                return Controller.Json(filterResult);
            }
            if (!ValidateSearch()) {
                // Nothing to do
            }

            // Restore search parms from Session if not searching / reset / export
            if ((IsExport() || Command != "search" && Command != "reset" && Command != "resetall") && Command != "json" && CheckSearchParms())
                RestoreSearchParms();

            // Call Recordset SearchValidated event
            RecordsetSearchValidated();

            // Set up sorting order
            SetupSortOrder();

            // Get basic search criteria
            if (!HasInvalidFields())
                srchBasic = BasicSearchWhere();

            // Get search criteria for advanced search
            if (!HasInvalidFields())
                srchAdvanced = AdvancedSearchWhere();

            // Get query builder criteria
            query = QueryBuilderWhere();

            // Restore display records
            if (Command != "json" && (RecordsPerPage == -1 || RecordsPerPage > 0)) {
                DisplayRecords = RecordsPerPage; // Restore from Session
            } else {
                DisplayRecords = 20; // Load default
                RecordsPerPage = DisplayRecords; // Save default to session
            }

            // Load search default if no existing search criteria
            if (!CheckSearchParms() && Empty(query)) {
                // Load basic search from default
                BasicSearch.LoadDefault();
                if (!Empty(BasicSearch.Keyword))
                    srchBasic = BasicSearchWhere(); // Save to session

                // Load advanced search from default
                if (LoadAdvancedSearchDefault())
                    srchAdvanced = AdvancedSearchWhere(); // Save to session
            }

            // Restore search settings from Session
            if (!HasInvalidFields())
                LoadAdvancedSearch();

            // Build search criteria
            if (!Empty(query)) {
                AddFilter(ref SearchWhere, query);
            } else {
                AddFilter(ref SearchWhere, srchAdvanced);
                AddFilter(ref SearchWhere, srchBasic);
            }

            // Call Recordset Searching event
            RecordsetSearching(ref SearchWhere);

            // Save search criteria
            if (Command == "search" && !RestoreSearch) {
                SessionSearchWhere = SearchWhere; // Save to Session (rename as SessionSearchWhere property)
                StartRecord = 1; // Reset start record counter
                StartRecordNumber = StartRecord;
            } else if (Command != "json" && Empty(query)) {
                SearchWhere = SessionSearchWhere;
            }

            // Build filter
            filter = "";
            if (!Security.CanList)
                filter = "(0=1)"; // Filter all records
            AddFilter(ref filter, DbDetailFilter);
            AddFilter(ref filter, SearchWhere);

            // Set up filter
            if (Command == "json") {
                UseSessionForListSql = false; // Do not use session for ListSql
                CurrentFilter = filter;
            } else {
                SessionWhere = filter;
                CurrentFilter = "";
            }
            Filter = ApplyUserIDFilters(filter);
            if (IsGridAdd) {
                CurrentFilter = "0=1";
                StartRecord = 1;
                DisplayRecords = GridAddRowCount;
                TotalRecords = DisplayRecords;
                StopRecord = DisplayRecords;
            } else if ((IsEdit || IsCopy || IsInlineInserted || IsInlineUpdated) && UseInfiniteScroll) { // Get current record only
                CurrentFilter = IsInlineUpdated ? GetRecordFilter() : GetFilterFromRecordKeys();
                TotalRecords = ListRecordCount();
                StartRecord = 1;
                StopRecord = DisplayRecords;
                Recordset = await LoadRecordset();
            } else if (
                UseInfiniteScroll && IsGridInserted ||
                UseInfiniteScroll && (IsGridEdit || IsGridUpdated) ||
                IsMultiEdit ||
                UseInfiniteScroll && IsMultiUpdated
            ) { // Get current records only
                CurrentFilter = FilterForModalActions; // Restore filter
                TotalRecords = ListRecordCount();
                StartRecord = 1;
                StopRecord = DisplayRecords;
                Recordset = await LoadRecordset();
            } else {
                TotalRecords = await ListRecordCountAsync();
                StopRecord = DisplayRecords;
                StartRecord = 1;
                if (DisplayRecords <= 0 || (IsExport() && ExportAll)) // Display all records
                    DisplayRecords = TotalRecords;
                if (!(IsExport() && ExportAll)) // Set up start record position
                    SetupStartRecord();

                // Recordset
                bool selectLimit = UseSelectLimit;

                // Set up list action columns, must be before LoadRecordset // DN
                foreach (var (key, act) in ListActions.Items.Where(kvp => kvp.Value.Allowed)) {
                    if (act.Select == Config.ActionMultiple && ListOptions["checkbox"] is ListOption listOpt) { // Show checkbox column if multiple action
                        listOpt.Visible = true;
                    } else if (act.Select == Config.ActionSingle) { // Show list action column
                            ListOptions["listactions"]?.SetVisible(true); // Set visible if any list action is allowed
                    }
                }
                if (selectLimit)
                    Recordset = await LoadRecordset(StartRecord - 1, DisplayRecords);

                // Set no record found message
                if ((Empty(CurrentAction) || IsSearch) && TotalRecords == 0) {
                    if (!Security.CanList)
                        WarningMessage = DeniedMessage();
                    if (SearchWhere == "0=101")
                        WarningMessage = Language.Phrase("EnterSearchCriteria");
                    else
                        WarningMessage = Language.Phrase("NoRecord");
                }
            }

            // Search options
            SetupSearchOptions();

            // Set up search panel class
            if (!Empty(SearchWhere)) {
                if (!Empty(query)) { // Hide search panel if using QueryBuilder
                    SearchPanelClass = RemoveClass(SearchPanelClass, "show");
                } else {
                    SearchPanelClass = AppendClass(SearchPanelClass, "show");
                }
            }

            // API list action
            if (IsApi()) {
                if (CurrentPageName().EndsWith(Config.ApiListAction)) { // DN
                    if (!IsExport()) {
                        if (!Connection.SelectOffset && Recordset != null) { // DN
                            for (var i = 1; i <= StartRecord - 1; i++) // Move to first record
                                await Recordset.ReadAsync();
                        }
                        using (Recordset) {
                            return Controller.Json(new Dictionary<string, object> { {"success", true}, {TableVar, await GetRecordsFromRecordset(Recordset)}, {"totalRecordCount", TotalRecords}, {"version", Config.ProductVersion} });
                        }
                    }
                } else if (!Empty(FailureMessage)) {
                    return Controller.Json(new { success = false, error = GetFailureMessage() });
                }
                return new EmptyResult();
            }

            // Render other options
            RenderOtherOptions();

            // Set ReturnUrl in header if necessary
            if (TempData["Return-Url"] != null)
                AddHeader("Return-Url", ConvertToString(TempData["Return-Url"]));

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();

                // Page Render event
                crewChecklistForAdminList?.PageRender();
            }
            return PageResult();
        }
        #pragma warning restore 219

        // Get page number
        public int PageNumber => DisplayRecords > 0 && StartRecord > 0 ? ConvertToInt(Math.Ceiling((double)StartRecord / DisplayRecords)) : 1;

        // Set up number of records displayed per page
        protected void SetupDisplayRecords() {
            string wrk = Get(Config.TableRecordsPerPage);
            if (!Empty(wrk)) {
                if (IsNumeric(wrk)) {
                    DisplayRecords = ConvertToInt(wrk);
                } else {
                    if (SameText(wrk, "all")) { // Display all records
                        DisplayRecords = -1;
                    } else {
                        DisplayRecords = 20; // Non-numeric, load default
                    }
                }
                RecordsPerPage = DisplayRecords; // Save to Session
                // Reset start position
                StartRecord = 1;
                StartRecordNumber = StartRecord;
            }
        }

        // Exit inline mode
        protected void ClearInlineMode() {
            LastAction = CurrentAction; // Save last action
            CurrentAction = ""; // Clear action
            Session[Config.SessionInlineMode] = ""; // Clear inline mode
        }

        // Build filter for all keys
        protected string BuildKeyFilter() {
            string wrkFilter = "";

            // Update row index and get row key
            int rowindex = 1;
            CurrentForm.Index = rowindex;
            string thisKey = CurrentForm.GetValue(OldKeyName);
            while (!Empty(thisKey)) {
                SetKey(thisKey);
                if (!Empty(OldKey)) {
                    string filter = GetRecordFilter();
                    if (!Empty(wrkFilter))
                        wrkFilter += " OR ";
                    wrkFilter += filter;
                } else {
                    wrkFilter = "0=1";
                    break;
                }

                // Update row index and get row key
                rowindex++; // next row
                CurrentForm.Index = rowindex;
                thisKey = CurrentForm.GetValue(OldKeyName);
            }
            return wrkFilter;
        }

        // Check if empty row
        public bool EmptyRow() => false;

        #pragma warning disable 162, 1998
        // Get list of filters
        public async Task<string> GetFilterList()
        {
            string filterList = "";

            // Initialize
            var filters = new JObject(); // DN
            filters.Merge(JObject.Parse(CreatedByUserID.AdvancedSearch.ToJson())); // Field CreatedByUserID
            filters.Merge(JObject.Parse(CreatedDateTime.AdvancedSearch.ToJson())); // Field CreatedDateTime
            filters.Merge(JObject.Parse(LastUpdatedByUserID.AdvancedSearch.ToJson())); // Field LastUpdatedByUserID
            filters.Merge(JObject.Parse(LastUpdatedDateTime.AdvancedSearch.ToJson())); // Field LastUpdatedDateTime
            filters.Merge(JObject.Parse(ApprovedByUserID1.AdvancedSearch.ToJson())); // Field ApprovedByUserID1
            filters.Merge(JObject.Parse(ApprovedByUserID2.AdvancedSearch.ToJson())); // Field ApprovedByUserID2
            filters.Merge(JObject.Parse(BasicSearch.ToJson()));

            // Return filter list in JSON
            if (filters.HasValues)
                filterList = "\"data\":" + filters.ToString();
            return (filterList != "") ? "{" + filterList + "}" : "null";
        }

        // Process filter list
        protected async Task<object?> ProcessFilterList() {
            if (Post("cmd") == "resetfilter") {
                RestoreFilterList();
            }
            return null;
        }
        #pragma warning restore 162, 1998

        // Restore list of filters
        protected bool RestoreFilterList() {
            // Return if not reset filter
            if (Post("cmd") != "resetfilter")
                return false;
            var filter = JsonConvert.DeserializeObject<Dictionary<string, string>>(Post("filter"));
            Command = "search";
            string? sv;

            // Field CreatedByUserID
            if (filter?.TryGetValue("x_CreatedByUserID", out sv) ?? false) {
                CreatedByUserID.AdvancedSearch.SearchValue = sv;
                CreatedByUserID.AdvancedSearch.SearchOperator = filter["z_CreatedByUserID"];
                CreatedByUserID.AdvancedSearch.SearchCondition = filter["v_CreatedByUserID"];
                CreatedByUserID.AdvancedSearch.SearchValue2 = filter["y_CreatedByUserID"];
                CreatedByUserID.AdvancedSearch.SearchOperator2 = filter["w_CreatedByUserID"];
                CreatedByUserID.AdvancedSearch.Save();
            }

            // Field CreatedDateTime
            if (filter?.TryGetValue("x_CreatedDateTime", out sv) ?? false) {
                CreatedDateTime.AdvancedSearch.SearchValue = sv;
                CreatedDateTime.AdvancedSearch.SearchOperator = filter["z_CreatedDateTime"];
                CreatedDateTime.AdvancedSearch.SearchCondition = filter["v_CreatedDateTime"];
                CreatedDateTime.AdvancedSearch.SearchValue2 = filter["y_CreatedDateTime"];
                CreatedDateTime.AdvancedSearch.SearchOperator2 = filter["w_CreatedDateTime"];
                CreatedDateTime.AdvancedSearch.Save();
            }

            // Field LastUpdatedByUserID
            if (filter?.TryGetValue("x_LastUpdatedByUserID", out sv) ?? false) {
                LastUpdatedByUserID.AdvancedSearch.SearchValue = sv;
                LastUpdatedByUserID.AdvancedSearch.SearchOperator = filter["z_LastUpdatedByUserID"];
                LastUpdatedByUserID.AdvancedSearch.SearchCondition = filter["v_LastUpdatedByUserID"];
                LastUpdatedByUserID.AdvancedSearch.SearchValue2 = filter["y_LastUpdatedByUserID"];
                LastUpdatedByUserID.AdvancedSearch.SearchOperator2 = filter["w_LastUpdatedByUserID"];
                LastUpdatedByUserID.AdvancedSearch.Save();
            }

            // Field LastUpdatedDateTime
            if (filter?.TryGetValue("x_LastUpdatedDateTime", out sv) ?? false) {
                LastUpdatedDateTime.AdvancedSearch.SearchValue = sv;
                LastUpdatedDateTime.AdvancedSearch.SearchOperator = filter["z_LastUpdatedDateTime"];
                LastUpdatedDateTime.AdvancedSearch.SearchCondition = filter["v_LastUpdatedDateTime"];
                LastUpdatedDateTime.AdvancedSearch.SearchValue2 = filter["y_LastUpdatedDateTime"];
                LastUpdatedDateTime.AdvancedSearch.SearchOperator2 = filter["w_LastUpdatedDateTime"];
                LastUpdatedDateTime.AdvancedSearch.Save();
            }

            // Field ApprovedByUserID1
            if (filter?.TryGetValue("x_ApprovedByUserID1", out sv) ?? false) {
                ApprovedByUserID1.AdvancedSearch.SearchValue = sv;
                ApprovedByUserID1.AdvancedSearch.SearchOperator = filter["z_ApprovedByUserID1"];
                ApprovedByUserID1.AdvancedSearch.SearchCondition = filter["v_ApprovedByUserID1"];
                ApprovedByUserID1.AdvancedSearch.SearchValue2 = filter["y_ApprovedByUserID1"];
                ApprovedByUserID1.AdvancedSearch.SearchOperator2 = filter["w_ApprovedByUserID1"];
                ApprovedByUserID1.AdvancedSearch.Save();
            }

            // Field ApprovedByUserID2
            if (filter?.TryGetValue("x_ApprovedByUserID2", out sv) ?? false) {
                ApprovedByUserID2.AdvancedSearch.SearchValue = sv;
                ApprovedByUserID2.AdvancedSearch.SearchOperator = filter["z_ApprovedByUserID2"];
                ApprovedByUserID2.AdvancedSearch.SearchCondition = filter["v_ApprovedByUserID2"];
                ApprovedByUserID2.AdvancedSearch.SearchValue2 = filter["y_ApprovedByUserID2"];
                ApprovedByUserID2.AdvancedSearch.SearchOperator2 = filter["w_ApprovedByUserID2"];
                ApprovedByUserID2.AdvancedSearch.Save();
            }
            if (filter?.TryGetValue(Config.TableBasicSearch, out string? keyword) ?? false)
                BasicSearch.SessionKeyword = keyword;
            if (filter?.TryGetValue(Config.TableBasicSearchType, out string? type) ?? false)
                BasicSearch.SessionType = type;
            return true;
        }

        // Advanced search WHERE clause based on QueryString
        public string AdvancedSearchWhere(bool def = false) {
            string where = "";
            if (!Security.CanSearch)
                return "";
            BuildSearchSql(ref where, CreatedByUserID, def, true); // CreatedByUserID
            BuildSearchSql(ref where, CreatedDateTime, def, true); // CreatedDateTime
            BuildSearchSql(ref where, LastUpdatedByUserID, def, true); // LastUpdatedByUserID
            BuildSearchSql(ref where, LastUpdatedDateTime, def, true); // LastUpdatedDateTime
            BuildSearchSql(ref where, ApprovedByUserID1, def, false); // ApprovedByUserID1
            BuildSearchSql(ref where, ApprovedByUserID2, def, false); // ApprovedByUserID2

            // Set up search command
            if (!def && !Empty(where) && (new[] { "", "reset", "resetall" }).Contains(Command))
                Command = "search";
            if (!def && Command == "search") {
                CreatedByUserID.AdvancedSearch.Save(); // CreatedByUserID
                CreatedDateTime.AdvancedSearch.Save(); // CreatedDateTime
                LastUpdatedByUserID.AdvancedSearch.Save(); // LastUpdatedByUserID
                LastUpdatedDateTime.AdvancedSearch.Save(); // LastUpdatedDateTime
                ApprovedByUserID1.AdvancedSearch.Save(); // ApprovedByUserID1
                ApprovedByUserID2.AdvancedSearch.Save(); // ApprovedByUserID2

                // Clear rules for QueryBuilder
                SessionRules = "";
            }
            return where;
        }

        // Parse query builder rule function
        protected string ParseRules(Dictionary<string, object>? group, string fieldName = "") {
            if (group == null)
                return "";
            string condition = group.ContainsKey("condition") ? ConvertToString(group["condition"]) : "AND";
            if (!(new [] { "AND", "OR" }).Contains(condition))
                throw new System.Exception("Unable to build SQL query with condition '" + condition + "'");
            List<string> parts = new ();
            string where = "";
            var groupRules = group.ContainsKey("rules") ? group["rules"] : null;
            if (groupRules is IEnumerable<object> rules) {
                foreach (object rule in rules) {
                    var subRules = JObject.FromObject(rule).ToObject<Dictionary<string, object>>();
                    if (subRules == null)
                        continue;
                    if (subRules.ContainsKey("rules")) {
                        parts.Add("(" + " " + ParseRules(subRules, fieldName) + " " + ")" + " ");
                    } else {
                        string field = subRules.ContainsKey("field") ? ConvertToString(subRules["field"]) : "";
                        var fld = FieldByParam(field);
                        if (fld == null)
                            throw new System.Exception("Failed to find field '" + field + "'");
                        if (Empty(fieldName) || fld.Name == fieldName) { // Field name not specified or matched field name
                            string opr = subRules.ContainsKey("operator") ? ConvertToString(subRules["operator"]) : "";
                            string fldOpr = Config.ClientSearchOperators.FirstOrDefault(o => o.Value == opr).Key;
                            Dictionary<string, object>? ope = Config.QueryBuilderOperators.ContainsKey(opr) ? Config.QueryBuilderOperators[opr] : null;
                            if (ope == null || Empty(fldOpr))
                                throw new System.Exception("Unknown SQL operation for operator '" + opr + "'");
                            int nb_inputs = ope.ContainsKey("nb_inputs") ? ConvertToInt(ope["nb_inputs"]) : 0;
                            object val = subRules.ContainsKey("value") ? subRules["value"] : "";
                            if (nb_inputs > 0 && !Empty(val) || IsNullOrEmptyOperator(fldOpr)) {
                                string fldVal = val is List<object> list
                                    ? (list[0] is IEnumerable<string> ? String.Join(Config.MultipleOptionSeparator, list[0]) : ConvertToString(list[0]))
                                    : ConvertToString(val);
                                bool useFilter = fld.UseFilter; // Query builder does not use filter
                                try {
                                    if (fld.IsMultiSelect) {
                                        parts.Add(!Empty(fldVal) ? GetMultiSearchSql(fld, fldOpr, ConvertSearchValue(fldVal, fldOpr, fld), DbId) : "");
                                    } else {
                                        string fldVal2 = fldOpr.Contains("BETWEEN")
                                            ? (val is List<object> list2 && list2.Count > 1
                                                ? (list2[1] is IEnumerable<string> ? String.Join(Config.MultipleOptionSeparator, list2[1]) : ConvertToString(list2[1]))
                                                : "")
                                            : ""; // BETWEEN
                                        parts.Add(GetSearchSql(
                                            fld,
                                            ConvertSearchValue(fldVal, fldOpr, fld), // fldVal
                                            fldOpr,
                                            "", // fldCond not used
                                            ConvertSearchValue(fldVal2, fldOpr, fld), // $fldVal2
                                            "", // fldOpr2 not used
                                            DbId
                                        ));
                                    }
                                } finally {
                                    fld.UseFilter = useFilter;
                                }
                            }
                        }
                    }
                }
                where = String.Join(" " + condition + " ", parts);
                bool not = group.ContainsKey("not") ? ConvertToBool(group["not"]) : false;
                if (not)
                    where = "NOT (" + where + ")";
            }
            return where;
        }

        // Quey builder WHERE clause
        public string QueryBuilderWhere(string fieldName = "")
        {
            if (!Security.CanSearch)
                return "";

            // Get rules by query builder
            string rules = "";
            if (Post("rules", out StringValues sv))
                rules = sv.ToString();
            else
                rules = SessionRules;

            // Decode and parse rules
            string where = !Empty(rules) ? ParseRules(JsonConvert.DeserializeObject<Dictionary<string, object>>(rules), fieldName) : "";

            // Clear other search and save rules to session
            if (!Empty(where) && Empty(fieldName)) { // Skip if get query for specific field
                ResetSearchParms();
                SessionRules = rules;
            }

            // Return query
            return where;
        }

        // Build search SQL
        public void BuildSearchSql(ref string where, DbField fld, bool def, bool multiValue)
        {
            string fldParm = fld.Param;
            string fldVal = def ? ConvertToString(fld.AdvancedSearch.SearchValueDefault) : ConvertToString(fld.AdvancedSearch.SearchValue);
            string fldOpr = def ? fld.AdvancedSearch.SearchOperatorDefault : fld.AdvancedSearch.SearchOperator;
            string fldCond = def ? fld.AdvancedSearch.SearchConditionDefault : fld.AdvancedSearch.SearchCondition;
            string fldVal2 = def ? ConvertToString(fld.AdvancedSearch.SearchValue2Default) : ConvertToString(fld.AdvancedSearch.SearchValue2);
            string fldOpr2 = def ? fld.AdvancedSearch.SearchOperator2Default : fld.AdvancedSearch.SearchOperator2;
            fldVal = ConvertSearchValue(fldVal, fldOpr, fld);
            fldVal2 = ConvertSearchValue(fldVal2, fldOpr2, fld);
            fldOpr = ConvertSearchOperator(fldOpr, fld, fldVal);
            fldOpr2 = ConvertSearchOperator(fldOpr2, fld, fldVal2);
            string wrk = "";
            if (Config.SearchMultiValueOption == 1 && !fld.UseFilter || !IsMultiSearchOperator(fldOpr))
                multiValue = false;
            if (multiValue) {
                wrk = !Empty(fldVal) ? GetMultiSearchSql(fld, fldOpr, fldVal, DbId) : ""; // Field value 1
                string wrk2 = !Empty(fldVal2) ? GetMultiSearchSql(fld, fldOpr2, fldVal2, DbId) : ""; // Field value 2
                AddFilter(ref wrk, wrk2, fldCond);
            } else {
                wrk = GetSearchSql(fld, fldVal, fldOpr, fldCond, fldVal2, fldOpr2, DbId);
            }
            string cond = SearchOption == "AUTO" && (new[] {"AND", "OR"}).Contains(BasicSearch.Type)
                ? BasicSearch.Type
                : SameText(SearchOption, "OR") ? "OR" : "AND";
            AddFilter(ref where, wrk, cond);
        }

        // Show list of filters
        public void ShowFilterList()
        {
            // Initialize
            string filterList = "",
                filter = "",
                captionClass = IsExport("email") ? "ew-filter-caption-email" : "ew-filter-caption",
                captionSuffix = IsExport("email") ? ": " : "";

            // Field CreatedByUserID
            filter = QueryBuilderWhere("CreatedByUserID");
            if (Empty(filter))
                BuildSearchSql(ref filter, CreatedByUserID, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CreatedByUserID.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CreatedDateTime
            filter = QueryBuilderWhere("CreatedDateTime");
            if (Empty(filter))
                BuildSearchSql(ref filter, CreatedDateTime, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CreatedDateTime.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LastUpdatedByUserID
            filter = QueryBuilderWhere("LastUpdatedByUserID");
            if (Empty(filter))
                BuildSearchSql(ref filter, LastUpdatedByUserID, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LastUpdatedByUserID.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LastUpdatedDateTime
            filter = QueryBuilderWhere("LastUpdatedDateTime");
            if (Empty(filter))
                BuildSearchSql(ref filter, LastUpdatedDateTime, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LastUpdatedDateTime.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field ApprovedByUserID1
            filter = QueryBuilderWhere("ApprovedByUserID1");
            if (Empty(filter))
                BuildSearchSql(ref filter, ApprovedByUserID1, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + ApprovedByUserID1.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field ApprovedByUserID2
            filter = QueryBuilderWhere("ApprovedByUserID2");
            if (Empty(filter))
                BuildSearchSql(ref filter, ApprovedByUserID2, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + ApprovedByUserID2.Caption + "</span>" + captionSuffix + filter + "</div>";
            if (!Empty(BasicSearch.Keyword))
                filterList += "<div><span class=\"" + captionClass + "\">" + Language.Phrase("BasicSearchKeyword") + "</span>" + captionSuffix + BasicSearch.Keyword + "</div>";

            // Show Filters
            if (!Empty(filterList)) {
                string message = "<div id=\"ew-filter-list\" class=\"callout callout-info d-table\"><div id=\"ew-current-filters\">" +
                    Language.Phrase("CurrentFilters") + "</div>" + filterList + "</div>";
                MessageShowing(ref message, "");
                Write(message);
            } else { // Output empty tag
                Write("<div id=\"ew-filter-list\"></div>");
            }
        }

        // Return basic search WHERE clause based on search keyword and type
        public string BasicSearchWhere(bool def = false) {
            string searchStr = "";
            if (!Security.CanSearch)
                return "";

            // Fields to search
            List<DbField> searchFlds = new ();
            searchFlds.Add(CreatedByUserID);
            searchFlds.Add(CreatedDateTime);
            searchFlds.Add(LastUpdatedByUserID);
            searchFlds.Add(LastUpdatedDateTime);
            string searchKeyword = def ? BasicSearch.KeywordDefault : BasicSearch.Keyword;
            string searchType = def ? BasicSearch.TypeDefault : BasicSearch.Type;

            // Get search SQL
            if (!Empty(searchKeyword)) {
                List<string> list = BasicSearch.KeywordList(def);
                searchStr = GetQuickSearchFilter(searchFlds, list, searchType, BasicSearch.BasicSearchAnyFields, DbId);
                if (!def && (new[] {"", "reset", "resetall"}).Contains(Command))
                    Command = "search";
            }
            if (!def && Command == "search") {
                BasicSearch.SessionKeyword = searchKeyword;
                BasicSearch.SessionType = searchType;

                // Clear rules for QueryBuilder
                SessionRules = "";
            }
            return searchStr;
        }

        // Check if search parm exists
        protected bool CheckSearchParms() {
            // Check basic search
            if (BasicSearch.IssetSession)
                return true;
            if (CreatedByUserID.AdvancedSearch.IssetSession)
                return true;
            if (CreatedDateTime.AdvancedSearch.IssetSession)
                return true;
            if (LastUpdatedByUserID.AdvancedSearch.IssetSession)
                return true;
            if (LastUpdatedDateTime.AdvancedSearch.IssetSession)
                return true;
            if (ApprovedByUserID1.AdvancedSearch.IssetSession)
                return true;
            if (ApprovedByUserID2.AdvancedSearch.IssetSession)
                return true;
            return false;
        }

        // Clear all search parameters
        protected void ResetSearchParms() {
            SearchWhere = "";
            SessionSearchWhere = SearchWhere;

            // Clear basic search parameters
            ResetBasicSearchParms();

            // Clear advanced search parameters
            ResetAdvancedSearchParms();

            // Clear queryBuilder
            SessionRules = "";
        }

        // Load advanced search default values
        protected bool LoadAdvancedSearchDefault() {
        return false;
        }

        // Clear all basic search parameters
        protected void ResetBasicSearchParms() {
            BasicSearch.UnsetSession();
        }

        // Clear all advanced search parameters
        protected void ResetAdvancedSearchParms() {
            CreatedByUserID.AdvancedSearch.UnsetSession();
            CreatedDateTime.AdvancedSearch.UnsetSession();
            LastUpdatedByUserID.AdvancedSearch.UnsetSession();
            LastUpdatedDateTime.AdvancedSearch.UnsetSession();
            ApprovedByUserID1.AdvancedSearch.UnsetSession();
            ApprovedByUserID2.AdvancedSearch.UnsetSession();
        }

        // Restore all search parameters
        protected void RestoreSearchParms() {
            RestoreSearch = true;

            // Restore basic search values
            BasicSearch.Load();

            // Restore advanced search values
            CreatedByUserID.AdvancedSearch.Load();
            CreatedDateTime.AdvancedSearch.Load();
            LastUpdatedByUserID.AdvancedSearch.Load();
            LastUpdatedDateTime.AdvancedSearch.Load();
            ApprovedByUserID1.AdvancedSearch.Load();
            ApprovedByUserID2.AdvancedSearch.Load();
        }

        // Set up sort parameters
        protected void SetupSortOrder() {
            // Load default Sorting Order
            if (Command != "json") {
                string defaultSort = ""; // Set up default sort
                if (Empty(SessionOrderBy) && !Empty(defaultSort))
                    SessionOrderBy = defaultSort;
            }

            // Check for Ctrl pressed
            bool ctrl = Get<bool>("ctrl");

            // Check for "order" parameter
            if (Get("order", out StringValues sv)) {
                CurrentOrder = sv.ToString();
                CurrentOrderType = Get("ordertype");
                UpdateSort(CreatedByUserID, ctrl); // CreatedByUserID
                UpdateSort(CreatedDateTime, ctrl); // CreatedDateTime
                UpdateSort(LastUpdatedByUserID, ctrl); // LastUpdatedByUserID
                UpdateSort(LastUpdatedDateTime, ctrl); // LastUpdatedDateTime
                UpdateSort(ApprovedByUserID1, ctrl); // ApprovedByUserID1
                UpdateSort(ApprovedByUserID2, ctrl); // ApprovedByUserID2
                StartRecordNumber = 1; // Reset start position
            }

            // Update field sort
            UpdateFieldSort();
        }

        /// <summary>
        /// Reset command
        /// cmd=reset (Reset search parameters)
        /// cmd=resetall (Reset search and master/detail parameters)
        /// cmd=resetsort (Reset sort parameters)
        /// </summary>
        protected void ResetCommand() {
            // Get reset cmd
            if (Command.ToLower().StartsWith("reset")) {
                // Reset search criteria
                if (SameText(Command, "reset") || SameText(Command, "resetall"))
                    ResetSearchParms();

                // Reset (clear) sorting order
                if (SameText(Command, "resetsort")) {
                    string orderBy = "";
                    SessionOrderBy = orderBy;
                    ID.Sort = "";
                    MTCrewID.Sort = "";
                    Activity10.Sort = "";
                    RemarkActivity10.Sort = "";
                    Activity11.Sort = "";
                    RemarkActivity11.Sort = "";
                    Activity12.Sort = "";
                    RemarkActivity12.Sort = "";
                    Activity13.Sort = "";
                    RemarkActivity13.Sort = "";
                    Activity14.Sort = "";
                    RemarkActivity14.Sort = "";
                    Activity20.Sort = "";
                    RemarkActivity20.Sort = "";
                    Activity30.Sort = "";
                    RemarkActivity30.Sort = "";
                    Activity40.Sort = "";
                    RemarkActivity40.Sort = "";
                    Activity50.Sort = "";
                    RemarkActivity50.Sort = "";
                    Activity60.Sort = "";
                    RemarkActivity60.Sort = "";
                    Activity70.Sort = "";
                    RemarkActivity70.Sort = "";
                    InterviewerComment.Sort = "";
                    JobKnowledge.Sort = "";
                    SafetyAwareness.Sort = "";
                    Personality.Sort = "";
                    EnglishProficiency.Sort = "";
                    PrincipalComment.Sort = "";
                    CreatedByUserID.Sort = "";
                    CreatedDateTime.Sort = "";
                    LastUpdatedByUserID.Sort = "";
                    LastUpdatedDateTime.Sort = "";
                    FinalInterviewComment.Sort = "";
                    InterviewedByPersonOneName.Sort = "";
                    InterviewedByPersonOneRank.Sort = "";
                    AssistantManagerPdeReviewedDate.Sort = "";
                    InterviewedByPersonTwoName.Sort = "";
                    InterviewedByPersonTwoRank.Sort = "";
                    InterviewedByPersonThreeName.Sort = "";
                    InterviewedByPersonThreeRank.Sort = "";
                    CrewingManagerApprovalDate.Sort = "";
                    Activity14Attachment.Sort = "";
                    Activity20Attachment.Sort = "";
                    Activity30Attachment.Sort = "";
                    Activity50Attachment.Sort = "";
                    Activity70Attachment.Sort = "";
                    FinalInterviewAttachment.Sort = "";
                    PrincipalCommentAttachment.Sort = "";
                    FormPrintoutAttachment.Sort = "";
                    AssistantManagerPdeReviewed.Sort = "";
                    CrewingManagerApproval.Sort = "";
                    InterviewDate.Sort = "";
                    InterviewAttachment.Sort = "";
                    ApprovedByUserID1.Sort = "";
                    ApprovedByUserID2.Sort = "";
                }

                // Reset start position
                StartRecord = 1;
                StartRecordNumber = StartRecord;
            }
        }

        #pragma warning disable 1998
        // Set up list options
        protected async Task SetupListOptions() {
            ListOption item;

            // Add group option item
            item = ListOptions.AddGroupOption();
            item.Body = "";
            item.OnLeft = true;
            item.Visible = false;

            // "view"
            item = ListOptions.Add("view");
            item.CssClass = "text-nowrap";
            item.Visible = Security.CanView;
            item.OnLeft = true;

            // "edit"
            item = ListOptions.Add("edit");
            item.CssClass = "text-nowrap";
            item.Visible = Security.CanEdit;
            item.OnLeft = true;

            // "detail_TRChecklistPerformance"
            item = ListOptions.Add("detail_TRChecklistPerformance");
            item.CssClass = "text-nowrap";
            item.Visible = Security.AllowList(CurrentProjectID + "TRChecklistPerformance");
            item.OnLeft = true;
            item.ShowInButtonGroup = false;
            trChecklistPerformanceGrid = Resolve("TrChecklistPerformanceGrid")!;

            // Multiple details
            if (ShowMultipleDetails) {
                item = ListOptions.Add("details");
                item.CssClass = "text-nowrap";
                item.Visible = ShowMultipleDetails && ListOptions.DetailVisible();
                item.OnLeft = true;
                item.ShowInButtonGroup = false;
            }

            // Set up detail pages
            var _pages = new SubPages();
            _pages.Add("TRChecklistPerformance");
            DetailPages = _pages;

            // List actions
            item = ListOptions.Add("listactions");
            item.CssClass = "text-nowrap";
            item.OnLeft = true;
            item.Visible = false;
            item.ShowInButtonGroup = false;
            item.ShowInDropDown = false;

            // "checkbox"
            item = ListOptions.Add("checkbox");
            item.CssStyle = "white-space: nowrap; text-align: center; vertical-align: middle; margin: 0px;";
            item.Visible = false;
            item.OnLeft = true;
            item.Header = "<div class=\"form-check\"><input type=\"checkbox\" name=\"key\" id=\"key\" class=\"form-check-input\" data-ew-action=\"select-all-keys\"></div>";
            if (item.OnLeft)
                item.MoveTo(0);
            item.ShowInDropDown = false;
            item.ShowInButtonGroup = false;

            // "sequence"
            item = ListOptions.Add("sequence");
            item.CssClass = "text-nowrap";
            item.Visible = true;
            item.OnLeft = true; // Always on left
            item.ShowInDropDown = false;
            item.ShowInButtonGroup = false;

            // Drop down button for ListOptions
            ListOptions.UseDropDownButton = true;
            ListOptions.DropDownButtonPhrase = "ButtonListOptions";
            ListOptions.UseButtonGroup = false;
            if (ListOptions.UseButtonGroup && IsMobile())
                ListOptions.UseDropDownButton = true;

            //ListOptions.ButtonClass = ""; // Class for button group

            // Call ListOptions Load event
            ListOptionsLoad();
            SetupListOptionsExt();
            ListOptions[ListOptions.GroupOptionName]?.SetVisible(ListOptions.GroupOptionVisible);
        }
        #pragma warning restore 1998

        // Set up list options (extensions)
        protected void SetupListOptionsExt() {
            // Preview extension
            ListOptions.HideDetailItemsForDropDown(); // Hide detail items for dropdown if necessary
        }

        // Add "hash" parameter to URL
        public string UrlAddHash(string url, string hash)
        {
            return UseAjaxActions ? url : UrlAddQuery(url, "hash=" + hash);
        }

        // Render list options
        #pragma warning disable 168, 219, 1998

        public async Task RenderListOptions()
        {
            ListOption? listOption;
            bool isVisible = false; // DN
            ListOptions.LoadDefault();

            // Call ListOptions Rendering event
            ListOptionsRendering();

            // "sequence"
            listOption = ListOptions["sequence"];
            listOption?.SetBody(FormatSequenceNumber(RecordCount));

            // "view"
            listOption = ListOptions["view"];
            string viewcaption = Language.Phrase("ViewLink", true);
            isVisible = Security.CanView;
            if (isVisible) {
                if (ModalView && !IsMobile())
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-table=""CrewChecklistForAdmin"" data-caption=""{viewcaption}"" data-ew-action=""modal"" data-action=""view"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(ViewUrl)) + "\" data-btn=\"null\">" + Language.Phrase("ViewLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-caption=""{viewcaption}"" href=""" + HtmlEncode(AppPath(ViewUrl)) + "\">" + Language.Phrase("ViewLink") + "</a>");
            } else {
                listOption?.Clear();
            }

            // "edit"
            listOption = ListOptions["edit"];
            string editcaption = Language.Phrase("EditLink", true);
            isVisible = Security.CanEdit;
            if (isVisible) {
                if (ModalEdit && !IsMobile())
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-table=""CrewChecklistForAdmin"" data-caption=""{editcaption}"" data-ew-action=""modal"" data-action=""edit"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\" data-btn=\"SaveBtn\">" + Language.Phrase("EditLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-caption=""{editcaption}"" href=""" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("EditLink") + "</a>");
            } else {
                listOption?.Clear();
            }

            // Set up list action buttons
            listOption = ListOptions["listactions"];
            if (listOption != null && !IsExport() && CurrentAction == "") {
                string body = "";
                var links = new List<string>();
                foreach (var (key, act) in ListActions.Items) {
                    if (act.Select == Config.ActionSingle && act.Allowed) {
                        var action = act.Action;
                        string caption = act.Caption;
                        var icon = (act.Icon != "") ? "<i class=\"" + HtmlEncode(act.Icon.Replace(" ew-icon", "")) + "\" data-caption=\"" + HtmlTitle(caption) + "\"></i> " : "";
                        string link = "<li><button type=\"button\" class=\"dropdown-item ew-action ew-list-action\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fCrewChecklistForAdminlist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttrs() + ">" + icon + " " + caption + "</button></li>";
                        if (!Empty(link)) {
                            links.Add(link);
                            if (Empty(body)) // Setup first button
                                body = "<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlTitle(caption) + "\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fCrewChecklistForAdminlist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttrs() + ">" + icon + caption + "</button>";
                        }
                    }
                }
                if (links.Count > 1) { // More than one buttons, use dropdown
                    body = "<button type=\"button\" class=\"dropdown-toggle btn btn-default ew-actions\" title=\"" + Language.Phrase("ListActionButton", true) + "\" data-bs-toggle=\"dropdown\">" + Language.Phrase("ListActionButton") + "</button>";
                    string content = links.Aggregate("", (result, link) => result + "<li>" + link + "</li>");
                    body += "<ul class=\"dropdown-menu" + (listOption?.OnLeft ?? false ? "" : " dropdown-menu-right") + "\">" + content + "</ul>";
                    body = "<div class=\"btn-group btn-group-sm\">" + body + "</div>";
                }
                if (links.Count > 0)
                    listOption?.SetBody(body);
            }
            var detailViewTblVar = "";
            var detailCopyTblVar = "";
            var detailEditTblVar = "";
            dynamic? detailPage = null;
            string detailFilter = "";

            // "detail_TRChecklistPerformance"
            listOption = ListOptions["detail_TRChecklistPerformance"];
            isVisible = Security.AllowList(CurrentProjectID + "TRChecklistPerformance");
            if (isVisible) {
                string caption, title, url;
                var body = Language.Phrase("DetailLink") + Language.TablePhrase("TRChecklistPerformance", "TblCaption");
                body = "<a class=\"btn btn-default ew-row-link ew-detail" + (ListOptions.UseDropDownButton ? " dropdown-toggle" : "") + "\" data-action=\"list\" href=\"" + HtmlEncode(AppPath("TrChecklistPerformanceList?" + Config.TableShowMaster + "=CrewChecklistForAdmin&" + ForeignKeyUrl("fk_ID", ID.CurrentValue) + "")) + "\">" + body + "</a>";
                string links = "";
                detailPage = Resolve("TrChecklistPerformanceGrid")!;
                if (detailPage?.DetailView && Security.CanView && Security.AllowView(CurrentProjectID + "CrewChecklistForAdmin") ?? false) {
                    caption = Language.Phrase("MasterDetailViewLink", null);
                    title = Language.Phrase("MasterDetailViewLink", true);
                    url = GetViewUrl(Config.TableShowDetail + "=TRChecklistPerformance");
                    links += "<li><a class=\"dropdown-item ew-row-link ew-detail-view\" data-action=\"view\" data-caption=\"" + title + "\" href=\"" + HtmlEncode(AppPath(url)) + "\">" + caption + "</a></li>";
                    if (!Empty(detailViewTblVar))
                        detailViewTblVar += ",";
                    detailViewTblVar += "TRChecklistPerformance";
                }
                if (detailPage?.DetailEdit && Security.CanEdit && Security.AllowEdit(CurrentProjectID + "CrewChecklistForAdmin") ?? false) {
                    caption = Language.Phrase("MasterDetailEditLink", null);
                    title = Language.Phrase("MasterDetailEditLink", true);
                    url = GetEditUrl(Config.TableShowDetail + "=TRChecklistPerformance");
                    links += "<li><a class=\"dropdown-item ew-row-link ew-detail-edit\" data-action=\"edit\" data-caption=\"" + title + "\" href=\"" + HtmlEncode(AppPath(url)) + "\">" + caption + "</a></li>";
                    if (!Empty(detailEditTblVar))
                        detailEditTblVar += ",";
                    detailEditTblVar += "TRChecklistPerformance";
                }
                if (!Empty(links)) {
                    body += "<button type=\"button\" class=\"dropdown-toggle btn btn-default ew-detail\" data-bs-toggle=\"dropdown\"></button>";
                    body += "<ul class=\"dropdown-menu\">" + links + "</ul>";
                } else {
                    body = Regex.Replace(body, @"\b\s+dropdown-toggle\b", "");
                }
                body = "<div class=\"btn-group btn-group-sm ew-btn-group\">" + body + "</div>";
                listOption?.SetBody(body);
                if (ShowMultipleDetails)
                    listOption?.SetVisible(false);
            }
            if (ShowMultipleDetails) {
                var body = Language.Phrase("MultipleMasterDetails");
                body = "<div class=\"btn-group btn-group-sm ew-btn-group\">";
                string links = "";
                if (!Empty(detailViewTblVar)) {
                    links += "<li><a class=\"dropdown-item ew-row-link ew-detail-view\" data-action=\"view\" data-caption=\"" + HtmlEncode(Language.Phrase("MasterDetailViewLink", true)) + "\" href=\"" + HtmlEncode(AppPath(GetViewUrl(Config.TableShowDetail + "=" + detailViewTblVar))) + "\">" + Language.Phrase("MasterDetailViewLink", null) + "</a></li>";
                }
                if (!Empty(detailEditTblVar)) {
                    links += "<li><a class=\"dropdown-item ew-row-link ew-detail-edit\" data-action=\"edit\" data-caption=\"" + HtmlEncode(Language.Phrase("MasterDetailEditLink", true)) + "\" href=\"" + HtmlEncode(AppPath(GetEditUrl(Config.TableShowDetail + "=" + detailEditTblVar))) + "\">" + Language.Phrase("MasterDetailEditLink", null) + "</a></li>";
                }
                if (!Empty(detailCopyTblVar)) {
                    links += "<li><a class=\"dropdown-item ew-row-link ew-detail-copy\" data-action=\"add\" data-caption=\"" + HtmlEncode(Language.Phrase("MasterDetailCopyLink", true)) + "\" href=\"" + HtmlEncode(AppPath(GetCopyUrl(Config.TableShowDetail + "=" + detailCopyTblVar))) + "\">" + Language.Phrase("MasterDetailCopyLink", null) + "</a></li>";
                }
                if (!Empty(links)) {
                    body += "<button type=\"button\" class=\"dropdown-toggle btn btn-default ew-master-detail\" title=\"" + HtmlEncode(Language.Phrase("MultipleMasterDetails", true)) + "\" data-bs-toggle=\"dropdown\">" + Language.Phrase("MultipleMasterDetails") + "</button>";
                    body += "<ul class=\"dropdown-menu ew-dropdown-menu\">" + links + "</ul>";
                }
                body += "</div>";
                // Multiple details
                listOption = ListOptions["details"];
                listOption?.SetBody(body);
            }

            // "checkbox"
            listOption = ListOptions["checkbox"];
            listOption?.SetBody("<div class=\"form-check\"><input type=\"checkbox\" id=\"key_m_" + RowCount + "\" name=\"key_m[]\" class=\"form-check-input ew-multi-select\" value=\"" + HtmlEncode(ID.CurrentValue) + "\" data-ew-action=\"select-key\"></div>");
            RenderListOptionsExt();

            // Call ListOptions Rendered event
            ListOptionsRendered();
        }

        // Render list options (extensions)
        protected void RenderListOptionsExt() {
            // Preview extension
            string links = "", btngrps = "", sqlwrk, detaillnk, link, url, btngrp, caption, title, icon, detailFilter;
            ListOption? option;
            dynamic? detailTbl = null, detailPage = null;
            sqlwrk = KeyFilter(Resolve("TRChecklistPerformance")!.TRChecklistID, ID.CurrentValue, ID.DataType, DbId);

            // Column "detail_TRChecklistPerformance"
            if ((DetailPages?["TRChecklistPerformance"]?.Visible ?? false) && Security.AllowList(CurrentProjectID + "TRChecklistPerformance")) {
                link = "";
                option = ListOptions["detail_TRChecklistPerformance"];
                url = "TrChecklistPerformancePreview?t=CrewChecklistForAdmin&f=" + Encrypt(sqlwrk);
                btngrp = "<ul data-table=\"TRChecklistPerformance\" data-url=\"" + AppPath(url) + "\" class=\"ew-detail-btn-group dropdown-menu\">";
                if (Security.AllowList(CurrentProjectID + "CrewChecklistForAdmin")) {
                    string label = Language.TablePhrase("TRChecklistPerformance", "TblCaption");
                    link = "<button class=\"nav-link\" data-bs-toggle=\"tab\" data-table=\"TRChecklistPerformance\" data-url=\"" + AppPath(url) + "\" type=\"button\" role=\"tab\" aria-selected=\"false\">" + label + "</button>";
                    detaillnk = AppPath("TrChecklistPerformanceList?" + Config.TableShowMaster + "=CrewChecklistForAdmin&" + ForeignKeyUrl("fk_ID", ID.CurrentValue) + "");
                    title = Language.TablePhrase("TRChecklistPerformance", "TblCaption");
                    caption = Language.Phrase("MasterDetailListLink");
                    caption += "&nbsp;" + title;
                    btngrp += "<a class=\"dropdown-item\" href=\"#\" data-ew-action=\"redirect\" data-url=\"" + HtmlEncode(detaillnk) + "\">" + caption + "</a>";
                }
                detailPage = Resolve("TrChecklistPerformanceGrid")!;
                if (detailPage?.DetailView && Security.CanView && Security.AllowView(CurrentProjectID + "CrewChecklistForAdmin") ?? false) {
                    caption = Language.Phrase("MasterDetailViewLink", null);
                    title = Language.Phrase("MasterDetailViewLink", true);
                    url = AppPath(GetViewUrl(Config.TableShowDetail + "=TRChecklistPerformance"));
                    btngrp += "<a class=\"dropdown-item\" href=\"#\" data-ew-action=\"redirect\" data-url=\"" + HtmlEncode(url) + "\">" + caption + "</a>";
                }
                if (detailPage?.DetailEdit && Security.CanEdit && Security.AllowEdit(CurrentProjectID + "CrewChecklistForAdmin") ?? false) {
                    caption = Language.Phrase("MasterDetailEditLink", null);
                    title = Language.Phrase("MasterDetailEditLink", true);
                    url = AppPath(GetEditUrl(Config.TableShowDetail + "=TRChecklistPerformance"));
                    btngrp += "<a class=\"dropdown-item\" href=\"#\" data-ew-action=\"redirect\" data-url=\"" + HtmlEncode(url) + "\">" + caption + "</a>";
                }
                btngrp += "</ul>";
                if (link != "") {
                    link = "<li class=\"nav-item\">" + btngrp + link + "</li>";  // Note: Place btngrp before link
                    links += link;
                    option?.AddBody("<div class=\"ew-preview d-none\">" + link + "</div>");
                }
            }

            // Add row attributes for expandable row
            if (RowType == RowType.View) {
                RowAttrs["data-widget"] = "expandable-table";
                RowAttrs["aria-expanded"] = "false";
            }

            // Column "preview"
            option = ListOptions["preview"];
            if (option == null) { // Add preview column
                option = ListOptions.Add("preview");
                option.OnLeft = true;
                option.MoveTo(option.OnLeft ? ListOptions.GetItemIndex("checkbox") + 1 : ListOptions.GetItemIndex("checkbox"));
                option.Visible = !(IsExport() || IsGridAdd || IsGridEdit || IsMultiEdit);
                option.ShowInDropDown = false;
                option.ShowInButtonGroup = false;
            }
            icon = "fas fa-caret-right"; // Right
            if (SameText(GetPropertyValue(this, "MultiColumnLayout"), "table")) {
                option.CssStyle = "width: 1%;";
                if (!option.OnLeft)
                    icon = Regex.Replace(icon, @"\bright\b", "left");
            }
            if (IsRTL) { // Reverse
                if (Regex.IsMatch(icon, @"\bleft\b"))
                    icon = Regex.Replace(icon, @"\bleft\b", "right");
                else if (Regex.IsMatch(icon, @"\bright\b"))
                    icon = Regex.Replace(icon, @"\bright\b", "left");
            }
            option.SetBody("<i role=\"button\" class=\"ew-preview-btn expandable-table-caret ew-icon " + icon + "\"></i>" +
                "<div class=\"ew-preview d-none\">" + links + "</div>");
            if (option.Visible)
                option.Visible = links != "";

            // Column "details" (Multiple details)
            option = ListOptions["details"];
            option?.AddBody("<div class=\"ew-preview d-none\">" + links + "</div>");
            if (option?.Visible ?? false)
                option.Visible = links != "";
        }

        // Set up other options
        protected void SetupOtherOptions() {
            ListOptions option;
            ListOption item;
            var options = OtherOptions;
            option = options["action"];

            // Show column list for column visibility
            if (UseColumnVisibility) {
                option = OtherOptions["column"];
                item = option.AddGroupOption();
                item.Body = "";
                item.Visible = UseColumnVisibility;
                CreateColumnOption(option.Add("CreatedByUserID")); // DN
                CreateColumnOption(option.Add("CreatedDateTime")); // DN
                CreateColumnOption(option.Add("LastUpdatedByUserID")); // DN
                CreateColumnOption(option.Add("LastUpdatedDateTime")); // DN
                CreateColumnOption(option.Add("ApprovedByUserID1")); // DN
                CreateColumnOption(option.Add("ApprovedByUserID2")); // DN
            }

            // Set up options default
            foreach (var (key, opt) in options) {
                if (key != "column") { // Always use dropdown for column
                    opt.UseDropDownButton = true;
                    opt.UseButtonGroup = true;
                }
                //opt.ButtonClass = ""; // Class for button group
                item = opt.AddGroupOption();
                item.Body = "";
                item.Visible = false;
            }
            options["addedit"].DropDownButtonPhrase = "ButtonAddEdit";
            options["detail"].DropDownButtonPhrase = "ButtonDetails";
            options["action"].DropDownButtonPhrase = "ButtonActions";

            // Filter button
            item = FilterOptions.Add("savecurrentfilter");
            item.Body = "<a class=\"ew-save-filter\" data-form=\"fCrewChecklistForAdminsrch\" data-ew-action=\"none\">" + Language.Phrase("SaveCurrentFilter") + "</a>";
            item.Visible = true;
            item = FilterOptions.Add("deletefilter");
            item.Body = "<a class=\"ew-delete-filter\" data-form=\"fCrewChecklistForAdminsrch\" data-ew-action=\"none\">" + Language.Phrase("DeleteFilter") + "</a>";
            item.Visible = true;
            FilterOptions.UseDropDownButton = true;
            FilterOptions.UseButtonGroup = !FilterOptions.UseDropDownButton;
            FilterOptions.DropDownButtonPhrase = "Filters";

            // Add group option item
            item = FilterOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;
        }

        // Create new column option // DN
        public void CreateColumnOption(ListOption item)
        {
            var field = FieldByName(item.Name);
            if (field?.Visible ?? false) {
                item.Body = "<button class=\"dropdown-item\">" +
                    "<div class=\"form-check ew-dropdown-checkbox\">" +
                    "<div class=\"form-check-input ew-dropdown-check-input\" data-field=\"" + field.Param + "\"></div>" +
                    "<label class=\"form-check-label ew-dropdown-check-label\">" + field.Caption + "</label></div></button>";
            }
        }

        // Render other options
        public void RenderOtherOptions()
        {
            ListOptions option;
            ListOption? item;
            var options = OtherOptions;
                option = options["action"];

                // Set up list action buttons
                foreach (var (key, act) in ListActions.Items.Where(kvp => kvp.Value.Select == Config.ActionMultiple)) {
                    item = option.Add("custom_" + act.Action);
                    string caption = act.Caption;
                    var icon = (act.Icon != "") ? "<i class=\"" + HtmlEncode(act.Icon) + "\" data-caption=\"" + HtmlEncode(caption) + "\"></i>" + caption : caption;
                    item.Body = "<<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlEncode(caption) + "\" data-caption=\"" + HtmlEncode(caption) + "\" data-ew-action=\"submit\" form=\"fCrewChecklistForAdminlist\"" + act.ToDataAttrs() + ">" + icon + "</button>";
                    item.Visible = act.Allowed;
                }

                // Hide multi edit, grid edit and other options
                if (TotalRecords <= 0) {
                    option = options["addedit"];
                    option?["gridedit"]?.SetVisible(false);
                    option = options["action"];
                    option.HideAllOptions();
                }
        }

        // Process list action
        public async Task<IActionResult> ProcessListAction()
        {
            string filter = GetFilterFromRecordKeys();
            string userAction = Post("action");
            if (filter != "" && userAction != "") {
                // Check permission first
                string actionCaption = userAction;
                foreach (var (key, act) in ListActions.Items) {
                    if (SameString(key, userAction)) {
                        actionCaption = act.Caption;
                        if (CustomActions.ContainsKey(userAction)) {
                            UserAction = userAction;
                            CurrentAction = "";
                        }
                        if (!act.Allowed) {
                            string errmsg = Language.Phrase("CustomActionNotAllowed").Replace("%s", actionCaption);
                            if (Post("ajax") == userAction) // Ajax
                                return Controller.Content("<p class=\"text-danger\">" + errmsg + "</p>", "text/plain", Encoding.UTF8);
                            else
                                FailureMessage = errmsg;
                            return new EmptyResult();
                        }
                    }
                }
                CurrentFilter = filter;
                string sql = CurrentSql;
                var rsuser = await Connection.GetRowsAsync(sql);
                ActionValue = Post("actionvalue");

                // Call row custom action event
                if (rsuser != null) {
                    if (UseTransaction)
                        Connection.BeginTrans();
                    bool processed = true;
                    SelectedCount = rsuser.Count();
                    SelectedIndex = 0;
                    foreach (var row in rsuser) {
                        SelectedIndex++;
                        processed = RowCustomAction(userAction, row);
                        if (!processed)
                            break;
                    }
                    if (processed) {
                        if (UseTransaction)
                            Connection.CommitTrans(); // Commit the changes
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("CustomActionCompleted").Replace("%s", actionCaption); // Set up success message
                    } else {
                        if (UseTransaction)
                            Connection.RollbackTrans(); // Rollback changes

                        // Set up error message
                        if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {
                            // Use the message, do nothing
                        } else if (!Empty(CancelMessage)) {
                            FailureMessage = CancelMessage;
                            CancelMessage = "";
                        } else {
                            FailureMessage = Language.Phrase("CustomActionFailed").Replace("%s", actionCaption);
                        }
                    }
                }
                CurrentAction = ""; // Clear action
                if (Post("ajax") == userAction) { // Ajax
                    if (ActionResult != null) // Action result set by Row CustomAction event // DN
                        return ActionResult;
                    string msg = "";
                    if (SuccessMessage != "") {
                        msg = "<p class=\"text-success\">" + SuccessMessage + "</p>";
                        ClearSuccessMessage(); // Clear message
                    }
                    if (FailureMessage != "") {
                        msg = "<p class=\"text-danger\">" + FailureMessage + "</p>";
                        ClearFailureMessage(); // Clear message
                    }
                    if (!Empty(msg))
                        return Controller.Content(msg, "text/plain", Encoding.UTF8);
                }
            }
            return new EmptyResult(); // Not ajax request
        }

        // Set up Grid
        public async Task SetupGrid()
        {
            if (ExportAll && IsExport()) {
                StopRecord = TotalRecords;
            } else {
                // Set the last record to display
                if (TotalRecords > StartRecord + DisplayRecords - 1) {
                    StopRecord = StartRecord + DisplayRecords - 1;
                } else {
                    StopRecord = TotalRecords;
                }
            }
            if (Recordset != null && Recordset.HasRows) {
                if (!Connection.SelectOffset) { // DN
                    for (int i = 1; i <= StartRecord - 1; i++) { // Move to first record
                        if (await Recordset.ReadAsync())
                            RecordCount++;
                    }
                } else {
                    RecordCount = StartRecord - 1;
                }
            } else if (IsGridAdd && !AllowAddDeleteRow && StopRecord == 0) { // Grid-Add with no records
                StopRecord = GridAddRowCount;
            } else if (IsAdd && TotalRecords == 0) { // Inline-Add with no records
                StopRecord = 1;
            }

            // Initialize aggregate
            RowType = RowType.AggregateInit;
            ResetAttributes();
            await RenderRow();
            if ((IsGridAdd || IsGridEdit)) // Render template row first
                RowIndex = "$rowindex$";
        }

        // Set up Row
        public async Task SetupRow()
        {
            if (IsGridAdd || IsGridEdit) {
                if (SameString(RowIndex, "$rowindex$")) { // Render template row first
                    await LoadRowValues();

                    // Set row properties
                    ResetAttributes();
                    RowAttrs.Add("data-rowindex", ConvertToString(RowIndex));
                    RowAttrs.Add("id", "r0_CrewChecklistForAdmin");
                    RowAttrs.Add("data-rowtype", ConvertToString((int)RowType.Add));
                    RowAttrs.Add("data-inline", (IsAdd || IsCopy || IsEdit) ? "true" : "false");
                    RowAttrs.AppendClass("ew-template");

                    // Render row
                    RowType = RowType.Add;
                    await RenderRow();

                    // Render list options
                    await RenderListOptions();

                    // Reset record count for template row
                    RecordCount--;
                    return;
                }
            }

            // Set up key count
            KeyCount = ConvertToInt(RowIndex);

            // Init row class and style
            ResetAttributes();
            CssClass = "";
            if (IsCopy && InlineRowCount == 0 && !await LoadRow()) { // Inline copy
                CurrentAction = "add";
            }
            if (IsAdd && InlineRowCount == 0 || IsGridAdd) {
                await LoadRowValues(); // Load default values
                OldKey = "";
                SetKey(OldKey);
            } else if (IsInlineInserted && UseInfiniteScroll) {
                // Nothing to do, just use current values
            } else if (!(IsCopy && InlineRowCount == 0)) {
                await LoadRowValues(Recordset); // Load row values
                if (IsGridEdit || IsMultiEdit) {
                    OldKey = GetKey(true); // Get from CurrentValue
                    SetKey(OldKey);
                }
            }
            RowType = RowType.View; // Render view
            if ((IsAdd || IsCopy) && InlineRowCount == 0 || IsGridAdd) // Add
                RowType = RowType.Add; // Render add

            // Inline Add/Copy row (row 0)
            if (RowType == RowType.Add && (IsAdd || IsCopy)) {
                InlineRowCount++;
                RecordCount--; // Reset record count for inline add/copy row
                if (TotalRecords == 0) // Reset stop record if no records
                    StopRecord = 0;
            } else {
                // Inline Edit row
                if (RowType == RowType.Edit && IsEdit)
                    InlineRowCount++;
                RowCount++; // Increment row count
            }

            // Set up row attributes
            RowAttrs.Add("data-rowindex", ConvertToString(crewChecklistForAdminList.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(crewChecklistForAdminList.RowCount) + "_CrewChecklistForAdmin");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(crewChecklistForAdminList.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && crewChecklistForAdminList.RowType == RowType.Add || IsEdit && crewChecklistForAdminList.RowType == RowType.Edit) // Inline-Add/Edit row
                RowAttrs.AppendClass("table-active");

            // Render row
            await RenderRow();

            // Render list options
            await RenderListOptions();
        }

        // Load basic search values // DN
        protected void LoadBasicSearchValues() {
            if (Get(Config.TableBasicSearch, out StringValues keyword))
                BasicSearch.Keyword = keyword.ToString();
            if (!Empty(BasicSearch.Keyword) && Empty(Command))
                Command = "search";
            if (Get(Config.TableBasicSearchType, out StringValues type))
                BasicSearch.Type = type.ToString();
        }

        // Load search values for validation // DN
        protected void LoadSearchValues() {
            // Load query builder rules
            string rules = Post("rules");
            if (!Empty(rules) && Empty(Command)) {
                QueryRules = rules;
                Command = "search";
            }

            // CreatedByUserID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CreatedByUserID[]"))
                    CreatedByUserID.AdvancedSearch.SearchValue = Get("x_CreatedByUserID[]");
                else
                    CreatedByUserID.AdvancedSearch.SearchValue = Get("CreatedByUserID"); // Default Value // DN
            if (!Empty(CreatedByUserID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CreatedByUserID"))
                CreatedByUserID.AdvancedSearch.SearchOperator = Get("z_CreatedByUserID");

            // CreatedDateTime
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CreatedDateTime[]"))
                    CreatedDateTime.AdvancedSearch.SearchValue = Get("x_CreatedDateTime[]");
                else
                    CreatedDateTime.AdvancedSearch.SearchValue = Get("CreatedDateTime"); // Default Value // DN
            if (!Empty(CreatedDateTime.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CreatedDateTime"))
                CreatedDateTime.AdvancedSearch.SearchOperator = Get("z_CreatedDateTime");

            // LastUpdatedByUserID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LastUpdatedByUserID[]"))
                    LastUpdatedByUserID.AdvancedSearch.SearchValue = Get("x_LastUpdatedByUserID[]");
                else
                    LastUpdatedByUserID.AdvancedSearch.SearchValue = Get("LastUpdatedByUserID"); // Default Value // DN
            if (!Empty(LastUpdatedByUserID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LastUpdatedByUserID"))
                LastUpdatedByUserID.AdvancedSearch.SearchOperator = Get("z_LastUpdatedByUserID");

            // LastUpdatedDateTime
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LastUpdatedDateTime[]"))
                    LastUpdatedDateTime.AdvancedSearch.SearchValue = Get("x_LastUpdatedDateTime[]");
                else
                    LastUpdatedDateTime.AdvancedSearch.SearchValue = Get("LastUpdatedDateTime"); // Default Value // DN
            if (!Empty(LastUpdatedDateTime.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LastUpdatedDateTime"))
                LastUpdatedDateTime.AdvancedSearch.SearchOperator = Get("z_LastUpdatedDateTime");

            // ApprovedByUserID1
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_ApprovedByUserID1"))
                    ApprovedByUserID1.AdvancedSearch.SearchValue = Get("x_ApprovedByUserID1");
                else
                    ApprovedByUserID1.AdvancedSearch.SearchValue = Get("ApprovedByUserID1"); // Default Value // DN
            if (!Empty(ApprovedByUserID1.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_ApprovedByUserID1"))
                ApprovedByUserID1.AdvancedSearch.SearchOperator = Get("z_ApprovedByUserID1");

            // ApprovedByUserID2
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_ApprovedByUserID2"))
                    ApprovedByUserID2.AdvancedSearch.SearchValue = Get("x_ApprovedByUserID2");
                else
                    ApprovedByUserID2.AdvancedSearch.SearchValue = Get("ApprovedByUserID2"); // Default Value // DN
            if (!Empty(ApprovedByUserID2.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_ApprovedByUserID2"))
                ApprovedByUserID2.AdvancedSearch.SearchOperator = Get("z_ApprovedByUserID2");
        }

        // Load recordset // DN
        public async Task<DbDataReader?> LoadRecordset(int offset = -1, int rowcnt = -1)
        {
            // Load list page SQL
            string sql = ListSql;

            // Load recordset // DN
            var dr = await Connection.SelectLimit(sql, rowcnt, offset, !Empty(OrderBy) || !Empty(SessionOrderBy));

            // Call Recordset Selected event
            RecordsetSelected(dr);
            return dr;
        }

        // Load rows // DN
        public async Task<List<Dictionary<string, object>>> LoadRows(int offset = -1, int rowcnt = -1)
        {
            // Load list page SQL
            string sql = ListSql;

            // Load rows // DN
            using var dr = await Connection.SelectLimit(sql, rowcnt, offset, !Empty(OrderBy) || !Empty(SessionOrderBy));
            var rows = await Connection.GetRowsAsync(dr);
            dr.Close(); // Close datareader before return
            return rows;
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
            Activity20.SetDbValue((ConvertToBool(row["Activity20"]) ? "1" : "0"));
            RemarkActivity20.SetDbValue(row["RemarkActivity20"]);
            Activity30.SetDbValue((ConvertToBool(row["Activity30"]) ? "1" : "0"));
            RemarkActivity30.SetDbValue(row["RemarkActivity30"]);
            Activity40.SetDbValue((ConvertToBool(row["Activity40"]) ? "1" : "0"));
            RemarkActivity40.SetDbValue(row["RemarkActivity40"]);
            Activity50.SetDbValue((ConvertToBool(row["Activity50"]) ? "1" : "0"));
            RemarkActivity50.SetDbValue(row["RemarkActivity50"]);
            Activity60.SetDbValue((ConvertToBool(row["Activity60"]) ? "1" : "0"));
            RemarkActivity60.SetDbValue(row["RemarkActivity60"]);
            Activity70.SetDbValue((ConvertToBool(row["Activity70"]) ? "1" : "0"));
            RemarkActivity70.SetDbValue(row["RemarkActivity70"]);
            InterviewerComment.SetDbValue(row["InterviewerComment"]);
            JobKnowledge.SetDbValue(row["JobKnowledge"]);
            SafetyAwareness.SetDbValue(row["SafetyAwareness"]);
            Personality.SetDbValue(row["Personality"]);
            EnglishProficiency.SetDbValue(row["EnglishProficiency"]);
            PrincipalComment.SetDbValue(row["PrincipalComment"]);
            CreatedByUserID.SetDbValue(row["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(row["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
            FinalInterviewComment.SetDbValue(row["FinalInterviewComment"]);
            InterviewedByPersonOneName.SetDbValue(row["InterviewedByPersonOneName"]);
            InterviewedByPersonOneRank.SetDbValue(row["InterviewedByPersonOneRank"]);
            AssistantManagerPdeReviewedDate.SetDbValue(row["AssistantManagerPdeReviewedDate"]);
            InterviewedByPersonTwoName.SetDbValue(row["InterviewedByPersonTwoName"]);
            InterviewedByPersonTwoRank.SetDbValue(row["InterviewedByPersonTwoRank"]);
            InterviewedByPersonThreeName.SetDbValue(row["InterviewedByPersonThreeName"]);
            InterviewedByPersonThreeRank.SetDbValue(row["InterviewedByPersonThreeRank"]);
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
            row.Add("Activity20", Activity20.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity20", RemarkActivity20.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity30", Activity30.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity30", RemarkActivity30.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity40", Activity40.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity40", RemarkActivity40.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity50", Activity50.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity50", RemarkActivity50.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity60", Activity60.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity60", RemarkActivity60.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity70", Activity70.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity70", RemarkActivity70.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewerComment", InterviewerComment.DefaultValue ?? DbNullValue); // DN
            row.Add("JobKnowledge", JobKnowledge.DefaultValue ?? DbNullValue); // DN
            row.Add("SafetyAwareness", SafetyAwareness.DefaultValue ?? DbNullValue); // DN
            row.Add("Personality", Personality.DefaultValue ?? DbNullValue); // DN
            row.Add("EnglishProficiency", EnglishProficiency.DefaultValue ?? DbNullValue); // DN
            row.Add("PrincipalComment", PrincipalComment.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedByUserID", CreatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("FinalInterviewComment", FinalInterviewComment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneName", InterviewedByPersonOneName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneRank", InterviewedByPersonOneRank.DefaultValue ?? DbNullValue); // DN
            row.Add("AssistantManagerPdeReviewedDate", AssistantManagerPdeReviewedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoName", InterviewedByPersonTwoName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoRank", InterviewedByPersonTwoRank.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeName", InterviewedByPersonThreeName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeRank", InterviewedByPersonThreeRank.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewingManagerApprovalDate", CrewingManagerApprovalDate.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity14Attachment", Activity14Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity20Attachment", Activity20Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity30Attachment", Activity30Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity50Attachment", Activity50Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity70Attachment", Activity70Attachment.DefaultValue ?? DbNullValue); // DN
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
            ID.CellCssStyle = "white-space: nowrap;";

            // MTCrewID
            MTCrewID.CellCssStyle = "white-space: nowrap;";

            // Activity10
            Activity10.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity10
            RemarkActivity10.CellCssStyle = "white-space: nowrap;";

            // Activity11
            Activity11.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity11
            RemarkActivity11.CellCssStyle = "white-space: nowrap;";

            // Activity12
            Activity12.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity12
            RemarkActivity12.CellCssStyle = "white-space: nowrap;";

            // Activity13
            Activity13.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity13
            RemarkActivity13.CellCssStyle = "white-space: nowrap;";

            // Activity14
            Activity14.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity14
            RemarkActivity14.CellCssStyle = "white-space: nowrap;";

            // Activity20
            Activity20.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity20
            RemarkActivity20.CellCssStyle = "white-space: nowrap;";

            // Activity30
            Activity30.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity30
            RemarkActivity30.CellCssStyle = "white-space: nowrap;";

            // Activity40
            Activity40.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity40
            RemarkActivity40.CellCssStyle = "white-space: nowrap;";

            // Activity50
            Activity50.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity50
            RemarkActivity50.CellCssStyle = "white-space: nowrap;";

            // Activity60
            Activity60.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity60
            RemarkActivity60.CellCssStyle = "white-space: nowrap;";

            // Activity70
            Activity70.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity70
            RemarkActivity70.CellCssStyle = "white-space: nowrap;";

            // InterviewerComment
            InterviewerComment.CellCssStyle = "white-space: nowrap;";

            // JobKnowledge
            JobKnowledge.CellCssStyle = "white-space: nowrap;";

            // SafetyAwareness
            SafetyAwareness.CellCssStyle = "white-space: nowrap;";

            // Personality
            Personality.CellCssStyle = "white-space: nowrap;";

            // EnglishProficiency
            EnglishProficiency.CellCssStyle = "white-space: nowrap;";

            // PrincipalComment
            PrincipalComment.CellCssStyle = "white-space: nowrap;";

            // CreatedByUserID
            CreatedByUserID.CellCssStyle = "white-space: nowrap;";

            // CreatedDateTime
            CreatedDateTime.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedByUserID
            LastUpdatedByUserID.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedDateTime
            LastUpdatedDateTime.CellCssStyle = "white-space: nowrap;";

            // FinalInterviewComment
            FinalInterviewComment.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.CellCssStyle = "white-space: nowrap;";

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.CellCssStyle = "white-space: nowrap;";

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.CellCssStyle = "white-space: nowrap;";

            // Activity14Attachment
            Activity14Attachment.CellCssStyle = "white-space: nowrap;";

            // Activity20Attachment
            Activity20Attachment.CellCssStyle = "white-space: nowrap;";

            // Activity30Attachment
            Activity30Attachment.CellCssStyle = "white-space: nowrap;";

            // Activity50Attachment
            Activity50Attachment.CellCssStyle = "white-space: nowrap;";

            // Activity70Attachment
            Activity70Attachment.CellCssStyle = "white-space: nowrap;";

            // FinalInterviewAttachment
            FinalInterviewAttachment.CellCssStyle = "white-space: nowrap;";

            // PrincipalCommentAttachment
            PrincipalCommentAttachment.CellCssStyle = "white-space: nowrap;";

            // FormPrintoutAttachment
            FormPrintoutAttachment.CellCssStyle = "white-space: nowrap;";

            // AssistantManagerPdeReviewed
            AssistantManagerPdeReviewed.CellCssStyle = "white-space: nowrap;";

            // CrewingManagerApproval
            CrewingManagerApproval.CellCssStyle = "white-space: nowrap;";

            // InterviewDate
            InterviewDate.CellCssStyle = "white-space: nowrap;";

            // InterviewAttachment
            InterviewAttachment.CellCssStyle = "white-space: nowrap;";

            // ApprovedByUserID1

            // ApprovedByUserID2

            // View row
            if (RowType == RowType.View) {
                // MTCrewID
                MTCrewID.ViewValue = MTCrewID.CurrentValue;
                MTCrewID.ViewValue = FormatNumber(MTCrewID.ViewValue, MTCrewID.FormatPattern);
                MTCrewID.ViewCustomAttributes = "";

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

                // FinalInterviewComment
                FinalInterviewComment.ViewValue = FinalInterviewComment.CurrentValue;
                FinalInterviewComment.ViewCustomAttributes = "";

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.ViewValue = ConvertToString(InterviewedByPersonOneName.CurrentValue); // DN
                InterviewedByPersonOneName.ViewCustomAttributes = "";

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.ViewValue = ConvertToString(InterviewedByPersonOneRank.CurrentValue); // DN
                InterviewedByPersonOneRank.ViewCustomAttributes = "";

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

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.ViewValue = ConvertToString(InterviewedByPersonThreeName.CurrentValue); // DN
                InterviewedByPersonThreeName.ViewCustomAttributes = "";

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.ViewValue = ConvertToString(InterviewedByPersonThreeRank.CurrentValue); // DN
                InterviewedByPersonThreeRank.ViewCustomAttributes = "";

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
                curVal = ConvertToString(ApprovedByUserID1.CurrentValue);
                if (!Empty(curVal)) {
                    if (ApprovedByUserID1.Lookup != null && IsDictionary(ApprovedByUserID1.Lookup?.Options) && ApprovedByUserID1.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        ApprovedByUserID1.ViewValue = ApprovedByUserID1.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", ApprovedByUserID1.CurrentValue, DataType.Number, "");
                        sqlWrk = ApprovedByUserID1.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && ApprovedByUserID1.Lookup != null) { // Lookup values found
                            var listwrk = ApprovedByUserID1.Lookup?.RenderViewRow(rswrk[0]);
                            ApprovedByUserID1.ViewValue = ApprovedByUserID1.HighlightLookup(ConvertToString(rswrk[0]), ApprovedByUserID1.DisplayValue(listwrk));
                        } else {
                            ApprovedByUserID1.ViewValue = FormatNumber(ApprovedByUserID1.CurrentValue, ApprovedByUserID1.FormatPattern);
                        }
                    }
                } else {
                    ApprovedByUserID1.ViewValue = DbNullValue;
                }
                ApprovedByUserID1.ViewCustomAttributes = "";

                // ApprovedByUserID2
                ApprovedByUserID2.ViewValue = ApprovedByUserID2.CurrentValue;
                curVal = ConvertToString(ApprovedByUserID2.CurrentValue);
                if (!Empty(curVal)) {
                    if (ApprovedByUserID2.Lookup != null && IsDictionary(ApprovedByUserID2.Lookup?.Options) && ApprovedByUserID2.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        ApprovedByUserID2.ViewValue = ApprovedByUserID2.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", ApprovedByUserID2.CurrentValue, DataType.Number, "");
                        sqlWrk = ApprovedByUserID2.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && ApprovedByUserID2.Lookup != null) { // Lookup values found
                            var listwrk = ApprovedByUserID2.Lookup?.RenderViewRow(rswrk[0]);
                            ApprovedByUserID2.ViewValue = ApprovedByUserID2.HighlightLookup(ConvertToString(rswrk[0]), ApprovedByUserID2.DisplayValue(listwrk));
                        } else {
                            ApprovedByUserID2.ViewValue = FormatNumber(ApprovedByUserID2.CurrentValue, ApprovedByUserID2.FormatPattern);
                        }
                    }
                } else {
                    ApprovedByUserID2.ViewValue = DbNullValue;
                }
                ApprovedByUserID2.ViewCustomAttributes = "";

                // CreatedByUserID
                CreatedByUserID.HrefValue = "";
                CreatedByUserID.TooltipValue = "";

                // CreatedDateTime
                CreatedDateTime.HrefValue = "";
                CreatedDateTime.TooltipValue = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.HrefValue = "";
                LastUpdatedByUserID.TooltipValue = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.HrefValue = "";
                LastUpdatedDateTime.TooltipValue = "";

                // ApprovedByUserID1
                ApprovedByUserID1.HrefValue = "";
                ApprovedByUserID1.TooltipValue = "";

                // ApprovedByUserID2
                ApprovedByUserID2.HrefValue = "";
                ApprovedByUserID2.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // CreatedByUserID
                if (CreatedByUserID.UseFilter && !Empty(CreatedByUserID.AdvancedSearch.SearchValue)) {
                    CreatedByUserID.EditValue = ConvertToString(CreatedByUserID.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // CreatedDateTime
                if (CreatedDateTime.UseFilter && !Empty(CreatedDateTime.AdvancedSearch.SearchValue)) {
                    CreatedDateTime.EditValue = ConvertToString(CreatedDateTime.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // LastUpdatedByUserID
                if (LastUpdatedByUserID.UseFilter && !Empty(LastUpdatedByUserID.AdvancedSearch.SearchValue)) {
                    LastUpdatedByUserID.EditValue = ConvertToString(LastUpdatedByUserID.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // LastUpdatedDateTime
                if (LastUpdatedDateTime.UseFilter && !Empty(LastUpdatedDateTime.AdvancedSearch.SearchValue)) {
                    LastUpdatedDateTime.EditValue = ConvertToString(LastUpdatedDateTime.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // ApprovedByUserID1
                ApprovedByUserID1.SetupEditAttributes();
                ApprovedByUserID1.EditValue = ApprovedByUserID1.AdvancedSearch.SearchValue; // DN
                ApprovedByUserID1.PlaceHolder = RemoveHtml(ApprovedByUserID1.Caption);

                // ApprovedByUserID2
                ApprovedByUserID2.SetupEditAttributes();
                ApprovedByUserID2.EditValue = ApprovedByUserID2.AdvancedSearch.SearchValue; // DN
                ApprovedByUserID2.PlaceHolder = RemoveHtml(ApprovedByUserID2.Caption);
            }

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        // Validate search
        protected bool ValidateSearch() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;

            // Return validate result
            bool validateSearch = !HasInvalidFields();

            // Call Form CustomValidate event
            string formCustomError = "";
            validateSearch = validateSearch && FormCustomValidate(ref formCustomError);
            if (!Empty(formCustomError))
                FailureMessage = formCustomError;
            return validateSearch;
        }

        /// <summary>
        /// Send event
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="type">Type</param>
        public void SendEvent(object data, string type = "message")
        {
            string str = "event: " + type + "\n" + "data: " + ConvertToJson(data) + "\n\n";
            ResponseWrite(str).Wait();
            // Flush the output buffer and send echoed messages to the browser
            Response?.Body.Flush();
        }

        /// <summary>
        /// Import file
        /// </summary>
        /// <param name="token">File token to locate the uploaded import file</param>
        /// <param name="rollback">Try import and then rollback</param>
        /// <returns>Action result</returns>
        public async Task<JsonBoolResult> Import(string token, bool rollback = false)
        {
            if (!Security.CanImport)
                return JsonBoolResult.FalseResult; // Import not allowed

            // Check if valid token
            if (Empty(token))
                return JsonBoolResult.FalseResult;

            // Get uploaded files by token
            var files = GetUploadedFileNames(token, true).Where(file => Path.GetExtension(file).ToLower() != ".txt"); // Ignore log file
            var exts = Config.ImportFileAllowedExtensions.Split(',');
            int totCnt = 0, totSuccessCnt = 0, totFailCnt = 0;
            object? ov;
            bool firstRowIsHeader = false;
            var list = new List<Dictionary<string, object>>();
            var results = new Dictionary<string, object> { { Config.ApiFileTokenName, token }, { "files", list }, { "success", false } };

            // Add HTTP headers for SSE
            AddHeader(HeaderNames.CacheControl, "no-store");
            AddHeader(HeaderNames.ContentType, "text/event-stream");

            // Import records
            foreach (var file in files) {
                string fileName = Path.GetFileName(file);
                Dictionary<string, object> res = new () { { Config.ApiFileTokenName, token }, { "file", fileName }, { "success", false } };
                string ext = Path.GetExtension(file)?.ToLower().Substring(1) ?? "";
                if (!exts.Contains(ext)) {
                    res.Add("error", Language.Phrase("ImportInvalidFileExtension").Replace("%e", ext));
                    SendEvent(res, "error");
                    return new JsonBoolResult(res, false);
                }

                // Set up options for Page Importing event

                // Default Options
                var options = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase) {
                    { "file", file },
                    { "activeSheet", 0 },
                    { "headerRowNumber", 0 },
                    { "headers", new List<string?>() },
                    { "offset", 0 },
                    { "limit", 0 }
                };

                // Get optional data from POST
                foreach (string key in Form.Keys) {
                    if (!(key == "action" || key == "token" || key == "filetoken"))
                        options.Add(key, Form[key]);
                }

                // Get data
                byte[] tempData;
                if (ext == "csv") {
                    options.Add("encoding", Config.ImportCsvEncoding);
                    options.Add("culture", Config.ImportCsvCulture);
                    options.Add("delimiter", Config.ImportCsvDelimiter);
                    options.Add("textQualifier", Config.ImportCsvTextQualifier);
                    options.Add("eol", Config.ImportCsvEol);
                    options.Add("dataTypes", new eDataTypes[] {});
                    options.Add("skipLinesBeginning", 0);
                    options.Add("skipLinesEnd", 0);
                }

                // Create a new Excel package
                using var excelPackage = new ExcelPackage();

                // Call Page Importing server event
                if (!PageImporting(excelPackage, options)) {
                    SendEvent(res, "error");
                    return new JsonBoolResult(res, false);
                }
                if (ext == "csv") { // CSV file
                    ExcelTextFormat format = new ();
                    if (options.TryGetValue("culture", out ov) && ov is CultureInfo)
                        format.Culture = (CultureInfo)ov;
                    if (options.TryGetValue("delimiter", out ov))
                        format.Delimiter = Convert.ToChar(ov);
                    if (options.TryGetValue("textQualifier", out ov))
                        format.TextQualifier = Convert.ToChar(ov);
                    if (options.TryGetValue("dataTypes", out ov))
                        format.DataTypes = (eDataTypes[])ov;
                    if (options.TryGetValue("eol", out ov))
                        format.EOL = ConvertToString(ov);
                    if (options.TryGetValue("skipLinesBeginning", out ov))
                        format.SkipLinesBeginning = ConvertToInt(ov);
                    if (options.TryGetValue("skipLinesEnd", out ov))
                        format.SkipLinesEnd = ConvertToInt(ov);

                    // Read file
                    string csvText;
                    if (options.TryGetValue("encoding", out ov) && ov is Encoding)
                        csvText = await FileReadAllTextWithEncoding(file, (Encoding)ov);
                    else
                        csvText = await FileReadAllText(file);

                    // Append EOL if the file has no EOL at end of file
                    if (!csvText.EndsWith(format.EOL))
                        csvText += format.EOL;

                    // Create a worksheet
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                    // Load the CSV data into cell A1
                    worksheet.Cells["A1"].LoadFromText(csvText, format);
                    tempData = excelPackage.GetAsByteArray();
                } else { // Excel file
                    tempData = await FileReadAllBytes(file);
                }
                int activeSheet = -1, offset = 0, limit = 0;
                if (options.TryGetValue("offset", out ov))
                    offset = ConvertToInt(ov);
                if (options.TryGetValue("limit", out ov))
                    limit = ConvertToInt(ov);
                // Get active worksheet for Excel
                if (ext == "xlsx" && options.TryGetValue("activeSheet", out ov))
                    activeSheet = ConvertToInt(ov);

                // Create a new Excel package in a memorystream
                using var stream = new MemoryStream(tempData);
                using var ep = new ExcelPackage(stream);
                ExcelWorksheet ws = (activeSheet > -1) ? ep.Workbook.Worksheets[activeSheet] : ep.Workbook.Worksheets.First();
                if (ws == null) {
                    var result = new { success = false, error = Language.Phrase("WorksheetNotExist") };
                    SendEvent(res, "error");
                    return new JsonBoolResult(result, false);
                }

                // Get column headers
                List<string> headers = new ();
                if (options.TryGetValue("headers", out ov) && ov is List<string>)
                    headers = (List<string>)ov;
                int headerRow = 0;
                int highestColumn = ws.Dimension.End.Column;
                int highestRow = ws.Dimension.End.Row;
                if (!IsList(headers) || headers.Count == 0) { // Undetermined, load from header row
                    headerRow = ConvertToInt(options["headerRowNumber"]) + 1;
                    headers = GetImportHeaders(ws, headerRow, highestColumn);
                }
                if (!IsList(headers) || headers.Count == 0) { // Unable to load header
                    res.Add("error", Language.Phrase("ImportNoHeaderRow"));
                    SendEvent(res, "error");
                    return new JsonBoolResult(res, false);
                }
                if (headers.Any(name => !Fields.ContainsKey(name))) {
                    res.Add("error", Language.Phrase("ImportInvalidFieldName").Replace("%f", String.Join(", ", headers.Where(name => !Fields.ContainsKey(name)))));
                    SendEvent(res, "error");
                    return new JsonBoolResult(res, false);
                }
                int startRow = headerRow + 1;
                int endRow = highestRow;
                if (offset > 0)
                    startRow += offset;
                if (limit > 0) {
                    endRow = startRow + limit - 1;
                    if (endRow > highestRow)
                        endRow = highestRow;
                }
                var records = new List<List<object>>();
                if (endRow >= startRow)
                    records = GetImportRecords(ws, startRow, endRow, highestColumn);
                int recordCnt = records.Count;
                int cnt = 0, successCnt = 0, failCnt = 0;
                var failList = new Dictionary<string, string>();
                res.Add("totalCount", recordCnt);
                res.Add("count", cnt);
                res.Add("successCount", successCnt);
                res.Add("failCount", 0);

                // Begin transaction
                if (ImportUseTransaction)
                    Connection.BeginTrans();

                // Process records
                foreach (var values in records) {
                    bool importSuccess = false;
                    try {
                        var row = new Dictionary<string, object>();
                        for (int k = 0; k < highestColumn && k < headers.Count; k++) {
                            if (!Empty(headers[k]) && !Empty(values[k])) { // Skip empty values // DN
                                var fld = FieldByName(headers[k]);
                                if (fld?.IsBoolean ?? false) // Fix boolean field // DN
                                    values[k] = Connection.IsMsSql ? ConvertToBool(values[k]) : ConvertToString(values[k]);
                                row.Add(headers[k], values[k]);
                            }
                        }
                        cnt++;
                        res["count"] = cnt;
                        res.Add("row", row);
                        if (await ImportRow(row, cnt)) {
                            successCnt++;
                            importSuccess = true;
                            res["success"] = true;
                            res.Add("error", false);
                        } else {
                            failCnt++;
                            failList.Add("row" + cnt, FailureMessage);
                            ClearFailureMessage(); // Clear error message
                            res["success"] = false;
                            res.Add("error", FailureMessage);
                        }
                    } catch (Exception e) {
                        failCnt++;
                        if (!failList.TryGetValue("row" + cnt, out string? fm) || fm == "")
                            failList["row" + cnt] = e.Message;
                        res.Add("error", e.Message);
                        res["success"] = false;
                    }

                    // Reset count if import fail and use transaction
                    if (!importSuccess && ImportUseTransaction) {
                        successCnt = 0;
                        failCnt = cnt;
                    }

                    // Save progress to memory cache // DN
                    res["successCount"] = successCnt;
                    res["failCount"] = failCnt;
                    SendEvent(res);
                    res.Remove("row");
                    res.Remove("error");

                    // No need to process further if import fail and use transaction
                    if (!importSuccess && ImportUseTransaction)
                        break;
                }
                res.Add("failList", failList);

                // Commit/Rollback transaction
                if (ImportUseTransaction) {
                    if (failCnt > 0) // Rollback
                        Connection.RollbackTrans();
                    else // Commit
                        Connection.CommitTrans();
                }
                totCnt += cnt;
                totSuccessCnt += successCnt;
                totFailCnt += failCnt;

                // Call Page Imported server event
                PageImported(ep, res);
                if (totCnt > 0 && totFailCnt == 0) { // Clean up if all records imported
                    results["success"] = true;
                } else {
                    results["success"] = false;
                }
                list.Add(res);
            }
            var ret = (bool)results["success"];
            if (ret)
                CleanUploadTempPaths(token);
            SendEvent(results, "complete"); // All files imported
            return new JsonBoolResult(results, ret);
        }

        /// <summary>
        /// Get import header
        /// </summary>
        /// <param name="ws">EPPlus worksheet</param>
        /// <param name="rowIdx">Row index for header row</param>
        /// <param name="highestColumn">Highest number of column</param>
        /// <returns>The column headers</returns>
        protected List<string> GetImportHeaders(ExcelWorksheet ws, int rowIdx, int highestColumn) =>
            ws.Cells[rowIdx, 1, rowIdx, highestColumn].Select(cell => cell.Value.ToString()).Select(v => ConvertToString(v)).ToList();

        /// <summary>
        /// Get import records
        /// </summary>
        /// <param name="ws">EPPlus worksheet</param>
        /// <param name="startRowIdx">Start row index</param>
        /// <param name="endRowIdx">End row index</param>
        /// <param name="highestColumn">Highest number of Column</param>
        /// <returns>The records to import</returns>
        protected List<List<object>> GetImportRecords(ExcelWorksheet ws, int startRowIdx, int endRowIdx, int highestColumn) {
            object[,] values = (object[,])ws.Cells[startRowIdx, 1, endRowIdx, highestColumn].Value;
            int bound0 = values.GetUpperBound(0), bound1 = values.GetUpperBound(1);
            var ar = new List<List<object>>();
            List<object> record;
            for (int i = 0; i <= bound0; i++) {
                record = new List<object>();
                for (int j = 0; j <= bound1; j++)
                    record.Add(values[i, j]);
                ar.Add(record);
            }
            return ar;
        }

        /// <summary>
        /// Import a row
        /// </summary>
        /// <param name="row">Record to import</param>
        /// <param name="cnt">Imported record count</param>
        /// <returns>Whether the record is imported</returns>
        protected async Task<bool> ImportRow(Dictionary<string, object> row, int cnt) {
            // Call Row Import server event
            if (!RowImport(row, cnt))
                return false;

            // Check field values
            foreach (var (key, value) in row) {
                if (Fields[key] is DbField<SqlDbType> fld && !CheckValue(fld, value)) {
                    FailureMessage = Language.Phrase("ImportInvalidFieldValue").Replace("%f", fld.Name).Replace("%v", ConvertToString(value));
                    return false;
                }
            }

            // Insert/Update to database
            var oldrow = await LoadRow(row);
            if (!ImportInsertOnly && !Empty(oldrow)) {
                // Call Row Updating event
                bool updateRow = RowUpdating(oldrow, row);
                if (updateRow) {
                    updateRow = ConvertToBool(await UpdateAsync(row, null, oldrow));
                    if (updateRow) // Call Row Updated event
                        RowUpdated(oldrow, row);
                }
                return updateRow;
            } else {
                // Call Row Inserting event
                bool insertRow = RowInserting(oldrow, row);
                if (insertRow) {
                    insertRow = ConvertToBool(await InsertAsync(row));
                    if (insertRow)
                        RowInserted(oldrow, row); // Call Row Updated event
                }
                return insertRow;
            }
        }

        /// <summary>
        /// Check field value
        /// </summary>
        /// <param name="fld">Field object</param>
        /// <param name="value">Field value to check</param>
        /// <returns>Whether the field values is valid</returns>
        protected bool CheckValue(DbField fld, object value) {
            if (fld.DataType == DataType.Number && !IsNumeric(value))
                return false;
            else if (fld.DataType == DataType.Date && !CheckDate(ConvertToString(value)))
                return false;
            return true;
        }

        // Load row (for import)
        protected async Task<Dictionary<string, object>?> LoadRow(Dictionary<string, object> row) {
            string filter = GetRecordFilter(row);
            if (Empty(filter)) // No primary key
                return null;
            CurrentFilter = filter;
            string sql = CurrentSql;
            try {
                return await Connection.GetRowAsync(sql, true); // Use main connection
            } catch {
                return null;
            }
        }

        // Load advanced search
        public void LoadAdvancedSearch()
        {
            ApprovedByUserID1.AdvancedSearch.Load();
            ApprovedByUserID2.AdvancedSearch.Load();
        }

        // Get export HTML tag
        protected string GetExportTag(string type, bool custom = false) {
            string exportUrl = AppPath(CurrentPageName()); // DN
            if (type == "print" || custom) { // Printer friendly / custom export
                exportUrl += "?export=" + type + (custom ? "&amp;custom=1" : "");
            } else {
                exportUrl = AppPath(Config.ApiUrl + Config.ApiExportAction + "/" + type + "/" + TableVar);
            }
            if (SameText(type, "excel")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fCrewChecklistForAdminlist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
            } else if (SameText(type, "word")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fCrewChecklistForAdminlist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>";
            } else if (SameText(type, "pdf")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fCrewChecklistForAdminlist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\">" + Language.Phrase("ExportToPDF") + "</a>";
            } else if (SameText(type, "html")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-html\" title=\"" + HtmlEncode(Language.Phrase("ExportToHtml", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToHtml", true)) + "\">" + Language.Phrase("ExportToHtml") + "</a>";
            } else if (SameText(type, "xml")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-xml\" title=\"" + HtmlEncode(Language.Phrase("ExportToXml", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToXml", true)) + "\">" + Language.Phrase("ExportToXml") + "</a>";
            } else if (SameText(type, "csv")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-csv\" title=\"" + HtmlEncode(Language.Phrase("ExportToCsv", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToCsv", true)) + "\">" + Language.Phrase("ExportToCsv") + "</a>";
            } else if (SameText(type, "email")) {
                string url = custom ? " data-url=\"" + exportUrl + "\"" : "";
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fCrewChecklistForAdminlist\" data-ew-action=\"email\" data-custom=\"false\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
            } else if (SameText(type, "print")) {
                return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-print\" title=\"" + HtmlEncode(Language.Phrase("PrinterFriendly", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("PrinterFriendly", true)) + "\">" + Language.Phrase("PrinterFriendly") + "</a>";
            }
            return "";
        }

        // Set up export options
        protected void SetupExportOptions() {
            ListOption item;

            // Printer friendly
            item = ExportOptions.Add("print");
            item.Body = GetExportTag("print");
            item.Visible = false;

            // Export to Excel
            item = ExportOptions.Add("excel");
            item.Body = GetExportTag("excel");
            item.Visible = true;

            // Export to Word
            item = ExportOptions.Add("word");
            item.Body = GetExportTag("word");
            item.Visible = false;

            // Export to HTML
            item = ExportOptions.Add("html");
            item.Body = GetExportTag("html");
            item.Visible = false;

            // Export to XML
            item = ExportOptions.Add("xml");
            item.Body = GetExportTag("xml");
            item.Visible = false;

            // Export to CSV
            item = ExportOptions.Add("csv");
            item.Body = GetExportTag("csv");
            item.Visible = true;

            // Export to PDF
            item = ExportOptions.Add("pdf");
            item.Body = GetExportTag("pdf");
            item.Visible = false;

            // Export to Email
            item = ExportOptions.Add("email");
            item.Body = GetExportTag("email");
            item.Visible = false;

            // Drop down button for export
            ExportOptions.UseButtonGroup = true;
            ExportOptions.UseDropDownButton = true;
            if (ExportOptions.UseButtonGroup && IsMobile())
                ExportOptions.UseDropDownButton = true;
            ExportOptions.DropDownButtonPhrase = "ButtonExport";

            // Add group option item
            item = ExportOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;
            if (!Security.CanExport) // Export not allowed
                ExportOptions.HideAllOptions();
        }

        // Set up search options
        protected void SetupSearchOptions() {
            ListOption item;

            // Search button
            item = SearchOptions.Add("searchtoggle");
            var searchToggleClass = !Empty(SearchWhere) ? " active" : " active";
            item.Body = "<a class=\"btn btn-default ew-search-toggle" + searchToggleClass + "\" role=\"button\" title=\"" + Language.Phrase("SearchPanel") + "\" data-caption=\"" + Language.Phrase("SearchPanel") + "\" data-ew-action=\"search-toggle\" data-form=\"fCrewChecklistForAdminsrch\" aria-pressed=\"" + (searchToggleClass == " active" ? "true" : "false") + "\">" + Language.Phrase("SearchLink") + "</a>";
            item.Visible = true;

            // Show all button
            item = SearchOptions.Add("showall");
            if (UseCustomTemplate || !UseAjaxActions)
                item.Body = "<a class=\"btn btn-default ew-show-all\" role=\"button\" title=\"" + Language.Phrase("ShowAll") + "\" data-caption=\"" + Language.Phrase("ShowAll") + "\" href=\"" + AppPath(PageUrl) + "cmd=reset\">" + Language.Phrase("ShowAllBtn") + "</a>";
            else
                item.Body = "<a class=\"btn btn-default ew-show-all\" role=\"button\" title=\"" + Language.Phrase("ShowAll") + "\" data-caption=\"" + Language.Phrase("ShowAll") + "\" data-ew-action=\"refresh\" data-url=\"" + AppPath(PageUrl) + "cmd=reset\">" + Language.Phrase("ShowAllBtn") + "</a>";
            item.Visible = (SearchWhere != DefaultSearchWhere && SearchWhere != "0=101");

            // Advanced search button
            item = SearchOptions.Add("advancedsearch");
            if (ModalSearch && !IsMobile())
                item.Body = "<a class=\"btn btn-default ew-advanced-search\" title=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-table=\"CrewChecklistForAdmin\" data-caption=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-ew-action=\"modal\" data-url=\"" + AppPath("CrewChecklistForAdminSearch") + "\" data-btn=\"SearchBtn\">" + Language.Phrase("AdvancedSearch", false) + "</a>";
            else
                item.Body = "<a class=\"btn btn-default ew-advanced-search\" title=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-caption=\"" + Language.Phrase("AdvancedSearch", true) + "\" href=\"" + AppPath("CrewChecklistForAdminSearch") + "\">" + Language.Phrase("AdvancedSearch", false) + "</a>";
            item.Visible = true;

            // Button group for search
            SearchOptions.UseDropDownButton = false;
            SearchOptions.UseButtonGroup = true;
            SearchOptions.DropDownButtonPhrase = "ButtonSearch";

            // Add group option item
            item = SearchOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;

            // Hide search options
            if (IsExport() || !Empty(CurrentAction) && CurrentAction != "search")
                SearchOptions.HideAllOptions();
            if (!Security.CanSearch) {
                SearchOptions.HideAllOptions();
                FilterOptions.HideAllOptions();
            }
        }

        // Check if any search fields
        public bool HasSearchFields()
        {
            return true;
        }

        // Render search options
        protected void RenderSearchOptions()
        {
            if (!HasSearchFields() && SearchOptions["searchtoggle"] is ListOption opt)
                opt.Visible = false;
        }

        // Set up import options
        protected void SetupImportOptions() {
            ListOption item;

            // Import
            item = ImportOptions.Add("import");
            item.Body = "<a class=\"ew-import-link ew-import\" role=\"button\" title=\"" + Language.Phrase("Import", true) + "\" data-caption=\"" + Language.Phrase("Import", true) + "\" data-ew-action=\"import\" data-hdr=\"" + Language.Phrase("Import", true) + "\">" + Language.Phrase("Import") + "</a>";
            item.Visible = Security.CanImport;
            ImportOptions.UseButtonGroup = true;
            ImportOptions.UseDropDownButton = false;
            ImportOptions.DropDownButtonPhrase = "ButtonImport";

            // Add group option item
            item = ImportOptions.AddGroupOption();
            item.Body = "";
            item.Visible = false;
        }

        #pragma warning disable 168

        /// <summary>
        /// Export data
        /// </summary>
        public async Task ExportData(dynamic? doc)
        {
            // Load recordset // DN
            DbDataReader? dr = null;
            if (TotalRecords < 0)
                TotalRecords = await ListRecordCountAsync();
            StartRecord = 1;

            // Export all
            if (ExportAll) {
                DisplayRecords = TotalRecords;
                StopRecord = TotalRecords;
            } else { // Export one page only
                SetupStartRecord(); // Set up start record position
                // Set the last record to display
                if (DisplayRecords < 0) {
                    StopRecord = TotalRecords;
                } else {
                    StopRecord = StartRecord + DisplayRecords - 1;
                }
            }
            dr = await LoadRecordset(StartRecord - 1, (DisplayRecords <= 0) ? TotalRecords : DisplayRecords); // DN
            if (doc == null) { // DN
                RemoveHeader("Content-Type"); // Remove header
                RemoveHeader("Content-Disposition");
                FailureMessage = Language.Phrase("ExportClassNotFound"); // Export class not found
                return;
            }

            // Call Page Exporting server event
            doc.ExportCustom = !PageExporting(ref doc);

            // Page header
            string header = PageHeader;
            PageDataRendering(ref header);
            doc.Text.Append(header);

            // Export
            if (dr != null)
                await ExportDocument(doc, dr, StartRecord, StopRecord, "");

            // Page footer
            string footer = PageFooter;
            PageDataRendered(ref footer);
            doc.Text.Append(footer);

            // Close recordset
            using (dr) {} // Dispose

            // Export header and footer
            await doc.ExportHeaderAndFooter();

            // Call Page Exported server event
            PageExported(doc);
        }
        #pragma warning restore 168

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            url = Regex.Replace(url, @"\?cmd=reset(all)?$", ""); // Remove cmd=reset / cmd=resetall
            breadcrumb.Add("list", TableVar, url, "", TableVar, true);
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
            infiniteScroll = Param<bool>("infinitescroll");
            if (!Empty(pageNo) && IsNumeric(pageNo)) {
                int page = ConvertToInt(pageNo);
                StartRecord = (page - 1) * DisplayRecords + 1;
                if (StartRecord <= 0)
                    StartRecord = 1;
                else if (StartRecord >= ((TotalRecords - 1) / DisplayRecords) * DisplayRecords + 1)
                    StartRecord = ((TotalRecords - 1) / DisplayRecords) * DisplayRecords + 1;
            } else if (!Empty(startRec) && IsNumeric(startRec)) {
                StartRecord = ConvertToInt(startRec);
            } else if (!infiniteScroll) {
                StartRecord = StartRecordNumber;
            }

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

        // ListOptions Load event
        public virtual void ListOptionsLoad() {
            // Example:
            //var opt = ListOptions.Add("new");
            //opt.Header = "xxx";
            //opt.OnLeft = true; // Link on left
            //opt.MoveTo(0); // Move to first column
        }

        // ListOptions Rendering event
        public virtual void ListOptionsRendering() {
            //xxxGrid.DetailAdd = (...condition...); // Set to true or false conditionally
            //xxxGrid.DetailEdit = (...condition...); // Set to true or false conditionally
            //xxxGrid.DetailView = (...condition...); // Set to true or false conditionally
        }

        // ListOptions Rendered event
        public virtual void ListOptionsRendered() {
            //Example:
            //ListOptions["new"].Body = "xxx";
        }

        // Row Custom Action event
        public virtual bool RowCustomAction(string action, Dictionary<string, object> row) {
            // Return false to abort
            return true;
        }

        // Page Exporting event
        // doc = export document object
        public virtual bool PageExporting(ref dynamic doc) {
            //doc.Text.Append("<p>" + "my header" + "</p>"); // Export header
            //return false; // Return false to skip default export and use Row_Export event
            return true; // Return true to use default export and skip Row_Export event
        }

        // Page Exported event
        // doc = export document object
        public virtual void PageExported(dynamic doc) {
            //doc.Text.Append("my footer"); // Export footer
            //Log("Text: {Text}", doc.Text.ToString());
        }

        public virtual bool PageImporting(ExcelPackage excelPackage, dynamic options) {
            //Log(excelPackage); // Import excelPackage
            //Log(options); // Show all options for importing
            //return false; // Return false to skip import
            return true;
        }

        // Row Import event
        public virtual bool RowImport(Dictionary<string, object> row, int cnt) {
            //Log(cnt); // Import record count
            //Log(row); // Import row
            //return false; // Return false to skip import
            return true;
        }

        // Page Imported event
        public virtual void PageImported(ExcelPackage excelPackage, Dictionary<string, object> result) {
            //Log(result); // Import result
        }

        // Grid Inserting event
        public virtual bool GridInserting() {
            // Enter your code here
            // To reject grid insert, set return value to false
            return true;
        }

        // Grid Inserted event
        public virtual void GridInserted(List<Dictionary<string, object>> rsnew) {
            //Log("Grid Inserted");
        }

        // Grid Updating event
        public virtual bool GridUpdating(List<Dictionary<string, object>> rsold) {
            // Enter your code here
            // To reject grid update, set return value to false
            return true;
        }

        // Grid Updated event
        public virtual void GridUpdated(List<Dictionary<string, object>> rsold, List<Dictionary<string, object>> rsnew) {
            //Log("Grid Updated");
        }
    } // End page class
} // End Partial class
