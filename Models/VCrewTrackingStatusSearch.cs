namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// vCrewTrackingStatusSearch
    /// </summary>
    public static VCrewTrackingStatusSearch vCrewTrackingStatusSearch
    {
        get => HttpData.Get<VCrewTrackingStatusSearch>("vCrewTrackingStatusSearch")!;
        set => HttpData["vCrewTrackingStatusSearch"] = value;
    }

    /// <summary>
    /// Page class for v_CrewTrackingStatus
    /// </summary>
    public class VCrewTrackingStatusSearch : VCrewTrackingStatusSearchBase
    {
        // Constructor
        public VCrewTrackingStatusSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public VCrewTrackingStatusSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class VCrewTrackingStatusSearchBase : VCrewTrackingStatus
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "v_CrewTrackingStatus";

        // Page object name
        public string PageObjName = "vCrewTrackingStatusSearch";

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
        public VCrewTrackingStatusSearchBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (vCrewTrackingStatus)
            if (vCrewTrackingStatus == null || vCrewTrackingStatus is VCrewTrackingStatus)
                vCrewTrackingStatus = this;

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
        public string PageName => "VCrewTrackingStatusSearch";

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
        public VCrewTrackingStatusSearchBase(Controller? controller = null): this() { // DN
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
            await SetupLookupOptions(Gender);
            await SetupLookupOptions(WillAcceptLowRank);

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
                    srchStr = "VCrewTrackingStatusList?" + srchStr;
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
                vCrewTrackingStatusSearch?.PageRender();
            }
            return PageResult();
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, IndividualCodeNumber); // IndividualCodeNumber
            BuildSearchUrl(ref srchUrl, FullName); // FullName
            BuildSearchUrl(ref srchUrl, RequiredPhoto); // RequiredPhoto
            BuildSearchUrl(ref srchUrl, VisaPhoto); // VisaPhoto
            BuildSearchUrl(ref srchUrl, Gender); // Gender
            BuildSearchUrl(ref srchUrl, RankAppliedFor); // RankAppliedFor
            BuildSearchUrl(ref srchUrl, WillAcceptLowRank, true); // WillAcceptLowRank
            BuildSearchUrl(ref srchUrl, EmployeeStatus); // EmployeeStatus
            BuildSearchUrl(ref srchUrl, Draft); // Draft
            BuildSearchUrl(ref srchUrl, Submitted); // Submitted
            BuildSearchUrl(ref srchUrl, Reviewed); // Reviewed
            BuildSearchUrl(ref srchUrl, RegistrationForm); // RegistrationForm
            BuildSearchUrl(ref srchUrl, PreScreeningInterview); // PreScreeningInterview
            BuildSearchUrl(ref srchUrl, MinimumRecruitmentCheck); // MinimumRecruitmentCheck
            BuildSearchUrl(ref srchUrl, EngagementChecklist); // EngagementChecklist
            BuildSearchUrl(ref srchUrl, COCAuthenticity); // COCAuthenticity
            BuildSearchUrl(ref srchUrl, CESTest); // CESTest
            BuildSearchUrl(ref srchUrl, PyschometricTest); // PyschometricTest
            BuildSearchUrl(ref srchUrl, CrewWatchlist); // CrewWatchlist
            BuildSearchUrl(ref srchUrl, PreviousAppraisalReport); // PreviousAppraisalReport
            BuildSearchUrl(ref srchUrl, ContractBackgroundCheck); // ContractBackgroundCheck
            BuildSearchUrl(ref srchUrl, EnglishProficiencyTestOrMarline); // EnglishProficiencyTestOrMarline
            BuildSearchUrl(ref srchUrl, Interviewed); // Interviewed
            BuildSearchUrl(ref srchUrl, Approved); // Approved
            BuildSearchUrl(ref srchUrl, MedicalCheckup); // MedicalCheckup
            BuildSearchUrl(ref srchUrl, CreatedBy); // CreatedBy
            BuildSearchUrl(ref srchUrl, LastUpdatedBy); // LastUpdatedBy
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
            // IndividualCodeNumber
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_IndividualCodeNumber"))
                    IndividualCodeNumber.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_IndividualCodeNumber");
            if (Form.ContainsKey("z_IndividualCodeNumber"))
                IndividualCodeNumber.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_IndividualCodeNumber");

            // FullName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_FullName"))
                    FullName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_FullName");
            if (Form.ContainsKey("z_FullName"))
                FullName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_FullName");

            // RequiredPhoto
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_RequiredPhoto"))
                    RequiredPhoto.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_RequiredPhoto");
            if (Form.ContainsKey("z_RequiredPhoto"))
                RequiredPhoto.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_RequiredPhoto");

            // VisaPhoto
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_VisaPhoto"))
                    VisaPhoto.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_VisaPhoto");
            if (Form.ContainsKey("z_VisaPhoto"))
                VisaPhoto.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_VisaPhoto");

            // Gender
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Gender"))
                    Gender.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Gender");
            if (Form.ContainsKey("z_Gender"))
                Gender.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Gender");

            // RankAppliedFor
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_RankAppliedFor"))
                    RankAppliedFor.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_RankAppliedFor");
            if (Form.ContainsKey("z_RankAppliedFor"))
                RankAppliedFor.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_RankAppliedFor");

            // WillAcceptLowRank
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_WillAcceptLowRank"))
                    WillAcceptLowRank.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_WillAcceptLowRank");
            if (Form.ContainsKey("z_WillAcceptLowRank"))
                WillAcceptLowRank.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_WillAcceptLowRank");

            // EmployeeStatus
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_EmployeeStatus"))
                    EmployeeStatus.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_EmployeeStatus");
            if (Form.ContainsKey("z_EmployeeStatus"))
                EmployeeStatus.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_EmployeeStatus");

            // Draft
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Draft"))
                    Draft.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Draft");
            if (Form.ContainsKey("z_Draft"))
                Draft.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Draft");

            // Submitted
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Submitted"))
                    Submitted.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Submitted");
            if (Form.ContainsKey("z_Submitted"))
                Submitted.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Submitted");

            // Reviewed
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reviewed"))
                    Reviewed.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reviewed");
            if (Form.ContainsKey("z_Reviewed"))
                Reviewed.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reviewed");

            // RegistrationForm
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_RegistrationForm"))
                    RegistrationForm.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_RegistrationForm");
            if (Form.ContainsKey("z_RegistrationForm"))
                RegistrationForm.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_RegistrationForm");

            // PreScreeningInterview
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PreScreeningInterview"))
                    PreScreeningInterview.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PreScreeningInterview");
            if (Form.ContainsKey("z_PreScreeningInterview"))
                PreScreeningInterview.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PreScreeningInterview");

            // MinimumRecruitmentCheck
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MinimumRecruitmentCheck"))
                    MinimumRecruitmentCheck.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MinimumRecruitmentCheck");
            if (Form.ContainsKey("z_MinimumRecruitmentCheck"))
                MinimumRecruitmentCheck.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MinimumRecruitmentCheck");

            // EngagementChecklist
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_EngagementChecklist"))
                    EngagementChecklist.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_EngagementChecklist");
            if (Form.ContainsKey("z_EngagementChecklist"))
                EngagementChecklist.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_EngagementChecklist");

            // COCAuthenticity
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_COCAuthenticity"))
                    COCAuthenticity.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_COCAuthenticity");
            if (Form.ContainsKey("z_COCAuthenticity"))
                COCAuthenticity.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_COCAuthenticity");

            // CESTest
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CESTest"))
                    CESTest.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CESTest");
            if (Form.ContainsKey("z_CESTest"))
                CESTest.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CESTest");

            // PyschometricTest
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PyschometricTest"))
                    PyschometricTest.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PyschometricTest");
            if (Form.ContainsKey("z_PyschometricTest"))
                PyschometricTest.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PyschometricTest");

            // CrewWatchlist
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CrewWatchlist"))
                    CrewWatchlist.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CrewWatchlist");
            if (Form.ContainsKey("z_CrewWatchlist"))
                CrewWatchlist.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CrewWatchlist");

            // PreviousAppraisalReport
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PreviousAppraisalReport"))
                    PreviousAppraisalReport.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PreviousAppraisalReport");
            if (Form.ContainsKey("z_PreviousAppraisalReport"))
                PreviousAppraisalReport.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PreviousAppraisalReport");

            // ContractBackgroundCheck
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ContractBackgroundCheck"))
                    ContractBackgroundCheck.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ContractBackgroundCheck");
            if (Form.ContainsKey("z_ContractBackgroundCheck"))
                ContractBackgroundCheck.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ContractBackgroundCheck");

            // EnglishProficiencyTestOrMarline
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_EnglishProficiencyTestOrMarline"))
                    EnglishProficiencyTestOrMarline.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_EnglishProficiencyTestOrMarline");
            if (Form.ContainsKey("z_EnglishProficiencyTestOrMarline"))
                EnglishProficiencyTestOrMarline.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_EnglishProficiencyTestOrMarline");

            // Interviewed
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Interviewed"))
                    Interviewed.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Interviewed");
            if (Form.ContainsKey("z_Interviewed"))
                Interviewed.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Interviewed");

            // Approved
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Approved"))
                    Approved.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Approved");
            if (Form.ContainsKey("z_Approved"))
                Approved.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Approved");

            // MedicalCheckup
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MedicalCheckup"))
                    MedicalCheckup.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MedicalCheckup");
            if (Form.ContainsKey("z_MedicalCheckup"))
                MedicalCheckup.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MedicalCheckup");

            // CreatedBy
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CreatedBy"))
                    CreatedBy.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CreatedBy");
            if (Form.ContainsKey("z_CreatedBy"))
                CreatedBy.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CreatedBy");

            // LastUpdatedBy
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_LastUpdatedBy"))
                    LastUpdatedBy.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_LastUpdatedBy");
            if (Form.ContainsKey("z_LastUpdatedBy"))
                LastUpdatedBy.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_LastUpdatedBy");
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

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // ID
            ID.RowCssClass = "row";

            // IndividualCodeNumber
            IndividualCodeNumber.RowCssClass = "row";

            // FullName
            FullName.RowCssClass = "row";

            // RequiredPhoto
            RequiredPhoto.RowCssClass = "row";

            // VisaPhoto
            VisaPhoto.RowCssClass = "row";

            // Gender
            Gender.RowCssClass = "row";

            // RankAppliedFor
            RankAppliedFor.RowCssClass = "row";

            // WillAcceptLowRank
            WillAcceptLowRank.RowCssClass = "row";

            // EmployeeStatus
            EmployeeStatus.RowCssClass = "row";

            // Draft
            Draft.RowCssClass = "row";

            // Submitted
            Submitted.RowCssClass = "row";

            // Reviewed
            Reviewed.RowCssClass = "row";

            // RegistrationForm
            RegistrationForm.RowCssClass = "row";

            // PreScreeningInterview
            PreScreeningInterview.RowCssClass = "row";

            // MinimumRecruitmentCheck
            MinimumRecruitmentCheck.RowCssClass = "row";

            // EngagementChecklist
            EngagementChecklist.RowCssClass = "row";

            // COCAuthenticity
            COCAuthenticity.RowCssClass = "row";

            // CESTest
            CESTest.RowCssClass = "row";

            // PyschometricTest
            PyschometricTest.RowCssClass = "row";

            // CrewWatchlist
            CrewWatchlist.RowCssClass = "row";

            // PreviousAppraisalReport
            PreviousAppraisalReport.RowCssClass = "row";

            // ContractBackgroundCheck
            ContractBackgroundCheck.RowCssClass = "row";

            // EnglishProficiencyTestOrMarline
            EnglishProficiencyTestOrMarline.RowCssClass = "row";

            // Interviewed
            Interviewed.RowCssClass = "row";

            // Approved
            Approved.RowCssClass = "row";

            // MedicalCheckup
            MedicalCheckup.RowCssClass = "row";

            // CreatedBy
            CreatedBy.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

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
                IndividualCodeNumber.SetupEditAttributes();
                if (!IndividualCodeNumber.Raw)
                    IndividualCodeNumber.AdvancedSearch.SearchValue = HtmlDecode(IndividualCodeNumber.AdvancedSearch.SearchValue);
                IndividualCodeNumber.EditValue = HtmlEncode(IndividualCodeNumber.AdvancedSearch.SearchValue);
                IndividualCodeNumber.PlaceHolder = RemoveHtml(IndividualCodeNumber.Caption);

                // FullName
                FullName.SetupEditAttributes();
                if (!FullName.Raw)
                    FullName.AdvancedSearch.SearchValue = HtmlDecode(FullName.AdvancedSearch.SearchValue);
                FullName.EditValue = HtmlEncode(FullName.AdvancedSearch.SearchValue);
                FullName.PlaceHolder = RemoveHtml(FullName.Caption);

                // RequiredPhoto
                RequiredPhoto.SetupEditAttributes();
                if (!RequiredPhoto.Raw)
                    RequiredPhoto.AdvancedSearch.SearchValue = HtmlDecode(RequiredPhoto.AdvancedSearch.SearchValue);
                RequiredPhoto.EditValue = HtmlEncode(RequiredPhoto.AdvancedSearch.SearchValue);
                RequiredPhoto.PlaceHolder = RemoveHtml(RequiredPhoto.Caption);

                // VisaPhoto
                VisaPhoto.SetupEditAttributes();
                if (!VisaPhoto.Raw)
                    VisaPhoto.AdvancedSearch.SearchValue = HtmlDecode(VisaPhoto.AdvancedSearch.SearchValue);
                VisaPhoto.EditValue = HtmlEncode(VisaPhoto.AdvancedSearch.SearchValue);
                VisaPhoto.PlaceHolder = RemoveHtml(VisaPhoto.Caption);

                // Gender
                Gender.SetupEditAttributes();
                if (!Gender.Raw)
                    Gender.AdvancedSearch.SearchValue = HtmlDecode(Gender.AdvancedSearch.SearchValue);
                Gender.EditValue = HtmlEncode(Gender.AdvancedSearch.SearchValue);
                Gender.PlaceHolder = RemoveHtml(Gender.Caption);

                // RankAppliedFor
                RankAppliedFor.SetupEditAttributes();
                if (!RankAppliedFor.Raw)
                    RankAppliedFor.AdvancedSearch.SearchValue = HtmlDecode(RankAppliedFor.AdvancedSearch.SearchValue);
                RankAppliedFor.EditValue = HtmlEncode(RankAppliedFor.AdvancedSearch.SearchValue);
                RankAppliedFor.PlaceHolder = RemoveHtml(RankAppliedFor.Caption);

                // WillAcceptLowRank
                WillAcceptLowRank.EditValue = WillAcceptLowRank.Options(false);
                WillAcceptLowRank.PlaceHolder = RemoveHtml(WillAcceptLowRank.Caption);

                // EmployeeStatus
                EmployeeStatus.SetupEditAttributes();
                if (!EmployeeStatus.Raw)
                    EmployeeStatus.AdvancedSearch.SearchValue = HtmlDecode(EmployeeStatus.AdvancedSearch.SearchValue);
                EmployeeStatus.EditValue = HtmlEncode(EmployeeStatus.AdvancedSearch.SearchValue);
                EmployeeStatus.PlaceHolder = RemoveHtml(EmployeeStatus.Caption);

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
            if (!CheckInteger(ConvertToString(Draft.AdvancedSearch.SearchValue))) {
                Draft.AddErrorMessage(Draft.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(Submitted.AdvancedSearch.SearchValue))) {
                Submitted.AddErrorMessage(Submitted.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(Reviewed.AdvancedSearch.SearchValue))) {
                Reviewed.AddErrorMessage(Reviewed.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(RegistrationForm.AdvancedSearch.SearchValue))) {
                RegistrationForm.AddErrorMessage(RegistrationForm.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(PreScreeningInterview.AdvancedSearch.SearchValue))) {
                PreScreeningInterview.AddErrorMessage(PreScreeningInterview.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(MinimumRecruitmentCheck.AdvancedSearch.SearchValue))) {
                MinimumRecruitmentCheck.AddErrorMessage(MinimumRecruitmentCheck.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(EngagementChecklist.AdvancedSearch.SearchValue))) {
                EngagementChecklist.AddErrorMessage(EngagementChecklist.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(COCAuthenticity.AdvancedSearch.SearchValue))) {
                COCAuthenticity.AddErrorMessage(COCAuthenticity.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(CESTest.AdvancedSearch.SearchValue))) {
                CESTest.AddErrorMessage(CESTest.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(PyschometricTest.AdvancedSearch.SearchValue))) {
                PyschometricTest.AddErrorMessage(PyschometricTest.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(CrewWatchlist.AdvancedSearch.SearchValue))) {
                CrewWatchlist.AddErrorMessage(CrewWatchlist.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(PreviousAppraisalReport.AdvancedSearch.SearchValue))) {
                PreviousAppraisalReport.AddErrorMessage(PreviousAppraisalReport.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(ContractBackgroundCheck.AdvancedSearch.SearchValue))) {
                ContractBackgroundCheck.AddErrorMessage(ContractBackgroundCheck.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(EnglishProficiencyTestOrMarline.AdvancedSearch.SearchValue))) {
                EnglishProficiencyTestOrMarline.AddErrorMessage(EnglishProficiencyTestOrMarline.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(Interviewed.AdvancedSearch.SearchValue))) {
                Interviewed.AddErrorMessage(Interviewed.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(Approved.AdvancedSearch.SearchValue))) {
                Approved.AddErrorMessage(Approved.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(MedicalCheckup.AdvancedSearch.SearchValue))) {
                MedicalCheckup.AddErrorMessage(MedicalCheckup.GetErrorMessage(false));
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

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("VCrewTrackingStatusList")), "", TableVar, true);
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
