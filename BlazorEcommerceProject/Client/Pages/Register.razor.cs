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
using BlazorEcommerceProject.Client.Services.AuthService;
using Blazored.LocalStorage;

namespace BlazorEcommerceProject.Client.Pages
{
    public partial class Register
    {
        UserRegister user = new UserRegister();
        string message = string.Empty;
        string messageCssClass = string.Empty;

        async Task HandleRegistration()
        {
            var result = await AuthService.Register(user);
            message = result.Message;
            if (result.Success)
            {
                messageCssClass = "text-success";
            }
            else
            {
                messageCssClass = "text-danger";
            }
        }
    }
}