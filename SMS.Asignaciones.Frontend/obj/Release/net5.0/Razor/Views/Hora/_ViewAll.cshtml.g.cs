#pragma checksum "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fd77da72668d678c69f5f3781dd7286d6bb4166"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hora__ViewAll), @"mvc.1.0.view", @"/Views/Hora/_ViewAll.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fd77da72668d678c69f5f3781dd7286d6bb4166", @"/Views/Hora/_ViewAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"259775e9f1677d871a3a8ad9b8d81a6cea15ba59", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Hora__ViewAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SMS.Asignaciones.Frontend.Models.HorasViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 5 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-sm-6 col-md-4 col-lg-3\" id=\"margin-card\">\r\n            <div");
            BeginWriteAttribute("class", " class=\"", 216, "\"", 296, 3);
            WriteAttributeValue("", 224, "card", 224, 4, true);
            WriteAttributeValue(" ", 228, "sombra-instructivo", 229, 19, true);
#nullable restore
#line 8 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
WriteAttributeValue(" ", 247, item.HorasPendientes <= 0 ? "bg-success" : "", 248, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"avatar-container\">\r\n");
#nullable restore
#line 10 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                      
                        var base64 = Convert.ToBase64String(item.Foto);
                        var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <img class=\"avatar-horas\"");
            BeginWriteAttribute("src", " src=\"", 605, "\"", 618, 1);
#nullable restore
#line 15 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
WriteAttributeValue("", 611, imgSrc, 611, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </div>\r\n\r\n                <b>");
#nullable restore
#line 18 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
              Write(item.NombreColaborador);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                ");
#nullable restore
#line 19 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
           Write(item.Legajo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"badge badge-light\">");
#nullable restore
#line 20 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                          Write(item.Equipo);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 20 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                        Write(!string.IsNullOrEmpty(item.SubEquipo) ? " / " + item.SubEquipo : "");

#line default
#line hidden
#nullable disable
            WriteLiteral("  </div>\r\n\r\n");
#nullable restore
#line 22 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                   if (item.TipoRegistro.Contains("SMS"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\'badge bg-danger text-white\'>\r\n                            ");
#nullable restore
#line 25 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                       Write(item.TipoRegistro);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                               if (item.Lider)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"fa fa-star text-warning\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Líder\"></i> ");
#nullable restore
#line 27 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                                                                                   } 

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                               if (item.LiderSubEquipo)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"fa fa-star-half-o text-warning\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Líder de un Sub Equipo\"></i> ");
#nullable restore
#line 29 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                                                                                                           } 

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </span>\r\n");
#nullable restore
#line 31 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                }
                                else if (item.TipoRegistro.Contains("Mono"))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\'badge bg-warning text-dark\'>\r\n                            ");
#nullable restore
#line 35 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                       Write(item.TipoRegistro);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 36 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                               if (item.Lider)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"fa fa-star text-dark\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Líder\"></i> ");
#nullable restore
#line 37 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                                                                                } 

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                               if (item.LiderSubEquipo)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"fa fa-star-half-o text-dark\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Líder de un Sub Equipo\"></i> ");
#nullable restore
#line 39 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                                                                                                        } 

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </span>\r\n");
#nullable restore
#line 41 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\'badge bg-info text-dark\'>\r\n                            ");
#nullable restore
#line 45 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                       Write(item.TipoRegistro);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 46 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                               if (item.Lider)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"fa fa-star text-dark\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Líder\"></i> ");
#nullable restore
#line 47 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                                                                                } 

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                               if (item.LiderSubEquipo)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"fa fa-star-half-o text-dark\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Líder de un Sub Equipo\"></i> ");
#nullable restore
#line 49 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                                                                                                        } 

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </span>\r\n");
#nullable restore
#line 51 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                }

                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <span class=\"text-dark\" style=\"text-align:left; padding-left:5px; font-size:11px;\">\r\n                    <i class=\"fa fa-clock-o text-danger\"></i> Horas mes: ");
#nullable restore
#line 56 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                            if (!item.HorasVariables)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <b> ");
#nullable restore
#line 57 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                         Write(item.HorasMes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> ");
#nullable restore
#line 57 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                 }
                        else {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\'badge bg-info text-white\'>Variable</span> ");
#nullable restore
#line 58 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                                      } 

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </span>\r\n                <span class=\"text-dark\" style=\"text-align: left; padding-left: 5px; font-size: 11px;\">\r\n                    <i class=\"fa fa-clock-o text-info\"></i> Horas Cargadas: <b> ");
#nullable restore
#line 61 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                           Write(item.HorasCargadas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                </span>\r\n                <span class=\"text-dark\" style=\"text-align: left; padding-left: 5px; font-size: 11px;\">\r\n                    <i class=\"fa fa-clock-o text-dark\"></i> Horas Pendientes: ");
#nullable restore
#line 64 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                                 if (!item.HorasVariables)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <b>");
#nullable restore
#line 66 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                           Write(item.HorasPendientes > 0 ? item.HorasPendientes : 0);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n");
#nullable restore
#line 67 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\'badge bg-info text-white\'>Variable</span>\r\n");
#nullable restore
#line 71 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                        } 

#line default
#line hidden
#nullable disable
            WriteLiteral("                </span>\r\n                <span class=\"text-dark\" style=\"text-align: left; padding-left: 5px; font-size: 11px;\">\r\n                    <i class=\"fa fa-clock-o text-dark\"></i> Horas Extra:  <b>");
#nullable restore
#line 74 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                        Write(item.HorasExtra);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                </span>\r\n                <span class=\"text-dark\" style=\"text-align: left; padding-left: 5px; font-size: 11px;\">\r\n                    <i class=\"fa fa-clock-o text-dark\"></i> D&iacute;as Licencia:  <b>");
#nullable restore
#line 77 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                                                                                 Write(item.DiasLicencia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                </span>\r\n\r\n                <div class=\"btn-group\" role=\"group\" aria-label=\"acciones\">\r\n                    <button class=\"btn btn-light btn-sm\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4661, "\"", 4898, 4);
            WriteAttributeValue("", 4671, "showInPopup(\'", 4671, 13, true);
#nullable restore
#line 81 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
WriteAttributeValue("", 4684, Url.Action("_VerCarga","Hora",new {colaboradorId=@item.ColaboradorId, anio=@item.Anio, mes= @item.Mes, colaboradorIdSeleccionado=item.ColaboradorIdSeleccionado},Context.Request.Scheme), 4684, 185, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4869, "\',\'Horas", 4869, 8, true);
            WriteAttributeValue(" ", 4877, "Asignadas\',\'Nombre\')", 4878, 21, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fa fa-eye text-dark\"></i> Ver\r\n                    </button>\r\n\r\n");
#nullable restore
#line 85 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                     if (item.HorasPendientes <= 0 && !item.HorasVariables)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-success\">\r\n                            <i class=\"fa fa-smile-o fa-2x bg-success text-white\"></i> Cargado\r\n                        </span>\r\n");
#nullable restore
#line 90 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button");
            BeginWriteAttribute("class", " class=\"", 5391, "\"", 5465, 4);
            WriteAttributeValue("", 5399, "btn", 5399, 3, true);
            WriteAttributeValue(" ", 5402, "btn-light", 5403, 10, true);
            WriteAttributeValue(" ", 5412, "btn-sm", 5413, 7, true);
#nullable restore
#line 93 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
WriteAttributeValue(" ", 5419, item.HorasPendientes == 0 ? "ocultar" : "", 5420, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 5466, "\"", 5705, 4);
            WriteAttributeValue("", 5476, "showInPopup(\'", 5476, 13, true);
#nullable restore
#line 93 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
WriteAttributeValue("", 5489, Url.Action("_CargaHoras","Hora",new {colaboradorId=@item.ColaboradorId, anio=@item.Anio, mes= item.Mes, colaboradorIdSeleccionado=item.ColaboradorIdSeleccionado},Context.Request.Scheme), 5489, 186, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5675, "\',\'Cargar", 5675, 9, true);
            WriteAttributeValue(" ", 5684, "Horas\',\'ProyectoId\')", 5685, 21, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <i class=\"fa fa-calendar-check-o text-dark\"></i> Cargar\r\n                        </button>\r\n");
#nullable restore
#line 96 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n\r\n\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 104 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Hora\_ViewAll.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SMS.Asignaciones.Frontend.Models.HorasViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591