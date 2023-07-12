namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// vCrewTrackingStatusList
    /// </summary>
    public static VCrewTrackingStatusList vCrewTrackingStatusList
    {
        get => HttpData.Get<VCrewTrackingStatusList>("vCrewTrackingStatusList")!;
        set => HttpData["vCrewTrackingStatusList"] = value;
    }

    /// <summary>
    /// Page class for v_CrewTrackingStatus
    /// </summary>
    public class VCrewTrackingStatusList : VCrewTrackingStatusListBase
    {
        // Constructor
        public VCrewTrackingStatusList(Controller controller) : base(controller)
        {
        }

        // Constructor
        public VCrewTrackingStatusList() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class VCrewTrackingStatusListBase : VCrewTrackingStatus
    {
        // Page ID
        public string PageID = "list";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "v_CrewTrackingStatus";

        // Page object name
        public string PageObjName = "vCrewTrackingStatusList";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fv_CrewTrackingStatuslist";

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
        public VCrewTrackingStatusListBase()
        {
            // CSS class name as context
            TableVar = "v_CrewTrackingStatus";
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

            // Table object (vCrewTrackingStatus)
            if (vCrewTrackingStatus == null || vCrewTrackingStatus is VCrewTrackingStatus)
                vCrewTrackingStatus = this;

            // Initialize URLs
            AddUrl = "VCrewTrackingStatusAdd";
            InlineAddUrl = PageUrl + "action=add";
            GridAddUrl = PageUrl + "action=gridadd";
            GridEditUrl = PageUrl + "action=gridedit";
            MultiEditUrl = PageUrl + "action=multiedit";
            MultiDeleteUrl = "VCrewTrackingStatusDelete";
            MultiUpdateUrl = "VCrewTrackingStatusUpdate";

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
        public string PageName => "VCrewTrackingStatusList";

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
            IndividualCodeNumber.SetVisibility();
            FullName.SetVisibility();
            RequiredPhoto.SetVisibility();
            VisaPhoto.SetVisibility();
            Gender.SetVisibility();
            RankAppliedFor.SetVisibility();
            WillAcceptLowRank.SetVisibility();
            EmployeeStatus.SetVisibility();
            Draft.SetVisibility();
            Submitted.SetVisibility();
            Reviewed.SetVisibility();
            RegistrationForm.SetVisibility();
            PreScreeningInterview.SetVisibility();
            MinimumRecruitmentCheck.SetVisibility();
            EngagementChecklist.SetVisibility();
            COCAuthenticity.SetVisibility();
            CESTest.SetVisibility();
            PyschometricTest.SetVisibility();
            CrewWatchlist.SetVisibility();
            PreviousAppraisalReport.SetVisibility();
            ContractBackgroundCheck.SetVisibility();
            EnglishProficiencyTestOrMarline.SetVisibility();
            Interviewed.SetVisibility();
            Approved.SetVisibility();
            MedicalCheckup.SetVisibility();
            CreatedBy.SetVisibility();
            LastUpdatedBy.SetVisibility();
        }

        // Constructor
        public VCrewTrackingStatusListBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "VCrewTrackingStatusView" ? "1" : "0"); // If View page, no primary button
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
            if (IsAddOrEdit)
                RankAppliedFor.Visible = false;
            if (IsAddOrEdit)
                Draft.Visible = false;
            if (IsAddOrEdit)
                Submitted.Visible = false;
            if (IsAddOrEdit)
                Reviewed.Visible = false;
            if (IsAddOrEdit)
                RegistrationForm.Visible = false;
            if (IsAddOrEdit)
                PreScreeningInterview.Visible = false;
            if (IsAddOrEdit)
                MinimumRecruitmentCheck.Visible = false;
            if (IsAddOrEdit)
                EngagementChecklist.Visible = false;
            if (IsAddOrEdit)
                COCAuthenticity.Visible = false;
            if (IsAddOrEdit)
                CESTest.Visible = false;
            if (IsAddOrEdit)
                PyschometricTest.Visible = false;
            if (IsAddOrEdit)
                CrewWatchlist.Visible = false;
            if (IsAddOrEdit)
                PreviousAppraisalReport.Visible = false;
            if (IsAddOrEdit)
                ContractBackgroundCheck.Visible = false;
            if (IsAddOrEdit)
                EnglishProficiencyTestOrMarline.Visible = false;
            if (IsAddOrEdit)
                Interviewed.Visible = false;
            if (IsAddOrEdit)
                Approved.Visible = false;
            if (IsAddOrEdit)
                MedicalCheckup.Visible = false;
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
            await SetupLookupOptions(Gender);
            await SetupLookupOptions(WillAcceptLowRank);

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fv_CrewTrackingStatusgrid";

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
                vCrewTrackingStatusList?.PageRender();
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
            filters.Merge(JObject.Parse(IndividualCodeNumber.AdvancedSearch.ToJson())); // Field IndividualCodeNumber
            filters.Merge(JObject.Parse(FullName.AdvancedSearch.ToJson())); // Field FullName
            filters.Merge(JObject.Parse(RequiredPhoto.AdvancedSearch.ToJson())); // Field RequiredPhoto
            filters.Merge(JObject.Parse(VisaPhoto.AdvancedSearch.ToJson())); // Field VisaPhoto
            filters.Merge(JObject.Parse(Gender.AdvancedSearch.ToJson())); // Field Gender
            filters.Merge(JObject.Parse(RankAppliedFor.AdvancedSearch.ToJson())); // Field RankAppliedFor
            filters.Merge(JObject.Parse(WillAcceptLowRank.AdvancedSearch.ToJson())); // Field WillAcceptLowRank
            filters.Merge(JObject.Parse(EmployeeStatus.AdvancedSearch.ToJson())); // Field EmployeeStatus
            filters.Merge(JObject.Parse(Draft.AdvancedSearch.ToJson())); // Field Draft
            filters.Merge(JObject.Parse(Submitted.AdvancedSearch.ToJson())); // Field Submitted
            filters.Merge(JObject.Parse(Reviewed.AdvancedSearch.ToJson())); // Field Reviewed
            filters.Merge(JObject.Parse(RegistrationForm.AdvancedSearch.ToJson())); // Field RegistrationForm
            filters.Merge(JObject.Parse(PreScreeningInterview.AdvancedSearch.ToJson())); // Field PreScreeningInterview
            filters.Merge(JObject.Parse(MinimumRecruitmentCheck.AdvancedSearch.ToJson())); // Field MinimumRecruitmentCheck
            filters.Merge(JObject.Parse(EngagementChecklist.AdvancedSearch.ToJson())); // Field EngagementChecklist
            filters.Merge(JObject.Parse(COCAuthenticity.AdvancedSearch.ToJson())); // Field COCAuthenticity
            filters.Merge(JObject.Parse(CESTest.AdvancedSearch.ToJson())); // Field CESTest
            filters.Merge(JObject.Parse(PyschometricTest.AdvancedSearch.ToJson())); // Field PyschometricTest
            filters.Merge(JObject.Parse(CrewWatchlist.AdvancedSearch.ToJson())); // Field CrewWatchlist
            filters.Merge(JObject.Parse(PreviousAppraisalReport.AdvancedSearch.ToJson())); // Field PreviousAppraisalReport
            filters.Merge(JObject.Parse(ContractBackgroundCheck.AdvancedSearch.ToJson())); // Field ContractBackgroundCheck
            filters.Merge(JObject.Parse(EnglishProficiencyTestOrMarline.AdvancedSearch.ToJson())); // Field EnglishProficiencyTestOrMarline
            filters.Merge(JObject.Parse(Interviewed.AdvancedSearch.ToJson())); // Field Interviewed
            filters.Merge(JObject.Parse(Approved.AdvancedSearch.ToJson())); // Field Approved
            filters.Merge(JObject.Parse(MedicalCheckup.AdvancedSearch.ToJson())); // Field MedicalCheckup
            filters.Merge(JObject.Parse(CreatedBy.AdvancedSearch.ToJson())); // Field CreatedBy
            filters.Merge(JObject.Parse(LastUpdatedBy.AdvancedSearch.ToJson())); // Field LastUpdatedBy
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

            // Field IndividualCodeNumber
            if (filter?.TryGetValue("x_IndividualCodeNumber", out sv) ?? false) {
                IndividualCodeNumber.AdvancedSearch.SearchValue = sv;
                IndividualCodeNumber.AdvancedSearch.SearchOperator = filter["z_IndividualCodeNumber"];
                IndividualCodeNumber.AdvancedSearch.SearchCondition = filter["v_IndividualCodeNumber"];
                IndividualCodeNumber.AdvancedSearch.SearchValue2 = filter["y_IndividualCodeNumber"];
                IndividualCodeNumber.AdvancedSearch.SearchOperator2 = filter["w_IndividualCodeNumber"];
                IndividualCodeNumber.AdvancedSearch.Save();
            }

            // Field FullName
            if (filter?.TryGetValue("x_FullName", out sv) ?? false) {
                FullName.AdvancedSearch.SearchValue = sv;
                FullName.AdvancedSearch.SearchOperator = filter["z_FullName"];
                FullName.AdvancedSearch.SearchCondition = filter["v_FullName"];
                FullName.AdvancedSearch.SearchValue2 = filter["y_FullName"];
                FullName.AdvancedSearch.SearchOperator2 = filter["w_FullName"];
                FullName.AdvancedSearch.Save();
            }

            // Field RequiredPhoto
            if (filter?.TryGetValue("x_RequiredPhoto", out sv) ?? false) {
                RequiredPhoto.AdvancedSearch.SearchValue = sv;
                RequiredPhoto.AdvancedSearch.SearchOperator = filter["z_RequiredPhoto"];
                RequiredPhoto.AdvancedSearch.SearchCondition = filter["v_RequiredPhoto"];
                RequiredPhoto.AdvancedSearch.SearchValue2 = filter["y_RequiredPhoto"];
                RequiredPhoto.AdvancedSearch.SearchOperator2 = filter["w_RequiredPhoto"];
                RequiredPhoto.AdvancedSearch.Save();
            }

            // Field VisaPhoto
            if (filter?.TryGetValue("x_VisaPhoto", out sv) ?? false) {
                VisaPhoto.AdvancedSearch.SearchValue = sv;
                VisaPhoto.AdvancedSearch.SearchOperator = filter["z_VisaPhoto"];
                VisaPhoto.AdvancedSearch.SearchCondition = filter["v_VisaPhoto"];
                VisaPhoto.AdvancedSearch.SearchValue2 = filter["y_VisaPhoto"];
                VisaPhoto.AdvancedSearch.SearchOperator2 = filter["w_VisaPhoto"];
                VisaPhoto.AdvancedSearch.Save();
            }

            // Field Gender
            if (filter?.TryGetValue("x_Gender", out sv) ?? false) {
                Gender.AdvancedSearch.SearchValue = sv;
                Gender.AdvancedSearch.SearchOperator = filter["z_Gender"];
                Gender.AdvancedSearch.SearchCondition = filter["v_Gender"];
                Gender.AdvancedSearch.SearchValue2 = filter["y_Gender"];
                Gender.AdvancedSearch.SearchOperator2 = filter["w_Gender"];
                Gender.AdvancedSearch.Save();
            }

            // Field RankAppliedFor
            if (filter?.TryGetValue("x_RankAppliedFor", out sv) ?? false) {
                RankAppliedFor.AdvancedSearch.SearchValue = sv;
                RankAppliedFor.AdvancedSearch.SearchOperator = filter["z_RankAppliedFor"];
                RankAppliedFor.AdvancedSearch.SearchCondition = filter["v_RankAppliedFor"];
                RankAppliedFor.AdvancedSearch.SearchValue2 = filter["y_RankAppliedFor"];
                RankAppliedFor.AdvancedSearch.SearchOperator2 = filter["w_RankAppliedFor"];
                RankAppliedFor.AdvancedSearch.Save();
            }

            // Field WillAcceptLowRank
            if (filter?.TryGetValue("x_WillAcceptLowRank", out sv) ?? false) {
                WillAcceptLowRank.AdvancedSearch.SearchValue = sv;
                WillAcceptLowRank.AdvancedSearch.SearchOperator = filter["z_WillAcceptLowRank"];
                WillAcceptLowRank.AdvancedSearch.SearchCondition = filter["v_WillAcceptLowRank"];
                WillAcceptLowRank.AdvancedSearch.SearchValue2 = filter["y_WillAcceptLowRank"];
                WillAcceptLowRank.AdvancedSearch.SearchOperator2 = filter["w_WillAcceptLowRank"];
                WillAcceptLowRank.AdvancedSearch.Save();
            }

            // Field EmployeeStatus
            if (filter?.TryGetValue("x_EmployeeStatus", out sv) ?? false) {
                EmployeeStatus.AdvancedSearch.SearchValue = sv;
                EmployeeStatus.AdvancedSearch.SearchOperator = filter["z_EmployeeStatus"];
                EmployeeStatus.AdvancedSearch.SearchCondition = filter["v_EmployeeStatus"];
                EmployeeStatus.AdvancedSearch.SearchValue2 = filter["y_EmployeeStatus"];
                EmployeeStatus.AdvancedSearch.SearchOperator2 = filter["w_EmployeeStatus"];
                EmployeeStatus.AdvancedSearch.Save();
            }

            // Field Draft
            if (filter?.TryGetValue("x_Draft", out sv) ?? false) {
                Draft.AdvancedSearch.SearchValue = sv;
                Draft.AdvancedSearch.SearchOperator = filter["z_Draft"];
                Draft.AdvancedSearch.SearchCondition = filter["v_Draft"];
                Draft.AdvancedSearch.SearchValue2 = filter["y_Draft"];
                Draft.AdvancedSearch.SearchOperator2 = filter["w_Draft"];
                Draft.AdvancedSearch.Save();
            }

            // Field Submitted
            if (filter?.TryGetValue("x_Submitted", out sv) ?? false) {
                Submitted.AdvancedSearch.SearchValue = sv;
                Submitted.AdvancedSearch.SearchOperator = filter["z_Submitted"];
                Submitted.AdvancedSearch.SearchCondition = filter["v_Submitted"];
                Submitted.AdvancedSearch.SearchValue2 = filter["y_Submitted"];
                Submitted.AdvancedSearch.SearchOperator2 = filter["w_Submitted"];
                Submitted.AdvancedSearch.Save();
            }

            // Field Reviewed
            if (filter?.TryGetValue("x_Reviewed", out sv) ?? false) {
                Reviewed.AdvancedSearch.SearchValue = sv;
                Reviewed.AdvancedSearch.SearchOperator = filter["z_Reviewed"];
                Reviewed.AdvancedSearch.SearchCondition = filter["v_Reviewed"];
                Reviewed.AdvancedSearch.SearchValue2 = filter["y_Reviewed"];
                Reviewed.AdvancedSearch.SearchOperator2 = filter["w_Reviewed"];
                Reviewed.AdvancedSearch.Save();
            }

            // Field RegistrationForm
            if (filter?.TryGetValue("x_RegistrationForm", out sv) ?? false) {
                RegistrationForm.AdvancedSearch.SearchValue = sv;
                RegistrationForm.AdvancedSearch.SearchOperator = filter["z_RegistrationForm"];
                RegistrationForm.AdvancedSearch.SearchCondition = filter["v_RegistrationForm"];
                RegistrationForm.AdvancedSearch.SearchValue2 = filter["y_RegistrationForm"];
                RegistrationForm.AdvancedSearch.SearchOperator2 = filter["w_RegistrationForm"];
                RegistrationForm.AdvancedSearch.Save();
            }

            // Field PreScreeningInterview
            if (filter?.TryGetValue("x_PreScreeningInterview", out sv) ?? false) {
                PreScreeningInterview.AdvancedSearch.SearchValue = sv;
                PreScreeningInterview.AdvancedSearch.SearchOperator = filter["z_PreScreeningInterview"];
                PreScreeningInterview.AdvancedSearch.SearchCondition = filter["v_PreScreeningInterview"];
                PreScreeningInterview.AdvancedSearch.SearchValue2 = filter["y_PreScreeningInterview"];
                PreScreeningInterview.AdvancedSearch.SearchOperator2 = filter["w_PreScreeningInterview"];
                PreScreeningInterview.AdvancedSearch.Save();
            }

            // Field MinimumRecruitmentCheck
            if (filter?.TryGetValue("x_MinimumRecruitmentCheck", out sv) ?? false) {
                MinimumRecruitmentCheck.AdvancedSearch.SearchValue = sv;
                MinimumRecruitmentCheck.AdvancedSearch.SearchOperator = filter["z_MinimumRecruitmentCheck"];
                MinimumRecruitmentCheck.AdvancedSearch.SearchCondition = filter["v_MinimumRecruitmentCheck"];
                MinimumRecruitmentCheck.AdvancedSearch.SearchValue2 = filter["y_MinimumRecruitmentCheck"];
                MinimumRecruitmentCheck.AdvancedSearch.SearchOperator2 = filter["w_MinimumRecruitmentCheck"];
                MinimumRecruitmentCheck.AdvancedSearch.Save();
            }

            // Field EngagementChecklist
            if (filter?.TryGetValue("x_EngagementChecklist", out sv) ?? false) {
                EngagementChecklist.AdvancedSearch.SearchValue = sv;
                EngagementChecklist.AdvancedSearch.SearchOperator = filter["z_EngagementChecklist"];
                EngagementChecklist.AdvancedSearch.SearchCondition = filter["v_EngagementChecklist"];
                EngagementChecklist.AdvancedSearch.SearchValue2 = filter["y_EngagementChecklist"];
                EngagementChecklist.AdvancedSearch.SearchOperator2 = filter["w_EngagementChecklist"];
                EngagementChecklist.AdvancedSearch.Save();
            }

            // Field COCAuthenticity
            if (filter?.TryGetValue("x_COCAuthenticity", out sv) ?? false) {
                COCAuthenticity.AdvancedSearch.SearchValue = sv;
                COCAuthenticity.AdvancedSearch.SearchOperator = filter["z_COCAuthenticity"];
                COCAuthenticity.AdvancedSearch.SearchCondition = filter["v_COCAuthenticity"];
                COCAuthenticity.AdvancedSearch.SearchValue2 = filter["y_COCAuthenticity"];
                COCAuthenticity.AdvancedSearch.SearchOperator2 = filter["w_COCAuthenticity"];
                COCAuthenticity.AdvancedSearch.Save();
            }

            // Field CESTest
            if (filter?.TryGetValue("x_CESTest", out sv) ?? false) {
                CESTest.AdvancedSearch.SearchValue = sv;
                CESTest.AdvancedSearch.SearchOperator = filter["z_CESTest"];
                CESTest.AdvancedSearch.SearchCondition = filter["v_CESTest"];
                CESTest.AdvancedSearch.SearchValue2 = filter["y_CESTest"];
                CESTest.AdvancedSearch.SearchOperator2 = filter["w_CESTest"];
                CESTest.AdvancedSearch.Save();
            }

            // Field PyschometricTest
            if (filter?.TryGetValue("x_PyschometricTest", out sv) ?? false) {
                PyschometricTest.AdvancedSearch.SearchValue = sv;
                PyschometricTest.AdvancedSearch.SearchOperator = filter["z_PyschometricTest"];
                PyschometricTest.AdvancedSearch.SearchCondition = filter["v_PyschometricTest"];
                PyschometricTest.AdvancedSearch.SearchValue2 = filter["y_PyschometricTest"];
                PyschometricTest.AdvancedSearch.SearchOperator2 = filter["w_PyschometricTest"];
                PyschometricTest.AdvancedSearch.Save();
            }

            // Field CrewWatchlist
            if (filter?.TryGetValue("x_CrewWatchlist", out sv) ?? false) {
                CrewWatchlist.AdvancedSearch.SearchValue = sv;
                CrewWatchlist.AdvancedSearch.SearchOperator = filter["z_CrewWatchlist"];
                CrewWatchlist.AdvancedSearch.SearchCondition = filter["v_CrewWatchlist"];
                CrewWatchlist.AdvancedSearch.SearchValue2 = filter["y_CrewWatchlist"];
                CrewWatchlist.AdvancedSearch.SearchOperator2 = filter["w_CrewWatchlist"];
                CrewWatchlist.AdvancedSearch.Save();
            }

            // Field PreviousAppraisalReport
            if (filter?.TryGetValue("x_PreviousAppraisalReport", out sv) ?? false) {
                PreviousAppraisalReport.AdvancedSearch.SearchValue = sv;
                PreviousAppraisalReport.AdvancedSearch.SearchOperator = filter["z_PreviousAppraisalReport"];
                PreviousAppraisalReport.AdvancedSearch.SearchCondition = filter["v_PreviousAppraisalReport"];
                PreviousAppraisalReport.AdvancedSearch.SearchValue2 = filter["y_PreviousAppraisalReport"];
                PreviousAppraisalReport.AdvancedSearch.SearchOperator2 = filter["w_PreviousAppraisalReport"];
                PreviousAppraisalReport.AdvancedSearch.Save();
            }

            // Field ContractBackgroundCheck
            if (filter?.TryGetValue("x_ContractBackgroundCheck", out sv) ?? false) {
                ContractBackgroundCheck.AdvancedSearch.SearchValue = sv;
                ContractBackgroundCheck.AdvancedSearch.SearchOperator = filter["z_ContractBackgroundCheck"];
                ContractBackgroundCheck.AdvancedSearch.SearchCondition = filter["v_ContractBackgroundCheck"];
                ContractBackgroundCheck.AdvancedSearch.SearchValue2 = filter["y_ContractBackgroundCheck"];
                ContractBackgroundCheck.AdvancedSearch.SearchOperator2 = filter["w_ContractBackgroundCheck"];
                ContractBackgroundCheck.AdvancedSearch.Save();
            }

            // Field EnglishProficiencyTestOrMarline
            if (filter?.TryGetValue("x_EnglishProficiencyTestOrMarline", out sv) ?? false) {
                EnglishProficiencyTestOrMarline.AdvancedSearch.SearchValue = sv;
                EnglishProficiencyTestOrMarline.AdvancedSearch.SearchOperator = filter["z_EnglishProficiencyTestOrMarline"];
                EnglishProficiencyTestOrMarline.AdvancedSearch.SearchCondition = filter["v_EnglishProficiencyTestOrMarline"];
                EnglishProficiencyTestOrMarline.AdvancedSearch.SearchValue2 = filter["y_EnglishProficiencyTestOrMarline"];
                EnglishProficiencyTestOrMarline.AdvancedSearch.SearchOperator2 = filter["w_EnglishProficiencyTestOrMarline"];
                EnglishProficiencyTestOrMarline.AdvancedSearch.Save();
            }

            // Field Interviewed
            if (filter?.TryGetValue("x_Interviewed", out sv) ?? false) {
                Interviewed.AdvancedSearch.SearchValue = sv;
                Interviewed.AdvancedSearch.SearchOperator = filter["z_Interviewed"];
                Interviewed.AdvancedSearch.SearchCondition = filter["v_Interviewed"];
                Interviewed.AdvancedSearch.SearchValue2 = filter["y_Interviewed"];
                Interviewed.AdvancedSearch.SearchOperator2 = filter["w_Interviewed"];
                Interviewed.AdvancedSearch.Save();
            }

            // Field Approved
            if (filter?.TryGetValue("x_Approved", out sv) ?? false) {
                Approved.AdvancedSearch.SearchValue = sv;
                Approved.AdvancedSearch.SearchOperator = filter["z_Approved"];
                Approved.AdvancedSearch.SearchCondition = filter["v_Approved"];
                Approved.AdvancedSearch.SearchValue2 = filter["y_Approved"];
                Approved.AdvancedSearch.SearchOperator2 = filter["w_Approved"];
                Approved.AdvancedSearch.Save();
            }

            // Field MedicalCheckup
            if (filter?.TryGetValue("x_MedicalCheckup", out sv) ?? false) {
                MedicalCheckup.AdvancedSearch.SearchValue = sv;
                MedicalCheckup.AdvancedSearch.SearchOperator = filter["z_MedicalCheckup"];
                MedicalCheckup.AdvancedSearch.SearchCondition = filter["v_MedicalCheckup"];
                MedicalCheckup.AdvancedSearch.SearchValue2 = filter["y_MedicalCheckup"];
                MedicalCheckup.AdvancedSearch.SearchOperator2 = filter["w_MedicalCheckup"];
                MedicalCheckup.AdvancedSearch.Save();
            }

            // Field CreatedBy
            if (filter?.TryGetValue("x_CreatedBy", out sv) ?? false) {
                CreatedBy.AdvancedSearch.SearchValue = sv;
                CreatedBy.AdvancedSearch.SearchOperator = filter["z_CreatedBy"];
                CreatedBy.AdvancedSearch.SearchCondition = filter["v_CreatedBy"];
                CreatedBy.AdvancedSearch.SearchValue2 = filter["y_CreatedBy"];
                CreatedBy.AdvancedSearch.SearchOperator2 = filter["w_CreatedBy"];
                CreatedBy.AdvancedSearch.Save();
            }

            // Field LastUpdatedBy
            if (filter?.TryGetValue("x_LastUpdatedBy", out sv) ?? false) {
                LastUpdatedBy.AdvancedSearch.SearchValue = sv;
                LastUpdatedBy.AdvancedSearch.SearchOperator = filter["z_LastUpdatedBy"];
                LastUpdatedBy.AdvancedSearch.SearchCondition = filter["v_LastUpdatedBy"];
                LastUpdatedBy.AdvancedSearch.SearchValue2 = filter["y_LastUpdatedBy"];
                LastUpdatedBy.AdvancedSearch.SearchOperator2 = filter["w_LastUpdatedBy"];
                LastUpdatedBy.AdvancedSearch.Save();
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
            BuildSearchSql(ref where, IndividualCodeNumber, def, true); // IndividualCodeNumber
            BuildSearchSql(ref where, FullName, def, true); // FullName
            BuildSearchSql(ref where, RequiredPhoto, def, true); // RequiredPhoto
            BuildSearchSql(ref where, VisaPhoto, def, true); // VisaPhoto
            BuildSearchSql(ref where, Gender, def, true); // Gender
            BuildSearchSql(ref where, RankAppliedFor, def, true); // RankAppliedFor
            BuildSearchSql(ref where, WillAcceptLowRank, def, true); // WillAcceptLowRank
            BuildSearchSql(ref where, EmployeeStatus, def, true); // EmployeeStatus
            BuildSearchSql(ref where, Draft, def, false); // Draft
            BuildSearchSql(ref where, Submitted, def, false); // Submitted
            BuildSearchSql(ref where, Reviewed, def, false); // Reviewed
            BuildSearchSql(ref where, RegistrationForm, def, false); // RegistrationForm
            BuildSearchSql(ref where, PreScreeningInterview, def, false); // PreScreeningInterview
            BuildSearchSql(ref where, MinimumRecruitmentCheck, def, false); // MinimumRecruitmentCheck
            BuildSearchSql(ref where, EngagementChecklist, def, false); // EngagementChecklist
            BuildSearchSql(ref where, COCAuthenticity, def, false); // COCAuthenticity
            BuildSearchSql(ref where, CESTest, def, false); // CESTest
            BuildSearchSql(ref where, PyschometricTest, def, false); // PyschometricTest
            BuildSearchSql(ref where, CrewWatchlist, def, false); // CrewWatchlist
            BuildSearchSql(ref where, PreviousAppraisalReport, def, false); // PreviousAppraisalReport
            BuildSearchSql(ref where, ContractBackgroundCheck, def, false); // ContractBackgroundCheck
            BuildSearchSql(ref where, EnglishProficiencyTestOrMarline, def, false); // EnglishProficiencyTestOrMarline
            BuildSearchSql(ref where, Interviewed, def, false); // Interviewed
            BuildSearchSql(ref where, Approved, def, false); // Approved
            BuildSearchSql(ref where, MedicalCheckup, def, false); // MedicalCheckup
            BuildSearchSql(ref where, CreatedBy, def, false); // CreatedBy
            BuildSearchSql(ref where, LastUpdatedBy, def, false); // LastUpdatedBy

            // Set up search command
            if (!def && !Empty(where) && (new[] { "", "reset", "resetall" }).Contains(Command))
                Command = "search";
            if (!def && Command == "search") {
                IndividualCodeNumber.AdvancedSearch.Save(); // IndividualCodeNumber
                FullName.AdvancedSearch.Save(); // FullName
                RequiredPhoto.AdvancedSearch.Save(); // RequiredPhoto
                VisaPhoto.AdvancedSearch.Save(); // VisaPhoto
                Gender.AdvancedSearch.Save(); // Gender
                RankAppliedFor.AdvancedSearch.Save(); // RankAppliedFor
                WillAcceptLowRank.AdvancedSearch.Save(); // WillAcceptLowRank
                EmployeeStatus.AdvancedSearch.Save(); // EmployeeStatus
                Draft.AdvancedSearch.Save(); // Draft
                Submitted.AdvancedSearch.Save(); // Submitted
                Reviewed.AdvancedSearch.Save(); // Reviewed
                RegistrationForm.AdvancedSearch.Save(); // RegistrationForm
                PreScreeningInterview.AdvancedSearch.Save(); // PreScreeningInterview
                MinimumRecruitmentCheck.AdvancedSearch.Save(); // MinimumRecruitmentCheck
                EngagementChecklist.AdvancedSearch.Save(); // EngagementChecklist
                COCAuthenticity.AdvancedSearch.Save(); // COCAuthenticity
                CESTest.AdvancedSearch.Save(); // CESTest
                PyschometricTest.AdvancedSearch.Save(); // PyschometricTest
                CrewWatchlist.AdvancedSearch.Save(); // CrewWatchlist
                PreviousAppraisalReport.AdvancedSearch.Save(); // PreviousAppraisalReport
                ContractBackgroundCheck.AdvancedSearch.Save(); // ContractBackgroundCheck
                EnglishProficiencyTestOrMarline.AdvancedSearch.Save(); // EnglishProficiencyTestOrMarline
                Interviewed.AdvancedSearch.Save(); // Interviewed
                Approved.AdvancedSearch.Save(); // Approved
                MedicalCheckup.AdvancedSearch.Save(); // MedicalCheckup
                CreatedBy.AdvancedSearch.Save(); // CreatedBy
                LastUpdatedBy.AdvancedSearch.Save(); // LastUpdatedBy

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

            // Field IndividualCodeNumber
            filter = QueryBuilderWhere("IndividualCodeNumber");
            if (Empty(filter))
                BuildSearchSql(ref filter, IndividualCodeNumber, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + IndividualCodeNumber.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field FullName
            filter = QueryBuilderWhere("FullName");
            if (Empty(filter))
                BuildSearchSql(ref filter, FullName, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + FullName.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field RequiredPhoto
            filter = QueryBuilderWhere("RequiredPhoto");
            if (Empty(filter))
                BuildSearchSql(ref filter, RequiredPhoto, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + RequiredPhoto.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field VisaPhoto
            filter = QueryBuilderWhere("VisaPhoto");
            if (Empty(filter))
                BuildSearchSql(ref filter, VisaPhoto, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + VisaPhoto.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Gender
            filter = QueryBuilderWhere("Gender");
            if (Empty(filter))
                BuildSearchSql(ref filter, Gender, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Gender.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field RankAppliedFor
            filter = QueryBuilderWhere("RankAppliedFor");
            if (Empty(filter))
                BuildSearchSql(ref filter, RankAppliedFor, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + RankAppliedFor.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field WillAcceptLowRank
            filter = QueryBuilderWhere("WillAcceptLowRank");
            if (Empty(filter))
                BuildSearchSql(ref filter, WillAcceptLowRank, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + WillAcceptLowRank.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field EmployeeStatus
            filter = QueryBuilderWhere("EmployeeStatus");
            if (Empty(filter))
                BuildSearchSql(ref filter, EmployeeStatus, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + EmployeeStatus.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Draft
            filter = QueryBuilderWhere("Draft");
            if (Empty(filter))
                BuildSearchSql(ref filter, Draft, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Draft.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Submitted
            filter = QueryBuilderWhere("Submitted");
            if (Empty(filter))
                BuildSearchSql(ref filter, Submitted, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Submitted.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Reviewed
            filter = QueryBuilderWhere("Reviewed");
            if (Empty(filter))
                BuildSearchSql(ref filter, Reviewed, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Reviewed.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field RegistrationForm
            filter = QueryBuilderWhere("RegistrationForm");
            if (Empty(filter))
                BuildSearchSql(ref filter, RegistrationForm, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + RegistrationForm.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field PreScreeningInterview
            filter = QueryBuilderWhere("PreScreeningInterview");
            if (Empty(filter))
                BuildSearchSql(ref filter, PreScreeningInterview, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + PreScreeningInterview.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field MinimumRecruitmentCheck
            filter = QueryBuilderWhere("MinimumRecruitmentCheck");
            if (Empty(filter))
                BuildSearchSql(ref filter, MinimumRecruitmentCheck, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + MinimumRecruitmentCheck.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field EngagementChecklist
            filter = QueryBuilderWhere("EngagementChecklist");
            if (Empty(filter))
                BuildSearchSql(ref filter, EngagementChecklist, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + EngagementChecklist.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field COCAuthenticity
            filter = QueryBuilderWhere("COCAuthenticity");
            if (Empty(filter))
                BuildSearchSql(ref filter, COCAuthenticity, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + COCAuthenticity.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CESTest
            filter = QueryBuilderWhere("CESTest");
            if (Empty(filter))
                BuildSearchSql(ref filter, CESTest, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CESTest.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field PyschometricTest
            filter = QueryBuilderWhere("PyschometricTest");
            if (Empty(filter))
                BuildSearchSql(ref filter, PyschometricTest, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + PyschometricTest.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CrewWatchlist
            filter = QueryBuilderWhere("CrewWatchlist");
            if (Empty(filter))
                BuildSearchSql(ref filter, CrewWatchlist, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CrewWatchlist.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field PreviousAppraisalReport
            filter = QueryBuilderWhere("PreviousAppraisalReport");
            if (Empty(filter))
                BuildSearchSql(ref filter, PreviousAppraisalReport, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + PreviousAppraisalReport.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field ContractBackgroundCheck
            filter = QueryBuilderWhere("ContractBackgroundCheck");
            if (Empty(filter))
                BuildSearchSql(ref filter, ContractBackgroundCheck, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + ContractBackgroundCheck.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field EnglishProficiencyTestOrMarline
            filter = QueryBuilderWhere("EnglishProficiencyTestOrMarline");
            if (Empty(filter))
                BuildSearchSql(ref filter, EnglishProficiencyTestOrMarline, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + EnglishProficiencyTestOrMarline.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Interviewed
            filter = QueryBuilderWhere("Interviewed");
            if (Empty(filter))
                BuildSearchSql(ref filter, Interviewed, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Interviewed.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Approved
            filter = QueryBuilderWhere("Approved");
            if (Empty(filter))
                BuildSearchSql(ref filter, Approved, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Approved.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field MedicalCheckup
            filter = QueryBuilderWhere("MedicalCheckup");
            if (Empty(filter))
                BuildSearchSql(ref filter, MedicalCheckup, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + MedicalCheckup.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CreatedBy
            filter = QueryBuilderWhere("CreatedBy");
            if (Empty(filter))
                BuildSearchSql(ref filter, CreatedBy, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CreatedBy.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LastUpdatedBy
            filter = QueryBuilderWhere("LastUpdatedBy");
            if (Empty(filter))
                BuildSearchSql(ref filter, LastUpdatedBy, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LastUpdatedBy.Caption + "</span>" + captionSuffix + filter + "</div>";
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
            searchFlds.Add(IndividualCodeNumber);
            searchFlds.Add(FullName);
            searchFlds.Add(RequiredPhoto);
            searchFlds.Add(VisaPhoto);
            searchFlds.Add(Gender);
            searchFlds.Add(RankAppliedFor);
            searchFlds.Add(EmployeeStatus);
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
            if (IndividualCodeNumber.AdvancedSearch.IssetSession)
                return true;
            if (FullName.AdvancedSearch.IssetSession)
                return true;
            if (RequiredPhoto.AdvancedSearch.IssetSession)
                return true;
            if (VisaPhoto.AdvancedSearch.IssetSession)
                return true;
            if (Gender.AdvancedSearch.IssetSession)
                return true;
            if (RankAppliedFor.AdvancedSearch.IssetSession)
                return true;
            if (WillAcceptLowRank.AdvancedSearch.IssetSession)
                return true;
            if (EmployeeStatus.AdvancedSearch.IssetSession)
                return true;
            if (Draft.AdvancedSearch.IssetSession)
                return true;
            if (Submitted.AdvancedSearch.IssetSession)
                return true;
            if (Reviewed.AdvancedSearch.IssetSession)
                return true;
            if (RegistrationForm.AdvancedSearch.IssetSession)
                return true;
            if (PreScreeningInterview.AdvancedSearch.IssetSession)
                return true;
            if (MinimumRecruitmentCheck.AdvancedSearch.IssetSession)
                return true;
            if (EngagementChecklist.AdvancedSearch.IssetSession)
                return true;
            if (COCAuthenticity.AdvancedSearch.IssetSession)
                return true;
            if (CESTest.AdvancedSearch.IssetSession)
                return true;
            if (PyschometricTest.AdvancedSearch.IssetSession)
                return true;
            if (CrewWatchlist.AdvancedSearch.IssetSession)
                return true;
            if (PreviousAppraisalReport.AdvancedSearch.IssetSession)
                return true;
            if (ContractBackgroundCheck.AdvancedSearch.IssetSession)
                return true;
            if (EnglishProficiencyTestOrMarline.AdvancedSearch.IssetSession)
                return true;
            if (Interviewed.AdvancedSearch.IssetSession)
                return true;
            if (Approved.AdvancedSearch.IssetSession)
                return true;
            if (MedicalCheckup.AdvancedSearch.IssetSession)
                return true;
            if (CreatedBy.AdvancedSearch.IssetSession)
                return true;
            if (LastUpdatedBy.AdvancedSearch.IssetSession)
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
            IndividualCodeNumber.AdvancedSearch.UnsetSession();
            FullName.AdvancedSearch.UnsetSession();
            RequiredPhoto.AdvancedSearch.UnsetSession();
            VisaPhoto.AdvancedSearch.UnsetSession();
            Gender.AdvancedSearch.UnsetSession();
            RankAppliedFor.AdvancedSearch.UnsetSession();
            WillAcceptLowRank.AdvancedSearch.UnsetSession();
            EmployeeStatus.AdvancedSearch.UnsetSession();
            Draft.AdvancedSearch.UnsetSession();
            Submitted.AdvancedSearch.UnsetSession();
            Reviewed.AdvancedSearch.UnsetSession();
            RegistrationForm.AdvancedSearch.UnsetSession();
            PreScreeningInterview.AdvancedSearch.UnsetSession();
            MinimumRecruitmentCheck.AdvancedSearch.UnsetSession();
            EngagementChecklist.AdvancedSearch.UnsetSession();
            COCAuthenticity.AdvancedSearch.UnsetSession();
            CESTest.AdvancedSearch.UnsetSession();
            PyschometricTest.AdvancedSearch.UnsetSession();
            CrewWatchlist.AdvancedSearch.UnsetSession();
            PreviousAppraisalReport.AdvancedSearch.UnsetSession();
            ContractBackgroundCheck.AdvancedSearch.UnsetSession();
            EnglishProficiencyTestOrMarline.AdvancedSearch.UnsetSession();
            Interviewed.AdvancedSearch.UnsetSession();
            Approved.AdvancedSearch.UnsetSession();
            MedicalCheckup.AdvancedSearch.UnsetSession();
            CreatedBy.AdvancedSearch.UnsetSession();
            LastUpdatedBy.AdvancedSearch.UnsetSession();
        }

        // Restore all search parameters
        protected void RestoreSearchParms() {
            RestoreSearch = true;

            // Restore basic search values
            BasicSearch.Load();

            // Restore advanced search values
            IndividualCodeNumber.AdvancedSearch.Load();
            FullName.AdvancedSearch.Load();
            RequiredPhoto.AdvancedSearch.Load();
            VisaPhoto.AdvancedSearch.Load();
            Gender.AdvancedSearch.Load();
            RankAppliedFor.AdvancedSearch.Load();
            WillAcceptLowRank.AdvancedSearch.Load();
            EmployeeStatus.AdvancedSearch.Load();
            Draft.AdvancedSearch.Load();
            Submitted.AdvancedSearch.Load();
            Reviewed.AdvancedSearch.Load();
            RegistrationForm.AdvancedSearch.Load();
            PreScreeningInterview.AdvancedSearch.Load();
            MinimumRecruitmentCheck.AdvancedSearch.Load();
            EngagementChecklist.AdvancedSearch.Load();
            COCAuthenticity.AdvancedSearch.Load();
            CESTest.AdvancedSearch.Load();
            PyschometricTest.AdvancedSearch.Load();
            CrewWatchlist.AdvancedSearch.Load();
            PreviousAppraisalReport.AdvancedSearch.Load();
            ContractBackgroundCheck.AdvancedSearch.Load();
            EnglishProficiencyTestOrMarline.AdvancedSearch.Load();
            Interviewed.AdvancedSearch.Load();
            Approved.AdvancedSearch.Load();
            MedicalCheckup.AdvancedSearch.Load();
            CreatedBy.AdvancedSearch.Load();
            LastUpdatedBy.AdvancedSearch.Load();
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
                UpdateSort(IndividualCodeNumber, ctrl); // IndividualCodeNumber
                UpdateSort(FullName, ctrl); // FullName
                UpdateSort(RequiredPhoto, ctrl); // RequiredPhoto
                UpdateSort(VisaPhoto, ctrl); // VisaPhoto
                UpdateSort(Gender, ctrl); // Gender
                UpdateSort(RankAppliedFor, ctrl); // RankAppliedFor
                UpdateSort(WillAcceptLowRank, ctrl); // WillAcceptLowRank
                UpdateSort(EmployeeStatus, ctrl); // EmployeeStatus
                UpdateSort(Draft, ctrl); // Draft
                UpdateSort(Submitted, ctrl); // Submitted
                UpdateSort(Reviewed, ctrl); // Reviewed
                UpdateSort(RegistrationForm, ctrl); // RegistrationForm
                UpdateSort(PreScreeningInterview, ctrl); // PreScreeningInterview
                UpdateSort(MinimumRecruitmentCheck, ctrl); // MinimumRecruitmentCheck
                UpdateSort(EngagementChecklist, ctrl); // EngagementChecklist
                UpdateSort(COCAuthenticity, ctrl); // COCAuthenticity
                UpdateSort(CESTest, ctrl); // CESTest
                UpdateSort(PyschometricTest, ctrl); // PyschometricTest
                UpdateSort(CrewWatchlist, ctrl); // CrewWatchlist
                UpdateSort(PreviousAppraisalReport, ctrl); // PreviousAppraisalReport
                UpdateSort(ContractBackgroundCheck, ctrl); // ContractBackgroundCheck
                UpdateSort(EnglishProficiencyTestOrMarline, ctrl); // EnglishProficiencyTestOrMarline
                UpdateSort(Interviewed, ctrl); // Interviewed
                UpdateSort(Approved, ctrl); // Approved
                UpdateSort(MedicalCheckup, ctrl); // MedicalCheckup
                UpdateSort(CreatedBy, ctrl); // CreatedBy
                UpdateSort(LastUpdatedBy, ctrl); // LastUpdatedBy
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
                    IndividualCodeNumber.Sort = "";
                    FullName.Sort = "";
                    RequiredPhoto.Sort = "";
                    VisaPhoto.Sort = "";
                    Gender.Sort = "";
                    RankAppliedFor.Sort = "";
                    WillAcceptLowRank.Sort = "";
                    EmployeeStatus.Sort = "";
                    Draft.Sort = "";
                    Submitted.Sort = "";
                    Reviewed.Sort = "";
                    RegistrationForm.Sort = "";
                    PreScreeningInterview.Sort = "";
                    MinimumRecruitmentCheck.Sort = "";
                    EngagementChecklist.Sort = "";
                    COCAuthenticity.Sort = "";
                    CESTest.Sort = "";
                    PyschometricTest.Sort = "";
                    CrewWatchlist.Sort = "";
                    PreviousAppraisalReport.Sort = "";
                    ContractBackgroundCheck.Sort = "";
                    EnglishProficiencyTestOrMarline.Sort = "";
                    Interviewed.Sort = "";
                    Approved.Sort = "";
                    MedicalCheckup.Sort = "";
                    CreatedBy.Sort = "";
                    LastUpdatedBy.Sort = "";
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

            // "delete"
            item = ListOptions.Add("delete");
            item.CssClass = "text-nowrap";
            item.Visible = Security.CanDelete;
            item.OnLeft = true;

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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-table=""v_CrewTrackingStatus"" data-caption=""{viewcaption}"" data-ew-action=""modal"" data-action=""view"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(ViewUrl)) + "\" data-btn=\"null\">" + Language.Phrase("ViewLink") + "</a>");
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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-table=""v_CrewTrackingStatus"" data-caption=""{editcaption}"" data-ew-action=""modal"" data-action=""edit"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\" data-btn=\"SaveBtn\">" + Language.Phrase("EditLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-caption=""{editcaption}"" href=""" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("EditLink") + "</a>");
            } else {
                listOption?.Clear();
            }

            // "delete"
            listOption = ListOptions["delete"];
            isVisible = Security.CanDelete;
            if (isVisible) {
                string deleteCaption = Language.Phrase("DeleteLink");
                string deleteTitle = Language.Phrase("DeleteLink", true);
                if (UseAjaxActions)
                    listOption?.SetBody($@"<a class=""ew-row-link ew-delete"" data-ew-action=""inline"" data-action=""delete"" title=""{deleteTitle}"" data-caption=""{deleteTitle}"" data-key=""" + HtmlEncode(GetKey(true)) + "\" data-url=\"" + HtmlEncode(AppPath(DeleteUrl)) + "\">" + deleteCaption + "</a>");
                else
                    listOption?.SetBody(@"<a class=""ew-row-link ew-delete""" +
                        (InlineDelete ? @" data-ew-action=""inline-delete""" : "") +
                        $@" title=""{deleteTitle}"" data-caption=""{deleteTitle}"" href=""" + HtmlEncode(AppPath(DeleteUrl)) + "\">" + deleteCaption + "</a>");
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
                        string link = "<li><button type=\"button\" class=\"dropdown-item ew-action ew-list-action\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fv_CrewTrackingStatuslist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttrs() + ">" + icon + " " + caption + "</button></li>";
                        if (!Empty(link)) {
                            links.Add(link);
                            if (Empty(body)) // Setup first button
                                body = "<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlTitle(caption) + "\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fv_CrewTrackingStatuslist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttrs() + ">" + icon + caption + "</button>";
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

            // "checkbox"
            listOption = ListOptions["checkbox"];
            listOption?.SetBody("<div class=\"form-check\"><input type=\"checkbox\" id=\"key_m_" + RowCount + "\" name=\"key_m[]\" class=\"form-check-input ew-multi-select\" value=\"" + HtmlEncode(ID.CurrentValue) + "\" data-ew-action=\"select-key\"></div>");
            RenderListOptionsExt();

            // Call ListOptions Rendered event
            ListOptionsRendered();
        }

        // Render list options (extensions)
        protected void RenderListOptionsExt() {
            // Render list options (to be implemented by extensions)
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
                CreateColumnOption(option.Add("IndividualCodeNumber")); // DN
                CreateColumnOption(option.Add("FullName")); // DN
                CreateColumnOption(option.Add("RequiredPhoto")); // DN
                CreateColumnOption(option.Add("VisaPhoto")); // DN
                CreateColumnOption(option.Add("Gender")); // DN
                CreateColumnOption(option.Add("RankAppliedFor")); // DN
                CreateColumnOption(option.Add("WillAcceptLowRank")); // DN
                CreateColumnOption(option.Add("EmployeeStatus")); // DN
                CreateColumnOption(option.Add("Draft")); // DN
                CreateColumnOption(option.Add("Submitted")); // DN
                CreateColumnOption(option.Add("Reviewed")); // DN
                CreateColumnOption(option.Add("RegistrationForm")); // DN
                CreateColumnOption(option.Add("PreScreeningInterview")); // DN
                CreateColumnOption(option.Add("MinimumRecruitmentCheck")); // DN
                CreateColumnOption(option.Add("EngagementChecklist")); // DN
                CreateColumnOption(option.Add("COCAuthenticity")); // DN
                CreateColumnOption(option.Add("CESTest")); // DN
                CreateColumnOption(option.Add("PyschometricTest")); // DN
                CreateColumnOption(option.Add("CrewWatchlist")); // DN
                CreateColumnOption(option.Add("PreviousAppraisalReport")); // DN
                CreateColumnOption(option.Add("ContractBackgroundCheck")); // DN
                CreateColumnOption(option.Add("EnglishProficiencyTestOrMarline")); // DN
                CreateColumnOption(option.Add("Interviewed")); // DN
                CreateColumnOption(option.Add("Approved")); // DN
                CreateColumnOption(option.Add("MedicalCheckup")); // DN
                CreateColumnOption(option.Add("CreatedBy")); // DN
                CreateColumnOption(option.Add("LastUpdatedBy")); // DN
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
            item.Body = "<a class=\"ew-save-filter\" data-form=\"fv_CrewTrackingStatussrch\" data-ew-action=\"none\">" + Language.Phrase("SaveCurrentFilter") + "</a>";
            item.Visible = true;
            item = FilterOptions.Add("deletefilter");
            item.Body = "<a class=\"ew-delete-filter\" data-form=\"fv_CrewTrackingStatussrch\" data-ew-action=\"none\">" + Language.Phrase("DeleteFilter") + "</a>";
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
                    item.Body = "<<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlEncode(caption) + "\" data-caption=\"" + HtmlEncode(caption) + "\" data-ew-action=\"submit\" form=\"fv_CrewTrackingStatuslist\"" + act.ToDataAttrs() + ">" + icon + "</button>";
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
                    RowAttrs.Add("id", "r0_v_CrewTrackingStatus");
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
            RowAttrs.Add("data-rowindex", ConvertToString(vCrewTrackingStatusList.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(vCrewTrackingStatusList.RowCount) + "_v_CrewTrackingStatus");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(vCrewTrackingStatusList.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && vCrewTrackingStatusList.RowType == RowType.Add || IsEdit && vCrewTrackingStatusList.RowType == RowType.Edit) // Inline-Add/Edit row
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

            // IndividualCodeNumber
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_IndividualCodeNumber[]"))
                    IndividualCodeNumber.AdvancedSearch.SearchValue = Get("x_IndividualCodeNumber[]");
                else
                    IndividualCodeNumber.AdvancedSearch.SearchValue = Get("IndividualCodeNumber"); // Default Value // DN
            if (!Empty(IndividualCodeNumber.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_IndividualCodeNumber"))
                IndividualCodeNumber.AdvancedSearch.SearchOperator = Get("z_IndividualCodeNumber");

            // FullName
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_FullName[]"))
                    FullName.AdvancedSearch.SearchValue = Get("x_FullName[]");
                else
                    FullName.AdvancedSearch.SearchValue = Get("FullName"); // Default Value // DN
            if (!Empty(FullName.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_FullName"))
                FullName.AdvancedSearch.SearchOperator = Get("z_FullName");

            // RequiredPhoto
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_RequiredPhoto[]"))
                    RequiredPhoto.AdvancedSearch.SearchValue = Get("x_RequiredPhoto[]");
                else
                    RequiredPhoto.AdvancedSearch.SearchValue = Get("RequiredPhoto"); // Default Value // DN
            if (!Empty(RequiredPhoto.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_RequiredPhoto"))
                RequiredPhoto.AdvancedSearch.SearchOperator = Get("z_RequiredPhoto");

            // VisaPhoto
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_VisaPhoto[]"))
                    VisaPhoto.AdvancedSearch.SearchValue = Get("x_VisaPhoto[]");
                else
                    VisaPhoto.AdvancedSearch.SearchValue = Get("VisaPhoto"); // Default Value // DN
            if (!Empty(VisaPhoto.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_VisaPhoto"))
                VisaPhoto.AdvancedSearch.SearchOperator = Get("z_VisaPhoto");

            // Gender
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Gender[]"))
                    Gender.AdvancedSearch.SearchValue = Get("x_Gender[]");
                else
                    Gender.AdvancedSearch.SearchValue = Get("Gender"); // Default Value // DN
            if (!Empty(Gender.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Gender"))
                Gender.AdvancedSearch.SearchOperator = Get("z_Gender");

            // RankAppliedFor
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_RankAppliedFor[]"))
                    RankAppliedFor.AdvancedSearch.SearchValue = Get("x_RankAppliedFor[]");
                else
                    RankAppliedFor.AdvancedSearch.SearchValue = Get("RankAppliedFor"); // Default Value // DN
            if (!Empty(RankAppliedFor.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_RankAppliedFor"))
                RankAppliedFor.AdvancedSearch.SearchOperator = Get("z_RankAppliedFor");

            // WillAcceptLowRank
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_WillAcceptLowRank[]"))
                    WillAcceptLowRank.AdvancedSearch.SearchValue = Get("x_WillAcceptLowRank[]");
                else
                    WillAcceptLowRank.AdvancedSearch.SearchValue = Get("WillAcceptLowRank"); // Default Value // DN
            if (!Empty(WillAcceptLowRank.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_WillAcceptLowRank"))
                WillAcceptLowRank.AdvancedSearch.SearchOperator = Get("z_WillAcceptLowRank");

            // EmployeeStatus
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_EmployeeStatus[]"))
                    EmployeeStatus.AdvancedSearch.SearchValue = Get("x_EmployeeStatus[]");
                else
                    EmployeeStatus.AdvancedSearch.SearchValue = Get("EmployeeStatus"); // Default Value // DN
            if (!Empty(EmployeeStatus.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_EmployeeStatus"))
                EmployeeStatus.AdvancedSearch.SearchOperator = Get("z_EmployeeStatus");

            // Draft
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Draft"))
                    Draft.AdvancedSearch.SearchValue = Get("x_Draft");
                else
                    Draft.AdvancedSearch.SearchValue = Get("Draft"); // Default Value // DN
            if (!Empty(Draft.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Draft"))
                Draft.AdvancedSearch.SearchOperator = Get("z_Draft");

            // Submitted
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Submitted"))
                    Submitted.AdvancedSearch.SearchValue = Get("x_Submitted");
                else
                    Submitted.AdvancedSearch.SearchValue = Get("Submitted"); // Default Value // DN
            if (!Empty(Submitted.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Submitted"))
                Submitted.AdvancedSearch.SearchOperator = Get("z_Submitted");

            // Reviewed
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Reviewed"))
                    Reviewed.AdvancedSearch.SearchValue = Get("x_Reviewed");
                else
                    Reviewed.AdvancedSearch.SearchValue = Get("Reviewed"); // Default Value // DN
            if (!Empty(Reviewed.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Reviewed"))
                Reviewed.AdvancedSearch.SearchOperator = Get("z_Reviewed");

            // RegistrationForm
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_RegistrationForm"))
                    RegistrationForm.AdvancedSearch.SearchValue = Get("x_RegistrationForm");
                else
                    RegistrationForm.AdvancedSearch.SearchValue = Get("RegistrationForm"); // Default Value // DN
            if (!Empty(RegistrationForm.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_RegistrationForm"))
                RegistrationForm.AdvancedSearch.SearchOperator = Get("z_RegistrationForm");

            // PreScreeningInterview
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PreScreeningInterview"))
                    PreScreeningInterview.AdvancedSearch.SearchValue = Get("x_PreScreeningInterview");
                else
                    PreScreeningInterview.AdvancedSearch.SearchValue = Get("PreScreeningInterview"); // Default Value // DN
            if (!Empty(PreScreeningInterview.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PreScreeningInterview"))
                PreScreeningInterview.AdvancedSearch.SearchOperator = Get("z_PreScreeningInterview");

            // MinimumRecruitmentCheck
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_MinimumRecruitmentCheck"))
                    MinimumRecruitmentCheck.AdvancedSearch.SearchValue = Get("x_MinimumRecruitmentCheck");
                else
                    MinimumRecruitmentCheck.AdvancedSearch.SearchValue = Get("MinimumRecruitmentCheck"); // Default Value // DN
            if (!Empty(MinimumRecruitmentCheck.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_MinimumRecruitmentCheck"))
                MinimumRecruitmentCheck.AdvancedSearch.SearchOperator = Get("z_MinimumRecruitmentCheck");

            // EngagementChecklist
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_EngagementChecklist"))
                    EngagementChecklist.AdvancedSearch.SearchValue = Get("x_EngagementChecklist");
                else
                    EngagementChecklist.AdvancedSearch.SearchValue = Get("EngagementChecklist"); // Default Value // DN
            if (!Empty(EngagementChecklist.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_EngagementChecklist"))
                EngagementChecklist.AdvancedSearch.SearchOperator = Get("z_EngagementChecklist");

            // COCAuthenticity
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_COCAuthenticity"))
                    COCAuthenticity.AdvancedSearch.SearchValue = Get("x_COCAuthenticity");
                else
                    COCAuthenticity.AdvancedSearch.SearchValue = Get("COCAuthenticity"); // Default Value // DN
            if (!Empty(COCAuthenticity.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_COCAuthenticity"))
                COCAuthenticity.AdvancedSearch.SearchOperator = Get("z_COCAuthenticity");

            // CESTest
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CESTest"))
                    CESTest.AdvancedSearch.SearchValue = Get("x_CESTest");
                else
                    CESTest.AdvancedSearch.SearchValue = Get("CESTest"); // Default Value // DN
            if (!Empty(CESTest.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CESTest"))
                CESTest.AdvancedSearch.SearchOperator = Get("z_CESTest");

            // PyschometricTest
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PyschometricTest"))
                    PyschometricTest.AdvancedSearch.SearchValue = Get("x_PyschometricTest");
                else
                    PyschometricTest.AdvancedSearch.SearchValue = Get("PyschometricTest"); // Default Value // DN
            if (!Empty(PyschometricTest.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PyschometricTest"))
                PyschometricTest.AdvancedSearch.SearchOperator = Get("z_PyschometricTest");

            // CrewWatchlist
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CrewWatchlist"))
                    CrewWatchlist.AdvancedSearch.SearchValue = Get("x_CrewWatchlist");
                else
                    CrewWatchlist.AdvancedSearch.SearchValue = Get("CrewWatchlist"); // Default Value // DN
            if (!Empty(CrewWatchlist.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CrewWatchlist"))
                CrewWatchlist.AdvancedSearch.SearchOperator = Get("z_CrewWatchlist");

            // PreviousAppraisalReport
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PreviousAppraisalReport"))
                    PreviousAppraisalReport.AdvancedSearch.SearchValue = Get("x_PreviousAppraisalReport");
                else
                    PreviousAppraisalReport.AdvancedSearch.SearchValue = Get("PreviousAppraisalReport"); // Default Value // DN
            if (!Empty(PreviousAppraisalReport.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PreviousAppraisalReport"))
                PreviousAppraisalReport.AdvancedSearch.SearchOperator = Get("z_PreviousAppraisalReport");

            // ContractBackgroundCheck
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_ContractBackgroundCheck"))
                    ContractBackgroundCheck.AdvancedSearch.SearchValue = Get("x_ContractBackgroundCheck");
                else
                    ContractBackgroundCheck.AdvancedSearch.SearchValue = Get("ContractBackgroundCheck"); // Default Value // DN
            if (!Empty(ContractBackgroundCheck.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_ContractBackgroundCheck"))
                ContractBackgroundCheck.AdvancedSearch.SearchOperator = Get("z_ContractBackgroundCheck");

            // EnglishProficiencyTestOrMarline
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_EnglishProficiencyTestOrMarline"))
                    EnglishProficiencyTestOrMarline.AdvancedSearch.SearchValue = Get("x_EnglishProficiencyTestOrMarline");
                else
                    EnglishProficiencyTestOrMarline.AdvancedSearch.SearchValue = Get("EnglishProficiencyTestOrMarline"); // Default Value // DN
            if (!Empty(EnglishProficiencyTestOrMarline.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_EnglishProficiencyTestOrMarline"))
                EnglishProficiencyTestOrMarline.AdvancedSearch.SearchOperator = Get("z_EnglishProficiencyTestOrMarline");

            // Interviewed
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Interviewed"))
                    Interviewed.AdvancedSearch.SearchValue = Get("x_Interviewed");
                else
                    Interviewed.AdvancedSearch.SearchValue = Get("Interviewed"); // Default Value // DN
            if (!Empty(Interviewed.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Interviewed"))
                Interviewed.AdvancedSearch.SearchOperator = Get("z_Interviewed");

            // Approved
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Approved"))
                    Approved.AdvancedSearch.SearchValue = Get("x_Approved");
                else
                    Approved.AdvancedSearch.SearchValue = Get("Approved"); // Default Value // DN
            if (!Empty(Approved.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Approved"))
                Approved.AdvancedSearch.SearchOperator = Get("z_Approved");

            // MedicalCheckup
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_MedicalCheckup"))
                    MedicalCheckup.AdvancedSearch.SearchValue = Get("x_MedicalCheckup");
                else
                    MedicalCheckup.AdvancedSearch.SearchValue = Get("MedicalCheckup"); // Default Value // DN
            if (!Empty(MedicalCheckup.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_MedicalCheckup"))
                MedicalCheckup.AdvancedSearch.SearchOperator = Get("z_MedicalCheckup");

            // CreatedBy
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CreatedBy"))
                    CreatedBy.AdvancedSearch.SearchValue = Get("x_CreatedBy");
                else
                    CreatedBy.AdvancedSearch.SearchValue = Get("CreatedBy"); // Default Value // DN
            if (!Empty(CreatedBy.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CreatedBy"))
                CreatedBy.AdvancedSearch.SearchOperator = Get("z_CreatedBy");

            // LastUpdatedBy
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LastUpdatedBy"))
                    LastUpdatedBy.AdvancedSearch.SearchValue = Get("x_LastUpdatedBy");
                else
                    LastUpdatedBy.AdvancedSearch.SearchValue = Get("LastUpdatedBy"); // Default Value // DN
            if (!Empty(LastUpdatedBy.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LastUpdatedBy"))
                LastUpdatedBy.AdvancedSearch.SearchOperator = Get("z_LastUpdatedBy");
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
            IndividualCodeNumber.SetDbValue(row["IndividualCodeNumber"]);
            FullName.SetDbValue(row["FullName"]);
            RequiredPhoto.SetDbValue(row["RequiredPhoto"]);
            VisaPhoto.SetDbValue(row["VisaPhoto"]);
            Gender.SetDbValue(row["Gender"]);
            RankAppliedFor.SetDbValue(row["RankAppliedFor"]);
            WillAcceptLowRank.SetDbValue((ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"));
            EmployeeStatus.SetDbValue(row["EmployeeStatus"]);
            Draft.SetDbValue(row["Draft"]);
            Submitted.SetDbValue(row["Submitted"]);
            Reviewed.SetDbValue(row["Reviewed"]);
            RegistrationForm.SetDbValue(row["RegistrationForm"]);
            PreScreeningInterview.SetDbValue(row["PreScreeningInterview"]);
            MinimumRecruitmentCheck.SetDbValue(row["MinimumRecruitmentCheck"]);
            EngagementChecklist.SetDbValue(row["EngagementChecklist"]);
            COCAuthenticity.SetDbValue(row["COCAuthenticity"]);
            CESTest.SetDbValue(row["CESTest"]);
            PyschometricTest.SetDbValue(row["PyschometricTest"]);
            CrewWatchlist.SetDbValue(row["CrewWatchlist"]);
            PreviousAppraisalReport.SetDbValue(row["PreviousAppraisalReport"]);
            ContractBackgroundCheck.SetDbValue(row["ContractBackgroundCheck"]);
            EnglishProficiencyTestOrMarline.SetDbValue(row["EnglishProficiencyTestOrMarline"]);
            Interviewed.SetDbValue(row["Interviewed"]);
            Approved.SetDbValue(row["Approved"]);
            MedicalCheckup.SetDbValue(row["MedicalCheckup"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("IndividualCodeNumber", IndividualCodeNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("RequiredPhoto", RequiredPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("VisaPhoto", VisaPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("Gender", Gender.DefaultValue ?? DbNullValue); // DN
            row.Add("RankAppliedFor", RankAppliedFor.DefaultValue ?? DbNullValue); // DN
            row.Add("WillAcceptLowRank", WillAcceptLowRank.DefaultValue ?? DbNullValue); // DN
            row.Add("EmployeeStatus", EmployeeStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("Draft", Draft.DefaultValue ?? DbNullValue); // DN
            row.Add("Submitted", Submitted.DefaultValue ?? DbNullValue); // DN
            row.Add("Reviewed", Reviewed.DefaultValue ?? DbNullValue); // DN
            row.Add("RegistrationForm", RegistrationForm.DefaultValue ?? DbNullValue); // DN
            row.Add("PreScreeningInterview", PreScreeningInterview.DefaultValue ?? DbNullValue); // DN
            row.Add("MinimumRecruitmentCheck", MinimumRecruitmentCheck.DefaultValue ?? DbNullValue); // DN
            row.Add("EngagementChecklist", EngagementChecklist.DefaultValue ?? DbNullValue); // DN
            row.Add("COCAuthenticity", COCAuthenticity.DefaultValue ?? DbNullValue); // DN
            row.Add("CESTest", CESTest.DefaultValue ?? DbNullValue); // DN
            row.Add("PyschometricTest", PyschometricTest.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewWatchlist", CrewWatchlist.DefaultValue ?? DbNullValue); // DN
            row.Add("PreviousAppraisalReport", PreviousAppraisalReport.DefaultValue ?? DbNullValue); // DN
            row.Add("ContractBackgroundCheck", ContractBackgroundCheck.DefaultValue ?? DbNullValue); // DN
            row.Add("EnglishProficiencyTestOrMarline", EnglishProficiencyTestOrMarline.DefaultValue ?? DbNullValue); // DN
            row.Add("Interviewed", Interviewed.DefaultValue ?? DbNullValue); // DN
            row.Add("Approved", Approved.DefaultValue ?? DbNullValue); // DN
            row.Add("MedicalCheckup", MedicalCheckup.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
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

            // IndividualCodeNumber
            IndividualCodeNumber.CellCssStyle = "white-space: nowrap;";

            // FullName
            FullName.CellCssStyle = "white-space: nowrap;";

            // RequiredPhoto
            RequiredPhoto.CellCssStyle = "white-space: nowrap;";

            // VisaPhoto
            VisaPhoto.CellCssStyle = "white-space: nowrap;";

            // Gender
            Gender.CellCssStyle = "white-space: nowrap;";

            // RankAppliedFor
            RankAppliedFor.CellCssStyle = "white-space: nowrap;";

            // WillAcceptLowRank
            WillAcceptLowRank.CellCssStyle = "white-space: nowrap;";

            // EmployeeStatus
            EmployeeStatus.CellCssStyle = "white-space: nowrap;";

            // Draft
            Draft.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Submitted
            Submitted.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Reviewed
            Reviewed.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // RegistrationForm
            RegistrationForm.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PreScreeningInterview
            PreScreeningInterview.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // MinimumRecruitmentCheck
            MinimumRecruitmentCheck.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // EngagementChecklist
            EngagementChecklist.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // COCAuthenticity
            COCAuthenticity.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // CESTest
            CESTest.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PyschometricTest
            PyschometricTest.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // CrewWatchlist
            CrewWatchlist.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PreviousAppraisalReport
            PreviousAppraisalReport.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // ContractBackgroundCheck
            ContractBackgroundCheck.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // EnglishProficiencyTestOrMarline
            EnglishProficiencyTestOrMarline.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Interviewed
            Interviewed.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Approved
            Approved.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // MedicalCheckup
            MedicalCheckup.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // CreatedBy
            CreatedBy.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedBy
            LastUpdatedBy.CellCssStyle = "white-space: nowrap;";

            // View row
            if (RowType == RowType.View) {
                // IndividualCodeNumber
                IndividualCodeNumber.ViewValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
                IndividualCodeNumber.ViewCustomAttributes = "";

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

                // EmployeeStatus
                EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
                EmployeeStatus.ViewCustomAttributes = "";

                // Draft
                Draft.ViewValue = Draft.CurrentValue;
                Draft.ViewValue = FormatNumber(Draft.ViewValue, Draft.FormatPattern);
                Draft.CellCssStyle += "text-align: center;";
                Draft.ViewCustomAttributes = "";

                // Submitted
                Submitted.ViewValue = Submitted.CurrentValue;
                Submitted.ViewValue = FormatNumber(Submitted.ViewValue, Submitted.FormatPattern);
                Submitted.CellCssStyle += "text-align: center;";
                Submitted.ViewCustomAttributes = "";

                // Reviewed
                Reviewed.ViewValue = Reviewed.CurrentValue;
                Reviewed.ViewValue = FormatNumber(Reviewed.ViewValue, Reviewed.FormatPattern);
                Reviewed.CellCssStyle += "text-align: center;";
                Reviewed.ViewCustomAttributes = "";

                // RegistrationForm
                RegistrationForm.ViewValue = RegistrationForm.CurrentValue;
                RegistrationForm.ViewValue = FormatNumber(RegistrationForm.ViewValue, RegistrationForm.FormatPattern);
                RegistrationForm.CellCssStyle += "text-align: center;";
                RegistrationForm.ViewCustomAttributes = "";

                // PreScreeningInterview
                PreScreeningInterview.ViewValue = PreScreeningInterview.CurrentValue;
                PreScreeningInterview.ViewValue = FormatNumber(PreScreeningInterview.ViewValue, PreScreeningInterview.FormatPattern);
                PreScreeningInterview.CellCssStyle += "text-align: center;";
                PreScreeningInterview.ViewCustomAttributes = "";

                // MinimumRecruitmentCheck
                MinimumRecruitmentCheck.ViewValue = MinimumRecruitmentCheck.CurrentValue;
                MinimumRecruitmentCheck.ViewValue = FormatNumber(MinimumRecruitmentCheck.ViewValue, MinimumRecruitmentCheck.FormatPattern);
                MinimumRecruitmentCheck.CellCssStyle += "text-align: center;";
                MinimumRecruitmentCheck.ViewCustomAttributes = "";

                // EngagementChecklist
                EngagementChecklist.ViewValue = EngagementChecklist.CurrentValue;
                EngagementChecklist.ViewValue = FormatNumber(EngagementChecklist.ViewValue, EngagementChecklist.FormatPattern);
                EngagementChecklist.CellCssStyle += "text-align: center;";
                EngagementChecklist.ViewCustomAttributes = "";

                // COCAuthenticity
                COCAuthenticity.ViewValue = COCAuthenticity.CurrentValue;
                COCAuthenticity.ViewValue = FormatNumber(COCAuthenticity.ViewValue, COCAuthenticity.FormatPattern);
                COCAuthenticity.CellCssStyle += "text-align: center;";
                COCAuthenticity.ViewCustomAttributes = "";

                // CESTest
                CESTest.ViewValue = CESTest.CurrentValue;
                CESTest.ViewValue = FormatNumber(CESTest.ViewValue, CESTest.FormatPattern);
                CESTest.CellCssStyle += "text-align: center;";
                CESTest.ViewCustomAttributes = "";

                // PyschometricTest
                PyschometricTest.ViewValue = PyschometricTest.CurrentValue;
                PyschometricTest.ViewValue = FormatNumber(PyschometricTest.ViewValue, PyschometricTest.FormatPattern);
                PyschometricTest.CellCssStyle += "text-align: center;";
                PyschometricTest.ViewCustomAttributes = "";

                // CrewWatchlist
                CrewWatchlist.ViewValue = CrewWatchlist.CurrentValue;
                CrewWatchlist.ViewValue = FormatNumber(CrewWatchlist.ViewValue, CrewWatchlist.FormatPattern);
                CrewWatchlist.CellCssStyle += "text-align: center;";
                CrewWatchlist.ViewCustomAttributes = "";

                // PreviousAppraisalReport
                PreviousAppraisalReport.ViewValue = PreviousAppraisalReport.CurrentValue;
                PreviousAppraisalReport.ViewValue = FormatNumber(PreviousAppraisalReport.ViewValue, PreviousAppraisalReport.FormatPattern);
                PreviousAppraisalReport.CellCssStyle += "text-align: center;";
                PreviousAppraisalReport.ViewCustomAttributes = "";

                // ContractBackgroundCheck
                ContractBackgroundCheck.ViewValue = ContractBackgroundCheck.CurrentValue;
                ContractBackgroundCheck.ViewValue = FormatNumber(ContractBackgroundCheck.ViewValue, ContractBackgroundCheck.FormatPattern);
                ContractBackgroundCheck.CellCssStyle += "text-align: center;";
                ContractBackgroundCheck.ViewCustomAttributes = "";

                // EnglishProficiencyTestOrMarline
                EnglishProficiencyTestOrMarline.ViewValue = EnglishProficiencyTestOrMarline.CurrentValue;
                EnglishProficiencyTestOrMarline.ViewValue = FormatNumber(EnglishProficiencyTestOrMarline.ViewValue, EnglishProficiencyTestOrMarline.FormatPattern);
                EnglishProficiencyTestOrMarline.CellCssStyle += "text-align: center;";
                EnglishProficiencyTestOrMarline.ViewCustomAttributes = "";

                // Interviewed
                Interviewed.ViewValue = Interviewed.CurrentValue;
                Interviewed.ViewValue = FormatNumber(Interviewed.ViewValue, Interviewed.FormatPattern);
                Interviewed.CellCssStyle += "text-align: center;";
                Interviewed.ViewCustomAttributes = "";

                // Approved
                Approved.ViewValue = Approved.CurrentValue;
                Approved.ViewValue = FormatNumber(Approved.ViewValue, Approved.FormatPattern);
                Approved.CellCssStyle += "text-align: center;";
                Approved.ViewCustomAttributes = "";

                // MedicalCheckup
                MedicalCheckup.ViewValue = MedicalCheckup.CurrentValue;
                MedicalCheckup.ViewValue = FormatNumber(MedicalCheckup.ViewValue, MedicalCheckup.FormatPattern);
                MedicalCheckup.CellCssStyle += "text-align: center;";
                MedicalCheckup.ViewCustomAttributes = "";

                // CreatedBy
                CreatedBy.ViewValue = ConvertToString(CreatedBy.CurrentValue); // DN
                CreatedBy.ViewCustomAttributes = "";

                // LastUpdatedBy
                LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
                LastUpdatedBy.ViewCustomAttributes = "";

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";
                IndividualCodeNumber.TooltipValue = "";

                // FullName
                FullName.HrefValue = "";
                FullName.TooltipValue = "";

                // RequiredPhoto
                RequiredPhoto.HrefValue = "";
                RequiredPhoto.TooltipValue = "";

                // VisaPhoto
                VisaPhoto.HrefValue = "";
                VisaPhoto.TooltipValue = "";

                // Gender
                Gender.HrefValue = "";
                Gender.TooltipValue = "";

                // RankAppliedFor
                RankAppliedFor.HrefValue = "";
                RankAppliedFor.TooltipValue = "";

                // WillAcceptLowRank
                WillAcceptLowRank.HrefValue = "";
                WillAcceptLowRank.TooltipValue = "";

                // EmployeeStatus
                EmployeeStatus.HrefValue = "";
                EmployeeStatus.TooltipValue = "";

                // Draft
                Draft.HrefValue = "";
                Draft.TooltipValue = "";

                // Submitted
                Submitted.HrefValue = "";
                Submitted.TooltipValue = "";

                // Reviewed
                Reviewed.HrefValue = "";
                Reviewed.TooltipValue = "";

                // RegistrationForm
                RegistrationForm.HrefValue = "";
                RegistrationForm.TooltipValue = "";

                // PreScreeningInterview
                PreScreeningInterview.HrefValue = "";
                PreScreeningInterview.TooltipValue = "";

                // MinimumRecruitmentCheck
                MinimumRecruitmentCheck.HrefValue = "";
                MinimumRecruitmentCheck.TooltipValue = "";

                // EngagementChecklist
                EngagementChecklist.HrefValue = "";
                EngagementChecklist.TooltipValue = "";

                // COCAuthenticity
                COCAuthenticity.HrefValue = "";
                COCAuthenticity.TooltipValue = "";

                // CESTest
                CESTest.HrefValue = "";
                CESTest.TooltipValue = "";

                // PyschometricTest
                PyschometricTest.HrefValue = "";
                PyschometricTest.TooltipValue = "";

                // CrewWatchlist
                CrewWatchlist.HrefValue = "";
                CrewWatchlist.TooltipValue = "";

                // PreviousAppraisalReport
                PreviousAppraisalReport.HrefValue = "";
                PreviousAppraisalReport.TooltipValue = "";

                // ContractBackgroundCheck
                ContractBackgroundCheck.HrefValue = "";
                ContractBackgroundCheck.TooltipValue = "";

                // EnglishProficiencyTestOrMarline
                EnglishProficiencyTestOrMarline.HrefValue = "";
                EnglishProficiencyTestOrMarline.TooltipValue = "";

                // Interviewed
                Interviewed.HrefValue = "";
                Interviewed.TooltipValue = "";

                // Approved
                Approved.HrefValue = "";
                Approved.TooltipValue = "";

                // MedicalCheckup
                MedicalCheckup.HrefValue = "";
                MedicalCheckup.TooltipValue = "";

                // CreatedBy
                CreatedBy.HrefValue = "";
                CreatedBy.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";
            } else if (RowType == RowType.Search) {
                // IndividualCodeNumber
                if (IndividualCodeNumber.UseFilter && !Empty(IndividualCodeNumber.AdvancedSearch.SearchValue)) {
                    IndividualCodeNumber.EditValue = ConvertToString(IndividualCodeNumber.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // FullName
                if (FullName.UseFilter && !Empty(FullName.AdvancedSearch.SearchValue)) {
                    FullName.EditValue = ConvertToString(FullName.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // RequiredPhoto
                if (RequiredPhoto.UseFilter && !Empty(RequiredPhoto.AdvancedSearch.SearchValue)) {
                    RequiredPhoto.EditValue = ConvertToString(RequiredPhoto.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // VisaPhoto
                if (VisaPhoto.UseFilter && !Empty(VisaPhoto.AdvancedSearch.SearchValue)) {
                    VisaPhoto.EditValue = ConvertToString(VisaPhoto.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // Gender
                if (Gender.UseFilter && !Empty(Gender.AdvancedSearch.SearchValue)) {
                    Gender.EditValue = ConvertToString(Gender.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // RankAppliedFor
                if (RankAppliedFor.UseFilter && !Empty(RankAppliedFor.AdvancedSearch.SearchValue)) {
                    RankAppliedFor.EditValue = ConvertToString(RankAppliedFor.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // WillAcceptLowRank
                if (WillAcceptLowRank.UseFilter && !Empty(WillAcceptLowRank.AdvancedSearch.SearchValue)) {
                    WillAcceptLowRank.EditValue = ConvertToString(WillAcceptLowRank.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // EmployeeStatus
                if (EmployeeStatus.UseFilter && !Empty(EmployeeStatus.AdvancedSearch.SearchValue)) {
                    EmployeeStatus.EditValue = ConvertToString(EmployeeStatus.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // Draft
                Draft.SetupEditAttributes();
                Draft.EditValue = Draft.AdvancedSearch.SearchValue; // DN
                Draft.PlaceHolder = RemoveHtml(Draft.Caption);

                // Submitted
                Submitted.SetupEditAttributes();
                Submitted.EditValue = Submitted.AdvancedSearch.SearchValue; // DN
                Submitted.PlaceHolder = RemoveHtml(Submitted.Caption);

                // Reviewed
                Reviewed.SetupEditAttributes();
                Reviewed.EditValue = Reviewed.AdvancedSearch.SearchValue; // DN
                Reviewed.PlaceHolder = RemoveHtml(Reviewed.Caption);

                // RegistrationForm
                RegistrationForm.SetupEditAttributes();
                RegistrationForm.EditValue = RegistrationForm.AdvancedSearch.SearchValue; // DN
                RegistrationForm.PlaceHolder = RemoveHtml(RegistrationForm.Caption);

                // PreScreeningInterview
                PreScreeningInterview.SetupEditAttributes();
                PreScreeningInterview.EditValue = PreScreeningInterview.AdvancedSearch.SearchValue; // DN
                PreScreeningInterview.PlaceHolder = RemoveHtml(PreScreeningInterview.Caption);

                // MinimumRecruitmentCheck
                MinimumRecruitmentCheck.SetupEditAttributes();
                MinimumRecruitmentCheck.EditValue = MinimumRecruitmentCheck.AdvancedSearch.SearchValue; // DN
                MinimumRecruitmentCheck.PlaceHolder = RemoveHtml(MinimumRecruitmentCheck.Caption);

                // EngagementChecklist
                EngagementChecklist.SetupEditAttributes();
                EngagementChecklist.EditValue = EngagementChecklist.AdvancedSearch.SearchValue; // DN
                EngagementChecklist.PlaceHolder = RemoveHtml(EngagementChecklist.Caption);

                // COCAuthenticity
                COCAuthenticity.SetupEditAttributes();
                COCAuthenticity.EditValue = COCAuthenticity.AdvancedSearch.SearchValue; // DN
                COCAuthenticity.PlaceHolder = RemoveHtml(COCAuthenticity.Caption);

                // CESTest
                CESTest.SetupEditAttributes();
                CESTest.EditValue = CESTest.AdvancedSearch.SearchValue; // DN
                CESTest.PlaceHolder = RemoveHtml(CESTest.Caption);

                // PyschometricTest
                PyschometricTest.SetupEditAttributes();
                PyschometricTest.EditValue = PyschometricTest.AdvancedSearch.SearchValue; // DN
                PyschometricTest.PlaceHolder = RemoveHtml(PyschometricTest.Caption);

                // CrewWatchlist
                CrewWatchlist.SetupEditAttributes();
                CrewWatchlist.EditValue = CrewWatchlist.AdvancedSearch.SearchValue; // DN
                CrewWatchlist.PlaceHolder = RemoveHtml(CrewWatchlist.Caption);

                // PreviousAppraisalReport
                PreviousAppraisalReport.SetupEditAttributes();
                PreviousAppraisalReport.EditValue = PreviousAppraisalReport.AdvancedSearch.SearchValue; // DN
                PreviousAppraisalReport.PlaceHolder = RemoveHtml(PreviousAppraisalReport.Caption);

                // ContractBackgroundCheck
                ContractBackgroundCheck.SetupEditAttributes();
                ContractBackgroundCheck.EditValue = ContractBackgroundCheck.AdvancedSearch.SearchValue; // DN
                ContractBackgroundCheck.PlaceHolder = RemoveHtml(ContractBackgroundCheck.Caption);

                // EnglishProficiencyTestOrMarline
                EnglishProficiencyTestOrMarline.SetupEditAttributes();
                EnglishProficiencyTestOrMarline.EditValue = EnglishProficiencyTestOrMarline.AdvancedSearch.SearchValue; // DN
                EnglishProficiencyTestOrMarline.PlaceHolder = RemoveHtml(EnglishProficiencyTestOrMarline.Caption);

                // Interviewed
                Interviewed.SetupEditAttributes();
                Interviewed.EditValue = Interviewed.AdvancedSearch.SearchValue; // DN
                Interviewed.PlaceHolder = RemoveHtml(Interviewed.Caption);

                // Approved
                Approved.SetupEditAttributes();
                Approved.EditValue = Approved.AdvancedSearch.SearchValue; // DN
                Approved.PlaceHolder = RemoveHtml(Approved.Caption);

                // MedicalCheckup
                MedicalCheckup.SetupEditAttributes();
                MedicalCheckup.EditValue = MedicalCheckup.AdvancedSearch.SearchValue; // DN
                MedicalCheckup.PlaceHolder = RemoveHtml(MedicalCheckup.Caption);

                // CreatedBy
                CreatedBy.SetupEditAttributes();
                if (!CreatedBy.Raw)
                    CreatedBy.AdvancedSearch.SearchValue = HtmlDecode(CreatedBy.AdvancedSearch.SearchValue);
                CreatedBy.EditValue = HtmlEncode(CreatedBy.AdvancedSearch.SearchValue);
                CreatedBy.PlaceHolder = RemoveHtml(CreatedBy.Caption);

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                if (!LastUpdatedBy.Raw)
                    LastUpdatedBy.AdvancedSearch.SearchValue = HtmlDecode(LastUpdatedBy.AdvancedSearch.SearchValue);
                LastUpdatedBy.EditValue = HtmlEncode(LastUpdatedBy.AdvancedSearch.SearchValue);
                LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);
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

        // Load advanced search
        public void LoadAdvancedSearch()
        {
            IndividualCodeNumber.AdvancedSearch.Load();
            FullName.AdvancedSearch.Load();
            RequiredPhoto.AdvancedSearch.Load();
            VisaPhoto.AdvancedSearch.Load();
            Gender.AdvancedSearch.Load();
            RankAppliedFor.AdvancedSearch.Load();
            WillAcceptLowRank.AdvancedSearch.Load();
            EmployeeStatus.AdvancedSearch.Load();
            Draft.AdvancedSearch.Load();
            Submitted.AdvancedSearch.Load();
            Reviewed.AdvancedSearch.Load();
            RegistrationForm.AdvancedSearch.Load();
            PreScreeningInterview.AdvancedSearch.Load();
            MinimumRecruitmentCheck.AdvancedSearch.Load();
            EngagementChecklist.AdvancedSearch.Load();
            COCAuthenticity.AdvancedSearch.Load();
            CESTest.AdvancedSearch.Load();
            PyschometricTest.AdvancedSearch.Load();
            CrewWatchlist.AdvancedSearch.Load();
            PreviousAppraisalReport.AdvancedSearch.Load();
            ContractBackgroundCheck.AdvancedSearch.Load();
            EnglishProficiencyTestOrMarline.AdvancedSearch.Load();
            Interviewed.AdvancedSearch.Load();
            Approved.AdvancedSearch.Load();
            MedicalCheckup.AdvancedSearch.Load();
            CreatedBy.AdvancedSearch.Load();
            LastUpdatedBy.AdvancedSearch.Load();
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
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fv_CrewTrackingStatuslist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
            } else if (SameText(type, "word")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fv_CrewTrackingStatuslist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>";
            } else if (SameText(type, "pdf")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fv_CrewTrackingStatuslist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>";
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
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fv_CrewTrackingStatuslist\" data-ew-action=\"email\" data-custom=\"false\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
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
            item.Body = "<a class=\"btn btn-default ew-search-toggle" + searchToggleClass + "\" role=\"button\" title=\"" + Language.Phrase("SearchPanel") + "\" data-caption=\"" + Language.Phrase("SearchPanel") + "\" data-ew-action=\"search-toggle\" data-form=\"fv_CrewTrackingStatussrch\" aria-pressed=\"" + (searchToggleClass == " active" ? "true" : "false") + "\">" + Language.Phrase("SearchLink") + "</a>";
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
                item.Body = "<a class=\"btn btn-default ew-advanced-search\" title=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-table=\"v_CrewTrackingStatus\" data-caption=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-ew-action=\"modal\" data-url=\"" + AppPath("VCrewTrackingStatusSearch") + "\" data-btn=\"SearchBtn\">" + Language.Phrase("AdvancedSearch", false) + "</a>";
            else
                item.Body = "<a class=\"btn btn-default ew-advanced-search\" title=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-caption=\"" + Language.Phrase("AdvancedSearch", true) + "\" href=\"" + AppPath("VCrewTrackingStatusSearch") + "\">" + Language.Phrase("AdvancedSearch", false) + "</a>";
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
