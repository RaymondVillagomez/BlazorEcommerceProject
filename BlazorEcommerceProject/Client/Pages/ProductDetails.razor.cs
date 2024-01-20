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

namespace BlazorEcommerceProject.Client.Pages
{
    public partial class ProductDetails
    {
        private Product? product = null;
        private string message = string.Empty;
        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            message = "Loading Product...";
            var result = await ProductService.GetProduct(Id);
            if (!result.Success)
            {
                message = result.Message;
            }
            else
            {
                product = result.Data;
            }
        }

        private async Task AddToCart()
        {
            var cartItem = new CartItem
            {
                ProductId = product.Id
            };
            await CartService.AddToCart(cartItem);
        }
    }
}