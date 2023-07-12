namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mcuResultList
    /// </summary>
    public static McuResultList mcuResultList
    {
        get => HttpData.Get<McuResultList>("mcuResultList")!;
        set => HttpData["mcuResultList"] = value;
    }

    /// <summary>
    /// Page class for McuResult
    /// </summary>
    public class McuResultList : McuResultListBase
    {
        // Constructor
        public McuResultList(Controller controller) : base(controller)
        {
        }

        // Constructor
        public McuResultList() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class McuResultListBase : McuResult
    {
        // Page ID
        public string PageID = "list";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "McuResult";

        // Page object name
        public string PageObjName = "mcuResultList";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fMcuResultlist";

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
        public McuResultListBase()
        {
            // CSS class name as context
            TableVar = "McuResult";
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

            // Table object (mcuResult)
            if (mcuResult == null || mcuResult is McuResult)
                mcuResult = this;

            // Initialize URLs
            AddUrl = "McuResultAdd";
            InlineAddUrl = PageUrl + "action=add";
            GridAddUrl = PageUrl + "action=gridadd";
            GridEditUrl = PageUrl + "action=gridedit";
            MultiEditUrl = PageUrl + "action=multiedit";
            MultiDeleteUrl = "McuResultDelete";
            MultiUpdateUrl = "McuResultUpdate";

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
        public string PageName => "McuResultList";

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
            McuResult_ID.Visible = false;
            MTCrew_ID.Visible = false;
            IndividualCodeNumber.SetVisibility();
            FullName.SetVisibility();
            RequiredPhoto.SetVisibility();
            VisaPhoto.SetVisibility();
            Gender.SetVisibility();
            RankAppliedFor.SetVisibility();
            WillAcceptLowRank.SetVisibility();
            AvailableFrom.SetVisibility();
            AvailableUntil.SetVisibility();
            EmployeeStatus.SetVisibility();
            McuScheduleDate.SetVisibility();
            McuDate.SetVisibility();
            McuExpirationDate.SetVisibility();
            HealthStatus.SetVisibility();
            McuLocation.SetVisibility();
            McuAttachment.SetVisibility();
            McuRemark.SetVisibility();
            CreatedBy.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedBy.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            MTUserID.Visible = false;
        }

        // Constructor
        public McuResultListBase(Controller? controller = null): this() { // DN
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
            await SetupLookupOptions(Gender);
            await SetupLookupOptions(WillAcceptLowRank);

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fMcuResultgrid";

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
                mcuResultList?.PageRender();
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
            filters.Merge(JObject.Parse(IndividualCodeNumber.AdvancedSearch.ToJson())); // Field IndividualCodeNumber
            filters.Merge(JObject.Parse(FullName.AdvancedSearch.ToJson())); // Field FullName
            filters.Merge(JObject.Parse(Gender.AdvancedSearch.ToJson())); // Field Gender
            filters.Merge(JObject.Parse(RankAppliedFor.AdvancedSearch.ToJson())); // Field RankAppliedFor
            filters.Merge(JObject.Parse(WillAcceptLowRank.AdvancedSearch.ToJson())); // Field WillAcceptLowRank
            filters.Merge(JObject.Parse(AvailableFrom.AdvancedSearch.ToJson())); // Field AvailableFrom
            filters.Merge(JObject.Parse(AvailableUntil.AdvancedSearch.ToJson())); // Field AvailableUntil
            filters.Merge(JObject.Parse(McuScheduleDate.AdvancedSearch.ToJson())); // Field McuScheduleDate
            filters.Merge(JObject.Parse(McuDate.AdvancedSearch.ToJson())); // Field McuDate
            filters.Merge(JObject.Parse(McuExpirationDate.AdvancedSearch.ToJson())); // Field McuExpirationDate
            filters.Merge(JObject.Parse(HealthStatus.AdvancedSearch.ToJson())); // Field HealthStatus
            filters.Merge(JObject.Parse(McuLocation.AdvancedSearch.ToJson())); // Field McuLocation
            filters.Merge(JObject.Parse(McuRemark.AdvancedSearch.ToJson())); // Field McuRemark
            filters.Merge(JObject.Parse(CreatedBy.AdvancedSearch.ToJson())); // Field CreatedBy
            filters.Merge(JObject.Parse(CreatedDateTime.AdvancedSearch.ToJson())); // Field CreatedDateTime
            filters.Merge(JObject.Parse(LastUpdatedBy.AdvancedSearch.ToJson())); // Field LastUpdatedBy
            filters.Merge(JObject.Parse(LastUpdatedDateTime.AdvancedSearch.ToJson())); // Field LastUpdatedDateTime
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

            // Field AvailableFrom
            if (filter?.TryGetValue("x_AvailableFrom", out sv) ?? false) {
                AvailableFrom.AdvancedSearch.SearchValue = sv;
                AvailableFrom.AdvancedSearch.SearchOperator = filter["z_AvailableFrom"];
                AvailableFrom.AdvancedSearch.SearchCondition = filter["v_AvailableFrom"];
                AvailableFrom.AdvancedSearch.SearchValue2 = filter["y_AvailableFrom"];
                AvailableFrom.AdvancedSearch.SearchOperator2 = filter["w_AvailableFrom"];
                AvailableFrom.AdvancedSearch.Save();
            }

            // Field AvailableUntil
            if (filter?.TryGetValue("x_AvailableUntil", out sv) ?? false) {
                AvailableUntil.AdvancedSearch.SearchValue = sv;
                AvailableUntil.AdvancedSearch.SearchOperator = filter["z_AvailableUntil"];
                AvailableUntil.AdvancedSearch.SearchCondition = filter["v_AvailableUntil"];
                AvailableUntil.AdvancedSearch.SearchValue2 = filter["y_AvailableUntil"];
                AvailableUntil.AdvancedSearch.SearchOperator2 = filter["w_AvailableUntil"];
                AvailableUntil.AdvancedSearch.Save();
            }

            // Field McuScheduleDate
            if (filter?.TryGetValue("x_McuScheduleDate", out sv) ?? false) {
                McuScheduleDate.AdvancedSearch.SearchValue = sv;
                McuScheduleDate.AdvancedSearch.SearchOperator = filter["z_McuScheduleDate"];
                McuScheduleDate.AdvancedSearch.SearchCondition = filter["v_McuScheduleDate"];
                McuScheduleDate.AdvancedSearch.SearchValue2 = filter["y_McuScheduleDate"];
                McuScheduleDate.AdvancedSearch.SearchOperator2 = filter["w_McuScheduleDate"];
                McuScheduleDate.AdvancedSearch.Save();
            }

            // Field McuDate
            if (filter?.TryGetValue("x_McuDate", out sv) ?? false) {
                McuDate.AdvancedSearch.SearchValue = sv;
                McuDate.AdvancedSearch.SearchOperator = filter["z_McuDate"];
                McuDate.AdvancedSearch.SearchCondition = filter["v_McuDate"];
                McuDate.AdvancedSearch.SearchValue2 = filter["y_McuDate"];
                McuDate.AdvancedSearch.SearchOperator2 = filter["w_McuDate"];
                McuDate.AdvancedSearch.Save();
            }

            // Field McuExpirationDate
            if (filter?.TryGetValue("x_McuExpirationDate", out sv) ?? false) {
                McuExpirationDate.AdvancedSearch.SearchValue = sv;
                McuExpirationDate.AdvancedSearch.SearchOperator = filter["z_McuExpirationDate"];
                McuExpirationDate.AdvancedSearch.SearchCondition = filter["v_McuExpirationDate"];
                McuExpirationDate.AdvancedSearch.SearchValue2 = filter["y_McuExpirationDate"];
                McuExpirationDate.AdvancedSearch.SearchOperator2 = filter["w_McuExpirationDate"];
                McuExpirationDate.AdvancedSearch.Save();
            }

            // Field HealthStatus
            if (filter?.TryGetValue("x_HealthStatus", out sv) ?? false) {
                HealthStatus.AdvancedSearch.SearchValue = sv;
                HealthStatus.AdvancedSearch.SearchOperator = filter["z_HealthStatus"];
                HealthStatus.AdvancedSearch.SearchCondition = filter["v_HealthStatus"];
                HealthStatus.AdvancedSearch.SearchValue2 = filter["y_HealthStatus"];
                HealthStatus.AdvancedSearch.SearchOperator2 = filter["w_HealthStatus"];
                HealthStatus.AdvancedSearch.Save();
            }

            // Field McuLocation
            if (filter?.TryGetValue("x_McuLocation", out sv) ?? false) {
                McuLocation.AdvancedSearch.SearchValue = sv;
                McuLocation.AdvancedSearch.SearchOperator = filter["z_McuLocation"];
                McuLocation.AdvancedSearch.SearchCondition = filter["v_McuLocation"];
                McuLocation.AdvancedSearch.SearchValue2 = filter["y_McuLocation"];
                McuLocation.AdvancedSearch.SearchOperator2 = filter["w_McuLocation"];
                McuLocation.AdvancedSearch.Save();
            }

            // Field McuRemark
            if (filter?.TryGetValue("x_McuRemark", out sv) ?? false) {
                McuRemark.AdvancedSearch.SearchValue = sv;
                McuRemark.AdvancedSearch.SearchOperator = filter["z_McuRemark"];
                McuRemark.AdvancedSearch.SearchCondition = filter["v_McuRemark"];
                McuRemark.AdvancedSearch.SearchValue2 = filter["y_McuRemark"];
                McuRemark.AdvancedSearch.SearchOperator2 = filter["w_McuRemark"];
                McuRemark.AdvancedSearch.Save();
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

            // Field CreatedDateTime
            if (filter?.TryGetValue("x_CreatedDateTime", out sv) ?? false) {
                CreatedDateTime.AdvancedSearch.SearchValue = sv;
                CreatedDateTime.AdvancedSearch.SearchOperator = filter["z_CreatedDateTime"];
                CreatedDateTime.AdvancedSearch.SearchCondition = filter["v_CreatedDateTime"];
                CreatedDateTime.AdvancedSearch.SearchValue2 = filter["y_CreatedDateTime"];
                CreatedDateTime.AdvancedSearch.SearchOperator2 = filter["w_CreatedDateTime"];
                CreatedDateTime.AdvancedSearch.Save();
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

            // Field LastUpdatedDateTime
            if (filter?.TryGetValue("x_LastUpdatedDateTime", out sv) ?? false) {
                LastUpdatedDateTime.AdvancedSearch.SearchValue = sv;
                LastUpdatedDateTime.AdvancedSearch.SearchOperator = filter["z_LastUpdatedDateTime"];
                LastUpdatedDateTime.AdvancedSearch.SearchCondition = filter["v_LastUpdatedDateTime"];
                LastUpdatedDateTime.AdvancedSearch.SearchValue2 = filter["y_LastUpdatedDateTime"];
                LastUpdatedDateTime.AdvancedSearch.SearchOperator2 = filter["w_LastUpdatedDateTime"];
                LastUpdatedDateTime.AdvancedSearch.Save();
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
            BuildSearchSql(ref where, Gender, def, false); // Gender
            BuildSearchSql(ref where, RankAppliedFor, def, true); // RankAppliedFor
            BuildSearchSql(ref where, WillAcceptLowRank, def, true); // WillAcceptLowRank
            BuildSearchSql(ref where, AvailableFrom, def, true); // AvailableFrom
            BuildSearchSql(ref where, AvailableUntil, def, true); // AvailableUntil
            BuildSearchSql(ref where, EmployeeStatus, def, true); // EmployeeStatus
            BuildSearchSql(ref where, McuScheduleDate, def, true); // McuScheduleDate
            BuildSearchSql(ref where, McuDate, def, true); // McuDate
            BuildSearchSql(ref where, McuExpirationDate, def, true); // McuExpirationDate
            BuildSearchSql(ref where, HealthStatus, def, true); // HealthStatus
            BuildSearchSql(ref where, McuLocation, def, true); // McuLocation
            BuildSearchSql(ref where, McuAttachment, def, true); // McuAttachment
            BuildSearchSql(ref where, McuRemark, def, false); // McuRemark
            BuildSearchSql(ref where, CreatedBy, def, true); // CreatedBy
            BuildSearchSql(ref where, CreatedDateTime, def, true); // CreatedDateTime
            BuildSearchSql(ref where, LastUpdatedBy, def, true); // LastUpdatedBy
            BuildSearchSql(ref where, LastUpdatedDateTime, def, true); // LastUpdatedDateTime

            // Set up search command
            if (!def && !Empty(where) && (new[] { "", "reset", "resetall" }).Contains(Command))
                Command = "search";
            if (!def && Command == "search") {
                IndividualCodeNumber.AdvancedSearch.Save(); // IndividualCodeNumber
                FullName.AdvancedSearch.Save(); // FullName
                Gender.AdvancedSearch.Save(); // Gender
                RankAppliedFor.AdvancedSearch.Save(); // RankAppliedFor
                WillAcceptLowRank.AdvancedSearch.Save(); // WillAcceptLowRank
                AvailableFrom.AdvancedSearch.Save(); // AvailableFrom
                AvailableUntil.AdvancedSearch.Save(); // AvailableUntil
                McuScheduleDate.AdvancedSearch.Save(); // McuScheduleDate
                McuDate.AdvancedSearch.Save(); // McuDate
                McuExpirationDate.AdvancedSearch.Save(); // McuExpirationDate
                HealthStatus.AdvancedSearch.Save(); // HealthStatus
                McuLocation.AdvancedSearch.Save(); // McuLocation
                McuRemark.AdvancedSearch.Save(); // McuRemark
                CreatedBy.AdvancedSearch.Save(); // CreatedBy
                CreatedDateTime.AdvancedSearch.Save(); // CreatedDateTime
                LastUpdatedBy.AdvancedSearch.Save(); // LastUpdatedBy
                LastUpdatedDateTime.AdvancedSearch.Save(); // LastUpdatedDateTime

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
                BuildSearchSql(ref filter, Gender, false, false);
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

            // Field AvailableFrom
            filter = QueryBuilderWhere("AvailableFrom");
            if (Empty(filter))
                BuildSearchSql(ref filter, AvailableFrom, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + AvailableFrom.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field AvailableUntil
            filter = QueryBuilderWhere("AvailableUntil");
            if (Empty(filter))
                BuildSearchSql(ref filter, AvailableUntil, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + AvailableUntil.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field EmployeeStatus
            filter = QueryBuilderWhere("EmployeeStatus");
            if (Empty(filter))
                BuildSearchSql(ref filter, EmployeeStatus, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + EmployeeStatus.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field McuScheduleDate
            filter = QueryBuilderWhere("McuScheduleDate");
            if (Empty(filter))
                BuildSearchSql(ref filter, McuScheduleDate, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + McuScheduleDate.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field McuDate
            filter = QueryBuilderWhere("McuDate");
            if (Empty(filter))
                BuildSearchSql(ref filter, McuDate, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + McuDate.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field McuExpirationDate
            filter = QueryBuilderWhere("McuExpirationDate");
            if (Empty(filter))
                BuildSearchSql(ref filter, McuExpirationDate, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + McuExpirationDate.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field HealthStatus
            filter = QueryBuilderWhere("HealthStatus");
            if (Empty(filter))
                BuildSearchSql(ref filter, HealthStatus, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + HealthStatus.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field McuLocation
            filter = QueryBuilderWhere("McuLocation");
            if (Empty(filter))
                BuildSearchSql(ref filter, McuLocation, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + McuLocation.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field McuAttachment
            filter = QueryBuilderWhere("McuAttachment");
            if (Empty(filter))
                BuildSearchSql(ref filter, McuAttachment, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + McuAttachment.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field McuRemark
            filter = QueryBuilderWhere("McuRemark");
            if (Empty(filter))
                BuildSearchSql(ref filter, McuRemark, false, false);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + McuRemark.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CreatedBy
            filter = QueryBuilderWhere("CreatedBy");
            if (Empty(filter))
                BuildSearchSql(ref filter, CreatedBy, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CreatedBy.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CreatedDateTime
            filter = QueryBuilderWhere("CreatedDateTime");
            if (Empty(filter))
                BuildSearchSql(ref filter, CreatedDateTime, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CreatedDateTime.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LastUpdatedBy
            filter = QueryBuilderWhere("LastUpdatedBy");
            if (Empty(filter))
                BuildSearchSql(ref filter, LastUpdatedBy, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LastUpdatedBy.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field LastUpdatedDateTime
            filter = QueryBuilderWhere("LastUpdatedDateTime");
            if (Empty(filter))
                BuildSearchSql(ref filter, LastUpdatedDateTime, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + LastUpdatedDateTime.Caption + "</span>" + captionSuffix + filter + "</div>";
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
            searchFlds.Add(Gender);
            searchFlds.Add(RankAppliedFor);
            searchFlds.Add(HealthStatus);
            searchFlds.Add(McuLocation);
            searchFlds.Add(McuRemark);
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
            if (AvailableFrom.AdvancedSearch.IssetSession)
                return true;
            if (AvailableUntil.AdvancedSearch.IssetSession)
                return true;
            if (EmployeeStatus.AdvancedSearch.IssetSession)
                return true;
            if (McuScheduleDate.AdvancedSearch.IssetSession)
                return true;
            if (McuDate.AdvancedSearch.IssetSession)
                return true;
            if (McuExpirationDate.AdvancedSearch.IssetSession)
                return true;
            if (HealthStatus.AdvancedSearch.IssetSession)
                return true;
            if (McuLocation.AdvancedSearch.IssetSession)
                return true;
            if (McuAttachment.AdvancedSearch.IssetSession)
                return true;
            if (McuRemark.AdvancedSearch.IssetSession)
                return true;
            if (CreatedBy.AdvancedSearch.IssetSession)
                return true;
            if (CreatedDateTime.AdvancedSearch.IssetSession)
                return true;
            if (LastUpdatedBy.AdvancedSearch.IssetSession)
                return true;
            if (LastUpdatedDateTime.AdvancedSearch.IssetSession)
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
            AvailableFrom.AdvancedSearch.UnsetSession();
            AvailableUntil.AdvancedSearch.UnsetSession();
            EmployeeStatus.AdvancedSearch.UnsetSession();
            McuScheduleDate.AdvancedSearch.UnsetSession();
            McuDate.AdvancedSearch.UnsetSession();
            McuExpirationDate.AdvancedSearch.UnsetSession();
            HealthStatus.AdvancedSearch.UnsetSession();
            McuLocation.AdvancedSearch.UnsetSession();
            McuAttachment.AdvancedSearch.UnsetSession();
            McuRemark.AdvancedSearch.UnsetSession();
            CreatedBy.AdvancedSearch.UnsetSession();
            CreatedDateTime.AdvancedSearch.UnsetSession();
            LastUpdatedBy.AdvancedSearch.UnsetSession();
            LastUpdatedDateTime.AdvancedSearch.UnsetSession();
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
            AvailableFrom.AdvancedSearch.Load();
            AvailableUntil.AdvancedSearch.Load();
            EmployeeStatus.AdvancedSearch.Load();
            McuScheduleDate.AdvancedSearch.Load();
            McuDate.AdvancedSearch.Load();
            McuExpirationDate.AdvancedSearch.Load();
            HealthStatus.AdvancedSearch.Load();
            McuLocation.AdvancedSearch.Load();
            McuAttachment.AdvancedSearch.Load();
            McuRemark.AdvancedSearch.Load();
            CreatedBy.AdvancedSearch.Load();
            CreatedDateTime.AdvancedSearch.Load();
            LastUpdatedBy.AdvancedSearch.Load();
            LastUpdatedDateTime.AdvancedSearch.Load();
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
                UpdateSort(AvailableFrom, ctrl); // AvailableFrom
                UpdateSort(AvailableUntil, ctrl); // AvailableUntil
                UpdateSort(EmployeeStatus, ctrl); // EmployeeStatus
                UpdateSort(McuScheduleDate, ctrl); // McuScheduleDate
                UpdateSort(McuDate, ctrl); // McuDate
                UpdateSort(McuExpirationDate, ctrl); // McuExpirationDate
                UpdateSort(HealthStatus, ctrl); // HealthStatus
                UpdateSort(McuLocation, ctrl); // McuLocation
                UpdateSort(McuAttachment, ctrl); // McuAttachment
                UpdateSort(McuRemark, ctrl); // McuRemark
                UpdateSort(CreatedBy, ctrl); // CreatedBy
                UpdateSort(CreatedDateTime, ctrl); // CreatedDateTime
                UpdateSort(LastUpdatedBy, ctrl); // LastUpdatedBy
                UpdateSort(LastUpdatedDateTime, ctrl); // LastUpdatedDateTime
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
                    McuResult_ID.Sort = "";
                    MTCrew_ID.Sort = "";
                    IndividualCodeNumber.Sort = "";
                    FullName.Sort = "";
                    RequiredPhoto.Sort = "";
                    VisaPhoto.Sort = "";
                    Gender.Sort = "";
                    RankAppliedFor.Sort = "";
                    WillAcceptLowRank.Sort = "";
                    AvailableFrom.Sort = "";
                    AvailableUntil.Sort = "";
                    EmployeeStatus.Sort = "";
                    McuScheduleDate.Sort = "";
                    McuDate.Sort = "";
                    McuExpirationDate.Sort = "";
                    HealthStatus.Sort = "";
                    McuLocation.Sort = "";
                    McuAttachment.Sort = "";
                    McuRemark.Sort = "";
                    CreatedBy.Sort = "";
                    CreatedDateTime.Sort = "";
                    LastUpdatedBy.Sort = "";
                    LastUpdatedDateTime.Sort = "";
                    MTUserID.Sort = "";
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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-view"" title=""{viewcaption}"" data-table=""McuResult"" data-caption=""{viewcaption}"" data-ew-action=""modal"" data-action=""view"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(ViewUrl)) + "\" data-btn=\"null\">" + Language.Phrase("ViewLink") + "</a>");
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
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-table=""McuResult"" data-caption=""{editcaption}"" data-ew-action=""modal"" data-action=""edit"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\" data-btn=\"SaveBtn\">" + Language.Phrase("EditLink") + "</a>");
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
                        string link = "<li><button type=\"button\" class=\"dropdown-item ew-action ew-list-action\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fMcuResultlist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttrs() + ">" + icon + " " + caption + "</button></li>";
                        if (!Empty(link)) {
                            links.Add(link);
                            if (Empty(body)) // Setup first button
                                body = "<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlTitle(caption) + "\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fMcuResultlist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttrs() + ">" + icon + caption + "</button>";
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
            listOption?.SetBody("<div class=\"form-check\"><input type=\"checkbox\" id=\"key_m_" + RowCount + "\" name=\"key_m[]\" class=\"form-check-input ew-multi-select\" value=\"" + HtmlEncode(McuResult_ID.CurrentValue) + "\" data-ew-action=\"select-key\"></div>");
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
                CreateColumnOption(option.Add("AvailableFrom")); // DN
                CreateColumnOption(option.Add("AvailableUntil")); // DN
                CreateColumnOption(option.Add("EmployeeStatus")); // DN
                CreateColumnOption(option.Add("McuScheduleDate")); // DN
                CreateColumnOption(option.Add("McuDate")); // DN
                CreateColumnOption(option.Add("McuExpirationDate")); // DN
                CreateColumnOption(option.Add("HealthStatus")); // DN
                CreateColumnOption(option.Add("McuLocation")); // DN
                CreateColumnOption(option.Add("McuAttachment")); // DN
                CreateColumnOption(option.Add("McuRemark")); // DN
                CreateColumnOption(option.Add("CreatedBy")); // DN
                CreateColumnOption(option.Add("CreatedDateTime")); // DN
                CreateColumnOption(option.Add("LastUpdatedBy")); // DN
                CreateColumnOption(option.Add("LastUpdatedDateTime")); // DN
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
            item.Body = "<a class=\"ew-save-filter\" data-form=\"fMcuResultsrch\" data-ew-action=\"none\">" + Language.Phrase("SaveCurrentFilter") + "</a>";
            item.Visible = true;
            item = FilterOptions.Add("deletefilter");
            item.Body = "<a class=\"ew-delete-filter\" data-form=\"fMcuResultsrch\" data-ew-action=\"none\">" + Language.Phrase("DeleteFilter") + "</a>";
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
                    item.Body = "<<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlEncode(caption) + "\" data-caption=\"" + HtmlEncode(caption) + "\" data-ew-action=\"submit\" form=\"fMcuResultlist\"" + act.ToDataAttrs() + ">" + icon + "</button>";
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
                    RowAttrs.Add("id", "r0_McuResult");
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
            RowAttrs.Add("data-rowindex", ConvertToString(mcuResultList.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(mcuResultList.RowCount) + "_McuResult");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(mcuResultList.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && mcuResultList.RowType == RowType.Add || IsEdit && mcuResultList.RowType == RowType.Edit) // Inline-Add/Edit row
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
                if (Query.ContainsKey("x_Gender"))
                    Gender.AdvancedSearch.SearchValue = Get("x_Gender");
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

            // AvailableFrom
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AvailableFrom[]"))
                    AvailableFrom.AdvancedSearch.SearchValue = Get("x_AvailableFrom[]");
                else
                    AvailableFrom.AdvancedSearch.SearchValue = Get("AvailableFrom"); // Default Value // DN
            if (!Empty(AvailableFrom.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AvailableFrom"))
                AvailableFrom.AdvancedSearch.SearchOperator = Get("z_AvailableFrom");

            // AvailableUntil
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AvailableUntil[]"))
                    AvailableUntil.AdvancedSearch.SearchValue = Get("x_AvailableUntil[]");
                else
                    AvailableUntil.AdvancedSearch.SearchValue = Get("AvailableUntil"); // Default Value // DN
            if (!Empty(AvailableUntil.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AvailableUntil"))
                AvailableUntil.AdvancedSearch.SearchOperator = Get("z_AvailableUntil");

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

            // McuScheduleDate
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_McuScheduleDate[]"))
                    McuScheduleDate.AdvancedSearch.SearchValue = Get("x_McuScheduleDate[]");
                else
                    McuScheduleDate.AdvancedSearch.SearchValue = Get("McuScheduleDate"); // Default Value // DN
            if (!Empty(McuScheduleDate.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_McuScheduleDate"))
                McuScheduleDate.AdvancedSearch.SearchOperator = Get("z_McuScheduleDate");

            // McuDate
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_McuDate[]"))
                    McuDate.AdvancedSearch.SearchValue = Get("x_McuDate[]");
                else
                    McuDate.AdvancedSearch.SearchValue = Get("McuDate"); // Default Value // DN
            if (!Empty(McuDate.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_McuDate"))
                McuDate.AdvancedSearch.SearchOperator = Get("z_McuDate");

            // McuExpirationDate
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_McuExpirationDate[]"))
                    McuExpirationDate.AdvancedSearch.SearchValue = Get("x_McuExpirationDate[]");
                else
                    McuExpirationDate.AdvancedSearch.SearchValue = Get("McuExpirationDate"); // Default Value // DN
            if (!Empty(McuExpirationDate.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_McuExpirationDate"))
                McuExpirationDate.AdvancedSearch.SearchOperator = Get("z_McuExpirationDate");

            // HealthStatus
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_HealthStatus[]"))
                    HealthStatus.AdvancedSearch.SearchValue = Get("x_HealthStatus[]");
                else
                    HealthStatus.AdvancedSearch.SearchValue = Get("HealthStatus"); // Default Value // DN
            if (!Empty(HealthStatus.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_HealthStatus"))
                HealthStatus.AdvancedSearch.SearchOperator = Get("z_HealthStatus");

            // McuLocation
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_McuLocation[]"))
                    McuLocation.AdvancedSearch.SearchValue = Get("x_McuLocation[]");
                else
                    McuLocation.AdvancedSearch.SearchValue = Get("McuLocation"); // Default Value // DN
            if (!Empty(McuLocation.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_McuLocation"))
                McuLocation.AdvancedSearch.SearchOperator = Get("z_McuLocation");

            // McuAttachment
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_McuAttachment[]"))
                    McuAttachment.AdvancedSearch.SearchValue = Get("x_McuAttachment[]");
                else
                    McuAttachment.AdvancedSearch.SearchValue = Get("McuAttachment"); // Default Value // DN
            if (!Empty(McuAttachment.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_McuAttachment"))
                McuAttachment.AdvancedSearch.SearchOperator = Get("z_McuAttachment");

            // McuRemark
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_McuRemark"))
                    McuRemark.AdvancedSearch.SearchValue = Get("x_McuRemark");
                else
                    McuRemark.AdvancedSearch.SearchValue = Get("McuRemark"); // Default Value // DN
            if (!Empty(McuRemark.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_McuRemark"))
                McuRemark.AdvancedSearch.SearchOperator = Get("z_McuRemark");

            // CreatedBy
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CreatedBy[]"))
                    CreatedBy.AdvancedSearch.SearchValue = Get("x_CreatedBy[]");
                else
                    CreatedBy.AdvancedSearch.SearchValue = Get("CreatedBy"); // Default Value // DN
            if (!Empty(CreatedBy.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CreatedBy"))
                CreatedBy.AdvancedSearch.SearchOperator = Get("z_CreatedBy");

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

            // LastUpdatedBy
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_LastUpdatedBy[]"))
                    LastUpdatedBy.AdvancedSearch.SearchValue = Get("x_LastUpdatedBy[]");
                else
                    LastUpdatedBy.AdvancedSearch.SearchValue = Get("LastUpdatedBy"); // Default Value // DN
            if (!Empty(LastUpdatedBy.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_LastUpdatedBy"))
                LastUpdatedBy.AdvancedSearch.SearchOperator = Get("z_LastUpdatedBy");

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
            McuResult_ID.CellCssStyle = "white-space: nowrap;";

            // MTCrew_ID
            MTCrew_ID.CellCssStyle = "white-space: nowrap;";

            // IndividualCodeNumber
            IndividualCodeNumber.CellCssStyle = "white-space: nowrap;";

            // FullName
            FullName.CellCssStyle = "white-space: nowrap;";

            // RequiredPhoto
            RequiredPhoto.CellCssStyle = "white-space: nowrap;";

            // VisaPhoto
            VisaPhoto.CellCssStyle = "white-space: nowrap;";

            // Gender

            // RankAppliedFor
            RankAppliedFor.CellCssStyle = "white-space: nowrap;";

            // WillAcceptLowRank
            WillAcceptLowRank.CellCssStyle = "white-space: nowrap;";

            // AvailableFrom
            AvailableFrom.CellCssStyle = "white-space: nowrap;";

            // AvailableUntil
            AvailableUntil.CellCssStyle = "white-space: nowrap;";

            // EmployeeStatus
            EmployeeStatus.CellCssStyle = "white-space: nowrap;";

            // McuScheduleDate
            McuScheduleDate.CellCssStyle = "white-space: nowrap;";

            // McuDate
            McuDate.CellCssStyle = "white-space: nowrap;";

            // McuExpirationDate
            McuExpirationDate.CellCssStyle = "white-space: nowrap;";

            // HealthStatus
            HealthStatus.CellCssStyle = "white-space: nowrap;";

            // McuLocation
            McuLocation.CellCssStyle = "white-space: nowrap;";

            // McuAttachment
            McuAttachment.CellCssStyle = "white-space: nowrap;";

            // McuRemark
            McuRemark.CellCssStyle = "white-space: nowrap;";

            // CreatedBy
            CreatedBy.CellCssStyle = "white-space: nowrap;";

            // CreatedDateTime
            CreatedDateTime.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedBy
            LastUpdatedBy.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedDateTime
            LastUpdatedDateTime.CellCssStyle = "white-space: nowrap;";

            // MTUserID
            MTUserID.CellCssStyle = "white-space: nowrap;";

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

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";
                IndividualCodeNumber.TooltipValue = "";

                // FullName
                FullName.HrefValue = "";
                FullName.TooltipValue = "";

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
                RequiredPhoto.TooltipValue = "";

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

                // AvailableFrom
                AvailableFrom.HrefValue = "";
                AvailableFrom.TooltipValue = "";

                // AvailableUntil
                AvailableUntil.HrefValue = "";
                AvailableUntil.TooltipValue = "";

                // EmployeeStatus
                EmployeeStatus.HrefValue = "";
                EmployeeStatus.TooltipValue = "";

                // McuScheduleDate
                McuScheduleDate.HrefValue = "";
                McuScheduleDate.TooltipValue = "";

                // McuDate
                McuDate.HrefValue = "";
                McuDate.TooltipValue = "";

                // McuExpirationDate
                McuExpirationDate.HrefValue = "";
                McuExpirationDate.TooltipValue = "";

                // HealthStatus
                HealthStatus.HrefValue = "";
                HealthStatus.TooltipValue = "";

                // McuLocation
                McuLocation.HrefValue = "";
                McuLocation.TooltipValue = "";

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
                McuAttachment.TooltipValue = "";

                // McuRemark
                McuRemark.HrefValue = "";
                McuRemark.TooltipValue = "";

                // CreatedBy
                CreatedBy.HrefValue = "";
                CreatedBy.TooltipValue = "";

                // CreatedDateTime
                CreatedDateTime.HrefValue = "";
                CreatedDateTime.TooltipValue = "";

                // LastUpdatedBy
                LastUpdatedBy.HrefValue = "";
                LastUpdatedBy.TooltipValue = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.HrefValue = "";
                LastUpdatedDateTime.TooltipValue = "";
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
                Gender.SetupEditAttributes();
                if (!Gender.Raw)
                    Gender.AdvancedSearch.SearchValue = HtmlDecode(Gender.AdvancedSearch.SearchValue);
                Gender.EditValue = HtmlEncode(Gender.AdvancedSearch.SearchValue);
                Gender.PlaceHolder = RemoveHtml(Gender.Caption);

                // RankAppliedFor
                if (RankAppliedFor.UseFilter && !Empty(RankAppliedFor.AdvancedSearch.SearchValue)) {
                    RankAppliedFor.EditValue = ConvertToString(RankAppliedFor.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // WillAcceptLowRank
                if (WillAcceptLowRank.UseFilter && !Empty(WillAcceptLowRank.AdvancedSearch.SearchValue)) {
                    WillAcceptLowRank.EditValue = ConvertToString(WillAcceptLowRank.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // AvailableFrom
                if (AvailableFrom.UseFilter && !Empty(AvailableFrom.AdvancedSearch.SearchValue)) {
                    AvailableFrom.EditValue = ConvertToString(AvailableFrom.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // AvailableUntil
                if (AvailableUntil.UseFilter && !Empty(AvailableUntil.AdvancedSearch.SearchValue)) {
                    AvailableUntil.EditValue = ConvertToString(AvailableUntil.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // EmployeeStatus
                if (EmployeeStatus.UseFilter && !Empty(EmployeeStatus.AdvancedSearch.SearchValue)) {
                    EmployeeStatus.EditValue = ConvertToString(EmployeeStatus.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // McuScheduleDate
                if (McuScheduleDate.UseFilter && !Empty(McuScheduleDate.AdvancedSearch.SearchValue)) {
                    McuScheduleDate.EditValue = ConvertToString(McuScheduleDate.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // McuDate
                if (McuDate.UseFilter && !Empty(McuDate.AdvancedSearch.SearchValue)) {
                    McuDate.EditValue = ConvertToString(McuDate.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // McuExpirationDate
                if (McuExpirationDate.UseFilter && !Empty(McuExpirationDate.AdvancedSearch.SearchValue)) {
                    McuExpirationDate.EditValue = ConvertToString(McuExpirationDate.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // HealthStatus
                if (HealthStatus.UseFilter && !Empty(HealthStatus.AdvancedSearch.SearchValue)) {
                    HealthStatus.EditValue = ConvertToString(HealthStatus.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // McuLocation
                if (McuLocation.UseFilter && !Empty(McuLocation.AdvancedSearch.SearchValue)) {
                    McuLocation.EditValue = ConvertToString(McuLocation.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // McuAttachment
                if (McuAttachment.UseFilter && !Empty(McuAttachment.AdvancedSearch.SearchValue)) {
                    McuAttachment.EditValue = ConvertToString(McuAttachment.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // McuRemark
                McuRemark.SetupEditAttributes();
                if (!McuRemark.Raw)
                    McuRemark.AdvancedSearch.SearchValue = HtmlDecode(McuRemark.AdvancedSearch.SearchValue);
                McuRemark.EditValue = HtmlEncode(McuRemark.AdvancedSearch.SearchValue);
                McuRemark.PlaceHolder = RemoveHtml(McuRemark.Caption);

                // CreatedBy
                if (CreatedBy.UseFilter && !Empty(CreatedBy.AdvancedSearch.SearchValue)) {
                    CreatedBy.EditValue = ConvertToString(CreatedBy.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // CreatedDateTime
                if (CreatedDateTime.UseFilter && !Empty(CreatedDateTime.AdvancedSearch.SearchValue)) {
                    CreatedDateTime.EditValue = ConvertToString(CreatedDateTime.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // LastUpdatedBy
                if (LastUpdatedBy.UseFilter && !Empty(LastUpdatedBy.AdvancedSearch.SearchValue)) {
                    LastUpdatedBy.EditValue = ConvertToString(LastUpdatedBy.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // LastUpdatedDateTime
                if (LastUpdatedDateTime.UseFilter && !Empty(LastUpdatedDateTime.AdvancedSearch.SearchValue)) {
                    LastUpdatedDateTime.EditValue = ConvertToString(LastUpdatedDateTime.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }
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
            IndividualCodeNumber.AdvancedSearch.Load();
            FullName.AdvancedSearch.Load();
            Gender.AdvancedSearch.Load();
            RankAppliedFor.AdvancedSearch.Load();
            WillAcceptLowRank.AdvancedSearch.Load();
            AvailableFrom.AdvancedSearch.Load();
            AvailableUntil.AdvancedSearch.Load();
            McuScheduleDate.AdvancedSearch.Load();
            McuDate.AdvancedSearch.Load();
            McuExpirationDate.AdvancedSearch.Load();
            HealthStatus.AdvancedSearch.Load();
            McuLocation.AdvancedSearch.Load();
            McuRemark.AdvancedSearch.Load();
            CreatedBy.AdvancedSearch.Load();
            CreatedDateTime.AdvancedSearch.Load();
            LastUpdatedBy.AdvancedSearch.Load();
            LastUpdatedDateTime.AdvancedSearch.Load();
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
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fMcuResultlist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
            } else if (SameText(type, "word")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fMcuResultlist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>";
            } else if (SameText(type, "pdf")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fMcuResultlist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>";
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
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fMcuResultlist\" data-ew-action=\"email\" data-custom=\"false\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
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
            item.Body = "<a class=\"btn btn-default ew-search-toggle" + searchToggleClass + "\" role=\"button\" title=\"" + Language.Phrase("SearchPanel") + "\" data-caption=\"" + Language.Phrase("SearchPanel") + "\" data-ew-action=\"search-toggle\" data-form=\"fMcuResultsrch\" aria-pressed=\"" + (searchToggleClass == " active" ? "true" : "false") + "\">" + Language.Phrase("SearchLink") + "</a>";
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
                item.Body = "<a class=\"btn btn-default ew-advanced-search\" title=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-table=\"McuResult\" data-caption=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-ew-action=\"modal\" data-url=\"" + AppPath("McuResultSearch") + "\" data-btn=\"SearchBtn\">" + Language.Phrase("AdvancedSearch", false) + "</a>";
            else
                item.Body = "<a class=\"btn btn-default ew-advanced-search\" title=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-caption=\"" + Language.Phrase("AdvancedSearch", true) + "\" href=\"" + AppPath("McuResultSearch") + "\">" + Language.Phrase("AdvancedSearch", false) + "</a>";
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
