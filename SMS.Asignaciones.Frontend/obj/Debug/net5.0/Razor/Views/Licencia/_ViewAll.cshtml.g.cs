#pragma checksum "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1167e7c8299a27b52fd3664df970b018f0d1eb17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Licencia__ViewAll), @"mvc.1.0.view", @"/Views/Licencia/_ViewAll.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1167e7c8299a27b52fd3664df970b018f0d1eb17", @"/Views/Licencia/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"259775e9f1677d871a3a8ad9b8d81a6cea15ba59", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Licencia__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SMS.Asignaciones.Models.Licencia>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return jQueryAjaxDelete(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""sombra-instructivo2"">
    <table id=""tLicencias"" class=""table table-bordered table-dark table-sm table-hover table-responsive-sm"">
        <thead>
            <tr>
                <th style=""width:200px;"">
                    Colaborador
                </th>
                <th>
                    Licencia
                </th>
                <th>
                    Desde
                </th>
                <th>
                    Hasta
                </th>
                <th style=""width:120px;""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 24 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td style=\"vertical-align: middle;\">\r\n                    <b>");
#nullable restore
#line 28 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml"
                  Write(item.Colaborador.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>, ");
#nullable restore
#line 28 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml"
                                                  Write(item.Colaborador.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"vertical-align: middle;\">\r\n                    ");
#nullable restore
#line 31 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml"
               Write(item.TipoLicencia.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"vertical-align: middle;\">\r\n                    ");
#nullable restore
#line 34 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml"
               Write(item.Desde.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"vertical-align: middle;\">\r\n                    ");
#nullable restore
#line 37 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml"
               Write(item.Hasta.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td style=\"text-align:center;\">\r\n                    <a style=\"cursor:pointer;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1377, "\"", 1510, 4);
            WriteAttributeValue("", 1387, "showInPopup(\'", 1387, 13, true);
#nullable restore
#line 41 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml"
WriteAttributeValue("", 1400, Url.Action("_CreateOrEdit","Licencia",new {id=@item.Id},Context.Request.Scheme), 1400, 80, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1480, "\',\'Modificar", 1480, 12, true);
            WriteAttributeValue(" ", 1492, "Licencia\',\'Anio\')", 1493, 18, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-light text-white\" data-bs-toggle=\"tooltip\" data-bs-placement=\"top\" title=\"Modificar\"><i class=\"fa fa-pencil text-dark\"></i></a>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1167e7c8299a27b52fd3664df970b018f0d1eb178050", async() => {
                WriteLiteral(@"
                        <button type=""submit"" class=""btn btn-sm btn-danger text-white"" data-bs-toggle=""tooltip"" data-bs-placement=""top"" title=""Eliminar"">
                            <i class=""fa fa-trash text-white""></i>
                        </button>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml"
                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 51 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Licencia\_ViewAll.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<script>

    $(document).ready(function () {



        $(""#tLicencias"").DataTable({
            ""language"": {
                ""sProcessing"": ""Procesando..."",
                ""sLengthMenu"": ""Mostrar _MENU_ registros"",
                ""sZeroRecords"": ""No se encontraron resultados"",
                ""sEmptyTable"": ""Ningún dato disponible en esta tabla"",
                ""sInfo"": ""Mostrando  _END_ / _TOTAL_ registros"",
                ""sInfoEmpty"": ""Sin datos"",
                ""sInfoFiltered"": ""(filtrado de un total de _MAX_ registros)"",
                ""sInfoPostFix"": """",
                ""sSearch"": ""Buscar:"",
                ""sUrl"": """",
                ""sInfoThousands"": "","",
                ""sLoadingRecords"": ""Cargando..."",
                ""oPaginate"": {
                    ""sFirst"": ""Primero"",
                    ""sLast"": ""Último"",
                    ""sNext"": ""Siguiente"",
                    ""sPrevious"": ""Anterior""
                },
         ");
            WriteLiteral(@"       ""oAria"": {
                    ""sSortAscending"": "": Activar para ordenar la columna de manera ascendente"",
                    ""sSortDescending"": "": Activar para ordenar la columna de manera descendente""
                },
            },
            ""pagingType"": ""numbers""
        });



    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SMS.Asignaciones.Models.Licencia>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
