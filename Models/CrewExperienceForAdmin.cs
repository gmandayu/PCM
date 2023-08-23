namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewExperienceForAdmin
    /// </summary>
    [MaybeNull]
    public static CrewExperienceForAdmin crewExperienceForAdmin
    {
        get => HttpData.Resolve<CrewExperienceForAdmin>("CrewExperienceForAdmin");
        set => HttpData["CrewExperienceForAdmin"] = value;
    }

    /// <summary>
    /// Table class for CrewExperienceForAdmin
    /// </summary>
    public class CrewExperienceForAdmin : DbTable, IQueryFactory
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

        public bool InlineDelete = true;

        public bool ModalGridAdd = false;

        public bool ModalGridEdit = false;

        public bool ModalMultiEdit = false;

        public readonly DbField<SqlDbType> ID;

        public readonly DbField<SqlDbType> MTCrewID;

        public readonly DbField<SqlDbType> CompanyName;

        public readonly DbField<SqlDbType> FlagName_CountryID;

        public readonly DbField<SqlDbType> VesselName;

        public readonly DbField<SqlDbType> MTVesselTypeID;

        public readonly DbField<SqlDbType> GRT;

        public readonly DbField<SqlDbType> DWT;

        public readonly DbField<SqlDbType> MainEngine;

        public readonly DbField<SqlDbType> BHP;

        public readonly DbField<SqlDbType> MTRankID;

        public readonly DbField<SqlDbType> DateFrom;

        public readonly DbField<SqlDbType> DateUntil;

        public readonly DbField<SqlDbType> ActiveDescription;

        public readonly DbField<SqlDbType> CreatedByUserID;

        public readonly DbField<SqlDbType> CreatedDateTime;

        public readonly DbField<SqlDbType> LastUpdatedByUserID;

        public readonly DbField<SqlDbType> LastUpdatedDateTime;

        public readonly DbField<SqlDbType> MTUserID;

        public readonly DbField<SqlDbType> SignOnPortName;

        public readonly DbField<SqlDbType> SignOffPortName;

        public readonly DbField<SqlDbType> SignOffReason;

        // Constructor
        public CrewExperienceForAdmin()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "CrewExperienceForAdmin";
            Name = "CrewExperienceForAdmin";
            Type = "CUSTOMVIEW";
            UpdateTable = "dbo.MTCrewExperience"; // Update Table
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
                Expression = "dbo.MTCrewExperience.ID",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.ID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.ID",
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
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ID", ID);

            // MTCrewID
            MTCrewID = new (this, "x_MTCrewID", 3, SqlDbType.Int) {
                Name = "MTCrewID",
                Expression = "dbo.MTCrewExperience.MTCrewID",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.MTCrewID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.MTCrewID",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "MTCrewID", "CustomMsg"),
                IsUpload = false
            };
            MTCrewID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MTCrewID", "MTCrew", true, "ID", new List<string> {"FirstName", "MiddleName", "LastName", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([FirstName],'" + ValueSeparator(1, MTCrewID) + "',[MiddleName],'" + ValueSeparator(2, MTCrewID) + "',[LastName])"),
                "id-ID" => new Lookup<DbField>("MTCrewID", "MTCrew", true, "ID", new List<string> {"FirstName", "MiddleName", "LastName", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([FirstName],'" + ValueSeparator(1, MTCrewID) + "',[MiddleName],'" + ValueSeparator(2, MTCrewID) + "',[LastName])"),
                _ => new Lookup<DbField>("MTCrewID", "MTCrew", true, "ID", new List<string> {"FirstName", "MiddleName", "LastName", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([FirstName],'" + ValueSeparator(1, MTCrewID) + "',[MiddleName],'" + ValueSeparator(2, MTCrewID) + "',[LastName])")
            };
            Fields.Add("MTCrewID", MTCrewID);

            // CompanyName
            CompanyName = new (this, "x_CompanyName", 202, SqlDbType.NVarChar) {
                Name = "CompanyName",
                Expression = "dbo.MTCrewExperience.CompanyName",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrewExperience.CompanyName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.CompanyName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "CompanyName", "CustomMsg"),
                IsUpload = false
            };
            CompanyName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CompanyName", "CrewExperienceForAdmin", true, "CompanyName", new List<string> {"CompanyName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CompanyName", "CrewExperienceForAdmin", true, "CompanyName", new List<string> {"CompanyName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CompanyName", "CrewExperienceForAdmin", true, "CompanyName", new List<string> {"CompanyName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CompanyName", CompanyName);

            // FlagName_CountryID
            FlagName_CountryID = new (this, "x_FlagName_CountryID", 3, SqlDbType.Int) {
                Name = "FlagName_CountryID",
                Expression = "dbo.MTCrewExperience.FlagName_CountryID",
                UseBasicSearch = true,
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.FlagName_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.FlagName_CountryID",
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
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "FlagName_CountryID", "CustomMsg"),
                IsUpload = false
            };
            FlagName_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FlagName_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("FlagName_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("FlagName_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("FlagName_CountryID", FlagName_CountryID);

            // VesselName
            VesselName = new (this, "x_VesselName", 202, SqlDbType.NVarChar) {
                Name = "VesselName",
                Expression = "dbo.MTCrewExperience.VesselName",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrewExperience.VesselName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.VesselName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "VesselName", "CustomMsg"),
                IsUpload = false
            };
            VesselName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("VesselName", "CrewExperienceForAdmin", true, "VesselName", new List<string> {"VesselName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("VesselName", "CrewExperienceForAdmin", true, "VesselName", new List<string> {"VesselName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("VesselName", "CrewExperienceForAdmin", true, "VesselName", new List<string> {"VesselName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("VesselName", VesselName);

            // MTVesselTypeID
            MTVesselTypeID = new (this, "x_MTVesselTypeID", 3, SqlDbType.Int) {
                Name = "MTVesselTypeID",
                Expression = "dbo.MTCrewExperience.MTVesselTypeID",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.MTVesselTypeID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.MTVesselTypeID",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "MTVesselTypeID", "CustomMsg"),
                IsUpload = false
            };
            MTVesselTypeID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MTVesselTypeID", "MTVesselType", true, "ID", new List<string> {"Abbreviation", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Abbreviation],'" + ValueSeparator(1, MTVesselTypeID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("MTVesselTypeID", "MTVesselType", true, "ID", new List<string> {"Abbreviation", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Abbreviation],'" + ValueSeparator(1, MTVesselTypeID) + "',[Name])"),
                _ => new Lookup<DbField>("MTVesselTypeID", "MTVesselType", true, "ID", new List<string> {"Abbreviation", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Abbreviation],'" + ValueSeparator(1, MTVesselTypeID) + "',[Name])")
            };
            Fields.Add("MTVesselTypeID", MTVesselTypeID);

            // GRT
            GRT = new (this, "x_GRT", 3, SqlDbType.Int) {
                Name = "GRT",
                Expression = "dbo.MTCrewExperience.GRT",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.GRT AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.GRT",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "GRT", "CustomMsg"),
                IsUpload = false
            };
            GRT.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("GRT", "CrewExperienceForAdmin", true, "GRT", new List<string> {"GRT", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("GRT", "CrewExperienceForAdmin", true, "GRT", new List<string> {"GRT", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("GRT", "CrewExperienceForAdmin", true, "GRT", new List<string> {"GRT", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("GRT", GRT);

            // DWT
            DWT = new (this, "x_DWT", 3, SqlDbType.Int) {
                Name = "DWT",
                Expression = "dbo.MTCrewExperience.DWT",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.DWT AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.DWT",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "DWT", "CustomMsg"),
                IsUpload = false
            };
            DWT.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("DWT", "CrewExperienceForAdmin", true, "DWT", new List<string> {"DWT", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("DWT", "CrewExperienceForAdmin", true, "DWT", new List<string> {"DWT", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("DWT", "CrewExperienceForAdmin", true, "DWT", new List<string> {"DWT", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("DWT", DWT);

            // MainEngine
            MainEngine = new (this, "x_MainEngine", 202, SqlDbType.NVarChar) {
                Name = "MainEngine",
                Expression = "dbo.MTCrewExperience.MainEngine",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrewExperience.MainEngine",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.MainEngine",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "MainEngine", "CustomMsg"),
                IsUpload = false
            };
            MainEngine.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MainEngine", "CrewExperienceForAdmin", true, "MainEngine", new List<string> {"MainEngine", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("MainEngine", "CrewExperienceForAdmin", true, "MainEngine", new List<string> {"MainEngine", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("MainEngine", "CrewExperienceForAdmin", true, "MainEngine", new List<string> {"MainEngine", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("MainEngine", MainEngine);

            // BHP
            BHP = new (this, "x_BHP", 3, SqlDbType.Int) {
                Name = "BHP",
                Expression = "dbo.MTCrewExperience.BHP",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.BHP AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.BHP",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "BHP", "CustomMsg"),
                IsUpload = false
            };
            BHP.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("BHP", "CrewExperienceForAdmin", true, "BHP", new List<string> {"BHP", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("BHP", "CrewExperienceForAdmin", true, "BHP", new List<string> {"BHP", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("BHP", "CrewExperienceForAdmin", true, "BHP", new List<string> {"BHP", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("BHP", BHP);

            // MTRankID
            MTRankID = new (this, "x_MTRankID", 3, SqlDbType.Int) {
                Name = "MTRankID",
                Expression = "dbo.MTCrewExperience.MTRankID",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.MTRankID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.MTRankID",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "MTRankID", "CustomMsg"),
                IsUpload = false
            };
            MTRankID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MTRankID", "MTRank", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("MTRankID", "MTRank", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("MTRankID", "MTRank", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("MTRankID", MTRankID);

            // DateFrom
            DateFrom = new (this, "x_DateFrom", 133, SqlDbType.Date) {
                Name = "DateFrom",
                Expression = "dbo.MTCrewExperience.DateFrom",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrewExperience.DateFrom", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.MTCrewExperience.DateFrom",
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
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "DateFrom", "CustomMsg"),
                IsUpload = false
            };
            DateFrom.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("DateFrom", "CrewExperienceForAdmin", true, "DateFrom", new List<string> {"DateFrom", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("DateFrom", "CrewExperienceForAdmin", true, "DateFrom", new List<string> {"DateFrom", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("DateFrom", "CrewExperienceForAdmin", true, "DateFrom", new List<string> {"DateFrom", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("DateFrom", DateFrom);

            // DateUntil
            DateUntil = new (this, "x_DateUntil", 133, SqlDbType.Date) {
                Name = "DateUntil",
                Expression = "dbo.MTCrewExperience.DateUntil",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrewExperience.DateUntil", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.MTCrewExperience.DateUntil",
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
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "DateUntil", "CustomMsg"),
                IsUpload = false
            };
            DateUntil.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("DateUntil", "CrewExperienceForAdmin", true, "DateUntil", new List<string> {"DateUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("DateUntil", "CrewExperienceForAdmin", true, "DateUntil", new List<string> {"DateUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("DateUntil", "CrewExperienceForAdmin", true, "DateUntil", new List<string> {"DateUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("DateUntil", DateUntil);

            // ActiveDescription
            ActiveDescription = new (this, "x_ActiveDescription", 202, SqlDbType.NVarChar) {
                Name = "ActiveDescription",
                Expression = "dbo.MTCrewExperience.ActiveDescription",
                BasicSearchExpression = "dbo.MTCrewExperience.ActiveDescription",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.ActiveDescription",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "ActiveDescription", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ActiveDescription", ActiveDescription);

            // CreatedByUserID
            CreatedByUserID = new (this, "x_CreatedByUserID", 3, SqlDbType.Int) {
                Name = "CreatedByUserID",
                Expression = "dbo.MTCrewExperience.CreatedByUserID",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.CreatedByUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.CreatedByUserID",
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
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "CreatedByUserID", "CustomMsg"),
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
                Expression = "dbo.MTCrewExperience.CreatedDateTime",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrewExperience.CreatedDateTime", 1, "DB"),
                DateTimeFormat = 1,
                VirtualExpression = "dbo.MTCrewExperience.CreatedDateTime",
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
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "CreatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            CreatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedDateTime", "CrewExperienceForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CreatedDateTime", "CrewExperienceForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CreatedDateTime", "CrewExperienceForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CreatedDateTime", CreatedDateTime);

            // LastUpdatedByUserID
            LastUpdatedByUserID = new (this, "x_LastUpdatedByUserID", 3, SqlDbType.Int) {
                Name = "LastUpdatedByUserID",
                Expression = "dbo.MTCrewExperience.LastUpdatedByUserID",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.LastUpdatedByUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.LastUpdatedByUserID",
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
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "LastUpdatedByUserID", "CustomMsg"),
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
                Expression = "dbo.MTCrewExperience.LastUpdatedDateTime",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrewExperience.LastUpdatedDateTime", 1, "DB"),
                DateTimeFormat = 1,
                VirtualExpression = "dbo.MTCrewExperience.LastUpdatedDateTime",
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
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "LastUpdatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedDateTime", "CrewExperienceForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedDateTime", "CrewExperienceForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedDateTime", "CrewExperienceForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("LastUpdatedDateTime", LastUpdatedDateTime);

            // MTUserID
            MTUserID = new (this, "x_MTUserID", 3, SqlDbType.Int) {
                Name = "MTUserID",
                Expression = "dbo.MTCrewExperience.MTUserID",
                BasicSearchExpression = "CAST(dbo.MTCrewExperience.MTUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.MTUserID",
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
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "MTUserID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MTUserID", MTUserID);

            // SignOnPortName
            SignOnPortName = new (this, "x_SignOnPortName", 202, SqlDbType.NVarChar) {
                Name = "SignOnPortName",
                Expression = "dbo.MTCrewExperience.SignOnPortName",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrewExperience.SignOnPortName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.SignOnPortName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "SignOnPortName", "CustomMsg"),
                IsUpload = false
            };
            SignOnPortName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("SignOnPortName", "CrewExperienceForAdmin", true, "SignOnPortName", new List<string> {"SignOnPortName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("SignOnPortName", "CrewExperienceForAdmin", true, "SignOnPortName", new List<string> {"SignOnPortName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("SignOnPortName", "CrewExperienceForAdmin", true, "SignOnPortName", new List<string> {"SignOnPortName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("SignOnPortName", SignOnPortName);

            // SignOffPortName
            SignOffPortName = new (this, "x_SignOffPortName", 202, SqlDbType.NVarChar) {
                Name = "SignOffPortName",
                Expression = "dbo.MTCrewExperience.SignOffPortName",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrewExperience.SignOffPortName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.SignOffPortName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "SignOffPortName", "CustomMsg"),
                IsUpload = false
            };
            SignOffPortName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("SignOffPortName", "CrewExperienceForAdmin", true, "SignOffPortName", new List<string> {"SignOffPortName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("SignOffPortName", "CrewExperienceForAdmin", true, "SignOffPortName", new List<string> {"SignOffPortName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("SignOffPortName", "CrewExperienceForAdmin", true, "SignOffPortName", new List<string> {"SignOffPortName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("SignOffPortName", SignOffPortName);

            // SignOffReason
            SignOffReason = new (this, "x_SignOffReason", 202, SqlDbType.NVarChar) {
                Name = "SignOffReason",
                Expression = "dbo.MTCrewExperience.SignOffReason",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrewExperience.SignOffReason",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewExperience.SignOffReason",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewExperienceForAdmin", "SignOffReason", "CustomMsg"),
                IsUpload = false
            };
            SignOffReason.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("SignOffReason", "CrewExperienceForAdmin", true, "SignOffReason", new List<string> {"SignOffReason", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("SignOffReason", "CrewExperienceForAdmin", true, "SignOffReason", new List<string> {"SignOffReason", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("SignOffReason", "CrewExperienceForAdmin", true, "SignOffReason", new List<string> {"SignOffReason", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("SignOffReason", SignOffReason);

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
            get => _sqlFrom ?? "dbo.MTCrewExperience";
            set => _sqlFrom = value;
        }

        // SELECT
        private string? _sqlSelect = null;

        public string SqlSelect { // Select
            get => _sqlSelect ?? "SELECT dbo.MTCrewExperience.ID, dbo.MTCrewExperience.MTCrewID, dbo.MTCrewExperience.CompanyName, dbo.MTCrewExperience.FlagName_CountryID, dbo.MTCrewExperience.VesselName, dbo.MTCrewExperience.MTVesselTypeID, dbo.MTCrewExperience.GRT, dbo.MTCrewExperience.DWT, dbo.MTCrewExperience.MainEngine, dbo.MTCrewExperience.BHP, dbo.MTCrewExperience.MTRankID, dbo.MTCrewExperience.DateFrom, dbo.MTCrewExperience.DateUntil, dbo.MTCrewExperience.ActiveDescription, dbo.MTCrewExperience.CreatedByUserID, dbo.MTCrewExperience.CreatedDateTime, dbo.MTCrewExperience.LastUpdatedByUserID, dbo.MTCrewExperience.LastUpdatedDateTime, dbo.MTCrewExperience.MTUserID, dbo.MTCrewExperience.SignOnPortName, dbo.MTCrewExperience.SignOffPortName, dbo.MTCrewExperience.SignOffReason FROM " + SqlFrom;
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
                CompanyName.DbValue = row["CompanyName"]; // Set DB value only
                FlagName_CountryID.DbValue = row["FlagName_CountryID"]; // Set DB value only
                VesselName.DbValue = row["VesselName"]; // Set DB value only
                MTVesselTypeID.DbValue = row["MTVesselTypeID"]; // Set DB value only
                GRT.DbValue = row["GRT"]; // Set DB value only
                DWT.DbValue = row["DWT"]; // Set DB value only
                MainEngine.DbValue = row["MainEngine"]; // Set DB value only
                BHP.DbValue = row["BHP"]; // Set DB value only
                MTRankID.DbValue = row["MTRankID"]; // Set DB value only
                DateFrom.DbValue = row["DateFrom"]; // Set DB value only
                DateUntil.DbValue = row["DateUntil"]; // Set DB value only
                ActiveDescription.DbValue = row["ActiveDescription"]; // Set DB value only
                CreatedByUserID.DbValue = row["CreatedByUserID"]; // Set DB value only
                CreatedDateTime.DbValue = row["CreatedDateTime"]; // Set DB value only
                LastUpdatedByUserID.DbValue = row["LastUpdatedByUserID"]; // Set DB value only
                LastUpdatedDateTime.DbValue = row["LastUpdatedDateTime"]; // Set DB value only
                MTUserID.DbValue = row["MTUserID"]; // Set DB value only
                SignOnPortName.DbValue = row["SignOnPortName"]; // Set DB value only
                SignOffPortName.DbValue = row["SignOffPortName"]; // Set DB value only
                SignOffReason.DbValue = row["SignOffReason"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "dbo.MTCrewExperience.ID = @ID@";

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
                    return "CrewExperienceForAdminList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "CrewExperienceForAdminView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "CrewExperienceForAdminEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "CrewExperienceForAdminAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "CrewExperienceForAdminList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "CrewExperienceForAdminView",
                Config.ApiAddAction => "CrewExperienceForAdminAdd",
                Config.ApiEditAction => "CrewExperienceForAdminEdit",
                Config.ApiDeleteAction => "CrewExperienceForAdminDelete",
                Config.ApiListAction => "CrewExperienceForAdminList",
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
        public string ListUrl => "CrewExperienceForAdminList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("CrewExperienceForAdminView", parm);
            else
                url = KeyUrl("CrewExperienceForAdminView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "CrewExperienceForAdminAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "CrewExperienceForAdminAdd?" + parm;
            else
                url = "CrewExperienceForAdminAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("CrewExperienceForAdminEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewExperienceForAdminList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("CrewExperienceForAdminAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewExperienceForAdminList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("CrewExperienceForAdminDelete")); // DN

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
            CompanyName.SetDbValue(dr["CompanyName"]);
            FlagName_CountryID.SetDbValue(dr["FlagName_CountryID"]);
            VesselName.SetDbValue(dr["VesselName"]);
            MTVesselTypeID.SetDbValue(dr["MTVesselTypeID"]);
            GRT.SetDbValue(dr["GRT"]);
            DWT.SetDbValue(dr["DWT"]);
            MainEngine.SetDbValue(dr["MainEngine"]);
            BHP.SetDbValue(dr["BHP"]);
            MTRankID.SetDbValue(dr["MTRankID"]);
            DateFrom.SetDbValue(dr["DateFrom"]);
            DateUntil.SetDbValue(dr["DateUntil"]);
            ActiveDescription.SetDbValue(dr["ActiveDescription"]);
            CreatedByUserID.SetDbValue(dr["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(dr["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(dr["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(dr["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(dr["MTUserID"]);
            SignOnPortName.SetDbValue(dr["SignOnPortName"]);
            SignOffPortName.SetDbValue(dr["SignOffPortName"]);
            SignOffReason.SetDbValue(dr["SignOffReason"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "CrewExperienceForAdminList";
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

            // CompanyName
            CompanyName.CellCssStyle = "white-space: nowrap;";

            // FlagName_CountryID
            FlagName_CountryID.CellCssStyle = "white-space: nowrap;";

            // VesselName
            VesselName.CellCssStyle = "white-space: nowrap;";

            // MTVesselTypeID
            MTVesselTypeID.CellCssStyle = "white-space: nowrap;";

            // GRT
            GRT.CellCssStyle = "white-space: nowrap;";

            // DWT
            DWT.CellCssStyle = "white-space: nowrap;";

            // MainEngine
            MainEngine.CellCssStyle = "white-space: nowrap;";

            // BHP
            BHP.CellCssStyle = "white-space: nowrap;";

            // MTRankID
            MTRankID.CellCssStyle = "white-space: nowrap;";

            // DateFrom
            DateFrom.CellCssStyle = "white-space: nowrap;";

            // DateUntil
            DateUntil.CellCssStyle = "white-space: nowrap;";

            // ActiveDescription
            ActiveDescription.CellCssStyle = "white-space: nowrap;";

            // CreatedByUserID
            CreatedByUserID.CellCssStyle = "white-space: nowrap;";

            // CreatedDateTime
            CreatedDateTime.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedByUserID
            LastUpdatedByUserID.CellCssStyle = "white-space: nowrap;";

            // LastUpdatedDateTime
            LastUpdatedDateTime.CellCssStyle = "white-space: nowrap;";

            // MTUserID
            MTUserID.CellCssStyle = "white-space: nowrap;";

            // SignOnPortName
            SignOnPortName.CellCssStyle = "white-space: nowrap;";

            // SignOffPortName
            SignOffPortName.CellCssStyle = "white-space: nowrap;";

            // SignOffReason
            SignOffReason.CellCssStyle = "white-space: nowrap;";

            // ID
            ID.ViewValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

            // MTCrewID
            MTCrewID.ViewValue = MTCrewID.CurrentValue;
            MTCrewID.ViewValue = FormatNumber(MTCrewID.ViewValue, MTCrewID.FormatPattern);
            MTCrewID.ViewCustomAttributes = "";

            // CompanyName
            CompanyName.ViewValue = ConvertToString(CompanyName.CurrentValue); // DN
            CompanyName.ViewCustomAttributes = "";

            // FlagName_CountryID
            curVal = ConvertToString(FlagName_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (FlagName_CountryID.Lookup != null && IsDictionary(FlagName_CountryID.Lookup?.Options) && FlagName_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    FlagName_CountryID.ViewValue = FlagName_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", FlagName_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = FlagName_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && FlagName_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = FlagName_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        FlagName_CountryID.ViewValue = FlagName_CountryID.HighlightLookup(ConvertToString(rswrk[0]), FlagName_CountryID.DisplayValue(listwrk));
                    } else {
                        FlagName_CountryID.ViewValue = FormatNumber(FlagName_CountryID.CurrentValue, FlagName_CountryID.FormatPattern);
                    }
                }
            } else {
                FlagName_CountryID.ViewValue = DbNullValue;
            }
            FlagName_CountryID.ViewCustomAttributes = "";

            // VesselName
            VesselName.ViewValue = ConvertToString(VesselName.CurrentValue); // DN
            VesselName.ViewCustomAttributes = "";

            // MTVesselTypeID
            curVal = ConvertToString(MTVesselTypeID.CurrentValue);
            if (!Empty(curVal)) {
                if (MTVesselTypeID.Lookup != null && IsDictionary(MTVesselTypeID.Lookup?.Options) && MTVesselTypeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTVesselTypeID.ViewValue = MTVesselTypeID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", MTVesselTypeID.CurrentValue, DataType.Number, "");
                    sqlWrk = MTVesselTypeID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && MTVesselTypeID.Lookup != null) { // Lookup values found
                        var listwrk = MTVesselTypeID.Lookup?.RenderViewRow(rswrk[0]);
                        MTVesselTypeID.ViewValue = MTVesselTypeID.HighlightLookup(ConvertToString(rswrk[0]), MTVesselTypeID.DisplayValue(listwrk));
                    } else {
                        MTVesselTypeID.ViewValue = FormatNumber(MTVesselTypeID.CurrentValue, MTVesselTypeID.FormatPattern);
                    }
                }
            } else {
                MTVesselTypeID.ViewValue = DbNullValue;
            }
            MTVesselTypeID.ViewCustomAttributes = "";

            // GRT
            GRT.ViewValue = GRT.CurrentValue;
            GRT.ViewCustomAttributes = "";

            // DWT
            DWT.ViewValue = DWT.CurrentValue;
            DWT.ViewCustomAttributes = "";

            // MainEngine
            MainEngine.ViewValue = ConvertToString(MainEngine.CurrentValue); // DN
            MainEngine.ViewCustomAttributes = "";

            // BHP
            BHP.ViewValue = BHP.CurrentValue;
            BHP.ViewCustomAttributes = "";

            // MTRankID
            curVal = ConvertToString(MTRankID.CurrentValue);
            if (!Empty(curVal)) {
                if (MTRankID.Lookup != null && IsDictionary(MTRankID.Lookup?.Options) && MTRankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MTRankID.ViewValue = MTRankID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", MTRankID.CurrentValue, DataType.Number, "");
                    sqlWrk = MTRankID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && MTRankID.Lookup != null) { // Lookup values found
                        var listwrk = MTRankID.Lookup?.RenderViewRow(rswrk[0]);
                        MTRankID.ViewValue = MTRankID.HighlightLookup(ConvertToString(rswrk[0]), MTRankID.DisplayValue(listwrk));
                    } else {
                        MTRankID.ViewValue = FormatNumber(MTRankID.CurrentValue, MTRankID.FormatPattern);
                    }
                }
            } else {
                MTRankID.ViewValue = DbNullValue;
            }
            MTRankID.ViewCustomAttributes = "";

            // DateFrom
            DateFrom.ViewValue = DateFrom.CurrentValue;
            DateFrom.ViewValue = FormatDateTime(DateFrom.ViewValue, DateFrom.FormatPattern);
            DateFrom.ViewCustomAttributes = "";

            // DateUntil
            DateUntil.ViewValue = DateUntil.CurrentValue;
            DateUntil.ViewValue = FormatDateTime(DateUntil.ViewValue, DateUntil.FormatPattern);
            DateUntil.ViewCustomAttributes = "";

            // ActiveDescription
            ActiveDescription.ViewValue = ConvertToString(ActiveDescription.CurrentValue); // DN
            ActiveDescription.ViewCustomAttributes = "";

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

            // MTUserID
            MTUserID.ViewValue = MTUserID.CurrentValue;
            MTUserID.ViewValue = FormatNumber(MTUserID.ViewValue, MTUserID.FormatPattern);
            MTUserID.ViewCustomAttributes = "";

            // SignOnPortName
            SignOnPortName.ViewValue = ConvertToString(SignOnPortName.CurrentValue); // DN
            SignOnPortName.ViewCustomAttributes = "";

            // SignOffPortName
            SignOffPortName.ViewValue = ConvertToString(SignOffPortName.CurrentValue); // DN
            SignOffPortName.ViewCustomAttributes = "";

            // SignOffReason
            SignOffReason.ViewValue = SignOffReason.CurrentValue;
            SignOffReason.ViewCustomAttributes = "";

            // ID
            ID.HrefValue = "";
            ID.TooltipValue = "";

            // MTCrewID
            MTCrewID.HrefValue = "";
            MTCrewID.TooltipValue = "";

            // CompanyName
            CompanyName.HrefValue = "";
            CompanyName.TooltipValue = "";

            // FlagName_CountryID
            FlagName_CountryID.HrefValue = "";
            FlagName_CountryID.TooltipValue = "";

            // VesselName
            VesselName.HrefValue = "";
            VesselName.TooltipValue = "";

            // MTVesselTypeID
            MTVesselTypeID.HrefValue = "";
            MTVesselTypeID.TooltipValue = "";

            // GRT
            GRT.HrefValue = "";
            GRT.TooltipValue = "";

            // DWT
            DWT.HrefValue = "";
            DWT.TooltipValue = "";

            // MainEngine
            MainEngine.HrefValue = "";
            MainEngine.TooltipValue = "";

            // BHP
            BHP.HrefValue = "";
            BHP.TooltipValue = "";

            // MTRankID
            MTRankID.HrefValue = "";
            MTRankID.TooltipValue = "";

            // DateFrom
            DateFrom.HrefValue = "";
            DateFrom.TooltipValue = "";

            // DateUntil
            DateUntil.HrefValue = "";
            DateUntil.TooltipValue = "";

            // ActiveDescription
            ActiveDescription.HrefValue = "";
            ActiveDescription.TooltipValue = "";

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

            // MTUserID
            MTUserID.HrefValue = "";
            MTUserID.TooltipValue = "";

            // SignOnPortName
            SignOnPortName.HrefValue = "";
            SignOnPortName.TooltipValue = "";

            // SignOffPortName
            SignOffPortName.HrefValue = "";
            SignOffPortName.TooltipValue = "";

            // SignOffReason
            SignOffReason.HrefValue = "";
            SignOffReason.TooltipValue = "";

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

            // CompanyName
            CompanyName.SetupEditAttributes();
            if (!CompanyName.Raw)
                CompanyName.CurrentValue = HtmlDecode(CompanyName.CurrentValue);
            CompanyName.EditValue = HtmlEncode(CompanyName.CurrentValue);
            CompanyName.PlaceHolder = RemoveHtml(CompanyName.Caption);

            // FlagName_CountryID
            FlagName_CountryID.SetupEditAttributes();
            curVal = ConvertToString(FlagName_CountryID.CurrentValue)?.Trim() ?? "";
            if (FlagName_CountryID.Lookup != null && IsDictionary(FlagName_CountryID.Lookup?.Options) && FlagName_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                FlagName_CountryID.EditValue = FlagName_CountryID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = FlagName_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                FlagName_CountryID.EditValue = rswrk;
            }
            FlagName_CountryID.PlaceHolder = RemoveHtml(FlagName_CountryID.Caption);
            if (!Empty(FlagName_CountryID.EditValue) && IsNumeric(FlagName_CountryID.EditValue))
                FlagName_CountryID.EditValue = FormatNumber(FlagName_CountryID.EditValue, null);

            // VesselName
            VesselName.SetupEditAttributes();
            if (!VesselName.Raw)
                VesselName.CurrentValue = HtmlDecode(VesselName.CurrentValue);
            VesselName.EditValue = HtmlEncode(VesselName.CurrentValue);
            VesselName.PlaceHolder = RemoveHtml(VesselName.Caption);

            // MTVesselTypeID
            MTVesselTypeID.SetupEditAttributes();
            curVal = ConvertToString(MTVesselTypeID.CurrentValue)?.Trim() ?? "";
            if (MTVesselTypeID.Lookup != null && IsDictionary(MTVesselTypeID.Lookup?.Options) && MTVesselTypeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                MTVesselTypeID.EditValue = MTVesselTypeID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = MTVesselTypeID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                MTVesselTypeID.EditValue = rswrk;
            }
            MTVesselTypeID.PlaceHolder = RemoveHtml(MTVesselTypeID.Caption);
            if (!Empty(MTVesselTypeID.EditValue) && IsNumeric(MTVesselTypeID.EditValue))
                MTVesselTypeID.EditValue = FormatNumber(MTVesselTypeID.EditValue, null);

            // GRT
            GRT.SetupEditAttributes();
            GRT.EditValue = GRT.CurrentValue; // DN
            GRT.PlaceHolder = RemoveHtml(GRT.Caption);

            // DWT
            DWT.SetupEditAttributes();
            DWT.EditValue = DWT.CurrentValue; // DN
            DWT.PlaceHolder = RemoveHtml(DWT.Caption);

            // MainEngine
            MainEngine.SetupEditAttributes();
            if (!MainEngine.Raw)
                MainEngine.CurrentValue = HtmlDecode(MainEngine.CurrentValue);
            MainEngine.EditValue = HtmlEncode(MainEngine.CurrentValue);
            MainEngine.PlaceHolder = RemoveHtml(MainEngine.Caption);

            // BHP
            BHP.SetupEditAttributes();
            BHP.EditValue = BHP.CurrentValue; // DN
            BHP.PlaceHolder = RemoveHtml(BHP.Caption);

            // MTRankID
            MTRankID.SetupEditAttributes();
            curVal = ConvertToString(MTRankID.CurrentValue)?.Trim() ?? "";
            if (MTRankID.Lookup != null && IsDictionary(MTRankID.Lookup?.Options) && MTRankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                MTRankID.EditValue = MTRankID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = MTRankID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                MTRankID.EditValue = rswrk;
            }
            MTRankID.PlaceHolder = RemoveHtml(MTRankID.Caption);
            if (!Empty(MTRankID.EditValue) && IsNumeric(MTRankID.EditValue))
                MTRankID.EditValue = FormatNumber(MTRankID.EditValue, null);

            // DateFrom
            DateFrom.SetupEditAttributes();
            DateFrom.EditValue = FormatDateTime(DateFrom.CurrentValue, DateFrom.FormatPattern); // DN
            DateFrom.PlaceHolder = RemoveHtml(DateFrom.Caption);

            // DateUntil
            DateUntil.SetupEditAttributes();
            DateUntil.EditValue = FormatDateTime(DateUntil.CurrentValue, DateUntil.FormatPattern); // DN
            DateUntil.PlaceHolder = RemoveHtml(DateUntil.Caption);

            // ActiveDescription
            ActiveDescription.SetupEditAttributes();
            if (!ActiveDescription.Raw)
                ActiveDescription.CurrentValue = HtmlDecode(ActiveDescription.CurrentValue);
            ActiveDescription.EditValue = HtmlEncode(ActiveDescription.CurrentValue);
            ActiveDescription.PlaceHolder = RemoveHtml(ActiveDescription.Caption);

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

            // SignOnPortName
            SignOnPortName.SetupEditAttributes();
            if (!SignOnPortName.Raw)
                SignOnPortName.CurrentValue = HtmlDecode(SignOnPortName.CurrentValue);
            SignOnPortName.EditValue = HtmlEncode(SignOnPortName.CurrentValue);
            SignOnPortName.PlaceHolder = RemoveHtml(SignOnPortName.Caption);

            // SignOffPortName
            SignOffPortName.SetupEditAttributes();
            if (!SignOffPortName.Raw)
                SignOffPortName.CurrentValue = HtmlDecode(SignOffPortName.CurrentValue);
            SignOffPortName.EditValue = HtmlEncode(SignOffPortName.CurrentValue);
            SignOffPortName.PlaceHolder = RemoveHtml(SignOffPortName.Caption);

            // SignOffReason
            SignOffReason.SetupEditAttributes();
            SignOffReason.EditValue = SignOffReason.CurrentValue; // DN
            SignOffReason.PlaceHolder = RemoveHtml(SignOffReason.Caption);

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
                        doc.ExportCaption(CompanyName);
                        doc.ExportCaption(FlagName_CountryID);
                        doc.ExportCaption(VesselName);
                        doc.ExportCaption(MTVesselTypeID);
                        doc.ExportCaption(GRT);
                        doc.ExportCaption(DWT);
                        doc.ExportCaption(MainEngine);
                        doc.ExportCaption(BHP);
                        doc.ExportCaption(MTRankID);
                        doc.ExportCaption(DateFrom);
                        doc.ExportCaption(DateUntil);
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(SignOnPortName);
                        doc.ExportCaption(SignOffPortName);
                        doc.ExportCaption(SignOffReason);
                    } else {
                        doc.ExportCaption(MTCrewID);
                        doc.ExportCaption(CompanyName);
                        doc.ExportCaption(FlagName_CountryID);
                        doc.ExportCaption(VesselName);
                        doc.ExportCaption(MTVesselTypeID);
                        doc.ExportCaption(GRT);
                        doc.ExportCaption(DWT);
                        doc.ExportCaption(MainEngine);
                        doc.ExportCaption(BHP);
                        doc.ExportCaption(MTRankID);
                        doc.ExportCaption(DateFrom);
                        doc.ExportCaption(DateUntil);
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(SignOnPortName);
                        doc.ExportCaption(SignOffPortName);
                        doc.ExportCaption(SignOffReason);
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
                            await doc.ExportField(CompanyName);
                            await doc.ExportField(FlagName_CountryID);
                            await doc.ExportField(VesselName);
                            await doc.ExportField(MTVesselTypeID);
                            await doc.ExportField(GRT);
                            await doc.ExportField(DWT);
                            await doc.ExportField(MainEngine);
                            await doc.ExportField(BHP);
                            await doc.ExportField(MTRankID);
                            await doc.ExportField(DateFrom);
                            await doc.ExportField(DateUntil);
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(SignOnPortName);
                            await doc.ExportField(SignOffPortName);
                            await doc.ExportField(SignOffReason);
                        } else {
                            await doc.ExportField(MTCrewID);
                            await doc.ExportField(CompanyName);
                            await doc.ExportField(FlagName_CountryID);
                            await doc.ExportField(VesselName);
                            await doc.ExportField(MTVesselTypeID);
                            await doc.ExportField(GRT);
                            await doc.ExportField(DWT);
                            await doc.ExportField(MainEngine);
                            await doc.ExportField(BHP);
                            await doc.ExportField(MTRankID);
                            await doc.ExportField(DateFrom);
                            await doc.ExportField(DateUntil);
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(SignOnPortName);
                            await doc.ExportField(SignOffPortName);
                            await doc.ExportField(SignOffReason);
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
                    filterWrk = "dbo.MTCrewExperience.MTUserID IN (" + filterWrk + ")";
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
            string sql = "SELECT " + masterfld.Expression + " FROM dbo.MTCrewExperience";
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
            rsnew["CreatedByUserID"] = CurrentUserID();
            rsnew["CreatedDateTime"] = DateTimeOffset.Now;
            rsnew["LastUpdatedByUserID"] = CurrentUserID();
            rsnew["LastUpdatedDateTime"] = DateTimeOffset.Now;
            if (CurrentUserLevel() == "-1") // Admin
            {
                dynamic crewQueryResult = QueryBuilder("MTCrew").Where("ID", rsnew["MTCrewID"].ToString()).Select("MTUserID").FirstOrDefault();
                if ((object) crewQueryResult != null)
                {
                    rsnew["MTUserID"] = crewQueryResult.MTUserID.ToString();
                }    
            }
            else
            {
                rsnew["MTUserID"] = CurrentUserID();
            }
            return true;
        }
        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            //Log("Row Inserted");
            Session.SetInt("lastAddedExperienceCrewID", ConvertToInt(rsnew["MTCrewID"]));
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
            Session.SetInt("lastUpdatedExperienceCrewID", ConvertToInt(rsnew["MTCrewID"]));
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
