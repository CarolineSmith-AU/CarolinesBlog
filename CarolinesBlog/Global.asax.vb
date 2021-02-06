Imports System.Web.Optimization
Imports System.Web.Routing

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub

    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.MapPageRoute("Home Page",
            "", "~/HomePage.aspx")
        routes.MapPageRoute("All Blogs",
            "blog", "~/app/aspx/BlogListView.aspx")
        routes.MapPageRoute("Blog Post",
            "blog/{id}/{title}", "~/app/aspx/BlogPostTemplate.aspx")
        routes.MapPageRoute("Contact Page",
            "contact", "~/app/aspx/ContactPage.aspx")
        routes.MapPageRoute("About Page",
            "about", "~/app/aspx/About.aspx")
        routes.MapPageRoute("Unsubscribe Page",
            "unsubscribe", "~/app/aspx/Unsubscribe.aspx")
    End Sub
End Class
