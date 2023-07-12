namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// vChecklist
    /// </summary>
    [MaybeNull]
    public static VChecklist vChecklist
    {
        get => HttpData.Resolve<VChecklist>("v_Checklist");
        set => HttpData["v_Checklist"] = value;
    }

    /// <summary>
    /// Table class for v_Checklist
    /// </summary>
    public class VChecklist : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> DocumentDate;

        public readonly DbField<SqlDbType> RequiredPhoto;

        public readonly DbField<SqlDbType> VisaPhoto;

        public readonly DbField<SqlDbType> CityOfBirth;

        public readonly DbField<SqlDbType> DateOfBirth;

        public readonly DbField<SqlDbType> RankAppliedFor_RankID;

        public readonly DbField<SqlDbType> WillAcceptLowRank;

        public readonly DbField<SqlDbType> AvailableFrom;

        public readonly DbField<SqlDbType> AvailableUntil;

        public readonly DbField<SqlDbType> Activity10;

        public readonly DbField<SqlDbType> RemarkActivity10;

        public readonly DbField<SqlDbType> Activity11;

        public readonly DbField<SqlDbType> RemarkActivity11;

        public readonly DbField<SqlDbType> Activity12;

        public readonly DbField<SqlDbType> RemarkActivity12;

        public readonly DbField<SqlDbType> Activity13;

        public readonly DbField<SqlDbType> RemarkActivity13;

        public readonly DbField<SqlDbType> Activity14;

        public readonly DbField<SqlDbType> RemarkActivity14;

        public readonly DbField<SqlDbType> Activity20;

        public readonly DbField<SqlDbType> RemarkActivity20;

        public readonly DbField<SqlDbType> Activity30;

        public readonly DbField<SqlDbType> RemarkActivity30;

        public readonly DbField<SqlDbType> Activity40;

        public readonly DbField<SqlDbType> RemarkActivity40;

        public readonly DbField<SqlDbType> Activity50;

        public readonly DbField<SqlDbType> RemarkActivity50;

        public readonly DbField<SqlDbType> Activity60;

        public readonly DbField<SqlDbType> RemarkActivity60;

        public readonly DbField<SqlDbType> Activity70;

        public readonly DbField<SqlDbType> RemarkActivity70;

        public readonly DbField<SqlDbType> InterviewerComment;

        public readonly DbField<SqlDbType> FinalInterviewComment;

        public readonly DbField<SqlDbType> JobKnowledge;

        public readonly DbField<SqlDbType> SafetyAwareness;

        public readonly DbField<SqlDbType> Personality;

        public readonly DbField<SqlDbType> EnglishProficiency;

        public readonly DbField<SqlDbType> PrincipalComment;

        public readonly DbField<SqlDbType> IndividualCodeNumber;

        public readonly DbField<SqlDbType> EmployeeStatus;

        public readonly DbField<SqlDbType> AssistantManagerPdeReviewedDate;

        public readonly DbField<SqlDbType> InterviewedByPersonTwoName;

        public readonly DbField<SqlDbType> InterviewedByPersonTwoRank;

        public readonly DbField<SqlDbType> InterviewedByPersonTwoDate;

        public readonly DbField<SqlDbType> InterviewedByPersonThreeName;

        public readonly DbField<SqlDbType> InterviewedByPersonThreeRank;

        public readonly DbField<SqlDbType> InterviewedByPersonThreeDate;

        public readonly DbField<SqlDbType> CrewingManagerApprovalDate;

        public readonly DbField<SqlDbType> ChecklistId;

        public readonly DbField<SqlDbType> FullName;

        public readonly DbField<SqlDbType> ManningAgent;

        public readonly DbField<SqlDbType> VesselName;

        public readonly DbField<SqlDbType> Performance;

        public readonly DbField<SqlDbType> DateChecked;

        public readonly DbField<SqlDbType> InterviewedByPersonOneName;

        public readonly DbField<SqlDbType> InterviewedByPersonOneRank;

        public readonly DbField<SqlDbType> InterviewedByPersonOneDate;

        public readonly DbField<SqlDbType> InterviewDate;

        public readonly DbField<SqlDbType> AssistantManagerPdeName;

        public readonly DbField<SqlDbType> CrewingManagerName;

        // Constructor
        public VChecklist()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "v_Checklist";
            Name = "v_Checklist";
            Type = "VIEW";
            UpdateTable = "dbo.v_Checklist"; // Update Table
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

            // DocumentDate
            DocumentDate = new (this, "x_DocumentDate", 133, SqlDbType.DateTime) {
                Name = "DocumentDate",
                Expression = "[DocumentDate]",
                BasicSearchExpression = CastDateFieldForLike("[DocumentDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[DocumentDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "DocumentDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("DocumentDate", DocumentDate);

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
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RequiredPhoto", "CustomMsg"),
                IsUpload = false
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
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "VisaPhoto", "CustomMsg"),
                IsUpload = false
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
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "CityOfBirth", "CustomMsg"),
                IsUpload = false
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
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "DateOfBirth", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("DateOfBirth", DateOfBirth);

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
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RankAppliedFor_RankID", "CustomMsg"),
                IsUpload = false
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
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "WillAcceptLowRank", "CustomMsg"),
                IsUpload = false
            };
            WillAcceptLowRank.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("WillAcceptLowRank", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("WillAcceptLowRank", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("WillAcceptLowRank", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "AvailableFrom", "CustomMsg"),
                IsUpload = false
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
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "AvailableUntil", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AvailableUntil", AvailableUntil);

            // Activity10
            Activity10 = new (this, "x_Activity10", 11, SqlDbType.Bit) {
                Name = "Activity10",
                Expression = "[Activity10]",
                BasicSearchExpression = "[Activity10]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity10]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity10", "CustomMsg"),
                IsUpload = false
            };
            Activity10.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity10", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity10", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity10", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity10", Activity10);

            // RemarkActivity10
            RemarkActivity10 = new (this, "x_RemarkActivity10", 203, SqlDbType.NText) {
                Name = "RemarkActivity10",
                Expression = "[RemarkActivity10]",
                BasicSearchExpression = "[RemarkActivity10]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity10]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity10", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity10", RemarkActivity10);

            // Activity11
            Activity11 = new (this, "x_Activity11", 11, SqlDbType.Bit) {
                Name = "Activity11",
                Expression = "[Activity11]",
                BasicSearchExpression = "[Activity11]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity11]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity11", "CustomMsg"),
                IsUpload = false
            };
            Activity11.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity11", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity11", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity11", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity11", Activity11);

            // RemarkActivity11
            RemarkActivity11 = new (this, "x_RemarkActivity11", 203, SqlDbType.NText) {
                Name = "RemarkActivity11",
                Expression = "[RemarkActivity11]",
                BasicSearchExpression = "[RemarkActivity11]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity11]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity11", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity11", RemarkActivity11);

            // Activity12
            Activity12 = new (this, "x_Activity12", 11, SqlDbType.Bit) {
                Name = "Activity12",
                Expression = "[Activity12]",
                BasicSearchExpression = "[Activity12]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity12]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity12", "CustomMsg"),
                IsUpload = false
            };
            Activity12.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity12", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity12", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity12", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity12", Activity12);

            // RemarkActivity12
            RemarkActivity12 = new (this, "x_RemarkActivity12", 203, SqlDbType.NText) {
                Name = "RemarkActivity12",
                Expression = "[RemarkActivity12]",
                BasicSearchExpression = "[RemarkActivity12]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity12]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity12", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity12", RemarkActivity12);

            // Activity13
            Activity13 = new (this, "x_Activity13", 11, SqlDbType.Bit) {
                Name = "Activity13",
                Expression = "[Activity13]",
                BasicSearchExpression = "[Activity13]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity13]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity13", "CustomMsg"),
                IsUpload = false
            };
            Activity13.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity13", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity13", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity13", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity13", Activity13);

            // RemarkActivity13
            RemarkActivity13 = new (this, "x_RemarkActivity13", 203, SqlDbType.NText) {
                Name = "RemarkActivity13",
                Expression = "[RemarkActivity13]",
                BasicSearchExpression = "[RemarkActivity13]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity13]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity13", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity13", RemarkActivity13);

            // Activity14
            Activity14 = new (this, "x_Activity14", 11, SqlDbType.Bit) {
                Name = "Activity14",
                Expression = "[Activity14]",
                BasicSearchExpression = "[Activity14]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity14]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity14", "CustomMsg"),
                IsUpload = false
            };
            Activity14.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity14", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity14", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity14", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity14", Activity14);

            // RemarkActivity14
            RemarkActivity14 = new (this, "x_RemarkActivity14", 203, SqlDbType.NText) {
                Name = "RemarkActivity14",
                Expression = "[RemarkActivity14]",
                BasicSearchExpression = "[RemarkActivity14]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity14]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity14", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity14", RemarkActivity14);

            // Activity20
            Activity20 = new (this, "x_Activity20", 11, SqlDbType.Bit) {
                Name = "Activity20",
                Expression = "[Activity20]",
                BasicSearchExpression = "[Activity20]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity20]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity20", "CustomMsg"),
                IsUpload = false
            };
            Activity20.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity20", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity20", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity20", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity20", Activity20);

            // RemarkActivity20
            RemarkActivity20 = new (this, "x_RemarkActivity20", 203, SqlDbType.NText) {
                Name = "RemarkActivity20",
                Expression = "[RemarkActivity20]",
                BasicSearchExpression = "[RemarkActivity20]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity20]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity20", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity20", RemarkActivity20);

            // Activity30
            Activity30 = new (this, "x_Activity30", 11, SqlDbType.Bit) {
                Name = "Activity30",
                Expression = "[Activity30]",
                BasicSearchExpression = "[Activity30]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity30]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity30", "CustomMsg"),
                IsUpload = false
            };
            Activity30.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity30", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity30", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity30", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity30", Activity30);

            // RemarkActivity30
            RemarkActivity30 = new (this, "x_RemarkActivity30", 203, SqlDbType.NText) {
                Name = "RemarkActivity30",
                Expression = "[RemarkActivity30]",
                BasicSearchExpression = "[RemarkActivity30]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity30]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity30", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity30", RemarkActivity30);

            // Activity40
            Activity40 = new (this, "x_Activity40", 11, SqlDbType.Bit) {
                Name = "Activity40",
                Expression = "[Activity40]",
                BasicSearchExpression = "[Activity40]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity40]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity40", "CustomMsg"),
                IsUpload = false
            };
            Activity40.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity40", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity40", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity40", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity40", Activity40);

            // RemarkActivity40
            RemarkActivity40 = new (this, "x_RemarkActivity40", 203, SqlDbType.NText) {
                Name = "RemarkActivity40",
                Expression = "[RemarkActivity40]",
                BasicSearchExpression = "[RemarkActivity40]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity40]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity40", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity40", RemarkActivity40);

            // Activity50
            Activity50 = new (this, "x_Activity50", 11, SqlDbType.Bit) {
                Name = "Activity50",
                Expression = "[Activity50]",
                BasicSearchExpression = "[Activity50]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity50]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity50", "CustomMsg"),
                IsUpload = false
            };
            Activity50.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity50", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity50", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity50", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity50", Activity50);

            // RemarkActivity50
            RemarkActivity50 = new (this, "x_RemarkActivity50", 203, SqlDbType.NText) {
                Name = "RemarkActivity50",
                Expression = "[RemarkActivity50]",
                BasicSearchExpression = "[RemarkActivity50]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity50]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity50", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity50", RemarkActivity50);

            // Activity60
            Activity60 = new (this, "x_Activity60", 11, SqlDbType.Bit) {
                Name = "Activity60",
                Expression = "[Activity60]",
                BasicSearchExpression = "[Activity60]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity60]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity60", "CustomMsg"),
                IsUpload = false
            };
            Activity60.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity60", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity60", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity60", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity60", Activity60);

            // RemarkActivity60
            RemarkActivity60 = new (this, "x_RemarkActivity60", 203, SqlDbType.NText) {
                Name = "RemarkActivity60",
                Expression = "[RemarkActivity60]",
                BasicSearchExpression = "[RemarkActivity60]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity60]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity60", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity60", RemarkActivity60);

            // Activity70
            Activity70 = new (this, "x_Activity70", 11, SqlDbType.Bit) {
                Name = "Activity70",
                Expression = "[Activity70]",
                BasicSearchExpression = "[Activity70]",
                DateTimeFormat = -1,
                VirtualExpression = "[Activity70]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Activity70", "CustomMsg"),
                IsUpload = false
            };
            Activity70.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity70", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity70", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity70", "v_Checklist", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity70", Activity70);

            // RemarkActivity70
            RemarkActivity70 = new (this, "x_RemarkActivity70", 203, SqlDbType.NText) {
                Name = "RemarkActivity70",
                Expression = "[RemarkActivity70]",
                BasicSearchExpression = "[RemarkActivity70]",
                DateTimeFormat = -1,
                VirtualExpression = "[RemarkActivity70]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "RemarkActivity70", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity70", RemarkActivity70);

            // InterviewerComment
            InterviewerComment = new (this, "x_InterviewerComment", 202, SqlDbType.NVarChar) {
                Name = "InterviewerComment",
                Expression = "[InterviewerComment]",
                UseBasicSearch = true,
                BasicSearchExpression = "[InterviewerComment]",
                DateTimeFormat = -1,
                VirtualExpression = "[InterviewerComment]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewerComment", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewerComment", InterviewerComment);

            // FinalInterviewComment
            FinalInterviewComment = new (this, "x_FinalInterviewComment", 202, SqlDbType.NVarChar) {
                Name = "FinalInterviewComment",
                Expression = "[FinalInterviewComment]",
                UseBasicSearch = true,
                BasicSearchExpression = "[FinalInterviewComment]",
                DateTimeFormat = -1,
                VirtualExpression = "[FinalInterviewComment]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "FinalInterviewComment", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("FinalInterviewComment", FinalInterviewComment);

            // JobKnowledge
            JobKnowledge = new (this, "x_JobKnowledge", 202, SqlDbType.NVarChar) {
                Name = "JobKnowledge",
                Expression = "[JobKnowledge]",
                UseBasicSearch = true,
                BasicSearchExpression = "[JobKnowledge]",
                DateTimeFormat = -1,
                VirtualExpression = "[JobKnowledge]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "JobKnowledge", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("JobKnowledge", JobKnowledge);

            // SafetyAwareness
            SafetyAwareness = new (this, "x_SafetyAwareness", 202, SqlDbType.NVarChar) {
                Name = "SafetyAwareness",
                Expression = "[SafetyAwareness]",
                UseBasicSearch = true,
                BasicSearchExpression = "[SafetyAwareness]",
                DateTimeFormat = -1,
                VirtualExpression = "[SafetyAwareness]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "SafetyAwareness", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("SafetyAwareness", SafetyAwareness);

            // Personality
            Personality = new (this, "x_Personality", 202, SqlDbType.NVarChar) {
                Name = "Personality",
                Expression = "[Personality]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Personality]",
                DateTimeFormat = -1,
                VirtualExpression = "[Personality]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Personality", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Personality", Personality);

            // EnglishProficiency
            EnglishProficiency = new (this, "x_EnglishProficiency", 202, SqlDbType.NVarChar) {
                Name = "EnglishProficiency",
                Expression = "[EnglishProficiency]",
                UseBasicSearch = true,
                BasicSearchExpression = "[EnglishProficiency]",
                DateTimeFormat = -1,
                VirtualExpression = "[EnglishProficiency]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "EnglishProficiency", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("EnglishProficiency", EnglishProficiency);

            // PrincipalComment
            PrincipalComment = new (this, "x_PrincipalComment", 202, SqlDbType.NVarChar) {
                Name = "PrincipalComment",
                Expression = "[PrincipalComment]",
                UseBasicSearch = true,
                BasicSearchExpression = "[PrincipalComment]",
                DateTimeFormat = -1,
                VirtualExpression = "[PrincipalComment]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "PrincipalComment", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrincipalComment", PrincipalComment);

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
                CustomMessage = Language.FieldPhrase("v_Checklist", "IndividualCodeNumber", "CustomMsg"),
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
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "EmployeeStatus", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("EmployeeStatus", EmployeeStatus);

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate = new (this, "x_AssistantManagerPdeReviewedDate", 133, SqlDbType.DateTime) {
                Name = "AssistantManagerPdeReviewedDate",
                Expression = "[AssistantManagerPdeReviewedDate]",
                BasicSearchExpression = CastDateFieldForLike("[AssistantManagerPdeReviewedDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[AssistantManagerPdeReviewedDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "AssistantManagerPdeReviewedDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AssistantManagerPdeReviewedDate", AssistantManagerPdeReviewedDate);

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName = new (this, "x_InterviewedByPersonTwoName", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonTwoName",
                Expression = "[InterviewedByPersonTwoName]",
                UseBasicSearch = true,
                BasicSearchExpression = "[InterviewedByPersonTwoName]",
                DateTimeFormat = -1,
                VirtualExpression = "[InterviewedByPersonTwoName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewedByPersonTwoName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonTwoName", InterviewedByPersonTwoName);

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank = new (this, "x_InterviewedByPersonTwoRank", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonTwoRank",
                Expression = "[InterviewedByPersonTwoRank]",
                UseBasicSearch = true,
                BasicSearchExpression = "[InterviewedByPersonTwoRank]",
                DateTimeFormat = -1,
                VirtualExpression = "[InterviewedByPersonTwoRank]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewedByPersonTwoRank", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonTwoRank", InterviewedByPersonTwoRank);

            // InterviewedByPersonTwoDate
            InterviewedByPersonTwoDate = new (this, "x_InterviewedByPersonTwoDate", 133, SqlDbType.DateTime) {
                Name = "InterviewedByPersonTwoDate",
                Expression = "[InterviewedByPersonTwoDate]",
                BasicSearchExpression = CastDateFieldForLike("[InterviewedByPersonTwoDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[InterviewedByPersonTwoDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewedByPersonTwoDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonTwoDate", InterviewedByPersonTwoDate);

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName = new (this, "x_InterviewedByPersonThreeName", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonThreeName",
                Expression = "[InterviewedByPersonThreeName]",
                UseBasicSearch = true,
                BasicSearchExpression = "[InterviewedByPersonThreeName]",
                DateTimeFormat = -1,
                VirtualExpression = "[InterviewedByPersonThreeName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewedByPersonThreeName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonThreeName", InterviewedByPersonThreeName);

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank = new (this, "x_InterviewedByPersonThreeRank", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonThreeRank",
                Expression = "[InterviewedByPersonThreeRank]",
                UseBasicSearch = true,
                BasicSearchExpression = "[InterviewedByPersonThreeRank]",
                DateTimeFormat = -1,
                VirtualExpression = "[InterviewedByPersonThreeRank]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewedByPersonThreeRank", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonThreeRank", InterviewedByPersonThreeRank);

            // InterviewedByPersonThreeDate
            InterviewedByPersonThreeDate = new (this, "x_InterviewedByPersonThreeDate", 133, SqlDbType.DateTime) {
                Name = "InterviewedByPersonThreeDate",
                Expression = "[InterviewedByPersonThreeDate]",
                BasicSearchExpression = CastDateFieldForLike("[InterviewedByPersonThreeDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[InterviewedByPersonThreeDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewedByPersonThreeDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonThreeDate", InterviewedByPersonThreeDate);

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate = new (this, "x_CrewingManagerApprovalDate", 133, SqlDbType.DateTime) {
                Name = "CrewingManagerApprovalDate",
                Expression = "[CrewingManagerApprovalDate]",
                BasicSearchExpression = CastDateFieldForLike("[CrewingManagerApprovalDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[CrewingManagerApprovalDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "CrewingManagerApprovalDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("CrewingManagerApprovalDate", CrewingManagerApprovalDate);

            // ChecklistId
            ChecklistId = new (this, "x_ChecklistId", 3, SqlDbType.Int) {
                Name = "ChecklistId",
                Expression = "[ChecklistId]",
                BasicSearchExpression = "CAST([ChecklistId] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[ChecklistId]",
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
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "ChecklistId", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ChecklistId", ChecklistId);

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
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "FullName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("FullName", FullName);

            // ManningAgent
            ManningAgent = new (this, "x_ManningAgent", 202, SqlDbType.NVarChar) {
                Name = "ManningAgent",
                Expression = "[ManningAgent]",
                UseBasicSearch = true,
                BasicSearchExpression = "[ManningAgent]",
                DateTimeFormat = -1,
                VirtualExpression = "[ManningAgent]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "ManningAgent", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ManningAgent", ManningAgent);

            // VesselName
            VesselName = new (this, "x_VesselName", 202, SqlDbType.NVarChar) {
                Name = "VesselName",
                Expression = "[VesselName]",
                UseBasicSearch = true,
                BasicSearchExpression = "[VesselName]",
                DateTimeFormat = -1,
                VirtualExpression = "[VesselName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "VesselName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("VesselName", VesselName);

            // Performance
            Performance = new (this, "x_Performance", 202, SqlDbType.NVarChar) {
                Name = "Performance",
                Expression = "[Performance]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Performance]",
                DateTimeFormat = -1,
                VirtualExpression = "[Performance]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "Performance", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Performance", Performance);

            // DateChecked
            DateChecked = new (this, "x_DateChecked", 133, SqlDbType.DateTime) {
                Name = "DateChecked",
                Expression = "[DateChecked]",
                BasicSearchExpression = CastDateFieldForLike("[DateChecked]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[DateChecked]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "DateChecked", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("DateChecked", DateChecked);

            // InterviewedByPersonOneName
            InterviewedByPersonOneName = new (this, "x_InterviewedByPersonOneName", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonOneName",
                Expression = "[InterviewedByPersonOneName]",
                UseBasicSearch = true,
                BasicSearchExpression = "[InterviewedByPersonOneName]",
                DateTimeFormat = -1,
                VirtualExpression = "[InterviewedByPersonOneName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewedByPersonOneName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonOneName", InterviewedByPersonOneName);

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank = new (this, "x_InterviewedByPersonOneRank", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonOneRank",
                Expression = "[InterviewedByPersonOneRank]",
                UseBasicSearch = true,
                BasicSearchExpression = "[InterviewedByPersonOneRank]",
                DateTimeFormat = -1,
                VirtualExpression = "[InterviewedByPersonOneRank]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewedByPersonOneRank", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonOneRank", InterviewedByPersonOneRank);

            // InterviewedByPersonOneDate
            InterviewedByPersonOneDate = new (this, "x_InterviewedByPersonOneDate", 133, SqlDbType.DateTime) {
                Name = "InterviewedByPersonOneDate",
                Expression = "[InterviewedByPersonOneDate]",
                BasicSearchExpression = CastDateFieldForLike("[InterviewedByPersonOneDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[InterviewedByPersonOneDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewedByPersonOneDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonOneDate", InterviewedByPersonOneDate);

            // InterviewDate
            InterviewDate = new (this, "x_InterviewDate", 133, SqlDbType.DateTime) {
                Name = "InterviewDate",
                Expression = "[InterviewDate]",
                BasicSearchExpression = CastDateFieldForLike("[InterviewDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[InterviewDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "InterviewDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewDate", InterviewDate);

            // AssistantManagerPdeName
            AssistantManagerPdeName = new (this, "x_AssistantManagerPdeName", 202, SqlDbType.NVarChar) {
                Name = "AssistantManagerPdeName",
                Expression = "[AssistantManagerPdeName]",
                UseBasicSearch = true,
                BasicSearchExpression = "[AssistantManagerPdeName]",
                DateTimeFormat = -1,
                VirtualExpression = "[AssistantManagerPdeName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "AssistantManagerPdeName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AssistantManagerPdeName", AssistantManagerPdeName);

            // CrewingManagerName
            CrewingManagerName = new (this, "x_CrewingManagerName", 202, SqlDbType.NVarChar) {
                Name = "CrewingManagerName",
                Expression = "[CrewingManagerName]",
                UseBasicSearch = true,
                BasicSearchExpression = "[CrewingManagerName]",
                DateTimeFormat = -1,
                VirtualExpression = "[CrewingManagerName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_Checklist", "CrewingManagerName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("CrewingManagerName", CrewingManagerName);

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
            get => _sqlFrom ?? "dbo.v_Checklist";
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
                DocumentDate.DbValue = row["DocumentDate"]; // Set DB value only
                RequiredPhoto.DbValue = row["RequiredPhoto"]; // Set DB value only
                VisaPhoto.DbValue = row["VisaPhoto"]; // Set DB value only
                CityOfBirth.DbValue = row["CityOfBirth"]; // Set DB value only
                DateOfBirth.DbValue = row["DateOfBirth"]; // Set DB value only
                RankAppliedFor_RankID.DbValue = row["RankAppliedFor_RankID"]; // Set DB value only
                WillAcceptLowRank.DbValue = (ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"); // Set DB value only
                AvailableFrom.DbValue = row["AvailableFrom"]; // Set DB value only
                AvailableUntil.DbValue = row["AvailableUntil"]; // Set DB value only
                Activity10.DbValue = (ConvertToBool(row["Activity10"]) ? "1" : "0"); // Set DB value only
                RemarkActivity10.DbValue = row["RemarkActivity10"]; // Set DB value only
                Activity11.DbValue = (ConvertToBool(row["Activity11"]) ? "1" : "0"); // Set DB value only
                RemarkActivity11.DbValue = row["RemarkActivity11"]; // Set DB value only
                Activity12.DbValue = (ConvertToBool(row["Activity12"]) ? "1" : "0"); // Set DB value only
                RemarkActivity12.DbValue = row["RemarkActivity12"]; // Set DB value only
                Activity13.DbValue = (ConvertToBool(row["Activity13"]) ? "1" : "0"); // Set DB value only
                RemarkActivity13.DbValue = row["RemarkActivity13"]; // Set DB value only
                Activity14.DbValue = (ConvertToBool(row["Activity14"]) ? "1" : "0"); // Set DB value only
                RemarkActivity14.DbValue = row["RemarkActivity14"]; // Set DB value only
                Activity20.DbValue = (ConvertToBool(row["Activity20"]) ? "1" : "0"); // Set DB value only
                RemarkActivity20.DbValue = row["RemarkActivity20"]; // Set DB value only
                Activity30.DbValue = (ConvertToBool(row["Activity30"]) ? "1" : "0"); // Set DB value only
                RemarkActivity30.DbValue = row["RemarkActivity30"]; // Set DB value only
                Activity40.DbValue = (ConvertToBool(row["Activity40"]) ? "1" : "0"); // Set DB value only
                RemarkActivity40.DbValue = row["RemarkActivity40"]; // Set DB value only
                Activity50.DbValue = (ConvertToBool(row["Activity50"]) ? "1" : "0"); // Set DB value only
                RemarkActivity50.DbValue = row["RemarkActivity50"]; // Set DB value only
                Activity60.DbValue = (ConvertToBool(row["Activity60"]) ? "1" : "0"); // Set DB value only
                RemarkActivity60.DbValue = row["RemarkActivity60"]; // Set DB value only
                Activity70.DbValue = (ConvertToBool(row["Activity70"]) ? "1" : "0"); // Set DB value only
                RemarkActivity70.DbValue = row["RemarkActivity70"]; // Set DB value only
                InterviewerComment.DbValue = row["InterviewerComment"]; // Set DB value only
                FinalInterviewComment.DbValue = row["FinalInterviewComment"]; // Set DB value only
                JobKnowledge.DbValue = row["JobKnowledge"]; // Set DB value only
                SafetyAwareness.DbValue = row["SafetyAwareness"]; // Set DB value only
                Personality.DbValue = row["Personality"]; // Set DB value only
                EnglishProficiency.DbValue = row["EnglishProficiency"]; // Set DB value only
                PrincipalComment.DbValue = row["PrincipalComment"]; // Set DB value only
                IndividualCodeNumber.DbValue = row["IndividualCodeNumber"]; // Set DB value only
                EmployeeStatus.DbValue = row["EmployeeStatus"]; // Set DB value only
                AssistantManagerPdeReviewedDate.DbValue = row["AssistantManagerPdeReviewedDate"]; // Set DB value only
                InterviewedByPersonTwoName.DbValue = row["InterviewedByPersonTwoName"]; // Set DB value only
                InterviewedByPersonTwoRank.DbValue = row["InterviewedByPersonTwoRank"]; // Set DB value only
                InterviewedByPersonTwoDate.DbValue = row["InterviewedByPersonTwoDate"]; // Set DB value only
                InterviewedByPersonThreeName.DbValue = row["InterviewedByPersonThreeName"]; // Set DB value only
                InterviewedByPersonThreeRank.DbValue = row["InterviewedByPersonThreeRank"]; // Set DB value only
                InterviewedByPersonThreeDate.DbValue = row["InterviewedByPersonThreeDate"]; // Set DB value only
                CrewingManagerApprovalDate.DbValue = row["CrewingManagerApprovalDate"]; // Set DB value only
                ChecklistId.DbValue = row["ChecklistId"]; // Set DB value only
                FullName.DbValue = row["FullName"]; // Set DB value only
                ManningAgent.DbValue = row["ManningAgent"]; // Set DB value only
                VesselName.DbValue = row["VesselName"]; // Set DB value only
                Performance.DbValue = row["Performance"]; // Set DB value only
                DateChecked.DbValue = row["DateChecked"]; // Set DB value only
                InterviewedByPersonOneName.DbValue = row["InterviewedByPersonOneName"]; // Set DB value only
                InterviewedByPersonOneRank.DbValue = row["InterviewedByPersonOneRank"]; // Set DB value only
                InterviewedByPersonOneDate.DbValue = row["InterviewedByPersonOneDate"]; // Set DB value only
                InterviewDate.DbValue = row["InterviewDate"]; // Set DB value only
                AssistantManagerPdeName.DbValue = row["AssistantManagerPdeName"]; // Set DB value only
                CrewingManagerName.DbValue = row["CrewingManagerName"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "[ChecklistId] = @ChecklistId@";

        #pragma warning disable 168, 219
        // Get record filter as string
        public string GetRecordFilter(Dictionary<string, object>? row = null, bool current = false)
        {
            string keyFilter = _sqlKeyFilter;
            object? val = null, result = "";
            val = row?.TryGetValue("ChecklistId", out result) ?? false
                ? result
                : !Empty(ChecklistId.OldValue) && !current ? ChecklistId.OldValue : ChecklistId.CurrentValue;
            if (!IsNumeric(val))
                return "0=1"; // Invalid key
            if (val == null)
                return "0=1"; // Invalid key
            keyFilter = keyFilter.Replace("@ChecklistId@", AdjustSql(val, DbId)); // Replace key value
            return keyFilter;
        }

        // Get record filter as Dictionary // DN
        public Dictionary<string, object>? GetRowFilterAsDictionary(IDictionary<string, object>? row = null)
        {
            Dictionary<string, object>? keyFilter = new ();
            object? val = null, result;
            val = row?.TryGetValue("ChecklistId", out result) ?? false
                ? result
                : !Empty(ChecklistId.OldValue) ? ChecklistId.OldValue : ChecklistId.CurrentValue;
            if (!IsNumeric(val))
                return null; // Invalid key
            if (Empty(val))
                return null; // Invalid key
            keyFilter.Add("ChecklistId", val); // Add key value
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
                    return "VChecklistList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "VChecklistView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "VChecklistEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "VChecklistAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "VChecklistList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "VChecklistView",
                Config.ApiAddAction => "VChecklistAdd",
                Config.ApiEditAction => "VChecklistEdit",
                Config.ApiDeleteAction => "VChecklistDelete",
                Config.ApiListAction => "VChecklistList",
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
        public string ListUrl => "VChecklistList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("VChecklistView", parm);
            else
                url = KeyUrl("VChecklistView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "VChecklistAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "VChecklistAdd?" + parm;
            else
                url = "VChecklistAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("VChecklistEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("VChecklistList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("VChecklistAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("VChecklistList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("VChecklistDelete")); // DN

        // Add master URL
        public string AddMasterUrl(string url)
        {
            return url;
        }

        // Get primary key as JSON
        public string KeyToJson(bool htmlEncode = false)
        {
            string json = "";
            json += "\"ChecklistId\":" + ConvertToJson(ChecklistId.CurrentValue, "number", true);
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL
        public string KeyUrl(string url, string parm = "") { // DN
            if (!IsNull(ChecklistId.CurrentValue)) {
                url += "/" + ChecklistId.CurrentValue;
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
            val = current ? ConvertToString(ChecklistId.CurrentValue) ?? "" : ConvertToString(ChecklistId.OldValue) ?? "";
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
            val = row?.TryGetValue("ChecklistId", out result) ?? false ? ConvertToString(result) : null;
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
                    ChecklistId.CurrentValue = keys[0];
                } else {
                    ChecklistId.OldValue = keys[0];
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
                if (RouteValues.TryGetValue("ChecklistId", out object? v0)) { // ChecklistId // DN
                    key = UrlDecode(v0); // DN
                } else if (IsApi() && !Empty(keyValues)) {
                    key = keyValues[0];
                } else {
                    key = Param("ChecklistId");
                }
                keysList.Add(key);
            }
            // Check keys
            foreach (var keys in keysList) {
                if (!IsNumeric(keys)) // ChecklistId
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
                    ChecklistId.CurrentValue = keys;
                else
                    ChecklistId.OldValue = keys;
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
            DocumentDate.SetDbValue(dr["DocumentDate"]);
            RequiredPhoto.SetDbValue(dr["RequiredPhoto"]);
            VisaPhoto.SetDbValue(dr["VisaPhoto"]);
            CityOfBirth.SetDbValue(dr["CityOfBirth"]);
            DateOfBirth.SetDbValue(dr["DateOfBirth"]);
            RankAppliedFor_RankID.SetDbValue(dr["RankAppliedFor_RankID"]);
            WillAcceptLowRank.SetDbValue(ConvertToBool(dr["WillAcceptLowRank"]) ? "1" : "0");
            AvailableFrom.SetDbValue(dr["AvailableFrom"]);
            AvailableUntil.SetDbValue(dr["AvailableUntil"]);
            Activity10.SetDbValue(ConvertToBool(dr["Activity10"]) ? "1" : "0");
            RemarkActivity10.SetDbValue(dr["RemarkActivity10"]);
            Activity11.SetDbValue(ConvertToBool(dr["Activity11"]) ? "1" : "0");
            RemarkActivity11.SetDbValue(dr["RemarkActivity11"]);
            Activity12.SetDbValue(ConvertToBool(dr["Activity12"]) ? "1" : "0");
            RemarkActivity12.SetDbValue(dr["RemarkActivity12"]);
            Activity13.SetDbValue(ConvertToBool(dr["Activity13"]) ? "1" : "0");
            RemarkActivity13.SetDbValue(dr["RemarkActivity13"]);
            Activity14.SetDbValue(ConvertToBool(dr["Activity14"]) ? "1" : "0");
            RemarkActivity14.SetDbValue(dr["RemarkActivity14"]);
            Activity20.SetDbValue(ConvertToBool(dr["Activity20"]) ? "1" : "0");
            RemarkActivity20.SetDbValue(dr["RemarkActivity20"]);
            Activity30.SetDbValue(ConvertToBool(dr["Activity30"]) ? "1" : "0");
            RemarkActivity30.SetDbValue(dr["RemarkActivity30"]);
            Activity40.SetDbValue(ConvertToBool(dr["Activity40"]) ? "1" : "0");
            RemarkActivity40.SetDbValue(dr["RemarkActivity40"]);
            Activity50.SetDbValue(ConvertToBool(dr["Activity50"]) ? "1" : "0");
            RemarkActivity50.SetDbValue(dr["RemarkActivity50"]);
            Activity60.SetDbValue(ConvertToBool(dr["Activity60"]) ? "1" : "0");
            RemarkActivity60.SetDbValue(dr["RemarkActivity60"]);
            Activity70.SetDbValue(ConvertToBool(dr["Activity70"]) ? "1" : "0");
            RemarkActivity70.SetDbValue(dr["RemarkActivity70"]);
            InterviewerComment.SetDbValue(dr["InterviewerComment"]);
            FinalInterviewComment.SetDbValue(dr["FinalInterviewComment"]);
            JobKnowledge.SetDbValue(dr["JobKnowledge"]);
            SafetyAwareness.SetDbValue(dr["SafetyAwareness"]);
            Personality.SetDbValue(dr["Personality"]);
            EnglishProficiency.SetDbValue(dr["EnglishProficiency"]);
            PrincipalComment.SetDbValue(dr["PrincipalComment"]);
            IndividualCodeNumber.SetDbValue(dr["IndividualCodeNumber"]);
            EmployeeStatus.SetDbValue(dr["EmployeeStatus"]);
            AssistantManagerPdeReviewedDate.SetDbValue(dr["AssistantManagerPdeReviewedDate"]);
            InterviewedByPersonTwoName.SetDbValue(dr["InterviewedByPersonTwoName"]);
            InterviewedByPersonTwoRank.SetDbValue(dr["InterviewedByPersonTwoRank"]);
            InterviewedByPersonTwoDate.SetDbValue(dr["InterviewedByPersonTwoDate"]);
            InterviewedByPersonThreeName.SetDbValue(dr["InterviewedByPersonThreeName"]);
            InterviewedByPersonThreeRank.SetDbValue(dr["InterviewedByPersonThreeRank"]);
            InterviewedByPersonThreeDate.SetDbValue(dr["InterviewedByPersonThreeDate"]);
            CrewingManagerApprovalDate.SetDbValue(dr["CrewingManagerApprovalDate"]);
            ChecklistId.SetDbValue(dr["ChecklistId"]);
            FullName.SetDbValue(dr["FullName"]);
            ManningAgent.SetDbValue(dr["ManningAgent"]);
            VesselName.SetDbValue(dr["VesselName"]);
            Performance.SetDbValue(dr["Performance"]);
            DateChecked.SetDbValue(dr["DateChecked"]);
            InterviewedByPersonOneName.SetDbValue(dr["InterviewedByPersonOneName"]);
            InterviewedByPersonOneRank.SetDbValue(dr["InterviewedByPersonOneRank"]);
            InterviewedByPersonOneDate.SetDbValue(dr["InterviewedByPersonOneDate"]);
            InterviewDate.SetDbValue(dr["InterviewDate"]);
            AssistantManagerPdeName.SetDbValue(dr["AssistantManagerPdeName"]);
            CrewingManagerName.SetDbValue(dr["CrewingManagerName"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "VChecklistList";
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

            // DocumentDate

            // RequiredPhoto

            // VisaPhoto

            // CityOfBirth

            // DateOfBirth

            // RankAppliedFor_RankID

            // WillAcceptLowRank

            // AvailableFrom

            // AvailableUntil

            // Activity10

            // RemarkActivity10

            // Activity11

            // RemarkActivity11

            // Activity12

            // RemarkActivity12

            // Activity13

            // RemarkActivity13

            // Activity14

            // RemarkActivity14

            // Activity20

            // RemarkActivity20

            // Activity30

            // RemarkActivity30

            // Activity40

            // RemarkActivity40

            // Activity50

            // RemarkActivity50

            // Activity60

            // RemarkActivity60

            // Activity70

            // RemarkActivity70

            // InterviewerComment

            // FinalInterviewComment

            // JobKnowledge

            // SafetyAwareness

            // Personality

            // EnglishProficiency

            // PrincipalComment

            // IndividualCodeNumber

            // EmployeeStatus

            // AssistantManagerPdeReviewedDate

            // InterviewedByPersonTwoName

            // InterviewedByPersonTwoRank

            // InterviewedByPersonTwoDate

            // InterviewedByPersonThreeName

            // InterviewedByPersonThreeRank

            // InterviewedByPersonThreeDate

            // CrewingManagerApprovalDate

            // ChecklistId

            // FullName

            // ManningAgent

            // VesselName

            // Performance

            // DateChecked

            // InterviewedByPersonOneName

            // InterviewedByPersonOneRank

            // InterviewedByPersonOneDate

            // InterviewDate

            // AssistantManagerPdeName

            // CrewingManagerName

            // DocumentDate
            DocumentDate.ViewValue = DocumentDate.CurrentValue;
            DocumentDate.ViewValue = FormatDateTime(DocumentDate.ViewValue, DocumentDate.FormatPattern);
            DocumentDate.ViewCustomAttributes = "";

            // RequiredPhoto
            RequiredPhoto.ViewValue = ConvertToString(RequiredPhoto.CurrentValue); // DN
            RequiredPhoto.ViewCustomAttributes = "";

            // VisaPhoto
            VisaPhoto.ViewValue = ConvertToString(VisaPhoto.CurrentValue); // DN
            VisaPhoto.ViewCustomAttributes = "";

            // CityOfBirth
            CityOfBirth.ViewValue = ConvertToString(CityOfBirth.CurrentValue); // DN
            CityOfBirth.ViewCustomAttributes = "";

            // DateOfBirth
            DateOfBirth.ViewValue = DateOfBirth.CurrentValue;
            DateOfBirth.ViewValue = FormatDateTime(DateOfBirth.ViewValue, DateOfBirth.FormatPattern);
            DateOfBirth.ViewCustomAttributes = "";

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.ViewValue = RankAppliedFor_RankID.CurrentValue;
            RankAppliedFor_RankID.ViewValue = FormatNumber(RankAppliedFor_RankID.ViewValue, RankAppliedFor_RankID.FormatPattern);
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

            // Activity10
            if (ConvertToBool(Activity10.CurrentValue)) {
                Activity10.ViewValue = Activity10.TagCaption(1) != "" ? Activity10.TagCaption(1) : "Yes";
            } else {
                Activity10.ViewValue = Activity10.TagCaption(2) != "" ? Activity10.TagCaption(2) : "No";
            }
            Activity10.ViewCustomAttributes = "";

            // RemarkActivity10
            RemarkActivity10.ViewValue = RemarkActivity10.CurrentValue;
            RemarkActivity10.ViewCustomAttributes = "";

            // Activity11
            if (ConvertToBool(Activity11.CurrentValue)) {
                Activity11.ViewValue = Activity11.TagCaption(1) != "" ? Activity11.TagCaption(1) : "Yes";
            } else {
                Activity11.ViewValue = Activity11.TagCaption(2) != "" ? Activity11.TagCaption(2) : "No";
            }
            Activity11.ViewCustomAttributes = "";

            // RemarkActivity11
            RemarkActivity11.ViewValue = RemarkActivity11.CurrentValue;
            RemarkActivity11.ViewCustomAttributes = "";

            // Activity12
            if (ConvertToBool(Activity12.CurrentValue)) {
                Activity12.ViewValue = Activity12.TagCaption(1) != "" ? Activity12.TagCaption(1) : "Yes";
            } else {
                Activity12.ViewValue = Activity12.TagCaption(2) != "" ? Activity12.TagCaption(2) : "No";
            }
            Activity12.ViewCustomAttributes = "";

            // RemarkActivity12
            RemarkActivity12.ViewValue = RemarkActivity12.CurrentValue;
            RemarkActivity12.ViewCustomAttributes = "";

            // Activity13
            if (ConvertToBool(Activity13.CurrentValue)) {
                Activity13.ViewValue = Activity13.TagCaption(1) != "" ? Activity13.TagCaption(1) : "Yes";
            } else {
                Activity13.ViewValue = Activity13.TagCaption(2) != "" ? Activity13.TagCaption(2) : "No";
            }
            Activity13.ViewCustomAttributes = "";

            // RemarkActivity13
            RemarkActivity13.ViewValue = RemarkActivity13.CurrentValue;
            RemarkActivity13.ViewCustomAttributes = "";

            // Activity14
            if (ConvertToBool(Activity14.CurrentValue)) {
                Activity14.ViewValue = Activity14.TagCaption(1) != "" ? Activity14.TagCaption(1) : "Yes";
            } else {
                Activity14.ViewValue = Activity14.TagCaption(2) != "" ? Activity14.TagCaption(2) : "No";
            }
            Activity14.ViewCustomAttributes = "";

            // RemarkActivity14
            RemarkActivity14.ViewValue = RemarkActivity14.CurrentValue;
            RemarkActivity14.ViewCustomAttributes = "";

            // Activity20
            if (ConvertToBool(Activity20.CurrentValue)) {
                Activity20.ViewValue = Activity20.TagCaption(1) != "" ? Activity20.TagCaption(1) : "Yes";
            } else {
                Activity20.ViewValue = Activity20.TagCaption(2) != "" ? Activity20.TagCaption(2) : "No";
            }
            Activity20.ViewCustomAttributes = "";

            // RemarkActivity20
            RemarkActivity20.ViewValue = RemarkActivity20.CurrentValue;
            RemarkActivity20.ViewCustomAttributes = "";

            // Activity30
            if (ConvertToBool(Activity30.CurrentValue)) {
                Activity30.ViewValue = Activity30.TagCaption(1) != "" ? Activity30.TagCaption(1) : "Yes";
            } else {
                Activity30.ViewValue = Activity30.TagCaption(2) != "" ? Activity30.TagCaption(2) : "No";
            }
            Activity30.ViewCustomAttributes = "";

            // RemarkActivity30
            RemarkActivity30.ViewValue = RemarkActivity30.CurrentValue;
            RemarkActivity30.ViewCustomAttributes = "";

            // Activity40
            if (ConvertToBool(Activity40.CurrentValue)) {
                Activity40.ViewValue = Activity40.TagCaption(1) != "" ? Activity40.TagCaption(1) : "Yes";
            } else {
                Activity40.ViewValue = Activity40.TagCaption(2) != "" ? Activity40.TagCaption(2) : "No";
            }
            Activity40.ViewCustomAttributes = "";

            // RemarkActivity40
            RemarkActivity40.ViewValue = RemarkActivity40.CurrentValue;
            RemarkActivity40.ViewCustomAttributes = "";

            // Activity50
            if (ConvertToBool(Activity50.CurrentValue)) {
                Activity50.ViewValue = Activity50.TagCaption(1) != "" ? Activity50.TagCaption(1) : "Yes";
            } else {
                Activity50.ViewValue = Activity50.TagCaption(2) != "" ? Activity50.TagCaption(2) : "No";
            }
            Activity50.ViewCustomAttributes = "";

            // RemarkActivity50
            RemarkActivity50.ViewValue = RemarkActivity50.CurrentValue;
            RemarkActivity50.ViewCustomAttributes = "";

            // Activity60
            if (ConvertToBool(Activity60.CurrentValue)) {
                Activity60.ViewValue = Activity60.TagCaption(1) != "" ? Activity60.TagCaption(1) : "Yes";
            } else {
                Activity60.ViewValue = Activity60.TagCaption(2) != "" ? Activity60.TagCaption(2) : "No";
            }
            Activity60.ViewCustomAttributes = "";

            // RemarkActivity60
            RemarkActivity60.ViewValue = RemarkActivity60.CurrentValue;
            RemarkActivity60.ViewCustomAttributes = "";

            // Activity70
            if (ConvertToBool(Activity70.CurrentValue)) {
                Activity70.ViewValue = Activity70.TagCaption(1) != "" ? Activity70.TagCaption(1) : "Yes";
            } else {
                Activity70.ViewValue = Activity70.TagCaption(2) != "" ? Activity70.TagCaption(2) : "No";
            }
            Activity70.ViewCustomAttributes = "";

            // RemarkActivity70
            RemarkActivity70.ViewValue = RemarkActivity70.CurrentValue;
            RemarkActivity70.ViewCustomAttributes = "";

            // InterviewerComment
            InterviewerComment.ViewValue = ConvertToString(InterviewerComment.CurrentValue); // DN
            InterviewerComment.ViewCustomAttributes = "";

            // FinalInterviewComment
            FinalInterviewComment.ViewValue = ConvertToString(FinalInterviewComment.CurrentValue); // DN
            FinalInterviewComment.ViewCustomAttributes = "";

            // JobKnowledge
            JobKnowledge.ViewValue = ConvertToString(JobKnowledge.CurrentValue); // DN
            JobKnowledge.ViewCustomAttributes = "";

            // SafetyAwareness
            SafetyAwareness.ViewValue = ConvertToString(SafetyAwareness.CurrentValue); // DN
            SafetyAwareness.ViewCustomAttributes = "";

            // Personality
            Personality.ViewValue = ConvertToString(Personality.CurrentValue); // DN
            Personality.ViewCustomAttributes = "";

            // EnglishProficiency
            EnglishProficiency.ViewValue = ConvertToString(EnglishProficiency.CurrentValue); // DN
            EnglishProficiency.ViewCustomAttributes = "";

            // PrincipalComment
            PrincipalComment.ViewValue = ConvertToString(PrincipalComment.CurrentValue); // DN
            PrincipalComment.ViewCustomAttributes = "";

            // IndividualCodeNumber
            IndividualCodeNumber.ViewValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
            IndividualCodeNumber.ViewCustomAttributes = "";

            // EmployeeStatus
            EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
            EmployeeStatus.ViewCustomAttributes = "";

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.ViewValue = AssistantManagerPdeReviewedDate.CurrentValue;
            AssistantManagerPdeReviewedDate.ViewValue = FormatDateTime(AssistantManagerPdeReviewedDate.ViewValue, AssistantManagerPdeReviewedDate.FormatPattern);
            AssistantManagerPdeReviewedDate.ViewCustomAttributes = "";

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.ViewValue = ConvertToString(InterviewedByPersonTwoName.CurrentValue); // DN
            InterviewedByPersonTwoName.ViewCustomAttributes = "";

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.ViewValue = ConvertToString(InterviewedByPersonTwoRank.CurrentValue); // DN
            InterviewedByPersonTwoRank.ViewCustomAttributes = "";

            // InterviewedByPersonTwoDate
            InterviewedByPersonTwoDate.ViewValue = InterviewedByPersonTwoDate.CurrentValue;
            InterviewedByPersonTwoDate.ViewValue = FormatDateTime(InterviewedByPersonTwoDate.ViewValue, InterviewedByPersonTwoDate.FormatPattern);
            InterviewedByPersonTwoDate.ViewCustomAttributes = "";

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.ViewValue = ConvertToString(InterviewedByPersonThreeName.CurrentValue); // DN
            InterviewedByPersonThreeName.ViewCustomAttributes = "";

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.ViewValue = ConvertToString(InterviewedByPersonThreeRank.CurrentValue); // DN
            InterviewedByPersonThreeRank.ViewCustomAttributes = "";

            // InterviewedByPersonThreeDate
            InterviewedByPersonThreeDate.ViewValue = InterviewedByPersonThreeDate.CurrentValue;
            InterviewedByPersonThreeDate.ViewValue = FormatDateTime(InterviewedByPersonThreeDate.ViewValue, InterviewedByPersonThreeDate.FormatPattern);
            InterviewedByPersonThreeDate.ViewCustomAttributes = "";

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.ViewValue = CrewingManagerApprovalDate.CurrentValue;
            CrewingManagerApprovalDate.ViewValue = FormatDateTime(CrewingManagerApprovalDate.ViewValue, CrewingManagerApprovalDate.FormatPattern);
            CrewingManagerApprovalDate.ViewCustomAttributes = "";

            // ChecklistId
            ChecklistId.ViewValue = ChecklistId.CurrentValue;
            ChecklistId.ViewValue = FormatNumber(ChecklistId.ViewValue, ChecklistId.FormatPattern);
            ChecklistId.ViewCustomAttributes = "";

            // FullName
            FullName.ViewValue = ConvertToString(FullName.CurrentValue); // DN
            FullName.ViewCustomAttributes = "";

            // ManningAgent
            ManningAgent.ViewValue = ConvertToString(ManningAgent.CurrentValue); // DN
            ManningAgent.ViewCustomAttributes = "";

            // VesselName
            VesselName.ViewValue = ConvertToString(VesselName.CurrentValue); // DN
            VesselName.ViewCustomAttributes = "";

            // Performance
            Performance.ViewValue = ConvertToString(Performance.CurrentValue); // DN
            Performance.ViewCustomAttributes = "";

            // DateChecked
            DateChecked.ViewValue = DateChecked.CurrentValue;
            DateChecked.ViewValue = FormatDateTime(DateChecked.ViewValue, DateChecked.FormatPattern);
            DateChecked.ViewCustomAttributes = "";

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.ViewValue = ConvertToString(InterviewedByPersonOneName.CurrentValue); // DN
            InterviewedByPersonOneName.ViewCustomAttributes = "";

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.ViewValue = ConvertToString(InterviewedByPersonOneRank.CurrentValue); // DN
            InterviewedByPersonOneRank.ViewCustomAttributes = "";

            // InterviewedByPersonOneDate
            InterviewedByPersonOneDate.ViewValue = InterviewedByPersonOneDate.CurrentValue;
            InterviewedByPersonOneDate.ViewValue = FormatDateTime(InterviewedByPersonOneDate.ViewValue, InterviewedByPersonOneDate.FormatPattern);
            InterviewedByPersonOneDate.ViewCustomAttributes = "";

            // InterviewDate
            InterviewDate.ViewValue = InterviewDate.CurrentValue;
            InterviewDate.ViewValue = FormatDateTime(InterviewDate.ViewValue, InterviewDate.FormatPattern);
            InterviewDate.ViewCustomAttributes = "";

            // AssistantManagerPdeName
            AssistantManagerPdeName.ViewValue = ConvertToString(AssistantManagerPdeName.CurrentValue); // DN
            AssistantManagerPdeName.ViewCustomAttributes = "";

            // CrewingManagerName
            CrewingManagerName.ViewValue = ConvertToString(CrewingManagerName.CurrentValue); // DN
            CrewingManagerName.ViewCustomAttributes = "";

            // DocumentDate
            DocumentDate.HrefValue = "";
            DocumentDate.TooltipValue = "";

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

            // Activity10
            Activity10.HrefValue = "";
            Activity10.TooltipValue = "";

            // RemarkActivity10
            RemarkActivity10.HrefValue = "";
            RemarkActivity10.TooltipValue = "";

            // Activity11
            Activity11.HrefValue = "";
            Activity11.TooltipValue = "";

            // RemarkActivity11
            RemarkActivity11.HrefValue = "";
            RemarkActivity11.TooltipValue = "";

            // Activity12
            Activity12.HrefValue = "";
            Activity12.TooltipValue = "";

            // RemarkActivity12
            RemarkActivity12.HrefValue = "";
            RemarkActivity12.TooltipValue = "";

            // Activity13
            Activity13.HrefValue = "";
            Activity13.TooltipValue = "";

            // RemarkActivity13
            RemarkActivity13.HrefValue = "";
            RemarkActivity13.TooltipValue = "";

            // Activity14
            Activity14.HrefValue = "";
            Activity14.TooltipValue = "";

            // RemarkActivity14
            RemarkActivity14.HrefValue = "";
            RemarkActivity14.TooltipValue = "";

            // Activity20
            Activity20.HrefValue = "";
            Activity20.TooltipValue = "";

            // RemarkActivity20
            RemarkActivity20.HrefValue = "";
            RemarkActivity20.TooltipValue = "";

            // Activity30
            Activity30.HrefValue = "";
            Activity30.TooltipValue = "";

            // RemarkActivity30
            RemarkActivity30.HrefValue = "";
            RemarkActivity30.TooltipValue = "";

            // Activity40
            Activity40.HrefValue = "";
            Activity40.TooltipValue = "";

            // RemarkActivity40
            RemarkActivity40.HrefValue = "";
            RemarkActivity40.TooltipValue = "";

            // Activity50
            Activity50.HrefValue = "";
            Activity50.TooltipValue = "";

            // RemarkActivity50
            RemarkActivity50.HrefValue = "";
            RemarkActivity50.TooltipValue = "";

            // Activity60
            Activity60.HrefValue = "";
            Activity60.TooltipValue = "";

            // RemarkActivity60
            RemarkActivity60.HrefValue = "";
            RemarkActivity60.TooltipValue = "";

            // Activity70
            Activity70.HrefValue = "";
            Activity70.TooltipValue = "";

            // RemarkActivity70
            RemarkActivity70.HrefValue = "";
            RemarkActivity70.TooltipValue = "";

            // InterviewerComment
            InterviewerComment.HrefValue = "";
            InterviewerComment.TooltipValue = "";

            // FinalInterviewComment
            FinalInterviewComment.HrefValue = "";
            FinalInterviewComment.TooltipValue = "";

            // JobKnowledge
            JobKnowledge.HrefValue = "";
            JobKnowledge.TooltipValue = "";

            // SafetyAwareness
            SafetyAwareness.HrefValue = "";
            SafetyAwareness.TooltipValue = "";

            // Personality
            Personality.HrefValue = "";
            Personality.TooltipValue = "";

            // EnglishProficiency
            EnglishProficiency.HrefValue = "";
            EnglishProficiency.TooltipValue = "";

            // PrincipalComment
            PrincipalComment.HrefValue = "";
            PrincipalComment.TooltipValue = "";

            // IndividualCodeNumber
            IndividualCodeNumber.HrefValue = "";
            IndividualCodeNumber.TooltipValue = "";

            // EmployeeStatus
            EmployeeStatus.HrefValue = "";
            EmployeeStatus.TooltipValue = "";

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.HrefValue = "";
            AssistantManagerPdeReviewedDate.TooltipValue = "";

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.HrefValue = "";
            InterviewedByPersonTwoName.TooltipValue = "";

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.HrefValue = "";
            InterviewedByPersonTwoRank.TooltipValue = "";

            // InterviewedByPersonTwoDate
            InterviewedByPersonTwoDate.HrefValue = "";
            InterviewedByPersonTwoDate.TooltipValue = "";

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.HrefValue = "";
            InterviewedByPersonThreeName.TooltipValue = "";

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.HrefValue = "";
            InterviewedByPersonThreeRank.TooltipValue = "";

            // InterviewedByPersonThreeDate
            InterviewedByPersonThreeDate.HrefValue = "";
            InterviewedByPersonThreeDate.TooltipValue = "";

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.HrefValue = "";
            CrewingManagerApprovalDate.TooltipValue = "";

            // ChecklistId
            ChecklistId.HrefValue = "";
            ChecklistId.TooltipValue = "";

            // FullName
            FullName.HrefValue = "";
            FullName.TooltipValue = "";

            // ManningAgent
            ManningAgent.HrefValue = "";
            ManningAgent.TooltipValue = "";

            // VesselName
            VesselName.HrefValue = "";
            VesselName.TooltipValue = "";

            // Performance
            Performance.HrefValue = "";
            Performance.TooltipValue = "";

            // DateChecked
            DateChecked.HrefValue = "";
            DateChecked.TooltipValue = "";

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.HrefValue = "";
            InterviewedByPersonOneName.TooltipValue = "";

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.HrefValue = "";
            InterviewedByPersonOneRank.TooltipValue = "";

            // InterviewedByPersonOneDate
            InterviewedByPersonOneDate.HrefValue = "";
            InterviewedByPersonOneDate.TooltipValue = "";

            // InterviewDate
            InterviewDate.HrefValue = "";
            InterviewDate.TooltipValue = "";

            // AssistantManagerPdeName
            AssistantManagerPdeName.HrefValue = "";
            AssistantManagerPdeName.TooltipValue = "";

            // CrewingManagerName
            CrewingManagerName.HrefValue = "";
            CrewingManagerName.TooltipValue = "";

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

            // DocumentDate
            DocumentDate.SetupEditAttributes();
            DocumentDate.EditValue = FormatDateTime(DocumentDate.CurrentValue, DocumentDate.FormatPattern); // DN
            DocumentDate.PlaceHolder = RemoveHtml(DocumentDate.Caption);

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

            // Activity10
            Activity10.EditValue = Activity10.Options(false);
            Activity10.PlaceHolder = RemoveHtml(Activity10.Caption);

            // RemarkActivity10
            RemarkActivity10.SetupEditAttributes();
            RemarkActivity10.EditValue = RemarkActivity10.CurrentValue; // DN
            RemarkActivity10.PlaceHolder = RemoveHtml(RemarkActivity10.Caption);

            // Activity11
            Activity11.EditValue = Activity11.Options(false);
            Activity11.PlaceHolder = RemoveHtml(Activity11.Caption);

            // RemarkActivity11
            RemarkActivity11.SetupEditAttributes();
            RemarkActivity11.EditValue = RemarkActivity11.CurrentValue; // DN
            RemarkActivity11.PlaceHolder = RemoveHtml(RemarkActivity11.Caption);

            // Activity12
            Activity12.EditValue = Activity12.Options(false);
            Activity12.PlaceHolder = RemoveHtml(Activity12.Caption);

            // RemarkActivity12
            RemarkActivity12.SetupEditAttributes();
            RemarkActivity12.EditValue = RemarkActivity12.CurrentValue; // DN
            RemarkActivity12.PlaceHolder = RemoveHtml(RemarkActivity12.Caption);

            // Activity13
            Activity13.EditValue = Activity13.Options(false);
            Activity13.PlaceHolder = RemoveHtml(Activity13.Caption);

            // RemarkActivity13
            RemarkActivity13.SetupEditAttributes();
            RemarkActivity13.EditValue = RemarkActivity13.CurrentValue; // DN
            RemarkActivity13.PlaceHolder = RemoveHtml(RemarkActivity13.Caption);

            // Activity14
            Activity14.EditValue = Activity14.Options(false);
            Activity14.PlaceHolder = RemoveHtml(Activity14.Caption);

            // RemarkActivity14
            RemarkActivity14.SetupEditAttributes();
            RemarkActivity14.EditValue = RemarkActivity14.CurrentValue; // DN
            RemarkActivity14.PlaceHolder = RemoveHtml(RemarkActivity14.Caption);

            // Activity20
            Activity20.EditValue = Activity20.Options(false);
            Activity20.PlaceHolder = RemoveHtml(Activity20.Caption);

            // RemarkActivity20
            RemarkActivity20.SetupEditAttributes();
            RemarkActivity20.EditValue = RemarkActivity20.CurrentValue; // DN
            RemarkActivity20.PlaceHolder = RemoveHtml(RemarkActivity20.Caption);

            // Activity30
            Activity30.EditValue = Activity30.Options(false);
            Activity30.PlaceHolder = RemoveHtml(Activity30.Caption);

            // RemarkActivity30
            RemarkActivity30.SetupEditAttributes();
            RemarkActivity30.EditValue = RemarkActivity30.CurrentValue; // DN
            RemarkActivity30.PlaceHolder = RemoveHtml(RemarkActivity30.Caption);

            // Activity40
            Activity40.EditValue = Activity40.Options(false);
            Activity40.PlaceHolder = RemoveHtml(Activity40.Caption);

            // RemarkActivity40
            RemarkActivity40.SetupEditAttributes();
            RemarkActivity40.EditValue = RemarkActivity40.CurrentValue; // DN
            RemarkActivity40.PlaceHolder = RemoveHtml(RemarkActivity40.Caption);

            // Activity50
            Activity50.EditValue = Activity50.Options(false);
            Activity50.PlaceHolder = RemoveHtml(Activity50.Caption);

            // RemarkActivity50
            RemarkActivity50.SetupEditAttributes();
            RemarkActivity50.EditValue = RemarkActivity50.CurrentValue; // DN
            RemarkActivity50.PlaceHolder = RemoveHtml(RemarkActivity50.Caption);

            // Activity60
            Activity60.EditValue = Activity60.Options(false);
            Activity60.PlaceHolder = RemoveHtml(Activity60.Caption);

            // RemarkActivity60
            RemarkActivity60.SetupEditAttributes();
            RemarkActivity60.EditValue = RemarkActivity60.CurrentValue; // DN
            RemarkActivity60.PlaceHolder = RemoveHtml(RemarkActivity60.Caption);

            // Activity70
            Activity70.EditValue = Activity70.Options(false);
            Activity70.PlaceHolder = RemoveHtml(Activity70.Caption);

            // RemarkActivity70
            RemarkActivity70.SetupEditAttributes();
            RemarkActivity70.EditValue = RemarkActivity70.CurrentValue; // DN
            RemarkActivity70.PlaceHolder = RemoveHtml(RemarkActivity70.Caption);

            // InterviewerComment
            InterviewerComment.SetupEditAttributes();
            if (!InterviewerComment.Raw)
                InterviewerComment.CurrentValue = HtmlDecode(InterviewerComment.CurrentValue);
            InterviewerComment.EditValue = HtmlEncode(InterviewerComment.CurrentValue);
            InterviewerComment.PlaceHolder = RemoveHtml(InterviewerComment.Caption);

            // FinalInterviewComment
            FinalInterviewComment.SetupEditAttributes();
            if (!FinalInterviewComment.Raw)
                FinalInterviewComment.CurrentValue = HtmlDecode(FinalInterviewComment.CurrentValue);
            FinalInterviewComment.EditValue = HtmlEncode(FinalInterviewComment.CurrentValue);
            FinalInterviewComment.PlaceHolder = RemoveHtml(FinalInterviewComment.Caption);

            // JobKnowledge
            JobKnowledge.SetupEditAttributes();
            if (!JobKnowledge.Raw)
                JobKnowledge.CurrentValue = HtmlDecode(JobKnowledge.CurrentValue);
            JobKnowledge.EditValue = HtmlEncode(JobKnowledge.CurrentValue);
            JobKnowledge.PlaceHolder = RemoveHtml(JobKnowledge.Caption);

            // SafetyAwareness
            SafetyAwareness.SetupEditAttributes();
            if (!SafetyAwareness.Raw)
                SafetyAwareness.CurrentValue = HtmlDecode(SafetyAwareness.CurrentValue);
            SafetyAwareness.EditValue = HtmlEncode(SafetyAwareness.CurrentValue);
            SafetyAwareness.PlaceHolder = RemoveHtml(SafetyAwareness.Caption);

            // Personality
            Personality.SetupEditAttributes();
            if (!Personality.Raw)
                Personality.CurrentValue = HtmlDecode(Personality.CurrentValue);
            Personality.EditValue = HtmlEncode(Personality.CurrentValue);
            Personality.PlaceHolder = RemoveHtml(Personality.Caption);

            // EnglishProficiency
            EnglishProficiency.SetupEditAttributes();
            if (!EnglishProficiency.Raw)
                EnglishProficiency.CurrentValue = HtmlDecode(EnglishProficiency.CurrentValue);
            EnglishProficiency.EditValue = HtmlEncode(EnglishProficiency.CurrentValue);
            EnglishProficiency.PlaceHolder = RemoveHtml(EnglishProficiency.Caption);

            // PrincipalComment
            PrincipalComment.SetupEditAttributes();
            if (!PrincipalComment.Raw)
                PrincipalComment.CurrentValue = HtmlDecode(PrincipalComment.CurrentValue);
            PrincipalComment.EditValue = HtmlEncode(PrincipalComment.CurrentValue);
            PrincipalComment.PlaceHolder = RemoveHtml(PrincipalComment.Caption);

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

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.SetupEditAttributes();
            AssistantManagerPdeReviewedDate.EditValue = FormatDateTime(AssistantManagerPdeReviewedDate.CurrentValue, AssistantManagerPdeReviewedDate.FormatPattern); // DN
            AssistantManagerPdeReviewedDate.PlaceHolder = RemoveHtml(AssistantManagerPdeReviewedDate.Caption);

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.SetupEditAttributes();
            if (!InterviewedByPersonTwoName.Raw)
                InterviewedByPersonTwoName.CurrentValue = HtmlDecode(InterviewedByPersonTwoName.CurrentValue);
            InterviewedByPersonTwoName.EditValue = HtmlEncode(InterviewedByPersonTwoName.CurrentValue);
            InterviewedByPersonTwoName.PlaceHolder = RemoveHtml(InterviewedByPersonTwoName.Caption);

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.SetupEditAttributes();
            if (!InterviewedByPersonTwoRank.Raw)
                InterviewedByPersonTwoRank.CurrentValue = HtmlDecode(InterviewedByPersonTwoRank.CurrentValue);
            InterviewedByPersonTwoRank.EditValue = HtmlEncode(InterviewedByPersonTwoRank.CurrentValue);
            InterviewedByPersonTwoRank.PlaceHolder = RemoveHtml(InterviewedByPersonTwoRank.Caption);

            // InterviewedByPersonTwoDate
            InterviewedByPersonTwoDate.SetupEditAttributes();
            InterviewedByPersonTwoDate.EditValue = FormatDateTime(InterviewedByPersonTwoDate.CurrentValue, InterviewedByPersonTwoDate.FormatPattern); // DN
            InterviewedByPersonTwoDate.PlaceHolder = RemoveHtml(InterviewedByPersonTwoDate.Caption);

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.SetupEditAttributes();
            if (!InterviewedByPersonThreeName.Raw)
                InterviewedByPersonThreeName.CurrentValue = HtmlDecode(InterviewedByPersonThreeName.CurrentValue);
            InterviewedByPersonThreeName.EditValue = HtmlEncode(InterviewedByPersonThreeName.CurrentValue);
            InterviewedByPersonThreeName.PlaceHolder = RemoveHtml(InterviewedByPersonThreeName.Caption);

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.SetupEditAttributes();
            if (!InterviewedByPersonThreeRank.Raw)
                InterviewedByPersonThreeRank.CurrentValue = HtmlDecode(InterviewedByPersonThreeRank.CurrentValue);
            InterviewedByPersonThreeRank.EditValue = HtmlEncode(InterviewedByPersonThreeRank.CurrentValue);
            InterviewedByPersonThreeRank.PlaceHolder = RemoveHtml(InterviewedByPersonThreeRank.Caption);

            // InterviewedByPersonThreeDate
            InterviewedByPersonThreeDate.SetupEditAttributes();
            InterviewedByPersonThreeDate.EditValue = FormatDateTime(InterviewedByPersonThreeDate.CurrentValue, InterviewedByPersonThreeDate.FormatPattern); // DN
            InterviewedByPersonThreeDate.PlaceHolder = RemoveHtml(InterviewedByPersonThreeDate.Caption);

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.SetupEditAttributes();
            CrewingManagerApprovalDate.EditValue = FormatDateTime(CrewingManagerApprovalDate.CurrentValue, CrewingManagerApprovalDate.FormatPattern); // DN
            CrewingManagerApprovalDate.PlaceHolder = RemoveHtml(CrewingManagerApprovalDate.Caption);

            // ChecklistId
            ChecklistId.SetupEditAttributes();
            ChecklistId.EditValue = ChecklistId.CurrentValue; // DN
            ChecklistId.PlaceHolder = RemoveHtml(ChecklistId.Caption);

            // FullName
            FullName.SetupEditAttributes();
            if (!FullName.Raw)
                FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
            FullName.EditValue = HtmlEncode(FullName.CurrentValue);
            FullName.PlaceHolder = RemoveHtml(FullName.Caption);

            // ManningAgent
            ManningAgent.SetupEditAttributes();
            if (!ManningAgent.Raw)
                ManningAgent.CurrentValue = HtmlDecode(ManningAgent.CurrentValue);
            ManningAgent.EditValue = HtmlEncode(ManningAgent.CurrentValue);
            ManningAgent.PlaceHolder = RemoveHtml(ManningAgent.Caption);

            // VesselName
            VesselName.SetupEditAttributes();
            if (!VesselName.Raw)
                VesselName.CurrentValue = HtmlDecode(VesselName.CurrentValue);
            VesselName.EditValue = HtmlEncode(VesselName.CurrentValue);
            VesselName.PlaceHolder = RemoveHtml(VesselName.Caption);

            // Performance
            Performance.SetupEditAttributes();
            if (!Performance.Raw)
                Performance.CurrentValue = HtmlDecode(Performance.CurrentValue);
            Performance.EditValue = HtmlEncode(Performance.CurrentValue);
            Performance.PlaceHolder = RemoveHtml(Performance.Caption);

            // DateChecked
            DateChecked.SetupEditAttributes();
            DateChecked.EditValue = FormatDateTime(DateChecked.CurrentValue, DateChecked.FormatPattern); // DN
            DateChecked.PlaceHolder = RemoveHtml(DateChecked.Caption);

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.SetupEditAttributes();
            if (!InterviewedByPersonOneName.Raw)
                InterviewedByPersonOneName.CurrentValue = HtmlDecode(InterviewedByPersonOneName.CurrentValue);
            InterviewedByPersonOneName.EditValue = HtmlEncode(InterviewedByPersonOneName.CurrentValue);
            InterviewedByPersonOneName.PlaceHolder = RemoveHtml(InterviewedByPersonOneName.Caption);

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.SetupEditAttributes();
            if (!InterviewedByPersonOneRank.Raw)
                InterviewedByPersonOneRank.CurrentValue = HtmlDecode(InterviewedByPersonOneRank.CurrentValue);
            InterviewedByPersonOneRank.EditValue = HtmlEncode(InterviewedByPersonOneRank.CurrentValue);
            InterviewedByPersonOneRank.PlaceHolder = RemoveHtml(InterviewedByPersonOneRank.Caption);

            // InterviewedByPersonOneDate
            InterviewedByPersonOneDate.SetupEditAttributes();
            InterviewedByPersonOneDate.EditValue = FormatDateTime(InterviewedByPersonOneDate.CurrentValue, InterviewedByPersonOneDate.FormatPattern); // DN
            InterviewedByPersonOneDate.PlaceHolder = RemoveHtml(InterviewedByPersonOneDate.Caption);

            // InterviewDate
            InterviewDate.SetupEditAttributes();
            InterviewDate.EditValue = FormatDateTime(InterviewDate.CurrentValue, InterviewDate.FormatPattern); // DN
            InterviewDate.PlaceHolder = RemoveHtml(InterviewDate.Caption);

            // AssistantManagerPdeName
            AssistantManagerPdeName.SetupEditAttributes();
            if (!AssistantManagerPdeName.Raw)
                AssistantManagerPdeName.CurrentValue = HtmlDecode(AssistantManagerPdeName.CurrentValue);
            AssistantManagerPdeName.EditValue = HtmlEncode(AssistantManagerPdeName.CurrentValue);
            AssistantManagerPdeName.PlaceHolder = RemoveHtml(AssistantManagerPdeName.Caption);

            // CrewingManagerName
            CrewingManagerName.SetupEditAttributes();
            if (!CrewingManagerName.Raw)
                CrewingManagerName.CurrentValue = HtmlDecode(CrewingManagerName.CurrentValue);
            CrewingManagerName.EditValue = HtmlEncode(CrewingManagerName.CurrentValue);
            CrewingManagerName.PlaceHolder = RemoveHtml(CrewingManagerName.Caption);

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
                        doc.ExportCaption(DocumentDate);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(CityOfBirth);
                        doc.ExportCaption(DateOfBirth);
                        doc.ExportCaption(RankAppliedFor_RankID);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
                        doc.ExportCaption(Activity10);
                        doc.ExportCaption(RemarkActivity10);
                        doc.ExportCaption(Activity11);
                        doc.ExportCaption(RemarkActivity11);
                        doc.ExportCaption(Activity12);
                        doc.ExportCaption(RemarkActivity12);
                        doc.ExportCaption(Activity13);
                        doc.ExportCaption(RemarkActivity13);
                        doc.ExportCaption(Activity14);
                        doc.ExportCaption(RemarkActivity14);
                        doc.ExportCaption(Activity20);
                        doc.ExportCaption(RemarkActivity20);
                        doc.ExportCaption(Activity30);
                        doc.ExportCaption(RemarkActivity30);
                        doc.ExportCaption(Activity40);
                        doc.ExportCaption(RemarkActivity40);
                        doc.ExportCaption(Activity50);
                        doc.ExportCaption(RemarkActivity50);
                        doc.ExportCaption(Activity60);
                        doc.ExportCaption(RemarkActivity60);
                        doc.ExportCaption(Activity70);
                        doc.ExportCaption(RemarkActivity70);
                        doc.ExportCaption(InterviewerComment);
                        doc.ExportCaption(FinalInterviewComment);
                        doc.ExportCaption(JobKnowledge);
                        doc.ExportCaption(SafetyAwareness);
                        doc.ExportCaption(Personality);
                        doc.ExportCaption(EnglishProficiency);
                        doc.ExportCaption(PrincipalComment);
                        doc.ExportCaption(IndividualCodeNumber);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(AssistantManagerPdeReviewedDate);
                        doc.ExportCaption(InterviewedByPersonTwoName);
                        doc.ExportCaption(InterviewedByPersonTwoRank);
                        doc.ExportCaption(InterviewedByPersonTwoDate);
                        doc.ExportCaption(InterviewedByPersonThreeName);
                        doc.ExportCaption(InterviewedByPersonThreeRank);
                        doc.ExportCaption(InterviewedByPersonThreeDate);
                        doc.ExportCaption(CrewingManagerApprovalDate);
                        doc.ExportCaption(ChecklistId);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(ManningAgent);
                        doc.ExportCaption(VesselName);
                        doc.ExportCaption(Performance);
                        doc.ExportCaption(DateChecked);
                        doc.ExportCaption(InterviewedByPersonOneName);
                        doc.ExportCaption(InterviewedByPersonOneRank);
                        doc.ExportCaption(InterviewedByPersonOneDate);
                        doc.ExportCaption(InterviewDate);
                        doc.ExportCaption(AssistantManagerPdeName);
                        doc.ExportCaption(CrewingManagerName);
                    } else {
                        doc.ExportCaption(DocumentDate);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(CityOfBirth);
                        doc.ExportCaption(DateOfBirth);
                        doc.ExportCaption(RankAppliedFor_RankID);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
                        doc.ExportCaption(Activity10);
                        doc.ExportCaption(Activity11);
                        doc.ExportCaption(Activity12);
                        doc.ExportCaption(Activity13);
                        doc.ExportCaption(Activity14);
                        doc.ExportCaption(Activity20);
                        doc.ExportCaption(Activity30);
                        doc.ExportCaption(Activity40);
                        doc.ExportCaption(Activity50);
                        doc.ExportCaption(Activity60);
                        doc.ExportCaption(Activity70);
                        doc.ExportCaption(InterviewerComment);
                        doc.ExportCaption(FinalInterviewComment);
                        doc.ExportCaption(JobKnowledge);
                        doc.ExportCaption(SafetyAwareness);
                        doc.ExportCaption(Personality);
                        doc.ExportCaption(EnglishProficiency);
                        doc.ExportCaption(PrincipalComment);
                        doc.ExportCaption(IndividualCodeNumber);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(AssistantManagerPdeReviewedDate);
                        doc.ExportCaption(InterviewedByPersonTwoName);
                        doc.ExportCaption(InterviewedByPersonTwoRank);
                        doc.ExportCaption(InterviewedByPersonTwoDate);
                        doc.ExportCaption(InterviewedByPersonThreeName);
                        doc.ExportCaption(InterviewedByPersonThreeRank);
                        doc.ExportCaption(InterviewedByPersonThreeDate);
                        doc.ExportCaption(CrewingManagerApprovalDate);
                        doc.ExportCaption(ChecklistId);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(ManningAgent);
                        doc.ExportCaption(VesselName);
                        doc.ExportCaption(Performance);
                        doc.ExportCaption(DateChecked);
                        doc.ExportCaption(InterviewedByPersonOneName);
                        doc.ExportCaption(InterviewedByPersonOneRank);
                        doc.ExportCaption(InterviewedByPersonOneDate);
                        doc.ExportCaption(InterviewDate);
                        doc.ExportCaption(AssistantManagerPdeName);
                        doc.ExportCaption(CrewingManagerName);
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
                            await doc.ExportField(DocumentDate);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(CityOfBirth);
                            await doc.ExportField(DateOfBirth);
                            await doc.ExportField(RankAppliedFor_RankID);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
                            await doc.ExportField(Activity10);
                            await doc.ExportField(RemarkActivity10);
                            await doc.ExportField(Activity11);
                            await doc.ExportField(RemarkActivity11);
                            await doc.ExportField(Activity12);
                            await doc.ExportField(RemarkActivity12);
                            await doc.ExportField(Activity13);
                            await doc.ExportField(RemarkActivity13);
                            await doc.ExportField(Activity14);
                            await doc.ExportField(RemarkActivity14);
                            await doc.ExportField(Activity20);
                            await doc.ExportField(RemarkActivity20);
                            await doc.ExportField(Activity30);
                            await doc.ExportField(RemarkActivity30);
                            await doc.ExportField(Activity40);
                            await doc.ExportField(RemarkActivity40);
                            await doc.ExportField(Activity50);
                            await doc.ExportField(RemarkActivity50);
                            await doc.ExportField(Activity60);
                            await doc.ExportField(RemarkActivity60);
                            await doc.ExportField(Activity70);
                            await doc.ExportField(RemarkActivity70);
                            await doc.ExportField(InterviewerComment);
                            await doc.ExportField(FinalInterviewComment);
                            await doc.ExportField(JobKnowledge);
                            await doc.ExportField(SafetyAwareness);
                            await doc.ExportField(Personality);
                            await doc.ExportField(EnglishProficiency);
                            await doc.ExportField(PrincipalComment);
                            await doc.ExportField(IndividualCodeNumber);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(AssistantManagerPdeReviewedDate);
                            await doc.ExportField(InterviewedByPersonTwoName);
                            await doc.ExportField(InterviewedByPersonTwoRank);
                            await doc.ExportField(InterviewedByPersonTwoDate);
                            await doc.ExportField(InterviewedByPersonThreeName);
                            await doc.ExportField(InterviewedByPersonThreeRank);
                            await doc.ExportField(InterviewedByPersonThreeDate);
                            await doc.ExportField(CrewingManagerApprovalDate);
                            await doc.ExportField(ChecklistId);
                            await doc.ExportField(FullName);
                            await doc.ExportField(ManningAgent);
                            await doc.ExportField(VesselName);
                            await doc.ExportField(Performance);
                            await doc.ExportField(DateChecked);
                            await doc.ExportField(InterviewedByPersonOneName);
                            await doc.ExportField(InterviewedByPersonOneRank);
                            await doc.ExportField(InterviewedByPersonOneDate);
                            await doc.ExportField(InterviewDate);
                            await doc.ExportField(AssistantManagerPdeName);
                            await doc.ExportField(CrewingManagerName);
                        } else {
                            await doc.ExportField(DocumentDate);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(CityOfBirth);
                            await doc.ExportField(DateOfBirth);
                            await doc.ExportField(RankAppliedFor_RankID);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
                            await doc.ExportField(Activity10);
                            await doc.ExportField(Activity11);
                            await doc.ExportField(Activity12);
                            await doc.ExportField(Activity13);
                            await doc.ExportField(Activity14);
                            await doc.ExportField(Activity20);
                            await doc.ExportField(Activity30);
                            await doc.ExportField(Activity40);
                            await doc.ExportField(Activity50);
                            await doc.ExportField(Activity60);
                            await doc.ExportField(Activity70);
                            await doc.ExportField(InterviewerComment);
                            await doc.ExportField(FinalInterviewComment);
                            await doc.ExportField(JobKnowledge);
                            await doc.ExportField(SafetyAwareness);
                            await doc.ExportField(Personality);
                            await doc.ExportField(EnglishProficiency);
                            await doc.ExportField(PrincipalComment);
                            await doc.ExportField(IndividualCodeNumber);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(AssistantManagerPdeReviewedDate);
                            await doc.ExportField(InterviewedByPersonTwoName);
                            await doc.ExportField(InterviewedByPersonTwoRank);
                            await doc.ExportField(InterviewedByPersonTwoDate);
                            await doc.ExportField(InterviewedByPersonThreeName);
                            await doc.ExportField(InterviewedByPersonThreeRank);
                            await doc.ExportField(InterviewedByPersonThreeDate);
                            await doc.ExportField(CrewingManagerApprovalDate);
                            await doc.ExportField(ChecklistId);
                            await doc.ExportField(FullName);
                            await doc.ExportField(ManningAgent);
                            await doc.ExportField(VesselName);
                            await doc.ExportField(Performance);
                            await doc.ExportField(DateChecked);
                            await doc.ExportField(InterviewedByPersonOneName);
                            await doc.ExportField(InterviewedByPersonOneRank);
                            await doc.ExportField(InterviewedByPersonOneDate);
                            await doc.ExportField(InterviewDate);
                            await doc.ExportField(AssistantManagerPdeName);
                            await doc.ExportField(CrewingManagerName);
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
