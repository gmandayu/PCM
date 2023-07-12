namespace PCM.Controllers;

// Partial class
[AutoValidateAntiforgeryToken]
[Authorize(Policy = "UserLevel")]
[ApiExplorerSettings(IgnoreApi=true)]
public partial class HomeController : Controller
{
    private IMemoryCache _cache;

    private readonly SignInManager<ApplicationUser> _signInManager;

    // Constructor
    public HomeController(SignInManager<ApplicationUser> signInManager, ILogger<HomeController> logger, IMemoryCache memoryCache)
    {
        _signInManager = signInManager;
        _cache = memoryCache;
        GLOBALS.Logger = logger;
    }

    // Destructor
    protected override void Dispose(bool disposing)
    {
        if (disposing) {
            // Clean up temp folder if not add/edit/export
            dynamic page = CurrentPage;
            if (page != null) {
                string pageId = page.PageID;
                if (GetProperty(page, "TableName") != null &&
                    !(new [] { "add", "register", "edit", "update" }).Contains(pageId) &&
                    !(pageId == "list" && page.IsAddOrEdit) &&
                    !(!Empty(GetPropertyValue(page, "Export")) && page.Export != "print" && page.UseCustomTemplate))
                CleanUploadTempPaths(Session.SessionId);
            }
        }
        base.Dispose(disposing);
    }

    // Personal Data
    [Route("personaldata/{cmd?}", Name = "personaldata")]
    [Route("Home/personaldata/{cmd?}", Name = "personaldata-2")]
    public async Task<IActionResult> PersonalData()
    {
        // Create page object
        personalData = new GLOBALS.PersonalData(this);

        // Run the page
        return await personalData.Run();
    }

    // External provider
    [HttpGet]
    [Route("ExternalLogin/{provider}", Name = "ExternalLogin")]
    [Route("Home/ExternalLogin/{provider}", Name = "ExternalLogin-2")]
    [AllowAnonymous]
    public IActionResult ExternalLogin([FromRoute] string provider)
    {
        if (SameText(provider, "saml"))
            return RedirectToAction("SignIn", "Saml");
        string redirectUrl = AppPath("ExternalCallback");
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return new ChallengeResult(provider, properties);
    }

    // External login callback
    [Route("ExternalCallback", Name = "ExternalCallback")]
    [Route("Home/ExternalCallback", Name = "ExternalCallback-2")]
    [AllowAnonymous]
    public IActionResult ExternalCallback()
    {
        var loginInfo = _signInManager.GetExternalLoginInfoAsync().GetAwaiter().GetResult();  // Get from signInManager first
        string provider = loginInfo?.LoginProvider ?? User.Identity?.AuthenticationType ?? ""; // Google/Facebook/Microsoft
        object? routeValues = provider != "" && Config.Authentications.Keys.Contains(provider) ? new { provider = provider } : null;
        return RedirectToAction("Login", "Home", routeValues); // Redirect to login/{provider}
    }

    // Login
    [Route("login/{provider?}", Name = "login")]
    [Route("Home/login/{provider?}", Name = "login-2")]
    [AllowAnonymous]
    public async Task<IActionResult> Login()
    {
        // Create page object
        login = new GLOBALS.Login(this);

        // Run the page
        return await login.Run();
    }

    // Reset Password
    [Route("resetpassword", Name = "resetpassword")]
    [Route("Home/resetpassword", Name = "resetpassword-2")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword()
    {
        // Create page object
        resetPassword = new GLOBALS.ResetPassword(this);

        // Run the page
        return await resetPassword.Run();
    }

    // Change Password
    [Route("changepassword", Name = "changepassword")]
    [Route("Home/changepassword", Name = "changepassword-2")]
    public async Task<IActionResult> ChangePassword()
    {
        // Create page object
        changePassword = new GLOBALS.ChangePassword(this);

        // Run the page
        return await changePassword.Run();
    }

    // Register
    [Route("register", Name = "register")]
    [Route("Home/register", Name = "register-2")]
    [AllowAnonymous]
    public async Task<IActionResult> Register()
    {
        // Create page object
        register = new GLOBALS.Register(this);

        // Run the page
        return await register.Run();
    }

    // Userpriv
    [Route("userpriv/{UserLevelID?}", Name = "userpriv")]
    [Route("Home/userpriv/{UserLevelID?}", Name = "userpriv-2")]
    public async Task<IActionResult> Userpriv()
    {
        // Create page object
        userpriv = new GLOBALS.Userpriv(this);

        // Run the page
        return await userpriv.Run();
    }

    // Logout
    [Route("logout", Name = "logout")]
    [Route("Home/logout", Name = "logout-2")]
    public async Task<IActionResult> Logout()
    {
        // Create page object
        logout = new GLOBALS.Logout(this);

        // Run the page
        return await logout.Run();
    }

    // Index
    [Route("")]
    [Route("index", Name = "index")]
    [Route("Home/index", Name = "index-2")]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        // Create page object
        index = new GLOBALS.Index(this);

        // Run the page
        return await index.Run();
    }

    // Error
    [Route("error", Name = "error")]
    [Route("Home/error", Name = "error-2")]
    [AllowAnonymous]
    [HttpCacheExpiration(CacheLocation = CacheLocation.Private, NoStore = true, MaxAge = 0)]
    public async Task<IActionResult> Error()
    {
        // Create page object
        error = new GLOBALS.Error(this);

        // Run the page
        return await error.Run();
    }

    // Swagger
    [Route("swagger/swagger", Name = "swagger")]
    [Route("Home/swagger/swagger", Name = "swagger-2")]
    [AllowAnonymous]
    public IActionResult Swagger()
    {
        Language = ResolveLanguage();
        ViewData["Title"] = Language.Phrase("ApiTitle");
        ViewData["Version"] = Config.ApiVersion;
        ViewData["BasePath"] = Request.PathBase.ToString();
        return View();
    }

    // Custom actions
    [Route("IdamanLogin", Name = "IdamanLogin")]
    [AllowAnonymous]
    public IActionResult IdamanLogin()
    {
        if (IsLoggedIn())
        {
            return Redirect(AppPath() + "index");
        }
        if (HttpContext != null && HttpContext.User != null && HttpContext.User.Identity != null)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge("oidc");
            }

            // User is already authenticated
            string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email))?.Value ?? "";
            string fullName = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("display_name"))?.Value ?? "";
            if (email != "" && fullName != "")
            {
                dynamic userQuery = QueryBuilder("MTUser").Where("Email", email).Select("Email").FirstOrDefault();
                if ((object)userQuery != null && (object)userQuery.Email != null)
                {
                    LoginModel model = new()
                    {
                        Username = email,
                        Password = ""
                    };
                    Session.SetBool("IsIdamanUserRegistered", true);
                    Session.SetBool("BypassIdamanPwdCheck", true);
                    Dictionary<string, string> userClaimDictionary = new Dictionary<string, string>();
                    userClaimDictionary.Add(ClaimTypes.Email.Split('/').Last(), email);
                    Profile = ResolveProfile();
                    Profile.Assign(userClaimDictionary);
                    Task.Run(async () =>
                    {
                        await Security.ValidateUser(model, true);
                    }).GetAwaiter().GetResult();
                    return Redirect(AppPath() + "index"); 
                }
                else
                {
                    Session.SetBool("IsIdamanUserRegistered", false);
                    Task.Run(async () =>
                    {
                        await HttpContext.SignOutAsync("oidc");
                    }).GetAwaiter().GetResult();
                    HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());
                    if (Session.GetBool("BypassIdamanPwdCheck"))
                    {
                        Session.SetBool("BypassIdamanPwdCheck", false);
                    }
                    return Redirect(AppPath() + "IdamanUserNotRegistered");
                }       
            }
        }
        return Redirect(AppPath() + "login");
    }

    // Dispose
    // protected override void Dispose(bool disposing) {
    //     try {
    //         base.Dispose(disposing);
    //     } finally {
    //         CurrentPage?.Terminate();
    //     }
    // }
}
