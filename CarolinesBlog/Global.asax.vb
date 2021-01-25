﻿Imports System.Web.Optimization
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
            "", "~/app/aspx/HomePage.aspx")
        routes.MapPageRoute("All Blogs",
            "blog", "~/app/aspx/BlogListView.aspx")
        routes.MapPageRoute("Hair Blog",
            "hair-blog", "~/app/aspx/BlogListView.aspx")
        routes.MapPageRoute("Fashion Blog",
            "fashion-blog", "~/app/aspx/BlogListView.aspx")
        routes.MapPageRoute("Thoughts Blog",
            "thoughts-blog", "~/app/aspx/BlogListView.aspx")
        routes.MapPageRoute("Hair Blog Post",
            "hair-blog/{id}/{title}", "~/app/aspx/BlogPostTemplate.aspx")
        routes.MapPageRoute("Fashion Blog Post",
            "fashion-blog/{id}/{title}", "~/app/aspx/BlogPostTemplate.aspx")
        routes.MapPageRoute("Thoughts Blog Post",
            "thoughts-blog/{id}/{title}", "~/app/aspx/BlogPostTemplate.aspx")
        routes.MapPageRoute("Contact Page",
            "contact", "~/app/aspx/ContactPage.aspx")
        routes.MapPageRoute("About Page",
            "about", "~/About.aspx")
    End Sub
End Class
