#pragma checksum "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\Party\GetAllParty.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acc0fc76007dfc052b7b921fbcbc2172ef32d16a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Party_GetAllParty), @"mvc.1.0.view", @"/Views/Party/GetAllParty.cshtml")]
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
#line 2 "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\_ViewImports.cshtml"
using PartyProductAPI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acc0fc76007dfc052b7b921fbcbc2172ef32d16a", @"/Views/Party/GetAllParty.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e17b7f040dbcffa5004e7b3e8a3ba3a8c5828ca8", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Party_GetAllParty : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Party", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNewParty", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\Party\GetAllParty.cshtml"
  
    List<PartyModel> allParty = await _partyRepo.GetAllParty();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <h2 class=\"my-3\">Party</h2>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acc0fc76007dfc052b7b921fbcbc2172ef32d16a4330", async() => {
                WriteLiteral("Add Party");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <table class=""table table-striped"">
        <thead class=""bg-dark text-white"">
            <tr>
                <th scope=""col"" class=""py-3"">#</th>
                <th scope=""col"" class=""py-3"">PartyID</th>
                <th scope=""col"" class=""py-3"">PartyName</th>
                <th scope=""col"" class=""py-3"">Action</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 21 "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\Party\GetAllParty.cshtml"
             foreach (PartyModel party in allParty)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td scope=\"row\">");
#nullable restore
#line 24 "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\Party\GetAllParty.cshtml"
                                Write(allParty.IndexOf(party) + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\Party\GetAllParty.cshtml"
                   Write(party.PartyId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\Party\GetAllParty.cshtml"
                   Write(party.PartyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n                        <button class=\"btn btn-sm btn-primary\">");
#nullable restore
#line 28 "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\Party\GetAllParty.cshtml"
                                                          Write(Html.ActionLink("Edit", "UpdateParty", new { id = party.PartyId }, new { @class = "text-white text-decoration-none" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                        <button class=\"btn btn-sm btn-danger\">");
#nullable restore
#line 29 "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\Party\GetAllParty.cshtml"
                                                         Write(Html.ActionLink("Delete", "DeleteParty", new { id = party.PartyId }, new { @class = "text-white text-decoration-none" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 32 "C:\Users\Weybee-N1\Desktop\.NET\Practice Course\Party Product\PartyProductAPI\Views\Party\GetAllParty.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public PartyProductAPI.Repository.IInvoiceRepository _invoiceRepo { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public PartyProductAPI.Repository.IProductRateRepository _productRateRepo { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public PartyProductAPI.Repository.IPartyProductRepository _partyProductRepo { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public PartyProductAPI.Repository.IProductRepository _productRepo { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public PartyProductAPI.Repository.IPartyRepository _partyRepo { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591