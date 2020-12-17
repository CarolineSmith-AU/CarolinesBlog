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
        routes.MapPageRoute("All Blogs",
            "blog", "~/BlogListView.aspx")
        routes.MapPageRoute("Hair Blog",
            "hair-blog", "~/BlogListView.aspx")
        routes.MapPageRoute("Fashion Blog",
            "fashion-blog", "~/BlogListView.aspx")
        routes.MapPageRoute("Thoughts Blog",
            "thoughts-blog", "~/BlogListView.aspx")
        routes.MapPageRoute("Hair Blog Post",
            "hair-blog/{id}/{title}", "~/BlogPostTemplate.aspx")
        routes.MapPageRoute("Fashion Blog Post",
            "fashion-blog/{id}/{title}", "~/BlogPostTemplate.aspx")
        routes.MapPageRoute("Thoughts Blog Post",
            "thoughts-blog/{id}/{title}", "~/BlogPostTemplate.aspx")
        routes.MapPageRoute("Contact Page",
            "contact", "~/Contact.aspx")
        routes.MapPageRoute("About Page",
            "about", "~/About.aspx")
    End Sub
End Class
