#pragma checksum "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Proveedor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "958026a51c433bc548ef480800b39b8e3c66bd91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Proveedor_Index), @"mvc.1.0.view", @"/Views/Proveedor/Index.cshtml")]
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
#line 1 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\_ViewImports.cshtml"
using SMS.Asignaciones.Frontend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\_ViewImports.cshtml"
using SMS.Asignaciones.Frontend.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"958026a51c433bc548ef480800b39b8e3c66bd91", @"/Views/Proveedor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"259775e9f1677d871a3a8ad9b8d81a6cea15ba59", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Proveedor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<SMS.Asignaciones.Models.Proveedor>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Proveedor\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />

<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""header-instructivo bg-light sombra-instructivo"">
            <i class=""fa fa-circle text-danger""></i> <strong>Proveedores</strong>
        </div>
    </div>
</div>

<br />
<div class=""row"">
    <div class=""col-lg-12"">

        <div class=""mb-2"">
            <a");
            BeginWriteAttribute("onclick", " onclick=\"", 432, "\"", 548, 3);
            WriteAttributeValue("", 442, "showInPopup(\'", 442, 13, true);
#nullable restore
#line 21 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Proveedor\Index.cshtml"
WriteAttributeValue("", 455, Url.Action("_CreateOrEdit","Proveedor",new {id=0},Context.Request.Scheme), 455, 74, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 529, "\',\'Nuevo\',\'Nombre\')", 529, 19, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-danger text-white\" style=\"cursor:pointer;\">\r\n                <i class=\"fa fa-plus text-white\"></i> Nuevo\r\n            </a>\r\n        </div>\r\n\r\n        <div id=\"view-all\">\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n\r\n        $(document).ready(function () {\r\n            $(\'#view-all\').load(\'");
#nullable restore
#line 38 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Proveedor\Index.cshtml"
                            Write(Url.Action("_ViewAll", "Proveedor"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n        });\r\n\r\n    </script>\r\n\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<SMS.Asignaciones.Models.Proveedor>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
