using System.Web.Mvc;
using System.Web.Routing;

namespace Mariage
{
    // Remarque : pour obtenir des instructions sur l'activation du mode classique IIS6 ou IIS7, 
    // visitez http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ico");
            routes.IgnoreRoute("{resource}.txt");
            routes.MapRoute("Construct",
                            "{*all}",
                            new {controller = "Mariage", action = "EnCoursDeDeveloppement"});
            routes.MapRoute(
                "Liste",
                "Liste",
                new { controller = "Mariage", action = "Liste" });
            routes.MapRoute(
                "Media",
                "Media/{id}", 
                new {controller = "Mariage", action = "Media", id = UrlParameter.Optional});
            routes.MapRoute(
                "Contact",
                "Contact",
                new { controller = "Mariage", action = "Contact" });
            routes.MapRoute(
                "Infos",
                "Infos",
                new { controller = "Mariage", action = "Infos" });
            routes.MapRoute(
                "Invite", 
                "Invite", 
                new {controller = "Mariage", action = "Invite"});
            routes.MapRoute(
                "Accueil", // Nom d'itinéraire
                "", // URL avec des paramètres
                new { controller = "Mariage", action = "Index" } // Paramètres par défaut
            );
            routes.MapRoute(
                "Default", // Nom d'itinéraire
                "{controller}/{action}/{id}", // URL avec des paramètres
                new { controller = "Mariage", action = "Index", id = UrlParameter.Optional } // Paramètres par défaut
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}