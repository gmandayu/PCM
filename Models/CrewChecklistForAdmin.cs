namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewChecklistForAdmin
    /// </summary>
    [MaybeNull]
    public static CrewChecklistForAdmin crewChecklistForAdmin
    {
        get => HttpData.Resolve<CrewChecklistForAdmin>("CrewChecklistForAdmin");
        set => HttpData["CrewChecklistForAdmin"] = value;
    }

    /// <summary>
    /// Table class for CrewChecklistForAdmin
    /// </summary>
    public class CrewChecklistForAdmin : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> MTCrewID;

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

        public readonly DbField<SqlDbType> JobKnowledge;

        public readonly DbField<SqlDbType> SafetyAwareness;

        public readonly DbField<SqlDbType> Personality;

        public readonly DbField<SqlDbType> EnglishProficiency;

        public readonly DbField<SqlDbType> PrincipalComment;

        public readonly DbField<SqlDbType> CreatedByUserID;

        public readonly DbField<SqlDbType> CreatedDateTime;

        public readonly DbField<SqlDbType> LastUpdatedByUserID;

        public readonly DbField<SqlDbType> LastUpdatedDateTime;

        public readonly DbField<SqlDbType> FinalInterviewComment;

        public readonly DbField<SqlDbType> InterviewedByPersonOneName;

        public readonly DbField<SqlDbType> InterviewedByPersonOneRank;

        public readonly DbField<SqlDbType> AssistantManagerPdeReviewedDate;

        public readonly DbField<SqlDbType> InterviewedByPersonTwoName;

        public readonly DbField<SqlDbType> InterviewedByPersonTwoRank;

        public readonly DbField<SqlDbType> InterviewedByPersonThreeName;

        public readonly DbField<SqlDbType> InterviewedByPersonThreeRank;

        public readonly DbField<SqlDbType> CrewingManagerApprovalDate;

        public readonly DbField<SqlDbType> Activity14Attachment;

        public readonly DbField<SqlDbType> Activity20Attachment;

        public readonly DbField<SqlDbType> Activity30Attachment;

        public readonly DbField<SqlDbType> Activity50Attachment;

        public readonly DbField<SqlDbType> Activity70Attachment;

        public readonly DbField<SqlDbType> FinalInterviewAttachment;

        public readonly DbField<SqlDbType> PrincipalCommentAttachment;

        public readonly DbField<SqlDbType> FormPrintoutAttachment;

        public readonly DbField<SqlDbType> AssistantManagerPdeReviewed;

        public readonly DbField<SqlDbType> CrewingManagerApproval;

        public readonly DbField<SqlDbType> InterviewDate;

        public readonly DbField<SqlDbType> InterviewAttachment;

        public readonly DbField<SqlDbType> ApprovedByUserID1;

        public readonly DbField<SqlDbType> ApprovedByUserID2;

        // Constructor
        public CrewChecklistForAdmin()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "CrewChecklistForAdmin";
            Name = "CrewChecklistForAdmin";
            Type = "CUSTOMVIEW";
            UpdateTable = "dbo.TRChecklist"; // Update Table
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
                Expression = "dbo.TRChecklist.ID",
                BasicSearchExpression = "CAST(dbo.TRChecklist.ID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.ID",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "NO",
                InputTextType = "text",
                IsAutoIncrement = true, // Autoincrement field
                IsPrimaryKey = true, // Primary key field
                IsForeignKey = true, // Foreign key field
                Nullable = false, // NOT NULL field
                Sortable = false, // Allow sort
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ID", ID);

            // MTCrewID
            MTCrewID = new (this, "x_MTCrewID", 3, SqlDbType.Int) {
                Name = "MTCrewID",
                Expression = "dbo.TRChecklist.MTCrewID",
                BasicSearchExpression = "CAST(dbo.TRChecklist.MTCrewID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.MTCrewID",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "MTCrewID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MTCrewID", MTCrewID);

            // Activity10
            Activity10 = new (this, "x_Activity10", 11, SqlDbType.Bit) {
                Name = "Activity10",
                Expression = "dbo.TRChecklist.Activity10",
                BasicSearchExpression = "dbo.TRChecklist.Activity10",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity10",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity10", "CustomMsg"),
                IsUpload = false
            };
            Activity10.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity10", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity10", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity10", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity10", Activity10);

            // RemarkActivity10
            RemarkActivity10 = new (this, "x_RemarkActivity10", 203, SqlDbType.NText) {
                Name = "RemarkActivity10",
                Expression = "dbo.TRChecklist.RemarkActivity10",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity10",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity10",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity10", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity10", RemarkActivity10);

            // Activity11
            Activity11 = new (this, "x_Activity11", 11, SqlDbType.Bit) {
                Name = "Activity11",
                Expression = "dbo.TRChecklist.Activity11",
                BasicSearchExpression = "dbo.TRChecklist.Activity11",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity11",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity11", "CustomMsg"),
                IsUpload = false
            };
            Activity11.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity11", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity11", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity11", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity11", Activity11);

            // RemarkActivity11
            RemarkActivity11 = new (this, "x_RemarkActivity11", 203, SqlDbType.NText) {
                Name = "RemarkActivity11",
                Expression = "dbo.TRChecklist.RemarkActivity11",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity11",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity11",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity11", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity11", RemarkActivity11);

            // Activity12
            Activity12 = new (this, "x_Activity12", 11, SqlDbType.Bit) {
                Name = "Activity12",
                Expression = "dbo.TRChecklist.Activity12",
                BasicSearchExpression = "dbo.TRChecklist.Activity12",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity12",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity12", "CustomMsg"),
                IsUpload = false
            };
            Activity12.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity12", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity12", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity12", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity12", Activity12);

            // RemarkActivity12
            RemarkActivity12 = new (this, "x_RemarkActivity12", 203, SqlDbType.NText) {
                Name = "RemarkActivity12",
                Expression = "dbo.TRChecklist.RemarkActivity12",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity12",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity12",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity12", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity12", RemarkActivity12);

            // Activity13
            Activity13 = new (this, "x_Activity13", 11, SqlDbType.Bit) {
                Name = "Activity13",
                Expression = "dbo.TRChecklist.Activity13",
                BasicSearchExpression = "dbo.TRChecklist.Activity13",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity13",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity13", "CustomMsg"),
                IsUpload = false
            };
            Activity13.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity13", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity13", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity13", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity13", Activity13);

            // RemarkActivity13
            RemarkActivity13 = new (this, "x_RemarkActivity13", 203, SqlDbType.NText) {
                Name = "RemarkActivity13",
                Expression = "dbo.TRChecklist.RemarkActivity13",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity13",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity13",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity13", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity13", RemarkActivity13);

            // Activity14
            Activity14 = new (this, "x_Activity14", 11, SqlDbType.Bit) {
                Name = "Activity14",
                Expression = "dbo.TRChecklist.Activity14",
                BasicSearchExpression = "dbo.TRChecklist.Activity14",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity14",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity14", "CustomMsg"),
                IsUpload = false
            };
            Activity14.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity14", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity14", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity14", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity14", Activity14);

            // RemarkActivity14
            RemarkActivity14 = new (this, "x_RemarkActivity14", 203, SqlDbType.NText) {
                Name = "RemarkActivity14",
                Expression = "dbo.TRChecklist.RemarkActivity14",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity14",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity14",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity14", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity14", RemarkActivity14);

            // Activity20
            Activity20 = new (this, "x_Activity20", 11, SqlDbType.Bit) {
                Name = "Activity20",
                Expression = "dbo.TRChecklist.Activity20",
                BasicSearchExpression = "dbo.TRChecklist.Activity20",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity20",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity20", "CustomMsg"),
                IsUpload = false
            };
            Activity20.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity20", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity20", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity20", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity20", Activity20);

            // RemarkActivity20
            RemarkActivity20 = new (this, "x_RemarkActivity20", 203, SqlDbType.NText) {
                Name = "RemarkActivity20",
                Expression = "dbo.TRChecklist.RemarkActivity20",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity20",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity20",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity20", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity20", RemarkActivity20);

            // Activity30
            Activity30 = new (this, "x_Activity30", 11, SqlDbType.Bit) {
                Name = "Activity30",
                Expression = "dbo.TRChecklist.Activity30",
                BasicSearchExpression = "dbo.TRChecklist.Activity30",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity30",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity30", "CustomMsg"),
                IsUpload = false
            };
            Activity30.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity30", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity30", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity30", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity30", Activity30);

            // RemarkActivity30
            RemarkActivity30 = new (this, "x_RemarkActivity30", 203, SqlDbType.NText) {
                Name = "RemarkActivity30",
                Expression = "dbo.TRChecklist.RemarkActivity30",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity30",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity30",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity30", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity30", RemarkActivity30);

            // Activity40
            Activity40 = new (this, "x_Activity40", 11, SqlDbType.Bit) {
                Name = "Activity40",
                Expression = "dbo.TRChecklist.Activity40",
                BasicSearchExpression = "dbo.TRChecklist.Activity40",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity40",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity40", "CustomMsg"),
                IsUpload = false
            };
            Activity40.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity40", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity40", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity40", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity40", Activity40);

            // RemarkActivity40
            RemarkActivity40 = new (this, "x_RemarkActivity40", 203, SqlDbType.NText) {
                Name = "RemarkActivity40",
                Expression = "dbo.TRChecklist.RemarkActivity40",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity40",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity40",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity40", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity40", RemarkActivity40);

            // Activity50
            Activity50 = new (this, "x_Activity50", 11, SqlDbType.Bit) {
                Name = "Activity50",
                Expression = "dbo.TRChecklist.Activity50",
                BasicSearchExpression = "dbo.TRChecklist.Activity50",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity50",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity50", "CustomMsg"),
                IsUpload = false
            };
            Activity50.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity50", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity50", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity50", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity50", Activity50);

            // RemarkActivity50
            RemarkActivity50 = new (this, "x_RemarkActivity50", 203, SqlDbType.NText) {
                Name = "RemarkActivity50",
                Expression = "dbo.TRChecklist.RemarkActivity50",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity50",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity50",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity50", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity50", RemarkActivity50);

            // Activity60
            Activity60 = new (this, "x_Activity60", 11, SqlDbType.Bit) {
                Name = "Activity60",
                Expression = "dbo.TRChecklist.Activity60",
                BasicSearchExpression = "dbo.TRChecklist.Activity60",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity60",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity60", "CustomMsg"),
                IsUpload = false
            };
            Activity60.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity60", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity60", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity60", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity60", Activity60);

            // RemarkActivity60
            RemarkActivity60 = new (this, "x_RemarkActivity60", 203, SqlDbType.NText) {
                Name = "RemarkActivity60",
                Expression = "dbo.TRChecklist.RemarkActivity60",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity60",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity60",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity60", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity60", RemarkActivity60);

            // Activity70
            Activity70 = new (this, "x_Activity70", 11, SqlDbType.Bit) {
                Name = "Activity70",
                Expression = "dbo.TRChecklist.Activity70",
                BasicSearchExpression = "dbo.TRChecklist.Activity70",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity70",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity70", "CustomMsg"),
                IsUpload = false
            };
            Activity70.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Activity70", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Activity70", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Activity70", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Activity70", Activity70);

            // RemarkActivity70
            RemarkActivity70 = new (this, "x_RemarkActivity70", 203, SqlDbType.NText) {
                Name = "RemarkActivity70",
                Expression = "dbo.TRChecklist.RemarkActivity70",
                BasicSearchExpression = "dbo.TRChecklist.RemarkActivity70",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.RemarkActivity70",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "RemarkActivity70", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RemarkActivity70", RemarkActivity70);

            // InterviewerComment
            InterviewerComment = new (this, "x_InterviewerComment", 202, SqlDbType.NVarChar) {
                Name = "InterviewerComment",
                Expression = "dbo.TRChecklist.InterviewerComment",
                BasicSearchExpression = "dbo.TRChecklist.InterviewerComment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.InterviewerComment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "InterviewerComment", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewerComment", InterviewerComment);

            // JobKnowledge
            JobKnowledge = new (this, "x_JobKnowledge", 202, SqlDbType.NVarChar) {
                Name = "JobKnowledge",
                Expression = "dbo.TRChecklist.JobKnowledge",
                BasicSearchExpression = "dbo.TRChecklist.JobKnowledge",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.JobKnowledge",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 3,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "JobKnowledge", "CustomMsg"),
                IsUpload = false
            };
            JobKnowledge.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("JobKnowledge", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("JobKnowledge", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("JobKnowledge", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("JobKnowledge", JobKnowledge);

            // SafetyAwareness
            SafetyAwareness = new (this, "x_SafetyAwareness", 202, SqlDbType.NVarChar) {
                Name = "SafetyAwareness",
                Expression = "dbo.TRChecklist.SafetyAwareness",
                BasicSearchExpression = "dbo.TRChecklist.SafetyAwareness",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.SafetyAwareness",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 3,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "SafetyAwareness", "CustomMsg"),
                IsUpload = false
            };
            SafetyAwareness.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("SafetyAwareness", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("SafetyAwareness", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("SafetyAwareness", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("SafetyAwareness", SafetyAwareness);

            // Personality
            Personality = new (this, "x_Personality", 202, SqlDbType.NVarChar) {
                Name = "Personality",
                Expression = "dbo.TRChecklist.Personality",
                BasicSearchExpression = "dbo.TRChecklist.Personality",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Personality",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 3,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Personality", "CustomMsg"),
                IsUpload = false
            };
            Personality.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Personality", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Personality", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Personality", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Personality", Personality);

            // EnglishProficiency
            EnglishProficiency = new (this, "x_EnglishProficiency", 202, SqlDbType.NVarChar) {
                Name = "EnglishProficiency",
                Expression = "dbo.TRChecklist.EnglishProficiency",
                BasicSearchExpression = "dbo.TRChecklist.EnglishProficiency",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.EnglishProficiency",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 3,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "EnglishProficiency", "CustomMsg"),
                IsUpload = false
            };
            EnglishProficiency.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("EnglishProficiency", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("EnglishProficiency", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("EnglishProficiency", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("EnglishProficiency", EnglishProficiency);

            // PrincipalComment
            PrincipalComment = new (this, "x_PrincipalComment", 202, SqlDbType.NVarChar) {
                Name = "PrincipalComment",
                Expression = "dbo.TRChecklist.PrincipalComment",
                BasicSearchExpression = "dbo.TRChecklist.PrincipalComment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.PrincipalComment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "PrincipalComment", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrincipalComment", PrincipalComment);

            // CreatedByUserID
            CreatedByUserID = new (this, "x_CreatedByUserID", 3, SqlDbType.Int) {
                Name = "CreatedByUserID",
                Expression = "dbo.TRChecklist.CreatedByUserID",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST(dbo.TRChecklist.CreatedByUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.CreatedByUserID",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "CreatedByUserID", "CustomMsg"),
                IsUpload = false
            };
            CreatedByUserID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedByUserID", "CrewChecklistForAdmin", true, "CreatedByUserID", new List<string> {"CreatedByUserID", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CreatedByUserID", "CrewChecklistForAdmin", true, "CreatedByUserID", new List<string> {"CreatedByUserID", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CreatedByUserID", "CrewChecklistForAdmin", true, "CreatedByUserID", new List<string> {"CreatedByUserID", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CreatedByUserID", CreatedByUserID);

            // CreatedDateTime
            CreatedDateTime = new (this, "x_CreatedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "CreatedDateTime",
                Expression = "dbo.TRChecklist.CreatedDateTime",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("dbo.TRChecklist.CreatedDateTime", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.TRChecklist.CreatedDateTime",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "CreatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            CreatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedDateTime", "CrewChecklistForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CreatedDateTime", "CrewChecklistForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CreatedDateTime", "CrewChecklistForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CreatedDateTime", CreatedDateTime);

            // LastUpdatedByUserID
            LastUpdatedByUserID = new (this, "x_LastUpdatedByUserID", 3, SqlDbType.Int) {
                Name = "LastUpdatedByUserID",
                Expression = "dbo.TRChecklist.LastUpdatedByUserID",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST(dbo.TRChecklist.LastUpdatedByUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.LastUpdatedByUserID",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "LastUpdatedByUserID", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedByUserID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedByUserID", "CrewChecklistForAdmin", true, "LastUpdatedByUserID", new List<string> {"LastUpdatedByUserID", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedByUserID", "CrewChecklistForAdmin", true, "LastUpdatedByUserID", new List<string> {"LastUpdatedByUserID", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedByUserID", "CrewChecklistForAdmin", true, "LastUpdatedByUserID", new List<string> {"LastUpdatedByUserID", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("LastUpdatedByUserID", LastUpdatedByUserID);

            // LastUpdatedDateTime
            LastUpdatedDateTime = new (this, "x_LastUpdatedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "LastUpdatedDateTime",
                Expression = "dbo.TRChecklist.LastUpdatedDateTime",
                UseBasicSearch = true,
                BasicSearchExpression = CastDateFieldForLike("dbo.TRChecklist.LastUpdatedDateTime", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.TRChecklist.LastUpdatedDateTime",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "LastUpdatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedDateTime", "CrewChecklistForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedDateTime", "CrewChecklistForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedDateTime", "CrewChecklistForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("LastUpdatedDateTime", LastUpdatedDateTime);

            // FinalInterviewComment
            FinalInterviewComment = new (this, "x_FinalInterviewComment", 202, SqlDbType.NVarChar) {
                Name = "FinalInterviewComment",
                Expression = "dbo.TRChecklist.FinalInterviewComment",
                BasicSearchExpression = "dbo.TRChecklist.FinalInterviewComment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.FinalInterviewComment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "FinalInterviewComment", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("FinalInterviewComment", FinalInterviewComment);

            // InterviewedByPersonOneName
            InterviewedByPersonOneName = new (this, "x_InterviewedByPersonOneName", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonOneName",
                Expression = "dbo.TRChecklist.InterviewedByPersonOneName",
                BasicSearchExpression = "dbo.TRChecklist.InterviewedByPersonOneName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.InterviewedByPersonOneName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "InterviewedByPersonOneName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonOneName", InterviewedByPersonOneName);

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank = new (this, "x_InterviewedByPersonOneRank", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonOneRank",
                Expression = "dbo.TRChecklist.InterviewedByPersonOneRank",
                BasicSearchExpression = "dbo.TRChecklist.InterviewedByPersonOneRank",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.InterviewedByPersonOneRank",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "InterviewedByPersonOneRank", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonOneRank", InterviewedByPersonOneRank);

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate = new (this, "x_AssistantManagerPdeReviewedDate", 133, SqlDbType.Date) {
                Name = "AssistantManagerPdeReviewedDate",
                Expression = "dbo.TRChecklist.AssistantManagerPdeReviewedDate",
                BasicSearchExpression = CastDateFieldForLike("dbo.TRChecklist.AssistantManagerPdeReviewedDate", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.TRChecklist.AssistantManagerPdeReviewedDate",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "AssistantManagerPdeReviewedDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AssistantManagerPdeReviewedDate", AssistantManagerPdeReviewedDate);

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName = new (this, "x_InterviewedByPersonTwoName", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonTwoName",
                Expression = "dbo.TRChecklist.InterviewedByPersonTwoName",
                BasicSearchExpression = "dbo.TRChecklist.InterviewedByPersonTwoName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.InterviewedByPersonTwoName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "InterviewedByPersonTwoName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonTwoName", InterviewedByPersonTwoName);

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank = new (this, "x_InterviewedByPersonTwoRank", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonTwoRank",
                Expression = "dbo.TRChecklist.InterviewedByPersonTwoRank",
                BasicSearchExpression = "dbo.TRChecklist.InterviewedByPersonTwoRank",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.InterviewedByPersonTwoRank",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "InterviewedByPersonTwoRank", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonTwoRank", InterviewedByPersonTwoRank);

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName = new (this, "x_InterviewedByPersonThreeName", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonThreeName",
                Expression = "dbo.TRChecklist.InterviewedByPersonThreeName",
                BasicSearchExpression = "dbo.TRChecklist.InterviewedByPersonThreeName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.InterviewedByPersonThreeName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "InterviewedByPersonThreeName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonThreeName", InterviewedByPersonThreeName);

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank = new (this, "x_InterviewedByPersonThreeRank", 202, SqlDbType.NVarChar) {
                Name = "InterviewedByPersonThreeRank",
                Expression = "dbo.TRChecklist.InterviewedByPersonThreeRank",
                BasicSearchExpression = "dbo.TRChecklist.InterviewedByPersonThreeRank",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.InterviewedByPersonThreeRank",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "InterviewedByPersonThreeRank", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewedByPersonThreeRank", InterviewedByPersonThreeRank);

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate = new (this, "x_CrewingManagerApprovalDate", 133, SqlDbType.Date) {
                Name = "CrewingManagerApprovalDate",
                Expression = "dbo.TRChecklist.CrewingManagerApprovalDate",
                BasicSearchExpression = CastDateFieldForLike("dbo.TRChecklist.CrewingManagerApprovalDate", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.TRChecklist.CrewingManagerApprovalDate",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "CrewingManagerApprovalDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("CrewingManagerApprovalDate", CrewingManagerApprovalDate);

            // Activity14Attachment
            Activity14Attachment = new (this, "x_Activity14Attachment", 202, SqlDbType.NVarChar) {
                Name = "Activity14Attachment",
                Expression = "dbo.TRChecklist.Activity14Attachment",
                BasicSearchExpression = "dbo.TRChecklist.Activity14Attachment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity14Attachment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity14Attachment", "CustomMsg"),
                IsUpload = true
            };
            Fields.Add("Activity14Attachment", Activity14Attachment);

            // Activity20Attachment
            Activity20Attachment = new (this, "x_Activity20Attachment", 202, SqlDbType.NVarChar) {
                Name = "Activity20Attachment",
                Expression = "dbo.TRChecklist.Activity20Attachment",
                BasicSearchExpression = "dbo.TRChecklist.Activity20Attachment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity20Attachment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity20Attachment", "CustomMsg"),
                IsUpload = true
            };
            Fields.Add("Activity20Attachment", Activity20Attachment);

            // Activity30Attachment
            Activity30Attachment = new (this, "x_Activity30Attachment", 202, SqlDbType.NVarChar) {
                Name = "Activity30Attachment",
                Expression = "dbo.TRChecklist.Activity30Attachment",
                BasicSearchExpression = "dbo.TRChecklist.Activity30Attachment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity30Attachment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity30Attachment", "CustomMsg"),
                IsUpload = true
            };
            Fields.Add("Activity30Attachment", Activity30Attachment);

            // Activity50Attachment
            Activity50Attachment = new (this, "x_Activity50Attachment", 202, SqlDbType.NVarChar) {
                Name = "Activity50Attachment",
                Expression = "dbo.TRChecklist.Activity50Attachment",
                BasicSearchExpression = "dbo.TRChecklist.Activity50Attachment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity50Attachment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000003,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity50Attachment", "CustomMsg"),
                IsUpload = true
            };
            Fields.Add("Activity50Attachment", Activity50Attachment);

            // Activity70Attachment
            Activity70Attachment = new (this, "x_Activity70Attachment", 202, SqlDbType.NVarChar) {
                Name = "Activity70Attachment",
                Expression = "dbo.TRChecklist.Activity70Attachment",
                BasicSearchExpression = "dbo.TRChecklist.Activity70Attachment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.Activity70Attachment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "Activity70Attachment", "CustomMsg"),
                IsUpload = true
            };
            Fields.Add("Activity70Attachment", Activity70Attachment);

            // FinalInterviewAttachment
            FinalInterviewAttachment = new (this, "x_FinalInterviewAttachment", 202, SqlDbType.NVarChar) {
                Name = "FinalInterviewAttachment",
                Expression = "dbo.TRChecklist.FinalInterviewAttachment",
                BasicSearchExpression = "dbo.TRChecklist.FinalInterviewAttachment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.FinalInterviewAttachment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "FinalInterviewAttachment", "CustomMsg"),
                IsUpload = true
            };
            Fields.Add("FinalInterviewAttachment", FinalInterviewAttachment);

            // PrincipalCommentAttachment
            PrincipalCommentAttachment = new (this, "x_PrincipalCommentAttachment", 202, SqlDbType.NVarChar) {
                Name = "PrincipalCommentAttachment",
                Expression = "dbo.TRChecklist.PrincipalCommentAttachment",
                BasicSearchExpression = "dbo.TRChecklist.PrincipalCommentAttachment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.PrincipalCommentAttachment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "PrincipalCommentAttachment", "CustomMsg"),
                IsUpload = true
            };
            Fields.Add("PrincipalCommentAttachment", PrincipalCommentAttachment);

            // FormPrintoutAttachment
            FormPrintoutAttachment = new (this, "x_FormPrintoutAttachment", 202, SqlDbType.NVarChar) {
                Name = "FormPrintoutAttachment",
                Expression = "dbo.TRChecklist.FormPrintoutAttachment",
                BasicSearchExpression = "dbo.TRChecklist.FormPrintoutAttachment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.FormPrintoutAttachment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "FormPrintoutAttachment", "CustomMsg"),
                IsUpload = true
            };
            Fields.Add("FormPrintoutAttachment", FormPrintoutAttachment);

            // AssistantManagerPdeReviewed
            AssistantManagerPdeReviewed = new (this, "x_AssistantManagerPdeReviewed", 11, SqlDbType.Bit) {
                Name = "AssistantManagerPdeReviewed",
                Expression = "dbo.TRChecklist.AssistantManagerPdeReviewed",
                BasicSearchExpression = "dbo.TRChecklist.AssistantManagerPdeReviewed",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.AssistantManagerPdeReviewed",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "AssistantManagerPdeReviewed", "CustomMsg"),
                IsUpload = false
            };
            AssistantManagerPdeReviewed.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("AssistantManagerPdeReviewed", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("AssistantManagerPdeReviewed", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("AssistantManagerPdeReviewed", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("AssistantManagerPdeReviewed", AssistantManagerPdeReviewed);

            // CrewingManagerApproval
            CrewingManagerApproval = new (this, "x_CrewingManagerApproval", 11, SqlDbType.Bit) {
                Name = "CrewingManagerApproval",
                Expression = "dbo.TRChecklist.CrewingManagerApproval",
                BasicSearchExpression = "dbo.TRChecklist.CrewingManagerApproval",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.CrewingManagerApproval",
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
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "CrewingManagerApproval", "CustomMsg"),
                IsUpload = false
            };
            CrewingManagerApproval.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CrewingManagerApproval", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CrewingManagerApproval", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CrewingManagerApproval", "CrewChecklistForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CrewingManagerApproval", CrewingManagerApproval);

            // InterviewDate
            InterviewDate = new (this, "x_InterviewDate", 133, SqlDbType.Date) {
                Name = "InterviewDate",
                Expression = "dbo.TRChecklist.InterviewDate",
                BasicSearchExpression = CastDateFieldForLike("dbo.TRChecklist.InterviewDate", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.TRChecklist.InterviewDate",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "InterviewDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewDate", InterviewDate);

            // InterviewAttachment
            InterviewAttachment = new (this, "x_InterviewAttachment", 202, SqlDbType.NVarChar) {
                Name = "InterviewAttachment",
                Expression = "dbo.TRChecklist.InterviewAttachment",
                BasicSearchExpression = "dbo.TRChecklist.InterviewAttachment",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.InterviewAttachment",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpeg,jpg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "InterviewAttachment", "CustomMsg"),
                IsUpload = true
            };
            Fields.Add("InterviewAttachment", InterviewAttachment);

            // ApprovedByUserID1
            ApprovedByUserID1 = new (this, "x_ApprovedByUserID1", 3, SqlDbType.Int) {
                Name = "ApprovedByUserID1",
                Expression = "dbo.TRChecklist.ApprovedByUserID1",
                BasicSearchExpression = "CAST(dbo.TRChecklist.ApprovedByUserID1 AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.ApprovedByUserID1",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "ApprovedByUserID1", "CustomMsg"),
                IsUpload = false
            };
            ApprovedByUserID1.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ApprovedByUserID1", "MTUser", false, "ID", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[FullName]"),
                "id-ID" => new Lookup<DbField>("ApprovedByUserID1", "MTUser", false, "ID", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[FullName]"),
                _ => new Lookup<DbField>("ApprovedByUserID1", "MTUser", false, "ID", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[FullName]")
            };
            Fields.Add("ApprovedByUserID1", ApprovedByUserID1);

            // ApprovedByUserID2
            ApprovedByUserID2 = new (this, "x_ApprovedByUserID2", 3, SqlDbType.Int) {
                Name = "ApprovedByUserID2",
                Expression = "dbo.TRChecklist.ApprovedByUserID2",
                BasicSearchExpression = "CAST(dbo.TRChecklist.ApprovedByUserID2 AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.TRChecklist.ApprovedByUserID2",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewChecklistForAdmin", "ApprovedByUserID2", "CustomMsg"),
                IsUpload = false
            };
            ApprovedByUserID2.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ApprovedByUserID2", "MTUser", false, "ID", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[FullName]"),
                "id-ID" => new Lookup<DbField>("ApprovedByUserID2", "MTUser", false, "ID", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[FullName]"),
                _ => new Lookup<DbField>("ApprovedByUserID2", "MTUser", false, "ID", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[FullName]")
            };
            Fields.Add("ApprovedByUserID2", ApprovedByUserID2);

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

        // Current detail table name
        public string CurrentDetailTable
        {
            get => Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableDetailTable);
            set => Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableDetailTable] = value;
        }

        // List of current detail table names
        public List<string> CurrentDetailTables => CurrentDetailTable.Split(',').ToList();

        // Get detail URL
        public string DetailUrl
        {
            get {
                string detailUrl = "";
                if (CurrentDetailTable == "TRChecklistPerformance" && trChecklistPerformance != null) {
                    detailUrl = trChecklistPerformance.ListUrl + "?" + Config.TableShowMaster + "=" + TableVar;
                    detailUrl += "&" + ForeignKeyUrl("fk_ID", ID.CurrentValue);
                }
                if (Empty(detailUrl))
                    detailUrl = "CrewChecklistForAdminList";
                return detailUrl;
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
            get => _sqlFrom ?? "dbo.TRChecklist";
            set => _sqlFrom = value;
        }

        // SELECT
        private string? _sqlSelect = null;

        public string SqlSelect { // Select
            get => _sqlSelect ?? "SELECT dbo.TRChecklist.ID, dbo.TRChecklist.MTCrewID, dbo.TRChecklist.Activity10, dbo.TRChecklist.RemarkActivity10, dbo.TRChecklist.Activity11, dbo.TRChecklist.RemarkActivity11, dbo.TRChecklist.Activity12, dbo.TRChecklist.RemarkActivity12, dbo.TRChecklist.Activity13, dbo.TRChecklist.RemarkActivity13, dbo.TRChecklist.Activity14, dbo.TRChecklist.RemarkActivity14, dbo.TRChecklist.Activity14Attachment, dbo.TRChecklist.Activity20, dbo.TRChecklist.RemarkActivity20, dbo.TRChecklist.Activity20Attachment, dbo.TRChecklist.Activity30, dbo.TRChecklist.RemarkActivity30, dbo.TRChecklist.Activity30Attachment, dbo.TRChecklist.Activity40, dbo.TRChecklist.RemarkActivity40, dbo.TRChecklist.Activity50, dbo.TRChecklist.RemarkActivity50, dbo.TRChecklist.Activity50Attachment, dbo.TRChecklist.Activity60, dbo.TRChecklist.RemarkActivity60, dbo.TRChecklist.Activity70, dbo.TRChecklist.RemarkActivity70, dbo.TRChecklist.Activity70Attachment, dbo.TRChecklist.InterviewerComment, dbo.TRChecklist.InterviewDate, dbo.TRChecklist.InterviewAttachment, dbo.TRChecklist.InterviewedByPersonOneName, dbo.TRChecklist.InterviewedByPersonOneRank, dbo.TRChecklist.InterviewedByPersonTwoName, dbo.TRChecklist.InterviewedByPersonTwoRank, dbo.TRChecklist.InterviewedByPersonThreeName, dbo.TRChecklist.InterviewedByPersonThreeRank, dbo.TRChecklist.FinalInterviewComment, dbo.TRChecklist.FinalInterviewAttachment, dbo.TRChecklist.JobKnowledge, dbo.TRChecklist.SafetyAwareness, dbo.TRChecklist.Personality, dbo.TRChecklist.EnglishProficiency, dbo.TRChecklist.PrincipalComment, dbo.TRChecklist.PrincipalCommentAttachment, dbo.TRChecklist.AssistantManagerPdeReviewed, dbo.TRChecklist.AssistantManagerPdeReviewedDate, dbo.TRChecklist.CrewingManagerApproval, dbo.TRChecklist.CrewingManagerApprovalDate, dbo.TRChecklist.FormPrintoutAttachment, dbo.TRChecklist.CreatedByUserID, dbo.TRChecklist.CreatedDateTime, dbo.TRChecklist.LastUpdatedByUserID, dbo.TRChecklist.LastUpdatedDateTime, dbo.TRChecklist.ApprovedByUserID1, dbo.TRChecklist.ApprovedByUserID2 FROM " + SqlFrom;
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
            bool cascadeUpdate = false;
            DbDataReader? drwrk;
            int updateResult;
            Dictionary<string, object> rscascade = new ();
            if (rsold != null) {
            }
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
            List<Dictionary<string, object>>? dtlrows;
            if (row != null) {
            }
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
                MTCrewID.DbValue = row["MTCrewID"]; // Set DB value only
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
                JobKnowledge.DbValue = row["JobKnowledge"]; // Set DB value only
                SafetyAwareness.DbValue = row["SafetyAwareness"]; // Set DB value only
                Personality.DbValue = row["Personality"]; // Set DB value only
                EnglishProficiency.DbValue = row["EnglishProficiency"]; // Set DB value only
                PrincipalComment.DbValue = row["PrincipalComment"]; // Set DB value only
                CreatedByUserID.DbValue = row["CreatedByUserID"]; // Set DB value only
                CreatedDateTime.DbValue = row["CreatedDateTime"]; // Set DB value only
                LastUpdatedByUserID.DbValue = row["LastUpdatedByUserID"]; // Set DB value only
                LastUpdatedDateTime.DbValue = row["LastUpdatedDateTime"]; // Set DB value only
                FinalInterviewComment.DbValue = row["FinalInterviewComment"]; // Set DB value only
                InterviewedByPersonOneName.DbValue = row["InterviewedByPersonOneName"]; // Set DB value only
                InterviewedByPersonOneRank.DbValue = row["InterviewedByPersonOneRank"]; // Set DB value only
                AssistantManagerPdeReviewedDate.DbValue = row["AssistantManagerPdeReviewedDate"]; // Set DB value only
                InterviewedByPersonTwoName.DbValue = row["InterviewedByPersonTwoName"]; // Set DB value only
                InterviewedByPersonTwoRank.DbValue = row["InterviewedByPersonTwoRank"]; // Set DB value only
                InterviewedByPersonThreeName.DbValue = row["InterviewedByPersonThreeName"]; // Set DB value only
                InterviewedByPersonThreeRank.DbValue = row["InterviewedByPersonThreeRank"]; // Set DB value only
                CrewingManagerApprovalDate.DbValue = row["CrewingManagerApprovalDate"]; // Set DB value only
                Activity14Attachment.Upload.DbValue = row["Activity14Attachment"];
                Activity20Attachment.Upload.DbValue = row["Activity20Attachment"];
                Activity30Attachment.Upload.DbValue = row["Activity30Attachment"];
                Activity50Attachment.Upload.DbValue = row["Activity50Attachment"];
                Activity70Attachment.Upload.DbValue = row["Activity70Attachment"];
                FinalInterviewAttachment.Upload.DbValue = row["FinalInterviewAttachment"];
                PrincipalCommentAttachment.Upload.DbValue = row["PrincipalCommentAttachment"];
                FormPrintoutAttachment.Upload.DbValue = row["FormPrintoutAttachment"];
                AssistantManagerPdeReviewed.DbValue = (ConvertToBool(row["AssistantManagerPdeReviewed"]) ? "1" : "0"); // Set DB value only
                CrewingManagerApproval.DbValue = (ConvertToBool(row["CrewingManagerApproval"]) ? "1" : "0"); // Set DB value only
                InterviewDate.DbValue = row["InterviewDate"]; // Set DB value only
                InterviewAttachment.Upload.DbValue = row["InterviewAttachment"];
                ApprovedByUserID1.DbValue = row["ApprovedByUserID1"]; // Set DB value only
                ApprovedByUserID2.DbValue = row["ApprovedByUserID2"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
            if (!Empty(row["Activity14Attachment"])) {
                DeleteFile(Activity14Attachment.OldPhysicalUploadPath + row["Activity14Attachment"]);
            }
            if (!Empty(row["Activity20Attachment"])) {
                DeleteFile(Activity20Attachment.OldPhysicalUploadPath + row["Activity20Attachment"]);
            }
            if (!Empty(row["Activity30Attachment"])) {
                DeleteFile(Activity30Attachment.OldPhysicalUploadPath + row["Activity30Attachment"]);
            }
            if (!Empty(row["Activity50Attachment"])) {
                DeleteFile(Activity50Attachment.OldPhysicalUploadPath + row["Activity50Attachment"]);
            }
            if (!Empty(row["Activity70Attachment"])) {
                DeleteFile(Activity70Attachment.OldPhysicalUploadPath + row["Activity70Attachment"]);
            }
            if (!Empty(row["FinalInterviewAttachment"])) {
                DeleteFile(FinalInterviewAttachment.OldPhysicalUploadPath + row["FinalInterviewAttachment"]);
            }
            if (!Empty(row["PrincipalCommentAttachment"])) {
                DeleteFile(PrincipalCommentAttachment.OldPhysicalUploadPath + row["PrincipalCommentAttachment"]);
            }
            if (!Empty(row["FormPrintoutAttachment"])) {
                DeleteFile(FormPrintoutAttachment.OldPhysicalUploadPath + row["FormPrintoutAttachment"]);
            }
            if (!Empty(row["InterviewAttachment"])) {
                DeleteFile(InterviewAttachment.OldPhysicalUploadPath + row["InterviewAttachment"]);
            }
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "dbo.TRChecklist.ID = @ID@";

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
                    return "CrewChecklistForAdminList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "CrewChecklistForAdminView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "CrewChecklistForAdminEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "CrewChecklistForAdminAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "CrewChecklistForAdminList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "CrewChecklistForAdminView",
                Config.ApiAddAction => "CrewChecklistForAdminAdd",
                Config.ApiEditAction => "CrewChecklistForAdminEdit",
                Config.ApiDeleteAction => "CrewChecklistForAdminDelete",
                Config.ApiListAction => "CrewChecklistForAdminList",
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
        public string ListUrl => "CrewChecklistForAdminList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("CrewChecklistForAdminView", parm);
            else
                url = KeyUrl("CrewChecklistForAdminView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "CrewChecklistForAdminAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "CrewChecklistForAdminAdd?" + parm;
            else
                url = "CrewChecklistForAdminAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("CrewChecklistForAdminEdit", parm);
            else
                url = KeyUrl("CrewChecklistForAdminEdit", Config.TableShowDetail + "=");
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewChecklistForAdminList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("CrewChecklistForAdminAdd", parm);
            else
                url = KeyUrl("CrewChecklistForAdminAdd", Config.TableShowDetail + "=");
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewChecklistForAdminList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("CrewChecklistForAdminDelete")); // DN

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
            MTCrewID.SetDbValue(dr["MTCrewID"]);
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
            JobKnowledge.SetDbValue(dr["JobKnowledge"]);
            SafetyAwareness.SetDbValue(dr["SafetyAwareness"]);
            Personality.SetDbValue(dr["Personality"]);
            EnglishProficiency.SetDbValue(dr["EnglishProficiency"]);
            PrincipalComment.SetDbValue(dr["PrincipalComment"]);
            CreatedByUserID.SetDbValue(dr["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(dr["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(dr["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(dr["LastUpdatedDateTime"]);
            FinalInterviewComment.SetDbValue(dr["FinalInterviewComment"]);
            InterviewedByPersonOneName.SetDbValue(dr["InterviewedByPersonOneName"]);
            InterviewedByPersonOneRank.SetDbValue(dr["InterviewedByPersonOneRank"]);
            AssistantManagerPdeReviewedDate.SetDbValue(dr["AssistantManagerPdeReviewedDate"]);
            InterviewedByPersonTwoName.SetDbValue(dr["InterviewedByPersonTwoName"]);
            InterviewedByPersonTwoRank.SetDbValue(dr["InterviewedByPersonTwoRank"]);
            InterviewedByPersonThreeName.SetDbValue(dr["InterviewedByPersonThreeName"]);
            InterviewedByPersonThreeRank.SetDbValue(dr["InterviewedByPersonThreeRank"]);
            CrewingManagerApprovalDate.SetDbValue(dr["CrewingManagerApprovalDate"]);
            Activity14Attachment.Upload.DbValue = dr["Activity14Attachment"];
            Activity14Attachment.SetDbValue(Activity14Attachment.Upload.DbValue);
            Activity20Attachment.Upload.DbValue = dr["Activity20Attachment"];
            Activity20Attachment.SetDbValue(Activity20Attachment.Upload.DbValue);
            Activity30Attachment.Upload.DbValue = dr["Activity30Attachment"];
            Activity30Attachment.SetDbValue(Activity30Attachment.Upload.DbValue);
            Activity50Attachment.Upload.DbValue = dr["Activity50Attachment"];
            Activity50Attachment.SetDbValue(Activity50Attachment.Upload.DbValue);
            Activity70Attachment.Upload.DbValue = dr["Activity70Attachment"];
            Activity70Attachment.SetDbValue(Activity70Attachment.Upload.DbValue);
            FinalInterviewAttachment.Upload.DbValue = dr["FinalInterviewAttachment"];
            FinalInterviewAttachment.SetDbValue(FinalInterviewAttachment.Upload.DbValue);
            PrincipalCommentAttachment.Upload.DbValue = dr["PrincipalCommentAttachment"];
            PrincipalCommentAttachment.SetDbValue(PrincipalCommentAttachment.Upload.DbValue);
            FormPrintoutAttachment.Upload.DbValue = dr["FormPrintoutAttachment"];
            FormPrintoutAttachment.SetDbValue(FormPrintoutAttachment.Upload.DbValue);
            AssistantManagerPdeReviewed.SetDbValue(ConvertToBool(dr["AssistantManagerPdeReviewed"]) ? "1" : "0");
            CrewingManagerApproval.SetDbValue(ConvertToBool(dr["CrewingManagerApproval"]) ? "1" : "0");
            InterviewDate.SetDbValue(dr["InterviewDate"]);
            InterviewAttachment.Upload.DbValue = dr["InterviewAttachment"];
            InterviewAttachment.SetDbValue(InterviewAttachment.Upload.DbValue);
            ApprovedByUserID1.SetDbValue(dr["ApprovedByUserID1"]);
            ApprovedByUserID2.SetDbValue(dr["ApprovedByUserID2"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "CrewChecklistForAdminList";
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

            // MTCrewID
            MTCrewID.CellCssStyle = "white-space: nowrap;";

            // Activity10
            Activity10.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity10
            RemarkActivity10.CellCssStyle = "white-space: nowrap;";

            // Activity11
            Activity11.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity11
            RemarkActivity11.CellCssStyle = "white-space: nowrap;";

            // Activity12
            Activity12.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity12
            RemarkActivity12.CellCssStyle = "white-space: nowrap;";

            // Activity13
            Activity13.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity13
            RemarkActivity13.CellCssStyle = "white-space: nowrap;";

            // Activity14
            Activity14.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity14
            RemarkActivity14.CellCssStyle = "white-space: nowrap;";

            // Activity20
            Activity20.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity20
            RemarkActivity20.CellCssStyle = "white-space: nowrap;";

            // Activity30
            Activity30.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity30
            RemarkActivity30.CellCssStyle = "white-space: nowrap;";

            // Activity40
            Activity40.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity40
            RemarkActivity40.CellCssStyle = "white-space: nowrap;";

            // Activity50
            Activity50.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity50
            RemarkActivity50.CellCssStyle = "white-space: nowrap;";

            // Activity60
            Activity60.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity60
            RemarkActivity60.CellCssStyle = "white-space: nowrap;";

            // Activity70
            Activity70.CellCssStyle = "white-space: nowrap;";

            // RemarkActivity70
            RemarkActivity70.CellCssStyle = "white-space: nowrap;";

            // InterviewerComment
            InterviewerComment.CellCssStyle = "white-space: nowrap;";

            // JobKnowledge
            JobKnowledge.CellCssStyle = "white-space: nowrap;";

            // SafetyAwareness
            SafetyAwareness.CellCssStyle = "white-space: nowrap;";

            // Personality
            Personality.CellCssStyle = "white-space: nowrap;";

            // EnglishProficiency
            EnglishProficiency.CellCssStyle = "white-space: nowrap;";

            // PrincipalComment
            PrincipalComment.CellCssStyle = "white-space: nowrap;";

            // CreatedByUserID
            CreatedByUserID.CellCssStyle = "white-space: nowrap;";

            // CreatedDateTime
            CreatedDateTime.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedByUserID
            LastUpdatedByUserID.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedDateTime
            LastUpdatedDateTime.CellCssStyle = "white-space: nowrap;";

            // FinalInterviewComment
            FinalInterviewComment.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.CellCssStyle = "white-space: nowrap;";

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.CellCssStyle = "white-space: nowrap;";

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.CellCssStyle = "white-space: nowrap;";

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.CellCssStyle = "white-space: nowrap;";

            // Activity14Attachment
            Activity14Attachment.CellCssStyle = "white-space: nowrap;";

            // Activity20Attachment
            Activity20Attachment.CellCssStyle = "white-space: nowrap;";

            // Activity30Attachment
            Activity30Attachment.CellCssStyle = "white-space: nowrap;";

            // Activity50Attachment
            Activity50Attachment.CellCssStyle = "white-space: nowrap;";

            // Activity70Attachment
            Activity70Attachment.CellCssStyle = "white-space: nowrap;";

            // FinalInterviewAttachment
            FinalInterviewAttachment.CellCssStyle = "white-space: nowrap;";

            // PrincipalCommentAttachment
            PrincipalCommentAttachment.CellCssStyle = "white-space: nowrap;";

            // FormPrintoutAttachment
            FormPrintoutAttachment.CellCssStyle = "white-space: nowrap;";

            // AssistantManagerPdeReviewed
            AssistantManagerPdeReviewed.CellCssStyle = "white-space: nowrap;";

            // CrewingManagerApproval
            CrewingManagerApproval.CellCssStyle = "white-space: nowrap;";

            // InterviewDate
            InterviewDate.CellCssStyle = "white-space: nowrap;";

            // InterviewAttachment
            InterviewAttachment.CellCssStyle = "white-space: nowrap;";

            // ApprovedByUserID1

            // ApprovedByUserID2

            // ID
            ID.ViewValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

            // MTCrewID
            MTCrewID.ViewValue = MTCrewID.CurrentValue;
            MTCrewID.ViewValue = FormatNumber(MTCrewID.ViewValue, MTCrewID.FormatPattern);
            MTCrewID.ViewCustomAttributes = "";

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
            InterviewerComment.ViewValue = InterviewerComment.CurrentValue;
            InterviewerComment.ViewCustomAttributes = "";

            // JobKnowledge
            if (!Empty(JobKnowledge.CurrentValue)) {
                JobKnowledge.ViewValue = JobKnowledge.HighlightLookup(ConvertToString(JobKnowledge.CurrentValue), JobKnowledge.OptionCaption(ConvertToString(JobKnowledge.CurrentValue)));
            } else {
                JobKnowledge.ViewValue = DbNullValue;
            }
            JobKnowledge.ViewCustomAttributes = "";

            // SafetyAwareness
            if (!Empty(SafetyAwareness.CurrentValue)) {
                SafetyAwareness.ViewValue = SafetyAwareness.HighlightLookup(ConvertToString(SafetyAwareness.CurrentValue), SafetyAwareness.OptionCaption(ConvertToString(SafetyAwareness.CurrentValue)));
            } else {
                SafetyAwareness.ViewValue = DbNullValue;
            }
            SafetyAwareness.ViewCustomAttributes = "";

            // Personality
            if (!Empty(Personality.CurrentValue)) {
                Personality.ViewValue = Personality.HighlightLookup(ConvertToString(Personality.CurrentValue), Personality.OptionCaption(ConvertToString(Personality.CurrentValue)));
            } else {
                Personality.ViewValue = DbNullValue;
            }
            Personality.ViewCustomAttributes = "";

            // EnglishProficiency
            if (!Empty(EnglishProficiency.CurrentValue)) {
                EnglishProficiency.ViewValue = EnglishProficiency.HighlightLookup(ConvertToString(EnglishProficiency.CurrentValue), EnglishProficiency.OptionCaption(ConvertToString(EnglishProficiency.CurrentValue)));
            } else {
                EnglishProficiency.ViewValue = DbNullValue;
            }
            EnglishProficiency.ViewCustomAttributes = "";

            // PrincipalComment
            PrincipalComment.ViewValue = PrincipalComment.CurrentValue;
            PrincipalComment.ViewCustomAttributes = "";

            // CreatedByUserID
            CreatedByUserID.ViewValue = CreatedByUserID.CurrentValue;
            CreatedByUserID.ViewValue = FormatNumber(CreatedByUserID.ViewValue, CreatedByUserID.FormatPattern);
            CreatedByUserID.ViewCustomAttributes = "";

            // CreatedDateTime
            CreatedDateTime.ViewValue = CreatedDateTime.CurrentValue;
            CreatedDateTime.ViewValue = FormatDateTime(CreatedDateTime.ViewValue, CreatedDateTime.FormatPattern);
            CreatedDateTime.ViewCustomAttributes = "";

            // LastUpdatedByUserID
            LastUpdatedByUserID.ViewValue = LastUpdatedByUserID.CurrentValue;
            LastUpdatedByUserID.ViewValue = FormatNumber(LastUpdatedByUserID.ViewValue, LastUpdatedByUserID.FormatPattern);
            LastUpdatedByUserID.ViewCustomAttributes = "";

            // LastUpdatedDateTime
            LastUpdatedDateTime.ViewValue = LastUpdatedDateTime.CurrentValue;
            LastUpdatedDateTime.ViewValue = FormatDateTime(LastUpdatedDateTime.ViewValue, LastUpdatedDateTime.FormatPattern);
            LastUpdatedDateTime.ViewCustomAttributes = "";

            // FinalInterviewComment
            FinalInterviewComment.ViewValue = FinalInterviewComment.CurrentValue;
            FinalInterviewComment.ViewCustomAttributes = "";

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.ViewValue = ConvertToString(InterviewedByPersonOneName.CurrentValue); // DN
            InterviewedByPersonOneName.ViewCustomAttributes = "";

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.ViewValue = ConvertToString(InterviewedByPersonOneRank.CurrentValue); // DN
            InterviewedByPersonOneRank.ViewCustomAttributes = "";

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

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.ViewValue = ConvertToString(InterviewedByPersonThreeName.CurrentValue); // DN
            InterviewedByPersonThreeName.ViewCustomAttributes = "";

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.ViewValue = ConvertToString(InterviewedByPersonThreeRank.CurrentValue); // DN
            InterviewedByPersonThreeRank.ViewCustomAttributes = "";

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.ViewValue = CrewingManagerApprovalDate.CurrentValue;
            CrewingManagerApprovalDate.ViewValue = FormatDateTime(CrewingManagerApprovalDate.ViewValue, CrewingManagerApprovalDate.FormatPattern);
            CrewingManagerApprovalDate.ViewCustomAttributes = "";

            // Activity14Attachment
            if (!IsNull(Activity14Attachment.Upload.DbValue)) {
                Activity14Attachment.ViewValue = Activity14Attachment.Upload.DbValue;
            } else {
                Activity14Attachment.ViewValue = "";
            }
            Activity14Attachment.ViewCustomAttributes = "";

            // Activity20Attachment
            if (!IsNull(Activity20Attachment.Upload.DbValue)) {
                Activity20Attachment.ViewValue = Activity20Attachment.Upload.DbValue;
            } else {
                Activity20Attachment.ViewValue = "";
            }
            Activity20Attachment.ViewCustomAttributes = "";

            // Activity30Attachment
            if (!IsNull(Activity30Attachment.Upload.DbValue)) {
                Activity30Attachment.ViewValue = Activity30Attachment.Upload.DbValue;
            } else {
                Activity30Attachment.ViewValue = "";
            }
            Activity30Attachment.ViewCustomAttributes = "";

            // Activity50Attachment
            if (!IsNull(Activity50Attachment.Upload.DbValue)) {
                Activity50Attachment.ViewValue = Activity50Attachment.Upload.DbValue;
            } else {
                Activity50Attachment.ViewValue = "";
            }
            Activity50Attachment.ViewCustomAttributes = "";

            // Activity70Attachment
            if (!IsNull(Activity70Attachment.Upload.DbValue)) {
                Activity70Attachment.ViewValue = Activity70Attachment.Upload.DbValue;
            } else {
                Activity70Attachment.ViewValue = "";
            }
            Activity70Attachment.ViewCustomAttributes = "";

            // FinalInterviewAttachment
            if (!IsNull(FinalInterviewAttachment.Upload.DbValue)) {
                FinalInterviewAttachment.ViewValue = FinalInterviewAttachment.Upload.DbValue;
            } else {
                FinalInterviewAttachment.ViewValue = "";
            }
            FinalInterviewAttachment.ViewCustomAttributes = "";

            // PrincipalCommentAttachment
            if (!IsNull(PrincipalCommentAttachment.Upload.DbValue)) {
                PrincipalCommentAttachment.ViewValue = PrincipalCommentAttachment.Upload.DbValue;
            } else {
                PrincipalCommentAttachment.ViewValue = "";
            }
            PrincipalCommentAttachment.ViewCustomAttributes = "";

            // FormPrintoutAttachment
            if (!IsNull(FormPrintoutAttachment.Upload.DbValue)) {
                FormPrintoutAttachment.ViewValue = FormPrintoutAttachment.Upload.DbValue;
            } else {
                FormPrintoutAttachment.ViewValue = "";
            }
            FormPrintoutAttachment.ViewCustomAttributes = "";

            // AssistantManagerPdeReviewed
            if (ConvertToBool(AssistantManagerPdeReviewed.CurrentValue)) {
                AssistantManagerPdeReviewed.ViewValue = AssistantManagerPdeReviewed.TagCaption(1) != "" ? AssistantManagerPdeReviewed.TagCaption(1) : "Yes";
            } else {
                AssistantManagerPdeReviewed.ViewValue = AssistantManagerPdeReviewed.TagCaption(2) != "" ? AssistantManagerPdeReviewed.TagCaption(2) : "No";
            }
            AssistantManagerPdeReviewed.ViewCustomAttributes = "";

            // CrewingManagerApproval
            if (ConvertToBool(CrewingManagerApproval.CurrentValue)) {
                CrewingManagerApproval.ViewValue = CrewingManagerApproval.TagCaption(1) != "" ? CrewingManagerApproval.TagCaption(1) : "Yes";
            } else {
                CrewingManagerApproval.ViewValue = CrewingManagerApproval.TagCaption(2) != "" ? CrewingManagerApproval.TagCaption(2) : "No";
            }
            CrewingManagerApproval.ViewCustomAttributes = "";

            // InterviewDate
            InterviewDate.ViewValue = InterviewDate.CurrentValue;
            InterviewDate.ViewValue = FormatDateTime(InterviewDate.ViewValue, InterviewDate.FormatPattern);
            InterviewDate.ViewCustomAttributes = "";

            // InterviewAttachment
            if (!IsNull(InterviewAttachment.Upload.DbValue)) {
                InterviewAttachment.ViewValue = InterviewAttachment.Upload.DbValue;
            } else {
                InterviewAttachment.ViewValue = "";
            }
            InterviewAttachment.ViewCustomAttributes = "";

            // ApprovedByUserID1
            ApprovedByUserID1.ViewValue = ApprovedByUserID1.CurrentValue;
            curVal = ConvertToString(ApprovedByUserID1.CurrentValue);
            if (!Empty(curVal)) {
                if (ApprovedByUserID1.Lookup != null && IsDictionary(ApprovedByUserID1.Lookup?.Options) && ApprovedByUserID1.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ApprovedByUserID1.ViewValue = ApprovedByUserID1.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", ApprovedByUserID1.CurrentValue, DataType.Number, "");
                    sqlWrk = ApprovedByUserID1.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && ApprovedByUserID1.Lookup != null) { // Lookup values found
                        var listwrk = ApprovedByUserID1.Lookup?.RenderViewRow(rswrk[0]);
                        ApprovedByUserID1.ViewValue = ApprovedByUserID1.HighlightLookup(ConvertToString(rswrk[0]), ApprovedByUserID1.DisplayValue(listwrk));
                    } else {
                        ApprovedByUserID1.ViewValue = FormatNumber(ApprovedByUserID1.CurrentValue, ApprovedByUserID1.FormatPattern);
                    }
                }
            } else {
                ApprovedByUserID1.ViewValue = DbNullValue;
            }
            ApprovedByUserID1.ViewCustomAttributes = "";

            // ApprovedByUserID2
            ApprovedByUserID2.ViewValue = ApprovedByUserID2.CurrentValue;
            curVal = ConvertToString(ApprovedByUserID2.CurrentValue);
            if (!Empty(curVal)) {
                if (ApprovedByUserID2.Lookup != null && IsDictionary(ApprovedByUserID2.Lookup?.Options) && ApprovedByUserID2.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ApprovedByUserID2.ViewValue = ApprovedByUserID2.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", ApprovedByUserID2.CurrentValue, DataType.Number, "");
                    sqlWrk = ApprovedByUserID2.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && ApprovedByUserID2.Lookup != null) { // Lookup values found
                        var listwrk = ApprovedByUserID2.Lookup?.RenderViewRow(rswrk[0]);
                        ApprovedByUserID2.ViewValue = ApprovedByUserID2.HighlightLookup(ConvertToString(rswrk[0]), ApprovedByUserID2.DisplayValue(listwrk));
                    } else {
                        ApprovedByUserID2.ViewValue = FormatNumber(ApprovedByUserID2.CurrentValue, ApprovedByUserID2.FormatPattern);
                    }
                }
            } else {
                ApprovedByUserID2.ViewValue = DbNullValue;
            }
            ApprovedByUserID2.ViewCustomAttributes = "";

            // ID
            ID.HrefValue = "";
            ID.TooltipValue = "";

            // MTCrewID
            MTCrewID.HrefValue = "";
            MTCrewID.TooltipValue = "";

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

            // FinalInterviewComment
            FinalInterviewComment.HrefValue = "";
            FinalInterviewComment.TooltipValue = "";

            // InterviewedByPersonOneName
            InterviewedByPersonOneName.HrefValue = "";
            InterviewedByPersonOneName.TooltipValue = "";

            // InterviewedByPersonOneRank
            InterviewedByPersonOneRank.HrefValue = "";
            InterviewedByPersonOneRank.TooltipValue = "";

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.HrefValue = "";
            AssistantManagerPdeReviewedDate.TooltipValue = "";

            // InterviewedByPersonTwoName
            InterviewedByPersonTwoName.HrefValue = "";
            InterviewedByPersonTwoName.TooltipValue = "";

            // InterviewedByPersonTwoRank
            InterviewedByPersonTwoRank.HrefValue = "";
            InterviewedByPersonTwoRank.TooltipValue = "";

            // InterviewedByPersonThreeName
            InterviewedByPersonThreeName.HrefValue = "";
            InterviewedByPersonThreeName.TooltipValue = "";

            // InterviewedByPersonThreeRank
            InterviewedByPersonThreeRank.HrefValue = "";
            InterviewedByPersonThreeRank.TooltipValue = "";

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.HrefValue = "";
            CrewingManagerApprovalDate.TooltipValue = "";

            // Activity14Attachment
            if (!IsNull(Activity14Attachment.Upload.DbValue)) {
                Activity14Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity14Attachment, Activity14Attachment.HtmlDecode(ConvertToString(Activity14Attachment.Upload.DbValue)))); // Add prefix/suffix
                Activity14Attachment.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    Activity14Attachment.HrefValue = FullUrl(ConvertToString(Activity14Attachment.HrefValue), "href");
            } else {
                Activity14Attachment.HrefValue = "";
            }
            Activity14Attachment.ExportHrefValue = Activity14Attachment.UploadPath + Activity14Attachment.Upload.DbValue;
            Activity14Attachment.TooltipValue = "";

            // Activity20Attachment
            if (!IsNull(Activity20Attachment.Upload.DbValue)) {
                Activity20Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity20Attachment, Activity20Attachment.HtmlDecode(ConvertToString(Activity20Attachment.Upload.DbValue)))); // Add prefix/suffix
                Activity20Attachment.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    Activity20Attachment.HrefValue = FullUrl(ConvertToString(Activity20Attachment.HrefValue), "href");
            } else {
                Activity20Attachment.HrefValue = "";
            }
            Activity20Attachment.ExportHrefValue = Activity20Attachment.UploadPath + Activity20Attachment.Upload.DbValue;
            Activity20Attachment.TooltipValue = "";

            // Activity30Attachment
            if (!IsNull(Activity30Attachment.Upload.DbValue)) {
                Activity30Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity30Attachment, Activity30Attachment.HtmlDecode(ConvertToString(Activity30Attachment.Upload.DbValue)))); // Add prefix/suffix
                Activity30Attachment.LinkAttrs["target"] = ""; // Add target
                if (IsExport())
                    Activity30Attachment.HrefValue = FullUrl(ConvertToString(Activity30Attachment.HrefValue), "href");
            } else {
                Activity30Attachment.HrefValue = "";
            }
            Activity30Attachment.ExportHrefValue = Activity30Attachment.UploadPath + Activity30Attachment.Upload.DbValue;
            Activity30Attachment.TooltipValue = "";

            // Activity50Attachment
            if (!IsNull(Activity50Attachment.Upload.DbValue)) {
                Activity50Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity50Attachment, Activity50Attachment.HtmlDecode(ConvertToString(Activity50Attachment.Upload.DbValue)))); // Add prefix/suffix
                Activity50Attachment.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    Activity50Attachment.HrefValue = FullUrl(ConvertToString(Activity50Attachment.HrefValue), "href");
            } else {
                Activity50Attachment.HrefValue = "";
            }
            Activity50Attachment.ExportHrefValue = Activity50Attachment.UploadPath + Activity50Attachment.Upload.DbValue;
            Activity50Attachment.TooltipValue = "";

            // Activity70Attachment
            if (!IsNull(Activity70Attachment.Upload.DbValue)) {
                Activity70Attachment.HrefValue = ConvertToString(GetFileUploadUrl(Activity70Attachment, Activity70Attachment.HtmlDecode(ConvertToString(Activity70Attachment.Upload.DbValue)))); // Add prefix/suffix
                Activity70Attachment.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    Activity70Attachment.HrefValue = FullUrl(ConvertToString(Activity70Attachment.HrefValue), "href");
            } else {
                Activity70Attachment.HrefValue = "";
            }
            Activity70Attachment.ExportHrefValue = Activity70Attachment.UploadPath + Activity70Attachment.Upload.DbValue;
            Activity70Attachment.TooltipValue = "";

            // FinalInterviewAttachment
            if (!IsNull(FinalInterviewAttachment.Upload.DbValue)) {
                FinalInterviewAttachment.HrefValue = ConvertToString(GetFileUploadUrl(FinalInterviewAttachment, FinalInterviewAttachment.HtmlDecode(ConvertToString(FinalInterviewAttachment.Upload.DbValue)))); // Add prefix/suffix
                FinalInterviewAttachment.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    FinalInterviewAttachment.HrefValue = FullUrl(ConvertToString(FinalInterviewAttachment.HrefValue), "href");
            } else {
                FinalInterviewAttachment.HrefValue = "";
            }
            FinalInterviewAttachment.ExportHrefValue = FinalInterviewAttachment.UploadPath + FinalInterviewAttachment.Upload.DbValue;
            FinalInterviewAttachment.TooltipValue = "";

            // PrincipalCommentAttachment
            if (!IsNull(PrincipalCommentAttachment.Upload.DbValue)) {
                PrincipalCommentAttachment.HrefValue = ConvertToString(GetFileUploadUrl(PrincipalCommentAttachment, PrincipalCommentAttachment.HtmlDecode(ConvertToString(PrincipalCommentAttachment.Upload.DbValue)))); // Add prefix/suffix
                PrincipalCommentAttachment.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    PrincipalCommentAttachment.HrefValue = FullUrl(ConvertToString(PrincipalCommentAttachment.HrefValue), "href");
            } else {
                PrincipalCommentAttachment.HrefValue = "";
            }
            PrincipalCommentAttachment.ExportHrefValue = PrincipalCommentAttachment.UploadPath + PrincipalCommentAttachment.Upload.DbValue;
            PrincipalCommentAttachment.TooltipValue = "";

            // FormPrintoutAttachment
            if (!IsNull(FormPrintoutAttachment.Upload.DbValue)) {
                FormPrintoutAttachment.HrefValue = ConvertToString(GetFileUploadUrl(FormPrintoutAttachment, FormPrintoutAttachment.HtmlDecode(ConvertToString(FormPrintoutAttachment.Upload.DbValue)))); // Add prefix/suffix
                FormPrintoutAttachment.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    FormPrintoutAttachment.HrefValue = FullUrl(ConvertToString(FormPrintoutAttachment.HrefValue), "href");
            } else {
                FormPrintoutAttachment.HrefValue = "";
            }
            FormPrintoutAttachment.ExportHrefValue = FormPrintoutAttachment.UploadPath + FormPrintoutAttachment.Upload.DbValue;
            FormPrintoutAttachment.TooltipValue = "";

            // AssistantManagerPdeReviewed
            AssistantManagerPdeReviewed.HrefValue = "";
            AssistantManagerPdeReviewed.TooltipValue = "";

            // CrewingManagerApproval
            CrewingManagerApproval.HrefValue = "";
            CrewingManagerApproval.TooltipValue = "";

            // InterviewDate
            InterviewDate.HrefValue = "";
            InterviewDate.TooltipValue = "";

            // InterviewAttachment
            if (!IsNull(InterviewAttachment.Upload.DbValue)) {
                InterviewAttachment.HrefValue = ConvertToString(GetFileUploadUrl(InterviewAttachment, InterviewAttachment.HtmlDecode(ConvertToString(InterviewAttachment.Upload.DbValue)))); // Add prefix/suffix
                InterviewAttachment.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    InterviewAttachment.HrefValue = FullUrl(ConvertToString(InterviewAttachment.HrefValue), "href");
            } else {
                InterviewAttachment.HrefValue = "";
            }
            InterviewAttachment.ExportHrefValue = InterviewAttachment.UploadPath + InterviewAttachment.Upload.DbValue;
            InterviewAttachment.TooltipValue = "";

            // ApprovedByUserID1
            ApprovedByUserID1.HrefValue = "";
            ApprovedByUserID1.TooltipValue = "";

            // ApprovedByUserID2
            ApprovedByUserID2.HrefValue = "";
            ApprovedByUserID2.TooltipValue = "";

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

            // MTCrewID
            MTCrewID.SetupEditAttributes();
            MTCrewID.EditValue = MTCrewID.CurrentValue; // DN
            MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);
            if (!Empty(MTCrewID.EditValue) && IsNumeric(MTCrewID.EditValue))
                MTCrewID.EditValue = FormatNumber(MTCrewID.EditValue, null);

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
            InterviewerComment.EditValue = InterviewerComment.CurrentValue; // DN
            InterviewerComment.PlaceHolder = RemoveHtml(InterviewerComment.Caption);

            // JobKnowledge
            JobKnowledge.SetupEditAttributes();
            JobKnowledge.EditValue = JobKnowledge.Options(true);
            JobKnowledge.PlaceHolder = RemoveHtml(JobKnowledge.Caption);

            // SafetyAwareness
            SafetyAwareness.SetupEditAttributes();
            SafetyAwareness.EditValue = SafetyAwareness.Options(true);
            SafetyAwareness.PlaceHolder = RemoveHtml(SafetyAwareness.Caption);

            // Personality
            Personality.SetupEditAttributes();
            Personality.EditValue = Personality.Options(true);
            Personality.PlaceHolder = RemoveHtml(Personality.Caption);

            // EnglishProficiency
            EnglishProficiency.SetupEditAttributes();
            EnglishProficiency.EditValue = EnglishProficiency.Options(true);
            EnglishProficiency.PlaceHolder = RemoveHtml(EnglishProficiency.Caption);

            // PrincipalComment
            PrincipalComment.SetupEditAttributes();
            PrincipalComment.EditValue = PrincipalComment.CurrentValue; // DN
            PrincipalComment.PlaceHolder = RemoveHtml(PrincipalComment.Caption);

            // CreatedByUserID
            CreatedByUserID.SetupEditAttributes();
            CreatedByUserID.EditValue = CreatedByUserID.CurrentValue; // DN
            CreatedByUserID.PlaceHolder = RemoveHtml(CreatedByUserID.Caption);
            if (!Empty(CreatedByUserID.EditValue) && IsNumeric(CreatedByUserID.EditValue))
                CreatedByUserID.EditValue = FormatNumber(CreatedByUserID.EditValue, null);

            // CreatedDateTime
            CreatedDateTime.SetupEditAttributes();
            CreatedDateTime.EditValue = FormatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern); // DN
            CreatedDateTime.PlaceHolder = RemoveHtml(CreatedDateTime.Caption);

            // LastUpdatedByUserID
            LastUpdatedByUserID.SetupEditAttributes();
            LastUpdatedByUserID.EditValue = LastUpdatedByUserID.CurrentValue; // DN
            LastUpdatedByUserID.PlaceHolder = RemoveHtml(LastUpdatedByUserID.Caption);
            if (!Empty(LastUpdatedByUserID.EditValue) && IsNumeric(LastUpdatedByUserID.EditValue))
                LastUpdatedByUserID.EditValue = FormatNumber(LastUpdatedByUserID.EditValue, null);

            // LastUpdatedDateTime
            LastUpdatedDateTime.SetupEditAttributes();
            LastUpdatedDateTime.EditValue = FormatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern); // DN
            LastUpdatedDateTime.PlaceHolder = RemoveHtml(LastUpdatedDateTime.Caption);

            // FinalInterviewComment
            FinalInterviewComment.SetupEditAttributes();
            FinalInterviewComment.EditValue = FinalInterviewComment.CurrentValue; // DN
            FinalInterviewComment.PlaceHolder = RemoveHtml(FinalInterviewComment.Caption);

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

            // AssistantManagerPdeReviewedDate
            AssistantManagerPdeReviewedDate.SetupEditAttributes();
            AssistantManagerPdeReviewedDate.EditValue = AssistantManagerPdeReviewedDate.CurrentValue;
            AssistantManagerPdeReviewedDate.EditValue = FormatDateTime(AssistantManagerPdeReviewedDate.EditValue, AssistantManagerPdeReviewedDate.FormatPattern);
            AssistantManagerPdeReviewedDate.ViewCustomAttributes = "";

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

            // CrewingManagerApprovalDate
            CrewingManagerApprovalDate.SetupEditAttributes();
            CrewingManagerApprovalDate.EditValue = CrewingManagerApprovalDate.CurrentValue;
            CrewingManagerApprovalDate.EditValue = FormatDateTime(CrewingManagerApprovalDate.EditValue, CrewingManagerApprovalDate.FormatPattern);
            CrewingManagerApprovalDate.ViewCustomAttributes = "";

            // Activity14Attachment
            Activity14Attachment.SetupEditAttributes();
            Activity14Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(Activity14Attachment.Upload.DbValue)) {
                Activity14Attachment.EditValue = Activity14Attachment.Upload.DbValue;
            } else {
                Activity14Attachment.EditValue = "";
            }
            if (!Empty(Activity14Attachment.CurrentValue))
                    Activity14Attachment.Upload.FileName = ConvertToString(Activity14Attachment.CurrentValue);

            // Activity20Attachment
            Activity20Attachment.SetupEditAttributes();
            Activity20Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(Activity20Attachment.Upload.DbValue)) {
                Activity20Attachment.EditValue = Activity20Attachment.Upload.DbValue;
            } else {
                Activity20Attachment.EditValue = "";
            }
            if (!Empty(Activity20Attachment.CurrentValue))
                    Activity20Attachment.Upload.FileName = ConvertToString(Activity20Attachment.CurrentValue);

            // Activity30Attachment
            Activity30Attachment.SetupEditAttributes();
            Activity30Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(Activity30Attachment.Upload.DbValue)) {
                Activity30Attachment.EditValue = Activity30Attachment.Upload.DbValue;
            } else {
                Activity30Attachment.EditValue = "";
            }
            if (!Empty(Activity30Attachment.CurrentValue))
                    Activity30Attachment.Upload.FileName = ConvertToString(Activity30Attachment.CurrentValue);

            // Activity50Attachment
            Activity50Attachment.SetupEditAttributes();
            Activity50Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(Activity50Attachment.Upload.DbValue)) {
                Activity50Attachment.EditValue = Activity50Attachment.Upload.DbValue;
            } else {
                Activity50Attachment.EditValue = "";
            }
            if (!Empty(Activity50Attachment.CurrentValue))
                    Activity50Attachment.Upload.FileName = ConvertToString(Activity50Attachment.CurrentValue);

            // Activity70Attachment
            Activity70Attachment.SetupEditAttributes();
            Activity70Attachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(Activity70Attachment.Upload.DbValue)) {
                Activity70Attachment.EditValue = Activity70Attachment.Upload.DbValue;
            } else {
                Activity70Attachment.EditValue = "";
            }
            if (!Empty(Activity70Attachment.CurrentValue))
                    Activity70Attachment.Upload.FileName = ConvertToString(Activity70Attachment.CurrentValue);

            // FinalInterviewAttachment
            FinalInterviewAttachment.SetupEditAttributes();
            FinalInterviewAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(FinalInterviewAttachment.Upload.DbValue)) {
                FinalInterviewAttachment.EditValue = FinalInterviewAttachment.Upload.DbValue;
            } else {
                FinalInterviewAttachment.EditValue = "";
            }
            if (!Empty(FinalInterviewAttachment.CurrentValue))
                    FinalInterviewAttachment.Upload.FileName = ConvertToString(FinalInterviewAttachment.CurrentValue);

            // PrincipalCommentAttachment
            PrincipalCommentAttachment.SetupEditAttributes();
            PrincipalCommentAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(PrincipalCommentAttachment.Upload.DbValue)) {
                PrincipalCommentAttachment.EditValue = PrincipalCommentAttachment.Upload.DbValue;
            } else {
                PrincipalCommentAttachment.EditValue = "";
            }
            if (!Empty(PrincipalCommentAttachment.CurrentValue))
                    PrincipalCommentAttachment.Upload.FileName = ConvertToString(PrincipalCommentAttachment.CurrentValue);

            // FormPrintoutAttachment
            FormPrintoutAttachment.SetupEditAttributes();
            FormPrintoutAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(FormPrintoutAttachment.Upload.DbValue)) {
                FormPrintoutAttachment.EditValue = FormPrintoutAttachment.Upload.DbValue;
            } else {
                FormPrintoutAttachment.EditValue = "";
            }
            if (!Empty(FormPrintoutAttachment.CurrentValue))
                    FormPrintoutAttachment.Upload.FileName = ConvertToString(FormPrintoutAttachment.CurrentValue);

            // AssistantManagerPdeReviewed
            AssistantManagerPdeReviewed.SetupEditAttributes();
            if (ConvertToBool(AssistantManagerPdeReviewed.CurrentValue)) {
                AssistantManagerPdeReviewed.EditValue = AssistantManagerPdeReviewed.TagCaption(1) != "" ? AssistantManagerPdeReviewed.TagCaption(1) : "Yes";
            } else {
                AssistantManagerPdeReviewed.EditValue = AssistantManagerPdeReviewed.TagCaption(2) != "" ? AssistantManagerPdeReviewed.TagCaption(2) : "No";
            }
            AssistantManagerPdeReviewed.ViewCustomAttributes = "";

            // CrewingManagerApproval
            CrewingManagerApproval.SetupEditAttributes();
            if (ConvertToBool(CrewingManagerApproval.CurrentValue)) {
                CrewingManagerApproval.EditValue = CrewingManagerApproval.TagCaption(1) != "" ? CrewingManagerApproval.TagCaption(1) : "Yes";
            } else {
                CrewingManagerApproval.EditValue = CrewingManagerApproval.TagCaption(2) != "" ? CrewingManagerApproval.TagCaption(2) : "No";
            }
            CrewingManagerApproval.ViewCustomAttributes = "";

            // InterviewDate
            InterviewDate.SetupEditAttributes();
            InterviewDate.EditValue = FormatDateTime(InterviewDate.CurrentValue, InterviewDate.FormatPattern); // DN
            InterviewDate.PlaceHolder = RemoveHtml(InterviewDate.Caption);

            // InterviewAttachment
            InterviewAttachment.SetupEditAttributes();
            InterviewAttachment.EditAttrs["accept"] = "jpeg,jpg,png,pdf";
            if (!IsNull(InterviewAttachment.Upload.DbValue)) {
                InterviewAttachment.EditValue = InterviewAttachment.Upload.DbValue;
            } else {
                InterviewAttachment.EditValue = "";
            }
            if (!Empty(InterviewAttachment.CurrentValue))
                    InterviewAttachment.Upload.FileName = ConvertToString(InterviewAttachment.CurrentValue);

            // ApprovedByUserID1
            ApprovedByUserID1.SetupEditAttributes();
            ApprovedByUserID1.EditValue = ApprovedByUserID1.CurrentValue;
            curVal = ConvertToString(ApprovedByUserID1.CurrentValue);
            if (!Empty(curVal)) {
                if (ApprovedByUserID1.Lookup != null && IsDictionary(ApprovedByUserID1.Lookup?.Options) && ApprovedByUserID1.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ApprovedByUserID1.EditValue = ApprovedByUserID1.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", ApprovedByUserID1.CurrentValue, DataType.Number, "");
                    sqlWrk = ApprovedByUserID1.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && ApprovedByUserID1.Lookup != null) { // Lookup values found
                        var listwrk = ApprovedByUserID1.Lookup?.RenderViewRow(rswrk[0]);
                        ApprovedByUserID1.EditValue = ApprovedByUserID1.HighlightLookup(ConvertToString(rswrk[0]), ApprovedByUserID1.DisplayValue(listwrk));
                    } else {
                        ApprovedByUserID1.EditValue = FormatNumber(ApprovedByUserID1.CurrentValue, ApprovedByUserID1.FormatPattern);
                    }
                }
            } else {
                ApprovedByUserID1.EditValue = DbNullValue;
            }
            ApprovedByUserID1.ViewCustomAttributes = "";

            // ApprovedByUserID2
            ApprovedByUserID2.SetupEditAttributes();
            ApprovedByUserID2.EditValue = ApprovedByUserID2.CurrentValue;
            curVal = ConvertToString(ApprovedByUserID2.CurrentValue);
            if (!Empty(curVal)) {
                if (ApprovedByUserID2.Lookup != null && IsDictionary(ApprovedByUserID2.Lookup?.Options) && ApprovedByUserID2.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ApprovedByUserID2.EditValue = ApprovedByUserID2.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", ApprovedByUserID2.CurrentValue, DataType.Number, "");
                    sqlWrk = ApprovedByUserID2.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && ApprovedByUserID2.Lookup != null) { // Lookup values found
                        var listwrk = ApprovedByUserID2.Lookup?.RenderViewRow(rswrk[0]);
                        ApprovedByUserID2.EditValue = ApprovedByUserID2.HighlightLookup(ConvertToString(rswrk[0]), ApprovedByUserID2.DisplayValue(listwrk));
                    } else {
                        ApprovedByUserID2.EditValue = FormatNumber(ApprovedByUserID2.CurrentValue, ApprovedByUserID2.FormatPattern);
                    }
                }
            } else {
                ApprovedByUserID2.EditValue = DbNullValue;
            }
            ApprovedByUserID2.ViewCustomAttributes = "";

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
                        doc.ExportCaption(MTCrewID);
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
                        doc.ExportCaption(JobKnowledge);
                        doc.ExportCaption(SafetyAwareness);
                        doc.ExportCaption(Personality);
                        doc.ExportCaption(EnglishProficiency);
                        doc.ExportCaption(PrincipalComment);
                        doc.ExportCaption(FinalInterviewComment);
                        doc.ExportCaption(InterviewedByPersonOneName);
                        doc.ExportCaption(InterviewedByPersonOneRank);
                        doc.ExportCaption(AssistantManagerPdeReviewedDate);
                        doc.ExportCaption(InterviewedByPersonTwoName);
                        doc.ExportCaption(InterviewedByPersonTwoRank);
                        doc.ExportCaption(InterviewedByPersonThreeName);
                        doc.ExportCaption(InterviewedByPersonThreeRank);
                        doc.ExportCaption(CrewingManagerApprovalDate);
                        doc.ExportCaption(Activity14Attachment);
                        doc.ExportCaption(Activity20Attachment);
                        doc.ExportCaption(Activity30Attachment);
                        doc.ExportCaption(Activity50Attachment);
                        doc.ExportCaption(Activity70Attachment);
                        doc.ExportCaption(FinalInterviewAttachment);
                        doc.ExportCaption(PrincipalCommentAttachment);
                        doc.ExportCaption(FormPrintoutAttachment);
                        doc.ExportCaption(AssistantManagerPdeReviewed);
                        doc.ExportCaption(CrewingManagerApproval);
                        doc.ExportCaption(InterviewDate);
                        doc.ExportCaption(InterviewAttachment);
                        doc.ExportCaption(ApprovedByUserID1);
                        doc.ExportCaption(ApprovedByUserID2);
                    } else {
                        doc.ExportCaption(MTCrewID);
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
                        doc.ExportCaption(JobKnowledge);
                        doc.ExportCaption(SafetyAwareness);
                        doc.ExportCaption(Personality);
                        doc.ExportCaption(EnglishProficiency);
                        doc.ExportCaption(PrincipalComment);
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(FinalInterviewComment);
                        doc.ExportCaption(InterviewedByPersonOneName);
                        doc.ExportCaption(InterviewedByPersonOneRank);
                        doc.ExportCaption(AssistantManagerPdeReviewedDate);
                        doc.ExportCaption(InterviewedByPersonTwoName);
                        doc.ExportCaption(InterviewedByPersonTwoRank);
                        doc.ExportCaption(InterviewedByPersonThreeName);
                        doc.ExportCaption(InterviewedByPersonThreeRank);
                        doc.ExportCaption(CrewingManagerApprovalDate);
                        doc.ExportCaption(Activity14Attachment);
                        doc.ExportCaption(Activity20Attachment);
                        doc.ExportCaption(Activity30Attachment);
                        doc.ExportCaption(Activity50Attachment);
                        doc.ExportCaption(Activity70Attachment);
                        doc.ExportCaption(FinalInterviewAttachment);
                        doc.ExportCaption(PrincipalCommentAttachment);
                        doc.ExportCaption(FormPrintoutAttachment);
                        doc.ExportCaption(AssistantManagerPdeReviewed);
                        doc.ExportCaption(CrewingManagerApproval);
                        doc.ExportCaption(InterviewDate);
                        doc.ExportCaption(InterviewAttachment);
                        doc.ExportCaption(ApprovedByUserID1);
                        doc.ExportCaption(ApprovedByUserID2);
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
                            await doc.ExportField(MTCrewID);
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
                            await doc.ExportField(JobKnowledge);
                            await doc.ExportField(SafetyAwareness);
                            await doc.ExportField(Personality);
                            await doc.ExportField(EnglishProficiency);
                            await doc.ExportField(PrincipalComment);
                            await doc.ExportField(FinalInterviewComment);
                            await doc.ExportField(InterviewedByPersonOneName);
                            await doc.ExportField(InterviewedByPersonOneRank);
                            await doc.ExportField(AssistantManagerPdeReviewedDate);
                            await doc.ExportField(InterviewedByPersonTwoName);
                            await doc.ExportField(InterviewedByPersonTwoRank);
                            await doc.ExportField(InterviewedByPersonThreeName);
                            await doc.ExportField(InterviewedByPersonThreeRank);
                            await doc.ExportField(CrewingManagerApprovalDate);
                            await doc.ExportField(Activity14Attachment);
                            await doc.ExportField(Activity20Attachment);
                            await doc.ExportField(Activity30Attachment);
                            await doc.ExportField(Activity50Attachment);
                            await doc.ExportField(Activity70Attachment);
                            await doc.ExportField(FinalInterviewAttachment);
                            await doc.ExportField(PrincipalCommentAttachment);
                            await doc.ExportField(FormPrintoutAttachment);
                            await doc.ExportField(AssistantManagerPdeReviewed);
                            await doc.ExportField(CrewingManagerApproval);
                            await doc.ExportField(InterviewDate);
                            await doc.ExportField(InterviewAttachment);
                            await doc.ExportField(ApprovedByUserID1);
                            await doc.ExportField(ApprovedByUserID2);
                        } else {
                            await doc.ExportField(MTCrewID);
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
                            await doc.ExportField(JobKnowledge);
                            await doc.ExportField(SafetyAwareness);
                            await doc.ExportField(Personality);
                            await doc.ExportField(EnglishProficiency);
                            await doc.ExportField(PrincipalComment);
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(FinalInterviewComment);
                            await doc.ExportField(InterviewedByPersonOneName);
                            await doc.ExportField(InterviewedByPersonOneRank);
                            await doc.ExportField(AssistantManagerPdeReviewedDate);
                            await doc.ExportField(InterviewedByPersonTwoName);
                            await doc.ExportField(InterviewedByPersonTwoRank);
                            await doc.ExportField(InterviewedByPersonThreeName);
                            await doc.ExportField(InterviewedByPersonThreeRank);
                            await doc.ExportField(CrewingManagerApprovalDate);
                            await doc.ExportField(Activity14Attachment);
                            await doc.ExportField(Activity20Attachment);
                            await doc.ExportField(Activity30Attachment);
                            await doc.ExportField(Activity50Attachment);
                            await doc.ExportField(Activity70Attachment);
                            await doc.ExportField(FinalInterviewAttachment);
                            await doc.ExportField(PrincipalCommentAttachment);
                            await doc.ExportField(FormPrintoutAttachment);
                            await doc.ExportField(AssistantManagerPdeReviewed);
                            await doc.ExportField(CrewingManagerApproval);
                            await doc.ExportField(InterviewDate);
                            await doc.ExportField(InterviewAttachment);
                            await doc.ExportField(ApprovedByUserID1);
                            await doc.ExportField(ApprovedByUserID2);
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
            if (SameText(fldparm, "Activity14Attachment")) {
                fldName = "Activity14Attachment";
                fileNameFld = "Activity14Attachment";
            } else if (SameText(fldparm, "Activity20Attachment")) {
                fldName = "Activity20Attachment";
                fileNameFld = "Activity20Attachment";
            } else if (SameText(fldparm, "Activity30Attachment")) {
                fldName = "Activity30Attachment";
                fileNameFld = "Activity30Attachment";
            } else if (SameText(fldparm, "Activity50Attachment")) {
                fldName = "Activity50Attachment";
                fileNameFld = "Activity50Attachment";
            } else if (SameText(fldparm, "Activity70Attachment")) {
                fldName = "Activity70Attachment";
                fileNameFld = "Activity70Attachment";
            } else if (SameText(fldparm, "FinalInterviewAttachment")) {
                fldName = "FinalInterviewAttachment";
                fileNameFld = "FinalInterviewAttachment";
            } else if (SameText(fldparm, "PrincipalCommentAttachment")) {
                fldName = "PrincipalCommentAttachment";
                fileNameFld = "PrincipalCommentAttachment";
            } else if (SameText(fldparm, "FormPrintoutAttachment")) {
                fldName = "FormPrintoutAttachment";
                fileNameFld = "FormPrintoutAttachment";
            } else if (SameText(fldparm, "InterviewAttachment")) {
                fldName = "InterviewAttachment";
                fileNameFld = "InterviewAttachment";
            } else {
                return JsonBoolResult.FalseResult; // Incorrect field
            }

            // Set up key values
            if (keys.Length == 1) {
                ID.CurrentValue = keys[0];
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
            int mtCrewID = Convert.ToInt32(row["MTCrewID"]);
            object individualCodeNumberObject = ExecuteScalar("SELECT IndividualCodeNumber FROM MTCrew WHERE ID = " + mtCrewID + ";");
            if ((object) individualCodeNumberObject != null)
            {
                string individualCodeNumber = individualCodeNumberObject.ToString();
                Activity14Attachment.UploadPath = "uploads/" + individualCodeNumber;
                Activity20Attachment.UploadPath = "uploads/" + individualCodeNumber;
                Activity30Attachment.UploadPath = "uploads/" + individualCodeNumber;
                Activity50Attachment.UploadPath = "uploads/" + individualCodeNumber;
                Activity70Attachment.UploadPath = "uploads/" + individualCodeNumber;
                InterviewAttachment.UploadPath = "uploads/" + individualCodeNumber;
                FinalInterviewAttachment.UploadPath = "uploads/" + individualCodeNumber;
                PrincipalCommentAttachment.UploadPath = "uploads/" + individualCodeNumber;
                FormPrintoutAttachment.UploadPath = "uploads/" + individualCodeNumber;
            }
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
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) 
        {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
            rsnew["LastUpdatedByUserID"] = CurrentUserID();
            rsnew["LastUpdatedDateTime"] = DateTimeOffset.Now;
            dynamic crewQueryResult = QueryBuilder("MTCrew").Where("ID", rsnew["MTCrewID"].ToString()).Select("IndividualCodeNumber").FirstOrDefault();
            if ((object) crewQueryResult != null)
            {
                string crewIndividualCodeNumber = crewQueryResult.IndividualCodeNumber;
                string fileName, fileExtension;
                if (rsnew.ContainsKey("Activity14Attachment"))
                {
                    Activity14Attachment.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    fileName = rsnew["Activity14Attachment"].ToString();
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    rsnew["Activity14Attachment"] = crewIndividualCodeNumber + "-cl-act14" + fileExtension;
                }
                if (rsnew.ContainsKey("Activity20Attachment"))
                {
                    Activity20Attachment.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    fileName = rsnew["Activity20Attachment"].ToString();
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    rsnew["Activity20Attachment"] = crewIndividualCodeNumber + "-cl-act20" + fileExtension;
                }
                if (rsnew.ContainsKey("Activity30Attachment"))
                {
                    Activity30Attachment.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    fileName = rsnew["Activity30Attachment"].ToString();
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    rsnew["Activity30Attachment"] = crewIndividualCodeNumber + "-cl-act30" + fileExtension;
                }
                if (rsnew.ContainsKey("Activity50Attachment"))
                {
                    Activity50Attachment.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    fileName = rsnew["Activity50Attachment"].ToString();
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    rsnew["Activity50Attachment"] = crewIndividualCodeNumber + "-cl-act50" + fileExtension;
                }
                if (rsnew.ContainsKey("Activity70Attachment"))
                {
                    Activity70Attachment.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    fileName = rsnew["Activity70Attachment"].ToString();
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    rsnew["Activity70Attachment"] = crewIndividualCodeNumber + "-cl-act70" + fileExtension;
                }
                if (rsnew.ContainsKey("InterviewAttachment"))
                {
                    InterviewAttachment.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    fileName = rsnew["InterviewAttachment"].ToString();
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    rsnew["InterviewAttachment"] = crewIndividualCodeNumber + "-cl-int" + fileExtension;
                }
                if (rsnew.ContainsKey("FinalInterviewAttachment"))
                {
                    FinalInterviewAttachment.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    fileName = rsnew["FinalInterviewAttachment"].ToString();
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    rsnew["FinalInterviewAttachment"] = crewIndividualCodeNumber + "-cl-fin-int" + fileExtension;
                }
                if (rsnew.ContainsKey("PrincipalCommentAttachment"))
                {
                    PrincipalCommentAttachment.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    fileName = rsnew["PrincipalCommentAttachment"].ToString();
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    rsnew["PrincipalCommentAttachment"] = crewIndividualCodeNumber + "-cl-prin-com" + fileExtension;
                }
                if (rsnew.ContainsKey("FormPrintoutAttachment"))
                {
                    FormPrintoutAttachment.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    fileName = rsnew["FormPrintoutAttachment"].ToString();
                    fileExtension = System.IO.Path.GetExtension(fileName);
                    rsnew["FormPrintoutAttachment"] = crewIndividualCodeNumber + "-cl-form-printout" + fileExtension;
                }
            }
            return true;
        }
        // Row Updated event
        public void RowUpdated(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            //Log("Row Updated");
            Session.SetInt("lastUpdatedChecklistID", ConvertToInt(rsold["ID"]));

            // gmandayu: untuk tracking process.
            var checklistItems = QueryBuilder("TRChecklist")
                .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                .Get();
            int affectedRows = 0;
            foreach (var item in checklistItems)
            {
                int flag;
                string flagDescription;
                if (item.Activity10)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 103 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 103 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity11)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 104 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 104 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity12)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 105 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else 
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 105 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity13)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 106 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else 
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 106 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity14)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 107 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else 
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 107 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity20)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 108 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 108 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity30)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 109 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else 
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 109 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity40)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 110 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 110 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity50)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 111 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 111 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity60)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 112 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 112 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.Activity70)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 113 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 113 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (item.AssistantManagerPdeReviewed && item.CrewingManagerApproval)
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 120 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 120 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (!string.IsNullOrEmpty(item.InterviewedByPersonOneName) &&
                    !string.IsNullOrEmpty(item.InterviewedByPersonTwoName) &&
                    !string.IsNullOrEmpty(item.InterviewedByPersonThreeName))
                {
                    flag = 1; flagDescription = "Selesai";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 119 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                else
                {
                    flag = 2; flagDescription = "Menunggu";
                    affectedRows = QueryBuilder("MTRecruitmentStatusTracking")
                        .Where("MTCrewID", rsnew["MTCrewID"].ToString())
                        .WhereIn("MTRecruitmentStatusID", new int[] { 119 })
                        .Update(new
                        {
                            Flag = flag,
                            FlagDescription = flagDescription,
                            LastUpdatedByUserID = CurrentUserID(),
                            LastUpdatedDateTime = DateTimeOffset.Now,
                        });
                }
                if (affectedRows == 0)
                {
                    throw new Exception((CurrentLanguage == "en-US") ? "Failed to Update Crew Tracking Status" : "Gagal Mengubah Data Pelacakan Status Kru");
                }
            }
            //gmandayu: code ends here.
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
