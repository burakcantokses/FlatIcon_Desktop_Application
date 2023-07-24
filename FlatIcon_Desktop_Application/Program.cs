using FlatIcon_Desktop_Application.Managers.Authentication;
using FlatIcon_Desktop_Application.Managers.Items.Download;
using FlatIcon_Desktop_Application.Managers.Items.Icon;
using FlatIcon_Desktop_Application.Managers.Items.Pack;
using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Managers.Search;
using FlatIcon_Desktop_Application.Managers.Styles;
using FlatIcon_Desktop_Application.Managers.Tags;
using FlatIcon_Desktop_Application.Schemas.Icon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application
{
    public class Program
    {
        public static string API_KEY = "bcUkhpRaAwcwQUpLXF4G4A8J3RDkyu5GlishbaKCqH50exKF";
        public static string MAIN_URL = "https://api.flaticon.com/";
        public static string VERSION = "v3";

        public static AuthenticationManager authenticationManager;
        public static StylesManager stylesManager;
        public static TagsManager tagsManager;
        public static StyleManager styleManager;
        public static IconManager iconManager;
        public static PackManager packManager;
        public static DownloadManager downloadManager;
        public static SearchIconManager searchIconManager;
        public static SearchPackManager searchPackManager;

        public static async Task Main(string[] args)
        {
            authenticationManager = new AuthenticationManager(API_KEY);
            stylesManager = new StylesManager();
            tagsManager = new TagsManager();
            styleManager = new StyleManager(5);
            iconManager = new IconManager(5);
            packManager = new PackManager(110841);
            downloadManager = new DownloadManager(31, "png");
            searchIconManager = new SearchIconManager("king");
            searchPackManager = new SearchPackManager("Game");
            Console.WriteLine(searchPackManager.packsResponse.data[0].family_name);
            // test area
            Console.WriteLine();
            Console.WriteLine(authenticationManager.authenticationToken);
            Console.ReadKey();
        }
    }
}
