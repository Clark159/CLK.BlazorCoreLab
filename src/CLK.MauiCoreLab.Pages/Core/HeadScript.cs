using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Sections;

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
