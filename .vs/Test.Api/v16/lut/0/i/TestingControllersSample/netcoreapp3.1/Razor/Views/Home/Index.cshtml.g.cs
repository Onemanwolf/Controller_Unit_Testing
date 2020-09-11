#pragma checksum "C:\Controller_Unit_Test\src\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51d679038b83ba951c1db398960705c0df6ec67c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Controller_Unit_Test\src\Views\Home\Index.cshtml"
using TestingControllersSample.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51d679038b83ba951c1db398960705c0df6ec67c", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StormSessionViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Controller_Unit_Test\src\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Brainstormer";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Brainstorm Sessions</h2>\r\n<div class=\"row\">\r\n    <div class=\"col-md-9\">\r\n");
#nullable restore
#line 12 "C:\Controller_Unit_Test\src\Views\Home\Index.cshtml"
         foreach (var storm in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"panel panel-default\">\r\n                <div class=\"panel-heading\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 401, "\"", 458, 1);
#nullable restore
#line 16 "C:\Controller_Unit_Test\src\Views\Home\Index.cshtml"
WriteAttributeValue("", 408, Url.Action("Index","Session", new {id=@storm.Id}), 408, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 16 "C:\Controller_Unit_Test\src\Views\Home\Index.cshtml"
                                                                            Write(storm.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a> - ");
#nullable restore
#line 16 "C:\Controller_Unit_Test\src\Views\Home\Index.cshtml"
                                                                                              Write(storm.DateCreated.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"panel-body\">\r\n                    ");
#nullable restore
#line 19 "C:\Controller_Unit_Test\src\Views\Home\Index.cshtml"
               Write(storm.IdeaCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ideas\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 22 "C:\Controller_Unit_Test\src\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <div class=""col-md-3"">
        <div class=""panel panel-primary"">
            <div class=""panel-heading"">
                Add New Session
            </div>
            <div class=""panel-body"">
                <form method=""post"" asp-controller=""Home"" asp-action=""Index"">
                    <fieldset class=""form-group"">
                        <label for=""sessionName"">New Session Name</label>
                        <input type=""text"" class=""form-control"" id=""sessionName"" name=""SessionName"" placeholder=""Name"" required />
                    </fieldset>
                    <input type=""submit"" value=""Save"" id=""SaveButton"" name=""SaveButton"" class=""btn btn-primary"" />
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StormSessionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
