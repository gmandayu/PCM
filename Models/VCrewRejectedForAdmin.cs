namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// vCrewRejectedForAdmin
    /// </summary>
    [MaybeNull]
    public static VCrewRejectedForAdmin vCrewRejectedForAdmin
    {
        get => HttpData.Resolve<VCrewRejectedForAdmin>("v_CrewRejectedForAdmin");
        set => HttpData["v_CrewRejectedForAdmin"] = value;
    }

    /// <summary>
    /// Table class for v_CrewRejectedForAdmin
    /// </summary>
    public class VCrewRejectedForAdmin : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> ID;

        public readonly DbField<SqlDbType> IndividualCodeNumber;

        public readonly DbField<SqlDbType> EmployeeStatus;

        public readonly DbField<SqlDbType> FullName;

        public readonly DbField<SqlDbType> RequiredPhoto;

        public readonly DbField<SqlDbType> VisaPhoto;

        public readonly DbField<SqlDbType> CityOfBirth;

        public readonly DbField<SqlDbType> DateOfBirth;

        public readonly DbField<SqlDbType> Gender;

        public readonly DbField<SqlDbType> RankAppliedFor_RankID;

        public readonly DbField<SqlDbType> WillAcceptLowRank;

        public readonly DbField<SqlDbType> AvailableFrom;

        public readonly DbField<SqlDbType> AvailableUntil;

        // Constructor
        public VCrewRejectedForAdmin()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "v_CrewRejectedForAdmin";
            Name = "v_CrewRejectedForAdmin";
            Type = "VIEW";
            UpdateTable = "dbo.MTCrew"; // Update Table
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

            // ID
            ID = new (this, "x_ID", 3, SqlDbType.Int) {
                Name = "ID",
                Expression = "[ID]",
                BasicSearchExpression = "CAST([ID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[ID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "NO",
                InputTextType = "text",
                IsAutoIncrement = true, // Autoincrement field
                IsPrimaryKey = true, // Primary key field
                Nullable = false, // NOT NULL field
                Sortable = false, // Allow sort
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN" },
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ID", ID);

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
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "IndividualCodeNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("IndividualCodeNumber", IndividualCodeNumber);

            // EmployeeStatus
            EmployeeStatus = new (this, "x_EmployeeStatus", 202, SqlDbType.NVarChar) {
                Name = "EmployeeStatus",
                Expression = "[EmployeeStatus]",
                UseBasicSearch = true,
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
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "EmployeeStatus", "CustomMsg"),
                IsUpload = false
            };
            EmployeeStatus.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("EmployeeStatus", "v_CrewRejectedForAdmin", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("EmployeeStatus", "v_CrewRejectedForAdmin", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("EmployeeStatus", "v_CrewRejectedForAdmin", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("EmployeeStatus", EmployeeStatus);

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
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "FullName", "CustomMsg"),
                IsUpload = false
            };
            FullName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FullName", "v_CrewRejectedForAdmin", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("FullName", "v_CrewRejectedForAdmin", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("FullName", "v_CrewRejectedForAdmin", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("FullName", FullName);

            // RequiredPhoto
            RequiredPhoto = new (this, "x_RequiredPhoto", 202, SqlDbType.NVarChar) {
                Name = "RequiredPhoto",
                Expression = "[RequiredPhoto]",
                UseBasicSearch = true,
                BasicSearchExpression = "[RequiredPhoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[RequiredPhoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "RequiredPhoto", "CustomMsg"),
                IsUpload = false
            };
            RequiredPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("RequiredPhoto", "v_CrewRejectedForAdmin", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("RequiredPhoto", "v_CrewRejectedForAdmin", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("RequiredPhoto", "v_CrewRejectedForAdmin", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("RequiredPhoto", RequiredPhoto);

            // VisaPhoto
            VisaPhoto = new (this, "x_VisaPhoto", 202, SqlDbType.NVarChar) {
                Name = "VisaPhoto",
                Expression = "[VisaPhoto]",
                UseBasicSearch = true,
                BasicSearchExpression = "[VisaPhoto]",
                DateTimeFormat = -1,
                VirtualExpression = "[VisaPhoto]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "VisaPhoto", "CustomMsg"),
                IsUpload = false
            };
            VisaPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("VisaPhoto", "v_CrewRejectedForAdmin", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("VisaPhoto", "v_CrewRejectedForAdmin", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("VisaPhoto", "v_CrewRejectedForAdmin", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("VisaPhoto", VisaPhoto);

            // CityOfBirth
            CityOfBirth = new (this, "x_CityOfBirth", 202, SqlDbType.NVarChar) {
                Name = "CityOfBirth",
                Expression = "[CityOfBirth]",
                UseBasicSearch = true,
                BasicSearchExpression = "[CityOfBirth]",
                DateTimeFormat = -1,
                VirtualExpression = "[CityOfBirth]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "CityOfBirth", "CustomMsg"),
                IsUpload = false
            };
            CityOfBirth.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CityOfBirth", "v_CrewRejectedForAdmin", true, "CityOfBirth", new List<string> {"CityOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CityOfBirth", "v_CrewRejectedForAdmin", true, "CityOfBirth", new List<string> {"CityOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CityOfBirth", "v_CrewRejectedForAdmin", true, "CityOfBirth", new List<string> {"CityOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CityOfBirth", CityOfBirth);

            // DateOfBirth
            DateOfBirth = new (this, "x_DateOfBirth", 133, SqlDbType.DateTime) {
                Name = "DateOfBirth",
                Expression = "[DateOfBirth]",
                BasicSearchExpression = CastDateFieldForLike("[DateOfBirth]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[DateOfBirth]",
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
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "DateOfBirth", "CustomMsg"),
                IsUpload = false
            };
            DateOfBirth.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("DateOfBirth", "v_CrewRejectedForAdmin", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("DateOfBirth", "v_CrewRejectedForAdmin", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("DateOfBirth", "v_CrewRejectedForAdmin", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("DateOfBirth", DateOfBirth);

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
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "Gender", "CustomMsg"),
                IsUpload = false
            };
            Gender.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Gender", "v_CrewRejectedForAdmin", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Gender", "v_CrewRejectedForAdmin", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Gender", "v_CrewRejectedForAdmin", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Gender", Gender);

            // RankAppliedFor_RankID
            RankAppliedFor_RankID = new (this, "x_RankAppliedFor_RankID", 3, SqlDbType.Int) {
                Name = "RankAppliedFor_RankID",
                Expression = "[RankAppliedFor_RankID]",
                BasicSearchExpression = "CAST([RankAppliedFor_RankID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[RankAppliedFor_RankID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "RankAppliedFor_RankID", "CustomMsg"),
                IsUpload = false
            };
            RankAppliedFor_RankID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("RankAppliedFor_RankID", "MTRank", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("RankAppliedFor_RankID", "MTRank", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("RankAppliedFor_RankID", "MTRank", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("RankAppliedFor_RankID", RankAppliedFor_RankID);

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
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "WillAcceptLowRank", "CustomMsg"),
                IsUpload = false
            };
            WillAcceptLowRank.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("WillAcceptLowRank", "v_CrewRejectedForAdmin", true, "WillAcceptLowRank", new List<string> {"WillAcceptLowRank", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("WillAcceptLowRank", "v_CrewRejectedForAdmin", true, "WillAcceptLowRank", new List<string> {"WillAcceptLowRank", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("WillAcceptLowRank", "v_CrewRejectedForAdmin", true, "WillAcceptLowRank", new List<string> {"WillAcceptLowRank", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "AvailableFrom", "CustomMsg"),
                IsUpload = false
            };
            AvailableFrom.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("AvailableFrom", "v_CrewRejectedForAdmin", true, "AvailableFrom", new List<string> {"AvailableFrom", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("AvailableFrom", "v_CrewRejectedForAdmin", true, "AvailableFrom", new List<string> {"AvailableFrom", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("AvailableFrom", "v_CrewRejectedForAdmin", true, "AvailableFrom", new List<string> {"AvailableFrom", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("v_CrewRejectedForAdmin", "AvailableUntil", "CustomMsg"),
                IsUpload = false
            };
            AvailableUntil.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("AvailableUntil", "v_CrewRejectedForAdmin", true, "AvailableUntil", new List<string> {"AvailableUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("AvailableUntil", "v_CrewRejectedForAdmin", true, "AvailableUntil", new List<string> {"AvailableUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("AvailableUntil", "v_CrewRejectedForAdmin", true, "AvailableUntil", new List<string> {"AvailableUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("AvailableUntil", AvailableUntil);

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
            get => _sqlFrom ?? "dbo.v_CrewRejectedForAdmin";
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
                var lastInsertedId = await queryBuilder.InsertGetIdAsync<int>(row);
                ID.SetDbValue(lastInsertedId);
                result = 1;
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
                ID.DbValue = row["ID"]; // Set DB value only
                IndividualCodeNumber.DbValue = row["IndividualCodeNumber"]; // Set DB value only
                EmployeeStatus.DbValue = row["EmployeeStatus"]; // Set DB value only
                FullName.DbValue = row["FullName"]; // Set DB value only
                RequiredPhoto.DbValue = row["RequiredPhoto"]; // Set DB value only
                VisaPhoto.DbValue = row["VisaPhoto"]; // Set DB value only
                CityOfBirth.DbValue = row["CityOfBirth"]; // Set DB value only
                DateOfBirth.DbValue = row["DateOfBirth"]; // Set DB value only
                Gender.DbValue = row["Gender"]; // Set DB value only
                RankAppliedFor_RankID.DbValue = row["RankAppliedFor_RankID"]; // Set DB value only
                WillAcceptLowRank.DbValue = (ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"); // Set DB value only
                AvailableFrom.DbValue = row["AvailableFrom"]; // Set DB value only
                AvailableUntil.DbValue = row["AvailableUntil"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[ID] = @ID@";

        #pragma warning disable 168, 219
        // Get record filter as string
        public string GetRecordFilter(Dictionary<string, object>? row = null, bool current = false)
        {
            string keyFilter = _sqlKeyFilter;
            object? val = null, result = "";
            val = row?.TryGetValue("ID", out result) ?? false
                ? result
                : !Empty(ID.OldValue) && !current ? ID.OldValue : ID.CurrentValue;
            if (!IsNumeric(val))
                return "0=1"; // Invalid key
            if (val == null)
                return "0=1"; // Invalid key
            keyFilter = keyFilter.Replace("@ID@", AdjustSql(val, DbId)); // Replace key value
            return keyFilter;
        }

        // Get record filter as Dictionary // DN
        public Dictionary<string, object>? GetRowFilterAsDictionary(IDictionary<string, object>? row = null)
        {
            Dictionary<string, object>? keyFilter = new ();
            object? val = null, result;
            val = row?.TryGetValue("ID", out result) ?? false
                ? result
                : !Empty(ID.OldValue) ? ID.OldValue : ID.CurrentValue;
            if (!IsNumeric(val))
                return null; // Invalid key
            if (Empty(val))
                return null; // Invalid key
            keyFilter.Add("ID", val); // Add key value
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
                    return "VCrewRejectedForAdminList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "VCrewRejectedForAdminView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "VCrewRejectedForAdminEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "VCrewRejectedForAdminAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "VCrewRejectedForAdminList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "VCrewRejectedForAdminView",
                Config.ApiAddAction => "VCrewRejectedForAdminAdd",
                Config.ApiEditAction => "VCrewRejectedForAdminEdit",
                Config.ApiDeleteAction => "VCrewRejectedForAdminDelete",
                Config.ApiListAction => "VCrewRejectedForAdminList",
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
        public string ListUrl => "VCrewRejectedForAdminList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("VCrewRejectedForAdminView", parm);
            else
                url = KeyUrl("VCrewRejectedForAdminView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "VCrewRejectedForAdminAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "VCrewRejectedForAdminAdd?" + parm;
            else
                url = "VCrewRejectedForAdminAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("VCrewRejectedForAdminEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("VCrewRejectedForAdminList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("VCrewRejectedForAdminAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("VCrewRejectedForAdminList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("VCrewRejectedForAdminDelete")); // DN

        // Add master URL
        public string AddMasterUrl(string url)
        {
            return url;
        }

        // Get primary key as JSON
        public string KeyToJson(bool htmlEncode = false)
        {
            string json = "";
            json += "\"ID\":" + ConvertToJson(ID.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL
        public string KeyUrl(string url, string parm = "") { // DN
            if (!IsNull(ID.CurrentValue)) {
                url += "/" + ID.CurrentValue;
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
            val = current ? ConvertToString(ID.CurrentValue) ?? "" : ConvertToString(ID.OldValue) ?? "";
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
            val = row?.TryGetValue("ID", out result) ?? false ? ConvertToString(result) : null;
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
                    ID.CurrentValue = keys[0];
                } else {
                    ID.OldValue = keys[0];
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
                if (RouteValues.TryGetValue("ID", out object? v0)) { // ID // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("ID");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (!IsNumeric(keys)) // ID
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
                    ID.CurrentValue = keys;
                else
                    ID.OldValue = keys;
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
            ID.SetDbValue(dr["ID"]);
            IndividualCodeNumber.SetDbValue(dr["IndividualCodeNumber"]);
            EmployeeStatus.SetDbValue(dr["EmployeeStatus"]);
            FullName.SetDbValue(dr["FullName"]);
            RequiredPhoto.SetDbValue(dr["RequiredPhoto"]);
            VisaPhoto.SetDbValue(dr["VisaPhoto"]);
            CityOfBirth.SetDbValue(dr["CityOfBirth"]);
            DateOfBirth.SetDbValue(dr["DateOfBirth"]);
            Gender.SetDbValue(dr["Gender"]);
            RankAppliedFor_RankID.SetDbValue(dr["RankAppliedFor_RankID"]);
            WillAcceptLowRank.SetDbValue(ConvertToBool(dr["WillAcceptLowRank"]) ? "1" : "0");
            AvailableFrom.SetDbValue(dr["AvailableFrom"]);
            AvailableUntil.SetDbValue(dr["AvailableUntil"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "VCrewRejectedForAdminList";
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

            // ID
            ID.CellCssStyle = "white-space: nowrap;";

            // IndividualCodeNumber
            IndividualCodeNumber.CellCssStyle = "white-space: nowrap;";

            // EmployeeStatus
            EmployeeStatus.CellCssStyle = "white-space: nowrap;";

            // FullName
            FullName.CellCssStyle = "white-space: nowrap;";

            // RequiredPhoto
            RequiredPhoto.CellCssStyle = "white-space: nowrap;";

            // VisaPhoto
            VisaPhoto.CellCssStyle = "white-space: nowrap;";

            // CityOfBirth
            CityOfBirth.CellCssStyle = "white-space: nowrap;";

            // DateOfBirth
            DateOfBirth.CellCssStyle = "white-space: nowrap;";

            // Gender
            Gender.CellCssStyle = "white-space: nowrap;";

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.CellCssStyle = "white-space: nowrap;";

            // WillAcceptLowRank
            WillAcceptLowRank.CellCssStyle = "white-space: nowrap;";

            // AvailableFrom
            AvailableFrom.CellCssStyle = "white-space: nowrap;";

            // AvailableUntil
            AvailableUntil.CellCssStyle = "white-space: nowrap;";

            // ID
            ID.ViewValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

            // IndividualCodeNumber
            IndividualCodeNumber.ViewValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
            IndividualCodeNumber.ViewCustomAttributes = "";

            // EmployeeStatus
            EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
            EmployeeStatus.ViewCustomAttributes = "";

            // FullName
            FullName.ViewValue = ConvertToString(FullName.CurrentValue); // DN
            FullName.ViewCustomAttributes = "";

            // RequiredPhoto
            RequiredPhoto.ViewValue = ConvertToString(RequiredPhoto.CurrentValue); // DN
            RequiredPhoto.CellCssStyle += "text-align: center;";
            RequiredPhoto.ViewCustomAttributes = "";

            // VisaPhoto
            VisaPhoto.ViewValue = ConvertToString(VisaPhoto.CurrentValue); // DN
            VisaPhoto.CellCssStyle += "text-align: center;";
            VisaPhoto.ViewCustomAttributes = "";

            // CityOfBirth
            CityOfBirth.ViewValue = ConvertToString(CityOfBirth.CurrentValue); // DN
            CityOfBirth.ViewCustomAttributes = "";

            // DateOfBirth
            DateOfBirth.ViewValue = DateOfBirth.CurrentValue;
            DateOfBirth.ViewValue = FormatDateTime(DateOfBirth.ViewValue, DateOfBirth.FormatPattern);
            DateOfBirth.ViewCustomAttributes = "";

            // Gender
            Gender.ViewValue = ConvertToString(Gender.CurrentValue); // DN
            Gender.ViewCustomAttributes = "";

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.ViewValue = RankAppliedFor_RankID.CurrentValue;
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

            // ID
            ID.HrefValue = "";
            ID.TooltipValue = "";

            // IndividualCodeNumber
            IndividualCodeNumber.HrefValue = "";
            IndividualCodeNumber.TooltipValue = "";

            // EmployeeStatus
            EmployeeStatus.HrefValue = "";
            EmployeeStatus.TooltipValue = "";

            // FullName
            FullName.HrefValue = "";
            FullName.TooltipValue = "";

            // RequiredPhoto
            RequiredPhoto.HrefValue = "";
            RequiredPhoto.TooltipValue = "";

            // VisaPhoto
            VisaPhoto.HrefValue = "";
            VisaPhoto.TooltipValue = "";

            // CityOfBirth
            CityOfBirth.HrefValue = "";
            CityOfBirth.TooltipValue = "";

            // DateOfBirth
            DateOfBirth.HrefValue = "";
            DateOfBirth.TooltipValue = "";

            // Gender
            Gender.HrefValue = "";
            Gender.TooltipValue = "";

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

            // ID
            ID.SetupEditAttributes();
            ID.EditValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

            // IndividualCodeNumber
            IndividualCodeNumber.SetupEditAttributes();
            if (!IndividualCodeNumber.Raw)
                IndividualCodeNumber.CurrentValue = HtmlDecode(IndividualCodeNumber.CurrentValue);
            IndividualCodeNumber.EditValue = HtmlEncode(IndividualCodeNumber.CurrentValue);
            IndividualCodeNumber.PlaceHolder = RemoveHtml(IndividualCodeNumber.Caption);

            // EmployeeStatus
            EmployeeStatus.SetupEditAttributes();
            if (!EmployeeStatus.Raw)
                EmployeeStatus.CurrentValue = HtmlDecode(EmployeeStatus.CurrentValue);
            EmployeeStatus.EditValue = HtmlEncode(EmployeeStatus.CurrentValue);
            EmployeeStatus.PlaceHolder = RemoveHtml(EmployeeStatus.Caption);

            // FullName
            FullName.SetupEditAttributes();
            if (!FullName.Raw)
                FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
            FullName.EditValue = HtmlEncode(FullName.CurrentValue);
            FullName.PlaceHolder = RemoveHtml(FullName.Caption);

            // RequiredPhoto
            RequiredPhoto.SetupEditAttributes();
            if (!RequiredPhoto.Raw)
                RequiredPhoto.CurrentValue = HtmlDecode(RequiredPhoto.CurrentValue);
            RequiredPhoto.EditValue = HtmlEncode(RequiredPhoto.CurrentValue);
            RequiredPhoto.PlaceHolder = RemoveHtml(RequiredPhoto.Caption);

            // VisaPhoto
            VisaPhoto.SetupEditAttributes();
            if (!VisaPhoto.Raw)
                VisaPhoto.CurrentValue = HtmlDecode(VisaPhoto.CurrentValue);
            VisaPhoto.EditValue = HtmlEncode(VisaPhoto.CurrentValue);
            VisaPhoto.PlaceHolder = RemoveHtml(VisaPhoto.Caption);

            // CityOfBirth
            CityOfBirth.SetupEditAttributes();
            if (!CityOfBirth.Raw)
                CityOfBirth.CurrentValue = HtmlDecode(CityOfBirth.CurrentValue);
            CityOfBirth.EditValue = HtmlEncode(CityOfBirth.CurrentValue);
            CityOfBirth.PlaceHolder = RemoveHtml(CityOfBirth.Caption);

            // DateOfBirth
            DateOfBirth.SetupEditAttributes();
            DateOfBirth.EditValue = FormatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern); // DN
            DateOfBirth.PlaceHolder = RemoveHtml(DateOfBirth.Caption);

            // Gender
            Gender.SetupEditAttributes();
            if (!Gender.Raw)
                Gender.CurrentValue = HtmlDecode(Gender.CurrentValue);
            Gender.EditValue = HtmlEncode(Gender.CurrentValue);
            Gender.PlaceHolder = RemoveHtml(Gender.Caption);

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.SetupEditAttributes();
            RankAppliedFor_RankID.EditValue = RankAppliedFor_RankID.CurrentValue; // DN
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
                        doc.ExportCaption(IndividualCodeNumber);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(CityOfBirth);
                        doc.ExportCaption(DateOfBirth);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(RankAppliedFor_RankID);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
                    } else {
                        doc.ExportCaption(IndividualCodeNumber);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(CityOfBirth);
                        doc.ExportCaption(DateOfBirth);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(RankAppliedFor_RankID);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
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
                            await doc.ExportField(IndividualCodeNumber);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(FullName);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(CityOfBirth);
                            await doc.ExportField(DateOfBirth);
                            await doc.ExportField(Gender);
                            await doc.ExportField(RankAppliedFor_RankID);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
                        } else {
                            await doc.ExportField(IndividualCodeNumber);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(FullName);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(CityOfBirth);
                            await doc.ExportField(DateOfBirth);
                            await doc.ExportField(Gender);
                            await doc.ExportField(RankAppliedFor_RankID);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
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

            // No binary fields
            return JsonBoolResult.FalseResult; // Incorrect key
        }
        #pragma warning restore 1998

        // Table level events

        // Table Load event
        public void TableLoad()
        {
            // Enter your code here
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
