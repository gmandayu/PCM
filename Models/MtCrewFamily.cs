namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mtCrewFamily
    /// </summary>
    [MaybeNull]
    public static MtCrewFamily mtCrewFamily
    {
        get => HttpData.Resolve<MtCrewFamily>("MTCrewFamily");
        set => HttpData["MTCrewFamily"] = value;
    }

    /// <summary>
    /// Table class for MTCrewFamily
    /// </summary>
    public class MtCrewFamily : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> Relationship;

        public readonly DbField<SqlDbType> FullName;

        public readonly DbField<SqlDbType> Gender;

        public readonly DbField<SqlDbType> DateOfBirth;

        public readonly DbField<SqlDbType> MobileNumberCode_CountryID;

        public readonly DbField<SqlDbType> MobileNumber;

        public readonly DbField<SqlDbType> _Email;

        public readonly DbField<SqlDbType> SocialSecurityNumber;

        public readonly DbField<SqlDbType> FamilyRegisterNumber;

        public readonly DbField<SqlDbType> ActiveDescription;

        public readonly DbField<SqlDbType> Address;

        public readonly DbField<SqlDbType> CreatedByUserID;

        public readonly DbField<SqlDbType> CreatedDateTime;

        public readonly DbField<SqlDbType> LastUpdatedByUserID;

        public readonly DbField<SqlDbType> LastUpdatedDateTime;

        public readonly DbField<SqlDbType> PassportValidUntil;

        public readonly DbField<SqlDbType> PassportPlaceIssued;

        public readonly DbField<SqlDbType> PassportDateIssued;

        public readonly DbField<SqlDbType> PassportNumber;

        public readonly DbField<SqlDbType> FirstName;

        public readonly DbField<SqlDbType> LastName;

        public readonly DbField<SqlDbType> MTUserID;

        // Constructor
        public MtCrewFamily()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "MTCrewFamily";
            Name = "MTCrewFamily";
            Type = "TABLE";
            UpdateTable = "dbo.MTCrewFamily"; // Update Table
            DbId = "DB"; // DN
            ExportAll = true;
            ExportPageBreakCount = 0; // Page break per every n record (PDF only)
            ExportPageOrientation = "portrait"; // Page orientation (PDF only)
            ExportPageSize = "a4"; // Page size (PDF only)
            ExportColumnWidths = new float[] {  }; // Column widths (PDF only) // DN
            ExportExcelPageOrientation = "Portrait"; // Page orientation (EPPlus only)
            ExportExcelPageSize = "A4"; // Page size (EPPlus only)
            ExportWordPageOrientation = ""; // Page orientation (Word only)
            DetailAdd = true; // Allow detail add
            DetailEdit = true; // Allow detail edit
            DetailView = true; // Allow detail view
            ShowMultipleDetails = false; // Show multiple details
            GridAddRowCount = 5;
            AllowAddDeleteRow = true; // Allow add/delete row
            UseAjaxActions = UseAjaxActions || Config.UseAjaxActions;

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
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ID", ID);

            // MTCrewID
            MTCrewID = new (this, "x_MTCrewID", 3, SqlDbType.Int) {
                Name = "MTCrewID",
                Expression = "[MTCrewID]",
                BasicSearchExpression = "CAST([MTCrewID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[MTCrewID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                IsForeignKey = true, // Foreign key field
                Required = true, // Required field
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "MTCrewID", "CustomMsg"),
                IsUpload = false
            };
            MTCrewID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MTCrewID", "MTCrew", true, "ID", new List<string> {"IndividualCodeNumber", "FullName", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([IndividualCodeNumber],'" + ValueSeparator(1, MTCrewID) + "',[FullName])"),
                "id-ID" => new Lookup<DbField>("MTCrewID", "MTCrew", true, "ID", new List<string> {"IndividualCodeNumber", "FullName", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([IndividualCodeNumber],'" + ValueSeparator(1, MTCrewID) + "',[FullName])"),
                _ => new Lookup<DbField>("MTCrewID", "MTCrew", true, "ID", new List<string> {"IndividualCodeNumber", "FullName", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([IndividualCodeNumber],'" + ValueSeparator(1, MTCrewID) + "',[FullName])")
            };
            Fields.Add("MTCrewID", MTCrewID);

            // Relationship
            Relationship = new (this, "x_Relationship", 202, SqlDbType.NVarChar) {
                Name = "Relationship",
                Expression = "[Relationship]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Relationship]",
                DateTimeFormat = -1,
                VirtualExpression = "[Relationship]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                Required = true, // Required field
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                OptionCount = 5,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "Relationship", "CustomMsg"),
                IsUpload = false
            };
            Relationship.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Relationship", "MTCrewFamily", true, "Relationship", new List<string> {"Relationship", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Relationship", "MTCrewFamily", true, "Relationship", new List<string> {"Relationship", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Relationship", "MTCrewFamily", true, "Relationship", new List<string> {"Relationship", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Relationship", Relationship);

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
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "FullName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("FullName", FullName);

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
                HtmlTag = "SELECT",
                InputTextType = "text",
                Required = true, // Required field
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "Gender", "CustomMsg"),
                IsUpload = false
            };
            Gender.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Gender", "MTCrewFamily", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Gender", "MTCrewFamily", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Gender", "MTCrewFamily", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Gender", Gender);

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
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "DateOfBirth", "CustomMsg"),
                IsUpload = false
            };
            DateOfBirth.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("DateOfBirth", "MTCrewFamily", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("DateOfBirth", "MTCrewFamily", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("DateOfBirth", "MTCrewFamily", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("DateOfBirth", DateOfBirth);

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID = new (this, "x_MobileNumberCode_CountryID", 3, SqlDbType.Int) {
                Name = "MobileNumberCode_CountryID",
                Expression = "[MobileNumberCode_CountryID]",
                BasicSearchExpression = "CAST([MobileNumberCode_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[MobileNumberCode_CountryID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "MobileNumberCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MobileNumberCode_CountryID", MobileNumberCode_CountryID);

            // MobileNumber
            MobileNumber = new (this, "x_MobileNumber", 202, SqlDbType.NVarChar) {
                Name = "MobileNumber",
                Expression = "[MobileNumber]",
                UseBasicSearch = true,
                BasicSearchExpression = "[MobileNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[MobileNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "MobileNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MobileNumber", MobileNumber);

            // Email
            _Email = new (this, "x__Email", 202, SqlDbType.NVarChar) {
                Name = "Email",
                Expression = "[Email]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Email]",
                DateTimeFormat = -1,
                VirtualExpression = "[Email]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "_Email", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Email", _Email);

            // SocialSecurityNumber
            SocialSecurityNumber = new (this, "x_SocialSecurityNumber", 202, SqlDbType.NVarChar) {
                Name = "SocialSecurityNumber",
                Expression = "[SocialSecurityNumber]",
                UseBasicSearch = true,
                BasicSearchExpression = "[SocialSecurityNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[SocialSecurityNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "SocialSecurityNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("SocialSecurityNumber", SocialSecurityNumber);

            // FamilyRegisterNumber
            FamilyRegisterNumber = new (this, "x_FamilyRegisterNumber", 202, SqlDbType.NVarChar) {
                Name = "FamilyRegisterNumber",
                Expression = "[FamilyRegisterNumber]",
                UseBasicSearch = true,
                BasicSearchExpression = "[FamilyRegisterNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[FamilyRegisterNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "FamilyRegisterNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("FamilyRegisterNumber", FamilyRegisterNumber);

            // ActiveDescription
            ActiveDescription = new (this, "x_ActiveDescription", 202, SqlDbType.NVarChar) {
                Name = "ActiveDescription",
                Expression = "[ActiveDescription]",
                BasicSearchExpression = "[ActiveDescription]",
                DateTimeFormat = -1,
                VirtualExpression = "[ActiveDescription]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "ActiveDescription", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ActiveDescription", ActiveDescription);

            // Address
            Address = new (this, "x_Address", 202, SqlDbType.NVarChar) {
                Name = "Address",
                Expression = "[Address]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Address]",
                DateTimeFormat = -1,
                VirtualExpression = "[Address]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "Address", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Address", Address);

            // CreatedByUserID
            CreatedByUserID = new (this, "x_CreatedByUserID", 3, SqlDbType.Int) {
                Name = "CreatedByUserID",
                Expression = "[CreatedByUserID]",
                BasicSearchExpression = "CAST([CreatedByUserID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[CreatedByUserID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "CreatedByUserID", "CustomMsg"),
                IsUpload = false
            };
            CreatedByUserID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedByUserID", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]"),
                "id-ID" => new Lookup<DbField>("CreatedByUserID", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]"),
                _ => new Lookup<DbField>("CreatedByUserID", "MTUser", true, "ID", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Email]")
            };
            Fields.Add("CreatedByUserID", CreatedByUserID);

            // CreatedDateTime
            CreatedDateTime = new (this, "x_CreatedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "CreatedDateTime",
                Expression = "[CreatedDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[CreatedDateTime]", 1, "DB"),
                DateTimeFormat = 1,
                VirtualExpression = "[CreatedDateTime]",
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
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "CreatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            CreatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedDateTime", "MTCrewFamily", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CreatedDateTime", "MTCrewFamily", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CreatedDateTime", "MTCrewFamily", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CreatedDateTime", CreatedDateTime);

            // LastUpdatedByUserID
            LastUpdatedByUserID = new (this, "x_LastUpdatedByUserID", 3, SqlDbType.Int) {
                Name = "LastUpdatedByUserID",
                Expression = "[LastUpdatedByUserID]",
                BasicSearchExpression = "CAST([LastUpdatedByUserID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[LastUpdatedByUserID]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "LastUpdatedByUserID", "CustomMsg"),
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
                Expression = "[LastUpdatedDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[LastUpdatedDateTime]", 1, "DB"),
                DateTimeFormat = 1,
                VirtualExpression = "[LastUpdatedDateTime]",
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
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "LastUpdatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedDateTime", "MTCrewFamily", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedDateTime", "MTCrewFamily", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedDateTime", "MTCrewFamily", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("LastUpdatedDateTime", LastUpdatedDateTime);

            // PassportValidUntil
            PassportValidUntil = new (this, "x_PassportValidUntil", 133, SqlDbType.DateTime) {
                Name = "PassportValidUntil",
                Expression = "[PassportValidUntil]",
                BasicSearchExpression = CastDateFieldForLike("[PassportValidUntil]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[PassportValidUntil]",
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
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "PassportValidUntil", "CustomMsg"),
                IsUpload = false
            };
            PassportValidUntil.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("PassportValidUntil", "MTCrewFamily", true, "PassportValidUntil", new List<string> {"PassportValidUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("PassportValidUntil", "MTCrewFamily", true, "PassportValidUntil", new List<string> {"PassportValidUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("PassportValidUntil", "MTCrewFamily", true, "PassportValidUntil", new List<string> {"PassportValidUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("PassportValidUntil", PassportValidUntil);

            // PassportPlaceIssued
            PassportPlaceIssued = new (this, "x_PassportPlaceIssued", 202, SqlDbType.NVarChar) {
                Name = "PassportPlaceIssued",
                Expression = "[PassportPlaceIssued]",
                BasicSearchExpression = "[PassportPlaceIssued]",
                DateTimeFormat = -1,
                VirtualExpression = "[PassportPlaceIssued]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "PassportPlaceIssued", "CustomMsg"),
                IsUpload = false
            };
            PassportPlaceIssued.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("PassportPlaceIssued", "MTCrewFamily", true, "PassportPlaceIssued", new List<string> {"PassportPlaceIssued", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("PassportPlaceIssued", "MTCrewFamily", true, "PassportPlaceIssued", new List<string> {"PassportPlaceIssued", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("PassportPlaceIssued", "MTCrewFamily", true, "PassportPlaceIssued", new List<string> {"PassportPlaceIssued", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("PassportPlaceIssued", PassportPlaceIssued);

            // PassportDateIssued
            PassportDateIssued = new (this, "x_PassportDateIssued", 133, SqlDbType.DateTime) {
                Name = "PassportDateIssued",
                Expression = "[PassportDateIssued]",
                BasicSearchExpression = CastDateFieldForLike("[PassportDateIssued]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[PassportDateIssued]",
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
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "PassportDateIssued", "CustomMsg"),
                IsUpload = false
            };
            PassportDateIssued.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("PassportDateIssued", "MTCrewFamily", true, "PassportDateIssued", new List<string> {"PassportDateIssued", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("PassportDateIssued", "MTCrewFamily", true, "PassportDateIssued", new List<string> {"PassportDateIssued", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("PassportDateIssued", "MTCrewFamily", true, "PassportDateIssued", new List<string> {"PassportDateIssued", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("PassportDateIssued", PassportDateIssued);

            // PassportNumber
            PassportNumber = new (this, "x_PassportNumber", 202, SqlDbType.NVarChar) {
                Name = "PassportNumber",
                Expression = "[PassportNumber]",
                BasicSearchExpression = "[PassportNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[PassportNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "PassportNumber", "CustomMsg"),
                IsUpload = false
            };
            PassportNumber.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("PassportNumber", "MTCrewFamily", true, "PassportNumber", new List<string> {"PassportNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("PassportNumber", "MTCrewFamily", true, "PassportNumber", new List<string> {"PassportNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("PassportNumber", "MTCrewFamily", true, "PassportNumber", new List<string> {"PassportNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("PassportNumber", PassportNumber);

            // FirstName
            FirstName = new (this, "x_FirstName", 202, SqlDbType.NVarChar) {
                Name = "FirstName",
                Expression = "[FirstName]",
                BasicSearchExpression = "[FirstName]",
                DateTimeFormat = -1,
                VirtualExpression = "[FirstName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "FirstName", "CustomMsg"),
                IsUpload = false
            };
            FirstName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FirstName", "MTCrewFamily", true, "FirstName", new List<string> {"FirstName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("FirstName", "MTCrewFamily", true, "FirstName", new List<string> {"FirstName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("FirstName", "MTCrewFamily", true, "FirstName", new List<string> {"FirstName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("FirstName", FirstName);

            // LastName
            LastName = new (this, "x_LastName", 202, SqlDbType.NVarChar) {
                Name = "LastName",
                Expression = "[LastName]",
                BasicSearchExpression = "[LastName]",
                DateTimeFormat = -1,
                VirtualExpression = "[LastName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "LastName", "CustomMsg"),
                IsUpload = false
            };
            LastName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastName", "MTCrewFamily", true, "LastName", new List<string> {"LastName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastName", "MTCrewFamily", true, "LastName", new List<string> {"LastName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastName", "MTCrewFamily", true, "LastName", new List<string> {"LastName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("LastName", LastName);

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
                CustomMessage = Language.FieldPhrase("MTCrewFamily", "MTUserID", "CustomMsg"),
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

        // Current master table name
        public string CurrentMasterTable
        {
            get => Session.GetString(Config.ProjectName + "_" + TableVar + "_" + Config.TableMasterTable);
            set => Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableMasterTable] = value;
        }

        // Session master where clause
        public string MasterFilterFromSession
        {
            get { // Master filter
                string masterFilter = "";
            if (CurrentMasterTable == "MTCrew") {
                dynamic masterTable = Resolve("MTCrew")!;
                if (!Empty(MTCrewID.SessionValue))
                    masterFilter += "" + KeyFilter(masterTable.ID, MTCrewID.SessionValue, masterTable.ID.DataType, masterTable.DbId);
                else
                    return "";
            }
                return masterFilter;
            }
        }

        // Session detail WHERE clause
        public string DetailFilterFromSession
        {
            get { // Detail filter
                string detailFilter = "";
                if (CurrentMasterTable == "MTCrew") {
                    dynamic masterTable = Resolve("MTCrew")!;
                    if (!Empty(MTCrewID.SessionValue))
                        detailFilter += "" + KeyFilter(MTCrewID, MTCrewID.SessionValue, masterTable.ID.DataType, DbId);
                    else
                        return "";
                }
                return detailFilter;
            }
        }

        // Master filter // DN
        public string? MasterFilter(dynamic? masterTable, Dictionary<string, object?> keys) // DN
        {
            bool validKeys = true;
            object key = "";
            switch (masterTable?.TableVar) {
            case "MTCrew":
                key = keys["MTCrewID"] ?? "";
                if (Empty(key)) {
                    if (masterTable.ID.Required) // Required field and empty value
                        return ""; // Return empty filter
                    validKeys = false;
                } else if (!validKeys) { // Already has empty key
                    return ""; // Return empty filter
                }
                if (validKeys) {
                    return KeyFilter(masterTable.ID, keys["MTCrewID"], MTCrewID.DataType, DbId);
                }
                break;
            }
            return null; // All null values and no required fields
        }

        // Detail filter // DN
        public string DetailFilter(dynamic masterTable) // DN
        {
            return masterTable.TableVar switch {
                "MTCrew" => KeyFilter(MTCrewID, masterTable.ID.DbValue, masterTable.ID.DataType, masterTable.DbId),
                _ => ""
            };
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
            get => _sqlFrom ?? "dbo.MTCrewFamily";
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
                MTCrewID.DbValue = row["MTCrewID"]; // Set DB value only
                Relationship.DbValue = row["Relationship"]; // Set DB value only
                FullName.DbValue = row["FullName"]; // Set DB value only
                Gender.DbValue = row["Gender"]; // Set DB value only
                DateOfBirth.DbValue = row["DateOfBirth"]; // Set DB value only
                MobileNumberCode_CountryID.DbValue = row["MobileNumberCode_CountryID"]; // Set DB value only
                MobileNumber.DbValue = row["MobileNumber"]; // Set DB value only
                _Email.DbValue = row["Email"]; // Set DB value only
                SocialSecurityNumber.DbValue = row["SocialSecurityNumber"]; // Set DB value only
                FamilyRegisterNumber.DbValue = row["FamilyRegisterNumber"]; // Set DB value only
                ActiveDescription.DbValue = row["ActiveDescription"]; // Set DB value only
                Address.DbValue = row["Address"]; // Set DB value only
                CreatedByUserID.DbValue = row["CreatedByUserID"]; // Set DB value only
                CreatedDateTime.DbValue = row["CreatedDateTime"]; // Set DB value only
                LastUpdatedByUserID.DbValue = row["LastUpdatedByUserID"]; // Set DB value only
                LastUpdatedDateTime.DbValue = row["LastUpdatedDateTime"]; // Set DB value only
                PassportValidUntil.DbValue = row["PassportValidUntil"]; // Set DB value only
                PassportPlaceIssued.DbValue = row["PassportPlaceIssued"]; // Set DB value only
                PassportDateIssued.DbValue = row["PassportDateIssued"]; // Set DB value only
                PassportNumber.DbValue = row["PassportNumber"]; // Set DB value only
                FirstName.DbValue = row["FirstName"]; // Set DB value only
                LastName.DbValue = row["LastName"]; // Set DB value only
                MTUserID.DbValue = row["MTUserID"]; // Set DB value only
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
                    return "MtCrewFamilyList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "MtCrewFamilyView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "MtCrewFamilyEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "MtCrewFamilyAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "MtCrewFamilyList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "MtCrewFamilyView",
                Config.ApiAddAction => "MtCrewFamilyAdd",
                Config.ApiEditAction => "MtCrewFamilyEdit",
                Config.ApiDeleteAction => "MtCrewFamilyDelete",
                Config.ApiListAction => "MtCrewFamilyList",
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
        public string ListUrl => "MtCrewFamilyList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("MtCrewFamilyView", parm);
            else
                url = KeyUrl("MtCrewFamilyView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "MtCrewFamilyAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "MtCrewFamilyAdd?" + parm;
            else
                url = "MtCrewFamilyAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("MtCrewFamilyEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("MtCrewFamilyList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("MtCrewFamilyAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("MtCrewFamilyList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("MtCrewFamilyDelete")); // DN

        // Add master URL
        public string AddMasterUrl(string url)
        {
            if (CurrentMasterTable == "MTCrew" && !url.Contains(Config.TableShowMaster + "=")) {
                url += (url.Contains("?") ? "&" : "?") + Config.TableShowMaster + "=" + CurrentMasterTable;
                url += "&" + ForeignKeyUrl("fk_ID", MTCrewID.SessionValue); // Use Session Value
            }
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
            Relationship.SetDbValue(dr["Relationship"]);
            FullName.SetDbValue(dr["FullName"]);
            Gender.SetDbValue(dr["Gender"]);
            DateOfBirth.SetDbValue(dr["DateOfBirth"]);
            MobileNumberCode_CountryID.SetDbValue(dr["MobileNumberCode_CountryID"]);
            MobileNumber.SetDbValue(dr["MobileNumber"]);
            _Email.SetDbValue(dr["Email"]);
            SocialSecurityNumber.SetDbValue(dr["SocialSecurityNumber"]);
            FamilyRegisterNumber.SetDbValue(dr["FamilyRegisterNumber"]);
            ActiveDescription.SetDbValue(dr["ActiveDescription"]);
            Address.SetDbValue(dr["Address"]);
            CreatedByUserID.SetDbValue(dr["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(dr["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(dr["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(dr["LastUpdatedDateTime"]);
            PassportValidUntil.SetDbValue(dr["PassportValidUntil"]);
            PassportPlaceIssued.SetDbValue(dr["PassportPlaceIssued"]);
            PassportDateIssued.SetDbValue(dr["PassportDateIssued"]);
            PassportNumber.SetDbValue(dr["PassportNumber"]);
            FirstName.SetDbValue(dr["FirstName"]);
            LastName.SetDbValue(dr["LastName"]);
            MTUserID.SetDbValue(dr["MTUserID"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "MtCrewFamilyList";
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

            // Relationship
            Relationship.CellCssStyle = "white-space: nowrap;";

            // FullName

            // Gender
            Gender.CellCssStyle = "white-space: nowrap;";

            // DateOfBirth
            DateOfBirth.CellCssStyle = "white-space: nowrap;";

            // MobileNumberCode_CountryID

            // MobileNumber

            // Email

            // SocialSecurityNumber

            // FamilyRegisterNumber

            // ActiveDescription
            ActiveDescription.CellCssStyle = "white-space: nowrap;";

            // Address

            // CreatedByUserID
            CreatedByUserID.CellCssStyle = "white-space: nowrap;";

            // CreatedDateTime
            CreatedDateTime.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedByUserID
            LastUpdatedByUserID.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedDateTime
            LastUpdatedDateTime.CellCssStyle = "white-space: nowrap;";

            // PassportValidUntil
            PassportValidUntil.CellCssStyle = "white-space: nowrap;";

            // PassportPlaceIssued
            PassportPlaceIssued.CellCssStyle = "white-space: nowrap;";

            // PassportDateIssued
            PassportDateIssued.CellCssStyle = "white-space: nowrap;";

            // PassportNumber
            PassportNumber.CellCssStyle = "white-space: nowrap;";

            // FirstName
            FirstName.CellCssStyle = "white-space: nowrap;";

            // LastName
            LastName.CellCssStyle = "white-space: nowrap;";

            // MTUserID
            MTUserID.CellCssStyle = "white-space: nowrap;";

            // ID
            ID.ViewValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

            // MTCrewID
            curVal = ConvertToString(MTCrewID.CurrentValue);
            if (!Empty(curVal)) {
                if (MTCrewID.Lookup != null && IsDictionary(MTCrewID.Lookup?.Options) && MTCrewID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTCrewID.ViewValue = MTCrewID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", MTCrewID.CurrentValue, DataType.Number, "");
                    sqlWrk = MTCrewID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && MTCrewID.Lookup != null) { // Lookup values found
                        var listwrk = MTCrewID.Lookup?.RenderViewRow(rswrk[0]);
                        MTCrewID.ViewValue = MTCrewID.HighlightLookup(ConvertToString(rswrk[0]), MTCrewID.DisplayValue(listwrk));
                    } else {
                        MTCrewID.ViewValue = FormatNumber(MTCrewID.CurrentValue, MTCrewID.FormatPattern);
                    }
                }
            } else {
                MTCrewID.ViewValue = DbNullValue;
            }
            MTCrewID.ViewCustomAttributes = "";

            // Relationship
            if (!Empty(Relationship.CurrentValue)) {
                Relationship.ViewValue = Relationship.HighlightLookup(ConvertToString(Relationship.CurrentValue), Relationship.OptionCaption(ConvertToString(Relationship.CurrentValue)));
            } else {
                Relationship.ViewValue = DbNullValue;
            }
            Relationship.ViewCustomAttributes = "";

            // FullName
            FullName.ViewValue = ConvertToString(FullName.CurrentValue); // DN
            FullName.ViewCustomAttributes = "";

            // Gender
            if (!Empty(Gender.CurrentValue)) {
                Gender.ViewValue = Gender.HighlightLookup(ConvertToString(Gender.CurrentValue), Gender.OptionCaption(ConvertToString(Gender.CurrentValue)));
            } else {
                Gender.ViewValue = DbNullValue;
            }
            Gender.ViewCustomAttributes = "";

            // DateOfBirth
            DateOfBirth.ViewValue = DateOfBirth.CurrentValue;
            DateOfBirth.ViewValue = FormatDateTime(DateOfBirth.ViewValue, DateOfBirth.FormatPattern);
            DateOfBirth.ViewCustomAttributes = "";

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.ViewValue = MobileNumberCode_CountryID.CurrentValue;
            MobileNumberCode_CountryID.ViewValue = FormatNumber(MobileNumberCode_CountryID.ViewValue, MobileNumberCode_CountryID.FormatPattern);
            MobileNumberCode_CountryID.ViewCustomAttributes = "";

            // MobileNumber
            MobileNumber.ViewValue = ConvertToString(MobileNumber.CurrentValue); // DN
            MobileNumber.ViewCustomAttributes = "";

            // Email
            _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
            _Email.ViewCustomAttributes = "";

            // SocialSecurityNumber
            SocialSecurityNumber.ViewValue = ConvertToString(SocialSecurityNumber.CurrentValue); // DN
            SocialSecurityNumber.ViewCustomAttributes = "";

            // FamilyRegisterNumber
            FamilyRegisterNumber.ViewValue = ConvertToString(FamilyRegisterNumber.CurrentValue); // DN
            FamilyRegisterNumber.ViewCustomAttributes = "";

            // ActiveDescription
            ActiveDescription.ViewValue = ConvertToString(ActiveDescription.CurrentValue); // DN
            ActiveDescription.ViewCustomAttributes = "";

            // Address
            Address.ViewValue = ConvertToString(Address.CurrentValue); // DN
            Address.ViewCustomAttributes = "";

            // CreatedByUserID
            curVal = ConvertToString(CreatedByUserID.CurrentValue);
            if (!Empty(curVal)) {
                if (CreatedByUserID.Lookup != null && IsDictionary(CreatedByUserID.Lookup?.Options) && CreatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CreatedByUserID.ViewValue = CreatedByUserID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", CreatedByUserID.CurrentValue, DataType.Number, "");
                    sqlWrk = CreatedByUserID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && CreatedByUserID.Lookup != null) { // Lookup values found
                        var listwrk = CreatedByUserID.Lookup?.RenderViewRow(rswrk[0]);
                        CreatedByUserID.ViewValue = CreatedByUserID.HighlightLookup(ConvertToString(rswrk[0]), CreatedByUserID.DisplayValue(listwrk));
                    } else {
                        CreatedByUserID.ViewValue = FormatNumber(CreatedByUserID.CurrentValue, CreatedByUserID.FormatPattern);
                    }
                }
            } else {
                CreatedByUserID.ViewValue = DbNullValue;
            }
            CreatedByUserID.ViewCustomAttributes = "";

            // CreatedDateTime
            CreatedDateTime.ViewValue = CreatedDateTime.CurrentValue;
            CreatedDateTime.ViewValue = FormatDateTime(CreatedDateTime.ViewValue, CreatedDateTime.FormatPattern);
            CreatedDateTime.ViewCustomAttributes = "";

            // LastUpdatedByUserID
            curVal = ConvertToString(LastUpdatedByUserID.CurrentValue);
            if (!Empty(curVal)) {
                if (LastUpdatedByUserID.Lookup != null && IsDictionary(LastUpdatedByUserID.Lookup?.Options) && LastUpdatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    LastUpdatedByUserID.ViewValue = LastUpdatedByUserID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", LastUpdatedByUserID.CurrentValue, DataType.Number, "");
                    sqlWrk = LastUpdatedByUserID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && LastUpdatedByUserID.Lookup != null) { // Lookup values found
                        var listwrk = LastUpdatedByUserID.Lookup?.RenderViewRow(rswrk[0]);
                        LastUpdatedByUserID.ViewValue = LastUpdatedByUserID.HighlightLookup(ConvertToString(rswrk[0]), LastUpdatedByUserID.DisplayValue(listwrk));
                    } else {
                        LastUpdatedByUserID.ViewValue = FormatNumber(LastUpdatedByUserID.CurrentValue, LastUpdatedByUserID.FormatPattern);
                    }
                }
            } else {
                LastUpdatedByUserID.ViewValue = DbNullValue;
            }
            LastUpdatedByUserID.ViewCustomAttributes = "";

            // LastUpdatedDateTime
            LastUpdatedDateTime.ViewValue = LastUpdatedDateTime.CurrentValue;
            LastUpdatedDateTime.ViewValue = FormatDateTime(LastUpdatedDateTime.ViewValue, LastUpdatedDateTime.FormatPattern);
            LastUpdatedDateTime.ViewCustomAttributes = "";

            // PassportValidUntil
            PassportValidUntil.ViewValue = PassportValidUntil.CurrentValue;
            PassportValidUntil.ViewValue = FormatDateTime(PassportValidUntil.ViewValue, PassportValidUntil.FormatPattern);
            PassportValidUntil.ViewCustomAttributes = "";

            // PassportPlaceIssued
            PassportPlaceIssued.ViewValue = ConvertToString(PassportPlaceIssued.CurrentValue); // DN
            PassportPlaceIssued.ViewCustomAttributes = "";

            // PassportDateIssued
            PassportDateIssued.ViewValue = PassportDateIssued.CurrentValue;
            PassportDateIssued.ViewValue = FormatDateTime(PassportDateIssued.ViewValue, PassportDateIssued.FormatPattern);
            PassportDateIssued.ViewCustomAttributes = "";

            // PassportNumber
            PassportNumber.ViewValue = ConvertToString(PassportNumber.CurrentValue); // DN
            PassportNumber.ViewCustomAttributes = "";

            // FirstName
            FirstName.ViewValue = ConvertToString(FirstName.CurrentValue); // DN
            FirstName.ViewCustomAttributes = "";

            // LastName
            LastName.ViewValue = ConvertToString(LastName.CurrentValue); // DN
            LastName.ViewCustomAttributes = "";

            // MTUserID
            MTUserID.ViewValue = MTUserID.CurrentValue;
            MTUserID.ViewValue = FormatNumber(MTUserID.ViewValue, MTUserID.FormatPattern);
            MTUserID.ViewCustomAttributes = "";

            // ID
            ID.HrefValue = "";
            ID.TooltipValue = "";

            // MTCrewID
            MTCrewID.HrefValue = "";
            MTCrewID.TooltipValue = "";

            // Relationship
            Relationship.HrefValue = "";
            Relationship.TooltipValue = "";

            // FullName
            FullName.HrefValue = "";
            FullName.TooltipValue = "";

            // Gender
            Gender.HrefValue = "";
            Gender.TooltipValue = "";

            // DateOfBirth
            DateOfBirth.HrefValue = "";
            DateOfBirth.TooltipValue = "";

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.HrefValue = "";
            MobileNumberCode_CountryID.TooltipValue = "";

            // MobileNumber
            MobileNumber.HrefValue = "";
            MobileNumber.TooltipValue = "";

            // Email
            _Email.HrefValue = "";
            _Email.TooltipValue = "";

            // SocialSecurityNumber
            SocialSecurityNumber.HrefValue = "";
            SocialSecurityNumber.TooltipValue = "";

            // FamilyRegisterNumber
            FamilyRegisterNumber.HrefValue = "";
            FamilyRegisterNumber.TooltipValue = "";

            // ActiveDescription
            ActiveDescription.HrefValue = "";
            ActiveDescription.TooltipValue = "";

            // Address
            Address.HrefValue = "";
            Address.TooltipValue = "";

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

            // PassportValidUntil
            PassportValidUntil.HrefValue = "";
            PassportValidUntil.TooltipValue = "";

            // PassportPlaceIssued
            PassportPlaceIssued.HrefValue = "";
            PassportPlaceIssued.TooltipValue = "";

            // PassportDateIssued
            PassportDateIssued.HrefValue = "";
            PassportDateIssued.TooltipValue = "";

            // PassportNumber
            PassportNumber.HrefValue = "";
            PassportNumber.TooltipValue = "";

            // FirstName
            FirstName.HrefValue = "";
            FirstName.TooltipValue = "";

            // LastName
            LastName.HrefValue = "";
            LastName.TooltipValue = "";

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

            // ID
            ID.SetupEditAttributes();
            ID.EditValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

            // MTCrewID
            MTCrewID.SetupEditAttributes();
            if (!Empty(MTCrewID.SessionValue)) {
                MTCrewID.CurrentValue = ForeignKeyValue(MTCrewID.SessionValue);
                curVal = ConvertToString(MTCrewID.CurrentValue);
                if (!Empty(curVal)) {
                    if (MTCrewID.Lookup != null && IsDictionary(MTCrewID.Lookup?.Options) && MTCrewID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                        MTCrewID.ViewValue = MTCrewID.LookupCacheOption(curVal);
                    } else { // Lookup from database // DN
                        filterWrk = SearchFilter("[ID]", "=", MTCrewID.CurrentValue, DataType.Number, "");
                        sqlWrk = MTCrewID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                        rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                        if (rswrk?.Count > 0 && MTCrewID.Lookup != null) { // Lookup values found
                            var listwrk = MTCrewID.Lookup?.RenderViewRow(rswrk[0]);
                            MTCrewID.ViewValue = MTCrewID.HighlightLookup(ConvertToString(rswrk[0]), MTCrewID.DisplayValue(listwrk));
                        } else {
                            MTCrewID.ViewValue = FormatNumber(MTCrewID.CurrentValue, MTCrewID.FormatPattern);
                        }
                    }
                } else {
                    MTCrewID.ViewValue = DbNullValue;
                }
                MTCrewID.ViewCustomAttributes = "";
            } else {
                curVal = ConvertToString(MTCrewID.CurrentValue)?.Trim() ?? "";
                if (MTCrewID.Lookup != null && IsDictionary(MTCrewID.Lookup?.Options) && MTCrewID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTCrewID.EditValue = MTCrewID.Lookup?.Options.Values.ToList();
                } else { // Lookup from database
                    filterWrk = "";
                    sqlWrk = MTCrewID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    MTCrewID.EditValue = rswrk;
                }
                MTCrewID.PlaceHolder = RemoveHtml(MTCrewID.Caption);
                if (!Empty(MTCrewID.EditValue) && IsNumeric(MTCrewID.EditValue))
                    MTCrewID.EditValue = FormatNumber(MTCrewID.EditValue, null);
            }

            // Relationship
            Relationship.SetupEditAttributes();
            Relationship.EditValue = Relationship.Options(true);
            Relationship.PlaceHolder = RemoveHtml(Relationship.Caption);

            // FullName
            FullName.SetupEditAttributes();
            if (!FullName.Raw)
                FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
            FullName.EditValue = HtmlEncode(FullName.CurrentValue);
            FullName.PlaceHolder = RemoveHtml(FullName.Caption);

            // Gender
            Gender.SetupEditAttributes();
            Gender.EditValue = Gender.Options(true);
            Gender.PlaceHolder = RemoveHtml(Gender.Caption);

            // DateOfBirth
            DateOfBirth.SetupEditAttributes();
            DateOfBirth.EditValue = FormatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern); // DN
            DateOfBirth.PlaceHolder = RemoveHtml(DateOfBirth.Caption);

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.SetupEditAttributes();
            MobileNumberCode_CountryID.EditValue = MobileNumberCode_CountryID.CurrentValue; // DN
            MobileNumberCode_CountryID.PlaceHolder = RemoveHtml(MobileNumberCode_CountryID.Caption);
            if (!Empty(MobileNumberCode_CountryID.EditValue) && IsNumeric(MobileNumberCode_CountryID.EditValue))
                MobileNumberCode_CountryID.EditValue = FormatNumber(MobileNumberCode_CountryID.EditValue, null);

            // MobileNumber
            MobileNumber.SetupEditAttributes();
            if (!MobileNumber.Raw)
                MobileNumber.CurrentValue = HtmlDecode(MobileNumber.CurrentValue);
            MobileNumber.EditValue = HtmlEncode(MobileNumber.CurrentValue);
            MobileNumber.PlaceHolder = RemoveHtml(MobileNumber.Caption);

            // Email
            _Email.SetupEditAttributes();
            if (!_Email.Raw)
                _Email.CurrentValue = HtmlDecode(_Email.CurrentValue);
            _Email.EditValue = HtmlEncode(_Email.CurrentValue);
            _Email.PlaceHolder = RemoveHtml(_Email.Caption);

            // SocialSecurityNumber
            SocialSecurityNumber.SetupEditAttributes();
            if (!SocialSecurityNumber.Raw)
                SocialSecurityNumber.CurrentValue = HtmlDecode(SocialSecurityNumber.CurrentValue);
            SocialSecurityNumber.EditValue = HtmlEncode(SocialSecurityNumber.CurrentValue);
            SocialSecurityNumber.PlaceHolder = RemoveHtml(SocialSecurityNumber.Caption);

            // FamilyRegisterNumber
            FamilyRegisterNumber.SetupEditAttributes();
            if (!FamilyRegisterNumber.Raw)
                FamilyRegisterNumber.CurrentValue = HtmlDecode(FamilyRegisterNumber.CurrentValue);
            FamilyRegisterNumber.EditValue = HtmlEncode(FamilyRegisterNumber.CurrentValue);
            FamilyRegisterNumber.PlaceHolder = RemoveHtml(FamilyRegisterNumber.Caption);

            // ActiveDescription
            ActiveDescription.SetupEditAttributes();
            if (!ActiveDescription.Raw)
                ActiveDescription.CurrentValue = HtmlDecode(ActiveDescription.CurrentValue);
            ActiveDescription.EditValue = HtmlEncode(ActiveDescription.CurrentValue);
            ActiveDescription.PlaceHolder = RemoveHtml(ActiveDescription.Caption);

            // Address
            Address.SetupEditAttributes();
            if (!Address.Raw)
                Address.CurrentValue = HtmlDecode(Address.CurrentValue);
            Address.EditValue = HtmlEncode(Address.CurrentValue);
            Address.PlaceHolder = RemoveHtml(Address.Caption);

            // CreatedByUserID
            CreatedByUserID.SetupEditAttributes();
            curVal = ConvertToString(CreatedByUserID.CurrentValue)?.Trim() ?? "";
            if (CreatedByUserID.Lookup != null && IsDictionary(CreatedByUserID.Lookup?.Options) && CreatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                CreatedByUserID.EditValue = CreatedByUserID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = CreatedByUserID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                CreatedByUserID.EditValue = rswrk;
            }
            CreatedByUserID.PlaceHolder = RemoveHtml(CreatedByUserID.Caption);
            if (!Empty(CreatedByUserID.EditValue) && IsNumeric(CreatedByUserID.EditValue))
                CreatedByUserID.EditValue = FormatNumber(CreatedByUserID.EditValue, null);

            // CreatedDateTime
            CreatedDateTime.SetupEditAttributes();
            CreatedDateTime.EditValue = FormatDateTime(CreatedDateTime.CurrentValue, CreatedDateTime.FormatPattern); // DN
            CreatedDateTime.PlaceHolder = RemoveHtml(CreatedDateTime.Caption);

            // LastUpdatedByUserID
            LastUpdatedByUserID.SetupEditAttributes();
            curVal = ConvertToString(LastUpdatedByUserID.CurrentValue)?.Trim() ?? "";
            if (LastUpdatedByUserID.Lookup != null && IsDictionary(LastUpdatedByUserID.Lookup?.Options) && LastUpdatedByUserID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                LastUpdatedByUserID.EditValue = LastUpdatedByUserID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = LastUpdatedByUserID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                LastUpdatedByUserID.EditValue = rswrk;
            }
            LastUpdatedByUserID.PlaceHolder = RemoveHtml(LastUpdatedByUserID.Caption);
            if (!Empty(LastUpdatedByUserID.EditValue) && IsNumeric(LastUpdatedByUserID.EditValue))
                LastUpdatedByUserID.EditValue = FormatNumber(LastUpdatedByUserID.EditValue, null);

            // LastUpdatedDateTime
            LastUpdatedDateTime.SetupEditAttributes();
            LastUpdatedDateTime.EditValue = FormatDateTime(LastUpdatedDateTime.CurrentValue, LastUpdatedDateTime.FormatPattern); // DN
            LastUpdatedDateTime.PlaceHolder = RemoveHtml(LastUpdatedDateTime.Caption);

            // PassportValidUntil
            PassportValidUntil.SetupEditAttributes();
            PassportValidUntil.EditValue = FormatDateTime(PassportValidUntil.CurrentValue, PassportValidUntil.FormatPattern); // DN
            PassportValidUntil.PlaceHolder = RemoveHtml(PassportValidUntil.Caption);

            // PassportPlaceIssued
            PassportPlaceIssued.SetupEditAttributes();
            if (!PassportPlaceIssued.Raw)
                PassportPlaceIssued.CurrentValue = HtmlDecode(PassportPlaceIssued.CurrentValue);
            PassportPlaceIssued.EditValue = HtmlEncode(PassportPlaceIssued.CurrentValue);
            PassportPlaceIssued.PlaceHolder = RemoveHtml(PassportPlaceIssued.Caption);

            // PassportDateIssued
            PassportDateIssued.SetupEditAttributes();
            PassportDateIssued.EditValue = FormatDateTime(PassportDateIssued.CurrentValue, PassportDateIssued.FormatPattern); // DN
            PassportDateIssued.PlaceHolder = RemoveHtml(PassportDateIssued.Caption);

            // PassportNumber
            PassportNumber.SetupEditAttributes();
            if (!PassportNumber.Raw)
                PassportNumber.CurrentValue = HtmlDecode(PassportNumber.CurrentValue);
            PassportNumber.EditValue = HtmlEncode(PassportNumber.CurrentValue);
            PassportNumber.PlaceHolder = RemoveHtml(PassportNumber.Caption);

            // FirstName
            FirstName.SetupEditAttributes();
            if (!FirstName.Raw)
                FirstName.CurrentValue = HtmlDecode(FirstName.CurrentValue);
            FirstName.EditValue = HtmlEncode(FirstName.CurrentValue);
            FirstName.PlaceHolder = RemoveHtml(FirstName.Caption);

            // LastName
            LastName.SetupEditAttributes();
            if (!LastName.Raw)
                LastName.CurrentValue = HtmlDecode(LastName.CurrentValue);
            LastName.EditValue = HtmlEncode(LastName.CurrentValue);
            LastName.PlaceHolder = RemoveHtml(LastName.Caption);

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
                        doc.ExportCaption(Relationship);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(DateOfBirth);
                        doc.ExportCaption(MobileNumberCode_CountryID);
                        doc.ExportCaption(MobileNumber);
                        doc.ExportCaption(_Email);
                        doc.ExportCaption(SocialSecurityNumber);
                        doc.ExportCaption(FamilyRegisterNumber);
                        doc.ExportCaption(Address);
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(PassportValidUntil);
                        doc.ExportCaption(PassportPlaceIssued);
                        doc.ExportCaption(PassportDateIssued);
                        doc.ExportCaption(PassportNumber);
                        doc.ExportCaption(FirstName);
                        doc.ExportCaption(LastName);
                    } else {
                        doc.ExportCaption(MTCrewID);
                        doc.ExportCaption(Relationship);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(DateOfBirth);
                        doc.ExportCaption(MobileNumberCode_CountryID);
                        doc.ExportCaption(MobileNumber);
                        doc.ExportCaption(_Email);
                        doc.ExportCaption(SocialSecurityNumber);
                        doc.ExportCaption(FamilyRegisterNumber);
                        doc.ExportCaption(Address);
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(PassportValidUntil);
                        doc.ExportCaption(PassportPlaceIssued);
                        doc.ExportCaption(PassportDateIssued);
                        doc.ExportCaption(PassportNumber);
                        doc.ExportCaption(FirstName);
                        doc.ExportCaption(LastName);
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
                            await doc.ExportField(Relationship);
                            await doc.ExportField(FullName);
                            await doc.ExportField(Gender);
                            await doc.ExportField(DateOfBirth);
                            await doc.ExportField(MobileNumberCode_CountryID);
                            await doc.ExportField(MobileNumber);
                            await doc.ExportField(_Email);
                            await doc.ExportField(SocialSecurityNumber);
                            await doc.ExportField(FamilyRegisterNumber);
                            await doc.ExportField(Address);
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(PassportValidUntil);
                            await doc.ExportField(PassportPlaceIssued);
                            await doc.ExportField(PassportDateIssued);
                            await doc.ExportField(PassportNumber);
                            await doc.ExportField(FirstName);
                            await doc.ExportField(LastName);
                        } else {
                            await doc.ExportField(MTCrewID);
                            await doc.ExportField(Relationship);
                            await doc.ExportField(FullName);
                            await doc.ExportField(Gender);
                            await doc.ExportField(DateOfBirth);
                            await doc.ExportField(MobileNumberCode_CountryID);
                            await doc.ExportField(MobileNumber);
                            await doc.ExportField(_Email);
                            await doc.ExportField(SocialSecurityNumber);
                            await doc.ExportField(FamilyRegisterNumber);
                            await doc.ExportField(Address);
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(PassportValidUntil);
                            await doc.ExportField(PassportPlaceIssued);
                            await doc.ExportField(PassportDateIssued);
                            await doc.ExportField(PassportNumber);
                            await doc.ExportField(FirstName);
                            await doc.ExportField(LastName);
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
                    filterWrk = "[MTUserID] IN (" + filterWrk + ")";
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
            string sql = "SELECT " + masterfld.Expression + " FROM dbo.MTCrewFamily";
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

        // Add master User ID filter
        public string AddMasterUserIDFilter(string filter, string currentMasterTable)
        {
            string? filterWrk = filter;
            if (currentMasterTable == "MTCrew") {
                filterWrk = mtCrew?.AddUserIDFilter(filterWrk);
            }
            return filterWrk ?? "";
        }

        // Add detail User ID filter
        public string AddDetailUserIDFilter(string filter, string currentMasterTable)
        {
            string filterWrk = filter;
            if (currentMasterTable == "MTCrew") {
                if (mtCrew != null && !mtCrew.UserIDAllow())
                    AddFilter(ref filterWrk, mtCrew.GetUserIDSubquery(MTCrewID, mtCrew.ID));
            }
            return filterWrk;
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
            rsnew["CreatedByUserID"] = CurrentUserID();
            rsnew["CreatedDateTime"] = DateTimeOffset.Now;
            rsnew["LastUpdatedByUserID"] = CurrentUserID();
            rsnew["LastUpdatedDateTime"] = DateTimeOffset.Now;
            rsnew["MTUserID"] = CurrentUserID();
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
