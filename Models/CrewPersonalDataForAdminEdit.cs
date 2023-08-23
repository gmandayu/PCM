namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewPersonalDataForAdminEdit
    /// </summary>
    public static CrewPersonalDataForAdminEdit crewPersonalDataForAdminEdit
    {
        get => HttpData.Get<CrewPersonalDataForAdminEdit>("crewPersonalDataForAdminEdit")!;
        set => HttpData["crewPersonalDataForAdminEdit"] = value;
    }

    /// <summary>
    /// Page class for CrewPersonalDataForAdmin
    /// </summary>
    public class CrewPersonalDataForAdminEdit : CrewPersonalDataForAdminEditBase
    {
        // Constructor
        public CrewPersonalDataForAdminEdit(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewPersonalDataForAdminEdit() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewPersonalDataForAdminEditBase : CrewPersonalDataForAdmin
    {
        // Page ID
        public string PageID = "edit";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewPersonalDataForAdmin";

        // Page object name
        public string PageObjName = "crewPersonalDataForAdminEdit";

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
        public CrewPersonalDataForAdminEditBase()
        {
            // Custom template // DN
            UseCustomTemplate = true;

            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-edit-table d-none";

            // Language object
            Language = ResolveLanguage();

            // Table object (crewPersonalDataForAdmin)
            if (crewPersonalDataForAdmin == null || crewPersonalDataForAdmin is CrewPersonalDataForAdmin)
                crewPersonalDataForAdmin = this;

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
        public string PageName => "CrewPersonalDataForAdminEdit";

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
            Nationality_CountryID.SetVisibility();
            CountryOfOrigin_CountryID.SetVisibility();
            DateOfBirth.SetVisibility();
            CityOfBirth.SetVisibility();
            Gender.SetVisibility();
            MaritalStatus.SetVisibility();
            ReligionID.SetVisibility();
            BloodType.SetVisibility();
            RankAppliedFor_RankID.SetVisibility();
            WillAcceptLowRank.SetVisibility();
            AvailableFrom.SetVisibility();
            AvailableUntil.SetVisibility();
            PrimaryAddressDetail.SetVisibility();
            PrimaryAddressCity.SetVisibility();
            PrimaryAddressNearestAirport.SetVisibility();
            PrimaryAddressState.SetVisibility();
            PrimaryAddressPostCode.SetVisibility();
            PrimaryAddressCountryID.SetVisibility();
            PrimaryAddressHomeTel.SetVisibility();
            AlternativeAddressDetail.SetVisibility();
            AlternativeAddressState.SetVisibility();
            AlternativeAddressCity.SetVisibility();
            AlternativeAddressHomeTel.SetVisibility();
            AlternativeAddressPostCode.SetVisibility();
            AlternativeAddressCountryID.SetVisibility();
            MobileNumber.SetVisibility();
            _Email.SetVisibility();
            EmployeeStatus.Visible = false;
            FormSubmittedDateTime.Visible = false;
            ActiveDescription.Visible = false;
            CreatedByUserID.Visible = false;
            CreatedDateTime.Visible = false;
            LastUpdatedByUserID.Visible = false;
            LastUpdatedDateTime.Visible = false;
            MTUserID.Visible = false;
            SocialSecurityNumber.SetVisibility();
            SocialSecurityIssuingCountryID.SetVisibility();
            SocialSecurityImage.SetVisibility();
            PersonalTaxNumber.SetVisibility();
            PersonalTaxIssuingCountryID.SetVisibility();
            PersonalTaxImage.SetVisibility();
            Status.SetVisibility();
            Reason.SetVisibility();
            Weight.SetVisibility();
            Height.SetVisibility();
            CoverallSize.SetVisibility();
            SafetyShoesSize.SetVisibility();
            ShirtSize.SetVisibility();
            TrousersSize.SetVisibility();
            NomineeFullName.SetVisibility();
            NomineeRelationship.SetVisibility();
            NomineeGender.SetVisibility();
            NomineeNationality_CountryID.SetVisibility();
            NomineeAddressDetail.SetVisibility();
            NomineeAddressCity.SetVisibility();
            NomineeAddressPostCode.SetVisibility();
            NomineeAddressCountryID.SetVisibility();
            NomineeAddressHomeTel.SetVisibility();
            NomineeEmail.SetVisibility();
            NomineeMobileNumber.SetVisibility();
            NSSF_Health_Number.SetVisibility();
            NSSF_Occupation_Number.SetVisibility();
            NomineeRelationshipSelect.SetVisibility();
            NomineeRelationshipDetail.SetVisibility();
            MobileNumberCode_CountryID.SetVisibility();
            PrimaryAddressHomeTelCode_CountryID.SetVisibility();
            AlternativeAddressHomeTelCode_CountryID.SetVisibility();
            NomineeAddressHomeTelCode_CountryID.SetVisibility();
            NomineeMobileNumberCode_CountryID.SetVisibility();
            MTManningAgentID.SetVisibility();
        }

        // Constructor
        public CrewPersonalDataForAdminEditBase(Controller? controller = null): this() { // DN
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

        public int DisplayRecords = 1; // Number of display records

        public int StartRecord;

        public int StopRecord;

        public int TotalRecords = -1;

        public int RecordRange = 10;

        public int RecordCount;

        public Dictionary<string, string> RecordKeys = new ();

        public string FormClassName = "ew-form ew-edit-form overlay-wrapper";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public DbDataReader? Recordset; // DN

        #pragma warning disable 219
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

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;
            bool loaded = false;
            bool postBack = false;
            StringValues sv;
            object? rv;

            // Set up current action and primary key
            if (IsApi()) {
                loaded = true;

                // Load key from form
                string[] keyValues = {};
                if (RouteValues.TryGetValue("key", out object? k))
                    keyValues = ConvertToString(k).Split('/');
                if (RouteValues.TryGetValue("ID", out rv)) { // DN
                    ID.FormValue = UrlDecode(rv); // DN
                    ID.OldValue = ID.FormValue;
                } else if (CurrentForm.HasValue("x_ID")) {
                    ID.FormValue = CurrentForm.GetValue("x_ID");
                    ID.OldValue = ID.FormValue;
                } else if (!Empty(keyValues)) {
                    ID.OldValue = ConvertToString(keyValues[0]);
                } else {
                    loaded = false; // Unable to load key
                }

                // Load record
                if (loaded)
                    loaded = await LoadRow();
                if (!loaded) {
                    FailureMessage = Language.Phrase("NoRecord"); // Set no record message
                    return Terminate();
                }
                CurrentAction = "update"; // Update record directly
                OldKey = GetKey(true); // Get from CurrentValue
                postBack = true;
            } else {
                if (!Empty(Post("action"))) {
                    CurrentAction = Post("action"); // Get action code
                    if (!IsShow) // Not reload record, handle as postback
                        postBack = true;

                    // Get key from Form
                    if (Post(OldKeyName, out sv))
                        SetKey(sv.ToString(), IsShow);
                } else {
                    CurrentAction = "show"; // Default action is display

                    // Load key from QueryString
                    bool loadByQuery = false;
                    if (RouteValues.TryGetValue("ID", out rv)) { // DN
                        ID.QueryValue = UrlDecode(rv); // DN
                        loadByQuery = true;
                    } else if (Get("ID", out sv)) {
                        ID.QueryValue = sv.ToString();
                        loadByQuery = true;
                    } else {
                        ID.CurrentValue = DbNullValue;
                    }
                }

                // Load recordset
                if (IsShow) {
                    // Load current record
                    loaded = await LoadRow();
                OldKey = loaded ? GetKey(true) : ""; // Get from CurrentValue
            }
        }

        // Process form if post back
        if (postBack) {
            await LoadFormValues(); // Get form values
            if (IsApi() && RouteValues.TryGetValue("key", out object? k)) {
                var keyValues = ConvertToString(k).Split('/');
                ID.FormValue = ConvertToString(keyValues[0]);
            }
        }

        // Validate form if post back
        if (postBack) {
            if (!await ValidateForm()) {
                EventCancelled = true; // Event cancelled
                RestoreFormValues();
                if (IsApi())
                    return Terminate();
                else
                    CurrentAction = ""; // Form error, reset action
            }
        }

        // Perform current action
        switch (CurrentAction) {
                case "show": // Get a record to display
                        if (!loaded) { // Load record based on key
                            if (Empty(FailureMessage))
                                FailureMessage = Language.Phrase("NoRecord"); // No record found
                            return Terminate("CrewPersonalDataForAdminList"); // No matching record, return to list
                        }
                    break;
                case "update": // Update // DN
                    CloseRecordset(); // DN
                    string returnUrl = EditUrl;
                    if (GetPageName(returnUrl) == "CrewPersonalDataForAdminList")
                        returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                    SendEmail = true; // Send email on update success
                    var res = await EditRow();
                    if (res) {
                        // Handle UseAjaxActions with return page
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "CrewPersonalDataForAdminList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "CrewPersonalDataForAdminList"; // Return list page content
                            }
                        }
                        if (Empty(SuccessMessage))
                            SuccessMessage = Language.Phrase("UpdateSuccess"); // Update success
                        if (IsJsonResponse()) {
                            ClearMessages(); // Clear messages for Json response
                            return res;
                        } else {
                            return Terminate(returnUrl); // Return to caller
                        }
                    } else if (IsApi()) { // API request, return
                        return Terminate();
                    } else if (IsModal && UseAjaxActions) { // Return JSON error message
                        return Controller.Json(new { success = false, error = GetFailureMessage() });
                    } else if (FailureMessage == Language.Phrase("NoRecord")) {
                        return Terminate(returnUrl); // Return to caller
                    } else {
                        EventCancelled = true; // Event cancelled
                        RestoreFormValues(); // Restore form values if update failed
                    }
                    break;
            }

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Render the record
            RowType = RowType.Edit; // Render as Edit
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
                crewPersonalDataForAdminEdit?.PageRender();
            }
            return PageResult();
        }
        #pragma warning restore 219

        // Confirm page
        public bool ConfirmPage = false; // DN

        #pragma warning disable 1998
        // Get upload files
        public async Task GetUploadFiles()
        {
            // Get upload data
            RequiredPhoto.Upload.Index = CurrentForm.Index;
            if (!await RequiredPhoto.Upload.UploadFile()) // DN
                End(RequiredPhoto.Upload.Message);
            RequiredPhoto.CurrentValue = RequiredPhoto.Upload.FileName;
            VisaPhoto.Upload.Index = CurrentForm.Index;
            if (!await VisaPhoto.Upload.UploadFile()) // DN
                End(VisaPhoto.Upload.Message);
            VisaPhoto.CurrentValue = VisaPhoto.Upload.FileName;
            SocialSecurityImage.Upload.Index = CurrentForm.Index;
            if (!await SocialSecurityImage.Upload.UploadFile()) // DN
                End(SocialSecurityImage.Upload.Message);
            SocialSecurityImage.CurrentValue = SocialSecurityImage.Upload.FileName;
            PersonalTaxImage.Upload.Index = CurrentForm.Index;
            if (!await PersonalTaxImage.Upload.UploadFile()) // DN
                End(PersonalTaxImage.Upload.Message);
            PersonalTaxImage.CurrentValue = PersonalTaxImage.Upload.FileName;
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Load form values
        protected async Task LoadFormValues() {
            if (CurrentForm == null)
                return;
            bool validate = !Config.ServerValidate;
            string val;

            // Check field name 'IndividualCodeNumber' before field var 'x_IndividualCodeNumber'
            val = CurrentForm.HasValue("IndividualCodeNumber") ? CurrentForm.GetValue("IndividualCodeNumber") : CurrentForm.GetValue("x_IndividualCodeNumber");
            if (!IndividualCodeNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("IndividualCodeNumber") && !CurrentForm.HasValue("x_IndividualCodeNumber")) // DN
                    IndividualCodeNumber.Visible = false; // Disable update for API request
                else
                    IndividualCodeNumber.SetFormValue(val);
            }

            // Check field name 'FullName' before field var 'x_FullName'
            val = CurrentForm.HasValue("FullName") ? CurrentForm.GetValue("FullName") : CurrentForm.GetValue("x_FullName");
            if (!FullName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FullName") && !CurrentForm.HasValue("x_FullName")) // DN
                    FullName.Visible = false; // Disable update for API request
                else
                    FullName.SetFormValue(val);
            }

            // Check field name 'Nationality_CountryID' before field var 'x_Nationality_CountryID'
            val = CurrentForm.HasValue("Nationality_CountryID") ? CurrentForm.GetValue("Nationality_CountryID") : CurrentForm.GetValue("x_Nationality_CountryID");
            if (!Nationality_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Nationality_CountryID") && !CurrentForm.HasValue("x_Nationality_CountryID")) // DN
                    Nationality_CountryID.Visible = false; // Disable update for API request
                else
                    Nationality_CountryID.SetFormValue(val);
            }

            // Check field name 'CountryOfOrigin_CountryID' before field var 'x_CountryOfOrigin_CountryID'
            val = CurrentForm.HasValue("CountryOfOrigin_CountryID") ? CurrentForm.GetValue("CountryOfOrigin_CountryID") : CurrentForm.GetValue("x_CountryOfOrigin_CountryID");
            if (!CountryOfOrigin_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CountryOfOrigin_CountryID") && !CurrentForm.HasValue("x_CountryOfOrigin_CountryID")) // DN
                    CountryOfOrigin_CountryID.Visible = false; // Disable update for API request
                else
                    CountryOfOrigin_CountryID.SetFormValue(val);
            }

            // Check field name 'DateOfBirth' before field var 'x_DateOfBirth'
            val = CurrentForm.HasValue("DateOfBirth") ? CurrentForm.GetValue("DateOfBirth") : CurrentForm.GetValue("x_DateOfBirth");
            if (!DateOfBirth.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("DateOfBirth") && !CurrentForm.HasValue("x_DateOfBirth")) // DN
                    DateOfBirth.Visible = false; // Disable update for API request
                else
                    DateOfBirth.SetFormValue(val, true, validate);
                DateOfBirth.CurrentValue = UnformatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern);
            }

            // Check field name 'CityOfBirth' before field var 'x_CityOfBirth'
            val = CurrentForm.HasValue("CityOfBirth") ? CurrentForm.GetValue("CityOfBirth") : CurrentForm.GetValue("x_CityOfBirth");
            if (!CityOfBirth.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CityOfBirth") && !CurrentForm.HasValue("x_CityOfBirth")) // DN
                    CityOfBirth.Visible = false; // Disable update for API request
                else
                    CityOfBirth.SetFormValue(val);
            }

            // Check field name 'Gender' before field var 'x_Gender'
            val = CurrentForm.HasValue("Gender") ? CurrentForm.GetValue("Gender") : CurrentForm.GetValue("x_Gender");
            if (!Gender.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Gender") && !CurrentForm.HasValue("x_Gender")) // DN
                    Gender.Visible = false; // Disable update for API request
                else
                    Gender.SetFormValue(val);
            }

            // Check field name 'MaritalStatus' before field var 'x_MaritalStatus'
            val = CurrentForm.HasValue("MaritalStatus") ? CurrentForm.GetValue("MaritalStatus") : CurrentForm.GetValue("x_MaritalStatus");
            if (!MaritalStatus.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MaritalStatus") && !CurrentForm.HasValue("x_MaritalStatus")) // DN
                    MaritalStatus.Visible = false; // Disable update for API request
                else
                    MaritalStatus.SetFormValue(val);
            }

            // Check field name 'ReligionID' before field var 'x_ReligionID'
            val = CurrentForm.HasValue("ReligionID") ? CurrentForm.GetValue("ReligionID") : CurrentForm.GetValue("x_ReligionID");
            if (!ReligionID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ReligionID") && !CurrentForm.HasValue("x_ReligionID")) // DN
                    ReligionID.Visible = false; // Disable update for API request
                else
                    ReligionID.SetFormValue(val);
            }

            // Check field name 'BloodType' before field var 'x_BloodType'
            val = CurrentForm.HasValue("BloodType") ? CurrentForm.GetValue("BloodType") : CurrentForm.GetValue("x_BloodType");
            if (!BloodType.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BloodType") && !CurrentForm.HasValue("x_BloodType")) // DN
                    BloodType.Visible = false; // Disable update for API request
                else
                    BloodType.SetFormValue(val);
            }

            // Check field name 'RankAppliedFor_RankID' before field var 'x_RankAppliedFor_RankID'
            val = CurrentForm.HasValue("RankAppliedFor_RankID") ? CurrentForm.GetValue("RankAppliedFor_RankID") : CurrentForm.GetValue("x_RankAppliedFor_RankID");
            if (!RankAppliedFor_RankID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RankAppliedFor_RankID") && !CurrentForm.HasValue("x_RankAppliedFor_RankID")) // DN
                    RankAppliedFor_RankID.Visible = false; // Disable update for API request
                else
                    RankAppliedFor_RankID.SetFormValue(val);
            }

            // Check field name 'WillAcceptLowRank' before field var 'x_WillAcceptLowRank'
            val = CurrentForm.HasValue("WillAcceptLowRank") ? CurrentForm.GetValue("WillAcceptLowRank") : CurrentForm.GetValue("x_WillAcceptLowRank");
            if (!WillAcceptLowRank.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("WillAcceptLowRank") && !CurrentForm.HasValue("x_WillAcceptLowRank")) // DN
                    WillAcceptLowRank.Visible = false; // Disable update for API request
                else
                    WillAcceptLowRank.SetFormValue(val);
            }

            // Check field name 'AvailableFrom' before field var 'x_AvailableFrom'
            val = CurrentForm.HasValue("AvailableFrom") ? CurrentForm.GetValue("AvailableFrom") : CurrentForm.GetValue("x_AvailableFrom");
            if (!AvailableFrom.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AvailableFrom") && !CurrentForm.HasValue("x_AvailableFrom")) // DN
                    AvailableFrom.Visible = false; // Disable update for API request
                else
                    AvailableFrom.SetFormValue(val, true, validate);
                AvailableFrom.CurrentValue = UnformatDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern);
            }

            // Check field name 'AvailableUntil' before field var 'x_AvailableUntil'
            val = CurrentForm.HasValue("AvailableUntil") ? CurrentForm.GetValue("AvailableUntil") : CurrentForm.GetValue("x_AvailableUntil");
            if (!AvailableUntil.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AvailableUntil") && !CurrentForm.HasValue("x_AvailableUntil")) // DN
                    AvailableUntil.Visible = false; // Disable update for API request
                else
                    AvailableUntil.SetFormValue(val, true, validate);
                AvailableUntil.CurrentValue = UnformatDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern);
            }

            // Check field name 'PrimaryAddressDetail' before field var 'x_PrimaryAddressDetail'
            val = CurrentForm.HasValue("PrimaryAddressDetail") ? CurrentForm.GetValue("PrimaryAddressDetail") : CurrentForm.GetValue("x_PrimaryAddressDetail");
            if (!PrimaryAddressDetail.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressDetail") && !CurrentForm.HasValue("x_PrimaryAddressDetail")) // DN
                    PrimaryAddressDetail.Visible = false; // Disable update for API request
                else
                    PrimaryAddressDetail.SetFormValue(val);
            }

            // Check field name 'PrimaryAddressCity' before field var 'x_PrimaryAddressCity'
            val = CurrentForm.HasValue("PrimaryAddressCity") ? CurrentForm.GetValue("PrimaryAddressCity") : CurrentForm.GetValue("x_PrimaryAddressCity");
            if (!PrimaryAddressCity.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressCity") && !CurrentForm.HasValue("x_PrimaryAddressCity")) // DN
                    PrimaryAddressCity.Visible = false; // Disable update for API request
                else
                    PrimaryAddressCity.SetFormValue(val);
            }

            // Check field name 'PrimaryAddressNearestAirport' before field var 'x_PrimaryAddressNearestAirport'
            val = CurrentForm.HasValue("PrimaryAddressNearestAirport") ? CurrentForm.GetValue("PrimaryAddressNearestAirport") : CurrentForm.GetValue("x_PrimaryAddressNearestAirport");
            if (!PrimaryAddressNearestAirport.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressNearestAirport") && !CurrentForm.HasValue("x_PrimaryAddressNearestAirport")) // DN
                    PrimaryAddressNearestAirport.Visible = false; // Disable update for API request
                else
                    PrimaryAddressNearestAirport.SetFormValue(val);
            }

            // Check field name 'PrimaryAddressState' before field var 'x_PrimaryAddressState'
            val = CurrentForm.HasValue("PrimaryAddressState") ? CurrentForm.GetValue("PrimaryAddressState") : CurrentForm.GetValue("x_PrimaryAddressState");
            if (!PrimaryAddressState.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressState") && !CurrentForm.HasValue("x_PrimaryAddressState")) // DN
                    PrimaryAddressState.Visible = false; // Disable update for API request
                else
                    PrimaryAddressState.SetFormValue(val);
            }

            // Check field name 'PrimaryAddressPostCode' before field var 'x_PrimaryAddressPostCode'
            val = CurrentForm.HasValue("PrimaryAddressPostCode") ? CurrentForm.GetValue("PrimaryAddressPostCode") : CurrentForm.GetValue("x_PrimaryAddressPostCode");
            if (!PrimaryAddressPostCode.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressPostCode") && !CurrentForm.HasValue("x_PrimaryAddressPostCode")) // DN
                    PrimaryAddressPostCode.Visible = false; // Disable update for API request
                else
                    PrimaryAddressPostCode.SetFormValue(val);
            }

            // Check field name 'PrimaryAddressCountryID' before field var 'x_PrimaryAddressCountryID'
            val = CurrentForm.HasValue("PrimaryAddressCountryID") ? CurrentForm.GetValue("PrimaryAddressCountryID") : CurrentForm.GetValue("x_PrimaryAddressCountryID");
            if (!PrimaryAddressCountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressCountryID") && !CurrentForm.HasValue("x_PrimaryAddressCountryID")) // DN
                    PrimaryAddressCountryID.Visible = false; // Disable update for API request
                else
                    PrimaryAddressCountryID.SetFormValue(val);
            }

            // Check field name 'PrimaryAddressHomeTel' before field var 'x_PrimaryAddressHomeTel'
            val = CurrentForm.HasValue("PrimaryAddressHomeTel") ? CurrentForm.GetValue("PrimaryAddressHomeTel") : CurrentForm.GetValue("x_PrimaryAddressHomeTel");
            if (!PrimaryAddressHomeTel.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressHomeTel") && !CurrentForm.HasValue("x_PrimaryAddressHomeTel")) // DN
                    PrimaryAddressHomeTel.Visible = false; // Disable update for API request
                else
                    PrimaryAddressHomeTel.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressDetail' before field var 'x_AlternativeAddressDetail'
            val = CurrentForm.HasValue("AlternativeAddressDetail") ? CurrentForm.GetValue("AlternativeAddressDetail") : CurrentForm.GetValue("x_AlternativeAddressDetail");
            if (!AlternativeAddressDetail.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressDetail") && !CurrentForm.HasValue("x_AlternativeAddressDetail")) // DN
                    AlternativeAddressDetail.Visible = false; // Disable update for API request
                else
                    AlternativeAddressDetail.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressState' before field var 'x_AlternativeAddressState'
            val = CurrentForm.HasValue("AlternativeAddressState") ? CurrentForm.GetValue("AlternativeAddressState") : CurrentForm.GetValue("x_AlternativeAddressState");
            if (!AlternativeAddressState.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressState") && !CurrentForm.HasValue("x_AlternativeAddressState")) // DN
                    AlternativeAddressState.Visible = false; // Disable update for API request
                else
                    AlternativeAddressState.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressCity' before field var 'x_AlternativeAddressCity'
            val = CurrentForm.HasValue("AlternativeAddressCity") ? CurrentForm.GetValue("AlternativeAddressCity") : CurrentForm.GetValue("x_AlternativeAddressCity");
            if (!AlternativeAddressCity.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressCity") && !CurrentForm.HasValue("x_AlternativeAddressCity")) // DN
                    AlternativeAddressCity.Visible = false; // Disable update for API request
                else
                    AlternativeAddressCity.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressHomeTel' before field var 'x_AlternativeAddressHomeTel'
            val = CurrentForm.HasValue("AlternativeAddressHomeTel") ? CurrentForm.GetValue("AlternativeAddressHomeTel") : CurrentForm.GetValue("x_AlternativeAddressHomeTel");
            if (!AlternativeAddressHomeTel.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressHomeTel") && !CurrentForm.HasValue("x_AlternativeAddressHomeTel")) // DN
                    AlternativeAddressHomeTel.Visible = false; // Disable update for API request
                else
                    AlternativeAddressHomeTel.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressPostCode' before field var 'x_AlternativeAddressPostCode'
            val = CurrentForm.HasValue("AlternativeAddressPostCode") ? CurrentForm.GetValue("AlternativeAddressPostCode") : CurrentForm.GetValue("x_AlternativeAddressPostCode");
            if (!AlternativeAddressPostCode.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressPostCode") && !CurrentForm.HasValue("x_AlternativeAddressPostCode")) // DN
                    AlternativeAddressPostCode.Visible = false; // Disable update for API request
                else
                    AlternativeAddressPostCode.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressCountryID' before field var 'x_AlternativeAddressCountryID'
            val = CurrentForm.HasValue("AlternativeAddressCountryID") ? CurrentForm.GetValue("AlternativeAddressCountryID") : CurrentForm.GetValue("x_AlternativeAddressCountryID");
            if (!AlternativeAddressCountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressCountryID") && !CurrentForm.HasValue("x_AlternativeAddressCountryID")) // DN
                    AlternativeAddressCountryID.Visible = false; // Disable update for API request
                else
                    AlternativeAddressCountryID.SetFormValue(val);
            }

            // Check field name 'MobileNumber' before field var 'x_MobileNumber'
            val = CurrentForm.HasValue("MobileNumber") ? CurrentForm.GetValue("MobileNumber") : CurrentForm.GetValue("x_MobileNumber");
            if (!MobileNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MobileNumber") && !CurrentForm.HasValue("x_MobileNumber")) // DN
                    MobileNumber.Visible = false; // Disable update for API request
                else
                    MobileNumber.SetFormValue(val);
            }

            // Check field name 'Email' before field var 'x__Email'
            val = CurrentForm.HasValue("Email") ? CurrentForm.GetValue("Email") : CurrentForm.GetValue("x__Email");
            if (!_Email.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Email") && !CurrentForm.HasValue("x__Email")) // DN
                    _Email.Visible = false; // Disable update for API request
                else
                    _Email.SetFormValue(val, true, validate);
            }

            // Check field name 'SocialSecurityNumber' before field var 'x_SocialSecurityNumber'
            val = CurrentForm.HasValue("SocialSecurityNumber") ? CurrentForm.GetValue("SocialSecurityNumber") : CurrentForm.GetValue("x_SocialSecurityNumber");
            if (!SocialSecurityNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SocialSecurityNumber") && !CurrentForm.HasValue("x_SocialSecurityNumber")) // DN
                    SocialSecurityNumber.Visible = false; // Disable update for API request
                else
                    SocialSecurityNumber.SetFormValue(val);
            }

            // Check field name 'SocialSecurityIssuingCountryID' before field var 'x_SocialSecurityIssuingCountryID'
            val = CurrentForm.HasValue("SocialSecurityIssuingCountryID") ? CurrentForm.GetValue("SocialSecurityIssuingCountryID") : CurrentForm.GetValue("x_SocialSecurityIssuingCountryID");
            if (!SocialSecurityIssuingCountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SocialSecurityIssuingCountryID") && !CurrentForm.HasValue("x_SocialSecurityIssuingCountryID")) // DN
                    SocialSecurityIssuingCountryID.Visible = false; // Disable update for API request
                else
                    SocialSecurityIssuingCountryID.SetFormValue(val);
            }

            // Check field name 'PersonalTaxNumber' before field var 'x_PersonalTaxNumber'
            val = CurrentForm.HasValue("PersonalTaxNumber") ? CurrentForm.GetValue("PersonalTaxNumber") : CurrentForm.GetValue("x_PersonalTaxNumber");
            if (!PersonalTaxNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PersonalTaxNumber") && !CurrentForm.HasValue("x_PersonalTaxNumber")) // DN
                    PersonalTaxNumber.Visible = false; // Disable update for API request
                else
                    PersonalTaxNumber.SetFormValue(val);
            }

            // Check field name 'PersonalTaxIssuingCountryID' before field var 'x_PersonalTaxIssuingCountryID'
            val = CurrentForm.HasValue("PersonalTaxIssuingCountryID") ? CurrentForm.GetValue("PersonalTaxIssuingCountryID") : CurrentForm.GetValue("x_PersonalTaxIssuingCountryID");
            if (!PersonalTaxIssuingCountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PersonalTaxIssuingCountryID") && !CurrentForm.HasValue("x_PersonalTaxIssuingCountryID")) // DN
                    PersonalTaxIssuingCountryID.Visible = false; // Disable update for API request
                else
                    PersonalTaxIssuingCountryID.SetFormValue(val);
            }

            // Check field name 'Status' before field var 'x_Status'
            val = CurrentForm.HasValue("Status") ? CurrentForm.GetValue("Status") : CurrentForm.GetValue("x_Status");
            if (!Status.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Status") && !CurrentForm.HasValue("x_Status")) // DN
                    Status.Visible = false; // Disable update for API request
                else
                    Status.SetFormValue(val);
            }

            // Check field name 'Reason' before field var 'x_Reason'
            val = CurrentForm.HasValue("Reason") ? CurrentForm.GetValue("Reason") : CurrentForm.GetValue("x_Reason");
            if (!Reason.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reason") && !CurrentForm.HasValue("x_Reason")) // DN
                    Reason.Visible = false; // Disable update for API request
                else
                    Reason.SetFormValue(val);
            }

            // Check field name 'Weight' before field var 'x_Weight'
            val = CurrentForm.HasValue("Weight") ? CurrentForm.GetValue("Weight") : CurrentForm.GetValue("x_Weight");
            if (!Weight.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Weight") && !CurrentForm.HasValue("x_Weight")) // DN
                    Weight.Visible = false; // Disable update for API request
                else
                    Weight.SetFormValue(val);
            }

            // Check field name 'Height' before field var 'x_Height'
            val = CurrentForm.HasValue("Height") ? CurrentForm.GetValue("Height") : CurrentForm.GetValue("x_Height");
            if (!Height.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Height") && !CurrentForm.HasValue("x_Height")) // DN
                    Height.Visible = false; // Disable update for API request
                else
                    Height.SetFormValue(val);
            }

            // Check field name 'CoverallSize' before field var 'x_CoverallSize'
            val = CurrentForm.HasValue("CoverallSize") ? CurrentForm.GetValue("CoverallSize") : CurrentForm.GetValue("x_CoverallSize");
            if (!CoverallSize.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CoverallSize") && !CurrentForm.HasValue("x_CoverallSize")) // DN
                    CoverallSize.Visible = false; // Disable update for API request
                else
                    CoverallSize.SetFormValue(val);
            }

            // Check field name 'SafetyShoesSize' before field var 'x_SafetyShoesSize'
            val = CurrentForm.HasValue("SafetyShoesSize") ? CurrentForm.GetValue("SafetyShoesSize") : CurrentForm.GetValue("x_SafetyShoesSize");
            if (!SafetyShoesSize.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SafetyShoesSize") && !CurrentForm.HasValue("x_SafetyShoesSize")) // DN
                    SafetyShoesSize.Visible = false; // Disable update for API request
                else
                    SafetyShoesSize.SetFormValue(val);
            }

            // Check field name 'ShirtSize' before field var 'x_ShirtSize'
            val = CurrentForm.HasValue("ShirtSize") ? CurrentForm.GetValue("ShirtSize") : CurrentForm.GetValue("x_ShirtSize");
            if (!ShirtSize.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ShirtSize") && !CurrentForm.HasValue("x_ShirtSize")) // DN
                    ShirtSize.Visible = false; // Disable update for API request
                else
                    ShirtSize.SetFormValue(val);
            }

            // Check field name 'TrousersSize' before field var 'x_TrousersSize'
            val = CurrentForm.HasValue("TrousersSize") ? CurrentForm.GetValue("TrousersSize") : CurrentForm.GetValue("x_TrousersSize");
            if (!TrousersSize.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("TrousersSize") && !CurrentForm.HasValue("x_TrousersSize")) // DN
                    TrousersSize.Visible = false; // Disable update for API request
                else
                    TrousersSize.SetFormValue(val);
            }

            // Check field name 'NomineeFullName' before field var 'x_NomineeFullName'
            val = CurrentForm.HasValue("NomineeFullName") ? CurrentForm.GetValue("NomineeFullName") : CurrentForm.GetValue("x_NomineeFullName");
            if (!NomineeFullName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeFullName") && !CurrentForm.HasValue("x_NomineeFullName")) // DN
                    NomineeFullName.Visible = false; // Disable update for API request
                else
                    NomineeFullName.SetFormValue(val);
            }

            // Check field name 'NomineeRelationship' before field var 'x_NomineeRelationship'
            val = CurrentForm.HasValue("NomineeRelationship") ? CurrentForm.GetValue("NomineeRelationship") : CurrentForm.GetValue("x_NomineeRelationship");
            if (!NomineeRelationship.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeRelationship") && !CurrentForm.HasValue("x_NomineeRelationship")) // DN
                    NomineeRelationship.Visible = false; // Disable update for API request
                else
                    NomineeRelationship.SetFormValue(val);
            }

            // Check field name 'NomineeGender' before field var 'x_NomineeGender'
            val = CurrentForm.HasValue("NomineeGender") ? CurrentForm.GetValue("NomineeGender") : CurrentForm.GetValue("x_NomineeGender");
            if (!NomineeGender.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeGender") && !CurrentForm.HasValue("x_NomineeGender")) // DN
                    NomineeGender.Visible = false; // Disable update for API request
                else
                    NomineeGender.SetFormValue(val);
            }

            // Check field name 'NomineeNationality_CountryID' before field var 'x_NomineeNationality_CountryID'
            val = CurrentForm.HasValue("NomineeNationality_CountryID") ? CurrentForm.GetValue("NomineeNationality_CountryID") : CurrentForm.GetValue("x_NomineeNationality_CountryID");
            if (!NomineeNationality_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeNationality_CountryID") && !CurrentForm.HasValue("x_NomineeNationality_CountryID")) // DN
                    NomineeNationality_CountryID.Visible = false; // Disable update for API request
                else
                    NomineeNationality_CountryID.SetFormValue(val);
            }

            // Check field name 'NomineeAddressDetail' before field var 'x_NomineeAddressDetail'
            val = CurrentForm.HasValue("NomineeAddressDetail") ? CurrentForm.GetValue("NomineeAddressDetail") : CurrentForm.GetValue("x_NomineeAddressDetail");
            if (!NomineeAddressDetail.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeAddressDetail") && !CurrentForm.HasValue("x_NomineeAddressDetail")) // DN
                    NomineeAddressDetail.Visible = false; // Disable update for API request
                else
                    NomineeAddressDetail.SetFormValue(val);
            }

            // Check field name 'NomineeAddressCity' before field var 'x_NomineeAddressCity'
            val = CurrentForm.HasValue("NomineeAddressCity") ? CurrentForm.GetValue("NomineeAddressCity") : CurrentForm.GetValue("x_NomineeAddressCity");
            if (!NomineeAddressCity.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeAddressCity") && !CurrentForm.HasValue("x_NomineeAddressCity")) // DN
                    NomineeAddressCity.Visible = false; // Disable update for API request
                else
                    NomineeAddressCity.SetFormValue(val);
            }

            // Check field name 'NomineeAddressPostCode' before field var 'x_NomineeAddressPostCode'
            val = CurrentForm.HasValue("NomineeAddressPostCode") ? CurrentForm.GetValue("NomineeAddressPostCode") : CurrentForm.GetValue("x_NomineeAddressPostCode");
            if (!NomineeAddressPostCode.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeAddressPostCode") && !CurrentForm.HasValue("x_NomineeAddressPostCode")) // DN
                    NomineeAddressPostCode.Visible = false; // Disable update for API request
                else
                    NomineeAddressPostCode.SetFormValue(val);
            }

            // Check field name 'NomineeAddressCountryID' before field var 'x_NomineeAddressCountryID'
            val = CurrentForm.HasValue("NomineeAddressCountryID") ? CurrentForm.GetValue("NomineeAddressCountryID") : CurrentForm.GetValue("x_NomineeAddressCountryID");
            if (!NomineeAddressCountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeAddressCountryID") && !CurrentForm.HasValue("x_NomineeAddressCountryID")) // DN
                    NomineeAddressCountryID.Visible = false; // Disable update for API request
                else
                    NomineeAddressCountryID.SetFormValue(val);
            }

            // Check field name 'NomineeAddressHomeTel' before field var 'x_NomineeAddressHomeTel'
            val = CurrentForm.HasValue("NomineeAddressHomeTel") ? CurrentForm.GetValue("NomineeAddressHomeTel") : CurrentForm.GetValue("x_NomineeAddressHomeTel");
            if (!NomineeAddressHomeTel.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeAddressHomeTel") && !CurrentForm.HasValue("x_NomineeAddressHomeTel")) // DN
                    NomineeAddressHomeTel.Visible = false; // Disable update for API request
                else
                    NomineeAddressHomeTel.SetFormValue(val);
            }

            // Check field name 'NomineeEmail' before field var 'x_NomineeEmail'
            val = CurrentForm.HasValue("NomineeEmail") ? CurrentForm.GetValue("NomineeEmail") : CurrentForm.GetValue("x_NomineeEmail");
            if (!NomineeEmail.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeEmail") && !CurrentForm.HasValue("x_NomineeEmail")) // DN
                    NomineeEmail.Visible = false; // Disable update for API request
                else
                    NomineeEmail.SetFormValue(val, true, validate);
            }

            // Check field name 'NomineeMobileNumber' before field var 'x_NomineeMobileNumber'
            val = CurrentForm.HasValue("NomineeMobileNumber") ? CurrentForm.GetValue("NomineeMobileNumber") : CurrentForm.GetValue("x_NomineeMobileNumber");
            if (!NomineeMobileNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeMobileNumber") && !CurrentForm.HasValue("x_NomineeMobileNumber")) // DN
                    NomineeMobileNumber.Visible = false; // Disable update for API request
                else
                    NomineeMobileNumber.SetFormValue(val);
            }

            // Check field name 'NSSF_Health_Number' before field var 'x_NSSF_Health_Number'
            val = CurrentForm.HasValue("NSSF_Health_Number") ? CurrentForm.GetValue("NSSF_Health_Number") : CurrentForm.GetValue("x_NSSF_Health_Number");
            if (!NSSF_Health_Number.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NSSF_Health_Number") && !CurrentForm.HasValue("x_NSSF_Health_Number")) // DN
                    NSSF_Health_Number.Visible = false; // Disable update for API request
                else
                    NSSF_Health_Number.SetFormValue(val);
            }

            // Check field name 'NSSF_Occupation_Number' before field var 'x_NSSF_Occupation_Number'
            val = CurrentForm.HasValue("NSSF_Occupation_Number") ? CurrentForm.GetValue("NSSF_Occupation_Number") : CurrentForm.GetValue("x_NSSF_Occupation_Number");
            if (!NSSF_Occupation_Number.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NSSF_Occupation_Number") && !CurrentForm.HasValue("x_NSSF_Occupation_Number")) // DN
                    NSSF_Occupation_Number.Visible = false; // Disable update for API request
                else
                    NSSF_Occupation_Number.SetFormValue(val);
            }

            // Check field name 'NomineeRelationshipSelect' before field var 'x_NomineeRelationshipSelect'
            val = CurrentForm.HasValue("NomineeRelationshipSelect") ? CurrentForm.GetValue("NomineeRelationshipSelect") : CurrentForm.GetValue("x_NomineeRelationshipSelect");
            if (!NomineeRelationshipSelect.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeRelationshipSelect") && !CurrentForm.HasValue("x_NomineeRelationshipSelect")) // DN
                    NomineeRelationshipSelect.Visible = false; // Disable update for API request
                else
                    NomineeRelationshipSelect.SetFormValue(val);
            }

            // Check field name 'NomineeRelationshipDetail' before field var 'x_NomineeRelationshipDetail'
            val = CurrentForm.HasValue("NomineeRelationshipDetail") ? CurrentForm.GetValue("NomineeRelationshipDetail") : CurrentForm.GetValue("x_NomineeRelationshipDetail");
            if (!NomineeRelationshipDetail.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeRelationshipDetail") && !CurrentForm.HasValue("x_NomineeRelationshipDetail")) // DN
                    NomineeRelationshipDetail.Visible = false; // Disable update for API request
                else
                    NomineeRelationshipDetail.SetFormValue(val);
            }

            // Check field name 'MobileNumberCode_CountryID' before field var 'x_MobileNumberCode_CountryID'
            val = CurrentForm.HasValue("MobileNumberCode_CountryID") ? CurrentForm.GetValue("MobileNumberCode_CountryID") : CurrentForm.GetValue("x_MobileNumberCode_CountryID");
            if (!MobileNumberCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MobileNumberCode_CountryID") && !CurrentForm.HasValue("x_MobileNumberCode_CountryID")) // DN
                    MobileNumberCode_CountryID.Visible = false; // Disable update for API request
                else
                    MobileNumberCode_CountryID.SetFormValue(val);
            }

            // Check field name 'PrimaryAddressHomeTelCode_CountryID' before field var 'x_PrimaryAddressHomeTelCode_CountryID'
            val = CurrentForm.HasValue("PrimaryAddressHomeTelCode_CountryID") ? CurrentForm.GetValue("PrimaryAddressHomeTelCode_CountryID") : CurrentForm.GetValue("x_PrimaryAddressHomeTelCode_CountryID");
            if (!PrimaryAddressHomeTelCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressHomeTelCode_CountryID") && !CurrentForm.HasValue("x_PrimaryAddressHomeTelCode_CountryID")) // DN
                    PrimaryAddressHomeTelCode_CountryID.Visible = false; // Disable update for API request
                else
                    PrimaryAddressHomeTelCode_CountryID.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressHomeTelCode_CountryID' before field var 'x_AlternativeAddressHomeTelCode_CountryID'
            val = CurrentForm.HasValue("AlternativeAddressHomeTelCode_CountryID") ? CurrentForm.GetValue("AlternativeAddressHomeTelCode_CountryID") : CurrentForm.GetValue("x_AlternativeAddressHomeTelCode_CountryID");
            if (!AlternativeAddressHomeTelCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressHomeTelCode_CountryID") && !CurrentForm.HasValue("x_AlternativeAddressHomeTelCode_CountryID")) // DN
                    AlternativeAddressHomeTelCode_CountryID.Visible = false; // Disable update for API request
                else
                    AlternativeAddressHomeTelCode_CountryID.SetFormValue(val);
            }

            // Check field name 'NomineeAddressHomeTelCode_CountryID' before field var 'x_NomineeAddressHomeTelCode_CountryID'
            val = CurrentForm.HasValue("NomineeAddressHomeTelCode_CountryID") ? CurrentForm.GetValue("NomineeAddressHomeTelCode_CountryID") : CurrentForm.GetValue("x_NomineeAddressHomeTelCode_CountryID");
            if (!NomineeAddressHomeTelCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeAddressHomeTelCode_CountryID") && !CurrentForm.HasValue("x_NomineeAddressHomeTelCode_CountryID")) // DN
                    NomineeAddressHomeTelCode_CountryID.Visible = false; // Disable update for API request
                else
                    NomineeAddressHomeTelCode_CountryID.SetFormValue(val);
            }

            // Check field name 'NomineeMobileNumberCode_CountryID' before field var 'x_NomineeMobileNumberCode_CountryID'
            val = CurrentForm.HasValue("NomineeMobileNumberCode_CountryID") ? CurrentForm.GetValue("NomineeMobileNumberCode_CountryID") : CurrentForm.GetValue("x_NomineeMobileNumberCode_CountryID");
            if (!NomineeMobileNumberCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeMobileNumberCode_CountryID") && !CurrentForm.HasValue("x_NomineeMobileNumberCode_CountryID")) // DN
                    NomineeMobileNumberCode_CountryID.Visible = false; // Disable update for API request
                else
                    NomineeMobileNumberCode_CountryID.SetFormValue(val);
            }

            // Check field name 'MTManningAgentID' before field var 'x_MTManningAgentID'
            val = CurrentForm.HasValue("MTManningAgentID") ? CurrentForm.GetValue("MTManningAgentID") : CurrentForm.GetValue("x_MTManningAgentID");
            if (!MTManningAgentID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MTManningAgentID") && !CurrentForm.HasValue("x_MTManningAgentID")) // DN
                    MTManningAgentID.Visible = false; // Disable update for API request
                else
                    MTManningAgentID.SetFormValue(val);
            }

            // Check field name 'ID' before field var 'x_ID'
            val = CurrentForm.HasValue("ID") ? CurrentForm.GetValue("ID") : CurrentForm.GetValue("x_ID");
            if (!ID.IsDetailKey)
                ID.SetFormValue(val);
            RequiredPhoto.OldUploadPath = RequiredPhoto.GetUploadPath();
            RequiredPhoto.UploadPath = RequiredPhoto.OldUploadPath;
            VisaPhoto.OldUploadPath = VisaPhoto.GetUploadPath();
            VisaPhoto.UploadPath = VisaPhoto.OldUploadPath;
            SocialSecurityImage.OldUploadPath = SocialSecurityImage.GetUploadPath();
            SocialSecurityImage.UploadPath = SocialSecurityImage.OldUploadPath;
            PersonalTaxImage.OldUploadPath = PersonalTaxImage.GetUploadPath();
            PersonalTaxImage.UploadPath = PersonalTaxImage.OldUploadPath;
            await GetUploadFiles(); // Get upload files
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            ID.CurrentValue = ID.FormValue;
            IndividualCodeNumber.CurrentValue = IndividualCodeNumber.FormValue;
            FullName.CurrentValue = FullName.FormValue;
            Nationality_CountryID.CurrentValue = Nationality_CountryID.FormValue;
            CountryOfOrigin_CountryID.CurrentValue = CountryOfOrigin_CountryID.FormValue;
            DateOfBirth.CurrentValue = DateOfBirth.FormValue;
            DateOfBirth.CurrentValue = UnformatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern);
            CityOfBirth.CurrentValue = CityOfBirth.FormValue;
            Gender.CurrentValue = Gender.FormValue;
            MaritalStatus.CurrentValue = MaritalStatus.FormValue;
            ReligionID.CurrentValue = ReligionID.FormValue;
            BloodType.CurrentValue = BloodType.FormValue;
            RankAppliedFor_RankID.CurrentValue = RankAppliedFor_RankID.FormValue;
            WillAcceptLowRank.CurrentValue = WillAcceptLowRank.FormValue;
            AvailableFrom.CurrentValue = AvailableFrom.FormValue;
            AvailableFrom.CurrentValue = UnformatDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern);
            AvailableUntil.CurrentValue = AvailableUntil.FormValue;
            AvailableUntil.CurrentValue = UnformatDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern);
            PrimaryAddressDetail.CurrentValue = PrimaryAddressDetail.FormValue;
            PrimaryAddressCity.CurrentValue = PrimaryAddressCity.FormValue;
            PrimaryAddressNearestAirport.CurrentValue = PrimaryAddressNearestAirport.FormValue;
            PrimaryAddressState.CurrentValue = PrimaryAddressState.FormValue;
            PrimaryAddressPostCode.CurrentValue = PrimaryAddressPostCode.FormValue;
            PrimaryAddressCountryID.CurrentValue = PrimaryAddressCountryID.FormValue;
            PrimaryAddressHomeTel.CurrentValue = PrimaryAddressHomeTel.FormValue;
            AlternativeAddressDetail.CurrentValue = AlternativeAddressDetail.FormValue;
            AlternativeAddressState.CurrentValue = AlternativeAddressState.FormValue;
            AlternativeAddressCity.CurrentValue = AlternativeAddressCity.FormValue;
            AlternativeAddressHomeTel.CurrentValue = AlternativeAddressHomeTel.FormValue;
            AlternativeAddressPostCode.CurrentValue = AlternativeAddressPostCode.FormValue;
            AlternativeAddressCountryID.CurrentValue = AlternativeAddressCountryID.FormValue;
            MobileNumber.CurrentValue = MobileNumber.FormValue;
            _Email.CurrentValue = _Email.FormValue;
            SocialSecurityNumber.CurrentValue = SocialSecurityNumber.FormValue;
            SocialSecurityIssuingCountryID.CurrentValue = SocialSecurityIssuingCountryID.FormValue;
            PersonalTaxNumber.CurrentValue = PersonalTaxNumber.FormValue;
            PersonalTaxIssuingCountryID.CurrentValue = PersonalTaxIssuingCountryID.FormValue;
            Status.CurrentValue = Status.FormValue;
            Reason.CurrentValue = Reason.FormValue;
            Weight.CurrentValue = Weight.FormValue;
            Height.CurrentValue = Height.FormValue;
            CoverallSize.CurrentValue = CoverallSize.FormValue;
            SafetyShoesSize.CurrentValue = SafetyShoesSize.FormValue;
            ShirtSize.CurrentValue = ShirtSize.FormValue;
            TrousersSize.CurrentValue = TrousersSize.FormValue;
            NomineeFullName.CurrentValue = NomineeFullName.FormValue;
            NomineeRelationship.CurrentValue = NomineeRelationship.FormValue;
            NomineeGender.CurrentValue = NomineeGender.FormValue;
            NomineeNationality_CountryID.CurrentValue = NomineeNationality_CountryID.FormValue;
            NomineeAddressDetail.CurrentValue = NomineeAddressDetail.FormValue;
            NomineeAddressCity.CurrentValue = NomineeAddressCity.FormValue;
            NomineeAddressPostCode.CurrentValue = NomineeAddressPostCode.FormValue;
            NomineeAddressCountryID.CurrentValue = NomineeAddressCountryID.FormValue;
            NomineeAddressHomeTel.CurrentValue = NomineeAddressHomeTel.FormValue;
            NomineeEmail.CurrentValue = NomineeEmail.FormValue;
            NomineeMobileNumber.CurrentValue = NomineeMobileNumber.FormValue;
            NSSF_Health_Number.CurrentValue = NSSF_Health_Number.FormValue;
            NSSF_Occupation_Number.CurrentValue = NSSF_Occupation_Number.FormValue;
            NomineeRelationshipSelect.CurrentValue = NomineeRelationshipSelect.FormValue;
            NomineeRelationshipDetail.CurrentValue = NomineeRelationshipDetail.FormValue;
            MobileNumberCode_CountryID.CurrentValue = MobileNumberCode_CountryID.FormValue;
            PrimaryAddressHomeTelCode_CountryID.CurrentValue = PrimaryAddressHomeTelCode_CountryID.FormValue;
            AlternativeAddressHomeTelCode_CountryID.CurrentValue = AlternativeAddressHomeTelCode_CountryID.FormValue;
            NomineeAddressHomeTelCode_CountryID.CurrentValue = NomineeAddressHomeTelCode_CountryID.FormValue;
            NomineeMobileNumberCode_CountryID.CurrentValue = NomineeMobileNumberCode_CountryID.FormValue;
            MTManningAgentID.CurrentValue = MTManningAgentID.FormValue;
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

            // Check if valid User ID
            if (res) {
                res = ShowOptionLink("edit");
                if (!res)
                    FailureMessage = DeniedMessage();
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
            ID.RowCssClass = "row";

            // IndividualCodeNumber
            IndividualCodeNumber.RowCssClass = "row";

            // FullName
            FullName.RowCssClass = "row";

            // RequiredPhoto
            RequiredPhoto.RowCssClass = "row";

            // VisaPhoto
            VisaPhoto.RowCssClass = "row";

            // Nationality_CountryID
            Nationality_CountryID.RowCssClass = "row";

            // CountryOfOrigin_CountryID
            CountryOfOrigin_CountryID.RowCssClass = "row";

            // DateOfBirth
            DateOfBirth.RowCssClass = "row";

            // CityOfBirth
            CityOfBirth.RowCssClass = "row";

            // Gender
            Gender.RowCssClass = "row";

            // MaritalStatus
            MaritalStatus.RowCssClass = "row";

            // ReligionID
            ReligionID.RowCssClass = "row";

            // BloodType
            BloodType.RowCssClass = "row";

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.RowCssClass = "row";

            // WillAcceptLowRank
            WillAcceptLowRank.RowCssClass = "row";

            // AvailableFrom
            AvailableFrom.RowCssClass = "row";

            // AvailableUntil
            AvailableUntil.RowCssClass = "row";

            // PrimaryAddressDetail
            PrimaryAddressDetail.RowCssClass = "row";

            // PrimaryAddressCity
            PrimaryAddressCity.RowCssClass = "row";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.RowCssClass = "row";

            // PrimaryAddressState
            PrimaryAddressState.RowCssClass = "row";

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.RowCssClass = "row";

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.RowCssClass = "row";

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.RowCssClass = "row";

            // AlternativeAddressDetail
            AlternativeAddressDetail.RowCssClass = "row";

            // AlternativeAddressState
            AlternativeAddressState.RowCssClass = "row";

            // AlternativeAddressCity
            AlternativeAddressCity.RowCssClass = "row";

            // AlternativeAddressHomeTel
            AlternativeAddressHomeTel.RowCssClass = "row";

            // AlternativeAddressPostCode
            AlternativeAddressPostCode.RowCssClass = "row";

            // AlternativeAddressCountryID
            AlternativeAddressCountryID.RowCssClass = "row";

            // MobileNumber
            MobileNumber.RowCssClass = "row";

            // Email
            _Email.RowCssClass = "row";

            // EmployeeStatus
            EmployeeStatus.RowCssClass = "row";

            // FormSubmittedDateTime
            FormSubmittedDateTime.RowCssClass = "row";

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

            // SocialSecurityNumber
            SocialSecurityNumber.RowCssClass = "row";

            // SocialSecurityIssuingCountryID
            SocialSecurityIssuingCountryID.RowCssClass = "row";

            // SocialSecurityImage
            SocialSecurityImage.RowCssClass = "row";

            // PersonalTaxNumber
            PersonalTaxNumber.RowCssClass = "row";

            // PersonalTaxIssuingCountryID
            PersonalTaxIssuingCountryID.RowCssClass = "row";

            // PersonalTaxImage
            PersonalTaxImage.RowCssClass = "row";

            // Status
            Status.RowCssClass = "row";

            // Reason
            Reason.RowCssClass = "row";

            // Weight
            Weight.RowCssClass = "row";

            // Height
            Height.RowCssClass = "row";

            // CoverallSize
            CoverallSize.RowCssClass = "row";

            // SafetyShoesSize
            SafetyShoesSize.RowCssClass = "row";

            // ShirtSize
            ShirtSize.RowCssClass = "row";

            // TrousersSize
            TrousersSize.RowCssClass = "row";

            // NomineeFullName
            NomineeFullName.RowCssClass = "row";

            // NomineeRelationship
            NomineeRelationship.RowCssClass = "row";

            // NomineeGender
            NomineeGender.RowCssClass = "row";

            // NomineeNationality_CountryID
            NomineeNationality_CountryID.RowCssClass = "row";

            // NomineeAddressDetail
            NomineeAddressDetail.RowCssClass = "row";

            // NomineeAddressCity
            NomineeAddressCity.RowCssClass = "row";

            // NomineeAddressPostCode
            NomineeAddressPostCode.RowCssClass = "row";

            // NomineeAddressCountryID
            NomineeAddressCountryID.RowCssClass = "row";

            // NomineeAddressHomeTel
            NomineeAddressHomeTel.RowCssClass = "row";

            // NomineeEmail
            NomineeEmail.RowCssClass = "row";

            // NomineeMobileNumber
            NomineeMobileNumber.RowCssClass = "row";

            // NSSF_Health_Number
            NSSF_Health_Number.RowCssClass = "row";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.RowCssClass = "row";

            // NomineeRelationshipSelect
            NomineeRelationshipSelect.RowCssClass = "row";

            // NomineeRelationshipDetail
            NomineeRelationshipDetail.RowCssClass = "row";

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.RowCssClass = "row";

            // PrimaryAddressHomeTelCode_CountryID
            PrimaryAddressHomeTelCode_CountryID.RowCssClass = "row";

            // AlternativeAddressHomeTelCode_CountryID
            AlternativeAddressHomeTelCode_CountryID.RowCssClass = "row";

            // NomineeAddressHomeTelCode_CountryID
            NomineeAddressHomeTelCode_CountryID.RowCssClass = "row";

            // NomineeMobileNumberCode_CountryID
            NomineeMobileNumberCode_CountryID.RowCssClass = "row";

            // MTManningAgentID
            MTManningAgentID.RowCssClass = "row";

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

                // NomineeRelationshipSelect
                if (!Empty(NomineeRelationshipSelect.CurrentValue)) {
                    NomineeRelationshipSelect.ViewValue = NomineeRelationshipSelect.HighlightLookup(ConvertToString(NomineeRelationshipSelect.CurrentValue), NomineeRelationshipSelect.OptionCaption(ConvertToString(NomineeRelationshipSelect.CurrentValue)));
                } else {
                    NomineeRelationshipSelect.ViewValue = DbNullValue;
                }
                NomineeRelationshipSelect.ViewCustomAttributes = "";

                // NomineeRelationshipDetail
                NomineeRelationshipDetail.ViewValue = ConvertToString(NomineeRelationshipDetail.CurrentValue); // DN
                NomineeRelationshipDetail.ViewCustomAttributes = "";

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

                // Nationality_CountryID
                Nationality_CountryID.HrefValue = "";

                // CountryOfOrigin_CountryID
                CountryOfOrigin_CountryID.HrefValue = "";

                // DateOfBirth
                DateOfBirth.HrefValue = "";

                // CityOfBirth
                CityOfBirth.HrefValue = "";

                // Gender
                Gender.HrefValue = "";

                // MaritalStatus
                MaritalStatus.HrefValue = "";

                // ReligionID
                ReligionID.HrefValue = "";

                // BloodType
                BloodType.HrefValue = "";

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.HrefValue = "";

                // WillAcceptLowRank
                WillAcceptLowRank.HrefValue = "";

                // AvailableFrom
                AvailableFrom.HrefValue = "";

                // AvailableUntil
                AvailableUntil.HrefValue = "";

                // PrimaryAddressDetail
                PrimaryAddressDetail.HrefValue = "";

                // PrimaryAddressCity
                PrimaryAddressCity.HrefValue = "";

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.HrefValue = "";

                // PrimaryAddressState
                PrimaryAddressState.HrefValue = "";

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.HrefValue = "";

                // PrimaryAddressCountryID
                PrimaryAddressCountryID.HrefValue = "";

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.HrefValue = "";

                // AlternativeAddressDetail
                AlternativeAddressDetail.HrefValue = "";

                // AlternativeAddressState
                AlternativeAddressState.HrefValue = "";

                // AlternativeAddressCity
                AlternativeAddressCity.HrefValue = "";

                // AlternativeAddressHomeTel
                AlternativeAddressHomeTel.HrefValue = "";

                // AlternativeAddressPostCode
                AlternativeAddressPostCode.HrefValue = "";

                // AlternativeAddressCountryID
                AlternativeAddressCountryID.HrefValue = "";

                // MobileNumber
                MobileNumber.HrefValue = "";

                // Email
                _Email.HrefValue = "";

                // SocialSecurityNumber
                SocialSecurityNumber.HrefValue = "";

                // SocialSecurityIssuingCountryID
                SocialSecurityIssuingCountryID.HrefValue = "";

                // SocialSecurityImage
                SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
                if (!IsNull(SocialSecurityImage.Upload.DbValue)) {
                    SocialSecurityImage.HrefValue = ConvertToString(GetFileUploadUrl(SocialSecurityImage, SocialSecurityImage.HtmlDecode(ConvertToString(SocialSecurityImage.Upload.DbValue)))); // Add prefix/suffix
                    SocialSecurityImage.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        SocialSecurityImage.HrefValue = FullUrl(ConvertToString(SocialSecurityImage.HrefValue), "href");
                } else {
                    SocialSecurityImage.HrefValue = "";
                }
                SocialSecurityImage.ExportHrefValue = SocialSecurityImage.UploadPath + SocialSecurityImage.Upload.DbValue;

                // PersonalTaxNumber
                PersonalTaxNumber.HrefValue = "";

                // PersonalTaxIssuingCountryID
                PersonalTaxIssuingCountryID.HrefValue = "";

                // PersonalTaxImage
                PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
                if (!IsNull(PersonalTaxImage.Upload.DbValue)) {
                    PersonalTaxImage.HrefValue = ConvertToString(GetFileUploadUrl(PersonalTaxImage, PersonalTaxImage.HtmlDecode(ConvertToString(PersonalTaxImage.Upload.DbValue)))); // Add prefix/suffix
                    PersonalTaxImage.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        PersonalTaxImage.HrefValue = FullUrl(ConvertToString(PersonalTaxImage.HrefValue), "href");
                } else {
                    PersonalTaxImage.HrefValue = "";
                }
                PersonalTaxImage.ExportHrefValue = PersonalTaxImage.UploadPath + PersonalTaxImage.Upload.DbValue;

                // Status
                Status.HrefValue = "";

                // Reason
                Reason.HrefValue = "";

                // Weight
                Weight.HrefValue = "";

                // Height
                Height.HrefValue = "";

                // CoverallSize
                CoverallSize.HrefValue = "";

                // SafetyShoesSize
                SafetyShoesSize.HrefValue = "";

                // ShirtSize
                ShirtSize.HrefValue = "";

                // TrousersSize
                TrousersSize.HrefValue = "";

                // NomineeFullName
                NomineeFullName.HrefValue = "";

                // NomineeRelationship
                NomineeRelationship.HrefValue = "";

                // NomineeGender
                NomineeGender.HrefValue = "";

                // NomineeNationality_CountryID
                NomineeNationality_CountryID.HrefValue = "";

                // NomineeAddressDetail
                NomineeAddressDetail.HrefValue = "";

                // NomineeAddressCity
                NomineeAddressCity.HrefValue = "";

                // NomineeAddressPostCode
                NomineeAddressPostCode.HrefValue = "";

                // NomineeAddressCountryID
                NomineeAddressCountryID.HrefValue = "";

                // NomineeAddressHomeTel
                NomineeAddressHomeTel.HrefValue = "";

                // NomineeEmail
                NomineeEmail.HrefValue = "";

                // NomineeMobileNumber
                NomineeMobileNumber.HrefValue = "";

                // NSSF_Health_Number
                NSSF_Health_Number.HrefValue = "";

                // NSSF_Occupation_Number
                NSSF_Occupation_Number.HrefValue = "";

                // NomineeRelationshipSelect
                NomineeRelationshipSelect.HrefValue = "";

                // NomineeRelationshipDetail
                NomineeRelationshipDetail.HrefValue = "";

                // MobileNumberCode_CountryID
                MobileNumberCode_CountryID.HrefValue = "";

                // PrimaryAddressHomeTelCode_CountryID
                PrimaryAddressHomeTelCode_CountryID.HrefValue = "";

                // AlternativeAddressHomeTelCode_CountryID
                AlternativeAddressHomeTelCode_CountryID.HrefValue = "";

                // NomineeAddressHomeTelCode_CountryID
                NomineeAddressHomeTelCode_CountryID.HrefValue = "";

                // NomineeMobileNumberCode_CountryID
                NomineeMobileNumberCode_CountryID.HrefValue = "";

                // MTManningAgentID
                MTManningAgentID.HrefValue = "";
            } else if (RowType == RowType.Edit) {
                // IndividualCodeNumber
                IndividualCodeNumber.SetupEditAttributes();
                IndividualCodeNumber.EditValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
                IndividualCodeNumber.ViewCustomAttributes = "";

                // FullName
                FullName.SetupEditAttributes();
                if (!FullName.Raw)
                    FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
                FullName.EditValue = HtmlEncode(FullName.CurrentValue);
                FullName.PlaceHolder = RemoveHtml(FullName.Caption);

                // RequiredPhoto
                RequiredPhoto.SetupEditAttributes();
                RequiredPhoto.EditAttrs["accept"] = "jpg,jpeg,png";
                RequiredPhoto.UploadPath = RequiredPhoto.GetUploadPath();
                if (!IsNull(RequiredPhoto.Upload.DbValue)) {
                    RequiredPhoto.ImageWidth = 120;
                    RequiredPhoto.ImageHeight = 0;
                    RequiredPhoto.ImageAlt = RequiredPhoto.Alt;
                    RequiredPhoto.ImageCssClass = "ew-image";
                    RequiredPhoto.EditValue = RequiredPhoto.Upload.DbValue;
                } else {
                    RequiredPhoto.EditValue = "";
                }
                if (!Empty(RequiredPhoto.CurrentValue))
                        RequiredPhoto.Upload.FileName = ConvertToString(RequiredPhoto.CurrentValue);
                if (IsShow && !EventCancelled)
                    await RenderUploadField(RequiredPhoto);

                // VisaPhoto
                VisaPhoto.SetupEditAttributes();
                VisaPhoto.EditAttrs["accept"] = "jpg,jpeg,png";
                VisaPhoto.UploadPath = VisaPhoto.GetUploadPath();
                if (!IsNull(VisaPhoto.Upload.DbValue)) {
                    VisaPhoto.ImageWidth = 120;
                    VisaPhoto.ImageHeight = 0;
                    VisaPhoto.ImageAlt = VisaPhoto.Alt;
                    VisaPhoto.ImageCssClass = "ew-image";
                    VisaPhoto.EditValue = VisaPhoto.Upload.DbValue;
                } else {
                    VisaPhoto.EditValue = "";
                }
                if (!Empty(VisaPhoto.CurrentValue))
                        VisaPhoto.Upload.FileName = ConvertToString(VisaPhoto.CurrentValue);
                if (IsShow && !EventCancelled)
                    await RenderUploadField(VisaPhoto);

                // Nationality_CountryID
                Nationality_CountryID.SetupEditAttributes();
                curVal = ConvertToString(Nationality_CountryID.CurrentValue)?.Trim() ?? "";
                if (Nationality_CountryID.Lookup != null && IsDictionary(Nationality_CountryID.Lookup?.Options) && Nationality_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Nationality_CountryID.EditValue = Nationality_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Nationality_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = Nationality_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Nationality_CountryID.EditValue = rswrk;
                }
                Nationality_CountryID.PlaceHolder = RemoveHtml(Nationality_CountryID.Caption);
                if (!Empty(Nationality_CountryID.EditValue) && IsNumeric(Nationality_CountryID.EditValue))
                    Nationality_CountryID.EditValue = FormatNumber(Nationality_CountryID.EditValue, null);

                // CountryOfOrigin_CountryID
                CountryOfOrigin_CountryID.SetupEditAttributes();
                curVal = ConvertToString(CountryOfOrigin_CountryID.CurrentValue)?.Trim() ?? "";
                if (CountryOfOrigin_CountryID.Lookup != null && IsDictionary(CountryOfOrigin_CountryID.Lookup?.Options) && CountryOfOrigin_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CountryOfOrigin_CountryID.EditValue = CountryOfOrigin_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", CountryOfOrigin_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = CountryOfOrigin_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    CountryOfOrigin_CountryID.EditValue = rswrk;
                }
                CountryOfOrigin_CountryID.PlaceHolder = RemoveHtml(CountryOfOrigin_CountryID.Caption);
                if (!Empty(CountryOfOrigin_CountryID.EditValue) && IsNumeric(CountryOfOrigin_CountryID.EditValue))
                    CountryOfOrigin_CountryID.EditValue = FormatNumber(CountryOfOrigin_CountryID.EditValue, null);

                // DateOfBirth
                DateOfBirth.SetupEditAttributes();
                DateOfBirth.EditValue = FormatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern); // DN
                DateOfBirth.PlaceHolder = RemoveHtml(DateOfBirth.Caption);

                // CityOfBirth
                CityOfBirth.SetupEditAttributes();
                if (!CityOfBirth.Raw)
                    CityOfBirth.CurrentValue = HtmlDecode(CityOfBirth.CurrentValue);
                CityOfBirth.EditValue = HtmlEncode(CityOfBirth.CurrentValue);
                CityOfBirth.PlaceHolder = RemoveHtml(CityOfBirth.Caption);

                // Gender
                Gender.SetupEditAttributes();
                Gender.EditValue = Gender.Options(true);
                Gender.PlaceHolder = RemoveHtml(Gender.Caption);

                // MaritalStatus
                MaritalStatus.SetupEditAttributes();
                MaritalStatus.EditValue = MaritalStatus.Options(true);
                MaritalStatus.PlaceHolder = RemoveHtml(MaritalStatus.Caption);

                // ReligionID
                ReligionID.SetupEditAttributes();
                curVal = ConvertToString(ReligionID.CurrentValue)?.Trim() ?? "";
                if (ReligionID.Lookup != null && IsDictionary(ReligionID.Lookup?.Options) && ReligionID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ReligionID.EditValue = ReligionID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", ReligionID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = ReligionID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    ReligionID.EditValue = rswrk;
                }
                ReligionID.PlaceHolder = RemoveHtml(ReligionID.Caption);
                if (!Empty(ReligionID.EditValue) && IsNumeric(ReligionID.EditValue))
                    ReligionID.EditValue = FormatNumber(ReligionID.EditValue, null);

                // BloodType
                BloodType.SetupEditAttributes();
                BloodType.EditValue = BloodType.Options(true);
                BloodType.PlaceHolder = RemoveHtml(BloodType.Caption);

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.SetupEditAttributes();
                curVal = ConvertToString(RankAppliedFor_RankID.CurrentValue)?.Trim() ?? "";
                if (RankAppliedFor_RankID.Lookup != null && IsDictionary(RankAppliedFor_RankID.Lookup?.Options) && RankAppliedFor_RankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    RankAppliedFor_RankID.EditValue = RankAppliedFor_RankID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", RankAppliedFor_RankID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = RankAppliedFor_RankID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    RankAppliedFor_RankID.EditValue = rswrk;
                }
                RankAppliedFor_RankID.PlaceHolder = RemoveHtml(RankAppliedFor_RankID.Caption);
                if (!Empty(RankAppliedFor_RankID.EditValue) && IsNumeric(RankAppliedFor_RankID.EditValue))
                    RankAppliedFor_RankID.EditValue = FormatNumber(RankAppliedFor_RankID.EditValue, null);

                // WillAcceptLowRank
                WillAcceptLowRank.EditValue = WillAcceptLowRank.Options(false);
                WillAcceptLowRank.PlaceHolder = RemoveHtml(WillAcceptLowRank.Caption);

                // AvailableFrom
                AvailableFrom.SetupEditAttributes();
                AvailableFrom.EditValue = FormatDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern); // DN
                AvailableFrom.PlaceHolder = RemoveHtml(AvailableFrom.Caption);

                // AvailableUntil
                AvailableUntil.SetupEditAttributes();
                AvailableUntil.EditValue = FormatDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern); // DN
                AvailableUntil.PlaceHolder = RemoveHtml(AvailableUntil.Caption);

                // PrimaryAddressDetail
                PrimaryAddressDetail.SetupEditAttributes();
                PrimaryAddressDetail.EditValue = PrimaryAddressDetail.CurrentValue; // DN
                PrimaryAddressDetail.PlaceHolder = RemoveHtml(PrimaryAddressDetail.Caption);

                // PrimaryAddressCity
                PrimaryAddressCity.SetupEditAttributes();
                if (!PrimaryAddressCity.Raw)
                    PrimaryAddressCity.CurrentValue = HtmlDecode(PrimaryAddressCity.CurrentValue);
                PrimaryAddressCity.EditValue = HtmlEncode(PrimaryAddressCity.CurrentValue);
                PrimaryAddressCity.PlaceHolder = RemoveHtml(PrimaryAddressCity.Caption);

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.SetupEditAttributes();
                if (!PrimaryAddressNearestAirport.Raw)
                    PrimaryAddressNearestAirport.CurrentValue = HtmlDecode(PrimaryAddressNearestAirport.CurrentValue);
                PrimaryAddressNearestAirport.EditValue = HtmlEncode(PrimaryAddressNearestAirport.CurrentValue);
                PrimaryAddressNearestAirport.PlaceHolder = RemoveHtml(PrimaryAddressNearestAirport.Caption);

                // PrimaryAddressState
                PrimaryAddressState.SetupEditAttributes();
                if (!PrimaryAddressState.Raw)
                    PrimaryAddressState.CurrentValue = HtmlDecode(PrimaryAddressState.CurrentValue);
                PrimaryAddressState.EditValue = HtmlEncode(PrimaryAddressState.CurrentValue);
                PrimaryAddressState.PlaceHolder = RemoveHtml(PrimaryAddressState.Caption);

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.SetupEditAttributes();
                if (!PrimaryAddressPostCode.Raw)
                    PrimaryAddressPostCode.CurrentValue = HtmlDecode(PrimaryAddressPostCode.CurrentValue);
                PrimaryAddressPostCode.EditValue = HtmlEncode(PrimaryAddressPostCode.CurrentValue);
                PrimaryAddressPostCode.PlaceHolder = RemoveHtml(PrimaryAddressPostCode.Caption);

                // PrimaryAddressCountryID
                PrimaryAddressCountryID.SetupEditAttributes();
                curVal = ConvertToString(PrimaryAddressCountryID.CurrentValue)?.Trim() ?? "";
                if (PrimaryAddressCountryID.Lookup != null && IsDictionary(PrimaryAddressCountryID.Lookup?.Options) && PrimaryAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PrimaryAddressCountryID.EditValue = PrimaryAddressCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", PrimaryAddressCountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = PrimaryAddressCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    PrimaryAddressCountryID.EditValue = rswrk;
                }
                PrimaryAddressCountryID.PlaceHolder = RemoveHtml(PrimaryAddressCountryID.Caption);
                if (!Empty(PrimaryAddressCountryID.EditValue) && IsNumeric(PrimaryAddressCountryID.EditValue))
                    PrimaryAddressCountryID.EditValue = FormatNumber(PrimaryAddressCountryID.EditValue, null);

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.SetupEditAttributes();
                if (!PrimaryAddressHomeTel.Raw)
                    PrimaryAddressHomeTel.CurrentValue = HtmlDecode(PrimaryAddressHomeTel.CurrentValue);
                PrimaryAddressHomeTel.EditValue = HtmlEncode(PrimaryAddressHomeTel.CurrentValue);
                PrimaryAddressHomeTel.PlaceHolder = RemoveHtml(PrimaryAddressHomeTel.Caption);

                // AlternativeAddressDetail
                AlternativeAddressDetail.SetupEditAttributes();
                AlternativeAddressDetail.EditValue = AlternativeAddressDetail.CurrentValue; // DN
                AlternativeAddressDetail.PlaceHolder = RemoveHtml(AlternativeAddressDetail.Caption);

                // AlternativeAddressState
                AlternativeAddressState.SetupEditAttributes();
                if (!AlternativeAddressState.Raw)
                    AlternativeAddressState.CurrentValue = HtmlDecode(AlternativeAddressState.CurrentValue);
                AlternativeAddressState.EditValue = HtmlEncode(AlternativeAddressState.CurrentValue);
                AlternativeAddressState.PlaceHolder = RemoveHtml(AlternativeAddressState.Caption);

                // AlternativeAddressCity
                AlternativeAddressCity.SetupEditAttributes();
                if (!AlternativeAddressCity.Raw)
                    AlternativeAddressCity.CurrentValue = HtmlDecode(AlternativeAddressCity.CurrentValue);
                AlternativeAddressCity.EditValue = HtmlEncode(AlternativeAddressCity.CurrentValue);
                AlternativeAddressCity.PlaceHolder = RemoveHtml(AlternativeAddressCity.Caption);

                // AlternativeAddressHomeTel
                AlternativeAddressHomeTel.SetupEditAttributes();
                if (!AlternativeAddressHomeTel.Raw)
                    AlternativeAddressHomeTel.CurrentValue = HtmlDecode(AlternativeAddressHomeTel.CurrentValue);
                AlternativeAddressHomeTel.EditValue = HtmlEncode(AlternativeAddressHomeTel.CurrentValue);
                AlternativeAddressHomeTel.PlaceHolder = RemoveHtml(AlternativeAddressHomeTel.Caption);

                // AlternativeAddressPostCode
                AlternativeAddressPostCode.SetupEditAttributes();
                if (!AlternativeAddressPostCode.Raw)
                    AlternativeAddressPostCode.CurrentValue = HtmlDecode(AlternativeAddressPostCode.CurrentValue);
                AlternativeAddressPostCode.EditValue = HtmlEncode(AlternativeAddressPostCode.CurrentValue);
                AlternativeAddressPostCode.PlaceHolder = RemoveHtml(AlternativeAddressPostCode.Caption);

                // AlternativeAddressCountryID
                AlternativeAddressCountryID.SetupEditAttributes();
                curVal = ConvertToString(AlternativeAddressCountryID.CurrentValue)?.Trim() ?? "";
                if (AlternativeAddressCountryID.Lookup != null && IsDictionary(AlternativeAddressCountryID.Lookup?.Options) && AlternativeAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    AlternativeAddressCountryID.EditValue = AlternativeAddressCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", AlternativeAddressCountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = AlternativeAddressCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    AlternativeAddressCountryID.EditValue = rswrk;
                }
                AlternativeAddressCountryID.PlaceHolder = RemoveHtml(AlternativeAddressCountryID.Caption);
                if (!Empty(AlternativeAddressCountryID.EditValue) && IsNumeric(AlternativeAddressCountryID.EditValue))
                    AlternativeAddressCountryID.EditValue = FormatNumber(AlternativeAddressCountryID.EditValue, null);

                // MobileNumber
                MobileNumber.SetupEditAttributes();
                if (!MobileNumber.Raw)
                    MobileNumber.CurrentValue = HtmlDecode(MobileNumber.CurrentValue);
                MobileNumber.EditValue = HtmlEncode(MobileNumber.CurrentValue);
                MobileNumber.PlaceHolder = RemoveHtml(MobileNumber.Caption);

                // Email
                _Email.SetupEditAttributes();
                if (!_Email.Raw)
                    _Email.CurrentValue = HtmlDecode(_Email.CurrentValue);
                _Email.EditValue = HtmlEncode(_Email.CurrentValue);
                _Email.PlaceHolder = RemoveHtml(_Email.Caption);

                // SocialSecurityNumber
                SocialSecurityNumber.SetupEditAttributes();
                if (!SocialSecurityNumber.Raw)
                    SocialSecurityNumber.CurrentValue = HtmlDecode(SocialSecurityNumber.CurrentValue);
                SocialSecurityNumber.EditValue = HtmlEncode(SocialSecurityNumber.CurrentValue);
                SocialSecurityNumber.PlaceHolder = RemoveHtml(SocialSecurityNumber.Caption);

                // SocialSecurityIssuingCountryID
                SocialSecurityIssuingCountryID.SetupEditAttributes();
                curVal = ConvertToString(SocialSecurityIssuingCountryID.CurrentValue)?.Trim() ?? "";
                if (SocialSecurityIssuingCountryID.Lookup != null && IsDictionary(SocialSecurityIssuingCountryID.Lookup?.Options) && SocialSecurityIssuingCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    SocialSecurityIssuingCountryID.EditValue = SocialSecurityIssuingCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", SocialSecurityIssuingCountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = SocialSecurityIssuingCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    SocialSecurityIssuingCountryID.EditValue = rswrk;
                }
                SocialSecurityIssuingCountryID.PlaceHolder = RemoveHtml(SocialSecurityIssuingCountryID.Caption);
                if (!Empty(SocialSecurityIssuingCountryID.EditValue) && IsNumeric(SocialSecurityIssuingCountryID.EditValue))
                    SocialSecurityIssuingCountryID.EditValue = FormatNumber(SocialSecurityIssuingCountryID.EditValue, null);

                // SocialSecurityImage
                SocialSecurityImage.SetupEditAttributes();
                SocialSecurityImage.EditAttrs["accept"] = "jpg,jpeg,png,pdf";
                SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
                if (!IsNull(SocialSecurityImage.Upload.DbValue)) {
                    SocialSecurityImage.ImageWidth = 200;
                    SocialSecurityImage.ImageHeight = 0;
                    SocialSecurityImage.ImageAlt = SocialSecurityImage.Alt;
                    SocialSecurityImage.ImageCssClass = "ew-image";
                    SocialSecurityImage.EditValue = SocialSecurityImage.Upload.DbValue;
                } else {
                    SocialSecurityImage.EditValue = "";
                }
                if (!Empty(SocialSecurityImage.CurrentValue))
                        SocialSecurityImage.Upload.FileName = ConvertToString(SocialSecurityImage.CurrentValue);
                if (IsShow && !EventCancelled)
                    await RenderUploadField(SocialSecurityImage);

                // PersonalTaxNumber
                PersonalTaxNumber.SetupEditAttributes();
                if (!PersonalTaxNumber.Raw)
                    PersonalTaxNumber.CurrentValue = HtmlDecode(PersonalTaxNumber.CurrentValue);
                PersonalTaxNumber.EditValue = HtmlEncode(PersonalTaxNumber.CurrentValue);
                PersonalTaxNumber.PlaceHolder = RemoveHtml(PersonalTaxNumber.Caption);

                // PersonalTaxIssuingCountryID
                PersonalTaxIssuingCountryID.SetupEditAttributes();
                curVal = ConvertToString(PersonalTaxIssuingCountryID.CurrentValue)?.Trim() ?? "";
                if (PersonalTaxIssuingCountryID.Lookup != null && IsDictionary(PersonalTaxIssuingCountryID.Lookup?.Options) && PersonalTaxIssuingCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PersonalTaxIssuingCountryID.EditValue = PersonalTaxIssuingCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", PersonalTaxIssuingCountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = PersonalTaxIssuingCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    PersonalTaxIssuingCountryID.EditValue = rswrk;
                }
                PersonalTaxIssuingCountryID.PlaceHolder = RemoveHtml(PersonalTaxIssuingCountryID.Caption);
                if (!Empty(PersonalTaxIssuingCountryID.EditValue) && IsNumeric(PersonalTaxIssuingCountryID.EditValue))
                    PersonalTaxIssuingCountryID.EditValue = FormatNumber(PersonalTaxIssuingCountryID.EditValue, null);

                // PersonalTaxImage
                PersonalTaxImage.SetupEditAttributes();
                PersonalTaxImage.EditAttrs["accept"] = "jpg,jpeg,png,pdf";
                PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
                if (!IsNull(PersonalTaxImage.Upload.DbValue)) {
                    PersonalTaxImage.ImageWidth = 200;
                    PersonalTaxImage.ImageHeight = 0;
                    PersonalTaxImage.ImageAlt = PersonalTaxImage.Alt;
                    PersonalTaxImage.ImageCssClass = "ew-image";
                    PersonalTaxImage.EditValue = PersonalTaxImage.Upload.DbValue;
                } else {
                    PersonalTaxImage.EditValue = "";
                }
                if (!Empty(PersonalTaxImage.CurrentValue))
                        PersonalTaxImage.Upload.FileName = ConvertToString(PersonalTaxImage.CurrentValue);
                if (IsShow && !EventCancelled)
                    await RenderUploadField(PersonalTaxImage);

                // Status
                Status.SetupEditAttributes();
                if (!Status.Raw)
                    Status.CurrentValue = HtmlDecode(Status.CurrentValue);
                Status.EditValue = HtmlEncode(Status.CurrentValue);
                Status.PlaceHolder = RemoveHtml(Status.Caption);

                // Reason
                Reason.SetupEditAttributes();
                Reason.EditValue = Reason.CurrentValue; // DN
                Reason.PlaceHolder = RemoveHtml(Reason.Caption);

                // Weight
                Weight.SetupEditAttributes();
                Weight.EditValue = Weight.CurrentValue; // DN
                Weight.PlaceHolder = RemoveHtml(Weight.Caption);

                // Height
                Height.SetupEditAttributes();
                Height.EditValue = Height.CurrentValue; // DN
                Height.PlaceHolder = RemoveHtml(Height.Caption);

                // CoverallSize
                CoverallSize.SetupEditAttributes();
                curVal = ConvertToString(CoverallSize.CurrentValue)?.Trim() ?? "";
                if (CoverallSize.Lookup != null && IsDictionary(CoverallSize.Lookup?.Options) && CoverallSize.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CoverallSize.EditValue = CoverallSize.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[Name]", "=", CoverallSize.CurrentValue, DataType.String, "");
                    }
                    sqlWrk = CoverallSize.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    CoverallSize.EditValue = rswrk;
                }
                CoverallSize.PlaceHolder = RemoveHtml(CoverallSize.Caption);

                // SafetyShoesSize
                SafetyShoesSize.SetupEditAttributes();
                SafetyShoesSize.EditValue = SafetyShoesSize.Options(true);
                SafetyShoesSize.PlaceHolder = RemoveHtml(SafetyShoesSize.Caption);

                // ShirtSize
                ShirtSize.SetupEditAttributes();
                curVal = ConvertToString(ShirtSize.CurrentValue)?.Trim() ?? "";
                if (ShirtSize.Lookup != null && IsDictionary(ShirtSize.Lookup?.Options) && ShirtSize.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ShirtSize.EditValue = ShirtSize.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[Name]", "=", ShirtSize.CurrentValue, DataType.String, "");
                    }
                    sqlWrk = ShirtSize.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    ShirtSize.EditValue = rswrk;
                }
                ShirtSize.PlaceHolder = RemoveHtml(ShirtSize.Caption);

                // TrousersSize
                TrousersSize.SetupEditAttributes();
                curVal = ConvertToString(TrousersSize.CurrentValue)?.Trim() ?? "";
                if (TrousersSize.Lookup != null && IsDictionary(TrousersSize.Lookup?.Options) && TrousersSize.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TrousersSize.EditValue = TrousersSize.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[Name]", "=", TrousersSize.CurrentValue, DataType.String, "");
                    }
                    sqlWrk = TrousersSize.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    TrousersSize.EditValue = rswrk;
                }
                TrousersSize.PlaceHolder = RemoveHtml(TrousersSize.Caption);

                // NomineeFullName
                NomineeFullName.SetupEditAttributes();
                if (!NomineeFullName.Raw)
                    NomineeFullName.CurrentValue = HtmlDecode(NomineeFullName.CurrentValue);
                NomineeFullName.EditValue = HtmlEncode(NomineeFullName.CurrentValue);
                NomineeFullName.PlaceHolder = RemoveHtml(NomineeFullName.Caption);

                // NomineeRelationship
                NomineeRelationship.SetupEditAttributes();
                if (!NomineeRelationship.Raw)
                    NomineeRelationship.CurrentValue = HtmlDecode(NomineeRelationship.CurrentValue);
                NomineeRelationship.EditValue = HtmlEncode(NomineeRelationship.CurrentValue);
                NomineeRelationship.PlaceHolder = RemoveHtml(NomineeRelationship.Caption);

                // NomineeGender
                NomineeGender.SetupEditAttributes();
                NomineeGender.EditValue = NomineeGender.Options(true);
                NomineeGender.PlaceHolder = RemoveHtml(NomineeGender.Caption);

                // NomineeNationality_CountryID
                NomineeNationality_CountryID.SetupEditAttributes();
                curVal = ConvertToString(NomineeNationality_CountryID.CurrentValue)?.Trim() ?? "";
                if (NomineeNationality_CountryID.Lookup != null && IsDictionary(NomineeNationality_CountryID.Lookup?.Options) && NomineeNationality_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeNationality_CountryID.EditValue = NomineeNationality_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", NomineeNationality_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = NomineeNationality_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    NomineeNationality_CountryID.EditValue = rswrk;
                }
                NomineeNationality_CountryID.PlaceHolder = RemoveHtml(NomineeNationality_CountryID.Caption);
                if (!Empty(NomineeNationality_CountryID.EditValue) && IsNumeric(NomineeNationality_CountryID.EditValue))
                    NomineeNationality_CountryID.EditValue = FormatNumber(NomineeNationality_CountryID.EditValue, null);

                // NomineeAddressDetail
                NomineeAddressDetail.SetupEditAttributes();
                NomineeAddressDetail.EditValue = NomineeAddressDetail.CurrentValue; // DN
                NomineeAddressDetail.PlaceHolder = RemoveHtml(NomineeAddressDetail.Caption);

                // NomineeAddressCity
                NomineeAddressCity.SetupEditAttributes();
                if (!NomineeAddressCity.Raw)
                    NomineeAddressCity.CurrentValue = HtmlDecode(NomineeAddressCity.CurrentValue);
                NomineeAddressCity.EditValue = HtmlEncode(NomineeAddressCity.CurrentValue);
                NomineeAddressCity.PlaceHolder = RemoveHtml(NomineeAddressCity.Caption);

                // NomineeAddressPostCode
                NomineeAddressPostCode.SetupEditAttributes();
                if (!NomineeAddressPostCode.Raw)
                    NomineeAddressPostCode.CurrentValue = HtmlDecode(NomineeAddressPostCode.CurrentValue);
                NomineeAddressPostCode.EditValue = HtmlEncode(NomineeAddressPostCode.CurrentValue);
                NomineeAddressPostCode.PlaceHolder = RemoveHtml(NomineeAddressPostCode.Caption);

                // NomineeAddressCountryID
                NomineeAddressCountryID.SetupEditAttributes();
                curVal = ConvertToString(NomineeAddressCountryID.CurrentValue)?.Trim() ?? "";
                if (NomineeAddressCountryID.Lookup != null && IsDictionary(NomineeAddressCountryID.Lookup?.Options) && NomineeAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeAddressCountryID.EditValue = NomineeAddressCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", NomineeAddressCountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = NomineeAddressCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    NomineeAddressCountryID.EditValue = rswrk;
                }
                NomineeAddressCountryID.PlaceHolder = RemoveHtml(NomineeAddressCountryID.Caption);
                if (!Empty(NomineeAddressCountryID.EditValue) && IsNumeric(NomineeAddressCountryID.EditValue))
                    NomineeAddressCountryID.EditValue = FormatNumber(NomineeAddressCountryID.EditValue, null);

                // NomineeAddressHomeTel
                NomineeAddressHomeTel.SetupEditAttributes();
                if (!NomineeAddressHomeTel.Raw)
                    NomineeAddressHomeTel.CurrentValue = HtmlDecode(NomineeAddressHomeTel.CurrentValue);
                NomineeAddressHomeTel.EditValue = HtmlEncode(NomineeAddressHomeTel.CurrentValue);
                NomineeAddressHomeTel.PlaceHolder = RemoveHtml(NomineeAddressHomeTel.Caption);

                // NomineeEmail
                NomineeEmail.SetupEditAttributes();
                if (!NomineeEmail.Raw)
                    NomineeEmail.CurrentValue = HtmlDecode(NomineeEmail.CurrentValue);
                NomineeEmail.EditValue = HtmlEncode(NomineeEmail.CurrentValue);
                NomineeEmail.PlaceHolder = RemoveHtml(NomineeEmail.Caption);

                // NomineeMobileNumber
                NomineeMobileNumber.SetupEditAttributes();
                if (!NomineeMobileNumber.Raw)
                    NomineeMobileNumber.CurrentValue = HtmlDecode(NomineeMobileNumber.CurrentValue);
                NomineeMobileNumber.EditValue = HtmlEncode(NomineeMobileNumber.CurrentValue);
                NomineeMobileNumber.PlaceHolder = RemoveHtml(NomineeMobileNumber.Caption);

                // NSSF_Health_Number
                NSSF_Health_Number.SetupEditAttributes();
                if (!NSSF_Health_Number.Raw)
                    NSSF_Health_Number.CurrentValue = HtmlDecode(NSSF_Health_Number.CurrentValue);
                NSSF_Health_Number.EditValue = HtmlEncode(NSSF_Health_Number.CurrentValue);
                NSSF_Health_Number.PlaceHolder = RemoveHtml(NSSF_Health_Number.Caption);

                // NSSF_Occupation_Number
                NSSF_Occupation_Number.SetupEditAttributes();
                if (!NSSF_Occupation_Number.Raw)
                    NSSF_Occupation_Number.CurrentValue = HtmlDecode(NSSF_Occupation_Number.CurrentValue);
                NSSF_Occupation_Number.EditValue = HtmlEncode(NSSF_Occupation_Number.CurrentValue);
                NSSF_Occupation_Number.PlaceHolder = RemoveHtml(NSSF_Occupation_Number.Caption);

                // NomineeRelationshipSelect
                NomineeRelationshipSelect.SetupEditAttributes();
                NomineeRelationshipSelect.EditValue = NomineeRelationshipSelect.Options(true);
                NomineeRelationshipSelect.PlaceHolder = RemoveHtml(NomineeRelationshipSelect.Caption);

                // NomineeRelationshipDetail
                NomineeRelationshipDetail.SetupEditAttributes();
                if (!NomineeRelationshipDetail.Raw)
                    NomineeRelationshipDetail.CurrentValue = HtmlDecode(NomineeRelationshipDetail.CurrentValue);
                NomineeRelationshipDetail.EditValue = HtmlEncode(NomineeRelationshipDetail.CurrentValue);
                NomineeRelationshipDetail.PlaceHolder = RemoveHtml(NomineeRelationshipDetail.Caption);

                // MobileNumberCode_CountryID
                MobileNumberCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(MobileNumberCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (MobileNumberCode_CountryID.Lookup != null && IsDictionary(MobileNumberCode_CountryID.Lookup?.Options) && MobileNumberCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MobileNumberCode_CountryID.EditValue = MobileNumberCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MobileNumberCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = MobileNumberCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MobileNumberCode_CountryID.EditValue = rswrk;
                }
                MobileNumberCode_CountryID.PlaceHolder = RemoveHtml(MobileNumberCode_CountryID.Caption);

                // PrimaryAddressHomeTelCode_CountryID
                PrimaryAddressHomeTelCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(PrimaryAddressHomeTelCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (PrimaryAddressHomeTelCode_CountryID.Lookup != null && IsDictionary(PrimaryAddressHomeTelCode_CountryID.Lookup?.Options) && PrimaryAddressHomeTelCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PrimaryAddressHomeTelCode_CountryID.EditValue = PrimaryAddressHomeTelCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", PrimaryAddressHomeTelCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = PrimaryAddressHomeTelCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    PrimaryAddressHomeTelCode_CountryID.EditValue = rswrk;
                }
                PrimaryAddressHomeTelCode_CountryID.PlaceHolder = RemoveHtml(PrimaryAddressHomeTelCode_CountryID.Caption);

                // AlternativeAddressHomeTelCode_CountryID
                AlternativeAddressHomeTelCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(AlternativeAddressHomeTelCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (AlternativeAddressHomeTelCode_CountryID.Lookup != null && IsDictionary(AlternativeAddressHomeTelCode_CountryID.Lookup?.Options) && AlternativeAddressHomeTelCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    AlternativeAddressHomeTelCode_CountryID.EditValue = AlternativeAddressHomeTelCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", AlternativeAddressHomeTelCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = AlternativeAddressHomeTelCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    AlternativeAddressHomeTelCode_CountryID.EditValue = rswrk;
                }
                AlternativeAddressHomeTelCode_CountryID.PlaceHolder = RemoveHtml(AlternativeAddressHomeTelCode_CountryID.Caption);

                // NomineeAddressHomeTelCode_CountryID
                NomineeAddressHomeTelCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(NomineeAddressHomeTelCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (NomineeAddressHomeTelCode_CountryID.Lookup != null && IsDictionary(NomineeAddressHomeTelCode_CountryID.Lookup?.Options) && NomineeAddressHomeTelCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeAddressHomeTelCode_CountryID.EditValue = NomineeAddressHomeTelCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", NomineeAddressHomeTelCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = NomineeAddressHomeTelCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    NomineeAddressHomeTelCode_CountryID.EditValue = rswrk;
                }
                NomineeAddressHomeTelCode_CountryID.PlaceHolder = RemoveHtml(NomineeAddressHomeTelCode_CountryID.Caption);

                // NomineeMobileNumberCode_CountryID
                NomineeMobileNumberCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(NomineeMobileNumberCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (NomineeMobileNumberCode_CountryID.Lookup != null && IsDictionary(NomineeMobileNumberCode_CountryID.Lookup?.Options) && NomineeMobileNumberCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeMobileNumberCode_CountryID.EditValue = NomineeMobileNumberCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", NomineeMobileNumberCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = NomineeMobileNumberCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    NomineeMobileNumberCode_CountryID.EditValue = rswrk;
                }
                NomineeMobileNumberCode_CountryID.PlaceHolder = RemoveHtml(NomineeMobileNumberCode_CountryID.Caption);

                // MTManningAgentID
                MTManningAgentID.SetupEditAttributes();
                MTManningAgentID.EditValue = MTManningAgentID.CurrentValue; // DN
                MTManningAgentID.PlaceHolder = RemoveHtml(MTManningAgentID.Caption);

                // Edit refer script

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";
                IndividualCodeNumber.TooltipValue = "";

                // FullName
                FullName.HrefValue = "";

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

                // Nationality_CountryID
                Nationality_CountryID.HrefValue = "";

                // CountryOfOrigin_CountryID
                CountryOfOrigin_CountryID.HrefValue = "";

                // DateOfBirth
                DateOfBirth.HrefValue = "";

                // CityOfBirth
                CityOfBirth.HrefValue = "";

                // Gender
                Gender.HrefValue = "";

                // MaritalStatus
                MaritalStatus.HrefValue = "";

                // ReligionID
                ReligionID.HrefValue = "";

                // BloodType
                BloodType.HrefValue = "";

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.HrefValue = "";

                // WillAcceptLowRank
                WillAcceptLowRank.HrefValue = "";

                // AvailableFrom
                AvailableFrom.HrefValue = "";

                // AvailableUntil
                AvailableUntil.HrefValue = "";

                // PrimaryAddressDetail
                PrimaryAddressDetail.HrefValue = "";

                // PrimaryAddressCity
                PrimaryAddressCity.HrefValue = "";

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.HrefValue = "";

                // PrimaryAddressState
                PrimaryAddressState.HrefValue = "";

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.HrefValue = "";

                // PrimaryAddressCountryID
                PrimaryAddressCountryID.HrefValue = "";

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.HrefValue = "";

                // AlternativeAddressDetail
                AlternativeAddressDetail.HrefValue = "";

                // AlternativeAddressState
                AlternativeAddressState.HrefValue = "";

                // AlternativeAddressCity
                AlternativeAddressCity.HrefValue = "";

                // AlternativeAddressHomeTel
                AlternativeAddressHomeTel.HrefValue = "";

                // AlternativeAddressPostCode
                AlternativeAddressPostCode.HrefValue = "";

                // AlternativeAddressCountryID
                AlternativeAddressCountryID.HrefValue = "";

                // MobileNumber
                MobileNumber.HrefValue = "";

                // Email
                _Email.HrefValue = "";

                // SocialSecurityNumber
                SocialSecurityNumber.HrefValue = "";

                // SocialSecurityIssuingCountryID
                SocialSecurityIssuingCountryID.HrefValue = "";

                // SocialSecurityImage
                SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
                if (!IsNull(SocialSecurityImage.Upload.DbValue)) {
                    SocialSecurityImage.HrefValue = ConvertToString(GetFileUploadUrl(SocialSecurityImage, SocialSecurityImage.HtmlDecode(ConvertToString(SocialSecurityImage.Upload.DbValue)))); // Add prefix/suffix
                    SocialSecurityImage.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        SocialSecurityImage.HrefValue = FullUrl(ConvertToString(SocialSecurityImage.HrefValue), "href");
                } else {
                    SocialSecurityImage.HrefValue = "";
                }
                SocialSecurityImage.ExportHrefValue = SocialSecurityImage.UploadPath + SocialSecurityImage.Upload.DbValue;

                // PersonalTaxNumber
                PersonalTaxNumber.HrefValue = "";

                // PersonalTaxIssuingCountryID
                PersonalTaxIssuingCountryID.HrefValue = "";

                // PersonalTaxImage
                PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
                if (!IsNull(PersonalTaxImage.Upload.DbValue)) {
                    PersonalTaxImage.HrefValue = ConvertToString(GetFileUploadUrl(PersonalTaxImage, PersonalTaxImage.HtmlDecode(ConvertToString(PersonalTaxImage.Upload.DbValue)))); // Add prefix/suffix
                    PersonalTaxImage.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        PersonalTaxImage.HrefValue = FullUrl(ConvertToString(PersonalTaxImage.HrefValue), "href");
                } else {
                    PersonalTaxImage.HrefValue = "";
                }
                PersonalTaxImage.ExportHrefValue = PersonalTaxImage.UploadPath + PersonalTaxImage.Upload.DbValue;

                // Status
                Status.HrefValue = "";

                // Reason
                Reason.HrefValue = "";

                // Weight
                Weight.HrefValue = "";

                // Height
                Height.HrefValue = "";

                // CoverallSize
                CoverallSize.HrefValue = "";

                // SafetyShoesSize
                SafetyShoesSize.HrefValue = "";

                // ShirtSize
                ShirtSize.HrefValue = "";

                // TrousersSize
                TrousersSize.HrefValue = "";

                // NomineeFullName
                NomineeFullName.HrefValue = "";

                // NomineeRelationship
                NomineeRelationship.HrefValue = "";

                // NomineeGender
                NomineeGender.HrefValue = "";

                // NomineeNationality_CountryID
                NomineeNationality_CountryID.HrefValue = "";

                // NomineeAddressDetail
                NomineeAddressDetail.HrefValue = "";

                // NomineeAddressCity
                NomineeAddressCity.HrefValue = "";

                // NomineeAddressPostCode
                NomineeAddressPostCode.HrefValue = "";

                // NomineeAddressCountryID
                NomineeAddressCountryID.HrefValue = "";

                // NomineeAddressHomeTel
                NomineeAddressHomeTel.HrefValue = "";

                // NomineeEmail
                NomineeEmail.HrefValue = "";

                // NomineeMobileNumber
                NomineeMobileNumber.HrefValue = "";

                // NSSF_Health_Number
                NSSF_Health_Number.HrefValue = "";

                // NSSF_Occupation_Number
                NSSF_Occupation_Number.HrefValue = "";

                // NomineeRelationshipSelect
                NomineeRelationshipSelect.HrefValue = "";

                // NomineeRelationshipDetail
                NomineeRelationshipDetail.HrefValue = "";

                // MobileNumberCode_CountryID
                MobileNumberCode_CountryID.HrefValue = "";

                // PrimaryAddressHomeTelCode_CountryID
                PrimaryAddressHomeTelCode_CountryID.HrefValue = "";

                // AlternativeAddressHomeTelCode_CountryID
                AlternativeAddressHomeTelCode_CountryID.HrefValue = "";

                // NomineeAddressHomeTelCode_CountryID
                NomineeAddressHomeTelCode_CountryID.HrefValue = "";

                // NomineeMobileNumberCode_CountryID
                NomineeMobileNumberCode_CountryID.HrefValue = "";

                // MTManningAgentID
                MTManningAgentID.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();

            // Save data for Custom Template
            if (RowType == RowType.View || RowType == RowType.Edit || RowType == RowType.Add)
                Rows.Add(CustomTemplateFieldValues());
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Validate form
        protected async Task<bool> ValidateForm() {
            // Check if validation required
            if (!Config.ServerValidate)
                return true;
            bool validateForm = true;
            if (IndividualCodeNumber.Required) {
                if (!IndividualCodeNumber.IsDetailKey && Empty(IndividualCodeNumber.FormValue)) {
                    IndividualCodeNumber.AddErrorMessage(ConvertToString(IndividualCodeNumber.RequiredErrorMessage).Replace("%s", IndividualCodeNumber.Caption));
                }
            }
            if (FullName.Required) {
                if (!FullName.IsDetailKey && Empty(FullName.FormValue)) {
                    FullName.AddErrorMessage(ConvertToString(FullName.RequiredErrorMessage).Replace("%s", FullName.Caption));
                }
            }
            if (RequiredPhoto.Required) {
                if (RequiredPhoto.Upload.FileName == "" && !RequiredPhoto.Upload.KeepFile) {
                    RequiredPhoto.AddErrorMessage(ConvertToString(RequiredPhoto.RequiredErrorMessage).Replace("%s", RequiredPhoto.Caption));
                }
            }
            if (VisaPhoto.Required) {
                if (VisaPhoto.Upload.FileName == "" && !VisaPhoto.Upload.KeepFile) {
                    VisaPhoto.AddErrorMessage(ConvertToString(VisaPhoto.RequiredErrorMessage).Replace("%s", VisaPhoto.Caption));
                }
            }
            if (Nationality_CountryID.Required) {
                if (!Nationality_CountryID.IsDetailKey && Empty(Nationality_CountryID.FormValue)) {
                    Nationality_CountryID.AddErrorMessage(ConvertToString(Nationality_CountryID.RequiredErrorMessage).Replace("%s", Nationality_CountryID.Caption));
                }
            }
            if (CountryOfOrigin_CountryID.Required) {
                if (!CountryOfOrigin_CountryID.IsDetailKey && Empty(CountryOfOrigin_CountryID.FormValue)) {
                    CountryOfOrigin_CountryID.AddErrorMessage(ConvertToString(CountryOfOrigin_CountryID.RequiredErrorMessage).Replace("%s", CountryOfOrigin_CountryID.Caption));
                }
            }
            if (DateOfBirth.Required) {
                if (!DateOfBirth.IsDetailKey && Empty(DateOfBirth.FormValue)) {
                    DateOfBirth.AddErrorMessage(ConvertToString(DateOfBirth.RequiredErrorMessage).Replace("%s", DateOfBirth.Caption));
                }
            }
            if (!CheckDate(DateOfBirth.FormValue, DateOfBirth.FormatPattern)) {
                DateOfBirth.AddErrorMessage(DateOfBirth.GetErrorMessage(false));
            }
            if (CityOfBirth.Required) {
                if (!CityOfBirth.IsDetailKey && Empty(CityOfBirth.FormValue)) {
                    CityOfBirth.AddErrorMessage(ConvertToString(CityOfBirth.RequiredErrorMessage).Replace("%s", CityOfBirth.Caption));
                }
            }
            if (Gender.Required) {
                if (!Gender.IsDetailKey && Empty(Gender.FormValue)) {
                    Gender.AddErrorMessage(ConvertToString(Gender.RequiredErrorMessage).Replace("%s", Gender.Caption));
                }
            }
            if (MaritalStatus.Required) {
                if (!MaritalStatus.IsDetailKey && Empty(MaritalStatus.FormValue)) {
                    MaritalStatus.AddErrorMessage(ConvertToString(MaritalStatus.RequiredErrorMessage).Replace("%s", MaritalStatus.Caption));
                }
            }
            if (ReligionID.Required) {
                if (!ReligionID.IsDetailKey && Empty(ReligionID.FormValue)) {
                    ReligionID.AddErrorMessage(ConvertToString(ReligionID.RequiredErrorMessage).Replace("%s", ReligionID.Caption));
                }
            }
            if (BloodType.Required) {
                if (!BloodType.IsDetailKey && Empty(BloodType.FormValue)) {
                    BloodType.AddErrorMessage(ConvertToString(BloodType.RequiredErrorMessage).Replace("%s", BloodType.Caption));
                }
            }
            if (RankAppliedFor_RankID.Required) {
                if (!RankAppliedFor_RankID.IsDetailKey && Empty(RankAppliedFor_RankID.FormValue)) {
                    RankAppliedFor_RankID.AddErrorMessage(ConvertToString(RankAppliedFor_RankID.RequiredErrorMessage).Replace("%s", RankAppliedFor_RankID.Caption));
                }
            }
            if (WillAcceptLowRank.Required) {
                if (Empty(WillAcceptLowRank.FormValue)) {
                    WillAcceptLowRank.AddErrorMessage(ConvertToString(WillAcceptLowRank.RequiredErrorMessage).Replace("%s", WillAcceptLowRank.Caption));
                }
            }
            if (AvailableFrom.Required) {
                if (!AvailableFrom.IsDetailKey && Empty(AvailableFrom.FormValue)) {
                    AvailableFrom.AddErrorMessage(ConvertToString(AvailableFrom.RequiredErrorMessage).Replace("%s", AvailableFrom.Caption));
                }
            }
            if (!CheckDate(AvailableFrom.FormValue, AvailableFrom.FormatPattern)) {
                AvailableFrom.AddErrorMessage(AvailableFrom.GetErrorMessage(false));
            }
            if (AvailableUntil.Required) {
                if (!AvailableUntil.IsDetailKey && Empty(AvailableUntil.FormValue)) {
                    AvailableUntil.AddErrorMessage(ConvertToString(AvailableUntil.RequiredErrorMessage).Replace("%s", AvailableUntil.Caption));
                }
            }
            if (!CheckDate(AvailableUntil.FormValue, AvailableUntil.FormatPattern)) {
                AvailableUntil.AddErrorMessage(AvailableUntil.GetErrorMessage(false));
            }
            if (PrimaryAddressDetail.Required) {
                if (!PrimaryAddressDetail.IsDetailKey && Empty(PrimaryAddressDetail.FormValue)) {
                    PrimaryAddressDetail.AddErrorMessage(ConvertToString(PrimaryAddressDetail.RequiredErrorMessage).Replace("%s", PrimaryAddressDetail.Caption));
                }
            }
            if (PrimaryAddressCity.Required) {
                if (!PrimaryAddressCity.IsDetailKey && Empty(PrimaryAddressCity.FormValue)) {
                    PrimaryAddressCity.AddErrorMessage(ConvertToString(PrimaryAddressCity.RequiredErrorMessage).Replace("%s", PrimaryAddressCity.Caption));
                }
            }
            if (PrimaryAddressNearestAirport.Required) {
                if (!PrimaryAddressNearestAirport.IsDetailKey && Empty(PrimaryAddressNearestAirport.FormValue)) {
                    PrimaryAddressNearestAirport.AddErrorMessage(ConvertToString(PrimaryAddressNearestAirport.RequiredErrorMessage).Replace("%s", PrimaryAddressNearestAirport.Caption));
                }
            }
            if (PrimaryAddressState.Required) {
                if (!PrimaryAddressState.IsDetailKey && Empty(PrimaryAddressState.FormValue)) {
                    PrimaryAddressState.AddErrorMessage(ConvertToString(PrimaryAddressState.RequiredErrorMessage).Replace("%s", PrimaryAddressState.Caption));
                }
            }
            if (PrimaryAddressPostCode.Required) {
                if (!PrimaryAddressPostCode.IsDetailKey && Empty(PrimaryAddressPostCode.FormValue)) {
                    PrimaryAddressPostCode.AddErrorMessage(ConvertToString(PrimaryAddressPostCode.RequiredErrorMessage).Replace("%s", PrimaryAddressPostCode.Caption));
                }
            }
            if (PrimaryAddressCountryID.Required) {
                if (!PrimaryAddressCountryID.IsDetailKey && Empty(PrimaryAddressCountryID.FormValue)) {
                    PrimaryAddressCountryID.AddErrorMessage(ConvertToString(PrimaryAddressCountryID.RequiredErrorMessage).Replace("%s", PrimaryAddressCountryID.Caption));
                }
            }
            if (PrimaryAddressHomeTel.Required) {
                if (!PrimaryAddressHomeTel.IsDetailKey && Empty(PrimaryAddressHomeTel.FormValue)) {
                    PrimaryAddressHomeTel.AddErrorMessage(ConvertToString(PrimaryAddressHomeTel.RequiredErrorMessage).Replace("%s", PrimaryAddressHomeTel.Caption));
                }
            }
            if (AlternativeAddressDetail.Required) {
                if (!AlternativeAddressDetail.IsDetailKey && Empty(AlternativeAddressDetail.FormValue)) {
                    AlternativeAddressDetail.AddErrorMessage(ConvertToString(AlternativeAddressDetail.RequiredErrorMessage).Replace("%s", AlternativeAddressDetail.Caption));
                }
            }
            if (AlternativeAddressState.Required) {
                if (!AlternativeAddressState.IsDetailKey && Empty(AlternativeAddressState.FormValue)) {
                    AlternativeAddressState.AddErrorMessage(ConvertToString(AlternativeAddressState.RequiredErrorMessage).Replace("%s", AlternativeAddressState.Caption));
                }
            }
            if (AlternativeAddressCity.Required) {
                if (!AlternativeAddressCity.IsDetailKey && Empty(AlternativeAddressCity.FormValue)) {
                    AlternativeAddressCity.AddErrorMessage(ConvertToString(AlternativeAddressCity.RequiredErrorMessage).Replace("%s", AlternativeAddressCity.Caption));
                }
            }
            if (AlternativeAddressHomeTel.Required) {
                if (!AlternativeAddressHomeTel.IsDetailKey && Empty(AlternativeAddressHomeTel.FormValue)) {
                    AlternativeAddressHomeTel.AddErrorMessage(ConvertToString(AlternativeAddressHomeTel.RequiredErrorMessage).Replace("%s", AlternativeAddressHomeTel.Caption));
                }
            }
            if (AlternativeAddressPostCode.Required) {
                if (!AlternativeAddressPostCode.IsDetailKey && Empty(AlternativeAddressPostCode.FormValue)) {
                    AlternativeAddressPostCode.AddErrorMessage(ConvertToString(AlternativeAddressPostCode.RequiredErrorMessage).Replace("%s", AlternativeAddressPostCode.Caption));
                }
            }
            if (AlternativeAddressCountryID.Required) {
                if (!AlternativeAddressCountryID.IsDetailKey && Empty(AlternativeAddressCountryID.FormValue)) {
                    AlternativeAddressCountryID.AddErrorMessage(ConvertToString(AlternativeAddressCountryID.RequiredErrorMessage).Replace("%s", AlternativeAddressCountryID.Caption));
                }
            }
            if (MobileNumber.Required) {
                if (!MobileNumber.IsDetailKey && Empty(MobileNumber.FormValue)) {
                    MobileNumber.AddErrorMessage(ConvertToString(MobileNumber.RequiredErrorMessage).Replace("%s", MobileNumber.Caption));
                }
            }
            if (_Email.Required) {
                if (!_Email.IsDetailKey && Empty(_Email.FormValue)) {
                    _Email.AddErrorMessage(ConvertToString(_Email.RequiredErrorMessage).Replace("%s", _Email.Caption));
                }
            }
            if (!CheckEmail(_Email.FormValue)) {
                _Email.AddErrorMessage(_Email.GetErrorMessage(false));
            }
            if (SocialSecurityNumber.Required) {
                if (!SocialSecurityNumber.IsDetailKey && Empty(SocialSecurityNumber.FormValue)) {
                    SocialSecurityNumber.AddErrorMessage(ConvertToString(SocialSecurityNumber.RequiredErrorMessage).Replace("%s", SocialSecurityNumber.Caption));
                }
            }
            if (SocialSecurityIssuingCountryID.Required) {
                if (!SocialSecurityIssuingCountryID.IsDetailKey && Empty(SocialSecurityIssuingCountryID.FormValue)) {
                    SocialSecurityIssuingCountryID.AddErrorMessage(ConvertToString(SocialSecurityIssuingCountryID.RequiredErrorMessage).Replace("%s", SocialSecurityIssuingCountryID.Caption));
                }
            }
            if (SocialSecurityImage.Required) {
                if (SocialSecurityImage.Upload.FileName == "" && !SocialSecurityImage.Upload.KeepFile) {
                    SocialSecurityImage.AddErrorMessage(ConvertToString(SocialSecurityImage.RequiredErrorMessage).Replace("%s", SocialSecurityImage.Caption));
                }
            }
            if (PersonalTaxNumber.Required) {
                if (!PersonalTaxNumber.IsDetailKey && Empty(PersonalTaxNumber.FormValue)) {
                    PersonalTaxNumber.AddErrorMessage(ConvertToString(PersonalTaxNumber.RequiredErrorMessage).Replace("%s", PersonalTaxNumber.Caption));
                }
            }
            if (PersonalTaxIssuingCountryID.Required) {
                if (!PersonalTaxIssuingCountryID.IsDetailKey && Empty(PersonalTaxIssuingCountryID.FormValue)) {
                    PersonalTaxIssuingCountryID.AddErrorMessage(ConvertToString(PersonalTaxIssuingCountryID.RequiredErrorMessage).Replace("%s", PersonalTaxIssuingCountryID.Caption));
                }
            }
            if (PersonalTaxImage.Required) {
                if (PersonalTaxImage.Upload.FileName == "" && !PersonalTaxImage.Upload.KeepFile) {
                    PersonalTaxImage.AddErrorMessage(ConvertToString(PersonalTaxImage.RequiredErrorMessage).Replace("%s", PersonalTaxImage.Caption));
                }
            }
            if (Status.Required) {
                if (!Status.IsDetailKey && Empty(Status.FormValue)) {
                    Status.AddErrorMessage(ConvertToString(Status.RequiredErrorMessage).Replace("%s", Status.Caption));
                }
            }
            if (Reason.Required) {
                if (!Reason.IsDetailKey && Empty(Reason.FormValue)) {
                    Reason.AddErrorMessage(ConvertToString(Reason.RequiredErrorMessage).Replace("%s", Reason.Caption));
                }
            }
            if (Weight.Required) {
                if (!Weight.IsDetailKey && Empty(Weight.FormValue)) {
                    Weight.AddErrorMessage(ConvertToString(Weight.RequiredErrorMessage).Replace("%s", Weight.Caption));
                }
            }
            if (Height.Required) {
                if (!Height.IsDetailKey && Empty(Height.FormValue)) {
                    Height.AddErrorMessage(ConvertToString(Height.RequiredErrorMessage).Replace("%s", Height.Caption));
                }
            }
            if (CoverallSize.Required) {
                if (!CoverallSize.IsDetailKey && Empty(CoverallSize.FormValue)) {
                    CoverallSize.AddErrorMessage(ConvertToString(CoverallSize.RequiredErrorMessage).Replace("%s", CoverallSize.Caption));
                }
            }
            if (SafetyShoesSize.Required) {
                if (!SafetyShoesSize.IsDetailKey && Empty(SafetyShoesSize.FormValue)) {
                    SafetyShoesSize.AddErrorMessage(ConvertToString(SafetyShoesSize.RequiredErrorMessage).Replace("%s", SafetyShoesSize.Caption));
                }
            }
            if (ShirtSize.Required) {
                if (!ShirtSize.IsDetailKey && Empty(ShirtSize.FormValue)) {
                    ShirtSize.AddErrorMessage(ConvertToString(ShirtSize.RequiredErrorMessage).Replace("%s", ShirtSize.Caption));
                }
            }
            if (TrousersSize.Required) {
                if (!TrousersSize.IsDetailKey && Empty(TrousersSize.FormValue)) {
                    TrousersSize.AddErrorMessage(ConvertToString(TrousersSize.RequiredErrorMessage).Replace("%s", TrousersSize.Caption));
                }
            }
            if (NomineeFullName.Required) {
                if (!NomineeFullName.IsDetailKey && Empty(NomineeFullName.FormValue)) {
                    NomineeFullName.AddErrorMessage(ConvertToString(NomineeFullName.RequiredErrorMessage).Replace("%s", NomineeFullName.Caption));
                }
            }
            if (NomineeRelationship.Required) {
                if (!NomineeRelationship.IsDetailKey && Empty(NomineeRelationship.FormValue)) {
                    NomineeRelationship.AddErrorMessage(ConvertToString(NomineeRelationship.RequiredErrorMessage).Replace("%s", NomineeRelationship.Caption));
                }
            }
            if (NomineeGender.Required) {
                if (!NomineeGender.IsDetailKey && Empty(NomineeGender.FormValue)) {
                    NomineeGender.AddErrorMessage(ConvertToString(NomineeGender.RequiredErrorMessage).Replace("%s", NomineeGender.Caption));
                }
            }
            if (NomineeNationality_CountryID.Required) {
                if (!NomineeNationality_CountryID.IsDetailKey && Empty(NomineeNationality_CountryID.FormValue)) {
                    NomineeNationality_CountryID.AddErrorMessage(ConvertToString(NomineeNationality_CountryID.RequiredErrorMessage).Replace("%s", NomineeNationality_CountryID.Caption));
                }
            }
            if (NomineeAddressDetail.Required) {
                if (!NomineeAddressDetail.IsDetailKey && Empty(NomineeAddressDetail.FormValue)) {
                    NomineeAddressDetail.AddErrorMessage(ConvertToString(NomineeAddressDetail.RequiredErrorMessage).Replace("%s", NomineeAddressDetail.Caption));
                }
            }
            if (NomineeAddressCity.Required) {
                if (!NomineeAddressCity.IsDetailKey && Empty(NomineeAddressCity.FormValue)) {
                    NomineeAddressCity.AddErrorMessage(ConvertToString(NomineeAddressCity.RequiredErrorMessage).Replace("%s", NomineeAddressCity.Caption));
                }
            }
            if (NomineeAddressPostCode.Required) {
                if (!NomineeAddressPostCode.IsDetailKey && Empty(NomineeAddressPostCode.FormValue)) {
                    NomineeAddressPostCode.AddErrorMessage(ConvertToString(NomineeAddressPostCode.RequiredErrorMessage).Replace("%s", NomineeAddressPostCode.Caption));
                }
            }
            if (NomineeAddressCountryID.Required) {
                if (!NomineeAddressCountryID.IsDetailKey && Empty(NomineeAddressCountryID.FormValue)) {
                    NomineeAddressCountryID.AddErrorMessage(ConvertToString(NomineeAddressCountryID.RequiredErrorMessage).Replace("%s", NomineeAddressCountryID.Caption));
                }
            }
            if (NomineeAddressHomeTel.Required) {
                if (!NomineeAddressHomeTel.IsDetailKey && Empty(NomineeAddressHomeTel.FormValue)) {
                    NomineeAddressHomeTel.AddErrorMessage(ConvertToString(NomineeAddressHomeTel.RequiredErrorMessage).Replace("%s", NomineeAddressHomeTel.Caption));
                }
            }
            if (NomineeEmail.Required) {
                if (!NomineeEmail.IsDetailKey && Empty(NomineeEmail.FormValue)) {
                    NomineeEmail.AddErrorMessage(ConvertToString(NomineeEmail.RequiredErrorMessage).Replace("%s", NomineeEmail.Caption));
                }
            }
            if (!CheckEmail(NomineeEmail.FormValue)) {
                NomineeEmail.AddErrorMessage(NomineeEmail.GetErrorMessage(false));
            }
            if (NomineeMobileNumber.Required) {
                if (!NomineeMobileNumber.IsDetailKey && Empty(NomineeMobileNumber.FormValue)) {
                    NomineeMobileNumber.AddErrorMessage(ConvertToString(NomineeMobileNumber.RequiredErrorMessage).Replace("%s", NomineeMobileNumber.Caption));
                }
            }
            if (NSSF_Health_Number.Required) {
                if (!NSSF_Health_Number.IsDetailKey && Empty(NSSF_Health_Number.FormValue)) {
                    NSSF_Health_Number.AddErrorMessage(ConvertToString(NSSF_Health_Number.RequiredErrorMessage).Replace("%s", NSSF_Health_Number.Caption));
                }
            }
            if (NSSF_Occupation_Number.Required) {
                if (!NSSF_Occupation_Number.IsDetailKey && Empty(NSSF_Occupation_Number.FormValue)) {
                    NSSF_Occupation_Number.AddErrorMessage(ConvertToString(NSSF_Occupation_Number.RequiredErrorMessage).Replace("%s", NSSF_Occupation_Number.Caption));
                }
            }
            if (NomineeRelationshipSelect.Required) {
                if (!NomineeRelationshipSelect.IsDetailKey && Empty(NomineeRelationshipSelect.FormValue)) {
                    NomineeRelationshipSelect.AddErrorMessage(ConvertToString(NomineeRelationshipSelect.RequiredErrorMessage).Replace("%s", NomineeRelationshipSelect.Caption));
                }
            }
            if (NomineeRelationshipDetail.Required) {
                if (!NomineeRelationshipDetail.IsDetailKey && Empty(NomineeRelationshipDetail.FormValue)) {
                    NomineeRelationshipDetail.AddErrorMessage(ConvertToString(NomineeRelationshipDetail.RequiredErrorMessage).Replace("%s", NomineeRelationshipDetail.Caption));
                }
            }
            if (MobileNumberCode_CountryID.Required) {
                if (!MobileNumberCode_CountryID.IsDetailKey && Empty(MobileNumberCode_CountryID.FormValue)) {
                    MobileNumberCode_CountryID.AddErrorMessage(ConvertToString(MobileNumberCode_CountryID.RequiredErrorMessage).Replace("%s", MobileNumberCode_CountryID.Caption));
                }
            }
            if (PrimaryAddressHomeTelCode_CountryID.Required) {
                if (!PrimaryAddressHomeTelCode_CountryID.IsDetailKey && Empty(PrimaryAddressHomeTelCode_CountryID.FormValue)) {
                    PrimaryAddressHomeTelCode_CountryID.AddErrorMessage(ConvertToString(PrimaryAddressHomeTelCode_CountryID.RequiredErrorMessage).Replace("%s", PrimaryAddressHomeTelCode_CountryID.Caption));
                }
            }
            if (AlternativeAddressHomeTelCode_CountryID.Required) {
                if (!AlternativeAddressHomeTelCode_CountryID.IsDetailKey && Empty(AlternativeAddressHomeTelCode_CountryID.FormValue)) {
                    AlternativeAddressHomeTelCode_CountryID.AddErrorMessage(ConvertToString(AlternativeAddressHomeTelCode_CountryID.RequiredErrorMessage).Replace("%s", AlternativeAddressHomeTelCode_CountryID.Caption));
                }
            }
            if (NomineeAddressHomeTelCode_CountryID.Required) {
                if (!NomineeAddressHomeTelCode_CountryID.IsDetailKey && Empty(NomineeAddressHomeTelCode_CountryID.FormValue)) {
                    NomineeAddressHomeTelCode_CountryID.AddErrorMessage(ConvertToString(NomineeAddressHomeTelCode_CountryID.RequiredErrorMessage).Replace("%s", NomineeAddressHomeTelCode_CountryID.Caption));
                }
            }
            if (NomineeMobileNumberCode_CountryID.Required) {
                if (!NomineeMobileNumberCode_CountryID.IsDetailKey && Empty(NomineeMobileNumberCode_CountryID.FormValue)) {
                    NomineeMobileNumberCode_CountryID.AddErrorMessage(ConvertToString(NomineeMobileNumberCode_CountryID.RequiredErrorMessage).Replace("%s", NomineeMobileNumberCode_CountryID.Caption));
                }
            }
            if (MTManningAgentID.Required) {
                if (!MTManningAgentID.IsDetailKey && Empty(MTManningAgentID.FormValue)) {
                    MTManningAgentID.AddErrorMessage(ConvertToString(MTManningAgentID.RequiredErrorMessage).Replace("%s", MTManningAgentID.Caption));
                }
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
                RequiredPhoto.OldUploadPath = RequiredPhoto.GetUploadPath();
                RequiredPhoto.UploadPath = RequiredPhoto.OldUploadPath;
                VisaPhoto.OldUploadPath = VisaPhoto.GetUploadPath();
                VisaPhoto.UploadPath = VisaPhoto.OldUploadPath;
                SocialSecurityImage.OldUploadPath = SocialSecurityImage.GetUploadPath();
                SocialSecurityImage.UploadPath = SocialSecurityImage.OldUploadPath;
                PersonalTaxImage.OldUploadPath = PersonalTaxImage.GetUploadPath();
                PersonalTaxImage.UploadPath = PersonalTaxImage.OldUploadPath;
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }

            // Set new row
            Dictionary<string, object> rsnew = new ();

            // FullName
            FullName.SetDbValue(rsnew, FullName.CurrentValue, FullName.ReadOnly);

            // RequiredPhoto
            if (RequiredPhoto.Visible && !RequiredPhoto.ReadOnly && !RequiredPhoto.Upload.KeepFile) {
                RequiredPhoto.Upload.DbValue = rsold["RequiredPhoto"]; // Get original value
                if (Empty(RequiredPhoto.Upload.FileName)) {
                    rsnew["RequiredPhoto"] = DbNullValue;
                } else {
                    rsnew["RequiredPhoto"] = RequiredPhoto.Upload.FileName;
                }
            }

            // VisaPhoto
            if (VisaPhoto.Visible && !VisaPhoto.ReadOnly && !VisaPhoto.Upload.KeepFile) {
                VisaPhoto.Upload.DbValue = rsold["VisaPhoto"]; // Get original value
                if (Empty(VisaPhoto.Upload.FileName)) {
                    rsnew["VisaPhoto"] = DbNullValue;
                } else {
                    rsnew["VisaPhoto"] = VisaPhoto.Upload.FileName;
                }
            }

            // Nationality_CountryID
            Nationality_CountryID.SetDbValue(rsnew, Nationality_CountryID.CurrentValue, Nationality_CountryID.ReadOnly);

            // CountryOfOrigin_CountryID
            CountryOfOrigin_CountryID.SetDbValue(rsnew, CountryOfOrigin_CountryID.CurrentValue, CountryOfOrigin_CountryID.ReadOnly);

            // DateOfBirth
            DateOfBirth.SetDbValue(rsnew, ConvertToDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern), DateOfBirth.ReadOnly);

            // CityOfBirth
            CityOfBirth.SetDbValue(rsnew, CityOfBirth.CurrentValue, CityOfBirth.ReadOnly);

            // Gender
            Gender.SetDbValue(rsnew, Gender.CurrentValue, Gender.ReadOnly);

            // MaritalStatus
            MaritalStatus.SetDbValue(rsnew, MaritalStatus.CurrentValue, MaritalStatus.ReadOnly);

            // ReligionID
            ReligionID.SetDbValue(rsnew, ReligionID.CurrentValue, ReligionID.ReadOnly);

            // BloodType
            BloodType.SetDbValue(rsnew, BloodType.CurrentValue, BloodType.ReadOnly);

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.SetDbValue(rsnew, RankAppliedFor_RankID.CurrentValue, RankAppliedFor_RankID.ReadOnly);

            // WillAcceptLowRank
            WillAcceptLowRank.SetDbValue(rsnew, ConvertToBool(WillAcceptLowRank.CurrentValue), WillAcceptLowRank.ReadOnly);

            // AvailableFrom
            AvailableFrom.SetDbValue(rsnew, ConvertToDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern), AvailableFrom.ReadOnly);

            // AvailableUntil
            AvailableUntil.SetDbValue(rsnew, ConvertToDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern), AvailableUntil.ReadOnly);

            // PrimaryAddressDetail
            PrimaryAddressDetail.SetDbValue(rsnew, PrimaryAddressDetail.CurrentValue, PrimaryAddressDetail.ReadOnly);

            // PrimaryAddressCity
            PrimaryAddressCity.SetDbValue(rsnew, PrimaryAddressCity.CurrentValue, PrimaryAddressCity.ReadOnly);

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.SetDbValue(rsnew, PrimaryAddressNearestAirport.CurrentValue, PrimaryAddressNearestAirport.ReadOnly);

            // PrimaryAddressState
            PrimaryAddressState.SetDbValue(rsnew, PrimaryAddressState.CurrentValue, PrimaryAddressState.ReadOnly);

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.SetDbValue(rsnew, PrimaryAddressPostCode.CurrentValue, PrimaryAddressPostCode.ReadOnly);

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.SetDbValue(rsnew, PrimaryAddressCountryID.CurrentValue, PrimaryAddressCountryID.ReadOnly);

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.SetDbValue(rsnew, PrimaryAddressHomeTel.CurrentValue, PrimaryAddressHomeTel.ReadOnly);

            // AlternativeAddressDetail
            AlternativeAddressDetail.SetDbValue(rsnew, AlternativeAddressDetail.CurrentValue, AlternativeAddressDetail.ReadOnly);

            // AlternativeAddressState
            AlternativeAddressState.SetDbValue(rsnew, AlternativeAddressState.CurrentValue, AlternativeAddressState.ReadOnly);

            // AlternativeAddressCity
            AlternativeAddressCity.SetDbValue(rsnew, AlternativeAddressCity.CurrentValue, AlternativeAddressCity.ReadOnly);

            // AlternativeAddressHomeTel
            AlternativeAddressHomeTel.SetDbValue(rsnew, AlternativeAddressHomeTel.CurrentValue, AlternativeAddressHomeTel.ReadOnly);

            // AlternativeAddressPostCode
            AlternativeAddressPostCode.SetDbValue(rsnew, AlternativeAddressPostCode.CurrentValue, AlternativeAddressPostCode.ReadOnly);

            // AlternativeAddressCountryID
            AlternativeAddressCountryID.SetDbValue(rsnew, AlternativeAddressCountryID.CurrentValue, AlternativeAddressCountryID.ReadOnly);

            // MobileNumber
            MobileNumber.SetDbValue(rsnew, MobileNumber.CurrentValue, MobileNumber.ReadOnly);

            // Email
            _Email.SetDbValue(rsnew, _Email.CurrentValue, _Email.ReadOnly);

            // SocialSecurityNumber
            SocialSecurityNumber.SetDbValue(rsnew, SocialSecurityNumber.CurrentValue, SocialSecurityNumber.ReadOnly);

            // SocialSecurityIssuingCountryID
            SocialSecurityIssuingCountryID.SetDbValue(rsnew, SocialSecurityIssuingCountryID.CurrentValue, SocialSecurityIssuingCountryID.ReadOnly);

            // SocialSecurityImage
            if (SocialSecurityImage.Visible && !SocialSecurityImage.ReadOnly && !SocialSecurityImage.Upload.KeepFile) {
                SocialSecurityImage.Upload.DbValue = rsold["SocialSecurityImage"]; // Get original value
                if (Empty(SocialSecurityImage.Upload.FileName)) {
                    rsnew["SocialSecurityImage"] = DbNullValue;
                } else {
                    rsnew["SocialSecurityImage"] = SocialSecurityImage.Upload.FileName;
                }
            }

            // PersonalTaxNumber
            PersonalTaxNumber.SetDbValue(rsnew, PersonalTaxNumber.CurrentValue, PersonalTaxNumber.ReadOnly);

            // PersonalTaxIssuingCountryID
            PersonalTaxIssuingCountryID.SetDbValue(rsnew, PersonalTaxIssuingCountryID.CurrentValue, PersonalTaxIssuingCountryID.ReadOnly);

            // PersonalTaxImage
            if (PersonalTaxImage.Visible && !PersonalTaxImage.ReadOnly && !PersonalTaxImage.Upload.KeepFile) {
                PersonalTaxImage.Upload.DbValue = rsold["PersonalTaxImage"]; // Get original value
                if (Empty(PersonalTaxImage.Upload.FileName)) {
                    rsnew["PersonalTaxImage"] = DbNullValue;
                } else {
                    rsnew["PersonalTaxImage"] = PersonalTaxImage.Upload.FileName;
                }
            }

            // Status
            Status.SetDbValue(rsnew, Status.CurrentValue, Status.ReadOnly);

            // Reason
            Reason.SetDbValue(rsnew, Reason.CurrentValue, Reason.ReadOnly);

            // Weight
            Weight.SetDbValue(rsnew, Weight.CurrentValue, Weight.ReadOnly);

            // Height
            Height.SetDbValue(rsnew, Height.CurrentValue, Height.ReadOnly);

            // CoverallSize
            CoverallSize.SetDbValue(rsnew, CoverallSize.CurrentValue, CoverallSize.ReadOnly);

            // SafetyShoesSize
            SafetyShoesSize.SetDbValue(rsnew, SafetyShoesSize.CurrentValue, SafetyShoesSize.ReadOnly);

            // ShirtSize
            ShirtSize.SetDbValue(rsnew, ShirtSize.CurrentValue, ShirtSize.ReadOnly);

            // TrousersSize
            TrousersSize.SetDbValue(rsnew, TrousersSize.CurrentValue, TrousersSize.ReadOnly);

            // NomineeFullName
            NomineeFullName.SetDbValue(rsnew, NomineeFullName.CurrentValue, NomineeFullName.ReadOnly);

            // NomineeRelationship
            NomineeRelationship.SetDbValue(rsnew, NomineeRelationship.CurrentValue, NomineeRelationship.ReadOnly);

            // NomineeGender
            NomineeGender.SetDbValue(rsnew, NomineeGender.CurrentValue, NomineeGender.ReadOnly);

            // NomineeNationality_CountryID
            NomineeNationality_CountryID.SetDbValue(rsnew, NomineeNationality_CountryID.CurrentValue, NomineeNationality_CountryID.ReadOnly);

            // NomineeAddressDetail
            NomineeAddressDetail.SetDbValue(rsnew, NomineeAddressDetail.CurrentValue, NomineeAddressDetail.ReadOnly);

            // NomineeAddressCity
            NomineeAddressCity.SetDbValue(rsnew, NomineeAddressCity.CurrentValue, NomineeAddressCity.ReadOnly);

            // NomineeAddressPostCode
            NomineeAddressPostCode.SetDbValue(rsnew, NomineeAddressPostCode.CurrentValue, NomineeAddressPostCode.ReadOnly);

            // NomineeAddressCountryID
            NomineeAddressCountryID.SetDbValue(rsnew, NomineeAddressCountryID.CurrentValue, NomineeAddressCountryID.ReadOnly);

            // NomineeAddressHomeTel
            NomineeAddressHomeTel.SetDbValue(rsnew, NomineeAddressHomeTel.CurrentValue, NomineeAddressHomeTel.ReadOnly);

            // NomineeEmail
            NomineeEmail.SetDbValue(rsnew, NomineeEmail.CurrentValue, NomineeEmail.ReadOnly);

            // NomineeMobileNumber
            NomineeMobileNumber.SetDbValue(rsnew, NomineeMobileNumber.CurrentValue, NomineeMobileNumber.ReadOnly);

            // NSSF_Health_Number
            NSSF_Health_Number.SetDbValue(rsnew, NSSF_Health_Number.CurrentValue, NSSF_Health_Number.ReadOnly);

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.SetDbValue(rsnew, NSSF_Occupation_Number.CurrentValue, NSSF_Occupation_Number.ReadOnly);

            // NomineeRelationshipSelect
            NomineeRelationshipSelect.SetDbValue(rsnew, NomineeRelationshipSelect.CurrentValue, NomineeRelationshipSelect.ReadOnly);

            // NomineeRelationshipDetail
            NomineeRelationshipDetail.SetDbValue(rsnew, NomineeRelationshipDetail.CurrentValue, NomineeRelationshipDetail.ReadOnly);

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.SetDbValue(rsnew, MobileNumberCode_CountryID.CurrentValue, MobileNumberCode_CountryID.ReadOnly);

            // PrimaryAddressHomeTelCode_CountryID
            PrimaryAddressHomeTelCode_CountryID.SetDbValue(rsnew, PrimaryAddressHomeTelCode_CountryID.CurrentValue, PrimaryAddressHomeTelCode_CountryID.ReadOnly);

            // AlternativeAddressHomeTelCode_CountryID
            AlternativeAddressHomeTelCode_CountryID.SetDbValue(rsnew, AlternativeAddressHomeTelCode_CountryID.CurrentValue, AlternativeAddressHomeTelCode_CountryID.ReadOnly);

            // NomineeAddressHomeTelCode_CountryID
            NomineeAddressHomeTelCode_CountryID.SetDbValue(rsnew, NomineeAddressHomeTelCode_CountryID.CurrentValue, NomineeAddressHomeTelCode_CountryID.ReadOnly);

            // NomineeMobileNumberCode_CountryID
            NomineeMobileNumberCode_CountryID.SetDbValue(rsnew, NomineeMobileNumberCode_CountryID.CurrentValue, NomineeMobileNumberCode_CountryID.ReadOnly);

            // MTManningAgentID
            MTManningAgentID.SetDbValue(rsnew, MTManningAgentID.CurrentValue, MTManningAgentID.ReadOnly);

            // Update current values
            SetCurrentValues(rsnew);

            // Check field with unique index (IndividualCodeNumber)
            if (!Empty(IndividualCodeNumber.CurrentValue)) {
                string filterChk = "(dbo.MTCrew.IndividualCodeNumber = '" + AdjustSql(IndividualCodeNumber.CurrentValue, DbId) + "')";
                filterChk = filterChk + " AND NOT (" + filter + ")";
                try {
                    using var rschk = await LoadReader(filterChk);
                    if (rschk?.HasRows ?? false) {
                        var idxErrMsg = Language.Phrase("DupIndex").Replace("%f", IndividualCodeNumber.Caption);
                        idxErrMsg = idxErrMsg.Replace("%v", ConvertToString(IndividualCodeNumber.CurrentValue));
                        FailureMessage = idxErrMsg;
                        return JsonBoolResult.FalseResult;
                    }
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    return JsonBoolResult.FalseResult;
                }
            }

            // Check field with unique index (Email)
            if (!Empty(_Email.CurrentValue)) {
                string filterChk = "(dbo.MTCrew.Email = '" + AdjustSql(_Email.CurrentValue, DbId) + "')";
                filterChk = filterChk + " AND NOT (" + filter + ")";
                try {
                    using var rschk = await LoadReader(filterChk);
                    if (rschk?.HasRows ?? false) {
                        var idxErrMsg = Language.Phrase("DupIndex").Replace("%f", _Email.Caption);
                        idxErrMsg = idxErrMsg.Replace("%v", ConvertToString(_Email.CurrentValue));
                        FailureMessage = idxErrMsg;
                        return JsonBoolResult.FalseResult;
                    }
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    return JsonBoolResult.FalseResult;
                }
            }
            if (RequiredPhoto.Visible && !RequiredPhoto.Upload.KeepFile) {
                RequiredPhoto.UploadPath = RequiredPhoto.GetUploadPath();
                List<string> oldFiles = Empty(RequiredPhoto.Upload.DbValue) ? new () : new () { RequiredPhoto.HtmlDecode(RequiredPhoto.Upload.DbValue) };
                if (!Empty(RequiredPhoto.Upload.FileName)) {
                    var newFiles = new string[] { RequiredPhoto.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(RequiredPhoto, RequiredPhoto.Upload.Index);
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
                                var folders = new[] { RequiredPhoto.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(RequiredPhoto.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(RequiredPhoto.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    RequiredPhoto.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    RequiredPhoto.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    RequiredPhoto.SetDbValue(rsnew, RequiredPhoto.Upload.FileName, RequiredPhoto.ReadOnly);
                }
            }
            if (VisaPhoto.Visible && !VisaPhoto.Upload.KeepFile) {
                VisaPhoto.UploadPath = VisaPhoto.GetUploadPath();
                List<string> oldFiles = Empty(VisaPhoto.Upload.DbValue) ? new () : new () { VisaPhoto.HtmlDecode(VisaPhoto.Upload.DbValue) };
                if (!Empty(VisaPhoto.Upload.FileName)) {
                    var newFiles = new string[] { VisaPhoto.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(VisaPhoto, VisaPhoto.Upload.Index);
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
                                var folders = new[] { VisaPhoto.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(VisaPhoto.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(VisaPhoto.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    VisaPhoto.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    VisaPhoto.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    VisaPhoto.SetDbValue(rsnew, VisaPhoto.Upload.FileName, VisaPhoto.ReadOnly);
                }
            }
            if (SocialSecurityImage.Visible && !SocialSecurityImage.Upload.KeepFile) {
                SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
                List<string> oldFiles = Empty(SocialSecurityImage.Upload.DbValue) ? new () : new () { SocialSecurityImage.HtmlDecode(SocialSecurityImage.Upload.DbValue) };
                if (!Empty(SocialSecurityImage.Upload.FileName)) {
                    var newFiles = new string[] { SocialSecurityImage.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(SocialSecurityImage, SocialSecurityImage.Upload.Index);
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
                                var folders = new[] { SocialSecurityImage.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(SocialSecurityImage.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(SocialSecurityImage.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    SocialSecurityImage.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    SocialSecurityImage.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    SocialSecurityImage.SetDbValue(rsnew, SocialSecurityImage.Upload.FileName, SocialSecurityImage.ReadOnly);
                }
            }
            if (PersonalTaxImage.Visible && !PersonalTaxImage.Upload.KeepFile) {
                PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
                List<string> oldFiles = Empty(PersonalTaxImage.Upload.DbValue) ? new () : new () { PersonalTaxImage.HtmlDecode(PersonalTaxImage.Upload.DbValue) };
                if (!Empty(PersonalTaxImage.Upload.FileName)) {
                    var newFiles = new string[] { PersonalTaxImage.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(PersonalTaxImage, PersonalTaxImage.Upload.Index);
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
                                var folders = new[] { PersonalTaxImage.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(PersonalTaxImage.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(PersonalTaxImage.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    PersonalTaxImage.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    PersonalTaxImage.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    PersonalTaxImage.SetDbValue(rsnew, PersonalTaxImage.Upload.FileName, PersonalTaxImage.ReadOnly);
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
                        if (RequiredPhoto.Visible && !RequiredPhoto.Upload.KeepFile) {
                            var newFiles = new string[] {};
                            var oldFiles = Empty(RequiredPhoto.Upload.DbValue) ? new string[] {} : new string[] { RequiredPhoto.HtmlDecode(RequiredPhoto.Upload.DbValue) };
                            if (!Empty(RequiredPhoto.Upload.FileName)) {
                                newFiles = new string[] { RequiredPhoto.Upload.FileName };
                                var newFiles2 = new string[] { RequiredPhoto.HtmlDecode(ConvertToString(rsnew["RequiredPhoto"])) };
                                for (var i = 0; i < newFiles.Length; i++) {
                                    if (!Empty(newFiles[i])) {
                                        var file = UploadTempPath(RequiredPhoto, RequiredPhoto.Upload.Index) + newFiles[i];
                                        if (FileExists(file)) {
                                            if (!Empty(newFiles2[i])) // Use correct file name
                                                newFiles[i] = newFiles2[i];
                                            if (!await RequiredPhoto.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                        DeleteFile(RequiredPhoto.OldPhysicalUploadPath + oldFiles[i]);
                                }
                            }
                        }
                        if (VisaPhoto.Visible && !VisaPhoto.Upload.KeepFile) {
                            var newFiles = new string[] {};
                            var oldFiles = Empty(VisaPhoto.Upload.DbValue) ? new string[] {} : new string[] { VisaPhoto.HtmlDecode(VisaPhoto.Upload.DbValue) };
                            if (!Empty(VisaPhoto.Upload.FileName)) {
                                newFiles = new string[] { VisaPhoto.Upload.FileName };
                                var newFiles2 = new string[] { VisaPhoto.HtmlDecode(ConvertToString(rsnew["VisaPhoto"])) };
                                for (var i = 0; i < newFiles.Length; i++) {
                                    if (!Empty(newFiles[i])) {
                                        var file = UploadTempPath(VisaPhoto, VisaPhoto.Upload.Index) + newFiles[i];
                                        if (FileExists(file)) {
                                            if (!Empty(newFiles2[i])) // Use correct file name
                                                newFiles[i] = newFiles2[i];
                                            if (!await VisaPhoto.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                        DeleteFile(VisaPhoto.OldPhysicalUploadPath + oldFiles[i]);
                                }
                            }
                        }
                        if (SocialSecurityImage.Visible && !SocialSecurityImage.Upload.KeepFile) {
                            var newFiles = new string[] {};
                            var oldFiles = Empty(SocialSecurityImage.Upload.DbValue) ? new string[] {} : new string[] { SocialSecurityImage.HtmlDecode(SocialSecurityImage.Upload.DbValue) };
                            if (!Empty(SocialSecurityImage.Upload.FileName)) {
                                newFiles = new string[] { SocialSecurityImage.Upload.FileName };
                                var newFiles2 = new string[] { SocialSecurityImage.HtmlDecode(ConvertToString(rsnew["SocialSecurityImage"])) };
                                for (var i = 0; i < newFiles.Length; i++) {
                                    if (!Empty(newFiles[i])) {
                                        var file = UploadTempPath(SocialSecurityImage, SocialSecurityImage.Upload.Index) + newFiles[i];
                                        if (FileExists(file)) {
                                            if (!Empty(newFiles2[i])) // Use correct file name
                                                newFiles[i] = newFiles2[i];
                                            if (!await SocialSecurityImage.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                        DeleteFile(SocialSecurityImage.OldPhysicalUploadPath + oldFiles[i]);
                                }
                            }
                        }
                        if (PersonalTaxImage.Visible && !PersonalTaxImage.Upload.KeepFile) {
                            var newFiles = new string[] {};
                            var oldFiles = Empty(PersonalTaxImage.Upload.DbValue) ? new string[] {} : new string[] { PersonalTaxImage.HtmlDecode(PersonalTaxImage.Upload.DbValue) };
                            if (!Empty(PersonalTaxImage.Upload.FileName)) {
                                newFiles = new string[] { PersonalTaxImage.Upload.FileName };
                                var newFiles2 = new string[] { PersonalTaxImage.HtmlDecode(ConvertToString(rsnew["PersonalTaxImage"])) };
                                for (var i = 0; i < newFiles.Length; i++) {
                                    if (!Empty(newFiles[i])) {
                                        var file = UploadTempPath(PersonalTaxImage, PersonalTaxImage.Upload.Index) + newFiles[i];
                                        if (FileExists(file)) {
                                            if (!Empty(newFiles2[i])) // Use correct file name
                                                newFiles[i] = newFiles2[i];
                                            if (!await PersonalTaxImage.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                        DeleteFile(PersonalTaxImage.OldPhysicalUploadPath + oldFiles[i]);
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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("CrewPersonalDataForAdminList")), "", TableVar, true);
            string pageId = "edit";
            breadcrumb.Add("edit", pageId, url);
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

        // Form Custom Validate event
        public virtual bool FormCustomValidate(ref string customError) {
            //Return error message in customError
            return true;
        }
    } // End page class
} // End Partial class
