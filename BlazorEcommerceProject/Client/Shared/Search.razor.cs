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
    public partial class Search
    {
        private string searchText = string.Empty;
        private List<string> suggestions = new List<string>();
        protected ElementReference searchInput;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await searchInput.FocusAsync();
            }
        }

        public void SearchProducts()
        {
            NavigationManager.NavigateTo($"search/{searchText}");
        }

        public async Task HandleSearch(KeyboardEventArgs args)
        {
            if (args.Key == null || args.Key.Equals("Enter"))
            {
                SearchProducts();
            }
            else if (searchText.Length > 1)
            {
                suggestions = await ProductService.GetProductSearchSuggestions(searchText);
            }
        }
    }
}