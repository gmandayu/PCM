namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mtCrewCertificatePreview
    /// </summary>
    public static MtCrewCertificatePreview mtCrewCertificatePreview
    {
        get => HttpData.Get<MtCrewCertificatePreview>("mtCrewCertificatePreview")!;
        set => HttpData["mtCrewCertificatePreview"] = value;
    }

    /// <summary>
    /// Page class for MTCrewCertificate
    /// </summary>
    public class MtCrewCertificatePreview : MtCrewCertificatePreviewBase
    {
        // Constructor
        public MtCrewCertificatePreview(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MtCrewCertificatePreview() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MtCrewCertificatePreviewBase : MtCrewCertificate
    {
        // Page ID
        public string PageID = "preview";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "MTCrewCertificate";

        // Page object name
        public string PageObjName = "mtCrewCertificatePreview";

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
        public MtCrewCertificatePreviewBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table ew-preview-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (mtCrewCertificate)
            if (mtCrewCertificate == null || mtCrewCertificate is MtCrewCertificate)
                mtCrewCertificate = this;

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
        public string PageName => "MtCrewCertificatePreview";

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

        // Constructor
        public MtCrewCertificatePreviewBase(Controller? controller = null): this() { // DN
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

            // Properties
            public DbDataReader? Recordset = null;

            public int TotalRecords = 0;

            public int RecordCount = 0;

            public Pager? _pager;

            public int StartRecord = 1;

            public int DisplayRecords = 0;

            public bool UseModalLinks = false;

            public string PreviewUrl = ""; // DN

            // Pager
            public Pager Pager
            {
                get {
                    _pager ??= new PrevNextPager(this, StartRecord, DisplayRecords, TotalRecords, usePageSizeSelector: false, url: PreviewUrl, isModal: true);
                    return _pager;
                }
            }

            /// <summary>
            /// Page run
            /// </summary>
            /// <returns>Page result</returns>
            public override async Task<IActionResult> Run()
            {
            // Use layout
            if (!Empty(Param("layout")) && !Param<bool>("layout"))
                UseLayout = false;

            // User profile
            Profile = ResolveProfile();

            // Security
            Security = ResolveSecurity();
            if (TableVar != "")
                Security.LoadTablePermissions(TableVar);
            CurrentAction = Param("action"); // Set up current action

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

            // Setup other options
            SetupOtherOptions();

            // Set up lookup cache
            await SetupLookupOptions(MTCrewID);
            await SetupLookupOptions(MTCertificateID);
            await SetupLookupOptions(CountryOfIssue_CountryID);
            await SetupLookupOptions(CreatedByUserID);
            await SetupLookupOptions(LastUpdatedByUserID);

                // Load filter
                string filter = Get("f");
                filter = Decrypt(filter);
                if (Empty(filter))
                    filter = "0=1";

                // Preview URL // DN
                PreviewUrl = AppPath(CurrentPageName() + "?t=" + Get("t") + "&f=" + Get("f")); // Add table/filter parameters only

                // Set up sort order
                SetupSortOrder();

                // Set up foreign keys from filter
                SetupForeignKeysFromFilter(filter);

                // Call Recordset Selecting event
                RecordsetSelecting(ref filter);

                // Load recordset
                filter = ApplyUserIDFilters(filter);
                TotalRecords = await LoadRecordCountAsync(filter);
                string defaultSort = ""; // Default sort // DN
                string sql = PreviewSql(filter);
                if (DisplayRecords > 0)
                    Recordset = await Connection.SelectLimit(sql, DisplayRecords, StartRecord - 1, !Empty(CurrentOrder) || !Empty(SessionOrderBy) || !Empty(defaultSort));
                Recordset ??= await Connection.GetDataReaderAsync(sql);
                if (Recordset != null && await Recordset.ReadAsync()) {
                    // Call Recordset Selected event
                    RecordsetSelected(Recordset);
                    LoadListRowValues(Recordset);
                }
                RenderOtherOptions();

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();

                // Page Render event
                mtCrewCertificatePreview?.PageRender();
            }
                return PageResult();
            }

            // Set up sort order
            public void SetupSortOrder()
            {
                string defaultSort = ""; // Set up default sort
                if (Empty(SessionOrderBy) && !Empty(defaultSort))
                    SessionOrderBy = defaultSort;

                // Check for Ctrl pressed
                bool ctrl = Get<bool>("ctrl");
                if (SameText(Get("cmd"), "resetsort")) {
                    StartRecord = 1;
                    CurrentOrder = "";
                    CurrentOrderType = "";
                    ID.Sort = "";
                    MTCrewID.Sort = "";
                    MTCertificateID.Sort = "";
                    CountryOfIssue_CountryID.Sort = "";
                    Number.Sort = "";
                    DateOfIssue.Sort = "";
                    DateOfExpiry.Sort = "";
                    PlaceOfIssue.Sort = "";
                    IssuingAuthority.Sort = "";
                    Level.Sort = "";
                    PaxVesselType.Sort = "";
                    Image.Sort = "";
                    ActiveDescription.Sort = "";
                    CreatedByUserID.Sort = "";
                    CreatedDateTime.Sort = "";
                    LastUpdatedByUserID.Sort = "";
                    LastUpdatedDateTime.Sort = "";
                    MTUserID.Sort = "";

                    // Save sort to session
                    SessionOrderBy = "";
                } else {
                    StartRecord = Math.Max(Get<int>("start"), 1);
                    StartRecord = 1;
                    int pageNo = ConvertToInt(Get(Config.TablePageNumber));
                    int startRec = ConvertToInt(Get(Config.TableStartRec));
                    if (pageNo > 0) // Check for page parameter
                        StartRecord = (pageNo - 1) * DisplayRecords + 1;
                    else if (startRec > 0) // Check for "start" parameter
                        StartRecord = startRec;
                    CurrentOrder = Get("sort");
                    CurrentOrderType = Get("sortorder");
                }

                // Check for sort field
                if (!Empty(CurrentOrder)) {
                    UpdateSort(MTCrewID, ctrl); // MTCrewID
                    UpdateSort(MTCertificateID, ctrl); // MTCertificateID
                    UpdateSort(CountryOfIssue_CountryID, ctrl); // CountryOfIssue_CountryID
                    UpdateSort(Number, ctrl); // Number
                    UpdateSort(DateOfIssue, ctrl); // DateOfIssue
                    UpdateSort(DateOfExpiry, ctrl); // DateOfExpiry
                    UpdateSort(PlaceOfIssue, ctrl); // PlaceOfIssue
                    UpdateSort(IssuingAuthority, ctrl); // IssuingAuthority
                    UpdateSort(Level, ctrl); // Level
                    UpdateSort(PaxVesselType, ctrl); // PaxVesselType
                    UpdateSort(Image, ctrl); // Image
                    UpdateSort(CreatedByUserID, ctrl); // CreatedByUserID
                    UpdateSort(CreatedDateTime, ctrl); // CreatedDateTime
                    UpdateSort(LastUpdatedByUserID, ctrl); // LastUpdatedByUserID
                    UpdateSort(LastUpdatedDateTime, ctrl); // LastUpdatedDateTime
                }

                // Update field sort
                UpdateFieldSort();
            }

            // Get preview SQL
            protected string PreviewSql(string filter) {
                string sort = SessionOrderBy;
                return BuildSelectSql(SqlSelect, SqlWhere, SqlGroupBy, SqlHaving, SqlOrderBy, filter, sort);
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

                // Drop down button for ListOptions
                ListOptions.UseDropDownButton = true;
                ListOptions.DropDownButtonPhrase = "ButtonListOptions";
                ListOptions.UseButtonGroup = false;
                ListOptions.ButtonClass = ""; // Class for button group

                // Call ListOptions Load event
                ListOptionsLoad();
                ListOptions[ListOptions.GroupOptionName]?.SetVisible(ListOptions.GroupOptionVisible);
            }
            #pragma warning restore 1998

            // Render list options
            #pragma warning disable 168, 219, 1998

            public async Task RenderListOptions()
            {
                ListOption? listOption;
                ListOptions.LoadDefault();

                // Call ListOptions Rendering event
                ListOptionsRendering();
                var masterKeyUrl = MasterKeyUrl();

                // Call ListOptions Rendered event
                ListOptionsRendered();
            }
            #pragma warning restore 168, 219, 1998

            // Set up other options
            protected void SetupOtherOptions() {
                var options = OtherOptions;
            }

            // Render other options
            #pragma warning disable 168, 219

            public void RenderOtherOptions() {
                var options = OtherOptions;
            }
            #pragma warning restore 168, 219

            // Get master foreign key URL
            protected string MasterKeyUrl() {
                string masterTblVar = Get("t"), url = "";
                if (masterTblVar == "MTCrew") {
                    url = "" + Config.TableShowMaster + "=MTCrew&" + ForeignKeyUrl("fk_ID", MTCrewID.QueryValue) + "";
                }
                return url;
            }

            #pragma warning disable 168
            // Set up foreign keys from filter
            protected void SetupForeignKeysFromFilter(string f) {
                string masterTblVar = Get("t");
                string filter = f;
                string val = "";
                string pattern;
                Match m, m1;
                if (masterTblVar == "MTCrew") {
                    pattern = @"^(" + Regex.Escape("[MTCrewID]") + @"\s*=\s*)";
                    m = Regex.Match(filter, pattern);
                    if (m.Success) {
                        val = filter.Substring(m.Groups[1].Length);
                        val = UnquoteValue(val); // DN
         		        MTCrewID.QueryValue = val;
                    }
                }
            }
            #pragma warning restore 168

            // Unquote value
            protected string UnquoteValue(string val) { // DN
                if (val.StartsWith("'") && val.EndsWith("'") && Connection != null) {
                    if (Connection.IsMySql)
                        return val.Substring(1, val.Length - 2).Replace(@"\'", "'");
                    else
                        return val.Substring(1, val.Length - 2).Replace("''", "'");
                } else if (val.StartsWith("N'") && val.EndsWith("'") && (Connection?.IsMsSql ?? false)) {
                    return val.Substring(2, val.Length - 3).Replace("''", "'");
                }
                return val;
            }

            // Close recordset
            public void CloseRecordset()
            {
                using (Recordset) {}
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

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MtCrewCertificateList")), "", TableVar, true);
            string pageId = "preview";
            breadcrumb.Add("preview", pageId, url);
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
    } // End page class
} // End Partial class
