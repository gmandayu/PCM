namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// crewPersonalDataForAdmin
    /// </summary>
    [MaybeNull]
    public static CrewPersonalDataForAdmin crewPersonalDataForAdmin
    {
        get => HttpData.Resolve<CrewPersonalDataForAdmin>("CrewPersonalDataForAdmin");
        set => HttpData["CrewPersonalDataForAdmin"] = value;
    }

    /// <summary>
    /// Table class for CrewPersonalDataForAdmin
    /// </summary>
    public class CrewPersonalDataForAdmin : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> IndividualCodeNumber;

        public readonly DbField<SqlDbType> FullName;

        public readonly DbField<SqlDbType> RequiredPhoto;

        public readonly DbField<SqlDbType> VisaPhoto;

        public readonly DbField<SqlDbType> Nationality_CountryID;

        public readonly DbField<SqlDbType> CountryOfOrigin_CountryID;

        public readonly DbField<SqlDbType> DateOfBirth;

        public readonly DbField<SqlDbType> CityOfBirth;

        public readonly DbField<SqlDbType> Gender;

        public readonly DbField<SqlDbType> MaritalStatus;

        public readonly DbField<SqlDbType> ReligionID;

        public readonly DbField<SqlDbType> BloodType;

        public readonly DbField<SqlDbType> RankAppliedFor_RankID;

        public readonly DbField<SqlDbType> WillAcceptLowRank;

        public readonly DbField<SqlDbType> AvailableFrom;

        public readonly DbField<SqlDbType> AvailableUntil;

        public readonly DbField<SqlDbType> PrimaryAddressDetail;

        public readonly DbField<SqlDbType> PrimaryAddressCity;

        public readonly DbField<SqlDbType> PrimaryAddressNearestAirport;

        public readonly DbField<SqlDbType> PrimaryAddressState;

        public readonly DbField<SqlDbType> PrimaryAddressPostCode;

        public readonly DbField<SqlDbType> PrimaryAddressCountryID;

        public readonly DbField<SqlDbType> PrimaryAddressHomeTel;

        public readonly DbField<SqlDbType> AlternativeAddressDetail;

        public readonly DbField<SqlDbType> AlternativeAddressState;

        public readonly DbField<SqlDbType> AlternativeAddressCity;

        public readonly DbField<SqlDbType> AlternativeAddressHomeTel;

        public readonly DbField<SqlDbType> AlternativeAddressPostCode;

        public readonly DbField<SqlDbType> AlternativeAddressCountryID;

        public readonly DbField<SqlDbType> MobileNumber;

        public readonly DbField<SqlDbType> _Email;

        public readonly DbField<SqlDbType> EmployeeStatus;

        public readonly DbField<SqlDbType> FormSubmittedDateTime;

        public readonly DbField<SqlDbType> ActiveDescription;

        public readonly DbField<SqlDbType> CreatedByUserID;

        public readonly DbField<SqlDbType> CreatedDateTime;

        public readonly DbField<SqlDbType> LastUpdatedByUserID;

        public readonly DbField<SqlDbType> LastUpdatedDateTime;

        public readonly DbField<SqlDbType> MTUserID;

        public readonly DbField<SqlDbType> SocialSecurityNumber;

        public readonly DbField<SqlDbType> SocialSecurityIssuingCountryID;

        public readonly DbField<SqlDbType> SocialSecurityImage;

        public readonly DbField<SqlDbType> PersonalTaxNumber;

        public readonly DbField<SqlDbType> PersonalTaxIssuingCountryID;

        public readonly DbField<SqlDbType> PersonalTaxImage;

        public readonly DbField<SqlDbType> Status;

        public readonly DbField<SqlDbType> Reason;

        public readonly DbField<SqlDbType> Weight;

        public readonly DbField<SqlDbType> Height;

        public readonly DbField<SqlDbType> CoverallSize;

        public readonly DbField<SqlDbType> SafetyShoesSize;

        public readonly DbField<SqlDbType> ShirtSize;

        public readonly DbField<SqlDbType> TrousersSize;

        public readonly DbField<SqlDbType> NomineeFullName;

        public readonly DbField<SqlDbType> NomineeRelationship;

        public readonly DbField<SqlDbType> NomineeGender;

        public readonly DbField<SqlDbType> NomineeNationality_CountryID;

        public readonly DbField<SqlDbType> NomineeAddressDetail;

        public readonly DbField<SqlDbType> NomineeAddressCity;

        public readonly DbField<SqlDbType> NomineeAddressPostCode;

        public readonly DbField<SqlDbType> NomineeAddressCountryID;

        public readonly DbField<SqlDbType> NomineeAddressHomeTel;

        public readonly DbField<SqlDbType> NomineeEmail;

        public readonly DbField<SqlDbType> NomineeMobileNumber;

        public readonly DbField<SqlDbType> NSSF_Health_Number;

        public readonly DbField<SqlDbType> NSSF_Occupation_Number;

        public readonly DbField<SqlDbType> NomineeRelationshipSelect;

        public readonly DbField<SqlDbType> NomineeRelationshipDetail;

        public readonly DbField<SqlDbType> MobileNumberCode_CountryID;

        public readonly DbField<SqlDbType> PrimaryAddressHomeTelCode_CountryID;

        public readonly DbField<SqlDbType> AlternativeAddressHomeTelCode_CountryID;

        public readonly DbField<SqlDbType> NomineeAddressHomeTelCode_CountryID;

        public readonly DbField<SqlDbType> NomineeMobileNumberCode_CountryID;

        // Constructor
        public CrewPersonalDataForAdmin()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "CrewPersonalDataForAdmin";
            Name = "CrewPersonalDataForAdmin";
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ID", ID);

            // IndividualCodeNumber
            IndividualCodeNumber = new (this, "x_IndividualCodeNumber", 202, SqlDbType.NVarChar) {
                Name = "IndividualCodeNumber",
                Expression = "dbo.MTCrew.IndividualCodeNumber",
                BasicSearchExpression = "dbo.MTCrew.IndividualCodeNumber",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.IndividualCodeNumber",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "IndividualCodeNumber", "CustomMsg"),
                IsUpload = false
            };
            IndividualCodeNumber.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("IndividualCodeNumber", "CrewPersonalDataForAdmin", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("IndividualCodeNumber", "CrewPersonalDataForAdmin", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("IndividualCodeNumber", "CrewPersonalDataForAdmin", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            IndividualCodeNumber.GetServerValidateArguments = () => @"^\d{10}$";
            Fields.Add("IndividualCodeNumber", IndividualCodeNumber);

            // FullName
            FullName = new (this, "x_FullName", 202, SqlDbType.NVarChar) {
                Name = "FullName",
                Expression = "dbo.MTCrew.FullName",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrew.FullName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.FullName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "FullName", "CustomMsg"),
                IsUpload = false
            };
            FullName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FullName", "CrewPersonalDataForAdmin", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("FullName", "CrewPersonalDataForAdmin", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("FullName", "CrewPersonalDataForAdmin", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("FullName", FullName);

            // RequiredPhoto
            RequiredPhoto = new (this, "x_RequiredPhoto", 202, SqlDbType.NVarChar) {
                Name = "RequiredPhoto",
                Expression = "dbo.MTCrew.RequiredPhoto",
                BasicSearchExpression = "dbo.MTCrew.RequiredPhoto",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.RequiredPhoto",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "IMAGE",
                HtmlTag = "FILE",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                ImageResize = true,
                UploadAllowedFileExtensions = "jpg,jpeg,png",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "RequiredPhoto", "CustomMsg"),
                IsUpload = true
            };
            RequiredPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("RequiredPhoto", "CrewPersonalDataForAdmin", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("RequiredPhoto", "CrewPersonalDataForAdmin", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("RequiredPhoto", "CrewPersonalDataForAdmin", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            RequiredPhoto.GetUploadPath = () => "uploads/" + IndividualCodeNumber.DbValue;
            Fields.Add("RequiredPhoto", RequiredPhoto);

            // VisaPhoto
            VisaPhoto = new (this, "x_VisaPhoto", 202, SqlDbType.NVarChar) {
                Name = "VisaPhoto",
                Expression = "dbo.MTCrew.VisaPhoto",
                BasicSearchExpression = "dbo.MTCrew.VisaPhoto",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.VisaPhoto",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "IMAGE",
                HtmlTag = "FILE",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                ImageResize = true,
                UploadAllowedFileExtensions = "jpg,jpeg,png",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "VisaPhoto", "CustomMsg"),
                IsUpload = true
            };
            VisaPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("VisaPhoto", "CrewPersonalDataForAdmin", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("VisaPhoto", "CrewPersonalDataForAdmin", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("VisaPhoto", "CrewPersonalDataForAdmin", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            VisaPhoto.GetUploadPath = () => "uploads/" + IndividualCodeNumber.DbValue;
            Fields.Add("VisaPhoto", VisaPhoto);

            // Nationality_CountryID
            Nationality_CountryID = new (this, "x_Nationality_CountryID", 3, SqlDbType.Int) {
                Name = "Nationality_CountryID",
                Expression = "dbo.MTCrew.Nationality_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.Nationality_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Nationality_CountryID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "Nationality_CountryID", "CustomMsg"),
                IsUpload = false
            };
            Nationality_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Nationality_CountryID", "MTCountry", true, "ID", new List<string> {"Nationality", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Nationality]"),
                "id-ID" => new Lookup<DbField>("Nationality_CountryID", "MTCountry", true, "ID", new List<string> {"Nationality", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Nationality]"),
                _ => new Lookup<DbField>("Nationality_CountryID", "MTCountry", true, "ID", new List<string> {"Nationality", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Nationality]")
            };
            Fields.Add("Nationality_CountryID", Nationality_CountryID);

            // CountryOfOrigin_CountryID
            CountryOfOrigin_CountryID = new (this, "x_CountryOfOrigin_CountryID", 3, SqlDbType.Int) {
                Name = "CountryOfOrigin_CountryID",
                Expression = "dbo.MTCrew.CountryOfOrigin_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.CountryOfOrigin_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.CountryOfOrigin_CountryID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "CountryOfOrigin_CountryID", "CustomMsg"),
                IsUpload = false
            };
            CountryOfOrigin_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CountryOfOrigin_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("CountryOfOrigin_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("CountryOfOrigin_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("CountryOfOrigin_CountryID", CountryOfOrigin_CountryID);

            // DateOfBirth
            DateOfBirth = new (this, "x_DateOfBirth", 133, SqlDbType.Date) {
                Name = "DateOfBirth",
                Expression = "dbo.MTCrew.DateOfBirth",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrew.DateOfBirth", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.MTCrew.DateOfBirth",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "DateOfBirth", "CustomMsg"),
                IsUpload = false
            };
            DateOfBirth.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("DateOfBirth", "CrewPersonalDataForAdmin", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("DateOfBirth", "CrewPersonalDataForAdmin", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("DateOfBirth", "CrewPersonalDataForAdmin", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("DateOfBirth", DateOfBirth);

            // CityOfBirth
            CityOfBirth = new (this, "x_CityOfBirth", 202, SqlDbType.NVarChar) {
                Name = "CityOfBirth",
                Expression = "dbo.MTCrew.CityOfBirth",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrew.CityOfBirth",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.CityOfBirth",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "CityOfBirth", "CustomMsg"),
                IsUpload = false
            };
            CityOfBirth.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CityOfBirth", "CrewPersonalDataForAdmin", true, "CityOfBirth", new List<string> {"CityOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CityOfBirth", "CrewPersonalDataForAdmin", true, "CityOfBirth", new List<string> {"CityOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CityOfBirth", "CrewPersonalDataForAdmin", true, "CityOfBirth", new List<string> {"CityOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CityOfBirth", CityOfBirth);

            // Gender
            Gender = new (this, "x_Gender", 202, SqlDbType.NVarChar) {
                Name = "Gender",
                Expression = "dbo.MTCrew.Gender",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrew.Gender",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Gender",
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
                OptionCount = 3,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "Gender", "CustomMsg"),
                IsUpload = false
            };
            Gender.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Gender", "CrewPersonalDataForAdmin", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Gender", "CrewPersonalDataForAdmin", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Gender", "CrewPersonalDataForAdmin", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Gender", Gender);

            // MaritalStatus
            MaritalStatus = new (this, "x_MaritalStatus", 202, SqlDbType.NVarChar) {
                Name = "MaritalStatus",
                Expression = "dbo.MTCrew.MaritalStatus",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrew.MaritalStatus",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.MaritalStatus",
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
                OptionCount = 3,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "MaritalStatus", "CustomMsg"),
                IsUpload = false
            };
            MaritalStatus.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MaritalStatus", "CrewPersonalDataForAdmin", true, "MaritalStatus", new List<string> {"MaritalStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("MaritalStatus", "CrewPersonalDataForAdmin", true, "MaritalStatus", new List<string> {"MaritalStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("MaritalStatus", "CrewPersonalDataForAdmin", true, "MaritalStatus", new List<string> {"MaritalStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("MaritalStatus", MaritalStatus);

            // ReligionID
            ReligionID = new (this, "x_ReligionID", 3, SqlDbType.Int) {
                Name = "ReligionID",
                Expression = "dbo.MTCrew.ReligionID",
                BasicSearchExpression = "CAST(dbo.MTCrew.ReligionID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.ReligionID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "ReligionID", "CustomMsg"),
                IsUpload = false
            };
            ReligionID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ReligionID", "MTReligion", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("ReligionID", "MTReligion", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("ReligionID", "MTReligion", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("ReligionID", ReligionID);

            // BloodType
            BloodType = new (this, "x_BloodType", 202, SqlDbType.NVarChar) {
                Name = "BloodType",
                Expression = "dbo.MTCrew.BloodType",
                BasicSearchExpression = "dbo.MTCrew.BloodType",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.BloodType",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 8,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "BloodType", "CustomMsg"),
                IsUpload = false
            };
            BloodType.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("BloodType", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("BloodType", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("BloodType", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("BloodType", BloodType);

            // RankAppliedFor_RankID
            RankAppliedFor_RankID = new (this, "x_RankAppliedFor_RankID", 3, SqlDbType.Int) {
                Name = "RankAppliedFor_RankID",
                Expression = "dbo.MTCrew.RankAppliedFor_RankID",
                BasicSearchExpression = "CAST(dbo.MTCrew.RankAppliedFor_RankID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.RankAppliedFor_RankID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "RankAppliedFor_RankID", "CustomMsg"),
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
                Expression = "dbo.MTCrew.WillAcceptLowRank",
                BasicSearchExpression = "dbo.MTCrew.WillAcceptLowRank",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.WillAcceptLowRank",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "WillAcceptLowRank", "CustomMsg"),
                IsUpload = false
            };
            WillAcceptLowRank.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("WillAcceptLowRank", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("WillAcceptLowRank", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("WillAcceptLowRank", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("WillAcceptLowRank", WillAcceptLowRank);

            // AvailableFrom
            AvailableFrom = new (this, "x_AvailableFrom", 133, SqlDbType.Date) {
                Name = "AvailableFrom",
                Expression = "dbo.MTCrew.AvailableFrom",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrew.AvailableFrom", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.MTCrew.AvailableFrom",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "AvailableFrom", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AvailableFrom", AvailableFrom);

            // AvailableUntil
            AvailableUntil = new (this, "x_AvailableUntil", 133, SqlDbType.Date) {
                Name = "AvailableUntil",
                Expression = "dbo.MTCrew.AvailableUntil",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrew.AvailableUntil", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "dbo.MTCrew.AvailableUntil",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "AvailableUntil", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AvailableUntil", AvailableUntil);

            // PrimaryAddressDetail
            PrimaryAddressDetail = new (this, "x_PrimaryAddressDetail", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressDetail",
                Expression = "dbo.MTCrew.PrimaryAddressDetail",
                BasicSearchExpression = "dbo.MTCrew.PrimaryAddressDetail",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PrimaryAddressDetail",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PrimaryAddressDetail", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressDetail", PrimaryAddressDetail);

            // PrimaryAddressCity
            PrimaryAddressCity = new (this, "x_PrimaryAddressCity", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressCity",
                Expression = "dbo.MTCrew.PrimaryAddressCity",
                BasicSearchExpression = "dbo.MTCrew.PrimaryAddressCity",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PrimaryAddressCity",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PrimaryAddressCity", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressCity", PrimaryAddressCity);

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport = new (this, "x_PrimaryAddressNearestAirport", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressNearestAirport",
                Expression = "dbo.MTCrew.PrimaryAddressNearestAirport",
                BasicSearchExpression = "dbo.MTCrew.PrimaryAddressNearestAirport",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PrimaryAddressNearestAirport",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PrimaryAddressNearestAirport", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressNearestAirport", PrimaryAddressNearestAirport);

            // PrimaryAddressState
            PrimaryAddressState = new (this, "x_PrimaryAddressState", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressState",
                Expression = "dbo.MTCrew.PrimaryAddressState",
                BasicSearchExpression = "dbo.MTCrew.PrimaryAddressState",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PrimaryAddressState",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PrimaryAddressState", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressState", PrimaryAddressState);

            // PrimaryAddressPostCode
            PrimaryAddressPostCode = new (this, "x_PrimaryAddressPostCode", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressPostCode",
                Expression = "dbo.MTCrew.PrimaryAddressPostCode",
                BasicSearchExpression = "dbo.MTCrew.PrimaryAddressPostCode",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PrimaryAddressPostCode",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PrimaryAddressPostCode", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressPostCode", PrimaryAddressPostCode);

            // PrimaryAddressCountryID
            PrimaryAddressCountryID = new (this, "x_PrimaryAddressCountryID", 3, SqlDbType.Int) {
                Name = "PrimaryAddressCountryID",
                Expression = "dbo.MTCrew.PrimaryAddressCountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.PrimaryAddressCountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PrimaryAddressCountryID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PrimaryAddressCountryID", "CustomMsg"),
                IsUpload = false
            };
            PrimaryAddressCountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("PrimaryAddressCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("PrimaryAddressCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("PrimaryAddressCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("PrimaryAddressCountryID", PrimaryAddressCountryID);

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel = new (this, "x_PrimaryAddressHomeTel", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressHomeTel",
                Expression = "dbo.MTCrew.PrimaryAddressHomeTel",
                BasicSearchExpression = "dbo.MTCrew.PrimaryAddressHomeTel",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PrimaryAddressHomeTel",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PrimaryAddressHomeTel", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressHomeTel", PrimaryAddressHomeTel);

            // AlternativeAddressDetail
            AlternativeAddressDetail = new (this, "x_AlternativeAddressDetail", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressDetail",
                Expression = "dbo.MTCrew.AlternativeAddressDetail",
                BasicSearchExpression = "dbo.MTCrew.AlternativeAddressDetail",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.AlternativeAddressDetail",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "AlternativeAddressDetail", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressDetail", AlternativeAddressDetail);

            // AlternativeAddressState
            AlternativeAddressState = new (this, "x_AlternativeAddressState", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressState",
                Expression = "dbo.MTCrew.AlternativeAddressState",
                BasicSearchExpression = "dbo.MTCrew.AlternativeAddressState",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.AlternativeAddressState",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "AlternativeAddressState", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressState", AlternativeAddressState);

            // AlternativeAddressCity
            AlternativeAddressCity = new (this, "x_AlternativeAddressCity", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressCity",
                Expression = "dbo.MTCrew.AlternativeAddressCity",
                BasicSearchExpression = "dbo.MTCrew.AlternativeAddressCity",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.AlternativeAddressCity",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "AlternativeAddressCity", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressCity", AlternativeAddressCity);

            // AlternativeAddressHomeTel
            AlternativeAddressHomeTel = new (this, "x_AlternativeAddressHomeTel", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressHomeTel",
                Expression = "dbo.MTCrew.AlternativeAddressHomeTel",
                BasicSearchExpression = "dbo.MTCrew.AlternativeAddressHomeTel",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.AlternativeAddressHomeTel",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "AlternativeAddressHomeTel", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressHomeTel", AlternativeAddressHomeTel);

            // AlternativeAddressPostCode
            AlternativeAddressPostCode = new (this, "x_AlternativeAddressPostCode", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressPostCode",
                Expression = "dbo.MTCrew.AlternativeAddressPostCode",
                BasicSearchExpression = "dbo.MTCrew.AlternativeAddressPostCode",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.AlternativeAddressPostCode",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "AlternativeAddressPostCode", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressPostCode", AlternativeAddressPostCode);

            // AlternativeAddressCountryID
            AlternativeAddressCountryID = new (this, "x_AlternativeAddressCountryID", 3, SqlDbType.Int) {
                Name = "AlternativeAddressCountryID",
                Expression = "dbo.MTCrew.AlternativeAddressCountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.AlternativeAddressCountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.AlternativeAddressCountryID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "AlternativeAddressCountryID", "CustomMsg"),
                IsUpload = false
            };
            AlternativeAddressCountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("AlternativeAddressCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("AlternativeAddressCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("AlternativeAddressCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("AlternativeAddressCountryID", AlternativeAddressCountryID);

            // MobileNumber
            MobileNumber = new (this, "x_MobileNumber", 202, SqlDbType.NVarChar) {
                Name = "MobileNumber",
                Expression = "dbo.MTCrew.MobileNumber",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrew.MobileNumber",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.MobileNumber",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "MobileNumber", "CustomMsg"),
                IsUpload = false
            };
            MobileNumber.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MobileNumber", "CrewPersonalDataForAdmin", true, "MobileNumber", new List<string> {"MobileNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("MobileNumber", "CrewPersonalDataForAdmin", true, "MobileNumber", new List<string> {"MobileNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("MobileNumber", "CrewPersonalDataForAdmin", true, "MobileNumber", new List<string> {"MobileNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("MobileNumber", MobileNumber);

            // Email
            _Email = new (this, "x__Email", 202, SqlDbType.NVarChar) {
                Name = "Email",
                Expression = "dbo.MTCrew.Email",
                UseBasicSearch = true,
                BasicSearchExpression = "dbo.MTCrew.Email",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Email",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "email",
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectEmail"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "_Email", "CustomMsg"),
                IsUpload = false
            };
            _Email.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Email", "CrewPersonalDataForAdmin", true, "Email", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Email", "CrewPersonalDataForAdmin", true, "Email", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Email", "CrewPersonalDataForAdmin", true, "Email", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Email", _Email);

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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "EmployeeStatus", "CustomMsg"),
                IsUpload = false
            };
            EmployeeStatus.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("EmployeeStatus", "CrewPersonalDataForAdmin", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("EmployeeStatus", "CrewPersonalDataForAdmin", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("EmployeeStatus", "CrewPersonalDataForAdmin", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("EmployeeStatus", EmployeeStatus);

            // FormSubmittedDateTime
            FormSubmittedDateTime = new (this, "x_FormSubmittedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "FormSubmittedDateTime",
                Expression = "dbo.MTCrew.FormSubmittedDateTime",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrew.FormSubmittedDateTime", 1, "DB"),
                DateTimeFormat = 1,
                VirtualExpression = "dbo.MTCrew.FormSubmittedDateTime",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "FormSubmittedDateTime", "CustomMsg"),
                IsUpload = false
            };
            FormSubmittedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FormSubmittedDateTime", "CrewPersonalDataForAdmin", true, "FormSubmittedDateTime", new List<string> {"FormSubmittedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("FormSubmittedDateTime", "CrewPersonalDataForAdmin", true, "FormSubmittedDateTime", new List<string> {"FormSubmittedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("FormSubmittedDateTime", "CrewPersonalDataForAdmin", true, "FormSubmittedDateTime", new List<string> {"FormSubmittedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("FormSubmittedDateTime", FormSubmittedDateTime);

            // ActiveDescription
            ActiveDescription = new (this, "x_ActiveDescription", 202, SqlDbType.NVarChar) {
                Name = "ActiveDescription",
                Expression = "dbo.MTCrew.ActiveDescription",
                BasicSearchExpression = "dbo.MTCrew.ActiveDescription",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.ActiveDescription",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "ActiveDescription", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ActiveDescription", ActiveDescription);

            // CreatedByUserID
            CreatedByUserID = new (this, "x_CreatedByUserID", 3, SqlDbType.Int) {
                Name = "CreatedByUserID",
                Expression = "dbo.MTCrew.CreatedByUserID",
                BasicSearchExpression = "CAST(dbo.MTCrew.CreatedByUserID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.CreatedByUserID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "CreatedByUserID", "CustomMsg"),
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
                Expression = "dbo.MTCrew.CreatedDateTime",
                BasicSearchExpression = CastDateFieldForLike("dbo.MTCrew.CreatedDateTime", 1, "DB"),
                DateTimeFormat = 1,
                VirtualExpression = "dbo.MTCrew.CreatedDateTime",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "CreatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            CreatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedDateTime", "CrewPersonalDataForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CreatedDateTime", "CrewPersonalDataForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CreatedDateTime", "CrewPersonalDataForAdmin", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CreatedDateTime", CreatedDateTime);

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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "LastUpdatedByUserID", "CustomMsg"),
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "LastUpdatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedDateTime", "CrewPersonalDataForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedDateTime", "CrewPersonalDataForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedDateTime", "CrewPersonalDataForAdmin", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "MTUserID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MTUserID", MTUserID);

            // SocialSecurityNumber
            SocialSecurityNumber = new (this, "x_SocialSecurityNumber", 202, SqlDbType.NVarChar) {
                Name = "SocialSecurityNumber",
                Expression = "dbo.MTCrew.SocialSecurityNumber",
                BasicSearchExpression = "dbo.MTCrew.SocialSecurityNumber",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.SocialSecurityNumber",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "SocialSecurityNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("SocialSecurityNumber", SocialSecurityNumber);

            // SocialSecurityIssuingCountryID
            SocialSecurityIssuingCountryID = new (this, "x_SocialSecurityIssuingCountryID", 3, SqlDbType.Int) {
                Name = "SocialSecurityIssuingCountryID",
                Expression = "dbo.MTCrew.SocialSecurityIssuingCountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.SocialSecurityIssuingCountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.SocialSecurityIssuingCountryID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "SocialSecurityIssuingCountryID", "CustomMsg"),
                IsUpload = false
            };
            SocialSecurityIssuingCountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("SocialSecurityIssuingCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("SocialSecurityIssuingCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("SocialSecurityIssuingCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("SocialSecurityIssuingCountryID", SocialSecurityIssuingCountryID);

            // SocialSecurityImage
            SocialSecurityImage = new (this, "x_SocialSecurityImage", 202, SqlDbType.NVarChar) {
                Name = "SocialSecurityImage",
                Expression = "dbo.MTCrew.SocialSecurityImage",
                BasicSearchExpression = "dbo.MTCrew.SocialSecurityImage",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.SocialSecurityImage",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "IMAGE",
                HtmlTag = "FILE",
                InputTextType = "text",
                ImageResize = true,
                UploadAllowedFileExtensions = "jpg,jpeg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "SocialSecurityImage", "CustomMsg"),
                IsUpload = true
            };
            SocialSecurityImage.GetUploadPath = () => "uploads/" + IndividualCodeNumber.DbValue;
            Fields.Add("SocialSecurityImage", SocialSecurityImage);

            // PersonalTaxNumber
            PersonalTaxNumber = new (this, "x_PersonalTaxNumber", 202, SqlDbType.NVarChar) {
                Name = "PersonalTaxNumber",
                Expression = "dbo.MTCrew.PersonalTaxNumber",
                BasicSearchExpression = "dbo.MTCrew.PersonalTaxNumber",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PersonalTaxNumber",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PersonalTaxNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PersonalTaxNumber", PersonalTaxNumber);

            // PersonalTaxIssuingCountryID
            PersonalTaxIssuingCountryID = new (this, "x_PersonalTaxIssuingCountryID", 3, SqlDbType.Int) {
                Name = "PersonalTaxIssuingCountryID",
                Expression = "dbo.MTCrew.PersonalTaxIssuingCountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.PersonalTaxIssuingCountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PersonalTaxIssuingCountryID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PersonalTaxIssuingCountryID", "CustomMsg"),
                IsUpload = false
            };
            PersonalTaxIssuingCountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("PersonalTaxIssuingCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("PersonalTaxIssuingCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("PersonalTaxIssuingCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("PersonalTaxIssuingCountryID", PersonalTaxIssuingCountryID);

            // PersonalTaxImage
            PersonalTaxImage = new (this, "x_PersonalTaxImage", 202, SqlDbType.NVarChar) {
                Name = "PersonalTaxImage",
                Expression = "dbo.MTCrew.PersonalTaxImage",
                BasicSearchExpression = "dbo.MTCrew.PersonalTaxImage",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PersonalTaxImage",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "IMAGE",
                HtmlTag = "FILE",
                InputTextType = "text",
                ImageResize = true,
                UploadAllowedFileExtensions = "jpg,jpeg,png,pdf",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PersonalTaxImage", "CustomMsg"),
                IsUpload = true
            };
            PersonalTaxImage.GetUploadPath = () => "uploads/" + IndividualCodeNumber.DbValue;
            Fields.Add("PersonalTaxImage", PersonalTaxImage);

            // Status
            Status = new (this, "x_Status", 202, SqlDbType.NVarChar) {
                Name = "Status",
                Expression = "dbo.MTCrew.Status",
                BasicSearchExpression = "dbo.MTCrew.Status",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Status",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "Status", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Status", Status);

            // Reason
            Reason = new (this, "x_Reason", 202, SqlDbType.NVarChar) {
                Name = "Reason",
                Expression = "dbo.MTCrew.Reason",
                BasicSearchExpression = "dbo.MTCrew.Reason",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Reason",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "Reason", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reason", Reason);

            // Weight
            Weight = new (this, "x_Weight", 3, SqlDbType.Int) {
                Name = "Weight",
                Expression = "dbo.MTCrew.Weight",
                BasicSearchExpression = "CAST(dbo.MTCrew.Weight AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Weight",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "Weight", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Weight", Weight);

            // Height
            Height = new (this, "x_Height", 3, SqlDbType.Int) {
                Name = "Height",
                Expression = "dbo.MTCrew.Height",
                BasicSearchExpression = "CAST(dbo.MTCrew.Height AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.Height",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "Height", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Height", Height);

            // CoverallSize
            CoverallSize = new (this, "x_CoverallSize", 202, SqlDbType.NVarChar) {
                Name = "CoverallSize",
                Expression = "dbo.MTCrew.CoverallSize",
                BasicSearchExpression = "dbo.MTCrew.CoverallSize",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.CoverallSize",
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
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "CoverallSize", "CustomMsg"),
                IsUpload = false
            };
            CoverallSize.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CoverallSize", "MTClothesSize", false, "Name", new List<string> {"Name", "CoverallSizeDescription", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Name],'" + ValueSeparator(1, CoverallSize) + "',[CoverallSizeDescription])"),
                "id-ID" => new Lookup<DbField>("CoverallSize", "MTClothesSize", false, "Name", new List<string> {"Name", "CoverallSizeDescription", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Name],'" + ValueSeparator(1, CoverallSize) + "',[CoverallSizeDescription])"),
                _ => new Lookup<DbField>("CoverallSize", "MTClothesSize", false, "Name", new List<string> {"Name", "CoverallSizeDescription", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Name],'" + ValueSeparator(1, CoverallSize) + "',[CoverallSizeDescription])")
            };
            Fields.Add("CoverallSize", CoverallSize);

            // SafetyShoesSize
            SafetyShoesSize = new (this, "x_SafetyShoesSize", 3, SqlDbType.Int) {
                Name = "SafetyShoesSize",
                Expression = "dbo.MTCrew.SafetyShoesSize",
                BasicSearchExpression = "CAST(dbo.MTCrew.SafetyShoesSize AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.SafetyShoesSize",
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
                OptionCount = 9,
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "SafetyShoesSize", "CustomMsg"),
                IsUpload = false
            };
            SafetyShoesSize.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("SafetyShoesSize", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("SafetyShoesSize", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("SafetyShoesSize", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("SafetyShoesSize", SafetyShoesSize);

            // ShirtSize
            ShirtSize = new (this, "x_ShirtSize", 202, SqlDbType.NVarChar) {
                Name = "ShirtSize",
                Expression = "dbo.MTCrew.ShirtSize",
                BasicSearchExpression = "dbo.MTCrew.ShirtSize",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.ShirtSize",
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
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "ShirtSize", "CustomMsg"),
                IsUpload = false
            };
            ShirtSize.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ShirtSize", "MTClothesSize", false, "Name", new List<string> {"Name", "ShirtSizeDescription", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Name],'" + ValueSeparator(1, ShirtSize) + "',[ShirtSizeDescription])"),
                "id-ID" => new Lookup<DbField>("ShirtSize", "MTClothesSize", false, "Name", new List<string> {"Name", "ShirtSizeDescription", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Name],'" + ValueSeparator(1, ShirtSize) + "',[ShirtSizeDescription])"),
                _ => new Lookup<DbField>("ShirtSize", "MTClothesSize", false, "Name", new List<string> {"Name", "ShirtSizeDescription", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Name],'" + ValueSeparator(1, ShirtSize) + "',[ShirtSizeDescription])")
            };
            Fields.Add("ShirtSize", ShirtSize);

            // TrousersSize
            TrousersSize = new (this, "x_TrousersSize", 202, SqlDbType.NVarChar) {
                Name = "TrousersSize",
                Expression = "dbo.MTCrew.TrousersSize",
                BasicSearchExpression = "dbo.MTCrew.TrousersSize",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.TrousersSize",
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
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "TrousersSize", "CustomMsg"),
                IsUpload = false
            };
            TrousersSize.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("TrousersSize", "MTClothesSize", false, "Name", new List<string> {"Name", "TrouserSizeDescription", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Name],'" + ValueSeparator(1, TrousersSize) + "',[TrouserSizeDescription])"),
                "id-ID" => new Lookup<DbField>("TrousersSize", "MTClothesSize", false, "Name", new List<string> {"Name", "TrouserSizeDescription", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Name],'" + ValueSeparator(1, TrousersSize) + "',[TrouserSizeDescription])"),
                _ => new Lookup<DbField>("TrousersSize", "MTClothesSize", false, "Name", new List<string> {"Name", "TrouserSizeDescription", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "CONCAT([Name],'" + ValueSeparator(1, TrousersSize) + "',[TrouserSizeDescription])")
            };
            Fields.Add("TrousersSize", TrousersSize);

            // NomineeFullName
            NomineeFullName = new (this, "x_NomineeFullName", 202, SqlDbType.NVarChar) {
                Name = "NomineeFullName",
                Expression = "dbo.MTCrew.NomineeFullName",
                BasicSearchExpression = "dbo.MTCrew.NomineeFullName",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeFullName",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeFullName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeFullName", NomineeFullName);

            // NomineeRelationship
            NomineeRelationship = new (this, "x_NomineeRelationship", 202, SqlDbType.NVarChar) {
                Name = "NomineeRelationship",
                Expression = "dbo.MTCrew.NomineeRelationship",
                BasicSearchExpression = "dbo.MTCrew.NomineeRelationship",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeRelationship",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeRelationship", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeRelationship", NomineeRelationship);

            // NomineeGender
            NomineeGender = new (this, "x_NomineeGender", 202, SqlDbType.NVarChar) {
                Name = "NomineeGender",
                Expression = "dbo.MTCrew.NomineeGender",
                BasicSearchExpression = "dbo.MTCrew.NomineeGender",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeGender",
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
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeGender", "CustomMsg"),
                IsUpload = false
            };
            NomineeGender.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("NomineeGender", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("NomineeGender", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("NomineeGender", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("NomineeGender", NomineeGender);

            // NomineeNationality_CountryID
            NomineeNationality_CountryID = new (this, "x_NomineeNationality_CountryID", 3, SqlDbType.Int) {
                Name = "NomineeNationality_CountryID",
                Expression = "dbo.MTCrew.NomineeNationality_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.NomineeNationality_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeNationality_CountryID",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeNationality_CountryID", "CustomMsg"),
                IsUpload = false
            };
            NomineeNationality_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("NomineeNationality_CountryID", "MTCountry", false, "ID", new List<string> {"Nationality", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Nationality]"),
                "id-ID" => new Lookup<DbField>("NomineeNationality_CountryID", "MTCountry", false, "ID", new List<string> {"Nationality", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Nationality]"),
                _ => new Lookup<DbField>("NomineeNationality_CountryID", "MTCountry", false, "ID", new List<string> {"Nationality", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Nationality]")
            };
            Fields.Add("NomineeNationality_CountryID", NomineeNationality_CountryID);

            // NomineeAddressDetail
            NomineeAddressDetail = new (this, "x_NomineeAddressDetail", 202, SqlDbType.NVarChar) {
                Name = "NomineeAddressDetail",
                Expression = "dbo.MTCrew.NomineeAddressDetail",
                BasicSearchExpression = "dbo.MTCrew.NomineeAddressDetail",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeAddressDetail",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeAddressDetail", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeAddressDetail", NomineeAddressDetail);

            // NomineeAddressCity
            NomineeAddressCity = new (this, "x_NomineeAddressCity", 202, SqlDbType.NVarChar) {
                Name = "NomineeAddressCity",
                Expression = "dbo.MTCrew.NomineeAddressCity",
                BasicSearchExpression = "dbo.MTCrew.NomineeAddressCity",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeAddressCity",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeAddressCity", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeAddressCity", NomineeAddressCity);

            // NomineeAddressPostCode
            NomineeAddressPostCode = new (this, "x_NomineeAddressPostCode", 202, SqlDbType.NVarChar) {
                Name = "NomineeAddressPostCode",
                Expression = "dbo.MTCrew.NomineeAddressPostCode",
                BasicSearchExpression = "dbo.MTCrew.NomineeAddressPostCode",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeAddressPostCode",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeAddressPostCode", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeAddressPostCode", NomineeAddressPostCode);

            // NomineeAddressCountryID
            NomineeAddressCountryID = new (this, "x_NomineeAddressCountryID", 3, SqlDbType.Int) {
                Name = "NomineeAddressCountryID",
                Expression = "dbo.MTCrew.NomineeAddressCountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.NomineeAddressCountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeAddressCountryID",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeAddressCountryID", "CustomMsg"),
                IsUpload = false
            };
            NomineeAddressCountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("NomineeAddressCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("NomineeAddressCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("NomineeAddressCountryID", "MTCountry", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("NomineeAddressCountryID", NomineeAddressCountryID);

            // NomineeAddressHomeTel
            NomineeAddressHomeTel = new (this, "x_NomineeAddressHomeTel", 202, SqlDbType.NVarChar) {
                Name = "NomineeAddressHomeTel",
                Expression = "dbo.MTCrew.NomineeAddressHomeTel",
                BasicSearchExpression = "dbo.MTCrew.NomineeAddressHomeTel",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeAddressHomeTel",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeAddressHomeTel", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeAddressHomeTel", NomineeAddressHomeTel);

            // NomineeEmail
            NomineeEmail = new (this, "x_NomineeEmail", 202, SqlDbType.NVarChar) {
                Name = "NomineeEmail",
                Expression = "dbo.MTCrew.NomineeEmail",
                BasicSearchExpression = "dbo.MTCrew.NomineeEmail",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeEmail",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "email",
                Sortable = false, // Allow sort
                DefaultErrorMessage = Language.Phrase("IncorrectEmail"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeEmail", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeEmail", NomineeEmail);

            // NomineeMobileNumber
            NomineeMobileNumber = new (this, "x_NomineeMobileNumber", 202, SqlDbType.NVarChar) {
                Name = "NomineeMobileNumber",
                Expression = "dbo.MTCrew.NomineeMobileNumber",
                BasicSearchExpression = "dbo.MTCrew.NomineeMobileNumber",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeMobileNumber",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeMobileNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeMobileNumber", NomineeMobileNumber);

            // NSSF_Health_Number
            NSSF_Health_Number = new (this, "x_NSSF_Health_Number", 202, SqlDbType.NVarChar) {
                Name = "NSSF_Health_Number",
                Expression = "dbo.MTCrew.NSSF_Health_Number",
                BasicSearchExpression = "dbo.MTCrew.NSSF_Health_Number",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NSSF_Health_Number",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NSSF_Health_Number", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NSSF_Health_Number", NSSF_Health_Number);

            // NSSF_Occupation_Number
            NSSF_Occupation_Number = new (this, "x_NSSF_Occupation_Number", 202, SqlDbType.NVarChar) {
                Name = "NSSF_Occupation_Number",
                Expression = "dbo.MTCrew.NSSF_Occupation_Number",
                BasicSearchExpression = "dbo.MTCrew.NSSF_Occupation_Number",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NSSF_Occupation_Number",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NSSF_Occupation_Number", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NSSF_Occupation_Number", NSSF_Occupation_Number);

            // NomineeRelationshipSelect
            NomineeRelationshipSelect = new (this, "x_NomineeRelationshipSelect", 200, SqlDbType.VarChar) {
                Name = "NomineeRelationshipSelect",
                Expression = "''",
                BasicSearchExpression = "''",
                DateTimeFormat = -1,
                VirtualExpression = "''",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "SELECT",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                OptionCount = 5,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeRelationshipSelect", "CustomMsg"),
                IsUpload = false
            };
            NomineeRelationshipSelect.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("NomineeRelationshipSelect", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("NomineeRelationshipSelect", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("NomineeRelationshipSelect", "CrewPersonalDataForAdmin", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("NomineeRelationshipSelect", NomineeRelationshipSelect);

            // NomineeRelationshipDetail
            NomineeRelationshipDetail = new (this, "x_NomineeRelationshipDetail", 200, SqlDbType.VarChar) {
                Name = "NomineeRelationshipDetail",
                Expression = "''",
                BasicSearchExpression = "''",
                DateTimeFormat = -1,
                VirtualExpression = "''",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                IsCustom = true, // Custom field
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeRelationshipDetail", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeRelationshipDetail", NomineeRelationshipDetail);

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID = new (this, "x_MobileNumberCode_CountryID", 3, SqlDbType.Int) {
                Name = "MobileNumberCode_CountryID",
                Expression = "dbo.MTCrew.MobileNumberCode_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.MobileNumberCode_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.MobileNumberCode_CountryID",
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
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "MobileNumberCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            MobileNumberCode_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MobileNumberCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, MobileNumberCode_CountryID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("MobileNumberCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, MobileNumberCode_CountryID) + "',[Name])"),
                _ => new Lookup<DbField>("MobileNumberCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, MobileNumberCode_CountryID) + "',[Name])")
            };
            Fields.Add("MobileNumberCode_CountryID", MobileNumberCode_CountryID);

            // PrimaryAddressHomeTelCode_CountryID
            PrimaryAddressHomeTelCode_CountryID = new (this, "x_PrimaryAddressHomeTelCode_CountryID", 3, SqlDbType.Int) {
                Name = "PrimaryAddressHomeTelCode_CountryID",
                Expression = "dbo.MTCrew.PrimaryAddressHomeTelCode_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.PrimaryAddressHomeTelCode_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.PrimaryAddressHomeTelCode_CountryID",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "PrimaryAddressHomeTelCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            PrimaryAddressHomeTelCode_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("PrimaryAddressHomeTelCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, PrimaryAddressHomeTelCode_CountryID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("PrimaryAddressHomeTelCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, PrimaryAddressHomeTelCode_CountryID) + "',[Name])"),
                _ => new Lookup<DbField>("PrimaryAddressHomeTelCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, PrimaryAddressHomeTelCode_CountryID) + "',[Name])")
            };
            Fields.Add("PrimaryAddressHomeTelCode_CountryID", PrimaryAddressHomeTelCode_CountryID);

            // AlternativeAddressHomeTelCode_CountryID
            AlternativeAddressHomeTelCode_CountryID = new (this, "x_AlternativeAddressHomeTelCode_CountryID", 3, SqlDbType.Int) {
                Name = "AlternativeAddressHomeTelCode_CountryID",
                Expression = "dbo.MTCrew.AlternativeAddressHomeTelCode_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.AlternativeAddressHomeTelCode_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.AlternativeAddressHomeTelCode_CountryID",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "AlternativeAddressHomeTelCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            AlternativeAddressHomeTelCode_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("AlternativeAddressHomeTelCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, AlternativeAddressHomeTelCode_CountryID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("AlternativeAddressHomeTelCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, AlternativeAddressHomeTelCode_CountryID) + "',[Name])"),
                _ => new Lookup<DbField>("AlternativeAddressHomeTelCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, AlternativeAddressHomeTelCode_CountryID) + "',[Name])")
            };
            Fields.Add("AlternativeAddressHomeTelCode_CountryID", AlternativeAddressHomeTelCode_CountryID);

            // NomineeAddressHomeTelCode_CountryID
            NomineeAddressHomeTelCode_CountryID = new (this, "x_NomineeAddressHomeTelCode_CountryID", 3, SqlDbType.Int) {
                Name = "NomineeAddressHomeTelCode_CountryID",
                Expression = "dbo.MTCrew.NomineeAddressHomeTelCode_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.NomineeAddressHomeTelCode_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeAddressHomeTelCode_CountryID",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeAddressHomeTelCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            NomineeAddressHomeTelCode_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("NomineeAddressHomeTelCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, NomineeAddressHomeTelCode_CountryID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("NomineeAddressHomeTelCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, NomineeAddressHomeTelCode_CountryID) + "',[Name])"),
                _ => new Lookup<DbField>("NomineeAddressHomeTelCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, NomineeAddressHomeTelCode_CountryID) + "',[Name])")
            };
            Fields.Add("NomineeAddressHomeTelCode_CountryID", NomineeAddressHomeTelCode_CountryID);

            // NomineeMobileNumberCode_CountryID
            NomineeMobileNumberCode_CountryID = new (this, "x_NomineeMobileNumberCode_CountryID", 3, SqlDbType.Int) {
                Name = "NomineeMobileNumberCode_CountryID",
                Expression = "dbo.MTCrew.NomineeMobileNumberCode_CountryID",
                BasicSearchExpression = "CAST(dbo.MTCrew.NomineeMobileNumberCode_CountryID AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "dbo.MTCrew.NomineeMobileNumberCode_CountryID",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("CrewPersonalDataForAdmin", "NomineeMobileNumberCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            NomineeMobileNumberCode_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("NomineeMobileNumberCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, NomineeMobileNumberCode_CountryID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("NomineeMobileNumberCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, NomineeMobileNumberCode_CountryID) + "',[Name])"),
                _ => new Lookup<DbField>("NomineeMobileNumberCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, NomineeMobileNumberCode_CountryID) + "',[Name])")
            };
            Fields.Add("NomineeMobileNumberCode_CountryID", NomineeMobileNumberCode_CountryID);

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
            get => _sqlSelect ?? "SELECT dbo.MTCrew.ID, dbo.MTCrew.FullName, dbo.MTCrew.NSSF_Health_Number, dbo.MTCrew.NSSF_Occupation_Number, dbo.MTCrew.IndividualCodeNumber, dbo.MTCrew.Nationality_CountryID, dbo.MTCrew.CountryOfOrigin_CountryID, dbo.MTCrew.DateOfBirth, dbo.MTCrew.CityOfBirth, dbo.MTCrew.Gender, dbo.MTCrew.MaritalStatus, dbo.MTCrew.ReligionID, dbo.MTCrew.RankAppliedFor_RankID, dbo.MTCrew.WillAcceptLowRank, dbo.MTCrew.AvailableFrom, dbo.MTCrew.AvailableUntil, dbo.MTCrew.PrimaryAddressDetail, dbo.MTCrew.PrimaryAddressCity, dbo.MTCrew.PrimaryAddressNearestAirport, dbo.MTCrew.PrimaryAddressState, dbo.MTCrew.PrimaryAddressPostCode, dbo.MTCrew.PrimaryAddressCountryID, dbo.MTCrew.PrimaryAddressHomeTel, dbo.MTCrew.AlternativeAddressDetail, dbo.MTCrew.AlternativeAddressState, dbo.MTCrew.AlternativeAddressCity, dbo.MTCrew.AlternativeAddressHomeTel, dbo.MTCrew.AlternativeAddressPostCode, dbo.MTCrew.AlternativeAddressCountryID, dbo.MTCrew.MobileNumber, dbo.MTCrew.Email, dbo.MTCrew.EmployeeStatus, dbo.MTCrew.FormSubmittedDateTime, dbo.MTCrew.ActiveDescription, dbo.MTCrew.CreatedByUserID, dbo.MTCrew.CreatedDateTime, dbo.MTCrew.LastUpdatedByUserID, dbo.MTCrew.LastUpdatedDateTime, dbo.MTCrew.MTUserID, dbo.MTCrew.SocialSecurityNumber, dbo.MTCrew.SocialSecurityIssuingCountryID, dbo.MTCrew.SocialSecurityImage, dbo.MTCrew.PersonalTaxNumber, dbo.MTCrew.PersonalTaxIssuingCountryID, dbo.MTCrew.PersonalTaxImage, dbo.MTCrew.BloodType, dbo.MTCrew.RequiredPhoto, dbo.MTCrew.VisaPhoto, dbo.MTCrew.Status, dbo.MTCrew.Reason, dbo.MTCrew.Weight, dbo.MTCrew.Height, dbo.MTCrew.CoverallSize, dbo.MTCrew.SafetyShoesSize, dbo.MTCrew.ShirtSize, dbo.MTCrew.TrousersSize, dbo.MTCrew.NomineeFullName, dbo.MTCrew.NomineeRelationship, dbo.MTCrew.NomineeGender, dbo.MTCrew.NomineeNationality_CountryID, dbo.MTCrew.NomineeAddressDetail, dbo.MTCrew.NomineeAddressCity, dbo.MTCrew.NomineeAddressPostCode, dbo.MTCrew.NomineeAddressCountryID, dbo.MTCrew.NomineeAddressHomeTel, dbo.MTCrew.NomineeEmail, dbo.MTCrew.NomineeMobileNumber, dbo.MTCrew.MobileNumberCode_CountryID, dbo.MTCrew.PrimaryAddressHomeTelCode_CountryID, dbo.MTCrew.AlternativeAddressHomeTelCode_CountryID, dbo.MTCrew.NomineeAddressHomeTelCode_CountryID, dbo.MTCrew.NomineeMobileNumberCode_CountryID, '' AS [NomineeRelationshipSelect], '' AS [NomineeRelationshipDetail] FROM " + SqlFrom;
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
                IndividualCodeNumber.DbValue = row["IndividualCodeNumber"]; // Set DB value only
                FullName.DbValue = row["FullName"]; // Set DB value only
                RequiredPhoto.Upload.DbValue = row["RequiredPhoto"];
                VisaPhoto.Upload.DbValue = row["VisaPhoto"];
                Nationality_CountryID.DbValue = row["Nationality_CountryID"]; // Set DB value only
                CountryOfOrigin_CountryID.DbValue = row["CountryOfOrigin_CountryID"]; // Set DB value only
                DateOfBirth.DbValue = row["DateOfBirth"]; // Set DB value only
                CityOfBirth.DbValue = row["CityOfBirth"]; // Set DB value only
                Gender.DbValue = row["Gender"]; // Set DB value only
                MaritalStatus.DbValue = row["MaritalStatus"]; // Set DB value only
                ReligionID.DbValue = row["ReligionID"]; // Set DB value only
                BloodType.DbValue = row["BloodType"]; // Set DB value only
                RankAppliedFor_RankID.DbValue = row["RankAppliedFor_RankID"]; // Set DB value only
                WillAcceptLowRank.DbValue = (ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"); // Set DB value only
                AvailableFrom.DbValue = row["AvailableFrom"]; // Set DB value only
                AvailableUntil.DbValue = row["AvailableUntil"]; // Set DB value only
                PrimaryAddressDetail.DbValue = row["PrimaryAddressDetail"]; // Set DB value only
                PrimaryAddressCity.DbValue = row["PrimaryAddressCity"]; // Set DB value only
                PrimaryAddressNearestAirport.DbValue = row["PrimaryAddressNearestAirport"]; // Set DB value only
                PrimaryAddressState.DbValue = row["PrimaryAddressState"]; // Set DB value only
                PrimaryAddressPostCode.DbValue = row["PrimaryAddressPostCode"]; // Set DB value only
                PrimaryAddressCountryID.DbValue = row["PrimaryAddressCountryID"]; // Set DB value only
                PrimaryAddressHomeTel.DbValue = row["PrimaryAddressHomeTel"]; // Set DB value only
                AlternativeAddressDetail.DbValue = row["AlternativeAddressDetail"]; // Set DB value only
                AlternativeAddressState.DbValue = row["AlternativeAddressState"]; // Set DB value only
                AlternativeAddressCity.DbValue = row["AlternativeAddressCity"]; // Set DB value only
                AlternativeAddressHomeTel.DbValue = row["AlternativeAddressHomeTel"]; // Set DB value only
                AlternativeAddressPostCode.DbValue = row["AlternativeAddressPostCode"]; // Set DB value only
                AlternativeAddressCountryID.DbValue = row["AlternativeAddressCountryID"]; // Set DB value only
                MobileNumber.DbValue = row["MobileNumber"]; // Set DB value only
                _Email.DbValue = row["Email"]; // Set DB value only
                EmployeeStatus.DbValue = row["EmployeeStatus"]; // Set DB value only
                FormSubmittedDateTime.DbValue = row["FormSubmittedDateTime"]; // Set DB value only
                ActiveDescription.DbValue = row["ActiveDescription"]; // Set DB value only
                CreatedByUserID.DbValue = row["CreatedByUserID"]; // Set DB value only
                CreatedDateTime.DbValue = row["CreatedDateTime"]; // Set DB value only
                LastUpdatedByUserID.DbValue = row["LastUpdatedByUserID"]; // Set DB value only
                LastUpdatedDateTime.DbValue = row["LastUpdatedDateTime"]; // Set DB value only
                MTUserID.DbValue = row["MTUserID"]; // Set DB value only
                SocialSecurityNumber.DbValue = row["SocialSecurityNumber"]; // Set DB value only
                SocialSecurityIssuingCountryID.DbValue = row["SocialSecurityIssuingCountryID"]; // Set DB value only
                SocialSecurityImage.Upload.DbValue = row["SocialSecurityImage"];
                PersonalTaxNumber.DbValue = row["PersonalTaxNumber"]; // Set DB value only
                PersonalTaxIssuingCountryID.DbValue = row["PersonalTaxIssuingCountryID"]; // Set DB value only
                PersonalTaxImage.Upload.DbValue = row["PersonalTaxImage"];
                Status.DbValue = row["Status"]; // Set DB value only
                Reason.DbValue = row["Reason"]; // Set DB value only
                Weight.DbValue = row["Weight"]; // Set DB value only
                Height.DbValue = row["Height"]; // Set DB value only
                CoverallSize.DbValue = row["CoverallSize"]; // Set DB value only
                SafetyShoesSize.DbValue = row["SafetyShoesSize"]; // Set DB value only
                ShirtSize.DbValue = row["ShirtSize"]; // Set DB value only
                TrousersSize.DbValue = row["TrousersSize"]; // Set DB value only
                NomineeFullName.DbValue = row["NomineeFullName"]; // Set DB value only
                NomineeRelationship.DbValue = row["NomineeRelationship"]; // Set DB value only
                NomineeGender.DbValue = row["NomineeGender"]; // Set DB value only
                NomineeNationality_CountryID.DbValue = row["NomineeNationality_CountryID"]; // Set DB value only
                NomineeAddressDetail.DbValue = row["NomineeAddressDetail"]; // Set DB value only
                NomineeAddressCity.DbValue = row["NomineeAddressCity"]; // Set DB value only
                NomineeAddressPostCode.DbValue = row["NomineeAddressPostCode"]; // Set DB value only
                NomineeAddressCountryID.DbValue = row["NomineeAddressCountryID"]; // Set DB value only
                NomineeAddressHomeTel.DbValue = row["NomineeAddressHomeTel"]; // Set DB value only
                NomineeEmail.DbValue = row["NomineeEmail"]; // Set DB value only
                NomineeMobileNumber.DbValue = row["NomineeMobileNumber"]; // Set DB value only
                NSSF_Health_Number.DbValue = row["NSSF_Health_Number"]; // Set DB value only
                NSSF_Occupation_Number.DbValue = row["NSSF_Occupation_Number"]; // Set DB value only
                NomineeRelationshipSelect.DbValue = row["NomineeRelationshipSelect"]; // Set DB value only
                NomineeRelationshipDetail.DbValue = row["NomineeRelationshipDetail"]; // Set DB value only
                MobileNumberCode_CountryID.DbValue = row["MobileNumberCode_CountryID"]; // Set DB value only
                PrimaryAddressHomeTelCode_CountryID.DbValue = row["PrimaryAddressHomeTelCode_CountryID"]; // Set DB value only
                AlternativeAddressHomeTelCode_CountryID.DbValue = row["AlternativeAddressHomeTelCode_CountryID"]; // Set DB value only
                NomineeAddressHomeTelCode_CountryID.DbValue = row["NomineeAddressHomeTelCode_CountryID"]; // Set DB value only
                NomineeMobileNumberCode_CountryID.DbValue = row["NomineeMobileNumberCode_CountryID"]; // Set DB value only
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
            SocialSecurityImage.OldUploadPath = SocialSecurityImage.GetUploadPath();
            if (!Empty(row["SocialSecurityImage"])) {
                DeleteFile(SocialSecurityImage.OldPhysicalUploadPath + row["SocialSecurityImage"]);
            }
            PersonalTaxImage.OldUploadPath = PersonalTaxImage.GetUploadPath();
            if (!Empty(row["PersonalTaxImage"])) {
                DeleteFile(PersonalTaxImage.OldPhysicalUploadPath + row["PersonalTaxImage"]);
            }
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
                    return "CrewPersonalDataForAdminList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "CrewPersonalDataForAdminView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "CrewPersonalDataForAdminEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "CrewPersonalDataForAdminAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "CrewPersonalDataForAdminList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "CrewPersonalDataForAdminView",
                Config.ApiAddAction => "CrewPersonalDataForAdminAdd",
                Config.ApiEditAction => "CrewPersonalDataForAdminEdit",
                Config.ApiDeleteAction => "CrewPersonalDataForAdminDelete",
                Config.ApiListAction => "CrewPersonalDataForAdminList",
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
        public string ListUrl => "CrewPersonalDataForAdminList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("CrewPersonalDataForAdminView", parm);
            else
                url = KeyUrl("CrewPersonalDataForAdminView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "CrewPersonalDataForAdminAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "CrewPersonalDataForAdminAdd?" + parm;
            else
                url = "CrewPersonalDataForAdminAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("CrewPersonalDataForAdminEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewPersonalDataForAdminList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("CrewPersonalDataForAdminAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("CrewPersonalDataForAdminList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("CrewPersonalDataForAdminDelete")); // DN

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
            RequiredPhoto.Upload.DbValue = dr["RequiredPhoto"];
            RequiredPhoto.SetDbValue(RequiredPhoto.Upload.DbValue);
            VisaPhoto.Upload.DbValue = dr["VisaPhoto"];
            VisaPhoto.SetDbValue(VisaPhoto.Upload.DbValue);
            Nationality_CountryID.SetDbValue(dr["Nationality_CountryID"]);
            CountryOfOrigin_CountryID.SetDbValue(dr["CountryOfOrigin_CountryID"]);
            DateOfBirth.SetDbValue(dr["DateOfBirth"]);
            CityOfBirth.SetDbValue(dr["CityOfBirth"]);
            Gender.SetDbValue(dr["Gender"]);
            MaritalStatus.SetDbValue(dr["MaritalStatus"]);
            ReligionID.SetDbValue(dr["ReligionID"]);
            BloodType.SetDbValue(dr["BloodType"]);
            RankAppliedFor_RankID.SetDbValue(dr["RankAppliedFor_RankID"]);
            WillAcceptLowRank.SetDbValue(ConvertToBool(dr["WillAcceptLowRank"]) ? "1" : "0");
            AvailableFrom.SetDbValue(dr["AvailableFrom"]);
            AvailableUntil.SetDbValue(dr["AvailableUntil"]);
            PrimaryAddressDetail.SetDbValue(dr["PrimaryAddressDetail"]);
            PrimaryAddressCity.SetDbValue(dr["PrimaryAddressCity"]);
            PrimaryAddressNearestAirport.SetDbValue(dr["PrimaryAddressNearestAirport"]);
            PrimaryAddressState.SetDbValue(dr["PrimaryAddressState"]);
            PrimaryAddressPostCode.SetDbValue(dr["PrimaryAddressPostCode"]);
            PrimaryAddressCountryID.SetDbValue(dr["PrimaryAddressCountryID"]);
            PrimaryAddressHomeTel.SetDbValue(dr["PrimaryAddressHomeTel"]);
            AlternativeAddressDetail.SetDbValue(dr["AlternativeAddressDetail"]);
            AlternativeAddressState.SetDbValue(dr["AlternativeAddressState"]);
            AlternativeAddressCity.SetDbValue(dr["AlternativeAddressCity"]);
            AlternativeAddressHomeTel.SetDbValue(dr["AlternativeAddressHomeTel"]);
            AlternativeAddressPostCode.SetDbValue(dr["AlternativeAddressPostCode"]);
            AlternativeAddressCountryID.SetDbValue(dr["AlternativeAddressCountryID"]);
            MobileNumber.SetDbValue(dr["MobileNumber"]);
            _Email.SetDbValue(dr["Email"]);
            EmployeeStatus.SetDbValue(dr["EmployeeStatus"]);
            FormSubmittedDateTime.SetDbValue(dr["FormSubmittedDateTime"]);
            ActiveDescription.SetDbValue(dr["ActiveDescription"]);
            CreatedByUserID.SetDbValue(dr["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(dr["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(dr["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(dr["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(dr["MTUserID"]);
            SocialSecurityNumber.SetDbValue(dr["SocialSecurityNumber"]);
            SocialSecurityIssuingCountryID.SetDbValue(dr["SocialSecurityIssuingCountryID"]);
            SocialSecurityImage.Upload.DbValue = dr["SocialSecurityImage"];
            SocialSecurityImage.SetDbValue(SocialSecurityImage.Upload.DbValue);
            PersonalTaxNumber.SetDbValue(dr["PersonalTaxNumber"]);
            PersonalTaxIssuingCountryID.SetDbValue(dr["PersonalTaxIssuingCountryID"]);
            PersonalTaxImage.Upload.DbValue = dr["PersonalTaxImage"];
            PersonalTaxImage.SetDbValue(PersonalTaxImage.Upload.DbValue);
            Status.SetDbValue(dr["Status"]);
            Reason.SetDbValue(dr["Reason"]);
            Weight.SetDbValue(dr["Weight"]);
            Height.SetDbValue(dr["Height"]);
            CoverallSize.SetDbValue(dr["CoverallSize"]);
            SafetyShoesSize.SetDbValue(dr["SafetyShoesSize"]);
            ShirtSize.SetDbValue(dr["ShirtSize"]);
            TrousersSize.SetDbValue(dr["TrousersSize"]);
            NomineeFullName.SetDbValue(dr["NomineeFullName"]);
            NomineeRelationship.SetDbValue(dr["NomineeRelationship"]);
            NomineeGender.SetDbValue(dr["NomineeGender"]);
            NomineeNationality_CountryID.SetDbValue(dr["NomineeNationality_CountryID"]);
            NomineeAddressDetail.SetDbValue(dr["NomineeAddressDetail"]);
            NomineeAddressCity.SetDbValue(dr["NomineeAddressCity"]);
            NomineeAddressPostCode.SetDbValue(dr["NomineeAddressPostCode"]);
            NomineeAddressCountryID.SetDbValue(dr["NomineeAddressCountryID"]);
            NomineeAddressHomeTel.SetDbValue(dr["NomineeAddressHomeTel"]);
            NomineeEmail.SetDbValue(dr["NomineeEmail"]);
            NomineeMobileNumber.SetDbValue(dr["NomineeMobileNumber"]);
            NSSF_Health_Number.SetDbValue(dr["NSSF_Health_Number"]);
            NSSF_Occupation_Number.SetDbValue(dr["NSSF_Occupation_Number"]);
            NomineeRelationshipSelect.SetDbValue(dr["NomineeRelationshipSelect"]);
            NomineeRelationshipDetail.SetDbValue(dr["NomineeRelationshipDetail"]);
            MobileNumberCode_CountryID.SetDbValue(dr["MobileNumberCode_CountryID"]);
            PrimaryAddressHomeTelCode_CountryID.SetDbValue(dr["PrimaryAddressHomeTelCode_CountryID"]);
            AlternativeAddressHomeTelCode_CountryID.SetDbValue(dr["AlternativeAddressHomeTelCode_CountryID"]);
            NomineeAddressHomeTelCode_CountryID.SetDbValue(dr["NomineeAddressHomeTelCode_CountryID"]);
            NomineeMobileNumberCode_CountryID.SetDbValue(dr["NomineeMobileNumberCode_CountryID"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "CrewPersonalDataForAdminList";
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

            // Nationality_CountryID
            Nationality_CountryID.CellCssStyle = "white-space: nowrap;";

            // CountryOfOrigin_CountryID
            CountryOfOrigin_CountryID.CellCssStyle = "white-space: nowrap;";

            // DateOfBirth
            DateOfBirth.CellCssStyle = "white-space: nowrap;";

            // CityOfBirth
            CityOfBirth.CellCssStyle = "white-space: nowrap;";

            // Gender
            Gender.CellCssStyle = "white-space: nowrap;";

            // MaritalStatus
            MaritalStatus.CellCssStyle = "white-space: nowrap;";

            // ReligionID
            ReligionID.CellCssStyle = "white-space: nowrap;";

            // BloodType
            BloodType.CellCssStyle = "white-space: nowrap;";

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.CellCssStyle = "white-space: nowrap;";

            // WillAcceptLowRank
            WillAcceptLowRank.CellCssStyle = "white-space: nowrap;";

            // AvailableFrom
            AvailableFrom.CellCssStyle = "white-space: nowrap;";

            // AvailableUntil
            AvailableUntil.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressDetail
            PrimaryAddressDetail.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressCity
            PrimaryAddressCity.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressState
            PrimaryAddressState.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressDetail
            AlternativeAddressDetail.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressState
            AlternativeAddressState.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressCity
            AlternativeAddressCity.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressHomeTel
            AlternativeAddressHomeTel.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressPostCode
            AlternativeAddressPostCode.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressCountryID
            AlternativeAddressCountryID.CellCssStyle = "white-space: nowrap;";

            // MobileNumber
            MobileNumber.CellCssStyle = "white-space: nowrap;";

            // Email
            _Email.CellCssStyle = "white-space: nowrap;";

            // EmployeeStatus
            EmployeeStatus.CellCssStyle = "white-space: nowrap;";

            // FormSubmittedDateTime
            FormSubmittedDateTime.CellCssStyle = "white-space: nowrap;";

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

            // SocialSecurityNumber
            SocialSecurityNumber.CellCssStyle = "white-space: nowrap;";

            // SocialSecurityIssuingCountryID
            SocialSecurityIssuingCountryID.CellCssStyle = "white-space: nowrap;";

            // SocialSecurityImage
            SocialSecurityImage.CellCssStyle = "white-space: nowrap;";

            // PersonalTaxNumber
            PersonalTaxNumber.CellCssStyle = "white-space: nowrap;";

            // PersonalTaxIssuingCountryID
            PersonalTaxIssuingCountryID.CellCssStyle = "white-space: nowrap;";

            // PersonalTaxImage
            PersonalTaxImage.CellCssStyle = "white-space: nowrap;";

            // Status
            Status.CellCssStyle = "white-space: nowrap;";

            // Reason
            Reason.CellCssStyle = "white-space: nowrap;";

            // Weight
            Weight.CellCssStyle = "white-space: nowrap;";

            // Height
            Height.CellCssStyle = "white-space: nowrap;";

            // CoverallSize
            CoverallSize.CellCssStyle = "white-space: nowrap;";

            // SafetyShoesSize
            SafetyShoesSize.CellCssStyle = "white-space: nowrap;";

            // ShirtSize
            ShirtSize.CellCssStyle = "white-space: nowrap;";

            // TrousersSize
            TrousersSize.CellCssStyle = "white-space: nowrap;";

            // NomineeFullName
            NomineeFullName.CellCssStyle = "white-space: nowrap;";

            // NomineeRelationship
            NomineeRelationship.CellCssStyle = "white-space: nowrap;";

            // NomineeGender
            NomineeGender.CellCssStyle = "white-space: nowrap;";

            // NomineeNationality_CountryID
            NomineeNationality_CountryID.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressDetail
            NomineeAddressDetail.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressCity
            NomineeAddressCity.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressPostCode
            NomineeAddressPostCode.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressCountryID
            NomineeAddressCountryID.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressHomeTel
            NomineeAddressHomeTel.CellCssStyle = "white-space: nowrap;";

            // NomineeEmail
            NomineeEmail.CellCssStyle = "white-space: nowrap;";

            // NomineeMobileNumber
            NomineeMobileNumber.CellCssStyle = "white-space: nowrap;";

            // NSSF_Health_Number
            NSSF_Health_Number.CellCssStyle = "white-space: nowrap;";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.CellCssStyle = "white-space: nowrap;";

            // NomineeRelationshipSelect
            NomineeRelationshipSelect.CellCssStyle = "white-space: nowrap;";

            // NomineeRelationshipDetail
            NomineeRelationshipDetail.CellCssStyle = "white-space: nowrap;";

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressHomeTelCode_CountryID
            PrimaryAddressHomeTelCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressHomeTelCode_CountryID
            AlternativeAddressHomeTelCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // NomineeAddressHomeTelCode_CountryID
            NomineeAddressHomeTelCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // NomineeMobileNumberCode_CountryID
            NomineeMobileNumberCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // ID
            ID.ViewValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

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
            VisaPhoto.ViewCustomAttributes = "";

            // Nationality_CountryID
            curVal = ConvertToString(Nationality_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (Nationality_CountryID.Lookup != null && IsDictionary(Nationality_CountryID.Lookup?.Options) && Nationality_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    Nationality_CountryID.ViewValue = Nationality_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", Nationality_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = Nationality_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && Nationality_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = Nationality_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        Nationality_CountryID.ViewValue = Nationality_CountryID.HighlightLookup(ConvertToString(rswrk[0]), Nationality_CountryID.DisplayValue(listwrk));
                    } else {
                        Nationality_CountryID.ViewValue = FormatNumber(Nationality_CountryID.CurrentValue, Nationality_CountryID.FormatPattern);
                    }
                }
            } else {
                Nationality_CountryID.ViewValue = DbNullValue;
            }
            Nationality_CountryID.ViewCustomAttributes = "";

            // CountryOfOrigin_CountryID
            curVal = ConvertToString(CountryOfOrigin_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (CountryOfOrigin_CountryID.Lookup != null && IsDictionary(CountryOfOrigin_CountryID.Lookup?.Options) && CountryOfOrigin_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CountryOfOrigin_CountryID.ViewValue = CountryOfOrigin_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", CountryOfOrigin_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = CountryOfOrigin_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && CountryOfOrigin_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = CountryOfOrigin_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        CountryOfOrigin_CountryID.ViewValue = CountryOfOrigin_CountryID.HighlightLookup(ConvertToString(rswrk[0]), CountryOfOrigin_CountryID.DisplayValue(listwrk));
                    } else {
                        CountryOfOrigin_CountryID.ViewValue = FormatNumber(CountryOfOrigin_CountryID.CurrentValue, CountryOfOrigin_CountryID.FormatPattern);
                    }
                }
            } else {
                CountryOfOrigin_CountryID.ViewValue = DbNullValue;
            }
            CountryOfOrigin_CountryID.ViewCustomAttributes = "";

            // DateOfBirth
            DateOfBirth.ViewValue = DateOfBirth.CurrentValue;
            DateOfBirth.ViewValue = FormatDateTime(DateOfBirth.ViewValue, DateOfBirth.FormatPattern);
            DateOfBirth.ViewCustomAttributes = "";

            // CityOfBirth
            CityOfBirth.ViewValue = ConvertToString(CityOfBirth.CurrentValue); // DN
            CityOfBirth.ViewCustomAttributes = "";

            // Gender
            if (!Empty(Gender.CurrentValue)) {
                Gender.ViewValue = Gender.HighlightLookup(ConvertToString(Gender.CurrentValue), Gender.OptionCaption(ConvertToString(Gender.CurrentValue)));
            } else {
                Gender.ViewValue = DbNullValue;
            }
            Gender.ViewCustomAttributes = "";

            // MaritalStatus
            if (!Empty(MaritalStatus.CurrentValue)) {
                MaritalStatus.ViewValue = MaritalStatus.HighlightLookup(ConvertToString(MaritalStatus.CurrentValue), MaritalStatus.OptionCaption(ConvertToString(MaritalStatus.CurrentValue)));
            } else {
                MaritalStatus.ViewValue = DbNullValue;
            }
            MaritalStatus.ViewCustomAttributes = "";

            // ReligionID
            curVal = ConvertToString(ReligionID.CurrentValue);
            if (!Empty(curVal)) {
                if (ReligionID.Lookup != null && IsDictionary(ReligionID.Lookup?.Options) && ReligionID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ReligionID.ViewValue = ReligionID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", ReligionID.CurrentValue, DataType.Number, "");
                    sqlWrk = ReligionID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && ReligionID.Lookup != null) { // Lookup values found
                        var listwrk = ReligionID.Lookup?.RenderViewRow(rswrk[0]);
                        ReligionID.ViewValue = ReligionID.HighlightLookup(ConvertToString(rswrk[0]), ReligionID.DisplayValue(listwrk));
                    } else {
                        ReligionID.ViewValue = FormatNumber(ReligionID.CurrentValue, ReligionID.FormatPattern);
                    }
                }
            } else {
                ReligionID.ViewValue = DbNullValue;
            }
            ReligionID.ViewCustomAttributes = "";

            // BloodType
            if (!Empty(BloodType.CurrentValue)) {
                BloodType.ViewValue = BloodType.HighlightLookup(ConvertToString(BloodType.CurrentValue), BloodType.OptionCaption(ConvertToString(BloodType.CurrentValue)));
            } else {
                BloodType.ViewValue = DbNullValue;
            }
            BloodType.ViewCustomAttributes = "";

            // RankAppliedFor_RankID
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

            // PrimaryAddressDetail
            PrimaryAddressDetail.ViewValue = PrimaryAddressDetail.CurrentValue;
            PrimaryAddressDetail.ViewCustomAttributes = "";

            // PrimaryAddressCity
            PrimaryAddressCity.ViewValue = ConvertToString(PrimaryAddressCity.CurrentValue); // DN
            PrimaryAddressCity.ViewCustomAttributes = "";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.ViewValue = ConvertToString(PrimaryAddressNearestAirport.CurrentValue); // DN
            PrimaryAddressNearestAirport.ViewCustomAttributes = "";

            // PrimaryAddressState
            PrimaryAddressState.ViewValue = ConvertToString(PrimaryAddressState.CurrentValue); // DN
            PrimaryAddressState.ViewCustomAttributes = "";

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.ViewValue = ConvertToString(PrimaryAddressPostCode.CurrentValue); // DN
            PrimaryAddressPostCode.ViewCustomAttributes = "";

            // PrimaryAddressCountryID
            curVal = ConvertToString(PrimaryAddressCountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (PrimaryAddressCountryID.Lookup != null && IsDictionary(PrimaryAddressCountryID.Lookup?.Options) && PrimaryAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PrimaryAddressCountryID.ViewValue = PrimaryAddressCountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", PrimaryAddressCountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = PrimaryAddressCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && PrimaryAddressCountryID.Lookup != null) { // Lookup values found
                        var listwrk = PrimaryAddressCountryID.Lookup?.RenderViewRow(rswrk[0]);
                        PrimaryAddressCountryID.ViewValue = PrimaryAddressCountryID.HighlightLookup(ConvertToString(rswrk[0]), PrimaryAddressCountryID.DisplayValue(listwrk));
                    } else {
                        PrimaryAddressCountryID.ViewValue = FormatNumber(PrimaryAddressCountryID.CurrentValue, PrimaryAddressCountryID.FormatPattern);
                    }
                }
            } else {
                PrimaryAddressCountryID.ViewValue = DbNullValue;
            }
            PrimaryAddressCountryID.ViewCustomAttributes = "";

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.ViewValue = ConvertToString(PrimaryAddressHomeTel.CurrentValue); // DN
            PrimaryAddressHomeTel.ViewCustomAttributes = "";

            // AlternativeAddressDetail
            AlternativeAddressDetail.ViewValue = AlternativeAddressDetail.CurrentValue;
            AlternativeAddressDetail.ViewCustomAttributes = "";

            // AlternativeAddressState
            AlternativeAddressState.ViewValue = ConvertToString(AlternativeAddressState.CurrentValue); // DN
            AlternativeAddressState.ViewCustomAttributes = "";

            // AlternativeAddressCity
            AlternativeAddressCity.ViewValue = ConvertToString(AlternativeAddressCity.CurrentValue); // DN
            AlternativeAddressCity.ViewCustomAttributes = "";

            // AlternativeAddressHomeTel
            AlternativeAddressHomeTel.ViewValue = ConvertToString(AlternativeAddressHomeTel.CurrentValue); // DN
            AlternativeAddressHomeTel.ViewCustomAttributes = "";

            // AlternativeAddressPostCode
            AlternativeAddressPostCode.ViewValue = ConvertToString(AlternativeAddressPostCode.CurrentValue); // DN
            AlternativeAddressPostCode.ViewCustomAttributes = "";

            // AlternativeAddressCountryID
            curVal = ConvertToString(AlternativeAddressCountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (AlternativeAddressCountryID.Lookup != null && IsDictionary(AlternativeAddressCountryID.Lookup?.Options) && AlternativeAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    AlternativeAddressCountryID.ViewValue = AlternativeAddressCountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", AlternativeAddressCountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = AlternativeAddressCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && AlternativeAddressCountryID.Lookup != null) { // Lookup values found
                        var listwrk = AlternativeAddressCountryID.Lookup?.RenderViewRow(rswrk[0]);
                        AlternativeAddressCountryID.ViewValue = AlternativeAddressCountryID.HighlightLookup(ConvertToString(rswrk[0]), AlternativeAddressCountryID.DisplayValue(listwrk));
                    } else {
                        AlternativeAddressCountryID.ViewValue = FormatNumber(AlternativeAddressCountryID.CurrentValue, AlternativeAddressCountryID.FormatPattern);
                    }
                }
            } else {
                AlternativeAddressCountryID.ViewValue = DbNullValue;
            }
            AlternativeAddressCountryID.ViewCustomAttributes = "";

            // MobileNumber
            MobileNumber.ViewValue = ConvertToString(MobileNumber.CurrentValue); // DN
            MobileNumber.ViewCustomAttributes = "";

            // Email
            _Email.ViewValue = ConvertToString(_Email.CurrentValue); // DN
            _Email.ViewCustomAttributes = "";

            // EmployeeStatus
            EmployeeStatus.ViewValue = ConvertToString(EmployeeStatus.CurrentValue); // DN
            EmployeeStatus.ViewCustomAttributes = "";

            // FormSubmittedDateTime
            FormSubmittedDateTime.ViewValue = FormSubmittedDateTime.CurrentValue;
            FormSubmittedDateTime.ViewValue = FormatDateTime(FormSubmittedDateTime.ViewValue, FormSubmittedDateTime.FormatPattern);
            FormSubmittedDateTime.ViewCustomAttributes = "";

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

            // SocialSecurityNumber
            SocialSecurityNumber.ViewValue = ConvertToString(SocialSecurityNumber.CurrentValue); // DN
            SocialSecurityNumber.ViewCustomAttributes = "";

            // SocialSecurityIssuingCountryID
            curVal = ConvertToString(SocialSecurityIssuingCountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (SocialSecurityIssuingCountryID.Lookup != null && IsDictionary(SocialSecurityIssuingCountryID.Lookup?.Options) && SocialSecurityIssuingCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    SocialSecurityIssuingCountryID.ViewValue = SocialSecurityIssuingCountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", SocialSecurityIssuingCountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = SocialSecurityIssuingCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && SocialSecurityIssuingCountryID.Lookup != null) { // Lookup values found
                        var listwrk = SocialSecurityIssuingCountryID.Lookup?.RenderViewRow(rswrk[0]);
                        SocialSecurityIssuingCountryID.ViewValue = SocialSecurityIssuingCountryID.HighlightLookup(ConvertToString(rswrk[0]), SocialSecurityIssuingCountryID.DisplayValue(listwrk));
                    } else {
                        SocialSecurityIssuingCountryID.ViewValue = FormatNumber(SocialSecurityIssuingCountryID.CurrentValue, SocialSecurityIssuingCountryID.FormatPattern);
                    }
                }
            } else {
                SocialSecurityIssuingCountryID.ViewValue = DbNullValue;
            }
            SocialSecurityIssuingCountryID.ViewCustomAttributes = "";

            // SocialSecurityImage
            SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
            if (!IsNull(SocialSecurityImage.Upload.DbValue)) {
                SocialSecurityImage.ImageWidth = 200;
                SocialSecurityImage.ImageHeight = 0;
                SocialSecurityImage.ImageAlt = SocialSecurityImage.Alt;
                SocialSecurityImage.ImageCssClass = "ew-image";
                SocialSecurityImage.ViewValue = SocialSecurityImage.Upload.DbValue;
            } else {
                SocialSecurityImage.ViewValue = "";
            }
            SocialSecurityImage.ViewCustomAttributes = "";

            // PersonalTaxNumber
            PersonalTaxNumber.ViewValue = ConvertToString(PersonalTaxNumber.CurrentValue); // DN
            PersonalTaxNumber.ViewCustomAttributes = "";

            // PersonalTaxIssuingCountryID
            curVal = ConvertToString(PersonalTaxIssuingCountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (PersonalTaxIssuingCountryID.Lookup != null && IsDictionary(PersonalTaxIssuingCountryID.Lookup?.Options) && PersonalTaxIssuingCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PersonalTaxIssuingCountryID.ViewValue = PersonalTaxIssuingCountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", PersonalTaxIssuingCountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = PersonalTaxIssuingCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && PersonalTaxIssuingCountryID.Lookup != null) { // Lookup values found
                        var listwrk = PersonalTaxIssuingCountryID.Lookup?.RenderViewRow(rswrk[0]);
                        PersonalTaxIssuingCountryID.ViewValue = PersonalTaxIssuingCountryID.HighlightLookup(ConvertToString(rswrk[0]), PersonalTaxIssuingCountryID.DisplayValue(listwrk));
                    } else {
                        PersonalTaxIssuingCountryID.ViewValue = FormatNumber(PersonalTaxIssuingCountryID.CurrentValue, PersonalTaxIssuingCountryID.FormatPattern);
                    }
                }
            } else {
                PersonalTaxIssuingCountryID.ViewValue = DbNullValue;
            }
            PersonalTaxIssuingCountryID.ViewCustomAttributes = "";

            // PersonalTaxImage
            PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
            if (!IsNull(PersonalTaxImage.Upload.DbValue)) {
                PersonalTaxImage.ImageWidth = 200;
                PersonalTaxImage.ImageHeight = 0;
                PersonalTaxImage.ImageAlt = PersonalTaxImage.Alt;
                PersonalTaxImage.ImageCssClass = "ew-image";
                PersonalTaxImage.ViewValue = PersonalTaxImage.Upload.DbValue;
            } else {
                PersonalTaxImage.ViewValue = "";
            }
            PersonalTaxImage.ViewCustomAttributes = "";

            // Status
            Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
            Status.ViewCustomAttributes = "";

            // Reason
            Reason.ViewValue = Reason.CurrentValue;
            Reason.ViewCustomAttributes = "";

            // Weight
            Weight.ViewValue = Weight.CurrentValue;
            Weight.ViewCustomAttributes = "";

            // Height
            Height.ViewValue = Height.CurrentValue;
            Height.ViewCustomAttributes = "";

            // CoverallSize
            curVal = ConvertToString(CoverallSize.CurrentValue);
            if (!Empty(curVal)) {
                if (CoverallSize.Lookup != null && IsDictionary(CoverallSize.Lookup?.Options) && CoverallSize.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    CoverallSize.ViewValue = CoverallSize.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[Name]", "=", CoverallSize.CurrentValue, DataType.String, "");
                    sqlWrk = CoverallSize.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && CoverallSize.Lookup != null) { // Lookup values found
                        var listwrk = CoverallSize.Lookup?.RenderViewRow(rswrk[0]);
                        CoverallSize.ViewValue = CoverallSize.HighlightLookup(ConvertToString(rswrk[0]), CoverallSize.DisplayValue(listwrk));
                    } else {
                        CoverallSize.ViewValue = CoverallSize.CurrentValue;
                    }
                }
            } else {
                CoverallSize.ViewValue = DbNullValue;
            }
            CoverallSize.ViewCustomAttributes = "";

            // SafetyShoesSize
            if (!Empty(SafetyShoesSize.CurrentValue)) {
                SafetyShoesSize.ViewValue = SafetyShoesSize.HighlightLookup(ConvertToString(SafetyShoesSize.CurrentValue), SafetyShoesSize.OptionCaption(ConvertToString(SafetyShoesSize.CurrentValue)));
            } else {
                SafetyShoesSize.ViewValue = DbNullValue;
            }
            SafetyShoesSize.ViewCustomAttributes = "";

            // ShirtSize
            curVal = ConvertToString(ShirtSize.CurrentValue);
            if (!Empty(curVal)) {
                if (ShirtSize.Lookup != null && IsDictionary(ShirtSize.Lookup?.Options) && ShirtSize.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    ShirtSize.ViewValue = ShirtSize.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[Name]", "=", ShirtSize.CurrentValue, DataType.String, "");
                    sqlWrk = ShirtSize.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && ShirtSize.Lookup != null) { // Lookup values found
                        var listwrk = ShirtSize.Lookup?.RenderViewRow(rswrk[0]);
                        ShirtSize.ViewValue = ShirtSize.HighlightLookup(ConvertToString(rswrk[0]), ShirtSize.DisplayValue(listwrk));
                    } else {
                        ShirtSize.ViewValue = ShirtSize.CurrentValue;
                    }
                }
            } else {
                ShirtSize.ViewValue = DbNullValue;
            }
            ShirtSize.ViewCustomAttributes = "";

            // TrousersSize
            curVal = ConvertToString(TrousersSize.CurrentValue);
            if (!Empty(curVal)) {
                if (TrousersSize.Lookup != null && IsDictionary(TrousersSize.Lookup?.Options) && TrousersSize.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    TrousersSize.ViewValue = TrousersSize.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[Name]", "=", TrousersSize.CurrentValue, DataType.String, "");
                    sqlWrk = TrousersSize.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && TrousersSize.Lookup != null) { // Lookup values found
                        var listwrk = TrousersSize.Lookup?.RenderViewRow(rswrk[0]);
                        TrousersSize.ViewValue = TrousersSize.HighlightLookup(ConvertToString(rswrk[0]), TrousersSize.DisplayValue(listwrk));
                    } else {
                        TrousersSize.ViewValue = TrousersSize.CurrentValue;
                    }
                }
            } else {
                TrousersSize.ViewValue = DbNullValue;
            }
            TrousersSize.ViewCustomAttributes = "";

            // NomineeFullName
            NomineeFullName.ViewValue = ConvertToString(NomineeFullName.CurrentValue); // DN
            NomineeFullName.ViewCustomAttributes = "";

            // NomineeRelationship
            NomineeRelationship.ViewValue = ConvertToString(NomineeRelationship.CurrentValue); // DN
            NomineeRelationship.ViewCustomAttributes = "";

            // NomineeGender
            if (!Empty(NomineeGender.CurrentValue)) {
                NomineeGender.ViewValue = NomineeGender.HighlightLookup(ConvertToString(NomineeGender.CurrentValue), NomineeGender.OptionCaption(ConvertToString(NomineeGender.CurrentValue)));
            } else {
                NomineeGender.ViewValue = DbNullValue;
            }
            NomineeGender.ViewCustomAttributes = "";

            // NomineeNationality_CountryID
            curVal = ConvertToString(NomineeNationality_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (NomineeNationality_CountryID.Lookup != null && IsDictionary(NomineeNationality_CountryID.Lookup?.Options) && NomineeNationality_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeNationality_CountryID.ViewValue = NomineeNationality_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", NomineeNationality_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = NomineeNationality_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && NomineeNationality_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = NomineeNationality_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        NomineeNationality_CountryID.ViewValue = NomineeNationality_CountryID.HighlightLookup(ConvertToString(rswrk[0]), NomineeNationality_CountryID.DisplayValue(listwrk));
                    } else {
                        NomineeNationality_CountryID.ViewValue = FormatNumber(NomineeNationality_CountryID.CurrentValue, NomineeNationality_CountryID.FormatPattern);
                    }
                }
            } else {
                NomineeNationality_CountryID.ViewValue = DbNullValue;
            }
            NomineeNationality_CountryID.ViewCustomAttributes = "";

            // NomineeAddressDetail
            NomineeAddressDetail.ViewValue = NomineeAddressDetail.CurrentValue;
            NomineeAddressDetail.ViewCustomAttributes = "";

            // NomineeAddressCity
            NomineeAddressCity.ViewValue = ConvertToString(NomineeAddressCity.CurrentValue); // DN
            NomineeAddressCity.ViewCustomAttributes = "";

            // NomineeAddressPostCode
            NomineeAddressPostCode.ViewValue = ConvertToString(NomineeAddressPostCode.CurrentValue); // DN
            NomineeAddressPostCode.ViewCustomAttributes = "";

            // NomineeAddressCountryID
            curVal = ConvertToString(NomineeAddressCountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (NomineeAddressCountryID.Lookup != null && IsDictionary(NomineeAddressCountryID.Lookup?.Options) && NomineeAddressCountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeAddressCountryID.ViewValue = NomineeAddressCountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", NomineeAddressCountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = NomineeAddressCountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && NomineeAddressCountryID.Lookup != null) { // Lookup values found
                        var listwrk = NomineeAddressCountryID.Lookup?.RenderViewRow(rswrk[0]);
                        NomineeAddressCountryID.ViewValue = NomineeAddressCountryID.HighlightLookup(ConvertToString(rswrk[0]), NomineeAddressCountryID.DisplayValue(listwrk));
                    } else {
                        NomineeAddressCountryID.ViewValue = FormatNumber(NomineeAddressCountryID.CurrentValue, NomineeAddressCountryID.FormatPattern);
                    }
                }
            } else {
                NomineeAddressCountryID.ViewValue = DbNullValue;
            }
            NomineeAddressCountryID.ViewCustomAttributes = "";

            // NomineeAddressHomeTel
            NomineeAddressHomeTel.ViewValue = ConvertToString(NomineeAddressHomeTel.CurrentValue); // DN
            NomineeAddressHomeTel.ViewCustomAttributes = "";

            // NomineeEmail
            NomineeEmail.ViewValue = ConvertToString(NomineeEmail.CurrentValue); // DN
            NomineeEmail.ViewCustomAttributes = "";

            // NomineeMobileNumber
            NomineeMobileNumber.ViewValue = ConvertToString(NomineeMobileNumber.CurrentValue); // DN
            NomineeMobileNumber.ViewCustomAttributes = "";

            // NSSF_Health_Number
            NSSF_Health_Number.ViewValue = ConvertToString(NSSF_Health_Number.CurrentValue); // DN
            NSSF_Health_Number.ViewCustomAttributes = "";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.ViewValue = ConvertToString(NSSF_Occupation_Number.CurrentValue); // DN
            NSSF_Occupation_Number.ViewCustomAttributes = "";

            // NomineeRelationshipSelect
            if (!Empty(NomineeRelationshipSelect.CurrentValue)) {
                NomineeRelationshipSelect.ViewValue = NomineeRelationshipSelect.HighlightLookup(ConvertToString(NomineeRelationshipSelect.CurrentValue), NomineeRelationshipSelect.OptionCaption(ConvertToString(NomineeRelationshipSelect.CurrentValue)));
            } else {
                NomineeRelationshipSelect.ViewValue = DbNullValue;
            }
            NomineeRelationshipSelect.ViewCustomAttributes = "";

            // NomineeRelationshipDetail
            NomineeRelationshipDetail.ViewValue = ConvertToString(NomineeRelationshipDetail.CurrentValue); // DN
            NomineeRelationshipDetail.ViewCustomAttributes = "";

            // MobileNumberCode_CountryID
            curVal = ConvertToString(MobileNumberCode_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (MobileNumberCode_CountryID.Lookup != null && IsDictionary(MobileNumberCode_CountryID.Lookup?.Options) && MobileNumberCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    MobileNumberCode_CountryID.ViewValue = MobileNumberCode_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", MobileNumberCode_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = MobileNumberCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && MobileNumberCode_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = MobileNumberCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        MobileNumberCode_CountryID.ViewValue = MobileNumberCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), MobileNumberCode_CountryID.DisplayValue(listwrk));
                    } else {
                        MobileNumberCode_CountryID.ViewValue = MobileNumberCode_CountryID.CurrentValue;
                    }
                }
            } else {
                MobileNumberCode_CountryID.ViewValue = DbNullValue;
            }
            MobileNumberCode_CountryID.ViewCustomAttributes = "";

            // PrimaryAddressHomeTelCode_CountryID
            curVal = ConvertToString(PrimaryAddressHomeTelCode_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (PrimaryAddressHomeTelCode_CountryID.Lookup != null && IsDictionary(PrimaryAddressHomeTelCode_CountryID.Lookup?.Options) && PrimaryAddressHomeTelCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    PrimaryAddressHomeTelCode_CountryID.ViewValue = PrimaryAddressHomeTelCode_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", PrimaryAddressHomeTelCode_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = PrimaryAddressHomeTelCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && PrimaryAddressHomeTelCode_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = PrimaryAddressHomeTelCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        PrimaryAddressHomeTelCode_CountryID.ViewValue = PrimaryAddressHomeTelCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), PrimaryAddressHomeTelCode_CountryID.DisplayValue(listwrk));
                    } else {
                        PrimaryAddressHomeTelCode_CountryID.ViewValue = PrimaryAddressHomeTelCode_CountryID.CurrentValue;
                    }
                }
            } else {
                PrimaryAddressHomeTelCode_CountryID.ViewValue = DbNullValue;
            }
            PrimaryAddressHomeTelCode_CountryID.ViewCustomAttributes = "";

            // AlternativeAddressHomeTelCode_CountryID
            curVal = ConvertToString(AlternativeAddressHomeTelCode_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (AlternativeAddressHomeTelCode_CountryID.Lookup != null && IsDictionary(AlternativeAddressHomeTelCode_CountryID.Lookup?.Options) && AlternativeAddressHomeTelCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    AlternativeAddressHomeTelCode_CountryID.ViewValue = AlternativeAddressHomeTelCode_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", AlternativeAddressHomeTelCode_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = AlternativeAddressHomeTelCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && AlternativeAddressHomeTelCode_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = AlternativeAddressHomeTelCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        AlternativeAddressHomeTelCode_CountryID.ViewValue = AlternativeAddressHomeTelCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), AlternativeAddressHomeTelCode_CountryID.DisplayValue(listwrk));
                    } else {
                        AlternativeAddressHomeTelCode_CountryID.ViewValue = AlternativeAddressHomeTelCode_CountryID.CurrentValue;
                    }
                }
            } else {
                AlternativeAddressHomeTelCode_CountryID.ViewValue = DbNullValue;
            }
            AlternativeAddressHomeTelCode_CountryID.ViewCustomAttributes = "";

            // NomineeAddressHomeTelCode_CountryID
            curVal = ConvertToString(NomineeAddressHomeTelCode_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (NomineeAddressHomeTelCode_CountryID.Lookup != null && IsDictionary(NomineeAddressHomeTelCode_CountryID.Lookup?.Options) && NomineeAddressHomeTelCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeAddressHomeTelCode_CountryID.ViewValue = NomineeAddressHomeTelCode_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", NomineeAddressHomeTelCode_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = NomineeAddressHomeTelCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && NomineeAddressHomeTelCode_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = NomineeAddressHomeTelCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        NomineeAddressHomeTelCode_CountryID.ViewValue = NomineeAddressHomeTelCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), NomineeAddressHomeTelCode_CountryID.DisplayValue(listwrk));
                    } else {
                        NomineeAddressHomeTelCode_CountryID.ViewValue = NomineeAddressHomeTelCode_CountryID.CurrentValue;
                    }
                }
            } else {
                NomineeAddressHomeTelCode_CountryID.ViewValue = DbNullValue;
            }
            NomineeAddressHomeTelCode_CountryID.ViewCustomAttributes = "";

            // NomineeMobileNumberCode_CountryID
            curVal = ConvertToString(NomineeMobileNumberCode_CountryID.CurrentValue);
            if (!Empty(curVal)) {
                if (NomineeMobileNumberCode_CountryID.Lookup != null && IsDictionary(NomineeMobileNumberCode_CountryID.Lookup?.Options) && NomineeMobileNumberCode_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    NomineeMobileNumberCode_CountryID.ViewValue = NomineeMobileNumberCode_CountryID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", NomineeMobileNumberCode_CountryID.CurrentValue, DataType.Number, "");
                    sqlWrk = NomineeMobileNumberCode_CountryID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && NomineeMobileNumberCode_CountryID.Lookup != null) { // Lookup values found
                        var listwrk = NomineeMobileNumberCode_CountryID.Lookup?.RenderViewRow(rswrk[0]);
                        NomineeMobileNumberCode_CountryID.ViewValue = NomineeMobileNumberCode_CountryID.HighlightLookup(ConvertToString(rswrk[0]), NomineeMobileNumberCode_CountryID.DisplayValue(listwrk));
                    } else {
                        NomineeMobileNumberCode_CountryID.ViewValue = NomineeMobileNumberCode_CountryID.CurrentValue;
                    }
                }
            } else {
                NomineeMobileNumberCode_CountryID.ViewValue = DbNullValue;
            }
            NomineeMobileNumberCode_CountryID.ViewCustomAttributes = "";

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
            if (RequiredPhoto.UseColorbox) {
                if (Empty(RequiredPhoto.TooltipValue))
                    RequiredPhoto.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                RequiredPhoto.LinkAttrs["data-rel"] = "CrewPersonalDataForAdmin_x_RequiredPhoto";
                if (RequiredPhoto.LinkAttrs.ContainsKey("class")) {
                    RequiredPhoto.LinkAttrs.AppendClass("ew-lightbox");
                } else {
                    RequiredPhoto.LinkAttrs["class"] = "ew-lightbox";
                }
            }

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
            if (VisaPhoto.UseColorbox) {
                if (Empty(VisaPhoto.TooltipValue))
                    VisaPhoto.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                VisaPhoto.LinkAttrs["data-rel"] = "CrewPersonalDataForAdmin_x_VisaPhoto";
                if (VisaPhoto.LinkAttrs.ContainsKey("class")) {
                    VisaPhoto.LinkAttrs.AppendClass("ew-lightbox");
                } else {
                    VisaPhoto.LinkAttrs["class"] = "ew-lightbox";
                }
            }

            // Nationality_CountryID
            Nationality_CountryID.HrefValue = "";
            Nationality_CountryID.TooltipValue = "";

            // CountryOfOrigin_CountryID
            CountryOfOrigin_CountryID.HrefValue = "";
            CountryOfOrigin_CountryID.TooltipValue = "";

            // DateOfBirth
            DateOfBirth.HrefValue = "";
            DateOfBirth.TooltipValue = "";

            // CityOfBirth
            CityOfBirth.HrefValue = "";
            CityOfBirth.TooltipValue = "";

            // Gender
            Gender.HrefValue = "";
            Gender.TooltipValue = "";

            // MaritalStatus
            MaritalStatus.HrefValue = "";
            MaritalStatus.TooltipValue = "";

            // ReligionID
            ReligionID.HrefValue = "";
            ReligionID.TooltipValue = "";

            // BloodType
            BloodType.HrefValue = "";
            BloodType.TooltipValue = "";

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

            // PrimaryAddressDetail
            PrimaryAddressDetail.HrefValue = "";
            PrimaryAddressDetail.TooltipValue = "";

            // PrimaryAddressCity
            PrimaryAddressCity.HrefValue = "";
            PrimaryAddressCity.TooltipValue = "";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.HrefValue = "";
            PrimaryAddressNearestAirport.TooltipValue = "";

            // PrimaryAddressState
            PrimaryAddressState.HrefValue = "";
            PrimaryAddressState.TooltipValue = "";

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.HrefValue = "";
            PrimaryAddressPostCode.TooltipValue = "";

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.HrefValue = "";
            PrimaryAddressCountryID.TooltipValue = "";

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.HrefValue = "";
            PrimaryAddressHomeTel.TooltipValue = "";

            // AlternativeAddressDetail
            AlternativeAddressDetail.HrefValue = "";
            AlternativeAddressDetail.TooltipValue = "";

            // AlternativeAddressState
            AlternativeAddressState.HrefValue = "";
            AlternativeAddressState.TooltipValue = "";

            // AlternativeAddressCity
            AlternativeAddressCity.HrefValue = "";
            AlternativeAddressCity.TooltipValue = "";

            // AlternativeAddressHomeTel
            AlternativeAddressHomeTel.HrefValue = "";
            AlternativeAddressHomeTel.TooltipValue = "";

            // AlternativeAddressPostCode
            AlternativeAddressPostCode.HrefValue = "";
            AlternativeAddressPostCode.TooltipValue = "";

            // AlternativeAddressCountryID
            AlternativeAddressCountryID.HrefValue = "";
            AlternativeAddressCountryID.TooltipValue = "";

            // MobileNumber
            MobileNumber.HrefValue = "";
            MobileNumber.TooltipValue = "";

            // Email
            _Email.HrefValue = "";
            _Email.TooltipValue = "";

            // EmployeeStatus
            EmployeeStatus.HrefValue = "";
            EmployeeStatus.TooltipValue = "";

            // FormSubmittedDateTime
            FormSubmittedDateTime.HrefValue = "";
            FormSubmittedDateTime.TooltipValue = "";

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

            // SocialSecurityNumber
            SocialSecurityNumber.HrefValue = "";
            SocialSecurityNumber.TooltipValue = "";

            // SocialSecurityIssuingCountryID
            SocialSecurityIssuingCountryID.HrefValue = "";
            SocialSecurityIssuingCountryID.TooltipValue = "";

            // SocialSecurityImage
            SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
            if (!IsNull(SocialSecurityImage.Upload.DbValue)) {
                SocialSecurityImage.HrefValue = ConvertToString(GetFileUploadUrl(SocialSecurityImage, SocialSecurityImage.HtmlDecode(ConvertToString(SocialSecurityImage.Upload.DbValue)))); // Add prefix/suffix
                SocialSecurityImage.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    SocialSecurityImage.HrefValue = FullUrl(ConvertToString(SocialSecurityImage.HrefValue), "href");
            } else {
                SocialSecurityImage.HrefValue = "";
            }
            SocialSecurityImage.ExportHrefValue = SocialSecurityImage.UploadPath + SocialSecurityImage.Upload.DbValue;
            SocialSecurityImage.TooltipValue = "";
            if (SocialSecurityImage.UseColorbox) {
                if (Empty(SocialSecurityImage.TooltipValue))
                    SocialSecurityImage.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                SocialSecurityImage.LinkAttrs["data-rel"] = "CrewPersonalDataForAdmin_x_SocialSecurityImage";
                if (SocialSecurityImage.LinkAttrs.ContainsKey("class")) {
                    SocialSecurityImage.LinkAttrs.AppendClass("ew-lightbox");
                } else {
                    SocialSecurityImage.LinkAttrs["class"] = "ew-lightbox";
                }
            }

            // PersonalTaxNumber
            PersonalTaxNumber.HrefValue = "";
            PersonalTaxNumber.TooltipValue = "";

            // PersonalTaxIssuingCountryID
            PersonalTaxIssuingCountryID.HrefValue = "";
            PersonalTaxIssuingCountryID.TooltipValue = "";

            // PersonalTaxImage
            PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
            if (!IsNull(PersonalTaxImage.Upload.DbValue)) {
                PersonalTaxImage.HrefValue = ConvertToString(GetFileUploadUrl(PersonalTaxImage, PersonalTaxImage.HtmlDecode(ConvertToString(PersonalTaxImage.Upload.DbValue)))); // Add prefix/suffix
                PersonalTaxImage.LinkAttrs["target"] = "_blank"; // Add target
                if (IsExport())
                    PersonalTaxImage.HrefValue = FullUrl(ConvertToString(PersonalTaxImage.HrefValue), "href");
            } else {
                PersonalTaxImage.HrefValue = "";
            }
            PersonalTaxImage.ExportHrefValue = PersonalTaxImage.UploadPath + PersonalTaxImage.Upload.DbValue;
            PersonalTaxImage.TooltipValue = "";
            if (PersonalTaxImage.UseColorbox) {
                if (Empty(PersonalTaxImage.TooltipValue))
                    PersonalTaxImage.LinkAttrs["title"] = Language.Phrase("ViewImageGallery");
                PersonalTaxImage.LinkAttrs["data-rel"] = "CrewPersonalDataForAdmin_x_PersonalTaxImage";
                if (PersonalTaxImage.LinkAttrs.ContainsKey("class")) {
                    PersonalTaxImage.LinkAttrs.AppendClass("ew-lightbox");
                } else {
                    PersonalTaxImage.LinkAttrs["class"] = "ew-lightbox";
                }
            }

            // Status
            Status.HrefValue = "";
            Status.TooltipValue = "";

            // Reason
            Reason.HrefValue = "";
            Reason.TooltipValue = "";

            // Weight
            Weight.HrefValue = "";
            Weight.TooltipValue = "";

            // Height
            Height.HrefValue = "";
            Height.TooltipValue = "";

            // CoverallSize
            CoverallSize.HrefValue = "";
            CoverallSize.TooltipValue = "";

            // SafetyShoesSize
            SafetyShoesSize.HrefValue = "";
            SafetyShoesSize.TooltipValue = "";

            // ShirtSize
            ShirtSize.HrefValue = "";
            ShirtSize.TooltipValue = "";

            // TrousersSize
            TrousersSize.HrefValue = "";
            TrousersSize.TooltipValue = "";

            // NomineeFullName
            NomineeFullName.HrefValue = "";
            NomineeFullName.TooltipValue = "";

            // NomineeRelationship
            NomineeRelationship.HrefValue = "";
            NomineeRelationship.TooltipValue = "";

            // NomineeGender
            NomineeGender.HrefValue = "";
            NomineeGender.TooltipValue = "";

            // NomineeNationality_CountryID
            NomineeNationality_CountryID.HrefValue = "";
            NomineeNationality_CountryID.TooltipValue = "";

            // NomineeAddressDetail
            NomineeAddressDetail.HrefValue = "";
            NomineeAddressDetail.TooltipValue = "";

            // NomineeAddressCity
            NomineeAddressCity.HrefValue = "";
            NomineeAddressCity.TooltipValue = "";

            // NomineeAddressPostCode
            NomineeAddressPostCode.HrefValue = "";
            NomineeAddressPostCode.TooltipValue = "";

            // NomineeAddressCountryID
            NomineeAddressCountryID.HrefValue = "";
            NomineeAddressCountryID.TooltipValue = "";

            // NomineeAddressHomeTel
            NomineeAddressHomeTel.HrefValue = "";
            NomineeAddressHomeTel.TooltipValue = "";

            // NomineeEmail
            NomineeEmail.HrefValue = "";
            NomineeEmail.TooltipValue = "";

            // NomineeMobileNumber
            NomineeMobileNumber.HrefValue = "";
            NomineeMobileNumber.TooltipValue = "";

            // NSSF_Health_Number
            NSSF_Health_Number.HrefValue = "";
            NSSF_Health_Number.TooltipValue = "";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.HrefValue = "";
            NSSF_Occupation_Number.TooltipValue = "";

            // NomineeRelationshipSelect
            NomineeRelationshipSelect.HrefValue = "";
            NomineeRelationshipSelect.TooltipValue = "";

            // NomineeRelationshipDetail
            NomineeRelationshipDetail.HrefValue = "";
            NomineeRelationshipDetail.TooltipValue = "";

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.HrefValue = "";
            MobileNumberCode_CountryID.TooltipValue = "";

            // PrimaryAddressHomeTelCode_CountryID
            PrimaryAddressHomeTelCode_CountryID.HrefValue = "";
            PrimaryAddressHomeTelCode_CountryID.TooltipValue = "";

            // AlternativeAddressHomeTelCode_CountryID
            AlternativeAddressHomeTelCode_CountryID.HrefValue = "";
            AlternativeAddressHomeTelCode_CountryID.TooltipValue = "";

            // NomineeAddressHomeTelCode_CountryID
            NomineeAddressHomeTelCode_CountryID.HrefValue = "";
            NomineeAddressHomeTelCode_CountryID.TooltipValue = "";

            // NomineeMobileNumberCode_CountryID
            NomineeMobileNumberCode_CountryID.HrefValue = "";
            NomineeMobileNumberCode_CountryID.TooltipValue = "";

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

            // FullName
            FullName.SetupEditAttributes();
            if (!FullName.Raw)
                FullName.CurrentValue = HtmlDecode(FullName.CurrentValue);
            FullName.EditValue = HtmlEncode(FullName.CurrentValue);
            FullName.PlaceHolder = RemoveHtml(FullName.Caption);

            // RequiredPhoto
            RequiredPhoto.SetupEditAttributes();
            RequiredPhoto.EditAttrs["accept"] = "jpg,jpeg,png";
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
            VisaPhoto.EditAttrs["accept"] = "jpg,jpeg,png";
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

            // Nationality_CountryID
            Nationality_CountryID.SetupEditAttributes();
            curVal = ConvertToString(Nationality_CountryID.CurrentValue)?.Trim() ?? "";
            if (Nationality_CountryID.Lookup != null && IsDictionary(Nationality_CountryID.Lookup?.Options) && Nationality_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                Nationality_CountryID.EditValue = Nationality_CountryID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = Nationality_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                Nationality_CountryID.EditValue = rswrk;
            }
            Nationality_CountryID.PlaceHolder = RemoveHtml(Nationality_CountryID.Caption);
            if (!Empty(Nationality_CountryID.EditValue) && IsNumeric(Nationality_CountryID.EditValue))
                Nationality_CountryID.EditValue = FormatNumber(Nationality_CountryID.EditValue, null);

            // CountryOfOrigin_CountryID
            CountryOfOrigin_CountryID.SetupEditAttributes();
            curVal = ConvertToString(CountryOfOrigin_CountryID.CurrentValue)?.Trim() ?? "";
            if (CountryOfOrigin_CountryID.Lookup != null && IsDictionary(CountryOfOrigin_CountryID.Lookup?.Options) && CountryOfOrigin_CountryID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                CountryOfOrigin_CountryID.EditValue = CountryOfOrigin_CountryID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = CountryOfOrigin_CountryID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                CountryOfOrigin_CountryID.EditValue = rswrk;
            }
            CountryOfOrigin_CountryID.PlaceHolder = RemoveHtml(CountryOfOrigin_CountryID.Caption);
            if (!Empty(CountryOfOrigin_CountryID.EditValue) && IsNumeric(CountryOfOrigin_CountryID.EditValue))
                CountryOfOrigin_CountryID.EditValue = FormatNumber(CountryOfOrigin_CountryID.EditValue, null);

            // DateOfBirth
            DateOfBirth.SetupEditAttributes();
            DateOfBirth.EditValue = FormatDateTime(DateOfBirth.CurrentValue, DateOfBirth.FormatPattern); // DN
            DateOfBirth.PlaceHolder = RemoveHtml(DateOfBirth.Caption);

            // CityOfBirth
            CityOfBirth.SetupEditAttributes();
            if (!CityOfBirth.Raw)
                CityOfBirth.CurrentValue = HtmlDecode(CityOfBirth.CurrentValue);
            CityOfBirth.EditValue = HtmlEncode(CityOfBirth.CurrentValue);
            CityOfBirth.PlaceHolder = RemoveHtml(CityOfBirth.Caption);

            // Gender
            Gender.SetupEditAttributes();
            Gender.EditValue = Gender.Options(true);
            Gender.PlaceHolder = RemoveHtml(Gender.Caption);

            // MaritalStatus
            MaritalStatus.SetupEditAttributes();
            MaritalStatus.EditValue = MaritalStatus.Options(true);
            MaritalStatus.PlaceHolder = RemoveHtml(MaritalStatus.Caption);

            // ReligionID
            ReligionID.SetupEditAttributes();
            curVal = ConvertToString(ReligionID.CurrentValue)?.Trim() ?? "";
            if (ReligionID.Lookup != null && IsDictionary(ReligionID.Lookup?.Options) && ReligionID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                ReligionID.EditValue = ReligionID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = ReligionID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                ReligionID.EditValue = rswrk;
            }
            ReligionID.PlaceHolder = RemoveHtml(ReligionID.Caption);
            if (!Empty(ReligionID.EditValue) && IsNumeric(ReligionID.EditValue))
                ReligionID.EditValue = FormatNumber(ReligionID.EditValue, null);

            // BloodType
            BloodType.SetupEditAttributes();
            BloodType.EditValue = BloodType.Options(true);
            BloodType.PlaceHolder = RemoveHtml(BloodType.Caption);

            // RankAppliedFor_RankID
            RankAppliedFor_RankID.SetupEditAttributes();
            curVal = ConvertToString(RankAppliedFor_RankID.CurrentValue)?.Trim() ?? "";
            if (RankAppliedFor_RankID.Lookup != null && IsDictionary(RankAppliedFor_RankID.Lookup?.Options) && RankAppliedFor_RankID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                RankAppliedFor_RankID.EditValue = RankAppliedFor_RankID.Lookup?.Options.Values.ToList();
            } else { // Lookup from database
                filterWrk = "";
                sqlWrk = RankAppliedFor_RankID.Lookup?.GetSql(true, filterWrk, null, this, false, true);
                rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                RankAppliedFor_RankID.EditValue = rswrk;
            }
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

            // PrimaryAddressDetail
            PrimaryAddressDetail.SetupEditAttributes();
            PrimaryAddressDetail.EditValue = PrimaryAddressDetail.CurrentValue; // DN
            PrimaryAddressDetail.PlaceHolder = RemoveHtml(PrimaryAddressDetail.Caption);

            // PrimaryAddressCity
            PrimaryAddressCity.SetupEditAttributes();
            if (!PrimaryAddressCity.Raw)
                PrimaryAddressCity.CurrentValue = HtmlDecode(PrimaryAddressCity.CurrentValue);
            PrimaryAddressCity.EditValue = HtmlEncode(PrimaryAddressCity.CurrentValue);
            PrimaryAddressCity.PlaceHolder = RemoveHtml(PrimaryAddressCity.Caption);

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.SetupEditAttributes();
            if (!PrimaryAddressNearestAirport.Raw)
                PrimaryAddressNearestAirport.CurrentValue = HtmlDecode(PrimaryAddressNearestAirport.CurrentValue);
            PrimaryAddressNearestAirport.EditValue = HtmlEncode(PrimaryAddressNearestAirport.CurrentValue);
            PrimaryAddressNearestAirport.PlaceHolder = RemoveHtml(PrimaryAddressNearestAirport.Caption);

            // PrimaryAddressState
            PrimaryAddressState.SetupEditAttributes();
            if (!PrimaryAddressState.Raw)
                PrimaryAddressState.CurrentValue = HtmlDecode(PrimaryAddressState.CurrentValue);
            PrimaryAddressState.EditValue = HtmlEncode(PrimaryAddressState.CurrentValue);
            PrimaryAddressState.PlaceHolder = RemoveHtml(PrimaryAddressState.Caption);

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.SetupEditAttributes();
            if (!PrimaryAddressPostCode.Raw)
                PrimaryAddressPostCode.CurrentValue = HtmlDecode(PrimaryAddressPostCode.CurrentValue);
            PrimaryAddressPostCode.EditValue = HtmlEncode(PrimaryAddressPostCode.CurrentValue);
            PrimaryAddressPostCode.PlaceHolder = RemoveHtml(PrimaryAddressPostCode.Caption);

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.SetupEditAttributes();
            PrimaryAddressCountryID.PlaceHolder = RemoveHtml(PrimaryAddressCountryID.Caption);
            if (!Empty(PrimaryAddressCountryID.EditValue) && IsNumeric(PrimaryAddressCountryID.EditValue))
                PrimaryAddressCountryID.EditValue = FormatNumber(PrimaryAddressCountryID.EditValue, null);

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.SetupEditAttributes();
            if (!PrimaryAddressHomeTel.Raw)
                PrimaryAddressHomeTel.CurrentValue = HtmlDecode(PrimaryAddressHomeTel.CurrentValue);
            PrimaryAddressHomeTel.EditValue = HtmlEncode(PrimaryAddressHomeTel.CurrentValue);
            PrimaryAddressHomeTel.PlaceHolder = RemoveHtml(PrimaryAddressHomeTel.Caption);

            // AlternativeAddressDetail
            AlternativeAddressDetail.SetupEditAttributes();
            AlternativeAddressDetail.EditValue = AlternativeAddressDetail.CurrentValue; // DN
            AlternativeAddressDetail.PlaceHolder = RemoveHtml(AlternativeAddressDetail.Caption);

            // AlternativeAddressState
            AlternativeAddressState.SetupEditAttributes();
            if (!AlternativeAddressState.Raw)
                AlternativeAddressState.CurrentValue = HtmlDecode(AlternativeAddressState.CurrentValue);
            AlternativeAddressState.EditValue = HtmlEncode(AlternativeAddressState.CurrentValue);
            AlternativeAddressState.PlaceHolder = RemoveHtml(AlternativeAddressState.Caption);

            // AlternativeAddressCity
            AlternativeAddressCity.SetupEditAttributes();
            if (!AlternativeAddressCity.Raw)
                AlternativeAddressCity.CurrentValue = HtmlDecode(AlternativeAddressCity.CurrentValue);
            AlternativeAddressCity.EditValue = HtmlEncode(AlternativeAddressCity.CurrentValue);
            AlternativeAddressCity.PlaceHolder = RemoveHtml(AlternativeAddressCity.Caption);

            // AlternativeAddressHomeTel
            AlternativeAddressHomeTel.SetupEditAttributes();
            if (!AlternativeAddressHomeTel.Raw)
                AlternativeAddressHomeTel.CurrentValue = HtmlDecode(AlternativeAddressHomeTel.CurrentValue);
            AlternativeAddressHomeTel.EditValue = HtmlEncode(AlternativeAddressHomeTel.CurrentValue);
            AlternativeAddressHomeTel.PlaceHolder = RemoveHtml(AlternativeAddressHomeTel.Caption);

            // AlternativeAddressPostCode
            AlternativeAddressPostCode.SetupEditAttributes();
            if (!AlternativeAddressPostCode.Raw)
                AlternativeAddressPostCode.CurrentValue = HtmlDecode(AlternativeAddressPostCode.CurrentValue);
            AlternativeAddressPostCode.EditValue = HtmlEncode(AlternativeAddressPostCode.CurrentValue);
            AlternativeAddressPostCode.PlaceHolder = RemoveHtml(AlternativeAddressPostCode.Caption);

            // AlternativeAddressCountryID
            AlternativeAddressCountryID.SetupEditAttributes();
            AlternativeAddressCountryID.PlaceHolder = RemoveHtml(AlternativeAddressCountryID.Caption);
            if (!Empty(AlternativeAddressCountryID.EditValue) && IsNumeric(AlternativeAddressCountryID.EditValue))
                AlternativeAddressCountryID.EditValue = FormatNumber(AlternativeAddressCountryID.EditValue, null);

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

            // SocialSecurityNumber
            SocialSecurityNumber.SetupEditAttributes();
            if (!SocialSecurityNumber.Raw)
                SocialSecurityNumber.CurrentValue = HtmlDecode(SocialSecurityNumber.CurrentValue);
            SocialSecurityNumber.EditValue = HtmlEncode(SocialSecurityNumber.CurrentValue);
            SocialSecurityNumber.PlaceHolder = RemoveHtml(SocialSecurityNumber.Caption);

            // SocialSecurityIssuingCountryID
            SocialSecurityIssuingCountryID.SetupEditAttributes();
            SocialSecurityIssuingCountryID.PlaceHolder = RemoveHtml(SocialSecurityIssuingCountryID.Caption);
            if (!Empty(SocialSecurityIssuingCountryID.EditValue) && IsNumeric(SocialSecurityIssuingCountryID.EditValue))
                SocialSecurityIssuingCountryID.EditValue = FormatNumber(SocialSecurityIssuingCountryID.EditValue, null);

            // SocialSecurityImage
            SocialSecurityImage.SetupEditAttributes();
            SocialSecurityImage.EditAttrs["accept"] = "jpg,jpeg,png,pdf";
            SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
            if (!IsNull(SocialSecurityImage.Upload.DbValue)) {
                SocialSecurityImage.ImageWidth = 200;
                SocialSecurityImage.ImageHeight = 0;
                SocialSecurityImage.ImageAlt = SocialSecurityImage.Alt;
                SocialSecurityImage.ImageCssClass = "ew-image";
                SocialSecurityImage.EditValue = SocialSecurityImage.Upload.DbValue;
            } else {
                SocialSecurityImage.EditValue = "";
            }
            if (!Empty(SocialSecurityImage.CurrentValue))
                    SocialSecurityImage.Upload.FileName = ConvertToString(SocialSecurityImage.CurrentValue);

            // PersonalTaxNumber
            PersonalTaxNumber.SetupEditAttributes();
            if (!PersonalTaxNumber.Raw)
                PersonalTaxNumber.CurrentValue = HtmlDecode(PersonalTaxNumber.CurrentValue);
            PersonalTaxNumber.EditValue = HtmlEncode(PersonalTaxNumber.CurrentValue);
            PersonalTaxNumber.PlaceHolder = RemoveHtml(PersonalTaxNumber.Caption);

            // PersonalTaxIssuingCountryID
            PersonalTaxIssuingCountryID.SetupEditAttributes();
            PersonalTaxIssuingCountryID.PlaceHolder = RemoveHtml(PersonalTaxIssuingCountryID.Caption);
            if (!Empty(PersonalTaxIssuingCountryID.EditValue) && IsNumeric(PersonalTaxIssuingCountryID.EditValue))
                PersonalTaxIssuingCountryID.EditValue = FormatNumber(PersonalTaxIssuingCountryID.EditValue, null);

            // PersonalTaxImage
            PersonalTaxImage.SetupEditAttributes();
            PersonalTaxImage.EditAttrs["accept"] = "jpg,jpeg,png,pdf";
            PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
            if (!IsNull(PersonalTaxImage.Upload.DbValue)) {
                PersonalTaxImage.ImageWidth = 200;
                PersonalTaxImage.ImageHeight = 0;
                PersonalTaxImage.ImageAlt = PersonalTaxImage.Alt;
                PersonalTaxImage.ImageCssClass = "ew-image";
                PersonalTaxImage.EditValue = PersonalTaxImage.Upload.DbValue;
            } else {
                PersonalTaxImage.EditValue = "";
            }
            if (!Empty(PersonalTaxImage.CurrentValue))
                    PersonalTaxImage.Upload.FileName = ConvertToString(PersonalTaxImage.CurrentValue);

            // Status
            Status.SetupEditAttributes();
            if (!Status.Raw)
                Status.CurrentValue = HtmlDecode(Status.CurrentValue);
            Status.EditValue = HtmlEncode(Status.CurrentValue);
            Status.PlaceHolder = RemoveHtml(Status.Caption);

            // Reason
            Reason.SetupEditAttributes();
            Reason.EditValue = Reason.CurrentValue; // DN
            Reason.PlaceHolder = RemoveHtml(Reason.Caption);

            // Weight
            Weight.SetupEditAttributes();
            Weight.EditValue = Weight.CurrentValue; // DN
            Weight.PlaceHolder = RemoveHtml(Weight.Caption);

            // Height
            Height.SetupEditAttributes();
            Height.EditValue = Height.CurrentValue; // DN
            Height.PlaceHolder = RemoveHtml(Height.Caption);

            // CoverallSize
            CoverallSize.SetupEditAttributes();
            CoverallSize.PlaceHolder = RemoveHtml(CoverallSize.Caption);

            // SafetyShoesSize
            SafetyShoesSize.SetupEditAttributes();
            SafetyShoesSize.EditValue = SafetyShoesSize.Options(true);
            SafetyShoesSize.PlaceHolder = RemoveHtml(SafetyShoesSize.Caption);

            // ShirtSize
            ShirtSize.SetupEditAttributes();
            ShirtSize.PlaceHolder = RemoveHtml(ShirtSize.Caption);

            // TrousersSize
            TrousersSize.SetupEditAttributes();
            TrousersSize.PlaceHolder = RemoveHtml(TrousersSize.Caption);

            // NomineeFullName
            NomineeFullName.SetupEditAttributes();
            if (!NomineeFullName.Raw)
                NomineeFullName.CurrentValue = HtmlDecode(NomineeFullName.CurrentValue);
            NomineeFullName.EditValue = HtmlEncode(NomineeFullName.CurrentValue);
            NomineeFullName.PlaceHolder = RemoveHtml(NomineeFullName.Caption);

            // NomineeRelationship
            NomineeRelationship.SetupEditAttributes();
            if (!NomineeRelationship.Raw)
                NomineeRelationship.CurrentValue = HtmlDecode(NomineeRelationship.CurrentValue);
            NomineeRelationship.EditValue = HtmlEncode(NomineeRelationship.CurrentValue);
            NomineeRelationship.PlaceHolder = RemoveHtml(NomineeRelationship.Caption);

            // NomineeGender
            NomineeGender.SetupEditAttributes();
            NomineeGender.EditValue = NomineeGender.Options(true);
            NomineeGender.PlaceHolder = RemoveHtml(NomineeGender.Caption);

            // NomineeNationality_CountryID
            NomineeNationality_CountryID.SetupEditAttributes();
            NomineeNationality_CountryID.PlaceHolder = RemoveHtml(NomineeNationality_CountryID.Caption);
            if (!Empty(NomineeNationality_CountryID.EditValue) && IsNumeric(NomineeNationality_CountryID.EditValue))
                NomineeNationality_CountryID.EditValue = FormatNumber(NomineeNationality_CountryID.EditValue, null);

            // NomineeAddressDetail
            NomineeAddressDetail.SetupEditAttributes();
            NomineeAddressDetail.EditValue = NomineeAddressDetail.CurrentValue; // DN
            NomineeAddressDetail.PlaceHolder = RemoveHtml(NomineeAddressDetail.Caption);

            // NomineeAddressCity
            NomineeAddressCity.SetupEditAttributes();
            if (!NomineeAddressCity.Raw)
                NomineeAddressCity.CurrentValue = HtmlDecode(NomineeAddressCity.CurrentValue);
            NomineeAddressCity.EditValue = HtmlEncode(NomineeAddressCity.CurrentValue);
            NomineeAddressCity.PlaceHolder = RemoveHtml(NomineeAddressCity.Caption);

            // NomineeAddressPostCode
            NomineeAddressPostCode.SetupEditAttributes();
            if (!NomineeAddressPostCode.Raw)
                NomineeAddressPostCode.CurrentValue = HtmlDecode(NomineeAddressPostCode.CurrentValue);
            NomineeAddressPostCode.EditValue = HtmlEncode(NomineeAddressPostCode.CurrentValue);
            NomineeAddressPostCode.PlaceHolder = RemoveHtml(NomineeAddressPostCode.Caption);

            // NomineeAddressCountryID
            NomineeAddressCountryID.SetupEditAttributes();
            NomineeAddressCountryID.PlaceHolder = RemoveHtml(NomineeAddressCountryID.Caption);
            if (!Empty(NomineeAddressCountryID.EditValue) && IsNumeric(NomineeAddressCountryID.EditValue))
                NomineeAddressCountryID.EditValue = FormatNumber(NomineeAddressCountryID.EditValue, null);

            // NomineeAddressHomeTel
            NomineeAddressHomeTel.SetupEditAttributes();
            if (!NomineeAddressHomeTel.Raw)
                NomineeAddressHomeTel.CurrentValue = HtmlDecode(NomineeAddressHomeTel.CurrentValue);
            NomineeAddressHomeTel.EditValue = HtmlEncode(NomineeAddressHomeTel.CurrentValue);
            NomineeAddressHomeTel.PlaceHolder = RemoveHtml(NomineeAddressHomeTel.Caption);

            // NomineeEmail
            NomineeEmail.SetupEditAttributes();
            if (!NomineeEmail.Raw)
                NomineeEmail.CurrentValue = HtmlDecode(NomineeEmail.CurrentValue);
            NomineeEmail.EditValue = HtmlEncode(NomineeEmail.CurrentValue);
            NomineeEmail.PlaceHolder = RemoveHtml(NomineeEmail.Caption);

            // NomineeMobileNumber
            NomineeMobileNumber.SetupEditAttributes();
            if (!NomineeMobileNumber.Raw)
                NomineeMobileNumber.CurrentValue = HtmlDecode(NomineeMobileNumber.CurrentValue);
            NomineeMobileNumber.EditValue = HtmlEncode(NomineeMobileNumber.CurrentValue);
            NomineeMobileNumber.PlaceHolder = RemoveHtml(NomineeMobileNumber.Caption);

            // NSSF_Health_Number
            NSSF_Health_Number.SetupEditAttributes();
            if (!NSSF_Health_Number.Raw)
                NSSF_Health_Number.CurrentValue = HtmlDecode(NSSF_Health_Number.CurrentValue);
            NSSF_Health_Number.EditValue = HtmlEncode(NSSF_Health_Number.CurrentValue);
            NSSF_Health_Number.PlaceHolder = RemoveHtml(NSSF_Health_Number.Caption);

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.SetupEditAttributes();
            if (!NSSF_Occupation_Number.Raw)
                NSSF_Occupation_Number.CurrentValue = HtmlDecode(NSSF_Occupation_Number.CurrentValue);
            NSSF_Occupation_Number.EditValue = HtmlEncode(NSSF_Occupation_Number.CurrentValue);
            NSSF_Occupation_Number.PlaceHolder = RemoveHtml(NSSF_Occupation_Number.Caption);

            // NomineeRelationshipSelect
            NomineeRelationshipSelect.SetupEditAttributes();
            NomineeRelationshipSelect.EditValue = NomineeRelationshipSelect.Options(true);
            NomineeRelationshipSelect.PlaceHolder = RemoveHtml(NomineeRelationshipSelect.Caption);

            // NomineeRelationshipDetail
            NomineeRelationshipDetail.SetupEditAttributes();
            if (!NomineeRelationshipDetail.Raw)
                NomineeRelationshipDetail.CurrentValue = HtmlDecode(NomineeRelationshipDetail.CurrentValue);
            NomineeRelationshipDetail.EditValue = HtmlEncode(NomineeRelationshipDetail.CurrentValue);
            NomineeRelationshipDetail.PlaceHolder = RemoveHtml(NomineeRelationshipDetail.Caption);

            // MobileNumberCode_CountryID
            MobileNumberCode_CountryID.SetupEditAttributes();
            MobileNumberCode_CountryID.PlaceHolder = RemoveHtml(MobileNumberCode_CountryID.Caption);

            // PrimaryAddressHomeTelCode_CountryID
            PrimaryAddressHomeTelCode_CountryID.SetupEditAttributes();
            PrimaryAddressHomeTelCode_CountryID.PlaceHolder = RemoveHtml(PrimaryAddressHomeTelCode_CountryID.Caption);

            // AlternativeAddressHomeTelCode_CountryID
            AlternativeAddressHomeTelCode_CountryID.SetupEditAttributes();
            AlternativeAddressHomeTelCode_CountryID.PlaceHolder = RemoveHtml(AlternativeAddressHomeTelCode_CountryID.Caption);

            // NomineeAddressHomeTelCode_CountryID
            NomineeAddressHomeTelCode_CountryID.SetupEditAttributes();
            NomineeAddressHomeTelCode_CountryID.PlaceHolder = RemoveHtml(NomineeAddressHomeTelCode_CountryID.Caption);

            // NomineeMobileNumberCode_CountryID
            NomineeMobileNumberCode_CountryID.SetupEditAttributes();
            NomineeMobileNumberCode_CountryID.PlaceHolder = RemoveHtml(NomineeMobileNumberCode_CountryID.Caption);

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
                        doc.ExportCaption(Nationality_CountryID);
                        doc.ExportCaption(CountryOfOrigin_CountryID);
                        doc.ExportCaption(DateOfBirth);
                        doc.ExportCaption(CityOfBirth);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(MaritalStatus);
                        doc.ExportCaption(ReligionID);
                        doc.ExportCaption(BloodType);
                        doc.ExportCaption(RankAppliedFor_RankID);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
                        doc.ExportCaption(PrimaryAddressDetail);
                        doc.ExportCaption(PrimaryAddressCity);
                        doc.ExportCaption(PrimaryAddressNearestAirport);
                        doc.ExportCaption(PrimaryAddressState);
                        doc.ExportCaption(PrimaryAddressPostCode);
                        doc.ExportCaption(PrimaryAddressCountryID);
                        doc.ExportCaption(PrimaryAddressHomeTel);
                        doc.ExportCaption(AlternativeAddressDetail);
                        doc.ExportCaption(AlternativeAddressState);
                        doc.ExportCaption(AlternativeAddressCity);
                        doc.ExportCaption(AlternativeAddressHomeTel);
                        doc.ExportCaption(AlternativeAddressPostCode);
                        doc.ExportCaption(AlternativeAddressCountryID);
                        doc.ExportCaption(MobileNumber);
                        doc.ExportCaption(_Email);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(FormSubmittedDateTime);
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(SocialSecurityNumber);
                        doc.ExportCaption(SocialSecurityIssuingCountryID);
                        doc.ExportCaption(SocialSecurityImage);
                        doc.ExportCaption(PersonalTaxNumber);
                        doc.ExportCaption(PersonalTaxIssuingCountryID);
                        doc.ExportCaption(PersonalTaxImage);
                        doc.ExportCaption(Status);
                        doc.ExportCaption(Reason);
                        doc.ExportCaption(Weight);
                        doc.ExportCaption(Height);
                        doc.ExportCaption(CoverallSize);
                        doc.ExportCaption(SafetyShoesSize);
                        doc.ExportCaption(ShirtSize);
                        doc.ExportCaption(TrousersSize);
                        doc.ExportCaption(NomineeFullName);
                        doc.ExportCaption(NomineeRelationship);
                        doc.ExportCaption(NomineeGender);
                        doc.ExportCaption(NomineeNationality_CountryID);
                        doc.ExportCaption(NomineeAddressDetail);
                        doc.ExportCaption(NomineeAddressCity);
                        doc.ExportCaption(NomineeAddressPostCode);
                        doc.ExportCaption(NomineeAddressCountryID);
                        doc.ExportCaption(NomineeAddressHomeTel);
                        doc.ExportCaption(NomineeEmail);
                        doc.ExportCaption(NomineeMobileNumber);
                        doc.ExportCaption(NSSF_Health_Number);
                        doc.ExportCaption(NSSF_Occupation_Number);
                        doc.ExportCaption(NomineeRelationshipSelect);
                        doc.ExportCaption(NomineeRelationshipDetail);
                        doc.ExportCaption(MobileNumberCode_CountryID);
                        doc.ExportCaption(PrimaryAddressHomeTelCode_CountryID);
                        doc.ExportCaption(AlternativeAddressHomeTelCode_CountryID);
                        doc.ExportCaption(NomineeAddressHomeTelCode_CountryID);
                        doc.ExportCaption(NomineeMobileNumberCode_CountryID);
                    } else {
                        doc.ExportCaption(IndividualCodeNumber);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(Nationality_CountryID);
                        doc.ExportCaption(CountryOfOrigin_CountryID);
                        doc.ExportCaption(DateOfBirth);
                        doc.ExportCaption(CityOfBirth);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(MaritalStatus);
                        doc.ExportCaption(ReligionID);
                        doc.ExportCaption(BloodType);
                        doc.ExportCaption(RankAppliedFor_RankID);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
                        doc.ExportCaption(PrimaryAddressDetail);
                        doc.ExportCaption(PrimaryAddressCity);
                        doc.ExportCaption(PrimaryAddressNearestAirport);
                        doc.ExportCaption(PrimaryAddressState);
                        doc.ExportCaption(PrimaryAddressPostCode);
                        doc.ExportCaption(PrimaryAddressCountryID);
                        doc.ExportCaption(PrimaryAddressHomeTel);
                        doc.ExportCaption(AlternativeAddressDetail);
                        doc.ExportCaption(AlternativeAddressState);
                        doc.ExportCaption(AlternativeAddressCity);
                        doc.ExportCaption(AlternativeAddressHomeTel);
                        doc.ExportCaption(AlternativeAddressPostCode);
                        doc.ExportCaption(AlternativeAddressCountryID);
                        doc.ExportCaption(MobileNumber);
                        doc.ExportCaption(_Email);
                        doc.ExportCaption(EmployeeStatus);
                        doc.ExportCaption(FormSubmittedDateTime);
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(SocialSecurityNumber);
                        doc.ExportCaption(SocialSecurityIssuingCountryID);
                        doc.ExportCaption(SocialSecurityImage);
                        doc.ExportCaption(PersonalTaxNumber);
                        doc.ExportCaption(PersonalTaxIssuingCountryID);
                        doc.ExportCaption(PersonalTaxImage);
                        doc.ExportCaption(Status);
                        doc.ExportCaption(Reason);
                        doc.ExportCaption(Weight);
                        doc.ExportCaption(Height);
                        doc.ExportCaption(CoverallSize);
                        doc.ExportCaption(SafetyShoesSize);
                        doc.ExportCaption(ShirtSize);
                        doc.ExportCaption(TrousersSize);
                        doc.ExportCaption(NomineeFullName);
                        doc.ExportCaption(NomineeRelationship);
                        doc.ExportCaption(NomineeGender);
                        doc.ExportCaption(NomineeNationality_CountryID);
                        doc.ExportCaption(NomineeAddressDetail);
                        doc.ExportCaption(NomineeAddressCity);
                        doc.ExportCaption(NomineeAddressPostCode);
                        doc.ExportCaption(NomineeAddressCountryID);
                        doc.ExportCaption(NomineeAddressHomeTel);
                        doc.ExportCaption(NomineeEmail);
                        doc.ExportCaption(NomineeMobileNumber);
                        doc.ExportCaption(NSSF_Health_Number);
                        doc.ExportCaption(NSSF_Occupation_Number);
                        doc.ExportCaption(MobileNumberCode_CountryID);
                        doc.ExportCaption(PrimaryAddressHomeTelCode_CountryID);
                        doc.ExportCaption(AlternativeAddressHomeTelCode_CountryID);
                        doc.ExportCaption(NomineeAddressHomeTelCode_CountryID);
                        doc.ExportCaption(NomineeMobileNumberCode_CountryID);
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
                            await doc.ExportField(Nationality_CountryID);
                            await doc.ExportField(CountryOfOrigin_CountryID);
                            await doc.ExportField(DateOfBirth);
                            await doc.ExportField(CityOfBirth);
                            await doc.ExportField(Gender);
                            await doc.ExportField(MaritalStatus);
                            await doc.ExportField(ReligionID);
                            await doc.ExportField(BloodType);
                            await doc.ExportField(RankAppliedFor_RankID);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
                            await doc.ExportField(PrimaryAddressDetail);
                            await doc.ExportField(PrimaryAddressCity);
                            await doc.ExportField(PrimaryAddressNearestAirport);
                            await doc.ExportField(PrimaryAddressState);
                            await doc.ExportField(PrimaryAddressPostCode);
                            await doc.ExportField(PrimaryAddressCountryID);
                            await doc.ExportField(PrimaryAddressHomeTel);
                            await doc.ExportField(AlternativeAddressDetail);
                            await doc.ExportField(AlternativeAddressState);
                            await doc.ExportField(AlternativeAddressCity);
                            await doc.ExportField(AlternativeAddressHomeTel);
                            await doc.ExportField(AlternativeAddressPostCode);
                            await doc.ExportField(AlternativeAddressCountryID);
                            await doc.ExportField(MobileNumber);
                            await doc.ExportField(_Email);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(FormSubmittedDateTime);
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(SocialSecurityNumber);
                            await doc.ExportField(SocialSecurityIssuingCountryID);
                            await doc.ExportField(SocialSecurityImage);
                            await doc.ExportField(PersonalTaxNumber);
                            await doc.ExportField(PersonalTaxIssuingCountryID);
                            await doc.ExportField(PersonalTaxImage);
                            await doc.ExportField(Status);
                            await doc.ExportField(Reason);
                            await doc.ExportField(Weight);
                            await doc.ExportField(Height);
                            await doc.ExportField(CoverallSize);
                            await doc.ExportField(SafetyShoesSize);
                            await doc.ExportField(ShirtSize);
                            await doc.ExportField(TrousersSize);
                            await doc.ExportField(NomineeFullName);
                            await doc.ExportField(NomineeRelationship);
                            await doc.ExportField(NomineeGender);
                            await doc.ExportField(NomineeNationality_CountryID);
                            await doc.ExportField(NomineeAddressDetail);
                            await doc.ExportField(NomineeAddressCity);
                            await doc.ExportField(NomineeAddressPostCode);
                            await doc.ExportField(NomineeAddressCountryID);
                            await doc.ExportField(NomineeAddressHomeTel);
                            await doc.ExportField(NomineeEmail);
                            await doc.ExportField(NomineeMobileNumber);
                            await doc.ExportField(NSSF_Health_Number);
                            await doc.ExportField(NSSF_Occupation_Number);
                            await doc.ExportField(NomineeRelationshipSelect);
                            await doc.ExportField(NomineeRelationshipDetail);
                            await doc.ExportField(MobileNumberCode_CountryID);
                            await doc.ExportField(PrimaryAddressHomeTelCode_CountryID);
                            await doc.ExportField(AlternativeAddressHomeTelCode_CountryID);
                            await doc.ExportField(NomineeAddressHomeTelCode_CountryID);
                            await doc.ExportField(NomineeMobileNumberCode_CountryID);
                        } else {
                            await doc.ExportField(IndividualCodeNumber);
                            await doc.ExportField(FullName);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(Nationality_CountryID);
                            await doc.ExportField(CountryOfOrigin_CountryID);
                            await doc.ExportField(DateOfBirth);
                            await doc.ExportField(CityOfBirth);
                            await doc.ExportField(Gender);
                            await doc.ExportField(MaritalStatus);
                            await doc.ExportField(ReligionID);
                            await doc.ExportField(BloodType);
                            await doc.ExportField(RankAppliedFor_RankID);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
                            await doc.ExportField(PrimaryAddressDetail);
                            await doc.ExportField(PrimaryAddressCity);
                            await doc.ExportField(PrimaryAddressNearestAirport);
                            await doc.ExportField(PrimaryAddressState);
                            await doc.ExportField(PrimaryAddressPostCode);
                            await doc.ExportField(PrimaryAddressCountryID);
                            await doc.ExportField(PrimaryAddressHomeTel);
                            await doc.ExportField(AlternativeAddressDetail);
                            await doc.ExportField(AlternativeAddressState);
                            await doc.ExportField(AlternativeAddressCity);
                            await doc.ExportField(AlternativeAddressHomeTel);
                            await doc.ExportField(AlternativeAddressPostCode);
                            await doc.ExportField(AlternativeAddressCountryID);
                            await doc.ExportField(MobileNumber);
                            await doc.ExportField(_Email);
                            await doc.ExportField(EmployeeStatus);
                            await doc.ExportField(FormSubmittedDateTime);
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(SocialSecurityNumber);
                            await doc.ExportField(SocialSecurityIssuingCountryID);
                            await doc.ExportField(SocialSecurityImage);
                            await doc.ExportField(PersonalTaxNumber);
                            await doc.ExportField(PersonalTaxIssuingCountryID);
                            await doc.ExportField(PersonalTaxImage);
                            await doc.ExportField(Status);
                            await doc.ExportField(Reason);
                            await doc.ExportField(Weight);
                            await doc.ExportField(Height);
                            await doc.ExportField(CoverallSize);
                            await doc.ExportField(SafetyShoesSize);
                            await doc.ExportField(ShirtSize);
                            await doc.ExportField(TrousersSize);
                            await doc.ExportField(NomineeFullName);
                            await doc.ExportField(NomineeRelationship);
                            await doc.ExportField(NomineeGender);
                            await doc.ExportField(NomineeNationality_CountryID);
                            await doc.ExportField(NomineeAddressDetail);
                            await doc.ExportField(NomineeAddressCity);
                            await doc.ExportField(NomineeAddressPostCode);
                            await doc.ExportField(NomineeAddressCountryID);
                            await doc.ExportField(NomineeAddressHomeTel);
                            await doc.ExportField(NomineeEmail);
                            await doc.ExportField(NomineeMobileNumber);
                            await doc.ExportField(NSSF_Health_Number);
                            await doc.ExportField(NSSF_Occupation_Number);
                            await doc.ExportField(MobileNumberCode_CountryID);
                            await doc.ExportField(PrimaryAddressHomeTelCode_CountryID);
                            await doc.ExportField(AlternativeAddressHomeTelCode_CountryID);
                            await doc.ExportField(NomineeAddressHomeTelCode_CountryID);
                            await doc.ExportField(NomineeMobileNumberCode_CountryID);
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

            // Set up field names
            string fldName = "", fileNameFld = "", fileTypeFld = "";
            if (SameText(fldparm, "RequiredPhoto")) {
                fldName = "RequiredPhoto";
                fileNameFld = "RequiredPhoto";
            } else if (SameText(fldparm, "VisaPhoto")) {
                fldName = "VisaPhoto";
                fileNameFld = "VisaPhoto";
            } else if (SameText(fldparm, "SocialSecurityImage")) {
                fldName = "SocialSecurityImage";
                fileNameFld = "SocialSecurityImage";
            } else if (SameText(fldparm, "PersonalTaxImage")) {
                fldName = "PersonalTaxImage";
                fileNameFld = "PersonalTaxImage";
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
            if (rsnew.ContainsKey("RequiredPhoto") && rsnew["RequiredPhoto"] != null)
            {
                string requiredPhotoFileName = rsnew["RequiredPhoto"].ToString();
                string requiredPhotoFileExtension = System.IO.Path.GetExtension(requiredPhotoFileName);
                rsnew["RequiredPhoto"] =  rsnew["IndividualCodeNumber"].ToString() + "-pp" + requiredPhotoFileExtension;
            }
            if (rsnew.ContainsKey("VisaPhoto") && rsnew["VisaPhoto"] != null)
            {
                string visaPhotoFileName = rsnew["VisaPhoto"].ToString();
                string visaPhotoFileExtension = System.IO.Path.GetExtension(visaPhotoFileName);
                rsnew["VisaPhoto"] =  rsnew["IndividualCodeNumber"].ToString() + "-vp" + visaPhotoFileExtension;
            }
            if (rsnew.ContainsKey("SocialSecurityImage") && rsnew["SocialSecurityImage"] != null)
            {
                string socialSecurityImageFileName = rsnew["SocialSecurityImage"].ToString();
                string socialSecurityImageFileExtension = System.IO.Path.GetExtension(socialSecurityImageFileName);
                rsnew["SocialSecurityImage"] =  rsnew["IndividualCodeNumber"].ToString() + "-ss" + socialSecurityImageFileExtension;
            }
            if (rsnew.ContainsKey("PersonalTaxImage") && rsnew["PersonalTaxImage"] != null)
            {
                string personalTaxImageFileName = rsnew["PersonalTaxImage"].ToString();
                string personalTaxImageFileExtension = System.IO.Path.GetExtension(personalTaxImageFileName);
                rsnew["PersonalTaxImage"] =  rsnew["IndividualCodeNumber"].ToString() + "-pt" + personalTaxImageFileExtension;
            }

            // add required but not yet exist certificates and delete unfilled but not required certificates
            var oldRankID = "0"; 
            var newRankID = "0"; 
            if (rsold["RankAppliedFor_RankID"] != null)
            {
                if (!string.IsNullOrEmpty(rsold["RankAppliedFor_RankID"].ToString()))
                {
                    oldRankID = rsold["RankAppliedFor_RankID"].ToString();
                }
            }
            if (rsnew["RankAppliedFor_RankID"] != null)
            {
                if (!string.IsNullOrEmpty(rsnew["RankAppliedFor_RankID"].ToString()))
                {
                    newRankID = rsnew["RankAppliedFor_RankID"].ToString();
                }
            }
            if (oldRankID != newRankID)
            {
                try {
                    if (newRankID != "0")
                    {
                        int rowsAffected = 0;
                        string crewID = ID.DbValue.ToString();
                        var notYetExistRequiredCertificateQuery = ExecuteRows(
                            "SELECT MTCertificateID FROM MTCertificateOnRank " + 
                            "WHERE MTCertificateOnRank.MTRankID = '" + newRankID + "' " +
                            "AND MTCertificateOnRank.MTCertificateID NOT IN (SELECT MTCertificateID FROM MTCrewCertificate WHERE MTCrewCertificate.MTCrewID = '" + crewID + "');"
                        );
                        if (notYetExistRequiredCertificateQuery.Count > 0)
                        {
                            var insertNotYetExistRequiredCertificateQuery = "INSERT INTO MTCrewCertificate (MTCrewID, MTCertificateID, CreatedByUserID, CreatedDateTime, LastUpdatedByUserID, LastUpdatedDateTime, MTUserID) VALUES ";
                            for (int i = 0; i < notYetExistRequiredCertificateQuery.Count; i++)
                            {
                                var row = notYetExistRequiredCertificateQuery[i];
                                var notYetExistRequiredCertificateID = row["MTCertificateID"].ToString();
                                insertNotYetExistRequiredCertificateQuery += "('" + crewID + "', '" + notYetExistRequiredCertificateID + "', '" + CurrentUserID() + "', '" + DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz", CultureInfo.InvariantCulture) + "', '" + CurrentUserID() + "', '" + DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzz", CultureInfo.InvariantCulture) + "', '" + MTUserID.DbValue.ToString() + "')";
                                if (i < notYetExistRequiredCertificateQuery.Count - 1)
                                {
                                    insertNotYetExistRequiredCertificateQuery += ", ";
                                }
                            }
                            insertNotYetExistRequiredCertificateQuery += ";";
                            rowsAffected = Execute(insertNotYetExistRequiredCertificateQuery);
                            if (rowsAffected != notYetExistRequiredCertificateQuery.Count)
                            {
                                CancelMessage = "Error when updating data: Error creating mandatory certificates";
                                return false;
                            }
                        }
                        var notRequiredUnfilledCertificateQuery = "SELECT ID FROM MTCrewCertificate " +  "WHERE MTCrewCertificate.MTCrewID = '" + crewID + "' " + "AND MTCrewCertificate.Number IS NULL " + "AND MTCrewCertificate.MTCertificateID NOT IN (SELECT MTCertificateID FROM MTCertificateOnRank WHERE MTCertificateOnRank.MTRankID = '" + newRankID + "')";
                        var notRequiredUnfilledCertificateQueryResult = ExecuteRows(notRequiredUnfilledCertificateQuery + ";");
                        if (notRequiredUnfilledCertificateQueryResult.Count > 0)
                        {
                            var deleteNotRequiredUnfilledCertificateQuery = "DELETE FROM MTCrewCertificate WHERE ID IN (" + notRequiredUnfilledCertificateQuery + ");";
                            rowsAffected = Execute(deleteNotRequiredUnfilledCertificateQuery);
                            if (rowsAffected != notRequiredUnfilledCertificateQueryResult.Count)
                            {
                                CancelMessage = "Error when updating data: Error deleting unfilled certificates which are not mandatory";
                                return false;
                            }
                        }
                    }
                    else
                    {
                        int rowsAffected = 0;
                        string crewID = rsold["ID"].ToString();
                        var notRequiredUnfilledCertificateQuery = "SELECT ID FROM MTCrewCertificate " +  "WHERE MTCrewCertificate.MTCrewID = '" + crewID + "' " + "AND MTCrewCertificate.Number IS NULL";
                        var notRequiredUnfilledCertificateQueryResult = ExecuteRows(notRequiredUnfilledCertificateQuery + ";");
                        if (notRequiredUnfilledCertificateQueryResult.Count > 0)
                        {
                            var deleteNotRequiredUnfilledCertificateQuery = "DELETE FROM MTCrewCertificate WHERE ID IN (" + notRequiredUnfilledCertificateQuery + ");";
                            rowsAffected = Execute(deleteNotRequiredUnfilledCertificateQuery);
                            if (rowsAffected != notRequiredUnfilledCertificateQueryResult.Count)
                            {
                                CancelMessage = "Error when updating data: Error deleting unfilled certificates which are not mandatory";
                                return false;
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    CancelMessage = "Error when updating data: " + ex.Message;
                    return false;
                }
            }
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
