using FlatIcon_Desktop_Application.Managers.Authentication;
using FlatIcon_Desktop_Application.Managers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatIcon_Desktop_Application
{
    public class Program
    {
        public static string API_KEY = "";

        public static AuthenticationManager authenticationManager;

        static void Main(string[] args)
        {
            authenticationManager = new AuthenticationManager(API_KEY);
        }
    }
}
