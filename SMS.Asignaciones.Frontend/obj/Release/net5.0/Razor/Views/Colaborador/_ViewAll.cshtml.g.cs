#pragma checksum "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac536944fcb616d4bd9aa3604655c927fd53355d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Colaborador__ViewAll), @"mvc.1.0.view", @"/Views/Colaborador/_ViewAll.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac536944fcb616d4bd9aa3604655c927fd53355d", @"/Views/Colaborador/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"259775e9f1677d871a3a8ad9b8d81a6cea15ba59", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Colaborador__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SMS.Asignaciones.Models.Colaborador>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return jQueryAjaxDelete(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ResetPassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return jQueryAjaxResetPassword(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
    <table id=""tColaboradores"" class=""table table-bordered table-dark table-sm table-hover table-responsive-sm"">
        <thead>
            <tr>
                <th style=""width:30px;"">

                </th>
                <th>
                    ");
#nullable restore
#line 12 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 15 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.Legajo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Lider\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 21 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
               Write(Html.DisplayNameFor(model => model.Equipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Tipo Contrato\r\n                </th>\r\n                <th style=\"width:120px;\"></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 30 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td style=\"vertical-align: middle; text-align:center;\">\r\n");
#nullable restore
#line 34 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
                      
                        var base64 = Convert.ToBase64String(item.Foto);
                        var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <img class=\"avatar-grid\"");
            BeginWriteAttribute("src", " src=\"", 1308, "\"", 1321, 1);
#nullable restore
#line 39 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
WriteAttributeValue("", 1314, imgSrc, 1314, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                </td>\r\n\r\n\r\n                <td style=\"vertical-align: middle;\">\r\n                    ");
#nullable restore
#line 45 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"vertical-align: middle;\">\r\n                    ");
#nullable restore
#line 48 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Legajo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"vertical-align: middle;\">\r\n                    ");
#nullable restore
#line 51 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.NombreLider));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"vertical-align: middle;\">\r\n                    ");
#nullable restore
#line 54 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
               Write(Html.DisplayFor(modelItem => item.Equipo.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"vertical-align: middle; text-align: center;\">\r\n");
#nullable restore
#line 57 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
                       if (item.Proveedor.Nombre.Contains("SMS"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\'badge bg-danger text-white\'>");
#nullable restore
#line 59 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
                                                                Write(item.Proveedor.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 60 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
                        }
                        else if (item.Proveedor.Nombre.Contains("Mono"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\'badge bg-warning text-dark\'>");
#nullable restore
#line 63 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
                                                                Write(item.Proveedor.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 64 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\'badge bg-info text-dark\'>");
#nullable restore
#line 67 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
                                                             Write(item.Proveedor.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 68 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
                        }

                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n\r\n                <td style=\"text-align:center;\">\r\n                    <a style=\"cursor:pointer;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2789, "\"", 2920, 3);
            WriteAttributeValue("", 2799, "showInPopupLg(\'", 2799, 15, true);
#nullable restore
#line 74 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
WriteAttributeValue("", 2814, Url.Action("_CreateOrEdit","Colaborador",new {id=@item.Id},Context.Request.Scheme), 2814, 83, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2897, "\',\'Modificar\',\'Legajo\')", 2897, 23, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-light text-white\" data-bs-toggle=\"tooltip\" data-bs-placement=\"top\" title=\"Modificar\"><i class=\"fa fa-pencil text-dark\"></i></a>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac536944fcb616d4bd9aa3604655c927fd53355d12863", async() => {
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
#line 75 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
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
            WriteLiteral("\r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac536944fcb616d4bd9aa3604655c927fd53355d15786", async() => {
                WriteLiteral(@"
                        <button type=""submit"" class=""btn btn-sm btn-light text-white"" data-bs-toggle=""tooltip"" data-bs-placement=""top"" title=""Reset Password"">
                            <i class=""fa fa-key text-dark""></i>
                        </button>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 81 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                </td>\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 91 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Colaborador\_ViewAll.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<script>

    $(document).ready(function () {



        $(""#tColaboradores"").DataTable({
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
            WriteLiteral(@"           ""oAria"": {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SMS.Asignaciones.Models.Colaborador>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
