namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewPersonalDataForAdminViewModeSearch
    /// </summary>
    public static CrewPersonalDataForAdminViewModeSearch crewPersonalDataForAdminViewModeSearch
    {
        get => HttpData.Get<CrewPersonalDataForAdminViewModeSearch>("crewPersonalDataForAdminViewModeSearch")!;
        set => HttpData["crewPersonalDataForAdminViewModeSearch"] = value;
    }

    /// <summary>
    /// Page class for CrewPersonalDataForAdminViewMode
    /// </summary>
    public class CrewPersonalDataForAdminViewModeSearch : CrewPersonalDataForAdminViewModeSearchBase
    {
        // Constructor
        public CrewPersonalDataForAdminViewModeSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public CrewPersonalDataForAdminViewModeSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class CrewPersonalDataForAdminViewModeSearchBase : CrewPersonalDataForAdminViewMode
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "CrewPersonalDataForAdminViewMode";

        // Page object name
        public string PageObjName = "crewPersonalDataForAdminViewModeSearch";

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
        public CrewPersonalDataForAdminViewModeSearchBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (crewPersonalDataForAdminViewMode)
            if (crewPersonalDataForAdminViewMode == null || crewPersonalDataForAdminViewMode is CrewPersonalDataForAdminViewMode)
                crewPersonalDataForAdminViewMode = this;

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
        public string PageName => "CrewPersonalDataForAdminViewModeSearch";

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
            Nationality_CountryID.SetVisibility();
            CountryOfOrigin_CountryID.SetVisibility();
            DateOfBirth.SetVisibility();
            CityOfBirth.SetVisibility();
            Gender.SetVisibility();
            MaritalStatus.SetVisibility();
            ReligionID.SetVisibility();
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
            EmployeeStatus.SetVisibility();
            FormSubmittedDateTime.SetVisibility();
            ActiveDescription.Visible = false;
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            MTUserID.Visible = false;
            SocialSecurityNumber.SetVisibility();
            SocialSecurityIssuingCountryID.SetVisibility();
            SocialSecurityImage.SetVisibility();
            PersonalTaxNumber.SetVisibility();
            PersonalTaxIssuingCountryID.SetVisibility();
            PersonalTaxImage.SetVisibility();
            BloodType.SetVisibility();
            RequiredPhoto.SetVisibility();
            VisaPhoto.SetVisibility();
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
            NomineeRelationshipSelect.SetVisibility();
            NomineeRelationshipDetail.SetVisibility();
            MobileNumberCode_CountryID.Visible = false;
            PrimaryAddressHomeTelCode_CountryID.Visible = false;
            AlternativeAddressHomeTelCode_CountryID.Visible = false;
            NomineeAddressHomeTelCode_CountryID.Visible = false;
            NomineeMobileNumberCode_CountryID.Visible = false;
        }

        // Constructor
        public CrewPersonalDataForAdminViewModeSearchBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "CrewPersonalDataForAdminViewModeView" ? "1" : "0"); // If View page, no primary button
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
                SocialSecurityImage.OldUploadPath = SocialSecurityImage.GetUploadPath();
                SocialSecurityImage.UploadPath = SocialSecurityImage.OldUploadPath;
                PersonalTaxImage.OldUploadPath = PersonalTaxImage.GetUploadPath();
                PersonalTaxImage.UploadPath = PersonalTaxImage.OldUploadPath;
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
            await SetupLookupOptions(Nationality_CountryID);
            await SetupLookupOptions(CountryOfOrigin_CountryID);
            await SetupLookupOptions(Gender);
            await SetupLookupOptions(MaritalStatus);
            await SetupLookupOptions(ReligionID);
            await SetupLookupOptions(RankAppliedFor_RankID);
            await SetupLookupOptions(WillAcceptLowRank);
            await SetupLookupOptions(PrimaryAddressCountryID);
            await SetupLookupOptions(AlternativeAddressCountryID);
            await SetupLookupOptions(SocialSecurityIssuingCountryID);
            await SetupLookupOptions(PersonalTaxIssuingCountryID);
            await SetupLookupOptions(BloodType);
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
                    srchStr = "CrewPersonalDataForAdminViewModeList?" + srchStr;
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
                crewPersonalDataForAdminViewModeSearch?.PageRender();
            }
            return PageResult();
        }

        // Build advanced search
        protected string BuildAdvancedSearch() {
            string srchUrl = "";
            BuildSearchUrl(ref srchUrl, IndividualCodeNumber); // IndividualCodeNumber
            BuildSearchUrl(ref srchUrl, FullName); // FullName
            BuildSearchUrl(ref srchUrl, Nationality_CountryID); // Nationality_CountryID
            BuildSearchUrl(ref srchUrl, CountryOfOrigin_CountryID); // CountryOfOrigin_CountryID
            BuildSearchUrl(ref srchUrl, DateOfBirth); // DateOfBirth
            BuildSearchUrl(ref srchUrl, CityOfBirth); // CityOfBirth
            BuildSearchUrl(ref srchUrl, Gender); // Gender
            BuildSearchUrl(ref srchUrl, MaritalStatus); // MaritalStatus
            BuildSearchUrl(ref srchUrl, ReligionID); // ReligionID
            BuildSearchUrl(ref srchUrl, RankAppliedFor_RankID); // RankAppliedFor_RankID
            BuildSearchUrl(ref srchUrl, WillAcceptLowRank, true); // WillAcceptLowRank
            BuildSearchUrl(ref srchUrl, AvailableFrom); // AvailableFrom
            BuildSearchUrl(ref srchUrl, AvailableUntil); // AvailableUntil
            BuildSearchUrl(ref srchUrl, PrimaryAddressDetail); // PrimaryAddressDetail
            BuildSearchUrl(ref srchUrl, PrimaryAddressCity); // PrimaryAddressCity
            BuildSearchUrl(ref srchUrl, PrimaryAddressNearestAirport); // PrimaryAddressNearestAirport
            BuildSearchUrl(ref srchUrl, PrimaryAddressState); // PrimaryAddressState
            BuildSearchUrl(ref srchUrl, PrimaryAddressPostCode); // PrimaryAddressPostCode
            BuildSearchUrl(ref srchUrl, PrimaryAddressCountryID); // PrimaryAddressCountryID
            BuildSearchUrl(ref srchUrl, PrimaryAddressHomeTel); // PrimaryAddressHomeTel
            BuildSearchUrl(ref srchUrl, AlternativeAddressDetail); // AlternativeAddressDetail
            BuildSearchUrl(ref srchUrl, AlternativeAddressState); // AlternativeAddressState
            BuildSearchUrl(ref srchUrl, AlternativeAddressCity); // AlternativeAddressCity
            BuildSearchUrl(ref srchUrl, AlternativeAddressHomeTel); // AlternativeAddressHomeTel
            BuildSearchUrl(ref srchUrl, AlternativeAddressPostCode); // AlternativeAddressPostCode
            BuildSearchUrl(ref srchUrl, AlternativeAddressCountryID); // AlternativeAddressCountryID
            BuildSearchUrl(ref srchUrl, MobileNumber); // MobileNumber
            BuildSearchUrl(ref srchUrl, _Email); // Email
            BuildSearchUrl(ref srchUrl, EmployeeStatus); // EmployeeStatus
            BuildSearchUrl(ref srchUrl, FormSubmittedDateTime); // FormSubmittedDateTime
            BuildSearchUrl(ref srchUrl, CreatedByUserID); // CreatedByUserID
            BuildSearchUrl(ref srchUrl, CreatedDateTime); // CreatedDateTime
            BuildSearchUrl(ref srchUrl, LastUpdatedByUserID); // LastUpdatedByUserID
            BuildSearchUrl(ref srchUrl, LastUpdatedDateTime); // LastUpdatedDateTime
            BuildSearchUrl(ref srchUrl, SocialSecurityNumber); // SocialSecurityNumber
            BuildSearchUrl(ref srchUrl, SocialSecurityIssuingCountryID); // SocialSecurityIssuingCountryID
            BuildSearchUrl(ref srchUrl, SocialSecurityImage); // SocialSecurityImage
            BuildSearchUrl(ref srchUrl, PersonalTaxNumber); // PersonalTaxNumber
            BuildSearchUrl(ref srchUrl, PersonalTaxIssuingCountryID); // PersonalTaxIssuingCountryID
            BuildSearchUrl(ref srchUrl, PersonalTaxImage); // PersonalTaxImage
            BuildSearchUrl(ref srchUrl, BloodType); // BloodType
            BuildSearchUrl(ref srchUrl, RequiredPhoto); // RequiredPhoto
            BuildSearchUrl(ref srchUrl, VisaPhoto); // VisaPhoto
            BuildSearchUrl(ref srchUrl, NomineeRelationshipSelect); // NomineeRelationshipSelect
            BuildSearchUrl(ref srchUrl, NomineeRelationshipDetail); // NomineeRelationshipDetail
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

            // Nationality_CountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Nationality_CountryID"))
                    Nationality_CountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Nationality_CountryID");
            if (Form.ContainsKey("z_Nationality_CountryID"))
                Nationality_CountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Nationality_CountryID");

            // CountryOfOrigin_CountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CountryOfOrigin_CountryID"))
                    CountryOfOrigin_CountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CountryOfOrigin_CountryID");
            if (Form.ContainsKey("z_CountryOfOrigin_CountryID"))
                CountryOfOrigin_CountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CountryOfOrigin_CountryID");

            // DateOfBirth
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_DateOfBirth"))
                    DateOfBirth.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_DateOfBirth");
            if (Form.ContainsKey("z_DateOfBirth"))
                DateOfBirth.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_DateOfBirth");

            // CityOfBirth
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CityOfBirth"))
                    CityOfBirth.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CityOfBirth");
            if (Form.ContainsKey("z_CityOfBirth"))
                CityOfBirth.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CityOfBirth");

            // Gender
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Gender"))
                    Gender.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Gender");
            if (Form.ContainsKey("z_Gender"))
                Gender.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Gender");

            // MaritalStatus
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MaritalStatus"))
                    MaritalStatus.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MaritalStatus");
            if (Form.ContainsKey("z_MaritalStatus"))
                MaritalStatus.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MaritalStatus");

            // ReligionID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ReligionID"))
                    ReligionID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ReligionID");
            if (Form.ContainsKey("z_ReligionID"))
                ReligionID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ReligionID");

            // RankAppliedFor_RankID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_RankAppliedFor_RankID"))
                    RankAppliedFor_RankID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_RankAppliedFor_RankID");
            if (Form.ContainsKey("z_RankAppliedFor_RankID"))
                RankAppliedFor_RankID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_RankAppliedFor_RankID");

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

            // PrimaryAddressDetail
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressDetail"))
                    PrimaryAddressDetail.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressDetail");
            if (Form.ContainsKey("z_PrimaryAddressDetail"))
                PrimaryAddressDetail.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressDetail");

            // PrimaryAddressCity
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressCity"))
                    PrimaryAddressCity.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressCity");
            if (Form.ContainsKey("z_PrimaryAddressCity"))
                PrimaryAddressCity.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressCity");

            // PrimaryAddressNearestAirport
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressNearestAirport"))
                    PrimaryAddressNearestAirport.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressNearestAirport");
            if (Form.ContainsKey("z_PrimaryAddressNearestAirport"))
                PrimaryAddressNearestAirport.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressNearestAirport");

            // PrimaryAddressState
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressState"))
                    PrimaryAddressState.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressState");
            if (Form.ContainsKey("z_PrimaryAddressState"))
                PrimaryAddressState.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressState");

            // PrimaryAddressPostCode
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressPostCode"))
                    PrimaryAddressPostCode.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressPostCode");
            if (Form.ContainsKey("z_PrimaryAddressPostCode"))
                PrimaryAddressPostCode.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressPostCode");

            // PrimaryAddressCountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressCountryID"))
                    PrimaryAddressCountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressCountryID");
            if (Form.ContainsKey("z_PrimaryAddressCountryID"))
                PrimaryAddressCountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressCountryID");

            // PrimaryAddressHomeTel
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressHomeTel"))
                    PrimaryAddressHomeTel.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressHomeTel");
            if (Form.ContainsKey("z_PrimaryAddressHomeTel"))
                PrimaryAddressHomeTel.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressHomeTel");

            // AlternativeAddressDetail
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AlternativeAddressDetail"))
                    AlternativeAddressDetail.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AlternativeAddressDetail");
            if (Form.ContainsKey("z_AlternativeAddressDetail"))
                AlternativeAddressDetail.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AlternativeAddressDetail");

            // AlternativeAddressState
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AlternativeAddressState"))
                    AlternativeAddressState.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AlternativeAddressState");
            if (Form.ContainsKey("z_AlternativeAddressState"))
                AlternativeAddressState.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AlternativeAddressState");

            // AlternativeAddressCity
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AlternativeAddressCity"))
                    AlternativeAddressCity.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AlternativeAddressCity");
            if (Form.ContainsKey("z_AlternativeAddressCity"))
                AlternativeAddressCity.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AlternativeAddressCity");

            // AlternativeAddressHomeTel
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AlternativeAddressHomeTel"))
                    AlternativeAddressHomeTel.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AlternativeAddressHomeTel");
            if (Form.ContainsKey("z_AlternativeAddressHomeTel"))
                AlternativeAddressHomeTel.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AlternativeAddressHomeTel");

            // AlternativeAddressPostCode
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AlternativeAddressPostCode"))
                    AlternativeAddressPostCode.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AlternativeAddressPostCode");
            if (Form.ContainsKey("z_AlternativeAddressPostCode"))
                AlternativeAddressPostCode.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AlternativeAddressPostCode");

            // AlternativeAddressCountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AlternativeAddressCountryID"))
                    AlternativeAddressCountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AlternativeAddressCountryID");
            if (Form.ContainsKey("z_AlternativeAddressCountryID"))
                AlternativeAddressCountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AlternativeAddressCountryID");

            // MobileNumber
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MobileNumber"))
                    MobileNumber.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MobileNumber");
            if (Form.ContainsKey("z_MobileNumber"))
                MobileNumber.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MobileNumber");

            // _Email
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x__Email"))
                    _Email.AdvancedSearch.SearchValue = CurrentForm.GetValue("x__Email");
            if (Form.ContainsKey("z__Email"))
                _Email.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z__Email");

            // EmployeeStatus
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_EmployeeStatus"))
                    EmployeeStatus.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_EmployeeStatus");
            if (Form.ContainsKey("z_EmployeeStatus"))
                EmployeeStatus.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_EmployeeStatus");

            // FormSubmittedDateTime
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_FormSubmittedDateTime"))
                    FormSubmittedDateTime.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_FormSubmittedDateTime");
            if (Form.ContainsKey("z_FormSubmittedDateTime"))
                FormSubmittedDateTime.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_FormSubmittedDateTime");

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

            // SocialSecurityNumber
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_SocialSecurityNumber"))
                    SocialSecurityNumber.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_SocialSecurityNumber");
            if (Form.ContainsKey("z_SocialSecurityNumber"))
                SocialSecurityNumber.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_SocialSecurityNumber");

            // SocialSecurityIssuingCountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_SocialSecurityIssuingCountryID"))
                    SocialSecurityIssuingCountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_SocialSecurityIssuingCountryID");
            if (Form.ContainsKey("z_SocialSecurityIssuingCountryID"))
                SocialSecurityIssuingCountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_SocialSecurityIssuingCountryID");

            // SocialSecurityImage
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_SocialSecurityImage"))
                    SocialSecurityImage.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_SocialSecurityImage");
            if (Form.ContainsKey("z_SocialSecurityImage"))
                SocialSecurityImage.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_SocialSecurityImage");

            // PersonalTaxNumber
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PersonalTaxNumber"))
                    PersonalTaxNumber.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PersonalTaxNumber");
            if (Form.ContainsKey("z_PersonalTaxNumber"))
                PersonalTaxNumber.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PersonalTaxNumber");

            // PersonalTaxIssuingCountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PersonalTaxIssuingCountryID"))
                    PersonalTaxIssuingCountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PersonalTaxIssuingCountryID");
            if (Form.ContainsKey("z_PersonalTaxIssuingCountryID"))
                PersonalTaxIssuingCountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PersonalTaxIssuingCountryID");

            // PersonalTaxImage
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PersonalTaxImage"))
                    PersonalTaxImage.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PersonalTaxImage");
            if (Form.ContainsKey("z_PersonalTaxImage"))
                PersonalTaxImage.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PersonalTaxImage");

            // BloodType
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_BloodType"))
                    BloodType.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_BloodType");
            if (Form.ContainsKey("z_BloodType"))
                BloodType.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_BloodType");

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

            // NomineeRelationshipSelect
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeRelationshipSelect"))
                    NomineeRelationshipSelect.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeRelationshipSelect");
            if (Form.ContainsKey("z_NomineeRelationshipSelect"))
                NomineeRelationshipSelect.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeRelationshipSelect");

            // NomineeRelationshipDetail
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeRelationshipDetail"))
                    NomineeRelationshipDetail.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeRelationshipDetail");
            if (Form.ContainsKey("z_NomineeRelationshipDetail"))
                NomineeRelationshipDetail.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeRelationshipDetail");
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
            Nationality_CountryID.SetDbValue(row["Nationality_CountryID"]);
            CountryOfOrigin_CountryID.SetDbValue(row["CountryOfOrigin_CountryID"]);
            DateOfBirth.SetDbValue(row["DateOfBirth"]);
            CityOfBirth.SetDbValue(row["CityOfBirth"]);
            Gender.SetDbValue(row["Gender"]);
            MaritalStatus.SetDbValue(row["MaritalStatus"]);
            ReligionID.SetDbValue(row["ReligionID"]);
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
            BloodType.SetDbValue(row["BloodType"]);
            RequiredPhoto.Upload.DbValue = row["RequiredPhoto"];
            RequiredPhoto.SetDbValue(RequiredPhoto.Upload.DbValue);
            VisaPhoto.Upload.DbValue = row["VisaPhoto"];
            VisaPhoto.SetDbValue(VisaPhoto.Upload.DbValue);
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
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("IndividualCodeNumber", IndividualCodeNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("Nationality_CountryID", Nationality_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("CountryOfOrigin_CountryID", CountryOfOrigin_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("DateOfBirth", DateOfBirth.DefaultValue ?? DbNullValue); // DN
            row.Add("CityOfBirth", CityOfBirth.DefaultValue ?? DbNullValue); // DN
            row.Add("Gender", Gender.DefaultValue ?? DbNullValue); // DN
            row.Add("MaritalStatus", MaritalStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("ReligionID", ReligionID.DefaultValue ?? DbNullValue); // DN
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
            row.Add("BloodType", BloodType.DefaultValue ?? DbNullValue); // DN
            row.Add("RequiredPhoto", RequiredPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("VisaPhoto", VisaPhoto.DefaultValue ?? DbNullValue); // DN
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

            // BloodType
            BloodType.RowCssClass = "row";

            // RequiredPhoto
            RequiredPhoto.RowCssClass = "row";

            // VisaPhoto
            VisaPhoto.RowCssClass = "row";

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

            // View row
            if (RowType == RowType.View) {
                // IndividualCodeNumber
                IndividualCodeNumber.ViewValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
                IndividualCodeNumber.ViewCustomAttributes = "";

                // FullName
                FullName.ViewValue = ConvertToString(FullName.CurrentValue); // DN
                FullName.ViewCustomAttributes = "";

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

                // BloodType
                if (!Empty(BloodType.CurrentValue)) {
                    BloodType.ViewValue = BloodType.HighlightLookup(ConvertToString(BloodType.CurrentValue), BloodType.OptionCaption(ConvertToString(BloodType.CurrentValue)));
                } else {
                    BloodType.ViewValue = DbNullValue;
                }
                BloodType.ViewCustomAttributes = "";

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

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";
                IndividualCodeNumber.TooltipValue = "";

                // FullName
                FullName.HrefValue = "";
                FullName.TooltipValue = "";

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

                // WillAcceptLowRank
                WillAcceptLowRank.HrefValue = "";
                WillAcceptLowRank.TooltipValue = "";

                // AvailableFrom
                AvailableFrom.HrefValue = "";
                AvailableFrom.TooltipValue = "";

                // AvailableUntil
                AvailableUntil.HrefValue = "";
                AvailableUntil.TooltipValue = "";

                // PrimaryAddressDetail
                PrimaryAddressDetail.HrefValue = "";
                PrimaryAddressDetail.TooltipValue = "";

                // PrimaryAddressCity
                PrimaryAddressCity.HrefValue = "";
                PrimaryAddressCity.TooltipValue = "";

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.HrefValue = "";
                PrimaryAddressNearestAirport.TooltipValue = "";

                // PrimaryAddressState
                PrimaryAddressState.HrefValue = "";
                PrimaryAddressState.TooltipValue = "";

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.HrefValue = "";
                PrimaryAddressPostCode.TooltipValue = "";

                // PrimaryAddressCountryID
                PrimaryAddressCountryID.HrefValue = "";
                PrimaryAddressCountryID.TooltipValue = "";

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.HrefValue = "";
                PrimaryAddressHomeTel.TooltipValue = "";

                // AlternativeAddressDetail
                AlternativeAddressDetail.HrefValue = "";
                AlternativeAddressDetail.TooltipValue = "";

                // AlternativeAddressState
                AlternativeAddressState.HrefValue = "";
                AlternativeAddressState.TooltipValue = "";

                // AlternativeAddressCity
                AlternativeAddressCity.HrefValue = "";
                AlternativeAddressCity.TooltipValue = "";

                // AlternativeAddressHomeTel
                AlternativeAddressHomeTel.HrefValue = "";
                AlternativeAddressHomeTel.TooltipValue = "";

                // AlternativeAddressPostCode
                AlternativeAddressPostCode.HrefValue = "";
                AlternativeAddressPostCode.TooltipValue = "";

                // AlternativeAddressCountryID
                AlternativeAddressCountryID.HrefValue = "";
                AlternativeAddressCountryID.TooltipValue = "";

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

                // SocialSecurityNumber
                SocialSecurityNumber.HrefValue = "";
                SocialSecurityNumber.TooltipValue = "";

                // SocialSecurityIssuingCountryID
                SocialSecurityIssuingCountryID.HrefValue = "";
                SocialSecurityIssuingCountryID.TooltipValue = "";

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
                SocialSecurityImage.TooltipValue = "";
                if (SocialSecurityImage.UseColorbox) {
                    if (Empty(SocialSecurityImage.TooltipValue))
                        SocialSecurityImage.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                    SocialSecurityImage.LinkAttrs["data-rel"] = "CrewPersonalDataForAdminViewMode_x_SocialSecurityImage";
                    if (SocialSecurityImage.LinkAttrs.ContainsKey("class")) {
                        SocialSecurityImage.LinkAttrs.AppendClass("ew-lightbox");
                    } else {
                        SocialSecurityImage.LinkAttrs["class"] = "ew-lightbox";
                    }
                }

                // PersonalTaxNumber
                PersonalTaxNumber.HrefValue = "";
                PersonalTaxNumber.TooltipValue = "";

                // PersonalTaxIssuingCountryID
                PersonalTaxIssuingCountryID.HrefValue = "";
                PersonalTaxIssuingCountryID.TooltipValue = "";

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
                PersonalTaxImage.TooltipValue = "";
                if (PersonalTaxImage.UseColorbox) {
                    if (Empty(PersonalTaxImage.TooltipValue))
                        PersonalTaxImage.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                    PersonalTaxImage.LinkAttrs["data-rel"] = "CrewPersonalDataForAdminViewMode_x_PersonalTaxImage";
                    if (PersonalTaxImage.LinkAttrs.ContainsKey("class")) {
                        PersonalTaxImage.LinkAttrs.AppendClass("ew-lightbox");
                    } else {
                        PersonalTaxImage.LinkAttrs["class"] = "ew-lightbox";
                    }
                }

                // BloodType
                BloodType.HrefValue = "";
                BloodType.TooltipValue = "";

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
                    RequiredPhoto.LinkAttrs["data-rel"] = "CrewPersonalDataForAdminViewMode_x_RequiredPhoto";
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
                    VisaPhoto.LinkAttrs["data-rel"] = "CrewPersonalDataForAdminViewMode_x_VisaPhoto";
                    if (VisaPhoto.LinkAttrs.ContainsKey("class")) {
                        VisaPhoto.LinkAttrs.AppendClass("ew-lightbox");
                    } else {
                        VisaPhoto.LinkAttrs["class"] = "ew-lightbox";
                    }
                }

                // NomineeRelationshipSelect
                NomineeRelationshipSelect.HrefValue = "";
                NomineeRelationshipSelect.TooltipValue = "";

                // NomineeRelationshipDetail
                NomineeRelationshipDetail.HrefValue = "";
                NomineeRelationshipDetail.TooltipValue = "";
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

                // Nationality_CountryID
                Nationality_CountryID.SetupEditAttributes();
                curVal = ConvertToString(Nationality_CountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (Nationality_CountryID.Lookup != null && IsDictionary(Nationality_CountryID.Lookup?.Options) && Nationality_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Nationality_CountryID.EditValue = Nationality_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Nationality_CountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = Nationality_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Nationality_CountryID.EditValue = rswrk;
                }
                Nationality_CountryID.PlaceHolder = RemoveHtml(Nationality_CountryID.Caption);

                // CountryOfOrigin_CountryID
                CountryOfOrigin_CountryID.SetupEditAttributes();
                curVal = ConvertToString(CountryOfOrigin_CountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (CountryOfOrigin_CountryID.Lookup != null && IsDictionary(CountryOfOrigin_CountryID.Lookup?.Options) && CountryOfOrigin_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CountryOfOrigin_CountryID.EditValue = CountryOfOrigin_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", CountryOfOrigin_CountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = CountryOfOrigin_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    CountryOfOrigin_CountryID.EditValue = rswrk;
                }
                CountryOfOrigin_CountryID.PlaceHolder = RemoveHtml(CountryOfOrigin_CountryID.Caption);

                // DateOfBirth
                DateOfBirth.SetupEditAttributes();
                DateOfBirth.EditValue = FormatDateTime(UnformatDateTime(DateOfBirth.AdvancedSearch.SearchValue, DateOfBirth.FormatPattern), DateOfBirth.FormatPattern); // DN
                DateOfBirth.PlaceHolder = RemoveHtml(DateOfBirth.Caption);

                // CityOfBirth
                CityOfBirth.SetupEditAttributes();
                if (!CityOfBirth.Raw)
                    CityOfBirth.AdvancedSearch.SearchValue = HtmlDecode(CityOfBirth.AdvancedSearch.SearchValue);
                CityOfBirth.EditValue = HtmlEncode(CityOfBirth.AdvancedSearch.SearchValue);
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
                curVal = ConvertToString(ReligionID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (ReligionID.Lookup != null && IsDictionary(ReligionID.Lookup?.Options) && ReligionID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ReligionID.EditValue = ReligionID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", ReligionID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = ReligionID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    ReligionID.EditValue = rswrk;
                }
                ReligionID.PlaceHolder = RemoveHtml(ReligionID.Caption);

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.SetupEditAttributes();
                curVal = ConvertToString(RankAppliedFor_RankID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (RankAppliedFor_RankID.Lookup != null && IsDictionary(RankAppliedFor_RankID.Lookup?.Options) && RankAppliedFor_RankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    RankAppliedFor_RankID.EditValue = RankAppliedFor_RankID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", RankAppliedFor_RankID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = RankAppliedFor_RankID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    RankAppliedFor_RankID.EditValue = rswrk;
                }
                RankAppliedFor_RankID.PlaceHolder = RemoveHtml(RankAppliedFor_RankID.Caption);

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

                // PrimaryAddressDetail
                PrimaryAddressDetail.SetupEditAttributes();
                PrimaryAddressDetail.EditValue = PrimaryAddressDetail.AdvancedSearch.SearchValue; // DN
                PrimaryAddressDetail.PlaceHolder = RemoveHtml(PrimaryAddressDetail.Caption);

                // PrimaryAddressCity
                PrimaryAddressCity.SetupEditAttributes();
                if (!PrimaryAddressCity.Raw)
                    PrimaryAddressCity.AdvancedSearch.SearchValue = HtmlDecode(PrimaryAddressCity.AdvancedSearch.SearchValue);
                PrimaryAddressCity.EditValue = HtmlEncode(PrimaryAddressCity.AdvancedSearch.SearchValue);
                PrimaryAddressCity.PlaceHolder = RemoveHtml(PrimaryAddressCity.Caption);

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.SetupEditAttributes();
                if (!PrimaryAddressNearestAirport.Raw)
                    PrimaryAddressNearestAirport.AdvancedSearch.SearchValue = HtmlDecode(PrimaryAddressNearestAirport.AdvancedSearch.SearchValue);
                PrimaryAddressNearestAirport.EditValue = HtmlEncode(PrimaryAddressNearestAirport.AdvancedSearch.SearchValue);
                PrimaryAddressNearestAirport.PlaceHolder = RemoveHtml(PrimaryAddressNearestAirport.Caption);

                // PrimaryAddressState
                PrimaryAddressState.SetupEditAttributes();
                if (!PrimaryAddressState.Raw)
                    PrimaryAddressState.AdvancedSearch.SearchValue = HtmlDecode(PrimaryAddressState.AdvancedSearch.SearchValue);
                PrimaryAddressState.EditValue = HtmlEncode(PrimaryAddressState.AdvancedSearch.SearchValue);
                PrimaryAddressState.PlaceHolder = RemoveHtml(PrimaryAddressState.Caption);

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.SetupEditAttributes();
                if (!PrimaryAddressPostCode.Raw)
                    PrimaryAddressPostCode.AdvancedSearch.SearchValue = HtmlDecode(PrimaryAddressPostCode.AdvancedSearch.SearchValue);
                PrimaryAddressPostCode.EditValue = HtmlEncode(PrimaryAddressPostCode.AdvancedSearch.SearchValue);
                PrimaryAddressPostCode.PlaceHolder = RemoveHtml(PrimaryAddressPostCode.Caption);

                // PrimaryAddressCountryID
                PrimaryAddressCountryID.SetupEditAttributes();
                curVal = ConvertToString(PrimaryAddressCountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (PrimaryAddressCountryID.Lookup != null && IsDictionary(PrimaryAddressCountryID.Lookup?.Options) && PrimaryAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PrimaryAddressCountryID.EditValue = PrimaryAddressCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", PrimaryAddressCountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = PrimaryAddressCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    PrimaryAddressCountryID.EditValue = rswrk;
                }
                PrimaryAddressCountryID.PlaceHolder = RemoveHtml(PrimaryAddressCountryID.Caption);

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.SetupEditAttributes();
                if (!PrimaryAddressHomeTel.Raw)
                    PrimaryAddressHomeTel.AdvancedSearch.SearchValue = HtmlDecode(PrimaryAddressHomeTel.AdvancedSearch.SearchValue);
                PrimaryAddressHomeTel.EditValue = HtmlEncode(PrimaryAddressHomeTel.AdvancedSearch.SearchValue);
                PrimaryAddressHomeTel.PlaceHolder = RemoveHtml(PrimaryAddressHomeTel.Caption);

                // AlternativeAddressDetail
                AlternativeAddressDetail.SetupEditAttributes();
                AlternativeAddressDetail.EditValue = AlternativeAddressDetail.AdvancedSearch.SearchValue; // DN
                AlternativeAddressDetail.PlaceHolder = RemoveHtml(AlternativeAddressDetail.Caption);

                // AlternativeAddressState
                AlternativeAddressState.SetupEditAttributes();
                if (!AlternativeAddressState.Raw)
                    AlternativeAddressState.AdvancedSearch.SearchValue = HtmlDecode(AlternativeAddressState.AdvancedSearch.SearchValue);
                AlternativeAddressState.EditValue = HtmlEncode(AlternativeAddressState.AdvancedSearch.SearchValue);
                AlternativeAddressState.PlaceHolder = RemoveHtml(AlternativeAddressState.Caption);

                // AlternativeAddressCity
                AlternativeAddressCity.SetupEditAttributes();
                if (!AlternativeAddressCity.Raw)
                    AlternativeAddressCity.AdvancedSearch.SearchValue = HtmlDecode(AlternativeAddressCity.AdvancedSearch.SearchValue);
                AlternativeAddressCity.EditValue = HtmlEncode(AlternativeAddressCity.AdvancedSearch.SearchValue);
                AlternativeAddressCity.PlaceHolder = RemoveHtml(AlternativeAddressCity.Caption);

                // AlternativeAddressHomeTel
                AlternativeAddressHomeTel.SetupEditAttributes();
                if (!AlternativeAddressHomeTel.Raw)
                    AlternativeAddressHomeTel.AdvancedSearch.SearchValue = HtmlDecode(AlternativeAddressHomeTel.AdvancedSearch.SearchValue);
                AlternativeAddressHomeTel.EditValue = HtmlEncode(AlternativeAddressHomeTel.AdvancedSearch.SearchValue);
                AlternativeAddressHomeTel.PlaceHolder = RemoveHtml(AlternativeAddressHomeTel.Caption);

                // AlternativeAddressPostCode
                AlternativeAddressPostCode.SetupEditAttributes();
                if (!AlternativeAddressPostCode.Raw)
                    AlternativeAddressPostCode.AdvancedSearch.SearchValue = HtmlDecode(AlternativeAddressPostCode.AdvancedSearch.SearchValue);
                AlternativeAddressPostCode.EditValue = HtmlEncode(AlternativeAddressPostCode.AdvancedSearch.SearchValue);
                AlternativeAddressPostCode.PlaceHolder = RemoveHtml(AlternativeAddressPostCode.Caption);

                // AlternativeAddressCountryID
                AlternativeAddressCountryID.SetupEditAttributes();
                curVal = ConvertToString(AlternativeAddressCountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (AlternativeAddressCountryID.Lookup != null && IsDictionary(AlternativeAddressCountryID.Lookup?.Options) && AlternativeAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    AlternativeAddressCountryID.EditValue = AlternativeAddressCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", AlternativeAddressCountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = AlternativeAddressCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    AlternativeAddressCountryID.EditValue = rswrk;
                }
                AlternativeAddressCountryID.PlaceHolder = RemoveHtml(AlternativeAddressCountryID.Caption);

                // MobileNumber
                MobileNumber.SetupEditAttributes();
                if (!MobileNumber.Raw)
                    MobileNumber.AdvancedSearch.SearchValue = HtmlDecode(MobileNumber.AdvancedSearch.SearchValue);
                MobileNumber.EditValue = HtmlEncode(MobileNumber.AdvancedSearch.SearchValue);
                MobileNumber.PlaceHolder = RemoveHtml(MobileNumber.Caption);

                // Email
                _Email.SetupEditAttributes();
                if (!_Email.Raw)
                    _Email.AdvancedSearch.SearchValue = HtmlDecode(_Email.AdvancedSearch.SearchValue);
                _Email.EditValue = HtmlEncode(_Email.AdvancedSearch.SearchValue);
                _Email.PlaceHolder = RemoveHtml(_Email.Caption);

                // EmployeeStatus
                EmployeeStatus.SetupEditAttributes();
                if (!EmployeeStatus.Raw)
                    EmployeeStatus.AdvancedSearch.SearchValue = HtmlDecode(EmployeeStatus.AdvancedSearch.SearchValue);
                EmployeeStatus.EditValue = HtmlEncode(EmployeeStatus.AdvancedSearch.SearchValue);
                EmployeeStatus.PlaceHolder = RemoveHtml(EmployeeStatus.Caption);

                // FormSubmittedDateTime
                FormSubmittedDateTime.SetupEditAttributes();
                FormSubmittedDateTime.EditValue = FormatDateTime(UnformatDateTime(FormSubmittedDateTime.AdvancedSearch.SearchValue, FormSubmittedDateTime.FormatPattern), FormSubmittedDateTime.FormatPattern); // DN
                FormSubmittedDateTime.PlaceHolder = RemoveHtml(FormSubmittedDateTime.Caption);

                // CreatedByUserID
                CreatedByUserID.SetupEditAttributes();
                CreatedByUserID.EditValue = CreatedByUserID.AdvancedSearch.SearchValue; // DN
                CreatedByUserID.PlaceHolder = RemoveHtml(CreatedByUserID.Caption);

                // CreatedDateTime
                CreatedDateTime.SetupEditAttributes();
                CreatedDateTime.EditValue = FormatDateTime(UnformatDateTime(CreatedDateTime.AdvancedSearch.SearchValue, CreatedDateTime.FormatPattern), CreatedDateTime.FormatPattern); // DN
                CreatedDateTime.PlaceHolder = RemoveHtml(CreatedDateTime.Caption);

                // LastUpdatedByUserID
                LastUpdatedByUserID.SetupEditAttributes();
                LastUpdatedByUserID.EditValue = LastUpdatedByUserID.AdvancedSearch.SearchValue; // DN
                LastUpdatedByUserID.PlaceHolder = RemoveHtml(LastUpdatedByUserID.Caption);

                // LastUpdatedDateTime
                LastUpdatedDateTime.SetupEditAttributes();
                LastUpdatedDateTime.EditValue = FormatDateTime(UnformatDateTime(LastUpdatedDateTime.AdvancedSearch.SearchValue, LastUpdatedDateTime.FormatPattern), LastUpdatedDateTime.FormatPattern); // DN
                LastUpdatedDateTime.PlaceHolder = RemoveHtml(LastUpdatedDateTime.Caption);

                // SocialSecurityNumber
                SocialSecurityNumber.SetupEditAttributes();
                if (!SocialSecurityNumber.Raw)
                    SocialSecurityNumber.AdvancedSearch.SearchValue = HtmlDecode(SocialSecurityNumber.AdvancedSearch.SearchValue);
                SocialSecurityNumber.EditValue = HtmlEncode(SocialSecurityNumber.AdvancedSearch.SearchValue);
                SocialSecurityNumber.PlaceHolder = RemoveHtml(SocialSecurityNumber.Caption);

                // SocialSecurityIssuingCountryID
                SocialSecurityIssuingCountryID.SetupEditAttributes();
                curVal = ConvertToString(SocialSecurityIssuingCountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (SocialSecurityIssuingCountryID.Lookup != null && IsDictionary(SocialSecurityIssuingCountryID.Lookup?.Options) && SocialSecurityIssuingCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    SocialSecurityIssuingCountryID.EditValue = SocialSecurityIssuingCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", SocialSecurityIssuingCountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = SocialSecurityIssuingCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    SocialSecurityIssuingCountryID.EditValue = rswrk;
                }
                SocialSecurityIssuingCountryID.PlaceHolder = RemoveHtml(SocialSecurityIssuingCountryID.Caption);

                // SocialSecurityImage
                SocialSecurityImage.SetupEditAttributes();
                if (!SocialSecurityImage.Raw)
                    SocialSecurityImage.AdvancedSearch.SearchValue = HtmlDecode(SocialSecurityImage.AdvancedSearch.SearchValue);
                SocialSecurityImage.EditValue = HtmlEncode(SocialSecurityImage.AdvancedSearch.SearchValue);
                SocialSecurityImage.PlaceHolder = RemoveHtml(SocialSecurityImage.Caption);

                // PersonalTaxNumber
                PersonalTaxNumber.SetupEditAttributes();
                if (!PersonalTaxNumber.Raw)
                    PersonalTaxNumber.AdvancedSearch.SearchValue = HtmlDecode(PersonalTaxNumber.AdvancedSearch.SearchValue);
                PersonalTaxNumber.EditValue = HtmlEncode(PersonalTaxNumber.AdvancedSearch.SearchValue);
                PersonalTaxNumber.PlaceHolder = RemoveHtml(PersonalTaxNumber.Caption);

                // PersonalTaxIssuingCountryID
                PersonalTaxIssuingCountryID.SetupEditAttributes();
                curVal = ConvertToString(PersonalTaxIssuingCountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (PersonalTaxIssuingCountryID.Lookup != null && IsDictionary(PersonalTaxIssuingCountryID.Lookup?.Options) && PersonalTaxIssuingCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PersonalTaxIssuingCountryID.EditValue = PersonalTaxIssuingCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", PersonalTaxIssuingCountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = PersonalTaxIssuingCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    PersonalTaxIssuingCountryID.EditValue = rswrk;
                }
                PersonalTaxIssuingCountryID.PlaceHolder = RemoveHtml(PersonalTaxIssuingCountryID.Caption);

                // PersonalTaxImage
                PersonalTaxImage.SetupEditAttributes();
                if (!PersonalTaxImage.Raw)
                    PersonalTaxImage.AdvancedSearch.SearchValue = HtmlDecode(PersonalTaxImage.AdvancedSearch.SearchValue);
                PersonalTaxImage.EditValue = HtmlEncode(PersonalTaxImage.AdvancedSearch.SearchValue);
                PersonalTaxImage.PlaceHolder = RemoveHtml(PersonalTaxImage.Caption);

                // BloodType
                BloodType.SetupEditAttributes();
                BloodType.EditValue = BloodType.Options(true);
                BloodType.PlaceHolder = RemoveHtml(BloodType.Caption);

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

                // NomineeRelationshipSelect
                NomineeRelationshipSelect.SetupEditAttributes();
                NomineeRelationshipSelect.EditValue = NomineeRelationshipSelect.Options(true);
                NomineeRelationshipSelect.PlaceHolder = RemoveHtml(NomineeRelationshipSelect.Caption);

                // NomineeRelationshipDetail
                NomineeRelationshipDetail.SetupEditAttributes();
                if (!NomineeRelationshipDetail.Raw)
                    NomineeRelationshipDetail.AdvancedSearch.SearchValue = HtmlDecode(NomineeRelationshipDetail.AdvancedSearch.SearchValue);
                NomineeRelationshipDetail.EditValue = HtmlEncode(NomineeRelationshipDetail.AdvancedSearch.SearchValue);
                NomineeRelationshipDetail.PlaceHolder = RemoveHtml(NomineeRelationshipDetail.Caption);
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
            if (!CheckDate(ConvertToString(DateOfBirth.AdvancedSearch.SearchValue), DateOfBirth.FormatPattern)) {
                DateOfBirth.AddErrorMessage(DateOfBirth.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(AvailableFrom.AdvancedSearch.SearchValue), AvailableFrom.FormatPattern)) {
                AvailableFrom.AddErrorMessage(AvailableFrom.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(AvailableUntil.AdvancedSearch.SearchValue), AvailableUntil.FormatPattern)) {
                AvailableUntil.AddErrorMessage(AvailableUntil.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(FormSubmittedDateTime.AdvancedSearch.SearchValue), FormSubmittedDateTime.FormatPattern)) {
                FormSubmittedDateTime.AddErrorMessage(FormSubmittedDateTime.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(CreatedByUserID.AdvancedSearch.SearchValue))) {
                CreatedByUserID.AddErrorMessage(CreatedByUserID.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(CreatedDateTime.AdvancedSearch.SearchValue), CreatedDateTime.FormatPattern)) {
                CreatedDateTime.AddErrorMessage(CreatedDateTime.GetErrorMessage(false));
            }
            if (!CheckInteger(ConvertToString(LastUpdatedByUserID.AdvancedSearch.SearchValue))) {
                LastUpdatedByUserID.AddErrorMessage(LastUpdatedByUserID.GetErrorMessage(false));
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
            Nationality_CountryID.AdvancedSearch.Load();
            CountryOfOrigin_CountryID.AdvancedSearch.Load();
            DateOfBirth.AdvancedSearch.Load();
            CityOfBirth.AdvancedSearch.Load();
            Gender.AdvancedSearch.Load();
            MaritalStatus.AdvancedSearch.Load();
            ReligionID.AdvancedSearch.Load();
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
            BloodType.AdvancedSearch.Load();
            RequiredPhoto.AdvancedSearch.Load();
            VisaPhoto.AdvancedSearch.Load();
            NomineeRelationshipSelect.AdvancedSearch.Load();
            NomineeRelationshipDetail.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("CrewPersonalDataForAdminViewModeList")), "", TableVar, true);
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
