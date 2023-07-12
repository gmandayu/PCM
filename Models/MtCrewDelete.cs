namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mtCrewDelete
    /// </summary>
    public static MtCrewDelete mtCrewDelete
    {
        get => HttpData.Get<MtCrewDelete>("mtCrewDelete")!;
        set => HttpData["mtCrewDelete"] = value;
    }

    /// <summary>
    /// Page class for MTCrew
    /// </summary>
    public class MtCrewDelete : MtCrewDeleteBase
    {
        // Constructor
        public MtCrewDelete(Controller controller) : base(controller)
        {
        }

        // Constructor
        public MtCrewDelete() : base()
        {
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class MtCrewDeleteBase : MtCrew
    {
        // Page ID
        public string PageID = "delete";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Table name
        public string TableName { get; set; } = "MTCrew";

        // Page object name
        public string PageObjName = "mtCrewDelete";

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
        public MtCrewDeleteBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-bordered table-hover table-sm ew-table";

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
        public string PageName => "MtCrewDelete";

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
            BloodType.Visible = false;
            RankAppliedFor_RankID.SetVisibility();
            WillAcceptLowRank.Visible = false;
            AvailableFrom.Visible = false;
            AvailableUntil.Visible = false;
            PrimaryAddressDetail.Visible = false;
            PrimaryAddressCity.Visible = false;
            PrimaryAddressState.Visible = false;
            PrimaryAddressNearestAirport.Visible = false;
            PrimaryAddressPostCode.Visible = false;
            PrimaryAddressCountryID.Visible = false;
            PrimaryAddressHomeTel.Visible = false;
            PrimaryAddressFax.Visible = false;
            AlternativeAddressDetail.Visible = false;
            AlternativeAddressCity.Visible = false;
            AlternativeAddressState.Visible = false;
            AlternativeAddressHomeTel.Visible = false;
            AlternativeAddressPostCode.Visible = false;
            AlternativeAddressCountryID.Visible = false;
            MobileNumber.SetVisibility();
            _Email.SetVisibility();
            ContactMethodEmail.Visible = false;
            ContactMethodFax.Visible = false;
            ContactMethodMobilePhone.Visible = false;
            ContactMethodHomePhone.Visible = false;
            ContactMethodPost.Visible = false;
            CollarSize.Visible = false;
            ChestSize.Visible = false;
            WaistSize.Visible = false;
            InsideLegSize.Visible = false;
            CapSize.Visible = false;
            SweaterSize_ClothesSizeID.Visible = false;
            BoilersuitSize_ClothesSizeID.Visible = false;
            SocialSecurityNumber.Visible = false;
            SocialSecurityIssuingCountryID.Visible = false;
            SocialSecurityImage.Visible = false;
            PersonalTaxNumber.Visible = false;
            PersonalTaxIssuingCountryID.Visible = false;
            PersonalTaxImage.Visible = false;
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
            NomineeValidVisa.Visible = false;
            BankName.Visible = false;
            BankAddress.Visible = false;
            BankAccountName.Visible = false;
            BankAccountNumber.Visible = false;
            BankSortCode.Visible = false;
            MNOPF.Visible = false;
            MembershipNumber.Visible = false;
            NationalInsuranceNumber.Visible = false;
            AVC.Visible = false;
            ForeignVisaHasBeenDenied.Visible = false;
            ForeignVisaDenied_CountryID.Visible = false;
            ForeignVisaDeniedReason.Visible = false;
            HasMaritimeAccidentOrCourtOfEnquiry.Visible = false;
            HasMaritimeAccidentOrCourtOfEnquiryDetails.Visible = false;
            Reference1CompanyName.Visible = false;
            Reference1ContactPersonName.Visible = false;
            Reference1CompanyAddress.Visible = false;
            Reference1CompanyCountryID.Visible = false;
            Reference1CompanyTelephone.Visible = false;
            Reference2CompanyName.Visible = false;
            Reference2ContactPersonName.Visible = false;
            Reference2CompanyAddress.Visible = false;
            Reference2CompanyCountryID.Visible = false;
            Reference2CompanyTelephone.Visible = false;
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
            FinalAcceptedDate.SetVisibility();
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
        public MtCrewDeleteBase(Controller? controller = null): this() { // DN
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
                    SaveDebugMessage();
                    return Controller.LocalRedirect(AppPath(url));
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

        public string DbMasterFilter = "";

        public string DbDetailFilter = "";

        public int StartRecord;

        public int TotalRecords;

        public int RecordCount;

        public List<string> RecordKeys = new ();

        public DbDataReader? Recordset;

        public int StartRowCount = 1;

        public bool IsModal = false;

        /// <summary>
        /// Page run
        /// </summary>
        /// <returns>Page result</returns>
        public override async Task<IActionResult> Run()
        {
            // Use layout
            if (!Empty(Param("layout")) && !Param<bool>("layout"))
                UseLayout = false;

            // User profile
            Profile = ResolveProfile();

            // Security
            Security = ResolveSecurity();
            if (TableVar != "")
                Security.LoadTablePermissions(TableVar);
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

            // Load key parameters
            RecordKeys = GetRecordKeys(); // Load record keys
            string filter = GetFilterFromRecordKeys();
            if (Empty(filter))
                return Terminate("MtCrewList"); // Prevent SQL injection, return to List page

            // Set up filter (WHERE Clause)
            CurrentFilter = filter;

            // Check if valid User ID
            string sql = GetSql(CurrentFilter);
            using (Recordset = await Connection.OpenDataReaderAsync(sql)) {
                if (Recordset != null) {
                    bool res = true;
                    while (await Recordset.ReadAsync()) {
                        await LoadRowValues(Recordset);
                        if (!ShowOptionLink("delete")) {
                            string userIdMsg = Language.Phrase("NoDeletePermission");
                            FailureMessage = userIdMsg;
                            res = false;
                            break;
                        }
                    }
                    if (!res)
                        return Terminate("MtCrewList"); // Return to List page
                }
            }

            // Get action
            if (IsApi()) {
                CurrentAction = "delete"; // Delete record directly
            } else if (!Empty(Param("action"))) {
                CurrentAction = Param("action") == "delete" ? "delete" : "show";
            } else {
                CurrentAction = InlineDelete ?
                    "delete" : // Delete record directly
                    "show"; // Display record
            }
            if (IsDelete) { // DN
                SendEmail = true; // Send email on delete success
                var res = await DeleteRows();
                if (res) { // Delete rows
                    if (Empty(SuccessMessage))
                        SuccessMessage = Language.Phrase("DeleteSuccess"); // Set up success message
                    if (IsJsonResponse()) {
                        ClearMessages(); // Clear messages for Json response
                        return res;
                    } else {
                        return Terminate(ReturnUrl); // Return to caller
                    }
                } else { // Delete failed
                    if (IsJsonResponse()) {
                        return Terminate();
                    }
                    // Return JSON error message if UseAjaxActions
                    if (UseAjaxActions)
                        return Controller.Json(new { success = false, error = GetFailureMessage() });
                    if (InlineDelete)
                        return Terminate(ReturnUrl); // Return to caller
                    else
                        CurrentAction = "show"; // Display record
                }
            }
            if (IsShow) { // Load records for display // DN
                Recordset = await LoadRecordset();
                TotalRecords = await ListRecordCountAsync(); // Get record count
                if (TotalRecords <= 0) { // No record found, exit
                    CloseRecordset(); // DN
                    return Terminate("MtCrewList"); // Return to list
                }
            }

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);

                // Global Page Rendering event
                PageRendering();

                // Page Render event
                mtCrewDelete?.PageRender();
            }
            return PageResult();
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
            ID.CellCssStyle = "white-space: nowrap;";

            // IndividualCodeNumber
            IndividualCodeNumber.CellCssStyle = "white-space: nowrap;";

            // FullName
            FullName.CellCssStyle = "white-space: nowrap;";

            // FirstName
            FirstName.CellCssStyle = "white-space: nowrap;";

            // MiddleName
            MiddleName.CellCssStyle = "white-space: nowrap;";

            // LastName
            LastName.CellCssStyle = "white-space: nowrap;";

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

            // MaritalStatus
            MaritalStatus.CellCssStyle = "white-space: nowrap;";

            // Gender
            Gender.CellCssStyle = "white-space: nowrap;";

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

            // PrimaryAddressState
            PrimaryAddressState.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressFax
            PrimaryAddressFax.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressDetail
            AlternativeAddressDetail.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressCity
            AlternativeAddressCity.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressState
            AlternativeAddressState.CellCssStyle = "white-space: nowrap;";

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

            // ContactMethodEmail
            ContactMethodEmail.CellCssStyle = "white-space: nowrap;";

            // ContactMethodFax
            ContactMethodFax.CellCssStyle = "white-space: nowrap;";

            // ContactMethodMobilePhone
            ContactMethodMobilePhone.CellCssStyle = "white-space: nowrap;";

            // ContactMethodHomePhone
            ContactMethodHomePhone.CellCssStyle = "white-space: nowrap;";

            // ContactMethodPost
            ContactMethodPost.CellCssStyle = "white-space: nowrap;";

            // CollarSize
            CollarSize.CellCssStyle = "white-space: nowrap;";

            // ChestSize
            ChestSize.CellCssStyle = "white-space: nowrap;";

            // WaistSize
            WaistSize.CellCssStyle = "white-space: nowrap;";

            // InsideLegSize
            InsideLegSize.CellCssStyle = "white-space: nowrap;";

            // CapSize
            CapSize.CellCssStyle = "white-space: nowrap;";

            // SweaterSize_ClothesSizeID
            SweaterSize_ClothesSizeID.CellCssStyle = "white-space: nowrap;";

            // BoilersuitSize_ClothesSizeID
            BoilersuitSize_ClothesSizeID.CellCssStyle = "white-space: nowrap;";

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

            // NomineeValidVisa
            NomineeValidVisa.CellCssStyle = "white-space: nowrap;";

            // BankName
            BankName.CellCssStyle = "white-space: nowrap;";

            // BankAddress
            BankAddress.CellCssStyle = "white-space: nowrap;";

            // BankAccountName
            BankAccountName.CellCssStyle = "white-space: nowrap;";

            // BankAccountNumber
            BankAccountNumber.CellCssStyle = "white-space: nowrap;";

            // BankSortCode
            BankSortCode.CellCssStyle = "white-space: nowrap;";

            // MNOPF
            MNOPF.CellCssStyle = "white-space: nowrap;";

            // MembershipNumber
            MembershipNumber.CellCssStyle = "white-space: nowrap;";

            // NationalInsuranceNumber
            NationalInsuranceNumber.CellCssStyle = "white-space: nowrap;";

            // AVC
            AVC.CellCssStyle = "white-space: nowrap;";

            // ForeignVisaHasBeenDenied
            ForeignVisaHasBeenDenied.CellCssStyle = "white-space: nowrap;";

            // ForeignVisaDenied_CountryID
            ForeignVisaDenied_CountryID.CellCssStyle = "white-space: nowrap;";

            // ForeignVisaDeniedReason
            ForeignVisaDeniedReason.CellCssStyle = "white-space: nowrap;";

            // HasMaritimeAccidentOrCourtOfEnquiry
            HasMaritimeAccidentOrCourtOfEnquiry.CellCssStyle = "white-space: nowrap;";

            // HasMaritimeAccidentOrCourtOfEnquiryDetails
            HasMaritimeAccidentOrCourtOfEnquiryDetails.CellCssStyle = "white-space: nowrap;";

            // Reference1CompanyName
            Reference1CompanyName.CellCssStyle = "white-space: nowrap;";

            // Reference1ContactPersonName
            Reference1ContactPersonName.CellCssStyle = "white-space: nowrap;";

            // Reference1CompanyAddress
            Reference1CompanyAddress.CellCssStyle = "white-space: nowrap;";

            // Reference1CompanyCountryID
            Reference1CompanyCountryID.CellCssStyle = "white-space: nowrap;";

            // Reference1CompanyTelephone
            Reference1CompanyTelephone.CellCssStyle = "white-space: nowrap;";

            // Reference2CompanyName
            Reference2CompanyName.CellCssStyle = "white-space: nowrap;";

            // Reference2ContactPersonName
            Reference2ContactPersonName.CellCssStyle = "white-space: nowrap;";

            // Reference2CompanyAddress
            Reference2CompanyAddress.CellCssStyle = "white-space: nowrap;";

            // Reference2CompanyCountryID
            Reference2CompanyCountryID.CellCssStyle = "white-space: nowrap;";

            // Reference2CompanyTelephone
            Reference2CompanyTelephone.CellCssStyle = "white-space: nowrap;";

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

            // DocumentCheckDateTime
            DocumentCheckDateTime.CellCssStyle = "white-space: nowrap;";

            // InterviewManagerDateTime
            InterviewManagerDateTime.CellCssStyle = "white-space: nowrap;";

            // InterviewGMDateTime
            InterviewGMDateTime.CellCssStyle = "white-space: nowrap;";

            // MCUScheduleDateTime
            MCUScheduleDateTime.CellCssStyle = "white-space: nowrap;";

            // RejectedReason
            RejectedReason.CellCssStyle = "white-space: nowrap;";

            // RejectedDateTime
            RejectedDateTime.CellCssStyle = "white-space: nowrap;";

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

            // NSSF_Health_Number
            NSSF_Health_Number.CellCssStyle = "white-space: nowrap;";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.CellCssStyle = "white-space: nowrap;";

            // FinalAcceptedDate
            FinalAcceptedDate.CellCssStyle = "white-space: nowrap;";

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.CellCssStyle = "white-space: nowrap;";

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

            // RevisedReason
            RevisedReason.CellCssStyle = "white-space: nowrap;";

            // RevisedDateTime
            RevisedDateTime.CellCssStyle = "white-space: nowrap;";

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
                    RequiredPhoto.LinkAttrs["data-rel"] = "MTCrew_x_RequiredPhoto";
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
                    VisaPhoto.LinkAttrs["data-rel"] = "MTCrew_x_VisaPhoto";
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

                // MaritalStatus
                MaritalStatus.HrefValue = "";
                MaritalStatus.TooltipValue = "";

                // Gender
                Gender.HrefValue = "";
                Gender.TooltipValue = "";

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

                // FinalAcceptedDate
                FinalAcceptedDate.HrefValue = "";
                FinalAcceptedDate.TooltipValue = "";

                // RevisedReason
                RevisedReason.HrefValue = "";
                RevisedReason.TooltipValue = "";

                // RevisedDateTime
                RevisedDateTime.HrefValue = "";
                RevisedDateTime.TooltipValue = "";
            }

            // Call Row Rendered event
            if (RowType != RowType.AggregateInit)
                RowRendered();
        }
        #pragma warning restore 1998

        // Delete records (based on current filter)
        protected async Task<JsonBoolResult> DeleteRows() { // DN
            if (!Security.CanDelete) {
                FailureMessage = Language.Phrase("NoDeletePermission"); // No delete permission
                return JsonBoolResult.FalseResult; // No delete permission
            }
            List<Dictionary<string, object>>? rsold = null;
            bool result = true;
            try {
                string sql = CurrentSql;
                using var rs = await Connection.GetDataReaderAsync(sql);
                if (rs == null) {
                    return JsonBoolResult.FalseResult;
                } else if (!rs.HasRows) {
                    FailureMessage = Language.Phrase("NoRecord"); // No record found
                    return JsonBoolResult.FalseResult;
                } else { // Clone old rows
                    rsold = await Connection.GetRowsAsync(rs);
                }
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }
            if (UseTransaction)
                Connection.BeginTrans();
            List<string> successKeys = new (), failKeys = new ();
            try {
                // Call Row Deleting event
                if (result)
                    result = rsold.All(row => RowDeleting(row));
                if (result) {
                    foreach (var row in rsold) {
                        try {
                            result = await DeleteAsync(row) > 0;
                        } catch (Exception e) {
                            if (Config.Debug)
                                throw;
                            FailureMessage = e.Message; // Set up error message
                            result = false;
                        }
                        if (!result) {
                            if (UseTransaction) {
                                successKeys.Clear();
                                break;
                            }
                            failKeys.Add(GetKey(row)); // DN
                        } else {
                            if (Config.DeleteUploadFiles)
                                DeleteUploadedFiles(row);
                            RowDeleted(row);
                            successKeys.Add(GetKey(row)); // DN
                        }
                    }
                }
                result = successKeys.Count > 0;
                if (!result) {
                    // Set up error message
                    if (!Empty(SuccessMessage) || !Empty(FailureMessage)) {
                        // Use the message, do nothing
                    } else if (!Empty(CancelMessage)) {
                        FailureMessage = CancelMessage;
                        CancelMessage = "";
                    } else {
                        FailureMessage = Language.Phrase("DeleteCancelled");
                    }
                }
            } catch (Exception e) {
                FailureMessage = e.Message;
                result = false;
            }
            if (result) {
                if (UseTransaction)
                    Connection.CommitTrans(); // Commit the changes

                // Set warning message if delete some records failed
                if (failKeys.Count > 0)
                    WarningMessage = Language.Phrase("DeleteRecordsFailed").Replace("%k", String.Join(", ", failKeys));
            } else {
                if (UseTransaction)
                    Connection.RollbackTrans(); // Rollback changes
            }

            // Write JSON for API request
            Dictionary<string, object> d = new ();
            d.Add("success", result);
            if (IsJsonResponse() && result) {
                var rows = await GetRecordsFromRecordset(rsold);
                string table = TableVar;
                d.Add(table, RouteValues.Count > 2 && rows.Count == 1 ? rows[0] : rows); // If single-delete, route values are controller/action/id (count > 2)
                d.Add("action", Config.ApiDeleteAction);
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
            breadcrumb.Add("list", TableVar, AppPath(AddMasterUrl("MtCrewList")), "", TableVar, true);
            string pageId = "delete";
            breadcrumb.Add("delete", pageId, url);
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
    } // End page class
} // End Partial class
