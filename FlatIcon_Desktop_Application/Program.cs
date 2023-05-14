using FlatIcon_Desktop_Application.Managers.Authentication;
using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Managers.Styles;
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

        static void Main(string[] args)
        {
            authenticationManager = new AuthenticationManager(API_KEY);
            stylesManager = new StylesManager();
            Console.WriteLine(authenticationManager.authenticationToken);
            Console.ReadKey();
        }
    }
}
