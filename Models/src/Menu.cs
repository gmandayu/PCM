namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// Menu class
    /// </summary>
    public class Menu : MenuBase
    {
        // Constructor
        public Menu(object menuId, bool isRoot = false, bool isNavbar = false, string? languageFolder = null) : base(menuId, isRoot, isNavbar, languageFolder)
        {
        }

        // Render
        public override async Task<string> ToJson()
        {
            MenuRendering();
            return await base.ToJson();
        }

        public override void MenuRendering() {
            // Change menu items here
            if (CurrentUserLevel() == "0")
            {
                MenuItem? MI = null;
                var menuText = (CurrentLanguage == "en-US") ? "Registration (560)" : "Registrasi (560)";
                this.FindItemByText(menuText, out MI);
                var rs = ExecuteRow("SELECT TOP 1 ID, EmployeeStatus FROM MTCrew WHERE MTUserID = " + CurrentUserID());
                if (MI != null && rs["ID"] != null && rs["EmployeeStatus"] != null)
                {
                    if (rs["EmployeeStatus"].ToString() == "Candidate - Draft")
                    {
                        MI.Url = "CrewPersonalDataForAdminEdit/" + rs["ID"].ToString();
                    }
                    else
                    {
                        MI.Url = "CrewPersonalDataForAdminViewModeView/" + rs["ID"].ToString() + "?showdetail=";
                    }
                }
            }
            else
            {
                MenuItem? MI = null;
                var menuText = (CurrentLanguage == "en-US") ? "Home Page" : "Beranda";
                this.FindItemByText(menuText, out MI);
                if (MI != null)
                {
                    MI.Url = "HomePageAdminPde";
                }
                MI = null;
                menuText = (CurrentLanguage == "en-US") ? "Crew Notification" : "Notifikasi Kru";
                this.FindItemByText(menuText, out MI);
                if (MI != null)
                {
                    MI.Allowed = false;
                }
            }
        }
    }
} // End Partial class
