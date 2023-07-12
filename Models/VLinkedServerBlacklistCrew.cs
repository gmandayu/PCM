namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// vLinkedServerBlacklistCrew
    /// </summary>
    [MaybeNull]
    public static VLinkedServerBlacklistCrew vLinkedServerBlacklistCrew
    {
        get => HttpData.Resolve<VLinkedServerBlacklistCrew>("v_LinkedServerBlacklistCrew");
        set => HttpData["v_LinkedServerBlacklistCrew"] = value;
    }

    /// <summary>
    /// Table class for v_LinkedServerBlacklistCrew
    /// </summary>
    public class VLinkedServerBlacklistCrew : DbTable, IQueryFactory
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

        public readonly DbField<SqlDbType> id;

        public readonly DbField<SqlDbType> NamaCrew;

        public readonly DbField<SqlDbType> WarnaCek;

        public readonly DbField<SqlDbType> NoIjazah;

        public readonly DbField<SqlDbType> KodePelaut;

        public readonly DbField<SqlDbType> TempatLahir;

        public readonly DbField<SqlDbType> TanggalLahir;

        public readonly DbField<SqlDbType> EksKapal;

        public readonly DbField<SqlDbType> Rank;

        public readonly DbField<SqlDbType> PerwiraRating;

        public readonly DbField<SqlDbType> TempatKejadian;

        public readonly DbField<SqlDbType> TanggalKejadian;

        public readonly DbField<SqlDbType> Keterangan;

        public readonly DbField<SqlDbType> RapatKomite;

        public readonly DbField<SqlDbType> TanggalPenetapanSanksi;

        public readonly DbField<SqlDbType> MasaAkhirHukuman;

        public readonly DbField<SqlDbType> StatusAwalSanksi;

        public readonly DbField<SqlDbType> SisaHariHukuman;

        public readonly DbField<SqlDbType> TahunPenetapanSanksi;

        public readonly DbField<SqlDbType> BAP;

        public readonly DbField<SqlDbType> HasilWorkshop;

        // Constructor
        public VLinkedServerBlacklistCrew()
        {
            // Language object // DN
            Language = ResolveLanguage();
            TableVar = "v_LinkedServerBlacklistCrew";
            Name = "v_LinkedServerBlacklistCrew";
            Type = "VIEW";
            UpdateTable = "dbo.v_LinkedServerBlacklistCrew"; // Update Table
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

            // id
            id = new (this, "x_id", 20, SqlDbType.BigInt) {
                Name = "id",
                Expression = "[id]",
                BasicSearchExpression = "CAST([id] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[id]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                Nullable = false, // NOT NULL field
                Required = true, // Required field
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "id", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("id", id);

            // NamaCrew
            NamaCrew = new (this, "x_NamaCrew", 200, SqlDbType.VarChar) {
                Name = "NamaCrew",
                Expression = "[NamaCrew]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NamaCrew]",
                DateTimeFormat = -1,
                VirtualExpression = "[NamaCrew]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "NamaCrew", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NamaCrew", NamaCrew);

            // WarnaCek
            WarnaCek = new (this, "x_WarnaCek", 200, SqlDbType.VarChar) {
                Name = "WarnaCek",
                Expression = "[WarnaCek]",
                UseBasicSearch = true,
                BasicSearchExpression = "[WarnaCek]",
                DateTimeFormat = -1,
                VirtualExpression = "[WarnaCek]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "WarnaCek", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("WarnaCek", WarnaCek);

            // NoIjazah
            NoIjazah = new (this, "x_NoIjazah", 200, SqlDbType.VarChar) {
                Name = "NoIjazah",
                Expression = "[NoIjazah]",
                UseBasicSearch = true,
                BasicSearchExpression = "[NoIjazah]",
                DateTimeFormat = -1,
                VirtualExpression = "[NoIjazah]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "NoIjazah", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("NoIjazah", NoIjazah);

            // KodePelaut
            KodePelaut = new (this, "x_KodePelaut", 200, SqlDbType.VarChar) {
                Name = "KodePelaut",
                Expression = "[KodePelaut]",
                UseBasicSearch = true,
                BasicSearchExpression = "[KodePelaut]",
                DateTimeFormat = -1,
                VirtualExpression = "[KodePelaut]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "KodePelaut", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("KodePelaut", KodePelaut);

            // TempatLahir
            TempatLahir = new (this, "x_TempatLahir", 200, SqlDbType.VarChar) {
                Name = "TempatLahir",
                Expression = "[TempatLahir]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TempatLahir]",
                DateTimeFormat = -1,
                VirtualExpression = "[TempatLahir]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "TempatLahir", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("TempatLahir", TempatLahir);

            // TanggalLahir
            TanggalLahir = new (this, "x_TanggalLahir", 133, SqlDbType.DateTime) {
                Name = "TanggalLahir",
                Expression = "[TanggalLahir]",
                BasicSearchExpression = CastDateFieldForLike("[TanggalLahir]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[TanggalLahir]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "TanggalLahir", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("TanggalLahir", TanggalLahir);

            // EksKapal
            EksKapal = new (this, "x_EksKapal", 200, SqlDbType.VarChar) {
                Name = "EksKapal",
                Expression = "[EksKapal]",
                UseBasicSearch = true,
                BasicSearchExpression = "[EksKapal]",
                DateTimeFormat = -1,
                VirtualExpression = "[EksKapal]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "EksKapal", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("EksKapal", EksKapal);

            // Rank
            Rank = new (this, "x_Rank", 200, SqlDbType.VarChar) {
                Name = "Rank",
                Expression = "[Rank]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Rank]",
                DateTimeFormat = -1,
                VirtualExpression = "[Rank]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "Rank", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Rank", Rank);

            // PerwiraRating
            PerwiraRating = new (this, "x_PerwiraRating", 200, SqlDbType.VarChar) {
                Name = "PerwiraRating",
                Expression = "[PerwiraRating]",
                UseBasicSearch = true,
                BasicSearchExpression = "[PerwiraRating]",
                DateTimeFormat = -1,
                VirtualExpression = "[PerwiraRating]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "PerwiraRating", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("PerwiraRating", PerwiraRating);

            // TempatKejadian
            TempatKejadian = new (this, "x_TempatKejadian", 200, SqlDbType.VarChar) {
                Name = "TempatKejadian",
                Expression = "[TempatKejadian]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TempatKejadian]",
                DateTimeFormat = -1,
                VirtualExpression = "[TempatKejadian]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "TempatKejadian", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("TempatKejadian", TempatKejadian);

            // TanggalKejadian
            TanggalKejadian = new (this, "x_TanggalKejadian", 200, SqlDbType.VarChar) {
                Name = "TanggalKejadian",
                Expression = "[TanggalKejadian]",
                UseBasicSearch = true,
                BasicSearchExpression = "[TanggalKejadian]",
                DateTimeFormat = -1,
                VirtualExpression = "[TanggalKejadian]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "TanggalKejadian", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("TanggalKejadian", TanggalKejadian);

            // Keterangan
            Keterangan = new (this, "x_Keterangan", 200, SqlDbType.VarChar) {
                Name = "Keterangan",
                Expression = "[Keterangan]",
                UseBasicSearch = true,
                BasicSearchExpression = "[Keterangan]",
                DateTimeFormat = -1,
                VirtualExpression = "[Keterangan]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "Keterangan", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("Keterangan", Keterangan);

            // RapatKomite
            RapatKomite = new (this, "x_RapatKomite", 200, SqlDbType.VarChar) {
                Name = "RapatKomite",
                Expression = "[RapatKomite]",
                UseBasicSearch = true,
                BasicSearchExpression = "[RapatKomite]",
                DateTimeFormat = -1,
                VirtualExpression = "[RapatKomite]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "RapatKomite", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("RapatKomite", RapatKomite);

            // TanggalPenetapanSanksi
            TanggalPenetapanSanksi = new (this, "x_TanggalPenetapanSanksi", 133, SqlDbType.DateTime) {
                Name = "TanggalPenetapanSanksi",
                Expression = "[TanggalPenetapanSanksi]",
                BasicSearchExpression = CastDateFieldForLike("[TanggalPenetapanSanksi]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[TanggalPenetapanSanksi]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "TanggalPenetapanSanksi", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("TanggalPenetapanSanksi", TanggalPenetapanSanksi);

            // MasaAkhirHukuman
            MasaAkhirHukuman = new (this, "x_MasaAkhirHukuman", 133, SqlDbType.DateTime) {
                Name = "MasaAkhirHukuman",
                Expression = "[MasaAkhirHukuman]",
                BasicSearchExpression = CastDateFieldForLike("[MasaAkhirHukuman]", 0, "DB"),
                DateTimeFormat = 0,
                VirtualExpression = "[MasaAkhirHukuman]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = ConvertToString(Language.Phrase("IncorrectDate")).Replace("%s", CurrentDateTimeFormat.ShortDatePattern),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "MasaAkhirHukuman", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("MasaAkhirHukuman", MasaAkhirHukuman);

            // StatusAwalSanksi
            StatusAwalSanksi = new (this, "x_StatusAwalSanksi", 200, SqlDbType.VarChar) {
                Name = "StatusAwalSanksi",
                Expression = "[StatusAwalSanksi]",
                UseBasicSearch = true,
                BasicSearchExpression = "[StatusAwalSanksi]",
                DateTimeFormat = -1,
                VirtualExpression = "[StatusAwalSanksi]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "StatusAwalSanksi", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("StatusAwalSanksi", StatusAwalSanksi);

            // SisaHariHukuman
            SisaHariHukuman = new (this, "x_SisaHariHukuman", 200, SqlDbType.VarChar) {
                Name = "SisaHariHukuman",
                Expression = "[SisaHariHukuman]",
                UseBasicSearch = true,
                BasicSearchExpression = "[SisaHariHukuman]",
                DateTimeFormat = -1,
                VirtualExpression = "[SisaHariHukuman]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "SisaHariHukuman", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("SisaHariHukuman", SisaHariHukuman);

            // TahunPenetapanSanksi
            TahunPenetapanSanksi = new (this, "x_TahunPenetapanSanksi", 2, SqlDbType.SmallInt) {
                Name = "TahunPenetapanSanksi",
                Expression = "[TahunPenetapanSanksi]",
                BasicSearchExpression = "CAST([TahunPenetapanSanksi] AS NVARCHAR)",
                DateTimeFormat = -1,
                VirtualExpression = "[TahunPenetapanSanksi]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                DefaultErrorMessage = Language.Phrase("IncorrectInteger"),
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "<", "<=", ">", ">=", "BETWEEN", "NOT BETWEEN", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "TahunPenetapanSanksi", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("TahunPenetapanSanksi", TahunPenetapanSanksi);

            // BAP
            BAP = new (this, "x_BAP", 129, SqlDbType.Char) {
                Name = "BAP",
                Expression = "[BAP]",
                UseBasicSearch = true,
                BasicSearchExpression = "[BAP]",
                DateTimeFormat = -1,
                VirtualExpression = "[BAP]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "BAP", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("BAP", BAP);

            // HasilWorkshop
            HasilWorkshop = new (this, "x_HasilWorkshop", 200, SqlDbType.VarChar) {
                Name = "HasilWorkshop",
                Expression = "[HasilWorkshop]",
                UseBasicSearch = true,
                BasicSearchExpression = "[HasilWorkshop]",
                DateTimeFormat = -1,
                VirtualExpression = "[HasilWorkshop]",
                IsVirtual = false,
                ForceSelection = false,
                SelectMultiple = false,
                VirtualSearch = false,
                ViewTag = "FORMATTED TEXT",
                HtmlTag = "TEXT",
                InputTextType = "text",
                SearchOperators = new () { "=", "<>", "IN", "NOT IN", "STARTS WITH", "NOT STARTS WITH", "LIKE", "NOT LIKE", "ENDS WITH", "NOT ENDS WITH", "IS EMPTY", "IS NOT EMPTY", "IS NULL", "IS NOT NULL" },
                CustomMessage = Language.FieldPhrase("v_LinkedServerBlacklistCrew", "HasilWorkshop", "CustomMsg"),
                IsUpload = false
            };
            Fields.Add("HasilWorkshop", HasilWorkshop);

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
            get => _sqlFrom ?? "dbo.v_LinkedServerBlacklistCrew";
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
                id.DbValue = row["id"]; // Set DB value only
                NamaCrew.DbValue = row["NamaCrew"]; // Set DB value only
                WarnaCek.DbValue = row["WarnaCek"]; // Set DB value only
                NoIjazah.DbValue = row["NoIjazah"]; // Set DB value only
                KodePelaut.DbValue = row["KodePelaut"]; // Set DB value only
                TempatLahir.DbValue = row["TempatLahir"]; // Set DB value only
                TanggalLahir.DbValue = row["TanggalLahir"]; // Set DB value only
                EksKapal.DbValue = row["EksKapal"]; // Set DB value only
                Rank.DbValue = row["Rank"]; // Set DB value only
                PerwiraRating.DbValue = row["PerwiraRating"]; // Set DB value only
                TempatKejadian.DbValue = row["TempatKejadian"]; // Set DB value only
                TanggalKejadian.DbValue = row["TanggalKejadian"]; // Set DB value only
                Keterangan.DbValue = row["Keterangan"]; // Set DB value only
                RapatKomite.DbValue = row["RapatKomite"]; // Set DB value only
                TanggalPenetapanSanksi.DbValue = row["TanggalPenetapanSanksi"]; // Set DB value only
                MasaAkhirHukuman.DbValue = row["MasaAkhirHukuman"]; // Set DB value only
                StatusAwalSanksi.DbValue = row["StatusAwalSanksi"]; // Set DB value only
                SisaHariHukuman.DbValue = row["SisaHariHukuman"]; // Set DB value only
                TahunPenetapanSanksi.DbValue = row["TahunPenetapanSanksi"]; // Set DB value only
                BAP.DbValue = row["BAP"]; // Set DB value only
                HasilWorkshop.DbValue = row["HasilWorkshop"]; // Set DB value only
            } catch {}
        }

        public void DeleteUploadedFiles(Dictionary<string, object> row)
        {
            LoadDbValues(row);
        }

        // Record filter WHERE clause
        private string _sqlKeyFilter => "";

        #pragma warning disable 168, 219
        // Get record filter as string
        public string GetRecordFilter(Dictionary<string, object>? row = null, bool current = false)
        {
            string keyFilter = _sqlKeyFilter;
            object? val = null, result = "";
            return keyFilter;
        }

        // Get record filter as Dictionary // DN
        public Dictionary<string, object>? GetRowFilterAsDictionary(IDictionary<string, object>? row = null)
        {
            Dictionary<string, object>? keyFilter = new ();
            object? val = null, result;
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
                    return "VLinkedServerBlacklistCrewList";
                }
            }
            set {
                Session[Config.ProjectName + "_" + TableVar + "_" + Config.TableReturnUrl] = value;
            }
        }

        // Get modal caption
        public string GetModalCaption(string pageName)
        {
            if (SameString(pageName, "VLinkedServerBlacklistCrewView"))
                return Language.Phrase("View");
            else if (SameString(pageName, "VLinkedServerBlacklistCrewEdit"))
                return Language.Phrase("Edit");
            else if (SameString(pageName, "VLinkedServerBlacklistCrewAdd"))
                return Language.Phrase("Add");
            else
                return "";
        }

        // Default route URL
        public string DefaultRouteUrl
        {
            get {
                return "VLinkedServerBlacklistCrewList";
            }
        }

        // API page name
        public string GetApiPageName(string action)
        {
            return action.ToLowerInvariant() switch {
                Config.ApiViewAction => "VLinkedServerBlacklistCrewView",
                Config.ApiAddAction => "VLinkedServerBlacklistCrewAdd",
                Config.ApiEditAction => "VLinkedServerBlacklistCrewEdit",
                Config.ApiDeleteAction => "VLinkedServerBlacklistCrewDelete",
                Config.ApiListAction => "VLinkedServerBlacklistCrewList",
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
        public string ListUrl => "VLinkedServerBlacklistCrewList";

        // View URL
        public string ViewUrl => GetViewUrl();

        // View URL
        public string GetViewUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = KeyUrl("VLinkedServerBlacklistCrewView", parm);
            else
                url = KeyUrl("VLinkedServerBlacklistCrewView", Config.TableShowDetail + "=");
            return AddMasterUrl(url);
        }

        // Add URL
        public string AddUrl { get; set; } = "VLinkedServerBlacklistCrewAdd";

        // Add URL
        public string GetAddUrl(string parm = "")
        {
            string url = "";
            if (!Empty(parm))
                url = "VLinkedServerBlacklistCrewAdd?" + parm;
            else
                url = "VLinkedServerBlacklistCrewAdd";
            return AppPath(AddMasterUrl(url));
        }

        // Edit URL
        public string EditUrl => GetEditUrl();

        // Edit URL (with parameter)
        public string GetEditUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("VLinkedServerBlacklistCrewEdit", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline edit URL
        public string InlineEditUrl =>
            AppPath(AddMasterUrl(KeyUrl("VLinkedServerBlacklistCrewList", "action=edit"))); // DN

        // Copy URL
        public string CopyUrl => GetCopyUrl();

        // Copy URL
        public string GetCopyUrl(string parm = "")
        {
            string url = "";
            url = KeyUrl("VLinkedServerBlacklistCrewAdd", parm);
            return AppPath(AddMasterUrl(url)); // DN
        }

        // Inline copy URL
        public string InlineCopyUrl =>
            AppPath(AddMasterUrl(KeyUrl("VLinkedServerBlacklistCrewList", "action=copy"))); // DN

        // Delete URL
        public string DeleteUrl => UseAjaxActions && Param<bool>("infinitescroll") && CurrentPageID() == "list"
            ? AppPath(KeyUrl(Config.ApiUrl + Config.ApiDeleteAction + "/" + TableVar))
            : AppPath(KeyUrl("VLinkedServerBlacklistCrewDelete")); // DN

        // Add master URL
        public string AddMasterUrl(string url)
        {
            return url;
        }

        // Get primary key as JSON
        public string KeyToJson(bool htmlEncode = false)
        {
            string json = "";
            json = "{" + json + "}";
            if (htmlEncode)
                json = HtmlEncode(json);
            return json;
        }

        // Add key value to URL
        public string KeyUrl(string url, string parm = "") { // DN
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
            return String.Join(Config.CompositeKeySeparator, keys);
        }

        // Get record filter as string // DN
        public string GetKey(IDictionary<string, object> row)
        {
            List<string> keys = new ();
            object? val = null, result;
            return String.Join(Config.CompositeKeySeparator, keys);
        }
        #pragma warning restore 168, 219

        // Set key
        public void SetKey(string key, bool current = false)
        {
            OldKey = key;
            string[] keys = OldKey.Split(Convert.ToChar(Config.CompositeKeySeparator));
            if (keys.Length == 0) {
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
                string[] keyValues = {};
                if (IsApi() && RouteValues.TryGetValue("key", out object? k)) {
                    string str = ConvertToString(k);
                    keyValues = str.Split('/');
                }
            }
            // Check keys
            foreach (var keys in keysList) {
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
            id.SetDbValue(dr["id"]);
            NamaCrew.SetDbValue(dr["NamaCrew"]);
            WarnaCek.SetDbValue(dr["WarnaCek"]);
            NoIjazah.SetDbValue(dr["NoIjazah"]);
            KodePelaut.SetDbValue(dr["KodePelaut"]);
            TempatLahir.SetDbValue(dr["TempatLahir"]);
            TanggalLahir.SetDbValue(dr["TanggalLahir"]);
            EksKapal.SetDbValue(dr["EksKapal"]);
            Rank.SetDbValue(dr["Rank"]);
            PerwiraRating.SetDbValue(dr["PerwiraRating"]);
            TempatKejadian.SetDbValue(dr["TempatKejadian"]);
            TanggalKejadian.SetDbValue(dr["TanggalKejadian"]);
            Keterangan.SetDbValue(dr["Keterangan"]);
            RapatKomite.SetDbValue(dr["RapatKomite"]);
            TanggalPenetapanSanksi.SetDbValue(dr["TanggalPenetapanSanksi"]);
            MasaAkhirHukuman.SetDbValue(dr["MasaAkhirHukuman"]);
            StatusAwalSanksi.SetDbValue(dr["StatusAwalSanksi"]);
            SisaHariHukuman.SetDbValue(dr["SisaHariHukuman"]);
            TahunPenetapanSanksi.SetDbValue(dr["TahunPenetapanSanksi"]);
            BAP.SetDbValue(dr["BAP"]);
            HasilWorkshop.SetDbValue(dr["HasilWorkshop"]);
        }

        // Render list content
        public async Task<string> RenderListContent(string filter)
        {
            string pageName = "VLinkedServerBlacklistCrewList";
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

            // id

            // NamaCrew

            // WarnaCek

            // NoIjazah

            // KodePelaut

            // TempatLahir

            // TanggalLahir

            // EksKapal

            // Rank

            // PerwiraRating

            // TempatKejadian

            // TanggalKejadian

            // Keterangan

            // RapatKomite

            // TanggalPenetapanSanksi

            // MasaAkhirHukuman

            // StatusAwalSanksi

            // SisaHariHukuman

            // TahunPenetapanSanksi

            // BAP

            // HasilWorkshop

            // id
            id.ViewValue = id.CurrentValue;
            id.ViewValue = FormatNumber(id.ViewValue, id.FormatPattern);
            id.ViewCustomAttributes = "";

            // NamaCrew
            NamaCrew.ViewValue = ConvertToString(NamaCrew.CurrentValue); // DN
            NamaCrew.ViewCustomAttributes = "";

            // WarnaCek
            WarnaCek.ViewValue = ConvertToString(WarnaCek.CurrentValue); // DN
            WarnaCek.ViewCustomAttributes = "";

            // NoIjazah
            NoIjazah.ViewValue = ConvertToString(NoIjazah.CurrentValue); // DN
            NoIjazah.ViewCustomAttributes = "";

            // KodePelaut
            KodePelaut.ViewValue = ConvertToString(KodePelaut.CurrentValue); // DN
            KodePelaut.ViewCustomAttributes = "";

            // TempatLahir
            TempatLahir.ViewValue = ConvertToString(TempatLahir.CurrentValue); // DN
            TempatLahir.ViewCustomAttributes = "";

            // TanggalLahir
            TanggalLahir.ViewValue = TanggalLahir.CurrentValue;
            TanggalLahir.ViewValue = FormatDateTime(TanggalLahir.ViewValue, TanggalLahir.FormatPattern);
            TanggalLahir.ViewCustomAttributes = "";

            // EksKapal
            EksKapal.ViewValue = ConvertToString(EksKapal.CurrentValue); // DN
            EksKapal.ViewCustomAttributes = "";

            // Rank
            Rank.ViewValue = ConvertToString(Rank.CurrentValue); // DN
            Rank.ViewCustomAttributes = "";

            // PerwiraRating
            PerwiraRating.ViewValue = ConvertToString(PerwiraRating.CurrentValue); // DN
            PerwiraRating.ViewCustomAttributes = "";

            // TempatKejadian
            TempatKejadian.ViewValue = ConvertToString(TempatKejadian.CurrentValue); // DN
            TempatKejadian.ViewCustomAttributes = "";

            // TanggalKejadian
            TanggalKejadian.ViewValue = ConvertToString(TanggalKejadian.CurrentValue); // DN
            TanggalKejadian.ViewCustomAttributes = "";

            // Keterangan
            Keterangan.ViewValue = ConvertToString(Keterangan.CurrentValue); // DN
            Keterangan.ViewCustomAttributes = "";

            // RapatKomite
            RapatKomite.ViewValue = ConvertToString(RapatKomite.CurrentValue); // DN
            RapatKomite.ViewCustomAttributes = "";

            // TanggalPenetapanSanksi
            TanggalPenetapanSanksi.ViewValue = TanggalPenetapanSanksi.CurrentValue;
            TanggalPenetapanSanksi.ViewValue = FormatDateTime(TanggalPenetapanSanksi.ViewValue, TanggalPenetapanSanksi.FormatPattern);
            TanggalPenetapanSanksi.ViewCustomAttributes = "";

            // MasaAkhirHukuman
            MasaAkhirHukuman.ViewValue = MasaAkhirHukuman.CurrentValue;
            MasaAkhirHukuman.ViewValue = FormatDateTime(MasaAkhirHukuman.ViewValue, MasaAkhirHukuman.FormatPattern);
            MasaAkhirHukuman.ViewCustomAttributes = "";

            // StatusAwalSanksi
            StatusAwalSanksi.ViewValue = ConvertToString(StatusAwalSanksi.CurrentValue); // DN
            StatusAwalSanksi.ViewCustomAttributes = "";

            // SisaHariHukuman
            SisaHariHukuman.ViewValue = ConvertToString(SisaHariHukuman.CurrentValue); // DN
            SisaHariHukuman.ViewCustomAttributes = "";

            // TahunPenetapanSanksi
            TahunPenetapanSanksi.ViewValue = TahunPenetapanSanksi.CurrentValue;
            TahunPenetapanSanksi.ViewValue = FormatNumber(TahunPenetapanSanksi.ViewValue, TahunPenetapanSanksi.FormatPattern);
            TahunPenetapanSanksi.ViewCustomAttributes = "";

            // BAP
            BAP.ViewValue = ConvertToString(BAP.CurrentValue); // DN
            BAP.ViewCustomAttributes = "";

            // HasilWorkshop
            HasilWorkshop.ViewValue = ConvertToString(HasilWorkshop.CurrentValue); // DN
            HasilWorkshop.ViewCustomAttributes = "";

            // id
            id.HrefValue = "";
            id.TooltipValue = "";

            // NamaCrew
            NamaCrew.HrefValue = "";
            NamaCrew.TooltipValue = "";

            // WarnaCek
            WarnaCek.HrefValue = "";
            WarnaCek.TooltipValue = "";

            // NoIjazah
            NoIjazah.HrefValue = "";
            NoIjazah.TooltipValue = "";

            // KodePelaut
            KodePelaut.HrefValue = "";
            KodePelaut.TooltipValue = "";

            // TempatLahir
            TempatLahir.HrefValue = "";
            TempatLahir.TooltipValue = "";

            // TanggalLahir
            TanggalLahir.HrefValue = "";
            TanggalLahir.TooltipValue = "";

            // EksKapal
            EksKapal.HrefValue = "";
            EksKapal.TooltipValue = "";

            // Rank
            Rank.HrefValue = "";
            Rank.TooltipValue = "";

            // PerwiraRating
            PerwiraRating.HrefValue = "";
            PerwiraRating.TooltipValue = "";

            // TempatKejadian
            TempatKejadian.HrefValue = "";
            TempatKejadian.TooltipValue = "";

            // TanggalKejadian
            TanggalKejadian.HrefValue = "";
            TanggalKejadian.TooltipValue = "";

            // Keterangan
            Keterangan.HrefValue = "";
            Keterangan.TooltipValue = "";

            // RapatKomite
            RapatKomite.HrefValue = "";
            RapatKomite.TooltipValue = "";

            // TanggalPenetapanSanksi
            TanggalPenetapanSanksi.HrefValue = "";
            TanggalPenetapanSanksi.TooltipValue = "";

            // MasaAkhirHukuman
            MasaAkhirHukuman.HrefValue = "";
            MasaAkhirHukuman.TooltipValue = "";

            // StatusAwalSanksi
            StatusAwalSanksi.HrefValue = "";
            StatusAwalSanksi.TooltipValue = "";

            // SisaHariHukuman
            SisaHariHukuman.HrefValue = "";
            SisaHariHukuman.TooltipValue = "";

            // TahunPenetapanSanksi
            TahunPenetapanSanksi.HrefValue = "";
            TahunPenetapanSanksi.TooltipValue = "";

            // BAP
            BAP.HrefValue = "";
            BAP.TooltipValue = "";

            // HasilWorkshop
            HasilWorkshop.HrefValue = "";
            HasilWorkshop.TooltipValue = "";

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

            // id
            id.SetupEditAttributes();
            id.EditValue = id.CurrentValue; // DN
            id.PlaceHolder = RemoveHtml(id.Caption);
            if (!Empty(id.EditValue) && IsNumeric(id.EditValue))
                id.EditValue = FormatNumber(id.EditValue, null);

            // NamaCrew
            NamaCrew.SetupEditAttributes();
            if (!NamaCrew.Raw)
                NamaCrew.CurrentValue = HtmlDecode(NamaCrew.CurrentValue);
            NamaCrew.EditValue = HtmlEncode(NamaCrew.CurrentValue);
            NamaCrew.PlaceHolder = RemoveHtml(NamaCrew.Caption);

            // WarnaCek
            WarnaCek.SetupEditAttributes();
            if (!WarnaCek.Raw)
                WarnaCek.CurrentValue = HtmlDecode(WarnaCek.CurrentValue);
            WarnaCek.EditValue = HtmlEncode(WarnaCek.CurrentValue);
            WarnaCek.PlaceHolder = RemoveHtml(WarnaCek.Caption);

            // NoIjazah
            NoIjazah.SetupEditAttributes();
            if (!NoIjazah.Raw)
                NoIjazah.CurrentValue = HtmlDecode(NoIjazah.CurrentValue);
            NoIjazah.EditValue = HtmlEncode(NoIjazah.CurrentValue);
            NoIjazah.PlaceHolder = RemoveHtml(NoIjazah.Caption);

            // KodePelaut
            KodePelaut.SetupEditAttributes();
            if (!KodePelaut.Raw)
                KodePelaut.CurrentValue = HtmlDecode(KodePelaut.CurrentValue);
            KodePelaut.EditValue = HtmlEncode(KodePelaut.CurrentValue);
            KodePelaut.PlaceHolder = RemoveHtml(KodePelaut.Caption);

            // TempatLahir
            TempatLahir.SetupEditAttributes();
            if (!TempatLahir.Raw)
                TempatLahir.CurrentValue = HtmlDecode(TempatLahir.CurrentValue);
            TempatLahir.EditValue = HtmlEncode(TempatLahir.CurrentValue);
            TempatLahir.PlaceHolder = RemoveHtml(TempatLahir.Caption);

            // TanggalLahir
            TanggalLahir.SetupEditAttributes();
            TanggalLahir.EditValue = FormatDateTime(TanggalLahir.CurrentValue, TanggalLahir.FormatPattern); // DN
            TanggalLahir.PlaceHolder = RemoveHtml(TanggalLahir.Caption);

            // EksKapal
            EksKapal.SetupEditAttributes();
            if (!EksKapal.Raw)
                EksKapal.CurrentValue = HtmlDecode(EksKapal.CurrentValue);
            EksKapal.EditValue = HtmlEncode(EksKapal.CurrentValue);
            EksKapal.PlaceHolder = RemoveHtml(EksKapal.Caption);

            // Rank
            Rank.SetupEditAttributes();
            if (!Rank.Raw)
                Rank.CurrentValue = HtmlDecode(Rank.CurrentValue);
            Rank.EditValue = HtmlEncode(Rank.CurrentValue);
            Rank.PlaceHolder = RemoveHtml(Rank.Caption);

            // PerwiraRating
            PerwiraRating.SetupEditAttributes();
            if (!PerwiraRating.Raw)
                PerwiraRating.CurrentValue = HtmlDecode(PerwiraRating.CurrentValue);
            PerwiraRating.EditValue = HtmlEncode(PerwiraRating.CurrentValue);
            PerwiraRating.PlaceHolder = RemoveHtml(PerwiraRating.Caption);

            // TempatKejadian
            TempatKejadian.SetupEditAttributes();
            if (!TempatKejadian.Raw)
                TempatKejadian.CurrentValue = HtmlDecode(TempatKejadian.CurrentValue);
            TempatKejadian.EditValue = HtmlEncode(TempatKejadian.CurrentValue);
            TempatKejadian.PlaceHolder = RemoveHtml(TempatKejadian.Caption);

            // TanggalKejadian
            TanggalKejadian.SetupEditAttributes();
            if (!TanggalKejadian.Raw)
                TanggalKejadian.CurrentValue = HtmlDecode(TanggalKejadian.CurrentValue);
            TanggalKejadian.EditValue = HtmlEncode(TanggalKejadian.CurrentValue);
            TanggalKejadian.PlaceHolder = RemoveHtml(TanggalKejadian.Caption);

            // Keterangan
            Keterangan.SetupEditAttributes();
            if (!Keterangan.Raw)
                Keterangan.CurrentValue = HtmlDecode(Keterangan.CurrentValue);
            Keterangan.EditValue = HtmlEncode(Keterangan.CurrentValue);
            Keterangan.PlaceHolder = RemoveHtml(Keterangan.Caption);

            // RapatKomite
            RapatKomite.SetupEditAttributes();
            if (!RapatKomite.Raw)
                RapatKomite.CurrentValue = HtmlDecode(RapatKomite.CurrentValue);
            RapatKomite.EditValue = HtmlEncode(RapatKomite.CurrentValue);
            RapatKomite.PlaceHolder = RemoveHtml(RapatKomite.Caption);

            // TanggalPenetapanSanksi
            TanggalPenetapanSanksi.SetupEditAttributes();
            TanggalPenetapanSanksi.EditValue = FormatDateTime(TanggalPenetapanSanksi.CurrentValue, TanggalPenetapanSanksi.FormatPattern); // DN
            TanggalPenetapanSanksi.PlaceHolder = RemoveHtml(TanggalPenetapanSanksi.Caption);

            // MasaAkhirHukuman
            MasaAkhirHukuman.SetupEditAttributes();
            MasaAkhirHukuman.EditValue = FormatDateTime(MasaAkhirHukuman.CurrentValue, MasaAkhirHukuman.FormatPattern); // DN
            MasaAkhirHukuman.PlaceHolder = RemoveHtml(MasaAkhirHukuman.Caption);

            // StatusAwalSanksi
            StatusAwalSanksi.SetupEditAttributes();
            if (!StatusAwalSanksi.Raw)
                StatusAwalSanksi.CurrentValue = HtmlDecode(StatusAwalSanksi.CurrentValue);
            StatusAwalSanksi.EditValue = HtmlEncode(StatusAwalSanksi.CurrentValue);
            StatusAwalSanksi.PlaceHolder = RemoveHtml(StatusAwalSanksi.Caption);

            // SisaHariHukuman
            SisaHariHukuman.SetupEditAttributes();
            if (!SisaHariHukuman.Raw)
                SisaHariHukuman.CurrentValue = HtmlDecode(SisaHariHukuman.CurrentValue);
            SisaHariHukuman.EditValue = HtmlEncode(SisaHariHukuman.CurrentValue);
            SisaHariHukuman.PlaceHolder = RemoveHtml(SisaHariHukuman.Caption);

            // TahunPenetapanSanksi
            TahunPenetapanSanksi.SetupEditAttributes();
            TahunPenetapanSanksi.EditValue = TahunPenetapanSanksi.CurrentValue; // DN
            TahunPenetapanSanksi.PlaceHolder = RemoveHtml(TahunPenetapanSanksi.Caption);
            if (!Empty(TahunPenetapanSanksi.EditValue) && IsNumeric(TahunPenetapanSanksi.EditValue))
                TahunPenetapanSanksi.EditValue = FormatNumber(TahunPenetapanSanksi.EditValue, null);

            // BAP
            BAP.SetupEditAttributes();
            if (!BAP.Raw)
                BAP.CurrentValue = HtmlDecode(BAP.CurrentValue);
            BAP.EditValue = HtmlEncode(BAP.CurrentValue);
            BAP.PlaceHolder = RemoveHtml(BAP.Caption);

            // HasilWorkshop
            HasilWorkshop.SetupEditAttributes();
            if (!HasilWorkshop.Raw)
                HasilWorkshop.CurrentValue = HtmlDecode(HasilWorkshop.CurrentValue);
            HasilWorkshop.EditValue = HtmlEncode(HasilWorkshop.CurrentValue);
            HasilWorkshop.PlaceHolder = RemoveHtml(HasilWorkshop.Caption);

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
                        doc.ExportCaption(id);
                        doc.ExportCaption(NamaCrew);
                        doc.ExportCaption(WarnaCek);
                        doc.ExportCaption(NoIjazah);
                        doc.ExportCaption(KodePelaut);
                        doc.ExportCaption(TempatLahir);
                        doc.ExportCaption(TanggalLahir);
                        doc.ExportCaption(EksKapal);
                        doc.ExportCaption(Rank);
                        doc.ExportCaption(PerwiraRating);
                        doc.ExportCaption(TempatKejadian);
                        doc.ExportCaption(TanggalKejadian);
                        doc.ExportCaption(Keterangan);
                        doc.ExportCaption(RapatKomite);
                        doc.ExportCaption(TanggalPenetapanSanksi);
                        doc.ExportCaption(MasaAkhirHukuman);
                        doc.ExportCaption(StatusAwalSanksi);
                        doc.ExportCaption(SisaHariHukuman);
                        doc.ExportCaption(TahunPenetapanSanksi);
                        doc.ExportCaption(BAP);
                        doc.ExportCaption(HasilWorkshop);
                    } else {
                        doc.ExportCaption(id);
                        doc.ExportCaption(NamaCrew);
                        doc.ExportCaption(WarnaCek);
                        doc.ExportCaption(NoIjazah);
                        doc.ExportCaption(KodePelaut);
                        doc.ExportCaption(TempatLahir);
                        doc.ExportCaption(TanggalLahir);
                        doc.ExportCaption(EksKapal);
                        doc.ExportCaption(Rank);
                        doc.ExportCaption(PerwiraRating);
                        doc.ExportCaption(TempatKejadian);
                        doc.ExportCaption(TanggalKejadian);
                        doc.ExportCaption(Keterangan);
                        doc.ExportCaption(RapatKomite);
                        doc.ExportCaption(TanggalPenetapanSanksi);
                        doc.ExportCaption(MasaAkhirHukuman);
                        doc.ExportCaption(StatusAwalSanksi);
                        doc.ExportCaption(SisaHariHukuman);
                        doc.ExportCaption(TahunPenetapanSanksi);
                        doc.ExportCaption(BAP);
                        doc.ExportCaption(HasilWorkshop);
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
                            await doc.ExportField(id);
                            await doc.ExportField(NamaCrew);
                            await doc.ExportField(WarnaCek);
                            await doc.ExportField(NoIjazah);
                            await doc.ExportField(KodePelaut);
                            await doc.ExportField(TempatLahir);
                            await doc.ExportField(TanggalLahir);
                            await doc.ExportField(EksKapal);
                            await doc.ExportField(Rank);
                            await doc.ExportField(PerwiraRating);
                            await doc.ExportField(TempatKejadian);
                            await doc.ExportField(TanggalKejadian);
                            await doc.ExportField(Keterangan);
                            await doc.ExportField(RapatKomite);
                            await doc.ExportField(TanggalPenetapanSanksi);
                            await doc.ExportField(MasaAkhirHukuman);
                            await doc.ExportField(StatusAwalSanksi);
                            await doc.ExportField(SisaHariHukuman);
                            await doc.ExportField(TahunPenetapanSanksi);
                            await doc.ExportField(BAP);
                            await doc.ExportField(HasilWorkshop);
                        } else {
                            await doc.ExportField(id);
                            await doc.ExportField(NamaCrew);
                            await doc.ExportField(WarnaCek);
                            await doc.ExportField(NoIjazah);
                            await doc.ExportField(KodePelaut);
                            await doc.ExportField(TempatLahir);
                            await doc.ExportField(TanggalLahir);
                            await doc.ExportField(EksKapal);
                            await doc.ExportField(Rank);
                            await doc.ExportField(PerwiraRating);
                            await doc.ExportField(TempatKejadian);
                            await doc.ExportField(TanggalKejadian);
                            await doc.ExportField(Keterangan);
                            await doc.ExportField(RapatKomite);
                            await doc.ExportField(TanggalPenetapanSanksi);
                            await doc.ExportField(MasaAkhirHukuman);
                            await doc.ExportField(StatusAwalSanksi);
                            await doc.ExportField(SisaHariHukuman);
                            await doc.ExportField(TahunPenetapanSanksi);
                            await doc.ExportField(BAP);
                            await doc.ExportField(HasilWorkshop);
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
