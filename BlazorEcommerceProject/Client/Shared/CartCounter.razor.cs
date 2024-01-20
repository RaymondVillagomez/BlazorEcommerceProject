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
using BlazorEcommerceProject.Client.Services.CartService;
using Blazored.LocalStorage;

namespace BlazorEcommerceProject.Client.Shared
{
    public partial class CartCounter
    {
        private int GetCartItemsCount()
        {
            var cart = LocalStorage.GetItem<List<CartItem>>("cart");
            return cart != null ? cart.Count : 0;
        }

		protected override void OnInitialized()
		{
            CartService.OnChange += StateHasChanged;
		}

        public void Dispose()
        {
            CartService.OnChange -= StateHasChanged;
        }
	}

}