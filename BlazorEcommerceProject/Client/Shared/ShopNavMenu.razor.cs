using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using BlazorEcommerceProject.Client;
using BlazorEcommerceProject.Client.Shared;
using BlazorEcommerceProject.Shared;
using BlazorEcommerceProject.Client.Services.ProductService;
using BlazorEcommerceProject.Client.Services.CategoryService;

namespace BlazorEcommerceProject.Client.Shared
{
    public partial class ShopNavMenu
    {
        private bool collapseNavMenu = true;
        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetCategories();
        }
    }
}