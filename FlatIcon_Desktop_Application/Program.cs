﻿using FlatIcon_Desktop_Application.Managers.Authentication;
using FlatIcon_Desktop_Application.Managers.Request;
using FlatIcon_Desktop_Application.Managers.Styles;
using FlatIcon_Desktop_Application.Managers.Tags;
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

        static void Main(string[] args)
        {
            authenticationManager = new AuthenticationManager(API_KEY);
            stylesManager = new StylesManager();
            tagsManager = new TagsManager();
            styleManager = new StyleManager(5);
            Console.WriteLine(styleManager.style.data.family_name);
            Console.WriteLine(authenticationManager.authenticationToken);
            Console.ReadKey();
        }
    }
}
