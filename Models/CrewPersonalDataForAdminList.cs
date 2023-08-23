namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewPersonalDataForAdminList
    /// </summary>
    public static CrewPersonalDataForAdminList crewPersonalDataForAdminList
    {
        get => HttpData.Get<CrewPersonalDataForAdminList>("crewPersonalDataForAdminList")!;
        set => HttpData["crewPersonalDataForAdminList"] = value;
    }

    /// <summary>
    /// Page class for CrewPersonalDataForAdmin
    /// </summary>
    public class CrewPersonalDataForAdminList : CrewPersonalDataForAdminListBase
    {
        // Constructor
        public CrewPersonalDataForAdminList(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewPersonalDataForAdminList() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewPersonalDataForAdminListBase : CrewPersonalDataForAdmin
    {
        // Page ID
        public string PageID = "list";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewPersonalDataForAdmin";

        // Page object name
        public string PageObjName = "crewPersonalDataForAdminList";

        // Title
        public string? Title = null; // Title for <title> tag

        // Grid form hidden field names
        public string FormName = "fCrewPersonalDataForAdminlist";

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
        public CrewPersonalDataForAdminListBase()
        {
            // CSS class name as context
            TableVar = "CrewPersonalDataForAdmin";
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

            // Table object (crewPersonalDataForAdmin)
            if (crewPersonalDataForAdmin == null || crewPersonalDataForAdmin is CrewPersonalDataForAdmin)
                crewPersonalDataForAdmin = this;

            // Initialize URLs
            AddUrl = "CrewPersonalDataForAdminAdd";
            InlineAddUrl = PageUrl + "action=add";
            GridAddUrl = PageUrl + "action=gridadd";
            GridEditUrl = PageUrl + "action=gridedit";
            MultiEditUrl = PageUrl + "action=multiedit";
            MultiDeleteUrl = "CrewPersonalDataForAdminDelete";
            MultiUpdateUrl = "CrewPersonalDataForAdminUpdate";

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
        public string PageName => "CrewPersonalDataForAdminList";

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
            Nationality_CountryID.SetVisibility();
            CountryOfOrigin_CountryID.SetVisibility();
            DateOfBirth.SetVisibility();
            CityOfBirth.SetVisibility();
            Gender.SetVisibility();
            MaritalStatus.SetVisibility();
            ReligionID.SetVisibility();
            BloodType.Visible = false;
            RankAppliedFor_RankID.SetVisibility();
            WillAcceptLowRank.Visible = false;
            AvailableFrom.Visible = false;
            AvailableUntil.Visible = false;
            PrimaryAddressDetail.Visible = false;
            PrimaryAddressCity.Visible = false;
            PrimaryAddressNearestAirport.Visible = false;
            PrimaryAddressState.Visible = false;
            PrimaryAddressPostCode.Visible = false;
            PrimaryAddressCountryID.Visible = false;
            PrimaryAddressHomeTel.Visible = false;
            AlternativeAddressDetail.Visible = false;
            AlternativeAddressState.Visible = false;
            AlternativeAddressCity.Visible = false;
            AlternativeAddressHomeTel.Visible = false;
            AlternativeAddressPostCode.Visible = false;
            AlternativeAddressCountryID.Visible = false;
            MobileNumber.SetVisibility();
            _Email.SetVisibility();
            EmployeeStatus.SetVisibility();
            FormSubmittedDateTime.SetVisibility();
            ActiveDescription.Visible = false;
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            MTUserID.Visible = false;
            SocialSecurityNumber.Visible = false;
            SocialSecurityIssuingCountryID.Visible = false;
            SocialSecurityImage.Visible = false;
            PersonalTaxNumber.Visible = false;
            PersonalTaxIssuingCountryID.Visible = false;
            PersonalTaxImage.Visible = false;
            Status.Visible = false;
            Reason.Visible = false;
            Weight.Visible = false;
            Height.Visible = false;
            CoverallSize.Visible = false;
            SafetyShoesSize.Visible = false;
            ShirtSize.Visible = false;
            TrousersSize.Visible = false;
            NomineeFullName.Visible = false;
            NomineeRelationship.Visible = false;
            NomineeGender.Visible = false;
            NomineeNationality_CountryID.Visible = false;
            NomineeAddressDetail.Visible = false;
            NomineeAddressCity.Visible = false;
            NomineeAddressPostCode.Visible = false;
            NomineeAddressCountryID.Visible = false;
            NomineeAddressHomeTel.Visible = false;
            NomineeEmail.Visible = false;
            NomineeMobileNumber.Visible = false;
            NSSF_Health_Number.Visible = false;
            NSSF_Occupation_Number.Visible = false;
            NomineeRelationshipSelect.Visible = false;
            NomineeRelationshipDetail.Visible = false;
            MobileNumberCode_CountryID.Visible = false;
            PrimaryAddressHomeTelCode_CountryID.Visible = false;
            AlternativeAddressHomeTelCode_CountryID.Visible = false;
            NomineeAddressHomeTelCode_CountryID.Visible = false;
            NomineeMobileNumberCode_CountryID.Visible = false;
            MTManningAgentID.Visible = false;
        }

        // Constructor
        public CrewPersonalDataForAdminListBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "CrewPersonalDataForAdminView" ? "1" : "0"); // If View page, no primary button
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
                SocialSecurityImage.OldUploadPath = SocialSecurityImage.GetUploadPath();
                SocialSecurityImage.UploadPath = SocialSecurityImage.OldUploadPath;
                PersonalTaxImage.OldUploadPath = PersonalTaxImage.GetUploadPath();
                PersonalTaxImage.UploadPath = PersonalTaxImage.OldUploadPath;
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
            await SetupLookupOptions(Nationality_CountryID);
            await SetupLookupOptions(CountryOfOrigin_CountryID);
            await SetupLookupOptions(Gender);
            await SetupLookupOptions(MaritalStatus);
            await SetupLookupOptions(ReligionID);
            await SetupLookupOptions(BloodType);
            await SetupLookupOptions(RankAppliedFor_RankID);
            await SetupLookupOptions(WillAcceptLowRank);
            await SetupLookupOptions(PrimaryAddressCountryID);
            await SetupLookupOptions(AlternativeAddressCountryID);
            await SetupLookupOptions(SocialSecurityIssuingCountryID);
            await SetupLookupOptions(PersonalTaxIssuingCountryID);
            await SetupLookupOptions(CoverallSize);
            await SetupLookupOptions(SafetyShoesSize);
            await SetupLookupOptions(ShirtSize);
            await SetupLookupOptions(TrousersSize);
            await SetupLookupOptions(NomineeGender);
            await SetupLookupOptions(NomineeNationality_CountryID);
            await SetupLookupOptions(NomineeAddressCountryID);
            await SetupLookupOptions(NomineeRelationshipSelect);
            await SetupLookupOptions(MobileNumberCode_CountryID);
            await SetupLookupOptions(PrimaryAddressHomeTelCode_CountryID);
            await SetupLookupOptions(AlternativeAddressHomeTelCode_CountryID);
            await SetupLookupOptions(NomineeAddressHomeTelCode_CountryID);
            await SetupLookupOptions(NomineeMobileNumberCode_CountryID);

            // Update form name to avoid conflict
            if (IsModal)
                FormName = "fCrewPersonalDataForAdmingrid";

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
                crewPersonalDataForAdminList?.PageRender();
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
            filters.Merge(JObject.Parse(Nationality_CountryID.AdvancedSearch.ToJson())); // Field Nationality_CountryID
            filters.Merge(JObject.Parse(CountryOfOrigin_CountryID.AdvancedSearch.ToJson())); // Field CountryOfOrigin_CountryID
            filters.Merge(JObject.Parse(DateOfBirth.AdvancedSearch.ToJson())); // Field DateOfBirth
            filters.Merge(JObject.Parse(CityOfBirth.AdvancedSearch.ToJson())); // Field CityOfBirth
            filters.Merge(JObject.Parse(Gender.AdvancedSearch.ToJson())); // Field Gender
            filters.Merge(JObject.Parse(MaritalStatus.AdvancedSearch.ToJson())); // Field MaritalStatus
            filters.Merge(JObject.Parse(ReligionID.AdvancedSearch.ToJson())); // Field ReligionID
            filters.Merge(JObject.Parse(BloodType.AdvancedSearch.ToJson())); // Field BloodType
            filters.Merge(JObject.Parse(RankAppliedFor_RankID.AdvancedSearch.ToJson())); // Field RankAppliedFor_RankID
            filters.Merge(JObject.Parse(WillAcceptLowRank.AdvancedSearch.ToJson())); // Field WillAcceptLowRank
            filters.Merge(JObject.Parse(AvailableFrom.AdvancedSearch.ToJson())); // Field AvailableFrom
            filters.Merge(JObject.Parse(AvailableUntil.AdvancedSearch.ToJson())); // Field AvailableUntil
            filters.Merge(JObject.Parse(PrimaryAddressDetail.AdvancedSearch.ToJson())); // Field PrimaryAddressDetail
            filters.Merge(JObject.Parse(PrimaryAddressCity.AdvancedSearch.ToJson())); // Field PrimaryAddressCity
            filters.Merge(JObject.Parse(PrimaryAddressNearestAirport.AdvancedSearch.ToJson())); // Field PrimaryAddressNearestAirport
            filters.Merge(JObject.Parse(PrimaryAddressState.AdvancedSearch.ToJson())); // Field PrimaryAddressState
            filters.Merge(JObject.Parse(PrimaryAddressPostCode.AdvancedSearch.ToJson())); // Field PrimaryAddressPostCode
            filters.Merge(JObject.Parse(PrimaryAddressCountryID.AdvancedSearch.ToJson())); // Field PrimaryAddressCountryID
            filters.Merge(JObject.Parse(PrimaryAddressHomeTel.AdvancedSearch.ToJson())); // Field PrimaryAddressHomeTel
            filters.Merge(JObject.Parse(AlternativeAddressDetail.AdvancedSearch.ToJson())); // Field AlternativeAddressDetail
            filters.Merge(JObject.Parse(AlternativeAddressState.AdvancedSearch.ToJson())); // Field AlternativeAddressState
            filters.Merge(JObject.Parse(AlternativeAddressCity.AdvancedSearch.ToJson())); // Field AlternativeAddressCity
            filters.Merge(JObject.Parse(AlternativeAddressHomeTel.AdvancedSearch.ToJson())); // Field AlternativeAddressHomeTel
            filters.Merge(JObject.Parse(AlternativeAddressPostCode.AdvancedSearch.ToJson())); // Field AlternativeAddressPostCode
            filters.Merge(JObject.Parse(AlternativeAddressCountryID.AdvancedSearch.ToJson())); // Field AlternativeAddressCountryID
            filters.Merge(JObject.Parse(MobileNumber.AdvancedSearch.ToJson())); // Field MobileNumber
            filters.Merge(JObject.Parse(_Email.AdvancedSearch.ToJson())); // Field Email
            filters.Merge(JObject.Parse(EmployeeStatus.AdvancedSearch.ToJson())); // Field EmployeeStatus
            filters.Merge(JObject.Parse(FormSubmittedDateTime.AdvancedSearch.ToJson())); // Field FormSubmittedDateTime
            filters.Merge(JObject.Parse(CreatedByUserID.AdvancedSearch.ToJson())); // Field CreatedByUserID
            filters.Merge(JObject.Parse(CreatedDateTime.AdvancedSearch.ToJson())); // Field CreatedDateTime
            filters.Merge(JObject.Parse(LastUpdatedByUserID.AdvancedSearch.ToJson())); // Field LastUpdatedByUserID
            filters.Merge(JObject.Parse(LastUpdatedDateTime.AdvancedSearch.ToJson())); // Field LastUpdatedDateTime
            filters.Merge(JObject.Parse(SocialSecurityNumber.AdvancedSearch.ToJson())); // Field SocialSecurityNumber
            filters.Merge(JObject.Parse(SocialSecurityIssuingCountryID.AdvancedSearch.ToJson())); // Field SocialSecurityIssuingCountryID
            filters.Merge(JObject.Parse(SocialSecurityImage.AdvancedSearch.ToJson())); // Field SocialSecurityImage
            filters.Merge(JObject.Parse(PersonalTaxNumber.AdvancedSearch.ToJson())); // Field PersonalTaxNumber
            filters.Merge(JObject.Parse(PersonalTaxIssuingCountryID.AdvancedSearch.ToJson())); // Field PersonalTaxIssuingCountryID
            filters.Merge(JObject.Parse(PersonalTaxImage.AdvancedSearch.ToJson())); // Field PersonalTaxImage
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

            // Field Nationality_CountryID
            if (filter?.TryGetValue("x_Nationality_CountryID", out sv) ?? false) {
                Nationality_CountryID.AdvancedSearch.SearchValue = sv;
                Nationality_CountryID.AdvancedSearch.SearchOperator = filter["z_Nationality_CountryID"];
                Nationality_CountryID.AdvancedSearch.SearchCondition = filter["v_Nationality_CountryID"];
                Nationality_CountryID.AdvancedSearch.SearchValue2 = filter["y_Nationality_CountryID"];
                Nationality_CountryID.AdvancedSearch.SearchOperator2 = filter["w_Nationality_CountryID"];
                Nationality_CountryID.AdvancedSearch.Save();
            }

            // Field CountryOfOrigin_CountryID
            if (filter?.TryGetValue("x_CountryOfOrigin_CountryID", out sv) ?? false) {
                CountryOfOrigin_CountryID.AdvancedSearch.SearchValue = sv;
                CountryOfOrigin_CountryID.AdvancedSearch.SearchOperator = filter["z_CountryOfOrigin_CountryID"];
                CountryOfOrigin_CountryID.AdvancedSearch.SearchCondition = filter["v_CountryOfOrigin_CountryID"];
                CountryOfOrigin_CountryID.AdvancedSearch.SearchValue2 = filter["y_CountryOfOrigin_CountryID"];
                CountryOfOrigin_CountryID.AdvancedSearch.SearchOperator2 = filter["w_CountryOfOrigin_CountryID"];
                CountryOfOrigin_CountryID.AdvancedSearch.Save();
            }

            // Field DateOfBirth
            if (filter?.TryGetValue("x_DateOfBirth", out sv) ?? false) {
                DateOfBirth.AdvancedSearch.SearchValue = sv;
                DateOfBirth.AdvancedSearch.SearchOperator = filter["z_DateOfBirth"];
                DateOfBirth.AdvancedSearch.SearchCondition = filter["v_DateOfBirth"];
                DateOfBirth.AdvancedSearch.SearchValue2 = filter["y_DateOfBirth"];
                DateOfBirth.AdvancedSearch.SearchOperator2 = filter["w_DateOfBirth"];
                DateOfBirth.AdvancedSearch.Save();
            }

            // Field CityOfBirth
            if (filter?.TryGetValue("x_CityOfBirth", out sv) ?? false) {
                CityOfBirth.AdvancedSearch.SearchValue = sv;
                CityOfBirth.AdvancedSearch.SearchOperator = filter["z_CityOfBirth"];
                CityOfBirth.AdvancedSearch.SearchCondition = filter["v_CityOfBirth"];
                CityOfBirth.AdvancedSearch.SearchValue2 = filter["y_CityOfBirth"];
                CityOfBirth.AdvancedSearch.SearchOperator2 = filter["w_CityOfBirth"];
                CityOfBirth.AdvancedSearch.Save();
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

            // Field MaritalStatus
            if (filter?.TryGetValue("x_MaritalStatus", out sv) ?? false) {
                MaritalStatus.AdvancedSearch.SearchValue = sv;
                MaritalStatus.AdvancedSearch.SearchOperator = filter["z_MaritalStatus"];
                MaritalStatus.AdvancedSearch.SearchCondition = filter["v_MaritalStatus"];
                MaritalStatus.AdvancedSearch.SearchValue2 = filter["y_MaritalStatus"];
                MaritalStatus.AdvancedSearch.SearchOperator2 = filter["w_MaritalStatus"];
                MaritalStatus.AdvancedSearch.Save();
            }

            // Field ReligionID
            if (filter?.TryGetValue("x_ReligionID", out sv) ?? false) {
                ReligionID.AdvancedSearch.SearchValue = sv;
                ReligionID.AdvancedSearch.SearchOperator = filter["z_ReligionID"];
                ReligionID.AdvancedSearch.SearchCondition = filter["v_ReligionID"];
                ReligionID.AdvancedSearch.SearchValue2 = filter["y_ReligionID"];
                ReligionID.AdvancedSearch.SearchOperator2 = filter["w_ReligionID"];
                ReligionID.AdvancedSearch.Save();
            }

            // Field BloodType
            if (filter?.TryGetValue("x_BloodType", out sv) ?? false) {
                BloodType.AdvancedSearch.SearchValue = sv;
                BloodType.AdvancedSearch.SearchOperator = filter["z_BloodType"];
                BloodType.AdvancedSearch.SearchCondition = filter["v_BloodType"];
                BloodType.AdvancedSearch.SearchValue2 = filter["y_BloodType"];
                BloodType.AdvancedSearch.SearchOperator2 = filter["w_BloodType"];
                BloodType.AdvancedSearch.Save();
            }

            // Field RankAppliedFor_RankID
            if (filter?.TryGetValue("x_RankAppliedFor_RankID", out sv) ?? false) {
                RankAppliedFor_RankID.AdvancedSearch.SearchValue = sv;
                RankAppliedFor_RankID.AdvancedSearch.SearchOperator = filter["z_RankAppliedFor_RankID"];
                RankAppliedFor_RankID.AdvancedSearch.SearchCondition = filter["v_RankAppliedFor_RankID"];
                RankAppliedFor_RankID.AdvancedSearch.SearchValue2 = filter["y_RankAppliedFor_RankID"];
                RankAppliedFor_RankID.AdvancedSearch.SearchOperator2 = filter["w_RankAppliedFor_RankID"];
                RankAppliedFor_RankID.AdvancedSearch.Save();
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

            // Field PrimaryAddressDetail
            if (filter?.TryGetValue("x_PrimaryAddressDetail", out sv) ?? false) {
                PrimaryAddressDetail.AdvancedSearch.SearchValue = sv;
                PrimaryAddressDetail.AdvancedSearch.SearchOperator = filter["z_PrimaryAddressDetail"];
                PrimaryAddressDetail.AdvancedSearch.SearchCondition = filter["v_PrimaryAddressDetail"];
                PrimaryAddressDetail.AdvancedSearch.SearchValue2 = filter["y_PrimaryAddressDetail"];
                PrimaryAddressDetail.AdvancedSearch.SearchOperator2 = filter["w_PrimaryAddressDetail"];
                PrimaryAddressDetail.AdvancedSearch.Save();
            }

            // Field PrimaryAddressCity
            if (filter?.TryGetValue("x_PrimaryAddressCity", out sv) ?? false) {
                PrimaryAddressCity.AdvancedSearch.SearchValue = sv;
                PrimaryAddressCity.AdvancedSearch.SearchOperator = filter["z_PrimaryAddressCity"];
                PrimaryAddressCity.AdvancedSearch.SearchCondition = filter["v_PrimaryAddressCity"];
                PrimaryAddressCity.AdvancedSearch.SearchValue2 = filter["y_PrimaryAddressCity"];
                PrimaryAddressCity.AdvancedSearch.SearchOperator2 = filter["w_PrimaryAddressCity"];
                PrimaryAddressCity.AdvancedSearch.Save();
            }

            // Field PrimaryAddressNearestAirport
            if (filter?.TryGetValue("x_PrimaryAddressNearestAirport", out sv) ?? false) {
                PrimaryAddressNearestAirport.AdvancedSearch.SearchValue = sv;
                PrimaryAddressNearestAirport.AdvancedSearch.SearchOperator = filter["z_PrimaryAddressNearestAirport"];
                PrimaryAddressNearestAirport.AdvancedSearch.SearchCondition = filter["v_PrimaryAddressNearestAirport"];
                PrimaryAddressNearestAirport.AdvancedSearch.SearchValue2 = filter["y_PrimaryAddressNearestAirport"];
                PrimaryAddressNearestAirport.AdvancedSearch.SearchOperator2 = filter["w_PrimaryAddressNearestAirport"];
                PrimaryAddressNearestAirport.AdvancedSearch.Save();
            }

            // Field PrimaryAddressState
            if (filter?.TryGetValue("x_PrimaryAddressState", out sv) ?? false) {
                PrimaryAddressState.AdvancedSearch.SearchValue = sv;
                PrimaryAddressState.AdvancedSearch.SearchOperator = filter["z_PrimaryAddressState"];
                PrimaryAddressState.AdvancedSearch.SearchCondition = filter["v_PrimaryAddressState"];
                PrimaryAddressState.AdvancedSearch.SearchValue2 = filter["y_PrimaryAddressState"];
                PrimaryAddressState.AdvancedSearch.SearchOperator2 = filter["w_PrimaryAddressState"];
                PrimaryAddressState.AdvancedSearch.Save();
            }

            // Field PrimaryAddressPostCode
            if (filter?.TryGetValue("x_PrimaryAddressPostCode", out sv) ?? false) {
                PrimaryAddressPostCode.AdvancedSearch.SearchValue = sv;
                PrimaryAddressPostCode.AdvancedSearch.SearchOperator = filter["z_PrimaryAddressPostCode"];
                PrimaryAddressPostCode.AdvancedSearch.SearchCondition = filter["v_PrimaryAddressPostCode"];
                PrimaryAddressPostCode.AdvancedSearch.SearchValue2 = filter["y_PrimaryAddressPostCode"];
                PrimaryAddressPostCode.AdvancedSearch.SearchOperator2 = filter["w_PrimaryAddressPostCode"];
                PrimaryAddressPostCode.AdvancedSearch.Save();
            }

            // Field PrimaryAddressCountryID
            if (filter?.TryGetValue("x_PrimaryAddressCountryID", out sv) ?? false) {
                PrimaryAddressCountryID.AdvancedSearch.SearchValue = sv;
                PrimaryAddressCountryID.AdvancedSearch.SearchOperator = filter["z_PrimaryAddressCountryID"];
                PrimaryAddressCountryID.AdvancedSearch.SearchCondition = filter["v_PrimaryAddressCountryID"];
                PrimaryAddressCountryID.AdvancedSearch.SearchValue2 = filter["y_PrimaryAddressCountryID"];
                PrimaryAddressCountryID.AdvancedSearch.SearchOperator2 = filter["w_PrimaryAddressCountryID"];
                PrimaryAddressCountryID.AdvancedSearch.Save();
            }

            // Field PrimaryAddressHomeTel
            if (filter?.TryGetValue("x_PrimaryAddressHomeTel", out sv) ?? false) {
                PrimaryAddressHomeTel.AdvancedSearch.SearchValue = sv;
                PrimaryAddressHomeTel.AdvancedSearch.SearchOperator = filter["z_PrimaryAddressHomeTel"];
                PrimaryAddressHomeTel.AdvancedSearch.SearchCondition = filter["v_PrimaryAddressHomeTel"];
                PrimaryAddressHomeTel.AdvancedSearch.SearchValue2 = filter["y_PrimaryAddressHomeTel"];
                PrimaryAddressHomeTel.AdvancedSearch.SearchOperator2 = filter["w_PrimaryAddressHomeTel"];
                PrimaryAddressHomeTel.AdvancedSearch.Save();
            }

            // Field AlternativeAddressDetail
            if (filter?.TryGetValue("x_AlternativeAddressDetail", out sv) ?? false) {
                AlternativeAddressDetail.AdvancedSearch.SearchValue = sv;
                AlternativeAddressDetail.AdvancedSearch.SearchOperator = filter["z_AlternativeAddressDetail"];
                AlternativeAddressDetail.AdvancedSearch.SearchCondition = filter["v_AlternativeAddressDetail"];
                AlternativeAddressDetail.AdvancedSearch.SearchValue2 = filter["y_AlternativeAddressDetail"];
                AlternativeAddressDetail.AdvancedSearch.SearchOperator2 = filter["w_AlternativeAddressDetail"];
                AlternativeAddressDetail.AdvancedSearch.Save();
            }

            // Field AlternativeAddressState
            if (filter?.TryGetValue("x_AlternativeAddressState", out sv) ?? false) {
                AlternativeAddressState.AdvancedSearch.SearchValue = sv;
                AlternativeAddressState.AdvancedSearch.SearchOperator = filter["z_AlternativeAddressState"];
                AlternativeAddressState.AdvancedSearch.SearchCondition = filter["v_AlternativeAddressState"];
                AlternativeAddressState.AdvancedSearch.SearchValue2 = filter["y_AlternativeAddressState"];
                AlternativeAddressState.AdvancedSearch.SearchOperator2 = filter["w_AlternativeAddressState"];
                AlternativeAddressState.AdvancedSearch.Save();
            }

            // Field AlternativeAddressCity
            if (filter?.TryGetValue("x_AlternativeAddressCity", out sv) ?? false) {
                AlternativeAddressCity.AdvancedSearch.SearchValue = sv;
                AlternativeAddressCity.AdvancedSearch.SearchOperator = filter["z_AlternativeAddressCity"];
                AlternativeAddressCity.AdvancedSearch.SearchCondition = filter["v_AlternativeAddressCity"];
                AlternativeAddressCity.AdvancedSearch.SearchValue2 = filter["y_AlternativeAddressCity"];
                AlternativeAddressCity.AdvancedSearch.SearchOperator2 = filter["w_AlternativeAddressCity"];
                AlternativeAddressCity.AdvancedSearch.Save();
            }

            // Field AlternativeAddressHomeTel
            if (filter?.TryGetValue("x_AlternativeAddressHomeTel", out sv) ?? false) {
                AlternativeAddressHomeTel.AdvancedSearch.SearchValue = sv;
                AlternativeAddressHomeTel.AdvancedSearch.SearchOperator = filter["z_AlternativeAddressHomeTel"];
                AlternativeAddressHomeTel.AdvancedSearch.SearchCondition = filter["v_AlternativeAddressHomeTel"];
                AlternativeAddressHomeTel.AdvancedSearch.SearchValue2 = filter["y_AlternativeAddressHomeTel"];
                AlternativeAddressHomeTel.AdvancedSearch.SearchOperator2 = filter["w_AlternativeAddressHomeTel"];
                AlternativeAddressHomeTel.AdvancedSearch.Save();
            }

            // Field AlternativeAddressPostCode
            if (filter?.TryGetValue("x_AlternativeAddressPostCode", out sv) ?? false) {
                AlternativeAddressPostCode.AdvancedSearch.SearchValue = sv;
                AlternativeAddressPostCode.AdvancedSearch.SearchOperator = filter["z_AlternativeAddressPostCode"];
                AlternativeAddressPostCode.AdvancedSearch.SearchCondition = filter["v_AlternativeAddressPostCode"];
                AlternativeAddressPostCode.AdvancedSearch.SearchValue2 = filter["y_AlternativeAddressPostCode"];
                AlternativeAddressPostCode.AdvancedSearch.SearchOperator2 = filter["w_AlternativeAddressPostCode"];
                AlternativeAddressPostCode.AdvancedSearch.Save();
            }

            // Field AlternativeAddressCountryID
            if (filter?.TryGetValue("x_AlternativeAddressCountryID", out sv) ?? false) {
                AlternativeAddressCountryID.AdvancedSearch.SearchValue = sv;
                AlternativeAddressCountryID.AdvancedSearch.SearchOperator = filter["z_AlternativeAddressCountryID"];
                AlternativeAddressCountryID.AdvancedSearch.SearchCondition = filter["v_AlternativeAddressCountryID"];
                AlternativeAddressCountryID.AdvancedSearch.SearchValue2 = filter["y_AlternativeAddressCountryID"];
                AlternativeAddressCountryID.AdvancedSearch.SearchOperator2 = filter["w_AlternativeAddressCountryID"];
                AlternativeAddressCountryID.AdvancedSearch.Save();
            }

            // Field MobileNumber
            if (filter?.TryGetValue("x_MobileNumber", out sv) ?? false) {
                MobileNumber.AdvancedSearch.SearchValue = sv;
                MobileNumber.AdvancedSearch.SearchOperator = filter["z_MobileNumber"];
                MobileNumber.AdvancedSearch.SearchCondition = filter["v_MobileNumber"];
                MobileNumber.AdvancedSearch.SearchValue2 = filter["y_MobileNumber"];
                MobileNumber.AdvancedSearch.SearchOperator2 = filter["w_MobileNumber"];
                MobileNumber.AdvancedSearch.Save();
            }

            // Field Email
            if (filter?.TryGetValue("x__Email", out sv) ?? false) {
                _Email.AdvancedSearch.SearchValue = sv;
                _Email.AdvancedSearch.SearchOperator = filter["z__Email"];
                _Email.AdvancedSearch.SearchCondition = filter["v__Email"];
                _Email.AdvancedSearch.SearchValue2 = filter["y__Email"];
                _Email.AdvancedSearch.SearchOperator2 = filter["w__Email"];
                _Email.AdvancedSearch.Save();
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

            // Field FormSubmittedDateTime
            if (filter?.TryGetValue("x_FormSubmittedDateTime", out sv) ?? false) {
                FormSubmittedDateTime.AdvancedSearch.SearchValue = sv;
                FormSubmittedDateTime.AdvancedSearch.SearchOperator = filter["z_FormSubmittedDateTime"];
                FormSubmittedDateTime.AdvancedSearch.SearchCondition = filter["v_FormSubmittedDateTime"];
                FormSubmittedDateTime.AdvancedSearch.SearchValue2 = filter["y_FormSubmittedDateTime"];
                FormSubmittedDateTime.AdvancedSearch.SearchOperator2 = filter["w_FormSubmittedDateTime"];
                FormSubmittedDateTime.AdvancedSearch.Save();
            }

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

            // Field SocialSecurityNumber
            if (filter?.TryGetValue("x_SocialSecurityNumber", out sv) ?? false) {
                SocialSecurityNumber.AdvancedSearch.SearchValue = sv;
                SocialSecurityNumber.AdvancedSearch.SearchOperator = filter["z_SocialSecurityNumber"];
                SocialSecurityNumber.AdvancedSearch.SearchCondition = filter["v_SocialSecurityNumber"];
                SocialSecurityNumber.AdvancedSearch.SearchValue2 = filter["y_SocialSecurityNumber"];
                SocialSecurityNumber.AdvancedSearch.SearchOperator2 = filter["w_SocialSecurityNumber"];
                SocialSecurityNumber.AdvancedSearch.Save();
            }

            // Field SocialSecurityIssuingCountryID
            if (filter?.TryGetValue("x_SocialSecurityIssuingCountryID", out sv) ?? false) {
                SocialSecurityIssuingCountryID.AdvancedSearch.SearchValue = sv;
                SocialSecurityIssuingCountryID.AdvancedSearch.SearchOperator = filter["z_SocialSecurityIssuingCountryID"];
                SocialSecurityIssuingCountryID.AdvancedSearch.SearchCondition = filter["v_SocialSecurityIssuingCountryID"];
                SocialSecurityIssuingCountryID.AdvancedSearch.SearchValue2 = filter["y_SocialSecurityIssuingCountryID"];
                SocialSecurityIssuingCountryID.AdvancedSearch.SearchOperator2 = filter["w_SocialSecurityIssuingCountryID"];
                SocialSecurityIssuingCountryID.AdvancedSearch.Save();
            }

            // Field SocialSecurityImage
            if (filter?.TryGetValue("x_SocialSecurityImage", out sv) ?? false) {
                SocialSecurityImage.AdvancedSearch.SearchValue = sv;
                SocialSecurityImage.AdvancedSearch.SearchOperator = filter["z_SocialSecurityImage"];
                SocialSecurityImage.AdvancedSearch.SearchCondition = filter["v_SocialSecurityImage"];
                SocialSecurityImage.AdvancedSearch.SearchValue2 = filter["y_SocialSecurityImage"];
                SocialSecurityImage.AdvancedSearch.SearchOperator2 = filter["w_SocialSecurityImage"];
                SocialSecurityImage.AdvancedSearch.Save();
            }

            // Field PersonalTaxNumber
            if (filter?.TryGetValue("x_PersonalTaxNumber", out sv) ?? false) {
                PersonalTaxNumber.AdvancedSearch.SearchValue = sv;
                PersonalTaxNumber.AdvancedSearch.SearchOperator = filter["z_PersonalTaxNumber"];
                PersonalTaxNumber.AdvancedSearch.SearchCondition = filter["v_PersonalTaxNumber"];
                PersonalTaxNumber.AdvancedSearch.SearchValue2 = filter["y_PersonalTaxNumber"];
                PersonalTaxNumber.AdvancedSearch.SearchOperator2 = filter["w_PersonalTaxNumber"];
                PersonalTaxNumber.AdvancedSearch.Save();
            }

            // Field PersonalTaxIssuingCountryID
            if (filter?.TryGetValue("x_PersonalTaxIssuingCountryID", out sv) ?? false) {
                PersonalTaxIssuingCountryID.AdvancedSearch.SearchValue = sv;
                PersonalTaxIssuingCountryID.AdvancedSearch.SearchOperator = filter["z_PersonalTaxIssuingCountryID"];
                PersonalTaxIssuingCountryID.AdvancedSearch.SearchCondition = filter["v_PersonalTaxIssuingCountryID"];
                PersonalTaxIssuingCountryID.AdvancedSearch.SearchValue2 = filter["y_PersonalTaxIssuingCountryID"];
                PersonalTaxIssuingCountryID.AdvancedSearch.SearchOperator2 = filter["w_PersonalTaxIssuingCountryID"];
                PersonalTaxIssuingCountryID.AdvancedSearch.Save();
            }

            // Field PersonalTaxImage
            if (filter?.TryGetValue("x_PersonalTaxImage", out sv) ?? false) {
                PersonalTaxImage.AdvancedSearch.SearchValue = sv;
                PersonalTaxImage.AdvancedSearch.SearchOperator = filter["z_PersonalTaxImage"];
                PersonalTaxImage.AdvancedSearch.SearchCondition = filter["v_PersonalTaxImage"];
                PersonalTaxImage.AdvancedSearch.SearchValue2 = filter["y_PersonalTaxImage"];
                PersonalTaxImage.AdvancedSearch.SearchOperator2 = filter["w_PersonalTaxImage"];
                PersonalTaxImage.AdvancedSearch.Save();
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
            BuildSearchSql(ref where, Nationality_CountryID, def, true); // Nationality_CountryID
            BuildSearchSql(ref where, CountryOfOrigin_CountryID, def, true); // CountryOfOrigin_CountryID
            BuildSearchSql(ref where, DateOfBirth, def, true); // DateOfBirth
            BuildSearchSql(ref where, CityOfBirth, def, true); // CityOfBirth
            BuildSearchSql(ref where, Gender, def, true); // Gender
            BuildSearchSql(ref where, MaritalStatus, def, true); // MaritalStatus
            BuildSearchSql(ref where, ReligionID, def, true); // ReligionID
            BuildSearchSql(ref where, BloodType, def, false); // BloodType
            BuildSearchSql(ref where, RankAppliedFor_RankID, def, true); // RankAppliedFor_RankID
            BuildSearchSql(ref where, WillAcceptLowRank, def, false); // WillAcceptLowRank
            BuildSearchSql(ref where, AvailableFrom, def, false); // AvailableFrom
            BuildSearchSql(ref where, AvailableUntil, def, false); // AvailableUntil
            BuildSearchSql(ref where, PrimaryAddressDetail, def, false); // PrimaryAddressDetail
            BuildSearchSql(ref where, PrimaryAddressCity, def, false); // PrimaryAddressCity
            BuildSearchSql(ref where, PrimaryAddressNearestAirport, def, false); // PrimaryAddressNearestAirport
            BuildSearchSql(ref where, PrimaryAddressState, def, false); // PrimaryAddressState
            BuildSearchSql(ref where, PrimaryAddressPostCode, def, false); // PrimaryAddressPostCode
            BuildSearchSql(ref where, PrimaryAddressCountryID, def, false); // PrimaryAddressCountryID
            BuildSearchSql(ref where, PrimaryAddressHomeTel, def, false); // PrimaryAddressHomeTel
            BuildSearchSql(ref where, AlternativeAddressDetail, def, false); // AlternativeAddressDetail
            BuildSearchSql(ref where, AlternativeAddressState, def, false); // AlternativeAddressState
            BuildSearchSql(ref where, AlternativeAddressCity, def, false); // AlternativeAddressCity
            BuildSearchSql(ref where, AlternativeAddressHomeTel, def, false); // AlternativeAddressHomeTel
            BuildSearchSql(ref where, AlternativeAddressPostCode, def, false); // AlternativeAddressPostCode
            BuildSearchSql(ref where, AlternativeAddressCountryID, def, false); // AlternativeAddressCountryID
            BuildSearchSql(ref where, MobileNumber, def, true); // MobileNumber
            BuildSearchSql(ref where, _Email, def, true); // _Email
            BuildSearchSql(ref where, EmployeeStatus, def, true); // EmployeeStatus
            BuildSearchSql(ref where, FormSubmittedDateTime, def, true); // FormSubmittedDateTime
            BuildSearchSql(ref where, CreatedByUserID, def, true); // CreatedByUserID
            BuildSearchSql(ref where, CreatedDateTime, def, true); // CreatedDateTime
            BuildSearchSql(ref where, LastUpdatedByUserID, def, true); // LastUpdatedByUserID
            BuildSearchSql(ref where, LastUpdatedDateTime, def, true); // LastUpdatedDateTime
            BuildSearchSql(ref where, SocialSecurityNumber, def, false); // SocialSecurityNumber
            BuildSearchSql(ref where, SocialSecurityIssuingCountryID, def, false); // SocialSecurityIssuingCountryID
            BuildSearchSql(ref where, SocialSecurityImage, def, false); // SocialSecurityImage
            BuildSearchSql(ref where, PersonalTaxNumber, def, false); // PersonalTaxNumber
            BuildSearchSql(ref where, PersonalTaxIssuingCountryID, def, false); // PersonalTaxIssuingCountryID
            BuildSearchSql(ref where, PersonalTaxImage, def, false); // PersonalTaxImage

            // Set up search command
            if (!def && !Empty(where) && (new[] { "", "reset", "resetall" }).Contains(Command))
                Command = "search";
            if (!def && Command == "search") {
                IndividualCodeNumber.AdvancedSearch.Save(); // IndividualCodeNumber
                FullName.AdvancedSearch.Save(); // FullName
                RequiredPhoto.AdvancedSearch.Save(); // RequiredPhoto
                VisaPhoto.AdvancedSearch.Save(); // VisaPhoto
                Nationality_CountryID.AdvancedSearch.Save(); // Nationality_CountryID
                CountryOfOrigin_CountryID.AdvancedSearch.Save(); // CountryOfOrigin_CountryID
                DateOfBirth.AdvancedSearch.Save(); // DateOfBirth
                CityOfBirth.AdvancedSearch.Save(); // CityOfBirth
                Gender.AdvancedSearch.Save(); // Gender
                MaritalStatus.AdvancedSearch.Save(); // MaritalStatus
                ReligionID.AdvancedSearch.Save(); // ReligionID
                BloodType.AdvancedSearch.Save(); // BloodType
                RankAppliedFor_RankID.AdvancedSearch.Save(); // RankAppliedFor_RankID
                WillAcceptLowRank.AdvancedSearch.Save(); // WillAcceptLowRank
                AvailableFrom.AdvancedSearch.Save(); // AvailableFrom
                AvailableUntil.AdvancedSearch.Save(); // AvailableUntil
                PrimaryAddressDetail.AdvancedSearch.Save(); // PrimaryAddressDetail
                PrimaryAddressCity.AdvancedSearch.Save(); // PrimaryAddressCity
                PrimaryAddressNearestAirport.AdvancedSearch.Save(); // PrimaryAddressNearestAirport
                PrimaryAddressState.AdvancedSearch.Save(); // PrimaryAddressState
                PrimaryAddressPostCode.AdvancedSearch.Save(); // PrimaryAddressPostCode
                PrimaryAddressCountryID.AdvancedSearch.Save(); // PrimaryAddressCountryID
                PrimaryAddressHomeTel.AdvancedSearch.Save(); // PrimaryAddressHomeTel
                AlternativeAddressDetail.AdvancedSearch.Save(); // AlternativeAddressDetail
                AlternativeAddressState.AdvancedSearch.Save(); // AlternativeAddressState
                AlternativeAddressCity.AdvancedSearch.Save(); // AlternativeAddressCity
                AlternativeAddressHomeTel.AdvancedSearch.Save(); // AlternativeAddressHomeTel
                AlternativeAddressPostCode.AdvancedSearch.Save(); // AlternativeAddressPostCode
                AlternativeAddressCountryID.AdvancedSearch.Save(); // AlternativeAddressCountryID
                MobileNumber.AdvancedSearch.Save(); // MobileNumber
                _Email.AdvancedSearch.Save(); // Email
                EmployeeStatus.AdvancedSearch.Save(); // EmployeeStatus
                FormSubmittedDateTime.AdvancedSearch.Save(); // FormSubmittedDateTime
                CreatedByUserID.AdvancedSearch.Save(); // CreatedByUserID
                CreatedDateTime.AdvancedSearch.Save(); // CreatedDateTime
                LastUpdatedByUserID.AdvancedSearch.Save(); // LastUpdatedByUserID
                LastUpdatedDateTime.AdvancedSearch.Save(); // LastUpdatedDateTime
                SocialSecurityNumber.AdvancedSearch.Save(); // SocialSecurityNumber
                SocialSecurityIssuingCountryID.AdvancedSearch.Save(); // SocialSecurityIssuingCountryID
                SocialSecurityImage.AdvancedSearch.Save(); // SocialSecurityImage
                PersonalTaxNumber.AdvancedSearch.Save(); // PersonalTaxNumber
                PersonalTaxIssuingCountryID.AdvancedSearch.Save(); // PersonalTaxIssuingCountryID
                PersonalTaxImage.AdvancedSearch.Save(); // PersonalTaxImage

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

            // Field Nationality_CountryID
            filter = QueryBuilderWhere("Nationality_CountryID");
            if (Empty(filter))
                BuildSearchSql(ref filter, Nationality_CountryID, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Nationality_CountryID.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CountryOfOrigin_CountryID
            filter = QueryBuilderWhere("CountryOfOrigin_CountryID");
            if (Empty(filter))
                BuildSearchSql(ref filter, CountryOfOrigin_CountryID, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CountryOfOrigin_CountryID.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field DateOfBirth
            filter = QueryBuilderWhere("DateOfBirth");
            if (Empty(filter))
                BuildSearchSql(ref filter, DateOfBirth, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + DateOfBirth.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field CityOfBirth
            filter = QueryBuilderWhere("CityOfBirth");
            if (Empty(filter))
                BuildSearchSql(ref filter, CityOfBirth, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + CityOfBirth.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Gender
            filter = QueryBuilderWhere("Gender");
            if (Empty(filter))
                BuildSearchSql(ref filter, Gender, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + Gender.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field MaritalStatus
            filter = QueryBuilderWhere("MaritalStatus");
            if (Empty(filter))
                BuildSearchSql(ref filter, MaritalStatus, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + MaritalStatus.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field ReligionID
            filter = QueryBuilderWhere("ReligionID");
            if (Empty(filter))
                BuildSearchSql(ref filter, ReligionID, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + ReligionID.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field RankAppliedFor_RankID
            filter = QueryBuilderWhere("RankAppliedFor_RankID");
            if (Empty(filter))
                BuildSearchSql(ref filter, RankAppliedFor_RankID, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + RankAppliedFor_RankID.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field MobileNumber
            filter = QueryBuilderWhere("MobileNumber");
            if (Empty(filter))
                BuildSearchSql(ref filter, MobileNumber, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + MobileNumber.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field Email
            filter = QueryBuilderWhere("Email");
            if (Empty(filter))
                BuildSearchSql(ref filter, _Email, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + _Email.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field EmployeeStatus
            filter = QueryBuilderWhere("EmployeeStatus");
            if (Empty(filter))
                BuildSearchSql(ref filter, EmployeeStatus, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + EmployeeStatus.Caption + "</span>" + captionSuffix + filter + "</div>";

            // Field FormSubmittedDateTime
            filter = QueryBuilderWhere("FormSubmittedDateTime");
            if (Empty(filter))
                BuildSearchSql(ref filter, FormSubmittedDateTime, false, true);
            if (!Empty(filter))
                filterList += "<div><span class=\"" + captionClass + "\">" + FormSubmittedDateTime.Caption + "</span>" + captionSuffix + filter + "</div>";

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
            searchFlds.Add(FullName);
            searchFlds.Add(CityOfBirth);
            searchFlds.Add(Gender);
            searchFlds.Add(MaritalStatus);
            searchFlds.Add(BloodType);
            searchFlds.Add(PrimaryAddressDetail);
            searchFlds.Add(PrimaryAddressCity);
            searchFlds.Add(PrimaryAddressNearestAirport);
            searchFlds.Add(PrimaryAddressState);
            searchFlds.Add(PrimaryAddressPostCode);
            searchFlds.Add(PrimaryAddressHomeTel);
            searchFlds.Add(AlternativeAddressDetail);
            searchFlds.Add(AlternativeAddressState);
            searchFlds.Add(AlternativeAddressCity);
            searchFlds.Add(AlternativeAddressHomeTel);
            searchFlds.Add(AlternativeAddressPostCode);
            searchFlds.Add(MobileNumber);
            searchFlds.Add(_Email);
            searchFlds.Add(EmployeeStatus);
            searchFlds.Add(SocialSecurityNumber);
            searchFlds.Add(SocialSecurityImage);
            searchFlds.Add(PersonalTaxNumber);
            searchFlds.Add(PersonalTaxImage);
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
            if (Nationality_CountryID.AdvancedSearch.IssetSession)
                return true;
            if (CountryOfOrigin_CountryID.AdvancedSearch.IssetSession)
                return true;
            if (DateOfBirth.AdvancedSearch.IssetSession)
                return true;
            if (CityOfBirth.AdvancedSearch.IssetSession)
                return true;
            if (Gender.AdvancedSearch.IssetSession)
                return true;
            if (MaritalStatus.AdvancedSearch.IssetSession)
                return true;
            if (ReligionID.AdvancedSearch.IssetSession)
                return true;
            if (BloodType.AdvancedSearch.IssetSession)
                return true;
            if (RankAppliedFor_RankID.AdvancedSearch.IssetSession)
                return true;
            if (WillAcceptLowRank.AdvancedSearch.IssetSession)
                return true;
            if (AvailableFrom.AdvancedSearch.IssetSession)
                return true;
            if (AvailableUntil.AdvancedSearch.IssetSession)
                return true;
            if (PrimaryAddressDetail.AdvancedSearch.IssetSession)
                return true;
            if (PrimaryAddressCity.AdvancedSearch.IssetSession)
                return true;
            if (PrimaryAddressNearestAirport.AdvancedSearch.IssetSession)
                return true;
            if (PrimaryAddressState.AdvancedSearch.IssetSession)
                return true;
            if (PrimaryAddressPostCode.AdvancedSearch.IssetSession)
                return true;
            if (PrimaryAddressCountryID.AdvancedSearch.IssetSession)
                return true;
            if (PrimaryAddressHomeTel.AdvancedSearch.IssetSession)
                return true;
            if (AlternativeAddressDetail.AdvancedSearch.IssetSession)
                return true;
            if (AlternativeAddressState.AdvancedSearch.IssetSession)
                return true;
            if (AlternativeAddressCity.AdvancedSearch.IssetSession)
                return true;
            if (AlternativeAddressHomeTel.AdvancedSearch.IssetSession)
                return true;
            if (AlternativeAddressPostCode.AdvancedSearch.IssetSession)
                return true;
            if (AlternativeAddressCountryID.AdvancedSearch.IssetSession)
                return true;
            if (MobileNumber.AdvancedSearch.IssetSession)
                return true;
            if (_Email.AdvancedSearch.IssetSession)
                return true;
            if (EmployeeStatus.AdvancedSearch.IssetSession)
                return true;
            if (FormSubmittedDateTime.AdvancedSearch.IssetSession)
                return true;
            if (CreatedByUserID.AdvancedSearch.IssetSession)
                return true;
            if (CreatedDateTime.AdvancedSearch.IssetSession)
                return true;
            if (LastUpdatedByUserID.AdvancedSearch.IssetSession)
                return true;
            if (LastUpdatedDateTime.AdvancedSearch.IssetSession)
                return true;
            if (SocialSecurityNumber.AdvancedSearch.IssetSession)
                return true;
            if (SocialSecurityIssuingCountryID.AdvancedSearch.IssetSession)
                return true;
            if (SocialSecurityImage.AdvancedSearch.IssetSession)
                return true;
            if (PersonalTaxNumber.AdvancedSearch.IssetSession)
                return true;
            if (PersonalTaxIssuingCountryID.AdvancedSearch.IssetSession)
                return true;
            if (PersonalTaxImage.AdvancedSearch.IssetSession)
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
            Nationality_CountryID.AdvancedSearch.UnsetSession();
            CountryOfOrigin_CountryID.AdvancedSearch.UnsetSession();
            DateOfBirth.AdvancedSearch.UnsetSession();
            CityOfBirth.AdvancedSearch.UnsetSession();
            Gender.AdvancedSearch.UnsetSession();
            MaritalStatus.AdvancedSearch.UnsetSession();
            ReligionID.AdvancedSearch.UnsetSession();
            BloodType.AdvancedSearch.UnsetSession();
            RankAppliedFor_RankID.AdvancedSearch.UnsetSession();
            WillAcceptLowRank.AdvancedSearch.UnsetSession();
            AvailableFrom.AdvancedSearch.UnsetSession();
            AvailableUntil.AdvancedSearch.UnsetSession();
            PrimaryAddressDetail.AdvancedSearch.UnsetSession();
            PrimaryAddressCity.AdvancedSearch.UnsetSession();
            PrimaryAddressNearestAirport.AdvancedSearch.UnsetSession();
            PrimaryAddressState.AdvancedSearch.UnsetSession();
            PrimaryAddressPostCode.AdvancedSearch.UnsetSession();
            PrimaryAddressCountryID.AdvancedSearch.UnsetSession();
            PrimaryAddressHomeTel.AdvancedSearch.UnsetSession();
            AlternativeAddressDetail.AdvancedSearch.UnsetSession();
            AlternativeAddressState.AdvancedSearch.UnsetSession();
            AlternativeAddressCity.AdvancedSearch.UnsetSession();
            AlternativeAddressHomeTel.AdvancedSearch.UnsetSession();
            AlternativeAddressPostCode.AdvancedSearch.UnsetSession();
            AlternativeAddressCountryID.AdvancedSearch.UnsetSession();
            MobileNumber.AdvancedSearch.UnsetSession();
            _Email.AdvancedSearch.UnsetSession();
            EmployeeStatus.AdvancedSearch.UnsetSession();
            FormSubmittedDateTime.AdvancedSearch.UnsetSession();
            CreatedByUserID.AdvancedSearch.UnsetSession();
            CreatedDateTime.AdvancedSearch.UnsetSession();
            LastUpdatedByUserID.AdvancedSearch.UnsetSession();
            LastUpdatedDateTime.AdvancedSearch.UnsetSession();
            SocialSecurityNumber.AdvancedSearch.UnsetSession();
            SocialSecurityIssuingCountryID.AdvancedSearch.UnsetSession();
            SocialSecurityImage.AdvancedSearch.UnsetSession();
            PersonalTaxNumber.AdvancedSearch.UnsetSession();
            PersonalTaxIssuingCountryID.AdvancedSearch.UnsetSession();
            PersonalTaxImage.AdvancedSearch.UnsetSession();
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
            Nationality_CountryID.AdvancedSearch.Load();
            CountryOfOrigin_CountryID.AdvancedSearch.Load();
            DateOfBirth.AdvancedSearch.Load();
            CityOfBirth.AdvancedSearch.Load();
            Gender.AdvancedSearch.Load();
            MaritalStatus.AdvancedSearch.Load();
            ReligionID.AdvancedSearch.Load();
            BloodType.AdvancedSearch.Load();
            RankAppliedFor_RankID.AdvancedSearch.Load();
            WillAcceptLowRank.AdvancedSearch.Load();
            AvailableFrom.AdvancedSearch.Load();
            AvailableUntil.AdvancedSearch.Load();
            PrimaryAddressDetail.AdvancedSearch.Load();
            PrimaryAddressCity.AdvancedSearch.Load();
            PrimaryAddressNearestAirport.AdvancedSearch.Load();
            PrimaryAddressState.AdvancedSearch.Load();
            PrimaryAddressPostCode.AdvancedSearch.Load();
            PrimaryAddressCountryID.AdvancedSearch.Load();
            PrimaryAddressHomeTel.AdvancedSearch.Load();
            AlternativeAddressDetail.AdvancedSearch.Load();
            AlternativeAddressState.AdvancedSearch.Load();
            AlternativeAddressCity.AdvancedSearch.Load();
            AlternativeAddressHomeTel.AdvancedSearch.Load();
            AlternativeAddressPostCode.AdvancedSearch.Load();
            AlternativeAddressCountryID.AdvancedSearch.Load();
            MobileNumber.AdvancedSearch.Load();
            _Email.AdvancedSearch.Load();
            EmployeeStatus.AdvancedSearch.Load();
            FormSubmittedDateTime.AdvancedSearch.Load();
            CreatedByUserID.AdvancedSearch.Load();
            CreatedDateTime.AdvancedSearch.Load();
            LastUpdatedByUserID.AdvancedSearch.Load();
            LastUpdatedDateTime.AdvancedSearch.Load();
            SocialSecurityNumber.AdvancedSearch.Load();
            SocialSecurityIssuingCountryID.AdvancedSearch.Load();
            SocialSecurityImage.AdvancedSearch.Load();
            PersonalTaxNumber.AdvancedSearch.Load();
            PersonalTaxIssuingCountryID.AdvancedSearch.Load();
            PersonalTaxImage.AdvancedSearch.Load();
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
                UpdateSort(Nationality_CountryID, ctrl); // Nationality_CountryID
                UpdateSort(CountryOfOrigin_CountryID, ctrl); // CountryOfOrigin_CountryID
                UpdateSort(DateOfBirth, ctrl); // DateOfBirth
                UpdateSort(CityOfBirth, ctrl); // CityOfBirth
                UpdateSort(Gender, ctrl); // Gender
                UpdateSort(MaritalStatus, ctrl); // MaritalStatus
                UpdateSort(ReligionID, ctrl); // ReligionID
                UpdateSort(RankAppliedFor_RankID, ctrl); // RankAppliedFor_RankID
                UpdateSort(MobileNumber, ctrl); // MobileNumber
                UpdateSort(_Email, ctrl); // Email
                UpdateSort(EmployeeStatus, ctrl); // EmployeeStatus
                UpdateSort(FormSubmittedDateTime, ctrl); // FormSubmittedDateTime
                UpdateSort(CreatedByUserID, ctrl); // CreatedByUserID
                UpdateSort(CreatedDateTime, ctrl); // CreatedDateTime
                UpdateSort(LastUpdatedByUserID, ctrl); // LastUpdatedByUserID
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
                    ID.Sort = "";
                    IndividualCodeNumber.Sort = "";
                    FullName.Sort = "";
                    RequiredPhoto.Sort = "";
                    VisaPhoto.Sort = "";
                    Nationality_CountryID.Sort = "";
                    CountryOfOrigin_CountryID.Sort = "";
                    DateOfBirth.Sort = "";
                    CityOfBirth.Sort = "";
                    Gender.Sort = "";
                    MaritalStatus.Sort = "";
                    ReligionID.Sort = "";
                    BloodType.Sort = "";
                    RankAppliedFor_RankID.Sort = "";
                    WillAcceptLowRank.Sort = "";
                    AvailableFrom.Sort = "";
                    AvailableUntil.Sort = "";
                    PrimaryAddressDetail.Sort = "";
                    PrimaryAddressCity.Sort = "";
                    PrimaryAddressNearestAirport.Sort = "";
                    PrimaryAddressState.Sort = "";
                    PrimaryAddressPostCode.Sort = "";
                    PrimaryAddressCountryID.Sort = "";
                    PrimaryAddressHomeTel.Sort = "";
                    AlternativeAddressDetail.Sort = "";
                    AlternativeAddressState.Sort = "";
                    AlternativeAddressCity.Sort = "";
                    AlternativeAddressHomeTel.Sort = "";
                    AlternativeAddressPostCode.Sort = "";
                    AlternativeAddressCountryID.Sort = "";
                    MobileNumber.Sort = "";
                    _Email.Sort = "";
                    EmployeeStatus.Sort = "";
                    FormSubmittedDateTime.Sort = "";
                    ActiveDescription.Sort = "";
                    CreatedByUserID.Sort = "";
                    CreatedDateTime.Sort = "";
                    LastUpdatedByUserID.Sort = "";
                    LastUpdatedDateTime.Sort = "";
                    MTUserID.Sort = "";
                    SocialSecurityNumber.Sort = "";
                    SocialSecurityIssuingCountryID.Sort = "";
                    SocialSecurityImage.Sort = "";
                    PersonalTaxNumber.Sort = "";
                    PersonalTaxIssuingCountryID.Sort = "";
                    PersonalTaxImage.Sort = "";
                    Status.Sort = "";
                    Reason.Sort = "";
                    Weight.Sort = "";
                    Height.Sort = "";
                    CoverallSize.Sort = "";
                    SafetyShoesSize.Sort = "";
                    ShirtSize.Sort = "";
                    TrousersSize.Sort = "";
                    NomineeFullName.Sort = "";
                    NomineeRelationship.Sort = "";
                    NomineeGender.Sort = "";
                    NomineeNationality_CountryID.Sort = "";
                    NomineeAddressDetail.Sort = "";
                    NomineeAddressCity.Sort = "";
                    NomineeAddressPostCode.Sort = "";
                    NomineeAddressCountryID.Sort = "";
                    NomineeAddressHomeTel.Sort = "";
                    NomineeEmail.Sort = "";
                    NomineeMobileNumber.Sort = "";
                    NSSF_Health_Number.Sort = "";
                    NSSF_Occupation_Number.Sort = "";
                    NomineeRelationshipSelect.Sort = "";
                    NomineeRelationshipDetail.Sort = "";
                    MobileNumberCode_CountryID.Sort = "";
                    PrimaryAddressHomeTelCode_CountryID.Sort = "";
                    AlternativeAddressHomeTelCode_CountryID.Sort = "";
                    NomineeAddressHomeTelCode_CountryID.Sort = "";
                    NomineeMobileNumberCode_CountryID.Sort = "";
                    MTManningAgentID.Sort = "";
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

            // "edit"
            listOption = ListOptions["edit"];
            string editcaption = Language.Phrase("EditLink", true);
            isVisible = Security.CanEdit && ShowOptionLink("edit");
            if (isVisible) {
                if (ModalEdit && !IsMobile())
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-table=""CrewPersonalDataForAdmin"" data-caption=""{editcaption}"" data-ew-action=""modal"" data-action=""edit"" data-ajax=""" + (UseAjaxActions ? "true" : "false") + "\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\" data-btn=\"SaveBtn\">" + Language.Phrase("EditLink") + "</a>");
                else
                    listOption?.SetBody($@"<a class=""ew-row-link ew-edit"" title=""{editcaption}"" data-caption=""{editcaption}"" href=""" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("EditLink") + "</a>");
            } else {
                listOption?.Clear();
            }

            // "delete"
            listOption = ListOptions["delete"];
            isVisible = Security.CanDelete && ShowOptionLink("delete");
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
                        string link = "<li><button type=\"button\" class=\"dropdown-item ew-action ew-list-action\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fCrewPersonalDataForAdminlist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttrs() + ">" + icon + " " + caption + "</button></li>";
                        if (!Empty(link)) {
                            links.Add(link);
                            if (Empty(body)) // Setup first button
                                body = "<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlTitle(caption) + "\" data-caption=\"" + HtmlTitle(caption) + "\" data-ew-action=\"submit\" form=\"fCrewPersonalDataForAdminlist\" data-key=\"" + KeyToJson(true) + "\"" + act.ToDataAttrs() + ">" + icon + caption + "</button>";
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
                CreateColumnOption(option.Add("Nationality_CountryID")); // DN
                CreateColumnOption(option.Add("CountryOfOrigin_CountryID")); // DN
                CreateColumnOption(option.Add("DateOfBirth")); // DN
                CreateColumnOption(option.Add("CityOfBirth")); // DN
                CreateColumnOption(option.Add("Gender")); // DN
                CreateColumnOption(option.Add("MaritalStatus")); // DN
                CreateColumnOption(option.Add("ReligionID")); // DN
                CreateColumnOption(option.Add("RankAppliedFor_RankID")); // DN
                CreateColumnOption(option.Add("MobileNumber")); // DN
                CreateColumnOption(option.Add("Email")); // DN
                CreateColumnOption(option.Add("EmployeeStatus")); // DN
                CreateColumnOption(option.Add("FormSubmittedDateTime")); // DN
                CreateColumnOption(option.Add("CreatedByUserID")); // DN
                CreateColumnOption(option.Add("CreatedDateTime")); // DN
                CreateColumnOption(option.Add("LastUpdatedByUserID")); // DN
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
            item.Body = "<a class=\"ew-save-filter\" data-form=\"fCrewPersonalDataForAdminsrch\" data-ew-action=\"none\">" + Language.Phrase("SaveCurrentFilter") + "</a>";
            item.Visible = true;
            item = FilterOptions.Add("deletefilter");
            item.Body = "<a class=\"ew-delete-filter\" data-form=\"fCrewPersonalDataForAdminsrch\" data-ew-action=\"none\">" + Language.Phrase("DeleteFilter") + "</a>";
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
                    item.Body = "<<button type=\"button\" class=\"btn btn-default ew-action ew-list-action\" title=\"" + HtmlEncode(caption) + "\" data-caption=\"" + HtmlEncode(caption) + "\" data-ew-action=\"submit\" form=\"fCrewPersonalDataForAdminlist\"" + act.ToDataAttrs() + ">" + icon + "</button>";
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
                    RowAttrs.Add("id", "r0_CrewPersonalDataForAdmin");
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
            RowAttrs.Add("data-rowindex", ConvertToString(crewPersonalDataForAdminList.RowCount));
            RowAttrs.Add("data-key", GetKey(true));
            RowAttrs.Add("id", "r" + ConvertToString(crewPersonalDataForAdminList.RowCount) + "_CrewPersonalDataForAdmin");
            RowAttrs.Add("data-rowtype", ConvertToString((int)RowType));
            RowAttrs.AppendClass(crewPersonalDataForAdminList.RowCount % 2 != 1 ? "ew-table-alt-row" : "");
            if (IsAdd && crewPersonalDataForAdminList.RowType == RowType.Add || IsEdit && crewPersonalDataForAdminList.RowType == RowType.Edit) // Inline-Add/Edit row
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

            // Nationality_CountryID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_Nationality_CountryID[]"))
                    Nationality_CountryID.AdvancedSearch.SearchValue = Get("x_Nationality_CountryID[]");
                else
                    Nationality_CountryID.AdvancedSearch.SearchValue = Get("Nationality_CountryID"); // Default Value // DN
            if (!Empty(Nationality_CountryID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_Nationality_CountryID"))
                Nationality_CountryID.AdvancedSearch.SearchOperator = Get("z_Nationality_CountryID");

            // CountryOfOrigin_CountryID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CountryOfOrigin_CountryID[]"))
                    CountryOfOrigin_CountryID.AdvancedSearch.SearchValue = Get("x_CountryOfOrigin_CountryID[]");
                else
                    CountryOfOrigin_CountryID.AdvancedSearch.SearchValue = Get("CountryOfOrigin_CountryID"); // Default Value // DN
            if (!Empty(CountryOfOrigin_CountryID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CountryOfOrigin_CountryID"))
                CountryOfOrigin_CountryID.AdvancedSearch.SearchOperator = Get("z_CountryOfOrigin_CountryID");

            // DateOfBirth
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_DateOfBirth[]"))
                    DateOfBirth.AdvancedSearch.SearchValue = Get("x_DateOfBirth[]");
                else
                    DateOfBirth.AdvancedSearch.SearchValue = Get("DateOfBirth"); // Default Value // DN
            if (!Empty(DateOfBirth.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_DateOfBirth"))
                DateOfBirth.AdvancedSearch.SearchOperator = Get("z_DateOfBirth");

            // CityOfBirth
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_CityOfBirth[]"))
                    CityOfBirth.AdvancedSearch.SearchValue = Get("x_CityOfBirth[]");
                else
                    CityOfBirth.AdvancedSearch.SearchValue = Get("CityOfBirth"); // Default Value // DN
            if (!Empty(CityOfBirth.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_CityOfBirth"))
                CityOfBirth.AdvancedSearch.SearchOperator = Get("z_CityOfBirth");

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

            // MaritalStatus
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_MaritalStatus[]"))
                    MaritalStatus.AdvancedSearch.SearchValue = Get("x_MaritalStatus[]");
                else
                    MaritalStatus.AdvancedSearch.SearchValue = Get("MaritalStatus"); // Default Value // DN
            if (!Empty(MaritalStatus.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_MaritalStatus"))
                MaritalStatus.AdvancedSearch.SearchOperator = Get("z_MaritalStatus");

            // ReligionID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_ReligionID[]"))
                    ReligionID.AdvancedSearch.SearchValue = Get("x_ReligionID[]");
                else
                    ReligionID.AdvancedSearch.SearchValue = Get("ReligionID"); // Default Value // DN
            if (!Empty(ReligionID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_ReligionID"))
                ReligionID.AdvancedSearch.SearchOperator = Get("z_ReligionID");

            // BloodType
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_BloodType"))
                    BloodType.AdvancedSearch.SearchValue = Get("x_BloodType");
                else
                    BloodType.AdvancedSearch.SearchValue = Get("BloodType"); // Default Value // DN
            if (!Empty(BloodType.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_BloodType"))
                BloodType.AdvancedSearch.SearchOperator = Get("z_BloodType");

            // RankAppliedFor_RankID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_RankAppliedFor_RankID[]"))
                    RankAppliedFor_RankID.AdvancedSearch.SearchValue = Get("x_RankAppliedFor_RankID[]");
                else
                    RankAppliedFor_RankID.AdvancedSearch.SearchValue = Get("RankAppliedFor_RankID"); // Default Value // DN
            if (!Empty(RankAppliedFor_RankID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_RankAppliedFor_RankID"))
                RankAppliedFor_RankID.AdvancedSearch.SearchOperator = Get("z_RankAppliedFor_RankID");

            // WillAcceptLowRank
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_WillAcceptLowRank"))
                    WillAcceptLowRank.AdvancedSearch.SearchValue = Get("x_WillAcceptLowRank");
                else
                    WillAcceptLowRank.AdvancedSearch.SearchValue = Get("WillAcceptLowRank"); // Default Value // DN
            if (!Empty(WillAcceptLowRank.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_WillAcceptLowRank"))
                WillAcceptLowRank.AdvancedSearch.SearchOperator = Get("z_WillAcceptLowRank");

            // AvailableFrom
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AvailableFrom"))
                    AvailableFrom.AdvancedSearch.SearchValue = Get("x_AvailableFrom");
                else
                    AvailableFrom.AdvancedSearch.SearchValue = Get("AvailableFrom"); // Default Value // DN
            if (!Empty(AvailableFrom.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AvailableFrom"))
                AvailableFrom.AdvancedSearch.SearchOperator = Get("z_AvailableFrom");

            // AvailableUntil
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AvailableUntil"))
                    AvailableUntil.AdvancedSearch.SearchValue = Get("x_AvailableUntil");
                else
                    AvailableUntil.AdvancedSearch.SearchValue = Get("AvailableUntil"); // Default Value // DN
            if (!Empty(AvailableUntil.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AvailableUntil"))
                AvailableUntil.AdvancedSearch.SearchOperator = Get("z_AvailableUntil");

            // PrimaryAddressDetail
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PrimaryAddressDetail"))
                    PrimaryAddressDetail.AdvancedSearch.SearchValue = Get("x_PrimaryAddressDetail");
                else
                    PrimaryAddressDetail.AdvancedSearch.SearchValue = Get("PrimaryAddressDetail"); // Default Value // DN
            if (!Empty(PrimaryAddressDetail.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PrimaryAddressDetail"))
                PrimaryAddressDetail.AdvancedSearch.SearchOperator = Get("z_PrimaryAddressDetail");

            // PrimaryAddressCity
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PrimaryAddressCity"))
                    PrimaryAddressCity.AdvancedSearch.SearchValue = Get("x_PrimaryAddressCity");
                else
                    PrimaryAddressCity.AdvancedSearch.SearchValue = Get("PrimaryAddressCity"); // Default Value // DN
            if (!Empty(PrimaryAddressCity.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PrimaryAddressCity"))
                PrimaryAddressCity.AdvancedSearch.SearchOperator = Get("z_PrimaryAddressCity");

            // PrimaryAddressNearestAirport
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PrimaryAddressNearestAirport"))
                    PrimaryAddressNearestAirport.AdvancedSearch.SearchValue = Get("x_PrimaryAddressNearestAirport");
                else
                    PrimaryAddressNearestAirport.AdvancedSearch.SearchValue = Get("PrimaryAddressNearestAirport"); // Default Value // DN
            if (!Empty(PrimaryAddressNearestAirport.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PrimaryAddressNearestAirport"))
                PrimaryAddressNearestAirport.AdvancedSearch.SearchOperator = Get("z_PrimaryAddressNearestAirport");

            // PrimaryAddressState
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PrimaryAddressState"))
                    PrimaryAddressState.AdvancedSearch.SearchValue = Get("x_PrimaryAddressState");
                else
                    PrimaryAddressState.AdvancedSearch.SearchValue = Get("PrimaryAddressState"); // Default Value // DN
            if (!Empty(PrimaryAddressState.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PrimaryAddressState"))
                PrimaryAddressState.AdvancedSearch.SearchOperator = Get("z_PrimaryAddressState");

            // PrimaryAddressPostCode
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PrimaryAddressPostCode"))
                    PrimaryAddressPostCode.AdvancedSearch.SearchValue = Get("x_PrimaryAddressPostCode");
                else
                    PrimaryAddressPostCode.AdvancedSearch.SearchValue = Get("PrimaryAddressPostCode"); // Default Value // DN
            if (!Empty(PrimaryAddressPostCode.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PrimaryAddressPostCode"))
                PrimaryAddressPostCode.AdvancedSearch.SearchOperator = Get("z_PrimaryAddressPostCode");

            // PrimaryAddressCountryID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PrimaryAddressCountryID"))
                    PrimaryAddressCountryID.AdvancedSearch.SearchValue = Get("x_PrimaryAddressCountryID");
                else
                    PrimaryAddressCountryID.AdvancedSearch.SearchValue = Get("PrimaryAddressCountryID"); // Default Value // DN
            if (!Empty(PrimaryAddressCountryID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PrimaryAddressCountryID"))
                PrimaryAddressCountryID.AdvancedSearch.SearchOperator = Get("z_PrimaryAddressCountryID");

            // PrimaryAddressHomeTel
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PrimaryAddressHomeTel"))
                    PrimaryAddressHomeTel.AdvancedSearch.SearchValue = Get("x_PrimaryAddressHomeTel");
                else
                    PrimaryAddressHomeTel.AdvancedSearch.SearchValue = Get("PrimaryAddressHomeTel"); // Default Value // DN
            if (!Empty(PrimaryAddressHomeTel.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PrimaryAddressHomeTel"))
                PrimaryAddressHomeTel.AdvancedSearch.SearchOperator = Get("z_PrimaryAddressHomeTel");

            // AlternativeAddressDetail
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AlternativeAddressDetail"))
                    AlternativeAddressDetail.AdvancedSearch.SearchValue = Get("x_AlternativeAddressDetail");
                else
                    AlternativeAddressDetail.AdvancedSearch.SearchValue = Get("AlternativeAddressDetail"); // Default Value // DN
            if (!Empty(AlternativeAddressDetail.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AlternativeAddressDetail"))
                AlternativeAddressDetail.AdvancedSearch.SearchOperator = Get("z_AlternativeAddressDetail");

            // AlternativeAddressState
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AlternativeAddressState"))
                    AlternativeAddressState.AdvancedSearch.SearchValue = Get("x_AlternativeAddressState");
                else
                    AlternativeAddressState.AdvancedSearch.SearchValue = Get("AlternativeAddressState"); // Default Value // DN
            if (!Empty(AlternativeAddressState.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AlternativeAddressState"))
                AlternativeAddressState.AdvancedSearch.SearchOperator = Get("z_AlternativeAddressState");

            // AlternativeAddressCity
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AlternativeAddressCity"))
                    AlternativeAddressCity.AdvancedSearch.SearchValue = Get("x_AlternativeAddressCity");
                else
                    AlternativeAddressCity.AdvancedSearch.SearchValue = Get("AlternativeAddressCity"); // Default Value // DN
            if (!Empty(AlternativeAddressCity.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AlternativeAddressCity"))
                AlternativeAddressCity.AdvancedSearch.SearchOperator = Get("z_AlternativeAddressCity");

            // AlternativeAddressHomeTel
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AlternativeAddressHomeTel"))
                    AlternativeAddressHomeTel.AdvancedSearch.SearchValue = Get("x_AlternativeAddressHomeTel");
                else
                    AlternativeAddressHomeTel.AdvancedSearch.SearchValue = Get("AlternativeAddressHomeTel"); // Default Value // DN
            if (!Empty(AlternativeAddressHomeTel.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AlternativeAddressHomeTel"))
                AlternativeAddressHomeTel.AdvancedSearch.SearchOperator = Get("z_AlternativeAddressHomeTel");

            // AlternativeAddressPostCode
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AlternativeAddressPostCode"))
                    AlternativeAddressPostCode.AdvancedSearch.SearchValue = Get("x_AlternativeAddressPostCode");
                else
                    AlternativeAddressPostCode.AdvancedSearch.SearchValue = Get("AlternativeAddressPostCode"); // Default Value // DN
            if (!Empty(AlternativeAddressPostCode.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AlternativeAddressPostCode"))
                AlternativeAddressPostCode.AdvancedSearch.SearchOperator = Get("z_AlternativeAddressPostCode");

            // AlternativeAddressCountryID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_AlternativeAddressCountryID"))
                    AlternativeAddressCountryID.AdvancedSearch.SearchValue = Get("x_AlternativeAddressCountryID");
                else
                    AlternativeAddressCountryID.AdvancedSearch.SearchValue = Get("AlternativeAddressCountryID"); // Default Value // DN
            if (!Empty(AlternativeAddressCountryID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_AlternativeAddressCountryID"))
                AlternativeAddressCountryID.AdvancedSearch.SearchOperator = Get("z_AlternativeAddressCountryID");

            // MobileNumber
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_MobileNumber[]"))
                    MobileNumber.AdvancedSearch.SearchValue = Get("x_MobileNumber[]");
                else
                    MobileNumber.AdvancedSearch.SearchValue = Get("MobileNumber"); // Default Value // DN
            if (!Empty(MobileNumber.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_MobileNumber"))
                MobileNumber.AdvancedSearch.SearchOperator = Get("z_MobileNumber");

            // _Email
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x__Email[]"))
                    _Email.AdvancedSearch.SearchValue = Get("x__Email[]");
                else
                    _Email.AdvancedSearch.SearchValue = Get("_Email"); // Default Value // DN
            if (!Empty(_Email.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z__Email"))
                _Email.AdvancedSearch.SearchOperator = Get("z__Email");

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

            // FormSubmittedDateTime
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_FormSubmittedDateTime[]"))
                    FormSubmittedDateTime.AdvancedSearch.SearchValue = Get("x_FormSubmittedDateTime[]");
                else
                    FormSubmittedDateTime.AdvancedSearch.SearchValue = Get("FormSubmittedDateTime"); // Default Value // DN
            if (!Empty(FormSubmittedDateTime.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_FormSubmittedDateTime"))
                FormSubmittedDateTime.AdvancedSearch.SearchOperator = Get("z_FormSubmittedDateTime");

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

            // SocialSecurityNumber
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_SocialSecurityNumber"))
                    SocialSecurityNumber.AdvancedSearch.SearchValue = Get("x_SocialSecurityNumber");
                else
                    SocialSecurityNumber.AdvancedSearch.SearchValue = Get("SocialSecurityNumber"); // Default Value // DN
            if (!Empty(SocialSecurityNumber.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_SocialSecurityNumber"))
                SocialSecurityNumber.AdvancedSearch.SearchOperator = Get("z_SocialSecurityNumber");

            // SocialSecurityIssuingCountryID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_SocialSecurityIssuingCountryID"))
                    SocialSecurityIssuingCountryID.AdvancedSearch.SearchValue = Get("x_SocialSecurityIssuingCountryID");
                else
                    SocialSecurityIssuingCountryID.AdvancedSearch.SearchValue = Get("SocialSecurityIssuingCountryID"); // Default Value // DN
            if (!Empty(SocialSecurityIssuingCountryID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_SocialSecurityIssuingCountryID"))
                SocialSecurityIssuingCountryID.AdvancedSearch.SearchOperator = Get("z_SocialSecurityIssuingCountryID");

            // SocialSecurityImage
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_SocialSecurityImage"))
                    SocialSecurityImage.AdvancedSearch.SearchValue = Get("x_SocialSecurityImage");
                else
                    SocialSecurityImage.AdvancedSearch.SearchValue = Get("SocialSecurityImage"); // Default Value // DN
            if (!Empty(SocialSecurityImage.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_SocialSecurityImage"))
                SocialSecurityImage.AdvancedSearch.SearchOperator = Get("z_SocialSecurityImage");

            // PersonalTaxNumber
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PersonalTaxNumber"))
                    PersonalTaxNumber.AdvancedSearch.SearchValue = Get("x_PersonalTaxNumber");
                else
                    PersonalTaxNumber.AdvancedSearch.SearchValue = Get("PersonalTaxNumber"); // Default Value // DN
            if (!Empty(PersonalTaxNumber.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PersonalTaxNumber"))
                PersonalTaxNumber.AdvancedSearch.SearchOperator = Get("z_PersonalTaxNumber");

            // PersonalTaxIssuingCountryID
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PersonalTaxIssuingCountryID"))
                    PersonalTaxIssuingCountryID.AdvancedSearch.SearchValue = Get("x_PersonalTaxIssuingCountryID");
                else
                    PersonalTaxIssuingCountryID.AdvancedSearch.SearchValue = Get("PersonalTaxIssuingCountryID"); // Default Value // DN
            if (!Empty(PersonalTaxIssuingCountryID.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PersonalTaxIssuingCountryID"))
                PersonalTaxIssuingCountryID.AdvancedSearch.SearchOperator = Get("z_PersonalTaxIssuingCountryID");

            // PersonalTaxImage
            if (!IsAddOrEdit)
                if (Query.ContainsKey("x_PersonalTaxImage"))
                    PersonalTaxImage.AdvancedSearch.SearchValue = Get("x_PersonalTaxImage");
                else
                    PersonalTaxImage.AdvancedSearch.SearchValue = Get("PersonalTaxImage"); // Default Value // DN
            if (!Empty(PersonalTaxImage.AdvancedSearch.SearchValue) && Command == "")
                Command = "search";
            if (Query.ContainsKey("z_PersonalTaxImage"))
                PersonalTaxImage.AdvancedSearch.SearchOperator = Get("z_PersonalTaxImage");
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
            RequiredPhoto.Upload.DbValue = row["RequiredPhoto"];
            RequiredPhoto.SetDbValue(RequiredPhoto.Upload.DbValue);
            VisaPhoto.Upload.DbValue = row["VisaPhoto"];
            VisaPhoto.SetDbValue(VisaPhoto.Upload.DbValue);
            Nationality_CountryID.SetDbValue(row["Nationality_CountryID"]);
            CountryOfOrigin_CountryID.SetDbValue(row["CountryOfOrigin_CountryID"]);
            DateOfBirth.SetDbValue(row["DateOfBirth"]);
            CityOfBirth.SetDbValue(row["CityOfBirth"]);
            Gender.SetDbValue(row["Gender"]);
            MaritalStatus.SetDbValue(row["MaritalStatus"]);
            ReligionID.SetDbValue(row["ReligionID"]);
            BloodType.SetDbValue(row["BloodType"]);
            RankAppliedFor_RankID.SetDbValue(row["RankAppliedFor_RankID"]);
            WillAcceptLowRank.SetDbValue((ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"));
            AvailableFrom.SetDbValue(row["AvailableFrom"]);
            AvailableUntil.SetDbValue(row["AvailableUntil"]);
            PrimaryAddressDetail.SetDbValue(row["PrimaryAddressDetail"]);
            PrimaryAddressCity.SetDbValue(row["PrimaryAddressCity"]);
            PrimaryAddressNearestAirport.SetDbValue(row["PrimaryAddressNearestAirport"]);
            PrimaryAddressState.SetDbValue(row["PrimaryAddressState"]);
            PrimaryAddressPostCode.SetDbValue(row["PrimaryAddressPostCode"]);
            PrimaryAddressCountryID.SetDbValue(row["PrimaryAddressCountryID"]);
            PrimaryAddressHomeTel.SetDbValue(row["PrimaryAddressHomeTel"]);
            AlternativeAddressDetail.SetDbValue(row["AlternativeAddressDetail"]);
            AlternativeAddressState.SetDbValue(row["AlternativeAddressState"]);
            AlternativeAddressCity.SetDbValue(row["AlternativeAddressCity"]);
            AlternativeAddressHomeTel.SetDbValue(row["AlternativeAddressHomeTel"]);
            AlternativeAddressPostCode.SetDbValue(row["AlternativeAddressPostCode"]);
            AlternativeAddressCountryID.SetDbValue(row["AlternativeAddressCountryID"]);
            MobileNumber.SetDbValue(row["MobileNumber"]);
            _Email.SetDbValue(row["Email"]);
            EmployeeStatus.SetDbValue(row["EmployeeStatus"]);
            FormSubmittedDateTime.SetDbValue(row["FormSubmittedDateTime"]);
            ActiveDescription.SetDbValue(row["ActiveDescription"]);
            CreatedByUserID.SetDbValue(row["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(row["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(row["MTUserID"]);
            SocialSecurityNumber.SetDbValue(row["SocialSecurityNumber"]);
            SocialSecurityIssuingCountryID.SetDbValue(row["SocialSecurityIssuingCountryID"]);
            SocialSecurityImage.Upload.DbValue = row["SocialSecurityImage"];
            SocialSecurityImage.SetDbValue(SocialSecurityImage.Upload.DbValue);
            PersonalTaxNumber.SetDbValue(row["PersonalTaxNumber"]);
            PersonalTaxIssuingCountryID.SetDbValue(row["PersonalTaxIssuingCountryID"]);
            PersonalTaxImage.Upload.DbValue = row["PersonalTaxImage"];
            PersonalTaxImage.SetDbValue(PersonalTaxImage.Upload.DbValue);
            Status.SetDbValue(row["Status"]);
            Reason.SetDbValue(row["Reason"]);
            Weight.SetDbValue(row["Weight"]);
            Height.SetDbValue(row["Height"]);
            CoverallSize.SetDbValue(row["CoverallSize"]);
            SafetyShoesSize.SetDbValue(row["SafetyShoesSize"]);
            ShirtSize.SetDbValue(row["ShirtSize"]);
            TrousersSize.SetDbValue(row["TrousersSize"]);
            NomineeFullName.SetDbValue(row["NomineeFullName"]);
            NomineeRelationship.SetDbValue(row["NomineeRelationship"]);
            NomineeGender.SetDbValue(row["NomineeGender"]);
            NomineeNationality_CountryID.SetDbValue(row["NomineeNationality_CountryID"]);
            NomineeAddressDetail.SetDbValue(row["NomineeAddressDetail"]);
            NomineeAddressCity.SetDbValue(row["NomineeAddressCity"]);
            NomineeAddressPostCode.SetDbValue(row["NomineeAddressPostCode"]);
            NomineeAddressCountryID.SetDbValue(row["NomineeAddressCountryID"]);
            NomineeAddressHomeTel.SetDbValue(row["NomineeAddressHomeTel"]);
            NomineeEmail.SetDbValue(row["NomineeEmail"]);
            NomineeMobileNumber.SetDbValue(row["NomineeMobileNumber"]);
            NSSF_Health_Number.SetDbValue(row["NSSF_Health_Number"]);
            NSSF_Occupation_Number.SetDbValue(row["NSSF_Occupation_Number"]);
            NomineeRelationshipSelect.SetDbValue(row["NomineeRelationshipSelect"]);
            NomineeRelationshipDetail.SetDbValue(row["NomineeRelationshipDetail"]);
            MobileNumberCode_CountryID.SetDbValue(row["MobileNumberCode_CountryID"]);
            PrimaryAddressHomeTelCode_CountryID.SetDbValue(row["PrimaryAddressHomeTelCode_CountryID"]);
            AlternativeAddressHomeTelCode_CountryID.SetDbValue(row["AlternativeAddressHomeTelCode_CountryID"]);
            NomineeAddressHomeTelCode_CountryID.SetDbValue(row["NomineeAddressHomeTelCode_CountryID"]);
            NomineeMobileNumberCode_CountryID.SetDbValue(row["NomineeMobileNumberCode_CountryID"]);
            MTManningAgentID.SetDbValue(row["MTManningAgentID"]);
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
            row.Add("Nationality_CountryID", Nationality_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("CountryOfOrigin_CountryID", CountryOfOrigin_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("DateOfBirth", DateOfBirth.DefaultValue ?? DbNullValue); // DN
            row.Add("CityOfBirth", CityOfBirth.DefaultValue ?? DbNullValue); // DN
            row.Add("Gender", Gender.DefaultValue ?? DbNullValue); // DN
            row.Add("MaritalStatus", MaritalStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("ReligionID", ReligionID.DefaultValue ?? DbNullValue); // DN
            row.Add("BloodType", BloodType.DefaultValue ?? DbNullValue); // DN
            row.Add("RankAppliedFor_RankID", RankAppliedFor_RankID.DefaultValue ?? DbNullValue); // DN
            row.Add("WillAcceptLowRank", WillAcceptLowRank.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableFrom", AvailableFrom.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableUntil", AvailableUntil.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressDetail", PrimaryAddressDetail.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressCity", PrimaryAddressCity.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressNearestAirport", PrimaryAddressNearestAirport.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressState", PrimaryAddressState.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressPostCode", PrimaryAddressPostCode.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressCountryID", PrimaryAddressCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressHomeTel", PrimaryAddressHomeTel.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressDetail", AlternativeAddressDetail.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressState", AlternativeAddressState.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressCity", AlternativeAddressCity.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressHomeTel", AlternativeAddressHomeTel.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressPostCode", AlternativeAddressPostCode.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressCountryID", AlternativeAddressCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("MobileNumber", MobileNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("EmployeeStatus", EmployeeStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("FormSubmittedDateTime", FormSubmittedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("ActiveDescription", ActiveDescription.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedByUserID", CreatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("MTUserID", MTUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("SocialSecurityNumber", SocialSecurityNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("SocialSecurityIssuingCountryID", SocialSecurityIssuingCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("SocialSecurityImage", SocialSecurityImage.DefaultValue ?? DbNullValue); // DN
            row.Add("PersonalTaxNumber", PersonalTaxNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("PersonalTaxIssuingCountryID", PersonalTaxIssuingCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("PersonalTaxImage", PersonalTaxImage.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("Reason", Reason.DefaultValue ?? DbNullValue); // DN
            row.Add("Weight", Weight.DefaultValue ?? DbNullValue); // DN
            row.Add("Height", Height.DefaultValue ?? DbNullValue); // DN
            row.Add("CoverallSize", CoverallSize.DefaultValue ?? DbNullValue); // DN
            row.Add("SafetyShoesSize", SafetyShoesSize.DefaultValue ?? DbNullValue); // DN
            row.Add("ShirtSize", ShirtSize.DefaultValue ?? DbNullValue); // DN
            row.Add("TrousersSize", TrousersSize.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeFullName", NomineeFullName.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeRelationship", NomineeRelationship.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeGender", NomineeGender.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeNationality_CountryID", NomineeNationality_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeAddressDetail", NomineeAddressDetail.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeAddressCity", NomineeAddressCity.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeAddressPostCode", NomineeAddressPostCode.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeAddressCountryID", NomineeAddressCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeAddressHomeTel", NomineeAddressHomeTel.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeEmail", NomineeEmail.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeMobileNumber", NomineeMobileNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("NSSF_Health_Number", NSSF_Health_Number.DefaultValue ?? DbNullValue); // DN
            row.Add("NSSF_Occupation_Number", NSSF_Occupation_Number.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeRelationshipSelect", NomineeRelationshipSelect.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeRelationshipDetail", NomineeRelationshipDetail.DefaultValue ?? DbNullValue); // DN
            row.Add("MobileNumberCode_CountryID", MobileNumberCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressHomeTelCode_CountryID", PrimaryAddressHomeTelCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressHomeTelCode_CountryID", AlternativeAddressHomeTelCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeAddressHomeTelCode_CountryID", NomineeAddressHomeTelCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeMobileNumberCode_CountryID", NomineeMobileNumberCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTManningAgentID", MTManningAgentID.DefaultValue ?? DbNullValue); // DN
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

            // Nationality_CountryID
            Nationality_CountryID.CellCssStyle = "white-space: nowrap;";

            // CountryOfOrigin_CountryID
            CountryOfOrigin_CountryID.CellCssStyle = "white-space: nowrap;";

            // DateOfBirth
            DateOfBirth.CellCssStyle = "white-space: nowrap;";

            // CityOfBirth
            CityOfBirth.CellCssStyle = "white-space: nowrap;";

            // Gender
            Gender.CellCssStyle = "white-space: nowrap;";

            // MaritalStatus
            MaritalStatus.CellCssStyle = "white-space: nowrap;";

            // ReligionID
            ReligionID.CellCssStyle = "white-space: nowrap;";

            // BloodType
            BloodType.CellCssStyle = "white-space: nowrap;";

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.CellCssStyle = "white-space: nowrap;";

            // WillAcceptLowRank
            WillAcceptLowRank.CellCssStyle = "white-space: nowrap;";

            // AvailableFrom
            AvailableFrom.CellCssStyle = "white-space: nowrap;";

            // AvailableUntil
            AvailableUntil.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressDetail
            PrimaryAddressDetail.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressCity
            PrimaryAddressCity.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressState
            PrimaryAddressState.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressDetail
            AlternativeAddressDetail.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressState
            AlternativeAddressState.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressCity
            AlternativeAddressCity.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressHomeTel
            AlternativeAddressHomeTel.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressPostCode
            AlternativeAddressPostCode.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressCountryID
            AlternativeAddressCountryID.CellCssStyle = "white-space: nowrap;";

            // MobileNumber
            MobileNumber.CellCssStyle = "white-space: nowrap;";

            // Email
            _Email.CellCssStyle = "white-space: nowrap;";

            // EmployeeStatus
            EmployeeStatus.CellCssStyle = "white-space: nowrap;";

            // FormSubmittedDateTime
            FormSubmittedDateTime.CellCssStyle = "white-space: nowrap;";

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

            // SocialSecurityNumber
            SocialSecurityNumber.CellCssStyle = "white-space: nowrap;";

            // SocialSecurityIssuingCountryID
            SocialSecurityIssuingCountryID.CellCssStyle = "white-space: nowrap;";

            // SocialSecurityImage
            SocialSecurityImage.CellCssStyle = "white-space: nowrap;";

            // PersonalTaxNumber
            PersonalTaxNumber.CellCssStyle = "white-space: nowrap;";

            // PersonalTaxIssuingCountryID
            PersonalTaxIssuingCountryID.CellCssStyle = "white-space: nowrap;";

            // PersonalTaxImage
            PersonalTaxImage.CellCssStyle = "white-space: nowrap;";

            // Status
            Status.CellCssStyle = "white-space: nowrap;";

            // Reason
            Reason.CellCssStyle = "white-space: nowrap;";

            // Weight
            Weight.CellCssStyle = "white-space: nowrap;";

            // Height
            Height.CellCssStyle = "white-space: nowrap;";

            // CoverallSize
            CoverallSize.CellCssStyle = "white-space: nowrap;";

            // SafetyShoesSize
            SafetyShoesSize.CellCssStyle = "white-space: nowrap;";

            // ShirtSize
            ShirtSize.CellCssStyle = "white-space: nowrap;";

            // TrousersSize
            TrousersSize.CellCssStyle = "white-space: nowrap;";

            // NomineeFullName
            NomineeFullName.CellCssStyle = "white-space: nowrap;";

            // NomineeRelationship
            NomineeRelationship.CellCssStyle = "white-space: nowrap;";

            // NomineeGender
            NomineeGender.CellCssStyle = "white-space: nowrap;";

            // NomineeNationality_CountryID
            NomineeNationality_CountryID.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressDetail
            NomineeAddressDetail.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressCity
            NomineeAddressCity.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressPostCode
            NomineeAddressPostCode.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressCountryID
            NomineeAddressCountryID.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressHomeTel
            NomineeAddressHomeTel.CellCssStyle = "white-space: nowrap;";

            // NomineeEmail
            NomineeEmail.CellCssStyle = "white-space: nowrap;";

            // NomineeMobileNumber
            NomineeMobileNumber.CellCssStyle = "white-space: nowrap;";

            // NSSF_Health_Number
            NSSF_Health_Number.CellCssStyle = "white-space: nowrap;";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.CellCssStyle = "white-space: nowrap;";

            // NomineeRelationshipSelect
            NomineeRelationshipSelect.CellCssStyle = "white-space: nowrap;";

            // NomineeRelationshipDetail
            NomineeRelationshipDetail.CellCssStyle = "white-space: nowrap;";

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressHomeTelCode_CountryID
            PrimaryAddressHomeTelCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressHomeTelCode_CountryID
            AlternativeAddressHomeTelCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressHomeTelCode_CountryID
            NomineeAddressHomeTelCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // NomineeMobileNumberCode_CountryID
            NomineeMobileNumberCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // MTManningAgentID
            MTManningAgentID.CellCssStyle = "white-space: nowrap;";

            // View row
            if (RowType == RowType.View) {
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
                VisaPhoto.ViewCustomAttributes = "";

                // Nationality_CountryID
                curVal = ConvertToString(Nationality_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (Nationality_CountryID.Lookup != null && IsDictionary(Nationality_CountryID.Lookup?.Options) && Nationality_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Nationality_CountryID.ViewValue = Nationality_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", Nationality_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = Nationality_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Nationality_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = Nationality_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            Nationality_CountryID.ViewValue = Nationality_CountryID.HighlightLookup(ConvertToString(rswrk[0]), Nationality_CountryID.DisplayValue(listwrk));
                        } else {
                            Nationality_CountryID.ViewValue = FormatNumber(Nationality_CountryID.CurrentValue, Nationality_CountryID.FormatPattern);
                        }
                    }
                } else {
                    Nationality_CountryID.ViewValue = DbNullValue;
                }
                Nationality_CountryID.ViewCustomAttributes = "";

                // CountryOfOrigin_CountryID
                curVal = ConvertToString(CountryOfOrigin_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (CountryOfOrigin_CountryID.Lookup != null && IsDictionary(CountryOfOrigin_CountryID.Lookup?.Options) && CountryOfOrigin_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        CountryOfOrigin_CountryID.ViewValue = CountryOfOrigin_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", CountryOfOrigin_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = CountryOfOrigin_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && CountryOfOrigin_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = CountryOfOrigin_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            CountryOfOrigin_CountryID.ViewValue = CountryOfOrigin_CountryID.HighlightLookup(ConvertToString(rswrk[0]), CountryOfOrigin_CountryID.DisplayValue(listwrk));
                        } else {
                            CountryOfOrigin_CountryID.ViewValue = FormatNumber(CountryOfOrigin_CountryID.CurrentValue, CountryOfOrigin_CountryID.FormatPattern);
                        }
                    }
                } else {
                    CountryOfOrigin_CountryID.ViewValue = DbNullValue;
                }
                CountryOfOrigin_CountryID.ViewCustomAttributes = "";

                // DateOfBirth
                DateOfBirth.ViewValue = DateOfBirth.CurrentValue;
                DateOfBirth.ViewValue = FormatDateTime(DateOfBirth.ViewValue, DateOfBirth.FormatPattern);
                DateOfBirth.ViewCustomAttributes = "";

                // CityOfBirth
                CityOfBirth.ViewValue = ConvertToString(CityOfBirth.CurrentValue); // DN
                CityOfBirth.ViewCustomAttributes = "";

                // Gender
                if (!Empty(Gender.CurrentValue)) {
                    Gender.ViewValue = Gender.HighlightLookup(ConvertToString(Gender.CurrentValue), Gender.OptionCaption(ConvertToString(Gender.CurrentValue)));
                } else {
                    Gender.ViewValue = DbNullValue;
                }
                Gender.ViewCustomAttributes = "";

                // MaritalStatus
                if (!Empty(MaritalStatus.CurrentValue)) {
                    MaritalStatus.ViewValue = MaritalStatus.HighlightLookup(ConvertToString(MaritalStatus.CurrentValue), MaritalStatus.OptionCaption(ConvertToString(MaritalStatus.CurrentValue)));
                } else {
                    MaritalStatus.ViewValue = DbNullValue;
                }
                MaritalStatus.ViewCustomAttributes = "";

                // ReligionID
                curVal = ConvertToString(ReligionID.CurrentValue);
                if (!Empty(curVal)) {
                    if (ReligionID.Lookup != null && IsDictionary(ReligionID.Lookup?.Options) && ReligionID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        ReligionID.ViewValue = ReligionID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", ReligionID.CurrentValue, DataType.Number, "");
                        sqlWrk = ReligionID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && ReligionID.Lookup != null) { // Lookup values found
                            var listwrk = ReligionID.Lookup?.RenderViewRow(rswrk[0]);
                            ReligionID.ViewValue = ReligionID.HighlightLookup(ConvertToString(rswrk[0]), ReligionID.DisplayValue(listwrk));
                        } else {
                            ReligionID.ViewValue = FormatNumber(ReligionID.CurrentValue, ReligionID.FormatPattern);
                        }
                    }
                } else {
                    ReligionID.ViewValue = DbNullValue;
                }
                ReligionID.ViewCustomAttributes = "";

                // BloodType
                if (!Empty(BloodType.CurrentValue)) {
                    BloodType.ViewValue = BloodType.HighlightLookup(ConvertToString(BloodType.CurrentValue), BloodType.OptionCaption(ConvertToString(BloodType.CurrentValue)));
                } else {
                    BloodType.ViewValue = DbNullValue;
                }
                BloodType.ViewCustomAttributes = "";

                // RankAppliedFor_RankID
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

                // PrimaryAddressDetail
                PrimaryAddressDetail.ViewValue = PrimaryAddressDetail.CurrentValue;
                PrimaryAddressDetail.ViewCustomAttributes = "";

                // PrimaryAddressCity
                PrimaryAddressCity.ViewValue = ConvertToString(PrimaryAddressCity.CurrentValue); // DN
                PrimaryAddressCity.ViewCustomAttributes = "";

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.ViewValue = ConvertToString(PrimaryAddressNearestAirport.CurrentValue); // DN
                PrimaryAddressNearestAirport.ViewCustomAttributes = "";

                // PrimaryAddressState
                PrimaryAddressState.ViewValue = ConvertToString(PrimaryAddressState.CurrentValue); // DN
                PrimaryAddressState.ViewCustomAttributes = "";

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.ViewValue = ConvertToString(PrimaryAddressPostCode.CurrentValue); // DN
                PrimaryAddressPostCode.ViewCustomAttributes = "";

                // PrimaryAddressCountryID
                curVal = ConvertToString(PrimaryAddressCountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (PrimaryAddressCountryID.Lookup != null && IsDictionary(PrimaryAddressCountryID.Lookup?.Options) && PrimaryAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PrimaryAddressCountryID.ViewValue = PrimaryAddressCountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", PrimaryAddressCountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = PrimaryAddressCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && PrimaryAddressCountryID.Lookup != null) { // Lookup values found
                            var listwrk = PrimaryAddressCountryID.Lookup?.RenderViewRow(rswrk[0]);
                            PrimaryAddressCountryID.ViewValue = PrimaryAddressCountryID.HighlightLookup(ConvertToString(rswrk[0]), PrimaryAddressCountryID.DisplayValue(listwrk));
                        } else {
                            PrimaryAddressCountryID.ViewValue = FormatNumber(PrimaryAddressCountryID.CurrentValue, PrimaryAddressCountryID.FormatPattern);
                        }
                    }
                } else {
                    PrimaryAddressCountryID.ViewValue = DbNullValue;
                }
                PrimaryAddressCountryID.ViewCustomAttributes = "";

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.ViewValue = ConvertToString(PrimaryAddressHomeTel.CurrentValue); // DN
                PrimaryAddressHomeTel.ViewCustomAttributes = "";

                // AlternativeAddressDetail
                AlternativeAddressDetail.ViewValue = AlternativeAddressDetail.CurrentValue;
                AlternativeAddressDetail.ViewCustomAttributes = "";

                // AlternativeAddressState
                AlternativeAddressState.ViewValue = ConvertToString(AlternativeAddressState.CurrentValue); // DN
                AlternativeAddressState.ViewCustomAttributes = "";

                // AlternativeAddressCity
                AlternativeAddressCity.ViewValue = ConvertToString(AlternativeAddressCity.CurrentValue); // DN
                AlternativeAddressCity.ViewCustomAttributes = "";

                // AlternativeAddressHomeTel
                AlternativeAddressHomeTel.ViewValue = ConvertToString(AlternativeAddressHomeTel.CurrentValue); // DN
                AlternativeAddressHomeTel.ViewCustomAttributes = "";

                // AlternativeAddressPostCode
                AlternativeAddressPostCode.ViewValue = ConvertToString(AlternativeAddressPostCode.CurrentValue); // DN
                AlternativeAddressPostCode.ViewCustomAttributes = "";

                // AlternativeAddressCountryID
                curVal = ConvertToString(AlternativeAddressCountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (AlternativeAddressCountryID.Lookup != null && IsDictionary(AlternativeAddressCountryID.Lookup?.Options) && AlternativeAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        AlternativeAddressCountryID.ViewValue = AlternativeAddressCountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", AlternativeAddressCountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = AlternativeAddressCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && AlternativeAddressCountryID.Lookup != null) { // Lookup values found
                            var listwrk = AlternativeAddressCountryID.Lookup?.RenderViewRow(rswrk[0]);
                            AlternativeAddressCountryID.ViewValue = AlternativeAddressCountryID.HighlightLookup(ConvertToString(rswrk[0]), AlternativeAddressCountryID.DisplayValue(listwrk));
                        } else {
                            AlternativeAddressCountryID.ViewValue = FormatNumber(AlternativeAddressCountryID.CurrentValue, AlternativeAddressCountryID.FormatPattern);
                        }
                    }
                } else {
                    AlternativeAddressCountryID.ViewValue = DbNullValue;
                }
                AlternativeAddressCountryID.ViewCustomAttributes = "";

                // MobileNumber
                MobileNumber.ViewValue = ConvertToString(MobileNumber.CurrentValue); // DN
                MobileNumber.ViewCustomAttributes = "";

                // Email
                _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
                _Email.ViewCustomAttributes = "";

                // EmployeeStatus
                EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
                EmployeeStatus.ViewCustomAttributes = "";

                // FormSubmittedDateTime
                FormSubmittedDateTime.ViewValue = FormSubmittedDateTime.CurrentValue;
                FormSubmittedDateTime.ViewValue = FormatDateTime(FormSubmittedDateTime.ViewValue, FormSubmittedDateTime.FormatPattern);
                FormSubmittedDateTime.ViewCustomAttributes = "";

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

                // SocialSecurityNumber
                SocialSecurityNumber.ViewValue = ConvertToString(SocialSecurityNumber.CurrentValue); // DN
                SocialSecurityNumber.ViewCustomAttributes = "";

                // SocialSecurityIssuingCountryID
                curVal = ConvertToString(SocialSecurityIssuingCountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (SocialSecurityIssuingCountryID.Lookup != null && IsDictionary(SocialSecurityIssuingCountryID.Lookup?.Options) && SocialSecurityIssuingCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        SocialSecurityIssuingCountryID.ViewValue = SocialSecurityIssuingCountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", SocialSecurityIssuingCountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = SocialSecurityIssuingCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && SocialSecurityIssuingCountryID.Lookup != null) { // Lookup values found
                            var listwrk = SocialSecurityIssuingCountryID.Lookup?.RenderViewRow(rswrk[0]);
                            SocialSecurityIssuingCountryID.ViewValue = SocialSecurityIssuingCountryID.HighlightLookup(ConvertToString(rswrk[0]), SocialSecurityIssuingCountryID.DisplayValue(listwrk));
                        } else {
                            SocialSecurityIssuingCountryID.ViewValue = FormatNumber(SocialSecurityIssuingCountryID.CurrentValue, SocialSecurityIssuingCountryID.FormatPattern);
                        }
                    }
                } else {
                    SocialSecurityIssuingCountryID.ViewValue = DbNullValue;
                }
                SocialSecurityIssuingCountryID.ViewCustomAttributes = "";

                // SocialSecurityImage
                SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
                if (!IsNull(SocialSecurityImage.Upload.DbValue)) {
                    SocialSecurityImage.ImageWidth = 200;
                    SocialSecurityImage.ImageHeight = 0;
                    SocialSecurityImage.ImageAlt = SocialSecurityImage.Alt;
                    SocialSecurityImage.ImageCssClass = "ew-image";
                    SocialSecurityImage.ViewValue = SocialSecurityImage.Upload.DbValue;
                } else {
                    SocialSecurityImage.ViewValue = "";
                }
                SocialSecurityImage.ViewCustomAttributes = "";

                // PersonalTaxNumber
                PersonalTaxNumber.ViewValue = ConvertToString(PersonalTaxNumber.CurrentValue); // DN
                PersonalTaxNumber.ViewCustomAttributes = "";

                // PersonalTaxIssuingCountryID
                curVal = ConvertToString(PersonalTaxIssuingCountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (PersonalTaxIssuingCountryID.Lookup != null && IsDictionary(PersonalTaxIssuingCountryID.Lookup?.Options) && PersonalTaxIssuingCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PersonalTaxIssuingCountryID.ViewValue = PersonalTaxIssuingCountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", PersonalTaxIssuingCountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = PersonalTaxIssuingCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && PersonalTaxIssuingCountryID.Lookup != null) { // Lookup values found
                            var listwrk = PersonalTaxIssuingCountryID.Lookup?.RenderViewRow(rswrk[0]);
                            PersonalTaxIssuingCountryID.ViewValue = PersonalTaxIssuingCountryID.HighlightLookup(ConvertToString(rswrk[0]), PersonalTaxIssuingCountryID.DisplayValue(listwrk));
                        } else {
                            PersonalTaxIssuingCountryID.ViewValue = FormatNumber(PersonalTaxIssuingCountryID.CurrentValue, PersonalTaxIssuingCountryID.FormatPattern);
                        }
                    }
                } else {
                    PersonalTaxIssuingCountryID.ViewValue = DbNullValue;
                }
                PersonalTaxIssuingCountryID.ViewCustomAttributes = "";

                // PersonalTaxImage
                PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
                if (!IsNull(PersonalTaxImage.Upload.DbValue)) {
                    PersonalTaxImage.ImageWidth = 200;
                    PersonalTaxImage.ImageHeight = 0;
                    PersonalTaxImage.ImageAlt = PersonalTaxImage.Alt;
                    PersonalTaxImage.ImageCssClass = "ew-image";
                    PersonalTaxImage.ViewValue = PersonalTaxImage.Upload.DbValue;
                } else {
                    PersonalTaxImage.ViewValue = "";
                }
                PersonalTaxImage.ViewCustomAttributes = "";

                // Status
                Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // Reason
                Reason.ViewValue = Reason.CurrentValue;
                Reason.ViewCustomAttributes = "";

                // Weight
                Weight.ViewValue = Weight.CurrentValue;
                Weight.ViewCustomAttributes = "";

                // Height
                Height.ViewValue = Height.CurrentValue;
                Height.ViewCustomAttributes = "";

                // CoverallSize
                curVal = ConvertToString(CoverallSize.CurrentValue);
                if (!Empty(curVal)) {
                    if (CoverallSize.Lookup != null && IsDictionary(CoverallSize.Lookup?.Options) && CoverallSize.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        CoverallSize.ViewValue = CoverallSize.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[Name]", "=", CoverallSize.CurrentValue, DataType.String, "");
                        sqlWrk = CoverallSize.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && CoverallSize.Lookup != null) { // Lookup values found
                            var listwrk = CoverallSize.Lookup?.RenderViewRow(rswrk[0]);
                            CoverallSize.ViewValue = CoverallSize.HighlightLookup(ConvertToString(rswrk[0]), CoverallSize.DisplayValue(listwrk));
                        } else {
                            CoverallSize.ViewValue = CoverallSize.CurrentValue;
                        }
                    }
                } else {
                    CoverallSize.ViewValue = DbNullValue;
                }
                CoverallSize.ViewCustomAttributes = "";

                // SafetyShoesSize
                if (!Empty(SafetyShoesSize.CurrentValue)) {
                    SafetyShoesSize.ViewValue = SafetyShoesSize.HighlightLookup(ConvertToString(SafetyShoesSize.CurrentValue), SafetyShoesSize.OptionCaption(ConvertToString(SafetyShoesSize.CurrentValue)));
                } else {
                    SafetyShoesSize.ViewValue = DbNullValue;
                }
                SafetyShoesSize.ViewCustomAttributes = "";

                // ShirtSize
                curVal = ConvertToString(ShirtSize.CurrentValue);
                if (!Empty(curVal)) {
                    if (ShirtSize.Lookup != null && IsDictionary(ShirtSize.Lookup?.Options) && ShirtSize.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        ShirtSize.ViewValue = ShirtSize.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[Name]", "=", ShirtSize.CurrentValue, DataType.String, "");
                        sqlWrk = ShirtSize.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && ShirtSize.Lookup != null) { // Lookup values found
                            var listwrk = ShirtSize.Lookup?.RenderViewRow(rswrk[0]);
                            ShirtSize.ViewValue = ShirtSize.HighlightLookup(ConvertToString(rswrk[0]), ShirtSize.DisplayValue(listwrk));
                        } else {
                            ShirtSize.ViewValue = ShirtSize.CurrentValue;
                        }
                    }
                } else {
                    ShirtSize.ViewValue = DbNullValue;
                }
                ShirtSize.ViewCustomAttributes = "";

                // TrousersSize
                curVal = ConvertToString(TrousersSize.CurrentValue);
                if (!Empty(curVal)) {
                    if (TrousersSize.Lookup != null && IsDictionary(TrousersSize.Lookup?.Options) && TrousersSize.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        TrousersSize.ViewValue = TrousersSize.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[Name]", "=", TrousersSize.CurrentValue, DataType.String, "");
                        sqlWrk = TrousersSize.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && TrousersSize.Lookup != null) { // Lookup values found
                            var listwrk = TrousersSize.Lookup?.RenderViewRow(rswrk[0]);
                            TrousersSize.ViewValue = TrousersSize.HighlightLookup(ConvertToString(rswrk[0]), TrousersSize.DisplayValue(listwrk));
                        } else {
                            TrousersSize.ViewValue = TrousersSize.CurrentValue;
                        }
                    }
                } else {
                    TrousersSize.ViewValue = DbNullValue;
                }
                TrousersSize.ViewCustomAttributes = "";

                // NomineeFullName
                NomineeFullName.ViewValue = ConvertToString(NomineeFullName.CurrentValue); // DN
                NomineeFullName.ViewCustomAttributes = "";

                // NomineeRelationship
                NomineeRelationship.ViewValue = ConvertToString(NomineeRelationship.CurrentValue); // DN
                NomineeRelationship.ViewCustomAttributes = "";

                // NomineeGender
                if (!Empty(NomineeGender.CurrentValue)) {
                    NomineeGender.ViewValue = NomineeGender.HighlightLookup(ConvertToString(NomineeGender.CurrentValue), NomineeGender.OptionCaption(ConvertToString(NomineeGender.CurrentValue)));
                } else {
                    NomineeGender.ViewValue = DbNullValue;
                }
                NomineeGender.ViewCustomAttributes = "";

                // NomineeNationality_CountryID
                curVal = ConvertToString(NomineeNationality_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (NomineeNationality_CountryID.Lookup != null && IsDictionary(NomineeNationality_CountryID.Lookup?.Options) && NomineeNationality_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        NomineeNationality_CountryID.ViewValue = NomineeNationality_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", NomineeNationality_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = NomineeNationality_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && NomineeNationality_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = NomineeNationality_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            NomineeNationality_CountryID.ViewValue = NomineeNationality_CountryID.HighlightLookup(ConvertToString(rswrk[0]), NomineeNationality_CountryID.DisplayValue(listwrk));
                        } else {
                            NomineeNationality_CountryID.ViewValue = FormatNumber(NomineeNationality_CountryID.CurrentValue, NomineeNationality_CountryID.FormatPattern);
                        }
                    }
                } else {
                    NomineeNationality_CountryID.ViewValue = DbNullValue;
                }
                NomineeNationality_CountryID.ViewCustomAttributes = "";

                // NomineeAddressDetail
                NomineeAddressDetail.ViewValue = NomineeAddressDetail.CurrentValue;
                NomineeAddressDetail.ViewCustomAttributes = "";

                // NomineeAddressCity
                NomineeAddressCity.ViewValue = ConvertToString(NomineeAddressCity.CurrentValue); // DN
                NomineeAddressCity.ViewCustomAttributes = "";

                // NomineeAddressPostCode
                NomineeAddressPostCode.ViewValue = ConvertToString(NomineeAddressPostCode.CurrentValue); // DN
                NomineeAddressPostCode.ViewCustomAttributes = "";

                // NomineeAddressCountryID
                curVal = ConvertToString(NomineeAddressCountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (NomineeAddressCountryID.Lookup != null && IsDictionary(NomineeAddressCountryID.Lookup?.Options) && NomineeAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        NomineeAddressCountryID.ViewValue = NomineeAddressCountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", NomineeAddressCountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = NomineeAddressCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && NomineeAddressCountryID.Lookup != null) { // Lookup values found
                            var listwrk = NomineeAddressCountryID.Lookup?.RenderViewRow(rswrk[0]);
                            NomineeAddressCountryID.ViewValue = NomineeAddressCountryID.HighlightLookup(ConvertToString(rswrk[0]), NomineeAddressCountryID.DisplayValue(listwrk));
                        } else {
                            NomineeAddressCountryID.ViewValue = FormatNumber(NomineeAddressCountryID.CurrentValue, NomineeAddressCountryID.FormatPattern);
                        }
                    }
                } else {
                    NomineeAddressCountryID.ViewValue = DbNullValue;
                }
                NomineeAddressCountryID.ViewCustomAttributes = "";

                // NomineeAddressHomeTel
                NomineeAddressHomeTel.ViewValue = ConvertToString(NomineeAddressHomeTel.CurrentValue); // DN
                NomineeAddressHomeTel.ViewCustomAttributes = "";

                // NomineeEmail
                NomineeEmail.ViewValue = ConvertToString(NomineeEmail.CurrentValue); // DN
                NomineeEmail.ViewCustomAttributes = "";

                // NomineeMobileNumber
                NomineeMobileNumber.ViewValue = ConvertToString(NomineeMobileNumber.CurrentValue); // DN
                NomineeMobileNumber.ViewCustomAttributes = "";

                // NSSF_Health_Number
                NSSF_Health_Number.ViewValue = ConvertToString(NSSF_Health_Number.CurrentValue); // DN
                NSSF_Health_Number.ViewCustomAttributes = "";

                // NSSF_Occupation_Number
                NSSF_Occupation_Number.ViewValue = ConvertToString(NSSF_Occupation_Number.CurrentValue); // DN
                NSSF_Occupation_Number.ViewCustomAttributes = "";

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
                            MobileNumberCode_CountryID.ViewValue = MobileNumberCode_CountryID.CurrentValue;
                        }
                    }
                } else {
                    MobileNumberCode_CountryID.ViewValue = DbNullValue;
                }
                MobileNumberCode_CountryID.ViewCustomAttributes = "";

                // PrimaryAddressHomeTelCode_CountryID
                curVal = ConvertToString(PrimaryAddressHomeTelCode_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (PrimaryAddressHomeTelCode_CountryID.Lookup != null && IsDictionary(PrimaryAddressHomeTelCode_CountryID.Lookup?.Options) && PrimaryAddressHomeTelCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        PrimaryAddressHomeTelCode_CountryID.ViewValue = PrimaryAddressHomeTelCode_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", PrimaryAddressHomeTelCode_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = PrimaryAddressHomeTelCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && PrimaryAddressHomeTelCode_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = PrimaryAddressHomeTelCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            PrimaryAddressHomeTelCode_CountryID.ViewValue = PrimaryAddressHomeTelCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), PrimaryAddressHomeTelCode_CountryID.DisplayValue(listwrk));
                        } else {
                            PrimaryAddressHomeTelCode_CountryID.ViewValue = PrimaryAddressHomeTelCode_CountryID.CurrentValue;
                        }
                    }
                } else {
                    PrimaryAddressHomeTelCode_CountryID.ViewValue = DbNullValue;
                }
                PrimaryAddressHomeTelCode_CountryID.ViewCustomAttributes = "";

                // AlternativeAddressHomeTelCode_CountryID
                curVal = ConvertToString(AlternativeAddressHomeTelCode_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (AlternativeAddressHomeTelCode_CountryID.Lookup != null && IsDictionary(AlternativeAddressHomeTelCode_CountryID.Lookup?.Options) && AlternativeAddressHomeTelCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        AlternativeAddressHomeTelCode_CountryID.ViewValue = AlternativeAddressHomeTelCode_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", AlternativeAddressHomeTelCode_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = AlternativeAddressHomeTelCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && AlternativeAddressHomeTelCode_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = AlternativeAddressHomeTelCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            AlternativeAddressHomeTelCode_CountryID.ViewValue = AlternativeAddressHomeTelCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), AlternativeAddressHomeTelCode_CountryID.DisplayValue(listwrk));
                        } else {
                            AlternativeAddressHomeTelCode_CountryID.ViewValue = AlternativeAddressHomeTelCode_CountryID.CurrentValue;
                        }
                    }
                } else {
                    AlternativeAddressHomeTelCode_CountryID.ViewValue = DbNullValue;
                }
                AlternativeAddressHomeTelCode_CountryID.ViewCustomAttributes = "";

                // NomineeAddressHomeTelCode_CountryID
                curVal = ConvertToString(NomineeAddressHomeTelCode_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (NomineeAddressHomeTelCode_CountryID.Lookup != null && IsDictionary(NomineeAddressHomeTelCode_CountryID.Lookup?.Options) && NomineeAddressHomeTelCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        NomineeAddressHomeTelCode_CountryID.ViewValue = NomineeAddressHomeTelCode_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", NomineeAddressHomeTelCode_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = NomineeAddressHomeTelCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && NomineeAddressHomeTelCode_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = NomineeAddressHomeTelCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            NomineeAddressHomeTelCode_CountryID.ViewValue = NomineeAddressHomeTelCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), NomineeAddressHomeTelCode_CountryID.DisplayValue(listwrk));
                        } else {
                            NomineeAddressHomeTelCode_CountryID.ViewValue = NomineeAddressHomeTelCode_CountryID.CurrentValue;
                        }
                    }
                } else {
                    NomineeAddressHomeTelCode_CountryID.ViewValue = DbNullValue;
                }
                NomineeAddressHomeTelCode_CountryID.ViewCustomAttributes = "";

                // NomineeMobileNumberCode_CountryID
                curVal = ConvertToString(NomineeMobileNumberCode_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (NomineeMobileNumberCode_CountryID.Lookup != null && IsDictionary(NomineeMobileNumberCode_CountryID.Lookup?.Options) && NomineeMobileNumberCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        NomineeMobileNumberCode_CountryID.ViewValue = NomineeMobileNumberCode_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", NomineeMobileNumberCode_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = NomineeMobileNumberCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && NomineeMobileNumberCode_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = NomineeMobileNumberCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            NomineeMobileNumberCode_CountryID.ViewValue = NomineeMobileNumberCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), NomineeMobileNumberCode_CountryID.DisplayValue(listwrk));
                        } else {
                            NomineeMobileNumberCode_CountryID.ViewValue = NomineeMobileNumberCode_CountryID.CurrentValue;
                        }
                    }
                } else {
                    NomineeMobileNumberCode_CountryID.ViewValue = DbNullValue;
                }
                NomineeMobileNumberCode_CountryID.ViewCustomAttributes = "";

                // MTManningAgentID
                MTManningAgentID.ViewValue = MTManningAgentID.CurrentValue;
                MTManningAgentID.ViewCustomAttributes = "";

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
                if (RequiredPhoto.UseColorbox) {
                    if (Empty(RequiredPhoto.TooltipValue))
                        RequiredPhoto.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                    RequiredPhoto.LinkAttrs["data-rel"] = "CrewPersonalDataForAdmin_x" + RowCount + "_RequiredPhoto";
                    if (RequiredPhoto.LinkAttrs.ContainsKey("class")) {
                        RequiredPhoto.LinkAttrs.AppendClass("ew-lightbox");
                    } else {
                        RequiredPhoto.LinkAttrs["class"] = "ew-lightbox";
                    }
                }

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
                if (VisaPhoto.UseColorbox) {
                    if (Empty(VisaPhoto.TooltipValue))
                        VisaPhoto.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                    VisaPhoto.LinkAttrs["data-rel"] = "CrewPersonalDataForAdmin_x" + RowCount + "_VisaPhoto";
                    if (VisaPhoto.LinkAttrs.ContainsKey("class")) {
                        VisaPhoto.LinkAttrs.AppendClass("ew-lightbox");
                    } else {
                        VisaPhoto.LinkAttrs["class"] = "ew-lightbox";
                    }
                }

                // Nationality_CountryID
                Nationality_CountryID.HrefValue = "";
                Nationality_CountryID.TooltipValue = "";

                // CountryOfOrigin_CountryID
                CountryOfOrigin_CountryID.HrefValue = "";
                CountryOfOrigin_CountryID.TooltipValue = "";

                // DateOfBirth
                DateOfBirth.HrefValue = "";
                DateOfBirth.TooltipValue = "";

                // CityOfBirth
                CityOfBirth.HrefValue = "";
                CityOfBirth.TooltipValue = "";

                // Gender
                Gender.HrefValue = "";
                Gender.TooltipValue = "";

                // MaritalStatus
                MaritalStatus.HrefValue = "";
                MaritalStatus.TooltipValue = "";

                // ReligionID
                ReligionID.HrefValue = "";
                ReligionID.TooltipValue = "";

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.HrefValue = "";
                RankAppliedFor_RankID.TooltipValue = "";

                // MobileNumber
                MobileNumber.HrefValue = "";
                MobileNumber.TooltipValue = "";

                // Email
                _Email.HrefValue = "";
                _Email.TooltipValue = "";

                // EmployeeStatus
                EmployeeStatus.HrefValue = "";
                EmployeeStatus.TooltipValue = "";

                // FormSubmittedDateTime
                FormSubmittedDateTime.HrefValue = "";
                FormSubmittedDateTime.TooltipValue = "";

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

                // Nationality_CountryID
                if (Nationality_CountryID.UseFilter && !Empty(Nationality_CountryID.AdvancedSearch.SearchValue)) {
                    Nationality_CountryID.EditValue = ConvertToString(Nationality_CountryID.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // CountryOfOrigin_CountryID
                if (CountryOfOrigin_CountryID.UseFilter && !Empty(CountryOfOrigin_CountryID.AdvancedSearch.SearchValue)) {
                    CountryOfOrigin_CountryID.EditValue = ConvertToString(CountryOfOrigin_CountryID.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // DateOfBirth
                if (DateOfBirth.UseFilter && !Empty(DateOfBirth.AdvancedSearch.SearchValue)) {
                    DateOfBirth.EditValue = ConvertToString(DateOfBirth.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // CityOfBirth
                if (CityOfBirth.UseFilter && !Empty(CityOfBirth.AdvancedSearch.SearchValue)) {
                    CityOfBirth.EditValue = ConvertToString(CityOfBirth.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // Gender
                if (Gender.UseFilter && !Empty(Gender.AdvancedSearch.SearchValue)) {
                    Gender.EditValue = ConvertToString(Gender.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // MaritalStatus
                if (MaritalStatus.UseFilter && !Empty(MaritalStatus.AdvancedSearch.SearchValue)) {
                    MaritalStatus.EditValue = ConvertToString(MaritalStatus.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // ReligionID
                if (ReligionID.UseFilter && !Empty(ReligionID.AdvancedSearch.SearchValue)) {
                    ReligionID.EditValue = ConvertToString(ReligionID.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // RankAppliedFor_RankID
                if (RankAppliedFor_RankID.UseFilter && !Empty(RankAppliedFor_RankID.AdvancedSearch.SearchValue)) {
                    RankAppliedFor_RankID.EditValue = ConvertToString(RankAppliedFor_RankID.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // MobileNumber
                if (MobileNumber.UseFilter && !Empty(MobileNumber.AdvancedSearch.SearchValue)) {
                    MobileNumber.EditValue = ConvertToString(MobileNumber.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // Email
                if (_Email.UseFilter && !Empty(_Email.AdvancedSearch.SearchValue)) {
                    _Email.EditValue = ConvertToString(_Email.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // EmployeeStatus
                if (EmployeeStatus.UseFilter && !Empty(EmployeeStatus.AdvancedSearch.SearchValue)) {
                    EmployeeStatus.EditValue = ConvertToString(EmployeeStatus.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

                // FormSubmittedDateTime
                if (FormSubmittedDateTime.UseFilter && !Empty(FormSubmittedDateTime.AdvancedSearch.SearchValue)) {
                    FormSubmittedDateTime.EditValue = ConvertToString(FormSubmittedDateTime.AdvancedSearch.SearchValue).Split(Config.MultipleOptionSeparator).ToList();
                }

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
            Nationality_CountryID.AdvancedSearch.Load();
            CountryOfOrigin_CountryID.AdvancedSearch.Load();
            DateOfBirth.AdvancedSearch.Load();
            CityOfBirth.AdvancedSearch.Load();
            Gender.AdvancedSearch.Load();
            MaritalStatus.AdvancedSearch.Load();
            ReligionID.AdvancedSearch.Load();
            BloodType.AdvancedSearch.Load();
            RankAppliedFor_RankID.AdvancedSearch.Load();
            WillAcceptLowRank.AdvancedSearch.Load();
            AvailableFrom.AdvancedSearch.Load();
            AvailableUntil.AdvancedSearch.Load();
            PrimaryAddressDetail.AdvancedSearch.Load();
            PrimaryAddressCity.AdvancedSearch.Load();
            PrimaryAddressNearestAirport.AdvancedSearch.Load();
            PrimaryAddressState.AdvancedSearch.Load();
            PrimaryAddressPostCode.AdvancedSearch.Load();
            PrimaryAddressCountryID.AdvancedSearch.Load();
            PrimaryAddressHomeTel.AdvancedSearch.Load();
            AlternativeAddressDetail.AdvancedSearch.Load();
            AlternativeAddressState.AdvancedSearch.Load();
            AlternativeAddressCity.AdvancedSearch.Load();
            AlternativeAddressHomeTel.AdvancedSearch.Load();
            AlternativeAddressPostCode.AdvancedSearch.Load();
            AlternativeAddressCountryID.AdvancedSearch.Load();
            MobileNumber.AdvancedSearch.Load();
            _Email.AdvancedSearch.Load();
            EmployeeStatus.AdvancedSearch.Load();
            FormSubmittedDateTime.AdvancedSearch.Load();
            CreatedByUserID.AdvancedSearch.Load();
            CreatedDateTime.AdvancedSearch.Load();
            LastUpdatedByUserID.AdvancedSearch.Load();
            LastUpdatedDateTime.AdvancedSearch.Load();
            SocialSecurityNumber.AdvancedSearch.Load();
            SocialSecurityIssuingCountryID.AdvancedSearch.Load();
            SocialSecurityImage.AdvancedSearch.Load();
            PersonalTaxNumber.AdvancedSearch.Load();
            PersonalTaxIssuingCountryID.AdvancedSearch.Load();
            PersonalTaxImage.AdvancedSearch.Load();
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
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fCrewPersonalDataForAdminlist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
            } else if (SameText(type, "word")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fCrewPersonalDataForAdminlist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>";
            } else if (SameText(type, "pdf")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fCrewPersonalDataForAdminlist\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>";
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
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fCrewPersonalDataForAdminlist\" data-ew-action=\"email\" data-custom=\"false\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
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
            item.Body = "<a class=\"btn btn-default ew-search-toggle" + searchToggleClass + "\" role=\"button\" title=\"" + Language.Phrase("SearchPanel") + "\" data-caption=\"" + Language.Phrase("SearchPanel") + "\" data-ew-action=\"search-toggle\" data-form=\"fCrewPersonalDataForAdminsrch\" aria-pressed=\"" + (searchToggleClass == " active" ? "true" : "false") + "\">" + Language.Phrase("SearchLink") + "</a>";
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
                item.Body = "<a class=\"btn btn-default ew-advanced-search\" title=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-table=\"CrewPersonalDataForAdmin\" data-caption=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-ew-action=\"modal\" data-url=\"" + AppPath("CrewPersonalDataForAdminSearch") + "\" data-btn=\"SearchBtn\">" + Language.Phrase("AdvancedSearch", false) + "</a>";
            else
                item.Body = "<a class=\"btn btn-default ew-advanced-search\" title=\"" + Language.Phrase("AdvancedSearch", true) + "\" data-caption=\"" + Language.Phrase("AdvancedSearch", true) + "\" href=\"" + AppPath("CrewPersonalDataForAdminSearch") + "\">" + Language.Phrase("AdvancedSearch", false) + "</a>";
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
