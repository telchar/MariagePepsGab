using System;
using System.Collections.Generic;
using System.Web;

namespace Mariage.Models
{
    public class BaseModel
    {
        public static Boolean Private { 
            get 
            {                
                if (HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session["private"] == null)
                    {
                        HttpContext.Current.Session.Add("private", false);
                    }
                    return (bool)HttpContext.Current.Session["private"];
                }
                return false;
            }  
        }
        public static Dictionary<string, string> Menu
        {
            get
            {
                var menu = new Dictionary<string, string>
                    {
                        {"Accueil", "Accueil"},
                        {"Media", "Photos"},
                        {"Liste", "Liste de mariage"},
                        {"Infos", "Informations"},
                        {"Contact", "Contact"}
                    };
                if(Private)
                    menu.Add("Logements", "Logements");
                return menu;
            }
        }
        public string Selected { get; set; }
        public string ConfirmMessage { get; set; }
    }
}