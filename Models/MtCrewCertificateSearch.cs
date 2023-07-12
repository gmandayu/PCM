namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mtCrewCertificateSearch
    /// </summary>
    public static MtCrewCertificateSearch mtCrewCertificateSearch
    {
        get => HttpData.Get<MtCrewCertificateSearch>("mtCrewCertificateSearch")!;
        set => HttpData["mtCrewCertificateSearch"] = value;
    }

    /// <summary>
    /// Page class for MTCrewCertificate
    /// </summary>
    public class MtCrewCertificateSearch : MtCrewCertificateSearchBase
    {
        // Constructor
        public MtCrewCertificateSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MtCrewCertificateSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MtCrewCertificateSearchBase : MtCrewCertificate
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "MTCrewCertificate";

        // Page object name
        public string PageObjName = "mtCrewCertificateSearch";

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
        public MtCrewCertificateSearchBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

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
        public string PageName => "MtCrewCertificateSearch";

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
            Image.Visible = false;
            ActiveDescription.Visible = false;
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            MTUserID.Visible = false;
        }

        // Constructor
        public MtCrewCertificateSearchBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "MtCrewCertificateView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(MTCertificateID);
            await SetupLookupOptions(CountryOfIssue_CountryID);
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
                    srchStr = "MtCrewCertificateList?" + srchStr;
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
                mtCrewCertificateSearch?.PageRender();
            }
            return PageResult();
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, MTCrewID); // MTCrewID
            BuildSearchUrl(ref srchUrl, MTCertificateID); // MTCertificateID
            BuildSearchUrl(ref srchUrl, CountryOfIssue_CountryID); // CountryOfIssue_CountryID
            BuildSearchUrl(ref srchUrl, Number); // Number
            BuildSearchUrl(ref srchUrl, DateOfIssue); // DateOfIssue
            BuildSearchUrl(ref srchUrl, DateOfExpiry); // DateOfExpiry
            BuildSearchUrl(ref srchUrl, PlaceOfIssue); // PlaceOfIssue
            BuildSearchUrl(ref srchUrl, IssuingAuthority); // IssuingAuthority
            BuildSearchUrl(ref srchUrl, Level); // Level
            BuildSearchUrl(ref srchUrl, PaxVesselType); // PaxVesselType
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

            // MTCertificateID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MTCertificateID"))
                    MTCertificateID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MTCertificateID");
            if (Form.ContainsKey("z_MTCertificateID"))
                MTCertificateID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MTCertificateID");

            // CountryOfIssue_CountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CountryOfIssue_CountryID"))
                    CountryOfIssue_CountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CountryOfIssue_CountryID");
            if (Form.ContainsKey("z_CountryOfIssue_CountryID"))
                CountryOfIssue_CountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CountryOfIssue_CountryID");

            // Number
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Number"))
                    Number.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Number");
            if (Form.ContainsKey("z_Number"))
                Number.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Number");

            // DateOfIssue
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_DateOfIssue"))
                    DateOfIssue.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DateOfIssue");
            if (Form.ContainsKey("z_DateOfIssue"))
                DateOfIssue.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DateOfIssue");

            // DateOfExpiry
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_DateOfExpiry"))
                    DateOfExpiry.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DateOfExpiry");
            if (Form.ContainsKey("z_DateOfExpiry"))
                DateOfExpiry.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DateOfExpiry");

            // PlaceOfIssue
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PlaceOfIssue"))
                    PlaceOfIssue.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PlaceOfIssue");
            if (Form.ContainsKey("z_PlaceOfIssue"))
                PlaceOfIssue.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PlaceOfIssue");

            // IssuingAuthority
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IssuingAuthority"))
                    IssuingAuthority.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IssuingAuthority");
            if (Form.ContainsKey("z_IssuingAuthority"))
                IssuingAuthority.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IssuingAuthority");

            // Level
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Level"))
                    Level.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Level");
            if (Form.ContainsKey("z_Level"))
                Level.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Level");

            // PaxVesselType
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PaxVesselType"))
                    PaxVesselType.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PaxVesselType");
            if (Form.ContainsKey("z_PaxVesselType"))
                PaxVesselType.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PaxVesselType");

            // Image
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Image"))
                    Image.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Image");
            if (Form.ContainsKey("z_Image"))
                Image.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Image");

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

            // MTCertificateID
            MTCertificateID.RowCssClass = "row";

            // CountryOfIssue_CountryID
            CountryOfIssue_CountryID.RowCssClass = "row";

            // Number
            Number.RowCssClass = "row";

            // DateOfIssue
            DateOfIssue.RowCssClass = "row";

            // DateOfExpiry
            DateOfExpiry.RowCssClass = "row";

            // PlaceOfIssue
            PlaceOfIssue.RowCssClass = "row";

            // IssuingAuthority
            IssuingAuthority.RowCssClass = "row";

            // Level
            Level.RowCssClass = "row";

            // PaxVesselType
            PaxVesselType.RowCssClass = "row";

            // Image
            Image.RowCssClass = "row";

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

                // MTCertificateID
                MTCertificateID.SetupEditAttributes();
                curVal = ConvertToString(MTCertificateID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (MTCertificateID.Lookup != null && IsDictionary(MTCertificateID.Lookup?.Options) && MTCertificateID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTCertificateID.EditValue = MTCertificateID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTCertificateID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = MTCertificateID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTCertificateID.EditValue = rswrk;
                }
                MTCertificateID.PlaceHolder = RemoveHtml(MTCertificateID.Caption);

                // CountryOfIssue_CountryID
                CountryOfIssue_CountryID.SetupEditAttributes();
                curVal = ConvertToString(CountryOfIssue_CountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (CountryOfIssue_CountryID.Lookup != null && IsDictionary(CountryOfIssue_CountryID.Lookup?.Options) && CountryOfIssue_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CountryOfIssue_CountryID.EditValue = CountryOfIssue_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", CountryOfIssue_CountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = CountryOfIssue_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    CountryOfIssue_CountryID.EditValue = rswrk;
                }
                CountryOfIssue_CountryID.PlaceHolder = RemoveHtml(CountryOfIssue_CountryID.Caption);

                // Number
                Number.SetupEditAttributes();
                if (!Number.Raw)
                    Number.AdvancedSearch.SearchValue = HtmlDecode(Number.AdvancedSearch.SearchValue);
                Number.EditValue = HtmlEncode(Number.AdvancedSearch.SearchValue);
                Number.PlaceHolder = RemoveHtml(Number.Caption);

                // DateOfIssue
                DateOfIssue.SetupEditAttributes();
                DateOfIssue.EditValue = FormatDateTime(UnformatDateTime(DateOfIssue.AdvancedSearch.SearchValue, DateOfIssue.FormatPattern), DateOfIssue.FormatPattern); // DN
                DateOfIssue.PlaceHolder = RemoveHtml(DateOfIssue.Caption);

                // DateOfExpiry
                DateOfExpiry.SetupEditAttributes();
                DateOfExpiry.EditValue = FormatDateTime(UnformatDateTime(DateOfExpiry.AdvancedSearch.SearchValue, DateOfExpiry.FormatPattern), DateOfExpiry.FormatPattern); // DN
                DateOfExpiry.PlaceHolder = RemoveHtml(DateOfExpiry.Caption);

                // PlaceOfIssue
                PlaceOfIssue.SetupEditAttributes();
                if (!PlaceOfIssue.Raw)
                    PlaceOfIssue.AdvancedSearch.SearchValue = HtmlDecode(PlaceOfIssue.AdvancedSearch.SearchValue);
                PlaceOfIssue.EditValue = HtmlEncode(PlaceOfIssue.AdvancedSearch.SearchValue);
                PlaceOfIssue.PlaceHolder = RemoveHtml(PlaceOfIssue.Caption);

                // IssuingAuthority
                IssuingAuthority.SetupEditAttributes();
                if (!IssuingAuthority.Raw)
                    IssuingAuthority.AdvancedSearch.SearchValue = HtmlDecode(IssuingAuthority.AdvancedSearch.SearchValue);
                IssuingAuthority.EditValue = HtmlEncode(IssuingAuthority.AdvancedSearch.SearchValue);
                IssuingAuthority.PlaceHolder = RemoveHtml(IssuingAuthority.Caption);

                // Level
                Level.SetupEditAttributes();
                if (!Level.Raw)
                    Level.AdvancedSearch.SearchValue = HtmlDecode(Level.AdvancedSearch.SearchValue);
                Level.EditValue = HtmlEncode(Level.AdvancedSearch.SearchValue);
                Level.PlaceHolder = RemoveHtml(Level.Caption);

                // PaxVesselType
                PaxVesselType.SetupEditAttributes();
                if (!PaxVesselType.Raw)
                    PaxVesselType.AdvancedSearch.SearchValue = HtmlDecode(PaxVesselType.AdvancedSearch.SearchValue);
                PaxVesselType.EditValue = HtmlEncode(PaxVesselType.AdvancedSearch.SearchValue);
                PaxVesselType.PlaceHolder = RemoveHtml(PaxVesselType.Caption);

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
            if (!CheckDate(ConvertToString(DateOfIssue.AdvancedSearch.SearchValue), DateOfIssue.FormatPattern)) {
                DateOfIssue.AddErrorMessage(DateOfIssue.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(DateOfExpiry.AdvancedSearch.SearchValue), DateOfExpiry.FormatPattern)) {
                DateOfExpiry.AddErrorMessage(DateOfExpiry.GetErrorMessage(false));
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
            MTCertificateID.AdvancedSearch.Load();
            CountryOfIssue_CountryID.AdvancedSearch.Load();
            Number.AdvancedSearch.Load();
            DateOfIssue.AdvancedSearch.Load();
            DateOfExpiry.AdvancedSearch.Load();
            PlaceOfIssue.AdvancedSearch.Load();
            IssuingAuthority.AdvancedSearch.Load();
            Level.AdvancedSearch.Load();
            PaxVesselType.AdvancedSearch.Load();
            CreatedByUserID.AdvancedSearch.Load();
            CreatedDateTime.AdvancedSearch.Load();
            LastUpdatedByUserID.AdvancedSearch.Load();
            LastUpdatedDateTime.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MtCrewCertificateList")), "", TableVar, true);
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
