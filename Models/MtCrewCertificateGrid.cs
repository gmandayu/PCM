namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mtCrewCertificateGrid
    /// </summary>
    public static MtCrewCertificateGrid mtCrewCertificateGrid
    {
        get => HttpData.Get<MtCrewCertificateGrid>("mtCrewCertificateGrid")!;
        set => HttpData["mtCrewCertificateGrid"] = value;
    }

    /// <summary>
    /// Page class for MTCrewCertificate
    /// </summary>
    public class MtCrewCertificateGrid : MtCrewCertificateGridBase
    {
        // Constructor
        public MtCrewCertificateGrid() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MtCrewCertificateGridBase : MtCrewCertificate
    {
        // Page ID
        public string PageID = "grid";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "MTCrewCertificate";

        // Page object name
        public string PageObjName = "mtCrewCertificateGrid";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fMTCrewCertificategrid";

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
        public MtCrewCertificateGridBase()
        {
            // CSS class name as context
            TableVar = "MTCrewCertificate";
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);
            FormActionName = Config.FormRowActionName;
            FormBlankRowName = Config.FormBlankRowName;
            FormKeyCountName = Config.FormKeyCountName;

            // Initialize
            FormActionName += "_" + FormName;
            OldKeyName += "_" + FormName;
            FormBlankRowName += "_" + FormName;
            FormKeyCountName += "_" + FormName;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

            // CSS class name as context
            ContextClass = CheckClassName(TableVar);
            TableGridClass = AppendClass(TableGridClass, ContextClass);

            // Language object
            Language = ResolveLanguage();
            AddUrl = "MtCrewCertificateAdd";

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
        public string PageName => "MtCrewCertificateGrid";

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
            MTCertificateID.SetVisibility();
            CountryOfIssue_CountryID.SetVisibility();
            Number.SetVisibility();
            DateOfIssue.SetVisibility();
            DateOfExpiry.SetVisibility();
            PlaceOfIssue.SetVisibility();
            IssuingAuthority.SetVisibility();
            Level.SetVisibility();
            PaxVesselType.SetVisibility();
            Image.SetVisibility();
            ActiveDescription.Visible = false;
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            MTUserID.Visible = false;
        }

        /// <summary>
        /// Terminate page
        /// </summary>
        /// <param name="url">URL to rediect to</param>
        /// <returns>Page result</returns>
        public override IActionResult Terminate(string url = "") { // DN
            if (_terminated) // DN
                return new EmptyResult();
            if (Empty(url))
                return new EmptyResult();
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
                    SaveDebugMessage();
                    return Controller.LocalRedirect(AppPath(url));
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
                Image.OldUploadPath = Image.GetUploadPath();
                Image.UploadPath = Image.OldUploadPath;
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
        private Pager? _pager; // DN

        public int SelectedCount = 0;

        public int SelectedIndex = 0;

        #pragma warning disable 169

        public bool ShowOtherOptions = false;

        private DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType>? _connection;
        #pragma warning restore 169

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

        #pragma warning disable 618
        // Connection
        public override DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> Connection
        {
            get {
                _connection ??= GetConnection2(DbId);
                return _connection;
            }
        }
        #pragma warning restore 618

        /// <summary>
        /// Load recordset from filter
        /// <param name="filter">Record filter</param>
        /// </summary>
        public async Task LoadRecordsetFromFilter(string filter)
        {
            // Set up list options
            await SetupListOptions();

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

            // Get grid add count
            int gridaddcnt = Get<int>(Config.TableGridAddRowCount);
            if (gridaddcnt > 0)
                GridAddRowCount = gridaddcnt;

            // Set up list options
            await SetupListOptions();
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

            // Set up master detail parameters
            SetupMasterParms();

            // Setup other options
            SetupOtherOptions();

            // Set up lookup cache
            await SetupLookupOptions(MTCrewID);
            await SetupLookupOptions(MTCertificateID);
            await SetupLookupOptions(CountryOfIssue_CountryID);
            await SetupLookupOptions(CreatedByUserID);
            await SetupLookupOptions(LastUpdatedByUserID);

            // Load default values for add
            LoadDefaultValues();

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fMTCrewCertificategrid";

            // Set up infinite scroll
            UseInfiniteScroll = Param<bool>("infinitescroll");

            // Search filters
            string srchAdvanced = ""; // Advanced search filter
            string srchBasic = ""; // Basic search filter
            string filter = ""; // Filter
            string query = ""; // Query builder

            // Get command
            Command = Get("cmd").ToLower();

            // Set up records per page
            SetupDisplayRecords();

            // Handle reset command
            ResetCommand();

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

            // Show grid delete link for grid add / grid edit
            if (AllowAddDeleteRow) {
                if (IsGridAdd || IsGridEdit) {
                    var item = ListOptions["griddelete"];
                    if (item != null)
                        item.Visible = false;
                }
            }

            // Set up sorting order
            SetupSortOrder();

            // Restore display records
            if (Command != "json" && (RecordsPerPage == -1 || RecordsPerPage > 0)) {
                DisplayRecords = RecordsPerPage; // Restore from Session
            } else {
                DisplayRecords = 20; // Load default
                RecordsPerPage = DisplayRecords; // Save default to session
            }

            // Build filter
            filter = "";
            if (!Security.CanList)
                filter = "(0=1)"; // Filter all records

            // Restore master/detail filter from session
            DbMasterFilter = MasterFilterFromSession;
            DbDetailFilter = DetailFilterFromSession;

            // Add master User ID filter
            if (!Empty(Security.CurrentUserID) && !Security.IsAdmin) { // Non system admin
                if (CurrentMasterTable == "MTCrew")
                    DbMasterFilter = AddMasterUserIDFilter(DbMasterFilter, "MTCrew"); // Add master User ID filter
            }
            AddFilter(ref filter, DbDetailFilter);
            AddFilter(ref filter, SearchWhere);

            // Load master record
            if (CurrentMode != "add" && !Empty(MasterFilterFromSession) && CurrentMasterTable == "MTCrew") {
                mtCrew = Resolve("MTCrew")!;
                if (mtCrew != null) {
                    using (var rsmaster = await mtCrew.LoadReader(DbMasterFilter)) { // Note: Use {}
                        MasterRecordExists = rsmaster != null && await rsmaster.ReadAsync();
                        if (!MasterRecordExists) {
                            FailureMessage = Language.Phrase("NoRecord"); // Set no record found
                            return Terminate("MtCrewList"); // Return to master page
                        } else {
                            mtCrew.LoadListRowValues(rsmaster);
                        }
                    }
                    mtCrew.RowType = RowType.Master; // Master row
                    await mtCrew.RenderListRow(); // Note: Do it outside "using" // DN
                }
            }

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
                if (CurrentMode == "copy") {
                    TotalRecords = await ListRecordCountAsync();
                    Recordset = await LoadRecordset(StartRecord - 1, TotalRecords);
                    StartRecord = 1;
                    DisplayRecords = TotalRecords;
                } else {
                    CurrentFilter = "0=1";
                    StartRecord = 1;
                    DisplayRecords = GridAddRowCount;
                }
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
                DisplayRecords = TotalRecords; // Display all records

                // Recordset
                bool selectLimit = UseSelectLimit;
                if (selectLimit)
                    Recordset = await LoadRecordset(StartRecord - 1, DisplayRecords);
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
                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();

                // Page Render event
                mtCrewCertificateGrid?.PageRender();
            }
            return new EmptyResult();
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

        // Switch to grid add mode
        protected void GridAddMode() {
            CurrentAction = "gridadd";
            Session[Config.SessionInlineMode] = "gridadd"; // Enabled grid add
            HideFieldsForAddEdit();
        }

        // Switch to grid edit mode
        protected void GridEditMode() {
            CurrentAction = "gridedit";
            Session[Config.SessionInlineMode] = "gridedit"; // Enabled grid edit
            HideFieldsForAddEdit();
        }

        // Perform update to grid
        public async Task<bool> GridUpdate()
        {
            bool gridUpdate = true;

            // Get old recordset
            CurrentFilter = BuildKeyFilter();
            if (Empty(CurrentFilter))
                CurrentFilter = "0=1";
            string sql = CurrentSql;
            List<Dictionary<string, object>> rsold = await Connection.GetRowsAsync(sql);

            // Call Grid Updating event
            if (!GridUpdating(rsold)) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("GridEditCancelled"); // Set grid edit cancelled message
                EventCancelled = true;
                return false;
            }
            string wrkFilter = "";
            string key = "";

            // Update row index and get row key
            CurrentForm.Index = -1;
            int rowcnt = CurrentForm.GetInt(FormKeyCountName);

            // Load default values for emptyRow checking // DN
            LoadDefaultValues();

            // Update all rows based on key
            try {
                for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                    CurrentForm.Index = rowindex;
                    SetKey(CurrentForm.GetValue(OldKeyName));
                    string rowaction = CurrentForm.GetValue(FormActionName);

                    // Load all values and keys
                    if (rowaction != "insertdelete" && rowaction != "hide") { // Skip insert then deleted rows / hidden rows for grid edit
                        await LoadFormValues(); // Get form values
                        if (Empty(rowaction) || rowaction == "edit" || rowaction == "delete") {
                            gridUpdate = !Empty(OldKey); // Key must not be empty
                        } else {
                            gridUpdate = true;
                        }

                        // Skip empty row
                        if (rowaction == "insert" && EmptyRow()) {
                            // No action required
                        } else if (gridUpdate) { // Validate form and insert/update/delete record
                            if (rowaction == "delete") {
                                CurrentFilter = GetRecordFilter();
                                gridUpdate = await DeleteRows(); // Delete this row
                            } else {
                                if (rowaction == "insert") {
                                    gridUpdate = await AddRow(); // Insert this row
                                } else {
                                    if (!Empty(OldKey)) {
                                        SendEmail = false; // Do not send email on update success
                                        gridUpdate = await EditRow(); // Update this row
                                    }
                                } // End update
                                if (gridUpdate) // Get inserted or updated filter
                                    AddFilter(ref wrkFilter, GetRecordFilter(), "OR");
                            }
                        }
                        if (gridUpdate) {
                            if (!Empty(key))
                                key += ", ";
                            key += OldKey;
                        } else {
                            EventCancelled = true;
                            break;
                        }
                    }
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                gridUpdate = false;
            }
            if (gridUpdate) {
                FilterForModalActions = wrkFilter;

                // Get new recordset
                List<Dictionary<string, object>> rsnew = await Connection.GetRowsAsync(sql, true); // Use main connection (faster) // DN

                // Call Grid Updated event
                GridUpdated(rsold, rsnew);
                ClearInlineMode(); // Clear inline edit mode
            } else {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("UpdateFailed"); // Set update failed message
            }
            return gridUpdate;
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

        // Perform Grid Add
        #pragma warning disable 168, 219

        public async Task<bool> GridInsert()
        {
            int addcnt = 0;
            bool gridInsert = false;

            // Call Grid Inserting event
            if (!GridInserting()) {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("GridAddCancelled"); // Set grid add cancelled message
                EventCancelled = true;
                return false;
            }

            // Init key filter
            string wrkFilter = "";
            string key = "";

            // Get row count
            CurrentForm.Index = -1;
            int rowcnt = CurrentForm.GetInt(FormKeyCountName);

            // Load default values for emptyRow checking // DN
            LoadDefaultValues();

            // Insert all rows
            try {
                for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                    // Load current row values
                    CurrentForm.Index = rowindex;
                    string rowaction = CurrentForm.GetValue(FormActionName);
                    Dictionary<string, object>? rsold = null;
                    if (!Empty(rowaction) && rowaction != "insert")
                        continue; // Skip
                    if (rowaction == "insert") {
                        OldKey = CurrentForm.GetValue(OldKeyName);
                        rsold = await LoadOldRecord(); // Load old record
                    }
                    await LoadFormValues(); // Get form values
                    if (!EmptyRow()) {
                        addcnt++;
                        SendEmail = false; // Do not send email on insert success
                        gridInsert = await AddRow(rsold); // Insert row (already validated by validateGridForm())
                        if (gridInsert) {
                            if (!Empty(key))
                                key += Config.CompositeKeySeparator;
                            key += ConvertToString(ID.CurrentValue);

                            // Add filter for this record
                            AddFilter(ref wrkFilter, GetRecordFilter(), "OR");
                        } else {
                            EventCancelled = true;
                            break;
                        }
                    }
                }
                if (addcnt == 0) { // No record inserted
                    ClearInlineMode(); // Clear grid add mode and return
                    return true;
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                gridInsert = false;
            }
            if (gridInsert) {
                // Get new recordset
                CurrentFilter = wrkFilter;
                FilterForModalActions = wrkFilter;
                string sql = CurrentSql;
                List<Dictionary<string, object>> rsnew = await Connection.GetRowsAsync(sql, true); // Use main connection (faster) // DN

                // Call Grid Inserted event
                GridInserted(rsnew);
                ClearInlineMode(); // Clear grid add mode
            } else {
                if (Empty(FailureMessage))
                    FailureMessage = Language.Phrase("InsertFailed"); // Set insert failed message
            }
            return gridInsert;
        }
        #pragma warning restore 168, 219

        // Check if empty row
        public bool EmptyRow()
        {
            if (CurrentForm == null)
                return true;
            if (CurrentForm.HasValue("x_MTCrewID") && CurrentForm.HasValue("o_MTCrewID") && !SameString(MTCrewID.CurrentValue, MTCrewID.DefaultValue) &&
            !(MTCrewID.IsForeignKey && CurrentMasterTable != "" && SameString(MTCrewID.CurrentValue, MTCrewID.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_MTCertificateID") && CurrentForm.HasValue("o_MTCertificateID") && !SameString(MTCertificateID.CurrentValue, MTCertificateID.DefaultValue) &&
            !(MTCertificateID.IsForeignKey && CurrentMasterTable != "" && SameString(MTCertificateID.CurrentValue, MTCertificateID.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_CountryOfIssue_CountryID") && CurrentForm.HasValue("o_CountryOfIssue_CountryID") && !SameString(CountryOfIssue_CountryID.CurrentValue, CountryOfIssue_CountryID.DefaultValue) &&
            !(CountryOfIssue_CountryID.IsForeignKey && CurrentMasterTable != "" && SameString(CountryOfIssue_CountryID.CurrentValue, CountryOfIssue_CountryID.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_Number") && CurrentForm.HasValue("o_Number") && !SameString(Number.CurrentValue, Number.DefaultValue) &&
            !(Number.IsForeignKey && CurrentMasterTable != "" && SameString(Number.CurrentValue, Number.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_DateOfIssue") && CurrentForm.HasValue("o_DateOfIssue") && !SameString(FormatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern), FormatDateTime(DateOfIssue.DefaultValue, DateOfIssue.FormatPattern)) &&
            !(DateOfIssue.IsForeignKey && CurrentMasterTable != "" && SameString(FormatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern), FormatDateTime(DateOfIssue.SessionValue, DateOfIssue.FormatPattern))))
                return false;
            if (CurrentForm.HasValue("x_DateOfExpiry") && CurrentForm.HasValue("o_DateOfExpiry") && !SameString(FormatDateTime(DateOfExpiry.CurrentValue, DateOfExpiry.FormatPattern), FormatDateTime(DateOfExpiry.DefaultValue, DateOfExpiry.FormatPattern)) &&
            !(DateOfExpiry.IsForeignKey && CurrentMasterTable != "" && SameString(FormatDateTime(DateOfExpiry.CurrentValue, DateOfExpiry.FormatPattern), FormatDateTime(DateOfExpiry.SessionValue, DateOfExpiry.FormatPattern))))
                return false;
            if (CurrentForm.HasValue("x_PlaceOfIssue") && CurrentForm.HasValue("o_PlaceOfIssue") && !SameString(PlaceOfIssue.CurrentValue, PlaceOfIssue.DefaultValue) &&
            !(PlaceOfIssue.IsForeignKey && CurrentMasterTable != "" && SameString(PlaceOfIssue.CurrentValue, PlaceOfIssue.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_IssuingAuthority") && CurrentForm.HasValue("o_IssuingAuthority") && !SameString(IssuingAuthority.CurrentValue, IssuingAuthority.DefaultValue) &&
            !(IssuingAuthority.IsForeignKey && CurrentMasterTable != "" && SameString(IssuingAuthority.CurrentValue, IssuingAuthority.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_Level") && CurrentForm.HasValue("o_Level") && !SameString(Level.CurrentValue, Level.DefaultValue) &&
            !(Level.IsForeignKey && CurrentMasterTable != "" && SameString(Level.CurrentValue, Level.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_PaxVesselType") && CurrentForm.HasValue("o_PaxVesselType") && !SameString(PaxVesselType.CurrentValue, PaxVesselType.DefaultValue) &&
            !(PaxVesselType.IsForeignKey && CurrentMasterTable != "" && SameString(PaxVesselType.CurrentValue, PaxVesselType.SessionValue)))
                return false;
            if (!Empty(Image.Upload.Value))
                return false;
            if (CurrentForm.HasValue("x_CreatedByUserID") && CurrentForm.HasValue("o_CreatedByUserID") && !SameString(CreatedByUserID.CurrentValue, CreatedByUserID.DefaultValue) &&
            !(CreatedByUserID.IsForeignKey && CurrentMasterTable != "" && SameString(CreatedByUserID.CurrentValue, CreatedByUserID.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_CreatedDateTime") && CurrentForm.HasValue("o_CreatedDateTime") && !SameString(FormatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern), FormatDateTime(CreatedDateTime.DefaultValue, CreatedDateTime.FormatPattern)) &&
            !(CreatedDateTime.IsForeignKey && CurrentMasterTable != "" && SameString(FormatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern), FormatDateTime(CreatedDateTime.SessionValue, CreatedDateTime.FormatPattern))))
                return false;
            if (CurrentForm.HasValue("x_LastUpdatedByUserID") && CurrentForm.HasValue("o_LastUpdatedByUserID") && !SameString(LastUpdatedByUserID.CurrentValue, LastUpdatedByUserID.DefaultValue) &&
            !(LastUpdatedByUserID.IsForeignKey && CurrentMasterTable != "" && SameString(LastUpdatedByUserID.CurrentValue, LastUpdatedByUserID.SessionValue)))
                return false;
            if (CurrentForm.HasValue("x_LastUpdatedDateTime") && CurrentForm.HasValue("o_LastUpdatedDateTime") && !SameString(FormatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern), FormatDateTime(LastUpdatedDateTime.DefaultValue, LastUpdatedDateTime.FormatPattern)) &&
            !(LastUpdatedDateTime.IsForeignKey && CurrentMasterTable != "" && SameString(FormatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern), FormatDateTime(LastUpdatedDateTime.SessionValue, LastUpdatedDateTime.FormatPattern))))
                return false;
            return true;
        }

        // Validate grid form
        public async Task<bool> ValidateGridForm()
        {
            // Get row count
            CurrentForm.Index = -1;
            int rowcnt = CurrentForm.GetInt(FormKeyCountName);

            // Load default values for emptyRow checking
            LoadDefaultValues();

            // Validate all records
            for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                // Load current row values
                CurrentForm.Index = rowindex;
                string rowaction = CurrentForm.GetValue(FormActionName);
                if (rowaction != "delete" && rowaction != "insertdelete" && rowaction != "hide") {
                    await LoadFormValues(); // Get form values
                    if (rowaction == "insert" && EmptyRow()) {
                        // Ignore
                    } else if (!await ValidateForm()) {
                        return false;
                    }
                }
            }
            return true;
        }

        // Get all form values of the grid
        public List<Dictionary<string, string?>> GetGridFormValues()
        {
            // Get row count
            CurrentForm.Index = -1;
            int rowcnt = CurrentForm.GetInt(FormKeyCountName);
            List<Dictionary<string, string?>> rows = new ();

            // Loop through all records
            for (int rowindex = 1; rowindex <= rowcnt; rowindex++) {
                // Load current row values
                CurrentForm.Index = rowindex;
                string rowaction = CurrentForm.GetValue(FormActionName);
                if (rowaction != "delete" && rowaction != "insertdelete") {
                    LoadFormValues().GetAwaiter().GetResult(); // Load form values (sync)
                    if (rowaction == "insert" && EmptyRow()) {
                        // Ignore
                    } else {
                        rows.Add(GetFormValues()); // Return row as array
                    }
                }
            }
            return rows; // Return as array of array
        }

        // Restore form values for current row
        public async Task RestoreCurrentRowFormValues(object index)
        {
            // Get row based on current index
            if (index is int idx)
                CurrentForm.Index = idx;
            string rowaction = CurrentForm.GetValue(FormActionName);
            await LoadFormValues(); // Load form values
            // Set up invalid status correctly
            ResetFormError();
            if (rowaction == "insert" && EmptyRow()) {
                // Ignore
            } else {
                await ValidateForm();
            }
        }

        // Reset form status
        public void ResetFormError()
        {
            MTCrewID.ClearErrorMessage();
            MTCertificateID.ClearErrorMessage();
            CountryOfIssue_CountryID.ClearErrorMessage();
            Number.ClearErrorMessage();
            DateOfIssue.ClearErrorMessage();
            DateOfExpiry.ClearErrorMessage();
            PlaceOfIssue.ClearErrorMessage();
            IssuingAuthority.ClearErrorMessage();
            Level.ClearErrorMessage();
            PaxVesselType.ClearErrorMessage();
            Image.ClearErrorMessage();
            CreatedByUserID.ClearErrorMessage();
            CreatedDateTime.ClearErrorMessage();
            LastUpdatedByUserID.ClearErrorMessage();
            LastUpdatedDateTime.ClearErrorMessage();
        }

        // Set up sort parameters
        protected void SetupSortOrder() {
            // Load default Sorting Order
            if (Command != "json") {
                string defaultSort = ""; // Set up default sort
                if (Empty(SessionOrderBy) && !Empty(defaultSort))
                    SessionOrderBy = defaultSort;
            }

            // Check for "order" parameter
            if (Get("order", out StringValues sv)) {
                CurrentOrder = sv.ToString();
                CurrentOrderType = Get("ordertype");
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
                // Reset master/detail keys
                if (SameText(Command, "resetall")) {
                    CurrentMasterTable = ""; // Clear master table
                    DbMasterFilter = "";
                    DbDetailFilter = "";
                    MTCrewID.SessionValue = "";
                }

                // Reset (clear) sorting order
                if (SameText(Command, "resetsort")) {
                    string orderBy = "";
                    SessionOrderBy = orderBy;
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

            // "griddelete"
            if (AllowAddDeleteRow) {
                item = ListOptions.Add("griddelete");
                item.CssClass = "text-nowrap";
                item.OnLeft = true;
                item.Visible = false; // Default hidden
            }

            // Add group option item
            item = ListOptions.AddGroupOption();
            item.Body = "";
            item.OnLeft = true;
            item.Visible = false;

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

            // Set up row action and key
            if (IsNumeric(RowIndex) && RowType != RowType.View) {
                CurrentForm.Index = ConvertToInt(RowIndex);
                var actionName = FormActionName.Replace("k_", "k" + ConvertToString(RowIndex) + "_");
                var oldKeyName = OldKeyName.Replace("k_", "k" + ConvertToString(RowIndex) + "_");
                var blankRowName = FormBlankRowName.Replace("k_", "k" + ConvertToString(RowIndex) + "_");
                if (!Empty(RowAction))
                    MultiSelectKey += "<input type=\"hidden\" name=\"" + actionName + "\" id=\"" + actionName + "\" value=\"" + RowAction + "\">";
                string oldKey = GetKey(false); // Get from OldValue
                if (!Empty(oldKeyName) && !Empty(oldKey)) {
                    MultiSelectKey += "<input type=\"hidden\" name=\"" + oldKeyName + "\" id=\"" + oldKeyName + "\" value=\"" + HtmlEncode(oldKey) + "\">";
                }
                if (RowAction == "insert" && IsConfirm && EmptyRow())
                    MultiSelectKey += "<input type=\"hidden\" name=\"" + blankRowName + "\" id=\"" + blankRowName + "\" value=\"1\">";
            }

            // "delete"
            if (AllowAddDeleteRow) {
                if (CurrentMode == "add" || CurrentMode == "copy" || CurrentMode == "edit") {
                    var options = ListOptions;
                    options.UseButtonGroup = true; // Use button group for grid delete button
                    listOption = options["griddelete"];
                    if (IsNumeric(RowIndex) && (RowAction == "" || RowAction == "edit")) { // Do not allow delete existing record
                        listOption?.SetBody("&nbsp;");
                    } else {
                        listOption?.SetBody("<a class=\"ew-grid-link ew-grid-delete\" title=\"" + Language.Phrase("DeleteLink", true) + "\" data-caption=\"" + Language.Phrase("DeleteLink", true) + "\" data-ew-action=\"delete-grid-row\" data-rowindex=\"" + RowIndex + "\">" + Language.Phrase("DeleteLink") + "</a>");
                    }
                }
            }

            // "sequence"
            listOption = ListOptions["sequence"];
            listOption?.SetBody(FormatSequenceNumber(RecordCount));
            if (CurrentMode == "view") { // View mode
            } // End View mode
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
            option = OtherOptions["addedit"];
            option.UseDropDownButton = false;
            option.DropDownButtonPhrase = "ButtonAddEdit";
            option.UseButtonGroup = true;
            option.ButtonClass = ""; // Class for button group
            item = option.AddGroupOption();
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
                if ((CurrentMode == "add" || CurrentMode == "copy" || CurrentMode == "edit") && !IsConfirm) { // Check add/copy/edit mode
                    if (AllowAddDeleteRow) {
                        option = options["addedit"];
                        option.UseDropDownButton = false;
                        item = option.Add("addblankrow");
                        item.Body = "<a class=\"ew-add-edit ew-add-blank-row\" title=\"" + Language.Phrase("AddBlankRow", true) + "\" data-caption=\"" + Language.Phrase("AddBlankRow", true) + "\" data-ew-action=\"add-grid-row\">" + Language.Phrase("AddBlankRow") + "</a>";
                        item.Visible = false;
                        ShowOtherOptions = item.Visible;
                    }
                }
                if (CurrentMode == "view") { // Check view mode
                    option = options["addedit"];
                    item = option.GetItem("add");
                    ShowOtherOptions = !Empty(item) && item.Visible;
                }
        }

        // Set up Grid
        public async Task SetupGrid()
        {
            StartRecord = 1;
            StopRecord = TotalRecords; // Show all records

            // Restore number of post back records
            if (CurrentForm != null && (IsConfirm || EventCancelled)) {
                CurrentForm!.ResetIndex(); // DN
                if (CurrentForm!.HasValue(FormKeyCountName) && (IsGridAdd || IsGridEdit || IsConfirm)) {
                    KeyCount = CurrentForm.GetInt(FormKeyCountName);
                    StopRecord = StartRecord + KeyCount - 1;
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
                    RowAttrs.Add("id", "r0_MTCrewCertificate");
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
            if (CurrentForm != null && (IsGridAdd || IsGridEdit || IsConfirm || IsMultiEdit)) {
                RowIndex = ConvertToInt(RowIndex) + 1;
                CurrentForm!.SetIndex(ConvertToInt(RowIndex));
                if (CurrentForm!.HasValue(FormActionName) && (IsConfirm || EventCancelled))
                    RowAction = CurrentForm.GetValue(FormActionName);
                else if (IsGridAdd)
                    RowAction = "insert";
                else
                    RowAction = "";
            }

            // Set up key count
            KeyCount = ConvertToInt(RowIndex);

            // Init row class and style
            ResetAttributes();
            CssClass = "";
            if (IsGridAdd) {
                if (CurrentMode == "copy") {
                    await LoadRowValues(Recordset); // Load row values
                    OldKey = GetKey(true); // Get from CurrentValue
                } else {
                    await LoadRowValues(); // Load default values
                    OldKey = "";
                }
            } else {
                await LoadRowValues(Recordset); // Load row values
                OldKey = GetKey(true); // Get from CurrentValue
            }
            SetKey(OldKey);
            RowType = RowType.View; // Render view
            if ((IsAdd || IsCopy) && InlineRowCount == 0 || IsGridAdd) // Add
                RowType = RowType.Add; // Render add
            if (IsGridAdd && EventCancelled && !CurrentForm!.HasValue(FormBlankRowName)) // Insert failed
                await RestoreCurrentRowFormValues(RowIndex); // Restore form values
            if (IsGridEdit) { // Grid edit
                if (EventCancelled)
                    await RestoreCurrentRowFormValues(RowIndex); // Restore form values
                if (RowAction == "insert")
                    RowType = RowType.Add; // Render add
                else
                    RowType = RowType.Edit; // Render edit
            }
            if (IsGridEdit && (RowType == RowType.Edit || RowType == RowType.Add) && EventCancelled) // Update failed
                await RestoreCurrentRowFormValues(RowIndex); // Restore form values
            if (IsConfirm) // Confirm row
                await RestoreCurrentRowFormValues(RowIndex); // Restore form values

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
            RowAttrs.Add("data-rowindex", ConvertToString(mtCrewCertificateGrid.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(mtCrewCertificateGrid.RowCount) + "_MTCrewCertificate");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(mtCrewCertificateGrid.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && mtCrewCertificateGrid.RowType == RowType.Add || IsEdit && mtCrewCertificateGrid.RowType == RowType.Edit) // Inline-Add/Edit row
                RowAttrs.AppendClass("table-active");

            // Render row
            await RenderRow();

            // Render list options
            await RenderListOptions();
        }

        // Confirm page
        public bool ConfirmPage = false; // DN

        #pragma warning disable 1998
        // Get upload files
        public async Task GetUploadFiles()
        {
            // Get upload data
            Image.Upload.Index = CurrentForm.Index;
            if (!await Image.Upload.UploadFile()) // DN
                End(Image.Upload.Message);
            Image.CurrentValue = Image.Upload.FileName;
        }
        #pragma warning restore 1998

        // Load default values
        protected void LoadDefaultValues() {
            Image.Upload.Index = ConvertToInt(RowIndex);
            MTUserID.DefaultValue = CurrentUserID();
            MTUserID.OldValue = MTUserID.DefaultValue;
        }

        #pragma warning disable 1998
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            CurrentForm.FormName = FormName;
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
            if (CurrentForm.HasValue("o_MTCrewID"))
                MTCrewID.OldValue = CurrentForm.GetValue("o_MTCrewID");

            // Check field name 'MTCertificateID' before field var 'x_MTCertificateID'
            val = CurrentForm.HasValue("MTCertificateID") ? CurrentForm.GetValue("MTCertificateID") : CurrentForm.GetValue("x_MTCertificateID");
            if (!MTCertificateID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTCertificateID") && !CurrentForm.HasValue("x_MTCertificateID")) // DN
                    MTCertificateID.Visible = false; // Disable update for API request
                else
                    MTCertificateID.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_MTCertificateID"))
                MTCertificateID.OldValue = CurrentForm.GetValue("o_MTCertificateID");

            // Check field name 'CountryOfIssue_CountryID' before field var 'x_CountryOfIssue_CountryID'
            val = CurrentForm.HasValue("CountryOfIssue_CountryID") ? CurrentForm.GetValue("CountryOfIssue_CountryID") : CurrentForm.GetValue("x_CountryOfIssue_CountryID");
            if (!CountryOfIssue_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CountryOfIssue_CountryID") && !CurrentForm.HasValue("x_CountryOfIssue_CountryID")) // DN
                    CountryOfIssue_CountryID.Visible = false; // Disable update for API request
                else
                    CountryOfIssue_CountryID.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_CountryOfIssue_CountryID"))
                CountryOfIssue_CountryID.OldValue = CurrentForm.GetValue("o_CountryOfIssue_CountryID");

            // Check field name 'Number' before field var 'x_Number'
            val = CurrentForm.HasValue("Number") ? CurrentForm.GetValue("Number") : CurrentForm.GetValue("x_Number");
            if (!Number.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Number") && !CurrentForm.HasValue("x_Number")) // DN
                    Number.Visible = false; // Disable update for API request
                else
                    Number.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_Number"))
                Number.OldValue = CurrentForm.GetValue("o_Number");

            // Check field name 'DateOfIssue' before field var 'x_DateOfIssue'
            val = CurrentForm.HasValue("DateOfIssue") ? CurrentForm.GetValue("DateOfIssue") : CurrentForm.GetValue("x_DateOfIssue");
            if (!DateOfIssue.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DateOfIssue") && !CurrentForm.HasValue("x_DateOfIssue")) // DN
                    DateOfIssue.Visible = false; // Disable update for API request
                else
                    DateOfIssue.SetFormValue(val, true, validate);
                DateOfIssue.CurrentValue = UnformatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern);
            }
            DateOfIssue.OldValue = UnformatDateTime(CurrentForm.GetValue("o_DateOfIssue"), DateOfIssue.FormatPattern);

            // Check field name 'DateOfExpiry' before field var 'x_DateOfExpiry'
            val = CurrentForm.HasValue("DateOfExpiry") ? CurrentForm.GetValue("DateOfExpiry") : CurrentForm.GetValue("x_DateOfExpiry");
            if (!DateOfExpiry.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DateOfExpiry") && !CurrentForm.HasValue("x_DateOfExpiry")) // DN
                    DateOfExpiry.Visible = false; // Disable update for API request
                else
                    DateOfExpiry.SetFormValue(val, true, validate);
                DateOfExpiry.CurrentValue = UnformatDateTime(DateOfExpiry.CurrentValue, DateOfExpiry.FormatPattern);
            }
            DateOfExpiry.OldValue = UnformatDateTime(CurrentForm.GetValue("o_DateOfExpiry"), DateOfExpiry.FormatPattern);

            // Check field name 'PlaceOfIssue' before field var 'x_PlaceOfIssue'
            val = CurrentForm.HasValue("PlaceOfIssue") ? CurrentForm.GetValue("PlaceOfIssue") : CurrentForm.GetValue("x_PlaceOfIssue");
            if (!PlaceOfIssue.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PlaceOfIssue") && !CurrentForm.HasValue("x_PlaceOfIssue")) // DN
                    PlaceOfIssue.Visible = false; // Disable update for API request
                else
                    PlaceOfIssue.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_PlaceOfIssue"))
                PlaceOfIssue.OldValue = CurrentForm.GetValue("o_PlaceOfIssue");

            // Check field name 'IssuingAuthority' before field var 'x_IssuingAuthority'
            val = CurrentForm.HasValue("IssuingAuthority") ? CurrentForm.GetValue("IssuingAuthority") : CurrentForm.GetValue("x_IssuingAuthority");
            if (!IssuingAuthority.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IssuingAuthority") && !CurrentForm.HasValue("x_IssuingAuthority")) // DN
                    IssuingAuthority.Visible = false; // Disable update for API request
                else
                    IssuingAuthority.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_IssuingAuthority"))
                IssuingAuthority.OldValue = CurrentForm.GetValue("o_IssuingAuthority");

            // Check field name 'Level' before field var 'x_Level'
            val = CurrentForm.HasValue("Level") ? CurrentForm.GetValue("Level") : CurrentForm.GetValue("x_Level");
            if (!Level.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Level") && !CurrentForm.HasValue("x_Level")) // DN
                    Level.Visible = false; // Disable update for API request
                else
                    Level.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_Level"))
                Level.OldValue = CurrentForm.GetValue("o_Level");

            // Check field name 'PaxVesselType' before field var 'x_PaxVesselType'
            val = CurrentForm.HasValue("PaxVesselType") ? CurrentForm.GetValue("PaxVesselType") : CurrentForm.GetValue("x_PaxVesselType");
            if (!PaxVesselType.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PaxVesselType") && !CurrentForm.HasValue("x_PaxVesselType")) // DN
                    PaxVesselType.Visible = false; // Disable update for API request
                else
                    PaxVesselType.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_PaxVesselType"))
                PaxVesselType.OldValue = CurrentForm.GetValue("o_PaxVesselType");

            // Check field name 'CreatedByUserID' before field var 'x_CreatedByUserID'
            val = CurrentForm.HasValue("CreatedByUserID") ? CurrentForm.GetValue("CreatedByUserID") : CurrentForm.GetValue("x_CreatedByUserID");
            if (!CreatedByUserID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CreatedByUserID") && !CurrentForm.HasValue("x_CreatedByUserID")) // DN
                    CreatedByUserID.Visible = false; // Disable update for API request
                else
                    CreatedByUserID.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_CreatedByUserID"))
                CreatedByUserID.OldValue = CurrentForm.GetValue("o_CreatedByUserID");

            // Check field name 'CreatedDateTime' before field var 'x_CreatedDateTime'
            val = CurrentForm.HasValue("CreatedDateTime") ? CurrentForm.GetValue("CreatedDateTime") : CurrentForm.GetValue("x_CreatedDateTime");
            if (!CreatedDateTime.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CreatedDateTime") && !CurrentForm.HasValue("x_CreatedDateTime")) // DN
                    CreatedDateTime.Visible = false; // Disable update for API request
                else
                    CreatedDateTime.SetFormValue(val, true, validate);
                CreatedDateTime.CurrentValue = UnformatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern);
            }
            CreatedDateTime.OldValue = UnformatDateTime(CurrentForm.GetValue("o_CreatedDateTime"), CreatedDateTime.FormatPattern);

            // Check field name 'LastUpdatedByUserID' before field var 'x_LastUpdatedByUserID'
            val = CurrentForm.HasValue("LastUpdatedByUserID") ? CurrentForm.GetValue("LastUpdatedByUserID") : CurrentForm.GetValue("x_LastUpdatedByUserID");
            if (!LastUpdatedByUserID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LastUpdatedByUserID") && !CurrentForm.HasValue("x_LastUpdatedByUserID")) // DN
                    LastUpdatedByUserID.Visible = false; // Disable update for API request
                else
                    LastUpdatedByUserID.SetFormValue(val);
            }
            if (CurrentForm.HasValue("o_LastUpdatedByUserID"))
                LastUpdatedByUserID.OldValue = CurrentForm.GetValue("o_LastUpdatedByUserID");

            // Check field name 'LastUpdatedDateTime' before field var 'x_LastUpdatedDateTime'
            val = CurrentForm.HasValue("LastUpdatedDateTime") ? CurrentForm.GetValue("LastUpdatedDateTime") : CurrentForm.GetValue("x_LastUpdatedDateTime");
            if (!LastUpdatedDateTime.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("LastUpdatedDateTime") && !CurrentForm.HasValue("x_LastUpdatedDateTime")) // DN
                    LastUpdatedDateTime.Visible = false; // Disable update for API request
                else
                    LastUpdatedDateTime.SetFormValue(val, true, validate);
                LastUpdatedDateTime.CurrentValue = UnformatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern);
            }
            LastUpdatedDateTime.OldValue = UnformatDateTime(CurrentForm.GetValue("o_LastUpdatedDateTime"), LastUpdatedDateTime.FormatPattern);

            // Check field name 'ID' before field var 'x_ID'
            val = CurrentForm.HasValue("ID") ? CurrentForm.GetValue("ID") : CurrentForm.GetValue("x_ID");
            if (!ID.IsDetailKey && !IsGridAdd && !IsAdd)
                ID.SetFormValue(val);
            Image.OldUploadPath = Image.GetUploadPath();
            Image.UploadPath = Image.OldUploadPath;
            await GetUploadFiles(); // Get upload files
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            if (!IsGridAdd && !IsAdd)
                ID.CurrentValue = ID.FormValue;
            MTCrewID.CurrentValue = MTCrewID.FormValue;
            MTCertificateID.CurrentValue = MTCertificateID.FormValue;
            CountryOfIssue_CountryID.CurrentValue = CountryOfIssue_CountryID.FormValue;
            Number.CurrentValue = Number.FormValue;
            DateOfIssue.CurrentValue = DateOfIssue.FormValue;
            DateOfIssue.CurrentValue = UnformatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern);
            DateOfExpiry.CurrentValue = DateOfExpiry.FormValue;
            DateOfExpiry.CurrentValue = UnformatDateTime(DateOfExpiry.CurrentValue, DateOfExpiry.FormatPattern);
            PlaceOfIssue.CurrentValue = PlaceOfIssue.FormValue;
            IssuingAuthority.CurrentValue = IssuingAuthority.FormValue;
            Level.CurrentValue = Level.FormValue;
            PaxVesselType.CurrentValue = PaxVesselType.FormValue;
            CreatedByUserID.CurrentValue = CreatedByUserID.FormValue;
            CreatedDateTime.CurrentValue = CreatedDateTime.FormValue;
            CreatedDateTime.CurrentValue = UnformatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern);
            LastUpdatedByUserID.CurrentValue = LastUpdatedByUserID.FormValue;
            LastUpdatedDateTime.CurrentValue = LastUpdatedDateTime.FormValue;
            LastUpdatedDateTime.CurrentValue = UnformatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern);
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
            MTCertificateID.SetDbValue(row["MTCertificateID"]);
            CountryOfIssue_CountryID.SetDbValue(row["CountryOfIssue_CountryID"]);
            Number.SetDbValue(row["Number"]);
            DateOfIssue.SetDbValue(row["DateOfIssue"]);
            DateOfExpiry.SetDbValue(row["DateOfExpiry"]);
            PlaceOfIssue.SetDbValue(row["PlaceOfIssue"]);
            IssuingAuthority.SetDbValue(row["IssuingAuthority"]);
            Level.SetDbValue(row["Level"]);
            PaxVesselType.SetDbValue(row["PaxVesselType"]);
            Image.Upload.DbValue = row["Image"];
            Image.SetDbValue(Image.Upload.DbValue);
            Image.Upload.Index = ConvertToInt(RowIndex);
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
            row.Add("MTCertificateID", MTCertificateID.DefaultValue ?? DbNullValue); // DN
            row.Add("CountryOfIssue_CountryID", CountryOfIssue_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("Number", Number.DefaultValue ?? DbNullValue); // DN
            row.Add("DateOfIssue", DateOfIssue.DefaultValue ?? DbNullValue); // DN
            row.Add("DateOfExpiry", DateOfExpiry.DefaultValue ?? DbNullValue); // DN
            row.Add("PlaceOfIssue", PlaceOfIssue.DefaultValue ?? DbNullValue); // DN
            row.Add("IssuingAuthority", IssuingAuthority.DefaultValue ?? DbNullValue); // DN
            row.Add("Level", Level.DefaultValue ?? DbNullValue); // DN
            row.Add("PaxVesselType", PaxVesselType.DefaultValue ?? DbNullValue); // DN
            row.Add("Image", Image.DefaultValue ?? DbNullValue); // DN
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
            ID.CellCssStyle = "white-space: nowrap;";

            // MTCrewID
            MTCrewID.CellCssStyle = "white-space: nowrap;";

            // MTCertificateID
            MTCertificateID.CellCssStyle = "white-space: nowrap;";

            // CountryOfIssue_CountryID
            CountryOfIssue_CountryID.CellCssStyle = "white-space: nowrap;";

            // Number
            Number.CellCssStyle = "white-space: nowrap;";

            // DateOfIssue
            DateOfIssue.CellCssStyle = "white-space: nowrap;";

            // DateOfExpiry
            DateOfExpiry.CellCssStyle = "white-space: nowrap;";

            // PlaceOfIssue
            PlaceOfIssue.CellCssStyle = "white-space: nowrap;";

            // IssuingAuthority
            IssuingAuthority.CellCssStyle = "white-space: nowrap;";

            // Level
            Level.CellCssStyle = "white-space: nowrap;";

            // PaxVesselType
            PaxVesselType.CellCssStyle = "white-space: nowrap;";

            // Image
            Image.CellCssStyle = "white-space: nowrap;";

            // ActiveDescription
            ActiveDescription.CellCssStyle = "white-space: nowrap;";

            // CreatedByUserID
            CreatedByUserID.CellCssStyle = "white-space: nowrap;";

            // CreatedDateTime
            CreatedDateTime.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedByUserID
            LastUpdatedByUserID.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedDateTime
            LastUpdatedDateTime.CellCssStyle = "white-space: nowrap;";

            // MTUserID
            MTUserID.CellCssStyle = "white-space: nowrap;";

            // View row
            if (RowType == RowType.View) {
                // MTCrewID
                curVal = ConvertToString(MTCrewID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MTCrewID.Lookup != null && IsDictionary(MTCrewID.Lookup?.Options) && MTCrewID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTCrewID.ViewValue = MTCrewID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MTCrewID.CurrentValue, DataType.Number, "");
                        sqlWrk = MTCrewID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MTCrewID.Lookup != null) { // Lookup values found
                            var listwrk = MTCrewID.Lookup?.RenderViewRow(rswrk[0]);
                            MTCrewID.ViewValue = MTCrewID.HighlightLookup(ConvertToString(rswrk[0]), MTCrewID.DisplayValue(listwrk));
                        } else {
                            MTCrewID.ViewValue = MTCrewID.CurrentValue;
                        }
                    }
                } else {
                    MTCrewID.ViewValue = DbNullValue;
                }
                MTCrewID.ViewCustomAttributes = "";

                // MTCertificateID
                curVal = ConvertToString(MTCertificateID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MTCertificateID.Lookup != null && IsDictionary(MTCertificateID.Lookup?.Options) && MTCertificateID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTCertificateID.ViewValue = MTCertificateID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MTCertificateID.CurrentValue, DataType.Number, "");
                        sqlWrk = MTCertificateID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MTCertificateID.Lookup != null) { // Lookup values found
                            var listwrk = MTCertificateID.Lookup?.RenderViewRow(rswrk[0]);
                            MTCertificateID.ViewValue = MTCertificateID.HighlightLookup(ConvertToString(rswrk[0]), MTCertificateID.DisplayValue(listwrk));
                        } else {
                            MTCertificateID.ViewValue = FormatNumber(MTCertificateID.CurrentValue, MTCertificateID.FormatPattern);
                        }
                    }
                } else {
                    MTCertificateID.ViewValue = DbNullValue;
                }
                MTCertificateID.ViewCustomAttributes = "";

                // CountryOfIssue_CountryID
                curVal = ConvertToString(CountryOfIssue_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (CountryOfIssue_CountryID.Lookup != null && IsDictionary(CountryOfIssue_CountryID.Lookup?.Options) && CountryOfIssue_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        CountryOfIssue_CountryID.ViewValue = CountryOfIssue_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", CountryOfIssue_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = CountryOfIssue_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && CountryOfIssue_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = CountryOfIssue_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            CountryOfIssue_CountryID.ViewValue = CountryOfIssue_CountryID.HighlightLookup(ConvertToString(rswrk[0]), CountryOfIssue_CountryID.DisplayValue(listwrk));
                        } else {
                            CountryOfIssue_CountryID.ViewValue = FormatNumber(CountryOfIssue_CountryID.CurrentValue, CountryOfIssue_CountryID.FormatPattern);
                        }
                    }
                } else {
                    CountryOfIssue_CountryID.ViewValue = DbNullValue;
                }
                CountryOfIssue_CountryID.ViewCustomAttributes = "";

                // Number
                Number.ViewValue = ConvertToString(Number.CurrentValue); // DN
                Number.ViewCustomAttributes = "";

                // DateOfIssue
                DateOfIssue.ViewValue = DateOfIssue.CurrentValue;
                DateOfIssue.ViewValue = FormatDateTime(DateOfIssue.ViewValue, DateOfIssue.FormatPattern);
                DateOfIssue.ViewCustomAttributes = "";

                // DateOfExpiry
                DateOfExpiry.ViewValue = DateOfExpiry.CurrentValue;
                DateOfExpiry.ViewValue = FormatDateTime(DateOfExpiry.ViewValue, DateOfExpiry.FormatPattern);
                DateOfExpiry.ViewCustomAttributes = "";

                // PlaceOfIssue
                PlaceOfIssue.ViewValue = ConvertToString(PlaceOfIssue.CurrentValue); // DN
                PlaceOfIssue.ViewCustomAttributes = "";

                // IssuingAuthority
                IssuingAuthority.ViewValue = ConvertToString(IssuingAuthority.CurrentValue); // DN
                IssuingAuthority.ViewCustomAttributes = "";

                // Level
                Level.ViewValue = ConvertToString(Level.CurrentValue); // DN
                Level.ViewCustomAttributes = "";

                // PaxVesselType
                PaxVesselType.ViewValue = ConvertToString(PaxVesselType.CurrentValue); // DN
                PaxVesselType.ViewCustomAttributes = "";

                // Image
                Image.UploadPath = Image.GetUploadPath();
                if (!IsNull(Image.Upload.DbValue)) {
                    Image.ImageWidth = 200;
                    Image.ImageHeight = 200;
                    Image.ImageAlt = Image.Alt;
                    Image.ImageCssClass = "ew-image";
                    Image.ViewValue = Image.Upload.DbValue;
                } else {
                    Image.ViewValue = "";
                }
                Image.CellCssStyle += "text-align: center;";
                Image.ViewCustomAttributes = "";

                // CreatedByUserID
                curVal = ConvertToString(CreatedByUserID.CurrentValue);
                if (!Empty(curVal)) {
                    if (CreatedByUserID.Lookup != null && IsDictionary(CreatedByUserID.Lookup?.Options) && CreatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        CreatedByUserID.ViewValue = CreatedByUserID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", CreatedByUserID.CurrentValue, DataType.Number, "");
                        sqlWrk = CreatedByUserID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && CreatedByUserID.Lookup != null) { // Lookup values found
                            var listwrk = CreatedByUserID.Lookup?.RenderViewRow(rswrk[0]);
                            CreatedByUserID.ViewValue = CreatedByUserID.HighlightLookup(ConvertToString(rswrk[0]), CreatedByUserID.DisplayValue(listwrk));
                        } else {
                            CreatedByUserID.ViewValue = FormatNumber(CreatedByUserID.CurrentValue, CreatedByUserID.FormatPattern);
                        }
                    }
                } else {
                    CreatedByUserID.ViewValue = DbNullValue;
                }
                CreatedByUserID.ViewCustomAttributes = "";

                // CreatedDateTime
                CreatedDateTime.ViewValue = CreatedDateTime.CurrentValue;
                CreatedDateTime.ViewValue = FormatDateTime(CreatedDateTime.ViewValue, CreatedDateTime.FormatPattern);
                CreatedDateTime.ViewCustomAttributes = "";

                // LastUpdatedByUserID
                curVal = ConvertToString(LastUpdatedByUserID.CurrentValue);
                if (!Empty(curVal)) {
                    if (LastUpdatedByUserID.Lookup != null && IsDictionary(LastUpdatedByUserID.Lookup?.Options) && LastUpdatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        LastUpdatedByUserID.ViewValue = LastUpdatedByUserID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", LastUpdatedByUserID.CurrentValue, DataType.Number, "");
                        sqlWrk = LastUpdatedByUserID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && LastUpdatedByUserID.Lookup != null) { // Lookup values found
                            var listwrk = LastUpdatedByUserID.Lookup?.RenderViewRow(rswrk[0]);
                            LastUpdatedByUserID.ViewValue = LastUpdatedByUserID.HighlightLookup(ConvertToString(rswrk[0]), LastUpdatedByUserID.DisplayValue(listwrk));
                        } else {
                            LastUpdatedByUserID.ViewValue = FormatNumber(LastUpdatedByUserID.CurrentValue, LastUpdatedByUserID.FormatPattern);
                        }
                    }
                } else {
                    LastUpdatedByUserID.ViewValue = DbNullValue;
                }
                LastUpdatedByUserID.ViewCustomAttributes = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.ViewValue = LastUpdatedDateTime.CurrentValue;
                LastUpdatedDateTime.ViewValue = FormatDateTime(LastUpdatedDateTime.ViewValue, LastUpdatedDateTime.FormatPattern);
                LastUpdatedDateTime.ViewCustomAttributes = "";

                // MTCrewID
                MTCrewID.HrefValue = "";
                MTCrewID.TooltipValue = "";

                // MTCertificateID
                MTCertificateID.HrefValue = "";
                MTCertificateID.TooltipValue = "";

                // CountryOfIssue_CountryID
                CountryOfIssue_CountryID.HrefValue = "";
                CountryOfIssue_CountryID.TooltipValue = "";

                // Number
                Number.HrefValue = "";
                Number.TooltipValue = "";

                // DateOfIssue
                DateOfIssue.HrefValue = "";
                DateOfIssue.TooltipValue = "";

                // DateOfExpiry
                DateOfExpiry.HrefValue = "";
                DateOfExpiry.TooltipValue = "";

                // PlaceOfIssue
                PlaceOfIssue.HrefValue = "";
                PlaceOfIssue.TooltipValue = "";

                // IssuingAuthority
                IssuingAuthority.HrefValue = "";
                IssuingAuthority.TooltipValue = "";

                // Level
                Level.HrefValue = "";
                Level.TooltipValue = "";

                // PaxVesselType
                PaxVesselType.HrefValue = "";
                PaxVesselType.TooltipValue = "";

                // Image
                Image.UploadPath = Image.GetUploadPath();
                if (!IsNull(Image.Upload.DbValue)) {
                    Image.HrefValue = ConvertToString(GetFileUploadUrl(Image, Image.HtmlDecode(ConvertToString(Image.Upload.DbValue)))); // Add prefix/suffix
                    Image.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Image.HrefValue = FullUrl(ConvertToString(Image.HrefValue), "href");
                } else {
                    Image.HrefValue = "";
                }
                Image.ExportHrefValue = Image.UploadPath + Image.Upload.DbValue;
                Image.TooltipValue = "";

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
            } else if (RowType == RowType.Add) {
                // MTCrewID
                MTCrewID.SetupEditAttributes();
                if (!Empty(MTCrewID.SessionValue)) {
                    MTCrewID.CurrentValue = ForeignKeyValue(MTCrewID.SessionValue);
                    MTCrewID.OldValue = MTCrewID.CurrentValue;
                    curVal = ConvertToString(MTCrewID.CurrentValue);
                    if (!Empty(curVal)) {
                        if (MTCrewID.Lookup != null && IsDictionary(MTCrewID.Lookup?.Options) && MTCrewID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                            MTCrewID.ViewValue = MTCrewID.LookupCacheOption(curVal);
                        } else { // Lookup from database // DN
                            filterWrk = SearchFilter("[ID]", "=", MTCrewID.CurrentValue, DataType.Number, "");
                            sqlWrk = MTCrewID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                            rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                            if (rswrk?.Count > 0 && MTCrewID.Lookup != null) { // Lookup values found
                                var listwrk = MTCrewID.Lookup?.RenderViewRow(rswrk[0]);
                                MTCrewID.ViewValue = MTCrewID.HighlightLookup(ConvertToString(rswrk[0]), MTCrewID.DisplayValue(listwrk));
                            } else {
                                MTCrewID.ViewValue = MTCrewID.CurrentValue;
                            }
                        }
                    } else {
                        MTCrewID.ViewValue = DbNullValue;
                    }
                    MTCrewID.ViewCustomAttributes = "";
                } else {
                    curVal = ConvertToString(MTCrewID.CurrentValue)?.Trim() ?? "";
                    if (MTCrewID.Lookup != null && IsDictionary(MTCrewID.Lookup?.Options) && MTCrewID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTCrewID.EditValue = MTCrewID.Lookup?.Options.Values.ToList();
                    } else { // Lookup from database
                        if (curVal == "") {
                            filterWrk = "0=1";
                        } else {
                            filterWrk = SearchFilter("[ID]", "=", MTCrewID.CurrentValue, DataType.Number, "");
                        }
                        sqlWrk = MTCrewID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        MTCrewID.EditValue = rswrk;
                    }
                    MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);
                }

                // MTCertificateID
                MTCertificateID.SetupEditAttributes();
                curVal = ConvertToString(MTCertificateID.CurrentValue)?.Trim() ?? "";
                if (MTCertificateID.Lookup != null && IsDictionary(MTCertificateID.Lookup?.Options) && MTCertificateID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTCertificateID.EditValue = MTCertificateID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTCertificateID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = MTCertificateID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTCertificateID.EditValue = rswrk;
                }
                MTCertificateID.PlaceHolder = RemoveHtml(MTCertificateID.Caption);
                if (!Empty(MTCertificateID.EditValue) && IsNumeric(MTCertificateID.EditValue))
                    MTCertificateID.EditValue = FormatNumber(MTCertificateID.EditValue, null);

                // CountryOfIssue_CountryID
                CountryOfIssue_CountryID.SetupEditAttributes();
                curVal = ConvertToString(CountryOfIssue_CountryID.CurrentValue)?.Trim() ?? "";
                if (CountryOfIssue_CountryID.Lookup != null && IsDictionary(CountryOfIssue_CountryID.Lookup?.Options) && CountryOfIssue_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CountryOfIssue_CountryID.EditValue = CountryOfIssue_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", CountryOfIssue_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = CountryOfIssue_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    CountryOfIssue_CountryID.EditValue = rswrk;
                }
                CountryOfIssue_CountryID.PlaceHolder = RemoveHtml(CountryOfIssue_CountryID.Caption);
                if (!Empty(CountryOfIssue_CountryID.EditValue) && IsNumeric(CountryOfIssue_CountryID.EditValue))
                    CountryOfIssue_CountryID.EditValue = FormatNumber(CountryOfIssue_CountryID.EditValue, null);

                // Number
                Number.SetupEditAttributes();
                if (!Number.Raw)
                    Number.CurrentValue = HtmlDecode(Number.CurrentValue);
                Number.EditValue = HtmlEncode(Number.CurrentValue);
                Number.PlaceHolder = RemoveHtml(Number.Caption);

                // DateOfIssue
                DateOfIssue.SetupEditAttributes();
                DateOfIssue.EditValue = FormatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern); // DN
                DateOfIssue.PlaceHolder = RemoveHtml(DateOfIssue.Caption);

                // DateOfExpiry
                DateOfExpiry.SetupEditAttributes();
                DateOfExpiry.EditValue = FormatDateTime(DateOfExpiry.CurrentValue, DateOfExpiry.FormatPattern); // DN
                DateOfExpiry.PlaceHolder = RemoveHtml(DateOfExpiry.Caption);

                // PlaceOfIssue
                PlaceOfIssue.SetupEditAttributes();
                if (!PlaceOfIssue.Raw)
                    PlaceOfIssue.CurrentValue = HtmlDecode(PlaceOfIssue.CurrentValue);
                PlaceOfIssue.EditValue = HtmlEncode(PlaceOfIssue.CurrentValue);
                PlaceOfIssue.PlaceHolder = RemoveHtml(PlaceOfIssue.Caption);

                // IssuingAuthority
                IssuingAuthority.SetupEditAttributes();
                if (!IssuingAuthority.Raw)
                    IssuingAuthority.CurrentValue = HtmlDecode(IssuingAuthority.CurrentValue);
                IssuingAuthority.EditValue = HtmlEncode(IssuingAuthority.CurrentValue);
                IssuingAuthority.PlaceHolder = RemoveHtml(IssuingAuthority.Caption);

                // Level
                Level.SetupEditAttributes();
                if (!Level.Raw)
                    Level.CurrentValue = HtmlDecode(Level.CurrentValue);
                Level.EditValue = HtmlEncode(Level.CurrentValue);
                Level.PlaceHolder = RemoveHtml(Level.Caption);

                // PaxVesselType
                PaxVesselType.SetupEditAttributes();
                if (!PaxVesselType.Raw)
                    PaxVesselType.CurrentValue = HtmlDecode(PaxVesselType.CurrentValue);
                PaxVesselType.EditValue = HtmlEncode(PaxVesselType.CurrentValue);
                PaxVesselType.PlaceHolder = RemoveHtml(PaxVesselType.Caption);

                // Image
                Image.SetupEditAttributes();
                Image.EditAttrs["accept"] = "jpg,jpeg.gif,png";
                Image.UploadPath = Image.GetUploadPath();
                if (!IsNull(Image.Upload.DbValue)) {
                    Image.ImageWidth = 200;
                    Image.ImageHeight = 200;
                    Image.ImageAlt = Image.Alt;
                    Image.ImageCssClass = "ew-image";
                    Image.EditValue = Image.Upload.DbValue;
                } else {
                    Image.EditValue = "";
                }
                if (!Empty(Image.CurrentValue))
                        if (SameString(RowIndex, "$rowindex$"))
                            Image.Upload.FileName = "";
                        else
                            Image.Upload.FileName = ConvertToString(Image.CurrentValue);
                if (IsNumeric(RowIndex) && !EventCancelled)
                    await RenderUploadField(Image, ConvertToInt(RowIndex));

                // CreatedByUserID
                CreatedByUserID.SetupEditAttributes();
                curVal = ConvertToString(CreatedByUserID.CurrentValue)?.Trim() ?? "";
                if (CreatedByUserID.Lookup != null && IsDictionary(CreatedByUserID.Lookup?.Options) && CreatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CreatedByUserID.EditValue = CreatedByUserID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", CreatedByUserID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = CreatedByUserID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    CreatedByUserID.EditValue = rswrk;
                }
                CreatedByUserID.PlaceHolder = RemoveHtml(CreatedByUserID.Caption);
                if (!Empty(CreatedByUserID.EditValue) && IsNumeric(CreatedByUserID.EditValue))
                    CreatedByUserID.EditValue = FormatNumber(CreatedByUserID.EditValue, null);

                // CreatedDateTime
                CreatedDateTime.SetupEditAttributes();
                CreatedDateTime.EditValue = FormatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern); // DN
                CreatedDateTime.PlaceHolder = RemoveHtml(CreatedDateTime.Caption);

                // LastUpdatedByUserID
                LastUpdatedByUserID.SetupEditAttributes();
                curVal = ConvertToString(LastUpdatedByUserID.CurrentValue)?.Trim() ?? "";
                if (LastUpdatedByUserID.Lookup != null && IsDictionary(LastUpdatedByUserID.Lookup?.Options) && LastUpdatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    LastUpdatedByUserID.EditValue = LastUpdatedByUserID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", LastUpdatedByUserID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = LastUpdatedByUserID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    LastUpdatedByUserID.EditValue = rswrk;
                }
                LastUpdatedByUserID.PlaceHolder = RemoveHtml(LastUpdatedByUserID.Caption);
                if (!Empty(LastUpdatedByUserID.EditValue) && IsNumeric(LastUpdatedByUserID.EditValue))
                    LastUpdatedByUserID.EditValue = FormatNumber(LastUpdatedByUserID.EditValue, null);

                // LastUpdatedDateTime
                LastUpdatedDateTime.SetupEditAttributes();
                LastUpdatedDateTime.EditValue = FormatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern); // DN
                LastUpdatedDateTime.PlaceHolder = RemoveHtml(LastUpdatedDateTime.Caption);

                // Add refer script

                // MTCrewID
                MTCrewID.HrefValue = "";

                // MTCertificateID
                MTCertificateID.HrefValue = "";

                // CountryOfIssue_CountryID
                CountryOfIssue_CountryID.HrefValue = "";

                // Number
                Number.HrefValue = "";

                // DateOfIssue
                DateOfIssue.HrefValue = "";

                // DateOfExpiry
                DateOfExpiry.HrefValue = "";

                // PlaceOfIssue
                PlaceOfIssue.HrefValue = "";

                // IssuingAuthority
                IssuingAuthority.HrefValue = "";

                // Level
                Level.HrefValue = "";

                // PaxVesselType
                PaxVesselType.HrefValue = "";

                // Image
                Image.UploadPath = Image.GetUploadPath();
                if (!IsNull(Image.Upload.DbValue)) {
                    Image.HrefValue = ConvertToString(GetFileUploadUrl(Image, Image.HtmlDecode(ConvertToString(Image.Upload.DbValue)))); // Add prefix/suffix
                    Image.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Image.HrefValue = FullUrl(ConvertToString(Image.HrefValue), "href");
                } else {
                    Image.HrefValue = "";
                }
                Image.ExportHrefValue = Image.UploadPath + Image.Upload.DbValue;

                // CreatedByUserID
                CreatedByUserID.HrefValue = "";

                // CreatedDateTime
                CreatedDateTime.HrefValue = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.HrefValue = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // MTCrewID
                MTCrewID.SetupEditAttributes();
                if (!Empty(MTCrewID.SessionValue)) {
                    MTCrewID.CurrentValue = ForeignKeyValue(MTCrewID.SessionValue);
                    MTCrewID.OldValue = MTCrewID.CurrentValue;
                    curVal = ConvertToString(MTCrewID.CurrentValue);
                    if (!Empty(curVal)) {
                        if (MTCrewID.Lookup != null && IsDictionary(MTCrewID.Lookup?.Options) && MTCrewID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                            MTCrewID.ViewValue = MTCrewID.LookupCacheOption(curVal);
                        } else { // Lookup from database // DN
                            filterWrk = SearchFilter("[ID]", "=", MTCrewID.CurrentValue, DataType.Number, "");
                            sqlWrk = MTCrewID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                            rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                            if (rswrk?.Count > 0 && MTCrewID.Lookup != null) { // Lookup values found
                                var listwrk = MTCrewID.Lookup?.RenderViewRow(rswrk[0]);
                                MTCrewID.ViewValue = MTCrewID.HighlightLookup(ConvertToString(rswrk[0]), MTCrewID.DisplayValue(listwrk));
                            } else {
                                MTCrewID.ViewValue = MTCrewID.CurrentValue;
                            }
                        }
                    } else {
                        MTCrewID.ViewValue = DbNullValue;
                    }
                    MTCrewID.ViewCustomAttributes = "";
                } else {
                    curVal = ConvertToString(MTCrewID.CurrentValue)?.Trim() ?? "";
                    if (MTCrewID.Lookup != null && IsDictionary(MTCrewID.Lookup?.Options) && MTCrewID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTCrewID.EditValue = MTCrewID.Lookup?.Options.Values.ToList();
                    } else { // Lookup from database
                        if (curVal == "") {
                            filterWrk = "0=1";
                        } else {
                            filterWrk = SearchFilter("[ID]", "=", MTCrewID.CurrentValue, DataType.Number, "");
                        }
                        sqlWrk = MTCrewID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        MTCrewID.EditValue = rswrk;
                    }
                    MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);
                }

                // MTCertificateID
                MTCertificateID.SetupEditAttributes();
                curVal = ConvertToString(MTCertificateID.CurrentValue)?.Trim() ?? "";
                if (MTCertificateID.Lookup != null && IsDictionary(MTCertificateID.Lookup?.Options) && MTCertificateID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTCertificateID.EditValue = MTCertificateID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTCertificateID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = MTCertificateID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTCertificateID.EditValue = rswrk;
                }
                MTCertificateID.PlaceHolder = RemoveHtml(MTCertificateID.Caption);
                if (!Empty(MTCertificateID.EditValue) && IsNumeric(MTCertificateID.EditValue))
                    MTCertificateID.EditValue = FormatNumber(MTCertificateID.EditValue, null);

                // CountryOfIssue_CountryID
                CountryOfIssue_CountryID.SetupEditAttributes();
                curVal = ConvertToString(CountryOfIssue_CountryID.CurrentValue)?.Trim() ?? "";
                if (CountryOfIssue_CountryID.Lookup != null && IsDictionary(CountryOfIssue_CountryID.Lookup?.Options) && CountryOfIssue_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CountryOfIssue_CountryID.EditValue = CountryOfIssue_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", CountryOfIssue_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = CountryOfIssue_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    CountryOfIssue_CountryID.EditValue = rswrk;
                }
                CountryOfIssue_CountryID.PlaceHolder = RemoveHtml(CountryOfIssue_CountryID.Caption);
                if (!Empty(CountryOfIssue_CountryID.EditValue) && IsNumeric(CountryOfIssue_CountryID.EditValue))
                    CountryOfIssue_CountryID.EditValue = FormatNumber(CountryOfIssue_CountryID.EditValue, null);

                // Number
                Number.SetupEditAttributes();
                if (!Number.Raw)
                    Number.CurrentValue = HtmlDecode(Number.CurrentValue);
                Number.EditValue = HtmlEncode(Number.CurrentValue);
                Number.PlaceHolder = RemoveHtml(Number.Caption);

                // DateOfIssue
                DateOfIssue.SetupEditAttributes();
                DateOfIssue.EditValue = FormatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern); // DN
                DateOfIssue.PlaceHolder = RemoveHtml(DateOfIssue.Caption);

                // DateOfExpiry
                DateOfExpiry.SetupEditAttributes();
                DateOfExpiry.EditValue = FormatDateTime(DateOfExpiry.CurrentValue, DateOfExpiry.FormatPattern); // DN
                DateOfExpiry.PlaceHolder = RemoveHtml(DateOfExpiry.Caption);

                // PlaceOfIssue
                PlaceOfIssue.SetupEditAttributes();
                if (!PlaceOfIssue.Raw)
                    PlaceOfIssue.CurrentValue = HtmlDecode(PlaceOfIssue.CurrentValue);
                PlaceOfIssue.EditValue = HtmlEncode(PlaceOfIssue.CurrentValue);
                PlaceOfIssue.PlaceHolder = RemoveHtml(PlaceOfIssue.Caption);

                // IssuingAuthority
                IssuingAuthority.SetupEditAttributes();
                if (!IssuingAuthority.Raw)
                    IssuingAuthority.CurrentValue = HtmlDecode(IssuingAuthority.CurrentValue);
                IssuingAuthority.EditValue = HtmlEncode(IssuingAuthority.CurrentValue);
                IssuingAuthority.PlaceHolder = RemoveHtml(IssuingAuthority.Caption);

                // Level
                Level.SetupEditAttributes();
                if (!Level.Raw)
                    Level.CurrentValue = HtmlDecode(Level.CurrentValue);
                Level.EditValue = HtmlEncode(Level.CurrentValue);
                Level.PlaceHolder = RemoveHtml(Level.Caption);

                // PaxVesselType
                PaxVesselType.SetupEditAttributes();
                if (!PaxVesselType.Raw)
                    PaxVesselType.CurrentValue = HtmlDecode(PaxVesselType.CurrentValue);
                PaxVesselType.EditValue = HtmlEncode(PaxVesselType.CurrentValue);
                PaxVesselType.PlaceHolder = RemoveHtml(PaxVesselType.Caption);

                // Image
                Image.SetupEditAttributes();
                Image.EditAttrs["accept"] = "jpg,jpeg.gif,png";
                Image.UploadPath = Image.GetUploadPath();
                if (!IsNull(Image.Upload.DbValue)) {
                    Image.ImageWidth = 200;
                    Image.ImageHeight = 200;
                    Image.ImageAlt = Image.Alt;
                    Image.ImageCssClass = "ew-image";
                    Image.EditValue = Image.Upload.DbValue;
                } else {
                    Image.EditValue = "";
                }
                if (!Empty(Image.CurrentValue))
                        if (SameString(RowIndex, "$rowindex$"))
                            Image.Upload.FileName = "";
                        else
                            Image.Upload.FileName = ConvertToString(Image.CurrentValue);
                if (IsNumeric(RowIndex) && !EventCancelled)
                    await RenderUploadField(Image, ConvertToInt(RowIndex));

                // CreatedByUserID
                CreatedByUserID.SetupEditAttributes();
                curVal = ConvertToString(CreatedByUserID.CurrentValue)?.Trim() ?? "";
                if (CreatedByUserID.Lookup != null && IsDictionary(CreatedByUserID.Lookup?.Options) && CreatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CreatedByUserID.EditValue = CreatedByUserID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", CreatedByUserID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = CreatedByUserID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    CreatedByUserID.EditValue = rswrk;
                }
                CreatedByUserID.PlaceHolder = RemoveHtml(CreatedByUserID.Caption);
                if (!Empty(CreatedByUserID.EditValue) && IsNumeric(CreatedByUserID.EditValue))
                    CreatedByUserID.EditValue = FormatNumber(CreatedByUserID.EditValue, null);

                // CreatedDateTime
                CreatedDateTime.SetupEditAttributes();
                CreatedDateTime.EditValue = FormatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern); // DN
                CreatedDateTime.PlaceHolder = RemoveHtml(CreatedDateTime.Caption);

                // LastUpdatedByUserID
                LastUpdatedByUserID.SetupEditAttributes();
                curVal = ConvertToString(LastUpdatedByUserID.CurrentValue)?.Trim() ?? "";
                if (LastUpdatedByUserID.Lookup != null && IsDictionary(LastUpdatedByUserID.Lookup?.Options) && LastUpdatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    LastUpdatedByUserID.EditValue = LastUpdatedByUserID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", LastUpdatedByUserID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = LastUpdatedByUserID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    LastUpdatedByUserID.EditValue = rswrk;
                }
                LastUpdatedByUserID.PlaceHolder = RemoveHtml(LastUpdatedByUserID.Caption);
                if (!Empty(LastUpdatedByUserID.EditValue) && IsNumeric(LastUpdatedByUserID.EditValue))
                    LastUpdatedByUserID.EditValue = FormatNumber(LastUpdatedByUserID.EditValue, null);

                // LastUpdatedDateTime
                LastUpdatedDateTime.SetupEditAttributes();
                LastUpdatedDateTime.EditValue = FormatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern); // DN
                LastUpdatedDateTime.PlaceHolder = RemoveHtml(LastUpdatedDateTime.Caption);

                // Edit refer script

                // MTCrewID
                MTCrewID.HrefValue = "";

                // MTCertificateID
                MTCertificateID.HrefValue = "";

                // CountryOfIssue_CountryID
                CountryOfIssue_CountryID.HrefValue = "";

                // Number
                Number.HrefValue = "";

                // DateOfIssue
                DateOfIssue.HrefValue = "";

                // DateOfExpiry
                DateOfExpiry.HrefValue = "";

                // PlaceOfIssue
                PlaceOfIssue.HrefValue = "";

                // IssuingAuthority
                IssuingAuthority.HrefValue = "";

                // Level
                Level.HrefValue = "";

                // PaxVesselType
                PaxVesselType.HrefValue = "";

                // Image
                Image.UploadPath = Image.GetUploadPath();
                if (!IsNull(Image.Upload.DbValue)) {
                    Image.HrefValue = ConvertToString(GetFileUploadUrl(Image, Image.HtmlDecode(ConvertToString(Image.Upload.DbValue)))); // Add prefix/suffix
                    Image.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Image.HrefValue = FullUrl(ConvertToString(Image.HrefValue), "href");
                } else {
                    Image.HrefValue = "";
                }
                Image.ExportHrefValue = Image.UploadPath + Image.Upload.DbValue;

                // CreatedByUserID
                CreatedByUserID.HrefValue = "";

                // CreatedDateTime
                CreatedDateTime.HrefValue = "";

                // LastUpdatedByUserID
                LastUpdatedByUserID.HrefValue = "";

                // LastUpdatedDateTime
                LastUpdatedDateTime.HrefValue = "";
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
            if (MTCertificateID.Required) {
                if (!MTCertificateID.IsDetailKey && Empty(MTCertificateID.FormValue)) {
                    MTCertificateID.AddErrorMessage(ConvertToString(MTCertificateID.RequiredErrorMessage).Replace("%s", MTCertificateID.Caption));
                }
            }
            if (CountryOfIssue_CountryID.Required) {
                if (!CountryOfIssue_CountryID.IsDetailKey && Empty(CountryOfIssue_CountryID.FormValue)) {
                    CountryOfIssue_CountryID.AddErrorMessage(ConvertToString(CountryOfIssue_CountryID.RequiredErrorMessage).Replace("%s", CountryOfIssue_CountryID.Caption));
                }
            }
            if (Number.Required) {
                if (!Number.IsDetailKey && Empty(Number.FormValue)) {
                    Number.AddErrorMessage(ConvertToString(Number.RequiredErrorMessage).Replace("%s", Number.Caption));
                }
            }
            if (DateOfIssue.Required) {
                if (!DateOfIssue.IsDetailKey && Empty(DateOfIssue.FormValue)) {
                    DateOfIssue.AddErrorMessage(ConvertToString(DateOfIssue.RequiredErrorMessage).Replace("%s", DateOfIssue.Caption));
                }
            }
            if (!CheckDate(DateOfIssue.FormValue, DateOfIssue.FormatPattern)) {
                DateOfIssue.AddErrorMessage(DateOfIssue.GetErrorMessage(false));
            }
            if (DateOfExpiry.Required) {
                if (!DateOfExpiry.IsDetailKey && Empty(DateOfExpiry.FormValue)) {
                    DateOfExpiry.AddErrorMessage(ConvertToString(DateOfExpiry.RequiredErrorMessage).Replace("%s", DateOfExpiry.Caption));
                }
            }
            if (!CheckDate(DateOfExpiry.FormValue, DateOfExpiry.FormatPattern)) {
                DateOfExpiry.AddErrorMessage(DateOfExpiry.GetErrorMessage(false));
            }
            if (PlaceOfIssue.Required) {
                if (!PlaceOfIssue.IsDetailKey && Empty(PlaceOfIssue.FormValue)) {
                    PlaceOfIssue.AddErrorMessage(ConvertToString(PlaceOfIssue.RequiredErrorMessage).Replace("%s", PlaceOfIssue.Caption));
                }
            }
            if (IssuingAuthority.Required) {
                if (!IssuingAuthority.IsDetailKey && Empty(IssuingAuthority.FormValue)) {
                    IssuingAuthority.AddErrorMessage(ConvertToString(IssuingAuthority.RequiredErrorMessage).Replace("%s", IssuingAuthority.Caption));
                }
            }
            if (Level.Required) {
                if (!Level.IsDetailKey && Empty(Level.FormValue)) {
                    Level.AddErrorMessage(ConvertToString(Level.RequiredErrorMessage).Replace("%s", Level.Caption));
                }
            }
            if (PaxVesselType.Required) {
                if (!PaxVesselType.IsDetailKey && Empty(PaxVesselType.FormValue)) {
                    PaxVesselType.AddErrorMessage(ConvertToString(PaxVesselType.RequiredErrorMessage).Replace("%s", PaxVesselType.Caption));
                }
            }
            if (Image.Required) {
                if (Image.Upload.FileName == "" && !Image.Upload.KeepFile) {
                    Image.AddErrorMessage(ConvertToString(Image.RequiredErrorMessage).Replace("%s", Image.Caption));
                }
            }
            if (CreatedByUserID.Required) {
                if (!CreatedByUserID.IsDetailKey && Empty(CreatedByUserID.FormValue)) {
                    CreatedByUserID.AddErrorMessage(ConvertToString(CreatedByUserID.RequiredErrorMessage).Replace("%s", CreatedByUserID.Caption));
                }
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
            if (LastUpdatedDateTime.Required) {
                if (!LastUpdatedDateTime.IsDetailKey && Empty(LastUpdatedDateTime.FormValue)) {
                    LastUpdatedDateTime.AddErrorMessage(ConvertToString(LastUpdatedDateTime.RequiredErrorMessage).Replace("%s", LastUpdatedDateTime.Caption));
                }
            }
            if (!CheckDate(LastUpdatedDateTime.FormValue, LastUpdatedDateTime.FormatPattern)) {
                LastUpdatedDateTime.AddErrorMessage(LastUpdatedDateTime.GetErrorMessage(false));
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

        // Delete records (based on current filter)
        protected async Task<JsonBoolResult> DeleteRows() { // DN
            if (!Security.CanDelete) {
                FailureMessage = Language.Phrase("NoDeletePermission"); // No delete permission
                return JsonBoolResult.FalseResult; // No delete permission
            }
            List<Dictionary<string, object>>? rsold = null;
            bool result = true;
            try {
                string sql = CurrentSql;
                using var rs = await Connection.GetDataReaderAsync(sql);
                if (rs == null) {
                    return JsonBoolResult.FalseResult;
                } else if (!rs.HasRows) {
                    FailureMessage = Language.Phrase("NoRecord"); // No record found
                    return JsonBoolResult.FalseResult;
                } else { // Clone old rows
                    rsold = await Connection.GetRowsAsync(rs);
                }
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }
            List<string> successKeys = new (), failKeys = new ();
            try {
                // Call Row Deleting event
                if (result)
                    result = rsold.All(row => RowDeleting(row));
                if (result) {
                    foreach (var row in rsold) {
                        try {
                            result = await DeleteAsync(row) > 0;
                        } catch (Exception e) {
                            if (Config.Debug)
                                throw;
                            FailureMessage = e.Message; // Set up error message
                            result = false;
                        }
                        if (!result) {
                            if (UseTransaction) {
                                successKeys.Clear();
                                break;
                            }
                            failKeys.Add(GetKey(row)); // DN
                        } else {
                            if (Config.DeleteUploadFiles)
                                DeleteUploadedFiles(row);
                            RowDeleted(row);
                            successKeys.Add(GetKey(row)); // DN
                        }
                    }
                }
                result = successKeys.Count > 0;
                if (!result) {
                    // Set up error message
                    if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {
                        // Use the message, do nothing
                    } else if (!Empty(CancelMessage)) {
                        FailureMessage = CancelMessage;
                        CancelMessage = "";
                    } else {
                        FailureMessage = Language.Phrase("DeleteCancelled");
                    }
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                result = false;
            }

            // Write JSON for API request
            Dictionary<string, object> d = new ();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                var rows = await GetRecordsFromRecordset(rsold);
                string table = TableVar;
                d.Add(table, RouteValues.Count > 2 && rows.Count == 1 ? rows[0] : rows); // If single-delete, route values are controller/action/id (count > 2)
                d.Add("action", Config.ApiDeleteAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, true);
            }
            return new JsonBoolResult(d, result);
        }

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
                Image.OldUploadPath = Image.GetUploadPath();
                Image.UploadPath = Image.OldUploadPath;
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }

            // Set new row
            Dictionary<string, object> rsnew = new ();

            // MTCrewID
            if (!Empty(MTCrewID.SessionValue))
                MTCrewID.ReadOnly = true;
            MTCrewID.SetDbValue(rsnew, MTCrewID.CurrentValue, MTCrewID.ReadOnly);

            // MTCertificateID
            MTCertificateID.SetDbValue(rsnew, MTCertificateID.CurrentValue, MTCertificateID.ReadOnly);

            // CountryOfIssue_CountryID
            CountryOfIssue_CountryID.SetDbValue(rsnew, CountryOfIssue_CountryID.CurrentValue, CountryOfIssue_CountryID.ReadOnly);

            // Number
            Number.SetDbValue(rsnew, Number.CurrentValue, Number.ReadOnly);

            // DateOfIssue
            DateOfIssue.SetDbValue(rsnew, ConvertToDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern), DateOfIssue.ReadOnly);

            // DateOfExpiry
            DateOfExpiry.SetDbValue(rsnew, ConvertToDateTime(DateOfExpiry.CurrentValue, DateOfExpiry.FormatPattern), DateOfExpiry.ReadOnly);

            // PlaceOfIssue
            PlaceOfIssue.SetDbValue(rsnew, PlaceOfIssue.CurrentValue, PlaceOfIssue.ReadOnly);

            // IssuingAuthority
            IssuingAuthority.SetDbValue(rsnew, IssuingAuthority.CurrentValue, IssuingAuthority.ReadOnly);

            // Level
            Level.SetDbValue(rsnew, Level.CurrentValue, Level.ReadOnly);

            // PaxVesselType
            PaxVesselType.SetDbValue(rsnew, PaxVesselType.CurrentValue, PaxVesselType.ReadOnly);

            // Image
            if (Image.Visible && !Image.ReadOnly && !Image.Upload.KeepFile) {
                Image.Upload.DbValue = rsold["Image"]; // Get original value
                if (Empty(Image.Upload.FileName)) {
                    rsnew["Image"] = DbNullValue;
                } else {
                    rsnew["Image"] = Image.Upload.FileName;
                }
            }

            // CreatedByUserID
            CreatedByUserID.SetDbValue(rsnew, CreatedByUserID.CurrentValue, CreatedByUserID.ReadOnly);

            // CreatedDateTime
            CreatedDateTime.SetDbValue(rsnew, ConvertToDateTimeOffset(CreatedDateTime.CurrentValue, DateTimeStyles.AssumeUniversal), CreatedDateTime.ReadOnly);

            // LastUpdatedByUserID
            LastUpdatedByUserID.SetDbValue(rsnew, LastUpdatedByUserID.CurrentValue, LastUpdatedByUserID.ReadOnly);

            // LastUpdatedDateTime
            LastUpdatedDateTime.SetDbValue(rsnew, ConvertToDateTimeOffset(LastUpdatedDateTime.CurrentValue, DateTimeStyles.AssumeUniversal), LastUpdatedDateTime.ReadOnly);

            // Update current values
            SetCurrentValues(rsnew);
            bool validMasterRecord;
            object keyValue;
            object? v;
            string? masterFilter;
            Dictionary<string, object?> detailKeys;
            if (Image.Visible && !Image.Upload.KeepFile) {
                Image.UploadPath = Image.GetUploadPath();
                List<string> oldFiles = Empty(Image.Upload.DbValue) ? new () : new () { Image.HtmlDecode(Image.Upload.DbValue) };
                if (!Empty(Image.Upload.FileName)) {
                    var newFiles = new string[] { Image.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(Image, Image.Upload.Index);
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
                                var folders = new[] { Image.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(Image.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(Image.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    Image.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    Image.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    Image.SetDbValue(rsnew, Image.Upload.FileName, Image.ReadOnly);
                }
            }

            // Call Row Updating event
            bool updateRow = RowUpdating(rsold, rsnew);
            if (updateRow) {
                try {
                    if (rsnew.Count > 0)
                        result = await UpdateAsync(rsnew, null, rsold) > 0;
                    else
                        result = true;
                    if (result) {
                        if (Image.Visible && !Image.Upload.KeepFile) {
                            var newFiles = new string[] {};
                            var oldFiles = Empty(Image.Upload.DbValue) ? new string[] {} : new string[] { Image.HtmlDecode(Image.Upload.DbValue) };
                            if (!Empty(Image.Upload.FileName)) {
                                newFiles = new string[] { Image.Upload.FileName };
                                var newFiles2 = new string[] { Image.HtmlDecode(ConvertToString(rsnew["Image"])) };
                                for (var i = 0; i < newFiles.Length; i++) {
                                    if (!Empty(newFiles[i])) {
                                        var file = UploadTempPath(Image, Image.Upload.Index) + newFiles[i];
                                        if (FileExists(file)) {
                                            if (!Empty(newFiles2[i])) // Use correct file name
                                                newFiles[i] = newFiles2[i];
                                            if (!await Image.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                        DeleteFile(Image.OldPhysicalUploadPath + oldFiles[i]);
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

        // Add record
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> AddRow(Dictionary<string, object>? rsold = null) { // DN
            bool result = false;

            // Set up foreign key field value from Session
            if (CurrentMasterTable == "MTCrew") {
                MTCrewID.CurrentValue = MTCrewID.SessionValue;
            }

            // Set new row
            Dictionary<string, object> rsnew = new ();
            try {
                // MTCrewID
                MTCrewID.SetDbValue(rsnew, MTCrewID.CurrentValue);

                // MTCertificateID
                MTCertificateID.SetDbValue(rsnew, MTCertificateID.CurrentValue);

                // CountryOfIssue_CountryID
                CountryOfIssue_CountryID.SetDbValue(rsnew, CountryOfIssue_CountryID.CurrentValue);

                // Number
                Number.SetDbValue(rsnew, Number.CurrentValue);

                // DateOfIssue
                DateOfIssue.SetDbValue(rsnew, ConvertToDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern));

                // DateOfExpiry
                DateOfExpiry.SetDbValue(rsnew, ConvertToDateTime(DateOfExpiry.CurrentValue, DateOfExpiry.FormatPattern));

                // PlaceOfIssue
                PlaceOfIssue.SetDbValue(rsnew, PlaceOfIssue.CurrentValue);

                // IssuingAuthority
                IssuingAuthority.SetDbValue(rsnew, IssuingAuthority.CurrentValue);

                // Level
                Level.SetDbValue(rsnew, Level.CurrentValue);

                // PaxVesselType
                PaxVesselType.SetDbValue(rsnew, PaxVesselType.CurrentValue);

                // Image
                if (Image.Visible && !Image.Upload.KeepFile) {
                    Image.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(Image.Upload.FileName)) {
                        rsnew["Image"] = DbNullValue;
                    } else {
                        rsnew["Image"] = Image.Upload.FileName;
                    }
                }

                // CreatedByUserID
                CreatedByUserID.SetDbValue(rsnew, CreatedByUserID.CurrentValue);

                // CreatedDateTime
                CreatedDateTime.SetDbValue(rsnew, ConvertToDateTimeOffset(CreatedDateTime.CurrentValue, DateTimeStyles.AssumeUniversal));

                // LastUpdatedByUserID
                LastUpdatedByUserID.SetDbValue(rsnew, LastUpdatedByUserID.CurrentValue);

                // LastUpdatedDateTime
                LastUpdatedDateTime.SetDbValue(rsnew, ConvertToDateTimeOffset(LastUpdatedDateTime.CurrentValue, DateTimeStyles.AssumeUniversal));

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
            if (Image.Visible && !Image.Upload.KeepFile) {
                Image.UploadPath = Image.GetUploadPath();
                List<string> oldFiles = Empty(Image.Upload.DbValue) ? new () : new () { Image.HtmlDecode(Image.Upload.DbValue) };
                if (!Empty(Image.Upload.FileName)) {
                    var newFiles = new string[] { Image.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(Image, Image.Upload.Index);
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
                                var folders = new[] { Image.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(Image.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(Image.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    Image.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    Image.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    Image.SetDbValue(rsnew, Image.Upload.FileName);
                }
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
            string? masterFilter;
            Dictionary<string, object?> detailKeys;
            bool validMasterRecord;

            // Load db values from rsold
            LoadDbValues(rsold);
            if (rsold != null) {
                Image.OldUploadPath = Image.GetUploadPath();
                Image.UploadPath = Image.OldUploadPath;
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
                    if (Image.Visible && !Image.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(Image.Upload.DbValue) ? new string[] {} : new string[] { Image.HtmlDecode(Image.Upload.DbValue) };
                        if (!Empty(Image.Upload.FileName)) {
                            newFiles = new string[] { Image.Upload.FileName };
                            var newFiles2 = new string[] { Image.HtmlDecode(ConvertToString(rsnew["Image"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(Image, Image.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await Image.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(Image.OldPhysicalUploadPath + oldFiles[i]);
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

        // Set up master/detail based on QueryString
        protected void SetupMasterParms() {
            // Hide foreign keys
            string masterTblVar = CurrentMasterTable;
            if (masterTblVar == "MTCrew") {
                MTCrewID.Visible = false;

                //if (mtCrew.EventCancelled) EventCancelled = true;
                if (Get<bool>("mastereventcancelled"))
                    EventCancelled = true;
            }
            DbMasterFilter = MasterFilterFromSession; // Get master filter from session
            DbDetailFilter = DetailFilterFromSession; // Get detail filter from session
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
