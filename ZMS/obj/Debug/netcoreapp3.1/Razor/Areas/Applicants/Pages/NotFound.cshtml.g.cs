#pragma checksum "G:\OneDrive\Projects\Git\ZMS\ZMS\Areas\Applicants\Pages\NotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d06f9be5d23924eb8801f06eb3819586eebd7e72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ZMS.Areas.Applicants.Pages.Areas_Applicants_Pages_NotFound), @"mvc.1.0.razor-page", @"/Areas/Applicants/Pages/NotFound.cshtml")]
namespace ZMS.Areas.Applicants.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d06f9be5d23924eb8801f06eb3819586eebd7e72", @"/Areas/Applicants/Pages/NotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1869cba4db4bb26c65ee6361c7be25a1733f0ec9", @"/Areas/Applicants/Pages/_ViewImports.cshtml")]
    public class Areas_Applicants_Pages_NotFound : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\OneDrive\Projects\Git\ZMS\ZMS\Areas\Applicants\Pages\NotFound.cshtml"
   ViewData["Title"] = "NotFound"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div style=""text-align:center;""><h1>Oops... that applicant wasn't found</h1></div>

<div style=""text-align:center;""><a class=""btn btn-outline-secondary"" onclick=""goBack()"">Go Back</a></div>
<script>function goBack() {
  window.history.back();
}</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Areas_Applicants_Pages_NotFound> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Areas_Applicants_Pages_NotFound> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Areas_Applicants_Pages_NotFound>)PageContext?.ViewData;
        public Areas_Applicants_Pages_NotFound Model => ViewData.Model;
    }
}
#pragma warning restore 1591
