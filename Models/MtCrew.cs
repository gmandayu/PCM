namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// mtCrew
    /// </summary>
    [MaybeNull]
    public static MtCrew mtCrew
    {
        get => HttpData.Resolve<MtCrew>("MTCrew");
        set => HttpData["MTCrew"] = value;
    }

    /// <summary>
    /// Table class for MTCrew
    /// </summary>
    public class MtCrew : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> FirstName;

        public readonly DbField<SqlDbType> MiddleName;

        public readonly DbField<SqlDbType> LastName;

        public readonly DbField<SqlDbType> RequiredPhoto;

        public readonly DbField<SqlDbType> VisaPhoto;

        public readonly DbField<SqlDbType> Nationality_CountryID;

        public readonly DbField<SqlDbType> CountryOfOrigin_CountryID;

        public readonly DbField<SqlDbType> DateOfBirth;

        public readonly DbField<SqlDbType> CityOfBirth;

        public readonly DbField<SqlDbType> MaritalStatus;

        public readonly DbField<SqlDbType> Gender;

        public readonly DbField<SqlDbType> ReligionID;

        public readonly DbField<SqlDbType> BloodType;

        public readonly DbField<SqlDbType> RankAppliedFor_RankID;

        public readonly DbField<SqlDbType> WillAcceptLowRank;

        public readonly DbField<SqlDbType> AvailableFrom;

        public readonly DbField<SqlDbType> AvailableUntil;

        public readonly DbField<SqlDbType> PrimaryAddressDetail;

        public readonly DbField<SqlDbType> PrimaryAddressCity;

        public readonly DbField<SqlDbType> PrimaryAddressState;

        public readonly DbField<SqlDbType> PrimaryAddressNearestAirport;

        public readonly DbField<SqlDbType> PrimaryAddressPostCode;

        public readonly DbField<SqlDbType> PrimaryAddressCountryID;

        public readonly DbField<SqlDbType> PrimaryAddressHomeTel;

        public readonly DbField<SqlDbType> PrimaryAddressFax;

        public readonly DbField<SqlDbType> AlternativeAddressDetail;

        public readonly DbField<SqlDbType> AlternativeAddressCity;

        public readonly DbField<SqlDbType> AlternativeAddressState;

        public readonly DbField<SqlDbType> AlternativeAddressHomeTel;

        public readonly DbField<SqlDbType> AlternativeAddressPostCode;

        public readonly DbField<SqlDbType> AlternativeAddressCountryID;

        public readonly DbField<SqlDbType> MobileNumber;

        public readonly DbField<SqlDbType> _Email;

        public readonly DbField<SqlDbType> ContactMethodEmail;

        public readonly DbField<SqlDbType> ContactMethodFax;

        public readonly DbField<SqlDbType> ContactMethodMobilePhone;

        public readonly DbField<SqlDbType> ContactMethodHomePhone;

        public readonly DbField<SqlDbType> ContactMethodPost;

        public readonly DbField<SqlDbType> CollarSize;

        public readonly DbField<SqlDbType> ChestSize;

        public readonly DbField<SqlDbType> WaistSize;

        public readonly DbField<SqlDbType> InsideLegSize;

        public readonly DbField<SqlDbType> CapSize;

        public readonly DbField<SqlDbType> SweaterSize_ClothesSizeID;

        public readonly DbField<SqlDbType> BoilersuitSize_ClothesSizeID;

        public readonly DbField<SqlDbType> SocialSecurityNumber;

        public readonly DbField<SqlDbType> SocialSecurityIssuingCountryID;

        public readonly DbField<SqlDbType> SocialSecurityImage;

        public readonly DbField<SqlDbType> PersonalTaxNumber;

        public readonly DbField<SqlDbType> PersonalTaxIssuingCountryID;

        public readonly DbField<SqlDbType> PersonalTaxImage;

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

        public readonly DbField<SqlDbType> NomineeValidVisa;

        public readonly DbField<SqlDbType> BankName;

        public readonly DbField<SqlDbType> BankAddress;

        public readonly DbField<SqlDbType> BankAccountName;

        public readonly DbField<SqlDbType> BankAccountNumber;

        public readonly DbField<SqlDbType> BankSortCode;

        public readonly DbField<SqlDbType> MNOPF;

        public readonly DbField<SqlDbType> MembershipNumber;

        public readonly DbField<SqlDbType> NationalInsuranceNumber;

        public readonly DbField<SqlDbType> AVC;

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

        public readonly DbField<SqlDbType> ActiveDescription;

        public readonly DbField<SqlDbType> CreatedByUserID;

        public readonly DbField<SqlDbType> CreatedDateTime;

        public readonly DbField<SqlDbType> LastUpdatedByUserID;

        public readonly DbField<SqlDbType> LastUpdatedDateTime;

        public readonly DbField<SqlDbType> MTUserID;

        public readonly DbField<SqlDbType> DocumentCheckDateTime;

        public readonly DbField<SqlDbType> InterviewManagerDateTime;

        public readonly DbField<SqlDbType> InterviewGMDateTime;

        public readonly DbField<SqlDbType> MCUScheduleDateTime;

        public readonly DbField<SqlDbType> RejectedReason;

        public readonly DbField<SqlDbType> RejectedDateTime;

        public readonly DbField<SqlDbType> Status;

        public readonly DbField<SqlDbType> Reason;

        public readonly DbField<SqlDbType> Weight;

        public readonly DbField<SqlDbType> Height;

        public readonly DbField<SqlDbType> CoverallSize;

        public readonly DbField<SqlDbType> SafetyShoesSize;

        public readonly DbField<SqlDbType> ShirtSize;

        public readonly DbField<SqlDbType> TrousersSize;

        public readonly DbField<SqlDbType> NSSF_Health_Number;

        public readonly DbField<SqlDbType> NSSF_Occupation_Number;

        public readonly DbField<SqlDbType> FinalAcceptedDate;

        public readonly DbField<SqlDbType> Reference1CompanyTelephoneCode_CountryID;

        public readonly DbField<SqlDbType> Reference2CompanyTelephoneCode_CountryID;

        public readonly DbField<SqlDbType> MobileNumberCode_CountryID;

        public readonly DbField<SqlDbType> PrimaryAddressHomeTelCode_CountryID;

        public readonly DbField<SqlDbType> AlternativeAddressHomeTelCode_CountryID;

        public readonly DbField<SqlDbType> NomineeAddressHomeTelCode_CountryID;

        public readonly DbField<SqlDbType> NomineeMobileNumberCode_CountryID;

        public readonly DbField<SqlDbType> RevisedReason;

        public readonly DbField<SqlDbType> RevisedDateTime;

        // Constructor
        public MtCrew()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "MTCrew";
            Name = "MTCrew";
            Type = "TABLE";
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
                IsForeignKey = true, // Foreign key field
                Nullable = false, // NOT NULL field
                Sortable = false, // Allow sort
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN" },
                CustomMessage = Language.FieldPhrase("MTCrew", "ID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ID", ID);

            // IndividualCodeNumber
            IndividualCodeNumber = new (this, "x_IndividualCodeNumber", 202, SqlDbType.NVarChar) {
                Name = "IndividualCodeNumber",
                Expression = "[IndividualCodeNumber]",
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
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectField"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "IndividualCodeNumber", "CustomMsg"),
                IsUpload = false
            };
            IndividualCodeNumber.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("IndividualCodeNumber", "MTCrew", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("IndividualCodeNumber", "MTCrew", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("IndividualCodeNumber", "MTCrew", true, "IndividualCodeNumber", new List<string> {"IndividualCodeNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("MTCrew", "FullName", "CustomMsg"),
                IsUpload = false
            };
            FullName.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FullName", "MTCrew", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("FullName", "MTCrew", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("FullName", "MTCrew", true, "FullName", new List<string> {"FullName", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("FullName", FullName);

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
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "FirstName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("FirstName", FirstName);

            // MiddleName
            MiddleName = new (this, "x_MiddleName", 202, SqlDbType.NVarChar) {
                Name = "MiddleName",
                Expression = "[MiddleName]",
                BasicSearchExpression = "[MiddleName]",
                DateTimeFormat = -1,
                VirtualExpression = "[MiddleName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "MiddleName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MiddleName", MiddleName);

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
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "LastName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("LastName", LastName);

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
                ViewTag = "IMAGE",
                HtmlTag = "FILE",
                InputTextType = "text",
                Required = true, // Required field
                UseFilter = true, // Table header filter
                ImageResize = true,
                UploadAllowedFileExtensions = "jpeg,png,jpg",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "RequiredPhoto", "CustomMsg"),
                IsUpload = true
            };
            RequiredPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("RequiredPhoto", "MTCrew", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("RequiredPhoto", "MTCrew", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("RequiredPhoto", "MTCrew", true, "RequiredPhoto", new List<string> {"RequiredPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            RequiredPhoto.GetUploadPath = () => "files/crew";
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
                ViewTag = "IMAGE",
                HtmlTag = "FILE",
                InputTextType = "text",
                UseFilter = true, // Table header filter
                ImageResize = true,
                UploadAllowedFileExtensions = "jpeg,png,jpg",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "VisaPhoto", "CustomMsg"),
                IsUpload = true
            };
            VisaPhoto.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("VisaPhoto", "MTCrew", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("VisaPhoto", "MTCrew", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("VisaPhoto", "MTCrew", true, "VisaPhoto", new List<string> {"VisaPhoto", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            VisaPhoto.GetUploadPath = () => "files/crew";
            Fields.Add("VisaPhoto", VisaPhoto);

            // Nationality_CountryID
            Nationality_CountryID = new (this, "x_Nationality_CountryID", 3, SqlDbType.Int) {
                Name = "Nationality_CountryID",
                Expression = "[Nationality_CountryID]",
                BasicSearchExpression = "CAST([Nationality_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Nationality_CountryID]",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Nationality_CountryID", "CustomMsg"),
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
                Expression = "[CountryOfOrigin_CountryID]",
                BasicSearchExpression = "CAST([CountryOfOrigin_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[CountryOfOrigin_CountryID]",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "CountryOfOrigin_CountryID", "CustomMsg"),
                IsUpload = false
            };
            CountryOfOrigin_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CountryOfOrigin_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("CountryOfOrigin_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("CountryOfOrigin_CountryID", "MTCountry", true, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("CountryOfOrigin_CountryID", CountryOfOrigin_CountryID);

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
                CustomMessage = Language.FieldPhrase("MTCrew", "DateOfBirth", "CustomMsg"),
                IsUpload = false
            };
            DateOfBirth.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("DateOfBirth", "MTCrew", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("DateOfBirth", "MTCrew", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("DateOfBirth", "MTCrew", true, "DateOfBirth", new List<string> {"DateOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("DateOfBirth", DateOfBirth);

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
                Required = true, // Required field
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "CityOfBirth", "CustomMsg"),
                IsUpload = false
            };
            CityOfBirth.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CityOfBirth", "MTCrew", true, "CityOfBirth", new List<string> {"CityOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CityOfBirth", "MTCrew", true, "CityOfBirth", new List<string> {"CityOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CityOfBirth", "MTCrew", true, "CityOfBirth", new List<string> {"CityOfBirth", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("CityOfBirth", CityOfBirth);

            // MaritalStatus
            MaritalStatus = new (this, "x_MaritalStatus", 202, SqlDbType.NVarChar) {
                Name = "MaritalStatus",
                Expression = "[MaritalStatus]",
                UseBasicSearch = true,
                BasicSearchExpression = "[MaritalStatus]",
                DateTimeFormat = -1,
                VirtualExpression = "[MaritalStatus]",
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
                OptionCount = 3,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "MaritalStatus", "CustomMsg"),
                IsUpload = false
            };
            MaritalStatus.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MaritalStatus", "MTCrew", true, "MaritalStatus", new List<string> {"MaritalStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("MaritalStatus", "MTCrew", true, "MaritalStatus", new List<string> {"MaritalStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("MaritalStatus", "MTCrew", true, "MaritalStatus", new List<string> {"MaritalStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("MaritalStatus", MaritalStatus);

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
                CustomMessage = Language.FieldPhrase("MTCrew", "Gender", "CustomMsg"),
                IsUpload = false
            };
            Gender.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Gender", "MTCrew", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Gender", "MTCrew", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Gender", "MTCrew", true, "Gender", new List<string> {"Gender", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Gender", Gender);

            // ReligionID
            ReligionID = new (this, "x_ReligionID", 3, SqlDbType.Int) {
                Name = "ReligionID",
                Expression = "[ReligionID]",
                BasicSearchExpression = "CAST([ReligionID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[ReligionID]",
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
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "ReligionID", "CustomMsg"),
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
                Expression = "[BloodType]",
                BasicSearchExpression = "[BloodType]",
                DateTimeFormat = -1,
                VirtualExpression = "[BloodType]",
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
                OptionCount = 8,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "BloodType", "CustomMsg"),
                IsUpload = false
            };
            BloodType.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("BloodType", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("BloodType", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("BloodType", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("BloodType", BloodType);

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
                HtmlTag = "SELECT",
                InputTextType = "text",
                Required = true, // Required field
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "RankAppliedFor_RankID", "CustomMsg"),
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
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "WillAcceptLowRank", "CustomMsg"),
                IsUpload = false
            };
            WillAcceptLowRank.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("WillAcceptLowRank", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("WillAcceptLowRank", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("WillAcceptLowRank", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                Required = true, // Required field
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "AvailableFrom", "CustomMsg"),
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
                Required = true, // Required field
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "AvailableUntil", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AvailableUntil", AvailableUntil);

            // PrimaryAddressDetail
            PrimaryAddressDetail = new (this, "x_PrimaryAddressDetail", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressDetail",
                Expression = "[PrimaryAddressDetail]",
                BasicSearchExpression = "[PrimaryAddressDetail]",
                DateTimeFormat = -1,
                VirtualExpression = "[PrimaryAddressDetail]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PrimaryAddressDetail", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressDetail", PrimaryAddressDetail);

            // PrimaryAddressCity
            PrimaryAddressCity = new (this, "x_PrimaryAddressCity", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressCity",
                Expression = "[PrimaryAddressCity]",
                BasicSearchExpression = "[PrimaryAddressCity]",
                DateTimeFormat = -1,
                VirtualExpression = "[PrimaryAddressCity]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PrimaryAddressCity", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressCity", PrimaryAddressCity);

            // PrimaryAddressState
            PrimaryAddressState = new (this, "x_PrimaryAddressState", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressState",
                Expression = "[PrimaryAddressState]",
                BasicSearchExpression = "[PrimaryAddressState]",
                DateTimeFormat = -1,
                VirtualExpression = "[PrimaryAddressState]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PrimaryAddressState", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressState", PrimaryAddressState);

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport = new (this, "x_PrimaryAddressNearestAirport", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressNearestAirport",
                Expression = "[PrimaryAddressNearestAirport]",
                BasicSearchExpression = "[PrimaryAddressNearestAirport]",
                DateTimeFormat = -1,
                VirtualExpression = "[PrimaryAddressNearestAirport]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PrimaryAddressNearestAirport", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressNearestAirport", PrimaryAddressNearestAirport);

            // PrimaryAddressPostCode
            PrimaryAddressPostCode = new (this, "x_PrimaryAddressPostCode", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressPostCode",
                Expression = "[PrimaryAddressPostCode]",
                BasicSearchExpression = "[PrimaryAddressPostCode]",
                DateTimeFormat = -1,
                VirtualExpression = "[PrimaryAddressPostCode]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PrimaryAddressPostCode", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressPostCode", PrimaryAddressPostCode);

            // PrimaryAddressCountryID
            PrimaryAddressCountryID = new (this, "x_PrimaryAddressCountryID", 3, SqlDbType.Int) {
                Name = "PrimaryAddressCountryID",
                Expression = "[PrimaryAddressCountryID]",
                BasicSearchExpression = "CAST([PrimaryAddressCountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PrimaryAddressCountryID]",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PrimaryAddressCountryID", "CustomMsg"),
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
                Expression = "[PrimaryAddressHomeTel]",
                BasicSearchExpression = "[PrimaryAddressHomeTel]",
                DateTimeFormat = -1,
                VirtualExpression = "[PrimaryAddressHomeTel]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PrimaryAddressHomeTel", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressHomeTel", PrimaryAddressHomeTel);

            // PrimaryAddressFax
            PrimaryAddressFax = new (this, "x_PrimaryAddressFax", 202, SqlDbType.NVarChar) {
                Name = "PrimaryAddressFax",
                Expression = "[PrimaryAddressFax]",
                BasicSearchExpression = "[PrimaryAddressFax]",
                DateTimeFormat = -1,
                VirtualExpression = "[PrimaryAddressFax]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PrimaryAddressFax", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PrimaryAddressFax", PrimaryAddressFax);

            // AlternativeAddressDetail
            AlternativeAddressDetail = new (this, "x_AlternativeAddressDetail", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressDetail",
                Expression = "[AlternativeAddressDetail]",
                BasicSearchExpression = "[AlternativeAddressDetail]",
                DateTimeFormat = -1,
                VirtualExpression = "[AlternativeAddressDetail]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "AlternativeAddressDetail", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressDetail", AlternativeAddressDetail);

            // AlternativeAddressCity
            AlternativeAddressCity = new (this, "x_AlternativeAddressCity", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressCity",
                Expression = "[AlternativeAddressCity]",
                BasicSearchExpression = "[AlternativeAddressCity]",
                DateTimeFormat = -1,
                VirtualExpression = "[AlternativeAddressCity]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "AlternativeAddressCity", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressCity", AlternativeAddressCity);

            // AlternativeAddressState
            AlternativeAddressState = new (this, "x_AlternativeAddressState", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressState",
                Expression = "[AlternativeAddressState]",
                BasicSearchExpression = "[AlternativeAddressState]",
                DateTimeFormat = -1,
                VirtualExpression = "[AlternativeAddressState]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "AlternativeAddressState", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressState", AlternativeAddressState);

            // AlternativeAddressHomeTel
            AlternativeAddressHomeTel = new (this, "x_AlternativeAddressHomeTel", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressHomeTel",
                Expression = "[AlternativeAddressHomeTel]",
                BasicSearchExpression = "[AlternativeAddressHomeTel]",
                DateTimeFormat = -1,
                VirtualExpression = "[AlternativeAddressHomeTel]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "AlternativeAddressHomeTel", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressHomeTel", AlternativeAddressHomeTel);

            // AlternativeAddressPostCode
            AlternativeAddressPostCode = new (this, "x_AlternativeAddressPostCode", 202, SqlDbType.NVarChar) {
                Name = "AlternativeAddressPostCode",
                Expression = "[AlternativeAddressPostCode]",
                BasicSearchExpression = "[AlternativeAddressPostCode]",
                DateTimeFormat = -1,
                VirtualExpression = "[AlternativeAddressPostCode]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "AlternativeAddressPostCode", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AlternativeAddressPostCode", AlternativeAddressPostCode);

            // AlternativeAddressCountryID
            AlternativeAddressCountryID = new (this, "x_AlternativeAddressCountryID", 3, SqlDbType.Int) {
                Name = "AlternativeAddressCountryID",
                Expression = "[AlternativeAddressCountryID]",
                BasicSearchExpression = "CAST([AlternativeAddressCountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[AlternativeAddressCountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "AlternativeAddressCountryID", "CustomMsg"),
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
                InputTextType = "tel",
                Required = true, // Required field
                UseFilter = true, // Table header filter
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "MobileNumber", "CustomMsg"),
                IsUpload = false
            };
            MobileNumber.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("MobileNumber", "MTCrew", true, "MobileNumber", new List<string> {"MobileNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("MobileNumber", "MTCrew", true, "MobileNumber", new List<string> {"MobileNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("MobileNumber", "MTCrew", true, "MobileNumber", new List<string> {"MobileNumber", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                InputTextType = "email",
                Required = true, // Required field
                UseFilter = true, // Table header filter
                DefaultErrorMessage = Language.Phrase("IncorrectEmail"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "_Email", "CustomMsg"),
                IsUpload = false
            };
            _Email.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Email", "MTCrew", true, "Email", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("Email", "MTCrew", true, "Email", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("Email", "MTCrew", true, "Email", new List<string> {"Email", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("Email", _Email);

            // ContactMethodEmail
            ContactMethodEmail = new (this, "x_ContactMethodEmail", 11, SqlDbType.Bit) {
                Name = "ContactMethodEmail",
                Expression = "[ContactMethodEmail]",
                BasicSearchExpression = "[ContactMethodEmail]",
                DateTimeFormat = -1,
                VirtualExpression = "[ContactMethodEmail]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "ContactMethodEmail", "CustomMsg"),
                IsUpload = false
            };
            ContactMethodEmail.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ContactMethodEmail", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("ContactMethodEmail", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("ContactMethodEmail", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("ContactMethodEmail", ContactMethodEmail);

            // ContactMethodFax
            ContactMethodFax = new (this, "x_ContactMethodFax", 11, SqlDbType.Bit) {
                Name = "ContactMethodFax",
                Expression = "[ContactMethodFax]",
                BasicSearchExpression = "[ContactMethodFax]",
                DateTimeFormat = -1,
                VirtualExpression = "[ContactMethodFax]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "ContactMethodFax", "CustomMsg"),
                IsUpload = false
            };
            ContactMethodFax.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ContactMethodFax", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("ContactMethodFax", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("ContactMethodFax", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("ContactMethodFax", ContactMethodFax);

            // ContactMethodMobilePhone
            ContactMethodMobilePhone = new (this, "x_ContactMethodMobilePhone", 11, SqlDbType.Bit) {
                Name = "ContactMethodMobilePhone",
                Expression = "[ContactMethodMobilePhone]",
                BasicSearchExpression = "[ContactMethodMobilePhone]",
                DateTimeFormat = -1,
                VirtualExpression = "[ContactMethodMobilePhone]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "ContactMethodMobilePhone", "CustomMsg"),
                IsUpload = false
            };
            ContactMethodMobilePhone.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ContactMethodMobilePhone", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("ContactMethodMobilePhone", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("ContactMethodMobilePhone", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("ContactMethodMobilePhone", ContactMethodMobilePhone);

            // ContactMethodHomePhone
            ContactMethodHomePhone = new (this, "x_ContactMethodHomePhone", 11, SqlDbType.Bit) {
                Name = "ContactMethodHomePhone",
                Expression = "[ContactMethodHomePhone]",
                BasicSearchExpression = "[ContactMethodHomePhone]",
                DateTimeFormat = -1,
                VirtualExpression = "[ContactMethodHomePhone]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "ContactMethodHomePhone", "CustomMsg"),
                IsUpload = false
            };
            ContactMethodHomePhone.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ContactMethodHomePhone", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("ContactMethodHomePhone", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("ContactMethodHomePhone", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("ContactMethodHomePhone", ContactMethodHomePhone);

            // ContactMethodPost
            ContactMethodPost = new (this, "x_ContactMethodPost", 11, SqlDbType.Bit) {
                Name = "ContactMethodPost",
                Expression = "[ContactMethodPost]",
                BasicSearchExpression = "[ContactMethodPost]",
                DateTimeFormat = -1,
                VirtualExpression = "[ContactMethodPost]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "ContactMethodPost", "CustomMsg"),
                IsUpload = false
            };
            ContactMethodPost.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ContactMethodPost", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("ContactMethodPost", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("ContactMethodPost", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("ContactMethodPost", ContactMethodPost);

            // CollarSize
            CollarSize = new (this, "x_CollarSize", 131, SqlDbType.Decimal) {
                Name = "CollarSize",
                Expression = "[CollarSize]",
                BasicSearchExpression = "CAST([CollarSize] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[CollarSize]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Required = true, // Required field
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "CollarSize", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("CollarSize", CollarSize);

            // ChestSize
            ChestSize = new (this, "x_ChestSize", 131, SqlDbType.Decimal) {
                Name = "ChestSize",
                Expression = "[ChestSize]",
                BasicSearchExpression = "CAST([ChestSize] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[ChestSize]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Required = true, // Required field
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "ChestSize", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ChestSize", ChestSize);

            // WaistSize
            WaistSize = new (this, "x_WaistSize", 131, SqlDbType.Decimal) {
                Name = "WaistSize",
                Expression = "[WaistSize]",
                BasicSearchExpression = "CAST([WaistSize] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[WaistSize]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Required = true, // Required field
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "WaistSize", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("WaistSize", WaistSize);

            // InsideLegSize
            InsideLegSize = new (this, "x_InsideLegSize", 131, SqlDbType.Decimal) {
                Name = "InsideLegSize",
                Expression = "[InsideLegSize]",
                BasicSearchExpression = "CAST([InsideLegSize] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[InsideLegSize]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Required = true, // Required field
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "InsideLegSize", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InsideLegSize", InsideLegSize);

            // CapSize
            CapSize = new (this, "x_CapSize", 131, SqlDbType.Decimal) {
                Name = "CapSize",
                Expression = "[CapSize]",
                BasicSearchExpression = "CAST([CapSize] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[CapSize]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Required = true, // Required field
                DefaultErrorMessage = Language.Phrase("IncorrectFloat"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "CapSize", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("CapSize", CapSize);

            // SweaterSize_ClothesSizeID
            SweaterSize_ClothesSizeID = new (this, "x_SweaterSize_ClothesSizeID", 3, SqlDbType.Int) {
                Name = "SweaterSize_ClothesSizeID",
                Expression = "[SweaterSize_ClothesSizeID]",
                BasicSearchExpression = "CAST([SweaterSize_ClothesSizeID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[SweaterSize_ClothesSizeID]",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "SweaterSize_ClothesSizeID", "CustomMsg"),
                IsUpload = false
            };
            SweaterSize_ClothesSizeID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("SweaterSize_ClothesSizeID", "MTClothesSize", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("SweaterSize_ClothesSizeID", "MTClothesSize", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("SweaterSize_ClothesSizeID", "MTClothesSize", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("SweaterSize_ClothesSizeID", SweaterSize_ClothesSizeID);

            // BoilersuitSize_ClothesSizeID
            BoilersuitSize_ClothesSizeID = new (this, "x_BoilersuitSize_ClothesSizeID", 3, SqlDbType.Int) {
                Name = "BoilersuitSize_ClothesSizeID",
                Expression = "[BoilersuitSize_ClothesSizeID]",
                BasicSearchExpression = "CAST([BoilersuitSize_ClothesSizeID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[BoilersuitSize_ClothesSizeID]",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "BoilersuitSize_ClothesSizeID", "CustomMsg"),
                IsUpload = false
            };
            BoilersuitSize_ClothesSizeID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("BoilersuitSize_ClothesSizeID", "MTClothesSize", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                "id-ID" => new Lookup<DbField>("BoilersuitSize_ClothesSizeID", "MTClothesSize", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]"),
                _ => new Lookup<DbField>("BoilersuitSize_ClothesSizeID", "MTClothesSize", false, "ID", new List<string> {"Name", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "[Name]")
            };
            Fields.Add("BoilersuitSize_ClothesSizeID", BoilersuitSize_ClothesSizeID);

            // SocialSecurityNumber
            SocialSecurityNumber = new (this, "x_SocialSecurityNumber", 202, SqlDbType.NVarChar) {
                Name = "SocialSecurityNumber",
                Expression = "[SocialSecurityNumber]",
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
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "SocialSecurityNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("SocialSecurityNumber", SocialSecurityNumber);

            // SocialSecurityIssuingCountryID
            SocialSecurityIssuingCountryID = new (this, "x_SocialSecurityIssuingCountryID", 3, SqlDbType.Int) {
                Name = "SocialSecurityIssuingCountryID",
                Expression = "[SocialSecurityIssuingCountryID]",
                BasicSearchExpression = "CAST([SocialSecurityIssuingCountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[SocialSecurityIssuingCountryID]",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "SocialSecurityIssuingCountryID", "CustomMsg"),
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
                Expression = "[SocialSecurityImage]",
                BasicSearchExpression = "[SocialSecurityImage]",
                DateTimeFormat = -1,
                VirtualExpression = "[SocialSecurityImage]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                Required = true, // Required field
                UploadAllowedFileExtensions = "jpg,jpeg,gif,png",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "SocialSecurityImage", "CustomMsg"),
                IsUpload = true
            };
            SocialSecurityImage.GetUploadPath = () => "files/social-security";
            Fields.Add("SocialSecurityImage", SocialSecurityImage);

            // PersonalTaxNumber
            PersonalTaxNumber = new (this, "x_PersonalTaxNumber", 202, SqlDbType.NVarChar) {
                Name = "PersonalTaxNumber",
                Expression = "[PersonalTaxNumber]",
                BasicSearchExpression = "[PersonalTaxNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[PersonalTaxNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PersonalTaxNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PersonalTaxNumber", PersonalTaxNumber);

            // PersonalTaxIssuingCountryID
            PersonalTaxIssuingCountryID = new (this, "x_PersonalTaxIssuingCountryID", 3, SqlDbType.Int) {
                Name = "PersonalTaxIssuingCountryID",
                Expression = "[PersonalTaxIssuingCountryID]",
                BasicSearchExpression = "CAST([PersonalTaxIssuingCountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PersonalTaxIssuingCountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "PersonalTaxIssuingCountryID", "CustomMsg"),
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
                Expression = "[PersonalTaxImage]",
                BasicSearchExpression = "[PersonalTaxImage]",
                DateTimeFormat = -1,
                VirtualExpression = "[PersonalTaxImage]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "FILE",
                InputTextType = "text",
                UploadAllowedFileExtensions = "jpg,jpeg,gif,png",
                UploadMaxFileSize = 2000000,
                SearchOperators = new () { "=", "<>", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "PersonalTaxImage", "CustomMsg"),
                IsUpload = true
            };
            PersonalTaxImage.GetUploadPath = () => "files/personal-tax";
            Fields.Add("PersonalTaxImage", PersonalTaxImage);

            // NomineeFullName
            NomineeFullName = new (this, "x_NomineeFullName", 202, SqlDbType.NVarChar) {
                Name = "NomineeFullName",
                Expression = "[NomineeFullName]",
                BasicSearchExpression = "[NomineeFullName]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeFullName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeFullName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeFullName", NomineeFullName);

            // NomineeRelationship
            NomineeRelationship = new (this, "x_NomineeRelationship", 202, SqlDbType.NVarChar) {
                Name = "NomineeRelationship",
                Expression = "[NomineeRelationship]",
                BasicSearchExpression = "[NomineeRelationship]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeRelationship]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeRelationship", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeRelationship", NomineeRelationship);

            // NomineeGender
            NomineeGender = new (this, "x_NomineeGender", 202, SqlDbType.NVarChar) {
                Name = "NomineeGender",
                Expression = "[NomineeGender]",
                BasicSearchExpression = "[NomineeGender]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeGender]",
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
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeGender", "CustomMsg"),
                IsUpload = false
            };
            NomineeGender.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("NomineeGender", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("NomineeGender", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("NomineeGender", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("NomineeGender", NomineeGender);

            // NomineeNationality_CountryID
            NomineeNationality_CountryID = new (this, "x_NomineeNationality_CountryID", 3, SqlDbType.Int) {
                Name = "NomineeNationality_CountryID",
                Expression = "[NomineeNationality_CountryID]",
                BasicSearchExpression = "CAST([NomineeNationality_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeNationality_CountryID]",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeNationality_CountryID", "CustomMsg"),
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
                Expression = "[NomineeAddressDetail]",
                BasicSearchExpression = "[NomineeAddressDetail]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeAddressDetail]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeAddressDetail", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeAddressDetail", NomineeAddressDetail);

            // NomineeAddressCity
            NomineeAddressCity = new (this, "x_NomineeAddressCity", 202, SqlDbType.NVarChar) {
                Name = "NomineeAddressCity",
                Expression = "[NomineeAddressCity]",
                BasicSearchExpression = "[NomineeAddressCity]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeAddressCity]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeAddressCity", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeAddressCity", NomineeAddressCity);

            // NomineeAddressPostCode
            NomineeAddressPostCode = new (this, "x_NomineeAddressPostCode", 202, SqlDbType.NVarChar) {
                Name = "NomineeAddressPostCode",
                Expression = "[NomineeAddressPostCode]",
                BasicSearchExpression = "[NomineeAddressPostCode]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeAddressPostCode]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeAddressPostCode", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeAddressPostCode", NomineeAddressPostCode);

            // NomineeAddressCountryID
            NomineeAddressCountryID = new (this, "x_NomineeAddressCountryID", 3, SqlDbType.Int) {
                Name = "NomineeAddressCountryID",
                Expression = "[NomineeAddressCountryID]",
                BasicSearchExpression = "CAST([NomineeAddressCountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeAddressCountryID]",
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
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeAddressCountryID", "CustomMsg"),
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
                Expression = "[NomineeAddressHomeTel]",
                BasicSearchExpression = "[NomineeAddressHomeTel]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeAddressHomeTel]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeAddressHomeTel", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeAddressHomeTel", NomineeAddressHomeTel);

            // NomineeEmail
            NomineeEmail = new (this, "x_NomineeEmail", 202, SqlDbType.NVarChar) {
                Name = "NomineeEmail",
                Expression = "[NomineeEmail]",
                BasicSearchExpression = "[NomineeEmail]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeEmail]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "email",
                Required = true, // Required field
                DefaultErrorMessage = Language.Phrase("IncorrectEmail"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeEmail", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeEmail", NomineeEmail);

            // NomineeMobileNumber
            NomineeMobileNumber = new (this, "x_NomineeMobileNumber", 202, SqlDbType.NVarChar) {
                Name = "NomineeMobileNumber",
                Expression = "[NomineeMobileNumber]",
                BasicSearchExpression = "[NomineeMobileNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeMobileNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeMobileNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NomineeMobileNumber", NomineeMobileNumber);

            // NomineeValidVisa
            NomineeValidVisa = new (this, "x_NomineeValidVisa", 202, SqlDbType.NVarChar) {
                Name = "NomineeValidVisa",
                Expression = "[NomineeValidVisa]",
                BasicSearchExpression = "[NomineeValidVisa]",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeValidVisa]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                OptionCount = 6,
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeValidVisa", "CustomMsg"),
                IsUpload = false
            };
            NomineeValidVisa.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("NomineeValidVisa", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("NomineeValidVisa", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("NomineeValidVisa", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("NomineeValidVisa", NomineeValidVisa);

            // BankName
            BankName = new (this, "x_BankName", 202, SqlDbType.NVarChar) {
                Name = "BankName",
                Expression = "[BankName]",
                BasicSearchExpression = "[BankName]",
                DateTimeFormat = -1,
                VirtualExpression = "[BankName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "BankName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BankName", BankName);

            // BankAddress
            BankAddress = new (this, "x_BankAddress", 202, SqlDbType.NVarChar) {
                Name = "BankAddress",
                Expression = "[BankAddress]",
                BasicSearchExpression = "[BankAddress]",
                DateTimeFormat = -1,
                VirtualExpression = "[BankAddress]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "BankAddress", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BankAddress", BankAddress);

            // BankAccountName
            BankAccountName = new (this, "x_BankAccountName", 202, SqlDbType.NVarChar) {
                Name = "BankAccountName",
                Expression = "[BankAccountName]",
                BasicSearchExpression = "[BankAccountName]",
                DateTimeFormat = -1,
                VirtualExpression = "[BankAccountName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "BankAccountName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BankAccountName", BankAccountName);

            // BankAccountNumber
            BankAccountNumber = new (this, "x_BankAccountNumber", 202, SqlDbType.NVarChar) {
                Name = "BankAccountNumber",
                Expression = "[BankAccountNumber]",
                BasicSearchExpression = "[BankAccountNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[BankAccountNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "number",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "BankAccountNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BankAccountNumber", BankAccountNumber);

            // BankSortCode
            BankSortCode = new (this, "x_BankSortCode", 202, SqlDbType.NVarChar) {
                Name = "BankSortCode",
                Expression = "[BankSortCode]",
                BasicSearchExpression = "[BankSortCode]",
                DateTimeFormat = -1,
                VirtualExpression = "[BankSortCode]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Required = true, // Required field
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "BankSortCode", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BankSortCode", BankSortCode);

            // MNOPF
            MNOPF = new (this, "x_MNOPF", 202, SqlDbType.NVarChar) {
                Name = "MNOPF",
                Expression = "[MNOPF]",
                BasicSearchExpression = "[MNOPF]",
                DateTimeFormat = -1,
                VirtualExpression = "[MNOPF]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "MNOPF", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MNOPF", MNOPF);

            // MembershipNumber
            MembershipNumber = new (this, "x_MembershipNumber", 202, SqlDbType.NVarChar) {
                Name = "MembershipNumber",
                Expression = "[MembershipNumber]",
                BasicSearchExpression = "[MembershipNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[MembershipNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "MembershipNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MembershipNumber", MembershipNumber);

            // NationalInsuranceNumber
            NationalInsuranceNumber = new (this, "x_NationalInsuranceNumber", 202, SqlDbType.NVarChar) {
                Name = "NationalInsuranceNumber",
                Expression = "[NationalInsuranceNumber]",
                BasicSearchExpression = "[NationalInsuranceNumber]",
                DateTimeFormat = -1,
                VirtualExpression = "[NationalInsuranceNumber]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NationalInsuranceNumber", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NationalInsuranceNumber", NationalInsuranceNumber);

            // AVC
            AVC = new (this, "x_AVC", 202, SqlDbType.NVarChar) {
                Name = "AVC",
                Expression = "[AVC]",
                BasicSearchExpression = "[AVC]",
                DateTimeFormat = -1,
                VirtualExpression = "[AVC]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "AVC", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("AVC", AVC);

            // ForeignVisaHasBeenDenied
            ForeignVisaHasBeenDenied = new (this, "x_ForeignVisaHasBeenDenied", 11, SqlDbType.Bit) {
                Name = "ForeignVisaHasBeenDenied",
                Expression = "[ForeignVisaHasBeenDenied]",
                BasicSearchExpression = "[ForeignVisaHasBeenDenied]",
                DateTimeFormat = -1,
                VirtualExpression = "[ForeignVisaHasBeenDenied]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                Required = true, // Required field
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "ForeignVisaHasBeenDenied", "CustomMsg"),
                IsUpload = false
            };
            ForeignVisaHasBeenDenied.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("ForeignVisaHasBeenDenied", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("ForeignVisaHasBeenDenied", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("ForeignVisaHasBeenDenied", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("ForeignVisaHasBeenDenied", ForeignVisaHasBeenDenied);

            // ForeignVisaDenied_CountryID
            ForeignVisaDenied_CountryID = new (this, "x_ForeignVisaDenied_CountryID", 3, SqlDbType.Int) {
                Name = "ForeignVisaDenied_CountryID",
                Expression = "[ForeignVisaDenied_CountryID]",
                BasicSearchExpression = "CAST([ForeignVisaDenied_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[ForeignVisaDenied_CountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "ForeignVisaDenied_CountryID", "CustomMsg"),
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
                Expression = "[ForeignVisaDeniedReason]",
                BasicSearchExpression = "[ForeignVisaDeniedReason]",
                DateTimeFormat = -1,
                VirtualExpression = "[ForeignVisaDeniedReason]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "ForeignVisaDeniedReason", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ForeignVisaDeniedReason", ForeignVisaDeniedReason);

            // HasMaritimeAccidentOrCourtOfEnquiry
            HasMaritimeAccidentOrCourtOfEnquiry = new (this, "x_HasMaritimeAccidentOrCourtOfEnquiry", 11, SqlDbType.Bit) {
                Name = "HasMaritimeAccidentOrCourtOfEnquiry",
                Expression = "[HasMaritimeAccidentOrCourtOfEnquiry]",
                BasicSearchExpression = "[HasMaritimeAccidentOrCourtOfEnquiry]",
                DateTimeFormat = -1,
                VirtualExpression = "[HasMaritimeAccidentOrCourtOfEnquiry]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "CHECKBOX",
                InputTextType = "text",
                Required = true, // Required field
                DataType = DataType.Boolean,
                OptionCount = 2,
                SearchOperators = new () { "=", "<>", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "HasMaritimeAccidentOrCourtOfEnquiry", "CustomMsg"),
                IsUpload = false
            };
            HasMaritimeAccidentOrCourtOfEnquiry.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("HasMaritimeAccidentOrCourtOfEnquiry", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("HasMaritimeAccidentOrCourtOfEnquiry", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("HasMaritimeAccidentOrCourtOfEnquiry", "MTCrew", false, "", new List<string> {"", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("HasMaritimeAccidentOrCourtOfEnquiry", HasMaritimeAccidentOrCourtOfEnquiry);

            // HasMaritimeAccidentOrCourtOfEnquiryDetails
            HasMaritimeAccidentOrCourtOfEnquiryDetails = new (this, "x_HasMaritimeAccidentOrCourtOfEnquiryDetails", 202, SqlDbType.NVarChar) {
                Name = "HasMaritimeAccidentOrCourtOfEnquiryDetails",
                Expression = "[HasMaritimeAccidentOrCourtOfEnquiryDetails]",
                BasicSearchExpression = "[HasMaritimeAccidentOrCourtOfEnquiryDetails]",
                DateTimeFormat = -1,
                VirtualExpression = "[HasMaritimeAccidentOrCourtOfEnquiryDetails]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "HasMaritimeAccidentOrCourtOfEnquiryDetails", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("HasMaritimeAccidentOrCourtOfEnquiryDetails", HasMaritimeAccidentOrCourtOfEnquiryDetails);

            // Reference1CompanyName
            Reference1CompanyName = new (this, "x_Reference1CompanyName", 202, SqlDbType.NVarChar) {
                Name = "Reference1CompanyName",
                Expression = "[Reference1CompanyName]",
                BasicSearchExpression = "[Reference1CompanyName]",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference1CompanyName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference1CompanyName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference1CompanyName", Reference1CompanyName);

            // Reference1ContactPersonName
            Reference1ContactPersonName = new (this, "x_Reference1ContactPersonName", 202, SqlDbType.NVarChar) {
                Name = "Reference1ContactPersonName",
                Expression = "[Reference1ContactPersonName]",
                BasicSearchExpression = "[Reference1ContactPersonName]",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference1ContactPersonName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference1ContactPersonName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference1ContactPersonName", Reference1ContactPersonName);

            // Reference1CompanyAddress
            Reference1CompanyAddress = new (this, "x_Reference1CompanyAddress", 202, SqlDbType.NVarChar) {
                Name = "Reference1CompanyAddress",
                Expression = "[Reference1CompanyAddress]",
                BasicSearchExpression = "[Reference1CompanyAddress]",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference1CompanyAddress]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference1CompanyAddress", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference1CompanyAddress", Reference1CompanyAddress);

            // Reference1CompanyCountryID
            Reference1CompanyCountryID = new (this, "x_Reference1CompanyCountryID", 3, SqlDbType.Int) {
                Name = "Reference1CompanyCountryID",
                Expression = "[Reference1CompanyCountryID]",
                BasicSearchExpression = "CAST([Reference1CompanyCountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference1CompanyCountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference1CompanyCountryID", "CustomMsg"),
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
                Expression = "[Reference1CompanyTelephone]",
                BasicSearchExpression = "[Reference1CompanyTelephone]",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference1CompanyTelephone]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference1CompanyTelephone", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference1CompanyTelephone", Reference1CompanyTelephone);

            // Reference2CompanyName
            Reference2CompanyName = new (this, "x_Reference2CompanyName", 202, SqlDbType.NVarChar) {
                Name = "Reference2CompanyName",
                Expression = "[Reference2CompanyName]",
                BasicSearchExpression = "[Reference2CompanyName]",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference2CompanyName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference2CompanyName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference2CompanyName", Reference2CompanyName);

            // Reference2ContactPersonName
            Reference2ContactPersonName = new (this, "x_Reference2ContactPersonName", 202, SqlDbType.NVarChar) {
                Name = "Reference2ContactPersonName",
                Expression = "[Reference2ContactPersonName]",
                BasicSearchExpression = "[Reference2ContactPersonName]",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference2ContactPersonName]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference2ContactPersonName", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference2ContactPersonName", Reference2ContactPersonName);

            // Reference2CompanyAddress
            Reference2CompanyAddress = new (this, "x_Reference2CompanyAddress", 202, SqlDbType.NVarChar) {
                Name = "Reference2CompanyAddress",
                Expression = "[Reference2CompanyAddress]",
                BasicSearchExpression = "[Reference2CompanyAddress]",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference2CompanyAddress]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference2CompanyAddress", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference2CompanyAddress", Reference2CompanyAddress);

            // Reference2CompanyCountryID
            Reference2CompanyCountryID = new (this, "x_Reference2CompanyCountryID", 3, SqlDbType.Int) {
                Name = "Reference2CompanyCountryID",
                Expression = "[Reference2CompanyCountryID]",
                BasicSearchExpression = "CAST([Reference2CompanyCountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference2CompanyCountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference2CompanyCountryID", "CustomMsg"),
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
                Expression = "[Reference2CompanyTelephone]",
                BasicSearchExpression = "[Reference2CompanyTelephone]",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference2CompanyTelephone]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "tel",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference2CompanyTelephone", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reference2CompanyTelephone", Reference2CompanyTelephone);

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
                CustomMessage = Language.FieldPhrase("MTCrew", "EmployeeStatus", "CustomMsg"),
                IsUpload = false
            };
            EmployeeStatus.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("EmployeeStatus", "MTCrew", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("EmployeeStatus", "MTCrew", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("EmployeeStatus", "MTCrew", true, "EmployeeStatus", new List<string> {"EmployeeStatus", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("EmployeeStatus", EmployeeStatus);

            // FormSubmittedDateTime
            FormSubmittedDateTime = new (this, "x_FormSubmittedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "FormSubmittedDateTime",
                Expression = "[FormSubmittedDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[FormSubmittedDateTime]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[FormSubmittedDateTime]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "FormSubmittedDateTime", "CustomMsg"),
                IsUpload = false
            };
            FormSubmittedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("FormSubmittedDateTime", "MTCrew", true, "FormSubmittedDateTime", new List<string> {"FormSubmittedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("FormSubmittedDateTime", "MTCrew", true, "FormSubmittedDateTime", new List<string> {"FormSubmittedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("FormSubmittedDateTime", "MTCrew", true, "FormSubmittedDateTime", new List<string> {"FormSubmittedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
            };
            Fields.Add("FormSubmittedDateTime", FormSubmittedDateTime);

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
                CustomMessage = Language.FieldPhrase("MTCrew", "ActiveDescription", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ActiveDescription", ActiveDescription);

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
                CustomMessage = Language.FieldPhrase("MTCrew", "CreatedByUserID", "CustomMsg"),
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
                CustomMessage = Language.FieldPhrase("MTCrew", "CreatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            CreatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("CreatedDateTime", "MTCrew", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("CreatedDateTime", "MTCrew", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("CreatedDateTime", "MTCrew", true, "CreatedDateTime", new List<string> {"CreatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("MTCrew", "LastUpdatedByUserID", "CustomMsg"),
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
                CustomMessage = Language.FieldPhrase("MTCrew", "LastUpdatedDateTime", "CustomMsg"),
                IsUpload = false
            };
            LastUpdatedDateTime.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("LastUpdatedDateTime", "MTCrew", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                "id-ID" => new Lookup<DbField>("LastUpdatedDateTime", "MTCrew", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", ""),
                _ => new Lookup<DbField>("LastUpdatedDateTime", "MTCrew", true, "LastUpdatedDateTime", new List<string> {"LastUpdatedDateTime", "", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "", "")
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
                CustomMessage = Language.FieldPhrase("MTCrew", "MTUserID", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MTUserID", MTUserID);

            // DocumentCheckDateTime
            DocumentCheckDateTime = new (this, "x_DocumentCheckDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "DocumentCheckDateTime",
                Expression = "[DocumentCheckDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[DocumentCheckDateTime]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[DocumentCheckDateTime]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "DocumentCheckDateTime", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("DocumentCheckDateTime", DocumentCheckDateTime);

            // InterviewManagerDateTime
            InterviewManagerDateTime = new (this, "x_InterviewManagerDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "InterviewManagerDateTime",
                Expression = "[InterviewManagerDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[InterviewManagerDateTime]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[InterviewManagerDateTime]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "InterviewManagerDateTime", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewManagerDateTime", InterviewManagerDateTime);

            // InterviewGMDateTime
            InterviewGMDateTime = new (this, "x_InterviewGMDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "InterviewGMDateTime",
                Expression = "[InterviewGMDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[InterviewGMDateTime]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[InterviewGMDateTime]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "InterviewGMDateTime", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("InterviewGMDateTime", InterviewGMDateTime);

            // MCUScheduleDateTime
            MCUScheduleDateTime = new (this, "x_MCUScheduleDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "MCUScheduleDateTime",
                Expression = "[MCUScheduleDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[MCUScheduleDateTime]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[MCUScheduleDateTime]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "MCUScheduleDateTime", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MCUScheduleDateTime", MCUScheduleDateTime);

            // RejectedReason
            RejectedReason = new (this, "x_RejectedReason", 202, SqlDbType.NVarChar) {
                Name = "RejectedReason",
                Expression = "[RejectedReason]",
                BasicSearchExpression = "[RejectedReason]",
                DateTimeFormat = -1,
                VirtualExpression = "[RejectedReason]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXTAREA",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "RejectedReason", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RejectedReason", RejectedReason);

            // RejectedDateTime
            RejectedDateTime = new (this, "x_RejectedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "RejectedDateTime",
                Expression = "[RejectedDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[RejectedDateTime]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[RejectedDateTime]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "RejectedDateTime", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RejectedDateTime", RejectedDateTime);

            // Status
            Status = new (this, "x_Status", 202, SqlDbType.NVarChar) {
                Name = "Status",
                Expression = "[Status]",
                BasicSearchExpression = "[Status]",
                DateTimeFormat = -1,
                VirtualExpression = "[Status]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Status", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Status", Status);

            // Reason
            Reason = new (this, "x_Reason", 202, SqlDbType.NVarChar) {
                Name = "Reason",
                Expression = "[Reason]",
                BasicSearchExpression = "[Reason]",
                DateTimeFormat = -1,
                VirtualExpression = "[Reason]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "Reason", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Reason", Reason);

            // Weight
            Weight = new (this, "x_Weight", 3, SqlDbType.Int) {
                Name = "Weight",
                Expression = "[Weight]",
                BasicSearchExpression = "CAST([Weight] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Weight]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "Weight", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Weight", Weight);

            // Height
            Height = new (this, "x_Height", 3, SqlDbType.Int) {
                Name = "Height",
                Expression = "[Height]",
                BasicSearchExpression = "CAST([Height] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Height]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "Height", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Height", Height);

            // CoverallSize
            CoverallSize = new (this, "x_CoverallSize", 202, SqlDbType.NVarChar) {
                Name = "CoverallSize",
                Expression = "[CoverallSize]",
                BasicSearchExpression = "[CoverallSize]",
                DateTimeFormat = -1,
                VirtualExpression = "[CoverallSize]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "CoverallSize", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("CoverallSize", CoverallSize);

            // SafetyShoesSize
            SafetyShoesSize = new (this, "x_SafetyShoesSize", 3, SqlDbType.Int) {
                Name = "SafetyShoesSize",
                Expression = "[SafetyShoesSize]",
                BasicSearchExpression = "CAST([SafetyShoesSize] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[SafetyShoesSize]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "SafetyShoesSize", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("SafetyShoesSize", SafetyShoesSize);

            // ShirtSize
            ShirtSize = new (this, "x_ShirtSize", 202, SqlDbType.NVarChar) {
                Name = "ShirtSize",
                Expression = "[ShirtSize]",
                BasicSearchExpression = "[ShirtSize]",
                DateTimeFormat = -1,
                VirtualExpression = "[ShirtSize]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "ShirtSize", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("ShirtSize", ShirtSize);

            // TrousersSize
            TrousersSize = new (this, "x_TrousersSize", 202, SqlDbType.NVarChar) {
                Name = "TrousersSize",
                Expression = "[TrousersSize]",
                BasicSearchExpression = "[TrousersSize]",
                DateTimeFormat = -1,
                VirtualExpression = "[TrousersSize]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "TrousersSize", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("TrousersSize", TrousersSize);

            // NSSF_Health_Number
            NSSF_Health_Number = new (this, "x_NSSF_Health_Number", 202, SqlDbType.NVarChar) {
                Name = "NSSF_Health_Number",
                Expression = "[NSSF_Health_Number]",
                BasicSearchExpression = "[NSSF_Health_Number]",
                DateTimeFormat = -1,
                VirtualExpression = "[NSSF_Health_Number]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NSSF_Health_Number", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NSSF_Health_Number", NSSF_Health_Number);

            // NSSF_Occupation_Number
            NSSF_Occupation_Number = new (this, "x_NSSF_Occupation_Number", 202, SqlDbType.NVarChar) {
                Name = "NSSF_Occupation_Number",
                Expression = "[NSSF_Occupation_Number]",
                BasicSearchExpression = "[NSSF_Occupation_Number]",
                DateTimeFormat = -1,
                VirtualExpression = "[NSSF_Occupation_Number]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "NSSF_Occupation_Number", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NSSF_Occupation_Number", NSSF_Occupation_Number);

            // FinalAcceptedDate
            FinalAcceptedDate = new (this, "x_FinalAcceptedDate", 146, SqlDbType.DateTimeOffset) {
                Name = "FinalAcceptedDate",
                Expression = "[FinalAcceptedDate]",
                BasicSearchExpression = CastDateFieldForLike("[FinalAcceptedDate]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[FinalAcceptedDate]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "FinalAcceptedDate", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("FinalAcceptedDate", FinalAcceptedDate);

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID = new (this, "x_Reference1CompanyTelephoneCode_CountryID", 3, SqlDbType.Int) {
                Name = "Reference1CompanyTelephoneCode_CountryID",
                Expression = "[Reference1CompanyTelephoneCode_CountryID]",
                BasicSearchExpression = "CAST([Reference1CompanyTelephoneCode_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference1CompanyTelephoneCode_CountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference1CompanyTelephoneCode_CountryID", "CustomMsg"),
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
                Expression = "[Reference2CompanyTelephoneCode_CountryID]",
                BasicSearchExpression = "CAST([Reference2CompanyTelephoneCode_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[Reference2CompanyTelephoneCode_CountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "Reference2CompanyTelephoneCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            Reference2CompanyTelephoneCode_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("Reference2CompanyTelephoneCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, Reference2CompanyTelephoneCode_CountryID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("Reference2CompanyTelephoneCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, Reference2CompanyTelephoneCode_CountryID) + "',[Name])"),
                _ => new Lookup<DbField>("Reference2CompanyTelephoneCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, Reference2CompanyTelephoneCode_CountryID) + "',[Name])")
            };
            Fields.Add("Reference2CompanyTelephoneCode_CountryID", Reference2CompanyTelephoneCode_CountryID);

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
                HtmlTag = "SELECT",
                InputTextType = "text",
                Sortable = false, // Allow sort
                UsePleaseSelect = true, // Use PleaseSelect by default
                PleaseSelectText = Language.Phrase("PleaseSelect"), // PleaseSelect text
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "MobileNumberCode_CountryID", "CustomMsg"),
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
                Expression = "[PrimaryAddressHomeTelCode_CountryID]",
                BasicSearchExpression = "CAST([PrimaryAddressHomeTelCode_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[PrimaryAddressHomeTelCode_CountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "PrimaryAddressHomeTelCode_CountryID", "CustomMsg"),
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
                Expression = "[AlternativeAddressHomeTelCode_CountryID]",
                BasicSearchExpression = "CAST([AlternativeAddressHomeTelCode_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[AlternativeAddressHomeTelCode_CountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "AlternativeAddressHomeTelCode_CountryID", "CustomMsg"),
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
                Expression = "[NomineeAddressHomeTelCode_CountryID]",
                BasicSearchExpression = "CAST([NomineeAddressHomeTelCode_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeAddressHomeTelCode_CountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeAddressHomeTelCode_CountryID", "CustomMsg"),
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
                Expression = "[NomineeMobileNumberCode_CountryID]",
                BasicSearchExpression = "CAST([NomineeMobileNumberCode_CountryID] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[NomineeMobileNumberCode_CountryID]",
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
                CustomMessage = Language.FieldPhrase("MTCrew", "NomineeMobileNumberCode_CountryID", "CustomMsg"),
                IsUpload = false
            };
            NomineeMobileNumberCode_CountryID.Lookup = CurrentLanguage switch {
                "en-US" => new Lookup<DbField>("NomineeMobileNumberCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, NomineeMobileNumberCode_CountryID) + "',[Name])"),
                "id-ID" => new Lookup<DbField>("NomineeMobileNumberCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, NomineeMobileNumberCode_CountryID) + "',[Name])"),
                _ => new Lookup<DbField>("NomineeMobileNumberCode_CountryID", "MTCountry", false, "ID", new List<string> {"CallingCode", "Name", "", ""}, "", "", new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, new List<string> {}, "", "<span>{{:df}} ({{:df2}})</span>", "CONCAT([CallingCode],'" + ValueSeparator(1, NomineeMobileNumberCode_CountryID) + "',[Name])")
            };
            Fields.Add("NomineeMobileNumberCode_CountryID", NomineeMobileNumberCode_CountryID);

            // RevisedReason
            RevisedReason = new (this, "x_RevisedReason", 202, SqlDbType.NVarChar) {
                Name = "RevisedReason",
                Expression = "[RevisedReason]",
                UseBasicSearch = true,
                BasicSearchExpression = "[RevisedReason]",
                DateTimeFormat = -1,
                VirtualExpression = "[RevisedReason]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "RevisedReason", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RevisedReason", RevisedReason);

            // RevisedDateTime
            RevisedDateTime = new (this, "x_RevisedDateTime", 146, SqlDbType.DateTimeOffset) {
                Name = "RevisedDateTime",
                Expression = "[RevisedDateTime]",
                BasicSearchExpression = CastDateFieldForLike("[RevisedDateTime]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[RevisedDateTime]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("MTCrew", "RevisedDateTime", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RevisedDateTime", RevisedDateTime);

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
                if (CurrentDetailTable == "MTCrewCertificate" && mtCrewCertificate != null) {
                    detailUrl = mtCrewCertificate.ListUrl + "?" + Config.TableShowMaster + "=" + TableVar;
                    detailUrl += "&" + ForeignKeyUrl("fk_ID", ID.CurrentValue);
                }
                if (CurrentDetailTable == "MTCrewDocument" && mtCrewDocument != null) {
                    detailUrl = mtCrewDocument.ListUrl + "?" + Config.TableShowMaster + "=" + TableVar;
                    detailUrl += "&" + ForeignKeyUrl("fk_ID", ID.CurrentValue);
                }
                if (CurrentDetailTable == "MTCrewExperience" && mtCrewExperience != null) {
                    detailUrl = mtCrewExperience.ListUrl + "?" + Config.TableShowMaster + "=" + TableVar;
                    detailUrl += "&" + ForeignKeyUrl("fk_ID", ID.CurrentValue);
                }
                if (CurrentDetailTable == "MTCrewFamily" && mtCrewFamily != null) {
                    detailUrl = mtCrewFamily.ListUrl + "?" + Config.TableShowMaster + "=" + TableVar;
                    detailUrl += "&" + ForeignKeyUrl("fk_ID", ID.CurrentValue);
                }
                if (CurrentDetailTable == "MTCrewMedicalHistory" && mtCrewMedicalHistory != null) {
                    detailUrl = mtCrewMedicalHistory.ListUrl + "?" + Config.TableShowMaster + "=" + TableVar;
                    detailUrl += "&" + ForeignKeyUrl("fk_ID", ID.CurrentValue);
                }
                if (Empty(detailUrl))
                    detailUrl = "MtCrewList";
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
            get => _sqlFrom ?? "dbo.MTCrew";
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
                IndividualCodeNumber.DbValue = row["IndividualCodeNumber"]; // Set DB value only
                FullName.DbValue = row["FullName"]; // Set DB value only
                FirstName.DbValue = row["FirstName"]; // Set DB value only
                MiddleName.DbValue = row["MiddleName"]; // Set DB value only
                LastName.DbValue = row["LastName"]; // Set DB value only
                RequiredPhoto.Upload.DbValue = row["RequiredPhoto"];
                VisaPhoto.Upload.DbValue = row["VisaPhoto"];
                Nationality_CountryID.DbValue = row["Nationality_CountryID"]; // Set DB value only
                CountryOfOrigin_CountryID.DbValue = row["CountryOfOrigin_CountryID"]; // Set DB value only
                DateOfBirth.DbValue = row["DateOfBirth"]; // Set DB value only
                CityOfBirth.DbValue = row["CityOfBirth"]; // Set DB value only
                MaritalStatus.DbValue = row["MaritalStatus"]; // Set DB value only
                Gender.DbValue = row["Gender"]; // Set DB value only
                ReligionID.DbValue = row["ReligionID"]; // Set DB value only
                BloodType.DbValue = row["BloodType"]; // Set DB value only
                RankAppliedFor_RankID.DbValue = row["RankAppliedFor_RankID"]; // Set DB value only
                WillAcceptLowRank.DbValue = (ConvertToBool(row["WillAcceptLowRank"]) ? "1" : "0"); // Set DB value only
                AvailableFrom.DbValue = row["AvailableFrom"]; // Set DB value only
                AvailableUntil.DbValue = row["AvailableUntil"]; // Set DB value only
                PrimaryAddressDetail.DbValue = row["PrimaryAddressDetail"]; // Set DB value only
                PrimaryAddressCity.DbValue = row["PrimaryAddressCity"]; // Set DB value only
                PrimaryAddressState.DbValue = row["PrimaryAddressState"]; // Set DB value only
                PrimaryAddressNearestAirport.DbValue = row["PrimaryAddressNearestAirport"]; // Set DB value only
                PrimaryAddressPostCode.DbValue = row["PrimaryAddressPostCode"]; // Set DB value only
                PrimaryAddressCountryID.DbValue = row["PrimaryAddressCountryID"]; // Set DB value only
                PrimaryAddressHomeTel.DbValue = row["PrimaryAddressHomeTel"]; // Set DB value only
                PrimaryAddressFax.DbValue = row["PrimaryAddressFax"]; // Set DB value only
                AlternativeAddressDetail.DbValue = row["AlternativeAddressDetail"]; // Set DB value only
                AlternativeAddressCity.DbValue = row["AlternativeAddressCity"]; // Set DB value only
                AlternativeAddressState.DbValue = row["AlternativeAddressState"]; // Set DB value only
                AlternativeAddressHomeTel.DbValue = row["AlternativeAddressHomeTel"]; // Set DB value only
                AlternativeAddressPostCode.DbValue = row["AlternativeAddressPostCode"]; // Set DB value only
                AlternativeAddressCountryID.DbValue = row["AlternativeAddressCountryID"]; // Set DB value only
                MobileNumber.DbValue = row["MobileNumber"]; // Set DB value only
                _Email.DbValue = row["Email"]; // Set DB value only
                ContactMethodEmail.DbValue = (ConvertToBool(row["ContactMethodEmail"]) ? "1" : "0"); // Set DB value only
                ContactMethodFax.DbValue = (ConvertToBool(row["ContactMethodFax"]) ? "1" : "0"); // Set DB value only
                ContactMethodMobilePhone.DbValue = (ConvertToBool(row["ContactMethodMobilePhone"]) ? "1" : "0"); // Set DB value only
                ContactMethodHomePhone.DbValue = (ConvertToBool(row["ContactMethodHomePhone"]) ? "1" : "0"); // Set DB value only
                ContactMethodPost.DbValue = (ConvertToBool(row["ContactMethodPost"]) ? "1" : "0"); // Set DB value only
                CollarSize.DbValue = row["CollarSize"]; // Set DB value only
                ChestSize.DbValue = row["ChestSize"]; // Set DB value only
                WaistSize.DbValue = row["WaistSize"]; // Set DB value only
                InsideLegSize.DbValue = row["InsideLegSize"]; // Set DB value only
                CapSize.DbValue = row["CapSize"]; // Set DB value only
                SweaterSize_ClothesSizeID.DbValue = row["SweaterSize_ClothesSizeID"]; // Set DB value only
                BoilersuitSize_ClothesSizeID.DbValue = row["BoilersuitSize_ClothesSizeID"]; // Set DB value only
                SocialSecurityNumber.DbValue = row["SocialSecurityNumber"]; // Set DB value only
                SocialSecurityIssuingCountryID.DbValue = row["SocialSecurityIssuingCountryID"]; // Set DB value only
                SocialSecurityImage.Upload.DbValue = row["SocialSecurityImage"];
                PersonalTaxNumber.DbValue = row["PersonalTaxNumber"]; // Set DB value only
                PersonalTaxIssuingCountryID.DbValue = row["PersonalTaxIssuingCountryID"]; // Set DB value only
                PersonalTaxImage.Upload.DbValue = row["PersonalTaxImage"];
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
                NomineeValidVisa.DbValue = row["NomineeValidVisa"]; // Set DB value only
                BankName.DbValue = row["BankName"]; // Set DB value only
                BankAddress.DbValue = row["BankAddress"]; // Set DB value only
                BankAccountName.DbValue = row["BankAccountName"]; // Set DB value only
                BankAccountNumber.DbValue = row["BankAccountNumber"]; // Set DB value only
                BankSortCode.DbValue = row["BankSortCode"]; // Set DB value only
                MNOPF.DbValue = row["MNOPF"]; // Set DB value only
                MembershipNumber.DbValue = row["MembershipNumber"]; // Set DB value only
                NationalInsuranceNumber.DbValue = row["NationalInsuranceNumber"]; // Set DB value only
                AVC.DbValue = row["AVC"]; // Set DB value only
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
                ActiveDescription.DbValue = row["ActiveDescription"]; // Set DB value only
                CreatedByUserID.DbValue = row["CreatedByUserID"]; // Set DB value only
                CreatedDateTime.DbValue = row["CreatedDateTime"]; // Set DB value only
                LastUpdatedByUserID.DbValue = row["LastUpdatedByUserID"]; // Set DB value only
                LastUpdatedDateTime.DbValue = row["LastUpdatedDateTime"]; // Set DB value only
                MTUserID.DbValue = row["MTUserID"]; // Set DB value only
                DocumentCheckDateTime.DbValue = row["DocumentCheckDateTime"]; // Set DB value only
                InterviewManagerDateTime.DbValue = row["InterviewManagerDateTime"]; // Set DB value only
                InterviewGMDateTime.DbValue = row["InterviewGMDateTime"]; // Set DB value only
                MCUScheduleDateTime.DbValue = row["MCUScheduleDateTime"]; // Set DB value only
                RejectedReason.DbValue = row["RejectedReason"]; // Set DB value only
                RejectedDateTime.DbValue = row["RejectedDateTime"]; // Set DB value only
                Status.DbValue = row["Status"]; // Set DB value only
                Reason.DbValue = row["Reason"]; // Set DB value only
                Weight.DbValue = row["Weight"]; // Set DB value only
                Height.DbValue = row["Height"]; // Set DB value only
                CoverallSize.DbValue = row["CoverallSize"]; // Set DB value only
                SafetyShoesSize.DbValue = row["SafetyShoesSize"]; // Set DB value only
                ShirtSize.DbValue = row["ShirtSize"]; // Set DB value only
                TrousersSize.DbValue = row["TrousersSize"]; // Set DB value only
                NSSF_Health_Number.DbValue = row["NSSF_Health_Number"]; // Set DB value only
                NSSF_Occupation_Number.DbValue = row["NSSF_Occupation_Number"]; // Set DB value only
                FinalAcceptedDate.DbValue = row["FinalAcceptedDate"]; // Set DB value only
                Reference1CompanyTelephoneCode_CountryID.DbValue = row["Reference1CompanyTelephoneCode_CountryID"]; // Set DB value only
                Reference2CompanyTelephoneCode_CountryID.DbValue = row["Reference2CompanyTelephoneCode_CountryID"]; // Set DB value only
                MobileNumberCode_CountryID.DbValue = row["MobileNumberCode_CountryID"]; // Set DB value only
                PrimaryAddressHomeTelCode_CountryID.DbValue = row["PrimaryAddressHomeTelCode_CountryID"]; // Set DB value only
                AlternativeAddressHomeTelCode_CountryID.DbValue = row["AlternativeAddressHomeTelCode_CountryID"]; // Set DB value only
                NomineeAddressHomeTelCode_CountryID.DbValue = row["NomineeAddressHomeTelCode_CountryID"]; // Set DB value only
                NomineeMobileNumberCode_CountryID.DbValue = row["NomineeMobileNumberCode_CountryID"]; // Set DB value only
                RevisedReason.DbValue = row["RevisedReason"]; // Set DB value only
                RevisedDateTime.DbValue = row["RevisedDateTime"]; // Set DB value only
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
                    return "MtCrewList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "MtCrewView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "MtCrewEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "MtCrewAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "MtCrewList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "MtCrewView",
                Config.ApiAddAction => "MtCrewAdd",
                Config.ApiEditAction => "MtCrewEdit",
                Config.ApiDeleteAction => "MtCrewDelete",
                Config.ApiListAction => "MtCrewList",
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
        public string ListUrl => "MtCrewList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("MtCrewView", parm);
            else
                url = KeyUrl("MtCrewView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "MtCrewAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "MtCrewAdd?" + parm;
            else
                url = "MtCrewAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("MtCrewEdit", parm);
            else
                url = KeyUrl("MtCrewEdit", Config.TableShowDetail + "=");
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("MtCrewList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("MtCrewAdd", parm);
            else
                url = KeyUrl("MtCrewAdd", Config.TableShowDetail + "=");
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("MtCrewList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("MtCrewDelete")); // DN

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
            FirstName.SetDbValue(dr["FirstName"]);
            MiddleName.SetDbValue(dr["MiddleName"]);
            LastName.SetDbValue(dr["LastName"]);
            RequiredPhoto.Upload.DbValue = dr["RequiredPhoto"];
            RequiredPhoto.SetDbValue(RequiredPhoto.Upload.DbValue);
            VisaPhoto.Upload.DbValue = dr["VisaPhoto"];
            VisaPhoto.SetDbValue(VisaPhoto.Upload.DbValue);
            Nationality_CountryID.SetDbValue(dr["Nationality_CountryID"]);
            CountryOfOrigin_CountryID.SetDbValue(dr["CountryOfOrigin_CountryID"]);
            DateOfBirth.SetDbValue(dr["DateOfBirth"]);
            CityOfBirth.SetDbValue(dr["CityOfBirth"]);
            MaritalStatus.SetDbValue(dr["MaritalStatus"]);
            Gender.SetDbValue(dr["Gender"]);
            ReligionID.SetDbValue(dr["ReligionID"]);
            BloodType.SetDbValue(dr["BloodType"]);
            RankAppliedFor_RankID.SetDbValue(dr["RankAppliedFor_RankID"]);
            WillAcceptLowRank.SetDbValue(ConvertToBool(dr["WillAcceptLowRank"]) ? "1" : "0");
            AvailableFrom.SetDbValue(dr["AvailableFrom"]);
            AvailableUntil.SetDbValue(dr["AvailableUntil"]);
            PrimaryAddressDetail.SetDbValue(dr["PrimaryAddressDetail"]);
            PrimaryAddressCity.SetDbValue(dr["PrimaryAddressCity"]);
            PrimaryAddressState.SetDbValue(dr["PrimaryAddressState"]);
            PrimaryAddressNearestAirport.SetDbValue(dr["PrimaryAddressNearestAirport"]);
            PrimaryAddressPostCode.SetDbValue(dr["PrimaryAddressPostCode"]);
            PrimaryAddressCountryID.SetDbValue(dr["PrimaryAddressCountryID"]);
            PrimaryAddressHomeTel.SetDbValue(dr["PrimaryAddressHomeTel"]);
            PrimaryAddressFax.SetDbValue(dr["PrimaryAddressFax"]);
            AlternativeAddressDetail.SetDbValue(dr["AlternativeAddressDetail"]);
            AlternativeAddressCity.SetDbValue(dr["AlternativeAddressCity"]);
            AlternativeAddressState.SetDbValue(dr["AlternativeAddressState"]);
            AlternativeAddressHomeTel.SetDbValue(dr["AlternativeAddressHomeTel"]);
            AlternativeAddressPostCode.SetDbValue(dr["AlternativeAddressPostCode"]);
            AlternativeAddressCountryID.SetDbValue(dr["AlternativeAddressCountryID"]);
            MobileNumber.SetDbValue(dr["MobileNumber"]);
            _Email.SetDbValue(dr["Email"]);
            ContactMethodEmail.SetDbValue(ConvertToBool(dr["ContactMethodEmail"]) ? "1" : "0");
            ContactMethodFax.SetDbValue(ConvertToBool(dr["ContactMethodFax"]) ? "1" : "0");
            ContactMethodMobilePhone.SetDbValue(ConvertToBool(dr["ContactMethodMobilePhone"]) ? "1" : "0");
            ContactMethodHomePhone.SetDbValue(ConvertToBool(dr["ContactMethodHomePhone"]) ? "1" : "0");
            ContactMethodPost.SetDbValue(ConvertToBool(dr["ContactMethodPost"]) ? "1" : "0");
            CollarSize.SetDbValue(dr["CollarSize"]);
            ChestSize.SetDbValue(dr["ChestSize"]);
            WaistSize.SetDbValue(dr["WaistSize"]);
            InsideLegSize.SetDbValue(dr["InsideLegSize"]);
            CapSize.SetDbValue(dr["CapSize"]);
            SweaterSize_ClothesSizeID.SetDbValue(dr["SweaterSize_ClothesSizeID"]);
            BoilersuitSize_ClothesSizeID.SetDbValue(dr["BoilersuitSize_ClothesSizeID"]);
            SocialSecurityNumber.SetDbValue(dr["SocialSecurityNumber"]);
            SocialSecurityIssuingCountryID.SetDbValue(dr["SocialSecurityIssuingCountryID"]);
            SocialSecurityImage.Upload.DbValue = dr["SocialSecurityImage"];
            SocialSecurityImage.SetDbValue(SocialSecurityImage.Upload.DbValue);
            PersonalTaxNumber.SetDbValue(dr["PersonalTaxNumber"]);
            PersonalTaxIssuingCountryID.SetDbValue(dr["PersonalTaxIssuingCountryID"]);
            PersonalTaxImage.Upload.DbValue = dr["PersonalTaxImage"];
            PersonalTaxImage.SetDbValue(PersonalTaxImage.Upload.DbValue);
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
            NomineeValidVisa.SetDbValue(dr["NomineeValidVisa"]);
            BankName.SetDbValue(dr["BankName"]);
            BankAddress.SetDbValue(dr["BankAddress"]);
            BankAccountName.SetDbValue(dr["BankAccountName"]);
            BankAccountNumber.SetDbValue(dr["BankAccountNumber"]);
            BankSortCode.SetDbValue(dr["BankSortCode"]);
            MNOPF.SetDbValue(dr["MNOPF"]);
            MembershipNumber.SetDbValue(dr["MembershipNumber"]);
            NationalInsuranceNumber.SetDbValue(dr["NationalInsuranceNumber"]);
            AVC.SetDbValue(dr["AVC"]);
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
            ActiveDescription.SetDbValue(dr["ActiveDescription"]);
            CreatedByUserID.SetDbValue(dr["CreatedByUserID"]);
            CreatedDateTime.SetDbValue(dr["CreatedDateTime"]);
            LastUpdatedByUserID.SetDbValue(dr["LastUpdatedByUserID"]);
            LastUpdatedDateTime.SetDbValue(dr["LastUpdatedDateTime"]);
            MTUserID.SetDbValue(dr["MTUserID"]);
            DocumentCheckDateTime.SetDbValue(dr["DocumentCheckDateTime"]);
            InterviewManagerDateTime.SetDbValue(dr["InterviewManagerDateTime"]);
            InterviewGMDateTime.SetDbValue(dr["InterviewGMDateTime"]);
            MCUScheduleDateTime.SetDbValue(dr["MCUScheduleDateTime"]);
            RejectedReason.SetDbValue(dr["RejectedReason"]);
            RejectedDateTime.SetDbValue(dr["RejectedDateTime"]);
            Status.SetDbValue(dr["Status"]);
            Reason.SetDbValue(dr["Reason"]);
            Weight.SetDbValue(dr["Weight"]);
            Height.SetDbValue(dr["Height"]);
            CoverallSize.SetDbValue(dr["CoverallSize"]);
            SafetyShoesSize.SetDbValue(dr["SafetyShoesSize"]);
            ShirtSize.SetDbValue(dr["ShirtSize"]);
            TrousersSize.SetDbValue(dr["TrousersSize"]);
            NSSF_Health_Number.SetDbValue(dr["NSSF_Health_Number"]);
            NSSF_Occupation_Number.SetDbValue(dr["NSSF_Occupation_Number"]);
            FinalAcceptedDate.SetDbValue(dr["FinalAcceptedDate"]);
            Reference1CompanyTelephoneCode_CountryID.SetDbValue(dr["Reference1CompanyTelephoneCode_CountryID"]);
            Reference2CompanyTelephoneCode_CountryID.SetDbValue(dr["Reference2CompanyTelephoneCode_CountryID"]);
            MobileNumberCode_CountryID.SetDbValue(dr["MobileNumberCode_CountryID"]);
            PrimaryAddressHomeTelCode_CountryID.SetDbValue(dr["PrimaryAddressHomeTelCode_CountryID"]);
            AlternativeAddressHomeTelCode_CountryID.SetDbValue(dr["AlternativeAddressHomeTelCode_CountryID"]);
            NomineeAddressHomeTelCode_CountryID.SetDbValue(dr["NomineeAddressHomeTelCode_CountryID"]);
            NomineeMobileNumberCode_CountryID.SetDbValue(dr["NomineeMobileNumberCode_CountryID"]);
            RevisedReason.SetDbValue(dr["RevisedReason"]);
            RevisedDateTime.SetDbValue(dr["RevisedDateTime"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "MtCrewList";
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

            // FirstName
            FirstName.CellCssStyle = "white-space: nowrap;";

            // MiddleName
            MiddleName.CellCssStyle = "white-space: nowrap;";

            // LastName
            LastName.CellCssStyle = "white-space: nowrap;";

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

            // MaritalStatus
            MaritalStatus.CellCssStyle = "white-space: nowrap;";

            // Gender
            Gender.CellCssStyle = "white-space: nowrap;";

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

            // PrimaryAddressState
            PrimaryAddressState.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.CellCssStyle = "white-space: nowrap;";

            // PrimaryAddressFax
            PrimaryAddressFax.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressDetail
            AlternativeAddressDetail.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressCity
            AlternativeAddressCity.CellCssStyle = "white-space: nowrap;";

            // AlternativeAddressState
            AlternativeAddressState.CellCssStyle = "white-space: nowrap;";

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

            // ContactMethodEmail
            ContactMethodEmail.CellCssStyle = "white-space: nowrap;";

            // ContactMethodFax
            ContactMethodFax.CellCssStyle = "white-space: nowrap;";

            // ContactMethodMobilePhone
            ContactMethodMobilePhone.CellCssStyle = "white-space: nowrap;";

            // ContactMethodHomePhone
            ContactMethodHomePhone.CellCssStyle = "white-space: nowrap;";

            // ContactMethodPost
            ContactMethodPost.CellCssStyle = "white-space: nowrap;";

            // CollarSize
            CollarSize.CellCssStyle = "white-space: nowrap;";

            // ChestSize
            ChestSize.CellCssStyle = "white-space: nowrap;";

            // WaistSize
            WaistSize.CellCssStyle = "white-space: nowrap;";

            // InsideLegSize
            InsideLegSize.CellCssStyle = "white-space: nowrap;";

            // CapSize
            CapSize.CellCssStyle = "white-space: nowrap;";

            // SweaterSize_ClothesSizeID
            SweaterSize_ClothesSizeID.CellCssStyle = "white-space: nowrap;";

            // BoilersuitSize_ClothesSizeID
            BoilersuitSize_ClothesSizeID.CellCssStyle = "white-space: nowrap;";

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

            // NomineeValidVisa
            NomineeValidVisa.CellCssStyle = "white-space: nowrap;";

            // BankName
            BankName.CellCssStyle = "white-space: nowrap;";

            // BankAddress
            BankAddress.CellCssStyle = "white-space: nowrap;";

            // BankAccountName
            BankAccountName.CellCssStyle = "white-space: nowrap;";

            // BankAccountNumber
            BankAccountNumber.CellCssStyle = "white-space: nowrap;";

            // BankSortCode
            BankSortCode.CellCssStyle = "white-space: nowrap;";

            // MNOPF
            MNOPF.CellCssStyle = "white-space: nowrap;";

            // MembershipNumber
            MembershipNumber.CellCssStyle = "white-space: nowrap;";

            // NationalInsuranceNumber
            NationalInsuranceNumber.CellCssStyle = "white-space: nowrap;";

            // AVC
            AVC.CellCssStyle = "white-space: nowrap;";

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

            // DocumentCheckDateTime
            DocumentCheckDateTime.CellCssStyle = "white-space: nowrap;";

            // InterviewManagerDateTime
            InterviewManagerDateTime.CellCssStyle = "white-space: nowrap;";

            // InterviewGMDateTime
            InterviewGMDateTime.CellCssStyle = "white-space: nowrap;";

            // MCUScheduleDateTime
            MCUScheduleDateTime.CellCssStyle = "white-space: nowrap;";

            // RejectedReason
            RejectedReason.CellCssStyle = "white-space: nowrap;";

            // RejectedDateTime
            RejectedDateTime.CellCssStyle = "white-space: nowrap;";

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

            // NSSF_Health_Number
            NSSF_Health_Number.CellCssStyle = "white-space: nowrap;";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.CellCssStyle = "white-space: nowrap;";

            // FinalAcceptedDate
            FinalAcceptedDate.CellCssStyle = "white-space: nowrap;";

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.CellCssStyle = "white-space: nowrap;";

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.CellCssStyle = "white-space: nowrap;";

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

            // RevisedReason
            RevisedReason.CellCssStyle = "white-space: nowrap;";

            // RevisedDateTime
            RevisedDateTime.CellCssStyle = "white-space: nowrap;";

            // ID
            ID.ViewValue = ID.CurrentValue;
            ID.ViewCustomAttributes = "";

            // IndividualCodeNumber
            IndividualCodeNumber.ViewValue = ConvertToString(IndividualCodeNumber.CurrentValue); // DN
            IndividualCodeNumber.ViewCustomAttributes = "";

            // FullName
            FullName.ViewValue = ConvertToString(FullName.CurrentValue); // DN
            FullName.ViewCustomAttributes = "";

            // FirstName
            FirstName.ViewValue = ConvertToString(FirstName.CurrentValue); // DN
            FirstName.ViewCustomAttributes = "";

            // MiddleName
            MiddleName.ViewValue = ConvertToString(MiddleName.CurrentValue); // DN
            MiddleName.ViewCustomAttributes = "";

            // LastName
            LastName.ViewValue = ConvertToString(LastName.CurrentValue); // DN
            LastName.ViewCustomAttributes = "";

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

            // MaritalStatus
            if (!Empty(MaritalStatus.CurrentValue)) {
                MaritalStatus.ViewValue = MaritalStatus.HighlightLookup(ConvertToString(MaritalStatus.CurrentValue), MaritalStatus.OptionCaption(ConvertToString(MaritalStatus.CurrentValue)));
            } else {
                MaritalStatus.ViewValue = DbNullValue;
            }
            MaritalStatus.ViewCustomAttributes = "";

            // Gender
            if (!Empty(Gender.CurrentValue)) {
                Gender.ViewValue = Gender.HighlightLookup(ConvertToString(Gender.CurrentValue), Gender.OptionCaption(ConvertToString(Gender.CurrentValue)));
            } else {
                Gender.ViewValue = DbNullValue;
            }
            Gender.ViewCustomAttributes = "";

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

            // PrimaryAddressState
            PrimaryAddressState.ViewValue = ConvertToString(PrimaryAddressState.CurrentValue); // DN
            PrimaryAddressState.ViewCustomAttributes = "";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.ViewValue = ConvertToString(PrimaryAddressNearestAirport.CurrentValue); // DN
            PrimaryAddressNearestAirport.ViewCustomAttributes = "";

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

            // PrimaryAddressFax
            PrimaryAddressFax.ViewValue = ConvertToString(PrimaryAddressFax.CurrentValue); // DN
            PrimaryAddressFax.ViewCustomAttributes = "";

            // AlternativeAddressDetail
            AlternativeAddressDetail.ViewValue = AlternativeAddressDetail.CurrentValue;
            AlternativeAddressDetail.ViewCustomAttributes = "";

            // AlternativeAddressCity
            AlternativeAddressCity.ViewValue = ConvertToString(AlternativeAddressCity.CurrentValue); // DN
            AlternativeAddressCity.ViewCustomAttributes = "";

            // AlternativeAddressState
            AlternativeAddressState.ViewValue = ConvertToString(AlternativeAddressState.CurrentValue); // DN
            AlternativeAddressState.ViewCustomAttributes = "";

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

            // ContactMethodEmail
            if (ConvertToBool(ContactMethodEmail.CurrentValue)) {
                ContactMethodEmail.ViewValue = ContactMethodEmail.TagCaption(1) != "" ? ContactMethodEmail.TagCaption(1) : "Yes";
            } else {
                ContactMethodEmail.ViewValue = ContactMethodEmail.TagCaption(2) != "" ? ContactMethodEmail.TagCaption(2) : "No";
            }
            ContactMethodEmail.ViewCustomAttributes = "";

            // ContactMethodFax
            if (ConvertToBool(ContactMethodFax.CurrentValue)) {
                ContactMethodFax.ViewValue = ContactMethodFax.TagCaption(1) != "" ? ContactMethodFax.TagCaption(1) : "Yes";
            } else {
                ContactMethodFax.ViewValue = ContactMethodFax.TagCaption(2) != "" ? ContactMethodFax.TagCaption(2) : "No";
            }
            ContactMethodFax.ViewCustomAttributes = "";

            // ContactMethodMobilePhone
            if (ConvertToBool(ContactMethodMobilePhone.CurrentValue)) {
                ContactMethodMobilePhone.ViewValue = ContactMethodMobilePhone.TagCaption(1) != "" ? ContactMethodMobilePhone.TagCaption(1) : "Yes";
            } else {
                ContactMethodMobilePhone.ViewValue = ContactMethodMobilePhone.TagCaption(2) != "" ? ContactMethodMobilePhone.TagCaption(2) : "No";
            }
            ContactMethodMobilePhone.ViewCustomAttributes = "";

            // ContactMethodHomePhone
            if (ConvertToBool(ContactMethodHomePhone.CurrentValue)) {
                ContactMethodHomePhone.ViewValue = ContactMethodHomePhone.TagCaption(1) != "" ? ContactMethodHomePhone.TagCaption(1) : "Yes";
            } else {
                ContactMethodHomePhone.ViewValue = ContactMethodHomePhone.TagCaption(2) != "" ? ContactMethodHomePhone.TagCaption(2) : "No";
            }
            ContactMethodHomePhone.ViewCustomAttributes = "";

            // ContactMethodPost
            if (ConvertToBool(ContactMethodPost.CurrentValue)) {
                ContactMethodPost.ViewValue = ContactMethodPost.TagCaption(1) != "" ? ContactMethodPost.TagCaption(1) : "Yes";
            } else {
                ContactMethodPost.ViewValue = ContactMethodPost.TagCaption(2) != "" ? ContactMethodPost.TagCaption(2) : "No";
            }
            ContactMethodPost.ViewCustomAttributes = "";

            // CollarSize
            CollarSize.ViewValue = CollarSize.CurrentValue;
            CollarSize.ViewValue = FormatNumber(CollarSize.ViewValue, CollarSize.FormatPattern);
            CollarSize.ViewCustomAttributes = "";

            // ChestSize
            ChestSize.ViewValue = ChestSize.CurrentValue;
            ChestSize.ViewValue = FormatNumber(ChestSize.ViewValue, ChestSize.FormatPattern);
            ChestSize.ViewCustomAttributes = "";

            // WaistSize
            WaistSize.ViewValue = WaistSize.CurrentValue;
            WaistSize.ViewValue = FormatNumber(WaistSize.ViewValue, WaistSize.FormatPattern);
            WaistSize.ViewCustomAttributes = "";

            // InsideLegSize
            InsideLegSize.ViewValue = InsideLegSize.CurrentValue;
            InsideLegSize.ViewValue = FormatNumber(InsideLegSize.ViewValue, InsideLegSize.FormatPattern);
            InsideLegSize.ViewCustomAttributes = "";

            // CapSize
            CapSize.ViewValue = CapSize.CurrentValue;
            CapSize.ViewValue = FormatNumber(CapSize.ViewValue, CapSize.FormatPattern);
            CapSize.ViewCustomAttributes = "";

            // SweaterSize_ClothesSizeID
            curVal = ConvertToString(SweaterSize_ClothesSizeID.CurrentValue);
            if (!Empty(curVal)) {
                if (SweaterSize_ClothesSizeID.Lookup != null && IsDictionary(SweaterSize_ClothesSizeID.Lookup?.Options) && SweaterSize_ClothesSizeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    SweaterSize_ClothesSizeID.ViewValue = SweaterSize_ClothesSizeID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", SweaterSize_ClothesSizeID.CurrentValue, DataType.Number, "");
                    sqlWrk = SweaterSize_ClothesSizeID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && SweaterSize_ClothesSizeID.Lookup != null) { // Lookup values found
                        var listwrk = SweaterSize_ClothesSizeID.Lookup?.RenderViewRow(rswrk[0]);
                        SweaterSize_ClothesSizeID.ViewValue = SweaterSize_ClothesSizeID.HighlightLookup(ConvertToString(rswrk[0]), SweaterSize_ClothesSizeID.DisplayValue(listwrk));
                    } else {
                        SweaterSize_ClothesSizeID.ViewValue = FormatNumber(SweaterSize_ClothesSizeID.CurrentValue, SweaterSize_ClothesSizeID.FormatPattern);
                    }
                }
            } else {
                SweaterSize_ClothesSizeID.ViewValue = DbNullValue;
            }
            SweaterSize_ClothesSizeID.ViewCustomAttributes = "";

            // BoilersuitSize_ClothesSizeID
            curVal = ConvertToString(BoilersuitSize_ClothesSizeID.CurrentValue);
            if (!Empty(curVal)) {
                if (BoilersuitSize_ClothesSizeID.Lookup != null && IsDictionary(BoilersuitSize_ClothesSizeID.Lookup?.Options) && BoilersuitSize_ClothesSizeID.Lookup?.Options.Values.Count > 0) { // Load from cache // DN
                    BoilersuitSize_ClothesSizeID.ViewValue = BoilersuitSize_ClothesSizeID.LookupCacheOption(curVal);
                } else { // Lookup from database // DN
                    filterWrk = SearchFilter("[ID]", "=", BoilersuitSize_ClothesSizeID.CurrentValue, DataType.Number, "");
                    sqlWrk = BoilersuitSize_ClothesSizeID.Lookup?.GetSql(false, filterWrk, null, this, true, true);
                    rswrk = sqlWrk != null ? Connection.GetRows(sqlWrk) : null; // Must use Sync to avoid overwriting ViewValue in RenderViewRow
                    if (rswrk?.Count > 0 && BoilersuitSize_ClothesSizeID.Lookup != null) { // Lookup values found
                        var listwrk = BoilersuitSize_ClothesSizeID.Lookup?.RenderViewRow(rswrk[0]);
                        BoilersuitSize_ClothesSizeID.ViewValue = BoilersuitSize_ClothesSizeID.HighlightLookup(ConvertToString(rswrk[0]), BoilersuitSize_ClothesSizeID.DisplayValue(listwrk));
                    } else {
                        BoilersuitSize_ClothesSizeID.ViewValue = FormatNumber(BoilersuitSize_ClothesSizeID.CurrentValue, BoilersuitSize_ClothesSizeID.FormatPattern);
                    }
                }
            } else {
                BoilersuitSize_ClothesSizeID.ViewValue = DbNullValue;
            }
            BoilersuitSize_ClothesSizeID.ViewCustomAttributes = "";

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
                PersonalTaxImage.ViewValue = PersonalTaxImage.Upload.DbValue;
            } else {
                PersonalTaxImage.ViewValue = "";
            }
            PersonalTaxImage.ViewCustomAttributes = "";

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

            // NomineeValidVisa
            NomineeValidVisa.ViewValue = ConvertToString(NomineeValidVisa.CurrentValue); // DN
            NomineeValidVisa.ViewCustomAttributes = "";

            // BankName
            BankName.ViewValue = ConvertToString(BankName.CurrentValue); // DN
            BankName.ViewCustomAttributes = "";

            // BankAddress
            BankAddress.ViewValue = BankAddress.CurrentValue;
            BankAddress.ViewCustomAttributes = "";

            // BankAccountName
            BankAccountName.ViewValue = ConvertToString(BankAccountName.CurrentValue); // DN
            BankAccountName.ViewCustomAttributes = "";

            // BankAccountNumber
            BankAccountNumber.ViewValue = ConvertToString(BankAccountNumber.CurrentValue); // DN
            BankAccountNumber.ViewCustomAttributes = "";

            // BankSortCode
            BankSortCode.ViewValue = ConvertToString(BankSortCode.CurrentValue); // DN
            BankSortCode.ViewCustomAttributes = "";

            // MNOPF
            MNOPF.ViewValue = ConvertToString(MNOPF.CurrentValue); // DN
            MNOPF.ViewCustomAttributes = "";

            // MembershipNumber
            MembershipNumber.ViewValue = ConvertToString(MembershipNumber.CurrentValue); // DN
            MembershipNumber.ViewCustomAttributes = "";

            // NationalInsuranceNumber
            NationalInsuranceNumber.ViewValue = ConvertToString(NationalInsuranceNumber.CurrentValue); // DN
            NationalInsuranceNumber.ViewCustomAttributes = "";

            // AVC
            AVC.ViewValue = ConvertToString(AVC.CurrentValue); // DN
            AVC.ViewCustomAttributes = "";

            // ForeignVisaHasBeenDenied
            if (ConvertToBool(ForeignVisaHasBeenDenied.CurrentValue)) {
                ForeignVisaHasBeenDenied.ViewValue = ForeignVisaHasBeenDenied.TagCaption(1) != "" ? ForeignVisaHasBeenDenied.TagCaption(1) : "Yes";
            } else {
                ForeignVisaHasBeenDenied.ViewValue = ForeignVisaHasBeenDenied.TagCaption(2) != "" ? ForeignVisaHasBeenDenied.TagCaption(2) : "No";
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
                HasMaritimeAccidentOrCourtOfEnquiry.ViewValue = HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(1) != "" ? HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(1) : "Yes";
            } else {
                HasMaritimeAccidentOrCourtOfEnquiry.ViewValue = HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(2) != "" ? HasMaritimeAccidentOrCourtOfEnquiry.TagCaption(2) : "No";
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

            // ActiveDescription
            ActiveDescription.ViewValue = ConvertToString(ActiveDescription.CurrentValue); // DN
            ActiveDescription.ViewCustomAttributes = "";

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

            // MTUserID
            MTUserID.ViewValue = MTUserID.CurrentValue;
            MTUserID.ViewValue = FormatNumber(MTUserID.ViewValue, MTUserID.FormatPattern);
            MTUserID.ViewCustomAttributes = "";

            // DocumentCheckDateTime
            DocumentCheckDateTime.ViewValue = DocumentCheckDateTime.CurrentValue;
            DocumentCheckDateTime.ViewValue = FormatDateTime(DocumentCheckDateTime.ViewValue, DocumentCheckDateTime.FormatPattern);
            DocumentCheckDateTime.ViewCustomAttributes = "";

            // InterviewManagerDateTime
            InterviewManagerDateTime.ViewValue = InterviewManagerDateTime.CurrentValue;
            InterviewManagerDateTime.ViewValue = FormatDateTime(InterviewManagerDateTime.ViewValue, InterviewManagerDateTime.FormatPattern);
            InterviewManagerDateTime.ViewCustomAttributes = "";

            // InterviewGMDateTime
            InterviewGMDateTime.ViewValue = InterviewGMDateTime.CurrentValue;
            InterviewGMDateTime.ViewValue = FormatDateTime(InterviewGMDateTime.ViewValue, InterviewGMDateTime.FormatPattern);
            InterviewGMDateTime.ViewCustomAttributes = "";

            // MCUScheduleDateTime
            MCUScheduleDateTime.ViewValue = MCUScheduleDateTime.CurrentValue;
            MCUScheduleDateTime.ViewValue = FormatDateTime(MCUScheduleDateTime.ViewValue, MCUScheduleDateTime.FormatPattern);
            MCUScheduleDateTime.ViewCustomAttributes = "";

            // RejectedReason
            RejectedReason.ViewValue = RejectedReason.CurrentValue;
            RejectedReason.ViewCustomAttributes = "";

            // RejectedDateTime
            RejectedDateTime.ViewValue = RejectedDateTime.CurrentValue;
            RejectedDateTime.ViewValue = FormatDateTime(RejectedDateTime.ViewValue, RejectedDateTime.FormatPattern);
            RejectedDateTime.ViewCustomAttributes = "";

            // Status
            Status.ViewValue = ConvertToString(Status.CurrentValue); // DN
            Status.ViewCustomAttributes = "";

            // Reason
            Reason.ViewValue = ConvertToString(Reason.CurrentValue); // DN
            Reason.ViewCustomAttributes = "";

            // Weight
            Weight.ViewValue = Weight.CurrentValue;
            Weight.ViewValue = FormatNumber(Weight.ViewValue, Weight.FormatPattern);
            Weight.ViewCustomAttributes = "";

            // Height
            Height.ViewValue = Height.CurrentValue;
            Height.ViewValue = FormatNumber(Height.ViewValue, Height.FormatPattern);
            Height.ViewCustomAttributes = "";

            // CoverallSize
            CoverallSize.ViewValue = ConvertToString(CoverallSize.CurrentValue); // DN
            CoverallSize.ViewCustomAttributes = "";

            // SafetyShoesSize
            SafetyShoesSize.ViewValue = SafetyShoesSize.CurrentValue;
            SafetyShoesSize.ViewValue = FormatNumber(SafetyShoesSize.ViewValue, SafetyShoesSize.FormatPattern);
            SafetyShoesSize.ViewCustomAttributes = "";

            // ShirtSize
            ShirtSize.ViewValue = ConvertToString(ShirtSize.CurrentValue); // DN
            ShirtSize.ViewCustomAttributes = "";

            // TrousersSize
            TrousersSize.ViewValue = ConvertToString(TrousersSize.CurrentValue); // DN
            TrousersSize.ViewCustomAttributes = "";

            // NSSF_Health_Number
            NSSF_Health_Number.ViewValue = ConvertToString(NSSF_Health_Number.CurrentValue); // DN
            NSSF_Health_Number.ViewCustomAttributes = "";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.ViewValue = ConvertToString(NSSF_Occupation_Number.CurrentValue); // DN
            NSSF_Occupation_Number.ViewCustomAttributes = "";

            // FinalAcceptedDate
            FinalAcceptedDate.ViewValue = FinalAcceptedDate.CurrentValue;
            FinalAcceptedDate.ViewValue = FormatDateTime(FinalAcceptedDate.ViewValue, FinalAcceptedDate.FormatPattern);
            FinalAcceptedDate.ViewCustomAttributes = "";

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

            // RevisedReason
            RevisedReason.ViewValue = ConvertToString(RevisedReason.CurrentValue); // DN
            RevisedReason.ViewCustomAttributes = "";

            // RevisedDateTime
            RevisedDateTime.ViewValue = RevisedDateTime.CurrentValue;
            RevisedDateTime.ViewValue = FormatDateTime(RevisedDateTime.ViewValue, RevisedDateTime.FormatPattern);
            RevisedDateTime.ViewCustomAttributes = "";

            // ID
            ID.HrefValue = "";
            ID.TooltipValue = "";

            // IndividualCodeNumber
            IndividualCodeNumber.HrefValue = "";
            IndividualCodeNumber.TooltipValue = "";

            // FullName
            FullName.HrefValue = "";
            FullName.TooltipValue = "";

            // FirstName
            FirstName.HrefValue = "";
            FirstName.TooltipValue = "";

            // MiddleName
            MiddleName.HrefValue = "";
            MiddleName.TooltipValue = "";

            // LastName
            LastName.HrefValue = "";
            LastName.TooltipValue = "";

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
                RequiredPhoto.LinkAttrs["data-rel"] = "MTCrew_x_RequiredPhoto";
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
                VisaPhoto.LinkAttrs["data-rel"] = "MTCrew_x_VisaPhoto";
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

            // MaritalStatus
            MaritalStatus.HrefValue = "";
            MaritalStatus.TooltipValue = "";

            // Gender
            Gender.HrefValue = "";
            Gender.TooltipValue = "";

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

            // PrimaryAddressState
            PrimaryAddressState.HrefValue = "";
            PrimaryAddressState.TooltipValue = "";

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.HrefValue = "";
            PrimaryAddressNearestAirport.TooltipValue = "";

            // PrimaryAddressPostCode
            PrimaryAddressPostCode.HrefValue = "";
            PrimaryAddressPostCode.TooltipValue = "";

            // PrimaryAddressCountryID
            PrimaryAddressCountryID.HrefValue = "";
            PrimaryAddressCountryID.TooltipValue = "";

            // PrimaryAddressHomeTel
            PrimaryAddressHomeTel.HrefValue = "";
            PrimaryAddressHomeTel.TooltipValue = "";

            // PrimaryAddressFax
            PrimaryAddressFax.HrefValue = "";
            PrimaryAddressFax.TooltipValue = "";

            // AlternativeAddressDetail
            AlternativeAddressDetail.HrefValue = "";
            AlternativeAddressDetail.TooltipValue = "";

            // AlternativeAddressCity
            AlternativeAddressCity.HrefValue = "";
            AlternativeAddressCity.TooltipValue = "";

            // AlternativeAddressState
            AlternativeAddressState.HrefValue = "";
            AlternativeAddressState.TooltipValue = "";

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

            // ContactMethodEmail
            ContactMethodEmail.HrefValue = "";
            ContactMethodEmail.TooltipValue = "";

            // ContactMethodFax
            ContactMethodFax.HrefValue = "";
            ContactMethodFax.TooltipValue = "";

            // ContactMethodMobilePhone
            ContactMethodMobilePhone.HrefValue = "";
            ContactMethodMobilePhone.TooltipValue = "";

            // ContactMethodHomePhone
            ContactMethodHomePhone.HrefValue = "";
            ContactMethodHomePhone.TooltipValue = "";

            // ContactMethodPost
            ContactMethodPost.HrefValue = "";
            ContactMethodPost.TooltipValue = "";

            // CollarSize
            CollarSize.HrefValue = "";
            CollarSize.TooltipValue = "";

            // ChestSize
            ChestSize.HrefValue = "";
            ChestSize.TooltipValue = "";

            // WaistSize
            WaistSize.HrefValue = "";
            WaistSize.TooltipValue = "";

            // InsideLegSize
            InsideLegSize.HrefValue = "";
            InsideLegSize.TooltipValue = "";

            // CapSize
            CapSize.HrefValue = "";
            CapSize.TooltipValue = "";

            // SweaterSize_ClothesSizeID
            SweaterSize_ClothesSizeID.HrefValue = "";
            SweaterSize_ClothesSizeID.TooltipValue = "";

            // BoilersuitSize_ClothesSizeID
            BoilersuitSize_ClothesSizeID.HrefValue = "";
            BoilersuitSize_ClothesSizeID.TooltipValue = "";

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

            // NomineeValidVisa
            NomineeValidVisa.HrefValue = "";
            NomineeValidVisa.TooltipValue = "";

            // BankName
            BankName.HrefValue = "";
            BankName.TooltipValue = "";

            // BankAddress
            BankAddress.HrefValue = "";
            BankAddress.TooltipValue = "";

            // BankAccountName
            BankAccountName.HrefValue = "";
            BankAccountName.TooltipValue = "";

            // BankAccountNumber
            BankAccountNumber.HrefValue = "";
            BankAccountNumber.TooltipValue = "";

            // BankSortCode
            BankSortCode.HrefValue = "";
            BankSortCode.TooltipValue = "";

            // MNOPF
            MNOPF.HrefValue = "";
            MNOPF.TooltipValue = "";

            // MembershipNumber
            MembershipNumber.HrefValue = "";
            MembershipNumber.TooltipValue = "";

            // NationalInsuranceNumber
            NationalInsuranceNumber.HrefValue = "";
            NationalInsuranceNumber.TooltipValue = "";

            // AVC
            AVC.HrefValue = "";
            AVC.TooltipValue = "";

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

            // DocumentCheckDateTime
            DocumentCheckDateTime.HrefValue = "";
            DocumentCheckDateTime.TooltipValue = "";

            // InterviewManagerDateTime
            InterviewManagerDateTime.HrefValue = "";
            InterviewManagerDateTime.TooltipValue = "";

            // InterviewGMDateTime
            InterviewGMDateTime.HrefValue = "";
            InterviewGMDateTime.TooltipValue = "";

            // MCUScheduleDateTime
            MCUScheduleDateTime.HrefValue = "";
            MCUScheduleDateTime.TooltipValue = "";

            // RejectedReason
            RejectedReason.HrefValue = "";
            RejectedReason.TooltipValue = "";

            // RejectedDateTime
            RejectedDateTime.HrefValue = "";
            RejectedDateTime.TooltipValue = "";

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

            // NSSF_Health_Number
            NSSF_Health_Number.HrefValue = "";
            NSSF_Health_Number.TooltipValue = "";

            // NSSF_Occupation_Number
            NSSF_Occupation_Number.HrefValue = "";
            NSSF_Occupation_Number.TooltipValue = "";

            // FinalAcceptedDate
            FinalAcceptedDate.HrefValue = "";
            FinalAcceptedDate.TooltipValue = "";

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.HrefValue = "";
            Reference1CompanyTelephoneCode_CountryID.TooltipValue = "";

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.HrefValue = "";
            Reference2CompanyTelephoneCode_CountryID.TooltipValue = "";

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

            // RevisedReason
            RevisedReason.HrefValue = "";
            RevisedReason.TooltipValue = "";

            // RevisedDateTime
            RevisedDateTime.HrefValue = "";
            RevisedDateTime.TooltipValue = "";

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

            // FirstName
            FirstName.SetupEditAttributes();
            if (!FirstName.Raw)
                FirstName.CurrentValue = HtmlDecode(FirstName.CurrentValue);
            FirstName.EditValue = HtmlEncode(FirstName.CurrentValue);
            FirstName.PlaceHolder = RemoveHtml(FirstName.Caption);

            // MiddleName
            MiddleName.SetupEditAttributes();
            if (!MiddleName.Raw)
                MiddleName.CurrentValue = HtmlDecode(MiddleName.CurrentValue);
            MiddleName.EditValue = HtmlEncode(MiddleName.CurrentValue);
            MiddleName.PlaceHolder = RemoveHtml(MiddleName.Caption);

            // LastName
            LastName.SetupEditAttributes();
            if (!LastName.Raw)
                LastName.CurrentValue = HtmlDecode(LastName.CurrentValue);
            LastName.EditValue = HtmlEncode(LastName.CurrentValue);
            LastName.PlaceHolder = RemoveHtml(LastName.Caption);

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

            // MaritalStatus
            MaritalStatus.SetupEditAttributes();
            MaritalStatus.EditValue = MaritalStatus.Options(true);
            MaritalStatus.PlaceHolder = RemoveHtml(MaritalStatus.Caption);

            // Gender
            Gender.SetupEditAttributes();
            Gender.EditValue = Gender.Options(true);
            Gender.PlaceHolder = RemoveHtml(Gender.Caption);

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

            // PrimaryAddressState
            PrimaryAddressState.SetupEditAttributes();
            if (!PrimaryAddressState.Raw)
                PrimaryAddressState.CurrentValue = HtmlDecode(PrimaryAddressState.CurrentValue);
            PrimaryAddressState.EditValue = HtmlEncode(PrimaryAddressState.CurrentValue);
            PrimaryAddressState.PlaceHolder = RemoveHtml(PrimaryAddressState.Caption);

            // PrimaryAddressNearestAirport
            PrimaryAddressNearestAirport.SetupEditAttributes();
            if (!PrimaryAddressNearestAirport.Raw)
                PrimaryAddressNearestAirport.CurrentValue = HtmlDecode(PrimaryAddressNearestAirport.CurrentValue);
            PrimaryAddressNearestAirport.EditValue = HtmlEncode(PrimaryAddressNearestAirport.CurrentValue);
            PrimaryAddressNearestAirport.PlaceHolder = RemoveHtml(PrimaryAddressNearestAirport.Caption);

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

            // PrimaryAddressFax
            PrimaryAddressFax.SetupEditAttributes();
            if (!PrimaryAddressFax.Raw)
                PrimaryAddressFax.CurrentValue = HtmlDecode(PrimaryAddressFax.CurrentValue);
            PrimaryAddressFax.EditValue = HtmlEncode(PrimaryAddressFax.CurrentValue);
            PrimaryAddressFax.PlaceHolder = RemoveHtml(PrimaryAddressFax.Caption);

            // AlternativeAddressDetail
            AlternativeAddressDetail.SetupEditAttributes();
            AlternativeAddressDetail.EditValue = AlternativeAddressDetail.CurrentValue; // DN
            AlternativeAddressDetail.PlaceHolder = RemoveHtml(AlternativeAddressDetail.Caption);

            // AlternativeAddressCity
            AlternativeAddressCity.SetupEditAttributes();
            if (!AlternativeAddressCity.Raw)
                AlternativeAddressCity.CurrentValue = HtmlDecode(AlternativeAddressCity.CurrentValue);
            AlternativeAddressCity.EditValue = HtmlEncode(AlternativeAddressCity.CurrentValue);
            AlternativeAddressCity.PlaceHolder = RemoveHtml(AlternativeAddressCity.Caption);

            // AlternativeAddressState
            AlternativeAddressState.SetupEditAttributes();
            if (!AlternativeAddressState.Raw)
                AlternativeAddressState.CurrentValue = HtmlDecode(AlternativeAddressState.CurrentValue);
            AlternativeAddressState.EditValue = HtmlEncode(AlternativeAddressState.CurrentValue);
            AlternativeAddressState.PlaceHolder = RemoveHtml(AlternativeAddressState.Caption);

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

            // ContactMethodEmail
            ContactMethodEmail.EditValue = ContactMethodEmail.Options(false);
            ContactMethodEmail.PlaceHolder = RemoveHtml(ContactMethodEmail.Caption);

            // ContactMethodFax
            ContactMethodFax.EditValue = ContactMethodFax.Options(false);
            ContactMethodFax.PlaceHolder = RemoveHtml(ContactMethodFax.Caption);

            // ContactMethodMobilePhone
            ContactMethodMobilePhone.EditValue = ContactMethodMobilePhone.Options(false);
            ContactMethodMobilePhone.PlaceHolder = RemoveHtml(ContactMethodMobilePhone.Caption);

            // ContactMethodHomePhone
            ContactMethodHomePhone.EditValue = ContactMethodHomePhone.Options(false);
            ContactMethodHomePhone.PlaceHolder = RemoveHtml(ContactMethodHomePhone.Caption);

            // ContactMethodPost
            ContactMethodPost.EditValue = ContactMethodPost.Options(false);
            ContactMethodPost.PlaceHolder = RemoveHtml(ContactMethodPost.Caption);

            // CollarSize
            CollarSize.SetupEditAttributes();
            CollarSize.EditValue = CollarSize.CurrentValue; // DN
            CollarSize.PlaceHolder = RemoveHtml(CollarSize.Caption);
            if (!Empty(CollarSize.EditValue) && IsNumeric(CollarSize.EditValue))
                CollarSize.EditValue = FormatNumber(CollarSize.EditValue, null);

            // ChestSize
            ChestSize.SetupEditAttributes();
            ChestSize.EditValue = ChestSize.CurrentValue; // DN
            ChestSize.PlaceHolder = RemoveHtml(ChestSize.Caption);
            if (!Empty(ChestSize.EditValue) && IsNumeric(ChestSize.EditValue))
                ChestSize.EditValue = FormatNumber(ChestSize.EditValue, null);

            // WaistSize
            WaistSize.SetupEditAttributes();
            WaistSize.EditValue = WaistSize.CurrentValue; // DN
            WaistSize.PlaceHolder = RemoveHtml(WaistSize.Caption);
            if (!Empty(WaistSize.EditValue) && IsNumeric(WaistSize.EditValue))
                WaistSize.EditValue = FormatNumber(WaistSize.EditValue, null);

            // InsideLegSize
            InsideLegSize.SetupEditAttributes();
            InsideLegSize.EditValue = InsideLegSize.CurrentValue; // DN
            InsideLegSize.PlaceHolder = RemoveHtml(InsideLegSize.Caption);
            if (!Empty(InsideLegSize.EditValue) && IsNumeric(InsideLegSize.EditValue))
                InsideLegSize.EditValue = FormatNumber(InsideLegSize.EditValue, null);

            // CapSize
            CapSize.SetupEditAttributes();
            CapSize.EditValue = CapSize.CurrentValue; // DN
            CapSize.PlaceHolder = RemoveHtml(CapSize.Caption);
            if (!Empty(CapSize.EditValue) && IsNumeric(CapSize.EditValue))
                CapSize.EditValue = FormatNumber(CapSize.EditValue, null);

            // SweaterSize_ClothesSizeID
            SweaterSize_ClothesSizeID.SetupEditAttributes();
            SweaterSize_ClothesSizeID.PlaceHolder = RemoveHtml(SweaterSize_ClothesSizeID.Caption);
            if (!Empty(SweaterSize_ClothesSizeID.EditValue) && IsNumeric(SweaterSize_ClothesSizeID.EditValue))
                SweaterSize_ClothesSizeID.EditValue = FormatNumber(SweaterSize_ClothesSizeID.EditValue, null);

            // BoilersuitSize_ClothesSizeID
            BoilersuitSize_ClothesSizeID.SetupEditAttributes();
            BoilersuitSize_ClothesSizeID.PlaceHolder = RemoveHtml(BoilersuitSize_ClothesSizeID.Caption);
            if (!Empty(BoilersuitSize_ClothesSizeID.EditValue) && IsNumeric(BoilersuitSize_ClothesSizeID.EditValue))
                BoilersuitSize_ClothesSizeID.EditValue = FormatNumber(BoilersuitSize_ClothesSizeID.EditValue, null);

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
            SocialSecurityImage.EditAttrs["accept"] = "jpg,jpeg,gif,png";
            SocialSecurityImage.UploadPath = SocialSecurityImage.GetUploadPath();
            if (!IsNull(SocialSecurityImage.Upload.DbValue)) {
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
            PersonalTaxImage.EditAttrs["accept"] = "jpg,jpeg,gif,png";
            PersonalTaxImage.UploadPath = PersonalTaxImage.GetUploadPath();
            if (!IsNull(PersonalTaxImage.Upload.DbValue)) {
                PersonalTaxImage.EditValue = PersonalTaxImage.Upload.DbValue;
            } else {
                PersonalTaxImage.EditValue = "";
            }
            if (!Empty(PersonalTaxImage.CurrentValue))
                    PersonalTaxImage.Upload.FileName = ConvertToString(PersonalTaxImage.CurrentValue);

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

            // NomineeValidVisa
            NomineeValidVisa.SetupEditAttributes();
            if (!NomineeValidVisa.Raw)
                NomineeValidVisa.CurrentValue = HtmlDecode(NomineeValidVisa.CurrentValue);
            NomineeValidVisa.EditValue = HtmlEncode(NomineeValidVisa.CurrentValue);
            NomineeValidVisa.PlaceHolder = RemoveHtml(NomineeValidVisa.Caption);

            // BankName
            BankName.SetupEditAttributes();
            if (!BankName.Raw)
                BankName.CurrentValue = HtmlDecode(BankName.CurrentValue);
            BankName.EditValue = HtmlEncode(BankName.CurrentValue);
            BankName.PlaceHolder = RemoveHtml(BankName.Caption);

            // BankAddress
            BankAddress.SetupEditAttributes();
            BankAddress.EditValue = BankAddress.CurrentValue; // DN
            BankAddress.PlaceHolder = RemoveHtml(BankAddress.Caption);

            // BankAccountName
            BankAccountName.SetupEditAttributes();
            if (!BankAccountName.Raw)
                BankAccountName.CurrentValue = HtmlDecode(BankAccountName.CurrentValue);
            BankAccountName.EditValue = HtmlEncode(BankAccountName.CurrentValue);
            BankAccountName.PlaceHolder = RemoveHtml(BankAccountName.Caption);

            // BankAccountNumber
            BankAccountNumber.SetupEditAttributes();
            if (!BankAccountNumber.Raw)
                BankAccountNumber.CurrentValue = HtmlDecode(BankAccountNumber.CurrentValue);
            BankAccountNumber.EditValue = HtmlEncode(BankAccountNumber.CurrentValue);
            BankAccountNumber.PlaceHolder = RemoveHtml(BankAccountNumber.Caption);

            // BankSortCode
            BankSortCode.SetupEditAttributes();
            if (!BankSortCode.Raw)
                BankSortCode.CurrentValue = HtmlDecode(BankSortCode.CurrentValue);
            BankSortCode.EditValue = HtmlEncode(BankSortCode.CurrentValue);
            BankSortCode.PlaceHolder = RemoveHtml(BankSortCode.Caption);

            // MNOPF
            MNOPF.SetupEditAttributes();
            if (!MNOPF.Raw)
                MNOPF.CurrentValue = HtmlDecode(MNOPF.CurrentValue);
            MNOPF.EditValue = HtmlEncode(MNOPF.CurrentValue);
            MNOPF.PlaceHolder = RemoveHtml(MNOPF.Caption);

            // MembershipNumber
            MembershipNumber.SetupEditAttributes();
            if (!MembershipNumber.Raw)
                MembershipNumber.CurrentValue = HtmlDecode(MembershipNumber.CurrentValue);
            MembershipNumber.EditValue = HtmlEncode(MembershipNumber.CurrentValue);
            MembershipNumber.PlaceHolder = RemoveHtml(MembershipNumber.Caption);

            // NationalInsuranceNumber
            NationalInsuranceNumber.SetupEditAttributes();
            if (!NationalInsuranceNumber.Raw)
                NationalInsuranceNumber.CurrentValue = HtmlDecode(NationalInsuranceNumber.CurrentValue);
            NationalInsuranceNumber.EditValue = HtmlEncode(NationalInsuranceNumber.CurrentValue);
            NationalInsuranceNumber.PlaceHolder = RemoveHtml(NationalInsuranceNumber.Caption);

            // AVC
            AVC.SetupEditAttributes();
            if (!AVC.Raw)
                AVC.CurrentValue = HtmlDecode(AVC.CurrentValue);
            AVC.EditValue = HtmlEncode(AVC.CurrentValue);
            AVC.PlaceHolder = RemoveHtml(AVC.Caption);

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

            // ActiveDescription
            ActiveDescription.SetupEditAttributes();
            if (!ActiveDescription.Raw)
                ActiveDescription.CurrentValue = HtmlDecode(ActiveDescription.CurrentValue);
            ActiveDescription.EditValue = HtmlEncode(ActiveDescription.CurrentValue);
            ActiveDescription.PlaceHolder = RemoveHtml(ActiveDescription.Caption);

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

            // DocumentCheckDateTime
            DocumentCheckDateTime.SetupEditAttributes();
            DocumentCheckDateTime.EditValue = FormatDateTime(DocumentCheckDateTime.CurrentValue, DocumentCheckDateTime.FormatPattern); // DN
            DocumentCheckDateTime.PlaceHolder = RemoveHtml(DocumentCheckDateTime.Caption);

            // InterviewManagerDateTime
            InterviewManagerDateTime.SetupEditAttributes();
            InterviewManagerDateTime.EditValue = FormatDateTime(InterviewManagerDateTime.CurrentValue, InterviewManagerDateTime.FormatPattern); // DN
            InterviewManagerDateTime.PlaceHolder = RemoveHtml(InterviewManagerDateTime.Caption);

            // InterviewGMDateTime
            InterviewGMDateTime.SetupEditAttributes();
            InterviewGMDateTime.EditValue = FormatDateTime(InterviewGMDateTime.CurrentValue, InterviewGMDateTime.FormatPattern); // DN
            InterviewGMDateTime.PlaceHolder = RemoveHtml(InterviewGMDateTime.Caption);

            // MCUScheduleDateTime
            MCUScheduleDateTime.SetupEditAttributes();
            MCUScheduleDateTime.EditValue = FormatDateTime(MCUScheduleDateTime.CurrentValue, MCUScheduleDateTime.FormatPattern); // DN
            MCUScheduleDateTime.PlaceHolder = RemoveHtml(MCUScheduleDateTime.Caption);

            // RejectedReason
            RejectedReason.SetupEditAttributes();
            RejectedReason.EditValue = RejectedReason.CurrentValue; // DN
            RejectedReason.PlaceHolder = RemoveHtml(RejectedReason.Caption);

            // RejectedDateTime
            RejectedDateTime.SetupEditAttributes();
            RejectedDateTime.EditValue = FormatDateTime(RejectedDateTime.CurrentValue, RejectedDateTime.FormatPattern); // DN
            RejectedDateTime.PlaceHolder = RemoveHtml(RejectedDateTime.Caption);

            // Status
            Status.SetupEditAttributes();
            if (!Status.Raw)
                Status.CurrentValue = HtmlDecode(Status.CurrentValue);
            Status.EditValue = HtmlEncode(Status.CurrentValue);
            Status.PlaceHolder = RemoveHtml(Status.Caption);

            // Reason
            Reason.SetupEditAttributes();
            if (!Reason.Raw)
                Reason.CurrentValue = HtmlDecode(Reason.CurrentValue);
            Reason.EditValue = HtmlEncode(Reason.CurrentValue);
            Reason.PlaceHolder = RemoveHtml(Reason.Caption);

            // Weight
            Weight.SetupEditAttributes();
            Weight.EditValue = Weight.CurrentValue; // DN
            Weight.PlaceHolder = RemoveHtml(Weight.Caption);
            if (!Empty(Weight.EditValue) && IsNumeric(Weight.EditValue))
                Weight.EditValue = FormatNumber(Weight.EditValue, null);

            // Height
            Height.SetupEditAttributes();
            Height.EditValue = Height.CurrentValue; // DN
            Height.PlaceHolder = RemoveHtml(Height.Caption);
            if (!Empty(Height.EditValue) && IsNumeric(Height.EditValue))
                Height.EditValue = FormatNumber(Height.EditValue, null);

            // CoverallSize
            CoverallSize.SetupEditAttributes();
            if (!CoverallSize.Raw)
                CoverallSize.CurrentValue = HtmlDecode(CoverallSize.CurrentValue);
            CoverallSize.EditValue = HtmlEncode(CoverallSize.CurrentValue);
            CoverallSize.PlaceHolder = RemoveHtml(CoverallSize.Caption);

            // SafetyShoesSize
            SafetyShoesSize.SetupEditAttributes();
            SafetyShoesSize.EditValue = SafetyShoesSize.CurrentValue; // DN
            SafetyShoesSize.PlaceHolder = RemoveHtml(SafetyShoesSize.Caption);
            if (!Empty(SafetyShoesSize.EditValue) && IsNumeric(SafetyShoesSize.EditValue))
                SafetyShoesSize.EditValue = FormatNumber(SafetyShoesSize.EditValue, null);

            // ShirtSize
            ShirtSize.SetupEditAttributes();
            if (!ShirtSize.Raw)
                ShirtSize.CurrentValue = HtmlDecode(ShirtSize.CurrentValue);
            ShirtSize.EditValue = HtmlEncode(ShirtSize.CurrentValue);
            ShirtSize.PlaceHolder = RemoveHtml(ShirtSize.Caption);

            // TrousersSize
            TrousersSize.SetupEditAttributes();
            if (!TrousersSize.Raw)
                TrousersSize.CurrentValue = HtmlDecode(TrousersSize.CurrentValue);
            TrousersSize.EditValue = HtmlEncode(TrousersSize.CurrentValue);
            TrousersSize.PlaceHolder = RemoveHtml(TrousersSize.Caption);

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

            // FinalAcceptedDate
            FinalAcceptedDate.SetupEditAttributes();
            FinalAcceptedDate.EditValue = FormatDateTime(FinalAcceptedDate.CurrentValue, FinalAcceptedDate.FormatPattern); // DN
            FinalAcceptedDate.PlaceHolder = RemoveHtml(FinalAcceptedDate.Caption);

            // Reference1CompanyTelephoneCode_CountryID
            Reference1CompanyTelephoneCode_CountryID.SetupEditAttributes();
            Reference1CompanyTelephoneCode_CountryID.PlaceHolder = RemoveHtml(Reference1CompanyTelephoneCode_CountryID.Caption);

            // Reference2CompanyTelephoneCode_CountryID
            Reference2CompanyTelephoneCode_CountryID.SetupEditAttributes();
            Reference2CompanyTelephoneCode_CountryID.PlaceHolder = RemoveHtml(Reference2CompanyTelephoneCode_CountryID.Caption);

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

            // RevisedReason
            RevisedReason.SetupEditAttributes();
            if (!RevisedReason.Raw)
                RevisedReason.CurrentValue = HtmlDecode(RevisedReason.CurrentValue);
            RevisedReason.EditValue = HtmlEncode(RevisedReason.CurrentValue);
            RevisedReason.PlaceHolder = RemoveHtml(RevisedReason.Caption);

            // RevisedDateTime
            RevisedDateTime.SetupEditAttributes();
            RevisedDateTime.EditValue = FormatDateTime(RevisedDateTime.CurrentValue, RevisedDateTime.FormatPattern); // DN
            RevisedDateTime.PlaceHolder = RemoveHtml(RevisedDateTime.Caption);

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
                        doc.ExportCaption(MaritalStatus);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(ReligionID);
                        doc.ExportCaption(BloodType);
                        doc.ExportCaption(RankAppliedFor_RankID);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
                        doc.ExportCaption(PrimaryAddressDetail);
                        doc.ExportCaption(PrimaryAddressCity);
                        doc.ExportCaption(PrimaryAddressState);
                        doc.ExportCaption(PrimaryAddressNearestAirport);
                        doc.ExportCaption(PrimaryAddressPostCode);
                        doc.ExportCaption(PrimaryAddressCountryID);
                        doc.ExportCaption(PrimaryAddressHomeTel);
                        doc.ExportCaption(PrimaryAddressFax);
                        doc.ExportCaption(AlternativeAddressDetail);
                        doc.ExportCaption(AlternativeAddressCity);
                        doc.ExportCaption(AlternativeAddressState);
                        doc.ExportCaption(AlternativeAddressHomeTel);
                        doc.ExportCaption(AlternativeAddressPostCode);
                        doc.ExportCaption(AlternativeAddressCountryID);
                        doc.ExportCaption(MobileNumber);
                        doc.ExportCaption(_Email);
                        doc.ExportCaption(ContactMethodEmail);
                        doc.ExportCaption(ContactMethodFax);
                        doc.ExportCaption(ContactMethodMobilePhone);
                        doc.ExportCaption(ContactMethodHomePhone);
                        doc.ExportCaption(ContactMethodPost);
                        doc.ExportCaption(CollarSize);
                        doc.ExportCaption(ChestSize);
                        doc.ExportCaption(WaistSize);
                        doc.ExportCaption(InsideLegSize);
                        doc.ExportCaption(CapSize);
                        doc.ExportCaption(SweaterSize_ClothesSizeID);
                        doc.ExportCaption(BoilersuitSize_ClothesSizeID);
                        doc.ExportCaption(SocialSecurityNumber);
                        doc.ExportCaption(SocialSecurityIssuingCountryID);
                        doc.ExportCaption(SocialSecurityImage);
                        doc.ExportCaption(PersonalTaxNumber);
                        doc.ExportCaption(PersonalTaxIssuingCountryID);
                        doc.ExportCaption(PersonalTaxImage);
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
                        doc.ExportCaption(NomineeValidVisa);
                        doc.ExportCaption(BankName);
                        doc.ExportCaption(BankAddress);
                        doc.ExportCaption(BankAccountName);
                        doc.ExportCaption(BankAccountNumber);
                        doc.ExportCaption(BankSortCode);
                        doc.ExportCaption(MNOPF);
                        doc.ExportCaption(MembershipNumber);
                        doc.ExportCaption(NationalInsuranceNumber);
                        doc.ExportCaption(AVC);
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
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(Status);
                        doc.ExportCaption(Reason);
                        doc.ExportCaption(Weight);
                        doc.ExportCaption(Height);
                        doc.ExportCaption(CoverallSize);
                        doc.ExportCaption(SafetyShoesSize);
                        doc.ExportCaption(ShirtSize);
                        doc.ExportCaption(TrousersSize);
                        doc.ExportCaption(NSSF_Health_Number);
                        doc.ExportCaption(NSSF_Occupation_Number);
                        doc.ExportCaption(FinalAcceptedDate);
                        doc.ExportCaption(Reference1CompanyTelephoneCode_CountryID);
                        doc.ExportCaption(Reference2CompanyTelephoneCode_CountryID);
                        doc.ExportCaption(MobileNumberCode_CountryID);
                        doc.ExportCaption(PrimaryAddressHomeTelCode_CountryID);
                        doc.ExportCaption(AlternativeAddressHomeTelCode_CountryID);
                        doc.ExportCaption(NomineeAddressHomeTelCode_CountryID);
                        doc.ExportCaption(NomineeMobileNumberCode_CountryID);
                        doc.ExportCaption(RevisedReason);
                        doc.ExportCaption(RevisedDateTime);
                    } else {
                        doc.ExportCaption(IndividualCodeNumber);
                        doc.ExportCaption(FullName);
                        doc.ExportCaption(RequiredPhoto);
                        doc.ExportCaption(VisaPhoto);
                        doc.ExportCaption(Nationality_CountryID);
                        doc.ExportCaption(CountryOfOrigin_CountryID);
                        doc.ExportCaption(DateOfBirth);
                        doc.ExportCaption(CityOfBirth);
                        doc.ExportCaption(MaritalStatus);
                        doc.ExportCaption(Gender);
                        doc.ExportCaption(ReligionID);
                        doc.ExportCaption(BloodType);
                        doc.ExportCaption(RankAppliedFor_RankID);
                        doc.ExportCaption(WillAcceptLowRank);
                        doc.ExportCaption(AvailableFrom);
                        doc.ExportCaption(AvailableUntil);
                        doc.ExportCaption(PrimaryAddressDetail);
                        doc.ExportCaption(PrimaryAddressCity);
                        doc.ExportCaption(PrimaryAddressState);
                        doc.ExportCaption(PrimaryAddressNearestAirport);
                        doc.ExportCaption(PrimaryAddressPostCode);
                        doc.ExportCaption(PrimaryAddressCountryID);
                        doc.ExportCaption(PrimaryAddressHomeTel);
                        doc.ExportCaption(PrimaryAddressFax);
                        doc.ExportCaption(AlternativeAddressDetail);
                        doc.ExportCaption(AlternativeAddressCity);
                        doc.ExportCaption(AlternativeAddressState);
                        doc.ExportCaption(AlternativeAddressHomeTel);
                        doc.ExportCaption(AlternativeAddressPostCode);
                        doc.ExportCaption(AlternativeAddressCountryID);
                        doc.ExportCaption(MobileNumber);
                        doc.ExportCaption(_Email);
                        doc.ExportCaption(ContactMethodEmail);
                        doc.ExportCaption(ContactMethodFax);
                        doc.ExportCaption(ContactMethodMobilePhone);
                        doc.ExportCaption(ContactMethodHomePhone);
                        doc.ExportCaption(ContactMethodPost);
                        doc.ExportCaption(CollarSize);
                        doc.ExportCaption(ChestSize);
                        doc.ExportCaption(WaistSize);
                        doc.ExportCaption(InsideLegSize);
                        doc.ExportCaption(CapSize);
                        doc.ExportCaption(SweaterSize_ClothesSizeID);
                        doc.ExportCaption(BoilersuitSize_ClothesSizeID);
                        doc.ExportCaption(SocialSecurityNumber);
                        doc.ExportCaption(SocialSecurityIssuingCountryID);
                        doc.ExportCaption(SocialSecurityImage);
                        doc.ExportCaption(PersonalTaxNumber);
                        doc.ExportCaption(PersonalTaxIssuingCountryID);
                        doc.ExportCaption(PersonalTaxImage);
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
                        doc.ExportCaption(NomineeValidVisa);
                        doc.ExportCaption(BankName);
                        doc.ExportCaption(BankAddress);
                        doc.ExportCaption(BankAccountName);
                        doc.ExportCaption(BankAccountNumber);
                        doc.ExportCaption(BankSortCode);
                        doc.ExportCaption(MNOPF);
                        doc.ExportCaption(MembershipNumber);
                        doc.ExportCaption(NationalInsuranceNumber);
                        doc.ExportCaption(AVC);
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
                        doc.ExportCaption(CreatedByUserID);
                        doc.ExportCaption(CreatedDateTime);
                        doc.ExportCaption(LastUpdatedByUserID);
                        doc.ExportCaption(LastUpdatedDateTime);
                        doc.ExportCaption(DocumentCheckDateTime);
                        doc.ExportCaption(InterviewManagerDateTime);
                        doc.ExportCaption(InterviewGMDateTime);
                        doc.ExportCaption(MCUScheduleDateTime);
                        doc.ExportCaption(RejectedReason);
                        doc.ExportCaption(RejectedDateTime);
                        doc.ExportCaption(Status);
                        doc.ExportCaption(Reason);
                        doc.ExportCaption(Weight);
                        doc.ExportCaption(Height);
                        doc.ExportCaption(CoverallSize);
                        doc.ExportCaption(SafetyShoesSize);
                        doc.ExportCaption(ShirtSize);
                        doc.ExportCaption(TrousersSize);
                        doc.ExportCaption(NSSF_Health_Number);
                        doc.ExportCaption(NSSF_Occupation_Number);
                        doc.ExportCaption(FinalAcceptedDate);
                        doc.ExportCaption(Reference1CompanyTelephoneCode_CountryID);
                        doc.ExportCaption(Reference2CompanyTelephoneCode_CountryID);
                        doc.ExportCaption(MobileNumberCode_CountryID);
                        doc.ExportCaption(PrimaryAddressHomeTelCode_CountryID);
                        doc.ExportCaption(AlternativeAddressHomeTelCode_CountryID);
                        doc.ExportCaption(NomineeAddressHomeTelCode_CountryID);
                        doc.ExportCaption(NomineeMobileNumberCode_CountryID);
                        doc.ExportCaption(RevisedReason);
                        doc.ExportCaption(RevisedDateTime);
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
                            await doc.ExportField(MaritalStatus);
                            await doc.ExportField(Gender);
                            await doc.ExportField(ReligionID);
                            await doc.ExportField(BloodType);
                            await doc.ExportField(RankAppliedFor_RankID);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
                            await doc.ExportField(PrimaryAddressDetail);
                            await doc.ExportField(PrimaryAddressCity);
                            await doc.ExportField(PrimaryAddressState);
                            await doc.ExportField(PrimaryAddressNearestAirport);
                            await doc.ExportField(PrimaryAddressPostCode);
                            await doc.ExportField(PrimaryAddressCountryID);
                            await doc.ExportField(PrimaryAddressHomeTel);
                            await doc.ExportField(PrimaryAddressFax);
                            await doc.ExportField(AlternativeAddressDetail);
                            await doc.ExportField(AlternativeAddressCity);
                            await doc.ExportField(AlternativeAddressState);
                            await doc.ExportField(AlternativeAddressHomeTel);
                            await doc.ExportField(AlternativeAddressPostCode);
                            await doc.ExportField(AlternativeAddressCountryID);
                            await doc.ExportField(MobileNumber);
                            await doc.ExportField(_Email);
                            await doc.ExportField(ContactMethodEmail);
                            await doc.ExportField(ContactMethodFax);
                            await doc.ExportField(ContactMethodMobilePhone);
                            await doc.ExportField(ContactMethodHomePhone);
                            await doc.ExportField(ContactMethodPost);
                            await doc.ExportField(CollarSize);
                            await doc.ExportField(ChestSize);
                            await doc.ExportField(WaistSize);
                            await doc.ExportField(InsideLegSize);
                            await doc.ExportField(CapSize);
                            await doc.ExportField(SweaterSize_ClothesSizeID);
                            await doc.ExportField(BoilersuitSize_ClothesSizeID);
                            await doc.ExportField(SocialSecurityNumber);
                            await doc.ExportField(SocialSecurityIssuingCountryID);
                            await doc.ExportField(SocialSecurityImage);
                            await doc.ExportField(PersonalTaxNumber);
                            await doc.ExportField(PersonalTaxIssuingCountryID);
                            await doc.ExportField(PersonalTaxImage);
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
                            await doc.ExportField(NomineeValidVisa);
                            await doc.ExportField(BankName);
                            await doc.ExportField(BankAddress);
                            await doc.ExportField(BankAccountName);
                            await doc.ExportField(BankAccountNumber);
                            await doc.ExportField(BankSortCode);
                            await doc.ExportField(MNOPF);
                            await doc.ExportField(MembershipNumber);
                            await doc.ExportField(NationalInsuranceNumber);
                            await doc.ExportField(AVC);
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
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(Status);
                            await doc.ExportField(Reason);
                            await doc.ExportField(Weight);
                            await doc.ExportField(Height);
                            await doc.ExportField(CoverallSize);
                            await doc.ExportField(SafetyShoesSize);
                            await doc.ExportField(ShirtSize);
                            await doc.ExportField(TrousersSize);
                            await doc.ExportField(NSSF_Health_Number);
                            await doc.ExportField(NSSF_Occupation_Number);
                            await doc.ExportField(FinalAcceptedDate);
                            await doc.ExportField(Reference1CompanyTelephoneCode_CountryID);
                            await doc.ExportField(Reference2CompanyTelephoneCode_CountryID);
                            await doc.ExportField(MobileNumberCode_CountryID);
                            await doc.ExportField(PrimaryAddressHomeTelCode_CountryID);
                            await doc.ExportField(AlternativeAddressHomeTelCode_CountryID);
                            await doc.ExportField(NomineeAddressHomeTelCode_CountryID);
                            await doc.ExportField(NomineeMobileNumberCode_CountryID);
                            await doc.ExportField(RevisedReason);
                            await doc.ExportField(RevisedDateTime);
                        } else {
                            await doc.ExportField(IndividualCodeNumber);
                            await doc.ExportField(FullName);
                            await doc.ExportField(RequiredPhoto);
                            await doc.ExportField(VisaPhoto);
                            await doc.ExportField(Nationality_CountryID);
                            await doc.ExportField(CountryOfOrigin_CountryID);
                            await doc.ExportField(DateOfBirth);
                            await doc.ExportField(CityOfBirth);
                            await doc.ExportField(MaritalStatus);
                            await doc.ExportField(Gender);
                            await doc.ExportField(ReligionID);
                            await doc.ExportField(BloodType);
                            await doc.ExportField(RankAppliedFor_RankID);
                            await doc.ExportField(WillAcceptLowRank);
                            await doc.ExportField(AvailableFrom);
                            await doc.ExportField(AvailableUntil);
                            await doc.ExportField(PrimaryAddressDetail);
                            await doc.ExportField(PrimaryAddressCity);
                            await doc.ExportField(PrimaryAddressState);
                            await doc.ExportField(PrimaryAddressNearestAirport);
                            await doc.ExportField(PrimaryAddressPostCode);
                            await doc.ExportField(PrimaryAddressCountryID);
                            await doc.ExportField(PrimaryAddressHomeTel);
                            await doc.ExportField(PrimaryAddressFax);
                            await doc.ExportField(AlternativeAddressDetail);
                            await doc.ExportField(AlternativeAddressCity);
                            await doc.ExportField(AlternativeAddressState);
                            await doc.ExportField(AlternativeAddressHomeTel);
                            await doc.ExportField(AlternativeAddressPostCode);
                            await doc.ExportField(AlternativeAddressCountryID);
                            await doc.ExportField(MobileNumber);
                            await doc.ExportField(_Email);
                            await doc.ExportField(ContactMethodEmail);
                            await doc.ExportField(ContactMethodFax);
                            await doc.ExportField(ContactMethodMobilePhone);
                            await doc.ExportField(ContactMethodHomePhone);
                            await doc.ExportField(ContactMethodPost);
                            await doc.ExportField(CollarSize);
                            await doc.ExportField(ChestSize);
                            await doc.ExportField(WaistSize);
                            await doc.ExportField(InsideLegSize);
                            await doc.ExportField(CapSize);
                            await doc.ExportField(SweaterSize_ClothesSizeID);
                            await doc.ExportField(BoilersuitSize_ClothesSizeID);
                            await doc.ExportField(SocialSecurityNumber);
                            await doc.ExportField(SocialSecurityIssuingCountryID);
                            await doc.ExportField(SocialSecurityImage);
                            await doc.ExportField(PersonalTaxNumber);
                            await doc.ExportField(PersonalTaxIssuingCountryID);
                            await doc.ExportField(PersonalTaxImage);
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
                            await doc.ExportField(NomineeValidVisa);
                            await doc.ExportField(BankName);
                            await doc.ExportField(BankAddress);
                            await doc.ExportField(BankAccountName);
                            await doc.ExportField(BankAccountNumber);
                            await doc.ExportField(BankSortCode);
                            await doc.ExportField(MNOPF);
                            await doc.ExportField(MembershipNumber);
                            await doc.ExportField(NationalInsuranceNumber);
                            await doc.ExportField(AVC);
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
                            await doc.ExportField(CreatedByUserID);
                            await doc.ExportField(CreatedDateTime);
                            await doc.ExportField(LastUpdatedByUserID);
                            await doc.ExportField(LastUpdatedDateTime);
                            await doc.ExportField(DocumentCheckDateTime);
                            await doc.ExportField(InterviewManagerDateTime);
                            await doc.ExportField(InterviewGMDateTime);
                            await doc.ExportField(MCUScheduleDateTime);
                            await doc.ExportField(RejectedReason);
                            await doc.ExportField(RejectedDateTime);
                            await doc.ExportField(Status);
                            await doc.ExportField(Reason);
                            await doc.ExportField(Weight);
                            await doc.ExportField(Height);
                            await doc.ExportField(CoverallSize);
                            await doc.ExportField(SafetyShoesSize);
                            await doc.ExportField(ShirtSize);
                            await doc.ExportField(TrousersSize);
                            await doc.ExportField(NSSF_Health_Number);
                            await doc.ExportField(NSSF_Occupation_Number);
                            await doc.ExportField(FinalAcceptedDate);
                            await doc.ExportField(Reference1CompanyTelephoneCode_CountryID);
                            await doc.ExportField(Reference2CompanyTelephoneCode_CountryID);
                            await doc.ExportField(MobileNumberCode_CountryID);
                            await doc.ExportField(PrimaryAddressHomeTelCode_CountryID);
                            await doc.ExportField(AlternativeAddressHomeTelCode_CountryID);
                            await doc.ExportField(NomineeAddressHomeTelCode_CountryID);
                            await doc.ExportField(NomineeMobileNumberCode_CountryID);
                            await doc.ExportField(RevisedReason);
                            await doc.ExportField(RevisedDateTime);
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
