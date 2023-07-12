namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mtCrewAdd
    /// </summary>
    public static MtCrewAdd mtCrewAdd
    {
        get => HttpData.Get<MtCrewAdd>("mtCrewAdd")!;
        set => HttpData["mtCrewAdd"] = value;
    }

    /// <summary>
    /// Page class for MTCrew
    /// </summary>
    public class MtCrewAdd : MtCrewAddBase
    {
        // Constructor
        public MtCrewAdd(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MtCrewAdd() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MtCrewAddBase : MtCrew
    {
        // Page ID
        public string PageID = "add";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "MTCrew";

        // Page object name
        public string PageObjName = "mtCrewAdd";

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
        public MtCrewAddBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-add-table";

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
        public string PageName => "MtCrewAdd";

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
            RequiredPhoto.SetVisibility();
            VisaPhoto.SetVisibility();
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
            EmployeeStatus.Visible = false;
            FormSubmittedDateTime.Visible = false;
            ActiveDescription.Visible = false;
            CreatedByUserID.Visible = false;
            CreatedDateTime.Visible = false;
            LastUpdatedByUserID.Visible = false;
            LastUpdatedDateTime.Visible = false;
            MTUserID.Visible = false;
            DocumentCheckDateTime.Visible = false;
            InterviewManagerDateTime.Visible = false;
            InterviewGMDateTime.Visible = false;
            MCUScheduleDateTime.Visible = false;
            RejectedReason.Visible = false;
            RejectedDateTime.Visible = false;
            Status.SetVisibility();
            Reason.SetVisibility();
            Weight.SetVisibility();
            Height.SetVisibility();
            CoverallSize.SetVisibility();
            SafetyShoesSize.SetVisibility();
            ShirtSize.SetVisibility();
            TrousersSize.SetVisibility();
            NSSF_Health_Number.SetVisibility();
            NSSF_Occupation_Number.SetVisibility();
            FinalAcceptedDate.SetVisibility();
            Reference1CompanyTelephoneCode_CountryID.SetVisibility();
            Reference2CompanyTelephoneCode_CountryID.SetVisibility();
            MobileNumberCode_CountryID.SetVisibility();
            PrimaryAddressHomeTelCode_CountryID.SetVisibility();
            AlternativeAddressHomeTelCode_CountryID.SetVisibility();
            NomineeAddressHomeTelCode_CountryID.SetVisibility();
            NomineeMobileNumberCode_CountryID.SetVisibility();
            RevisedReason.SetVisibility();
            RevisedDateTime.SetVisibility();
        }

        // Constructor
        public MtCrewAddBase(Controller? controller = null): this() { // DN
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

        // Properties
        public string FormClassName = "ew-form ew-add-form";

        public bool IsModal = false;

        public bool IsMobileOrModal = false;

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public int StartRecord;

        public DbDataReader? Recordset = null; // Reserved // DN

        public bool CopyRecord;

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

            // Load default values for add
            LoadDefaultValues();

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;
            bool postBack = false;
            StringValues sv;

            // Set up current action
            if (IsApi()) {
                CurrentAction = "insert"; // Add record directly
                postBack = true;
            } else if (!Empty(Post("action"))) {
                CurrentAction = Post("action"); // Get form action
                if (Post(OldKeyName, out sv))
                    SetKey(sv.ToString());
                postBack = true;
            } else {
                // Load key from QueryString
                string[] keyValues = {};
                object? rv;
                if (RouteValues.TryGetValue("key", out object? k))
                    keyValues = ConvertToString(k).Split('/'); // For Copy page
                if (RouteValues.TryGetValue("ID", out rv)) { // DN
                    ID.QueryValue = UrlDecode(rv); // DN
                } else if (Get("ID", out sv)) {
                    ID.QueryValue = sv.ToString();
                }
                OldKey = GetKey(true); // Get from CurrentValue
                CopyRecord = !Empty(OldKey);
                if (CopyRecord) {
                    CurrentAction = "copy"; // Copy record
                    SetKey(OldKey); // Set up record key
                } else {
                    CurrentAction = "show"; // Display blank record
                }
            }

            // Load old record / default values
            var rsold = await LoadOldRecord();

            // Load form values
            if (postBack) {
                await LoadFormValues(); // Load form values
            }

            // Set up detail parameters
            SetupDetailParms();

            // Validate form if post back
            if (postBack) {
                if (!await ValidateForm()) {
                    EventCancelled = true; // Event cancelled
                    RestoreFormValues(); // Restore form values
                    if (IsApi())
                        return Terminate();
                    else
                        CurrentAction = "show"; // Form error, reset action
                }
            }

            // Perform current action
            switch (CurrentAction) {
                case "copy": // Copy an existing record
                    if (rsold == null) { // Record not loaded
                        if (Empty(FailureMessage))
                            FailureMessage = Language.Phrase("NoRecord"); // No record found
                        return Terminate("MtCrewList"); // No matching record, return to List page // DN
                    }

                    // Set up detail parameters
                    SetupDetailParms();
                    break;
                case "insert": // Add new record // DN
                    SendEmail = true; // Send email on add success
                    var res = await AddRow(rsold);
                    if (res) { // Add successful
                        if (Empty(SuccessMessage) && Post("addopt") != "1") // Skip success message for addopt (done in JavaScript)
                            SuccessMessage = Language.Phrase("AddSuccess"); // Set up success message
                        string returnUrl = "";
                        if (!Empty(CurrentDetailTable)) // Master/detail add
                            returnUrl = DetailUrl;
                        else
                            returnUrl = ReturnUrl;
                        if (GetPageName(returnUrl) == "MtCrewList")
                            returnUrl = AddMasterUrl(ListUrl); // List page, return to List page with correct master key if necessary
                        else if (GetPageName(returnUrl) == "MtCrewView")
                            returnUrl = ViewUrl; // View page, return to View page with key URL directly

                        // Handle UseAjaxActions
                        if (IsModal && UseAjaxActions) {
                            IsModal = false;
                            if (GetPageName(returnUrl) != "MtCrewList") {
                                TempData["Return-Url"] = returnUrl; // Save return URL
                                returnUrl = "MtCrewList"; // Return list page content
                            }
                        }
                        if (IsJsonResponse()) { // Return to caller
                            ClearMessages(); // Clear messages for Json response
                            return res;
                        } else {
                            return Terminate(returnUrl);
                        }
                    } else if (IsApi()) { // API request, return
                        return Terminate();
                    } else {
                        EventCancelled = true; // Event cancelled
                        RestoreFormValues(); // Add failed, restore form values

                        // Set up detail parameters
                        SetupDetailParms();
                    }
                    break;
            }

            // Set up Breadcrumb
            SetupBreadcrumb();

            // Render row based on row type
            RowType = RowType.Add; // Render add type

            // Render row
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
                mtCrewAdd?.PageRender();
            }
            return PageResult();
        }

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

        // Load default values
        protected void LoadDefaultValues() {
        }

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
                    IndividualCodeNumber.SetFormValue(val, true, validate);
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

            // Check field name 'MaritalStatus' before field var 'x_MaritalStatus'
            val = CurrentForm.HasValue("MaritalStatus") ? CurrentForm.GetValue("MaritalStatus") : CurrentForm.GetValue("x_MaritalStatus");
            if (!MaritalStatus.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MaritalStatus") && !CurrentForm.HasValue("x_MaritalStatus")) // DN
                    MaritalStatus.Visible = false; // Disable update for API request
                else
                    MaritalStatus.SetFormValue(val);
            }

            // Check field name 'Gender' before field var 'x_Gender'
            val = CurrentForm.HasValue("Gender") ? CurrentForm.GetValue("Gender") : CurrentForm.GetValue("x_Gender");
            if (!Gender.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Gender") && !CurrentForm.HasValue("x_Gender")) // DN
                    Gender.Visible = false; // Disable update for API request
                else
                    Gender.SetFormValue(val);
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

            // Check field name 'PrimaryAddressState' before field var 'x_PrimaryAddressState'
            val = CurrentForm.HasValue("PrimaryAddressState") ? CurrentForm.GetValue("PrimaryAddressState") : CurrentForm.GetValue("x_PrimaryAddressState");
            if (!PrimaryAddressState.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressState") && !CurrentForm.HasValue("x_PrimaryAddressState")) // DN
                    PrimaryAddressState.Visible = false; // Disable update for API request
                else
                    PrimaryAddressState.SetFormValue(val);
            }

            // Check field name 'PrimaryAddressNearestAirport' before field var 'x_PrimaryAddressNearestAirport'
            val = CurrentForm.HasValue("PrimaryAddressNearestAirport") ? CurrentForm.GetValue("PrimaryAddressNearestAirport") : CurrentForm.GetValue("x_PrimaryAddressNearestAirport");
            if (!PrimaryAddressNearestAirport.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressNearestAirport") && !CurrentForm.HasValue("x_PrimaryAddressNearestAirport")) // DN
                    PrimaryAddressNearestAirport.Visible = false; // Disable update for API request
                else
                    PrimaryAddressNearestAirport.SetFormValue(val);
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

            // Check field name 'PrimaryAddressFax' before field var 'x_PrimaryAddressFax'
            val = CurrentForm.HasValue("PrimaryAddressFax") ? CurrentForm.GetValue("PrimaryAddressFax") : CurrentForm.GetValue("x_PrimaryAddressFax");
            if (!PrimaryAddressFax.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("PrimaryAddressFax") && !CurrentForm.HasValue("x_PrimaryAddressFax")) // DN
                    PrimaryAddressFax.Visible = false; // Disable update for API request
                else
                    PrimaryAddressFax.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressDetail' before field var 'x_AlternativeAddressDetail'
            val = CurrentForm.HasValue("AlternativeAddressDetail") ? CurrentForm.GetValue("AlternativeAddressDetail") : CurrentForm.GetValue("x_AlternativeAddressDetail");
            if (!AlternativeAddressDetail.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressDetail") && !CurrentForm.HasValue("x_AlternativeAddressDetail")) // DN
                    AlternativeAddressDetail.Visible = false; // Disable update for API request
                else
                    AlternativeAddressDetail.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressCity' before field var 'x_AlternativeAddressCity'
            val = CurrentForm.HasValue("AlternativeAddressCity") ? CurrentForm.GetValue("AlternativeAddressCity") : CurrentForm.GetValue("x_AlternativeAddressCity");
            if (!AlternativeAddressCity.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressCity") && !CurrentForm.HasValue("x_AlternativeAddressCity")) // DN
                    AlternativeAddressCity.Visible = false; // Disable update for API request
                else
                    AlternativeAddressCity.SetFormValue(val);
            }

            // Check field name 'AlternativeAddressState' before field var 'x_AlternativeAddressState'
            val = CurrentForm.HasValue("AlternativeAddressState") ? CurrentForm.GetValue("AlternativeAddressState") : CurrentForm.GetValue("x_AlternativeAddressState");
            if (!AlternativeAddressState.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AlternativeAddressState") && !CurrentForm.HasValue("x_AlternativeAddressState")) // DN
                    AlternativeAddressState.Visible = false; // Disable update for API request
                else
                    AlternativeAddressState.SetFormValue(val);
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

            // Check field name 'ContactMethodEmail' before field var 'x_ContactMethodEmail'
            val = CurrentForm.HasValue("ContactMethodEmail") ? CurrentForm.GetValue("ContactMethodEmail") : CurrentForm.GetValue("x_ContactMethodEmail");
            if (!ContactMethodEmail.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ContactMethodEmail") && !CurrentForm.HasValue("x_ContactMethodEmail")) // DN
                    ContactMethodEmail.Visible = false; // Disable update for API request
                else
                    ContactMethodEmail.SetFormValue(val);
            }

            // Check field name 'ContactMethodFax' before field var 'x_ContactMethodFax'
            val = CurrentForm.HasValue("ContactMethodFax") ? CurrentForm.GetValue("ContactMethodFax") : CurrentForm.GetValue("x_ContactMethodFax");
            if (!ContactMethodFax.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ContactMethodFax") && !CurrentForm.HasValue("x_ContactMethodFax")) // DN
                    ContactMethodFax.Visible = false; // Disable update for API request
                else
                    ContactMethodFax.SetFormValue(val);
            }

            // Check field name 'ContactMethodMobilePhone' before field var 'x_ContactMethodMobilePhone'
            val = CurrentForm.HasValue("ContactMethodMobilePhone") ? CurrentForm.GetValue("ContactMethodMobilePhone") : CurrentForm.GetValue("x_ContactMethodMobilePhone");
            if (!ContactMethodMobilePhone.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ContactMethodMobilePhone") && !CurrentForm.HasValue("x_ContactMethodMobilePhone")) // DN
                    ContactMethodMobilePhone.Visible = false; // Disable update for API request
                else
                    ContactMethodMobilePhone.SetFormValue(val);
            }

            // Check field name 'ContactMethodHomePhone' before field var 'x_ContactMethodHomePhone'
            val = CurrentForm.HasValue("ContactMethodHomePhone") ? CurrentForm.GetValue("ContactMethodHomePhone") : CurrentForm.GetValue("x_ContactMethodHomePhone");
            if (!ContactMethodHomePhone.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ContactMethodHomePhone") && !CurrentForm.HasValue("x_ContactMethodHomePhone")) // DN
                    ContactMethodHomePhone.Visible = false; // Disable update for API request
                else
                    ContactMethodHomePhone.SetFormValue(val);
            }

            // Check field name 'ContactMethodPost' before field var 'x_ContactMethodPost'
            val = CurrentForm.HasValue("ContactMethodPost") ? CurrentForm.GetValue("ContactMethodPost") : CurrentForm.GetValue("x_ContactMethodPost");
            if (!ContactMethodPost.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ContactMethodPost") && !CurrentForm.HasValue("x_ContactMethodPost")) // DN
                    ContactMethodPost.Visible = false; // Disable update for API request
                else
                    ContactMethodPost.SetFormValue(val);
            }

            // Check field name 'CollarSize' before field var 'x_CollarSize'
            val = CurrentForm.HasValue("CollarSize") ? CurrentForm.GetValue("CollarSize") : CurrentForm.GetValue("x_CollarSize");
            if (!CollarSize.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CollarSize") && !CurrentForm.HasValue("x_CollarSize")) // DN
                    CollarSize.Visible = false; // Disable update for API request
                else
                    CollarSize.SetFormValue(val, true, validate);
            }

            // Check field name 'ChestSize' before field var 'x_ChestSize'
            val = CurrentForm.HasValue("ChestSize") ? CurrentForm.GetValue("ChestSize") : CurrentForm.GetValue("x_ChestSize");
            if (!ChestSize.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ChestSize") && !CurrentForm.HasValue("x_ChestSize")) // DN
                    ChestSize.Visible = false; // Disable update for API request
                else
                    ChestSize.SetFormValue(val, true, validate);
            }

            // Check field name 'WaistSize' before field var 'x_WaistSize'
            val = CurrentForm.HasValue("WaistSize") ? CurrentForm.GetValue("WaistSize") : CurrentForm.GetValue("x_WaistSize");
            if (!WaistSize.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("WaistSize") && !CurrentForm.HasValue("x_WaistSize")) // DN
                    WaistSize.Visible = false; // Disable update for API request
                else
                    WaistSize.SetFormValue(val, true, validate);
            }

            // Check field name 'InsideLegSize' before field var 'x_InsideLegSize'
            val = CurrentForm.HasValue("InsideLegSize") ? CurrentForm.GetValue("InsideLegSize") : CurrentForm.GetValue("x_InsideLegSize");
            if (!InsideLegSize.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("InsideLegSize") && !CurrentForm.HasValue("x_InsideLegSize")) // DN
                    InsideLegSize.Visible = false; // Disable update for API request
                else
                    InsideLegSize.SetFormValue(val, true, validate);
            }

            // Check field name 'CapSize' before field var 'x_CapSize'
            val = CurrentForm.HasValue("CapSize") ? CurrentForm.GetValue("CapSize") : CurrentForm.GetValue("x_CapSize");
            if (!CapSize.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("CapSize") && !CurrentForm.HasValue("x_CapSize")) // DN
                    CapSize.Visible = false; // Disable update for API request
                else
                    CapSize.SetFormValue(val, true, validate);
            }

            // Check field name 'SweaterSize_ClothesSizeID' before field var 'x_SweaterSize_ClothesSizeID'
            val = CurrentForm.HasValue("SweaterSize_ClothesSizeID") ? CurrentForm.GetValue("SweaterSize_ClothesSizeID") : CurrentForm.GetValue("x_SweaterSize_ClothesSizeID");
            if (!SweaterSize_ClothesSizeID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SweaterSize_ClothesSizeID") && !CurrentForm.HasValue("x_SweaterSize_ClothesSizeID")) // DN
                    SweaterSize_ClothesSizeID.Visible = false; // Disable update for API request
                else
                    SweaterSize_ClothesSizeID.SetFormValue(val);
            }

            // Check field name 'BoilersuitSize_ClothesSizeID' before field var 'x_BoilersuitSize_ClothesSizeID'
            val = CurrentForm.HasValue("BoilersuitSize_ClothesSizeID") ? CurrentForm.GetValue("BoilersuitSize_ClothesSizeID") : CurrentForm.GetValue("x_BoilersuitSize_ClothesSizeID");
            if (!BoilersuitSize_ClothesSizeID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BoilersuitSize_ClothesSizeID") && !CurrentForm.HasValue("x_BoilersuitSize_ClothesSizeID")) // DN
                    BoilersuitSize_ClothesSizeID.Visible = false; // Disable update for API request
                else
                    BoilersuitSize_ClothesSizeID.SetFormValue(val);
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

            // Check field name 'NomineeValidVisa' before field var 'x_NomineeValidVisa'
            val = CurrentForm.HasValue("NomineeValidVisa") ? CurrentForm.GetValue("NomineeValidVisa") : CurrentForm.GetValue("x_NomineeValidVisa");
            if (!NomineeValidVisa.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NomineeValidVisa") && !CurrentForm.HasValue("x_NomineeValidVisa")) // DN
                    NomineeValidVisa.Visible = false; // Disable update for API request
                else
                    NomineeValidVisa.SetFormValue(val);
            }

            // Check field name 'BankName' before field var 'x_BankName'
            val = CurrentForm.HasValue("BankName") ? CurrentForm.GetValue("BankName") : CurrentForm.GetValue("x_BankName");
            if (!BankName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BankName") && !CurrentForm.HasValue("x_BankName")) // DN
                    BankName.Visible = false; // Disable update for API request
                else
                    BankName.SetFormValue(val);
            }

            // Check field name 'BankAddress' before field var 'x_BankAddress'
            val = CurrentForm.HasValue("BankAddress") ? CurrentForm.GetValue("BankAddress") : CurrentForm.GetValue("x_BankAddress");
            if (!BankAddress.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BankAddress") && !CurrentForm.HasValue("x_BankAddress")) // DN
                    BankAddress.Visible = false; // Disable update for API request
                else
                    BankAddress.SetFormValue(val);
            }

            // Check field name 'BankAccountName' before field var 'x_BankAccountName'
            val = CurrentForm.HasValue("BankAccountName") ? CurrentForm.GetValue("BankAccountName") : CurrentForm.GetValue("x_BankAccountName");
            if (!BankAccountName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BankAccountName") && !CurrentForm.HasValue("x_BankAccountName")) // DN
                    BankAccountName.Visible = false; // Disable update for API request
                else
                    BankAccountName.SetFormValue(val);
            }

            // Check field name 'BankAccountNumber' before field var 'x_BankAccountNumber'
            val = CurrentForm.HasValue("BankAccountNumber") ? CurrentForm.GetValue("BankAccountNumber") : CurrentForm.GetValue("x_BankAccountNumber");
            if (!BankAccountNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BankAccountNumber") && !CurrentForm.HasValue("x_BankAccountNumber")) // DN
                    BankAccountNumber.Visible = false; // Disable update for API request
                else
                    BankAccountNumber.SetFormValue(val);
            }

            // Check field name 'BankSortCode' before field var 'x_BankSortCode'
            val = CurrentForm.HasValue("BankSortCode") ? CurrentForm.GetValue("BankSortCode") : CurrentForm.GetValue("x_BankSortCode");
            if (!BankSortCode.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("BankSortCode") && !CurrentForm.HasValue("x_BankSortCode")) // DN
                    BankSortCode.Visible = false; // Disable update for API request
                else
                    BankSortCode.SetFormValue(val);
            }

            // Check field name 'MNOPF' before field var 'x_MNOPF'
            val = CurrentForm.HasValue("MNOPF") ? CurrentForm.GetValue("MNOPF") : CurrentForm.GetValue("x_MNOPF");
            if (!MNOPF.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MNOPF") && !CurrentForm.HasValue("x_MNOPF")) // DN
                    MNOPF.Visible = false; // Disable update for API request
                else
                    MNOPF.SetFormValue(val);
            }

            // Check field name 'MembershipNumber' before field var 'x_MembershipNumber'
            val = CurrentForm.HasValue("MembershipNumber") ? CurrentForm.GetValue("MembershipNumber") : CurrentForm.GetValue("x_MembershipNumber");
            if (!MembershipNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("MembershipNumber") && !CurrentForm.HasValue("x_MembershipNumber")) // DN
                    MembershipNumber.Visible = false; // Disable update for API request
                else
                    MembershipNumber.SetFormValue(val);
            }

            // Check field name 'NationalInsuranceNumber' before field var 'x_NationalInsuranceNumber'
            val = CurrentForm.HasValue("NationalInsuranceNumber") ? CurrentForm.GetValue("NationalInsuranceNumber") : CurrentForm.GetValue("x_NationalInsuranceNumber");
            if (!NationalInsuranceNumber.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("NationalInsuranceNumber") && !CurrentForm.HasValue("x_NationalInsuranceNumber")) // DN
                    NationalInsuranceNumber.Visible = false; // Disable update for API request
                else
                    NationalInsuranceNumber.SetFormValue(val);
            }

            // Check field name 'AVC' before field var 'x_AVC'
            val = CurrentForm.HasValue("AVC") ? CurrentForm.GetValue("AVC") : CurrentForm.GetValue("x_AVC");
            if (!AVC.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("AVC") && !CurrentForm.HasValue("x_AVC")) // DN
                    AVC.Visible = false; // Disable update for API request
                else
                    AVC.SetFormValue(val);
            }

            // Check field name 'ForeignVisaHasBeenDenied' before field var 'x_ForeignVisaHasBeenDenied'
            val = CurrentForm.HasValue("ForeignVisaHasBeenDenied") ? CurrentForm.GetValue("ForeignVisaHasBeenDenied") : CurrentForm.GetValue("x_ForeignVisaHasBeenDenied");
            if (!ForeignVisaHasBeenDenied.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ForeignVisaHasBeenDenied") && !CurrentForm.HasValue("x_ForeignVisaHasBeenDenied")) // DN
                    ForeignVisaHasBeenDenied.Visible = false; // Disable update for API request
                else
                    ForeignVisaHasBeenDenied.SetFormValue(val);
            }

            // Check field name 'ForeignVisaDenied_CountryID' before field var 'x_ForeignVisaDenied_CountryID'
            val = CurrentForm.HasValue("ForeignVisaDenied_CountryID") ? CurrentForm.GetValue("ForeignVisaDenied_CountryID") : CurrentForm.GetValue("x_ForeignVisaDenied_CountryID");
            if (!ForeignVisaDenied_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ForeignVisaDenied_CountryID") && !CurrentForm.HasValue("x_ForeignVisaDenied_CountryID")) // DN
                    ForeignVisaDenied_CountryID.Visible = false; // Disable update for API request
                else
                    ForeignVisaDenied_CountryID.SetFormValue(val);
            }

            // Check field name 'ForeignVisaDeniedReason' before field var 'x_ForeignVisaDeniedReason'
            val = CurrentForm.HasValue("ForeignVisaDeniedReason") ? CurrentForm.GetValue("ForeignVisaDeniedReason") : CurrentForm.GetValue("x_ForeignVisaDeniedReason");
            if (!ForeignVisaDeniedReason.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("ForeignVisaDeniedReason") && !CurrentForm.HasValue("x_ForeignVisaDeniedReason")) // DN
                    ForeignVisaDeniedReason.Visible = false; // Disable update for API request
                else
                    ForeignVisaDeniedReason.SetFormValue(val);
            }

            // Check field name 'HasMaritimeAccidentOrCourtOfEnquiry' before field var 'x_HasMaritimeAccidentOrCourtOfEnquiry'
            val = CurrentForm.HasValue("HasMaritimeAccidentOrCourtOfEnquiry") ? CurrentForm.GetValue("HasMaritimeAccidentOrCourtOfEnquiry") : CurrentForm.GetValue("x_HasMaritimeAccidentOrCourtOfEnquiry");
            if (!HasMaritimeAccidentOrCourtOfEnquiry.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("HasMaritimeAccidentOrCourtOfEnquiry") && !CurrentForm.HasValue("x_HasMaritimeAccidentOrCourtOfEnquiry")) // DN
                    HasMaritimeAccidentOrCourtOfEnquiry.Visible = false; // Disable update for API request
                else
                    HasMaritimeAccidentOrCourtOfEnquiry.SetFormValue(val);
            }

            // Check field name 'HasMaritimeAccidentOrCourtOfEnquiryDetails' before field var 'x_HasMaritimeAccidentOrCourtOfEnquiryDetails'
            val = CurrentForm.HasValue("HasMaritimeAccidentOrCourtOfEnquiryDetails") ? CurrentForm.GetValue("HasMaritimeAccidentOrCourtOfEnquiryDetails") : CurrentForm.GetValue("x_HasMaritimeAccidentOrCourtOfEnquiryDetails");
            if (!HasMaritimeAccidentOrCourtOfEnquiryDetails.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("HasMaritimeAccidentOrCourtOfEnquiryDetails") && !CurrentForm.HasValue("x_HasMaritimeAccidentOrCourtOfEnquiryDetails")) // DN
                    HasMaritimeAccidentOrCourtOfEnquiryDetails.Visible = false; // Disable update for API request
                else
                    HasMaritimeAccidentOrCourtOfEnquiryDetails.SetFormValue(val);
            }

            // Check field name 'Reference1CompanyName' before field var 'x_Reference1CompanyName'
            val = CurrentForm.HasValue("Reference1CompanyName") ? CurrentForm.GetValue("Reference1CompanyName") : CurrentForm.GetValue("x_Reference1CompanyName");
            if (!Reference1CompanyName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyName") && !CurrentForm.HasValue("x_Reference1CompanyName")) // DN
                    Reference1CompanyName.Visible = false; // Disable update for API request
                else
                    Reference1CompanyName.SetFormValue(val);
            }

            // Check field name 'Reference1ContactPersonName' before field var 'x_Reference1ContactPersonName'
            val = CurrentForm.HasValue("Reference1ContactPersonName") ? CurrentForm.GetValue("Reference1ContactPersonName") : CurrentForm.GetValue("x_Reference1ContactPersonName");
            if (!Reference1ContactPersonName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1ContactPersonName") && !CurrentForm.HasValue("x_Reference1ContactPersonName")) // DN
                    Reference1ContactPersonName.Visible = false; // Disable update for API request
                else
                    Reference1ContactPersonName.SetFormValue(val);
            }

            // Check field name 'Reference1CompanyAddress' before field var 'x_Reference1CompanyAddress'
            val = CurrentForm.HasValue("Reference1CompanyAddress") ? CurrentForm.GetValue("Reference1CompanyAddress") : CurrentForm.GetValue("x_Reference1CompanyAddress");
            if (!Reference1CompanyAddress.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyAddress") && !CurrentForm.HasValue("x_Reference1CompanyAddress")) // DN
                    Reference1CompanyAddress.Visible = false; // Disable update for API request
                else
                    Reference1CompanyAddress.SetFormValue(val);
            }

            // Check field name 'Reference1CompanyCountryID' before field var 'x_Reference1CompanyCountryID'
            val = CurrentForm.HasValue("Reference1CompanyCountryID") ? CurrentForm.GetValue("Reference1CompanyCountryID") : CurrentForm.GetValue("x_Reference1CompanyCountryID");
            if (!Reference1CompanyCountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyCountryID") && !CurrentForm.HasValue("x_Reference1CompanyCountryID")) // DN
                    Reference1CompanyCountryID.Visible = false; // Disable update for API request
                else
                    Reference1CompanyCountryID.SetFormValue(val);
            }

            // Check field name 'Reference1CompanyTelephone' before field var 'x_Reference1CompanyTelephone'
            val = CurrentForm.HasValue("Reference1CompanyTelephone") ? CurrentForm.GetValue("Reference1CompanyTelephone") : CurrentForm.GetValue("x_Reference1CompanyTelephone");
            if (!Reference1CompanyTelephone.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyTelephone") && !CurrentForm.HasValue("x_Reference1CompanyTelephone")) // DN
                    Reference1CompanyTelephone.Visible = false; // Disable update for API request
                else
                    Reference1CompanyTelephone.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyName' before field var 'x_Reference2CompanyName'
            val = CurrentForm.HasValue("Reference2CompanyName") ? CurrentForm.GetValue("Reference2CompanyName") : CurrentForm.GetValue("x_Reference2CompanyName");
            if (!Reference2CompanyName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyName") && !CurrentForm.HasValue("x_Reference2CompanyName")) // DN
                    Reference2CompanyName.Visible = false; // Disable update for API request
                else
                    Reference2CompanyName.SetFormValue(val);
            }

            // Check field name 'Reference2ContactPersonName' before field var 'x_Reference2ContactPersonName'
            val = CurrentForm.HasValue("Reference2ContactPersonName") ? CurrentForm.GetValue("Reference2ContactPersonName") : CurrentForm.GetValue("x_Reference2ContactPersonName");
            if (!Reference2ContactPersonName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2ContactPersonName") && !CurrentForm.HasValue("x_Reference2ContactPersonName")) // DN
                    Reference2ContactPersonName.Visible = false; // Disable update for API request
                else
                    Reference2ContactPersonName.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyAddress' before field var 'x_Reference2CompanyAddress'
            val = CurrentForm.HasValue("Reference2CompanyAddress") ? CurrentForm.GetValue("Reference2CompanyAddress") : CurrentForm.GetValue("x_Reference2CompanyAddress");
            if (!Reference2CompanyAddress.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyAddress") && !CurrentForm.HasValue("x_Reference2CompanyAddress")) // DN
                    Reference2CompanyAddress.Visible = false; // Disable update for API request
                else
                    Reference2CompanyAddress.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyCountryID' before field var 'x_Reference2CompanyCountryID'
            val = CurrentForm.HasValue("Reference2CompanyCountryID") ? CurrentForm.GetValue("Reference2CompanyCountryID") : CurrentForm.GetValue("x_Reference2CompanyCountryID");
            if (!Reference2CompanyCountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyCountryID") && !CurrentForm.HasValue("x_Reference2CompanyCountryID")) // DN
                    Reference2CompanyCountryID.Visible = false; // Disable update for API request
                else
                    Reference2CompanyCountryID.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyTelephone' before field var 'x_Reference2CompanyTelephone'
            val = CurrentForm.HasValue("Reference2CompanyTelephone") ? CurrentForm.GetValue("Reference2CompanyTelephone") : CurrentForm.GetValue("x_Reference2CompanyTelephone");
            if (!Reference2CompanyTelephone.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyTelephone") && !CurrentForm.HasValue("x_Reference2CompanyTelephone")) // DN
                    Reference2CompanyTelephone.Visible = false; // Disable update for API request
                else
                    Reference2CompanyTelephone.SetFormValue(val);
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
                    Weight.SetFormValue(val, true, validate);
            }

            // Check field name 'Height' before field var 'x_Height'
            val = CurrentForm.HasValue("Height") ? CurrentForm.GetValue("Height") : CurrentForm.GetValue("x_Height");
            if (!Height.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Height") && !CurrentForm.HasValue("x_Height")) // DN
                    Height.Visible = false; // Disable update for API request
                else
                    Height.SetFormValue(val, true, validate);
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
                    SafetyShoesSize.SetFormValue(val, true, validate);
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

            // Check field name 'FinalAcceptedDate' before field var 'x_FinalAcceptedDate'
            val = CurrentForm.HasValue("FinalAcceptedDate") ? CurrentForm.GetValue("FinalAcceptedDate") : CurrentForm.GetValue("x_FinalAcceptedDate");
            if (!FinalAcceptedDate.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FinalAcceptedDate") && !CurrentForm.HasValue("x_FinalAcceptedDate")) // DN
                    FinalAcceptedDate.Visible = false; // Disable update for API request
                else
                    FinalAcceptedDate.SetFormValue(val, true, validate);
                FinalAcceptedDate.CurrentValue = UnformatDateTime(FinalAcceptedDate.CurrentValue, FinalAcceptedDate.FormatPattern);
            }

            // Check field name 'Reference1CompanyTelephoneCode_CountryID' before field var 'x_Reference1CompanyTelephoneCode_CountryID'
            val = CurrentForm.HasValue("Reference1CompanyTelephoneCode_CountryID") ? CurrentForm.GetValue("Reference1CompanyTelephoneCode_CountryID") : CurrentForm.GetValue("x_Reference1CompanyTelephoneCode_CountryID");
            if (!Reference1CompanyTelephoneCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference1CompanyTelephoneCode_CountryID") && !CurrentForm.HasValue("x_Reference1CompanyTelephoneCode_CountryID")) // DN
                    Reference1CompanyTelephoneCode_CountryID.Visible = false; // Disable update for API request
                else
                    Reference1CompanyTelephoneCode_CountryID.SetFormValue(val);
            }

            // Check field name 'Reference2CompanyTelephoneCode_CountryID' before field var 'x_Reference2CompanyTelephoneCode_CountryID'
            val = CurrentForm.HasValue("Reference2CompanyTelephoneCode_CountryID") ? CurrentForm.GetValue("Reference2CompanyTelephoneCode_CountryID") : CurrentForm.GetValue("x_Reference2CompanyTelephoneCode_CountryID");
            if (!Reference2CompanyTelephoneCode_CountryID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Reference2CompanyTelephoneCode_CountryID") && !CurrentForm.HasValue("x_Reference2CompanyTelephoneCode_CountryID")) // DN
                    Reference2CompanyTelephoneCode_CountryID.Visible = false; // Disable update for API request
                else
                    Reference2CompanyTelephoneCode_CountryID.SetFormValue(val);
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

            // Check field name 'RevisedReason' before field var 'x_RevisedReason'
            val = CurrentForm.HasValue("RevisedReason") ? CurrentForm.GetValue("RevisedReason") : CurrentForm.GetValue("x_RevisedReason");
            if (!RevisedReason.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RevisedReason") && !CurrentForm.HasValue("x_RevisedReason")) // DN
                    RevisedReason.Visible = false; // Disable update for API request
                else
                    RevisedReason.SetFormValue(val);
            }

            // Check field name 'RevisedDateTime' before field var 'x_RevisedDateTime'
            val = CurrentForm.HasValue("RevisedDateTime") ? CurrentForm.GetValue("RevisedDateTime") : CurrentForm.GetValue("x_RevisedDateTime");
            if (!RevisedDateTime.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("RevisedDateTime") && !CurrentForm.HasValue("x_RevisedDateTime")) // DN
                    RevisedDateTime.Visible = false; // Disable update for API request
                else
                    RevisedDateTime.SetFormValue(val, true, validate);
                RevisedDateTime.CurrentValue = UnformatDateTime(RevisedDateTime.CurrentValue, RevisedDateTime.FormatPattern);
            }

            // Check field name 'ID' before field var 'x_ID'
            val = CurrentForm.HasValue("ID") ? CurrentForm.GetValue("ID") : CurrentForm.GetValue("x_ID");
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
            IndividualCodeNumber.CurrentValue = IndividualCodeNumber.FormValue;
            FullName.CurrentValue = FullName.FormValue;
            Nationality_CountryID.CurrentValue = Nationality_CountryID.FormValue;
            CountryOfOrigin_CountryID.CurrentValue = CountryOfOrigin_CountryID.FormValue;
            DateOfBirth.CurrentValue = DateOfBirth.FormValue;
            DateOfBirth.CurrentValue = UnformatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern);
            CityOfBirth.CurrentValue = CityOfBirth.FormValue;
            MaritalStatus.CurrentValue = MaritalStatus.FormValue;
            Gender.CurrentValue = Gender.FormValue;
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
            PrimaryAddressState.CurrentValue = PrimaryAddressState.FormValue;
            PrimaryAddressNearestAirport.CurrentValue = PrimaryAddressNearestAirport.FormValue;
            PrimaryAddressPostCode.CurrentValue = PrimaryAddressPostCode.FormValue;
            PrimaryAddressCountryID.CurrentValue = PrimaryAddressCountryID.FormValue;
            PrimaryAddressHomeTel.CurrentValue = PrimaryAddressHomeTel.FormValue;
            PrimaryAddressFax.CurrentValue = PrimaryAddressFax.FormValue;
            AlternativeAddressDetail.CurrentValue = AlternativeAddressDetail.FormValue;
            AlternativeAddressCity.CurrentValue = AlternativeAddressCity.FormValue;
            AlternativeAddressState.CurrentValue = AlternativeAddressState.FormValue;
            AlternativeAddressHomeTel.CurrentValue = AlternativeAddressHomeTel.FormValue;
            AlternativeAddressPostCode.CurrentValue = AlternativeAddressPostCode.FormValue;
            AlternativeAddressCountryID.CurrentValue = AlternativeAddressCountryID.FormValue;
            MobileNumber.CurrentValue = MobileNumber.FormValue;
            _Email.CurrentValue = _Email.FormValue;
            ContactMethodEmail.CurrentValue = ContactMethodEmail.FormValue;
            ContactMethodFax.CurrentValue = ContactMethodFax.FormValue;
            ContactMethodMobilePhone.CurrentValue = ContactMethodMobilePhone.FormValue;
            ContactMethodHomePhone.CurrentValue = ContactMethodHomePhone.FormValue;
            ContactMethodPost.CurrentValue = ContactMethodPost.FormValue;
            CollarSize.CurrentValue = CollarSize.FormValue;
            ChestSize.CurrentValue = ChestSize.FormValue;
            WaistSize.CurrentValue = WaistSize.FormValue;
            InsideLegSize.CurrentValue = InsideLegSize.FormValue;
            CapSize.CurrentValue = CapSize.FormValue;
            SweaterSize_ClothesSizeID.CurrentValue = SweaterSize_ClothesSizeID.FormValue;
            BoilersuitSize_ClothesSizeID.CurrentValue = BoilersuitSize_ClothesSizeID.FormValue;
            SocialSecurityNumber.CurrentValue = SocialSecurityNumber.FormValue;
            SocialSecurityIssuingCountryID.CurrentValue = SocialSecurityIssuingCountryID.FormValue;
            PersonalTaxNumber.CurrentValue = PersonalTaxNumber.FormValue;
            PersonalTaxIssuingCountryID.CurrentValue = PersonalTaxIssuingCountryID.FormValue;
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
            NomineeValidVisa.CurrentValue = NomineeValidVisa.FormValue;
            BankName.CurrentValue = BankName.FormValue;
            BankAddress.CurrentValue = BankAddress.FormValue;
            BankAccountName.CurrentValue = BankAccountName.FormValue;
            BankAccountNumber.CurrentValue = BankAccountNumber.FormValue;
            BankSortCode.CurrentValue = BankSortCode.FormValue;
            MNOPF.CurrentValue = MNOPF.FormValue;
            MembershipNumber.CurrentValue = MembershipNumber.FormValue;
            NationalInsuranceNumber.CurrentValue = NationalInsuranceNumber.FormValue;
            AVC.CurrentValue = AVC.FormValue;
            ForeignVisaHasBeenDenied.CurrentValue = ForeignVisaHasBeenDenied.FormValue;
            ForeignVisaDenied_CountryID.CurrentValue = ForeignVisaDenied_CountryID.FormValue;
            ForeignVisaDeniedReason.CurrentValue = ForeignVisaDeniedReason.FormValue;
            HasMaritimeAccidentOrCourtOfEnquiry.CurrentValue = HasMaritimeAccidentOrCourtOfEnquiry.FormValue;
            HasMaritimeAccidentOrCourtOfEnquiryDetails.CurrentValue = HasMaritimeAccidentOrCourtOfEnquiryDetails.FormValue;
            Reference1CompanyName.CurrentValue = Reference1CompanyName.FormValue;
            Reference1ContactPersonName.CurrentValue = Reference1ContactPersonName.FormValue;
            Reference1CompanyAddress.CurrentValue = Reference1CompanyAddress.FormValue;
            Reference1CompanyCountryID.CurrentValue = Reference1CompanyCountryID.FormValue;
            Reference1CompanyTelephone.CurrentValue = Reference1CompanyTelephone.FormValue;
            Reference2CompanyName.CurrentValue = Reference2CompanyName.FormValue;
            Reference2ContactPersonName.CurrentValue = Reference2ContactPersonName.FormValue;
            Reference2CompanyAddress.CurrentValue = Reference2CompanyAddress.FormValue;
            Reference2CompanyCountryID.CurrentValue = Reference2CompanyCountryID.FormValue;
            Reference2CompanyTelephone.CurrentValue = Reference2CompanyTelephone.FormValue;
            Status.CurrentValue = Status.FormValue;
            Reason.CurrentValue = Reason.FormValue;
            Weight.CurrentValue = Weight.FormValue;
            Height.CurrentValue = Height.FormValue;
            CoverallSize.CurrentValue = CoverallSize.FormValue;
            SafetyShoesSize.CurrentValue = SafetyShoesSize.FormValue;
            ShirtSize.CurrentValue = ShirtSize.FormValue;
            TrousersSize.CurrentValue = TrousersSize.FormValue;
            NSSF_Health_Number.CurrentValue = NSSF_Health_Number.FormValue;
            NSSF_Occupation_Number.CurrentValue = NSSF_Occupation_Number.FormValue;
            FinalAcceptedDate.CurrentValue = FinalAcceptedDate.FormValue;
            FinalAcceptedDate.CurrentValue = UnformatDateTime(FinalAcceptedDate.CurrentValue, FinalAcceptedDate.FormatPattern);
            Reference1CompanyTelephoneCode_CountryID.CurrentValue = Reference1CompanyTelephoneCode_CountryID.FormValue;
            Reference2CompanyTelephoneCode_CountryID.CurrentValue = Reference2CompanyTelephoneCode_CountryID.FormValue;
            MobileNumberCode_CountryID.CurrentValue = MobileNumberCode_CountryID.FormValue;
            PrimaryAddressHomeTelCode_CountryID.CurrentValue = PrimaryAddressHomeTelCode_CountryID.FormValue;
            AlternativeAddressHomeTelCode_CountryID.CurrentValue = AlternativeAddressHomeTelCode_CountryID.FormValue;
            NomineeAddressHomeTelCode_CountryID.CurrentValue = NomineeAddressHomeTelCode_CountryID.FormValue;
            NomineeMobileNumberCode_CountryID.CurrentValue = NomineeMobileNumberCode_CountryID.FormValue;
            RevisedReason.CurrentValue = RevisedReason.FormValue;
            RevisedDateTime.CurrentValue = RevisedDateTime.FormValue;
            RevisedDateTime.CurrentValue = UnformatDateTime(RevisedDateTime.CurrentValue, RevisedDateTime.FormatPattern);
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
                res = ShowOptionLink("add");
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

                // MaritalStatus
                MaritalStatus.HrefValue = "";

                // Gender
                Gender.HrefValue = "";

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

                // PrimaryAddressState
                PrimaryAddressState.HrefValue = "";

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.HrefValue = "";

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.HrefValue = "";

                // PrimaryAddressCountryID
                PrimaryAddressCountryID.HrefValue = "";

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.HrefValue = "";

                // PrimaryAddressFax
                PrimaryAddressFax.HrefValue = "";

                // AlternativeAddressDetail
                AlternativeAddressDetail.HrefValue = "";

                // AlternativeAddressCity
                AlternativeAddressCity.HrefValue = "";

                // AlternativeAddressState
                AlternativeAddressState.HrefValue = "";

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

                // ContactMethodEmail
                ContactMethodEmail.HrefValue = "";

                // ContactMethodFax
                ContactMethodFax.HrefValue = "";

                // ContactMethodMobilePhone
                ContactMethodMobilePhone.HrefValue = "";

                // ContactMethodHomePhone
                ContactMethodHomePhone.HrefValue = "";

                // ContactMethodPost
                ContactMethodPost.HrefValue = "";

                // CollarSize
                CollarSize.HrefValue = "";

                // ChestSize
                ChestSize.HrefValue = "";

                // WaistSize
                WaistSize.HrefValue = "";

                // InsideLegSize
                InsideLegSize.HrefValue = "";

                // CapSize
                CapSize.HrefValue = "";

                // SweaterSize_ClothesSizeID
                SweaterSize_ClothesSizeID.HrefValue = "";

                // BoilersuitSize_ClothesSizeID
                BoilersuitSize_ClothesSizeID.HrefValue = "";

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

                // NomineeValidVisa
                NomineeValidVisa.HrefValue = "";

                // BankName
                BankName.HrefValue = "";

                // BankAddress
                BankAddress.HrefValue = "";

                // BankAccountName
                BankAccountName.HrefValue = "";

                // BankAccountNumber
                BankAccountNumber.HrefValue = "";

                // BankSortCode
                BankSortCode.HrefValue = "";

                // MNOPF
                MNOPF.HrefValue = "";

                // MembershipNumber
                MembershipNumber.HrefValue = "";

                // NationalInsuranceNumber
                NationalInsuranceNumber.HrefValue = "";

                // AVC
                AVC.HrefValue = "";

                // ForeignVisaHasBeenDenied
                ForeignVisaHasBeenDenied.HrefValue = "";

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.HrefValue = "";

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.HrefValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.HrefValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.HrefValue = "";

                // Reference1CompanyName
                Reference1CompanyName.HrefValue = "";

                // Reference1ContactPersonName
                Reference1ContactPersonName.HrefValue = "";

                // Reference1CompanyAddress
                Reference1CompanyAddress.HrefValue = "";

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.HrefValue = "";

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.HrefValue = "";

                // Reference2CompanyName
                Reference2CompanyName.HrefValue = "";

                // Reference2ContactPersonName
                Reference2ContactPersonName.HrefValue = "";

                // Reference2CompanyAddress
                Reference2CompanyAddress.HrefValue = "";

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.HrefValue = "";

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.HrefValue = "";

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

                // NSSF_Health_Number
                NSSF_Health_Number.HrefValue = "";

                // NSSF_Occupation_Number
                NSSF_Occupation_Number.HrefValue = "";

                // FinalAcceptedDate
                FinalAcceptedDate.HrefValue = "";

                // Reference1CompanyTelephoneCode_CountryID
                Reference1CompanyTelephoneCode_CountryID.HrefValue = "";

                // Reference2CompanyTelephoneCode_CountryID
                Reference2CompanyTelephoneCode_CountryID.HrefValue = "";

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

                // RevisedReason
                RevisedReason.HrefValue = "";

                // RevisedDateTime
                RevisedDateTime.HrefValue = "";
            } else if (RowType == RowType.Add) {
                // IndividualCodeNumber
                IndividualCodeNumber.SetupEditAttributes();
                if (!IndividualCodeNumber.Raw)
                    IndividualCodeNumber.CurrentValue = HtmlDecode(IndividualCodeNumber.CurrentValue);
                IndividualCodeNumber.EditValue = HtmlEncode(IndividualCodeNumber.CurrentValue);
                IndividualCodeNumber.PlaceHolder = RemoveHtml(IndividualCodeNumber.Caption);

                // FullName
                FullName.SetupEditAttributes();
                if (!FullName.Raw)
                    FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
                FullName.EditValue = HtmlEncode(FullName.CurrentValue);
                FullName.PlaceHolder = RemoveHtml(FullName.Caption);

                // RequiredPhoto
                RequiredPhoto.SetupEditAttributes();
                RequiredPhoto.EditAttrs["accept"] = "jpeg,png,jpg";
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
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(RequiredPhoto);

                // VisaPhoto
                VisaPhoto.SetupEditAttributes();
                VisaPhoto.EditAttrs["accept"] = "jpeg,png,jpg";
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
                if ((IsShow || IsCopy) && !EventCancelled)
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

                // PrimaryAddressState
                PrimaryAddressState.SetupEditAttributes();
                if (!PrimaryAddressState.Raw)
                    PrimaryAddressState.CurrentValue = HtmlDecode(PrimaryAddressState.CurrentValue);
                PrimaryAddressState.EditValue = HtmlEncode(PrimaryAddressState.CurrentValue);
                PrimaryAddressState.PlaceHolder = RemoveHtml(PrimaryAddressState.Caption);

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.SetupEditAttributes();
                if (!PrimaryAddressNearestAirport.Raw)
                    PrimaryAddressNearestAirport.CurrentValue = HtmlDecode(PrimaryAddressNearestAirport.CurrentValue);
                PrimaryAddressNearestAirport.EditValue = HtmlEncode(PrimaryAddressNearestAirport.CurrentValue);
                PrimaryAddressNearestAirport.PlaceHolder = RemoveHtml(PrimaryAddressNearestAirport.Caption);

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

                // PrimaryAddressFax
                PrimaryAddressFax.SetupEditAttributes();
                if (!PrimaryAddressFax.Raw)
                    PrimaryAddressFax.CurrentValue = HtmlDecode(PrimaryAddressFax.CurrentValue);
                PrimaryAddressFax.EditValue = HtmlEncode(PrimaryAddressFax.CurrentValue);
                PrimaryAddressFax.PlaceHolder = RemoveHtml(PrimaryAddressFax.Caption);

                // AlternativeAddressDetail
                AlternativeAddressDetail.SetupEditAttributes();
                AlternativeAddressDetail.EditValue = AlternativeAddressDetail.CurrentValue; // DN
                AlternativeAddressDetail.PlaceHolder = RemoveHtml(AlternativeAddressDetail.Caption);

                // AlternativeAddressCity
                AlternativeAddressCity.SetupEditAttributes();
                if (!AlternativeAddressCity.Raw)
                    AlternativeAddressCity.CurrentValue = HtmlDecode(AlternativeAddressCity.CurrentValue);
                AlternativeAddressCity.EditValue = HtmlEncode(AlternativeAddressCity.CurrentValue);
                AlternativeAddressCity.PlaceHolder = RemoveHtml(AlternativeAddressCity.Caption);

                // AlternativeAddressState
                AlternativeAddressState.SetupEditAttributes();
                if (!AlternativeAddressState.Raw)
                    AlternativeAddressState.CurrentValue = HtmlDecode(AlternativeAddressState.CurrentValue);
                AlternativeAddressState.EditValue = HtmlEncode(AlternativeAddressState.CurrentValue);
                AlternativeAddressState.PlaceHolder = RemoveHtml(AlternativeAddressState.Caption);

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
                CollarSize.EditValue = CollarSize.CurrentValue; // DN
                CollarSize.PlaceHolder = RemoveHtml(CollarSize.Caption);
                if (!Empty(CollarSize.EditValue) && IsNumeric(CollarSize.EditValue))
                    CollarSize.EditValue = FormatNumber(CollarSize.EditValue, null);

                // ChestSize
                ChestSize.SetupEditAttributes();
                ChestSize.EditValue = ChestSize.CurrentValue; // DN
                ChestSize.PlaceHolder = RemoveHtml(ChestSize.Caption);
                if (!Empty(ChestSize.EditValue) && IsNumeric(ChestSize.EditValue))
                    ChestSize.EditValue = FormatNumber(ChestSize.EditValue, null);

                // WaistSize
                WaistSize.SetupEditAttributes();
                WaistSize.EditValue = WaistSize.CurrentValue; // DN
                WaistSize.PlaceHolder = RemoveHtml(WaistSize.Caption);
                if (!Empty(WaistSize.EditValue) && IsNumeric(WaistSize.EditValue))
                    WaistSize.EditValue = FormatNumber(WaistSize.EditValue, null);

                // InsideLegSize
                InsideLegSize.SetupEditAttributes();
                InsideLegSize.EditValue = InsideLegSize.CurrentValue; // DN
                InsideLegSize.PlaceHolder = RemoveHtml(InsideLegSize.Caption);
                if (!Empty(InsideLegSize.EditValue) && IsNumeric(InsideLegSize.EditValue))
                    InsideLegSize.EditValue = FormatNumber(InsideLegSize.EditValue, null);

                // CapSize
                CapSize.SetupEditAttributes();
                CapSize.EditValue = CapSize.CurrentValue; // DN
                CapSize.PlaceHolder = RemoveHtml(CapSize.Caption);
                if (!Empty(CapSize.EditValue) && IsNumeric(CapSize.EditValue))
                    CapSize.EditValue = FormatNumber(CapSize.EditValue, null);

                // SweaterSize_ClothesSizeID
                SweaterSize_ClothesSizeID.SetupEditAttributes();
                curVal = ConvertToString(SweaterSize_ClothesSizeID.CurrentValue)?.Trim() ?? "";
                if (SweaterSize_ClothesSizeID.Lookup != null && IsDictionary(SweaterSize_ClothesSizeID.Lookup?.Options) && SweaterSize_ClothesSizeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    SweaterSize_ClothesSizeID.EditValue = SweaterSize_ClothesSizeID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", SweaterSize_ClothesSizeID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = SweaterSize_ClothesSizeID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    SweaterSize_ClothesSizeID.EditValue = rswrk;
                }
                SweaterSize_ClothesSizeID.PlaceHolder = RemoveHtml(SweaterSize_ClothesSizeID.Caption);
                if (!Empty(SweaterSize_ClothesSizeID.EditValue) && IsNumeric(SweaterSize_ClothesSizeID.EditValue))
                    SweaterSize_ClothesSizeID.EditValue = FormatNumber(SweaterSize_ClothesSizeID.EditValue, null);

                // BoilersuitSize_ClothesSizeID
                BoilersuitSize_ClothesSizeID.SetupEditAttributes();
                curVal = ConvertToString(BoilersuitSize_ClothesSizeID.CurrentValue)?.Trim() ?? "";
                if (BoilersuitSize_ClothesSizeID.Lookup != null && IsDictionary(BoilersuitSize_ClothesSizeID.Lookup?.Options) && BoilersuitSize_ClothesSizeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    BoilersuitSize_ClothesSizeID.EditValue = BoilersuitSize_ClothesSizeID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", BoilersuitSize_ClothesSizeID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = BoilersuitSize_ClothesSizeID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    BoilersuitSize_ClothesSizeID.EditValue = rswrk;
                }
                BoilersuitSize_ClothesSizeID.PlaceHolder = RemoveHtml(BoilersuitSize_ClothesSizeID.Caption);
                if (!Empty(BoilersuitSize_ClothesSizeID.EditValue) && IsNumeric(BoilersuitSize_ClothesSizeID.EditValue))
                    BoilersuitSize_ClothesSizeID.EditValue = FormatNumber(BoilersuitSize_ClothesSizeID.EditValue, null);

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
                SocialSecurityImage.EditAttrs["accept"] = "jpg,jpeg,gif,png";
                SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
                if (!IsNull(SocialSecurityImage.Upload.DbValue)) {
                    SocialSecurityImage.EditValue = SocialSecurityImage.Upload.DbValue;
                } else {
                    SocialSecurityImage.EditValue = "";
                }
                if (!Empty(SocialSecurityImage.CurrentValue))
                        SocialSecurityImage.Upload.FileName = ConvertToString(SocialSecurityImage.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
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
                PersonalTaxImage.EditAttrs["accept"] = "jpg,jpeg,gif,png";
                PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
                if (!IsNull(PersonalTaxImage.Upload.DbValue)) {
                    PersonalTaxImage.EditValue = PersonalTaxImage.Upload.DbValue;
                } else {
                    PersonalTaxImage.EditValue = "";
                }
                if (!Empty(PersonalTaxImage.CurrentValue))
                        PersonalTaxImage.Upload.FileName = ConvertToString(PersonalTaxImage.CurrentValue);
                if ((IsShow || IsCopy) && !EventCancelled)
                    await RenderUploadField(PersonalTaxImage);

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

                // NomineeValidVisa
                NomineeValidVisa.SetupEditAttributes();
                if (!NomineeValidVisa.Raw)
                    NomineeValidVisa.CurrentValue = HtmlDecode(NomineeValidVisa.CurrentValue);
                NomineeValidVisa.EditValue = HtmlEncode(NomineeValidVisa.CurrentValue);
                NomineeValidVisa.PlaceHolder = RemoveHtml(NomineeValidVisa.Caption);

                // BankName
                BankName.SetupEditAttributes();
                if (!BankName.Raw)
                    BankName.CurrentValue = HtmlDecode(BankName.CurrentValue);
                BankName.EditValue = HtmlEncode(BankName.CurrentValue);
                BankName.PlaceHolder = RemoveHtml(BankName.Caption);

                // BankAddress
                BankAddress.SetupEditAttributes();
                BankAddress.EditValue = BankAddress.CurrentValue; // DN
                BankAddress.PlaceHolder = RemoveHtml(BankAddress.Caption);

                // BankAccountName
                BankAccountName.SetupEditAttributes();
                if (!BankAccountName.Raw)
                    BankAccountName.CurrentValue = HtmlDecode(BankAccountName.CurrentValue);
                BankAccountName.EditValue = HtmlEncode(BankAccountName.CurrentValue);
                BankAccountName.PlaceHolder = RemoveHtml(BankAccountName.Caption);

                // BankAccountNumber
                BankAccountNumber.SetupEditAttributes();
                if (!BankAccountNumber.Raw)
                    BankAccountNumber.CurrentValue = HtmlDecode(BankAccountNumber.CurrentValue);
                BankAccountNumber.EditValue = HtmlEncode(BankAccountNumber.CurrentValue);
                BankAccountNumber.PlaceHolder = RemoveHtml(BankAccountNumber.Caption);

                // BankSortCode
                BankSortCode.SetupEditAttributes();
                if (!BankSortCode.Raw)
                    BankSortCode.CurrentValue = HtmlDecode(BankSortCode.CurrentValue);
                BankSortCode.EditValue = HtmlEncode(BankSortCode.CurrentValue);
                BankSortCode.PlaceHolder = RemoveHtml(BankSortCode.Caption);

                // MNOPF
                MNOPF.SetupEditAttributes();
                if (!MNOPF.Raw)
                    MNOPF.CurrentValue = HtmlDecode(MNOPF.CurrentValue);
                MNOPF.EditValue = HtmlEncode(MNOPF.CurrentValue);
                MNOPF.PlaceHolder = RemoveHtml(MNOPF.Caption);

                // MembershipNumber
                MembershipNumber.SetupEditAttributes();
                if (!MembershipNumber.Raw)
                    MembershipNumber.CurrentValue = HtmlDecode(MembershipNumber.CurrentValue);
                MembershipNumber.EditValue = HtmlEncode(MembershipNumber.CurrentValue);
                MembershipNumber.PlaceHolder = RemoveHtml(MembershipNumber.Caption);

                // NationalInsuranceNumber
                NationalInsuranceNumber.SetupEditAttributes();
                if (!NationalInsuranceNumber.Raw)
                    NationalInsuranceNumber.CurrentValue = HtmlDecode(NationalInsuranceNumber.CurrentValue);
                NationalInsuranceNumber.EditValue = HtmlEncode(NationalInsuranceNumber.CurrentValue);
                NationalInsuranceNumber.PlaceHolder = RemoveHtml(NationalInsuranceNumber.Caption);

                // AVC
                AVC.SetupEditAttributes();
                if (!AVC.Raw)
                    AVC.CurrentValue = HtmlDecode(AVC.CurrentValue);
                AVC.EditValue = HtmlEncode(AVC.CurrentValue);
                AVC.PlaceHolder = RemoveHtml(AVC.Caption);

                // ForeignVisaHasBeenDenied
                ForeignVisaHasBeenDenied.EditValue = ForeignVisaHasBeenDenied.Options(false);
                ForeignVisaHasBeenDenied.PlaceHolder = RemoveHtml(ForeignVisaHasBeenDenied.Caption);

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.SetupEditAttributes();
                curVal = ConvertToString(ForeignVisaDenied_CountryID.CurrentValue)?.Trim() ?? "";
                if (ForeignVisaDenied_CountryID.Lookup != null && IsDictionary(ForeignVisaDenied_CountryID.Lookup?.Options) && ForeignVisaDenied_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ForeignVisaDenied_CountryID.EditValue = ForeignVisaDenied_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", ForeignVisaDenied_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = ForeignVisaDenied_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    ForeignVisaDenied_CountryID.EditValue = rswrk;
                }
                ForeignVisaDenied_CountryID.PlaceHolder = RemoveHtml(ForeignVisaDenied_CountryID.Caption);
                if (!Empty(ForeignVisaDenied_CountryID.EditValue) && IsNumeric(ForeignVisaDenied_CountryID.EditValue))
                    ForeignVisaDenied_CountryID.EditValue = FormatNumber(ForeignVisaDenied_CountryID.EditValue, null);

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.SetupEditAttributes();
                ForeignVisaDeniedReason.EditValue = ForeignVisaDeniedReason.CurrentValue; // DN
                ForeignVisaDeniedReason.PlaceHolder = RemoveHtml(ForeignVisaDeniedReason.Caption);

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.EditValue = HasMaritimeAccidentOrCourtOfEnquiry.Options(false);
                HasMaritimeAccidentOrCourtOfEnquiry.PlaceHolder = RemoveHtml(HasMaritimeAccidentOrCourtOfEnquiry.Caption);

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.SetupEditAttributes();
                HasMaritimeAccidentOrCourtOfEnquiryDetails.EditValue = HasMaritimeAccidentOrCourtOfEnquiryDetails.CurrentValue; // DN
                HasMaritimeAccidentOrCourtOfEnquiryDetails.PlaceHolder = RemoveHtml(HasMaritimeAccidentOrCourtOfEnquiryDetails.Caption);

                // Reference1CompanyName
                Reference1CompanyName.SetupEditAttributes();
                if (!Reference1CompanyName.Raw)
                    Reference1CompanyName.CurrentValue = HtmlDecode(Reference1CompanyName.CurrentValue);
                Reference1CompanyName.EditValue = HtmlEncode(Reference1CompanyName.CurrentValue);
                Reference1CompanyName.PlaceHolder = RemoveHtml(Reference1CompanyName.Caption);

                // Reference1ContactPersonName
                Reference1ContactPersonName.SetupEditAttributes();
                if (!Reference1ContactPersonName.Raw)
                    Reference1ContactPersonName.CurrentValue = HtmlDecode(Reference1ContactPersonName.CurrentValue);
                Reference1ContactPersonName.EditValue = HtmlEncode(Reference1ContactPersonName.CurrentValue);
                Reference1ContactPersonName.PlaceHolder = RemoveHtml(Reference1ContactPersonName.Caption);

                // Reference1CompanyAddress
                Reference1CompanyAddress.SetupEditAttributes();
                Reference1CompanyAddress.EditValue = Reference1CompanyAddress.CurrentValue; // DN
                Reference1CompanyAddress.PlaceHolder = RemoveHtml(Reference1CompanyAddress.Caption);

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference1CompanyCountryID.CurrentValue)?.Trim() ?? "";
                if (Reference1CompanyCountryID.Lookup != null && IsDictionary(Reference1CompanyCountryID.Lookup?.Options) && Reference1CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference1CompanyCountryID.EditValue = Reference1CompanyCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference1CompanyCountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = Reference1CompanyCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference1CompanyCountryID.EditValue = rswrk;
                }
                Reference1CompanyCountryID.PlaceHolder = RemoveHtml(Reference1CompanyCountryID.Caption);
                if (!Empty(Reference1CompanyCountryID.EditValue) && IsNumeric(Reference1CompanyCountryID.EditValue))
                    Reference1CompanyCountryID.EditValue = FormatNumber(Reference1CompanyCountryID.EditValue, null);

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.SetupEditAttributes();
                if (!Reference1CompanyTelephone.Raw)
                    Reference1CompanyTelephone.CurrentValue = HtmlDecode(Reference1CompanyTelephone.CurrentValue);
                Reference1CompanyTelephone.EditValue = HtmlEncode(Reference1CompanyTelephone.CurrentValue);
                Reference1CompanyTelephone.PlaceHolder = RemoveHtml(Reference1CompanyTelephone.Caption);

                // Reference2CompanyName
                Reference2CompanyName.SetupEditAttributes();
                if (!Reference2CompanyName.Raw)
                    Reference2CompanyName.CurrentValue = HtmlDecode(Reference2CompanyName.CurrentValue);
                Reference2CompanyName.EditValue = HtmlEncode(Reference2CompanyName.CurrentValue);
                Reference2CompanyName.PlaceHolder = RemoveHtml(Reference2CompanyName.Caption);

                // Reference2ContactPersonName
                Reference2ContactPersonName.SetupEditAttributes();
                if (!Reference2ContactPersonName.Raw)
                    Reference2ContactPersonName.CurrentValue = HtmlDecode(Reference2ContactPersonName.CurrentValue);
                Reference2ContactPersonName.EditValue = HtmlEncode(Reference2ContactPersonName.CurrentValue);
                Reference2ContactPersonName.PlaceHolder = RemoveHtml(Reference2ContactPersonName.Caption);

                // Reference2CompanyAddress
                Reference2CompanyAddress.SetupEditAttributes();
                Reference2CompanyAddress.EditValue = Reference2CompanyAddress.CurrentValue; // DN
                Reference2CompanyAddress.PlaceHolder = RemoveHtml(Reference2CompanyAddress.Caption);

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference2CompanyCountryID.CurrentValue)?.Trim() ?? "";
                if (Reference2CompanyCountryID.Lookup != null && IsDictionary(Reference2CompanyCountryID.Lookup?.Options) && Reference2CompanyCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference2CompanyCountryID.EditValue = Reference2CompanyCountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference2CompanyCountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = Reference2CompanyCountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference2CompanyCountryID.EditValue = rswrk;
                }
                Reference2CompanyCountryID.PlaceHolder = RemoveHtml(Reference2CompanyCountryID.Caption);
                if (!Empty(Reference2CompanyCountryID.EditValue) && IsNumeric(Reference2CompanyCountryID.EditValue))
                    Reference2CompanyCountryID.EditValue = FormatNumber(Reference2CompanyCountryID.EditValue, null);

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.SetupEditAttributes();
                if (!Reference2CompanyTelephone.Raw)
                    Reference2CompanyTelephone.CurrentValue = HtmlDecode(Reference2CompanyTelephone.CurrentValue);
                Reference2CompanyTelephone.EditValue = HtmlEncode(Reference2CompanyTelephone.CurrentValue);
                Reference2CompanyTelephone.PlaceHolder = RemoveHtml(Reference2CompanyTelephone.Caption);

                // Status
                Status.SetupEditAttributes();
                if (!Status.Raw)
                    Status.CurrentValue = HtmlDecode(Status.CurrentValue);
                Status.EditValue = HtmlEncode(Status.CurrentValue);
                Status.PlaceHolder = RemoveHtml(Status.Caption);

                // Reason
                Reason.SetupEditAttributes();
                if (!Reason.Raw)
                    Reason.CurrentValue = HtmlDecode(Reason.CurrentValue);
                Reason.EditValue = HtmlEncode(Reason.CurrentValue);
                Reason.PlaceHolder = RemoveHtml(Reason.Caption);

                // Weight
                Weight.SetupEditAttributes();
                Weight.EditValue = Weight.CurrentValue; // DN
                Weight.PlaceHolder = RemoveHtml(Weight.Caption);
                if (!Empty(Weight.EditValue) && IsNumeric(Weight.EditValue))
                    Weight.EditValue = FormatNumber(Weight.EditValue, null);

                // Height
                Height.SetupEditAttributes();
                Height.EditValue = Height.CurrentValue; // DN
                Height.PlaceHolder = RemoveHtml(Height.Caption);
                if (!Empty(Height.EditValue) && IsNumeric(Height.EditValue))
                    Height.EditValue = FormatNumber(Height.EditValue, null);

                // CoverallSize
                CoverallSize.SetupEditAttributes();
                if (!CoverallSize.Raw)
                    CoverallSize.CurrentValue = HtmlDecode(CoverallSize.CurrentValue);
                CoverallSize.EditValue = HtmlEncode(CoverallSize.CurrentValue);
                CoverallSize.PlaceHolder = RemoveHtml(CoverallSize.Caption);

                // SafetyShoesSize
                SafetyShoesSize.SetupEditAttributes();
                SafetyShoesSize.EditValue = SafetyShoesSize.CurrentValue; // DN
                SafetyShoesSize.PlaceHolder = RemoveHtml(SafetyShoesSize.Caption);
                if (!Empty(SafetyShoesSize.EditValue) && IsNumeric(SafetyShoesSize.EditValue))
                    SafetyShoesSize.EditValue = FormatNumber(SafetyShoesSize.EditValue, null);

                // ShirtSize
                ShirtSize.SetupEditAttributes();
                if (!ShirtSize.Raw)
                    ShirtSize.CurrentValue = HtmlDecode(ShirtSize.CurrentValue);
                ShirtSize.EditValue = HtmlEncode(ShirtSize.CurrentValue);
                ShirtSize.PlaceHolder = RemoveHtml(ShirtSize.Caption);

                // TrousersSize
                TrousersSize.SetupEditAttributes();
                if (!TrousersSize.Raw)
                    TrousersSize.CurrentValue = HtmlDecode(TrousersSize.CurrentValue);
                TrousersSize.EditValue = HtmlEncode(TrousersSize.CurrentValue);
                TrousersSize.PlaceHolder = RemoveHtml(TrousersSize.Caption);

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

                // FinalAcceptedDate
                FinalAcceptedDate.SetupEditAttributes();
                FinalAcceptedDate.EditValue = FormatDateTime(FinalAcceptedDate.CurrentValue, FinalAcceptedDate.FormatPattern); // DN
                FinalAcceptedDate.PlaceHolder = RemoveHtml(FinalAcceptedDate.Caption);

                // Reference1CompanyTelephoneCode_CountryID
                Reference1CompanyTelephoneCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference1CompanyTelephoneCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (Reference1CompanyTelephoneCode_CountryID.Lookup != null && IsDictionary(Reference1CompanyTelephoneCode_CountryID.Lookup?.Options) && Reference1CompanyTelephoneCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference1CompanyTelephoneCode_CountryID.EditValue = Reference1CompanyTelephoneCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference1CompanyTelephoneCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = Reference1CompanyTelephoneCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference1CompanyTelephoneCode_CountryID.EditValue = rswrk;
                }
                Reference1CompanyTelephoneCode_CountryID.PlaceHolder = RemoveHtml(Reference1CompanyTelephoneCode_CountryID.Caption);

                // Reference2CompanyTelephoneCode_CountryID
                Reference2CompanyTelephoneCode_CountryID.SetupEditAttributes();
                curVal = ConvertToString(Reference2CompanyTelephoneCode_CountryID.CurrentValue)?.Trim() ?? "";
                if (Reference2CompanyTelephoneCode_CountryID.Lookup != null && IsDictionary(Reference2CompanyTelephoneCode_CountryID.Lookup?.Options) && Reference2CompanyTelephoneCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Reference2CompanyTelephoneCode_CountryID.EditValue = Reference2CompanyTelephoneCode_CountryID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", Reference2CompanyTelephoneCode_CountryID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = Reference2CompanyTelephoneCode_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    Reference2CompanyTelephoneCode_CountryID.EditValue = rswrk;
                }
                Reference2CompanyTelephoneCode_CountryID.PlaceHolder = RemoveHtml(Reference2CompanyTelephoneCode_CountryID.Caption);

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

                // RevisedReason
                RevisedReason.SetupEditAttributes();
                if (!RevisedReason.Raw)
                    RevisedReason.CurrentValue = HtmlDecode(RevisedReason.CurrentValue);
                RevisedReason.EditValue = HtmlEncode(RevisedReason.CurrentValue);
                RevisedReason.PlaceHolder = RemoveHtml(RevisedReason.Caption);

                // RevisedDateTime
                RevisedDateTime.SetupEditAttributes();
                RevisedDateTime.EditValue = FormatDateTime(RevisedDateTime.CurrentValue, RevisedDateTime.FormatPattern); // DN
                RevisedDateTime.PlaceHolder = RemoveHtml(RevisedDateTime.Caption);

                // Add refer script

                // IndividualCodeNumber
                IndividualCodeNumber.HrefValue = "";

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

                // MaritalStatus
                MaritalStatus.HrefValue = "";

                // Gender
                Gender.HrefValue = "";

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

                // PrimaryAddressState
                PrimaryAddressState.HrefValue = "";

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.HrefValue = "";

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.HrefValue = "";

                // PrimaryAddressCountryID
                PrimaryAddressCountryID.HrefValue = "";

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.HrefValue = "";

                // PrimaryAddressFax
                PrimaryAddressFax.HrefValue = "";

                // AlternativeAddressDetail
                AlternativeAddressDetail.HrefValue = "";

                // AlternativeAddressCity
                AlternativeAddressCity.HrefValue = "";

                // AlternativeAddressState
                AlternativeAddressState.HrefValue = "";

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

                // ContactMethodEmail
                ContactMethodEmail.HrefValue = "";

                // ContactMethodFax
                ContactMethodFax.HrefValue = "";

                // ContactMethodMobilePhone
                ContactMethodMobilePhone.HrefValue = "";

                // ContactMethodHomePhone
                ContactMethodHomePhone.HrefValue = "";

                // ContactMethodPost
                ContactMethodPost.HrefValue = "";

                // CollarSize
                CollarSize.HrefValue = "";

                // ChestSize
                ChestSize.HrefValue = "";

                // WaistSize
                WaistSize.HrefValue = "";

                // InsideLegSize
                InsideLegSize.HrefValue = "";

                // CapSize
                CapSize.HrefValue = "";

                // SweaterSize_ClothesSizeID
                SweaterSize_ClothesSizeID.HrefValue = "";

                // BoilersuitSize_ClothesSizeID
                BoilersuitSize_ClothesSizeID.HrefValue = "";

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

                // NomineeValidVisa
                NomineeValidVisa.HrefValue = "";

                // BankName
                BankName.HrefValue = "";

                // BankAddress
                BankAddress.HrefValue = "";

                // BankAccountName
                BankAccountName.HrefValue = "";

                // BankAccountNumber
                BankAccountNumber.HrefValue = "";

                // BankSortCode
                BankSortCode.HrefValue = "";

                // MNOPF
                MNOPF.HrefValue = "";

                // MembershipNumber
                MembershipNumber.HrefValue = "";

                // NationalInsuranceNumber
                NationalInsuranceNumber.HrefValue = "";

                // AVC
                AVC.HrefValue = "";

                // ForeignVisaHasBeenDenied
                ForeignVisaHasBeenDenied.HrefValue = "";

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.HrefValue = "";

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.HrefValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.HrefValue = "";

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.HrefValue = "";

                // Reference1CompanyName
                Reference1CompanyName.HrefValue = "";

                // Reference1ContactPersonName
                Reference1ContactPersonName.HrefValue = "";

                // Reference1CompanyAddress
                Reference1CompanyAddress.HrefValue = "";

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.HrefValue = "";

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.HrefValue = "";

                // Reference2CompanyName
                Reference2CompanyName.HrefValue = "";

                // Reference2ContactPersonName
                Reference2ContactPersonName.HrefValue = "";

                // Reference2CompanyAddress
                Reference2CompanyAddress.HrefValue = "";

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.HrefValue = "";

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.HrefValue = "";

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

                // NSSF_Health_Number
                NSSF_Health_Number.HrefValue = "";

                // NSSF_Occupation_Number
                NSSF_Occupation_Number.HrefValue = "";

                // FinalAcceptedDate
                FinalAcceptedDate.HrefValue = "";

                // Reference1CompanyTelephoneCode_CountryID
                Reference1CompanyTelephoneCode_CountryID.HrefValue = "";

                // Reference2CompanyTelephoneCode_CountryID
                Reference2CompanyTelephoneCode_CountryID.HrefValue = "";

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

                // RevisedReason
                RevisedReason.HrefValue = "";

                // RevisedDateTime
                RevisedDateTime.HrefValue = "";
            }
            if (RowType == RowType.Add || RowType == RowType.Edit || RowType == RowType.Search) // Add/Edit/Search row
                SetupFieldTitles();

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
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
            if (MaritalStatus.Required) {
                if (!MaritalStatus.IsDetailKey && Empty(MaritalStatus.FormValue)) {
                    MaritalStatus.AddErrorMessage(ConvertToString(MaritalStatus.RequiredErrorMessage).Replace("%s", MaritalStatus.Caption));
                }
            }
            if (Gender.Required) {
                if (!Gender.IsDetailKey && Empty(Gender.FormValue)) {
                    Gender.AddErrorMessage(ConvertToString(Gender.RequiredErrorMessage).Replace("%s", Gender.Caption));
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
            if (PrimaryAddressState.Required) {
                if (!PrimaryAddressState.IsDetailKey && Empty(PrimaryAddressState.FormValue)) {
                    PrimaryAddressState.AddErrorMessage(ConvertToString(PrimaryAddressState.RequiredErrorMessage).Replace("%s", PrimaryAddressState.Caption));
                }
            }
            if (PrimaryAddressNearestAirport.Required) {
                if (!PrimaryAddressNearestAirport.IsDetailKey && Empty(PrimaryAddressNearestAirport.FormValue)) {
                    PrimaryAddressNearestAirport.AddErrorMessage(ConvertToString(PrimaryAddressNearestAirport.RequiredErrorMessage).Replace("%s", PrimaryAddressNearestAirport.Caption));
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
            if (PrimaryAddressFax.Required) {
                if (!PrimaryAddressFax.IsDetailKey && Empty(PrimaryAddressFax.FormValue)) {
                    PrimaryAddressFax.AddErrorMessage(ConvertToString(PrimaryAddressFax.RequiredErrorMessage).Replace("%s", PrimaryAddressFax.Caption));
                }
            }
            if (AlternativeAddressDetail.Required) {
                if (!AlternativeAddressDetail.IsDetailKey && Empty(AlternativeAddressDetail.FormValue)) {
                    AlternativeAddressDetail.AddErrorMessage(ConvertToString(AlternativeAddressDetail.RequiredErrorMessage).Replace("%s", AlternativeAddressDetail.Caption));
                }
            }
            if (AlternativeAddressCity.Required) {
                if (!AlternativeAddressCity.IsDetailKey && Empty(AlternativeAddressCity.FormValue)) {
                    AlternativeAddressCity.AddErrorMessage(ConvertToString(AlternativeAddressCity.RequiredErrorMessage).Replace("%s", AlternativeAddressCity.Caption));
                }
            }
            if (AlternativeAddressState.Required) {
                if (!AlternativeAddressState.IsDetailKey && Empty(AlternativeAddressState.FormValue)) {
                    AlternativeAddressState.AddErrorMessage(ConvertToString(AlternativeAddressState.RequiredErrorMessage).Replace("%s", AlternativeAddressState.Caption));
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
            if (ContactMethodEmail.Required) {
                if (Empty(ContactMethodEmail.FormValue)) {
                    ContactMethodEmail.AddErrorMessage(ConvertToString(ContactMethodEmail.RequiredErrorMessage).Replace("%s", ContactMethodEmail.Caption));
                }
            }
            if (ContactMethodFax.Required) {
                if (Empty(ContactMethodFax.FormValue)) {
                    ContactMethodFax.AddErrorMessage(ConvertToString(ContactMethodFax.RequiredErrorMessage).Replace("%s", ContactMethodFax.Caption));
                }
            }
            if (ContactMethodMobilePhone.Required) {
                if (Empty(ContactMethodMobilePhone.FormValue)) {
                    ContactMethodMobilePhone.AddErrorMessage(ConvertToString(ContactMethodMobilePhone.RequiredErrorMessage).Replace("%s", ContactMethodMobilePhone.Caption));
                }
            }
            if (ContactMethodHomePhone.Required) {
                if (Empty(ContactMethodHomePhone.FormValue)) {
                    ContactMethodHomePhone.AddErrorMessage(ConvertToString(ContactMethodHomePhone.RequiredErrorMessage).Replace("%s", ContactMethodHomePhone.Caption));
                }
            }
            if (ContactMethodPost.Required) {
                if (Empty(ContactMethodPost.FormValue)) {
                    ContactMethodPost.AddErrorMessage(ConvertToString(ContactMethodPost.RequiredErrorMessage).Replace("%s", ContactMethodPost.Caption));
                }
            }
            if (CollarSize.Required) {
                if (!CollarSize.IsDetailKey && Empty(CollarSize.FormValue)) {
                    CollarSize.AddErrorMessage(ConvertToString(CollarSize.RequiredErrorMessage).Replace("%s", CollarSize.Caption));
                }
            }
            if (!CheckNumber(CollarSize.FormValue)) {
                CollarSize.AddErrorMessage(CollarSize.GetErrorMessage(false));
            }
            if (ChestSize.Required) {
                if (!ChestSize.IsDetailKey && Empty(ChestSize.FormValue)) {
                    ChestSize.AddErrorMessage(ConvertToString(ChestSize.RequiredErrorMessage).Replace("%s", ChestSize.Caption));
                }
            }
            if (!CheckNumber(ChestSize.FormValue)) {
                ChestSize.AddErrorMessage(ChestSize.GetErrorMessage(false));
            }
            if (WaistSize.Required) {
                if (!WaistSize.IsDetailKey && Empty(WaistSize.FormValue)) {
                    WaistSize.AddErrorMessage(ConvertToString(WaistSize.RequiredErrorMessage).Replace("%s", WaistSize.Caption));
                }
            }
            if (!CheckNumber(WaistSize.FormValue)) {
                WaistSize.AddErrorMessage(WaistSize.GetErrorMessage(false));
            }
            if (InsideLegSize.Required) {
                if (!InsideLegSize.IsDetailKey && Empty(InsideLegSize.FormValue)) {
                    InsideLegSize.AddErrorMessage(ConvertToString(InsideLegSize.RequiredErrorMessage).Replace("%s", InsideLegSize.Caption));
                }
            }
            if (!CheckNumber(InsideLegSize.FormValue)) {
                InsideLegSize.AddErrorMessage(InsideLegSize.GetErrorMessage(false));
            }
            if (CapSize.Required) {
                if (!CapSize.IsDetailKey && Empty(CapSize.FormValue)) {
                    CapSize.AddErrorMessage(ConvertToString(CapSize.RequiredErrorMessage).Replace("%s", CapSize.Caption));
                }
            }
            if (!CheckNumber(CapSize.FormValue)) {
                CapSize.AddErrorMessage(CapSize.GetErrorMessage(false));
            }
            if (SweaterSize_ClothesSizeID.Required) {
                if (!SweaterSize_ClothesSizeID.IsDetailKey && Empty(SweaterSize_ClothesSizeID.FormValue)) {
                    SweaterSize_ClothesSizeID.AddErrorMessage(ConvertToString(SweaterSize_ClothesSizeID.RequiredErrorMessage).Replace("%s", SweaterSize_ClothesSizeID.Caption));
                }
            }
            if (BoilersuitSize_ClothesSizeID.Required) {
                if (!BoilersuitSize_ClothesSizeID.IsDetailKey && Empty(BoilersuitSize_ClothesSizeID.FormValue)) {
                    BoilersuitSize_ClothesSizeID.AddErrorMessage(ConvertToString(BoilersuitSize_ClothesSizeID.RequiredErrorMessage).Replace("%s", BoilersuitSize_ClothesSizeID.Caption));
                }
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
            if (NomineeValidVisa.Required) {
                if (!NomineeValidVisa.IsDetailKey && Empty(NomineeValidVisa.FormValue)) {
                    NomineeValidVisa.AddErrorMessage(ConvertToString(NomineeValidVisa.RequiredErrorMessage).Replace("%s", NomineeValidVisa.Caption));
                }
            }
            if (BankName.Required) {
                if (!BankName.IsDetailKey && Empty(BankName.FormValue)) {
                    BankName.AddErrorMessage(ConvertToString(BankName.RequiredErrorMessage).Replace("%s", BankName.Caption));
                }
            }
            if (BankAddress.Required) {
                if (!BankAddress.IsDetailKey && Empty(BankAddress.FormValue)) {
                    BankAddress.AddErrorMessage(ConvertToString(BankAddress.RequiredErrorMessage).Replace("%s", BankAddress.Caption));
                }
            }
            if (BankAccountName.Required) {
                if (!BankAccountName.IsDetailKey && Empty(BankAccountName.FormValue)) {
                    BankAccountName.AddErrorMessage(ConvertToString(BankAccountName.RequiredErrorMessage).Replace("%s", BankAccountName.Caption));
                }
            }
            if (BankAccountNumber.Required) {
                if (!BankAccountNumber.IsDetailKey && Empty(BankAccountNumber.FormValue)) {
                    BankAccountNumber.AddErrorMessage(ConvertToString(BankAccountNumber.RequiredErrorMessage).Replace("%s", BankAccountNumber.Caption));
                }
            }
            if (BankSortCode.Required) {
                if (!BankSortCode.IsDetailKey && Empty(BankSortCode.FormValue)) {
                    BankSortCode.AddErrorMessage(ConvertToString(BankSortCode.RequiredErrorMessage).Replace("%s", BankSortCode.Caption));
                }
            }
            if (MNOPF.Required) {
                if (!MNOPF.IsDetailKey && Empty(MNOPF.FormValue)) {
                    MNOPF.AddErrorMessage(ConvertToString(MNOPF.RequiredErrorMessage).Replace("%s", MNOPF.Caption));
                }
            }
            if (MembershipNumber.Required) {
                if (!MembershipNumber.IsDetailKey && Empty(MembershipNumber.FormValue)) {
                    MembershipNumber.AddErrorMessage(ConvertToString(MembershipNumber.RequiredErrorMessage).Replace("%s", MembershipNumber.Caption));
                }
            }
            if (NationalInsuranceNumber.Required) {
                if (!NationalInsuranceNumber.IsDetailKey && Empty(NationalInsuranceNumber.FormValue)) {
                    NationalInsuranceNumber.AddErrorMessage(ConvertToString(NationalInsuranceNumber.RequiredErrorMessage).Replace("%s", NationalInsuranceNumber.Caption));
                }
            }
            if (AVC.Required) {
                if (!AVC.IsDetailKey && Empty(AVC.FormValue)) {
                    AVC.AddErrorMessage(ConvertToString(AVC.RequiredErrorMessage).Replace("%s", AVC.Caption));
                }
            }
            if (ForeignVisaHasBeenDenied.Required) {
                if (Empty(ForeignVisaHasBeenDenied.FormValue)) {
                    ForeignVisaHasBeenDenied.AddErrorMessage(ConvertToString(ForeignVisaHasBeenDenied.RequiredErrorMessage).Replace("%s", ForeignVisaHasBeenDenied.Caption));
                }
            }
            if (ForeignVisaDenied_CountryID.Required) {
                if (!ForeignVisaDenied_CountryID.IsDetailKey && Empty(ForeignVisaDenied_CountryID.FormValue)) {
                    ForeignVisaDenied_CountryID.AddErrorMessage(ConvertToString(ForeignVisaDenied_CountryID.RequiredErrorMessage).Replace("%s", ForeignVisaDenied_CountryID.Caption));
                }
            }
            if (ForeignVisaDeniedReason.Required) {
                if (!ForeignVisaDeniedReason.IsDetailKey && Empty(ForeignVisaDeniedReason.FormValue)) {
                    ForeignVisaDeniedReason.AddErrorMessage(ConvertToString(ForeignVisaDeniedReason.RequiredErrorMessage).Replace("%s", ForeignVisaDeniedReason.Caption));
                }
            }
            if (HasMaritimeAccidentOrCourtOfEnquiry.Required) {
                if (Empty(HasMaritimeAccidentOrCourtOfEnquiry.FormValue)) {
                    HasMaritimeAccidentOrCourtOfEnquiry.AddErrorMessage(ConvertToString(HasMaritimeAccidentOrCourtOfEnquiry.RequiredErrorMessage).Replace("%s", HasMaritimeAccidentOrCourtOfEnquiry.Caption));
                }
            }
            if (HasMaritimeAccidentOrCourtOfEnquiryDetails.Required) {
                if (!HasMaritimeAccidentOrCourtOfEnquiryDetails.IsDetailKey && Empty(HasMaritimeAccidentOrCourtOfEnquiryDetails.FormValue)) {
                    HasMaritimeAccidentOrCourtOfEnquiryDetails.AddErrorMessage(ConvertToString(HasMaritimeAccidentOrCourtOfEnquiryDetails.RequiredErrorMessage).Replace("%s", HasMaritimeAccidentOrCourtOfEnquiryDetails.Caption));
                }
            }
            if (Reference1CompanyName.Required) {
                if (!Reference1CompanyName.IsDetailKey && Empty(Reference1CompanyName.FormValue)) {
                    Reference1CompanyName.AddErrorMessage(ConvertToString(Reference1CompanyName.RequiredErrorMessage).Replace("%s", Reference1CompanyName.Caption));
                }
            }
            if (Reference1ContactPersonName.Required) {
                if (!Reference1ContactPersonName.IsDetailKey && Empty(Reference1ContactPersonName.FormValue)) {
                    Reference1ContactPersonName.AddErrorMessage(ConvertToString(Reference1ContactPersonName.RequiredErrorMessage).Replace("%s", Reference1ContactPersonName.Caption));
                }
            }
            if (Reference1CompanyAddress.Required) {
                if (!Reference1CompanyAddress.IsDetailKey && Empty(Reference1CompanyAddress.FormValue)) {
                    Reference1CompanyAddress.AddErrorMessage(ConvertToString(Reference1CompanyAddress.RequiredErrorMessage).Replace("%s", Reference1CompanyAddress.Caption));
                }
            }
            if (Reference1CompanyCountryID.Required) {
                if (!Reference1CompanyCountryID.IsDetailKey && Empty(Reference1CompanyCountryID.FormValue)) {
                    Reference1CompanyCountryID.AddErrorMessage(ConvertToString(Reference1CompanyCountryID.RequiredErrorMessage).Replace("%s", Reference1CompanyCountryID.Caption));
                }
            }
            if (Reference1CompanyTelephone.Required) {
                if (!Reference1CompanyTelephone.IsDetailKey && Empty(Reference1CompanyTelephone.FormValue)) {
                    Reference1CompanyTelephone.AddErrorMessage(ConvertToString(Reference1CompanyTelephone.RequiredErrorMessage).Replace("%s", Reference1CompanyTelephone.Caption));
                }
            }
            if (Reference2CompanyName.Required) {
                if (!Reference2CompanyName.IsDetailKey && Empty(Reference2CompanyName.FormValue)) {
                    Reference2CompanyName.AddErrorMessage(ConvertToString(Reference2CompanyName.RequiredErrorMessage).Replace("%s", Reference2CompanyName.Caption));
                }
            }
            if (Reference2ContactPersonName.Required) {
                if (!Reference2ContactPersonName.IsDetailKey && Empty(Reference2ContactPersonName.FormValue)) {
                    Reference2ContactPersonName.AddErrorMessage(ConvertToString(Reference2ContactPersonName.RequiredErrorMessage).Replace("%s", Reference2ContactPersonName.Caption));
                }
            }
            if (Reference2CompanyAddress.Required) {
                if (!Reference2CompanyAddress.IsDetailKey && Empty(Reference2CompanyAddress.FormValue)) {
                    Reference2CompanyAddress.AddErrorMessage(ConvertToString(Reference2CompanyAddress.RequiredErrorMessage).Replace("%s", Reference2CompanyAddress.Caption));
                }
            }
            if (Reference2CompanyCountryID.Required) {
                if (!Reference2CompanyCountryID.IsDetailKey && Empty(Reference2CompanyCountryID.FormValue)) {
                    Reference2CompanyCountryID.AddErrorMessage(ConvertToString(Reference2CompanyCountryID.RequiredErrorMessage).Replace("%s", Reference2CompanyCountryID.Caption));
                }
            }
            if (Reference2CompanyTelephone.Required) {
                if (!Reference2CompanyTelephone.IsDetailKey && Empty(Reference2CompanyTelephone.FormValue)) {
                    Reference2CompanyTelephone.AddErrorMessage(ConvertToString(Reference2CompanyTelephone.RequiredErrorMessage).Replace("%s", Reference2CompanyTelephone.Caption));
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
            if (!CheckInteger(Weight.FormValue)) {
                Weight.AddErrorMessage(Weight.GetErrorMessage(false));
            }
            if (Height.Required) {
                if (!Height.IsDetailKey && Empty(Height.FormValue)) {
                    Height.AddErrorMessage(ConvertToString(Height.RequiredErrorMessage).Replace("%s", Height.Caption));
                }
            }
            if (!CheckInteger(Height.FormValue)) {
                Height.AddErrorMessage(Height.GetErrorMessage(false));
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
            if (!CheckInteger(SafetyShoesSize.FormValue)) {
                SafetyShoesSize.AddErrorMessage(SafetyShoesSize.GetErrorMessage(false));
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
            if (FinalAcceptedDate.Required) {
                if (!FinalAcceptedDate.IsDetailKey && Empty(FinalAcceptedDate.FormValue)) {
                    FinalAcceptedDate.AddErrorMessage(ConvertToString(FinalAcceptedDate.RequiredErrorMessage).Replace("%s", FinalAcceptedDate.Caption));
                }
            }
            if (!CheckDate(FinalAcceptedDate.FormValue, FinalAcceptedDate.FormatPattern)) {
                FinalAcceptedDate.AddErrorMessage(FinalAcceptedDate.GetErrorMessage(false));
            }
            if (Reference1CompanyTelephoneCode_CountryID.Required) {
                if (!Reference1CompanyTelephoneCode_CountryID.IsDetailKey && Empty(Reference1CompanyTelephoneCode_CountryID.FormValue)) {
                    Reference1CompanyTelephoneCode_CountryID.AddErrorMessage(ConvertToString(Reference1CompanyTelephoneCode_CountryID.RequiredErrorMessage).Replace("%s", Reference1CompanyTelephoneCode_CountryID.Caption));
                }
            }
            if (Reference2CompanyTelephoneCode_CountryID.Required) {
                if (!Reference2CompanyTelephoneCode_CountryID.IsDetailKey && Empty(Reference2CompanyTelephoneCode_CountryID.FormValue)) {
                    Reference2CompanyTelephoneCode_CountryID.AddErrorMessage(ConvertToString(Reference2CompanyTelephoneCode_CountryID.RequiredErrorMessage).Replace("%s", Reference2CompanyTelephoneCode_CountryID.Caption));
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
            if (RevisedReason.Required) {
                if (!RevisedReason.IsDetailKey && Empty(RevisedReason.FormValue)) {
                    RevisedReason.AddErrorMessage(ConvertToString(RevisedReason.RequiredErrorMessage).Replace("%s", RevisedReason.Caption));
                }
            }
            if (RevisedDateTime.Required) {
                if (!RevisedDateTime.IsDetailKey && Empty(RevisedDateTime.FormValue)) {
                    RevisedDateTime.AddErrorMessage(ConvertToString(RevisedDateTime.RequiredErrorMessage).Replace("%s", RevisedDateTime.Caption));
                }
            }
            if (!CheckDate(RevisedDateTime.FormValue, RevisedDateTime.FormatPattern)) {
                RevisedDateTime.AddErrorMessage(RevisedDateTime.GetErrorMessage(false));
            }

            // Validate detail grid
            var detailTblVar = CurrentDetailTables;
            if (detailTblVar.Contains("MTCrewCertificate") && mtCrewCertificate?.DetailAdd == true) {
                mtCrewCertificateGrid = Resolve("MtCrewCertificateGrid")!; // Get detail page object
                if (mtCrewCertificateGrid != null)
                    validateForm = validateForm && await mtCrewCertificateGrid.ValidateGridForm();
            }
            if (detailTblVar.Contains("MTCrewDocument") && mtCrewDocument?.DetailAdd == true) {
                mtCrewDocumentGrid = Resolve("MtCrewDocumentGrid")!; // Get detail page object
                if (mtCrewDocumentGrid != null)
                    validateForm = validateForm && await mtCrewDocumentGrid.ValidateGridForm();
            }
            if (detailTblVar.Contains("MTCrewExperience") && mtCrewExperience?.DetailAdd == true) {
                mtCrewExperienceGrid = Resolve("MtCrewExperienceGrid")!; // Get detail page object
                if (mtCrewExperienceGrid != null)
                    validateForm = validateForm && await mtCrewExperienceGrid.ValidateGridForm();
            }
            if (detailTblVar.Contains("MTCrewFamily") && mtCrewFamily?.DetailAdd == true) {
                mtCrewFamilyGrid = Resolve("MtCrewFamilyGrid")!; // Get detail page object
                if (mtCrewFamilyGrid != null)
                    validateForm = validateForm && await mtCrewFamilyGrid.ValidateGridForm();
            }
            if (detailTblVar.Contains("MTCrewMedicalHistory") && mtCrewMedicalHistory?.DetailAdd == true) {
                mtCrewMedicalHistoryGrid = Resolve("MtCrewMedicalHistoryGrid")!; // Get detail page object
                if (mtCrewMedicalHistoryGrid != null)
                    validateForm = validateForm && await mtCrewMedicalHistoryGrid.ValidateGridForm();
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

        // Add record
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> AddRow(Dictionary<string, object>? rsold = null) { // DN
            bool result = false;

            // Set new row
            Dictionary<string, object> rsnew = new ();
            try {
                // IndividualCodeNumber
                IndividualCodeNumber.SetDbValue(rsnew, IndividualCodeNumber.CurrentValue);

                // FullName
                FullName.SetDbValue(rsnew, FullName.CurrentValue);

                // RequiredPhoto
                if (RequiredPhoto.Visible && !RequiredPhoto.Upload.KeepFile) {
                    RequiredPhoto.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(RequiredPhoto.Upload.FileName)) {
                        rsnew["RequiredPhoto"] = DbNullValue;
                    } else {
                        rsnew["RequiredPhoto"] = RequiredPhoto.Upload.FileName;
                    }
                }

                // VisaPhoto
                if (VisaPhoto.Visible && !VisaPhoto.Upload.KeepFile) {
                    VisaPhoto.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(VisaPhoto.Upload.FileName)) {
                        rsnew["VisaPhoto"] = DbNullValue;
                    } else {
                        rsnew["VisaPhoto"] = VisaPhoto.Upload.FileName;
                    }
                }

                // Nationality_CountryID
                Nationality_CountryID.SetDbValue(rsnew, Nationality_CountryID.CurrentValue);

                // CountryOfOrigin_CountryID
                CountryOfOrigin_CountryID.SetDbValue(rsnew, CountryOfOrigin_CountryID.CurrentValue);

                // DateOfBirth
                DateOfBirth.SetDbValue(rsnew, ConvertToDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern));

                // CityOfBirth
                CityOfBirth.SetDbValue(rsnew, CityOfBirth.CurrentValue);

                // MaritalStatus
                MaritalStatus.SetDbValue(rsnew, MaritalStatus.CurrentValue);

                // Gender
                Gender.SetDbValue(rsnew, Gender.CurrentValue);

                // ReligionID
                ReligionID.SetDbValue(rsnew, ReligionID.CurrentValue);

                // BloodType
                BloodType.SetDbValue(rsnew, BloodType.CurrentValue);

                // RankAppliedFor_RankID
                RankAppliedFor_RankID.SetDbValue(rsnew, RankAppliedFor_RankID.CurrentValue);

                // WillAcceptLowRank
                WillAcceptLowRank.SetDbValue(rsnew, ConvertToBool(WillAcceptLowRank.CurrentValue));

                // AvailableFrom
                AvailableFrom.SetDbValue(rsnew, ConvertToDateTime(AvailableFrom.CurrentValue, AvailableFrom.FormatPattern));

                // AvailableUntil
                AvailableUntil.SetDbValue(rsnew, ConvertToDateTime(AvailableUntil.CurrentValue, AvailableUntil.FormatPattern));

                // PrimaryAddressDetail
                PrimaryAddressDetail.SetDbValue(rsnew, PrimaryAddressDetail.CurrentValue);

                // PrimaryAddressCity
                PrimaryAddressCity.SetDbValue(rsnew, PrimaryAddressCity.CurrentValue);

                // PrimaryAddressState
                PrimaryAddressState.SetDbValue(rsnew, PrimaryAddressState.CurrentValue);

                // PrimaryAddressNearestAirport
                PrimaryAddressNearestAirport.SetDbValue(rsnew, PrimaryAddressNearestAirport.CurrentValue);

                // PrimaryAddressPostCode
                PrimaryAddressPostCode.SetDbValue(rsnew, PrimaryAddressPostCode.CurrentValue);

                // PrimaryAddressCountryID
                PrimaryAddressCountryID.SetDbValue(rsnew, PrimaryAddressCountryID.CurrentValue);

                // PrimaryAddressHomeTel
                PrimaryAddressHomeTel.SetDbValue(rsnew, PrimaryAddressHomeTel.CurrentValue);

                // PrimaryAddressFax
                PrimaryAddressFax.SetDbValue(rsnew, PrimaryAddressFax.CurrentValue);

                // AlternativeAddressDetail
                AlternativeAddressDetail.SetDbValue(rsnew, AlternativeAddressDetail.CurrentValue);

                // AlternativeAddressCity
                AlternativeAddressCity.SetDbValue(rsnew, AlternativeAddressCity.CurrentValue);

                // AlternativeAddressState
                AlternativeAddressState.SetDbValue(rsnew, AlternativeAddressState.CurrentValue);

                // AlternativeAddressHomeTel
                AlternativeAddressHomeTel.SetDbValue(rsnew, AlternativeAddressHomeTel.CurrentValue);

                // AlternativeAddressPostCode
                AlternativeAddressPostCode.SetDbValue(rsnew, AlternativeAddressPostCode.CurrentValue);

                // AlternativeAddressCountryID
                AlternativeAddressCountryID.SetDbValue(rsnew, AlternativeAddressCountryID.CurrentValue);

                // MobileNumber
                MobileNumber.SetDbValue(rsnew, MobileNumber.CurrentValue);

                // Email
                _Email.SetDbValue(rsnew, _Email.CurrentValue);

                // ContactMethodEmail
                ContactMethodEmail.SetDbValue(rsnew, ConvertToBool(ContactMethodEmail.CurrentValue));

                // ContactMethodFax
                ContactMethodFax.SetDbValue(rsnew, ConvertToBool(ContactMethodFax.CurrentValue));

                // ContactMethodMobilePhone
                ContactMethodMobilePhone.SetDbValue(rsnew, ConvertToBool(ContactMethodMobilePhone.CurrentValue));

                // ContactMethodHomePhone
                ContactMethodHomePhone.SetDbValue(rsnew, ConvertToBool(ContactMethodHomePhone.CurrentValue));

                // ContactMethodPost
                ContactMethodPost.SetDbValue(rsnew, ConvertToBool(ContactMethodPost.CurrentValue));

                // CollarSize
                CollarSize.SetDbValue(rsnew, CollarSize.CurrentValue);

                // ChestSize
                ChestSize.SetDbValue(rsnew, ChestSize.CurrentValue);

                // WaistSize
                WaistSize.SetDbValue(rsnew, WaistSize.CurrentValue);

                // InsideLegSize
                InsideLegSize.SetDbValue(rsnew, InsideLegSize.CurrentValue);

                // CapSize
                CapSize.SetDbValue(rsnew, CapSize.CurrentValue);

                // SweaterSize_ClothesSizeID
                SweaterSize_ClothesSizeID.SetDbValue(rsnew, SweaterSize_ClothesSizeID.CurrentValue);

                // BoilersuitSize_ClothesSizeID
                BoilersuitSize_ClothesSizeID.SetDbValue(rsnew, BoilersuitSize_ClothesSizeID.CurrentValue);

                // SocialSecurityNumber
                SocialSecurityNumber.SetDbValue(rsnew, SocialSecurityNumber.CurrentValue);

                // SocialSecurityIssuingCountryID
                SocialSecurityIssuingCountryID.SetDbValue(rsnew, SocialSecurityIssuingCountryID.CurrentValue);

                // SocialSecurityImage
                if (SocialSecurityImage.Visible && !SocialSecurityImage.Upload.KeepFile) {
                    SocialSecurityImage.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(SocialSecurityImage.Upload.FileName)) {
                        rsnew["SocialSecurityImage"] = DbNullValue;
                    } else {
                        rsnew["SocialSecurityImage"] = SocialSecurityImage.Upload.FileName;
                    }
                }

                // PersonalTaxNumber
                PersonalTaxNumber.SetDbValue(rsnew, PersonalTaxNumber.CurrentValue);

                // PersonalTaxIssuingCountryID
                PersonalTaxIssuingCountryID.SetDbValue(rsnew, PersonalTaxIssuingCountryID.CurrentValue);

                // PersonalTaxImage
                if (PersonalTaxImage.Visible && !PersonalTaxImage.Upload.KeepFile) {
                    PersonalTaxImage.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(PersonalTaxImage.Upload.FileName)) {
                        rsnew["PersonalTaxImage"] = DbNullValue;
                    } else {
                        rsnew["PersonalTaxImage"] = PersonalTaxImage.Upload.FileName;
                    }
                }

                // NomineeFullName
                NomineeFullName.SetDbValue(rsnew, NomineeFullName.CurrentValue);

                // NomineeRelationship
                NomineeRelationship.SetDbValue(rsnew, NomineeRelationship.CurrentValue);

                // NomineeGender
                NomineeGender.SetDbValue(rsnew, NomineeGender.CurrentValue);

                // NomineeNationality_CountryID
                NomineeNationality_CountryID.SetDbValue(rsnew, NomineeNationality_CountryID.CurrentValue);

                // NomineeAddressDetail
                NomineeAddressDetail.SetDbValue(rsnew, NomineeAddressDetail.CurrentValue);

                // NomineeAddressCity
                NomineeAddressCity.SetDbValue(rsnew, NomineeAddressCity.CurrentValue);

                // NomineeAddressPostCode
                NomineeAddressPostCode.SetDbValue(rsnew, NomineeAddressPostCode.CurrentValue);

                // NomineeAddressCountryID
                NomineeAddressCountryID.SetDbValue(rsnew, NomineeAddressCountryID.CurrentValue);

                // NomineeAddressHomeTel
                NomineeAddressHomeTel.SetDbValue(rsnew, NomineeAddressHomeTel.CurrentValue);

                // NomineeEmail
                NomineeEmail.SetDbValue(rsnew, NomineeEmail.CurrentValue);

                // NomineeMobileNumber
                NomineeMobileNumber.SetDbValue(rsnew, NomineeMobileNumber.CurrentValue);

                // NomineeValidVisa
                NomineeValidVisa.SetDbValue(rsnew, NomineeValidVisa.CurrentValue);

                // BankName
                BankName.SetDbValue(rsnew, BankName.CurrentValue);

                // BankAddress
                BankAddress.SetDbValue(rsnew, BankAddress.CurrentValue);

                // BankAccountName
                BankAccountName.SetDbValue(rsnew, BankAccountName.CurrentValue);

                // BankAccountNumber
                BankAccountNumber.SetDbValue(rsnew, BankAccountNumber.CurrentValue);

                // BankSortCode
                BankSortCode.SetDbValue(rsnew, BankSortCode.CurrentValue);

                // MNOPF
                MNOPF.SetDbValue(rsnew, MNOPF.CurrentValue);

                // MembershipNumber
                MembershipNumber.SetDbValue(rsnew, MembershipNumber.CurrentValue);

                // NationalInsuranceNumber
                NationalInsuranceNumber.SetDbValue(rsnew, NationalInsuranceNumber.CurrentValue);

                // AVC
                AVC.SetDbValue(rsnew, AVC.CurrentValue);

                // ForeignVisaHasBeenDenied
                ForeignVisaHasBeenDenied.SetDbValue(rsnew, ConvertToBool(ForeignVisaHasBeenDenied.CurrentValue));

                // ForeignVisaDenied_CountryID
                ForeignVisaDenied_CountryID.SetDbValue(rsnew, ForeignVisaDenied_CountryID.CurrentValue);

                // ForeignVisaDeniedReason
                ForeignVisaDeniedReason.SetDbValue(rsnew, ForeignVisaDeniedReason.CurrentValue);

                // HasMaritimeAccidentOrCourtOfEnquiry
                HasMaritimeAccidentOrCourtOfEnquiry.SetDbValue(rsnew, ConvertToBool(HasMaritimeAccidentOrCourtOfEnquiry.CurrentValue));

                // HasMaritimeAccidentOrCourtOfEnquiryDetails
                HasMaritimeAccidentOrCourtOfEnquiryDetails.SetDbValue(rsnew, HasMaritimeAccidentOrCourtOfEnquiryDetails.CurrentValue);

                // Reference1CompanyName
                Reference1CompanyName.SetDbValue(rsnew, Reference1CompanyName.CurrentValue);

                // Reference1ContactPersonName
                Reference1ContactPersonName.SetDbValue(rsnew, Reference1ContactPersonName.CurrentValue);

                // Reference1CompanyAddress
                Reference1CompanyAddress.SetDbValue(rsnew, Reference1CompanyAddress.CurrentValue);

                // Reference1CompanyCountryID
                Reference1CompanyCountryID.SetDbValue(rsnew, Reference1CompanyCountryID.CurrentValue);

                // Reference1CompanyTelephone
                Reference1CompanyTelephone.SetDbValue(rsnew, Reference1CompanyTelephone.CurrentValue);

                // Reference2CompanyName
                Reference2CompanyName.SetDbValue(rsnew, Reference2CompanyName.CurrentValue);

                // Reference2ContactPersonName
                Reference2ContactPersonName.SetDbValue(rsnew, Reference2ContactPersonName.CurrentValue);

                // Reference2CompanyAddress
                Reference2CompanyAddress.SetDbValue(rsnew, Reference2CompanyAddress.CurrentValue);

                // Reference2CompanyCountryID
                Reference2CompanyCountryID.SetDbValue(rsnew, Reference2CompanyCountryID.CurrentValue);

                // Reference2CompanyTelephone
                Reference2CompanyTelephone.SetDbValue(rsnew, Reference2CompanyTelephone.CurrentValue);

                // Status
                Status.SetDbValue(rsnew, Status.CurrentValue);

                // Reason
                Reason.SetDbValue(rsnew, Reason.CurrentValue);

                // Weight
                Weight.SetDbValue(rsnew, Weight.CurrentValue);

                // Height
                Height.SetDbValue(rsnew, Height.CurrentValue);

                // CoverallSize
                CoverallSize.SetDbValue(rsnew, CoverallSize.CurrentValue);

                // SafetyShoesSize
                SafetyShoesSize.SetDbValue(rsnew, SafetyShoesSize.CurrentValue);

                // ShirtSize
                ShirtSize.SetDbValue(rsnew, ShirtSize.CurrentValue);

                // TrousersSize
                TrousersSize.SetDbValue(rsnew, TrousersSize.CurrentValue);

                // NSSF_Health_Number
                NSSF_Health_Number.SetDbValue(rsnew, NSSF_Health_Number.CurrentValue);

                // NSSF_Occupation_Number
                NSSF_Occupation_Number.SetDbValue(rsnew, NSSF_Occupation_Number.CurrentValue);

                // FinalAcceptedDate
                FinalAcceptedDate.SetDbValue(rsnew, ConvertToDateTimeOffset(FinalAcceptedDate.CurrentValue, DateTimeStyles.AssumeUniversal));

                // Reference1CompanyTelephoneCode_CountryID
                Reference1CompanyTelephoneCode_CountryID.SetDbValue(rsnew, Reference1CompanyTelephoneCode_CountryID.CurrentValue);

                // Reference2CompanyTelephoneCode_CountryID
                Reference2CompanyTelephoneCode_CountryID.SetDbValue(rsnew, Reference2CompanyTelephoneCode_CountryID.CurrentValue);

                // MobileNumberCode_CountryID
                MobileNumberCode_CountryID.SetDbValue(rsnew, MobileNumberCode_CountryID.CurrentValue);

                // PrimaryAddressHomeTelCode_CountryID
                PrimaryAddressHomeTelCode_CountryID.SetDbValue(rsnew, PrimaryAddressHomeTelCode_CountryID.CurrentValue);

                // AlternativeAddressHomeTelCode_CountryID
                AlternativeAddressHomeTelCode_CountryID.SetDbValue(rsnew, AlternativeAddressHomeTelCode_CountryID.CurrentValue);

                // NomineeAddressHomeTelCode_CountryID
                NomineeAddressHomeTelCode_CountryID.SetDbValue(rsnew, NomineeAddressHomeTelCode_CountryID.CurrentValue);

                // NomineeMobileNumberCode_CountryID
                NomineeMobileNumberCode_CountryID.SetDbValue(rsnew, NomineeMobileNumberCode_CountryID.CurrentValue);

                // RevisedReason
                RevisedReason.SetDbValue(rsnew, RevisedReason.CurrentValue);

                // RevisedDateTime
                RevisedDateTime.SetDbValue(rsnew, ConvertToDateTimeOffset(RevisedDateTime.CurrentValue, DateTimeStyles.AssumeUniversal));

                // MTUserID
                if (!Security.IsAdmin && Security.IsLoggedIn) { // Non system admin
                    rsnew["MTUserID"] = CurrentUserID();
                }
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
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
                    RequiredPhoto.SetDbValue(rsnew, RequiredPhoto.Upload.FileName);
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
                    VisaPhoto.SetDbValue(rsnew, VisaPhoto.Upload.FileName);
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
                    SocialSecurityImage.SetDbValue(rsnew, SocialSecurityImage.Upload.FileName);
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
                    PersonalTaxImage.SetDbValue(rsnew, PersonalTaxImage.Upload.FileName);
                }
            }

            // Update current values
            SetCurrentValues(rsnew);

            // Check if valid User ID
            bool validUser = false;
            string userIdMsg;
            if (!Empty(Security.CurrentUserID) && !Security.IsAdmin) { // Non system admin
                validUser = Security.IsValidUserID(MTUserID.CurrentValue);
                if (!validUser) {
                    userIdMsg = Language.Phrase("UnAuthorizedUserID").Replace("%c", ConvertToString(Security.CurrentUserID));
                    userIdMsg = userIdMsg.Replace("%u", ConvertToString(MTUserID.CurrentValue));
                    FailureMessage = userIdMsg;
                    return JsonBoolResult.FalseResult;
                }
            }

            // Begin transaction
            if (!Empty(CurrentDetailTable) && UseTransaction)
                Connection.BeginTrans();

            // Load db values from rsold
            LoadDbValues(rsold);
            if (rsold != null) {
                RequiredPhoto.OldUploadPath = RequiredPhoto.GetUploadPath();
                RequiredPhoto.UploadPath = RequiredPhoto.OldUploadPath;
                VisaPhoto.OldUploadPath = VisaPhoto.GetUploadPath();
                VisaPhoto.UploadPath = VisaPhoto.OldUploadPath;
                SocialSecurityImage.OldUploadPath = SocialSecurityImage.GetUploadPath();
                SocialSecurityImage.UploadPath = SocialSecurityImage.OldUploadPath;
                PersonalTaxImage.OldUploadPath = PersonalTaxImage.GetUploadPath();
                PersonalTaxImage.UploadPath = PersonalTaxImage.OldUploadPath;
            }

            // Call Row Inserting event
            bool insertRow = RowInserting(rsold, rsnew);
            if (insertRow) {
                try {
                    result = ConvertToBool(await InsertAsync(rsnew));
                    rsnew["ID"] = ID.CurrentValue!;
                } catch (Exception e) {
                    if (Config.Debug)
                        throw;
                    FailureMessage = e.Message;
                    result = false;
                }
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
            } else {
                if (SuccessMessage != "" || FailureMessage != "") {
                    // Use the message, do nothing
                } else if (CancelMessage != "") {
                    FailureMessage = CancelMessage;
                    CancelMessage = "";
                } else {
                    FailureMessage = Language.Phrase("InsertCancelled");
                }
                result = false;
            }

            // Add detail records
            var detailTblVar = CurrentDetailTables;
            if (result) {
                if (detailTblVar.Contains("MTCrewCertificate") && mtCrewCertificate?.DetailAdd == true) {
                    mtCrewCertificate.MTCrewID.SessionValue = ConvertToString(ID.CurrentValue); // Set master key
                    mtCrewCertificateGrid = Resolve("MtCrewCertificateGrid")!; // Get detail page object
                    if (mtCrewCertificateGrid != null) {
                        Security.LoadCurrentUserLevel(ProjectID + "MTCrewCertificate"); // Load user level of detail table
                        result = await mtCrewCertificateGrid.GridInsert();
                        Security.LoadCurrentUserLevel(ProjectID + TableName); // Restore user level of master table
                    }
                }
            }
            if (result) {
                if (detailTblVar.Contains("MTCrewDocument") && mtCrewDocument?.DetailAdd == true) {
                    mtCrewDocument.MTCrewID.SessionValue = ConvertToString(ID.CurrentValue); // Set master key
                    mtCrewDocumentGrid = Resolve("MtCrewDocumentGrid")!; // Get detail page object
                    if (mtCrewDocumentGrid != null) {
                        Security.LoadCurrentUserLevel(ProjectID + "MTCrewDocument"); // Load user level of detail table
                        result = await mtCrewDocumentGrid.GridInsert();
                        Security.LoadCurrentUserLevel(ProjectID + TableName); // Restore user level of master table
                    }
                }
            }
            if (result) {
                if (detailTblVar.Contains("MTCrewExperience") && mtCrewExperience?.DetailAdd == true) {
                    mtCrewExperience.MTCrewID.SessionValue = ConvertToString(ID.CurrentValue); // Set master key
                    mtCrewExperienceGrid = Resolve("MtCrewExperienceGrid")!; // Get detail page object
                    if (mtCrewExperienceGrid != null) {
                        Security.LoadCurrentUserLevel(ProjectID + "MTCrewExperience"); // Load user level of detail table
                        result = await mtCrewExperienceGrid.GridInsert();
                        Security.LoadCurrentUserLevel(ProjectID + TableName); // Restore user level of master table
                    }
                }
            }
            if (result) {
                if (detailTblVar.Contains("MTCrewFamily") && mtCrewFamily?.DetailAdd == true) {
                    mtCrewFamily.MTCrewID.SessionValue = ConvertToString(ID.CurrentValue); // Set master key
                    mtCrewFamilyGrid = Resolve("MtCrewFamilyGrid")!; // Get detail page object
                    if (mtCrewFamilyGrid != null) {
                        Security.LoadCurrentUserLevel(ProjectID + "MTCrewFamily"); // Load user level of detail table
                        result = await mtCrewFamilyGrid.GridInsert();
                        Security.LoadCurrentUserLevel(ProjectID + TableName); // Restore user level of master table
                    }
                }
            }
            if (result) {
                if (detailTblVar.Contains("MTCrewMedicalHistory") && mtCrewMedicalHistory?.DetailAdd == true) {
                    mtCrewMedicalHistory.MTCrewID.SessionValue = ConvertToString(ID.CurrentValue); // Set master key
                    mtCrewMedicalHistoryGrid = Resolve("MtCrewMedicalHistoryGrid")!; // Get detail page object
                    if (mtCrewMedicalHistoryGrid != null) {
                        Security.LoadCurrentUserLevel(ProjectID + "MTCrewMedicalHistory"); // Load user level of detail table
                        result = await mtCrewMedicalHistoryGrid.GridInsert();
                        Security.LoadCurrentUserLevel(ProjectID + TableName); // Restore user level of master table
                    }
                }
            }

            // Commit/Rollback transaction
            if (!Empty(CurrentDetailTable) && UseTransaction) {
                if (result) {
                    Connection.CommitTrans(); // Commit transaction
                } else {
                    Connection.RollbackTrans(); // Rollback transaction
                }
            }

            // Call Row Inserted event
            if (result)
                RowInserted(rsold, rsnew);

            // Write JSON for API request
            Dictionary<string, object> d = new ();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                if (GetRecordFromDictionary(rsnew) is var row && row != null) {
                    string table = TableVar;
                    d.Add(table, row);
                }
                d.Add("action", Config.ApiAddAction);
                d.Add("version", Config.ProductVersion);
                return new JsonBoolResult(d, result);
            }
            return new JsonBoolResult(d, result);
        }

        // Show link optionally based on User ID
        protected bool ShowOptionLink(string pageId = "") { // DN
            if (Security.IsLoggedIn && !Security.IsAdmin && !UserIDAllow(pageId))
                return Security.IsValidUserID(MTUserID.CurrentValue);
            return true;
        }

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
                if (detailTblVars.Contains("MTCrewCertificate")) {
                    mtCrewCertificateGrid = Resolve("MtCrewCertificateGrid")!;
                    if (mtCrewCertificateGrid?.DetailAdd ?? false) {
                        if (CopyRecord)
                            mtCrewCertificateGrid.CurrentMode = "copy";
                        else
                            mtCrewCertificateGrid.CurrentMode = "add";
                        mtCrewCertificateGrid.CurrentAction = "gridadd";

                        // Save current master table to detail table
                        mtCrewCertificateGrid.CurrentMasterTable = TableVar;
                        mtCrewCertificateGrid.StartRecordNumber = 1;
                        mtCrewCertificateGrid.MTCrewID.IsDetailKey = true;
                        mtCrewCertificateGrid.MTCrewID.CurrentValue = ID.CurrentValue;
                        mtCrewCertificateGrid.MTCrewID.SessionValue = mtCrewCertificateGrid.MTCrewID.CurrentValue;
                    }
                }
                if (detailTblVars.Contains("MTCrewDocument")) {
                    mtCrewDocumentGrid = Resolve("MtCrewDocumentGrid")!;
                    if (mtCrewDocumentGrid?.DetailAdd ?? false) {
                        if (CopyRecord)
                            mtCrewDocumentGrid.CurrentMode = "copy";
                        else
                            mtCrewDocumentGrid.CurrentMode = "add";
                        mtCrewDocumentGrid.CurrentAction = "gridadd";

                        // Save current master table to detail table
                        mtCrewDocumentGrid.CurrentMasterTable = TableVar;
                        mtCrewDocumentGrid.StartRecordNumber = 1;
                        mtCrewDocumentGrid.MTCrewID.IsDetailKey = true;
                        mtCrewDocumentGrid.MTCrewID.CurrentValue = ID.CurrentValue;
                        mtCrewDocumentGrid.MTCrewID.SessionValue = mtCrewDocumentGrid.MTCrewID.CurrentValue;
                    }
                }
                if (detailTblVars.Contains("MTCrewExperience")) {
                    mtCrewExperienceGrid = Resolve("MtCrewExperienceGrid")!;
                    if (mtCrewExperienceGrid?.DetailAdd ?? false) {
                        if (CopyRecord)
                            mtCrewExperienceGrid.CurrentMode = "copy";
                        else
                            mtCrewExperienceGrid.CurrentMode = "add";
                        mtCrewExperienceGrid.CurrentAction = "gridadd";

                        // Save current master table to detail table
                        mtCrewExperienceGrid.CurrentMasterTable = TableVar;
                        mtCrewExperienceGrid.StartRecordNumber = 1;
                        mtCrewExperienceGrid.MTCrewID.IsDetailKey = true;
                        mtCrewExperienceGrid.MTCrewID.CurrentValue = ID.CurrentValue;
                        mtCrewExperienceGrid.MTCrewID.SessionValue = mtCrewExperienceGrid.MTCrewID.CurrentValue;
                    }
                }
                if (detailTblVars.Contains("MTCrewFamily")) {
                    mtCrewFamilyGrid = Resolve("MtCrewFamilyGrid")!;
                    if (mtCrewFamilyGrid?.DetailAdd ?? false) {
                        if (CopyRecord)
                            mtCrewFamilyGrid.CurrentMode = "copy";
                        else
                            mtCrewFamilyGrid.CurrentMode = "add";
                        mtCrewFamilyGrid.CurrentAction = "gridadd";

                        // Save current master table to detail table
                        mtCrewFamilyGrid.CurrentMasterTable = TableVar;
                        mtCrewFamilyGrid.StartRecordNumber = 1;
                        mtCrewFamilyGrid.MTCrewID.IsDetailKey = true;
                        mtCrewFamilyGrid.MTCrewID.CurrentValue = ID.CurrentValue;
                        mtCrewFamilyGrid.MTCrewID.SessionValue = mtCrewFamilyGrid.MTCrewID.CurrentValue;
                    }
                }
                if (detailTblVars.Contains("MTCrewMedicalHistory")) {
                    mtCrewMedicalHistoryGrid = Resolve("MtCrewMedicalHistoryGrid")!;
                    if (mtCrewMedicalHistoryGrid?.DetailAdd ?? false) {
                        if (CopyRecord)
                            mtCrewMedicalHistoryGrid.CurrentMode = "copy";
                        else
                            mtCrewMedicalHistoryGrid.CurrentMode = "add";
                        mtCrewMedicalHistoryGrid.CurrentAction = "gridadd";

                        // Save current master table to detail table
                        mtCrewMedicalHistoryGrid.CurrentMasterTable = TableVar;
                        mtCrewMedicalHistoryGrid.StartRecordNumber = 1;
                        mtCrewMedicalHistoryGrid.MTCrewID.IsDetailKey = true;
                        mtCrewMedicalHistoryGrid.MTCrewID.CurrentValue = ID.CurrentValue;
                        mtCrewMedicalHistoryGrid.MTCrewID.SessionValue = mtCrewMedicalHistoryGrid.MTCrewID.CurrentValue;
                    }
                }
            }
        }

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
            string url = CurrentUrl();
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MtCrewList")), "", TableVar, true);
            string pageId = IsCopy ? "Copy" : "Add";
            breadcrumb.Add("add", pageId, url);
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
