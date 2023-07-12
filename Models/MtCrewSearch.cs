namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mtCrewSearch
    /// </summary>
    public static MtCrewSearch mtCrewSearch
    {
        get => HttpData.Get<MtCrewSearch>("mtCrewSearch")!;
        set => HttpData["mtCrewSearch"] = value;
    }

    /// <summary>
    /// Page class for MTCrew
    /// </summary>
    public class MtCrewSearch : MtCrewSearchBase
    {
        // Constructor
        public MtCrewSearch(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MtCrewSearch() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MtCrewSearchBase : MtCrew
    {
        // Page ID
        public string PageID = "search";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "MTCrew";

        // Page object name
        public string PageObjName = "mtCrewSearch";

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
        public MtCrewSearchBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-search-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (mtCrew)
            if (mtCrew == null || mtCrew is MtCrew)
                mtCrew = this;

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
        public string PageName => "MtCrewSearch";

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
            FirstName.Visible = false;
            MiddleName.Visible = false;
            LastName.Visible = false;
            RequiredPhoto.Visible = false;
            VisaPhoto.Visible = false;
            Nationality_CountryID.SetVisibility();
            CountryOfOrigin_CountryID.SetVisibility();
            DateOfBirth.SetVisibility();
            CityOfBirth.SetVisibility();
            MaritalStatus.SetVisibility();
            Gender.SetVisibility();
            ReligionID.SetVisibility();
            BloodType.SetVisibility();
            RankAppliedFor_RankID.SetVisibility();
            WillAcceptLowRank.SetVisibility();
            AvailableFrom.SetVisibility();
            AvailableUntil.SetVisibility();
            PrimaryAddressDetail.SetVisibility();
            PrimaryAddressCity.SetVisibility();
            PrimaryAddressState.SetVisibility();
            PrimaryAddressNearestAirport.SetVisibility();
            PrimaryAddressPostCode.SetVisibility();
            PrimaryAddressCountryID.SetVisibility();
            PrimaryAddressHomeTel.SetVisibility();
            PrimaryAddressFax.SetVisibility();
            AlternativeAddressDetail.SetVisibility();
            AlternativeAddressCity.SetVisibility();
            AlternativeAddressState.SetVisibility();
            AlternativeAddressHomeTel.SetVisibility();
            AlternativeAddressPostCode.SetVisibility();
            AlternativeAddressCountryID.SetVisibility();
            MobileNumber.SetVisibility();
            _Email.SetVisibility();
            ContactMethodEmail.SetVisibility();
            ContactMethodFax.SetVisibility();
            ContactMethodMobilePhone.SetVisibility();
            ContactMethodHomePhone.SetVisibility();
            ContactMethodPost.SetVisibility();
            CollarSize.SetVisibility();
            ChestSize.SetVisibility();
            WaistSize.SetVisibility();
            InsideLegSize.SetVisibility();
            CapSize.SetVisibility();
            SweaterSize_ClothesSizeID.SetVisibility();
            BoilersuitSize_ClothesSizeID.SetVisibility();
            SocialSecurityNumber.SetVisibility();
            SocialSecurityIssuingCountryID.SetVisibility();
            SocialSecurityImage.SetVisibility();
            PersonalTaxNumber.SetVisibility();
            PersonalTaxIssuingCountryID.SetVisibility();
            PersonalTaxImage.SetVisibility();
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
            NomineeValidVisa.SetVisibility();
            BankName.SetVisibility();
            BankAddress.SetVisibility();
            BankAccountName.SetVisibility();
            BankAccountNumber.SetVisibility();
            BankSortCode.SetVisibility();
            MNOPF.SetVisibility();
            MembershipNumber.SetVisibility();
            NationalInsuranceNumber.SetVisibility();
            AVC.SetVisibility();
            ForeignVisaHasBeenDenied.SetVisibility();
            ForeignVisaDenied_CountryID.SetVisibility();
            ForeignVisaDeniedReason.SetVisibility();
            HasMaritimeAccidentOrCourtOfEnquiry.SetVisibility();
            HasMaritimeAccidentOrCourtOfEnquiryDetails.SetVisibility();
            Reference1CompanyName.SetVisibility();
            Reference1ContactPersonName.SetVisibility();
            Reference1CompanyAddress.SetVisibility();
            Reference1CompanyCountryID.SetVisibility();
            Reference1CompanyTelephone.SetVisibility();
            Reference2CompanyName.SetVisibility();
            Reference2ContactPersonName.SetVisibility();
            Reference2CompanyAddress.SetVisibility();
            Reference2CompanyCountryID.SetVisibility();
            Reference2CompanyTelephone.SetVisibility();
            EmployeeStatus.SetVisibility();
            FormSubmittedDateTime.SetVisibility();
            ActiveDescription.Visible = false;
            CreatedByUserID.SetVisibility();
            CreatedDateTime.SetVisibility();
            LastUpdatedByUserID.SetVisibility();
            LastUpdatedDateTime.SetVisibility();
            MTUserID.Visible = false;
            DocumentCheckDateTime.Visible = false;
            InterviewManagerDateTime.Visible = false;
            InterviewGMDateTime.Visible = false;
            MCUScheduleDateTime.Visible = false;
            RejectedReason.Visible = false;
            RejectedDateTime.Visible = false;
            Status.Visible = false;
            Reason.Visible = false;
            Weight.Visible = false;
            Height.Visible = false;
            CoverallSize.Visible = false;
            SafetyShoesSize.Visible = false;
            ShirtSize.Visible = false;
            TrousersSize.Visible = false;
            NSSF_Health_Number.Visible = false;
            NSSF_Occupation_Number.Visible = false;
            FinalAcceptedDate.Visible = false;
            Reference1CompanyTelephoneCode_CountryID.Visible = false;
            Reference2CompanyTelephoneCode_CountryID.Visible = false;
            MobileNumberCode_CountryID.Visible = false;
            PrimaryAddressHomeTelCode_CountryID.Visible = false;
            AlternativeAddressHomeTelCode_CountryID.Visible = false;
            NomineeAddressHomeTelCode_CountryID.Visible = false;
            NomineeMobileNumberCode_CountryID.Visible = false;
            RevisedReason.SetVisibility();
            RevisedDateTime.SetVisibility();
        }

        // Constructor
        public MtCrewSearchBase(Controller? controller = null): this() { // DN
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
                            result.Add("view", pageName == "MtCrewView" ? "1" : "0"); // If View page, no primary button
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
            await SetupLookupOptions(MaritalStatus);
            await SetupLookupOptions(Gender);
            await SetupLookupOptions(ReligionID);
            await SetupLookupOptions(BloodType);
            await SetupLookupOptions(RankAppliedFor_RankID);
            await SetupLookupOptions(WillAcceptLowRank);
            await SetupLookupOptions(PrimaryAddressCountryID);
            await SetupLookupOptions(AlternativeAddressCountryID);
            await SetupLookupOptions(ContactMethodEmail);
            await SetupLookupOptions(ContactMethodFax);
            await SetupLookupOptions(ContactMethodMobilePhone);
            await SetupLookupOptions(ContactMethodHomePhone);
            await SetupLookupOptions(ContactMethodPost);
            await SetupLookupOptions(SweaterSize_ClothesSizeID);
            await SetupLookupOptions(BoilersuitSize_ClothesSizeID);
            await SetupLookupOptions(SocialSecurityIssuingCountryID);
            await SetupLookupOptions(PersonalTaxIssuingCountryID);
            await SetupLookupOptions(NomineeGender);
            await SetupLookupOptions(NomineeNationality_CountryID);
            await SetupLookupOptions(NomineeAddressCountryID);
            await SetupLookupOptions(NomineeValidVisa);
            await SetupLookupOptions(ForeignVisaHasBeenDenied);
            await SetupLookupOptions(ForeignVisaDenied_CountryID);
            await SetupLookupOptions(HasMaritimeAccidentOrCourtOfEnquiry);
            await SetupLookupOptions(Reference1CompanyCountryID);
            await SetupLookupOptions(Reference2CompanyCountryID);
            await SetupLookupOptions(CreatedByUserID);
            await SetupLookupOptions(LastUpdatedByUserID);
            await SetupLookupOptions(Reference1CompanyTelephoneCode_CountryID);
            await SetupLookupOptions(Reference2CompanyTelephoneCode_CountryID);
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
                    srchStr = "MtCrewList?" + srchStr;
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
                mtCrewSearch?.PageRender();
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
            BuildSearchUrl(ref srchUrl, MaritalStatus); // MaritalStatus
            BuildSearchUrl(ref srchUrl, Gender); // Gender
            BuildSearchUrl(ref srchUrl, ReligionID); // ReligionID
            BuildSearchUrl(ref srchUrl, BloodType); // BloodType
            BuildSearchUrl(ref srchUrl, RankAppliedFor_RankID); // RankAppliedFor_RankID
            BuildSearchUrl(ref srchUrl, WillAcceptLowRank, true); // WillAcceptLowRank
            BuildSearchUrl(ref srchUrl, AvailableFrom); // AvailableFrom
            BuildSearchUrl(ref srchUrl, AvailableUntil); // AvailableUntil
            BuildSearchUrl(ref srchUrl, PrimaryAddressDetail); // PrimaryAddressDetail
            BuildSearchUrl(ref srchUrl, PrimaryAddressCity); // PrimaryAddressCity
            BuildSearchUrl(ref srchUrl, PrimaryAddressState); // PrimaryAddressState
            BuildSearchUrl(ref srchUrl, PrimaryAddressNearestAirport); // PrimaryAddressNearestAirport
            BuildSearchUrl(ref srchUrl, PrimaryAddressPostCode); // PrimaryAddressPostCode
            BuildSearchUrl(ref srchUrl, PrimaryAddressCountryID); // PrimaryAddressCountryID
            BuildSearchUrl(ref srchUrl, PrimaryAddressHomeTel); // PrimaryAddressHomeTel
            BuildSearchUrl(ref srchUrl, PrimaryAddressFax); // PrimaryAddressFax
            BuildSearchUrl(ref srchUrl, AlternativeAddressDetail); // AlternativeAddressDetail
            BuildSearchUrl(ref srchUrl, AlternativeAddressCity); // AlternativeAddressCity
            BuildSearchUrl(ref srchUrl, AlternativeAddressState); // AlternativeAddressState
            BuildSearchUrl(ref srchUrl, AlternativeAddressHomeTel); // AlternativeAddressHomeTel
            BuildSearchUrl(ref srchUrl, AlternativeAddressPostCode); // AlternativeAddressPostCode
            BuildSearchUrl(ref srchUrl, AlternativeAddressCountryID); // AlternativeAddressCountryID
            BuildSearchUrl(ref srchUrl, MobileNumber); // MobileNumber
            BuildSearchUrl(ref srchUrl, _Email); // Email
            BuildSearchUrl(ref srchUrl, ContactMethodEmail, true); // ContactMethodEmail
            BuildSearchUrl(ref srchUrl, ContactMethodFax, true); // ContactMethodFax
            BuildSearchUrl(ref srchUrl, ContactMethodMobilePhone, true); // ContactMethodMobilePhone
            BuildSearchUrl(ref srchUrl, ContactMethodHomePhone, true); // ContactMethodHomePhone
            BuildSearchUrl(ref srchUrl, ContactMethodPost, true); // ContactMethodPost
            BuildSearchUrl(ref srchUrl, CollarSize); // CollarSize
            BuildSearchUrl(ref srchUrl, ChestSize); // ChestSize
            BuildSearchUrl(ref srchUrl, WaistSize); // WaistSize
            BuildSearchUrl(ref srchUrl, InsideLegSize); // InsideLegSize
            BuildSearchUrl(ref srchUrl, CapSize); // CapSize
            BuildSearchUrl(ref srchUrl, SweaterSize_ClothesSizeID); // SweaterSize_ClothesSizeID
            BuildSearchUrl(ref srchUrl, BoilersuitSize_ClothesSizeID); // BoilersuitSize_ClothesSizeID
            BuildSearchUrl(ref srchUrl, SocialSecurityNumber); // SocialSecurityNumber
            BuildSearchUrl(ref srchUrl, SocialSecurityIssuingCountryID); // SocialSecurityIssuingCountryID
            BuildSearchUrl(ref srchUrl, SocialSecurityImage); // SocialSecurityImage
            BuildSearchUrl(ref srchUrl, PersonalTaxNumber); // PersonalTaxNumber
            BuildSearchUrl(ref srchUrl, PersonalTaxIssuingCountryID); // PersonalTaxIssuingCountryID
            BuildSearchUrl(ref srchUrl, PersonalTaxImage); // PersonalTaxImage
            BuildSearchUrl(ref srchUrl, NomineeFullName); // NomineeFullName
            BuildSearchUrl(ref srchUrl, NomineeRelationship); // NomineeRelationship
            BuildSearchUrl(ref srchUrl, NomineeGender); // NomineeGender
            BuildSearchUrl(ref srchUrl, NomineeNationality_CountryID); // NomineeNationality_CountryID
            BuildSearchUrl(ref srchUrl, NomineeAddressDetail); // NomineeAddressDetail
            BuildSearchUrl(ref srchUrl, NomineeAddressCity); // NomineeAddressCity
            BuildSearchUrl(ref srchUrl, NomineeAddressPostCode); // NomineeAddressPostCode
            BuildSearchUrl(ref srchUrl, NomineeAddressCountryID); // NomineeAddressCountryID
            BuildSearchUrl(ref srchUrl, NomineeAddressHomeTel); // NomineeAddressHomeTel
            BuildSearchUrl(ref srchUrl, NomineeEmail); // NomineeEmail
            BuildSearchUrl(ref srchUrl, NomineeMobileNumber); // NomineeMobileNumber
            BuildSearchUrl(ref srchUrl, NomineeValidVisa); // NomineeValidVisa
            BuildSearchUrl(ref srchUrl, BankName); // BankName
            BuildSearchUrl(ref srchUrl, BankAddress); // BankAddress
            BuildSearchUrl(ref srchUrl, BankAccountName); // BankAccountName
            BuildSearchUrl(ref srchUrl, BankAccountNumber); // BankAccountNumber
            BuildSearchUrl(ref srchUrl, BankSortCode); // BankSortCode
            BuildSearchUrl(ref srchUrl, MNOPF); // MNOPF
            BuildSearchUrl(ref srchUrl, MembershipNumber); // MembershipNumber
            BuildSearchUrl(ref srchUrl, NationalInsuranceNumber); // NationalInsuranceNumber
            BuildSearchUrl(ref srchUrl, AVC); // AVC
            BuildSearchUrl(ref srchUrl, ForeignVisaHasBeenDenied, true); // ForeignVisaHasBeenDenied
            BuildSearchUrl(ref srchUrl, ForeignVisaDenied_CountryID); // ForeignVisaDenied_CountryID
            BuildSearchUrl(ref srchUrl, ForeignVisaDeniedReason); // ForeignVisaDeniedReason
            BuildSearchUrl(ref srchUrl, HasMaritimeAccidentOrCourtOfEnquiry, true); // HasMaritimeAccidentOrCourtOfEnquiry
            BuildSearchUrl(ref srchUrl, HasMaritimeAccidentOrCourtOfEnquiryDetails); // HasMaritimeAccidentOrCourtOfEnquiryDetails
            BuildSearchUrl(ref srchUrl, Reference1CompanyName); // Reference1CompanyName
            BuildSearchUrl(ref srchUrl, Reference1ContactPersonName); // Reference1ContactPersonName
            BuildSearchUrl(ref srchUrl, Reference1CompanyAddress); // Reference1CompanyAddress
            BuildSearchUrl(ref srchUrl, Reference1CompanyCountryID); // Reference1CompanyCountryID
            BuildSearchUrl(ref srchUrl, Reference1CompanyTelephone); // Reference1CompanyTelephone
            BuildSearchUrl(ref srchUrl, Reference2CompanyName); // Reference2CompanyName
            BuildSearchUrl(ref srchUrl, Reference2ContactPersonName); // Reference2ContactPersonName
            BuildSearchUrl(ref srchUrl, Reference2CompanyAddress); // Reference2CompanyAddress
            BuildSearchUrl(ref srchUrl, Reference2CompanyCountryID); // Reference2CompanyCountryID
            BuildSearchUrl(ref srchUrl, Reference2CompanyTelephone); // Reference2CompanyTelephone
            BuildSearchUrl(ref srchUrl, EmployeeStatus); // EmployeeStatus
            BuildSearchUrl(ref srchUrl, FormSubmittedDateTime); // FormSubmittedDateTime
            BuildSearchUrl(ref srchUrl, CreatedByUserID); // CreatedByUserID
            BuildSearchUrl(ref srchUrl, CreatedDateTime); // CreatedDateTime
            BuildSearchUrl(ref srchUrl, LastUpdatedByUserID); // LastUpdatedByUserID
            BuildSearchUrl(ref srchUrl, LastUpdatedDateTime); // LastUpdatedDateTime
            BuildSearchUrl(ref srchUrl, RevisedReason); // RevisedReason
            BuildSearchUrl(ref srchUrl, RevisedDateTime); // RevisedDateTime
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

            // MaritalStatus
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MaritalStatus"))
                    MaritalStatus.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MaritalStatus");
            if (Form.ContainsKey("z_MaritalStatus"))
                MaritalStatus.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MaritalStatus");

            // Gender
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Gender"))
                    Gender.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Gender");
            if (Form.ContainsKey("z_Gender"))
                Gender.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Gender");

            // ReligionID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ReligionID"))
                    ReligionID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ReligionID");
            if (Form.ContainsKey("z_ReligionID"))
                ReligionID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ReligionID");

            // BloodType
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_BloodType"))
                    BloodType.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_BloodType");
            if (Form.ContainsKey("z_BloodType"))
                BloodType.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_BloodType");

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

            // PrimaryAddressState
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressState"))
                    PrimaryAddressState.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressState");
            if (Form.ContainsKey("z_PrimaryAddressState"))
                PrimaryAddressState.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressState");

            // PrimaryAddressNearestAirport
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressNearestAirport"))
                    PrimaryAddressNearestAirport.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressNearestAirport");
            if (Form.ContainsKey("z_PrimaryAddressNearestAirport"))
                PrimaryAddressNearestAirport.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressNearestAirport");

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

            // PrimaryAddressFax
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_PrimaryAddressFax"))
                    PrimaryAddressFax.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_PrimaryAddressFax");
            if (Form.ContainsKey("z_PrimaryAddressFax"))
                PrimaryAddressFax.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_PrimaryAddressFax");

            // AlternativeAddressDetail
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AlternativeAddressDetail"))
                    AlternativeAddressDetail.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AlternativeAddressDetail");
            if (Form.ContainsKey("z_AlternativeAddressDetail"))
                AlternativeAddressDetail.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AlternativeAddressDetail");

            // AlternativeAddressCity
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AlternativeAddressCity"))
                    AlternativeAddressCity.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AlternativeAddressCity");
            if (Form.ContainsKey("z_AlternativeAddressCity"))
                AlternativeAddressCity.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AlternativeAddressCity");

            // AlternativeAddressState
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AlternativeAddressState"))
                    AlternativeAddressState.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AlternativeAddressState");
            if (Form.ContainsKey("z_AlternativeAddressState"))
                AlternativeAddressState.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AlternativeAddressState");

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

            // ContactMethodEmail
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ContactMethodEmail"))
                    ContactMethodEmail.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ContactMethodEmail");
            if (Form.ContainsKey("z_ContactMethodEmail"))
                ContactMethodEmail.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ContactMethodEmail");

            // ContactMethodFax
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ContactMethodFax"))
                    ContactMethodFax.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ContactMethodFax");
            if (Form.ContainsKey("z_ContactMethodFax"))
                ContactMethodFax.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ContactMethodFax");

            // ContactMethodMobilePhone
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ContactMethodMobilePhone"))
                    ContactMethodMobilePhone.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ContactMethodMobilePhone");
            if (Form.ContainsKey("z_ContactMethodMobilePhone"))
                ContactMethodMobilePhone.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ContactMethodMobilePhone");

            // ContactMethodHomePhone
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ContactMethodHomePhone"))
                    ContactMethodHomePhone.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ContactMethodHomePhone");
            if (Form.ContainsKey("z_ContactMethodHomePhone"))
                ContactMethodHomePhone.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ContactMethodHomePhone");

            // ContactMethodPost
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ContactMethodPost"))
                    ContactMethodPost.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ContactMethodPost");
            if (Form.ContainsKey("z_ContactMethodPost"))
                ContactMethodPost.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ContactMethodPost");

            // CollarSize
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CollarSize"))
                    CollarSize.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CollarSize");
            if (Form.ContainsKey("z_CollarSize"))
                CollarSize.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CollarSize");

            // ChestSize
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ChestSize"))
                    ChestSize.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ChestSize");
            if (Form.ContainsKey("z_ChestSize"))
                ChestSize.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ChestSize");

            // WaistSize
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_WaistSize"))
                    WaistSize.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_WaistSize");
            if (Form.ContainsKey("z_WaistSize"))
                WaistSize.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_WaistSize");

            // InsideLegSize
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_InsideLegSize"))
                    InsideLegSize.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_InsideLegSize");
            if (Form.ContainsKey("z_InsideLegSize"))
                InsideLegSize.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_InsideLegSize");

            // CapSize
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_CapSize"))
                    CapSize.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_CapSize");
            if (Form.ContainsKey("z_CapSize"))
                CapSize.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_CapSize");

            // SweaterSize_ClothesSizeID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_SweaterSize_ClothesSizeID"))
                    SweaterSize_ClothesSizeID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_SweaterSize_ClothesSizeID");
            if (Form.ContainsKey("z_SweaterSize_ClothesSizeID"))
                SweaterSize_ClothesSizeID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_SweaterSize_ClothesSizeID");

            // BoilersuitSize_ClothesSizeID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_BoilersuitSize_ClothesSizeID"))
                    BoilersuitSize_ClothesSizeID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_BoilersuitSize_ClothesSizeID");
            if (Form.ContainsKey("z_BoilersuitSize_ClothesSizeID"))
                BoilersuitSize_ClothesSizeID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_BoilersuitSize_ClothesSizeID");

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

            // NomineeFullName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeFullName"))
                    NomineeFullName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeFullName");
            if (Form.ContainsKey("z_NomineeFullName"))
                NomineeFullName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeFullName");

            // NomineeRelationship
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeRelationship"))
                    NomineeRelationship.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeRelationship");
            if (Form.ContainsKey("z_NomineeRelationship"))
                NomineeRelationship.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeRelationship");

            // NomineeGender
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeGender"))
                    NomineeGender.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeGender");
            if (Form.ContainsKey("z_NomineeGender"))
                NomineeGender.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeGender");

            // NomineeNationality_CountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeNationality_CountryID"))
                    NomineeNationality_CountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeNationality_CountryID");
            if (Form.ContainsKey("z_NomineeNationality_CountryID"))
                NomineeNationality_CountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeNationality_CountryID");

            // NomineeAddressDetail
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeAddressDetail"))
                    NomineeAddressDetail.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeAddressDetail");
            if (Form.ContainsKey("z_NomineeAddressDetail"))
                NomineeAddressDetail.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeAddressDetail");

            // NomineeAddressCity
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeAddressCity"))
                    NomineeAddressCity.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeAddressCity");
            if (Form.ContainsKey("z_NomineeAddressCity"))
                NomineeAddressCity.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeAddressCity");

            // NomineeAddressPostCode
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeAddressPostCode"))
                    NomineeAddressPostCode.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeAddressPostCode");
            if (Form.ContainsKey("z_NomineeAddressPostCode"))
                NomineeAddressPostCode.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeAddressPostCode");

            // NomineeAddressCountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeAddressCountryID"))
                    NomineeAddressCountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeAddressCountryID");
            if (Form.ContainsKey("z_NomineeAddressCountryID"))
                NomineeAddressCountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeAddressCountryID");

            // NomineeAddressHomeTel
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeAddressHomeTel"))
                    NomineeAddressHomeTel.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeAddressHomeTel");
            if (Form.ContainsKey("z_NomineeAddressHomeTel"))
                NomineeAddressHomeTel.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeAddressHomeTel");

            // NomineeEmail
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeEmail"))
                    NomineeEmail.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeEmail");
            if (Form.ContainsKey("z_NomineeEmail"))
                NomineeEmail.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeEmail");

            // NomineeMobileNumber
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeMobileNumber"))
                    NomineeMobileNumber.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeMobileNumber");
            if (Form.ContainsKey("z_NomineeMobileNumber"))
                NomineeMobileNumber.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeMobileNumber");

            // NomineeValidVisa
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NomineeValidVisa"))
                    NomineeValidVisa.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NomineeValidVisa");
            if (Form.ContainsKey("z_NomineeValidVisa"))
                NomineeValidVisa.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NomineeValidVisa");

            // BankName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_BankName"))
                    BankName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_BankName");
            if (Form.ContainsKey("z_BankName"))
                BankName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_BankName");

            // BankAddress
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_BankAddress"))
                    BankAddress.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_BankAddress");
            if (Form.ContainsKey("z_BankAddress"))
                BankAddress.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_BankAddress");

            // BankAccountName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_BankAccountName"))
                    BankAccountName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_BankAccountName");
            if (Form.ContainsKey("z_BankAccountName"))
                BankAccountName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_BankAccountName");

            // BankAccountNumber
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_BankAccountNumber"))
                    BankAccountNumber.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_BankAccountNumber");
            if (Form.ContainsKey("z_BankAccountNumber"))
                BankAccountNumber.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_BankAccountNumber");

            // BankSortCode
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_BankSortCode"))
                    BankSortCode.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_BankSortCode");
            if (Form.ContainsKey("z_BankSortCode"))
                BankSortCode.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_BankSortCode");

            // MNOPF
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MNOPF"))
                    MNOPF.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MNOPF");
            if (Form.ContainsKey("z_MNOPF"))
                MNOPF.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MNOPF");

            // MembershipNumber
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_MembershipNumber"))
                    MembershipNumber.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_MembershipNumber");
            if (Form.ContainsKey("z_MembershipNumber"))
                MembershipNumber.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_MembershipNumber");

            // NationalInsuranceNumber
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_NationalInsuranceNumber"))
                    NationalInsuranceNumber.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_NationalInsuranceNumber");
            if (Form.ContainsKey("z_NationalInsuranceNumber"))
                NationalInsuranceNumber.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_NationalInsuranceNumber");

            // AVC
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_AVC"))
                    AVC.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_AVC");
            if (Form.ContainsKey("z_AVC"))
                AVC.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_AVC");

            // ForeignVisaHasBeenDenied
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ForeignVisaHasBeenDenied"))
                    ForeignVisaHasBeenDenied.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ForeignVisaHasBeenDenied");
            if (Form.ContainsKey("z_ForeignVisaHasBeenDenied"))
                ForeignVisaHasBeenDenied.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ForeignVisaHasBeenDenied");

            // ForeignVisaDenied_CountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ForeignVisaDenied_CountryID"))
                    ForeignVisaDenied_CountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ForeignVisaDenied_CountryID");
            if (Form.ContainsKey("z_ForeignVisaDenied_CountryID"))
                ForeignVisaDenied_CountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ForeignVisaDenied_CountryID");

            // ForeignVisaDeniedReason
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_ForeignVisaDeniedReason"))
                    ForeignVisaDeniedReason.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_ForeignVisaDeniedReason");
            if (Form.ContainsKey("z_ForeignVisaDeniedReason"))
                ForeignVisaDeniedReason.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_ForeignVisaDeniedReason");

            // HasMaritimeAccidentOrCourtOfEnquiry
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_HasMaritimeAccidentOrCourtOfEnquiry"))
                    HasMaritimeAccidentOrCourtOfEnquiry.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_HasMaritimeAccidentOrCourtOfEnquiry");
            if (Form.ContainsKey("z_HasMaritimeAccidentOrCourtOfEnquiry"))
                HasMaritimeAccidentOrCourtOfEnquiry.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_HasMaritimeAccidentOrCourtOfEnquiry");

            // HasMaritimeAccidentOrCourtOfEnquiryDetails
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_HasMaritimeAccidentOrCourtOfEnquiryDetails"))
                    HasMaritimeAccidentOrCourtOfEnquiryDetails.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_HasMaritimeAccidentOrCourtOfEnquiryDetails");
            if (Form.ContainsKey("z_HasMaritimeAccidentOrCourtOfEnquiryDetails"))
                HasMaritimeAccidentOrCourtOfEnquiryDetails.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_HasMaritimeAccidentOrCourtOfEnquiryDetails");

            // Reference1CompanyName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference1CompanyName"))
                    Reference1CompanyName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference1CompanyName");
            if (Form.ContainsKey("z_Reference1CompanyName"))
                Reference1CompanyName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference1CompanyName");

            // Reference1ContactPersonName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference1ContactPersonName"))
                    Reference1ContactPersonName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference1ContactPersonName");
            if (Form.ContainsKey("z_Reference1ContactPersonName"))
                Reference1ContactPersonName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference1ContactPersonName");

            // Reference1CompanyAddress
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference1CompanyAddress"))
                    Reference1CompanyAddress.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference1CompanyAddress");
            if (Form.ContainsKey("z_Reference1CompanyAddress"))
                Reference1CompanyAddress.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference1CompanyAddress");

            // Reference1CompanyCountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference1CompanyCountryID"))
                    Reference1CompanyCountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference1CompanyCountryID");
            if (Form.ContainsKey("z_Reference1CompanyCountryID"))
                Reference1CompanyCountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference1CompanyCountryID");

            // Reference1CompanyTelephone
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference1CompanyTelephone"))
                    Reference1CompanyTelephone.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference1CompanyTelephone");
            if (Form.ContainsKey("z_Reference1CompanyTelephone"))
                Reference1CompanyTelephone.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference1CompanyTelephone");

            // Reference2CompanyName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference2CompanyName"))
                    Reference2CompanyName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference2CompanyName");
            if (Form.ContainsKey("z_Reference2CompanyName"))
                Reference2CompanyName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference2CompanyName");

            // Reference2ContactPersonName
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference2ContactPersonName"))
                    Reference2ContactPersonName.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference2ContactPersonName");
            if (Form.ContainsKey("z_Reference2ContactPersonName"))
                Reference2ContactPersonName.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference2ContactPersonName");

            // Reference2CompanyAddress
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference2CompanyAddress"))
                    Reference2CompanyAddress.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference2CompanyAddress");
            if (Form.ContainsKey("z_Reference2CompanyAddress"))
                Reference2CompanyAddress.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference2CompanyAddress");

            // Reference2CompanyCountryID
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference2CompanyCountryID"))
                    Reference2CompanyCountryID.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference2CompanyCountryID");
            if (Form.ContainsKey("z_Reference2CompanyCountryID"))
                Reference2CompanyCountryID.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference2CompanyCountryID");

            // Reference2CompanyTelephone
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_Reference2CompanyTelephone"))
                    Reference2CompanyTelephone.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_Reference2CompanyTelephone");
            if (Form.ContainsKey("z_Reference2CompanyTelephone"))
                Reference2CompanyTelephone.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_Reference2CompanyTelephone");

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

            // RevisedReason
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_RevisedReason"))
                    RevisedReason.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_RevisedReason");
            if (Form.ContainsKey("z_RevisedReason"))
                RevisedReason.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_RevisedReason");

            // RevisedDateTime
            if (!IsAddOrEdit)
                if (Form.ContainsKey("x_RevisedDateTime"))
                    RevisedDateTime.AdvancedSearch.SearchValue = CurrentForm.GetValue("x_RevisedDateTime");
            if (Form.ContainsKey("z_RevisedDateTime"))
                RevisedDateTime.AdvancedSearch.SearchOperator = CurrentForm.GetValue("z_RevisedDateTime");
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
            FirstName.SetDbValue(row["FirstName"]);
            MiddleName.SetDbValue(row["MiddleName"]);
            LastName.SetDbValue(row["LastName"]);
            RequiredPhoto.Upload.DbValue = row["RequiredPhoto"];
            RequiredPhoto.SetDbValue(RequiredPhoto.Upload.DbValue);
            VisaPhoto.Upload.DbValue = row["VisaPhoto"];
            VisaPhoto.SetDbValue(VisaPhoto.Upload.DbValue);
            Nationality_CountryID.SetDbValue(row["Nationality_CountryID"]);
            CountryOfOrigin_CountryID.SetDbValue(row["CountryOfOrigin_CountryID"]);
            DateOfBirth.SetDbValue(row["DateOfBirth"]);
            CityOfBirth.SetDbValue(row["CityOfBirth"]);
            MaritalStatus.SetDbValue(row["MaritalStatus"]);
            Gender.SetDbValue(row["Gender"]);
            ReligionID.SetDbValue(row["ReligionID"]);
            BloodType.SetDbValue(row["BloodType"]);
            RankAppliedFor_RankID.SetDbValue(row["RankAppliedFor_RankID"]);
            WillAcceptLowRank.SetDbValue((ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"));
            AvailableFrom.SetDbValue(row["AvailableFrom"]);
            AvailableUntil.SetDbValue(row["AvailableUntil"]);
            PrimaryAddressDetail.SetDbValue(row["PrimaryAddressDetail"]);
            PrimaryAddressCity.SetDbValue(row["PrimaryAddressCity"]);
            PrimaryAddressState.SetDbValue(row["PrimaryAddressState"]);
            PrimaryAddressNearestAirport.SetDbValue(row["PrimaryAddressNearestAirport"]);
            PrimaryAddressPostCode.SetDbValue(row["PrimaryAddressPostCode"]);
            PrimaryAddressCountryID.SetDbValue(row["PrimaryAddressCountryID"]);
            PrimaryAddressHomeTel.SetDbValue(row["PrimaryAddressHomeTel"]);
            PrimaryAddressFax.SetDbValue(row["PrimaryAddressFax"]);
            AlternativeAddressDetail.SetDbValue(row["AlternativeAddressDetail"]);
            AlternativeAddressCity.SetDbValue(row["AlternativeAddressCity"]);
            AlternativeAddressState.SetDbValue(row["AlternativeAddressState"]);
            AlternativeAddressHomeTel.SetDbValue(row["AlternativeAddressHomeTel"]);
            AlternativeAddressPostCode.SetDbValue(row["AlternativeAddressPostCode"]);
            AlternativeAddressCountryID.SetDbValue(row["AlternativeAddressCountryID"]);
            MobileNumber.SetDbValue(row["MobileNumber"]);
            _Email.SetDbValue(row["Email"]);
            ContactMethodEmail.SetDbValue((ConvertToBool(row["ContactMethodEmail"]) ? "1" : "0"));
            ContactMethodFax.SetDbValue((ConvertToBool(row["ContactMethodFax"]) ? "1" : "0"));
            ContactMethodMobilePhone.SetDbValue((ConvertToBool(row["ContactMethodMobilePhone"]) ? "1" : "0"));
            ContactMethodHomePhone.SetDbValue((ConvertToBool(row["ContactMethodHomePhone"]) ? "1" : "0"));
            ContactMethodPost.SetDbValue((ConvertToBool(row["ContactMethodPost"]) ? "1" : "0"));
            CollarSize.SetDbValue(IsNull(row["CollarSize"]) ? DbNullValue : ConvertToDouble(row["CollarSize"]));
            ChestSize.SetDbValue(IsNull(row["ChestSize"]) ? DbNullValue : ConvertToDouble(row["ChestSize"]));
            WaistSize.SetDbValue(IsNull(row["WaistSize"]) ? DbNullValue : ConvertToDouble(row["WaistSize"]));
            InsideLegSize.SetDbValue(IsNull(row["InsideLegSize"]) ? DbNullValue : ConvertToDouble(row["InsideLegSize"]));
            CapSize.SetDbValue(IsNull(row["CapSize"]) ? DbNullValue : ConvertToDouble(row["CapSize"]));
            SweaterSize_ClothesSizeID.SetDbValue(row["SweaterSize_ClothesSizeID"]);
            BoilersuitSize_ClothesSizeID.SetDbValue(row["BoilersuitSize_ClothesSizeID"]);
            SocialSecurityNumber.SetDbValue(row["SocialSecurityNumber"]);
            SocialSecurityIssuingCountryID.SetDbValue(row["SocialSecurityIssuingCountryID"]);
            SocialSecurityImage.Upload.DbValue = row["SocialSecurityImage"];
            SocialSecurityImage.SetDbValue(SocialSecurityImage.Upload.DbValue);
            PersonalTaxNumber.SetDbValue(row["PersonalTaxNumber"]);
            PersonalTaxIssuingCountryID.SetDbValue(row["PersonalTaxIssuingCountryID"]);
            PersonalTaxImage.Upload.DbValue = row["PersonalTaxImage"];
            PersonalTaxImage.SetDbValue(PersonalTaxImage.Upload.DbValue);
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
            NomineeValidVisa.SetDbValue(row["NomineeValidVisa"]);
            BankName.SetDbValue(row["BankName"]);
            BankAddress.SetDbValue(row["BankAddress"]);
            BankAccountName.SetDbValue(row["BankAccountName"]);
            BankAccountNumber.SetDbValue(row["BankAccountNumber"]);
            BankSortCode.SetDbValue(row["BankSortCode"]);
            MNOPF.SetDbValue(row["MNOPF"]);
            MembershipNumber.SetDbValue(row["MembershipNumber"]);
            NationalInsuranceNumber.SetDbValue(row["NationalInsuranceNumber"]);
            AVC.SetDbValue(row["AVC"]);
            ForeignVisaHasBeenDenied.SetDbValue((ConvertToBool(row["ForeignVisaHasBeenDenied"]) ? "1" : "0"));
            ForeignVisaDenied_CountryID.SetDbValue(row["ForeignVisaDenied_CountryID"]);
            ForeignVisaDeniedReason.SetDbValue(row["ForeignVisaDeniedReason"]);
            HasMaritimeAccidentOrCourtOfEnquiry.SetDbValue((ConvertToBool(row["HasMaritimeAccidentOrCourtOfEnquiry"]) ? "1" : "0"));
            HasMaritimeAccidentOrCourtOfEnquiryDetails.SetDbValue(row["HasMaritimeAccidentOrCourtOfEnquiryDetails"]);
            Reference1CompanyName.SetDbValue(row["Reference1CompanyName"]);
            Reference1ContactPersonName.SetDbValue(row["Reference1ContactPersonName"]);
            Reference1CompanyAddress.SetDbValue(row["Reference1CompanyAddress"]);
            Reference1CompanyCountryID.SetDbValue(row["Reference1CompanyCountryID"]);
            Reference1CompanyTelephone.SetDbValue(row["Reference1CompanyTelephone"]);
            Reference2CompanyName.SetDbValue(row["Reference2CompanyName"]);
            Reference2ContactPersonName.SetDbValue(row["Reference2ContactPersonName"]);
            Reference2CompanyAddress.SetDbValue(row["Reference2CompanyAddress"]);
            Reference2CompanyCountryID.SetDbValue(row["Reference2CompanyCountryID"]);
            Reference2CompanyTelephone.SetDbValue(row["Reference2CompanyTelephone"]);
            EmployeeStatus.SetDbValue(row["EmployeeStatus"]);
            FormSubmittedDateTime.SetDbValue(row["FormSubmittedDateTime"]);
            ActiveDescription.SetDbValue(row["ActiveDescription"]);
            CreatedByUserID.SetDbValue(row["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(row["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(row["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(row["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(row["MTUserID"]);
            DocumentCheckDateTime.SetDbValue(row["DocumentCheckDateTime"]);
            InterviewManagerDateTime.SetDbValue(row["InterviewManagerDateTime"]);
            InterviewGMDateTime.SetDbValue(row["InterviewGMDateTime"]);
            MCUScheduleDateTime.SetDbValue(row["MCUScheduleDateTime"]);
            RejectedReason.SetDbValue(row["RejectedReason"]);
            RejectedDateTime.SetDbValue(row["RejectedDateTime"]);
            Status.SetDbValue(row["Status"]);
            Reason.SetDbValue(row["Reason"]);
            Weight.SetDbValue(row["Weight"]);
            Height.SetDbValue(row["Height"]);
            CoverallSize.SetDbValue(row["CoverallSize"]);
            SafetyShoesSize.SetDbValue(row["SafetyShoesSize"]);
            ShirtSize.SetDbValue(row["ShirtSize"]);
            TrousersSize.SetDbValue(row["TrousersSize"]);
            NSSF_Health_Number.SetDbValue(row["NSSF_Health_Number"]);
            NSSF_Occupation_Number.SetDbValue(row["NSSF_Occupation_Number"]);
            FinalAcceptedDate.SetDbValue(row["FinalAcceptedDate"]);
            Reference1CompanyTelephoneCode_CountryID.SetDbValue(row["Reference1CompanyTelephoneCode_CountryID"]);
            Reference2CompanyTelephoneCode_CountryID.SetDbValue(row["Reference2CompanyTelephoneCode_CountryID"]);
            MobileNumberCode_CountryID.SetDbValue(row["MobileNumberCode_CountryID"]);
            PrimaryAddressHomeTelCode_CountryID.SetDbValue(row["PrimaryAddressHomeTelCode_CountryID"]);
            AlternativeAddressHomeTelCode_CountryID.SetDbValue(row["AlternativeAddressHomeTelCode_CountryID"]);
            NomineeAddressHomeTelCode_CountryID.SetDbValue(row["NomineeAddressHomeTelCode_CountryID"]);
            NomineeMobileNumberCode_CountryID.SetDbValue(row["NomineeMobileNumberCode_CountryID"]);
            RevisedReason.SetDbValue(row["RevisedReason"]);
            RevisedDateTime.SetDbValue(row["RevisedDateTime"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("IndividualCodeNumber", IndividualCodeNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("FirstName", FirstName.DefaultValue ?? DbNullValue); // DN
            row.Add("MiddleName", MiddleName.DefaultValue ?? DbNullValue); // DN
            row.Add("LastName", LastName.DefaultValue ?? DbNullValue); // DN
            row.Add("RequiredPhoto", RequiredPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("VisaPhoto", VisaPhoto.DefaultValue ?? DbNullValue); // DN
            row.Add("Nationality_CountryID", Nationality_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("CountryOfOrigin_CountryID", CountryOfOrigin_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("DateOfBirth", DateOfBirth.DefaultValue ?? DbNullValue); // DN
            row.Add("CityOfBirth", CityOfBirth.DefaultValue ?? DbNullValue); // DN
            row.Add("MaritalStatus", MaritalStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("Gender", Gender.DefaultValue ?? DbNullValue); // DN
            row.Add("ReligionID", ReligionID.DefaultValue ?? DbNullValue); // DN
            row.Add("BloodType", BloodType.DefaultValue ?? DbNullValue); // DN
            row.Add("RankAppliedFor_RankID", RankAppliedFor_RankID.DefaultValue ?? DbNullValue); // DN
            row.Add("WillAcceptLowRank", WillAcceptLowRank.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableFrom", AvailableFrom.DefaultValue ?? DbNullValue); // DN
            row.Add("AvailableUntil", AvailableUntil.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressDetail", PrimaryAddressDetail.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressCity", PrimaryAddressCity.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressState", PrimaryAddressState.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressNearestAirport", PrimaryAddressNearestAirport.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressPostCode", PrimaryAddressPostCode.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressCountryID", PrimaryAddressCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressHomeTel", PrimaryAddressHomeTel.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressFax", PrimaryAddressFax.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressDetail", AlternativeAddressDetail.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressCity", AlternativeAddressCity.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressState", AlternativeAddressState.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressHomeTel", AlternativeAddressHomeTel.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressPostCode", AlternativeAddressPostCode.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressCountryID", AlternativeAddressCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("MobileNumber", MobileNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("ContactMethodEmail", ContactMethodEmail.DefaultValue ?? DbNullValue); // DN
            row.Add("ContactMethodFax", ContactMethodFax.DefaultValue ?? DbNullValue); // DN
            row.Add("ContactMethodMobilePhone", ContactMethodMobilePhone.DefaultValue ?? DbNullValue); // DN
            row.Add("ContactMethodHomePhone", ContactMethodHomePhone.DefaultValue ?? DbNullValue); // DN
            row.Add("ContactMethodPost", ContactMethodPost.DefaultValue ?? DbNullValue); // DN
            row.Add("CollarSize", CollarSize.DefaultValue ?? DbNullValue); // DN
            row.Add("ChestSize", ChestSize.DefaultValue ?? DbNullValue); // DN
            row.Add("WaistSize", WaistSize.DefaultValue ?? DbNullValue); // DN
            row.Add("InsideLegSize", InsideLegSize.DefaultValue ?? DbNullValue); // DN
            row.Add("CapSize", CapSize.DefaultValue ?? DbNullValue); // DN
            row.Add("SweaterSize_ClothesSizeID", SweaterSize_ClothesSizeID.DefaultValue ?? DbNullValue); // DN
            row.Add("BoilersuitSize_ClothesSizeID", BoilersuitSize_ClothesSizeID.DefaultValue ?? DbNullValue); // DN
            row.Add("SocialSecurityNumber", SocialSecurityNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("SocialSecurityIssuingCountryID", SocialSecurityIssuingCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("SocialSecurityImage", SocialSecurityImage.DefaultValue ?? DbNullValue); // DN
            row.Add("PersonalTaxNumber", PersonalTaxNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("PersonalTaxIssuingCountryID", PersonalTaxIssuingCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("PersonalTaxImage", PersonalTaxImage.DefaultValue ?? DbNullValue); // DN
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
            row.Add("NomineeValidVisa", NomineeValidVisa.DefaultValue ?? DbNullValue); // DN
            row.Add("BankName", BankName.DefaultValue ?? DbNullValue); // DN
            row.Add("BankAddress", BankAddress.DefaultValue ?? DbNullValue); // DN
            row.Add("BankAccountName", BankAccountName.DefaultValue ?? DbNullValue); // DN
            row.Add("BankAccountNumber", BankAccountNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("BankSortCode", BankSortCode.DefaultValue ?? DbNullValue); // DN
            row.Add("MNOPF", MNOPF.DefaultValue ?? DbNullValue); // DN
            row.Add("MembershipNumber", MembershipNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("NationalInsuranceNumber", NationalInsuranceNumber.DefaultValue ?? DbNullValue); // DN
            row.Add("AVC", AVC.DefaultValue ?? DbNullValue); // DN
            row.Add("ForeignVisaHasBeenDenied", ForeignVisaHasBeenDenied.DefaultValue ?? DbNullValue); // DN
            row.Add("ForeignVisaDenied_CountryID", ForeignVisaDenied_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("ForeignVisaDeniedReason", ForeignVisaDeniedReason.DefaultValue ?? DbNullValue); // DN
            row.Add("HasMaritimeAccidentOrCourtOfEnquiry", HasMaritimeAccidentOrCourtOfEnquiry.DefaultValue ?? DbNullValue); // DN
            row.Add("HasMaritimeAccidentOrCourtOfEnquiryDetails", HasMaritimeAccidentOrCourtOfEnquiryDetails.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyName", Reference1CompanyName.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1ContactPersonName", Reference1ContactPersonName.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyAddress", Reference1CompanyAddress.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyCountryID", Reference1CompanyCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyTelephone", Reference1CompanyTelephone.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyName", Reference2CompanyName.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2ContactPersonName", Reference2ContactPersonName.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyAddress", Reference2CompanyAddress.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyCountryID", Reference2CompanyCountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyTelephone", Reference2CompanyTelephone.DefaultValue ?? DbNullValue); // DN
            row.Add("EmployeeStatus", EmployeeStatus.DefaultValue ?? DbNullValue); // DN
            row.Add("FormSubmittedDateTime", FormSubmittedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("ActiveDescription", ActiveDescription.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedByUserID", CreatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("CreatedDateTime", CreatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedByUserID", LastUpdatedByUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("LastUpdatedDateTime", LastUpdatedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("MTUserID", MTUserID.DefaultValue ?? DbNullValue); // DN
            row.Add("DocumentCheckDateTime", DocumentCheckDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewManagerDateTime", InterviewManagerDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("InterviewGMDateTime", InterviewGMDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("MCUScheduleDateTime", MCUScheduleDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("RejectedReason", RejectedReason.DefaultValue ?? DbNullValue); // DN
            row.Add("RejectedDateTime", RejectedDateTime.DefaultValue ?? DbNullValue); // DN
            row.Add("Status", Status.DefaultValue ?? DbNullValue); // DN
            row.Add("Reason", Reason.DefaultValue ?? DbNullValue); // DN
            row.Add("Weight", Weight.DefaultValue ?? DbNullValue); // DN
            row.Add("Height", Height.DefaultValue ?? DbNullValue); // DN
            row.Add("CoverallSize", CoverallSize.DefaultValue ?? DbNullValue); // DN
            row.Add("SafetyShoesSize", SafetyShoesSize.DefaultValue ?? DbNullValue); // DN
            row.Add("ShirtSize", ShirtSize.DefaultValue ?? DbNullValue); // DN
            row.Add("TrousersSize", TrousersSize.DefaultValue ?? DbNullValue); // DN
            row.Add("NSSF_Health_Number", NSSF_Health_Number.DefaultValue ?? DbNullValue); // DN
            row.Add("NSSF_Occupation_Number", NSSF_Occupation_Number.DefaultValue ?? DbNullValue); // DN
            row.Add("FinalAcceptedDate", FinalAcceptedDate.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference1CompanyTelephoneCode_CountryID", Reference1CompanyTelephoneCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("Reference2CompanyTelephoneCode_CountryID", Reference2CompanyTelephoneCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("MobileNumberCode_CountryID", MobileNumberCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("PrimaryAddressHomeTelCode_CountryID", PrimaryAddressHomeTelCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("AlternativeAddressHomeTelCode_CountryID", AlternativeAddressHomeTelCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeAddressHomeTelCode_CountryID", NomineeAddressHomeTelCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("NomineeMobileNumberCode_CountryID", NomineeMobileNumberCode_CountryID.DefaultValue ?? DbNullValue); // DN
            row.Add("RevisedReason", RevisedReason.DefaultValue ?? DbNullValue); // DN
            row.Add("RevisedDateTime", RevisedDateTime.DefaultValue ?? DbNullValue); // DN
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

            // FirstName
            FirstName.RowCssClass = "row";

            // MiddleName
            MiddleName.RowCssClass = "row";

            // LastName
            LastName.RowCssClass = "row";

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

            // MaritalStatus
            MaritalStatus.RowCssClass = "row";

            // Gender
            Gender.RowCssClass = "row";

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

            // PrimaryAddressState
            PrimaryAddressState.RowCssClass = "row";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.RowCssClass = "row";

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.RowCssClass = "row";

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.RowCssClass = "row";

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.RowCssClass = "row";

            // PrimaryAddressFax
            PrimaryAddressFax.RowCssClass = "row";

            // AlternativeAddressDetail
            AlternativeAddressDetail.RowCssClass = "row";

            // AlternativeAddressCity
            AlternativeAddressCity.RowCssClass = "row";

            // AlternativeAddressState
            AlternativeAddressState.RowCssClass = "row";

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

            // ContactMethodEmail
            ContactMethodEmail.RowCssClass = "row";

            // ContactMethodFax
            ContactMethodFax.RowCssClass = "row";

            // ContactMethodMobilePhone
            ContactMethodMobilePhone.RowCssClass = "row";

            // ContactMethodHomePhone
            ContactMethodHomePhone.RowCssClass = "row";

            // ContactMethodPost
            ContactMethodPost.RowCssClass = "row";

            // CollarSize
            CollarSize.RowCssClass = "row";

            // ChestSize
            ChestSize.RowCssClass = "row";

            // WaistSize
            WaistSize.RowCssClass = "row";

            // InsideLegSize
            InsideLegSize.RowCssClass = "row";

            // CapSize
            CapSize.RowCssClass = "row";

            // SweaterSize_ClothesSizeID
            SweaterSize_ClothesSizeID.RowCssClass = "row";

            // BoilersuitSize_ClothesSizeID
            BoilersuitSize_ClothesSizeID.RowCssClass = "row";

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

            // NomineeValidVisa
            NomineeValidVisa.RowCssClass = "row";

            // BankName
            BankName.RowCssClass = "row";

            // BankAddress
            BankAddress.RowCssClass = "row";

            // BankAccountName
            BankAccountName.RowCssClass = "row";

            // BankAccountNumber
            BankAccountNumber.RowCssClass = "row";

            // BankSortCode
            BankSortCode.RowCssClass = "row";

            // MNOPF
            MNOPF.RowCssClass = "row";

            // MembershipNumber
            MembershipNumber.RowCssClass = "row";

            // NationalInsuranceNumber
            NationalInsuranceNumber.RowCssClass = "row";

            // AVC
            AVC.RowCssClass = "row";

            // ForeignVisaHasBeenDenied
            ForeignVisaHasBeenDenied.RowCssClass = "row";

            // ForeignVisaDenied_CountryID
            ForeignVisaDenied_CountryID.RowCssClass = "row";

            // ForeignVisaDeniedReason
            ForeignVisaDeniedReason.RowCssClass = "row";

            // HasMaritimeAccidentOrCourtOfEnquiry
            HasMaritimeAccidentOrCourtOfEnquiry.RowCssClass = "row";

            // HasMaritimeAccidentOrCourtOfEnquiryDetails
            HasMaritimeAccidentOrCourtOfEnquiryDetails.RowCssClass = "row";

            // Reference1CompanyName
            Reference1CompanyName.RowCssClass = "row";

            // Reference1ContactPersonName
            Reference1ContactPersonName.RowCssClass = "row";

            // Reference1CompanyAddress
            Reference1CompanyAddress.RowCssClass = "row";

            // Reference1CompanyCountryID
            Reference1CompanyCountryID.RowCssClass = "row";

            // Reference1CompanyTelephone
            Reference1CompanyTelephone.RowCssClass = "row";

            // Reference2CompanyName
            Reference2CompanyName.RowCssClass = "row";

            // Reference2ContactPersonName
            Reference2ContactPersonName.RowCssClass = "row";

            // Reference2CompanyAddress
            Reference2CompanyAddress.RowCssClass = "row";

            // Reference2CompanyCountryID
            Reference2CompanyCountryID.RowCssClass = "row";

            // Reference2CompanyTelephone
            Reference2CompanyTelephone.RowCssClass = "row";

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

            // DocumentCheckDateTime
            DocumentCheckDateTime.RowCssClass = "row";

            // InterviewManagerDateTime
            InterviewManagerDateTime.RowCssClass = "row";

            // InterviewGMDateTime
            InterviewGMDateTime.RowCssClass = "row";

            // MCUScheduleDateTime
            MCUScheduleDateTime.RowCssClass = "row";

            // RejectedReason
            RejectedReason.RowCssClass = "row";

            // RejectedDateTime
            RejectedDateTime.RowCssClass = "row";

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

            // NSSF_Health_Number
            NSSF_Health_Number.RowCssClass = "row";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.RowCssClass = "row";

            // FinalAcceptedDate
            FinalAcceptedDate.RowCssClass = "row";

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.RowCssClass = "row";

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.RowCssClass = "row";

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

            // RevisedReason
            RevisedReason.RowCssClass = "row";

            // RevisedDateTime
            RevisedDateTime.RowCssClass = "row";

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

                // MaritalStatus
                if (!Empty(MaritalStatus.CurrentValue)) {
                    MaritalStatus.ViewValue = MaritalStatus.HighlightLookup(ConvertToString(MaritalStatus.CurrentValue), MaritalStatus.OptionCaption(ConvertToString(MaritalStatus.CurrentValue)));
                } else {
                    MaritalStatus.ViewValue = DbNullValue;
                }
                MaritalStatus.ViewCustomAttributes = "";

                // Gender
                if (!Empty(Gender.CurrentValue)) {
                    Gender.ViewValue = Gender.HighlightLookup(ConvertToString(Gender.CurrentValue), Gender.OptionCaption(ConvertToString(Gender.CurrentValue)));
                } else {
                    Gender.ViewValue = DbNullValue;
                }
                Gender.ViewCustomAttributes = "";

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

                // PrimaryAddressState
                PrimaryAddressState.ViewValue = ConvertToString(PrimaryAddressState.CurrentValue); // DN
                PrimaryAddressState.ViewCustomAttributes = "";

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.ViewValue = ConvertToString(PrimaryAddressNearestAirport.CurrentValue); // DN
                PrimaryAddressNearestAirport.ViewCustomAttributes = "";

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

                // PrimaryAddressFax
                PrimaryAddressFax.ViewValue = ConvertToString(PrimaryAddressFax.CurrentValue); // DN
                PrimaryAddressFax.ViewCustomAttributes = "";

                // AlternativeAddressDetail
                AlternativeAddressDetail.ViewValue = AlternativeAddressDetail.CurrentValue;
                AlternativeAddressDetail.ViewCustomAttributes = "";

                // AlternativeAddressCity
                AlternativeAddressCity.ViewValue = ConvertToString(AlternativeAddressCity.CurrentValue); // DN
                AlternativeAddressCity.ViewCustomAttributes = "";

                // AlternativeAddressState
                AlternativeAddressState.ViewValue = ConvertToString(AlternativeAddressState.CurrentValue); // DN
                AlternativeAddressState.ViewCustomAttributes = "";

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

                // ContactMethodEmail
                if (ConvertToBool(ContactMethodEmail.CurrentValue)) {
                    ContactMethodEmail.ViewValue = ContactMethodEmail.TagCaption(1) != "" ? ContactMethodEmail.TagCaption(1) : "Yes";
                } else {
                    ContactMethodEmail.ViewValue = ContactMethodEmail.TagCaption(2) != "" ? ContactMethodEmail.TagCaption(2) : "No";
                }
                ContactMethodEmail.ViewCustomAttributes = "";

                // ContactMethodFax
                if (ConvertToBool(ContactMethodFax.CurrentValue)) {
                    ContactMethodFax.ViewValue = ContactMethodFax.TagCaption(1) != "" ? ContactMethodFax.TagCaption(1) : "Yes";
                } else {
                    ContactMethodFax.ViewValue = ContactMethodFax.TagCaption(2) != "" ? ContactMethodFax.TagCaption(2) : "No";
                }
                ContactMethodFax.ViewCustomAttributes = "";

                // ContactMethodMobilePhone
                if (ConvertToBool(ContactMethodMobilePhone.CurrentValue)) {
                    ContactMethodMobilePhone.ViewValue = ContactMethodMobilePhone.TagCaption(1) != "" ? ContactMethodMobilePhone.TagCaption(1) : "Yes";
                } else {
                    ContactMethodMobilePhone.ViewValue = ContactMethodMobilePhone.TagCaption(2) != "" ? ContactMethodMobilePhone.TagCaption(2) : "No";
                }
                ContactMethodMobilePhone.ViewCustomAttributes = "";

                // ContactMethodHomePhone
                if (ConvertToBool(ContactMethodHomePhone.CurrentValue)) {
                    ContactMethodHomePhone.ViewValue = ContactMethodHomePhone.TagCaption(1) != "" ? ContactMethodHomePhone.TagCaption(1) : "Yes";
                } else {
                    ContactMethodHomePhone.ViewValue = ContactMethodHomePhone.TagCaption(2) != "" ? ContactMethodHomePhone.TagCaption(2) : "No";
                }
                ContactMethodHomePhone.ViewCustomAttributes = "";

                // ContactMethodPost
                if (ConvertToBool(ContactMethodPost.CurrentValue)) {
                    ContactMethodPost.ViewValue = ContactMethodPost.TagCaption(1) != "" ? ContactMethodPost.TagCaption(1) : "Yes";
                } else {
                    ContactMethodPost.ViewValue = ContactMethodPost.TagCaption(2) != "" ? ContactMethodPost.TagCaption(2) : "No";
                }
                ContactMethodPost.ViewCustomAttributes = "";

                // CollarSize
                CollarSize.ViewValue = CollarSize.CurrentValue;
                CollarSize.ViewValue = FormatNumber(CollarSize.ViewValue, CollarSize.FormatPattern);
                CollarSize.ViewCustomAttributes = "";

                // ChestSize
                ChestSize.ViewValue = ChestSize.CurrentValue;
                ChestSize.ViewValue = FormatNumber(ChestSize.ViewValue, ChestSize.FormatPattern);
                ChestSize.ViewCustomAttributes = "";

                // WaistSize
                WaistSize.ViewValue = WaistSize.CurrentValue;
                WaistSize.ViewValue = FormatNumber(WaistSize.ViewValue, WaistSize.FormatPattern);
                WaistSize.ViewCustomAttributes = "";

                // InsideLegSize
                InsideLegSize.ViewValue = InsideLegSize.CurrentValue;
                InsideLegSize.ViewValue = FormatNumber(InsideLegSize.ViewValue, InsideLegSize.FormatPattern);
                InsideLegSize.ViewCustomAttributes = "";

                // CapSize
                CapSize.ViewValue = CapSize.CurrentValue;
                CapSize.ViewValue = FormatNumber(CapSize.ViewValue, CapSize.FormatPattern);
                CapSize.ViewCustomAttributes = "";

                // SweaterSize_ClothesSizeID
                curVal = ConvertToString(SweaterSize_ClothesSizeID.CurrentValue);
                if (!Empty(curVal)) {
                    if (SweaterSize_ClothesSizeID.Lookup != null && IsDictionary(SweaterSize_ClothesSizeID.Lookup?.Options) && SweaterSize_ClothesSizeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        SweaterSize_ClothesSizeID.ViewValue = SweaterSize_ClothesSizeID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", SweaterSize_ClothesSizeID.CurrentValue, DataType.Number, "");
                        sqlWrk = SweaterSize_ClothesSizeID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && SweaterSize_ClothesSizeID.Lookup != null) { // Lookup values found
                            var listwrk = SweaterSize_ClothesSizeID.Lookup?.RenderViewRow(rswrk[0]);
                            SweaterSize_ClothesSizeID.ViewValue = SweaterSize_ClothesSizeID.HighlightLookup(ConvertToString(rswrk[0]), SweaterSize_ClothesSizeID.DisplayValue(listwrk));
                        } else {
                            SweaterSize_ClothesSizeID.ViewValue = FormatNumber(SweaterSize_ClothesSizeID.CurrentValue, SweaterSize_ClothesSizeID.FormatPattern);
                        }
                    }
                } else {
                    SweaterSize_ClothesSizeID.ViewValue = DbNullValue;
                }
                SweaterSize_ClothesSizeID.ViewCustomAttributes = "";

                // BoilersuitSize_ClothesSizeID
                curVal = ConvertToString(BoilersuitSize_ClothesSizeID.CurrentValue);
                if (!Empty(curVal)) {
                    if (BoilersuitSize_ClothesSizeID.Lookup != null && IsDictionary(BoilersuitSize_ClothesSizeID.Lookup?.Options) && BoilersuitSize_ClothesSizeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        BoilersuitSize_ClothesSizeID.ViewValue = BoilersuitSize_ClothesSizeID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", BoilersuitSize_ClothesSizeID.CurrentValue, DataType.Number, "");
                        sqlWrk = BoilersuitSize_ClothesSizeID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && BoilersuitSize_ClothesSizeID.Lookup != null) { // Lookup values found
                            var listwrk = BoilersuitSize_ClothesSizeID.Lookup?.RenderViewRow(rswrk[0]);
                            BoilersuitSize_ClothesSizeID.ViewValue = BoilersuitSize_ClothesSizeID.HighlightLookup(ConvertToString(rswrk[0]), BoilersuitSize_ClothesSizeID.DisplayValue(listwrk));
                        } else {
                            BoilersuitSize_ClothesSizeID.ViewValue = FormatNumber(BoilersuitSize_ClothesSizeID.CurrentValue, BoilersuitSize_ClothesSizeID.FormatPattern);
                        }
                    }
                } else {
                    BoilersuitSize_ClothesSizeID.ViewValue = DbNullValue;
                }
                BoilersuitSize_ClothesSizeID.ViewCustomAttributes = "";

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
                    PersonalTaxImage.ViewValue = PersonalTaxImage.Upload.DbValue;
                } else {
                    PersonalTaxImage.ViewValue = "";
                }
                PersonalTaxImage.ViewCustomAttributes = "";

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

                // NomineeValidVisa
                NomineeValidVisa.ViewValue = ConvertToString(NomineeValidVisa.CurrentValue); // DN
                NomineeValidVisa.ViewCustomAttributes = "";

                // BankName
                BankName.ViewValue = ConvertToString(BankName.CurrentValue); // DN
                BankName.ViewCustomAttributes = "";

                // BankAddress
                BankAddress.ViewValue = BankAddress.CurrentValue;
                BankAddress.ViewCustomAttributes = "";

                // BankAccountName
                BankAccountName.ViewValue = ConvertToString(BankAccountName.CurrentValue); // DN
                BankAccountName.ViewCustomAttributes = "";

                // BankAccountNumber
                BankAccountNumber.ViewValue = ConvertToString(BankAccountNumber.CurrentValue); // DN
                BankAccountNumber.ViewCustomAttributes = "";

                // BankSortCode
                BankSortCode.ViewValue = ConvertToString(BankSortCode.CurrentValue); // DN
                BankSortCode.ViewCustomAttributes = "";

                // MNOPF
                MNOPF.ViewValue = ConvertToString(MNOPF.CurrentValue); // DN
                MNOPF.ViewCustomAttributes = "";

                // MembershipNumber
                MembershipNumber.ViewValue = ConvertToString(MembershipNumber.CurrentValue); // DN
                MembershipNumber.ViewCustomAttributes = "";

                // NationalInsuranceNumber
                NationalInsuranceNumber.ViewValue = ConvertToString(NationalInsuranceNumber.CurrentValue); // DN
                NationalInsuranceNumber.ViewCustomAttributes = "";

                // AVC
                AVC.ViewValue = ConvertToString(AVC.CurrentValue); // DN
                AVC.ViewCustomAttributes = "";

                // ForeignVisaHasBeenDenied
                if (ConvertToBool(ForeignVisaHasBeenDenied.CurrentValue)) {
                    ForeignVisaHasBeenDenied.ViewValue = ForeignVisaHasBeenDenied.TagCaption(1) != "" ? ForeignVisaHasBeenDenied.TagCaption(1) : "Yes";
                } else {
                    ForeignVisaHasBeenDenied.ViewValue = ForeignVisaHasBeenDenied.TagCaption(2) != "" ? ForeignVisaHasBeenDenied.TagCaption(2) : "No";
                }
                ForeignVisaHasBeenDenied.ViewCustomAttributes = "";

                // ForeignVisaDenied_CountryID
                curVal = ConvertToString(ForeignVisaDenied_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (ForeignVisaDenied_CountryID.Lookup != null && IsDictionary(ForeignVisaDenied_CountryID.Lookup?.Options) && ForeignVisaDenied_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        ForeignVisaDenied_CountryID.ViewValue = ForeignVisaDenied_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", ForeignVisaDenied_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = ForeignVisaDenied_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && ForeignVisaDenied_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = ForeignVisaDenied_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            ForeignVisaDenied_CountryID.ViewValue = ForeignVisaDenied_CountryID.HighlightLookup(ConvertToString(rswrk[0]), ForeignVisaDenied_CountryID.DisplayValue(listwrk));
                        } else {
                            ForeignVisaDenied_CountryID.ViewValue = FormatNumber(ForeignVisaDenied_CountryID.CurrentValue, ForeignVisaDenied_CountryID.FormatPattern);
                        }
                    }
                } else {
                    ForeignVisaDenied_CountryID.ViewValue = DbNullValue;
                }
                ForeignVisaDenied_CountryID.ViewCustomAttributes = "";

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.ViewValue = ForeignVisaDeniedReason.CurrentValue;
                ForeignVisaDeniedReason.ViewCustomAttributes = "";

                // HasMaritimeAccidentOrCourtOfEnquiry
                if (ConvertToBool(HasMaritimeAccidentOrCourtOfEnquiry.CurrentValue)) {
                    HasMaritimeAccidentOrCourtOfEnquiry.ViewValue = HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(1) != "" ? HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(1) : "Yes";
                } else {
                    HasMaritimeAccidentOrCourtOfEnquiry.ViewValue = HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(2) != "" ? HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(2) : "No";
                }
                HasMaritimeAccidentOrCourtOfEnquiry.ViewCustomAttributes = "";

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.ViewValue = HasMaritimeAccidentOrCourtOfEnquiryDetails.CurrentValue;
                HasMaritimeAccidentOrCourtOfEnquiryDetails.ViewCustomAttributes = "";

                // Reference1CompanyName
                Reference1CompanyName.ViewValue = ConvertToString(Reference1CompanyName.CurrentValue); // DN
                Reference1CompanyName.ViewCustomAttributes = "";

                // Reference1ContactPersonName
                Reference1ContactPersonName.ViewValue = ConvertToString(Reference1ContactPersonName.CurrentValue); // DN
                Reference1ContactPersonName.ViewCustomAttributes = "";

                // Reference1CompanyAddress
                Reference1CompanyAddress.ViewValue = Reference1CompanyAddress.CurrentValue;
                Reference1CompanyAddress.ViewCustomAttributes = "";

                // Reference1CompanyCountryID
                curVal = ConvertToString(Reference1CompanyCountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (Reference1CompanyCountryID.Lookup != null && IsDictionary(Reference1CompanyCountryID.Lookup?.Options) && Reference1CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Reference1CompanyCountryID.ViewValue = Reference1CompanyCountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", Reference1CompanyCountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = Reference1CompanyCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Reference1CompanyCountryID.Lookup != null) { // Lookup values found
                            var listwrk = Reference1CompanyCountryID.Lookup?.RenderViewRow(rswrk[0]);
                            Reference1CompanyCountryID.ViewValue = Reference1CompanyCountryID.HighlightLookup(ConvertToString(rswrk[0]), Reference1CompanyCountryID.DisplayValue(listwrk));
                        } else {
                            Reference1CompanyCountryID.ViewValue = FormatNumber(Reference1CompanyCountryID.CurrentValue, Reference1CompanyCountryID.FormatPattern);
                        }
                    }
                } else {
                    Reference1CompanyCountryID.ViewValue = DbNullValue;
                }
                Reference1CompanyCountryID.ViewCustomAttributes = "";

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.ViewValue = ConvertToString(Reference1CompanyTelephone.CurrentValue); // DN
                Reference1CompanyTelephone.ViewCustomAttributes = "";

                // Reference2CompanyName
                Reference2CompanyName.ViewValue = ConvertToString(Reference2CompanyName.CurrentValue); // DN
                Reference2CompanyName.ViewCustomAttributes = "";

                // Reference2ContactPersonName
                Reference2ContactPersonName.ViewValue = ConvertToString(Reference2ContactPersonName.CurrentValue); // DN
                Reference2ContactPersonName.ViewCustomAttributes = "";

                // Reference2CompanyAddress
                Reference2CompanyAddress.ViewValue = Reference2CompanyAddress.CurrentValue;
                Reference2CompanyAddress.ViewCustomAttributes = "";

                // Reference2CompanyCountryID
                curVal = ConvertToString(Reference2CompanyCountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (Reference2CompanyCountryID.Lookup != null && IsDictionary(Reference2CompanyCountryID.Lookup?.Options) && Reference2CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Reference2CompanyCountryID.ViewValue = Reference2CompanyCountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", Reference2CompanyCountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = Reference2CompanyCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Reference2CompanyCountryID.Lookup != null) { // Lookup values found
                            var listwrk = Reference2CompanyCountryID.Lookup?.RenderViewRow(rswrk[0]);
                            Reference2CompanyCountryID.ViewValue = Reference2CompanyCountryID.HighlightLookup(ConvertToString(rswrk[0]), Reference2CompanyCountryID.DisplayValue(listwrk));
                        } else {
                            Reference2CompanyCountryID.ViewValue = FormatNumber(Reference2CompanyCountryID.CurrentValue, Reference2CompanyCountryID.FormatPattern);
                        }
                    }
                } else {
                    Reference2CompanyCountryID.ViewValue = DbNullValue;
                }
                Reference2CompanyCountryID.ViewCustomAttributes = "";

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.ViewValue = ConvertToString(Reference2CompanyTelephone.CurrentValue); // DN
                Reference2CompanyTelephone.ViewCustomAttributes = "";

                // EmployeeStatus
                EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
                EmployeeStatus.ViewCustomAttributes = "";

                // FormSubmittedDateTime
                FormSubmittedDateTime.ViewValue = FormSubmittedDateTime.CurrentValue;
                FormSubmittedDateTime.ViewValue = FormatDateTime(FormSubmittedDateTime.ViewValue, FormSubmittedDateTime.FormatPattern);
                FormSubmittedDateTime.ViewCustomAttributes = "";

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

                // DocumentCheckDateTime
                DocumentCheckDateTime.ViewValue = DocumentCheckDateTime.CurrentValue;
                DocumentCheckDateTime.ViewValue = FormatDateTime(DocumentCheckDateTime.ViewValue, DocumentCheckDateTime.FormatPattern);
                DocumentCheckDateTime.ViewCustomAttributes = "";

                // InterviewManagerDateTime
                InterviewManagerDateTime.ViewValue = InterviewManagerDateTime.CurrentValue;
                InterviewManagerDateTime.ViewValue = FormatDateTime(InterviewManagerDateTime.ViewValue, InterviewManagerDateTime.FormatPattern);
                InterviewManagerDateTime.ViewCustomAttributes = "";

                // InterviewGMDateTime
                InterviewGMDateTime.ViewValue = InterviewGMDateTime.CurrentValue;
                InterviewGMDateTime.ViewValue = FormatDateTime(InterviewGMDateTime.ViewValue, InterviewGMDateTime.FormatPattern);
                InterviewGMDateTime.ViewCustomAttributes = "";

                // MCUScheduleDateTime
                MCUScheduleDateTime.ViewValue = MCUScheduleDateTime.CurrentValue;
                MCUScheduleDateTime.ViewValue = FormatDateTime(MCUScheduleDateTime.ViewValue, MCUScheduleDateTime.FormatPattern);
                MCUScheduleDateTime.ViewCustomAttributes = "";

                // RejectedReason
                RejectedReason.ViewValue = RejectedReason.CurrentValue;
                RejectedReason.ViewCustomAttributes = "";

                // RejectedDateTime
                RejectedDateTime.ViewValue = RejectedDateTime.CurrentValue;
                RejectedDateTime.ViewValue = FormatDateTime(RejectedDateTime.ViewValue, RejectedDateTime.FormatPattern);
                RejectedDateTime.ViewCustomAttributes = "";

                // Status
                Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
                Status.ViewCustomAttributes = "";

                // Reason
                Reason.ViewValue = ConvertToString(Reason.CurrentValue); // DN
                Reason.ViewCustomAttributes = "";

                // Weight
                Weight.ViewValue = Weight.CurrentValue;
                Weight.ViewValue = FormatNumber(Weight.ViewValue, Weight.FormatPattern);
                Weight.ViewCustomAttributes = "";

                // Height
                Height.ViewValue = Height.CurrentValue;
                Height.ViewValue = FormatNumber(Height.ViewValue, Height.FormatPattern);
                Height.ViewCustomAttributes = "";

                // CoverallSize
                CoverallSize.ViewValue = ConvertToString(CoverallSize.CurrentValue); // DN
                CoverallSize.ViewCustomAttributes = "";

                // SafetyShoesSize
                SafetyShoesSize.ViewValue = SafetyShoesSize.CurrentValue;
                SafetyShoesSize.ViewValue = FormatNumber(SafetyShoesSize.ViewValue, SafetyShoesSize.FormatPattern);
                SafetyShoesSize.ViewCustomAttributes = "";

                // ShirtSize
                ShirtSize.ViewValue = ConvertToString(ShirtSize.CurrentValue); // DN
                ShirtSize.ViewCustomAttributes = "";

                // TrousersSize
                TrousersSize.ViewValue = ConvertToString(TrousersSize.CurrentValue); // DN
                TrousersSize.ViewCustomAttributes = "";

                // NSSF_Health_Number
                NSSF_Health_Number.ViewValue = ConvertToString(NSSF_Health_Number.CurrentValue); // DN
                NSSF_Health_Number.ViewCustomAttributes = "";

                // NSSF_Occupation_Number
                NSSF_Occupation_Number.ViewValue = ConvertToString(NSSF_Occupation_Number.CurrentValue); // DN
                NSSF_Occupation_Number.ViewCustomAttributes = "";

                // FinalAcceptedDate
                FinalAcceptedDate.ViewValue = FinalAcceptedDate.CurrentValue;
                FinalAcceptedDate.ViewValue = FormatDateTime(FinalAcceptedDate.ViewValue, FinalAcceptedDate.FormatPattern);
                FinalAcceptedDate.ViewCustomAttributes = "";

                // Reference1CompanyTelephoneCode_CountryID
                curVal = ConvertToString(Reference1CompanyTelephoneCode_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (Reference1CompanyTelephoneCode_CountryID.Lookup != null && IsDictionary(Reference1CompanyTelephoneCode_CountryID.Lookup?.Options) && Reference1CompanyTelephoneCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Reference1CompanyTelephoneCode_CountryID.ViewValue = Reference1CompanyTelephoneCode_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", Reference1CompanyTelephoneCode_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = Reference1CompanyTelephoneCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Reference1CompanyTelephoneCode_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = Reference1CompanyTelephoneCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            Reference1CompanyTelephoneCode_CountryID.ViewValue = Reference1CompanyTelephoneCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), Reference1CompanyTelephoneCode_CountryID.DisplayValue(listwrk));
                        } else {
                            Reference1CompanyTelephoneCode_CountryID.ViewValue = Reference1CompanyTelephoneCode_CountryID.CurrentValue;
                        }
                    }
                } else {
                    Reference1CompanyTelephoneCode_CountryID.ViewValue = DbNullValue;
                }
                Reference1CompanyTelephoneCode_CountryID.ViewCustomAttributes = "";

                // Reference2CompanyTelephoneCode_CountryID
                curVal = ConvertToString(Reference2CompanyTelephoneCode_CountryID.CurrentValue);
                if (!Empty(curVal)) {
                    if (Reference2CompanyTelephoneCode_CountryID.Lookup != null && IsDictionary(Reference2CompanyTelephoneCode_CountryID.Lookup?.Options) && Reference2CompanyTelephoneCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        Reference2CompanyTelephoneCode_CountryID.ViewValue = Reference2CompanyTelephoneCode_CountryID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", Reference2CompanyTelephoneCode_CountryID.CurrentValue, DataType.Number, "");
                        sqlWrk = Reference2CompanyTelephoneCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && Reference2CompanyTelephoneCode_CountryID.Lookup != null) { // Lookup values found
                            var listwrk = Reference2CompanyTelephoneCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                            Reference2CompanyTelephoneCode_CountryID.ViewValue = Reference2CompanyTelephoneCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), Reference2CompanyTelephoneCode_CountryID.DisplayValue(listwrk));
                        } else {
                            Reference2CompanyTelephoneCode_CountryID.ViewValue = Reference2CompanyTelephoneCode_CountryID.CurrentValue;
                        }
                    }
                } else {
                    Reference2CompanyTelephoneCode_CountryID.ViewValue = DbNullValue;
                }
                Reference2CompanyTelephoneCode_CountryID.ViewCustomAttributes = "";

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

                // RevisedReason
                RevisedReason.ViewValue = ConvertToString(RevisedReason.CurrentValue); // DN
                RevisedReason.ViewCustomAttributes = "";

                // RevisedDateTime
                RevisedDateTime.ViewValue = RevisedDateTime.CurrentValue;
                RevisedDateTime.ViewValue = FormatDateTime(RevisedDateTime.ViewValue, RevisedDateTime.FormatPattern);
                RevisedDateTime.ViewCustomAttributes = "";

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

                // MaritalStatus
                MaritalStatus.HrefValue = "";
                MaritalStatus.TooltipValue = "";

                // Gender
                Gender.HrefValue = "";
                Gender.TooltipValue = "";

                // ReligionID
                ReligionID.HrefValue = "";
                ReligionID.TooltipValue = "";

                // BloodType
                BloodType.HrefValue = "";
                BloodType.TooltipValue = "";

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

                // PrimaryAddressState
                PrimaryAddressState.HrefValue = "";
                PrimaryAddressState.TooltipValue = "";

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.HrefValue = "";
                PrimaryAddressNearestAirport.TooltipValue = "";

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.HrefValue = "";
                PrimaryAddressPostCode.TooltipValue = "";

                // PrimaryAddressCountryID
                PrimaryAddressCountryID.HrefValue = "";
                PrimaryAddressCountryID.TooltipValue = "";

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.HrefValue = "";
                PrimaryAddressHomeTel.TooltipValue = "";

                // PrimaryAddressFax
                PrimaryAddressFax.HrefValue = "";
                PrimaryAddressFax.TooltipValue = "";

                // AlternativeAddressDetail
                AlternativeAddressDetail.HrefValue = "";
                AlternativeAddressDetail.TooltipValue = "";

                // AlternativeAddressCity
                AlternativeAddressCity.HrefValue = "";
                AlternativeAddressCity.TooltipValue = "";

                // AlternativeAddressState
                AlternativeAddressState.HrefValue = "";
                AlternativeAddressState.TooltipValue = "";

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

                // ContactMethodEmail
                ContactMethodEmail.HrefValue = "";
                ContactMethodEmail.TooltipValue = "";

                // ContactMethodFax
                ContactMethodFax.HrefValue = "";
                ContactMethodFax.TooltipValue = "";

                // ContactMethodMobilePhone
                ContactMethodMobilePhone.HrefValue = "";
                ContactMethodMobilePhone.TooltipValue = "";

                // ContactMethodHomePhone
                ContactMethodHomePhone.HrefValue = "";
                ContactMethodHomePhone.TooltipValue = "";

                // ContactMethodPost
                ContactMethodPost.HrefValue = "";
                ContactMethodPost.TooltipValue = "";

                // CollarSize
                CollarSize.HrefValue = "";
                CollarSize.TooltipValue = "";

                // ChestSize
                ChestSize.HrefValue = "";
                ChestSize.TooltipValue = "";

                // WaistSize
                WaistSize.HrefValue = "";
                WaistSize.TooltipValue = "";

                // InsideLegSize
                InsideLegSize.HrefValue = "";
                InsideLegSize.TooltipValue = "";

                // CapSize
                CapSize.HrefValue = "";
                CapSize.TooltipValue = "";

                // SweaterSize_ClothesSizeID
                SweaterSize_ClothesSizeID.HrefValue = "";
                SweaterSize_ClothesSizeID.TooltipValue = "";

                // BoilersuitSize_ClothesSizeID
                BoilersuitSize_ClothesSizeID.HrefValue = "";
                BoilersuitSize_ClothesSizeID.TooltipValue = "";

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

                // NomineeFullName
                NomineeFullName.HrefValue = "";
                NomineeFullName.TooltipValue = "";

                // NomineeRelationship
                NomineeRelationship.HrefValue = "";
                NomineeRelationship.TooltipValue = "";

                // NomineeGender
                NomineeGender.HrefValue = "";
                NomineeGender.TooltipValue = "";

                // NomineeNationality_CountryID
                NomineeNationality_CountryID.HrefValue = "";
                NomineeNationality_CountryID.TooltipValue = "";

                // NomineeAddressDetail
                NomineeAddressDetail.HrefValue = "";
                NomineeAddressDetail.TooltipValue = "";

                // NomineeAddressCity
                NomineeAddressCity.HrefValue = "";
                NomineeAddressCity.TooltipValue = "";

                // NomineeAddressPostCode
                NomineeAddressPostCode.HrefValue = "";
                NomineeAddressPostCode.TooltipValue = "";

                // NomineeAddressCountryID
                NomineeAddressCountryID.HrefValue = "";
                NomineeAddressCountryID.TooltipValue = "";

                // NomineeAddressHomeTel
                NomineeAddressHomeTel.HrefValue = "";
                NomineeAddressHomeTel.TooltipValue = "";

                // NomineeEmail
                NomineeEmail.HrefValue = "";
                NomineeEmail.TooltipValue = "";

                // NomineeMobileNumber
                NomineeMobileNumber.HrefValue = "";
                NomineeMobileNumber.TooltipValue = "";

                // NomineeValidVisa
                NomineeValidVisa.HrefValue = "";
                NomineeValidVisa.TooltipValue = "";

                // BankName
                BankName.HrefValue = "";
                BankName.TooltipValue = "";

                // BankAddress
                BankAddress.HrefValue = "";
                BankAddress.TooltipValue = "";

                // BankAccountName
                BankAccountName.HrefValue = "";
                BankAccountName.TooltipValue = "";

                // BankAccountNumber
                BankAccountNumber.HrefValue = "";
                BankAccountNumber.TooltipValue = "";

                // BankSortCode
                BankSortCode.HrefValue = "";
                BankSortCode.TooltipValue = "";

                // MNOPF
                MNOPF.HrefValue = "";
                MNOPF.TooltipValue = "";

                // MembershipNumber
                MembershipNumber.HrefValue = "";
                MembershipNumber.TooltipValue = "";

                // NationalInsuranceNumber
                NationalInsuranceNumber.HrefValue = "";
                NationalInsuranceNumber.TooltipValue = "";

                // AVC
                AVC.HrefValue = "";
                AVC.TooltipValue = "";

                // ForeignVisaHasBeenDenied
                ForeignVisaHasBeenDenied.HrefValue = "";
                ForeignVisaHasBeenDenied.TooltipValue = "";

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.HrefValue = "";
                ForeignVisaDenied_CountryID.TooltipValue = "";

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.HrefValue = "";
                ForeignVisaDeniedReason.TooltipValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.HrefValue = "";
                HasMaritimeAccidentOrCourtOfEnquiry.TooltipValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.HrefValue = "";
                HasMaritimeAccidentOrCourtOfEnquiryDetails.TooltipValue = "";

                // Reference1CompanyName
                Reference1CompanyName.HrefValue = "";
                Reference1CompanyName.TooltipValue = "";

                // Reference1ContactPersonName
                Reference1ContactPersonName.HrefValue = "";
                Reference1ContactPersonName.TooltipValue = "";

                // Reference1CompanyAddress
                Reference1CompanyAddress.HrefValue = "";
                Reference1CompanyAddress.TooltipValue = "";

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.HrefValue = "";
                Reference1CompanyCountryID.TooltipValue = "";

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.HrefValue = "";
                Reference1CompanyTelephone.TooltipValue = "";

                // Reference2CompanyName
                Reference2CompanyName.HrefValue = "";
                Reference2CompanyName.TooltipValue = "";

                // Reference2ContactPersonName
                Reference2ContactPersonName.HrefValue = "";
                Reference2ContactPersonName.TooltipValue = "";

                // Reference2CompanyAddress
                Reference2CompanyAddress.HrefValue = "";
                Reference2CompanyAddress.TooltipValue = "";

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.HrefValue = "";
                Reference2CompanyCountryID.TooltipValue = "";

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.HrefValue = "";
                Reference2CompanyTelephone.TooltipValue = "";

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

                // RevisedReason
                RevisedReason.HrefValue = "";
                RevisedReason.TooltipValue = "";

                // RevisedDateTime
                RevisedDateTime.HrefValue = "";
                RevisedDateTime.TooltipValue = "";
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

                // MaritalStatus
                MaritalStatus.SetupEditAttributes();
                MaritalStatus.EditValue = MaritalStatus.Options(true);
                MaritalStatus.PlaceHolder = RemoveHtml(MaritalStatus.Caption);

                // Gender
                Gender.SetupEditAttributes();
                Gender.EditValue = Gender.Options(true);
                Gender.PlaceHolder = RemoveHtml(Gender.Caption);

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

                // BloodType
                BloodType.SetupEditAttributes();
                BloodType.EditValue = BloodType.Options(true);
                BloodType.PlaceHolder = RemoveHtml(BloodType.Caption);

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

                // PrimaryAddressState
                PrimaryAddressState.SetupEditAttributes();
                if (!PrimaryAddressState.Raw)
                    PrimaryAddressState.AdvancedSearch.SearchValue = HtmlDecode(PrimaryAddressState.AdvancedSearch.SearchValue);
                PrimaryAddressState.EditValue = HtmlEncode(PrimaryAddressState.AdvancedSearch.SearchValue);
                PrimaryAddressState.PlaceHolder = RemoveHtml(PrimaryAddressState.Caption);

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.SetupEditAttributes();
                if (!PrimaryAddressNearestAirport.Raw)
                    PrimaryAddressNearestAirport.AdvancedSearch.SearchValue = HtmlDecode(PrimaryAddressNearestAirport.AdvancedSearch.SearchValue);
                PrimaryAddressNearestAirport.EditValue = HtmlEncode(PrimaryAddressNearestAirport.AdvancedSearch.SearchValue);
                PrimaryAddressNearestAirport.PlaceHolder = RemoveHtml(PrimaryAddressNearestAirport.Caption);

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

                // PrimaryAddressFax
                PrimaryAddressFax.SetupEditAttributes();
                if (!PrimaryAddressFax.Raw)
                    PrimaryAddressFax.AdvancedSearch.SearchValue = HtmlDecode(PrimaryAddressFax.AdvancedSearch.SearchValue);
                PrimaryAddressFax.EditValue = HtmlEncode(PrimaryAddressFax.AdvancedSearch.SearchValue);
                PrimaryAddressFax.PlaceHolder = RemoveHtml(PrimaryAddressFax.Caption);

                // AlternativeAddressDetail
                AlternativeAddressDetail.SetupEditAttributes();
                AlternativeAddressDetail.EditValue = AlternativeAddressDetail.AdvancedSearch.SearchValue; // DN
                AlternativeAddressDetail.PlaceHolder = RemoveHtml(AlternativeAddressDetail.Caption);

                // AlternativeAddressCity
                AlternativeAddressCity.SetupEditAttributes();
                if (!AlternativeAddressCity.Raw)
                    AlternativeAddressCity.AdvancedSearch.SearchValue = HtmlDecode(AlternativeAddressCity.AdvancedSearch.SearchValue);
                AlternativeAddressCity.EditValue = HtmlEncode(AlternativeAddressCity.AdvancedSearch.SearchValue);
                AlternativeAddressCity.PlaceHolder = RemoveHtml(AlternativeAddressCity.Caption);

                // AlternativeAddressState
                AlternativeAddressState.SetupEditAttributes();
                if (!AlternativeAddressState.Raw)
                    AlternativeAddressState.AdvancedSearch.SearchValue = HtmlDecode(AlternativeAddressState.AdvancedSearch.SearchValue);
                AlternativeAddressState.EditValue = HtmlEncode(AlternativeAddressState.AdvancedSearch.SearchValue);
                AlternativeAddressState.PlaceHolder = RemoveHtml(AlternativeAddressState.Caption);

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

                // ContactMethodEmail
                ContactMethodEmail.EditValue = ContactMethodEmail.Options(false);
                ContactMethodEmail.PlaceHolder = RemoveHtml(ContactMethodEmail.Caption);

                // ContactMethodFax
                ContactMethodFax.EditValue = ContactMethodFax.Options(false);
                ContactMethodFax.PlaceHolder = RemoveHtml(ContactMethodFax.Caption);

                // ContactMethodMobilePhone
                ContactMethodMobilePhone.EditValue = ContactMethodMobilePhone.Options(false);
                ContactMethodMobilePhone.PlaceHolder = RemoveHtml(ContactMethodMobilePhone.Caption);

                // ContactMethodHomePhone
                ContactMethodHomePhone.EditValue = ContactMethodHomePhone.Options(false);
                ContactMethodHomePhone.PlaceHolder = RemoveHtml(ContactMethodHomePhone.Caption);

                // ContactMethodPost
                ContactMethodPost.EditValue = ContactMethodPost.Options(false);
                ContactMethodPost.PlaceHolder = RemoveHtml(ContactMethodPost.Caption);

                // CollarSize
                CollarSize.SetupEditAttributes();
                CollarSize.EditValue = CollarSize.AdvancedSearch.SearchValue; // DN
                CollarSize.PlaceHolder = RemoveHtml(CollarSize.Caption);

                // ChestSize
                ChestSize.SetupEditAttributes();
                ChestSize.EditValue = ChestSize.AdvancedSearch.SearchValue; // DN
                ChestSize.PlaceHolder = RemoveHtml(ChestSize.Caption);

                // WaistSize
                WaistSize.SetupEditAttributes();
                WaistSize.EditValue = WaistSize.AdvancedSearch.SearchValue; // DN
                WaistSize.PlaceHolder = RemoveHtml(WaistSize.Caption);

                // InsideLegSize
                InsideLegSize.SetupEditAttributes();
                InsideLegSize.EditValue = InsideLegSize.AdvancedSearch.SearchValue; // DN
                InsideLegSize.PlaceHolder = RemoveHtml(InsideLegSize.Caption);

                // CapSize
                CapSize.SetupEditAttributes();
                CapSize.EditValue = CapSize.AdvancedSearch.SearchValue; // DN
                CapSize.PlaceHolder = RemoveHtml(CapSize.Caption);

                // SweaterSize_ClothesSizeID
                SweaterSize_ClothesSizeID.SetupEditAttributes();
                curVal = ConvertToString(SweaterSize_ClothesSizeID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (SweaterSize_ClothesSizeID.Lookup != null && IsDictionary(SweaterSize_ClothesSizeID.Lookup?.Options) && SweaterSize_ClothesSizeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    SweaterSize_ClothesSizeID.EditValue = SweaterSize_ClothesSizeID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", SweaterSize_ClothesSizeID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = SweaterSize_ClothesSizeID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    SweaterSize_ClothesSizeID.EditValue = rswrk;
                }
                SweaterSize_ClothesSizeID.PlaceHolder = RemoveHtml(SweaterSize_ClothesSizeID.Caption);

                // BoilersuitSize_ClothesSizeID
                BoilersuitSize_ClothesSizeID.SetupEditAttributes();
                curVal = ConvertToString(BoilersuitSize_ClothesSizeID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (BoilersuitSize_ClothesSizeID.Lookup != null && IsDictionary(BoilersuitSize_ClothesSizeID.Lookup?.Options) && BoilersuitSize_ClothesSizeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    BoilersuitSize_ClothesSizeID.EditValue = BoilersuitSize_ClothesSizeID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", BoilersuitSize_ClothesSizeID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = BoilersuitSize_ClothesSizeID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    BoilersuitSize_ClothesSizeID.EditValue = rswrk;
                }
                BoilersuitSize_ClothesSizeID.PlaceHolder = RemoveHtml(BoilersuitSize_ClothesSizeID.Caption);

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

                // NomineeFullName
                NomineeFullName.SetupEditAttributes();
                if (!NomineeFullName.Raw)
                    NomineeFullName.AdvancedSearch.SearchValue = HtmlDecode(NomineeFullName.AdvancedSearch.SearchValue);
                NomineeFullName.EditValue = HtmlEncode(NomineeFullName.AdvancedSearch.SearchValue);
                NomineeFullName.PlaceHolder = RemoveHtml(NomineeFullName.Caption);

                // NomineeRelationship
                NomineeRelationship.SetupEditAttributes();
                if (!NomineeRelationship.Raw)
                    NomineeRelationship.AdvancedSearch.SearchValue = HtmlDecode(NomineeRelationship.AdvancedSearch.SearchValue);
                NomineeRelationship.EditValue = HtmlEncode(NomineeRelationship.AdvancedSearch.SearchValue);
                NomineeRelationship.PlaceHolder = RemoveHtml(NomineeRelationship.Caption);

                // NomineeGender
                NomineeGender.SetupEditAttributes();
                NomineeGender.EditValue = NomineeGender.Options(true);
                NomineeGender.PlaceHolder = RemoveHtml(NomineeGender.Caption);

                // NomineeNationality_CountryID
                NomineeNationality_CountryID.SetupEditAttributes();
                curVal = ConvertToString(NomineeNationality_CountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (NomineeNationality_CountryID.Lookup != null && IsDictionary(NomineeNationality_CountryID.Lookup?.Options) && NomineeNationality_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeNationality_CountryID.EditValue = NomineeNationality_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", NomineeNationality_CountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = NomineeNationality_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    NomineeNationality_CountryID.EditValue = rswrk;
                }
                NomineeNationality_CountryID.PlaceHolder = RemoveHtml(NomineeNationality_CountryID.Caption);

                // NomineeAddressDetail
                NomineeAddressDetail.SetupEditAttributes();
                NomineeAddressDetail.EditValue = NomineeAddressDetail.AdvancedSearch.SearchValue; // DN
                NomineeAddressDetail.PlaceHolder = RemoveHtml(NomineeAddressDetail.Caption);

                // NomineeAddressCity
                NomineeAddressCity.SetupEditAttributes();
                if (!NomineeAddressCity.Raw)
                    NomineeAddressCity.AdvancedSearch.SearchValue = HtmlDecode(NomineeAddressCity.AdvancedSearch.SearchValue);
                NomineeAddressCity.EditValue = HtmlEncode(NomineeAddressCity.AdvancedSearch.SearchValue);
                NomineeAddressCity.PlaceHolder = RemoveHtml(NomineeAddressCity.Caption);

                // NomineeAddressPostCode
                NomineeAddressPostCode.SetupEditAttributes();
                if (!NomineeAddressPostCode.Raw)
                    NomineeAddressPostCode.AdvancedSearch.SearchValue = HtmlDecode(NomineeAddressPostCode.AdvancedSearch.SearchValue);
                NomineeAddressPostCode.EditValue = HtmlEncode(NomineeAddressPostCode.AdvancedSearch.SearchValue);
                NomineeAddressPostCode.PlaceHolder = RemoveHtml(NomineeAddressPostCode.Caption);

                // NomineeAddressCountryID
                NomineeAddressCountryID.SetupEditAttributes();
                curVal = ConvertToString(NomineeAddressCountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (NomineeAddressCountryID.Lookup != null && IsDictionary(NomineeAddressCountryID.Lookup?.Options) && NomineeAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeAddressCountryID.EditValue = NomineeAddressCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", NomineeAddressCountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = NomineeAddressCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    NomineeAddressCountryID.EditValue = rswrk;
                }
                NomineeAddressCountryID.PlaceHolder = RemoveHtml(NomineeAddressCountryID.Caption);

                // NomineeAddressHomeTel
                NomineeAddressHomeTel.SetupEditAttributes();
                if (!NomineeAddressHomeTel.Raw)
                    NomineeAddressHomeTel.AdvancedSearch.SearchValue = HtmlDecode(NomineeAddressHomeTel.AdvancedSearch.SearchValue);
                NomineeAddressHomeTel.EditValue = HtmlEncode(NomineeAddressHomeTel.AdvancedSearch.SearchValue);
                NomineeAddressHomeTel.PlaceHolder = RemoveHtml(NomineeAddressHomeTel.Caption);

                // NomineeEmail
                NomineeEmail.SetupEditAttributes();
                if (!NomineeEmail.Raw)
                    NomineeEmail.AdvancedSearch.SearchValue = HtmlDecode(NomineeEmail.AdvancedSearch.SearchValue);
                NomineeEmail.EditValue = HtmlEncode(NomineeEmail.AdvancedSearch.SearchValue);
                NomineeEmail.PlaceHolder = RemoveHtml(NomineeEmail.Caption);

                // NomineeMobileNumber
                NomineeMobileNumber.SetupEditAttributes();
                if (!NomineeMobileNumber.Raw)
                    NomineeMobileNumber.AdvancedSearch.SearchValue = HtmlDecode(NomineeMobileNumber.AdvancedSearch.SearchValue);
                NomineeMobileNumber.EditValue = HtmlEncode(NomineeMobileNumber.AdvancedSearch.SearchValue);
                NomineeMobileNumber.PlaceHolder = RemoveHtml(NomineeMobileNumber.Caption);

                // NomineeValidVisa
                NomineeValidVisa.SetupEditAttributes();
                if (!NomineeValidVisa.Raw)
                    NomineeValidVisa.AdvancedSearch.SearchValue = HtmlDecode(NomineeValidVisa.AdvancedSearch.SearchValue);
                NomineeValidVisa.EditValue = HtmlEncode(NomineeValidVisa.AdvancedSearch.SearchValue);
                NomineeValidVisa.PlaceHolder = RemoveHtml(NomineeValidVisa.Caption);

                // BankName
                BankName.SetupEditAttributes();
                if (!BankName.Raw)
                    BankName.AdvancedSearch.SearchValue = HtmlDecode(BankName.AdvancedSearch.SearchValue);
                BankName.EditValue = HtmlEncode(BankName.AdvancedSearch.SearchValue);
                BankName.PlaceHolder = RemoveHtml(BankName.Caption);

                // BankAddress
                BankAddress.SetupEditAttributes();
                BankAddress.EditValue = BankAddress.AdvancedSearch.SearchValue; // DN
                BankAddress.PlaceHolder = RemoveHtml(BankAddress.Caption);

                // BankAccountName
                BankAccountName.SetupEditAttributes();
                if (!BankAccountName.Raw)
                    BankAccountName.AdvancedSearch.SearchValue = HtmlDecode(BankAccountName.AdvancedSearch.SearchValue);
                BankAccountName.EditValue = HtmlEncode(BankAccountName.AdvancedSearch.SearchValue);
                BankAccountName.PlaceHolder = RemoveHtml(BankAccountName.Caption);

                // BankAccountNumber
                BankAccountNumber.SetupEditAttributes();
                if (!BankAccountNumber.Raw)
                    BankAccountNumber.AdvancedSearch.SearchValue = HtmlDecode(BankAccountNumber.AdvancedSearch.SearchValue);
                BankAccountNumber.EditValue = HtmlEncode(BankAccountNumber.AdvancedSearch.SearchValue);
                BankAccountNumber.PlaceHolder = RemoveHtml(BankAccountNumber.Caption);

                // BankSortCode
                BankSortCode.SetupEditAttributes();
                if (!BankSortCode.Raw)
                    BankSortCode.AdvancedSearch.SearchValue = HtmlDecode(BankSortCode.AdvancedSearch.SearchValue);
                BankSortCode.EditValue = HtmlEncode(BankSortCode.AdvancedSearch.SearchValue);
                BankSortCode.PlaceHolder = RemoveHtml(BankSortCode.Caption);

                // MNOPF
                MNOPF.SetupEditAttributes();
                if (!MNOPF.Raw)
                    MNOPF.AdvancedSearch.SearchValue = HtmlDecode(MNOPF.AdvancedSearch.SearchValue);
                MNOPF.EditValue = HtmlEncode(MNOPF.AdvancedSearch.SearchValue);
                MNOPF.PlaceHolder = RemoveHtml(MNOPF.Caption);

                // MembershipNumber
                MembershipNumber.SetupEditAttributes();
                if (!MembershipNumber.Raw)
                    MembershipNumber.AdvancedSearch.SearchValue = HtmlDecode(MembershipNumber.AdvancedSearch.SearchValue);
                MembershipNumber.EditValue = HtmlEncode(MembershipNumber.AdvancedSearch.SearchValue);
                MembershipNumber.PlaceHolder = RemoveHtml(MembershipNumber.Caption);

                // NationalInsuranceNumber
                NationalInsuranceNumber.SetupEditAttributes();
                if (!NationalInsuranceNumber.Raw)
                    NationalInsuranceNumber.AdvancedSearch.SearchValue = HtmlDecode(NationalInsuranceNumber.AdvancedSearch.SearchValue);
                NationalInsuranceNumber.EditValue = HtmlEncode(NationalInsuranceNumber.AdvancedSearch.SearchValue);
                NationalInsuranceNumber.PlaceHolder = RemoveHtml(NationalInsuranceNumber.Caption);

                // AVC
                AVC.SetupEditAttributes();
                if (!AVC.Raw)
                    AVC.AdvancedSearch.SearchValue = HtmlDecode(AVC.AdvancedSearch.SearchValue);
                AVC.EditValue = HtmlEncode(AVC.AdvancedSearch.SearchValue);
                AVC.PlaceHolder = RemoveHtml(AVC.Caption);

                // ForeignVisaHasBeenDenied
                ForeignVisaHasBeenDenied.EditValue = ForeignVisaHasBeenDenied.Options(false);
                ForeignVisaHasBeenDenied.PlaceHolder = RemoveHtml(ForeignVisaHasBeenDenied.Caption);

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.SetupEditAttributes();
                curVal = ConvertToString(ForeignVisaDenied_CountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (ForeignVisaDenied_CountryID.Lookup != null && IsDictionary(ForeignVisaDenied_CountryID.Lookup?.Options) && ForeignVisaDenied_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ForeignVisaDenied_CountryID.EditValue = ForeignVisaDenied_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", ForeignVisaDenied_CountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = ForeignVisaDenied_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    ForeignVisaDenied_CountryID.EditValue = rswrk;
                }
                ForeignVisaDenied_CountryID.PlaceHolder = RemoveHtml(ForeignVisaDenied_CountryID.Caption);

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.SetupEditAttributes();
                ForeignVisaDeniedReason.EditValue = ForeignVisaDeniedReason.AdvancedSearch.SearchValue; // DN
                ForeignVisaDeniedReason.PlaceHolder = RemoveHtml(ForeignVisaDeniedReason.Caption);

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.EditValue = HasMaritimeAccidentOrCourtOfEnquiry.Options(false);
                HasMaritimeAccidentOrCourtOfEnquiry.PlaceHolder = RemoveHtml(HasMaritimeAccidentOrCourtOfEnquiry.Caption);

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.SetupEditAttributes();
                HasMaritimeAccidentOrCourtOfEnquiryDetails.EditValue = HasMaritimeAccidentOrCourtOfEnquiryDetails.AdvancedSearch.SearchValue; // DN
                HasMaritimeAccidentOrCourtOfEnquiryDetails.PlaceHolder = RemoveHtml(HasMaritimeAccidentOrCourtOfEnquiryDetails.Caption);

                // Reference1CompanyName
                Reference1CompanyName.SetupEditAttributes();
                if (!Reference1CompanyName.Raw)
                    Reference1CompanyName.AdvancedSearch.SearchValue = HtmlDecode(Reference1CompanyName.AdvancedSearch.SearchValue);
                Reference1CompanyName.EditValue = HtmlEncode(Reference1CompanyName.AdvancedSearch.SearchValue);
                Reference1CompanyName.PlaceHolder = RemoveHtml(Reference1CompanyName.Caption);

                // Reference1ContactPersonName
                Reference1ContactPersonName.SetupEditAttributes();
                if (!Reference1ContactPersonName.Raw)
                    Reference1ContactPersonName.AdvancedSearch.SearchValue = HtmlDecode(Reference1ContactPersonName.AdvancedSearch.SearchValue);
                Reference1ContactPersonName.EditValue = HtmlEncode(Reference1ContactPersonName.AdvancedSearch.SearchValue);
                Reference1ContactPersonName.PlaceHolder = RemoveHtml(Reference1ContactPersonName.Caption);

                // Reference1CompanyAddress
                Reference1CompanyAddress.SetupEditAttributes();
                Reference1CompanyAddress.EditValue = Reference1CompanyAddress.AdvancedSearch.SearchValue; // DN
                Reference1CompanyAddress.PlaceHolder = RemoveHtml(Reference1CompanyAddress.Caption);

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference1CompanyCountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (Reference1CompanyCountryID.Lookup != null && IsDictionary(Reference1CompanyCountryID.Lookup?.Options) && Reference1CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference1CompanyCountryID.EditValue = Reference1CompanyCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference1CompanyCountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = Reference1CompanyCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference1CompanyCountryID.EditValue = rswrk;
                }
                Reference1CompanyCountryID.PlaceHolder = RemoveHtml(Reference1CompanyCountryID.Caption);

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.SetupEditAttributes();
                if (!Reference1CompanyTelephone.Raw)
                    Reference1CompanyTelephone.AdvancedSearch.SearchValue = HtmlDecode(Reference1CompanyTelephone.AdvancedSearch.SearchValue);
                Reference1CompanyTelephone.EditValue = HtmlEncode(Reference1CompanyTelephone.AdvancedSearch.SearchValue);
                Reference1CompanyTelephone.PlaceHolder = RemoveHtml(Reference1CompanyTelephone.Caption);

                // Reference2CompanyName
                Reference2CompanyName.SetupEditAttributes();
                if (!Reference2CompanyName.Raw)
                    Reference2CompanyName.AdvancedSearch.SearchValue = HtmlDecode(Reference2CompanyName.AdvancedSearch.SearchValue);
                Reference2CompanyName.EditValue = HtmlEncode(Reference2CompanyName.AdvancedSearch.SearchValue);
                Reference2CompanyName.PlaceHolder = RemoveHtml(Reference2CompanyName.Caption);

                // Reference2ContactPersonName
                Reference2ContactPersonName.SetupEditAttributes();
                if (!Reference2ContactPersonName.Raw)
                    Reference2ContactPersonName.AdvancedSearch.SearchValue = HtmlDecode(Reference2ContactPersonName.AdvancedSearch.SearchValue);
                Reference2ContactPersonName.EditValue = HtmlEncode(Reference2ContactPersonName.AdvancedSearch.SearchValue);
                Reference2ContactPersonName.PlaceHolder = RemoveHtml(Reference2ContactPersonName.Caption);

                // Reference2CompanyAddress
                Reference2CompanyAddress.SetupEditAttributes();
                Reference2CompanyAddress.EditValue = Reference2CompanyAddress.AdvancedSearch.SearchValue; // DN
                Reference2CompanyAddress.PlaceHolder = RemoveHtml(Reference2CompanyAddress.Caption);

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference2CompanyCountryID.AdvancedSearch.SearchValue)?.Trim() ?? "";
                if (Reference2CompanyCountryID.Lookup != null && IsDictionary(Reference2CompanyCountryID.Lookup?.Options) && Reference2CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference2CompanyCountryID.EditValue = Reference2CompanyCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference2CompanyCountryID.AdvancedSearch.SearchValue, DataType.Number, "");
                    }
                    sqlWrk = Reference2CompanyCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference2CompanyCountryID.EditValue = rswrk;
                }
                Reference2CompanyCountryID.PlaceHolder = RemoveHtml(Reference2CompanyCountryID.Caption);

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.SetupEditAttributes();
                if (!Reference2CompanyTelephone.Raw)
                    Reference2CompanyTelephone.AdvancedSearch.SearchValue = HtmlDecode(Reference2CompanyTelephone.AdvancedSearch.SearchValue);
                Reference2CompanyTelephone.EditValue = HtmlEncode(Reference2CompanyTelephone.AdvancedSearch.SearchValue);
                Reference2CompanyTelephone.PlaceHolder = RemoveHtml(Reference2CompanyTelephone.Caption);

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

                // RevisedReason
                RevisedReason.SetupEditAttributes();
                if (!RevisedReason.Raw)
                    RevisedReason.AdvancedSearch.SearchValue = HtmlDecode(RevisedReason.AdvancedSearch.SearchValue);
                RevisedReason.EditValue = HtmlEncode(RevisedReason.AdvancedSearch.SearchValue);
                RevisedReason.PlaceHolder = RemoveHtml(RevisedReason.Caption);

                // RevisedDateTime
                RevisedDateTime.SetupEditAttributes();
                RevisedDateTime.EditValue = FormatDateTime(UnformatDateTime(RevisedDateTime.AdvancedSearch.SearchValue, RevisedDateTime.FormatPattern), RevisedDateTime.FormatPattern); // DN
                RevisedDateTime.PlaceHolder = RemoveHtml(RevisedDateTime.Caption);
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
            if (!CheckNumber(ConvertToString(CollarSize.AdvancedSearch.SearchValue))) {
                CollarSize.AddErrorMessage(CollarSize.GetErrorMessage(false));
            }
            if (!CheckNumber(ConvertToString(ChestSize.AdvancedSearch.SearchValue))) {
                ChestSize.AddErrorMessage(ChestSize.GetErrorMessage(false));
            }
            if (!CheckNumber(ConvertToString(WaistSize.AdvancedSearch.SearchValue))) {
                WaistSize.AddErrorMessage(WaistSize.GetErrorMessage(false));
            }
            if (!CheckNumber(ConvertToString(InsideLegSize.AdvancedSearch.SearchValue))) {
                InsideLegSize.AddErrorMessage(InsideLegSize.GetErrorMessage(false));
            }
            if (!CheckNumber(ConvertToString(CapSize.AdvancedSearch.SearchValue))) {
                CapSize.AddErrorMessage(CapSize.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(FormSubmittedDateTime.AdvancedSearch.SearchValue), FormSubmittedDateTime.FormatPattern)) {
                FormSubmittedDateTime.AddErrorMessage(FormSubmittedDateTime.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(CreatedDateTime.AdvancedSearch.SearchValue), CreatedDateTime.FormatPattern)) {
                CreatedDateTime.AddErrorMessage(CreatedDateTime.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(LastUpdatedDateTime.AdvancedSearch.SearchValue), LastUpdatedDateTime.FormatPattern)) {
                LastUpdatedDateTime.AddErrorMessage(LastUpdatedDateTime.GetErrorMessage(false));
            }
            if (!CheckDate(ConvertToString(RevisedDateTime.AdvancedSearch.SearchValue), RevisedDateTime.FormatPattern)) {
                RevisedDateTime.AddErrorMessage(RevisedDateTime.GetErrorMessage(false));
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
            MaritalStatus.AdvancedSearch.Load();
            Gender.AdvancedSearch.Load();
            ReligionID.AdvancedSearch.Load();
            BloodType.AdvancedSearch.Load();
            RankAppliedFor_RankID.AdvancedSearch.Load();
            WillAcceptLowRank.AdvancedSearch.Load();
            AvailableFrom.AdvancedSearch.Load();
            AvailableUntil.AdvancedSearch.Load();
            PrimaryAddressDetail.AdvancedSearch.Load();
            PrimaryAddressCity.AdvancedSearch.Load();
            PrimaryAddressState.AdvancedSearch.Load();
            PrimaryAddressNearestAirport.AdvancedSearch.Load();
            PrimaryAddressPostCode.AdvancedSearch.Load();
            PrimaryAddressCountryID.AdvancedSearch.Load();
            PrimaryAddressHomeTel.AdvancedSearch.Load();
            PrimaryAddressFax.AdvancedSearch.Load();
            AlternativeAddressDetail.AdvancedSearch.Load();
            AlternativeAddressCity.AdvancedSearch.Load();
            AlternativeAddressState.AdvancedSearch.Load();
            AlternativeAddressHomeTel.AdvancedSearch.Load();
            AlternativeAddressPostCode.AdvancedSearch.Load();
            AlternativeAddressCountryID.AdvancedSearch.Load();
            MobileNumber.AdvancedSearch.Load();
            _Email.AdvancedSearch.Load();
            ContactMethodEmail.AdvancedSearch.Load();
            ContactMethodFax.AdvancedSearch.Load();
            ContactMethodMobilePhone.AdvancedSearch.Load();
            ContactMethodHomePhone.AdvancedSearch.Load();
            ContactMethodPost.AdvancedSearch.Load();
            CollarSize.AdvancedSearch.Load();
            ChestSize.AdvancedSearch.Load();
            WaistSize.AdvancedSearch.Load();
            InsideLegSize.AdvancedSearch.Load();
            CapSize.AdvancedSearch.Load();
            SweaterSize_ClothesSizeID.AdvancedSearch.Load();
            BoilersuitSize_ClothesSizeID.AdvancedSearch.Load();
            SocialSecurityNumber.AdvancedSearch.Load();
            SocialSecurityIssuingCountryID.AdvancedSearch.Load();
            SocialSecurityImage.AdvancedSearch.Load();
            PersonalTaxNumber.AdvancedSearch.Load();
            PersonalTaxIssuingCountryID.AdvancedSearch.Load();
            PersonalTaxImage.AdvancedSearch.Load();
            NomineeFullName.AdvancedSearch.Load();
            NomineeRelationship.AdvancedSearch.Load();
            NomineeGender.AdvancedSearch.Load();
            NomineeNationality_CountryID.AdvancedSearch.Load();
            NomineeAddressDetail.AdvancedSearch.Load();
            NomineeAddressCity.AdvancedSearch.Load();
            NomineeAddressPostCode.AdvancedSearch.Load();
            NomineeAddressCountryID.AdvancedSearch.Load();
            NomineeAddressHomeTel.AdvancedSearch.Load();
            NomineeEmail.AdvancedSearch.Load();
            NomineeMobileNumber.AdvancedSearch.Load();
            NomineeValidVisa.AdvancedSearch.Load();
            BankName.AdvancedSearch.Load();
            BankAddress.AdvancedSearch.Load();
            BankAccountName.AdvancedSearch.Load();
            BankAccountNumber.AdvancedSearch.Load();
            BankSortCode.AdvancedSearch.Load();
            MNOPF.AdvancedSearch.Load();
            MembershipNumber.AdvancedSearch.Load();
            NationalInsuranceNumber.AdvancedSearch.Load();
            AVC.AdvancedSearch.Load();
            ForeignVisaHasBeenDenied.AdvancedSearch.Load();
            ForeignVisaDenied_CountryID.AdvancedSearch.Load();
            ForeignVisaDeniedReason.AdvancedSearch.Load();
            HasMaritimeAccidentOrCourtOfEnquiry.AdvancedSearch.Load();
            HasMaritimeAccidentOrCourtOfEnquiryDetails.AdvancedSearch.Load();
            Reference1CompanyName.AdvancedSearch.Load();
            Reference1ContactPersonName.AdvancedSearch.Load();
            Reference1CompanyAddress.AdvancedSearch.Load();
            Reference1CompanyCountryID.AdvancedSearch.Load();
            Reference1CompanyTelephone.AdvancedSearch.Load();
            Reference2CompanyName.AdvancedSearch.Load();
            Reference2ContactPersonName.AdvancedSearch.Load();
            Reference2CompanyAddress.AdvancedSearch.Load();
            Reference2CompanyCountryID.AdvancedSearch.Load();
            Reference2CompanyTelephone.AdvancedSearch.Load();
            EmployeeStatus.AdvancedSearch.Load();
            FormSubmittedDateTime.AdvancedSearch.Load();
            CreatedByUserID.AdvancedSearch.Load();
            CreatedDateTime.AdvancedSearch.Load();
            LastUpdatedByUserID.AdvancedSearch.Load();
            LastUpdatedDateTime.AdvancedSearch.Load();
            RevisedReason.AdvancedSearch.Load();
            RevisedDateTime.AdvancedSearch.Load();
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MtCrewList")), "", TableVar, true);
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
