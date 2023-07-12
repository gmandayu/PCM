namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewChecklistForAdminView
    /// </summary>
    public static CrewChecklistForAdminView crewChecklistForAdminView
    {
        get => HttpData.Get<CrewChecklistForAdminView>("crewChecklistForAdminView")!;
        set => HttpData["crewChecklistForAdminView"] = value;
    }

    /// <summary>
    /// Page class for CrewChecklistForAdmin
    /// </summary>
    public class CrewChecklistForAdminView : CrewChecklistForAdminViewBase
    {
        // Constructor
        public CrewChecklistForAdminView(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewChecklistForAdminView() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewChecklistForAdminViewBase : CrewChecklistForAdmin
    {
        // Page ID
        public string PageID = "view";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewChecklistForAdmin";

        // Page object name
        public string PageObjName = "crewChecklistForAdminView";

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
        public CrewChecklistForAdminViewBase()
        {
            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-view-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (crewChecklistForAdmin)
            if (crewChecklistForAdmin == null || crewChecklistForAdmin is CrewChecklistForAdmin)
                crewChecklistForAdmin = this;

            // DN
            string[] keys = new string[0];
            StringValues str = "";
            object? obj = null;
            string currentPageName = CurrentPageName();
            string currentUrl = AppPath(currentPageName); // DN
            if (IsApi()) {
                if (RouteValues.TryGetValue("key", out object? k) && !Empty(k))
                    keys = ConvertToString(k).Split('/');
                if (keys.Length > 0)
                    RecordKeys["ID"] = keys[0];
            } else {
                RecordKeys["ID"] = RouteValues.TryGetValue("ID", out obj) && obj != null ? UrlDecode(obj) : Get("ID"); // DN
            }

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
            OtherOptions["detail"] = new () { TagClassName = "ew-detail-option" };
            OtherOptions["action"] = new () { TagClassName = "ew-action-option" };
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
        public string PageName => "CrewChecklistForAdminView";

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
            ID.SetVisibility();
            MTCrewID.SetVisibility();
            Activity10.SetVisibility();
            RemarkActivity10.SetVisibility();
            Activity11.SetVisibility();
            RemarkActivity11.SetVisibility();
            Activity12.SetVisibility();
            RemarkActivity12.SetVisibility();
            Activity13.SetVisibility();
            RemarkActivity13.SetVisibility();
            Activity14.SetVisibility();
            RemarkActivity14.SetVisibility();
            Activity20.SetVisibility();
            RemarkActivity20.SetVisibility();
            Activity30.SetVisibility();
            RemarkActivity30.SetVisibility();
            Activity40.SetVisibility();
            RemarkActivity40.SetVisibility();
            Activity50.SetVisibility();
            RemarkActivity50.SetVisibility();
            Activity60.SetVisibility();
            RemarkActivity60.SetVisibility();
            Activity70.SetVisibility();
            RemarkActivity70.SetVisibility();
            InterviewerComment.SetVisibility();
            JobKnowledge.SetVisibility();
            SafetyAwareness.SetVisibility();
            Personality.SetVisibility();
            EnglishProficiency.SetVisibility();
            PrincipalComment.SetVisibility();
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            FinalInterviewComment.SetVisibility();
            InterviewedByPersonOneName.SetVisibility();
            InterviewedByPersonOneRank.SetVisibility();
            AssistantManagerPdeReviewedDate.SetVisibility();
            InterviewedByPersonTwoName.SetVisibility();
            InterviewedByPersonTwoRank.SetVisibility();
            InterviewedByPersonThreeName.SetVisibility();
            InterviewedByPersonThreeRank.SetVisibility();
            CrewingManagerApprovalDate.SetVisibility();
            Activity14Attachment.SetVisibility();
            Activity20Attachment.SetVisibility();
            Activity30Attachment.SetVisibility();
            Activity50Attachment.SetVisibility();
            Activity70Attachment.SetVisibility();
            FinalInterviewAttachment.SetVisibility();
            PrincipalCommentAttachment.SetVisibility();
            FormPrintoutAttachment.SetVisibility();
            AssistantManagerPdeReviewed.SetVisibility();
            CrewingManagerApproval.SetVisibility();
            InterviewDate.SetVisibility();
            InterviewAttachment.SetVisibility();
            ApprovedByUserID1.SetVisibility();
            ApprovedByUserID2.SetVisibility();
        }

        // Constructor
        public CrewChecklistForAdminViewBase(Controller? controller = null): this() { // DN
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
        }

        public int DisplayRecords = 1; // Number of display records

        public int StartRecord;

        public int StopRecord;

        public int TotalRecords = -1;

        public int RecordRange = 10;

        public int RecordCount;

        public Dictionary<string, string> RecordKeys = new ();

        public bool IsModal = false;

        public string SearchWhere = "";

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public bool MasterRecordExists;

        public DbDataReader? Recordset = null;

        #pragma warning disable 168, 219
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

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;

            // Load current record
            bool loadCurrentRecord = false;
            string returnUrl = "";
            bool matchRecord = false;
            string[] keyValues = {};
            object? v;
            StringValues sv;
            if (IsApi()) {
                if (RouteValues.TryGetValue(Config.ApiKeyName, out object? k)) {
                    if (!Empty(k))
                        keyValues = ConvertToString(k).Split('/');
                } else { // Get key from query string
                    string key = Get(Config.ApiKeyName);
                    if (!Empty(key))
                        keyValues = key.Split(',');
                }
                if (keyValues.Length == 0)
                    return new JsonBoolResult(new { success = false, error = Language.Phrase("NoRecord"), version = Config.ProductVersion }, false);
            }
            if (RouteValues.TryGetValue("ID", out v) && !Empty(v)) { // DN
                ID.QueryValue = UrlDecode(v); // DN
                RecordKeys["ID"] = ID.QueryValue;
            } else if (Get("ID", out sv)) {
                ID.QueryValue = sv.ToString();
                RecordKeys["ID"] = ID.QueryValue;
            } else if (IsApi() && !Empty(keyValues)) {
                ID.QueryValue = ConvertToString(keyValues[0]);
                RecordKeys["ID"] = ID.QueryValue;
            } else if (!loadCurrentRecord) {
                returnUrl = "CrewChecklistForAdminList"; // Return to list
            }

            // Get action
            CurrentAction = "show"; // Display form
            switch (CurrentAction) {
                case "show": // Get a record to display
                        bool res;
                        if (IsApi()) {
                            string filter = GetRecordFilter();
                            CurrentFilter = filter;
                            string sql = CurrentSql;
                            var conn = await GetConnectionAsync();
                            Recordset = await conn.GetDataReaderAsync(sql);
                            res = !Empty(Recordset) && await Recordset.ReadAsync();
                        } else {
                            res = await LoadRow();
                        }
                        if (!res) { // Load record based on key
                            if (Empty(SuccessMessage) && Empty(FailureMessage))
                                FailureMessage = Language.Phrase("NoRecord"); // Set no record message
                            if (IsApi()) {
                                if (!Empty(SuccessMessage))
                                    return new JsonBoolResult(new { success = true, message = SuccessMessage, version = Config.ProductVersion }, true);
                                else
                                    return new JsonBoolResult(new { success = false, error = FailureMessage, version = Config.ProductVersion }, false);
                            } else {
                                return Terminate("CrewChecklistForAdminList"); // Return to list page
                            }
                        }
                    break;
            }
            if (!Empty(returnUrl))
                return Terminate(returnUrl);

            // Render row
            RowType = RowType.View;
            ResetAttributes();
            await RenderRow();

            // Setup export options
            SetupExportOptions();

            // Set up Breadcrumb
            if (!IsExport())
                SetupBreadcrumb();

            // Set up detail parameters
            SetupDetailParms();

            // Normal return
            if (IsApi()) // Get current record only
                if (!IsExport())
                    return Controller.Json(new { success = true, TableVar = await GetRecordFromRecordset(Recordset), version = Config.ProductVersion });

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();

                // Page Render event
                crewChecklistForAdminView?.PageRender();
            }
            return PageResult();
        }
        #pragma warning restore 168, 219

        // Set up other options
        #pragma warning disable 168, 219

        public void SetupOtherOptions()
        {
            var options = OtherOptions;
            var option = options["action"];
            ListOption item;
            string links = "";

            // Edit
            item = option.Add("edit");
            var editTitle = Language.Phrase("ViewPageEditLink", true);
            if (IsModal) // Modal
                item.Body = "<a class=\"ew-action ew-edit\" title=\"" + editTitle + "\" data-caption=\"" + editTitle + "\" data-ew-action=\"modal\" data-url=\"" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("ViewPageEditLink") + "</a>";
            else
                item.Body = "<a class=\"ew-action ew-edit\" title=\"" + editTitle + "\" data-caption=\"" + editTitle + "\" href=\"" + HtmlEncode(AppPath(EditUrl)) + "\">" + Language.Phrase("ViewPageEditLink") + "</a>";
                item.Visible = EditUrl != "" && Security.CanEdit;
            string body = "";
            option = options["detail"];
            string detailTableLink = "";
            string detailViewTblVar = "";
            string detailCopyTblVar = "";
            string detailEditTblVar = "";
            dynamic? detailPage = null;
            string detailFilter = "";

            // "detail_TRChecklistPerformance"
            item = option.Add("detail_TRChecklistPerformance");
            body = Language.Phrase("ViewPageDetailLink") + Language.TablePhrase("TRChecklistPerformance", "TblCaption");
            body = "<a class=\"btn btn-default btn-sm ew-row-link ew-detail\" data-action=\"list\" href=\"" + HtmlEncode(AppPath("TrChecklistPerformanceList?" + Config.TableShowMaster + "=CrewChecklistForAdmin&" + ForeignKeyUrl("fk_ID", ID.CurrentValue) + "")) + "\">" + body + "</a>";
            links = "";
            detailPage = Resolve("TrChecklistPerformanceGrid");
            if (detailPage?.DetailView && Security.CanView && Security.AllowView(CurrentProjectID + "CrewChecklistForAdmin") ?? false) {
                links += "<li><a class=\"dropdown-item ew-row-link ew-detail-view\" data-action=\"view\" data-caption=\"" + Language.Phrase("MasterDetailViewLink", true) + "\" href=\"" + HtmlEncode(AppPath(GetViewUrl(Config.TableShowDetail + "=TRChecklistPerformance"))) + "\">" + Language.Phrase("MasterDetailViewLink", null) + "</a></li>";
                if (!Empty(detailViewTblVar))
                    detailViewTblVar += ",";
                detailViewTblVar += "TRChecklistPerformance";
            }
            if (detailPage?.DetailEdit && Security.CanEdit && Security.AllowEdit(CurrentProjectID + "CrewChecklistForAdmin") ?? false) {
                links += "<li><a class=\"dropdown-item ew-row-link ew-detail-edit\" data-action=\"edit\" data-caption=\"" + Language.Phrase("MasterDetailEditLink", true) + "\" href=\"" + HtmlEncode(AppPath(GetEditUrl(Config.TableShowDetail + "=TRChecklistPerformance"))) + "\">" + Language.Phrase("MasterDetailEditLink", null) + "</a></li>";
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
            item.Body = body;
            item.Visible = Security.AllowList(CurrentProjectID + "TRChecklistPerformance");
            if (item.Visible) {
                if (!Empty(detailTableLink))
                    detailTableLink += ",";
                detailTableLink += "TRChecklistPerformance";
            }
            if (ShowMultipleDetails)
                item.Visible = false;

            // Multiple details
            if (ShowMultipleDetails) {
                body = "<div class=\"btn-group btn-group-sm ew-btn-group\">";
                links = "";
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
                    body += "<button type=\"button\" class=\"dropdown-toggle btn btn-default btn-sm ew-master-detail\" title=\"" + HtmlEncode(Language.Phrase("MultipleMasterDetails", true)) + "\" data-bs-toggle=\"dropdown\">" + Language.Phrase("MultipleMasterDetails") + "</button>";
                    body += "<ul class=\"dropdown-menu ew-dropdown-menu\">" + links + "</ul>";
                }
                body += "</div>";
                // Multiple details
                item = option.Add("details");
                item.Body = body;
            }

            // Set up detail default
            option = options["detail"];
            options["detail"].DropDownButtonPhrase = "ButtonDetails";
            var ar = detailTableLink.Split(',');
            option.UseDropDownButton = (ar.Length > 1);
            option.UseButtonGroup = true;
            item = option.AddGroupOption();
            item.Body = "";
            item.Visible = false;

            // Set up action default
            option = options["action"];
            option.DropDownButtonPhrase = "ButtonActions";
            option.UseDropDownButton = !IsJsonResponse() && true;
            option.UseButtonGroup = true;
            item = option.AddGroupOption();
            item.Body = "";
            item.Visible = false;
        }
        #pragma warning restore 168, 219

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

        #pragma warning disable 1998
        // Render row values based on field settings
        public async Task RenderRow()
        {
            SetupOtherOptions();

            // Call Row Rendering event
            RowRendering();

            // Common render codes for all row types

            // ID

            // MTCrewID

            // Activity10

            // RemarkActivity10

            // Activity11

            // RemarkActivity11

            // Activity12

            // RemarkActivity12

            // Activity13

            // RemarkActivity13

            // Activity14

            // RemarkActivity14

            // Activity20

            // RemarkActivity20

            // Activity30

            // RemarkActivity30

            // Activity40

            // RemarkActivity40

            // Activity50

            // RemarkActivity50

            // Activity60

            // RemarkActivity60

            // Activity70

            // RemarkActivity70

            // InterviewerComment

            // JobKnowledge

            // SafetyAwareness

            // Personality

            // EnglishProficiency

            // PrincipalComment

            // CreatedByUserID

            // CreatedDateTime

            // LastUpdatedByUserID

            // LastUpdatedDateTime

            // FinalInterviewComment

            // InterviewedByPersonOneName

            // InterviewedByPersonOneRank

            // AssistantManagerPdeReviewedDate

            // InterviewedByPersonTwoName

            // InterviewedByPersonTwoRank

            // InterviewedByPersonThreeName

            // InterviewedByPersonThreeRank

            // CrewingManagerApprovalDate

            // Activity14Attachment

            // Activity20Attachment

            // Activity30Attachment

            // Activity50Attachment

            // Activity70Attachment

            // FinalInterviewAttachment

            // PrincipalCommentAttachment

            // FormPrintoutAttachment

            // AssistantManagerPdeReviewed

            // CrewingManagerApproval

            // InterviewDate

            // InterviewAttachment

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

                // RemarkActivity11
                RemarkActivity11.ViewValue = RemarkActivity11.CurrentValue;
                RemarkActivity11.ViewCustomAttributes = "";

                // Activity12
                if (ConvertToBool(Activity12.CurrentValue)) {
                    Activity12.ViewValue = Activity12.TagCaption(1) != "" ? Activity12.TagCaption(1) : "Yes";
                } else {
                    Activity12.ViewValue = Activity12.TagCaption(2) != "" ? Activity12.TagCaption(2) : "No";
                }
                Activity12.ViewCustomAttributes = "";

                // RemarkActivity12
                RemarkActivity12.ViewValue = RemarkActivity12.CurrentValue;
                RemarkActivity12.ViewCustomAttributes = "";

                // Activity13
                if (ConvertToBool(Activity13.CurrentValue)) {
                    Activity13.ViewValue = Activity13.TagCaption(1) != "" ? Activity13.TagCaption(1) : "Yes";
                } else {
                    Activity13.ViewValue = Activity13.TagCaption(2) != "" ? Activity13.TagCaption(2) : "No";
                }
                Activity13.ViewCustomAttributes = "";

                // RemarkActivity13
                RemarkActivity13.ViewValue = RemarkActivity13.CurrentValue;
                RemarkActivity13.ViewCustomAttributes = "";

                // Activity14
                if (ConvertToBool(Activity14.CurrentValue)) {
                    Activity14.ViewValue = Activity14.TagCaption(1) != "" ? Activity14.TagCaption(1) : "Yes";
                } else {
                    Activity14.ViewValue = Activity14.TagCaption(2) != "" ? Activity14.TagCaption(2) : "No";
                }
                Activity14.ViewCustomAttributes = "";

                // RemarkActivity14
                RemarkActivity14.ViewValue = RemarkActivity14.CurrentValue;
                RemarkActivity14.ViewCustomAttributes = "";

                // Activity20
                if (ConvertToBool(Activity20.CurrentValue)) {
                    Activity20.ViewValue = Activity20.TagCaption(1) != "" ? Activity20.TagCaption(1) : "Yes";
                } else {
                    Activity20.ViewValue = Activity20.TagCaption(2) != "" ? Activity20.TagCaption(2) : "No";
                }
                Activity20.ViewCustomAttributes = "";

                // RemarkActivity20
                RemarkActivity20.ViewValue = RemarkActivity20.CurrentValue;
                RemarkActivity20.ViewCustomAttributes = "";

                // Activity30
                if (ConvertToBool(Activity30.CurrentValue)) {
                    Activity30.ViewValue = Activity30.TagCaption(1) != "" ? Activity30.TagCaption(1) : "Yes";
                } else {
                    Activity30.ViewValue = Activity30.TagCaption(2) != "" ? Activity30.TagCaption(2) : "No";
                }
                Activity30.ViewCustomAttributes = "";

                // RemarkActivity30
                RemarkActivity30.ViewValue = RemarkActivity30.CurrentValue;
                RemarkActivity30.ViewCustomAttributes = "";

                // Activity40
                if (ConvertToBool(Activity40.CurrentValue)) {
                    Activity40.ViewValue = Activity40.TagCaption(1) != "" ? Activity40.TagCaption(1) : "Yes";
                } else {
                    Activity40.ViewValue = Activity40.TagCaption(2) != "" ? Activity40.TagCaption(2) : "No";
                }
                Activity40.ViewCustomAttributes = "";

                // RemarkActivity40
                RemarkActivity40.ViewValue = RemarkActivity40.CurrentValue;
                RemarkActivity40.ViewCustomAttributes = "";

                // Activity50
                if (ConvertToBool(Activity50.CurrentValue)) {
                    Activity50.ViewValue = Activity50.TagCaption(1) != "" ? Activity50.TagCaption(1) : "Yes";
                } else {
                    Activity50.ViewValue = Activity50.TagCaption(2) != "" ? Activity50.TagCaption(2) : "No";
                }
                Activity50.ViewCustomAttributes = "";

                // RemarkActivity50
                RemarkActivity50.ViewValue = RemarkActivity50.CurrentValue;
                RemarkActivity50.ViewCustomAttributes = "";

                // Activity60
                if (ConvertToBool(Activity60.CurrentValue)) {
                    Activity60.ViewValue = Activity60.TagCaption(1) != "" ? Activity60.TagCaption(1) : "Yes";
                } else {
                    Activity60.ViewValue = Activity60.TagCaption(2) != "" ? Activity60.TagCaption(2) : "No";
                }
                Activity60.ViewCustomAttributes = "";

                // RemarkActivity60
                RemarkActivity60.ViewValue = RemarkActivity60.CurrentValue;
                RemarkActivity60.ViewCustomAttributes = "";

                // Activity70
                if (ConvertToBool(Activity70.CurrentValue)) {
                    Activity70.ViewValue = Activity70.TagCaption(1) != "" ? Activity70.TagCaption(1) : "Yes";
                } else {
                    Activity70.ViewValue = Activity70.TagCaption(2) != "" ? Activity70.TagCaption(2) : "No";
                }
                Activity70.ViewCustomAttributes = "";

                // RemarkActivity70
                RemarkActivity70.ViewValue = RemarkActivity70.CurrentValue;
                RemarkActivity70.ViewCustomAttributes = "";

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

                // MTCrewID
                MTCrewID.HrefValue = "";
                MTCrewID.TooltipValue = "";

                // Activity10
                Activity10.HrefValue = "";
                Activity10.TooltipValue = "";

                // RemarkActivity10
                RemarkActivity10.HrefValue = "";
                RemarkActivity10.TooltipValue = "";

                // Activity11
                Activity11.HrefValue = "";
                Activity11.TooltipValue = "";

                // RemarkActivity11
                RemarkActivity11.HrefValue = "";
                RemarkActivity11.TooltipValue = "";

                // Activity12
                Activity12.HrefValue = "";
                Activity12.TooltipValue = "";

                // RemarkActivity12
                RemarkActivity12.HrefValue = "";
                RemarkActivity12.TooltipValue = "";

                // Activity13
                Activity13.HrefValue = "";
                Activity13.TooltipValue = "";

                // RemarkActivity13
                RemarkActivity13.HrefValue = "";
                RemarkActivity13.TooltipValue = "";

                // Activity14
                Activity14.HrefValue = "";
                Activity14.TooltipValue = "";

                // RemarkActivity14
                RemarkActivity14.HrefValue = "";
                RemarkActivity14.TooltipValue = "";

                // Activity20
                Activity20.HrefValue = "";
                Activity20.TooltipValue = "";

                // RemarkActivity20
                RemarkActivity20.HrefValue = "";
                RemarkActivity20.TooltipValue = "";

                // Activity30
                Activity30.HrefValue = "";
                Activity30.TooltipValue = "";

                // RemarkActivity30
                RemarkActivity30.HrefValue = "";
                RemarkActivity30.TooltipValue = "";

                // Activity40
                Activity40.HrefValue = "";
                Activity40.TooltipValue = "";

                // RemarkActivity40
                RemarkActivity40.HrefValue = "";
                RemarkActivity40.TooltipValue = "";

                // Activity50
                Activity50.HrefValue = "";
                Activity50.TooltipValue = "";

                // RemarkActivity50
                RemarkActivity50.HrefValue = "";
                RemarkActivity50.TooltipValue = "";

                // Activity60
                Activity60.HrefValue = "";
                Activity60.TooltipValue = "";

                // RemarkActivity60
                RemarkActivity60.HrefValue = "";
                RemarkActivity60.TooltipValue = "";

                // Activity70
                Activity70.HrefValue = "";
                Activity70.TooltipValue = "";

                // RemarkActivity70
                RemarkActivity70.HrefValue = "";
                RemarkActivity70.TooltipValue = "";

                // InterviewerComment
                InterviewerComment.HrefValue = "";
                InterviewerComment.TooltipValue = "";

                // JobKnowledge
                JobKnowledge.HrefValue = "";
                JobKnowledge.TooltipValue = "";

                // SafetyAwareness
                SafetyAwareness.HrefValue = "";
                SafetyAwareness.TooltipValue = "";

                // Personality
                Personality.HrefValue = "";
                Personality.TooltipValue = "";

                // EnglishProficiency
                EnglishProficiency.HrefValue = "";
                EnglishProficiency.TooltipValue = "";

                // PrincipalComment
                PrincipalComment.HrefValue = "";
                PrincipalComment.TooltipValue = "";

                // FinalInterviewComment
                FinalInterviewComment.HrefValue = "";
                FinalInterviewComment.TooltipValue = "";

                // InterviewedByPersonOneName
                InterviewedByPersonOneName.HrefValue = "";
                InterviewedByPersonOneName.TooltipValue = "";

                // InterviewedByPersonOneRank
                InterviewedByPersonOneRank.HrefValue = "";
                InterviewedByPersonOneRank.TooltipValue = "";

                // AssistantManagerPdeReviewedDate
                AssistantManagerPdeReviewedDate.HrefValue = "";
                AssistantManagerPdeReviewedDate.TooltipValue = "";

                // InterviewedByPersonTwoName
                InterviewedByPersonTwoName.HrefValue = "";
                InterviewedByPersonTwoName.TooltipValue = "";

                // InterviewedByPersonTwoRank
                InterviewedByPersonTwoRank.HrefValue = "";
                InterviewedByPersonTwoRank.TooltipValue = "";

                // InterviewedByPersonThreeName
                InterviewedByPersonThreeName.HrefValue = "";
                InterviewedByPersonThreeName.TooltipValue = "";

                // InterviewedByPersonThreeRank
                InterviewedByPersonThreeRank.HrefValue = "";
                InterviewedByPersonThreeRank.TooltipValue = "";

                // CrewingManagerApprovalDate
                CrewingManagerApprovalDate.HrefValue = "";
                CrewingManagerApprovalDate.TooltipValue = "";

                // Activity14Attachment
                if (!IsNull(Activity14Attachment.Upload.DbValue)) {
                    Activity14Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity14Attachment, Activity14Attachment.HtmlDecode(ConvertToString(Activity14Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity14Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity14Attachment.HrefValue = FullUrl(ConvertToString(Activity14Attachment.HrefValue), "href");
                } else {
                    Activity14Attachment.HrefValue = "";
                }
                Activity14Attachment.ExportHrefValue = Activity14Attachment.UploadPath + Activity14Attachment.Upload.DbValue;
                Activity14Attachment.TooltipValue = "";

                // Activity20Attachment
                if (!IsNull(Activity20Attachment.Upload.DbValue)) {
                    Activity20Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity20Attachment, Activity20Attachment.HtmlDecode(ConvertToString(Activity20Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity20Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity20Attachment.HrefValue = FullUrl(ConvertToString(Activity20Attachment.HrefValue), "href");
                } else {
                    Activity20Attachment.HrefValue = "";
                }
                Activity20Attachment.ExportHrefValue = Activity20Attachment.UploadPath + Activity20Attachment.Upload.DbValue;
                Activity20Attachment.TooltipValue = "";

                // Activity30Attachment
                if (!IsNull(Activity30Attachment.Upload.DbValue)) {
                    Activity30Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity30Attachment, Activity30Attachment.HtmlDecode(ConvertToString(Activity30Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity30Attachment.LinkAttrs["target"] = ""; // Add target
                    if (IsExport())
                        Activity30Attachment.HrefValue = FullUrl(ConvertToString(Activity30Attachment.HrefValue), "href");
                } else {
                    Activity30Attachment.HrefValue = "";
                }
                Activity30Attachment.ExportHrefValue = Activity30Attachment.UploadPath + Activity30Attachment.Upload.DbValue;
                Activity30Attachment.TooltipValue = "";

                // Activity50Attachment
                if (!IsNull(Activity50Attachment.Upload.DbValue)) {
                    Activity50Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity50Attachment, Activity50Attachment.HtmlDecode(ConvertToString(Activity50Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity50Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity50Attachment.HrefValue = FullUrl(ConvertToString(Activity50Attachment.HrefValue), "href");
                } else {
                    Activity50Attachment.HrefValue = "";
                }
                Activity50Attachment.ExportHrefValue = Activity50Attachment.UploadPath + Activity50Attachment.Upload.DbValue;
                Activity50Attachment.TooltipValue = "";

                // Activity70Attachment
                if (!IsNull(Activity70Attachment.Upload.DbValue)) {
                    Activity70Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity70Attachment, Activity70Attachment.HtmlDecode(ConvertToString(Activity70Attachment.Upload.DbValue)))); // Add prefix/suffix
                    Activity70Attachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        Activity70Attachment.HrefValue = FullUrl(ConvertToString(Activity70Attachment.HrefValue), "href");
                } else {
                    Activity70Attachment.HrefValue = "";
                }
                Activity70Attachment.ExportHrefValue = Activity70Attachment.UploadPath + Activity70Attachment.Upload.DbValue;
                Activity70Attachment.TooltipValue = "";

                // FinalInterviewAttachment
                if (!IsNull(FinalInterviewAttachment.Upload.DbValue)) {
                    FinalInterviewAttachment.HrefValue = ConvertToString(GetFileUploadUrl(FinalInterviewAttachment, FinalInterviewAttachment.HtmlDecode(ConvertToString(FinalInterviewAttachment.Upload.DbValue)))); // Add prefix/suffix
                    FinalInterviewAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        FinalInterviewAttachment.HrefValue = FullUrl(ConvertToString(FinalInterviewAttachment.HrefValue), "href");
                } else {
                    FinalInterviewAttachment.HrefValue = "";
                }
                FinalInterviewAttachment.ExportHrefValue = FinalInterviewAttachment.UploadPath + FinalInterviewAttachment.Upload.DbValue;
                FinalInterviewAttachment.TooltipValue = "";

                // PrincipalCommentAttachment
                if (!IsNull(PrincipalCommentAttachment.Upload.DbValue)) {
                    PrincipalCommentAttachment.HrefValue = ConvertToString(GetFileUploadUrl(PrincipalCommentAttachment, PrincipalCommentAttachment.HtmlDecode(ConvertToString(PrincipalCommentAttachment.Upload.DbValue)))); // Add prefix/suffix
                    PrincipalCommentAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        PrincipalCommentAttachment.HrefValue = FullUrl(ConvertToString(PrincipalCommentAttachment.HrefValue), "href");
                } else {
                    PrincipalCommentAttachment.HrefValue = "";
                }
                PrincipalCommentAttachment.ExportHrefValue = PrincipalCommentAttachment.UploadPath + PrincipalCommentAttachment.Upload.DbValue;
                PrincipalCommentAttachment.TooltipValue = "";

                // FormPrintoutAttachment
                if (!IsNull(FormPrintoutAttachment.Upload.DbValue)) {
                    FormPrintoutAttachment.HrefValue = ConvertToString(GetFileUploadUrl(FormPrintoutAttachment, FormPrintoutAttachment.HtmlDecode(ConvertToString(FormPrintoutAttachment.Upload.DbValue)))); // Add prefix/suffix
                    FormPrintoutAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        FormPrintoutAttachment.HrefValue = FullUrl(ConvertToString(FormPrintoutAttachment.HrefValue), "href");
                } else {
                    FormPrintoutAttachment.HrefValue = "";
                }
                FormPrintoutAttachment.ExportHrefValue = FormPrintoutAttachment.UploadPath + FormPrintoutAttachment.Upload.DbValue;
                FormPrintoutAttachment.TooltipValue = "";

                // AssistantManagerPdeReviewed
                AssistantManagerPdeReviewed.HrefValue = "";
                AssistantManagerPdeReviewed.TooltipValue = "";

                // CrewingManagerApproval
                CrewingManagerApproval.HrefValue = "";
                CrewingManagerApproval.TooltipValue = "";

                // InterviewDate
                InterviewDate.HrefValue = "";
                InterviewDate.TooltipValue = "";

                // InterviewAttachment
                if (!IsNull(InterviewAttachment.Upload.DbValue)) {
                    InterviewAttachment.HrefValue = ConvertToString(GetFileUploadUrl(InterviewAttachment, InterviewAttachment.HtmlDecode(ConvertToString(InterviewAttachment.Upload.DbValue)))); // Add prefix/suffix
                    InterviewAttachment.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        InterviewAttachment.HrefValue = FullUrl(ConvertToString(InterviewAttachment.HrefValue), "href");
                } else {
                    InterviewAttachment.HrefValue = "";
                }
                InterviewAttachment.ExportHrefValue = InterviewAttachment.UploadPath + InterviewAttachment.Upload.DbValue;
                InterviewAttachment.TooltipValue = "";

                // ApprovedByUserID1
                ApprovedByUserID1.HrefValue = "";
                ApprovedByUserID1.TooltipValue = "";

                // ApprovedByUserID2
                ApprovedByUserID2.HrefValue = "";
                ApprovedByUserID2.TooltipValue = "";
            }

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();

            // Save data for Custom Template
            if (RowType == RowType.View || RowType == RowType.Edit || RowType == RowType.Add)
                Rows.Add(CustomTemplateFieldValues());
        }
        #pragma warning restore 1998

        // Get export HTML tag
        protected string GetExportTag(string type, bool custom = false) {
            string exportUrl = AppPath(CurrentPageName()); // DN
            if (type == "print" || custom) { // Printer friendly / custom export
                List<string> keys = GetKey(true).Split(Config.CompositeKeySeparator).ToList();
                foreach (string key in keys)
                    exportUrl += "/" + UrlEncode(key);
                exportUrl += "?export=" + type + (custom ? "&amp;custom=1" : "");
            } else {
                exportUrl = AppPath(Config.ApiUrl + Config.ApiExportAction + "/" + type + "/" + TableVar);
                exportUrl += "?" + Config.ApiKeyName + "=" + GetKey(true);
            }
            if (SameText(type, "excel")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" form=\"fCrewChecklistForAdminview\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"excel\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToExcel") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-excel\" title=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToExcel", true)) + "\">" + Language.Phrase("ExportToExcel") + "</a>";
            } else if (SameText(type, "word")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" form=\"fCrewChecklistForAdminview\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"word\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToWord") + "</button>";
                else
                    return "<a href=\"" + exportUrl + "\" class=\"btn btn-default ew-export-link ew-word\" title=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToWord", true)) + "\">" + Language.Phrase("ExportToWord") + "</a>";
            } else if (SameText(type, "pdf")) {
                if (custom)
                    return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-pdf\" title=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" data-caption=\"" + HtmlEncode(Language.Phrase("ExportToPdf", true)) + "\" form=\"fCrewChecklistForAdminview\" data-url=\"" + exportUrl + "\" data-ew-action=\"export\" data-export=\"pdf\" data-custom=\"true\" data-export-selected=\"false\">" + Language.Phrase("ExportToPDF") + "</button>";
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
                return "<button type=\"button\" class=\"btn btn-default ew-export-link ew-email\" title=\"" + Language.Phrase("ExportToEmail", true) + "\" data-caption=\"" + Language.Phrase("ExportToEmail", true) + "\" form=\"fCrewChecklistForAdminview\" data-ew-action=\"email\" data-hdr=\"" + Language.Phrase("ExportToEmail", true) + "\" data-key='" + HtmlEncode(ConvertToJsonAttribute(RecordKeys)) + "' data-export-selected=\"false\"" + url + ">" + Language.Phrase("ExportToEmail") + "</button>";
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
            item.Body = GetExportTag("excel", !Config.UseExcelExtension);
            item.Visible = true;

            // Export to Word
            item = ExportOptions.Add("word");
            item.Body = GetExportTag("word", !Config.UseWordExtension);
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
            item.Body = GetExportTag("pdf", true);
            item.Visible = false;

            // Export to Email
            item = ExportOptions.Add("email");
            item.Body = GetExportTag("email", true);
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

            // Hide options for export
            if (IsExport())
                ExportOptions.HideAllOptions();

            // Hide options if json response
            if (IsJsonResponse())
                ExportOptions.HideAllOptions();
            if (!Security.CanExport) // Export not allowed
                ExportOptions.HideAllOptions();
        }

        #pragma warning disable 168

        /// <summary>
        /// Export data
        /// </summary>
        public async Task ExportData(dynamic? doc, string[] keys)
        {
            // Load recordset // DN
            DbDataReader? dr = null;
            if (TotalRecords < 0)
                TotalRecords = await ListRecordCountAsync();
            StartRecord = 1;
            if (keys.Length >= 1) {
                ID.OldValue = keys[0];
                var c = await GetConnection2Async(DbId); // Note: Use new connection for view page export // DN
                dr = await LoadReader(GetRecordFilter(), "", c);
            }
            if (doc == null) { // DN
                RemoveHeader("Content-Type"); // Remove header
                RemoveHeader("Content-Disposition");
                FailureMessage = Language.Phrase("ExportClassNotFound"); // Export class not found
                return;
            }

            // Call Page Exporting server event
            doc.ExportCustom = !PageExporting(ref doc);
            string exportStyle;

            // Page header
            string header = PageHeader;
            PageDataRendering(ref header);
            doc.Text.Append(header);

            // Export
            if (dr != null)
                await ExportDocument(doc, dr, StartRecord, StopRecord, "view");

            // Export detail records (TRChecklistPerformance)
            if (Config.ExportDetailRecords && CurrentDetailTables.Contains("TRChecklistPerformance")) {
                trChecklistPerformance = new TrChecklistPerformanceList();
                if (trChecklistPerformance != null) {
                    var c = await GetConnection2Async(trChecklistPerformance.DbId); // Note: Use new connection for detail records // DN
                    using var rsdetail = await trChecklistPerformance.LoadReader(trChecklistPerformance.DetailFilterFromSession, trChecklistPerformance.SessionOrderBy, c); // Load detail records
                    if (rsdetail?.HasRows ?? false) { // DN
                        exportStyle = doc.Style;
                        doc.SetStyle("h"); // Change to horizontal
                        if (Export != "csv" || Config.ExportDetailRecordsForCsv) {
                            doc.ExportEmptyRow();
                            int detailcnt = await trChecklistPerformance.LoadRecordCountAsync(trChecklistPerformance.DetailFilterFromSession); // DN
                            var oldtbl = doc.Table;
                            doc.Table = trChecklistPerformance;
                            await trChecklistPerformance.ExportDocument(doc, rsdetail, 1, detailcnt);
                            doc.Table = oldtbl;
                        }
                        doc.SetStyle(exportStyle); // Restore
                    }
                }
            }

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

        // Set up detail parms based on QueryString
        protected void SetupDetailParms() {
            StringValues detailTblVar = "";
            // Get the keys for master table
            if (Query.TryGetValue(Config.TableShowDetail, out detailTblVar)) { // Do not use Get()
                CurrentDetailTable = detailTblVar.ToString();
            } else {
                detailTblVar = CurrentDetailTable;
            }
            if (!Empty(detailTblVar)) {
                var detailTblVars = detailTblVar.ToString().Split(',');
                if (detailTblVars.Contains("TRChecklistPerformance")) {
                    trChecklistPerformanceGrid = Resolve("TrChecklistPerformanceGrid")!;
                    if (trChecklistPerformanceGrid?.DetailView ?? false) {
                        trChecklistPerformanceGrid.CurrentMode = "view";

                        // Save current master table to detail table
                        trChecklistPerformanceGrid.CurrentMasterTable = TableVar;
                        trChecklistPerformanceGrid.StartRecordNumber = 1;
                        trChecklistPerformanceGrid.TRChecklistID.IsDetailKey = true;
                        trChecklistPerformanceGrid.TRChecklistID.CurrentValue = ID.CurrentValue;
                        trChecklistPerformanceGrid.TRChecklistID.SessionValue = trChecklistPerformanceGrid.TRChecklistID.CurrentValue;
                    }
                }
            }
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("CrewChecklistForAdminList")), "", TableVar, true);
            string pageId = "view";
            breadcrumb.Add("view", pageId, url);
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
            string recordNo = !Empty(pageNo) ? pageNo : startRec; // Record number = page number or start record
            if (!Empty(recordNo) && IsNumeric(recordNo))
                StartRecord = ConvertToInt(recordNo);
            else
                StartRecord = StartRecordNumber;

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
    } // End page class
} // End Partial class
