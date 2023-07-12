namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mtCrewExperienceSearch
    /// </summary>
    public static MtCrewExperienceSearch mtCrewExperienceSearch
    {
        get => HttpData.Get<MtCrewExperienceSearch>("mtCrewExperienceSearch")!;
        set => HttpData["mtCrewExperienceSearch"] = value;
    }

    /// <summary>
    /// Page class for MTCrewExperience
    /// </summary>
    public class MtCrewExperienceSearch : MtCrewExperienceSearchBase
    {
        // Constructor
        public MtCrewExperienceSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MtCrewExperienceSearch() : base()
        {
        }

        // Page Load event
        public override void PageLoad() {
            //Log("Page Load");
            MTVesselTypeID.DisplayValueSeparator = " ";
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MtCrewExperienceSearchBase : MtCrewExperience
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "MTCrewExperience";

        // Page object name
        public string PageObjName = "mtCrewExperienceSearch";

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
        public MtCrewExperienceSearchBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (mtCrewExperience)
            if (mtCrewExperience == null || mtCrewExperience is MtCrewExperience)
                mtCrewExperience = this;

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
        public string PageName => "MtCrewExperienceSearch";

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
            CompanyName.SetVisibility();
            FlagName_CountryID.SetVisibility();
            VesselName.SetVisibility();
            MTVesselTypeID.SetVisibility();
            GRT.SetVisibility();
            DWT.SetVisibility();
            MainEngine.SetVisibility();
            BHP.SetVisibility();
            MTRankID.SetVisibility();
            DateFrom.SetVisibility();
            SignOnPortName.SetVisibility();
            DateUntil.SetVisibility();
            SignOffPortName.SetVisibility();
            SignOffReason.SetVisibility();
            ActiveDescription.Visible = false;
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            MTUserID.Visible = false;
        }

        // Constructor
        public MtCrewExperienceSearchBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "MtCrewExperienceView" ? "1" : "0"); // If View page, no primary button
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

        public string FormClassName = "ew-form ew-search-form";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

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
            await SetupLookupOptions(MTCrewID);
            await SetupLookupOptions(FlagName_CountryID);
            await SetupLookupOptions(MTVesselTypeID);
            await SetupLookupOptions(MTRankID);
            await SetupLookupOptions(CreatedByUserID);
            await SetupLookupOptions(LastUpdatedByUserID);

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;

            // Get action
            CurrentAction = CurrentForm.GetValue("action");
            if (IsSearch) {
                // Build search string for advanced search, remove blank field
                LoadSearchValues(); // Get search values
                string srchStr = ValidateSearch() ? BuildAdvancedSearch() : "";
                if (!Empty(srchStr)) {
                    srchStr = "MtCrewExperienceList?" + srchStr;
                    // Do not return Json for UseAjaxActions
                    if (IsModal && UseAjaxActions)
                        IsModal = false;
                    return Terminate(srchStr); // Go to List page
                }
            }

            // Restore search settings from Session
            if (!HasInvalidFields())
                LoadAdvancedSearch();

            // Render row for search
            RowType = RowType.Search;
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
                mtCrewExperienceSearch?.PageRender();
            }
            return PageResult();
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, MTCrewID); // MTCrewID
            BuildSearchUrl(ref srchUrl, CompanyName); // CompanyName
            BuildSearchUrl(ref srchUrl, FlagName_CountryID); // FlagName_CountryID
            BuildSearchUrl(ref srchUrl, VesselName); // VesselName
            BuildSearchUrl(ref srchUrl, MTVesselTypeID); // MTVesselTypeID
            BuildSearchUrl(ref srchUrl, GRT); // GRT
            BuildSearchUrl(ref srchUrl, DWT); // DWT
            BuildSearchUrl(ref srchUrl, MainEngine); // MainEngine
            BuildSearchUrl(ref srchUrl, BHP); // BHP
            BuildSearchUrl(ref srchUrl, MTRankID); // MTRankID
            BuildSearchUrl(ref srchUrl, DateFrom); // DateFrom
            BuildSearchUrl(ref srchUrl, SignOnPortName); // SignOnPortName
            BuildSearchUrl(ref srchUrl, DateUntil); // DateUntil
            BuildSearchUrl(ref srchUrl, SignOffPortName); // SignOffPortName
            BuildSearchUrl(ref srchUrl, SignOffReason); // SignOffReason
            BuildSearchUrl(ref srchUrl, CreatedByUserID); // CreatedByUserID
            BuildSearchUrl(ref srchUrl, CreatedDateTime); // CreatedDateTime
            BuildSearchUrl(ref srchUrl, LastUpdatedByUserID); // LastUpdatedByUserID
            BuildSearchUrl(ref srchUrl, LastUpdatedDateTime); // LastUpdatedDateTime
            if (!Empty(srchUrl))
                srchUrl += "&";
            srchUrl += "cmd=search";
            return srchUrl;
        }

        // Build search URL
        protected void BuildSearchUrl(ref string url, DbField fld, bool oprOnly = false) {
            bool isValid;
            string wrk = "";
            string fldParm = fld.Param;
            string ctl = "x_" + fldParm;
            string ctl2 = "y_" + fldParm;
            if (fld.IsMultiSelect) { // DN
                ctl += "[]";
                ctl2 += "[]";
            }
            string fldVal = CurrentForm.GetValue(ctl);
            string fldOpr = CurrentForm.GetValue("z_" + fldParm);
            string fldCond = CurrentForm.GetValue("v_" + fldParm);
            string fldVal2 = CurrentForm.GetValue(ctl2);
            string fldOpr2 = CurrentForm.GetValue("w_" + fldParm);
            DataType fldDataType = fld.IsVirtual ? DataType.String : fld.DataType;
            fldVal = ConvertSearchValue(fldVal, fldOpr, fld); // For testing if numeric only
            fldVal2 = ConvertSearchValue(fldVal2, fldOpr2, fld); // For testing if numeric only
            fldOpr = ConvertSearchOperator(fldOpr, fld, fldVal);
            fldOpr2 = ConvertSearchOperator(fldOpr2, fld, fldVal2);
            if ((new [] { "BETWEEN", "NOT BETWEEN" }).Contains(fldOpr)) {
                isValid = fldDataType != DataType.Number || fld.VirtualSearch || IsNumericSearchValue(fldVal, fldOpr, fld) && IsNumericSearchValue(fldVal2, fldOpr2, fld);
                if (!Empty(fldVal) && !Empty(fldVal2) && isValid)
                    wrk = ctl + "=" + UrlEncode(fldVal) + "&" + ctl2 + "=" + UrlEncode(fldVal2) + "&z_" + fldParm + "=" + UrlEncode(fldOpr);
            } else {
                isValid = fldDataType != DataType.Number || fld.VirtualSearch || IsNumericSearchValue(fldVal, fldOpr, fld);
                if (!Empty(fldVal) && isValid && IsValidOperator(fldOpr)) {
                    wrk = ctl + "=" + UrlEncode(fldVal) + "&z_" + fldParm + "=" + UrlEncode(fldOpr);
                } else if ((new [] { "IS NULL", "IS NOT NULL", "IS EMPTY", "IS NOT EMPTY" }).Contains(fldOpr) || !Empty(fldOpr) && oprOnly && IsValidOperator(fldOpr)) {
                    wrk = "z_" + fldParm + "=" + UrlEncode(fldOpr);
                }
                isValid = fldDataType != DataType.Number || fld.VirtualSearch || IsNumericSearchValue(fldVal2, fldOpr2, fld);
                if (!Empty(fldVal2) && isValid && IsValidOperator(fldOpr2)) {
                    if (!Empty(wrk))
                        wrk += "&v_" + fldParm + "=" + fldCond + "&";
                    wrk += ctl2 + "=" + UrlEncode(fldVal2) + "&w_" + fldParm + "=" + UrlEncode(fldOpr2);
                } else if ((new [] { "IS NULL", "IS NOT NULL", "IS EMPTY", "IS NOT EMPTY" }).Contains(fldOpr2) || !Empty(fldOpr2) && oprOnly && IsValidOperator(fldOpr2)) {
                    if (!Empty(wrk))
                        wrk += "&v_" + fldParm + "=" + UrlEncode(fldCond) + "&";
                    wrk += "w_" + fldParm + "=" + UrlEncode(fldOpr2);
                }
            }
            if (!Empty(wrk)) {
                if (!Empty(url))
                    url += "&";
                url += wrk;
            }
        }

        // Load search values for validation // DN
        protected void LoadSearchValues() {
            // MTCrewID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MTCrewID"))
                    MTCrewID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MTCrewID");
            if (Form.ContainsKey("z_MTCrewID"))
                MTCrewID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MTCrewID");

            // CompanyName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CompanyName"))
                    CompanyName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CompanyName");
            if (Form.ContainsKey("z_CompanyName"))
                CompanyName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CompanyName");

            // FlagName_CountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_FlagName_CountryID"))
                    FlagName_CountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_FlagName_CountryID");
            if (Form.ContainsKey("z_FlagName_CountryID"))
                FlagName_CountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_FlagName_CountryID");

            // VesselName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_VesselName"))
                    VesselName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_VesselName");
            if (Form.ContainsKey("z_VesselName"))
                VesselName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_VesselName");

            // MTVesselTypeID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MTVesselTypeID"))
                    MTVesselTypeID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MTVesselTypeID");
            if (Form.ContainsKey("z_MTVesselTypeID"))
                MTVesselTypeID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MTVesselTypeID");

            // GRT
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_GRT"))
                    GRT.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_GRT");
            if (Form.ContainsKey("z_GRT"))
                GRT.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_GRT");

            // DWT
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_DWT"))
                    DWT.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DWT");
            if (Form.ContainsKey("z_DWT"))
                DWT.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DWT");

            // MainEngine
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MainEngine"))
                    MainEngine.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MainEngine");
            if (Form.ContainsKey("z_MainEngine"))
                MainEngine.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MainEngine");

            // BHP
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_BHP"))
                    BHP.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_BHP");
            if (Form.ContainsKey("z_BHP"))
                BHP.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_BHP");

            // MTRankID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MTRankID"))
                    MTRankID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MTRankID");
            if (Form.ContainsKey("z_MTRankID"))
                MTRankID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MTRankID");

            // DateFrom
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_DateFrom"))
                    DateFrom.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DateFrom");
            if (Form.ContainsKey("z_DateFrom"))
                DateFrom.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DateFrom");

            // SignOnPortName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_SignOnPortName"))
                    SignOnPortName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_SignOnPortName");
            if (Form.ContainsKey("z_SignOnPortName"))
                SignOnPortName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_SignOnPortName");

            // DateUntil
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_DateUntil"))
                    DateUntil.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DateUntil");
            if (Form.ContainsKey("z_DateUntil"))
                DateUntil.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DateUntil");

            // SignOffPortName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_SignOffPortName"))
                    SignOffPortName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_SignOffPortName");
            if (Form.ContainsKey("z_SignOffPortName"))
                SignOffPortName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_SignOffPortName");

            // SignOffReason
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_SignOffReason"))
                    SignOffReason.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_SignOffReason");
            if (Form.ContainsKey("z_SignOffReason"))
                SignOffReason.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_SignOffReason");

            // CreatedByUserID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CreatedByUserID"))
                    CreatedByUserID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CreatedByUserID");
            if (Form.ContainsKey("z_CreatedByUserID"))
                CreatedByUserID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CreatedByUserID");

            // CreatedDateTime
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CreatedDateTime"))
                    CreatedDateTime.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CreatedDateTime");
            if (Form.ContainsKey("z_CreatedDateTime"))
                CreatedDateTime.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CreatedDateTime");

            // LastUpdatedByUserID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_LastUpdatedByUserID"))
                    LastUpdatedByUserID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_LastUpdatedByUserID");
            if (Form.ContainsKey("z_LastUpdatedByUserID"))
                LastUpdatedByUserID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_LastUpdatedByUserID");

            // LastUpdatedDateTime
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_LastUpdatedDateTime"))
                    LastUpdatedDateTime.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_LastUpdatedDateTime");
            if (Form.ContainsKey("z_LastUpdatedDateTime"))
                LastUpdatedDateTime.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_LastUpdatedDateTime");
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
            CompanyName.SetDbValue(row["CompanyName"]);
            FlagName_CountryID.SetDbValue(row["FlagName_CountryID"]);
            VesselName.SetDbValue(row["VesselName"]);
            MTVesselTypeID.SetDbValue(row["MTVesselTypeID"]);
            GRT.SetDbValue(row["GRT"]);
            DWT.SetDbValue(row["DWT"]);
            MainEngine.SetDbValue(row["MainEngine"]);
            BHP.SetDbValue(row["BHP"]);
            MTRankID.SetDbValue(row["MTRankID"]);
            DateFrom.SetDbValue(row["DateFrom"]);
            SignOnPortName.SetDbValue(row["SignOnPortName"]);
            DateUntil.SetDbValue(row["DateUntil"]);
            SignOffPortName.SetDbValue(row["SignOffPortName"]);
            SignOffReason.SetDbValue(row["SignOffReason"]);
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
            row.Add("CompanyName", CompanyName.DefaultValue ?? DbNullValue); // DN
            row.Add("FlagName_CountryID", FlagName_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("VesselName", VesselName.DefaultValue ?? DbNullValue); // DN
            row.Add("MTVesselTypeID", MTVesselTypeID.DefaultValue ?? DbNullValue); // DN
            row.Add("GRT", GRT.DefaultValue ?? DbNullValue); // DN
            row.Add("DWT", DWT.DefaultValue ?? DbNullValue); // DN
            row.Add("MainEngine", MainEngine.DefaultValue ?? DbNullValue); // DN
            row.Add("BHP", BHP.DefaultValue ?? DbNullValue); // DN
            row.Add("MTRankID", MTRankID.DefaultValue ?? DbNullValue); // DN
            row.Add("DateFrom", DateFrom.DefaultValue ?? DbNullValue); // DN
            row.Add("SignOnPortName", SignOnPortName.DefaultValue ?? DbNullValue); // DN
            row.Add("DateUntil", DateUntil.DefaultValue ?? DbNullValue); // DN
            row.Add("SignOffPortName", SignOffPortName.DefaultValue ?? DbNullValue); // DN
            row.Add("SignOffReason", SignOffReason.DefaultValue ?? DbNullValue); // DN
            row.Add("ActiveDescription", ActiveDescription.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedByUserID", CreatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("MTUserID", MTUserID.DefaultValue ?? DbNullValue); // DN
            return row;
        }

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

            // CompanyName
            CompanyName.RowCssClass = "row";

            // FlagName_CountryID
            FlagName_CountryID.RowCssClass = "row";

            // VesselName
            VesselName.RowCssClass = "row";

            // MTVesselTypeID
            MTVesselTypeID.RowCssClass = "row";

            // GRT
            GRT.RowCssClass = "row";

            // DWT
            DWT.RowCssClass = "row";

            // MainEngine
            MainEngine.RowCssClass = "row";

            // BHP
            BHP.RowCssClass = "row";

            // MTRankID
            MTRankID.RowCssClass = "row";

            // DateFrom
            DateFrom.RowCssClass = "row";

            // SignOnPortName
            SignOnPortName.RowCssClass = "row";

            // DateUntil
            DateUntil.RowCssClass = "row";

            // SignOffPortName
            SignOffPortName.RowCssClass = "row";

            // SignOffReason
            SignOffReason.RowCssClass = "row";

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
                            MTCrewID.ViewValue = FormatNumber(MTCrewID.CurrentValue, MTCrewID.FormatPattern);
                        }
                    }
                } else {
                    MTCrewID.ViewValue = DbNullValue;
                }
                MTCrewID.ViewCustomAttributes = "";

                // CompanyName
                CompanyName.ViewValue = ConvertToString(CompanyName.CurrentValue); // DN
                CompanyName.ViewCustomAttributes = "";

                // FlagName_CountryID
                curVal = ConvertToString(FlagName_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (FlagName_CountryID.Lookup != null && IsDictionary(FlagName_CountryID.Lookup?.Options) && FlagName_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        FlagName_CountryID.ViewValue = FlagName_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", FlagName_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = FlagName_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && FlagName_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = FlagName_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            FlagName_CountryID.ViewValue = FlagName_CountryID.HighlightLookup(ConvertToString(rswrk[0]), FlagName_CountryID.DisplayValue(listwrk));
                        } else {
                            FlagName_CountryID.ViewValue = FormatNumber(FlagName_CountryID.CurrentValue, FlagName_CountryID.FormatPattern);
                        }
                    }
                } else {
                    FlagName_CountryID.ViewValue = DbNullValue;
                }
                FlagName_CountryID.ViewCustomAttributes = "";

                // VesselName
                VesselName.ViewValue = ConvertToString(VesselName.CurrentValue); // DN
                VesselName.ViewCustomAttributes = "";

                // MTVesselTypeID
                curVal = ConvertToString(MTVesselTypeID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MTVesselTypeID.Lookup != null && IsDictionary(MTVesselTypeID.Lookup?.Options) && MTVesselTypeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTVesselTypeID.ViewValue = MTVesselTypeID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MTVesselTypeID.CurrentValue, DataType.Number, "");
                        sqlWrk = MTVesselTypeID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MTVesselTypeID.Lookup != null) { // Lookup values found
                            var listwrk = MTVesselTypeID.Lookup?.RenderViewRow(rswrk[0]);
                            MTVesselTypeID.ViewValue = MTVesselTypeID.HighlightLookup(ConvertToString(rswrk[0]), MTVesselTypeID.DisplayValue(listwrk));
                        } else {
                            MTVesselTypeID.ViewValue = FormatNumber(MTVesselTypeID.CurrentValue, MTVesselTypeID.FormatPattern);
                        }
                    }
                } else {
                    MTVesselTypeID.ViewValue = DbNullValue;
                }
                MTVesselTypeID.ViewCustomAttributes = "";

                // GRT
                GRT.ViewValue = GRT.CurrentValue;
                GRT.ViewValue = FormatNumber(GRT.ViewValue, GRT.FormatPattern);
                GRT.ViewCustomAttributes = "";

                // DWT
                DWT.ViewValue = DWT.CurrentValue;
                DWT.ViewValue = FormatNumber(DWT.ViewValue, DWT.FormatPattern);
                DWT.ViewCustomAttributes = "";

                // MainEngine
                MainEngine.ViewValue = ConvertToString(MainEngine.CurrentValue); // DN
                MainEngine.ViewCustomAttributes = "";

                // BHP
                BHP.ViewValue = BHP.CurrentValue;
                BHP.ViewValue = FormatNumber(BHP.ViewValue, BHP.FormatPattern);
                BHP.ViewCustomAttributes = "";

                // MTRankID
                curVal = ConvertToString(MTRankID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MTRankID.Lookup != null && IsDictionary(MTRankID.Lookup?.Options) && MTRankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTRankID.ViewValue = MTRankID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MTRankID.CurrentValue, DataType.Number, "");
                        sqlWrk = MTRankID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MTRankID.Lookup != null) { // Lookup values found
                            var listwrk = MTRankID.Lookup?.RenderViewRow(rswrk[0]);
                            MTRankID.ViewValue = MTRankID.HighlightLookup(ConvertToString(rswrk[0]), MTRankID.DisplayValue(listwrk));
                        } else {
                            MTRankID.ViewValue = FormatNumber(MTRankID.CurrentValue, MTRankID.FormatPattern);
                        }
                    }
                } else {
                    MTRankID.ViewValue = DbNullValue;
                }
                MTRankID.ViewCustomAttributes = "";

                // DateFrom
                DateFrom.ViewValue = DateFrom.CurrentValue;
                DateFrom.ViewValue = FormatDateTime(DateFrom.ViewValue, DateFrom.FormatPattern);
                DateFrom.ViewCustomAttributes = "";

                // SignOnPortName
                SignOnPortName.ViewValue = ConvertToString(SignOnPortName.CurrentValue); // DN
                SignOnPortName.ViewCustomAttributes = "";

                // DateUntil
                DateUntil.ViewValue = DateUntil.CurrentValue;
                DateUntil.ViewValue = FormatDateTime(DateUntil.ViewValue, DateUntil.FormatPattern);
                DateUntil.ViewCustomAttributes = "";

                // SignOffPortName
                SignOffPortName.ViewValue = ConvertToString(SignOffPortName.CurrentValue); // DN
                SignOffPortName.ViewCustomAttributes = "";

                // SignOffReason
                SignOffReason.ViewValue = SignOffReason.CurrentValue;
                SignOffReason.ViewCustomAttributes = "";

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

                // CompanyName
                CompanyName.HrefValue = "";
                CompanyName.TooltipValue = "";

                // FlagName_CountryID
                FlagName_CountryID.HrefValue = "";
                FlagName_CountryID.TooltipValue = "";

                // VesselName
                VesselName.HrefValue = "";
                VesselName.TooltipValue = "";

                // MTVesselTypeID
                MTVesselTypeID.HrefValue = "";
                MTVesselTypeID.TooltipValue = "";

                // GRT
                GRT.HrefValue = "";
                GRT.TooltipValue = "";

                // DWT
                DWT.HrefValue = "";
                DWT.TooltipValue = "";

                // MainEngine
                MainEngine.HrefValue = "";
                MainEngine.TooltipValue = "";

                // BHP
                BHP.HrefValue = "";
                BHP.TooltipValue = "";

                // MTRankID
                MTRankID.HrefValue = "";
                MTRankID.TooltipValue = "";

                // DateFrom
                DateFrom.HrefValue = "";
                DateFrom.TooltipValue = "";

                // SignOnPortName
                SignOnPortName.HrefValue = "";
                SignOnPortName.TooltipValue = "";

                // DateUntil
                DateUntil.HrefValue = "";
                DateUntil.TooltipValue = "";

                // SignOffPortName
                SignOffPortName.HrefValue = "";
                SignOffPortName.TooltipValue = "";

                // SignOffReason
                SignOffReason.HrefValue = "";
                SignOffReason.TooltipValue = "";

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
                // MTCrewID
                MTCrewID.SetupEditAttributes();
                curVal = ConvertToString(MTCrewID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (MTCrewID.Lookup != null && IsDictionary(MTCrewID.Lookup?.Options) && MTCrewID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTCrewID.EditValue = MTCrewID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTCrewID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = MTCrewID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTCrewID.EditValue = rswrk;
                }
                MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);

                // CompanyName
                CompanyName.SetupEditAttributes();
                if (!CompanyName.Raw)
                    CompanyName.AdvancedSearch.SearchValue = HtmlDecode(CompanyName.AdvancedSearch.SearchValue);
                CompanyName.EditValue = HtmlEncode(CompanyName.AdvancedSearch.SearchValue);
                CompanyName.PlaceHolder = RemoveHtml(CompanyName.Caption);

                // FlagName_CountryID
                FlagName_CountryID.SetupEditAttributes();
                curVal = ConvertToString(FlagName_CountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (FlagName_CountryID.Lookup != null && IsDictionary(FlagName_CountryID.Lookup?.Options) && FlagName_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    FlagName_CountryID.EditValue = FlagName_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", FlagName_CountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = FlagName_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    FlagName_CountryID.EditValue = rswrk;
                }
                FlagName_CountryID.PlaceHolder = RemoveHtml(FlagName_CountryID.Caption);

                // VesselName
                VesselName.SetupEditAttributes();
                if (!VesselName.Raw)
                    VesselName.AdvancedSearch.SearchValue = HtmlDecode(VesselName.AdvancedSearch.SearchValue);
                VesselName.EditValue = HtmlEncode(VesselName.AdvancedSearch.SearchValue);
                VesselName.PlaceHolder = RemoveHtml(VesselName.Caption);

                // MTVesselTypeID
                MTVesselTypeID.SetupEditAttributes();
                curVal = ConvertToString(MTVesselTypeID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (MTVesselTypeID.Lookup != null && IsDictionary(MTVesselTypeID.Lookup?.Options) && MTVesselTypeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTVesselTypeID.EditValue = MTVesselTypeID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTVesselTypeID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = MTVesselTypeID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTVesselTypeID.EditValue = rswrk;
                }
                MTVesselTypeID.PlaceHolder = RemoveHtml(MTVesselTypeID.Caption);

                // GRT
                GRT.SetupEditAttributes();
                GRT.EditValue = GRT.AdvancedSearch.SearchValue; // DN
                GRT.PlaceHolder = RemoveHtml(GRT.Caption);

                // DWT
                DWT.SetupEditAttributes();
                DWT.EditValue = DWT.AdvancedSearch.SearchValue; // DN
                DWT.PlaceHolder = RemoveHtml(DWT.Caption);

                // MainEngine
                MainEngine.SetupEditAttributes();
                if (!MainEngine.Raw)
                    MainEngine.AdvancedSearch.SearchValue = HtmlDecode(MainEngine.AdvancedSearch.SearchValue);
                MainEngine.EditValue = HtmlEncode(MainEngine.AdvancedSearch.SearchValue);
                MainEngine.PlaceHolder = RemoveHtml(MainEngine.Caption);

                // BHP
                BHP.SetupEditAttributes();
                BHP.EditValue = BHP.AdvancedSearch.SearchValue; // DN
                BHP.PlaceHolder = RemoveHtml(BHP.Caption);

                // MTRankID
                MTRankID.SetupEditAttributes();
                curVal = ConvertToString(MTRankID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (MTRankID.Lookup != null && IsDictionary(MTRankID.Lookup?.Options) && MTRankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTRankID.EditValue = MTRankID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTRankID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = MTRankID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTRankID.EditValue = rswrk;
                }
                MTRankID.PlaceHolder = RemoveHtml(MTRankID.Caption);

                // DateFrom
                DateFrom.SetupEditAttributes();
                DateFrom.EditValue = FormatDateTime(UnformatDateTime(DateFrom.AdvancedSearch.SearchValue, DateFrom.FormatPattern), DateFrom.FormatPattern); // DN
                DateFrom.PlaceHolder = RemoveHtml(DateFrom.Caption);

                // SignOnPortName
                SignOnPortName.SetupEditAttributes();
                if (!SignOnPortName.Raw)
                    SignOnPortName.AdvancedSearch.SearchValue = HtmlDecode(SignOnPortName.AdvancedSearch.SearchValue);
                SignOnPortName.EditValue = HtmlEncode(SignOnPortName.AdvancedSearch.SearchValue);
                SignOnPortName.PlaceHolder = RemoveHtml(SignOnPortName.Caption);

                // DateUntil
                DateUntil.SetupEditAttributes();
                DateUntil.EditValue = FormatDateTime(UnformatDateTime(DateUntil.AdvancedSearch.SearchValue, DateUntil.FormatPattern), DateUntil.FormatPattern); // DN
                DateUntil.PlaceHolder = RemoveHtml(DateUntil.Caption);

                // SignOffPortName
                SignOffPortName.SetupEditAttributes();
                if (!SignOffPortName.Raw)
                    SignOffPortName.AdvancedSearch.SearchValue = HtmlDecode(SignOffPortName.AdvancedSearch.SearchValue);
                SignOffPortName.EditValue = HtmlEncode(SignOffPortName.AdvancedSearch.SearchValue);
                SignOffPortName.PlaceHolder = RemoveHtml(SignOffPortName.Caption);

                // SignOffReason
                SignOffReason.SetupEditAttributes();
                SignOffReason.EditValue = SignOffReason.AdvancedSearch.SearchValue; // DN
                SignOffReason.PlaceHolder = RemoveHtml(SignOffReason.Caption);

                // CreatedByUserID
                CreatedByUserID.SetupEditAttributes();
                curVal = ConvertToString(CreatedByUserID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (CreatedByUserID.Lookup != null && IsDictionary(CreatedByUserID.Lookup?.Options) && CreatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CreatedByUserID.EditValue = CreatedByUserID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", CreatedByUserID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = CreatedByUserID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    CreatedByUserID.EditValue = rswrk;
                }
                CreatedByUserID.PlaceHolder = RemoveHtml(CreatedByUserID.Caption);

                // CreatedDateTime
                CreatedDateTime.SetupEditAttributes();
                CreatedDateTime.EditValue = FormatDateTime(UnformatDateTime(CreatedDateTime.AdvancedSearch.SearchValue, CreatedDateTime.FormatPattern), CreatedDateTime.FormatPattern); // DN
                CreatedDateTime.PlaceHolder = RemoveHtml(CreatedDateTime.Caption);

                // LastUpdatedByUserID
                LastUpdatedByUserID.SetupEditAttributes();
                curVal = ConvertToString(LastUpdatedByUserID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (LastUpdatedByUserID.Lookup != null && IsDictionary(LastUpdatedByUserID.Lookup?.Options) && LastUpdatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    LastUpdatedByUserID.EditValue = LastUpdatedByUserID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", LastUpdatedByUserID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = LastUpdatedByUserID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    LastUpdatedByUserID.EditValue = rswrk;
                }
                LastUpdatedByUserID.PlaceHolder = RemoveHtml(LastUpdatedByUserID.Caption);

                // LastUpdatedDateTime
                LastUpdatedDateTime.SetupEditAttributes();
                LastUpdatedDateTime.EditValue = FormatDateTime(UnformatDateTime(LastUpdatedDateTime.AdvancedSearch.SearchValue, LastUpdatedDateTime.FormatPattern), LastUpdatedDateTime.FormatPattern); // DN
                LastUpdatedDateTime.PlaceHolder = RemoveHtml(LastUpdatedDateTime.Caption);
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

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
            if (!CheckInteger(ConvertToString(GRT.AdvancedSearch.SearchValue))) {
                GRT.AddErrorMessage(GRT.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(DWT.AdvancedSearch.SearchValue))) {
                DWT.AddErrorMessage(DWT.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(BHP.AdvancedSearch.SearchValue))) {
                BHP.AddErrorMessage(BHP.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(DateFrom.AdvancedSearch.SearchValue), DateFrom.FormatPattern)) {
                DateFrom.AddErrorMessage(DateFrom.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(DateUntil.AdvancedSearch.SearchValue), DateUntil.FormatPattern)) {
                DateUntil.AddErrorMessage(DateUntil.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(CreatedDateTime.AdvancedSearch.SearchValue), CreatedDateTime.FormatPattern)) {
                CreatedDateTime.AddErrorMessage(CreatedDateTime.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(LastUpdatedDateTime.AdvancedSearch.SearchValue), LastUpdatedDateTime.FormatPattern)) {
                LastUpdatedDateTime.AddErrorMessage(LastUpdatedDateTime.GetErrorMessage(false));
            }

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
            MTCrewID.AdvancedSearch.Load();
            CompanyName.AdvancedSearch.Load();
            FlagName_CountryID.AdvancedSearch.Load();
            VesselName.AdvancedSearch.Load();
            MTVesselTypeID.AdvancedSearch.Load();
            GRT.AdvancedSearch.Load();
            DWT.AdvancedSearch.Load();
            MainEngine.AdvancedSearch.Load();
            BHP.AdvancedSearch.Load();
            MTRankID.AdvancedSearch.Load();
            DateFrom.AdvancedSearch.Load();
            SignOnPortName.AdvancedSearch.Load();
            DateUntil.AdvancedSearch.Load();
            SignOffPortName.AdvancedSearch.Load();
            SignOffReason.AdvancedSearch.Load();
            CreatedByUserID.AdvancedSearch.Load();
            CreatedDateTime.AdvancedSearch.Load();
            LastUpdatedByUserID.AdvancedSearch.Load();
            LastUpdatedDateTime.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MtCrewExperienceList")), "", TableVar, true);
            string pageId = "search";
            breadcrumb.Add("search", pageId, url);
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

        // Form Custom Validate event
        public virtual bool FormCustomValidate(ref string customError) {
            //Return error message in customError
            return true;
        }
    } // End page class
} // End Partial class
