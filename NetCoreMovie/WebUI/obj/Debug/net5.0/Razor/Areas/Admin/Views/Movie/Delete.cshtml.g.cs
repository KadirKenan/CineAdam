#pragma checksum "C:\Users\kadir\Desktop\12-NetCoreMovieTheater\NetCoreMovie\WebUI\Areas\Admin\Views\Movie\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f20e95f82fdfd4d036f380513f14114a6478d2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Movie_Delete), @"mvc.1.0.view", @"/Areas/Admin/Views/Movie/Delete.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f20e95f82fdfd4d036f380513f14114a6478d2d", @"/Areas/Admin/Views/Movie/Delete.cshtml")]
    public class Areas_Admin_Views_Movie_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataAccess.Entity.Movie>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\kadir\Desktop\12-NetCoreMovieTheater\NetCoreMovie\WebUI\Areas\Admin\Views\Movie\Delete.cshtml"
  
    ViewBag.Title = "Delete";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"panel\">\r\n                <div class=\"alert alert-danger\">\r\n                    <form method=\"post\">\r\n                        <h2> ");
#nullable restore
#line 12 "C:\Users\kadir\Desktop\12-NetCoreMovieTheater\NetCoreMovie\WebUI\Areas\Admin\Views\Movie\Delete.cshtml"
                        Write(Model.MovieName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2><br />
                        <span>Silmek istediğinize emin misiniz?</span><br />
                        <button type=""submit"" class=""btn btn-danger"">Evet Sil</button>
                        <a href=""/Admin/Movie"" class=""btn"">İptal</a>
                    </form>
                </div>
            </div>
        </div>
</div>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataAccess.Entity.Movie> Html { get; private set; }
    }
}
#pragma warning restore 1591