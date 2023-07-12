namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// Global events
    /// </summary>

    // ContentType Mapping event
    public static void ContentTypeMapping(IDictionary<string, string> mappings) {
        // Example:
        //mappings[".image"] = "image/png"; // Add new mappings
        //mappings[".rtf"] = "application/x-msdownload"; // Replace an existing mapping
        //mappings.Remove(".mp4"); // Remove MP4 videos
    }

    // Class Init event
    public static void ClassInit() {
        // Enter your code here
    }

    // Page Loading event
    public static void PageLoading() {
        // Enter your code here
    }

    // Page Rendering event
    public static void PageRendering() {
        //Log("Page Rendering");
    }

    // Page Unloaded event
    public static void PageUnloaded() {
        // Enter your code here
    }

    // Personal Data Downloading event
    public static void PersonalDataDownloading(Dictionary<string, object> row) {
        //Log("PersonalData Downloading");
    }

    // Personal Data Deleted event
    public static void PersonalDataDeleted(Dictionary<string, object> row) {
        //Log("PersonalData Deleted");
    }

    // AuditTrail Inserting event
    public static bool AuditTrailInserting(Dictionary<string, object> rsnew) {
        return true;
    }

    // Chart Rendered event
    public static void ChartRendered(ChartJsRenderer renderer) {
        // Example:
        //var data = renderer.Data;
        //var options = renderer.Options;
        //DbChart chart = renderer.Chart;
        //if (chart.ID == "<Report>_<Chart>") { // Check chart ID
        //}
    }

    // One Time Password Sending event
    public static bool OtpSending(string user, dynamic client) {
        // Example:
        // Log(user, client); // View user and client (Email or Sms object)
        // if (SameText(Config.TwoFactorAuthenticationType, "email")) { // Possible values: "email" or "sms"
        //     client.Content = ...; // Change content
        //     client.Recipient = ...; // Change recipient
        //     // return false; // Return false to cancel
        // }
        return true;
    }

    // Routes Add event
    public static void RouteAction(IEndpointRouteBuilder app) {
        // Example:
        // app.MapGet("/", () => "Hello World!");
    }

    // Services Add event
    public static void ServiceAdd(IServiceCollection services) {
        // Example:
        // services.AddSignalR();
    }

    // Container Build event
    public static void ContainerBuild(ContainerBuilder builder) {
        // Enter your code here
    }

    // App Build event
    public static void AppBuild(WebApplicationBuilder builder) {
        // Example:
        // builder.Configuration.AddAzureKeyVault(...);
        var idamanConfiguration = new Dictionary<string, string?>
        {
            { "Idaman:UrlLogin", "https://login.qa.idaman.pertamina.com" },
            { "Idaman:UrlApi", "http://rest.qa.idaman.pertamina.com/v1/" },
            { "Idaman:ClientId", "39a50da5-9549-4a89-9587-1bd7dfe25186" },
            { "Idaman:ClientSecret", "a565a43d-3407-420c-ab2a-96074bf276db" },
            { "Idaman:Scopes", "api.auth, application.read, application.readAll, user.read, user.readAll, user.role, user.whiteList.readAll, user.whiteList.read" }
        };
        builder.Configuration.AddInMemoryCollection(idamanConfiguration);
        builder.Services.AddAuthentication(options => {
            options.DefaultScheme = "oidc";
            options.DefaultChallengeScheme = "oidc";
        }).AddOpenIdConnect("oidc", options => SetOpenIdConnectOptions(options, builder.Configuration));
    }

    // Global user code
    // generate url friendly slug, a slug is a portion of a URL that is used to identify a particular page or resource in a human-readable way
    public static string GenerateSlug(string phrase) 
    {
        string str = RemoveAccent(phrase).ToLower();
        str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // Remove all non-alphanumeric characters except spaces and hyphens
        str = Regex.Replace(str, @"\s+", " ").Trim(); // Replace multiple spaces with a single space
        str = Regex.Replace(str, @"\s", "-"); // Replace spaces with hyphens
        str = Regex.Replace(str, @"-+", "-").Trim(); // Replace multiple hyphens with a single hyphen
        return str;
    }

    // This method removes any diacritics or accent marks from the given string.
    private static string RemoveAccent(string txt)
    {
        byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
        return Encoding.ASCII.GetString(bytes);
    }

    public static void SetOpenIdConnectOptions(OpenIdConnectOptions options, IConfiguration configuration)
    {
        options.Authority = configuration["Idaman:UrlLogin"];
        options.RequireHttpsMetadata = false;
        options.ClientId = configuration["Idaman:ClientId"];
        options.ClientSecret = configuration["Idaman:ClientSecret"];
        options.ResponseType = "code id_token";
        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.Scope.Add("api.auth");
        options.Scope.Add("email");
        options.Scope.Add("user.role");
        options.Scope.Add("user.read");
        options.Scope.Add("offline_access");
    }
} // End Partial class
