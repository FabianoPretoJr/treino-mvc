#pragma checksum "C:\Users\FOEU\My Private Documents\Projetos\treino-mvc\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6a9e1ad9454d3ea24af3935468e692f6585bad9"
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
#line 1 "C:\Users\FOEU\My Private Documents\Projetos\treino-mvc\Views\_ViewImports.cshtml"
using treino_mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FOEU\My Private Documents\Projetos\treino-mvc\Views\_ViewImports.cshtml"
using treino_mvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6a9e1ad9454d3ea24af3935468e692f6585bad9", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bd3ed43cd04b40809c668b1b91404eb2d41a2cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<treino_mvc.Models.Curso>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\FOEU\My Private Documents\Projetos\treino-mvc\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"title-curso\">Cursos para treinamento dos novos Starters</h1>\r\n    <div class=\"container-curso\">\r\n");
#nullable restore
#line 10 "C:\Users\FOEU\My Private Documents\Projetos\treino-mvc\Views\Home\Index.cshtml"
         foreach (var curso in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card-curso\">\r\n                <strong>Curso:</strong>\r\n                <p class=\"nome-curso\">");
#nullable restore
#line 14 "C:\Users\FOEU\My Private Documents\Projetos\treino-mvc\Views\Home\Index.cshtml"
                                 Write(curso.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <strong>Descrição:</strong>\r\n                <p class=\"descricao-curso\">\r\n                    ");
#nullable restore
#line 17 "C:\Users\FOEU\My Private Documents\Projetos\treino-mvc\Views\Home\Index.cshtml"
               Write(curso.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 580, "\"", 616, 2);
            WriteAttributeValue("", 587, "/curso/exibircursos/", 587, 20, true);
#nullable restore
#line 19 "C:\Users\FOEU\My Private Documents\Projetos\treino-mvc\Views\Home\Index.cshtml"
WriteAttributeValue("", 607, curso.Id, 607, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"button-curso\" type=\"button\">Fazer curso</a>\r\n            </div>\r\n");
#nullable restore
#line 21 "C:\Users\FOEU\My Private Documents\Projetos\treino-mvc\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<treino_mvc.Models.Curso>> Html { get; private set; }
    }
}
#pragma warning restore 1591
