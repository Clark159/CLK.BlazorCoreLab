using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Sections;

namespace CLK.MauiCoreLab.Pages
{
    public sealed class HeadScriptOutlet : ComponentBase
    {
        // Constants
        internal static readonly object SectionId = new();


        // Methods
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            // Build
            builder.OpenComponent<SectionOutlet>(0);
            builder.AddComponentParameter(1, nameof(SectionOutlet.SectionId), SectionId);
            builder.CloseComponent();
        }
    }
}