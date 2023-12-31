namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// index
    /// </summary>
    public static Index index
    {
        get => HttpData.Get<Index>("index")!;
        set => HttpData["index"] = value;
    }

    /// <summary>
    /// Page class (index)
    /// </summary>
    public class Index : IndexBase
    {
        // Constructor
        public Index(Controller controller) : base(controller)
        {
        }

        // Constructor
        public Index() : base()
        {
        }

        // Server events

        // Page Redirecting event
        public override void PageRedirecting(ref string url) {
            //url = newurl;
            var refererUrl = HttpContext.Request.Headers["Referer"].ToString();
            if (CurrentUserLevel() == "0") // Crew
            {
                var rs = ExecuteRow("SELECT TOP 1 ID, EmployeeStatus FROM MTCrew WHERE MTUserID = " + CurrentUserID());
                if (rs == null)
                {
                    rs = ExecuteRow("SELECT * FROM MTUser WHERE ID = " + CurrentUserID());
                    QueryBuilder("MTCrew").Insert(new
                    {
                        IndividualCodeNumber = rs["SeafarerID"]!=null?rs["SeafarerID"].ToString():"",
                        SocialSecurityImage = rs["IdentificationImage"]!=null?rs["IdentificationImage"].ToString():"",
                        Email = rs["Email"]!=null?rs["Email"]:"",
                        FullName = rs["FullName"]!=null?rs["FullName"]:"",
                        EmployeeStatus = "Candidate - Draft",
                        CreatedByUserID = Convert.ToInt32(rs["ID"]),
                        CreatedDateTime = DateTimeOffset.Now,
                        LastUpdatedByUserID = Convert.ToInt32(rs["ID"]),
                        LastUpdatedDateTime = DateTimeOffset.Now,
                        MTUserID = Convert.ToInt32(rs["ID"]),
                        MTManningAgentID = Convert.ToInt32(rs["MTManningAgentID"]),
                    });
                    dynamic crewQueryResult = QueryBuilder("MTCrew")
                        .Where("MTUserID", CurrentUserID())
                        .Select("ID").FirstOrDefault();
                    if ((object)crewQueryResult != null)
                    {
                        int crewID = crewQueryResult.ID;

                        // gmandayu: insert ke dalam MTRecruitmentStatusTracking untuk pertama kali daftar, selesai progres draft status.
                        // Mengambil data dari tabel MTRecruitmentStatus
                        IEnumerable<dynamic> rows = QueryBuilder("MTRecruitmentStatus").Get();
                        if (rows != null)
                        {
                            // Menghitung jumlah baris data
                            int rowCount = rows.Count();
                            int startingIndex = 100;

                            // Menjalankan perulangan sebanyak rowCount
                            for (int i = startingIndex; i < startingIndex + rowCount; i++)
                            {
                                int flag = (i == startingIndex) ? 1 : 2;
                                string flagDescription = (flag == 1) ? "Selesai" : "Menunggu";
                                try
                                {
                                    var insertData = new
                                    {
                                        MTCrewID = crewID,
                                        MTRecruitmentStatusID = i,
                                        Flag = flag,
                                        FlagDescription = flagDescription,
                                        CreatedDateTime = DateTimeOffset.Now,
                                        CreatedByUserID = CurrentUserID(),
                                        LastUpdatedDateTime = DateTimeOffset.Now,
                                        LastUpdatedByUserID = CurrentUserID(),
                                    };
                                    QueryBuilder("MTRecruitmentStatusTracking").Insert(insertData);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Kesalahan saat menyisipkan data: " + ex.Message);
                                }
                            }
                        }
                        url = "CrewPersonalDataForAdminEdit/" + crewID.ToString();
                    }
                }
                else if (rs["EmployeeStatus"].ToString() == "Candidate - Draft")
                {
                    url = "CrewPersonalDataForAdminEdit/" + rs["ID"].ToString();
                }
                else
                {
                    url = "NotificationForCrewList/";
                }
            }
            else if (CurrentUserLevel() == "-1") // Admin
            {
                if (refererUrl != null && refererUrl.EndsWith("Register") && IsAdmin())
                {
                    var rs = ExecuteRow("SELECT TOP 1 MTUser.ID FROM MTUser LEFT JOIN MTCrew on MTUser.ID = MTCrew.MTUserID  WHERE MTCrew.MTUserID is null ORDER BY ID DESC");
                    if (rs != null)
                    {
                        rs = ExecuteRow("SELECT * FROM MTUser WHERE ID = " + rs["MTUserID"].ToString());
                        QueryBuilder("MTCrew").Insert(new
                        {
                            IndividualCodeNumber = rs["SeafarerID"]!=null?rs["SeafarerID"].ToString():"",
                            SocialSecurityImage = rs["IdentificationImage"]!=null?rs["IdentificationImage"].ToString():"",
                            EmployeeStatus = "Candidate - Draft",
                            Email = rs["Email"]!=null?rs["Email"]:"",
                            FullName = rs["FullName"]!=null?rs["FullName"]:"",
                            CreatedByUserID = Convert.ToInt32(rs["ID"]),
                            CreatedDateTime = DateTimeOffset.Now,
                            LastUpdatedByUserID = Convert.ToInt32(rs["ID"]),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                            MTUserID = Convert.ToInt32(rs["ID"]),
                        });
                        dynamic crewQueryResult = QueryBuilder("MTCrew").Where("MTUserID", rs["ID"].ToString()).Select("ID").FirstOrDefault();
                        if ((object)crewQueryResult != null)
                        {
                            int crewID = crewQueryResult.ID;
                            url = "CrewPersonalDataForAdminEdit/" + crewID.ToString() + "?showdetail=";
                        }
                    }
                }
                else
                {
                    url = "HomePageAdminPde";
                }
            }
            else if (CurrentUserLevel() == "1" || CurrentUserLevel() == "2") // Asst. Manager PDE / Crewing Manager
            {
                url = "ChecklistList";
            }
            else if (CurrentUserLevel() == "-2") // Anonymous(user which is not yet logged in)
            {
                url = "login";
            }
        }
    }

    /// <summary>
    /// Page base class
    /// </summary>
    public class IndexBase : AspNetMakerPage
    {
        // Page ID
        public string PageID = "index";

        // Project ID
        public string ProjectID = "{858E8D60-55D9-41E6-8104-7B793C2843C4}";

        // Page object name
        public string PageObjName = "index";

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
        public IndexBase()
        {
            // Initialize
            CurrentPage = this;

            // Language object
            Language = ResolveLanguage();

            // Start time
            StartTime = Environment.TickCount;

            // Debug message
            LoadDebugMessage();

            // Open connection
            Conn = GetConnection();

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
        public string PageName => "logout";

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
        public IndexBase(Controller? controller = null): this() { // DN
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

        public bool IsModal = false; // DN

        #pragma warning disable 162, 1998
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
            CurrentBreadcrumb = new ();
            if (!Security.IsLoggedIn)
                await Security.AutoLoginAsync();
            Security.LoadUserLevel(); // Load User Level
            string url = "";
            var tableList = Config.UserLevelTablePermissions;
            for (var i = 0; i < tableList.Count; i++) {
                if (tableList[i].TableName == "MTCertificate") {
                    if (Security.AllowList(tableList[i].ProjectId + tableList[i].TableName)) {
                        url = tableList[i].Url;
                        break;
                    }
                } else if (url == "") {
                    if (!Empty(tableList[i].Url) && Security.AllowList(tableList[i].ProjectId + tableList[i].TableName))
                        url = tableList[i].Url;
                }
            }
            if (!Empty(url)) {
                return Terminate(url);
            } else if (Security.IsLoggedIn) {
                FailureMessage = DeniedMessage() + "<br><br><a href=\"" + AppPath("logout") + "\">" + Language.Phrase("BackToLogin") + "</a>";
            } else {
                return Terminate("login"); // Exit and go to login page
            }

            // Set LoginStatus, Page Rendering and Page Render
            if (!IsApi() && !IsTerminated) {
                SetupLoginStatus(); // Setup login status

                // Pass login status to client side
                SetClientVar("login", LoginStatus);
            }
            return PageResult();
        }
        #pragma warning restore 162, 1998

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
    } // End page class
} // End Partial class
