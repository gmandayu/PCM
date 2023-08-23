namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewDocumentForAdmin
    /// </summary>
    [MaybeNull]
    public static CrewDocumentForAdmin crewDocumentForAdmin
    {
        get => HttpData.Resolve<CrewDocumentForAdmin>("CrewDocumentForAdmin");
        set => HttpData["CrewDocumentForAdmin"] = value;
    }

    /// <summary>
    /// Table class for CrewDocumentForAdmin
    /// </summary>
    public class CrewDocumentForAdmin : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> MTDocumentID;

        public readonly DbField<SqlDbType> Number;

        public readonly DbField<SqlDbType> CountryOfIssue_CountryID;

        public readonly DbField<SqlDbType> DateOfIssue;

        public readonly DbField<SqlDbType> PlaceOfIssue;

        public readonly DbField<SqlDbType> DateValidUntil;

        public readonly DbField<SqlDbType> Image;

        public readonly DbField<SqlDbType> ActiveDescription;

        public readonly DbField<SqlDbType> CreatedByUserID;

        public readonly DbField<SqlDbType> CreatedDateTime;

        public readonly DbField<SqlDbType> LastUpdatedByUserID;

        public readonly DbField<SqlDbType> LastUpdatedDateTime;

        public readonly DbField<SqlDbType> MTUserID;

        public readonly DbField<SqlDbType> IsDraft;

        // Constructor
        public CrewDocumentForAdmin()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "CrewDocumentForAdmin";
            Name = "CrewDocumentForAdmin";
            Type = "CUSTOMVIEW";
            UpdateTable = "dbo.MTCrewDocument"; // Update Table
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
                Expression = "dbo.MTCrewDocument.ID",
                BasicSearchExpression = "CAST(dbo.MTCrewDocument.ID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.ID",
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
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ID", ID);

            // MTCrewID
            MTCrewID = new (this, "x_MTCrewID", 3, SqlDbType.Int) {
                Name = "MTCrewID",
                Expression = "dbo.MTCrewDocument.MTCrewID",
                BasicSearchExpression = "CAST(dbo.MTCrewDocument.MTCrewID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.MTCrewID",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "MTCrewID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MTCrewID", MTCrewID);

            // MTDocumentID
            MTDocumentID = new (this, "x_MTDocumentID", 3, SqlDbType.Int) {
                Name = "MTDocumentID",
                Expression = "dbo.MTCrewDocument.MTDocumentID",
                BasicSearchExpression = "CAST(dbo.MTCrewDocument.MTDocumentID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.MTDocumentID",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "MTDocumentID", "CustomMsg"),
                IsUpload = false
            };
            MTDocumentID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MTDocumentID", "MTDocument", true, "ID", new List<string> {"Type", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Type]"),
                "id-ID" => new Lookup<DbField>("MTDocumentID", "MTDocument", true, "ID", new List<string> {"Type", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Type]"),
                _ => new Lookup<DbField>("MTDocumentID", "MTDocument", true, "ID", new List<string> {"Type", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Type]")
            };
            Fields.Add("MTDocumentID", MTDocumentID);

            // Number
            Number = new (this, "x_Number", 202, SqlDbType.NVarChar) {
                Name = "Number",
                Expression = "dbo.MTCrewDocument.Number",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrewDocument.Number",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.Number",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "Number", "CustomMsg"),
                IsUpload = false
            };
            Number.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Number", "CrewDocumentForAdmin", true, "Number", new List<string> {"Number", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Number", "CrewDocumentForAdmin", true, "Number", new List<string> {"Number", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Number", "CrewDocumentForAdmin", true, "Number", new List<string> {"Number", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Number", Number);

            // CountryOfIssue_CountryID
            CountryOfIssue_CountryID = new (this, "x_CountryOfIssue_CountryID", 3, SqlDbType.Int) {
                Name = "CountryOfIssue_CountryID",
                Expression = "dbo.MTCrewDocument.CountryOfIssue_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrewDocument.CountryOfIssue_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.CountryOfIssue_CountryID",
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
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "CountryOfIssue_CountryID", "CustomMsg"),
                IsUpload = false
            };
            CountryOfIssue_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CountryOfIssue_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("CountryOfIssue_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("CountryOfIssue_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("CountryOfIssue_CountryID", CountryOfIssue_CountryID);

            // DateOfIssue
            DateOfIssue = new (this, "x_DateOfIssue", 133, SqlDbType.Date) {
                Name = "DateOfIssue",
                Expression = "dbo.MTCrewDocument.DateOfIssue",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrewDocument.DateOfIssue", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.MTCrewDocument.DateOfIssue",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                ImageResize = true,
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "DateOfIssue", "CustomMsg"),
                IsUpload = false
            };
            DateOfIssue.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("DateOfIssue", "CrewDocumentForAdmin", true, "DateOfIssue", new List<string> {"DateOfIssue", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("DateOfIssue", "CrewDocumentForAdmin", true, "DateOfIssue", new List<string> {"DateOfIssue", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("DateOfIssue", "CrewDocumentForAdmin", true, "DateOfIssue", new List<string> {"DateOfIssue", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("DateOfIssue", DateOfIssue);

            // PlaceOfIssue
            PlaceOfIssue = new (this, "x_PlaceOfIssue", 202, SqlDbType.NVarChar) {
                Name = "PlaceOfIssue",
                Expression = "dbo.MTCrewDocument.PlaceOfIssue",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrewDocument.PlaceOfIssue",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.PlaceOfIssue",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "PlaceOfIssue", "CustomMsg"),
                IsUpload = false
            };
            PlaceOfIssue.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("PlaceOfIssue", "CrewDocumentForAdmin", true, "PlaceOfIssue", new List<string> {"PlaceOfIssue", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("PlaceOfIssue", "CrewDocumentForAdmin", true, "PlaceOfIssue", new List<string> {"PlaceOfIssue", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("PlaceOfIssue", "CrewDocumentForAdmin", true, "PlaceOfIssue", new List<string> {"PlaceOfIssue", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("PlaceOfIssue", PlaceOfIssue);

            // DateValidUntil
            DateValidUntil = new (this, "x_DateValidUntil", 133, SqlDbType.Date) {
                Name = "DateValidUntil",
                Expression = "dbo.MTCrewDocument.DateValidUntil",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrewDocument.DateValidUntil", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.MTCrewDocument.DateValidUntil",
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
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "DateValidUntil", "CustomMsg"),
                IsUpload = false
            };
            DateValidUntil.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("DateValidUntil", "CrewDocumentForAdmin", true, "DateValidUntil", new List<string> {"DateValidUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("DateValidUntil", "CrewDocumentForAdmin", true, "DateValidUntil", new List<string> {"DateValidUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("DateValidUntil", "CrewDocumentForAdmin", true, "DateValidUntil", new List<string> {"DateValidUntil", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("DateValidUntil", DateValidUntil);

            // Image
            Image = new (this, "x_Image", 202, SqlDbType.NVarChar) {
                Name = "Image",
                Expression = "dbo.MTCrewDocument.Image",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrewDocument.Image",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.Image",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "IMAGE",
                HtmlTag = "FILE",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                ImageResize = true,
                UploadAllowedFileExtensions = "jpg,jpeg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "Image", "CustomMsg"),
                IsUpload = true
            };
            Image.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Image", "CrewDocumentForAdmin", true, "Image", new List<string> {"Image", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Image", "CrewDocumentForAdmin", true, "Image", new List<string> {"Image", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Image", "CrewDocumentForAdmin", true, "Image", new List<string> {"Image", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Image", Image);

            // ActiveDescription
            ActiveDescription = new (this, "x_ActiveDescription", 202, SqlDbType.NVarChar) {
                Name = "ActiveDescription",
                Expression = "dbo.MTCrewDocument.ActiveDescription",
                BasicSearchExpression = "dbo.MTCrewDocument.ActiveDescription",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.ActiveDescription",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "ActiveDescription", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ActiveDescription", ActiveDescription);

            // CreatedByUserID
            CreatedByUserID = new (this, "x_CreatedByUserID", 3, SqlDbType.Int) {
                Name = "CreatedByUserID",
                Expression = "dbo.MTCrewDocument.CreatedByUserID",
                BasicSearchExpression = "CAST(dbo.MTCrewDocument.CreatedByUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.CreatedByUserID",
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
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "CreatedByUserID", "CustomMsg"),
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
                Expression = "dbo.MTCrewDocument.CreatedDateTime",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrewDocument.CreatedDateTime", 1, "DB"),
                DateTimeFormat = 1,
                VirtualExpression = "dbo.MTCrewDocument.CreatedDateTime",
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
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "CreatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            CreatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedDateTime", "CrewDocumentForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CreatedDateTime", "CrewDocumentForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CreatedDateTime", "CrewDocumentForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CreatedDateTime", CreatedDateTime);

            // LastUpdatedByUserID
            LastUpdatedByUserID = new (this, "x_LastUpdatedByUserID", 3, SqlDbType.Int) {
                Name = "LastUpdatedByUserID",
                Expression = "dbo.MTCrewDocument.LastUpdatedByUserID",
                BasicSearchExpression = "CAST(dbo.MTCrewDocument.LastUpdatedByUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.LastUpdatedByUserID",
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
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "LastUpdatedByUserID", "CustomMsg"),
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
                Expression = "dbo.MTCrewDocument.LastUpdatedDateTime",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrewDocument.LastUpdatedDateTime", 1, "DB"),
                DateTimeFormat = 1,
                VirtualExpression = "dbo.MTCrewDocument.LastUpdatedDateTime",
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
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "LastUpdatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedDateTime", "CrewDocumentForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedDateTime", "CrewDocumentForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedDateTime", "CrewDocumentForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("LastUpdatedDateTime", LastUpdatedDateTime);

            // MTUserID
            MTUserID = new (this, "x_MTUserID", 3, SqlDbType.Int) {
                Name = "MTUserID",
                Expression = "dbo.MTCrewDocument.MTUserID",
                BasicSearchExpression = "CAST(dbo.MTCrewDocument.MTUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.MTUserID",
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
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "MTUserID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MTUserID", MTUserID);

            // IsDraft
            IsDraft = new (this, "x_IsDraft", 11, SqlDbType.Bit) {
                Name = "IsDraft",
                Expression = "dbo.MTCrewDocument.IsDraft",
                BasicSearchExpression = "dbo.MTCrewDocument.IsDraft",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrewDocument.IsDraft",
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
                CustomMessage = Language.FieldPhrase("CrewDocumentForAdmin", "IsDraft", "CustomMsg"),
                IsUpload = false
            };
            IsDraft.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("IsDraft", "CrewDocumentForAdmin", true, "IsDraft", new List<string> {"IsDraft", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("IsDraft", "CrewDocumentForAdmin", true, "IsDraft", new List<string> {"IsDraft", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("IsDraft", "CrewDocumentForAdmin", true, "IsDraft", new List<string> {"IsDraft", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("IsDraft", IsDraft);

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
            get => _sqlFrom ?? "dbo.MTCrewDocument";
            set => _sqlFrom = value;
        }

        // SELECT
        private string? _sqlSelect = null;

        public string SqlSelect { // Select
            get => _sqlSelect ?? "SELECT dbo.MTCrewDocument.ID, dbo.MTCrewDocument.MTCrewID, dbo.MTCrewDocument.MTDocumentID, dbo.MTCrewDocument.Number, dbo.MTCrewDocument.CountryOfIssue_CountryID, dbo.MTCrewDocument.DateOfIssue, dbo.MTCrewDocument.PlaceOfIssue, dbo.MTCrewDocument.DateValidUntil, dbo.MTCrewDocument.Image, dbo.MTCrewDocument.ActiveDescription, dbo.MTCrewDocument.CreatedByUserID, dbo.MTCrewDocument.CreatedDateTime, dbo.MTCrewDocument.LastUpdatedByUserID, dbo.MTCrewDocument.LastUpdatedDateTime, dbo.MTCrewDocument.MTUserID, dbo.MTCrewDocument.IsDraft FROM " + SqlFrom;
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
                MTDocumentID.DbValue = row["MTDocumentID"]; // Set DB value only
                Number.DbValue = row["Number"]; // Set DB value only
                CountryOfIssue_CountryID.DbValue = row["CountryOfIssue_CountryID"]; // Set DB value only
                DateOfIssue.DbValue = row["DateOfIssue"]; // Set DB value only
                PlaceOfIssue.DbValue = row["PlaceOfIssue"]; // Set DB value only
                DateValidUntil.DbValue = row["DateValidUntil"]; // Set DB value only
                Image.Upload.DbValue = row["Image"];
                ActiveDescription.DbValue = row["ActiveDescription"]; // Set DB value only
                CreatedByUserID.DbValue = row["CreatedByUserID"]; // Set DB value only
                CreatedDateTime.DbValue = row["CreatedDateTime"]; // Set DB value only
                LastUpdatedByUserID.DbValue = row["LastUpdatedByUserID"]; // Set DB value only
                LastUpdatedDateTime.DbValue = row["LastUpdatedDateTime"]; // Set DB value only
                MTUserID.DbValue = row["MTUserID"]; // Set DB value only
                IsDraft.DbValue = (ConvertToBool(row["IsDraft"]) ? "1" : "0"); // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
            if (!Empty(row["Image"])) {
                DeleteFile(Image.OldPhysicalUploadPath + row["Image"]);
            }
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "dbo.MTCrewDocument.ID = @ID@";

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
                    return "CrewDocumentForAdminList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "CrewDocumentForAdminView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "CrewDocumentForAdminEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "CrewDocumentForAdminAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "CrewDocumentForAdminList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "CrewDocumentForAdminView",
                Config.ApiAddAction => "CrewDocumentForAdminAdd",
                Config.ApiEditAction => "CrewDocumentForAdminEdit",
                Config.ApiDeleteAction => "CrewDocumentForAdminDelete",
                Config.ApiListAction => "CrewDocumentForAdminList",
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
        public string ListUrl => "CrewDocumentForAdminList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("CrewDocumentForAdminView", parm);
            else
                url = KeyUrl("CrewDocumentForAdminView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "CrewDocumentForAdminAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "CrewDocumentForAdminAdd?" + parm;
            else
                url = "CrewDocumentForAdminAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("CrewDocumentForAdminEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewDocumentForAdminList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("CrewDocumentForAdminAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewDocumentForAdminList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("CrewDocumentForAdminDelete")); // DN

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
            MTDocumentID.SetDbValue(dr["MTDocumentID"]);
            Number.SetDbValue(dr["Number"]);
            CountryOfIssue_CountryID.SetDbValue(dr["CountryOfIssue_CountryID"]);
            DateOfIssue.SetDbValue(dr["DateOfIssue"]);
            PlaceOfIssue.SetDbValue(dr["PlaceOfIssue"]);
            DateValidUntil.SetDbValue(dr["DateValidUntil"]);
            Image.Upload.DbValue = dr["Image"];
            Image.SetDbValue(Image.Upload.DbValue);
            ActiveDescription.SetDbValue(dr["ActiveDescription"]);
            CreatedByUserID.SetDbValue(dr["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(dr["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(dr["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(dr["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(dr["MTUserID"]);
            IsDraft.SetDbValue(ConvertToBool(dr["IsDraft"]) ? "1" : "0");
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "CrewDocumentForAdminList";
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

            // MTDocumentID
            MTDocumentID.CellCssStyle = "white-space: nowrap;";

            // Number
            Number.CellCssStyle = "white-space: nowrap;";

            // CountryOfIssue_CountryID
            CountryOfIssue_CountryID.CellCssStyle = "white-space: nowrap;";

            // DateOfIssue
            DateOfIssue.CellCssStyle = "white-space: nowrap;";

            // PlaceOfIssue
            PlaceOfIssue.CellCssStyle = "white-space: nowrap;";

            // DateValidUntil
            DateValidUntil.CellCssStyle = "white-space: nowrap;";

            // Image
            Image.CellCssStyle = "white-space: nowrap;";

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

            // IsDraft
            IsDraft.CellCssStyle = "white-space: nowrap;";

            // ID
            ID.ViewValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

            // MTCrewID
            MTCrewID.ViewValue = MTCrewID.CurrentValue;
            MTCrewID.ViewValue = FormatNumber(MTCrewID.ViewValue, MTCrewID.FormatPattern);
            MTCrewID.ViewCustomAttributes = "";

            // MTDocumentID
            MTDocumentID.ViewValue = MTDocumentID.CurrentValue;
            MTDocumentID.ViewCustomAttributes = "";

            // Number
            Number.ViewValue = ConvertToString(Number.CurrentValue); // DN
            Number.ViewCustomAttributes = "";

            // CountryOfIssue_CountryID
            curVal = ConvertToString(CountryOfIssue_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (CountryOfIssue_CountryID.Lookup != null && IsDictionary(CountryOfIssue_CountryID.Lookup?.Options) && CountryOfIssue_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CountryOfIssue_CountryID.ViewValue = CountryOfIssue_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", CountryOfIssue_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = CountryOfIssue_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && CountryOfIssue_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = CountryOfIssue_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        CountryOfIssue_CountryID.ViewValue = CountryOfIssue_CountryID.HighlightLookup(ConvertToString(rswrk[0]), CountryOfIssue_CountryID.DisplayValue(listwrk));
                    } else {
                        CountryOfIssue_CountryID.ViewValue = FormatNumber(CountryOfIssue_CountryID.CurrentValue, CountryOfIssue_CountryID.FormatPattern);
                    }
                }
            } else {
                CountryOfIssue_CountryID.ViewValue = DbNullValue;
            }
            CountryOfIssue_CountryID.ViewCustomAttributes = "";

            // DateOfIssue
            DateOfIssue.ViewValue = DateOfIssue.CurrentValue;
            DateOfIssue.ViewValue = FormatDateTime(DateOfIssue.ViewValue, DateOfIssue.FormatPattern);
            DateOfIssue.ViewCustomAttributes = "";

            // PlaceOfIssue
            PlaceOfIssue.ViewValue = ConvertToString(PlaceOfIssue.CurrentValue); // DN
            PlaceOfIssue.ViewCustomAttributes = "";

            // DateValidUntil
            DateValidUntil.ViewValue = DateValidUntil.CurrentValue;
            DateValidUntil.ViewValue = FormatDateTime(DateValidUntil.ViewValue, DateValidUntil.FormatPattern);
            DateValidUntil.ViewCustomAttributes = "";

            // Image
            if (!IsNull(Image.Upload.DbValue)) {
                Image.ImageWidth = 200;
                Image.ImageHeight = 0;
                Image.ImageAlt = Image.Alt;
                Image.ImageCssClass = "ew-image";
                Image.ViewValue = Image.Upload.DbValue;
            } else {
                Image.ViewValue = "";
            }
            Image.ViewCustomAttributes = "";

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

            // IsDraft
            if (ConvertToBool(IsDraft.CurrentValue)) {
                IsDraft.ViewValue = IsDraft.TagCaption(1) != "" ? IsDraft.TagCaption(1) : "Yes";
            } else {
                IsDraft.ViewValue = IsDraft.TagCaption(2) != "" ? IsDraft.TagCaption(2) : "No";
            }
            IsDraft.ViewCustomAttributes = "";

            // ID
            ID.HrefValue = "";
            ID.TooltipValue = "";

            // MTCrewID
            MTCrewID.HrefValue = "";
            MTCrewID.TooltipValue = "";

            // MTDocumentID
            MTDocumentID.HrefValue = "";
            MTDocumentID.TooltipValue = "";

            // Number
            Number.HrefValue = "";
            Number.TooltipValue = "";

            // CountryOfIssue_CountryID
            CountryOfIssue_CountryID.HrefValue = "";
            CountryOfIssue_CountryID.TooltipValue = "";

            // DateOfIssue
            DateOfIssue.HrefValue = "";
            DateOfIssue.TooltipValue = "";

            // PlaceOfIssue
            PlaceOfIssue.HrefValue = "";
            PlaceOfIssue.TooltipValue = "";

            // DateValidUntil
            DateValidUntil.HrefValue = "";
            DateValidUntil.TooltipValue = "";

            // Image
            if (!IsNull(Image.Upload.DbValue)) {
                Image.HrefValue = ConvertToString(GetFileUploadUrl(Image, Image.HtmlDecode(ConvertToString(Image.Upload.DbValue)))); // Add prefix/suffix
                Image.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    Image.HrefValue = FullUrl(ConvertToString(Image.HrefValue), "href");
            } else {
                Image.HrefValue = "";
            }
            Image.ExportHrefValue = Image.UploadPath + Image.Upload.DbValue;
            Image.TooltipValue = "";
            if (Image.UseColorbox) {
                if (Empty(Image.TooltipValue))
                    Image.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                Image.LinkAttrs["data-rel"] = "CrewDocumentForAdmin_x_Image";
                if (Image.LinkAttrs.ContainsKey("class")) {
                    Image.LinkAttrs.AppendClass("ew-lightbox");
                } else {
                    Image.LinkAttrs["class"] = "ew-lightbox";
                }
            }

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

            // IsDraft
            IsDraft.HrefValue = "";
            IsDraft.TooltipValue = "";

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

            // MTDocumentID
            MTDocumentID.SetupEditAttributes();
            MTDocumentID.EditValue = MTDocumentID.CurrentValue; // DN
            MTDocumentID.PlaceHolder = RemoveHtml(MTDocumentID.Caption);

            // Number
            Number.SetupEditAttributes();
            if (!Number.Raw)
                Number.CurrentValue = HtmlDecode(Number.CurrentValue);
            Number.EditValue = HtmlEncode(Number.CurrentValue);
            Number.PlaceHolder = RemoveHtml(Number.Caption);

            // CountryOfIssue_CountryID
            CountryOfIssue_CountryID.SetupEditAttributes();
            curVal = ConvertToString(CountryOfIssue_CountryID.CurrentValue)?.Trim() ?? "";
            if (CountryOfIssue_CountryID.Lookup != null && IsDictionary(CountryOfIssue_CountryID.Lookup?.Options) && CountryOfIssue_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                CountryOfIssue_CountryID.EditValue = CountryOfIssue_CountryID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = CountryOfIssue_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                CountryOfIssue_CountryID.EditValue = rswrk;
            }
            CountryOfIssue_CountryID.PlaceHolder = RemoveHtml(CountryOfIssue_CountryID.Caption);
            if (!Empty(CountryOfIssue_CountryID.EditValue) && IsNumeric(CountryOfIssue_CountryID.EditValue))
                CountryOfIssue_CountryID.EditValue = FormatNumber(CountryOfIssue_CountryID.EditValue, null);

            // DateOfIssue
            DateOfIssue.SetupEditAttributes();
            DateOfIssue.EditValue = FormatDateTime(DateOfIssue.CurrentValue, DateOfIssue.FormatPattern); // DN
            DateOfIssue.PlaceHolder = RemoveHtml(DateOfIssue.Caption);

            // PlaceOfIssue
            PlaceOfIssue.SetupEditAttributes();
            if (!PlaceOfIssue.Raw)
                PlaceOfIssue.CurrentValue = HtmlDecode(PlaceOfIssue.CurrentValue);
            PlaceOfIssue.EditValue = HtmlEncode(PlaceOfIssue.CurrentValue);
            PlaceOfIssue.PlaceHolder = RemoveHtml(PlaceOfIssue.Caption);

            // DateValidUntil
            DateValidUntil.SetupEditAttributes();
            DateValidUntil.EditValue = FormatDateTime(DateValidUntil.CurrentValue, DateValidUntil.FormatPattern); // DN
            DateValidUntil.PlaceHolder = RemoveHtml(DateValidUntil.Caption);

            // Image
            Image.SetupEditAttributes();
            Image.EditAttrs["accept"] = "jpg,jpeg,png,pdf";
            if (!IsNull(Image.Upload.DbValue)) {
                Image.ImageWidth = 200;
                Image.ImageHeight = 0;
                Image.ImageAlt = Image.Alt;
                Image.ImageCssClass = "ew-image";
                Image.EditValue = Image.Upload.DbValue;
            } else {
                Image.EditValue = "";
            }
            if (!Empty(Image.CurrentValue))
                    Image.Upload.FileName = ConvertToString(Image.CurrentValue);

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

            // IsDraft
            IsDraft.EditValue = IsDraft.Options(false);
            IsDraft.PlaceHolder = RemoveHtml(IsDraft.Caption);

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
                        doc.ExportCaption(MTDocumentID);
                        doc.ExportCaption(Number);
                        doc.ExportCaption(CountryOfIssue_CountryID);
                        doc.ExportCaption(DateOfIssue);
                        doc.ExportCaption(PlaceOfIssue);
                        doc.ExportCaption(DateValidUntil);
                        doc.ExportCaption(Image);
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(IsDraft);
                    } else {
                        doc.ExportCaption(MTDocumentID);
                        doc.ExportCaption(Number);
                        doc.ExportCaption(CountryOfIssue_CountryID);
                        doc.ExportCaption(DateOfIssue);
                        doc.ExportCaption(PlaceOfIssue);
                        doc.ExportCaption(DateValidUntil);
                        doc.ExportCaption(Image);
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(IsDraft);
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
                            await doc.ExportField(MTDocumentID);
                            await doc.ExportField(Number);
                            await doc.ExportField(CountryOfIssue_CountryID);
                            await doc.ExportField(DateOfIssue);
                            await doc.ExportField(PlaceOfIssue);
                            await doc.ExportField(DateValidUntil);
                            await doc.ExportField(Image);
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(IsDraft);
                        } else {
                            await doc.ExportField(MTDocumentID);
                            await doc.ExportField(Number);
                            await doc.ExportField(CountryOfIssue_CountryID);
                            await doc.ExportField(DateOfIssue);
                            await doc.ExportField(PlaceOfIssue);
                            await doc.ExportField(DateValidUntil);
                            await doc.ExportField(Image);
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(IsDraft);
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
                    filterWrk = "dbo.MTCrewDocument.MTUserID IN (" + filterWrk + ")";
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
            string sql = "SELECT " + masterfld.Expression + " FROM dbo.MTCrewDocument";
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

            // Set up field names
            string fldName = "", fileNameFld = "", fileTypeFld = "";
            if (SameText(fldparm, "Image")) {
                fldName = "Image";
                fileNameFld = "Image";
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
                Image.UploadPath = "uploads/" + individualCodeNumber;
            }
        }
        // Row Inserting event
        public bool RowInserting(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
            rsnew["CreatedByUserID"] = CurrentUserID();
            rsnew["CreatedDateTime"] = DateTimeOffset.Now;
            rsnew["LastUpdatedByUserID"] = CurrentUserID();
            rsnew["LastUpdatedDateTime"] = DateTimeOffset.Now;
            dynamic crewQueryResult = QueryBuilder("MTCrew").Where("ID", rsnew["MTCrewID"].ToString()).Select("IndividualCodeNumber").Select("MTUserID").FirstOrDefault();
            if ((object) crewQueryResult != null)
            {
                string crewIndividualCodeNumber = crewQueryResult.IndividualCodeNumber;
                Image.UploadPath = "uploads/" + crewIndividualCodeNumber;
                string imageFileName = rsnew["Image"].ToString();
                string imageFileExtension = System.IO.Path.GetExtension(imageFileName);
                dynamic documentQueryResult = QueryBuilder("MTDocument").Where("ID", rsnew["MTDocumentID"].ToString()).Select("Type").FirstOrDefault();
                if ((object) documentQueryResult != null)
                {
                    string documentType = documentQueryResult.Type;
                    string documentTypeURLFriendly = GenerateSlug(documentType);
                    rsnew["Image"] = crewIndividualCodeNumber + "-do-" + documentTypeURLFriendly + imageFileExtension;
                }
                if (CurrentUserLevel() == "-1") // Admin
                {
                    rsnew["MTUserID"] = crewQueryResult.MTUserID.ToString();
                }
                else
                {
                    rsnew["MTUserID"] = CurrentUserID();
                }
            }
            return true;
        }
        // Row Inserted event
        public void RowInserted(Dictionary<string, object>? rsold, Dictionary<string, object> rsnew) {
            //Log("Row Inserted");
            Session.SetInt("lastAddedDocumentCrewID", ConvertToInt(rsnew["MTCrewID"]));
        }
        // Row Updating event
        public bool RowUpdating(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            // Enter your code here
            // To cancel, set return value to False and error message to CancelMessage
            rsnew["LastUpdatedByUserID"] = CurrentUserID();
            rsnew["LastUpdatedDateTime"] = DateTimeOffset.Now;
            if (rsnew.ContainsKey("Image"))
            {
                dynamic crewQueryResult = QueryBuilder("MTCrew").Where("ID", rsnew["MTCrewID"].ToString()).Select("IndividualCodeNumber").FirstOrDefault();
                if ((object) crewQueryResult != null)
                {
                    string crewIndividualCodeNumber = crewQueryResult.IndividualCodeNumber;
                    Image.UploadPath = "uploads/" + crewIndividualCodeNumber;
                    Image.OldUploadPath = "uploads/" + crewIndividualCodeNumber;
                    string imageFileName = rsnew["Image"].ToString();
                    string imageFileExtension = System.IO.Path.GetExtension(imageFileName);
                    dynamic documentQueryResult = QueryBuilder("MTDocument").Where("ID", rsnew["MTDocumentID"].ToString()).Select("Type").FirstOrDefault();
                    if ((object) documentQueryResult != null)
                    {
                        string documentType = documentQueryResult.Type;
                        string documentTypeURLFriendly = GenerateSlug(documentType);
                        rsnew["Image"] = crewIndividualCodeNumber + "-do-" + documentTypeURLFriendly + imageFileExtension;
                    }
                }
            }
            return true;
        }
        // Row Updated event
        public void RowUpdated(Dictionary<string, object> rsold, Dictionary<string, object> rsnew) {
            //Log("Row Updated");
            Session.SetInt("lastUpdatedDocumentCrewID", ConvertToInt(rsnew["MTCrewID"]));
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
            int mtCrewID = Convert.ToInt32(rs["MTCrewID"]);
            object individualCodeNumberObject = ExecuteScalar("SELECT IndividualCodeNumber FROM MTCrew WHERE ID = " + mtCrewID + ";");
            if ((object) individualCodeNumberObject != null)
            {
                string individualCodeNumber = individualCodeNumberObject.ToString();
                Image.UploadPath = "uploads/" + individualCodeNumber;
                Image.OldUploadPath = "uploads/" + individualCodeNumber;
            }
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
