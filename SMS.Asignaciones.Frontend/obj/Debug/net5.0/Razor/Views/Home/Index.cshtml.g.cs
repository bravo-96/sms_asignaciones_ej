#pragma checksum "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b67b927f54e72939181867a435a6c261585d3155"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b67b927f54e72939181867a435a6c261585d3155", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"259775e9f1677d871a3a8ad9b8d81a6cea15ba59", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SMS.Asignaciones.Frontend.Models.DashboardViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"grey-bg container-fluid\">\r\n\r\n    <br />\r\n\r\n    <button class=\"btn btn-light btn-sm pull-right\"");
            BeginWriteAttribute("onclick", " onclick=\"", 168, "\"", 229, 3);
            WriteAttributeValue("", 178, "showInPopup(\'", 178, 13, true);
#nullable restore
#line 7 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
WriteAttributeValue("", 191, Url.Action("_ModificaDatos","Home"), 191, 36, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 227, "\')", 227, 2, true);
            EndWriteAttribute();
            WriteLiteral(@">
        <i class=""fa fa-user-circle text-dark""></i> Modificar Datos
    </button>

    <br />


    <section id=""minimal-statistics"">
        <div class=""row"">
            <div class=""col-12 mt-3 mb-1"">
                <h4 class=""text-uppercase"">Informaci&oacute;n general</h4>
                <p>Datos actualizados al mes en curso.</p>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-xl-3 col-sm-6 col-12"">
                <div class=""card sombra-instructivo"">
                    <div class=""card-content"">
                        <div class=""card-body"">
                            <div class=""media d-flex"">
                                <div class=""align-self-center"">
                                    <i class=""fa fa-calendar fa-2x text-danger font-large-2 float-left""></i>
                                </div>
                                <div class=""media-body text-right"">
                                    <h3>");
#nullable restore
#line 31 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
                                   Write(Model.MesActual);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                    <span>Mes actual</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-sm-6 col-12"">
                <div class=""card sombra-instructivo"">
                    <div class=""card-content"">
                        <div class=""card-body"">
                            <div class=""media d-flex"">
                                <div class=""align-self-center"">
                                    <i class=""fa fa-briefcase fa-2x text-warning font-large-2 float-left""></i>
                                </div>
                                <div class=""media-body text-right"">
                                    <h3>");
#nullable restore
#line 48 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
                                   Write(Model.DiasLaborales);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                    <span>D&iacute;as laborales</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-sm-6 col-12"">
                <div class=""card sombra-instructivo"">
                    <div class=""card-content"">
                        <div class=""card-body"">
                            <div class=""media d-flex"">
                                <div class=""align-self-center"">
                                    <i class=""fa fa-globe fa-2x text-primary font-large-2 float-left""></i>
                                </div>
                                <div class=""media-body text-right"">
                                    <h3>");
#nullable restore
#line 65 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
                                   Write(Model.Feriados);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                    <span>Feriados</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-sm-6 col-12"">
                <div class=""card sombra-instructivo"">
                    <div class=""card-content"">
                        <div class=""card-body"">
                            <div class=""media d-flex"">
                                <div class=""align-self-center"">
                                    <i class=""fa fa-clock-o fa-2x text-success font-large-2 float-left""></i>
                                </div>
                                <div class=""media-body text-right"">
                                    <h3>");
#nullable restore
#line 82 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
                                   Write(Model.HorasMes);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                    <span>Horas mes</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>

    <br />

    <section id=""stats-subtitle"">
        <div class=""row"">
            <div class=""col-12 mt-3 mb-1"">
                <h4 class=""text-uppercase"">Informaci&oacute;n personalizada</h4>
                <p>Informaci&oacute;n particular del usuario.</p>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-xl-3 col-sm-6 col-12"">
                <div class=""card sombra-instructivo"">
                    <div class=""card-content"">
                        <div class=""card-body"">
                            <div class=""media d-flex"">
                                <div class=""align-self-center"">
                                    <i class=""fa fa-user fa-2x text-danger font-larg");
            WriteLiteral("e-2 float-left\"></i>\r\n                                </div>\r\n                                <div class=\"media-body text-right\">\r\n                                    <h3>");
#nullable restore
#line 113 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
                                   Write(Model.Equipo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                    <span>Miembro del Equipo</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-xl-3 col-sm-6 col-12"">
                <div class=""card sombra-instructivo"">
                    <div class=""card-content"">
                        <div class=""card-body"">
                            <div class=""media d-flex"">
                                <div class=""align-self-center"">
                                    <i class=""fa fa-shield fa-2x text-warning font-large-2 float-left""></i>
                                </div>
                                <div class=""media-body text-right"">
                                    <h3>");
#nullable restore
#line 130 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
                                   Write(Model.Rol);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                    <span>Rol</span>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n");
#nullable restore
#line 139 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
             if (!User.IsInRole("Colaborador"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-xl-3 col-sm-6 col-12"">
                    <div class=""card sombra-instructivo"">
                        <div class=""card-content"">
                            <div class=""card-body"">
                                <div class=""media d-flex"">
                                    <div class=""align-self-center"">
                                        <i class=""fa fa-group fa-2x text-primary font-large-2 float-left""></i>
                                    </div>
                                    <div class=""media-body text-right"">
                                        <h3>");
#nullable restore
#line 150 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
                                       Write(Model.Colaboradores);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                        <span>Colaboradores</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 158 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col-xl-3 col-sm-6 col-12"">
                <div class=""card sombra-instructivo"">
                    <div class=""card-content"">
                        <div class=""card-body"">
                            <div class=""media d-flex"">
                                <div class=""align-self-center"">
                                    <i class=""fa fa-clock-o fa-2x text-success font-large-2 float-left""></i>
                                </div>
                                <div class=""media-body text-right"">
                                    <h3>");
#nullable restore
#line 168 "C:\SMS.Asignaciones\SMS.Asignaciones\SMS.Asignaciones.Frontend\Views\Home\Index.cshtml"
                                   Write(Model.HorasPendientesCarga);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Hs</h3>
                                    <span>Faltan cargar</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>




</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SMS.Asignaciones.Frontend.Models.DashboardViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
