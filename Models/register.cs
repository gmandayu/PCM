namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// register
    /// </summary>
    public static Register register
    {
        get => HttpData.Get<Register>("register")!;
        set => HttpData["register"] = value;
    }

    /// <summary>
    /// Page class (register)
    /// </summary>
    public class Register : RegisterBase
    {
        // Constructor
        public Register(Controller controller) : base(controller)
        {
        }

        // Constructor
        public Register() : base()
        {
        }

        // Server events

        // User Registered event
        public override void UserRegistered(Dictionary<string, object> rs) {
            // string socialSecurityImageFileName = rs["IdentificationImage"].ToString();
            // string socialSecurityImageFileExtension = System.IO.Path.GetExtension(socialSecurityImageFileName);
            // string newSocialSecurityImageFileName = rs["SeafarerID"].ToString() + "-ss" + socialSecurityImageFileExtension;

            // QueryBuilder("MTCrew").Insert(new {
            //     FullName = rs["FullName"].ToString(),
            //     IndividualCodeNumber = rs["SeafarerID"].ToString(),
            //     SocialSecurityImage = newSocialSecurityImageFileName,
            //     EmployeeStatus = "Candidate - Draft",
            //     CreatedByUserID = Convert.ToInt32(rs["ID"]),
            //     CreatedDateTime = DateTimeOffset.Now,
            //     LastUpdatedByUserID = Convert.ToInt32(rs["ID"]),
            //     LastUpdatedDateTime = DateTimeOffset.Now,
            //     MTUserID = Convert.ToInt32(rs["ID"]),
            // });

            // dynamic crewQueryResult = QueryBuilder("MTCrew").Where("IndividualCodeNumber", rs["SeafarerID"].ToString()).Select("ID").FirstOrDefault();
            // if ((object) crewQueryResult != null)
            // {
            //     int crewID = crewQueryResult.ID;
            //     QueryBuilder("TREmployeeStatus").Insert(new {
            //         MTCrewID = crewID,
            //         MTUserID = Convert.ToInt32(rs["ID"]),
            //         PreviousStatus = "",
            //         CurrentStatus = "Candidate - Draft",
            //         ChangedDateTime = DateTimeOffset.Now,
            //     });
            // }
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class RegisterBase : MtUser
    {
        // Page ID
        public string PageID = "register";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Page object name
        public string PageObjName = "register";

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
        public RegisterBase()
        {
            // Initialize
            CurrentPage = this;

            // Table CSS class
            TableClass = "table table-striped table-bordered table-hover table-sm ew-desktop-table ew-register-table";

            // Language object
            Language = ResolveLanguage();

            // Table object (mtUser)
            if (mtUser == null || mtUser is MtUser)
                mtUser = this;
            mtUser = Resolve("MTUser")!;

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
                return "";
            }
        }

        // Page name
        public string PageName => "register";

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

        // Constructor
        public RegisterBase(Controller? controller = null): this() { // DN
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
                    // Handle modal response
                    if (IsModal) { // Show as modal
                        var result = new { url = GetUrl(url) };
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
                IdentificationImage.OldUploadPath = IdentificationImage.GetUploadPath();
                IdentificationImage.UploadPath = IdentificationImage.OldUploadPath;
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

        public string FormClassName = "ew-form ew-register-form";

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

            // Load default values for add
            LoadDefaultValues();

            // Check modal
            if (IsModal)
                SkipHeaderFooter = true;
            IsMobileOrModal = IsMobile() || IsModal;

            // Set up Breadcrumb
            CurrentBreadcrumb = new ();
            string url = CurrentUrl(); // DN
            CurrentBreadcrumb.Add("register", "RegisterPage", url, "", "", true);
            Heading = Language.Phrase("RegisterPage");
            bool userExists = false;
            await LoadRowValues(); // Load default values

            // Get action
            string currentAction = "";
            StringValues sv;
            if (IsApi())
                currentAction = "insert";
            else if (Post("action", out sv))
                currentAction = sv.ToString();
            if (!Empty(currentAction)) {
                CurrentAction = currentAction;
                await LoadFormValues(); // Get form values

                // Validate form
                if (!await ValidateForm()) {
                    if (IsApi())
                        return Terminate();
                    else
                        CurrentAction = "show"; // Form error, reset action
                }
            } else {
                CurrentAction = "show"; // Display blank record
            }
            var model = new LoginModel();

                // Insert record
                if (IsInsert) {
                    // Check for duplicate User ID
                    string filter = GetUserFilter(Config.LoginUsernameFieldName, _Email.CurrentValue);
                    using var rschk = await LoadReader(filter);
                    if (rschk?.HasRows ?? false) { // DN
                        userExists = true;
                        RestoreFormValues(); // Restore form values
                        FailureMessage = Language.Phrase("UserExists"); // Set user exist message
                    }
                    if (!userExists) {
                        SendEmail = true; // Send email on add success
                        var res = await AddRow(); // Add record
                        if (res) {
                            if (Empty(SuccessMessage))
                                SuccessMessage = Language.Phrase("RegisterSuccess"); // Register success

                            // Auto login user
                            model.Username = ConvertToString(_Email.CurrentValue);
                            model.Password = Password.FormValue;
                            if (!await Security.ValidateUser(model, true)) // Auto login user
                                FailureMessage = Language.Phrase("AutoLoginFailed"); // Set auto login failed message
                            if (IsApi()) { // Return to caller
                                return res;
                            } else {
                                if (Config.UseTwoFactorAuthentication && Config.ForceTwoFactorAuthentication) { // Add two factor authentication
                                    Session[Config.SessionStatus] = "loggingin2fa";
                                    Session[Config.SessionUserProfileUserName] = _Email.CurrentValue;
                                    Session[Config.SessionUserProfilePassword] = Password.FormValue;
                                    return Terminate("login2fa"); // Add two factor authentication
                                } else {
                                    return Terminate("index"); // Return
                                }
                            }
                        } else if (IsApi()) { // API request, return
                            return Terminate();
                        } else {
                            RestoreFormValues(); // Restore form values
                        }
                    } else if (IsApi()) { // API request, return
                        return Terminate();
                    }
            }

            // Render row
            if (IsConfirm) { // Confirm page
                RowType = RowType.View; // Render view
            } else {
                RowType = RowType.Add; // Render add
            }
            ResetAttributes();
            await RenderRow();

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);
            }
            return PageResult();
        }

        // Confirm page
        public bool ConfirmPage = true; // DN

        #pragma warning disable 1998
        // Get upload files
        public async Task GetUploadFiles()
        {
            // Get upload data
            IdentificationImage.Upload.Index = CurrentForm.Index;
            if (!await IdentificationImage.Upload.UploadFile()) // DN
                End(IdentificationImage.Upload.Message);
            IdentificationImage.CurrentValue = IdentificationImage.Upload.FileName;
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

            // Check field name 'Email' before field var 'x__Email'
            val = CurrentForm.HasValue("Email") ? CurrentForm.GetValue("Email") : CurrentForm.GetValue("x__Email");
            if (!_Email.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Email") && !CurrentForm.HasValue("x__Email")) // DN
                    _Email.Visible = false; // Disable update for API request
                else
                    _Email.SetFormValue(val, true, validate);
            }

            // Check field name 'Password' before field var 'x_Password'
            val = CurrentForm.HasValue("Password") ? CurrentForm.GetValue("Password") : CurrentForm.GetValue("x_Password");
            if (!Password.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("Password") && !CurrentForm.HasValue("x_Password")) // DN
                    Password.Visible = false; // Disable update for API request
                else
                    Password.SetFormValue(val);
            }

            // Note: ConfirmValue will be compared with FormValue
            if (Config.EncryptedPassword) // Encrypted password, use raw value
                Password.ConfirmValue = CurrentForm.GetValue("c_Password");
            else
                Password.ConfirmValue = RemoveXss(CurrentForm.GetValue("c_Password"));

            // Check field name 'FullName' before field var 'x_FullName'
            val = CurrentForm.HasValue("FullName") ? CurrentForm.GetValue("FullName") : CurrentForm.GetValue("x_FullName");
            if (!FullName.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("FullName") && !CurrentForm.HasValue("x_FullName")) // DN
                    FullName.Visible = false; // Disable update for API request
                else
                    FullName.SetFormValue(val);
            }

            // Check field name 'SeafarerID' before field var 'x_SeafarerID'
            val = CurrentForm.HasValue("SeafarerID") ? CurrentForm.GetValue("SeafarerID") : CurrentForm.GetValue("x_SeafarerID");
            if (!SeafarerID.IsDetailKey) {
                if (IsApi() && !CurrentForm.HasValue("SeafarerID") && !CurrentForm.HasValue("x_SeafarerID")) // DN
                    SeafarerID.Visible = false; // Disable update for API request
                else
                    SeafarerID.SetFormValue(val);
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
            IdentificationImage.OldUploadPath = IdentificationImage.GetUploadPath();
            IdentificationImage.UploadPath = IdentificationImage.OldUploadPath;
            await GetUploadFiles(); // Get upload files
        }
        #pragma warning restore 1998

        // Restore form values
        public void RestoreFormValues()
        {
            _Email.CurrentValue = _Email.FormValue;
            Password.CurrentValue = Password.FormValue;
            FullName.CurrentValue = FullName.FormValue;
            SeafarerID.CurrentValue = SeafarerID.FormValue;
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
            _Email.SetDbValue(row["Email"]);
            Password.SetDbValue(row["Password"]);
            FullName.SetDbValue(row["FullName"]);
            MTUserLevelID.SetDbValue(row["MTUserLevelID"]);
            SeafarerID.SetDbValue(row["SeafarerID"]);
            IdentificationImage.Upload.DbValue = row["IdentificationImage"];
            IdentificationImage.SetDbValue(IdentificationImage.Upload.DbValue);
            CrewAgency.SetDbValue(row["CrewAgency"]);
            MTManningAgentID.SetDbValue(row["MTManningAgentID"]);
        }
        #pragma warning restore 162, 168, 1998, 4014

        // Return a row with default values
        protected Dictionary<string, object> NewRow() {
            var row = new Dictionary<string, object>();
            row.Add("ID", ID.DefaultValue ?? DbNullValue); // DN
            row.Add("Email", _Email.DefaultValue ?? DbNullValue); // DN
            row.Add("Password", Password.DefaultValue ?? DbNullValue); // DN
            row.Add("FullName", FullName.DefaultValue ?? DbNullValue); // DN
            row.Add("MTUserLevelID", MTUserLevelID.DefaultValue ?? DbNullValue); // DN
            row.Add("SeafarerID", SeafarerID.DefaultValue ?? DbNullValue); // DN
            row.Add("IdentificationImage", IdentificationImage.DefaultValue ?? DbNullValue); // DN
            row.Add("CrewAgency", CrewAgency.DefaultValue ?? DbNullValue); // DN
            row.Add("MTManningAgentID", MTManningAgentID.DefaultValue ?? DbNullValue); // DN
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

            // Email
            _Email.RowCssClass = "row";

            // Password
            Password.RowCssClass = "row";

            // FullName
            FullName.RowCssClass = "row";

            // MTUserLevelID
            MTUserLevelID.RowCssClass = "row";

            // SeafarerID
            SeafarerID.RowCssClass = "row";

            // IdentificationImage
            IdentificationImage.RowCssClass = "row";

            // CrewAgency
            CrewAgency.RowCssClass = "row";

            // MTManningAgentID
            MTManningAgentID.RowCssClass = "row";

            // View row
            if (RowType == RowType.View) {
                // Email
                _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
                _Email.ViewCustomAttributes = "";

                // Password
                Password.ViewValue = Language.Phrase("PasswordMask");
                Password.ViewCustomAttributes = "";

                // FullName
                FullName.ViewValue = ConvertToString(FullName.CurrentValue); // DN
                FullName.ViewCustomAttributes = "";

                // MTUserLevelID
                if (Security.CanAdmin) { // System admin
                    curVal = ConvertToString(MTUserLevelID.CurrentValue);
                    if (!Empty(curVal)) {
                        if (MTUserLevelID.Lookup != null && IsDictionary(MTUserLevelID.Lookup?.Options) && MTUserLevelID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                            MTUserLevelID.ViewValue = MTUserLevelID.LookupCacheOption(curVal);
                        } else { // Lookup from database // DN
                            filterWrk = SearchFilter("[UserLevelID]", "=", MTUserLevelID.CurrentValue, DataType.Number, "");
                            sqlWrk = MTUserLevelID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                            rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                            if (rswrk?.Count > 0 && MTUserLevelID.Lookup != null) { // Lookup values found
                                var listwrk = MTUserLevelID.Lookup?.RenderViewRow(rswrk[0]);
                                MTUserLevelID.ViewValue = MTUserLevelID.HighlightLookup(ConvertToString(rswrk[0]), MTUserLevelID.DisplayValue(listwrk));
                            } else {
                                MTUserLevelID.ViewValue = MTUserLevelID.CurrentValue;
                            }
                        }
                    } else {
                        MTUserLevelID.ViewValue = DbNullValue;
                    }
                } else {
                    MTUserLevelID.ViewValue = Language.Phrase("PasswordMask");
                }
                MTUserLevelID.ViewCustomAttributes = "";

                // SeafarerID
                SeafarerID.ViewValue = ConvertToString(SeafarerID.CurrentValue); // DN
                SeafarerID.ViewCustomAttributes = "";

                // IdentificationImage
                IdentificationImage.UploadPath = IdentificationImage.GetUploadPath();
                if (!IsNull(IdentificationImage.Upload.DbValue)) {
                    IdentificationImage.ImageWidth = 120;
                    IdentificationImage.ImageHeight = 0;
                    IdentificationImage.ImageAlt = IdentificationImage.Alt;
                    IdentificationImage.ImageCssClass = "ew-image";
                    IdentificationImage.ViewValue = IdentificationImage.Upload.DbValue;
                } else {
                    IdentificationImage.ViewValue = "";
                }
                IdentificationImage.ViewCustomAttributes = "";

                // MTManningAgentID
                curVal = ConvertToString(MTManningAgentID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MTManningAgentID.Lookup != null && IsDictionary(MTManningAgentID.Lookup?.Options) && MTManningAgentID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTManningAgentID.ViewValue = MTManningAgentID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MTManningAgentID.CurrentValue, DataType.Number, "");
                        sqlWrk = MTManningAgentID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MTManningAgentID.Lookup != null) { // Lookup values found
                            var listwrk = MTManningAgentID.Lookup?.RenderViewRow(rswrk[0]);
                            MTManningAgentID.ViewValue = MTManningAgentID.HighlightLookup(ConvertToString(rswrk[0]), MTManningAgentID.DisplayValue(listwrk));
                        } else {
                            MTManningAgentID.ViewValue = MTManningAgentID.CurrentValue;
                        }
                    }
                } else {
                    MTManningAgentID.ViewValue = DbNullValue;
                }
                MTManningAgentID.ViewCustomAttributes = "";

                // Email
                _Email.HrefValue = "";
                _Email.TooltipValue = "";

                // Password
                Password.HrefValue = "";
                Password.TooltipValue = "";

                // FullName
                FullName.HrefValue = "";
                FullName.TooltipValue = "";

                // SeafarerID
                SeafarerID.HrefValue = "";
                SeafarerID.TooltipValue = "";

                // IdentificationImage
                IdentificationImage.UploadPath = IdentificationImage.GetUploadPath();
                if (!IsNull(IdentificationImage.Upload.DbValue)) {
                    IdentificationImage.HrefValue = ConvertToString(GetFileUploadUrl(IdentificationImage, IdentificationImage.HtmlDecode(ConvertToString(IdentificationImage.Upload.DbValue)))); // Add prefix/suffix
                    IdentificationImage.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        IdentificationImage.HrefValue = FullUrl(ConvertToString(IdentificationImage.HrefValue), "href");
                } else {
                    IdentificationImage.HrefValue = "";
                }
                IdentificationImage.ExportHrefValue = IdentificationImage.UploadPath + IdentificationImage.Upload.DbValue;
                IdentificationImage.TooltipValue = "";
                if (IdentificationImage.UseColorbox) {
                    if (Empty(IdentificationImage.TooltipValue))
                        IdentificationImage.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                    IdentificationImage.LinkAttrs["data-rel"] = "MTUser_x_IdentificationImage";
                    if (IdentificationImage.LinkAttrs.ContainsKey("class")) {
                        IdentificationImage.LinkAttrs.AppendClass("ew-lightbox");
                    } else {
                        IdentificationImage.LinkAttrs["class"] = "ew-lightbox";
                    }
                }

                // MTManningAgentID
                MTManningAgentID.HrefValue = "";
                MTManningAgentID.TooltipValue = "";
            } else if (RowType == RowType.Add) {
                // Email
                _Email.SetupEditAttributes();
                if (!_Email.Raw)
                    _Email.CurrentValue = HtmlDecode(_Email.CurrentValue);
                _Email.EditValue = HtmlEncode(_Email.CurrentValue);
                _Email.PlaceHolder = RemoveHtml(_Email.Caption);

                // Password
                Password.SetupEditAttributes();
                Password.EditValue = Language.Phrase("PasswordMask"); // Show as masked password
                Password.PlaceHolder = RemoveHtml(Password.Caption);

                // FullName
                FullName.SetupEditAttributes();
                if (!FullName.Raw)
                    FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
                FullName.EditValue = HtmlEncode(FullName.CurrentValue);
                FullName.PlaceHolder = RemoveHtml(FullName.Caption);

                // SeafarerID
                SeafarerID.SetupEditAttributes();
                if (!SeafarerID.Raw)
                    SeafarerID.CurrentValue = HtmlDecode(SeafarerID.CurrentValue);
                SeafarerID.EditValue = HtmlEncode(SeafarerID.CurrentValue);
                SeafarerID.PlaceHolder = RemoveHtml(SeafarerID.Caption);

                // IdentificationImage
                IdentificationImage.SetupEditAttributes();
                IdentificationImage.EditAttrs["accept"] = "jpeg,png,jpg";
                IdentificationImage.UploadPath = IdentificationImage.GetUploadPath();
                if (!IsNull(IdentificationImage.Upload.DbValue)) {
                    IdentificationImage.ImageWidth = 120;
                    IdentificationImage.ImageHeight = 0;
                    IdentificationImage.ImageAlt = IdentificationImage.Alt;
                    IdentificationImage.ImageCssClass = "ew-image";
                    IdentificationImage.EditValue = IdentificationImage.Upload.DbValue;
                } else {
                    IdentificationImage.EditValue = "";
                }
                if (!Empty(IdentificationImage.CurrentValue))
                        IdentificationImage.Upload.FileName = ConvertToString(IdentificationImage.CurrentValue);
                if (IsShow && !EventCancelled)
                    await RenderUploadField(IdentificationImage);

                // MTManningAgentID
                MTManningAgentID.SetupEditAttributes();
                curVal = ConvertToString(MTManningAgentID.CurrentValue)?.Trim() ?? "";
                if (MTManningAgentID.Lookup != null && IsDictionary(MTManningAgentID.Lookup?.Options) && MTManningAgentID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTManningAgentID.EditValue = MTManningAgentID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    if (curVal == "") {
                        filterWrk = "0=1";
                    } else {
                        filterWrk = SearchFilter("[ID]", "=", MTManningAgentID.CurrentValue, DataType.Number, "");
                    }
                    sqlWrk = MTManningAgentID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTManningAgentID.EditValue = rswrk;
                }
                MTManningAgentID.PlaceHolder = RemoveHtml(MTManningAgentID.Caption);

                // Add refer script

                // Email
                _Email.HrefValue = "";

                // Password
                Password.HrefValue = "";

                // FullName
                FullName.HrefValue = "";

                // SeafarerID
                SeafarerID.HrefValue = "";

                // IdentificationImage
                IdentificationImage.UploadPath = IdentificationImage.GetUploadPath();
                if (!IsNull(IdentificationImage.Upload.DbValue)) {
                    IdentificationImage.HrefValue = ConvertToString(GetFileUploadUrl(IdentificationImage, IdentificationImage.HtmlDecode(ConvertToString(IdentificationImage.Upload.DbValue)))); // Add prefix/suffix
                    IdentificationImage.LinkAttrs["target"] = "_blank"; // Add target
                    if (IsExport())
                        IdentificationImage.HrefValue = FullUrl(ConvertToString(IdentificationImage.HrefValue), "href");
                } else {
                    IdentificationImage.HrefValue = "";
                }
                IdentificationImage.ExportHrefValue = IdentificationImage.UploadPath + IdentificationImage.Upload.DbValue;

                // MTManningAgentID
                MTManningAgentID.HrefValue = "";
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
            if (_Email.Required) {
                if (!_Email.IsDetailKey && Empty(_Email.FormValue)) {
                    _Email.AddErrorMessage(Language.Phrase("EnterUserName"));
                }
            }
            if (!CheckEmail(_Email.FormValue)) {
                _Email.AddErrorMessage(_Email.GetErrorMessage(false));
            }
            if (!_Email.Raw && Config.RemoveXss && CheckUsername(_Email.FormValue)) {
                _Email.AddErrorMessage(Language.Phrase("InvalidUsernameChars"));
            }
            if (Password.Required) {
                if (!Password.IsDetailKey && Empty(Password.FormValue)) {
                    Password.AddErrorMessage(Language.Phrase("EnterPassword"));
                }
            }
            if (!SameString(Password.ConfirmValue, Password.FormValue)) { // DN
                Password.AddErrorMessage(Language.Phrase("MismatchPassword"));
            }
            if (!Password.Raw && Config.RemoveXss && CheckPassword(Password.FormValue)) {
                Password.AddErrorMessage(Language.Phrase("InvalidPasswordChars"));
            }
            if (FullName.Required) {
                if (!FullName.IsDetailKey && Empty(FullName.FormValue)) {
                    FullName.AddErrorMessage(ConvertToString(FullName.RequiredErrorMessage).Replace("%s", FullName.Caption));
                }
            }
            if (SeafarerID.Required) {
                if (!SeafarerID.IsDetailKey && Empty(SeafarerID.FormValue)) {
                    SeafarerID.AddErrorMessage(ConvertToString(SeafarerID.RequiredErrorMessage).Replace("%s", SeafarerID.Caption));
                }
            }
            if (IdentificationImage.Required) {
                if (IdentificationImage.Upload.FileName == "" && !IdentificationImage.Upload.KeepFile) {
                    IdentificationImage.AddErrorMessage(ConvertToString(IdentificationImage.RequiredErrorMessage).Replace("%s", IdentificationImage.Caption));
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

        // Add record
        #pragma warning disable 168, 219

        protected async Task<JsonBoolResult> AddRow(Dictionary<string, object>? rsold = null) { // DN
            bool result = false;

            // Set new row
            Dictionary<string, object> rsnew = new ();
            try {
                // Email
                _Email.SetDbValue(rsnew, _Email.CurrentValue);

                // Password
                if (Config.EncryptedPassword && !IsMaskedPassword(Password.CurrentValue)) {
                    Password.CurrentValue = EncryptPassword(Config.CaseSensitivePassword ? ConvertToString(Password.CurrentValue) : ConvertToString(Password.CurrentValue).ToLower());
                }
                Password.SetDbValue(rsnew, Password.CurrentValue);

                // FullName
                FullName.SetDbValue(rsnew, FullName.CurrentValue);

                // SeafarerID
                SeafarerID.SetDbValue(rsnew, SeafarerID.CurrentValue);

                // IdentificationImage
                if (IdentificationImage.Visible && !IdentificationImage.Upload.KeepFile) {
                    IdentificationImage.Upload.DbValue = ""; // No need to delete old file
                    if (Empty(IdentificationImage.Upload.FileName)) {
                        rsnew["IdentificationImage"] = DbNullValue;
                    } else {
                        rsnew["IdentificationImage"] = IdentificationImage.Upload.FileName;
                    }
                }

                // MTManningAgentID
                MTManningAgentID.SetDbValue(rsnew, MTManningAgentID.CurrentValue);

                // ID
            } catch (Exception e) {
                if (Config.Debug)
                    throw;
                FailureMessage = e.Message;
                return JsonBoolResult.FalseResult;
            }
            if (IdentificationImage.Visible && !IdentificationImage.Upload.KeepFile) {
                IdentificationImage.UploadPath = IdentificationImage.GetUploadPath();
                List<string> oldFiles = Empty(IdentificationImage.Upload.DbValue) ? new () : new () { IdentificationImage.HtmlDecode(IdentificationImage.Upload.DbValue) };
                if (!Empty(IdentificationImage.Upload.FileName)) {
                    var newFiles = new string[] { IdentificationImage.Upload.FileName };
                    for (var i = 0; i < newFiles.Length; i++) {
                        if (!Empty(newFiles[i])) {
                            string tempPath = UploadTempPath(IdentificationImage, IdentificationImage.Upload.Index);
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
                                var folders = new[] { IdentificationImage.PhysicalUploadPath, tempPath };
                                string file1 = UniqueFileName(IdentificationImage.PhysicalUploadPath, file); // Get new file name (without index)
                                if (file1 != file) {
                                    while (FileExists(tempPath + file1) || FileExists(IdentificationImage.PhysicalUploadPath + file1)) // Make sure no file name clash
                                        file1 = UniqueFileName(folders, file1, true); // Use indexed name
                                    MoveFile(tempPath + file, tempPath + file1); // Rename temp file
                                    newFiles[i] = file1; // Update new file name
                                }
                            }
                        }
                    }
                    IdentificationImage.Upload.DbValue = String.Join(ConvertToString(Config.MultipleUploadSeparator), oldFiles);
                    IdentificationImage.Upload.FileName = String.Join(ConvertToString(Config.MultipleUploadSeparator), newFiles);
                    IdentificationImage.SetDbValue(rsnew, IdentificationImage.Upload.FileName);
                }
            }

            // Update current values
            SetCurrentValues(rsnew);

            // Check if valid User ID
            bool validUser = false;
            string userIdMsg;
            if (!Empty(Security.CurrentUserID) && !Security.IsAdmin) { // Non system admin
                validUser = Security.IsValidUserID(ID.CurrentValue);
                if (!validUser) {
                    userIdMsg = Language.Phrase("UnAuthorizedUserID").Replace("%c", ConvertToString(Security.CurrentUserID));
                    userIdMsg = userIdMsg.Replace("%u", ConvertToString(ID.CurrentValue));
                    FailureMessage = userIdMsg;
                    return JsonBoolResult.FalseResult;
                }
            }
            if (!Empty(_Email.CurrentValue)) { // Check field with unique index
                var filter = "(Email = '" + AdjustSql(_Email.CurrentValue, DbId) + "')";
                using var rschk = await LoadReader(filter);
                if (rschk?.HasRows ?? false) { // DN
                    FailureMessage = Language.Phrase("DupIndex").Replace("%f", _Email.Caption).Replace("%v", ConvertToString(_Email.CurrentValue));
                    return JsonBoolResult.FalseResult;
                }
            }
            if (!Empty(SeafarerID.CurrentValue)) { // Check field with unique index
                var filter = "(SeafarerID = '" + AdjustSql(SeafarerID.CurrentValue, DbId) + "')";
                using var rschk = await LoadReader(filter);
                if (rschk?.HasRows ?? false) { // DN
                    FailureMessage = Language.Phrase("DupIndex").Replace("%f", SeafarerID.Caption).Replace("%v", ConvertToString(SeafarerID.CurrentValue));
                    return JsonBoolResult.FalseResult;
                }
            }

            // Load db values from rsold
            LoadDbValues(rsold);
            if (rsold != null) {
                IdentificationImage.OldUploadPath = IdentificationImage.GetUploadPath();
                IdentificationImage.UploadPath = IdentificationImage.OldUploadPath;
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
                    if (IdentificationImage.Visible && !IdentificationImage.Upload.KeepFile) {
                        var newFiles = new string[] {};
                        var oldFiles = Empty(IdentificationImage.Upload.DbValue) ? new string[] {} : new string[] { IdentificationImage.HtmlDecode(IdentificationImage.Upload.DbValue) };
                        if (!Empty(IdentificationImage.Upload.FileName)) {
                            newFiles = new string[] { IdentificationImage.Upload.FileName };
                            var newFiles2 = new string[] { IdentificationImage.HtmlDecode(ConvertToString(rsnew["IdentificationImage"])) };
                            for (var i = 0; i < newFiles.Length; i++) {
                                if (!Empty(newFiles[i])) {
                                    var file = UploadTempPath(IdentificationImage, IdentificationImage.Upload.Index) + newFiles[i];
                                    if (FileExists(file)) {
                                        if (!Empty(newFiles2[i])) // Use correct file name
                                            newFiles[i] = newFiles2[i];
                                        if (!await IdentificationImage.Upload.SaveToFile(newFiles[i], true, i)) { // Just replace
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
                                    DeleteFile(IdentificationImage.OldPhysicalUploadPath + oldFiles[i]);
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

            // Call Row Inserted event
            if (result)
                RowInserted(rsold, rsnew);

            // Call User Registered event
            if (result)
                UserRegistered(rsnew);

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

        // Set up Breadcrumb
        protected void SetupBreadcrumb() {
            var breadcrumb = new Breadcrumb();
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

        // Form Custom Validate event
        public virtual bool FormCustomValidate(ref string customError) {
            //Return error message in customError
            return true;
        }

        // User Registered event
        public virtual void UserRegistered(Dictionary<string, object> rs) {
            //Log("User_Registered");
        }

        // User Activated event
        public virtual void UserActivated(Dictionary<string, object> rs) {
            //Log("User_Activated");
        }
    } // End page class
} // End Partial class
