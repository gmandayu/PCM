namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewGeneralDataForAdminViewMode
    /// </summary>
    [MaybeNull]
    public static CrewGeneralDataForAdminViewMode crewGeneralDataForAdminViewMode
    {
        get => HttpData.Resolve<CrewGeneralDataForAdminViewMode>("CrewGeneralDataForAdminViewMode");
        set => HttpData["CrewGeneralDataForAdminViewMode"] = value;
    }

    /// <summary>
    /// Table class for CrewGeneralDataForAdminViewMode
    /// </summary>
    public class CrewGeneralDataForAdminViewMode : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> ForeignVisaHasBeenDenied;

        public readonly DbField<SqlDbType> ForeignVisaDenied_CountryID;

        public readonly DbField<SqlDbType> ForeignVisaDeniedReason;

        public readonly DbField<SqlDbType> HasMaritimeAccidentOrCourtOfEnquiry;

        public readonly DbField<SqlDbType> HasMaritimeAccidentOrCourtOfEnquiryDetails;

        public readonly DbField<SqlDbType> Reference1CompanyName;

        public readonly DbField<SqlDbType> Reference1ContactPersonName;

        public readonly DbField<SqlDbType> Reference1CompanyAddress;

        public readonly DbField<SqlDbType> Reference1CompanyCountryID;

        public readonly DbField<SqlDbType> Reference1CompanyTelephone;

        public readonly DbField<SqlDbType> Reference2CompanyName;

        public readonly DbField<SqlDbType> Reference2ContactPersonName;

        public readonly DbField<SqlDbType> Reference2CompanyAddress;

        public readonly DbField<SqlDbType> Reference2CompanyCountryID;

        public readonly DbField<SqlDbType> Reference2CompanyTelephone;

        public readonly DbField<SqlDbType> EmployeeStatus;

        public readonly DbField<SqlDbType> FormSubmittedDateTime;

        public readonly DbField<SqlDbType> LastUpdatedByUserID;

        public readonly DbField<SqlDbType> LastUpdatedDateTime;

        public readonly DbField<SqlDbType> MTUserID;

        public readonly DbField<SqlDbType> Reference1CompanyTelephoneCode_CountryID;

        public readonly DbField<SqlDbType> Reference2CompanyTelephoneCode_CountryID;

        // Constructor
        public CrewGeneralDataForAdminViewMode()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "CrewGeneralDataForAdminViewMode";
            Name = "CrewGeneralDataForAdminViewMode";
            Type = "CUSTOMVIEW";
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

            // ID
            ID = new (this, "x_ID", 3, SqlDbType.Int) {
                Name = "ID",
                Expression = "dbo.MTCrew.ID",
                BasicSearchExpression = "CAST(dbo.MTCrew.ID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.ID",
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
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ID", ID);

            // ForeignVisaHasBeenDenied
            ForeignVisaHasBeenDenied = new (this, "x_ForeignVisaHasBeenDenied", 11, SqlDbType.Bit) {
                Name = "ForeignVisaHasBeenDenied",
                Expression = "dbo.MTCrew.ForeignVisaHasBeenDenied",
                BasicSearchExpression = "dbo.MTCrew.ForeignVisaHasBeenDenied",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.ForeignVisaHasBeenDenied",
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
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "ForeignVisaHasBeenDenied", "CustomMsg"),
                IsUpload = false
            };
            ForeignVisaHasBeenDenied.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ForeignVisaHasBeenDenied", "CrewGeneralDataForAdminViewMode", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("ForeignVisaHasBeenDenied", "CrewGeneralDataForAdminViewMode", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("ForeignVisaHasBeenDenied", "CrewGeneralDataForAdminViewMode", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("ForeignVisaHasBeenDenied", ForeignVisaHasBeenDenied);

            // ForeignVisaDenied_CountryID
            ForeignVisaDenied_CountryID = new (this, "x_ForeignVisaDenied_CountryID", 3, SqlDbType.Int) {
                Name = "ForeignVisaDenied_CountryID",
                Expression = "dbo.MTCrew.ForeignVisaDenied_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.ForeignVisaDenied_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.ForeignVisaDenied_CountryID",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "ForeignVisaDenied_CountryID", "CustomMsg"),
                IsUpload = false
            };
            ForeignVisaDenied_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ForeignVisaDenied_CountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("ForeignVisaDenied_CountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("ForeignVisaDenied_CountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("ForeignVisaDenied_CountryID", ForeignVisaDenied_CountryID);

            // ForeignVisaDeniedReason
            ForeignVisaDeniedReason = new (this, "x_ForeignVisaDeniedReason", 202, SqlDbType.NVarChar) {
                Name = "ForeignVisaDeniedReason",
                Expression = "dbo.MTCrew.ForeignVisaDeniedReason",
                BasicSearchExpression = "dbo.MTCrew.ForeignVisaDeniedReason",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.ForeignVisaDeniedReason",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "ForeignVisaDeniedReason", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ForeignVisaDeniedReason", ForeignVisaDeniedReason);

            // HasMaritimeAccidentOrCourtOfEnquiry
            HasMaritimeAccidentOrCourtOfEnquiry = new (this, "x_HasMaritimeAccidentOrCourtOfEnquiry", 11, SqlDbType.Bit) {
                Name = "HasMaritimeAccidentOrCourtOfEnquiry",
                Expression = "dbo.MTCrew.HasMaritimeAccidentOrCourtOfEnquiry",
                BasicSearchExpression = "dbo.MTCrew.HasMaritimeAccidentOrCourtOfEnquiry",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.HasMaritimeAccidentOrCourtOfEnquiry",
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
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "HasMaritimeAccidentOrCourtOfEnquiry", "CustomMsg"),
                IsUpload = false
            };
            HasMaritimeAccidentOrCourtOfEnquiry.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("HasMaritimeAccidentOrCourtOfEnquiry", "CrewGeneralDataForAdminViewMode", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("HasMaritimeAccidentOrCourtOfEnquiry", "CrewGeneralDataForAdminViewMode", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("HasMaritimeAccidentOrCourtOfEnquiry", "CrewGeneralDataForAdminViewMode", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("HasMaritimeAccidentOrCourtOfEnquiry", HasMaritimeAccidentOrCourtOfEnquiry);

            // HasMaritimeAccidentOrCourtOfEnquiryDetails
            HasMaritimeAccidentOrCourtOfEnquiryDetails = new (this, "x_HasMaritimeAccidentOrCourtOfEnquiryDetails", 202, SqlDbType.NVarChar) {
                Name = "HasMaritimeAccidentOrCourtOfEnquiryDetails",
                Expression = "dbo.MTCrew.HasMaritimeAccidentOrCourtOfEnquiryDetails",
                BasicSearchExpression = "dbo.MTCrew.HasMaritimeAccidentOrCourtOfEnquiryDetails",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.HasMaritimeAccidentOrCourtOfEnquiryDetails",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "HasMaritimeAccidentOrCourtOfEnquiryDetails", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("HasMaritimeAccidentOrCourtOfEnquiryDetails", HasMaritimeAccidentOrCourtOfEnquiryDetails);

            // Reference1CompanyName
            Reference1CompanyName = new (this, "x_Reference1CompanyName", 202, SqlDbType.NVarChar) {
                Name = "Reference1CompanyName",
                Expression = "dbo.MTCrew.Reference1CompanyName",
                BasicSearchExpression = "dbo.MTCrew.Reference1CompanyName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference1CompanyName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference1CompanyName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference1CompanyName", Reference1CompanyName);

            // Reference1ContactPersonName
            Reference1ContactPersonName = new (this, "x_Reference1ContactPersonName", 202, SqlDbType.NVarChar) {
                Name = "Reference1ContactPersonName",
                Expression = "dbo.MTCrew.Reference1ContactPersonName",
                BasicSearchExpression = "dbo.MTCrew.Reference1ContactPersonName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference1ContactPersonName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference1ContactPersonName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference1ContactPersonName", Reference1ContactPersonName);

            // Reference1CompanyAddress
            Reference1CompanyAddress = new (this, "x_Reference1CompanyAddress", 202, SqlDbType.NVarChar) {
                Name = "Reference1CompanyAddress",
                Expression = "dbo.MTCrew.Reference1CompanyAddress",
                BasicSearchExpression = "dbo.MTCrew.Reference1CompanyAddress",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference1CompanyAddress",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference1CompanyAddress", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference1CompanyAddress", Reference1CompanyAddress);

            // Reference1CompanyCountryID
            Reference1CompanyCountryID = new (this, "x_Reference1CompanyCountryID", 3, SqlDbType.Int) {
                Name = "Reference1CompanyCountryID",
                Expression = "dbo.MTCrew.Reference1CompanyCountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.Reference1CompanyCountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference1CompanyCountryID",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference1CompanyCountryID", "CustomMsg"),
                IsUpload = false
            };
            Reference1CompanyCountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Reference1CompanyCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("Reference1CompanyCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("Reference1CompanyCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("Reference1CompanyCountryID", Reference1CompanyCountryID);

            // Reference1CompanyTelephone
            Reference1CompanyTelephone = new (this, "x_Reference1CompanyTelephone", 202, SqlDbType.NVarChar) {
                Name = "Reference1CompanyTelephone",
                Expression = "dbo.MTCrew.Reference1CompanyTelephone",
                BasicSearchExpression = "dbo.MTCrew.Reference1CompanyTelephone",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference1CompanyTelephone",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference1CompanyTelephone", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference1CompanyTelephone", Reference1CompanyTelephone);

            // Reference2CompanyName
            Reference2CompanyName = new (this, "x_Reference2CompanyName", 202, SqlDbType.NVarChar) {
                Name = "Reference2CompanyName",
                Expression = "dbo.MTCrew.Reference2CompanyName",
                BasicSearchExpression = "dbo.MTCrew.Reference2CompanyName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference2CompanyName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference2CompanyName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference2CompanyName", Reference2CompanyName);

            // Reference2ContactPersonName
            Reference2ContactPersonName = new (this, "x_Reference2ContactPersonName", 202, SqlDbType.NVarChar) {
                Name = "Reference2ContactPersonName",
                Expression = "dbo.MTCrew.Reference2ContactPersonName",
                BasicSearchExpression = "dbo.MTCrew.Reference2ContactPersonName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference2ContactPersonName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference2ContactPersonName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference2ContactPersonName", Reference2ContactPersonName);

            // Reference2CompanyAddress
            Reference2CompanyAddress = new (this, "x_Reference2CompanyAddress", 202, SqlDbType.NVarChar) {
                Name = "Reference2CompanyAddress",
                Expression = "dbo.MTCrew.Reference2CompanyAddress",
                BasicSearchExpression = "dbo.MTCrew.Reference2CompanyAddress",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference2CompanyAddress",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference2CompanyAddress", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference2CompanyAddress", Reference2CompanyAddress);

            // Reference2CompanyCountryID
            Reference2CompanyCountryID = new (this, "x_Reference2CompanyCountryID", 3, SqlDbType.Int) {
                Name = "Reference2CompanyCountryID",
                Expression = "dbo.MTCrew.Reference2CompanyCountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.Reference2CompanyCountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference2CompanyCountryID",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference2CompanyCountryID", "CustomMsg"),
                IsUpload = false
            };
            Reference2CompanyCountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Reference2CompanyCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("Reference2CompanyCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("Reference2CompanyCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("Reference2CompanyCountryID", Reference2CompanyCountryID);

            // Reference2CompanyTelephone
            Reference2CompanyTelephone = new (this, "x_Reference2CompanyTelephone", 202, SqlDbType.NVarChar) {
                Name = "Reference2CompanyTelephone",
                Expression = "dbo.MTCrew.Reference2CompanyTelephone",
                BasicSearchExpression = "dbo.MTCrew.Reference2CompanyTelephone",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference2CompanyTelephone",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference2CompanyTelephone", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference2CompanyTelephone", Reference2CompanyTelephone);

            // EmployeeStatus
            EmployeeStatus = new (this, "x_EmployeeStatus", 202, SqlDbType.NVarChar) {
                Name = "EmployeeStatus",
                Expression = "dbo.MTCrew.EmployeeStatus",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrew.EmployeeStatus",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.EmployeeStatus",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "EmployeeStatus", "CustomMsg"),
                IsUpload = false
            };
            EmployeeStatus.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("EmployeeStatus", "CrewGeneralDataForAdminViewMode", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("EmployeeStatus", "CrewGeneralDataForAdminViewMode", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("EmployeeStatus", "CrewGeneralDataForAdminViewMode", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("EmployeeStatus", EmployeeStatus);

            // FormSubmittedDateTime
            FormSubmittedDateTime = new (this, "x_FormSubmittedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "FormSubmittedDateTime",
                Expression = "dbo.MTCrew.FormSubmittedDateTime",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrew.FormSubmittedDateTime", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.MTCrew.FormSubmittedDateTime",
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
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "FormSubmittedDateTime", "CustomMsg"),
                IsUpload = false
            };
            FormSubmittedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FormSubmittedDateTime", "CrewGeneralDataForAdminViewMode", true, "FormSubmittedDateTime", new List<string> {"FormSubmittedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("FormSubmittedDateTime", "CrewGeneralDataForAdminViewMode", true, "FormSubmittedDateTime", new List<string> {"FormSubmittedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("FormSubmittedDateTime", "CrewGeneralDataForAdminViewMode", true, "FormSubmittedDateTime", new List<string> {"FormSubmittedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("FormSubmittedDateTime", FormSubmittedDateTime);

            // LastUpdatedByUserID
            LastUpdatedByUserID = new (this, "x_LastUpdatedByUserID", 3, SqlDbType.Int) {
                Name = "LastUpdatedByUserID",
                Expression = "dbo.MTCrew.LastUpdatedByUserID",
                BasicSearchExpression = "CAST(dbo.MTCrew.LastUpdatedByUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.LastUpdatedByUserID",
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
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "LastUpdatedByUserID", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedByUserID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedByUserID", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]"),
                "id-ID" => new Lookup<DbField>("LastUpdatedByUserID", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]"),
                _ => new Lookup<DbField>("LastUpdatedByUserID", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]")
            };
            Fields.Add("LastUpdatedByUserID", LastUpdatedByUserID);

            // LastUpdatedDateTime
            LastUpdatedDateTime = new (this, "x_LastUpdatedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "LastUpdatedDateTime",
                Expression = "dbo.MTCrew.LastUpdatedDateTime",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrew.LastUpdatedDateTime", 1, "DB"),
                DateTimeFormat = 1,
                VirtualExpression = "dbo.MTCrew.LastUpdatedDateTime",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", DateFormat(1)),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "LastUpdatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedDateTime", "CrewGeneralDataForAdminViewMode", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedDateTime", "CrewGeneralDataForAdminViewMode", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedDateTime", "CrewGeneralDataForAdminViewMode", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("LastUpdatedDateTime", LastUpdatedDateTime);

            // MTUserID
            MTUserID = new (this, "x_MTUserID", 3, SqlDbType.Int) {
                Name = "MTUserID",
                Expression = "dbo.MTCrew.MTUserID",
                BasicSearchExpression = "CAST(dbo.MTCrew.MTUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.MTUserID",
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
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "MTUserID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MTUserID", MTUserID);

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID = new (this, "x_Reference1CompanyTelephoneCode_CountryID", 3, SqlDbType.Int) {
                Name = "Reference1CompanyTelephoneCode_CountryID",
                Expression = "dbo.MTCrew.Reference1CompanyTelephoneCode_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.Reference1CompanyTelephoneCode_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference1CompanyTelephoneCode_CountryID",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference1CompanyTelephoneCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            Reference1CompanyTelephoneCode_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Reference1CompanyTelephoneCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, Reference1CompanyTelephoneCode_CountryID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("Reference1CompanyTelephoneCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, Reference1CompanyTelephoneCode_CountryID) + "',[Name])"),
                _ => new Lookup<DbField>("Reference1CompanyTelephoneCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, Reference1CompanyTelephoneCode_CountryID) + "',[Name])")
            };
            Fields.Add("Reference1CompanyTelephoneCode_CountryID", Reference1CompanyTelephoneCode_CountryID);

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID = new (this, "x_Reference2CompanyTelephoneCode_CountryID", 3, SqlDbType.Int) {
                Name = "Reference2CompanyTelephoneCode_CountryID",
                Expression = "dbo.MTCrew.Reference2CompanyTelephoneCode_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.Reference2CompanyTelephoneCode_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reference2CompanyTelephoneCode_CountryID",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewGeneralDataForAdminViewMode", "Reference2CompanyTelephoneCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            Reference2CompanyTelephoneCode_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Reference2CompanyTelephoneCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, Reference2CompanyTelephoneCode_CountryID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("Reference2CompanyTelephoneCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, Reference2CompanyTelephoneCode_CountryID) + "',[Name])"),
                _ => new Lookup<DbField>("Reference2CompanyTelephoneCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, Reference2CompanyTelephoneCode_CountryID) + "',[Name])")
            };
            Fields.Add("Reference2CompanyTelephoneCode_CountryID", Reference2CompanyTelephoneCode_CountryID);

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
            get => _sqlFrom ?? "dbo.MTCrew";
            set => _sqlFrom = value;
        }

        // SELECT
        private string? _sqlSelect = null;

        public string SqlSelect { // Select
            get => _sqlSelect ?? "SELECT dbo.MTCrew.ID, dbo.MTCrew.ForeignVisaHasBeenDenied, dbo.MTCrew.ForeignVisaDenied_CountryID, dbo.MTCrew.ForeignVisaDeniedReason, dbo.MTCrew.HasMaritimeAccidentOrCourtOfEnquiry, dbo.MTCrew.HasMaritimeAccidentOrCourtOfEnquiryDetails, dbo.MTCrew.Reference1CompanyName, dbo.MTCrew.Reference1ContactPersonName, dbo.MTCrew.Reference1CompanyAddress, dbo.MTCrew.Reference1CompanyCountryID, dbo.MTCrew.Reference1CompanyTelephone, dbo.MTCrew.Reference2CompanyName, dbo.MTCrew.Reference2ContactPersonName, dbo.MTCrew.Reference2CompanyAddress, dbo.MTCrew.Reference2CompanyCountryID, dbo.MTCrew.Reference2CompanyTelephone, dbo.MTCrew.EmployeeStatus, dbo.MTCrew.FormSubmittedDateTime, dbo.MTCrew.LastUpdatedByUserID, dbo.MTCrew.LastUpdatedDateTime, dbo.MTCrew.MTUserID, dbo.MTCrew.Reference1CompanyTelephoneCode_CountryID, dbo.MTCrew.Reference2CompanyTelephoneCode_CountryID FROM " + SqlFrom;
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
            if (!Empty(Security.CurrentUserID) && !Security.IsAdmin) { // Non system admin
                filter = AddUserIDFilter(filter, id);
            }
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
                ForeignVisaHasBeenDenied.DbValue = (ConvertToBool(row["ForeignVisaHasBeenDenied"]) ? "1" : "0"); // Set DB value only
                ForeignVisaDenied_CountryID.DbValue = row["ForeignVisaDenied_CountryID"]; // Set DB value only
                ForeignVisaDeniedReason.DbValue = row["ForeignVisaDeniedReason"]; // Set DB value only
                HasMaritimeAccidentOrCourtOfEnquiry.DbValue = (ConvertToBool(row["HasMaritimeAccidentOrCourtOfEnquiry"]) ? "1" : "0"); // Set DB value only
                HasMaritimeAccidentOrCourtOfEnquiryDetails.DbValue = row["HasMaritimeAccidentOrCourtOfEnquiryDetails"]; // Set DB value only
                Reference1CompanyName.DbValue = row["Reference1CompanyName"]; // Set DB value only
                Reference1ContactPersonName.DbValue = row["Reference1ContactPersonName"]; // Set DB value only
                Reference1CompanyAddress.DbValue = row["Reference1CompanyAddress"]; // Set DB value only
                Reference1CompanyCountryID.DbValue = row["Reference1CompanyCountryID"]; // Set DB value only
                Reference1CompanyTelephone.DbValue = row["Reference1CompanyTelephone"]; // Set DB value only
                Reference2CompanyName.DbValue = row["Reference2CompanyName"]; // Set DB value only
                Reference2ContactPersonName.DbValue = row["Reference2ContactPersonName"]; // Set DB value only
                Reference2CompanyAddress.DbValue = row["Reference2CompanyAddress"]; // Set DB value only
                Reference2CompanyCountryID.DbValue = row["Reference2CompanyCountryID"]; // Set DB value only
                Reference2CompanyTelephone.DbValue = row["Reference2CompanyTelephone"]; // Set DB value only
                EmployeeStatus.DbValue = row["EmployeeStatus"]; // Set DB value only
                FormSubmittedDateTime.DbValue = row["FormSubmittedDateTime"]; // Set DB value only
                LastUpdatedByUserID.DbValue = row["LastUpdatedByUserID"]; // Set DB value only
                LastUpdatedDateTime.DbValue = row["LastUpdatedDateTime"]; // Set DB value only
                MTUserID.DbValue = row["MTUserID"]; // Set DB value only
                Reference1CompanyTelephoneCode_CountryID.DbValue = row["Reference1CompanyTelephoneCode_CountryID"]; // Set DB value only
                Reference2CompanyTelephoneCode_CountryID.DbValue = row["Reference2CompanyTelephoneCode_CountryID"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "dbo.MTCrew.ID = @ID@";

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
                    return "CrewGeneralDataForAdminViewModeList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "CrewGeneralDataForAdminViewModeView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "CrewGeneralDataForAdminViewModeEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "CrewGeneralDataForAdminViewModeAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "CrewGeneralDataForAdminViewModeList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "CrewGeneralDataForAdminViewModeView",
                Config.ApiAddAction => "CrewGeneralDataForAdminViewModeAdd",
                Config.ApiEditAction => "CrewGeneralDataForAdminViewModeEdit",
                Config.ApiDeleteAction => "CrewGeneralDataForAdminViewModeDelete",
                Config.ApiListAction => "CrewGeneralDataForAdminViewModeList",
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
        public string ListUrl => "CrewGeneralDataForAdminViewModeList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("CrewGeneralDataForAdminViewModeView", parm);
            else
                url = KeyUrl("CrewGeneralDataForAdminViewModeView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "CrewGeneralDataForAdminViewModeAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "CrewGeneralDataForAdminViewModeAdd?" + parm;
            else
                url = "CrewGeneralDataForAdminViewModeAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("CrewGeneralDataForAdminViewModeEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewGeneralDataForAdminViewModeList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("CrewGeneralDataForAdminViewModeAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewGeneralDataForAdminViewModeList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("CrewGeneralDataForAdminViewModeDelete")); // DN

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
            ForeignVisaHasBeenDenied.SetDbValue(ConvertToBool(dr["ForeignVisaHasBeenDenied"]) ? "1" : "0");
            ForeignVisaDenied_CountryID.SetDbValue(dr["ForeignVisaDenied_CountryID"]);
            ForeignVisaDeniedReason.SetDbValue(dr["ForeignVisaDeniedReason"]);
            HasMaritimeAccidentOrCourtOfEnquiry.SetDbValue(ConvertToBool(dr["HasMaritimeAccidentOrCourtOfEnquiry"]) ? "1" : "0");
            HasMaritimeAccidentOrCourtOfEnquiryDetails.SetDbValue(dr["HasMaritimeAccidentOrCourtOfEnquiryDetails"]);
            Reference1CompanyName.SetDbValue(dr["Reference1CompanyName"]);
            Reference1ContactPersonName.SetDbValue(dr["Reference1ContactPersonName"]);
            Reference1CompanyAddress.SetDbValue(dr["Reference1CompanyAddress"]);
            Reference1CompanyCountryID.SetDbValue(dr["Reference1CompanyCountryID"]);
            Reference1CompanyTelephone.SetDbValue(dr["Reference1CompanyTelephone"]);
            Reference2CompanyName.SetDbValue(dr["Reference2CompanyName"]);
            Reference2ContactPersonName.SetDbValue(dr["Reference2ContactPersonName"]);
            Reference2CompanyAddress.SetDbValue(dr["Reference2CompanyAddress"]);
            Reference2CompanyCountryID.SetDbValue(dr["Reference2CompanyCountryID"]);
            Reference2CompanyTelephone.SetDbValue(dr["Reference2CompanyTelephone"]);
            EmployeeStatus.SetDbValue(dr["EmployeeStatus"]);
            FormSubmittedDateTime.SetDbValue(dr["FormSubmittedDateTime"]);
            LastUpdatedByUserID.SetDbValue(dr["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(dr["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(dr["MTUserID"]);
            Reference1CompanyTelephoneCode_CountryID.SetDbValue(dr["Reference1CompanyTelephoneCode_CountryID"]);
            Reference2CompanyTelephoneCode_CountryID.SetDbValue(dr["Reference2CompanyTelephoneCode_CountryID"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "CrewGeneralDataForAdminViewModeList";
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

            // LastUpdatedByUserID
            LastUpdatedByUserID.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedDateTime
            LastUpdatedDateTime.CellCssStyle = "white-space: nowrap;";

            // MTUserID
            MTUserID.CellCssStyle = "white-space: nowrap;";

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // ID
            ID.ViewValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

            // ForeignVisaHasBeenDenied
            if (ConvertToBool(ForeignVisaHasBeenDenied.CurrentValue)) {
                ForeignVisaHasBeenDenied.ViewValue = ForeignVisaHasBeenDenied.TagCaption(2) != "" ? ForeignVisaHasBeenDenied.TagCaption(2) : "Yes";
            } else {
                ForeignVisaHasBeenDenied.ViewValue = ForeignVisaHasBeenDenied.TagCaption(1) != "" ? ForeignVisaHasBeenDenied.TagCaption(1) : "No";
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
                HasMaritimeAccidentOrCourtOfEnquiry.ViewValue = HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(2) != "" ? HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(2) : "Yes";
            } else {
                HasMaritimeAccidentOrCourtOfEnquiry.ViewValue = HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(1) != "" ? HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(1) : "No";
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

            // LastUpdatedByUserID
            LastUpdatedByUserID.ViewValue = LastUpdatedByUserID.CurrentValue;
            LastUpdatedByUserID.ViewValue = FormatNumber(LastUpdatedByUserID.ViewValue, LastUpdatedByUserID.FormatPattern);
            LastUpdatedByUserID.ViewCustomAttributes = "";

            // LastUpdatedDateTime
            LastUpdatedDateTime.ViewValue = LastUpdatedDateTime.CurrentValue;
            LastUpdatedDateTime.ViewValue = FormatDateTime(LastUpdatedDateTime.ViewValue, LastUpdatedDateTime.FormatPattern);
            LastUpdatedDateTime.ViewCustomAttributes = "";

            // MTUserID
            MTUserID.ViewValue = MTUserID.CurrentValue;
            MTUserID.ViewValue = FormatNumber(MTUserID.ViewValue, MTUserID.FormatPattern);
            MTUserID.ViewCustomAttributes = "";

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

            // ID
            ID.HrefValue = "";
            ID.TooltipValue = "";

            // ForeignVisaHasBeenDenied
            ForeignVisaHasBeenDenied.HrefValue = "";
            ForeignVisaHasBeenDenied.TooltipValue = "";

            // ForeignVisaDenied_CountryID
            ForeignVisaDenied_CountryID.HrefValue = "";
            ForeignVisaDenied_CountryID.TooltipValue = "";

            // ForeignVisaDeniedReason
            ForeignVisaDeniedReason.HrefValue = "";
            ForeignVisaDeniedReason.TooltipValue = "";

            // HasMaritimeAccidentOrCourtOfEnquiry
            HasMaritimeAccidentOrCourtOfEnquiry.HrefValue = "";
            HasMaritimeAccidentOrCourtOfEnquiry.TooltipValue = "";

            // HasMaritimeAccidentOrCourtOfEnquiryDetails
            HasMaritimeAccidentOrCourtOfEnquiryDetails.HrefValue = "";
            HasMaritimeAccidentOrCourtOfEnquiryDetails.TooltipValue = "";

            // Reference1CompanyName
            Reference1CompanyName.HrefValue = "";
            Reference1CompanyName.TooltipValue = "";

            // Reference1ContactPersonName
            Reference1ContactPersonName.HrefValue = "";
            Reference1ContactPersonName.TooltipValue = "";

            // Reference1CompanyAddress
            Reference1CompanyAddress.HrefValue = "";
            Reference1CompanyAddress.TooltipValue = "";

            // Reference1CompanyCountryID
            Reference1CompanyCountryID.HrefValue = "";
            Reference1CompanyCountryID.TooltipValue = "";

            // Reference1CompanyTelephone
            Reference1CompanyTelephone.HrefValue = "";
            Reference1CompanyTelephone.TooltipValue = "";

            // Reference2CompanyName
            Reference2CompanyName.HrefValue = "";
            Reference2CompanyName.TooltipValue = "";

            // Reference2ContactPersonName
            Reference2ContactPersonName.HrefValue = "";
            Reference2ContactPersonName.TooltipValue = "";

            // Reference2CompanyAddress
            Reference2CompanyAddress.HrefValue = "";
            Reference2CompanyAddress.TooltipValue = "";

            // Reference2CompanyCountryID
            Reference2CompanyCountryID.HrefValue = "";
            Reference2CompanyCountryID.TooltipValue = "";

            // Reference2CompanyTelephone
            Reference2CompanyTelephone.HrefValue = "";
            Reference2CompanyTelephone.TooltipValue = "";

            // EmployeeStatus
            EmployeeStatus.HrefValue = "";
            EmployeeStatus.TooltipValue = "";

            // FormSubmittedDateTime
            FormSubmittedDateTime.HrefValue = "";
            FormSubmittedDateTime.TooltipValue = "";

            // LastUpdatedByUserID
            LastUpdatedByUserID.HrefValue = "";
            LastUpdatedByUserID.TooltipValue = "";

            // LastUpdatedDateTime
            LastUpdatedDateTime.HrefValue = "";
            LastUpdatedDateTime.TooltipValue = "";

            // MTUserID
            MTUserID.HrefValue = "";
            MTUserID.TooltipValue = "";

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.HrefValue = "";
            Reference1CompanyTelephoneCode_CountryID.TooltipValue = "";

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.HrefValue = "";
            Reference2CompanyTelephoneCode_CountryID.TooltipValue = "";

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

            // ForeignVisaHasBeenDenied
            ForeignVisaHasBeenDenied.EditValue = ForeignVisaHasBeenDenied.Options(false);
            ForeignVisaHasBeenDenied.PlaceHolder = RemoveHtml(ForeignVisaHasBeenDenied.Caption);

            // ForeignVisaDenied_CountryID
            ForeignVisaDenied_CountryID.SetupEditAttributes();
            ForeignVisaDenied_CountryID.PlaceHolder = RemoveHtml(ForeignVisaDenied_CountryID.Caption);
            if (!Empty(ForeignVisaDenied_CountryID.EditValue) && IsNumeric(ForeignVisaDenied_CountryID.EditValue))
                ForeignVisaDenied_CountryID.EditValue = FormatNumber(ForeignVisaDenied_CountryID.EditValue, null);

            // ForeignVisaDeniedReason
            ForeignVisaDeniedReason.SetupEditAttributes();
            ForeignVisaDeniedReason.EditValue = ForeignVisaDeniedReason.CurrentValue; // DN
            ForeignVisaDeniedReason.PlaceHolder = RemoveHtml(ForeignVisaDeniedReason.Caption);

            // HasMaritimeAccidentOrCourtOfEnquiry
            HasMaritimeAccidentOrCourtOfEnquiry.EditValue = HasMaritimeAccidentOrCourtOfEnquiry.Options(false);
            HasMaritimeAccidentOrCourtOfEnquiry.PlaceHolder = RemoveHtml(HasMaritimeAccidentOrCourtOfEnquiry.Caption);

            // HasMaritimeAccidentOrCourtOfEnquiryDetails
            HasMaritimeAccidentOrCourtOfEnquiryDetails.SetupEditAttributes();
            HasMaritimeAccidentOrCourtOfEnquiryDetails.EditValue = HasMaritimeAccidentOrCourtOfEnquiryDetails.CurrentValue; // DN
            HasMaritimeAccidentOrCourtOfEnquiryDetails.PlaceHolder = RemoveHtml(HasMaritimeAccidentOrCourtOfEnquiryDetails.Caption);

            // Reference1CompanyName
            Reference1CompanyName.SetupEditAttributes();
            if (!Reference1CompanyName.Raw)
                Reference1CompanyName.CurrentValue = HtmlDecode(Reference1CompanyName.CurrentValue);
            Reference1CompanyName.EditValue = HtmlEncode(Reference1CompanyName.CurrentValue);
            Reference1CompanyName.PlaceHolder = RemoveHtml(Reference1CompanyName.Caption);

            // Reference1ContactPersonName
            Reference1ContactPersonName.SetupEditAttributes();
            if (!Reference1ContactPersonName.Raw)
                Reference1ContactPersonName.CurrentValue = HtmlDecode(Reference1ContactPersonName.CurrentValue);
            Reference1ContactPersonName.EditValue = HtmlEncode(Reference1ContactPersonName.CurrentValue);
            Reference1ContactPersonName.PlaceHolder = RemoveHtml(Reference1ContactPersonName.Caption);

            // Reference1CompanyAddress
            Reference1CompanyAddress.SetupEditAttributes();
            Reference1CompanyAddress.EditValue = Reference1CompanyAddress.CurrentValue; // DN
            Reference1CompanyAddress.PlaceHolder = RemoveHtml(Reference1CompanyAddress.Caption);

            // Reference1CompanyCountryID
            Reference1CompanyCountryID.SetupEditAttributes();
            Reference1CompanyCountryID.PlaceHolder = RemoveHtml(Reference1CompanyCountryID.Caption);
            if (!Empty(Reference1CompanyCountryID.EditValue) && IsNumeric(Reference1CompanyCountryID.EditValue))
                Reference1CompanyCountryID.EditValue = FormatNumber(Reference1CompanyCountryID.EditValue, null);

            // Reference1CompanyTelephone
            Reference1CompanyTelephone.SetupEditAttributes();
            if (!Reference1CompanyTelephone.Raw)
                Reference1CompanyTelephone.CurrentValue = HtmlDecode(Reference1CompanyTelephone.CurrentValue);
            Reference1CompanyTelephone.EditValue = HtmlEncode(Reference1CompanyTelephone.CurrentValue);
            Reference1CompanyTelephone.PlaceHolder = RemoveHtml(Reference1CompanyTelephone.Caption);

            // Reference2CompanyName
            Reference2CompanyName.SetupEditAttributes();
            if (!Reference2CompanyName.Raw)
                Reference2CompanyName.CurrentValue = HtmlDecode(Reference2CompanyName.CurrentValue);
            Reference2CompanyName.EditValue = HtmlEncode(Reference2CompanyName.CurrentValue);
            Reference2CompanyName.PlaceHolder = RemoveHtml(Reference2CompanyName.Caption);

            // Reference2ContactPersonName
            Reference2ContactPersonName.SetupEditAttributes();
            if (!Reference2ContactPersonName.Raw)
                Reference2ContactPersonName.CurrentValue = HtmlDecode(Reference2ContactPersonName.CurrentValue);
            Reference2ContactPersonName.EditValue = HtmlEncode(Reference2ContactPersonName.CurrentValue);
            Reference2ContactPersonName.PlaceHolder = RemoveHtml(Reference2ContactPersonName.Caption);

            // Reference2CompanyAddress
            Reference2CompanyAddress.SetupEditAttributes();
            Reference2CompanyAddress.EditValue = Reference2CompanyAddress.CurrentValue; // DN
            Reference2CompanyAddress.PlaceHolder = RemoveHtml(Reference2CompanyAddress.Caption);

            // Reference2CompanyCountryID
            Reference2CompanyCountryID.SetupEditAttributes();
            Reference2CompanyCountryID.PlaceHolder = RemoveHtml(Reference2CompanyCountryID.Caption);
            if (!Empty(Reference2CompanyCountryID.EditValue) && IsNumeric(Reference2CompanyCountryID.EditValue))
                Reference2CompanyCountryID.EditValue = FormatNumber(Reference2CompanyCountryID.EditValue, null);

            // Reference2CompanyTelephone
            Reference2CompanyTelephone.SetupEditAttributes();
            if (!Reference2CompanyTelephone.Raw)
                Reference2CompanyTelephone.CurrentValue = HtmlDecode(Reference2CompanyTelephone.CurrentValue);
            Reference2CompanyTelephone.EditValue = HtmlEncode(Reference2CompanyTelephone.CurrentValue);
            Reference2CompanyTelephone.PlaceHolder = RemoveHtml(Reference2CompanyTelephone.Caption);

            // EmployeeStatus
            EmployeeStatus.SetupEditAttributes();
            if (!EmployeeStatus.Raw)
                EmployeeStatus.CurrentValue = HtmlDecode(EmployeeStatus.CurrentValue);
            EmployeeStatus.EditValue = HtmlEncode(EmployeeStatus.CurrentValue);
            EmployeeStatus.PlaceHolder = RemoveHtml(EmployeeStatus.Caption);

            // FormSubmittedDateTime
            FormSubmittedDateTime.SetupEditAttributes();
            FormSubmittedDateTime.EditValue = FormatDateTime(FormSubmittedDateTime.CurrentValue, FormSubmittedDateTime.FormatPattern); // DN
            FormSubmittedDateTime.PlaceHolder = RemoveHtml(FormSubmittedDateTime.Caption);

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

            // MTUserID
            MTUserID.SetupEditAttributes();
            if (!Security.IsAdmin && Security.IsLoggedIn && !UserIDAllow("info")) { // Non system admin
                MTUserID.CurrentValue = CurrentUserID();
                MTUserID.EditValue = MTUserID.CurrentValue;
                MTUserID.EditValue = FormatNumber(MTUserID.EditValue, MTUserID.FormatPattern);
                MTUserID.ViewCustomAttributes = "";
            } else {
                MTUserID.EditValue = MTUserID.CurrentValue; // DN
                MTUserID.PlaceHolder = RemoveHtml(MTUserID.Caption);
                if (!Empty(MTUserID.EditValue) && IsNumeric(MTUserID.EditValue))
                    MTUserID.EditValue = FormatNumber(MTUserID.EditValue, null);
            }

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.SetupEditAttributes();
            Reference1CompanyTelephoneCode_CountryID.PlaceHolder = RemoveHtml(Reference1CompanyTelephoneCode_CountryID.Caption);

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.SetupEditAttributes();
            Reference2CompanyTelephoneCode_CountryID.PlaceHolder = RemoveHtml(Reference2CompanyTelephoneCode_CountryID.Caption);

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
                        doc.ExportCaption(ForeignVisaHasBeenDenied);
                        doc.ExportCaption(ForeignVisaDenied_CountryID);
                        doc.ExportCaption(ForeignVisaDeniedReason);
                        doc.ExportCaption(HasMaritimeAccidentOrCourtOfEnquiry);
                        doc.ExportCaption(HasMaritimeAccidentOrCourtOfEnquiryDetails);
                        doc.ExportCaption(Reference1CompanyName);
                        doc.ExportCaption(Reference1ContactPersonName);
                        doc.ExportCaption(Reference1CompanyAddress);
                        doc.ExportCaption(Reference1CompanyCountryID);
                        doc.ExportCaption(Reference1CompanyTelephone);
                        doc.ExportCaption(Reference2CompanyName);
                        doc.ExportCaption(Reference2ContactPersonName);
                        doc.ExportCaption(Reference2CompanyAddress);
                        doc.ExportCaption(Reference2CompanyCountryID);
                        doc.ExportCaption(Reference2CompanyTelephone);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(FormSubmittedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(Reference1CompanyTelephoneCode_CountryID);
                        doc.ExportCaption(Reference2CompanyTelephoneCode_CountryID);
                    } else {
                        doc.ExportCaption(ForeignVisaHasBeenDenied);
                        doc.ExportCaption(ForeignVisaDenied_CountryID);
                        doc.ExportCaption(ForeignVisaDeniedReason);
                        doc.ExportCaption(HasMaritimeAccidentOrCourtOfEnquiry);
                        doc.ExportCaption(HasMaritimeAccidentOrCourtOfEnquiryDetails);
                        doc.ExportCaption(Reference1CompanyName);
                        doc.ExportCaption(Reference1ContactPersonName);
                        doc.ExportCaption(Reference1CompanyAddress);
                        doc.ExportCaption(Reference1CompanyCountryID);
                        doc.ExportCaption(Reference1CompanyTelephone);
                        doc.ExportCaption(Reference2CompanyName);
                        doc.ExportCaption(Reference2ContactPersonName);
                        doc.ExportCaption(Reference2CompanyAddress);
                        doc.ExportCaption(Reference2CompanyCountryID);
                        doc.ExportCaption(Reference2CompanyTelephone);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(FormSubmittedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(Reference1CompanyTelephoneCode_CountryID);
                        doc.ExportCaption(Reference2CompanyTelephoneCode_CountryID);
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
                            await doc.ExportField(ForeignVisaHasBeenDenied);
                            await doc.ExportField(ForeignVisaDenied_CountryID);
                            await doc.ExportField(ForeignVisaDeniedReason);
                            await doc.ExportField(HasMaritimeAccidentOrCourtOfEnquiry);
                            await doc.ExportField(HasMaritimeAccidentOrCourtOfEnquiryDetails);
                            await doc.ExportField(Reference1CompanyName);
                            await doc.ExportField(Reference1ContactPersonName);
                            await doc.ExportField(Reference1CompanyAddress);
                            await doc.ExportField(Reference1CompanyCountryID);
                            await doc.ExportField(Reference1CompanyTelephone);
                            await doc.ExportField(Reference2CompanyName);
                            await doc.ExportField(Reference2ContactPersonName);
                            await doc.ExportField(Reference2CompanyAddress);
                            await doc.ExportField(Reference2CompanyCountryID);
                            await doc.ExportField(Reference2CompanyTelephone);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(FormSubmittedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(Reference1CompanyTelephoneCode_CountryID);
                            await doc.ExportField(Reference2CompanyTelephoneCode_CountryID);
                        } else {
                            await doc.ExportField(ForeignVisaHasBeenDenied);
                            await doc.ExportField(ForeignVisaDenied_CountryID);
                            await doc.ExportField(ForeignVisaDeniedReason);
                            await doc.ExportField(HasMaritimeAccidentOrCourtOfEnquiry);
                            await doc.ExportField(HasMaritimeAccidentOrCourtOfEnquiryDetails);
                            await doc.ExportField(Reference1CompanyName);
                            await doc.ExportField(Reference1ContactPersonName);
                            await doc.ExportField(Reference1CompanyAddress);
                            await doc.ExportField(Reference1CompanyCountryID);
                            await doc.ExportField(Reference1CompanyTelephone);
                            await doc.ExportField(Reference2CompanyName);
                            await doc.ExportField(Reference2ContactPersonName);
                            await doc.ExportField(Reference2CompanyAddress);
                            await doc.ExportField(Reference2CompanyCountryID);
                            await doc.ExportField(Reference2CompanyTelephone);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(FormSubmittedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(Reference1CompanyTelephoneCode_CountryID);
                            await doc.ExportField(Reference2CompanyTelephoneCode_CountryID);
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

        // Add User ID filter
        public string AddUserIDFilter(string filter = "", string id = "")
        {
            string filterWrk = "";
            if (id == "")
                id = (CurrentPageID() == "list") ? CurrentAction : CurrentPageID();
            if (!UserIDAllow(id) && !Security.IsAdmin) {
                filterWrk = Security.UserIDList();
                if (!Empty(filterWrk))
                    filterWrk = "dbo.MTCrew.MTUserID IN (" + filterWrk + ")";
            }

            // Call User ID Filtering event
            UserIdFiltering(ref filterWrk);
            AddFilter(ref filter, filterWrk);
            return filter;
        }

        // User ID subquery
        public string GetUserIDSubquery(DbField fld, DbField masterfld)
        {
            string wrk = "";
            string sql = "SELECT " + masterfld.Expression + " FROM dbo.MTCrew";
            string filter = AddUserIDFilter();
            if (!Empty(filter))
                sql += " WHERE " + filter;
            var list = Connection.GetRows(sql);
            wrk = String.Join(",", list.Select(d => QuotedValue(d.Values.First(), masterfld.DataType, Config.UserTableDbId))); // List all values
            if (!Empty(wrk))
                wrk = fld.Expression + " IN (" + wrk + ")";
            else
                wrk = "0=1"; // No User ID value found
            return wrk;
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
            rsnew["LastUpdatedByUserID"] = CurrentUserID();
            rsnew["LastUpdatedDateTime"] = DateTimeOffset.Now;
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
