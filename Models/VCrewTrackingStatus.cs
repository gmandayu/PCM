namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// vCrewTrackingStatus
    /// </summary>
    [MaybeNull]
    public static VCrewTrackingStatus vCrewTrackingStatus
    {
        get => HttpData.Resolve<VCrewTrackingStatus>("v_CrewTrackingStatus");
        set => HttpData["v_CrewTrackingStatus"] = value;
    }

    /// <summary>
    /// Table class for v_CrewTrackingStatus
    /// </summary>
    public class VCrewTrackingStatus : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> FullName;

        public readonly DbField<SqlDbType> RequiredPhoto;

        public readonly DbField<SqlDbType> VisaPhoto;

        public readonly DbField<SqlDbType> Gender;

        public readonly DbField<SqlDbType> RankAppliedFor;

        public readonly DbField<SqlDbType> WillAcceptLowRank;

        public readonly DbField<SqlDbType> EmployeeStatus;

        public readonly DbField<SqlDbType> Draft;

        public readonly DbField<SqlDbType> Submitted;

        public readonly DbField<SqlDbType> Reviewed;

        public readonly DbField<SqlDbType> RegistrationForm;

        public readonly DbField<SqlDbType> PreScreeningInterview;

        public readonly DbField<SqlDbType> MinimumRecruitmentCheck;

        public readonly DbField<SqlDbType> EngagementChecklist;

        public readonly DbField<SqlDbType> COCAuthenticity;

        public readonly DbField<SqlDbType> CESTest;

        public readonly DbField<SqlDbType> PyschometricTest;

        public readonly DbField<SqlDbType> CrewWatchlist;

        public readonly DbField<SqlDbType> PreviousAppraisalReport;

        public readonly DbField<SqlDbType> ContractBackgroundCheck;

        public readonly DbField<SqlDbType> EnglishProficiencyTestOrMarline;

        public readonly DbField<SqlDbType> Interviewed;

        public readonly DbField<SqlDbType> Approved;

        public readonly DbField<SqlDbType> MedicalCheckup;

        public readonly DbField<SqlDbType> CreatedBy;

        public readonly DbField<SqlDbType> LastUpdatedBy;

        // Constructor
        public VCrewTrackingStatus()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "v_CrewTrackingStatus";
            Name = "v_CrewTrackingStatus";
            Type = "VIEW";
            UpdateTable = "dbo.v_CrewTrackingStatus"; // Update Table
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
                HtmlTag = "TEXT",
                InputTextType = "text",
                IsPrimaryKey = true, // Primary key field
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                Sortable = false, // Allow sort
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "ID", "CustomMsg"),
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
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "IndividualCodeNumber", "CustomMsg"),
                IsUpload = false
            };
            IndividualCodeNumber.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("IndividualCodeNumber", "v_CrewTrackingStatus", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("IndividualCodeNumber", "v_CrewTrackingStatus", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("IndividualCodeNumber", "v_CrewTrackingStatus", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "FullName", "CustomMsg"),
                IsUpload = false
            };
            FullName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FullName", "v_CrewTrackingStatus", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("FullName", "v_CrewTrackingStatus", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("FullName", "v_CrewTrackingStatus", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "RequiredPhoto", "CustomMsg"),
                IsUpload = false
            };
            RequiredPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("RequiredPhoto", "v_CrewTrackingStatus", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("RequiredPhoto", "v_CrewTrackingStatus", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("RequiredPhoto", "v_CrewTrackingStatus", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "VisaPhoto", "CustomMsg"),
                IsUpload = false
            };
            VisaPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("VisaPhoto", "v_CrewTrackingStatus", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("VisaPhoto", "v_CrewTrackingStatus", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("VisaPhoto", "v_CrewTrackingStatus", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
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
                UseFilter = true, // Table header filter
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "Gender", "CustomMsg"),
                IsUpload = false
            };
            Gender.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Gender", "v_CrewTrackingStatus", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Gender", "v_CrewTrackingStatus", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Gender", "v_CrewTrackingStatus", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "RankAppliedFor", "CustomMsg"),
                IsUpload = false
            };
            RankAppliedFor.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("RankAppliedFor", "v_CrewTrackingStatus", true, "RankAppliedFor", new List<string> {"RankAppliedFor", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("RankAppliedFor", "v_CrewTrackingStatus", true, "RankAppliedFor", new List<string> {"RankAppliedFor", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("RankAppliedFor", "v_CrewTrackingStatus", true, "RankAppliedFor", new List<string> {"RankAppliedFor", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "WillAcceptLowRank", "CustomMsg"),
                IsUpload = false
            };
            WillAcceptLowRank.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("WillAcceptLowRank", "v_CrewTrackingStatus", true, "WillAcceptLowRank", new List<string> {"WillAcceptLowRank", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("WillAcceptLowRank", "v_CrewTrackingStatus", true, "WillAcceptLowRank", new List<string> {"WillAcceptLowRank", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("WillAcceptLowRank", "v_CrewTrackingStatus", true, "WillAcceptLowRank", new List<string> {"WillAcceptLowRank", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("WillAcceptLowRank", WillAcceptLowRank);

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
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "EmployeeStatus", "CustomMsg"),
                IsUpload = false
            };
            EmployeeStatus.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("EmployeeStatus", "v_CrewTrackingStatus", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("EmployeeStatus", "v_CrewTrackingStatus", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("EmployeeStatus", "v_CrewTrackingStatus", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("EmployeeStatus", EmployeeStatus);

            // Draft
            Draft = new (this, "x_Draft", 3, SqlDbType.Int) {
                Name = "Draft",
                Expression = "[Draft]",
                BasicSearchExpression = "CAST([Draft] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Draft]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "Draft", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Draft", Draft);

            // Submitted
            Submitted = new (this, "x_Submitted", 3, SqlDbType.Int) {
                Name = "Submitted",
                Expression = "[Submitted]",
                BasicSearchExpression = "CAST([Submitted] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Submitted]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "Submitted", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Submitted", Submitted);

            // Reviewed
            Reviewed = new (this, "x_Reviewed", 3, SqlDbType.Int) {
                Name = "Reviewed",
                Expression = "[Reviewed]",
                BasicSearchExpression = "CAST([Reviewed] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Reviewed]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "Reviewed", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reviewed", Reviewed);

            // RegistrationForm
            RegistrationForm = new (this, "x_RegistrationForm", 3, SqlDbType.Int) {
                Name = "RegistrationForm",
                Expression = "[RegistrationForm]",
                BasicSearchExpression = "CAST([RegistrationForm] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[RegistrationForm]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "RegistrationForm", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RegistrationForm", RegistrationForm);

            // PreScreeningInterview
            PreScreeningInterview = new (this, "x_PreScreeningInterview", 3, SqlDbType.Int) {
                Name = "PreScreeningInterview",
                Expression = "[PreScreeningInterview]",
                BasicSearchExpression = "CAST([PreScreeningInterview] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PreScreeningInterview]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "PreScreeningInterview", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PreScreeningInterview", PreScreeningInterview);

            // MinimumRecruitmentCheck
            MinimumRecruitmentCheck = new (this, "x_MinimumRecruitmentCheck", 3, SqlDbType.Int) {
                Name = "MinimumRecruitmentCheck",
                Expression = "[MinimumRecruitmentCheck]",
                BasicSearchExpression = "CAST([MinimumRecruitmentCheck] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[MinimumRecruitmentCheck]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "MinimumRecruitmentCheck", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MinimumRecruitmentCheck", MinimumRecruitmentCheck);

            // EngagementChecklist
            EngagementChecklist = new (this, "x_EngagementChecklist", 3, SqlDbType.Int) {
                Name = "EngagementChecklist",
                Expression = "[EngagementChecklist]",
                BasicSearchExpression = "CAST([EngagementChecklist] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[EngagementChecklist]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "EngagementChecklist", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("EngagementChecklist", EngagementChecklist);

            // COCAuthenticity
            COCAuthenticity = new (this, "x_COCAuthenticity", 3, SqlDbType.Int) {
                Name = "COCAuthenticity",
                Expression = "[COCAuthenticity]",
                BasicSearchExpression = "CAST([COCAuthenticity] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[COCAuthenticity]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "COCAuthenticity", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("COCAuthenticity", COCAuthenticity);

            // CESTest
            CESTest = new (this, "x_CESTest", 3, SqlDbType.Int) {
                Name = "CESTest",
                Expression = "[CESTest]",
                BasicSearchExpression = "CAST([CESTest] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[CESTest]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "CESTest", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("CESTest", CESTest);

            // PyschometricTest
            PyschometricTest = new (this, "x_PyschometricTest", 3, SqlDbType.Int) {
                Name = "PyschometricTest",
                Expression = "[PyschometricTest]",
                BasicSearchExpression = "CAST([PyschometricTest] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PyschometricTest]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "PyschometricTest", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PyschometricTest", PyschometricTest);

            // CrewWatchlist
            CrewWatchlist = new (this, "x_CrewWatchlist", 3, SqlDbType.Int) {
                Name = "CrewWatchlist",
                Expression = "[CrewWatchlist]",
                BasicSearchExpression = "CAST([CrewWatchlist] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[CrewWatchlist]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "CrewWatchlist", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("CrewWatchlist", CrewWatchlist);

            // PreviousAppraisalReport
            PreviousAppraisalReport = new (this, "x_PreviousAppraisalReport", 3, SqlDbType.Int) {
                Name = "PreviousAppraisalReport",
                Expression = "[PreviousAppraisalReport]",
                BasicSearchExpression = "CAST([PreviousAppraisalReport] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PreviousAppraisalReport]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "PreviousAppraisalReport", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PreviousAppraisalReport", PreviousAppraisalReport);

            // ContractBackgroundCheck
            ContractBackgroundCheck = new (this, "x_ContractBackgroundCheck", 3, SqlDbType.Int) {
                Name = "ContractBackgroundCheck",
                Expression = "[ContractBackgroundCheck]",
                BasicSearchExpression = "CAST([ContractBackgroundCheck] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[ContractBackgroundCheck]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "ContractBackgroundCheck", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ContractBackgroundCheck", ContractBackgroundCheck);

            // EnglishProficiencyTestOrMarline
            EnglishProficiencyTestOrMarline = new (this, "x_EnglishProficiencyTestOrMarline", 3, SqlDbType.Int) {
                Name = "EnglishProficiencyTestOrMarline",
                Expression = "[EnglishProficiencyTestOrMarline]",
                BasicSearchExpression = "CAST([EnglishProficiencyTestOrMarline] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[EnglishProficiencyTestOrMarline]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "EnglishProficiencyTestOrMarline", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("EnglishProficiencyTestOrMarline", EnglishProficiencyTestOrMarline);

            // Interviewed
            Interviewed = new (this, "x_Interviewed", 3, SqlDbType.Int) {
                Name = "Interviewed",
                Expression = "[Interviewed]",
                BasicSearchExpression = "CAST([Interviewed] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Interviewed]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "Interviewed", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Interviewed", Interviewed);

            // Approved
            Approved = new (this, "x_Approved", 3, SqlDbType.Int) {
                Name = "Approved",
                Expression = "[Approved]",
                BasicSearchExpression = "CAST([Approved] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Approved]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "Approved", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Approved", Approved);

            // MedicalCheckup
            MedicalCheckup = new (this, "x_MedicalCheckup", 3, SqlDbType.Int) {
                Name = "MedicalCheckup",
                Expression = "[MedicalCheckup]",
                BasicSearchExpression = "CAST([MedicalCheckup] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[MedicalCheckup]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "MedicalCheckup", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MedicalCheckup", MedicalCheckup);

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
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "CreatedBy", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("CreatedBy", CreatedBy);

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
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_CrewTrackingStatus", "LastUpdatedBy", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("LastUpdatedBy", LastUpdatedBy);

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
            get => _sqlFrom ?? "dbo.v_CrewTrackingStatus";
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
                ID.DbValue = row["ID"]; // Set DB value only
                IndividualCodeNumber.DbValue = row["IndividualCodeNumber"]; // Set DB value only
                FullName.DbValue = row["FullName"]; // Set DB value only
                RequiredPhoto.DbValue = row["RequiredPhoto"]; // Set DB value only
                VisaPhoto.DbValue = row["VisaPhoto"]; // Set DB value only
                Gender.DbValue = row["Gender"]; // Set DB value only
                RankAppliedFor.DbValue = row["RankAppliedFor"]; // Set DB value only
                WillAcceptLowRank.DbValue = (ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"); // Set DB value only
                EmployeeStatus.DbValue = row["EmployeeStatus"]; // Set DB value only
                Draft.DbValue = row["Draft"]; // Set DB value only
                Submitted.DbValue = row["Submitted"]; // Set DB value only
                Reviewed.DbValue = row["Reviewed"]; // Set DB value only
                RegistrationForm.DbValue = row["RegistrationForm"]; // Set DB value only
                PreScreeningInterview.DbValue = row["PreScreeningInterview"]; // Set DB value only
                MinimumRecruitmentCheck.DbValue = row["MinimumRecruitmentCheck"]; // Set DB value only
                EngagementChecklist.DbValue = row["EngagementChecklist"]; // Set DB value only
                COCAuthenticity.DbValue = row["COCAuthenticity"]; // Set DB value only
                CESTest.DbValue = row["CESTest"]; // Set DB value only
                PyschometricTest.DbValue = row["PyschometricTest"]; // Set DB value only
                CrewWatchlist.DbValue = row["CrewWatchlist"]; // Set DB value only
                PreviousAppraisalReport.DbValue = row["PreviousAppraisalReport"]; // Set DB value only
                ContractBackgroundCheck.DbValue = row["ContractBackgroundCheck"]; // Set DB value only
                EnglishProficiencyTestOrMarline.DbValue = row["EnglishProficiencyTestOrMarline"]; // Set DB value only
                Interviewed.DbValue = row["Interviewed"]; // Set DB value only
                Approved.DbValue = row["Approved"]; // Set DB value only
                MedicalCheckup.DbValue = row["MedicalCheckup"]; // Set DB value only
                CreatedBy.DbValue = row["CreatedBy"]; // Set DB value only
                LastUpdatedBy.DbValue = row["LastUpdatedBy"]; // Set DB value only
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
                    return "VCrewTrackingStatusList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "VCrewTrackingStatusView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "VCrewTrackingStatusEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "VCrewTrackingStatusAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "VCrewTrackingStatusList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "VCrewTrackingStatusView",
                Config.ApiAddAction => "VCrewTrackingStatusAdd",
                Config.ApiEditAction => "VCrewTrackingStatusEdit",
                Config.ApiDeleteAction => "VCrewTrackingStatusDelete",
                Config.ApiListAction => "VCrewTrackingStatusList",
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
        public string ListUrl => "VCrewTrackingStatusList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("VCrewTrackingStatusView", parm);
            else
                url = KeyUrl("VCrewTrackingStatusView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "VCrewTrackingStatusAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "VCrewTrackingStatusAdd?" + parm;
            else
                url = "VCrewTrackingStatusAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("VCrewTrackingStatusEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("VCrewTrackingStatusList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("VCrewTrackingStatusAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("VCrewTrackingStatusList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("VCrewTrackingStatusDelete")); // DN

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
            FullName.SetDbValue(dr["FullName"]);
            RequiredPhoto.SetDbValue(dr["RequiredPhoto"]);
            VisaPhoto.SetDbValue(dr["VisaPhoto"]);
            Gender.SetDbValue(dr["Gender"]);
            RankAppliedFor.SetDbValue(dr["RankAppliedFor"]);
            WillAcceptLowRank.SetDbValue(ConvertToBool(dr["WillAcceptLowRank"]) ? "1" : "0");
            EmployeeStatus.SetDbValue(dr["EmployeeStatus"]);
            Draft.SetDbValue(dr["Draft"]);
            Submitted.SetDbValue(dr["Submitted"]);
            Reviewed.SetDbValue(dr["Reviewed"]);
            RegistrationForm.SetDbValue(dr["RegistrationForm"]);
            PreScreeningInterview.SetDbValue(dr["PreScreeningInterview"]);
            MinimumRecruitmentCheck.SetDbValue(dr["MinimumRecruitmentCheck"]);
            EngagementChecklist.SetDbValue(dr["EngagementChecklist"]);
            COCAuthenticity.SetDbValue(dr["COCAuthenticity"]);
            CESTest.SetDbValue(dr["CESTest"]);
            PyschometricTest.SetDbValue(dr["PyschometricTest"]);
            CrewWatchlist.SetDbValue(dr["CrewWatchlist"]);
            PreviousAppraisalReport.SetDbValue(dr["PreviousAppraisalReport"]);
            ContractBackgroundCheck.SetDbValue(dr["ContractBackgroundCheck"]);
            EnglishProficiencyTestOrMarline.SetDbValue(dr["EnglishProficiencyTestOrMarline"]);
            Interviewed.SetDbValue(dr["Interviewed"]);
            Approved.SetDbValue(dr["Approved"]);
            MedicalCheckup.SetDbValue(dr["MedicalCheckup"]);
            CreatedBy.SetDbValue(dr["CreatedBy"]);
            LastUpdatedBy.SetDbValue(dr["LastUpdatedBy"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "VCrewTrackingStatusList";
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

            // FullName
            FullName.CellCssStyle = "white-space: nowrap;";

            // RequiredPhoto
            RequiredPhoto.CellCssStyle = "white-space: nowrap;";

            // VisaPhoto
            VisaPhoto.CellCssStyle = "white-space: nowrap;";

            // Gender
            Gender.CellCssStyle = "white-space: nowrap;";

            // RankAppliedFor
            RankAppliedFor.CellCssStyle = "white-space: nowrap;";

            // WillAcceptLowRank
            WillAcceptLowRank.CellCssStyle = "white-space: nowrap;";

            // EmployeeStatus
            EmployeeStatus.CellCssStyle = "white-space: nowrap;";

            // Draft
            Draft.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Submitted
            Submitted.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Reviewed
            Reviewed.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // RegistrationForm
            RegistrationForm.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PreScreeningInterview
            PreScreeningInterview.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // MinimumRecruitmentCheck
            MinimumRecruitmentCheck.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // EngagementChecklist
            EngagementChecklist.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // COCAuthenticity
            COCAuthenticity.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // CESTest
            CESTest.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PyschometricTest
            PyschometricTest.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // CrewWatchlist
            CrewWatchlist.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // PreviousAppraisalReport
            PreviousAppraisalReport.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // ContractBackgroundCheck
            ContractBackgroundCheck.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // EnglishProficiencyTestOrMarline
            EnglishProficiencyTestOrMarline.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Interviewed
            Interviewed.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // Approved
            Approved.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // MedicalCheckup
            MedicalCheckup.CellCssStyle = "min-width: 242px; white-space: nowrap;";

            // CreatedBy
            CreatedBy.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedBy
            LastUpdatedBy.CellCssStyle = "white-space: nowrap;";

            // ID
            ID.ViewValue = ID.CurrentValue;
            ID.ViewValue = FormatNumber(ID.ViewValue, ID.FormatPattern);
            ID.ViewCustomAttributes = "";

            // IndividualCodeNumber
            IndividualCodeNumber.ViewValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
            IndividualCodeNumber.ViewCustomAttributes = "";

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

            // EmployeeStatus
            EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
            EmployeeStatus.ViewCustomAttributes = "";

            // Draft
            Draft.ViewValue = Draft.CurrentValue;
            Draft.ViewValue = FormatNumber(Draft.ViewValue, Draft.FormatPattern);
            Draft.CellCssStyle += "text-align: center;";
            Draft.ViewCustomAttributes = "";

            // Submitted
            Submitted.ViewValue = Submitted.CurrentValue;
            Submitted.ViewValue = FormatNumber(Submitted.ViewValue, Submitted.FormatPattern);
            Submitted.CellCssStyle += "text-align: center;";
            Submitted.ViewCustomAttributes = "";

            // Reviewed
            Reviewed.ViewValue = Reviewed.CurrentValue;
            Reviewed.ViewValue = FormatNumber(Reviewed.ViewValue, Reviewed.FormatPattern);
            Reviewed.CellCssStyle += "text-align: center;";
            Reviewed.ViewCustomAttributes = "";

            // RegistrationForm
            RegistrationForm.ViewValue = RegistrationForm.CurrentValue;
            RegistrationForm.ViewValue = FormatNumber(RegistrationForm.ViewValue, RegistrationForm.FormatPattern);
            RegistrationForm.CellCssStyle += "text-align: center;";
            RegistrationForm.ViewCustomAttributes = "";

            // PreScreeningInterview
            PreScreeningInterview.ViewValue = PreScreeningInterview.CurrentValue;
            PreScreeningInterview.ViewValue = FormatNumber(PreScreeningInterview.ViewValue, PreScreeningInterview.FormatPattern);
            PreScreeningInterview.CellCssStyle += "text-align: center;";
            PreScreeningInterview.ViewCustomAttributes = "";

            // MinimumRecruitmentCheck
            MinimumRecruitmentCheck.ViewValue = MinimumRecruitmentCheck.CurrentValue;
            MinimumRecruitmentCheck.ViewValue = FormatNumber(MinimumRecruitmentCheck.ViewValue, MinimumRecruitmentCheck.FormatPattern);
            MinimumRecruitmentCheck.CellCssStyle += "text-align: center;";
            MinimumRecruitmentCheck.ViewCustomAttributes = "";

            // EngagementChecklist
            EngagementChecklist.ViewValue = EngagementChecklist.CurrentValue;
            EngagementChecklist.ViewValue = FormatNumber(EngagementChecklist.ViewValue, EngagementChecklist.FormatPattern);
            EngagementChecklist.CellCssStyle += "text-align: center;";
            EngagementChecklist.ViewCustomAttributes = "";

            // COCAuthenticity
            COCAuthenticity.ViewValue = COCAuthenticity.CurrentValue;
            COCAuthenticity.ViewValue = FormatNumber(COCAuthenticity.ViewValue, COCAuthenticity.FormatPattern);
            COCAuthenticity.CellCssStyle += "text-align: center;";
            COCAuthenticity.ViewCustomAttributes = "";

            // CESTest
            CESTest.ViewValue = CESTest.CurrentValue;
            CESTest.ViewValue = FormatNumber(CESTest.ViewValue, CESTest.FormatPattern);
            CESTest.CellCssStyle += "text-align: center;";
            CESTest.ViewCustomAttributes = "";

            // PyschometricTest
            PyschometricTest.ViewValue = PyschometricTest.CurrentValue;
            PyschometricTest.ViewValue = FormatNumber(PyschometricTest.ViewValue, PyschometricTest.FormatPattern);
            PyschometricTest.CellCssStyle += "text-align: center;";
            PyschometricTest.ViewCustomAttributes = "";

            // CrewWatchlist
            CrewWatchlist.ViewValue = CrewWatchlist.CurrentValue;
            CrewWatchlist.ViewValue = FormatNumber(CrewWatchlist.ViewValue, CrewWatchlist.FormatPattern);
            CrewWatchlist.CellCssStyle += "text-align: center;";
            CrewWatchlist.ViewCustomAttributes = "";

            // PreviousAppraisalReport
            PreviousAppraisalReport.ViewValue = PreviousAppraisalReport.CurrentValue;
            PreviousAppraisalReport.ViewValue = FormatNumber(PreviousAppraisalReport.ViewValue, PreviousAppraisalReport.FormatPattern);
            PreviousAppraisalReport.CellCssStyle += "text-align: center;";
            PreviousAppraisalReport.ViewCustomAttributes = "";

            // ContractBackgroundCheck
            ContractBackgroundCheck.ViewValue = ContractBackgroundCheck.CurrentValue;
            ContractBackgroundCheck.ViewValue = FormatNumber(ContractBackgroundCheck.ViewValue, ContractBackgroundCheck.FormatPattern);
            ContractBackgroundCheck.CellCssStyle += "text-align: center;";
            ContractBackgroundCheck.ViewCustomAttributes = "";

            // EnglishProficiencyTestOrMarline
            EnglishProficiencyTestOrMarline.ViewValue = EnglishProficiencyTestOrMarline.CurrentValue;
            EnglishProficiencyTestOrMarline.ViewValue = FormatNumber(EnglishProficiencyTestOrMarline.ViewValue, EnglishProficiencyTestOrMarline.FormatPattern);
            EnglishProficiencyTestOrMarline.CellCssStyle += "text-align: center;";
            EnglishProficiencyTestOrMarline.ViewCustomAttributes = "";

            // Interviewed
            Interviewed.ViewValue = Interviewed.CurrentValue;
            Interviewed.ViewValue = FormatNumber(Interviewed.ViewValue, Interviewed.FormatPattern);
            Interviewed.CellCssStyle += "text-align: center;";
            Interviewed.ViewCustomAttributes = "";

            // Approved
            Approved.ViewValue = Approved.CurrentValue;
            Approved.ViewValue = FormatNumber(Approved.ViewValue, Approved.FormatPattern);
            Approved.CellCssStyle += "text-align: center;";
            Approved.ViewCustomAttributes = "";

            // MedicalCheckup
            MedicalCheckup.ViewValue = MedicalCheckup.CurrentValue;
            MedicalCheckup.ViewValue = FormatNumber(MedicalCheckup.ViewValue, MedicalCheckup.FormatPattern);
            MedicalCheckup.CellCssStyle += "text-align: center;";
            MedicalCheckup.ViewCustomAttributes = "";

            // CreatedBy
            CreatedBy.ViewValue = ConvertToString(CreatedBy.CurrentValue); // DN
            CreatedBy.ViewCustomAttributes = "";

            // LastUpdatedBy
            LastUpdatedBy.ViewValue = ConvertToString(LastUpdatedBy.CurrentValue); // DN
            LastUpdatedBy.ViewCustomAttributes = "";

            // ID
            ID.HrefValue = "";
            ID.TooltipValue = "";

            // IndividualCodeNumber
            IndividualCodeNumber.HrefValue = "";
            IndividualCodeNumber.TooltipValue = "";

            // FullName
            FullName.HrefValue = "";
            FullName.TooltipValue = "";

            // RequiredPhoto
            RequiredPhoto.HrefValue = "";
            RequiredPhoto.TooltipValue = "";

            // VisaPhoto
            VisaPhoto.HrefValue = "";
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

            // EmployeeStatus
            EmployeeStatus.HrefValue = "";
            EmployeeStatus.TooltipValue = "";

            // Draft
            Draft.HrefValue = "";
            Draft.TooltipValue = "";

            // Submitted
            Submitted.HrefValue = "";
            Submitted.TooltipValue = "";

            // Reviewed
            Reviewed.HrefValue = "";
            Reviewed.TooltipValue = "";

            // RegistrationForm
            RegistrationForm.HrefValue = "";
            RegistrationForm.TooltipValue = "";

            // PreScreeningInterview
            PreScreeningInterview.HrefValue = "";
            PreScreeningInterview.TooltipValue = "";

            // MinimumRecruitmentCheck
            MinimumRecruitmentCheck.HrefValue = "";
            MinimumRecruitmentCheck.TooltipValue = "";

            // EngagementChecklist
            EngagementChecklist.HrefValue = "";
            EngagementChecklist.TooltipValue = "";

            // COCAuthenticity
            COCAuthenticity.HrefValue = "";
            COCAuthenticity.TooltipValue = "";

            // CESTest
            CESTest.HrefValue = "";
            CESTest.TooltipValue = "";

            // PyschometricTest
            PyschometricTest.HrefValue = "";
            PyschometricTest.TooltipValue = "";

            // CrewWatchlist
            CrewWatchlist.HrefValue = "";
            CrewWatchlist.TooltipValue = "";

            // PreviousAppraisalReport
            PreviousAppraisalReport.HrefValue = "";
            PreviousAppraisalReport.TooltipValue = "";

            // ContractBackgroundCheck
            ContractBackgroundCheck.HrefValue = "";
            ContractBackgroundCheck.TooltipValue = "";

            // EnglishProficiencyTestOrMarline
            EnglishProficiencyTestOrMarline.HrefValue = "";
            EnglishProficiencyTestOrMarline.TooltipValue = "";

            // Interviewed
            Interviewed.HrefValue = "";
            Interviewed.TooltipValue = "";

            // Approved
            Approved.HrefValue = "";
            Approved.TooltipValue = "";

            // MedicalCheckup
            MedicalCheckup.HrefValue = "";
            MedicalCheckup.TooltipValue = "";

            // CreatedBy
            CreatedBy.HrefValue = "";
            CreatedBy.TooltipValue = "";

            // LastUpdatedBy
            LastUpdatedBy.HrefValue = "";
            LastUpdatedBy.TooltipValue = "";

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
            ID.EditValue = ID.CurrentValue; // DN
            ID.PlaceHolder = RemoveHtml(ID.Caption);

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

            // EmployeeStatus
            EmployeeStatus.SetupEditAttributes();
            if (!EmployeeStatus.Raw)
                EmployeeStatus.CurrentValue = HtmlDecode(EmployeeStatus.CurrentValue);
            EmployeeStatus.EditValue = HtmlEncode(EmployeeStatus.CurrentValue);
            EmployeeStatus.PlaceHolder = RemoveHtml(EmployeeStatus.Caption);

            // Draft
            Draft.SetupEditAttributes();
            Draft.EditValue = Draft.CurrentValue; // DN
            Draft.PlaceHolder = RemoveHtml(Draft.Caption);
            if (!Empty(Draft.EditValue) && IsNumeric(Draft.EditValue))
                Draft.EditValue = FormatNumber(Draft.EditValue, null);

            // Submitted
            Submitted.SetupEditAttributes();
            Submitted.EditValue = Submitted.CurrentValue; // DN
            Submitted.PlaceHolder = RemoveHtml(Submitted.Caption);
            if (!Empty(Submitted.EditValue) && IsNumeric(Submitted.EditValue))
                Submitted.EditValue = FormatNumber(Submitted.EditValue, null);

            // Reviewed
            Reviewed.SetupEditAttributes();
            Reviewed.EditValue = Reviewed.CurrentValue; // DN
            Reviewed.PlaceHolder = RemoveHtml(Reviewed.Caption);
            if (!Empty(Reviewed.EditValue) && IsNumeric(Reviewed.EditValue))
                Reviewed.EditValue = FormatNumber(Reviewed.EditValue, null);

            // RegistrationForm
            RegistrationForm.SetupEditAttributes();
            RegistrationForm.EditValue = RegistrationForm.CurrentValue; // DN
            RegistrationForm.PlaceHolder = RemoveHtml(RegistrationForm.Caption);
            if (!Empty(RegistrationForm.EditValue) && IsNumeric(RegistrationForm.EditValue))
                RegistrationForm.EditValue = FormatNumber(RegistrationForm.EditValue, null);

            // PreScreeningInterview
            PreScreeningInterview.SetupEditAttributes();
            PreScreeningInterview.EditValue = PreScreeningInterview.CurrentValue; // DN
            PreScreeningInterview.PlaceHolder = RemoveHtml(PreScreeningInterview.Caption);
            if (!Empty(PreScreeningInterview.EditValue) && IsNumeric(PreScreeningInterview.EditValue))
                PreScreeningInterview.EditValue = FormatNumber(PreScreeningInterview.EditValue, null);

            // MinimumRecruitmentCheck
            MinimumRecruitmentCheck.SetupEditAttributes();
            MinimumRecruitmentCheck.EditValue = MinimumRecruitmentCheck.CurrentValue; // DN
            MinimumRecruitmentCheck.PlaceHolder = RemoveHtml(MinimumRecruitmentCheck.Caption);
            if (!Empty(MinimumRecruitmentCheck.EditValue) && IsNumeric(MinimumRecruitmentCheck.EditValue))
                MinimumRecruitmentCheck.EditValue = FormatNumber(MinimumRecruitmentCheck.EditValue, null);

            // EngagementChecklist
            EngagementChecklist.SetupEditAttributes();
            EngagementChecklist.EditValue = EngagementChecklist.CurrentValue; // DN
            EngagementChecklist.PlaceHolder = RemoveHtml(EngagementChecklist.Caption);
            if (!Empty(EngagementChecklist.EditValue) && IsNumeric(EngagementChecklist.EditValue))
                EngagementChecklist.EditValue = FormatNumber(EngagementChecklist.EditValue, null);

            // COCAuthenticity
            COCAuthenticity.SetupEditAttributes();
            COCAuthenticity.EditValue = COCAuthenticity.CurrentValue; // DN
            COCAuthenticity.PlaceHolder = RemoveHtml(COCAuthenticity.Caption);
            if (!Empty(COCAuthenticity.EditValue) && IsNumeric(COCAuthenticity.EditValue))
                COCAuthenticity.EditValue = FormatNumber(COCAuthenticity.EditValue, null);

            // CESTest
            CESTest.SetupEditAttributes();
            CESTest.EditValue = CESTest.CurrentValue; // DN
            CESTest.PlaceHolder = RemoveHtml(CESTest.Caption);
            if (!Empty(CESTest.EditValue) && IsNumeric(CESTest.EditValue))
                CESTest.EditValue = FormatNumber(CESTest.EditValue, null);

            // PyschometricTest
            PyschometricTest.SetupEditAttributes();
            PyschometricTest.EditValue = PyschometricTest.CurrentValue; // DN
            PyschometricTest.PlaceHolder = RemoveHtml(PyschometricTest.Caption);
            if (!Empty(PyschometricTest.EditValue) && IsNumeric(PyschometricTest.EditValue))
                PyschometricTest.EditValue = FormatNumber(PyschometricTest.EditValue, null);

            // CrewWatchlist
            CrewWatchlist.SetupEditAttributes();
            CrewWatchlist.EditValue = CrewWatchlist.CurrentValue; // DN
            CrewWatchlist.PlaceHolder = RemoveHtml(CrewWatchlist.Caption);
            if (!Empty(CrewWatchlist.EditValue) && IsNumeric(CrewWatchlist.EditValue))
                CrewWatchlist.EditValue = FormatNumber(CrewWatchlist.EditValue, null);

            // PreviousAppraisalReport
            PreviousAppraisalReport.SetupEditAttributes();
            PreviousAppraisalReport.EditValue = PreviousAppraisalReport.CurrentValue; // DN
            PreviousAppraisalReport.PlaceHolder = RemoveHtml(PreviousAppraisalReport.Caption);
            if (!Empty(PreviousAppraisalReport.EditValue) && IsNumeric(PreviousAppraisalReport.EditValue))
                PreviousAppraisalReport.EditValue = FormatNumber(PreviousAppraisalReport.EditValue, null);

            // ContractBackgroundCheck
            ContractBackgroundCheck.SetupEditAttributes();
            ContractBackgroundCheck.EditValue = ContractBackgroundCheck.CurrentValue; // DN
            ContractBackgroundCheck.PlaceHolder = RemoveHtml(ContractBackgroundCheck.Caption);
            if (!Empty(ContractBackgroundCheck.EditValue) && IsNumeric(ContractBackgroundCheck.EditValue))
                ContractBackgroundCheck.EditValue = FormatNumber(ContractBackgroundCheck.EditValue, null);

            // EnglishProficiencyTestOrMarline
            EnglishProficiencyTestOrMarline.SetupEditAttributes();
            EnglishProficiencyTestOrMarline.EditValue = EnglishProficiencyTestOrMarline.CurrentValue; // DN
            EnglishProficiencyTestOrMarline.PlaceHolder = RemoveHtml(EnglishProficiencyTestOrMarline.Caption);
            if (!Empty(EnglishProficiencyTestOrMarline.EditValue) && IsNumeric(EnglishProficiencyTestOrMarline.EditValue))
                EnglishProficiencyTestOrMarline.EditValue = FormatNumber(EnglishProficiencyTestOrMarline.EditValue, null);

            // Interviewed
            Interviewed.SetupEditAttributes();
            Interviewed.EditValue = Interviewed.CurrentValue; // DN
            Interviewed.PlaceHolder = RemoveHtml(Interviewed.Caption);
            if (!Empty(Interviewed.EditValue) && IsNumeric(Interviewed.EditValue))
                Interviewed.EditValue = FormatNumber(Interviewed.EditValue, null);

            // Approved
            Approved.SetupEditAttributes();
            Approved.EditValue = Approved.CurrentValue; // DN
            Approved.PlaceHolder = RemoveHtml(Approved.Caption);
            if (!Empty(Approved.EditValue) && IsNumeric(Approved.EditValue))
                Approved.EditValue = FormatNumber(Approved.EditValue, null);

            // MedicalCheckup
            MedicalCheckup.SetupEditAttributes();
            MedicalCheckup.EditValue = MedicalCheckup.CurrentValue; // DN
            MedicalCheckup.PlaceHolder = RemoveHtml(MedicalCheckup.Caption);
            if (!Empty(MedicalCheckup.EditValue) && IsNumeric(MedicalCheckup.EditValue))
                MedicalCheckup.EditValue = FormatNumber(MedicalCheckup.EditValue, null);

            // CreatedBy
            CreatedBy.SetupEditAttributes();
            if (!CreatedBy.Raw)
                CreatedBy.CurrentValue = HtmlDecode(CreatedBy.CurrentValue);
            CreatedBy.EditValue = HtmlEncode(CreatedBy.CurrentValue);
            CreatedBy.PlaceHolder = RemoveHtml(CreatedBy.Caption);

            // LastUpdatedBy
            LastUpdatedBy.SetupEditAttributes();
            if (!LastUpdatedBy.Raw)
                LastUpdatedBy.CurrentValue = HtmlDecode(LastUpdatedBy.CurrentValue);
            LastUpdatedBy.EditValue = HtmlEncode(LastUpdatedBy.CurrentValue);
            LastUpdatedBy.PlaceHolder = RemoveHtml(LastUpdatedBy.Caption);

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
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(RankAppliedFor);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(Draft);
                        doc.ExportCaption(Submitted);
                        doc.ExportCaption(Reviewed);
                        doc.ExportCaption(RegistrationForm);
                        doc.ExportCaption(PreScreeningInterview);
                        doc.ExportCaption(MinimumRecruitmentCheck);
                        doc.ExportCaption(EngagementChecklist);
                        doc.ExportCaption(COCAuthenticity);
                        doc.ExportCaption(CESTest);
                        doc.ExportCaption(PyschometricTest);
                        doc.ExportCaption(CrewWatchlist);
                        doc.ExportCaption(PreviousAppraisalReport);
                        doc.ExportCaption(ContractBackgroundCheck);
                        doc.ExportCaption(EnglishProficiencyTestOrMarline);
                        doc.ExportCaption(Interviewed);
                        doc.ExportCaption(Approved);
                        doc.ExportCaption(MedicalCheckup);
                        doc.ExportCaption(CreatedBy);
                        doc.ExportCaption(LastUpdatedBy);
                    } else {
                        doc.ExportCaption(IndividualCodeNumber);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(RankAppliedFor);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(Draft);
                        doc.ExportCaption(Submitted);
                        doc.ExportCaption(Reviewed);
                        doc.ExportCaption(RegistrationForm);
                        doc.ExportCaption(PreScreeningInterview);
                        doc.ExportCaption(MinimumRecruitmentCheck);
                        doc.ExportCaption(EngagementChecklist);
                        doc.ExportCaption(COCAuthenticity);
                        doc.ExportCaption(CESTest);
                        doc.ExportCaption(PyschometricTest);
                        doc.ExportCaption(CrewWatchlist);
                        doc.ExportCaption(PreviousAppraisalReport);
                        doc.ExportCaption(ContractBackgroundCheck);
                        doc.ExportCaption(EnglishProficiencyTestOrMarline);
                        doc.ExportCaption(Interviewed);
                        doc.ExportCaption(Approved);
                        doc.ExportCaption(MedicalCheckup);
                        doc.ExportCaption(CreatedBy);
                        doc.ExportCaption(LastUpdatedBy);
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
                            await doc.ExportField(FullName);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(Gender);
                            await doc.ExportField(RankAppliedFor);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(Draft);
                            await doc.ExportField(Submitted);
                            await doc.ExportField(Reviewed);
                            await doc.ExportField(RegistrationForm);
                            await doc.ExportField(PreScreeningInterview);
                            await doc.ExportField(MinimumRecruitmentCheck);
                            await doc.ExportField(EngagementChecklist);
                            await doc.ExportField(COCAuthenticity);
                            await doc.ExportField(CESTest);
                            await doc.ExportField(PyschometricTest);
                            await doc.ExportField(CrewWatchlist);
                            await doc.ExportField(PreviousAppraisalReport);
                            await doc.ExportField(ContractBackgroundCheck);
                            await doc.ExportField(EnglishProficiencyTestOrMarline);
                            await doc.ExportField(Interviewed);
                            await doc.ExportField(Approved);
                            await doc.ExportField(MedicalCheckup);
                            await doc.ExportField(CreatedBy);
                            await doc.ExportField(LastUpdatedBy);
                        } else {
                            await doc.ExportField(IndividualCodeNumber);
                            await doc.ExportField(FullName);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(Gender);
                            await doc.ExportField(RankAppliedFor);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(Draft);
                            await doc.ExportField(Submitted);
                            await doc.ExportField(Reviewed);
                            await doc.ExportField(RegistrationForm);
                            await doc.ExportField(PreScreeningInterview);
                            await doc.ExportField(MinimumRecruitmentCheck);
                            await doc.ExportField(EngagementChecklist);
                            await doc.ExportField(COCAuthenticity);
                            await doc.ExportField(CESTest);
                            await doc.ExportField(PyschometricTest);
                            await doc.ExportField(CrewWatchlist);
                            await doc.ExportField(PreviousAppraisalReport);
                            await doc.ExportField(ContractBackgroundCheck);
                            await doc.ExportField(EnglishProficiencyTestOrMarline);
                            await doc.ExportField(Interviewed);
                            await doc.ExportField(Approved);
                            await doc.ExportField(MedicalCheckup);
                            await doc.ExportField(CreatedBy);
                            await doc.ExportField(LastUpdatedBy);
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
