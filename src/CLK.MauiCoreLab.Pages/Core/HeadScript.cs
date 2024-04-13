using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Sections;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

namespace CLK.MauiCoreLab.Pages
{
    public sealed class HeadScript : ComponentBase
    {
        // Properties
        [Parameter]
        public RenderFragment? ChildContent { get; set; }


        // Methods
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            // Build
            builder.OpenComponent<SectionContent>(0);
            builder.AddComponentParameter(1, nameof(SectionContent.SectionId), HeadScriptOutlet.SectionId);
            builder.AddComponentParameter(2, nameof(SectionContent.ChildContent), this.ChildContent);
            builder.CloseComponent();
        }
    }
}
