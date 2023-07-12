namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// checklistSearch
    /// </summary>
    public static ChecklistSearch checklistSearch
    {
        get => HttpData.Get<ChecklistSearch>("checklistSearch")!;
        set => HttpData["checklistSearch"] = value;
    }

    /// <summary>
    /// Page class for Checklist
    /// </summary>
    public class ChecklistSearch : ChecklistSearchBase
    {
        // Constructor
        public ChecklistSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public ChecklistSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class ChecklistSearchBase : Checklist
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "Checklist";

        // Page object name
        public string PageObjName = "checklistSearch";

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
        public ChecklistSearchBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (checklist)
            if (checklist == null || checklist is Checklist)
                checklist = this;

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
        public string PageName => "ChecklistSearch";

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
            EmployeeStatus.Visible = false;
            IndividualCodeNumber.SetVisibility();
            FullName.SetVisibility();
            RequiredPhoto.Visible = false;
            VisaPhoto.Visible = false;
            RankAppliedFor.SetVisibility();
            WillAcceptLowRank.SetVisibility();
            AvailableFrom.SetVisibility();
            AvailableUntil.SetVisibility();
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
            Activity14Attachment.Visible = false;
            Activity20.Visible = false;
            RemarkActivity20.Visible = false;
            Activity20Attachment.Visible = false;
            Activity30.Visible = false;
            RemarkActivity30.Visible = false;
            Activity30Attachment.Visible = false;
            Activity40.Visible = false;
            RemarkActivity40.Visible = false;
            Activity50.Visible = false;
            RemarkActivity50.Visible = false;
            Activity50Attachment.Visible = false;
            Activity60.Visible = false;
            RemarkActivity60.Visible = false;
            Activity70.Visible = false;
            RemarkActivity70.Visible = false;
            Activity70Attachment.Visible = false;
            InterviewerComment.Visible = false;
            InterviewDate.Visible = false;
            InterviewAttachment.Visible = false;
            InterviewedByPersonOneName.Visible = false;
            InterviewedByPersonOneRank.Visible = false;
            InterviewedByPersonTwoName.Visible = false;
            InterviewedByPersonTwoRank.Visible = false;
            InterviewedByPersonThreeName.Visible = false;
            InterviewedByPersonThreeRank.Visible = false;
            FinalInterviewComment.Visible = false;
            FinalInterviewAttachment.Visible = false;
            JobKnowledge.Visible = false;
            SafetyAwareness.Visible = false;
            Personality.Visible = false;
            EnglishProficiency.Visible = false;
            PrincipalComment.Visible = false;
            PrincipalCommentAttachment.Visible = false;
            AssistantManagerPdeReviewed.Visible = false;
            AssistantManagerPdeReviewedDate.Visible = false;
            CrewingManagerApproval.Visible = false;
            CrewingManagerApprovalDate.Visible = false;
            FormPrintoutAttachment.Visible = false;
            CreatedBy.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedBy.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
        }

        // Constructor
        public ChecklistSearchBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "ChecklistView" ? "1" : "0"); // If View page, no primary button
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
                EmployeeStatus.Visible = false;
            if (IsAddOrEdit)
                IndividualCodeNumber.Visible = false;
            if (IsAddOrEdit)
                FullName.Visible = false;
            if (IsAddOrEdit)
                RequiredPhoto.Visible = false;
            if (IsAddOrEdit)
                VisaPhoto.Visible = false;
            if (IsAddOrEdit)
                RankAppliedFor.Visible = false;
            if (IsAddOrEdit)
                WillAcceptLowRank.Visible = false;
            if (IsAddOrEdit)
                AvailableFrom.Visible = false;
            if (IsAddOrEdit)
                AvailableUntil.Visible = false;
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
            await SetupLookupOptions(WillAcceptLowRank);
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
            await SetupLookupOptions(AssistantManagerPdeReviewed);
            await SetupLookupOptions(CrewingManagerApproval);

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
                    srchStr = "ChecklistList?" + srchStr;
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
                checklistSearch?.PageRender();
            }
            return PageResult();
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, IndividualCodeNumber); // IndividualCodeNumber
            BuildSearchUrl(ref srchUrl, FullName); // FullName
            BuildSearchUrl(ref srchUrl, RankAppliedFor); // RankAppliedFor
            BuildSearchUrl(ref srchUrl, WillAcceptLowRank, true); // WillAcceptLowRank
            BuildSearchUrl(ref srchUrl, AvailableFrom); // AvailableFrom
            BuildSearchUrl(ref srchUrl, AvailableUntil); // AvailableUntil
            BuildSearchUrl(ref srchUrl, CreatedBy); // CreatedBy
            BuildSearchUrl(ref srchUrl, CreatedDateTime); // CreatedDateTime
            BuildSearchUrl(ref srchUrl, LastUpdatedBy); // LastUpdatedBy
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
            // EmployeeStatus
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_EmployeeStatus"))
                    EmployeeStatus.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_EmployeeStatus");
            if (Form.ContainsKey("z_EmployeeStatus"))
                EmployeeStatus.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_EmployeeStatus");

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

            // AvailableFrom
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AvailableFrom"))
                    AvailableFrom.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AvailableFrom");
            if (Form.ContainsKey("z_AvailableFrom"))
                AvailableFrom.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AvailableFrom");

            // AvailableUntil
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AvailableUntil"))
                    AvailableUntil.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AvailableUntil");
            if (Form.ContainsKey("z_AvailableUntil"))
                AvailableUntil.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AvailableUntil");

            // CreatedBy
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CreatedBy"))
                    CreatedBy.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CreatedBy");
            if (Form.ContainsKey("z_CreatedBy"))
                CreatedBy.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CreatedBy");

            // CreatedDateTime
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CreatedDateTime"))
                    CreatedDateTime.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CreatedDateTime");
            if (Form.ContainsKey("z_CreatedDateTime"))
                CreatedDateTime.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CreatedDateTime");

            // LastUpdatedBy
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_LastUpdatedBy"))
                    LastUpdatedBy.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_LastUpdatedBy");
            if (Form.ContainsKey("z_LastUpdatedBy"))
                LastUpdatedBy.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_LastUpdatedBy");

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
            EmployeeStatus.SetDbValue(row["EmployeeStatus"]);
            IndividualCodeNumber.SetDbValue(row["IndividualCodeNumber"]);
            FullName.SetDbValue(row["FullName"]);
            RequiredPhoto.Upload.DbValue = row["RequiredPhoto"];
            RequiredPhoto.SetDbValue(RequiredPhoto.Upload.DbValue);
            VisaPhoto.Upload.DbValue = row["VisaPhoto"];
            VisaPhoto.SetDbValue(VisaPhoto.Upload.DbValue);
            RankAppliedFor.SetDbValue(row["RankAppliedFor"]);
            WillAcceptLowRank.SetDbValue((ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"));
            AvailableFrom.SetDbValue(row["AvailableFrom"]);
            AvailableUntil.SetDbValue(row["AvailableUntil"]);
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
            Activity14Attachment.SetDbValue(row["Activity14Attachment"]);
            Activity20.SetDbValue((ConvertToBool(row["Activity20"]) ? "1" : "0"));
            RemarkActivity20.SetDbValue(row["RemarkActivity20"]);
            Activity20Attachment.SetDbValue(row["Activity20Attachment"]);
            Activity30.SetDbValue((ConvertToBool(row["Activity30"]) ? "1" : "0"));
            RemarkActivity30.SetDbValue(row["RemarkActivity30"]);
            Activity30Attachment.SetDbValue(row["Activity30Attachment"]);
            Activity40.SetDbValue((ConvertToBool(row["Activity40"]) ? "1" : "0"));
            RemarkActivity40.SetDbValue(row["RemarkActivity40"]);
            Activity50.SetDbValue((ConvertToBool(row["Activity50"]) ? "1" : "0"));
            RemarkActivity50.SetDbValue(row["RemarkActivity50"]);
            Activity50Attachment.SetDbValue(row["Activity50Attachment"]);
            Activity60.SetDbValue((ConvertToBool(row["Activity60"]) ? "1" : "0"));
            RemarkActivity60.SetDbValue(row["RemarkActivity60"]);
            Activity70.SetDbValue((ConvertToBool(row["Activity70"]) ? "1" : "0"));
            RemarkActivity70.SetDbValue(row["RemarkActivity70"]);
            Activity70Attachment.SetDbValue(row["Activity70Attachment"]);
            InterviewerComment.SetDbValue(row["InterviewerComment"]);
            InterviewDate.SetDbValue(row["InterviewDate"]);
            InterviewAttachment.SetDbValue(row["InterviewAttachment"]);
            InterviewedByPersonOneName.SetDbValue(row["InterviewedByPersonOneName"]);
            InterviewedByPersonOneRank.SetDbValue(row["InterviewedByPersonOneRank"]);
            InterviewedByPersonTwoName.SetDbValue(row["InterviewedByPersonTwoName"]);
            InterviewedByPersonTwoRank.SetDbValue(row["InterviewedByPersonTwoRank"]);
            InterviewedByPersonThreeName.SetDbValue(row["InterviewedByPersonThreeName"]);
            InterviewedByPersonThreeRank.SetDbValue(row["InterviewedByPersonThreeRank"]);
            FinalInterviewComment.SetDbValue(row["FinalInterviewComment"]);
            FinalInterviewAttachment.SetDbValue(row["FinalInterviewAttachment"]);
            JobKnowledge.SetDbValue(row["JobKnowledge"]);
            SafetyAwareness.SetDbValue(row["SafetyAwareness"]);
            Personality.SetDbValue(row["Personality"]);
            EnglishProficiency.SetDbValue(row["EnglishProficiency"]);
            PrincipalComment.SetDbValue(row["PrincipalComment"]);
            PrincipalCommentAttachment.SetDbValue(row["PrincipalCommentAttachment"]);
            AssistantManagerPdeReviewed.SetDbValue((ConvertToBool(row["AssistantManagerPdeReviewed"]) ? "1" : "0"));
            AssistantManagerPdeReviewedDate.SetDbValue(row["AssistantManagerPdeReviewedDate"]);
            CrewingManagerApproval.SetDbValue((ConvertToBool(row["CrewingManagerApproval"]) ? "1" : "0"));
            CrewingManagerApprovalDate.SetDbValue(row["CrewingManagerApprovalDate"]);
            FormPrintoutAttachment.SetDbValue(row["FormPrintoutAttachment"]);
            CreatedBy.SetDbValue(row["CreatedBy"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedBy.SetDbValue(row["LastUpdatedBy"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("MTCrewID", MTCrewID.DefaultValue ?? DbNullValue); // DN
            row.Add("EmployeeStatus", EmployeeStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("IndividualCodeNumber", IndividualCodeNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("RequiredPhoto", RequiredPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("VisaPhoto", VisaPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("RankAppliedFor", RankAppliedFor.DefaultValue ?? DbNullValue); // DN
            row.Add("WillAcceptLowRank", WillAcceptLowRank.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableFrom", AvailableFrom.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableUntil", AvailableUntil.DefaultValue ?? DbNullValue); // DN
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
            row.Add("Activity14Attachment", Activity14Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity20", Activity20.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity20", RemarkActivity20.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity20Attachment", Activity20Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity30", Activity30.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity30", RemarkActivity30.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity30Attachment", Activity30Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity40", Activity40.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity40", RemarkActivity40.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity50", Activity50.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity50", RemarkActivity50.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity50Attachment", Activity50Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity60", Activity60.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity60", RemarkActivity60.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity70", Activity70.DefaultValue ?? DbNullValue); // DN
            row.Add("RemarkActivity70", RemarkActivity70.DefaultValue ?? DbNullValue); // DN
            row.Add("Activity70Attachment", Activity70Attachment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewerComment", InterviewerComment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewDate", InterviewDate.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewAttachment", InterviewAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneName", InterviewedByPersonOneName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonOneRank", InterviewedByPersonOneRank.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoName", InterviewedByPersonTwoName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonTwoRank", InterviewedByPersonTwoRank.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeName", InterviewedByPersonThreeName.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewedByPersonThreeRank", InterviewedByPersonThreeRank.DefaultValue ?? DbNullValue); // DN
            row.Add("FinalInterviewComment", FinalInterviewComment.DefaultValue ?? DbNullValue); // DN
            row.Add("FinalInterviewAttachment", FinalInterviewAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("JobKnowledge", JobKnowledge.DefaultValue ?? DbNullValue); // DN
            row.Add("SafetyAwareness", SafetyAwareness.DefaultValue ?? DbNullValue); // DN
            row.Add("Personality", Personality.DefaultValue ?? DbNullValue); // DN
            row.Add("EnglishProficiency", EnglishProficiency.DefaultValue ?? DbNullValue); // DN
            row.Add("PrincipalComment", PrincipalComment.DefaultValue ?? DbNullValue); // DN
            row.Add("PrincipalCommentAttachment", PrincipalCommentAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("AssistantManagerPdeReviewed", AssistantManagerPdeReviewed.DefaultValue ?? DbNullValue); // DN
            row.Add("AssistantManagerPdeReviewedDate", AssistantManagerPdeReviewedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewingManagerApproval", CrewingManagerApproval.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewingManagerApprovalDate", CrewingManagerApprovalDate.DefaultValue ?? DbNullValue); // DN
            row.Add("FormPrintoutAttachment", FormPrintoutAttachment.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedBy", CreatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedBy", LastUpdatedBy.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
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

            // EmployeeStatus
            EmployeeStatus.RowCssClass = "row";

            // IndividualCodeNumber
            IndividualCodeNumber.RowCssClass = "row";

            // FullName
            FullName.RowCssClass = "row";

            // RequiredPhoto
            RequiredPhoto.RowCssClass = "row";

            // VisaPhoto
            VisaPhoto.RowCssClass = "row";

            // RankAppliedFor
            RankAppliedFor.RowCssClass = "row";

            // WillAcceptLowRank
            WillAcceptLowRank.RowCssClass = "row";

            // AvailableFrom
            AvailableFrom.RowCssClass = "row";

            // AvailableUntil
            AvailableUntil.RowCssClass = "row";

            // Activity10
            Activity10.RowCssClass = "row";

            // RemarkActivity10
            RemarkActivity10.RowCssClass = "row";

            // Activity11
            Activity11.RowCssClass = "row";

            // RemarkActivity11
            RemarkActivity11.RowCssClass = "row";

            // Activity12
            Activity12.RowCssClass = "row";

            // RemarkActivity12
            RemarkActivity12.RowCssClass = "row";

            // Activity13
            Activity13.RowCssClass = "row";

            // RemarkActivity13
            RemarkActivity13.RowCssClass = "row";

            // Activity14
            Activity14.RowCssClass = "row";

            // RemarkActivity14
            RemarkActivity14.RowCssClass = "row";

            // Activity14Attachment
            Activity14Attachment.RowCssClass = "row";

            // Activity20
            Activity20.RowCssClass = "row";

            // RemarkActivity20
            RemarkActivity20.RowCssClass = "row";

            // Activity20Attachment
            Activity20Attachment.RowCssClass = "row";

            // Activity30
            Activity30.RowCssClass = "row";

            // RemarkActivity30
            RemarkActivity30.RowCssClass = "row";

            // Activity30Attachment
            Activity30Attachment.RowCssClass = "row";

            // Activity40
            Activity40.RowCssClass = "row";

            // RemarkActivity40
            RemarkActivity40.RowCssClass = "row";

            // Activity50
            Activity50.RowCssClass = "row";

            // RemarkActivity50
            RemarkActivity50.RowCssClass = "row";

            // Activity50Attachment
            Activity50Attachment.RowCssClass = "row";

            // Activity60
            Activity60.RowCssClass = "row";

            // RemarkActivity60
            RemarkActivity60.RowCssClass = "row";

            // Activity70
            Activity70.RowCssClass = "row";

            // RemarkActivity70
            RemarkActivity70.RowCssClass = "row";

            // Activity70Attachment
            Activity70Attachment.RowCssClass = "row";

            // InterviewerComment
            InterviewerComment.RowCssClass = "row";

            // InterviewDate
            InterviewDate.RowCssClass = "row";

            // InterviewAttachment
            InterviewAttachment.RowCssClass = "row";

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.RowCssClass = "row";

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.RowCssClass = "row";

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.RowCssClass = "row";

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.RowCssClass = "row";

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.RowCssClass = "row";

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.RowCssClass = "row";

            // FinalInterviewComment
            FinalInterviewComment.RowCssClass = "row";

            // FinalInterviewAttachment
            FinalInterviewAttachment.RowCssClass = "row";

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

            // PrincipalCommentAttachment
            PrincipalCommentAttachment.RowCssClass = "row";

            // AssistantManagerPdeReviewed
            AssistantManagerPdeReviewed.RowCssClass = "row";

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.RowCssClass = "row";

            // CrewingManagerApproval
            CrewingManagerApproval.RowCssClass = "row";

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.RowCssClass = "row";

            // FormPrintoutAttachment
            FormPrintoutAttachment.RowCssClass = "row";

            // CreatedBy
            CreatedBy.RowCssClass = "row";

            // CreatedDateTime
            CreatedDateTime.RowCssClass = "row";

            // LastUpdatedBy
            LastUpdatedBy.RowCssClass = "row";

            // LastUpdatedDateTime
            LastUpdatedDateTime.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // EmployeeStatus
                EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
                EmployeeStatus.ViewCustomAttributes = "";

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

                // Activity10
                if (ConvertToBool(Activity10.CurrentValue)) {
                    Activity10.ViewValue = Activity10.TagCaption(1) != "" ? Activity10.TagCaption(1) : "Yes";
                } else {
                    Activity10.ViewValue = Activity10.TagCaption(2) != "" ? Activity10.TagCaption(2) : "No";
                }
                Activity10.ViewCustomAttributes = "";

                // RemarkActivity10
                RemarkActivity10.ViewValue = RemarkActivity10.CurrentValue;
                RemarkActivity10.ViewCustomAttributes = "";

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

                // Activity14Attachment
                Activity14Attachment.ViewValue = ConvertToString(Activity14Attachment.CurrentValue); // DN
                Activity14Attachment.ViewCustomAttributes = "";

                // Activity20
                if (ConvertToBool(Activity20.CurrentValue)) {
                    Activity20.ViewValue = Activity20.TagCaption(1) != "" ? Activity20.TagCaption(1) : "Yes";
                } else {
                    Activity20.ViewValue = Activity20.TagCaption(2) != "" ? Activity20.TagCaption(2) : "No";
                }
                Activity20.ViewCustomAttributes = "";

                // Activity20Attachment
                Activity20Attachment.ViewValue = ConvertToString(Activity20Attachment.CurrentValue); // DN
                Activity20Attachment.ViewCustomAttributes = "";

                // Activity30
                if (ConvertToBool(Activity30.CurrentValue)) {
                    Activity30.ViewValue = Activity30.TagCaption(1) != "" ? Activity30.TagCaption(1) : "Yes";
                } else {
                    Activity30.ViewValue = Activity30.TagCaption(2) != "" ? Activity30.TagCaption(2) : "No";
                }
                Activity30.ViewCustomAttributes = "";

                // Activity30Attachment
                Activity30Attachment.ViewValue = ConvertToString(Activity30Attachment.CurrentValue); // DN
                Activity30Attachment.ViewCustomAttributes = "";

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

                // Activity50Attachment
                Activity50Attachment.ViewValue = ConvertToString(Activity50Attachment.CurrentValue); // DN
                Activity50Attachment.ViewCustomAttributes = "";

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

                // Activity70Attachment
                Activity70Attachment.ViewValue = ConvertToString(Activity70Attachment.CurrentValue); // DN
                Activity70Attachment.ViewCustomAttributes = "";

                // InterviewerComment
                InterviewerComment.ViewValue = ConvertToString(InterviewerComment.CurrentValue); // DN
                InterviewerComment.ViewCustomAttributes = "";

                // InterviewDate
                InterviewDate.ViewValue = InterviewDate.CurrentValue;
                InterviewDate.ViewValue = FormatDateTime(InterviewDate.ViewValue, InterviewDate.FormatPattern);
                InterviewDate.ViewCustomAttributes = "";

                // InterviewAttachment
                InterviewAttachment.ViewValue = ConvertToString(InterviewAttachment.CurrentValue); // DN
                InterviewAttachment.ViewCustomAttributes = "";

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.ViewValue = ConvertToString(InterviewedByPersonOneName.CurrentValue); // DN
                InterviewedByPersonOneName.ViewCustomAttributes = "";

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.ViewValue = ConvertToString(InterviewedByPersonOneRank.CurrentValue); // DN
                InterviewedByPersonOneRank.ViewCustomAttributes = "";

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

                // FinalInterviewComment
                FinalInterviewComment.ViewValue = ConvertToString(FinalInterviewComment.CurrentValue); // DN
                FinalInterviewComment.ViewCustomAttributes = "";

                // FinalInterviewAttachment
                FinalInterviewAttachment.ViewValue = ConvertToString(FinalInterviewAttachment.CurrentValue); // DN
                FinalInterviewAttachment.ViewCustomAttributes = "";

                // JobKnowledge
                JobKnowledge.ViewValue = ConvertToString(JobKnowledge.CurrentValue); // DN
                JobKnowledge.ViewCustomAttributes = "";

                // SafetyAwareness
                SafetyAwareness.ViewValue = ConvertToString(SafetyAwareness.CurrentValue); // DN
                SafetyAwareness.ViewCustomAttributes = "";

                // Personality
                Personality.ViewValue = ConvertToString(Personality.CurrentValue); // DN
                Personality.ViewCustomAttributes = "";

                // EnglishProficiency
                EnglishProficiency.ViewValue = ConvertToString(EnglishProficiency.CurrentValue); // DN
                EnglishProficiency.ViewCustomAttributes = "";

                // PrincipalComment
                PrincipalComment.ViewValue = ConvertToString(PrincipalComment.CurrentValue); // DN
                PrincipalComment.ViewCustomAttributes = "";

                // PrincipalCommentAttachment
                PrincipalCommentAttachment.ViewValue = ConvertToString(PrincipalCommentAttachment.CurrentValue); // DN
                PrincipalCommentAttachment.ViewCustomAttributes = "";

                // AssistantManagerPdeReviewed
                if (ConvertToBool(AssistantManagerPdeReviewed.CurrentValue)) {
                    AssistantManagerPdeReviewed.ViewValue = AssistantManagerPdeReviewed.TagCaption(1) != "" ? AssistantManagerPdeReviewed.TagCaption(1) : "Yes";
                } else {
                    AssistantManagerPdeReviewed.ViewValue = AssistantManagerPdeReviewed.TagCaption(2) != "" ? AssistantManagerPdeReviewed.TagCaption(2) : "No";
                }
                AssistantManagerPdeReviewed.ViewCustomAttributes = "";

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.ViewValue = AssistantManagerPdeReviewedDate.CurrentValue;
                AssistantManagerPdeReviewedDate.ViewValue = FormatDateTime(AssistantManagerPdeReviewedDate.ViewValue, AssistantManagerPdeReviewedDate.FormatPattern);
                AssistantManagerPdeReviewedDate.ViewCustomAttributes = "";

                // CrewingManagerApproval
                if (ConvertToBool(CrewingManagerApproval.CurrentValue)) {
                    CrewingManagerApproval.ViewValue = CrewingManagerApproval.TagCaption(1) != "" ? CrewingManagerApproval.TagCaption(1) : "Yes";
                } else {
                    CrewingManagerApproval.ViewValue = CrewingManagerApproval.TagCaption(2) != "" ? CrewingManagerApproval.TagCaption(2) : "No";
                }
                CrewingManagerApproval.ViewCustomAttributes = "";

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.ViewValue = CrewingManagerApprovalDate.CurrentValue;
                CrewingManagerApprovalDate.ViewValue = FormatDateTime(CrewingManagerApprovalDate.ViewValue, CrewingManagerApprovalDate.FormatPattern);
                CrewingManagerApprovalDate.ViewCustomAttributes = "";

                // FormPrintoutAttachment
                FormPrintoutAttachment.ViewValue = ConvertToString(FormPrintoutAttachment.CurrentValue); // DN
                FormPrintoutAttachment.ViewCustomAttributes = "";

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

                // RankAppliedFor
                RankAppliedFor.SetupEditAttributes();
                if (!RankAppliedFor.Raw)
                    RankAppliedFor.AdvancedSearch.SearchValue = HtmlDecode(RankAppliedFor.AdvancedSearch.SearchValue);
                RankAppliedFor.EditValue = HtmlEncode(RankAppliedFor.AdvancedSearch.SearchValue);
                RankAppliedFor.PlaceHolder = RemoveHtml(RankAppliedFor.Caption);

                // WillAcceptLowRank
                WillAcceptLowRank.EditValue = WillAcceptLowRank.Options(false);
                WillAcceptLowRank.PlaceHolder = RemoveHtml(WillAcceptLowRank.Caption);

                // AvailableFrom
                AvailableFrom.SetupEditAttributes();
                AvailableFrom.EditValue = FormatDateTime(UnformatDateTime(AvailableFrom.AdvancedSearch.SearchValue, AvailableFrom.FormatPattern), AvailableFrom.FormatPattern); // DN
                AvailableFrom.PlaceHolder = RemoveHtml(AvailableFrom.Caption);

                // AvailableUntil
                AvailableUntil.SetupEditAttributes();
                AvailableUntil.EditValue = FormatDateTime(UnformatDateTime(AvailableUntil.AdvancedSearch.SearchValue, AvailableUntil.FormatPattern), AvailableUntil.FormatPattern); // DN
                AvailableUntil.PlaceHolder = RemoveHtml(AvailableUntil.Caption);

                // CreatedBy
                CreatedBy.SetupEditAttributes();
                if (!CreatedBy.Raw)
                    CreatedBy.AdvancedSearch.SearchValue = HtmlDecode(CreatedBy.AdvancedSearch.SearchValue);
                CreatedBy.EditValue = HtmlEncode(CreatedBy.AdvancedSearch.SearchValue);
                CreatedBy.PlaceHolder = RemoveHtml(CreatedBy.Caption);

                // CreatedDateTime
                CreatedDateTime.SetupEditAttributes();
                CreatedDateTime.EditValue = FormatDateTime(UnformatDateTime(CreatedDateTime.AdvancedSearch.SearchValue, CreatedDateTime.FormatPattern), CreatedDateTime.FormatPattern); // DN
                CreatedDateTime.PlaceHolder = RemoveHtml(CreatedDateTime.Caption);

                // LastUpdatedBy
                LastUpdatedBy.SetupEditAttributes();
                if (!LastUpdatedBy.Raw)
                    LastUpdatedBy.AdvancedSearch.SearchValue = HtmlDecode(LastUpdatedBy.AdvancedSearch.SearchValue);
                LastUpdatedBy.EditValue = HtmlEncode(LastUpdatedBy.AdvancedSearch.SearchValue);
                LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);

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
            if (!CheckDate(ConvertToString(AvailableFrom.AdvancedSearch.SearchValue), AvailableFrom.FormatPattern)) {
                AvailableFrom.AddErrorMessage(AvailableFrom.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(AvailableUntil.AdvancedSearch.SearchValue), AvailableUntil.FormatPattern)) {
                AvailableUntil.AddErrorMessage(AvailableUntil.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(CreatedBy.AdvancedSearch.SearchValue))) {
                CreatedBy.AddErrorMessage(CreatedBy.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(CreatedDateTime.AdvancedSearch.SearchValue), CreatedDateTime.FormatPattern)) {
                CreatedDateTime.AddErrorMessage(CreatedDateTime.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(LastUpdatedBy.AdvancedSearch.SearchValue))) {
                LastUpdatedBy.AddErrorMessage(LastUpdatedBy.GetErrorMessage(false));
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
            IndividualCodeNumber.AdvancedSearch.Load();
            FullName.AdvancedSearch.Load();
            RankAppliedFor.AdvancedSearch.Load();
            WillAcceptLowRank.AdvancedSearch.Load();
            AvailableFrom.AdvancedSearch.Load();
            AvailableUntil.AdvancedSearch.Load();
            CreatedBy.AdvancedSearch.Load();
            CreatedDateTime.AdvancedSearch.Load();
            LastUpdatedBy.AdvancedSearch.Load();
            LastUpdatedDateTime.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("ChecklistList")), "", TableVar, true);
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
