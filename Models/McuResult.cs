namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mcuResult
    /// </summary>
    [MaybeNull]
    public static McuResult mcuResult
    {
        get => HttpData.Resolve<McuResult>("McuResult");
        set => HttpData["McuResult"] = value;
    }

    /// <summary>
    /// Table class for McuResult
    /// </summary>
    public class McuResult : DbTable, IQueryFactory
    {
        public int RowCount = 0; // DN

        public bool UseSessionForListSql = true;

        // Column CSS classes
        public string LeftColumnClass = "col-sm-2 col-form-label ew-label";

        public string RightColumnClass = "col-sm-10";

        public string OffsetColumnClass = "col-sm-10 offset-sm-2";

        public string TableLeftColumnClass = "w-col-2";

        // Ajax / Modal
        public bool UseAjaxActions = false;

        public bool ModalSearch = false;

        public bool ModalView = false;

        public bool ModalAdd = false;

        public bool ModalEdit = false;

        public bool ModalUpdate = false;

        public bool InlineDelete = false;

        public bool ModalGridAdd = false;

        public bool ModalGridEdit = false;

        public bool ModalMultiEdit = false;

        public readonly DbField<SqlDbType> McuResult_ID;

        public readonly DbField<SqlDbType> MTCrew_ID;

        public readonly DbField<SqlDbType> IndividualCodeNumber;

        public readonly DbField<SqlDbType> FullName;

        public readonly DbField<SqlDbType> RequiredPhoto;

        public readonly DbField<SqlDbType> VisaPhoto;

        public readonly DbField<SqlDbType> Gender;

        public readonly DbField<SqlDbType> RankAppliedFor;

        public readonly DbField<SqlDbType> WillAcceptLowRank;

        public readonly DbField<SqlDbType> AvailableFrom;

        public readonly DbField<SqlDbType> AvailableUntil;

        public readonly DbField<SqlDbType> EmployeeStatus;

        public readonly DbField<SqlDbType> McuScheduleDate;

        public readonly DbField<SqlDbType> McuDate;

        public readonly DbField<SqlDbType> McuExpirationDate;

        public readonly DbField<SqlDbType> HealthStatus;

        public readonly DbField<SqlDbType> McuLocation;

        public readonly DbField<SqlDbType> McuAttachment;

        public readonly DbField<SqlDbType> McuRemark;

        public readonly DbField<SqlDbType> CreatedBy;

        public readonly DbField<SqlDbType> CreatedDateTime;

        public readonly DbField<SqlDbType> LastUpdatedBy;

        public readonly DbField<SqlDbType> LastUpdatedDateTime;

        public readonly DbField<SqlDbType> MTUserID;

        // Constructor
        public McuResult()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "McuResult";
            Name = "McuResult";
            Type = "VIEW";
            UpdateTable = "dbo.McuResult"; // Update Table
            DbId = "DB"; // DN
            ExportAll = true;
            ExportPageBreakCount = 0; // Page break per every n record (PDF only)
            ExportPageOrientation = "portrait"; // Page orientation (PDF only)
            ExportPageSize = "a4"; // Page size (PDF only)
            ExportColumnWidths = new float[] {  }; // Column widths (PDF only) // DN
            ExportExcelPageOrientation = "Portrait"; // Page orientation (EPPlus only)
            ExportExcelPageSize = "A4"; // Page size (EPPlus only)
            ExportWordPageOrientation = ""; // Page orientation (Word only)
            DetailAdd = false; // Allow detail add
            DetailEdit = false; // Allow detail edit
            DetailView = false; // Allow detail view
            ShowMultipleDetails = false; // Show multiple details
            GridAddRowCount = 5;
            AllowAddDeleteRow = true; // Allow add/delete row
            UseAjaxActions = UseAjaxActions || Config.UseAjaxActions;
            UserIdAllowSecurity = Config.DefaultUserIdAllowSecurity; // User ID Allow

            // McuResult_ID
            McuResult_ID = new (this, "x_McuResult_ID", 3, SqlDbType.Int) {
                Name = "McuResult_ID",
                Expression = "[McuResult_ID]",
                BasicSearchExpression = "CAST([McuResult_ID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[McuResult_ID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "NO",
                InputTextType = "text",
                IsPrimaryKey = true, // Primary key field
                Nullable = false, // NOT NULL field
                Sortable = false, // Allow sort
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN" },
                CustomMessage = Language.FieldPhrase("McuResult", "McuResult_ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("McuResult_ID", McuResult_ID);

            // MTCrew_ID
            MTCrew_ID = new (this, "x_MTCrew_ID", 3, SqlDbType.Int) {
                Name = "MTCrew_ID",
                Expression = "[MTCrew_ID]",
                BasicSearchExpression = "CAST([MTCrew_ID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[MTCrew_ID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN" },
                CustomMessage = Language.FieldPhrase("McuResult", "MTCrew_ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MTCrew_ID", MTCrew_ID);

            // IndividualCodeNumber
            IndividualCodeNumber = new (this, "x_IndividualCodeNumber", 202, SqlDbType.NVarChar) {
                Name = "IndividualCodeNumber",
                Expression = "[IndividualCodeNumber]",
                UseBasicSearch = true,
                BasicSearchExpression = "[IndividualCodeNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[IndividualCodeNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Required = true, // Required field
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "IndividualCodeNumber", "CustomMsg"),
                IsUpload = false
            };
            IndividualCodeNumber.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("IndividualCodeNumber", "McuResult", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("IndividualCodeNumber", "McuResult", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("IndividualCodeNumber", "McuResult", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("IndividualCodeNumber", IndividualCodeNumber);

            // FullName
            FullName = new (this, "x_FullName", 202, SqlDbType.NVarChar) {
                Name = "FullName",
                Expression = "[FullName]",
                UseBasicSearch = true,
                BasicSearchExpression = "[FullName]",
                DateTimeFormat = -1,
                VirtualExpression = "[FullName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "FullName", "CustomMsg"),
                IsUpload = false
            };
            FullName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FullName", "McuResult", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("FullName", "McuResult", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("FullName", "McuResult", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("FullName", FullName);

            // RequiredPhoto
            RequiredPhoto = new (this, "x_RequiredPhoto", 202, SqlDbType.NVarChar) {
                Name = "RequiredPhoto",
                Expression = "[RequiredPhoto]",
                BasicSearchExpression = "[RequiredPhoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[RequiredPhoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                ImageResize = true,
                UploadAllowedFileExtensions = "jpeg,png,jpg",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "RequiredPhoto", "CustomMsg"),
                IsUpload = true
            };
            RequiredPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("RequiredPhoto", "McuResult", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("RequiredPhoto", "McuResult", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("RequiredPhoto", "McuResult", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            RequiredPhoto.GetUploadPath = () => "uploads/" + IndividualCodeNumber.DbValue;
            Fields.Add("RequiredPhoto", RequiredPhoto);

            // VisaPhoto
            VisaPhoto = new (this, "x_VisaPhoto", 202, SqlDbType.NVarChar) {
                Name = "VisaPhoto",
                Expression = "[VisaPhoto]",
                BasicSearchExpression = "[VisaPhoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[VisaPhoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                ImageResize = true,
                UploadAllowedFileExtensions = "jpeg,png,jpg",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "VisaPhoto", "CustomMsg"),
                IsUpload = true
            };
            VisaPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("VisaPhoto", "McuResult", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("VisaPhoto", "McuResult", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("VisaPhoto", "McuResult", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            VisaPhoto.GetUploadPath = () => "uploads/" + IndividualCodeNumber.DbValue;
            Fields.Add("VisaPhoto", VisaPhoto);

            // Gender
            Gender = new (this, "x_Gender", 202, SqlDbType.NVarChar) {
                Name = "Gender",
                Expression = "[Gender]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Gender]",
                DateTimeFormat = -1,
                VirtualExpression = "[Gender]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "Gender", "CustomMsg"),
                IsUpload = false
            };
            Gender.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Gender", "McuResult", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Gender", "McuResult", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Gender", "McuResult", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Gender", Gender);

            // RankAppliedFor
            RankAppliedFor = new (this, "x_RankAppliedFor", 202, SqlDbType.NVarChar) {
                Name = "RankAppliedFor",
                Expression = "[RankAppliedFor]",
                UseBasicSearch = true,
                BasicSearchExpression = "[RankAppliedFor]",
                DateTimeFormat = -1,
                VirtualExpression = "[RankAppliedFor]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY" },
                CustomMessage = Language.FieldPhrase("McuResult", "RankAppliedFor", "CustomMsg"),
                IsUpload = false
            };
            RankAppliedFor.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("RankAppliedFor", "MTRank", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("RankAppliedFor", "MTRank", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("RankAppliedFor", "MTRank", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("RankAppliedFor", RankAppliedFor);

            // WillAcceptLowRank
            WillAcceptLowRank = new (this, "x_WillAcceptLowRank", 11, SqlDbType.Bit) {
                Name = "WillAcceptLowRank",
                Expression = "[WillAcceptLowRank]",
                BasicSearchExpression = "[WillAcceptLowRank]",
                DateTimeFormat = -1,
                VirtualExpression = "[WillAcceptLowRank]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                UseFilter = true, // Table header filter
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "WillAcceptLowRank", "CustomMsg"),
                IsUpload = false
            };
            WillAcceptLowRank.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("WillAcceptLowRank", "McuResult", true, "WillAcceptLowRank", new List<string> {"WillAcceptLowRank", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("WillAcceptLowRank", "McuResult", true, "WillAcceptLowRank", new List<string> {"WillAcceptLowRank", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("WillAcceptLowRank", "McuResult", true, "WillAcceptLowRank", new List<string> {"WillAcceptLowRank", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("WillAcceptLowRank", WillAcceptLowRank);

            // AvailableFrom
            AvailableFrom = new (this, "x_AvailableFrom", 133, SqlDbType.DateTime) {
                Name = "AvailableFrom",
                Expression = "[AvailableFrom]",
                BasicSearchExpression = CastDateFieldForLike("[AvailableFrom]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[AvailableFrom]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "AvailableFrom", "CustomMsg"),
                IsUpload = false
            };
            AvailableFrom.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("AvailableFrom", "McuResult", true, "AvailableFrom", new List<string> {"AvailableFrom", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("AvailableFrom", "McuResult", true, "AvailableFrom", new List<string> {"AvailableFrom", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("AvailableFrom", "McuResult", true, "AvailableFrom", new List<string> {"AvailableFrom", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("AvailableFrom", AvailableFrom);

            // AvailableUntil
            AvailableUntil = new (this, "x_AvailableUntil", 133, SqlDbType.DateTime) {
                Name = "AvailableUntil",
                Expression = "[AvailableUntil]",
                BasicSearchExpression = CastDateFieldForLike("[AvailableUntil]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[AvailableUntil]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "AvailableUntil", "CustomMsg"),
                IsUpload = false
            };
            AvailableUntil.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("AvailableUntil", "McuResult", true, "AvailableUntil", new List<string> {"AvailableUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("AvailableUntil", "McuResult", true, "AvailableUntil", new List<string> {"AvailableUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("AvailableUntil", "McuResult", true, "AvailableUntil", new List<string> {"AvailableUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("AvailableUntil", AvailableUntil);

            // EmployeeStatus
            EmployeeStatus = new (this, "x_EmployeeStatus", 202, SqlDbType.NVarChar) {
                Name = "EmployeeStatus",
                Expression = "[EmployeeStatus]",
                BasicSearchExpression = "[EmployeeStatus]",
                DateTimeFormat = -1,
                VirtualExpression = "[EmployeeStatus]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "EmployeeStatus", "CustomMsg"),
                IsUpload = false
            };
            EmployeeStatus.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("EmployeeStatus", "McuResult", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("EmployeeStatus", "McuResult", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("EmployeeStatus", "McuResult", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("EmployeeStatus", EmployeeStatus);

            // McuScheduleDate
            McuScheduleDate = new (this, "x_McuScheduleDate", 146, SqlDbType.DateTimeOffset) {
                Name = "McuScheduleDate",
                Expression = "[McuScheduleDate]",
                BasicSearchExpression = CastDateFieldForLike("[McuScheduleDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[McuScheduleDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "McuScheduleDate", "CustomMsg"),
                IsUpload = false
            };
            McuScheduleDate.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("McuScheduleDate", "McuResult", true, "McuScheduleDate", new List<string> {"McuScheduleDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("McuScheduleDate", "McuResult", true, "McuScheduleDate", new List<string> {"McuScheduleDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("McuScheduleDate", "McuResult", true, "McuScheduleDate", new List<string> {"McuScheduleDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("McuScheduleDate", McuScheduleDate);

            // McuDate
            McuDate = new (this, "x_McuDate", 146, SqlDbType.DateTimeOffset) {
                Name = "McuDate",
                Expression = "[McuDate]",
                BasicSearchExpression = CastDateFieldForLike("[McuDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[McuDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "McuDate", "CustomMsg"),
                IsUpload = false
            };
            McuDate.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("McuDate", "McuResult", true, "McuDate", new List<string> {"McuDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("McuDate", "McuResult", true, "McuDate", new List<string> {"McuDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("McuDate", "McuResult", true, "McuDate", new List<string> {"McuDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("McuDate", McuDate);

            // McuExpirationDate
            McuExpirationDate = new (this, "x_McuExpirationDate", 146, SqlDbType.DateTimeOffset) {
                Name = "McuExpirationDate",
                Expression = "[McuExpirationDate]",
                BasicSearchExpression = CastDateFieldForLike("[McuExpirationDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[McuExpirationDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "McuExpirationDate", "CustomMsg"),
                IsUpload = false
            };
            McuExpirationDate.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("McuExpirationDate", "McuResult", true, "McuExpirationDate", new List<string> {"McuExpirationDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("McuExpirationDate", "McuResult", true, "McuExpirationDate", new List<string> {"McuExpirationDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("McuExpirationDate", "McuResult", true, "McuExpirationDate", new List<string> {"McuExpirationDate", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("McuExpirationDate", McuExpirationDate);

            // HealthStatus
            HealthStatus = new (this, "x_HealthStatus", 202, SqlDbType.NVarChar) {
                Name = "HealthStatus",
                Expression = "[HealthStatus]",
                UseBasicSearch = true,
                BasicSearchExpression = "[HealthStatus]",
                DateTimeFormat = -1,
                VirtualExpression = "[HealthStatus]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "HealthStatus", "CustomMsg"),
                IsUpload = false
            };
            HealthStatus.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("HealthStatus", "McuResult", true, "HealthStatus", new List<string> {"HealthStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("HealthStatus", "McuResult", true, "HealthStatus", new List<string> {"HealthStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("HealthStatus", "McuResult", true, "HealthStatus", new List<string> {"HealthStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("HealthStatus", HealthStatus);

            // McuLocation
            McuLocation = new (this, "x_McuLocation", 202, SqlDbType.NVarChar) {
                Name = "McuLocation",
                Expression = "[McuLocation]",
                UseBasicSearch = true,
                BasicSearchExpression = "[McuLocation]",
                DateTimeFormat = -1,
                VirtualExpression = "[McuLocation]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "McuLocation", "CustomMsg"),
                IsUpload = false
            };
            McuLocation.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("McuLocation", "McuResult", true, "McuLocation", new List<string> {"McuLocation", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("McuLocation", "McuResult", true, "McuLocation", new List<string> {"McuLocation", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("McuLocation", "McuResult", true, "McuLocation", new List<string> {"McuLocation", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("McuLocation", McuLocation);

            // McuAttachment
            McuAttachment = new (this, "x_McuAttachment", 202, SqlDbType.NVarChar) {
                Name = "McuAttachment",
                Expression = "[McuAttachment]",
                BasicSearchExpression = "[McuAttachment]",
                DateTimeFormat = -1,
                VirtualExpression = "[McuAttachment]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "McuAttachment", "CustomMsg"),
                IsUpload = true
            };
            McuAttachment.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("McuAttachment", "McuResult", true, "McuAttachment", new List<string> {"McuAttachment", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("McuAttachment", "McuResult", true, "McuAttachment", new List<string> {"McuAttachment", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("McuAttachment", "McuResult", true, "McuAttachment", new List<string> {"McuAttachment", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("McuAttachment", McuAttachment);

            // McuRemark
            McuRemark = new (this, "x_McuRemark", 202, SqlDbType.NVarChar) {
                Name = "McuRemark",
                Expression = "[McuRemark]",
                UseBasicSearch = true,
                BasicSearchExpression = "[McuRemark]",
                DateTimeFormat = -1,
                VirtualExpression = "[McuRemark]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "McuRemark", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("McuRemark", McuRemark);

            // CreatedBy
            CreatedBy = new (this, "x_CreatedBy", 202, SqlDbType.NVarChar) {
                Name = "CreatedBy",
                Expression = "[CreatedBy]",
                BasicSearchExpression = "[CreatedBy]",
                DateTimeFormat = -1,
                VirtualExpression = "[CreatedBy]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY" },
                CustomMessage = Language.FieldPhrase("McuResult", "CreatedBy", "CustomMsg"),
                IsUpload = false
            };
            CreatedBy.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedBy", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]"),
                "id-ID" => new Lookup<DbField>("CreatedBy", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]"),
                _ => new Lookup<DbField>("CreatedBy", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]")
            };
            Fields.Add("CreatedBy", CreatedBy);

            // CreatedDateTime
            CreatedDateTime = new (this, "x_CreatedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "CreatedDateTime",
                Expression = "[CreatedDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[CreatedDateTime]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[CreatedDateTime]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "CreatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            CreatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedDateTime", "McuResult", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CreatedDateTime", "McuResult", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CreatedDateTime", "McuResult", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CreatedDateTime", CreatedDateTime);

            // LastUpdatedBy
            LastUpdatedBy = new (this, "x_LastUpdatedBy", 202, SqlDbType.NVarChar) {
                Name = "LastUpdatedBy",
                Expression = "[LastUpdatedBy]",
                BasicSearchExpression = "[LastUpdatedBy]",
                DateTimeFormat = -1,
                VirtualExpression = "[LastUpdatedBy]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY" },
                CustomMessage = Language.FieldPhrase("McuResult", "LastUpdatedBy", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedBy.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedBy", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]"),
                "id-ID" => new Lookup<DbField>("LastUpdatedBy", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]"),
                _ => new Lookup<DbField>("LastUpdatedBy", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]")
            };
            Fields.Add("LastUpdatedBy", LastUpdatedBy);

            // LastUpdatedDateTime
            LastUpdatedDateTime = new (this, "x_LastUpdatedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "LastUpdatedDateTime",
                Expression = "[LastUpdatedDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[LastUpdatedDateTime]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[LastUpdatedDateTime]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "LastUpdatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedDateTime", "McuResult", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedDateTime", "McuResult", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedDateTime", "McuResult", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("LastUpdatedDateTime", LastUpdatedDateTime);

            // MTUserID
            MTUserID = new (this, "x_MTUserID", 3, SqlDbType.Int) {
                Name = "MTUserID",
                Expression = "[MTUserID]",
                BasicSearchExpression = "CAST([MTUserID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[MTUserID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("McuResult", "MTUserID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MTUserID", MTUserID);

            // Call Table Load event
            TableLoad();
        }

        // Set Field Visibility
        public override bool GetFieldVisibility(string fldname)
        {
            var fld = FieldByName(fldname);
            return fld?.Visible ?? false; // Returns original value
        }

        // Invoke method // DN
        public object? Invoke(string name, object?[]? parameters = null)
        {
            var mi = this.GetType().GetMethod(name);
            if (mi != null)
                return IsAsyncMethod(mi)
                    ? InvokeAsync(mi, parameters).GetAwaiter().GetResult()
                    : mi.Invoke(this, parameters);
            return null;
        }

        // Invoke async method // DN
        public async Task<object?> InvokeAsync(MethodInfo? mi, object?[]? parameters = null)
        {
            if (mi != null) {
                dynamic? awaitable = mi.Invoke(this, parameters);
                if (awaitable != null) {
                    await awaitable;
                    return awaitable.GetAwaiter().GetResult();
                }
            }
            return null;
        }

        #pragma warning disable 1998
        // Invoke async method // DN
        public async Task<object> InvokeAsync(string name, object[]? parameters = null) => InvokeAsync(this.GetType().GetMethod(name), parameters);
        #pragma warning restore 1998

        // Check if Invoke async method // DN
        public bool IsAsyncMethod(MethodInfo? mi)
        {
            if (mi != null) {
                Type attType = typeof(AsyncStateMachineAttribute);
                return mi.GetCustomAttribute(attType) is AsyncStateMachineAttribute;
            }
            return false;
        }

        // Check if Invoke async method // DN
        public bool IsAsyncMethod(string name) => IsAsyncMethod(this.GetType().GetMethod(name));

        #pragma warning disable 618
        // Connection
        public virtual DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType> Connection => GetConnection(DbId);
        #pragma warning restore 618

        // Get query factory
        public QueryFactory GetQueryFactory(bool main) => Connection.GetQueryFactory(main);

        // Get query builder
        public QueryBuilder GetQueryBuilder(bool main, string output = "")
        {
            var qf = GetQueryFactory(main);
            var qb = (XQuery)qf.Query(UpdateTable);
            if (output != "")
                qb.Compiler = Connection.GetCompiler(output); // Replace the compiler
            return qb;
        }

        // Get query builder with output Id (use secondary connection)
        public QueryBuilder GetQueryBuilder(string output) => GetQueryBuilder(false, output);

        // Get query builder without output Id (use secondary connection)
        public QueryBuilder GetQueryBuilder() => GetQueryBuilder(false);

        // Set left column class (must be predefined col-*-* classes of Bootstrap grid system)
        public void SetLeftColumnClass(string columnClass)
        {
            Match m = Regex.Match(columnClass, @"^col\-(\w+)\-(\d+)$");
            if (m.Success) {
                LeftColumnClass = columnClass + " col-form-label ew-label";
                RightColumnClass = "col-" + m.Groups[1].Value + "-" + ConvertToString(12 - ConvertToInt(m.Groups[2].Value));
                OffsetColumnClass = RightColumnClass + " " + columnClass.Replace("col-", "offset-");
                TableLeftColumnClass = Regex.Replace(columnClass, @"/^col-\w+-(\d+)$/", "w-col-$1"); // Change to w-col-*
            }
        }

        // Multiple column sort
        public void UpdateSort(DbField fld, bool ctrl)
        {
            string sortField, lastSort, curSort, orderBy, lastOrderBy, curOrderBy;
            if (CurrentOrder == fld.Name) {
                sortField = fld.Expression;
                lastSort = fld.Sort;
                if ((new[] { "ASC", "DESC", "NO" }).Contains(CurrentOrderType)) {
                    curSort = CurrentOrderType;
                } else {
                    curSort = lastSort;
                }
                lastOrderBy = (new[] { "ASC", "DESC" }).Contains(lastSort) ? sortField + " " + lastSort : "";
                curOrderBy = (new[] { "ASC", "DESC" }).Contains(curSort) ? sortField + " " + curSort : "";
                if (ctrl) {
                    orderBy = SessionOrderBy;
                    List<string> listOrderBy = !Empty(orderBy) ? orderBy.Split(new string[] { ", " }, StringSplitOptions.None).ToList() : new ();
                    if (!Empty(lastOrderBy) && listOrderBy.Contains(lastOrderBy)) {
                        if (Empty(curOrderBy)) {
                            listOrderBy.Remove(lastOrderBy);
                        } else {
                            var index = listOrderBy.IndexOf(lastOrderBy);
                            listOrderBy[index] = curOrderBy;
                        }
                    } else if (!Empty(curOrderBy)) {
                        listOrderBy.Add(curOrderBy);
                    }
                    orderBy = String.Join(", ", listOrderBy);
                    SessionOrderBy = orderBy; // Save to Session
                } else {
                    SessionOrderBy = curOrderBy; // Save to Session
                }
            }
        }

        // Update field sort
        public void UpdateFieldSort()
        {
            string orderBy = SessionOrderBy; // Get ORDER BY from Session
            var flds = GetSortFields(orderBy);
            foreach (var (key, field) in Fields) {
                string fldSort = "";
                foreach (var fld in flds) {
                    if (fld[0] == field.Expression || fld[0] == field.VirtualExpression)
                        fldSort = fld[1];
                }
                field.Sort = fldSort;
            }
        }

        #pragma warning disable 1998
        // Render X Axis for chart
        public async Task<Dictionary<string, object>> RenderChartXAxis(string chartVar, Dictionary<string, object> chartRow)
        {
            return chartRow;
        }
        #pragma warning restore 1998

        // Table level SQL
        // FROM
        private string? _sqlFrom = null;

        public string SqlFrom
        {
            get => _sqlFrom ?? "dbo.McuResult";
            set => _sqlFrom = value;
        }

        // SELECT
        private string? _sqlSelect = null;

        public string SqlSelect { // Select
            get => _sqlSelect ?? "SELECT * FROM " + SqlFrom;
            set => _sqlSelect = value;
        }

        // WHERE // DN
        private string? _sqlWhere = null;

        public string SqlWhere
        {
            get {
                string where = "";
                return _sqlWhere ?? where;
            }
            set {
                _sqlWhere = value;
            }
        }

        // Group By
        private string? _sqlGroupBy = null;

        public string SqlGroupBy
        {
            get => _sqlGroupBy ?? "";
            set => _sqlGroupBy = value;
        }

        // Having
        private string? _sqlHaving = null;

        public string SqlHaving
        {
            get => _sqlHaving ?? "";
            set => _sqlHaving = value;
        }

        // Order By
        private string? _sqlOrderBy = null;

        public string SqlOrderBy
        {
            get => _sqlOrderBy ?? "";
            set => _sqlOrderBy = value;
        }

        // Apply User ID filters
        public string ApplyUserIDFilters(string filter, string id = "")
        {
            return filter;
        }

        // Check if User ID security allows view all
        public bool UserIDAllow(string id = "")
        {
            int allow = UserIdAllowSecurity;
            return id switch {
                "add" => ((allow & 1) == 1),
                "copy" => ((allow & 1) == 1),
                "gridadd" => ((allow & 1) == 1),
                "register" => ((allow & 1) == 1),
                "addopt" => ((allow & 1) == 1),
                "edit" => ((allow & 4) == 4),
                "gridedit" => ((allow & 4) == 4),
                "update" => ((allow & 4) == 4),
                "changepassword" => ((allow & 4) == 4),
                "resetpassword" => ((allow & 4) == 4),
                "delete" => ((allow & 2) == 2),
                "view" => ((allow & 32) == 32),
                "search" => ((allow & 64) == 64),
                "lookup" => ((allow & 256) == 256),
                _ => ((allow & 8) == 8)
            };
        }

        /// <summary>
        /// Get record count by reading data reader (Async) // DN
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="c">Connection</param>
        /// <returns>Record count</returns>
        public async Task<int> GetRecordCountAsync(string sql, dynamic? c = null) {
            try {
                var cnt = 0;
                var conn = c ?? Connection;
                using var dr = await conn.OpenDataReaderAsync(sql);
                if (dr != null) {
                    while (await dr.ReadAsync())
                        cnt++;
                }
                return cnt;
            } catch {
                if (Config.Debug)
                    throw;
                return -1;
            }
        }

        /// <summary>
        /// Get record count by reading data reader // DN
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="c">Connection</param>
        /// <returns>Record count</returns>
        public int GetRecordCount(string sql, dynamic? c = null) => GetRecordCountAsync(sql, c).GetAwaiter().GetResult();

        /// <summary>
        /// Try to get record count by SELECT COUNT(*) (Async) // DN
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="c">Connection</param>
        /// <returns>Record count</returns>
        public async Task<int> TryGetRecordCountAsync(string sql, dynamic? c = null)
        {
            string orderBy = OrderBy;
            var conn = c ?? Connection;
            sql = Regex.Replace(sql, @"/\*BeginOrderBy\*/[\s\S]+/\*EndOrderBy\*/", "", RegexOptions.IgnoreCase).Trim(); // Remove ORDER BY clause (MSSQL)
            if (!Empty(orderBy) && sql.EndsWith(orderBy))
                sql = sql.Substring(0, sql.Length - orderBy.Length); // Remove ORDER BY clause
            try {
                string sqlcnt;
                if ((new[] { "TABLE", "VIEW", "LINKTABLE" }).Contains(Type) && sql.StartsWith(SqlSelect)) { // Handle Custom Field
                    sqlcnt = "SELECT COUNT(*) FROM " + SqlFrom + sql.Substring(SqlSelect.Length);
                } else {
                    sqlcnt = "SELECT COUNT(*) FROM (" + sql + ") EW_COUNT_TABLE";
                }
                return Convert.ToInt32(await conn?.ExecuteScalarAsync(sqlcnt));
            } catch {
                return await GetRecordCountAsync(sql, conn);
            }
        }

        /// <summary>
        /// Try to get record count by SELECT COUNT(*) // DN
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="c">Connection</param>
        /// <returns>Record count</returns>
        public int TryGetRecordCount(string sql, dynamic? c = null) => TryGetRecordCountAsync(sql, c).GetAwaiter().GetResult();

        // Get SQL
        public string GetSql(string where, string orderBy = "") => BuildSelectSql(SqlSelect, SqlWhere, SqlGroupBy, SqlHaving, SqlOrderBy, where, orderBy);

        // Table SQL
        public string CurrentSql
        {
            get {
                string filter = CurrentFilter;
                filter = ApplyUserIDFilters(filter); // Add User ID filter
                string sort = SessionOrderBy;
                return GetSql(filter, sort);
            }
        }

        // Table SQL with List page filter
        public string ListSql
        {
            get {
                string sort = "";
                string select = "";
                string filter = UseSessionForListSql ? SessionWhere : "";
                AddFilter(ref filter, CurrentFilter);
                RecordsetSelecting(ref filter);
                filter = ApplyUserIDFilters(filter); // Add User ID filter
                select = SqlSelect;
                sort = UseSessionForListSql ? SessionOrderBy : "";
                return BuildSelectSql(select, SqlWhere, SqlGroupBy, SqlHaving, SqlOrderBy, filter, sort);
            }
        }

        // Get ORDER BY clause
        public string OrderBy
        {
            get {
                string sort = SessionOrderBy;
                return BuildSelectSql("", "", "", "", SqlOrderBy, "", sort);
            }
        }

        /// <summary>
        /// Get record count based on filter (for detail record count in master table pages) (Async) // DN
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Record count</returns>
        public async Task<int> LoadRecordCountAsync(string filter) => await TryGetRecordCountAsync(GetSql(filter));

        /// <summary>
        /// Get record count based on filter (for detail record count in master table pages) // DN
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Record count</returns>
        public int LoadRecordCount(string filter) => TryGetRecordCount(GetSql(filter));

        /// <summary>
        /// Get record count (for current List page) (Async) // DN
        /// </summary>
        /// <returns>Record count</returns>
        public async Task<int> ListRecordCountAsync() => await TryGetRecordCountAsync(ListSql);

        /// <summary>
        /// Get record count (for current List page) // DN
        /// </summary>
        /// <returns>Record count</returns>
        public int ListRecordCount() => TryGetRecordCount(ListSql);

        /// <summary>
        /// Insert (Async)
        /// </summary>
        /// <param name="data">Data to be inserted (IDictionary|Anonymous)</param>
        /// <returns>Row affected</returns>
        public async Task<int> InsertAsync(object data)
        {
            int result = 0;
            IDictionary<string, object> row;
            if (data is IDictionary<string, object> d)
                row = d;
            else if (IsAnonymousType(data))
                row = ConvertToDictionary<object>(data);
            else
                throw new ArgumentException("Data must be of anonymous type or Dictionary<string, object> type", "data");
            row = row.Where(kvp => {
                var fld = FieldByName(kvp.Key);
                return fld != null && !fld.IsCustom;
            }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            try {
                result = await queryBuilder.InsertAsync(row);
            } catch (Exception e) {
                CurrentPage?.SetFailureMessage(e.Message);
                if (Config.Debug)
                    throw;
            }
            return result;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="data">Data to be inserted (IDictionary|Anonymous)</param>
        /// <returns>Row affected</returns>
        public int Insert(object data) => InsertAsync(data).GetAwaiter().GetResult();

        /// <summary>
        /// Update (Async)
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <returns>Row affected</returns>
        public async Task<int> UpdateAsync(object data)
        {
            IDictionary<string, object> row;
            if (data is IDictionary<string, object> d)
                row = d;
            else if (IsAnonymousType(data))
                row = ConvertToDictionary<object>(data);
            else
                throw new ArgumentException("Data must be of anonymous type or Dictionary<string, object> type", "data");
            var where = GetRowFilterAsDictionary(row);
            return where != null ? await UpdateAsync(row, where) : -1; // Prevent update all record
        }

        /// <summary>
        /// Update (Async)
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <returns>Row affected</returns>
        public async Task<int> UpdateAsync(object data, object? where) => await UpdateAsync(data, where, null);

        #pragma warning disable 168, 219
        /// <summary>
        /// Update (Async)
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous)</param>
        /// <param name="rsold">Old record</param>
        /// <returns>Row affected</returns>
        public async Task<int> UpdateAsync(object data, object? where, Dictionary<string, object>? rsold)
        {
            int result = -1;
            IDictionary<string, object> row;
            if (data is IDictionary<string, object> d)
                row = d;
            else if (IsAnonymousType(data))
                row = ConvertToDictionary<object>(data);
            else
                throw new ArgumentException("Data must be of anonymous type or Dictionary<string, object> type", "data");
            Dictionary<string, object> rscascade = new ();
            row = row.Where(kvp => FieldByName(kvp.Key) is DbField fld && !fld.IsCustom).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            if (row.Count == 0)
                return -1;
            var queryBuilder = GetQueryBuilder();
            string filter = CurrentFilter;
            if (!Empty(filter))
                queryBuilder.WhereRaw(filter);
            if (IsAnonymousType(where))
                queryBuilder.Where(where);
            else if (where is IDictionary<string, object> dict)
                queryBuilder.Where(dict);
            else if (where is string)
                queryBuilder.WhereRaw((string)where);
            if (rsold != null && GetRowFilterAsDictionary(rsold) is IDictionary<string, object> rsoldFilter) // Add filter from old record
                queryBuilder.Where(rsoldFilter);
            if (queryBuilder.HasComponent("where")) // Prevent update all records
                result = await queryBuilder.UpdateAsync(row);
            return result;
        }
        #pragma warning restore 168, 219

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <returns>Row affected</returns>
        public int Update(object data) => UpdateAsync(data).GetAwaiter().GetResult();

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <returns>Row affected</returns>
        public int Update(object data, object where) => UpdateAsync(data, where).GetAwaiter().GetResult();

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="data">Data to be updated (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <param name="rsold">Old record</param>
        /// <returns>Row affected</returns>
        public int Update(object data, object where, Dictionary<string, object> rsold) => UpdateAsync(data, where, rsold).GetAwaiter().GetResult();

        #pragma warning disable 168, 1998
        /// <summary>
        /// Delete (Async)
        /// </summary>
        /// <param name="data">Data to be removed (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <returns>Row affected</returns>
        public async Task<int> DeleteAsync(object? data, object? where = null)
        {
            bool delete = true;
            IDictionary<string, object>? row = null;
            if (data is IDictionary<string, object> d)
                row = d;
            else if (IsAnonymousType(data))
                row = ConvertToDictionary<object>(data);
            var queryBuilder = GetQueryBuilder(true); // Use main connection
            if (GetRowFilterAsDictionary(row) is IDictionary<string, object> rowFilter)
                queryBuilder.Where(rowFilter);
            if (IsAnonymousType(where))
                queryBuilder.Where(where);
            else if (where is IDictionary<string, object> dict)
                queryBuilder.Where(dict);
            else if (where is string)
                queryBuilder.WhereRaw((string)where);
            int result = delete && queryBuilder.HasComponent("where") // Avoid delete if no WHERE clause
                ? await queryBuilder.DeleteAsync(Connection.Transaction)
                : -1;
            return result;
        }
        #pragma warning restore 168, 1998

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="data">Data to be removed (IDictionary|Anonymous)</param>
        /// <param name="where">Where (IDictionary|Anonymous|string)</param>
        /// <returns>Row affected</returns>
        public int Delete(object data, object? where = null) => DeleteAsync(data, where).GetAwaiter().GetResult();

        // Load DbValue from recordset
        public void LoadDbValues(Dictionary<string, object>? row)
        {
            if (row == null)
                return;
            try {
                McuResult_ID.DbValue = row["McuResult_ID"]; // Set DB value only
                MTCrew_ID.DbValue = row["MTCrew_ID"]; // Set DB value only
                IndividualCodeNumber.DbValue = row["IndividualCodeNumber"]; // Set DB value only
                FullName.DbValue = row["FullName"]; // Set DB value only
                RequiredPhoto.Upload.DbValue = row["RequiredPhoto"];
                VisaPhoto.Upload.DbValue = row["VisaPhoto"];
                Gender.DbValue = row["Gender"]; // Set DB value only
                RankAppliedFor.DbValue = row["RankAppliedFor"]; // Set DB value only
                WillAcceptLowRank.DbValue = (ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"); // Set DB value only
                AvailableFrom.DbValue = row["AvailableFrom"]; // Set DB value only
                AvailableUntil.DbValue = row["AvailableUntil"]; // Set DB value only
                EmployeeStatus.DbValue = row["EmployeeStatus"]; // Set DB value only
                McuScheduleDate.DbValue = row["McuScheduleDate"]; // Set DB value only
                McuDate.DbValue = row["McuDate"]; // Set DB value only
                McuExpirationDate.DbValue = row["McuExpirationDate"]; // Set DB value only
                HealthStatus.DbValue = row["HealthStatus"]; // Set DB value only
                McuLocation.DbValue = row["McuLocation"]; // Set DB value only
                McuAttachment.Upload.DbValue = row["McuAttachment"];
                McuRemark.DbValue = row["McuRemark"]; // Set DB value only
                CreatedBy.DbValue = row["CreatedBy"]; // Set DB value only
                CreatedDateTime.DbValue = row["CreatedDateTime"]; // Set DB value only
                LastUpdatedBy.DbValue = row["LastUpdatedBy"]; // Set DB value only
                LastUpdatedDateTime.DbValue = row["LastUpdatedDateTime"]; // Set DB value only
                MTUserID.DbValue = row["MTUserID"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
            RequiredPhoto.OldUploadPath = RequiredPhoto.GetUploadPath();
            if (!Empty(row["RequiredPhoto"])) {
                DeleteFile(RequiredPhoto.OldPhysicalUploadPath + row["RequiredPhoto"]);
            }
            VisaPhoto.OldUploadPath = VisaPhoto.GetUploadPath();
            if (!Empty(row["VisaPhoto"])) {
                DeleteFile(VisaPhoto.OldPhysicalUploadPath + row["VisaPhoto"]);
            }
            if (!Empty(row["McuAttachment"])) {
                DeleteFile(McuAttachment.OldPhysicalUploadPath + row["McuAttachment"]);
            }
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[McuResult_ID] = @McuResult_ID@";

        #pragma warning disable 168, 219
        // Get record filter as string
        public string GetRecordFilter(Dictionary<string, object>? row = null, bool current = false)
        {
            string keyFilter = _sqlKeyFilter;
            object? val = null, result = "";
            val = row?.TryGetValue("McuResult_ID", out result) ?? false
                ? result
                : !Empty(McuResult_ID.OldValue) && !current ? McuResult_ID.OldValue : McuResult_ID.CurrentValue;
            if (!IsNumeric(val))
                return "0=1"; // Invalid key
            if (val == null)
                return "0=1"; // Invalid key
            keyFilter = keyFilter.Replace("@McuResult_ID@", AdjustSql(val, DbId)); // Replace key value
            return keyFilter;
        }

        // Get record filter as Dictionary // DN
        public Dictionary<string, object>? GetRowFilterAsDictionary(IDictionary<string, object>? row = null)
        {
            Dictionary<string, object>? keyFilter = new ();
            object? val = null, result;
            val = row?.TryGetValue("McuResult_ID", out result) ?? false
                ? result
                : !Empty(McuResult_ID.OldValue) ? McuResult_ID.OldValue : McuResult_ID.CurrentValue;
            if (!IsNumeric(val))
                return null; // Invalid key
            if (Empty(val))
                return null; // Invalid key
            keyFilter.Add("McuResult_ID", val); // Add key value
            return keyFilter.Count > 0 ? keyFilter : null;
        }
        #pragma warning restore 168, 219

        // Return URL
        public string ReturnUrl
        {
            get {
                string name = Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl;
                // Get referer URL automatically
                if (!Empty(ReferUrl()) && !SameText(ReferPage(), CurrentPageName()) &&
                    !SameText(ReferPage(), "login")) {// Referer not same page or login page
                        Session[name] = ReferUrl(); // Save to Session
                }
                if (!Empty(Session[name])) {
                    return Session.GetString(name);
                } else {
                    return "McuResultList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "McuResultView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "McuResultEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "McuResultAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "McuResultList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "McuResultView",
                Config.ApiAddAction => "McuResultAdd",
                Config.ApiEditAction => "McuResultEdit",
                Config.ApiDeleteAction => "McuResultDelete",
                Config.ApiListAction => "McuResultList",
                _ => String.Empty
            };
        }

        // Current URL
        public string GetCurrentUrl(string parm = "")
        {
            string url = CurrentPageName();
            if (!Empty(parm))
                url = KeyUrl(url, parm);
            else
                url = KeyUrl(url, Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // List URL
        public string ListUrl => "McuResultList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("McuResultView", parm);
            else
                url = KeyUrl("McuResultView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "McuResultAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "McuResultAdd?" + parm;
            else
                url = "McuResultAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("McuResultEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("McuResultList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("McuResultAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("McuResultList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("McuResultDelete")); // DN

        // Add master URL
        public string AddMasterUrl(string url)
        {
            return url;
        }

        // Get primary key as JSON
        public string KeyToJson(bool htmlEncode = false)
        {
            string json = "";
            json += "\"McuResult_ID\":" + ConvertToJson(McuResult_ID.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL
        public string KeyUrl(string url, string parm = "") { // DN
            if (!IsNull(McuResult_ID.CurrentValue)) {
                url += "/" + McuResult_ID.CurrentValue;
            } else {
                return "javascript:ew.alert(ew.language.phrase('InvalidRecord'));";
            }
            if (Empty(parm))
                return url;
            else
                return url + "?" + parm;
        }

        // Render sort
        public string RenderFieldHeader(DbField fld)
        {
            string sortUrl = "";
            string attrs = "";
            if (fld.Sortable) {
                sortUrl = SortUrl(fld);
                attrs = " role=\"button\" data-ew-action=\"sort\" data-ajax=\"" + (UseAjaxActions ? "true" : "false") + "\" data-sort-url=\"" + sortUrl + "\" data-sort-type=\"2\"";
                if (!Empty(ContextClass)) // Add context
                    attrs += " data-context=\"" + HtmlEncode(ContextClass) + "\"";
            }
            string html = "<div class=\"ew-table-header-caption\"" + attrs + ">" + fld.Caption + "</div>";
            if (!Empty(sortUrl)) {
                html += "<div class=\"ew-table-header-sort\">" + fld.SortIcon + "</div>";
            }
            if (fld.UseFilter && Security.CanSearch) {
                html += "<div class=\"ew-filter-dropdown-btn\" data-ew-action=\"filter\" data-table=\"" + fld.TableVar + "\" data-field=\"" + fld.FieldVar +
                    "\"><div class=\"ew-table-header-filter\" role=\"button\" aria-haspopup=\"true\">" + Language.Phrase("Filter") + "</div></div>";
            }
            html = "<div class=\"ew-table-header-btn\">" + html + "</div>";
            if (UseCustomTemplate) {
                string scriptId = ("tpc_{id}").Replace("{id}", fld.TableVar + "_" + fld.Param);
                html = "<template id=\"" + scriptId + "\">" + html + "</template>";
            }
            return html;
        }

        // Sort URL (already URL-encoded)
        public string SortUrl(DbField fld)
        {
            if (!Empty(CurrentAction) || !Empty(Export) ||
                (new[] {141, 201, 203, 128, 204, 205}).Contains(fld.Type)) { // Unsortable data type
                return "";
            } else if (fld.Sortable) {
                string urlParm = "order=" + UrlEncode(fld.Name) + "&amp;ordertype=" + fld.NextSort;
                if (DashboardReport)
                    urlParm += "&amp;" + Config.PageDashboard + "=true";
                return AddMasterUrl(CurrentDashboardPageUrl() + "?" + urlParm);
            }
            return "";
        }

        #pragma warning disable 168, 219
        // Get key as string
        public string GetKey(bool current = false)
        {
            List<string> keys = new ();
            string val;
            val = current ? ConvertToString(McuResult_ID.CurrentValue) ?? "" : ConvertToString(McuResult_ID.OldValue) ?? "";
            if (Empty(val))
                return String.Empty;
            keys.Add(val);
            return String.Join(Config.CompositeKeySeparator, keys);
        }

        // Get record filter as string // DN
        public string GetKey(IDictionary<string, object> row)
        {
            List<string> keys = new ();
            object? val = null, result;
            val = row?.TryGetValue("McuResult_ID", out result) ?? false ? ConvertToString(result) : null;
            if (Empty(val))
                return String.Empty; // Invalid key
            keys.Add(ConvertToString(val)); // Add key value
            return String.Join(Config.CompositeKeySeparator, keys);
        }
        #pragma warning restore 168, 219

        // Set key
        public void SetKey(string key, bool current = false)
        {
            OldKey = key;
            string[] keys = OldKey.Split(Convert.ToChar(Config.CompositeKeySeparator));
            if (keys.Length == 1) {
                if (current) {
                    McuResult_ID.CurrentValue = keys[0];
                } else {
                    McuResult_ID.OldValue = keys[0];
                }
            }
        }

        #pragma warning disable 168
        // Get record keys
        public List<string> GetRecordKeys()
        {
            List<string> result = new ();
            StringValues sv;
            List<string> keysList = new ();
            if (Post("key_m[]", out sv) || Get("key_m[]", out sv)) { // DN
                keysList = ((StringValues)sv).Select(k => ConvertToString(k)).ToList();
            } else if (RouteValues.Count > 0 || Query.Count > 0 || Form.Count > 0) { // DN
                string key = "";
                string[] keyValues = {};
                if (IsApi() && RouteValues.TryGetValue("key", out object? k)) {
                    string str = ConvertToString(k);
                    keyValues = str.Split('/');
                }
                if (RouteValues.TryGetValue("McuResult_ID", out object? v0)) { // McuResult_ID // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("McuResult_ID");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (!IsNumeric(keys)) // McuResult_ID
                    continue;
                result.Add(keys);
            }
            return result;
        }
        #pragma warning restore 168

        // Get filter from records
        public string GetFilterFromRecords(IEnumerable<Dictionary<string, object>> rows) =>
            String.Join(" OR ", rows.Select(row => "(" + GetRecordFilter(row) + ")"));

        // Get filter from record keys
        public string GetFilterFromRecordKeys(bool setCurrent = true)
        {
            List<string> recordKeys = GetRecordKeys();
            string keyFilter = "";
            foreach (var keys in recordKeys) {
                if (!Empty(keyFilter))
                    keyFilter += " OR ";
                if (setCurrent)
                    McuResult_ID.CurrentValue = keys;
                else
                    McuResult_ID.OldValue = keys;
                keyFilter += "(" + GetRecordFilter() + ")";
            }
            return keyFilter;
        }

        #pragma warning disable 618
        // Load rows based on filter // DN
        public async Task<DbDataReader?> LoadReader(string filter, string sort = "", DatabaseConnectionBase<SqlConnection, SqlCommand, SqlDataReader, SqlDbType>? conn = null)
        {
            // Set up filter (SQL WHERE clause) and get return SQL
            string sql = GetSql(filter, sort);
            try {
                var dr = await (conn ?? Connection).OpenDataReaderAsync(sql);
                if (dr?.HasRows ?? false)
                    return dr;
                else
                    dr?.Close(); // Close unused data reader // DN
            } catch {}
            return null;
        }
        #pragma warning restore 618

        // Load row values from recordset
        public void LoadListRowValues(DbDataReader? dr)
        {
            if (dr == null)
                return;
            McuResult_ID.SetDbValue(dr["McuResult_ID"]);
            MTCrew_ID.SetDbValue(dr["MTCrew_ID"]);
            IndividualCodeNumber.SetDbValue(dr["IndividualCodeNumber"]);
            FullName.SetDbValue(dr["FullName"]);
            RequiredPhoto.Upload.DbValue = dr["RequiredPhoto"];
            RequiredPhoto.SetDbValue(RequiredPhoto.Upload.DbValue);
            VisaPhoto.Upload.DbValue = dr["VisaPhoto"];
            VisaPhoto.SetDbValue(VisaPhoto.Upload.DbValue);
            Gender.SetDbValue(dr["Gender"]);
            RankAppliedFor.SetDbValue(dr["RankAppliedFor"]);
            WillAcceptLowRank.SetDbValue(ConvertToBool(dr["WillAcceptLowRank"]) ? "1" : "0");
            AvailableFrom.SetDbValue(dr["AvailableFrom"]);
            AvailableUntil.SetDbValue(dr["AvailableUntil"]);
            EmployeeStatus.SetDbValue(dr["EmployeeStatus"]);
            McuScheduleDate.SetDbValue(dr["McuScheduleDate"]);
            McuDate.SetDbValue(dr["McuDate"]);
            McuExpirationDate.SetDbValue(dr["McuExpirationDate"]);
            HealthStatus.SetDbValue(dr["HealthStatus"]);
            McuLocation.SetDbValue(dr["McuLocation"]);
            McuAttachment.Upload.DbValue = dr["McuAttachment"];
            McuAttachment.SetDbValue(McuAttachment.Upload.DbValue);
            McuRemark.SetDbValue(dr["McuRemark"]);
            CreatedBy.SetDbValue(dr["CreatedBy"]);
            CreatedDateTime.SetDbValue(dr["CreatedDateTime"]);
            LastUpdatedBy.SetDbValue(dr["LastUpdatedBy"]);
            LastUpdatedDateTime.SetDbValue(dr["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(dr["MTUserID"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "McuResultList";
            dynamic? page = CreateInstance(pageName, new object[] { Controller }); // DN
            if (page != null) {
                page.UseLayout = false; // DN
                await page.LoadRecordsetFromFilter(filter);
                string html = await GetViewOutput(pageName, page, false);
                page.Terminate(); // Terminate page and clean up
                return html;
            }
            return "";
        }

        #pragma warning disable 1998
        // Render list row values
        public async Task RenderListRow()
        {
            // Call Row Rendering event
            RowRendering();

            // Common render codes

            // McuResult_ID
            McuResult_ID.CellCssStyle = "white-space: nowrap;";

            // MTCrew_ID
            MTCrew_ID.CellCssStyle = "white-space: nowrap;";

            // IndividualCodeNumber
            IndividualCodeNumber.CellCssStyle = "white-space: nowrap;";

            // FullName
            FullName.CellCssStyle = "white-space: nowrap;";

            // RequiredPhoto
            RequiredPhoto.CellCssStyle = "white-space: nowrap;";

            // VisaPhoto
            VisaPhoto.CellCssStyle = "white-space: nowrap;";

            // Gender

            // RankAppliedFor
            RankAppliedFor.CellCssStyle = "white-space: nowrap;";

            // WillAcceptLowRank
            WillAcceptLowRank.CellCssStyle = "white-space: nowrap;";

            // AvailableFrom
            AvailableFrom.CellCssStyle = "white-space: nowrap;";

            // AvailableUntil
            AvailableUntil.CellCssStyle = "white-space: nowrap;";

            // EmployeeStatus
            EmployeeStatus.CellCssStyle = "white-space: nowrap;";

            // McuScheduleDate
            McuScheduleDate.CellCssStyle = "white-space: nowrap;";

            // McuDate
            McuDate.CellCssStyle = "white-space: nowrap;";

            // McuExpirationDate
            McuExpirationDate.CellCssStyle = "white-space: nowrap;";

            // HealthStatus
            HealthStatus.CellCssStyle = "white-space: nowrap;";

            // McuLocation
            McuLocation.CellCssStyle = "white-space: nowrap;";

            // McuAttachment
            McuAttachment.CellCssStyle = "white-space: nowrap;";

            // McuRemark
            McuRemark.CellCssStyle = "white-space: nowrap;";

            // CreatedBy
            CreatedBy.CellCssStyle = "white-space: nowrap;";

            // CreatedDateTime
            CreatedDateTime.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedBy
            LastUpdatedBy.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedDateTime
            LastUpdatedDateTime.CellCssStyle = "white-space: nowrap;";

            // MTUserID
            MTUserID.CellCssStyle = "white-space: nowrap;";

            // McuResult_ID
            McuResult_ID.ViewValue = McuResult_ID.CurrentValue;
            McuResult_ID.ViewCustomAttributes = "";

            // MTCrew_ID
            MTCrew_ID.ViewValue = MTCrew_ID.CurrentValue;
            MTCrew_ID.ViewValue = FormatNumber(MTCrew_ID.ViewValue, MTCrew_ID.FormatPattern);
            MTCrew_ID.ViewCustomAttributes = "";

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
            RequiredPhoto.CellCssStyle += "text-align: center;";
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
            VisaPhoto.CellCssStyle += "text-align: center;";
            VisaPhoto.ViewCustomAttributes = "";

            // Gender
            Gender.ViewValue = ConvertToString(Gender.CurrentValue); // DN
            Gender.ViewCustomAttributes = "";

            // RankAppliedFor
            RankAppliedFor.ViewValue = ConvertToString(RankAppliedFor.CurrentValue); // DN
            RankAppliedFor.ViewCustomAttributes = "";

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

            // EmployeeStatus
            EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
            EmployeeStatus.ViewCustomAttributes = "";

            // McuScheduleDate
            McuScheduleDate.ViewValue = McuScheduleDate.CurrentValue;
            McuScheduleDate.ViewValue = FormatDateTime(McuScheduleDate.ViewValue, McuScheduleDate.FormatPattern);
            McuScheduleDate.ViewCustomAttributes = "";

            // McuDate
            McuDate.ViewValue = McuDate.CurrentValue;
            McuDate.ViewValue = FormatDateTime(McuDate.ViewValue, McuDate.FormatPattern);
            McuDate.ViewCustomAttributes = "";

            // McuExpirationDate
            McuExpirationDate.ViewValue = McuExpirationDate.CurrentValue;
            McuExpirationDate.ViewValue = FormatDateTime(McuExpirationDate.ViewValue, McuExpirationDate.FormatPattern);
            McuExpirationDate.ViewCustomAttributes = "";

            // HealthStatus
            HealthStatus.ViewValue = ConvertToString(HealthStatus.CurrentValue); // DN
            HealthStatus.ViewCustomAttributes = "";

            // McuLocation
            McuLocation.ViewValue = ConvertToString(McuLocation.CurrentValue); // DN
            McuLocation.ViewCustomAttributes = "";

            // McuAttachment
            if (!IsNull(McuAttachment.Upload.DbValue)) {
                McuAttachment.ViewValue = McuAttachment.Upload.DbValue;
            } else {
                McuAttachment.ViewValue = "";
            }
            McuAttachment.CellCssStyle += "text-align: center;";
            McuAttachment.ViewCustomAttributes = "";

            // McuRemark
            McuRemark.ViewValue = ConvertToString(McuRemark.CurrentValue); // DN
            McuRemark.ViewCustomAttributes = "";

            // CreatedBy
            CreatedBy.ViewValue = ConvertToString(CreatedBy.CurrentValue); // DN
            CreatedBy.ViewCustomAttributes = "";

            // CreatedDateTime
            CreatedDateTime.ViewValue = CreatedDateTime.CurrentValue;
            CreatedDateTime.ViewValue = FormatDateTime(CreatedDateTime.ViewValue, CreatedDateTime.FormatPattern);
            CreatedDateTime.ViewCustomAttributes = "";

            // LastUpdatedBy
            LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
            LastUpdatedBy.ViewCustomAttributes = "";

            // LastUpdatedDateTime
            LastUpdatedDateTime.ViewValue = LastUpdatedDateTime.CurrentValue;
            LastUpdatedDateTime.ViewValue = FormatDateTime(LastUpdatedDateTime.ViewValue, LastUpdatedDateTime.FormatPattern);
            LastUpdatedDateTime.ViewCustomAttributes = "";

            // MTUserID
            MTUserID.ViewValue = MTUserID.CurrentValue;
            MTUserID.ViewValue = FormatNumber(MTUserID.ViewValue, MTUserID.FormatPattern);
            MTUserID.ViewCustomAttributes = "";

            // McuResult_ID
            McuResult_ID.HrefValue = "";
            McuResult_ID.TooltipValue = "";

            // MTCrew_ID
            MTCrew_ID.HrefValue = "";
            MTCrew_ID.TooltipValue = "";

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

            // Gender
            Gender.HrefValue = "";
            Gender.TooltipValue = "";

            // RankAppliedFor
            RankAppliedFor.HrefValue = "";
            RankAppliedFor.TooltipValue = "";

            // WillAcceptLowRank
            WillAcceptLowRank.HrefValue = "";
            WillAcceptLowRank.TooltipValue = "";

            // AvailableFrom
            AvailableFrom.HrefValue = "";
            AvailableFrom.TooltipValue = "";

            // AvailableUntil
            AvailableUntil.HrefValue = "";
            AvailableUntil.TooltipValue = "";

            // EmployeeStatus
            EmployeeStatus.HrefValue = "";
            EmployeeStatus.TooltipValue = "";

            // McuScheduleDate
            McuScheduleDate.HrefValue = "";
            McuScheduleDate.TooltipValue = "";

            // McuDate
            McuDate.HrefValue = "";
            McuDate.TooltipValue = "";

            // McuExpirationDate
            McuExpirationDate.HrefValue = "";
            McuExpirationDate.TooltipValue = "";

            // HealthStatus
            HealthStatus.HrefValue = "";
            HealthStatus.TooltipValue = "";

            // McuLocation
            McuLocation.HrefValue = "";
            McuLocation.TooltipValue = "";

            // McuAttachment
            if (!IsNull(McuAttachment.Upload.DbValue)) {
                McuAttachment.HrefValue = ConvertToString(GetFileUploadUrl(McuAttachment, McuAttachment.HtmlDecode(ConvertToString(McuAttachment.Upload.DbValue)))); // Add prefix/suffix
                McuAttachment.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    McuAttachment.HrefValue = FullUrl(ConvertToString(McuAttachment.HrefValue), "href");
            } else {
                McuAttachment.HrefValue = "";
            }
            McuAttachment.ExportHrefValue = McuAttachment.UploadPath + McuAttachment.Upload.DbValue;
            McuAttachment.TooltipValue = "";

            // McuRemark
            McuRemark.HrefValue = "";
            McuRemark.TooltipValue = "";

            // CreatedBy
            CreatedBy.HrefValue = "";
            CreatedBy.TooltipValue = "";

            // CreatedDateTime
            CreatedDateTime.HrefValue = "";
            CreatedDateTime.TooltipValue = "";

            // LastUpdatedBy
            LastUpdatedBy.HrefValue = "";
            LastUpdatedBy.TooltipValue = "";

            // LastUpdatedDateTime
            LastUpdatedDateTime.HrefValue = "";
            LastUpdatedDateTime.TooltipValue = "";

            // MTUserID
            MTUserID.HrefValue = "";
            MTUserID.TooltipValue = "";

            // Call Row Rendered event
            RowRendered();

            // Save data for Custom Template
            Rows.Add(CustomTemplateFieldValues());
        }
        #pragma warning restore 1998

        #pragma warning disable 1998
        // Render edit row values
        public async Task RenderEditRow()
        {
            // Call Row Rendering event
            RowRendering();

            // McuResult_ID
            McuResult_ID.SetupEditAttributes();
            McuResult_ID.EditValue = McuResult_ID.CurrentValue; // DN
            McuResult_ID.PlaceHolder = RemoveHtml(McuResult_ID.Caption);

            // MTCrew_ID
            MTCrew_ID.SetupEditAttributes();
            MTCrew_ID.EditValue = MTCrew_ID.CurrentValue; // DN
            MTCrew_ID.PlaceHolder = RemoveHtml(MTCrew_ID.Caption);
            if (!Empty(MTCrew_ID.EditValue) && IsNumeric(MTCrew_ID.EditValue))
                MTCrew_ID.EditValue = FormatNumber(MTCrew_ID.EditValue, null);

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

            // Gender
            Gender.SetupEditAttributes();
            if (!Gender.Raw)
                Gender.CurrentValue = HtmlDecode(Gender.CurrentValue);
            Gender.EditValue = HtmlEncode(Gender.CurrentValue);
            Gender.PlaceHolder = RemoveHtml(Gender.Caption);

            // RankAppliedFor
            RankAppliedFor.SetupEditAttributes();
            if (!RankAppliedFor.Raw)
                RankAppliedFor.CurrentValue = HtmlDecode(RankAppliedFor.CurrentValue);
            RankAppliedFor.EditValue = HtmlEncode(RankAppliedFor.CurrentValue);
            RankAppliedFor.PlaceHolder = RemoveHtml(RankAppliedFor.Caption);

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

            // EmployeeStatus
            EmployeeStatus.SetupEditAttributes();
            if (!EmployeeStatus.Raw)
                EmployeeStatus.CurrentValue = HtmlDecode(EmployeeStatus.CurrentValue);
            EmployeeStatus.EditValue = HtmlEncode(EmployeeStatus.CurrentValue);
            EmployeeStatus.PlaceHolder = RemoveHtml(EmployeeStatus.Caption);

            // McuScheduleDate
            McuScheduleDate.SetupEditAttributes();
            McuScheduleDate.EditValue = FormatDateTime(McuScheduleDate.CurrentValue, McuScheduleDate.FormatPattern); // DN
            McuScheduleDate.PlaceHolder = RemoveHtml(McuScheduleDate.Caption);

            // McuDate
            McuDate.SetupEditAttributes();
            McuDate.EditValue = FormatDateTime(McuDate.CurrentValue, McuDate.FormatPattern); // DN
            McuDate.PlaceHolder = RemoveHtml(McuDate.Caption);

            // McuExpirationDate
            McuExpirationDate.SetupEditAttributes();
            McuExpirationDate.EditValue = FormatDateTime(McuExpirationDate.CurrentValue, McuExpirationDate.FormatPattern); // DN
            McuExpirationDate.PlaceHolder = RemoveHtml(McuExpirationDate.Caption);

            // HealthStatus
            HealthStatus.SetupEditAttributes();
            if (!HealthStatus.Raw)
                HealthStatus.CurrentValue = HtmlDecode(HealthStatus.CurrentValue);
            HealthStatus.EditValue = HtmlEncode(HealthStatus.CurrentValue);
            HealthStatus.PlaceHolder = RemoveHtml(HealthStatus.Caption);

            // McuLocation
            McuLocation.SetupEditAttributes();
            if (!McuLocation.Raw)
                McuLocation.CurrentValue = HtmlDecode(McuLocation.CurrentValue);
            McuLocation.EditValue = HtmlEncode(McuLocation.CurrentValue);
            McuLocation.PlaceHolder = RemoveHtml(McuLocation.Caption);

            // McuAttachment
            McuAttachment.SetupEditAttributes();
            McuAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(McuAttachment.Upload.DbValue)) {
                McuAttachment.EditValue = McuAttachment.Upload.DbValue;
            } else {
                McuAttachment.EditValue = "";
            }
            if (!Empty(McuAttachment.CurrentValue))
                    McuAttachment.Upload.FileName = ConvertToString(McuAttachment.CurrentValue);

            // McuRemark
            McuRemark.SetupEditAttributes();
            if (!McuRemark.Raw)
                McuRemark.CurrentValue = HtmlDecode(McuRemark.CurrentValue);
            McuRemark.EditValue = HtmlEncode(McuRemark.CurrentValue);
            McuRemark.PlaceHolder = RemoveHtml(McuRemark.Caption);

            // CreatedBy
            CreatedBy.SetupEditAttributes();
            if (!CreatedBy.Raw)
                CreatedBy.CurrentValue = HtmlDecode(CreatedBy.CurrentValue);
            CreatedBy.EditValue = HtmlEncode(CreatedBy.CurrentValue);
            CreatedBy.PlaceHolder = RemoveHtml(CreatedBy.Caption);

            // CreatedDateTime
            CreatedDateTime.SetupEditAttributes();
            CreatedDateTime.EditValue = FormatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern); // DN
            CreatedDateTime.PlaceHolder = RemoveHtml(CreatedDateTime.Caption);

            // LastUpdatedBy
            LastUpdatedBy.SetupEditAttributes();
            if (!LastUpdatedBy.Raw)
                LastUpdatedBy.CurrentValue = HtmlDecode(LastUpdatedBy.CurrentValue);
            LastUpdatedBy.EditValue = HtmlEncode(LastUpdatedBy.CurrentValue);
            LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);

            // LastUpdatedDateTime
            LastUpdatedDateTime.SetupEditAttributes();
            LastUpdatedDateTime.EditValue = FormatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern); // DN
            LastUpdatedDateTime.PlaceHolder = RemoveHtml(LastUpdatedDateTime.Caption);

            // MTUserID
            MTUserID.SetupEditAttributes();
            MTUserID.EditValue = MTUserID.CurrentValue; // DN
            MTUserID.PlaceHolder = RemoveHtml(MTUserID.Caption);
            if (!Empty(MTUserID.EditValue) && IsNumeric(MTUserID.EditValue))
                MTUserID.EditValue = FormatNumber(MTUserID.EditValue, null);

            // Call Row Rendered event
            RowRendered();
        }
        #pragma warning restore 1998

        // Aggregate list row values
        public void AggregateListRowValues()
        {
        }

        #pragma warning disable 1998
        // Aggregate list row (for rendering)
        public async Task AggregateListRow()
        {
            // Call Row Rendered event
            RowRendered();
        }
        #pragma warning restore 1998

        // Export data in HTML/CSV/Word/Excel/Email/PDF format
        public async Task ExportDocument(dynamic doc, DbDataReader dataReader, int startRec, int stopRec, string exportType = "")
        {
            if (doc == null)
                return;
            if (dataReader == null)
                return;
            if (!doc.ExportCustom) {
                // Write header
                doc.ExportTableHeader();
                if (doc.Horizontal) { // Horizontal format, write header
                    doc.BeginExportRow();
                    if (exportType == "view") {
                        doc.ExportCaption(MTCrew_ID);
                        doc.ExportCaption(IndividualCodeNumber);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(RankAppliedFor);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
                        doc.ExportCaption(McuScheduleDate);
                        doc.ExportCaption(McuDate);
                        doc.ExportCaption(McuExpirationDate);
                        doc.ExportCaption(HealthStatus);
                        doc.ExportCaption(McuLocation);
                        doc.ExportCaption(McuAttachment);
                        doc.ExportCaption(McuRemark);
                    } else {
                        doc.ExportCaption(MTCrew_ID);
                        doc.ExportCaption(IndividualCodeNumber);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(RankAppliedFor);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(McuScheduleDate);
                        doc.ExportCaption(McuDate);
                        doc.ExportCaption(McuExpirationDate);
                        doc.ExportCaption(HealthStatus);
                        doc.ExportCaption(McuLocation);
                        doc.ExportCaption(McuAttachment);
                        doc.ExportCaption(McuRemark);
                        doc.ExportCaption(CreatedBy);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedBy);
                        doc.ExportCaption(LastUpdatedDateTime);
                    }
                    doc.EndExportRow();
                }
            }
            int recCnt = startRec - 1;
            // Read first record for View Page // DN
            if (exportType == "view") {
                await dataReader.ReadAsync();
            // Move to and read first record for list page // DN
            } else {
                if (Connection.SelectOffset) {
                    await dataReader.ReadAsync();
                } else {
                    for (int i = 0; i < startRec; i++) // Move to the start record and use do-while loop
                        await dataReader.ReadAsync();
                }
            }
            int rowcnt = 0; // DN
            do { // DN
                recCnt++;
                if (recCnt >= startRec) {
                    rowcnt = recCnt - startRec + 1;

                    // Page break
                    if (ExportPageBreakCount > 0) {
                        if (rowcnt > 1 && (rowcnt - 1) % ExportPageBreakCount == 0)
                            doc.ExportPageBreak();
                    }
                    LoadListRowValues(dataReader);

                    // Render row
                    RowType = RowType.View; // Render view
                    ResetAttributes();
                    await RenderListRow();
                    if (!doc.ExportCustom) {
                        doc.BeginExportRow(rowcnt); // Allow CSS styles if enabled
                        if (exportType == "view") {
                            await doc.ExportField(MTCrew_ID);
                            await doc.ExportField(IndividualCodeNumber);
                            await doc.ExportField(FullName);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(Gender);
                            await doc.ExportField(RankAppliedFor);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
                            await doc.ExportField(McuScheduleDate);
                            await doc.ExportField(McuDate);
                            await doc.ExportField(McuExpirationDate);
                            await doc.ExportField(HealthStatus);
                            await doc.ExportField(McuLocation);
                            await doc.ExportField(McuAttachment);
                            await doc.ExportField(McuRemark);
                        } else {
                            await doc.ExportField(MTCrew_ID);
                            await doc.ExportField(IndividualCodeNumber);
                            await doc.ExportField(FullName);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(Gender);
                            await doc.ExportField(RankAppliedFor);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(McuScheduleDate);
                            await doc.ExportField(McuDate);
                            await doc.ExportField(McuExpirationDate);
                            await doc.ExportField(HealthStatus);
                            await doc.ExportField(McuLocation);
                            await doc.ExportField(McuAttachment);
                            await doc.ExportField(McuRemark);
                            await doc.ExportField(CreatedBy);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedBy);
                            await doc.ExportField(LastUpdatedDateTime);
                        }
                        doc.EndExportRow(rowcnt);
                    }
                }

                // Call Row Export server event
                if (doc.ExportCustom)
                    RowExport(doc, dataReader);
            } while (recCnt < stopRec && await dataReader.ReadAsync()); // DN
            if (!doc.ExportCustom)
                doc.ExportTableFooter();
        }

        // Table filter
        private string? _tableFilter = null;

        public string TableFilter
        {
            get => _tableFilter ?? "";
            set => _tableFilter = value;
        }

        // TblBasicSearchDefault
        private string? _tableBasicSearchDefault = null;

        public string TableBasicSearchDefault
        {
            get => _tableBasicSearchDefault ?? "";
            set => _tableBasicSearchDefault = value;
        }

        #pragma warning disable 1998
        // Get file data
        public async Task<IActionResult> GetFileData(string fldparm, string[] keys, bool resize, int width = -1, int height = -1)
        {
            if (width < 0)
                width = Config.ThumbnailDefaultWidth;
            if (height < 0)
                height = Config.ThumbnailDefaultHeight;

            // Set up field names
            string fldName = "", fileNameFld = "", fileTypeFld = "";
            if (SameText(fldparm, "RequiredPhoto")) {
                fldName = "RequiredPhoto";
                fileNameFld = "RequiredPhoto";
            } else if (SameText(fldparm, "VisaPhoto")) {
                fldName = "VisaPhoto";
                fileNameFld = "VisaPhoto";
            } else if (SameText(fldparm, "McuAttachment")) {
                fldName = "McuAttachment";
                fileNameFld = "McuAttachment";
            } else {
                return JsonBoolResult.FalseResult; // Incorrect field
            }

            // Set up key values
            if (keys.Length == 1) {
                McuResult_ID.CurrentValue = keys[0];
            } else {
                return JsonBoolResult.FalseResult; // Incorrect key
            }

            // Set up filter (WHERE Clause)
            string filter = GetRecordFilter();
            CurrentFilter = filter;
            string sql = CurrentSql;
            using var rs = await Connection.GetDataReaderAsync(sql);
            if (rs != null && await rs.ReadAsync()) {
                var val = rs[fldName];
                if (!Empty(val)) {
                    if (Fields.TryGetValue(fldName, out DbField? fld) && fld != null) {
                        // Binary data
                        if (fld.IsBlob) {
                            byte[] data = (byte[])val;
                            if (resize && data.Length > 0)
                                ResizeBinary(ref data, ref width, ref height);
                            string? contentType = "";

                            // Write file type
                            if (!Empty(fileTypeFld) && !Empty(rs[fileTypeFld]))
                                contentType = ConvertToString(rs[fileTypeFld]);
                            else
                                contentType = ContentType(data);

                            // Write file data
                            if (data.Take(8).SequenceEqual(new byte[] {0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00}) && // Fix Office 2007 documents
                                !data.TakeLast(4).SequenceEqual(new byte[] {0x00, 0x00, 0x00, 0x00}))
                                    data.Concat(new byte[] {0x00, 0x00, 0x00, 0x00});

                            // Clear any debug message
                            // Response?.Clear();

                            // Return file content result // DN
                            string downloadFileName = !Empty(fileNameFld) && !Empty(rs[fileNameFld]) ?
                                ConvertToString(rs[fileNameFld]) :
                                DownloadFileName;
                            string ext = ContentExtension(data).Replace(".", ""); // Get file extension
                            if (ext == "pdf" && Config.EmbedPdf) // Embed Pdf // DN
                                downloadFileName = "";
                            if (!Empty(downloadFileName))
                                return Controller.File(data, contentType, downloadFileName);
                            else
                                return Controller.File(data, contentType);

                        // Upload to folder
                        } else {
                            List<string> files;
                            if (fld.UploadMultiple)
                                files = ConvertToString(val).Split(Config.MultipleUploadSeparator).ToList();
                            else
                                files = new () { ConvertToString(val) };
                            var mi = fld.GetType().GetMethod("GetUploadPath");
                            if (mi != null) // GetUploadPath
                                fld.UploadPath = ConvertToString(mi.Invoke(fld, null));
                            var result = files.ToDictionary(f => f, f => Config.EncryptFilePath
                                ? FullUrl(Config.ApiUrl + Config.ApiFileAction + "/" + TableVar + "/" + Encrypt(fld.PhysicalUploadPath + f))
                                : FullUrl(fld.HrefPath + f));
                            return new JsonBoolResult(new Dictionary<string, object> { { fld.Param, result } }, true);
                        }
                    }
                }
            }
            return JsonBoolResult.FalseResult; // Incorrect key
        }
        #pragma warning restore 1998

        // Table level events
        // Table Load event
        public void TableLoad()
        {
            // Enter your code here
            RankAppliedFor.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("RankAppliedFor", "McuResult", true, "RankAppliedFor", new List<string> {"RankAppliedFor", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("RankAppliedFor", "McuResult", true, "RankAppliedFor", new List<string> {"RankAppliedFor", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("RankAppliedFor", "McuResult", true, "RankAppliedFor", new List<string> {"RankAppliedFor", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            CreatedBy.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedBy", "McuResult", true, "CreatedBy", new List<string> {"CreatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CreatedBy", "McuResult", true, "CreatedBy", new List<string> {"CreatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CreatedBy", "McuResult", true, "CreatedBy", new List<string> {"CreatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            LastUpdatedBy.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedBy", "McuResult", true, "LastUpdatedBy", new List<string> {"LastUpdatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedBy", "McuResult", true, "LastUpdatedBy", new List<string> {"LastUpdatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedBy", "McuResult", true, "LastUpdatedBy", new List<string> {"LastUpdatedBy", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
        }

        // Recordset Selecting event
        public void RecordsetSelecting(ref string filter) {
            // Enter your code here
        }

        // Recordset Selected event
        public void RecordsetSelected(DbDataReader rs) {
            // Enter your code here
        }

        // Recordset Searching event
        public void RecordsetSearching(ref string filter) {
            // Enter your code here
        }

        // Recordset Search Validated event
        public void RecordsetSearchValidated() {
            // Enter your code here
        }

        // Row_Selecting event
        public void RowSelecting(ref string filter) {
            // Enter your code here
        }

        // Row Selected event
        public void RowSelected(Dictionary<string, object> row) {
            //Log("Row Selected");
        }

        // Row Inserting event
        public bool RowInserting(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
            return true;
        }

        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            //Log("Row Inserted");
        }

        // Row Updating event
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
            return true;
        }

        // Row Updated event
        public void RowUpdated(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            //Log("Row Updated");
        }

        // Row Update Conflict event
        public bool RowUpdateConflict(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            // Enter your code here
            // To ignore conflict, set return value to false
            return true;
        }

        // Recordset Deleting event
        public bool RowDeleting(Dictionary<string, object> rs) {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
            return true;
        }

        // Row Deleted event
        public void RowDeleted(Dictionary<string, object> rs) {
            //Log("Row Deleted");
        }

        // Row Export event
        // doc = export document object
        public virtual void RowExport(dynamic doc, DbDataReader rs) {
            //doc.Text.Append("<div>" + MyField.ViewValue +"</div>"); // Build HTML with field value: rs["MyField"] or MyField.ViewValue
        }

        // Email Sending event
        public virtual bool EmailSending(Email email, dynamic? args) {
            //Log(email);
            return true;
        }

        // Lookup Selecting event
        public void LookupSelecting(DbField fld, ref string filter) {
            // Enter your code here
        }

        // Row Rendering event
        public void RowRendering() {
            // Enter your code here
        }

        // Row Rendered event
        public void RowRendered() {
            //VarDump(<FieldName>); // View field properties
        }

        // User ID Filtering event
        public void UserIdFiltering(ref string filter) {
            // Enter your code here
        }
    }
} // End Partial class
